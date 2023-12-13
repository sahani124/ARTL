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
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

public partial class Application_Isys_Saim_Customisation_MstActCatgSchm : BaseClass
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
    DataSet dsResult = new DataSet();
    DataAccessClass objDAL = new DataAccessClass();
    StringBuilder sb = new StringBuilder();
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    StringBuilder sb3 = new StringBuilder();
    StringBuilder sb4 = new StringBuilder();

    StringBuilder sb5 = new StringBuilder();
    StringBuilder sb6 = new StringBuilder();
    StringBuilder sb7 = new StringBuilder();
    Microsoft.Office.Interop.Excel.Application excel;
    Microsoft.Office.Interop.Excel.Workbook worKbooK;
    Microsoft.Office.Interop.Excel.Worksheet worksheet;
    Microsoft.Office.Interop.Excel.Range celLrangE;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            divGeographicalLoc.Attributes.Add("display", "none");
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            if (Request.QueryString["SchKey"] != null)
            {
                txtrtgschKey.Text = Request.QueryString["SchKey"].ToString();
                GetFuncDtls22();
            }
          
            if (!IsPostBack)
            {
                try
                {

                    btnDnldGridData.Attributes.Add("disabled", "disabled");
                    //GetFuncDtls22();
                    bindgvcatgStp();  //Added by Rutuja
                    BindListBox(); //Added by DAksh
                    divVisibility(); //Added by DAksh
                    Fillddl(ddlLOBBlkUpd, "lob");
                    Fillddl(ddllob, "lob");
                    Fillddl(ddlProductCode, "Prodcode");
                    Fillddl(ddlpolicyType, "policytype");
                    Fillddl(ddlCPC, "CPC");// Added By arjun
                    Fillddl(DdlPDT, "PDT");// Added By arjun
                    Fillddl(DdlVpscFlag, "VPSC");// Added By arjun


                    Fillddl(ddlsubProductCode, "SubproductCode");
                    Fillddl(ddlSELFIflag, "Selfiflag");
                    Fillddl(ddlULIP, "ulipflag");



                }
                catch (Exception ex)
                {
                    //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                    //string sRet = oInfo.Name;
                    //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    //String LogClassName = method.ReflectedType.Name;
                    objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                }
            }
            // btnDnldGridData.Enabled = false;
            txtLDFrom.Attributes.Add("readonly", "readonly");
            txtLDto.Attributes.Add("readonly", "readonly");
            txtTDFrom.Attributes.Add("readonly", "readonly");
            txtTDto.Attributes.Add("readonly", "readonly");

            //divLoader.Attributes.Add("style", "display:none");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void Fillddl(DropDownList ddl, string LookupCode)    //Added by Rutuja
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FixFctr_FillDropDown", ht);
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "Fillddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void Fillddl(DropDownList ddl, string LookupCode, string lob)    //Added by Rutuja
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            ht.Add("@PRODUCT_TYPE", lob);
            //drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FixFctr_FillDropDown", ht);
            //ds = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", ht);

            ddl.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "Fillddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    void GetFuncDtls22()   //Added by Rutuja
    {

        try
        {
            DataSet ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@ACT_SCHM_KEY", Request.QueryString["SchKey"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetFixFactorControls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string fixfactor = ds.Tables[0].Rows[0]["FIX_FCTR"].ToString().Trim();
                Array fixfactorArr = fixfactor.Split('|');
                string rangefactor = ds.Tables[0].Rows[0]["RNG_FCTR"].ToString().Trim();
                Array rangefactorArr = rangefactor.Split('|');

                Hashtable httd = new Hashtable();
                DataSet dsExcel1 = new DataSet();
                DataTable dtExcel1 = new DataTable();
                dsExcel1.Clear();
                httd.Clear();

                dsExcel1.Tables.Add(dtExcel1);
                dsExcel1.Tables[0].Columns.Add("FIX_FCTR", typeof(string));
                dsExcel1.Tables[0].Columns.Add("RNG_FCTR", typeof(string));
                foreach (string val in fixfactorArr)
                {
                    dsExcel1.Tables[0].Columns.Add(val, typeof(string));

                    if (val == "LOB")
                    {
                        divLob.Style.Add("display", "block");
                    }

                    if (val == "PC")
                    {

                        divPC.Style.Add("display", "block");

                    }
                    if (val == "CPC")
                    {

                        divCPC.Style.Add("display", "block");

                    }
                    if (val == "PDT")
                    {

                        divPDT.Style.Add("display", "block");

                    }

                    if (val == "VPSC")
                    {

                        divVPSC.Style.Add("display", "block");

                    }
                    //if (val == "SPC")
                    //{

                    //    divSPC.Style.Add("display", "block");


                    //}
                    if (val == "PT")
                    {

                        divPT.Style.Add("display", "block");
                    }
                    //if (val == "ULIP")
                    //{
                    //    divULIP.Style.Add("display", "block");
                    //}
                    //if (val == "SELFI")
                    //{
                    //    divFixFactorSELFIandULIPbody.Style.Add("display", "block");
                    //}

                }
                foreach (string val in rangefactorArr)
                {
                    dsExcel1.Tables[0].Columns.Add(val, typeof(string));

                    if (val == "PPT")
                    {

                        divRangeFactorPTFromTo.Style.Add("display", "block");
                    }

                    //if (val == "PWT")
                    //{

                    //    divRangeFactorPWTFromTo.Style.Add("display", "block");
                    //}

                    if (val == "LD")
                    {

                        divRangeFactorLDFromTo.Style.Add("display", "block");
                    }

                    //if (val == "TD")
                    //{
                    //    divRangeFactorTDFromTo.Style.Add("display", "block");
                    //}
                    if (val == "PWOT")
                    {

                        divRangeFactorPWOTFromTo.Style.Add("display", "block");
                    }

                    if (val == "ANP")
                    {

                        divRangeFactorANPFromTo.Style.Add("display", "block");
                    }

                    if (val == "WNBP")
                    {

                        divRangeFactorWNBPFromTo.Style.Add("display", "block");
                    }

                    if (val == "DFP")
                    {

                        divRangeFactorDFPFromTo.Style.Add("display", "block");
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "GetFuncDtls22", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindgvcatgStp()   //Added by Rutuja
    {
        try
        {

            dsfill.Clear();
            Hashtable htable = new Hashtable();
            htable.Add("@ACT_SCHM_KEY", txtrtgschKey.Text);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetRulCatgStp_GRID", htable); //Proc Created by Rutuja in SAIM DB

            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                //btnDnldGridData.Enabled = true;
                gvcatgStp.Columns.Clear();
                foreach (DataColumn column in dsfill.Tables[0].Columns)
                {
                    //ColumnSHowHide(column.ColumnName);

                    BoundField bfield = new BoundField();
                    bfield.HeaderText = column.ColumnName;
                    bfield.DataField = column.ColumnName;
                    if (bfield.DataField == "SEQ_NO")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PPT FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PPT TO")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PWT FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PWT TO")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PWOT FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "PWOT TO")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "LD FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "LD TO")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "TD FROM")
                    {
                        bfield.ReadOnly = true;
                    }

                    if (bfield.DataField == "TD TO")
                    {
                        bfield.ReadOnly = true;
                    }

                    if (bfield.DataField == "ANP FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "ANP TO")
                    {
                        bfield.ReadOnly = true;
                    }

                    if (bfield.DataField == "WNBP FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "WNBP TO")
                    {
                        bfield.ReadOnly = true;
                    }

                    if (bfield.DataField == "DFP FROM")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "DFP TO")
                    {
                        bfield.ReadOnly = true;
                    }


                    if (bfield.DataField == "ACT SCHM KEY")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "ACT SCHM CODE")
                    {
                        bfield.ReadOnly = true;
                    }
                    if (bfield.DataField == "STATUS")
                    {
                        bfield.ReadOnly = true;
                    }

                    if (bfield.DataField == "SEQ NO")
                    {
                        bfield.ReadOnly = true;
                    }

                    gvcatgStp.Columns.Add(bfield);
                }
                gvcatgStp.DataSource = dsfill;
                gvcatgStp.DataBind();
                ViewState["grid"] = dsfill.Tables[0];
                if (gvcatgStp.PageCount == 1)
                {
                    btnnext.Enabled = false;
                    btnprevious.Enabled = false;
                }

                if (gvcatgStp.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
                btnDnldGridData.Attributes.Remove("disabled");
                //btnDnldGridData.Enabled = true;
            }
            else
            {
                btnDnldGridData.Attributes.Add("disabled", "disabled");
                //btnDnldGridData.Enabled = false;
                DataTable dt = new DataTable();
                dt = null;
                gvcatgStp.DataSource = dt;
                gvcatgStp.DataBind();
                //ViewState["grid"] = dsfill.Tables[0];
                btnnext.Enabled = false;
                btnprevious.Enabled = false;

            }

            string role = Convert.ToString(Request.QueryString["role"]);
        }

        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "bindgvcatgStp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void disable_Control(string role)
    {
        if (role != "admin")
        {



        }

    }

    protected void btnprevious_Click(object sender, EventArgs e)   //rutuja
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)    //rutuja
    {
        try
        {
            int pageIndex = gvcatgStp.PageIndex;
            gvcatgStp.PageIndex = pageIndex + 1;
            bindgvcatgStp();
            txtPage.Text = Convert.ToString(gvcatgStp.PageIndex + 1);
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    public void ColumnSHowHide(string Column)  //Added by Rutuja
    {
        try
        {
            string[] columnName = { "[ACT SCHM KEY]" , "[ACT SCHM CODE]","[PPT FROM]" ,
            "[PPT TO]", "[PWOT FROM]", "[PWOT TO]", "[LD FROM]", "[LD TO]", "[TD FROM]", "[TD TO]","[PWT FROM]","[PWT TO]" ,"[RATE]","[STATUS]"
        };

            gvcatgStp.Columns[Array.IndexOf(columnName, Column)].Visible = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "ColumnSHowHide", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void gvcatgStp_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)   //Added by Rutuja
    {
        try
        {
            //btn_Upload.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            int index = e.NewEditIndex;
            gvcatgStp.EditIndex = e.NewEditIndex;
            this.bindgvcatgStp();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "gvcatgStp_RowEditing", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)  //Added by Rutuja
    {
        try
        {
            dsfill.Clear();
            Hashtable htable = new Hashtable();
            htable.Add("@ACT_SCHM_KEY", txtrtgschKey.Text);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetRulCatgStp_GRID", htable); //Proc Created by Rutuja in SAIM DB

            gvcatgStp.DataSource = dsfill;
            gvcatgStp.DataBind();
            ViewState["grid"] = dsfill;

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "btnSearch_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string actno = Request.QueryString["ActNo"].ToString().Trim();
            string kpicode = Request.QueryString["KPIcode"].ToString().Trim();
            string mapcode = Request.QueryString["mapcode"].ToString().Trim();
            string role = Request.QueryString["role"].ToString().Trim();
            string ACT_TYPE = Request.QueryString["ACT_TYPE"].ToString().Trim();
            Response.Redirect("MstActCatgSU.aspx?ActNO=" + actno + "&kpicode=" + kpicode + "&mapcode=" + mapcode + "&role=" + role + "&ACT_TYPE=" + ACT_TYPE);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "btnCancel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvcatgStp_RowDataBound(object sender, GridViewRowEventArgs e)   //Added by Rutuja
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "gvcatgStp_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "gvcatgStp_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)  //Added by Rutuja
    {
        try
        {
            Hashtable htable = new Hashtable();

            //htable.Add("@ACT_SCHM_CODE", ddllob.SelectedValue + "|" + ddlProductCode.SelectedValue + "|" + ddlpolicyType.SelectedValue + "|" + ddlsubProductCode.SelectedValue + "|" + ddlSELFIflag.SelectedValue + "|" + ddlULIP.SelectedValue+"|"+ddlCPC.SelectedValue+"|"+DdlPDT.SelectedValue+"|"+DdlVpscFlag.SelectedValue);

            if (ddllob.SelectedIndex > 0)
            {
                htable.Add("@LOB", ddllob.SelectedValue);
            }
            if (ddlProductCode.SelectedIndex > 0)
            {
                htable.Add("@PC", ddlProductCode.SelectedValue);
            }
            if (DdlPDT.SelectedIndex > 0)
            {
                htable.Add("@PDT", DdlPDT.SelectedValue);
            }
            if (ddlCPC.SelectedIndex > 0)
            {
                htable.Add("@CPC", ddlCPC.SelectedValue);
            }
            if (ddlpolicyType.SelectedIndex > 0)
            {
                htable.Add("@PT", ddlpolicyType.SelectedValue);
            }
            if (DdlVpscFlag.SelectedIndex > 0)
            {
                htable.Add("@VPSC", DdlVpscFlag.SelectedValue);
            }




            //        string[] min_max = new string[]
            //    {
            //        txtLDFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtLDFrom.Text + "\')",
            //        txtLDto.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtLDto.Text + "\')",
            //        txtPayTermFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPayTermFrom.Text  + "\')",
            //        txtPayTermTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPayTermTo.Text + "\')",
            //        txtPremiumWOTaxFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPremiumWOTaxFrom.Text + "\')",
            //        txtPremiumWOTaxTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPremiumWOTaxTo.Text + "\')",       
            //        txtANPFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtANPFrom.Text + "\')",
            //        txtANPTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtANPTo.Text + "\')",
            //        txtWNBPFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtWNBPFrom.Text + "\')",
            //        txtWNBPTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtWNBPTo.Text + "\')",
            //        txtDEPFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtDEPFrom.Text + "\')",
            //        txtDEPTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtDEPTo.Text + "\')"

            //};
            if (txtPayTermFrom.Text != "")
            {
                htable.Add("@PPT_FROM", txtPayTermFrom.Text);
                htable.Add("@PPT_TO", txtPayTermTo.Text);
            }

            if (txtANPFrom.Text != "")
            {
                htable.Add("@ANP_FROM", txtANPFrom.Text);
                htable.Add("@ANP_TO", txtANPTo.Text);
            }
            if (txtPremiumWOTaxFrom.Text != "")
            {
                htable.Add("@PWOT_FROM", txtPremiumWOTaxFrom.Text);
                htable.Add("@PWOT_TO", txtPremiumWOTaxTo.Text);
            }
            if (txtWNBPFrom.Text != "")
            {
                htable.Add("@WNBP_FROM", txtWNBPFrom.Text);
                htable.Add("@WNBP_TO", txtWNBPTo.Text);
            }
            if (txtDEPFrom.Text != "")
            {
                htable.Add("@DFP_FROM", txtDEPFrom.Text);
                htable.Add("@DFP_TO", txtDEPTo.Text);
            }
            if (txtLDFrom.Text != "")
            {
                htable.Add("@LD_FROM", txtLDFrom.Text);
                htable.Add("@LD_TO", txtLDto.Text);
            }

            //  txtPremiumWTaxFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPremiumWTaxFrom.Text + "\')",
            //  txtPremiumWTaxTo.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtPremiumWTaxTo.Text + "\')",
            // txtTDFrom.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtTDFrom.Text + "\')",
            // txtTDto.Text == "" ? ""  : "Convert(varchar(max) , \'" + txtTDto.Text + "\')"
            // string min_max_string = String.Join("|", min_max).ToString().TrimEnd('|');

            // htable.Add("@min_max", min_max_string);
            htable.Add("@ACT_SCHM_KEY", txtrtgschKey.Text);
            htable.Add("@RATE1", txtweightage.Text);
            htable.Add("@CreatedBy", HttpContext.Current.Session["UserId"].ToString());
            dsResult.Clear();
            //  dsResult = objDal.GetDataSetForPrc_SAIM("Prc_Chk_Duplicate_SCHM", htable);
            //if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(dsResult.Tables[0].Rows[0]["COUNTMAIN"].ToString().Trim()) > 0)
            //    {
            objDal.execute_sprc("Prc_Ins_MST_ACT_CATG_SCHM_NEW", htable);
            bindgvcatgStp();
            ClearControl();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Action scheme details added successfully.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "dopostback", "doPostback();", true);
            dsResult.Clear();
            //   }
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
            //}
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
            //btnDnldGridData.Enabled = true;
            //Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "btnAddNew_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void ClearControl()
    {
        try
        {
            txtweightage.Text = "";
            ddllob.SelectedIndex = 0;
            ddlpolicyType.SelectedIndex = 0;
            //ddlSELFIflag.SelectedIndex = 0;
            ddlProductCode.SelectedIndex = 0;
            //ddlsubProductCode.SelectedIndex = 0;
            //ddlULIP.SelectedIndex = 0;
            DdlVpscFlag.SelectedIndex = 0;
            ddlCPC.SelectedIndex = 0;
            DdlPDT.SelectedIndex = 0;


            txtPayTermFrom.Text = "";
            txtPayTermTo.Text = "";
            txtPremiumWTaxFrom.Text = "";
            txtPremiumWTaxTo.Text = "";
            txtLDFrom.Text = "";
            txtLDto.Text = "";
            txtTDFrom.Text = "";
            txtTDto.Text = "";
            txtPremiumWOTaxFrom.Text = "";
            txtPremiumWOTaxTo.Text = "";

            txtWNBPFrom.Text = "";
            txtWNBPTo.Text = "";

            txtDEPFrom.Text = "";
            txtDEPTo.Text = "";
            txtLDFrom.Text = "";
            txtLDto.Text = "";
            txtANPFrom.Text = "";
            txtANPTo.Text = "";


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "ClearControl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindBoundfields()  //Added by Rutuja
    {
        try
        {
            gvcatgStp.Columns.Clear();
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Name";
            bfield.DataField = "Name";
            gvcatgStp.Columns.Add(bfield);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "bindBoundfields", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnlGenExcelFile_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 
    public void BindListBox()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@LookupCode", "Prodcode");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            lstProdCodeBlkUpd.DataSource = dsfill.Tables[0];
            lstProdCodeBlkUpd.DataTextField = "ParamDesc01";
            lstProdCodeBlkUpd.DataValueField = "ParamValue";
            lstProdCodeBlkUpd.DataBind();

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@LookupCode", "PolicyType");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            lstPolicyTypBlkUpd.DataSource = dsfill.Tables[0];
            lstPolicyTypBlkUpd.DataTextField = "ParamDesc01";
            lstPolicyTypBlkUpd.DataValueField = "ParamValue";
            lstPolicyTypBlkUpd.DataBind();


            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@LookupCode", "CPC");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Added by arjun
            lstCPCBlkUpd.DataSource = dsfill.Tables[0];
            lstCPCBlkUpd.DataTextField = "ParamDesc01";
            lstCPCBlkUpd.DataValueField = "ParamValue";
            lstCPCBlkUpd.DataBind();

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@LookupCode", "PDT");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Added by arjun
            lstPDTBlkUpd.DataSource = dsfill.Tables[0];
            lstPDTBlkUpd.DataTextField = "ParamDesc01";
            lstPDTBlkUpd.DataValueField = "ParamValue";
            lstPDTBlkUpd.DataBind();

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@LookupCode", "VPSC");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Added by arjun
            lstVPSCFlagBlkUpd.DataSource = dsfill.Tables[0];
            lstVPSCFlagBlkUpd.DataTextField = "ParamDesc01";
            lstVPSCFlagBlkUpd.DataValueField = "ParamValue";
            lstVPSCFlagBlkUpd.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "SubProductCode");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //lstSubProductCodeBlkUpd.DataSource = dsfill.Tables[0];
            //lstSubProductCodeBlkUpd.DataTextField = "ParamDesc01";
            //lstSubProductCodeBlkUpd.DataValueField = "ParamValue";
            //lstSubProductCodeBlkUpd.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "Selfiflag");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //lstSELFIFlgBlkUpd.DataSource = dsfill.Tables[0];
            //lstSELFIFlgBlkUpd.DataTextField = "ParamDesc01";
            //lstSELFIFlgBlkUpd.DataValueField = "ParamValue";
            //lstSELFIFlgBlkUpd.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "ulipflag");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //lstULIPBlkUpd.DataSource = dsfill.Tables[0];
            //lstULIPBlkUpd.DataTextField = "ParamDesc01";
            //lstULIPBlkUpd.DataValueField = "ParamValue";
            //lstULIPBlkUpd.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "EPAY");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //lstepay.DataSource = dsfill.Tables[0];
            //lstepay.DataTextField = "ParamDesc01";
            //lstepay.DataValueField = "ParamValue";
            //lstepay.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "MSC");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //lstmscbox.DataSource = dsfill.Tables[0];
            //lstmscbox.DataTextField = "ParamDesc01";
            //lstmscbox.DataValueField = "ParamValue";
            //lstmscbox.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "HO");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //ListBoxHO.DataSource = dsfill.Tables[0];
            //ListBoxHO.DataTextField = "ParamDesc01";
            //ListBoxHO.DataValueField = "ParamValue";
            //ListBoxHO.DataBind();

            //htparam.Clear();
            //dsfill.Clear();
            //htparam.Add("@LookupCode", "HUBZONAL");
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
            //ListBoxHubZonal.DataSource = dsfill.Tables[0];
            //ListBoxHubZonal.DataTextField = "ParamDesc01";
            //ListBoxHubZonal.DataValueField = "ParamValue";
            //ListBoxHubZonal.DataBind();

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindListBox", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void divVisibility()
    {
        try
        {
            string fixfactor = string.Empty;
            string rangefactor = string.Empty;
            string[] fixfactorArr;
            string[] rangefactorArr;
            if (Request.QueryString["SchKey"].ToString().Trim() != "")
            {
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@ACT_SCHM_KEY", Request.QueryString["SchKey"].ToString().Trim());
                dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetFixFactorControls", htParam);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    fixfactor = dsResult.Tables[0].Rows[0]["FIX_FCTR"].ToString().Trim();
                    fixfactorArr = fixfactor.Split('|');
                    rangefactor = dsResult.Tables[0].Rows[0]["RNG_FCTR"].ToString().Trim();
                    rangefactorArr = rangefactor.Split('|');

                    foreach (string val in fixfactorArr)
                    {
                        if (val == "LOB")
                        {
                            ddlLOBBlkUpd.Enabled = true;
                        }
                        else if (val == "PC")
                        {
                            lstProdCodeBlkUpd.Enabled = true;
                        }
                        else if (val == "PT")
                        {
                            lstPolicyTypBlkUpd.Enabled = true;
                        }

                        else if (val == "PDT")
                        {
                            lstPDTBlkUpd.Enabled = true;
                        }

                        else if (val == "CPC")
                        {
                            lstCPCBlkUpd.Enabled = true;
                        }
                        else if (val == "VPSC")
                        {
                            lstVPSCFlagBlkUpd.Enabled = true;
                        }


                        //else if (val == "SPC")
                        //{
                        //    lstSubProductCodeBlkUpd.Enabled = true;
                        //}

                        //else if (val == "SELFI")
                        //{
                        //    lstSELFIFlgBlkUpd.Enabled = true;
                        //}
                        //else if (val == "ULIP")
                        //{
                        //    lstULIPBlkUpd.Enabled = true;
                        //}
                        //else if (val == "EPY")
                        //{
                        //    lstepay.Enabled = true;
                        //}
                        //else if (val == "MSC")
                        //{
                        //    lstmscbox.Enabled = true;
                        //}
                        //else if (val == "REGLOC")
                        //{
                        //    divGeographicalLoc.Attributes.Add("display","block");
                        //}
                        else
                        {
                            ddlLOBBlkUpd.Enabled = false;
                            lstProdCodeBlkUpd.Enabled = false;
                            lstPolicyTypBlkUpd.Enabled = false;
                            lstSubProductCodeBlkUpd.Enabled = false;
                            lstSELFIFlgBlkUpd.Enabled = false;
                            lstULIPBlkUpd.Enabled = false;
                            lstepay.Enabled = false;
                            lstmscbox.Enabled = false;
                            divGeographicalLoc.Attributes.Add("display", "none");
                        }
                    }
                    foreach (string value in rangefactorArr)
                    {
                        if (value == "PPT")
                        {
                            BindPTFromTo();
                        }
                        //if (value == "PWT")
                        //{
                        //    BindPWTFromTo();
                        //}
                        if (value == "PWOT")
                        {
                            BindPWOTFromTo();
                        }

                        if (value == "LD")
                        {
                            BindLDFromTo();
                        }

                        if (value == "WNBP")
                        {
                            BindWNBPFromTo();
                        }
                        if (value == "ANP")
                        {
                            BindANPFromTo();
                        }

                        if (value == "DFP")
                        {
                            BindDFPFromTo();
                        }


                        //if (value == "TD")
                        //{
                        //    BindTDFromTo();
                        //}
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "divVisibility", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindPTFromTo()
    {
        try
        {
            sb.Append("<div id = 'divPTFromandToBody'>");
            sb.Append("<div id = 'divPTFromandToInnerBody'>");
            sb.Append("<div class='col-sm-2' style='text-align:left'>");
            sb.Append("<label ID = 'lblPTFromBlkUpd' Class='control-label required'>Pay Term From <span class='counter'> 1 </span></Label>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-3'>");
            sb.Append("<input type = 'text' name='txtPTFromBlkUpd' placeholder='Pay Term From' maxlength='20' onkeypress='return isNumber(event)' id='txtPTFromBlkUpd' Class='form-control'>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-2' style='text-align:left'>");
            sb.Append("<label ID = 'lblPTToBlkUpd' Class='control-label required'>Pay Term To <span class='counter'> 1 </span> </Label>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-3'>");
            sb.Append("<input type= 'text' name='txtPTToBlkUpd' placeholder='Pay Term To' maxlength='20' onkeypress='return isNumber(event)' id='txtPTToBlkUpd' Class='form-control'>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-2'>");
            sb.Append("<input type ='hidden' value='0' id='addPTTo'>");
            string hiddenVal = "PT";
            string click = "customAddClick(\"divPTFromandToBody\",\"divPTFromandToInnerBody\"," + divRangeFactorPTFromToBlkUpd.ClientID + ",\"PT\",\"Pay Term\")";
            string btn = String.Format(@"<button id = 'btnAddPTTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb.Append(btn);
            sb.Append("</div>");
            sb.Append("</div>");

            sb.Append("</div>");
            divRangeFactorPTFromToBlkUpd.InnerHtml = sb.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindPTFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindPWTFromTo()
    {
        try
        {
            sb4.Append("<div id = 'divPWTFromandToBody'>");
            sb4.Append("<div id = 'divPWTFromandToInnerBody'>");
            sb4.Append("<div class='col-sm-2' style='text-align:left'>");
            sb4.Append("<label ID = 'lblPWTFromBlkUpd' Class='control-label required'>PWT From <span class='counter'> 1 </span></Label>");
            sb4.Append("</div>");
            sb4.Append("<div class='col-sm-3'>");
            sb4.Append("<input type = 'text' name='txtPWTFromBlkUpd' placeholder='Premium with Tax From' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtPWTFromBlkUpd' Class='form-control'>");
            sb4.Append("</div>");
            sb4.Append("<div class='col-sm-2' style='text-align:left'>");
            sb4.Append("<label ID = 'lblPWTToBlkUpd' Class='control-label required'>PWT To <span class='counter'> 1 </span></Label>");
            sb4.Append("</div>");
            sb4.Append("<div class='col-sm-3'>");
            sb4.Append("<input type= 'text' name='txtPWTToBlkUpd' placeholder='Premium with Tax To' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtPWTToBlkUpd' Class='form-control'>");
            sb4.Append("</div>");
            sb4.Append("<div class='col-sm-2'>");
            sb4.Append("<input type ='hidden' value='0' id='addPWTTo'>");
            string click = "customAddClick(\"divPWTFromandToBody\", \"divPWTFromandToInnerBody\", " + divRangeFactorPWTFromToBlkUpd.ClientID + ",\"PWT\",\"PWT\")";
            //string click = "addClickPWTTo(divPWTFromandToBody,divPWTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddPWTTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb4.Append(btn);
            sb4.Append("</div>");
            sb4.Append("</div>");

            sb4.Append("</div>");
            divRangeFactorPWTFromToBlkUpd.InnerHtml = sb4.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindPWTFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindPWOTFromTo()
    {
        try
        {
            sb1.Append("<div id = 'divPWOTFromandToBody'>");
            sb1.Append("<div id = 'divPWOTFromandToInnerBody'>");
            sb1.Append("<div class='col-sm-2' style='text-align:left'>");
            sb1.Append("<label ID = 'lblPWOTFromBlkUpd' Class='control-label required'>PWOT From <span class='counter'> 1 </span></Label>");
            sb1.Append("</div>");
            sb1.Append("<div class='col-sm-3'>");
            sb1.Append("<input type = 'text' name='txtPWOTFromBlkUpd' placeholder='Premium without Tax From' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtPWOTFromBlkUpd' Class='form-control'>");
            sb1.Append("</div>");
            sb1.Append("<div class='col-sm-2' style='text-align:left'>");
            sb1.Append("<label ID = 'lblPWOTToBlkUpd' Class='control-label required'>PWOT To <span class='counter'> 1 </span></Label>");
            sb1.Append("</div>");
            sb1.Append("<div class='col-sm-3'>");
            sb1.Append("<input type= 'text' name='txtPWOTToBlkUpd' placeholder='Premium without Tax To' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtPWOTToBlkUpd' Class='form-control'>");
            sb1.Append("</div>");
            sb1.Append("<div class='col-sm-2'>");
            sb1.Append("<input type ='hidden' value='0' id='addPWOTTo'>");
            string click = "customAddClick(\"divPWOTFromandToBody\", \"divPWOTFromandToInnerBody\", " + divRangeFactorPWOTFromToBlkUpd.ClientID + ",\"PWOT\",\"PWOT\")";
            //string click = "addClickPWOTTo(divPWOTFromandToBody,divPWOTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddPWOTTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb1.Append(btn);
            sb1.Append("</div>");
            sb1.Append("</div>");

            sb1.Append("</div>");
            divRangeFactorPWOTFromToBlkUpd.InnerHtml = sb1.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindPWOTFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindLDFromTo()
    {
        try
        {
            //onmousedown='populateDateT(this.id)' onmouseup='populateDateT(this.id)'
            sb2.Append("<div id = 'divLDFromandToBody'>");
            sb2.Append("<div id = 'divLDTFromandToInnerBody'>");
            sb2.Append("<div class='col-sm-2' style='text-align:left'>");
            sb2.Append("<label ID = 'lblLDFromBlkUpd' Class='control-label required'>LogIn Date From <span class='counter'> 1 </span></Label>");
            sb2.Append("</div>");
            sb2.Append("<div class='col-sm-3'>");
            sb2.Append("<input type = 'text' readonly name='txtLDFromBlkUpd' placeholder='LogIn Date From' onclick='callDate(this)' id='txtLDFromBlkUpd' Class='form-control'>");
            sb2.Append("</div>");
            sb2.Append("<div class='col-sm-2' style='text-align:left'>");
            sb2.Append("<label ID = 'lblLDToBlkUpd' Class='control-label required'>LogIn Date To <span class='counter'> 1 </span></Label>");
            sb2.Append("</div>");
            sb2.Append("<div class='col-sm-3'>");
            sb2.Append("<input type= 'text' readonly name='txtLDToBlkUpd' placeholder='LogIn Date To' onclick='callDate(this)' id='txtLDToBlkUpd' Class='form-control'>");
            sb2.Append("</div>");
            sb2.Append("<div class='col-sm-2'>");
            sb2.Append("<input type ='hidden' value='0' id='addLDFromTo'>");
            string click = "customAddClick(\"divLDFromandToBody\", \"divLDTFromandToInnerBody\", " + divRangeFactorLDFromToBlkUpd.ClientID + ",\"LD\",\"LogIn Date\")";
            //string click = "addClickLDFromTo(divLDFromandToBody,divLDTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddLDFromTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb2.Append(btn);
            sb2.Append("</div>");
            sb2.Append("</div>");

            sb2.Append("</div>");
            divRangeFactorLDFromToBlkUpd.InnerHtml = sb2.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindLDFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindTDFromTo()
    {
        try
        {
            sb3.Append("<div id = 'divTDFromandToBody'>");
            sb3.Append("<div id = 'divTDTFromandToInnerBody'>");
            sb3.Append("<div class='col-sm-2' style='text-align:left'>");
            sb3.Append("<label ID = 'lblTDFromBlkUpd' Class='control-label required'>Trans. Date From <span class='counter'> 1 </span></Label>");
            sb3.Append("</div>");
            sb3.Append("<div class='col-sm-3'>");
            sb3.Append("<input type = 'text' readonly name='txtTDFromBlkUpd' placeholder='Transaction Date From' onclick='callDate(this)'  id='txtTDFromBlkUpd' Class='form-control'>");
            sb3.Append("</div>");
            sb3.Append("<div class='col-sm-2' style='text-align:left'>");
            sb3.Append("<label ID = 'lblTDToBlkUpd' Class='control-label required'>Trans. Date To <span class='counter'> 1 </span></Label>");
            sb3.Append("</div>");
            sb3.Append("<div class='col-sm-3'>");
            sb3.Append("<input type= 'text' readonly name='txtTDToBlkUpd' placeholder='Transaction Date To' onclick='callDate(this)'  id='txtTDToBlkUpd' Class='form-control'>");
            sb3.Append("</div>");
            sb3.Append("<div class='col-sm-2'>");
            sb3.Append("<input type ='hidden' value='0' id='addTDFromTo'>");
            string click = "customAddClick(\"divTDFromandToBody\", \"divTDTFromandToInnerBody\", " + divRangeFactorTDFromToBlkUpd.ClientID + ",\"TD\",\"Trans. Date\")";
            //string click = "addClickTDFromTo(divTDFromandToBody,divTDTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddTDFromTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb3.Append(btn);
            sb3.Append("</div>");
            sb3.Append("</div>");

            sb3.Append("</div>");
            divRangeFactorTDFromToBlkUpd.InnerHtml = sb3.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindTDFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void BindDFPFromTo()
    {
        try
        {

            sb5.Append("<div id = 'divDFPFromandToBody'>");
            sb5.Append("<div id = 'divDFPFromandToInnerBody'>");
            sb5.Append("<div class='col-sm-2' style='text-align:left'>");
            sb5.Append("<label ID = 'lblDFPFromBlkUpd' Class='control-label required'>Deferment From <span class='counter'> 1 </span></Label>");
            sb5.Append("</div>");
            sb5.Append("<div class='col-sm-3'>");
            sb5.Append("<input type = 'text' name='txtDFPFromBlkUpd' placeholder='Deferment From' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtDFPFromBlkUpd' Class='form-control'>");
            sb5.Append("</div>");
            sb5.Append("<div class='col-sm-2' style='text-align:left'>");
            sb5.Append("<label ID = 'lblDFPToBlkUpd' Class='control-label required'>Deferment To <span class='counter'> 1 </span></Label>");
            sb5.Append("</div>");
            sb5.Append("<div class='col-sm-3'>");
            sb5.Append("<input type= 'text' name='txtDFPToBlkUpd' placeholder='Deferment To' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtDFPToBlkUpd' Class='form-control'>");
            sb5.Append("</div>");
            sb5.Append("<div class='col-sm-2'>");
            sb5.Append("<input type ='hidden' value='0' id='addDFPTo'>");
            string click = "customAddClick(\"divDFPFromandToBody\", \"divDFPFromandToInnerBody\", " + divRangeFactorDFPFromToBlkUpd.ClientID + ",\"DFP\",\"Deferment \")";
            //string click = "addClickPWOTTo(divPWOTFromandToBody,divPWOTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddDFPTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb5.Append(btn);
            sb5.Append("</div>");
            sb5.Append("</div>");

            sb5.Append("</div>");
            divRangeFactorDFPFromToBlkUpd.InnerHtml = sb5.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindDFPFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindANPFromTo()
    {
        try
        {
            sb6.Append("<div id = 'divANPFromandToBody'>");
            sb6.Append("<div id = 'divANPFromandToInnerBody'>");
            sb6.Append("<div class='col-sm-2' style='text-align:left'>");
            sb6.Append("<label ID = 'lblANPFromBlkUpd' Class='control-label required'>ANP From <span class='counter'> 1 </span></Label>");
            sb6.Append("</div>");
            sb6.Append("<div class='col-sm-3'>");
            sb6.Append("<input type = 'text' name='txtANPFromBlkUpd' placeholder='Annualised Premium From' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtANPFromBlkUpd' Class='form-control'>");
            sb6.Append("</div>");
            sb6.Append("<div class='col-sm-2' style='text-align:left'>");
            sb6.Append("<label ID = 'lblANPToBlkUpd' Class='control-label required'>ANP To <span class='counter'> 1 </span></Label>");
            sb6.Append("</div>");
            sb6.Append("<div class='col-sm-3'>");
            sb6.Append("<input type= 'text' name='txtANPToBlkUpd' placeholder='Annualised Premium To' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtANPToBlkUpd' Class='form-control'>");
            sb6.Append("</div>");
            sb6.Append("<div class='col-sm-2'>");
            sb6.Append("<input type ='hidden' value='0' id='addANPTo'>");
            string click = "customAddClick(\"divANPFromandToBody\", \"divANPFromandToInnerBody\", " + divRangeFactorANPFromToBlkUpd.ClientID + ",\"ANP\",\"ANP\")";
            //string click = "addClickPWOTTo(divPWOTFromandToBody,divPWOTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddANPTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb6.Append(btn);
            sb6.Append("</div>");
            sb6.Append("</div>");

            sb6.Append("</div>");
            divRangeFactorANPFromToBlkUpd.InnerHtml = sb6.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindANPFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    //WNBP
    //DFP
    //ANP
    protected void BindWNBPFromTo()
    {
        try
        {
            sb7.Append("<div id = 'divWNBPFromandToBody'>");
            sb7.Append("<div id = 'divWNBPFromandToInnerBody'>");
            sb7.Append("<div class='col-sm-2' style='text-align:left'>");
            sb7.Append("<label ID = 'lblWNBPFromBlkUpd' Class='control-label required'>WNBP From <span class='counter'> 1 </span></Label>");
            sb7.Append("</div>");
            sb7.Append("<div class='col-sm-3'>");
            sb7.Append("<input type = 'text' name='txtWNBPFromBlkUpd' placeholder='WNBP From' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtWNBPFromBlkUpd' Class='form-control'>");
            sb7.Append("</div>");
            sb7.Append("<div class='col-sm-2' style='text-align:left'>");
            sb7.Append("<label ID = 'lblWNBPToBlkUpd' Class='control-label required'>WNBP To <span class='counter'> 1 </span></Label>");
            sb7.Append("</div>");
            sb7.Append("<div class='col-sm-3'>");
            sb7.Append("<input type= 'text' name='txtWNBPToBlkUpd' placeholder='WNBP To' maxlength='20' onkeypress='return validateFloatKeyPress(this,event);' id='txtWNBPToBlkUpd' Class='form-control'>");
            sb7.Append("</div>");
            sb7.Append("<div class='col-sm-2'>");
            sb7.Append("<input type ='hidden' value='0' id='addWNBPTo'>");
            string click = "customAddClick(\"divWNBPFromandToBody\", \"divWNBPFromandToInnerBody\", " + divRangeFactorWNBPFromToBlkUpd.ClientID + ",\"WNBP\",\"WNBP \")";
            //string click = "addClickPWOTTo(divPWOTFromandToBody,divPWOTFromandToInnerBody)";
            string btn = String.Format(@"<button id = 'btnAddWNBPTo' onclick='{0}' class='icon-button' title='Add' type = 'button'><i style = 'font-size:x-large' class='viewadd' ></i></button>", click);
            sb7.Append(btn);
            sb7.Append("</div>");
            sb7.Append("</div>");

            sb7.Append("</div>");
            divRangeFactorWNBPFromToBlkUpd.InnerHtml = sb7.ToString();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "BindWNBPFromTo", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public class SaveData
    {
        public string divFromTo { get; set; }
    }

    [WebMethod(EnableSession = true)]
    public static string GenerateList(string Data)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataAccessClass objDal = new DataAccessClass();
            DataSet dsResult = new DataSet();
            Application_Isys_Saim_Customisation_MstActCatgSchm n = new Application_Isys_Saim_Customisation_MstActCatgSchm();
            DataTable dt = n.Tabulate(Data);
            DataSet data = JsonConvert.DeserializeObject<DataSet>(Data);
            htParam.Clear();
            #region Loop
            string paramKey = "@";
            for (int i = 0; i < data.Tables.Count; i++)
            {
                if (data.Tables[i] != null)
                {
                    htParam.Add(paramKey + data.Tables[i].TableName, data.Tables[i]);
                }
            }
            #endregion Loop

            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetGeneratedDtls", htParam);
            //dsResult.Tables[0].Columns.Add("Rate");
            //dsResult.AcceptChanges();
            string JSONresult = JsonConvert.SerializeObject(dsResult.Tables[0]);
            return JSONresult;
            //return "1";

            //n.downloadExcel(dsResult);
            //n.ExportCSV(dsResult.Tables[0], "SampleCategorySchemeFile");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Tabulate(string json)
    {
        var jsonLinq = JObject.Parse(json);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }

        return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
    }

    public int ExportCSV(DataTable data, string fileName)
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

        }

        return Rest;
    }

    protected void downloadExcel(DataSet dsResult)
    {
        try
        {
            Hashtable hparam = new Hashtable();
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            worKbooK = excel.Workbooks.Add(Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
            DataSet dsQuestion = new DataSet();
            Hashtable hTable = new Hashtable();

            dsQuestion = dsResult;

            for (int i = 0; i < dsQuestion.Tables[0].Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dsQuestion.Tables[0].Columns[i].ColumnName;
                //worksheet.Cells[1, i + 1].Font.Color = System.Drawing.Color.Black;
                //worksheet.Cells[1, i + 1].Font.FontStyle = System.Drawing.FontStyle.Bold;
                //worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.Color.Yellow;
            }

            for (int i = 0; i < dsQuestion.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < dsQuestion.Tables[0].Columns.Count; j++)
                {
                    worksheet.Cells[2 + i, j + 1] = dsQuestion.Tables[0].Rows[i][j];
                }
            }


            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
            celLrangE.EntireColumn.AutoFit();
            //celLrangE.EntireColumn[2].Hidden = true;
            //worksheet.Columns[2].Hidden = True;
            //celLrangE.EntireColumn[3].Locked = true;

            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
            Missing mv = Missing.Value;
            worksheet.Columns.Locked = false;
            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 1], (object)worksheet.Cells[1, 12])).EntireColumn.Locked = true;
            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 15], (object)worksheet.Cells[1, 36])).EntireColumn.Locked = true;
            worksheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlUnlockedCells;
            worksheet.Protect(mv, mv, mv, mv, mv, false, mv, mv, mv, mv, mv, mv, mv, mv, mv, mv);
            string tempPath = "D:\\Daksh2.xlsx";
            worKbooK.SaveAs(tempPath, worKbooK.FileFormat);//create temporary file from the workbook
            tempPath = worKbooK.FullName;
            //worKbooK.SaveAs(saveExcel(), Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, mv, mv, mv, mv, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, mv, mv, mv, mv, mv);
            //worKbooK.SaveAs(saveExcel(), Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, mv, mv, mv, mv, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, mv, mv, mv, mv, mv);
            //worKbooK.sa("my-workbook.xls");
            //worKbooK.SaveAs("E:\\Das.xlsx");
            worKbooK.Close();
            //byte[] result = File.ReadAllBytes(tempPath);//change to byte[]

            excel.Quit();
            FileInfo file = new FileInfo(tempPath);
            if (file.Exists)
            {
                try
                {
                    Response.ContentType = "application/vnd.xls";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Daksh2.xlsx");
                    //Response.TransmitFile(Server.MapPath("~/images/sailbig.jpg"));
                    Response.End();

                    //Response.AddHeader("content-disposition", "attachment; filename=" + "ASD" + ".xlsx");
                    //Response.AddHeader("Content-Type", "application/Excel");
                    //Response.ContentType = "application/vnd.xls";
                    //Response.AddHeader("Content-Length", file.Length.ToString());
                    //Response.WriteFile(file.FullName);
                    //Response.End();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "downloadExcel", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void lnlGenExcelFile_Click1(object sender, EventArgs e)
    {
        try
        {
            string json = respJSON.Value;
            DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
            ExportCSV(data.Tables[0], "SampleCategorySchemeFile");
            //downloadExcel(data);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "lnlGenExcelFile_Click1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            gvcatgStp.EditIndex = -1;
            bindgvcatgStp();
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnDnldGridData_Click(object sender, EventArgs e)
    {
        Hashtable htable = new Hashtable();
        dsfill.Clear();
        htable.Clear();
        htable.Add("@ACT_SCHM_KEY", txtrtgschKey.Text);
        dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetRulCatgStp_GRID", htable); //Proc Created by Rutuja in SAIM DB

        if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
        {
            ExportCSV(dsfill.Tables[0], "ActionSchemes");
        }
    }

    protected void gvcatgStp_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ShowProgress()", true);
            //divLoading.Attributes.Add("style", "display:block");
            GridView gvcatgStp = sender as GridView;
            string Rate = Convert.ToString(e.NewValues["RATE"]);
            int SeqNo = Convert.ToInt32(gvcatgStp.Rows[e.RowIndex].Cells[1].Text);
            dsfill.Clear();
            htparam.Clear();
            htparam.Add("@ACT_SCHM_KEY", Request.QueryString["SchKey"].ToString());
            htparam.Add("@RATE", Rate);
            htparam.Add("@SEQNO", SeqNo);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_Upd_MST_ACT_CATG_SCHM", htparam); //Proc Created by Rutuja in SAIM DB
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "popAlert()", true);
            gvcatgStp.EditIndex = -1;
            bindgvcatgStp();
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "HideShowProgress()", true);
            //divLoading.Attributes.Add("style", "display:none");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSchm", "gvcatgStp_RowUpdating", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void ListBoxHO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxHO.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxHO.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "HZ");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxHubZonal.Items.Clear();
            ListBoxZonal.Items.Clear();
            ListBoxStateOffc.Items.Clear();
            ListBoxRegionOffc.Items.Clear();
            ListBoxAreaOffc.Items.Clear();
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();


            if (dtRead.HasRows)
            {
                ListBoxHubZonal.DataSource = dtRead;
                ListBoxHubZonal.DataTextField = "paramdesc";
                ListBoxHubZonal.DataValueField = "paramval";
                ListBoxHubZonal.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxHO_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxHubZonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxHubZonal.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxHubZonal.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "ZO");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxZonal.Items.Clear();
            ListBoxStateOffc.Items.Clear();
            ListBoxRegionOffc.Items.Clear();
            ListBoxAreaOffc.Items.Clear();
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxZonal.DataSource = dtRead;
                ListBoxZonal.DataTextField = "paramdesc";
                ListBoxZonal.DataValueField = "paramval";
                ListBoxZonal.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxHubZonal_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxZonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxZonal.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxZonal.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "SO");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxStateOffc.Items.Clear();
            ListBoxRegionOffc.Items.Clear();
            ListBoxAreaOffc.Items.Clear();
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxStateOffc.DataSource = dtRead;
                ListBoxStateOffc.DataTextField = "paramdesc";
                ListBoxStateOffc.DataValueField = "paramval";
                ListBoxStateOffc.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxZonal_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxStateOffc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxStateOffc.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxStateOffc.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "RO");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxRegionOffc.Items.Clear();
            ListBoxAreaOffc.Items.Clear();
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxRegionOffc.DataSource = dtRead;
                ListBoxRegionOffc.DataTextField = "paramdesc";
                ListBoxRegionOffc.DataValueField = "paramval";
                ListBoxRegionOffc.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxStateOffc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxRegionOffc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxRegionOffc.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxRegionOffc.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "AR");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxAreaOffc.Items.Clear();
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxAreaOffc.DataSource = dtRead;
                ListBoxAreaOffc.DataTextField = "paramdesc";
                ListBoxAreaOffc.DataValueField = "paramval";
                ListBoxAreaOffc.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxRegionOffc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxAreaOffc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxAreaOffc.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxAreaOffc.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "BR");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxBranchOffc.Items.Clear();
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxBranchOffc.DataSource = dtRead;
                ListBoxBranchOffc.DataTextField = "paramdesc";
                ListBoxBranchOffc.DataValueField = "paramval";
                ListBoxBranchOffc.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxAreaOffc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxBranchOffc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxBranchOffc.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxBranchOffc.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "SU");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxSalesUnit.Items.Clear();
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxSalesUnit.DataSource = dtRead;
                ListBoxSalesUnit.DataTextField = "paramdesc";
                ListBoxSalesUnit.DataValueField = "paramval";
                ListBoxSalesUnit.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxBranchOffc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ListBoxSalesUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = ListBoxSalesUnit.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => ListBoxSalesUnit.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@RptUnitCode", String.Join(",", Channels));
            htparam.Add("@UnitType", "SS");
            htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_Hierarchical_GeoLOC", htparam);
            ListBoxSubSalesUnit.Items.Clear();
            if (dtRead.HasRows)
            {
                ListBoxSubSalesUnit.DataSource = dtRead;
                ListBoxSubSalesUnit.DataTextField = "paramdesc";
                ListBoxSubSalesUnit.DataValueField = "paramval";
                ListBoxSubSalesUnit.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "MstActCatgSchm", "ListBoxSalesUnit_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void ddlLOBBlkUpd_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Fillddl(lstProdCodeBlkUpd, "Prodcode", ddlLOBBlkUpd.SelectedValue.ToString());
        ////Fillddl(ddlpolicyType, "policytype");
        //Fillddl(lstCPCBlkUpd, "CPC", ddlLOBBlkUpd.SelectedValue.ToString());

        htparam.Clear();
        dsfill.Clear();
        htparam.Add("@LookupCode", "Prodcode");
        htparam.Add("@PRODUCT_TYPE", ddlLOBBlkUpd.SelectedValue.ToString());
        dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB

        lstProdCodeBlkUpd.Items.Clear();
        lstProdCodeBlkUpd.DataSource = dsfill.Tables[0];
        lstProdCodeBlkUpd.DataTextField = "ParamDesc01";
        lstProdCodeBlkUpd.DataValueField = "ParamValue";
        lstProdCodeBlkUpd.DataBind();

        //htparam.Clear();
        //dsfill.Clear();
        //htparam.Add("@LookupCode", "PolicyType");
        //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Proc Created by Daksh in SAIM DB
        //lstPolicyTypBlkUpd.DataSource = dsfill.Tables[0];
        //lstPolicyTypBlkUpd.DataTextField = "ParamDesc01";
        //lstPolicyTypBlkUpd.DataValueField = "ParamValue";
        //lstPolicyTypBlkUpd.DataBind();


        htparam.Clear();
        dsfill.Clear();
        htparam.Add("@LookupCode", "CPC");
        htparam.Add("@PRODUCT_TYPE", ddlLOBBlkUpd.SelectedValue.ToString());
        dsfill = objDal.GetDataSetForPrc_SAIM("Prc_FixFctr_FillDropDown", htparam); //Added by arjun
        lstCPCBlkUpd.Items.Clear();
        lstCPCBlkUpd.DataSource = dsfill.Tables[0];
        lstCPCBlkUpd.DataTextField = "ParamDesc01";
        lstCPCBlkUpd.DataValueField = "ParamValue";
        lstCPCBlkUpd.DataBind();
    }
}
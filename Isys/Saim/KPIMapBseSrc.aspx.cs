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

public partial class Application_ISys_Saim_KPIMapBseSrc : BaseClass
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
    string kpicode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            fillKPI_MAP_CODE();
            fillKPI();

            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                kpicode = Request.QueryString["kpicode"].ToString().Trim();
            }


            txtEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDJEffFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDCJoinEffFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TxtWhrEffFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtmapEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // divDefColJoin.Attributes.Add("style", "display:none");

            txtIntGid.Text = kpicode;
            Getmapkpibstbl(dgmapkpibsetbl);
            Bindddl(ddlbsetbl, "B");
            Bindddl(ddlSrctbl, "S");
            BindDdlStatus(ddlStatus);
            BindDdlStatus(MapddlStatus);
            bindDEFJOIN(kpicode);
            bindWhrCond();

            Fillddl(ddlDCJoinStatus, "STS", string.Empty);
            ddlDCJoinStatus.SelectedValue = "1";

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('" + hdnTabIndex.Value.ToString() + "');", true);
    }

    protected void fillKPI_MAP_CODE()
    {
        try
        {
            ds.Clear();

            //ds = objDal.GetDataSetForPrc("Prc_GetMaxKPI_BSRC_MPCODE");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxKPI_BSRC_MPCODE");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtkpiBseSrcMapCode.Text = ds.Tables[0].Rows[0]["maxKPI_BSRC_MPCODE"].ToString();

            }

            txtkpiBseSrcMapCode.Enabled = false;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIdesc", "fillKPI_MAP_CODE", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void fillKPI()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            //ds = objDal.GetDataSetForPrc("Prc_GETKPI_DESC", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GETKPI_DESC", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtkpicoddesc.Text = ds.Tables[0].Rows[0]["KPI_DESC_01"].ToString();

            }

            txtkpicoddesc.Enabled = false;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIdesc", "fillKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void Bindddl(DropDownList ddl, String Flag)
    {
        try
        {

            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                kpicode = Request.QueryString["kpicode"].ToString().Trim();
            }


            ds.Clear();
            htParam.Clear();
            htParam.Add("@FLAG", Flag.ToString().Trim());
            htParam.Add("@kpi_code", kpicode);
            //ds = objDal.GetDataSetForPrc("PRC_DDLDATBINDTBL", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DDLDATBINDTBL", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "TBL_NAME";
                ddl.DataValueField = "OBJ_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "BindddlBseTbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    public void BindDdlStatus(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            // htParam.Add("@FLAG", Flag.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_DDLSTATUS", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DDLSTATUS", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();

            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));
            ddl.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "BindddlBseTbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Bindddl(ddlbsetbl, "B");
            Bindddl(ddlSrctbl, "S");

            txtceasedt.Text = "";

            ddlStatus.Enabled = false;
            txtEffDtFrm.Enabled = false;
            txtceasedt.Enabled = false;
            ddlStatus.SelectedValue = "1";

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnClear_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            if (ddlbsetbl.SelectedItem.Text.ToString() == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Base table name');", true);
                return;


            }
            else
            {
                ht.Add("@BSE_TBL", ddlbsetbl.SelectedValue.ToString().Trim());
            }

            if (ddlSrctbl.SelectedItem.Text.ToString() == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source table name');", true);
                return;


            }
            else
            {
                ht.Add("@SRC_TBL", ddlSrctbl.SelectedValue.ToString().Trim());
            }


            if (ddlStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                return;

            }
            else if (ddlStatus.SelectedValue.ToString() == "0" && txtceasedt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Cease Date');", true);
                return;

            }
            else
            {
                ht.Add("@status", ddlStatus.SelectedValue.ToString().Trim());
            }

            ht.Add("@KPI_BSE_SRC_MAP_CODE", txtkpiBseSrcMapCode.Text.ToString());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());

            if (txtEffDtFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", txtEffDtFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtEffDtFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtceasedt.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", txtceasedt.Text);

            }
            else
            {


                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtceasedt.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            ht.Add("@Flag", "I");


            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_MAP_SU", ht);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ///ScriptManager.RegisterStartupScript(this, this.GetType(), popup, "alert('Data Deleted Successfully.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully.');", true);

                }

                else if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
                {
                    ///ScriptManager.RegisterStartupScript(this, this.GetType(), popup, "alert('Data Deleted Successfully.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already exists.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }

            }







            Getmapkpibstbl(dgmapkpibsetbl);

            btnClear_Click(sender, e);



            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                kpicode = Request.QueryString["kpicode"].ToString().Trim();
            }
            bindDEFJOIN(kpicode);

            fillKPI_MAP_CODE();


            //  Response.Redirect(Page.Request.Url.AbsoluteUri);

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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

    protected void Getmapkpibstbl(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TBL", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgmapkpibsetbl.Columns[7].Visible = true;


                    if (dgmapkpibsetbl.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                        btnprevious.Enabled = false;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        btnprevious.Enabled = false;
                    }

                }
                else
                {
                    dgmapkpibsetbl.Columns[7].Visible = false;

                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, dg);
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "GetSrcTblData", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgmapkpibsetbl.PageIndex;
            dgmapkpibsetbl.PageIndex = pageIndex - 1;
            Getmapkpibstbl(dgmapkpibsetbl);
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
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgmapkpibsetbl.PageIndex;
            dgmapkpibsetbl.PageIndex = pageIndex + 1;
            Getmapkpibstbl(dgmapkpibsetbl);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgmapkpibsetbl.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgmapkpibsetbl.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgmapkpibsetbl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "dgmapkpibsetbl_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkmapbsetblsrctbl_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnKpiCode = (HiddenField)row.FindControl("hdnKpiCode");
            HiddenField hdnbsetbl = (HiddenField)row.FindControl("hdnbsetbl");
            HiddenField hdnSrctbl = (HiddenField)row.FindControl("hdnSrctbl");
            htParam.Clear();
            ds.Clear();
            htParam.Add("@KPI_CODE", hdnKpiCode.Value.ToString().Trim());
            htParam.Add("@BSE_TBL", hdnbsetbl.Value.ToString().Trim());
            htParam.Add("@SRC_TBL", hdnSrctbl.Value.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_COD", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSrctblNam.Text = ds.Tables[0].Rows[0]["SRC_TBL_ID"].ToString();
                string KPI_MAP_CODE = ds.Tables[0].Rows[0]["KPI_BSE_SRC_MAP_CODE"].ToString();
                Session["KPI_MAP_CODE"] = KPI_MAP_CODE;
                string OBJ_ID_BSE = ds.Tables[1].Rows[0]["OBJ_ID_BSE"].ToString();
                Session["OBJ_ID_BSE"] = OBJ_ID_BSE;
                string OBJ_ID_SRC = ds.Tables[2].Rows[0]["OBJ_ID_SRC"].ToString();
                Session["OBJ_ID_SRC"] = OBJ_ID_SRC;
                hdnKPIMapCode.Value = ds.Tables[0].Rows[0]["KPI_BSE_SRC_MAP_CODE"].ToString();
            }
            txtSrctblNam.Enabled = false;
            txtpagecol.Text = "1";
            Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);
            bindddlBseCol(ddlBsetblCol);
            bindddlSrcCol(ddlSrctblCol);
            BindDdlStatus(MapddlStatus);
            MapddlStatus.SelectedIndex = 1;
            //BindddlStatus(ddlstatus1);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "lnkmapbsetblsrctbl_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgmapbsetbltosrctbl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "dgmapbsetbltosrctbl_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void Getmapbsetbltosrctbl(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            string KPI_MAP_CODE1 = (string)(Session["KPI_MAP_CODE"]);
            htParam.Add("@KPI_MAP_CODE", KPI_MAP_CODE1.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TO_SRC_TBL", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (dgmapbsetbltosrctbl.PageCount > 1)
                    {
                        btnnextcol.Enabled = true;
                        btnpreviouscol.Enabled = false;
                    }
                    else
                    {
                        btnnextcol.Enabled = false;
                        btnpreviouscol.Enabled = false;
                    }
                }
                else
                {
                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, dg);
                }

            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "Getmapbsetbltosrctbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnpreviouscol_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgmapbsetbltosrctbl.PageIndex;
            dgmapbsetbltosrctbl.PageIndex = pageIndex - 1;
            Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);
            txtpagecol.Text = Convert.ToString(Convert.ToInt32(txtpagecol.Text) - 1);
            if (txtpagecol.Text == "1")
            {
                btnpreviouscol.Enabled = false;
            }
            else
            {
                btnpreviouscol.Enabled = true;
            }
            btnnextcol.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Defbassrctbl", "btnpreviouscol_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextcol_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgmapbsetbltosrctbl.PageIndex;
            dgmapbsetbltosrctbl.PageIndex = pageIndex + 1;
            Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);
            txtpagecol.Text = Convert.ToString(Convert.ToInt32(txtpagecol.Text) + 1);
            btnpreviouscol.Enabled = true;
            if (txtpagecol.Text == Convert.ToString(dgmapbsetbltosrctbl.PageCount))
            {
                btnnextcol.Enabled = false;
            }
            int page = dgmapbsetbltosrctbl.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Defbassrctbl", "btnnextcol_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddlBseSrc(DropDownList ddl, String Flag)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BASE_SRC_TBL_COL_DAT_TYP");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "DATA_TYP";
                ddl.DataValueField = "DATA_TYP_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Defbassrctbl", "bindddlBseSrc", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddlBseCol(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            string OBJ_ID_BSE1 = (string)(Session["OBJ_ID_BSE"]);
            htParam.Add("@OBJ_ID_BSE", OBJ_ID_BSE1.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_BSE_TBL_COL", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "bindddlBseCol", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddlSrcCol(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            string OBJ_ID_SRC1 = (string)(Session["OBJ_ID_SRC"]);
            htParam.Add("@OBJ_ID_SRC", OBJ_ID_SRC1.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_SRC_TBL_COL", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            else
            {
                ddl.Items.Clear();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Map Column with table');", true);

            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "bindddlcoldattyp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    public void bindddlSrcCol(DropDownList ddl, string obj_id, string FLAG)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@flag", FLAG);
            htParam.Add("@OBJ_ID_SRC", obj_id.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_SRC_TBL_COL", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            else
            {
                ddl.Items.Clear();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Map Column with table');", true);

            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "bindddlcoldattyp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnClear1_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlBsetblCol.SelectedIndex = 0;
            //ddlSrctblCol.SelectedIndex = 0;


            bindddlBseCol(ddlBsetblCol);
            bindddlSrcCol(ddlSrctblCol);

            BindDdlStatus(MapddlStatus);
            MapddlStatus.SelectedIndex = 1;

            // txtSrctblNam.Text = "";
            //txtmapEffDtFrm.Text = "";
            txtmapceasedt.Text = "";
            ddlSrctblCol.Enabled = true;
            divbtnGrp1.Disabled = false;
            btnMapUpd.Attributes.Add("style", "display:none;");
            btnSave1.Attributes.Add("style", "display:inline-block;");
            btnClear1.Visible = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnClear1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            string KPI_MAP_CODE2 = (string)(Session["KPI_MAP_CODE"]);
            ht.Add("@KPI_MAP_CODE1", KPI_MAP_CODE2.ToString().Trim());
            if (ddlBsetblCol.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Base table Column');", true);
                return;

            }
            else
            {
                ht.Add("@BSE_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString());
            }
            if (ddlSrctblCol.SelectedItem.Text == "SELECT")
            {
                DataSet dsST = new DataSet();
                Hashtable htST = new Hashtable();
                htST.Add("@KPI_CD", Request.QueryString["kpicode"].ToString().Trim());
                htST.Add("@SrcTbl", txtSrctblNam.Text.ToString().Trim());
                htST.Add("@SRC_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString().Trim());
                htST.Add("@flag", "INS");

                dsST = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htST);

                if (dsST.Tables.Count > 0 && dsST.Tables[0].Rows.Count > 0)
                {
                    if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "1")
                    {
                        ddlSrctblCol.Enabled = false;
                    }
                    else if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
                    {
                        ddlSrctblCol.Enabled = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source table Column');", true);
                        return;
                    }
                }



               

            }
            else
            {
                ht.Add("@SRC_TBL_COL", ddlSrctblCol.SelectedValue.ToString().Trim());
            }

            if (MapddlStatus.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                return;

            }
            else
            {
                ht.Add("@Status", MapddlStatus.SelectedValue.ToString().Trim());
            }

            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());

            if (txtmapEffDtFrm.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Effective Date');", true);
                return;

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtmapEffDtFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtmapceasedt.Text.ToString() == "")
            {
                ht.Add("@CSE_DTIM", txtmapceasedt.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtmapceasedt.Text.Trim()).ToString("MM/dd/yyyy"));
            }




            ht.Add("@Flag", "I");

            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_COL_MAP_SU", ht);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ddlSrctblCol.Enabled = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully.');", true);


                }
               else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 2)
                {

                    txtmapEffDtFrm.Enabled = false;
                    txtmapceasedt.Enabled = false;
                    MapddlStatus.Enabled = false;
                    MapddlStatus.SelectedValue = "1";
                    ddlSrctblCol.Enabled = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already Exists.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }

            }


            //fillKPI_MAP_CODE();


            divbtnGrp1.Visible = true;
            divbtnGrp1.Disabled = false;

            btnClear1_Click(sender, e);

            Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //protected void lnkedit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        btnSave1.Text = "Update";
    //        DataSet ds = new DataSet();
    //        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
    //        HiddenField hdncolnam = (HiddenField)row.FindControl("hdncolnam");
    //        htParam.Clear();
    //        ds.Clear();
    //        htParam.Add("@COL_NME", hdncolnam.Value.ToString().Trim());
    //        ds = objDal.GetDataSetForPrc_SAIM("PRC_FILLCOLEDIT", htParam);
    //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {

    //            txtColName.Text = ds.Tables[0].Rows[0]["COL_NAM"].ToString();
    //            Session["ColName"]= ds.Tables[0].Rows[0]["COL_NAM"].ToString();

    //        }
    //        txtColName.Enabled = false;
    //        rdIsAvailable.Enabled = false;
    //        rdSingleCycle.Enabled = false;
    //        rdSingleCycle1.Enabled = false;
    //        rdIsforkey.Enabled = false;
    //        rdIsforkey1.Enabled = false;
    //        rdIsAvailable.Enabled = false;
    //        rdIsAvailable1.Enabled = false;
    //        rdIsPrimary.Enabled = false;
    //        rdIsPrimary1.Enabled = false;
    //        ddlstatus1.Enabled = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        objErr.LogErr("ISYS-SAIM", "Defbassrctbl", "lnkedit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}


    protected void Fillddl(DropDownList ddl, string LookupCode, string synNAME)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            ht.Add("@synmNAME", synNAME);
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetINTSTFillUPddlVal", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "paramdesc";
                ddl.DataValueField = "paramval";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("SELECT", ""));
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

    public string getCTRNotxt(string ctrid)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@counterId", ctrid);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetCTRNO", htparam);
            return dsfill.Tables[0].Rows.Count > 0 ? dsfill.Tables[0].Rows[0]["CTRNO"].ToString().Trim() : "";
        }
        catch (Exception ex)
        {
            return "";
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindDEFJOIN(string kpicode)
    {
        try
        {
            txtIntGid.Text = kpicode;
            txtJId.Text = getCTRNotxt("Join_Id");
            //TextBoxColJoinId.Text = txtJId.Text;
            //TextBoxColKpi.Text = kpicode;
            //  Fillddl(ddlSynm1, "synm", string.Empty);

            Bindddl(ddlSynm1, "MAP_S");
            Bindddl(ddlSynm2, "MAP_S");

            // Fillddl(ddlSynm2, "synm", string.Empty);
            Fillddl(ddlPrmJnt, "IPJ", string.Empty);
            Fillddl(ddlJoinType, "JTYP", string.Empty);
            Fillddl(ddlDJStatus, "STS", string.Empty);
            ddlDJStatus.SelectedValue = "1";
            bindgridDefJoin();
            bindGridDefCol();

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

    public void bindWhrCond()
    {
        try
        {
            GetWhrCondGrid(GridViewWhr);

            Bindddl(ddlST, "MAP_S");
            //  bindddlSrcCol(ddlCol,ddlST.SelectedValue);
            BindDdlOpratr(ddlOp);
            Fillddl(ddlSts, "STS", string.Empty);
            ddlSts.SelectedValue = "1";
            GetWhrCondGrid(GridViewWhr);
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



    protected void openDJoin_Click(object sender, EventArgs e)
    {
        ////try
        ////{
        ////    divDJoin.Visible = true;
        ////}
        ////catch (Exception ex)
        ////{
        ////    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        ////    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        ////    string sRet = oInfo.Name;
        ////    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        ////    String LogClassName = method.ReflectedType.Name;
        ////    objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        ////}
    }


    protected void btnDEFJOINSave_Click(object sender, EventArgs e)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();

            if (txtIntGid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {
                htparam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            }//txtIntGid

            if (txtJId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {
                htparam.Add("@JN_ID", txtJId.Text);
            }//txtIntGid

            if (ddlSynm1.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table 1');", true);
                return;


            }
            else
            {
                htparam.Add("@TABLE_1", ddlSynm1.SelectedValue);
            }
            if (ddlSynm2.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table 2');", true);
                return;


            }
            else
            {
                htparam.Add("@TABLE_2", ddlSynm2.SelectedValue);
            }

            if (ddlPrmJnt.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Is-Primary Join');", true);
                return;


            }
            else
            {
                htparam.Add("@IS_PRIMARY_JOIN", ddlPrmJnt.SelectedValue);
            }

            if (ddlJoinType.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Join Type');", true);
                return;


            }
            else
            {
                htparam.Add("@JN_TYP", ddlJoinType.SelectedValue);
            }





           
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());


            if (txtDJEffFrom.Text.ToString() == "")
            {
                htparam.Add("@EFF_DTIM", txtDJEffFrom.Text);

            }
            else
            {

                htparam.Add("@EFF_DTIM", Convert.ToDateTime(txtDJEffFrom.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtDJEffTo.Text.ToString() == "")
            {

                htparam.Add("@CSE_DTIM", txtDJEffTo.Text);

            }
            else
            {


                htparam.Add("@CSE_DTIM", Convert.ToDateTime(txtDJEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            htparam.Add("@STATUS", ddlDJStatus.SelectedValue);
            htparam.Add("@Flag", "I");
            dsfill = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_JOIN_DTLS", htparam);

            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                txtIntGid.Text = Request.QueryString["kpicode"].ToString().Trim();
            }
            if (Convert.ToInt32(dsfill.Tables[0].Rows[0]["Response"]) == 0)
            {

                bindgridDefJoin();
                htparam.Clear();
                dsfill.Clear();
                htparam.Add("@counterId", "Join_Id");
                dsfill = objDal.GetDataSetForPrc_SAIM("Prc_UPDCtrNO", htparam);
                // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Data added successfully.');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Added Successfully.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "confPromptBox2();", true);
                btnClr_Click(sender, e);
                ddlDJStatus.Enabled = false;
                txtDJEffTo.Enabled = false;
                txtDJEffFrom.Enabled = false;
                btnDEFJOINSave.Visible = true;
            }
            else if (Convert.ToInt32(dsfill.Tables[0].Rows[0]["Response"]) == 2)
            {

               
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Record Already Exists.');", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already Exists.');", true);
                //return;

            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Something went wrong.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong..');", true);
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


    public void bindDEFCOLFORJOIN(string synm1, string synm2, string joinID, string seqNo)
    {
        try
        {
            divDefColJoin.Attributes.Add("style", "display:block");
            ddlSValCol.Enabled = false;
            ddlDCFJSynmCol.Enabled = false;
            ddlDCFJSOpertr.Enabled = false;
            ddlDCFJColVal.Enabled = false;
            TextBoxColJoinId.Enabled = false;
            TextBoxColKpi.Enabled = false;
            //ddlSyn1Col.SelectedValue= synm1;
            //ddlSyn2Col.SelectedValue = synm2;

            DataSet dsDefCol = new DataSet();
            Hashtable htDefCol = new Hashtable();

            htDefCol.Clear();
            dsDefCol.Clear();
            htDefCol.Add("@SEQNO", seqNo);
            htDefCol.Add("@Flag", "Edit");
            dsDefCol = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_DTLS", htDefCol);
            if (dsDefCol.Tables.Count > 0)
            {
                if (dsDefCol.Tables[0].Rows.Count > 0)
                {

                    bindddlSrcCol(ddlSyn1Col, dsDefCol.Tables[0].Rows[0]["SRC_TABLE_1_Id"].ToString(), "MAP_COL");
                    //ddlSyn1Col.SelectedItem.Value = ds.Tables[0].Rows[0]["COL_NAME"].ToString();
                    //ddlSyn1Col.SelectedItem.Text = ds.Tables[0].Rows[0]["COL_DESC"].ToString();

                    bindddlSrcCol(ddlSyn2Col, dsDefCol.Tables[0].Rows[0]["SRC_TABLE_2_Id"].ToString(), "MAP_COL");
                    //ddlSyn2Col.SelectedItem.Value = ds.Tables[0].Rows[0]["COL_NAME"].ToString();
                    //ddlSyn2Col.SelectedItem.Text = ds.Tables[0].Rows[0]["COL_DESC"].ToString();


                    TextBoxColJoinId.Text = dsDefCol.Tables[0].Rows[0]["JN_ID"].ToString();

                    TextBoxColKpi.Text = Request.QueryString["kpicode"].ToString().Trim();

                    Session["OBJ_ID_SRC"] = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_2_Id"].ToString();

                    Session["OBJ_ID_BSE"] = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_1_Id"].ToString();
                    lblHdSql.Text = seqNo;
                }
            }
            divDefColJoin.Attributes.Add("style", "display:block");

            txtDCJoinEffFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            bindGridDefCol();

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>ToggleDiv('col')</script>", false);







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


    protected void lnkGRIDDefJOINEdit_Click(object sender, EventArgs e)
    {
        try
        {
            divDefColJoin.Visible = true;
            txtDCJoinEffFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDCJoinEffFrm.Enabled = false;
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblJN_ID = (Label)grd.FindControl("lblJN_ID");
            Label lblTABLE_1 = (Label)grd.FindControl("lblTABLE_1");
            Label lblTABLE_2 = (Label)grd.FindControl("lblTABLE_2");
            HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnDefSEQNO");
            Session["lblTABLE_1"] = lblTABLE_1.Text;
            Session["lblTABLE_2"] = lblTABLE_2.Text;
            Session["lblJN_ID"] = lblJN_ID.Text;
            Session["hdnSEQNO"] = hdnSEQNO.Value;
            bindDEFCOLFORJOIN(lblTABLE_1.Text, lblTABLE_2.Text, lblJN_ID.Text, hdnSEQNO.Value);

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

    protected void btnGrdDEFJOINPrev_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gridDefJoin.PageIndex;
            gridDefJoin.PageIndex = pageIndex - 1;
            bindgridDefJoin();
            TextBox3.Text = Convert.ToString(Convert.ToInt32(TextBox3.Text) - 1);
            if (TextBox3.Text == "1")
            {
                btnGrdDEFJOINPrev.Enabled = false;
            }
            else
            {
                btnGrdDEFJOINPrev.Enabled = true;
            }
            btnGrdDEFJOINNext.Enabled = true;
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

    protected void btnGrdDEFJOINNext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gridDefJoin.PageIndex;
            gridDefJoin.PageIndex = pageIndex + 1;
            bindgridDefJoin();
            TextBox3.Text = Convert.ToString(Convert.ToInt32(TextBox3.Text) + 1);
            btnGrdDEFJOINPrev.Enabled = true;
            if (TextBox3.Text == Convert.ToString(gridDefJoin.PageCount))
            {
                btnGrdDEFJOINNext.Enabled = false;
            }
            int page = gridDefJoin.PageCount;
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

    protected void lnkDefColJoinbtn_Click(object sender, EventArgs e)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@INTGRTN_ID", TextBoxColKpi.Text);
            htparam.Add("@JN_ID", TextBoxColJoinId.Text);
            htparam.Add("@SET_VAL_AS_CLMN", rdbSVACol.SelectedValue);
            htparam.Add("@TBL_1_COL", ddlSyn1Col.SelectedValue);
            htparam.Add("@TBL_2_COL", ddlSyn2Col.SelectedValue);
            //htparam.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);
            //htparam.Add("@CSE_DTIM", txtDCJoinEffTo.Text);




            if (txtDCJoinEffFrm.Text.ToString() == "")
            {
                htparam.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);

            }
            else
            {

                htparam.Add("@EFF_DTIM", Convert.ToDateTime(txtDCJoinEffFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtDCJoinEffTo.Text.ToString() == "")
            {

                htparam.Add("@CSE_DTIM", txtDCJoinEffTo.Text);

            }
            else
            {


                htparam.Add("@CSE_DTIM", Convert.ToDateTime(txtDCJoinEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            htparam.Add("@STATUS", ddlDCJoinStatus.SelectedValue);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_MST_KPI_INTGRTN_CLT_SRC_JOIN_COL_DTLS", htparam);
            if (Convert.ToInt32(dsfill.Tables[0].Rows[0]["Response"]) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data added successfully.');", true);
                //bindgridDefJoin();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong.');", true);
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

    protected void rdbSVACol_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdbSVACol.SelectedValue == "1")
            {
                ddlSValCol.Enabled = true;
                ddlDCFJSynmCol.Enabled = true;
                ddlDCFJSOpertr.Enabled = true;
                ddlDCFJColVal.Enabled = true;
            }
            else
            {
                ddlSValCol.Enabled = false;
                ddlDCFJSynmCol.Enabled = false;
                ddlDCFJSOpertr.Enabled = false;
                ddlDCFJColVal.Enabled = false;
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

    protected void btnGrdDEFWHERECondPrev_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridDefCol.PageIndex;
            GridDefCol.PageIndex = pageIndex - 1;
            bindGridDefCol();
            txtPageDEFWCond.Text = Convert.ToString(Convert.ToInt32(txtPageDEFWCond.Text) - 1);
            if (txtPageDEFWCond.Text == "1")
            {
                btnGrdDEFWHERECondPrev.Enabled = false;
            }
            else
            {
                btnGrdDEFWHERECondPrev.Enabled = true;
            }
            btnGrdDEFWHERECondNext.Enabled = true;
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

    protected void btnGrdDEFWHERECondNext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridDefCol.PageIndex;
            GridDefCol.PageIndex = pageIndex + 1;
            bindGridDefCol();
            txtPageDEFWCond.Text = Convert.ToString(Convert.ToInt32(txtPageDEFWCond.Text) + 1);
            btnGrdDEFWHERECondPrev.Enabled = true;
            if (TextBox3.Text == Convert.ToString(GridDefCol.PageCount))
            {
                btnGrdDEFWHERECondNext.Enabled = false;
            }
            int page = GridDefCol.PageCount;
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
    public void bindgridDefJoin()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_code", Request.QueryString["kpicode"].ToString().Trim());
            dsfill = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_DTLS", htparam);
            gridDefJoin.DataSource = dsfill;
            gridDefJoin.DataBind();
            if (dsfill.Tables.Count > 0)
            {
                if (dsfill.Tables[0].Rows.Count > 0)
                {

                    //gridDefJoin.DataSource = dsfill;
                    //gridDefJoin.DataBind();
                    ViewState["grid"] = dsfill.Tables[0];
                    if (gridDefJoin.PageCount > 1)
                    {
                        btnGrdDEFJOINNext.Enabled = true;
                    }
                    else
                    {
                        btnGrdDEFJOINNext.Enabled = false;
                    }
                }


                else
                {
                    DataTable dt = dsfill.Tables[0];
                    ShowNoResultFound(dt, gridDefJoin);
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

    protected void gridDefJoin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != "&nbsp;")
                {

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

    protected void gridDefJoin_Sorting(object sender, GridViewSortEventArgs e)
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
            if (dgSource.PageCount >= Convert.ToInt32(TextBox3.Text))
            {
                btnGrdDEFJOINPrev.Enabled = false;
                TextBox3.Text = "1";
                btnGrdDEFJOINNext.Enabled = true;
            }
            else
            {
                btnGrdDEFJOINNext.Enabled = false;
            }
            /////ShowPageInformation();
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

    protected void GridDefCol_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != "&nbsp;")
                {

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

    protected void GridDefCol_Sorting(object sender, GridViewSortEventArgs e)
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
            if (dgSource.PageCount >= Convert.ToInt32(txtPageDEFWCond.Text))
            {
                btnGrdDEFWHERECondPrev.Enabled = false;
                txtPageDEFWCond.Text = "1";
                btnGrdDEFWHERECondNext.Enabled = true;
            }
            else
            {
                btnGrdDEFWHERECondNext.Enabled = false;
            }
            /////ShowPageInformation();
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

    public void bindGridDefCol()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_code", Request.QueryString["kpicode"].ToString().Trim());
            dsfill = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_COL_DTLS", htparam);
            GridDefCol.DataSource = dsfill;
            GridDefCol.DataBind();
            if (dsfill.Tables.Count > 0)
            {
                if (dsfill.Tables[0].Rows.Count > 0)
                {

                    ViewState["grid"] = dsfill.Tables[0];
                    if (GridDefCol.PageCount > 1)
                    {
                        btnGrdDEFWHERECondNext.Enabled = true;
                    }
                    else
                    {
                        btnGrdDEFWHERECondNext.Enabled = false;
                    }
                }
                else
                {
                    DataTable dt = dsfill.Tables[0];
                    ShowNoResultFound(dt, GridDefCol);
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

    protected void openDWhereCond_Click(object sender, EventArgs e)
    {
        //DivWhr.visi
    }

    protected void ddlST_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindddlSrcCol(ddlCol, ddlST.SelectedValue, "MAP_COL");
    }
    public void BindDdlOpratr(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            // htParam.Add("@FLAG", Flag.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_BIND_DDL_OPRTR", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_OPRTR", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "BindddlBseTbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["kpicode"].ToString().Trim() != "")
        {
            kpicode = Request.QueryString["kpicode"].ToString().Trim();
        }

        bindDEFJOIN(kpicode);
        txtDJEffTo.Text = "";


    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        //ddlST.SelectedItem.Text = "SELECT";
        TextBoxColVal.Text = "";
        //   ddlCol.SelectedIndex = 0;
        ddlCol.SelectedItem.Text = "SELECT";
        ddlSts.SelectedItem.Text = "SELECT";
        //TxtWhrEffFrm.Enabled = true;
        TxtWhrCseDt.Text = "";
        //ddlOp.SelectedIndex = 0;
        //TxtWhrEffFrm.Enabled = true;
        //ddlST.Enabled = true;
        //ddlCol.Enabled = true;
        bindWhrCond();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();


            if (ddlST.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table Name');", true);
                return;


            }
            else
            {
                ht.Add("@SRC_TBL", ddlST.SelectedItem.Value.ToString().Trim());
            }
            if (ddlCol.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Column name');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_COL_NAME", ddlCol.SelectedItem.Value.ToString().Trim());
            }
            if (ddlOp.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Operator');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_OPRT", ddlOp.SelectedValue.ToString().Trim());
            }
            if (TextBoxColVal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Col Value');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_COL_VAL", TextBoxColVal.Text.ToString());
            }




            ht.Add("@status", ddlSts.SelectedValue.ToString().Trim());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());





            if (TxtWhrEffFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", TxtWhrEffFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(TxtWhrEffFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (TxtWhrCseDt.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", TxtWhrCseDt.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(TxtWhrCseDt.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            ht.Add("@Flag", "I");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_WHR_LOGIC_SU", ht);

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 0)
            {
                GetWhrCondGrid(GridViewWhr);
                LinkButton4_Click(sender, e);

                TxtWhrCseDt.Enabled = false;
                TxtWhrEffFrm.Enabled = false;
                ddlSts.Enabled = false;
                ddlSts.SelectedValue = "1";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Added Successfully.');", true);

            }
           else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 2)
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already Exists.');", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something Went Wrong.');", true);
            }



          
           



        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void GetWhrCondGrid(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_WHR_LOGIC_SU", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (GridViewWhr.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                        btnprevious.Enabled = false;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        btnprevious.Enabled = false;
                    }

                }
                else
                {
                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, dg);
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "GetSrcTblData", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void lnkGRIDWhrEdit_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lbl_GrST = (Label)grd.FindControl("lbl_GrST");
        Label lblGrColName = (Label)grd.FindControl("lblGrColName");
        Label lblGrOp = (Label)grd.FindControl("lblGrOp");
        Label lblGrColVal = (Label)grd.FindControl("lblGrColVal");
        Label lblSeqNo = (Label)grd.FindControl("lblSeqNo");//
        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnSEQNO");



        bindGRIDWhrEdit(lbl_GrST.Text, lblGrColName.Text, lblGrOp.Text, lblGrColVal.Text, hdnSEQNO.Value);

    }
    public void bindGRIDWhrEdit(string ST, string ColNm, string Op, string ColVal, string lblSeqNo)
    {
        try
        {
            DivWhr.Attributes.Add("style", "display:block");

            ddlOp.SelectedValue = Op;
            TextBoxColVal.Text = ColVal;
            //ddlST.Enabled = false;
            //ddlCol.Enabled = false;
            ddlST.SelectedItem.Text = ST;
            // bindddlSrcCol(ddlCol, ddlST.SelectedValue);
            // ddlCol.SelectedValue = ColNm;


            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@Flag", "Edit");
            htParam.Add("@SEQNO", lblSeqNo);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_WHR_LOGIC_SU", htParam);

            ddlST.SelectedItem.Value = ds.Tables[0].Rows[0]["SRC_TBL_NAME"].ToString();
            ddlST.SelectedItem.Text = ds.Tables[0].Rows[0]["SRC_TBL_NAME_desc"].ToString();

            //  ddlST.SelectedItem.Value= ds.Tables[0].Rows[0]["OBJ_ID"].ToString();
            bindddlSrcCol(ddlCol, ds.Tables[0].Rows[0]["OBJ_ID"].ToString(), "S");



            ddlCol.SelectedItem.Value = ds.Tables[0].Rows[0]["COL_NAME"].ToString();
            ddlCol.SelectedItem.Text = ds.Tables[0].Rows[0]["COL_DESC"].ToString();

            ddlSts.SelectedItem.Text = ds.Tables[0].Rows[0]["StatusDesc"].ToString();
            TxtWhrEffFrm.Text = ds.Tables[0].Rows[0]["EFF_DTIM"].ToString();
            TxtWhrCseDt.Text = ds.Tables[0].Rows[0]["CSE_DTIM"].ToString();
            TxtWhrEffFrm.Enabled = true;
            TxtWhrCseDt.Enabled = true;
            ddlSts.Enabled = true;

            lblHdSql.Text = lblSeqNo;

            lnkWhrUPD.Attributes.Add("style", "display:inline-block;");
            LinkButton1.Attributes.Add("style", "display:none;");
            LinkButton4.Visible = false;


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



    protected void lnkDefColJoinbtn_Click1(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();


            if (ddlSyn1Col.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Table 1 Column');", true);
                return;


            }
            else
            {
                ht.Add("@TABLE_1", ddlSyn1Col.SelectedValue.ToString().Trim());
            }
            if (ddlSyn2Col.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Table 2 Column');", true);
                return;


            }
            else
            {
                ht.Add("@TABLE_2", ddlSyn2Col.SelectedValue.ToString().Trim());
            }

            if (TextBoxColJoinId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Join Id');", true);
                return;


            }
            else
            {

                ht.Add("@JN_ID", TextBoxColJoinId.Text.ToString());
            }
            if (TextBoxColKpi.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {

                ht.Add("@KPI_CODE", TextBoxColKpi.Text.ToString());
            }
            ht.Add("@status", ddlDCJoinStatus.SelectedValue.ToString().Trim());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            //ht.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);
            //ht.Add("@CSE_DTIM", txtDCJoinEffTo.Text);




            if (txtDCJoinEffFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtDCJoinEffFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtDCJoinEffTo.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", txtDCJoinEffTo.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtDCJoinEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            ht.Add("@Flag", "I");
            ht.Add("@TBL_1_COL_CNVRT_TYP", hdnCol1DT.Value);

            ht.Add("@TBL_2_COL_CNVRT_TYP", hdnCol2DT.Value);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_JOIN_COL_DTLS", ht);

          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully!!');", true);

            LinkBtnColclr_Click(sender, e);

            bindGridDefCol();

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 0)
            {
               

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Added Successfully.');", true);

            }
            else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 2)
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already Exists.');", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something Went Wrong.');", true);
            }
            string lblTABLE_1 = (string)(Session["lblTABLE_1"]);
            string lblTABLE_2 = (string)(Session["lblTABLE_2"]);
            string lblJN_ID = (string)(Session["lblJN_ID"]);
            string hdnSEQNO = (string)(Session["hdnSEQNO"]);
            bindDEFCOLFORJOIN(lblTABLE_1.ToString().Trim(), lblTABLE_2.ToString().Trim(), lblJN_ID.ToString().Trim(), hdnSEQNO.ToString().Trim());

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }


    }





    protected void LinkBtnColclr_Click(object sender, EventArgs e)
    {


        //bindddlSrcCol(ddlSyn2Col);
        Fillddl(ddlDCJoinStatus, "STS", string.Empty);
        ddlDCJoinStatus.SelectedValue = "1";
        //TextBoxColJoinId.Text = "";
        //TextBoxColKpi.Text = "";
        //txtDCJoinEffFrm.Enabled = true;
        //txtDCJoinEffTo.Enabled = true;
        ddlSyn1Col.SelectedItem.Text = "SELECT";
        ddlSyn2Col.SelectedItem.Text = "SELECT";
        hdnCol1DT.Value = "";
        hdnCol2DT.Value = "";
        Col1MapDT.ToolTip = "";
        Col2MapDT.ToolTip = "";
        ddlDCJoinStatus.SelectedValue = "1";
        ddlDCJoinStatus.Enabled = false;
        txtDCJoinEffTo.Enabled = false;
        txtDCJoinEffFrm.Enabled = false;


    }

    protected void lnkDEFCOLJOINEdit_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnColSEQNO");

        DataSet ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "Edit");
        htParam.Add("@SEQNO", hdnSEQNO.Value);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_COL_DTLS", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlSyn1Col.SelectedItem.Text = ds.Tables[0].Rows[0]["TBL_1_COL_desc"].ToString();
            ddlSyn1Col.SelectedItem.Value = ds.Tables[0].Rows[0]["TBL_1_COL"].ToString();
            ddlSyn2Col.SelectedItem.Text = ds.Tables[0].Rows[0]["TBL_2_COL_desc"].ToString();
            ddlSyn2Col.SelectedItem.Value = ds.Tables[0].Rows[0]["TBL_2_COL"].ToString();
            ddlDCJoinStatus.SelectedItem.Text = ds.Tables[0].Rows[0]["StatusDesc"].ToString();
            txtDCJoinEffFrm.Text = ds.Tables[0].Rows[0]["EFF_DTIM"].ToString();
            txtDCJoinEffTo.Text = ds.Tables[0].Rows[0]["CSE_DTIM"].ToString();
            TextBoxColKpi.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString();
            TextBoxColJoinId.Text = ds.Tables[0].Rows[0]["JN_ID"].ToString();
            lblHdSql.Text = hdnSEQNO.Value;
            hdnCol1DT.Value = ds.Tables[0].Rows[0]["TBL_1_COL_CNVRT_TYP"].ToString();
            hdnCol2DT.Value = ds.Tables[0].Rows[0]["TBL_2_COL_CNVRT_TYP"].ToString();
            Col1MapDT.ToolTip = hdnCol1DT.Value;
            Col2MapDT.ToolTip = hdnCol2DT.Value;


        }
        txtDCJoinEffFrm.Enabled = true;
        ddlDCJoinStatus.Enabled = true;
        txtDCJoinEffTo.Enabled = true;
        lnkdefcolupd.Attributes.Add("style", "display:inline-block;");
        lnkDefColJoinbtn.Attributes.Add("style", "display:none;");
        LinkBtnColclr.Attributes.Add("style", "display:none;");

    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnColMapSeq");

        DataSet ds = new DataSet();
        string KPI_MAP_CODE1 = (string)(Session["KPI_MAP_CODE"]);
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "Edit");
        htParam.Add("@SEQNO", hdnSEQNO.Value);

        htParam.Add("@KPI_MAP_CODE", KPI_MAP_CODE1.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TO_SRC_TBL", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            txtSrctblNam.Text = ds.Tables[0].Rows[0]["SRC_TBL_ID"].ToString();
            ddlBsetblCol.SelectedItem.Value = ds.Tables[0].Rows[0]["BSE_TBL_COL_ID"].ToString();
            ddlBsetblCol.SelectedItem.Text = ds.Tables[0].Rows[0]["BSE_TBL_COL_DESC"].ToString();

            if (ds.Tables[0].Rows[0]["SCR_TBL_COL_ID"].ToString() != "")
            {
                ddlSrctblCol.SelectedItem.Value = ds.Tables[0].Rows[0]["SCR_TBL_COL_ID"].ToString();
                ddlSrctblCol.SelectedItem.Text = ds.Tables[0].Rows[0]["SCR_TBL_COL_DESC"].ToString();
            }
            else
            {
                ddlSrctblCol.Enabled = false;
            }
            MapddlStatus.SelectedItem.Text = ds.Tables[0].Rows[0]["StatusDescCOL"].ToString();

            txtmapEffDtFrm.Text = ds.Tables[0].Rows[0]["EFF_DTIM_COL"].ToString();
            txtmapceasedt.Text = ds.Tables[0].Rows[0]["CSE_DTIM_COL"].ToString();

            lblHdSql.Text = hdnSEQNO.Value;


        }
        txtmapEffDtFrm.Enabled = true;
        txtmapceasedt.Enabled = true;
        MapddlStatus.Enabled = true;

        btnMapUpd.Attributes.Add("style", "display:inline-block;");
        btnSave1.Attributes.Add("style", "display:none;");
        btnClear1.Visible = false;
    }



    protected void btnPrvWhr_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridViewWhr.PageIndex;
            GridViewWhr.PageIndex = pageIndex - 1;
            GetWhrCondGrid(GridViewWhr);
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
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnNctWhr_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridViewWhr.PageIndex;
            GridViewWhr.PageIndex = pageIndex + 1;
            GetWhrCondGrid(GridViewWhr);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(GridViewWhr.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgmapkpibsetbl.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        //Response.Redirect("KPISearch.aspx?flag=N", true);
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + Request.QueryString["KPICode"].ToString().Trim(), true);
    }



    protected void btnCancl_Click(object sender, EventArgs e)
    {
        //Response.Redirect("KPISearch.aspx?flag=N", true);
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + Request.QueryString["KPICode"].ToString().Trim(), true);
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //Response.Redirect("KPISearch.aspx?flag=N", true);
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + Request.QueryString["KPICode"].ToString().Trim(), true);
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        //Response.Redirect("KPISearch.aspx?flag=N", true);
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + Request.QueryString["KPICode"].ToString().Trim(), true);
    }

    protected void btnCnCl1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("KPISearch.aspx?flag=N", true);
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + Request.QueryString["KPICode"].ToString().Trim(), true);
    }


    protected void Col1MapDT_Click(object sender, EventArgs e)
    {
        HdnColVal.Value = ddlSyn1Col.SelectedValue;

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>OpenPopupColData('COL1DT','" + HdnColVal.Value.ToString() + "')</script>", false);

    }

    protected void Col2MapDT_Click(object sender, EventArgs e)
    {


        HdnColVal.Value = ddlSyn2Col.SelectedValue;

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>OpenPopupColData('COL2DT','" + HdnColVal.Value.ToString() + "')</script>", false);
    }



    protected void BtnToolTip_Click(object sender, EventArgs e)
    {

        Col1MapDT.ToolTip = hdnMapDataType1.Value;
        hdnCol1DT.Value = hdnMapDataType1.Value;
        divDefColJoin.Visible = true;

       // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Selected value is');", true);
    }

    protected void BtnToolTip2_Click(object sender, EventArgs e)
    {
        Col2MapDT.ToolTip = hdnMapDataType2.Value;
        hdnCol2DT.Value = hdnMapDataType2.Value;
        divDefColJoin.Visible = true;

    }


    protected void lnkMapEdit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnKpiCode = (HiddenField)row.FindControl("hdnKpiCode");
            HiddenField HdnMapSeqNo = (HiddenField)row.FindControl("HdnMapSeqNo");
            htParam.Clear();
            ds.Clear();
            htParam.Add("@KPI_CODE", hdnKpiCode.Value.ToString().Trim());
            htParam.Add("@SEQ_NO", HdnMapSeqNo.Value.ToString().Trim());
            htParam.Add("@FLAG", "EDIT");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TBL", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtkpiBseSrcMapCode.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString();
                txtkpicoddesc.Text = ds.Tables[0].Rows[0]["KPI_CODE_DESC"].ToString();
                txtEffDtFrm.Text = ds.Tables[0].Rows[0]["EFF_DTIM"].ToString();
                txtceasedt.Text = ds.Tables[0].Rows[0]["CSE_DTIM"].ToString();
                ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();

                ddlbsetbl.SelectedItem.Value = ds.Tables[0].Rows[0]["BASE_OBJ_ID"].ToString();
                ddlbsetbl.SelectedItem.Text = ds.Tables[0].Rows[0]["TBL_DESC"].ToString();

                ddlSrctbl.SelectedItem.Value = ds.Tables[0].Rows[0]["src_OBJ_ID"].ToString();
                ddlSrctbl.SelectedItem.Text = ds.Tables[0].Rows[0]["Src_TBL_DESC"].ToString();


            }
            txtEffDtFrm.Enabled = true;
            txtceasedt.Enabled = true;
            ddlStatus.Enabled = true;
            lblHdSql.Text = HdnMapSeqNo.Value;
            btnUpd.Attributes.Add("style", "display:inline-block;");
            btnSave.Attributes.Add("style", "display:none;");

            btnClear.Attributes.Add("style", "display:none;");
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "lnkMapEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkMapDel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnKpiCode = (HiddenField)row.FindControl("hdnKpiCode");
            HiddenField HdnMapSeqNo = (HiddenField)row.FindControl("HdnMapSeqNo");
            htParam.Clear();
            ds.Clear();
            htParam.Add("@KPI_CODE", hdnKpiCode.Value.ToString().Trim());
            htParam.Add("@SEQ_NO", HdnMapSeqNo.Value.ToString().Trim());
            htParam.Add("@FLAG", "DELETE");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TBL", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Deleted Successfully.');", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }

            }
            txtEffDtFrm.Enabled = false;
            txtceasedt.Enabled = false;
            ddlStatus.Enabled = false;

            btnClear_Click(sender, e);

            txtEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Getmapkpibstbl(dgmapkpibsetbl);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "lnkMapDel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void lnkGridJoinEdit_Click(object sender, EventArgs e)
    {


        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnDefSEQNO = (HiddenField)grd.FindControl("hdnDefSEQNO");

        DataSet dsDefCol = new DataSet();
        Hashtable htDefCol = new Hashtable();
        htDefCol.Clear();
        dsDefCol.Clear();
        htDefCol.Add("@SEQNO", hdnDefSEQNO.Value);
        htDefCol.Add("@Flag", "Edit");
        htparam.Add("@KPI_code", Request.QueryString["kpicode"].ToString().Trim());
        dsDefCol = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_DTLS", htDefCol);
        if (dsDefCol.Tables.Count > 0)
        {
            txtIntGid.Text = dsDefCol.Tables[0].Rows[0]["KPI_CODE"].ToString();
            txtJId.Text = dsDefCol.Tables[0].Rows[0]["JN_ID"].ToString();

            ddlSynm1.SelectedItem.Value = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_1_ID"].ToString();
            ddlSynm1.SelectedItem.Text = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_1"].ToString();

            ddlSynm2.SelectedItem.Value = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_2_ID"].ToString();
            ddlSynm2.SelectedItem.Text = dsDefCol.Tables[0].Rows[0]["SRC_TABLE_2"].ToString();

            ddlPrmJnt.SelectedItem.Value = dsDefCol.Tables[0].Rows[0]["IS_PRIMARY_JOIN"].ToString();
            ddlPrmJnt.SelectedItem.Text = dsDefCol.Tables[0].Rows[0]["IS_PRIMARY_JOIN_DESC"].ToString();
            ddlJoinType.SelectedItem.Value = dsDefCol.Tables[0].Rows[0]["JN_TYP"].ToString();

            ddlJoinType.SelectedItem.Text = dsDefCol.Tables[0].Rows[0]["JN_TYP_DESC"].ToString();
            ddlDJStatus.SelectedItem.Value = dsDefCol.Tables[0].Rows[0]["status"].ToString();


            txtDJEffFrom.Text = dsDefCol.Tables[0].Rows[0]["EFF_DTIM"].ToString();

            txtDJEffTo.Text = dsDefCol.Tables[0].Rows[0]["CSE_DTIM"].ToString();

        }
        txtDJEffFrom.Enabled = true;
        txtDJEffTo.Enabled = true;
        ddlDJStatus.Enabled = true;
        lblHdSql.Text = hdnDefSEQNO.Value;
        btnClr.Visible = false;
        btnDEFJOINSave.Visible = false;
        lnkbtnDEFJOINUpd.Visible = true;

        lnkbtnDEFJOINUpd.Attributes.Add("style", "display:inline-block;");
        btnDEFJOINSave.Attributes.Add("style", "display:none;");


    }

    protected void lnkGridDefJoinDel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField hdnDefSEQNO = (HiddenField)row.FindControl("hdnDefSEQNO");
            htParam.Clear();
            ds.Clear();
            htparam.Add("@KPI_code", Request.QueryString["kpicode"].ToString().Trim());
            htParam.Add("@SEQNO", hdnDefSEQNO.Value.ToString().Trim());
            htParam.Add("@FLAG", "DELETE");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_DTLS", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Deleted Successfully.');", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the record as column is defined for join');", true);
                }

            }


            ddlDJStatus.Enabled = false;
            txtDJEffTo.Enabled = false;
            txtDJEffFrom.Enabled = false;

            btnClr_Click(sender, e);

            txtDJEffFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            bindgridDefJoin();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "lnkMapDel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }

    protected void lnkDEFCOLJOINDel_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnColSEQNO");

        DataSet ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "DELETE");
        htParam.Add("@SEQNO", hdnSEQNO.Value);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_JOIN_COL_DTLS", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Deleted Successfully.');", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
            }

        }

        bindGridDefCol();

    }
    protected void lnkGRIDWhrDel_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnSEQNO");

        DataSet ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "DELETE");
        htParam.Add("@SEQNO", hdnSEQNO.Value);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_BSE_SRC_WHR_LOGIC_SU", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")

            {
                GetWhrCondGrid(GridViewWhr);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Deleted Successfully.');", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
            }

        }

   
    }

    protected void lnkMapColDel_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnSEQNO = (HiddenField)grd.FindControl("hdnColMapSeq");

        DataSet ds = new DataSet();
        string KPI_MAP_CODE1 = (string)(Session["KPI_MAP_CODE"]);
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "Edit");
        htParam.Add("@SEQNO", hdnSEQNO.Value);

        htParam.Add("@KPI_MAP_CODE", KPI_MAP_CODE1.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TO_SRC_TBL", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Session["BSE_TBL_COL_ID"] = ds.Tables[0].Rows[0]["BSE_TBL_COL_ID"].ToString();
        }

        DataSet dsST = new DataSet();
        Hashtable htST = new Hashtable();
        string BSE_TBL_COL_ID = (string)(Session["BSE_TBL_COL_ID"]);
        htST.Add("@KPI_CD", Request.QueryString["kpicode"].ToString().Trim());
        htST.Add("@SrcTbl", txtSrctblNam.Text.ToString().Trim());
        htST.Add("@SRC_TBL_COL", BSE_TBL_COL_ID.ToString().Trim());
        htST.Add("@flag", "INS");

        dsST = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htST);

        if (dsST.Tables.Count > 0 && dsST.Tables[0].Rows.Count > 0)
        {
            if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete this record as parameter exists for this record.');", true);
                return;
            }
            else if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
            {
                ds.Clear();
                htParam.Clear();
                htParam.Add("@Flag", "DELETE");
                htParam.Add("@SEQNO", hdnSEQNO.Value);

                htParam.Add("@KPI_MAP_CODE", KPI_MAP_CODE1.ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAP_KPI_BSE_TO_SRC_TBL", htParam);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Deleted Successfully.');", true);


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                    }

                }

                Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);
                btnClear1_Click(sender, e);

            }
        }

    }

    protected void lnkbtnDEFJOINUpd_Click(object sender, EventArgs e)
    {


        try
        {
            //  btnDEFJOINSave.Visible = false;
            htparam.Clear();
            dsfill.Clear();
            btnClr.Visible = false;

            if (txtIntGid.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {
                htparam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            }//txtIntGid

            if (txtJId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {
                htparam.Add("@JN_ID", txtJId.Text);
            }//txtIntGid

            if (ddlSynm1.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table 1');", true);
                return;


            }
            else
            {
                htparam.Add("@TABLE_1", ddlSynm1.SelectedValue);
            }
            if (ddlSynm2.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table 2');", true);
                return;


            }
            else
            {
                htparam.Add("@TABLE_2", ddlSynm2.SelectedValue);
            }




            if (ddlPrmJnt.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Is-Primary Join');", true);
                return;


            }
            else
            {
                htparam.Add("@IS_PRIMARY_JOIN", ddlPrmJnt.SelectedValue);
            }

            if (ddlJoinType.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Join Type');", true);
                return;


            }
            else
            {
                htparam.Add("@JN_TYP", ddlJoinType.SelectedValue);
            }
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());


            if (txtDJEffFrom.Text.ToString() == "")
            {
                htparam.Add("@EFF_DTIM", txtDJEffFrom.Text);

            }
            else
            {

                htparam.Add("@EFF_DTIM", Convert.ToDateTime(txtDJEffFrom.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtDJEffTo.Text.ToString() == "")
            {

                htparam.Add("@CSE_DTIM", txtDJEffTo.Text);

            }
            else
            {


                htparam.Add("@CSE_DTIM", Convert.ToDateTime(txtDJEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            htparam.Add("@STATUS", ddlDJStatus.SelectedValue);
            htparam.Add("@SEQ_NO", lblHdSql.Text);
            htparam.Add("@Flag", "U");
            dsfill = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_JOIN_DTLS", htparam);
            if (Convert.ToInt32(dsfill.Tables[0].Rows[0]["Response"]) == 0)
            {

                bindgridDefJoin();
                htparam.Clear();
                dsfill.Clear();
                htparam.Add("@counterId", "Join_Id");
                dsfill = objDal.GetDataSetForPrc_SAIM("Prc_UPDCtrNO", htparam);
              
                btnClr_Click(sender, e);
                ddlDJStatus.Enabled = false;
                ddlDJStatus.SelectedValue = "1";
                txtDJEffTo.Enabled = false;
                txtDJEffFrom.Enabled = false;
                btnDEFJOINSave.Visible = true;
                lnkbtnDEFJOINUpd.Visible = false;
                btnClr.Visible = true;

                lnkbtnDEFJOINUpd.Attributes.Add("style", "display:none;");
                btnDEFJOINSave.Attributes.Add("style", "display:inline-block;");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated successfully.');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong.');", true);
            }

            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                txtIntGid.Text = Request.QueryString["kpicode"].ToString().Trim();
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

    protected void lnkWhrUPD_Click(object sender, EventArgs e)
    {

        try
        {
            LinkButton1.Attributes.Add("style", "display:inline-block;");
            lnkWhrUPD.Attributes.Add("style", "display:none;");
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();


            if (ddlST.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source Table Name');", true);
                return;


            }
            else
            {
                ht.Add("@SRC_TBL", ddlST.SelectedItem.Value.ToString().Trim());
            }
            if (ddlCol.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Column name');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_COL_NAME", ddlCol.SelectedItem.Value.ToString().Trim());
            }
            if (ddlOp.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Operator');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_OPRT", ddlOp.SelectedValue.ToString().Trim());
            }
            if (TextBoxColVal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Col Value');", true);
                return;


            }
            else
            {
                ht.Add("@WHR_CNDTN_COL_VAL", TextBoxColVal.Text.ToString());
            }




            ht.Add("@status", ddlSts.SelectedValue.ToString().Trim());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());





            if (TxtWhrEffFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", TxtWhrEffFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(TxtWhrEffFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (TxtWhrCseDt.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", TxtWhrCseDt.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(TxtWhrCseDt.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            ht.Add("@SEQNO", lblHdSql.Text);
            ht.Add("@Flag", "U");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_WHR_LOGIC_SU", ht);


            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 0)
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated Successfully.');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something Went Wrong.');", true);
            }
            
            GetWhrCondGrid(GridViewWhr);
            LinkButton4_Click(sender, e);
            TxtWhrCseDt.Enabled = false;
            TxtWhrEffFrm.Enabled = false;
            ddlSts.Enabled = false;
            ddlSts.SelectedValue = "1";
            LinkButton4.Visible = true;
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

    protected void btnMapUpd_Click(object sender, EventArgs e)
    {
        try
        {
            //btnSave1.Attributes.Add("style", "display:inline-block;");
            //btnMapUpd.Attributes.Add("style", "display:none;");
            //btnClear1.Visible = true;

              DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            string KPI_MAP_CODE2 = (string)(Session["KPI_MAP_CODE"]);
            ht.Add("@KPI_MAP_CODE1", KPI_MAP_CODE2.ToString().Trim());
            if (ddlBsetblCol.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Base table Column');", true);
                return;

            }
            else
            {
                ht.Add("@BSE_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString());
            }
            //if (ddlSrctblCol.SelectedItem.Text == "SELECT")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source table Column');", true);
            //    return;

            //}
            //else
            //{
            //    ht.Add("@SRC_TBL_COL", ddlSrctblCol.SelectedValue.ToString().Trim());
            //}
            if (ddlSrctblCol.SelectedItem.Text == "SELECT")
            {
                DataSet dsST = new DataSet();
                Hashtable htST = new Hashtable();
                htST.Add("@KPI_CD", Request.QueryString["kpicode"].ToString().Trim());
                htST.Add("@SrcTbl", txtSrctblNam.Text.ToString().Trim());
                htST.Add("@SRC_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString().Trim());
                htST.Add("@flag", "INS");

                dsST = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htST);

                if (dsST.Tables.Count > 0 && dsST.Tables[0].Rows.Count > 0)
                {
                    if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "1")
                    {
                        ddlSrctblCol.Enabled = false;
                    }
                    else if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
                    {
                        ddlSrctblCol.Enabled = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source table Column');", true);
                        return;
                    }
                }





            }
            else
            {
                ht.Add("@SRC_TBL_COL", ddlSrctblCol.SelectedValue.ToString().Trim());
            }

            if (MapddlStatus.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                return;

            }
            else
            {
                ht.Add("@Status", MapddlStatus.SelectedValue.ToString().Trim());
            }

            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());

            if (txtmapEffDtFrm.Text.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Effective Date');", true);
                return;

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtmapEffDtFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtmapceasedt.Text.ToString() == "")
            {
                ht.Add("@CSE_DTIM", txtmapceasedt.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtmapceasedt.Text.Trim()).ToString("MM/dd/yyyy"));
            }




            ht.Add("@SEQ_NO", lblHdSql.Text);
            ht.Add("@Flag", "U");

            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_COL_MAP_SU", ht);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {

                    txtmapEffDtFrm.Enabled = false;
                    txtmapceasedt.Enabled = false;
                    MapddlStatus.Enabled = false;
                    MapddlStatus.SelectedValue = "1";
                    btnSave1.Attributes.Add("style", "display:inline-block;");
                    btnMapUpd.Attributes.Add("style", "display:none;");
                    btnClear1.Visible = true;
                    ddlBsetblCol.ClearSelection();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated Successfully.');", true);


                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Already exists');", true);

                    return;
                }

            }


            //fillKPI_MAP_CODE();




            btnClear1_Click(sender, e);

            Getmapbsetbltosrctbl(dgmapbsetbltosrctbl);

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void btnUpd_Click(object sender, EventArgs e)
    {

        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            if (ddlbsetbl.SelectedItem.Text.ToString() == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Base table name');", true);
                return;


            }
            else
            {
                ht.Add("@BSE_TBL", ddlbsetbl.SelectedValue.ToString().Trim());
            }

            if (ddlSrctbl.SelectedItem.Text.ToString() == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Source table name');", true);
                return;


            }
            else
            {
                ht.Add("@SRC_TBL", ddlSrctbl.SelectedValue.ToString().Trim());
            }


            if (ddlStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                return;

            }
            else if (ddlStatus.SelectedValue.ToString() == "0" && txtceasedt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Cease Date');", true);
                return;

            }
            else
            {
                ht.Add("@status", ddlStatus.SelectedValue.ToString().Trim());
            }

            ht.Add("@KPI_BSE_SRC_MAP_CODE", txtkpiBseSrcMapCode.Text.ToString());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());

            if (txtEffDtFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", txtEffDtFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtEffDtFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtceasedt.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", txtceasedt.Text);

            }
            else
            {


                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtceasedt.Text.Trim()).ToString("MM/dd/yyyy"));
            }

            ht.Add("@SEQ_NO", lblHdSql.Text);
            ht.Add("@Flag", "U");


            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_MAP_SU", ht);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ///ScriptManager.RegisterStartupScript(this, this.GetType(), popup, "alert('Data Deleted Successfully.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated Successfully.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }

            }







            Getmapkpibstbl(dgmapkpibsetbl);

            btnClear_Click(sender, e);



            if (Request.QueryString["kpicode"].ToString().Trim() != "")
            {
                kpicode = Request.QueryString["kpicode"].ToString().Trim();
            }
            bindDEFJOIN(kpicode);

            fillKPI_MAP_CODE();
            btnUpd.Attributes.Add("style", "display:none;");
            btnSave.Attributes.Add("style", "display:inline-block;");

            btnClear.Attributes.Add("style", "display:inline-block;");
            

            //  Response.Redirect(Page.Request.Url.AbsoluteUri);

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void lnkdefcolupd_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();


            if (ddlSyn1Col.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Table 1 Column');", true);
                return;


            }
            else
            {
                ht.Add("@TABLE_1", ddlSyn1Col.SelectedValue.ToString().Trim());
            }
            if (ddlSyn2Col.SelectedItem.Text == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Table 2 Column');", true);
                return;


            }
            else
            {
                ht.Add("@TABLE_2", ddlSyn2Col.SelectedValue.ToString().Trim());
            }

            if (TextBoxColJoinId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Join Id');", true);
                return;


            }
            else
            {

                ht.Add("@JN_ID", TextBoxColJoinId.Text.ToString());
            }
            if (TextBoxColKpi.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI');", true);
                return;


            }
            else
            {

                ht.Add("@KPI_CODE", TextBoxColKpi.Text.ToString());
            }
            ht.Add("@status", ddlDCJoinStatus.SelectedValue.ToString().Trim());
            ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            //ht.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);
            //ht.Add("@CSE_DTIM", txtDCJoinEffTo.Text);




            if (txtDCJoinEffFrm.Text.ToString() == "")
            {
                ht.Add("@EFF_DTIM", txtDCJoinEffFrm.Text);

            }
            else
            {

                ht.Add("@EFF_DTIM", Convert.ToDateTime(txtDCJoinEffFrm.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            if (txtDCJoinEffTo.Text.ToString() == "")
            {

                ht.Add("@CSE_DTIM", txtDCJoinEffTo.Text);

            }
            else
            {

                ht.Add("@CSE_DTIM", Convert.ToDateTime(txtDCJoinEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }


            ht.Add("@SEQ_NO", lblHdSql.Text);
            ht.Add("@TBL_1_COL_CNVRT_TYP", hdnCol1DT.Value);

            ht.Add("@TBL_2_COL_CNVRT_TYP", hdnCol2DT.Value);
            ht.Add("@Flag", "U");

            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_BSE_SRC_JOIN_COL_DTLS", ht);

          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully!!');", true);

            LinkBtnColclr_Click(sender, e);

            bindGridDefCol();

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 0)
            {
               

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated Successfully.');", true);

            }
            else if (Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]) == 2)
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already Exists.');", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something Went Wrong.');", true);
            }

            lnkdefcolupd.Attributes.Add("style", "display:none;");
            lnkDefColJoinbtn.Attributes.Add("style", "display:inline-block;");
            LinkBtnColclr.Attributes.Add("style", "display:inline-block;");

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrc", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void ddlSrctblCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSrctblCol.SelectedItem.Value == "")
        {
            
            //divbtnGrp1.Visible = true;
            //divbtnGrp1.Attributes.Add("style", "display:block");


            divbtnGrp1.Disabled = false;
        }
        else
        {
            divbtnGrp1.Disabled = true;


            //divbtnGrp1.Attributes.Add("style", "display:none");
            //divbtnGrp1.Visible = false;
            
           
        }
    }

    protected void ddlBsetblCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        divbtnGrp1.Visible = true;
        divbtnGrp1.Disabled = false;

        DataSet dsST = new DataSet();
        Hashtable htST = new Hashtable();
        htST.Add("@KPI_CD", Request.QueryString["kpicode"].ToString().Trim());
        htST.Add("@SrcTbl", txtSrctblNam.Text.ToString().Trim());
        htST.Add("@SRC_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString().Trim());
        htST.Add("@flag", "INS");

        dsST = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htST);

        if (dsST.Tables.Count > 0 && dsST.Tables[0].Rows.Count > 0)
        {
            if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "1")
            {
                ddlSrctblCol.Enabled = false;
            }
            else if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
            {
                ddlSrctblCol.Enabled = true;
             
            }
        }



        string OBJ_ID_SRC1 = (string)(Session["OBJ_ID_SRC"]);
      
        ddlSrctblCol.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@flag", "MapColType");
        ht.Add("@OBJ_ID_SRC", OBJ_ID_SRC1.ToString().Trim());
        ht.Add("@OpTypeVal", ddlBsetblCol.SelectedValue.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("PRC_BIND_DDL_SRC_TBL_COL_OpType", ht);
        if (drRead.HasRows)
        {
            ddlSrctblCol.DataSource = drRead;
            ddlSrctblCol.DataTextField = "COL_DESC";
            ddlSrctblCol.DataValueField = "COL_NAM";
            ddlSrctblCol.DataBind();
          
        }
          ddlSrctblCol.Items.Insert(0, new ListItem("SELECT", ""));
    }

    protected void BtnGrp_Click(object sender, EventArgs e)
    {
        DataSet dsST = new DataSet();
        Hashtable htST = new Hashtable();
        htST.Add("@KPI_CD", Request.QueryString["kpicode"].ToString().Trim());
        htST.Add("@SrcTbl", txtSrctblNam.Text.ToString().Trim());
        htST.Add("@SRC_TBL_COL", ddlBsetblCol.SelectedItem.Value.ToString().Trim());
        htST.Add("@flag", "INS");

        dsST = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htST);

        if (dsST.Tables.Count > 0 && dsST.Tables[0].Rows.Count > 0)
        {
            if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "1")
            {
                ddlSrctblCol.Enabled = false;
            }
            else if (dsST.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
            {
                ddlSrctblCol.Enabled = true;
            }
        }
    }
}
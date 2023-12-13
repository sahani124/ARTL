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
using System.Web.UI.DataVisualization.Charting;

public partial class Application_ISys_Saim_CmpSetupReport : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strCompCode = null;
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            BindChart();
            if (Request.QueryString["CmpCode"] != null)
            {
                strCompCode = Request.QueryString["CmpCode"].ToString().Trim();
            }
            //kalyani start
            if (Session["Mode"].ToString() == "C")
            {
                //divC.Visible = true;
                //divR.Visible = false;
            }
            else if (Session["Mode"].ToString() == "R")
            {
                //divR.Visible = true;
                //divC.Visible = false;
                //FillDropDowns(ddlStatusR);
                //BindStatus();
            }

            //BindAuditGrid(strCompCode);
            //kalyani end

            //FillDropDowns(ddlAccCyc, "8", "");
            //FillDropDowns(ddlAccYear, "9", "");
            //FillDropDowns(ddlCompType, "10", "");
            //FillDropDowns(ddlStatus, "11", "");

            //FillDropDowns(ddlAccrCyc, "8", "");
            //FillDropDowns(ddlRwdRlsCyc, "8", "");


            //ddlAccCyc.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlAccYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlCompType.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlStatus.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlBusiYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlAccrCyc.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlRwdRlsCyc.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlStatus.Items.Insert(0, new ListItem("-- SELECT --", ""));
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "N")
                {
                    ////txtEffDtFrm.Text = "01/04/2014";
                    ////txtEffDtTo.Text = "31/03/2015";
                    ////txtFinYr.Text = "2014-2015";
                    ////txtVerEffFrm.Text = "01/04/2014";
                    ////txtVerEffTo.Text = "31/03/2015";
                    /////ddlStatus.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    ///ddlStatus.SelectedIndex = 1;
                    txtVer.Text = "1.00";
                    //FillDropDowns(ddlStatus, "12", "");
                    //ddlStatus.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    //ddlStatus.Enabled = false;
                    GetMaxCmpCode();
                }
                else if (Request.QueryString["flag"].ToString().Trim() == "E")
                {
                    FillCmpDetails();
                }
            }
            if (Request.QueryString["CmpCode"] != null)
            {
                BindCnstGrid(Request.QueryString["CmpCode"].ToString().Trim());
            }
            else
            {
                BindCnstGrid("");
            }
        }

        btnAddCntst.Attributes.Add("onclick", "funPopUp('" + txtCompCode.Text.ToString().Trim() + "','" + txtCompDesc1.Text.ToString().Trim() + "');return false;");
    }

    private void BindChart()
    {

        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetChartVals", htParam);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string[] x = new string[ds.Tables[0].Rows.Count];
                decimal[] y1 = new decimal[ds.Tables[0].Rows.Count];
                decimal[] y2 = new decimal[ds.Tables[0].Rows.Count];
                decimal[] y3 = new decimal[ds.Tables[0].Rows.Count];


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x[i] = ds.Tables[0].Rows[i]["AccuCycle"].ToString();
                    y1[i] = Convert.ToDecimal(ds.Tables[0].Rows[i]["WRP"]);
                    y2[i] = Convert.ToDecimal(ds.Tables[0].Rows[i]["Agents"]);
                    y3[i] = Convert.ToDecimal(ds.Tables[0].Rows[i]["Cost"]);
                }
                Chart1.Series[0].Points.DataBindXY(x, y1);
                Chart1.Series[0].ChartType = SeriesChartType.Line;
                Chart1.Series[0].LegendText = "WRP ('0000)";
                Chart1.Series[0].BorderWidth = 3;


                Chart1.Series[1].Points.DataBindXY(x, y2);
                Chart1.Series[1].ChartType = SeriesChartType.Line;
                Chart1.Series[1].LegendText = "# Agents";
                Chart1.Series[1].BorderWidth = 3;

                Chart1.Series[2].Points.DataBindXY(x, y3);
                Chart1.Series[2].ChartType = SeriesChartType.Line;
                Chart1.Series[2].LegendText = "Cost ('0000)";
                Chart1.Series[2].BorderWidth = 3;

                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //CmpCreate();
        mdlpopup.Show();
        lbl3.Text = "Compensation Code Saved Successfully";
        lbl4.Text = "Compensation Code:" + txtCompCode.Text.ToString().Trim();
        lbl5.Text = "Compensation Description:" + txtCompDesc1.Text.ToString().Trim();
        btnSave.Enabled = false;
        /////btnAddCntst.Enabled = true;
    }
    protected void btnCnclCmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompStpSrch.aspx");
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

    protected void FillCmpDetails()
    {
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCompCode.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
            txtCompDesc1.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
            txtCompDesc2.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
            ddlAccCyc.Text = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString().Trim();
            ddlAccYear.Text = ds.Tables[0].Rows[0]["ACC_YEAR"].ToString().Trim();
            //FillDropDowns(ddlBusiYear, "15", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()));
            //ddlBusiYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlCompType.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString().Trim();
            ddlStatus.Text = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
            txtEffDtFrm.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
            txtEffDtTo.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
            ddlBusiYear.Text = ds.Tables[0].Rows[0]["BUSI_DESC"].ToString().Trim();
            txtVer.Text = ds.Tables[0].Rows[0]["VERSION"].ToString().Trim();
            txtVerEffFrm.Text = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
            txtVerEffTo.Text = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();
            if (ds.Tables[0].Rows[0]["SET_TRG_RULE"].ToString().Trim() == "1001")
            {
                rblSetTrgRul.Text = "Set full period target and split by cycle";    
            }
            else
            {
                rblSetTrgRul.Text = "Set target by cycle";    
            }
            ddlAccrCyc.Text = ds.Tables[0].Rows[0]["ACCURAL_CYCLE_DESC"].ToString().Trim();
            ddlRwdRlsCyc.Text = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE_DESC"].ToString().Trim();
        }
    }

    

    protected void GetMaxCmpCode()
    {
        ds.Clear();
        htParam.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCompCode", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCompCode.Text = ds.Tables[0].Rows[0]["MaxCmpCode"].ToString().Trim();
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lnkCnstCode = (Label)row.FindControl("lnkCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CntstCode", lnkCnstCode.Text.ToString().Trim());
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCntstDtls", htParam);
        ds.Clear();
        htParam.Clear();
        DataTable dt = (DataTable)Session["grid"];
        dt.Rows[rowIndex].Delete();
        dt.AcceptChanges();
        if (dt.Rows.Count > 0)
        {
            dgCntst.DataSource = dt;
            dgCntst.DataBind();
        }
        else
        {
            ShowNoResultFound(dt, dgCntst);
        }
    }
    protected void BindCnstGrid(string cmpcode)
    {
        ds.Clear();
        htParam.Clear();
        if (cmpcode != "")
        {
            htParam.Add("@CmpCode", cmpcode.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgCntst.DataSource = ds;
                dgCntst.DataBind();
                if (dgCntst.PageCount > 1)
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
                htParam.Clear();
                ds = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
                ShowNoResultFound(ds.Tables[0], dgCntst);
            }
        }
        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
            ShowNoResultFound(ds.Tables[0], dgCntst);
        }
        Session["grid"] = ds.Tables[0];
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
        gv.Rows[0].Cells[0].Text = "No contestants have been defined";
        source.Rows.Clear();
    }
    protected void btncmp_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtresult = new DataTable();
        if (Session["CMP"] != null)
        {
            dt = (DataTable)Session["CMP"];
            dtresult = (DataTable)Session["grid"];
            dtresult.Merge(dt, true, MissingSchemaAction.Ignore);
            dgCntst.DataSource = null;
            dgCntst.DataBind();
            dgCntst.DataSource = dtresult;
            dgCntst.DataBind();
            Session["grid"] = dtresult;
        }
    }
    protected void btnSaveCntst_Click(object sender, EventArgs e)
    {
        CntstCreate();
    }

    protected void CntstCreate()
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CmpCode", txtCompCode.Text.ToString().Trim());
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCntstDtls", htParam);
        ds.Clear();
        htParam.Clear();
        List<string> lstCntstCode = new List<string>();
        List<string> lstCmpCode = new List<string>();
        List<string> lstBizSrc = new List<string>();
        List<string> lstChnCls = new List<string>();
        List<string> lstMemTyp = new List<string>();
        List<string> lstEffFrm = new List<string>();
        List<string> lstEffTo = new List<string>();
        List<string> lstFinYr = new List<string>();
        List<string> lstVer = new List<string>();
        List<string> lstVerFrm = new List<string>();
        List<string> lstVerTo = new List<string>();

        string strhdnCnstCode = "";

        for (int intRowCount = 0; intRowCount <= dgCntst.Rows.Count - 1; intRowCount++)
        {
            HiddenField hdnCnstCode = (HiddenField)dgCntst.Rows[intRowCount].Cells[0].FindControl("hdnCnstCode");
            lstCntstCode.Add(hdnCnstCode.Value.ToString().Trim());
            strhdnCnstCode = hdnCnstCode.Value.ToString().Trim();

            HiddenField hdnCmpCode = (HiddenField)dgCntst.Rows[intRowCount].Cells[1].FindControl("lblCmpDsc");
            lstCmpCode.Add(hdnCmpCode.Value.ToString().Trim());

            HiddenField hdnBizSrc = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnSlsChnl");
            lstBizSrc.Add(hdnBizSrc.Value.ToString().Trim());

            HiddenField hdnChnCls = (HiddenField)dgCntst.Rows[intRowCount].Cells[3].FindControl("hdnSubCls");
            lstChnCls.Add(hdnChnCls.Value.ToString().Trim());

            HiddenField hdnMemTyp = (HiddenField)dgCntst.Rows[intRowCount].Cells[4].FindControl("hdnMemType");
            lstMemTyp.Add(hdnMemTyp.Value.ToString().Trim());

        }
        for (int intDataCount = 0; intDataCount <= lstCntstCode.Count - 1; intDataCount++)
        {
            htParam.Clear();
            htParam.Add("@CntstCode", lstCntstCode[intDataCount]);
            htParam.Add("@CmpCode", lstCmpCode[intDataCount]);
            htParam.Add("@BizSrc", lstBizSrc[intDataCount]);
            htParam.Add("@ChnCls", lstChnCls[intDataCount]);
            htParam.Add("@MemType", lstMemTyp[intDataCount]);
            if (txtEffDtFrm.Text == "")
            {
                htParam.Add("@EffFrm", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@EffFrm", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
            }
            if (txtEffDtTo.Text == "")
            {
                htParam.Add("@EffTo", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@EffTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));
            }
            if (txtVerEffFrm.Text == "")
            {
                htParam.Add("@VerFrmDt", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@VerFrmDt", Convert.ToDateTime(txtVerEffFrm.Text.ToString().Trim()));
            }
            if (txtVerEffTo.Text == "")
            {
                htParam.Add("@VerToDt", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@VerToDt", Convert.ToDateTime(txtVerEffTo.Text.ToString().Trim()));
            }
            htParam.Add("@FinYr", ddlBusiYear.Text.ToString().Trim());
            htParam.Add("@VerNo", txtVer.Text.ToString().Trim());
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            htParam.Add("@Flag", "N");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCntstDtls", htParam);
        }
        mdlpopup.Show();
        lbl3.Text = "Contestant Codes Saved Successfully";
        lbl4.Text = "Compensation Code:" + txtCompCode.Text.ToString().Trim();
        lbl5.Text = "Compensation Description:" + txtCompDesc1.Text.ToString().Trim();
        btnSave.Enabled = false;
    }

    protected void dgCntst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDel = (LinkButton)e.Row.FindControl("lnkDelete");
            Label lnkCnstCode = (Label)e.Row.FindControl("lnkCnstCode");
            lnkDel.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete contestant code for " + lnkCnstCode.Text.ToString().Trim() + "?')");
        }
    }
    protected void dgCntst_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = (DataTable)Session["grid"];
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex + 1;
            dgCntst.DataSource = (DataTable)Session["grid"];
            dgCntst.DataBind();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgCntst.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgCntst.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetupReport", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex - 1;
            dgCntst.DataSource = (DataTable)Session["grid"];
            dgCntst.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "CmpSetupReport", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlAccYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillDropDowns(ddlBusiYear, "15", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()));
        //ddlBusiYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }

    protected string GetYearType(string val)
    {
        string yrtyp = string.Empty;
        DataSet dstype = new DataSet();
        Hashtable httype = new Hashtable();
        dstype.Clear();
        httype.Add("@ACC_YEAR_CODE", val.ToString().Trim());
        dstype = objDal.GetDataSetForPrc_SAIM("Prc_GetYearType", httype);
        if (dstype.Tables.Count > 0 && dstype.Tables[0].Rows.Count > 0)
        {
            yrtyp = dstype.Tables[0].Rows[0]["YEAR_TYPE"].ToString().Trim();
        }
        return yrtyp;
    }
    protected void ddlBusiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetDates("V", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()), ddlBusiYear.SelectedValue.ToString().Trim());
    }

    protected void GetDates(string flag, string yrtyp, string busicode)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        htParam.Add("@BUSI_CODE", busicode.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtEffDtFrm.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtEffDtTo.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
            txtVerEffFrm.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtVerEffTo.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
        }
    }
    //ADDED BY KALYANI FOR DIVC
    //protected void btOK_Click(object sender, EventArgs e)
    //{
    //    ds.Clear();
    //    htParam.Clear();
    //    htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
    //    htParam.Add("@CompStat", ddlStatus.SelectedValue.ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCmpStatus", htParam);
    //    Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);

    //}
    //protected void chkQual_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkQual.Checked == true)
    //    {
    //        btOK.Enabled = true;
    //    }
    //}


    protected void FillDropDowns(DropDownList ddl)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();

        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetDESC01", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
    }
    //protected void btSubmit_Click1(object sender, EventArgs e)
    //{
    //    //REMARK ENTRY
    //    ds.Clear();
    //    htParam.Clear();
    //    htParam.Add("@CompRemark", txtRemark.Text.ToString().Trim());
    //    htParam.Add("@CompStat", ddlStatusR.SelectedValue.ToString().Trim());
    //    htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCompRemark", htParam);


    //    //AUDIT ENTRY
    //    ds.Clear();
    //    htParam.Clear();
    //    htParam.Add("@ActionFlag", "CH");
    //    htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
    //    htParam.Add("@UserId", Session["UserID"].ToString().Trim());
    //    htParam.Add("@Remark", txtRemark.Text.ToString().Trim());
    //    htParam.Add("@Status", ddlStatusR.SelectedValue.ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsertCMPNSTN_AuditTrail", htParam);

    //    Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);
    //}

    //protected void BindStatus()
    //{
    //    ds.Clear();

    //    ds = objDal.GetDataSetForPrc_SAIM("[Prc_BindStatus_DropDown_CHK]", htParam);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlStatusR.DataSource = ds.Tables[0];
    //        ddlStatusR.DataTextField = "DESC01";
    //        ddlStatusR.DataValueField = "CODE";
    //        ddlStatusR.DataBind();
    //        ddlStatusR.Items.Insert(0, new ListItem("-- SELECT --", ""));

    //    }
    //}

    //protected void BindAuditGrid(string strCompcode1)
    //{
    //    ds.Clear();
    //    htParam.Add("@CMPNSTN_CODE", strCompcode1);
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAuditData", htParam);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        gdAudit.DataSource = ds.Tables[0];
    //        gdAudit.DataBind();
    //    }
    //}
}
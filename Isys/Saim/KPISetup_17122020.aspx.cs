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

public partial class Application_ISys_Saim_KPISetup : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    int index;
    DropDownList ddlGrdChnl, ddlGrdSubChnl, ddlGrdMemType, ddlGrdStatus;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            divkpisrchhdrcollapse.Visible = false;
            //Added by Prathamesh on 21_02_2018 start
            ddlChnCls.Enabled = false;
            ddlKPItype.Enabled = false;
            ddlKPISbtype.Enabled = false;
            ddlMeasureAs.Enabled = false;
            ////ddlDtLstKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlKPIOrg.Enabled = false;
            ddlCategory.Enabled = false;
            ddlBusiYear.Enabled = false;
            ddlChn.Enabled = false;
            txtStdMin.Enabled = false;
            txtStdMax.Enabled = false;
            ddlBusiYrType.Enabled = false;
            txtFrmDate.Enabled = false;
            txtToDate.Enabled = false;
            txtEffdate.Enabled = false;
            txtCseDt.Enabled = false;
            txtVer.Enabled = false;
            txtBusiRuleCd.Enabled = false;
            txtKPIDesc1.Enabled = false;
            txtKPIDesc2.Enabled = false;
            txtKPIDesc3.Enabled = false;
            btnCancel.Enabled = false;
            ddlSrcUpld.Enabled = false;

            divGrid.Visible = false;

            //Added by Prathamesh on 21_02_2018 end

            txtKPIDesc1.Focus();
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlKPItype.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlKPISbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlMeasureAs.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ////ddlDtLstKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlKPIOrg.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlCategory.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlBusiYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ////ddlDtFuncKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ////ddlDtFldKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlMemType.Items.Insert(0, new ListItem("-- SELECT --", ""));

            FillDropDowns(ddlKPItype, "1");
            FillDropDowns(ddlMeasureAs, "3");
            FillDropDowns(ddlKPIOrg, "4");
            FillDropDowns(ddlCategory, "17");
            FillDropDowns(ddlBusiYrType, "9");

            funchnlpopup(ddlChn);
            funchnlpopup(ddlChannel);

            funchnlpopup(lstChannel);

            GetChnCls(ddlChannel, ddlSubChannel);
            //fillDdlStatus(ddlStatus);
            Fillddl(ddlStatus, "Authflg");

            txtPageChnlMap.Text = "1";
            txtKPICode.Enabled = false;
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "N")
                {
                    txtVer.Text = "1.00";
                    txtStdMin.Text = "0";
                    txtStdMax.Text = "0";
                    lnkAdd.Enabled = false;

                    btnCancel.Enabled = true;
                    btnNo.Visible = false;
                    GetMaxKPI();
                    AddNewKpi();
                    div4.Visible = false;
                    //btnSave.Attributes.Add("onclick", "javascript:return validate();");
                }
                else if (Request.QueryString["flag"].ToString().Trim() == "E")
                {
                    btnCancel.Visible = false;
                    btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
                    FillKPIDetails();
                }
            }
            BindActionGrid();
            lnkAdd.Attributes.Add("onclick", "funPopUp();return false;");
            btnSave.Attributes.Add("onclick", "javascript:return validate();");
            txtEfDate.Attributes.Add("readonly", "readonly");
            txtCeDate.Attributes.Add("readonly", "readonly");
            txtFrmDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
            txtEffdate.Attributes.Add("readonly", "readonly");
            txtCseDt.Attributes.Add("readonly", "readonly");
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        try
        {
            //var a = ScriptManager.GetCurrent(this);
            //var client = a.GetRegisteredClientScriptBlocks();
            //var scr = client.AsEnumerable().ToArray();
            //ScriptManager1.Scripts;
//                ;scr[0].
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "Page_UnLoad", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        if (btnSave.Enabled == true && btnEdit.Enabled == false)
        {
            mdlpopup2.Show();

            lblVersion1.Text = "All changes shall be lost if you do not save and cancel." + "</br>Please click yes to continue";
        }
        else
        {
            Response.Redirect("KPISearch.aspx", true);
        }

    }

    //Added by Prathamesh on 24_02_2018 start for Add New Kpi
    protected void AddNewKpi()
    {
        //Added by Prathamesh on 24_02_2018 start
        btnHist.Visible = false;
        btnSave.Enabled = true;
        btnEdit.Enabled = false;
        txtKPICode.Enabled = false;
        ddlChnCls.Enabled = true;
        txtVer.Enabled = true;
        ddlKPItype.Enabled = true;
        ddlKPISbtype.Enabled = true;
        ddlMeasureAs.Enabled = true;
        ////ddlDtLstKey.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlKPIOrg.Enabled = true;
        ddlCategory.Enabled = true;
        //ddlBusiYear.Enabled = true;
        ddlChn.Enabled = true;
        txtStdMin.Enabled = true;
        txtStdMax.Enabled = true;
        //ddlBusiYrType.Enabled = true;
        //txtFrmDate.Enabled = true;
        //txtToDate.Enabled = true;
        //txtEffdate.Enabled = true;
        //txtCseDt.Enabled = true;
        //txtVer.Enabled = true;
        //txtBusiRuleCd.Enabled = true;
        txtKPIDesc1.Enabled = true;
        txtKPIDesc2.Enabled = true;
        txtKPIDesc3.Enabled = true;
        txtVer.Enabled = false;

        if (ddlKPIOrg.SelectedIndex == 3)
        {
            ddlSrcUpld.Enabled = true;
        }

        //Added by Prathamesh on 24_02_2018 end
        ddlBusiYrType.SelectedIndex = 1;
        FillDropDowns(ddlBusiYear, "15", GetYearType(ddlBusiYrType.SelectedValue.ToString().Trim()), "");
        NewKPIVersion();
        ddlBusiYear.Focus();
        ddlBusiYear.SelectedIndex = (ddlBusiYear.Items.Count - 1);
        txtFrmDate.Text = DateTime.Now.Date.ToShortDateString();
        txtEffdate.Text = DateTime.Now.Date.ToShortDateString();
    }
    //Added by Prathamesh on 24_02_2018 end for Add New Kpi

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();//btnHist_Click
    }

    protected void BindGrid()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@KPICode", txtKPICode.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsKPIDtls", htParam);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgKPI.DataSource = ds;
                    dgKPI.DataBind();
                    ViewState["grid"] = ds.Tables[0];
                    if (dgKPI.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                    }
                }
            }
            else
            {
                ds = null;
            }
        }
        else
        {
            ds = null;
        }
    }

    protected void btnHist_Click(object sender, EventArgs e)
    {
        divkpisrchhdrcollapse.Visible = true;
        BindGrid();
    }

    protected void dgKPI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if(DataRow)
    }

    protected void dgKPI_Sorting(object sender, GridViewSortEventArgs e)
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
        /////ShowPageInformation();
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgKPI.PageIndex;
            dgKPI.PageIndex = pageIndex - 1;
            BindGrid();
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
            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgKPI.PageIndex;
            dgKPI.PageIndex = pageIndex + 1;
            BindGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgKPI.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgKPI.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('212');", true);
            int a = MinMaxCom();
            if (a == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('21');", true);
                return;
            }
            int b = VerFrmDate();
            if (b == 1)
            {
                return;
            }
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            mdlpopup1.Hide();
            if (Request.QueryString["flag"].ToString().Trim() == "N")
            {
                mdlpopup1.Show();
                lblVersion.Text = "Do you want to add new KPI setup?";
            }
            else
            {
                mdlpopup1.Show();
                lblVersion.Text = "Do you want to save changes?";
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        bool isKPIsaved = false;
        string Result = string.Empty;
        string text_kpi = txtKPICode.Text.Trim();
        if (Request.QueryString["flag"].ToString().Trim() != "N")
        {
            KPICreate("U");

            if (ViewState["MyDataSet"] == "Result")
            {
                lbl3.Text = "KPI Desc:" + txtKPIDesc1.Text.ToString().Trim();
                lbl5.Text = "Already  exist";
                AddNewKpi();
            }

            else
            {
                lbl3.Text = "New Version of KPI:" + txtKPIDesc1.Text.ToString().Trim();
                lbl5.Text = "Updated successfully";
            }
        }
        else
        {
            KPICreate("AddNew");
            if (ViewState["MyDataSet"] == "Result")
            {
                lbl3.Text = "KPI Code:" + txtKPICode.Text + "\n" + " KPI Desc : " + txtKPIDesc1.Text.ToString().Trim(); ;
                lbl5.Text = "Already  exist";
                AddNewKpi();
            }

            else
            {
                SaveKPI_MAP_Details("", "", "", String.Join("", text_kpi.Split(new char[] { '-' })), "2001");
                isKPIsaved = true;
                lbl3.Text = "KPI Code:" + txtKPICode.Text + "\n" + " KPI Desc : " + txtKPIDesc1.Text.ToString().Trim(); ;
                lbl5.Text = "saved successfully";
                btnCancel.Visible = false;
                div4.Visible = true;
                //Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + txtKPICode.Text, false);
            }
        }
        //KPICreate("N");
        
        btnSave.Enabled = false;
        ddlChnCls.Enabled = false;
        ddlKPItype.Enabled = false;
        ddlKPISbtype.Enabled = false;
        ddlMeasureAs.Enabled = false;
        ddlKPIOrg.Enabled = false;
        ddlCategory.Enabled = false;
        ddlBusiYear.Enabled = false;
        ddlChn.Enabled = false;
        txtStdMin.Enabled = false;
        txtStdMax.Enabled = false;
        ddlBusiYrType.Enabled = false;
        txtFrmDate.Enabled = false;
        txtToDate.Enabled = false;
        txtEffdate.Enabled = false;
        txtCseDt.Enabled = false;
        txtVer.Enabled = false;
        txtBusiRuleCd.Enabled = false;
        txtKPIDesc1.Enabled = false;
        txtKPIDesc2.Enabled = false;
        txtKPIDesc3.Enabled = false;

        if (isKPIsaved)
        {
            div4.Visible = true;
        }
        mdlpopup1.Hide();
        mdlpopup.Show();
    }

    protected void btnYes1_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPISearch.aspx", true);
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //txtVer.Enabled = true;
        KPICreate("U");


        if (ViewState["MyDataSet"] == "Result")
        {
            lbl3.Text = "KPI Desc:" + txtKPIDesc1.Text.ToString().Trim();
            lbl5.Text = "Already  exist";
            //AddNewKpi();
            txtKPIDesc1.Enabled = true;
            txtKPIDesc3.Enabled = true;
            ddlChn.Enabled = true;
            ddlKPISbtype.Enabled = true;
            mdlpopup.Show();
            btnSave.Enabled = true;
        }

        else
        {
            lblPnl4.Text = "Existing Version of KPI:" + txtKPIDesc1.Text.ToString().Trim();
            lblPnl6.Text = "Updated Successfully";
            mdlpopup3.Show();

            txtKPIDesc1.Enabled = false;
            txtKPIDesc2.Enabled = false;
            txtKPIDesc3.Enabled = false;
            ddlChn.Enabled = false;
            ddlChnCls.Enabled = false;
            btnSave.Enabled = false;
            ddlKPItype.Enabled = false;
            ddlKPISbtype.Enabled = false;
            ddlMeasureAs.Enabled = false;
            ddlKPIOrg.Enabled = false;
            txtStdMin.Enabled = false;
            txtStdMax.Enabled = false;
            ddlCategory.Enabled = false;
            ddlSrcUpld.Enabled = false;
        }
    }

    protected void btnCanSave_Click(object sender, EventArgs e)
    {
        ddlKPItype.Enabled = true;
        ddlKPISbtype.Enabled = true;
        ddlMeasureAs.Enabled = true;
        ddlKPIOrg.Enabled = true;
        txtStdMin.Enabled = true;
        txtStdMax.Enabled = true;
        ddlCategory.Enabled = true;
    }

    protected void btnNo1_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = true;
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EditControl();
    }

    protected void EditControl()
    {

        if (HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpchecker")
        {
            txtKPIDesc1.Enabled = true;
            txtKPIDesc2.Enabled = true;
            txtKPIDesc3.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = true;
            ddlChnCls.Enabled = false;
            txtVer.Enabled = false;
            ddlKPItype.Enabled = true;
            ddlKPISbtype.Enabled = true;
            ddlMeasureAs.Enabled = true;
            ////ddlDtLstKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlKPIOrg.Enabled = true;
            ddlCategory.Enabled = true;
            ddlBusiYear.Enabled = false;
            ddlChn.Enabled = false;
            txtStdMin.Enabled = true;
            txtStdMax.Enabled = true;
            ddlBusiYrType.Enabled = false;
            txtFrmDate.Enabled = false;
            txtToDate.Enabled = false;
            txtEffdate.Enabled = false;
            txtCseDt.Enabled = false;
            txtVer.Enabled = false;
            txtBusiRuleCd.Enabled = false;
        }



        else
        {
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = true;
            ddlChnCls.Enabled = false;
            txtVer.Enabled = false;
            ddlKPItype.Enabled = true;
            ddlKPISbtype.Enabled = true;
            ddlMeasureAs.Enabled = true;
            ////ddlDtLstKey.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlKPIOrg.Enabled = true;
            ddlCategory.Enabled = true;
            ddlBusiYear.Enabled = false;
            ddlChn.Enabled = false;
            txtStdMin.Enabled = true;
            txtStdMax.Enabled = true;
            ddlBusiYrType.Enabled = false;
            txtFrmDate.Enabled = false;
            txtToDate.Enabled = false;
            txtEffdate.Enabled = false;
            txtCseDt.Enabled = false;
            txtVer.Enabled = false;
            txtBusiRuleCd.Enabled = false;
            txtKPIDesc1.Enabled = false;
            txtKPIDesc2.Enabled = false;
            txtKPIDesc3.Enabled = false;
        }

        ddlMeasureAs.Focus();
        if (ddlMeasureAs.SelectedIndex == 1)
        {
            txtStdMin.Enabled = false;
            txtStdMax.Enabled = false;
            txtStdMax.Text = txtStdMin.Text;
        }

        else
        {
            txtStdMax.Enabled = true;
            txtStdMin.Enabled = true;
        }

    }

    protected void NewKPIVersion()
    {
        string kpi = txtKPICode.Text.Substring(0, 8);
        txtKPICode.Text = kpi + "-" + "01";//+(Convert.ToDecimal(txtVer.Text));
    }

    protected void KPICreate(string strflag)
    {

        // DateTime.Now.Date.ToShortDateString();

        string Result = string.Empty;
        ds.Clear();
        htParam.Clear();
        if (strflag == "AddNew")
        {
            htParam.Add("@KPICode", txtKPICode.Text.Substring(0, 8) + txtKPICode.Text.Substring(9, 2));  //(Convert.ToDecimal(txtVer.Text)));
        }
        else if (strflag == "N")
        {
            double kpi_No = Convert.ToDouble(txtKPICode.Text.Substring(10)) + 1;
            //htParam.Add("@KPICode", txtKPICode.Text.Substring(0, 8) + (Convert.ToDecimal(txtVer.Text) + Convert.ToDecimal("1")).ToString());
            htParam.Add("@KPICode", txtKPICode.Text.Substring(0, 8) + txtKPICode.Text.Substring(9, 1) + kpi_No);// + Convert.ToInt32("1")).ToString());
        }
        else
        {
            htParam.Add("@KPICode", txtKPICode.Text.Substring(0, 8) + txtKPICode.Text.Substring(9, 2));

        }
        // htParam.Add("@KPICode", txtKPICode.Text.ToString().Trim());
        htParam.Add("@Category", ddlCategory.SelectedValue.ToString().Trim());
        htParam.Add("@KPIDesc1", txtKPIDesc1.Text.ToString().Trim());
        htParam.Add("@KPIDesc2", txtKPIDesc2.Text.ToString().Trim());
        htParam.Add("@KPIDesc3", txtKPIDesc3.Text.ToString().Trim());
        htParam.Add("@KPIType", ddlKPItype.SelectedValue.ToString().Trim());
        htParam.Add("@KPISubType", ddlKPISbtype.SelectedValue.ToString().Trim());
        htParam.Add("@MeasuredAs", ddlMeasureAs.SelectedValue.ToString().Trim());
        htParam.Add("@KPIOrigin", ddlKPIOrg.SelectedValue.ToString().Trim());
        htParam.Add("@StdMin", txtStdMin.Text.ToString().Trim());
        htParam.Add("@StdMax", txtStdMax.Text.ToString().Trim());
        htParam.Add("@BusiYrType", ddlBusiYrType.SelectedValue.ToString().Trim());
        htParam.Add("@BusiYr", ddlBusiYear.SelectedValue.ToString().Trim());
        if (strflag == "N")
        {
            txtVer.Text = (Convert.ToDecimal(txtVer.Text) + Convert.ToDecimal("1.00")).ToString();
        }


        htParam.Add("@Version", txtVer.Text.ToString().Trim());

        txtEffdate.Text = DateTime.Now.Date.ToShortDateString();
        htParam.Add("@StartDt", Convert.ToDateTime(txtEffdate.Text.ToString().Trim()));
        htParam.Add("@Chn", ddlChn.SelectedValue.ToString().Trim());
        htParam.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
        htParam.Add("@BusiRuleCode", txtBusiRuleCd.Text.ToString().Trim());

        if (txtFrmDate.Text == "")
        {
            htParam.Add("@RangeFrm", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@RangeFrm", Convert.ToDateTime(txtFrmDate.Text.ToString().Trim()));
        }
        if (txtToDate.Text == "")
        {
            htParam.Add("@RangeTo", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@RangeTo", Convert.ToDateTime(txtToDate.Text.ToString().Trim()));
        }

        //DateTime theDate = DateTime.Now;
        //theDate = theDate.AddYears(1);
        //txtCseDt.Text =theDate.ToShortDateString();
        //if (txtCseDt.Text == "")
        //{
        htParam.Add("@CeaseDt", System.DBNull.Value);
        //}
        //else
        //{
        //    htParam.Add("@CeaseDt", Convert.ToDateTime(txtCseDt.Text.ToString().Trim()));
        //}
        htParam.Add("@FrmlCode", hdnFormulaCode.Value.ToString().Trim());
        htParam.Add("@FrmlDesc", txtFormula.Text.ToString().Trim());
        htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
        if (strflag == "N" || strflag == "AddNew")
        {
            htParam.Add("@Flag", "N");
        }
        else if (strflag == "U")
        {
            htParam.Add("@Flag", "F");
        }
        htParam.Add("@SrcUpld", ddlSrcUpld.SelectedValue.ToString().Trim());

        //int i=Convert.ToInt32(ds.Tables[0].Rows[0][0]).ToString();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsKPIDtls", htParam);

        if (ds.Tables.Count > 0)
        {
            if ((ds.Tables[0].Rows[0]["Result"]).ToString() == "Result")
            {
                ViewState["MyDataSet"] = "Result";

                btnCancel.Visible = true;

            }
        }


        if (strflag == "N")
        {
            double kpi_No = Convert.ToDouble(txtKPICode.Text.Substring(10)) + 1;
            txtKPICode.Text = txtKPICode.Text.Substring(0, 8) + "-" + txtKPICode.Text.Substring(9, 1) + kpi_No;
        }
    }

    protected void GetMaxKPI()
    {
        try
        {
            DataSet d = new DataSet();
            htParam.Clear();
            d = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxKPICode", htParam);
            if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
            {
                txtKPICode.Text = d.Tables[0].Rows[0]["MaxKPI"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "GetMaxKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlKPISbtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKPISbtype.SelectedIndex == 1)
        {
            txtStdMin.Text = "0";
            txtStdMax.Text = "0";
        }
        else
        {
            txtStdMin.Text = "0.00";
            txtStdMax.Text = "0.00";
        }

        //txtStdMin.Text = "0";
        //txtStdMax.Text = "0";
        ddlKPISbtype.Focus();
    }

    protected void FillKPIDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            htParam.Clear();
            if (Request.QueryString["KPICode"] != null)
            {
                htParam.Add("@KPICode", Request.QueryString["KPICode"].ToString().Trim());
            }
            htParam.Add("@Flag", "1");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_KPISearch", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                //txtKPICode.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                //COMMENT BY PRATHAMESH ON 20180227 START 
                string kpicode = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtKPICode.Text = kpicode.Substring(0, 8) + "-" + kpicode.Substring(8);
                //COMMENT BY PRATHAMESH ON 20180227 END 
                txtKPIDesc1.Text = ds.Tables[0].Rows[0]["KPI_DESC_01"].ToString().Trim();
                txtKPIDesc2.Text = ds.Tables[0].Rows[0]["KPI_DESC_02"].ToString().Trim();
                txtKPIDesc3.Text = ds.Tables[0].Rows[0]["KPI_DESC_03"].ToString().Trim();
                ddlKPItype.SelectedValue = ds.Tables[0].Rows[0]["KPI_TYPE"].ToString().Trim();
                FillSubType();
                ddlKPISbtype.SelectedValue = ds.Tables[0].Rows[0]["KPI_SUBTYPE"].ToString().Trim();
                ddlMeasureAs.SelectedValue = ds.Tables[0].Rows[0]["MEASURED_AS"].ToString().Trim();
                ddlKPIOrg.SelectedValue = ds.Tables[0].Rows[0]["KPI_ORIGIN"].ToString().Trim();
                ddlChn.SelectedValue = ds.Tables[0].Rows[0]["CHN"].ToString().Trim();
                GetChnCls(ddlChn, ddlChnCls);
                ddlChnCls.SelectedValue = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();
                txtStdMin.Text = ds.Tables[0].Rows[0]["STD_MIN"].ToString().Trim();
                txtStdMax.Text = ds.Tables[0].Rows[0]["STD_MAX"].ToString().Trim();
                txtFrmDate.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
                txtToDate.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
                txtFinYr.Text = ds.Tables[0].Rows[0]["BUSI_YR_TYPE"].ToString().Trim();
                ddlBusiYrType.SelectedValue = ds.Tables[0].Rows[0]["BUSI_YR_TYPE"].ToString().Trim();
                FillDropDowns(ddlBusiYear, "15", GetYearType(ddlBusiYrType.SelectedValue.ToString().Trim()), "");
                ddlBusiYear.SelectedValue = ds.Tables[0].Rows[0]["BUSI_YR"].ToString().Trim();
                txtVer.Text = ds.Tables[0].Rows[0]["VER_NO"].ToString().Trim();
                txtEffdate.Text = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
                txtCseDt.Text = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
                ////ddlDtLstKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_LIST_KEY"].ToString().Trim();
                ////FillDataField(ddlDtFldKey, ddlDtLstKey);
                ////ddlDtFldKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_FIELD_KEY"].ToString().Trim();
                ////ddlDtFuncKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_FUNCTION_KEY"].ToString().Trim();
                txtBusiRuleCd.Text = ds.Tables[0].Rows[0]["BUSI_RULE_CODE"].ToString().Trim();
                txtFormula.Text = ds.Tables[0].Rows[0]["FRML_DESC"].ToString().Trim();
                txtFormula.Enabled = false;
                hdnFormulaCode.Value = ds.Tables[0].Rows[0]["FRML_CODE"].ToString().Trim();
                LnkVisible();
                ddlSrcUpld.SelectedValue = ds.Tables[0].Rows[0]["SRC_UPLD"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "FillKPIDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ClearControls()
    {
        //txtKPICode.Text = "";
        txtKPIDesc1.Text = "";
        txtKPIDesc2.Text = "";
        txtKPIDesc3.Text = "";
        txtStdMax.Text = "";
        txtStdMin.Text = "";
        //txtFrmDate.Text = "";
        //txtToDate.Text = "";
        txtFinYr.Text = "";
        //txtVer.Text = "";
        //txtEffdate.Text = "";
        //txtCseDt.Text = "";
        ddlKPItype.SelectedValue = "";
        ddlKPISbtype.SelectedValue = "";
        ddlMeasureAs.SelectedValue = "";
        ddlKPIOrg.SelectedValue = "";
        ddlChn.SelectedValue = "";
        ddlCategory.SelectedValue = "";
        ddlChnCls.SelectedValue = "";
        //ddlBusiYrType.SelectedValue = "";
        //ddlBusiYear.SelectedValue = "";
        //txtFormula.Text = "";
        ddlSrcUpld.SelectedValue = "";
    }

    #region funchnlpopup
    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_getchannels", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "funchnlpopup", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void ddlChn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChn.SelectedValue != "")
        {
            GetChnCls(ddlChn, ddlChnCls);
        }
        else
        {
            ddlChnCls.Items.Clear();
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        //ddlChn.Focus();
    }

    protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChannel.SelectedIndex != 0)
        {
            GetChnCls(ddlChannel, ddlSubChannel);
        }
        else
        {
            ddlSubChannel.Items.Clear();
            ddlSubChannel.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        //ddlChannel.Focus();
    }

    protected void GetChnCls(DropDownList ddlChnPara, DropDownList ddl)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlChnPara.SelectedValue.ToString().Trim());

            ddl.Items.Clear();
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ChnClsDesc01";
                ddl.DataValueField = "ChnCls";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "GetChnCls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
              
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlKPItype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlKPItype.SelectedValue != "")
            {
                FillSubType();
            }
            else
            {
                ddlKPISbtype.Items.Clear();
                ddlKPISbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
                txtStdMin.Text = "0";
                txtStdMax.Text = "0";
            }
            ddlKPItype.Focus();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "ddlKPItype_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillSubType()
    {
        try
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("@TypeCode", ddlKPItype.SelectedValue.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetKPISubType", ht);
            ddlKPISbtype.Items.Clear();
            if (drRead.HasRows)
            {
                ddlKPISbtype.DataSource = drRead;
                ddlKPISbtype.DataTextField = "DESC01";
                ddlKPISbtype.DataValueField = "CODE";
                ddlKPISbtype.DataBind();
            }
            drRead.Close();
            ddlKPISbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "FillSubType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDataField(DropDownList ddl, DropDownList ddl1)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@TblCode", ddl1.SelectedValue.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetDataLstKey", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "FillDataField", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlChnCls.Focus();
    }

    protected void ddlMeasureAs_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMeasureAs.Focus();
        if (ddlMeasureAs.SelectedIndex == 1)
        {
            txtStdMin.Enabled = false;
            txtStdMax.Enabled = false;
            txtStdMax.Text = txtStdMin.Text;
        }

        else
        {
            txtStdMax.Enabled = true;
            txtStdMin.Enabled = true;
        }


    }

    protected int MinMaxCom()
    {
        int c = 0;
        if (ddlMeasureAs.SelectedIndex == 2 || ddlMeasureAs.SelectedIndex == 3)
        {

            float a = float.Parse(txtStdMin.Text);
            float b = float.Parse(txtStdMax.Text);
            if (a > b)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Std Min. should be less than Std Max.');", true);
                txtStdMin.Focus();
                c = 1;
            }

            else if (a == b)
            {
                if (ddlMeasureAs.SelectedIndex != 2 && ddlMeasureAs.SelectedIndex == 3)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Std Min. should not be equal to Std Max.');", true);
                    txtStdMin.Focus();
                    c = 1;
                }
            }
        }

        if (ddlMeasureAs.SelectedIndex == 4 || ddlMeasureAs.SelectedIndex == 5)
        {
            float a = float.Parse(txtStdMin.Text);
            float b = float.Parse(txtStdMax.Text);
            //int a = Convert.ToInt32(txtStdMin.Text);
            //int b = Convert.ToInt32(txtStdMax.Text);
            if (a < b)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Std Min. should be greater than Std Max.');", true);
                txtStdMin.Focus();
                c = 1;
            }
            else if (a == b)
            {
                if (ddlMeasureAs.SelectedIndex != 4 && ddlMeasureAs.SelectedIndex == 5)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('1');", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Std Min. should not be equal to Std Max.');", true);
                    txtStdMin.Focus();
                    c = 1;
                }

            }
        }
        return c;
    }

    protected int VerFrmDate()
    {
        int c = 0;
        DateTime dy1 = DateTime.Now.AddYears(-1);
        string yy = dy1.Year.ToString();
        //int y = convert(yy - 1;

        //txtEffdate.Text = DateTime.Now.Date.ToShortDateString();
        DateTime dy11 = Convert.ToDateTime(txtEffdate.Text);
        DateTime dy12 = Convert.ToDateTime(txtFrmDate.Text);

        string EffDate = "01/04/" + yy;
        DateTime dy22 = (Convert.ToDateTime(EffDate));

        if (dy11 < dy22)
        {
            string message = "Version eff. date should not be less than" + EffDate;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('" + message + "');", true);
            txtEffdate.Focus();
            c = 1;
        }

        else
        {
            txtEffdate.Text = dy11.ToString();
            c = 0;
        }

        if (dy12 < dy22)
        {
            string message = "from date should not be less than" + " " + EffDate;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('" + message + "');", true);
            txtFrmDate.Focus();
            c = 1;
        }

        else
        {
            txtFrmDate.Text = dy12.ToString();
            c = 0;
        }

        return c;

    }

    protected void ddlKPIOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKPIOrg.SelectedIndex == 3)
        {
            ddlSrcUpld.Enabled = true;
        }
        LnkVisible();
        ddlKPIOrg.Focus();
    }

    protected void btnfrml_Click(object sender, EventArgs e)
    {
        if (Session["frml"] != null)
        {
            txtFormula.Text = Session["frml"].ToString();
        }
        txtFormula.Enabled = false;
    }

    protected void lnkHyb_Click(object sender, EventArgs e)
    {
        ///////Response.Redirect("MstTblDesign.aspx");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpHyb('" + txtKPICode.Text.ToString().Trim() + "','" + txtKPIDesc1.Text.ToString().Trim() + "');", true);
    }

    protected void LnkVisible()
    {
        if (ddlKPIOrg.SelectedValue == "1001")
        {
            //lnkAdd.Enabled = true;
            txtFormula.ReadOnly = true;
            lnkHyb.Visible = false;
            lblSrcUpld.Visible = false;
            ddlSrcUpld.Items.Clear();
            ddlSrcUpld.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlSrcUpld.Visible = false;
        }
        else if (ddlKPIOrg.SelectedValue == "1002")
        {
            lnkAdd.Enabled = false;
            txtFormula.ReadOnly = true;
            lnkHyb.Visible = false;
            lblSrcUpld.Visible = false;
            ddlSrcUpld.Items.Clear();
            ddlSrcUpld.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlSrcUpld.Visible = false;
        }
        else if (ddlKPIOrg.SelectedValue == "1003")
        {
            lnkAdd.Enabled = false;
            txtFormula.ReadOnly = true;
            lnkHyb.Visible = true;
            lblSrcUpld.Visible = true;
            ddlSrcUpld.Visible = true;
            FillDropDowns(ddlSrcUpld, "25");
        }
    }

    protected void btnC_Click(object sender, EventArgs e)
    {
        mdlVwHb.Hide();
    }

    protected void ddlBusiYrType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlBusiYear, "15", GetYearType(ddlBusiYrType.SelectedValue.ToString().Trim()), "");

        /////ddlBusiYear.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlBusiYear.Focus();
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

    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        ht.Add("@TYPFLG", typflg.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }

    protected void ddlBusiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDates("V", GetYearType(ddlBusiYrType.SelectedValue.ToString().Trim()), ddlBusiYear.SelectedValue.ToString().Trim());
        ddlBusiYear.Focus();
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
            txtFrmDate.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtToDate.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
            txtEffdate.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtCseDt.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
        }
    }

    protected void ddlMemType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void fillddlMemType(DropDownList ddlChnId, DropDownList ddlSubChnlId, DropDownList ddlMemTypeId)
    {

        if (ddlChnId.SelectedIndex != 0 && ddlSubChnlId.SelectedIndex !=0)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@BIZSRC", ddlChnId.SelectedValue.ToString().Trim());
            ht.Add("@CHNCLS", ddlSubChnlId.SelectedValue.ToString().Trim());

            ddlMemTypeId.Items.Clear();
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_fillddlMemType", ht);
            if (drRead.HasRows)
            {
                ddlMemTypeId.DataSource = drRead;
                ddlMemTypeId.DataTextField = "ParamDesc";
                ddlMemTypeId.DataValueField = "ParamValue";
                ddlMemTypeId.DataBind();
               
            }
            ddlMemTypeId.Items.Insert(0, new ListItem("-- SELECT --", ""));
            drRead.Close();
           
        }
        else
        {
        }
    }

    protected void ddlSubChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlMemType(ddlChannel, ddlSubChannel, ddlMemType);
    }

    public void fillDdlStatus(DropDownList ddlId)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", "");
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_Fillddlstatus", ht);
        if (drRead.HasRows)
        {
            ddlId.DataSource = drRead;
            ddlId.DataTextField = "ParamDesc1";
            ddlId.DataValueField = "ParamValue";
            ddlId.DataBind();
            ddlId.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        drRead.Close();
       
    }

    protected void BindActionGrid()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            string kpi = String.Join("", txtKPICode.Text.Split(new char[] { '-' }));
            htParam.Add("@KPI_CODE", kpi);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GetChnlMappDetails", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();
                ViewState["gridChnlMap"] = ds.Tables[0];
                divGrid.Visible = true;
                if (grvaddedresult.PageCount > 1)
                {
                    btnnextChnlMap.Enabled = true;
                }
                else
                {
                    btnnextChnlMap.Enabled = false;
                }
            }
            else
            {
                divGrid.Visible = false;
                ds = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string channel = ddlChannel.SelectedValue.ToString().Trim();
            string subchnl = ddlSubChannel.SelectedValue.ToString().Trim();
            string memtype = ddlMemType.SelectedValue.ToString().Trim();
            string kpi = String.Join("", txtKPICode.Text.Split(new char[] { '-' }));

            if (!CheckChannelMapExits(kpi, channel, subchnl, memtype))
            {
                Hashtable ht = new Hashtable();
                DataSet ds = new DataSet();
                ht.Add("@KPI_CODE", kpi);
                ht.Add("@BIZSRC", channel);
                ht.Add("@CHNCLS", subchnl);
                ht.Add("@MEMTYPE", memtype);
                ht.Add("@STATUS", ddlStatus.SelectedValue.ToString().Trim());
                ht.Add("@EFF_DTIM", txtEfDate.Text.ToString().Trim());
                ht.Add("@CSE_DTIM", txtCeDate.Text.ToString().Trim());
                ht.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_INSChnlMappDetails", ht);
                grvaddedresult.EditIndex = -1;
                BindActionGrid();
                ResetChnlMap();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This mapping already exist.');", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool CheckChannelMapExits(string KPI_CODE, string channel, string subchnl, string memtype)
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@KPI_CODE", KPI_CODE);
        ht.Add("@BIZSRC", channel);
        ht.Add("@CHNCLS", subchnl);
        ht.Add("@MEMTYPE", memtype);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_CHKKPICHNLMAP", ht);
        return Convert.ToString(ds.Tables[0].Rows[0][0]) == "1";
    }

    public void clearValue()
    {
        txtEfDate.Text = "";
        txtCeDate.Text = "";

    }

    protected void grvaddedresult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            index = e.NewEditIndex;
            grvaddedresult.EditIndex = e.NewEditIndex;
            this.BindActionGrid();
            grvaddedresult.EditIndex = e.NewEditIndex;
            grvaddedresult.AllowSorting = false;
            string chnl = Convert.ToString(grvaddedresult.DataKeys[index]["BIZSRC"]);
            string Subchnl = Convert.ToString(grvaddedresult.DataKeys[index]["CHNCLS"]);
            string MEMTYPE = Convert.ToString(grvaddedresult.DataKeys[index]["MEMTYPE"]);
            ddlGrdChnl = grvaddedresult.Rows[index].FindControl("ddlGrdChnl") as DropDownList;
            ddlGrdSubChnl = grvaddedresult.Rows[index].FindControl("ddlGrdSubChnl") as DropDownList;
            ddlGrdMemType = grvaddedresult.Rows[index].FindControl("ddlGrdMemType") as DropDownList;
            ddlGrdStatus = grvaddedresult.Rows[index].FindControl("ddlGrdStatus") as DropDownList;

            TextBox csDate = grvaddedresult.Rows[index].FindControl("txtceasedt") as TextBox;

            csDate.Attributes.Add("readonly", "readonly");
            funchnlpopup(ddlGrdChnl);
            ddlGrdChnl.SelectedValue = chnl;

            GetChnCls(ddlGrdChnl, ddlGrdSubChnl);
            ddlGrdSubChnl.SelectedValue = Subchnl;

            fillddlMemType(ddlGrdChnl, ddlGrdSubChnl, ddlGrdMemType);
            ddlGrdMemType.SelectedValue = MEMTYPE;
            Fillddl(ddlStatus, "Authflg");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "grvaddedresult_RowEditing", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void grvaddedresult_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = (DataTable)ViewState["gridChnlMap"];
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

    protected void ddlGrdChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        //index = e.NewEditIndex;
        GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
        ddlGrdChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdChnl") as DropDownList;
        ddlGrdSubChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdSubChnl") as DropDownList;
        GetChnCls(ddlGrdChnl, ddlGrdSubChnl);
    }

    protected void ddlGrdSubChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;
        ddlGrdChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdChnl") as DropDownList;
        ddlGrdSubChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdSubChnl") as DropDownList;
        ddlGrdMemType = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdMemType") as DropDownList;
        fillddlMemType(ddlGrdChnl, ddlGrdSubChnl, ddlGrdMemType);

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            ddlGrdChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdChnl") as DropDownList;
            ddlGrdSubChnl = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdSubChnl") as DropDownList;
            ddlGrdMemType = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdMemType") as DropDownList;
            ddlGrdStatus = grvaddedresult.Rows[row.RowIndex].FindControl("ddlGrdStatus") as DropDownList;

            string KPI_CODE = String.Join("", ((Label)row.FindControl("lblChnlMapId")).Text.Split(new char[] { '-' }));
            string ChnlValue = (row.FindControl("ddlGrdChnl") as DropDownList).SelectedValue.ToString().Trim();
            string SubChnlValue = (row.FindControl("ddlGrdSubChnl") as DropDownList).SelectedValue.ToString().Trim();
            string MemTypeValue = (row.FindControl("ddlGrdMemType") as DropDownList).SelectedValue.ToString().Trim();
            string StatusValue = (row.FindControl("ddlGrdStatus") as DropDownList).SelectedValue.ToString().Trim();
            string EffDteValue = ((TextBox)row.FindControl("txtEffDtFrm")).Text.ToString().Trim();
            string CeDteValue = ((TextBox)row.FindControl("txtceasedt")).Text.ToString().Trim();

            bool isValid = true;

            //if (ChnlValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Channel.');", false);
            //    isValid = false;
            //}

            //if (SubChnlValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Sub Channel.');", false);
            //    isValid = false;
            //}

            //if (MemTypeValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Member Type.');", false);
            //    isValid = false;
            //}
            //int result = compareDates(DateTime.Now.ToString("dd/MM/yyyy"), EffDteValue);
            //if (result > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Effective Date cannot be less than today.');", false);
            //    isValid = false;
            //}

            if (CeDteValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Cease Date.');", false);
                isValid = false;
            }

            if (CeDteValue != "")
            {
                int result1 = compareDates(EffDteValue, CeDteValue);
                if (result1 > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "customeAlert('Please select correct cease date.')", true);
                    isValid = false;
                }
            }
            if (isValid)
            {
                Hashtable ht = new Hashtable();
                ht.Add("@KPI_CODE", KPI_CODE);
                ht.Add("@BIZSRC", ChnlValue);
                ht.Add("@CHNCLS", SubChnlValue);
                ht.Add("@MEMTYPE", MemTypeValue);
                ht.Add("@STATUS", StatusValue);
                ht.Add("@EFF_DTIM", EffDteValue);
                ht.Add("@CSE_DTIM", CeDteValue);
                ht.Add("@UPDATEDBY", Session["UserID"].ToString().Trim());

                DataSet ds = new DataSet();
                ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_INSChnlMappDetails", ht);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully.')", true);
                grvaddedresult.EditIndex = -1;
                BindActionGrid();
            }
            grvaddedresult.AllowSorting = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnUpdate_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            grvaddedresult.EditIndex = -1;
            grvaddedresult.AllowSorting = true;
            BindActionGrid();
            
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnDeleteGrdRcrd_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string KPICODE = ((Label)row.FindControl("lblChnlMapId")).Text.ToString().Trim();
            Hashtable ht = new Hashtable();
            ht.Add("@KPI_CODE", KPICODE);
            ht.Add("@UPDATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            DataSet ds = new DataSet();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_INSChnlMappDetails", ht);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Deleted successfully.');", true);
            grvaddedresult.EditIndex = -1;
            BindActionGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnnextChnlMap_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = grvaddedresult.PageIndex;
            grvaddedresult.PageIndex = pageIndex + 1;
            BindActionGrid();
            txtPageChnlMap.Text = Convert.ToString(Convert.ToInt32(txtPageChnlMap.Text) + 1);
            btnpreviousChnlMap.Enabled = true;
            if (txtPageChnlMap.Text == Convert.ToString(grvaddedresult.PageCount))
            {
                btnnextChnlMap.Enabled = false;
            }
            int page = grvaddedresult.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnnextChnlMap_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnpreviousChnlMap_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = grvaddedresult.PageIndex;
            grvaddedresult.PageIndex = pageIndex - 1;
            BindActionGrid();
            txtPageChnlMap.Text = Convert.ToString(Convert.ToInt32(txtPageChnlMap.Text) - 1);
            if (txtPageChnlMap.Text == "1")
            {
                btnpreviousChnlMap.Enabled = false;
            }
            else
            {
                btnpreviousChnlMap.Enabled = true;
            }
            btnnextChnlMap.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnpreviousChnlMap_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    #region base and souce table definition
    #region Pagination event
    protected void btnBasePrev_Click(object sender, EventArgs e)
    {

    }

    protected void btnBaseKPIPrev_Click(object sender, EventArgs e)
    {

    }

    protected void btnBaseKPINext_Click(object sender, EventArgs e)
    {

    }

    protected void gvSrcTableKPIPrev_Click(object sender, EventArgs e)
    {

    }

    protected void gvSrcTableKPINext_Click(object sender, EventArgs e)
    {

    }

    protected void gvSrcTableALLNext_Click(object sender, EventArgs e)
    {

    }

    protected void gvSrcTableALLPrev_Click(object sender, EventArgs e)
    {

    }

    protected void btnBaseALLPrev_Click(object sender, EventArgs e)
    {

    }

    protected void btnBaseALLNext_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Binding of Table List
    public void BindAssignedbaseTables(string KPI_CODE, string SEARCHSTRING)
    {
        try
        {
            DataSet dsBase = GetAssignedTable(KPI_CODE, "B", SEARCHSTRING);
            gvBaseTableKPI.DataSource = dsBase;
            gvBaseTableKPI.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public void BindNotAssignedbaseTables(string KPI_CODE, string SEARCHSTRING)
    {
        try
        {
            DataSet dsBase = GetNotAssignedTable(KPI_CODE, "B", SEARCHSTRING);
            gvBaseTableALL.DataSource = dsBase;
            gvBaseTableALL.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public void BindAssignedSrcTables(string KPI_CODE, string SEARCHSTRING)
    {
        try
        {
            DataSet dsBase = GetAssignedTable(KPI_CODE, "S", SEARCHSTRING);
            gvSrcTableKPI.DataSource = dsBase;
            gvSrcTableKPI.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public void BindNotAssignedSrcTables(string KPI_CODE, string SEARCHSTRING)
    {
        try
        {
            DataSet dsBase = GetNotAssignedTable(KPI_CODE, "S", SEARCHSTRING);
            gvSrcTableALL.DataSource = dsBase;
            gvSrcTableALL.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public DataSet GetAssignedTable(string KPI_CODE, string TBL_TYP, string SEARCHSTRING)
    {
        DataSet dt = new DataSet();
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@TBL_TYP", TBL_TYP);
            ht.Add("@SEARCHSTRING", SEARCHSTRING);
            dt = objDal.GetDataSetForPrc("Prc_GetTablesByKPI", ht);
        }
        catch (Exception ex)
        {

        }
        return dt;

    }

    public DataSet GetNotAssignedTable(string KPI_CODE, string TBL_TYP, string SEARCHSTRING)
    {
        DataSet dt = new DataSet();
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@TBL_TYP", TBL_TYP);
            ht.Add("@SEARCHSTRING", SEARCHSTRING);
            dt = objDal.GetDataSetForPrc("Prc_GetTablesNotAddedforKPI", ht);
        }
        catch (Exception ex)
        {

        }
        return dt;

    }

    #endregion

    protected void btnAddSrc_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> table_ids = new List<string>();
            string Seperator = "|";
            for (int i = 0; i < gvSrcTableALL.Rows.Count; i++)
            {
                CheckBox chk = (gvSrcTableALL.Rows[i]).FindControl("chkSelector") as CheckBox;
                if (chk.Checked)
                {
                    table_ids.Add(Convert.ToString(gvSrcTableALL.DataKeys[i]["OBJ_ID"]));
                }
            }
            SaveTablesForKPIS(txtKPICode.Text.Trim(), String.Join(Seperator, table_ids), Seperator);
            BindAssignedSrcTables(txtKPICode.Text.Trim(), "");
            BindNotAssignedSrcTables(txtKPICode.Text.Trim(), "");
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnAddBase_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                List<string> table_ids = new List<string>();
                string Seperator = "|";
                for (int i = 0; i < gvBaseTableALL.Rows.Count; i++)
                {
                    CheckBox chk = (gvBaseTableALL.Rows[i]).FindControl("chkSelector") as CheckBox;
                    if (chk.Checked)
                    {
                        table_ids.Add(Convert.ToString(gvBaseTableALL.DataKeys[i]["OBJ_ID"]));
                    }
                }
                SaveTablesForKPIS(txtKPICode.Text.Trim(), String.Join(Seperator, table_ids), Seperator);

                BindAssignedbaseTables(txtKPICode.Text.Trim(), "");
                BindNotAssignedbaseTables(txtKPICode.Text.Trim(), "");
            }
            catch (Exception ex)
            {

            }
        }
        catch (Exception ex)
        {

        }
    }

    //TODO : need to develop search functionality start
    protected void btnBaseAllSearch_Click(object sender, EventArgs e)
    {
        BindAssignedbaseTables(txtKPICode.Text.Trim(), txtBaseAll.Text.Trim());
    }

    protected void btnBaseKPISearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindAssignedbaseTables(txtKPICode.Text.Trim(), txtBaseKPI.Text.Trim());
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSrcAllSearch_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSrcKPISearch_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    //TODO : need to develop search functionality start

    public void SaveTablesForKPIS(string KPI_CODE, string TABLELIST, string @SEPERATOR)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@TABLELIST", TABLELIST);
            ht.Add("@CREATEDBY", Convert.ToString(Session["UserID"]));
            ht.Add("@SEPERATOR", @SEPERATOR);
            objDal.GetDataSetForPrc("PRC_InsTablesForKPI", ht);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "SaveTablesForKPIS", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void lnkBaseBtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string OBJ_ID = Convert.ToString(gvBaseTableKPI.DataKeys[row.RowIndex]["OBJ_ID"]);
            InactiveTableAssignedForKPI(txtKPICode.Text, OBJ_ID);
            BindAssignedbaseTables(txtKPICode.Text.Trim(), "");
            BindNotAssignedbaseTables(txtKPICode.Text.Trim(), "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkBaseBtnDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkSrcBtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string OBJ_ID = Convert.ToString(gvSrcTableKPI.DataKeys[row.RowIndex]["OBJ_ID"]);
            InactiveTableAssignedForKPI(txtKPICode.Text, OBJ_ID);
            BindAssignedSrcTables(txtKPICode.Text.Trim(), "");
            BindNotAssignedSrcTables(txtKPICode.Text.Trim(), "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkSrcBtnDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void InactiveTableAssignedForKPI(string KPI_CODE, string OBJ_ID)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@OBJ_ID", OBJ_ID);
            ht.Add("@UPDATEDBY", Convert.ToString(Session["UserID"]));
            objDal.GetDataSetForPrc("PRC_DelTableAssignedForKPI", ht);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "InactiveTableAssignedForKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
                ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "Fillddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void btnSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string BIZSRC = (row.FindControl("lblChnl") as Label).Text;
            string SUBCHNL = (row.FindControl("lblSubChnl") as Label).Text;
            string MEMTYPE = (row.FindControl("lblMemType") as Label).Text;
            string flag = "1";
            string KPI_CODE = String.Join("", txtKPICode.Text.Split(new char[] { '-' }));
            string mapcode = SaveKPI_MAP_Details(BIZSRC, SUBCHNL, MEMTYPE, KPI_CODE, "2002");
            string url = "~/Application/Isys/Saim/RuleSetPages/FFContestPageStdDef.aspx?";
            url += "role=admin&flag=" + flag + "&KpiCode=" + KPI_CODE + "&mapcode=" + mapcode;
            Response.Redirect(url, false);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public string SaveKPI_MAP_Details(string channel, string subchnl, string memtype, string kpi, string flag)
    {
        string mapcode = "";
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("BIZSRC", channel);
            ht.Add("CHNCLS", subchnl);
            ht.Add("MEMTYPE", memtype);
            ht.Add("KPI_CODE", kpi);
            ht.Add("FLAG", flag);
            ht.Add("CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            DataSet ds = objDal.GetDataSetForPrc("PRC_Ins_MST_STDDEFNTN", ht);
            mapcode = Convert.ToString(ds.Tables[0].Rows[0][0]);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "SaveKPI_MAP_Details", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return mapcode;
    }

    public int compareDates(string date1, string date2)
    {
        int d = 0;
        try
        {
            DateTime d1 = DateTime.ParseExact(date1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            d = DateTime.Compare(d1, d2);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPISetup", "compareDates", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return d;
    }

    public void ResetChnlMap()
    {
        ddlChannel.SelectedIndex = 0;
        ddlSubChannel.SelectedIndex = 0;
        ddlMemType.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        lstChannel.ClearSelection();
        lstSubChnl.ClearSelection();
        lstMemType.ClearSelection();
        txtEfDate.Attributes.Remove("readonly");
        txtCeDate.Attributes.Remove("readonly");
        txtEfDate.Text = "";
        txtCeDate.Text = "";
        txtEfDate.Attributes.Add("readonly", "readonly");
        txtCeDate.Attributes.Add("readonly", "readonly");
    }
    protected void grvaddedresult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grvaddedresult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            
        }
    }

    //Added BY Pratik For Multi Select

    protected void funchnlpopup(ListBox ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_getchannels", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
          //  ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "KPISetup", "funchnlpopup", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lstChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listSelected = lstChannel.GetSelectedIndices();
            string[] Channels = listSelected.Select(x => lstChannel.Items[x].Value).ToArray();
            Hashtable htparam = new Hashtable();
            htparam.Add("@BIZSRC", String.Join(",", Channels));
            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_SUB_CHNL_FOR_MUL_CHNL", htparam);
            lstSubChnl.Items.Clear();
            lstMemType.Items.Clear();
            if (dtRead.HasRows)
            {
                lstSubChnl.DataSource = dtRead;
                lstSubChnl.DataTextField = "paramdesc";
                lstSubChnl.DataValueField = "paramval";
                lstSubChnl.DataBind();
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
            objErr.LogErr("ISYS-RGIC", "KPISetup", "lstChannel_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lstSubChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int[] listChnSelected = lstChannel.GetSelectedIndices();
            int[] listChnClsSelected = lstSubChnl.GetSelectedIndices();

            string[] Channels = listChnSelected.Select(x => lstChannel.Items[x].Value).ToArray();
            string[] SubChannels = listChnClsSelected.Select(x => lstSubChnl.Items[x].Value).ToArray();

            Hashtable htparam = new Hashtable();
            htparam.Add("@BIZSRC", String.Join(",", Channels));
            htparam.Add("@CHNCLS", String.Join(",", SubChannels));

            lstMemType.Items.Clear();

            SqlDataReader dtRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_MEM_TYPE_FOR_MUL_CHNL", htparam);
            if (dtRead.HasRows)
            {
                lstMemType.DataSource = dtRead;
                lstMemType.DataTextField = "paramdesc";
                lstMemType.DataValueField = "paramval";
                lstMemType.DataBind();
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
            objErr.LogErr("ISYS-RGIC", "KPISetup", "lstSubChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lstMemType_SelectedIndexChanged(object sender, EventArgs e)
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
            objErr.LogErr("ISYS-RGIC", "KPISetup", "lstMemType_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        try
        {
            int[] listChnSelected = lstChannel.GetSelectedIndices();
            int[] listChnClsSelected = lstSubChnl.GetSelectedIndices();
            int[] listMemTypeSelected = lstMemType.GetSelectedIndices();

            string Channels = String.Join(",",listChnSelected.Select(x => lstChannel.Items[x].Value).ToArray());
            string SubChannels = String.Join(",", listChnClsSelected.Select(x => lstSubChnl.Items[x].Value).ToArray());
            string memtype = String.Join(",", listMemTypeSelected.Select(x => lstMemType.Items[x].Value).ToArray());
            string kpi = String.Join("", txtKPICode.Text.Split(new char[] { '-' }));

            DataSet dsNew = CheckChannelBulkMapExits(kpi, Channels, SubChannels, memtype);

            if (dsNew.Tables[0].Rows.Count == 0)
            {
                Hashtable ht = new Hashtable();
                DataSet ds = new DataSet();
                ht.Add("@KPI_CODE", kpi);
                ht.Add("@BIZSRC", Channels);
                ht.Add("@CHNCLS", SubChannels);
                ht.Add("@MEMTYPE", memtype);
                ht.Add("@STATUS", ddlStatus.SelectedValue.ToString().Trim());
                ht.Add("@EFF_DTIM", txtEfDate.Text.ToString().Trim());
                ht.Add("@CSE_DTIM", txtCeDate.Text.ToString().Trim());
                ht.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_CHN_CHNCHLS_MEMCODE_BULK", ht);
                grvaddedresult.EditIndex = -1;
                BindActionGrid();
                ResetChnlMap();
            }
            else
            {
                string ss = "Below Mapping Already Exist :";
                for (int i = 0; i < dsNew.Tables[0].Rows.Count; i++)
                {
                    ss += String.Format("\\n {0}. {1} - {2} - {3} ", (i+1), Convert.ToString(dsNew.Tables[0].Rows[i]["ChnDesc"]), Convert.ToString(dsNew.Tables[0].Rows[i]["chnClsDesc"]), Convert.ToString(dsNew.Tables[0].Rows[i]["MemDesc"]));
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+ ss + "');", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CheckChannelBulkMapExits(string KPI_CODE, string channel, string subchnl, string memtype)
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@KPI_CODE", KPI_CODE);
        ht.Add("@BIZSRC", channel);
        ht.Add("@CHNCLS", subchnl);
        ht.Add("@MEMTYPE", memtype);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_CHK_CHN_CHNCLS_MEM_MAP_EXISTS", ht);
        return ds;
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPISetup.aspx?flag=E&KPICode=" + txtKPICode.Text, false);
    }
}
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
using System.Drawing;

public partial class Application_ISys_Saim_KPISetup : BaseClass
{
    private List<string> ControlsList
    {
        get
        {
            if (ViewState["controls"] == null)
            {
                ViewState["controls"] = new List<string>();
            }
            return (List<string>)ViewState["controls"];
        }
    }
    private int NextID
    {
        get
        {
            return ControlsList.Count + 1;
        }
    }
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        int countpost = 1;
        foreach (string bID in ControlsList)
        {
            Button b = new Button();
            b.ID = bID;
            b.Text = bID;
            b.Attributes.Add("Onclick", "return addDigit(this)");
            b.BackColor = System.Drawing.Color.Transparent;
            b.BorderWidth = 1;
            if (countpost % 5 == 1 && countpost != 1)
            {
                pnladdbtn.Controls.Add(new LiteralControl("<br/>"));
                pnladdbtn.Controls.Add(b);
            }
            else
            {
                pnladdbtn.Controls.Add(b);
            }
            b.Width = 40;
            b.Height = 30;
            countpost++;
        }
    }
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    int index;
    DropDownList ddlGrdChnl, ddlGrdSubChnl, ddlGrdMemType, ddlGrdStatus;
    //Added by Abuzar
    private int n;
    int num;
    //Added by Abuzar


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
            ddlStatus.SelectedIndex = 1;
            ddlStatus.Enabled = false;
            //Added by Abuzar Starts
            divsrcbsetbldefhdrcollapse.Visible = false;
            divdefdattyphdrcollapse.Visible = false;
            divdefaccdatsynloghdrcollapse.Visible = false;
            divforcalhdrcollapse.Visible = false;
            divdefacccycloghdrcollapse.Visible = false;
            BindddlStatus(ddldefstddeftypsta);
            ddldefstddeftypsta.SelectedIndex = 1;
            ddldefstddeftypsta.Enabled = false;
            txteffdtdefstdtyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txteffdtdefstdtyp.Enabled = false;
            divdefstddeftyphdrcollapse.Visible = false;
            txtEfDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEfDate.Enabled = false;
            //Added by Abuzar Ends
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
                    rdDefproclog1.Checked = true;
                    //btnSave.Attributes.Add("onclick", "javascript:return validate();");
                }
                else if (Request.QueryString["flag"].ToString().Trim() == "E")
                {
                    btnCancel.Visible = false;
                    btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
                    FillKPIDetails();
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ScrollTo", "var needScroll = true;", true);
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
        Checkforstddef();
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
        if (rdDefproclog.Checked == false && rdDefproclog1.Checked == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please check atleast one Option from Define Processing Logic ');", true);
            return;

        }
        else
        {
            if (rdDefproclog.Checked == true)
            {
                htParam.Add("@Defproclog", "1");
            }

            if (rdDefproclog1.Checked == true)
            {
                htParam.Add("@Defproclog", "0");
            }
        }
        htParam.Add("@Procnme", txtattchproc.Text.ToString().Trim());
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
                String defproclog = ds.Tables[0].Rows[0]["DFN_PRCSG_LGC"].ToString().Trim();
                String kpiaccumlgcsu = ds.Tables[0].Rows[0]["KPI_ACCUM_LOGIC_SU"].ToString().Trim();
                txtattchproc.Text = ds.Tables[0].Rows[0]["PRCSR_NAME"].ToString().Trim();
                txtformuladiv.Text= ds.Tables[0].Rows[0]["KPI_ACCR_LOGIC_SU"].ToString().Trim();
                txtattchproc.Enabled = false;
                string fname = "kmiadmin";
                if (defproclog == "1")
                {
                    //if (HttpContext.Current.Session["UserID"].ToString().Trim() == "kmiadmin")
                    if (HttpContext.Current.Session["UserID"].ToString().Trim().Equals(fname, StringComparison.OrdinalIgnoreCase))
                    {
                        rdDefproclog.Checked = true;
                        divsrcbsetbldefhdrcollapse.Visible = true;
                        divdefdattyphdrcollapse.Visible = true;
                        divdefaccdatsynloghdrcollapse.Visible = true;
                        divforcalhdrcollapse.Visible = true;
                        divdefacccycloghdrcollapse.Visible = true;
                        lblSynonnyms.Text = "1. Do you need to create a Synonyms";
                        lblSrctbl.Text = "2. Do you need to create a Source Table";
                        lblmapsyntosrc.Text = "3. Do you need to map a Synonyms to a Source Table";
                        Label35.Text = "4. Create a Base Table";
                        Label34.Text = "5. Map a Base Table to a Source Table";
                        bindddltblnam(ddltblnam);
                        Getdattypdata(dgdattyp);
                        bindddlstddeftyp(ddllblStddeftyp);
                        Getstddeftypdata(dgstddeftyp);
                        bindddltemplate(ddltemplate);
                        bindlstdefgrpbsdcol(lstdefgrpbsdcol);
                        bindlstgrpcolnam(lstgrpcolnam);
                        bindddlwhrconcolnam(ddlwhrconcolnam);
                        ViewState["Count"] = 0;
                        ViewState["Count1"] = 0;
                        bindddlgrpcond(ddlgrpcond);
                        bindddlOprtr(ddlOprtr);
                        getdgdefaccdatsynlog(dgdefaccdatsynlog);
                        getdgwhrcnd(dgwhrcnd);
                        if (kpiaccumlgcsu == "")
                        {
                            bindddltemplatebind(ddltemplatebind);
                        }
                        else
                        {
                            bindddltemplatebind(ddltemplatebind);
                            ddltemplatebind.SelectedValue = kpiaccumlgcsu;
                            //ddltemplatebind.Enabled = false;
                            if (kpiaccumlgcsu.ToString().Trim() == "201")
                            {
                                lbldefacccyclog.Text = "Consider All Accrual Cycle";
                            }
                            else
                            {
                                lbldefacccyclog.Text = "Consider Last Accrual Cycle";
                            }
                        }
                        bindddltemplatebind(ddltemplatebind);
                        btn0.Enabled = false; btn1.Enabled = false; btn2.Enabled = false; btn3.Enabled = false; btn5.Enabled = false; btn6.Enabled = false; btn7.Enabled = false;
                        btn8.Enabled = false; btn9.Enabled = false; btnMinus.Enabled = false; btnperc.Enabled = false; btnPlus.Enabled = false; btnequla.Enabled = false;
                        Buttonmul.Enabled = false; btn4.Enabled = false;
                        ddlcolnam.Items.Insert(0, new ListItem("SELECT", ""));
                        txteffdefdttyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txteffdefdttyp.Enabled = false;
                        BindddlStatus(ddldattypsta);
                        ddldattypsta.SelectedIndex = 1;
                        ddldattypsta.Enabled = false;
                        BindddlStatus(ddldefstddeftypsta);
                        ddldefstddeftypsta.SelectedIndex = 1;
                        ddldefstddeftypsta.Enabled = false;
                        txteffdtdefstdtyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txteffdtdefstdtyp.Enabled = false;
                        BindddlStatus(ddlaccrualwhrsta);
                        ddlaccrualwhrsta.SelectedIndex = 1;
                        ddlaccrualwhrsta.Enabled = false;
                        BindddlStatus(ddldefaccruallogsta);
                        ddldefaccruallogsta.Enabled = false;
                        ddldefaccruallogsta.SelectedIndex = 1;
                        txteffdtdefaccruallog.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txteffdtaccrualwhr.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txteffdtdefaccruallog.Enabled = false;
                        txteffdtaccrualwhr.Enabled = false;
                        ddlwhrconcolnam.Enabled = false;
                        ddlOprtr.Enabled = false;
                        txtwhrconcolval.Enabled = false;
                        lnkbtnfrtcolparamadd.Enabled = false;
                        lnkbtnfrtcolparamclr.Enabled = false;
                        lnkbtnfrtcolparamgen.Enabled = false;
                        divdefstddeftyphdrcollapse.Visible = true;
                        bindddlstddeftyp(ddllblStddeftyp);
                        Getstddeftypdata(dgstddeftyp);
                    }
                    else
                    {
                        rdDefproclog.Checked = true;
                        div4.Visible = true;
                    }
                    txtEfDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtEfDate.Enabled = false;
                }
                else
                {
                    if (HttpContext.Current.Session["UserID"].ToString().Trim() == "kmiadmin")
                    {
                        BindddlStatus(ddldefstddeftypsta);
                        ddldefstddeftypsta.SelectedIndex = 1;
                        ddldefstddeftypsta.Enabled = false;
                        txteffdtdefstdtyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txteffdtdefstdtyp.Enabled = false;
                        divdefstddeftyphdrcollapse.Visible = true;
                        rdDefproclog1.Checked = true;
                        bindddlstddeftyp(ddllblStddeftyp);
                        Getstddeftypdata(dgstddeftyp);
                    }
                    else
                    {
                        rdDefproclog1.Checked = true;
                        div4.Visible = true;
                    }
                    txtEfDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtEfDate.Enabled = false;
                }
                rdDefproclog.Enabled = false;
                rdDefproclog1.Enabled = false;
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
        ddlStatus.SelectedIndex = 1;
        ddlStatus.Enabled = false;
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
            txtEfDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEfDate.Enabled = false;
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
        //txtEfDate.Text = "";
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
            //DataSet ds = objDal.GetDataSetForPrc("PRC_Ins_MST_STDDEFNTN", ht);
            DataSet ds = objDal.GetDataSetForPrc_SAIM("PRC_Ins_MST_STDDEFNTN", ht);
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
    //Added By Abuzar Starts

    //protected void btnnewpage_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("KPIMapBseSrc.aspx?KPICode=" + txtKPICode.Text, false);
    //}

    protected void Getdattypdata(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DAT_TYP_DATA", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (dgdattyp.PageCount > 1)
                    {
                        btnnextdattyp.Enabled = true;
                        btnpreviousdattyp.Enabled = false;
                    }
                    else
                    {
                        btnnextdattyp.Enabled = false;
                        btnpreviousdattyp.Enabled = false;
                    }

                }
                else
                {
                    DataTable dt = ds.Tables[0];
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "Getdattypdata", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnpreviousdattyp_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgdattyp.PageIndex;
            dgdattyp.PageIndex = pageIndex - 1;
            Getdattypdata(dgdattyp);
            txtpgdattyp.Text = Convert.ToString(Convert.ToInt32(txtpgdattyp.Text) - 1);
            if (txtpgdattyp.Text == "1")
            {
                btnpreviousdattyp.Enabled = false;
            }
            else
            {
                btnpreviousdattyp.Enabled = true;
            }
            btnnextdattyp.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnpreviousdattyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextdattyp_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgdattyp.PageIndex;
            dgdattyp.PageIndex = pageIndex + 1;
            Getdattypdata(dgdattyp);
            txtpgdattyp.Text = Convert.ToString(Convert.ToInt32(txtpgdattyp.Text) + 1);
            btnpreviousdattyp.Enabled = true;
            if (txtpgdattyp.Text == Convert.ToString(dgdattyp.PageCount))
            {
                btnnextdattyp.Enabled = false;
            }
            int page = dgdattyp.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnnextdattyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddltblnam(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_KPISETUP_TBLNAM", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "SRC_TBL_ID";
                ddl.DataValueField = "OBJ_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddltblnam", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSavedattyp_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            if (btnAdddattyp.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                //string code = string.Empty;
                //Session["DATTYPCOD"] = code;
                string code1 = (string)(Session["DATTYPCOD"]);
                ht.Add("@CODE1", code1.ToString().Trim());
                if (String.IsNullOrEmpty(txtdattypdesc.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Date Type description');", true);
                    return;

                }
                else
                {
                    ht.Add("@DAT_TYP_DESC", txtdattypdesc.Text);
                }
                if (ddltblnam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Table name');", true);
                    return;

                }
                else
                {
                    ht.Add("@OBJ_ID", ddltblnam.SelectedValue.ToString().Trim());
                }

                if (ddlcolnam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select column name');", true);
                    return;

                }
                else
                {
                    ht.Add("@COL_NAM", ddlcolnam.SelectedValue.ToString().Trim());
                }
                if (txtcsedttyp.Text.ToString() == "")
                {

                    ht.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    ht.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedttyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedttyp.Text.ToString() != "")
                {

                    if (ddldattypsta.SelectedIndex != 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select inactive as status');", true);
                        return;
                    }
                    else
                    {
                        ht.Add("@STATUS", ddldattypsta.SelectedValue.ToString().Trim());
                    }
                }
                else
                {
                    if (ddldattypsta.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Status');", true);
                        return;
                    }
                    else
                    {
                        ht.Add("@STATUS", ddldattypsta.SelectedValue.ToString().Trim());
                    }
                }
                ht.Add("@UPDATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                ht.Add("@FLAG", "U");

            }
            else
            {
                if (String.IsNullOrEmpty(txtdattypdesc.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Date Type description');", true);
                    return;

                }
                else
                {
                    ht.Add("@DAT_TYP_DESC", txtdattypdesc.Text);
                }
                if (ddltblnam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Table name');", true);
                    return;

                }
                else
                {
                    ht.Add("@OBJ_ID", ddltblnam.SelectedValue.ToString().Trim());
                }

                if (ddlcolnam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select column name');", true);
                    return;

                }
                else
                {
                    ht.Add("@COL_NAM", ddlcolnam.SelectedValue.ToString().Trim());
                }
                if (String.IsNullOrEmpty(txteffdefdttyp.Text.Trim().ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date');", true);
                    return;

                }
                else
                {
                    ht.Add("@EFF_DTIM", Convert.ToDateTime(txteffdefdttyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedttyp.Text.ToString() == "")
                {

                    ht.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    ht.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedttyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (ddldattypsta.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                    return;

                }
                else
                {
                    ht.Add("@STATUS", ddldattypsta.SelectedValue.ToString().Trim());
                }
                ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                ht.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
                ht.Add("@FLAG", "A");
            }
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_DATETYPE_SU", ht);
            if (ds.Tables.Count > 0)
            {
                string msg1 = string.Empty;
                msg1 = ds.Tables[0].Rows[0]["MESSAGE"].ToString().Trim();
                if (msg1 == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date Type Description already exits');", true);
                    return;
                }
            }
            else
            {
                if (btnAdddattyp.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully saved the record');", true);
                    Getdattypdata(dgdattyp);
                    bindddltblnam(ddltblnam);
                    ddlcolnam.ClearSelection();
                    txtdattypdesc.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Updated the record');", true);
                    btnAdddattyp.Text = "<span class='glyphicon glyphicon-plus BtnGlyphicon' style='color: White;'></span>  Add";
                    txteffdefdttyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtdattypdesc.Text = "";
                    Getdattypdata(dgdattyp);
                    bindddltblnam(ddltblnam);
                    ddlcolnam.ClearSelection();
                    txtcsedttyp.Text = "";
                    txtcsedttyp.Enabled = false;
                    BindddlStatus(ddldattypsta);
                    ddldattypsta.SelectedIndex = 1;
                    ddldattypsta.Enabled = false;
                }
            }



        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnSavedattyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindddlstddeftyp(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_KPISETUP_STDEFTYP", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "ACT_TYP_DSC";
                ddl.DataValueField = "ACT_TYP_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddlstddeftyp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSavestddeftyp_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            if (btnsavestddeftyp.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                string ssdt = (string)(Session["ssdt"]);
                string skpi = (string)(Session["skpi"]);
                ht.Add("@ACT_TYP", ssdt.ToString().Trim());
                ht.Add("@UKPICODEDATTYP", skpi.ToString().Trim());
                if (ddlbsdontbltyp.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Based on Table type');", true);
                    return;

                }
                else
                {
                    ht.Add("@BSD_TBL_TYP", ddlbsdontbltyp.SelectedValue.ToString().Trim());
                }
                if (txtcsedtdefstdtyp.Text.ToString() == "")
                {

                    ht.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    ht.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedtdefstdtyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedtdefstdtyp.Text.ToString() != "")
                {

                    if (ddldefstddeftypsta.SelectedIndex != 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select inactive as status');", true);
                        return;
                    }
                    else
                    {
                        ht.Add("@STATUS", ddldefstddeftypsta.SelectedValue.ToString().Trim());
                    }
                }
                else
                {
                    if (ddldefstddeftypsta.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Status');", true);
                        return;
                    }
                    else
                    {
                        ht.Add("@STATUS", ddldefstddeftypsta.SelectedValue.ToString().Trim());
                    }
                }
                ht.Add("@UPDATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                ht.Add("@FLAG", "U");
            }
            else
            {
                if (ddllblStddeftyp.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select standard definition type');", true);
                    return;

                }
                else
                {
                    ht.Add("@STD_DEF_TYP", ddllblStddeftyp.SelectedValue.ToString().Trim());
                }
                if (ddlbsdontbltyp.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Based on Table type');", true);
                    return;

                }
                else
                {
                    ht.Add("@BSD_TBL_TYP", ddlbsdontbltyp.SelectedValue.ToString().Trim());
                }
                if (String.IsNullOrEmpty(txteffdtdefstdtyp.Text.Trim().ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date');", true);
                    return;

                }
                else
                {
                    ht.Add("@EFF_DTIM", Convert.ToDateTime(txteffdtdefstdtyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedtdefstdtyp.Text.ToString() == "")
                {

                    ht.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    ht.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedtdefstdtyp.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (ddldefstddeftypsta.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                    return;

                }
                else
                {
                    ht.Add("@STATUS", ddldefstddeftypsta.SelectedValue.ToString().Trim());
                }

                ht.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                ht.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
                ht.Add("@FLAG", "A");
            }
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_STD_DEF_SCOPE_DTLS", ht);

            if (btnsavestddeftyp.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "confPromptBox();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Added the record');", true);
                Getstddeftypdata(dgstddeftyp);
                ddllblStddeftyp.ClearSelection();
                ddlbsdontbltyp.ClearSelection();
                bindddlstddeftyp(ddllblStddeftyp);
                BindActionGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Updated the record');", true);
                btnsavestddeftyp.Text = "<span class='glyphicon glyphicon-plus BtnGlyphicon' style='color: White;'></span>  Add";
                txteffdtdefstdtyp.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Getstddeftypdata(dgstddeftyp);
                bindddlstddeftyp(ddllblStddeftyp);
                ddllblStddeftyp.Enabled = true;
                ddlbsdontbltyp.ClearSelection();
                txtcsedtdefstdtyp.Text = "";
                txtcsedtdefstdtyp.Enabled = false;
                BindddlStatus(ddldefstddeftypsta);
                ddldefstddeftypsta.SelectedIndex = 1;
                ddldefstddeftypsta.Enabled = false;
            }


        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnSavestddeftyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void Getstddeftypdata(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_STD_DEF_SCOPE_DTLS", htParam);
            dg.DataSource = ds;
            dg.DataBind();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "Getstddeftypdata", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void rdSynonnyms_CheckedChanged(object sender, EventArgs e)
    {

        if (rdSynonnyms.Checked)
        {
            lnkcrtsyn.Enabled = true;
        }
        else
        {
            lnkcrtsyn.Enabled = false;
        }
    }
    protected void lnkcrtsyn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/Isys/Saim/Masters/MstSynonym.aspx", false);
    }
    protected void rdSrctbl_CheckedChanged(object sender, EventArgs e)
    {

        if (rdSrctbl.Checked)
        {
            lnkcrtsrctbl.Enabled = true;
        }
        else
        {
            lnkcrtsrctbl.Enabled = false;
        }
    }
    protected void lnkcrtsrctbl_Click(object sender, EventArgs e)
    {
        Response.Redirect("Defbassrctbl.aspx?Flag=S&KPICode=" + txtKPICode.Text, false);
    }
    protected void lnkcrtbsetbl_Click(object sender, EventArgs e)
    {
        Response.Redirect("Defbassrctbl.aspx?Flag=B&KPICode=" + txtKPICode.Text, false);
    }
    protected void rdmapsyntosrc_CheckedChanged(object sender, EventArgs e)
    {

        if (rdmapsyntosrc.Checked)
        {
            lnkmapsyntosrc.Enabled = true;
        }
        else
        {
            lnkmapsyntosrc.Enabled = false;
        }
    }
    protected void lnkmapbsesrctbl_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPIMapBseSrc.aspx?KPICode=" + txtKPICode.Text, false);
    }
    public void bindddltemplate(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_TEMP");
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
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddltemplate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindlstdefgrpbsdcol(ListBox lst)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_LST_COL_GRP", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DataTextField = "COL_DESC";
                lst.DataValueField = "COL_NAM";
                lst.DataBind();
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindlstdefgrpbsdcol", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindlstgrpcolnam(ListBox lst)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_LST_COL_GRP", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DataTextField = "COL_NAM";
                lst.DataValueField = "COL_NAM";
                lst.DataBind();
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "ddlgrpcolnam", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddlwhrconcolnam(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_LST_COL_GRP", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "COL_NAM";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddlwhrconcolnam", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkaccdatsynlog_Click(object sender, EventArgs e)
    {
        try
        {
            //string PRMTR =string.Empty;
            //string number=string.Empty;
            //string column= string.Empty;
            //int n = Int32.Parse(txtNoParam.Text);
            //for (int i = 1; i <= n; i++)
            //{
            //    PRMTR += "P" + i + ",";
            //    number += i + ",";
            //}
            //PRMTR=PRMTR.TrimEnd(',');
            //number= number.TrimEnd(',');
            //foreach (ListItem item in this.lstdefgrpbsdcol.Items)
            //{

            //    if (item.Selected)
            //    {
            //        column += item.Value + ",";
            //    }
            //}
            //column = column.TrimEnd(',');
            if (lnkaccdatsynlog.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
                if (ddltemplate.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Template');", true);
                    return;

                }
                if (String.IsNullOrEmpty(txtNoParam.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter No of Parameter');", true);
                    return;

                }
                if (lstdefgrpbsdcol.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Define Grouping based column');", true);
                    return;

                }
                if (ddlgrpcond.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Group Condition');", true);
                    return;

                }
                if (lstgrpcolnam.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Group Column Name');", true);
                    return;

                }
                insertdata();
                lstdefgrpbsdcol.ClearSelection();
                lstgrpcolnam.ClearSelection();
                ddltemplate.ClearSelection();
                txtNoParam.Text = "";
                ddlgrpcond.ClearSelection();
                txtcsedtdefaccruallog.Text = "";
                txtcsedtdefaccruallog.Enabled = false;
                txteffdtdefaccruallog.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txteffdtdefaccruallog.Enabled = false;
                BindddlStatus(ddldefaccruallogsta);
                ddldefaccruallogsta.SelectedIndex = 1;
                ddldefaccruallogsta.Enabled = false;
                lnkaccdatsynlog.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Save";
                btnClearaccdatsynlog.Enabled = true;
                ViewState["count"] = 0;
            }
            else
            {
                ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
                if (Convert.ToInt32(ViewState["count"]) == 1)
                {
                    if (ddltemplate.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Template');", true);
                        ViewState["count"] = 0;
                        return;

                    }
                    if (String.IsNullOrEmpty(txtNoParam.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter No of Parameter');", true);
                        ViewState["count"] = 0;
                        return;

                    }
                    if (lstdefgrpbsdcol.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Define Grouping based column');", true);
                        ViewState["count"] = 0;
                        return;

                    }
                    if (ddlgrpcond.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Group Condition');", true);
                        ViewState["count"] = 0;
                        return;

                    }
                    if (lstgrpcolnam.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Group Column Name');", true);
                        ViewState["count"] = 0;
                        return;

                    }
                    ViewState["count1"] = Int32.Parse(txtNoParam.Text);
                    insertdata();
                    if (Convert.ToInt32(ViewState["count1"]) == 1)
                    {
                        lnkaccdatsynlog.Enabled = false;
                        ddltemplate.Enabled = true;
                        txtNoParam.Enabled = true;
                        lstdefgrpbsdcol.ClearSelection();
                        lstgrpcolnam.ClearSelection();
                        ddltemplate.ClearSelection();
                        txtNoParam.Text = "";
                        ddlgrpcond.ClearSelection();
                        ViewState["count"] = 0;
                    }
                    else
                    {
                        ddltemplate.Enabled = false;
                        txtNoParam.Enabled = false;
                        lstdefgrpbsdcol.ClearSelection();
                        lstgrpcolnam.ClearSelection();
                        ddlgrpcond.ClearSelection();
                    }
                }
                else
                {
                    if (Convert.ToInt32(ViewState["count"]) < Convert.ToInt32(ViewState["count1"]))
                    {
                        if (lstdefgrpbsdcol.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Define Grouping based column');", true);
                            ViewState["count"] = Convert.ToInt32(ViewState["count"]) - 1;
                            return;

                        }
                        if (ddlgrpcond.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Group Condition');", true);
                            ViewState["count"] = Convert.ToInt32(ViewState["count"]) - 1;
                            return;

                        }
                        if (lstgrpcolnam.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select atleast one column from Group Column Name');", true);
                            ViewState["count"] = Convert.ToInt32(ViewState["count"]) - 1;
                            return;

                        }
                        insertdata();
                        ddltemplate.Enabled = false;
                        txtNoParam.Enabled = false;
                        lstdefgrpbsdcol.ClearSelection();
                        lstgrpcolnam.ClearSelection();
                        ddlgrpcond.ClearSelection();
                    }
                    else
                    {
                        insertdata();
                        lnkaccdatsynlog.Enabled = false;
                        ddltemplate.Enabled = true;
                        txtNoParam.Enabled = true;
                        lstdefgrpbsdcol.ClearSelection();
                        lstgrpcolnam.ClearSelection();
                        ddltemplate.ClearSelection();
                        txtNoParam.Text = "";
                        ddlgrpcond.ClearSelection();
                        ViewState["count"] = 0;
                    }
                }
            }

        }
        catch (Exception ex)
        {

            objErr.LogErr("ISYS-RGIC", "KPISetup", "lnkaccdatsynlog_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void insertdata()
    {
        try
        {
            string column = string.Empty;
            foreach (ListItem item in this.lstdefgrpbsdcol.Items)
            {

                if (item.Selected)
                {
                    column += item.Value + ",";
                }
            }
            string grpcolumn = string.Empty;
            foreach (ListItem item in this.lstgrpcolnam.Items)
            {

                if (item.Selected)
                {
                    grpcolumn += item.Value + ",";
                }
            }
            int num1 = Int32.Parse(txtNoParam.Text);
            column = column.TrimEnd(',');
            grpcolumn = grpcolumn.TrimEnd(',');
            int num = (int)(ViewState["count"]);
            ds.Clear();
            htParam.Clear();
            if (lnkaccdatsynlog.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                string Par1 = (string)(Session["Par"]);
                string akpi1 = (string)(Session["akpi"]);
                string defgrp1 = (string)(Session["defgrp"]);
                string grpcol1 = (string)(Session["grpcol"]);
                string tmplt1 = (string)(Session["tmplt"]);
                htParam.Add("@UPD_PRM", Par1.ToString().Trim());
                htParam.Add("@UPD_KPI", akpi1.ToString().Trim());
                htParam.Add("@UPD_DEF_GRP", defgrp1.ToString().Trim());
                htParam.Add("@UPD_GRP_COL", grpcol1.ToString().Trim());
                htParam.Add("@UPD_TMPLT", tmplt1.ToString().Trim());
            }
            htParam.Add("@GRP_BSE_COL", column.ToString().Trim());
            if (lnkaccdatsynlog.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                htParam.Add("@NO_OF_PRMTR", num.ToString().Trim());
            }
            else
            {
                htParam.Add("@NO_OF_PRMTR", num1.ToString().Trim());
            }
            htParam.Add("@COL", grpcolumn.ToString().Trim());
            htParam.Add("@TMPLT_ID", ddltemplate.SelectedValue.ToString().Trim());
            if (lnkaccdatsynlog.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                htParam.Add("@KPICODE", Request.QueryString["KPICode"].ToString().Trim());
            }
            htParam.Add("@GRP_CNDTN", ddlgrpcond.SelectedValue.ToString().Trim());
            if (String.IsNullOrEmpty(txteffdtdefaccruallog.Text.Trim().ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date');", true);
                return;

            }
            else
            {
                htParam.Add("@EFF_DTIM", Convert.ToDateTime(txteffdtdefaccruallog.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            if (txtcsedtdefaccruallog.Text.ToString() == "")
            {

                htParam.Add("@CSE_DTIM", DBNull.Value);

            }
            else
            {

                htParam.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedtdefaccruallog.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            if (lnkaccdatsynlog.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                if (txtcsedtdefaccruallog.Text.ToString() != "")
                {

                    if (ddldefaccruallogsta.SelectedIndex != 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select inactive as status');", true);
                        return;
                    }
                    else
                    {
                        htParam.Add("@STATUS", ddldefaccruallogsta.SelectedValue.ToString().Trim());
                    }
                }
                else
                {
                    if (ddldefaccruallogsta.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                        return;

                    }
                    else
                    {
                        htParam.Add("@STATUS", ddldefaccruallogsta.SelectedValue.ToString().Trim());
                    }
                }
            }
            else
            {
                if (ddldefaccruallogsta.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                    return;

                }
                else
                {
                    htParam.Add("@STATUS", ddldefaccruallogsta.SelectedValue.ToString().Trim());
                }
            }
            if (lnkaccdatsynlog.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                htParam.Add("@UPDATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@FLAG", "U");
            }
            else
            {
                htParam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@FLAG", "A");
            }
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_ACCR_LOGIC_SU", htParam);
            if (lnkaccdatsynlog.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                txtNoParam.Text = num.ToString().Trim();
            }
            if (lnkaccdatsynlog.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully saved the record');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Updated the record');", true);
            }
            getdgdefaccdatsynlog(dgdefaccdatsynlog);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "insertdata", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void getdgdefaccdatsynlog(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_ACCR_LOGIC_SU", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (dgdefaccdatsynlog.PageCount > 1)
                {
                    btnnextaccsyn.Enabled = true;
                    btnpreviousaccsyn.Enabled = false;
                }
                else
                {
                    btnnextaccsyn.Enabled = false;
                    btnpreviousaccsyn.Enabled = false;
                }

            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "getdgdefaccdatsynlog", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnpreviousaccsyn_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgdefaccdatsynlog.PageIndex;
            dgdefaccdatsynlog.PageIndex = pageIndex - 1;
            getdgdefaccdatsynlog(dgdefaccdatsynlog);
            txtbtnnextaccsyn.Text = Convert.ToString(Convert.ToInt32(txtbtnnextaccsyn.Text) - 1);
            if (txtbtnnextaccsyn.Text == "1")
            {
                btnpreviousaccsyn.Enabled = false;
            }
            else
            {
                btnpreviousaccsyn.Enabled = true;
            }
            btnnextaccsyn.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnpreviousaccsyn_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextaccsyn_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgdefaccdatsynlog.PageIndex;
            dgdefaccdatsynlog.PageIndex = pageIndex + 1;
            getdgdefaccdatsynlog(dgdefaccdatsynlog);
            txtbtnnextaccsyn.Text = Convert.ToString(Convert.ToInt32(txtbtnnextaccsyn.Text) + 1);
            btnpreviousaccsyn.Enabled = true;
            if (txtbtnnextaccsyn.Text == Convert.ToString(dgdefaccdatsynlog.PageCount))
            {
                btnnextaccsyn.Enabled = false;
            }
            int page = dgdefaccdatsynlog.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnnextaccsyn_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindddlgrpcond(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_GRP_CND");
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
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddlgrpcond", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void bindddlOprtr(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_DDL_OPRTR");
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
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddlOprtr", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lblParam_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnParam = (HiddenField)row.FindControl("hdnParam");
            lblParamnamVal.Text = hdnParam.Value.ToString().Trim();
            Session["Parameter"] = hdnParam.Value.ToString().Trim();
            ddlwhrconcolnam.Enabled = true;
            ddlOprtr.Enabled = true;
            txtwhrconcolval.Enabled = true;
            lnkbtnfrtcolparamadd.Enabled = true;
            lnkbtnfrtcolparamclr.Enabled = true;
            lnkbtnfrtcolparamgen.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lblParam_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkbtnfrtcolparamadd_Click(object sender, EventArgs e)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            if (lnkbtnfrtcolparamadd.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                string wPar1 = (string)(Session["wPar"]);
                string wcn1 = (string)(Session["wcn"]);
                string wco1 = (string)(Session["wco"]);
                string wcv1 = (string)(Session["wcv"]);
                htParam.Add("@PRMTR", wPar1.ToString().Trim());
                htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
                htParam.Add("@WHR_CNDTN_COL_NAME", wcn1.ToString().Trim());
                htParam.Add("@WHR_CNDTN_OPRT1", wco1.ToString().Trim());
                htParam.Add("@WHR_CNDTN_COL_VAL1", wcv1.ToString().Trim());
                if (ddlOprtr.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Operator');", true);
                    return;
                }
                else
                {
                    htParam.Add("@WHR_CNDTN_OPRT", ddlOprtr.SelectedValue.ToString().Trim());
                }
                if (String.IsNullOrEmpty(txtwhrconcolval.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Where condition column value');", true);
                    return;

                }
                else
                {
                    htParam.Add("@WHR_CNDTN_COL_VAL", txtwhrconcolval.Text);
                }
                if (txtcsedtaccrualwhr.Text.ToString() == "")
                {

                    htParam.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    htParam.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedtaccrualwhr.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedtaccrualwhr.Text.ToString() != "")
                {

                    if (ddlaccrualwhrsta.SelectedIndex != 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select inactive as status');", true);
                        return;
                    }
                    else
                    {
                        htParam.Add("@STATUS", ddlaccrualwhrsta.SelectedValue.ToString().Trim());
                    }
                }
                else
                {
                    if (ddlaccrualwhrsta.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                        return;

                    }
                    else
                    {
                        htParam.Add("@STATUS", ddlaccrualwhrsta.SelectedValue.ToString().Trim());
                    }
                }
                htParam.Add("@UPDATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@FLAG", "U");
            }
            else
            {
                string Parameter = (string)(Session["Parameter"]);
                htParam.Add("@PRMTR", Parameter.ToString().Trim());
                htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
                if (ddlwhrconcolnam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Where Condition column name');", true);
                    return;

                }
                else
                {
                    htParam.Add("@WHR_CNDTN_COL_NAME", ddlwhrconcolnam.SelectedValue.ToString().Trim());
                }
                if (ddlOprtr.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Operator');", true);
                    return;
                }
                else
                {
                    htParam.Add("@WHR_CNDTN_OPRT", ddlOprtr.SelectedValue.ToString().Trim());
                }
                if (String.IsNullOrEmpty(txtwhrconcolval.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Where condition column value');", true);
                    return;

                }
                else
                {
                    htParam.Add("@WHR_CNDTN_COL_VAL", txtwhrconcolval.Text);
                }
                if (String.IsNullOrEmpty(txteffdtaccrualwhr.Text.Trim().ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date');", true);
                    return;

                }
                else
                {
                    htParam.Add("@EFF_DTIM", Convert.ToDateTime(txteffdtaccrualwhr.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (txtcsedtaccrualwhr.Text.ToString() == "")
                {

                    htParam.Add("@CSE_DTIM", DBNull.Value);

                }
                else
                {

                    htParam.Add("@CSE_DTIM", Convert.ToDateTime(txtcsedtaccrualwhr.Text.Trim()).ToString("MM/dd/yyyy"));
                }
                if (ddlaccrualwhrsta.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status');", true);
                    return;

                }
                else
                {
                    htParam.Add("@STATUS", ddlaccrualwhrsta.SelectedValue.ToString().Trim());
                }
                htParam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@FLAG", "A");
            }
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            if (lnkbtnfrtcolparamadd.Text != "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully saved the record');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Updated the record');", true);
                lnkbtnfrtcolparamadd.Text = "<span class='glyphicon glyphicon-plus' style='color: White;'></span>  Add";
                lnkbtnfrtcolparamadd.Enabled = false;
                txtcsedtaccrualwhr.Text = "";
                txtcsedtaccrualwhr.Enabled = false;
                txteffdtaccrualwhr.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }
            ddlwhrconcolnam.ClearSelection();
            ddlwhrconcolnam.Enabled = false;
            ddlOprtr.ClearSelection();
            ddlOprtr.Enabled = false;
            BindddlStatus(ddlaccrualwhrsta);
            ddlaccrualwhrsta.SelectedIndex = 1;
            ddlaccrualwhrsta.Enabled = false;
            lblParamnamVal.Text = "";
            txtwhrconcolval.Text = "";
            txtwhrconcolval.Enabled = false;
            getdgwhrcnd(dgwhrcnd);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkbtnfrtcolparamadd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void getdgwhrcnd(GridView dg)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            dg.DataSource = ds;
            dg.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (dgwhrcnd.PageCount > 1)
                {
                    btnnextwhrcnd.Enabled = true;
                    btnpreviouswhrcnd.Enabled = false;
                }
                else
                {
                    btnnextwhrcnd.Enabled = false;
                    btnpreviouswhrcnd.Enabled = false;
                }

            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "getdgwhrcnd", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnpreviouswhrcnd_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgwhrcnd.PageIndex;
            dgwhrcnd.PageIndex = pageIndex - 1;
            getdgwhrcnd(dgwhrcnd);
            txtpagewhrcnd.Text = Convert.ToString(Convert.ToInt32(txtpagewhrcnd.Text) - 1);
            if (txtpagewhrcnd.Text == "1")
            {
                btnpreviouswhrcnd.Enabled = false;
            }
            else
            {
                btnpreviouswhrcnd.Enabled = true;
            }
            btnnextwhrcnd.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnpreviouswhrcnd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextwhrcnd_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgwhrcnd.PageIndex;
            dgwhrcnd.PageIndex = pageIndex + 1;
            getdgwhrcnd(dgwhrcnd);
            txtpagewhrcnd.Text = Convert.ToString(Convert.ToInt32(txtpagewhrcnd.Text) + 1);
            btnpreviouswhrcnd.Enabled = true;
            if (txtpagewhrcnd.Text == Convert.ToString(dgwhrcnd.PageCount))
            {
                btnnextwhrcnd.Enabled = false;
            }
            int page = dgwhrcnd.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnnextwhrcnd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnaddparam_Click(object sender, EventArgs e)
    {
        try
        {
            btn0.Enabled = true; btn1.Enabled = true; btn2.Enabled = true; btn3.Enabled = true; btn5.Enabled = true; btn6.Enabled = true; btn7.Enabled = true;
            btn8.Enabled = true; btn9.Enabled = true; btnMinus.Enabled = true; btnperc.Enabled = true; btnPlus.Enabled = true; btnequla.Enabled = true;
            Buttonmul.Enabled = true; btn4.Enabled = true;
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_COUNT_OF_PARAM", htParam);
            int n1 = Convert.ToInt32(ds.Tables[0].Rows[0]["COUNT"].ToString().Trim());

            if (Convert.ToInt32(ViewState["count1"]) == 0)
            {
                ViewState["count1"] = Convert.ToInt32(ViewState["count1"]) + 1;
            }
            else
            {
                ViewState["count1"] = Convert.ToInt32(ViewState["count1"]);
            }
            //for (int i = 1; i <= x; i++)
            //{
            Button b = new Button();
            b.Text = "P" + Convert.ToInt32(ViewState["count1"]).ToString();
            b.ID = "P" + Convert.ToInt32(ViewState["count1"]).ToString();
            b.Attributes.Add("Onclick", "return addDigit(this)");
            b.BackColor = System.Drawing.Color.Transparent;
            b.BorderWidth = 1;
            b.Width = 40;
            b.Height = 30;
            if (Convert.ToInt32(ViewState["count1"]) % 5 == 1 && Convert.ToInt32(ViewState["count1"]) != 1)
            {
                pnladdbtn.Controls.Add(new LiteralControl("<br/>"));
                pnladdbtn.Controls.Add(b);
            }
            else
            {
                pnladdbtn.Controls.Add(b);
            }
            ControlsList.Add(b.ID);
            //}
            if (Convert.ToInt32(ViewState["count1"]) == n1)
            {
                btnaddparam.Enabled = false;
            }
            ViewState["count1"] = Convert.ToInt32(ViewState["count1"]) + 1;
            //x++;
        }
        catch (Exception ex)
        {

            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnaddparam_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSaveformuladiv_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            htParam.Add("@FORMULA", txtformuladiv.Text);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_FORMULA", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Formula saved successfully');", true);
            //txtformuladiv.Text = "";
        }
        catch (Exception ex)
        {

            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnSaveformuladiv_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindddltemplatebind(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_KPI_ACCR_LOGIC_SU");
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
            objErr.LogErr("ISYS-SAIM", "KPISetup", "bindddltemplatebind", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddltemplatebind_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddltemplatebind.SelectedValue.ToString().Trim() == "201")
            {
                lbldefacccyclog.Text = "Consider All Accrual Cycle";
            }
            else if (ddltemplatebind.SelectedValue.ToString().Trim() == "202")
            {
                lbldefacccyclog.Text = "Consider Last Accrual Cycle";
            }
            else
            {
                lbldefacccyclog.Text = "";
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "ddltemplatebind_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnsavedefacccyclog_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            if (ddltemplatebind.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Template');", true);
                return;

            }
            else
            {
                htParam.Add("@KPI_ACCR_LOGIC", ddltemplatebind.SelectedValue.ToString().Trim());
            }
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_KPI_ACCR_LOGIC_SU", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Define Accumulation Logic saved successfully');", true);
            //ddltemplatebind.ClearSelection();
            //lbldefacccyclog.Text = "";
        }
        catch (Exception ex)
        {

            objErr.LogErr("ISYS-RGIC", "KPISetup", "btnsavedefacccyclog_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddltblnam_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlcolnam.Items.Clear();
            if (ddltblnam.SelectedIndex != 0)
            {
                ds.Clear();
                htParam.Clear();
                htParam.Add("@OBJ_ID", ddltblnam.SelectedValue.ToString().Trim());
                htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("PRC_BIND_KPISETUP_COLNAM", htParam);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlcolnam.DataSource = ds.Tables[0];
                    ddlcolnam.DataTextField = "COL_NAM";
                    ddlcolnam.DataValueField = "SEQ_NO";
                    ddlcolnam.DataBind();
                }
                ddlcolnam.Items.Insert(0, new ListItem("SELECT", ""));
            }
            else
            {
                ddlcolnam.SelectedIndex = 0;
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "ddltblnam_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void rdDefproclog_CheckedChanged(object sender, EventArgs e)
    {

        if (rdDefproclog.Checked)
        {
            txtattchproc.Enabled = false;
        }
        else
        {
            txtattchproc.Enabled = true;
        }
    }
    protected void rdDefproclog1_CheckedChanged(object sender, EventArgs e)
    {

        if (rdDefproclog1.Checked)
        {
            txtattchproc.Enabled = true;
        }
        else
        {
            txtattchproc.Enabled = false;
        }
    }
    public void BindddlStatus(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            //ds = objDal.GetDataSetForPrc("PRC_DDLSTATUS");
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DDLSTATUS");
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
            objErr.LogErr("ISYS-SAIM", "KPISetup", "BindddlStatus", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkdeletedattyp_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdndattypdesc = (HiddenField)row.FindControl("hdndattypdesc");
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CODE", hdndattypdesc.Value.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_DEL_MST_KPI_DATETYPE_SU", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_MST_KPI_DATETYPE_SU", htParam);
            if (ds.Tables.Count > 0)
            {
                string msg1 = string.Empty;
                msg1 = ds.Tables[0].Rows[0]["MESSAGE"].ToString().Trim();
                if (msg1 == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Cannot delete record as date type entry exist in date related definition');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data has been deleted');", true);
            }
            Getdattypdata(dgdattyp);
            bindddltblnam(ddltblnam);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkdeletedattyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkdeletestddeftyp_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnstddeftyp = (HiddenField)row.FindControl("hdnstddeftyp");
            ds.Clear();
            htParam.Clear();
            htParam.Add("@ACT_TYPE", hdnstddeftyp.Value.ToString().Trim());
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_DEL_MST_KPI_STD_DEF_SCOPE_DTLS", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_MST_KPI_STD_DEF_SCOPE_DTLS", htParam);
            if (ds.Tables.Count > 0)
            {
                string msg1 = string.Empty;
                msg1 = ds.Tables[0].Rows[0]["MESSAGE"].ToString().Trim();
                if (msg1 == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Cannot delete record as Action Exist for this Standard Definition Type');", true);
                    return;
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "confPromptBox1();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully Deleted the record');", true);
                Getstddeftypdata(dgstddeftyp);
                bindddlstddeftyp(ddllblStddeftyp);
                BindActionGrid();
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkdeletestddeftyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnClearaccdatsynlog_Click(object sender, EventArgs e)
    {
        try
        {
            ddltemplate.SelectedIndex = 0;
            txtNoParam.Text = "";
            lstdefgrpbsdcol.ClearSelection();
            ddlgrpcond.SelectedIndex = 0;
            lstgrpcolnam.ClearSelection();

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "btnClearaccdatsynlog_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkbtnfrtcolparamclr_Click(object sender, EventArgs e)
    {
        try
        {
            ddlwhrconcolnam.SelectedIndex = 0;
            ddlOprtr.SelectedIndex = 0;
            txtwhrconcolval.Text = "";

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkbtnfrtcolparamclr_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkeditdattyp_Click(object sender, EventArgs e)
    {
        try
        {
            btnAdddattyp.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdndattypdesc = (HiddenField)row.FindControl("hdndattypdesc");
            string c = hdndattypdesc.Value.ToString().Trim();
            Session["DATTYPCOD"] = c;
            ds.Clear();
            htParam.Clear();
            htParam.Add("@DAT_TYP_CODE", hdndattypdesc.Value.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_FILL_DATA_TYP_DTLS", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_FILL_DATA_TYP_DTLS", htParam);
            txtdattypdesc.Text = ds.Tables[0].Rows[0]["DESC01"].ToString();
            txteffdefdttyp.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EFF_DTIM"]).ToString("dd/MM/yyyy");
            txteffdefdttyp.Enabled = false;
            txtcsedttyp.Enabled = true;
            string status = ds.Tables[0].Rows[0]["STATUS"].ToString();
            string tblnam = ds.Tables[1].Rows[0]["OBJ_ID"].ToString();
            string colnam = ds.Tables[2].Rows[0]["SEQ_NO"].ToString();
            BindddlStatus(ddldattypsta);
            ddldattypsta.SelectedValue = status;
            ddldattypsta.Enabled = true;
            bindddltblnam(ddltblnam);
            ddltblnam.SelectedValue = tblnam;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString());
            String query = "SELECT COL_NAM FROM MST_TBL_COL_DTLS WHERE SEQ_NO= @SEQ_NO";
            SqlCommand queryCommand = new SqlCommand(query, con);
            SqlDataReader sdr;
            queryCommand.Parameters.Add("@SEQ_NO", colnam.ToString());
            con.Open();
            sdr = queryCommand.ExecuteReader(CommandBehavior.CloseConnection);
            bool temp = false;

            while (sdr.Read())
            {

                Session["COL_NAM"] = sdr["COL_NAM"].ToString();
                temp = true;
            }
            ddlcolnam.Items.Insert(1, new ListItem(Session["COL_NAM"].ToString(), Convert.ToString(Convert.ToInt32(colnam))));
            ddlcolnam.SelectedIndex = 1;
            con.Close();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkeditdattyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkeditstddeftyp_Click(object sender, EventArgs e)
    {
        try
        {
            btnsavestddeftyp.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnstddeftyp = (HiddenField)row.FindControl("hdnstddeftyp");
            HiddenField hdnkpicodestddef = (HiddenField)row.FindControl("hdnkpicodestddef");
            string sdt = hdnstddeftyp.Value.ToString().Trim();
            string kpi = hdnkpicodestddef.Value.ToString().Trim();
            Session["ssdt"] = sdt;
            Session["skpi"] = kpi;
            ds.Clear();
            htParam.Clear();
            htParam.Add("@ACT_TYP", hdnstddeftyp.Value.ToString().Trim());
            htParam.Add("@KPI_CODE", hdnkpicodestddef.Value.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_FILL_STD_DEF_TYP_DTLS", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_FILL_STD_DEF_TYP_DTLS", htParam);
            string stddeftyp = ds.Tables[0].Rows[0]["ACT_TYPE"].ToString();
            string status1 = ds.Tables[0].Rows[0]["STATUS"].ToString();
            string bsdontbltyp = ds.Tables[0].Rows[0]["BSD_ON_TBL_TYP"].ToString();
            txteffdtdefstdtyp.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EFF_DTIM"]).ToString("dd/MM/yyyy");
            txteffdtdefstdtyp.Enabled = false;
            txtcsedtdefstdtyp.Enabled = true;
            BindddlStatus(ddldefstddeftypsta);
            ddldefstddeftypsta.SelectedValue = status1;
            ddldefstddeftypsta.Enabled = true;
            ddlbsdontbltyp.SelectedValue = bsdontbltyp;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString());
            String query = "SELECT ACT_TYP_DSC FROM MST_ACT_TYPE WHERE ACT_TYP_ID= @ACT_TYP_ID";
            SqlCommand queryCommand = new SqlCommand(query, con);
            SqlDataReader sdr;
            queryCommand.Parameters.Add("@ACT_TYP_ID", stddeftyp.ToString());
            con.Open();
            sdr = queryCommand.ExecuteReader(CommandBehavior.CloseConnection);
            bool temp = false;

            while (sdr.Read())
            {

                Session["ACT_TYP_DSC"] = sdr["ACT_TYP_DSC"].ToString();
                temp = true;
            }
            ddllblStddeftyp.Items.Insert(1, new ListItem(Session["ACT_TYP_DSC"].ToString(), Convert.ToString(Convert.ToInt32(stddeftyp))));
            ddllblStddeftyp.SelectedIndex = 1;
            ddllblStddeftyp.Enabled = false;
            con.Close();

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkeditstddeftyp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkeditaccrlog_Click(object sender, EventArgs e)
    {
        try
        {
            lnkaccdatsynlog.Enabled = true;
            lnkaccdatsynlog.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
            btnClearaccdatsynlog.Enabled = false;
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnParam = (HiddenField)row.FindControl("hdnParam");
            HiddenField hdnkpicodeaccr = (HiddenField)row.FindControl("hdnkpicodeaccr");
            HiddenField hdndefgrp = (HiddenField)row.FindControl("hdndefgrp");
            HiddenField hdngrpcolnam = (HiddenField)row.FindControl("hdngrpcolnam");
            HiddenField hdntmplt = (HiddenField)row.FindControl("hdntmplt");
            string Par = hdnParam.Value.ToString().Trim();
            string akpi = hdnkpicodeaccr.Value.ToString().Trim();
            string defgrp = hdndefgrp.Value.ToString().Trim();
            string grpcol = hdngrpcolnam.Value.ToString().Trim();
            string tmplt = hdntmplt.Value.ToString().Trim();
            Session["Par"] = Par;
            Session["akpi"] = akpi;
            Session["defgrp"] = defgrp;
            Session["grpcol"] = grpcol;
            Session["tmplt"] = tmplt;
            ds.Clear();
            htParam.Clear();
            htParam.Add("@EPARAM", hdnParam.Value.ToString().Trim());
            htParam.Add("@EKPICD", hdnkpicodeaccr.Value.ToString().Trim());
            htParam.Add("@EDEFGRPCOL", hdndefgrp.Value.ToString().Trim());
            htParam.Add("@EGRPCOLNAM", hdngrpcolnam.Value.ToString().Trim());
            htParam.Add("@ETMPLT", hdntmplt.Value.ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_FILL_DEF_ACCR_DATA_LGC", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_FILL_DEF_ACCR_DATA_LGC", htParam);
            string TMPLT_ID = ds.Tables[0].Rows[0]["TMPLT_ID"].ToString();
            txtNoParam.Text = ds.Tables[0].Rows[0]["NO_OF_PRMTR"].ToString();
            txteffdtdefaccruallog.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EFF_DTIM"]).ToString("dd/MM/yyyy");
            txteffdtdefaccruallog.Enabled = false;
            txtcsedtdefaccruallog.Enabled = true;
            string STATUS = ds.Tables[0].Rows[0]["STATUS"].ToString();
            string GRP_CNDTN = ds.Tables[0].Rows[0]["GRP_CNDTN"].ToString();
            string GRP_BSE_COL = ds.Tables[0].Rows[0]["GRP_BSE_COL"].ToString();
            string COL = ds.Tables[0].Rows[0]["COL"].ToString();
            bindddltemplate(ddltemplate);
            ddltemplate.SelectedValue = TMPLT_ID;
            BindddlStatus(ddldefaccruallogsta);
            ddldefaccruallogsta.SelectedValue = STATUS;
            ddldefaccruallogsta.Enabled = true;
            bindddlgrpcond(ddlgrpcond);
            ddlgrpcond.SelectedValue = GRP_CNDTN;
            bindlstdefgrpbsdcol(lstdefgrpbsdcol);
            bindlstgrpcolnam(lstgrpcolnam);
            string[] values = GRP_BSE_COL.Split(',');
            for (int i = 0; i < lstdefgrpbsdcol.Items.Count; i++)
            {
                for (int i1 = 0; i1 < values.Length; i1++)
                {
                    if (lstdefgrpbsdcol.Items[i].Value.ToString().Trim() == values[i1].ToString().Trim())
                    {
                        lstdefgrpbsdcol.Items[i].Selected = true;
                    }
                }
            }
            string[] values1 = COL.Split(',');
            for (int i2 = 0; i2 < lstgrpcolnam.Items.Count; i2++)
            {
                for (int i3 = 0; i3 < values1.Length; i3++)
                {
                    if (lstgrpcolnam.Items[i2].Value.ToString().Trim() == values1[i3].ToString().Trim())
                    {
                        lstgrpcolnam.Items[i2].Selected = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkeditaccrlog_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkdeletewhrcond_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnwhrParam = (HiddenField)row.FindControl("hdnwhrParam");
            HiddenField hdnwhrconcolnam = (HiddenField)row.FindControl("hdnwhrconcolnam");
            HiddenField hdnwhrconopr = (HiddenField)row.FindControl("hdnwhrconopr");
            HiddenField hdnwhrconcolval = (HiddenField)row.FindControl("hdnwhrconcolval");
            ds.Clear();
            htParam.Clear();
            htParam.Add("@DEL_PARAM", hdnwhrParam.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_COL", hdnwhrconcolnam.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_OPR", hdnwhrconopr.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_COL_VAL", hdnwhrconcolval.Value.ToString().Trim());
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_DEL_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data has been deleted');", true);
            getdgwhrcnd(dgwhrcnd);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkdeletewhrcond_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkeditwhrcond_Click(object sender, EventArgs e)
    {
        try
        {
            lnkbtnfrtcolparamadd.Enabled = true;
            lnkbtnfrtcolparamadd.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White;'></span>  Update";
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnwhrParam = (HiddenField)row.FindControl("hdnwhrParam");
            HiddenField hdnwhrconcolnam = (HiddenField)row.FindControl("hdnwhrconcolnam");
            HiddenField hdnwhrconopr = (HiddenField)row.FindControl("hdnwhrconopr");
            HiddenField hdnwhrconcolval = (HiddenField)row.FindControl("hdnwhrconcolval");
            HiddenField hdnwhraccruallogiceffdt = (HiddenField)row.FindControl("hdnwhraccruallogiceffdt");
            txteffdtaccrualwhr.Text = hdnwhraccruallogiceffdt.Value.ToString().Trim();
            string wPar = hdnwhrParam.Value.ToString().Trim();
            string wcn = hdnwhrconcolnam.Value.ToString().Trim();
            string wco = hdnwhrconopr.Value.ToString().Trim();
            string wcv = hdnwhrconcolval.Value.ToString().Trim();
            Session["wPar"] = wPar;
            Session["wcn"] = wcn;
            Session["wco"] = wco;
            Session["wcv"] = wcv;
            ds.Clear();
            htParam.Clear();
            htParam.Add("@DEL_PARAM", hdnwhrParam.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_COL", hdnwhrconcolnam.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_OPR", hdnwhrconopr.Value.ToString().Trim());
            htParam.Add("@DEL_WHR_COL_VAL", hdnwhrconcolval.Value.ToString().Trim());
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            //ds = objDal.GetDataSetForPrc("PRC_FILL_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_FILL_MST_KPI_ACCR_WHR_LOGIC_SU", htParam);
            lblParamnamVal.Text = ds.Tables[0].Rows[0]["PRMTR"].ToString();
            txtwhrconcolval.Text = ds.Tables[0].Rows[0]["WHR_CNDTN_COL_VAL"].ToString();
            txtwhrconcolval.Enabled = true;
            string oprtr = ds.Tables[0].Rows[0]["WHR_CNDTN_OPRT"].ToString();
            string colnam = ds.Tables[0].Rows[0]["WHR_CNDTN_COL_NAME"].ToString();
            string whrstat = ds.Tables[0].Rows[0]["STATUS"].ToString();
            BindddlStatus(ddlaccrualwhrsta);
            ddlaccrualwhrsta.SelectedValue = whrstat;
            ddlaccrualwhrsta.Enabled = true;
            bindddlwhrconcolnam(ddlwhrconcolnam);
            bindddlOprtr(ddlOprtr);
            ddlOprtr.SelectedValue = oprtr;
            ddlOprtr.Enabled = true;
            ddlwhrconcolnam.SelectedValue = colnam;
            txtcsedtaccrualwhr.Enabled = true;
            txteffdtaccrualwhr.Enabled = false;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkeditwhrcond_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btncncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPISearch.aspx", true);

    }
    protected void lnkdefvalfctr_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnstddeftyp = (HiddenField)row.FindControl("hdnstddeftyp");
            HiddenField hdnkpicodestddef = (HiddenField)row.FindControl("hdnkpicodestddef");
            HiddenField hdnbsdtbltyp = (HiddenField)row.FindControl("hdnbsdtbltyp");
            Label lblhdacttyp = row.FindControl("lblhdacttyp") as Label;
            Label lblhdnbsdontbltype = row.FindControl("lblbsdtbltyp") as Label;
            if (hdnbsdtbltyp.Value.ToString().Trim() == "BASE")
            {
                Session["BSD_ON_TBL_TYP"] = "B";
            }
            else if (hdnbsdtbltyp.Value.ToString().Trim() == "SOURCE")
            {
                Session["BSD_ON_TBL_TYP"] = "S";
            }
             string BSD_ON_TBL_TYP = (string)Session["BSD_ON_TBL_TYP"];
             //string BSD_ON_TBL_TYP = lblhdnbsdontbltype.Text.ToString();
            Response.Redirect("~/Application/Isys/Saim/Customisation/MSTACTVALSU.aspx?KPICode=" + hdnkpicodestddef.Value.ToString().Trim()
                               + "&ACT_TYP=" + hdnstddeftyp.Value.ToString().Trim() + "&BSD_ON_TBL_TYP=" + BSD_ON_TBL_TYP.ToString().Trim(), false);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "KPISetup", "lnkeditaccrlog_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected bool Checkforstddef()
    {
        if (Request.QueryString["flag"].ToString().Trim() != "N")
        {
            DataSet ds = new DataSet();
            htParam.Clear();
            htParam.Add("@KPICODEDATTYP", Request.QueryString["KPICode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_CHK_FOR_STD_DEF_KPI", htParam);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    //Added By Abuzar Ends
}
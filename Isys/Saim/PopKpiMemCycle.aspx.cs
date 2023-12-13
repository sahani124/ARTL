using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CBFRMUTIL;
using DataAccessClassDAL;
using System.Data.SqlClient;


public partial class Application_Report_PopKpiMemCycle : BaseClass
{
    DataSet dsComplaintDtls = new DataSet();
    DataTable dtResult = new DataTable();
    Hashtable htparam = new Hashtable();
    DataAccessLayer objdal = new DataAccessLayer();
    DataAccessClass objDal1 = new DataAccessClass();
    public const string Constr = "SAIMConnectionString";
    DataAccessClass objDal = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    DataSet dsResult = new DataSet();
    DataSet DsValue = new DataSet();
    DataSet DsHeader = new DataSet();
    DataSet dsDtls = new DataSet();
    DataSet DsNew = new DataSet();
    Hashtable htable = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    CBFRMUTIL.ErrLog objErrLog = new CBFRMUTIL.ErrLog();
    CBFRMUTIL.DataAccessLayer objUTLDAL = new CBFRMUTIL.DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserId"] == null || Session["UserLangNum"] == null || Session["CarrierCode"] == null)
        //{
        //    Response.Redirect("~/ErrorSession.aspx");
        //}

        //if (Session["UserId"] != null)
        //{
        //UserID = Session["UserId"].ToString();

        cmpcode.Value = Request.QueryString["cmpcode"].ToString();
        cntstcode.Value = Request.QueryString["cntstcode"].ToString();
        ruleset.Value = Request.QueryString["ruleset"].ToString();
        kpi.Value = Request.QueryString["kpi"].ToString();

        if (!IsPostBack)
        {
            divcmphdr.Visible = false;

            BindGridMemCycle();
        }
        //}
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {

        ///   BindGridMemCycle();

    }
    protected void BindGridSearchDtls()
    {
        try
        {
            DataSet dsResult = new DataSet();
            GrdSearch.DataSource = null;
            GrdSearch.DataBind();
            dsResult = GridStateDtls();
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    GrdSearch.DataSource = dsResult;
                    GrdSearch.DataBind();
                    lblResult.Visible = false;

                }
                else
                {
                    GrdSearch.DataSource = null;
                    GrdSearch.DataBind();
                    lblResult.Visible = true;
                    lblResult.Text = "No record found";
                }
            }
            else
            {
                GrdSearch.DataSource = null;
                GrdSearch.DataBind();
                lblResult.Visible = true;
                lblResult.Text = "No record found";
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "BindGridSearchDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void DatasetBind()
    {
        try
        {
            //if (Request.QueryString["CallType"] != "")
            //{              
            //    htable.Clear();
            //    htable.Add("@CallTypeCode", "(" + strCode.TrimEnd(',') + ")");
            //    htable.Add("@Search", System.DBNull.Value);
            //    DsValue = objdal.GetDataSetForPrcDBConn("Prc_FillCallSubType", htable, Constr);
            //}
            //if (DsValue.Tables.Count > 0)
            //{


            //}
            //else
            //{
            //    GrdSearch.DataSource = null;
            //    GrdSearch.DataBind();
            //    lblResult.Visible = true;
            //    lblResult.Text = "No record found";
            //}


        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "DatasetBind", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void gvMemCycle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                DropDownList DropDownList1 = (e.Row.FindControl("ddlCycType") as DropDownList);
                LinkButton btnCyc1 = (e.Row.FindControl("btnCyc") as LinkButton);
                // FillAchievementTable(DropDownList1, "");


                DropDownList1.Items.Clear();
                Hashtable ht = new Hashtable();
                DataSet dsP = new DataSet();
                dsP.Clear();
               // ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());


                ht.Add("@Flag","3");

                dsP = objDal.GetDataSetForPrc_SAIM("Prc_GetReason", ht);

                if (dsP.Tables.Count > 0 && dsP.Tables[0].Rows.Count > 0)
                {


                    DropDownList1.DataSource = dsP;
                    DropDownList1.DataTextField = "ParamDesc1";
                    DropDownList1.DataValueField = "ParamValue";
                    DropDownList1.DataBind();
                }
                
                DropDownList1.Items.Insert(0, new ListItem("-- SELECT --", ""));

                DropDownList1.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Cycle_Type").ToString();

                if(DropDownList1.SelectedValue.ToString()=="N")
                {
                    btnCyc1.Visible = true;
                }
                else
                {
                    btnCyc1.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "gvMemCycle_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    #region grid State fill method
    private DataSet GridStateDtls()
    {

        try
        {
            
                htable.Clear();
                htable.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim());
                htable.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
                htable.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
                htable.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());
                htable.Add("@Flag", "Cycle");
                dsDtls = objDal1.GetDataSetForPrc_SAIM("Prc_GetKpiMemCycleType", htable);
            

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "GridStateDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        Session["dsGrdSearch"] = dsDtls;
        return dsDtls;
    }
    #endregion


    protected void GrdSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkAll = GrdSearch.HeaderRow.FindControl("checkAll") as CheckBox;
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect") as CheckBox;
            Label lblcallReqCode = (Label)e.Row.FindControl("lblcallReqCode") as Label;
            Label lblcallType = (Label)e.Row.FindControl("lblcallType") as Label;
            chkAll.Attributes.Add("onclick", "funCheckUnCheck(id)");
            chkSelect.Attributes.Add("onclick", "funCheckUnCheck(id)");

            if (lblcallReqCode.Text == "0")
            {
                chkSelect.Visible = false;
                lblcallType.Style["Font-Weight"] = "bold";
                lblcallType.Style["Font-color"] = "black";

            }

        }
    }
    protected void GrdSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            SaveCheckedValues();
            GrdSearch.PageIndex = e.NewPageIndex;
            GrdSearch.DataSource = Session["dsGrdSearch"];
            this.GrdSearch.DataBind();
            PopulateCheckedValues();

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "GrdSearch_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //This method is used to populate the saved checkbox values
    private void PopulateCheckedValues()
    {
        ArrayList userdetails = (ArrayList)Session["CHECKED_ITEMS"];
        if (userdetails != null && userdetails.Count > 0)
        {
            foreach (GridViewRow gvrow in GrdSearch.Rows)
            {
                int index = Convert.ToInt32(GrdSearch.DataKeys[gvrow.RowIndex].Value);
                if (userdetails.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkSelect");
                    myCheckBox.Checked = true;
                }
            }
        }
    }
    //This method is used to save the checkedstate of values
    private void SaveCheckedValues()
    {
        ArrayList userdetails = new ArrayList();
        int index = -1;
        foreach (GridViewRow gvrow in GrdSearch.Rows)
        {
            index = Convert.ToInt32(GrdSearch.DataKeys[gvrow.RowIndex].Value);
            bool result = ((CheckBox)gvrow.FindControl("chkSelect")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                userdetails = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!userdetails.Contains(index))
                    userdetails.Add(index);
            }
            else
                userdetails.Remove(index);
        }
        if (userdetails != null && userdetails.Count > 0)
            Session["CHECKED_ITEMS"] = userdetails;
    }


    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row


            try
            {

                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Number");
                dt.Columns.Add("TypeDesc");
                dt.Columns.Add("TypeCode");

                DataTable dt2 = new DataTable();
                dt2.Clear();
                dt2.Columns.Add("Number");
                dt2.Columns.Add("TypeDesc");
                dt2.Columns.Add("TypeCode");

                DataTable dt3 = new DataTable();
                dt3.Clear();
                dt3.Columns.Add("Number");
                dt3.Columns.Add("TypeDesc");
                dt3.Columns.Add("TypeCode");

                foreach (GridViewRow rowItem in GrdSearch.Rows)
                {
                    CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect");



                    Label lblCounter0 = (Label)rowItem.FindControl("lblCounter");

                    Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType");
                    Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode");
                    //if (chBx.Checked == true)
                    //{

                    DataRow _NewRow = dt3.NewRow();
                    _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
                    _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
                    _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
                    dt3.Rows.Add(_NewRow);




                    //}
                }

                foreach (GridViewRow rowItem in GrdSearchSelect.Rows)
                {
                    CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect1");


                    //chBx.Checked = true;
                    Label lblCounter0 = (Label)rowItem.FindControl("lblCounter1");

                    Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType1");
                    Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode1");
                    if (rowItem.RowIndex == rowindex)
                    {



                        DataRow _NewRow = dt2.NewRow();
                        _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
                        _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
                        _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
                        dt2.Rows.Add(_NewRow);
                    }

                    else
                    {
                        DataRow _NewRow = dt.NewRow();
                        _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
                        _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
                        _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
                        dt.Rows.Add(_NewRow);
                    }



                    //}
                }



                dt3.Merge(dt2);

                GrdSearch.DataSource = dt3;
                GrdSearch.DataBind();

                GrdSearchSelect.DataSource = dt;
                GrdSearchSelect.DataBind();
            }
            catch (Exception ex)
            {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "GridView1_RowCommand", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

            }

        }
    }



    protected void btncheck_Click(object sender, EventArgs e)
    {
    }

    protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            HdnAgentCnt.Value = GrdSearchSelect.Rows.Count.ToString().Trim();

            //if( Request.QueryString["CallType"].ToString()=="MarketType" )
            // {
            //     HdnMarkCnt.Value=GrdSearchSelect.Rows.Count.ToString().Trim();
            // }
            //if (Request.QueryString["CallType"].ToString() == "Agent")
            //{

            //    HdnAgentCnt.Value = GrdSearchSelect.Rows.Count.ToString().Trim();
            //}
            //if (Request.QueryString["CallType"].ToString() == "HNIN")
            //{
            //    HdnHninCnt.Value = GrdSearchSelect.Rows.Count.ToString().Trim();
            //}
            foreach (GridViewRow rowItem in GrdSearchSelect.Rows)
            {
                CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect1");


                //chBx.Checked = true;
                Label lblCounter0 = (Label)rowItem.FindControl("lblCounter1");

                Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType1");
                Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode1");

                //  hndDesc .Value =hndDesc.Value +","+ lblCounter0.Text.ToString().Trim();
                if (hndDesc.Value == "")
                {
                    hndDesc.Value = lbllblcallType0.Text.ToString().Trim();
                }
                else
                {
                    hndDesc.Value = hndDesc.Value + "," + lbllblcallType0.Text.ToString().Trim();
                }
                if (hndCode.Value == "")
                {
                    hndCode.Value = lbllblcallReqCode0.Text.ToString().Trim();
                }

                else
                {
                    hndCode.Value = hndCode.Value + "," + lbllblcallReqCode0.Text.ToString().Trim();
                }







                //}
            }

            if (GrdSearchSelect.Rows.Count > 0)
            {
                if (GrdSearchSelect.Rows.Count > 1)
                {
                    hndCode.Value = "";
                    hndDesc.Value = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please  select only one agent.You have selected multiple agents');</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doSelect('" + Request.QueryString["CallType"].ToString().Trim() + "','" + hndDesc.Value.ToString().TrimStart(',') + "','" + hndCode.Value.TrimStart(',') + "')", true);
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ValidationSelection()", true);
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "btnSubmit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlPageSelectorR_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrdSearch.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindGridSearchDtls();
    }

    public void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page, string DDlPagerR)
    {
        int pageIndexL = gridView.PageIndex;
        int pageCountL = gridView.PageCount;
        int pageIndexR = gridView.PageIndex;
        int pageCountR = gridView.PageCount;//Initialize the variables

        // ImageButton btnFirstL = (ImageButton)gvPagerRow.FindControl("ImgbtnFirst");
        // ImageButton btnPreviousL = (ImageButton)gvPagerRow.FindControl("ImgbtnPrevious");
        // ImageButton btnNextL = (ImageButton)gvPagerRow.FindControl("ImgbtnNext");
        //  ImageButton btnLastL = (ImageButton)gvPagerRow.FindControl("ImgbtnLast");
        ImageButton btnFirstR = (ImageButton)gvPagerRow.FindControl("ImgbtnFirst1");
        ImageButton btnPreviousR = (ImageButton)gvPagerRow.FindControl("ImgbtnPrevious1");
        ImageButton btnNextR = (ImageButton)gvPagerRow.FindControl("ImgbtnNext1");
        ImageButton btnLastR = (ImageButton)gvPagerRow.FindControl("ImgbtnLast1");//Find the controls

        //  btnFirstL.Visible = btnPreviousL.Visible = (pageIndexL != 0);
        //  btnNextL.Visible = btnLastL.Visible = (pageIndexL < (pageCountL - 1));
        btnFirstR.Visible = btnPreviousR.Visible = (pageIndexR != 0);
        btnNextR.Visible = btnLastR.Visible = (pageIndexR < (pageCountR - 1));//Manage the Buttons according to page number

        //   DropDownList ddlPageSelectorL = (DropDownList)gvPagerRow.FindControl(DDlPagerL);
        //  ddlPageSelectorL.Items.Clear();
        DropDownList ddlPageSelectorR = (DropDownList)gvPagerRow.FindControl(DDlPagerR);
        ddlPageSelectorR.Items.Clear();//Find Dropdowns

        for (int i = 1; i <= gridView.PageCount; i++)
        {
            //    ddlPageSelectorL.Items.Add(i.ToString());
            ddlPageSelectorR.Items.Add(i.ToString());
        }//Fill those dropdowns

        //   ddlPageSelectorL.SelectedIndex = pageIndexL;
        ddlPageSelectorR.SelectedIndex = pageIndexR;
        //Initialize the dropdowns

        string strPgeIndx = Convert.ToString(gridView.PageIndex + 1) + " of "
                            + gridView.PageCount.ToString();//Initialize the Page Information.

        Label lblpageindx = (Label)gvPagerRow.FindControl("lblpageindx");
        lblpageindx.Text += strPgeIndx;
        //Label lblpageindx2 = (Label)gvPagerRow.FindControl("lblpageindx2");
        //lblpageindx2.Text += strPgeIndx;
        //Fill the Page Information section
    }


    protected void GrdSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            SetPagerButtonStates(GrdSearch, e.Row, this, "ddlPageSelectorR");
        }
    }



    protected void btnsearch_Click(object sender, EventArgs e)
    {

        if (TxtSearchfield.Text != "")
        {
            DataSet dsResult = new DataSet();
            //GrdSearch.DataSource = null;
            //GrdSearch.DataBind();
            dsResult = GridStateDtls();

            //   DataRow[] result = dsResult.Tables[0].Select("TypeCode=" + TxtSearchfield.Text.Trim().ToString()); commented by prity on 13 oct 2015

            DataTable table = dsResult.Tables[0];
            if (table.Rows.Count > 0)
            {
                // table.DefaultView.RowFilter = "TypeCode = '" + TxtSearchfield.Text.Trim()+ "'";
                table.DefaultView.RowFilter = "[TypeCode] LIKE '%" + TxtSearchfield.Text.Trim() + "%'";//Added by prity 0n 13 oct 2015
                table = table.DefaultView.ToTable();

            }
            GrdSearchfilter.DataSource = table;
            GrdSearchfilter.DataBind();
            GrdSearchfilter.Visible = true;
            GrdSearch.Visible = false;
        }

        if (txtName.Text != "")
        {
            DataSet dsResult = new DataSet();
            //GrdSearch.DataSource = null;
            //GrdSearch.DataBind();
            dsResult = GridStateDtls();

            // DataRow[] result = dsResult.Tables[0].Select("TypeDesc=" + TxtSearchfield.Text.Trim());

            DataTable table = dsResult.Tables[0];
            if (table.Rows.Count > 0)
            {


                // dt.DefaultView.RowFilter = "[y_Malzemeler] LIKE '%" + strKelime + "%'";
                table.DefaultView.RowFilter = "[TypeDesc] LIKE '%" + txtName.Text.Trim() + "%'";
                // table.DefaultView.RowFilter = "TypeDesc = '" + txtName.Text.Trim() + "'";
                table = table.DefaultView.ToTable();
            }
            GrdSearchfilter.DataSource = table;
            GrdSearchfilter.DataBind();
            GrdSearchfilter.Visible = true;
            GrdSearch.Visible = false;

        }
        //Added by prity on 19 oct 2015
        if (TxtSearchfield.Text == "" && txtName.Text == "")
        {

            GrdSearchfilter.DataSource = null;
            GrdSearchfilter.DataBind();

        }
        //Ended by prity on 19 oct 2015

    }


    protected void btnsearch0_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        dt.Columns.Add("Number");
        dt.Columns.Add("TypeDesc");
        dt.Columns.Add("TypeCode");

        DataTable dt3 = new DataTable();
        dt3.Clear();
        dt3.Columns.Add("Number");
        dt3.Columns.Add("TypeDesc");
        dt3.Columns.Add("TypeCode");
        if (GrdSearchfilter.Rows.Count > 0)
        {



            foreach (GridViewRow rowItem in GrdSearchfilter.Rows)
            {
                CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect0");



                Label lblCounter0 = (Label)rowItem.FindControl("lblCounter0");

                Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType0");
                Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode0");
                if (chBx.Checked == true)
                {

                    DataRow _NewRow = dt.NewRow();
                    _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
                    _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
                    _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
                    dt.Rows.Add(_NewRow);




                }
            }

        }
        else
        {

            foreach (GridViewRow rowItem in GrdSearch.Rows)
            {
                CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect");



                Label lblCounter0 = (Label)rowItem.FindControl("lblCounter");

                Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType");
                Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode");
                if (chBx.Checked == true)
                {

                    DataRow _NewRow = dt3.NewRow();
                    _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
                    _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
                    _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
                    dt3.Rows.Add(_NewRow);




                }
            }

        }
        DataTable dt2 = new DataTable();
        dt2.Clear();
        dt2.Columns.Add("Number");
        dt2.Columns.Add("TypeDesc");
        dt2.Columns.Add("TypeCode");


        foreach (GridViewRow rowItem in GrdSearchSelect.Rows)
        {
            CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect1");


            //chBx.Checked = true;
            Label lblCounter0 = (Label)rowItem.FindControl("lblCounter1");

            Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType1");
            Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode1");
            //if (chBx.Checked == true)
            //{

            DataRow _NewRow = dt2.NewRow();
            _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
            _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
            _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
            dt2.Rows.Add(_NewRow);




            //}
        }
        if (GrdSearchfilter.Rows.Count > 0)
        {


            dt2.Merge(dt);
        }


        if (dt3.Rows.Count > 0)
        {
            dt2.Merge(dt3);
        }


        dt3.Clear();

        foreach (GridViewRow rowItem in GrdSearch.Rows)
        {
            CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect");



            Label lblCounter0 = (Label)rowItem.FindControl("lblCounter");

            Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType");
            Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode");
            //if (chBx.Checked == true)
            //{

            DataRow _NewRow = dt3.NewRow();
            _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
            _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
            _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
            dt3.Rows.Add(_NewRow);




            // }
        }


        // lblCounter1

        for (int i = 0; i < dt3.Rows.Count; i++)
        {

            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                string str1 = dt3.Rows[i]["TypeCode"].ToString();
                string str2 = dt2.Rows[j]["TypeCode"].ToString();

                if (str1 == str2)
                {

                    dt3.Rows.RemoveAt(i);
                }
            }


        }


        GrdSearchSelect.DataSource = dt2;

        GrdSearchSelect.DataBind();

        GrdSearchfilter.Visible = false;

        GrdSearch.Visible = true;

        GrdSearch.DataSource = dt3;

        GrdSearch.DataBind();

        GrdSearchfilter.DataSource = null;
        GrdSearchfilter.DataBind();



    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        btnsearch_Click(sender, e);//Added by prity on 19 oct 2015
    }
    protected void BindGridMemCycle()
    {
        try
        {
            DataSet dsResult = new DataSet();
            gvMemCycle.DataSource = null;
            gvMemCycle.DataBind();
            dsResult = GridStateDtls();
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    gvMemCycle.DataSource = dsResult;
                    gvMemCycle.DataBind();
                    lblResult1.Visible = false;
                    if (gvMemCycle.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
                    {
                        btnnextrwdtrg.Enabled = true;
                    }
                    else
                    {
                        btnnextrwdtrg.Enabled = false;
                    }

                }
                else
                {
                    divMemCycleSearch.Visible = false;
                    divPagination.Visible = false;
                    gvMemCycle.DataSource = null;
                    gvMemCycle.DataBind();
                    lblResult1.Visible = true;
                    lblResult1.Text = "No record found";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No record found.');", true);
                }
            }
            else
            {
                divMemCycleSearch.Visible = false;
                divPagination.Visible = false;
                gvMemCycle.DataSource = null;
                gvMemCycle.DataBind();
                lblResult1.Visible = true;
                lblResult1.Text = "No record found";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No record found.');", true);
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "BindGridMemCycle", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void btnnextrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvMemCycle.PageIndex;
            gvMemCycle.PageIndex = pageIndex + 1;
            BindGridMemCycle();

            btnprevrwdtrg.Enabled = true;
            if (txtpgrwdtrg.Text == Convert.ToString(gvMemCycle.PageCount))
            {
                btnnextrwdtrg.Enabled = false;
            }
            else
            {
                txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            }

            int page = gvMemCycle.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "btnnextrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvMemCycle.PageIndex;
            gvMemCycle.PageIndex = pageIndex - 1;
            BindGridMemCycle();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprevrwdtrg.Enabled = false;
            }
            else
            {
                btnprevrwdtrg.Enabled = true;
            }
            btnnextrwdtrg.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "btnprevrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlCycType_SelectedIndex(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlddlCycType1 = (DropDownList)row.FindControl("ddlCycType");
            Label lblCumuCycle1 = ((Label)row.FindControl("lblCumuCycle"));
            Label lblMemCycle1 = ((Label)row.FindControl("lblMemCycle"));
            Label lblTypeCycle1 = ((Label)row.FindControl("lblTypeCycle"));

            LinkButton btnCyc1 = ((LinkButton)row.FindControl("btnCyc"));
           //  TextBox TxtGRDlblCode = ((TextBox)row.FindControl("GRDlblCode"));
           // TextBox TxtGRDlblDesc = ((TextBox)row.FindControl("GRDlblDesc"));
            lblCumuCycle1.Text = "";
           
            if (ddlddlCycType1.SelectedItem.Text != "--SELECT--")
            {
                if (ddlddlCycType1.SelectedIndex.ToString() == "1")
                {
                    btnCyc1.Visible = false;
                    hdnCycType.Value = "S";
                    htable.Clear();
                    htable.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim());
                    htable.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
                    htable.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
                    htable.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());
                    htable.Add("@MEM_CYCLE", lblMemCycle1.Text.ToString());
                    htable.Add("@Flag", "CycType");
                    dsDtls = objDal1.GetDataSetForPrc_SAIM("Prc_GetKpiMemCycleType", htable);
                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        // lblCumuCycle1.Text = Convert.ToString(dsDtls.Tables[0].Rows[0]["BUSI_CODE"]);

                        hdnMemCycle.Value = Convert.ToString(dsDtls.Tables[0].Rows[0]["SHRT_BUSI_DESC"]);
                        //TxtGRDlblCode.Text = 
                       // TxtGRDlblDesc.Text = Convert.ToString(dsDtls.Tables[0].Rows[0]["BUSI_CODE"]);
                        hdnCumuCycle.Value = Convert.ToString(dsDtls.Tables[0].Rows[0]["BUSI_CODE"]);

                    }
                    
                 htable.Clear();
                 DsNew.Clear(); 

                htable.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim());
                htable.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
                htable.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
                htable.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());
                htable.Add("@MEM_CYCLE", lblMemCycle1.Text.ToString());
                htable.Add("@CYC_PERIOD", hdnCumuCycle.Value.ToString());
                htable.Add("@IS_SEQ", "S");
                htable.Add("@Flag", "INSTemp");
                htable.Add("@CREATEDBY", Session["UserId"].ToString());
                DsNew = objDal1.GetDataSetForPrc_SAIM("Prc_GetKpiMemCycleType", htable);


                BindGridMemCycle();
                }
                if (ddlddlCycType1.SelectedIndex.ToString() == "2")
                {
                    btnCyc1.Visible = true;
                    hdnCycType.Value = "N";
                }
            }
            else
            {
                lblCumuCycle1.Text = "";
               // TxtGRDlblCode.Text = "";
                //TxtGRDlblDesc.Text = "";
                btnCyc1.Visible = false;

            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "ddlCycType_SelectedIndex", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int strMemCyc = 0; 
            int strSuccess = 0;
            foreach (GridViewRow rowItem in gvMemCycle.Rows)
            {
                DropDownList ddlddlCycType1 = (DropDownList)rowItem.FindControl("ddlCycType");
                Label lblCumuCycle1 = ((Label)rowItem.FindControl("lblCumuCycle"));
                Label lblMemCycle1 = ((Label)rowItem.FindControl("lblMemCycle"));
                Label lblTypeCycle1 = ((Label)rowItem.FindControl("lblTypeCycle"));

                LinkButton btnCyc1 = ((LinkButton)rowItem.FindControl("btnCyc"));

                if (lblTypeCycle1.Text == "" || lblMemCycle1.Text == "")
                {
                    strMemCyc = strMemCyc + 1;
                }
            }
            if (strMemCyc > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select all cumulative cycles.');</script>", false);

            }
            else
            {
                foreach (GridViewRow rowItem in gvMemCycle.Rows)
            {
                DropDownList ddlddlCycType1 = (DropDownList)rowItem.FindControl("ddlCycType");
                Label lblCumuCycle1 = ((Label)rowItem.FindControl("lblCumuCycle"));
                Label lblTypeCycle1 = ((Label)rowItem.FindControl("lblTypeCycle"));
             
                Label lblMemCycle1 = ((Label)rowItem.FindControl("lblMemCycle"));
                LinkButton btnCyc1 = ((LinkButton)rowItem.FindControl("btnCyc"));
               
                hdnMemCycle.Value = lblMemCycle1.Text.ToString();
                hdnCumuCycle.Value = lblTypeCycle1.Text.ToString();
                if (ddlddlCycType1.SelectedIndex.ToString() == "1")
                { 
                    hdnCycType.Value = "S"; 
                }
                if (ddlddlCycType1.SelectedIndex.ToString() == "2")
                { 
                    hdnCycType.Value = "N"; 
                }
               
                htable.Clear();
                htable.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim());
                htable.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
                htable.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
                htable.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());
                htable.Add("@MEM_CYCLE", hdnMemCycle.Value.ToString());
                htable.Add("@CYC_PERIOD", hdnCumuCycle.Value.ToString());
                htable.Add("@IS_SEQ", hdnCycType.Value.ToString());
                htable.Add("@Flag", "INS");
                htable.Add("@CREATEDBY", Session["UserId"].ToString());
                dsDtls = objDal1.GetDataSetForPrc_SAIM("Prc_GetKpiMemCycleType", htable);
                if (dsDtls.Tables[0].Rows.Count > 0)
                {

                    if (Convert.ToString(dsDtls.Tables[0].Rows[0]["STATUS"]) == "S")
                    {
                     //   TxtGRDlblCode.Text = "";
                       // TxtGRDlblDesc.Text = "";
                        strSuccess = strSuccess + 1;
                        
                    }
                }
            }
            if (strSuccess >= 1) {
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cumulative cycles are added.');", true);
            }

        }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKpiMemCycle", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCyc_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
      //  HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
       // HiddenField hdnRulStKy = (HiddenField)row.FindControl("hdnRulStKy");

           Label lblMemCycle = (Label)row.FindControl("lblMemCycle");

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
        //    + "','Q','" + lblCatgCode.Text.ToString().Trim() + "','QualTrg', '" + hdnCode.Value.ToString().Trim() + "','" + hdnRulStKy.Value.ToString().Trim() + "');", true);



     
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "OpenPopupWindow('" + Request.QueryString["cmpcode"].ToString() + "','" + Request.QueryString["cntstcode"].ToString() + "','" 
            + Request.QueryString["ruleset"].ToString() + "','" + Request.QueryString["kpi"].ToString() + "','"+lblMemCycle.Text.ToString()+"');", true);
    }
    protected void BtnAgentToolTip_Click(object sender, EventArgs e)
    {


    }

}
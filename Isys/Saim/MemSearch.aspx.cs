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


public partial class Application_Report_MemSearch : BaseClass
{
    DataSet dsComplaintDtls = new DataSet();
    DataTable dtResult = new DataTable();
    Hashtable htparam = new Hashtable();
    DataAccessLayer objdal = new DataAccessLayer();
    DataAccessClass objDal1 = new DataAccessClass();
    public const string Constr = "SAIMConnectionString";
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    DataSet dsResult = new DataSet();
    DataSet DsValue = new DataSet();
    DataSet DsHeader = new DataSet();
    DataSet DsNew = new DataSet();
    Hashtable htable = new Hashtable();
    //CBFRMUTIL.ErrLog objErrLog = new CBFRMUTIL.ErrLog();
    CBFRMUTIL.DataAccessLayer objUTLDAL = new CBFRMUTIL.DataAccessLayer();
     ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserId"] == null || Session["UserLangNum"] == null || Session["CarrierCode"] == null)
        //{
        //    Response.Redirect("~/ErrorSession.aspx");
        //}

        //if (Session["UserId"] != null)
        //{
            //UserID = Session["UserId"].ToString();

            if (!IsPostBack)
            {
                Session["dsGrdSearch"] = null;
                Session["CHECKED_ITEMS"] = null;
              BindGridSearchDtls();
             GrdSearchSelect.DataSource = null;
            GrdSearchSelect.DataBind();
            }
        //}
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
            objErr.LogErr("ISYS-SAIM", "MemSearch", "BindGridSearchDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "MemSearch", "DatasetBind", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #region grid State fill method
    private DataSet GridStateDtls()
    {
        DataSet dsDtls = new DataSet();
        try
        {

            htable.Clear();
            htable.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
            htable.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim());
            dsDtls = objDal1.GetDataSetForPrc_SAIM("Prc_GetCNTSTNTMember", htable);



            //string strCode = string.Empty;
            //if (Request.QueryString["CallCode"] != "''")
            //{
            //    if (Request.QueryString["CallCode"] != "")
            //    {

            //        if (Request.QueryString["CallType"].ToString() == "HNIN" || Request.QueryString["CallType"].ToString() == "Agent" || Request.QueryString["CallType"].ToString() == "MarketType" || Request.QueryString["CallType"].ToString() == "Region" || Request.QueryString["CallType"].ToString() == "SmCodedirect" || Request.QueryString["CallType"].ToString() == "SmCode" || Request.QueryString["CallType"].ToString() == "BranchCode" || Request.QueryString["CallType"].ToString() == "Zone")
            //        {

            //            strCode = Request.QueryString["CallCode"].ToString();
            //        }
            //        else
            //        {
            //            string[] splitstr = Request.QueryString["CallCode"].Split(Convert.ToChar(","));
            //            for (int i = 0; i < splitstr.Length; i++)
            //            {
            //                if (splitstr[i] != "")
            //                {
            //                    strCode += "'" + splitstr[i] + "',";

            //                }
            //            }
            //        }
            //    }
            //}
            //if (Request.QueryString["CallType"] != "")
            //{
               
            //    htable.Clear();
            //    htable.Add("@Flag", Request.QueryString["CallType"].ToString().Trim());
            //    if (Request.QueryString["CallType"].ToString() == "Region" || Request.QueryString["CallType"].ToString() == "SmCodedirect" || Request.QueryString["CallType"].ToString() == "SmCode" || Request.QueryString["CallType"].ToString() == "BranchCode" || Request.QueryString["CallType"].ToString() == "Zone")
            //    {


            //        if (Request.QueryString["CallType"].ToString() == "SmCode" || Request.QueryString["CallType"].ToString() == "SmCodedirect")
            //        {
            //            if (Request.QueryString["CallType"].ToString() == "SmCode")
            //            {
            //                string[] str = strCode.Split('/');

            //                string[] strchanelarray = str[0].Split('-');


            //                htable.Add("@CodeID", str[1].ToString());
            //                htable.Add("@chanel", strchanelarray[0].ToString());
            //                htable.Add("@subchanel", strchanelarray[1].ToString());
            //                htable.Add("@UserId", Session["UserId"].ToString());
            //            }


            //            else
            //            {


            //                string[] strchanelarray = strCode.Split('-');


            //                htable.Add("@CodeID", "xyz");
            //                htable.Add("@chanel", strchanelarray[0].ToString());
            //                htable.Add("@subchanel", strchanelarray[1].ToString());
            //                htable.Add("@UserId", Session["UserId"].ToString());
            //            }
            //        }
            //        else
            //        {
            //            htable.Add("@CodeID", strCode.ToString());
            //        }

                    
            //    }
            //    else
            //    {
            //        if (Request.QueryString["CallCode"] != "" || Request.QueryString["CallType"].ToString() == "BranchCode" || Request.QueryString["CallType"].ToString() == "Zone" )
            //        {
            //            if ( Request.QueryString["CallType"].ToString() == "MarketType")
            //            {

            //                htable.Add("@CodeID", strCode.ToString());
            //                htable.Add("@MarckeFlag", Request.QueryString["Market"].ToString()); 
                            

                            

            //            }
            //            else if (Request.QueryString["CallType"].ToString() == "Agent")
            //            {
            //                htable.Add("@CodeID", strCode.ToString());
            //            }
            //            else if (Request.QueryString["CallType"].ToString() == "HNIN")
            //            {
            //                 htable.Add("@CodeID",  strCode.TrimEnd(',').ToString());

            //                 htable.Add("@smcode", Request.QueryString["SMcode"].ToString());

            //            }
            //            else
            //            {

            //                htable.Add("@CodeID", "(" + strCode.TrimEnd(',').ToString() + ")");
            //            }


            //        }
            //        else
            //        {
            //            htable.Add("@CodeID", System.DBNull.Value);
            //        }

                   
            //    }
            //    dsDtls = objDal1.GetDataSetForPrc_SAIM("Prc_FillLMSLeadAndLeadSubSource", htable);
            //     // dsDtls = objdal.GetDataSetForPrcDBConn("Prc_FillLMSLeadAndLeadSubSource", htable, "LMSRGICConnectionString");
                
            //}


           
               
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "MemSearch", "GridStateDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "MemSearch", "GrdSearch_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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

            objErr.LogErr("ISYS-SAIM", "MemSearch", "GridView1_RowCommand", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            
        }
    }


  
    protected void btncheck_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in GrdSearchSelect.Rows)
        //{
        //    if (row.RowIndex == GrdSearchSelect.SelectedIndex)
        //    {

           
        //        CheckBox chBx = (CheckBox)row.FindControl("chkSelect1");




        //    }
        //}
       
    }
    //protected void chkSelect1_OnCheckedChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Clear();
    //        dt.Columns.Add("Number");
    //        dt.Columns.Add("TypeDesc");
    //        dt.Columns.Add("TypeCode");

    //        DataTable dt2 = new DataTable();
    //        dt2.Clear();
    //        dt2.Columns.Add("Number");
    //        dt2.Columns.Add("TypeDesc");
    //        dt2.Columns.Add("TypeCode");

    //        DataTable dt3 = new DataTable();
    //        dt3.Clear();
    //        dt3.Columns.Add("Number");
    //        dt3.Columns.Add("TypeDesc");
    //        dt3.Columns.Add("TypeCode");

    //        foreach (GridViewRow rowItem in GrdSearch.Rows)
    //        {
    //            CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect");



    //            Label lblCounter0 = (Label)rowItem.FindControl("lblCounter");

    //            Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType");
    //            Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode");
    //            //if (chBx.Checked == true)
    //            //{

    //                DataRow _NewRow = dt3.NewRow();
    //                _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
    //                _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
    //                _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
    //                dt3.Rows.Add(_NewRow);




    //            //}
    //        }

    //        foreach (GridViewRow rowItem in GrdSearchSelect.Rows)
    //        {
    //            CheckBox chBx = (CheckBox)rowItem.FindControl("chkSelect1");


    //            //chBx.Checked = true;
    //            Label lblCounter0 = (Label)rowItem.FindControl("lblCounter1");

    //            Label lbllblcallType0 = (Label)rowItem.FindControl("lblcallType1");
    //            Label lbllblcallReqCode0 = (Label)rowItem.FindControl("lblcallReqCode1");
    //            if (chBx.Checked == true)
    //            {

    //                DataRow _NewRow = dt2.NewRow();
    //                _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
    //                _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
    //                _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
    //                dt2.Rows.Add(_NewRow);
    //            }

    //            else
    //            {
    //                DataRow _NewRow = dt.NewRow();
    //                _NewRow["Number"] = lblCounter0.Text.ToString().Trim();
    //                _NewRow["TypeDesc"] = lbllblcallType0.Text.ToString().Trim();
    //                _NewRow["TypeCode"] = lbllblcallReqCode0.Text.ToString().Trim();
    //                dt.Rows.Add(_NewRow);
    //            }



    //            //}
    //        }



    //        dt3.Merge(dt2);

    //        GrdSearch.DataSource = dt3;
    //        GrdSearch.DataBind();

    //        GrdSearchSelect.DataSource = dt;
    //        GrdSearchSelect.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
          //  objErr.LogErr("ISYS-SAIM", "MemSearch", "chkSelect1_OnCheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}
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
                    hndDesc.Value =  lbllblcallType0.Text.ToString().Trim();
                }
                else
                {
                    hndDesc.Value = hndDesc.Value + "," + lbllblcallType0.Text.ToString().Trim();
                }
                if (hndCode.Value == "")
                {
                    hndCode.Value =  lbllblcallReqCode0.Text.ToString().Trim();
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
            objErr.LogErr("ISYS-SAIM", "MemSearch", "chkSelect_OnCheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
        if (TxtSearchfield.Text == "" && txtName.Text== "")
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

        for  (int i=0 ;i<dt3.Rows.Count ;i++)
        {

            for (int j = 0; j < dt2.Rows.Count; j++)
            {
               string str1= dt3.Rows[i]["TypeCode"].ToString();
               string str2= dt2.Rows[j]["TypeCode"].ToString();

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
}
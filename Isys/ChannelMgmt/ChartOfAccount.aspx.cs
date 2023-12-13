using CLTMGR;
using DataAccessClassDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Application_Isys_ChannelMgmt_ChartOfAccount : BaseClass
{
    SqlDataReader dtRead;
    string saleschannel;
    string ErrMsg;
    string AuditType;
    string Flag;
    DataSet dsResult = new DataSet();
    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    Hashtable htable = new Hashtable();
    XmlDocument doc = new XmlDocument();
    //  private multilingualManager olng;
    private string strUserLang;
    DataAccessClass objDAL = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    INSCL.App_Code.CommonUtility oCommon = new INSCL.App_Code.CommonUtility();
    string ChnTyp = string.Empty;
    string Insuranctype = string.Empty;
    string Comp = string.Empty;
    string YrIncorporation = string.Empty;
    string LcnNo = string.Empty;
    string RegOfficeAddr = string.Empty;
    protected CommonFunc oCommon1 = new CommonFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            //BindChartData();

            BindGridView();
            GetDetails();
            FillType();
            FillParentGrpCode();
        }


    }
    //protected void BindChartData()
    //{
    //    try
    //    {
    //        {
    //            Hashtable htParam1 = new Hashtable();
    //            DataSet ds = new DataSet();
    //            htParam1.Clear();
    //            htParam1.Add("@Type", "1");
    //            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);
    //            DataTable dt = ds.Tables[0];
    //            ds.Tables[0].Rows[0]["TYPE"].ToString();
    //            DataSet DsNew = new DataSet();
    //            DataSet Ds3 = new DataSet();
    //            //addin div
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                string html = null;
    //                Literal ltrDyn = new Literal();
    //                html = "<html><body>";
    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//Type 1
    //                {

    //                    html = html + "<div id='divChartAcnt" + i + "' style='text-align:left !important;background-color: #fa4848;padding: 7px;width:1180px; color: white;margin-top: 4px;onclick='showDiv('divChartAcnt3', 'btnWfParam" + i + "''); return false;''> <span id='btnWfParam" + i + "' class='glyphicon glyphicon-plus icon' style='float: left; color: white; cursor: pointer;padding-top: 2px '></span>    <label id='lbl" + i + "' runat='server'style='margin-left: 10px;margin-right: 10px;font-size: 15px;' >" + ds.Tables[0].Rows[i]["GRP_NAME"].ToString() + "</label> <img src='Img/Nature_Of_Account_Icon.png' title='" + ds.Tables[0].Rows[i]["TYPE DESC"].ToString() + "'/></div>";
    //                    string StrGRPCode = ds.Tables[0].Rows[i]["GRP_CODE"].ToString();

    //                    htParam1.Clear();
    //                    htParam1.Add("@Type", "2");
    //                    htParam1.Add("@Prnt_GRP_Code", StrGRPCode);
    //                    DsNew = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

    //                    if (DsNew.Tables[0].Rows.Count > 0)
    //                    {
    //                        for (int j = 0; j < DsNew.Tables[0].Rows.Count; j++)////Type 2
    //                        {

    //                            html = html + "<div id='divChartAcnt" + j + "' style='text-align:left !important;background-color: #fa4848;padding: 7px;width:1120px;; color: white;margin-top: 4px;margin-left:14px;onclick='showDiv('DivGrdActMSt', 'btnWfPar'); return false;''> <span id='btnWfParam1" + j + "' class='glyphicon glyphicon-minus icon' style='float: left; color: white; cursor: pointer;padding-top: 2px '></span>    <label id='lbl" + j + "' runat='server'style='margin-left: 10px;margin-right: 10px;font-size: 15px;' >" + DsNew.Tables[0].Rows[j]["GRP_NAME"].ToString() + "</label> <img src='Img/Group_Of_Account_Icon.png' title='" + DsNew.Tables[0].Rows[j]["TYPE DESC"].ToString() + "'/></div>";
    //                            StrGRPCode = DsNew.Tables[0].Rows[j]["GRP_CODE"].ToString();

    //                            Ds3.Clear();
    //                            htParam1.Clear();
    //                            htParam1.Add("@Type", "2");
    //                            htParam1.Add("@Prnt_GRP_Code", StrGRPCode);
    //                            Ds3 = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

    //                            if (Ds3.Tables[0].Rows.Count == 0)
    //                            {
    //                                htParam1.Clear();
    //                                htParam1.Add("@Type", "3");
    //                                htParam1.Add("@Prnt_GRP_Code", StrGRPCode);
    //                                Ds3 = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);
    //                            }


    //                            if (Ds3.Tables[0].Rows.Count > 0 && Ds3.Tables[0].Rows[j]["Type"].ToString() == "2")//Type 3
    //                            {
    //                                html = html + "<div id='divChartAcnt" + j + "' style='text-align:left !important;background-color: #fa4848;padding: 7px;width:1100px;; color: white;margin-top: 4px;margin-left:35px;onclick='showDiv('DivGrdActMSt', 'btnWfPar'); return false;''> <span id='btnWfParam1" + j + "' class='glyphicon glyphicon-minus icon' style='float: left; color: white; cursor: pointer;padding-top: 2px '></span>    <label id='lbl" + j + "' runat='server'style='margin-left: 10px;margin-right: 10px;font-size: 15px;' >" + Ds3.Tables[0].Rows[j]["GRP_NAME"].ToString() + "</label> <img src='Img/Group_Of_Account_Icon.png' title='" + Ds3.Tables[0].Rows[j]["TYPE DESC"].ToString() + "'/></div>";
    //                                StrGRPCode = Ds3.Tables[0].Rows[j]["GRP_CODE"].ToString();
    //                                htParam1.Clear();
    //                                htParam1.Add("@Type", "3");
    //                                htParam1.Add("@Prnt_GRP_Code", StrGRPCode);
    //                                Ds3 = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);
    //                            }


    //                            if (Ds3.Tables[0].Rows.Count > 0 && Ds3.Tables[0].Rows[j]["Type"].ToString() == "3")//Type 3
    //                            {
    //                                html = html + "<div class='content'> <ul class='tree'><ul style='margin-right:49px;'>";
    //                                for (int k = 0; k < Ds3.Tables[0].Rows.Count; k++)
    //                                {

    //                                    html = html + "<li style='margin-left: 24px;'><label id='lbl" + k + "' runat='server'style='margin-left: 10px;margin-right: 10px;font-size: 15px; margin-left: 34px;' >" + Ds3.Tables[0].Rows[k]["GRP_CODE"].ToString() + "" + '-' + "" + Ds3.Tables[0].Rows[k]["GRP_NAME"].ToString() + "</label></li>";

    //                                }
    //                                html = html + "</ ul ></ ul ></ div >";
    //                            }


    //                        }
    //                    }




    //                }


    //                html = html + "</body></html>";
    //                ltrDyn.Text = html;
    //                divChartbody.Controls.Add(ltrDyn);
    //            }






    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    protected void BindGridView()
    {

        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        htParam1.Clear();
        htParam1.Add("@Type", "1");
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dgFirstLevel.DataSource = ds;
            dgFirstLevel.DataBind();

         
        }


    }

    protected void dgFirstLevel_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void dgFirstLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string GRP_Code = ((Label)e.Row.FindControl("lblGRP_Code")).Text;
                Hashtable htParam1 = new Hashtable();
                DataSet ds = new DataSet();
                htParam1.Clear();
                htParam1.Add("@Type", "2");
                htParam1.Add("@Prnt_GRP_Code", GRP_Code);
                ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgSecondLevel.DataSource = ds;
                    dgSecondLevel.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            
        }
    }
    protected void dgSecondLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GRP_Code = ((Label)e.Row.FindControl("lblGRP_Code2")).Text;
            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            htParam1.Add("@Prnt_GRP_Code", GRP_Code);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgThirdLevel.DataSource = ds;
                dgThirdLevel.DataBind();
            }
        }

    }

    protected void dgThirdLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GRP_Code = ((Label)e.Row.FindControl("lblGRP_Code3")).Text;
            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            htParam1.Add("@Prnt_GRP_Code", GRP_Code);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgFourthLevel.DataSource = ds;
                dgFourthLevel.DataBind();
            }
        }
    }

    protected void dgFourthLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string GRP_Code = ((Label)e.Row.FindControl("lblGRP_Code4")).Text;
            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            htParam1.Add("@Prnt_GRP_Code", GRP_Code);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_ChartAccount", htParam1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgFifthLevel.DataSource = ds;
                dgFifthLevel.DataBind();
            }
        }
    }

    protected void dgFifthLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void FillParentGrpCode()
    {
        Hashtable htParam1 = new Hashtable();
        DataSet dsdataset = new DataSet();
        dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_Prnt_GrpCode", htParam1);
        if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
        {
            ddlPrntGrpCode.DataSource = dsdataset;
            ddlPrntGrpCode.DataValueField = "PramValue";
            ddlPrntGrpCode.DataTextField = "PramDesc";
            ddlPrntGrpCode.DataBind();
        }
        ddlPrntGrpCode.Items.Insert(0, "Select (Parent Group Code)");
    }
    protected void FillType()
    {

        Hashtable htParam1 = new Hashtable();
        DataSet dsdataset = new DataSet();

        dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_Fill_Type", htParam1);

        if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
        {

            ddlType.DataSource = dsdataset;
            ddlType.DataValueField = "PramValue";
            ddlType.DataTextField = "PramDesc";
            ddlType.DataBind();
        }
        ddlType.SelectedValue ="2";
        ddlType.Enabled = false;






    }
    protected void GetDetails()
    {

        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        htParam1.Clear();
        gvGrpMater.DataSource = null;
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_Get_Dtails_Grp_Master", htParam1);
        gvGrpMater.DataSource = ds;
        gvGrpMater.DataBind();
        ViewState["SearchBindGrid"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvGrpMater.DataSource = ds;
            gvGrpMater.DataBind();
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvGrpMater.DataSource = ds;
            gvGrpMater.DataBind();
            ViewState["grid"] = ds.Tables[0];

            ////txtPage.Text = dgDetails.PageCount.ToString();
            if (gvGrpMater.PageCount > Convert.ToInt32(txtPage.Text))
            {
                btnCompnext.Enabled = true;
            }
            else
            {
                btnCompnext.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound1(ds.Tables[0], gvGrpMater);
            txtPage.Text = "1";
            btnCompprevious.Enabled = false;
            btnCompnext.Enabled = false;
        }
    }
    protected void lnkBtnSavePopup_Click(object sender, EventArgs e)
    {
        txtGrpCodeId.Text = "";
        txtgrpName.Text = "";
        //ddlType.SelectedIndex = 0;
        ddlPrntGrpCode.SelectedIndex = 0;
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "popupHist();", true);

    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {


        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        string GruopCode = txtGrpCodeId.Text.ToString();
        string GruopName = txtgrpName.Text.ToString();
        string Type = ddlType.SelectedValue.ToString();
        string Type_Desc = ddlType.SelectedItem.ToString();
        string PrntGrpCode = ddlPrntGrpCode.SelectedValue.ToString();

        htParam1.Clear();
        string CreatedBy = HttpContext.Current.Session["UserID"].ToString().Trim();
        htParam1.Add("@CreatedBy", CreatedBy);
        htParam1.Add("@GRP_CODE", GruopCode);
        if (GruopName != null && GruopName.Trim() != "")
        {
            htParam1.Add("@GRP_NAME", GruopName);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Group Name');popupHist();", true);
            return;
        }
        if (PrntGrpCode != null && PrntGrpCode.Trim() != "")
        {
            htParam1.Add("@PRNT_GRP_CODE", PrntGrpCode);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Select Parenet Group Code');popupHist();", true);
            return;
        }

        htParam1.Add("@TYPE", Type);
        htParam1.Add("@TYPE_DESC", Type_Desc);
       
        htParam1.Add("@COUNTERFLAG", PrntGrpCode.Substring(0, 1));
        htParam1.Add("@Action", "INS");



        ds = objDAL.GetDataSetForPrc_SAIM("Prc_Ins_Mst_Group", htParam1);
        if (ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
        {
            txtGrpCodeId.Text = ds.Tables[0].Rows[0]["GRP_CODE"].ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage(); popupHist();", true);
        }


    }

    protected void lnkBtnViewData_Click(object sender, EventArgs e)
    {
        //gvGrpMater.EditIndex = -1;
        GetDetails();

        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);
    }



    protected void gvGrpMater_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {

            Hashtable htobj = new Hashtable();
            DataSet ds = new DataSet();
            GridViewRow row = gvGrpMater.Rows[e.RowIndex];
            string GRP_CODE = ((Label)row.FindControl("lblGrpCode")).Text.ToString();
            htobj.Clear();
            ds.Clear();
            htobj.Add("@GRP_CODE", GRP_CODE);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Delet_Dtails_Grp_Master", htobj);
            if (ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Deleted Successfully');OpenElement();", true);

            }
            GetDetails();

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

    protected void btnCompprevious_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gvGrpMater.PageIndex;
            gvGrpMater.PageIndex = pageIndex - 1;
            // RefreshComGrid();
            GetDetails();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnCompnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvGrpMater.PageCount))
            {
                btnCompprevious.Enabled = false;
            }
            int page = gvGrpMater.PageCount;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "OpenElement();", true);
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

    protected void btnCompnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gvGrpMater.PageIndex;
            gvGrpMater.PageIndex = pageIndex + 1;
            //  RefreshComGrid();
            GetDetails();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnCompprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvGrpMater.PageCount))
            {
                btnCompnext.Enabled = false;
            }
            int page = gvGrpMater.PageCount;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "OpenElement();", true);
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

    private void ShowNoResultFound1(DataTable source, GridView gv)    {        try        {            source.Rows.Add(source.NewRow());            gv.DataSource = source;            gv.DataBind();            int columnsCount = gv.Columns.Count;            int rowsCount = gv.Rows.Count;            gv.Rows[0].Cells[columnsCount - 1].Text = "";            gv.Rows[0].Cells[0].Text = "";            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;            gv.Rows[0].Cells[1].Text = "No compensations have been defined";            source.Rows.Clear();        }        catch (Exception ex)        {
            
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }    }

    protected void gvGrpMater_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == gvGrpMater.EditIndex)
            {



                TextBox txtGrpNameEdit = (TextBox)e.Row.FindControl("txtGrpNameEdit");
                txtGrpNameEdit.Text = ((e.Row.FindControl("lblGrpNameEdit") as Label).Text).ToString();




                DropDownList ddlPrntGrpNameEdit = (DropDownList)e.Row.FindControl("ddlPrntGrpNameEdit");
                DataSet objds = new DataSet();
                Hashtable htParam1 = new Hashtable();
                objds.Clear();
                htParam1.Clear();
                objds = objDAL.GetDataSetForPrc_SAIM("Prc_Prnt_GrpCode", htParam1);
                ddlPrntGrpNameEdit.DataSource = objds;
                ddlPrntGrpNameEdit.DataTextField = "PramDesc";
                ddlPrntGrpNameEdit.DataValueField = "PramValue";
                ddlPrntGrpNameEdit.DataBind();
                ddlPrntGrpNameEdit.Items.Insert(0, new ListItem("Select (Parent Group Name)", "0"));
                string strgrpcode = ((e.Row.FindControl("lblPrntGrpNameEdit") as Label).Text).ToString();

                ddlPrntGrpNameEdit.SelectedValue = strgrpcode.Substring(0, 5);









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

    protected void gvGrpMater_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGrpMater.EditIndex = e.NewEditIndex;
        this.GetDetails();
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);
    }
    protected void GetSearchData(GridView grd)
    {

        try
        {
            if (ViewState["SearchBindGrid"] != null)
            {
                DataSet dtCurrentTable = (DataSet)ViewState["SearchBindGrid"];
                grd.DataSource = dtCurrentTable;
                grd.DataBind();
            }
            else
            {
                this.GetDetails();
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



    protected void gvGrpMater_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Hashtable htParam1 = new Hashtable();
        DataSet objds = new DataSet();
        htParam1.Clear();
        objds.Clear();

        GridViewRow row = gvGrpMater.Rows[e.RowIndex];
        string GrpCode = ((Label)row.FindControl("lblGrpCodeEdit")).Text.ToString();
        string txtGrpName = ((TextBox)row.FindControl("txtGrpNameEdit")).Text.ToString();
        string PrntGrpCodeEdit = ((DropDownList)row.FindControl("ddlPrntGrpNameEdit")).SelectedValue;
        string UpdatedBy = HttpContext.Current.Session["UserID"].ToString().Trim();
        htParam1.Add("@UpdatedBy", UpdatedBy);
         if (txtGrpName != null && txtGrpName.Trim() != "")
        {
            htParam1.Add("@GRP_NAME", txtGrpName);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Group Name');OpenElement();", true);
            return;
        }
        if (PrntGrpCodeEdit != null && PrntGrpCodeEdit.Trim() != "")
        {
            htParam1.Add("@PRNT_GRP_CODE", PrntGrpCodeEdit);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Select Parenet Group Code');OpenElement();", true);
            return;
        }
        htParam1.Add("@GRP_CODE", GrpCode);
       
        
        htParam1.Add("@Action", "UPT");
        objds = objDAL.GetDataSetForPrc_SAIM("Prc_Ins_Mst_Group", htParam1);
        gvGrpMater.EditIndex = -1;
        GetDetails();
        if (objds.Tables[0].Rows[0]["Exists"].ToString() == "Data updated")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Updated Successfully');OpenElement();", true);
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);


    }


    protected void lnkBtnClear_Click(object sender, EventArgs e)
    {
        txtGrpCodeId.Text = "";
        txtgrpName.Text = "";
  
        ddlPrntGrpCode.SelectedIndex = 0;
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "popupHist();", true);
    }



    protected void gvGrpMater_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGrpMater.EditIndex = -1;
        this.GetDetails();
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);
    }
}
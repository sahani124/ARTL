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

public partial class Application_Isys_Saim_CompStpSrchSimu : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            string sUserId = HttpContext.Current.Session["UserID"].ToString();
            GetEnblDsblCtrlsts("", "CompStpSrch", "Page_Load");
            //commented  by prity
            //if (sUserId == "cmpreview" || sUserId == "cmpchecker")
            //{
            //    btnAddNew.Enabled = false;
            //}
            if (!IsPostBack)
            {

                txtPage.Text = "1";
                FillDropDowns(ddlStatus, "11", "");
                if (Request.QueryString["CmpTyp"] != null)
                {
                    FillDropDowns(ddlCompType, "24", Request.QueryString["CmpTyp"].ToString().Trim());
                }
                ddlStatus.Items.Insert(0, new ListItem("Select", ""));
                ddlCompType.Items.Insert(0, new ListItem("Select", ""));
                ddlCompType.SelectedIndex = 1;
                ddlCompType.Enabled = false;
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
                    {
                        ddlStatus.SelectedValue = "1006";
                        ddlStatus.Enabled = false;
                        GetEnblDsblCtrlsts("", "CompStpSrch", "Stmt");
                        //btnAddNew.Visible = false;
                    }
                }
                if (Request.QueryString["Mode"] != null)
                {
                    if (Request.QueryString["Mode"].ToString() == "V")
                    {
                        ddlStatus.SelectedValue = "1006";
                        ddlStatus.Enabled = false;
                        dgCmp.Columns[8].Visible = false;
                        //////tblbtns.Visible = false;                   
                    }
                }
                ////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
                EnblDsblAct();

                //added By bhau
                divChanlWiseCompenDsn.Visible = true;
                GetChannelWiseCompenDesign();
                //End By bhau

                // BindCnstGrid(cmpcode.ToString().Trim(), dgCntst);
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtCompCode.Text = "";
            txtCompDesc1.Text = "";
            ddlStatus.SelectedValue = "";
            ddlCompType.SelectedValue = "";
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "btnCancel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
        try
        {
            EnblDsblAct();
            divChanlWiseCompenDsn.Visible = true;
            GetChannelWiseCompenDesign();

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "btnSearch_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtCompCode.Text = "";
            txtCompDesc1.Text = "";
            EnblDsblAct();
            /////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "btnClear_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(string code, string desc, string type, string status, string flag)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CompCode", code.ToString().Trim());
            htParam.Add("@CompDesc", desc.ToString().Trim());
            htParam.Add("@CompType", type.ToString().Trim());

            htParam.Add("@CompStat", status.ToString().Trim());
            htParam.Add("@Flag", flag.ToString().Trim());
            htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            //ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
	    ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch_SU", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgCmp.DataSource = ds;
                dgCmp.DataBind();
                ViewState["grid"] = ds.Tables[0];

                ////txtPage.Text = dgCmp.PageCount.ToString();
                if (dgCmp.PageCount > Convert.ToInt32(txtPage.Text))
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
                ShowNoResultFound1(ds.Tables[0], dgCmp);
                dgCntst.DataSource = null;
                dgCntst.DataBind();
                txtPage.Text = "1";
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
            dgCmp.Columns[5].Visible = false;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgCmp_Sorting(object sender, GridViewSortEventArgs e)
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
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "dgCmp_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgCmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView dgCntst = (GridView)e.Row.FindControl("dgCntst");

                string cmpcode = dgCmp.DataKeys[e.Row.RowIndex].Value.ToString();
                DataSet dt = new DataSet();
                ViewState["tempcmpcode"] = cmpcode;

                BindCnstGrid(cmpcode.ToString().Trim(), dgCntst, out dt);

                LinkButton lnkCmpCode = (LinkButton)e.Row.FindControl("lnkCmpCode");

                LinkButton lnkVwStmt = (LinkButton)e.Row.FindControl("lnkVwStmt");
                LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
                LinkButton lnkDelCmp = (LinkButton)e.Row.FindControl("lnkDelCmp");

                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "Btch")
                    {
                        if (e.Row.Cells[5].Text == "" || e.Row.Cells[5].Text == "&nbsp;")
                        {
                            e.Row.Cells[5].Text = "NA";
                            e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }



                if (dgCmp.Columns[6].HeaderText == "Status")
                {

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                        if (ds.Tables[0].Rows[e.Row.RowIndex]["STATUS"].ToString() == "APPROVED")
                        {
                            (e.Row.FindControl("lnkDelCmp") as LinkButton).Enabled = false;
                            //dgCmp.Rows[e.Row.RowIndex]["STATUS"] = false;
                            //LinkButton btn1 = (LinkButton)e.Row.FindControl("lnkDelCmp"); 
                            //btn1.Visible = false;
                        }



                    }



                }


            }



        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "dgCmp_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    //    protected void btnprevious_Click(object sender, EventArgs e)
    //    {
    ////New Added Bhaurao
    //        try
    //        {
    //            int pageIndex = dgCmp.PageIndex;
    //            dgCmp.PageIndex = pageIndex - 1;
    //            //dgCmp.DataSource = (DataTable)ViewState["grid"];
    //            dgCmp.DataBind();
    //            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
    //            if (txtPage.Text == "1")
    //            {
    //                btnprevious.Enabled = false;
    //            }
    //            else
    //            {
    //                btnprevious.Enabled = true;
    //            }
    //            btnnext.Enabled = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //            string sRet = oInfo.Name;
    //            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //            String LogClassName = method.ReflectedType.Name;
    //            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //        }
    //    }
    //    protected void btnnext_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            int pageIndex = dgCmp.PageIndex;
    //            dgCmp.PageIndex = pageIndex + 1;
    //            BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
    //            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);

    //            btnprevious.Enabled = true;
    //            int page = dgCmp.PageCount;
    //            if (txtPage.Text == Convert.ToString(dgCmp.PageCount))
    //            {
    //                btnnext.Enabled = false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //            string sRet = oInfo.Name;
    //            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //            String LogClassName = method.ReflectedType.Name;
    //            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //        }
    //    }


    protected void btnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex - 1;
            /////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            EnblDsblAct();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            //BindRevHistGrid(lblCompCodeVal.Text.ToString());
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
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex + 1;
            /////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            EnblDsblAct();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgCmp.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgCmp.PageCount;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnCncl_Click(object sender, EventArgs e)
    {
        txtCompCode.Text = "";
        txtCompDesc1.Text = "";
        ddlStatus.SelectedValue = "";
        ddlCompType.SelectedValue = "";
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["CmpTyp"] != null)
        {
            Response.Redirect("CmpSetupSimu.aspx?flag=N&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim(), true);
        }
    }
    protected void lnkCmpCode_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCmpCode = (LinkButton)grd.FindControl("lnkCmpCode");

        //if (Request.QueryString["Mode"] != null)
        //{
        //    if (Request.QueryString["Mode"].ToString() == "V")
        //    {
        //        Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&mode=V", true);
        //    }
        //    else
        //    {
        //        Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
        //    }
        //}
        //else
        //{
        //    Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
        //}

        //if (Request.QueryString["flag"] != null)
        //{
        //    if (Request.QueryString["flag"].ToString().Trim() == "Btch")
        //    {
        //        Response.Redirect("CmpSetupSimu.aspx?flag=Btch&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
        //    }
        //    else
        //    {
        //        Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
        //    }
        //}
        //else
        //{
        //    Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
        //}
        #region redirect
        try
        {
            if (Request.QueryString["Mode"] != null)
            {
                if (Request.QueryString["Mode"].ToString() == "V")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString().Trim() == "Btch")
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=Btch&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                        else if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=Stmt&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                        else
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "'&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                    }
                    else
                    {
                        Response.Redirect("CmpSetupSimu.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                    }
                    /////Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&mode=V", true);
                }
                else
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString().Trim() == "Btch")
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=Btch&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                        else if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=Stmt&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                        else
                        {
                            Response.Redirect("CmpSetupSimu.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                        }
                    }
                    else
                    {
                        Response.Redirect("CmpSetupSimu.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                    }
                    /////Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);
                }
            }
            else
            {
                Response.Redirect("CmpSetupSimu.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "lnkCmpCode_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        #endregion
    }

    protected void FillDropDowns(DropDownList ddl, string val, string typflg)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@TYPFLG", typflg.ToString().Trim());
            ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
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
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    private void childgridsort(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["gridcnt"];
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
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "childgridsort", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //------------------------------Upper Editable----------------
    protected void dgCntst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            foreach (GridViewRow gvRow1 in dgCntst.Rows)
            {
                LinkButton lnkDelCmp1 = (LinkButton)gvRow1.FindControl("lnkDelCntst");
                lnkDelCmp1.OnClientClick = "return false";
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "dgCntst_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }


        ////dgCntst.Columns[6].Visible = false;
    }
    //protected void lnkCnstCode_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
    //    LinkButton lnkCnstCode = (LinkButton)row.FindControl("lnkCnstCode");
    //    HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");

    //    string strLblcode = lblCmpDsc.Value;
    //    string[] StrcmpCode = strLblcode.Split(',');
    //    if (Request.QueryString["Mode"] != null)
    //    {
    //        if (Request.QueryString["Mode"].ToString() == "V")
    //        {
    //            Response.Redirect("CntstStpView.aspx?CmpCode=" + StrcmpCode[0].ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
    //        }
    //        else
    //        {
    //            Response.Redirect("CntstStp.aspx?CmpCode=" + StrcmpCode[0].ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect("CntstStp.aspx?CmpCode=" + StrcmpCode[0].ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
    //    }
    //    ////Response.Redirect("CmpSetupSimu.aspx?flag=E&CmpCode=" + StrcmpCode[row.RowIndex].ToString().Trim() + "&CntstCode=''", true);
    //}

    protected void BindCnstGrid(string cmpcode, GridView grd, out DataSet ds)
    {
        DataSet ds2 = new DataSet();
        try
        {

            ds2.Clear();
            htParam.Clear();
            htParam.Add("@CmpCode", cmpcode.ToString().Trim());
            ds2 = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls_NEW", htParam);
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds2;
                grd.DataBind();
                ViewState["gridcnt"] = ds2.Tables[0];
                if (grd.PageCount > 1)
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
                ShowNoResultFound(ds2.Tables[0], dgCntst);
            }
            Session["gridcnt"] = ds2.Tables[0];
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "Btch")
                {
                    dgCntst.Columns[6].Visible = false;
                }
                else
                {
                    dgCntst.Columns[6].Visible = true;
                }
            }
            else
            {
                dgCntst.Columns[6].Visible = true;
            }

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "BindCnstGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        ds = ds2;
    }

    protected DataTable GetDataRec(string cmpcode)
    {
        DataSet ds2 = new DataSet();

        try
        {
            ds2.Clear();
            htParam.Clear();
            htParam.Add("@CmpCode", cmpcode.ToString().Trim());
            ds2 = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls_NEW", htParam);
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                return ds2.Tables[0];
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "GetDataRec", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return ds2.Tables[0];
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        try
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
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        try
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            int rowsCount = gv.Rows.Count;
            gv.Rows[0].Cells[columnsCount - 1].Text = "";
            gv.Rows[0].Cells[0].Text = "";
            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[1].Text = "No compensations have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void lnkDelCmp_Click(object sender, EventArgs e)
    //{
    //    string msg = string.Empty;
    //    ds.Clear();
    //    GridViewRow gvrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //    LinkButton lnkCmpCode = (LinkButton)gvrow.FindControl("lnkCmpCode");
    //    htParam.Add("@CMPNSTNCODE", lnkCmpCode.Text.ToString().Trim());
    //    htParam.Add("@FLAG", "1");
    //    htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);


    //    //if (dgCmp.PageCount > 1)
    //    //{
    //    //    txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);

    //    //    if (txtPage.Text != "1")
    //    //    {
    //    //        if (dgCmp.PageCount > Convert.ToInt32(txtPage.Text))
    //    //        {
    //    //            btnnext.Enabled = true;
    //    //        }
    //    //        else
    //    //        {
    //    //            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);

    //    //            if (txtPage.Text == "1")
    //    //            {
    //    //                btnprevious.Enabled = false;
    //    //                btnnext.Enabled = false;
    //    //            }
    //    //            btnnext.Enabled = true;
    //    //        }
    //    //    }
    //    //    btnprevious.Enabled = false;
    //    //}
    //    //else
    //    //{
    //    //    txtPage.Text = "1";
    //    //    btnprevious.Enabled = false;
    //    //    btnnext.Enabled = false;
    //    //}

    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {

    //        msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
    //        if (msg == "NO DELETE")
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contest.This contest is assigned to a contestant');", true);

    //        }

    //    }

    //       int pageIndex = dgCmp.PageIndex;
    //        ////dgCmp.PageIndex = pageIndex - 1;
    //        //dgCmp.DataSource = (DataTable)ViewState["grid"];
    //        dgCmp.DataBind();
    //        txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
    //        if (txtPage.Text == "1")
    //        {
    //            btnprevious.Enabled = false;
    //        }
    //        else
    //        {
    //            btnprevious.Enabled = true;
    //        }
    //        btnnext.Enabled = true;
    //    BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
    //}

    //Added

    //protected void dgCmp_RowDataBound(object sender, GridViewRowEventArgs e)
    //{


    //}

    //protected void lnkDelCmp_Click(object sender, EventArgs e)
    //{
    //    string msg = string.Empty;
    //    ds.Clear();
    //    GridViewRow gvrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //    LinkButton lnkCmpCode = (LinkButton)gvrow.FindControl("lnkCmpCode");
    //    htParam.Add("@CMPNSTNCODE", lnkCmpCode.Text.ToString().Trim());
    //    htParam.Add("@FLAG", "1");
    //    htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);


    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {

    //        msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
    //        if (msg == "NO DELETE")
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contest.This contest is assigned to a contestant');", true);

    //        }

    //    }

    //    int pageIndex = dgCmp.PageIndex;

    //    if (pageIndex == 1)
    //    {
    //        txtPage.Text = "1";
    //        btnprevious.Enabled = false;
    //        btnnext.Enabled = false;
    //    }
    //    else
    //    {
    //        txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
    //        btnprevious.Enabled = true;
    //        btnnext.Enabled = true;

    //    }
    //    BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
    //}

    protected void lnkDelCmp_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = string.Empty;
            ds.Clear();
            GridViewRow gvrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            LinkButton lnkCmpCode = (LinkButton)gvrow.FindControl("lnkCmpCode");
            htParam.Add("@CMPNSTNCODE", lnkCmpCode.Text.ToString().Trim());
            htParam.Add("@FLAG", "1");
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contest.This contest is assigned to a contestant');", true);
                }
                else if (msg == "INVALID STATUS")
                {
                    string strmsg = "Cannot delete this compensation";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strmsg + "');", true);
                }
                else if (msg != "NO DELETE" || msg == "INVALID STATUS")
                {
                    if (msg != "DELETE")
                    {
                        string strmsg = "Compensation is in " + msg.ToString().Trim() + " status";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strmsg + "');", true);
                    }

                }
            }


            /////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            EnblDsblAct();

            int pageIndex = dgCmp.PageIndex;
            if (pageIndex == 1)
            {
                txtPage.Text = "2";
                btnprevious.Enabled = true;
                btnnext.Enabled = true;

            }
            else
            {
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnprevious.Enabled = true;
                btnnext.Enabled = true;

            }
            if (pageIndex == 0)
            {
                txtPage.Text = "1";
                btnprevious.Enabled = false;
                btnnext.Enabled = false;

            }
            EnblDsblAct();
            ////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "lnkDelCmp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkDelCntst_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = string.Empty;
            ds.Clear();
            GridViewRow gvrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lnkCnstCode = (Label)gvrow.FindControl("lnkCnstCode");
            htParam.Add("@CNTSTNCODE", lnkCnstCode.Text.ToString().Trim());
            htParam.Add("@FLAG", "2");
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contestant.KPI is assigned to this contestant');", true);
                }
                else if (msg == "INVALID STATUS")
                {
                    string strmsg = "Cannot delete this contestant";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strmsg + "');", true);
                }
                else if (msg != "NO DELETE" || msg == "INVALID STATUS")
                {
                    string strmsg = "Compensation is in " + msg.ToString().Trim() + " status";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strmsg + "');", true);
                }
            }
            /////BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            EnblDsblAct();
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "lnkDelCntst_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        // LinkButton lnkCmpCode = (LinkButton)grd.FindControl("lnkCmpCode");
        Label lblRuleSetCode = (Label)grd.FindControl("lblRuleSetCode");
        HiddenField hdncmpcode = (HiddenField)grd.FindControl("hdncmp");
        Label hdnCnstCode = (Label)grd.FindControl("lnkCnstCode");

        string[] PARENT = hdncmpcode.Value.ToString().Split(',');
        string cmpcode = PARENT[0];

        /////Response.Redirect("BtchJob.aspx?CmpCode=" + lnkCmpCode.Text.ToString().Trim(), true);
        Response.Redirect("BtchJob.aspx?CmpCode=" + cmpcode.ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
             + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&RuleSetKy=" + lblRuleSetCode.Text.ToString().Trim() + "&CNTSTNT_CODE=" + hdnCnstCode.Text.ToString().Trim(), true);
    }

    protected void EnblDsblAct()
    {
        try
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "Btch")
                {
                    ddlStatus.SelectedValue = "1006";
                    ddlStatus.Enabled = false;
                    GetEnblDsblCtrlsts("", "CompStpSrch", "Btch");
                    //btnAddNew.Visible = false;
                    BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim(), "2");
                    if (dgCmp.Rows.Count > 0 && dgCmp.Rows[0].Cells[1].Text != "No compensations have been defined")
                    {
                        foreach (GridViewRow gvRow in dgCmp.Rows)
                        {
                            LinkButton lnkDelCmp = (LinkButton)gvRow.FindControl("lnkDelCmp");
                            LinkButton lnkView = (LinkButton)gvRow.FindControl("lnkView");
                            lnkDelCmp.Visible = false;
                            lnkView.Visible = true;
                            dgCmp.Columns[4].Visible = false;
                            dgCmp.Columns[5].Visible = true;

                        }
                    }
                    else
                    {
                        dgCmp.Columns[4].Visible = false;
                        dgCmp.Columns[5].Visible = true;
                        dgCmp.Columns[8].Visible = false;
                    }
                }
                else
                {
                    BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim(), "");
                    if (dgCmp.Rows.Count > 0 && dgCmp.Rows[0].Cells[1].Text != "No compensations have been defined")
                    {
                        foreach (GridViewRow gvRow in dgCmp.Rows)
                        {
                            LinkButton lnkDelCmp = (LinkButton)gvRow.FindControl("lnkDelCmp");
                            LinkButton lnkView = (LinkButton)gvRow.FindControl("lnkView");
                            lnkDelCmp.Visible = true;
                            lnkView.Visible = false;
                            dgCmp.Columns[4].Visible = true;
                            dgCmp.Columns[5].Visible = false;

                        }
                    }
                }
            }
            else
            {

                BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim(), "");
                if (dgCmp.Rows.Count > 0 && dgCmp.Rows[0].Cells[1].Text != "No compensations have been defined")
                {
                    foreach (GridViewRow gvRow in dgCmp.Rows)
                    {
                        if (dgCmp.Columns[6].HeaderText == "Status")
                        {
                            if (ds.Tables[0].Rows[gvRow.RowIndex]["STATUS"].ToString() == "APPROVED")
                            {
                                LinkButton lnkDelCmp = (LinkButton)gvRow.FindControl("lnkDelCmp");//lnkDelCntst
                                LinkButton lnkView1 = (LinkButton)gvRow.FindControl("lnkView");
                                lnkDelCmp.OnClientClick = "return false";
                                lnkView1.Visible = false;
                                //foreach (GridViewRow gvRow1 in dgCntst.Rows)
                                //{
                                //    LinkButton lnkDelCmp1 = (LinkButton)gvRow1.FindControl("lnkDelCntst");
                                //    lnkDelCmp1.OnClientClick = "return false";
                                //}
                            }

                        }
                        else
                        {

                            LinkButton lnkDelCmp = (LinkButton)gvRow.FindControl("lnkDelCmp");
                            LinkButton lnkView = (LinkButton)gvRow.FindControl("lnkView");
                            lnkDelCmp.Enabled = true;
                            lnkDelCmp.Visible = true;
                            lnkView.Visible = false;
                            dgCmp.Columns[4].Visible = true;
                            dgCmp.Columns[5].Visible = false;
                        }
                        LinkButton lnkView2 = (LinkButton)gvRow.FindControl("lnkView");
                        lnkView2.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "EnblDsblAct", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //added bhau on 16 april
    protected void GetChannelWiseCompenDesign()
    {
        try
        {
            Hashtable htPara = new Hashtable();
            ds.Clear();
            htPara.Add("@CMPNSTN_TYPE", ddlCompType.SelectedValue);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetDashBoardDtls", htPara);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //SpnAgency.InnerText = ds.Tables[0].Rows[0]["AgencyCount"].ToString();
                //SpanHealth.InnerText = ds.Tables[0].Rows[0]["HealthCount"].ToString();
                //SpanDirect.InnerText = ds.Tables[0].Rows[0]["DirectCount"].ToString();

                SpnAgency.Text = ds.Tables[0].Rows[0]["AgencyCount"].ToString();
                SpanHealth.Text = ds.Tables[0].Rows[0]["HealthCount"].ToString();
                SpanDirect.Text = ds.Tables[0].Rows[0]["DirectCount"].ToString();
            }
            else
            {
                SpnAgency.Text = "0";
                SpanHealth.Text = "0";
                SpanDirect.Text = "0";
            }

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "GetChannelWiseCompenDesign", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //End

    //added BY  PRITY on 4 SEPT 2018
    public void GetEnblDsblCtrlsts(string strCMPNSTN_CODE, string strPAGE_ID, string strFlag)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            string CTRL_ID;

            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", strCMPNSTN_CODE.ToString());
            htParam.Add("@USER_ID", HttpContext.Current.Session["UserID"].ToString());
            htParam.Add("@PAGE_ID", strPAGE_ID.ToString());
            htParam.Add("@FLAG", strFlag);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetEnblDsbl_sts", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();
                    LinkButton lnkbtn = UpdatePanel3.FindControl(CTRL_ID) as LinkButton;
                    lnkbtn.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());

                }
            }

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpSrchSimu", "GetEnblDsblCtrlsts", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //End
}
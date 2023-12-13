using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_Isys_ChannelMgmt_PopViewPage : System.Web.UI.Page
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    DataSet dsmgr = new DataSet();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (HttpContext.Current.Session["SessionId"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
         
            if (!IsPostBack)
            {

                string BizsrcVal = Request.QueryString["Bizsrc"].ToString();
                string ChnClsVal = Request.QueryString["ChnCls"].ToString();
                string AgentTypeVal = Request.QueryString["AgentType"].ToString();
                //string mdlpopup = Request.QueryString["mdlpopup"].ToString();

                //Binddatagrid();
                BindAgentGrid();
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
    #endregion

    #region Binddatagrid
    protected void Binddatagrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsmgr = new DataSet();
            dsmgr.Clear();
            htParam.Clear();

            //htParam.Add("@AgentType", Convert.ToDecimal(Request.QueryString["agttyp"].ToString().Trim()));

            htParam.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            htParam.Add("@ChnlCls", Request.QueryString["schnl"].ToString().Trim());
            htParam.Add("@MemType", Request.QueryString["memtyp"].ToString().Trim());
            htParam.Add("@Reltyp", Request.QueryString["RptSetup"].ToString().Trim());
            
            //htParam.Add("@flag", Request.QueryString["flag"].ToString().Trim());
            //htParam.Add("@chkflag", Request.QueryString["chkflag"].ToString().Trim());
            //htParam.Add("@BsdOn", Request.QueryString["bsdon"].ToString().Trim());
            //htParam.Add("@MemType", "SM"); //Request.QueryString["memtyp"].ToString().Trim()
            //htParam.Add("@RptStp", Request.QueryString["rptstp"].ToString().Trim());
            //htParam.Add("@RptSetup", Request.QueryString["rptsetup"].ToString().Trim());
            //htParam.Add("@Chnl", Request.QueryString["chnl"].ToString().Trim());
            //htParam.Add("@SChnl", Request.QueryString["schnl"].ToString().Trim());
            //htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //if (Request.QueryString["chkflag"] != null)
            //{
            //if (Request.QueryString["untcd"].ToString() != "")
            //{
            //    if (Request.QueryString["agttyp"] != "")
            //    {

                    dsmgr = objDAL.GetDataSetForPrc("PRC_GET_CHILD_FATHER_RELATION_MAPPING", htParam);


            //    }
            //}
            //}

            if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dsmgr;
                gv.DataBind();
                ViewState["gv"] = dsmgr;
                gv.Visible = true;
            }
            else
            {
                //trErrorMsg.Visible = true;
                lblErrorMsg.Visible = true;
                gv.Visible = false;
                lblErrorMsg.Text = " No Records Found ! ";
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' No Records Found ! ');</script>", false);
            }

            dsmgr = null;
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
    #endregion
    #region BindAgentGrid Method
    protected void BindAgentGrid()
    {

        try
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            dsResult.Clear();
            Hashtable htParam = new Hashtable();
            htParam.Add("@BizSrc", Request.QueryString["Bizsrc"].ToString());
            htParam.Add("@ChnCls", Request.QueryString["ChnCls"].ToString());
            htParam.Add("@AgnType", Request.QueryString["AgentType"].ToString());
            dsResult = objDAL.GetDataSetForPrc("Prc_GetActInActUnitType", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    trAgentTypes.Visible = true;
                    gv.DataSource = dsResult.Tables[0];
                    gv.DataBind();
                    divPagingBtn.Visible = true;
                }
                else
                {

                    //Added by @Raj for no recods found from the database starts..

                    dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());
                    gv.DataSource = dsResult.Tables[0];
                    gv.DataBind();
                    int columnsCount = gv.Columns.Count;
                    gv.Rows[0].Cells.Clear();
                    gv.Rows[0].Cells.Add(new TableCell());
                    gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
                    gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gv.Rows[0].Cells[0].Font.Bold = true;
                    gv.Rows[0].Cells[0].Text = "No Records Found!";
                    dsResult.Tables[0].Rows.Clear();
                    gv.Visible = true;
                    divPagingBtn.Visible = false;

                    //Added by @Raj for no recods found from the database Ends..
                }
            }
            else
            {
                trAgentTypes.Visible = false;
                gv.DataSource = null;
                gv.DataBind();
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
    #endregion





    #region gv_RowDataBound
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkMgrCode = new LinkButton();
            LinkButton lnkUnitCode = new LinkButton();
            LinkButton lnkMemtyp = new LinkButton();

            lnkMgrCode = (LinkButton)e.Row.FindControl("lnk");
            lnkUnitCode = (LinkButton)e.Row.FindControl("lnkUnitCode");
            lnkMemtyp = (LinkButton)e.Row.FindControl("lnkMemtyp");


            /////lnkMgrCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + e.Row.Cells[2].Text.Trim() + "','" + lnkUnitCode.Text.Trim() + "','" + lnkMemtyp.Text.Trim() + "','" + e.Row.Cells[1].Text + "');return false;");
        }
    }
    #endregion

    #region gv_Sorting
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gv_PageIndexChanging
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv.PageIndex = e.NewPageIndex;
            dv.Sort = gv.Attributes["SortExpression"];

            if (gv.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv.DataSource = dv;
            gv.DataBind();
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
    #endregion



    #region ChkSelect_CheckedChanged
    //protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    //{
    //    #region CHECKBOX validation
    //    htParam.Clear();
    //    htParam.Add("@BizSrc", Request.QueryString["bizsrc"].ToString().Trim());
    //    htParam.Add("@ChnCls", Request.QueryString["schnl"].ToString().Trim());
    //    htParam.Add("@MemType", Request.QueryString["memtyp"].ToString().Trim());
    //    dsmgr = objDAL.GetDataSetForPrcCLP("Prc_GetUntLocn", htParam);
    //    #endregion

    //    if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
    //    {
    //        if (dsmgr.Tables[0].Rows[0]["UnitLocation"].ToString().Trim() == "0")
    //        {
    //            var activeCheckBox = sender as CheckBox;
    //            var count = 0;
    //            if (activeCheckBox != null)
    //            {
    //                var isChecked = activeCheckBox.Checked;
    //                var tempCheckBox = new CheckBox();
    //                foreach (GridViewRow gvRow in gv.Rows)
    //                {
    //                    tempCheckBox = gvRow.FindControl("ChkSelect") as CheckBox;
    //                    if (tempCheckBox != null)
    //                    {
    //                        tempCheckBox.Checked = !isChecked;
    //                    }
    //                    //if (tempCheckBox.Checked == true)
    //                    //{
    //                    //    count = count + 1;
    //                    //}
    //                    //if (count > 1)
    //                    //{
    //                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Cannot select more than ont unit');", true);
    //                    //    tempCheckBox.Checked = false;
    //                    //}
    //                }

    //                if (isChecked)
    //                {
    //                    activeCheckBox.Checked = true;
    //                }
    //            }
    //        }
    //    }

    //}
    #endregion


    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex - 1;
            Binddatagrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex + 1;
            Binddatagrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = gv.PageCount;
            if (txtPage.Text == Convert.ToString(gv.PageCount))
            {
                btnnext.Enabled = false;

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

  

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        string BizsrcVal = Request.QueryString["Bizsrc"].ToString();
        string ChnClsVal = Request.QueryString["ChnCls"].ToString();
       Response.Redirect("UnitNew.aspx?chncls=" + BizsrcVal + "&SubClass=" + ChnClsVal + "&flag=N");

    }
}

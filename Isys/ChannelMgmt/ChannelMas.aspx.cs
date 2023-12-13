//Creator:		    <Ajay Yadav> 
//Create date:      <17th Sep 2021>
//Description:	    <This page is created for Channel Setup.(Code Optimization)>

#region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
#endregion

namespace INSCL
{
    public partial class ChannelMas : Base
    {

        #region Global Declarations
        DataAccessClass objDAL = new DataAccessClass(); 
        Hashtable htParam = new Hashtable();
        DataSet dsResult = new DataSet();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        string strValue = string.Empty;
        #endregion

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            FunCheckSession();
            Session["CarrierCode"] ='2';
            if (!IsPostBack)
            {
               this.RefreshGrid();
               if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
               {
                   btnAddNew.Enabled = false;
               }
            }
        }
        #endregion

        #region REFRESHGRID
        private void RefreshGrid()
        {
            try
            {
                htParam.Clear();
                htParam.Add("@ChannelType", "C");
                FillGridView(htParam, dgDetails, "prc_ChannelSetup", "INSCCommonConnectionString"); 
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "RefreshGrid", ex);
            }
        }
        #endregion
    
        #region Button 'btnAddNew' Click Event
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ChannelSetup.aspx?ChnTyp=C&flag=N&mdlpopup=mdlpopup", false);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "dgDetails_PageIndexChanging", ex);
            }
        }
        #endregion    

        #region PAGEINDEX
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = GetDisplay();
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;
                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "dgDetails_PageIndexChanging", ex);
            }
        }
        #endregion

        #region ROWDATABOUND
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "XX" || e.Row.Cells[0].Text == "AG" || e.Row.Cells[0].Text == "BA")
                {
                    Session["stBizsrc"] = e.Row.Cells[0].Text;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                Label lblChannelDesc01 = (Label)e.Row.FindControl("lblChannelDesc01");
                if (strValue == "YES")
                {
                    l.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    l.Enabled = false;
                }
                l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete channel for " + lblChannelDesc01.Text.Trim() + "?')");
            }
        }
        #endregion

        #region SORTING
        protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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
            DataTable dt = GetDisplay();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
           ShowPageInformation();
       }
        #endregion      

        #region GETDISPLAY
       public DataTable GetDisplay()
        {
            DataSet dsdataset = new DataSet();
            try
            {
                htParam.Add("@ChannelType", "C");
                dsdataset = objDAL.GetDataSetForPrcCLP("prc_ChannelSetup", htParam);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "GetDisplay", ex);
            }
            return dsdataset.Tables[0];
        }
        #endregion

        #region ShowPageInformation
        private void ShowPageInformation()
        {
            try
            {
                int intPageIndex = dgDetails.PageIndex + 1;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "ShowPageInformation", ex);
            }
        }
        #endregion

        #region ShowNoResultFound
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
                gv.Rows[0].Cells[0].Text = "No Partner Channel have been defined";
                source.Rows.Clear();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "ShowNoResultFound", ex);
            }
        }
        #endregion

        #region ChannelCode Click Event
        protected void lbBizSrc_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
                LinkButton lbChnCls1 = (LinkButton)grd.FindControl("lbBizSrc");
                Label lblChannelDesc01 = (Label)grd.FindControl("lblChannelDesc01");
                Label lblSortOrder = (Label)grd.FindControl("lblSortOrder");
                Response.Redirect("ChannelSetup.aspx?ChnTyp=C&flag=''&ChnCls=" + lbChnCls1.Text + "&ChnDesc01=" + lblChannelDesc01.Text + "&SortOrder=" + lblSortOrder.Text + "&mdlpopup=mdlpopup");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "lbBizSrc_Click", ex);
            }
        }
       #endregion

        #region Paging for dgDetails 
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
               int pageIndex = dgDetails.PageIndex;
               dgDetails.PageIndex = pageIndex + 1;
               RefreshGrid();
               txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
               btnprevious.Enabled = true;
               if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
               {
                   btnnext.Enabled = false;
               }
               int page = dgDetails.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "btnnext_Click", ex);
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
           try
           {
               int pageIndex = dgDetails.PageIndex;
               dgDetails.PageIndex = pageIndex - 1;
               RefreshGrid();
               txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
               btnnext.Enabled = true;
               if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
               {
                   btnprevious.Enabled = false;
               }
               int page = dgDetails.PageCount;
               if (txtPage.Text == "1")
               {
                   btnprevious.Enabled = false;
               }
               else
               {
                   btnprevious.Enabled = true;
               }
           }
           catch (Exception ex)
           {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "btnprevious_Click", ex);
           }
        }
        #endregion
       
        #region Hierarchy Events
       protected void lnkbtnHumanHierarchy_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
                LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
                hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup"
                //    ,"OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','CHN')", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
      "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','CHN')", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "lnkbtnHumanHierarchy_Click", ex);
            }
        }

        protected void lnkbtnLocationHierarchy_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
                LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
                hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup","OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','chnUNT')", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "lnkbtnLocationHierarchy_Click", ex);
            }
        }

       //protected void lbLAbc_Click(object sender, EventArgs e)
       // {
       //     try
       //     {
       //         GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
       //         LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
       //         hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
       //         ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
       //         "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','chncls')", true);
       //     }
       //     catch (Exception ex)
       //     {
       //         LogException("ISYS-CHMS", "ChannelMas.aspx", "lbLAbc_Click", ex);
       //     }
       // }
        #endregion

        protected void lnkMem_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
            "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','member')", true);
        }

        protected void lnkbtnUnit_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
            "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','Unt')", true);
        }

        //protected void lnkbtnActSub_Click(object sender, EventArgs e)
        //{
        //    GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        //    LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
        //    hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
        //    "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','SubAct')", true);
        //}
        //ADDED BY AJAY 27 MAY 2023
        protected void lnkbtnchnlCease_Click(object sender, EventArgs e)
        {
            //GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            //LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbBizSrc");
            //hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ////ADDED BY AJAY 23 MAY 2023
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "openMoveTo()", true);
            //Binddatagrid();
            //BindAgentGrid();
        }
        ////Unit TYPE GRIDVIEW START
        //#region Binddatagrid
        //protected void Binddatagrid()
        //{
        //    try
        //    {
        //        Hashtable htParam = new Hashtable();
        //        DataSet dsmgr = new DataSet();
        //        dsmgr.Clear();
        //        htParam.Clear();
        //        htParam.Add("@Bizsrc", hdnselectedBizsrc.Value);// Request.QueryString["bizsrc"].ToString().Trim());
        //        dsmgr = objDAL.GetDataSetForPrc("Prc_getunittype_count", htParam);
        //        if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
        //        {
        //            gv.DataSource = dsmgr;
        //            gv.DataBind();
        //            ViewState["gv"] = dsmgr;
        //            gv.Visible = true;
        //        }
        //        else
        //        {
        //            dsmgr.Tables[0].Rows.Add(dsmgr.Tables[0].NewRow());
        //            gv.DataSource = dsmgr.Tables[0];
        //            gv.DataBind();
        //            int columnsCount = gv.Columns.Count;
        //            gv.Rows[0].Cells.Clear();
        //            gv.Rows[0].Cells.Add(new TableCell());
        //            gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
        //            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        //            gv.Rows[0].Cells[0].Font.Bold = true;
        //            gv.Rows[0].Cells[0].Text = "No Records Found!";
        //            dsmgr.Tables[0].Rows.Clear();
        //            gv.Visible = true;
        //        }
        //        dsmgr = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException("ISYS-CHMS", "ChannelMas.aspx", "lbLAbc_Click", ex);
        //    }
        //}
        //#endregion

        ////MEMBER TYPE GRIDVIEW START
        //protected void BindAgentGrid()
        //{
        //    try
        //    {
        //        string strSql = string.Empty;
        //        DataSet dsResult = new DataSet();
        //        dsResult.Clear();
        //        Hashtable htParam = new Hashtable();
        //        htParam.Add("@BizSrc", hdnselectedBizsrc.Value);//Request.QueryString["Bizsrc"].ToString());
        //        dsResult = objDAL.GetDataSetForPrc("Prc_getmemtype_count", htParam);
        //        if (dsResult.Tables.Count > 0)
        //        {
        //            if (dsResult.Tables[0].Rows.Count > 0)
        //            {
        //                Label3.Visible = true;
        //                gvmem.DataSource = dsResult.Tables[0];
        //                ViewState["gvmem"] = dsResult.Tables[0];
        //                gvmem.DataBind();
        //            }
        //            else
        //            {
        //                dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());
        //                gvmem.DataSource = dsResult.Tables[0];
        //                gvmem.DataBind();
        //                int columnsCount = gvmem.Columns.Count;
        //                gvmem.Rows[0].Cells.Clear();
        //                gvmem.Rows[0].Cells.Add(new TableCell());
        //                gvmem.Rows[0].Cells[0].ColumnSpan = columnsCount;
        //                gvmem.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //                gvmem.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        //                gvmem.Rows[0].Cells[0].Font.Bold = true;
        //                gvmem.Rows[0].Cells[0].Text = "No Records Found!";
        //                dsResult.Tables[0].Rows.Clear();
        //                gvmem.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            Label3.Visible = false;
        //            gvmem.DataSource = null;
        //            gvmem.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException("ISYS-CHMS", "ChannelMas.aspx", "lbLAbc_Click", ex);
        //    }
        //}
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
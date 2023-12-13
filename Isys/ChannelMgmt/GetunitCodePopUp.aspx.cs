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
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
namespace INSCL
{
    public partial class GetunitCodePopUp : BaseClass
    {
        /// <summary>
        /// Page Name:  GetunitCodePopUp.aspx
        /// Purpose:    To Allow User To Search For Unit
        /// Created By: Saurabh Nayar
        /// Created On: 18 Aug 2007
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        ErrLog objErr = new ErrLog();
        private multilingualManager olng;
        private string strUserLang;
		DataSet dsResult = new DataSet();
		Hashtable htParam = new Hashtable();
		//obj added by nitin
        DataAccessClass objDAL = new DataAccessClass();
		//INSCL.DAL.DataAccessLayer objDAL = new INSCL.DAL.DataAccessLayer();
		App_Code.CommonUtility objCommonU = new App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        #region PAGE_LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
		if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "GetunitCodePopUp.aspx", strUserLang);
            Session["CarrierCode"] ='2';
            if (!IsPostBack)
            {
                InitializeControl();
				//trDetails.Visible = false;
				// trdgDetails.Visible = false;
                objCommonU.GetSalesChannel(ddlSlsChannel, "", 0);
                ddlSlsChannel.Items.Insert(0, new ListItem("Select ", ""));
                if (Request.QueryString["Code"] != null)
                {
                    txtUnitCode.Text = Request.QueryString["Code"].ToString();
                }
                if (Request.QueryString["Field3"].Trim() != "")
                {
                    foreach (ListItem lstItem in ddlSlsChannel.Items)
                    {
                        if (lstItem.Value == Request.QueryString["Field3"].Trim())
                        {
                            ddlSlsChannel.SelectedValue = Request.QueryString["Field3"].Trim();
                            ddlSlsChannel.Enabled = false;
                        }
                    }
                }
                demo.Style.Add("display", "none");
                //Commented By Saurabh Nayar On 20071025
                //DataTable dt;
                //try
                //{
                //    dt = GetDataTable();
                //    if (dt.Rows.Count > 0)
                //    {
                //        dgDetails.DataSource = dt;
                //        dgDetails.DataBind();
                //        lblMessage.Text = "";
                //        lblMessage.Visible = false;
                //        ShowPageInformation();
                //    }
                //    else
                //    {
                //        dgDetails.DataSource = null;
                //        dgDetails.DataBind();
                //        // lblPageInfo.Text = "";
                //        lblMessage.Visible = true;
                //        lblMessage.Text = "0 RECORD FOUND.";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    dgDetails.DataSource = null;
                //    dgDetails.DataBind();
                //    // lblPageInfo.Text = "";
                //    lblMessage.Visible = true;
                //    lblMessage.Text = ex.Message;
                //}
                //End Of Comment By Saurabh Nayar On 20071025
            }
        }
        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            //lblSalesChannel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSalesChannel.Text"));
            //lblUntCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblUntCode.Text"));
            //lblUntName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblUntName.Text"));

            lblSalesChannel.Text = "Sales Channel";//ObjDec.GetDecData(olng.GetItemDesc("lblSalesChannel.Text"));
            lblUntCode.Text = "Unit Code";//ObjDec.GetDecData(olng.GetItemDesc("lblUntCode.Text"));
            lblUntName.Text = "Unit Name";//ObjDec.GetDecData(olng.GetItemDesc("lblUntName.Text"));
         }
        #endregion

        #region BUTTON 'btnSearch' ONCLICK EVENT
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //tbMsg.Visible = true;
			this.BindDataGrid();
        }
        #endregion
		#region METHOD 'BindDatagrid()' DEFINITION
		protected void BindDataGrid()
		{

			htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
			htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
			htParam.Add("@bizSrc", ddlSlsChannel.SelectedValue);
			htParam.Add("@UnitName", txtUnitName.Text);
			htParam.Add("@UnitCode", txtUnitCode.Text);
			//changed by nitin
			dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_UnitList", htParam);
			if (dsResult.Tables.Count > 0)
			{
				if (dsResult.Tables[0].Rows.Count > 0)
				{
                    demo.Style.Add("display", "block");
                    divPage.Style.Add("display", "block");
					dgDetails.DataSource = dsResult.Tables[0];
					dgDetails.DataBind();
					lblMessage.Text = "";
					lblMessage.Visible = false;
                    //tbMsg.Visible = true;
					//trDetails.Visible = true;
					//trdgDetails.Visible = true;
					ShowPageInformation();
				}
				else
				{
					dgDetails.DataSource = null;
					dgDetails.DataBind();
					//trDetails.Visible = false;
					// trdgDetails.Visible = false;
					// lblPageInfo.Text = "";
					lblMessage.Visible = true;
                 // tbMsg.Visible = false;
					lblMessage.Text = "0 RECORD FOUND.";
				}
			}
			else
			{
				dgDetails.DataSource = null;
				dgDetails.DataBind();
				//trDetails.Visible = false;
				// trdgDetails.Visible = false;
				// lblPageInfo.Text = "";
				lblMessage.Visible = true;
             // tbMsg.Visible = false;
				lblMessage.Text = "0 RECORD FOUND.";
			}
			dsResult = null;
			htParam.Clear();
		}
		#endregion
        #region METHOD 'GetDataTable()' DEFINITION
        protected DataTable GetDataTable()
        {
            
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            htParam.Add("@bizSrc", ddlSlsChannel.SelectedValue);
            htParam.Add("@UnitName", txtUnitName.Text);
            htParam.Add("@UnitCode", txtUnitCode.Text);
			//changed by nitin
            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_UnitList", htParam);
			htParam.Clear();
            return dsResult.Tables[0];
        }
        #endregion

        #region DATAGRID 'dgDetails' ROWDATABOUND EVENT
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUnitCode");
                    string str = ((HiddenField)e.Row.Cells[4].FindControl("HdnCompCode")).Value;   //added code by Venkat on 16/10/07
                    lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[0].Text.Trim() + "','" + str + "');return false;");
                }
            }
        }
        #endregion
        
        #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = GetDataTable();
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
        #endregion

        #region DATAGRID 'dgDetails' SORT EVENT
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

            DataTable dt = GetDataTable();
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

        #region METHOD 'ShowPageInformation'
        /// <summary>
        /// This method displays paging information in the appropriate label
        /// </summary>
        private void ShowPageInformation()
        {
            int intPageIndex = dgDetails.PageIndex + 1;
            //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        }
        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUnitCode.Text = "";
            txtUnitName.Text = "";
            ddlSlsChannel.SelectedIndex =0;
            //dgDetails.Visible = false;
            //lblPageInfo.Visible = false;
            ////trDetails.Visible = false;
         // tbMsg.Visible = false;
	    lblMessage.Text = "";

        }


        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {


                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                BindDataGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnnext.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnprevious.Enabled = false;
                }
                int page = dgDetails.PageCount;
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


                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                BindDataGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
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
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }


    }
}

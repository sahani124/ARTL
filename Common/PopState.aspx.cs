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
using Insc.Common.Multilingual;
using CLTMGR;
public partial class Application_Receipt_PopLocation : BaseClass
{
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();
    private multilingualManager olng;
     EncodeDecode ObjDec = new EncodeDecode();
     ErrLog objErr = new ErrLog();
     #region page load
     protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (HttpContext.Current.Session["SessionId"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            olng = new multilingualManager("DefaultConn", "PopState.aspx", Session["UserLangNum"].ToString());

            txtStateCode.Focus();

            if (!IsPostBack)
            {
                InitializeControl();
                ViewState["SortField"] = String.Empty;
                ViewState["SortDirection"] = String.Empty;

                if ((Request.QueryString["Code"].ToString() != String.Empty) || (Request.QueryString["Desc"].ToString() != String.Empty))
                {
                    txtStateCode.Text = Request.QueryString["Code"].ToString();
                    txtStateDesc.Text = Request.QueryString["Desc"].ToString();

                    subGetRec(0, String.Empty, String.Empty);
                }
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
     //Add By Darshik 16/05/2012
     #region InitializeControl()
     private void InitializeControl()
    {
        try
        {
            lblStateCode.Text = olng.GetItemDesc("lblStateCode");
            lblStateDesc.Text = olng.GetItemDesc("lblStateDesc");
            lblErrMsg.Text = olng.GetItemDesc("lblErrMsg");
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

     #region subGetRec
     private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        try
        {
            string strSQL = "prc_LookupState_sel " +
               oCommon.fncFormatSQLParam(Session["UserLangNum"].ToString()) + "," +
               oCommon.fncFormatSQLParam(txtStateCode.Text.Trim()) + "," +
               oCommon.fncFormatSQLParam(txtStateDesc.Text.Trim());

            DataView dv = new DataView(oDP.ReadData("INSCDirectConnectionString", strSQL).Tables[0]);

            if (strSortField == String.Empty)
            {
                dv.ApplyDefaultSort = true;
            }
            else
            {
                dv.Sort = strSortField + " " + strSortDirection;
            }

            gv.DataSource = dv;
            gv.PageIndex = intPage;
            gv.DataBind();

            lblErrMsg.Visible = (gv.Rows.Count == 0) ? true : false;

            dv = null;
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

     #region btnSearch_Click
     protected void btnSearch_Click(object sender, EventArgs e)
    {
        subGetRec(0, String.Empty, String.Empty);
    }
     #endregion

     #region Sorting
     protected void gv_Sorting(Object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression == ViewState["SortField"].ToString())
            {
                switch (ViewState["SortDirection"].ToString())
                {
                    case "ASC":
                        ViewState["SortDirection"] = "DESC";
                        break;

                    case "DESC":
                        ViewState["SortDirection"] = "ASC";
                        break;
                }
            }
            else
            {
                ViewState["SortField"] = e.SortExpression;
                ViewState["SortDirection"] = "ASC";
            }

            subGetRec(gv.PageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());
        }
        catch (Exception ex)
        {
             string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw;
        }
    }
     #endregion

     #region gv_PageIndexChanging
     protected void gv_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        subGetRec(e.NewPageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());
    }
     #endregion

     #region gv_RowDataBound
     protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = new LinkButton();
                lnk = (LinkButton)e.Row.FindControl("lnk");
                lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim() + "');return false;");
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
}

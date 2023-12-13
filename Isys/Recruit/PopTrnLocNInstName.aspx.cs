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
using System.Data.SqlClient;
using INSCL.DAL;
using INSCL.App_Code;
using System.Text;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_INSC_PopTrnLocNInstName : BaseClass
{
    #region Global Declaration
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();
//    private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    private multilingualManager olng;
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    #endregion
    #region Page_Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            olng = new multilingualManager("DefaultConn", "PopTrnLocNInstName.aspx", Session["UserLangNum"].ToString());
            if (!IsPostBack)
            {
                //InitializeControl();
                ViewState["SortField"] = String.Empty;
                ViewState["SortDirection"] = String.Empty;
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["Page"].ToString().Trim() == "TrnInst")
                    {
                        divTrnInstitute.Visible = true;
                        Page.Title = "Search Training Institute";
                    }
                    if (Request.QueryString["Page"].ToString().Trim() == "TrnLoc")
                    {
                        divTrnLoc.Visible = true;
                        Page.Title = "Search Training Location";
                    }
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
    #region InitializeControl()
    private void InitializeControl()
    {
        try
        {
            lblTrnLocCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTrnLocCode"));
            lblTrnLocName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTrnLocName"));
            lblTrnInstCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTrnInstCode"));
            lblTrnInstName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTrnInstName"));
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
    #region btnSearch_Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        subGetRec(0, String.Empty, String.Empty);
    }
    #endregion
    #region subGetRec()   
    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        try
        {
            string strSQL = string.Empty;
            SqlDataReader drResult;
            Hashtable htInst = new Hashtable();
            if (Request.QueryString.Count > 0)
            {
                //Added by rachana on 08-07-2013 for getting records by Prc_GetrecordsForinstitute start
                string stronline = Convert.ToString(Request.QueryString["TrnMode"]).Trim();
                string strTrnInstCode = txtTrnInstCode.Text;
                string strTrnInstName = txtTrnInstName.Text;

                //Added by rachana on 08-07-2013 for getting records by Prc_GetrecordsForinstitute end
                DataTable dtResult = new DataTable();
                DataView dv;
                //Added by rachana on 08-07-2013 for getting records by Prc_GetrecordsForinstitute start
                if (Request.QueryString["Page"].ToString().Trim() == "TrnInst")
                {
                    string strTrnLoc;
                    #region Location search
                    if (Request.QueryString["Page"].ToString().Trim() == "TrnInst")
                    {
                        strTrnLoc = Convert.ToString(Request.QueryString["TrnLoc"]).Trim();
                    }
                    else
                    {
                        strTrnLoc = string.Empty;
                    }
                    #endregion
                    if (stronline == "Online")
                    {
                        if (txtTrnInstCode.Text.ToString().Trim() != "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + "','','Icod'").Tables[0];
                        }
                        if (txtTrnInstName.Text.ToString().Trim() != "")
                        {
                            // dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + ", Iloc").Tables[0];
                            dtResult.Clear();
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + "','','Iloc'").Tables[0];
                        }
                        else if (txtTrnInstCode.Text.ToString().Trim() == "" && txtTrnInstName.Text.ToString().Trim() == "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online','','','" + strTrnLoc + "','Iall'").Tables[0];
                        }
                    }
                    else
                    {
                        if (txtTrnInstCode.Text.ToString().Trim() != "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + "','','Icod'").Tables[0];
                        }
                        if (txtTrnInstName.Text.ToString().Trim() != "")
                        {
                            // dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + ", Iloc").Tables[0];
                            dtResult.Clear();
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + "','','Iloc'").Tables[0];
                        }
                        else if (txtTrnInstCode.Text.ToString().Trim() == "" && txtTrnInstName.Text.ToString().Trim() == "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online','','','','Iall'").Tables[0];
                        }
                    }
                }
                else if (Request.QueryString["Page"].ToString().Trim() == "TrnLoc")
                {
                    string strTrnInstitute;
                    #region institute search
                    if (Request.QueryString["Page"].ToString().Trim() == "TrnLoc")
                    {
                        strTrnInstitute = string.Empty;
                        strTrnInstitute = Convert.ToString(Request.QueryString["TrnInst"]).Trim();
                    }
                    else
                    {
                        strTrnInstitute = string.Empty;
                    }
                    #endregion
                    if (stronline == "Online")
                    {
                        if (txtTrnLocCode.Text.ToString().Trim() != "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + strTrnInstitute + "','" + txtTrnLocName.Text + "','" + txtTrnLocCode.Text + "','Lcod'").Tables[0];
                        }
                        if (txtTrnLocName.Text.ToString().Trim() != "")
                        {
                            // dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + ", Iloc").Tables[0];
                            dtResult.Clear();
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + strTrnInstitute + "','" + txtTrnLocName.Text + "','" + txtTrnLocCode.Text + "','Lloc'").Tables[0];
                        }
                        else if (txtTrnLocCode.Text.ToString().Trim() == "" && txtTrnLocName.Text.ToString().Trim() == "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + strTrnInstitute + "','','','Lall'").Tables[0];

                        }
                    }
                    else
                    {
                        if (txtTrnLocCode.Text.ToString().Trim() != "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnLocCode.Text + "','" + txtTrnLocName.Text + "','" + strTrnInstitute + "','Lcod'").Tables[0];
                        }
                        if (txtTrnLocName.Text.ToString().Trim() != "")
                        {
                            // dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online" + txtTrnInstCode.Text + "','" + txtTrnInstName.Text + ", Iloc").Tables[0];
                            dtResult.Clear();
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute 2,'Online','" + txtTrnLocCode.Text + "','" + txtTrnLocName.Text + "','" + strTrnInstitute + "','Lloc'").Tables[0];
                        }
                        else if (txtTrnLocCode.Text.ToString().Trim() == "" && txtTrnLocName.Text.ToString().Trim() == "")
                        {
                            dtResult = oDP.ReadData("INSCRecruitConnectionString", "Prc_GetrecordsForinstitute '2','Online','','','" + strTrnInstitute + "','Lloc'").Tables[0];
                        }
                    }
                }

                //Added by rachana on 08-07-2013 for getting records by Prc_GetrecordsForinstitute end
                if (dtResult.Rows.Count > 0)
                {
                    divDGList.Visible = true;
                    lblMessage.Visible = false;
                    dv = new DataView(dtResult);

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

                    dv = null;
                }
                else
                {
                    gv.DataSource = null;
                    gv.DataBind();
                    lblMessage.Text = "0 Record Found.";
                    lblMessage.Visible = true;
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
    #region gv_Sorting
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
        }
    }
    #endregion
    #region gv_PageIndexChanging Event
    protected void gv_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        try
        {
            subGetRec(e.NewPageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());

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
    #region gv_RowDataBound Event
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = new LinkButton();
                lnk = (LinkButton)e.Row.FindControl("lnk");

                HiddenField hdnECCode = (HiddenField)e.Row.FindControl("hdnECCode");

                lnk.Attributes.Add("onclick", "doSelect('" + hdnECCode.Value.ToString().Trim() + "','" + lnk.Text + "');return false;");
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

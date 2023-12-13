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
using INSCL.DAL;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;


public partial class Application_Isys_ChannelMgmt_CeaseDtls : BaseClass
{
    #region Global Declaration
    Hashtable ht;
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtprodCode.Text = Request.QueryString["Productcode"];
                txtprodname.Text = Request.QueryString["ProductName"];
                txteffDtim.Text = Request.QueryString["Effectivedate"];
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel();", true);
    }
    protected void lnkbtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            ht = new Hashtable();
            ht.Clear();
            ht.Add("@ProdCode", txtprodCode.Text.Trim());
            ht.Add("@ProdName", txtprodname.Text.Trim());
            ht.Add("@CeaseDtim", txtceaseDtim.Text.Trim());
            ht.Add("@userid", HttpContext.Current.Session["UserID"].ToString().Trim());
            objDAL.execute_sprcIsysTemp("PrcUpdateProductCeaseDtim", ht);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product is ceased successfully')", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel();", true);
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
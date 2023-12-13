using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using DataAccessClassDAL;

public partial class Application_INSC_ChannelMgmt_MomEmpInbox : BaseClass
{
    DataAccessClass DtAccess = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGridInbox();
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

    private void BindGridInbox()
    {
        if (Cache["dsResult"] != null)
        {
            GridInbox.DataSource = Cache["dsResult"];
            GridInbox.DataBind();
        }
        else
        {
            dsResult = DtAccess.GetDataSetForPrcCommon("Prc_MomEmpAgnMap");
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                Cache["dsResult"] = dsResult.Tables[0];
                GridInbox.DataSource = dsResult.Tables[0];
                GridInbox.DataBind();

            }
        }
    }
    protected void lbCreteEmp_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbCreteEmp");
        Label lblEmpCode = (Label)row.FindControl("lblEmpCode");
        Response.Redirect("../../Common/CltEnquiry.aspx?Type=MomEmp&SapCode=" + lblEmpCode.Text + "");
    }

   
}
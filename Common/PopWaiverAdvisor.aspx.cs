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
using INSCL.App_Code;
using DataAccessClassDAL;

public partial class Application_Common_PopWaiverAdvisor : BaseClass
{
    DataTable dtResult = new DataTable();
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        
        if (!IsPostBack)
        {
            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;
            
            dtResult=null;
            dtResult = GetDataTable();
            if (dtResult.Rows.Count > 0)
            {
                gvWaiver.DataSource = dtResult;
                gvWaiver.DataBind();
            }
            else
            {
                lblMsg.Text = "No Record Found";
                
            }
        }

    }
    #region GetDataTable Method
    protected DataTable GetDataTable()
    {
        //try
        //{
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            if (Request.QueryString["Code"].ToString() != String.Empty)
            {
                htParam.Add("@CSCCode", Request.QueryString["Code"].ToString());
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CndAdvWaiver_Details", htParam);

            //if (dsResult.Tables.Count > 0)
            //{
            //    if (dsResult.Tables[0].Rows.Count > 0)
            //    {
                    
            //    }
            //}
            return dsResult.Tables[0];
        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = ex.Message.ToString();
        //    lblMsg.Visible = true;
        //}

        
    }
    #endregion
}

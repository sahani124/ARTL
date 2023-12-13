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

public partial class Application_Common_DuplicateCltRecords : BaseClass
{
    //added code by venkat on 07/11/07
    protected void Page_Load(object sender, EventArgs e)
    {
        //Insc.MQ.Life.CltCr.MQCltCrMgr obj=new Insc.MQ.Life.CltCr.MQCltCrMgr();
        //Insc.MQ.Life.CltCr.MQCltCr obj_CltCr = new Insc.MQ.Life.CltCr.MQCltCr();
        //dgDetails.DataSource = obj.BOCLTCRDTLS;
        if (Session["dtRecords"] != null)
        {
            dgDetails.DataSource = (DataTable)Session["dtRecords"];
            dgDetails.DataBind();
        }
    }
    //ended code by venkat
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = e.Row.Cells[5].Text + "/" + e.Row.Cells[8].Text + "/" + e.Row.Cells[9].Text;
            LinkButton lnk = new LinkButton();
            lnk = (LinkButton)e.Row.FindControl("lnkAgntCode");            
            lnk.Attributes.Add("onclick", "doSelect('" + e.Row.Cells[1].Text + "','" + e.Row.Cells[2].Text + "','" + e.Row.Cells[3].Text + "','" + e.Row.Cells[4].Text + "','" + e.Row.Cells[5].Text + "','" + e.Row.Cells[6].Text + "','" + e.Row.Cells[7].Text + "');return false;");
        }
    }
}

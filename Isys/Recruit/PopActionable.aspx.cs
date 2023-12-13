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
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_ISys_Recruit_PopActionable : BaseClass
{
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    string strAppNo = string.Empty;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strAppNo = Request.QueryString["AppNo"].ToString();
            htParam.Add("@AppNo", Request.QueryString["AppNo"].ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetCandActDtls", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "L")
                    {
                        lblHeader.Text = "Leader";
                        lblmsgL.Visible = true;
                        lblmsgL.Text = "The agent has completed 25 hours mandatory renewal training . Please upload  (VA- renewal ) documents  and deposit  necessary fees as provided in system for its renewal";
                    }
                    else if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "F")
                    {
                        lblHeader.Text = "Follower";
                        lblmsgF.Visible = true;
                        lblmsgF.Text = "The agent has completed 25 hours mandatory renewal training . Please download 25 hours renewal training certificate and handover the same to the agent for onward submission to the life company and follow-up with him for its renewal";
                    }
                    else
                    {
                        lblHeader.Text = "Soul";
                        lblmsgS.Visible = true;
                        lblmsgS.Text = "The agent has completed 25 hours mandatory renewal training . Please upload  (VA- renewal ) documents  and deposit  necessary fees as provided in system for its renewal";
                    }
                    lblAgCodeVal.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                    lblLcnNoVal.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                    lblDtExpVal.Text = dsResult.Tables[0].Rows[0]["LcnDate"].ToString().Trim();
                }
            }
        }

    }
}
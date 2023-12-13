
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataAccessClassDAL;
using System.Data.SqlClient;
using CLTMGR;
using Insc.Common.Multilingual;
public partial class Application_Common_PopAML : BaseClass
{
    private const string c_strBlank = "-- Select --";
    DataAccessClass objDAL = new DataAccessClass();
	
    //Added by Saleem----------Start
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    //Added by Saleem----------End
    CommonFunc oCommon = new CommonFunc();
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        //Added by Saleem----------Start
        olng = new multilingualManager("DefaultConn", "PopAML.aspx", Session["UserLangNum"].ToString());
        //Added by Saleem----------End
        this.dtpIssue.MaxDate = DateTime.Today;

        if (!IsPostBack)
        {
            //Added by Saleem----------Start
            InitializeControl();
            //Added by Saleem----------End

			//strGCN = Request.QueryString["GCN"].ToString();
            subPopulateRiskInd();
            //Commented by Anoop on 20-11-2007
            //subPopulateAge();
            //End of Comment
            subPopulateIdentity();
            subPopulateIncome();
            //Commented by Anoop on 20-11-2007
            //subPopulatePhotoId();
            //End of Comment
            subPopulateAddress();
            subPopulateReasonCD();
            btnSave.Attributes.Add("onclick", "doSave('" +
            //Commented by Anoop Goel on 20-11-2007
            //Request.QueryString["ProofAge"].ToString() + "','" +
            //End of Comment
            Request.QueryString["ChgWghtReason"].ToString() + "','" +
            Request.QueryString["ProofIncome"].ToString() + "','" +
            Request.QueryString["ProofAddr"].ToString() + "','" +
			Request.QueryString["PermProofAddr"].ToString() + "','" +
            Request.QueryString["ProofID"].ToString() + "','" +
            Request.QueryString["IdIssueAuth"].ToString() + "','" +
            Request.QueryString["IDNo"].ToString() + "','" +
            Request.QueryString["IdIssueDate"].ToString() + "','" +
            Request.QueryString["chkPhoto"].ToString() + "','" +
            //Commented by Anoop Goel on 20-11-2007
            //Request.QueryString["ProofPhtID"].ToString() + "','" +
            //End of Comment
            Request.QueryString["RiskInd"].ToString() + "');return false;");

            Page.Title = "AML"; // Request.QueryString["Title"].ToString();   
			ddlRiskInd.SelectedValue = Request.QueryString["RskInd"].ToString();
			this.ddlRiskInd.Focus();
			//if (Request.QueryString["GCN"] != null && Request.QueryString["GCN"] != "")
			//{
			//    lblReason.Visible = true;
			//    hdnReason.Value = "1";
			//}
			//else
			//{
			//    lblReason.Visible = false;
			//    hdnReason.Value = "";
			//}
			this.RiskIndicator();
			GetValidationValues();
        }

        string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup();  //HttpContext.Current.Session["UserGroupCode"].ToString();

        if (strUserGroupCode.ToUpper() == "AGENT")
            ReadEntry();
        else
            WriteEntry();


        if (dtpIssue.Text.Trim() != string.Empty)
            this.dtpIssue.Text = DateTime.Parse(dtpIssue.Text.Trim()).ToString("dd/MM/yyyy");
		
    }

    private void ReadEntry()
    {
        this.ddlReasonCD.Enabled = false;
        this.txtIdIssueAuth.Enabled = false;
        this.txtIDNo.Enabled = false;
        this.chkPhoto.Enabled = false;
        this.ddlProofAddr.Enabled = false;
		this.ddlPermProofAddr.Enabled = false;	//Added By Saurabh Nayar On 20071126
        //Commented by Anoop Goel on 20-11-2007
        //this.ddlProofAge.Enabled = false;
        //End of Comment
        this.ddlProofId.Enabled = false;
        this.ddlProofIncome.Enabled = false;
        //Commented by Anoop Goel on 20-11-2007
        //this.ddlProofPhtId.Enabled = false;
        //End of Comment
        this.dtpIssue.ReadOnly = true;
        this.dtpIssue.ShowCalendar = false;
        this.btnSave.Visible = false;
        this.btnClear.Visible = false;
        this.btnCancel.Visible = false;
        //this.btnExit.Visible = true;
    }

    private void WriteEntry()
    {
        this.ddlReasonCD.Enabled = true;
        this.txtIdIssueAuth.Enabled = true;
        this.txtIDNo.Enabled = true;
        this.chkPhoto.Enabled = true;
        this.ddlProofAddr.Enabled = true;
		this.ddlPermProofAddr.Enabled = true;	//Added By Saurabh Nayar On 20071126
        //Commented by Anoop Goel on 20-11-2007
        //this.ddlProofAge.Enabled = true;
        //End of Comment
        this.ddlProofId.Enabled = true;
        this.ddlProofIncome.Enabled = true;
        //Commented by Anoop Goel on 20-11-2007
        //this.ddlProofPhtId.Enabled = true;
        //End of Comment
        this.dtpIssue.ReadOnly = false;
        this.dtpIssue.ShowCalendar = true;
        this.btnSave.Visible = true;
        this.btnClear.Visible = true;
        this.btnCancel.Visible = true;
        //this.btnExit.Visible = false;
    }


    private void subPopulateAge()
    {
        //Commented by Anoop Goel on 20-11-2007
        //oCommon.getDropDown(ddlProofAge, "NBAgeProof", 1, "", 0, c_strBlank);
        //End of Comment
    }

    private void subPopulateReasonCD()
    {
        
        oCommon.getDropDown(ddlReasonCD, "ReasonCD", 1, "", 0, c_strBlank);
    }

    private void subPopulateRiskInd()
    {
        if (Request.QueryString["Occupation"].Trim() != "")
        {
			oCommon.getDropDown(ddlRiskInd, "RskInd" + Request.QueryString["Occupation"], 1, "1", 0);
        }
        else
        {
			oCommon.getDropDown(ddlRiskInd, "RskInd", 1, "1", 0);
        }
    }


    private void subPopulateIncome()
    {
        oCommon.getDropDown(ddlProofIncome, "NBINCProof", 1, "", 0, c_strBlank);
    }

    private void subPopulateIdentity()
    {
        oCommon.getDropDown(ddlProofId, "NBIDProof", 1, "", 0, c_strBlank);
    }

    private void subPopulatePhotoId()
    {
        //Commented by Anoop Goel on 20-11-2007
        //oCommon.getDropDown(ddlProofPhtId, "NBPhtProof", 1, "", 0, c_strBlank);
        //End of Comment
    }

    private void subPopulateAddress()
    {
        oCommon.getDropDown(ddlProofAddr, "NBAddProof", 1, "", 0, c_strBlank);
		oCommon.getDropDown(ddlPermProofAddr, "NBAddProof", 1, "", 0, c_strBlank);	//Added By Saurabh Nayar On 20071126
	}
	private void RiskIndicator()
	{
		string strRskInd = "";
		SqlDataReader dtRead;
		//changed by nitin

        //Added BY ibrahim on 15-07-2013 to get risckindicator start
        Hashtable Htable = new Hashtable();
        Htable.Clear();
        Htable.Add("Prc_RiskIndicator", Request.QueryString["GCN"].ToString());
        
        dtRead = objDAL.Common_exec_reader_prc("Prc_RiskIndicator", Htable);
        //Added BY ibrahim on 08-07-2013 to get risckindicator End
		//dtRead = objDAL.exec_reader("SELECT * FROM CltPer WHERE GCN = '" + Request.QueryString["GCN"].ToString() + "'");
		if (dtRead.Read())
		{
			strRskInd = dtRead["CltRiskInd"].ToString();
		}
		dtRead = null;
		
		if (strRskInd == "" && Request.QueryString["GCN"] != "")
		{
			lblReason.Visible = true;
			hdnReason.Value = "1";
		}
		if (strRskInd == ddlRiskInd.SelectedValue.ToString())
		{
			lblReason.Visible = false;
			hdnReason.Value = "";
		}
		if (strRskInd != "" && strRskInd != ddlRiskInd.SelectedValue.ToString())
		{
			lblReason.Visible = true;
			hdnReason.Value = "1";
		}
	}
	#region SELECTEDINDEXCHANGED 'ddlRiskInd' EVENT
	/// <summary>
	/// Added By:		Saurabh Nayar
	/// Date:			20071126
	/// Purpose:		SELECTEDINDEXCHANGED 'ddlRiskInd' EVENT Definition
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ddlRiskInd_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.RiskIndicator();
		GetValidationValues();
	}
	#endregion

	#region FUNCTION 'GetValidationValues()' DEFINITION
	/// <summary>
	/// Added By:		Saurabh Nayar
	/// Dated:			20071126
	/// Purpose:		To Get The Validation Rule Values From DB Into Hidden Controls Based On Risk Indicator Selected
	/// </summary>
	protected void GetValidationValues()
	{

		DataSet dsResult = new DataSet();

        //Added BY ibrahim on 15-07-2013 to get risckindicator start
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@RiskInd", ddlRiskInd.SelectedValue);
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_RiskIndicator", htparam);
        //Added BY ibrahim on 15-07-2013 to get risckindicator End
		//string strSQL = "SELECT * FROM CltAMLRlSU WHERE RiskInd = '" + ddlRiskInd.SelectedValue + "'";
		//changed by nitin
		//dsResult = objDAL.GetDataSetWithoutParam(strSQL, "INSCCommonConnectionString");
		if (dsResult.Tables.Count > 0)
		{
			if (dsResult.Tables[0].Rows.Count > 0)
			{
				hdnIncProof.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["IncProof"]);
				hdnAddProof.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["AddProof"]);
				hdnIDProof.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["IDProof"]);
				hdnIDNo.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["IDNo"]);
				hdnIssuAuth.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["IssuAuth"]);
				hdnIssuDate.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["IssuDate"]);
				hdnPhotos.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Photos"]);
				hdnPermAddProof.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["PermAddProof"]);

				if (hdnIncProof.Value == "Y")
				{
					lblIncProof.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if (hdnAddProof.Value == "Y")
				{
					lblAddrProof.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if (hdnPermAddProof.Value == "Y")
				{
					lblPermAddrProof.Visible = true;
				}
				else
				{
					lblPermAddrProof.Visible = false;
				}
				if (hdnIDProof.Value == "Y")
				{
					lblIDProof.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if (hdnIDNo.Value == "Y")
				{
					lblIDNo.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if(hdnIssuAuth.Value == "Y")
				{
					lblIssAuth.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if (hdnIssuDate.Value == "Y")
				{
					lblIssDt.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				if (hdnPhotos.Value == "Y")
				{
					lblPhoto.Visible = true;
				}
				else
				{
					lblIncProof.Visible = false;
				}
				
			}
		}
	}
	#endregion


	protected void btnSave_Click(object sender, EventArgs e)
	{
		//Session["AMLFlag"] = "1";
		HttpContext.Current.Session["AMLFlag"] = "1";
		
	}
    //Added by Saleem---------------Start
    private void InitializeControl()
    {
        lblRiskInd.Text = olng.GetItemDesc("lblRiskInd");
        lblRes.Text = olng.GetItemDesc("lblRes");
        lblIncmProof.Text = olng.GetItemDesc("lblIncmProof");
        lblAddProof.Text = olng.GetItemDesc("lblAddProof");
        lblPermAddProof.Text = olng.GetItemDesc("lblPermAddProoft");
        lblIDProf.Text = olng.GetItemDesc("lblIDProf");
        lblIdentity.Text = olng.GetItemDesc("lblIdentity");
        lblIssAuthority.Text = olng.GetItemDesc("lblIssAuthority");
        lblIssDate.Text = olng.GetItemDesc("lblIssDate");
    }
    //Added by Saleem---------------End
}

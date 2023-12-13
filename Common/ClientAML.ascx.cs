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

public partial class Application_Common_ClientAML : System.Web.UI.UserControl
{
    private bool blnReadOnly = false;
    private string strTitle = "AML";

    protected void Page_Load(object sender, EventArgs e)
        {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            //Commented by Anoop on 20-11-2007
            //btnAML.Attributes.Add("onclick", "popAML('" + hdnProofAge.ClientID + "','" +
            //End of Comment
			string strGCN = hdnGCN.Value;
            btnAML.Attributes.Add("onclick", "popAML('" + hdnChgWghtReason.ClientID + "','" +
            hdnProofIncome.ClientID + "','" +
            hdnProofAddr.ClientID + "','" +
			hdnPermProofAddr.ClientID + "','" +
            hdnProofID.ClientID + "','" +
            hdnIdIssueAuth.ClientID + "','" +
            hdnIDNo.ClientID + "','" +
            hdnIdIssueDate.ClientID + "','" +
            hdnchkPhoto.ClientID + "','" +
            //Commented by Anoop on 20-11-2007
            //hdnProofPhtID.ClientID + "','" +
            //End of Comment
            hdnRiskInd.ClientID + "'," +
            blnReadOnly.ToString().ToLower() + ", '" +
			strTitle + "', '" +
			strGCN + "', '" +
			hdnRiskInd.Value + "');return false;");
        }
    }

    public string Title
    {
        get { return strTitle; }
        set { strTitle = value; }
    }

    public void Reset()
    {
        //Commented by Anoop on 20-11-2007
        //hdnProofAge.Value = String.Empty;   
        //End of Comment
        hdnChgWghtReason.Value = String.Empty;
        hdnProofIncome.Value = String.Empty;
        hdnProofAddr.Value = String.Empty;
		hdnPermProofAddr.Value = String.Empty;
        hdnProofID.Value = String.Empty;
        hdnIdIssueAuth.Value = String.Empty;
        hdnIDNo.Value = String.Empty;
        hdnIdIssueDate.Value = String.Empty;
        hdnchkPhoto.Value = String.Empty;
        //Commented by Anoop on 20-11-2007
        //hdnProofPhtID.Value = String.Empty;
        //End of Comment
        hdnRiskInd.Value = String.Empty;
		hdnGCN.Value = String.Empty;
    }

    public Unit Width
    {
        get { return btnAML.Width; }
        set { btnAML.Width = value; }
    }
    
    public bool HasValue
    {
        get 
        {
            if (hdnProofAddr.Value == String.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public bool ReadOnly
    {
        get { return blnReadOnly; }
        set { blnReadOnly = value; }
    }

    //public string Field_ProofAge
    //{
    //    Commented by Anoop on 20-11-2007
    //    get { return hdnProofAge.ClientID; } 
    //    End of Comment
    //}
    public string Field_ChgWghtReason
    {
        get { return hdnChgWghtReason.ClientID; }
    }
    public string Field_ProofIncome
    {
        get { return hdnProofIncome.ClientID; }
    }
    public string Field_ProofAddr
    {
        get { return hdnProofAddr.ClientID; }
    }
	public string Field_PermProofAddr
	{
		get { return hdnPermProofAddr.ClientID; }
	}
    public string Field_ProofID
    {
        get { return hdnProofID.ClientID; }
    }
    public string Field_IdIssueAuth
    {
        get { return hdnIdIssueAuth.ClientID; }
    }
    public string Field_IDNo
    {
        get { return hdnIDNo.ClientID; }
    }
    public string Field_IdIssueDate
    {
        get { return hdnIdIssueDate.ClientID; }
    }
    public string Field_chkPhoto
    {
        get { return hdnchkPhoto.ClientID; }
    }
    //public string Field_ProofPhtID
    //{
    //    Commented by Anoop on 20-11-2007
    //    get { return hdnProofPhtID.ClientID; }
    //    End of Comment
    //}

    public string Field_RiskInd
    {
        get { return hdnRiskInd.ClientID; }

    }
	
    public string Text
    {
        get { return btnAML.Text; }
        set { btnAML.Text = value; }
    }
    public string CssClass
    {
        get { return btnAML.CssClass; }
        set { btnAML.CssClass = value; }
    }

    //public string Value_ProofAge
    //{
    //    Commented by Anoop on 20-11-2007
    //    get { return hdnProofAge.Value; }
    //    set { hdnProofAge.Value = value; }
    //    End of Comment
    //}
    public string Value_ChgWghtReason
    {
        get { return hdnChgWghtReason.Value; }
        set { hdnChgWghtReason.Value = value; }
    }
    public string Value_ProofIncome
    {
        get { return hdnProofIncome.Value; }
        set { hdnProofIncome.Value = value; }
    }
    public string Value_ProofAddr
    {
        get { return hdnProofAddr.Value; }
        set { hdnProofAddr.Value = value; }
    }
	public string Value_PermProofAddr
	{
		get { return hdnPermProofAddr.Value; }
		set { hdnPermProofAddr.Value = value; }
	}
    public string Value_ProofID
    {
        get { return hdnProofID.Value; }
        set { hdnProofID.Value = value; }
    }
    public string Value_IdIssueAuth
    {
        get { return hdnIdIssueAuth.Value; }
        set { hdnIdIssueAuth.Value = value; }
    }
    public string Value_IDNo
    {
        get { return hdnIDNo.Value; }
        set { hdnIDNo.Value = value; }
    }
    public string Value_IdIssueDate
    {
        get { return hdnIdIssueDate.Value; }
        set { hdnIdIssueDate.Value = value; }
    }
    //public string Value_ProofPhoto
    //{
    //    Commented by Anoop on 20-11-2007
    //    get { return hdnProofPhtID.Value; }
    //    set { hdnProofPhtID.Value = value; }
    //    End of Comment
    //}
    public string Value_chkPhoto
    {
        get { return hdnchkPhoto.Value; }
        set { hdnchkPhoto.Value = value; }
    }
    public string Value_RiskInd
    {
        get { return hdnRiskInd.Value; }
        set { hdnRiskInd.Value = value; }
    }
	public string strGCN
	{
		get { return hdnGCN.Value; }
		set { hdnGCN.Value = value; }
	}
    
}

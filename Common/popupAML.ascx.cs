using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using Insc.Common.Multilingual;
using CLTMGR;
public partial class Application_Common_popupAML : System.Web.UI.UserControl
{
    SqlConnection oSQLConn;
    SqlCommand SqlCmd;
    SqlDataReader SqlDr;
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConn"].ToString();

    private string codetext = String.Empty;
    private string desctext = String.Empty;
    private string searchcsscls = String.Empty;
    private string codecsscls = String.Empty;
    private string desccsscls = String.Empty;
    private string buttoncsscls = String.Empty;
    private string gvcsscls = String.Empty;
    private string lblcsscls = String.Empty;
    private int codewidth;
    private int descwidth;
    private string LngCode;
    private string lookupCode;

    private DataTable dtCltPer = new DataTable("CltPer");
    private multilingualManager olng;
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        olng = new multilingualManager("DefaultConn", "popupAML.aspx", Session["UserLangNum"].ToString());
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        this.txtHeight.Focus();

        if (!Page.IsPostBack)
        {
            InitializeControl();
             //btnSave.Attributes.Add("onclick", "btnSave_Click");

            if (dtCltPer != null)
                if (dtCltPer.Rows.Count > 0)
                    RetrieveCltPer(dtCltPer.Rows[0]);
        }

    }
    //Add By Darshik 16/05/2012
    private void InitializeControl()
    {
        lblPersonalDetail.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPersonalDetail"));
        lblHeigth.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeigth"));
        lblWeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblWeight"));
        lblChangedReason.Text = ObjDec.GetDecData(olng.GetItemDesc("lblChangedReason"));
        lblIncomProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIncomProof"));
        lblAddressProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddressProof"));
        lblIdentityProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIdentityProof"));
        lblIssueAuthority.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIssueAuthority"));
        lblIdentityNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIdentityNo"));
        lblIsuuedate.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIsuuedate"));
        chkPhoto.Text = ObjDec.GetDecData(olng.GetItemDesc("chkPhoto"));

    }

    public void RetrieveCltPer(DataRow drCltPer)
    {
        this.txtHeight.Text = drCltPer["Height"].ToString();
        this.txtWeight.Text = drCltPer["Weight"].ToString();
        this.txtChgWghtReason.Text = drCltPer["ChgWghtReason"].ToString();
        //this.txtProofAgeDoc.Text = drCltPer["ProofAgeDoc"].ToString();
        //this.txtProofAddrDoc.Text = drCltPer["ProofAddrDoc"].ToString();
        //this.txtProofIncomeDoc.Text = drCltPer["ProofIncomeDoc"].ToString();
        //this.txtProofIDDoc.Text = drCltPer["ProofIDDoc"].ToString();
        //this.txtProofPhtIDDoc.Text = drCltPer["ProofPhotoDoc"].ToString();
        //Commented by Anoop on 20-11-2007
        //this.DdlProofAge.SelectedValue = drCltPer["ProofAgeDoc"].ToString();
        //End of Comment
        this.DdlProofAddr.SelectedValue = drCltPer["ProofAddrDoc"].ToString();
        this.DdlProofIncome.SelectedValue = drCltPer["ProofIncomeDoc"].ToString();
        this.DdlProofID.SelectedValue = drCltPer["ProofIDDoc"].ToString();
        //Commented by Anoop on 20-11-2007
        //this.DdlProofPhtID.SelectedValue = drCltPer["ProofPhotoDoc"].ToString();
        //End of Comment
        this.txtIdIssueAuth.Text = drCltPer["IdIssueAuth"].ToString();
        this.txtIDNo.Text = drCltPer["IdNo"].ToString();
        if (drCltPer["IdIssueDate"] != DBNull.Value)
            this.txtIdIssueDate.Text = DateTime.Parse(drCltPer["IdIssueDate"].ToString()).ToString("dd/MM/yyyy");
        //this.txtIdIssueDate.Text = DateTime.Parse(drCltPer["IdIssueDate"].ToString()).ToString("dd/MM/yyyy");
        //this.chkPhoto.Checked = drCltPer["HasPhoto"].ToString() == "Y" ? true : false;
        if (drCltPer["HasPhoto"].ToString() != string.Empty)
            if (drCltPer["HasPhoto"].ToString() == "T")
                this.chkPhoto.Checked = true;        
    }


    [Category("Data")]
    public int CodeWidth
    {
        get { return codewidth; }
        set { codewidth = value; }
    }

    [Category("Data")]
    public int Descwidth
    {
        get { return descwidth; }
        set { descwidth = value; }
    }

    [Category("Data")]
    public string CodeCssCls
    {
        get { return codecsscls; }
        set { codecsscls = value; }
    }

    [Category("Data")]
    public string DescCssCls
    {
        get { return desccsscls; }
        set { desccsscls = value; }
    }

    [Category("Data")]
    public string ButtonCssCls
    {
        get { return buttoncsscls; }
        set { buttoncsscls = value; }
    }

    [Category("Data")]
    public string GvCssCls
    {
        get { return gvcsscls; }
        set { gvcsscls = value; }
    }

    [Category("Data")]
    public string LookupCode
    {
        get { return lookupCode; }
        set { lookupCode = value; }
    }

    [Category("Data")]
    public string lblCssCls
    {
        get { return lblcsscls; }
        set { lblcsscls = value; }
    }

    [Category("Data")]
    public string SearchCssCls
    {
        get { return searchcsscls; }
        set { searchcsscls = value; }
    }

    [Category("DataTable")]
    public DataTable dtCltPer1
    {
        get
        {
            dtCltPer = (DataTable)HttpContext.Current.Session["dtCltPer"];
            return (DataTable)HttpContext.Current.Session["dtCltPer"];
        }
        set
        {
            HttpContext.Current.Session["dtCltPer"] = value;
            dtCltPer = value;
        }
    }


    protected void btnSave_OnClick(object sender, EventArgs e)
    {        
        dtCltPer =(DataTable)HttpContext.Current.Session["dtCltPer"];
        if (dtCltPer == null)
            dtCltPer = new DataTable("CltPer");
        DataRow drCltPer = dtCltPer.NewRow();
              
        if (dtCltPer.Columns.Count == 0)
        {
            dtCltPer.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("Height", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("Weight", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ChgWghtReason", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofAgeDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofAddrDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofIncomeDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofIDDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdIssueAuth", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdNo", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdIssueDate", System.Type.GetType("System.DateTime"));
            dtCltPer.Columns.Add("HasPhoto", System.Type.GetType("System.Boolean"));
            dtCltPer.Columns.Add("ProofPhotoDoc", System.Type.GetType("System.String"));
        }

        if (HttpContext.Current.Session["GCN"] == null)
            drCltPer["GCN"] = "";
        else
            drCltPer["GCN"] = HttpContext.Current.Session["GCN"].ToString();

        if (Convert.ToString(this.txtHeight.Text) != String.Empty)
            drCltPer["Height"] = this.txtHeight.Text;
        if (Convert.ToString(this.txtWeight.Text) != String.Empty)
            drCltPer["Weight"] = this.txtWeight.Text;
        drCltPer["ChgWghtReason"] = this.txtChgWghtReason.Text;
        //drCltPer["ProofAgeDoc"] = this.txtProofAgeDoc.Text;
        //drCltPer["ProofAddrDoc"] = this.txtProofAddrDoc.Text;
        //drCltPer["ProofIncomeDoc"] = this.txtProofIncomeDoc.Text;
        //drCltPer["ProofIDDoc"] = this.txtProofIDDoc.Text;
        //drCltPer["ProofPhotoDoc"] = this.txtProofPhtIDDoc.Text;
        //Commented by Anoop on 20-11-2007
        //drCltPer["ProofAgeDoc"] = this.DdlProofAge.SelectedValue;
        //End of Comment
        drCltPer["ProofAddrDoc"] = this.DdlProofAddr.SelectedValue;
        drCltPer["ProofIncomeDoc"] = this.DdlProofIncome.SelectedValue;
        drCltPer["ProofIDDoc"] = this.DdlProofID.SelectedValue;
        //Commented by Anoop on 20-11-2007
        //drCltPer["ProofPhotoDoc"] = this.DdlProofPhtID.SelectedValue;
        //End of Comment
        drCltPer["IdIssueAuth"] = this.txtIdIssueAuth.Text;
        drCltPer["IdNo"] = this.txtIDNo.Text;
        if (this.txtIdIssueDate.Text != String.Empty)
            drCltPer["IdIssueDate"] = this.txtIdIssueDate.GetDateValue;
        drCltPer["HasPhoto"] = this.chkPhoto.Checked;        
        dtCltPer.Rows.Clear();
        dtCltPer.Rows.Add(drCltPer);
        HttpContext.Current.Session["dtCltPer"] = dtCltPer;

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.txtHeight.Text = string.Empty;
        this.txtWeight.Text = string.Empty;
        //Commented by Anoop on 20-11-2007
        //this.DdlProofAge.ddlClearSelection();
        //End of Comment
        this.DdlProofAddr.ddlClearSelection();
        this.DdlProofID.ddlClearSelection();
        this.DdlProofIncome.ddlClearSelection();
        //Commented by Anoop on 20-11-2007
        //this.DdlProofPhtID.ddlClearSelection();
        //End of Comment
        this.txtIdIssueAuth.Text = string.Empty;
        this.txtIdIssueDate.Text = string.Empty;
        this.txtIDNo.Text = string.Empty;
        this.chkPhoto.Checked = false;
    }
}
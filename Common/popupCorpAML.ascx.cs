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
public partial class Application_Common_popupCorpAML : System.Web.UI.UserControl
{
    private multilingualManager olng;
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
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        olng = new multilingualManager("DefaultConn", "popupCorpAML.aspx", Session["UserLangNum"].ToString());
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!Page.IsPostBack)
        {
            InitializeControl();
            if (dtCltPer != null)
                if (dtCltPer.Rows.Count > 0)
                    RetrieveCltPer(dtCltPer.Rows[0]);
        }
    }
    
    private void InitializeControl()
    {
        lblCorporateDetail.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCorporateDetail"));
        lblHeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeight"));
        lblWeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblWeight"));
        lblChangeReason.Text = ObjDec.GetDecData(olng.GetItemDesc("lblChangeReason"));
        lblAgeProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgeProof"));
        lblAddressProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddressProof"));
        lblIncomeProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIncomeProof"));
        lblIdentityProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIdentityProof"));
        lblIdentityNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIdentityNo"));
        lblIssueDate.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIssueDate"));
        lblPhotoIdProof.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPhotoIdProof"));
        lblTitleLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTitleLookup1"));
        lblSearch1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch1"));
        //Commented by rachana on 20-04-13 for solving error while building solution start 
        //lblMsgLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMsgLookup1"));
        //Commented by rachana on 20-04-13 for solving error while building solution end
        lblTitleLookup2.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTitleLookup2"));
        lblSearch2.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch2"));
        //Commented by rachana on 20-04-13 for solving error while building solution start          
        //lblMsgLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMsgLookup1"));
        //Commented by rachana on 20-04-13 for solving error while building solution end
        lblTitleLookup3.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTitleLookup3"));
        lblSearch3.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch3"));
        //Commented by rachana on 20-04-13 for solving error while building solution start 
        //lblMsgLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMsgLookup1"));
        //Commented by rachana on 20-04-13 for solving error while building solution end
        lblTitleLookup4.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTitleLookup4"));
        lblSearch4.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch4"));
        //Commented by rachana on 20-04-13 for solving error while building solution start        
        // lblMsgLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMsgLookup1"));
        //Commented by rachana on 20-04-13 for solving error while building solution end
        lblTitleLookup5.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTitleLookup5"));
        lblSearch5.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch5"));
        //Commented by rachana on 20-04-13 for solving error while building solution start        
        //lblMsgLookup1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMsgLookup1"));
        //Commented by rachana on 20-04-13 for solving error while building solution end

    }

    public void RetrieveCltPer(DataRow drCltPer)
    {
        this.txtHeight.Text = drCltPer["Height"].ToString();
        this.txtWeight.Text = drCltPer["Weight"].ToString();
        this.txtChgWghtReason.Text = drCltPer["ChgWghtReason"].ToString();
        this.txtProofAgeDoc.Text = drCltPer["ProofAgeDoc"].ToString();
        this.txtProofAddrDoc.Text = drCltPer["ProofAddrDoc"].ToString();
        this.txtProofIncomeDoc.Text = drCltPer["ProofIncomeDoc"].ToString();
        this.txtProofIDDoc.Text = drCltPer["ProofIDDoc"].ToString();
        this.txtIdIssueAuth.Text = drCltPer["IdIssueAuth"].ToString();
        this.txtIDNo.Text = drCltPer["IdNo"].ToString();
        this.txtIdIssueDate.Text = DateTime.Parse(drCltPer["IdIssueDate"].ToString()).ToString("dd/MM/yyyy");
        this.chkPhoto.Checked = drCltPer["HasPhoto"].ToString() == "Y" ? true : false;
        this.txtProofPhtIDDoc.Text = drCltPer["ProofPhotoDoc"].ToString();

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


    protected void btnSave_Click(object sender, EventArgs e)
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
            dtCltPer.Columns.Add("IdIssueDate", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("HasPhoto", System.Type.GetType("System.Boolean"));
            dtCltPer.Columns.Add("ProofPhotoDoc", System.Type.GetType("System.String"));
        }

        if (HttpContext.Current.Session["GCN"] == null)
            drCltPer["GCN"] = "";
        else
            drCltPer["GCN"] = HttpContext.Current.Session["GCN"].ToString();

        drCltPer["Height"] = this.txtHeight.Text;
        drCltPer["Weight"] = this.txtWeight.Text;
        drCltPer["ChgWghtReason"] = this.txtChgWghtReason.Text;
        drCltPer["ProofAgeDoc"] = this.txtProofAgeDoc.Text;
        drCltPer["ProofAddrDoc"] = this.txtProofAddrDoc.Text;
        drCltPer["ProofIncomeDoc"] = this.txtProofIncomeDoc.Text;
        drCltPer["ProofIDDoc"] = this.txtProofIDDoc.Text;
        drCltPer["IdIssueAuth"] = this.txtIdIssueAuth.Text;
        drCltPer["IdNo"] = this.txtIDNo.Text;
        drCltPer["IdIssueDate"] = DateTime.Parse(this.txtIdIssueDate.Text).ToString("yyyy-MMM-dd");
        drCltPer["HasPhoto"] = this.chkPhoto.Checked;
        drCltPer["ProofPhotoDoc"] = this.txtProofPhtIDDoc.Text;
        dtCltPer.Rows.Add(drCltPer);
        HttpContext.Current.Session["dtCltPer"] = dtCltPer;

    }

    
    protected void gvLookup1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvLookup1.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert1");

        txtProofAgeDoc.Text = CountryCode.Text;
        txtProofAgeDocDesc.Text = gvLookup1.DataKeys[gvLookup1.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender2.Hide();
    }
    protected void gvLookup1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLookup1.PageIndex = e.NewPageIndex;
        dsLookup1.SelectCommand = "prc_Get_LookupCode 'NBAgeProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup1.FilterExpression = "ParamDesc like '" + txtSearch1.Text + "%'";
        gvLookup1.DataBind();
    }
    protected void txtProofAgeDoc_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc 'NBAgeProof',1, '" + txtProofAgeDoc.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtProofAgeDocDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtProofAgeDocDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void cmbSearch1_Click(object sender, EventArgs e)
    {
        dsLookup1.SelectCommand = "prc_Get_LookupCode 'NBAgeProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup1.FilterExpression = "ParamDesc like '" + txtSearch1.Text + "%'";
        gvLookup1.DataBind();
        gvLookup1.Visible = true;
    }

    
    protected void gvLookup2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvLookup2.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert2");

        txtProofIncomeDoc.Text = CountryCode.Text;
        txtProofIncomeDocDesc.Text = gvLookup2.DataKeys[gvLookup2.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender3.Hide();
    }
    protected void gvLookup2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLookup2.PageIndex = e.NewPageIndex;
        dsLookup2.SelectCommand = "prc_Get_LookupCode 'NBIncProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup2.FilterExpression = "ParamDesc like '" + txtSearch2.Text + "%'";
        gvLookup2.DataBind();
    }
    protected void txtProofIncomeDoc_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc 'NBIncProof',1, '" + txtProofIncomeDoc.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtProofIncomeDocDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtProofIncomeDocDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void cmbSearch2_Click(object sender, EventArgs e)
    {
        dsLookup2.SelectCommand = "prc_Get_LookupCode 'NBIncProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup2.FilterExpression = "ParamDesc like '" + txtSearch2.Text + "%'";
        gvLookup2.DataBind();
        gvLookup2.Visible = true;
    }

    
    protected void gvLookup3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvLookup3.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert3");

        txtProofIDDoc.Text = CountryCode.Text;
        txtProofIDDocDesc.Text = gvLookup3.DataKeys[gvLookup3.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender4.Hide();
    }
    protected void gvLookup3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLookup3.PageIndex = e.NewPageIndex;
        dsLookup3.SelectCommand = "prc_Get_LookupCode 'NBIDProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup3.FilterExpression = "ParamDesc like '" + txtSearch3.Text + "%'";
        gvLookup3.DataBind();
    }
    protected void txtProofIDDoc_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc 'NBIDProof',1, '" + txtProofIDDoc.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtProofIDDocDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtProofIDDocDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void cmbSearch3_Click(object sender, EventArgs e)
    {
        dsLookup3.SelectCommand = "prc_Get_LookupCode 'NBIDProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup3.FilterExpression = "ParamDesc like '" + txtSearch3.Text + "%'";
        gvLookup3.DataBind();
        gvLookup3.Visible = true;
    }

    
    protected void gvLookup4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvLookup4.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert4");

        txtProofAddrDoc.Text = CountryCode.Text;
        txtProofAddrDocDesc.Text = gvLookup4.DataKeys[gvLookup4.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender5.Hide();
    }
    protected void gvLookup4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLookup4.PageIndex = e.NewPageIndex;
        dsLookup4.SelectCommand = "prc_Get_LookupCode 'NBAddProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup4.FilterExpression = "ParamDesc like '" + txtSearch4.Text + "%'";
        gvLookup4.DataBind();
    }
    protected void txtProofAddrDoc_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc 'NBAddProof',1, '" + txtProofAddrDoc.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtProofAddrDocDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtProofAddrDocDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void cmbSearch4_Click(object sender, EventArgs e)
    {
        dsLookup4.SelectCommand = "prc_Get_LookupCode 'NBAddProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup4.FilterExpression = "ParamDesc like '" + txtSearch4.Text + "%'";
        gvLookup4.DataBind();
        gvLookup4.Visible = true;
    }

    
    protected void gvLookup5_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvLookup5.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert5");

        txtProofPhtIDDoc.Text = CountryCode.Text;
        txtProofPhtIDDocDesc.Text = gvLookup5.DataKeys[gvLookup5.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender6.Hide();
    }
    protected void gvLookup5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLookup5.PageIndex = e.NewPageIndex;
        dsLookup5.SelectCommand = "prc_Get_LookupCode 'NBPhtProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup5.FilterExpression = "ParamDesc like '" + txtSearch5.Text + "%'";
        gvLookup5.DataBind();
    }
    protected void txtProofPhtIDDoc_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc 'NBPhtProof',1, '" + txtProofPhtIDDoc.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtProofPhtIDDocDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtProofPhtIDDocDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void cmbSearch5_Click(object sender, EventArgs e)
    {
        dsLookup5.SelectCommand = "prc_Get_LookupCode 'NBPhtProof'," + HttpContext.Current.Session["UserLangNum"].ToString() + ",1";
        dsLookup5.FilterExpression = "ParamDesc like '" + txtSearch5.Text + "%'";
        gvLookup5.DataBind();
        gvLookup5.Visible = true;
    }


}
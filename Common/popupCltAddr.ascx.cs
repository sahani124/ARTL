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

public partial class Application_Common_popupCltAddr : System.Web.UI.UserControl
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
    private multilingualManager olng;

    DataTable dtCltCnct = new DataTable();
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        olng = new multilingualManager("DefaultConn", "popupCltAddr.aspx", Session["UserLangNum"].ToString());
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
            InitializeControl();
        }
    }
    //Add by Darshik 16/05/2012
    private void InitializeControl()
    {
        lblABHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblABHeadear"));
        lblAddr1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddr1"));
        lblCity.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCity"));
        lblAddr2.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddr2"));
        lblState.Text = ObjDec.GetDecData(olng.GetItemDesc("lblState"));
        lblPin.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPin"));
        lblCountry.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountry"));

    }

    [Category("Data")]
    public int PCodeWidth
    {
        get { return codewidth; }
        set { codewidth = value; }
    }

    [Category("Data")]
    public int PDescwidth
    {
        get { return descwidth; }
        set { descwidth = value; }
    }

    [Category("Data")]
    public string PCodeCssCls
    {
        get { return codecsscls; }
        set { codecsscls = value; }
    }

    [Category("Data")]
    public string PDescCssCls
    {
        get { return desccsscls; }
        set { desccsscls = value; }
    }

    [Category("Data")]
    public string PButtonCssCls
    {
        get { return buttoncsscls; }
        set { buttoncsscls = value; }
    }

    [Category("Data")]
    public string PGvCssCls
    {
        get { return gvcsscls; }
        set { gvcsscls = value; }
    }

    [Category("Data")]
    public string PLookupCode
    {
        get { return lookupCode; }
        set { lookupCode = value; }
    }

    [Category("Data")]
    public string PlblCssCls
    {
        get { return lblcsscls; }
        set { lblcsscls = value; }
    }

    [Category("Data")]
    public string PSearchCssCls
    {
        get { return searchcsscls; }
        set { searchcsscls = value; }
    }

    [Category("Data")]
    public string lblABHeadearText
    {
        get { return lblABHeadear.Text; }
        set { lblABHeadear.Text = value; }
    }

    [Category("Data")]
    public string Addr1Text
    {
        get { return txtAddr1.Text; }
        set { txtAddr1.Text = value; }
    }

    [Category("Data")]
    public string Addr2Text
    {
        get { return txtAddr2.Text; }
        set { txtAddr2.Text = value; }
    }

    [Category("Data")]
    public string Addr3Text
    {
        get { return txtAddr3.Text; }
        set { txtAddr3.Text = value; }
    }

    [Category("Data")]
    public string Addr4Text
    {
        get { return txtAddr4.Text; }
        set { txtAddr4.Text = value; }
    }

    [Category("Data")]
    public string City
    {
        get { return txtCity.Text; }
        set { txtCity.Text = value; }
    }

    [Category("Data")]
    public string StateCode
    {
        get { return cboState.SelectedValue; }
        set { cboState.SelectedValue = value; }
    }

    //[Category("Data")]
    //public string CountryDesc
    //{
    //    get { return txtCountryDesc.Text; }
    //    set { txtCountryDesc.Text = value; }
    //}

    //[Category("Data")]
    //public string StateDesc
    //{
    //    get { return txtStateDesc.Text; }
    //    set { txtStateDesc.Text = value; }
    //}

    [Category("Data")]
    public string Pin
    {
        get { return txtPin.Text; }
        set { txtPin.Text = value; }
    }

    [Category("Data")]
    public string Country
    {
        get { return cboCountry.SelectedValue; }
        set { cboCountry.SelectedValue = value; }
    }

    [Category("Data")]
    public string cmdSearchText
    {
        get { return cmdSearch.Text; }
        set { cmdSearch.Text = value; }
    }

    [Category("DataTable")]
    public DataTable PdtCltCnct1
    {
        get { return dtCltCnct; }
        set { dtCltCnct = value; }
    }

    [Category("DataTable")]
    public string txtAddrNoText
    {
        get { return txtAddrNo.Text; }
        set { txtAddrNo.Text = value; }
    }

    [Category("DataTable")]
    public DataTable dtCltCnct1
    {
        get
        {
            dtCltCnct = (DataTable)HttpContext.Current.Session["dtCltCnct"];
            return (DataTable)HttpContext.Current.Session["dtCltCnct"];
        }
        set
        {
            HttpContext.Current.Session["dtCltCnct"] = value;
            dtCltCnct = value;
        }
    }

    [Category("Data")]
    public bool txtAddr1Enabled
    {
        get { return txtAddr1.Enabled; }
        set { txtAddr1.Enabled = value; }
    }

    [Category("Data")]
    public bool txtAddr2Enabled
    {
        get { return txtAddr2.Enabled; }
        set { txtAddr2.Enabled = value; }
    }

    [Category("Data")]
    public bool txtAddr3Enabled
    {
        get { return txtAddr3.Enabled; }
        set { txtAddr3.Enabled = value; }
    }

    [Category("Data")]
    public bool txtAddr4Enabled
    {
        get { return txtAddr4.Enabled; }
        set { txtAddr4.Enabled = value; }
    }

    [Category("Data")]
    public bool txtCityEnabled
    {
        get { return txtCity.Enabled; }
        set { txtCity.Enabled = value; }
    }

    [Category("Data")]
    public bool txtPINEnabled
    {
        get { return txtPin.Enabled; }
        set { txtPin.Enabled = value; }
    }

    [Category("Data")]
    public bool cboStateEnabled
    {
        get { return cboState.ddliSysLParamEnabled; }
        set { cboState.ddliSysLParamEnabled = value; }
    }

    [Category("Data")]
    public bool cboCountryEnabled
    {
        get { return cboCountry.ddliSysLParamEnabled; }
        set { cboCountry.ddliSysLParamEnabled = value; }
    }


    public void ddlClearSelection()
    {
        this.cboCountry.ddlClearSelection();
        this.cboState.ddlClearSelection();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        dtCltCnct = (DataTable)HttpContext.Current.Session["dtCltCnct"];
        if (dtCltCnct == null)
            dtCltCnct = new DataTable("CltCnct");

        DataRow drCltCnct = dtCltCnct.NewRow();

        if (dtCltCnct.Columns.Count == 0)
        {
            dtCltCnct.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CnctType", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr1", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr2", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr3", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr4", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("City", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("StateCode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PostCode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CntryCode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CreateBy", System.Type.GetType("System.String"));
            dtCltCnct.PrimaryKey = new DataColumn[] { dtCltCnct.Columns["CnctType"] };
        }

        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        if (HttpContext.Current.Session["GCN"] == null)
            drCltCnct["GCN"] = string.Empty;
        else
            drCltCnct["GCN"] = HttpContext.Current.Session["GCN"].ToString();

        drCltCnct["CnctType"] = this.txtAddrNo.Text;
        drCltCnct["Adr1"] = this.txtAddr1.Text;
        drCltCnct["Adr2"] = this.txtAddr2.Text;
        drCltCnct["Adr3"] = this.txtAddr3.Text;
        drCltCnct["Adr4"] = this.txtAddr4.Text;
        drCltCnct["City"] = this.txtCity.Text;
        drCltCnct["StateCode"] = this.cboState.SelectedValue;
        drCltCnct["PostCode"] = this.txtPin.Text;
        drCltCnct["CntryCode"] = this.cboCountry.SelectedValue;
        drCltCnct["CreateBy"] = strUserGCN;

        System.Data.DataTable duplicateTable = dtCltCnct.Clone();
        System.Data.DataColumn[] primaryKey = new System.Data.DataColumn[duplicateTable.Columns.Count];

        duplicateTable.Columns.CopyTo(primaryKey, 0);
        duplicateTable.PrimaryKey = primaryKey;

        System.Data.DataRow[] dataRows = new System.Data.DataRow[dtCltCnct.Rows.Count];
        dtCltCnct.Rows.CopyTo(dataRows, 0);
        foreach (System.Data.DataRow dataRow in dataRows)
            if (dataRow.ItemArray[1].Equals(this.txtAddrNo.Text))
                dtCltCnct.Rows.Remove(dataRow);

        dtCltCnct.Rows.Add(drCltCnct);
        HttpContext.Current.Session["dtCltCnct"] = dtCltCnct;

    }


    public event EventHandler Saved;

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (Saved != null)
            Saved(this, e);

        RaiseBubbleEvent(this, e);
    }
}
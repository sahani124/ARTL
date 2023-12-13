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
using System.ComponentModel;
using Insc.Common.Multilingual;
using CLTMGR;
public partial class Application_Common_popupCltEnq : System.Web.UI.UserControl
{
    SqlConnection oSQLConn;
    SqlCommand SqlCmd;
    SqlDataReader SqlDr;
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();

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
    private bool requiredfield;
    private string validationerror = String.Empty;
     
    DataTable dtClt = new DataTable();
    private multilingualManager olng;
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {

        olng = new multilingualManager("DefaultConn", "popupCltEnq.aspx", Session["UserLangNum"].ToString());

        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!Page.IsPostBack)
        {
            InitializeControl();
            LngCode = HttpContext.Current.Session["UserLangNum"].ToString();
            Insc.Common.Multilingual.multilingualManager mlm = new Insc.Common.Multilingual.multilingualManager("DefaultConn", "ddlCountry.ascx", LngCode);

            if (descwidth != 0) txtCountryDesc.Width = descwidth;
            if (codewidth != 0) txtCountryCode.Width = codewidth;
            if (desccsscls != null) txtCountryDesc.CssClass = desccsscls;
            if (codecsscls != null) txtCountryCode.CssClass = codecsscls;
            if (searchcsscls != null) txtSearchCountry.CssClass = searchcsscls;

            if (gvcsscls != null) gvCountry.CssClass = gvcsscls;
            if (lblcsscls != null) lblSearch.CssClass = lblcsscls;
            
            if (buttoncsscls != null)
            { 
                cmdSearch.CssClass = buttoncsscls;
                CancelButton.CssClass = buttoncsscls;
                cmbPSearch.CssClass = buttoncsscls;
            }

            if (requiredfield == true)
            {
                RFV.Enabled = true;
                VCE.Enabled = true;
            }
            else
            {
                RFV.Enabled = false;
                VCE.Enabled = false;
            }
            if (validationerror != null) RFV.ErrorMessage = validationerror;
        }
    }
    
    private void InitializeControl()
    {
        lblSearch.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearch"));
        lblSearchDescription.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearchDescription"));
        lblSearchDesc.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearchDesc"));
        lblSearchDescrip2.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSearchDescrip2"));
        //Commented by rachana on 20-04-13 for solving error while building solution start        
        //lblNoSearchResult.Text = ObjDec.GetDecData(olng.GetItemDesc("lblNoSearchResult"));
        //Commented by rachana on 20-04-13 for solving error while building solution end

    }
    protected void cmbPSearch_Click(object sender, EventArgs e)
    {

        string strGCN = string.Empty;
        string strSurname = string.Empty;
        string strGivenNm = string.Empty;
        string strDOB = string.Empty;
        string strGender = string.Empty; 
        string strIDType = string.Empty; 
        string strIDNo = string.Empty; 
        string strCltType = string.Empty;

        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();
        
        

        Insc.MQ.Common.Client.MQClientMgr oMQClnMgr = new Insc.MQ.Common.Client.MQClientMgr();
        

         gvCountry.DataSource = oMQClnMgr.SearchClient(strGCN, strIDNo, strIDType,"","",strCltType,
                               strGivenNm + ' ' + strSurname, strGivenNm, strSurname, strGender,
                               strDOB,"", strUserGCN);
        
        gvCountry.DataBind();
        gvCountry.Visible = true;
    }
    protected void gvCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCountry.SelectedRow;
        LinkButton CountryCode = (LinkButton)row.FindControl("btnInsert");

        txtCountryCode.Text = CountryCode.Text;
        txtCountryDesc.Text = gvCountry.DataKeys[gvCountry.SelectedIndex]["ParamDesc"].ToString();
        ModalPopupExtender1.Hide();
    }
    protected void gvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCountry.PageIndex = e.NewPageIndex;
        dsCountry.SelectCommand = "prc_Get_LookupCode '"+lookupCode+"'," + HttpContext.Current.Session["UserLangNum"].ToString() +",1";
        dsCountry.FilterExpression = "ParamDesc like '" + txtSearchCountry.Text + "%'";
        gvCountry.DataBind();
    }
    protected void txtCountryCode_TextChanged(object sender, EventArgs e)
    {
        String strSQL = "prc_Get_LookupSingleDesc '"+lookupCode+"',1, '" + txtCountryCode.Text + "'";

        oSQLConn = new SqlConnection(sConnStr);
        oSQLConn.Open();

        SqlCmd = new SqlCommand(strSQL, oSQLConn);
        SqlDr = SqlCmd.ExecuteReader();
        SqlDr.Read();

        if (SqlDr.HasRows)
        {
            txtCountryDesc.Text = SqlDr["ParamDesc"].ToString();
        }
        else
        {
            txtCountryDesc.Text = "";
        }

        oSQLConn.Close();
        SqlDr.Close();
        SqlCmd = null;
    }
    protected void Name_OnClick(object sender, EventArgs e)
    {
        
        this.Page.FindControl("Test_test");        
    }

    [Category("Data")]
    public string CodeText
    {
        get { return txtCountryCode.Text; }
        set { txtCountryCode.Text = value; }
    }

    [Category("Data")]
    public string DescText
    {
        get { return txtCountryDesc.Text; }
        set { txtCountryDesc.Text = value; }
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

    [Category("Data")]
    public bool RequiredField
    {
        get { return requiredfield; }
        set { requiredfield = value; }
    }

    [Category("Data")]
    public string ValidationError
    {
        get { return validationerror; }
        set { validationerror = value; }
    }
}

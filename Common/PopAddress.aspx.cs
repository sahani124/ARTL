using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
using System.Web;
//using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CLTMGR;
using Insc.Common.Multilingual;
public partial class Application_Common_PopAddress : BaseClass
{
    //Added by Saleem----------Start
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    //Added by Saleem----------End
    public string strInit = String.Empty;
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by Saleem----------Start
        olng = new multilingualManager("DefaultConn", "PopAddress.aspx", Session["UserLangNum"].ToString());
        //Added by Saleem----------End
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        txtAdd1.Focus();

        if (!IsPostBack)
        { 
            //Added by Saleem----------Start
            InitializeControl();
            //Added by Saleem----------End
            Page.Title = Request.QueryString["Title"].ToString();
            txtAdd1.Text = Request.QueryString["vAdd1"].ToString();
            txtAdd2.Text = Request.QueryString["vAdd2"].ToString();
            txtAdd3.Text = Request.QueryString["vAdd3"].ToString();
            txtAdd4.Text = Request.QueryString["vAdd4"].ToString();
            txtCity.Text = Request.QueryString["vCity"].ToString();
            txtStateCode.Text = Request.QueryString["vState"].ToString();
            txtPostcode.Text = Request.QueryString["vPostcode"].ToString();
            txtCountryCode.Text = Request.QueryString["vCountry"].ToString();           

            txtAdd1.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtAdd2.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtAdd3.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtAdd4.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtCity.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtStateCode.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtStateDesc.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtPostcode.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtCountryCode.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());
            txtCountryDesc.ReadOnly = bool.Parse(Request.QueryString["ReadOnly"].ToString());

            btnSave.Attributes.Add("onclick", "doSave('" +
                Request.QueryString["Add1"].ToString() + "','" +
                Request.QueryString["Add2"].ToString() + "','" +
                Request.QueryString["Add3"].ToString() + "','" +
                Request.QueryString["Add4"].ToString() + "','" +
                Request.QueryString["City"].ToString() + "','" +
                Request.QueryString["State"].ToString() + "','" +
                Request.QueryString["Postcode"].ToString() + "','" +
                Request.QueryString["Country"].ToString() + "');");
            
            txtAdd1.Attributes.Add("onchange", "doFormat('" + txtAdd1.ClientID + "');");
            txtAdd2.Attributes.Add("onchange", "doFormat('" + txtAdd2.ClientID + "');");
            txtAdd3.Attributes.Add("onchange", "doFormat('" + txtAdd3.ClientID + "');");
            txtAdd4.Attributes.Add("onchange", "doFormat('" + txtAdd4.ClientID + "');");
            txtCity.Attributes.Add("onchange", "doFormat('" + txtCity.ClientID + "');");
            //txtStateCode.Attributes.Add("onchange", "txtStateCodetoProperCase(document.getElementById('" + txtStateCode.ClientID + "').value);");
            //txtStateDesc.Attributes.Add("onchange", "txtStateDesctoProperCase(document.getElementById('" + txtStateDesc.ClientID + "').value);");
            //txtPostcode.Attributes.Add("onchange", "txtPostcodetoProperCase(document.getElementById('" + txtPostcode.ClientID + "').value);");
            //txtCountryCode.Attributes.Add("onchange", "txtCountryCodetoProperCase(document.getElementById('" + txtCountryCode.ClientID + "').value);");
            //txtCountryDesc.Attributes.Add("onchange", "txtCountryDesctoProperCase(document.getElementById('" + txtCountryDesc.ClientID + "').value);");

            txtStateCode.Attributes.Add("onchange", "lookupState(document.getElementById('" +
                txtStateCode.ClientID + "').value, '" +
                txtStateDesc.ClientID + "', 1);");
            btnState.Attributes.Add("onclick", "popState('" +
                txtStateCode.ClientID + "','" +
                txtStateDesc.ClientID + "'," +
                "document.getElementById('" +
                txtStateCode.ClientID + "').value," +
                "document.getElementById('" +
                txtStateDesc.ClientID + "').value);return false;");
            txtCountryCode.Attributes.Add("onchange", "lookupCountry(document.getElementById('" +
                txtCountryCode.ClientID + "').value, '" +
                txtCountryDesc.ClientID + "', 1);");
            btnCountry.Attributes.Add("onclick", "popCountry('" +
                txtCountryCode.ClientID + "','" +
                txtCountryDesc.ClientID + "'," +
                "document.getElementById('" +
                txtCountryCode.ClientID + "').value," +
                "document.getElementById('" +
                txtCountryDesc.ClientID + "').value);return false;");

            strInit += txtCountryCode.Attributes["onchange"].ToString();
            strInit += txtStateCode.Attributes["onchange"].ToString();
        }

        string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup(); //HttpContext.Current.Session["UserGroupCode"].ToString();

        if (strUserGroupCode.ToUpper() == "AGENT")
            ReadEntry();
        else
            WriteEntry();
            
    }

    private void WriteEntry()
    {
        this.txtAdd1.Enabled = true;
        this.txtAdd2.Enabled = true;
        this.txtAdd3.Enabled = true;
        this.txtAdd4.Enabled = true;
        this.txtCity.Enabled = true;
        this.txtCountryCode.Enabled = true;
        this.txtCountryDesc.Enabled = true;
        this.btnCountry.Enabled = true;
        this.txtPostcode.Enabled = true;
        this.txtStateCode.Enabled = true;
        this.txtStateDesc.Enabled = true;       
        this.btnState.Enabled = true;
        this.btnSave.Visible = true;
        this.btnClear.Visible = true;
    }

    private void ReadEntry()
    {
        this.txtAdd1.Enabled = false;
        this.txtAdd2.Enabled = false;
        this.txtAdd3.Enabled = false;
        this.txtAdd4.Enabled = false;
        this.txtCity.Enabled = false;
        this.txtCountryCode.Enabled = false;
        this.txtCountryDesc.Enabled = false;
        this.btnCountry.Enabled = false;
        this.txtPostcode.Enabled = false;
        this.txtStateCode.Enabled = false;
        this.txtStateDesc.Enabled = false;
        this.btnState.Enabled = false;
        this.btnSave.Visible = false;
        this.btnClear.Visible = false;
    }

    public string vTitle
    {
        get { return Title; }
        set { Title = value; }
    }
    //Added by Saleem---------------Start
    private void InitializeControl()
    {
        lblAddress.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddress.Text"));
        lblCity.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCity.Text"));
        lblCountry.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountry.Text"));
        lblState.Text = ObjDec.GetDecData(olng.GetItemDesc("lblState.Text"));
        lblPincode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPincode.Text"));
    }
    //Added by Saleem---------------End
}

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using Insc.Common.Multilingual;
using CLTMGR;

public partial class Application_Common_CltDetailAddr : System.Web.UI.UserControl
{
    private string strUserLang;
    private const string Conn_Direct = "DefaultConn";
    private multilingualManager olng;
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        olng = new multilingualManager("DefaultConn", "CltDetailAddr.ascx", Session["UserLangNum"].ToString());
        if (!IsPostBack)
        {
            // Set Proper case validation
            //txtAddr1.Attributes.Add("onchange", "Addr1toProperCase(document.getElementById('" + txtAddr1.ClientID + "').value);");
            //txtAddr2.Attributes.Add("onchange", "Addr2toProperCase(document.getElementById('" + txtAddr2.ClientID + "').value);");
            //txtAddr3.Attributes.Add("onchange", "Addr3toProperCase(document.getElementById('" + txtAddr3.ClientID + "').value);");
            //txtAddr4.Attributes.Add("onchange", "Addr4toProperCase(document.getElementById('" + txtAddr4.ClientID + "').value);");
            //txtCity.Attributes.Add("onchange", "CitytoProperCase(document.getElementById('" + txtCity.ClientID + "').value);");
            //txtPin.Attributes.Add("onchange", "PintoProperCase(document.getElementById('" + txtPin.ClientID + "').value);");
            InitializeControl();
            txtStateCode.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                txtStateCode.ClientID + "').value, '" +
                txtStateDesc.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
            btnState.Attributes.Add("onclick", "popState('" +
                txtStateCode.ClientID + "','" +
                txtStateDesc.ClientID + "'," +
                "document.getElementById('" +
                txtStateCode.ClientID + "').value," +
                "document.getElementById('" +
                txtStateDesc.ClientID + "').value,'" +
                "');return false;");
            txtCountryCode.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                txtCountryCode.ClientID + "').value, '" +
                txtCountryDesc.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
            btnCountry.Attributes.Add("onclick", "popCountry('" +
                txtCountryCode.ClientID + "','" +
                txtCountryDesc.ClientID + "'," +
                "document.getElementById('" +
                txtCountryCode.ClientID + "').value," +
                "document.getElementById('" +
                txtCountryDesc.ClientID + "').value,'" +
                "');return false;");
        }

        string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup(); //HttpContext.Current.Session["UserGroupCode"].ToString();

        if (strUserGroupCode.ToUpper() == "AGENT")
            ReadEntry();
        else
            WriteEntry();

    }

    #region InitializeControl Method
    private void InitializeControl()
    {
        lblAddr1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddr1"));
        lblCity.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCity"));
        lblState.Text = ObjDec.GetDecData(olng.GetItemDesc("lblState"));
        lblPin.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPin"));
        Label2.Text = ObjDec.GetDecData(olng.GetItemDesc("Label2"));
        lblABHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblABHeadear"));
    }
    #endregion

    private void WriteEntry()
    {
        this.txtAddr1Enabled = true;
        this.txtAddr2.Enabled = true;
        this.txtAddr3.Enabled = true;
        this.txtAddr4.Enabled = true;
        this.txtCity.Enabled = true;
        this.txtCountryCode.Enabled = true;
        this.txtCountryDesc.Enabled = true;
        this.btnCountry.Enabled = true;        
        this.txtPin.Enabled = true;
        this.txtStateCode.Enabled = true;
        this.txtStateDesc.Enabled = true;
        this.btnState.Enabled = true;
    }

    private void ReadEntry()
    {
        this.txtAddr1.Enabled = false;
        this.txtAddr2.Enabled = false;
        this.txtAddr3.Enabled = false;
        this.txtAddr4.Enabled = false;
        this.txtCity.Enabled = false;
        this.txtCountryCode.Enabled = false;
        this.txtCountryDesc.Enabled = false;
        this.btnCountry.Enabled = false;
        this.txtPin.Enabled = false;
        this.txtStateCode.Enabled = false;
        this.txtStateDesc.Enabled = false;
        this.btnState.Enabled = false;
    }


    public void ChangeHeader(string StrHeader)
    {
        lblABHeadear.Text = StrHeader;
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
        get { return txtStateCode.Text; }
        set { txtStateCode.Text=value; }
    }

    [Category("Data")]
    public string Pin
    {
        get { return txtPin.Text; }
        set { txtPin.Text = value; }
    }

    [Category("Data")]
    public string Country
    {
        get { return txtCountryCode.Text; }
        set { txtCountryCode.Text = value; }
    }

    [Category("Data")]
    public string CountryDesc
    {
        get { return txtCountryDesc.Text; }
        set { txtCountryDesc.Text = value; }
    }

    [Category("Data")]
    public string StateDesc
    {
        get { return txtStateDesc.Text; }
        set { txtStateDesc.Text = value; }
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
        get { return txtStateCode.Enabled ; }
        set { txtStateCode.Enabled = value; }
    }

    [Category("Data")]
    public bool cboCountryEnabled
    {
        get { return txtCountryCode.Enabled; }
        set { txtCountryCode.Enabled = value; }
    }

    [Category("Data")]
    public bool RFVAddr1Enabled
    {
        get { return RFVAddr1.Enabled; }
        set { RFVAddr1.Enabled = value; }
    }

    [Category("Data")]
    public bool RFVCityEnabled
    {
        get { return RFVCity.Enabled; }
        set { RFVCity.Enabled = value; }
    }

    [Category("Data")]
    public bool RFVPinEnabled
    {
        get { return RFVPin.Enabled; }
        set { RFVPin.Enabled = value; }
    }

    [Category("Data")]
    public bool RFVStateEnabled
    {
        get { return rfvState.Enabled; }
        set { rfvState.Enabled = value; }
    }

    [Category("Data")]
    public bool RFVCountryEnabled
    {
        get { return rfvCountry.Enabled; }
        set { rfvCountry.Enabled = value; }
    }

    [Category("Data")]
    public string lblEst1Text
    {
        get { return lblEst1.Text; }
        set { lblEst1.Text = value; }
    }

    [Category("Data")]
    public string lblEst2Text
    {
        get { return lblEst2.Text; }
        set { lblEst2.Text = value; }
    }

    [Category("Data")]
    public string lblEst3Text
    {
        get { return lblEst3.Text; }
        set { lblEst3.Text = value; }
    }

    [Category("Data")]
    public string lblEst4Text
    {
        get { return lblEst4.Text; }
        set { lblEst4.Text = value; }
    }

    [Category("Data")]
    public string lblEst5Text
    {
        get { return lblEst5.Text; }
        set { lblEst5.Text = value; }
    }


    public void ddlClearSelection()
    {
        txtCountryCode.Text = String.Empty;
        txtCountryDesc.Text = String.Empty;
        txtStateCode.Text = String.Empty;
        txtStateDesc.Text = String.Empty;
    }

}
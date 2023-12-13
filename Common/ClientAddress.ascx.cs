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

public partial class Application_Common_ClientAddress : System.Web.UI.UserControl
{
    private bool blnReadOnly = false;
    private string strTitle = "Address";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {   
            btnAddress.Attributes.Add("onclick", "popAddress('" + hdnAdd1.ClientID + "','" +
            hdnAdd2.ClientID + "','" +
            hdnAdd3.ClientID + "','" +
            hdnAdd4.ClientID + "','" +
            hdnCity.ClientID + "','" +
            hdnState.ClientID + "','" +
            hdnPostcode.ClientID + "','" +
            hdnCountry.ClientID + "'," +
            blnReadOnly.ToString().ToLower() + ", '" +
            strTitle + "');return false;");
        }
    }

    public string Title
    {
        get { return strTitle; }
        set { strTitle = value; }
    }

    public void Reset()
    {
        hdnAdd1.Value = String.Empty;
        hdnAdd2.Value = String.Empty;
        hdnAdd3.Value = String.Empty;
        hdnAdd4.Value = String.Empty;
        hdnCity.Value = String.Empty;
        hdnState.Value = String.Empty;
        hdnPostcode.Value = String.Empty;
        hdnCountry.Value = String.Empty;
        hdnDistrict.Value = string.Empty;
    }

    public Unit Width
    {
        get { return btnAddress.Width; }
        set { btnAddress.Width = value; }
    }

    public bool HasValue
    {
        get 
        {
            if (hdnAdd1.Value == String.Empty)
                return false;
            else
                return true;
        }
    }

    public bool ReadOnly
    {
        get { return blnReadOnly; }
        set { blnReadOnly = value; }
    }

    public string Field_Address1
    {
        get { return hdnAdd1.ClientID; }
    }

    public string Field_Address2
    {
        get { return hdnAdd2.ClientID; }
    }

    public string Field_Address3
    {
        get { return hdnAdd3.ClientID; }
    }

    public string Field_Address4
    {
        get { return hdnAdd4.ClientID; }
    }

    public string Field_City
    {
        get { return hdnCity.ClientID; }
    }

    public string Field_State
    {
        get { return hdnState.ClientID; }
    }

    public string Field_District
    {
        get { return hdnDistrict.ClientID; }
    }

    public string Field_Postcode
    {
        get { return hdnPostcode.ClientID; }
    }

    public string Field_Country
    {
        get { return hdnCountry.ClientID; }
    }

    public string Text
    {
        get { return btnAddress.Text; }
        set { btnAddress.Text = value; }
    }

    public string CssClass
    {
        get { return btnAddress.CssClass; }
        set { btnAddress.CssClass = value; }
    }

    public string Value_Address1
    {
        get { return hdnAdd1.Value; }
        set { hdnAdd1.Value = value; }
    }

    public string Value_Address2
    {
        get { return hdnAdd2.Value; }
        set { hdnAdd2.Value = value; }
    }

    public string Value_Address3
    {
        get { return hdnAdd3.Value; }
        set { hdnAdd3.Value = value; }
    }

    public string Value_Address4
    {
        get { return hdnAdd4.Value; }
        set { hdnAdd4.Value = value; }
    }

    public string Value_City
    {
        get { return hdnCity.Value; }
        set { hdnCity.Value = value; }
    }

    public string Value_State
    {
        get { return hdnState.Value; }
        set { hdnState.Value = value; }
    }
    public string Value_District
    {      
         get { return hdnDistrict.Value; }
        set { hdnDistrict.Value = value; }
    }

    public string Value_Postcode
    {
        get { return hdnPostcode.Value; }
        set { hdnPostcode.Value = value; }
    }

    public string Value_Country
    {
        get { return hdnCountry.Value; }
        set { hdnCountry.Value = value; }
    }
}

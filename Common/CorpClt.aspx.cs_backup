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
using System.Web.SessionState;
using System.Text;
using Insc.Common.Data;
using System.ComponentModel;


public partial class Application_Common_CorpClt : BaseClass
{
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();

    protected CommonFunc oCommon = new CommonFunc();
    DataSet dsClt = new DataSet();
    DataTable dtClt = new DataTable("Clt");
    DataTable dtCltCnct = new DataTable("CltCnct");
    DataTable dtCltCorp = new DataTable("CltCorp");
    DataTable dtCltPer = new DataTable("CltPer");

    const string cSessionQryState = "ClientDetail";
    protected string strEnq = string.Empty;
    protected string strGCNA = string.Empty;
    protected string strCnctType = string.Empty;
    protected string strFlagFind = string.Empty;
    public string strInit = String.Empty;

    Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

    string strCarrierCode = string.Empty;
    string strUserGCN = string.Empty;
    string strCltType = "C";
    string strSrc = "1";
    string strErrMsg = string.Empty;
    string strStatusMsg = string.Empty;
    string strGCN = string.Empty;
    int intStatusCode = 0;

    string[] strAddress1 = new string[9];
    string[] strAddress2 = new string[9];
    string[] strAddress3 = new string[9];
    string[] strAddress4 = new string[9];
    string[] strCity = new string[9];
    string[] strState = new string[9];
    string[] strPostcode = new string[9];
    string[] strCountry = new string[9];
    private const string c_strBlank = "-- Select --";

    protected void Page_Load(object sender, EventArgs e)
    {

        btnAML.Visible = false;

        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        //CltAddrB1.ChangeHeader("Business Address (1)");
        lblABHeadear.Text = "Business Address (1)";
        txtDOB.MaxDate = DateTime.Today;
        strCnctType = this.cboCnctType.SelectedValue;
        strFlagFind = this.txtFlagFind.Text;

        this.RFVSurname.Enabled = true;
        this.btnSearchClt.Visible = true;
        this.btnCancel.Visible = true;
        this.btnCancel2.Visible = false;

        cboCnctType.Attributes.Add("style", "display: visible");
        ddlDstbnMethod.Attributes.Add("style", "display: visible");
        ddlPrivacy.Attributes.Add("style", "display: visible");

        // ************************ Define button loops for multiple address ************************
        hdnCnctType.Value = String.Empty;
        for (int i = 0; i < 9; i++)
        {
            Application_Common_ClientAddress oAddr = (Application_Common_ClientAddress)Page.LoadControl("ClientAddress.ascx");
            int intAddCnt = i + 2;

            plcAddress.Controls.Add(oAddr);

            oAddr.Text = "Address " + intAddCnt.ToString();
            oAddr.CssClass = "standardbutton";
            oAddr.Width = Unit.Pixel(100);
            hdnCnctType.Value += oAddr.ClientID + ",";

            oAddr = null;
        }
        hdnCnctType.Value = hdnCnctType.Value.Trim(",".ToCharArray());

        // ************************ Define redirect from New page or Enquiry page ************************
        if (Request.QueryString.Count > 0)
        {
            strEnq = Request.QueryString["ENQ"].ToString();
            strGCNA = Request.QueryString["GCN"].ToString();
            strFlagFind = Request.QueryString["FLAGFIND"].ToString();
        }

        if (!Page.IsPostBack)
        {
            btnAML.Visible = false;

            switch (Session["CarrierCode"].ToString())
            {
                case "1":
                    break;

                case "2":
                    //Commented & Added By Saurabh Nayar On 20071122
                    //txtCapital.ReadOnly = true;
                    txtCapital.ReadOnly = false; ;
                    //End Of Addition By Saurabh Nayar On 20071122
                    break;
            }

            subPopulateSpecInd();
            subPopulateEcon();
            subPopulateCategory();

            txtAddr1.Attributes.Add("onchange", "doFormat('" + txtAddr1.ClientID + "');");
            txtAddr2.Attributes.Add("onchange", "doFormat('" + txtAddr2.ClientID + "');");
            txtAddr3.Attributes.Add("onchange", "doFormat('" + txtAddr3.ClientID + "');");
            txtAddr4.Attributes.Add("onchange", "doFormat('" + txtAddr4.ClientID + "');");
            // ************************ Define buttons and textbox properties ************************
            txtSurname.Attributes.Add("onchange", "doFormat('" + txtSurname.ClientID + "');");
            txtBirthPlace.Attributes.Add("onchange", "IncorporatedtoProperCase(document.getElementById('" + txtBirthPlace.ClientID + "').value);");
			//Commented By Saurabh Nayar On 20071123
			//txtCity.Attributes.Add("onchange", "doFormat('" + txtCity.ClientID + "');");
            txtContactPerson.Attributes.Add("onchange", "ContactPersontoProperCase(document.getElementById('" + txtContactPerson.ClientID + "').value);");

            txtCountryCode.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                txtCountryCode.ClientID + "').value, '" +
                txtCountryDesc.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");

            btnCountry.Attributes.Add("onclick", "popCountryOrigin('" +
                txtCountryCode.ClientID + "','" +
                txtCountryDesc.ClientID + "'," +
                "document.getElementById('" +
                txtCountryCode.ClientID + "').value," +
                "document.getElementById('" +
                txtCountryDesc.ClientID + "').value,'" +
                "');return false;");

            btnSearchClt.Attributes.Add("onclick", "popSearchCorpClt('" +
                txtGCN.ClientID + "','" +
                txtSurname.ClientID + "','" +
                txtCurrentID.ClientID + "','" +
                txtDOB.ClientID + "_txtDate','" +
                txtWorkTel.ClientID + "'," +
                "document.getElementById('" + txtGCN.ClientID + "').value," +
                "document.getElementById('" + txtSurname.ClientID + "').value," +
                "document.getElementById('" + txtCurrentID.ClientID + "').value," +
                "document.getElementById('" + txtDOB.ClientID + "_txtDate').value," +
                "document.getElementById('" + txtWorkTel.ClientID + "').value" +
                ",'');return false;");

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
            txtCountryCodeAddr.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                txtCountryCodeAddr.ClientID + "').value, '" +
                txtCountryDescAddr.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
            btnCountryAddr.Attributes.Add("onclick", "popCountry('" +
                txtCountryCodeAddr.ClientID + "','" +
                txtCountryDescAddr.ClientID + "'," +
                "document.getElementById('" +
                txtCountryCodeAddr.ClientID + "').value," +
                "document.getElementById('" +
                txtCountryDescAddr.ClientID + "').value,'" +
                "');return false;");
            
            // ************************ Retrieve the particular GCN information ************************
            if (strGCNA.Length > 0)
            {
                string strGCN = string.Empty;
                strGCN = strGCNA.ToString();
                string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();

                if (strEnq == "1")
                {
                    this.btnSearchClt.Visible = false;
                    this.btnCancel.Visible = false;
                    this.btnCancel2.Visible = true;
                }

                ViewEntry();

                RetrieveClt(strGCN, strCarrierCode);
                RetrieveCltCnct(strGCN, strCarrierCode);
                RetrieveCltCorp(strGCN);
                RetrieveCltPer(strGCN);

                strInit += txtStateCode.Attributes["onblur"].ToString();
                strInit += txtCountryCodeAddr.Attributes["onblur"].ToString();
            }
            else
            {
                NewEntry();
            }

            string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup(); //HttpContext.Current.Session["UserGroupCode"].ToString();

            // ************************ Define authority for read only and read write ***********************
            if (strUserGroupCode.ToUpper() == "AGENT")
            {
                ReadEntry();
            }
            else
            {
                WriteEntry();
            }
            //Added By Saurabh Nayar On 20071122
            hdnDupFlag.Value = "CLNCRTO";
            txtDupBtnFlag.Text = "1";
            btnDupCltRecords.Enabled = false;
            //End Of Addition By Saurabh Nayar On 20071122
        }
        else
        {
            if (strGCNA.Length > 0)
            {
                string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
                string strGCN = string.Empty;
                strGCN = strGCNA.ToString();

                ViewEntry();
                if (strEnq == "1")
                {
                    this.btnSearchClt.Visible = false;
                    this.btnCancel.Visible = false;
                    this.btnCancel2.Visible = true;
                }

                lblHeader.Text = Convert.ToString("Corporate Client - View");

                //strInit += txtStateCode.Attributes["onblur"].ToString();
                //strInit += txtCountryCodeAddr.Attributes["onblur"].ToString();
            }
            else
            {
                if (strFlagFind.Length == 0)
                    NewEntry();
            }
        }        
                
        this.txtGCN.Enabled = false;
        this.txtCltCode.Enabled = false;
        txtSurname.Focus();
        btnDupCltRecords.Attributes.Add("onClick", "javascript: return funOpenPopWin('DuplicateCltRecords.aspx', '','1','0');");   
    }

    private void subPopulateCategory()
    {
        switch (Session["CarrierCode"].ToString())
        {
            case "1":
                oCommon.getDropDown(ddlCategory, "NLCategory", 1, "", 1, c_strBlank);
                break;

            case "2":
                oCommon.getDropDown(ddlCategory, "LFCategory", 1, "", 1, c_strBlank);
                break;
        }
    }

    private void subRenderPage()
    {
        if (strGCNA.Length > 0)
        {
            string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
            string strGCN = string.Empty;
            strGCN = strGCNA.ToString();

            ViewEntry();
            if (strEnq == "1")
            {
                this.btnSearchClt.Visible = false;
                this.btnCancel.Visible = false;
                this.btnCancel2.Visible = true;
            }

            lblHeader.Text = Convert.ToString("Corporate Client - View");

            //strInit += txtStateCode.Attributes["onblur"].ToString();
            //strInit += txtCountryCodeAddr.Attributes["onblur"].ToString();
        }
        else
        {
            if (strFlagFind.Length == 0)
                NewEntry();
        }
    }

    private void subPopulateSpecInd()
    {
        switch (Session["CarrierCode"].ToString())
        {
            case "1":
                oCommon.getDropDown(ddlSpecInd, "NLSpecInd", 1, "", 1, c_strBlank);
                break;

            case "2":
                oCommon.getDropDown(ddlSpecInd, "LFSpecInd", 1, "", 1, c_strBlank);
                break;
        }
    }

    private void subPopulateEcon()
    {
        oCommon.getDropDown(ddlEcon, "Econ", 1, "", 1, c_strBlank);
    }
    
    public void CheckAddress(object source, ServerValidateEventArgs args)
    {
        bool blnResult = true;

        // ************************ Define validation for contact type of dropdown button ***********************
        if (this.txtGCN.Text.Length > 0)
        {
            for (int i = 0; i < plcAddress.Controls.Count; i++)
            {
                Application_Common_ClientAddress oAddr = (Application_Common_ClientAddress)plcAddress.Controls[i];

                if (cboCnctType.SelectedIndex == i)
                {
                    if (!oAddr.HasValue)
                    {
                        blnResult = false;
                    }
                }
                args.IsValid = blnResult;
            }
        }
    }

    private void NewEntry()
    {
        this.lblHeader.Text = "Corporate Client - New";

        plcAddress.Visible = false;
        this.btnSave.Text = "Save";
        this.txtFlagFind.Text = string.Empty;

        this.txtStaffSz.Text = "0";
        this.txtCapital.Text = "0";
        this.txtAnnTurnover.Text = "0.00";
        this.txtCountryCode.Text = "IND";
        this.txtCountryDesc.Text = "INDIA";
        this.txtCountryCodeAddr.Text = "IND";
        this.txtCountryDescAddr.Text = "INDIA";
        //this.CltAddrB1.Country = "IND";
        //this.CltAddrB1.CountryDesc = "INDIA";

        this.UpdPanelHeader.Update();
//        HttpContext.Current.Session["dtCltCnct"] = null;
//        HttpContext.Current.Session["dtCltCorp"] = null;
        CnctType(true);
    }
    private void ViewEntry()
    {
        this.lblHeader.Text = "Corporate Client - View";

        plcAddress.Visible = true;
        this.btnSave.Text = "Update";
        this.UpdPanelHeader.Update();
        CnctType(false);
    }
    private void ReadEntry()
    {
        lblHeader.Text = lblHeader.Text + " (Read only)";
        this.txtCltCode.Enabled = false;
        this.txtSurname.Enabled = false;
        this.txtCurrentID.Enabled = false;
        this.cmdLookup1.Enabled = false;
        this.txtWorkTel.Enabled = false;
        this.txtCmpnyTel.Enabled = false;
        this.txtWorkFax.Enabled = false;
        this.txtWebsite.Enabled = false;
        this.txtEmail.Enabled = false;
        this.txtBirthPlace.Enabled = false;
        this.ddlDstbnMethod.ddliSysLParamEnabled = false;
        this.txtDOB.ReadOnly = true;
        this.txtDOB.ShowCalendar = false;
        this.txtCountryCode.Enabled = false;
        this.txtCountryDesc.Enabled = false;
        this.txtStaffSz.Enabled = false;
        this.txtCapital.Enabled = false;
        this.txtAnnTurnover.Enabled = false;
        this.chkSalesTax.Enabled = false;
        this.ddlDstbnMethod.ddliSysLParamEnabled = false;
        this.ddlPrivacy.ddliSysLParamEnabled = false;
        this.cboCnctType.Enabled = false;

        //this.CltAddrB1.txtAddr1Enabled = false;
        //this.CltAddrB1.txtAddr2Enabled = false;
        //this.CltAddrB1.txtAddr3Enabled = false;
        //this.CltAddrB1.txtAddr4Enabled = false;
        //this.CltAddrB1.txtCityEnabled = false;
        //this.CltAddrB1.txtPINEnabled = false;
        //this.CltAddrB1.cboCountryEnabled = false;
        //this.CltAddrB1.cboStateEnabled = false;

        this.txtAddr1.Enabled = false;
        this.txtAddr2.Enabled = false;
        this.txtAddr3.Enabled = false;
        this.txtAddr4.Enabled = false;
		//Commented By Saurabh Nayar On 20071123
        //this.txtCity.Enabled = false;
        this.txtStateCode.Enabled = false;
        this.txtStateDesc.Enabled = false;
        this.txtPin.Enabled = false;
        this.txtCountryCodeAddr.Enabled = false;
        this.txtCountryDescAddr.Enabled = false;

        this.btnSave.Enabled = false;
    }
    private void WriteEntry()
    {
        this.txtCltCode.Enabled = true;
        this.txtSurname.Enabled = true;
        this.txtCurrentID.Enabled = true;
        this.cmdLookup1.Enabled = true;
        this.txtWorkTel.Enabled = true;
        this.txtCmpnyTel.Enabled = true;
        this.txtWorkFax.Enabled = true;
        this.txtWebsite.Enabled = true;
        this.txtEmail.Enabled = true;
        this.txtBirthPlace.Enabled = true;
        this.ddlDstbnMethod.ddliSysLParamEnabled = true;
        this.txtDOB.ReadOnly = false;
        this.txtDOB.ShowCalendar = true;
        this.txtCountryCode.Enabled = true;
        this.txtCountryDesc.Enabled = true;
        this.txtStaffSz.Enabled = true;
        this.txtCapital.Enabled = true;
        this.txtAnnTurnover.Enabled = true;
        this.chkSalesTax.Enabled = true;
        this.ddlDstbnMethod.ddliSysLParamEnabled = true;
        this.ddlPrivacy.ddliSysLParamEnabled = true;
        this.cboCnctType.Enabled = true;

        //this.CltAddrB1.txtAddr1Enabled = true;
        //this.CltAddrB1.txtAddr2Enabled = true;
        //this.CltAddrB1.txtAddr3Enabled = true;
        //this.CltAddrB1.txtAddr4Enabled = true;
        //this.CltAddrB1.txtCityEnabled = true;
        //this.CltAddrB1.txtPINEnabled = true;
        //this.CltAddrB1.cboCountryEnabled = true;
        //this.CltAddrB1.cboStateEnabled = true;

        this.txtAddr1.Enabled = true;
        this.txtAddr2.Enabled = true;
        this.txtAddr3.Enabled = true;
        this.txtAddr4.Enabled = true;
		//Commented By Saurabh Nayar On 20071123
		//this.txtCity.Enabled = true;
        this.txtStateCode.Enabled = true;
        this.txtStateDesc.Enabled = true;
        this.txtPin.Enabled = true;
        this.txtCountryCodeAddr.Enabled = true;
        this.txtCountryDescAddr.Enabled = true;

        this.btnSave.Enabled = true;

    }
    private void ClearEntry()
    {
        dtClt.Clear();
        dtCltCnct.Clear();
        dtCltCorp.Clear();

        this.txtGCN.Text = string.Empty;
        this.txtCltCode.Text = string.Empty;
        this.txtSurname.Text = string.Empty;
        this.txtCurrentID.Text = string.Empty;
        this.txtDOB.Text = string.Empty;
        //this.cboResCntryCode.ClearData();
        //this.cboResCntryCode.ClearData() ;
        this.txtWorkTel.Text = string.Empty;
        this.txtCmpnyTel.Text = string.Empty;
        this.txtWorkFax.Text = string.Empty;
        this.txtEmail.Text = string.Empty;
        this.txtWebsite.Text = String.Empty;
        this.txtBirthPlace.Text = string.Empty;
        //this.cboResCntryCode.ClearData(); ;
        this.txtStaffSz.Text = "0";
        this.txtCapital.Text = "0";
        this.txtAnnTurnover.Text = "0.00";
        this.chkSalesTax.Checked = false;

        //this.CltAddrB1.Addr1Text = string.Empty;
        //this.CltAddrB1.Addr2Text = string.Empty;
        //this.CltAddrB1.Addr3Text = string.Empty;
        //this.CltAddrB1.Addr4Text = string.Empty;
        //this.CltAddrB1.City = string.Empty;
        //this.CltAddrB1.Pin = string.Empty;
        //this.CltAddrB1.ddlClearSelection();

        this.txtAddr1.Text = string.Empty;
        this.txtAddr2.Text = string.Empty;
        this.txtAddr3.Text = string.Empty;
        this.txtAddr4.Text = string.Empty;
		//Commented By Saurabh Nayar On 20071123
		//this.txtCity.Text = string.Empty;
        this.txtStateCode.Text = string.Empty;
        this.txtStateDesc.Text = string.Empty;
        this.txtPin.Text = string.Empty;
        this.txtCountryCodeAddr.Text = string.Empty;
        this.txtCountryDescAddr.Text = string.Empty;

        foreach (Control oControl in plcAddress.Controls)
        {
            Application_Common_ClientAddress oAdd = (Application_Common_ClientAddress)oControl;
            oAdd.Reset();
        }

        //btnAML.Reset();

    }
    private void UpdateEntry()
    {
        this.UpdPanelGCN.Update();
        this.UpdPanelCltCode.Update();
        this.UpdPanelSurname.Update();
        this.UpdPanelCurrentID.Update();
        this.UpdPanelCnctType.Update();
        this.UpdPanelddlDstbnMethod.Update();
        this.UpdPanelddlPrivacy.Update();
        this.UpdPanelWorkTel.Update();
        this.UpdPanelCmpnyTel.Update();
        this.UpdPanelWorkFax.Update();
        this.UpdPanelEmail.Update();
        this.UpdPanelWebsite.Update();
        this.UpdPanelDOB.Update();
        this.UpdPanelBirthPlace.Update();
        this.UpdPanelStaffSz.Update();
        this.UpdPanelCapital.Update();
        this.UpdPanelAnnTurnover.Update();
        this.UpdPanelSalesTax.Update();
    }
    private void CnctType(bool blnNew)
    {
        ListItem[] items = new ListItem[1];

        string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();

        cboCnctType.Items.Clear();
        if (blnNew)
        {
            dsCnctType.SelectCommand = "SELECT ParamValue, ParamDesc1 AS ParamDesc FROM IsysLookupParam WHERE LookupCode = 'CnctType' AND Paramvalue IN ('B1') Order by SortOrder"; //mlm.GetItemDesc("ds.SelectCommand") + " '" + lookupCode + "'," + LngCode + ",1";
        }
        else
        {
            dsCnctType.SelectCommand = "SELECT ParamValue, ParamDesc1 AS ParamDesc FROM IsysLookupParam WHERE LookupCode = 'CnctType' AND (Paramvalue LIKE 'B%') Order by SortOrder "; //mlm.GetItemDesc("ds.SelectCommand") + " '" + lookupCode + "'," + LngCode + ",1";
        }

        cboCnctType.DataBind();
    }

    private void RetrieveClt(string strGCN, string strCarrierCode)
    {
        ClearEntry();
        txtFlagFind.Text = strFlagFind.ToString();

        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
        dtClt = oMQCltMgr.GetClt(strGCN, strCarrierCode);

        if (dtClt.Rows.Count > 0)
        {
            HttpContext.Current.Session["GCN"] = dtClt.Rows[0]["GCN"].ToString();

            this.txtGCN.Text = dtClt.Rows[0]["GCN"].ToString();
            this.txtCltCode.Text = dtClt.Rows[0]["ClientCode"].ToString();
            this.txtSurname.Text = dtClt.Rows[0]["Surname"].ToString();
            this.txtDOB.Text = oCommon.fncFormatDate(dtClt.Rows[0]["BirthRegDate"].ToString(), "dd/MM/yyyy");
            this.txtCurrentID.Text = dtClt.Rows[0]["AltId"].ToString();
            this.txtCountryCode.Text = dtClt.Rows[0]["ResCntryCode"].ToString();
            this.txtCountryDesc.Text = dtClt.Rows[0]["ResCntryCodeDesc"].ToString();
            this.cboCnctType.SelectedValue = dtClt.Rows[0]["DefCnctType"].ToString();
            this.txtCmpnyTel.Text = dtClt.Rows[0]["HomeTel"].ToString();
            this.txtWorkFax.Text = dtClt.Rows[0]["MobileTel"].ToString();
            this.txtWorkTel.Text = dtClt.Rows[0]["WorkTel"].ToString();
            this.txtEmail.Text = dtClt.Rows[0]["Email"].ToString();
            this.ddlPrivacy.SelectedValue = dtClt.Rows[0]["PrivacyStat"].ToString();
            this.ddlDstbnMethod.SelectedValue = dtClt.Rows[0]["DstbnMethod"].ToString();
            this.txtWebsite.Text = dtClt.Rows[0]["WebsiteUrl"].ToString();
            this.txtBirthPlace.Text = dtClt.Rows[0]["BirthRegPlace"].ToString();
            chkVip.Checked = (dtClt.Rows[0]["PrfStat"].ToString() == "90");
            ddlSpecInd.SelectedValue = dtClt.Rows[0]["SpecInd" + Session["CarrierCode"].ToString()].ToString();
            ddlEcon.SelectedValue = dtClt.Rows[0]["Econ"].ToString();
            txtPan.Text = dtClt.Rows[0]["CurrentId"].ToString();
            ddlCategory.SelectedValue = dtClt.Rows[0]["Category" + Session["CarrierCode"].ToString()].ToString();
            if (dtClt.Rows[0]["TaxStat"].ToString() != string.Empty)
                if (dtClt.Rows[0]["TaxStat"].ToString() == "T")
                    this.chkSalesTax.Checked = true;
        }

        dtClt.Clear();
        dtClt = oMQCltMgr.GetCltCorp(strGCN);
        if (dtClt.Rows.Count > 0)
        {
			//Commented & Added By Saurabh Nayar On 20071127
			//this.txtCapital.Text = double.Parse(dtClt.Rows[0]["FinYrDayMn"].ToString()).ToString("f");
			this.txtCapital.Text = dtClt.Rows[0]["FinYrDayMn"].ToString();
			//End Of Addition By Saurabh Nayar On 20071127
            this.txtAnnTurnover.Text = double.Parse(dtClt.Rows[0]["AnnTurnover"].ToString()).ToString("f");
            this.txtStaffSz.Text = int.Parse(dtClt.Rows[0]["StaffSize"].ToString()).ToString();
        }
    }
    private string GetAddHeader(string strCnctType)
    {
        string strType = strCnctType.Substring(0, 1);
        string strNo = strCnctType.Substring(1, 1);
        string strDesc = string.Empty;

        switch (strType)
        {
            case "R":
                strDesc = "Residential Address " + strNo;
                break;
            case "B":
                strDesc = "Business Address " + strNo;
                break;
        }
        return strDesc;
    }
    //private void SetCltCnct(DataRow drCltCnct, Application_Common_CltDetailAddr cltDtlAddr)
    //{
    //    cltDtlAddr.ChangeHeader(GetAddHeader(drCltCnct["CnctType"].ToString().Trim()));
    //    cltDtlAddr.Addr1Text = drCltCnct["Adr1"].ToString().Trim();
    //    cltDtlAddr.Addr2Text = drCltCnct["Adr2"].ToString().Trim();
    //    cltDtlAddr.Addr3Text = drCltCnct["Adr3"].ToString().Trim();
    //    cltDtlAddr.Addr4Text = drCltCnct["Adr4"].ToString().Trim();
    //    cltDtlAddr.City = drCltCnct["City"].ToString().Trim();
    //    cltDtlAddr.Pin = drCltCnct["PostCode"].ToString().Trim();
    //    cltDtlAddr.StateCode = drCltCnct["StateCode"].ToString().Trim();
    //    cltDtlAddr.StateDesc = drCltCnct["StateCodeDesc"].ToString().Trim();
    //    cltDtlAddr.Country = drCltCnct["CntryCode"].ToString().Trim();
    //    cltDtlAddr.CountryDesc = drCltCnct["CntryCodeDesc"].ToString().Trim();
    //    cltDtlAddr.Visible = true;
    //}

    private void SetCltCnct(DataRow drCltCnct, Application_Common_ClientAddress oClientAddress)
    {
        oClientAddress.Value_Address1 = drCltCnct["Adr1"].ToString().Trim();
        oClientAddress.Value_Address2 = drCltCnct["Adr2"].ToString().Trim();
        oClientAddress.Value_Address3 = drCltCnct["Adr3"].ToString().Trim();
        oClientAddress.Value_Address4 = drCltCnct["Adr4"].ToString().Trim();
        oClientAddress.Value_City = drCltCnct["City"].ToString().Trim();
        oClientAddress.Value_Postcode = drCltCnct["PostCode"].ToString().Trim();
        oClientAddress.Value_State = drCltCnct["StateCode"].ToString().Trim();
        //popupCltAddr.StateDesc = drCltCnct["StateCodeDesc"].ToString();
        oClientAddress.Value_Country = drCltCnct["CntryCode"].ToString().Trim();
        //popupCltAddr.CountryDesc = drCltCnct["CntryCodeDesc"].ToString();
        txtContactPerson.Text = drCltCnct["AdrAtnTo"].ToString().Trim();
    }
    private void SetCltCnct(DataRow drCltCnct)
    {
        this.txtAddr1.Text = drCltCnct["Adr1"].ToString().Trim();
        this.txtAddr2.Text = drCltCnct["Adr2"].ToString().Trim();
        this.txtAddr3.Text = drCltCnct["Adr3"].ToString().Trim();
        this.txtAddr4.Text = drCltCnct["Adr4"].ToString().Trim();
		//Commented By Saurabh Nayar On 20071123
		//this.txtCity.Text = drCltCnct["City"].ToString().Trim();
        this.txtPin.Text = drCltCnct["PostCode"].ToString().Trim();
        this.txtStateCode.Text = drCltCnct["StateCode"].ToString().Trim();
        //popupCltAddr.StateDesc = drCltCnct["StateCodeDesc"].ToString();
        this.txtCountryCodeAddr.Text = drCltCnct["CntryCode"].ToString().Trim();
        //popupCltAddr.CountryDesc = drCltCnct["CntryCodeDesc"].ToString();
        txtContactPerson.Text = drCltCnct["AdrAtnTo"].ToString().Trim();
    }
    private void SetCltPer(DataRow drCltPer, Application_Common_ClientAML oClientAML)
    {
        oClientAML.Value_ChgWghtReason = drCltPer["ChgWghtReason"].ToString().Trim();
        //Commented by Anoop on 20-11-2007
        //oClientAML.Value_ProofAge = drCltPer["ProofAgeDoc"].ToString().Trim();
        //End of Comment
        oClientAML.Value_ProofAddr = drCltPer["ProofAddrDoc"].ToString().Trim();
        oClientAML.Value_ProofIncome = drCltPer["ProofIncomeDoc"].ToString().Trim();
        oClientAML.Value_ProofID = drCltPer["ProofIDDoc"].ToString().Trim();
        oClientAML.Value_IDNo = drCltPer["IDNo"].ToString().Trim();
        oClientAML.Value_IdIssueAuth = drCltPer["IdIssueAuth"].ToString().Trim();
        if (drCltPer["IdIssueDate"] != DBNull.Value)
            oClientAML.Value_IdIssueDate = drCltPer["IdIssueDate"].ToString().Trim();
        //Commented by Anoop on 20-11-nd
        //oClientAML.Value_ProofPhoto = drCltPer["ProofPhotoDoc"].ToString().Trim();
        //End of Comment

        if (drCltPer["HasPhoto"].ToString() != string.Empty)
            if (drCltPer["HasPhoto"].ToString() == "T")
                oClientAML.Value_chkPhoto = true.ToString();
    }

    private void RetrieveCltCnct(string strGCN, string strCarrierCode)
    {
        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
        dtCltCnct = oMQCltMgr.GetCltCnct(strGCN, strCarrierCode);

        for (int i = 0; i < dtCltCnct.Rows.Count; i++)
        {
            string strCnctType = dtCltCnct.Rows[i]["CnctType"].ToString();
            switch (strCnctType)
            {
                case "B1":
                    //SetCltCnct(dtCltCnct.Rows[i], CltAddrB1);
                    SetCltCnct(dtCltCnct.Rows[i]);
                    break;
                case "B2":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[0]);
                    break;
                case "B3":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[1]);
                    break;
                case "B4":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[2]);
                    break;
                case "B5":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[3]);
                    break;
                case "B6":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[4]);
                    break;
                case "B7":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[5]);
                    break;
                case "B8":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[6]);
                    break;
                case "B9":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[7]);
                    break;
                case "B0":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddress.Controls[8]);
                    break;
            }
        }
    }
    private void RetrieveCltCorp(string strGCN)
    {
        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

        dtCltCorp = oMQCltMgr.GetCltCorp(strGCN);

        if (dtCltCorp.Rows.Count > 0)
        {
            this.txtAnnTurnover.Text = double.Parse(dtCltCorp.Rows[0]["AnnTurnover"].ToString().Trim()).ToString("f");
            this.txtStaffSz.Text = int.Parse(dtCltCorp.Rows[0]["StaffSize"].ToString().Trim()).ToString();
			//Commented & Added By Saurabh Nayar On 20071127
			//this.txtCapital.Text = double.Parse(dtCltCorp.Rows[0]["FinYrDayMn"].ToString().Trim()).ToString("f");
			this.txtCapital.Text = dtCltCorp.Rows[0]["FinYrDayMn"].ToString().Trim();
			//End Of Addition By Saurabh Nayar On 20071127
            dtCltCorp.TableName = "CltCorp";
//            HttpContext.Current.Session["dtCltCorp"] = dtCltCorp;
            //PopupAML1.dtCltCorp1 = dtCltCorp;
        }
    }
    protected void RetrieveCltSrc(object sender, EventArgs e)
    {
        string strGCN = ((System.Web.UI.WebControls.Button)(sender)).Text;
        string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();

        if (strGCN.Length > 0)
        {
            ViewEntry();
            RetrieveClt(strGCN, strCarrierCode);
            RetrieveCltCnct(strGCN, strCarrierCode);
            RetrieveCltCorp(strGCN);
            RetrieveCltPer(strGCN);
            UpdateEntry();
        }
    }
    protected void RetrievePopClt(object sender, EventArgs e)
    {
        Response.Redirect("CorpClt.aspx?ENQ=0&FLAGFIND=1&GCN=" + txtGCN.Text);
    }
    private void RetrieveCltPer(string strGCN)
    {
        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
        dtCltPer = oMQCltMgr.GetCltPer(strGCN);

        if (dtCltPer.Rows.Count > 0)
        {
            SetCltPer(dtCltPer.Rows[0], btnAML);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to cancel ?", "Confirmation", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
        if (result == System.Windows.Forms.DialogResult.Yes)
			//Response.Redirect("CorpClt.aspx?ENQ=" + strEnq + "&GCN=" + txtGCN.Text + "&FLAGFIND=" + txtFlagFind.Text);
			Response.Redirect("CorpClt.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        dsClt = new DataSet();
        dsClt = CltDataSet();


        // *********************************** Call MQ ***********************************
        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strCltType = "C";
        strSrc = "1";
        strErrMsg = string.Empty;
        strStatusMsg = string.Empty;
        intStatusCode = 0;
		string strStatus = "";
        if (txtGCN.Text != String.Empty && txtGCN.Text != "System.Web.UI.WebControls.TextBox")
        {
            intStatusCode = oMQCltMgr.SaveClient(2, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);

            #region BO Calling Mustafa 03 Nov 2007
            DataTable dtClt = dsClt.Tables["Clt"];
            string strClientCode = string.Empty;

            Insc.MQ.Life.CrpCltCr.MQCrpCltCr oCrpCltCr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCr();
            Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr oCrpCltMgr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr();
            Insc.MQ.Common.Client.MQClientMgr oClientMgr = new Insc.MQ.Common.Client.MQClientMgr();
            Insc.MQ.Life.CrpCltMod.MQCrpCltMod oCrpCltMod = new Insc.MQ.Life.CrpCltMod.MQCrpCltMod();
            Insc.MQ.Life.CrpCltMod.MQCrpCltModMgr oCrpCltModMgr = new Insc.MQ.Life.CrpCltMod.MQCrpCltModMgr();
			
			DataSet dsClient = new DataSet();
			dsClient = oClientMgr.GetCltStatus(txtSurname.Text.ToString(), strCltType);

			if (dsClient.Tables.Count > 0)
			{
				strStatus = dsClient.Tables[0].Rows[0][0].ToString();

				//string strStatus = oClientMgr.GetCltStatus(txtSurname.Text.ToString(), strCltType);

				char[] splitter = { '/' };
				string[] strDt = DateTime.Now.ToString("dd/MM/yyyy").Split(splitter);
				string[] strArrParam = new string[33];
				if (strStatus == "A")
				{
					if (hdnDupFlag.Value == "DUPCLT")
					{
						strArrParam[0] = hdnClientCode.Value;   //ClientCode
					}
					else
					{
						strArrParam[0] = txtCltCode.Text.Trim(); //ClientCode
					}
					strArrParam[1] = ""; //@ClientSecureID
					if (txtCapital.Text.Trim() != "")
					{
						strArrParam[2] = Convert.ToString(Math.Round(Convert.ToDouble(txtCapital.Text.Trim())));
					}
					else
					{
						strArrParam[2] = "";
					}
					strArrParam[3] = txtAddr1.Text.Trim();
					strArrParam[4] = txtAddr2.Text.Trim();
					strArrParam[5] = txtAddr3.Text.Trim();
					strArrParam[6] = txtStateDesc.Text;
					strArrParam[7] = txtPin.Text;
					strArrParam[8] = txtWorkTel.Text;
					strArrParam[9] = txtCmpnyTel.Text;
					strArrParam[10] = txtCountryCode.Text;
					strArrParam[11] = txtCountryCode.Text;
					strArrParam[12] = "I";  //@DirectMailIndicator
					strArrParam[13] = ddlEcon.SelectedValue;   //@EconomyActivity
					strArrParam[14] = txtContactPerson.Text;    ////@ForTheAttentionof
					strArrParam[15] = txtWorkFax.Text;      //@FacsimileNo
					strArrParam[16] = "E";      //@Languag
					strArrParam[17] = "";       //@LongGivenName
					strArrParam[18] = "Y";      //@MailingIndicator
					strArrParam[19] = "";       //@SocialsecurityNo
					strArrParam[20] = "10";     //@ServicingBranch
					strArrParam[21] = Convert.ToString(strDt[2]);   //@StartDateYear
					strArrParam[22] = Convert.ToString(strDt[1]);     //@StartDateMonth
					strArrParam[23] = Convert.ToString(strDt[0]);     //@StartDate
					strArrParam[24] = txtStaffSz.Text;   //@StaffNumber
					strArrParam[25] = ddlCategory.SelectedValue;       //@StatusCode
					strArrParam[26] = "";       //@TelegramNo
					strArrParam[27] = "";       //@TelexNo
					strArrParam[28] = (chkVip.Checked == true) ? "Y" : "N";     //@VIPIndicator
					strArrParam[29] = txtEmail.Text.Trim();       //@InternetAddress
					strArrParam[30] = txtPan.Text;  //@TaxIdNo
					strArrParam[31] = ddlSpecInd.SelectedValue;       //@SpecialIndicator
					strArrParam[32] = Convert.ToString(Session["CarrierCode"]);

					string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
					//intStatusCode = oCrpCltMgr.BOCrpCltCrDTLS(strArrParam, strCarrierCode, ref oCrpCltCr, strErrMsg);
					//intStatusCode = oClientCrMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oClientCr, ref strErrMsg);
					intStatusCode = oCrpCltModMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oCrpCltMod, ref strErrMsg);

					if (intStatusCode == 0)
					{
						strClientCode = oCrpCltMod.strCLTCRNUM;

						int intRowsAffected = 0;

						oClientMgr.UpdateClientCode(strGCN, strCarrierCode, strGCN);
						oClientMgr.UpdateClientCode(strGCN, strCarrierCode, strDefCnctType, strGCN);

						if (hdnDupFlag.Value == "DUPCLT")
						{
							//logic for updating duplicate client code to temp client code in INSC
							oClientMgr.UpdateDupCltDtls(hdnClientCode.Value, hdnTempClientCode.Value, Session["CarrierCode"].ToString(), "C");
						}


						lblErrMsg.Text = "Corporate Client Updated Sucessfully.";
						lblErrMsg.Visible = true;

						Session["GCN"] = oCrpCltMod.strCLTCRNUM;
						txtCltCode.Text = oCrpCltMod.strCLTCRNUM;
						txtGCN.Text = oCrpCltCr.strCLTCRNUM;
						if (strErrMsg.Length > 0)
						{
							lblError2.Text = strErrMsg.ToString();
							MPEError.Show();
						}
						else
						{
							if (strGCN.Length > 0)
							{
								if (txtGCN.Text.Length > 0)
								{
									lblError1.Text = "Message";
									lblError2.Text = "Client updated successfully!";
									MPEError.Show();
								}
								else
								{
									lblError1.Text = "Message";
									lblError2.Text = "Client created successfully!";
									MPEError.Show();
								}
							}
						}
					}
					else
					{
						lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
						lblErrMsg.Visible = true;
					}
				}
				else if (strStatus == "P")
				{
					
					#region BO Calling Mustafa 03 Nov 2007
					
					char[] splitterNew = { '/' };
					string[] strDtNew = DateTime.Now.ToString("dd/MM/yyyy").Split(splitterNew);
					string[] strArrParamNew = new string[32];

					//if (strStatus == "A")
					//{				
					strArrParamNew[0] = txtSurname.Text.Trim();
					if (txtCapital.Text.Trim() != "")
					{
						strArrParamNew[1] = Convert.ToString(Math.Round(Convert.ToDouble(txtCapital.Text.Trim())));	//@PaidUpcapital
					}
					else
					{
						strArrParamNew[1] = "";		//@PaidUpcapital
					}
					strArrParamNew[2] = txtAddr1.Text.Trim();
					strArrParamNew[3] = txtAddr2.Text.Trim();
					strArrParamNew[4] = txtAddr3.Text.Trim();
					strArrParamNew[5] = txtStateDesc.Text;
					strArrParamNew[6] = txtPin.Text;
					strArrParamNew[7] = txtWorkTel.Text;
					strArrParamNew[8] = txtCmpnyTel.Text;
					strArrParamNew[9] = txtCountryCode.Text;
					strArrParamNew[10] = txtCountryCode.Text;
					strArrParamNew[11] = "I";        //@DirectMailIndicator
					strArrParamNew[12] = ddlEcon.SelectedValue;      //@EconomyActivity
					strArrParamNew[13] = txtContactPerson.Text;          //@ForTheAttentionof
					strArrParamNew[14] = txtWorkFax.Text;      //@FacsimileNo
					strArrParamNew[15] = "E";      //@Languag
					strArrParamNew[16] = "";       //@LongGivenName
					strArrParamNew[17] = "Y";      //@MailingIndicator
					strArrParamNew[18] = "";       //@SocialsecurityNo
					strArrParamNew[19] = "10";     //@ServicingBranch
					strArrParamNew[20] = Convert.ToString(strDtNew[2]);   //@StartDateYear
					strArrParamNew[21] = Convert.ToString(strDtNew[1]);     //@StartDateMonth
					strArrParamNew[22] = Convert.ToString(strDtNew[0]);     //@StartDate
					strArrParamNew[23] = txtStaffSz.Text;   //@StaffNumber
					strArrParamNew[24] = ddlCategory.SelectedValue;       //@StatusCode
					strArrParamNew[25] = "";       //@TelegramNo
					strArrParamNew[26] = "";       //@TelexNo
					strArrParamNew[27] = (chkVip.Checked == true) ? "Y" : "N";     //@VIPIndicator
					strArrParamNew[28] = txtEmail.Text.Trim();       //@InternetAddress
					strArrParamNew[29] = txtPan.Text;  //@TaxIdNo
					strArrParamNew[30] = ddlSpecInd.SelectedValue;       //@SpecialIndicator
					strArrParamNew[31] = Convert.ToString(Session["CarrierCode"]);

					string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
					//intStatusCode = oCrpCltMgr.BOCrpCltCrDTLS(strArrParam, strCarrierCode, ref oCrpCltCr, strErrMsg);
					//intStatusCode = oClientCrMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oClientCr, ref strErrMsg);
					intStatusCode = oCrpCltMgr.FetchClientCreationDetailsFromLA(strArrParamNew, strCarrierCode, ref oCrpCltCr, ref strErrMsg);

					if (oCrpCltCr.dtCrpClt != null)
					{
					    if (oCrpCltCr.dtCrpClt.Rows.Count > 0)
					    {
					        DataTable dtRecords = oCrpCltCr.dtCrpClt;
					        HttpContext.Current.Session["dtRecords"] = dtRecords;
					        lblErrMsg.Text = "Duplicate Corporate Client Records Found.";
					        lblErrMsg.Visible = true;
					        txtGCN.Text = strGCN;
					        txtCltCode.Text = strGCN;
					        hdnTempClientCode.Value = strGCN;
					        hdnDupFlag.Value = "DUPCLT";
					        txtDupBtnFlag.Text = "";
					        btnDupCltRecords.Enabled = true;
					    }
					}
					else
					{
						if (intStatusCode == 0)
						{
							strClientCode = oCrpCltCr.strCLTCRNUM;

							int intRowsAffected = 0;

							oClientMgr.AddClientCode(strGCN, strCarrierCode, strClientCode);
							oClientMgr.AddClientCode(strGCN, strCarrierCode, strDefCnctType, strClientCode);

							oClientMgr.UpdateCltStatus(strClientCode);
							oClientMgr.UpdateCltGCNINAGN(strGCN, txtSurname.Text, strClientCode);

							lblErrMsg.Text = "Corporate Client Created Sucessfully.";
							lblErrMsg.Visible = true;

							if (strErrMsg.Length > 0)
							{
								lblError2.Text = strErrMsg.ToString();
								MPEError.Show();
							}
							else
							{
								if (strGCN.Length > 0)
								{
									if (txtGCN.Text.Length > 0)
									{
										lblError1.Text = "Message";
										lblError2.Text = "Client updated successfully!";
										MPEError.Show();
									}
									else
									{
										lblError1.Text = "Message";
										lblError2.Text = "Client created successfully!";
										MPEError.Show();
									}
								}
							}
							Session["GCN"] = oCrpCltCr.strCLTCRNUM;
							txtGCN.Text = oCrpCltCr.strCLTCRNUM;
							txtCltCode.Text = oCrpCltCr.strCLTCRNUM;
						}//End if (intStatusCode == 0)
						else
						{
							lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
							lblErrMsg.Visible = true;

						}
					}
					#endregion					
				}

			#endregion
			}
        }
        else
        {
            try
            {
                intStatusCode = oMQCltMgr.SaveClient(0, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
                if (intStatusCode > 0)
                {
                    if (intStatusCode == 1)
                    {
                        //System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("There is One MATCH record found. Do You want to create New or Update? Click 'Yes' for Create New and click 'No' for Update Client.", "Caption", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question);
                        lblComfirm1.Text = "One MATCH record found.";
                        lblComfirm2.Text = "Do you want to create New or Update?";
                        lblComfirm3.Text = "Click 'Yes' for create New and click 'No' for update Client.";

                        MPEComfirm.Show();
                        //this.rfvFlg.Enabled = false;
                    }
                    else if (intStatusCode == 2)
                    {
                        //System.Windows.Forms.DialogResult result2 = System.Windows.Forms.MessageBox.Show("Mulitple MATCH record found ? Do You want to create New? Click 'Yes' for Create New.", "Caption", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question);
                        lblComfirmM1.Text = "Multiple/Partial MATCH records found.";
                        lblComfirmM2.Text = "Do you want to create New? ";
                        lblComfirmM3.Text = "Click 'Yes' for create New.";

                        MPEComfirmM.Show();
                        //this.rfvFlg.Enabled = false;
                    }

                    if ((intStatusCode == 1) || (intStatusCode == 2))
                    {
                        ErrMsg_SetFocus();
                    }
                }
				
				
                #region BO Calling Mustafa 03 Nov 2007
                DataTable dtClt = dsClt.Tables["Clt"];
                string strClientCode = string.Empty;

                Insc.MQ.Life.CrpCltCr.MQCrpCltCr oCrpCltCr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCr();
                Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr oCrpCltMgr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr();
                Insc.MQ.Common.Client.MQClientMgr oClientMgr = new Insc.MQ.Common.Client.MQClientMgr();
                Insc.MQ.Life.CltCr.MQCltCr oClientCr = new Insc.MQ.Life.CltCr.MQCltCr();
                Insc.MQ.Life.CltCr.MQCltCrMgr oClientCrMgr = new Insc.MQ.Life.CltCr.MQCltCrMgr();

				
				char[] splitter = { '/' };
				string[] strDt = DateTime.Now.ToString("dd/MM/yyyy").Split(splitter);
				string[] strArrParam = new string[32];

				//if (strStatus == "A")
				//{				
					strArrParam[0] = txtSurname.Text.Trim();
					if (txtCapital.Text.Trim() != "")
					{
						strArrParam[1] = Convert.ToString(Math.Round(Convert.ToDouble(txtCapital.Text.Trim())));	//@PaidUpcapital
					}
					else
					{
						strArrParam[1] = "";		//@PaidUpcapital
					}
					strArrParam[2] = txtAddr1.Text.Trim();
					strArrParam[3] = txtAddr2.Text.Trim();
					strArrParam[4] = txtAddr3.Text.Trim();
					strArrParam[5] = txtStateDesc.Text;
					strArrParam[6] = txtPin.Text;
					strArrParam[7] = txtWorkTel.Text;
					strArrParam[8] = txtCmpnyTel.Text;
					strArrParam[9] = txtCountryCode.Text;
					strArrParam[10] = txtCountryCode.Text;
					strArrParam[11] = "I";        //@DirectMailIndicator
					strArrParam[12] = ddlEcon.SelectedValue;      //@EconomyActivity
					strArrParam[13] = txtContactPerson.Text;          //@ForTheAttentionof
					strArrParam[14] = txtWorkFax.Text;      //@FacsimileNo
					strArrParam[15] = "E";      //@Languag
					strArrParam[16] = "";       //@LongGivenName
					strArrParam[17] = "Y";      //@MailingIndicator
					strArrParam[18] = "";       //@SocialsecurityNo
					strArrParam[19] = "10";     //@ServicingBranch
					strArrParam[20] = Convert.ToString(strDt[2]);   //@StartDateYear
					strArrParam[21] = Convert.ToString(strDt[1]);     //@StartDateMonth
					strArrParam[22] = Convert.ToString(strDt[0]);     //@StartDate
					strArrParam[23] = txtStaffSz.Text;   //@StaffNumber
					strArrParam[24] = ddlCategory.SelectedValue;       //@StatusCode
					strArrParam[25] = "";       //@TelegramNo
					strArrParam[26] = "";       //@TelexNo
					strArrParam[27] = (chkVip.Checked == true) ? "Y" : "N";     //@VIPIndicator
					strArrParam[28] = txtEmail.Text.Trim();       //@InternetAddress
					strArrParam[29] = txtPan.Text;  //@TaxIdNo
					strArrParam[30] = ddlSpecInd.SelectedValue;       //@SpecialIndicator
					strArrParam[31] = Convert.ToString(Session["CarrierCode"]);

					string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
					//intStatusCode = oCrpCltMgr.BOCrpCltCrDTLS(strArrParam, strCarrierCode, ref oCrpCltCr, strErrMsg);
					//intStatusCode = oClientCrMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oClientCr, ref strErrMsg);
					intStatusCode = oCrpCltMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oCrpCltCr, ref strErrMsg);

					if (oCrpCltCr.dtCrpClt != null)
					{
						if (oCrpCltCr.dtCrpClt.Rows.Count > 0)
						{
							DataTable dtRecords = oCrpCltCr.dtCrpClt;
							HttpContext.Current.Session["dtRecords"] = dtRecords;
							lblErrMsg.Text = "Duplicate Corporate Client Records Found.";
							lblErrMsg.Visible = true;
							txtGCN.Text = strGCN;
							txtCltCode.Text = strGCN;
							hdnTempClientCode.Value = strGCN;
							hdnDupFlag.Value = "DUPCLT";
							txtDupBtnFlag.Text = "";
							btnDupCltRecords.Enabled = true;
						}
					}
					else
					{
						if (intStatusCode == 0)
						{
							strClientCode = oCrpCltCr.strCLTCRNUM;

							int intRowsAffected = 0;

							oClientMgr.AddClientCode(strGCN, strCarrierCode, strClientCode);
							oClientMgr.AddClientCode(strGCN, strCarrierCode, strDefCnctType, strClientCode);

							oClientMgr.UpdateCltStatus(strClientCode);

							lblErrMsg.Text = "Corporate Client Created Sucessfully.";
							lblErrMsg.Visible = true;

							if (strErrMsg.Length > 0)
							{
								lblError2.Text = strErrMsg.ToString();
								MPEError.Show();
							}
							else
							{
								if (strGCN.Length > 0)
								{
									if (txtGCN.Text.Length > 0)
									{
										lblError1.Text = "Message";
										lblError2.Text = "Client updated successfully!";
										MPEError.Show();
									}
									else
									{
										lblError1.Text = "Message";
										lblError2.Text = "Client created successfully!";
										MPEError.Show();
									}
								}
							}
							Session["GCN"] = oCrpCltCr.strCLTCRNUM;
							txtGCN.Text = oCrpCltCr.strCLTCRNUM;
							txtCltCode.Text = oCrpCltCr.strCLTCRNUM;
						}//End if (intStatusCode == 0)
						else
						{
							lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
							lblErrMsg.Visible = true;

						}
					}
				#endregion					
            }
            catch (Exception Ex)
            {
                lblErrMsg.Text = "Error Updating Record- " + Ex.Message;
                lblErrMsg.Visible = true;
            }
        }//End Else

  
     
    }

    protected void ErrMsg_SetFocus()
    {
        cboCnctType.Attributes.Add("style", "display: hidden");
        ddlDstbnMethod.Attributes.Add("style", "display: hidden");
        ddlPrivacy.Attributes.Add("style", "display: hidden");
    }
    protected void ErrMsg_ReSetFocus()
    {
        cboCnctType.Attributes.Add("style", "display: visible");
        ddlDstbnMethod.Attributes.Add("style", "display: visible");
        ddlPrivacy.Attributes.Add("style", "display: visible");
    }
    protected void hdnbtn_OnClick(object sender, EventArgs e)
    {
        cboCnctType.Attributes.Add("style", "display: hidden");
        ddlDstbnMethod.Attributes.Add("style", "display: hidden");
        ddlPrivacy.Attributes.Add("style", "display: hidden");
    }
    protected void hdnComfirmbtn_OnClick(object sender, EventArgs e)
    {
        cboCnctType.Attributes.Add("style", "display: hidden");
        ddlDstbnMethod.Attributes.Add("style", "display: hidden");
        ddlPrivacy.Attributes.Add("style", "display: hidden");
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        MPEComfirm.Hide();
        MPEComfirmM.Hide();
        MPEError.Hide();

        cboCnctType.Attributes.Add("style", "display: visible");
        ddlDstbnMethod.Attributes.Add("style", "display: visible");
        ddlPrivacy.Attributes.Add("style", "display: visible");
    }

    private DataSet CltDataSet()
    {
        // *** Reset Dataset, Datatable and Datarow ***
        dsClt = new DataSet();
        dtClt = new DataTable("Clt");
        dtCltCnct = new DataTable("CltCnct");
        dtCltCorp = new DataTable("CltCorp");
        dtCltPer = new DataTable("CltPer");

        DataRow drClt = dtClt.NewRow();
        DataRow drCltAddr = dtCltCnct.NewRow();
        DataRow drCltCorp = dtCltCorp.NewRow();
        DataRow drCltPer = dtCltPer.NewRow();

        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();
        string strGCN = txtGCN.ToString();

        // *********************************** Table Clt ***********************************
        if (dtClt.Columns.Count == 0)
        {
            dtClt.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CltType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Title", System.Type.GetType("System.String"));
            dtClt.Columns.Add("GivenName", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Surname", System.Type.GetType("System.String"));
            dtClt.Columns.Add("BirthRegDate", System.Type.GetType("System.DateTime"));
            dtClt.Columns.Add("BirthRegPlace", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Gender", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CurrentID", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CurrentIDType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AltID", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AltIDType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("MaritalStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AnniversaryDate", System.Type.GetType("System.DateTime"));
            dtClt.Columns.Add("Nationality", System.Type.GetType("System.String"));
            dtClt.Columns.Add("ResStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("ResCntryCode", System.Type.GetType("System.String"));
            dtClt.Columns.Add("QualCode", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DefCnctType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("HomeTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("MobileTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("WorkTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Email", System.Type.GetType("System.String"));
            dtClt.Columns.Add("OcpnCode01", System.Type.GetType("System.String"));
            dtClt.Columns.Add("PrivacyStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DstbnMethod", System.Type.GetType("System.String"));
            dtClt.Columns.Add("WebsiteUrl", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CreateBy", System.Type.GetType("System.String"));
            dtClt.Columns.Add("TaxStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("PrfStat", System.Type.GetType("System.Int32"));
            dtClt.Columns.Add("SpecInd1", System.Type.GetType("System.String"));
            dtClt.Columns.Add("SpecInd2", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Econ", System.Type.GetType("System.String"));            
            dtClt.Columns.Add("Category1", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Category2", System.Type.GetType("System.String"));
        }

        //Commented & Added By Saurabh Nayar On 20071122
        //drClt["GCN"] = this.txtGCN.Text.Trim();
        if (hdnDupFlag.Value == "DUPCLT")
        {
            drClt["GCN"] = hdnTempClientCode.Value;
        }
        else
        {
            drClt["GCN"] = this.txtGCN.Text;
        }
        //End Of Addition By Saurabh Nayar On 20071122
        drClt["CltType"] = "C";
        drClt["Title"] = string.Empty;
        drClt["GivenName"] = String.Empty;
        drClt["Surname"] = this.txtSurname.Text.Trim();
        if (this.txtDOB.Text != String.Empty)
            drClt["BirthRegDate"] = this.txtDOB.Text;
        drClt["BirthRegPlace"] = this.txtBirthPlace.Text.Trim();
        drClt["Gender"] = "C";
        drClt["CurrentID"] = txtPan.Text;
        drClt["CurrentIDType"] = "P";
        drClt["AltID"] = this.txtCurrentID.Text.Trim();
        drClt["AltIDType"] = "R";
        drClt["MaritalStat"] = string.Empty;
        drClt["ResStat"] = string.Empty;
        drClt["ResCntryCode"] = txtCountryCode.Text.Trim();
        drClt["QualCode"] = string.Empty;
        drClt["DefCnctType"] = this.cboCnctType.SelectedValue.Trim();
        drClt["HomeTel"] = this.txtCmpnyTel.Text.Trim();
        drClt["MobileTel"] = this.txtWorkFax.Text.Trim();
        drClt["WorkTel"] = this.txtWorkTel.Text.Trim();
        drClt["Email"] = this.txtEmail.Text.Trim();
        drClt["OcpnCode01"] = string.Empty;
        drClt["PrivacyStat"] = this.ddlPrivacy.SelectedValue.Trim();
        drClt["DstbnMethod"] = this.ddlDstbnMethod.SelectedValue.Trim();
        drClt["WebsiteUrl"] = this.txtWebsite.Text.Trim();
        drClt["CreateBy"] = strUserGCN.Trim();
        drClt["TaxStat"] = Convert.ToString(this.chkSalesTax.Checked);
        drClt["PrfStat"] = (chkVip.Checked ? 90 : 50);
        drClt["SpecInd" + Session["CarrierCode"].ToString()] = ddlSpecInd.SelectedValue;
        drClt["Category" + Session["CarrierCode"].ToString()] = ddlCategory.SelectedValue;
        drClt["Econ"] = ddlEcon.SelectedValue;        
        
        dtClt.Rows.Add(drClt);

        // *********************************** Table CltCnct ***********************************
        if (dtCltCnct.Rows.Count == 0)
        {
            dtCltCnct.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CnctType", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr1", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr2", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr3", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr4", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("City", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Postcode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Statecode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Cntrycode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CreateBy", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("AdrAtnTo", System.Type.GetType("System.String"));
        }

        if (this.txtAddr1.Text.Trim() != string.Empty)
        {
            drCltAddr["GCN"] = txtGCN.Text.Trim();
            drCltAddr["CnctType"] = "B1";
            //drCltAddr["Adr1"] = CltAddrB1.Addr1Text.Trim();
            //drCltAddr["Adr2"] = CltAddrB1.Addr2Text.Trim();
            //drCltAddr["Adr3"] = CltAddrB1.Addr3Text.Trim();
            //drCltAddr["Adr4"] = CltAddrB1.Addr4Text.Trim();
            //drCltAddr["City"] = CltAddrB1.City.Trim();
            //drCltAddr["Postcode"] = CltAddrB1.Pin.Trim();
            //drCltAddr["Statecode"] = CltAddrB1.StateCode.Trim();
            //drCltAddr["Cntrycode"] = CltAddrB1.Country.Trim();
            drCltAddr["Adr1"] = this.txtAddr1.Text.Trim();
            drCltAddr["Adr2"] = this.txtAddr2.Text.Trim();
            drCltAddr["Adr3"] = this.txtAddr3.Text.Trim();
            drCltAddr["Adr4"] = this.txtAddr4.Text.Trim();
			//Commented & Added By Saurabh Nayar On 20071123
			//drCltAddr["City"] = this.txtCity.Text.Trim();
			drCltAddr["City"] = "";
			//End Of Addition By Saurabh Nayar On 20071123
            drCltAddr["Postcode"] = this.txtPin.Text.Trim();
            drCltAddr["Statecode"] = this.txtStateCode.Text.Trim();
            drCltAddr["Cntrycode"] = this.txtCountryCodeAddr.Text.Trim();
            drCltAddr["CreateBy"] = strUserGCN.Trim();
            drCltAddr["AdrAtnTo"] = txtContactPerson.Text.Trim();
            
            dtCltCnct.Rows.Add(drCltAddr);
        }

        // *********************************** Multiple Address ***********************************
        
        int intContactType = 2;
        foreach (Control oControl in plcAddress.Controls)
        {
            Application_Common_ClientAddress oAddr = (Application_Common_ClientAddress)oControl;
            if (oAddr.Value_Address1 != String.Empty)
            {
                DataRow drCltCnct = dtCltCnct.NewRow();
                drCltCnct["GCN"] = txtGCN.Text.Trim();
                if (intContactType == 10)
                    drCltCnct["CnctType"] = "B0";
                else
                    drCltCnct["CnctType"] = "B" + intContactType.ToString();
                drCltCnct["Adr1"] = oAddr.Value_Address1.Trim();
                drCltCnct["Adr2"] = oAddr.Value_Address2.Trim();
                drCltCnct["Adr3"] = oAddr.Value_Address3.Trim();
                drCltCnct["Adr4"] = oAddr.Value_Address4.Trim();
                drCltCnct["City"] = oAddr.Value_City.Trim();
                drCltCnct["Postcode"] = oAddr.Value_Postcode.Trim();
                drCltCnct["Statecode"] = oAddr.Value_State.Trim();
                drCltCnct["Cntrycode"] = oAddr.Value_Country.Trim();
                drCltCnct["CreateBy"] = strUserGCN.Trim();
                drCltCnct["AdrAtnTo"] = txtContactPerson.Text.Trim();
            
                dtCltCnct.Rows.Add(drCltCnct);
                drCltCnct = null;
            }
            intContactType++;
            oAddr = null;
        }
       

        // *********************************** Table CltCorp ***********************************
        if (dtCltCorp.Rows.Count == 0)
        {
            dtCltCorp.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltCorp.Columns.Add("AnnTurnover", System.Type.GetType("System.Double"));
            dtCltCorp.Columns.Add("StaffSize", System.Type.GetType("System.Int16"));
            dtCltCorp.Columns.Add("FinYrDayMn", System.Type.GetType("System.Double"));
            dtCltCorp.Columns.Add("UpdateBy", System.Type.GetType("System.String"));
        }

        drCltCorp["GCN"] = this.txtGCN.Text.Trim();
        if (this.txtAnnTurnover.Text.Trim() != string.Empty)
            drCltCorp["AnnTurnover"] = this.txtAnnTurnover.Text.Trim();
        else
            drCltCorp["AnnTurnover"] = "0";
        if (this.txtStaffSz.Text.Trim() != string.Empty)
            drCltCorp["StaffSize"] = this.txtStaffSz.Text.Trim();
        else
            drCltCorp["StaffSize"] = "0";
        if (this.txtCapital.Text.Trim() != string.Empty)
            drCltCorp["FinYrDayMn"] = this.txtCapital.Text.Trim();
        else
            drCltCorp["FinYrDayMn"] = "0";
        drCltCorp["UpdateBy"] = strUserGCN.Trim();

        dtCltCorp.Rows.Add(drCltCorp);

        // *********************************** Table CltPer ***********************************
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

        drCltPer = dtCltPer.NewRow();
        drCltPer["GCN"] = txtGCN.Text.Trim();
        drCltPer["Height"] = String.Empty;
        drCltPer["Weight"] = String.Empty;
        drCltPer["ChgWghtReason"] = btnAML.Value_ChgWghtReason.Trim();
        //Commented and added by Anoop on 20-11-2007
        //drCltPer["ProofAgeDoc"] = btnAML.Value_ProofAge.Trim();
        //End of Comment and addidtion
        drCltPer["ProofAgeDoc"] = "";
        drCltPer["ProofAddrDoc"] = btnAML.Value_ProofAddr.Trim();
        drCltPer["ProofIncomeDoc"] = btnAML.Value_ProofIncome.Trim();
        drCltPer["ProofIDDoc"] = btnAML.Value_ProofID.Trim();
        drCltPer["IdIssueAuth"] = btnAML.Value_IdIssueAuth.Trim();
        drCltPer["IdNo"] = btnAML.Value_IDNo.Trim();
        if (btnAML.Value_IdIssueDate.Trim() != string.Empty)
            drCltPer["IdIssueDate"] = Convert.ToDateTime(btnAML.Value_IdIssueDate.Trim()).ToString("dd/MM/yyyy");
        if (btnAML.Value_chkPhoto.Trim() != string.Empty)
        {
            if (btnAML.Value_chkPhoto.Trim() == "true")
                drCltPer["HasPhoto"] = true;
            else
                drCltPer["HasPhoto"] = false;
        }
        //Commented and added by Anoop on 20-11-2007
        //drCltPer["ProofPhotoDoc"] = btnAML.Value_ProofPhoto.Trim();
        drCltPer["ProofPhotoDoc"] = "";
        //End of Comment and additiom
        dtCltPer.Rows.Add(drCltPer);

        // *********************************** Update DataSet ***********************************
        dsClt.Tables.Add(dtClt.Copy());
        dsClt.Tables.Add(dtCltCnct.Copy());
        dsClt.Tables.Add(dtCltCorp.Copy());
        dsClt.Tables.Add(dtCltPer.Copy());

        return dsClt;
    }
    //private DataRow SaveCnct(DataRow drCltCnct, Application_Common_CltDetailAddr cltDtlAddr)
    //{
    //    string strUserGCN = HttpContext.Current.Session["UserId"].ToString();

    //    DataRow drCltAddr = dtCltCnct.NewRow();
    //    drCltAddr["GCN"] = this.txtGCN.Text.Trim();
    //    drCltAddr["CnctType"] = cltDtlAddr.ID.Substring(cltDtlAddr.ID.Length - 2, 2);
    //    drCltAddr["Adr1"] = cltDtlAddr.Addr1Text.Trim();
    //    drCltAddr["Adr2"] = cltDtlAddr.Addr2Text.Trim();
    //    drCltAddr["Adr3"] = cltDtlAddr.Addr3Text.Trim();
    //    drCltAddr["Adr4"] = cltDtlAddr.Addr4Text.Trim();
    //    drCltAddr["City"] = cltDtlAddr.City.Trim();
    //    drCltAddr["Postcode"] = cltDtlAddr.Pin.Trim();
    //    drCltAddr["Statecode"] = cltDtlAddr.StateCode.Trim();
    //    drCltAddr["Cntrycode"] = cltDtlAddr.Country.Trim();
    //    drCltAddr["CreateBy"] = strUserGCN.Trim();

    //    return drCltAddr;
    //}

    protected void cmdYes_Click(object sender, EventArgs e)
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        dsClt = new DataSet();
        dsClt = CltDataSet();
        MPEComfirm.Hide();
        MPEComfirmM.Hide();

        intStatusCode = oMQCltMgr.SaveClient(1, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
        txtGCN.Text = strGCN;
        Session["GCN"] = strGCN;

        if (strErrMsg.Length > 0)
        {
            lblError1.Text = "Please Contact System Administrator.";
            lblError2.Text = strErrMsg.ToString();
            lblError2.Visible = true;
            lblError3.Text = "";
            lblError3.Visible = false;
            ErrMsg_SetFocus();
            MPEError.Show();
        }
        else
        {
            lblError1.Text = "Message";
            lblError2.Text = "Client created successfully!";
            lblError1.Text = "Message";
            lblError2.Text = "";
            lblError2.Visible = false;
            lblError3.Visible = true;
            lblError3.Text = "Client updated successfully!";
            ErrMsg_SetFocus();
            MPEError.Show();
            subRenderPage();
        }
    }
    protected void cmdNo_Click(object sender, EventArgs e)
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        MPEComfirm.Hide();
        MPEComfirmM.Hide();
        dsClt = new DataSet();
        dsClt = CltDataSet();

        intStatusCode = oMQCltMgr.SaveClient(2, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
        txtGCN.Text = strGCN;
        Session["GCN"] = strGCN;

        if (strErrMsg.Length > 0)
        {
            lblError1.Text = "Please Contact System Administrator.";
            lblError2.Text = strErrMsg.ToString();
            lblError2.Visible = true;
            lblError3.Text = "";
            lblError3.Visible = false;
            ErrMsg_ReSetFocus();
            MPEError.Show();
        }
        else
        {
            lblError1.Text = "Message";
            lblError2.Text = "";
            lblError2.Visible = false;
            lblError3.Visible = true;
            lblError3.Text = "Client updated successfully!";
            ErrMsg_ReSetFocus();
            MPEError.Show();
        }
    }
    protected void cmdOk_ClsMsg(object sender, EventArgs e)
    {
        MPEError.Hide();

        this.UpdPanelCnctType.Visible = true;
        this.UpdPanelddlDstbnMethod.Visible = true;
        this.UpdPanelddlPrivacy.Visible = true;

        txtGCN.Text = Session["GCN"].ToString();
        if (txtGCN.Text != string.Empty)
            Response.Redirect("CorpClt.aspx?ENQ=" + strEnq + "&GCN=" + txtGCN.Text + "&FLAGFIND=" + txtFlagFind.Text);

    }
}
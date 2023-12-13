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
using INSCL.DAL;
using System.Xml;
using System.Data.SqlClient;
using DataAccessClassDAL;


public partial class Application_Common_CorpCltView : BaseClass
{
	//cahnged by nitin
	DataAccessClass objDAL = new DataAccessClass();

	string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
	string ErrMsg, AuditType;
	protected CommonFunc oCommon = new CommonFunc();
	DataSet dsClt = new DataSet();
	DataTable dtClt = new DataTable("Clt");
	DataTable dtCltCnct = new DataTable("CltCnct");
	DataTable dtCltCorp = new DataTable("CltCorp");
	DataTable dtCltPer = new DataTable("CltPer");
	SqlDataReader dtRead;
	const string cSessionQryState = "ClientDetail";
	protected string strEnq = string.Empty;
	protected string strGCNA = string.Empty;
	protected string strCnctType = string.Empty;
	protected string strFlagFind = string.Empty;
	public string strInit = String.Empty;
	string strXML = "";
	XmlDocument doc = new XmlDocument();
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
		if (HttpContext.Current.Session["SessionId"] == null)
		{
			Response.Redirect("~/ErrorSession.aspx");
		}
		if (Request.QueryString.Count > 0)
		{
			strEnq = Request.QueryString["ENQ"].ToString();
			strGCNA = Request.QueryString["GCN"].ToString();
			strFlagFind = Request.QueryString["FLAGFIND"].ToString();
			//btnSave.Enabled = false;
		}
		if (!Page.IsPostBack)
		{
			//CltAddrB1.ChangeHeader("Business Address (1)");
			lblABHeadear.Text = "Business Address (1)";
			lblHeader.Text = Convert.ToString("Corporate Client - View");
			if (strGCNA.Length > 0)
			{
				string strGCN = string.Empty;
				strGCN = strGCNA.ToString();
				string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
				
				RetrieveClt(strGCN, strCarrierCode);
				RetrieveCltCnct(strGCN, strCarrierCode);
				RetrieveCltCorp(strGCN);
			//	RetrieveCltPer(strGCN);

				
			}
		}
	}

	private void RetrieveClt(string strGCN, string strCarrierCode)
	{
		//ClearEntry();
		txtFlagFind.Text = strFlagFind.ToString();

		Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
		dtClt = oMQCltMgr.GetClt(strGCN, strCarrierCode);

		if (dtClt.Rows.Count > 0)
		{
			HttpContext.Current.Session["GCN"] = dtClt.Rows[0]["GCN"].ToString();

			this.lblCustomerID.Text = dtClt.Rows[0]["GCN"].ToString();
			this.lblClientCode.Text = dtClt.Rows[0]["ClientCode"].ToString();
			this.lblCompanyName.Text = dtClt.Rows[0]["Surname"].ToString();
			this.lblDateIncorpo.Text = oCommon.fncFormatDate(dtClt.Rows[0]["BirthRegDate"].ToString(), "dd/MM/yyyy");
			this.lblCompRegNo.Text = dtClt.Rows[0]["AltId"].ToString();
			this.lblCountryCode.Text = dtClt.Rows[0]["ResCntryCode"].ToString();
			this.lblCountryDesc.Text = dtClt.Rows[0]["ResCntryCodeDesc"].ToString();
			if (dtClt.Rows[0]["DefCnctType"].ToString() == "B1")
			{
				this.lblCorrAddress.Text = "Business 1";
			}
			//this.lblCorrAddress.Text = dtClt.Rows[0]["DefCnctType"].ToString();
			this.lblAltWorkTel.Text = dtClt.Rows[0]["HomeTel"].ToString();
			this.lblWorkFax.Text = dtClt.Rows[0]["MobileTel"].ToString();
			this.lblWorkTel.Text = dtClt.Rows[0]["WorkTel"].ToString();
			this.lblEmail.Text = dtClt.Rows[0]["Email"].ToString();
			//this.lblPriv.Text = dtClt.Rows[0]["PrivacyStat"].ToString();

			//changed by nitin
            //Added By Ibrahim On 17-07-2013 to get param description value start
            Hashtable htable = new Hashtable();
            htable.Clear();
            htable.Add("@ParamValue", dtClt.Rows[0]["PrivacyStat"].ToString());
            htable.Add("@flag",9);
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
            //Added By Ibrahim On 17-07-2013 to get param description value End
			//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='PrvcStat' AND ParamValue='" + dtClt.Rows[0]["PrivacyStat"].ToString() + "' ");
			if (dtRead.Read())
			{
				lblPriv.Text = dtRead[0].ToString();
			}
			dtRead = null;
			//chnaged by nitin
            //Hashtable htable = new Hashtable();
            //Added By Ibrahim On 17-07-2013 to get param description value start
            htable.Clear();
            htable.Add("@ParamValue",dtClt.Rows[0]["DstbnMethod"].ToString());
            htable.Add("@flag", 10);
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
            //Added By Ibrahim On 17-07-2013 to get param description value End 
			//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='DstbnMtd' AND ParamValue='" + dtClt.Rows[0]["DstbnMethod"].ToString() + "' ");
			if (dtRead.Read())
			{
				lblContPref.Text = dtRead[0].ToString();
			}
			dtRead = null;
			//this.lblContPref.Text = dtClt.Rows[0]["DstbnMethod"].ToString();
			this.lblWebSite.Text = dtClt.Rows[0]["WebsiteUrl"].ToString();
			this.lblIncorpoin.Text = dtClt.Rows[0]["BirthRegPlace"].ToString();
			if (dtClt.Rows[0]["PrfStat"].ToString() == "90")
			{
				lblPrefClint.Text = "Y";
			}
			else
			{
				lblPrefClint.Text = "N";
			}
			//changed by nitin
            //Added By Ibrahim On 17-07-2013 to get param description value start
            htable.Clear();
            htable.Add("@ParamValue", dtClt.Rows[0]["SpecInd" + Session["CarrierCode"].ToString()].ToString());
            htable.Add("@flag", 11);
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
            //Added By Ibrahim On 17-07-2013 to get param description value End 
			//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='LFSpecInd' AND ParamValue='" + dtClt.Rows[0]["SpecInd" + Session["CarrierCode"].ToString()].ToString() + "' ");
			if (dtRead.Read())
			{
				lblSpecialInd.Text = dtRead[0].ToString();
			}
			dtRead = null;
			//changed by nitin
            //Added By Ibrahim On 17-07-2013 to get param description value start
            htable.Clear();
            htable.Add("@ParamValue", dtClt.Rows[0]["Econ"].ToString());
            htable.Add("@flag", 12);
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
            //Added By Ibrahim On 17-07-2013 to get param description value End 
			//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='Econ' AND ParamValue='" + dtClt.Rows[0]["Econ"].ToString() + "' ");
			if (dtRead.Read())
			{
				lblEcoActivity.Text = dtRead[0].ToString();
			}
			dtRead = null;
			//changed by nitin
            //Added By Ibrahim On 17-07-2013 to get param description value start
            htable.Clear();
            htable.Add("@ParamValue", dtClt.Rows[0]["Category" + Session["CarrierCode"].ToString()].ToString());
            htable.Add("@flag", 13);
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
            //Added By Ibrahim On 17-07-2013 to get param description value End 
			//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='LFCategory' AND ParamValue='" + dtClt.Rows[0]["Category" + Session["CarrierCode"].ToString()].ToString() + "' ");
			if (dtRead.Read())
			{
				lblCateg.Text = dtRead[0].ToString();
			}
			dtRead = null;
			
			//lblSpecialInd.Text = dtClt.Rows[0]["SpecInd" + Session["CarrierCode"].ToString()].ToString();
			//lblEcoActivity.Text = dtClt.Rows[0]["Econ"].ToString();
			lblPanNo.Text = dtClt.Rows[0]["CurrentId"].ToString();
			//lblCateg.Text = dtClt.Rows[0]["Category" + Session["CarrierCode"].ToString()].ToString();
			if (dtClt.Rows[0]["TaxStat"].ToString() != string.Empty)
				if (dtClt.Rows[0]["TaxStat"].ToString() == "T")
					this.lblServiceTax.Text = "Y";
		}

		dtClt.Clear();
		dtClt = oMQCltMgr.GetCltCorp(strGCN);
		if (dtClt.Rows.Count > 0)
		{
			//Commented & Added By Saurabh Nayar On 20071127
			//this.txtCapital.Text = double.Parse(dtClt.Rows[0]["FinYrDayMn"].ToString()).ToString("f");
			this.lblCapt.Text = dtClt.Rows[0]["FinYrDayMn"].ToString();
			//End Of Addition By Saurabh Nayar On 20071127
			this.lblAnualTurn.Text = double.Parse(dtClt.Rows[0]["AnnTurnover"].ToString()).ToString("f");
			this.lblStaffSize.Text = int.Parse(dtClt.Rows[0]["StaffSize"].ToString()).ToString();
		}
	}
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
		lblContPer.Text = drCltCnct["AdrAtnTo"].ToString().Trim();
	}

	private void SetCltCnct(DataRow drCltCnct)
	{
		this.lblAddres1.Text = drCltCnct["Adr1"].ToString().Trim();
		this.lblAddres2.Text = drCltCnct["Adr2"].ToString().Trim();
		this.lblAddres3.Text = drCltCnct["Adr3"].ToString().Trim();
		this.lblAddres4.Text = drCltCnct["Adr4"].ToString().Trim();
		//Commented By Saurabh Nayar On 20071123
		//this.txtCity.Text = drCltCnct["City"].ToString().Trim();
		this.lblPinCod.Text = drCltCnct["PostCode"].ToString().Trim();
		this.lblStateCode.Text = drCltCnct["StateCode"].ToString().Trim();
		//popupCltAddr.StateDesc = drCltCnct["StateCodeDesc"].ToString();
		this.lblCountryCode.Text = drCltCnct["CntryCode"].ToString().Trim();
		//popupCltAddr.CountryDesc = drCltCnct["CntryCodeDesc"].ToString();
		lblContPer.Text = drCltCnct["AdrAtnTo"].ToString().Trim();
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
			this.lblAnualTurn.Text = double.Parse(dtCltCorp.Rows[0]["AnnTurnover"].ToString().Trim()).ToString("f");
			this.lblStaffSize.Text = int.Parse(dtCltCorp.Rows[0]["StaffSize"].ToString().Trim()).ToString();
			//Commented & Added By Saurabh Nayar On 20071127
			//this.txtCapital.Text = double.Parse(dtCltCorp.Rows[0]["FinYrDayMn"].ToString().Trim()).ToString("f");
			this.lblCapt.Text = dtCltCorp.Rows[0]["FinYrDayMn"].ToString().Trim();
			//End Of Addition By Saurabh Nayar On 20071127
			dtCltCorp.TableName = "CltCorp";
			//            HttpContext.Current.Session["dtCltCorp"] = dtCltCorp;
			//PopupAML1.dtCltCorp1 = dtCltCorp;
		}
	}


	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("CltEnquiryView.aspx");
	}
}

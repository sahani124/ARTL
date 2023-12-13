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
using System.IO;
using MQSMQMgr;
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using System.Xml;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
	public partial class Application_Common_CltViewInfo : BaseClass
	{
		//changed by nitin
        DataAccessClass objDAL = new DataAccessClass();

		string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
		private Provider oDP = new Insc.Common.Data.Provider();
		
		DataSet dsClt = new DataSet();
		DataTable dtClt = new DataTable("Clt");
		DataTable dtCltCnct = new DataTable("CltCnct");
		DataTable dtCltPer = new DataTable("CltPer");
		Hashtable htable = new Hashtable();
		Hashtable htParam = new Hashtable();
		DataSet dsResult = new DataSet();
		SqlDataReader dtRead;
		const string cSessionQryState = "ClientDetail";
		protected CommonFunc oCommon = new CommonFunc();
		protected string strEnq = string.Empty;
		protected string strGCNA = string.Empty;
		protected string strCnctType = string.Empty;
		protected string strFlagFind = string.Empty;
        private string strUserLang;
        private const string Conn_Direct = "DefaultConn";
        private multilingualManager olng;

		Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

		string strCarrierCode = string.Empty;
		string strUserGCN = string.Empty;
		string strCltType = "A";
		string strSrc = "1";
		string strErrMsg = string.Empty;
		string strStatusMsg = string.Empty;
		string strGCN = string.Empty;
		
		
		private const string c_strLogPath = "/Log";
		private const string c_strBlank = "-- Select --";
        EncodeDecode ObjDec = new EncodeDecode();

		#region PAGE LOAD
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
			{
				Response.Redirect("~/ErrorSession.aspx");
			}
            olng = new multilingualManager("DefaultConn", "CltViewInfo.aspx", Session["UserLangNum"].ToString());
			if (!IsPostBack)
			{		
                InitializeControl();
				lblIncepDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");			
			}			
			
			if (HttpContext.Current.Session["SessionId"] == null)
			{
				Response.Redirect("~/ErrorSession.aspx");
			}
			
			this.lblAPHeadear.Text = "Residential Address ( 1 )";
			this.lblABHeadear.Text = "Business Address ( 1 )";

			lblHeader.Text = Convert.ToString("Personal Client - New");			
			this.btnCancel.Visible = true;
			
			if (Request.QueryString["ENQ"] != null)
			{
				strEnq = Request.QueryString["ENQ"].ToString();
			}
			if (Request.QueryString["GCN"] != null)
			{
				strGCNA = Request.QueryString["GCN"].ToString();
			}
			if (Request.QueryString["FLAGFIND"] != null)
			{
				strFlagFind = Request.QueryString["FLAGFIND"].ToString();
			}
			
			
			if (!Page.IsPostBack)
			{
				// ************************ Define buttons and textbox properties ************************
				this.Session.Remove("dtCltCnct");
				ViewState["GCN"] = String.Empty;

				string strCurrentIdNo = string.Empty;
				string strCurrentIdType = string.Empty;

				if (strGCNA.Length > 0)
				{					
					string strGCN = string.Empty;
					strGCN = strGCNA.ToString();
					
					RetrieveClt(strGCN, strCarrierCode);
					RetrieveCltCnct(strGCN, strCarrierCode);
					//RetrieveCltPer(strGCN);

					lblHeader.Text = Convert.ToString("Personal Client - View");
				}				

				string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup(); //HttpContext.Current.Session["UserGroupCode"].ToString();

			}
			
			//if (!Page.IsPostBack)
			//{
			//    if (strGCNA.Length > 0)
			//    {
					
			//        string strGCN = string.Empty;
			//        strGCN = strGCNA.ToString();

					
			//        RetrieveClt(strGCN, strCarrierCode);
			//        //RetrieveCltCnct(strGCN, strCarrierCode);
			//        //RetrieveCltPer(strGCN);

			//        lblHeader.Text = Convert.ToString("Personal Client - View");
			//    }				
			
			//}
			
			
		}
		#endregion

        #region InitializeControl Method
        private void InitializeControl()
        {
            lblHeader.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeader"));
            lblCusID.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCusID"));
            lblCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCode"));
            lblName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblName"));
            lblSurName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSurName"));
            //lblChannel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblChannel"));
            lbldob.Text = ObjDec.GetDecData(olng.GetItemDesc("lbldob"));
            lblFname.Text = ObjDec.GetDecData(olng.GetItemDesc("lblFname"));
            lblPAN.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPAN"));
            lblGender.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGender"));
            lblspIndicator.Text = ObjDec.GetDecData(olng.GetItemDesc("lblspIndicator"));
            lblAltIDType.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAltIDType "));
            lblMstatus.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMstatus"));
            lblAltIDNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAltIDNo"));
            lblSOE.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSOE"));
            lblNationality.Text = ObjDec.GetDecData(olng.GetItemDesc("lblNationality"));
            lblCategory.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCategory"));
            lblHigestQul.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHigestQul"));
            lblCorrAdd.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCorrAdd"));
            lblInceptiondate.Text = ObjDec.GetDecData(olng.GetItemDesc("lblInceptiondate"));
            lblAPHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAPHeadear"));
            lblAddrP1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddrP1"));
            lblStateP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateP"));
            //Label2.Text = ObjDec.GetDecData(olng.GetItemDesc("Label2"));
            lblPinP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPinP"));
            lblCountryP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountryP"));
            lblABHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblABHeadear"));
            lblAddrB1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddrB1"));
            lblStateB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateB"));
            //Label3.Text = ObjDec.GetDecData(olng.GetItemDesc("Label3"));
            lblPinB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPinB"));
            lblCountryB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountryB"));
            lblPA.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPA"));
            //Label4.Text = ObjDec.GetDecData(olng.GetItemDesc("Label4"));
            lblHomeTel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHomeTel"));
            lblOfficeTel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblOfficeTel"));
            lblDIdNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDIdNo"));
            lblMobileNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMobileNo"));
            lblEmail.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEmail"));
            lblDirectmail.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDirectmail"));
            lblPager.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPager"));
            lblFax.Text = ObjDec.GetDecData(olng.GetItemDesc("lblFax"));
            lblHeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeight"));
            lblWeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblWeight"));
            lblOccup.Text = ObjDec.GetDecData(olng.GetItemDesc("lblOccup"));
            lblAnnualIncome.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAnnualIncome"));
            lblPreferedClient.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPreferedClient"));
            lblStaff.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStaff"));
            lblServiceTax.Text = ObjDec.GetDecData(olng.GetItemDesc("lblServiceTax"));
            lblRemark.Text = ObjDec.GetDecData(olng.GetItemDesc("lblRemark"));
            //lblComfirmHeader.Text = ObjDec.GetDecData(olng.GetItemDesc("lblComfirmHeader"));
            //Label1.Text = ObjDec.GetDecData(olng.GetItemDesc("Label1"));
        }
        #endregion
		
		private void RetrieveClt(string strGCN, string strCarrierCode)
		{
			dtClt = oMQCltMgr.GetClt(strGCN, strCarrierCode);
			
			//CnctType(false);

			if (dtClt.Rows.Count > 0)
			{
				HttpContext.Current.Session["GCN"] = dtClt.Rows[0]["GCN"].ToString();

				this.lblGCN.Text = dtClt.Rows[0]["GCN"].ToString().Trim();
				this.lblCltCode.Text = dtClt.Rows[0]["ClientCode"].ToString().Trim();
				this.lblTitle.Text = dtClt.Rows[0]["Title"].ToString().Trim();
				this.lblGivenName.Text = dtClt.Rows[0]["GivenName"].ToString().Trim();
				//Commented & Added By Saurabh Nayar On 20071030
				//this.txtSurname.Text = dtClt.Rows[0]["Surname"].ToString().Trim();
				this.lblSrName.Text = dtClt.Rows[0]["Surname"].ToString().Trim();
				this.lblFatherName.Text = dtClt.Rows[0]["ParentName"].ToString().Trim();
				//End Of Addition By Saurabh Nayar On 20071030
				if (dtClt.Rows[0]["BirthRegDate"] != DBNull.Value)
					this.lblDOB1.Text = DateTime.Parse(dtClt.Rows[0]["BirthRegDate"].ToString()).ToString("dd/MM/yyyy");
			
				this.lblPAN1.Text = dtClt.Rows[0]["CurrentID"].ToString().Trim();
				this.lblAltIDNo.Text = dtClt.Rows[0]["AltId"].ToString().Trim();
				
				
				//if (dtClt.Rows[0]["AnniversaryDate"] != DBNull.Value)
				//    this.txtSO.Text = dtClt.Rows[0]["AnniversaryDate"].ToString();
				this.lblNationalID.Text = dtClt.Rows[0]["Nationality"].ToString().Trim();
				this.lblNationDesc.Text = dtClt.Rows[0]["NationalityDesc"].ToString().Trim();
				//Commented By Saurabh Nayar On 20071026
				//ddlCategory.SelectedValue = dtClt.Rows[0]["Category" + Session["CarrierCode"].ToString()].ToString().Trim();
				//ddlSpecInd.SelectedValue = dtClt.Rows[0]["SpecInd" + Session["CarrierCode"].ToString()].ToString().Trim();
				//End Of Comment By Saurabh Nayar On 20071026
				this.lblQualification.Text  = dtClt.Rows[0]["QualCode"].ToString().Trim();
				
				this.lblHomeTelNo.Text = dtClt.Rows[0]["HomeTel"].ToString().Trim();
				this.lblMobileNo1.Text = dtClt.Rows[0]["MobileTel"].ToString().Trim();
				this.lblOfficeTelNo.Text = dtClt.Rows[0]["WorkTel"].ToString().Trim();
				this.lblEmail1.Text = dtClt.Rows[0]["Email"].ToString().Trim();
				this.lblOccpationCode.Text = dtClt.Rows[0]["OcpnCode01"].ToString().Trim();
				this.lblOccupDesc.Text = dtClt.Rows[0]["OcpnCode01Desc"].ToString().Trim();
				this.lblPrivacy.Text = dtClt.Rows[0]["PrivacyStat"].ToString().Trim();
				this.lblCnctPrefer.Text = dtClt.Rows[0]["DstbnMethod"].ToString().Trim();
				lblPrefClient.Text = dtClt.Rows[0]["PrfStat"].ToString();
				lblSerTaxApp.Text = (dtClt.Rows[0]["TaxStat"].ToString() == "T") ? "T" : "F";
				
				lblChkPA.Text = (dtClt.Rows[0]["PermAdrInd"].ToString() == "T") ? "T" : "F";
				
				
				lblCatg.Text = Convert.ToString(dtClt.Rows[0]["Category2"]).Trim();				
				lblRemarks.Text = Convert.ToString(dtClt.Rows[0]["Remark"]).Trim();
				//this.lblGend.Text = dtClt.Rows[0]["Gender"].ToString().Trim();
				
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", dtClt.Rows[0]["Gender"].ToString().Trim());
                htable.Add("@flag",0);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
				//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='NBGender' AND ParamValue='" + dtClt.Rows[0]["Gender"].ToString().Trim() + "' ");
				if (dtRead.Read())
				{
					lblGend.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//chnagedd by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", Convert.ToString(dtClt.Rows[0]["CltCrRul"]).Trim());
                htable.Add("@flag",1);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
				//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='CltCrRul' AND ParamValue='" + Convert.ToString(dtClt.Rows[0]["CltCrRul"]).Trim() + "' ");
				if (dtRead.Read())
				{
					lblcltcreaterule.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//lblspecialindicator.Text = Convert.ToString(dtClt.Rows[0]["SpecInd2"]).Trim();
				//change by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", Convert.ToString(dtClt.Rows[0]["SpecInd2"]).Trim());
                htable.Add("@flag",2);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
     
				//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='LFSpecInd' AND ParamValue='" + Convert.ToString(dtClt.Rows[0]["SpecInd2"]).Trim() + "' ");
				if (dtRead.Read())
				{
					lblspecialindicator.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//this.lblAlterIdType.Text = dtClt.Rows[0]["AltIDType"].ToString().Trim().Trim();
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", dtClt.Rows[0]["AltIDType"].ToString().Trim().Trim());
                htable.Add("@flag",3);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
				//dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='NBSIDKey' AND ParamValue='" + dtClt.Rows[0]["AltIDType"].ToString().Trim().Trim() + "' ");
				if (dtRead.Read())
				{
					lblAlterIdType.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//this.lblMartStatus.Text = dtClt.Rows[0]["MaritalStat"].ToString();
				//changd by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", dtClt.Rows[0]["MaritalStat"].ToString());
                htable.Add("@flag",4);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
			//	dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='MarrySts' AND ParamValue='" + dtClt.Rows[0]["MaritalStat"].ToString() + "' ");
				if (dtRead.Read())
				{
					lblMartStatus.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//changed by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", Convert.ToString(dtClt.Rows[0]["SOE"]).Trim());
                htable.Add("@flag",5);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
			//	dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='SOE' AND ParamValue='" + Convert.ToString(dtClt.Rows[0]["SOE"]).Trim() + "' ");
				if (dtRead.Read())
				{
					lblSOE1.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//changed by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", Convert.ToString(dtClt.Rows[0]["Category2"]).Trim());
                htable.Add("@flag",6);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
			//	dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='NLCategory' AND ParamValue='" + Convert.ToString(dtClt.Rows[0]["Category2"]).Trim() + "' ");
				if (dtRead.Read())
				{
					lblCatg.Text = dtRead[0].ToString();
				}
				dtRead = null;
				//changed by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", dtClt.Rows[0]["QualCode"].ToString().Trim());
                htable.Add("@flag",7);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
		//		dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='NBEduQua' AND ParamValue='" + dtClt.Rows[0]["QualCode"].ToString().Trim() + "' ");
				if (dtRead.Read())
				{
					lblQualification.Text = dtRead[0].ToString();
				}
				dtRead = null;

				//changed by nitin
                //Added By Ibrahim On 17-07-2013 to get param description value start
                htable.Clear();
                htable.Add("@ParamValue", dtClt.Rows[0]["DefCnctType"].ToString());
                htable.Add("@flag",8);
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetParamDesc", htable);
                //Added By Ibrahim On 17-07-2013 to get param description value End
			//	dtRead = objDAL.exec_reader("SELECT paramdesc1 From INSCDIRECT..iSyslookupparam where lookupcode ='CnctType' AND ParamValue='" + dtClt.Rows[0]["DefCnctType"].ToString() + "' ");
				if (dtRead.Read())
				{
					lblCnctType.Text = dtRead[0].ToString();
				}
				dtRead = null;
				
			}
		}

		private void RetrieveCltCnct(string strGCN, string strCarrierCode)
		{
			dtCltCnct = oMQCltMgr.GetCltCnct(strGCN, strCarrierCode);

			for (int i = 0; i < dtCltCnct.Rows.Count; i++)
			{
				string strCnctType = dtCltCnct.Rows[i]["CnctType"].ToString();
				switch (strCnctType)
				{
					case "P1":
						//SetCltCnct(dtCltCnct.Rows[i], CltAddrP1);
						SetCltCnctP(dtCltCnct.Rows[i]);
						break;
					case "P2":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[0]);
						break;
					case "P3":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[1]);
						break;
					case "P4":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[2]);
						break;
					case "P5":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[3]);
						break;
					case "P6":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[4]);
						break;
					case "P7":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[5]);
						break;
					case "P8":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[6]);
						break;
					case "P9":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[7]);
						break;
					case "P0":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[8]);
						break;
					case "B1":
						//SetCltCnct(dtCltCnct.Rows[i], CltAddrB1);
						SetCltCnctB(dtCltCnct.Rows[i]);
						break;
					case "B2":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[0]);
						break;
					case "B3":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[1]);
						break;
					case "B4":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[2]);
						break;
					case "B5":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[3]);
						break;
					case "B6":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[4]);
						break;
					case "B7":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[5]);
						break;
					case "B8":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[6]);
						break;
					case "B9":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[7]);
						break;
					case "B0":
						SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[8]);
						break;
					case "M1":
						SetCltCnct(dtCltCnct.Rows[i]);
						break;
				}
			}
		}
		private void SetCltCnct(DataRow drCltCnct, Application_Common_ClientAddress oClientAddress)
		{
			//popupCltAddr.lblABHeadearText = GetAddHeader(drCltCnct["CnctType"].ToString());
			oClientAddress.Value_Address1 = drCltCnct["Adr1"].ToString();
			oClientAddress.Value_Address2 = drCltCnct["Adr2"].ToString();
			oClientAddress.Value_Address3 = drCltCnct["Adr3"].ToString();
			oClientAddress.Value_Address4 = drCltCnct["Adr4"].ToString();
			oClientAddress.Value_City = drCltCnct["City"].ToString();
			oClientAddress.Value_Postcode = drCltCnct["PostCode"].ToString();
			oClientAddress.Value_State = drCltCnct["StateCode"].ToString();
			oClientAddress.Value_Country = drCltCnct["CntryCode"].ToString();
			//popupCltAddr.StateDesc = drCltCnct["StateCodeDesc"].ToString();
			//popupCltAddr.CountryDesc = drCltCnct["CntryCodeDesc"].ToString();
		}

		


		private void SetCltCnctP(DataRow drCltCnct)
		{
			//cltDtlAddr.ChangeHeader(GetAddHeader(drCltCnct["CnctType"].ToString()));
			this.lblAddressP1.Text = drCltCnct["Adr1"].ToString();
			this.lblAddrP2.Text = drCltCnct["Adr2"].ToString();
			this.lblAddrP3.Text = drCltCnct["Adr3"].ToString();
			this.lblAddrP4.Text = drCltCnct["Adr4"].ToString();
			//Commented By Saurabh Nayar On 20071030
			//this.txtCityP.Text = drCltCnct["City"].ToString();
			//End Of Comment By Saurabh Nayar On 20071030
			this.lblPinCodeP1.Text = drCltCnct["PostCode"].ToString();
			this.lblStateCodeP1.Text = drCltCnct["StateCode"].ToString();
			this.lblStateDescP1.Text = drCltCnct["StateCodeDesc"].ToString();
			this.lblCountryIdP1.Text = drCltCnct["CntryCode"].ToString();
			this.lblCountryDescP1.Text = drCltCnct["CntryCodeDesc"].ToString();
			//cltDtlAddr.Visible = true;
		}

		private void SetCltCnct(DataRow drCltCnct)
		{
			this.lblAddr1.Text = drCltCnct["Adr1"].ToString();
			this.lbladdr2.Text = drCltCnct["Adr2"].ToString();
			this.lblAddr3.Text = drCltCnct["Adr3"].ToString();
			this.lblPinCode.Text = drCltCnct["PostCode"].ToString();
			this.lblStateId1.Text = drCltCnct["StateCode"].ToString();
			this.lblStateDesc1.Text = drCltCnct["StateCodeDesc"].ToString();
			this.lblCountryID.Text = drCltCnct["CntryCode"].ToString();
			this.lblCountryDesc.Text = drCltCnct["CntryCodeDesc"].ToString();
		}


		private void SetCltCnctB(DataRow drCltCnct)
		{
			//cltDtlAddr.ChangeHeader(GetAddHeader(drCltCnct["CnctType"].ToString()));
			this.lblAddressB1.Text = drCltCnct["Adr1"].ToString();
			this.lblAddrB2.Text = drCltCnct["Adr2"].ToString();
			this.lblAddrB3.Text = drCltCnct["Adr3"].ToString();
			this.lblAddrB4.Text = drCltCnct["Adr4"].ToString();
			
			this.lblPinCodeB1.Text = drCltCnct["PostCode"].ToString();
			this.lblStateCodeB1.Text = drCltCnct["StateCode"].ToString();
			this.lblStateDescB1.Text = drCltCnct["StateCodeDesc"].ToString();
			this.lblCountryIdB1.Text = drCltCnct["CntryCode"].ToString();
			this.lblCountryDescB1.Text = drCltCnct["CntryCodeDesc"].ToString();
			//cltDtlAddr.Visible = true;
		}


		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("CltEnquiryView.aspx");
		}
}



//Optimization By:		    <Usha Rathore & Ajay Yadav> 
//Optimization date:      <04th Oct 2021>
//Description:	    <This page is created for Search unit Rank Setup.(Code Optimization)>

#region Namespaces
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
#endregion

namespace INSCL
{
    public partial class UnitRank : Base
    {
        #region Declarations
        string ErrMsg;
        string AuditType, strXML = "";
        SqlDataReader dtRead;
        XmlDocument doc = new XmlDocument();
        CommonFunc oCommon = new CommonFunc();
        private multilingualManager olng;
        string strUntRnk;
        string slsChannel;
        DataSet dsResult = new DataSet();
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;
        private string strUserLang;
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        ErrLog objErr = new ErrLog();
        Hashtable htable = new Hashtable();
        string Flag;
        #endregion

        #region PAGELOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FunCheckSession();
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "UnitRank.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                if (!IsPostBack)
                {
                    EnableDisableButton();
                    InitializeControl();
                    fillFinyr();
                    //txtEff.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    EnableDisable();
                    LoadData();
                    hdnBizsrc.Value = Request.QueryString["BizSrc"];
                    lblUnitRank.Text = Request.QueryString["untRnk"];
                    lblSalesChannel.Text = Request.QueryString["SalesChannel"];
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "Page_Load", ex);
            }
        }
        #endregion

        #region Based on add or edit visiblity
        private void EnableDisable()
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString() == "N")
                    {
                        divModification.Visible = false;
                        btnshowHist.Visible = false;
                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        txtVer.Text = "1.00";
                        txtVer.Enabled = false;
                        txtUnitRank.Visible = true;
                        ddlSalesChannel.Visible = true;
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        if (Request.QueryString["slsChn"] == "All")
                        {
                       
                            ddlSalesChannel.Items.Insert(0, new ListItem("Select", ""));
                            //ddlSalesChannel.SelectedValue = Request.QueryString["slsChn"].ToString().Trim();
                        }
                        else
                        {
                            ddlSalesChannel.Items.Insert(0, new ListItem("Select", ""));
                            ddlSalesChannel.SelectedValue = Request.QueryString["slsChn"].ToString().Trim();
                        }
                    }
                    else
                    {
                        btnSave.Visible = false;
                        lblUnitRank.Visible = true;
                        lblSalesChannel.Visible = true;
                        rfvBizSrc.Visible = false;
                        rfvUnitRank.Visible = false;
                        ControlEnableddesable();
                    }
                }
                else
                {
                    lblUnitRank.Visible = true;
                    txtUnitRank.Visible = false;
                    lblSalesChannel.Visible = true;
                    ddlSalesChannel.Visible = false;
                    rfvBizSrc.Visible = false;
                    rfvUnitRank.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region EnableDisableButton
        private void EnableDisableButton()
        {
            try
            {
                dsResult = null;
                strDesc01 = "Enable Modification of Channel Maintenance";
                strModule = "CHMS";
                dsResult = objCommonU.GetConfigSettings(strDesc01, strModule);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    strValue = dsResult.Tables[0].Rows[0]["Value"].ToString().Trim();
                }
                if (strValue == "YES")
                {
                    btnUpdate.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region InitializeControl Assiging label value from data based
        private void InitializeControl()
        {
            try
            {
                lblChannel.Text = (olng.GetItemDesc("lblChannel.Text"));
                lblRank.Text = (olng.GetItemDesc("lblRank.Text"));
                lblDesc1.Text = (olng.GetItemDesc("lblDesc1.Text"));
                lblDesc2.Text = (olng.GetItemDesc("lblDesc2.Text"));
                lblDesc3.Text = (olng.GetItemDesc("lblDesc3.Text"));
                lblHdrDesc01.Text = (olng.GetItemDesc("lblHdrDesc01.Text"));
                lblAllowSales.Text = (olng.GetItemDesc("lblAllowSales.Text"));
                lblAllowServices.Text = (olng.GetItemDesc("lblAllowServices.Text"));
                lblChannelUnitRank.Text = (olng.GetItemDesc("lblChannelUnitRank"));
                lblPer.Text = (olng.GetItemDesc("lblPeriod"));
                lblVer.Text = (olng.GetItemDesc("lblVersion"));
                lblEff.Text = (olng.GetItemDesc("lblEff"));
                lblCsedt.Text = (olng.GetItemDesc("lblCease"));
                lblODtls.Text = (olng.GetItemDesc("lblhdrOth"));
                Label21.Text = "CORRECTION OR CHANGES IN UNIT RANK SETUP";
                lblChannelUnitRank.Text = "UNIT RANK SETUP";
                lblODtls.Text = "OTHER DETAILS";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "InitializeControl", ex);
            }
        }
        #endregion

        #region Based  On Carrier Code And Bizsrc The Edit Mode Data Will Be Show In This Function.
        private void LoadData()
        {
            if (Request.QueryString["untRnk"] != null)
            {
                try
                {
                    clsUnitRankSu objUnitRank = new clsUnitRankSu();
                    dtRead = objUnitRank.getUnitRankData(Session["CarrierCode"].ToString(), Request.QueryString["BizSrc"].ToString().Trim(), Convert.ToDecimal(Request.QueryString["untRnk"]));
                    if (dtRead.Read())
                    {
                        txtDesc1.Text = dtRead[3].ToString();
                        txtDesc2.Text = dtRead[4].ToString();
                        txtDesc3.Text = dtRead[5].ToString();
                        txtRnkHdrDesc1.Text = dtRead[6].ToString();
                        txtRnkHdrDesc2.Text = dtRead[7].ToString();
                        txtRnkHdrDesc3.Text = dtRead[8].ToString();
                        txtPer.Text = dtRead[9].ToString();
                        txtVer.Text = dtRead[10].ToString();
                       
                        txtEff.Text = dtRead[11].ToString();
                        txtCseDt.Text = dtRead[12].ToString();
                    }
                    dtRead.Close();
                }
                catch (Exception ex)
                {
                    LogException("ISYS-CHMS", "UnitRank.aspx", "LoadData", ex);
                }
            }
        }
        #endregion

        #region Button 'btnCancel' Click Event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SearchUnitRank.aspx");
                //if (Request.QueryString["slsChn"] != null)
                //{
                //    Response.Redirect("SearchUnitRank.aspx?Code=" + Request.QueryString["slsChn"].ToString() + "");//?Code=" + Request.QueryString["Cancel"].ToString() + "");
                //}
                //else
                //{
                //    Response.Redirect("SearchUnitRank.aspx?flag=" + Request.QueryString["BizSrc"].ToString() + "");
                //}
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "btnCancel_Click", ex);
            }

        }
        #endregion

        #region Function 'ClearControls' for Clearing Controls 
        private void ClearControls()
        {
            try
            {
                if (txtUnitRank.Visible == true)
                {
                    txtUnitRank.Text = "";
                }
                txtDesc1.Text = "";
                txtDesc3.Text = "";
                txtDesc2.Text = "";
                txtRnkHdrDesc1.Text = "";
                txtRnkHdrDesc2.Text = "";
                txtRnkHdrDesc3.Text = "";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "ClearControls", ex);
            }
        }
        #endregion

        #region Button 'btnUpdate' Click Event
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAndUpdateValues(htable);
                InsertData("PRC_UPT_CHNUNTRNKSU", htable, "INSCCommonConnectionString");
                htable.Clear();
                btnUpdate.Enabled = false;
                if (Request.QueryString["BizSrc"] != null)
                {
                    lbl_popup.Text = "Unit Rank is Updated Successfully<br/><br/>" + "Sales channel: " + lblSalesChannel.Text.Trim() + "<br/><br/>Unit Rank: " + lblUnitRank.Text.Trim() + "<br/><br/>Description: " + txtDesc1.Text;
                    RBHIDE();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "btnUpdate_Click", ex);
            }
        }
        #endregion

        #region Button 'btnSave_Click' Click Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    Flag = Request.QueryString["flag"].ToString();
                }
                else
                {
                    Flag = "Y";
                }
                InsertAndUpdateValues(htable);
                if (Flag == "N")
                {
                    InsertData("PRC_INS_CHNUNTRNKSU ", htable, "INSCCommonConnectionString");
                    htable.Clear();
                    btnSave.Enabled = false;
                }
                if (Request.QueryString["BizSrc"] == null)
                {
                    lbl_popup.Text = "Unit Rank is Added Successfully<br/><br/>" + "Sales channel: " + ddlSalesChannel.SelectedValue + "<br/><br/>Unit Rank: " + txtUnitRank.Text.Trim() + "<br/><br/>Description: " + txtDesc1.Text;
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "ClearControls", ex);
            }
        }
        #endregion

        #region Correction Or Changes Event
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ControlEnableddesable();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "rbCorrection_OnSelectedIndexChanged", ex);
            }
        }
        #endregion

        #region Enable Or Disable Functionality Based On Chage Or Correction Event.
        private void ControlEnableddesable()
        {
            try
            {
                if (rbCorrection.SelectedValue == "CR")
                {
                    txtDesc1.Enabled = true;
                    txtDesc2.Enabled = true;
                    txtDesc3.Enabled = true;
                    txtVer.Enabled = false;
                    txtCseDt.Enabled = false;
                    lblChannel.Enabled = false;
                    lblUnitRank.Enabled = false;
                    txtRnkHdrDesc1.Enabled = true;
                    txtRnkHdrDesc2.Enabled = true;
                    txtRnkHdrDesc3.Enabled = true;
                    ddlFinancialYr.Enabled = false;
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " Chk(2);", true);
                }
                else
                {
                    lblUnitRank.Enabled = true;
                    txtDesc1.Enabled = false;
                    txtDesc2.Enabled = false;
                    txtDesc3.Enabled = false;
                    txtVer.Enabled = true;
                    txtCseDt.Enabled = true;
                    lblChannel.Enabled = true;
                    txtRnkHdrDesc1.Enabled = false;
                    txtRnkHdrDesc2.Enabled = false;
                    txtRnkHdrDesc3.Enabled = false;
                    txtEff.Enabled = true;
                    txtCseDt.Enabled = true;
                    ddlFinancialYr.Enabled = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " Chk(0);", true);
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "ControlEnableddesable", ex);
            }

        }
        #endregion

        #region Filling  the Period (financial year) dropdown based on master business year setup.
        protected void fillFinyr()
        {
            try
            {
                htable.Clear();
                htable.Add("@flag", "N");
                FillDropDown(ddlFinancialYr, "Prc_get_Current_FinYear", htable, "INSCCommonConnectionString", "", "ParamDesc", "ParamValue");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "fillFinyr", ex);
            }
        }
        #endregion

        protected void btOK_Click(object sender, EventArgs e)
        {

        }

        #region Initializes And Adds Values In Hashtable Object Inorder To Insert Or Update The Recods In The Database.
        private void InsertAndUpdateValues(Hashtable htable)
        {
            try
            {
                if (txtVer.Text.Trim() == "")
                {
                    txtVer.Text = "1.00";
                }
                if (ddlSalesChannel.Visible == true)
                {
                    slsChannel = ddlSalesChannel.SelectedValue.ToString();
                }
                else
                {
                    slsChannel = Request.QueryString["BizSrc"].ToString().Trim();
                }
                if (this.txtUnitRank.Visible == true)
                {
                    strUntRnk = txtUnitRank.Text;
                }
                else
                {
                    strUntRnk = lblUnitRank.Text;
                }
                htable.Add("@carrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", slsChannel);
                htable.Add("@UnitRank", Convert.ToDecimal(strUntRnk));
                htable.Add("@UnitRankDesc01", txtDesc1.Text);
                htable.Add("@UnitRankDesc02", txtDesc2.Text);
                htable.Add("@UnitRankDesc03", txtDesc3.Text);
                htable.Add("@UnitRankHdr01", txtRnkHdrDesc1.Text);
                htable.Add("@UnitRankHdr02", txtRnkHdrDesc2.Text);
                htable.Add("@untRnkHdrDesc3", txtRnkHdrDesc3.Text);
                htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                htable.Add("@flgNewEdit", Convert.ToString(Request.QueryString["flag"]));
                htable.Add("@Period", ddlFinancialYr.SelectedValue.Trim());
                htable.Add("@Version", txtVer.Text.Trim());
                htable.Add("@ModMode", rbCorrection.SelectedValue.Trim());
                htable.Add("@Status", ddllStatus.SelectedValue.Trim());
                FillTextboxDatetm(htable, "@EffDate", txtEff.Text.Trim().ToString());
                FillTextboxDatetm(htable, "@CeaseDate", txtCseDt.Text.Trim().ToString());
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "InsertAndUpdateValues", ex);
            }


        }
        #endregion

        #region txtUnitRank Event
        protected void txtUnitRank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateInsertionData();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "txtUnitRank_TextChanged", ex);
            }
        }
        #endregion

        #region Validation Before Data Insertion For Records If Already Exists. 
        public void ValidateInsertionData()
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " function();", true);
                DataSet dsreturn = new DataSet();
                htable.Add("@UnitRank", this.txtUnitRank.Text.Trim());
                htable.Add("@BizSrc", this.ddlSalesChannel.SelectedValue.ToString()); //added by sanoj sahani 09/12/2021
                dsreturn = ValidationIfDataAlreadyExists("PRC_RECORDEXIT_CHNUNTRNKSU", htable, "INSCCommonConnectionString");
                if (dsreturn.Tables.Count != 0)
                {
                    string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                    if (comnm == "Unit rank already exists")
                    {
                        txtUnitRank.Text = "";
                        txtUnitRank.Focus();

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "ValidateInsertionData", ex);
            }
        }
        #endregion

        #region after update rb hide
        public void RBHIDE()
        {
            try
            {
                if (rbCorrection.SelectedValue == "CH")
                {
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
                if (rbCorrection.SelectedValue == "CR")
                {
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitRank.aspx", "RBHIDE", ex);
            }
        }
        #endregion
    }
}
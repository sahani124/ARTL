using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using INSCL.DAL;
using INSCL.App_Code;
using Insc.Common.Multilingual;
using DataAccessClassDAL;

public partial class MultiBranchAssignment : BaseClass
{


    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    string AgentCode = string.Empty;
    string VendorCode = string.Empty;
    string AgentName = string.Empty;
    string AgentChannel = string.Empty;
    string AgentSubClass = string.Empty;
    string VendorName = string.Empty;
    string agnType = string.Empty;
    string strUserLang = string.Empty;
    private INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    private multilingualManager olng;
    ErrLog objErr = new ErrLog();
    #endregion
    #region Page Load Method
    protected void Page_Load(object sender, EventArgs e)
        {
        try
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "MultiBranchAssignment.aspx", strUserLang);
            if (!IsPostBack)
            {
                InitializeControl();
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                fillDropDown();
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() == "Agn")
                    {
                        AgentCode = Request.QueryString["agncd"].ToString();
                        BindAgtTextVal(AgentCode);
                    }
                    else
                    {
                        AgentCode = Request.QueryString["agncd"].ToString();
                        VendorCode = Request.QueryString["VendCode"].ToString();
                        AgentName = Request.QueryString["AgnName"].ToString();
                        AgentChannel = Request.QueryString["AgnChn"].ToString();
                        AgentSubClass = Request.QueryString["AgnChnCls"].ToString();
                        VendorName = Request.QueryString["VendName"].ToString();
                        BindTextVal(AgentCode, VendorCode, AgentName, AgentChannel, AgentSubClass, VendorName);
                        GetVendorDtl();
                        if (Request.QueryString["Primary"].ToString() == "AGENT")
                        {
                            ddlLocation.SelectedIndex = 1;
                            fillSelectedValue();
                            ddlLocation.Enabled = false;
                        }
                        else if (Request.QueryString["Primary"].ToString() == "VENDOR")
                        {
                            ddlLocation.SelectedIndex = 2;
                            fillSelectedValue();
                            ddlLocation.Enabled = false;
                        }
                    }

                }
                GetVendorDtl();
                btnPopup.Attributes.Add("onClick", "funpopup('Agent');return false;");
                btnVendorSrch.Attributes.Add("onClick", "funpopup('Vendor');return false;");
                txtLocation.Focus();
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion
    #region InitializeControl
    private void InitializeControl()
    {
        lblTitle.Text = (olng.GetItemDesc("lblTitle"));
        lblAgentTitle.Text = (olng.GetItemDesc("lblAgentTitle"));
        lblAgnCode.Text = (olng.GetItemDesc("lblAgnCode"));
        lblAgnName.Text = (olng.GetItemDesc("lblAgnName"));
        lblAgnChn.Text = (olng.GetItemDesc("lblAgnChn"));
        lblSubCls.Text = (olng.GetItemDesc("lblSubCls"));
        lblVendorDtls.Text = (olng.GetItemDesc("lblVendorDtls"));
        lblVendorcode.Text = (olng.GetItemDesc("lblVendorcode"));
        lblVendorName.Text = (olng.GetItemDesc("lblVendorName"));
        lblVenChn.Text = (olng.GetItemDesc("lblVenChn"));
        lblSubclass.Text = (olng.GetItemDesc("lblSubclass"));
        lblMapping.Text = (olng.GetItemDesc("lblMapping"));
        lblLocation.Text = (olng.GetItemDesc("lblLocation"));
        lblPrimary.Text = (olng.GetItemDesc("lblPrimary"));
        lblMapDtls.Text = (olng.GetItemDesc("lblMapDtls"));
        lblChannel.Text = (olng.GetItemDesc("lblChannel"));
        lblSubChannel.Text = (olng.GetItemDesc("lblSubChannel"));
        lblBranch.Text = (olng.GetItemDesc("lblBranch"));
        lblSalesManager.Text = (olng.GetItemDesc("lblSalesManager"));
        // btnAdd.Text = (String)(olng.GetItemDesc("btnAdd")).ToUpper();//commented by amruta for chms upgrade on 4/7/16
        btnAdd.Text = "<i class='glyphicon glyphicon-floppy-disk' style='color:White'></i> Save";
        // btnCancel.Text = (String)(olng.GetItemDesc("btnCancel")).ToUpper();
        btnCancel.Text = "<i class='glyphicon glyphicon-remove' style='color:White'></i> Cancel";
        //btnclose.Text = (String)(olng.GetItemDesc("btnclose")).ToUpper();

    }
    #endregion

    #region Bind Text Value
    protected void BindTextVal(string AgtCode, string VendCode, string agnName, string AgnChn, string agnChnCls, string VendName)
    {
        txtAgtCode.Text = AgtCode;
        txtVendoreCode.Text = VendCode;
        lblNameData.Text = agnName;
        lblAgnChnData.Text = AgnChn;
        lblAgnSubClsData.Text = agnChnCls;
        lblVenNameData.Text = VendName;
        txtAgtCode.Enabled = false;
        txtVendoreCode.Enabled = false;
        btnPopup.Enabled = false;
        btnVendorSrch.Enabled = false;
    }

    protected void BindAgtTextVal(string AgtCode)
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@AgentCode", AgtCode);
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetAgentVendorMap", htParam);

        txtAgtCode.Text = dsResult.Tables[0].Rows[0]["Agentcode"].ToString();
        txtVendoreCode.Text = dsResult.Tables[0].Rows[0]["VendorCode"].ToString();
        lblNameData.Text = dsResult.Tables[0].Rows[0]["AgentName"].ToString();
        lblAgnChnData.Text = dsResult.Tables[0].Rows[0]["AgtChnl"].ToString();
        lblAgnSubClsData.Text = dsResult.Tables[0].Rows[0]["Agtchncls"].ToString();
        lblVenNameData.Text = dsResult.Tables[0].Rows[0]["VendorName"].ToString();

        txtAgtCode.Enabled = false;
        txtVendoreCode.Enabled = false;
        btnPopup.Enabled = false;
        btnVendorSrch.Enabled = false;
    }
    protected void GetVendorDtl()
    {
        htParam.Clear();
        //htParam.Add("@VendorCode", VendorCode);
        htParam.Add("@VendorCode", txtVendoreCode.Text.Trim());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetVendorDtls", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            lblVenChnData.Text = dsResult.Tables[0].Rows[0]["ChannelDesc01"].ToString();
            lblSubclassData.Text = dsResult.Tables[0].Rows[0]["ChnClsDesc01"].ToString();
        }

    }
    #endregion

    #region Fill DropDown
    protected void fillDropDown()
    {

        objCommonU.GetSalesChannel(ddlChannel1, "", 0);
        ddlChannel1.DataBind();
        ddlChannel1.Items.Insert(0, new ListItem("Select", ""));


    }
    protected void BindddlSubChannel()
    {
        htParam.Clear();
        htParam.Add("@CarrierCode", "2");
        htParam.Add("@BizSrc", ddlChannel1.SelectedItem.Text.ToString().Trim());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_ddlchnnlsubclsforunitmaint", htParam);
        htParam.Clear();
        if (dsResult.Tables[0].Rows.Count > 0)
        {

            ddlSubChannel1.DataSource = dsResult;
            ddlSubChannel1.DataTextField = "ChnlDesc";
            ddlSubChannel1.DataValueField = "ChnCls";
            ddlSubChannel1.DataBind();
            ddlSubChannel1.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    protected void BindddlBranch()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@BizSrc", ddlChannel1.SelectedItem.Text.ToString().Trim());
        //htParam.Add("@ChnCls", ddlSubChannel1.SelectedItem.Text.ToString().Trim());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUnitDtls", htParam);
        htParam.Clear();
        if (dsResult.Tables[0].Rows.Count > 0)
        {

            ddlBranch1.DataSource = dsResult;
            ddlBranch1.DataTextField = "UnitDesc01";
            ddlBranch1.DataValueField = "UNitcode";
            ddlBranch1.DataBind();
            ddlBranch1.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    #endregion
    #region Selected Index Change Method
    protected void ddlChannel1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        BindddlSubChannel();
    }
    protected void ddlSubChannel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindddlBranch();
    }
    protected void ddlBranch1_SelectedIndexChanged(object sender, EventArgs e)
    {

        htParam.Clear();
        dsResult = null;
        htParam.Add("@BizSrc", ddlChannel1.SelectedItem.Text.ToString().Trim());
        htParam.Add("@UnitCode", ddlBranch1.SelectedValue);
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetSMDtlsForUnitCode", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {

            ddlSalesManager1.DataSource = dsResult;
            ddlSalesManager1.DataTextField = "LegalName";
            ddlSalesManager1.DataValueField = "MemCode";
            ddlSalesManager1.DataBind();

            ddlSalesManager1.Items.Insert(0, new ListItem("Select", ""));
        }
        ddlBranch1.Focus();
    }
    protected void ddlSalesManager1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSalesManager1.Focus();
    }
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblAgnChnData.Text != "" || hdnAgnBizSrc.Value != "" && lblVenChnData.Text != "" || hdnVendBizSrc.Value != "")
        {
            fillDropDown();

            fillSelectedValue();

        }
        ddlLocation.Focus();
    }

    private void fillSelectedValue()
    {
        if (ddlLocation.SelectedItem.Text == "Agent")
        {
            if (Request.QueryString.Count > 1)
            {
                ddlChannel1.SelectedItem.Text = lblAgnChnData.Text;
                BindddlSubChannel();
                // ddlSubChannel1.SelectedItem.Text = lblAgnSubClsData.Text;
            }
            else
            {
                ddlChannel1.SelectedItem.Text = hdnAgnBizSrc.Value.ToString().Trim();
                BindddlSubChannel();
                //ddlSubChannel1.SelectedItem.Text = hdnAgnChnCls.Value.ToString().Trim();
            }
            BindddlBranch();
            ddlChannel1.Enabled = false;
            //ddlSubChannel1.Enabled = false;

        }
        else if (ddlLocation.SelectedItem.Text == "Vendor")
        {
            if (Request.QueryString.Count > 1)
            {
                ddlChannel1.SelectedItem.Text = lblVenChnData.Text;
                BindddlSubChannel();
                //ddlSubChannel1.SelectedItem.Text = lblSubclassData.Text;
            }
            else
            {
                ddlChannel1.SelectedItem.Text = hdnVendBizSrc.Value.ToString().Trim();
                BindddlSubChannel();
                //ddlSubChannel1.SelectedItem.Text = hdnVendChnCls.Value.ToString().Trim();
                BindddlBranch();
                ddlChannel1.Enabled = false;
                //ddlSubChannel1.Enabled = false;
            }
            BindddlBranch();
            ddlChannel1.Enabled = false;
            //ddlSubChannel1.Enabled = false;
        }
    }
    #endregion
    #region Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
        {
        if ((lblAgnChnData.Text != "" || hdnAgnBizSrc.Value != "") && (lblVenChnData.Text != "" || hdnVendBizSrc.Value != "") && txtLocation.Text != "" && ddlLocation.SelectedValue.ToString() != "" && ddlBranch1.SelectedValue.ToString() != "" && ddlSalesManager1.SelectedValue.ToString() != "")
        {
            try
            {
                htParam.Clear();
                dsResult = null;
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@DerivedBizSrc", ddlChannel1.SelectedItem.Text.ToString().Trim());
                htParam.Add("@DerivedChnCls", ddlSubChannel1.SelectedItem.Text.ToString().Trim());
                htParam.Add("@PrmyFlg", ddlLocation.SelectedValue.ToString().Trim());
                htParam.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));
                htParam.Add("@SMCode", ddlSalesManager1.SelectedValue.ToString().Trim());
                htParam.Add("@UnitCode", ddlBranch1.SelectedValue.ToString().Trim());
                htParam.Add("@LocationName", txtLocation.Text.ToString().Trim());

                if (Request.QueryString.Count > 1)
                {
                    htParam.Add("@AgentBizsrc", lblAgnChnData.Text.ToString().Trim());
                    htParam.Add("@AgentChnCls", lblAgnSubClsData.Text.ToString().Trim());
                    htParam.Add("@AgentCode", txtAgtCode.Text.ToString().Trim());
                    htParam.Add("@RelBizSrc", lblVenChnData.Text.ToString().Trim());
                    htParam.Add("@RelChnCls", lblSubclassData.Text.ToString().Trim());
                    htParam.Add("@RelAgentCode", txtVendoreCode.Text.ToString().Trim());
                    htParam.Add("@AgentName", lblNameData.Text.ToString());
                    htParam.Add("@VendorName", lblVenNameData.Text.ToString().Trim());
                }
                else
                {
                    htParam.Add("@AgentBizsrc", hdnAgnBizSrc.Value.ToString().Trim());
                    htParam.Add("@AgentChnCls", hdnAgnChnCls.Value.ToString().Trim());
                    //htParam.Add("@AgentType", );
                    htParam.Add("@AgentCode", hdnAgtCode.Value.ToString());
                    htParam.Add("@RelBizSrc", hdnVendBizSrc.Value.ToString().Trim());
                    htParam.Add("@RelChnCls", hdnVendChnCls.Value.ToString().Trim());
                    //htParam.Add("@RelAgentType","RF" );
                    htParam.Add("@RelAgentCode", hdnVendCode.Value.ToString().Trim());
                    //htParam.Add("@RelType", ); 
                    htParam.Add("@AgentName", hdnAgentName.Value.ToString());
                    htParam.Add("@VendorName", hdnVendName.Value.ToString().Trim());
                }
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_InsDataToGenIRC", htParam);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                if (dsResult.Tables.Count > 1)
                {
                    if (dsResult.Tables[1].Rows.Count > 0)
                    {
                        string strIRCCode = dsResult.Tables[1].Rows[0]["MapCode"].ToString();
                        //mdlpopup.Show();
                        //lbl_popup.Text = "IRC has been Created successfully";
                        //lblIrcCodeMsg.Text = "IRC Code : " + strIRCCode;
                        lbl_popup.Text = "IRC has been Created successfully<br /><br />IRC Code : " + strIRCCode;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                    }
                }
                else
                {
                    string strIRCCode = dsResult.Tables[0].Rows[0]["MapCode"].ToString();
                    //mdlpopup.Show();
                    //lbl_popup.Text = "IRC has been Created successfully";
                    //lblIrcCodeMsg.Text = "IRC Code : " + strIRCCode;
                    lbl_popup.Text = "IRC has been Created successfully<br /><br />IRC Code : " + strIRCCode;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                }
                //lblMsg.Text = "IRC Code " + strIRCCode + " has been generated successfully";
                //lblMsg.Visible = true;
            }
            btnAdd.Enabled = false;
        }
        else
        {
            //mdlpopup.Hide(); //Add-Parag@09052014
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "funValidate()", true);

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        object refUrl = ViewState["RefUrl"];

        if (Request.QueryString.Count > 0)
        {
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }
        else
        {
            //Response.Redirect("~/Default3.aspx?pid=8000");
            //  Response.Redirect("AGTSearch.aspx?ID=IN&Type=I");

            Response.Redirect("~/Application/isys/ChannelMgmt/AGTSearch.aspx");
        }
    }
    #endregion
}

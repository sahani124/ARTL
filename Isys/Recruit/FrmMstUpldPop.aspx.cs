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
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;
using System.Collections.Generic;

public partial class Application_ISys_FrmMstUpldPop : BaseClass
{
    #region Declare Variable
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private multilingualManager olng;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            olng = new multilingualManager("DefaultConn", "FrmMstUpldDocs.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            PopulateNewProcessType();
            PopulateNewCandType();
            PopulateNewStatus();
            PopulateDocType();
            PopulateMandatory();
            PopulateModuleCode();
            //trIns.Visible = false;
            LblhomeNote.Visible = false;
            spnins.Visible = false;
            lblInsType.Visible = false;
            ddlInsType.Visible = false;
        }

    }

    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
           
            lblnewProcess.Text = olng.GetItemDesc("lblnewProcess");
            lblnewcand.Text = olng.GetItemDesc("lblnewcand");
            lblnewStatus.Text = olng.GetItemDesc("lblnewStatus");
            lblnewdesc.Text = olng.GetItemDesc("lblnewdesc");
            lblInsType.Text = olng.GetItemDesc("lblInsType");
            lblmandtry.Text = olng.GetItemDesc("lblmandtry");
            lblmximg.Text = olng.GetItemDesc("lblmximg");
            lblModCode.Text = olng.GetItemDesc("lblModCode");
            lblDoc.Text = olng.GetItemDesc("lblDoc");

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

    #region PopulateNewProcessType
    private void PopulateNewProcessType()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetProcessType");
        ddlnewprocess.DataSource = dsresult;
        ddlnewprocess.DataTextField = "ProcessDesc";
        ddlnewprocess.DataValueField = "ProcessType";
        ddlnewprocess.DataBind();
        ddlnewprocess.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateNewCandType
    private void PopulateNewCandType()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetMstCandType");
        ddlnewcand.DataSource = dsresult;
        ddlnewcand.DataTextField = "CandTypeDesc";
        ddlnewcand.DataValueField = "Cand_Type";
        ddlnewcand.DataBind();
        ddlnewcand.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateNewStatus
    private void PopulateNewStatus()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetStatusType");
        ddlnewStatus.DataSource = dsresult;
        ddlnewStatus.DataTextField = "StatusDesc";
        ddlnewStatus.DataValueField = "Status";
        ddlnewStatus.DataBind();
        ddlnewStatus.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateModuleCode
    private void PopulateModuleCode()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetModuleCode");
        ddlModCode.DataSource = dsresult;
        ddlModCode.DataTextField = "ModCode";
        ddlModCode.DataValueField = "ModuleCode";
        ddlModCode.DataBind();
        ddlModCode.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateInsType
    protected void PopulateInsType()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetInsType");
        ddlInsType.DataSource = dsresult;
        ddlInsType.DataTextField = "InsurerTypeDesc";
        ddlInsType.DataValueField = "InsurerType";
        ddlInsType.DataBind();
        ddlInsType.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateDocType
    protected void PopulateDocType()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetMstDocType");
        ddlDoc.DataSource = dsresult;
        ddlDoc.DataTextField = "DocDesc";
        ddlDoc.DataValueField = "TypeofDoc";
        ddlDoc.DataBind();
        ddlDoc.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateMandatory
    protected void PopulateMandatory()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetMstIsMand");
        ddlmamdtry.DataSource = dsresult;
        ddlmamdtry.DataTextField = "Mandatory";
        ddlmamdtry.DataValueField = "IsMandatory";
        ddlmamdtry.DataBind();
        ddlmamdtry.Items.Insert(0, "--Select--");
        dsresult = null;

    }
    #endregion

    #region ddlnewcand SelectedIndexChanged
    protected void ddlnewcand_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlnewprocess.SelectedValue.ToString().Trim() == "RW")
        {
            if (ddlnewcand.SelectedValue.ToString().Trim() == "C")
            {
                //trIns.Visible = true;
                LblhomeNote.Visible = true;
                spnins.Visible = true;
                lblInsType.Visible = true;
                ddlInsType.Visible = true;
                PopulateInsType();
            }
            else
            {
                //trIns.Visible = false;
                //lblInsType.Text = "";
                LblhomeNote.Visible = false;
                spnins.Visible = false;
                lblInsType.Visible = false;
                ddlInsType.Visible = false;
            }

        }
    }
    #endregion

    #region ddlnewprocess SelectedIndexChanged
    protected void ddlnewprocess_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlnewprocess.SelectedValue.ToString().Trim() == "RW")
        {
            if (ddlnewcand.SelectedValue.ToString().Trim() == "C")
            {
                //trIns.Visible = true;
                LblhomeNote.Visible = true;
                spnins.Visible = true;
                lblInsType.Visible = true;
                ddlInsType.Visible = true;
                PopulateInsType();
            }
            else
            {
                LblhomeNote.Visible = false;
                spnins.Visible = false;
                lblInsType.Visible = false;
                ddlInsType.Visible = false;
                //trIns.Visible = false;
            }

        }
        else
        {
            LblhomeNote.Visible = false;
            spnins.Visible = false;
            lblInsType.Visible = false;
            ddlInsType.Visible = false;
            //trIns.Visible = false;
        }

    }
    #endregion

    #region Button ADD
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int x;
        htParam.Clear();
        dsResult.Clear();
        if (ddlnewcand.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Process Type.')", true);
            return;
            //htParam.Add("@CandType", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@CandType", ddlnewcand.SelectedValue.ToString().Trim());
        }
        if (ddlnewprocess.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Candidate Type.')", true);
            return;
            //htParam.Add("@ProcessType", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@ProcessType", ddlnewprocess.SelectedValue.ToString().Trim());
        }
        if (txtnewdesc.Text.ToString().Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Image Description.')", true);
            return;
        }
        else
        {
            htParam.Add("@Desc", txtnewdesc.Text.ToString().Trim());
        }
        if (ddlInsType.Visible == true)
        {
            if (ddlInsType.SelectedItem.ToString().Trim() == "--Select--")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Insurer Type.')", true);
                return;
                //htParam.Add("@InsType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@InsType", ddlInsType.SelectedValue.ToString().Trim());
            }

        }
        else
        {
            htParam.Add("@InsType", System.DBNull.Value);
        }
        if (ddlmamdtry.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Mandatory.')", true);
            return;
            //htParam.Add("@Mandatory", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@Mandatory", ddlmamdtry.SelectedValue.ToString().Trim());
        }
        if (txtmximg.Text.ToString().Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Image Size')", true);
            return;
        }
        else
        {
            htParam.Add("@ImgSize", txtmximg.Text.ToString().Trim());
        }
        htParam.Add("@ImgWidth", "725");
        htParam.Add("@ImgHeight", "900");
        if (ddlnewStatus.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Status.')", true);
            return;
            //htParam.Add("@Status", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@Status", ddlnewStatus.SelectedValue.ToString().Trim());
        }
        //htParam.Add("@ModuleCode", txtModCode.Text.ToString().Trim());
        if (ddlModCode.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select ModuleCode.')", true);
            return;
        }
        else
        {
            htParam.Add("@ModuleCode", ddlModCode.SelectedValue.ToString().Trim());
        }
        if (ddlDoc.SelectedItem.ToString().Trim() == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Document Type.')", true);
            return;
            //htParam.Add("@Doc", System.DBNull.Value);
        }
        else
        {
            htParam.Add("@Doc", ddlDoc.SelectedValue.ToString().Trim());
        }
        htParam.Add("@createdby", Session["UserID"].ToString());
        hdnCrtDtim.Value = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);
        htParam.Add("@CreatedDtim", DateTime.Parse(hdnCrtDtim.Value).ToString("yyyyMMdd"));
        x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstUpldDocs", htParam);
        //lblSub.Text = "Record Added Successfully";
        mdlpopupSub.Show();
        pnlSub.Visible = true;
        
        //BindMstUpldDocs();
    }
    #endregion
}
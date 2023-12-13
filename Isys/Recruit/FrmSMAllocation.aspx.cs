using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Text;
using INSCL;
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
public partial class Application_ISys_Recruit_FrmSMAllocation : BaseClass
{
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    private multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    string strAgentType = string.Empty;
    SqlDataReader dragnt;//Added by rachana
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            olng = new multilingualManager("DefaultConn", "FrmSMAllocation.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            ddlAgnTypes.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
            viewData(Request.QueryString["CndNo"].ToString().Trim());
            GetRecruitSalesChannel(ddlSlsChannel, "", 0);
            lnkSMAllocate.Attributes.Add("onclick", "funcMgrShowPopup('" + hdnBizsrc1.Value.Trim() + "','" + hdnChnCls.Value.Trim() + "','" + hdncndbrnch.Value.Trim() + "');return false;");
        }
        txtNwRecruiterCode.Text = hdnNwRecruiterCode.Value;
        txtNwEmpCode.Text = hdnNwEmpCode.Value;
        txtNwSMName.Text = hdnNwSMName.Value;
        txtNwchannelClass.Text = hdnhierarchyname.Value;
        txtNwsubClass.Text = hdnsubclass.Value;
        txtNwagttype.Text = hdnagenttypedesc.Value;
        txtNwcndagttyp.Text = hdncndagenttypedesc.Value;
        txtNwbrnch.Text = hdnbranchdesc.Value;
    }

     private void InitializeControl()
    {
        try
        {
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblBranch.Text = olng.GetItemDesc("lblBranch");
            lblPAN.Text = olng.GetItemDesc("lblPAN");
            lblMobileNo.Text = olng.GetItemDesc("lblMobileNo");
            lblEmail.Text = olng.GetItemDesc("lblEmail");
            lblpfSMCode.Text = olng.GetItemDesc("lblpfSMCode");
            lblpfSlsChannel.Text = olng.GetItemDesc("lblpfSlsChannel");
            lblpfChnCls.Text = olng.GetItemDesc("lblpfChnCls");
            lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
            lblpfSMName.Text = olng.GetItemDesc("lblpfSMName");
            lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
            lblCndAgtType.Text = olng.GetItemDesc("lblCndAgtType");


            lbloldRecruiterCode.Text = olng.GetItemDesc("lbloldRecruiterCode");
            lbloldchannelClass.Text = olng.GetItemDesc("lbloldchannelClass");
            lbloldsubClass.Text = olng.GetItemDesc("lbloldsubClass");
            lblOldSMName.Text = olng.GetItemDesc("lblOldSMName");
            lbloldagttype.Text = olng.GetItemDesc("lbloldagttype");
            lbloldbrnch.Text = olng.GetItemDesc("lbloldbrnch");
            lbloldcndagttyp.Text = olng.GetItemDesc("lbloldcndagttyp");
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


     #region METHOD 'AgentTypes' DEFINITION
     //Added by Pranjali on 07-12-2013 to Fill the Recruiter agent type dropdown start
     private void PopulateAgentTypes()
     {
         try
         {
             ddlAgnTypes.Items.Clear();
             DSAgnTypes.SelectCommand = "Prc_GetAgentTypeforCndReg '" + ddlSlsChannel.SelectedValue + "','" + ddlChnCls.SelectedValue + "','" + strAgentType + "'";
             ddlAgnTypes.DataBind();
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
     //Added by Pranjali on 07-12-2013 to Fill the Recruiter agent type dropdown end
     #endregion

     #region METHOD 'GetSalesChannel' DEFINITION
     //Added by Pranjali on 07-12-2013 to Fill Channel dropdown start
     private void GetRecruitSalesChannel(DropDownList ddl, string strBizSrc, int strIncMasterCmp)
     {
         try
         {
             //ddlChnCls.Items.Clear();
             ddlAgntType.Items.Clear();
             string strSql = string.Empty;
             DataSet dsResult = new DataSet();
             int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
             htParam.Clear();
             htParam.Add("@CarrierCode", CarrierCode);
             dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", htParam, CONN_Recruit);
             //dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", htParam, CONN_Recruit);
             if (dsResult.Tables.Count > 0)
             {
                 oCommonUtility.FillDropDown(ddl, dsResult.Tables[0], "BizSrc", "ChannelDesc01");
                 if (strBizSrc.Trim() != "")
                 {
                     ddl.SelectedValue = strBizSrc.Trim();
                 }
             }
             dsResult = null;
             strSql = null;
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
     //Added by Pranjali on 07-12-2013 to Fill Channel dropdown end
     #endregion

     #region METHOD 'FillddlChannelClass' DEFINITION
     //Added by Pranjali on 07-12-2013 to Fill Sub Class dropdown start
     private void FillddlChannelSubClass(string sddlSlsChannel)
     {
         try
         {
             ddlAgntType.Items.Clear();
             ddlChnCls.Items.Clear();
             SqlDataReader dtRead;
             htParam.Clear();
             int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
             htParam.Add("@CarrierCode", CarrierCode);
             htParam.Add("@BizSrc", sddlSlsChannel);
             //dtRead = dataAccess.exec_reader_prc_conn("Prc_Getddlslschannel", htParam, CONN_Recruit);
             dtRead = dataAccess.exec_reader_prc_conn("Prc_Getddlslschannel", htParam, CONN_Recruit);

             //DataSet dsresult = new DataSet();
             //dsresult = dataAccess.GetDataSetForPrcRecruit("Prc_Getddlslschannel", htParam);
             //ddlChnCls.DataSource = dsresult;
             //ddlChnCls.DataTextField = "ChnlDesc";
             //ddlChnCls.DataValueField = "ChnCls";
             //ddlChnCls.DataBind();
             ////ddlChnCls.Items.Insert(0, "--Select--");
             //dsresult = null;

             if (dtRead.HasRows)
             {
                 ddlChnCls.DataSource = dtRead;
                 ddlChnCls.DataTextField = "ChnlDesc";
                 ddlChnCls.DataValueField = "ChnCls";
                 ddlChnCls.DataBind();
             }
             dtRead = null;
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
     //Added by Pranjali on 07-12-2013 to Fill Sub Class dropdown end
     #endregion

     #region fill candidate type
     private void FillCndAgntType(string strbiz, string strChn)
     {
         try
         {
             htParam.Clear();
             DataSet dsagnt = new DataSet();
             htParam.Add("@BizSrc", strbiz);
             htParam.Add("@Chncls", strChn);

             //dragnt = dataAccessRecruit.exec_reader_prc_rec("Prc_GetAgntTypeforCnd", htParam);
             dragnt = dataAccess.exec_reader_prc_rec("Prc_GetAgntTypeforCnd", htParam);
             //dsagnt = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_RecruitInfoSearch", htParam);

             dragnt.Read();
             if (dragnt.HasRows)
             {
                 //if(dsResult.Tables.Count>0)
                 //{
                 ddlCndAgtType.DataSource = dragnt;
                 ddlCndAgtType.DataTextField = "MemTypeDesc01";
                 ddlCndAgtType.DataValueField = "MemType";
                 ddlCndAgtType.DataBind();
                 //ddlCndAgtType.SelectedValue = "IS";


             }
             dragnt = null;
         }
         catch (Exception ex)
         {

             string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
             System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
             string sRet = oInfo.Name;
             System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
             String LogClassName = method.ReflectedType.Name;
             objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
         }
     }
     #endregion

    protected void viewData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@CndNo", strCndNo);
        try
        {
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_GetDtlsForSMAllocation", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                        lblCndNameValue.Text = dsResult.Tables[0].Rows[0]["Name"].ToString().Trim();
                        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString().Trim();
                        string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["Branch"]).Trim();
                        string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                        lblBranchValue.Text = branch + " " + "(" + cmsunitcode + ")";
                        lblPANValue.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                        lblMobileValue.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();
                        lblEmailValue.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                        txtpfSMCode.Text = dsResult.Tables[0].Rows[0]["RecruitAgtCode"].ToString().Trim();
                        txtEmpCode.Text = dsResult.Tables[0].Rows[0]["RecruitEmpCode"].ToString().Trim();
                        txtSMName.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString().Trim();
                        txtBranchCode.Text = branch + " " + "(" + cmsunitcode + ")";
                        hdnBizsrc1.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        hdnChnCls.Value = dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                        hdncndbrnch.Value = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim();
                        FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                        ddlCndAgtType.SelectedValue = dsResult.Tables[0].Rows[0]["CndAgtType"].ToString().Trim();
                        //ddlCndAgtType.SelectedItem.Text = dsResult.Tables[0].Rows[0]["MemTypeDesc01"].ToString().Trim();
                        GetRecruitSalesChannel(ddlSlsChannel, "", 0);
                        ddlSlsChannel.SelectedItem.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        FillddlChannelSubClass((Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()));
                        ddlChnCls.SelectedValue = dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                        strAgentType = dsResult.Tables[0].Rows[0]["AgentType"].ToString().Trim();
                        
                        //if (strAgentType == "SM" || strAgentType == "BH") //commented by pranjali on 28-03-2014 
                        //{
                        PopulateAgentTypes();
                        ddlAgnTypes.SelectedItem.Value = dsResult.Tables[0].Rows[0]["AgentType"].ToString().Trim();
                        //ddlAgnTypes.SelectedItem.Text = dsResult.Tables[0].Rows[0]["AgentTypeDesc"].ToString().Trim();
                    }
                }
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int x;
        htParam.Clear();
        //dsResult.Clear();
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        htParam.Add("@EmpCode", hdnNwEmpCode.Value);
        htParam.Add("@SmCode", hdnNwRecruiterCode.Value);
        htParam.Add("@SlsChannel",hdnslschnl.Value);
        htParam.Add("@ChnCls", hdnsubcls.Value);
        htParam.Add("@SMName", hdnNwSMName.Value);
        htParam.Add("@AgnType", hdnagenttype.Value);
        htParam.Add("@BranchCode", hdnUnitCode.Value);
        htParam.Add("@CndAgtType", hdncndagenttype.Value);
        htParam.Add("@CreatedBy", Session["UserID"].ToString());
        x = dataAccess.execute_sprcrecruit("Prc_UpdNewSMDtls", htParam);
        lbl_popup.Text = "SM Allocation done successfully.";
        mdlpopup.Show();
        btnSubmit.Enabled = false;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
}
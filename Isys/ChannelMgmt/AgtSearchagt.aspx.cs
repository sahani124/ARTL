using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;

public partial class Application_Isys_ChannelMgmt_AgtSearchagt : BaseClass
{
    #region DECLARE VARIABLES
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    private multilingualManager olng;
    private string strUserLang;
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    Hashtable httable = new Hashtable();
    ErrLog objErr = new ErrLog();
    #endregion
    #region PAGE_LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();

            olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
            Session["CarrierCode"] = '2';
            SqlDataReader dtRead;
            if (!IsPostBack)
            {
                divsrchHdr.Style.Add("display", "none");
                string UserId = Session["UserID"].ToString();
                if (!IsPostBack)
                {

                    if (Request.QueryString["Role"] != null)
                    {
                        if (Request.QueryString["Role"].ToString() == "agt")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=JavaScript>addCssClassByClick(2);</script>");
                        }
                        else if (Request.QueryString["Role"].ToString() == "vendor")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=JavaScript>addCssClassByClick(3);</script>");
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=JavaScript>addCssClassByClick(1);</script>");
                    }

                    if (Session["LanguageCode"] == null)
                    {
                        Session["LanguageCode"] = "eng";
                    }
                    InitializeControl();
                    oCommon.getDropDown(ddlAgntStatus, "agtsts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

                    if (Request["Type"] != null)
                    {
                        if (Request["Type"].ToString() == "N")
                        {
                            ViewState["vwsType"] = "N";
                        }
                        else
                        {
                            ViewState["vwsType"] = "" + "E";

                        }
                    }
                    else
                    {
                        ViewState["vwsType"] = "E";
                    }
                    //trDetails.Visible = false;
                    //trDgDetails.Visible = false;

                    ddlAgntStatus.Items.Insert(0, new ListItem("All", "All"));
                    ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
                    ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
                    txtPAN.Attributes.Add("onblur", "Javascript:return ValidationPAN();");
                    if (ViewState["vwsType"].ToString() == "N")
                    {
                        oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "");
                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                    else
                    {
                        oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, UserId.ToString(), "");
                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                    ddlSlsChnnl.Items.Insert(0, new ListItem("All", "All"));
                    oCommonU.FillNoOfRecDropDown(ddlShwRecrds);
                    // trCDAHierarchy.Visible = false;
                    CDACheck.Checked = false;
                }
                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"].ToString().ToUpper().Trim() == "IN")
                    {
                        ddlAgntStatus.SelectedValue = "IF";
                    }
                }

                lblSourceName.Visible = false;
                //Added by Rachana on 14/05/2013 for showing popup on Page_load start
                btnUnitCode.Attributes.Add("onclick", "funcShowPopup('unitcode');return false;");
                //Added by Rachana on 14/05/2013 for showing popup on Page_load end
                CDACheck.Attributes.Add("onClick", "Javascript: return CheckAgtTypeForCDA();");
                //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist start
                oCommonU.GetRptType(ddlRptTyp);
                ddlRptTyp.Items.Insert(0, new ListItem("All", "All"));
                //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist end
                //Added by swapnesh on 12/12/2013 to add functionality of tabs start
                lnkTab1.BackColor = System.Drawing.Color.LightYellow;
                lnkTab2.BackColor = System.Drawing.Color.Transparent;
                lnkTab3.BackColor = System.Drawing.Color.Transparent;
                lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
                lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                lnkTab3.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
                InitializeControl();
                /////hdnAgentRole.Value = "E";

                //Added by swapnesh on 12/12/2013 to add functionality of tabs end
            }

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "IN")
                {
                    //  trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Member Info-Edit";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "RIN")//--Change: Parag @ 20022014
                {
                    ddlAgntStatus.SelectedValue = "TR";
                    ddlAgntStatus.Enabled = false;
                    lnkTab3.Visible = false;
                    //  trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Reinstatement";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "PR")
                {
                    //  trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Promotion Request";
                    lnkTab3.Visible = false;
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                }
                ///added by akshay on 27/01/14 start
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRF")
                {
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    //lnkTab3.Enabled = false;
                    lnkTab3.Visible = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                    if (Request.QueryString["MvmtMode"] != null)
                    {
                        if (Request.QueryString["MvmtMode"].ToString().Trim() != "0")
                        {
                            lblSourceName.Visible = true;
                            lblSourceName.Text = "Member Transfer Checker Details";
                            ddlAgntStatus.SelectedValue = "PN";
                        }
                        else
                        {
                            lblSourceName.Visible = true;
                            lblSourceName.Text = "Member Transfer Maker Details";
                        }
                    }

                }
                //Added By SANDEEP GARG on 10/12/2013 START
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IRC")
                {
                    //  trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "View Agent For IRC";
                }
                //Added By SANDEEP GARG on 10/12/2013 END
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TR")
                {
                    //lnkTab3.Enabled = false;
                    lnkTab3.Visible = false;
                    ///ddlAgntStatus.SelectedIndex = 1;
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                    // lblSourceName.Text = "Member Termination Request";
                    if (Request.QueryString["MvmtMode"] != null)
                    {
                        if (Request.QueryString["MvmtMode"].ToString().Trim() != "0")
                        {
                            lblSourceName.Visible = true;
                            lblSourceName.Text = "Member Termination Checker Details";
                            ddlAgntStatus.SelectedValue = "PN";
                        }
                        else
                        {
                            lblSourceName.Visible = true;
                            lblSourceName.Text = "Member Termination Maker Details";
                        }
                    }
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "CR")
                {
                    //  trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Member Creation Checker Details";
                }
                else
                {
                    //trHead.Visible = false;
                    lblSourceName.Visible = false;
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
    #endregion
    #region InitializeControl
    private void InitializeControl()
    {
        lblAgntCode.Text = (olng.GetItemDesc("lblAgntCode.Text"));
        lblAgntName.Text = (olng.GetItemDesc("lblAgntName.Text"));
        lblIDNo.Text = (olng.GetItemDesc("lblIDNo.Text"));
        lblAgntStatus.Text = (olng.GetItemDesc("lblAgntStatus.Text"));
        lblSlsChnnl.Text = (olng.GetItemDesc("lblSlsChnnl.Text"));
        lblChnCls.Text = (olng.GetItemDesc("lblChnCls.Text"));
        lblAgntType.Text = (olng.GetItemDesc("lblAgntType.Text"));
        lblImmLeaderCode.Text = (olng.GetItemDesc("lblImmLeaderCode.Text"));
        lblUnitCode.Text = (olng.GetItemDesc("lblUnitCode.Text"));
        lblDTJoinFrom.Text = (olng.GetItemDesc("lblDTJoinFrom.Text")) + " " + "(dd/mm/yyyy)";
        lblDTJoinTo.Text = (olng.GetItemDesc("lblDTJoinTo.Text")) + " " + "(dd/mm/yyyy)";
        lblCSCCode.Text = (olng.GetItemDesc("lblCSCCode.Text"));
        lblShwRecords.Text = (olng.GetItemDesc("lblShwRecords.Text"));
        lblRefAdv.Text = (olng.GetItemDesc("lblRefAdv"));
        lblClientCode.Text = (olng.GetItemDesc("lblClientCode"));
        lblSapCode.Text = (olng.GetItemDesc("lblSapCode"));
        lblchbox.Text = (olng.GetItemDesc("lblchbox"));
        lblFranchisee.Text = (olng.GetItemDesc("lblFranchisee"));
        lblLicenseNo.Text = (olng.GetItemDesc("lblLicenseNo"));
        lblCDALinkg.Text = (olng.GetItemDesc("lblCDALinkg"));
        ////added by akshay on 17/02/2014 to fetch label names from database
        lblUnTyp.Text = (olng.GetItemDesc("lblUnTyp"));
        lblRptUntTyp.Text = (olng.GetItemDesc("lblRptUntTyp"));
        //Added by swapnesh on 13/12/2013 to fetch lables value from database start
        lblPosition.Text = (olng.GetItemDesc("lblPosition"));
        lblchnltype.Text = (olng.GetItemDesc("lblchnltype"));
        dgDetails.Columns[1].HeaderText = (olng.GetItemDesc("lblgvagntcode.Text"));
        dgDetails.Columns[4].HeaderText = (olng.GetItemDesc("lblgvAgntName.Text"));

        dgDetails.Columns[11].HeaderText = (olng.GetItemDesc("lblgvAgntType.Text"));
        dgDetails.Columns[12].HeaderText = (olng.GetItemDesc("lblgvAgntStatus.Text"));
        //Added by swapnesh on 13/12/2013 to fetch lables value from database end

    }
    #endregion
    #region BUTTON 'btnSearch' ONCLICK EVENT
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataReader dtRead;
            divsrchHdr.Style.Add("display", "block");
            if (Request.QueryString["ID"].ToUpper().Trim() == "RT" || Request.QueryString["ID"].ToUpper().Trim() == "TR")
            {
                if (txtAgntCode.Text != "")
                {
                    string strAgnCodeAgnType = "";
                    string strAgnCodeAgnBizsrc = "";
                    string strAgnCodeAgnChnCls = "";
                    //1


                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentType,Bizsrc start
                    httable.Clear();
                    httable.Add("@AgentCode", txtAgntCode.Text.ToString().Trim());
                    httable.Add("@DirectAgtCode", "");
                    httable.Add("@flag", 2);
                    dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnDetails", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentType,Bizsrc End

                    // dtRead = dataAccess.exec_reader("Select AgentType,Bizsrc,Chncls From Agn where AgentCode ='" + txtAgntCode.Text.ToString().Trim() + "'");
                    if (dtRead.Read())
                    {
                        strAgnCodeAgnType = dtRead[0].ToString();
                        strAgnCodeAgnBizsrc = dtRead[1].ToString();
                        strAgnCodeAgnChnCls = dtRead[2].ToString();
                    }
                    dtRead.Close();
                    //2

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentCreateRulstart
                    httable.Clear();
                    httable.Add("@AgentType", strAgnCodeAgnType);
                    httable.Add("@BizSrc", strAgnCodeAgnBizsrc);
                    httable.Add("@ChnCls", strAgnCodeAgnChnCls);
                    httable.Add("@flag", 3);
                    dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentCreateRul End


                    // dtRead = dataAccess.exec_reader("Select AgentCreateRul From chnAgnSu where AgentType='" + strAgnCodeAgnType + "' AND BizSrc='" + strAgnCodeAgnBizsrc + "' AND ChnCls='" + strAgnCodeAgnChnCls + "'");
                    if (dtRead.Read())
                    {
                        ViewState["AgentCreateRul"] = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    //3


                    //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul start
                    httable.Clear();
                    httable.Add("@ChnCls", strAgnCodeAgnType);
                    httable.Add("@BizSrc", strAgnCodeAgnBizsrc);
                    httable.Add("@flag", 2);
                    dtRead = dataAccess.Common_exec_reader_prc("prc_GetChannelSubCls", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul End

                    //  dtRead = dataAccess.exec_reader("Select ChnCreateRul From chnClsSu where BizSrc='" + strAgnCodeAgnBizsrc + "' AND ChnCls='" + strAgnCodeAgnChnCls + "'");
                    if (dtRead.Read())
                    {
                        ViewState["ChnCreateRul"] = dtRead[0].ToString();
                    }
                    dtRead.Close();
                }
            }
            else
            {
                //4

                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent search start
                httable.Clear();


                httable.Add("@CarrierCode", "");
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString().Trim());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
                httable.Add("@flag", 5);


                dtRead = dataAccess.exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);
                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent search End
                // dtRead = dataAccess.exec_reader("Select AgentCreateRul From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    ViewState["AgentCreateRul"] = dtRead[0].ToString();
                }
            }

            BindDataGrid();
            if (txtAgntCode.Text == "")
            {
                //if (ddlAgntStatus.SelectedValue == "IP")////modified by akshay on 25/03/14 changed != to == to set visibility of Agent status column in grid view
                //{
                //    dgDetails.Columns[12].Visible = false;
                //}
                //else
                //{
                //    dgDetails.Columns[12].Visible = true;
                //}
            }
            else
            {
                //5

                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent AgentStatus start
                httable.Clear();
                httable.Add("@AgentCode", txtAgntCode.Text);
                httable.Add("@DirectAgtCode", "");
                httable.Add("@flag", 3);

                dtRead = dataAccess.exec_reader_prc("prc_GetAgnDetails", httable);
                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent AgentStatus End

                //  dtRead = dataAccess.exec_reader("Select AgentStatus From Agn where AgentCode='" + txtAgntCode.Text + "'");
                if (dtRead.Read())
                {
                    //if (dtRead[0].ToString().Trim() != "IP")
                    //{
                    //    dgDetails.Columns[13].Visible = false;
                    //}
                    //else
                    //{
                    //    dgDetails.Columns[13].Visible = true;
                    //}
                }
            }
            //if (ViewState["AgentCreateRul"].ToString() == "RF" || ViewState["AgentCreateRul"].ToString() == "BA")
            //{
            //    dgDetails.Columns[10].Visible = false;
            //    dgDetails.Columns[14].Visible = true;
            //}
            //else
            //{
            //    dgDetails.Columns[10].Visible = true;
            //    dgDetails.Columns[14].Visible = false;
            //}
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
    #region BIND DATAGRID 'dgDetails' METHOD
    protected void BindDataGrid()
    {
        try
        {
            if (txtDTJoinFrom.Text != "" && txtDTJoinTo.Text == "")
            {
                if (Convert.ToDateTime(txtDTJoinFrom.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be future date');</script>", false);
                    return;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Date Joined To');</script>", false);
                return;
            }
            if (txtDTJoinTo.Text != "" && txtDTJoinFrom.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Date Joined From');</script>", false);
                return;
                if (Convert.ToDateTime(txtDTJoinTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined To cannot be future date');</script>", false);
                    return;
                }
            }
            if (txtDTJoinTo.Text != "" && txtDTJoinFrom.Text != "")
            {
                if (Convert.ToDateTime(txtDTJoinFrom.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be future date');</script>", false);
                    return;
                }
                else if (Convert.ToDateTime(txtDTJoinTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined To cannot be future date');</script>", false);
                    return;
                }
                else
                {
                    DateTime dtFrom = DateTime.Parse(txtDTJoinFrom.Text);
                    DateTime dtTo = DateTime.Parse(txtDTJoinTo.Text);
                    if (dtFrom.CompareTo(dtTo) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be greater than Date Joined To');</script>", false);
                        return;
                    }
                }
            }

            string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";
            SqlDataReader dtRead;
            //6

            //Added by asrar on 02/07/2013 converted inline query into proc to get User Type Start
            httable.Clear();
            httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
            dtRead = dataAccess.exec_reader_prc_inscdirect("prc_GetUserType", httable);

            //Added by asrar on 02/07/2013 converted inline query into proc to get User Type End



            //dtRead = dataAccess.Common_exec_reader("Select UserType from InscDirect..iUser Where UserId= '" + Convert.ToString(Session["UserId"].ToString()) + "'");
            if (dtRead.Read())
            {
                strUsrType = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strUsrType == "0")
            {
                strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
            else
            {
                //7

                //Added by asrar on 02/07/2013 converted inline query into proc to Agent Code Start
                httable.Clear();
                httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

                //Added by asrar on 02/07/2013 converted inline query into proc to get Agent Code End


                //dtRead = dataAccess.Common_exec_reader("Select AgentCode from Agn Where EmpCode= '" + Convert.ToString(Session["UserId"].ToString()) + "' AND BizSrc='"+ ddlSlsChnnl.SelectedValue + "' AND AgentStatus='IF'");

                if (dtRead.Read())
                {
                    strIntAgentCode = dtRead[0].ToString();
                }
                dtRead.Close();
                if (strIntAgentCode.Trim().ToString() == "")
                {
                    strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
                }
            }
            dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue);
            dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            string strAgnCreateRul = "";

            decimal strUnitRank = 0;
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            htParam.Add("@Type", ViewState["vwsType"].ToString());
            htParam.Add("@AgentCode", txtAgntCode.Text);
            htParam.Add("@DirectGrpLeader", "");
            htParam.Add("@Surname", "");
            htParam.Add("@Givenname", "");
            htParam.Add("@CurrentId", txtPAN.Text);
            htParam.Add("@AgentStatus", ddlAgntStatus.SelectedValue);
            htParam.Add("@AgentType", ddlAgntType.SelectedValue);
            htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text.Trim());
            htParam.Add("@MgrSapCode", txtMgrSapCode.Text.Trim());
            htParam.Add("@UnitCode", txtUnitCode.Text);
            if (txtDTJoinFrom.Text.Trim() != "")
            {
                htParam.Add("@RecruitDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@RecruitDate ", System.DBNull.Value);
            }
            if (txtDTJoinTo.Text.Trim() != "")
            {
                htParam.Add("@CreateDtim", DateTime.Parse(txtDTJoinTo.Text).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateDtim ", System.DBNull.Value);
            }
            if (ViewState["vwsType"].ToString() == "N")
            {
                htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }
            else if (ViewState["vwsType"].ToString() == "E")
            {
                htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }
            htParam.Add("@AgentName", txtAgntName.Text);
            htParam.Add("@CSCCode", txtCSCCode.Text);
            htParam.Add("@EMPCode", txtSapCode.Text);
            htParam.Add("@LinkRefAdv", txtLinkRef.Text);
            htParam.Add("@GCN", txtGCN.Text);
            htParam.Add("@LicNo", txtLicNo.Text);
            if (Request.QueryString["ID"].ToUpper().Trim() != null)
            {
                htParam.Add("@ID", Request.QueryString["ID"].ToUpper().Trim());
            }
            //Added by swapnesh on 11/12/2013 to add search parameter for reporting type start

            if (ddlRptTyp.SelectedValue != "ALL")
            {
                //rdbRptTyp.SelectedValue = "2";
                htParam.Add("@RptTyp", ddlRptTyp.SelectedValue);
            }
            else
            {
                htParam.Add("@RptTyp", "");
            }
            htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
            //if (rdbPosn.SelectedValue == "0")
            //{
            //    htParam.Add("@posn", "yes");
            //}
            //else
            //{
            //    htParam.Add("@posn", "no");
            //}
            if (ddlPosition.SelectedValue == "0")
            {
                htParam.Add("@posn", DBNull.Value);
            }
            else if (ddlPosition.SelectedValue == "1")
            {
                htParam.Add("@posn", "yes");
            }
            else
            {
                htParam.Add("@posn", "no");
            }
            htParam.Add("@AgentRole", hdnAgentRole.Value.Trim());
            //Added by swapnesh on 11/12/2013 to add search parameter for reporting type end

            if (strUsrType == "0")
            {
                htParam.Add("@UserId", Session["UserID"].ToString());
            }
            else if (strIntAgentCode.Trim().ToString() != "")
            {
                htParam.Add("@UserId", strIntAgentCode.Trim().ToString());
            }


            if (strAgnCreateRul.Trim() == "")
            {
                //8
                //Added by asrar on 02/07/2013 converted inline query into proc to Agent Code Start
                httable.Clear();
                httable.Add("@CarrierCode", "");
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 3);
                dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

                //Added by asrar on 02/07/2013 converted inline query into proc to get Agent Code End

                // dtRead = dataAccess.exec_reader("Select UnitRank,AgentCreateRul From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {

                    strUnitRank = Convert.ToDecimal(dtRead[0].ToString());
                    strAgnCreateRul = dtRead[1].ToString();
                }
                dtRead.Close();
            }
            htParam.Add("@Unittype", ddlUnitType.SelectedValue.ToString().Trim());
            htParam.Add("@RptUnittype", ddlUnits.SelectedValue.ToString().Trim());
            if (Request.QueryString["MvmtMode"] != null)
            {
                if (Request.QueryString["MvmtMode"].ToString().Trim() != null)
                {
                    htParam.Add("@MvmtLvl", Request.QueryString["MvmtMode"].ToString().Trim());
                }
            }

            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_28122017", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    // divsearch1.Attributes.Add("display","block");
                    divsearch1.Attributes.Add("style", "display: block");
                    dgDetails.DataSource = dsResult.Tables[0];
                    //Added by swapnesh on 13/12/2013 to set headertext of gridview columns start
                    //if (Request.QueryString["Type"] != null)
                    //{
                    //    if (Request.QueryString["Type"].ToString() == "emp")
                    //    {
                    //        dgDetails.Columns[0].HeaderText = "Personnel Code";
                    //        dgDetails.Columns[1].HeaderText = "Personnel Name";
                    //        dgDetails.Columns[6].HeaderText = "Personnel Type";
                    //        dgDetails.Columns[11].HeaderText = "Personnel Status";
                    //    }
                    //}
                    //if (Request.QueryString["Type"] != null)
                    //{
                    //    if (Request.QueryString["Type"].ToString() == "vendor")
                    //    {
                    //        dgDetails.Columns[0].HeaderText = "Vendor Code";
                    //        dgDetails.Columns[1].HeaderText = "Vendor Name";
                    //        dgDetails.Columns[6].HeaderText = "Vendor Type";
                    //        dgDetails.Columns[11].HeaderText = "Vendor Status";
                    //    }
                    //}
                    //Added by swapnesh on 13/12/2013 to set headertext of gridview columns end
                    dgDetails.DataBind();
                    ShowPageInformation();
                    if (dgDetails.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        txtPage.Text = "1";
                    }
                    //trDetails.Visible = true;
                    //trDgDetails.Visible = true;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    if (Request.QueryString["ID"].ToUpper().Trim() == "SP")
                    {
                        if (ViewState["AppRule"].ToString() != "1")
                        {
                            lblMessage.Text = "Agent suspension allowed for CDA Franchisee only.";
                            lblMessage.Visible = true;
                        }
                    }

                }
                else
                {
                    //dgDetails.DataSource = null;
                    //dgDetails.DataBind();
                    //lblPageInfo.Text = "";
                    //trDetails.Visible = false;
                    //trDgDetails.Visible = false;
                    //lblMessage.Visible = true;
                    //lblMessage.Text = "0 RECORD FOUND.";
                    dgDetails.AllowPaging = false;
                    dgDetails.AllowSorting = false;

                    ShowNoResultFound(dsResult.Tables[0], dgDetails);

                }
            }

            else
            {
                ShowNoResultFound(dsResult.Tables[0], dgDetails);
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                ////lblPageInfo.Text = "";
                ////trDetails.Visible = false;
                ////trDgDetails.Visible = false;
                //lblMessage.Visible = true;
                //lblMessage.Text = "0 RECORD FOUND.";

            }
            dsResult = null;
            htParam.Clear();
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

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No Record Found";
        source.Rows.Clear();
    }
    #region DATAGRID 'dgDetails' ROWDATABOUND EVENT
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "", strMvmtLvl = "";
            SqlDataReader dtRead;
            //9
            DataSet dsMvmt = new DataSet();
            dsMvmt = GetMemtypeForMvmt("1", Request.QueryString["ID"].ToString().Trim());
            if (dsMvmt.Tables.Count != 0)
            {
                if (dsMvmt.Tables[0].Rows.Count != 0)
                {
                    strMvmtLvl = dsMvmt.Tables[0].Rows[0]["MvmtLvl"].ToString().Trim();
                }
            }
            dsMvmt.Clear();

            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type Start
            httable.Clear();
            httable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));

            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetUserType", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type End
            if (dtRead.Read())
            {
                strUsrType = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strUsrType == "0")
            {
                strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
            else
            {
                //10
                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode Start
                httable.Clear();
                httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());

                dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode End
                if (dtRead.Read())
                {
                    strIntAgentCode = dtRead[0].ToString();
                }
                dtRead.Close();
                if (strIntAgentCode.Trim().ToString() == "")
                {
                    strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
                }
            }

            Label lblEMPCode = (Label)e.Row.FindControl("label1");
            Label lblMgrEMPCode = (Label)e.Row.FindControl("MgrEMPCode");
            Label lblAgentStatus = (Label)e.Row.FindControl("AgentStatus");
            ////Akshay
            HiddenField hdnMemRole = (HiddenField)e.Row.FindControl("hdnMemRole");
            HiddenField hdnCrMvmtRule = (HiddenField)e.Row.FindControl("hdnCrMvmtRule");
            HiddenField hdnModMvmtRule = (HiddenField)e.Row.FindControl("hdnModMvmtRule");
            HiddenField hdnTrfMvmtRule = (HiddenField)e.Row.FindControl("hdnTrfMvmtRule");
            HiddenField hdnTrmMvmtRule = (HiddenField)e.Row.FindControl("hdnTrmMvmtRule");
            HiddenField hdnReinMvmtRule = (HiddenField)e.Row.FindControl("hdnReinMvmtRule");
            HiddenField hdnPrmMvmtRule = (HiddenField)e.Row.FindControl("hdnPrmMvmtRule");
            HiddenField hdnDemMvmtRule = (HiddenField)e.Row.FindControl("hdnDemMvmtRule");

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "CR")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        ////added by akshay for member creation movement
                        e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&MvmtMode=" + Request.QueryString["MvmtMode"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                    }
                }
                if (Request.QueryString["ID"].ToUpper().Trim() == "RIN")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        //Change: Parag @ 20022014- Alteration of Reinstatement QueryString ID from RE to RIN
                        e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"MemberReinstate.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\">" + e.Row.Cells[1].Text + "</a>";
                    }
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IN")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton lnkRequest = new LinkButton();
                        lnkRequest = (LinkButton)e.Row.FindControl("lnk");
                        lnkRequest.Attributes.Add("onclick", "funcShowPopupBAS('" + e.Row.Cells[1].Text + "');return false;");
                    }
                    if (lblAgentStatus.Text.Trim() != "IP")
                    {
                        if (Request.QueryString["Type"].ToString() == "I")
                        {
                            string strChnCls = ddlChnCls.SelectedItem.Text.ToString();
                            string strChannel = ddlSlsChnnl.SelectedItem.Text.ToString();
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\" href=\"AgentVendorMap.aspx?AgentCode=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&AgentName=" + e.Row.Cells[3].Text + "&slsChannel=" + strChannel + "&ChnCls=" + strChnCls + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                        else if (Request.QueryString["Type"].ToString() == "M")
                        {
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AgtVenMapping.aspx?AgentCode=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }

                        else
                        {
                            if (hdnAgentRole != null)
                            {
                                if (hdnAgentRole.Value == "E")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else if (hdnAgentRole.Value == "V")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Ven" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                            }
                            else
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                        }
                    }
                }

                //added by akshay on 23/01/14 start
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRF")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (Request.QueryString["MvmtMode"] != null)
                        {
                            if (Request.QueryString["MvmtMode"].ToString() == "0")
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=" + hdnAgentRole.Value.ToString().Trim() + "&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                            else
                            {
                                //e.Row.Cells[1].Text = "<a href=\"AGTTransfer.aspx?flag=A&Type=E&ID=Trf&Ctgry=Emp&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=" + hdnAgentRole.Value.ToString().Trim() + "&flag=A&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                        }
                    }
                }

                //added by akshay on 23/01/14 end


                else if (Request.QueryString["ID"].ToUpper().Trim() == "TR")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (hdnAgentRole.Value == "E")
                        {
                            if (Request.QueryString["MvmtMode"] != null)
                            {
                                if (Request.QueryString["MvmtMode"].ToString() == "0")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&flag=A&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                            }
                            //e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                        else
                        {
                            if (Request.QueryString["MvmtMode"] != null)
                            {
                                if (Request.QueryString["MvmtMode"].ToString() == "0")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&flag=A&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                            }
                            //e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                    }
                    else
                    {
                        if (Request.QueryString["MvmtMode"] != null)
                        {
                            if (Request.QueryString["MvmtMode"].ToString() == "0")
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                            else
                            {
                                //e.Row.Cells[1].Text = "<a href=\"AGTTransfer.aspx?flag=A&Type=E&ID=Trf&Ctgry=Emp&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&flag=A&MvmtRule=" + hdnTrfMvmtRule.Value.Trim() + "&MvmtMode=" + strMvmtLvl.Trim() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                        }
                        //e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                    }
                }

                //added by akshay on 27/01/14 end
                else if (Request.QueryString["ID"].ToUpper().Trim() == "PR")
                {
                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTPromotion.aspx?Role=" + hdnAgentRole.Value + "&AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                }
            }
        }
    }
    #endregion
    #region BUTTON 'btnClear' ONCLCIK EVENT
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + ViewState["vwsType"].ToString());
    }
    #endregion
    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = GetDataTable();
        DataView dv = new DataView(dt);
        GridView dgSource = (GridView)sender;

        dgSource.PageIndex = e.NewPageIndex;
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowPageInformation();
    }
    #endregion
    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion
    #region DATAGRID 'dgDetails' SORT EVENT
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridView dgSource = (GridView)sender;
        string strSort = string.Empty;
        string strASC = string.Empty;
        if (dgSource.Attributes["SortExpression"] != null)
        {
            strSort = dgSource.Attributes["SortExpression"].ToString();
        }
        if (dgSource.Attributes["SortASC"] != null)
        {
            strASC = dgSource.Attributes["SortASC"].ToString();
        }

        dgSource.Attributes["SortExpression"] = e.SortExpression;
        dgSource.Attributes["SortASC"] = "Yes";

        if (e.SortExpression == strSort)
        {
            if (strASC == "Yes")
            {
                dgSource.Attributes["SortASC"] = "No";
            }
            else
            {
                dgSource.Attributes["SortASC"] = "Yes";
            }
        }

        DataTable dt = GetDataTable();
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowPageInformation();
    }
    #endregion
    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        SqlDataReader dtRead;
        string strAgnCreateRule = "";
        string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";

        decimal strUntRnk = 0;
        dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        //11

        //added by asrar on 03/07/2013 to convert inline query into proc to get UserType start
        httable.Clear();
        httable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));

        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetUserType", httable);

        //added by asrar on 03/07/2013 to convert inline query into proc to get UserType End

        //  dtRead = dataAccess.Common_exec_reader("Select UserType from InscDirect..iUser Where UserId= '" + Convert.ToString(Session["UserId"].ToString()) + "'");
        if (dtRead.Read())
        {
            strUsrType = dtRead[0].ToString();
        }
        dtRead.Close();
        if (strUsrType == "0")
        {
            strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
        }
        else
        {

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode Start
            httable.Clear();
            httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());

            dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode End


            // dtRead = dataAccess.Common_exec_reader("Select AgentCode from Agn Where EmpCode= '" + Convert.ToString(Session["UserId"].ToString()) + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND AgentStatus='IF'");
            //12
            if (dtRead.Read())
            {
                strIntAgentCode = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strIntAgentCode.Trim().ToString() == "")
            {
                strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
        }
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        htParam.Add("@Type", ViewState["vwsType"].ToString());
        htParam.Add("@AgentCode", txtAgntCode.Text);
        htParam.Add("@DirectGrpLeader", "");
        htParam.Add("@Surname", "");
        htParam.Add("@Givenname", "");
        htParam.Add("@CurrentId", txtPAN.Text);
        htParam.Add("@AgentStatus", ddlAgntStatus.SelectedValue);
        htParam.Add("@AgentType", ddlAgntType.SelectedValue);
        htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text.Trim());
        htParam.Add("@MgrSapCode", txtMgrSapCode.Text.Trim());
        htParam.Add("@UnitCode", txtUnitCode.Text);
        if (txtDTJoinFrom.Text.Trim() != "")
        {
            htParam.Add("@RecruitDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@RecruitDate ", System.DBNull.Value);
        }
        if (txtDTJoinTo.Text.Trim() != "")
        {
            htParam.Add("@CreateDtim", DateTime.Parse(txtDTJoinTo.Text).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@CreateDtim ", System.DBNull.Value);
        }
        if (ViewState["vwsType"].ToString() == "N")
        {
            htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        }
        else if (ViewState["vwsType"].ToString() == "E")
        {
            htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        }
        htParam.Add("@AgentName", txtAgntName.Text);
        htParam.Add("@CSCCode", txtCSCCode.Text);
        htParam.Add("@EMPCode", txtSapCode.Text);
        htParam.Add("@LinkRefAdv", txtLinkRef.Text);
        htParam.Add("@GCN", txtGCN.Text);
        htParam.Add("@LicNo", txtLicNo.Text);
        //Added by swapnesh on 11/12/2013 to add search parameter for reporting type start

        if (ddlRptTyp.SelectedValue != "ALL")
        {
            //rdbRptTyp.SelectedValue = "2";
            htParam.Add("@RptTyp", ddlRptTyp.SelectedValue);
        }
        else
        {
            htParam.Add("@RptTyp", "");
        }
        htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
        //if (rdbPosn.SelectedValue == "0")
        //{
        //    htParam.Add("@posn", "yes");
        //}
        //else
        //{
        //    htParam.Add("@posn", "no");
        //}
        if (ddlPosition.SelectedValue == "0")
        {
            htParam.Add("@posn", DBNull.Value);
        }
        else if (ddlPosition.SelectedValue == "1")
        {
            htParam.Add("@posn", "yes");
        }
        else
        {
            htParam.Add("@posn", "no");
        }
        htParam.Add("@AgentRole", hdnAgentRole.Value.Trim());
        //Added by swapnesh on 11/12/2013 to add search parameter for reporting type end
        if (strUsrType == "0")
        {
            htParam.Add("@UserId", Session["UserID"].ToString());
        }
        else if (strIntAgentCode.Trim().ToString() != "")
        {
            htParam.Add("@UserId", strIntAgentCode.Trim().ToString());
        }
        if (strAgnCreateRule.Trim() == "")
        {
            //13


            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCreateRul,UnitRank Start
            httable.Clear();
            httable.Add("@CarrierCode", "");
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 3);

            dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCreateRul,UnitRank End


            //dtRead = dataAccess.exec_reader("Select AgentCreateRul,UnitRank From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {


                strUntRnk = Convert.ToDecimal(dtRead[0].ToString());
                strAgnCreateRule = dtRead[1].ToString();
            }
            dtRead.Close();
        }


        //if (ddlAgntType.SelectedValue == "EC" || ddlAgntType.SelectedValue == "ES")
        //{


        //    if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //    }
        //    else
        //    {
        //        if (strIntAgentCode.Trim().ToString() != "")
        //        {
        //            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //        }
        //        else if (strEmpAgentCode.Trim().ToString() != "")
        //        {
        //            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
        //        }

        //    }
        //}
        //else
        //{
        //if (strUntRnk < 7)
        //{

        //        if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
        //    }
        //    else
        //        {
        //            if (strIntAgentCode.Trim().ToString() != "")
        //            {
        //                dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
        //            }
        //            else if (strEmpAgentCode.Trim().ToString() != "")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
        //    }

        //}

        //    }
        //else
        //{

        //        if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //    }
        //    else
        //        {
        //            if (strIntAgentCode.Trim().ToString() != "")
        //            {
        //                dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //            }
        //            else if (strEmpAgentCode.Trim().ToString() != "")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
        //            }

        //        }
        //    }
        //}
        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
        return dsResult.Tables[0];

    }
    #endregion
    #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
    protected void ddlSlsChnnl_SelectedIndexChanged(object sender, EventArgs e)
    {

        string UserId = Session["UserID"].ToString();
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, UserId.ToString());
        ddlChnCls.Items.Insert(0, new ListItem("All", "All"));


        // trCDAHierarchy.Visible = false;
        CDACheck.Checked = false;
        ddlSlsChnnl.Focus();

    }
    #endregion
    #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {

        Get_UsersAgenttype();
        ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
        ////added by akshay on 17/02/14 to fill UnitType Dropdown and reporting unit type start
        GetUnitType(ddlUnitType);
        GetUnitType(ddlUnits);
        ddlChnCls.Focus();
        ////added by akshay on 17/02/14 to fill UnitType Dropdown and reporting unit type end

    }
    #endregion
    #region Get_ChnCls_User()
    public void Get_ChnCls_User()
    {
        try
        {
            ddlAgntType.Items.Clear();

            ddlChnCls.Items.Clear();
            SqlDataReader dtRead;
            //14

            //added by asrar on 03/07/2013 to convert inline query into proc to get ChnCls,ChnClsDesc01 start
            httable.Clear();
            httable.Add(" @CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", httable);

            //added by asrar on 03/07/2013 to convert inline query into proc to get ChnCls,ChnClsDesc01 End

            //  dtRead = dataAccess.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "'");
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
    #endregion
    #region Get_UsersAgenttype()
    public void Get_UsersAgenttype()
    {
        try
        {
            string UserId = Session["UserID"].ToString();

            if (ddlSlsChnnl.SelectedValue == "")
            {
                oCommonU.GetAgentType(ddlAgntType, "All", "");
            }
            else
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "AH" || Request.QueryString["ID"].ToUpper().Trim() == "VW")
                {
                    oCommonU.GetAgentTypeForSlsChnnlCTSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);
                }
                else
                {
                    GetMemtypeForMvmt("1", "CR");
                    /////oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);

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
    #endregion
    #region ddlAgntType SelectedIndexChanged Event
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader dtRead;
        httable.Clear();
        httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
        httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
        httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
        httable.Add("@flag", 1);
        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);
        if (dtRead.Read())
        {
            if (dtRead.HasRows)
            {
                hdnAgentRole.Value = dtRead[6].ToString();
            }
        }
        dtRead.Close();
        if (Request.QueryString["ID"].ToUpper().Trim() == "TR")
        {

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AppRule ,AgentCreateRul,UntRule  Start
            httable.Clear();
            httable.Add("@CarrierCode", "");
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 12);

            dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AppRule ,AgentCreateRul,UntRule  End


            // dtRead = dataAccess.exec_reader("Select AppRule ,AgentCreateRul,UntRule From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["AppRule"] = dtRead[0].ToString();
                ViewState["AgentCreateRul"] = dtRead[1].ToString();

                if (ViewState["AppRule"].ToString() == "1")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }
                else
                {
                    ChkFranchisee.Visible = false;
                    lblFranchisee.Visible = false;
                }
                if (Convert.ToString(dtRead["UntRule"]) == "3")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }


                if (ddlSlsChnnl.SelectedValue == "AD" && ddlAgntType.SelectedValue == "ST")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }

            }
            dtRead.Close();
            //16


            //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul start
            httable.Clear();
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@flag", 2);
            dtRead = dataAccess.Common_exec_reader_prc("prc_GetChannelSubCls", httable);

            //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul End



            //  dtRead = dataAccess.exec_reader("Select ChnCreateRul From chnClsSu where BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["ChnCreateRul"] = dtRead[0].ToString();
            }
            dtRead.Close();
        }
        else if (Request.QueryString["ID"].ToUpper().Trim() == "SP")
        {
            //17

            //added by asrar on 03/07/2013 to convert inline query to proc to get agent AppRule start
            httable.Clear();
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 8);
            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

            //added by asrar on 03/07/2013 to convert inline query to proc to get agent AppRule End


            //dtRead = dataAccess.exec_reader("Select AppRule From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["AppRule"] = dtRead[0].ToString();
            }
            dtRead.Close();
            if (ViewState["AppRule"].ToString() != "1")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('CDA s only allowed for suspension.');", true);
            }
        }
        else if (Request.QueryString["ID"].ToUpper().Trim() == "AH")
        {
            if (ddlSlsChnnl.SelectedValue == "AG")
            {
                //18

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule,AgentCreateRul,UntRule start
                httable.Clear();
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 9);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule,AgentCreateRul,UntRule End


                // dtRead = dataAccess.exec_reader("Select AppRule,AgentCreateRul,UntRule From chnAgnSu where AgentType ='"+ddlAgntType.SelectedValue  +"' and AgentType in ('DM','SB','AP','PP','SP') AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    if (dtRead.HasRows)
                    {
                        if (Convert.ToString(dtRead[0]).Trim() == "0")
                        {
                            // trCDAHierarchy.Visible = true
                        }
                        else
                        {
                            // trCDAHierarchy.Visible = false;
                        }
                    }
                }
                else
                {
                    // trCDAHierarchy.Visible = false;
                }
                dtRead.Close();

            }
            else if (ddlSlsChnnl.SelectedValue == "CD")
            {
                //19

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule start
                httable.Clear();
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 8);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule End

                //  dtRead = dataAccess.exec_reader("Select AppRule From chnAgnSu where AgentType ='"+ddlAgntType.SelectedValue  +"' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    if (dtRead.HasRows)
                    {
                        if (Convert.ToString(dtRead[0]).Trim() == "1")
                        {
                            // trCDAHierarchy.Visible = true
                        }
                        else
                        {
                            // trCDAHierarchy.Visible = false;
                            CDACheck.Checked = false;
                        }
                    }
                }
            }
        }
        if (hdnAgentRole.Value != null)
        {
            if (hdnAgentRole.Value.ToString() == "E")
            {
                olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
                InitializeControl();
            }
            else if (hdnAgentRole.Value.ToString() == "A")
            {
                olng = new multilingualManager("DefaultConn", "AGTSearchAgt.aspx", strUserLang);
                InitializeControl();
            }
            else if (hdnAgentRole.Value == "V")
            {
                olng = new multilingualManager("DefaultConn", "AGTSearchTab3.aspx", strUserLang);
                InitializeControl();
            }
        }
    }
    #endregion

    //Added by swapnesh on 6/12/2013 to fetch sales channel ddl value base on channel type start
    #region rdbChnlTyp_SelectedIndexChanged
    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbChnlTyp.SelectedValue == "0")
        {
            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "0");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));

        }
        else
        {
            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "1");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
        }
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, Session["UserID"].ToString());
        ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
        ddlAgntType.Items.Clear();
        ddlAgntType.DataSource = null;
        ddlAgntType.DataBind();
        ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
        rdbChnlTyp.Focus();
    }
    #endregion
    //Added by swapnesh on 6/12/2013 to fetch sales channel ddl value base on channel type end

    //Added by swapnesh on 12/12/2013 to add functionality of tabs start
    #region Link lnkTab1_Click
    protected void lnkTab1_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "E";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
    }
    #endregion

    #region Link lnkTab1_Click
    protected void lnkTab2_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "A";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=agt");
    }
    #endregion

    #region Link lnkTab1_Click
    protected void lnkTab3_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "V";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=vendor");
    }
    #endregion
    //Added by swapnesh on 12/12/2013 to add functionality of tabs end

    #region DROPDOWNLIST ddlRptTyp_SelectedIndexChanged
    protected void ddlRptTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRptTyp.SelectedIndex == 0)
        {
            txtImmLeaderCode.Enabled = false;
            txtImmLeaderCode.Text = "";
            txtMgrSapCode.Enabled = false;
            txtMgrSapCode.Text = "";
        }
        else
        {
            txtImmLeaderCode.Enabled = true;
            txtMgrSapCode.Enabled = true;
        }
        ddlRptTyp.Focus();
    }
    #endregion

    ///added by akshay on 06/02/2014 to add unittype dropdown values start
    #region GetUnitType
    protected void GetUnitType(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtddlRead;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@BizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            dtddlRead = dataAccess.Common_exec_reader_prc_common("Prc_GetUnitTypeForAgtSearch", htParam);
            if (dtddlRead.HasRows)
            {
                ddl.DataSource = dtddlRead;////ddlUnitType
                ddl.DataTextField = "UnitDesc";
                ddl.DataValueField = "UnitType";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));//"-- Select --"
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

    #region GetUnits
    protected void GetUnits()
    {
        try
        {
            ddlUnits.Items.Clear();
            SqlDataReader dtddlUnits;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@UnitType", ddlUnitType.SelectedValue);
            dtddlUnits = dataAccess.Common_exec_reader_prc_common("Prc_GetUnitsForAgtSearch", htParam);
            if (dtddlUnits.HasRows)
            {
                ddlUnits.DataSource = dtddlUnits;
                ddlUnits.DataTextField = "Units";
                ddlUnits.DataValueField = "UnitType";
                ddlUnits.DataBind();
            }
            ddlUnits.Items.Insert(0, new ListItem("Select", ""));//-- Select --
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

    protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlUnitType.Focus();
    }
    ///added by akshay on 06/02/2014 to add unittype dropdown values end
    ///
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex + 1;
            BindDataGrid();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgDetails.PageCount;
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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
            BindDataGrid();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            {
                btnprevious.Enabled = false;
            }
            int page = dgDetails.PageCount;
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

    #region Link lnkTab1_Click
    protected void Employee_Click(object sender, EventArgs e)
    {
        hdnAgentRole.Value = "E";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");

    }
    #endregion

    #region Link lnkTab1_Click
    protected void Agent_Click(object sender, EventArgs e)
    {
        hdnAgentRole.Value = "A";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=agt");

    }
    #endregion

    #region Link lnkTab1_Click
    protected void Other_Click(object sender, EventArgs e)
    {
        hdnAgentRole.Value = "V";
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=vendor");
    }
    #endregion

    //added by akshay on 07Sep2016 for implementing movement rule for creation
    protected DataSet GetMemtypeForMvmt(string flag, string rule)
    {
        Hashtable htMvmt = new Hashtable();
        DataSet dsMvmt = new DataSet();
        htMvmt.Clear();
        dsMvmt.Clear();
        ddlAgntType.Items.Clear();
        htMvmt.Add("@UserID", Session["UserID"].ToString().Trim());
        htMvmt.Add("@Bizsrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
        htMvmt.Add("@Chncls", ddlChnCls.SelectedValue.ToString().Trim());
        htMvmt.Add("@MvmtRule", rule.Trim());
        htMvmt.Add("@MvmtMode", Request.QueryString["MvmtMode"].Trim());
        htMvmt.Add("@Flag", flag);
        dsMvmt = dataAccess.GetDataSetForPrcCLP("Prc_GetMemTypeForMvmt_28120217", htMvmt);
        if (dsMvmt.Tables.Count != 0)
        {
            if (dsMvmt.Tables[0].Rows.Count != 0)
            {
                ddlAgntType.DataSource = dsMvmt.Tables[0];
                ddlAgntType.DataValueField = dsMvmt.Tables[0].Columns["MemType"].ToString().Trim();
                ddlAgntType.DataTextField = dsMvmt.Tables[0].Columns["MemTypeDesc"].ToString().Trim();
                ddlAgntType.DataBind();
            }
        }
        return dsMvmt;
    }

}
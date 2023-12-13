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
using INSCL.App_Code;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;

namespace INSCL
{


    public partial class MemberEnquiry : BaseClass
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
                string UserId = Session["UserID"].ToString();
                if (!IsPostBack)
                {
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
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;

                    ddlAgntStatus.Items.Insert(0, new ListItem("All", "All"));
                    ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
                    ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
                    if (ViewState["vwsType"].ToString() == "N")
                    {
                        oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "");

                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                    else
                    {
                        if (Request.QueryString["ID"].ToUpper().Trim() == "AH" || Request.QueryString["ID"].ToUpper().Trim() == "VW")
                        {
                            oCommonU.GetSalesChannelCT(ddlSlsChnnl, "", 0, UserId.ToString(), "");
                        }
                        else
                        {
                            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, UserId.ToString(), "");
                        }

                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                    ddlSlsChnnl.Items.Insert(0, new ListItem("All", "All"));

                    oCommonU.FillNoOfRecDropDown(ddlShwRecrds);
                    trCDAHierarchy.Visible = false;
                    CDACheck.Checked = false;

                }


                if (Request.QueryString["ID"].ToUpper().Trim() == "AH")
                {
                    chbxdefaultunit.Visible = true;
                    lblchbox.Visible = true;
                    lblchbox.Text = "Show default units";
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
                //btnSearch.Attributes.Add("onClick", "javascript: return funValidate();"); //Commented by swapnesh on 13/12/2013 to remove mandatory fields

                CDACheck.Attributes.Add("onClick", "Javascript: return CheckAgtTypeForCDA();");
                txtDTJoinFrom.Attributes.Add("readonly", "readonly");
                txtDTJoinTo.Attributes.Add("readonly", "readonly");

                //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist start
                oCommonU.GetRptType(ddlRptTyp);
                ddlRptTyp.Items.Insert(0, new ListItem("All", "All"));
                //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist end

                //Added by swapnesh on 12/12/2013 to add functionality of tabs start
                lnkTab1.BackColor = System.Drawing.Color.LightYellow;
                lnkTab2.BackColor = System.Drawing.Color.Transparent;
                lnkTab3.BackColor = System.Drawing.Color.Transparent;
                lnkTab1.ImageUrl = "~/theme/iflow/employee.gif";
                lnkTab2.ImageUrl = "~/theme/iflow/Agent_hover.gif";
                lnkTab3.ImageUrl = "~/theme/iflow/other_hover.gif";
                olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
                InitializeControl();
                rdbChnlTyp.SelectedValue = "0";
                hdnAgentRole.Value = "0";
                rdbChnlTyp_SelectedIndexChanged(sender, e);
                //ddlRptTyp.SelectedValue = "CU";

                if (Request.QueryString["Role"] != null)
                {
                    if (Request.QueryString["Role"].ToString() == "agt")
                    {
                        lnkTab1.BackColor = System.Drawing.Color.Transparent;
                        lnkTab2.BackColor = System.Drawing.Color.LightYellow;
                        lnkTab3.BackColor = System.Drawing.Color.Transparent;
                        lnkTab1.ImageUrl = "~/theme/iflow/employee_hover.gif";
                        lnkTab2.ImageUrl = "~/theme/iflow/Agent.gif";
                        lnkTab3.ImageUrl = "~/theme/iflow/other_hover.gif";
                        olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
                        InitializeControl();
                        rdbChnlTyp.SelectedValue = "1";
                        hdnAgentRole.Value = "1";
                        rdbChnlTyp_SelectedIndexChanged(sender, e);
                        //ddlRptTyp.SelectedValue = "CF";
                    }
                }

                if (Request.QueryString["Role"] != null)
                {
                    if (Request.QueryString["Role"].ToString() == "vendor")
                    {
                        lnkTab1.BackColor = System.Drawing.Color.Transparent;
                        lnkTab2.BackColor = System.Drawing.Color.Transparent;
                        lnkTab3.BackColor = System.Drawing.Color.LightYellow;
                        lnkTab1.ImageUrl = "~/theme/iflow/employee_hover.gif";
                        lnkTab2.ImageUrl = "~/theme/iflow/Agent_hover.gif";
                        lnkTab3.ImageUrl = "~/theme/iflow/other.gif";
                        olng = new multilingualManager("DefaultConn", "AGTSearchTab3.aspx", strUserLang);
                        InitializeControl();
                        rdbChnlTyp.SelectedValue = "1";
                        hdnAgentRole.Value = "2";
                        rdbChnlTyp_SelectedIndexChanged(sender, e);
                        //ddlRptTyp.SelectedValue = "ALL";
                    }
                }
                //Added by swapnesh on 12/12/2013 to add functionality of tabs end
            }
            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToString().ToUpper().Trim() == "TE")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Termination";

                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "LS")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Level Setup";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TR")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Transfer Request";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IN")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;

                    lblSourceName.Text = "Agent Info-Edit";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "RE")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Reinstatement";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "PR")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Promotion Request";
                }

                else if (Request.QueryString["ID"].ToUpper().Trim() == "PU")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Promotion Date Updation";
                }

                else if (Request.QueryString["ID"].ToUpper().Trim() == "AM")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent AM Promotion";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "VW")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "AgentInfo View";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "SP")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Suspension";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "MH")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Movement History";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "BR")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Branch Assignment";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "AH")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Hierarchy";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "RI")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "SM Reinstatement";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IT")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Inter Channel Transfer";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "LK")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent LinkRef AdvCode";
                }
                //Added By SANDEEP GARG on 10/12/2013 START
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IRC")
                {
                    trHead.Visible = true;
                    lblSourceName.Visible = true;

                    lblSourceName.Text = "View Agent For IRC";
                }
                //Added By SANDEEP GARG on 10/12/2013 END
                else
                {
                    trHead.Visible = false;
                    lblSourceName.Visible = false;
                }
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
            lblDTJoinFrom.Text = (olng.GetItemDesc("lblDTJoinFrom.Text"));
            lblDTJoinTo.Text = (olng.GetItemDesc("lblDTJoinTo.Text"));
            lblCSCCode.Text = (olng.GetItemDesc("lblCSCCode.Text"));
            lblShwRecords.Text = (olng.GetItemDesc("lblShwRecords.Text"));
            lblRefAdv.Text = (olng.GetItemDesc("lblRefAdv"));
            lblClientCode.Text = (olng.GetItemDesc("lblClientCode"));
            lblSapCode.Text = (olng.GetItemDesc("lblSapCode"));
            lblchbox.Text = (olng.GetItemDesc("lblchbox"));
            lblFranchisee.Text = (olng.GetItemDesc("lblFranchisee"));
            lblLicenseNo.Text = (olng.GetItemDesc("lblLicenseNo"));
            lblCDALinkg.Text = (olng.GetItemDesc("lblCDALinkg"));
            //Added by swapnesh on 13/12/2013 to fetch lables value from database start
            lblPosition.Text = (olng.GetItemDesc("lblPosition"));
            lblchnltype.Text = (olng.GetItemDesc("lblchnltype"));
            //dgDetails.Columns[0].HeaderText = (olng.GetItemDesc("lblgvagntcode.Text"));
            //dgDetails.Columns[1].HeaderText = (olng.GetItemDesc("lblgvAgntName.Text"));
            //dgDetails.Columns[8].HeaderText = (olng.GetItemDesc("lblgvAgntType.Text"));
            //dgDetails.Columns[13].HeaderText = (olng.GetItemDesc("lblgvAgntStatus.Text"));
            //Added by swapnesh on 13/12/2013 to fetch lables value from database end
        }
        #endregion
        #region BUTTON 'btnSearch' ONCLICK EVENT
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataReader dtRead;
            try
            {
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
        #region BIND DATAGRID 'dgDetails' METHOD
        protected void BindDataGrid()
        {
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
            htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text);
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


            if (ddlAgntType.SelectedValue == "EC" || ddlAgntType.SelectedValue == "ES")
            {

                if (strUsrType == "0")
                {
                    dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                }
                else
                {
                    if (strIntAgentCode.Trim().ToString() != "")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                    }
                    else
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
                    }
                }
            }
            else
            {
                if (strUnitRank < 7)
                {

                    if (strUsrType == "0")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
                    }
                    else
                    {
                        if (strIntAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
                        }
                        else
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
                        }
                    }

                }
                else
                {

                    if (strUsrType == "0")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                    }
                    else
                    {
                        if (strIntAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                        }
                        else
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
                        }

                    }
                }
            }

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
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
                    trDetails.Visible = true;
                    trDgDetails.Visible = true;
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
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 RECORD FOUND.";

                }
            }

            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblPageInfo.Text = "";
                trDetails.Visible = false;
                trDgDetails.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "0 RECORD FOUND.";

            }
            dsResult = null;
            htParam.Clear();
        }
        #endregion
        #region DATAGRID 'dgDetails' ROWDATABOUND EVENT
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";


            SqlDataReader dtRead;
            //9

            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type Start
            httable.Clear();
            httable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));

            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetUserType", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type End

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
                //10


                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode Start
                httable.Clear();
                httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());

                dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode End

                // dtRead = dataAccess.Common_exec_reader("Select AgentCode from Agn Where EmpCode= '" + Convert.ToString(Session["UserId"].ToString()) + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND AgentStatus='IF' ");
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEMPCode = (Label)e.Row.FindControl("label1");
                Label lblMgrEMPCode = (Label)e.Row.FindControl("MgrEMPCode");
                //Label lblAgentStatus = (Label)e.Row.FindControl("AgentStatus");

                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"].ToUpper().Trim() == "ME")
                    {

                        //if (chbxdefaultunit.Checked == true && CDACheck.Checked == true)
                        //{
                        //    e.Row.Cells[0].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[0].Text + "</a>";
                        //    // e.Row.Cells[3].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&PrmyMgrCode" + e.Row.Cells[3].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[3].Text + "</a>";
                        //    /// e.Row.Cells[4].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&AddlMgrCode" + e.Row.Cells[4].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[4].Text + "</a>";
                        //}
                        //else if (chbxdefaultunit.Checked == false && CDACheck.Checked == false)
                        //{
                        //    //e.Row.Cells[0].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=N&Flag=N&AgnCd=" + e.Row.Cells[0].Text + "&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[0].Text + "</a>";
                        //    //e.Row.Cells[3].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&PrmyMgrCode=" + e.Row.Cells[3].Text + "&AddlMgrCode=&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[3].Text + "</a>";
                        //    //e.Row.Cells[4].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AddlMgrCode=" + e.Row.Cells[4].Text + "&PrmyMgrCode=&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[4].Text + "</a>";
                        //    // e.Row.Cells[0].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=N&Flag=N&AgnCd=" + e.Row.Cells[0].Text + "&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[0].Text + "</a>";
                        //}
                        //else
                        //{
                        //    if (chbxdefaultunit.Checked)
                        //    {
                        //        e.Row.Cells[0].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=N&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[0].Text + "</a>";
                        //        // e.Row.Cells[3].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&PrmyMgrCode" + e.Row.Cells[3].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[3].Text + "</a>";
                        //        //e.Row.Cells[4].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&AddlMgrCode" + e.Row.Cells[4].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[4].Text + "</a>";
                        //    }
                        //    else
                        //    {
                        //        e.Row.Cells[0].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=N&AgnCd=" + e.Row.Cells[0].Text + "&AgnName=" + e.Row.Cells[2].Text + "\">" + e.Row.Cells[0].Text + "</a>";
                        //        // e.Row.Cells[3].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&PrmyMgrCode" + e.Row.Cells[3].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[3].Text + "</a>";
                        //        // e.Row.Cells[4].Text = "<a href=\"AgtSearchHierarchydtls.aspx?CDAFlag=Y&Flag=Y&AgnCd=" + e.Row.Cells[0].Text + "&AgnType=" + e.Row.Cells[6].Text + "&AddlMgrCode" + e.Row.Cells[4].Text + "&AgnName=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[4].Text + "</a>";
                        //    }
                        //}


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
            try
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
        #region METHOD 'ShowPageInformation'
        private void ShowPageInformation()
        {
            int intPageIndex = dgDetails.PageIndex + 1;
            lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
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
            htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text);
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


            if (ddlAgntType.SelectedValue == "EC" || ddlAgntType.SelectedValue == "ES")
            {


                if (strUsrType == "0")
                {
                    dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                }
                else
                {
                    if (strIntAgentCode.Trim().ToString() != "")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                    }
                    else if (strEmpAgentCode.Trim().ToString() != "")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
                    }

                }
            }
            else
            {
                if (strUntRnk < 7)
                {

                    if (strUsrType == "0")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
                    }
                    else
                    {
                        if (strIntAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
                        }
                        else if (strEmpAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
                        }

                    }

                }
                else
                {

                    if (strUsrType == "0")
                    {
                        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                    }
                    else
                    {
                        if (strIntAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
                        }
                        else if (strEmpAgentCode.Trim().ToString() != "")
                        {
                            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
                        }

                    }
                }
            }
            return dsResult.Tables[0];

        }
        #endregion
        #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
        protected void ddlSlsChnnl_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string UserId = Session["UserID"].ToString();
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, UserId.ToString());
                ddlChnCls.Items.Insert(0, new ListItem("All", "All"));


                trCDAHierarchy.Visible = false;
                CDACheck.Checked = false;
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
        #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
        protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Get_UsersAgenttype();
                ddlAgntType.Items.Insert(0, new ListItem("All", "All"));

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
        #region Get_ChnCls_User()
        public void Get_ChnCls_User()
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
        #endregion
        #region Get_UsersAgenttype()
        public void Get_UsersAgenttype()
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
                    //oCommonU.GetAgentTypeForSlsChnnlCT(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId);
                    oCommonU.GetAgentTypeForSlsChnnlCTSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);
                }
                else
                {
                    //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId);
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);
                }

            }
        }
        #endregion
        #region ddlAgntType SelectedIndexChanged Event
        protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dtRead;
            try
            {
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
                                    trCDAHierarchy.Visible = true;
                                }
                                else
                                {
                                    trCDAHierarchy.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            trCDAHierarchy.Visible = false;
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
                                    trCDAHierarchy.Visible = true;
                                }
                                else
                                {
                                    trCDAHierarchy.Visible = false;
                                    CDACheck.Checked = false;
                                }
                            }
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
        #endregion

        //Added by swapnesh on 6/12/2013 to fetch sales channel ddl value base on channel type start
        #region rdbChnlTyp_SelectedIndexChanged
        protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
        //Added by swapnesh on 6/12/2013 to fetch sales channel ddl value base on channel type end

        //Added by swapnesh on 12/12/2013 to add functionality of tabs start
        #region Link lnkTab1_Click
        protected void lnkTab1_Click(object sender, ImageClickEventArgs e)
        {
            hdnAgentRole.Value = "0";
            Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
        }
        #endregion

        #region Link lnkTab1_Click
        protected void lnkTab2_Click(object sender, ImageClickEventArgs e)
        {
            hdnAgentRole.Value = "1";
            Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=agt");
        }
        #endregion

        #region Link lnkTab1_Click
        protected void lnkTab3_Click(object sender, ImageClickEventArgs e)
        {
            hdnAgentRole.Value = "2";
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
            }
            else
            {
                txtImmLeaderCode.Enabled = true;
            }
        }
        #endregion

        string agentcode = string.Empty;
        string strFlag = string.Empty;
        protected void lbPrmyMgrCode_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbChnCls = (LinkButton)grd.FindControl("lbPrmyMgrCode");
            Label lblAgtCode = (Label)grd.FindControl("lblAgtCode");
            //Response.Redirect("AgtSearchHierarchydtls.aspx?Flag=P&AgnCd=" + lblAgtCode.Text + "");
            agentcode = lblAgtCode.Text.ToString();
            strFlag = "P";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "OpenPopup('" + agentcode + "','" + strFlag + "');", true);
        }
        protected void lbAddlMgrCode_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbChnCls = (LinkButton)grd.FindControl("lbAddlMgrCode");
            Label lblAgtCode = (Label)grd.FindControl("lblAgtCode");
            //Response.Redirect("AgtSearchHierarchydtls.aspx?Flag=A&AgnCd=" + lblAgtCode.Text + "");
            agentcode = lblAgtCode.Text.ToString();
            strFlag = "A";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "OpenPopup('" + agentcode + "','" + strFlag + "');", true);

        }
    }

}
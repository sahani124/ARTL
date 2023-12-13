using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Collections;
using DataAccessClassDAL;
using INSCL.App_Code;


public partial class Application_ISys_Recruit_Report : BaseClass
{
    DataSet dsDtls = new DataSet();
    DataTable dtResult = new DataTable();
    Hashtable htparam = new Hashtable();
    DataAccessClass objCon = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            if (!IsPostBack)
            {
                GetAgentandUserDtls();
                if (Request.QueryString["Type"] == "NSE")
                {
                    lbltitle.Text = "NSE Report Search";
                }
                else if (Request.QueryString["Type"] == "AgtIn")
                {
                    lbltitle.Text = "Agent In Force Report Search";
                    trAll.Visible = false;
                    TrA.Visible = true;
                    lblError2.Visible = true;
                }
                else if (Request.QueryString["Type"] == "AgtTrckr")
                {
                    lbltitle.Text = "Enrollment Tracker Report Search";
                }
                else if (Request.QueryString["Type"] == "RptTrckr")
                {
                    lbltitle.Text = "Repeater Tracker Report Search";
                }
                else if (Request.QueryString["Type"] == "AgtLicReg")
                {
                    lbltitle.Text = "Agent License Registration Report Search";
                }
                else if (Request.QueryString["Type"] == "FEE")
                {
                    lbltitle.Text = "Candidate Fees Tracker Report Search";
                }
                else if (Request.QueryString["Type"] == "Composite")
                {
                    lbltitle.Text = "Composite Tracker Report Search";
                }
                else if (Request.QueryString["Type"] == "Renewal")
                {
                    lbltitle.Text = "Renewal Tracker Report Search";
                }
                else if (Request.QueryString["Type"] == "SpocEnroll")
                {
                    lbltitle.Text = "ARTL Report";
                    trAll.Visible = true;
                    TrA.Visible = false;
                }
                else if (Request.QueryString["Type"] == "SpocEnrollRE")
                {
                    lbltitle.Text = "ARTL Repeater Report";
                    trAll.Visible = true;
                    TrA.Visible = false;
                }
                else if (Request.QueryString["Type"] == "SpocEnrollRW")
                {
                    lbltitle.Text = "ARTL Renewal Report";
                    trAll.Visible = true;
                    TrA.Visible = false;
                }
                else if (Request.QueryString["Type"] == "SpocExam")
                {
                    lbltitle.Text = "Spocs Exam Report";
                }
                else if (Request.QueryString["Type"] == "SpocCFR")
                {
                    lbltitle.Text = "Spocs CFR Report";
                }
                //Added by Nikhil for exam report on 30.4.15
                else if (Request.QueryString["Type"] == "ExmRpt")
                {

                    lbltitle.Text = "Exam Report ";
                    trAll.Visible = true;
                }
                else if (Request.QueryString["Type"] == "CFRRaiseRpt")
                {
                    // trProcessType.Attributes.Add("style", "display:block");
                    trProcessType.Visible = true;
                    ddlProcessType1();
                    lbltitle.Text = "CFR Raise Report ";
                    trAll.Visible = true;
                }
                //Ended by Nikhil on 30.4.15
                //added by usha  on 01.10.2015
                else if (Request.QueryString["Type"] == "updagent")
                {
                    lbltitle.Text = "NOC Report";
                    trAll.Visible = true;
                }
                //ended  by usha  on 01.10.2015
                // Added by usha for fees waiver tracker on 19.01.2016
                else if (Request.QueryString["Type"] == "feestrckr")
                {
                    lbltitle.Text = "Fees Waiver Report";
                    trAll.Visible = true;
                }


                //ended by usha  for fees waiver tracker on 19.01.2016

                //added by meena  on 21.03.2017
                else if (Request.QueryString["Type"] == "mobusgRpt")
                {
                    lbltitle.Text = "Mobile Usage Report";
                    trAll.Visible = true;

                    trProcessType.Visible = false;
                }

                //ended  by usha  on 21.03.2017


                 //added by Usha   on 10.08.2017
                else if (Request.QueryString["Type"] == "AgentProfileRpt")
                {
                    lbltitle.Text = "Agent Profile Report";
                    trAll.Visible = true;
                    // btncsv.Visible = false;
                    trProcessType.Visible = false;
                }

                //ended  by usha  on 21.03.2017

                 //added by Usha   on 10.08.2017
                else if (Request.QueryString["Type"] == "AgntT20Rpt")
                {
                    lbltitle.Text = "Agent T20 Report";
                    trAll.Visible = true;
                    TrDate.Visible = true;
                    // btncsv.Visible = false;
                    trProcessType.Visible = false;
                }
                else if (Request.QueryString["Type"] == "AgntT90Rpt")
                {
                    lbltitle.Text = "Agent T90 Report";
                    trAll.Visible = true;
                    TrDate.Visible = true;
                    trProcessType.Visible = false;
                }
                else if (Request.QueryString["Type"] == "AgntInactiveRpt")
                {
                    lbltitle.Text = " Inactive Agent Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
                    TrDate.Visible = true;
                }


                //ended  by usha  on 21.03.2017

                else if (Request.QueryString["Type"] == "AgntWIPSurveyRpt")
                {
                    lbltitle.Text = " WIP Survey Agent Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
                }
                else if (Request.QueryString["Type"] == "AgntVerificationSurveyRpt")
                {
                    lbltitle.Text = "Agent Verification Survey  Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
                }


                else if (Request.QueryString["Type"] == "AgntProdctiSurveyRpt")
                {
                    lbltitle.Text = "Agent Productivity Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
                }

                else if (Request.QueryString["Type"] == "AgntSMUpdationSurveyRpt")
                {
                    lbltitle.Text = "Agent SM Updation  Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
                }
                else if (Request.QueryString["Type"] == "CommPaymntRpt")
                {
                    lbltitle.Text = "Agent SM Updation  Report";
                    trAll.Visible = true;
                    trProcessType.Visible = false;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            dsDtls.Clear();
            htparam.Clear();
            LocalReport Report = new LocalReport();
            //added by usha for fees waiver report on 19.01.2016
            #region fees waiver report
            if (Request.QueryString["Type"] == "feestrckr")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_feeswaivertracker", htparam);
                dsDtls.DataSetName = "FeesWaiver";

                ReportDataSource RptDtls = new ReportDataSource("FeesWaiver", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\FeesWaiver.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "FeesWaiver.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }


            }

            #endregion
            //  ended by usha
            //Added by usha  on 01.10.2015
            #region NOC Report
            if (Request.QueryString["Type"] == "updagent")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_UpdateNOCTrckr", htparam);
                dsDtls.DataSetName = "UpdateNOCAgency";

                ReportDataSource RptDtls = new ReportDataSource("UpdateNOCAgency", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\UpdateNOCAgency.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "UpdateNOCAgency.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }


            }
            #endregion
            //ended by usha 
            //Added by Nikhil for exam report details on 30.4.15
            #region Exam Report
            if (Request.QueryString["Type"] == "ExmRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 
                htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_ExamDateReport", htparam);
                dsDtls.DataSetName = "ExmRpt";

                ReportDataSource RptDtls = new ReportDataSource("ExmRpt", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\ExmRpt.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "ExmRpt.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }


            }
            #endregion
            #region CFR Raise Report
            if (Request.QueryString["Type"] == "CFRRaiseRpt")
            {
                if (ddlProcessType.SelectedValue == "--Select--" && txtrptDtfrmval.Text != "" && txtrptDttoval.Text != "")
                {
                    lblman.Visible = true;
                }
                else
                {

                    lblman.Visible = false;
                    //Added by Nikhil for date range on 08.05.15
                    if (txtrptDtfrmval.Text.Trim() != "")
                    {
                        htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htparam.Add("@DtFrom", System.DBNull.Value);
                    }
                    if (txtrptDttoval.Text.Trim() != "")
                    {
                        htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htparam.Add("@DtTo", System.DBNull.Value);
                    }
                    if (ddlProcessType.SelectedValue != "")
                    {
                        if (ddlProcessType.SelectedValue == "Reterival")
                        {
                            htparam.Add("@ProcessType", "RW");

                        }
                        else if (ddlProcessType.SelectedValue == "Repeater")
                        {
                            htparam.Add("@ProcessType", "RE");

                        }
                        else if (ddlProcessType.SelectedValue == "NOC")
                        {
                            htparam.Add("@ProcessType", "NC");

                        }
                        else
                        {
                            htparam.Add("@ProcessType", "NR");
                        }
                    }
                    //ended by Nikhil 

                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetCFRRaiseRpt", htparam);
                    dsDtls.DataSetName = "CFRRaiseRpt";

                    ReportDataSource RptDtls = new ReportDataSource("CFRRaiseRpt", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        lblMessage.Visible = false;
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\CFRRaiseRpt.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "CFRRaiseRpt.rdlc";

                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(RptDtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";

                    }

                }
            }
            #endregion
            //Ended by Nikhil 
            #region NSE Report
            if (Request.QueryString["Type"] == "NSE")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("prc_NseReport", htparam);
                //Search criterion added by rachana end

                dsDtls.DataSetName = "NSE";

                ReportDataSource RptDtls = new ReportDataSource("NSE", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\NSE.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "NSE.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }


            }
            #endregion
            #region Agent In Force Report
            else if (Request.QueryString["Type"] == "AgtIn")
            {
                // htparam.Add("@Flag", textReport.Text);
                //dsDtls = objCon.GetDataSetForPrcDBConn("prc_getAgentInForce", htparam, "ARTLConnectionString");

                //dsDtls = objCon.GetDataSetForPrc1("prc_getAgentInForce");
                if (txtrptDtfrmvalA.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmvalA.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                //if (txtrptDttoval.Text.Trim() != "")
                //{
                //    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                //}
                //else
                //{
                //    htparam.Add("@DtTo", System.DBNull.Value);
                //}
                //dsDtls = objCon.GetDataSetForPrcRecruits("prc_getAgentInForce", htparam);
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_getAgentinforceReport", htparam);
                dsDtls.DataSetName = "Agent";

                ReportDataSource RptDtls = new ReportDataSource("Agent", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentInForce.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentInForce.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }

            }
            #endregion
            #region Enrollment Lic Report
            else if (Request.QueryString["Type"] == "AgtTrckr")
            {
                //htparam.Add("@Flag", textReport.Text);

                //dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetAgentTrackerDtls", htparam, "ARTLConnectionString");
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetAgentTrackerDtls", htparam);
                //Search criterion added by rachana end

                dsDtls.DataSetName = "AgentTracker";

                ReportDataSource Rptdtls = new ReportDataSource("AgentTracker", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentTracker.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentTracker.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }

            }
            #endregion
            #region LIC Repeater Report
            else if (Request.QueryString["Type"] == "RptTrckr")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_RepeaterTrackerDtls", htparam);
                //Search criterion added by rachana end                
                dsDtls.DataSetName = "RepeaterTracker";

                ReportDataSource Rptdtls = new ReportDataSource("RepeaterTracker", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\RepeaterTracker.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "RepeaterTracker.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region LIC Agent License Report
            else if (Request.QueryString["Type"] == "AgtLicReg")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetAgentLicReg", htparam);
                //Search criterion added by rachana end
                dsDtls.DataSetName = "AgentLicReg";

                ReportDataSource Rptdtls = new ReportDataSource("AgentLicReg", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentLicReg.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentLicReg.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region LIC FEE Report
            else if (Request.QueryString["Type"] == "FEE")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetReportForFees", htparam);
                //Search criterion added by rachana end               
                dsDtls.DataSetName = "AgentFeesRecord";

                ReportDataSource Rptdtls = new ReportDataSource("AgentFeesRecord", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;

                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentFeesRecord.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentFeesRecord.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region LIC Composite Report
            else if (Request.QueryString["Type"] == "Composite")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetCompositeDtls", htparam);
                //Search criterion added by rachana end

                dsDtls.DataSetName = "Composite";

                ReportDataSource Rptdtls = new ReportDataSource("Composite", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\Composite.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "Composite.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region LIC Renewal Report
            else if (Request.QueryString["Type"] == "Renewal")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                dsDtls = objCon.GetDataSetForPrcRecruits("prc_getReportRenewal", htparam);
                //Search criterion added by rachana end
                dsDtls.DataSetName = "RenewalRecord";

                ReportDataSource Rptdtls = new ReportDataSource("RenewalRecord", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\RenewalReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "RenewalReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region SPOC Enrollment Normal Report
            else if (Request.QueryString["Type"] == "SpocEnroll")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                if (ViewState["UserType"].ToString() == "E")
                {
                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                    //htparam.Add("@MemberCode", System.DBNull.Value);
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternal", htparam);
                }
                else
                {
                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTracker", htparam);
                }

                //Search criterion added by rachana end
                dsDtls.DataSetName = "MISEnroll";

                ReportDataSource Rptdtls = new ReportDataSource("MISEnroll", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnroll.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region Spocs Enrollment Repeater Report
            else if (Request.QueryString["Type"] == "SpocEnrollRE")
            {
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }

                if (ViewState["UserType"].ToString() == "E")
                {
                    //htparam.Add("@MemberCode", System.DBNull.Value);
                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternalRE", htparam);
                }
                else
                {
                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerRE", htparam);
                }

                //Search criterion added by rachana end
                dsDtls.DataSetName = "MISEnrollRE";

                ReportDataSource Rptdtls = new ReportDataSource("MISEnrollRE", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnrollRE.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region Spocs Enrollment Renewal Report
            else if (Request.QueryString["Type"] == "SpocEnrollRW")
            {
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }

                if (ViewState["UserType"].ToString() == "E")
                {
                    //htparam.Add("@MemberCode", System.DBNull.Value);
                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternalRW", htparam);
                }
                else
                {
                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerRW", htparam);
                }

                //Search criterion added by rachana end
                dsDtls.DataSetName = "MISEnrollRW";

                ReportDataSource Rptdtls = new ReportDataSource("MISEnrollRW", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnrollRW.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion
            #region Spocs Exam Report
            else if (Request.QueryString["Type"] == "SpocExam")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                if (ViewState["UserType"].ToString() == "E")
                {
                    // htparam.Add("@MemberCode", System.DBNull.Value);
                    htparam.Add("@MemberCode", Session["UserID"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISExamTrackerExternal", htparam);
                }
                else
                {
                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISExamTracker", htparam);
                }

                //Search criterion added by rachana end     

                ReportDataSource Rptdtls = new ReportDataSource("MISExam", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISExam.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISExam.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }

            }
            #endregion
            #region SPOCS CFR Report
            else if (Request.QueryString["Type"] == "SpocCFR")
            {
                //Search criterion added by rachana start 
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //if (ViewState["UserType"].ToString() == "E")
                //{
                //    htparam.Add("@MemberCode", System.DBNull.Value);
                //    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRTrackerExternal", htparam);
                //}
                //else
                //{
                //    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                //    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRTracker", htparam);
                //}

                //Search criterion added by rachana end
                //Added by Nikhil on 04.05.2015
                htparam.Add("@userId", Session["UserID"].ToString().Trim());
                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRSPOCTracker", htparam);
                //Ended by NIKhil on 04.05.2015
                dsDtls.DataSetName = "MISCFR";

                ReportDataSource Rptdtls = new ReportDataSource("MISCFR", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISCFR.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISCFR.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }
            }
            #endregion

            //Added by meena  on 22.02.2017
            #region mobile Usage Report
            if (Request.QueryString["Type"] == "mobusgRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetmobCountTracker", htparam);
                dsDtls.DataSetName = "MobileUsage";
                ViewState["csv"] = dsDtls;

                ReportDataSource RptDtls = new ReportDataSource("MobileUsage", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MobileUsage.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "MobileUsage.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();

                    // btncsv.Visible = true;

                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            //ended by meena 
            //Added by Usha  on 10.08.2017
            #region Agent Profile Report
            if (Request.QueryString["Type"] == "AgentProfileRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_AgentProfileReport", htparam);
                dsDtls.DataSetName = "AgentProfileReport";


                ReportDataSource RptDtls = new ReportDataSource("AgentProfileReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentProfileReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentProfileReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            //ended by usha 
            //Added by Usha  on 10.08.2017
            #region  AgntT20Rpt Report
            if (Request.QueryString["Type"] == "AgntT20Rpt")
            {
                if (ddlDate.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Date Type')", true);
                    return;
                }
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                htparam.Add("@DateType", ddlDate.SelectedValue.ToString());
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_T20AgentsurveyReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "T20AgentSurveyReport";


                ReportDataSource RptDtls = new ReportDataSource("T20AgentSurveyReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\T20AgentSurveyReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "T20AgentSurveyReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  AgntT90Rpt Report
            if (Request.QueryString["Type"] == "AgntT90Rpt")
            {
                if (ddlDate.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Date Type')", true);
                    return;
                }
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 
                htparam.Add("@DateType", ddlDate.SelectedValue.ToString());
                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_T90AgentsurveyReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "T90Agentsurvey";


                ReportDataSource RptDtls = new ReportDataSource("T90AgentSurveyreport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\T90 AgentSurveyReport .rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "T90 AgentSurveyReport .rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  Inactive Agnt Report
            if (Request.QueryString["Type"] == "AgntInactiveRpt")
            {
                if (ddlDate.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Date Type')", true);
                    return;
                }
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 
                htparam.Add("@DateType", ddlDate.SelectedValue.ToString());
                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetInactiveAgentsReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "InActiveAgentSurvey";


                ReportDataSource RptDtls = new ReportDataSource("InActiveAgentSurvey", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\InActiveAgentSurvey.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "InActiveAgentSurvey.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  WIP Agnt Report
            if (Request.QueryString["Type"] == "AgntWIPSurveyRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_WIPAgentSurveyReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "WIPReport";


                ReportDataSource RptDtls = new ReportDataSource("WIPReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\WIPAgentSurveyReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "WIPAgentSurveyReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  Verification Calling Report
            if (Request.QueryString["Type"] == "AgntVerificationSurveyRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_VerificationCallingReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "VerificationCallingReport";


                ReportDataSource RptDtls = new ReportDataSource("VerificationCallingReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\VerificationCallingReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "VerificationCallingReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  Productivity Report Agnt Report
            if (Request.QueryString["Type"] == "AgntProdctiSurveyRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetAgentSurveyProductivityReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "AgentSurveyProductivity";


                ReportDataSource RptDtls = new ReportDataSource("AgentSurveyProductivity", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentSurveyProductivity.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentSurveyProductivity.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            #region  SM BM Updation  Report Agnt Report
            if (Request.QueryString["Type"] == "AgntSMUpdationSurveyRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_SMBMUpdationReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "SMBMUpdationReport";


                ReportDataSource RptDtls = new ReportDataSource("SMBMUpdationReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\SMBMUpdationReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "SMBMUpdationReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion

            #region Mail SMS Report Agnt Report
            if (Request.QueryString["Type"] == "AgntSMSSurveyRpt")
            {
                //Added by usha for date range on 08.05.15
                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                //ended by usha 

                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetAgentSurveyMAilSMSReport", htparam, "INSCCommonConnectionString");

                dsDtls.DataSetName = "AgentSurveyMailSMSReport";


                ReportDataSource RptDtls = new ReportDataSource("AgentSurveyMailSMSReport", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentSurveyMailSMSReport.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentSurveyMailSMSReport.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
                    RptVwReport.LocalReport.Refresh();



                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                }
            }
            #endregion
            //ended by usha 

            //Added by usha for Franchisee Enrollment report on 13.01.2021
            #region  Franchisee Enrollment   Report
            else if (Request.QueryString["Type"] == "FPEnrollmentRpt")
            {

                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
                htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                // dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMemberTrackerDtls", htparam);
                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetMemberTrackerDtls", htparam, "INSCCommonConnectionString");

                //Search criterion added by rachana end

                dsDtls.DataSetName = "FranchiseTracker";

                ReportDataSource Rptdtls = new ReportDataSource("FranchiseTracker", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\FranchiseTracker.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "FranchiseTracker.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }

            }
            #endregion
            //end 
            //Added by usha for HNIN Commission  report on 13_06_2023
            #region  Franchisee Enrollment   Report
            else if (Request.QueryString["Type"] == "CommPaymntRpt")
            {

                if (txtrptDtfrmval.Text.Trim() != "")
                {
                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtFrom", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htparam.Add("@DtTo", System.DBNull.Value);
                }
              //  htparam.Add("@UserId", Session["UserID"].ToString().Trim());
                // dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMemberTrackerDtls", htparam);
                dsDtls = objCon.GetDataSetForPrcDBConn("Prc_HninReport", htparam, "INSCCommonConnectionString");

                //Search criterion added by rachana end

                dsDtls.DataSetName = "HNINCommission";

                ReportDataSource Rptdtls = new ReportDataSource("HNINCommission", dsDtls.Tables[0].DefaultView);

                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    pnlRpt.Visible = true;
                    RptVwReport.Visible = true;
                    RptVwReport.LocalReport.ReportPath = @"Application\Report\HNINCommission.rdlc";
                    RptVwReport.LocalReport.ReportEmbeddedResource = "HNINCommission.rdlc";

                    RptVwReport.LocalReport.DataSources.Clear();
                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    RptVwReport.LocalReport.Refresh();
                }
                else
                {
                    pnlRpt.Visible = false;
                    RptVwReport.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                }

            }
            #endregion
            //end 
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
    private void ddlProcessType1()
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();

            htParam.Add("@Flag", "2");
            dsComp = objCon.GetDataSetForPrcRecruits("Prc_GetNewProcessType", htParam);


            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddlProcessType.DataSource = dsComp;
                ddlProcessType.DataTextField = "Name";
                ddlProcessType.DataValueField = "Name";
                ddlProcessType.DataBind();
                ddlProcessType.Items.Insert(0, "--Select--");
            }

            //ended by nikhil on 9.6.15
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
    private void GetAgentandUserDtls()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
                    ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
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
//    DataSet dsDtls = new DataSet();
//    DataTable dtResult = new DataTable();
//    Hashtable htparam = new Hashtable();
//    DataAccessClass objCon = new DataAccessClass();
//    ErrLog objErr = new ErrLog();
//    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        try
//        {
//            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
//            {
//                Response.Redirect("~/ErrorSession.aspx");
//            }
//            if (!IsPostBack)
//            {
//                GetAgentandUserDtls();
//                if (Request.QueryString["Type"] == "NSE")
//                {
//                    lbltitle.Text = "NSE Report Search";
//                }
//                else if (Request.QueryString["Type"] == "AgtIn")
//                {
//                    lbltitle.Text = "Agent In Force Report Search";
//                    trAll.Visible = false;
//                    TrA.Visible = true;
//                    lblError2.Visible = true;
//                    txtrptDttoval.Visible = false;
//                    lblA.Visible = false;
//                    lblprtDtto.Visible = false;
//                    txtrptDtfrmvalA.Visible = false;
//                }
//                else if (Request.QueryString["Type"] == "AgtTrckr")
//                {
//                    trAll.Visible = true;
//                    lbltitle.Text = "Enrollment Tracker Report Search";
//                }
//                else if (Request.QueryString["Type"] == "RptTrckr")
//                {
//                    lbltitle.Text = "Repeater Tracker Report Search";
//                }
//                else if (Request.QueryString["Type"] == "AgtLicReg")
//                {
//                    lbltitle.Text = "Agent License Registration Report Search";
//                }
//                else if (Request.QueryString["Type"] == "FEE")
//                {
//                    lbltitle.Text = "Candidate Fees Tracker Report Search";
//                }
//                else if (Request.QueryString["Type"] == "Composite")
//                {
//                    lbltitle.Text = "Composite Tracker Report Search";
//                }
//                else if (Request.QueryString["Type"] == "Renewal")
//                {
//                    lbltitle.Text = "Renewal Tracker Report Search";
//                }
//                else if (Request.QueryString["Type"] == "SpocEnroll")
//                {
//                    lbltitle.Text = "ARTL Report";
//                    trAll.Visible = true;
//                    TrA.Visible = false;
//                }
//                else if (Request.QueryString["Type"] == "SpocEnrollRE")
//                {
//                    lbltitle.Text = "ARTL Repeater Report";
//                    trAll.Visible = true;
//                    TrA.Visible = false;
//                }
//                else if (Request.QueryString["Type"] == "SpocEnrollRW")
//                {
//                    lbltitle.Text = "ARTL Renewal Report";
//                    trAll.Visible = true;
//                    TrA.Visible = false;
//                }
//                else if (Request.QueryString["Type"] == "SpocExam")
//                {
//                    lbltitle.Text = "Spocs Exam Report";
//                }
//                else if (Request.QueryString["Type"] == "SpocCFR")
//                {
//                    lbltitle.Text = "Spocs CFR Report";
//                }
//                 //Added by Nikhil for exam report on 30.4.15
//                else  if (Request.QueryString["Type"] == "ExmRpt")
//                {
                    
//                    lbltitle.Text = "Exam Report ";
//                    trAll.Visible = true;
//                }
//                else if (Request.QueryString["Type"] == "CFRRaiseRpt")
//                {
//                   // trProcessType.Attributes.Add("style", "display:block");
//                    trProcessType.Visible = true;
//                    ddlProcessType1();
//                    lbltitle.Text = "CFR Raise Report ";
//                    trAll.Visible = true;
//                }
//                //Ended by Nikhil on 30.4.15
////added by usha  on 01.10.2015
//                else if (Request.QueryString["Type"] == "updagent")
//                {
//                    lbltitle.Text = "NOC Report";
//                    trAll.Visible = true;
//                }
//                //ended  by usha  on 01.10.2015
//              // Added by usha for fees waiver tracker on 19.01.2016
//                else if (Request.QueryString["Type"] == "feestrckr")
//                {
//                    lbltitle.Text = "Fees Waiver Report";
//                    trAll.Visible=true;
//                }
//                //ended by usha  for fees waiver tracker on 19.01.2016
//                else if (Request.QueryString["Type"] == "GSTRprt")
//                {
//                    lbltitle.Text = "GST Report";
//                    trAll.Visible = true;
//                    btnSearch.Visible = false;
//                    btnExport.Visible = true;
//                }
//            }
//            //txtrptDtfrmval.Attributes.Add("readonly", "readonly"); //commented by sanoj
//            //txtrptDttoval.Attributes.Add("readonly", "readonly");
//           // txtrptDtfrmvalA.Attributes.Add("readonly", "readonly");
//        }
//        catch (Exception ex)
//        {
            
//             string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//    }
//    protected void btnSearch_Click(object sender, EventArgs e) 
//    {

//        try
//        {
//            Label1.Text = "Report Data( "+lbltitle.Text+" )";
//            dsDtls.Clear();
//            htparam.Clear();
//            LocalReport Report = new LocalReport();
//            //added by usha for fees waiver report on 19.01.2016
//            #region fees waiver report
//            if (Request.QueryString["Type"] == "feestrckr")
//            {
//                //Added by usha for date range on 08.05.15
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                //ended by usha 

//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_feeswaivertracker", htparam);
//                dsDtls.DataSetName = "FeesWaiver";

//                ReportDataSource RptDtls = new ReportDataSource("FeesWaiver", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\FeesWaiver.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "FeesWaiver.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }


//            }

//            #endregion
//          //  ended by usha 
//            //Added by usha  on 01.10.2015
//            #region NOC Report
//            if (Request.QueryString["Type"] == "updagent")
//            {
//                //Added by usha for date range on 08.05.15
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                //ended by usha 

//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_UpdateNOCTrckr", htparam);
//                dsDtls.DataSetName = "UpdateNOCAgency";

//                ReportDataSource RptDtls = new ReportDataSource("UpdateNOCAgency", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\UpdateNOCAgency.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "UpdateNOCAgency.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }


//            }
//            #endregion
//            //ended by usha 
//            //Added by Nikhil for exam report details on 30.4.15
//            #region Exam Report
//            if (Request.QueryString["Type"] == "ExmRpt")
//            {
//                //Added by usha for date range on 08.05.15
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                //ended by usha 
//                htparam.Add("@UserId", Session["UserID"].ToString().Trim());
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_ExamDateReport",htparam);
//                dsDtls.DataSetName = "ExmRpt";

//                ReportDataSource RptDtls = new ReportDataSource("ExmRpt", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\ExmRpt.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "ExmRpt.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                    RptVwReport.LocalReport.Refresh();
                   
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }


//            }
//            #endregion
//            #region CFR Raise Report
//            if (Request.QueryString["Type"] == "CFRRaiseRpt")
//            {
//                if (ddlProcessType.SelectedValue == "Select" && txtrptDtfrmval.Text != "" && txtrptDttoval.Text != "")
//                {
//                    lblman.Visible = true;
//                }
//                else
//                {

//                    lblman.Visible = false;
//                    //Added by Nikhil for date range on 08.05.15
//                    if (txtrptDtfrmval.Text.Trim() != "")
//                    {
//                        htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                    }
//                    else
//                    {
//                        htparam.Add("@DtFrom", System.DBNull.Value);
//                    }
//                    if (txtrptDttoval.Text.Trim() != "")
//                    {
//                        htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                    }
//                    else
//                    {
//                        htparam.Add("@DtTo", System.DBNull.Value);
//                    }
//                    if (ddlProcessType.SelectedValue != "")
//                    {
//                        if (ddlProcessType.SelectedValue == "Reterival")
//                        {
//                            htparam.Add("@ProcessType", "RW");

//                        }
//                        else if (ddlProcessType.SelectedValue == "Repeater")
//                        {
//                            htparam.Add("@ProcessType", "RE");

//                        }
//                        else if (ddlProcessType.SelectedValue == "NOC")
//                        {
//                            htparam.Add("@ProcessType", "NC");

//                        }
//                        else
//                        {
//                            htparam.Add("@ProcessType", "NR");
//                        }
//                    }
//                    //ended by Nikhil 

//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetCFRRaiseRpt", htparam);
//                    dsDtls.DataSetName = "CFRRaiseRpt";

//                    ReportDataSource RptDtls = new ReportDataSource("CFRRaiseRpt", dsDtls.Tables[0].DefaultView);

//                    if (dsDtls.Tables[0].Rows.Count > 0)
//                    {
//                        lblMessage.Visible = false;
//                        Div2.Visible = true;
//                        RptVwReport.Visible = true;
//                        RptVwReport.LocalReport.ReportPath = @"Application\Report\CFRRaiseRpt.rdlc";
//                        RptVwReport.LocalReport.ReportEmbeddedResource = "CFRRaiseRpt.rdlc";

//                        RptVwReport.LocalReport.DataSources.Clear();
//                        RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                        RptVwReport.LocalReport.Refresh();
//                    }
//                    else
//                    {
//                        Div2.Visible = false;
//                        RptVwReport.Visible = false;
//                        lblMessage.Visible = true;
//                        lblMessage.Text = "0 Record Found";

//                    }

//                }
//            }
//            #endregion
//            //Ended by Nikhil 
//            #region NSE Report
//            if (Request.QueryString["Type"] == "NSE")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("prc_NseReport", htparam);
//                //Search criterion added by rachana end
                
//                dsDtls.DataSetName = "NSE";

//                ReportDataSource RptDtls = new ReportDataSource("NSE", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\NSE.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "NSE.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }


//            }
//            #endregion
//            #region Agent In Force Report
//            else if (Request.QueryString["Type"] == "AgtIn")
//            {
//               // htparam.Add("@Flag", textReport.Text);
//                //dsDtls = objCon.GetDataSetForPrcDBConn("prc_getAgentInForce", htparam, "ARTLConnectionString");
                
//                //dsDtls = objCon.GetDataSetForPrc1("prc_getAgentInForce");
//                if (txtrptDtfrmvalA.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmvalA.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom",System.DBNull.Value);
//                }
//                //if (txtrptDttoval.Text.Trim() != "")
//                //{
//                //    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                //}
//                //else
//                //{
//                //    htparam.Add("@DtTo", System.DBNull.Value);
//                //}
//                //dsDtls = objCon.GetDataSetForPrcRecruits("prc_getAgentInForce", htparam);
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_getAgentinforceReport", htparam);
//                dsDtls.DataSetName = "Agent";

//                ReportDataSource RptDtls = new ReportDataSource("Agent", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentInForce.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentInForce.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(RptDtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }

//            }
//            #endregion
//            #region Enrollment Lic Report
//            else if (Request.QueryString["Type"] == "AgtTrckr")
//            {
//                //htparam.Add("@Flag", textReport.Text);

//                //dsDtls = objCon.GetDataSetForPrcDBConn("Prc_GetAgentTrackerDtls", htparam, "ARTLConnectionString");
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                htparam.Add("@UserId", Session["UserID"].ToString().Trim());
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetAgentTrackerDtls", htparam);
//                //Search criterion added by rachana end
               
//                dsDtls.DataSetName = "AgentTracker";

//                ReportDataSource Rptdtls = new ReportDataSource("AgentTracker", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentTracker.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentTracker.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }

//            }
//            #endregion
//            #region LIC Repeater Report
//            else if (Request.QueryString["Type"] == "RptTrckr")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_RepeaterTrackerDtls", htparam);
//                //Search criterion added by rachana end                
//                dsDtls.DataSetName = "RepeaterTracker";

//                ReportDataSource Rptdtls = new ReportDataSource("RepeaterTracker", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\RepeaterTracker.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "RepeaterTracker.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region LIC Agent License Report
//            else if (Request.QueryString["Type"] == "AgtLicReg")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetAgentLicReg", htparam);
//                //Search criterion added by rachana end
//                dsDtls.DataSetName = "AgentLicReg";

//                ReportDataSource Rptdtls = new ReportDataSource("AgentLicReg", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentLicReg.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentLicReg.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region LIC FEE Report
//            else if (Request.QueryString["Type"] == "FEE")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetReportForFees", htparam);
//                //Search criterion added by rachana end               
//                dsDtls.DataSetName = "AgentFeesRecord";

//                ReportDataSource Rptdtls = new ReportDataSource("AgentFeesRecord", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;                   

//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentFeesRecord.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "AgentFeesRecord.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region LIC Composite Report
//            else if (Request.QueryString["Type"] == "Composite")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetCompositeDtls", htparam);
//                //Search criterion added by rachana end
                
//                dsDtls.DataSetName = "Composite";

//                ReportDataSource Rptdtls = new ReportDataSource("Composite", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\Composite.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "Composite.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region LIC Renewal Report
//            else if (Request.QueryString["Type"] == "Renewal")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                dsDtls = objCon.GetDataSetForPrcRecruits("prc_getReportRenewal", htparam);
//                //Search criterion added by rachana end
//                dsDtls.DataSetName = "RenewalRecord";

//                ReportDataSource Rptdtls = new ReportDataSource("RenewalRecord", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\RenewalReport.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "RenewalReport.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region SPOC Enrollment Normal Report
//            else if (Request.QueryString["Type"] == "SpocEnroll")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                if (ViewState["UserType"].ToString() == "E")
//                {
//                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
//                    //htparam.Add("@MemberCode", System.DBNull.Value);
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternal", htparam);
//                }
//                else
//                {
//                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTracker", htparam);
//                }
                
//                //Search criterion added by rachana end
//                dsDtls.DataSetName = "MISEnroll";

//                ReportDataSource Rptdtls = new ReportDataSource("MISEnroll", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnroll.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region Spocs Enrollment Repeater Report
//            else if (Request.QueryString["Type"] == "SpocEnrollRE")
//            {
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
               
//                if (ViewState["UserType"].ToString() == "E")
//                {
//                    //htparam.Add("@MemberCode", System.DBNull.Value);
//                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternalRE", htparam);
//                }
//                else
//                {
//                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerRE", htparam);
//                }

//                //Search criterion added by rachana end
//                dsDtls.DataSetName = "MISEnrollRE";

//                ReportDataSource Rptdtls = new ReportDataSource("MISEnrollRE", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnrollRE.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region Spocs Enrollment Renewal Report
//            else if (Request.QueryString["Type"] == "SpocEnrollRW")
//            {
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }

//                if (ViewState["UserType"].ToString() == "E")
//                {
//                    //htparam.Add("@MemberCode", System.DBNull.Value);
//                    htparam.Add("@UserId", Session["UserID"].ToString().Trim());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerExternalRW", htparam);
//                }
//                else
//                {
//                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISEnrollmentTrackerRW", htparam);
//                }

//                //Search criterion added by rachana end
//                dsDtls.DataSetName = "MISEnrollRW";

//                ReportDataSource Rptdtls = new ReportDataSource("MISEnrollRW", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISEnrollRW.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISEnroll.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
//            #region Spocs Exam Report
//            else if (Request.QueryString["Type"] == "SpocExam")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                if (ViewState["UserType"].ToString() == "E")
//                {
//                    htparam.Add("@MemberCode", System.DBNull.Value);
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISExamTrackerExternal", htparam);
//                }
//                else
//                {
//                    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
//                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISExamTracker", htparam);
//                }

//                //Search criterion added by rachana end     

//                ReportDataSource Rptdtls = new ReportDataSource("MISExam", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISExam.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISExam.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }

//            }
//            #endregion
//            #region SPOCS CFR Report
//            else if (Request.QueryString["Type"] == "SpocCFR")
//            {
//                //Search criterion added by rachana start 
//                if (txtrptDtfrmval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtFrom", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtFrom", System.DBNull.Value);
//                }
//                if (txtrptDttoval.Text.Trim() != "")
//                {
//                    htparam.Add("@DtTo", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
//                }
//                else
//                {
//                    htparam.Add("@DtTo", System.DBNull.Value);
//                }
//                //if (ViewState["UserType"].ToString() == "E")
//                //{
//                //    htparam.Add("@MemberCode", System.DBNull.Value);
//                //    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRTrackerExternal", htparam);
//                //}
//                //else
//                //{
//                //    htparam.Add("@MemberCode", ViewState["MemberCode"].ToString());
//                //    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRTracker", htparam);
//                //}
                
//                //Search criterion added by rachana end
//                //Added by Nikhil on 04.05.2015
//                     htparam.Add("@userId", Session["UserID"].ToString().Trim());
//                dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetMISCFRSPOCTracker", htparam);
//                //Ended by NIKhil on 04.05.2015
//                dsDtls.DataSetName = "MISCFR";

//                ReportDataSource Rptdtls = new ReportDataSource("MISCFR", dsDtls.Tables[0].DefaultView);

//                if (dsDtls.Tables[0].Rows.Count > 0)
//                {
//                    lblMessage.Visible = false;
//                    Div2.Visible = true;
//                    RptVwReport.Visible = true;
//                    RptVwReport.LocalReport.ReportPath = @"Application\Report\MISCFR.rdlc";
//                    RptVwReport.LocalReport.ReportEmbeddedResource = "MISCFR.rdlc";

//                    RptVwReport.LocalReport.DataSources.Clear();
//                    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
//                    RptVwReport.LocalReport.Refresh();
//                }
//                else
//                {
//                    Div2.Visible = false;
//                    RptVwReport.Visible = false;
//                    lblMessage.Visible = true;
//                    lblMessage.Text = "0 Record Found";

//                }
//            }
//            #endregion
            
//        }
//        catch (Exception ex)
//        {

//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }


//    }
//    private void ddlProcessType1()
//    {
//        try
//        {

//            //added by nikhil on 9.6.15
//            Hashtable htParam = new Hashtable();
//            DataSet dsComp = new DataSet();

//            htParam.Add("@Flag", "2");
//            dsComp = objCon.GetDataSetForPrcRecruits("Prc_GetNewProcessType", htParam);


//            if (dsComp.Tables[0].Rows.Count > 0)
//            {
//                ddlProcessType.DataSource = dsComp;
//                ddlProcessType.DataTextField = "Name";
//                ddlProcessType.DataValueField = "Name";
//                ddlProcessType.DataBind();
//                ddlProcessType.Items.Insert(0, "Select");
//            }

//            //ended by nikhil on 9.6.15
//        }
//        catch (Exception ex)
//        {
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//    }
//    private void GetAgentandUserDtls()
//    {
//        try
//        {
//            DataSet dsAgent = new DataSet();
//            dsAgent = oCommonUtility.GetUserDtls(HttpContext.Current.Session["UserID"].ToString().Trim());

//            if (dsAgent.Tables.Count > 0)
//            {
//                if (dsAgent.Tables[0].Rows.Count > 0)
//                {
//                    ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
//                    ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

//                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
//                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
//                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
//                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
//                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
//                }
//            }

//        }
//        catch (Exception ex)
//        {

//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//    }

    //Added By Pratik For Excel  download
    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DateTime startDate = Convert.ToDateTime(txtrptDtfrmval.Text);
    //        DateTime endDate = Convert.ToDateTime(txtrptDttoval.Text);

    //        Warning[] warnings;
    //        string[] streams;
    //        string MIMETYPE = string.Empty;
    //        string encoding = string.Empty;
    //        string extension = string.Empty;

    //        if (startDate > endDate)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Start Ddate cannot be greater than end date.')", true);
    //            return;
    //        }

    //        Hashtable htparam = new Hashtable();
    //        htparam.Clear();
    //        htparam.Add("@startDt", txtrptDtfrmval.Text.Replace('/', '-'));
    //        htparam.Add("@endDt", txtrptDttoval.Text.Replace('/', '-'));
    //        DataSet dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetGstReport", htparam);
    //        if (dsDtls.Tables[0].Rows.Count > 0)
    //        {
    //            dsDtls.DataSetName = "GST_DataSet";
    //            ReportDataSource RptDtls = new ReportDataSource("GST_Dataset", dsDtls.Tables[0].DefaultView);

    //            RptVwReport.LocalReport.ReportPath = @"Application\Report\GST_MonthlyReport.rdlc";
    //            RptVwReport.LocalReport.ReportEmbeddedResource = "GST_MonthlyReport.rdlc";

    //            RptVwReport.LocalReport.DataSources.Clear();
    //            RptVwReport.LocalReport.DataSources.Add(RptDtls);
    //            RptVwReport.LocalReport.Refresh();
    //            string FileName = "GST Report " + txtrptDtfrmval.Text + "-" + txtrptDttoval.Text; 

    //            byte[] bytes = RptVwReport.LocalReport.Render("Excel", null, out MIMETYPE, out encoding, out extension, out streams, out warnings);
    //            Response.Buffer = true;
    //            Response.Clear();
    //            Response.ContentType = MIMETYPE;
    //            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + "." + extension);
    //            Response.BinaryWrite(bytes);
    //            Response.Flush();
    //            Response.Close();
    //        }
    //        else
    //        {
    //            lblMessage.Visible = true;
    //            lblMessage.Text = "No record Found.";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}
    
}
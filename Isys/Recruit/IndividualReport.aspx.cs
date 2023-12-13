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
using System.Reflection;



public partial class Application_ISys_Recruit_IndividualReport : System.Web.UI.Page
{
    DataSet dsDtls = new DataSet();
    DataTable dtResult = new DataTable();
    Hashtable htparam = new Hashtable();
    DataAccessClass objCon = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Type"] == "IndvReprt")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetIndividualLtr", htparam);
                    dsDtls.DataSetName = "IndividualLtr";

                    ReportDataSource Rptdtls = new ReportDataSource("IndividualLtr", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\IndividualLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "IndividualLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "TrnsfrReprt")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetIndividualLtr", htparam);
                    dsDtls.DataSetName = "IndividualLtr";

                    ReportDataSource Rptdtls = new ReportDataSource("IndividualLtr", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\TransferLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "TransferLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "CompReprt")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetIndividualLtr", htparam);
                    dsDtls.DataSetName = "IndividualLtr";

                    ReportDataSource Rptdtls = new ReportDataSource("IndividualLtr", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\CompositeLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "CompositeLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "RnwlReprt")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetIndividualLtr", htparam);
                    dsDtls.DataSetName = "IndividualLtr";

                    ReportDataSource Rptdtls = new ReportDataSource("IndividualLtr", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\RenewalLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "RenewalLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }


                }

                //added by Nikhil for License & ID Download on 18042015---start
                else if (Request.QueryString["Type"] == "License")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    //dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppltr", htparam);
                    //dsDtls.DataSetName = "DirectAppointment";
                    //htparam.Add("@CndNo", "30036256");
                    dsDtls = objCon.GetDataSetForPrcRecruits("Prc_GetAutoFormData", htparam);
                    dsDtls.DataSetName = "POSPAppointment";

                    ReportDataSource Rptdtls = new ReportDataSource("POSPAppointment", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\POSPAppointment.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "POSPAppointment.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    //htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    //dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppltr", htparam);
                    //dsDtls.DataSetName = "DirectAppointment";

                    //ReportDataSource Rptdtls = new ReportDataSource("DirectAppointment", dsDtls.Tables[0].DefaultView);

                    //if (dsDtls.Tables[0].Rows.Count > 0)
                    //{
                    //    pnlRpt.Visible = true;
                    //    RptVwReport.Visible = true;
                    //    RptVwReport.LocalReport.ReportPath = @"Application\Report\DirectAppointment.rdlc";
                    //    RptVwReport.LocalReport.ReportEmbeddedResource = "DirectAppointment.rdlc";
                    //    DisableUnwantedExportFormat(RptVwReport, "Excel");
                    //    RptVwReport.LocalReport.DataSources.Clear();
                    //    RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                    //    RptVwReport.LocalReport.Refresh();
                    //}
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "ID")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAgtId ", htparam);
                    dsDtls.DataSetName = "AgentID";

                    ReportDataSource Rptdtls = new ReportDataSource("AgentID", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\AgentID.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "AgentID.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;
                      
                    }
                }
                //added by Nikhil on 18042015---end
                             //added by usha on 1.09.015---end

                else if (Request.QueryString["Type"] == "NOC")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetNOCIC ", htparam);
                    dsDtls.DataSetName = "NOCIC";

                    ReportDataSource Rptdtls = new ReportDataSource("NOCIC", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\NOCIC.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "NOCIC.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }

                else if (Request.QueryString["Type"] == "FPWelcmLttr")
                {
                    htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcCLP("prc_GetFPWelcomeLetter ", htparam);
                    dsDtls.DataSetName = "FPWelcomeLetter";

                    ReportDataSource Rptdtls = new ReportDataSource("FPWelcomeLetter", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\FPWelcomeLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "FPWelcomeLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                //added by Nikhil on 31082015---end
                else if (Request.QueryString["Type"] == "PospAppointment")
                {

                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    // dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppointPOSP", htparam);
                    dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppltrForPOSP", htparam);
                    dsDtls.DataSetName = "Posp_Ds1";

                    ReportDataSource Rptdtls = new ReportDataSource("Posp_Ds1", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\pospApp.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "pospApp.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "POSPNOCIC")
                {
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetPOSPNOCIC ", htparam);
                    dsDtls.DataSetName = "NOCIC";

                    ReportDataSource Rptdtls = new ReportDataSource("POSPNOCIC", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\POSPNOCIC.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "POSPNOCIC.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }
                else if (Request.QueryString["Type"] == "FPWelcmLttr")
                {
                    //divbutton.Attributes.Add("style", "display:block");//Added by Amit
                    htparam.Add("@Memcode", Request.QueryString["MemCode"].ToString().Trim());
                    dsDtls = objCon.GetDataSetForPrcCLP("prc_GetFPWelcomeLetter", htparam);
                    dsDtls.DataSetName = "FPWelcomeLetter";

                    ReportDataSource Rptdtls = new ReportDataSource("FPWelcomeLetter", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                      
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\FPWelcomeLetter.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "FPWelcomeLetter.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

                    }
                }

                 //added by Usha on 28082023---end
                else if (Request.QueryString["Type"] == "MISPLicCpy")
                {

                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    // dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppointPOSP", htparam);
                    dsDtls = objCon.GetDataSetForPrcRecruits("prc_GetAppltrForMISP", htparam);
                    dsDtls.DataSetName = "MISPAppointment";

                    ReportDataSource Rptdtls = new ReportDataSource("MISPAppointment", dsDtls.Tables[0].DefaultView);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        pnlRpt.Visible = true;
                        RptVwReport.Visible = true;
                        RptVwReport.LocalReport.ReportPath = @"Application\Report\MISPAppointment.rdlc";
                        RptVwReport.LocalReport.ReportEmbeddedResource = "MISPAppointment.rdlc";
                        DisableUnwantedExportFormat(RptVwReport, "Excel");
                        RptVwReport.LocalReport.DataSources.Clear();
                        RptVwReport.LocalReport.DataSources.Add(Rptdtls);
                        RptVwReport.LocalReport.Refresh();
                    }
                    else
                    {
                        pnlRpt.Visible = false;
                        RptVwReport.Visible = false;

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
    }
    public void DisableUnwantedExportFormat(ReportViewer ReportViewerID, string strFormatName)
    {
        FieldInfo info;

        foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
        {
            if (extension.Name == strFormatName)
            {
                info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                info.SetValue(extension, false);
            }
        }
    }
}
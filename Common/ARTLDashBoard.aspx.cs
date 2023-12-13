#region NAMESPACE
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
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using Insc.Common.Multilingual;
using INSCL.DAL;
using DataAccessClassDAL;
using System.Web.Script.Serialization;
using System.Xml;
using CLTMGR;
using System.Drawing;
using System.Collections.Generic;
#endregion 

public partial class Application_Common_ARTLDashBoard : BaseClass
{

    #region DECLARATION
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    private string strUserLang;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Get and set Session values
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (HttpContext.Current.Session["UserLangNum"] != "")
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        }
        Session["CarrierCode"] = "2";
        #endregion

        if (!IsPostBack)
        {
            FillDashBoardCount();
            FillChart();
        }
    }
    #endregion

    #region FillDashBoardCount
    public void FillDashBoardCount()
    {
        try
        {
            Hashtable htagt = new Hashtable();
            DataSet dsagt = new DataSet();
            dsagt.Clear();
            htagt.Clear();
            dsagt = objDAL.GetDataSetForPrcRec("prc_GetARTLDashBoardDtls", htagt);

            if (dsagt.Tables.Count > 0 && dsagt.Tables[0].Rows.Count > 0)
            {
                lblCndCnt.Text = "2677"; //dsagt.Tables[0].Rows[0]["CndCnt"].ToString().Trim();
                lblAgntCnt.Text = "18954";//dsagt.Tables[0].Rows[0]["AgnCnt"].ToString().Trim();
                lblRenwlsCnt.Text = "246"; //dsagt.Tables[0].Rows[0]["RptrCnt"].ToString().Trim();
                lblRpterCnt.Text = "33"; // dsagt.Tables[0].Rows[0]["RnwlCnt"].ToString().Trim();
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

    public void FillChart()
    {
        try
        {
            #region Chart  Lic Agents Till Date 
            //dsResult.Clear();
            //htParam.Clear();
            //htParam.Add("@flag", "6");
            //dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);
            //ChartLicAgentsTillDate.DataSource = dsResult.Tables[0];

            //ChartLicAgentsTillDate.DataBindCrossTable(dsResult.Tables[0].Rows, "Type", "StatusDesc01", "CandidateCount", "");

            string[] xAxis = { "Registered", "Pending QC", "Suspended", "Slot Alocated", "Examined", "Licensed" };
            double[] YAxis = { 1800, 442, 289, 968, 854, 1654 };

            ChartLicAgentsTillDate.Series[0].Points.DataBindXY(xAxis, YAxis);
            ChartLicAgentsTillDate.Series[0].Points[0].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#CC0000"));
            ChartLicAgentsTillDate.Series[0].Points[1].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#99FF00"));
            ChartLicAgentsTillDate.Series[0].Points[2].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#FFCC00"));
            ChartLicAgentsTillDate.Series[0].Points[3].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#3333FF"));
            ChartLicAgentsTillDate.Series[0].Points[4].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#FF33FF"));
            ChartLicAgentsTillDate.Series[0].Points[5].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#FF0033"));

            ChartLicAgentsTillDate.Series[0].IsValueShownAsLabel = false;

            //ChartLicAgentsTillDate.Series[1].IsValueShownAsLabel = true;
            

            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            ChartLicAgentsTillDate.Series[0].Color = Color.FromArgb(0, 123,66,21);
            ChartLicAgentsTillDate.Series[0]["PointWidth"] = "0.5";
            //ChartLicAgentsTillDate.Series[1]["PointWidth"] = "0.5";

            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].AxisX.Title = "Status";
            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].AxisY.Title = "Count";

            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //ChartLicAgentsTillDate.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -20;

            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].ShadowColor = Color.White;
            ChartLicAgentsTillDate.ChartAreas["ChartArea1"].BackColor = Color.White;

            //ChartLicAgentsTillDate.ChartAreas["ChartArea1"].AxisY.Interval = 20;
            #endregion
            #region Chart Lic Agent Current year
            //dsResult.Clear();
            //htParam.Clear();
            //htParam.Add("@flag", "7");
            //dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);
            //ChartLicAgentCurrent.DataSource = dsResult.Tables[0];

            //ChartLicAgentCurrent.DataBindCrossTable(dsResult.Tables[0].Rows, "Type", "Month", "CandidateCount", "");

            string[] xAxis1 = { "April", "May", "June" };
            double[] YAxis1 = { 318 , 456, 880};

            ChartLicAgentCurrent.Series[0].Points.DataBindXY(xAxis1, YAxis1);
            ChartLicAgentCurrent.Series[0].Points[0].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#CC00FF"));
            ChartLicAgentCurrent.Series[0].Points[1].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#99CC00"));
            ChartLicAgentCurrent.Series[0].Points[2].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#FF9900"));
            
            

            ChartLicAgentCurrent.Series[0].IsValueShownAsLabel = false;
            //ChartLicAgentCurrent.Series[1].IsValueShownAsLabel = true;

            ChartLicAgentCurrent.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ChartLicAgentCurrent.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            
            ChartLicAgentCurrent.Series[0]["PointWidth"] = "0.5";
            //ChartLicAgentCurrent.ApplyPaletteColors();
            ChartLicAgentCurrent.Series[0].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#CC0000"));
            //ChartLicAgentCurrent.Series[1].Points[0].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#ff0000"));
            //ChartLicAgentCurrent.Series[2].Points[0].Color = Color.FromArgb(127, System.Drawing.ColorTranslator.FromHtml("#bb0000"));

            ChartLicAgentCurrent.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            ChartLicAgentCurrent.ChartAreas["ChartArea1"].AxisY.Title = "Count";

            ChartLicAgentCurrent.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //ChartLicAgentCurrent.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -20;

            //ChartLicAgentCurrent.ChartAreas["ChartArea1"].ShadowColor = Color.White;
            //ChartLicAgentCurrent.ChartAreas["ChartArea1"].BackColor = Color.White;

            //ChartLicAgentCurrent.ChartAreas["ChartArea1"].AxisY.Interval = 20;
            #endregion
            #region Conversion Report

            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@flag", "11");
            dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);
            //dsResult = objDAL.GetDataSetForPrcRecruit("Prc_GetConversionCount");
            gv_CndCountRatio.DataSource = dsResult;
            gv_CndCountRatio.DataBind();


            #endregion
            #region Chart Cnd Count Monthly
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@flag", "10");
            dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);

            //Get the no of series first.. this will be a distinct series list..
            List<string> seriesList = new List<string>();
            foreach (DataRow row in dsResult.Tables[0].Rows)
            {
                string seriesName = row["Type"].ToString();
                if (!seriesList.Contains(seriesName))
                    seriesList.Add(seriesName);
            }
            //Now bind the xValues and yVlaues for each series
            foreach (string seriesName in seriesList)
            {
                List<string> xValues = new List<string>();
                List<int> yValues = new List<int>();

                foreach (DataRow row in dsResult.Tables[0].Rows)
                {
                    string xValue = row["Month"].ToString();
                    int yValue = Convert.ToInt32(row["CandidateCount"]);
                    string sName = row["Type"].ToString();

                    if (sName == seriesName)
                    {
                        xValues.Add(xValue);
                        yValues.Add(yValue);
                    }
                }
                ChartCndCountMonthly.Series.Add(seriesName);
                ChartCndCountMonthly.Series[seriesName].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                ChartCndCountMonthly.Series[seriesName].ChartArea = "ChartArea1";
                //ChartCndCountMonthly.Series[seriesName].Legend = "Legend1";
                //ChartCndCountMonthly.Series[seriesName].LegendText = seriesName;
                ChartCndCountMonthly.Series[seriesName].Points.DataBindXY(xValues, yValues);

                for (int i = 0; i < yValues.Count; i++)
                {
                    ChartCndCountMonthly.Series[seriesName].Points[i].ToolTip = yValues[i].ToString();
                }

            }
            //ChartCndCountMonthly.ChartAreas["ChartArea1"].AxisY.Interval = 5000;
            ChartCndCountMonthly.Series[0].Color = System.Drawing.Color.Red;
            ChartCndCountMonthly.Series[1].Color = System.Drawing.Color.Blue;

            ChartCndCountMonthly.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //YearwiseCND.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            #endregion
            #region Chart Pending Renewal month wise
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@flag", "8");
            dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);
            ChartPendingRenewal.DataSource = dsResult.Tables[0];

            ChartPendingRenewal.DataBindCrossTable(dsResult.Tables[0].Rows, "Type", "Month", "CandidateCount", "");
            ChartPendingRenewal.Series[0].IsValueShownAsLabel = true;
            //ChartPendingRenewal.Series[1].IsValueShownAsLabel = true;

            ChartPendingRenewal.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ChartPendingRenewal.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            ChartPendingRenewal.Series[0]["PointWidth"] = "0.5";
            //ChartPendingRenewal.Series[1]["PointWidth"] = "0.5";

            ChartPendingRenewal.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            ChartPendingRenewal.ChartAreas["ChartArea1"].AxisY.Title = "Count";

            ChartPendingRenewal.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //ChartPendingRenewal.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -20;

            ChartPendingRenewal.ChartAreas["ChartArea1"].ShadowColor = Color.White;
            ChartPendingRenewal.ChartAreas["ChartArea1"].BackColor = Color.White;

            //ChartPendingRenewal.ChartAreas["ChartArea1"].AxisY.Interval = 20;
            #endregion
            #region Chart Missed Renewal month wise
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@flag", "9");
            dsResult = objDAL.GetDataSetForPrcRec("prc_GetARTLChartsDtls", htParam);
            ChartMissedRenewal.DataSource = dsResult.Tables[0];

            ChartMissedRenewal.DataBindCrossTable(dsResult.Tables[0].Rows, "Type", "Month", "CandidateCount", "");
            ChartMissedRenewal.Series[0].IsValueShownAsLabel = true;
            //ChartMissedRenewal.Series[1].IsValueShownAsLabel = true;

            ChartMissedRenewal.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ChartMissedRenewal.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            ChartMissedRenewal.Series[0]["PointWidth"] = "0.5";
            //ChartMissedRenewal.Series[1]["PointWidth"] = "0.5";

            ChartMissedRenewal.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            ChartMissedRenewal.ChartAreas["ChartArea1"].AxisY.Title = "Count";

            ChartMissedRenewal.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //ChartMissedRenewal.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -20;

            ChartMissedRenewal.ChartAreas["ChartArea1"].ShadowColor = Color.White;
            ChartMissedRenewal.ChartAreas["ChartArea1"].BackColor = Color.White;

            //ChartMissedRenewal.ChartAreas["ChartArea1"].AxisY.Interval = 20;
            #endregion

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
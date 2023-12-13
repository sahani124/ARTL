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
#endregion 

public partial class Charts : BaseClass
{
    #region DECLARATION
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    SqlDataReader dtRead;
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    private const string c_strBlank = "-- Select --";
    private multilingualManager olng, olng_m;
    private string strUserLang;
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    string strXML = "";
    string strBizSrc = String.Empty, strBizSrcDesc = String.Empty, strChnCls = String.Empty, strAgentType = String.Empty;
    string ErrMsg, AuditType;
    private string m_strUserLang, m_strMgrCode, m_strUnitCode, m_strDirectAgtCode, m_strAgentStatus, m_strAgentTypeAddl;
    enum PrmDemType { Promotion, Demotion }

    SqlConnection objSQLConForTran = new SqlConnection();
    SqlTransaction objSQLTran = null;
    private clsAgent agtObject = new clsAgent();
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

        #region IsPostBack
        if (!IsPostBack)
        {
            FillPageData();            
        }
       #endregion

    }
    #endregion

    #region funchnlpopup
    public void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region FillPageData
    public void FillPageData()
    {
        funchnlpopup(ddlSlsChannel);
        ddlSlsChannel.SelectedValue = "AG";
        FillDashBoardCount();

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
            htagt.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
            dsagt = objDAL.GetDataSetForPrc("prc_GetDashBoardDtls", htagt);

            if (dsagt.Tables.Count > 0 && dsagt.Tables[0].Rows.Count > 0)
            {
                lblAgntCnt.Text = dsagt.Tables[0].Rows[0]["AgnCnt"].ToString().Trim();
                lblEmpCnt.Text = dsagt.Tables[0].Rows[0]["EmpCnt"].ToString().Trim();
                lblVenCnt.Text = dsagt.Tables[0].Rows[0]["VenCnt"].ToString().Trim();
                lblUntCnt.Text = dsagt.Tables[0].Rows[0]["UntCnt"].ToString().Trim();
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

    #region ddlSlsChannel_SelectedIndexChanged
    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDashBoardCount();
    }
    #endregion

    //    protected void FillDawatYr()
//    {
//        string EngYr = DateTime.Now.Year.ToString();
//        try
//        {
//            DataSet dsResult = new DataSet();
//            htParam.Clear();
//            htParam.Add("@EngYr", EngYr.ToString().Trim());
//            dsResult = objDAL.GetDataSetForPrc_jamea("Prc_GetArabicYr", htParam);

//            if (dsResult.Tables.Count > 0)
//            {
//                lblAraYr.Text = dsResult.Tables[0].Rows[0]["MuslimYr"].ToString().Trim();
//            }
//        }
//        catch (Exception ex)
//        {
//            htParam.Clear();
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//    }

//        #region FillCount()
//    public void Fillcount()
//    {
//        //try
//        //{
//        //    Hashtable htParam = new Hashtable();
//        //    ds1.Clear();
//        //    ds2.Clear();
//        //    htParam.Clear();
//        //    htParam.Add("@Jamea", lblMJamea.Text.ToString().Trim());
//        //    ds1 = objDAL.GetDataSetForPrc_jamea("Prc_GetAsatezaCount", htParam);
//        //    ds2 = objDAL.GetDataSetForPrc_jamea("Prc_GetTalabatCount", htParam);

//        //    if (ds1.Tables.Count > 0)
//        //    {
//        //        lblMAsatezaVal.Text = ds1.Tables[0].Rows[0]["SRNo"].ToString().Trim();
//        //    }

//        //    if (ds2.Tables.Count > 0)
//        //    {
//        //        lblMTalabatVal.Text = ds2.Tables[0].Rows[0]["TRNo"].ToString().Trim();
//        //    }

//        //    ds1.Clear();
//        //    ds2.Clear();
//        //    htParam.Clear();
//        //    htParam.Add("@Jamea", lblKJamea.Text.ToString().Trim());
//        //    ds1 = objDAL.GetDataSetForPrc_jamea("Prc_GetAsatezaCount", htParam);
//        //    ds2 = objDAL.GetDataSetForPrc_jamea("Prc_GetTalabatCount", htParam);

//        //    if (ds1.Tables.Count > 0)
//        //    {
//        //        lblKAsatezaVal.Text = ds1.Tables[0].Rows[0]["SRNo"].ToString().Trim();
//        //    }

//        //    if (ds2.Tables.Count > 0)
//        //    {
//        //        lblKTalabatVal.Text = ds2.Tables[0].Rows[0]["TRNo"].ToString().Trim();
//        //    }


//        //    ds1.Clear();
//        //    ds2.Clear();
//        //    htParam.Clear();
//        //    htParam.Add("@Jamea", lblSJamea.Text.ToString().Trim());
//        //    ds1 = objDAL.GetDataSetForPrc_jamea("Prc_GetAsatezaCount", htParam);
//        //    ds2 = objDAL.GetDataSetForPrc_jamea("Prc_GetTalabatCount", htParam);

//        //    if (ds1.Tables.Count > 0)
//        //    {
//        //        lblSAsatezaVal.Text = ds1.Tables[0].Rows[0]["SRNo"].ToString().Trim();
//        //    }

//        //    if (ds2.Tables.Count > 0)
//        //    {
//        //        lblSTalabatVal.Text = ds2.Tables[0].Rows[0]["TRNo"].ToString().Trim();
//        //    }



//        //    ds1.Clear();
//        //    ds2.Clear();
//        //    htParam.Clear();
//        //    htParam.Add("@Jamea", lblNJamea.Text.ToString().Trim());
//        //    ds1 = objDAL.GetDataSetForPrc_jamea("Prc_GetAsatezaCount", htParam);
//        //    ds2 = objDAL.GetDataSetForPrc_jamea("Prc_GetTalabatCount", htParam);

//        //    if (ds1.Tables.Count > 0)
//        //    {
//        //        lblNAsatezaVal.Text = ds1.Tables[0].Rows[0]["SRNo"].ToString().Trim();
//        //    }

//        //    if (ds2.Tables.Count > 0)
//        //    {
//        //        lblNTalabatVal.Text = ds2.Tables[0].Rows[0]["TRNo"].ToString().Trim();
//        //    }
//        //}
//        //catch (Exception ex)
//        //{
//        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//        //    String LogClassName = method.ReflectedType.Name;
//        //    ErrHandler.WriteLogFile(LogClassName.ToString(), method.Name.ToString(), ex.Message.ToString(),
//        //                                          HttpContext.Current.Session["UserId"].ToString(),
//        //                                          HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],
//        //                                          DateTime.Now.ToString("dd/MM/yyy hh:mm:ss"));
//        //}
//    }
//    #endregion

//        #region Line Chart Functions

//    private void addchart()
//    {
//        #region ChartLine
//        try
//        {
//            //Chart 1
//            //ht.Clear();
//            //ht.Add("@Flag", "1");
//            //dsChart = GetDataSetForPrcRec("Prc_GetJameadtl", ht);
//            //ChartLine.DataSource = dsChart;
//            //if (dsChart.Tables.Count > 0)
//            //{
//            //    ChartLine.ChartAreas.Add("ChartArea1");
//            //    ChartLine.ChartAreas[0].AxisX.Title = "AdmissionYr";
//            //    ChartLine.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 9, System.Drawing.FontStyle.Bold);
//            //    ChartLine.ChartAreas[0].AxisY.Title = "Total";
//            //    ChartLine.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 9, System.Drawing.FontStyle.Bold);
                


//            //    ChartLine.Legends.Add("AdmissionYr");
//            //    ChartLine.Series.Add("Karachi");
//            //    ChartLine.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
//            //    ChartLine.Series[0].Points.DataBindXY(dsChart.Tables[1].DefaultView, "AdmissionYr", dsChart.Tables[1].DefaultView, "Total");
//            //    ChartLine.Series[0].Color = Color.Red;
//            //    ChartLine.Series[0].BorderWidth = 0;
//            //    ChartLine.Series[0]["PointWidth"] = "0.00001";

//            //    ChartLine.Series.Add("Surat");
//            //    ChartLine.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
//            //    ChartLine.Series[1].Points.DataBindXY(dsChart.Tables[2].DefaultView, "AdmissionYr", dsChart.Tables[2].DefaultView, "Total");
//            //    ChartLine.Series[1].Color = Color.Green;
//            //    ChartLine.Series[1].BorderWidth = 0;
//            //    ChartLine.Series[1]["PointWidth"] = "0.00001";

//            //    ChartLine.Series.Add("Nairobi");
//            //    ChartLine.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
//            //    ChartLine.Series[2].Points.DataBindXY(dsChart.Tables[3].DefaultView, "AdmissionYr", dsChart.Tables[3].DefaultView, "Total");
//            //    ChartLine.Series[2].Color = Color.Blue;
//            //    ChartLine.Series[2].BorderWidth = 0;
//            //    ChartLine.Series[2]["PointWidth"] = "0.00001";

//            //    //ChartLine.Series.Add("Male");
//            //    //ChartLine.Series[3].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
//            //    //ChartLine.Series[3].Points.DataBindXY(dsChart.Tables[4].DefaultView, "AdmissionYr", dsChart.Tables[4].DefaultView, "Total");
//            //    //ChartLine.Series[3].Color = Color.Yellow;
//            //    //ChartLine.Series[3].BorderWidth = 3;

//            //    ChartLine.Series.Add("Marol");
//            //    ChartLine.Series[3].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
//            //    ChartLine.Series[3].Points.DataBindXY(dsChart.Tables[4].DefaultView, "AdmissionYr", dsChart.Tables[4].DefaultView, "Total");
//            //    ChartLine.Series[3].Color = Color.Purple;
//            //    ChartLine.Series[3].BorderWidth = 0;
//            //    ChartLine.Series[3]["PointWidth"] = "0.00001";

//            //    ChartLine.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
//            //    ChartLine.ChartAreas["ChartArea1"].BackColor  = Color.White;
//            //   // ChartLine.ChartAreas["ChartArea1"].ShadowColor = Color.White;

//            //    ChartLine.ChartAreas["ChartArea1"].AxisY.Interval = 20;
//            //}

//            //double plotY = 50.0;
//            //double plotY2 = 200.0;
//            //if (ChartLine.Series[0].Points.Count > 0)
//            //{
//            //    plotY = ChartLine.Series[0].Points[ChartLine.Series[0].Points.Count - 1].YValues[0];
//            //    plotY2 = ChartLine.Series[0].Points[ChartLine.Series[0].Points.Count - 1].YValues[0];
//            //}
//            //Random random = new Random();
//            //for (int pointIndex = 0; pointIndex < 20000; pointIndex++)
//            //{
//            //    plotY = plotY + (float)(random.NextDouble() * 10.0 - 5.0);
//            //    ChartLine.Series[0].Points.AddY(plotY);

//            //    plotY2 = plotY2 + (float)(random.NextDouble() * 10.0 - 5.0);
//            //    ChartLine.Series[0].Points.AddY(plotY2);
//            //}



//            #endregion

//            #region ChartKhidmat


//            dt = GetDataSetPrcBar1("Prc_GetAsatezaAdmissionDtls");
//            AsatezaAdmission.DataSource = dt;

//            AsatezaAdmission.DataBindCrossTable(dt.Rows, "KhidmatYr", "ParamDesc01", "Total", "");
//            AsatezaAdmission.Series[0].IsValueShownAsLabel = true;
//            AsatezaAdmission.Series[1].IsValueShownAsLabel = true;

//            AsatezaAdmission.Series[0]["PointWidth"] = "0.5";
//            AsatezaAdmission.Series[1]["PointWidth"] = "0.5";

//            AsatezaAdmission.ChartAreas["ChartArea1"].AxisX.Title = "Jamea";
//            AsatezaAdmission.ChartAreas["ChartArea1"].AxisY.Title = "Total";

//            AsatezaAdmission.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
//            AsatezaAdmission.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -18;

//            AsatezaAdmission.ChartAreas["ChartArea1"].ShadowColor = Color.White;
//            AsatezaAdmission.ChartAreas["ChartArea1"].BackColor= Color.White;

//            AsatezaAdmission.ChartAreas["ChartArea1"].AxisY.Interval = 2;
            

//        }
//        catch (Exception ex)
//        {
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//        #endregion
//    }
    
//#region method of aceesing DB with para and returns Dataset start
//    public DataSet GetDataSetForPrcRec(string strSql, Hashtable htable)
//    {
//        DataSet dsResult = new DataSet();
//        SqlCommand cmdObj = new SqlCommand();
//        cmdObj.CommandText = strSql;
//        cmdObj.CommandType = CommandType.StoredProcedure;
//        cmdObj.Connection = con;
//        try
//        {

//            objAdp = new SqlDataAdapter(cmdObj);
//            objAdp.SelectCommand.CommandTimeout = 0;
//            foreach (System.Collections.DictionaryEntry dist in htable)
//            {
//                 objAdp.SelectCommand.Parameters.AddWithValue((string)dist.Key, dist.Value);
//            }
//            objAdp.Fill(dsResult);

//        }
//         catch (Exception ex)
//        {
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//        return dsResult;
//    }
//    #endregion
//    #endregion
        
//        #region Pie Chart Functions Commented
//    //public DataSet GetDataSetPrcTal(string strSql)
//    //{
//    //    cmd.CommandText = strSql;
//    //    cmd.CommandType = CommandType.StoredProcedure;
//    //    cmd.Connection = con;
//    //    try
//    //    {
//    //        da = new SqlDataAdapter(cmd);
//    //        da.Fill(ds);

//    //    }
//    //    catch (Exception ex)
//    //    {
//    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//    //        string sRet = oInfo.Name;
//    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//    //        String LogClassName = method.ReflectedType.Name;
//    //        objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//    //    }
//    //    return ds;
//    //}
//    #endregion

//        #region Bar Chart Functions
//    public DataTable GetDataSetPrcBar1(string strSql)
//    {
       
//        cmd.CommandText = strSql;
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Connection = con;
//        try
//        {
//            da = new SqlDataAdapter(cmd);
//            da.Fill(dt);

//        }
//        catch (Exception ex)
//        {
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//        return dt;
//    }
//    public DataTable GetDataSetPrcBar2(string strSql)
//    {
//        dt.Clear();
//        cmd.CommandText = strSql;
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Connection = con;
//        try
//        {
//            da = new SqlDataAdapter(cmd);
//            da.Fill(dt);
//        }
//        catch (Exception ex)
//        {
//            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//            string sRet = oInfo.Name;
//            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//            String LogClassName = method.ReflectedType.Name;
//            objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//        }
//        return dt;
//    }
//    #endregion

//        #region Fill Webparts from Database
//        private void fillWebparts()
//        {
//            ht.Clear();
//            try
//            {
//                string strUserID = HttpContext.Current.Session["UserID"].ToString();
//                string strRoleCode = HttpContext.Current.Session["RoleCode"].ToString();

//                string[] AlertDt = new string[9];
//                string[] AlertDsc = new string[9];
//                string[] AnnDsc = new string[9];
//                string[] NewsDt = new string[9];
//                string[] NewsDsc = new string[9];

//                ds3 = objDAL.GetDataSetWithoutParam("prc_Getnews", "INSCDirectConnectionString");
            
//                NewsDt[0] =ds3.Tables[0].Rows[0]["NewsDate"].ToString();
//                NewsDsc[0] = ds3.Tables[0].Rows[0]["Description"].ToString();
//                NewsDt[1] =ds3.Tables[0].Rows[1]["NewsDate"].ToString();
//                NewsDsc[1] = ds3.Tables[0].Rows[1]["Description"].ToString();
//                NewsDt[2] = ds3.Tables[0].Rows[2]["NewsDate"].ToString();
//                NewsDsc[2] = ds3.Tables[0].Rows[2]["Description"].ToString();

//                lblDate1News.Text = NewsDt[0];
//                lblDate2News.Text =  NewsDt[1];
//                lblDate3News.Text =  NewsDt[2];

//                lblDesc1News.Text =  NewsDsc[0]; 
//                lblDesc2News.Text =  NewsDsc[1]; 
//                lblDesc3News.Text = NewsDsc[2];
                

//                ht.Add("@UserID", strUserID.ToString().Trim());
//                ds1 = objDAL.GetDataSetForPrcDBConn("prc_GetAlert", ht, "INSCDirectConnectionString");
               
//                gvAlert.DataSource = ds1;
//                gvAlert.DataBind();
//                #region Commented
//                //AlertDt[0] = ds1.Tables[0].Rows[0]["AlertDate"].ToString();
//                //AlertDt[1] = ds1.Tables[0].Rows[1]["AlertDate"].ToString();
//                //AlertDt[2] = ds1.Tables[0].Rows[2]["AlertDate"].ToString();

//                //AlertDsc[0] = ds1.Tables[0].Rows[0]["Description"].ToString();
//                //AlertDsc[1] = ds1.Tables[0].Rows[1]["Description"].ToString();
//                //AlertDsc[2] = ds1.Tables[0].Rows[2]["Description"].ToString();

//                //lblDate1Alert.Text = AlertDt[0];
//                //lblDesc1Alert.Text = AlertDsc[0];
//                //lblDate2Alert.Text = AlertDt[1];
//                //lblDesc2Alert.Text = AlertDsc[1];
//                //lblDate3Alert.Text = AlertDt[2];
//                //lblDesc3Alert.Text = AlertDsc[2];
//                #endregion
//                ht.Clear();

//                ht.Add("@RoleCode", strRoleCode.ToString().Trim());
//                ds2 = objDAL.GetDataSetForPrcDBConn("prc_GetAnnouncements", ht, "INSCDirectConnectionString");
//                AnnDsc[0] = ds2.Tables[0].Rows[0]["Description"].ToString();
//                AnnDsc[1] = ds2.Tables[0].Rows[1]["Description"].ToString();
//                AnnDsc[2] = ds2.Tables[0].Rows[2]["Description"].ToString();
//                AnnDsc[3] = ds2.Tables[0].Rows[3]["Description"].ToString();

//                //lblDesc1Ann.Text = AnnDsc[0];
//                //lblDesc2Ann.Text = AnnDsc[1];
//                //lblDesc3Ann.Text = AnnDsc[2];
//                //lblDesc4Ann.Text = AnnDsc[3];
//            }
//            catch (Exception ex)
//            {
//                ht.Clear();
//                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//                string sRet = oInfo.Name;
//                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//                String LogClassName = method.ReflectedType.Name;
//                objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//            }
//        }
//        #endregion
//        protected void gvAlert_RowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            try
//            {
//                if (e.Row.RowType == DataControlRowType.DataRow)
//                {
//                   int currRowIndex = e.Row.RowIndex;
//                   int valStatus = Convert.ToInt32(ds1.Tables[0].Rows[currRowIndex]["Status"].ToString().Trim());
//                        if (valStatus == 0)
//                        {
//                            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
//                            System.Web.UI.WebControls.Image imgStatus = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgStatus");
//                            lblStatus.Text = String.Empty;
//                            imgStatus.Visible = true;
//                            lblStatus.Text = "Pending";
//                            imgStatus.ImageUrl = "../../image/Approve.gif";
//                            imgStatus.Height = 20;
//                            imgStatus.Width = 20;
//                        }
//                        else if (valStatus == 1)
//                        {
//                            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
//                            System.Web.UI.WebControls.Image imgStatus = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgStatus");
//                            lblStatus.Text = String.Empty;
//                            lblStatus.Text = "Completed";
//                            imgStatus.ImageUrl = String.Empty;
//                            imgStatus.Visible = false;
//                        }
//                    }
//                }
//            catch (Exception ex)
//            {
//                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//                string sRet = oInfo.Name;
//                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//                String LogClassName = method.ReflectedType.Name;
//                objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//            }
//        }


//        protected DataTable GetAlert()
//        {
//            try
//            {
//                Hashtable htParam = new Hashtable();
//                htParam.Clear();
//                htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
//                ds1 = null;
//                ds1 = objDAL.GetDataSetForPrcDBConn("prc_GetAlert", htParam, "INSCDirectConnectionString");
//                return ds1.Tables[0];
//            }
//            catch (Exception Ex)
//            {
//                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//                string sRet = oInfo.Name;
//                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//                String LogClassName = method.ReflectedType.Name;
//                objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//                return null;
//            }
//        }
        

//        protected void gvAlert_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            try
//            {
//                DataTable dt = GetAlert();
//                DataView dv = new DataView(dt);
//                GridView dgSource = (GridView)sender;
//                dgSource.PageIndex = e.NewPageIndex;
//                dv.Sort = dgSource.Attributes["SortExpression"];
//                if (dgSource.Attributes["SortASC"] == "No")
//                {
//                    dv.Sort += " DESC";
//                }
//                dgSource.DataSource = dv;
//                dgSource.DataBind();
//                //ShowPageInformation();
//            }
//            catch (Exception Ex)
//            {
//                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
//                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
//                string sRet = oInfo.Name;
//                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
//                String LogClassName = method.ReflectedType.Name;
//                objErrLog.LogErr("SIGATULJAMEA", sRet, method.Name.ToString(), Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
//            }
//        }
//        protected void AsatezaAdmission_Load(object sender, EventArgs e)
//        {

//        }
    
}

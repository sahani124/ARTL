using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_RuleSetPages_FFContestPageStdDef : BaseClass
{
    #region Declarations
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["USRMGMT"].ToString();
    private SqlConnection sqlconn = new SqlConnection();
    private DataSet Ds = new DataSet();
    private SqlCommand cmd = new SqlCommand();
    private SqlDataAdapter sqladpt = new SqlDataAdapter();
    Hashtable Htparam = new Hashtable();

    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    DataAccessClass obDAL = new DataAccessClass();
    DataTable dt = new DataTable();
    ErrLog objErr = new ErrLog();

    string Branchcode = "";
    string strmapcode = string.Empty, strcmpcode = string.Empty, RuleSetKey = string.Empty, strcntstcode = string.Empty;

    string AccCycle = string.Empty;
    string table_name = null;
    string strColumnError = string.Empty;
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    private multilingualManager olng;
    private DataAccessClass dataAccess = new DataAccessClass();
    DataAccessClass objDAL = new DataAccessClass();

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strmapcode = Request.QueryString["mapcode"].ToString();
            if (Request.QueryString["CMPNSTN_CODE"] != null)
            {
                strcmpcode = Request.QueryString["CMPNSTN_CODE"].ToString();
            }
            if (Request.QueryString["RuleSetKey"] != null)
            {
                RuleSetKey = Request.QueryString["RuleSetKey"].ToString();//CNTST_CODE
            }
            if (Request.QueryString["CNTST_CODE"] != null)
            {
                strcntstcode = Request.QueryString["CNTST_CODE"].ToString();
            }

            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    hdnBackUrl.Value = Request.UrlReferrer.AbsoluteUri;
                }

                divHie.Visible = false;
                DivMApActionMPL.Visible = false;
                if (Request.QueryString["KpiCode"] != null)
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString() == "in")
                        {
                            divcmpmain.Style.Add("display", "none");
                            tblHeadare.Style.Add("display", "none");
                            divcmphdr.Style.Add("display", "none");
                            DivKpi.Style.Add("display", "block");
                            divStdDefLOBDtls.Style.Add("display", "block");
                            div9.Style.Add("display", "none");
                            GetDateRelDefn(strmapcode, dgDateDef, "P");

                            DataSet ds = new DataSet();
                            GetPremFreq(strmapcode);
                            GetProdData(strmapcode);
                            GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);

                            ds.Clear();
                            Htparam.Clear();

                            Htparam.Add("@KPICode", Request.QueryString["KpiCode"].ToString());
                            Htparam.Add("@Flag", "1");
                            ds = obDAL.GetDataSetForPrcDBConn("prc_KPISearch", Htparam, "SAIMConnectionString");

                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblKpiCode.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString();
                                    lblKpiDesc.Text = ds.Tables[0].Rows[0]["KPI_DESC_01"].ToString();
                                }
                            }
                            btnAddDateReleted.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + strmapcode + ",'','P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");////Date Level
                            btnAddMem.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + strmapcode + ",'','A','','');return false;");////Member Level
                            BtnPremium.Attributes.Add("onclick", "funPopUpRulSetPremium('','','R'," + strmapcode + ");return false;");////Frequency Level
                            BtnVPSCAdd.Attributes.Add("onclick", "funPopUpRulSetVPSC('','','R'," + strmapcode + ");return false;");////Frequency Level
                        }
                        else if (Request.QueryString["flag"].ToString() == "kpi")
                        {
                            divcmpmain.Style.Add("display", "none");
                            tblHeadare.Style.Add("display", "none");
                            divcmphdr.Style.Add("display", "none");
                            DivKpi.Style.Add("display", "block");
                            divStdDefLOBDtls.Style.Add("display", "block");
                            div9.Style.Add("display", "none");
                            div1.Style.Add("display", "none");
                            div4.Style.Add("display", "none");
                            divAgtDt.Visible = true;
                            GetDateRelDefn(strmapcode, dgMemDt, "A");

                            DataSet ds = new DataSet();
                            //string strmapcode = Request.QueryString["mapcode"].ToString();
                            GetPremFreq(strmapcode);
                            GetProdData(strmapcode);
                            GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);

                            ds.Clear();
                            Htparam.Clear();

                            Htparam.Add("@KPICode", Request.QueryString["KpiCode"].ToString());
                            Htparam.Add("@Flag", "1");
                            ds = obDAL.GetDataSetForPrcDBConn("prc_KPISearch", Htparam, "SAIMConnectionString");

                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblKpiCode.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString();
                                    lblKpiDesc.Text = ds.Tables[0].Rows[0]["KPI_DESC_01"].ToString();
                                }
                            }
                        }
                        else if (Request.QueryString["flag"].ToString() == "1")
                        {
                            //AddedControl BY Pratik
                            StdDefinationPrep();
                            div9.Visible = false;
                            //AddedControl BY Pratik
                        }
                        else if (Request.QueryString["flag"].ToString() == "2")
                        {
                            //AddedControl BY Pratik
                            StdDefinationPrep();
                            divHie.Visible = true;
                            div9.Visible = false;
                            div17.Visible = true;
                            DivMApActionMPL.Visible = true;
                            chkKpiMst.Visible = false;
                            Label7.Visible = false;
                            ddlSplit.Visible = false;
                            div21.Visible = true;
                            InheritedAction();
                            GetProdweightages(dgProdweightages);
                            GetMPLGrigview(dgMPL);
                            //AddedControl BY Pratik
                        }
                    }

                    if (Convert.ToString(Request.QueryString["flag"]) == "1")
                    {
                        //Added by Pratik
                        string ACT_TYPE = "1001";
                        btnproduct.Attributes.Add("onclick", "funGotoProductWeightage('" + Convert.ToString(Request.QueryString["role"]) + "','" + Convert.ToString(Request.QueryString["flag"]) + "','" + Convert.ToString(Request.QueryString["mapcode"]) + "','" + Convert.ToString(Request.QueryString["KpiCode"]) + "','" + ACT_TYPE + "'); return false;");
                    }
                    else if (Convert.ToString(Request.QueryString["flag"]) == "2")
                    {
                        btnproduct.Attributes.Add("onclick", "btnctn(); return false;");
                        //btnproduct.Click += btnproduct_Click;
                        btnAddProdweightages.Attributes.Add("onclick", "btnaddProd(); return false;");
                        btnAddMPL.Attributes.Add("onclick", "btnaddMPL(); return false;");
                    }
                    else
                    {
                        btnproduct.Attributes.Add("onclick", "funPopUpRulSetProduct('','','R','" + strmapcode + "','','" + RuleSetKey + "','" + Request.QueryString["KPI_CODE"].ToString().Trim() + "');return false;");
                    }
                }
                else
                {
                    if (Request.QueryString["flag"].ToString() == "rsKPI")
                    {
                        divStdDefLOBDtls.Style.Add("display", "block");
                        div9.Visible = true;
                    }

                    else if (Request.QueryString["flag"].ToString() == "rsKPITrg")/////KPI targets set Rule
                    {
                        //divStdDefLOBDtls.Style.Add("display", "block");
                        div9.Visible = true;
                        div1.Visible = false;
                        div12.Visible = false;
                        div4.Visible = false;
                        div17.Visible = false;
                        if (Request.QueryString["DRVDKPI"] != null)
                        {
                            GetMemberDates(Request.QueryString["DRVDKPI"].ToString().Trim(), Request.QueryString["mapcode"].ToString().Trim());
                        }
                        GetDateRelDefn(strmapcode, dgDateDef, "P");
                    }
                    else if (Request.QueryString["flag"].ToString() == "kpi")
                    {
                        divcmpmain.Style.Add("display", "block");
                        tblHeadare.Style.Add("display", "block");
                        divcmphdr.Style.Add("display", "block");
                        DivKpi.Style.Add("display", "none");
                        divStdDefLOBDtls.Style.Add("display", "block");
                        div9.Style.Add("display", "none");
                        div1.Style.Add("display", "none");
                        div4.Style.Add("display", "none");
                        divAgtDt.Visible = true;
                        GetDateRelDefn(strmapcode, dgMemDt, "A");
                    }
                    string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
                    string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();

                    DataSet ds = new DataSet();
                    ds.Clear();
                    Htparam.Clear();

                    Htparam.Add("@CompCode", strCMPNSTN_CODE);
                    Htparam.Add("@CntstCode", strCNTST_CODE);
                    //ds = obDAL.GetDataSetForPrcDBConn("Prc_FillCmpCntstDtls", Htparam, "SAIMConnectionString");
                    ds = obDAL.GetDataSetForPrc_SAIM("Prc_FillCmpCntstDtls", Htparam);

                    if (ds.Tables.Count > 0)
                    {
                        lblCompCodeVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString();

                        lblCompDesc1Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString();
                        lblCompDesc2Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString();

                        lblAccYrVal.Text = ds.Tables[0].Rows[0]["ACC_YEAR_DESC"].ToString();

                        lblCompTypVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString();

                        lblAccCycVal.Text = ds.Tables[0].Rows[0]["ACC_CYCLE_DESC"].ToString();
                        lblAccCycleValue.Text = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE_DESC"].ToString();

                        lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["REWARD_ACC_CYCLE_DESC"].ToString();

                        lblCntstCdVal.Text = ds.Tables[0].Rows[0]["CNTSTNT_CODE"].ToString();

                        lblSlsChnlVal.Text = ds.Tables[0].Rows[0]["CHN_DESC"].ToString();

                        lblSbClsVal.Text = ds.Tables[0].Rows[0]["CHNCLS_DESC"].ToString();
                        //REmain
                        lblMemTypVal.Text = ds.Tables[0].Rows[0]["MEMTYPE_DESC"].ToString();

                        lblFinYrVal.Text = ds.Tables[0].Rows[0]["FIN_YEAR_CMP"].ToString();

                        lblVerVal.Text = ds.Tables[0].Rows[0]["VER_NO_CNT"].ToString();
                        //   		
                        lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString();

                        lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString();

                    }

                    GetPremFreq(strmapcode);
                    GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);
                    GetProdData(strmapcode);
                    btnAddDateReleted.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + strmapcode + ",'','P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
                    btnAddMem.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + strmapcode + ",'','A'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
                    BtnPremium.Attributes.Add("onclick", "funPopUpRulSetPremium('','','R'," + strmapcode + ");return false;");
                    BtnVPSCAdd.Attributes.Add("onclick", "funPopUpRulSetVPSC('','','R'," + strmapcode + ");return false;");////Frequency Level
                }
            }

            GetPremFreq(strmapcode);
            GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);
            GetDateRelDefn(strmapcode, dgDateDef, "P");
            GetProdData(strmapcode);

            //btnDwnUpd.Attributes.Add("onclick", "funPopUpRulSetProductBulk('" + strcmpcode + "' ,'" + strcntstcode + ",'R'," + strmapcode + ");return false;");
            //btnproduct.Attributes.Add("onclick", "funPopUpRulSetProduct('','','R'," + strmapcode + ",'',','" + RuleSetKey + "','" + Request.QueryString["KPI_CODE"].ToString().Trim() + "');return false;");////Product Level
            //btnproduct.Attributes.Add("onclick", "funPopUpRulSetProduct('','','R','" + strmapcode + "','','" + RuleSetKey + "','" + Request.QueryString["KPI_CODE"].ToString().Trim() + "');return false;");////Product Level
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys SAIM", "FFcontestPageStdDef", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    public void GetSplitFunct()
    {

        Hashtable ht = new Hashtable();
        SqlDataReader drRead;
        if (Request.QueryString["KPIMode"] != null && Request.QueryString["KPIMode"].ToString().Trim() == "KPISet")
        {
            ht.Add("@CYCLE_CODE", "");
            ht.Add("@RuleSetKey", "");
        }
        else
        {
            ht.Add("@CYCLE_CODE", Request.QueryString["CYCLE"].ToString().Trim());
            ht.Add("@RuleSetKey", Request.QueryString["RuleSetKey"].ToString().Trim());
        }
        //ht.Add("@CNTSTNT_CODE", CNTSTNT_CODE.ToString());
        //ht.Add("@flag", flag.ToString());
        //ddlselect.Items.Insert(0, new ListItem("-- SELECT --"));
        ddlselect.Items.Clear();

        drRead = obDAL.Common_exec_reader_prc_SAIM("Prc_GetSplitFunc", ht);
        if (drRead.HasRows)
        {
            lnkSplit.Visible = false;
            ddlselect.DataSource = drRead;
            ddlselect.DataTextField = "ParamDesc1";
            ddlselect.DataValueField = "ParamValue";
            ddlselect.DataBind();
            ddlselect.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlselect.Enabled = true;
        }
        else
        {
            ddlselect.Enabled = false;
        }
        drRead.Close();

        //if (ddlselect.SelectedIndex[2] != "") { 

        //}

    }



    protected void btnDownloadData_Click(object sender, EventArgs e)
    {

        try
        {

            htParam.Clear();
            dsResult.Clear();




            htParam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());

            htParam.Add("@CYCLE_CODE", "");
            htParam.Add("@RuleSetKey", "");
            htParam.Add("@MEM_CODE", "");

            // string table_name = null;
            dsResult = objDAL.GetDataSetForPrc_SAIM("EditProdData_New", htParam);
            if (dsResult.Tables.Count > 0)
            {

                ExportCSV(dsResult.Tables[0], "DataFile");
                //BindGrid(table_name);
                //exportfile(table_name);

                // }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Table name not found')", true);
            }


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys SAIM", "FFcontestPageStdDef", "btnDownloadData_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }




    protected void btn_Download_Click(object sender, EventArgs e)
    {

        try
        {
            //GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;

            //LinkButton lnkup = (LinkButton)gvRow.FindControl("btn_Download");

            //HiddenField hdf_kpiCode = (HiddenField)gvRow.FindControl("hdnKPI_CODE");


            htParam.Clear();
            dsResult.Clear();

            //htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            //htParam.Add("@CNTSTNT_CODE", Request.QueryString["cnstCode"].ToString().Trim());
            //htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSet"].ToString().Trim());

            htParam.Add("@MappeCode", Request.QueryString["mapcode"].ToString().Trim());

            // htParam.Add("@ProdCode", AccCycle);

            // htParam.Add("@MappeCode", HttpContext.Current.Session["UserID"].ToString().Trim());

            //DataSet dsResult = new DataSet();
            //dsResult.Clear();
            // string table_name = null;
            dsResult = objDAL.GetDataSetForPrc_SAIM("Get_txProductMaster", htParam);
            if (dsResult.Tables.Count > 0)
            {

                ExportCSV(dsResult.Tables[0], "SampledataFile");
                //BindGrid(table_name);
                //exportfile(table_name);

                // }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Table name not found')", true);
            }


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys SAIM", "FFcontestPageStdDef", "btn_Download_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }


    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {

        }
        return Rest;


    }






    //protected void BtnDownloadExcel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlRuleSetCode.SelectedIndex == 0)
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Code Dropdown')", true);
    //        }
    //        else
    //        {
    //            Hashtable hparam = new Hashtable();
    //            htParam.Clear();
    //            dsResult.Clear();
    //            if (ddlRuleSetCode.SelectedIndex > 0)
    //            {
    //                htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
    //            }
    //            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetTargetsAgnstCode", htParam);
    //            excel = new Microsoft.Office.Interop.Excel.Application();
    //            excel.Visible = false;
    //            excel.DisplayAlerts = false;
    //            worKbooK = excel.Workbooks.Add(Type.Missing);


    //            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
    //            DataSet dsQuestion = new DataSet();
    //            Hashtable hTable = new Hashtable();

    //            dsQuestion = dsResult;

    //            for (int i = 0; i < dsQuestion.Tables[0].Columns.Count; i++)
    //            {
    //                worksheet.Cells[1, i + 1] = dsQuestion.Tables[0].Columns[i].ColumnName;
    //                //worksheet.Cells[1, i + 1].Font.Color = System.Drawing.Color.Black;
    //                //worksheet.Cells[1, i + 1].Font.FontStyle = System.Drawing.FontStyle.Bold;
    //                //worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.Color.Yellow;
    //            }

    //            for (int i = 0; i < dsQuestion.Tables[0].Rows.Count; i++)
    //            {
    //                for (int j = 0; j < dsQuestion.Tables[0].Columns.Count; j++)
    //                {
    //                    worksheet.Cells[2 + i, j + 1] = dsQuestion.Tables[0].Rows[i][j];
    //                }
    //            }


    //            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
    //            celLrangE.EntireColumn.AutoFit();
    //            //celLrangE.EntireColumn[2].Hidden = true;
    //            //worksheet.Columns[2].Hidden = True;
    //            //celLrangE.EntireColumn[3].Locked = true;

    //            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
    //            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
    //            border.Weight = 2d;

    //            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
    //            Missing mv = Missing.Value;
    //            worksheet.Columns.Locked = false;
    //            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 1], (object)worksheet.Cells[1, 12])).EntireColumn.Locked = true;
    //            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 15], (object)worksheet.Cells[1, 36])).EntireColumn.Locked = true;
    //            worksheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlUnlockedCells;
    //            worksheet.Protect(mv, mv, mv, mv, mv, false, mv, mv, mv, mv, mv, mv, mv, mv, mv, mv);
    //            // btnBlkCatgUpd.Enabled = true;
    //            string tempPath = "F:\\Daksh1.xlsx";
    //            //worKbooK.SaveAs(tempPath, Excel.XlFileFormat.xlWorkbookNormal, mv, mv, mv, mv, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, mv, mv, mv, mv, mv);
    //            worKbooK.SaveAs(tempPath, worKbooK.FileFormat);//create temporary file from the workbook
    //            tempPath = worKbooK.FullName;

    //            //worKbooK.SaveAs(saveExcel(), Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, mv, mv, mv, mv, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, mv, mv, mv, mv, mv);
    //            //worKbooK.sa("my-workbook.xls");
    //            //worKbooK.SaveAs("E:\\Das.xlsx");
    //            worKbooK.Close();
    //            byte[] result = File.ReadAllBytes(tempPath);//change to byte[]

    //            excel.Quit();

    //            //added by daksh for upd dwnld 
    //            htParam.Clear();
    //            dsResult.Clear();
    //            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
    //            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetBatchagainstRuleSetKey", htParam);
    //            string RuleSetKey = dsResult.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
    //            string BatchID = dsResult.Tables[0].Rows[0]["BatchId"].ToString().Trim();
    //            if (dsResult.Tables[0].Rows.Count != 0)
    //            {
    //                htParam.Clear();
    //                dsResult.Clear();
    //                htParam.Add("@RulStKey", RuleSetKey);
    //                htParam.Add("@BatchId", BatchID);
    //                dsResult = objDal.GetDataSetForPrc_SAIM("Prc_TX_InsTmp_Cmpnstn_Cntstnt_KPI_Trgt_hist", htParam);
    //            }
    //            //added by daksh for upd dwnld 


    //            FileInfo file = new FileInfo(tempPath);
    //            if (file.Exists)
    //            {
    //                try
    //                {
    //                    string FileName = ddlRuleSetCode.SelectedValue.ToString().Trim() + "_" + "KPI_Target";
    //                    //btnBlkCatgUpd.Visible = true;
    //                    Response.Clear();
    //                    Response.ClearHeaders();
    //                    Response.ClearContent();
    //                    Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xlsx");
    //                    Response.AddHeader("Content-Type", "application/Excel");
    //                    Response.ContentType = "application/vnd.xls";
    //                    Response.AddHeader("Content-Length", file.Length.ToString());
    //                    Response.WriteFile(file.FullName);
    //                    Response.End();
    //                }
    //                catch
    //                {

    //                }
    //            }
    //            else
    //            {
    //                Response.Write("This file does not exist.");
    //            }
    //        }
    //        //KMICommon CommObj = new KMICommon();
    //        //HttpContext.Current.Session["popupdataSet"] = dsResult.Tables[0];
    //        //Response.Redirect("../../downloadexl.aspx?popupdataSet=y&reportName=" + FileName.Value);
    //        //int pop = (int)(PopupType)Enum.Parse(typeof(PopupType), popupType.Value);
    //        //CommObj.ExportCSV(ds.Tables[0], FileName.Value + "_" + DateTime.Now);
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}


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
        gv.Rows[0].Cells[0].Text = "No rules have been defined";

        //source.Rows.Clear();
    }
    protected void dgDateDef_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("dgDateDefedit");
            string mapcode = Request.QueryString["mapcode"].ToString();
            if (Request.QueryString["KpiCode"] != null)
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString() == "in")
                    {
                        lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + mapcode.Trim() + "," + lblCode.Value + ",'P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
                    }
                    else if (Request.QueryString["flag"].ToString() == "kpi")
                    {
                        lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + mapcode.Trim() + "," + lblCode.Value + ",'A'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
                    }
                }
                else
                {
                    lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + mapcode.Trim() + "," + lblCode.Value + ",'P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
                }
            }
            else
            {
                lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + mapcode.Trim() + "," + lblCode.Value + ",'P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");
            }
        }
    }
    protected void GrdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("EditGrdProduct");
            string mapcode = Request.QueryString["mapcode"].ToString();
            lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSetProduct('','','R'," + mapcode.Trim() + "," + lblCode.Value + ");return false;");
        }
    }
    protected void GrdPremiumWeight_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("GrdPremiumWeightEdit");
            string mapcode = Request.QueryString["mapcode"].ToString();
            lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSetPremium('','','R'," + mapcode.Trim() + "," + lblCode.Value + ");return false;");
        }
    }

    protected void GrdVPSWeight_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("GrdVPSCWeightEdit");
            string mapcode = Request.QueryString["mapcode"].ToString();
            lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSetVPSC('','','R'," + mapcode.Trim() + "," + lblCode.Value + ");return false;");
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        FillDateMemRel("P", dgDateDef);
        FillDateMemRel("A", dgMemDt);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        string strmapcode = "";

        if (Request.QueryString["KpiCode"] != null)
        {

            strmapcode = Request.QueryString["mapcode"].ToString();

        }
        else
        {

            string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
            string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();
            strmapcode = Request.QueryString["mapcode"].ToString();

        }
        DataSet ds = new DataSet();
        Htparam.Clear();
        Htparam.Add("@MapCode", strmapcode);
        //ds = obDAL.GetDataSetForPrcDBConn("Prc_EditPremiumFreq", Htparam, "SAIMConnectionString");
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_EditPremiumFreq", Htparam);
        DataTable dtGrdPremiumWeight = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowNoResultFound(dtGrdPremiumWeight, GrdPremiumWeight);
        }
        else
        {
            GrdPremiumWeight.DataSource = ds;
            GrdPremiumWeight.DataBind();
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        string strmapcode = "";

        if (Request.QueryString["KpiCode"] != null)
        {
            strmapcode = Request.QueryString["mapcode"].ToString();
        }
        else
        {

            string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
            string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();
            strmapcode = Request.QueryString["mapcode"].ToString();

        }
        DataSet ds = new DataSet();
        Htparam.Clear();
        Htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString());


        if (Request.QueryString["KPIMode"] != null && Request.QueryString["KPIMode"].ToString().Trim() == "KPISet")
        {
            Htparam.Add("@CYCLE_CODE", "");
            Htparam.Add("@RuleSetKey", Request.QueryString["RuleSetKey"].ToString().Trim());
            if (Request.QueryString["KPITrgt"] != null && Request.QueryString["KPITrgt"].ToString().Trim() == "R")
            {
                Htparam.Add("@MEM_CODE", "");
            }
        }
        else
        {
            Htparam.Add("@CYCLE_CODE", Request.QueryString["CYCLE"].ToString().Trim());
            Htparam.Add("@RuleSetKey", Request.QueryString["RuleSetKey"].ToString().Trim());
            if (Request.QueryString["KPITrgt"].ToString().Trim() == "R")
            {
                Htparam.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());
            }
        }

        //ds = obDAL.GetDataSetForPrcDBConn("EditProdData", Htparam, "SAIMConnectionString");
        //ds = obDAL.GetDataSetForPrcDBConn("EditProdData_New", Htparam, "SAIMConnectionString");
        ds = obDAL.GetDataSetForPrc_SAIM("EditProdData_New", Htparam);

        DataTable dtGrdProduct = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowNoResultFound(dtGrdProduct, GrdProduct);
        }
        else
        {
            GrdProduct.DataSource = ds;
            GrdProduct.DataBind();
        }
    }
    protected void DeleteGrdProduct_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecIdPrd = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        Htparam.Add("@RecID", HdnRecIdPrd.Value.ToString().Trim());
        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelProdWtg", Htparam);
        GetProdData(strmapcode);
    }
    protected void GrdPremiumWeightDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelPremWtg", Htparam);

        GetPremFreq(strmapcode);
    }
    protected void GrdVPSCWeightDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        string strcmpcode = Request.QueryString["CMPNSTN_CODE"].ToString();
        string RuleSetKey = Request.QueryString["RuleSetKey"].ToString();//CNTST_CODE
        string strcntstcode = Request.QueryString["CNTST_CODE"].ToString();

        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelVpscWtg", Htparam);

        //GetPremFreq(strmapcode);
        GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);
    }
    protected void dgDateDefDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelDateRelDefn", Htparam);

        GetDateRelDefn(strmapcode, dgDateDef, "P");
    }
    protected void GetDateRelDefn(string strmapcode, GridView dg, string datetype)
    {
        DataSet dsDate = new DataSet();
        dsDate.Clear();
        Htparam.Clear();

        Htparam.Add("@MapCode", strmapcode);
        Htparam.Add("@Datetype", datetype);
        //dsDate = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
        dsDate = obDAL.GetDataSetForPrc_SAIM("Prc_getMST_DateRelatedDefData", Htparam);
        dg.DataSource = dsDate;
        dg.DataBind();

        if (dsDate.Tables.Count > 0)
        {
            if (dsDate.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                DataTable dt2 = dsDate.Tables[0];
                ShowNoResultFound(dt2, dg);
            }
        }
    }


    protected void GetPremFreq(string strmapcode)
    {
        DataSet dsPrem = new DataSet();

        Htparam.Clear();
        dsPrem.Clear();
        Htparam.Add("@MapCode", strmapcode);
        //dsPrem = obDAL.GetDataSetForPrcDBConn("Prc_EditPremiumFreq", Htparam, "SAIMConnectionString");
        dsPrem = obDAL.GetDataSetForPrc_SAIM("Prc_EditPremiumFreq", Htparam);
        GrdPremiumWeight.DataSource = dsPrem;
        GrdPremiumWeight.DataBind();
        if (dsPrem.Tables.Count > 0)
        {
            if (dsPrem.Tables[0].Rows.Count > 0)
            {
                GrdPremiumWeight.DataSource = dsPrem;
                GrdPremiumWeight.DataBind();
                if (GrdPremiumWeight.PageCount > Convert.ToInt32(txtpreGrdPremiumW.Text))
                {
                    btnnextGrdPremiumW.Enabled = true;
                }
                else
                {
                    btnnextGrdPremiumW.Enabled = false;
                }
            }
            else
            {
                DataTable dt = dsPrem.Tables[0];
                ShowNoResultFound(dt, GrdPremiumWeight);
                txtpreGrdPremiumW.Text = "1";
                btnpreGrdPremiumW.Enabled = false;
                btnnextGrdPremiumW.Enabled = false;
            }
        }
        ViewState["GrdPremiumWeight"] = dsPrem.Tables[0];
    }

    protected void GetVPSCFreq(string strmapcode, string strcmpcode, string RuleSetKey, string strcntstcode)
    {
        DataSet dsPrem = new DataSet();

        Htparam.Clear();
        dsPrem.Clear();
        Htparam.Add("@MapCode", strmapcode);

        Htparam.Add("@cmpcode", strcmpcode);
        Htparam.Add("@cntstcode", strcntstcode);
        //dsPrem = obDAL.GetDataSetForPrcDBConn("Prc_EditVPSCFreq", Htparam, "SAIMConnectionString");
        dsPrem = obDAL.GetDataSetForPrc_SAIM("Prc_EditVPSCFreq", Htparam);
        GrdVPSWeight.DataSource = dsPrem;
        GrdVPSWeight.DataBind();
        if (dsPrem.Tables.Count > 0)
        {
            if (dsPrem.Tables[0].Rows.Count > 0)
            {
                GrdVPSWeight.DataSource = dsPrem;
                GrdVPSWeight.DataBind();
                if (GrdVPSWeight.PageCount > Convert.ToInt32(txtpreGrdPremiumW.Text))
                {
                    btnnextGrdPremiumW.Enabled = true;
                }
                else
                {
                    btnnextGrdPremiumW.Enabled = false;
                }
            }
            else
            {
                DataTable dt = dsPrem.Tables[0];
                ShowNoResultFound(dt, GrdVPSWeight);
                txtpreGrdPremiumW.Text = "1";
                btnpreGrdPremiumW.Enabled = false;
                btnnextGrdPremiumW.Enabled = false;
            }
        }
        ViewState["GrdVPSWeight"] = dsPrem.Tables[0];
    }


    protected void GrdPremiumWeight_Sorting(object sender, GridViewSortEventArgs e)
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
        DataTable dt = (DataTable)ViewState["GrdPremiumWeight"];

        DataView dv = new DataView(dt);


        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {

            dv.Sort += " DESC";
        }
        if (dt.Rows.Count == 1)
        {
            ViewState["GrdPremiumWeight"] = null;
            ShowNoResultFound(dt, GrdPremiumWeight);
        }
        else
        {
            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
        }
        if (dgSource.PageCount >= Convert.ToInt32(txtpreGrdPremiumW.Text))
        {
            if (dgSource.PageCount == 1)
            {
                btnpreGrdPremiumW.Enabled = false;
                txtpreGrdPremiumW.Text = "1";
                btnnextGrdPremiumW.Enabled = false;
            }
            else
            {
                btnpreGrdPremiumW.Enabled = false;
                btnnextGrdPremiumW.Enabled = true;
            }
        }
        else
        {
            btnnextGrdPremiumW.Enabled = false;
        }
        /////ShowPageInformation();
        ViewState["GrdPremiumWeight"] = null;
    }
    protected void btnpreGrdPremiumW_Click(object sender, EventArgs e)
    {

        try
        { //bbbbb
            int pageIndex = GrdPremiumWeight.PageIndex;
            GrdPremiumWeight.PageIndex = pageIndex - 1;
            GetPremFreq(strmapcode);
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            //BindRevHistGrid(lblCompCodeVal.Text.ToString());
            txtpreGrdPremiumW.Text = Convert.ToString(Convert.ToInt32(txtpreGrdPremiumW.Text) - 1);
            if (txtpreGrdPremiumW.Text == "1")
            {
                btnpreGrdPremiumW.Enabled = false;
            }
            else
            {
                btnpreGrdPremiumW.Enabled = true;
            }
            btnnextGrdPremiumW.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnpreGrdPremiumW_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnprevmem_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgMemDt.PageIndex;
            dgMemDt.PageIndex = pageIndex - 1;
            GetDateRelDefn(strmapcode, dgMemDt, "A");
            txtMemPage.Text = Convert.ToString(Convert.ToInt32(txtpreGrdPremiumW.Text) - 1);
            if (txtMemPage.Text == "1")
            {
                btnprevmem.Enabled = false;
            }
            else
            {
                btnprevmem.Enabled = true;
            }
            btnnextGrdPremiumW.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnprevmem_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnextmem_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgMemDt.PageIndex;
            dgMemDt.PageIndex = pageIndex + 1;
            GetDateRelDefn(strmapcode, dgMemDt, "A");
            txtMemPage.Text = Convert.ToString(Convert.ToInt32(txtMemPage.Text) + 1);
            btnprevmem.Enabled = true;
            if (txtMemPage.Text == Convert.ToString(dgMemDt.PageCount))
            {
                btnnextmem.Enabled = false;
            }
            int page = dgMemDt.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnnextmem_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnnextGrdPremiumW_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GrdPremiumWeight.PageIndex;
            GrdPremiumWeight.PageIndex = pageIndex + 1;
            GetPremFreq(strmapcode);
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtpreGrdPremiumW.Text = Convert.ToString(Convert.ToInt32(txtpreGrdPremiumW.Text) + 1);
            btnpreGrdPremiumW.Enabled = true;
            if (txtpreGrdPremiumW.Text == Convert.ToString(GrdPremiumWeight.PageCount))
            {
                btnnextGrdPremiumW.Enabled = false;
            }
            int page = GrdPremiumWeight.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnnextGrdPremiumW_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void GetProdData(string strmapcode)
    {
        DataSet dsProd = new DataSet();
        dsProd.Clear();
        Htparam.Clear();
        Htparam.Add("@MapCode", strmapcode);

        if (Request.QueryString["KPIMode"] != null && Request.QueryString["KPIMode"].ToString().Trim() == "KPISet")
        {
            Htparam.Add("@CYCLE_CODE", "");
            Htparam.Add("@RuleSetKey", Request.QueryString["RuleSetKey"].ToString().Trim());
            if (Request.QueryString["KPITrgt"] != null)
            {
                if (Request.QueryString["KPITrgt"].ToString().Trim() == "R")
                {
                    Htparam.Add("@MEM_CODE", "");
                }
            }
        }
        else
        {
            Htparam.Add("@CYCLE_CODE", Convert.ToString(Request.QueryString["CYCLE"]));
            Htparam.Add("@RuleSetKey", Convert.ToString(Request.QueryString["RuleSetKey"]));
            if (Convert.ToString(Request.QueryString["KPITrgt"]) == "R")
            {
                Htparam.Add("@MEM_CODE", Convert.ToString(Request.QueryString["Memcode"]));
            }
        }
        //dsProd = obDAL.GetDataSetForPrcDBConn("EditProdData", Htparam, "SAIMConnectionString");
        //dsProd = obDAL.GetDataSetForPrcDBConn("EditProdData_New", Htparam, "SAIMConnectionString");
        dsProd = obDAL.GetDataSetForPrc_SAIM("EditProdData_New", Htparam);
        if (dsProd.Tables.Count > 0)
        {
            if (dsProd.Tables[0].Rows.Count > 0)
            {
                GrdProduct.DataSource = dsProd;
                GrdProduct.DataBind();

                GrdProduct.Columns[4].Visible = false;
                GrdProduct.Columns[5].Visible = false;
                GrdProduct.Columns[6].Visible = false;
                GrdProduct.Columns[7].Visible = false;
                GrdProduct.Columns[8].Visible = false;
                GrdProduct.Columns[9].Visible = false;
                GrdProduct.Columns[10].Visible = false;
                GrdProduct.Columns[11].Visible = false;
                GrdProduct.Columns[12].Visible = false;

                if (GrdProduct.PageCount > Convert.ToInt32(txtGrdProduct.Text))
                {
                    btnnextGrdProduct.Enabled = true;
                }
                else
                {
                    btnnextGrdProduct.Enabled = false;
                }
            }
            else
            {
                DataTable dt3 = dsProd.Tables[0];
                ShowNoResultFound(dt3, GrdProduct);
                txtGrdProduct.Text = "1";
                btnpreGrdProduct.Enabled = false;
                btnnextGrdProduct.Enabled = false;
                GrdProduct.Columns[4].Visible = false;
                GrdProduct.Columns[5].Visible = false;
                GrdProduct.Columns[6].Visible = false;
                GrdProduct.Columns[7].Visible = false;
                GrdProduct.Columns[8].Visible = false;
                GrdProduct.Columns[9].Visible = false;
                GrdProduct.Columns[10].Visible = false;
                GrdProduct.Columns[11].Visible = false;
                GrdProduct.Columns[12].Visible = false;

            }
        }
        ViewState["GrdProduct"] = dsProd.Tables[0];
    }
    protected void GrdProduct_Sorting(object sender, GridViewSortEventArgs e)
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
        DataTable dt = (DataTable)ViewState["GrdProduct"];
        DataView dv = new DataView(dt);

        dv.Sort = dgSource.Attributes["SortExpression"];
        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }
        if (dt.Rows.Count == 1)
        {
            ShowNoResultFound(dt, GrdPremiumWeight);
        }
        else
        {
            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
        }

        if (dgSource.PageCount >= Convert.ToInt32(txtpreGrdPremiumW.Text))
        {
            if (dgSource.PageCount == 1)
            {
                btnpreGrdProduct.Enabled = false;
                txtGrdProduct.Text = "1";
                btnnextGrdProduct.Enabled = false;
            }
            else
            {
                btnpreGrdProduct.Enabled = false;
                btnnextGrdProduct.Enabled = true;
            }
        }
        else
        {
            btnnextGrdProduct.Enabled = false;
        }
        /////ShowPageInformation();
    }

    protected void btnpreGrdProduct_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = GrdProduct.PageIndex;
            GrdProduct.PageIndex = pageIndex - 1;
            GetProdData(Request.QueryString["mapcode"].ToString());
            txtGrdProduct.Text = Convert.ToString(Convert.ToInt32(txtGrdProduct.Text) - 1);
            if (txtGrdProduct.Text == "1")
            {
                btnpreGrdProduct.Enabled = false;
            }
            else
            {
                btnpreGrdProduct.Enabled = true;
            }
            btnnextGrdProduct.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnpreGrdProduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextGrdProduct_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GrdProduct.PageIndex;
            GrdProduct.PageIndex = pageIndex + 1;
            GetProdData(Request.QueryString["mapcode"].ToString());
            txtGrdProduct.Text = Convert.ToString(Convert.ToInt32(txtGrdProduct.Text) + 1);
            btnpreGrdProduct.Enabled = true;
            if (txtGrdProduct.Text == Convert.ToString(GrdProduct.PageCount))
            {
                btnnextGrdProduct.Enabled = false;
            }
            int page = GrdProduct.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "FFcontestPageStdDef", "btnnextGrdProduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetMemberDates(string KPICode, string strmapcode)
    {
        string[] arr = new string[] { "10000007", "10000008", "10000009", "10000010" };
        int c = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (KPICode == arr[i].Trim())
            {
                c = 1;
            }
        }
        if (c == 1)
        {
            divAgtDt.Visible = true;
            /////divAgtDt.Attributes.Add("display", "block");
            GetDateRelDefn(strmapcode, dgMemDt, "A");
        }
        else
        {
            divAgtDt.Visible = false;
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        FillDateMemRel("A", dgMemDt);
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelDateRelDefn", Htparam);

        GetDateRelDefn(strmapcode, dgMemDt, "A");
    }

    protected void btnCancelAll_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["KpiCode"] != null)
        {
            if (Convert.ToString(Request.QueryString["role"]) == "admin")
            {
                Response.Redirect("../KPISetup.aspx?flag=E&KPICode=" + Convert.ToString(Request.QueryString["KpiCode"]), false);
            }
            else
            {
                Response.Redirect("../Customisation/Std_Dfntn_Action_Value_Setup.aspx", false);
            }
            //Response.Redirect(hdnBackUrl.Value, false);
        }
        else
        {
            if (Request.QueryString["RSetKey"] != null)
            {
                Response.Redirect("../CntstStp.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + lblCntstCdVal.Text.ToString().Trim()
                    + "&RSetKey=" + Request.QueryString["RSetKey"].ToString().Trim(), true);
            }
            else
            {
                Response.Redirect("../CntstStp.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + lblCntstCdVal.Text.ToString().Trim(), true);
            }
        }
    }

    protected void FillDateMemRel(string type, GridView grd)
    {
        string strmapcode = "";
        if (Request.QueryString["KpiCode"] != null)
        {
            strmapcode = Request.QueryString["mapcode"].ToString();
        }
        else
        {
            string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
            string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();
            strmapcode = Request.QueryString["mapcode"].ToString();
        }
        DataSet ds = new DataSet();
        Htparam.Clear();
        Htparam.Add("@MapCode", strmapcode);
        Htparam.Add("@Datetype", type.ToString().Trim());
        //ds = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_getMST_DateRelatedDefData", Htparam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = ds;
            grd.DataBind();
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], grd);
        }
    }
    protected void lnkSplit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsAcc = new DataSet();
            Hashtable htAcc = new Hashtable();
            string ddlAccYear = "";
            string txtEffDtFrm = "";
            string txtEffDtTo = "";
            string BUSI_YEAR = "";
            dsAcc.Clear();
            htAcc.Clear();
            htAcc.Add("@cmpcode", lblCompCodeVal.Text);

            dsAcc = obDAL.GetDataSetForPrc_SAIM("Prc_GetAccAccrRewardDtls", htAcc);
            {
                if (dsAcc.Tables[0].Rows.Count > 0)
                {
                    ddlAccYear = dsAcc.Tables[0].Rows[0]["ACC_YEAR"].ToString();
                    txtEffDtFrm = dsAcc.Tables[0].Rows[0]["EFF_FROM"].ToString();
                    txtEffDtTo = dsAcc.Tables[0].Rows[0]["EFF_TO"].ToString();
                    BUSI_YEAR = dsAcc.Tables[0].Rows[0]["BUSI_YEAR"].ToString();

                }

            }

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle();", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycleDef('" + lblCompCodeVal.Text.ToString().Trim() + "');", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle('" + lblCompCodeVal.Text.ToString().Trim() + "','" + ddlAccCyc.SelectedValue.ToString().Trim() + "','" + GetCycleDetails("CYCLE_TYPE", "23") + "','" + ddlAccYear + "','" + txtEffDtFrm.Trim() + "','" + txtEffDtTo + "','" + txtRuleSetKey.Text.ToString() + "','" + lblCntstCdVal.Text.ToString() + "','" + BUSI_YEAR + "');", true);

            string url = "Date_Cycle_Defination_Split_Def.aspx?cmpcode=" + lblCompCodeVal.Text.ToString().Trim() + "&effdatefrom=" + txtEffDtFrm.Trim() + "&effdateto=" + txtEffDtTo.Trim() + "&CYCLE=" + Request.QueryString["CYCLE"].ToString().Trim() + "&rulesetcode=" + Request.QueryString["RuleSetKey"].ToString().Trim() + "&cntstcode=" + Request.QueryString["CNTST_CODE"].ToString().Trim();
            string s = "window.open('" + url + "', 'popup_window', 'width=1200,height=600,left=70,top=40,bottom=80,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFcontestPageStdDef", "lnkSplit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnproduct_Click(object sender, EventArgs e)
    {
        try
        {
            string map = "";
            string ACT_TYPE = "1001";
            string KPI_CODE = String.Join("", Convert.ToString(Request.QueryString["KpiCode"]).Split(new char[] { '-' }));
            if (!chkKpiMst.Checked)
            {
                map = Request.QueryString["mapcode"].ToString();
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("@CNTSTNT_CODE", Convert.ToString(Request.QueryString["CNTST_CODE"]));
                ht.Add("@CMPNSTN_CODE", Convert.ToString(Request.QueryString["CMPNSTN_CODE"]));
                DataSet ds = objDAL.GetDataSetForPrc("PRC_GET_CHNL_DTLS", ht);

                string BIZSRC = Convert.ToString(ds.Tables[0].Rows[0]["CHN"]);
                string SUBCHNL = Convert.ToString(ds.Tables[0].Rows[0]["CHNCLS"]);
                string MEMTYPE = Convert.ToString(ds.Tables[0].Rows[0]["MEMTYPE"]);
                map = SaveKPI_MAP_Details(BIZSRC, SUBCHNL, MEMTYPE, KPI_CODE, "2002");

                Hashtable htnew = new Hashtable();
                htnew.Add("@PARENT_CODE", map);
                htnew.Add("@CHILD_CODE", Request.QueryString["mapcode"].ToString());
                htnew.Add("@ACT_TYP", "1001");
                //Added BY Pratik
                htnew.Add("@IS_SPLT", ddlSplit.SelectedValue);
                //Added BY Pratik
                objDAL.GetDataSetForPrc("PRC_INS_MST_STD_DEF_INHT_MAP", htnew);
            }
            Response.Redirect("../Customisation/MSTACTSU.aspx?role=" + Convert.ToString(Request.QueryString["role"]) + "&mapcode=" + map + "&kpicode=" + KPI_CODE + "&ACT_TYPE=" + ACT_TYPE, false);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFcontestPageStdDef", "btnproduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public string SaveKPI_MAP_Details(string channel, string subchnl, string memtype, string kpi, string flag)
    {
        string mapcode = "";
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("BIZSRC", channel);
            ht.Add("CHNCLS", subchnl);
            ht.Add("MEMTYPE", memtype);
            ht.Add("KPI_CODE", kpi);
            ht.Add("@FLAG", flag);
            ht.Add("CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            DataSet ds = objDAL.GetDataSetForPrc("PRC_Ins_MST_STDDEFNTN", ht);
            mapcode = Convert.ToString(ds.Tables[0].Rows[0][0]);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFcontestPageStdDef", "SaveKPI_MAP_Details", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return mapcode;
    }

    //Added by Pratik
    public void StdDefinationPrep()
    {
        btn_Download.Visible = false;
        btnDwnUpd.Visible = false;
        btnDownloadData.Visible = false;
        divcmpmain.Visible = false;
        div1.Visible = false;
        div12.Visible = false;
        div8.Visible = false;
        div5.Visible = false;
        btnproduct.Text = "Continue For Product Weightages Setup";
        rowselect.Visible = false;
    }

    protected void btnMPL_Click(object sender, EventArgs e)
    {
        string map = Request.QueryString["mapcode"].ToString();
        string ACT_TYPE = "1002";
        string KPI_CODE = String.Join("", Convert.ToString(Request.QueryString["KpiCode"]).Split(new char[] { '-' }));
        Response.Redirect("../Customisation/MSTACTSU.aspx?role=" + Convert.ToString(Request.QueryString["role"])
            + "&mapcode=" + map + "&kpicode=" + KPI_CODE + "&ACT_TYPE=" + ACT_TYPE, false);
    }
    //Added by Pratik
    
    //Added by Abuzar Siddiqui on 24/07/2020 Starts  
    public void InheritedAction()
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            ht.Add("@Chncls", Request.QueryString["chncls"].ToString().Trim());
            ht.Add("@Memtype", Request.QueryString["memtype"].ToString().Trim());
            ht.Add("@Kpi_code", Request.QueryString["KpiCode"].ToString().Trim());
            ds = obDAL.GetDataSetForPrc_SAIM("PRC_GETMAPCODEFORSETRULE", ht);
            string mapcodeinherited = "";
            if (ds.Tables.Count > 0)
            {

                mapcodeinherited = ds.Tables[0].Rows[0]["MAP_CODE"].ToString();

            }
            DataSet dsfinalProd = new DataSet();
            Hashtable htfinalProd = new Hashtable();
            dsfinalProd.Clear();
            htfinalProd.Clear();
            htfinalProd.Add("@mappedcode", mapcodeinherited.ToString().Trim());
            dsfinalProd = obDAL.GetDataSetForPrc_SAIM("PRC_GETACTIONCODEFORSETRULE", htfinalProd);
            if (dsfinalProd.Tables.Count > 0 && dsfinalProd.Tables[0].Rows.Count > 0)
            {
                ddlinheritedProd.DataSource = dsfinalProd;
                ddlinheritedProd.DataTextField = dsfinalProd.Tables[0].Columns[1].ToString().Trim();
                ddlinheritedProd.DataValueField = dsfinalProd.Tables[0].Columns[0].ToString().Trim();
                ddlinheritedProd.DataBind();
            }

            ddlinheritedProd.Items.Insert(0, new ListItem("-- SELECT --", ""));

            DataSet dsfinalMPL = new DataSet();
            Hashtable htfinalMPL = new Hashtable();
            htfinalMPL.Clear();
            htfinalMPL.Clear();
            htfinalMPL.Add("@mappedcode", mapcodeinherited.ToString().Trim());
            dsfinalMPL = obDAL.GetDataSetForPrc_SAIM("PRC_GETACTIONCODEFORSETRULE_MPL", htfinalProd);
            if (dsfinalMPL.Tables.Count > 0 && dsfinalMPL.Tables[0].Rows.Count > 0)
            {
                ddlinheritedMPL.DataSource = dsfinalMPL;
                ddlinheritedMPL.DataTextField = dsfinalMPL.Tables[0].Columns[1].ToString().Trim();
                ddlinheritedMPL.DataValueField = dsfinalMPL.Tables[0].Columns[0].ToString().Trim();
                ddlinheritedMPL.DataBind();
            }

            ddlinheritedMPL.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "InheritedAction", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //Added by Abuzar Siddiqui on 24/07/2020 End

    protected void btnAddProdweightages_click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            ht.Add("@Chncls", Request.QueryString["chncls"].ToString().Trim());
            ht.Add("@Memtype", Request.QueryString["memtype"].ToString().Trim());
            ht.Add("@Kpi_code", Request.QueryString["KpiCode"].ToString().Trim());
            ds = obDAL.GetDataSetForPrc_SAIM("PRC_GETMAPCODEFORSETRULE", ht);
            string mapcodeinheritedAddProd = "";
            if (ds.Tables.Count > 0)
            {

                mapcodeinheritedAddProd = ds.Tables[0].Rows[0]["MAP_CODE"].ToString();

            }
            DataSet dsAddProd = new DataSet();
            Hashtable htAddProd = new Hashtable();
            dsAddProd.Clear();
            htAddProd.Clear();
            htAddProd.Add("@PARENT_CODE", mapcodeinheritedAddProd.ToString().Trim());
            htAddProd.Add("@MAP_CODE", Request.QueryString["mapcode"].ToString().Trim());
            htAddProd.Add("@ACT_TYP","1001");
            if (ddlinheritedProd.SelectedIndex == 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Action description');", true);
                //return;
                Response.Redirect(Page.Request.Url.AbsoluteUri);

            }
            else
            {
                htAddProd.Add("@ACT_NO", ddlinheritedProd.SelectedValue.ToString().Trim());
            }
            htAddProd.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            {
                ds = obDAL.GetDataSetForPrc_SAIM("PRC_INS_MST_STD_DEF_ACT_INHT_MAP", htAddProd);
            }            
            //Response.Redirect("../RuleSetPages/FFContestPageStdDef.aspx?role=" + Convert.ToString(Request.QueryString["role"]) + "&mapcode=" + Convert.ToString(Request.QueryString["mapcode"]) + "&flag=" + Convert.ToString(Request.QueryString["flag"]), false);
            Response.Redirect(Page.Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "btnAddProdweightages_click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAddMPL_click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            ht.Add("@Chncls", Request.QueryString["chncls"].ToString().Trim());
            ht.Add("@Memtype", Request.QueryString["memtype"].ToString().Trim());
            ht.Add("@Kpi_code", Request.QueryString["KpiCode"].ToString().Trim());
            ds = obDAL.GetDataSetForPrc_SAIM("PRC_GETMAPCODEFORSETRULE", ht);
            string mapcodeinheritedMPL = "";
            if (ds.Tables.Count > 0)
            {

                mapcodeinheritedMPL = ds.Tables[0].Rows[0]["MAP_CODE"].ToString();

            }
            DataSet dsAddMPL = new DataSet();
            Hashtable htAddMPL = new Hashtable();
            dsAddMPL.Clear();
            htAddMPL.Clear();
            htAddMPL.Add("@PARENT_CODE", mapcodeinheritedMPL.ToString().Trim());
            htAddMPL.Add("@MAP_CODE", Request.QueryString["mapcode"].ToString().Trim());
            htAddMPL.Add("@ACT_TYP", "1002");
            if (ddlinheritedMPL.SelectedIndex == 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Action description');", true);
                //return;
                Response.Redirect(Page.Request.Url.AbsoluteUri);
            }
            else
            {
                htAddMPL.Add("@ACT_NO", ddlinheritedMPL.SelectedValue.ToString().Trim());
            }
            htAddMPL.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ds = obDAL.GetDataSetForPrc_SAIM("PRC_INS_MST_STD_DEF_ACT_INHT_MAP", htAddMPL);
            Response.Redirect(Page.Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "btnAddProdweightages_click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgProdweightages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "dgProdweightages_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void GetProdweightages(GridView dg)
    {
        try
        {
            DataSet dsAPS = new DataSet();
            Hashtable htAPS = new Hashtable();
            dsAPS.Clear();
            htAPS.Clear();
            htAPS.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            htAPS.Add("@Chncls", Request.QueryString["chncls"].ToString().Trim());
            htAPS.Add("@Memtype", Request.QueryString["memtype"].ToString().Trim());
            htAPS.Add("@Kpi_code", Request.QueryString["KpiCode"].ToString().Trim());
            dsAPS = obDAL.GetDataSetForPrc_SAIM("PRC_GETMAPCODEFORSETRULE", htAPS);
            string mapcodeinheritedAddProd = "";
            if (dsAPS.Tables.Count > 0)
            {

                mapcodeinheritedAddProd = dsAPS.Tables[0].Rows[0]["MAP_CODE"].ToString();

            }
            DataSet dsDate = new DataSet();
            dsDate.Clear();
            Htparam.Clear();

            Htparam.Add("@MAP_CODE", mapcodeinheritedAddProd.ToString().Trim());
            Htparam.Add("@ACT_TYP", "1001");
            //dsDate = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
            dsDate = obDAL.GetDataSetForPrc_SAIM("PRC_GET_MST_STD_DEF_ACT_INHT_MAP", Htparam);
            dg.DataSource = dsDate;
            dg.DataBind();

            if (dsDate.Tables.Count > 0)
            {
                if (dsDate.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    DataTable dt3 = dsDate.Tables[0];
                    ShowNoResultFound(dt3, dg);
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetProdweightages", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgMPL_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "dgProdweightages_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void GetMPLGrigview(GridView dg)
    {
        try
        {
            DataSet dsMPS = new DataSet();
            Hashtable htMPS = new Hashtable();
            dsMPS.Clear();
            htMPS.Clear();
            htMPS.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            htMPS.Add("@Chncls", Request.QueryString["chncls"].ToString().Trim());
            htMPS.Add("@Memtype", Request.QueryString["memtype"].ToString().Trim());
            htMPS.Add("@Kpi_code", Request.QueryString["KpiCode"].ToString().Trim());
            dsMPS = obDAL.GetDataSetForPrc_SAIM("PRC_GETMAPCODEFORSETRULE", htMPS);
            string mapcodeinheritedMPL = "";
            if (dsMPS.Tables.Count > 0)
            {

                mapcodeinheritedMPL = dsMPS.Tables[0].Rows[0]["MAP_CODE"].ToString();

            }
            DataSet dsDate = new DataSet();
            dsDate.Clear();
            Htparam.Clear();

            Htparam.Add("@MAP_CODE", mapcodeinheritedMPL.ToString().Trim());
            Htparam.Add("@ACT_TYP", "1002");
            //dsDate = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
            dsDate = obDAL.GetDataSetForPrc_SAIM("PRC_GET_MST_STD_DEF_ACT_INHT_MAP", Htparam);
            dg.DataSource = dsDate;
            dg.DataBind();

            if (dsDate.Tables.Count > 0)
            {
                if (dsDate.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    DataTable dt3 = dsDate.Tables[0];
                    ShowNoResultFound(dt3, dg);
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetMPLGrigview", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_Isys_Saim_Masters_MstTDSExemption : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            string sUserId = HttpContext.Current.Session["UserID"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["ACT_TYPE"] != null)
                {
                    if (Request.QueryString["ACT_TYPE"].ToString().Trim() == "RPRT")
                    {
                        ddlFinYr.Text = Request.QueryString["CMP_CODE"].ToString().Trim();
                        btnSearch_Click(sender, e);
                    }
                }
                txtPage.Text = "1";
                Hashtable ht = new Hashtable();
                ht.Add("@bizsrc", "AG");
                FillDropDowns(txtMemberCode, "24", "Prc_FillMemCode", ht);
                ht.Clear();
                ht.Add("@Flag", "15");
                ht.Add("@TYPFLG", "");
                ht.Add("@YEAR_TYPE", "FY");
                ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
                FillDropDowns(ddlFinYr, "24", "Prc_FillMstVals_TDS ", ht);
                ht.Clear();
                ht.Add("@LookupCode", "PST");
                FillDropDowns(ddlPanStatus, "24", "Prc_GetLookValDESC", ht);
                ht.Clear();
                ht.Add("@LookupCode", "ENT");
                FillDropDowns(ddlEntityTyp, "24", "Prc_GetLookValDESC", ht);
                //FillMemcode();
                ht.Clear();
                ht.Add("@Flag", "15");
                ht.Add("@TYPFLG", "");
                ht.Add("@YEAR_TYPE", "FY");
                ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
                FillDropDowns(ddlFinancialYear, "24", "Prc_FillMstVals_TDS ", ht);
                ht.Clear();
                ht.Add("@LookupCode", "PST");
                FillDropDowns(ddlPanSt, "24", "Prc_GetLookValDESC", ht);
                ht.Clear();
                ht.Add("@LookupCode", "ENT");
                FillDropDowns(ddlEntityType, "24", "Prc_GetLookValDESC", ht);
                ht.Clear();
                ht.Add("@LookupCode", "EXMPTNCDE");
                FillDropDowns(ddlExempCode, "24", "Prc_GetLookValDESC", ht);
                ddlFinancialYear.Items.Insert(0, new ListItem("Select", ""));
                ddlPanSt.Items.Insert(0, new ListItem("Select", ""));
                ddlEntityType.Items.Insert(0, new ListItem("Select", ""));
                ddlExmCode.Items.Insert(0, new ListItem("Select", ""));
                ht.Clear();
                ht.Add("@LookupCode", "EXMPTNCDE");
                FillDropDowns(ddlExmCode, "24", "Prc_GetLookValDESC", ht);
                if (Request.QueryString["CmpTyp"] != null)
                {
                    ht.Clear();
                    ht.Add("@LookupCode", "PickedByXI");
                    FillDropDowns(ddlPanStatus, "24", "Prc_GetLookValDESC", ht);
                    ht.Clear();
                }
                ddlFinYr.Items.Insert(0, new ListItem("Select", ""));
                ddlPanStatus.Items.Insert(0, new ListItem("Select", ""));
                ddlEntityTyp.Items.Insert(0, new ListItem("Select", ""));
                ddlExmCode.Items.Insert(0, new ListItem("Select", ""));
              
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
                    {
                        txtAppAson.Text = "1006";
                        txtAppAson.Enabled = false;
                    }
                }
                if (Request.QueryString["Mode"] != null)
                {
                    if (Request.QueryString["Mode"].ToString() == "V")
                    {
                        txtAppAson.Text = "1006";
                        txtAppAson.Enabled = false;
                        dgCmp.Columns[8].Visible = false;  
                    }
                }
                GetChannelWiseCompenDesign();
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GetChannelWiseCompenDesign();
            Loading_gif.Style.Add("display", "none");
            divkpisrch.Style.Add("display", "block");
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "btnSearch_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlFinYr.Text = "";
            ddlEntityTyp.Text = "";
            ddlExempCode.Text = "";
            ddlNtrOfPay.SelectedValue = "0";
            ddlExempCode.SelectedValue = "0";
            txtAppAson.Text = "";
            txtAppTo.Text = "";
            txtMemCode.Text = "";
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "btnClear_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(string code, string desc, string type, string status, string flag)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CompCode", code.ToString().Trim());
            htParam.Add("@CompDesc", desc.ToString().Trim());
            htParam.Add("@CompType", type.ToString().Trim());
            htParam.Add("@CompStat", status.ToString().Trim());
            htParam.Add("@Flag", flag.ToString().Trim());
            htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgCmp.DataSource = ds;
                dgCmp.DataBind();
                ViewState["grid"] = ds.Tables[0];
                if (dgCmp.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
            }
            else
            {
                ShowNoResultFound1(ds.Tables[0], dgCmp);
                txtPage.Text = "1";
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgCmp_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
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

            DataTable dt = (DataTable)ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtPage.Text))
            {
                btnprevious.Enabled = false;
                txtPage.Text = "1";
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "dgCmp_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgCmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex - 1;
            GetChannelWiseCompenDesign();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
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
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex + 1;
            GetChannelWiseCompenDesign();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = dgCmp.PageCount;
            if (txtPage.Text == Convert.ToString(dgCmp.PageCount))
            {
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ddlFinYr.Text = "";
        ddlEntityTyp.Text = "";
        txtAppAson.Text = "";
        ddlPanStatus.SelectedValue = "";
    }

    public void FillDropDowns(DropDownList ddl, string val, string ProcedureName, Hashtable ht)
    {
        try
        {
            ddl.Items.Clear();
            drRead = objDal.Common_exec_reader_prc_SAIM(ProcedureName, ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    public void FillDropDowns(DropDownList ddl, string val, string typflg)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetMemTypeDESC", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    

    private void childgridsort(object sender, GridViewSortEventArgs e)
    {
        try
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

            DataTable dt = (DataTable)ViewState["gridcnt"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();


        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "childgridsort", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    
    protected DataTable GetDataRec(string cmpcode)
    {
        DataSet ds2 = new DataSet();

        try
        {
            ds2.Clear();
            htParam.Clear();
            htParam.Add("@CmpCode", cmpcode.ToString().Trim());
            ds2 = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls_NEW", htParam);
            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                return ds2.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "GetDataRec", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return ds2.Tables[0];
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        try
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            int rowsCount = gv.Rows.Count;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[columnsCount - 1].Text = "";
            gv.Rows[0].Cells[columnsCount - 2].Text = "";
            gv.Rows[0].Cells[0].Text = "No contestants have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        try
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            int rowsCount = gv.Rows.Count;
            gv.Rows[0].Cells[columnsCount - 1].Text = "";
            gv.Rows[0].Cells[0].Text = "";
            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[1].Text = "No compensations have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public Hashtable addparameter(TextBox txt, string parameter, Hashtable ht)
    {
        if (txt.Text != "")
        {
            ht.Add(parameter, txt.Text);
        }

        else
        {


        }
        return ht;
    }

    public Hashtable addparameter(DropDownList ddl, string parameter, Hashtable ht)
    {
        if (ddl.SelectedIndex != 0)
        {
            ht.Add(parameter, ddl.SelectedValue.ToString());
        }

        else
        {

        }
        return ht;
    }
    protected void GetChannelWiseCompenDesign()
    {
        try
        {
            Hashtable htPara = new Hashtable();
            ds.Clear();
            htPara.Clear();
            htPara = addparameter(ddlPanStatus, "@PAN_STATUS", htPara);
            htPara = addparameter(ddlFinYr, "@BUSI_CODE", htPara);
            htPara = addparameter(ddlEntityTyp, "@ENTY_TYP", htPara);
            htPara = addparameter(ddlExempCode, "@EXMPTN_CODE", htPara);
            htPara = addparameter(txtAppAson, " @APPLCBL_FRM_DTIM", htPara);
            htPara = addparameter(txtAppTo, "@APPLCBL_TO_DTIM", htPara);
            htPara = addparameter(txtMemCode, "@MEM_CODE", htPara);

            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_TDS_NON_STD_DEF_DTLS", htPara);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgCmp.DataSource = ds;
                dgCmp.DataBind();
                ViewState["grid"] = ds.Tables[0];
                if (dgCmp.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
            }
            else
            {
                ShowNoResultFound1(ds.Tables[0], dgCmp);
                txtPage.Text = "1";
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "GetChannelWiseCompenDesign", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        DataSet dsObds = new DataSet();
        Hashtable htable = new Hashtable();
        htable.Clear();
        htable.Add("@Flag", "INS");
        htable.Add("@BUSI_CODE", Convert.ToInt32(txtBusiCode.Text.Trim()));
        htable.Add("@NTR_OF_PYMNT", ddlNatureOfPayment.SelectedValue.ToString());
        htable.Add("@PAN_STATUS", ddlPanSt.SelectedValue.ToString());
        htable.Add("@ENT_TYP", ddlEntityType.SelectedValue.ToString());
        htable.Add("@COMM_FRM_AMT", txtlblCommAmtFrm.Text.Trim());
        htable.Add("@COMM_TO_AMT", txtlblCommAmtTO.Text.Trim());
        htable.Add("@RATE", Convert.ToDecimal(TxtRate.Text.Trim()));
        htable.Add("@APPLCBLE_FRM_DTIM", DateTime.Parse(TxtApplicableFrom.Text.Trim()));
        htable.Add("@APPLCBLE_TO_DTIM", DateTime.Parse(TxtApplicableTo.Text.Trim()));
        htable.Add("@EXMPTON_CODE", ddlExmCode.SelectedValue.ToString());
        htable.Add("@Flag1", "NS");
        htable.Add("@MEMBER_CODE", txtMemberCode.SelectedItem.Text.ToString());
        dsObds = objDal.GetDataSetForPrc_SAIM("PRC_GvInsExmptnMst", htable);
        GetChannelWiseCompenDesign();
        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Data  Added Successfully.');</script>", false);

    }

    protected void btnCancl_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstTDSExemption.aspx");
    }

    //protected void FillMemcode()
    //{
    //    try
    //    {
    //        Hashtable htParam1 = new Hashtable();
    //        DataSet dsdataset = new DataSet();
    //        dsdataset = objDal.GetDataSetForPrcCommon("Prc_FillMemCode");
    //        if (dsdataset.Tables.Count > 0)
    //        {
    //            txtMemberCode.DataSource = dsdataset;
    //            txtMemberCode.DataValueField = "ParamValue";
    //            txtMemberCode.DataTextField = "ParamDesc";
    //            txtMemberCode.DataBind();
    //        }
    //        txtMemberCode.Items.Insert(0, new ListItem("Select", ""));
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("SAIM_TALIC", "MstTDSExemption", "FillMemcode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

}



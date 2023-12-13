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

public partial class Application_ISys_Saim_PopCycStp : BaseClass
{
    #region Declaration
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            InitializeCntrl();
            if (Request.QueryString["YrCode"] != null)
            {
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        ////GetCycleVal("14");
                        GetCycDtls(Request.QueryString["flag"].ToString().Trim(), Request.QueryString["Type"].ToString().Trim(), Request.QueryString["YrCode"].ToString().Trim());
                        dgMthYr.DataSource = GetMthGrid("M", Request.QueryString["Type"].ToString().Trim());
                        dgMthYr.DataBind();
                        dgQtrYr.DataSource = GetMthGrid("Q", Request.QueryString["Type"].ToString().Trim());
                        dgQtrYr.DataBind();
                        dgHyrYr.DataSource = GetMthGrid("H", Request.QueryString["Type"].ToString().Trim());
                        dgHyrYr.DataBind();
                        dgYear.DataSource = GetMthGrid("A", Request.QueryString["Type"].ToString().Trim());
                        dgYear.DataBind();
                    }
                }
            }
        }
    }

    protected void InitializeCntrl()
    {
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                lblYrCode.Text = "Financial Year Code";
                lblShrtYrDsc.Text = Request.QueryString["Type"].ToString().Trim() + "Short Description";
                lblYrDesc.Text = "Financial Year Description";
                lblbusiyrhdr.Text = "Financial Year Setup";
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lblYrCode.Text = "Calendar Year Code";
                lblShrtYrDsc.Text = Request.QueryString["Type"].ToString().Trim() + "Short Description";
                lblYrDesc.Text = "Calendar Year Desc";
                lblbusiyrhdr.Text = "Calendar Year Setup";
            }
            lblmthyrhdr.Text = "Monthly Cycle Setup";
            lblqtryrhdr.Text = "Quarterly Cycle Setup";
            lblhyrhdr.Text = "Half Yearly Cycle Setup";
            lblyrhdr.Text = "Yearly Cycle Setup";
        }
    }

    protected void GetCycDtls(string flag, string yrtyp, string yrcode)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        htParam.Add("@BUSI_CODE", yrcode.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblYrCodeVal.Text = ds.Tables[0].Rows[0]["BUSI_CODE"].ToString().Trim();
            lblShrtYrDscVal.Text = ds.Tables[0].Rows[0]["SHRT_BUSI_DESC"].ToString().Trim();
            lblYrDescVal.Text = ds.Tables[0].Rows[0]["BUSI_DESC"].ToString().Trim();
            lblStrtDtVal.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            lblEndDtVal.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
        }
    }

    protected DataSet GetMthGrid(string cycflag, string yrtyp)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FromDt", Convert.ToDateTime(lblStrtDtVal.Text.ToString().Trim()));
        htParam.Add("@ToDt", Convert.ToDateTime(lblEndDtVal.Text.ToString().Trim()));
        htParam.Add("@BusiCode", lblYrCodeVal.Text.ToString().Trim());
        htParam.Add("@CycFlag", cycflag.ToString().Trim());
        htParam.Add("@YearType", yrtyp.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMonths", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds;
        }

        return ds;
    }
    
    protected void btnSaveQtr_Click(object sender, EventArgs e)
    {
        InsCycleDtls("Q", dgQtrYr);
        mdlpopup.Show();
        lbl3.Text = "Quarterly cycle setup done successfully";
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                lbl4.Text = "Financial Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Financial Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lbl4.Text = "Calendar Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Calendar Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
        }
    }
    protected void btnSaveHyr_Click(object sender, EventArgs e)
    {
        InsCycleDtls("H", dgHyrYr);
        mdlpopup.Show();
        lbl3.Text = "Half yearly cycle setup done successfully";
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                lbl4.Text = "Financial Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Financial Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lbl4.Text = "Calendar Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Calendar Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
        }
    }
    protected void btnCnclYr_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYearStp.aspx");
    }
    protected void btnSaveMth_Click(object sender, EventArgs e)
    {
        InsCycleDtls("M", dgMthYr);
        mdlpopup.Show();
        lbl3.Text = "Monthly cycle setup done successfully";
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                lbl4.Text = "Financial Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Financial Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lbl4.Text = "Calendar Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Calendar Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
        }
    }

    protected void GetCycleVal(string val)
    {
        ds = new DataSet();
        ds.Clear();
        Hashtable ht = new Hashtable();
        ht.Clear();
        ht.Add("@Flag", val.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_FillMstVals", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            {
                divMonth.Visible = (ds.Tables[0].Rows[i]["CODE"] == "1003" ? true : false);
            }
        }
    }

    protected void InsCycleDtls(string cycle,GridView grd)
    {
        List<string> lstMthCode = new List<string>();
        List<string> lstMthName = new List<string>();
        List<string> lstStrtDt = new List<string>();
        List<string> lstEndDt = new List<string>();
        List<string> lstParCode = new List<string>();
        for (int intRowCount = 0; intRowCount <= grd.Rows.Count - 1; intRowCount++)
        {
            Label lblMthCode = (Label)grd.Rows[intRowCount].Cells[0].FindControl("lblMthCode");
            lstMthCode.Add(lblMthCode.Text.ToString().Trim());
            Label lblparcode = (Label)grd.Rows[intRowCount].Cells[0].FindControl("lblparcode");
            lstParCode.Add(lblparcode.Text.ToString().Trim());
            TextBox lblMthName = (TextBox)grd.Rows[intRowCount].Cells[0].FindControl("lblMthName");
            lstMthName.Add(lblMthName.Text.ToString().Trim().ToUpper());
            TextBox txtStrtDt = (TextBox)grd.Rows[intRowCount].Cells[0].FindControl("txtStrtDt");
            lstStrtDt.Add(txtStrtDt.Text.ToString().Trim());
            TextBox txtEndDt = (TextBox)grd.Rows[intRowCount].Cells[0].FindControl("txtEndDt");
            lstEndDt.Add(txtEndDt.Text.ToString().Trim());
        }
        for (int intDataCount = 0; intDataCount <= lstMthCode.Count - 1; intDataCount++)
        {
            htParam.Clear();
            htParam.Add("@MTH_CODE", lstMthCode[intDataCount]);
            htParam.Add("@MTH_NAME", lstMthName[intDataCount]);
            htParam.Add("@ROOT_BUSI_CODE", lblYrCodeVal.Text.ToString().Trim());
            if (Request.QueryString["Type"] != null)
            {
                htParam.Add("@YEAR_TYPE", Request.QueryString["Type"].ToString().Trim());
            }
            else
            {
                htParam.Add("@YEAR_TYPE", "");
            }
            htParam.Add("@PARENT_CODE", lstParCode[intDataCount]);
            if (lstStrtDt[intDataCount] != "")
            {
                htParam.Add("@START_DT", lstStrtDt[intDataCount]);
            }
            else
            {
                htParam.Add("@START_DT", System.DBNull.Value);
            }
            if (lstEndDt[intDataCount] != "")
            {
                htParam.Add("@END_DT", lstEndDt[intDataCount]);
            }
            else
            {
                htParam.Add("@END_DT", System.DBNull.Value);
            }
            htParam.Add("@CYCLE", cycle.ToString().Trim());
            htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsBusiYrCycles", htParam);
        }
    }
    protected void btnSaveYr_Click(object sender, EventArgs e)
    {
        InsCycleDtls("A", dgYear);
        mdlpopup.Show();
        lbl3.Text = "Yearly cycle setup done successfully";
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                lbl4.Text = "Financial Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Financial Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lbl4.Text = "Calendar Year Code:" + lblYrCodeVal.Text.ToString().Trim();
                lbl5.Text = "Calendar Year Description:" + lblYrDescVal.Text.ToString().Trim();
            }
        }
    }
    protected void btnCnclMth_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYearStp.aspx");
    }
    protected void btnCnclQtr_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYearStp.aspx");
    }
    protected void btnCnclHyr_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYearStp.aspx");
    }
    protected void btnprevyr_Click(object sender, EventArgs e)
    {

    }
    protected void btnextyr_Click(object sender, EventArgs e)
    {

    }
}
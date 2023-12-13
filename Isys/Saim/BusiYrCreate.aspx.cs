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

public partial class Application_ISys_Saim_BusiYrCreate : BaseClass
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
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            InitializeCntrl();
            txtYrCode.Enabled = false;
            
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "N")
                    {
                        GetMaxCode("M");
                    }
                    else if (Request.QueryString["flag"].ToString().Trim() == "E")
                    {
                        if (Request.QueryString["YrCode"] != null)
                        {
                            Search("V", Request.QueryString["YrCode"].ToString().Trim(), Request.QueryString["Type"].ToString().Trim());
                        }
                    }
                }
               
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["flag"] != null)
        {
            Create(Request.QueryString["flag"].ToString().Trim());
            mdlpopup.Show();
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"] == "FY")
                {
                    lbl3.Text = "Financial year saved successfully";
                    lbl4.Text = "Financial Year Code:" + txtYrCode.Text.ToString().Trim();
                    lbl5.Text = "Financial Year Desc:" + txtYrDesc.Text.ToString().Trim();
                }
                if (Request.QueryString["Type"] == "CY")
                {
                    lbl3.Text = "Calendar year saved successfully";
                    lbl4.Text = "Calendar Year Code:" + txtYrCode.Text.ToString().Trim();
                    lbl5.Text = "Calendar Year Desc:" + txtYrDesc.Text.ToString().Trim();
                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYearStp.aspx", true);
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
                Label1.Text = "Financial Year Setup";
                lblchkBusiYr.Text = "Is Current Financial Year";
                txtShrtYrDsc.Attributes["placeholder"] = "FYyyyy-yy";
                txtYrDesc.Attributes["placeholder"] = "FIN YEAR-yyyy-yy";
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                lblYrCode.Text = "Calendar Year Code";
                lblShrtYrDsc.Text = Request.QueryString["Type"].ToString().Trim() + "Short Description";
                lblYrDesc.Text = "Calendar Year Desc";
                Label1.Text = "Calendar Year Setup";
                lblchkBusiYr.Text = "Is Current Calendar Year";
                txtShrtYrDsc.Attributes["placeholder"] = "CYyyyy-yy";
                txtYrDesc.Attributes["placeholder"] = "CAL YEAR-yyyy-yy";
            }
        }
    }

    protected void GetDates()
    {
        string type = String.Empty;
        string year1 = String.Empty;
        string year2 = String.Empty;
        string date = String.Empty;
        date = txtShrtYrDsc.Text.ToString().Trim();
        type = date.Substring(1, 2);
        year1 = date.Substring(3, 4);
        year2 = (Convert.ToInt32(year1.ToString().Trim()) + 1).ToString().Trim();
        
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "FY")
            {
                txtStrtDt.Text = "01/04/" + year1.ToString().Trim();
                txtEndDt.Text = "31/03/" + year2.ToString().Trim();
            }
            else if (Request.QueryString["Type"] == "CY")
            {
                txtStrtDt.Text = "01/01/" + year1.ToString().Trim();
                txtEndDt.Text = "31/12/" + year1.ToString().Trim();
            }
        }
    }

    protected void GetMaxCode(string flag)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtYrCode.Text = ds.Tables[0].Rows[0]["MAXCODE"].ToString().Trim();
        }
    }

    protected void Create(string flag)
    {
        ds.Clear(); 
        htParam.Clear();
        htParam.Add("@BUSI_CODE", txtYrCode.Text.ToString().Trim());
        htParam.Add("@SHRT_BUSI_DESC", txtShrtYrDsc.Text.ToString().Trim());
        htParam.Add("@BUSI_DESC", txtYrDesc.Text.ToString().Trim());
        if (txtStrtDt.Text != "")
        {
            htParam.Add("@START_DATE", Convert.ToDateTime(txtStrtDt.Text.ToString().Trim())); 
        }
        else
        {
            htParam.Add("@START_DATE", System.DBNull.Value); 
        }
        if (txtEndDt.Text != "")
        {
            htParam.Add("@END_DATE", Convert.ToDateTime(txtEndDt.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@END_DATE", System.DBNull.Value);
        }
        if (chkBusiYr.Checked == true)
        {
            htParam.Add("@IS_CURRENTYEAR", "1");
        }
        else if (chkBusiYr.Checked == false)
        {
            htParam.Add("@IS_CURRENTYEAR", "0");
        }
        if (Request.QueryString["Type"] != null)
        {
            htParam.Add("@YEAR_TYPE", Request.QueryString["Type"].ToString().Trim());
        }
        htParam.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
    }

    protected void Search(string flag, string yrcode, string yrtyp)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@BUSI_CODE", yrcode.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtYrCode.Text = ds.Tables[0].Rows[0]["BUSI_CODE"].ToString().Trim();
            txtShrtYrDsc.Text = ds.Tables[0].Rows[0]["SHRT_BUSI_DESC"].ToString().Trim();
            txtYrDesc.Text = ds.Tables[0].Rows[0]["BUSI_DESC"].ToString().Trim();
            txtStrtDt.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtEndDt.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
            string check = ds.Tables[0].Rows[0]["IS_CURRENTYEAR"].ToString().Trim();
            if (check == "0")
            {
                chkBusiYr.Checked = false;
            }
            else if (check == "1")
            {
                chkBusiYr.Checked = true;
            }
        }
    }
}
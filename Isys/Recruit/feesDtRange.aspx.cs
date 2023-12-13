using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Collections;
using DataAccessClassDAL;
using INSCL.App_Code;
public partial class Application_ISys_Recruit_feesDtRange : BaseClass
{

    private DataAccessClass dataAccessRecruit = new DataAccessClass();
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

                if (Request.QueryString["Type"] == "FeesDt")
                {
                    lbltitle.Text = "Fees Waiver Date Range";
                    trAll.Visible = true;
                    tr2.Visible = false;
                    BindFeesGrid("1");
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


 #region Button 'Search Click Event'
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            DateTime Dtfrm = DateTime.ParseExact(txtrptDtfrmval.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Dtto = DateTime.ParseExact(txtrptDttoval.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Today = System.DateTime.Today;
            if (txtrptDtfrmval.Text.ToString().Trim() != "" && txtrptDttoval.Text.ToString().Trim() != "")
            {
                if (Convert.ToDateTime(txtrptDttoval.Text) < Convert.ToDateTime(txtrptDtfrmval.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date From should be less than Date To')", true);
                    ProgressBarModalPopupExtender.Hide();
                    //Dtfrm.Focus();
                    return;
                }
            }

            //if (Dtfrm < Today || Dtfrm ==Today)
            if (Today > Dtfrm)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date from can not be less than Today Date')", true);
                ProgressBarModalPopupExtender.Hide();
                //Dtfrm.Focus();
                return;
            }


            if (Dtto < Today)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date To can not be less than Today Date')", true);
                ProgressBarModalPopupExtender.Hide();
                //Dtfrm.Focus();
                return;
            }
            if (txtReference.Text=="")
            {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('It is mandatory to enter reference')", true);
                ProgressBarModalPopupExtender.Hide();
                txtReference.Focus();
                return; 
            }

            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"] != null || Request.QueryString["Type"] != null)
                {
                    ViewState["Value"] = Request.QueryString["type"].ToString().Trim();
                    if (Request.QueryString["type"].Trim() == "FeesDt")
                    {
                        tr2.Visible = true;
                        lbltitle.Text = "Fees Waiver Date Range";
                     

                        BindFeesGrid("");
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
    protected void BindFeesGrid( string flag1)
    {
        try
        {
            Hashtable htParam = new Hashtable();

            dsDtls.Clear();
            htParam.Clear();
            if (flag1 == "1")
            {
                htParam.Add("@flag1", "1");
            }
            else
            {
                if (txtrptDtfrmval.Text.Trim() != "")
                {

                    htParam.Add("@CreateFrmDtim", DateTime.Parse(txtrptDtfrmval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
                }
                if (txtrptDttoval.Text.Trim() != "")
                {
                    htParam.Add("@CreateToDtim", DateTime.Parse(txtrptDttoval.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@CreateToDtim ", System.DBNull.Value);
                }

                if (txtReference.Text != "")
                {
                    htParam.Add("@reference", txtReference.Text.Trim());

                }
                else
                {
                    htParam.Add("@reference", System.DBNull.Value);
                }
                 htParam.Add("@CreatedBy", Session["UserID"].ToString());
            }
            dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("prc_chkFeesDt", htParam);

            if (dsDtls.Tables[0].Rows[0]["Flag"].ToString() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This date range is already active for fees waiver scheme')", true);
                ProgressBarModalPopupExtender.Hide();
            }
            else
            {
                if (dsDtls.Tables.Count > 0)
                {
                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        dgFees.DataSource = dsDtls.Tables[0];
                        dgFees.DataBind();
                    }
                    else
                    {
                        dgFees.DataSource = null;
                        dgFees.DataBind();
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";


                    }
                }
                else
                {
                    dgFees.DataSource = null;
                    dgFees.DataBind();

                }
            }
            txtrptDtfrmval.Text = "";
            txtrptDttoval.Text = "";
            txtReference.Text = "";
           // BindGridControl(dgFees);
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
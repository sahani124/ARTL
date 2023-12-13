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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Insc.MQ.Life.AgnMd;
using INSCL.App_Code;
using INSCL.DAL;
using Insc.Common.Multilingual;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using SD = System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using DataAccessClassDAL;
using System.Web.Script.Serialization;
//Added by rachana for fees details Webservice start
using SysInrgConsum;
using System.ServiceModel;
using Ionic.Zip;

public partial class Application_INSC_Recruit_Receiptmodule : BaseClass
{

    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    DataSet dsdocType = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string str;
    string doctype;
    string strDocName = string.Empty;
    private string strFileName1 = string.Empty;
    DataSet ds_image = new DataSet();
    string strPhotoExt = string.Empty;
    string strSignExt = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    private string strFileName = string.Empty;
    string cndno = string.Empty;
    string candtype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        cndno = Request.QueryString["CndNo"].ToString().Trim();
     
        if (cndno == null)
        {
            Response.Redirect("~/CndEnq.aspx");
        }

        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {

            //FillData(cndno);
        
           FillData(Request.QueryString["CndNo"].ToString().Trim());
        
        }

    }
    protected void FillData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@CndNo", cndno);
        //htParam.Add("@AppNo", System.DBNull.Value);
        //htParam.Add("@ReqDate", System.DBNull.Value);
        //htParam.Add("@BranchCode", System.DBNull.Value);
        //htParam.Add("@AdvName", System.DBNull.Value);

        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Getdataforerecept", htParam);
       

        if (dsResult != null)
        {
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                    lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString().Trim();
                    lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                    txttoken.Text = dsResult.Tables[0].Rows[0]["FeesTokenNo"].ToString().Trim();
                    txtamount.Text = dsResult.Tables[0].Rows[0]["TotalFees"].ToString().Trim();
                   
                }
            }
        }
    }
    
    
 

  
    protected void lblCndView_Click(object sender, EventArgs e)
    {
        
            string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
     
   
    protected void BtnSave_click(object sender, EventArgs e)
    {
        try
        {

            htParam.Clear();
            htParam.Add("@CndNo", lblCndNoValue.Text.Trim());
            htParam.Add("@Appno", lblAppNoValue.Text.Trim());
            htParam.Add("@Tokenno", txttoken.Text.Trim());
            htParam.Add("@Pymtmode", txtmode.SelectedValue);
            htParam.Add("@Chqueno", txtchekno.Text.Trim());
            htParam.Add("@Chequedate", txtchqdate.Text.Trim());
            htParam.Add("@Transid", txttrnsid.Text.Trim());
            htParam.Add("@Transndate", txttrnsdate.Text.Trim());
            htParam.Add("@Bankname", txtbankname.Text.Trim());
            htParam.Add("@Amount", txtamount.Text.Trim());
             htParam.Add("@Userid",HttpContext.Current.Session["UserID"].ToString().Trim());
            htParam.Add("@Flag", 1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Getdataforerecept", htParam);
           // lbl3.Text = "Fees paid successfully";
            lbl3.Text = " Fees paid successfully" + "</br></br>Candidate ID: " + lblCndNoValue.Text.Trim() + "</br>Candidate Name:" + lblAdvNameValue.Text + "</br> Application No:" + lblAppNoValue.Text+"";
                                     
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            BtnSearch.Enabled = false;
        }
        catch (Exception ex)
        {

            catchdetails(ex);
        }
        
    }

    protected void ddlMode_SelectedIndexChnged(object sender, EventArgs e)
    {
        try {
            if (txtmode.SelectedValue == "Cash" || txtmode.SelectedValue == "")
            {
                divMode.Visible = false;
                txtchekno.Text = "";
                txtchqdate.Text ="";
            }
            else {
                divMode.Visible = true;
            }
        }
        catch (Exception ex)
        {
            catchdetails(ex);
        }
        
    }

    protected void catchdetails( Exception ex)
    {
        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        int LNNo = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber();
        string LineNo = Convert.ToString(LNNo);

        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);

        string sRet = oInfo.Name;
        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        String LogClassName = method.ReflectedType.Name;

        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    }

}
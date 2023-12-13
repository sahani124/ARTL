using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessClassDAL;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
 using CBCMSWEBAPI;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

public partial class Application_Isys_Recruit_GenerateLink : BaseClass
{
    
    ErrLog objErr = new ErrLog();
    protected CommonFunc oCommon = new CommonFunc();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    //private BitlyUtil BitlyUtil = new BitlyUtil();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
           
            Session["CarrierCode"] = '2';

            if (!IsPostBack)
            {
                PopulateAppLink();
                fillDetails();
                //Task<string> str = BitlyUtil.CreateBitlyLinkAsync(Request.QueryString["appno"].ToString().Trim());
                //JObject jObject = JObject.Parse(str.Result);

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
    private void PopulateAppLink()
    {
        try
        {
            oCommon.getDropDown(ddlaaplink, "DstbnMtd", 1, "", 1);
            ddlaaplink.Items.Insert(0, "Select");
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
    private void fillDetails()
    {
        try
        {
            ddlaaplink.SelectedValue = Request.QueryString["CnctPrefrd"].ToString().Trim();
            txtAppName.Text = Request.QueryString["Name"].ToString().Trim();
            txtMobNo.Text = Request.QueryString["MobNo"].ToString().Trim();
            txtEmailID.Text = Request.QueryString["Email"].ToString().Trim();
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

    protected void lknbtn_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            DataSet ds = new DataSet();
            htParam.Add("@AppNo", Request.QueryString["appno"].ToString().Trim());
            htParam.Add("@OTP", "12345");
            htParam.Add("@VerURL", lblshare.Text.Trim());

            int x = dataAccessRecruit.execute_sprcrecruit("Prc_InsOTPNumber", htParam);
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

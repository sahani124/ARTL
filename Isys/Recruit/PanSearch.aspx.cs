using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using DataAccessClassDAL;
using System.Threading;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;

public partial class Application_Isys_Recruit_PanSearch : BaseClass
{
        DataAccessClass dataAccessRecruit = new DataAccessClass();
        Hashtable htPan = new Hashtable();
        DataSet ds = new DataSet();
        ErrLog objErr = new ErrLog();
        Hashtable htParam = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
        }
	protected void btnVerifyPAN_Click(object sender, EventArgs e)
	{
		try
		{
			Hashtable htData = new Hashtable();
			DataSet ds = new DataSet();
			htData.Add("@Panno", txtpan.Text.ToString().Trim());
			htData.Add("@Sid", HttpContext.Current.Session.SessionID);
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("[Prc_Ins_TranstStatus]", htData);
			Session["Pan"] = txtpan.Text;
			Session["sid"] = HttpContext.Current.Session.SessionID;
			string Pan = txtpan.Text;
			string sid = HttpContext.Current.Session.SessionID;
			txtpan.Text = "";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "')", true);
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
	protected void BtnSubmitCaptcha_Click(object sender, EventArgs e)
	{
		//CaptchaImg.Attributes.Add("style", "display:block");
		Hashtable htData = new Hashtable();
		DataSet ds = new DataSet();
		//htData.Add("@Panno", Request.QueryString["Panno"].ToString().Trim());
		//htData.Add("@Sid", Request.QueryString["SId"].ToString().Trim());
		htData.Add("@Panno", Session["Pan"]);
		htData.Add("@Sid", Session["sid"]);
		htData.Add("@Capt", txtCaptcha.Text.ToString().Trim());
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Upd_Captcha]", htData);
		string Pan = Session["Pan"].ToString();
		string sid = Session["sid"].ToString();
		ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "')", true);
	}
	protected void BtnClear_Click(object sender, EventArgs e)
	{
		txtCaptcha.Text = "";
	}
	public class ResultPan
	{
		public string panno { get; set; }
		public string sid { get; set; }
	}

	[System.Web.Services.WebMethod]
	public static string CheckPanSts(List<ResultPan> data)
	{
		//try
		//{
		// string _data = "";
		string Response = "";
		CustomizationDynamic.ResponseClass resp = new CustomizationDynamic.ResponseClass();
		Hashtable htparam = new Hashtable();
		DataSet ds = new DataSet();
		DataTable dt = new DataTable();
		htparam.Clear();
		ds.Clear();
		DataAccessClass objDal = new DataAccessClass();
		htparam.Clear();
		htparam.Add("@Panno", data[0].panno.Trim());//data[0].ActNo.Trim()
		htparam.Add("@SId", data[0].sid.Trim());
		//ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);
		ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts_NSDL", htparam);
		//if (ds.Tables[0].Rows.Count > 0)
		//{
		//	if(ds.Tables[0].Rows[0]["status"].ToString().Trim()=="4")
		//	{
		//		return "PAN Number based search initiated";
		//	}
		//	else if(ds.Tables[0].Rows[0]["status"].ToString().Trim() == "7")
		//	{
		//		return ds.Tables[0].Rows[0]["Action"].ToString().Trim();
		//	}	
		//	else
		//	{
		//		return ds.Tables[0].Rows[0]["Action"].ToString().Trim();
		//	}
		//}
		//else
		//{
		//	return "";
		//}
		if (ds.Tables[0].Rows.Count > 0)
		{
			//return ds.Tables[0].Rows[0].ToString();
			resp.status = ds.Tables[0].Rows[0]["Action"].ToString().Trim();
			resp.Data = ds.Tables[0].Rows[0]["status"].ToString().Trim();
			Response = JsonConvert.SerializeObject(resp);
			return Response;
		}
		else
		{
			return "";
		}

		//return _data;
		//}
		//catch (Exception ex)
		//{
		//    ErrLog objErr = new ErrLog();
		//    objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetInhrtDta", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
		//    return "1";
		//}
	}

}
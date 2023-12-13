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

public partial class Application_Isys_Recruit_Integration : BaseClass
{
    DataAccessClass dataAccessRecruit = new DataAccessClass();
    Hashtable htPan = new Hashtable();
    DataSet ds = new DataSet();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();

    public static string ID="";
    public static string Userid = "";
    //public static string ResultNSDL = "";
    //public static string ResultIIB = "";
   // public static string ResultIRDA = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
        // btnVerifyPAN_Click(null, null); commented by ajay 08052023
		 Session["CKYC"] = "N";

		}
        Userid = Session["UserID"].ToString().Trim();
        //ShowResult.Text = ResultNSDL;
        //ShowResultIIB.Text = ResultIIB;
        //ShowResultIRDA.Text = ResultIRDA;
    }
    protected void lnkbtnIRDA_Click(object sender, EventArgs e)
    {
        try
        {
            ChkBxIRDA.Enabled = true;
            string url = "https://agencyportal.irdai.gov.in/PublicAccess/LookUpPAN.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Openwindow('" + url + "')", true);
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
    protected void lnkbtnIIB_Click(object sender, EventArgs e)
    {
        try
        {
            ChkBxIIB.Enabled = true;
            string url = "https://www.itrex.in/USN/SelfDeactivatePAN.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Openwindow('" + url + "')", true);
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
    protected void lnkPrcdWthInt_Click(object sender, EventArgs e)
    {
        try
        {
			Hashtable htparam = new Hashtable();
			DataSet ds = new DataSet();
			DataTable dt = new DataTable();
			htparam.Clear();
			ds.Clear();
			DataAccessClass objDal = new DataAccessClass();
			htparam.Clear();
			htparam.Add("@Panno", Request.QueryString["PAN"].Trim());//data[0].ActNo.Trim()
			ds = objDal.GetDataSetForPrcRecruit("Prc_Get_Intg_Flg", htparam);
			string NSDL = ds.Tables[0].Rows[0]["NSDL"].ToString().Trim();
			string IIB = ds.Tables[1].Rows[0]["IIB"].ToString().Trim();
			string IRDA = ds.Tables[2].Rows[0]["IRDA"].ToString().Trim();
			string CKYC = Session["CKYC"].ToString();

			if (NSDL == "N" || IIB == "N" || IRDA == "N" || CKYC == "N") {
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup1", "popup()", true);
				if (hdnPopmsg.Value == "btnYes")
				{
					Redirecttopage();
					//bool IRDA = false, IIB = false;
					//htParam.Add("@IntgId", "IRDA");
					//ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetflgforIRDAIIB", htParam);
					//string a = ds.Tables[0].Rows[0]["IsLicens"].ToString().Trim();
					//{
					//	IRDA = true;
					//}
					//htParam.Clear();
					//ds.Clear();
					//htParam.Add("@IntgId", "IIB");
					//ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetflgforIRDAIIB", htParam);
					//a = ds.Tables[0].Rows[0]["IsLicens"].ToString().Trim();
					//{
					//	IIB = true;
					//}
					//string ModuleID = Request.QueryString["ModuleID"].Trim();
					//string AgtType = Request.QueryString["AgtType"].Trim();
					//string PAN = Request.QueryString["PAN"].Trim();
					//string Type = Request.QueryString["Type"];//added by ajay yadav 02-11-2022
					//string Code = Request.QueryString["Code"];//added by ajay yadav 02-11-2022
					//string ACT = Request.QueryString["ACT"];//added by ajay yadav 02-11-2022
					//if (IRDA == true && IIB == true && ModuleID == "11010")//condition change by ajay for redirect
					//{
					//	Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
					//}
					//else if (IRDA == true && IIB == true && ModuleID == "11258")//condition change by ajay for redirect
					//{
					//	Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
					//}
					//else if (IRDA == true && IIB == true && ModuleID == "8017")
					//{
					//	Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
					//}
					//else if (IRDA == true && IIB == true && ModuleID == "11253")
					//{
					//	Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
					//}
					//else if (IRDA == true && IIB == true && ModuleID == "11257" && AgtType == "PS")
					//{
					//	Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
					//}
					//else if (IRDA == true && IIB == true && ModuleID == "11258" && AgtType == "SP")//condition change by ajay for redirect
					//{
					//	Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
					//}



					//else if (IRDA == true && IIB == true && ModuleID == "8017" && AgtType == "SP")
					//{
					//	Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
					//}
				}
				//else if (hdnPopmsg.Value == "btnNo")
				//{
				//	string Pan = ViewState["Pan"].ToString();
				//	string sid = ViewState["sid"].ToString();
				//	ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
				//}
			}
			else if (NSDL == "Y" && IIB == "Y" && IRDA == "Y" && CKYC == "Y")
			{
				Redirecttopage();
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
	protected void Redirecttopage()
	{
		try
		{
			bool IRDA = false, IIB = false;
			htParam.Add("@IntgId", "IRDA");
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetflgforIRDAIIB", htParam);
			string a = ds.Tables[0].Rows[0]["IsLicens"].ToString().Trim();
			{
				IRDA = true;
			}
			htParam.Clear();
			ds.Clear();
			htParam.Add("@IntgId", "IIB");
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetflgforIRDAIIB", htParam);
			a = ds.Tables[0].Rows[0]["IsLicens"].ToString().Trim();
			{
				IIB = true;
			}
			string ModuleID = Request.QueryString["ModuleID"].Trim();
			string AgtType = Request.QueryString["AgtType"].Trim();
			string PAN = Request.QueryString["PAN"].Trim();
			string Type = Request.QueryString["Type"];//added by ajay yadav 02-11-2022
			string Code = Request.QueryString["Code"];//added by ajay yadav 02-11-2022
			string ACT = Request.QueryString["ACT"];//added by ajay yadav 02-11-2022
			if (IRDA == true && IIB == true && ModuleID == "11010")//condition change by ajay for redirect
			{
				Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "11258")//condition change by ajay for redirect
			{
				Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "8017")
			{
				Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "11253")
			{
				Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "11257" && AgtType == "PS")
			{
				Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "11258" && AgtType == "SP")//condition change by ajay for redirect
			{
				Response.Redirect("frmCND_Personal.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN, false);
			}
			else if (IRDA == true && IIB == true && ModuleID == "8017" && AgtType == "SP")
			{
				Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&Code=" + Code + "&PAN=" + PAN + "&ACT=" + ACT, false);
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
	protected void btnPrevHome_Click(object sender, EventArgs e)
    {
        string ModuleID = Request.QueryString["ModuleID"].ToString();
        string ACT = Request.QueryString["ACT"].ToString();
        string PAN = Request.QueryString["PAN"].ToString();
        Response.Redirect("PAN.aspx?Type=N&ModuleID="+ ModuleID +"&AgtType=IS&Code=Spon" +"&ACT="+ ACT+ "&PAN="+ PAN);
    }
    #region for NSDL
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {
        try
        {
            //iLoading.Attributes.Add("style", "position:absolute");
            //iLoading.Attributes.Add("style", "top:50%");
            //iLoading.Attributes.Add("style", "left:50%");
            //iLoading.Attributes.Add("style", "margin:-50px 0px 0px -50px");
            //iLoading.Attributes.Add("style", "z-index:9999");
            txtpan.Text= Request.QueryString["PAN"].Trim();
            //iLoading.Attributes.Add("style", "display:block;position:absolute;top:50%;left:50%;margin:-50px 0px 0px -50px;z-index:9999");
            //divloader.Attributes.Add("style", "display:block;text-align:center");

            //iLoading.Attributes.Add("style", "position:absolute");
            //iLoading.Attributes.Add("style", "top:50%");
            //iLoading.Attributes.Add("style", "left:50%");
            //iLoading.Attributes.Add("style", "margin:-50px 0px 0px -50px");
            //iLoading.Attributes.Add("style", "z-index:9999");
            if (txtpan.Text.Length == 10)
            {
                Hashtable htData = new Hashtable();
                DataSet ds = new DataSet();
                var sid = DateTime.Now.Ticks.ToString();
                htData.Add("@Panno", txtpan.Text.ToString().Trim());
                htData.Add("@Sid", sid);
                htData.Add("@SapCode", Userid);
                htData.Add("@IntgID", "2001");
                htData.Add("@MobileNo", txtmobno.Text.Trim());
                ds = dataAccessRecruit.GetDataSetForPrcRecruits("[Prc_Ins_TranstStatus]", htData);
                ViewState["Pan"] = txtpan.Text;
                ViewState["sid"] = sid;
                string Pan = txtpan.Text;
                //string sid = HttpContext.Current.Session.SessionID;
                txtpan.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter 10 digit PAN')", true);
                return;
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
    protected void BtnSubmitCaptcha_Click(object sender, EventArgs e)
    {
		//divloader.Attributes.Add("style", "display:block;text-align:center");
		//Label3.Text = "Verifying Captcha";
        //end by ajay 08052023
		//CaptchaImg.Attributes.Add("style", "display:block");
		Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        //htData.Add("@Panno", Request.QueryString["Panno"].ToString().Trim());
        //htData.Add("@Sid", Request.QueryString["SId"].ToString().Trim());
        
        htData.Add("@Panno", ViewState["Pan"]);
        //htData.Add("@Sid", Convert.ToInt64(ID));
		htData.Add("@Sid", "");
		htData.Add("@IntgID", "2001");
        htData.Add("@Capt", txtCaptcha.Text.ToString().Trim());
        ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Upd_Captcha]", htData);
        string Pan = ViewState["Pan"].ToString();
        string sid = ViewState["sid"].ToString();
        txtCaptcha.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
        //btnNsdl.Attributes.Add("style", "margin-top: 2px;text-align: right;padding: 6px;");//added by ajay 08052023

    }
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{
    //	txtCaptcha.Text = "";
    //}
    public class ResultPan
    {
        public string panno { get; set; }
        public string sid { get; set; }
        public string UserId { get; set; }
    }

    [System.Web.Services.WebMethod]
    public static string CheckPanSts(List<ResultPan> data)
    {
        try
        {
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
        htparam.Add("@SapCode", data[0].UserId );
        htparam.Add("@IntgID", "2001");
        
        //ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);
        ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);

        //ID = ds.Tables[0].Rows[0]["Id"].ToString().Trim();
        //ResultNSDL= ds.Tables[0].Rows[0]["Result"].ToString().Trim();
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
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Action"].ToString().Trim() != "IsCapEntered")
        {
            //return ds.Tables[0].Rows[0].ToString();
            resp.status = ds.Tables[0].Rows[0]["Action"].ToString().Trim();
            resp.Data = ds.Tables[0].Rows[0]["status"].ToString().Trim();
            resp.Name = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
            resp.Result = ds.Tables[0].Rows[0]["Result"].ToString().Trim();

                if (ds.Tables[0].Rows[0]["ImgBin"] != null && ds.Tables[0].Rows[0]["ImgBin"] != System.DBNull.Value)
                {
                    byte[] img = (byte[])ds.Tables[0].Rows[0]["ImgBin"];
                    if (img != null)
                    {
                        resp.image = System.Convert.ToBase64String(img, 0, img.Length);
                    }
                }
          
            Response = JsonConvert.SerializeObject(resp);
            return Response;
        }
        else
        {
            return "";
        }

        //return _data;
    }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
    objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetInhrtDta", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return "1";
        }
    }
    #endregion

    
   protected void btnNsdl_Click(object sender, EventArgs e)
    {
        try
        {
            
            txtpan.Text = Request.QueryString["PAN"].Trim();

            divLoaderIIB.Attributes.Add("style", "display:block;text-align:center");
            divloader.Attributes.Add("style", "display:none;text-align:center");
            ImgIIB.Attributes.Add("src", "../../../image/IibClor.jpg");
            if (txtpan.Text.Length == 10)
            {
                Hashtable htData = new Hashtable();
                DataSet ds = new DataSet();
                var sid = DateTime.Now.Ticks.ToString();
                htData.Add("@Panno", txtpan.Text.ToString().Trim());
                htData.Add("@Sid", sid);
                htData.Add("@SapCode", Userid);
                htData.Add("@IntgID", "2002");

                ds = dataAccessRecruit.GetDataSetForPrcRecruits("[Prc_Ins_TranstStatus]", htData);
                ViewState["Pan"] = txtpan.Text;
                ViewState["sid"] = sid;
                string Pan = txtpan.Text;
                //string sid = HttpContext.Current.Session.SessionID;
                txtpan.Text = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefStsIIB('" + Pan + "','" + sid + "','" + Userid + "')", true);
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
			}
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter 10 digit PAN')", true);
                return;
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
    [System.Web.Services.WebMethod]
    public static string CheckPanStsIIB(List<ResultPan> data)
    {
        try
        {
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
            htparam.Add("@SapCode", data[0].UserId);
            htparam.Add("@IntgID", "2002");

            //ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);
            ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);

            //ID = ds.Tables[0].Rows[0]["Id"].ToString().Trim();
            //ResultIIB = ds.Tables[0].Rows[0]["Result"].ToString().Trim();
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Action"].ToString().Trim() != "IsCapEntered")
            {
                //return ds.Tables[0].Rows[0].ToString();
                resp.status = ds.Tables[0].Rows[0]["Action"].ToString().Trim();
                resp.Data = ds.Tables[0].Rows[0]["status"].ToString().Trim();
                resp.Name = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
                resp.Result = ds.Tables[0].Rows[0]["Result"].ToString().Trim();

                if (ds.Tables[0].Rows[0]["ImgBin"] != null && ds.Tables[0].Rows[0]["ImgBin"] != System.DBNull.Value)
                {
                    byte[] img = (byte[])ds.Tables[0].Rows[0]["ImgBin"];
                    if (img != null)
                    {
                        resp.image = System.Convert.ToBase64String(img, 0, img.Length);
                    }
                }

                Response = JsonConvert.SerializeObject(resp);
                return Response;
            }
            else
            {
                return "";
            }

            //return _data;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetInhrtDta", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return "1";
        }
    }
    protected void BtnSubmitCaptchaIIB_Click(object sender, EventArgs e)
    {
		divLoaderIIB.Attributes.Add("style", "display:block;text-align:center");
		Label5.Text = "Verifying Captcha";
		//CaptchaImg.Attributes.Add("style", "display:block");
		Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        //htData.Add("@Panno", Request.QueryString["Panno"].ToString().Trim());
        //htData.Add("@Sid", Request.QueryString["SId"].ToString().Trim());

        htData.Add("@Panno", ViewState["Pan"]);
		//htData.Add("@Sid", Convert.ToInt64(ID));
		htData.Add("@Sid", "");
		htData.Add("@IntgID", "2002");
        htData.Add("@Capt", txtIIB.Text.ToString().Trim());
        ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Upd_Captcha]", htData);
        string Pan = ViewState["Pan"].ToString();
        string sid = ViewState["sid"].ToString();
        txtCaptcha.Text = "";
		//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefStsIIB('" + Pan + "','" + sid + "','" + Userid + "')", true);
		ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
	}
	//for irda

	protected void btnNextIIB_Click(object sender, EventArgs e)
    {
        try
        {

            txtpan.Text = Request.QueryString["PAN"].Trim();

            divLoaderIRDA.Attributes.Add("style", "display:block;text-align:center");
            divLoaderIIB.Attributes.Add("style", "display:none;text-align:center");
            ImgIRDA.Attributes.Add("src", "../../../image/IrdaiClor.jpg");

            if (txtpan.Text.Length == 10)
            {
                Hashtable htData = new Hashtable();
                DataSet ds = new DataSet();
                var sid = DateTime.Now.Ticks.ToString();
                htData.Add("@Panno", txtpan.Text.ToString().Trim());
                htData.Add("@Sid", sid);
                htData.Add("@SapCode", Userid);
                htData.Add("@IntgID", "2003");

                ds = dataAccessRecruit.GetDataSetForPrcRecruits("[Prc_Ins_TranstStatus]", htData);
                ViewState["Pan"] = txtpan.Text;
                ViewState["sid"] = sid;
                string Pan = txtpan.Text;
                //string sid = HttpContext.Current.Session.SessionID;
                txtpan.Text = "";
				//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefStsIRDA('" + Pan + "','" + sid + "','" + Userid + "')", true);
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
			}
			else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter 10 digit PAN')", true);
                return;
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
    [System.Web.Services.WebMethod]
    public static string CheckPanStsIRDA(List<ResultPan> data)
    {
        try
        {
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
            htparam.Add("@SapCode", data[0].UserId);
            htparam.Add("@IntgID", "2003");

            //ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);
            ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);

            //ID = ds.Tables[0].Rows[0]["Id"].ToString().Trim();
            //ResultIRDA = ds.Tables[0].Rows[0]["Result"].ToString().Trim();
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Action"].ToString().Trim() != "IsCapEntered")
            {
                //return ds.Tables[0].Rows[0].ToString();
                resp.status = ds.Tables[0].Rows[0]["Action"].ToString().Trim();
                resp.Data = ds.Tables[0].Rows[0]["status"].ToString().Trim();
                resp.Name = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
                resp.Result = ds.Tables[0].Rows[0]["Result"].ToString().Trim();

                if (ds.Tables[0].Rows[0]["ImgBin"] != null && ds.Tables[0].Rows[0]["ImgBin"] != System.DBNull.Value)
                {
                    byte[] img = (byte[])ds.Tables[0].Rows[0]["ImgBin"];
                    if (img != null)
                    {
                        resp.image = System.Convert.ToBase64String(img, 0, img.Length);
                    }
                }

                Response = JsonConvert.SerializeObject(resp);
                return Response;
            }
            else
            {
                return "";
            }

            //return _data;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetInhrtDta", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return "1";
        }
    }
    protected void BtnSubmitCaptchaIRDA_Click(object sender, EventArgs e)
    {
		divLoaderIRDA.Attributes.Add("style", "display:block;text-align:center");
		Label6.Text = "Verifying Captcha";
		//CaptchaImg.Attributes.Add("style", "display:block");
		Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        //htData.Add("@Panno", Request.QueryString["Panno"].ToString().Trim());
        //htData.Add("@Sid", Request.QueryString["SId"].ToString().Trim());

        htData.Add("@Panno", ViewState["Pan"]);
		//htData.Add("@Sid", Convert.ToInt64(ID));
		htData.Add("@Sid", ""); htData.Add("@IntgID", "2003");
        htData.Add("@Capt", txtIRDA.Text.ToString().Trim());
        ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Upd_Captcha]", htData);
        string Pan = ViewState["Pan"].ToString();
        string sid = ViewState["sid"].ToString();
        txtCaptcha.Text = "";
		//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefStsIRDA('" + Pan + "','" + sid + "','" + Userid + "')", true);
		ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
	}
	//for next CKYC


	//added by ajay 30-12-2022 START
	protected void btnNextIRDA_Click(object sender, EventArgs e)
    {

        string Pan = ViewState["Pan"].ToString();
        string sid = ViewState["sid"].ToString();
		//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefStsIRDA('" + Pan + "','" + sid + "','" + Userid + "')", true);
		ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "RefSts('" + Pan + "','" + sid + "','" + Userid + "')", true);
		divLoaderIRDA.Attributes.Add("style", "display:none;text-align:center");
        ImgCERSAI.Attributes.Add("src", "../../../image/CersaiClor.jpg");
        txtDOB.Visible = true;
        Img4.Visible = true;
        btnPrcd1.Visible = true;
		LinkButton4.Visible = true;
        ds.Clear();
		htPan.Clear();
		htPan.Add("@Pan", Request.QueryString["PAN"].ToString().Trim());
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Get_Panno]", htPan);
		if (ds.Tables[0].Rows.Count > 0)
		{
			ptxt.Visible = true;
			ptxt.Text = "CKYC record found.Please enter DOB.";
		}
		else
		{
			ptxt.Visible = true;
			//ptxt.Attributes.Add("style", "color: Green;font-size: 10px;padding-left: 37px;");
			ptxt.Text = "CKYC record not found.";
		}
		Session["CKYC"]= "Y";
	}

    protected void btnPrcd1_Click(object sender, EventArgs e)
    {

        string ModuleID = Request.QueryString["ModuleID"].Trim();
        string AgtType = Request.QueryString["AgtType"].Trim();
        string PAN = Request.QueryString["PAN"].Trim();
        string ACT = Request.QueryString["ACT"].ToString();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Pan", PAN);
        ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_Get_AppNo", htParam);
        string Appno = ds.Tables[0].Rows[0]["applicationno"].ToString().Trim();
        Response.Redirect("CndReg.aspx?ProspectId=" + Appno + "&Type=E&ACT=" + ACT + "&ModuleID=" + ModuleID + "&Code=Spon" + "&AgtType=" + AgtType, false);
    }
    //added by ajay 30-12-2022 END

    protected void btnotp_Click(object sender, EventArgs e)
    {
        btnVerifyPAN_Click(null, null);
        divCaptchatxt1.Attributes.Add("style", "margin-left: 11px;display:flex;");
        divCaptchatxt.Attributes.Add("style", "display:block");
        txtmobno.Text = "";
        divMobno.Attributes.Add("style", "display:none");
    }

    //protected void txtCaptcha_TextChanged(object sender, EventArgs e)
    //{
    //    if(txtCaptcha.Text.Length >= 6)
    //    {
    //        BtnSubmitCaptcha.Attributes.Add("style", "padding: 0px; width: 28px; height: 24px; border - color:  #ced4da !important");
    //    }
    //}
}
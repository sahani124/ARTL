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
public partial class Application_Isys_Recruit_ResultCheck : BaseClass
{
        DataAccessClass dataAccessRecruit = new DataAccessClass();
        Hashtable htParam = new Hashtable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetAllowResponseInBrowserHistory(false);
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
                Hashtable htparam = new Hashtable();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                htparam.Clear();
                ds.Clear();
                DataAccessClass objDal = new DataAccessClass();
                htparam.Clear();
                htparam.Add("@Panno", data[0].panno.Trim());//data[0].ActNo.Trim()
                htparam.Add("@SId", data[0].sid.Trim());
                ds = objDal.GetDataSetForPrcRecruit("Prc_Get_PanSts", htparam);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                    return ds.Tables[0].Rows[0]["Action"].ToString().Trim();
                //}
                //return _data;
            //}
            //catch (Exception ex)
            //{
            //    ErrLog objErr = new ErrLog();
            //    objErr.LogErr("ISYS-SAIM", "FFContestPageStdDef", "GetInhrtDta", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            //    return "1";
            //}
        }
        protected void BtnSubmitCaptcha_Click(object sender, EventArgs e)
        {
            htParam.Add("@Panno", Request.QueryString["Panno"].ToString().Trim());
            htParam.Add("@Sid", Request.QueryString["SId"].ToString().Trim());
            htParam.Add("@Capt", txtCaptcha.Text.ToString().Trim());
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_Upd_Captcha]", htParam);
            DeleteImg();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            txtCaptcha.Text = "";
        }
        public void DeleteImg()
        {
            string filename = Request.QueryString["Panno"].ToString().Trim() + ".png";
            //string path = "D:\\Sarthak\\PAN verification\\PAN verification\\Images\\" + filename;
            string path = "D:\\Sarthak\\International_Insurance\\Application\\Isys\\Recruit\\Images\\" + filename;

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
               file.Delete();
            }
        }
}
using DataAccessClassDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Application_Isys_ChannelMgmt_HirerachyJS_JavaScript : System.Web.UI.Page
{
    string code = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["ChannelCode"].ToString().Trim() != "")
            //{
            //    code = Request.QueryString["ChannelCode"].ToString().Trim();
            //}
        }
    }

    [WebMethod]
    public static string GetData(string CODE, string Flag)
    {
        DataAccessClass dataAccess = new DataAccessClass();
        Hashtable htTable = new Hashtable();
        htTable.Clear();
        htTable.Add("@CODE", CODE);
        htTable.Add("@IsRoot", 1);
        htTable.Add("@Flag", Flag);
        DataSet ds1 = new DataSet();
        DateTime startTime = DateTime.Now;
        ds1 = dataAccess.GetDataSetForPrcIsysTemp("PRC_GET_HIERACHY_STRUCTURE", htTable);
        return ds1.Tables[0].Rows[0]["JSON"].ToString();
    }
    [WebMethod]
    public static string GetBytes(List<ResultMemcode> data)
    {
        DataAccessClass dataAccess = new DataAccessClass();
        Hashtable htTable = new Hashtable();
        DataSet dsbytes = new DataSet();
        htTable.Clear();
        if (data[0].Memcode.ToString().Trim() != "")
        {
            htTable.Add("@Memcode", data[0].Memcode.ToString().Trim());
            dsbytes = dataAccess.GetDataSetForPrcIsysTemp("Prc_GetBytes_Member", htTable);
            if (dsbytes.Tables.Count > 0)
            {
                if (dsbytes.Tables[0].Rows.Count > 0)
                {
                    if (dsbytes != null && dsbytes.Tables[0].Rows[0]["Images"].ToString().Trim() != "")
                    {
                        Byte[] bytes = (Byte[])dsbytes.Tables[0].Rows[0]["Images"];
                        string base64String = Convert.ToBase64String(bytes);
                        //System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(bytes));
                        string imageUrl = "data:image/jpeg;base64," + base64String;
                        return imageUrl;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        else
        {
            htTable.Add("@Memcode", System.DBNull.Value);
        }
        return "";
    }
    public class ResultMemcode
    {
        public string Memcode { get; set; }
    }

    public static string UploadImg(List<ResultMemcode> data)
    {
        return "";
    }
}

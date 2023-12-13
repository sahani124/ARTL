<%@ WebService Language="C#" Class="Common.Client.Lookup" %>
 
using System;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Common.Client
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class Lookup : System.Web.Services.WebService
    {
        [WebMethod]
        public string LookupCountry(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveCountry_sel '" +
                intLangNum + "', '" +
                strID + "'";
            String strConn;
            SqlCommand sqlCmd;
            SqlConnection sqlConn;
            SqlDataReader sqlReader;

            strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlReader = sqlCmd.ExecuteReader();

            int intCounter = 0;
            while (sqlReader.Read() == true)
            {
                strResult = sqlReader[0].ToString();
                intCounter += 1;
                if (intCounter > 1)
                {
                    strResult = String.Empty;
                    break;
                }
            }

            sqlConn.Close();
            sqlReader.Close();
            sqlCmd = null;

            return strResult;
        }
        
        [WebMethod]
        public string LookupState(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveState_sel '" +
                intLangNum + "', '" +
                strID + "'";
            String strConn;
            SqlCommand sqlCmd;
            SqlConnection sqlConn;
            SqlDataReader sqlReader;

            strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlReader = sqlCmd.ExecuteReader();

            int intCounter = 0;
            while (sqlReader.Read() == true)
            {
                strResult = sqlReader[0].ToString();
                intCounter += 1;
                if (intCounter > 1)
                {
                    strResult = String.Empty;
                    break;
                }
            }

            sqlConn.Close();
            sqlReader.Close();
            sqlCmd = null;

            return strResult;
        }

        [WebMethod]
        public string LookupNational(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            if (strID.ToUpper() != "OTH")
            {
                String strSQL = "prc_RetrieveLookup_sel '" +
                    intLangNum + "', '" +
                    strID + "', 'National'";
                String strConn;
                SqlCommand sqlCmd;
                SqlConnection sqlConn;
                SqlDataReader sqlReader;

                strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
                sqlConn = new SqlConnection(strConn);
                sqlConn.Open();

                sqlCmd = new SqlCommand(strSQL, sqlConn);
                sqlReader = sqlCmd.ExecuteReader();

                int intCounter = 0;
                while (sqlReader.Read() == true)
                {
                    strResult = sqlReader[0].ToString();
                    intCounter += 1;
                    if (intCounter > 1)
                    {
                        strResult = String.Empty;
                        break;
                    }
                }

                sqlConn.Close();
                sqlReader.Close();
                sqlCmd = null;
            }
            
            return strResult;         
        }

        [WebMethod]
        public string LookupResCntry(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveLookup_sel '" +
                intLangNum + "', '" +
                strID + "', 'NBLocate'";
            String strConn;
            SqlCommand sqlCmd;
            SqlConnection sqlConn;
            SqlDataReader sqlReader;

            strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlReader = sqlCmd.ExecuteReader();

            int intCounter = 0;
            while (sqlReader.Read() == true)
            {
                strResult = sqlReader[0].ToString();
                intCounter += 1;
                if (intCounter > 1)
                {
                    strResult = String.Empty;
                    break;
                }
            }

            sqlConn.Close();
            sqlReader.Close();
            sqlCmd = null;

            return strResult;
        }

        [WebMethod]
        public string LookupQual(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveLookup_sel '" +
                intLangNum + "', '" +
                strID + "', 'NBEduQua'";
            String strConn;
            SqlCommand sqlCmd;
            SqlConnection sqlConn;
            SqlDataReader sqlReader;

            strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlReader = sqlCmd.ExecuteReader();

            int intCounter = 0;
            while (sqlReader.Read() == true)
            {
                strResult = sqlReader[0].ToString();
                intCounter += 1;
                if (intCounter > 1)
                {
                    strResult = String.Empty;
                    break;
                }
            }

            sqlConn.Close();
            sqlReader.Close();
            sqlCmd = null;

            return strResult;
        }
        
        [WebMethod]
        public string LookupOccupation(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveOccupation_sel '" +
                intLangNum + "', '" +
                strID + "'";
            String strConn;
            SqlCommand sqlCmd;
            SqlConnection sqlConn;
            SqlDataReader sqlReader;

            strConn = ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlReader = sqlCmd.ExecuteReader();

            int intCounter = 0;
            while (sqlReader.Read() == true)
            {
                strResult = sqlReader[0].ToString();
                intCounter += 1;
                if (intCounter > 1)
                {
                    strResult = String.Empty;
                    break;
                }
            }

            sqlConn.Close();
            sqlReader.Close();
            sqlCmd = null;

            return strResult;
        }

        //[WebMethod]
        //public string CltRefresh(string strGCN, string strCltType)
        //{
        //    Session.Remove("CltNew_GCN");
        //    this.Session.Add("CltNew_GCN", strGCN);
        //}   
    }
}

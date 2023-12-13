<%@ WebService Language="C#" Class="Common.Client.Clt" %>
 
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
    public class Clt : System.Web.Services.WebService
    {
        [WebMethod]
        public string LookupBranch(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveBranch_sel '" +
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
        public string LookupBranch2(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveBranch_sel '" +
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
                strResult = sqlReader[1].ToString();
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
        public string LookupBank(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveBank_sel '" +
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
        public string LookupLocation(string strID, int intLangNum)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveLocation_sel '" +
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
        public string LookupProduct(string strID)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveProduct_sel '" +
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
        public string LookupAgent(string strID)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveAgent_sel '" +
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
        public string LookupClient(string strID)
        {
            String strResult = String.Empty;

            String strSQL = "prc_RetrieveClient_sel '" +
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
    }
}

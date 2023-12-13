using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DataAccessClassDAL;

public partial class Application_ISys_ChannelMgmt_FranchiesEnrollment_FPImageCSharp : BaseClass
{
    #region Global Declaration
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ImageID"] != null)
        {
            if(Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString().Trim() == "Hierarchy")
                {
                    htParam.Add("@Memcode", Request.QueryString["ImageID"]);
                    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Proc_GetAgtImgUpld", htParam);
                }
                else
                {
                    htParam.Add("@ID", Request.QueryString["ImageID"]);
                    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemImagesbinary", htParam);
                }
            }
            else
            {
                htParam.Add("@ID", Request.QueryString["ImageID"]);
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemImagesbinary", htParam);
            }

            if (dsResult != null)
            {
                try
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        Byte[] bytes = (Byte[])dsResult.Tables[0].Rows[0]["Images"];
						Session["FPImageCSharpImage"] = bytes;
						string fileName = dsResult.Tables[0].Rows[0]["PhotoName"].ToString();
						string fileExtension = Path.GetExtension(fileName);
						Session["FPImageCSharpImageextension"] = fileExtension.Substring(1);
						Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        if (Request.QueryString["Flag"].ToString().Trim() == "Hierarchy")
                        {
                            Response.ContentType = "Photo";
                        }
                        else
                        {
                            Response.ContentType = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                        }
                        Response.AddHeader("content-disposition", "attachment;filename="
                            + dsResult.Tables[0].Rows[0]["Images"].ToString());

                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
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
        }
    }
    #endregion
}
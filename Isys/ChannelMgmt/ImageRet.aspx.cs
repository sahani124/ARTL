using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DataAccessClassDAL;

public partial class ImageRet : BaseClass
{

    #region Declaration
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    private DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ImageID"] != null)
            {
                htParam.Add("@AgtCode", Request.QueryString["ImageID"]);
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetImageForAgents", htParam);

                if (dsResult != null)
                {
                    if (dsResult.Tables[0].Rows[0]["Images"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Images"].ToString().Trim() != "")
                        {
                            Byte[] bytes = (Byte[])dsResult.Tables[0].Rows[0]["Images"];
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.AddHeader("content-disposition", "attachment;filename="
                                + dsResult.Tables[0].Rows[0]["Images"].ToString());

                            Response.BinaryWrite(bytes);
                            Response.Flush();
                            ////Response.End();
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }

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
}
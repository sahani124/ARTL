using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_ChannelMgmt_PopUnitDownlines : BaseClass
{
    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsAtLoad = new DataSet();
        try
        {
            if (Request.QueryString["Bizsrc"].ToString() != String.Empty && Request.QueryString["UnitType"].ToString() != String.Empty && Request.QueryString["ChnCls"].ToString() != String.Empty)
            {
                dsAtLoad = BindData();
                StringBuilder output = new StringBuilder();
                lblStatusMsg.Text = String.Empty;
                lblStatusMsg.Visible = false;
                
                if (dsAtLoad != null || dsAtLoad.Tables[0].Rows.Count > 0)
                {
                    output.Append("<ul>");
                    for (int i = 0; i < dsAtLoad.Tables[0].Rows.Count; i++)
                    {
                        output.Append("<li class='databox-header'>"+Convert.ToString(dsAtLoad.Tables[0].Rows[i]["LegalName"]));
                        output.Append("</li>");
                        output.Append("<li class='databox-Address'>" + Convert.ToString(dsAtLoad.Tables[0].Rows[i]["UnitAddress"]).Replace("~", "") + " " + Convert.ToString(dsAtLoad.Tables[0].Rows[i]["UnitAddress2"]).Replace("~", ""));
                        output.Append("</li>");
                    }
                    output.Append("</ul>");
                
                    Literal.Text = output.ToString(); 
                }
                else
                {
                    lblStatusMsg.Visible = true;
                    lblStatusMsg.Text = "This Unit has 0 downline(s).";
                }
            }
            else
            {
                lblStatusMsg.Visible = true;
                lblStatusMsg.Text = "Downlines could not be shown."+Environment.NewLine.ToString()+"Please try again...";
            }
        }
        catch (Exception ex)
        {
            String currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            String sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected DataSet BindData()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@languageCode", "ENG");
            htParam.Add("@RptUnitCode", String.Empty);
            htParam.Add("@RptUnitType", Request.QueryString["UnitType"].ToString());
            htParam.Add("@BizSrc", Request.QueryString["BizSrc"].ToString());
            htParam.Add("@ChnnlClass", Request.QueryString["Chncls"].ToString());
            htParam.Add("@UnitCode", String.Empty);
            htParam.Add("@UnitType", String.Empty);

            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_enqUnitList", htParam);
            if (dsResult.Tables.Count == 0 && dsResult.Tables[0].Rows.Count == 0)
            {
                dsResult.Clear();
                dsResult = null;
            }

            return dsResult;
        }
        catch (Exception ex)
        {
            String currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            String sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

            return null;
        }
    }
}
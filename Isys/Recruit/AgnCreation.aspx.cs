using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Insc.MQ.Life.AgnMd;
using INSCL.App_Code;
using INSCL.DAL;
using Insc.Common.Multilingual;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using SD = System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using DataAccessClassDAL;
using System.Web.Script.Serialization;
//Added by rachana for fees details Webservice start
using SysInrgConsum;
using System.ServiceModel;
using Ionic.Zip;
public partial class Application_Isys_Recruit_AgnCreation : BaseClass
{
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string str;
    string cndno = string.Empty;
    string candtype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        cndno = Request.QueryString["CndNo"].ToString().Trim();
        try {
            if (!IsPostBack)
            {
                FillData(cndno);
            }

        }
        catch (Exception ex)
        {
            catchdetails(ex);

        }
    }

    protected void FillData(string strCndNo)
    {
        try {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", strCndNo);
            htParam.Add("@Flag",1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAgnInfo", htParam);
            txtCustomId.Text = dsResult.Tables[0].Rows[0][0].ToString().Trim();
            txtPan.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
            txtAgnName.Text = dsResult.Tables[0].Rows[0]["AgentName"].ToString().Trim();
            txtAgnName.ToolTip = txtAgnName.Text;
            ddlSaleChn.Items.Insert(0, dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim());
            ddlSaleChn.SelectedValue = "0";
            ddlSaleChn.ToolTip = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
            ddlChnSubClass.Items.Insert(0, dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim());
            ddlChnSubClass.SelectedValue = "0";
            ddlChnSubClass.ToolTip = dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
            txtrecruitDate.Text = dsResult.Tables[0].Rows[0]["EntryDate"].ToString().Trim();
            txtAppdate.Text = txtrecruitDate.Text;
            txtRecruitAgtCode.Text = dsResult.Tables[0].Rows[0]["UserId"].ToString().Trim();
            txtMgrCode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
            txtAppNo.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
            txtUnitCode.Text = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim();
            txtEmpCode.Text = txtRecruitAgtCode.Text;
        }
        catch (Exception ex)
        {
            catchdetails(ex);

        }
 
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try {
            string strAgtCode = string.Empty;
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", cndno);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAgnInfo", htParam);
            strAgtCode = dsResult.Tables[0].Rows[0][0].ToString().Trim();
            lblpopup.Text = "Agent created successfully<br/><br/>" + "Agent Code: " + strAgtCode;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        btnSubmit.Enabled = false;
        txtAgnCode.Text = strAgtCode;

        }
        catch (Exception ex)
        {
            catchdetails(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ClientAgentSearch.aspx?ID=AC");

        }
        catch (Exception ex)
        {
            catchdetails(ex);
        }
    }
    protected void catchdetails(Exception ex)
    {

        
        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        int LNNo = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber();
        string LineNo = Convert.ToString(LNNo);

        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);

        string sRet = oInfo.Name;
        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        String LogClassName = method.ReflectedType.Name;

        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    }
}
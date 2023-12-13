using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_ISys_Recruit_FrmTemplates : BaseClass
{
    string strPath = System.Configuration.ConfigurationManager.AppSettings["DwnldFilePath"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
    }
    protected void lblUnderTkn_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Undertaking from prospective Insurance Advisor";
        string strFileName = "Undertaking from prospective Insurance Advisor";
        string fileType = "doc";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lbFrmVA_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Form 1 A";
        string strFileName = "Form 1 A";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "."+ fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkVARnwl_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "CODE OF CONDUCT";
        string strFileName = "CODE OF CONDUCT";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkVATrnsfr_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Form1B";
        string strFileName = "Form1B";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
        
    }
    protected void lnkAdvsr_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Insurance Advisors application form 11th Apr 2013";
        string strFileName = "Insurance Advisors application form 11th Apr 2013";
        string fileType = "doc";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkNEFTFrm_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Combo NEFT Mandate Form-Ver. 1.0_101212 (1)";
        string strFileName = "Combo NEFT Mandate Form-Ver. 1.0_101212 (1)";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkRepeater_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Repeaters_form";
        string strFileName = "Repeaters_form";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkUsrManualSM_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "User_manual_SM";
        string strFileName = "User_manual_SM";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkUsrManualRnwl_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "User_manual_Renwl";
        string strFileName = "User_manual_Renwl";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    protected void lnkUsrManualReExm_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "UserManual_ReExam";
        string strFileName = "UserManual_ReExam";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }

    protected void lnkbtnSmAllocDwnl_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "SM_AllocationManual";
        string strFileName = "SM_AllocationManual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Added by Nikhil on 22-04-15 for  AppInsAgt Download
    protected void lnkAppDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "SponsorshipForm_Individual";
        string strFileName = "SponsorshipForm_Individual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Ended by Nikhil on 22-04-15
    //Added by Nikhil on 22-04-15 for  AppInsAgt Download
    protected void lnktranDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Transfer_Casel_Process_User_manual";
        string strFileName = "Transfer_Casel_Process_User_manual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Ended by Nikhil on 22-04-15
    //Added by Nikhil on 22-04-15 for  AppInsAgt Download
    protected void lnkfreshDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Fresh_Case_Process_User_manual";
        string strFileName = "Fresh_Case_Process_User_manual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Ended by Nikhil on 22-04-15
    //Added by Nikhil on 22-04-15 for  AppInsAgt Download
    protected void lnkcompDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Composite_Case_Process_User_manual";
        string strFileName = "Composite_Case_Process_User_manual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Ended by Nikhil on 22-04-15
    //added by usha  on 15.10.2015 for noc
    protected void lnknoc_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Declaration (NOC) cum Affidavit for Lost Appointment Letter";
        string strFileName = "Declaration (NOC) cum Affidavit for Lost Appointment Letter";
        string fileType = "doc";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();

    }




    protected void lnknocDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "NOC Process User manual for SM and BM";
        string strFileName = "NOC Process User manual for SM and BM";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }


    protected void lnknocteamDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "NOC Process manual for Team";
        string strFileName = "NOC Process manual for Team";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //ended by usha 


    protected void lnkFeesDwld_Click(object sender, EventArgs e)
    {

        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "Candidate Fees Pending and Fees Waiver User manual";
        string strFileName = "Candidate Fees Pending and Fees Waiver User manual";
        string fileType = "pdf";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
    //Added by Nikhil Start
    protected void lnkResgLtr_Click(object sender, EventArgs e)
    {
        string strImgPath = string.Empty;
        string strImg = string.Empty;
        strImgPath = strPath + "RGI-Resignation Letter Format for surrender agency";
        string strFileName = "RGI-Resignation Letter Format for surrender agency";
        string fileType = "doc";
        Response.Clear();
        Response.AppendHeader("content-disposition", "attachment; filename=" + strFileName + "." + fileType);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(strImgPath + "." + fileType);
        Response.Flush();
        Response.End();
    }
}
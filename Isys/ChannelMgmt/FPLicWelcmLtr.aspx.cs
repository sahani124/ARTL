using DataAccessClassDAL;
using Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Application_Isys_ChannelMgmt_FPLicWelcmLtr : System.Web.UI.Page
{
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    string strRpt = System.Configuration.ConfigurationManager.AppSettings["Report"].ToString();
    string mimeType = string.Empty;
    string encoding = string.Empty;
    string extension = string.Empty;
    string[] streamIds;
    Warning[] warnings;
    Hashtable htable = new Hashtable();
    Hashtable htRprt = new Hashtable();
    DataSet dsRprt = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';

            if (!IsPostBack)
            {
                InitializeControl();
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds1);
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "Page_Load()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
      

    }

    #region IntializeControl
    private void InitializeControl()
    {
        try
        {
            lbltitle.Text = "Member Search";
            lblFranName.Text = "Name";
            lblDTRegFrom.Text = "From Date";
            lblDTRegTO.Text = "To Date";
            lblShwRecords1.Text = "Show Records";

            txtDTRegFrom.Attributes.Add("readonly", "readonly");
            txtDTRegFrom.Attributes.Add("style", "background-color: white");
            txtDTRegTo.Attributes.Add("readonly", "readonly");
            txtDTRegTo.Attributes.Add("style", "background-color: white");
        }

        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "InitializeControl()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion


    private DataTable BindLICID()
    {
        try
        {

            dsRprt.Clear();
            htRprt.Clear();
            GrdLicId.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
            string[] stringArray = txtFrenchCode.Text.ToString().Trim().Split(',');
            List<string> stringList = new List<string>(stringArray);

            if (txtFrenchCode.Text.ToString().Trim() != "")
            {
                htRprt.Add("@MemCode", txtFrenchCode.Text.ToString().Trim());
            }
            else
            {
                htRprt.Add("@MemCode", "");
            }
            htRprt.Add("@EmpCode", "");
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", "");

            if (txtDTRegFrom.Text.Trim() != "")
            {
                htRprt.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htRprt.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htRprt.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htRprt.Add("@CreateToDtim ", System.DBNull.Value);
            }
        
            htRprt.Add("@SapCode", "");

            htRprt.Add("@UserId", Session["UserID"].ToString().Trim());

            dsRprt = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemWelcomeDownload", htRprt);
            //}
           
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GrdLicId.DataSource = dsRprt.Tables[0];
                    GrdLicId.DataBind();
                    if (GrdLicId.PageCount > Convert.ToInt32(txtLICId.Text))
                    {
                        btnNextLIC.Enabled = true;
                    }
                    else
                    {
                        btnPreLIC.Enabled = false;//added by sanoj 10022923
                        
                    }
                    if(dsRprt.Tables[0].Rows.Count < 11)
                    {
                      btnNextLIC.Enabled = false;
                    }
                    
                    btndownload.Visible = true;
                    trLICId.Visible = true;
                    tr31.Visible = true;
                  
            }
                else
                {
                    btndownload.Visible = false;
                    tr31.Visible = true;
                    DataTable dt = new DataTable();
                    GrdLicId.DataSource = dt;
                    GrdLicId.DataBind();
                    trLICId.Visible = true;
                    btnNextLIC.Enabled = false;
            }

        }
         
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "BindLICID()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return dsRprt.Tables[0];
    }
    protected void btndownload_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> selectedMemCode = new List<string>();

            foreach (GridViewRow row in GrdLicId.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("ChkAssigned");
                Label lblMemCode = (Label)row.FindControl("lblMemcode");
                string MemCode = lblMemCode.Text.ToString().Trim();

                if (chkSelect.Checked == true)
                {
                    selectedMemCode.Add(MemCode);
                }
            }

            if (selectedMemCode.Count > 0)
            {
                dwnLoadZipFile(selectedMemCode);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please select atleast one checkbox');", true);
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "btndownload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }

    }
    public void dwnLoadZipFile(List<string> SelectMemCode)
    {

        try
        {
            DataSet dsAll = new DataSet();
            Hashtable htAll = new Hashtable();
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");

                foreach (string MemCode in SelectMemCode)
                {

                    dsAll.Clear();
                    htAll.Clear();
                    htAll.Add("@memcode", MemCode);
                    dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FPImgBytes", htAll);

                    if (dsAll.Tables[0].Rows.Count <= 0)
                    {
                        ConvertRDLCToPDF(MemCode);
                    }
                }
                foreach (string MemCode in SelectMemCode)
                {
                    dsAll.Clear();
                    htAll.Clear();
                    htAll.Add("@memcode", MemCode);
                    dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FPImgBytes", htAll);

                    if (dsAll.Tables[0].Rows.Count > 0)
                    {
                        string folderPath = Server.MapPath(MemCode);
                        if (Directory.Exists(folderPath))
                        {
                            Directory.Delete(folderPath);
                        }
                        else
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        for (int i = 0; i < dsAll.Tables[0].Rows.Count; i++)
                        {
                            byte[] img = (byte[])dsAll.Tables[0].Rows[i]["Images"];
                            string serverFileName = dsAll.Tables[0].Rows[i]["serverfilename"].ToString();
                            string pdfPath = Path.Combine(folderPath, serverFileName);
                            File.WriteAllBytes(pdfPath, img);
                            zip.AddFile(pdfPath, "files");
                        }
                    }
                }

                Response.Clear();
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                // Clean up temporary folders
                foreach (string MemCode in SelectMemCode)
                {
                    string folderPath = Server.MapPath(MemCode);

                    if (Directory.Exists(folderPath))
                    {
                        Directory.Delete(folderPath, true);
                    }
                }

                Response.End();
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "dwnLoadZipFile", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }


    protected void btnPreLIC_Click(object sender, EventArgs e)
    {
        try
        {
                    int pageIndex = GrdLicId.PageIndex;
                    GrdLicId.PageIndex = pageIndex - 1;
                    BindLICID();

                    txtLICId.Text = Convert.ToString(Convert.ToInt32(txtLICId.Text) - 1);
                    if (txtLICId.Text == "1")
                    {
                    btnPreLIC.Enabled = false;
                    }
                    else
                    {
                        btnPreLIC.Enabled = true;
                        btnNextLIC.Enabled = true;
                    }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "btnPreLIC_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void btnNextLIC_Click(object sender, EventArgs e)
    {
        try
        {
                    int pageIndex = GrdLicId.PageIndex;
                    GrdLicId.PageIndex = pageIndex + 1;
                    BindLICID();
                    txtLICId.Text = Convert.ToString(Convert.ToInt32(txtLICId.Text) + 1);
                    btnPreLIC.Enabled = true;
                    int page = GrdLicId.PageCount;
                    if (txtLICId.Text == Convert.ToString(GrdLicId.PageCount))
                    {
                        btnNextLIC.Enabled = false;
                    }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "btnPreLIC_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }

    }

    protected void GrdLicId_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = BindLICID();
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;
            dgSource.PageIndex = e.NewPageIndex;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "GrdLicId_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindLICID();

        }

        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "btnNextPannel2_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ConvertRDLCToPDF(String Memcode)
    {

        string strAppoint = string.Empty;
        strAppoint = "WelcomeLetter";
        string strFileRePath = string.Empty;
        if (Directory.Exists(strPath) == false)
        {
            strPath = strPath + Memcode + "\\";
            Directory.CreateDirectory(strPath);
        }
        else
        {
            strFileRePath = strPath + Memcode + "\\";
            if (!Directory.Exists(strFileRePath))
            {
                Directory.CreateDirectory(strFileRePath);
            }
            else
            {
                strFileRePath = strPath + Memcode + "\\";
            }
        }
        Hashtable htCRP = new Hashtable();
        htCRP.Add("@MemCode", Memcode);
        DataSet dsCRP = new DataSet();
        if (strAppoint == "WelcomeLetter")
        {
            dsCRP = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetFPWelcomeLetter", htCRP);
            ReportDataSource rdsAct = new ReportDataSource("FPWelcomeLetter", dsCRP.Tables[0]);
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.Refresh();
            viewer.LocalReport.ReportPath = strRpt + "FPWelcomeLetter.rdlc"; //This is your rdlc name.
                                                                             // viewer.LocalReport.SetParameters(param);
            viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            
            Hashtable htApp = new Hashtable();
            DataSet dsApp = new DataSet();
            htApp.Add("@MemCode", Memcode);
            htApp.Add("@UserFilename", strFileRePath);
            htApp.Add("@ServerFilename", "FPWelcomeLetter.pdf");
            htApp.Add("@PDFByte", bytes);
            htApp.Add("@CreateBy", Session["UserID"].ToString().Trim());

            dsApp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsFPConRDLCToPDF", htApp);
        }
    }

    protected void GrdLicId_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FPWelcmLttr")
        {
            string ReportType = e.CommandName;
            //GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            //Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            //Hashtable htParam = new Hashtable();
            //htParam.Add("@CndNo", lblstatus1.Text);
            //htParam.Add("@Src", ReportType);
            //htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            //dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        tr31.Visible = false;
        GrdLicId.DataSource = null;
        GrdLicId.DataBind();
    }
}


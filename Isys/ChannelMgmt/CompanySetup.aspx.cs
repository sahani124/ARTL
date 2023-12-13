//Creator:		    <Rajkapoor Yadav> 
//Create date:      <15th Sep 2021>
//Description:	    <This page is created for seting up a company in the Hierarchy system, originally this page was part of a channel setup.>
//Reviewed by:      <Abhay & Arjun Aroskar> 

//Defined  namespace
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
using System.IO;
using System.Web;
using Telerik.Web.UI;
using System.Web.Services;
using System.Text;

namespace INSCL
{
    public partial class CompanySetup : Base
    {
        DataAccessClass objDAL = new DataAccessClass();
        //Global Declaration 
        SqlDataReader dtRead;
        string saleschannel;
        string Flag;
        //added by babita
        DataSet dsResult = new DataSet();
        //ended by babita
        Hashtable htable = new Hashtable();
        private multilingualManager olng;
        string ChnTyp = string.Empty;

        //Page Load Start
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CarrierCode"] = '2';
            if (!IsPostBack)
            {
                SetSessionObjectValue("OldProductDetails", null);
                SetSessionObjectValue("ProductDetails", null);
                hdnChntype.Value = Request.QueryString["ChnTyp"].ToString();
                hdnProdcodeEdit.Value = Request.QueryString["flag"].ToString();
                if (Request.QueryString["ChnTyp"].ToString() == "O")
                {
                    //olng = new multilingualManager("DefaultConn", "CompanySetup.aspx", strUserLang);
                    olng = new multilingualManager("DefaultConn", "ChannelSetup.aspx", strUserLang);
                    //ChannelSetup
                }
                InitializeControl();
                EnableDisable();
                Label1.Text = Request.QueryString["ChnCls"];
                lblChannel.Text = Request.QueryString["ChnCls"];
                // Added by babita
                filldivchanneldet(lblChannel.Text,"0");
                //Ended by babita
                LoadData();
                if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                {
                    btnSave.Enabled = false;
                }
            }
            lblSaleschannel.Text = "Company Code";
            fillFinyr();
            ddlParentChnl.Items.Insert(0, new ListItem("Select", "0"));
            checkImage();
        }
        //Page Load Ends here
        //added by babita
        private void filldivchanneldet(string text, string Flag)
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            string s = string.Empty;
            string s1 = string.Empty;
            ht.Add("@Bizsrc", text);
            ht.Add("@Flag", Flag);
            dsResult = objDAL.GetDataSetForPrc("Prc_GetChannel", ht);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dsResult.Tables[0].Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                           s = dsResult.Tables[0].Rows[i]["ChannelDesc01"].ToString();
                            s1 = dsResult.Tables[0].Rows[i]["ActiveFlag"].ToString();
                        }
                        else if(i< dsResult.Tables[0].Rows.Count)
                        {
                            s = s+","+dsResult.Tables[0].Rows[i]["ChannelDesc01"].ToString();
                            s1 = s1 + "," +dsResult.Tables[0].Rows[i]["ActiveFlag"].ToString();
                        }
                        else
                        {
                            s = s+dsResult.Tables[0].Rows[i]["ChannelDesc01"].ToString();
                            s1 = s1 + "," + dsResult.Tables[0].Rows[i]["ActiveFlag"].ToString();
                        }
                        
                        
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Adddiv('" + s + "','S','" + s1 + "');", true);
                }
            }
        } 
        //ended by babita
        private void checkImage()
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@Bizsrc", lblChannel.Text);
            dsResult = objDAL.GetDataSetForPrc("Prc_GetChannelImage", ht);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    byte[] imageBytes = (byte[])dsResult.Tables[0].Rows[0]["Images1"];
                    //byte[] imageBytes = dsResult.Tables[0].Rows[0]["Images1"].ToString();
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Construct the image source with the Base64 string
                    string imageSource = "data:image/jpeg;base64," + base64String;

                    // Set the source of the image control
                    Img.ImageUrl = imageSource;
                }
            }
        }


        private void EnableDisable()
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString() == "N" || Request.QueryString["flag"].ToString() == "IN")
                {
                    this.lblChannel.Visible = false;
                    this.txtChannel.Visible = true;
                    divModification.Visible = false;
                    txtVer.Text = "1.00";
                    btnUpdate.Visible = false;
                    btnshowHist.Visible = false;
                    ddlParentChnl.Enabled = false;
                    ddllStatus.Enabled = false;
                    txtVer.Enabled = false;
                    txtCseDt1.Enabled = false;
                    txtSortorder.Enabled = false;
                }
                else
                {
                    btnSave.Visible = false;
                    this.lblChannel.Visible = true;
                    this.txtChannel.Visible = false;
                    this.txtSortorder.Enabled = false;
                    ControlEnableddesable();
                }
            }
            else
            {
                txtEffDate.Enabled = false;
                this.lblChannel.Visible = true;
                this.txtChannel.Visible = false;
                this.hidFlag.Value = "F";
            }
        }

        private void LoadData()
        {
            if (Request.QueryString["ChnCls"] != null)
            {
                string BizSrc = Request.QueryString["ChnCls"];
                clsChannelSetup channelcode = new clsChannelSetup();
                dtRead = channelcode.Select(BizSrc, Session["CarrierCode"].ToString().Trim());
                if (Request.QueryString["flag"].ToString() != "V") /* This is for Retriving data when update mode is selected. */
                {
                    if (dtRead.Read())
                    {
                        txtDesc1.Text = dtRead[1].ToString();
                        txtDesc2.Text = dtRead[2].ToString();
                        txtDesc3.Text = dtRead[3].ToString();
                        txtSortorder.Text = dtRead[4].ToString();
                        txtFinYr.Text = dtRead[5].ToString();
                        txtVer.Text = dtRead[6].ToString();
                        txtEffDate.Text = dtRead[7].ToString();
                        txtCseDt.Text = dtRead[8].ToString();
                        txtComp.Text = dtRead[10].ToString();
                        rdoBusiYr.SelectedValue = dtRead[14].ToString();
                        txtCseDt1.Text = dtRead[15].ToString();
                        hdnProdcodeEdit.Value = "E";
                        hdnEffdate.Value = dtRead[7].ToString();
                        txtIncorporation.Text = dtRead[11].ToString();
                        txtIrdaLcn.Text = dtRead[12].ToString();
                        txtRegAddr.Text = dtRead[13].ToString();
                        CatComp();
                        ddlinsurance.SelectedValue = dtRead[9].ToString();
                        txtRegPan.Text=dtRead[16].ToString();
                        txtRegGstin.Text = dtRead[17].ToString();
                        if (txtRegGstin.Text != "")
                        {
                            txtgststcode.Text = txtRegGstin.Text.Substring(0, 2);
                            txtgstpan.Text = txtRegGstin.Text.Substring(2, 10);
                            txtgstothr.Text= txtRegGstin.Text.Substring(12, 3);
                        }
                        
                        txtRegCin.Text=dtRead[18].ToString();
                        txtLeiid.Text=dtRead[19].ToString();
                        txtCkycId.Text=dtRead[20].ToString();
                        txtPhoneNo.Text = dtRead[21].ToString();
                        txtCCN.Text = dtRead[22].ToString();
                        txtEmailId.Text= dtRead[23].ToString();
                        txtWebsite.Text = dtRead[24].ToString();
                    }
                }

            }
        }



        //This  cancel click event is for rendering the controls to Company setup master page.
        protected void Cancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "V")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "cancel('" + Request.QueryString["flag"].ToString().Trim() + "','" + Request.QueryString["ChnTyp"].ToString().Trim() + "');", true);
                }
                else
                {
                    if (Request.QueryString["ChnTyp"].ToString().Trim() == "O")
                    {
                        Server.Transfer("CompanyMaster.aspx");
                    }
                }
            }
            else if (Request.QueryString["ChnTyp"].ToString().Trim() == "O")
            {
                Server.Transfer("CompanyMaster.aspx");
            }
        }


        //Method UpdateAddCompanySetup is used for updating the existing records of company setup.
        public void UpdateAddCompanySetup(Hashtable htable)
        {
            InsertAndUpdateValues(htable);

            if (Flag == "N" && ChnTyp == "O")
            {
                InsertData("PRC_INS_CMPSU", htable, "INSCCommonConnectionString");
                btnSave.Enabled = false;
            }
            else
            {
                InsertData("PRC_UPT_CMPSU", htable, "INSCCommonConnectionString");
                btnUpdate.Enabled = false;
            }
            if (Request.QueryString["ChnCls"] != null)
            {
                lbl_popup.Text = "Company is updated successfully<br/><br/>" + "Company: " + lblChannel.Text + "<br/><br/>Company description: " + txtDesc1.Text;
            }
            else
            {
                lbl_popup.Text = "Company is added successfully<br/><br/>" + "Company: " + txtChannel.Text + "<br/><br/>Company description: " + txtDesc1.Text;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        }


        //Initializes and adds values in Hashtable object inorder to insert or update the recods in the database.
        private void InsertAndUpdateValues(Hashtable htable)
        {
            if (this.txtChannel.Visible == true)
            {
                saleschannel = this.txtChannel.Text.ToUpper();
            }
            else
            {
                saleschannel = this.lblChannel.Text.ToUpper();
            }
            if (txtVer.Text.Trim() == "")
            {
                txtVer.Text = "1.00";
            }
            FillTextboxDatetm(htable, "@EffDate", txtEffDate.Text.Trim().ToString());
            FillTextboxDatetm(htable, "@FrzBsnssFlg", txtCseDt1.Text.Trim().ToString());
            FillddlcheckNull(ddlinsurance, htable, "@Insuranctype", ddlinsurance.SelectedValue.ToString());
            FillTextboxDatetm(htable, "@YrInc", txtIncorporation.Text.Trim().ToString());
            htable.Add("@LcnNo", this.txtIrdaLcn.Text.Trim());
            htable.Add("@OffcAddr", this.txtRegAddr.Text.Trim());
            htable.Add("@CorpOffcAddr", this.txtCorpOfcAddr.Text.Trim());
            htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
            htable.Add("@BizSrc", this.saleschannel);
            htable.Add("@ChannelDesc01", this.txtDesc1.Text.Trim());
            htable.Add("@ChannelDesc02", this.txtDesc2.Text.Trim());
            htable.Add("@ChannelDesc03", this.txtDesc3.Text.ToString());
            //htable.Add("@SortOrder", this.txtSortorder.Text.Trim());
            htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            htable.Add("@Flag", Flag);
            htable.Add("@ChnlTyp", Request.QueryString["ChnTyp"].ToString().Trim());
            htable.Add("@Period", ddlFinancialYr.SelectedValue.Trim());
            htable.Add("@Version", this.txtVer.Text.Trim());
            htable.Add("@ModMode", this.rbCorrection.SelectedValue.Trim());
            htable.Add("@Parnt_ChnlID", this.ddlParentChnl.SelectedValue.Trim());
            htable.Add("@Status", this.ddllStatus.SelectedValue.Trim());
            htable.Add("@CompName", this.txtComp.Text.ToString());
            htable.Add("@CeaseDate", this.txtCseDt.Text.ToString());
            FillrbcheckNull(rdoBusiYr, htable, "@BusYrFlg", rdoBusiYr.SelectedValue);
           // htable.Add("@PanNo", this.txtRegPan.Text.ToString().Trim());
            string gstin = txtgststcode.Text + txtgstpan.Text + txtgstothr.Text;
            if (txtgststcode.Text != "" && txtgstpan.Text != "" && txtgstothr.Text != "")
            {
                htable.Add("@PanNo", gstin);//txtGSTNO.Text.Trim());
            }
            else
            {
                htable.Add("@PanNo", System.DBNull.Value);//txtGSTNO.Text.Trim());
            }
            htable.Add("@GstinNo", this.txtRegGstin.Text.ToString().Trim());
            htable.Add("@CinNo", this.txtRegCin.Text.ToString().Trim());
            htable.Add("@LeiNo", this.txtLeiid.Text.ToString().Trim());
            htable.Add("@CkycNo", this.txtCkycId.Text.ToString().Trim());

            htable.Add("@PhoneNo", this.txtPhoneNo.Text.ToString().Trim());
            htable.Add("@CustCareNo", this.txtCCN.Text.ToString().Trim());
            htable.Add("@Email", this.txtEmailId.Text.ToString().Trim());
            htable.Add("@Website", this.txtWebsite.Text.ToString().Trim());


        }
        //This method is used for updation of existing company records.
        #region UPDATE Click Event
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAndUpdateValues(htable);
                InsertData("PRC_UPT_CMPSU", htable, "INSCCommonConnectionString");
                htable.Clear();
                btnUpdate.Enabled = false;
                RBHIDE();
                if (Request.QueryString["ChnCls"] != null)
                {
                    lbl_popup.Text = "Company is updated successfully<br/><br/>" + "Company: " + lblChannel.Text + "<br/><br/>Company description: " + txtDesc1.Text;
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ex.Message);
                var script = string.Format("alert({0});", message);
                ClientScript.RegisterStartupScript(Page.GetType(), "", script, true);
                LogException("ISYS-CHMS", "CompanySetup.aspx", "btnUpdate_Click", ex);
            }
        }
        #endregion

        //This method is used for adding of new company data.
        #region Save Click Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    Flag = Request.QueryString["flag"].ToString();
                }
                else
                {
                    Flag = "Y";
                }
                if (Request.QueryString["ChnTyp"] != null)
                {
                    ChnTyp = Request.QueryString["ChnTyp"].ToString().Trim();
                }
                InsertAndUpdateValues(htable);
                if (Flag == "N" && ChnTyp == "O")
                {
                    InsertData("PRC_INS_CMPSU", htable, "INSCCommonConnectionString");
                    htable.Clear();
                    btnSave.Enabled = false;
                }
                if (Request.QueryString["ChnCls"] == null)
                {
                    lbl_popup.Text = "Company is added successfully<br/><br/>" + "Company: " + txtChannel.Text + "<br/><br/>Company description: " + txtDesc1.Text;
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "CompanySetup.aspx", "btnSave_Click", ex);
            }
        }
        #endregion

        //Validation before data insertion for records if already exists. 
        public void ValidateInsertionData()
        {
            try
            {
                if (this.txtChannel.Text.Trim().Length!=2)//added by sanoj 10-12-2021
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Atleast Two Character');</script>", false);
                    this.txtChannel.Text = "";
                    this.txtChannel.Focus();
                    return;
                }
                DataSet dsreturn = new DataSet();

                //htable.Add("@SortOrder", this.txtSortorder.Text.Trim());
                htable.Add("@BizSrc", this.txtChannel.Text.Trim());
                dsreturn = ValidationIfDataAlreadyExists("Prc_CheckifRecordExists", htable, "INSCCommonConnectionString");
                if (dsreturn.Tables.Count != 0)
                {
                    string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                    if (comnm == "Company code already exists")
                    {
                        txtChannel.Text = "";
                        txtChannel.Focus();
                    }
                    //else if (comnm == "Sort Order already exists")
                    //{
                    //    txtSortorder.Text = "";
                    //    txtSortorder.Focus();
                    //}
                    return;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "CompanySetup.aspx", "btnSave_Click", ex);
            }
        }


        //Remove values from fields on clear button click.
        #region CLEARCONTROLS
        private void Clearcontrols()
        {
            this.txtChannel.Text = "";
            this.txtDesc1.Text = "";
            this.txtDesc2.Text = "";
            this.txtDesc3.Text = "";
            this.txtSortorder.Text = "";
        }
        #endregion

        //Filling  the Period (financial year) dropdown based on master business year setup
        protected void fillFinyr()
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@flag", "N");
            FillDropDowns(ddlFinancialYr, "Prc_get_Current_FinYear", ht, "INSCCommonConnectionString", "", true, "flagN");
        }

        //Filling up the Insurer Type dropdown based on LookUpCode"
        private void CatComp()
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@LookUpCode", "TypeIns");
            FillDropDowns(ddlinsurance, "Prc_GetddlValueForCompanySetup", ht, "INSCDirectConnectionString", "", true, "TypeIns");
        }

        //Redirecting to Company Master page.
        protected void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ChnTyp"].ToString().Trim() == "O")
                {
                    Server.Transfer("CompanyMaster.aspx");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "CompanySetup.aspx", "btnok_Click", ex);
            }
        }


        // Based on Chnages or correction selection enable/disable controls using defined method.
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ControlEnableddesable();

        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "checksselect();", true);
        }

        //Validation for checking if Company code already exists.
        protected void txtChannel_TextChanged(object sender, EventArgs e)
        {
            ValidateInsertionData();
        }

        //Validation for checking if Sortorder already exists.
        //protected void txtSortorder_TextChanged(object sender, EventArgs e)
        //{
        //    ValidateInsertionData();
        //}

        //Initializing of lables using database.
        #region InitializeControl
        private void InitializeControl()
        {
            lblDesc1.Text = (olng.GetItemDesc("lblDesc1.Text"));
            lblDesc2.Text = (olng.GetItemDesc("lblDesc2.Text"));
            lblDesc3.Text = (olng.GetItemDesc("lblDesc3.Text"));
            lblSortorder.Text = (olng.GetItemDesc("lblSortorder.Text"));
            lblPer.Text = (olng.GetItemDesc("lblPeriod"));
            lblVer.Text = (olng.GetItemDesc("lblVersion"));
            lblEffDate.Text = (olng.GetItemDesc("lblEff"));
            lblCseDt.Text = (olng.GetItemDesc("lblCease"));
            lblhdr.Text = (olng.GetItemDesc("lblhdrOth"));
            Label12.Text = (olng.GetItemDesc("lblhdrOth"));

            lblhdr.Text = "OTHER DETAILS";      //ADDED BY RAJKAPOOR FOR DEMO
            CatComp();
        }
        #endregion

        // Based on Modification Mode selection Enable/Disable controls
        #region ControlEnableddesable 
        private void ControlEnableddesable()
        {
            if (rbCorrection.SelectedValue == "CR")
            {
                txtDesc1.Enabled = true;
                txtDesc2.Enabled = true;
                txtDesc3.Enabled = true;
                txtEffDate.Enabled = true;
                ddlParentChnl.Enabled = false;
                txtSortorder.Enabled = false;
                txtComp.Enabled = false;
                ddlinsurance.Enabled = false;
                txtIncorporation.Enabled = false;
                txtIrdaLcn.Enabled = false;
                txtCseDt1.Enabled = false;
                txtRegAddr.Enabled = false;
                ddlFinancialYr.Enabled = false;
                txtVer.Enabled = false;
                txtCseDt.Enabled = false;
                ddllStatus.Enabled = false;
                CheckBox1.Enabled = false;
                rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                txtEffDate.Text = hdnEffdate.Value;
                txtEffDate.Enabled = false;
            }
            else
            {
                txtEffDate.Enabled = true;
                txtIncorporation.Enabled = true;
                ddlinsurance.Enabled = true;
                txtRegAddr.Enabled = true;
                txtCseDt.Enabled = true;
                CheckBox1.Enabled = true;
                rdoBusiYr.Enabled = true;
                txtDesc1.Enabled = false;
                txtDesc2.Enabled = false;
                txtDesc3.Enabled = false;
                ddlParentChnl.Enabled = false;
                txtSortorder.Enabled = false;
                txtComp.Enabled = true;
                txtIrdaLcn.Enabled = true;
                ddlFinancialYr.Enabled = false;
                txtVer.Enabled = false;
                ddllStatus.Enabled = false;
                rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                txtEffDate.Text = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);

            }
        }
        #endregion

        #region after update rb hide
        public void RBHIDE()
        {
            if (rbCorrection.SelectedValue == "CH")
            {
                rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
            }
            if (rbCorrection.SelectedValue == "CR")
            {
                rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
            }
        }
        #endregion
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string strDocName = FileUpload1.PostedFile.FileName;
                string strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
                try
                {
                    if (strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
                    {
                        // Get the uploaded file
                        HttpPostedFile uploadedFile = FileUpload1.PostedFile;

                        // Create a byte array to store the file data
                        byte[] fileBytes = new byte[uploadedFile.ContentLength];

                        // Read the file data into the byte array
                        using (BinaryReader reader = new BinaryReader(uploadedFile.InputStream))
                        {
                            fileBytes = reader.ReadBytes(uploadedFile.ContentLength);
                        }
                        Hashtable ht = new Hashtable();
                        ht.Clear();
                        ht.Add("@Bizsrc", lblChannel.Text.ToString().Trim());
                        ht.Add("@ImgBytes", fileBytes);
                        dsResult = objDAL.GetDataSetForPrc("Prc_UpdImgChannel", ht);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select image file.');", true);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exception that may occur during file upload
                    Console.WriteLine("File upload error: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public static string GetData(string gststatecode)
        {
            DropDownList ddlStateofgst = new DropDownList();
            DataAccessClass dataAccess = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@Gststatecode", gststatecode.Trim());
            ds = dataAccess.GetDataSetForPrc_inscdirect("Prc_Get_GstCode", ht);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Gststatecode"].ToString().Trim();
                }
                else
                {
                    return "1";
                }
            }
            else
            {
                return "1";
            }
        }

    }
}

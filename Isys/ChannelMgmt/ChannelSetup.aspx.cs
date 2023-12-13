//Creator:		    <Ajay Yadav> 
//Create date:      <17th Sep 2021>
//Description:	    <This page is created for Channel Setup.(Code Optimization)>

#region Defined  namespaces
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
using INSCL.DAL;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
using System.Text;
#endregion

namespace INSCL
{
    public partial class ChannelSetup : Base
    {
        #region Global Declaration
        //added by babita
        DataSet dssubResult = new DataSet();
        //Ended by babita
        SqlDataReader dtRead;
        string saleschannel;
        string Flag;
        DataSet dsResult = new DataSet();
        Hashtable htable = new Hashtable();
        private multilingualManager olng;
        DataAccessClass objDAL = new DataAccessClass();
        EncodeDecode ObjDec = new EncodeDecode();
        //ErrLog objErr = new ErrLog();
        INSCL.App_Code.CommonUtility oCommon = new INSCL.App_Code.CommonUtility();
        string ChnTyp = string.Empty;
        protected CommonFunc oCommon1 = new CommonFunc();
        #endregion

        #region PAGELOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["CarrierCode"] = '2';
                if (!IsPostBack)
                {
                    SetSessionObjectValue("OldProductDetails", null);
                    SetSessionObjectValue("ProductDetails", null);
                    hdnChntype.Value = Request.QueryString["ChnTyp"].ToString();
                    if (Request.QueryString["ChnTyp"].ToString() == "C")
                    {
                        olng = new multilingualManager("DefaultConn", "ChannelSetup.aspx", strUserLang);
                    }
                    EnableDisable();
                    InitializeControl();
                    Label1.Text = Request.QueryString["ChnCls"];
                    lblChannel.Text = Request.QueryString["ChnCls"];
                    //added by babita
                    filldivsubchanneldet(lblChannel.Text, "1");
                    //Ended by babita
                    LoadData();
                    if (Request.QueryString["ChnTyp"].ToString() == "C")
                    {
                        lblcomp.Text = "Channel Name";
                        lblinsurance.Text = "Channel Type";
                        lblOffc.Text = "Primary Office Address";
                        lbllcn.Visible = false;
                        txtIrdaLcn.Visible = false;
                        CatChannel(ddlinsurance);
                    }
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnSave.Enabled = false;
                    }
                    if (Request.QueryString["flag"] == "N")
                    {
                        Fill_ParentChannel();
                    }
                    else
                    {
                        //divcount.Attributes.Add("style", "display:block");
                        getcount();
                    }
                    fillFinyr();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "Page_Load", ex);
            }
        }
        #endregion
        //added by babita
        private void filldivsubchanneldet(string text , string Flag)
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            string s = string.Empty;
            ht.Add("@Bizsrc", text);
            ht.Add("@Flag", Flag);
            dssubResult = objDAL.GetDataSetForPrc("Prc_GetChannel", ht);
            if (dssubResult.Tables.Count > 0)
            {
                if (dssubResult.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dssubResult.Tables[0].Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            s = dssubResult.Tables[0].Rows[i]["ChnClsDesc01"].ToString();
                        }
                        else if (i < dssubResult.Tables[0].Rows.Count)
                        {
                            s = s + "," + dssubResult.Tables[0].Rows[i]["ChnClsDesc01"].ToString();
                        }
                        else
                        {
                            s = s + dssubResult.Tables[0].Rows[i]["ChnClsDesc01"].ToString();
                        }
                    }
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Addsubdiv('" + s + "','S');", true);
                }
            }
        }

       //Ended by babita
        

        #region Based on add or edit visiblity
        private void EnableDisable()
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString() == "N" || Request.QueryString["flag"].ToString() == "IN")
                    {
                        this.lblChannel.Visible = false;
                        this.txtChannel.Visible = true;
                        btnUpdate.Text = "<i class='glyphicon glyphicon-floppy-disk' style='color:White'></i> Save";
                        divcmphdrcollapse.Attributes.Add("style", "display:block;margin-left:2%;margin-right:2%;");
                        div1.Attributes.Add("style", "display:block;margin-left:2%;margin-right:2%;");
                        div7.Attributes.Add("style", "display:none");
                        div5.Attributes.Add("style", "display:none");
                        divModification.Visible = false;
                        btnshowHist.Visible = false;
                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        ddlParentChnl.Enabled = true ;
                        txtVer.Enabled = false;
                        txtVer.Text = "1.00";
                        /*txtCseDt1.Enabled = false;*//*need to remove*/
                        txtSortorder.Enabled = false;
                    }
                    else if (Request.QueryString["flag"].ToString() == "V")
                    {
                        btnUpdate.Visible = false;
                        divcmphdrcollapse.Attributes.Add("style", "display:none");
                        div1.Attributes.Add("style", "display:none");
                        div11.Attributes.Add("style", "display:none");
                        div13.Attributes.Add("style", "display:block;margin-left:2%;margin-right:2%;");
                        div5.Attributes.Add("style", "display:block;margin-left:2%;margin-right:2%;");
                        div7.Attributes.Add("style", "display:block;margin-left:2%;margin-right:2%;");
                    }
                    else
                    {
                        divModification.Visible = true;
                        btnshowHist.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        this.lblChannel.Visible = true;
                        this.txtChannel.Visible = false;
                        ControlEnableddesable();
                    }
                }
                else
                {
                    this.lblChannel.Visible = true;
                    this.txtChannel.Visible = false;
                    this.hidFlag.Value = "F";
                }

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "EnableDisable", ex);
            }

        }
        #endregion

        #region InitializeControl Assiging label value from data based
        private void InitializeControl()
        {
            try
            {
                lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
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
                Label2.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
                Label4.Text = (olng.GetItemDesc("lblDesc1.Text"));
                Label6.Text = (olng.GetItemDesc("lblDesc2.Text"));
                Label8.Text = (olng.GetItemDesc("lblDesc3.Text"));
                Label10.Text = (olng.GetItemDesc("lblSortorder.Text"));
                Label13.Text = (olng.GetItemDesc("lblPeriod"));
                Label15.Text = (olng.GetItemDesc("lblVersion"));
                Label17.Text = (olng.GetItemDesc("lblEff"));
                Label19.Text = (olng.GetItemDesc("lblCease"));

                lblhdr.Text = "OTHER DETAILS";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "InitializeControl", ex);
            }
        }
        #endregion

        #region Validation Before Data Insertion For Records If Already Exists. 
        public void ValidateInsertionData()
        {
            try
            {
                if (this.txtChannel.Text.Trim().Length!=2)// Added by sanoj for Validation sahani 10-12-2021
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Atleast Two Character');</script>", false);
                    this.txtChannel.Text = "";
                    this.txtChannel.Focus();
                    return;
                }
                else {
                    DataSet dsreturn = new DataSet();
                    htable.Add("@BizSrc", this.txtChannel.Text.Trim());
                    dsreturn = ValidationIfDataAlreadyExists("PRC_RECORDEXIT_CHNSU", htable, "INSCCommonConnectionString");
                    if (dsreturn.Tables.Count != 0)
                    {
                        string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                        if (comnm == "Channel code already exists")
                        {
                            txtChannel.Text = "";
                            txtChannel.Focus();
                        }
                        return;
                    }
                }
               
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "ValidateInsertionData", ex);
            }
        }
        #endregion

        #region UPDATE Click Event
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAndUpdateValues(htable);
                InsertData("PRC_UPT_CHNSU", htable, "INSCCommonConnectionString");
                htable.Clear();
                

                if (Request.QueryString["ChnCls"] != null)
                {
                    lbl_popup.Text = "Channel is updated successfully<br/><br/>" + "Channel: " + lblChannel.Text + "<br/><br/>Channel description: " + txtDesc1.Text;
                    RBHIDE();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                //btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "btnUpdate_Click", ex);
            }
        }
        #endregion

        #region Based  On Carrier Code And Bizsrc The Edit Mode Data Will Be Show In This Function.
        private void LoadData()
        {
            try
            {
                if (Request.QueryString["ChnCls"] != null)
                {
                    string BizSrc = Request.QueryString["ChnCls"];
                    clsChannelSetup channelcode = new clsChannelSetup();
                    dtRead = channelcode.SelectChnl(BizSrc, Session["CarrierCode"].ToString().Trim());
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
                           // txtComp.Text = dtRead[10].ToString();
                            Fill_ParentChannel();

                            ddlParentChnl.SelectedValue = dtRead[10].ToString();
                            //rdoBusiYr.SelectedValue = dtRead[14].ToString(); /*need to reomve*/
                            //txtCseDt1.Text = dtRead[15].ToString(); /*need to reomve*/
                            hdnProdcodeEdit.Value = "E";
                            lblcomp.Text = "Channel Name";
                            lblinsurance.Text = "Channel Type";
                            lblOffc.Text = "Primary Office Address";
                            lbllcn.Visible = false;
                            txtIrdaLcn.Visible = false;
                            CatChannel(ddlinsurance);
                            ddlinsurance.Text = dtRead[9].ToString();
                            //txtIncorporation.Text = dtRead[11].ToString();
                            //txtIrdaLcn.Text = dtRead[12].ToString();
                            //txtRegAddr.Text = dtRead[13].ToString();
                          //  GetDataTable();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "LoadData", ex);
            }
        }
        #endregion

        #region Enable Or Disable Functionality Based On Chage Or Correction Event.
        private void ControlEnableddesable()
        {
            try
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
                    /*txtCseDt1.Enabled = false;*//*need to remove*/
                    txtRegAddr.Enabled = false;
                    ddlFinancialYr.Enabled = false;
                    txtVer.Enabled = false;
                    txtCseDt.Enabled = false;
                    ddllStatus.Enabled = false;
                    CheckBox1.Enabled = false;
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                }
                else
                {
                    txtIncorporation.Enabled = true;
                    ddlinsurance.Enabled = true;
                    txtRegAddr.Enabled = true;
                    txtCseDt.Enabled = true;
                    CheckBox1.Enabled = true;
                    //rdoBusiYr.Enabled = true;/*need to reomve*/
                    txtDesc1.Enabled = false;
                    txtDesc2.Enabled = false;
                    txtDesc3.Enabled = false;
                    ddlParentChnl.Enabled = true ;
                    txtSortorder.Enabled = false;
                    txtComp.Enabled = true;
                    txtIrdaLcn.Enabled = false;
                    ddlFinancialYr.Enabled = false;
                    txtVer.Enabled = false;
                    txtEffDate.Enabled = true;
                    ddllStatus.Enabled = false;
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "ControlEnableddesable", ex);
            }
        }
        #endregion

        #region Filling  the Period (financial year) dropdown based on master business year setup.
        protected void fillFinyr()
        {
            try
            {
                htable.Clear();
                htable.Add("@flag", "N");
                FillDropDowns(ddlFinancialYr, "Prc_get_Current_FinYear", htable, "INSCCommonConnectionString", "", true, "flagN");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "fillFinyr", ex);
            }
        }
        #endregion

        #region fill financial year dropdown 
        protected void Fill_ParentChannel()
        {
            try
            {
                {
                    htable.Clear();
                    //FillDropDowns(ddlParentChnl, "Prc_Get_ParentChannel", htable, "INSCCommonConnectionString", "Select", true, "");
                    FillDropDowns(ddlParentChnl, "Prc_Get_ChannelName", htable, "INSCCommonConnectionString", "Select", false, "");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "Fill_ParentChannel", ex);
            }
        }
        #endregion

        #region Insurence Type Dropdown Fill Event.
        private void CatChannel(DropDownList ddlinsurance)
        {
            try
            {
                {
                    oCommon1.getDropDown(ddlinsurance, "TypeChannel", 1, "", 1);
                    ddlinsurance.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "CatChannel", ex);
            }
        }
        #endregion

        #region Add Product Click Event
        protected void lnkbtnaddprod_Click(object sender, EventArgs e)
        {
            try
            {
                MdlPopExtndrLOB.Show();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "lnkbtnaddprod_Click", ex);
            }
        }
        #endregion

        #region  Button Previous Click Event For Paging
        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex - 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }
                else
                {
                    btnprevious.Enabled = true;
                }
                btnnext.Enabled = true;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "btnprevious_Click", ex);
            }
        }
        #endregion

        #region Button Next Click Event For Paging
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex + 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                int page = GridProdDtls.PageCount;
                if (txtPage.Text == Convert.ToString(GridProdDtls.PageCount))
                {
                    btnnext.Enabled = false;
                }
                else
                {
                    int intPageIndex = GridProdDtls.PageIndex + 1;
                    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "btnnext_Click", ex);
            }
        }
        #endregion

        #region GrdStateDtls PageIndexChanging
        protected void GrdStateDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = GetDataTable();
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;
                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "GrdStateDtls_PageIndexChanging", ex);
            }
        }
        #endregion

        #region GetDataTable
        protected DataTable GetDataTable()
        {
            try
            {
                string strProdcode, strProdName, LOBList, strOldProdcode;
                DataTable dt = new DataTable();
                DataTable dtold = new DataTable();
                dt = (DataTable)Session["ProductDetails"];
                if (dt != null)
                {
                    strProdcode = dt.Rows[0]["ProdCode"].ToString();
                    strProdName = dt.Rows[0]["ProdName"].ToString();
                    LOBList = dt.Rows[0]["LOBList"].ToString();
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = strProdcode;
                    if (Session["OldProductDetails"] != null)
                    {
                        dtold = (DataTable)Session["OldProductDetails"];
                        strOldProdcode = dtold.Rows[0]["ProdCode"].ToString();
                        strProdcode = strProdcode + "," + strOldProdcode;
                    }
                    htable.Clear();
                    dsResult = null;
                    htable.Add("@ProdCode", strProdcode.ToString());
                    htable.Add("@LOBList", LOBList.ToString());
                    if (Request.QueryString["flag"].ToString() == "V")
                    {
                        htable.Add("@bizsrc", lblChannel.Text.Trim().ToString());
                    }
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);
                    //dsResult = FillGridViewDataSet(htable,"Prc_GetLOBProductDtls","INSCCommonConnectionString");
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            //bind old and new value to grid
                            Session["OldProductDetails"] = dt;
                            GridProdDtls.DataSource = dsResult;
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();

                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            //lblMessage.Text = "0 Record Found";
                            //div2.Attributes.Add("style", "display:none");
                        }
                    }
                }
                else
                {
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = "";
                    htable.Clear();
                    dsResult = null;
                    if (Request.QueryString["flag"].ToString() == "''")
                    {
                        htable.Add("@bizsrc", lblChannel.Text.Trim().ToString());
                    }
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            GridProdDtls.DataSource = dsResult;
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();

                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            //  div2.Attributes.Add("style", "display:none");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "GetDataTable", ex);
            }
            return dsResult.Tables[0];
        }
        #endregion

        #region ShowPageInformation
        private void ShowPageInformation()
        {
            try
            {
                tblpagination.Visible = true;
                int intPageIndex = GridProdDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "ShowPageInformation", ex);
            }
        }
        #endregion

        #region GridProdDtls RowDataBound
        protected void GridProdDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Request.QueryString["flag"].ToString() == "N")
                    {
                        Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                        lnkdelete.Enabled = false;
                    }
                    else
                    {
                        Label lblceasedate = (Label)e.Row.FindControl("lblCeaseDtim");
                        if (lblceasedate.Text != "")
                        {
                            Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                            lnkdelete.Enabled = false;
                        }
                        else
                        {
                            Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                            lnkdelete.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "GridProdDtls_RowDataBound", ex);
            }
        }
        #endregion GridProdDtls_RowDataBound

        #region lnkdelete Click From Product Grid
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btndetails = sender as Button;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                string strProdcode = ((Label)gvrow.FindControl("lblProdCode")).Text;
                string strProdName = ((Label)gvrow.FindControl("lblProdName")).Text;
                string strEffDate = ((Label)gvrow.FindControl("lblEffFromDate")).Text;
                hdn1.Value = strProdcode;
                hdn2.Value = strProdName;
                hdn3.Value = strEffDate;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "lnkdelete_Click", ex);
            }
        }
        #endregion lnkdelete_Click

        #region InsertProductDtls
        public void InsertProductDtls()
        {
            try
            {

                foreach (GridViewRow grdtls in GridProdDtls.Rows)
                {
                    string StrProdCode = ((Label)grdtls.FindControl("lblProdCode")).Text;
                    string StrEffdtim = ((Label)grdtls.FindControl("lblEffFromDate")).Text;
                    string StrLobCode = ((Label)grdtls.FindControl("lblLobCode")).Text;
                    string StrStatus = ((Label)grdtls.FindControl("lblStatus")).Text;
                    string StrCeasedate = ((Label)grdtls.FindControl("lblCeaseDtim")).Text;
                    htable = new Hashtable();
                    htable.Clear();
                    htable.Add("@Bizsrc", txtChannel.Text.ToString());//
                    htable.Add("@Flag", ChnTyp.ToString());
                    htable.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                    htable.Add("@ProdCode", StrProdCode);
                    htable.Add("@EffDate", StrEffdtim);
                    htable.Add("@LOBCode", StrLobCode);
                    htable.Add("@Status", "Active");//"A"
                    htable.Add("@Ceasedate", StrCeasedate);
                    objDAL.execute_sprcIsysTemp("Prc_InsertProductDtls", htable);
                }
                Session["OldProductDetails"] = null;
                Session["ProductDetails"] = null;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "InsertProductDtls", ex);
            }
        }
        #endregion

        #region Correction Or Changes Event
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ControlEnableddesable();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "rbCorrection_OnSelectedIndexChanged", ex);
            }
        }
        #endregion

        #region Checkbox Event For Freeze Bussiness Date
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "checksselect();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "CheckBox1_CheckedChanged", ex);
            }
        }
        #endregion

        #region Initializes And Adds Values In Hashtable Object Inorder To Insert Or Update The Recods In The Database.
        private void InsertAndUpdateValues(Hashtable htable)
        {
            try
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
                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", saleschannel);
                htable.Add("@ChannelDesc01", txtDesc1.Text.Trim());
                htable.Add("@ChannelDesc02", txtDesc2.Text.Trim());
                htable.Add("@ChannelDesc03", txtDesc3.Text.Trim());
                htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                htable.Add("@Flag", Flag);
                htable.Add("@ChnlTyp", Request.QueryString["ChnTyp"].ToString().Trim());
                htable.Add("@Period", ddlFinancialYr.SelectedValue.Trim());
                htable.Add("@Version", txtVer.Text.Trim());
                htable.Add("@ModMode", rbCorrection.SelectedValue.Trim());
                FillddlcheckNull(ddlParentChnl, htable, "@Parnt_ChnlID", ddlParentChnl.SelectedValue.Trim());
                htable.Add("@LcnNo", txtIrdaLcn.Text.Trim());
                htable.Add("@OffcAddr", txtRegAddr.Text.Trim());
                htable.Add("@CompName", this.txtComp.Text.ToString());
                htable.Add("@CeaseDate", this.txtCseDt.Text.ToString());
                /*FillrbcheckNull(rdoBusiYr, htable, "@BusYrFlg", rdoBusiYr.SelectedValue);*//*need to reomve*/
                FillddlcheckNull(ddlinsurance, htable, "@Insuranctype", ddlinsurance.SelectedValue);
                /*FillTextboxDatetm(htable, "@FrzBsnssFlg", txtCseDt1.Text.ToString().Trim());*//*need to remove*/
                FillTextboxDatetm(htable, "@YrInc", txtIncorporation.Text.Trim().ToString());
                FillTextboxDatetm(htable, "@EffDate", txtEffDate.Text.Trim().ToString());
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "InsertAndUpdateValues", ex);
            }

        }
        #endregion

        #region This Method Is Used For Adding Of New Channel Data.
        protected void btnSave_Click(object sender, EventArgs e)
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
            if (Flag == "N" && ChnTyp == "C")
            {
                InsertData("PRC_INS_CHNSU", htable, "INSCCommonConnectionString");
                htable.Clear();
                btnSave.Enabled = false;
            }
            if (Request.QueryString["ChnCls"] == null)
            {
                lbl_popup.Text = "Channel is added successfully<br/><br/>" + "Channel: " + txtChannel.Text + "<br/><br/>Channel description: " + txtDesc1.Text;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        }
        #endregion

        #region Validation For Channel  Records If Already Exists. 
        protected void txtChannel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateInsertionData();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "txtChannel_TextChanged", ex);
            }
        }
        #endregion

        #region Cancel Click Event
        protected void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "V")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "cancel('" + Request.QueryString["flag"].ToString().Trim() + "','" + Request.QueryString["ChnTyp"].ToString().Trim() + "');", true);
                    }
                    else
                    {
                        if (Request.QueryString["ChnTyp"].ToString().Trim() == "C")
                        {
                            Server.Transfer("ChannelMas.aspx");
                        }
                        else if (Request.QueryString["ChnTyp"].ToString().Trim() == "O")
                        {
                            Server.Transfer("CompanyMaster.aspx");
                        }
                    }
                }
                else if (Request.QueryString["ChnTyp"].ToString().Trim() == "C")
                {
                    Server.Transfer("ChannelMas.aspx");
                }
                else if (Request.QueryString["ChnTyp"].ToString().Trim() == "O")
                {
                    Server.Transfer("CompanyMaster.aspx");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "Cancel_Click", ex);
            }

        }
        #endregion

        #region after update rb hide
        public void RBHIDE()
        {
            try
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
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelSetup.aspx", "RBHIDE", ex);
            }

        }
        #endregion

        //bind active inactive count by ajay start 29 may 2023
        protected void getcount()
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            string s = string.Empty;
            ht.Add("@Bizsrc", lblChannel.Text);
            dssubResult = objDAL.GetDataSetForPrc("Prc_getChnl_count", ht);
            StringBuilder sb = new StringBuilder();
            if (dssubResult.Tables.Count > 0)
            {
                //if (dssubResult.Tables[0].Rows.Count > 0)
                //{

                //    for (int i = 0; i <= dssubResult.Tables[0].Rows.Count - 1; i++)
                //    {
                //        string active = dssubResult.Tables[0].Rows[i]["Active"].ToString();
                //        string inactive = dssubResult.Tables[0].Rows[i]["terminated"].ToString();

                //        sb.Append("<div id=\"dynamicDiv_" + i + "\" style=\"background-color: #f3255e; padding: 10px; width: 15%; float: left; margin-right: 10px;\">");
                //        sb.Append("<label style=\"color: white;\">" + active  + inactive + "</label><br>");
                //        sb.Append("<label style=\"color: white;\">Active  Inactive</label><br>");
                //        sb.Append("<h4 style=\"color: white;\">Total Member Count</h4>");
                //        sb.Append("</div>");
                //    }
                //    string divContent = sb.ToString();
                //    container.InnerHtml = divContent;

                //}
                //3.0
                if (dssubResult.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dssubResult.Tables[0].Rows.Count - 1; i++)
                    {
                        string active = dssubResult.Tables[0].Rows[i]["Active"].ToString();
                        string inactive = dssubResult.Tables[0].Rows[i]["terminated"].ToString();
                        string ChnClsDesc01 = dssubResult.Tables[0].Rows[i]["ChnClsDesc01"].ToString();
                        
                        //sb.Append("<div id=\"dynamicDiv_" + i + "\" style=\"background-color: #f3255e; padding: 10px; width: 15%; float: left; margin-right: 10px;\">");
                        //sb.Append("<div style=\"position: relative;\">");
                        //sb.Append("<label style=\"color: white;\">Active</label>");
                        //sb.Append("<label style=\"color: white; position: absolute; right: 0;\">Inactive</label>");
                        //sb.Append("<div style=\"clear: both;\"></div>");
                        //sb.Append("<label style=\"color: white; position: relative;\">" + active + "</label>");
                        //sb.Append("<label style=\"color: white; position: absolute; right: 0;\">" + inactive + "</label>");
                        //sb.Append("</div>");
                        //sb.Append("<h4 style=\"color: white;\">Total Member Count</h4>");
                        //sb.Append("</div>");

                        sb.Append("<div id=\"dynamicDiv_" + i + "\" style=\"background-color: #aef29d; padding: 8px; width: 15%; float: left; margin: 6px -3px 0px 10px;min-height:100px;\">");
                        sb.Append("<div style=\"position: relative;\">");
                        sb.Append("<div>");
                        sb.Append("<label style=\"color: #404040;font-size: 11px;margin-left: -128px;\">Active</label>");
                        sb.Append("<label style=\"color: #404040; position: absolute; right: 0;font-size: 11px;\">Inactive</label>");
                        sb.Append("</div>");
                        sb.Append("<div style=\"clear: both;\"></div>");
                        sb.Append("<div>");
                        sb.Append("<label style=\"color: #404040; position: relative;font-size: 15px;margin-left: -128px;\">" + active + "</label>");
                        sb.Append("<label style=\"color: #404040; position: absolute; right: 0;font-size: 15px;\">" + inactive + "</label>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<label style=\"color: #404040;font-size: 11px;\">Total Member Count Of " + ChnClsDesc01 + "</label>");
                        //sb.Append("<h8 style=\"color: white;\"> Total Member Count Of" + ChnClsDesc01 + "</h8>");
                        sb.Append("</div>");



                    }

                    string divContent = sb.ToString();
                    container.InnerHtml = divContent;
                }

                //2.0
                //if (dssubResult.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i <= dssubResult.Tables[0].Rows.Count - 1; i++)
                //    {
                //        string active = dssubResult.Tables[0].Rows[i]["Active"].ToString();
                //        string inactive = dssubResult.Tables[0].Rows[i]["terminated"].ToString();

                //        sb.Append("<div id=\"dynamicDiv_" + i + "\" style=\"background-color: #f3255e; padding: 10px; width: 30%; margin-bottom: 10px;\">");

                //        sb.Append("<div style=\"width: 50%; float: left;\">");
                //        sb.Append("<label style=\"color: white;\">Active: " + active + "</label><br>");
                //        sb.Append("<label style=\"color: white;\">Inactive: " + inactive + "</label><br>");
                //        sb.Append("</div>");

                //        sb.Append("<div style=\"width: 50%; float: right;\">");
                //        sb.Append("<label style=\"color: white;\">Active: " + active + "</label><br>");
                //        sb.Append("<label style=\"color: white;\">Inactive: " + inactive + "</label><br>");
                //        sb.Append("</div>");

                //        sb.Append("<div style=\"clear: both;\"></div>"); // Clear float styles

                //        sb.Append("<h4 style=\"color: white;\">Total Member Count</h4>");
                //        sb.Append("</div>");
                //    }

                //    string divContent = sb.ToString();
                //    container.InnerHtml = divContent;
                //}

                else
                {

                    string active = "0";
                        string inactive = "0";
                    sb.Append("<div id=\"dynamicDiv_" + 0 + "\" style=\"background-color: #f3255e; padding: 10px; width: 15%; float: left; margin-right: 10px;\">");
                        sb.Append("<label style=\"color: white;\">" + active + " / " + inactive + "</label><br>");
                        sb.Append("<label style=\"color: white;\">Active / Inactive</label><br>");
                        sb.Append("<h4 style=\"color: white;\">Total Member Count</h4>");
                        sb.Append("</div>");
                    string divContent = sb.ToString();
                    container.InnerHtml = divContent;
                }
            }
        }

        //bind active inactive count by ajay end 29 may 2023
    }
}

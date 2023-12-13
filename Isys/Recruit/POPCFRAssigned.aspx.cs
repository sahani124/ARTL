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
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_INSC_Recruit_POPCFRAssigned : BaseClass
{
    //Page added by rachana to show a popup to show status of CFR
    
    #region Global Declaration
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsResult = new DataSet();
    DataSet ds_Remark = new DataSet();
    Hashtable htCFR = new Hashtable();
    //string usertype = string.Empty;
    string strCandidateNo = string.Empty;
    string strpopidentifier = string.Empty;
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    string stracsuser = string.Empty;
    #endregion
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRenewalDtls();
            GetReExamDtls();
           
            strCandidateNo = Request.QueryString["CndNo"].ToString();
            strpopidentifier = Request.QueryString["Popup"].ToString();
            
            stracsuser = Request.QueryString["user"].ToString();//Added by rachana
            
            BindGrid();
            
        }

    }
    #endregion

    #region set ReExamFlag,ExamType,RenewalFlag,Count
    private void GetRenewalDtls()
    {
        Hashtable htRe = new Hashtable();
        DataSet dsRe = new DataSet();
        htRe.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsRe = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htRe);
        //viewstate for inserting fees details
        ViewState["RenewalFlag"] = dsRe.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
        ViewState["ProcessType"] = dsRe.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
    }

    private void GetReExamDtls()
    {
        Hashtable htReExam = new Hashtable();
        DataSet dsReExam = new DataSet();
        htReExam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsReExam = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htReExam);
        //viewstate for inserting fees details
        ViewState["ReExmType"] = dsReExam.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
        ViewState["ReExamFlag"] = dsReExam.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
    }
    #endregion


    #region Method Bindgrid()
    protected void BindGrid()
    {

        if (Request.QueryString["Popup"].ToString()=="Inbox")//(strpopidentifier == "Inbox")
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);
            if (ViewState["ProcessType"].ToString() != "NC")
            {
                if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                {
                    htCFR.Add("@Flag", "RW");
                }
                else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                {
                    htCFR.Add("@Flag", "RE");
                }
                else
                {
                    htCFR.Add("@Flag", "NR");
                }
            }
            else {

                htCFR.Add("@Flag", "NC");
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_AssignedCFR_bracheduser", htCFR);
        }
        else if (Request.QueryString["Popup"].ToString() == "Responded")//(strpopidentifier == "Responded")
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);

            if (ViewState["ProcessType"].ToString() != "NC") 
            {
                if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htCFR.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htCFR.Add("@Flag", "RE");
            }
            else
            {
                htCFR.Add("@Flag", "NR");
            }
        }
         else
            {
                htCFR.Add("@Flag", "NC");
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htCFR);
           
        }
        //Added by pranjali on 25022014 for displaying CFR detail grid start
        else if (Request.QueryString["Popup"].ToString() == "CFRDetail")//(strpopidentifier == "Responded")
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);

            if (ViewState["ProcessType"].ToString() != "NC")
            {
                if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                {
                    htCFR.Add("@Flag", "RW");
                }
                else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                {
                    htCFR.Add("@Flag", "RE");
                }
                else
                {
                    htCFR.Add("@Flag", "NR");
                }
            }
            else
            {
                htCFR.Add("@Flag", "NC");
            }
            DataSet dsCfruser = new DataSet();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            if (ViewState["MemberType"] != "SM ")
            {
                htCFR.Add("@UserId", Session["UserID"].ToString());
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRStatus", htCFR);

        }
        //Added by pranjali on 25022014 for displaying CFR detail grid end
        else
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", strCandidateNo);
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                if (ViewState["ProcessType"].ToString() == "NC")
                { 
                    htCFR.Add("@Flag", "NC"); 
                }
                else
                {
                    htCFR.Add("@Flag", "RW");
                }
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htCFR.Add("@Flag", "RE");
            }
            else
            {
                if (ViewState["ProcessType"].ToString() == "NC")
                {
                    htCFR.Add("@Flag", "NC");
                }
                else
                {
                    htCFR.Add("@Flag", "NR");
                }
            }
            DataSet dsCfruser = new DataSet();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            if (MemberType != "SM ")
            {
                htCFR.Add("@UserId", Session["UserID"].ToString());
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ClosedCFR_bracheduser", htCFR);
           
        }
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                //if (Request.QueryString["Popup"].ToString() == "Inbox" && Request.QueryString["UserType"].ToString() == "HO")
                if (Request.QueryString["Popup"].ToString() == "Inbox"  && Request.QueryString["User"].ToString() == "Lic")
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    dgDetails.Columns[1].Visible = false;
                    btnSubmit.Visible = false;
                    BindLabels();
                    BindGrid1(); //Added by pranjali on 10-02-2014 for remark grid visible
                    
                }
                else if (Request.QueryString["Popup"].ToString() == "Inbox" && Request.QueryString["User"].ToString() != "Lic")//if (strpopidentifier == "Inbox" && usertype != "HO")//Branched User inbox cfr
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    dgDetails.Columns[1].Visible = true;
                    
                    btnSubmit.Visible = true;
                    BindLabels();
                    btnRespond.Visible = true;
                    BindGrid1();//Added by pranjali on 10-02-2014 for remark grid visible
                }
                else if (Request.QueryString["Popup"].ToString() == "Responded" && Request.QueryString["User"].ToString() == "Lic")//if (strpopidentifier == "Responded" && usertype=="HO")//Admin user responded cfr
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.Columns[3].Visible = false;
                    dgDetails.Columns[1].Visible = true;
                    btnSubmit.Visible = true;
                    dgDetails.DataBind();
                    lblHeader.Text = "Responded CFR";
                    BindGrid1();//Added by pranjali on 10-02-2014 for remark grid visible
                    BindLabels();
                }
                else if (Request.QueryString["Popup"].ToString() == "Responded" && Request.QueryString["User"].ToString() != "Lic")//if (strpopidentifier == "Responded" && usertype != "HO")//branched user responded cfr
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.Columns[3].Visible = false;
                    dgDetails.Columns[1].Visible = false;
                    dgDetails.Columns[6].HeaderText = "Closed";
                    btnSubmit.Visible = false;
                    dgDetails.DataBind();
                    lblHeader.Text = "Responded CFR";
                    BindLabels();
                    BindGrid1();//Added by pranjali on 10-02-2014 for remark grid visible
                }
                //Added by pranjali on 25022014 for displaying CFR detail grid start
                else if (Request.QueryString["Popup"].ToString() == "CFRDetail")//if (strpopidentifier == "Responded" && usertype != "HO")//branched user responded cfr
                {
                    tr3.Visible = true;
                    Tr2.Visible = true;
                    tb1.Visible = false;
                    tb2.Visible = false;
                    tb3.Visible = false;
                    btnSubmit.Visible = false;
                    GridCFRStatus.Visible = true;
                    GridCFRStatus.DataSource = dsResult.Tables[0];
                    GridCFRStatus.DataBind();
                }
                //Added by pranjali on 25022014 for displaying CFR detail grid end
                    //for both user closed cfr
                else
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    
                    dgDetails.Columns[3].Visible = false;
                    dgDetails.Columns[6].HeaderText = "Closed";
                    dgDetails.DataBind();
                    lblHeader.Text = "Closed CFR";
                    btnSubmit.Visible = false;
                    BindLabels();
                    BindGrid1();//Added by pranjali on 10-02-2014 for remark grid visible
                }


            }
            else
            {
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();


            }
        }
        else
        {
            //dgDetails.DataSource = null;
            //dgDetails.DataBind();
            BindGrid1();//Added by pranjali on 10-02-2014 for remark grid visible

        }
    }
    #endregion
    //Added by pranjali on 10-02-2014 for showing remarks grid start
    protected void BindGrid1()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
        {
            if (ViewState["ProcessType"].ToString() == "NC")
            {
                ht.Add("@Flag", "NC");
            }
            else
            {
                ht.Add("@Flag", "RW");
            }
        }
        else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
        {
            ht.Add("@Flag", "RE");
        }
        else
        {
            if (ViewState["ProcessType"].ToString() == "NC")
            {
                ht.Add("@Flag", "NC");
            }
            else
            {
                ht.Add("@Flag", "NR");
            }
        }
        DataSet dsCfruser = new DataSet();
        dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
        string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
        string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
        if (MemberType != "SM ")
        {
            ht.Add("@UserId", Session["UserID"].ToString());
        }
        ds_Remark = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRemark", ht);
        if (ds_Remark.Tables.Count > 0)
        {
            if (ds_Remark.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds_Remark.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

        }
    }
    //Added by pranjali on 10-02-2014 for showing remarks grid end

    #region Submit Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        //if (Session["UserID"].ToString() == "systemadmin")//for admin
        //if (Request.QueryString["UserGrpCode"].ToString() == "LICTEAM")  //Licensing Team user
        //{
        if (Request.QueryString["User"].ToString() == "Lic")
        {
            try
            {
                GridViewRow[] Assignedcfr = new GridViewRow[dgDetails.Rows.Count];
                dgDetails.Rows.CopyTo(Assignedcfr, 0);
                foreach (GridViewRow row in Assignedcfr)
                {
                    CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    Label lblcfrfor = (Label)row.FindControl("lblcfr");
                    Label lblremarkid = (Label)row.FindControl("lblRemarkid");
                    if (chkassign.Checked == true)
                    {
                        htCFR.Clear();
                        dsResult.Clear();
                        htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        htCFR.Add("@CFRfor", lblcfrfor.Text);
                        htCFR.Add("@RemarkId", lblremarkid.Text);
                        
                        dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedCFR_admin", htCFR);
                    }
                }
                lblMessage.Visible = true;
                lblMessage.Text = "Submitted Sucessfully";
                
                BindGrid();
                btnSubmit.Visible = false;
                
                
            }
            catch
            {
            }
            
        }

        else
        {
            try
            {
                GridViewRow[] Assignedcfr = new GridViewRow[dgDetails.Rows.Count];
                dgDetails.Rows.CopyTo(Assignedcfr, 0);
                foreach (GridViewRow row in Assignedcfr)
                {
                    CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    Label lblcfrfor = (Label)row.FindControl("lblcfr");
                    Label lblremarkid = (Label)row.FindControl("lblRemarkid");
                    if (chkassign.Checked == true)
                    {
                        htCFR.Clear();
                        dsResult.Clear();
                        htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        htCFR.Add("@CFRfor", lblcfrfor.Text);
                        htCFR.Add("@RemarkId", lblremarkid.Text);
                        dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedCFR_bracheduser", htCFR);
                    }
                }
                lblMessage.Visible = true;
                lblMessage.Text = "Submitted Sucessfully";
                
                BindGrid();
                btnSubmit.Visible = false;
               
            }
            catch
            {
            }
            
        }
    }
    #endregion
    protected void BindLabels()
    {
        DataSet dscount = new DataSet();
        Hashtable htcount = new Hashtable();
        htcount.Add("@CndNo", Request.QueryString["CndNo"].ToString());
       if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                if (ViewState["ProcessType"].ToString() == "NC")
                {
                    htcount.Add("@Flag", "NC"); 
                }
                else
                {
                    htcount.Add("@Flag", "RW");
                }
            }
       else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
       {
           htcount.Add("@Flag", "RE");
       }
       else
       {
           if (ViewState["ProcessType"].ToString() == "NC")
           {
               htcount.Add("@Flag", "NC");
           }
           else
           {
               htcount.Add("@Flag", "NR");
           }
       }
        dscount = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetcountFor_bracheduser", htcount);


        lblcfrraisedcount.Text = dscount.Tables[0].Rows[0]["Raised"].ToString();
        lblcfrrespondedcount.Text = dscount.Tables[1].Rows[0]["Responded"].ToString();
        lblcfrclosedcount.Text = dscount.Tables[2].Rows[0]["Closed"].ToString();
    }
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)//(object sender, GridViewSelectEventArgs e) 
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
        
    }
    #region Pageindexing for displaying remarks grid
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)//(object sender, GridViewSelectEventArgs e) 
    {
        DataTable dt = GetDataTableRemarks();
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

    }
    #endregion
    #region Method used for Pageindexing for displaying remarks grid
    protected DataTable GetDataTableRemarks()
    {
        Hashtable ht = new Hashtable();
        ds_Remark.Clear();
       
        ht.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
        {
            ht.Add("@Flag", "RW");
        }
        else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
        {
            ht.Add("@Flag", "RE");
        }
        else
        {
            ht.Add("@Flag", "NR");
        }
        ds_Remark = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRemark", ht);
        return ds_Remark.Tables[0];
    }
    #endregion
    protected DataTable GetDataTable()
    {
        if (Request.QueryString["Popup"].ToString() == "Inbox")//(strpopidentifier == "Inbox")
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_AssignedCFR_bracheduser", htCFR);

        }
        else if (Request.QueryString["Popup"].ToString() == "Responded")//(strpopidentifier == "Responded")
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htCFR.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htCFR.Add("@Flag", "RE");
            }
            else 
            {
                htCFR.Add("@Flag", "NR");
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htCFR);

        }
        else
        {
            htCFR.Clear();
            htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htCFR.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htCFR.Add("@Flag", "RE");
            }
            else
            {
                htCFR.Add("@Flag", "NR");
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ClosedCFR_bracheduser", htCFR);

        }
        return dsResult.Tables[0];
    }
    protected void btnRespond_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=Edit&CndNo=" + Request.QueryString["CndNo"].ToString() + "&Type=E");
        foreach (GridViewRow row in dgDetails.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox c = (CheckBox)row.FindControl("ChkAssigned");
                Label lblcfr = (Label)row.FindControl("lblcfr");
                Label lblRemarkid  = (Label)row.FindControl("lblRemarkid");
                if (c.Checked)
                {
                    string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + Request.QueryString["CndNo"].ToString() + "&Type=R&CfrFor=" + lblcfr.Text + "&Remarkid=" + lblRemarkid.Text + "','Respond','width=900,height=670,resizable=0,left=190,scrollbars=1');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                }
            }
        }
    }
    protected void GridCFRStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = GetDataTableCFR();
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
    }
    protected DataTable GetDataTableCFR()
    {
        htCFR.Clear();
        htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString());//strCandidateNo);
	if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
        {
            htCFR.Add("@Flag", "RW");
        }
        else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
        {
            htCFR.Add("@Flag", "RE");
        }
        else
        {
            htCFR.Add("@Flag", "NR");
        }
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRStatus", htCFR);
        return dsResult.Tables[0];
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
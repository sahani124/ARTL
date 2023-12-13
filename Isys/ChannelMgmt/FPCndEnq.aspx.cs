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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
using System.Text;
using System.Drawing;

public partial class Application_ISys_ChannelMgmt_FranchiesEnrollment_FPCndEnq : BaseClass
{
    #region declaration
    private multilingualManager olng;
    string Code;
    ErrLog objErr = new ErrLog();//Added by rachana on 10-12-2013 for error log
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsResult = new DataSet();
    DataTable dtResult = new DataTable();
    EncodeDecode ObjDec = new EncodeDecode();
    Hashtable htable = new Hashtable();//Added by rachana on 26-11-2013 
    Hashtable htRprt = new Hashtable();
    DataSet dsRprt = new DataSet();
    StringBuilder Approve = new StringBuilder();
    StringBuilder Reject = new StringBuilder();
    string ApprovedCnd = string.Empty;
    string RejectdCnd = string.Empty;
    String ModuleID = string.Empty;//Added by usha on 25.06.2021
    #endregion
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "CndEnq.aspx", Session["UserLangNum"].ToString());
          //  ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            InitializeControl();
            if (!IsPostBack)
            {
                //getcolor();
                PopulateExmBodyName();
                ddlmemtype.Items.Insert(0, "Select");//ADDED BY AJAY 01 JUNE 2023
                Session["dtResult"] = null;
                InitializeControl();
               

                    //Added by swapnesh for prospect enquiry
                    if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"].ToUpper().Trim() == "PR")// || Request.QueryString["ACT"].ToUpper().Trim() == "IV")
                    {
                        //lbltitle.Text = "Prospect Enquiry";
                        lbltitle.Text = "Candidate Registration Search";
                        Label1.Visible = false;//added by amruta on 25.7.15
                        tr6.Visible = false;//added by amruta on 25.7.15
                        lblApplicationNo.Text = "Application No";//Text Prospect ID changed to Application No. by kalyani on 23-12-2013 new requirement
                        btnAddnew.Visible = true;
                        //divbtnAddnew.Visible = true;
                        trCandidateNo.Visible = false;//Added by kalyani on 3-1-2014 to make application no field visible 
                        //lblCandidateCode.Visible = false;
                        //txtCandCode.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;

                      

                        trSave.Visible = false;
                        tr2.Attributes.Add("style", "display:none");
                        tr4.Attributes.Add("style", "display:none");
                        //added by rachana end
                    }
                    //added by shreela on 15042014 start
                    //Added by pranjali on 18-10-2014 for license upload download start
                    else if (Request.QueryString["ACT"].Trim() == "Upload" || Request.QueryString["ACT"].Trim() == "Download" || Request.QueryString["ACT"].Trim() == "Dwnld" || Request.QueryString["ACT"].Trim() == "LicUpload" || Request.QueryString["ACT"].Trim() == "LicDownload")
                    {
                        if (Request.QueryString["Type"].Trim() == "RenTrn" || Request.QueryString["Type"].Trim() == "License")
                        {
                            lbltitle.Text = "Candidate Enquiry Search";
                            trDetails.Visible = false;
                            trCandidateNo.Visible = true;
                            trApplication.Visible = false;
                            //added by rachana start
                            trCodedlicdetails.Visible = false;
                            trshowrecords.Visible = true;
                
                       
                       
                            trSave.Visible = false;
                            //added by rachana end
                            //Added by pranjali on 18-10-2014 for license upload download start
                            if (Request.QueryString["Type"].Trim() == "License")
                            {
                                ViewState["AgtLicAct"] = Request.QueryString["ACT"].Trim();
                                ViewState["AgtLicType"] = Request.QueryString["Type"].Trim();
                                ViewState["AgtLicCode"] = Request.QueryString["Code"].Trim();
                            }
                        }
                    }
                    //added by shreela on 15042014 end
                    #region Report Letters
                    else if (Request.QueryString["ACT"].Trim() == "IndvReprt")
                    {

                        lbltitle.Text = "Individual Letter";
                        trDetails.Visible = false;
                        trCandidateNo.Visible = true;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = true;
                        trshowrecords.Visible = true;
         
                      
                        
                        trSave.Visible = false;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "TrnsfrReprt")
                    {

                        lbltitle.Text = "Transfer Letter";
                        trDetails.Visible = false;
                        trCandidateNo.Visible = true;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = true;
                        trshowrecords.Visible = true;
                  
                       
                      
                        trSave.Visible = false;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "CompReprt")
                    {

                        lbltitle.Text = "Composite Letter";
                        trDetails.Visible = false;
                        trCandidateNo.Visible = true;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = true;
                        trshowrecords.Visible = true;
                     
                
                        trSave.Visible = false;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "RnwlReprt")
                    {

                        lbltitle.Text = "Renewal Letter";
                        trDetails.Visible = false;
                        trCandidateNo.Visible = true;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = true;
                        trshowrecords.Visible = true;
                       
                 
                   
                        trSave.Visible = false;
                    }
                    #endregion
                }
                //added by rachana on 07032014 for Candidate Revival,All candidate enq start
                else if (Request.QueryString["type"] != null || Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["type"].Trim() == "CndRev")
                    {
                        lbltitle.Text = "Candidate Revival Search";
                        trApplication.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                   
                      
                 
                        trSave.Visible = false;
                        //added by rachana end
                    }
                    else if (Request.QueryString["Type"].Trim() == "CndAllStat") //candidate enquiry
                    {
                        lbltitle.Text = "All Candidate Status Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        trshowrecords.Visible = false;
                
                        trSave.Visible = false;
                    }
                    else if (Request.QueryString["Type"].Trim() == "CndStat") //candidate status
                    {
                        lbltitle.Text = "All Member Enquiry Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        trshowrecords.Visible = true;
                 
                        trSave.Visible = false;
                        Label1.Visible = false;
                        tr31.Visible = false;
                        trLbl.Visible = false;
                    }
                    else if (Request.QueryString["Type"].Trim() == "CandConv")
                    {
                        lbltitle.Text = "Candidate Conversion Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                
                   
                  
                        trSave.Visible = false;
                        //added by rachana end
                    }
                    else if (Request.QueryString["Type"].Trim() == "LIC")
                    {
                        lbltitle.Text = "License Upload Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                  
                  
             
                        trSave.Visible = false;
                        //added by rachana end
                    }
                    else if (Request.QueryString["Type"].Trim() == "PREFFEXM")
                    {
                        lbltitle.Text = "Preffered Exam Details Search"; //Added by kalyani on 21/04/2014
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                      
                       
                   
                        trSave.Visible = false;
                        tr2.Visible = false;
                        //added by rachana end
                    }
                    else if (Request.QueryString["Type"].Trim() == "LicRnwl")
                    {
                        lbltitle.Text = "Retrieval Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        //added by rachana start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                    
                    
                      
                        trSave.Visible = false;
                        //added by rachana end
                        lblSapcode.Text = "License No";
                        trCodedlicdetails.Visible = true; // added by pranjali on 06.04.2015
                        Label1.Visible = false;
                    }
                    //added by pranjali on 17-04-2014 start
                    else if (Request.QueryString["Type"].Trim() == "SMAlloct")
                    {
                        lbltitle.Text = "SM Allocation Search";
                        trApplication.Visible = false;
                        trDetails.Visible = false;
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                  
                    
                        trSave.Visible = false;
                    }
                    //added by pranjali on 17-04-2014 end
                    //added by shreela on 21042014---start
                    else if (Request.QueryString["Type"].Trim() == "ReExam")
                    {

                        lbltitle.Text = "ReExamination Search";
                        trDetails.Visible = false;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                  
                      
                   
                        trSave.Visible = false;
                        Label1.Visible = false;
                    }
                    //added by shreela on 21042014---end

                    //Added by rachana on 10/04/2015 for Retrival Process start
                    else if (Request.QueryString["Type"].Trim() == "PhyRet")
                    {

                        lbltitle.Text = "Retrival Document Search";
                        trDetails.Visible = false;
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                  
                     
                      
                        trSave.Visible = false;

                    }
                    //Added by rachana on 10/04/2015 for Retrival Process end

                     //added by Nikhil on 18042015 for License & ID Download---start
                    else if (Request.QueryString["Type"].Trim() == "FPWelcmLttr")
                    {

                        lbltitle.Text = "Member Search";
                        trApplication.Visible = false;//Added by kalyani on 3-1-2014 to make candidate no field visible
                        //added by Nikhil start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                   
                 
                   
                        trSave.Visible = false;
                        //added by Nikhil end
                    }
                    //added by Nikhil on 18042015---end
                    //added by usha on 31.08.2015--
                    else if ((Request.QueryString["Type"].Trim() == "NOCIC") ||(Request.QueryString["Type"].Trim() == "POSPNOCIC"))
                    {

                        lbltitle.Text = "Candidate Enquiry Search";
                        trApplication.Visible = false;//Added by kalyani on 3-1-2014 to make candidate no field visible
                        //added by Nikhil start
                        trCodedlicdetails.Visible = true;
                        trshowrecords.Visible = true;
                 
                    
                        trSave.Visible = false;
                        Label1.Visible = false;
                    }

                    //Added by pallavi on 25\08\2020 for Posp licence copy start

                    else if (Request.QueryString["Type"].Trim() == "PospLicCpy") //
                    {

                        lbltitle.Text = "Candidate Enquiry Search";

                        Label1.Text = "Candidate License Search Result";

                        trApplication.Visible = false;//
                        //added by Nikhil start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                      
                  
               
                        trSave.Visible = false;
                        //added by Nikhil end
                    }
                    //Added by pallavi on 25\08\2020 for Posp licence copy end
                    #region
                    //Added By Bhaurao
                    else if (Request.QueryString["Type"].Trim() == "viewDoc") //View Documents
                    {
                        lbltitle.Text = "View Document Search";
                        // Label4.Text = "View Document Search Result";
                    
                   
                        trApplication.Visible = false;
                        //divprospectsearch.Visible = false;
                        trshowrecords.Visible = false;
                      
                        //div4.Visible = false;
                        Label1.Text = "";
                        btnSave.Visible = false;
                        btnAddnew.Visible = false;

                        //divcntstcollapse.Visible = true;
                        //divGridCndStatus.Visible = false;
                        //divdgRenTrn.Visible = false;
                        //divdgReExam.Visible = false;
                        //divGvRprt.Visible = false;
                        //divGvRprt1.Visible = false;
                        //divGrdDocumentRet1.Visible = false;
                        //divGrdLicId1.Visible = false;
                        //divGridNOCIC.Visible = false;
                        //divdgRetrieval1.Visible = false;
                        //divdgFees1.Visible = false;
                        ////div2.Visible = false; 
                        //div4.Visible = false;
                        //divcntstcollapse.Visible = false;

                        //divconfirm.Visible = false;
                        //divconfirmbtn.Visible = false;
                        //div6.Visible = false;
                        //divnote.Visible = false;


                        //lnkCndNo_view.Visible = true;
                    }
                    #endregion

                    //added by Nikhil on 18052015 for Reterival License Copy---start
                    else if (Request.QueryString["Type"].Trim() == "RetLIC")
                    {

                        lbltitle.Text = "Reterival Search";
                        trApplication.Visible = false;//Added by kalyani on 3-1-2014 to make candidate no field visible
                        //added by Nikhil start
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                 
                    
                
                        trSave.Visible = false;
                        txtAppNo.Visible = false;
                        lblAppNo.Visible = false;
                        //added by Nikhil end
                    }
                    //added by Nikhil on 18052015---end
                    //Added by amruta on 20/07/2015 for Fees Wavier start
                    else if (Request.QueryString["Type"].Trim() == "FeesApp")
                    {

                        lbltitle.Text = "Fees Waiver Approval Search";
                        trLbl.Visible = false;
                        trDetails.Visible = false;
                        trApplication.Visible = false;
                        //trDateRange.Visible = false;
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
              
                  
                        trSave.Visible = false;
                       // tr5.Visible = false;
                        tr4.Visible = false;
                        tr2.Visible = false;
                        ////trnote.Visible = false;//amruta 26/8
                        //lblmsg.Visible = false;
                        Label1.Visible = false;
                        tr31.Visible = false;

                    }
                    //Added by amruta on 20/07/2015 for Fees Wavier end




                    //Added by usha  for Agent profile search on 24.07.2017
                    #region Agent Profilling 
                    else if (Request.QueryString["Type"].Trim() == "AgentProfile")
                    {
                        lbltitle.Text = "Candidate Search";
                        trApplication.Visible = false;
                        trCodedlicdetails.Visible = false;
                        trshowrecords.Visible = true;
                
                     
                 
                        trSave.Visible = false;
                        Label1.Visible = false;
                        tr2.Attributes.Add("style", "display:none");
                        tblSave.Attributes.Add("style", "display:none");

                    }
                    #endregion  Agent Profilling

                    //Added by usha  for Agent profile search on 24.07.2017


                   
                }
                //added by rachana on 07032014 for Candidate Revival,All candidate enq end

                else
                {
                    lbltitle.Text = "Member Modification Search";
                    trApplication.Visible = false;//Added by kalyani on 3-1-2014 to make candidate no field visible
                    //added by rachana start
                    trCodedlicdetails.Visible = false;
                    trshowrecords.Visible = true;
             
                  
                
                    trSave.Visible = false;
                    Label1.Visible = false;
                    tr2.Attributes.Add("style", "display:none");
                    tblSave.Attributes.Add("style", "display:none");
                    //added by rachana end
                }

                //Added by swapnesh End
             
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds1);
                trDgDetails.Visible = false;
                trDetails.Visible = false;
                tr6.Visible = false;
                trButton.Visible = false;
            
                GetAgentandUserDtls();
                //btnImmLeaderCode.Attributes.Add("onClick", "javascript: return funOpenPopWinForAccntPayee('AccntPayPopUpPros.aspx', document.getElementById('" + txtImmLeader.ClientID + "').value,'" + txtDirectAgtName.ClientID + "','" + txtImmLeader.ClientID + "','" + txtSmCode.ClientID + "', document.getElementById('" + ddlSlsChannel.ClientID + "').value, document.getElementById('" + ddlChnCls.ClientID + "').value, document.getElementById('" + ddlAgntType.ClientID + "').value,'3');");//Commented by kalyani on 23-12-2013 as not required

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

    private void GetAgentandUserDtls()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
                    ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
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

    #region IntializeControl
    private void InitializeControl()
    {
        try
        {
            lbltitle.Text = "Member Search";//(olng.GetItemDesc("lbltitle.Text"));
            lblAppNo.Text = (olng.GetItemDesc("lblApplicationNo.Text"));//Added by kalyani for application no field of candidate registration page
            lblCandidateCode.Text = (olng.GetItemDesc("lblCandidateCode.Text"));//lblCandidateCode.text changed to lblApplicationNo.text by kalyani on 23-12-2013 to change label name to Application No. 
            lblApplicationNo.Text = (olng.GetItemDesc("lblApplicationNo.Text"));
           // lblGivenName.Text = (olng.GetItemDesc("lblGivenName.Text"));
            lblFranName.Text = "Name";
            lblBranchName.Text = "Branch Name"; //olng.GetItemDesc("lblBranchName")
            lblSurName.Text = (olng.GetItemDesc("lblSurName.Text"));
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));//added by Shreela on 10042014
            //Commented by kalyani on 23-12-2013 as not required start
            //lblApplicationNo.Text =  (olng.GetItemDesc("lblApplicationNo.Text"));
            //lblSlsChnnl.Text =  (olng.GetItemDesc("lblSlsChnnl.Text"));
            //lblChnCls.Text =  (olng.GetItemDesc("lblChnCls.Text"));
            //lblAgtType.Text =  (olng.GetItemDesc("lblAgtType.Text"));
            //lblImmediateLeader.Text =  (olng.GetItemDesc("lblImmediateLeader.Text"));
            //Commented by kalyani on 23-12-2013 as not required end
            lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text"));
            lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));
           
            lblShwRecords1.Text = (olng.GetItemDesc("lblShwRecords.Text"));
            lblMessage.Text = (olng.GetItemDesc("lblMessage.Text"));
        
            lblSapcode.Text = (olng.GetItemDesc("lblSapcode"));
            lblAgntBroker.Text = (olng.GetItemDesc("lblAgntBroker.Text"));
        
          
            //added by pranjali on 06.04.2015 start
            if (Request.QueryString["Type"].Trim() == "LicRnwl")
            {
                lblSapcode.Text = "License No";
            }
            //added by pranjali on 06.04.2015 end
        }
        //Added by Saleem------------Start
        //lbl_agentcode.Text =  (olng.GetItemDesc("lbl_agentcode.Text"));
        //Added by Saleem------------end
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

   

    #region  PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }
    // FOR CANDIDATE STATUS PAGEINDEXING
    protected void GridCndStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            ShowPageInformationCndStatus();
            GridCndStatus.Visible = true;
            trGridCndStatus.Visible = true;
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
    //Added by shreela on 14042014 start
    protected void dgRenTrn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            GridView dgRenTrn = (GridView)sender;

            dgRenTrn.PageIndex = e.NewPageIndex;
            dv.Sort = dgRenTrn.Attributes["SortExpression"];

            if (dgRenTrn.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgRenTrn.DataSource = dv;
            dgRenTrn.DataBind();
            ShowPageInformationRenTrn();
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
    //Added by shreela on 14042014 end
    #endregion
    //Added by shreela on 21042014---start
    protected void dgReExam_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            ShowPageInformationExm();
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
    //Added by shreela on 21042014---end

    #region DATAGRID 'dgDetails' SORT EVENT
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformation();
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
    //Added by shreela on 14042014 start
    protected void dgRenTrn_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgRenTrn = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgRenTrn.Attributes["SortExpression"] != null)
            {
                strSort = dgRenTrn.Attributes["SortExpression"].ToString();
            }
            if (dgRenTrn.Attributes["SortASC"] != null)
            {
                strASC = dgRenTrn.Attributes["SortASC"].ToString();
            }

            dgRenTrn.Attributes["SortExpression"] = e.SortExpression;
            dgRenTrn.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgRenTrn.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgRenTrn.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgRenTrn.Attributes["SortExpression"];

            if (dgRenTrn.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgRenTrn.PageIndex = 0;
            dgRenTrn.DataSource = dv;
            dgRenTrn.DataBind();
            ShowPageInformationRenTrn();
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
    //Added by shreela on 14042014 end
    #endregion

    #region candidate status grid sorting
    protected void GridCndStatus_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationCndStatus();
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
    //added by shreela on 21042014---start
    protected void dgReExam_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationExm();
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
    //added by shreela  on 21042014---end

    #region METHOD 'GetDataTableRetrieval()' DEFINITION
    protected DataTable GetDataTableRetrieval()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //Added by kalyani on 3-1-2014 to insert appno start
            //to insert appno for candidate registration search
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"].ToUpper().Trim() == "PR")
                {
                    htParam.Add("@AppNo", txtAppNo.Text.Trim());
                }
                //added by shreela on 15042014 start
                else if (Request.QueryString["ACT"].ToString().Trim() == "Upload" || Request.QueryString["ACT"].ToString().Trim() == "DWNLD" || Request.QueryString["ACT"].Trim() == "LicUpload" || Request.QueryString["ACT"].Trim() == "LicDownload")
                {
                    htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
                }
                //added by shreela on 15042014 end
            }
            //to insert appno for candidate enquiry search
            else
            {
                htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
            }
            //Added by kalyni on 3-1-2014 to insert appno end
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
        
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }
            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            htParam.Add("@Page", "CndEnq");
            if (Request.QueryString["type"].Trim() == "LicRnwl")
            {
                if (ViewState["UserType"].ToString() == "I")
                {
                    htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                    htParam.Add("@LcnNo", txtSapCode.Text);
                    htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                    dsResult.Clear();
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwl", htParam);
                    //dgDetails.Columns[3].Visible = false;
                    //dgDetails.Columns[9].Visible = true;
                    //dgDetails.Columns[10].Visible = true;
                    //dgDetails.Columns[11].Visible = true;
                    //dgDetails.Columns[12].Visible = false;
                    //dgDetails.Columns[13].Visible = false;//added by rachana on 06/03/2013
                    //dgDetails.Columns[14].Visible = true;
                    //dgDetails.Columns[15].Visible = false;
                    //dgDetails.Columns[16].Visible = false;
                    //dgDetails.Columns[17].Visible = false;
                    //dgDetails.Columns[18].Visible = true;
                    lbltitle.Text = "Retrieval";
                }
                else if (ViewState["UserType"].ToString() == "E")
                {
                    dsResult.Clear();
                    htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                    htParam.Add("@LcnNo", txtSapCode.Text);
                    htParam.Add("@UserId", HttpContext.Current.Session["UserID"].ToString().Trim());//amruta added

                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwlForExtrnl", htParam);
                    //dgDetails.Columns[3].Visible = false;
                    //dgDetails.Columns[9].Visible = true;
                    //dgDetails.Columns[10].Visible = true;
                    //dgDetails.Columns[11].Visible = true;
                    //dgDetails.Columns[12].Visible = false;
                    //dgDetails.Columns[13].Visible = false;//added by rachana on 06/03/2013
                    //dgDetails.Columns[14].Visible = true;
                    //dgDetails.Columns[15].Visible = false;
                    //dgDetails.Columns[16].Visible = false;
                    //dgDetails.Columns[17].Visible = false;
                    //dgDetails.Columns[18].Visible = true;
                    lbltitle.Text = "Retrieval";
                }
            }

            Session["dtResult"] = dsResult.Tables[0];
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
        finally
        {
            //con.Close();
        }
        return dsResult.Tables[0];
    }
    #endregion

    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@EmpCode", txtFrenchCode.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@BranchName", txtBranchName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());
            htParam.Add("@FPMemCode", txtMemberCode.Text.Trim());
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }
            //For Internal UserType
            if (ViewState["UserType"].ToString() == "I")
            {
                htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetCandidateForEnquiry", htParam);
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemberForEnquiry", htParam);
            }
            //For External UserType
            else if (ViewState["UserType"].ToString() == "E")
            {
                dsResult.Clear();
               dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemForEnquiryForExtrnl", htParam);
            }
            Session["dtResult"] = dsResult.Tables[0];
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
        finally
        {
            //con.Close();
        }
        return dsResult.Tables[0];
    }
    #endregion

    #region Button 'Search Click Event'
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //Added by pranjali on 05-03-2014 for registration date validation start
            if (txtDTRegFrom.Text.ToString().Trim() != "" && txtDTRegTo.Text.ToString().Trim() != "")
            {
                if (Convert.ToDateTime(txtDTRegTo.Text) < Convert.ToDateTime(txtDTRegFrom.Text))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Registration Date From should be less than Registration Date To";
                    trDetails.Visible = false;
                    tr6.Visible = false;//added by amruta 
                    dgDetails.Visible = false;
                    return;
                }
            }
           
            //Added by pranjali on 05-03-2014 for registration date validation end
            //added by rachana on 07032014 start 
            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"] != null || Request.QueryString["Type"] != null)
                {
                    ViewState["Value"] = Request.QueryString["type"].ToString().Trim();
                    if (Request.QueryString["type"].Trim() == "CndRev")
                    {
                        lbltitle.Text = "Candidate Revival Search";
                        Label1.Text = "Candidate Revival Search Results";
                    }
                    else if (Request.QueryString["type"].Trim() == "CndStat")
                    {
                        lbltitle.Text = "Member Status Search";
                        Label6.Text = "Member Status Search Results";
                        Label6.Visible = true;
                        //tr31.Visible = true; ajay 14042023
                        trLbl.Visible = false;
                    }
                    else if (Request.QueryString["type"].Trim() == "CndAllStat")
                    {
                        tr31.Visible = true;
                        lbltitle.Text = "All Candidate Status Search";
                        Label1.Text = "All Candidate Search Results";
                    }

                    else if (Request.QueryString["Type"].Trim() == "CandConv")
                    {
                        lbltitle.Text = "Candidate Conversion Search";
                        Label1.Text = "Candidate Conversion Search Results";
                    }
                    else if (Request.QueryString["Type"].Trim() == "LIC")
                    {
                        lbltitle.Text = "License Upload Search";
                        Label1.Text = "License Upload Search Results";

                    }
                    //added by shreela on 18042014
                    else if (Request.QueryString["Type"].Trim() == "LicRnwl")
                    {
                        lbltitle.Text = "Retrieval Search";
                        Label1.Visible = true;
                        Label1.Text = "Retrieval Search Results";

                    }
                    //added by shreela on 18042014
                    //Added by kalyani on 21/04/2014 to display preferred exam title strat
                    else if (Request.QueryString["Type"].Trim() == "PREFFEXM")
                    {
                        lbltitle.Text = "Preffered Exam Search";
                        Label1.Text = "Preffered Exam Search Results";
                        tr2.Visible = true;
                    }
                    //Added by kalyani on 21/04/2014 to display preferred exam title end
                    //Added by Pranjali on 22/04/2014 to display SM Allocation title strat
                    else if (Request.QueryString["Type"].Trim() == "SMAlloct")
                    {
                        lbltitle.Text = "SM Allocation Search";
                        Label1.Text = "SM Allocation Search Results";

                    }
                    //Added by Pranjali on 22/04/2014 to display SM Allocation title end
                    //added by shreela on 21042014---start
                    else if (Request.QueryString["Type"].Trim() == "ReExam")
                    {
                        lbltitle.Text = "ReExamination Search";
                        Label1.Text = "ReExamination Search Results";
                        Label1.Visible = true;

                    }
                    //Added by Rachana on 13/04/2015 for retrival process start
                    else if (Request.QueryString["Type"].Trim() == "PhyRet")
                    {
                        lbltitle.Text = "Document Retrival";
                        Label1.Text = "Document Retrival Results";

                    }
                    //added by shreela on 21042014---end
                    //added by amruta on 20.7.15 for fees Wavier start
                    else if (Request.QueryString["Type"].Trim() == "FeesApp")
                    {
                        lbltitle.Text = "Fees Wavier Approval Search";
                        Label1.Text = "Fees Wavier Approval Search Results";
                        //lblmsg.Visible = false;
                        tr6.Visible = true;
                        trLbl.Visible = false;
                    }
                    //added by amruta on 20.7.15 for fees Wavier end
                    //Added By Bhaurao
                    else if (Request.QueryString["type"].Trim() == "viewDoc")
                    {
                        // div4.Visible = false;
                        lbltitle.Text = "View Document Search";

                        Label7.Text = "Candidate Document Search Results";//changed by sanoj 22052023
                        tr31.Visible = true; //added by sanoj 22052023
                        gvDocs.DataSource = null; //added by sanoj 22052023
                        gvDocs.DataBind();//added by sanoj 22052023
                        // Label4.Text = "Candidate Document Search Results";
                        //divnote.Visible = false;
                    }//End

                    //Added by usha  for agent Profile on 24.07.2017

                    else if (Request.QueryString["Type"].Trim() == "AgentProfile")
                    {
                        lbltitle.Text = "Agent Profilling Search";
                        Label1.Text = "Agent Profilling Search Results";
                        tr2.Visible = true;
                    }
                    //ended  by usha  for agent Profile on 24.07.2017

                }
                //added by rachana on 07032014 end
                //Added By swapnesh
                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"].ToUpper().Trim() == "PR" || Request.QueryString["ACT"].ToUpper().Trim() == "IV")
                    {
                        //lbltitle.Text = "Prospect Enquiry";
                        lbltitle.Text = "Candidate Registration Search";
                        lblApplicationNo.Text = "Application No";//Text Prospect ID changed to Application No. by kalyani on 23-12-2013 for new requirement
                        tr6.Visible = false;// added by amruta
                        Label1.Visible = true;
                    }
                    //added by shreela 
                    else if (Request.QueryString["ACT"].Trim() == "Upload")
                    {
                        lbltitle.Text = "Candidate Enqiury";
                        dgRenTrn.Columns[13].Visible = false;
                        dgRenTrn.Columns[14].Visible = true;
                        dgRenTrn.Columns[15].Visible = false;
                        dgRenTrn.Columns[16].Visible = false;
                        dgRenTrn.Columns[17].Visible = false;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "Download")
                    {
                        lbltitle.Text = "Candidate Enqiury";
                        dgRenTrn.Columns[13].Visible = false;
                        dgRenTrn.Columns[14].Visible = false;
                        dgRenTrn.Columns[15].Visible = true;
                        dgRenTrn.Columns[16].Visible = false;
                        dgRenTrn.Columns[17].Visible = true;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "Dwnld")
                    {
                        lbltitle.Text = "Candidate Enqiury";
                        dgRenTrn.Columns[13].Visible = true;
                        dgRenTrn.Columns[14].Visible = false;
                        dgRenTrn.Columns[15].Visible = false;
                        dgRenTrn.Columns[16].Visible = true;
                        dgRenTrn.Columns[17].Visible = true;
                    }
                    //Added by pranjali on 18-10-2014 for license upload download start
                    else if (Request.QueryString["ACT"].Trim() == "LicUpload")
                    {
                        lbltitle.Text = "Candidate Enqiury";
                        dgRenTrn.Columns[18].Visible = true;
                        dgRenTrn.Columns[14].Visible = false;
                        dgRenTrn.Columns[15].Visible = false;
                        dgRenTrn.Columns[16].Visible = false;
                        dgRenTrn.Columns[17].Visible = false;
                    }
                    else if (Request.QueryString["ACT"].Trim() == "LicDownload")
                    {
                        lbltitle.Text = "Candidate Enqiury";
                        dgRenTrn.Columns[19].Visible = true;
                        dgRenTrn.Columns[14].Visible = false;
                        dgRenTrn.Columns[15].Visible = false;
                        dgRenTrn.Columns[16].Visible = false;
                        dgRenTrn.Columns[17].Visible = false;
                    }
                    #region Report Letters
                    else if (Request.QueryString["ACT"].Trim() == "IndvReprt")
                    {
                        lbltitle.Text = "Individual Letter";
                    }
                    else if (Request.QueryString["ACT"].Trim() == "TrnsfrReprt")
                    {
                        lbltitle.Text = "Transfer Letter";
                    }
                    else if (Request.QueryString["ACT"].Trim() == "CompReprt")
                    {
                        lbltitle.Text = "Composite Letter";
                    }
                    else if (Request.QueryString["ACT"].Trim() == "RnwlReprt")
                    {
                        lbltitle.Text = "Renewal Letter";
                    }
                    #endregion
                    else
                    {
                        lbltitle.Text = "Prospect Enquiry";
                    }
                }

                //Added By swapnesh End

                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"].ToUpper().Trim() == "IV")
                    {
                        btnAddnew.Visible = false;
                        //divbtnAddnew.Visible = false;
                    }
                }
            }
            else
            {
                lbltitle.Text = "Member Modification Search";
                Label1.Text = "Member Modification Search Result";
                tr6.Visible = false;// added by amruta
                Label1.Visible = true;
                tr31.Visible = true;//added by ajay 14042023
            }

            //Commented by shreela on 14042014 start
            //BindDataGrid();
            //commented by shreela on 14042014 end

            //added by shreela on 14042014 start
            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"].Trim() == "CndRev" || Request.QueryString["type"].Trim() == "CndStat" || Request.QueryString["type"].Trim() == "CndAllStat"
                    || Request.QueryString["type"].Trim() == "CndStat" || Request.QueryString["Type"].Trim() == "CandConv" || Request.QueryString["Type"].Trim() == "LIC" ||
                     Request.QueryString["type"].Trim() == "E" || Request.QueryString["type"].Trim() == "PREFFEXM" || Request.QueryString["Type"].Trim() == "SMAlloct" || Request.QueryString["Type"].Trim() == "viewDoc"
                     || Request.QueryString["Type"].Trim() == "AgentProfile")
                {
                    BindDataGrid();
                }
                //Added by Rahul on 21-04-2015 for Retrieval Process start
                else if (Request.QueryString["Type"].Trim() == "LicRnwl")
                {
                    BindDataGridRetrieval();
                }
                //Added by Rahul on 21-04-2015 for Retrieval Process end
                else if (Request.QueryString["Type"].Trim() == "ReExam")
                {
                    BindDataGridReExam();
                }
                else if (Request.QueryString["Type"].Trim() == "RenTrn")
                {
                    BindDataGridRenTrn();
                }
                //REPORT LETTERS
               // else if (Request.QueryString["Type"].Trim() == "Rprt")
                //{
                //    BindReport();
                //}
                //Added by pranjali on 18-10-2014 for license upload download start
                else if (Request.QueryString["Type"].Trim() == "License")
                {
                    LicenseUpldDwnld();
                }
                //Added by rachana on 13\04\2015 for retrival process start
                //else if (Request.QueryString["Type"].Trim() == "PhyRet")
                //{
                //    BindRetrivalGrid();
                //}
                //Added by rachana on 13\04\2015 for Agent License process end
                //Added by Nikhil on 13\04\2015 for retrival process start
                else if (Request.QueryString["Type"].Trim() == "FPWelcmLttr")
                {
                    BindLICID();
                }
                //Added by nikhil on 13\04\2015 for retrival process end
                ////Added by nikhil on 18\05\2015 for retrival process end
                //else if (Request.QueryString["Type"].Trim() == "RetLIC")
                //{
                //    BindRETLICID();
                //}
                //Added by nikhil on 15\04\2015 for retrival process end
                //Added by amruta on 20\07\2015 for fees Wavier process start
                else if (Request.QueryString["Type"].Trim() == "FeesApp")
                {
                    BindFeesGrid();

                }
                //Added by amruta on 20\07\2015 for fees Wavier process end
                //else if ((Request.QueryString["Type"].Trim() == "NOCIC")||(Request.QueryString["Type"].Trim() == "POSPNOCIC"))
                //{
                //    BindNOCIC();
                //}
                ////Added by pallavi on 25\08\2020 for Posp licence copy start
                //else if (Request.QueryString["Type"].Trim() == "PospLicCpy")
                //{
                //    BindLICPosp();
                //}

                     //Added by pallavi on 25\08\2020 for Posp licence copy end
          }
            else
            {
                BindDataGrid();
            }
            //added by shreela on 14042014 end
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


    //added by amruta on 20.7.15 start
    protected void BindFeesGrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();

      
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@Appno", txtApplicatoNo.Text.Trim());//added by pranjali on 20-03-2014 
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
          
          

            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            //htParam.Add("@UserType", Session["UnitRank"].ToString().Trim());
            //htParam.Add("@UserAuthCode", Session["UnitCode"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            //htParam.Add("@Page", "CndAprFees");
            //if (ViewState["UserType"].ToString() == "I")
            //{
            // htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
            htParam.Add("@MemberType", ViewState["MemberType"].ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_CandListForFees", htParam);
            /// }
            //For External UserType
            //else if (ViewState["UserType"].ToString() == "E")
            //{
            //    dsResult.Clear();
            //    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApprovalForExtrnl", htParam);
            //}
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            //dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgFees.DataSource = dsResult.Tables[0];
                    dgFees.DataBind();
                    ShowPageInformation();
                    tr31.Visible = true;
                    tr6.Visible = true;//added by amruta
                    Label1.Visible = true;
                    trLbl.Visible = true;
                    trDgFees.Visible = true;
                    trButton.Visible = true;
                    //  btnSubmit.Enabled = true;
                    //btnCancel.Enabled = true;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    //trnote.Visible =true;
                    // chkrcvd.Visible = true;//Added by Nikhil on 08062015
                    //lblconfirm.Visible = true;
                    tr2.Visible = true;
                    tr4.Visible = true;
                   // tr5.Visible = false;
                }
                else
                {
                    trLbl.Visible = true;
                    dgFees.DataSource = null;
                    dgFees.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgFees.Visible = false;
                    trButton.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                  //  lblmsg.Visible = true;
                    //chkrcvd.Visible = false; //Added by Nikhil on 08062015
                    //btnSubmit.Enabled = false;
                    //btnCancel.Enabled = true;
                    //trnote.Visible = false;
                    //lblconfirm.Visible = false;
                    tr2.Visible = false;
                    tr4.Visible = false;
                   // tr5.Visible = false;
                    tr6.Visible = false;
                }
            }
            else
            {
                dgFees.DataSource = null;
                dgFees.DataBind();
                lblPageInfo.Text = "";
                tr6.Visible = false;
                Label1.Visible = false;
                trDetails.Visible = false;
                trDgFees.Visible = false;
                trButton.Visible = false;
                // lblMessage.Visible = true;
                // lblMessage.Text = "0 Record Found";
                //lblmsg.Visible = true;

                //  btnSubmit.Enabled = false;
                //btnCancel.Enabled = true;
                //trnote.Visible = false;
                //tr2.Visible = false;
                //tr4.Visible = false;
                //tr5.Visible = false;
            }

            BindGridControl(dgFees);
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

    private void BindGridControl(GridView objDatagrid)
    {
        try
        {
            GridViewRow[] ApprovalArray = new GridViewRow[objDatagrid.Rows.Count];
            objDatagrid.Rows.CopyTo(ApprovalArray, 0);
            string PrID;
            foreach (GridViewRow row in ApprovalArray)
            {
                RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                PrID = lbapprove.Text.ToString();
                HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                HtmlInputButton btnvari = (HtmlInputButton)row.FindControl("btnVarify");
                HtmlInputHidden hdnPM = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                hdnPM.Attributes.Add("ID", "hdnPmtMode" + PrID);
                hdnVar.Attributes.Add("ID", "hdntxtVarify" + PrID);
                btnvari.Attributes.Add("ID", "btnVarify" + PrID);
                //Commented by kalyani on 25-11-13 for hidding visibility of bank verify option start         
                //Rbapp.Attributes.Add("onClick", "javascript:CheckVarify('" + hdnVar.ClientID + "','" + btnvari.ClientID + "');");
                //Commented by kalyani on 25-11-13 for hidding visibility of bank verify option end         
                if (hdnPM.Value.ToString().Trim() == "DC")
                {
                    btnvari.Attributes.Add("onclick", "javascript: return funOpenPopWinForBankVariy('CndBankVarify.aspx','" + PrID + "','" + hdnVar.ClientID + "','" + btnvari.ClientID + "')");
                }
                else
                {
                    btnvari.Disabled = true;
                    hdnVar.Value = "Done";
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
    protected void dgFees_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            //BindGridControl(dgSource);
            ShowPageInformation();
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

    protected void dgFees_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "click")
        {

            string cndno = e.CommandArgument.ToString();
            //Changed by rachana on 27112013 to redirect and fill all data of candidate start
            //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E");
            Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit&Flag=App");
            //Changed by rachana on 27112013 to redirect and fill all data of candidate end
        }

    }

    protected void dgFees_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Added by Ibrahim on 29/05/2013 for larger text in grid as substring Start
        string str = ".....";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //Label lblbizsrc = (Label)e.Row.FindControl("lblbizsrc");
            Label lblNamePronoun = (Label)e.Row.FindControl("lblNamePronoun");
            Label lbSurname = (Label)e.Row.FindControl("lbSurname");
            //Label lblChnCls = (Label)e.Row.FindControl("lblChnCls");
            //Label lblAgentType = (Label)e.Row.FindControl("lblAgentType");
            Label lblCndStatus = (Label)e.Row.FindControl("lblCndStatus");

            LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
            lbCndNo.Enabled = false;
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" start
            if (lblNamePronoun.Text != null && lblNamePronoun.Text != "")
            {
                if (lblNamePronoun.Text.Length > 20)
                {
                    lblNamePronoun.Text = lblNamePronoun.Text.Substring(0, 18) + str;
                }
            }
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" End
            if (lbSurname.Text != null && lbSurname.Text != "")
            {
                if (lbSurname.Text.Length > 20)
                {
                    lbSurname.Text = lbSurname.Text.Substring(0, 18) + str;
                }
            }
            //lblChnCls.Text = lblChnCls.Text.Substring(0, 10) + str;
            //lblAgentType.Text = lblAgentType.Text.Substring(0, 10) + str;
            //lblCndStatus.Text = lblCndStatus.Text.Substring(0, 26) + str;
            if (lblCndStatus.Text != null && lblCndStatus.Text != "")
            {
                if (lblCndStatus.Text.Length > 30)
                {
                    lblCndStatus.Text = lblCndStatus.Text.Substring(0, 30) + str;
                }
            }
            //Added by Ibrahim on 29/05/2013 for larger text in grid as substring End 
        }
    }

    protected void dgFees_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            // BindGridControl(dgSource);
            ShowPageInformation();
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

    protected void rbrapprove_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
        RadioButton Rbapp = (RadioButton)grd.FindControl("rbrapprove");
        TextBox remarks = (TextBox)grd.FindControl("txtRemarks");
        //RadioButton Rbrej = (RadioButton)grd.FindControl("rbrreject");
        if (Rbapp.Checked == true)
        {
            remarks.Text = "Fees Wavier Approved";
            lbltitle.Text = "Fees Wavier Approval Search";
        }

    }

    protected void rbrreject_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
        RadioButton Rbrej = (RadioButton)grd.FindControl("rbrreject");
        TextBox remarks = (TextBox)grd.FindControl("txtRemarks");

        if (Rbrej.Checked == true)
        {
            remarks.Text = "Fees Wavier Rejected";
            lbltitle.Text = "Fees Wavier Approval Search";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CndEnq.aspx?Type=FeesApp");
    }
    protected void btnFeesSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            //Added by Nikhil on 08062015           
            //if (chkrcvd.Checked == false)
            //{
            //    ProgressBarModalPopupExtender.Hide();

            //    ////return;
            //}
            //else
            //{
            //Ended by Nikhil on 08062015

            int BranchCount = dgFees.Rows.Count;
            if (BranchCount > 0)
            {
                using (SqlConnection objCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CONN_Recruit].ToString()))
                {
                    SqlCommand objCom = new SqlCommand();
                    objCom.Connection = objCon;
                    objCom.CommandType = CommandType.StoredProcedure;

                    objCom.CommandText = "prc_UpdateCandidateapproval";
                    SqlTransaction tn;
                    objCon.Open();
                    //tn = objCon.BeginTransaction();
                    //objCom.Transaction = tn;


                    try
                    {
                        string App_Prospect = "";
                        string strAppRej_Flag = string.Empty;//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate App/Rej 
                        string strAppRej_FlagDesc = string.Empty;
                        string PrID = "0";
                        string sremarks;
                        Hashtable htable = new Hashtable();
                        GridViewRow[] ApprovalArray = new GridViewRow[dgFees.Rows.Count];
                        dgFees.Rows.CopyTo(ApprovalArray, 0);
                        foreach (GridViewRow row in ApprovalArray)
                        {
                            sremarks = "";
                            RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                            RadioButton Rbrej = (RadioButton)row.FindControl("rbrreject");
                            LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                            Label lblappno = (Label)row.FindControl("lblappno");
                            HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                            PrID = lbapprove.Text.ToString();
                            HtmlInputHidden hdnPmt = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                            hdnPmt.Attributes.Add("ID", "hdnPmtMode" + PrID);
                            GridViewRow gvRow = (GridViewRow)hdnPmt.NamingContainer;

                            //Added By Ibrahim on 8-05-2013 text find the control in gridview  linkbutton
                            LinkButton lkbtn = (LinkButton)gvRow.FindControl("lbCndNo");
                            //string str = gvRow.Cells[10].Text;
                            string str = "";
                            if (Rbapp.Checked == true && hdnVar.Value == "Done")
                            {
                                //App_Prospect = "40"; // Candidiate Approved
                                App_Prospect = "50";
                                strAppRej_Flag = "0";
                                strAppRej_FlagDesc = "BM Approval";
                                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                sremarks = remarks.Text.Trim();
                                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                //Added by Swapnesh on 15/5/2013 for trimming value of parameter start
                                htable.Add("@CndNo", PrID.Trim());
                                //Added by Swapnesh on 15/5/2013 for trimming value of parameter end
                                htable.Add("@CndStatus", App_Prospect);
                                htable.Add("@CndAppRej_Flag", strAppRej_Flag);//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate App
                                htable.Add("@Reason", strAppRej_FlagDesc);
                                htable.Add("@confirm", "Yes");//Addded by Nikhil on 08.06.2015
                                htable.Add("@Remarks", sremarks);
                                htable.Add("@Stage", "PA1");
                                htable.Add("@UpdateBy", Session["UserID"].ToString());
                                htable.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                                objCom.Parameters.Clear();
                                foreach (DictionaryEntry dist in htable)
                                {
                                    objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                }

                                int ret = objCom.ExecuteNonQuery();
                                Approve.Append(lbapprove.Text.Trim());
                                Approve.Append(",");
                                htable.Clear();
                                ViewState["App_Prospect"] = App_Prospect;
                                ViewState["AppNo"] = lblappno.Text;
                                //MailResponse(PrID);//mail communication

                            }
                            //else
                            //{
                            //    if (Rbapp.Checked == false && Rbrej.Checked == false && hdnVar.Value.Trim() == "NotDone")
                            //    {
                            //        alert.InnerHtml = "<script language =javascript> alert('Please approve atleast one candidate')</script>";
                            //    }
                            //    else if (str == "DC" && hdnVar.Value.Trim() == "NotDone")
                            //    {
                            //        alert.InnerHtml = "<script language =javascript> alert('Please verify bank details and then Proceed with Client and Agent Creation')</script>";
                            //    }
                            //}

                            if (Rbrej.Checked == true)
                            {
                                //App_Prospect = "20";// Candidiate Rejected
                                //strAppRej_Flag = "1";
                                App_Prospect = "40";// Candidiate Rejected
                                strAppRej_Flag = "0";
                                strAppRej_FlagDesc = "CH Rejection";

                                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                sremarks = remarks.Text.Trim();
                                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                htable.Add("@CndNo", PrID.Trim());
                                htable.Add("@CndStatus", App_Prospect);
                                htable.Add("@CndAppRej_Flag", strAppRej_Flag);//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate Rej
                                htable.Add("@Reason", strAppRej_FlagDesc);
                                htable.Add("@confirm", "Yes");//Addded by Nikhil on 08.06.2015
                                htable.Add("@Remarks", sremarks);
                                htable.Add("@Stage", "PA1");
                                htable.Add("@UpdateBy", Session["UserID"].ToString());
                                htable.Add("@FlagAuto", "Y");
                                htable.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                                objCom.Parameters.Clear();
                                foreach (DictionaryEntry dist in htable)
                                {
                                    objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                }

                                int ret = objCom.ExecuteNonQuery();
                                Reject.Append(lbapprove.Text.Trim());
                                Reject.Append(",");
                                htable.Clear();
                                ViewState["App_Prospect"] = App_Prospect;
                                ViewState["AppNo"] = lblappno.Text;
                                //MailResponse(PrID);

                            }

                        }

                        //Added by Kalyani on 25-11-2013 for Candidate approved/rejected messagebox start 
                        ApprovedCnd = Approve.ToString();
                        if (ApprovedCnd != "")
                        {
                            ApprovedCnd = ApprovedCnd.Substring(0, ApprovedCnd.Length - 1);
                            //added by shreela on 09/06/2014 start
                            String[] strArr = ApprovedCnd.Split(',');
                            int count = 0;
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                count++;
                            }
                            ApprovedCnd = Convert.ToString(count);
                            //added by shreela on 09/06/2014 end
                        }
                        else
                        {
                            //ApprovedCnd = "-";
                            ApprovedCnd = "0";
                        }
                        RejectdCnd = Reject.ToString();
                        if (RejectdCnd != "")
                        {
                            RejectdCnd = RejectdCnd.Substring(0, RejectdCnd.Length - 1);
                            //added by shreela on 09/06/2014 start
                            String[] strArr = RejectdCnd.Split(',');
                            int count = 0;
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                count++;
                            }
                            RejectdCnd = Convert.ToString(count);
                            //added by shreela on 09/06/2014 end
                        }
                        else
                        {
                            //RejectdCnd = "-";
                            RejectdCnd = "0";
                        }
                        //lblmsg.Text = "Candidate Approved/Rejected Successfully";
                        //lblmsg.ForeColor = Color.Red;
                        //lblmsg.Visible = false;
                        //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                        //alert.InnerHtml = "";
                        //MailResponse(PrID);

                        //lbl3.Visible = true;
                        lbl3.Text = "Candidate Approved/Rejected Successfully";
                        lbl2.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                        lbl4.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();//added by shreela on 09/06/2014 

                        //pnl.Visible = true;
                        mdlpopupFees.Show();

                        //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format End 
                        //txtAppNo.Text = "";////Commented by kalyani on 24-12-2013 as not required 
                        txtSurname.Text = "";
                        txtCandCode.Text = "";
                        txtDTRegFrom.Text = "";
                        txtDTRegTo.Text = "";
                        txtGivenName.Text = "";
                        ProgressBarModalPopupExtender.Hide();//to hide progressbar after submit
                        lbltitle.Text = "Fees Wavier Approval Search";


                        //Added by Kalyani on 25-11-2013 for Candidate approved/rejected messagebox end 
                        //tn.Commit();
                        BindFeesGrid();
                    }
                    catch (Exception ex)
                    {
                        //tn.Rollback();
                        //lblmsg.Visible = true;
                        //lblmsg.Text = ex.Message;
                    }
                }
            }
            // }
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
    //added by amruta on 20.7.15 end

    #region Bind Data to GridView
    //commented by ajay start
    //protected void BindDataGrid()
    //{
    //    try
    //    {
    //    //    dgDetails.PageIndex = 0;//Added by pranjali on 05-03-2014 for setting first page on click of search
    //    //    GridCndStatus.PageIndex = 0;
    //    //    //Added by rachana on 06052014 for identification of showrecords ddl start
    //    //    if (trshowrecords.Visible == true)
    //    //    {
    //    //        dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
    //    //        GridCndStatus.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
    //    //    }
    //    //    else
    //    //    {

    //    //        GridCndStatus.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
    //    //    }
    //        //Added by rachana on 06052014 for identification of showrecords ddl end

    //        Hashtable htParam = new Hashtable();
    //        htParam.Clear();

    //        htParam.Add("@EmpCode", txtFrenchCode.Text.Trim());
    //        //htParam.Add("@SAPCODE", txtFrenchSap.Text.Trim());

    //        if (txtDTRegFrom.Text.Trim() != "")
    //        {
    //            htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
    //        }
    //        else
    //        {
    //            htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
    //        }
    //        if (txtDTRegTo.Text.Trim() != "")
    //        {
    //            htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
    //        }
    //        else
    //        {
    //            htParam.Add("@CreateToDtim ", System.DBNull.Value);
    //        }

    //       // htParam.Add("@LegalName", txtSurname.Text.Trim());



    //        if (Request.QueryString["Type"].Trim() == "CndStat")
    //                {

    //                if (ViewState["UserType"].ToString() == "I")
    //                {
    //                    dsResult.Clear();
    //                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetAllStatusCnd", htParam);
    //                }
    //                else if (ViewState["UserType"].ToString() == "E")
    //                {
    //                    dsResult.Clear();

    //                    //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetAllStatusCndForExtrnl", htParam);
    //                    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetAllStatusMemForExtrnl", htParam);
    //                }
    //                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetAllStatusCnd", htParam);
    //                //GridCndStatus.Columns[3].Visible = false;
    //                //GridCndStatus.Columns[9].Visible = true;
    //                //GridCndStatus.Columns[10].Visible = true;
    //                //GridCndStatus.Columns[11].Visible = true;
    //                //GridCndStatus.Columns[12].Visible = true;
    //                //GridCndStatus.Columns[13].Visible = true;
    //                //GridCndStatus.Columns[14].Visible = true;
    //                //GridCndStatus.Columns[15].Visible = true;
    //                //GridCndStatus.Columns[16].Visible = false;
    //                //GridCndStatus.Columns[17].Visible = false;
    //                //GridCndStatus.Columns[19].Visible = true;
    //                //GridCndStatus.Columns[18].Visible = true;
    //            //    lbltitle.Text = "All Candidate Enquiry"; //added by pranjali on 24-03-2014
    //            //}

    //            //added by pranjali on 23-04-2014 for license renewal start

    //            //DataSet dsCfruser = new DataSet();
    //            //dsCfruser.Clear();
    //            //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
    //            //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
    //            //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
    //            //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
    //            //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
    //            //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
    //            //if (UserType == "I")
    //            //{
    //            //htParam.Add("@MemberCode", MemberCode);
    //            //htParam.Add("@MemberType", MemberType);
    //            //dsResult.Clear();
    //            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwl", htParam);
    //            //dgDetails.Columns[9].Visible = false;
    //            //dgDetails.Columns[10].Visible = false;
    //            //dgDetails.Columns[11].Visible = false;//added by rachana on 06/03/2013
    //            //dgDetails.Columns[12].Visible = false;
    //            //dgDetails.Columns[13].Visible = false;
    //            //dgDetails.Columns[14].Visible = true;
    //            //lbltitle.Text = "License Renewal";
    //            //}
    //            //else if (UserType == "E")
    //            //{
    //            //dsResult.Clear();
    //            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwlForExtrnl", htParam);
    //            //dgDetails.Columns[9].Visible = false;
    //            //dgDetails.Columns[10].Visible = false;
    //            //dgDetails.Columns[11].Visible = false;//added by rachana on 06/03/2013
    //            //dgDetails.Columns[12].Visible = false;
    //            //dgDetails.Columns[13].Visible = false;
    //            //dgDetails.Columns[14].Visible = false;
    //            //dgDetails.Columns[15].Visible = true;
    //            //lbltitle.Text = "License Renewal";
    //            //}

    //            //}
    //            //added by pranjali on 23-04-2014 for license renewal end
    //            //added by pranjali on 17-04-2014 start

    //            //added by pranjali on 17-04-2014 end
    //            //pranjali

    //            //Added by usaha from agent Profile on 24.07.2017

    //            //Added by usaha from agent Profile on 24.07.2017

    //        }

    //   // }
    //        //added by pranjali on 19-02-2014 for preffered exam detail search end
    //        #region FOR CANDIDATE STATUS VIEW MODULE
    //        if (Request.QueryString["Type"] != null)
    //        {
    //            if (Request.QueryString["Type"].Trim() == "CndStat")
    //            {
    //                #region BINDING GRID
    //                if (dsResult.Tables.Count > 0)
    //                {
    //                    if (dsResult.Tables[0].Rows.Count > 0)
    //                    {
    //                        trGridCndStatus.Visible = true;
    //                        GridCndStatus.Visible = true;
    //                        GridCndStatus.DataSource = dsResult.Tables[0];
    //                        GridCndStatus.DataBind();
    //                        ShowPageInformationCndStatus();
    //                        //trGridCndStatus.Visible = true;
    //                        //GridCndStatus.Visible = true;
    //                        trButton.Visible = true;
    //                        btnAddnew.Enabled = true;
    //                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                        lblMessage.Visible = false;
    //                        lblMessage.Text = "";
    //                        Session["dtResult"] = dsResult.Tables[0];
    //                        //trnote.Visible =true;
    //                        trLbl.Visible = true;
    //                    }
    //                    else
    //                    {
    //                        GridCndStatus.DataSource = null;
    //                        GridCndStatus.DataBind();
    //                        lblPageInfo.Text = "";
    //                        trLbl.Visible = true;
    //                        trDetails.Visible = false;
    //                        trGridCndStatus.Visible = false;
    //                        trButton.Visible = false;
    //                        lblMessage.Visible = true;
    //                        tr6.Visible = false;
    //                        lblMessage.Text = "0 Record Found";
    //                        string errormsg = lblMessage.Text;
    //                        trButton.Visible = true;
    //                        btnAddnew.Enabled = true;
    //                        //trnote.Visible = false;
    //                        tr2.Attributes.Add("style", "display:none");
    //                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                    }
    //                }

    //                else
    //                {
    //                    GridCndStatus.DataSource = null;
    //                    GridCndStatus.DataBind();
    //                    lblPageInfo.Text = "";
    //                    trDetails.Visible = false;
    //                    trGridCndStatus.Visible = false;
    //                    trButton.Visible = false;
    //                    lblMessage.Visible = true;
    //                    lblMessage.Text = "0 Record Found";
    //                    tr6.Visible = false;
    //                    trButton.Visible = true;
    //                    btnAddnew.Enabled = true;
    //                    //trnote.Visible = false;
    //                    trLbl.Visible = true;
    //                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                }
    //                dsResult = null;
    //                Session["dtResult"] = null;
    //                #endregion
    //            }
    //            else
    //            {
    //                #region BINDING GRID
    //                if (dsResult.Tables.Count > 0)
    //                {
    //                    if (dsResult.Tables[0].Rows.Count > 0)
    //                    {

    //                        dgDetails.DataSource = dsResult.Tables[0];
    //                        dgDetails.DataBind();
    //                        ShowPageInformation();
    //                        trDgDetails.Visible = true;
    //                        trButton.Visible = true;
    //                        btnAddnew.Enabled = true;
    //                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                        lblMessage.Visible = false;
    //                        lblMessage.Text = "";
    //                        Session["dtResult"] = dsResult.Tables[0];
    //                        //trnote.Visible =true;
    //                        tr6.Visible = false;
    //                    }
    //                    else
    //                    {
    //                        dgDetails.DataSource = null;
    //                        dgDetails.DataBind();
    //                        lblPageInfo.Text = "";
    //                        trDetails.Visible = false;
    //                        trDgDetails.Visible = false;
    //                        trButton.Visible = false;
    //                        lblMessage.Visible = true;
    //                        tr6.Visible = false;
    //                        lblMessage.Text = "0 Record Found";
    //                        string errormsg = lblMessage.Text;
    //                        trButton.Visible = true;
    //                        btnAddnew.Enabled = true;
    //                        //trnote.Visible = false;
    //                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                    }
    //                }

    //                else
    //                {
    //                    dgDetails.DataSource = null;
    //                    dgDetails.DataBind();
    //                    lblPageInfo.Text = "";
    //                    trDetails.Visible = false;
    //                    trDgDetails.Visible = false;
    //                    trButton.Visible = false;
    //                    lblMessage.Visible = true;
    //                    lblMessage.Text = "0 Record Found";
    //                    tr6.Visible = false;
    //                    trButton.Visible = true;
    //                    btnAddnew.Enabled = true;
    //                    //trnote.Visible = false;
    //                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                }
    //                dsResult = null;
    //                Session["dtResult"] = null;
    //                #endregion

    //            }
    //        }
    //        #endregion
    //        else
    //        {
    //            #region BINDING GRID
    //            if (dsResult.Tables.Count > 0)
    //            {
    //                if (dsResult.Tables[0].Rows.Count > 0)
    //                {

    //                    dgDetails.DataSource = dsResult.Tables[0];
    //                    dgDetails.DataBind();
    //                    ShowPageInformation();
    //                    trDgDetails.Visible = true;
    //                    trButton.Visible = true;
    //                    btnAddnew.Enabled = true;
    //                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                    lblMessage.Visible = false;
    //                    lblMessage.Text = "";
    //                    Session["dtResult"] = dsResult.Tables[0];
    //                    //trnote.Visible =true;
    //                }
    //                else
    //                {
    //                    dgDetails.DataSource = null;
    //                    dgDetails.DataBind();
    //                    lblPageInfo.Text = "";
    //                    trDetails.Visible = false;
    //                    trDgDetails.Visible = false;
    //                    trButton.Visible = false;
    //                    lblMessage.Visible = true;
    //                    tr6.Visible = false;
    //                    lblMessage.Text = "0 Record Found";
    //                    string errormsg = lblMessage.Text;
    //                    trButton.Visible = true;
    //                    btnAddnew.Enabled = true;
    //                    trnote.Visible = false;
    //                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //                }
    //            }

    //            else
    //            {
    //                dgDetails.DataSource = null;
    //                dgDetails.DataBind();
    //                lblPageInfo.Text = "";
    //                trDetails.Visible = false;
    //                trDgDetails.Visible = false;
    //                trButton.Visible = false;
    //                lblMessage.Visible = true;
    //                lblMessage.Text = "0 Record Found";
    //                tr6.Visible = false;
    //                trButton.Visible = true;
    //                btnAddnew.Enabled = true;
    //                trnote.Visible = false;
    //                //btnAddnew.CssClass = "btn btn-xs btn-primary";
    //            }
    //            dsResult = null;
    //            Session["dtResult"] = null;
    //            #endregion

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

    //    }
    //}
    //commented by ajay End
    //Added by pranjali on 18-10-2014 for license upload download start

    //new GridBind added by ajay start
    protected void BindDataGrid()
    {
        try
        {
            //dgDetails.PageIndex = 0;//Added by pranjali on 05-03-2014 for setting first page on click of search
            //GridCndStatus.PageIndex = 0;
            //Added by rachana on 06052014 for identification of showrecords ddl start
          
            if (trshowrecords.Visible == true)
            {
                dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
                GridCndStatus.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
            }
            else
            {
                //dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue.Trim());
                GridCndStatus.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
            }
            //Added by rachana on 06052014 for identification of showrecords ddl end

            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@EmpCode", txtFrenchCode.Text.Trim());
            //<% --added by ajay start 1 - 21 - 2021-- %>
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@BranchName", txtBranchName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());
            htParam.Add("@FPMemCode", txtMemberCode.Text.Trim());
            //<% --added by ajay End 1 - 21 - 2021-- %>
            //htParam.Add("@SAPCODE", txtFrenchSap.Text.Trim());

            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString(("yyyyMMdd")));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString(("yyyyMMdd")));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            // htParam.Add("@LegalName", txtSurname.Text.Trim());

            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            ////Added by kalyani on 3-1-2014 to insert appno start
            ////to insert appno for candidate registration search
            //if (Request.QueryString["ACT"] != null)
            //{
            //    if (Request.QueryString["ACT"].ToUpper().Trim() == "PR")
            //    {
            //        htParam.Add("@AppNo", txtAppNo.Text.Trim());
            //    }
            //}
            ////to insert appno for candidate enquiry search
            //else
            //{
            //    htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
            //}
            ////Added by kalyni on 3-1-2014 to insert appno end
            //htParam.Add("@CndNo", txtCandCode.Text.Trim());
            //htParam.Add("@GivenName", txtGivenName.Text.Trim());
            //htParam.Add("@Surname", txtSurname.Text.Trim());
            ///*htParam.Add("@PAN", txtPan.Text.Trim());*///added by shreela on 10042014

            //if (txtDTRegFrom.Text.Trim() != "")
            //{
            //    htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            //}
            //if (txtDTRegTo.Text.Trim() != "")
            //{
            //    htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    htParam.Add("@CreateToDtim ", System.DBNull.Value);
            //}

            //htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());

            //htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());

            //htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            //htParam.Add("@Page", "CndEnq");

            //For Internal UserType
            if (ViewState["UserType"].ToString() == "I")
            {
                htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                htParam.Add("@MemberType", ViewState["MemberType"].ToString());
               
                if (ddlmemtype.SelectedItem.Text != "Select")
                {
                    htParam.Add("@VendorType", ddlmemtype.SelectedItem.Text);
                }
                else
                {
                    htParam.Add("@VendorType", System.DBNull.Value);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select member type')", true);//added by sanoj20062023
                    return;
                }
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemberForEnquiry", htParam);
            }
            //For External UserType
            else if (ViewState["UserType"].ToString() == "E")
            {
                dsResult.Clear();
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemForEnquiryForExtrnl", htParam);
            }

            //changed by rachana to show Candidate Modification end
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"].ToUpper().Trim() == "IV" || Request.QueryString["ACT"].ToUpper().Trim() == "PR")
                {
                    if (ViewState["UserType"].ToString() == "I")
                    {
                        //htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                        //htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                        dsResult.Clear();
                        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForProfileandProspect", htParam);
                    }
                    else if (ViewState["UserType"].ToString() == "E")
                    {
                        dsResult.Clear();
                        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForProfileandProspect_External", htParam);
                    }
                    dgDetails.Columns[0].Visible = false;
                    trDetails.Visible = false;
                    tr6.Visible = true;
                    dgDetails.Columns[9].Visible = false; //Memcode//added by pranjali on 27022014 for hiding create agent link
                    dgDetails.Columns[10].Visible = false;//Urn
                    dgDetails.Columns[11].Visible = false;//SAPcode
                    dgDetails.Columns[12].Visible = false;//Agent Broker code
                    dgDetails.Columns[13].Visible = false;//Create Agent
                    dgDetails.Columns[14].Visible = false;
                    dgDetails.Columns[15].Visible = false;
                    dgDetails.Columns[16].Visible = false;
                    dgDetails.Columns[17].Visible = false;
                }
            }
            else
            {
                dgDetails.Columns[1].Visible = true;
                tr6.Visible = false;
                dgDetails.Columns[9].Visible = true;//Memcode
                //dgDetails.Columns[10].Visible = false;//Urn
                //dgDetails.Columns[11].Visible = false;//SAPCODE
                //dgDetails.Columns[12].Visible = false;//Agent broker code
                //dgDetails.Columns[13].Visible = false;//Create Agent
                //dgDetails.Columns[14].Visible = false;
                //dgDetails.Columns[15].Visible = false;
                //dgDetails.Columns[16].Visible = false;
                //dgDetails.Columns[17].Visible = false;
                //dgDetails.Columns[18].Visible = false;
                //dgDetails.Columns[25].Visible = false;
                //lbltitle.Text = "Candidate Modification";
                //Label1.Text = "Candidate Modification Search Results";
            }
            /////added by akshay on 31/01/14
            if (Request.QueryString["ACT"] == null)
            {
                if (Request.QueryString["type"] != null)
                {
                    if (Request.QueryString["type"].Trim() == "LIC")
                    {
                        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForLicense", htParam);
                        dgDetails.Columns[9].Visible = false;
                        dgDetails.Columns[10].Visible = false;
                        //dgDetails.Columns[11].Visible = false;
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[13].Visible = false;
                        dgDetails.Columns[14].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[16].Visible = true;
                        dgDetails.Columns[17].Visible = true;
                        tr6.Visible = true;
                        lbltitle.Text = "License Upload"; //Added by kalyani on 21/04/2014
                    }

                    //pranjali
                    else if (Request.QueryString["type"].Trim() == "PREFFEXM")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForPreffExmDtls", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForPreffExmDtlsForExtrnl", htParam);
                        }
                        trApplication.Visible = false;//added by pranjali on 12/03/2014
                        dgDetails.Columns[9].Visible = false;
                        dgDetails.Columns[10].Visible = false;
                        dgDetails.Columns[11].Visible = false;
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[16].Visible = false;
                        dgDetails.Columns[17].Visible = false;
                        dgDetails.Columns[18].Visible = false;
                        dgDetails.Columns[19].Visible = false;
                        dgDetails.Columns[20].Visible = false;
                        dgDetails.Columns[22].Visible = true;
                        dgDetails.Columns[23].Visible = true;
                        tr6.Visible = true;
                        lbltitle.Text = "Preffered Exam Details"; //Added by kalyani on 21/04/2014
                    }
                    else if (Request.QueryString["type"].Trim() == "CandConv")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForCandConv", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForCandConvForExtrnl", htParam);
                        }
                        dgDetails.Columns[10].Visible = false;
                        dgDetails.Columns[11].Visible = false;
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[13].Visible = false;
                        dgDetails.Columns[14].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[16].Visible = true;
                        dgDetails.Columns[17].Visible = false;
                    }
                    else if (Request.QueryString["Type"].Trim() == "CndAllStat" || Request.QueryString["Type"].Trim() == "viewDoc")
                    {
                        dsResult.Clear();
                        htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                        htParam.Add("@AgentSapCode", txtSapCode.Text);
                        //if (ddlStatus.SelectedItem.Text == "--Select--")
                        //{
                        //    htParam.Add("@Status", System.DBNull.Value);

                        //}
                        //else
                        //{
                        //    htParam.Add("@Status", ddlStatus.SelectedValue);
                        //}
                        //htParam.Add("@URN", txtURN.Text);
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetAllStatusCnd", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {

                            if (Request.QueryString["Type"].Trim() == "viewDoc")//Added For View Doc Pawar Bhaurao
                            {
                                
                                DocGridBind();
                                return;
                            }
                            else
                            {
                                dsResult.Clear();
                                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetAllStatusCndForExtrnl", htParam);
                            }
                        }
                        string codetype = Request.QueryString["Type"].Trim();
                        if (codetype == "viewDoc")
                        //prc_GetCandidateinfoforViewDoc
                        {
                            //divcntstcollapse.Visible = true;
                            dgDetails.Columns[4].Visible = false;
                            dgDetails.Columns[9].Visible = false;
                            dgDetails.Columns[10].Visible = false;
                            /* comented by sanoj 23052022
                            //dgDetails.Columns[11].Visible = true;
                            //dgDetails.Columns[12].Visible = true;
                            //dgDetails.Columns[13].Visible = true;
                            //dgDetails.Columns[14].Visible = false;
                            //dgDetails.Columns[15].Visible = true;
                            //dgDetails.Columns[16].Visible = false;
                            //dgDetails.Columns[17].Visible = false;
                            //dgDetails.Columns[18].Visible = true;
                            //dgDetails.Columns[19].Visible = true;
                            //dgDetails.Columns[20].Visible = false;
                            */
                            //div4.Visible = false;
                            //divcmphdrcollapse.Visible = true;
                            //divcntstcollapse.Visible = true;
                            //divGvRprt.Visible = false;
                            //divprospectsearch.Visible = false;

                            lbltitle.Text = "View Document Search";
                            Label1.Text = " Candidate Document Search Results";



                            // ShowPageInformation();

                        }
                        else
                        {

                            dgDetails.Columns[3].Visible = false;
                            dgDetails.Columns[9].Visible = true;
                            dgDetails.Columns[10].Visible = true;
                            dgDetails.Columns[11].Visible = true;
                            dgDetails.Columns[12].Visible = true;
                            dgDetails.Columns[13].Visible = true;
                            dgDetails.Columns[14].Visible = false;
                            dgDetails.Columns[15].Visible = true;
                            dgDetails.Columns[16].Visible = false;
                            dgDetails.Columns[17].Visible = false;
                            dgDetails.Columns[18].Visible = true;
                            lbltitle.Text = "All Member Enquiry";
                            //added by bhaurao on 24-03-2014
                        }
                    }
                    else if (Request.QueryString["Type"].Trim() == "CndStat")
                    {

                        dsResult.Clear();
                        //htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                        htParam.Add("@AgentSapCode", txtSapCode.Text);
                        //if (ddlStatus.SelectedItem.Text == "--Select--")
                        //{
                        //    htParam.Add("@Status", System.DBNull.Value);

                        //}
                        //else
                        //{
                        //    htParam.Add("@Status", ddlStatus.SelectedValue);
                        //}
                        //htParam.Add("@URN", txtURN.Text);
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetAllStatusMem", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetAllStatusMemForExtrnl", htParam);
                        }
                        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetAllStatusCnd", htParam);
                        //GridCndStatus.Columns[3].Visible = false;
                        //GridCndStatus.Columns[9].Visible = true;
                        //GridCndStatus.Columns[10].Visible = true;
                        //GridCndStatus.Columns[11].Visible = true;
                        //GridCndStatus.Columns[12].Visible = true;
                        //GridCndStatus.Columns[13].Visible = true;
                        //GridCndStatus.Columns[14].Visible = true;
                        //GridCndStatus.Columns[15].Visible = true;
                        //GridCndStatus.Columns[16].Visible = false;
                        //GridCndStatus.Columns[17].Visible = false;
                        //GridCndStatus.Columns[19].Visible = true;
                        //GridCndStatus.Columns[18].Visible = true;
                        lbltitle.Text = "All Member Enquiry"; //added by pranjali on 24-03-2014
                    }
                    else if (Request.QueryString["type"].Trim() == "CndRev")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForCandRev", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForCandRevForExtrnl", htParam);
                        }
                        //dsResult.Clear();
                        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForCandRev", htParam);
                        dgDetails.Columns[9].Visible = false;
                        dgDetails.Columns[10].Visible = false;
                        dgDetails.Columns[11].Visible = false;//added by rachana on 06/03/2013
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[13].Visible = false;
                        dgDetails.Columns[14].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[17].Visible = true;
                        lbltitle.Text = "Candidate Revival"; //added by pranjali on 24-03-2014
                    }
                    //added by pranjali on 23-04-2014 for license renewal start
                    else if (Request.QueryString["type"].Trim() == "LicRnwl")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                            htParam.Add("@LcnNo", txtSapCode.Text);
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwl", htParam);
                            dgDetails.Columns[0].Visible = false;
                            dgDetails.Columns[3].Visible = false;
                            dgDetails.Columns[9].Visible = true;
                            dgDetails.Columns[10].Visible = true;
                            dgDetails.Columns[11].Visible = true;
                            dgDetails.Columns[12].Visible = true;
                            dgDetails.Columns[13].Visible = true;//added by rachana on 06/03/2013
                            dgDetails.Columns[14].Visible = true;
                            dgDetails.Columns[15].Visible = false;
                            dgDetails.Columns[16].Visible = false;
                            dgDetails.Columns[17].Visible = false;
                            dgDetails.Columns[18].Visible = false;
                            dgDetails.Columns[20].Visible = true;
                            lbltitle.Text = "Retrieval";
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                            htParam.Add("@LcnNo", txtSapCode.Text);
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwlForExtrnl", htParam);
                            dgDetails.Columns[3].Visible = false;
                            dgDetails.Columns[9].Visible = true;
                            dgDetails.Columns[10].Visible = true;
                            dgDetails.Columns[11].Visible = true;
                            dgDetails.Columns[12].Visible = false;
                            dgDetails.Columns[13].Visible = false;//added by rachana on 06/03/2013
                            dgDetails.Columns[14].Visible = true;
                            dgDetails.Columns[15].Visible = false;
                            dgDetails.Columns[16].Visible = false;
                            dgDetails.Columns[17].Visible = false;
                            dgDetails.Columns[18].Visible = false;
                            dgDetails.Columns[20].Visible = true;
                            lbltitle.Text = "Retrieval";
                        }
                    }
                    //DataSet dsCfruser = new DataSet();
                    //dsCfruser.Clear();
                    //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
                    //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
                    //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
                    //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
                    //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
                    //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
                    //if (UserType == "I")
                    //{
                    //htParam.Add("@MemberCode", MemberCode);
                    //htParam.Add("@MemberType", MemberType);
                    //dsResult.Clear();
                    //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwl", htParam);
                    //dgDetails.Columns[9].Visible = false;
                    //dgDetails.Columns[10].Visible = false;
                    //dgDetails.Columns[11].Visible = false;//added by rachana on 06/03/2013
                    //dgDetails.Columns[12].Visible = false;
                    //dgDetails.Columns[13].Visible = false;
                    //dgDetails.Columns[14].Visible = true;
                    //lbltitle.Text = "License Renewal";
                    //}
                    //else if (UserType == "E")
                    //{
                    //dsResult.Clear();
                    //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwlForExtrnl", htParam);
                    //dgDetails.Columns[9].Visible = false;
                    //dgDetails.Columns[10].Visible = false;
                    //dgDetails.Columns[11].Visible = false;//added by rachana on 06/03/2013
                    //dgDetails.Columns[12].Visible = false;
                    //dgDetails.Columns[13].Visible = false;
                    //dgDetails.Columns[14].Visible = false;
                    //dgDetails.Columns[15].Visible = true;
                    //lbltitle.Text = "License Renewal";
                    //}

                    //}
                    //added by pranjali on 23-04-2014 for license renewal end
                    //added by pranjali on 17-04-2014 start
                    else if (Request.QueryString["Type"].Trim() == "SMAlloct")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndForSMAllocate", htParam);
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndForSMAllocateForExtrnl", htParam);
                        }
                        //dsResult.Clear();
                        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndForSMAllocate", htParam);
                        dgDetails.Columns[9].Visible = false;
                        dgDetails.Columns[10].Visible = false;
                        dgDetails.Columns[11].Visible = false;
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[13].Visible = false;
                        dgDetails.Columns[14].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[16].Visible = false;
                        dgDetails.Columns[17].Visible = false;
                        dgDetails.Columns[18].Visible = false;
                        dgDetails.Columns[19].Visible = false;
                        dgDetails.Columns[21].Visible = true;
                        dgDetails.Columns[24].Visible = true;
                        lbltitle.Text = "SM Allocation";
                    }
                    //added by pranjali on 17-04-2014 end
                    //pranjali

                    //Added by usaha from agent Profile on 24.07.2017
                    if (Request.QueryString["Type"].Trim() == "AgentProfile")
                    {

                        dsResult.Clear();

                        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAgentProfileSearch", htParam);


                        dgDetails.Columns[9].Visible = false;
                        dgDetails.Columns[10].Visible = false;
                        dgDetails.Columns[11].Visible = false;
                        dgDetails.Columns[12].Visible = false;
                        dgDetails.Columns[13].Visible = false;
                        dgDetails.Columns[14].Visible = false;
                        dgDetails.Columns[15].Visible = false;
                        dgDetails.Columns[16].Visible = false;
                        dgDetails.Columns[17].Visible = false;
                        dgDetails.Columns[18].Visible = false;
                        dgDetails.Columns[19].Visible = false;
                        dgDetails.Columns[20].Visible = false;
                        dgDetails.Columns[21].Visible = false;
                        dgDetails.Columns[22].Visible = false;
                        dgDetails.Columns[23].Visible = false;
                        dgDetails.Columns[24].Visible = false;
                        dgDetails.Columns[25].Visible = true;
                        lbltitle.Text = "Agent Profile ";
                    }
                    //Added by usaha from agent Profile on 24.07.2017
                }
            }

            //added by pranjali on 19-02-2014 for preffered exam detail search end
            #region FOR CANDIDATE STATUS VIEW MODULE
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].Trim() == "CndStat")
                {
                    #region BINDING GRID
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            trGridCndStatus.Visible = true;
                            GridCndStatus.Visible = true;
                            trGridCndStatusPage.Visible = true;//Added  by usha  on 25_04_2023
                            GridCndStatus.DataSource = dsResult.Tables[0];
                            GridCndStatus.DataBind();
                            //Added  by usha  on 25_04_2023
                            ViewState["grid"] = dsResult.Tables[0];
                            if (GridCndStatus.PageCount > Convert.ToInt32(txtStatus.Text))
                            {
                                btnNextStatus.Enabled = true;
                            }
                            else
                            {
                                btnNextStatus.Enabled = false;
                            }
                            //ended   by usha  on 25_04_2023
                           // ShowPageInformationCndStatus();
                            //trGridCndStatus.Visible = true;
                            //GridCndStatus.Visible = true;
                            trButton.Visible = true;
                            btnAddnew.Enabled = true;
                            //btnAddnew.CssClass = "btn btn-xs btn-primary";
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                            Session["dtResult"] = dsResult.Tables[0];
                            //trnote.Visible =true;
                            trLbl.Visible = true;
                        }
                        else
                        {
                            GridCndStatus.DataSource = null;
                            GridCndStatus.DataBind();
                            lblPageInfo.Text = "";
                            trLbl.Visible = true;
                            trDetails.Visible = false;
                            trGridCndStatus.Visible = false;
                            trButton.Visible = false;
                            lblMessage.Visible = true;
                            tr6.Visible = false;
                            lblMessage.Text = "0 Record Found";
                            string errormsg = lblMessage.Text;
                            trButton.Visible = true;
                            btnAddnew.Enabled = true;
                            //trnote.Visible = false;
                            tr2.Attributes.Add("style", "display:none");
                            //btnAddnew.CssClass = "btn btn-xs btn-primary";
                        }
                    }

                    else
                    {
                        GridCndStatus.DataSource = null;
                        GridCndStatus.DataBind();
                        lblPageInfo.Text = "";
                        trDetails.Visible = false;
                        trGridCndStatus.Visible = false;
                        trButton.Visible = false;
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";
                        tr6.Visible = false;
                        trButton.Visible = true;
                        btnAddnew.Enabled = true;
                        //trnote.Visible = false;
                        trLbl.Visible = true;
                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
                    }
                    dsResult = null;
                    Session["dtResult"] = null;
                    #endregion
                }
                else
                {
                    #region BINDING GRID
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {

                            dgDetails.DataSource = dsResult.Tables[0];
                            dgDetails.DataBind();
                            ShowPageInformation();
                            trDgDetails.Visible = true;
                            trButton.Visible = true;
                            btnAddnew.Enabled = true;
                            //btnAddnew.CssClass = "btn btn-xs btn-primary";
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                            Session["dtResult"] = dsResult.Tables[0];
                            //trnote.Visible =true;
                            tr6.Visible = false;
                        }
                        else
                        {
                            dgDetails.DataSource = null;
                            dgDetails.DataBind();
                            lblPageInfo.Text = "";
                            trDetails.Visible = false;
                            trDgDetails.Visible = false;
                            trButton.Visible = false;
                            lblMessage.Visible = true;
                            tr6.Visible = false;
                            lblMessage.Text = "0 Record Found";
                            string errormsg = lblMessage.Text;
                            trButton.Visible = true;
                            btnAddnew.Enabled = true;
                            //trnote.Visible = false;
                            //btnAddnew.CssClass = "btn btn-xs btn-primary";
                        }
                    }

                    else
                    {
                        dgDetails.DataSource = null;
                        dgDetails.DataBind();
                        lblPageInfo.Text = "";
                        trDetails.Visible = false;
                        trDgDetails.Visible = false;
                        trButton.Visible = false;
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";
                        tr6.Visible = false;
                        trButton.Visible = true;
                        btnAddnew.Enabled = true;
                        //trnote.Visible = false;
                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
                    }
                    dsResult = null;
                    Session["dtResult"] = null;
                    #endregion

                }
            }
            #endregion
            else
            {
                #region BINDING GRID
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {

                        dgDetails.DataSource = dsResult.Tables[0];
                        dgDetails.DataBind();
                        ShowPageInformation();
                        trDgDetails.Visible = true;
                        trButton.Visible = true;
                        btnAddnew.Enabled = true;
                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
                        lblMessage.Visible = false;
                        lblMessage.Text = "";
                        Session["dtResult"] = dsResult.Tables[0];
                        //trnote.Visible =true;
                    }
                    else
                    {
                        dgDetails.DataSource = null;
                        dgDetails.DataBind();
                        lblPageInfo.Text = "";
                        trDetails.Visible = false;
                        trDgDetails.Visible = false;
                        trButton.Visible = false;
                        lblMessage.Visible = true;
                        tr6.Visible = false;
                        lblMessage.Text = "0 Record Found";
                        string errormsg = lblMessage.Text;
                        trButton.Visible = true;
                        btnAddnew.Enabled = true;
                        //trnote.Visible = false;
                        //btnAddnew.CssClass = "btn btn-xs btn-primary";
                    }
                }

                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    trButton.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    tr6.Visible = false;
                    trButton.Visible = true;
                    btnAddnew.Enabled = true;
                    //trnote.Visible = false;
                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
                }
                dsResult = null;
                Session["dtResult"] = null;
                #endregion

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

    //new GridBind added by ajay End

    protected void LicenseUpldDwnld()
    {
        try
        {
            dgRenTrn.PageIndex = 0;
        
            Hashtable htLic = new Hashtable();
            DataSet DsAgtLic = new DataSet();
            htLic.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htLic.Add("@CndNo", txtCandCode.Text.ToString().Trim());
            htLic.Add("@AppNo", txtApplicatoNo.Text.ToString().Trim());
            htLic.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htLic.Add("@Surname", txtSurname.Text.ToString().Trim());
           
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htLic.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htLic.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htLic.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htLic.Add("@CreateToDtim ", System.DBNull.Value);
            }
            if (Request.QueryString["ACT"].Trim() == "LicUpload")
            {
                htLic.Add("@flag", "1");//1 for upload
            }
            else if (Request.QueryString["ACT"].Trim() == "LicDownload")
            {
                htLic.Add("@flag", "2");
            }

            DataSet dsCfruser = new DataSet();
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            string unitcode = dsCfruser.Tables[0].Rows[0]["UnitCode"].ToString();
            if (UserType == "I")
            {
                htLic.Add("@MemberCode", MemberCode);
                htLic.Add("@MemberType", MemberType);
                DsAgtLic.Clear();
                DsAgtLic = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicUpldDwnldDtls", htLic);
            }
            else if (UserType == "E")
            {
                DsAgtLic.Clear();
                DsAgtLic = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicUpldDwnldDtlsforExtrnl", htLic);
            }
            if (DsAgtLic.Tables.Count > 0)
            {
                if (DsAgtLic.Tables[0].Rows.Count > 0)
                {
                    trdgRenTnr.Visible = true;
                    dgRenTrn.DataSource = DsAgtLic.Tables[0];
                    dgRenTrn.DataBind();
                    dgRenTrn.Visible = true;
                    lblMessage.Visible = false;
                    //trnote.Visible = false;
                }
                else
                {
                    dgRenTrn.DataSource = null;
                    dgRenTrn.DataBind();
                    dgRenTrn.Visible = false;
                    lblMessage.Visible = true;
                    string errormsg = lblMessage.Text;
                    //trnote.Visible = false;

                }
            }
            else
            {
                dgRenTrn.DataSource = null;
                dgRenTrn.DataBind();
                dgRenTrn.Visible = false;
                lblMessage.Visible = true;
                string errormsg = lblMessage.Text;
                //trnote.Visible = false;
            }
            DsAgtLic = null;
            Session["dtResult"] = null;

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
    //Added by shreela on 14042014 start
    protected void BindDataGridRenTrn()
    {
        try
        {
            dgRenTrn.PageIndex = 0;

            Hashtable htparam = new Hashtable();
            dsResult.Clear();
            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htparam.Add("@CndNo", txtCandCode.Text.ToString().Trim());
            htparam.Add("@AppNo", txtApplicatoNo.Text.ToString().Trim());
            htparam.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htparam.Add("@Surname", txtSurname.Text.ToString().Trim());
            
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htparam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htparam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htparam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htparam.Add("@CreateToDtim ", System.DBNull.Value);
            }
            if (Request.QueryString["ACT"].Trim() == "Upload")
            {
                htparam.Add("@flag", "1");//1 for upload
            }
            else if (Request.QueryString["ACT"].Trim() == "Download")
            {
                htparam.Add("@flag", "2");
            }
            else
            {
                htparam.Add("@flag", "3");
            }
            DataSet dsCfruser = new DataSet();
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            string unitcode = dsCfruser.Tables[0].Rows[0]["UnitCode"].ToString();
            if (UserType == "I")
            {
                htparam.Add("@MemberCode", MemberCode);
                htparam.Add("@MemberType", MemberType);
                dsResult.Clear();
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRenTrnDtls", htparam);
            }
            else if (UserType == "E")
            {
                dsResult.Clear();
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRenTrnDtlsForExtrnl", htparam);
            }
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    trdgRenTnr.Visible = true;
                    dgRenTrn.DataSource = dsResult.Tables[0];
                    dgRenTrn.DataBind();

                    ShowPageInformationRenTrn();
                    Session["dtResult"] = dsResult.Tables[0];
                    //trnote.Visible =true;
                }
                else
                {
                    dgRenTrn.DataSource = null;
                    dgRenTrn.DataBind();
                    dgRenTrn.Visible = false;
                    lblMessage.Visible = true;
                    string errormsg = lblMessage.Text;
                    //trnote.Visible = false;

                }
            }
            else
            {
                dgRenTrn.DataSource = null;
                dgRenTrn.DataBind();
                dgRenTrn.Visible = false;
                lblMessage.Visible = true;
                string errormsg = lblMessage.Text;
                //trnote.Visible = false;
            }
            dsResult = null;
            Session["dtResult"] = null;

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
    //Added by shreela on 14042014 end
    #endregion

    //added by shreela on 21042014---start
    #region Bind Data Grid to ReExam
    protected void BindDataGridReExam()
    {
        try
        {
            dgReExam.PageIndex = 0;
           
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
      
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            //htParam.Add("@UserType", Session["UnitRank"].ToString().Trim());
            //htParam.Add("@UserAuthCode", Session["UnitCode"].ToString().Trim());
            DataSet dsCfruser = new DataSet();
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            string unitcode = dsCfruser.Tables[0].Rows[0]["UnitCode"].ToString();
            if (UserType == "I")
            {
                htParam.Add("@MemberCode", MemberCode);
                htParam.Add("@MemberType", MemberType);
                dsResult.Clear();
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCandListForReExam", htParam);
            }
            else if (UserType == "E")
            {
                htParam.Add("@UnitCode", unitcode);
                dsResult.Clear();
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForReExmForExtrnl", htParam);
            }
            trdgreExam.Visible = true;
            dgReExam.Visible = true;
            dgDetails.Visible = false;
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgReExam.DataSource = dsResult.Tables[0];
                    dgReExam.DataBind();
                    ShowPageInformationExm();
                    tr6.Visible = false;
                    trDgDetails.Visible = true;
                    trButton.Visible = true;
                    btnAddnew.Enabled = true;
                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    Session["dtResult"] = dsResult.Tables[0];
                    //trnote.Visible =true;
                }
                else
                {
                    dgReExam.DataSource = null;
                    dgReExam.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    trButton.Visible = false;
                    lblMessage.Visible = true;
                    tr6.Visible = false;
                    string errormsg = lblMessage.Text;
                    trButton.Visible = true;
                    btnAddnew.Enabled = true;
                    //trnote.Visible = false;
                    // btnAddnew.CssClass = "btn btn-xs btn-primary";
                }
            }
            else
            {
                dgReExam.DataSource = null;
                dgReExam.DataBind();
                lblPageInfo.Text = "";
                trDetails.Visible = false;
                trDgDetails.Visible = false;
                trButton.Visible = false;
                lblMessage.Visible = true;
                tr6.Visible = false;
                trButton.Visible = true;
                btnAddnew.Enabled = true;
                //trnote.Visible = false;
                // btnAddnew.CssClass = "btn btn-xs btn-primary";
            }
            dsResult = null;
            Session["dtResult"] = null;
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
    //added by shreela on 21042014---end

    #region Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }

    #region Show Page Information for GridView of Fees
    private void ShowPageInformationFees()
    {
        int intPageIndex = dgFees.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgFees.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + dgFees.PageCount;
    }
    #endregion
    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    private void ShowPageInformationRetrieval()
    {
        int intPageIndex = dgRetrieval.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgRetrieval.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + dgRetrieval.PageCount;
    }
    //Added by Rahul on 22-04-2015 for Retrieval Grid end

    //added by shreela on 10042014 start
    private void ShowPageInformationRenTrn()
    {
        int intPageIndex = dgRenTrn.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgRenTrn.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + dgRenTrn.PageCount;
    }
    //added by shreela on 10042014 end
    //FOR CANDIDATE STATUS MODULE START
    private void ShowPageInformationCndStatus()
    {
        int intPageIndex = GridCndStatus.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridCndStatus.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + GridCndStatus.PageCount;
    }
    //FOR CANDIDATE STATUS MODULE END
    #endregion

    //added by shreela on 21042014---start
    #region Show Page InformationReExam for GridView
    private void ShowPageInformationExm()
    {
        int intPageIndex = dgReExam.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgReExam.PageCount;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + dgReExam.PageCount;
    }
    #endregion
    //added by shreela on 21042014---end

    #region Button 'Clear Click Event'
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ACT"] == null)
        {
            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"].Trim() == "LIC")
                {
                    Response.Redirect("CndEnq.aspx?Type=LIC");
                }
                //Added by pranjali on 27022014 start
                else if (Request.QueryString["type"].Trim() == "CandConv")
                {
                    Response.Redirect("CndEnq.aspx?Type=CandConv");
                }
                else if (Request.QueryString["type"].Trim() == "PREFFEXM")
                {
                    Response.Redirect("CndEnq.aspx?Type=PREFFEXM");
                }
                else if (Request.QueryString["type"].Trim() == "LicRnwl")
                {
                    Response.Redirect("CndEnq.aspx?Type=LicRnwl");
                }
                else if (Request.QueryString["type"].Trim() == "CndAllStat")
                {
                    Response.Redirect("CndEnq.aspx?Type=CndAllStat");
                }
                else if (Request.QueryString["type"].Trim() == "CndStat")
                {
                    //Response.Redirect("CndEnq.aspx?Type=CndStat");
                    Response.Redirect("FPCndEnq.aspx?Type=CndStat");
                    tr31.Attributes.Add("style", "display:none");
                }
                else if (Request.QueryString["type"].Trim() == "CndRev")
                {
                    Response.Redirect("CndEnq.aspx?Type=CndRev");
                }
                //Added by amruta on 18.8.15 start 
                else if (Request.QueryString["type"].Trim() == "FeesApp")
                {
                    Response.Redirect("CndEnq.aspx?Type=FeesApp");
                }
                //Added by amruta on 18.8.15 start
                //Added by pranjali on 27022014 end

   //Added by shreela on 14042014 start
                else if (Request.QueryString["type"].Trim() == "RenTrn")
                {
                    Response.Redirect("CndEnq.aspx?Type=RenTrn");
                }
                //Added by shreela on 14042014 end
                //added by shreela on 21042014---start
                if (Request.QueryString["type"].Trim() == "ReExam")
                {
                    Response.Redirect("CndEnq.aspx?Type=ReExam");
                }
                if (Request.QueryString["type"].Trim() == "viewDoc")
                {
                    Response.Redirect("FPCndEnq.aspx?Type=viewDoc");
                }
                //added by shreela on 21042014---end
            }
            else
            {
                lbltitle.Text = "Member Modification Search";
                if (Request.QueryString["ModuleID"].ToString() == "11402")
                {
                    //Response.Redirect("CndEnq.aspx?Type=CndStat");
                    Response.Redirect("FPCndEnq.aspx?ModuleID=11402");
                }
            }
        }
        else
        {
            //Added by pranjali on 06-03-2014 for redirecting page on clear button click start
            if ((Request.QueryString["ACT"].Trim() == "PR") && (Request.QueryString["type"].Trim() == "E"))
            {
                Response.Redirect("CndEnq.aspx?ACT=PR&type=E");
            }
            //added by shreela on 15042014 start
            else if (Request.QueryString["ACT"].Trim() == "Upload")
            {
                Response.Redirect("CndEnq.aspx?ACT=Upload&Type=RenTrn");
            }
            else if (Request.QueryString["ACT"].Trim() == "Download")
            {
                Response.Redirect("CndEnq.aspx?ACT=Download&Type=RenTrn");
            }
            else if (Request.QueryString["ACT"].Trim() == "Dwnld")
            {
                Response.Redirect("CndEnq.aspx?ACT=Dwnld&Type=RenTrn");
            }
            else if (Request.QueryString["ACT"].Trim() == "LicUpload")
            {
                Response.Redirect("CndEnq.aspx?ACT=LicUpload&Type=License");
            }
            else if (Request.QueryString["ACT"].Trim() == "LicDownload")
            {
                Response.Redirect("CndEnq.aspx?ACT=LicDownload&Type=License");
            }
            //added by shreela on 15042014 end
            else
            {
                Response.Redirect("CndEnq.aspx");
            }
        }
        //Response.Redirect("CndEnq.aspx");
        //Added by pranjali on 06-03-2014 for redirecting page on clear button click end
            lblMessage.Text = "";
            txtCandCode.Text="";
            txtApplicatoNo.Text="";
            txtGivenName.Text="";
            txtSurname.Text="";
            txtDTRegFrom.Text="";
            txtDTRegTo.Text="";
            txtMemberCode.Text = "";
            txtFrenchCode.Text = "";
            txtFrenchSap.Text = "";
            txtBranchName.Text = "";
            txtPan.Text = "";

    }
    #endregion

    #region GridView RowCommand
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "click")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                if (Request.QueryString["ACT"] != null)
                {
                    //Added by swapnesh start

                    if (Request.QueryString["ACT"].Trim() == "PR" && Request.QueryString["type"].Trim() == "E")
                    {
                        ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                        Response.Redirect("CndReg.aspx?ProspectId=" + cndno + "&Type=E&ACT=PR&ModuleID=" + ModuleID + "", false);
                       // Response.Redirect("CndReg.aspx?Type=N&ModuleID=" + ModuleID + "");
                    }
                }
                else if (Request.QueryString["Type"] == "CndAllStat")
                {
                    //Response.Redirect("CndReg.aspx?ProspectId=" + cndno + "&Type=E&ACT=PR", false);
                    GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblstatus1 = (Label)row1.FindControl("lblCndStatus");
                    if (lblstatus1.Text == "Prospect Reg")
                    {
                        LinkButton lbProsID = (LinkButton)row1.FindControl("lbProsID");
                        string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + lbProsID.Text + "','width=1000,height=800');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                    }
                    else
                    {
                        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "','width=1000,height=800');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                    }//'width=1000,height=670,resizable=0,left=190,scrollbars=1'

                }
                //added by ajay 01 june 2023
                else if(ddlmemtype.SelectedItem.Text == "HNIN")
                {
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    string AgnCd = (row.FindControl("lbCndNo") as LinkButton).Text; //row.Cells[0].Text.Trim();
                    string UnitCode = (row.FindControl("lblunitcode") as Label).Text;
                    Response.Redirect("HNINEnq.aspx?AgnCd=" + AgnCd + "&MemType=" + ddlmemtype.SelectedItem.Text + "&UnitCode=" + UnitCode + "&ModuleID=" + ModuleID, false);
                }
                else
                {
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                 //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "  &ModuleID=" + ModuleID +"&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    string AgnCd = (row.FindControl("lbCndNo") as LinkButton).Text; //row.Cells[0].Text.Trim();
                    string UnitCode = (row.FindControl("lblunitcode") as Label).Text;
                    //string UnitCode = row.Cells[8].Text.Trim();
                    string Type = "E";
                    string Ctgry = "Ven";
                    string ID = "IN";
                   // Response.Redirect("AGTInfo.aspx");//?CndNo=" + cndno + "  &ModuleID=" + ModuleID + "&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);
                    Response.Redirect("AGTInfo.aspx?AgnCd=" + AgnCd + "&Type=" + Type + "&Ctgry=" + Ctgry + "&UnitCode=" + UnitCode + "&ID=" + ID,false);
                    //string strWind = "window.open('AGTInfo.aspx?AgnCd=" + AgnCd + "&Type=" + Type + "&Ctgry=" + Ctgry + "&UnitCode=" + UnitCode + "&ID=" + ID + "');";

                }
                //Added by swapnesh End
                /////added by akshay start
                if (Request.QueryString["ACT"] == null)
                {
                    if (Request.QueryString["type"] != null)
                    {
                        if (Request.QueryString["type"].Trim() == "LIC")
                        {
                            Response.Redirect("CndLicDetails.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit&licflag=" + Request.QueryString["type"].ToString().Trim(), false);
                        }
                        else if (Request.QueryString["Type"] == "CndAllStat")
                        {
                            //Response.Redirect("CndReg.aspx?ProspectId=" + cndno + "&Type=E&ACT=PR", false);
                            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                            Label lblstatus1 = (Label)row1.FindControl("lblCndStatus");
                            if (lblstatus1.Text == "Prospect Reg")
                            {
                                LinkButton lbProsID = (LinkButton)row1.FindControl("lbProsID");
                                string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + lbProsID.Text + "');";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                            }
                            else
                            {
                                string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                            }

                        }
                        else if (Request.QueryString["Type"] == "viewDoc")
                        {

                            string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "','width=1000,height=800,top=59');";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

                        }
                        else
                        {
                            Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);
                        }
                    }
                }
                /////added by akshay end
                //added by pranjali for preffered exam detail start
                if (Request.QueryString["ACT"] == null)
                {
                    if (Request.QueryString["type"] != null)
                    {
                        if (Request.QueryString["type"].Trim() == "PREFFEXM")
                        {
                            //Response.Redirect("FrmPreffExmDtls.aspx?CndNo=" + cndno, false);
                            Response.Redirect("FrmSubmitTCC.aspx?CndNo=" + cndno + "&Type=E&mdlpopup=", false);  //Added by kalyani on 21/04/2014 for Preffered exam details
                        }
                        //added by pranjali on 27022014 for candidate conversion start
                        else if (Request.QueryString["type"].Trim() == "CandConv")
                        {
                            Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit&Flag=App", false);
                        }
                        //added by pranjali on 27022014 for candidate conversion end
                        else if (Request.QueryString["Type"] == "CndAllStat")
                        {
                            //Response.Redirect("CndReg.aspx?ProspectId=" + cndno + "&Type=E&ACT=PR", false);
                            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                            Label lblstatus1 = (Label)row1.FindControl("lblCndStatus");
                            if (lblstatus1.Text == "Prospect Reg")
                            {
                                LinkButton lbProsID = (LinkButton)row1.FindControl("lbProsID");
                                string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + lbProsID.Text + "');";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                            }
                            else
                            {
                                string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                            }

                        }
                        else
                        {
                            if (!(Request.QueryString["Type"] == "viewDoc"))
                            {
                                //string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "','width=1000,height=800');";
                                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                                //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);

                                /////divloadergrid.Visible = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDoc('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);

                            }
                            //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);By Bhaurao
                        }
                    }
                }
                //added by pranjali for preffered exam detail end
            }
            //added by pranjali on 27022014 for candidate conversion end
            if (e.CommandName == "CreateAgent")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                string strWindow = "window.open('~/../../ChannelMgmt/AGTInfo.aspx?cnd=CndCon&Type=N&CndNum=" + cndno + "');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
            //added by pranjali on 05-03-2014 for redirecting on click of viewstatus link start 
            else if (e.CommandName == "ViewStatus")

                if (Request.QueryString["Type"].Trim() == "viewDoc")
                {
                    DataSet dscount = new DataSet();

                    string cndno = e.CommandArgument.ToString().Trim();
                    string strresult = string.Empty;
                    string strnm = string.Empty;
                    GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblname = (Label)row1.FindControl("lblname");
                    strnm = lblname.Text.ToString().Trim();
                    strresult = "Documents Not Available of " + strnm;
                    Hashtable htParam = new Hashtable();
                    htParam.Add("@CndNo", cndno);
                    dscount = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);

                    if (dscount != null)
                    {
                        if (dscount.Tables.Count > 0)
                        {
                            if (dscount.Tables[0].Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDoc('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);

                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
                        return;
                    }
                }
                else
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblstatus = (Label)row.FindControl("lblCndStatus");


                    if (lblstatus.Text == "Prospect Reg")
                    {
                        LinkButton lbProsID = (LinkButton)row.FindControl("lbProsID");
                        string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + lbProsID.Text + "');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                    }
                    else if (Request.QueryString["Type"] == "viewDoc")
                    {
                        string cndno = e.CommandArgument.ToString().Trim();
                        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "','width=1000,height=800,top=59');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

                    }

                    else
                    {
                        string cndno = e.CommandArgument.ToString().Trim();
                        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                    }
                }
            //added by pranjali on 05-03-2014 for redirecting on click of viewstatus link end
            //Added by Rachana candidate Revival start
            else if (e.CommandName == "Revive")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit", false);
                Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Rev", false);
            }
            //Added by Rachana candidate Revival end
            //commented by pranjali on 23-04-2014 start
            //added by shreela on 18042014
            //            else if (e.CommandName == "License Renewal")
            //            {
            //                lbltitle.Text = "License Renewal";
            //                dsResult.Clear();
            //                Hashtable htParam = new Hashtable();
            //                string cndno = e.CommandArgument.ToString().Trim();
            //                htParam.Add("@CndNo", cndno);
            //                string Renew = dataAccessRecruit.execute_sprc_with_output("Prc_GetRenewalCnt", htParam, "@RenewalCnt");
            //                htParam.Add("@RenewalCnt", Renew);
            //                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndRenewalHst", htParam);
            //                string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=Renewal&CndNo=" + e.CommandArgument.ToString().Trim() + "&Type=Renwl&Code=Spon');";
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            //            }
            //added by shreela on 18042014
            //commented by pranjali on 23-04-2014 end


          //added by pranjali on 22-04-2014 start
            else if (e.CommandName == "License Renewal")
            {
                lbltitle.Text = "License Renewal";
                dsResult.Clear();
                DataSet dsValidSM = new DataSet();
                Hashtable htParam = new Hashtable();
                string cndno = e.CommandArgument.ToString().Trim();
                htParam.Add("@CndNo", cndno);
                dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSMRnwl", htParam);
                if (dsValidSM.Tables[0].Rows.Count > 0)
                {
                    string Renew = dataAccessRecruit.execute_sprc_with_output("Prc_GetRenewalCnt", htParam, "@RenewalCnt");
                    htParam.Add("@RenewalCnt", Renew);
                    htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    htParam.Add("@UpdateBy", Session["UserID"].ToString().Trim());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndRenewalHst", htParam);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopen('" + e.CommandArgument.ToString().Trim() + "');", true);
                    string Preview = e.CommandArgument.ToString().Trim();
                    //string CndNo = Request.QueryString["CndNo"].ToString().Trim();
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    string strWindow = "window.open('FrmSubmitRetrievalRqst.aspx?TrnRequest=Renewal&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=Spon" + "&Type=Renwl');";
                    // string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                }
                else
                {
                    Hashtable htagncode = new Hashtable();
                    DataSet dsAgnCode = new DataSet();
                    htagncode.Add("@CndNo", cndno);
                    dsAgnCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkAgnCode", htagncode);
                    if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                        return;
                    }
                    else
                    {
                        string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                        Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                    }
                }
                //added by pranjali on 22-04-2014 end
            }
            //added by pranjali on 17-04-2014 start
            else if (e.CommandName == "SMAllocation")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblLicenseStatus = (Label)row.FindControl("lblLicenseStatus");
                string LicStatus = lblLicenseStatus.Text;
                LinkButton lnkcnd = (LinkButton)row.FindControl("lbCndNo");
                string cndno = lnkcnd.Text;
                if (LicStatus == "Not Licensed")
                {
                    Response.Redirect("FrmSMAllocation.aspx?CndNo=" + e.CommandArgument.ToString().Trim(), false);//added by pranjali on 15042014
                }
                else if (LicStatus == "Licensed")
                {
                    Hashtable htagncode = new Hashtable();
                    DataSet dsAgnCode = new DataSet();
                    htagncode.Add("@CndNo", cndno);
                    dsAgnCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkAgnCode", htagncode);
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
            //added by pranjali on 17-04-2014 end
            //Added by kalyani on 27-05-14 for preffered exam date link start
            else if (e.CommandName == "Preffered Date")
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                Response.Redirect("FrmSubmitTCC.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Type=E&mdlpopup=", false);
            }
            //Added by kalyani on 27-05-14 for preffered exam date link end



            else if (e.CommandName == "Agent Profile")
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                Response.Redirect("AgentProfilling.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Type=E&mdlpopup=", false);
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
    //added by shreela on 14042014 start
    protected void dgRenTrn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "RenewalU")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                string strWindow = "window.open('FrmSubmitTCC.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ACT=Upload&Type=RenTrn&Code=TccUpld&mdlpopup=');";//shree07
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
            else if (e.CommandName == "RenewalD")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                string strWindow = "window.open('FrmSubmitTCC.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ACT=Download&Type=RenTrn&Code=TccDwnld&mdlpopup=');";//shree07
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
            else if (e.CommandName == "Dwnld")
            {
                string cndno = e.CommandArgument.ToString().Trim();
                string strWindow = "window.open('FrmSubmitTCC.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ACT=Dwnld&Type=RenTrn&Code=TccDwnld&mdlpopup=');";//shree07
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
            //Added by pranjali on 20-10-2014 for license upload download start
            else if ((e.CommandName == "LicUpld") || (e.CommandName == "LicDwnld"))
            {
                string cndno = e.CommandArgument.ToString().Trim();
                string strWindow = "window.open('FrmSubmitTCC.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "&ACT=" + ViewState["AgtLicAct"] + "&Type=" + ViewState["AgtLicType"] + "&Code=" + ViewState["AgtLicCode"] + "&mdlpopup=');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
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
    //added by shreela on 14042014 end

    //added by shreela on 27032014---start
    protected void dgReExam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sponsorship")
        {
            lbltitle.Text = "ReExamination";
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string cndno = e.CommandArgument.ToString().Trim();
            htParam.Add("@CndNo", cndno);
            dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSM", htParam);
            if (dsValidSM.Tables[0].Rows.Count > 0)
            {
                //string cndno = e.CommandArgument.ToString().Trim();
                htable.Clear();
                dsResult.Clear();
                htable.Add("@CndNo", cndno);
                //x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdCandTypeForReExam", htable);
                //x = dataAccessRecruit.execute_sprcrecruit("Prc_GetRenewalCnt", htable);
                string Reexm = dataAccessRecruit.execute_sprc_with_output("Prc_GetReExmCnt", htable, "@ReExmCnt");
                htable.Add("@ReExmCnt", Reexm);
                htable.Add("@ReExmType", "I");
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndReExmHst", htable);
                //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=ReExam&CndNo=" + e.CommandArgument.ToString().Trim() + "&ReExm=" + Reexm + "&Type=ReTrn&Code=Spon');";
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenReExam('" + e.CommandArgument.ToString().Trim() + "','" + Reexm + " ');", true);
            }
            else
            {
                Hashtable htagncode = new Hashtable();
                DataSet dsAgnCode = new DataSet();
                htagncode.Add("@CndNo", cndno);
                dsAgnCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkAgnCode", htagncode);
                if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                    return;
                }
                else
                {
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    ///Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?cnd=CndCon&Type=N&CndNum=" + lblCndNoValue.Text, false);
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
        }
        else if (e.CommandName == "ReExam")
        {
            lbltitle.Text = "ReExamination";
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string cndno = e.CommandArgument.ToString().Trim();
            htParam.Add("@CndNo", cndno);
            dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSM", htParam);
            if (dsValidSM.Tables[0].Rows.Count > 0)
            {
                //string cndno = e.CommandArgument.ToString().Trim();
                htable.Clear();
                dsResult.Clear();
                htable.Add("@CndNo", cndno);
                string Reexm = dataAccessRecruit.execute_sprc_with_output("Prc_GetReExmCnt", htable, "@ReExmCnt");
                htable.Add("@ReExmCnt", Reexm);
                htable.Add("@ReExmType", "V");
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndReExmHst", htable);
                //string strWindow = "window.open('FrmPreffExmDtls.aspx?CndNo=" + e.CommandArgument.ToString().Trim() + "');";
                //string strWindow = "window.open('FrmSubmitTCC.aspx?Type=ReExam&CndNo=" + e.CommandArgument.ToString().Trim() + "&ReExm=" + Reexm + "&Code=Spon');";
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                String ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenReExamV('" + e.CommandArgument.ToString().Trim() + "','" + Reexm + "','" + ModuleID + " ');", true);
            }
            else
            {
                Hashtable htagncode = new Hashtable();
                DataSet dsAgnCode = new DataSet();
                htagncode.Add("@CndNo", cndno);
                dsAgnCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkAgnCode", htagncode);
                if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                    return;
                }
                else
                {
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
        }
    }
    //added by shreela on 27032014---end
    #endregion

    #region GridCndStatus RowCommand FOR CANDIDATE STATUS MODULE
    protected void GridCndStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //added by pranjali on 05-03-2014 for redirecting on click of viewstatus link start 
            //if (e.CommandName == "ReqClick")
            //{
            //    DataSet dsValidSM = new DataSet();
            //    Hashtable htParam = new Hashtable();
            //    string MemCode = e.CommandArgument.ToString().Trim();
            //    //htParam.Add("@CndNo", cndno);
            //    //dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSM", htParam);
            //    //if (dsValidSM.Tables[0].Rows.Count > 0)
            //    //{

            //    //ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            //    Response.Redirect("AGTInfo.aspx");

            //    //Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014

            //}
            if (e.CommandName == "ReqClick")
            {
                DataSet dsValidSM = new DataSet();
                Hashtable htParam = new Hashtable();
                string MemCode = e.CommandArgument.ToString().Trim();
                //int rowIndex = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = GridCndStatus.Rows[rowIndex];
                //string percentage = ((DataBoundLiteralControl)e.row.Cells[7].Controls[0]).Text;
                //string AgnCd = row.Cells[0].Text;
                //string UnitCode = row.Cells[8].Text;
                
                //Added by ajay
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string AgnCd = (row.FindControl("lblMemCode") as Label).Text; // row.Cells[1].Text.Trim();
                string UnitCode = (row.FindControl("lblunitcode") as Label).Text;
                //string UnitCode = row.Cells[8].Text.Trim();
                string Type = Request.QueryString["Type"].Trim();
                string Ctgry = "Ven";
                string ID = "IN";
                //htParam.Add("@CndNo", cndno);
                //dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSM", htParam);
                //if (dsValidSM.Tables[0].Rows.Count > 0)
                //{
                //ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                //Response.Redirect("AGTInfo.aspx");
                string strWind = "window.open('AGTInfo.aspx?AgnCd=" + AgnCd + "&Type=" + Type + "&Ctgry=" + Ctgry + "&UnitCode=" + UnitCode + "&ID=" + ID + "');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWind, true);
                //Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014
            }//added by sanoj 20-01-2022
            if (e.CommandName == "ViewStatus")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                //Label lblstatus = (Label)row.FindControl("lblCndStatus1");//Comented by usha on 28.08.2020
                Label lblstatus = (Label)row.FindControl("lblStatusvalue");
                string status = lblstatus.Text.Trim();

              //  if (lblstatus.Text == "Prospect Reg" || lblstatus.Text == "Pending POSP Candidate Approval")//Added by usha on 28.08.2020
                if (status  == "10" || status  == "15" || status  == "180")//Added by usha on 28.08.2020
                {
                    LinkButton lbProsID = (LinkButton)row.FindControl("lbProsID1");
                    string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + lbProsID.Text + "');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                }
                else
                {
                    string cndno = e.CommandArgument.ToString().Trim();
                    string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                }
            }
            //added by pranjali on 05-03-2014 for redirecting on click of viewstatus link end
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

    #region
    protected void dgRenTrn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblAppno = (Label)e.Row.FindControl("lblApp");
                LinkButton lnkAction = (LinkButton)e.Row.FindControl("lnkAction");
                lnkAction.Attributes.Add("onclick", "funcPopupAct('act','" + lblAppno.Text + "');return false;");
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

    #region Button 'Submit' Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
        Response.Redirect("CndReg.aspx?Type=N&ModuleID="+ModuleID+"");
       
    }
    #endregion

    #region 'ddlShwRecrds_SelectedIndexChanged'
   

    protected void ddlShwRecrds1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds1.SelectedValue != null )
        {
            BindDataGrid();
        }
    }

    #endregion

    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try// if (Request.QueryString["type"].Trim() == "LicRnwl")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["ACT"] == null || Request.QueryString["ACT"] == "")
                {
                    if (Request.QueryString["type"] == null || Request.QueryString["Type"] == null)
                    {

                        LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                        lbProsID.Enabled = false;
                    }
                }
                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["Type"].Trim() == "CndStat" || Request.QueryString["type"].Trim() == "CndRev" || Request.QueryString["type"].Trim() == "LicRnwl" || Request.QueryString["type"].Trim() == "PREFFEXM")
                    {
                        LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                        lbCndNo.Enabled = false;
                        LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                        lbProsID.Enabled = false;
                    }
                    if (Request.QueryString["Type"].Trim() == "CndStat")
                    {
                        LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                        lbProsID.Enabled = false;
                        LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                        lbCndNo.Enabled = false;

                    }
                }
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].Trim() == "SMAlloct")
                    {
                        LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                        lbProsID.Enabled = false;
                        LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                        lbCndNo.Enabled = false;
                    }
                }
                if (Request.QueryString["Type"].Trim() == "viewDoc")
                {
                    // LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                    // lbProsID.Enabled = false;
                    //LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                    // lbCndNo.Enabled = false;
                    LinkButton lnk_viewdoc = (LinkButton)e.Row.FindControl("lnkCndNo_view");
                    lnk_viewdoc.Text = "View Document";

                    //bhaurao
                }
                //Added by usha  for aadhar   on  24.07.2017
                if (Request.QueryString["Type"].Trim() == "AgentProfile")
                {
                    LinkButton lnk_viewdoc = (LinkButton)e.Row.FindControl("lnkCndNo_view");
                    lnk_viewdoc.Text = "Agent Profile";
                    
                    LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                    lbProsID.Enabled = false;
                    LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                    lbCndNo.Enabled = false;
                    //Added by usha  for aadhar   on  24.07.2017
                 
                }
                LinkButton lnkview = (LinkButton)e.Row.FindControl("lnkCndNo_view");
                lnkview.Attributes.Add("onclick", "LdWaitGrid(100000)");
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

    #region CANDIDATE STATUS MODULE
    protected void GridCndStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
           //LinkButton lblRequest= (LinkButton)e.Row.FindControl("lblRequest");
            Label lblaction1 = (Label)e.Row.FindControl("lblaction1");
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["Type"].Trim() == "CndStat")
                {
                    //LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID1");
                    //lbProsID.Enabled = false;
                    //LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo1");
                    //lbCndNo.Enabled = false;
                }
                LinkButton lnkview = (LinkButton)e.Row.FindControl("lnkCndNo_view1");
                //lnkview.Attributes.Add("onclick", "LdWaitGrid(100000)"); comented by sanoj 14032023
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
    //added by shreela on 21042014---start
    #region dgReExam RowDataBound
    protected void dgReExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkSpon = new LinkButton();
                lnkSpon = (LinkButton)e.Row.FindControl("lnkSpon");
                LinkButton lnkRe = new LinkButton();
                lnkRe = (LinkButton)e.Row.FindControl("lnkRe");
                Label lblTcc = new Label();
                lblTcc = (Label)e.Row.FindControl("lblTcc");
                //if (lblTcc.Text == "Invalid TCC")
                //{
                //    lnkSpon.Visible = true;
                //}
                //else
                //{
                lnkRe.Visible = true;
                //}
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
    //added by shreela on 21042014---end
    

    protected void btnReFresh_Click(object sender, EventArgs e)
    {
        if (ViewState["Value"].ToString().Trim() == "LicRnwl")
        {
            BindDataGrid();
        }
        else if (ViewState["Value"].ToString().Trim() == "ReExam")
        {
            BindDataGridReExam();
        }
    }
     

   
    protected void BindLICID()
    {
        try
        {
            GrdLicId.PageIndex = 0;
            if (trshowrecords.Visible == true)
            {
                GrdLicId.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
             
            }
            dsRprt.Clear();
            //htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htRprt.Add("@MemCode", txtMemberCode.Text.ToString().Trim());
            htRprt.Add("@EmpCode", txtFrenchCode.Text.ToString().Trim());
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", txtSurname.Text.ToString().Trim());
           
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
            //htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            htRprt.Add("@SapCode", txtSapCode.Text);
     
            htRprt.Add("@UserId", Session["UserID"].ToString().Trim());
            
       //     htRprt.Add("@Flag", "1");
            dsRprt = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemWelcomeDownload", htRprt);
            //}
            if (dsRprt.Tables.Count > 0)
            {
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GrdLicId.DataSource = dsRprt.Tables[0];
                    GrdLicId.DataBind();
                    ViewState["grid"] = dsRprt.Tables[0];
                    if (GrdLicId.PageCount > Convert.ToInt32(txtLICId.Text))
                    {
                        btnNextLICId.Enabled = true;
                    }
                    else
                    {
                        btnNextLICId.Enabled = false;
                    }
                    Session["dtRPrt"] = dsRprt.Tables[0];
                    //trnote.Visible =true;
                    trLICId.Visible = true;
                    tr31.Visible = true;
                   // trLICId.Attributes.Add("style", "display:block");
                    dgDetails.Visible = false;
                }
                else
                {
                    GrdLicId.DataSource = null;
                    GrdLicId.DataBind();
                    GrdLicId.Visible = false;
                }
            }
            else
            {
                GrdLicId.DataSource = null;
                GrdLicId.DataBind();
                //trnote.Visible = false;
            }
            dsRprt = null;
            Session["dtRprt"] = null;

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
    //Added by Nikhil on 18-04-2015 for License and ID Download end
    //Added by Nikhil on 18-05-2015 for License and ID Download start

    
    #region GvRprt PageIndexChanging
    protected void GvRprt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //try
        //{
        //    //For Pagination of Search Grid
        //    //DataTable dt = GetIndvReport();
        //    DataView dv = new DataView(dt);
        //    GridView dgSource = (GridView)sender;
        //    dgSource.PageIndex = e.NewPageIndex;
        //    dv.Sort = dgSource.Attributes["SortExpression"];
        //    if (dgSource.Attributes["SortASC"] == "No")
        //    {
        //        dv.Sort += " DESC";
        //    }
        //    dgSource.DataSource = dv;
        //    dgSource.DataBind();
        //    ShowPageInformation();
        //}
        //catch (Exception ex)
        //{
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
        //    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //}
    }
    #endregion
  
    #region GvRprt RowDataBound
    protected void GvRprt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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
    #endregion
    protected void GvRprt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Report")
        {
            string ReportType = Request.QueryString["ACT"].Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
    }

    protected DataTable GetRetrivalGrid()
    {
        Hashtable htParam = new Hashtable();
        DataSet dsDocRet = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
        htParam.Add("@CndNo", txtCandCode.Text.Trim());
        htParam.Add("@GivenName", txtGivenName.Text.Trim());
        htParam.Add("@Surname", txtSurname.Text.Trim());
     
        if (txtDTRegFrom.Text.Trim() != "")
        {
            htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
        }
        if (txtDTRegTo.Text.Trim() != "")
        {
            htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@CreateToDtim ", System.DBNull.Value);
        }
        dsDocRet = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqDocumentRetrivalForExtrnl", htParam);

        if (dsDocRet != null)
        {
            if (dsDocRet.Tables.Count > 0)
            {
                lblMessage.Visible = false;
                GrdDocumentRet.DataSource = dsDocRet;
                GrdDocumentRet.DataBind();
            }
            else
            {
                GrdDocumentRet.DataSource = null;
                GrdDocumentRet.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
            }
        }
        else
        {
            GrdDocumentRet.DataSource = null;
            GrdDocumentRet.DataBind();
            lblMessage.Text = "0 Record Found";
            lblMessage.Visible = true;
        }

        return dsDocRet.Tables[0];
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        GridViewRow[] DocumentRetrival = new GridViewRow[GrdDocumentRet.Rows.Count];
        GrdDocumentRet.Rows.CopyTo(DocumentRetrival, 0);
        foreach (GridViewRow row in DocumentRetrival)
        {
            CheckBox chkrcvd = (CheckBox)row.FindControl("chkrcvd");
            TextBox txtRemarkRet = (TextBox)row.FindControl("txtRemarkRet");
            TextBox txtdocrecdate = (TextBox)row.FindControl("txtdocrecdate");
            Label lblCndRet = (Label)row.FindControl("lblCndRet");
            Label lblAppRet = (Label)row.FindControl("lblAppRet");

            if (chkrcvd.Checked == true)
            {
                Hashtable htParam = new Hashtable();
                htParam.Add("@CndNo", lblCndRet.Text);
                htParam.Add("@AppNo", lblAppRet.Text);
                htParam.Add("@DocRcvd", 'Y');
                htParam.Add("@Docdate", txtdocrecdate.Text);
                htParam.Add("@Remark", txtRemarkRet.Text);
                htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                dataAccessRecruit.execute_sprcrecruit("Prc_InsRemarkRetrival", htParam);

            }
        }

        lbl3.Text = "Remark saved successfully";
        //lblDocRcvd.Text = "Closed successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text +
        //"<br/>Note :- Please proceed with Update.";
        //mdlViewRen.Show();
        //pnlMdlDocRcvd.Visible = true;
        //BindRetrivalGrid();
        btnSave.Visible = false;
    }

    protected void GrdDocumentRet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void GrdDocumentRet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetRetrivalGrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void GrdDocumentRet_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationCndStatus();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //added by Nikhil for License & ID Download on 18042015---start
    protected void GrdLicId_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FPWelcmLttr")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
        else if (e.CommandName == "ID")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
    }

    //Added by pallavi on 25\08\2020 for Posp licence copy start
    protected void GrdLicPosp_RowCommand (object sender, GridViewCommandEventArgs e)
    {

        //PospAppointment
        if (e.CommandName == "PospAppointment")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
        else if (e.CommandName == "ID")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
    }


    //Added by pallavi on 25\08\2020 for Posp licence copy end

    protected void GrdLicId_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDatatableForLICCpyandID();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Added by pallavi on 25-08-2020 for License Download for posp start


    protected void GrdLicPosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDatatableForPospAppn();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Added by pallavi on 25-08-2020 for License Download for posp end


    protected void GrdLicId_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationCndStatus();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //Added by pallavi on 25-08-2020 for License Download for posp start
    protected void GrdLicPosp_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationCndStatus();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    //Added by pallavi on 25-08-2020 for License Download for posp end

    private DataTable GetDatatableForLICCpyandID()
    {
        try
        {
            GvRprt.PageIndex = 0;

            //dsRprt.Clear();
            //htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htRprt.Add("@CndNo", txtCandCode.Text.ToString().Trim());
            //htRprt.Add("@AppNo", txtApplicatoNo.Text.ToString().Trim());
            //htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            //htRprt.Add("@Surname", txtSurname.Text.ToString().Trim());

            //if (txtDTRegFrom.Text.Trim() != "")
            //{
            //    htRprt.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    htRprt.Add("@CreateFrmDtim ", System.DBNull.Value);
            //}
            //if (txtDTRegTo.Text.Trim() != "")
            //{
            //    htRprt.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    htRprt.Add("@CreateToDtim ", System.DBNull.Value);
            //}
            //htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            //htRprt.Add("@AgentSapCode", txtSapCode.Text);


            //htRprt.Add("@uSERID", Session["UserID"].ToString().Trim());
            //if (Request.QueryString["Type"].Trim() == "FPWelcmLttr")
            //{
            //    htRprt.Add("@Flag", "1");
            //}
            //else
            //{
            //    htRprt.Add("@Flag", "2");
            //}
            /*dsRprt = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicenseandIDDownload", htRprt);*/

            dsRprt.Clear();
            //htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htRprt.Add("@MemCode", txtMemberCode.Text.ToString().Trim());
            htRprt.Add("@EmpCode", txtFrenchCode.Text.ToString().Trim());
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", txtSurname.Text.ToString().Trim());

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
            //htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            htRprt.Add("@SapCode", txtSapCode.Text);

            htRprt.Add("@UserId", Session["UserID"].ToString().Trim());

            dsRprt = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemWelcomeDownload", htRprt); 

            if (dsRprt.Tables.Count > 0)
            {
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GrdLicId.DataSource = dsRprt.Tables[0];
                    GrdLicId.DataBind();
                    Session["dtRPrt"] = dsRprt.Tables[0];
                    //trnote.Visible =true;
                    trLICId.Visible = true;
                }
                else
                {
                    GrdLicId.DataSource = null;
                    GrdLicId.DataBind();
                    GrdLicId.Visible = false;
                }
            }
            else
            {
                GrdLicId.DataSource = null;
                GrdLicId.DataBind();
                //trnote.Visible = false;
            }
           // dsRprt = null;
            Session["dtRprt"] = null;

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
        return dsRprt.Tables[0];
    }
    //added by Nikhil on 18042015---end 
    //added by Nikhil for NOC IC  on 31082015---start

    //Added by pallavi on 25\08\2020 for Posp licence copy start
    private DataTable GetDatatableForPospAppn()
    {
        try
        {
            GvRprt.PageIndex = 0;
        
            dsRprt.Clear();
            htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htRprt.Add("@CndNo", txtCandCode.Text.ToString().Trim());
            htRprt.Add("@AppNo", txtApplicatoNo.Text.ToString().Trim());
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", txtSurname.Text.ToString().Trim());
            
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
            htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            htRprt.Add("@AgentSapCode", txtSapCode.Text);
          

            htRprt.Add("@uSERID", Session["UserID"].ToString().Trim());
            if (Request.QueryString["Type"].Trim() == "PospAgntLic")
            {
                htRprt.Add("@Flag", "1");
            }
            else
            {
                htRprt.Add("@Flag", "2");
            }
            dsRprt = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_PospGetLicenseandIDDownload", htRprt);

            if (dsRprt.Tables.Count > 0)
            {
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GrdLicPosp.DataSource = dsRprt.Tables[0];
                    GrdLicPosp.DataBind();
                    Session["dtRPrt"] = dsRprt.Tables[0];
                    //trnote.Visible =true;
                    trLICPosp.Visible = true;
                }
                else
                {
                    GrdLicPosp.DataSource = null;
                    GrdLicPosp.DataBind();
                    GrdLicPosp.Visible = false;
                }
            }
            else
            {
                GrdLicPosp.DataSource = null;
                GrdLicPosp.DataBind();
                //trnote.Visible = false;
            }
            // dsRprt = null;
            Session["dtRprt"] = null;

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
        return dsRprt.Tables[0];
    }

    //Added by pallavi on 25\08\2020 for Posp licence copy end

    protected void GridNOCIC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "NOC")
        {
            string ReportType;
            if (Request.QueryString["Type"].Trim() == "POSPNOCIC")
            {
                  ReportType = "POSPNOCIC";
            }
            else
            {
                  ReportType = e.CommandName;
            }
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }

    }

    protected void GridNOCIC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDatatableFORNOCIC();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void GridNOCIC_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformationCndStatus();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    private DataTable GetDatatableFORNOCIC()
    {
        try
        {
            GvRprt.PageIndex = 0;
            
            dsRprt.Clear();
            htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htRprt.Add("@CndNo", txtCandCode.Text.ToString().Trim());
            htRprt.Add("@AppNo", txtApplicatoNo.Text.ToString().Trim());
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", txtSurname.Text.ToString().Trim());
           
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
            htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            htRprt.Add("@AgentSapCode", txtSapCode.Text);
         

            dsRprt = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCICsearch", htRprt);

            if (dsRprt.Tables.Count > 0)
            {
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GridNOCIC.DataSource = dsRprt.Tables[0];
                    GridNOCIC.DataBind();
                    Session["dtRPrt"] = dsRprt.Tables[0];
                    //trnote.Visible =true;
                    trNOCIC.Visible = true;
                }
                else
                {
                    GridNOCIC.DataSource = null;
                    GridNOCIC.DataBind();
                    GridNOCIC.Visible = false;
                }
            }
            else
            {
                GridNOCIC.DataSource = null;
                GridNOCIC.DataBind();
                //trnote.Visible = false;
            }
            dsRprt = null;
            Session["dtRprt"] = null;

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
        return dsRprt.Tables[0];
    }
    //added by Nikhil on 18042015---end    
    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    protected void dgRetrieval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTableRetrieval();
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
            ShowPageInformationRetrieval();
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
    //Added by Rahul on 22-04-2015 for Retrieval Grid end

    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    protected void dgRetrieval_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "License Renewal")
            {
                lbltitle.Text = "License Renewal";
                dsResult.Clear();
                DataSet dsValidSM = new DataSet();
                Hashtable htParam = new Hashtable();
                string cndno = e.CommandArgument.ToString().Trim();
                htParam.Add("@CndNo", cndno);
                dsValidSM = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkValidSMRnwl", htParam);
                if (dsValidSM.Tables[0].Rows.Count > 0)
                {
                    string Renew = dataAccessRecruit.execute_sprc_with_output("Prc_GetRenewalCnt", htParam, "@RenewalCnt");
                    htParam.Add("@RenewalCnt", Renew);
                    htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    htParam.Add("@UpdateBy", Session["UserID"].ToString().Trim());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndRenewalHst", htParam);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopen('" + e.CommandArgument.ToString().Trim() + "');", true);
                    string Preview = e.CommandArgument.ToString().Trim();
                    //string CndNo = Request.QueryString["CndNo"].ToString().Trim();
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    string strWindow = "window.open('FrmSubmitRetrievalRqst.aspx?TrnRequest=Renewal&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=Spon" + "&Type=Renwl');";
                    // string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                }
                else
                {
                    Hashtable htagncode = new Hashtable();
                    DataSet dsAgnCode = new DataSet();
                    htagncode.Add("@CndNo", cndno);
                    dsAgnCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkAgnCode", htagncode);
                    if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                        return;
                    }
                    else
                    {
                        //added by amruta for external user (transfer page not open) on 16-03-2017 start
                        if (ViewState["UserType"].ToString() == "E")
                        {
                            string Renew = dataAccessRecruit.execute_sprc_with_output("Prc_GetRenewalCnt", htParam, "@RenewalCnt");
                            htParam.Add("@RenewalCnt", Renew);
                            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                            htParam.Add("@UpdateBy", Session["UserID"].ToString().Trim());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCndRenewalHst", htParam);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopen('" + e.CommandArgument.ToString().Trim() + "');", true);
                            string Preview = e.CommandArgument.ToString().Trim();
                            //string CndNo = Request.QueryString["CndNo"].ToString().Trim();
                            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                            string strWindow = "window.open('FrmSubmitRetrievalRqst.aspx?TrnRequest=Renewal&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=Spon" + "&Type=Renwl');";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                        }
                        //added by amruta for external user (transfer page not open) on 16-03-2017 end
                        else
                        {
                            string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                            Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
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
    //Added by Rahul on 22-04-2015 for Retrieval Grid end

    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    protected void dgRetrieval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try// if (Request.QueryString["type"].Trim() == "LicRnwl")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (Request.QueryString["ACT"] != null)
                //{
                //    if (Request.QueryString["type"].Trim() == "LicRnwl")
                //    {
                //        LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                //        lbCndNo.Enabled = false;
                //        LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                //        lbProsID.Enabled = false;
                //    }
                //}
                //LinkButton lnkview = (LinkButton)e.Row.FindControl("lnkCndNo_view");
                //lnkview.Attributes.Add("onclick", "LdWaitGrid(100000)");
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
    //Added by Rahul on 22-04-2015 for Retrieval Grid end

    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    protected void dgRetrieval_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = GetDataTableRetrieval();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformation();
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
    //Added by Rahul on 22-04-2015 for Retrieval Grid end

    //Added by Rahul on 22-04-2015 for Retrieval Grid start
    #region Bind Data to GridView for retrieval
    protected void BindDataGridRetrieval()
    {
        try
        {
            dgRetrieval.PageIndex = 0;

            if (trshowrecords.Visible == true)
            {
                dgRetrieval.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());
            }
            
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            if (Request.QueryString["ACT"] != null)
            {
            }
            //to insert appno for candidate enquiry search
            else
            {
                htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
            }
            //Added by kalyni on 3-1-2014 to insert appno end
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
         
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            htParam.Add("@Page", "CndEnq");

            //For Internal UserType
            if (ViewState["UserType"].ToString() == "I")
            {
                htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetCandidateForEnquiry", htParam);
            }
            //For External UserType
            else if (ViewState["UserType"].ToString() == "E")
            {
                dsResult.Clear();
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetCandidateForEnquiryForExtrnl", htParam);
            }

            if (Request.QueryString["ACT"] == null)
            {
                if (Request.QueryString["type"] != null)
                {
                    if (Request.QueryString["type"].Trim() == "LicRnwl")
                    {
                        if (ViewState["UserType"].ToString() == "I")
                        {
                            dsResult.Clear();
                            htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                            htParam.Add("@LcnNo", txtSapCode.Text);
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwl", htParam);
                            //dgDetails.Columns[0].Visible = false;
                            //dgDetails.Columns[3].Visible = false;
                            //dgDetails.Columns[9].Visible = true;
                            //dgDetails.Columns[10].Visible = true;
                            //dgDetails.Columns[11].Visible = true;
                            //dgDetails.Columns[12].Visible = true;
                            //dgDetails.Columns[13].Visible = true;//added by rachana on 06/03/2013
                            //dgDetails.Columns[14].Visible = true;
                            //dgDetails.Columns[15].Visible = false;
                            //dgDetails.Columns[16].Visible = false;
                            //dgDetails.Columns[17].Visible = false;
                            //dgDetails.Columns[18].Visible = false;
                            //dgDetails.Columns[20].Visible = true;
                            lbltitle.Text = "Retrieval";
                        }
                        else if (ViewState["UserType"].ToString() == "E")
                        {
                            dsResult.Clear();
                            htParam.Add("@AgentBrokerCode", txtAgntBroker.Text);
                            htParam.Add("@LcnNo", txtSapCode.Text);
                            htParam.Add("@UserId", HttpContext.Current.Session["UserID"].ToString().Trim());//amruta added
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_EnqCndListForRnwlForExtrnl", htParam);
                            //dgDetails.Columns[3].Visible = false;
                            //dgDetails.Columns[9].Visible = true;
                            //dgDetails.Columns[10].Visible = true;
                            //dgDetails.Columns[11].Visible = true;
                            //dgDetails.Columns[12].Visible = false;
                            //dgDetails.Columns[13].Visible = false;//added by rachana on 06/03/2013
                            //dgDetails.Columns[14].Visible = true;
                            //dgDetails.Columns[15].Visible = false;
                            //dgDetails.Columns[16].Visible = false;
                            //dgDetails.Columns[17].Visible = false;
                            //dgDetails.Columns[18].Visible = false;
                            //dgDetails.Columns[20].Visible = true;
                            lbltitle.Text = "Retrieval";
                        }
                    }
                }
            }

            #region BINDING GRID
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    dgRetrieval.DataSource = dsResult.Tables[0];
                    dgRetrieval.DataBind();
                    ShowPageInformationRetrieval();
                    trRetrieval.Visible = true;
                    trButton.Visible = true;
                    btnAddnew.Enabled = true;
                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    Session["dtResult"] = dsResult.Tables[0];
                   // //trnote.Visible =true;
                }
                else
                {
                    dgRetrieval.DataSource = null;
                    dgRetrieval.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trRetrieval.Visible = false;
                    trButton.Visible = false;
                    lblMessage.Visible = true;
                    tr6.Visible = false;
                    lblMessage.Text = "0 Record Found";
                    string errormsg = lblMessage.Text;
                    trButton.Visible = true;
                    btnAddnew.Enabled = true;
                    ////trnote.Visible = false;
                    //btnAddnew.CssClass = "btn btn-xs btn-primary";
                }
            }

            else
            {
                dgRetrieval.DataSource = null;
                dgRetrieval.DataBind();
                lblPageInfo.Text = "";
                trDetails.Visible = false;
                trRetrieval.Visible = false;
                trButton.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                tr6.Visible = false;
                trButton.Visible = true;
                btnAddnew.Enabled = true;
                ////trnote.Visible = false;
                //btnAddnew.CssClass = "btn btn-xs btn-primary";
            }
            dsResult = null;
            Session["dtResult"] = null;
            #endregion
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
    //Added by Rahul on 22-04-2015 for Retrieval Grid end
    //start added by sanoj 23052022
    public DataSet DocGridBind()
    {
        Hashtable htParam = new Hashtable();
        DataSet dsResult = new DataSet();
        htParam.Add("@Memcode", txtMemberCode.Text.ToString().Trim());
        htParam.Add("@EmpCode", txtFrenchCode.Text.ToString().Trim());
        htParam.Add("@BranchCode", "");
        htParam.Add("@CndName", txtGivenName.Text.ToString().Trim());
        htParam.Add("@Surname", txtSurname.Text.ToString().Trim());
        htParam.Add("@PAN", txtPan.Text.ToString().Trim());
        htParam.Add("@ReqDate", "");
        htParam.Add("@RecruiterName", "");
        htParam.Add("@BranchName", txtBranchName.Text.ToString().Trim());
        if (txtDTRegFrom.Text.Trim() != "")
        {
            htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("dd/MM/yyyy"));
        }
              
        else
        {
            htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
        }
        if (txtDTRegTo.Text.Trim() != "")
        {
            htParam.Add("@CreateToDtim",   DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("dd/MM/yyyy"));
          
        }
        else
        {
            htParam.Add("@CreateToDtim ", System.DBNull.Value);
        }
        htParam.Add("@AgentSapCode ", txtFrenchSap.Text.ToString().Trim());

        //htParam.Add("@Flag", "");  


        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFPSponsorshipAndQCCandidates", htParam); 
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            if(dsResult.Tables[0].Rows.Count <= 2)
            {
                btndocNext.Enabled = false;//added by sanoj 22052023
                btndocsPrev.Enabled = false;//added by sanoj 22052023
                txtPage2.Text = "1";//added by sanoj 22052023
            }
            gvDocs.DataSource = dsResult;
            gvDocs.DataBind();

        }
        ShowPageInformation1();
        return dsResult;

    }

    protected void gvDocs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "click")
        {
            DataSet dscount = new DataSet();

            string cndno = e.CommandArgument.ToString().Trim();
            string strresult = string.Empty;
            string strnm = string.Empty;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblname = (Label)row1.FindControl("lblLegalName");
            strnm = lblname.Text.ToString().Trim();
            strresult = "Documents Not Available of " + strnm;
            Hashtable htParam = new Hashtable();
            htParam.Add("@MemCode", cndno);//30027336 @CndNo
                                           //dscount = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetMemDocType", htParam);
            dscount = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
            if (dscount != null)
            {
                if (dscount.Tables.Count > 0)
                {
                    if (dscount.Tables[0].Rows.Count > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDoc('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDocs('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);

                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
                return;
            }
        }

    }
    //Ended added by sanoj 23052022
    //Added by sanoj 22052023
    protected void btndocsPrev_Click(object sender, EventArgs e)
    {
        int pageIndex = gvDocs.PageIndex;
        gvDocs.PageIndex = pageIndex - 1;
        DocGridBind();
        txtPage2.Text = Convert.ToString(Convert.ToInt32(txtPage2.Text) - 1);
        if (txtPage2.Text == "1")
        {
            btndocsPrev.Enabled = false;
        }
        else
        {
            btndocsPrev.Enabled = true;
        }
        btndocNext.Enabled = true;
    }

    protected void btndocNext_Click(object sender, EventArgs e)
    {
        int pageIndex = gvDocs.PageIndex;
        gvDocs.PageIndex = pageIndex + 1;
        DocGridBind();
        txtPage2.Text = Convert.ToString(Convert.ToInt32(txtPage2.Text) + 1);
        btndocsPrev.Enabled = true;
        int page = gvDocs.PageCount;
        if (txtPage2.Text == Convert.ToString(gvDocs.PageCount))
        {
            btndocNext.Enabled = false;
        }
    }
    //Endded by sanoj 22052023
    protected void gvDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataSet ds= DocGridBind();
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;
            gvDocs.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];
            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }
            gvDocs.DataSource = dv;
            gvDocs.DataBind();
            ShowPageInformation1();
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
    #region dgView Show Page Information for GridView
    public void ShowPageInformation1()
    {
        int intPageIndex = gvDocs.PageIndex + 1;
        lblPageInfo1.Text = "Page " + intPageIndex.ToString() + " of " + gvDocs.PageCount;
    }
    #endregion

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["type"] != null)
            {
            if (Request.QueryString["Type"].Trim() == "CndStat")
            {
                int pageIndex = GridCndStatus.PageIndex;
                GridCndStatus.PageIndex = pageIndex - 1;
                BindDataGrid();
                txtStatus.Text = Convert.ToString(Convert.ToInt32(txtStatus.Text) - 1);
                if (txtStatus.Text == "1")
                {
                    btnPreStatus.Enabled = false;
                }
                else
                {
                    btnPreStatus.Enabled = true;
                }
                btnNextStatus.Enabled = true;
            }
        // else if  Request.QueryString["Type"].Trim() == "FPWelcmLttr" 
               else if (Request.QueryString["Type"].Trim() == "FPWelcmLttr" )
            {
                int pageIndex = GrdLicId.PageIndex;
                GrdLicId.PageIndex = pageIndex - 1;
                    BindLICID();
                
                txtLICId.Text = Convert.ToString(Convert.ToInt32(txtLICId.Text) - 1);
                if (txtLICId.Text == "1")
                {
                    btnPreLICId.Enabled = false;
                }
                else
                {
                    btnPreLICId.Enabled = true;
                }
                btnNextLICId.Enabled = true;

            }
        }
            else
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                BindDataGrid();

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
                //int pageIndex = dgDetails.PageIndex;
                //dgDetails.PageIndex = pageIndex - 1;
                //BindDataGrid();


                //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                //btnprevious.Enabled = true;
                //int page = dgDetails.PageCount;
                //if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                //{
                //    btnnext.Enabled = false;
                //}
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["type"] != null)
            {

                if (Request.QueryString["Type"].Trim() == "CndStat")
                {
                    int pageIndex = GridCndStatus.PageIndex;
                    GridCndStatus.PageIndex = pageIndex + 1;
                    BindDataGrid();
                    txtStatus.Text = Convert.ToString(Convert.ToInt32(txtStatus.Text) + 1);
                    btnPreStatus.Enabled = true;
                    int page = GridCndStatus.PageCount;
                    if (txtStatus.Text == Convert.ToString(GridCndStatus.PageCount))
                    {
                        btnNextStatus.Enabled = false;
                    }
                }
                else if (Request.QueryString["Type"].Trim() == "FPWelcmLttr")
                {
                    int pageIndex = dgDetails.PageIndex;
                    GrdLicId.PageIndex = pageIndex + 1;

                    
                    BindLICID();

                    txtLICId.Text = Convert.ToString(Convert.ToInt32(txtLICId.Text) + 1);
                    btnPreLICId.Enabled = true;
                    int page = GrdLicId.PageCount;
                    if (txtLICId.Text == Convert.ToString(GrdLicId.PageCount))
                    {
                        btnNextLICId.Enabled = false;
                    }
                }
            }
            else
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                BindDataGrid();


                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                int page = dgDetails.PageCount;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnnext.Enabled = false;
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



    #region PopulateExmBodyName() ajay yadav 10-03-2023
    private void PopulateExmBodyName()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_get_Memtype");
            ddlmemtype.DataSource = dsresult;
            ddlmemtype.DataTextField = "MemTypeDesc03";
            ddlmemtype.DataValueField = "MemTypeDesc03"; 
            ddlmemtype.DataBind();
            dsresult = null;
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

  
    //changes related RF memtype by ajay 07 may 2023
    public void getcolor()
    {
        if(Request.QueryString["MemType"] != null)
        {
            if (Request.QueryString["MemType"].ToString().Trim() == "RF")
            {
            ddlmemtype.Attributes["style"] = "border-color: red";
            }
            else
            {
                ddlmemtype.Attributes["style"] = "border-color: #ced4da"; 
            }
        }
    }
}



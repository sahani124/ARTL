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
using DataAccessClassDAL;//added by rachana on 2012014 as new class file introduced
using CLTMGR;

public partial class Application_INSC_Recruit_PopRaiseCFR : BaseClass
{
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    //Added by rachana 2-08-2013
    //DataSet dsResult = new DataSet();
    string strFlag = string.Empty;
    string strddltext = string.Empty;
    string strDocId = string.Empty;//01
    string strDocCode = string.Empty;//pranjali
    string strddltext1 = string.Empty;
    string strddlseltext = string.Empty;
    DataSet dsResult = new DataSet();
    DataSet dsResult1 = new DataSet();
    Hashtable ht = new Hashtable();
    string strdocCode = string.Empty;
    string StrP1DoccodeNo = string.Empty;
    string StrP2DoccodeNo = string.Empty;
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    private DataAccessClass dataAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    //Added by rachana 2-08-2013
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"].ToString().Trim() == "Others")
            {
                strFlag = "Others";
            }
            if (Request.QueryString["FlagCode"].ToString().Trim() == "Trnsfr")
            {
                string IRDATrnsfrReqNo = Request.QueryString["TransfrReqNo"].ToString().Trim();
                ViewState["IRDATrnsfrReqNo"] = IRDATrnsfrReqNo;
            }
            else if (Request.QueryString["FlagCode"].ToString().Trim() != "Trnsfr")
            {
                ViewState["IRDATrnsfrReqNo"] = "";
            }
            else
            {
               
            }
            String ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            //string IRDATrnsfrReqNo = Request.QueryString["TransfrReqNo"].ToString().Trim();
            //ViewState["IRDATrnsfrReqNo"] = IRDATrnsfrReqNo;
            //Added by rachana to autopopulate grid,ddl on page load start
            if (!IsPostBack)
            {
                //GridView1.DataBind();

                bindGridview();
                GridView1.DataSource = dsResult.Tables[0];
                GridView1.DataBind();
                //commented by pranjali on 03-04-2014 start
                //if (Session["UserID"].ToString().Trim() == "admin")//User is admin
                //{
                //    strddltext = Request.QueryString["args3"].ToString();
                //    strDocId = Request.QueryString["args4"].ToString();//01

                //}
                //else//other user
                //{
                //commented by pranjali on 03-04-2014 end
                if (strFlag != "Others")
                {
                      strddltext = Request.QueryString["args3"].ToString();
                }
                    //strDocId = Request.QueryString["args4"].ToString();//01
                    strDocCode = Request.QueryString["args5"].ToString();//pranjali
                //}
                  
                BindDataGrid();

            }
            tr_title.Visible = true;
            BindLabels();
            if (strFlag != "Others")
            {
                DdlDoctype1.Enabled = false;  //comented by sanoj 11102022
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

    protected void FillDropDown()
    {
        try
        {
            //Added by pranjali on 14-02-2014 for fetching the candidate type start
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
            //Added by pranjali on 14-02-2014 for fetching the candidate type end
            //Added by rachana 6-08-2013 start

            //added by pranjali on 09-04-2014 start
            DataSet dslic = new DataSet();
            Hashtable htlic = new Hashtable();
            htlic.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dslic = dataAccess.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htlic);//added by pranjali on 14-03-2014 start
            if (dslic.Tables[0].Rows.Count > 0)
            {
                string RenewalFlag = dslic.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                string InsRenewalType = dslic.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                string OthrTrnComp = dslic.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                string EnbNxtRenwal = dslic.Tables[0].Rows[0]["EnbNxtRenwal"].ToString().Trim();
                if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {

                    //ht.Add("@RenwlFlag", RenewalFlag);
                    ht.Add("@InsurerType", InsRenewalType);
                    //ht.Add("@ReExmFlag", "N");
                    ht.Add("@ProcessType", "RW");
                    if (dslic.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
                    {
                        //ht.Add("@ModuleCode", "Tcc");
                    }
                    else
                    {
                        ht.Add("@ModuleCode", "Spon");
                    }
                }
                else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //ht.Add("@RenwlFlag", "N");
                    ht.Add("@InsurerType", "");
                    //ht.Add("@ReExmFlag", "N");
                    ht.Add("@ProcessType", "RE");
                    ht.Add("@ModuleCode", "Spon");
                }
                else
                {
                    ht.Add("@InsurerType", "");
                    ht.Add("@ModuleCode", "Spon");
                    if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        ht.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        ht.Add("@ProcessType", "NR");
                    }
                }
            }
            ht.Add("@CandType", dscandtype.Tables[0].Rows[0]["CandType"].ToString());
            //dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetDDLQuallityChk", ht); //added by pranjali on 09-04-2014 for change in procedure name
            if (dslic.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
            {
                dsResult = dataAccess.GetDataSetForPrcRecruits("Prc_GetDDLQC_Tcc", ht);
            }
            else
            {
                dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetDDLQuallityChk", ht);
            }
            if (dsResult.Tables.Count > 0)
            {
                DdlDoctype1.DataSource = dsResult;
                DdlDoctype1.DataTextField = "docdesc01";
                DdlDoctype1.DataValueField = "DocCode";
            }
            DdlDoctype1.Items.Insert(0, new ListItem("Select", ""));
            DdlDoctype1.DataBind();
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
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        
        int BranchCount = dgDetails.Rows.Count;  
        string StrCFRRemark = "";
        int count = 0;
        try
        {
            Hashtable htable = new Hashtable();
            GridViewRow[] ApprovalArray = new GridViewRow[dgDetails.Rows.Count];
            dgDetails.Rows.CopyTo(ApprovalArray, 0);
            foreach (GridViewRow row in ApprovalArray)
            {
                CheckBox ChkRaiseCFR = (CheckBox)row.FindControl("ChkRaise");
                Label lblRemark = (Label)row.FindControl("LblRemark");
                //TextBox  TxtRaiseCFR = (TextBox)row.FindControl("TxtRemark");
                TextBox TxtAddRemark = (TextBox)row.FindControl("TxtAddRemark");//Added by pranjali on 13-02-2014 for new added text in grid for additional remark
                Label LblAddRemark = (Label)row.FindControl("LblAddRemark");
                Label LblRemarkid = (Label)row.FindControl("LblRemarkid");//Added by pranjali on 13-02-2014 
                #region Checks for duplicate remark for same doc type

                Hashtable htparam = new Hashtable();
                dsResult.Clear();
                htparam.Add("@CndNo", Request.QueryString["CndNo"]);
                //htparam.Add("@CFRDesc", lblRemark.Text);
                htparam.Add("@CFRDesc", lblRemark.Text); //Added by pranjali on 13-02-2014 for checking duplicate remark for same doc type
                htparam.Add("@CFRFor", DdlDoctype1.SelectedItem.Text);
                dsResult = dataAccess.GetDataSetForPrcRecruits("Prc_ChkCFRRemarkExist", htparam);
                if (dsResult.Tables.Count > 0)//Added by rachana for validation of CFR raised 
                {
                 if (ChkRaiseCFR.Checked == true)
                 {
                     count++;
                     if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows[0]["remarkdesc01"].ToString() != "" || dsResult.Tables[0].Rows[0]["remarkdesc01"].ToString() == "")
                                {
                                    string cfrdesc = dsResult.Tables[0].Rows[0]["remarkdesc01"].ToString();
                                    if (lblRemark.Text == cfrdesc)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('CFR with same description already raised')", true);
                                        break;
                                    }
                                }

                            }
                     #endregion

                     // Hashtable htparam = new Hashtable();
                            htparam.Clear();
                            htparam.Add("@CndNo", Request.QueryString["CndNo"]);
                            //Added by rachana on 5-08-2013 for Prc_InsertCFRRemark_new has extra attribute start
                            htparam.Add("@Doccode", ViewState["Doccode"]);//DdlDoctype1.SelectedValue); //added viewstate instead of session by pranjali on 03-04-2014 start
                            //Added by rachana on 5-08-2013 for Prc_InsertCFRRemark_new has extra attribute end
                            # region commented
                            //Commented by pranjali on 13-02-2014 for not allowing label to be converted to text start

                            //if (TxtRaiseCFR.Visible == true)
                            //{
                            //    htparam.Add("@CFRDesc", TxtRaiseCFR.Text);
                            //    StrCFRRemark = StrCFRRemark + " " + TxtRaiseCFR.Text;
                            //    if (DdlDoctype1.SelectedItem.Text == "NOC DOCUMENT/ACKW")
                            //    {
                            //        string strText = StrCFRRemark;
                            //        string strNo = string.Empty;
                            //        int intTransferNo;
                            //        for (int i = 0; i < strText.Length; i++)
                            //        {
                            //            if (Char.IsDigit(strText[i]))
                            //                strNo += strText[i];
                            //        }
                            //        if (strNo.Length > 0)
                            //        {
                            //            intTransferNo = int.Parse(strNo);

                            //            htparam.Add("@CndTransferNo", intTransferNo);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            #endregion
                            //Commented by pranjali on 13-02-2014 for not allowing label to be converted to text end
                            htparam.Add("@CFRDesc", lblRemark.Text);
                            StrCFRRemark = StrCFRRemark + " " + lblRemark.Text;
                            //}
                            //Added by rachana 2-08-2013
                            htparam.Add("@Editable", "Y");//Editable
                            htparam.Add("@Createdby", Session["UserID"].ToString().Trim()); //added viewstate instead of session by pranjali on 03-04-2014 start
                            //htparam.Add("@Createdby", "ADMIN");
                            htparam.Add("@CFRFOR", DdlDoctype1.SelectedItem.Text);
                            if (DdlDoctype1.SelectedItem.Text != "")
                            {
                                htparam.Add("@CFRRaised", 0);
                            }
                            else
                            {
                                htparam.Add("@CFRRaised", "");
                            }

                            if (TxtAddRemark.Visible == true)
                            {
                                htparam.Add("@AddRemark", TxtAddRemark.Text.Trim());
                            }
                            else
                            {
                                htparam.Add("@AddRemark", LblAddRemark.Text);
                            }
                            htparam.Add("@CFRRemarkID", LblRemarkid.Text);
                            Hashtable httype = new Hashtable();
                            DataSet dscandtype = new DataSet();
                            httype.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dscandtype = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", httype);

                            if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                            {
                               htparam.Add("@Flag", "NC");
                            }
                            else
                            {
                                if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                                {
                                    htparam.Add("@Flag", "RW");
                                }
                                else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                                {
                                    htparam.Add("@Flag", "RE");
                                }
                                else
                                {
                                    htparam.Add("@Flag", "NR");
                                }
                            }
                            dataAccess.execute_sprcrecruit("Prc_InsertCFRRemark_new", htparam);
                            //Added by rachana 2-08-2013
                            htparam.Clear();
                            //}
                        }
                
                
                    //}
                }
               

            }
            if (count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select  The CheckBox')", true);
                return;
            }
               
            bindGridview();//Added by rachana on 18122013 for binding GridView1
            GridView1.DataSource = dsResult.Tables[0];
            GridView1.DataBind();
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                BtnSubmit.Enabled = true;
            }
            else
            {
                BtnSubmit.Enabled = false;
            }
            //updating in licrentccsu...start
            //Hashtable htCFRLic = new Hashtable ();
            //htCFRLic.Add ("@CFRRemark", StrCFRRemark );
            //htCFRLic.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            //htCFRLic.Add ("@Doctype", DdlDoctype1.SelectedValue );
            //htCFRLic.Add("@CFRCreatedby", Request.QueryString["UserId"].ToString());            
            //dataAccess.execute_sprcrecruit("Prc_UpdLicrentccsu", htCFRLic);
            //updating in licrentccsu...end
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.Message;
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //protected override void Render(HtmlTextWriter writer)
    //{
    //    try
    //    {
    //        foreach (GridViewRow r in dgDetails.Rows)
    //        {
    //            if (r.RowType == DataControlRowType.DataRow)
    //            {
    //                for (int columnIndex = 0; columnIndex <
    //                    r.Cells.Count; columnIndex++)
    //                {
    //                    Page.ClientScript.RegisterForEventValidation(
    //                        r.UniqueID + "$ctl00", columnIndex.ToString());
    //                }
    //            }
    //        }

    //        base.Render(writer);
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Visible = true;
    //        lblmsg.Text = ex.Message;
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    protected void BindLabels()
    {
        try
        {
            DataSet dscount = new DataSet();
            Hashtable htcount = new Hashtable();
            DataSet dscountlabel = new DataSet();
            htcount.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            dscountlabel = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", htcount);
            if (dscountlabel.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
            {
                htcount.Add("@Flag", "NC");
            }
            else
            {
                if (dscountlabel.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    htcount.Add("@Flag", "RW");
                }
                else if (dscountlabel.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    htcount.Add("@Flag", "RE");
                }
                else
                {
                    htcount.Add("@Flag", "NR");
                }
            }

            dscount = dataAccess.GetDataSetForPrcRecruit("Prc_GetcountFor_bracheduser", htcount);


            lblcfrraisedcount.Text = dscount.Tables[0].Rows[0]["Raised"].ToString();
            lblcfrrespondcount.Text = dscount.Tables[1].Rows[0]["Responded"].ToString();
            lblcfrclosed.Text = dscount.Tables[2].Rows[0]["Closed"].ToString();
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
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnDocCode = (HiddenField)e.Row.FindControl("hdnDocCode");
                strdocCode = hdnDocCode.Value;
                ViewState["Doccode"] = hdnDocCode.Value;



                //// Get the LinkButton control in the first cell
                //LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                //// Get the javascript which is assigned to this LinkButton
                //string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");

                //// Add events to each editable cell
                //for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                //{
                //    // Add the column index as the event argument parameter
                //    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                //    // Add this javascript to the onclick Attribute of the cell
                //    e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                //    // Add a cursor style to the cells
                //    e.Row.Cells[columnIndex].Attributes["style"] +=
                //        "cursor:pointer;cursor:hand;";
                //}
                //HiddenField hdnDocCode = (HiddenField)e.Row.FindControl("hdnDocCode");
                //strdocCode = hdnDocCode.Value;
                //ViewState["Doccode"] = hdnDocCode.Value;//added viewstate instead of session by pranjali on 03-04-2014 start
                //TextBox TxtAddRemark = (TextBox)e.Row.FindControl("TxtAddRemark");
                //if (ViewState["IRDATrnsfrReqNo"] != "")
                //{
                //    TxtAddRemark.Text = TxtAddRemark.Text + "(" + ViewState["IRDATrnsfrReqNo"] + ")";
                //}
                //else
                //{
                //    TxtAddRemark.Text = TxtAddRemark.Text + ViewState["IRDATrnsfrReqNo"];
                //}
                ////added by sanoj 15022023
                //Label lblAddnlRemark1 = (Label)e.Row.FindControl("LblRemark");
                //if (lblAddnlRemark1.Text.Length > 72)
                //{
                //    e.Row.Cells[2].Attributes.Add("style", "white-space:initial;");
                //}
                ////endde by sanoj 15022023
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
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //if (e.CommandName == "SingleClick")
            //{
            //    int _rowIndex = int.Parse(e.CommandArgument.ToString());
            //    int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);

            //    // Get the display control for the selected cell and make it invisible
            //    Control _displayControl = dgDetails.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
            //    _displayControl.Visible = false;
            //    // Get the edit control for the selected cell and make it visible

            //    if (_displayControl is CheckBox)
            //    {
            //        Control _displayControl1 =
            //         dgDetails.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
            //       // ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('amu');", true);
            //        _displayControl.Visible = true;
            //    }
            //    else
            //    {
            //        //Added by pranjali on 13-02-2014 for making CFR Remarks column as static start
            //        if (Convert.ToString(_columnIndex) == "2")
            //        {
            //            Control _displayControl1 = dgDetails.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
            //            //ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('amu1');", true);
            //            _displayControl1.Visible = true;
            //        }
            //        //Added by pranjali on 13-02-2014 for making CFR Remarks column as static end
            //        else
            //        {
            //            Control _editControl =
            //                dgDetails.Rows[_rowIndex].Cells[_columnIndex].Controls[4];
            //            //ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('"+_editControl+"');", true);
            //            _editControl.Visible = true;
                        
            //            // Clear the attributes from the selected cell to remove the click event
            //            dgDetails.Rows[_rowIndex].Cells[_columnIndex].Attributes.Clear();
            //        }
            //    }
            //}
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

    protected void dgDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            for (int i = 1; i < dgDetails.Columns.Count; i++)
            {
                Control _editControl = dgDetails.Rows[e.RowIndex].Cells[i].Controls[3];
                if (_editControl.Visible)
                {

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

    protected void DdlDoctype1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strddlseltext = DdlDoctype1.SelectedItem.Text.Trim(); //Added by rachana on 6-08-2013 for DDL text to be selected  
            //strDocId = DdlDoctype1.SelectedItem.Value.Trim();//01
            //ViewState["strDocId"] = strDocId; //added viewstate instead of session by pranjali on 03-04-2014 start
            strDocCode = DdlDoctype1.SelectedItem.Value.Trim();//01
            ViewState["strDocId"] = strDocCode; 
            BindDataGrid();
            DdlDoctype1.SelectedItem.Text = strddlseltext; //Added by rachana on 6-08-2013 for DDL options to be selected
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

    protected void 
        BindDataGrid()
    {
        try
        {
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
            //Added by rachana 6-08-2013 start
            ht.Clear();
           //ht.Add("@CandType", dscandtype.Tables[0].Rows[0]["CandType"].ToString());
            //added by pranjali on 09-04-2014 start
            DataSet dslic = new DataSet();
            Hashtable htlic = new Hashtable();
            htlic.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dslic = dataAccess.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htlic);//added by pranjali on 14-03-2014 start
            if (dslic.Tables[0].Rows.Count > 0)
            {
                string RenewalFlag = dslic.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                string InsRenewalType = dslic.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                string OthrTrnComp = dslic.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                string EnbNxtRenwal = dslic.Tables[0].Rows[0]["EnbNxtRenwal"].ToString().Trim();
                string ProcessType = dslic.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
                if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                    {
                        ht.Add("@InsurerType", "");
                        //ht.Add("@ReExmFlag", "N");
                        ht.Add("@ProcessType", "NC");
                       // ht.Add("@ModuleCode", "Spon");
                    }
                    else
                    {
                        //ht.Add("@RenwlFlag", RenewalFlag);
                        ht.Add("@InsurerType", InsRenewalType);
                        //ht.Add("@ReExmFlag", "N");
                        ht.Add("@ProcessType", "RW");
                    }

                    if (dslic.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
                    {
                        if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                        {
                            ht.Add("@ModuleCode", "NOC");
                        }
                        else
                        {
                            //ht.Add("@ModuleCode", "Tcc");
                        }
                    }
                    else
                    {
                        if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                        {
                            ht.Add("@ModuleCode", "NOC");
                        }
                        else
                        {
                            ht.Add("@ModuleCode", "Spon");
                        }
                    }
                }
                else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //ht.Add("@RenwlFlag", "N");
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                    {
                        ht.Add("@InsurerType", "");
                        //ht.Add("@ReExmFlag", "N");
                        ht.Add("@ProcessType", "NC");
                        ht.Add("@ModuleCode", "NOC");
                    }
                    else
                    {
                        ht.Add("@InsurerType", "");
                        //ht.Add("@ReExmFlag", "N");
                        ht.Add("@ProcessType", "RE");
                        ht.Add("@ModuleCode", "Spon");
                    }
                }
                else if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                {
                    ht.Add("@InsurerType", "");
                    //ht.Add("@ReExmFlag", "N");
                    ht.Add("@ProcessType", "NC");
                    ht.Add("@ModuleCode", "NOC");
                }
                else
                {
                    ht.Add("@InsurerType", "");
                    ht.Add("@ModuleCode", "Spon");
                    if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        ht.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        ht.Add("@ProcessType", "NR");
                    }
                }
            }
            //added by pranjali on 09-04-2014 end
            ht.Add("@CandType", dscandtype.Tables[0].Rows[0]["CandType"].ToString());
            //dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetDDLQuallityChk", ht);//added by pranjali on 09-04-2014 for change in procedure name
           
                if (dslic.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
                {
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() != "NC")
                    {
                    dsResult = dataAccess.GetDataSetForPrcRecruits("Prc_GetDDLQC_Tcc", ht);
                    }
                }
            else
            {
                if (strFlag == "Others")
                {
                    DdlDoctype1.Enabled = true;
                    ht.Add("@Flag",1);
                }
                ht.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ht.Add("@DocCode", Request.QueryString["args5"].ToString().Trim());
                dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetDDLQuallityChk", ht);
            } 
            if (dsResult.Tables.Count > 0)
            {

                DdlDoctype1.DataSource = dsResult;
                DdlDoctype1.DataTextField = "docdesc01";
                DdlDoctype1.DataValueField = "DocCode";
            }

            DdlDoctype1.DataBind();
            DdlDoctype1.Items.Insert(0, new ListItem("Select", ""));
            //dgDetails.PageSize = 10;

            #region compare and remove same value from ddl when page opens start
            Hashtable htParam = new Hashtable();
            string doctype = string.Empty;
            if (strddltext != "")
            {
                doctype = strddltext;
                DdlDoctype1.SelectedItem.Text = strddltext;
                if (DdlDoctype1.Items.Count > 0)
                {
                    for (int i = 1; i < DdlDoctype1.Items.Count; i++)
                    {
                        if (strddltext == DdlDoctype1.Items[i].Text)
                        {

                            DdlDoctype1.Items.RemoveAt(i);
                        }

                    }
                }
            }
            else
            {
                doctype = DdlDoctype1.SelectedItem.Text.Trim();
            }
            if (strddltext == "")//when option selected from Dropdown of document removes same value from dropdown
            {

                //doctype = strddlseltext;

                //DdlDoctype1.SelectedItem.Text = strddlseltext;
                DdlDoctype1.SelectedItem.Text = doctype;
                if (DdlDoctype1.Items.Count > 0)
                {
                    for (int i = 1; i < DdlDoctype1.Items.Count; i++)
                    {
                        if (strddlseltext == DdlDoctype1.Items[i].Text)
                        {

                            DdlDoctype1.Items.RemoveAt(i);
                        }

                    }

                }
            }
            #endregion
            Hashtable httable1 = new Hashtable();
            DataSet dscandtype1 = new DataSet();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype1 = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);

            dsResult.Clear();
            //Added by rachana 6-08-2013 end
            //htParam.Add("@ddlDoctype", strDocId);//01
           // htParam.Add("@ddlDoctype", doctype);//pranjali
 htParam.Add("@ddlDoctype", strDocCode);
            htParam.Add("@CandType", dscandtype1.Tables[0].Rows[0]["CandType"].ToString());
            //htParam.Add("@CndNo", Request.QueryString["CndNo"]);
            //Added by rachana 2-08-2013   
  
            //added by pranjali on 09-04-2014 start
            DataSet dslicdtl = new DataSet();
            Hashtable htlicdtl = new Hashtable();
            htlicdtl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dslicdtl = dataAccess.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htlicdtl);//added by pranjali on 14-03-2014 start
            if (dslicdtl.Tables[0].Rows.Count > 0)
            {
                string RenewalFlag = dslicdtl.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                string InsRenewalType = dslicdtl.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                string OthrTrnComp = dslicdtl.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                string EnbNxtRenwal = dslicdtl.Tables[0].Rows[0]["EnbNxtRenwal"].ToString().Trim();
                if (dscandtype1.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() != "NC")
                    {
                        //htParam.Add("@RenwlFlag", RenewalFlag);
                        htParam.Add("@InsurerType", InsRenewalType);
                        htParam.Add("@ProcessType", "RW");
                    }
                    else
                    {
                         htParam.Add("@InsurerType", "");
                        htParam.Add("@ProcessType", "NC");
                    
                    }
                }
                else if (dscandtype1.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() != "NC")
                    {
                        //htParam.Add("@RenwlFlag", "N");
                        htParam.Add("@InsurerType", "");
                        htParam.Add("@ProcessType", "RE");
                    }
                    else
                    {
                       
                         htParam.Add("@InsurerType", "");
                        htParam.Add("@ProcessType", "NC");
                    }

                    

                }
                else
                {
                    htParam.Add("@InsurerType", "");
                    if (dscandtype.Tables[0].Rows[0]["ProcessType"].ToString().Trim() != "NC")
                    {
                        if (dscandtype1.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                        {
                            htParam.Add("@ProcessType", "SP");
                        }
                        else
                        {
                            htParam.Add("@ProcessType", "NR");
                        }
                    }

                    else {
                        htParam.Add("@ProcessType", "NC");
                    }
                }
            }
            //added by pranjali on 09-04-2014 end

            dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetCFRRemark", htParam);//added by pranjali on 09-04-2014 for change in procedure name
            //dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetCFRRemark", htParam);
            //Added by rachana 2-08-2013
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();

                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();

                }
            }
            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();

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
    //Added by rachana on 06-08-2013 to allow pageindexing on both Grids start
    #region dgDetails dgDetails_PageIndexChanging
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = binddgDetails();
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
    #region binddgDetails()
    protected DataTable binddgDetails()
    {
        try
        {
            Hashtable httable12 = new Hashtable();
            DataSet dscandtype12 = new DataSet();
            httable12.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype12 = dataAccess.GetDataSetForPrcRecruit("Prc_GetCandType", httable12);

            //dsResult.Clear();
            ////Added by rachana 6-08-2013 end
            //htParam.Add("@ddlDoctype", strDocId);//01
            //htParam.Add("@CandType", dscandtype1.Tables[0].Rows[0]["CandType"].ToString());
            Hashtable htParam = new Hashtable();
            string doctype = string.Empty;
            doctype = DdlDoctype1.SelectedItem.Text.Trim();
            strDocId = ViewState["strDocId"].ToString(); //added viewstate instead of session by pranjali on 03-04-2014 start
            dsResult.Clear();
            //htParam.Add("@CndNo", Request.QueryString["CndNo"]);
            htParam.Add("@ddlDoctype", strDocId);//01
            htParam.Add("@CandType", dscandtype12.Tables[0].Rows[0]["CandType"].ToString());
            //added by pranjali on 09-04-2014 start

            DataSet dslicdtl = new DataSet();
            Hashtable htlicdtl = new Hashtable();
            htlicdtl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dslicdtl = dataAccess.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htlicdtl);//added by pranjali on 14-03-2014 start
            if (dslicdtl.Tables[0].Rows.Count > 0)
            {
                string RenewalFlag = dslicdtl.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                string InsRenewalType = dslicdtl.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                string OthrTrnComp = dslicdtl.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                string EnbNxtRenwal = dslicdtl.Tables[0].Rows[0]["EnbNxtRenwal"].ToString().Trim();
                if (dscandtype12.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    //htParam.Add("@RenwlFlag", RenewalFlag);
                    htParam.Add("@InsurerType", InsRenewalType);
                    htParam.Add("@ProcessType", "RW");
                }
                else if (dscandtype12.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //htParam.Add("@RenwlFlag", "N");
                    htParam.Add("@InsurerType", "");
                    htParam.Add("@ProcessType", "RE");
                }
                else
                {
                    htParam.Add("@InsurerType", "");
                    if (dscandtype12.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htParam.Add("@ProcessType", "NR");
                    }
                }
            }
            //added by pranjali on 09-04-2014 end

            //Added by rachana 2-08-2013         
            //dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetCFRRemark", htParam);
            dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetCFRRemark", htParam);//added by pranjali on 09-04-2014 for change in procedure name
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
        return dsResult.Tables[0];
    }
    #endregion
    #region GridView1_PageIndexChanging
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = bindGridview();
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
    #region bindGridview()
    protected DataTable bindGridview()
    {
        try
        {
            dsResult.Clear();
            Hashtable htParamgrid = new Hashtable();
            htParamgrid.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParamgrid.Add("@DocCode", Request.QueryString["args5"].ToString());

            dsResult = dataAccess.GetDataSetForPrcRecruits("prc_GetDataToBindGrid", htParamgrid);
            GridView1.Visible = true;
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
        return dsResult.Tables[0];
    }
    #endregion
    //Added by rachana on 06-08-2013 to allow pageindexing on both Grids end 

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            if (GridView1.Rows == null || GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please add CFR Remark')", true);
               
                return;
            }
            Hashtable htparam = new Hashtable();
            htparam.Add("@CndNo", Request.QueryString["CndNo"]);
            htparam.Add("@CFRRemark", txtRemrk.Text.Trim());
          
            
            //htparam.Add("@ID", Request.QueryString["ID"].ToString().Trim()); commented by DAKSH for POSP CFR Raise
            if (ViewState["IRDATrnsfrReqNo"] != "")  
            {
                htparam.Add("@TrnsfrReqNo", ViewState["IRDATrnsfrReqNo"]);
            }
            else
            {
                htparam.Add("@TrnsfrReqNo", System.DBNull.Value);
            }
            //dataAccessRecruit.execute_sprcrecruit("Prc_UpdateCFRstatus", htparam);

            htparam.Add("@Createdby", Session["UserID"].ToString().Trim());//added by sanoj 12102022
            htparam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());

            dataAccess.execute_sprcrecruit("Prc_UpdateCFRstatus", htparam);
            htparam.Clear();
            BindLabels();
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doSelect('" + Request.QueryString["args1"] + "','" + lblcfrraisedcount.Text.Trim() + "','" + lblcfrrespondcount.Text.Trim() + "','" + lblcfrclosed.Text.Trim() + "');</script>", false);
            
            
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doSelect('" + Request.QueryString["args1"] + "');</script>", false);
        }
        catch (Exception ex)
        {
           // lblmsg.Visible = true;
            lblmsg.Text = ex.Message;
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        bindGridview();
        GridView1.DataSource = dsResult.Tables[0];
        GridView1.DataBind();

        //Added by rachana on 19122013 to hide popup on submit Click start
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "show", "<script type='text/javascript'>doCancel();</script>", false);

        txtRemrk.Text = "";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('CFR raised successfully');", true);
        //return;
        //Added by rachana on 19122013 to hide popup on submit Click end
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {


       
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //HiddenField RemarkId1 = (HiddenField)e.Row.FindControl("hdnid");
                ViewState["RemarkId"] = e.Row.Cells[2].Text; //added viewstate instead of session by pranjali on 03-04-2014 start
                e.Row.Cells[2].Visible = false;
               Label LblRemark = (Label)e.Row.FindControl("RemarkId");
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                Label LblRemarkDesc01 = (Label)e.Row.FindControl("lblRemarkDesc01");
                Label lblCFRFor = (Label)e.Row.FindControl("lblCFRFor");
                Label lblAddnlRemark = (Label)e.Row.FindControl("lblAddnlRemark");

                




                if (LblRemarkDesc01.Text.Length >30)
                {
                   e.Row.Cells[0].Attributes.Add("style", "white-space:initial;");
                }
                if (lblCFRFor.Text.Length > 30)
                {
                    e.Row.Cells[1].Attributes.Add("style", "white-space:initial;");
                }
                if (lblAddnlRemark.Text.Length > 30)
                {
                    e.Row.Cells[3].Attributes.Add("style", "white-space:initial;");
                }


                l.Attributes.Add("onclick", "javascript:return confirm('Are You Sure You Want To Delete This Record?')");
                BtnSubmit.Enabled = true;
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
    //added by rachana on 2012014 for deletion on individual remark start
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
           // Label LblRemarkID = (Label)row.FindControl("RemarkId");
            try
            {
                
                ht.Clear();
                ht.Add("@CndNo", Request.QueryString["CndNo"]);
                //ht.Add("@RemarkId", Session["RemarkId"]);
               ht.Add("@RemarkId", row.Cells[2].Text.ToString());
               
                //int i = dataAccess.execute_sprc_inscRecurit("prc_DelCFRRemark", ht);
                int i = dataAccess.execute_sprc_inscRecurit("prc_DelCFRRemark", ht);


                bindGridview();
                GridView1.DataSource = dsResult.Tables[0];
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('CFR deleted successfully')", true);
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    //added by rachana on 2012014 for deletion on individual remark end

    
}

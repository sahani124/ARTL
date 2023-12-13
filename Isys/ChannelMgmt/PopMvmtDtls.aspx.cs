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
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_Isys_ChannelMgmt_PopMvmtDtls : BaseClass
{
    #region Declaration
    DataSet dsResult = new DataSet();
    DataSet tempdsResult = new DataSet();
    Hashtable htable = new Hashtable();
    CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();
    int currentRow = 0;
    DataAccessClass objDAL = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                 
                //oCommon.getDropDown(ddlMKCHKR, "MVMTREQAPPR", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                //ddlMKCHKR.Items.Insert(0, new ListItem("Select", ""));

                if (Request.QueryString["mvmtrule"] != null)
                {
                    if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                    {
                        //lblmvmthdr.Text = "Transfer Movement Rule Details";

                        lblmvmthdr.Text = "TRANSFER MOVEMENT RULE DETAILS";
                        FillTrfTyp("trfType", rblTrfTyp);
                        divmkchkrtrf.Visible = true;
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "TR")
                    {
                        //lblmvmthdr.Text = "Termination Movement Rule Details";
                        lblmvmthdr.Text = "TERMINATION MOVEMENT RULE DETAILS";
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "IS")
                    {
                        //lblmvmthdr.Text = "Reinstatement Movement Rule Details";
                        lblmvmthdr.Text = "REINSTATEMENT MOVEMENT RULE DETAILS";
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "PRM")
                    {
                        //lblmvmthdr.Text = "Promotion Movement Rule Details";
                        lblmvmthdr.Text = "PROMOTION MOVEMENT RULE DETAILS";
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "DEM")
                    {
                        //lblmvmthdr.Text = "Demotion Movement Rule Details";
                        lblmvmthdr.Text = "DEMOTION MOVEMENT RULE DETAILS";
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "CR")
                    {
                        //lblmvmthdr.Text = "Creation Movement Rule Details";
                        lblmvmthdr.Text = "CREATION MOVEMENT RULE DETAILS";
                    }
                    else if (Request.QueryString["mvmtrule"].ToString().Trim() == "MD")
                    {
                        //lblmvmthdr.Text = "Modification Movement Rule Details";
                        lblmvmthdr.Text = "MODIFICATION MOVEMENT RULE DETAILS";
                    }
                }

                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "V")
                    {
                        #region View
                        btnUpdate.Visible = false;
                        btnAddNew.Visible = false;
                        GetMvmtType();
                        BindCheckers();
                        FillGrid();/////view the maker checker details
                        MakerDetails.Columns[5].Visible = false;
                        MakerDetails.Columns[6].Visible = false;
                        chkMaker.Enabled = false;
                        if (Request.QueryString["mvmtrule"] != null)
                        {
                            if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                            {
                                try
                                {
                                    ShowTrfType();
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
                        for (int i = 0; grdMKCHKR.Rows.Count > i; i++)
                        {
                            DropDownList ddlmvmtchn = grdMKCHKR.Rows[i].FindControl("ddlmvmtchn") as DropDownList;
                            DropDownList ddlmvmtsubcls = grdMKCHKR.Rows[i].FindControl("ddlmvmtsubcls") as DropDownList;
                            DropDownList ddlmvmtbsdon = grdMKCHKR.Rows[i].FindControl("ddlmvmtbsdon") as DropDownList;
                            DropDownList ddlmvmtlvlagttyp = grdMKCHKR.Rows[i].FindControl("ddlmvmtlvlagttyp") as DropDownList;
                            RadioButtonList rblType = grdMKCHKR.Rows[i].FindControl("rblType") as RadioButtonList;

                        }
                        chkChecker.Enabled = false;
                        ddlnochkrs.Enabled = false;
                        rblTrfTyp.Enabled = false;
                        #endregion
                    }
                }

                if (Request.QueryString["btn"] != null)
                {
                    if (Request.QueryString["btn"].ToString().Trim() == "EMV")
                    {
                        
                        btnUpdate.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color:White'> </span> Update";
                        GetMvmtType();
                        BindCheckers();                    
                        FillGrid();
                        ////view the maker checker details in edit mode
                        if (Request.QueryString["mvmtrule"] != null)
                        {
                            if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                            {
                                ShowTrfType();
                            }
                        }
                    }
                }

                if (Session["MvmtDetails"] != null)
                {
                    if (!chkMaker.Checked)
                        FillGrid();
                }

                if (Session["NoOfCheckers"] != null)
                {
                    string noOfCheckers = Session["NoOfCheckers"].ToString();
                    if (noOfCheckers != "")
                    {
                        chkChecker.Checked = true;
                        VisibleChecker();
                    }
                    ddlnochkrs.SelectedValue = noOfCheckers;
                    BindGrid(noOfCheckers);                
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

    }

    private void BindCheckers()
    {
        if (Session["NoOfCheckers"] == null)
        {
            Session["NoOfCheckers"] = ddlnochkrs.SelectedValue.Trim();
            var value = ddlnochkrs.SelectedValue.Trim();
            if (value != "")
            {
                chkChecker.Checked = true;
                VisibleChecker();
            }
            BindGrid(ddlnochkrs.SelectedValue.Trim());
        }
        else
        {
            string noOfCheckers = Session["NoOfCheckers"].ToString();

            if (noOfCheckers == "Select")
            {
                chkChecker.Checked = true;
                VisibleChecker();
                Session["NoOfCheckers"] = "";
            }
            else if (noOfCheckers != "")
            {
                chkChecker.Checked = true;
                VisibleChecker();
            }
            BindGrid(noOfCheckers);
        }  
    }

    protected void grdMKCHKR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var titleTxt = (Label)e.Row.FindControl("lblmvtitle");
                titleTxt.Text = "Checker " + (e.Row.RowIndex + 1) + " Details";
                GridView grdChkrDtls = (GridView)e.Row.FindControl("CheckerDetails");
                if (Request.QueryString["flag"].ToString().Trim() == "V")
                {
                    grdChkrDtls.Columns[5].Visible = false;
                    grdChkrDtls.Columns[6].Visible = false;

                }

                dsResult = fillchckrdtls(e.Row.RowIndex + 1);

                if (Request.QueryString["flag"].ToString().Trim() == "V")
                {
                   LinkButton lkbtn = (LinkButton)e.Row.FindControl("btnAddNewCh");
                   lkbtn.Visible = false;
                }
                string onClickTxt = "ShowReqDtl1('ctl00_ContentPlaceHolder1_grdMKCHKR_ctl0" + (e.Row.RowIndex + 2) + "_divMvmt','ctl00_ContentPlaceHolder1_grdMKCHKR_ctl0" + (e.Row.RowIndex + 2) + "_Span1');return false;";
                HtmlGenericControl div = ((HtmlGenericControl)e.Row.FindControl("div4"));
                div.Attributes.Add("onclick", onClickTxt);
                int noOfCheckers = Convert.ToInt32(Session["NoOfCheckers"]);
                if (noOfCheckers > e.Row.RowIndex)
                {
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            grdChkrDtls.DataSource = dsResult;
                            //Session["MvmtCheckerDetails"] = dsResult;         
                            grdChkrDtls.DataBind();
                        }
                        else
                        {
                            ShowNoResultFound(dsResult.Tables[0], grdChkrDtls);
                        }
                    }
                    else
                    {
                        ShowNoResultFound(dsResult.Tables[0], grdChkrDtls);
                    }
                }
                else
                {
                    ShowNoResultFound(dsResult.Tables[0], grdChkrDtls);
                    DataSet tempds = (DataSet)Session["MvmtCheckerDetails"];
                    DataView tempdv = new DataView(tempds.Tables[0]);
                    tempdv.RowFilter = "MvmtLvl <>" + e.Row.RowIndex + 1;
                    tempds = new DataSet();
                    tempds.Tables.Add(tempdv.ToTable());
                    Session["MvmtCheckerDetails"] = tempds;
                }
                //HiddenField hdnmvtitle = (HiddenField)e.Row.FindControl("hdnmvtitle");
                //Label lblmvtitle = (Label)e.Row.FindControl("lblmvtitle");
                //DropDownList ddlmvmtchn = (DropDownList)e.Row.FindControl("ddlmvmtchn");
                //objCommonU.GetSalesChannel(ddlmvmtchn, "", 1);
                //ddlmvmtchn.Items.Insert(0, new ListItem("Select", ""));
                //DropDownList ddlmvmtsubcls = (DropDownList)e.Row.FindControl("ddlmvmtsubcls");
                //ddlmvmtsubcls.Items.Insert(0, new ListItem("Select", ""));
                //DropDownList ddlmvmtbsdon = (DropDownList)e.Row.FindControl("ddlmvmtbsdon");
                //oCommon.getDropDown(ddlmvmtbsdon, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                //ddlmvmtbsdon.Items.Insert(0, new ListItem("Select", ""));
                //DropDownList ddlmvmtlvlagttyp = (DropDownList)e.Row.FindControl("ddlmvmtlvlagttyp");
                //ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
                //Label lblType = (Label)e.Row.FindControl("lblType");
                //RadioButtonList rblType = e.Row.FindControl("rblType") as RadioButtonList;
                //oCommon.getRadio(rblType, "UserTypes", Session["UserLangNum"].ToString(), "", 0);
                //if (Request.QueryString["btn"] != null)
                //{
                //    if (Request.QueryString["btn"].ToString().Trim() == "EMV")
                //    {
                //        rblType.SelectedValue = "I";
                //    }
                //}


                //HtmlGenericControl div4 = (HtmlGenericControl)e.Row.FindControl("div4");
                //if (hdnmvtitle.Value == "1")
                //{
                //    lblmvtitle.Text = "Checker" + " " + hdnmvtitle.Value + " " + "Details";
                //    lblType.Text = "Checker" + " " + hdnmvtitle.Value + " Type";
                //    div4.Attributes.Add("onclick", "ShowReqDtl1('ctl00_ContentPlaceHolder1_grdMKCHKR_ctl02_divMvmt','ctl00_ContentPlaceHolder1_grdMKCHKR_ctl02_Span1');return false;");
                //}
                //else if (hdnmvtitle.Value == "2")
                //{
                //    lblmvtitle.Text = "Checker" + " " + hdnmvtitle.Value + " " + "Details";
                //    lblType.Text = "Checker" + " " + hdnmvtitle.Value + " Type";
                //    div4.Attributes.Add("onclick", "ShowReqDtl1('ctl00_ContentPlaceHolder1_grdMKCHKR_ctl03_divMvmt','ctl00_ContentPlaceHolder1_grdMKCHKR_ctl03_Span1');return false;");
                //}

              //  dsResult.Clear();
               // htable.Clear();
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


    protected void CheckerDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        currentRow = e.Row.RowIndex;
        if (e.Row.RowType == DataControlRowType.DataRow) // Enables or Disables Edit button based on Delete btn text
        {
            Label lblerrmsg = e.Row.FindControl("lblerrmsg") as Label;
            LinkButton editBtn = e.Row.FindControl("EditBtn") as LinkButton;
            LinkButton deleteBtn = e.Row.FindControl("DeleteChecker") as LinkButton;
            Label LabelText = e.Row.FindControl("Label7") as Label;
            if (deleteBtn.Text != "Delete")
            {
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
            }
            editBtn.Text = "Edit";
            if (LabelText.Text == "")
            {
                lblerrmsg.Text = "No records found";
                lblerrmsg.Visible = true;
            }
        }
    }

    protected void ddlMKCHKR_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        //FillGrid(5);
    }

    protected void ddlmvmtchn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlmvmtchn = (DropDownList)row.FindControl("ddlmvmtchn");
            DropDownList ddlmvmtsubcls = (DropDownList)row.FindControl("ddlmvmtsubcls");
            DropDownList ddlmvmtbsdon = (DropDownList)row.FindControl("ddlmvmtbsdon");
            DropDownList ddlmvmtlvlagttyp = (DropDownList)row.FindControl("ddlmvmtlvlagttyp");
            objCommonU.GetUserChnclsChannel(ddlmvmtsubcls, ddlmvmtchn.SelectedValue, 0, HttpContext.Current.Session["UserID"].ToString().Trim());
            ddlmvmtsubcls.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtbsdon.SelectedValue = "";
            ddlmvmtlvlagttyp.Items.Clear();
            ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtchn.Focus();

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
    protected void ddlmvmtsubcls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlmvmtbsdon = (DropDownList)row.FindControl("ddlmvmtbsdon");
            ddlmvmtbsdon.SelectedValue = "";
            DropDownList ddlmvmtlvlagttyp = (DropDownList)row.FindControl("ddlmvmtlvlagttyp");
            ddlmvmtlvlagttyp.Items.Clear();
            ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
            /////ddlmvmtsubcls.Focus();
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
    protected void ddlmvmtbsdon_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlmvmtchn = (DropDownList)row.FindControl("ddlmvmtchn");
            DropDownList ddlmvmtsubcls = (DropDownList)row.FindControl("ddlmvmtsubcls");
            DropDownList ddlmvmtbsdon = (DropDownList)row.FindControl("ddlmvmtbsdon");
            DropDownList ddlmvmtlvlagttyp = (DropDownList)row.FindControl("ddlmvmtlvlagttyp");
            ddlmvmtlvlagttyp.Items.Clear();
            if (ddlmvmtbsdon.SelectedValue == "1")
            {
                if (Request.QueryString["unitrank"] != null)
                {
                    if (Request.QueryString["unitrank"].ToString().Trim() != "")
                    {
                        GetAgentTypeForSlsChnnlCT(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtbsdon.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                    }
                }
            }
            else if (ddlmvmtbsdon.SelectedValue == "0")
            {
                if (Request.QueryString["unitrank"] != null)
                {
                    if (Request.QueryString["unitrank"].ToString().Trim() != "")
                    {
                        GetLevelType(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                    }
                }
            }
            ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtbsdon.Focus();
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

    protected void InsMvmtRptDtls(int flag, string mvmtchn, string mvmtsubcls, string mvmtbsdon, string mvmtlvlagttyp, string rblTyp, string mvmtlvl, string mvmttyp,string ceasedt,string effdt)
    {
        try
        {
            htable.Clear();
            dsResult.Clear();
            htable.Add("@CarrierCode", Session["CarrierCode"].ToString().Trim());
            htable.Add("@MvmtTyp", mvmttyp.ToString().Trim());
            htable.Add("@MvmtLvl", mvmtlvl.ToString().Trim());
            if (chkChecker.Checked == true)
            {
                if (ddlnochkrs.SelectedValue != "")
                {
                    htable.Add("@MvmtRule", ddlnochkrs.SelectedValue.ToString().Trim());
                }
                else
                {
                    htable.Add("@MvmtRule", "0");
                }
            }
            else
            {
                htable.Add("@MvmtRule", "0");
            }
            if (Request.QueryString["chn"] != null)
            {
                if (Request.QueryString["chn"].ToString().Trim() != "")
                {
                    htable.Add("@BizSrc", Request.QueryString["chn"].ToString().Trim());
                }
            }
            if (Request.QueryString["subchn"] != null)
            {
                if (Request.QueryString["subchn"].ToString().Trim() != "")
                {
                    htable.Add("@ChnCls", Request.QueryString["subchn"].ToString().Trim());
                }
            }
            if (Request.QueryString["memtype"] != null)
            {
                if (Request.QueryString["memtype"].ToString().Trim() != "")
                {
                    htable.Add("@MemType", Request.QueryString["memtype"].ToString().Trim());
                }
            }
            htable.Add("@Channel", mvmtchn.ToString().Trim());
            htable.Add("@SubChannel", mvmtsubcls.ToString().Trim());
            htable.Add("@BasedOn", mvmtbsdon.ToString().Trim());
            htable.Add("@MemOrLevelType", mvmtlvlagttyp.ToString().Trim());
            htable.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            htable.Add("@Flag", flag);
            htable.Add("@UserType", rblTyp.Trim());
            if (ceasedt != "")
            {
                htable.Add("@CeaseDate", ceasedt);
            }
            else
            {
                htable.Add("@CeaseDate", DBNull.Value);
            }
            if (effdt != "")
            {
                htable.Add("@EffectiveDate", effdt);
            }
            else
            {
                htable.Add("EffectiveDate", DBNull.Value);
            }
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", htable);
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkChecker.Checked && ddlnochkrs.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select No. of Checkers')", true);
                ddlnochkrs.Focus();
                return;
            }

            DataSet makerds = (DataSet)Session["MvmtDetails"];
            DataSet checkerds = (DataSet)Session["MvmtCheckerDetails"];

            if (makerds == null || makerds.Tables[0].Rows.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('There should be atleast one Maker')", true);
                return;
            }

            if (ddlnochkrs.SelectedValue != "")
            {
                int count = Convert.ToInt32(ddlnochkrs.SelectedValue);
                for (int i = 1; i <= count; i++)
                {
                    DataView tempchkdv = new DataView(checkerds.Tables[0]);
                    tempchkdv.RowFilter = "MvmtLvl = " + i;
                    DataTable tempdt = tempchkdv.ToTable();
                    if (tempdt.Rows.Count < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Insert atleast one Checker for Checker "+i+"')", true);
                        return;
                    }
                }


            }

            if (Request.QueryString["mvmtrule"] != null)
            {
                if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                {
                    if (rblTrfTyp.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select the Transfer Type')", true);
                        rblTrfTyp.Focus();
                        return;
                    }
                }
            }


            //if (ddlMKCHKR.SelectedValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Movement Type')", true);
            //    ddlMKCHKR.Focus();
            //    return;
            //}
            //if (chkMaker.Checked == false)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Maker')", true);
            //    chkMaker.Focus();
            //    return;
            //}
            //if (chkMaker.Checked == true)
            //{
            //    if (rblTypeMkr.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Maker Type')", true);
            //        rblTypeMkr.Focus();
            //        return;
            //    }
            //    if (ddlmvmtchnmkr.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Hierarchy Name')", true);
            //        ddlmvmtchnmkr.Focus();
            //        return;
            //    }
            //    if (ddlmvmtsubclsmkr.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Sub Class')", true);
            //        ddlmvmtsubclsmkr.Focus();
            //        return;
            //    }
            //    if (ddlmvmtbsdonmkr.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Based On')", true);
            //        ddlmvmtbsdonmkr.Focus();
            //        return;
            //    }
            //    if (ddlmvmtlvlagttypmkr.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Relation Member Type')", true);
            //        ddlmvmtlvlagttypmkr.Focus();
            //        return;
            //    }
            //}
            //if (chkChecker.Checked == true)
            //{
            //    if (ddlnochkrs.SelectedValue == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Number of checkers')", true);
            //        ddlnochkrs.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        for (int i = 0; grdMKCHKR.Rows.Count > i; i++)
            //        {
            //            DropDownList ddlmvmtchn = grdMKCHKR.Rows[i].FindControl("ddlmvmtchn") as DropDownList;
            //            DropDownList ddlmvmtsubcls = grdMKCHKR.Rows[i].FindControl("ddlmvmtsubcls") as DropDownList;
            //            DropDownList ddlmvmtbsdon = grdMKCHKR.Rows[i].FindControl("ddlmvmtbsdon") as DropDownList;
            //            DropDownList ddlmvmtlvlagttyp = grdMKCHKR.Rows[i].FindControl("ddlmvmtlvlagttyp") as DropDownList;
            //            RadioButtonList rblType = grdMKCHKR.Rows[i].FindControl("rblType") as RadioButtonList;
            //            HiddenField hdnmvtitle = (HiddenField)grdMKCHKR.Rows[i].FindControl("hdnmvtitle");

            //            if (hdnmvtitle.Value == "1")
            //            {
            //                if (rblType.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Type 1')", true);
            //                    rblType.Focus();
            //                    return;

            //                }
            //                if (ddlmvmtchn.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 1 Hierarchy Name')", true);
            //                    ddlmvmtchn.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtsubcls.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 1 Sub Class')", true);
            //                    ddlmvmtsubcls.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtbsdon.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 1 Based On')", true);
            //                    ddlmvmtbsdon.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtlvlagttyp.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 1 Relation Member Type')", true);
            //                    ddlmvmtlvlagttyp.Focus();
            //                    return;
            //                }

            //            }
            //            else if (hdnmvtitle.Value == "2")
            //            {
            //                if (rblType.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Type 2')", true);
            //                    rblType.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtchn.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 2 Hierarchy Name')", true);
            //                    ddlmvmtchn.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtsubcls.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 2 Sub Class')", true);
            //                    ddlmvmtsubcls.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtbsdon.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 2 Based On')", true);
            //                    ddlmvmtbsdon.Focus();
            //                    return;
            //                }
            //                if (ddlmvmtlvlagttyp.SelectedValue == "")
            //                {
            //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker 2 Relation Member Type')", true);
            //                    ddlmvmtlvlagttyp.Focus();
            //                    return;
            //                }
            //            }
            //        }

            //    }
            //}
            if (Request.QueryString["mvmtrule"] != null)
            {
                Delete();//deleting records

                
                DataTable maker = makerds.Tables[0];

                MakerDetails.DataSource = makerds;
                MakerDetails.DataBind();
                for (int i = 0; i < maker.Rows.Count; i++)
                {

                    InsMvmtRptDtls(1, (maker.Rows[i]["Channel"]).ToString(), (maker.Rows[i]["SubChannel"]).ToString(), (maker.Rows[i]["BasedOn"]).ToString(), (maker.Rows[i]["MemOrLevelType"]).ToString(), (maker.Rows[i]["UserType"]).ToString(), "0", Request.QueryString["mvmtrule"].ToString().Trim(), maker.Rows[i]["CeaseDate"].ToString().Trim(), maker.Rows[i]["EffectiveDate"].ToString().Trim());
                    //InsMvmtRptDtls(1, ddlmvmtchnmkr.SelectedValue, ddlmvmtsubclsmkr.SelectedValue, ddlmvmtbsdonmkr.SelectedValue, ddlmvmtlvlagttypmkr.SelectedValue, rblTypeMkr.SelectedValue, "0", Request.QueryString["mvmtrule"].ToString().Trim());
                }

                
                //DataTable checker = checkerds.Tables[0];

                for (int i = 0; i < grdMKCHKR.Rows.Count; i++)
                {
                    //GridViewRow grdrow = grdMKCHKR.Rows[i];
                    //GridView grd = grdrow.FindControl("CheckerDetails") as GridView;
                    //if (grd != null)
                    //{
                        DataTable checker = checkerds.Tables[0];
                        DataView dvchr = new DataView(checker);
                        int mvmtLvl = i + 1;
                        string MvmtLvl = mvmtLvl.ToString();
                        dvchr.RowFilter = "MvmtLvl =" + mvmtLvl;
                        checker = dvchr.ToTable();
                        for (int j = 0; j < checker.Rows.Count; j++)
                        {
                            //insert checker row based on checker no
                            InsMvmtRptDtls(1, (checker.Rows[j]["Channel"]).ToString(), (checker.Rows[j]["SubChannel"]).ToString(), (checker.Rows[j]["BasedOn"]).ToString(), (checker.Rows[j]["MemOrLevelType"]).ToString(), (checker.Rows[j]["UserType"]).ToString(), MvmtLvl, Request.QueryString["mvmtrule"].ToString().Trim(), checker.Rows[j]["CeaseDate"].ToString().Trim(), checker.Rows[j]["EffectiveDate"].ToString().Trim());
                        }
                    //}
                    //else {
                    //    break;
                    //}
                }

                //for (int i = 0; grdMKCHKR.Rows.Count > i; i++)
                //{
                //    HiddenField hdnmvtitle = grdMKCHKR.Rows[i].FindControl("hdnmvtitle") as HiddenField;

                //    DropDownList ddlmvmtchn = grdMKCHKR.Rows[i].FindControl("ddlmvmtchn") as DropDownList;
                //    DropDownList ddlmvmtsubcls = grdMKCHKR.Rows[i].FindControl("ddlmvmtsubcls") as DropDownList;

                //    DropDownList ddlmvmtbsdon = grdMKCHKR.Rows[i].FindControl("ddlmvmtbsdon") as DropDownList;
                //    DropDownList ddlmvmtlvlagttyp = grdMKCHKR.Rows[i].FindControl("ddlmvmtlvlagttyp") as DropDownList;

                //    RadioButtonList rblType = grdMKCHKR.Rows[i].FindControl("rblType") as RadioButtonList;

                //    InsMvmtRptDtls(1, ddlmvmtchn.SelectedValue, ddlmvmtsubcls.SelectedValue, ddlmvmtbsdon.SelectedValue, ddlmvmtlvlagttyp.SelectedValue, rblType.SelectedValue, hdnmvtitle.Value, Request.QueryString["mvmtrule"].ToString().Trim());
                //}

                if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                {
                    string[] arr = new string[4];
                    int j;
                    string channel = string.Empty;
                    string AgtType = string.Empty;
                    string schnl = string.Empty;
                    //if (strtrf == "1")
                    //{
                    for (j = 0; j < rblTrfTyp.Items.Count; j++)
                    {
                        if (rblTrfTyp.Items[j].Selected == true)
                        {
                            arr[j] = rblTrfTyp.Items[j].Value.ToString().Trim();
                        }
                        else
                        {
                            arr[j] = "";
                        }
                    }
                    if (Request.QueryString["chn"] != null)
                    {
                        if (Request.QueryString["chn"].ToString().Trim() != "")
                        {
                            channel = Request.QueryString["chn"].ToString().Trim();
                        }
                    }
                    if (Request.QueryString["subchn"] != null)
                    {
                        if (Request.QueryString["subchn"].ToString().Trim() != "")
                        {
                            schnl = Request.QueryString["subchn"].ToString().Trim();
                        }
                    }
                    if (Request.QueryString["memtype"] != null)
                    {
                        if (Request.QueryString["memtype"].ToString().Trim() != "")
                        {
                            AgtType = Request.QueryString["memtype"].ToString().Trim();
                        }
                    }
                    MvmtType(channel, schnl, AgtType.ToString().Trim(), "E", arr[0].ToString().Trim(), arr[1].ToString().Trim(), arr[2].ToString().Trim(), arr[3].ToString().Trim());
                }
                Session["mvmt"] = Request.QueryString["mvmtrule"].ToString().Trim();
            }
            Session["MvmtDetails"] = null;
            Session["MvmtCheckerDetails"] = null;
            Session["NoOfCheckers"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('1');", true);
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

    #region GetAgentTypeForSlsChnnlCT Method
    public void GetAgentTypeForSlsChnnlCT(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string urank)
    {
        try
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            string carriercode = "2";

            htable.Clear();

            htable.Add("@BizSrc", strBizSrc);
            htable.Add("@selectedchannel", strChnCls);
            htable.Add("@UnitRnk", urank);

            dsResult = objDAL.GetDataSetForPrc("Prc_getAgentLvl", htable);

            if (dsResult.Tables.Count > 0)
            {
                FillDropDown(ddl, dsResult.Tables[0], "MemType", "MemTypeDesc01");
            }
            dsResult = null;
            strSql = null;
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

    public void FillDropDown(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
    {
        try
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();
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

    #region GetLevelType Method
    //added by akshay for getting channel based on reporting type
    public void GetLevelType(DropDownList ddl, string strBizSrc, string strChnCls, string UntRnk)
    {
        try
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            htable.Clear();
            htable.Add("@BizSrc", strBizSrc);
            htable.Add("@ChnnlClass", strChnCls);
            htable.Add("@UntRnk", UntRnk);
            dsResult = objDAL.GetDataSetForPrc("Prc_AgnLvl", htable);
            if (dsResult.Tables.Count > 0)
            {
                FillDropDown(ddl, dsResult.Tables[0], "UnitRank", "UnitRank");
            }
            dsResult = null;
            strSql = null;
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

    #region FillTrfTyp
    protected void FillTrfTyp(string code, CheckBoxList chkbx)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dstyp = new DataSet();
            htParam.Add("@LookupCode", code.ToString().Trim());
            //chnaged by nitin
            dstyp = objDAL.GetDataSetForPrc_inscdirect("PrcGetParamVals", htParam);
            if (dstyp.Tables.Count > 0)
            {
                if (dstyp.Tables[0].Rows.Count > 0)
                {
                    chkbx.DataSource = dstyp.Tables[0];
                    chkbx.DataTextField = "ParamDesc";
                    chkbx.DataValueField = "ParamValue";
                    chkbx.DataBind();
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

    #region rblTrfTyp_SelectedIndexChanged
    protected void rblTrfTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            foreach (ListItem lst in rblTrfTyp.Items)
            {
                if (lst.Selected == false)
                {
                    i++;
                }
            }
            //if (i == rblTrfTyp.Items.Count)
            //{
            //    tbltrftype.Visible = false;
            //    rbltrf.SelectedValue = "N";
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
    #endregion
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel();", true);
        Session["MvmtDetails"] = null;
        Session["MvmtCheckerDetails"] = null;
        Session["NoOfCheckers"] = null;
    }

    #region MvmtType
    protected void MvmtType(string chnl, string schnl, string AgtType, string flag, string type1, string type2, string type3, string type4)
    {
        Hashtable htable = new Hashtable();
        htable.Clear();
        try
        {
            htable.Add("@BizSrc", chnl.ToString().Trim());
            htable.Add("@ChnnlClass", schnl.ToString().Trim());
            htable.Add("@MemType", AgtType.ToString().Trim());
            htable.Add("@MvmtType", "T");
            htable.Add("@TrfTyp1", type1.ToString().Trim());
            htable.Add("@TrfTyp2", type2.ToString().Trim());
            htable.Add("@TrfTyp3", type3.ToString().Trim());
            htable.Add("@TrfTyp4", type4.ToString().Trim());
            htable.Add("@Flag", flag.ToString().Trim());
            htable.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            objDAL.execute_sprc("Prc_GetTrfType", htable);
            ////dtRead = objDAL.exec_reader_prc("Prc_GetTrfType", htable);
            htable.Clear();
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

    protected void BindGrid(string value)
    {
        htable.Clear();
        dsResult.Clear();
        try
        {
            //if (ddlMKCHKR.SelectedValue == "MO")
            //{
            //    htable.Add("@Rule", "1");
            //}
            //else if (ddlMKCHKR.SelectedValue == "MC")
            //{
            //    htable.Add("@Rule", "2");
            //}
            //else if (ddlMKCHKR.SelectedValue == "MCH")
            //{
            //    htable.Add("@Rule", "1");
            //}
            htable.Add("@Rule", value.Trim());
            dsResult = objDAL.GetDataSetForPrc_inscdirect("Prc_GetParamCount", htable);

            if (dsResult.Tables.Count > 0 )
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ////divmkchkrmvmt.Visible = true;
                    grdMKCHKR.DataSource = dsResult;
                    grdMKCHKR.DataBind();
                }
                else
                {
                    ////divmkchkrmvmt.Visible = false;
                    grdMKCHKR.DataSource = null;
                    grdMKCHKR.DataBind();
                }
            }
            else
            {
                ////divmkchkrmvmt.Visible = false;
                grdMKCHKR.DataSource = null;
                grdMKCHKR.DataBind();
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

    protected void GetMvmtType()
    {
        htable.Clear();
        dsResult.Clear();

        dsResult = GetMvmDetail(6,ref htable);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                if (Request.QueryString["mvmtrule"].ToString().Trim() == "CR")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["CrMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "MD")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["ModMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["TrfMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "TR")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["TrmMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "IS")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["ReinMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "PRM")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["PrmMvmtRule"].ToString().Trim();
                }
                else if (Request.QueryString["mvmtrule"].ToString().Trim() == "DEM")
                {
                    ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[0]["DemMvmtRule"].ToString().Trim();
                }
            }
        }
    }

    protected void ShowTrfType()
    {
        #region TRFTYPE
        Hashtable ht = new Hashtable();
        SqlDataReader dtr;
        try
        {
            ht.Clear();
            ht.Add("@BizSrc", Request.QueryString["chn"].ToString().Trim());
            ht.Add("@ChnnlClass", Request.QueryString["subchn"].ToString().Trim());
            ht.Add("@MemType", Request.QueryString["memtype"].ToString().Trim().Trim());
            ht.Add("@MvmtType", "T");
            ht.Add("@Flag", "S");
            dtr = objDAL.exec_reader_prc("Prc_GetTrfType", ht);
            dtr.Read();
            if (dtr.HasRows)
            {
                if (dtr["TrfType1"].ToString().Trim() != "")
                {
                    ListItem currentCheckBox = rblTrfTyp.Items.FindByValue(dtr["TrfType1"].ToString().Trim());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
                    }
                }
                if (dtr["TrfType2"].ToString().Trim() != "")
                {
                    ListItem currentCheckBox = rblTrfTyp.Items.FindByValue(dtr["TrfType2"].ToString().Trim());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
                    }
                }
                if (dtr["TrfType3"].ToString().Trim() != "")
                {
                    ListItem currentCheckBox = rblTrfTyp.Items.FindByValue(dtr["TrfType3"].ToString().Trim());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
                    }
                }
                if (dtr["TrfType4"].ToString().Trim() != "")
                {
                    ListItem currentCheckBox = rblTrfTyp.Items.FindByValue(dtr["TrfType4"].ToString().Trim());
                    if (currentCheckBox != null)
                    {
                        currentCheckBox.Selected = true;
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
        #endregion
    }

    protected void ddlmvmtlvlagttyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////ddlmvmtlvlagttyp.Focus();
    }
    protected void chkChecker_CheckedChanged(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["MvmtDetails"];
        if (!chkMaker.Checked || ds == null || ds.Tables[0].Rows.Count < 1)
        {    
            if (chkChecker.Checked)
            {
                chkChecker.Checked = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('There should be atleast one maker')", true);
                return;
            }
        }
        ddlnochkrs.SelectedIndex = 0;
        SetCheckerSession();
        VisibleChecker();
    }
    protected void chkMaker_CheckedChanged(object sender, EventArgs e)
    {
        VisibleMaker();
        MakerBlankTable();
    }

    protected void VisibleMaker()
    {
        if (chkMaker.Checked == true)
        {
            divmkchkr2.Visible = true;
        }
        else
        {
            divmkchkr2.Visible = false;
        }
        if (chkMaker.Checked == true)
        {
            if (Request.QueryString["mvmtrule"] != null)
            {
                if (Request.QueryString["mvmtrule"].ToString().Trim() == "TRF")
                {
                    divmkchkrtrf.Visible = true;
                }
                else
                {
                    divmkchkrtrf.Visible = false;
                }
            }
            else
            {
                divmkchkrtrf.Visible = false;
            }
        }
        else
        {
            divmkchkrtrf.Visible = false;
        }
    }

    protected void VisibleChecker()
    {
        if (chkChecker.Checked == true)
        {
            divlblchkr.Visible = true;
            divtxtchkr.Visible = true;
        }
        else
        {
            divlblchkr.Visible = false;
            divtxtchkr.Visible = false;
            BindGrid(string.Empty);
        }
    }

    protected void ddlnochkrs_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        SetCheckerSession(); 
    }

    private void SetCheckerSession()
    {
        int totalCheckers = 0;
        Session["NoOfCheckers"] = ddlnochkrs.SelectedValue.Trim();
        if (ddlnochkrs.SelectedValue.Trim() != "")
        {
            totalCheckers = Convert.ToInt32(ddlnochkrs.SelectedValue.Trim());
        }

        BindGrid(ddlnochkrs.SelectedValue.ToString().Trim());
        DataSet ds = (DataSet)Session["MvmtCheckerDetails"];
        if (ds == null)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", "4");
            Session["MvmtCheckerDetails"] = objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", ht);
            return;
        }
        DataView tempdv = new DataView(ds.Tables[0]);
        tempdv.RowFilter = "MvmtLvl <" + (totalCheckers + 1);
        ds = new DataSet();
        ds.Tables.Add(tempdv.ToTable());
        Session["MvmtCheckerDetails"] = ds;
    }


    protected void ddlmvmtlvlagttypmkr_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void FillGrid()
    {
        try
        {

            if ((Session["MvmtDetails"]) == null)
            {
                htable.Clear();
                dsResult.Clear();

                dsResult = GetMvmDetail(4, ref htable);
                //Session["MvmtDetails"] = dsResult;

                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            chkMaker.Checked = true;
                            VisibleMaker();
                            DataTable makerdt = dsResult.Tables[0];
                            DataView makerdv = new DataView(makerdt);
                            DataSet temp = new DataSet();
                            makerdv.RowFilter = "MvmtLvl = 0";
                            makerdt = makerdv.ToTable();
                            temp.Tables.Add(makerdt);
                            MakerDetails.DataSource = temp;
                            Session["MvmtDetails"] = temp;
                            MakerDetails.DataBind();
                        }
                        else
                        {
                            ShowNoResultFound(dsResult.Tables[0], MakerDetails);
                        }
                    }
                    else
                    {
                        ShowNoResultFound(dsResult.Tables[0], MakerDetails);
                    }
                

                //if (dsResult.Tables.Count > 0)
                //{
                //    if (dsResult.Tables[0].Rows.Count > 0)
                //    {
                //        DataTable dt = new DataTable();
                //        dt.Columns.Add("MakerType");
                //        dt.Columns.Add("HierarchyName");
                //        dt.Columns.Add("SubClass");
                //        dt.Columns.Add("BasedOn");
                //        dt.Columns.Add("RelationMemberType");


                //        DataTable chkdt = new DataTable();
                //        chkdt.Columns.Add("CheckerType");
                //        chkdt.Columns.Add("HierarchyName");
                //        chkdt.Columns.Add("SubClass");
                //        chkdt.Columns.Add("BasedOn");
                //        chkdt.Columns.Add("RelationMemberType");

                //        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                //        {
                //            if (dsResult.Tables[0].Rows[i]["MvmtLvl"].ToString().Trim() == "0") //marker details
                //            {
                //                //chkMaker.Checked = true;
                //                //VisibleMaker();


                //                ddlmvmtchnmkr.SelectedValue = dsResult.Tables[0].Rows[i]["Channel"].ToString().Trim();
                //                objCommonU.GetUserChnclsChannel(ddlmvmtsubclsmkr, ddlmvmtchnmkr.SelectedValue, 0, HttpContext.Current.Session["UserID"].ToString().Trim());
                //                ddlmvmtsubclsmkr.Items.Insert(0, new ListItem("Select", ""));

                //                ddlmvmtsubclsmkr.SelectedValue = dsResult.Tables[0].Rows[i]["SubChannel"].ToString().Trim();
                //                ddlmvmtbsdonmkr.SelectedValue = dsResult.Tables[0].Rows[i]["BasedOn"].ToString().Trim();

                //                DataRow dr = dt.NewRow();
                //                dr["HierarchyName"] = dsResult.Tables[0].Rows[i]["Channel"].ToString().Trim();
                //                dr["SubClass"] = dsResult.Tables[0].Rows[i]["SubChannel"].ToString().Trim();
                //                dr["BasedOn"] = dsResult.Tables[0].Rows[i]["BasedOn"].ToString().Trim();



                //                ddlmvmtlvlagttypmkr.Items.Clear();
                //                if (ddlmvmtbsdonmkr.SelectedValue == "1")
                //                {
                //                    if (Request.QueryString["unitrank"] != null)
                //                    {
                //                        if (Request.QueryString["unitrank"].ToString().Trim() != "")
                //                        {
                //                            GetAgentTypeForSlsChnnlCT(ddlmvmtlvlagttypmkr, ddlmvmtchnmkr.SelectedValue, ddlmvmtbsdonmkr.SelectedValue, ddlmvmtsubclsmkr.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());

                //                        }
                //                    }
                //                }
                //                else if (ddlmvmtbsdonmkr.SelectedValue == "0")
                //                {
                //                    if (Request.QueryString["unitrank"] != null)
                //                    {
                //                        if (Request.QueryString["unitrank"].ToString().Trim() != "")
                //                        {
                //                            GetLevelType(ddlmvmtlvlagttypmkr, ddlmvmtchnmkr.SelectedValue, ddlmvmtsubclsmkr.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                //                        }
                //                    }
                //                }
                //                ddlmvmtlvlagttypmkr.Items.Insert(0, new ListItem("Select", ""));
                //                ddlmvmtlvlagttypmkr.SelectedValue = dsResult.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                //                dr["RelationMemberType"] = dsResult.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                //                if (dsResult.Tables[0].Rows[0]["UserType"] != "")
                //                {
                //                    rblTypeMkr.SelectedValue = dsResult.Tables[0].Rows[i]["UserType"].ToString().Trim();

                //                    dr["MakerType"] = dsResult.Tables[0].Rows[i]["UserType"].ToString().Trim();
                //                }
                //                else
                //                {
                //                    rblTypeMkr.SelectedValue = "I";
                //                }

                //                dt.Rows.Add(dr);
                //            }
                //            else if (dsResult.Tables[0].Rows[i]["MvmtLvl"].ToString().Trim() != "0") // checker details
                //            {
                //                for (int j = 0; grdMKCHKR.Rows.Count > j; j++)
                //                {
                //                    DropDownList ddlmvmtchn = grdMKCHKR.Rows[j].FindControl("ddlmvmtchn") as DropDownList; //hierarchy name
                //                    DropDownList ddlmvmtsubcls = grdMKCHKR.Rows[j].FindControl("ddlmvmtsubcls") as DropDownList; //subclass
                //                    DropDownList ddlmvmtbsdon = grdMKCHKR.Rows[j].FindControl("ddlmvmtbsdon") as DropDownList;//basedon
                //                    DropDownList ddlmvmtlvlagttyp = grdMKCHKR.Rows[j].FindControl("ddlmvmtlvlagttyp") as DropDownList; //relationMemberType
                //                    RadioButtonList rblType = grdMKCHKR.Rows[j].FindControl("rblType") as RadioButtonList;//Checker type

                //                    DataRow dr = chkdt.NewRow();

                //                    if (dsResult.Tables[0].Rows[j + 1]["MvmtLvl"].ToString().Trim() != "")
                //                    {
                //                        chkChecker.Checked = true;
                //                        ddlnochkrs.SelectedValue = dsResult.Tables[0].Rows[j + 1]["MvmtLvl"].ToString().Trim();
                //                        VisibleChecker();
                //                    }
                //                    //ddlmvmtchn.SelectedValue = dsResult.Tables[0].Rows[j + 1]["Channel"].ToString().Trim();
                //                    dr["HierarchyName"] = dsResult.Tables[0].Rows[j + 1]["Channel"].ToString().Trim();//grid
                //                  //  objCommonU.GetUserChnclsChannel(ddlmvmtsubcls, ddlmvmtchn.SelectedValue, 0, HttpContext.Current.Session["UserID"].ToString().Trim());
                //                  //ddlmvmtsubcls.Items.Insert(0, new ListItem("Select", ""));

                //                    //ddlmvmtsubcls.SelectedValue = dsResult.Tables[0].Rows[j + 1]["SubChannel"].ToString().Trim();
                //                    dr["SubClass"] = dsResult.Tables[0].Rows[j + 1]["SubChannel"].ToString().Trim(); //grid
                //                    //ddlmvmtbsdon.SelectedValue = dsResult.Tables[0].Rows[j + 1]["BasedOn"].ToString().Trim();
                //                    dr["BasedOn"] = dsResult.Tables[0].Rows[j + 1]["BasedOn"].ToString().Trim();

                //                    //ddlmvmtlvlagttyp.Items.Clear();
                //                    //if (ddlmvmtbsdon.SelectedValue == "1")
                //                    //{
                //                    //    if (Request.QueryString["unitrank"] != null)
                //                    //    {
                //                    //        if (Request.QueryString["unitrank"].ToString().Trim() != "")
                //                    //        {
                //                    //            GetAgentTypeForSlsChnnlCT(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtbsdon.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                //                    //        }
                //                    //    }
                //                    //}
                //                    //else if (ddlmvmtbsdon.SelectedValue == "0")
                //                    //{
                //                    //    if (Request.QueryString["unitrank"] != null)
                //                    //    {
                //                    //        if (Request.QueryString["unitrank"].ToString().Trim() != "")
                //                    //        {
                //                    //            GetLevelType(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                //                    //        }
                //                    //    }
                //                    //}
                //                    //ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
                //                    //ddlmvmtlvlagttyp.SelectedValue = dsResult.Tables[0].Rows[j + 1]["MemOrLevelType"].ToString().Trim();
                //                    dr["RelationMemberType"] = dsResult.Tables[0].Rows[j + 1]["MemOrLevelType"].ToString().Trim();
                //                    //rblType.SelectedValue = dsResult.Tables[0].Rows[j + 1]["UserType"].ToString().Trim();
                //                    dr["CheckerType"] = dsResult.Tables[0].Rows[j + 1]["UserType"].ToString().Trim();
                //                    chkdt.Rows.Add(dr);
                //                }
                //            }
                //        }

                //        MakerDetails.DataSource = dt;
                //        MakerDetails.DataBind();

                //        //var grdChecker = (GridView)grdMKCHKR.FindControl("CheckerDetails");
                //        //grdChecker.DataSource = chkdt;
                //        //grdChecker.DataBind();

                //    }
                //}
            }
            else
            {
                chkMaker.Checked = true;
                VisibleMaker();
                var makerChecker = (DataSet)Session["MvmtDetails"];
                if (makerChecker.Tables.Count > 0)
                {
                    if (makerChecker.Tables[0].Rows.Count > 0)
                    {
                        var maker = makerChecker.Tables[0];
                        MakerDetails.DataSource = maker;
                        MakerDetails.DataBind();
                    }
                    else
                    {
                        ShowNoResultFound(makerChecker.Tables[0], MakerDetails);
                    }
                }
                else
                {
                    ShowNoResultFound(dsResult.Tables[0], MakerDetails);
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

    protected void Delete()
    {
        htable.Clear();
        dsResult.Clear();
        try
        {
            dsResult = GetMvmDetail(2, ref htable);
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

    private DataSet GetMvmDetail(int flag, ref Hashtable ht)
    {
        if (Request.QueryString["chn"] != null)
        {
            if (Request.QueryString["chn"].ToString().Trim() != "")
            {
                ht.Add("@BizSrc", Request.QueryString["chn"].ToString().Trim());
            }
        }
        if (Request.QueryString["subchn"] != null)
        {
            if (Request.QueryString["subchn"].ToString().Trim() != "")
            {
                ht.Add("@ChnCls", Request.QueryString["subchn"].ToString().Trim());
            }
        }
        if (Request.QueryString["memtype"] != null)
        {
            if (Request.QueryString["memtype"].ToString().Trim() != "")
            {
                ht.Add("@MemType", Request.QueryString["memtype"].ToString().Trim());
            }
        }
        ht.Add("@Flag", flag);
        if (Request.QueryString["mvmtrule"] != null)
        {
            if (Request.QueryString["mvmtrule"].ToString().Trim() != "")
            {
                ht.Add("@MvmtTyp", Request.QueryString["mvmtrule"].ToString().Trim());
            }
        }
        return objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", ht);
    }

    #region Button 'btnAddNew' Click Event
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (chkChecker.Checked && ddlnochkrs.SelectedValue.Trim() == "")
        {
            Session["NoOfCheckers"] = "Select";
        }
        ////Server.Transfer("ChannelSetup.aspx?flag=N"); 
        Response.Redirect("PopMvmtAddDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim()
        + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&bsdon=" + Request.QueryString["bsdon"] + "&rmt=" + Request.QueryString["rmt"] + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&MvmtLvl=0" + "&mdlpopup=mdlpopupmvmtBID", false);
       // Response.Redirect("PopMvmtAddDtls.aspx?ChnTyp=C&flag=''&ChnCls=" + lbChnCls1.Text + "&ChnDesc01=" + lblChannelDesc01.Text + "&SortOrder=" + lblSortOrder.Text + "&mdlpopup=mdlpopup");
    }
    
    #endregion    

    #region Button 'btnAddNewCh' Click Event
    protected void btnAddNewCh_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;

        //Get the row that contains this button
        GridViewRow gRow = (GridViewRow)btn.NamingContainer;
        ////Server.Transfer("ChannelSetup.aspx?flag=N"); 
        //GridViewRow gRow = ((Button)sender).NamingContainer as GridViewRow;
        int MvmtLvl = Convert.ToInt32(gRow.RowIndex.ToString().Trim()) + 1;
        Response.Redirect("PopMvmtAddDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim()
        + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype="
        + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&bsdon=" + Request.QueryString["bsdon"] + "&rmt=" + Request.QueryString["rmt"] + "&flag="
        + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&MvmtLvl=" + MvmtLvl 
        + "&mdlpopup=mdlpopupmvmtBID", false);
       // Response.Redirect("PopMvmtAddDtls.aspx?ChnTyp=C&flag=''&ChnCls=" + lbChnCls1.Text + "&ChnDesc01=" + lblChannelDesc01.Text + "&SortOrder=" + lblSortOrder.Text + "&mdlpopup=mdlpopup");
    }
  
    #endregion    

    protected void Edit_Click(object sender, EventArgs e)
    {
        if (chkChecker.Checked && ddlnochkrs.SelectedValue.Trim() == "")
        {
            Session["NoOfCheckers"] = "Select";
        }
           GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
           LinkButton edit = (LinkButton)grd.FindControl("EditBtn");
           //Label lblChannelDesc01 = (Label)grd.FindControl("lblChannelDesc01");
           //Label lblSortOrder = (Label)grd.FindControl("lblSortOrder");
           Response.Redirect("PopMvmtAddDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim() + "&RowIndex=" + grd.RowIndex + "&ADE=E"
           + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&MvmtLvl=0" + "&mdlpopup=mdlpopupmvmtBID", false);

    }

    protected void EditChecker_Click(object sender, EventArgs e)
    {
        GridViewRow grdRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        GridView grd = (GridView)grdRow.NamingContainer;
        GridViewRow grdParent = (GridViewRow)grd.NamingContainer;
        Label title = (Label)grdParent.FindControl("lblmvtitle");
        string checkerTitle = System.Text.RegularExpressions.Regex.Replace(title.Text, "[^0-9]+", string.Empty);
        int RowIndex = int.Parse(checkerTitle);
        LinkButton edit = (LinkButton)grdRow.FindControl("EditBtn");
        //Label lblChannelDesc01 = (Label)grd.FindControl("lblChannelDesc01");
        //Label lblSortOrder = (Label)grd.FindControl("lblSortOrder");
        Response.Redirect("PopMvmtAddDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim() + "&RowIndex=" + grdRow.RowIndex + "&ADE=E"
        + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&MvmtLvl=" + RowIndex + "&mdlpopup=mdlpopupmvmtBID", false);

    }

    #region SORTING
    protected void MakerDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = new DataSet();
        DataView dv = new DataView();
        GridView dgSource = (GridView)sender;
        if(dgSource.ID.ToString() == "MakerDetails")
        {
          ds = (DataSet)Session["MvmtDetails"];
          DataTable dt = ds.Tables[0];
          dv = new DataView(dt);
        }
        else
        {
          ds = (DataSet)Session["MvmtCheckerDetails"];
          GridViewRow grdParent = (GridViewRow)dgSource.NamingContainer;
          Label title = (Label)grdParent.FindControl("lblmvtitle");
          string checkerTitle = System.Text.RegularExpressions.Regex.Replace(title.Text, "[^0-9]+", string.Empty);
          int Mvmtlvl = int.Parse(checkerTitle);
          DataTable dt = ds.Tables[0];
          dv = new DataView(dt);
          dv.RowFilter = "MvmtLvl =" + Mvmtlvl;
        }
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
        if (ds != null)
        {   
            if(ds.Tables[0].Rows.Count > 0)
            {
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

         //   dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            }
        }
    }
    #endregion   
  

    #region ROWDATABOUND
    protected void MakerDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) // Enables or Disables Edit button based on Delete btn text
        {
            Label Label5 = e.Row.FindControl("Label5") as Label;
            LinkButton deleteBtn = e.Row.FindControl("DeleteBtn") as LinkButton;
            LinkButton editBtn = e.Row.FindControl("EditBtn") as LinkButton;
            Label lblerrmsg = e.Row.FindControl("lblerrmsg") as Label;
            if (deleteBtn.Text != "Delete")
            {
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
            }
            editBtn.Text = "Edit";
            if (Label5.Text == "")
            {
                lblerrmsg.Text = "No records found";
                lblerrmsg.Visible = true;
            }
        }
    }
    #endregion       

    protected DataSet fillchckrdtls(int rowIndex)
    {
        var dsResult1 = new DataSet();
        var htable1 = new Hashtable();
           try
           {
          
               if ((Session["MvmtCheckerDetails"]) == null)
               {
                
                   dsResult1 = GetMvmDetail(4, ref htable1);

                   if (dsResult1.Tables[0].Rows.Count > 0)
                   {
                       if (Request.QueryString["flag"].ToString().Trim() == "V")
                       {
                           chkChecker.Checked = true;
                       }
                   }
                   DataTable checkerdt = dsResult1.Tables[0];
                   DataView checkerdv = new DataView(checkerdt);
                   checkerdv.RowFilter = "MvmtLvl > 0";
                   checkerdt = checkerdv.ToTable();
                   DataSet tempds = new DataSet();
                   tempds.Tables.Add(checkerdt);
                   Session["MvmtCheckerDetails"] = tempds;
                   checkerdv.RowFilter = "MvmtLvl = 1";
                   checkerdt = checkerdv.ToTable();
                   DataSet tempds2 = new DataSet();
                   tempds2.Tables.Add(checkerdt);

                   return tempds2; 
               }
               else
               {
                   chkMaker.Checked = true;
                   VisibleMaker();
                   var makerChecker = (DataSet)Session["MvmtCheckerDetails"];
                   var checker = makerChecker.Tables[0];
                   DataView dv = new DataView(checker);
                   dv.RowFilter = "MvmtLvl = " + rowIndex;
                   checker = dv.ToTable();
                   dsResult1.Tables.Add(checker);
                   return dsResult1;
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
           return dsResult1;
    }

    private DataTable ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        ////gv.Rows[0].Cells[0].Text = "No records found";
        source.Rows.Clear();
        return source;
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkDel = (LinkButton)grd.FindControl("DeleteBtn");
        LinkButton lnkEdit = (LinkButton)grd.FindControl("EditBtn");
        int index = grd.RowIndex;
        DataSet maker = new DataSet();
        maker = (DataSet)Session["MvmtDetails"];
        DataTable makerdt = maker.Tables[0];
        DataRow makerRow = makerdt.Rows[index];
        if (lnkDel.Text == "Delete")
        {
            lnkDel.Text = "InActive";
            lnkDel.Enabled = false;
            lnkEdit.Enabled = false;
            maker.Tables[0].Rows[index]["CeaseDate"] = DateTime.Now.ToShortDateString();
            maker.Tables[0].Rows[index]["CeaseDateDesc"] = "InActive";
            Session["MvmtDetails"] = maker;
        }

    }

    protected void DeleteChecker_Click(object sender, EventArgs e)
    {

        GridViewRow grdRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        GridView grd = (GridView)grdRow.NamingContainer;
        GridViewRow grdParent = (GridViewRow)grd.NamingContainer;
        Label title = (Label)grdParent.FindControl("lblmvtitle");
        string checkerTitle = System.Text.RegularExpressions.Regex.Replace(title.Text, "[^0-9]+", string.Empty);
        int RowIndex = int.Parse(checkerTitle);

        LinkButton lnkDel = (LinkButton)grdRow.FindControl("DeleteChecker");
        LinkButton lnkEdit = (LinkButton)grdRow.FindControl("EditBtn");

        int index = grdRow.RowIndex;
        int elementsBeforeIndexCount = 0;
        DataSet checker = (DataSet)Session["MvmtCheckerDetails"];
        DataTable checkerdt = checker.Tables[0];
        DataView checkerdv = new DataView(checkerdt);

        checkerdv.RowFilter = "MvmtLvl < " + RowIndex;
        DataTable temp = checkerdv.ToTable();
        if(temp.Rows.Count > 0)
        {
            index++;
            elementsBeforeIndexCount = temp.Rows.Count - 1;
        }
        int currentIndex = index + elementsBeforeIndexCount;  
        if (lnkDel.Text == "Delete")
        {
            lnkDel.Text = "InActive";
            lnkDel.Enabled = false;
            lnkEdit.Enabled = false;
            checker.Tables[0].Rows[currentIndex]["CeaseDate"] = DateTime.Now.ToShortDateString();
            Session["MvmtCheckerDetails"] = checker;
        }
    }
    protected void MakerBlankTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("UserType");
        dt.Columns.Add("ParamDesc");
        dt.Columns.Add("Channel");
        dt.Columns.Add("BizSrcDesc");
        dt.Columns.Add("SubChannel");
        dt.Columns.Add("ChnClsDesc");
        dt.Columns.Add("BasedOn");
        dt.Columns.Add("BasedOnDesc");
        dt.Columns.Add("MemOrLevelType");
        dt.Columns.Add("MemTypeDesc");
        dt.Columns.Add("Effective");
        dt.Columns.Add("CeaseDate");
        dt.Columns.Add("EffectiveDate");
        dt.Columns.Add("CeaseDateDesc");
        dt.Columns.Add("MvmtLvl");
        dt  = ShowNoResultFound(dt, MakerDetails);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        Session["MvmtDetails"] = ds;

    }

}
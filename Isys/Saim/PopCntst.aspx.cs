using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_PopCntst : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    Hashtable hdParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
            lblRefcntst.Visible = false;
            LblAddCntstRef.Visible = false;
            ddlAddCntstRef.Visible = false;
            ddlRefcntst.Visible = false;
            Lblrulstky.Visible = false;
            lstrulstky.Visible = false;
            ddlSlsChnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));
            DdlLocation.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlPartcpDef.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlRefcntst.Items.Insert(0, new ListItem("-- SELECT --", ""));//Added by Abuzar Siddiqui on 03/07/2020
            GetChnCls();
            funchnlpopup(ddlSlsChnl);
            GetParticipationRulCode();
            //GetCntstnt();//Added by Abuzar Siddiqui on 03/07/2020
            ddlPartcpDef.SelectedIndex=1;
            btnOK.Visible = false;
            btncancel1.Visible = false;

            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "ED")
                {
                    lblRefcntst.Visible = true;
                    LblAddCntstRef.Visible = true;
                    ddlAddCntstRef.Visible = true;
                    ddlRefcntst.Visible = true;
                    Lblrulstky.Visible = true;
                    lstrulstky.Visible = true;
                    btnSearch.Visible = false;
                    btnClear.Visible = false;
                    btnCncl.Visible = false;
                    FillDropDowns(ddlSlsChnl, "1");
                    FillDropDowns(ddlChnCls, "2");
                    FillDropDowns(ddlUnitRank, "3");
                    FillDropDowns(ddlPartcpDef, "4");
                    ddlSlsChnl.Enabled = false;
                    ddlChnCls.Enabled = false;
                    ddlUnitRank.Enabled = false;
                    ddlPartcpDef.Enabled = false;
                    btnOK.Visible=true;
                    btncancel1.Visible = true;
                }
                //else
                //{
                //    divmem.Attributes.Add("style", "display:block");

                //}
            }
        }
        if (ddlAddCntstRef.SelectedValue == "" || ddlAddCntstRef.SelectedValue == "N")
        {
            ddlRefcntst.Enabled = false;
        }
    }

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        var activeCheckBox = sender as CheckBox;
        var count = 0;
        if (activeCheckBox != null)
        {
            var isChecked = activeCheckBox.Checked;
            var tempCheckBox = new CheckBox();
            if (isChecked)
            {
                activeCheckBox.Checked = true;
            }
        }
    }

    #region funchnlpopup
    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_ddlmgrchnnl", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void ddlSlsChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSlsChnl.SelectedValue != "")
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "2"||Request.QueryString["flag"].ToString().Trim() == "ED")//Added by Abuzar Siddiqui on 14-07-2020
                {
                    GetChnCls();
                }
            }
        }
        else
        {
            ddlChnCls.Items.Clear();
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        ddlSlsChnl.Focus();
    }

    protected void GetChnCls()
    {
        try
        {
            ddlChnCls.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlSlsChnl.SelectedValue.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddlChnCls.DataSource = drRead;
                ddlChnCls.DataTextField = "ChnClsDesc01";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            drRead.Close();
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "2"|| Request.QueryString["flag"].ToString().Trim() == "ED")//Added by Abuzar Siddiqui on 14-07-2020
            {
                GetUnitRank();
            }
        }
    }



    
    protected void ddlPartcpDef_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPartcpDef.SelectedIndex == 2)
        {
            GetParticipationLocation();
            //Label4.Visible = true;
           // DdlLocation.Visible = true;
            
        }
        else
        {
            Label4.Visible = false;
            DdlLocation.Visible = false;
            
        }
        

    }

    protected void GetParticipationRulCode()
    {
        try
        {
            ddlPartcpDef.Items.Clear();
           Hashtable ht = new Hashtable();
            ht.Add("@Flag", "");

            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetPartiRulCode", ht);
            if (drRead.HasRows)
            {
                ddlPartcpDef.DataSource = drRead;
                ddlPartcpDef.DataTextField = "RUL_DESC";
                ddlPartcpDef.DataValueField = "RUL_CODE";
                ddlPartcpDef.DataBind();
		//ddlPartcpDef.SelectedIndex=1;
            }
            drRead.Close();
            ddlPartcpDef.Items.Insert(0, new ListItem("-- SELECT --", ""));
	 
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void GetParticipationLocation()
    {
        try
        {
            DdlLocation.Items.Clear();
            Hashtable ht = new Hashtable();
             ht.Add("@Flag", "44"); // added by ajay

            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
            if (drRead.HasRows)
            {
                DdlLocation.DataSource = drRead;
                DdlLocation.DataTextField = "DESC01";
                DdlLocation.DataValueField = "CODE";
                DdlLocation.DataBind();
            }
            drRead.Close();
            DdlLocation.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void GetUnitRank()
    {
        try
        {
            ddlUnitRank.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlSlsChnl.SelectedValue);

            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetUnitRank", ht);
            if (drRead.HasRows)
            {
                ddlUnitRank.DataSource = drRead;
                ddlUnitRank.DataTextField = "UnitRankDesc01";
                ddlUnitRank.DataValueField = "UnitRank";
                ddlUnitRank.DataBind();
            }
            drRead.Close();
            ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (ddlSlsChnl.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Sub Channel');", true);
            return;
        }
        if (ddlChnCls.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Channel');", true);
            return;
        }
        if (ddlUnitRank.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Unit Rank');", true);
            return;
        }
		
		if (ddlPartcpDef.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select  Participation');", true);
            return;
        }
        Hashtable ht = new Hashtable();
        ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetCntstnt", ht);
        if (drRead.HasRows)
        {
            LblAddCntstRef.Visible = true;
            lblRefcntst.Visible = true;
            ddlRefcntst.Visible = true;
            ddlAddCntstRef.Visible = true;
            Lblrulstky.Visible = true;
            lstrulstky.Visible = true;
            //ddlPartcpDef.SelectedIndex=1;
        }
        drRead.Close();
        BindGrid();
        //Loading_gif.Style.Add("display", "none");
        //dgCntst.Style.Add("display", "block");

        Loading_gif.Attributes["style"] = "display: none;";
        div3.Attributes["style"] = "display: block;";

        btnOK.Visible = true;
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlSlsChnl.SelectedValue = "";
        ddlChnCls.SelectedValue = "";
        ddlUnitRank.SelectedValue = "";
        dgCntst.DataSource = null;
        dgCntst.DataBind();
        dgCntst.Visible = false;
        divPage.Visible = false;
        tblOK.Visible = false;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (ddlPartcpDef.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Participation Definition');", true);
            return;

        }

        //if (ddlPartcpDef.SelectedIndex == 2)
        //{
        //    if (DdlLocation.SelectedIndex == 0)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Participation Defination');", true);
        //        return;
        //    }

        //}


        int str = 0;
        int cntcode = 0;
        DataTable dtR = new DataTable();
        //if (Session["grid"] != null)
        //{
        //    dtR = (DataTable)Session["grid"];
        //    if (dtR.Rows.Count > 0)
        //    {
        //        cntcode = Convert.ToInt32(dtR.Rows[dtR.Rows.Count - 1]["CNTSTNT_CODE"].ToString()) + 1;
        //    }
        //    else
        //    {
        //        cntcode = GetMaxCntstCode();
        //    }
        //}
        //else
        //{
        //    cntcode = GetMaxCntstCode();
        //}
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "2")
            {
                cntcode = GetMaxCntstCode();
                DataTable dt = new DataTable();
                dt.Columns.Add("CNTSTNT_CODE");
                dt.Columns.Add("CMPNSTN_CODE");
                dt.Columns.Add("CHN");
                dt.Columns.Add("CHNCLS");
                dt.Columns.Add("MEMTYPE");
                dt.Columns.Add("CMPNSTN_CODEVAL");
                dt.Columns.Add("BizSrc");
                dt.Columns.Add("ChnClsVal");
                dt.Columns.Add("MemTypeVal");
                dt.Columns.Add("UnitRank");
                dt.Columns.Add("UnitType");
                dt.Columns.Add("ActualUnitType");

                for (int intRowCount = 0; intRowCount <= dgCntst.Rows.Count - 1; intRowCount++)
                {
                    Label lblSlsChnl = (Label)dgCntst.Rows[intRowCount].Cells[0].FindControl("lblSlsChnl");
                    Label lblSubCls = (Label)dgCntst.Rows[intRowCount].Cells[1].FindControl("lblSubCls");
                    Label lblMemType = (Label)dgCntst.Rows[intRowCount].Cells[2].FindControl("lblMemType");
                    HiddenField hdnSlsChnl = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnSlsChnl");
                    HiddenField hdnSubCls = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnSubCls");
                    HiddenField hdnMemType = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnMemType");
                    HiddenField hdnUntRnk = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnUntRnk");
                    HiddenField hdnUntType = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnUntType");
                    HiddenField hdnActualUnitType = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnActualUnitType");

                    CheckBox ChkSelect = (CheckBox)dgCntst.Rows[intRowCount].Cells[3].FindControl("ChkSelect");

                    if (ChkSelect.Checked == true)
                    {
                        DataRow dr = dt.NewRow();

                        dr["CNTSTNT_CODE"] = cntcode;

                        if (Request.QueryString["cmpdesc"] != null)
                        {
                            dr["CMPNSTN_CODE"] = Request.QueryString["cmpdesc"].ToString().Trim();
                        }
                        if (Request.QueryString["cmpcode"] != null)
                        {
                            dr["CMPNSTN_CODEVAL"] = Request.QueryString["cmpcode"].ToString().Trim();
                        }
                        dr["CHN"] = lblSlsChnl.Text.ToString().Trim();
                        dr["CHNCLS"] = lblSubCls.Text.ToString().Trim();
                        dr["MEMTYPE"] = lblMemType.Text.ToString().Trim();
                        dr["BizSrc"] = hdnSlsChnl.Value.ToString().Trim();
                        dr["ChnClsVal"] = hdnSubCls.Value.ToString().Trim();
                        dr["MemTypeVal"] = hdnMemType.Value.ToString().Trim();
                        dr["UnitRank"] = hdnUntRnk.Value.ToString().Trim();
                        dr["UnitType"] = hdnUntType.Value.ToString().Trim();
                        dr["ActualUnitType"] = hdnActualUnitType.Value.ToString().Trim();
                        dt.Rows.Add(dr);

                        cntcode = cntcode + 1;
                    }
                }
                DataTable dts = new DataTable();
                Session["CMP"] = dt;
                CntstCreate(dt);
                /////ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
            }
            else
            {
                //Added by Abuzar on 13/07/2020 starts
                if (ddlAddCntstRef.SelectedIndex == 1)
                {
                    //hdParam.Clear();
                    ds.Clear();
                    //string Refrulesetkey = string.Empty;
                    foreach (ListItem item in this.lstrulstky.Items)
                    {
                        hdParam.Clear();
                        ds.Clear();
                        string Refrulesetkey = string.Empty;
                        if (item.Selected)
                        {
                            //Refrulesetkey += item + ",";
                            Refrulesetkey += item.Value;
                            hdParam.Add("@RULE_SET_CODE", Refrulesetkey.ToString());
                            hdParam.Add("@REF_CNTSTNT_CODE", ddlRefcntst.SelectedValue.ToString().Trim());
                            hdParam.Add("@CNTSTNT_CODE", Request.QueryString["pcntstcd"].ToString().Trim());
                            ds = objDal.GetDataSetForPrc_SAIM("PRC_COPY_RULE_EXECUTE", hdParam);
                        }
                    }
                    //hdParam.Add("@RULE_SET_CODE", Refrulesetkey.ToString());
                    //hdParam.Add("@REF_CNTSTNT_CODE", ddlRefcntst.SelectedValue.ToString().Trim());
                    //hdParam.Add("@CNTSTNT_CODE", lstCntstCode[intDataCount]);
                    //ds = objDal.GetDataSetForPrc_SAIM("PRC_COPY_RULE_EXECUTE", hdParam);
                }
                else
                {

                }
                //Added by Abuzar on 13/07/2020 Ends  
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);
        }
    }
    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[0].Text = "No member types have been defined";
        source.Rows.Clear();
    }
    protected void dgCntst_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex + 1;
            BindGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgCntst.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgCntst.PageCount;
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex - 1;
            BindGrid();
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
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindGrid()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@BizSrc", ddlSlsChnl.SelectedValue.ToString().Trim());
        htParam.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
        htParam.Add("@UnitRank", ddlUnitRank.SelectedValue.ToString().Trim());
		htParam.Add("@PRTCPTN_BSD_ON", ddlPartcpDef.SelectedValue.ToString().Trim());
		
      ///  htParam.Add("@cmpCode", Request.QueryString["cmpCode"].ToString().Trim());

        ds = objDal.GetDataSetForPrc_SAIM("GetMemTypeWithUnitTypRank", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgCntst.DataSource = ds;
            dgCntst.DataBind();
            ViewState["griddgCntst"] = ds.Tables[0];
            dgCntst.Visible = true;
            divPage.Visible = true;
            tblOK.Visible = true;
            
            if (dgCntst.PageCount > 1)
            {
                btnnext.Enabled = true;
                btnprevious.Enabled = false;
            }
            else
            {
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], dgCntst);
            tblOK.Visible = false;
        }
    }

    protected void BindGrid(string flag, string bizsrc, string chncls, string memtype)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@BizSrc", bizsrc.ToString().Trim());
        htParam.Add("@ChnCls", chncls.ToString().Trim());
        htParam.Add("@MemType", memtype.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("prc_GetRptMemType", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgCntst.DataSource = ds.Tables[0];
            dgCntst.DataBind();
            ViewState["griddgCntst"] = ds.Tables[0];
            FillDropDownDpnt(ds);
            dgCntst.Visible = true;
            divPage.Visible = true;
            tblOK.Visible = true;

            if (dgCntst.PageCount > 1)
            {
                btnnext.Enabled = true;
                btnprevious.Enabled = false;
            }
            else
            {
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], dgCntst);
            tblOK.Visible = false;
        }
    }

    protected int GetMaxCntstCode()
    {
        int code = 0;
        ds.Clear();
        htParam.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCntstCode", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            code = Convert.ToInt32(ds.Tables[0].Rows[0]["MaxCntstCode"].ToString().Trim());
        }
        return code;
    }

    //protected void CntstCreate(DataTable dtCnt)
    //{
    //    //htParam.Clear();
    //    //ds.Clear();
    //    //htParam.Add("@CmpCode", txtCompCode.Text.ToString().Trim());
    //    //htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
    //    //ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCntstDtls", htParam);
    //    ds.Clear();
    //    htParam.Clear();
    //    List<string> lstCntstCode = new List<string>();
    //    List<string> lstCmpCode = new List<string>();
    //    List<string> lstBizSrc = new List<string>();
    //    List<string> lstChnCls = new List<string>();
    //    List<string> lstMemTyp = new List<string>();
    //    List<string> lstEffFrm = new List<string>();
    //    List<string> lstEffTo = new List<string>();
    //    List<string> lstFinYr = new List<string>();
    //    List<string> lstVer = new List<string>();
    //    List<string> lstVerFrm = new List<string>();
    //    List<string> lstVerTo = new List<string>();

    //    string strhdnCnstCode = "";

    //    for (int intRowCount = 0; intRowCount <= dtCnt.Rows.Count - 1; intRowCount++)
    //    {
    //        lstCntstCode.Add(dtCnt.Rows[intRowCount]["CNTSTNT_CODE"].ToString().Trim());
    //        strhdnCnstCode = "";
    //        lstCmpCode.Add(dtCnt.Rows[intRowCount]["CMPNSTN_CODEVAL"].ToString().Trim());
    //        lstBizSrc.Add(dtCnt.Rows[intRowCount]["BizSrc"].ToString().Trim());
    //        lstChnCls.Add(dtCnt.Rows[intRowCount]["ChnClsVal"].ToString().Trim());
    //        lstMemTyp.Add(dtCnt.Rows[intRowCount]["MemTypeVal"].ToString().Trim());
    //    }
    //    for (int intDataCount = 0; intDataCount <= lstCntstCode.Count - 1; intDataCount++)
    //    {
    //        htParam.Clear();
    //        htParam.Add("@CntstCode", lstCntstCode[intDataCount]);
    //        htParam.Add("@CmpCode", lstCmpCode[intDataCount]);
    //        htParam.Add("@BizSrc", lstBizSrc[intDataCount]);
    //        htParam.Add("@ChnCls", lstChnCls[intDataCount]);
    //        htParam.Add("@MemType", lstMemTyp[intDataCount]);
    //        //if (txtEffDtFrm.Text == "")
    //        //{
    //        //    htParam.Add("@EffFrm", System.DBNull.Value);
    //        //}
    //        //else
    //        //{
    //        //    htParam.Add("@EffFrm", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
    //        //}
    //        //if (txtEffDtTo.Text == "")
    //        //{
    //        //    htParam.Add("@EffTo", System.DBNull.Value);
    //        //}
    //        //else
    //        //{
    //        //    htParam.Add("@EffTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));
    //        //}
    //        //if (txtVerEffFrm.Text == "")
    //        //{
    //        //    htParam.Add("@VerFrmDt", System.DBNull.Value);
    //        //}
    //        //else
    //        //{
    //        //    htParam.Add("@VerFrmDt", Convert.ToDateTime(txtVerEffFrm.Text.ToString().Trim()));
    //        //}
    //        //if (txtVerEffTo.Text == "")
    //        //{
    //        //    htParam.Add("@VerToDt", System.DBNull.Value);
    //        //}
    //        //else
    //        //{
    //        //    htParam.Add("@VerToDt", Convert.ToDateTime(txtVerEffTo.Text.ToString().Trim()));
    //        //}
    //        //htParam.Add("@FinYr", ddlBusiYear.SelectedValue.ToString().Trim());
    //        //htParam.Add("@VerNo", txtVer.Text.ToString().Trim());
    //        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
    //        htParam.Add("@Flag", "N");
    //        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCntstDtls", htParam);
    //    }
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);
    //    //mdlpopup.Show();
    //    //lbl3.Text = "Contestant Codes Saved Successfully";
    //    //lbl4.Text = "Compensation Code:" + txtCompCode.Text.ToString().Trim();
    //    //lbl5.Text = "Compensation Description:" + txtCompDesc1.Text.ToString().Trim();
    //    //btnSave.Enabled = false;
    //}

    protected void CntstCreate(DataTable dtCnt)
    {
        try
        {

            ds.Clear();
            htParam.Clear();
            List<string> lstCntstCode = new List<string>();
            List<string> lstCmpCode = new List<string>();
            List<string> lstBizSrc = new List<string>();
            List<string> lstChnCls = new List<string>();
            List<string> lstMemTyp = new List<string>();
            List<string> lstEffFrm = new List<string>();
            List<string> lstEffTo = new List<string>();
            List<string> lstFinYr = new List<string>();
            List<string> lstVer = new List<string>();
            List<string> lstVerFrm = new List<string>();
            List<string> lstVerTo = new List<string>();
            List<string> lstUnitRank = new List<string>();
            List<string> lstUnitType = new List<string>();
            List<string> lstActualUnitType = new List<string>();

            string strhdnCnstCode = "";

            for (int intRowCount = 0; intRowCount <= dtCnt.Rows.Count - 1; intRowCount++)
            {
                lstCntstCode.Add(dtCnt.Rows[intRowCount]["CNTSTNT_CODE"].ToString().Trim());
                strhdnCnstCode = "";
                lstCmpCode.Add(dtCnt.Rows[intRowCount]["CMPNSTN_CODEVAL"].ToString().Trim());
                lstBizSrc.Add(dtCnt.Rows[intRowCount]["BizSrc"].ToString().Trim());
                lstChnCls.Add(dtCnt.Rows[intRowCount]["ChnClsVal"].ToString().Trim());
                lstMemTyp.Add(dtCnt.Rows[intRowCount]["MemTypeVal"].ToString().Trim());
                lstUnitRank.Add(dtCnt.Rows[intRowCount]["UnitRank"].ToString().Trim());
                lstUnitType.Add(dtCnt.Rows[intRowCount]["UnitType"].ToString().Trim());
                lstActualUnitType.Add(dtCnt.Rows[intRowCount]["ActualUnitType"].ToString().Trim());
            }
            for (int intDataCount = 0; intDataCount <= lstCntstCode.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@CntstCode", lstCntstCode[intDataCount]);
                htParam.Add("@CmpCode", lstCmpCode[intDataCount]);
                htParam.Add("@BizSrc", lstBizSrc[intDataCount]);
                htParam.Add("@ChnCls", lstChnCls[intDataCount]);
                htParam.Add("@MemType", lstMemTyp[intDataCount]);
                htParam.Add("@UNIT_TYPE", lstUnitType[intDataCount]);
                htParam.Add("@UNIT_RANK", lstUnitRank[intDataCount]);
                htParam.Add("@ACTUAL_UNIT_TYPE", lstActualUnitType[intDataCount]);
                //if (txtEffDtFrm.Text == "")
                //{
                //    htParam.Add("@EffFrm", System.DBNull.Value);
                //}
                //else
                //{
                //    htParam.Add("@EffFrm", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
                //}
                //if (txtEffDtTo.Text == "")
                //{
                //    htParam.Add("@EffTo", System.DBNull.Value);
                //}
                //else
                //{
                //    htParam.Add("@EffTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));
                //}
                //if (txtVerEffFrm.Text == "")
                //{
                //    htParam.Add("@VerFrmDt", System.DBNull.Value);
                //}
                //else
                //{
                //    htParam.Add("@VerFrmDt", Convert.ToDateTime(txtVerEffFrm.Text.ToString().Trim()));
                //}
                //if (txtVerEffTo.Text == "")
                //{
                //    htParam.Add("@VerToDt", System.DBNull.Value);
                //}
                //else
                //{
                //    htParam.Add("@VerToDt", Convert.ToDateTime(txtVerEffTo.Text.ToString().Trim()));
                //}
                //htParam.Add("@FinYr", ddlBusiYear.SelectedValue.ToString().Trim());
                //htParam.Add("@VerNo", txtVer.Text.ToString().Trim());
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "2")
                    {
                        if (Request.QueryString["pcntstcd"] != null)
                        {
                            htParam.Add("@ParentCntCode", Request.QueryString["pcntstcd"].ToString().Trim());
                        }
                        else
                        {
                            htParam.Add("@ParentCntCode", "");
                        }
                    }
                    else
                    {
                        htParam.Add("@ParentCntCode", "");
                    }
                }
                else
                {
                    htParam.Add("@ParentCntCode", "");
                }
              //Added by Abuzar Siddiqui on 14/07/2020 starts
                htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                if (Request.QueryString["flag"] != null)
                {
                    htParam.Add("@Flag", "N");
                }
                else
                {
                    htParam.Add("@Flag", Request.QueryString["flag"].ToString().Trim());
                }
                //Added by Abuzar Siddiqui on 14/07/2020 End
                htParam.Add("@PRTCPTN_BSD_ON", ddlPartcpDef.SelectedValue.ToString().Trim());
                htParam.Add("@UNT_REL_TYPE", DdlLocation.SelectedValue.ToString().Trim());

                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCntstDtls", htParam);
                string msg = string.Empty;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    msg = ds.Tables[0].Rows[0]["Result"].ToString().Trim();
                    if (msg == "FAILED")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Contestant already exists for this compensation');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);
                    }
                }
                //Added by Abuzar on 13/07/2020 starts
                if (ddlAddCntstRef.SelectedIndex == 1)
                {
                    //hdParam.Clear();
                    ds.Clear();
                    //string Refrulesetkey = string.Empty;
                    foreach (ListItem item in this.lstrulstky.Items)
                    {
                        hdParam.Clear();
                        ds.Clear();
                        string Refrulesetkey = string.Empty;
                        if (item.Selected)
                        {
                            //Refrulesetkey += item + ",";
                            Refrulesetkey += item.Value;
                            hdParam.Add("@RULE_SET_CODE", Refrulesetkey.ToString());
                            hdParam.Add("@REF_CNTSTNT_CODE", ddlRefcntst.SelectedValue.ToString().Trim());
                            if (Request.QueryString["flag"] != null)
                            {
                                if (Request.QueryString["flag"].ToString().Trim() == "2")
                                {
                                    hdParam.Add("@CNTSTNT_CODE", lstCntstCode[intDataCount]);
                                }
                                else
                                {
                                    hdParam.Add("@CNTSTNT_CODE", Request.QueryString["pcntstcd"].ToString().Trim());
                                }
                            }
                            ds = objDal.GetDataSetForPrc_SAIM("PRC_COPY_RULE_EXECUTE", hdParam);
                        }
                    }
                    //hdParam.Add("@RULE_SET_CODE", Refrulesetkey.ToString());
                    //hdParam.Add("@REF_CNTSTNT_CODE", ddlRefcntst.SelectedValue.ToString().Trim());
                    //hdParam.Add("@CNTSTNT_CODE", lstCntstCode[intDataCount]);
                    //ds = objDal.GetDataSetForPrc_SAIM("PRC_COPY_RULE_EXECUTE", hdParam);
                }
                else
                {

                }
                //Added by Abuzar on 13/07/2020 Ends       
            }
            //mdlpopup.Show();
            //lbl3.Text = "Contestant Codes Saved Successfully";
            //lbl4.Text = "Compensation Code:" + txtCompCode.Text.ToString().Trim();
            //lbl5.Text = "Compensation Description:" + txtCompDesc1.Text.ToString().Trim();
            //btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
protected void dgCntst_Sorting(object sender, GridViewSortEventArgs e)
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

        BindGrid();
        DataTable dt = (DataTable)ViewState["griddgCntst"];
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
        if (dgSource.PageCount >= Convert.ToInt32(txtPage.Text))
        {
            btnprevious.Enabled = false;
            txtPage.Text = "1";
            btnnext.Enabled = false;
        }
        else
        {
            btnnext.Enabled = true;
        }
        /////ShowPageInformation();
    }

    protected void FillDropDownDpnt(DataSet ds)
    {
        ddlSlsChnl.Items.Clear();
        ddlChnCls.Items.Clear();
        ddlUnitRank.Items.Clear();

        ddlSlsChnl.DataSource = ds.Tables[1];
        ddlSlsChnl.DataTextField = "CHN";
        ddlSlsChnl.DataValueField = "BizSrc";
        ddlSlsChnl.DataBind();

        ddlChnCls.DataSource = ds.Tables[2];
        ddlChnCls.DataTextField = "CHNCLS";
        ddlChnCls.DataValueField = "ChnClsVal";
        ddlChnCls.DataBind();

        ddlUnitRank.DataSource = ds.Tables[3];
        ddlUnitRank.DataTextField = "UnitRankDesc01";
        ddlUnitRank.DataValueField = "UnitRank";
        ddlUnitRank.DataBind();

        ddlSlsChnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }
    //Added by Abuzar Siddiqui on 03/07/2020 starts

    protected void GetCntstnt()
    {
        try
        {
            ddlRefcntst.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            ht.Add("@bizsrc", ddlSlsChnl.SelectedValue.ToString().Trim());
            ht.Add("@chncls", ddlChnCls.SelectedValue.ToString().Trim());
            ht.Add("@unittype", ddlUnitRank.SelectedValue.ToString().Trim());
            ht.Add("@flag", Request.QueryString["flag"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetCntstnt_ref", ht);
            if (drRead.HasRows)
            {
                ddlRefcntst.DataSource = drRead;
                ddlRefcntst.DataTextField = "CNTSTNT_DESC";
                ddlRefcntst.DataValueField = "CNTSTNT_CODE";
                ddlRefcntst.DataBind();
                //ddlPartcpDef.SelectedIndex=1;
            }
            drRead.Close();
            ddlRefcntst.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //Added by Abuzar Siddiqui on 03/07/2020 ends
    protected void ddlRefcntst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "2"|| Request.QueryString["flag"].ToString().Trim() == "ED")
            {
                    GetRulstky();
            }
        }
    }
    protected void GetRulstky()
    {
        try
        {
            lstrulstky.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CNTSTNT_CODE", ddlRefcntst.SelectedValue.ToString().Trim());
            ht.Add("@Flag", Request.QueryString["flag"].ToString().Trim());
            ht.Add("@NCNTSTNT_CODE", Request.QueryString["pcntstcd"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetRulstkyRef", ht);
            if (drRead.HasRows)
            {
                lstrulstky.DataSource = drRead;
                lstrulstky.DataTextField = "RuleSetDesc";
                lstrulstky.DataValueField = "RuleSetCode"; 
                lstrulstky.DataBind();
                //ddlPartcpDef.SelectedIndex=1;
            }
            drRead.Close();

        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CODE", val.ToString().Trim());
            ht.Add("@CNTSTNT_CODE", Request.QueryString["pcntstcd"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetFILLDROPDOWN", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "Description";
                ddl.DataValueField = "Code";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));

            }
            drRead.Close();
            ddl.SelectedIndex = 1;

        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlAddCntstRef_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAddCntstRef.SelectedValue == "N"|| ddlAddCntstRef.SelectedValue=="")
            {
                ddlRefcntst.Enabled = false;
            }
            else
            {
                ddlRefcntst.Enabled = true;
            }
            if (ddlAddCntstRef.SelectedValue == "Y")
            {
                GetCntstnt();
            }
            else
            {
                ddlRefcntst.Items.Clear();
                lstrulstky.Items.Clear();
                ddlRefcntst.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
        }
        catch (Exception ex)
        {
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", "PopCntst", method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
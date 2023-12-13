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
            //ddlSlsChnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //funchnlpopup(ddlSlsChnl);
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "2")
                {
                    /////ddlUnitRank.SelectedValue = Request.QueryString["chncls"].ToString().Trim();
                    BindGrid(Request.QueryString["flag"].ToString().Trim(), Request.QueryString["bizsrc"].ToString().Trim(), Request.QueryString["chncls"].ToString().Trim(), Request.QueryString["memtype"].ToString().Trim());
                }

            }
            BindGrid();
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMem", "funchnlpopup", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    //protected void ddlSlsChnl_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSlsChnl.SelectedValue != "")
    //    {
    //        if (Request.QueryString["flag"] != null)
    //        {
    //            if (Request.QueryString["flag"].ToString().Trim() != "2")
    //            {
    //                GetChnCls();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        ddlChnCls.Items.Clear();
    //        ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
    //    }
    //    ddlSlsChnl.Focus();
    //}

    //protected void GetChnCls()
    //{
    //    try
    //    {
    //        ddlChnCls.Items.Clear();
    //        Hashtable ht = new Hashtable();
    //        ht.Add("@BizSrc", ddlSlsChnl.SelectedValue.ToString().Trim());
    //        drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddlChnCls.DataSource = drRead;
    //            ddlChnCls.DataTextField = "ChnClsDesc01";
    //            ddlChnCls.DataValueField = "ChnCls";
    //            ddlChnCls.DataBind();
    //        }
    //        drRead.Close();
    //        ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
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
    //protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["flag"] != null)
    //    {
    //        if (Request.QueryString["flag"].ToString().Trim() != "2")
    //        {
    //            GetUnitRank();
    //        }
    //    }
    //}

    //protected void GetUnitRank()
    //{
    //    try
    //    {
    //        ddlUnitRank.Items.Clear();
    //        Hashtable ht = new Hashtable();
    //        ht.Add("@BizSrc", ddlSlsChnl.SelectedValue);

    //        drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetUnitRank", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddlUnitRank.DataSource = drRead;
    //            ddlUnitRank.DataTextField = "UnitRankDesc01";
    //            ddlUnitRank.DataValueField = "UnitRank";
    //            ddlUnitRank.DataBind();
    //        }
    //        drRead.Close();
    //        ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));

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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ddlSlsChnl.SelectedValue = "";
        //ddlChnCls.SelectedValue = "";
        //ddlUnitRank.SelectedValue = "";
        dgCntst.DataSource = null;
        dgCntst.DataBind();
        dgCntst.Visible = false;
        divPage.Visible = false;
        tblOK.Visible = false;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
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
        cntcode = GetMaxCntstCode();
        DataTable dt = new DataTable();
        dt.Columns.Add("CNTSTNT_CODE");
        dt.Columns.Add("Member Code");
        dt.Columns.Add("Member Name");
        dt.Columns.Add("Agent Code");
        //dt.Columns.Add("MEMTYPE");
        //dt.Columns.Add("CMPNSTN_CODEVAL");
        //dt.Columns.Add("BizSrc");
        //dt.Columns.Add("ChnClsVal");
        //dt.Columns.Add("MemTypeVal");
        //dt.Columns.Add("UnitRank");

        //Add New column 30_11_2017
        dt.Columns.Add("CmpCode");
        dt.Columns.Add("memtype");
        dt.Columns.Add("chncls");
        dt.Columns.Add("chn");
        dt.Columns.Add("PARENTCNTSTCODE");

        for (int intRowCount = 0; intRowCount <= dgCntst.Rows.Count - 1; intRowCount++)
        {
            Label lblSlsChnl = (Label)dgCntst.Rows[intRowCount].Cells[0].FindControl("lblSlsChnl");
            Label lblSubCls = (Label)dgCntst.Rows[intRowCount].Cells[1].FindControl("lblSubCls");
            Label lblMemType = (Label)dgCntst.Rows[intRowCount].Cells[2].FindControl("lblMemType");
            //HiddenField hdnSlsChnl = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnSlsChnl");
            //HiddenField hdnSubCls = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnSubCls");
            //HiddenField hdnMemType = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnMemType");
            //HiddenField hdnUntRnk = (HiddenField)dgCntst.Rows[intRowCount].Cells[2].FindControl("hdnUntRnk");
            CheckBox ChkSelect = (CheckBox)dgCntst.Rows[intRowCount].Cells[3].FindControl("ChkSelect");
            if (ChkSelect.Checked == true)
            {
                DataRow dr = dt.NewRow();
                dr["CNTSTNT_CODE"] = cntcode;


                //if (Request.QueryString["cmpdesc"] != null)
                //{
                //    dr["CMPNSTN_CODE"] = Request.QueryString["cmpdesc"].ToString().Trim();
                //}
                //if (Request.QueryString["cmpcode"] != null)
                //{
                //    dr["CMPNSTN_CODEVAL"] = Request.QueryString["cmpcode"].ToString().Trim();
                //}
                dr["Member Code"] = lblSlsChnl.Text.ToString().Trim();
                dr["Member Name"] = lblSubCls.Text.ToString().Trim();
                dr["Agent Code"] = lblMemType.Text.ToString().Trim();

                dr["CmpCode"] = Request.QueryString["cmpcode"].ToString().Trim();
                dr["Memtype"] = Request.QueryString["memtype"].ToString().Trim();
                dr["Chncls"] = Request.QueryString["chncls"].ToString().Trim();
                dr["Chn"] = Request.QueryString["bizsrc"].ToString().Trim();
                dr["PARENTCNTSTCODE"] = Request.QueryString["pcntstcd"].ToString().Trim();
                dt.Rows.Add(dr);

                cntcode = cntcode + 1;
            }
        }
        DataTable dts = new DataTable();
        Session["CMP"] = dt;
        CntstCreate(dt);
        /////ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMem", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMem", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindGrid()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@memcode", txtMemtype.Text);
        htParam.Add("@memname", txtEmpname.Text);
        htParam.Add("@memtype", Request.QueryString["memtype"].ToString());
        htParam.Add("@BizSrc", Request.QueryString["bizsrc"].ToString());
        htParam.Add("@ChnCls ", Request.QueryString["chncls"].ToString());
        //ds = objDal.GetDataSetForPrc_SAIM("prc_GetMemDtls", htParam);
        ds = objDal.GetDataSetForPrc_SAIM("prc_GetMemDtls_contestant", htParam);
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
        // ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCntstCode", htParam);
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCntstMemberCode", htParam);
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

        //htParam.Clear();
        //ds.Clear();
        //htParam.Add("@CmpCode", txtCompCode.Text.ToString().Trim());
        //htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCntstDtls", htParam);
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

        string strhdnCnstCode = "";

        List<string> lsCmpCode = new List<string>();
        List<string> lstMemtype = new List<string>();
        List<string> lstChncls = new List<string>();
        List<string> lstChn = new List<string>();
        List<string> lstPARENTCNTSTCODE = new List<string>();
        List<string> lstMem_CNTSTNT_CODE = new List<string>();
        List<string> lstsub_CNTSTNT_CODE = new List<string>();

        for (int intRowCount = 0; intRowCount <= dtCnt.Rows.Count - 1; intRowCount++)
        {
            lstCntstCode.Add(dtCnt.Rows[intRowCount]["CNTSTNT_CODE"].ToString().Trim());
            strhdnCnstCode = "";
            //lstCmpCode.Add(dtCnt.Rows[intRowCount]["Member Code"].ToString().Trim());
            lstBizSrc.Add(dtCnt.Rows[intRowCount]["Member Name"].ToString().Trim());
            lstChnCls.Add(dtCnt.Rows[intRowCount]["Agent Code"].ToString().Trim());
            //lstMemTyp.Add(dtCnt.Rows[intRowCount]["MemTypeVal"].ToString().Trim());

            lsCmpCode.Add(dtCnt.Rows[intRowCount]["CmpCode"].ToString().Trim());
            lstMemtype.Add(dtCnt.Rows[intRowCount]["memtype"].ToString().Trim());
            lstChncls.Add(dtCnt.Rows[intRowCount]["chncls"].ToString().Trim());
            lstChn.Add(dtCnt.Rows[intRowCount]["chn"].ToString().Trim());
            lstPARENTCNTSTCODE.Add(dtCnt.Rows[intRowCount]["PARENTCNTSTCODE"].ToString().Trim());


            lstCmpCode.Add(dtCnt.Rows[intRowCount]["Member Code"].ToString().Trim());
            lstsub_CNTSTNT_CODE.Add("");


        }
        for (int intDataCount = 0; intDataCount <= lstCntstCode.Count - 1; intDataCount++)
        {
            htParam.Clear();
            //htParam.Add("@CntstCode", lstCntstCode[intDataCount]);
            //htParam.Add("@CmpCode", lstCmpCode[intDataCount]);
            //htParam.Add("@BizSrc", lstBizSrc[intDataCount]);
            //htParam.Add("@ChnCls", lstChnCls[intDataCount]);

            htParam.Add("@CntstCode", lstCntstCode[intDataCount]);
            htParam.Add("@CmpCode", lsCmpCode[intDataCount]);
            htParam.Add("@BizSrc", lstChn[intDataCount]);
            htParam.Add("@ChnCls", lstChncls[intDataCount]);
            htParam.Add("@ParentCntCode", lstPARENTCNTSTCODE[intDataCount]);
            // htParam.Add("@MemType", lstMemtype[intDataCount]);
            htParam.Add("@MemType", lstMemtype[intDataCount]);

            htParam.Add("@Mem_CNTSTNT_CODE", lstCmpCode[intDataCount]);
            htParam.Add("@Sub_Content_code", lstsub_CNTSTNT_CODE[intDataCount]);
            //if (Request.QueryString["flag"] != null)
            //{
            //    if (Request.QueryString["flag"].ToString().Trim() == "2")
            //    {
            //        if (Request.QueryString["pcntstcd"] != null)
            //        {
            //            htParam.Add("@ParentCntCode", Request.QueryString["pcntstcd"].ToString().Trim());
            //        }
            //        else
            //        {
            //            htParam.Add("@ParentCntCode", "");
            //        }
            //    }
            //    else
            //    {
            //        htParam.Add("@ParentCntCode", "");
            //    }
            //}
            //else
            //{
            //    htParam.Add("@ParentCntCode", "");
            //}


            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            htParam.Add("@Flag", "N");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCntstDtls_Member", htParam);
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
        }
    }
    //mdlpopup.Show();
    //lbl3.Text = "Contestant Codes Saved Successfully";
    //lbl4.Text = "Compensation Code:" + txtCompCode.Text.ToString().Trim();
    //lbl5.Text = "Compensation Description:" + txtCompDesc1.Text.ToString().Trim();
    //btnSave.Enabled = false;


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
        //ddlSlsChnl.Items.Clear();
        //ddlChnCls.Items.Clear();
        //ddlUnitRank.Items.Clear();

        //ddlSlsChnl.DataSource = ds.Tables[1];
        //ddlSlsChnl.DataTextField = "CHN";
        //ddlSlsChnl.DataValueField = "BizSrc";
        //ddlSlsChnl.DataBind();

        //ddlChnCls.DataSource = ds.Tables[2];
        //ddlChnCls.DataTextField = "CHNCLS";
        //ddlChnCls.DataValueField = "ChnClsVal";
        //ddlChnCls.DataBind();

        //ddlUnitRank.DataSource = ds.Tables[3];
        //ddlUnitRank.DataTextField = "UnitRankDesc01";
        //ddlUnitRank.DataValueField = "UnitRank";
        //ddlUnitRank.DataBind();

        //ddlSlsChnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        //ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
        //ddlUnitRank.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }

}
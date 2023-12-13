using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class Application_Isys_Saim_RuleSetPages_FFCntPageStdDef : BaseClass
{
    #region Declarations
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["USRMGMT"].ToString();
    private SqlConnection sqlconn = new SqlConnection();
    private DataSet Ds = new DataSet();
    private SqlCommand cmd = new SqlCommand();
    private SqlDataAdapter sqladpt = new SqlDataAdapter();
    Hashtable Htparam = new Hashtable();

    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    DataAccessClass obDAL = new DataAccessClass();
    DataTable dt = new DataTable();
    ErrLog objErr = new ErrLog();

    string Branchcode = "";
    string strmapcode = string.Empty;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["flagMode"] != null && Request.QueryString["flagMode"].ToString() != "undefined" && Request.QueryString["flagMode"].ToString() == "rsTrgStp")
            {
                div9.Attributes.Add("style", "display:none;");
            }
            if (Request.QueryString["mapcode"] != null && Request.QueryString["mapcode"].ToString() != "")
            {
                strmapcode = Request.QueryString["mapcode"].ToString().Trim();
            }
            //GetVPSCFreq(strmapcode, "", "", "");

            //Need to be uncommented later //
            //btnAddDateReleted.Attributes.Add("onclick", "funPopUpRulSet('','','R'," + strmapcode + ",'','P'," + lblEffDtFrmVal.Text.Trim() + "," + lblEffDtToVal.Text.Trim() + ");return false;");////Date Level
            //BtnVPSCAdd.Attributes.Add("onclick", "funPopUpRulSetVPSC('','','R'," + strmapcode + ");return false;");////Member Level
            //Need to be uncommented later //
            FillDateMemRel("A", dgDateDef);
            FillMemFilterDef();
            btnAddDateReleted.Attributes.Add("onclick", "funPopUpRulSet('','','R','" + strmapcode + "','','A','','');return false;");////Date Level
            BtnVPSCAdd.Attributes.Add("onclick", "funPopUpRulSetVPSC('" + Request.QueryString["CMPNSTN_CODE"] + "','" + Request.QueryString["CNTST_CODE"] + "','" + Request.QueryString["RULE_SET_KEY"] + "','" + Request.QueryString["CYCLE_CODE"] + "','R','" + strmapcode + "','');return false;");////Member Level
        }
    }

    protected void dgDateDef_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("dgDateDefedit");
            string mapcode = Request.QueryString["mapcode"].ToString();
            if (Request.QueryString["KpiCode"] != null)
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString() == "in")
                    {
                        lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R','" + mapcode.Trim() + "','" + lblCode.Value + "','A','" + lblEffDtFrmVal.Text.Trim() + "','" + lblEffDtToVal.Text.Trim() + "');return false;");
                    }
                    else if (Request.QueryString["flag"].ToString() == "kpi")
                    {
                        lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R','" + mapcode.Trim() + "','" + lblCode.Value + "','A','" + lblEffDtFrmVal.Text.Trim() + "','" + lblEffDtToVal.Text.Trim() + "');return false;");
                    }
                }
                else
                {
                    lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R','" + mapcode.Trim() + "','" + lblCode.Value + "','A','" + lblEffDtFrmVal.Text.Trim() + "','" + lblEffDtToVal.Text.Trim() + "');return false;");
                }
            }
            else
            {
                lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSet('','','R','" + mapcode.Trim() + "','" + lblCode.Value + "','A','" + lblEffDtFrmVal.Text.Trim() + "','" + lblEffDtToVal.Text.Trim() + "');return false;");
            }
        }
    }

    protected void GetDateRelDefn(string strmapcode, GridView dg, string datetype)
    {
        DataSet dsDate = new DataSet();
        dsDate.Clear();
        Htparam.Clear();

        Htparam.Add("@MapCode", strmapcode);
        Htparam.Add("@Datetype", datetype);
        dsDate = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
        dg.DataSource = dsDate;
        dg.DataBind();

        if (dsDate.Tables.Count > 0)
        {
            if (dsDate.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                DataTable dt2 = dsDate.Tables[0];
                ShowNoResultFound(dt2, dg);
            }
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
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No rules have been defined";

        //source.Rows.Clear();
    }

    protected void lnkSplit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsAcc = new DataSet();
            Hashtable htAcc = new Hashtable();
            string ddlAccYear = "";
            string txtEffDtFrm = "";
            string txtEffDtTo = "";
            string BUSI_YEAR = "";
            dsAcc.Clear();
            htAcc.Clear();
            htAcc.Add("@cmpcode", lblCompCodeVal.Text);

            dsAcc = obDAL.GetDataSetForPrc_SAIM("Prc_GetAccAccrRewardDtls", htAcc);
            {
                if (dsAcc.Tables[0].Rows.Count > 0)
                {

                    ddlAccYear = dsAcc.Tables[0].Rows[0]["ACC_YEAR"].ToString();
                    txtEffDtFrm = dsAcc.Tables[0].Rows[0]["EFF_FROM"].ToString();
                    txtEffDtTo = dsAcc.Tables[0].Rows[0]["EFF_TO"].ToString();
                    BUSI_YEAR = dsAcc.Tables[0].Rows[0]["BUSI_YEAR"].ToString();

                }

            }

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle();", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycleDef('" + lblCompCodeVal.Text.ToString().Trim() + "');", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle('" + lblCompCodeVal.Text.ToString().Trim() + "','" + ddlAccCyc.SelectedValue.ToString().Trim() + "','" + GetCycleDetails("CYCLE_TYPE", "23") + "','" + ddlAccYear + "','" + txtEffDtFrm.Trim() + "','" + txtEffDtTo + "','" + txtRuleSetKey.Text.ToString() + "','" + lblCntstCdVal.Text.ToString() + "','" + BUSI_YEAR + "');", true);

            string url = "Date_Cycle_Defination_Split_Def.aspx?cmpcode=" + lblCompCodeVal.Text.ToString().Trim() + "&effdatefrom=" + txtEffDtFrm.Trim() + "&effdateto=" + txtEffDtTo.Trim() + "&CYCLE=" + Request.QueryString["CYCLE"].ToString().Trim() + "&rulesetcode=" + Request.QueryString["RuleSetKey"].ToString().Trim() + "&cntstcode=" + Request.QueryString["CNTST_CODE"].ToString().Trim();
            string s = "window.open('" + url + "', 'popup_window', 'width=1200,height=600,left=70,top=40,bottom=80,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntPageStdDef", "lnkSplit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgDateDefDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelRecrDtRelDef", Htparam);

        GetDateRelDefn(strmapcode, dgDateDef, "A");
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        FillDateMemRel("A", dgDateDef);
        //FillDateMemRel("A", dgMemDt);
    }

    protected void FillDateMemRel(string type, GridView grd)
    {
        string strmapcode = "";
        if (Request.QueryString["KpiCode"] != null)
        {
            strmapcode = Request.QueryString["mapcode"].ToString();
        }
        else
        {
            string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
            string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();
            strmapcode = Request.QueryString["mapcode"].ToString();
        }
        DataSet ds = new DataSet();
        Htparam.Clear();
        Htparam.Add("@MapCode", strmapcode);
        Htparam.Add("@Datetype", type.ToString().Trim());
        ds = obDAL.GetDataSetForPrcDBConn("Prc_getMST_DateRelatedDefData", Htparam, "SAIMConnectionString");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = ds;
            grd.DataBind();
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], grd);
        }
    }


    protected void GrdVPSCWeightDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField HdnRecId = (HiddenField)row.FindControl("HdnRecId");
        Htparam.Clear();
        ds.Clear();
        string strmapcode = Request.QueryString["mapcode"].ToString();
        string strcmpcode = Request.QueryString["CMPNSTN_CODE"].ToString();
        string RuleSetKey = "";//CNTST_CODE
        string strcntstcode = Request.QueryString["CNTST_CODE"].ToString();

        Htparam.Add("@MapCode", strmapcode.ToString().Trim());
        Htparam.Add("@RecID", HdnRecId.Value.ToString().Trim());
        Htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DelMemFilterDef", Htparam);

        //GetPremFreq(strmapcode);
        GetVPSCFreq(strmapcode, strcmpcode, RuleSetKey, strcntstcode);
    }

    protected void GrdVPSWeight_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lblCode = (HiddenField)e.Row.FindControl("HdnRecId");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("GrdVPSCWeightEdit");
            string mapcode = Request.QueryString["mapcode"].ToString();
            lnkEditRwdTrg.Attributes.Add("onclick", "funPopUpRulSetVPSC('" + Request.QueryString["CMPNSTN_CODE"] + "','" + Request.QueryString["CNTST_CODE"] + "','" + Request.QueryString["RULE_SET_KEY"] + "','" + Request.QueryString["CYCLE_CODE"] + "','R','" + mapcode.Trim() + "','" + lblCode.Value + "');return false;");
        }
    }

    protected void btnpreGrdPremiumW_Click(object sender, EventArgs e)
    {

        try
        { //bbbbb
            int pageIndex = GrdVPSWeight.PageIndex;
            GrdVPSWeight.PageIndex = pageIndex - 1;
            GetVPSCFreq(strmapcode,"","","");
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            //BindRevHistGrid(lblCompCodeVal.Text.ToString());
            TextBox1.Text = Convert.ToString(Convert.ToInt32(TextBox1.Text) - 1);
            if (TextBox1.Text == "1")
            {
                Button1.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
            }
            Button2.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntPageStdDef", "btnpreGrdPremiumW_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnextGrdPremiumW_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GrdVPSWeight.PageIndex;
            GrdVPSWeight.PageIndex = pageIndex + 1;
            //GetPremFreq(strmapcode);
            GetVPSCFreq(strmapcode, "", "", "");
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            TextBox1.Text = Convert.ToString(Convert.ToInt32(TextBox1.Text) + 1);
            Button1.Enabled = true;
            if (TextBox1.Text == Convert.ToString(GrdVPSWeight.PageCount))
            {
                Button2.Enabled = false;
            }
            int page = GrdVPSWeight.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntPageStdDef", "btnnextGrdPremiumW_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetVPSCFreq(string strmapcode, string strcmpcode, string RuleSetKey, string strcntstcode)
    {
        DataSet dsPrem = new DataSet();

        Htparam.Clear();
        dsPrem.Clear();
        Htparam.Add("@MapCode", strmapcode);

        //Htparam.Add("@cmpcode", strcmpcode);
        //Htparam.Add("@cntstcode", strcntstcode);
        dsPrem = obDAL.GetDataSetForPrcDBConn("Prc_EditMemFilterDef", Htparam, "SAIMConnectionString");
        GrdVPSWeight.DataSource = dsPrem;
        GrdVPSWeight.DataBind();
        if (dsPrem.Tables.Count > 0)
        {
            if (dsPrem.Tables[0].Rows.Count > 0)
            {
                GrdVPSWeight.DataSource = dsPrem;
                GrdVPSWeight.DataBind();
                if (GrdVPSWeight.PageCount > Convert.ToInt32(TextBox1.Text))
                {
                    Button2.Enabled = true;
                }
                else
                {
                    Button2.Enabled = false;
                }
            }
            else
            {
                DataTable dt = dsPrem.Tables[0];
                ShowNoResultFound(dt, GrdVPSWeight);
                TextBox1.Text = "1";
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
        }
        ViewState["GrdVPSWeight"] = dsPrem.Tables[0];
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        FillMemFilterDef();
    }

    private void FillMemFilterDef()
    {
        string strmapcode = "";

        if (Request.QueryString["KpiCode"] != null)
        {

            strmapcode = Request.QueryString["mapcode"].ToString();

        }
        else
        {

            string strCMPNSTN_CODE = Request.QueryString["CMPNSTN_CODE"].ToString();
            string strCNTST_CODE = Request.QueryString["CNTST_CODE"].ToString();
            strmapcode = Request.QueryString["mapcode"].ToString();

        }
        DataSet ds = new DataSet();
        Htparam.Clear();
        Htparam.Add("@MapCode", strmapcode);
        ds = obDAL.GetDataSetForPrcDBConn("Prc_EditMemFilterDef", Htparam, "SAIMConnectionString");
        DataTable dtGrdPremiumWeight = ds.Tables[0];
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowNoResultFound(dtGrdPremiumWeight, GrdVPSWeight);
        }
        else
        {
            GrdVPSWeight.DataSource = ds;
            GrdVPSWeight.DataBind();
        }
    }

    protected void btnCancelAll_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["KpiCode"] != null)
        {
            Response.Redirect("../KPISearch.aspx", true);
        }
        else
        {
            if (Request.QueryString["RSetKey"] != null)
            {
                Response.Redirect("../CmpSetup.aspx?CmpTyp=" + lblCompTypVal.Text.ToString() + "&CmpCode=" + Request.QueryString["CMPNSTN_CODE"].ToString() + "&CntstCode=" + Request.QueryString["CNTST_CODE"].ToString().Trim()  
                    + "&RSetKey=" + Request.QueryString["RSetKey"].ToString().Trim(), true);
            }
            else
            {
                Response.Redirect("../CmpSetup.aspx?flag=" + "E" + "&Mode=" + "C" + "&Cmptyp=" + "CON" + "&CmpCode=" + Request.QueryString["CMPNSTN_CODE"].ToString() + "&CntstCode=" + Request.QueryString["CNTST_CODE"].ToString().Trim(), true);     //Need to be altered later by akash "&Cmptyp=" + lblCompTypVal.Text.ToString() +
            }
        }
    }
}
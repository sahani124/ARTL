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
using System.Web.Services;
using Newtonsoft.Json;

public partial class Application_Isys_Saim_KPIMapBseSrcFormulaPopUp : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    Hashtable htparam = new Hashtable();
    DataSet dsfill = new DataSet();
    string KPI_CD = string.Empty;
    string SRC_TBL_COL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["KPI_CD"].ToString().Trim() != "" && Request.QueryString["SRC_TBL_COL"].ToString().Trim() != "")
                {
                    KPI_CD = Request.QueryString["KPI_CD"].ToString().Trim();
                    SRC_TBL_COL = Request.QueryString["SRC_TBL_COL"].ToString().Trim();
                }
                bindModal(KPI_CD);
                FillddlColName(ddlmdlOpType, "BindddlOPtype", SRC_TBL_COL, SRC_TBL_COL);
            FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(), ddlmdlOpType.SelectedValue.ToString());

                // ddltmdlColName.Items.Insert(0, new ListItem("Select", ""));
                bindgvMODAL();

                //ddlmdlTblName.SelectedItem.Text = Request.QueryString["SrcTbl"].ToString().Trim();
                //  ddlmdlTblName.SelectedItem.Value=Request.QueryString["SrcTbl"].ToString().Trim();
                //  FillddlSAIMWRK(ddltmdlColName, "MAP_COL", ddlmdlTblName.SelectedItem.Text);
                // Fillddl(ddlmdlOpType, "OpType", "");
                //FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(), ddlmdlOpType.SelectedValue.ToString());
                //ddltmdlColName.SelectedValue = SRC_TBL_COL;

            }
            txtFormCALC.Attributes.Add("readonly", "readonly");
            txtConcat.Attributes.Add("readonly", "readonly");
            //bindgvMODAL();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void Fillddl(DropDownList ddl, string LookupCode, string synNAME)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            ht.Add("@synmNAME", synNAME);
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetINTSTFillUPddlVal", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "paramdesc";
                ddl.DataValueField = "paramval";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "Fillddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillddlSynm(DropDownList ddl, string LookupCode, string kpicode)
    {
        try
        {
            ddl.Items.Clear();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@FLAG", LookupCode.ToString().Trim());
            htParam.Add("@kpi_code", kpicode);
            //ds = objDal.GetDataSetForPrc("PRC_DDLDATBINDTBL", htParam);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DDLDATBINDTBL", htParam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "TBL_NAME";
                ddl.DataValueField = "OBJ_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "FillddlSynm", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillddlSAIMWRK(DropDownList ddl, string LookupCode, string TblNAME)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@flag", LookupCode);
            ht.Add("@OBJ_ID_SRC", TblNAME);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_BIND_DDL_SRC_TBL_COL", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "FillddlSAIMWRK", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void FillddlColName(DropDownList ddl, string LookupCode, string TblNAME,string OpTypeVal)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@flag", LookupCode);
            ht.Add("@OBJ_ID_SRC", TblNAME);
            ht.Add("@OpTypeVal", OpTypeVal);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_BIND_DDL_SRC_TBL_COL_OpType", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
                
            }
            else
            {
                if (ddl.ID == "ddlmdlOpType")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Operation type can not be performed.');", true);


                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doCancelClick();", true);
                }
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "FillddlColName", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    #region MODAL
    public void bindModal(string KPI_CD)
    {
        try
        {
            FillddlSynm(ddlmdlTblName, "MAP_S", KPI_CD);

         //   Bindddl(ddlSrctbl, "S");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "bindModal", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlmdlTblName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(), ddlmdlOpType.SelectedValue.ToString());
    }

    protected void lnkbtnModalSave_Click(object sender, EventArgs e)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@TBL_NAME", ddlmdlTblName.SelectedValue);
            htparam.Add("@COL_NAME", ddltmdlColName.SelectedValue);
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            htparam.Add("@FORMULA", "");
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@FLAG", "I");
            htparam.Add("@OPRTN_TYPE", ddlmdlOpType.SelectedValue.ToString());
            //htparam.Add("@EFF_DTIM", txtEffFrom.Text);
            //htparam.Add("@CSE_DTIM", txtEffTo.Text);
            //htparam.Add("@STATUS", ddlStatus.SelectedValue);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_INS_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);
            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    ///ScriptManager.RegisterStartupScript(this, this.GetType(), popup, "alert('Data Deleted Successfully.');", true);
                    ///
                   // hdnTabIndex.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully.');", true);

                }

                else if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
                {
                    ///ScriptManager.RegisterStartupScript(this, this.GetType(), popup, "alert('Data Deleted Successfully.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already exists.');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }

            }

            bindgvMODAL();
            lnkbtnModalClear_Click(EventArgs.Empty, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnkbtnModalSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindgvMODAL()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);
            gvMODAL.DataSource = dsfill;
            gvMODAL.DataBind();
            if (dsfill.Tables[0].Rows.Count > 0)
            {
                gvMODAL.DataSource = dsfill;
                gvMODAL.DataBind();
                ViewState["grid"] = dsfill.Tables[0];
                if (gvMODAL.PageCount > 1)
                {
                    btmModalnxt.Enabled = true;
                }
                else
                {
                    btmModalnxt.Enabled = false;
                }
                hdnPCount.Value = dsfill.Tables[0].Rows.Count.ToString().Trim();
                if (hdnTabIndex.Value.ToString() == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('1','" + dsfill.Tables[0].Rows.Count + "');", true);
                    lnbtnSaveConcat.Enabled = dsfill.Tables[0].Rows[0]["Formula"].ToString().Trim() != "" ? false : true;
                }
                else if (hdnTabIndex.Value.ToString() == "2")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('2','" + dsfill.Tables[0].Rows.Count + "');", true);
                    lnkbtnCalc.Enabled = dsfill.Tables[0].Rows[0]["Formula"].ToString().Trim() != "" ? false : true;
                }
                if (hdnTabIndex.Value.ToString() == "11")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('11','" + dsfill.Tables[0].Rows.Count + "');", true);
                    lnbtnSaveConcat.Enabled = dsfill.Tables[0].Rows[0]["Formula"].ToString().Trim() != "" ? false : true;
                }
                else if (hdnTabIndex.Value.ToString() == "22")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('22','" + dsfill.Tables[0].Rows.Count + "');", true);
                    lnkbtnCalc.Enabled = dsfill.Tables[0].Rows[0]["Formula"].ToString().Trim() != "" ? false : true;
                }
            }

            else
            {
                lnkbtnCalc.Enabled = false;
                lnbtnSaveConcat.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "bindgvMODAL", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btmModalprev_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvMODAL.PageIndex;
            gvMODAL.PageIndex = pageIndex - 1;
            bindgvMODAL();
            txtmodalPage.Text = Convert.ToString(Convert.ToInt32(txtmodalPage.Text) - 1);
            if (txtmodalPage.Text == "1")
            {
                btmModalprev.Enabled = false;
            }
            else
            {
                btmModalprev.Enabled = true;
            }
            btmModalnxt.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "btmModalprev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btmModalnxt_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvMODAL.PageIndex;
            gvMODAL.PageIndex = pageIndex + 1;
            bindgvMODAL();
            txtmodalPage.Text = Convert.ToString(Convert.ToInt32(txtmodalPage.Text) + 1);
            btmModalprev.Enabled = true;
            if (txtmodalPage.Text == Convert.ToString(gvMODAL.PageCount))
            {
                btmModalnxt.Enabled = false;
            }
            int page = gvMODAL.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "btmModalnxt_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvMODAL_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtmodalPage.Text))
            {
                btmModalprev.Enabled = false;
                txtmodalPage.Text = "1";
                btmModalnxt.Enabled = true;
            }
            else
            {
                btmModalnxt.Enabled = false;
            }
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "gvMODAL_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvMODAL_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public void bindcalculate()
    {
        try
        {
            Table divcalc = new Table();
            TableRow tRowT = new TableRow();
            divcalc.Rows.Add(tRowT);
            for (int T = 0; T < 3; T++)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Delete";
                //btn.Click += new EventHandler(BtnDelete_Click);
                btnCell.Controls.Add(btn);
                tRowT.Cells.Add(btnCell);
            }
            //foreach (TableRow row in Table1.Rows)
            //{
            //    TableCell btnCell = new TableCell();

            //    Button btn = new Button();
            //    btn.Text = "Delete";
            //    //btn.Click += new EventHandler(BtnDelete_Click);
            //    btnCell.Controls.Add(btn);

            //    row.Cells.Add(btnCell);
            //}

        }

        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "bindcalculate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion MODAL

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            Label lblSTBL_NAME = row.FindControl("lblSTBL_NAME") as Label;
            Label lblCOL_NAME = row.FindControl("lblCOL_NAME") as Label;
            Label lblPARAMETER = row.FindControl("lblPARAMETER") as Label;
            Label lblSRC_TBL_COL = row.FindControl("lblSRC_TBL_COL") as Label;
            Label lblFORMULA = row.FindControl("lblFORMULA") as Label;
            Label lblOpTypeDesc = row.FindControl("lblOpTypeDesc") as Label;//hdnOpType
            HiddenField hdnOpType = row.FindControl("hdnOpType") as HiddenField;//
            HiddenField hdnTblNm = row.FindControl("hdnTblNm") as HiddenField;//


            //if (hdnTabIndex.Value.ToString() == "1")
            //{
            //    ddlmdlTblName.SelectedValue = lblSTBL_NAME.Text;

            //    Fillddl(ddlmdlOpType, "OpType", "");
            //    ddlmdlOpType.SelectedValue = hdnOpType.Value;

            //    FillddlSAIMWRK(ddltmdlColName, "MAP_COL", ddlmdlTblName.SelectedItem.Text);

            //    ddltmdlColName.SelectedValue = lblCOL_NAME.Text;


            //    txtConcat.Text = lblFORMULA.Text;
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('1','" + hdnPCount.Value + "');", true);
            //    lnbtnUpdConcat.Attributes.Add("style", "display:inline-block;");
            //    lnbtnSaveConcat.Attributes.Add("style", "display:none;");
            //}
            //else if (hdnTabIndex.Value.ToString() == "2")
            //{
            //    ddlmdlTblName.SelectedValue = lblSTBL_NAME.Text;
            //    Fillddl(ddlmdlOpType, "OpType", "");
            //    ddlmdlOpType.SelectedValue = hdnOpType.Value;

            //    FillddlSAIMWRK(ddltmdlColName, "MAP_COL", ddlmdlTblName.SelectedItem.Text);
            //    ddltmdlColName.SelectedValue = lblCOL_NAME.Text;

            //    txtFormCALC.Text = lblFORMULA.Text;

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('2','" + hdnPCount.Value + "');", true);
            //    lnkbtnCalcUpd.Attributes.Add("style", "display:inline-block;");
            //    lnkbtnCalc.Attributes.Add("style", "display:none;");
            //}
            if (hdnOpType.Value.ToString() == "1")
            {
                ddlmdlTblName.SelectedValue = hdnTblNm.Value;
                //   FillddlSAIMWRK(ddltmdlColName, "MAP_COL", ddlmdlTblName.SelectedItem.Text);
                //  Fillddl(ddlmdlOpType, "OpType", "");
                FillddlColName(ddlmdlOpType, "BindddlOPtype", Request.QueryString["SRC_TBL_COL"].ToString().Trim(), Request.QueryString["SRC_TBL_COL"].ToString().Trim());
                ddlmdlOpType.SelectedValue = hdnOpType.Value;

                FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(), ddlmdlOpType.SelectedValue.ToString());

                ddltmdlColName.SelectedValue = lblCOL_NAME.Text;
               
                txtConcat.Text = lblFORMULA.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('11','" + hdnPCount.Value + "');", true);
                lnbtnUpdConcat.Attributes.Add("style", "display:inline-block;");
                lnbtnSaveConcat.Attributes.Add("style", "display:none;");
            }
            else if (hdnOpType.Value.ToString() == "2")
            {
                ddlmdlTblName.SelectedValue = hdnTblNm.Value;
                //Fillddl(ddlmdlOpType, "OpType", "");
                FillddlColName(ddlmdlOpType, "BindddlOPtype", Request.QueryString["SRC_TBL_COL"].ToString().Trim(), Request.QueryString["SRC_TBL_COL"].ToString().Trim());
                ddlmdlOpType.SelectedValue = hdnOpType.Value;

                //  FillddlSAIMWRK(ddltmdlColName, "MAP_COL", ddlmdlTblName.SelectedItem.Text);
                FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(), ddlmdlOpType.SelectedValue.ToString());
                ddltmdlColName.SelectedValue = lblCOL_NAME.Text;
                txtFormCALC.Text = lblFORMULA.Text;
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('22','" + hdnPCount.Value + "');", true);
                lnkbtnCalcUpd.Attributes.Add("style", "display:inline-block;");
                lnkbtnCalc.Attributes.Add("style", "display:none;");
            }
            ddlmdlTblName.Enabled = false;
            ddltmdlColName.Enabled = false;
            ddlmdlOpType.Enabled = false;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnkEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkbtnCalc_Click(object sender, EventArgs e)
    {
        try
        {

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("@TBL_NAME", "");
            htparam.Add("@COL_NAME", "");
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            htparam.Add("@FORMULA", txtFormCALC.Text);
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@FLAG", "U");
            htparam.Add("@OPRTN_TYPE", ddlmdlOpType.SelectedValue.ToString());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_INS_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);
            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    //hdnTabIndex.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Formula added Successfully.');", true);
                }
              
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }


            }

            bindgvMODAL();
            lnkbtnCalc.Enabled = false;
            lnkbtnCalcClr_Click(EventArgs.Empty,EventArgs.Empty);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnkbtnCalc_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkbtnModalClear_Click(object sender, EventArgs e)
    {
        ddlmdlTblName.SelectedIndex = 0;
        ddltmdlColName.SelectedIndex = 0;
        ddlmdlOpType.SelectedIndex = 0;
        bindgvMODAL();
    }

    protected void lnkbtnCalcUpd_Click(object sender, EventArgs e)
    {
        try
        {

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("@TBL_NAME", "");
            htparam.Add("@COL_NAME", "");
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@FORMULA", txtFormCALC.Text);
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            htparam.Add("@FLAG", "U");
            htparam.Add("@OPRTN_TYPE", ddlmdlOpType.SelectedValue.ToString());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_INS_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);

            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    //hdnTabIndex.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Formula Updated Successfully.');", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }
               

            }


            bindgvMODAL();
            lnkbtnCalcUpd.Attributes.Add("style", "display:none;");
            lnkbtnCalc.Attributes.Add("style", "display:inline-block;");
            txtFormCALC.Text = "";
            ddlmdlTblName.Enabled = true;
            ddltmdlColName.Enabled = true;
            ddlmdlOpType.Enabled = true;
            ddlmdlOpType.SelectedIndex = 0;
            ddlmdlTblName.SelectedIndex = 0;
            ddltmdlColName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnkbtnCalcUpd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkbtnCalcClr_Click(object sender, EventArgs e)
    {
        txtFormCALC.Text = "";
        bindgvMODAL();
    }

    protected void lnbtnUpdConcat_Click(object sender, EventArgs e)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("@TBL_NAME", "");
            htparam.Add("@COL_NAME", "");
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@FORMULA", txtConcat.Text);
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            htparam.Add("@FLAG", "U");
            htparam.Add("@OPRTN_TYPE", ddlmdlOpType.SelectedValue.ToString());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_INS_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);
            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                   // hdnTabIndex.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Formula Updated Successfully.');", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }
                //bindgvMODAL();

            }
            bindgvMODAL();
            lnbtnUpdConcat.Attributes.Add("style", "display:none;");
            lnbtnSaveConcat.Attributes.Add("style", "display:inline-block;");
            txtConcat.Text = "";
            ddlmdlTblName.Enabled = true;
            ddltmdlColName.Enabled = true;
            ddlmdlTblName.SelectedIndex = 0;
            ddltmdlColName.SelectedIndex = 0;
            ddlmdlOpType.Enabled = true;
            ddlmdlOpType.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnbtnUpdConcat_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnbtnSaveConcat_Click(object sender, EventArgs e)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
            htparam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
            htparam.Add("@TBL_NAME", "");
            htparam.Add("@COL_NAME", "");
            htparam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
            htparam.Add("@FORMULA", txtConcat.Text);
            htparam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@FLAG", "U");
            htparam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
            htparam.Add("@OPRTN_TYPE", ddlmdlOpType.SelectedValue.ToString());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_INS_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htparam);
            if (dsfill.Tables.Count > 0 && dsfill.Tables[0].Rows.Count > 0)
            {
                if (dsfill.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
                {
                    //hdnTabIndex.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Formula added Successfully.');", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
                }


            }
            bindgvMODAL();
            lnkbtnCalc.Enabled = false;
            lnkbtnCalcClr_Click(EventArgs.Empty, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "KPIMapBseSrcFormulaPopUp", "lnbtnSaveConcat_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnbtnClrConcat_Click(object sender, EventArgs e)
    {
        txtConcat.Text = "";
        bindgvMODAL();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        bindgvMODAL();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        bindgvMODAL();
    }

    protected void lnkGRIDDel_Click(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        HiddenField hdnSEQNO = (HiddenField)row.FindControl("hdnSEQNO");
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "DELETE");
        htParam.Add("@SEQNO", hdnSEQNO.Value);
        htParam.Add("@KPI_BSE_SRC_MAP_CODE", Request.QueryString["MapCode"].ToString().Trim());
        htParam.Add("KPI_CD", Request.QueryString["KPI_CD"].ToString().Trim());
        htParam.Add("@SRC_TBL_COL", Request.QueryString["SRC_TBL_COL"].ToString().Trim());
        htParam.Add("@SrcTbl", Request.QueryString["SrcTbl"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GET_MST_KPI_BSE_SRC_COL_MAP_SU_WITH_PARAM", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "0")
            {
               // hdnTabIndex.Value = "1";
                ddlmdlTblName.Enabled = true;
                ddltmdlColName.Enabled = true;
                ddlmdlOpType.Enabled = true;
                ddlmdlOpType.SelectedIndex = 0;
                ddlmdlTblName.SelectedIndex = 0;
                ddltmdlColName.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Parameter deleted sucessfully , Please reset the formula.');", true);


            }
            else if (ds.Tables[0].Rows[0]["Response"].ToString().Trim() == "2")
            {
                // hdnTabIndex.Value = "1";
                ddlmdlTblName.Enabled = true;
                ddltmdlColName.Enabled = true;
                ddlmdlOpType.Enabled = true;
                ddlmdlOpType.SelectedIndex = 0;
                ddlmdlTblName.SelectedIndex = 0;
                ddltmdlColName.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Parameter deleted sucessfully , Please reset the formula.');", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Something went wrong');", true);
            }


            lnkbtnModalClear_Click(EventArgs.Empty, EventArgs.Empty);
            bindgvMODAL();

        }
    }



    protected void ddlmdlOpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlColName(ddltmdlColName, "OpType", ddlmdlTblName.SelectedValue.ToString().Trim(),ddlmdlOpType.SelectedValue.ToString());
        if(ddlmdlOpType.SelectedValue=="1")
        {
            hdnTabIndex.Value = "11";
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('11','0');", true);
        }
        if (ddlmdlOpType.SelectedValue == "2")
        {
            hdnTabIndex.Value = "22";
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "fnSetTabs('22','0');", true);
        }
    }
}
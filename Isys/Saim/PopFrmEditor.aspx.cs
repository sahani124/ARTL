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
using System.Windows.Forms;

public partial class Application_ISys_Saim_PopFrmEditor : BaseClass
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
            if (Request.QueryString["frmltrg"] != null)
            {
                if (Request.QueryString["frmltrg"].ToString().Trim() == "FRMLTRG")
                {
                    divfrmltrg.Visible = true;
                    txtFrmlTrg.Text = "=ROUND((WRP PREMIUM - 100000)/50000,0)*3.00";
                    txtFrmlTrg.ReadOnly = true;
                    divfrmedthdr.Visible = false;
                    tblfrml.Visible = false;
                    tblfrmltxt.Visible = true;
                    btnSaveFrml.Visible = false;
                    tblbtn.Visible = false;
                }
                else if (Request.QueryString["frmltrg"].ToString().Trim() == "SETFRML")
                {
                    txtFrmlTrg.Text = "";
                    txtFrmlTrg.ReadOnly = false;
                    divfrmedthdr.Visible = false;
                    divfrmltrg.Visible = true;
                    tblfrml.Visible = true;
                    tblfrmltxt.Visible = true;
                    tblbtn.Visible = false;
                    FillDropDowns(ddlFunckeyTrg, "7");
                    FillddlKPI(ddlKPICode, "Prc_KPISearch", "1", "KPI_DESC_01", "KPI_CODE");
                }
            }
            else
            {
                divfrmedthdr.Visible = true;
                divfrmltrg.Visible = false;
                tblfrml.Visible = false;
                tblfrmltxt.Visible = false;
                tblbtn.Visible = true;
                FillDropDowns(ddlDtFunKey, "7");
                FillDropDowns(ddlDtOperator, "35");
                BindGrid();
                BindGridDDL();
                FillData();
            }
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected void ddlDtLstKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
        DropDownList ddlDtLstKey = (DropDownList)grd.FindControl("ddlDtLstKey");
        DropDownList ddlDtFldKey = (DropDownList)grd.FindControl("ddlDtFldKey");
        if (ddlDtLstKey.SelectedValue != "")
        {
            FillDataField(ddlDtFldKey, ddlDtLstKey);
        }
        else
        {
            ddlDtFldKey.Items.Clear();
            ddlDtFldKey.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        ddlDtLstKey.Focus();
    }
    protected void FillData()
    {

        try
        {

            foreach (GridViewRow gvrow in dgFormula.Rows)
            {
                DropDownList ddlDtFuncKey = (DropDownList)gvrow.FindControl("ddlDtFuncKey");
                DropDownList ddlDtLstKey = (DropDownList)gvrow.FindControl("ddlDtLstKey");
                DropDownList ddlDtFldKey = (DropDownList)gvrow.FindControl("ddlDtFldKey");

                //FillDropDowns(ddlDtFuncKey, "7");
                //FillDropDowns(ddlDtLstKey, "5");
                //FillDropDowns(ddlDtFldKey, "6");
                //ds.Clear();
                htParam.Clear();
                if (Request.QueryString["kpicode"] != null)
                {
                    htParam.Add("@KPI_CODE", Request.QueryString["kpicode"].ToString().Trim());
                }
                ds = objDal.GetDataSetForPrc_SAIM("Prc_getKPI", htParam);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlDtLstKey.SelectedItem.Text = ds.Tables[0].Rows[0]["DATA_LIST_KEY"].ToString().Trim();
                    ddlDtFuncKey.SelectedItem.Text = ds.Tables[0].Rows[0]["DATA_FUNCTION_KEY"].ToString().Trim();
                    ddlDtFldKey.SelectedItem.Text = ds.Tables[0].Rows[0]["DATA_FLD_KEY"].ToString().Trim();
                    ddlDtLstKey.Enabled=true;
                    ddlDtFuncKey.Enabled = true;
                    ddlDtFldKey.Enabled = true;

                }
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopFrmEditor", "FillData", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
                      
     
    }

    protected void FillDataField(DropDownList ddl, DropDownList ddl1)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@TblCode", ddl1.SelectedValue.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetDataLstKey", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string funckey = String.Empty, lstkey = String.Empty, fldkey = String.Empty;
        string funckeycd = String.Empty, lstkeycd = String.Empty, fldkeycd = String.Empty;
        for (int intRowCount = 0; intRowCount <= dgFormula.Rows.Count - 1; intRowCount++)
        {
            DropDownList ddlDtFuncKey = (DropDownList)dgFormula.Rows[intRowCount].Cells[0].FindControl("ddlDtFuncKey");
            DropDownList ddlDtLstKey = (DropDownList)dgFormula.Rows[intRowCount].Cells[1].FindControl("ddlDtLstKey");
            DropDownList ddlDtFldKey = (DropDownList)dgFormula.Rows[intRowCount].Cells[2].FindControl("ddlDtFldKey");

            funckey = ddlDtFuncKey.SelectedItem.Text.ToString().Trim() + "(";
            lstkey = ddlDtLstKey.SelectedItem.Text.ToString().Trim() + ".";
            fldkey = ddlDtFldKey.SelectedItem.Text.ToString().Trim() + ")";

            funckeycd = GetFrmlCode(ddlDtFuncKey, "17").ToString().Trim() + "(";
            lstkeycd = GetFrmlCode(ddlDtLstKey, "18").ToString().Trim() + ".";
            fldkeycd = GetFrmlCode(ddlDtFldKey, "19").ToString().Trim() + ")";

            if (intRowCount > 0)
            {
                hdnFormula.Value = hdnFormula.Value.ToString().Trim() + ddlDtOperator.SelectedValue.ToString().Trim() + funckey + lstkey + fldkey;
                hdnFormCode.Value = hdnFormCode.Value.ToString().Trim() + ddlDtOperator.SelectedValue.ToString().Trim() + funckeycd + lstkeycd + fldkeycd;
            }
            else
            {
                hdnFormula.Value = hdnFormula.Value.ToString().Trim() + funckey + lstkey + fldkey;
                hdnFormCode.Value = hdnFormCode.Value.ToString().Trim() + funckeycd + lstkeycd + fldkeycd;
            }
            Hashtable htParam1 = new Hashtable();
            htParam1.Add("@KPI_CODE", Request.QueryString["kpicode"].ToString().Trim());
            htParam1.Add("@DFKey", ddlDtFuncKey.SelectedValue.ToString().Trim());
            htParam1.Add("@DLISTKEY", ddlDtLstKey.SelectedValue.ToString().Trim());
            htParam1.Add("@DFLDKEY", ddlDtFldKey.SelectedValue.ToString().Trim());
            htParam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_InsUpdKPIFormula", htParam1);
        }
        Session["frml"] = hdnFormula.Value.ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "doOk('" + funckey.ToString().Trim() + "','" + lstkey.ToString().Trim() + "','" + fldkey.ToString().Trim() + "','" + hdnFormula.Value.ToString().Trim() + "','" + hdnFormCode.Value.ToString().Trim() + "');", true);
       
    }

    protected void ddlDtFuncKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlDtFldKey_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BindGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DBFUNCKEY");
        dt.Columns.Add("DBLSTKEY");
        dt.Columns.Add("DBFLDKEY");
        DataRow dr;
        
        if (ddlDtFunKey.SelectedValue == "1007")
        {
            for (int i = 0; i <= 1; i++)
            {
                dr = dt.NewRow();
                dr["DBFUNCKEY"] = "";
                dr["DBLSTKEY"] = "";
                dr["DBFLDKEY"] = "";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr["DBFUNCKEY"] = "";
            dr["DBLSTKEY"] = "";
            dr["DBFLDKEY"] = "";
            dt.Rows.Add(dr);
        }
        
        dgFormula.DataSource = dt;
        dgFormula.DataBind();
    }
    protected void ddlDtFunKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        BindGridDDL();
        if (ddlDtFunKey.SelectedValue == "1007")
        {
            ddlDtOperator.Enabled = true;
        }
        else
        {
            ddlDtOperator.Enabled = false;
        }
    }

    protected void BindGridDDL()
    {
        foreach (GridViewRow gvrow in dgFormula.Rows)
        {
            DropDownList ddlDtFuncKey = (DropDownList)gvrow.FindControl("ddlDtFuncKey");
            DropDownList ddlDtLstKey = (DropDownList)gvrow.FindControl("ddlDtLstKey");
            DropDownList ddlDtFldKey = (DropDownList)gvrow.FindControl("ddlDtFldKey");

            FillDropDowns(ddlDtFuncKey, "7");
            FillDropDowns(ddlDtLstKey, "5");
            ddlDtFldKey.Items.Insert(0, new ListItem("--SELECT--", ""));

            if (ddlDtFunKey.SelectedValue == "")
            {
                ddlDtFuncKey.Enabled = false;
                ddlDtLstKey.Enabled = false;
                ddlDtFldKey.Enabled = false;

                ddlDtFuncKey.SelectedValue = "";
                ddlDtLstKey.SelectedValue = "";
                ddlDtFldKey.SelectedValue = "";
            }
            else
            {
                ddlDtFuncKey.Enabled = true;
                ddlDtLstKey.Enabled = true;
                ddlDtFldKey.Enabled = true;
            }

            if (ddlDtFunKey.SelectedValue == "1007")
            {
                ddlDtFuncKey.SelectedValue = "";
            }
            else
            {
                ddlDtFuncKey.SelectedValue = ddlDtFunKey.SelectedValue.ToString().Trim();
            }
        }
    }

    protected string GetFrmlCode(DropDownList ddl, string flag)
    {
        DataSet dsFrml = new DataSet();
        Hashtable htFrml = new Hashtable();
        string frmlcode = string.Empty;
        ds.Clear();
        htFrml.Clear();
        htFrml.Add("@CODE", ddl.SelectedValue.ToString().Trim());
        htFrml.Add("@Flag", flag.ToString().Trim());
        dsFrml = objDal.GetDataSetForPrc_SAIM("Prc_FillMstVals", htFrml);
        if (dsFrml.Tables.Count > 0)
        {
            if (dsFrml.Tables[0].Rows.Count > 0)
            {
                frmlcode = dsFrml.Tables[0].Rows[0]["CODE"].ToString().Trim();
            }
        }
        else
        {
            ds = null;
        }
        return frmlcode;
    }
    protected void ddlFunckeyTrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFrmlTrg.Text = "=" + ddlFunckeyTrg.SelectedItem.Text.ToString().Trim() + "(";
    }
    protected void ddlKPICode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFrmlTrg.Text = txtFrmlTrg.Text + ddlKPICode.SelectedItem.Text.ToString().Trim() + ")";
    }

    protected void FillddlKPI(DropDownList ddl, string proc, string flag, string text, string value)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", flag.Trim());
        ddl.Items.Clear();
        drRead = objDal.Common_exec_reader_prc_SAIM(proc.ToString().Trim(), htParam);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }
}
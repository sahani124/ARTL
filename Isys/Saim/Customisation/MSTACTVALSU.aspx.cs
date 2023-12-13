using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using ClassFiles;

public partial class Application_Isys_Saim_Customisation_MSTACTVALSU : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strCompCode = null;
    //string sUserId = null;
    string sUserId = string.Empty;
    string KPICode, ACT_TYP, BSD_ON_TBL_TYP = string.Empty;
    string MAP_CODE = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
            try
            {
                //FillMapDdl(ddlMappedCd);

                //Fillddl(ddlAuthFlg, "AuthFlg");
                //Fillddl(ddlFR, "FactorFlg");

                //ddlBaseTbl.Items.Insert(0, new ListItem("Select", "0"));
                //ddlCol.Items.Insert(0, new ListItem("Select", "0"));

               
                //txtEffDtFrm.ReadOnly = true;

                if (Request.QueryString["KPICode"].ToString().Trim() != "" && Request.QueryString["ACT_TYP"].ToString().Trim() != "" && Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim() != "")
                {
                    KPICode = Request.QueryString["KPICode"].ToString().Trim();
                    ACT_TYP = Request.QueryString["ACT_TYP"].ToString().Trim();
                   BSD_ON_TBL_TYP = Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim();
                   // 

                }

               
                BindMappedCode(KPICode);
                BindSearchGrid();
            }
                
            catch (Exception ex)
            {
                throw ex;
            }
        }
       // BindSearchGrid();
    }




    protected void btnCnclCmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("IRULSU.aspx");
    }

    protected void Fillddl(DropDownList ddl, string FLAG)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            Hashtable HTS = new Hashtable();
            HTS.Clear();
            ddl.Items.Clear();
            HTS.Add("@FLAG", "");
            HTS.Add("@KPI_CODE", "");
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", HTS);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("SELECT", "0"));
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


    protected void FillddlFCTR(DropDownList ddl, string FLAG)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@FLAG", FLAG);
            ht.Add("@KPI_CODE", "");
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "FCTR_DESC";
                ddl.DataValueField = "FCTR_TYP_CODE";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("SELECT", "0"));


            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillTable(DropDownList ddl, string BSD_ON_TBL_TYP, string KPICode)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@Flag", BSD_ON_TBL_TYP);
            HTwc.Add("@KPI_CODE", KPICode.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("--SELECT--", "0"));
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
    protected void FillBase_Src_Colms(DropDownList ddl, string TBL_NAME, string FLAG)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@TBL_NAME", TBL_NAME);
            HTwc.Add("@FLAG", FLAG);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_COL_NAMES_FOR_VAL_FCT", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", "0"));
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



    //protected void FillMapDdl(DropDownList ddl)
    //{
    //    try
    //    {
         
    //        Hashtable ht = new Hashtable();

    //        drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_MapCodeValueFact", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddl.DataSource = drRead;
    //            ddl.DataTextField = "ParamDesc01";
    //            ddl.DataValueField = "ParamValue";
    //            ddl.DataBind();
    //            ddl.Items.Insert(0, new ListItem("Select", "0"));
    //        }



          

    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    protected void BindMappedCode(string KPICode)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@KPI_CODE", KPICode.ToString());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAPPED_CD_VAL_FACT", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                MAP_CODE = ds.Tables[0].Rows[0]["MAPPED_CODE"].ToString().Trim();
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

    protected void FillBase_LookUpCode(DropDownList ddl, string FLAG)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@TBL_NAME", "");
            HTwc.Add("@FLAG", FLAG);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_COL_NAMES_FOR_VAL_FCT", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
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

    protected void BindSearchGrid()
    {
        try
        {

            ds.Clear();
            htParam.Clear();

            htParam.Add("@VAL_DESC", TextSrValDesc.Text);
            htParam.Add("@VAL_CODE", TextSrVal.Text);
            htParam.Add("@IS_SCOPE", Request.QueryString["ACT_TYP"].ToString());
            htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString());

            //if (ddlMappedCd.SelectedValue.ToString() == "0")
            //{
            //    htParam.Add("@map_code", "");
            //}
            //else
            //{
            //    htParam.Add("@map_code", ddlMappedCd.SelectedValue);
            //}
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_FACTORDATA", htParam); //test proc PRC_GET_FACTORDATA_megha

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();
                ViewState["grid"] = ds.Tables[0];


                if (grvaddedresult.PageCount == 1)
                {
                    txtPage.Text = "1";
                    btnnext.Enabled = false;
                    btnprevious.Enabled = false;

                }

                if (grvaddedresult.PageCount > 1)
                {

                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }


            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();
                int columncount = grvaddedresult.Rows[0].Cells.Count;
                grvaddedresult.Rows[0].Cells.Clear();
                grvaddedresult.Rows[0].Cells.Add(new TableCell());
                grvaddedresult.Rows[0].Cells[0].ColumnSpan = columncount;
                grvaddedresult.Rows[0].Cells[0].Text = "No Records Found";
                grvaddedresult.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                
            }
           
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindSearchGrid();
            int pageIndex = grvaddedresult.PageIndex;
            //grvaddedresult.PageIndex = pageIndex - 1;


        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void ddlAuthFlg_SelectedIndexChanged(object sender, EventArgs e)
    {
       // FillddlTblDtls(ddlBaseTbl);
    }


  

    protected void ddlBaseTbl_SelectedIndexChanged(object sender, EventArgs e)
    {
       // FillddlColDtls(ddlCol);
    }

    
  
    //protected void FillddlColDtls(DropDownList ddl)
    //{
    //    try
    //    {
    //        ddl.Items.Clear();
    //        Hashtable ht = new Hashtable();
    //        ht.Add("@Table_name", ddlBaseTbl.SelectedItem.Value);
    //        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetTableColumns", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddl.DataSource = drRead;
    //            ddl.DataTextField = "column_Desc";
    //            ddl.DataValueField = "colName";
    //            ddl.DataBind();
    //            ddl.Items.Insert(0, new ListItem("Select", "0"));
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    protected void grvaddedresult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvaddedresult.EditIndex = -1;
        BindSearchGrid();
    }
    protected void grvaddedresult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msgs = string.Empty;
            DataSet ds = new DataSet();
            ds.Clear();

            GridViewRow row = (GridViewRow)grvaddedresult.Rows[e.RowIndex];
            Label lblValCode = (Label)row.FindControl("lblValCode");
             Label LBLSEQNO = (Label)row.FindControl("LBLSEQNO");
             Label lblMappedCd = (Label)row.FindControl("lblMappedCd");
           //  Label lblMappedCd = (Label)row.FindControl("lblMappedCd");

             htParam.Add("@VAL_CODE", lblValCode.Text);
             htParam.Add("@MAPPED_CODE", lblMappedCd.Text);
             htParam.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString());
             htParam.Add("@IS_SCOPE", Request.QueryString["ACT_TYP"].ToString().Trim());
            //htParam.Add("@SEQ_NO", LBLSEQNO.Text);

            //htParam.Add("@Flag", "");

            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_MST_ACT_VAL_SU", htParam);
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record  deleted sucessfully. ');", true);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msgs = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msgs == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record cannot Be Deleted');", true);
                    // return;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Deleted Successfully...!')", true);
                  
                }

            }
            grvaddedresult.EditIndex = -1;
           
            BindSearchGrid();
        }


        catch (Exception ex)
        {
            throw ex;
        }
   }

    //protected void btnUpdate_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

    //        DropDownList ddlIS_FX_RG_FLAG = row.FindControl("ddlIS_FX_RG_FLAG") as DropDownList;
    //        DropDownList ddlSTATUS = row.FindControl("ddlSTATUS") as DropDownList;
    //        DropDownList ddlBaseTableName = row.FindControl("ddlBaseTableName") as DropDownList;
    //        DropDownList ddlBASE_TBL_COL_NAME = row.FindControl("ddlBASE_TBL_COL_NAME") as DropDownList;
    //        DropDownList ddlMaster_TBL_NAME = row.FindControl("ddlMaster_TBL_NAME") as DropDownList;
    //        DropDownList ddlMaster_TBL_COL_NAME = row.FindControl("ddlMaster_TBL_COL_NAME") as DropDownList;
    //        DropDownList ddlMaster_Col_Desc = row.FindControl("ddlMaster_Col_Desc") as DropDownList;

    //        Label LBLSEQNO = row.FindControl("LBLSEQNO") as Label;

            
    //        string strtxtValCode = ((TextBox)row.FindControl("txtValCode")).Text.ToString();
    //       // string strMappedCode = (row.FindControl("ddlMappedCd") as DropDownList).SelectedValue;

    //        string strtxtVAL_DESC = ((TextBox)row.FindControl("txtVAL_DESC")).Text.ToString();
    //        string strddlIS_FX_RG_FLAG = ddlIS_FX_RG_FLAG.SelectedValue.ToString();
    //            //(row.FindControl("ddlIS_FX_RG_FLAG") as DropDownList).SelectedValue;

    //        string strddlSTATUS = (row.FindControl("ddlSTATUS") as DropDownList).SelectedValue;
    //        string strddlBaseTableName = (row.FindControl("ddlBaseTableName") as DropDownList).SelectedValue;
    //        string strddlBASE_TBL_COL_NAME = (row.FindControl("ddlBASE_TBL_COL_NAME") as DropDownList).SelectedValue;

    //        string strddlMaster_TBL_NAME = (row.FindControl("ddlMaster_TBL_NAME") as DropDownList).SelectedValue;
    //        string strddlMaster_TBL_COL_NAME = (row.FindControl("ddlMaster_TBL_COL_NAME") as DropDownList).SelectedValue;
    //        string strddlMaster_Col_Desc = (row.FindControl("ddlMaster_Col_Desc") as DropDownList).SelectedValue;
        
    ////        string strEffDt = ((TextBox)row.FindControl("DateTimeValue")).Text.ToString();
    //     string strCeaseDt = ((TextBox)row.FindControl("txtceasedt")).Text.ToString();


    //     Hashtable ht = new Hashtable();
    //     ht.Add("@VAL_CODE", strtxtValCode);
    //     ht.Add("@VAL_DESC", strtxtVAL_DESC);
    //     ht.Add("@IS_FX_RG_FLAG", strddlIS_FX_RG_FLAG);
    //     ht.Add("@BASE_DATA_TBL_NAME", strddlBaseTableName);
    //     ht.Add("@BASE_DATA_TBL_COL_NAME", strddlBASE_TBL_COL_NAME);
    //     ht.Add("@STATUS", strddlSTATUS);
    //     ht.Add("@CSE_DTIM", Convert.ToDateTime(strCeaseDt.ToString().Trim()));
    //     ht.Add("@MASTER_NAME", strddlMaster_TBL_NAME);
    //     ht.Add("@MASTER_COL_NAME", strddlMaster_TBL_COL_NAME);
    //     ht.Add("@MASTER_COL_DESC", strddlMaster_Col_Desc);
    //     ht.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
    //     ht.Add("@Flag", "UPD");
    //     ht.Add("@SEQ_NO", LBLSEQNO.Text);
    //     DataSet ds = new DataSet();
    //     ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_DEL_MST_ACT_VAL_SU", ht);
    //     ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Updated successfully.');", true);
    //     grvaddedresult.EditIndex = -1;
    ////        BindSearchGrid();
    //       BindSearchGrid();
    //  }


    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void btncancel_click(object sender, EventArgs e)
    {

    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = grvaddedresult.PageIndex;
            grvaddedresult.PageIndex = pageIndex - 1;
            BindSearchGrid();
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
            throw ex;
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = grvaddedresult.PageIndex;
            grvaddedresult.PageIndex = pageIndex + 1;
            BindSearchGrid();
            txtPage.Text = Convert.ToString(grvaddedresult.PageIndex + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(grvaddedresult.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = grvaddedresult.PageCount;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //protected void ddlSTATUS_selectedIndexChanged(object sender, EventArgs e)
    //{
        

    //    GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
    //    DropDownList ddlSTATUS = (DropDownList)row.FindControl("ddlSTATUS");
    //    DropDownList ddlBaseTableName = (DropDownList)row.FindControl("ddlBaseTableName");
    //    Fill_grdDDL_baseTables(ddlBaseTableName, ddlSTATUS.SelectedValue.ToString());
    //}

    protected void ddlBaseTableName_SelectedIndexChanged(object sender, EventArgs e)
    {


        GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlBaseTableName = (DropDownList)row.FindControl("ddlBaseTableName");
        DropDownList ddlBASE_TBL_COL_NAME = (DropDownList)row.FindControl("ddlBASE_TBL_COL_NAME");
        //fill_grdDdl_baseCol(ddlBASE_TBL_COL_NAME, ddlBaseTableName.SelectedValue.ToString());
        FillBase_Src_Colms(ddlBASE_TBL_COL_NAME, ddlBaseTableName.SelectedValue.ToString(),"BS");
    }


   //

    protected void grvaddedresult_RowEditing(object sender, GridViewEditEventArgs e)
    {

        int index = e.NewEditIndex;
        grvaddedresult.EditIndex = e.NewEditIndex;
        this.BindSearchGrid();
        grvaddedresult.EditIndex = e.NewEditIndex;

        
        HiddenField hdnIS_FX_RG_FLAG = grvaddedresult.Rows[index].FindControl("hdnIS_FX_RG_FLAG") as HiddenField;
        HiddenField hdnSTATUS = grvaddedresult.Rows[index].FindControl("hdnSTATUS") as HiddenField;
        HiddenField hdnddlBaseTableName = grvaddedresult.Rows[index].FindControl("hdnddlBaseTableName") as HiddenField;
        HiddenField hdnBASE_DATA_TBL_COL_NAME = grvaddedresult.Rows[index].FindControl("hdnBASE_DATA_TBL_COL_NAME") as HiddenField;
        HiddenField hdnMaster_TBL_NAME = grvaddedresult.Rows[index].FindControl("hdnMaster_TBL_NAME") as HiddenField;
        HiddenField hdnMasterDATA_TBL_COL_NAME = grvaddedresult.Rows[index].FindControl("hdnMasterDATA_TBL_COL_NAME") as HiddenField;
        HiddenField hdnMaster_Col_Desc = grvaddedresult.Rows[index].FindControl("hdnMaster_Col_Desc") as HiddenField;
        HiddenField hdn_lookup = grvaddedresult.Rows[index].FindControl("hdn_lookup") as HiddenField;

        DropDownList ddlIS_FX_RG_FLAG = grvaddedresult.Rows[index].FindControl("ddlIS_FX_RG_FLAG") as DropDownList;
        DropDownList ddlSTATUS = grvaddedresult.Rows[index].FindControl("ddlSTATUS") as DropDownList;
        DropDownList ddlBaseTableName = grvaddedresult.Rows[index].FindControl("ddlBaseTableName") as DropDownList;
        DropDownList ddlBASE_TBL_COL_NAME = grvaddedresult.Rows[index].FindControl("ddlBASE_TBL_COL_NAME") as DropDownList;
        DropDownList ddlMaster_TBL_NAME = grvaddedresult.Rows[index].FindControl("ddlMaster_TBL_NAME") as DropDownList;
        DropDownList ddlMaster_TBL_COL_NAME = grvaddedresult.Rows[index].FindControl("ddlMaster_TBL_COL_NAME") as DropDownList;
        DropDownList ddlMaster_Col_Desc = grvaddedresult.Rows[index].FindControl("ddlMaster_Col_Desc") as DropDownList;
        TextBox txtVAL_DESC = grvaddedresult.Rows[index].FindControl("txtVAL_DESC") as TextBox;
        TextBox txtceasedt = grvaddedresult.Rows[index].FindControl("txtceasedt") as TextBox; 
       DropDownList ddllookup= grvaddedresult.Rows[index].FindControl("ddllookup") as DropDownList;

        FillddlFCTR(ddlIS_FX_RG_FLAG, "FCT");
        Fillddl(ddlSTATUS,"");
        FillTable(ddlBaseTableName, Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim(), Request.QueryString["KPICode"].ToString());
        FillTable(ddlMaster_TBL_NAME, "M", "");
        
        ddlIS_FX_RG_FLAG.SelectedValue = hdnIS_FX_RG_FLAG.Value;
         ddlSTATUS.SelectedValue= hdnSTATUS.Value;
        
        string strBaseTableName = hdnddlBaseTableName.Value;
         ddlBaseTableName.SelectedValue = strBaseTableName;
         ddlMaster_TBL_NAME.SelectedValue = hdnMaster_TBL_NAME.Value;

         FillBase_Src_Colms(ddlBASE_TBL_COL_NAME, ddlBaseTableName.SelectedValue.ToString(),"BS");
         FillBase_Src_Colms(ddlMaster_TBL_COL_NAME, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
         FillBase_Src_Colms(ddlMaster_Col_Desc, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
         FillBase_LookUpCode(ddllookup, "L");

          ddlBASE_TBL_COL_NAME.SelectedValue = hdnBASE_DATA_TBL_COL_NAME.Value;
          ddlMaster_TBL_COL_NAME.SelectedValue = hdnMasterDATA_TBL_COL_NAME.Value;
          ddlMaster_Col_Desc.SelectedValue = hdnMaster_Col_Desc.Value;
          ddllookup.SelectedValue= hdn_lookup.Value;

          if (ddlIS_FX_RG_FLAG.SelectedValue=="2")
        {
            ddlMaster_TBL_COL_NAME.Enabled = false;
            ddlMaster_Col_Desc.Enabled = false;
            ddlMaster_TBL_NAME.Enabled = false;
          }
        else
          {
            ddlMaster_TBL_COL_NAME.Enabled = true;
            ddlMaster_Col_Desc.Enabled = true;
            ddlMaster_TBL_NAME.Enabled = true;
          }
          if (ddlMaster_TBL_NAME.SelectedValue == "LookUpSU")
          {

              //spnlook.Visible = true;
              ddllookup.Enabled = true;
              FillBase_LookUpCode(ddllookup, "L");
          }
          else
          {
              //lbllookpcd.Visible = false;
              //spnlook.Visible = false;
              ddllookup.Enabled = false;
              // ddllookup.Attributes.Add("readonly", "readonly");
          }

    }


    
    //protected void grvaddedresult_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow && grvaddedresult.EditIndex == e.Row.RowIndex)
    //        {
    //            {
                
    //                DropDownList ddl_FLAG = (DropDownList)e.Row.FindControl("ddlIS_FX_RG_FLAG");

            //        DropDownList ddlSTATUS = (DropDownList)e.Row.FindControl("ddlSTATUS");

            //        DropDownList ddlBASE_TBL_COL_NAME = (DropDownList)e.Row.FindControl("ddlBASE_TBL_COL_NAME");

            //        DropDownList ddlBaseTableName = (DropDownList)e.Row.FindControl("ddlBaseTableName");

            //        //ddlBASE_TBL_COL_NAME  ddlBaseTableName
            //        //bind dropdown-list

            //        Fillddl(ddl_FLAG, "FactorFlg");

            //        Fillddl(ddlSTATUS, "AuthFlg");
            //        FillddlTblDtls(ddlBaseTableName);
            //        FillddlColDtls(ddlBASE_TBL_COL_NAME);
       //   string selectedCity = DataBinder.Eval(e.Row.DataItem, "IS_FX_RG_FLAG").ToString();

              ///ddlIS_FX_RG_FLAG.SelectedIndex = selectedCity;
        //    ddl_FLAG.Items.FindByValue(selectedCity).Selected = true;
         // ddlIS_FX_RG_FLAG.SelectedValue = DataBinder.Eval(e.Row.DataItem, "IS_FX_RG_FLAG").ToString();

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}


    protected void grvaddedresult_Sorting(object sender, GridViewSortEventArgs e)
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
    }


    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["KPICode"].ToString().Trim() != "" && Request.QueryString["ACT_TYP"].ToString().Trim() != "" && Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim() != "")
        {
            KPICode = Request.QueryString["KPICode"].ToString().Trim();
            ACT_TYP = Request.QueryString["ACT_TYP"].ToString().Trim();
            BSD_ON_TBL_TYP = Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim();


           // btnadd.Attributes.Add("onclick", "fnCallPOP('" + KPICode + "','" + ACT_TYP + "','" + BSD_ON_TBL_TYP + "');return true;");
        
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "fnCallPOP('" + KPICode.ToString().Trim() + "','"
              + ACT_TYP.ToString().Trim() + "','" + BSD_ON_TBL_TYP.ToString().Trim() + "');", true);
        }
    }
    protected void ddlMaster_TBL_NAME_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
        //DropDownList ddlMaster_TBL_NAME = (DropDobwnList)row.FindControl("ddlMaster_TBL_NAME");
        //DropDownList ddlMaster_TBL_COL_NAME = (DropDownList)row.FindControl("ddlMaster_TBL_COL_NAME");
        //DropDownList ddlMaster_Col_Desc = (DropDownList)row.FindControl("ddlMaster_Col_Desc");

        FillBase_Src_Colms(ddlMaster_TBL_COL_NAME, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
        FillBase_Src_Colms(ddlMaster_Col_Desc, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");

        if (ddlMaster_TBL_NAME.SelectedValue == "LookUpSU")
        {

            //spnlook.Visible = true;
            ddllookup.Enabled = true;
            ddlMaster_TBL_COL_NAME.SelectedValue = "ParamValue";
            ddlMaster_Col_Desc.SelectedValue = "ParamDesc1";
            ddlMaster_TBL_COL_NAME.Enabled = false;
            ddlMaster_Col_Desc.Enabled = false;
            FillBase_LookUpCode(ddllookup, "L");
        }
        else
        {
            //lbllookpcd.Visible = false;
            //spnlook.Visible = false;
            ddllookup.Enabled = false;
            //ddlMaster_TBL_COL_NAME.SelectedValue = "";
            //ddlMaster_Col_Desc.SelectedValue = "";
            ddlMaster_TBL_COL_NAME.SelectedIndex = 0;
            ddlMaster_Col_Desc.SelectedIndex = 0;
            ddlMaster_TBL_COL_NAME.Enabled = true;
            ddlMaster_Col_Desc.Enabled = true;
            
           // ddllookup.Attributes.Add("readonly", "readonly");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grvaddedresult.EditIndex = -1;
        BindSearchGrid();
    }

    protected void grvaddedresult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string msgs = string.Empty;
        try {
  
            DropDownList ddlIS_FX_RG_FLAG = grvaddedresult.Rows[e.RowIndex].FindControl("ddlIS_FX_RG_FLAG") as DropDownList;
            //FillddlFCTR(ddlIS_FX_RG_FLAG, "FCT");
            DropDownList ddlSTATUS = grvaddedresult.Rows[e.RowIndex].FindControl("ddlSTATUS") as DropDownList;
           // Fillddl(ddlSTATUS, "");
            DropDownList ddlBaseTableName = grvaddedresult.Rows[e.RowIndex].FindControl("ddlBaseTableName") as DropDownList;
           // FillTable(ddlBaseTableName, Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim());
            DropDownList ddlBASE_TBL_COL_NAME = grvaddedresult.Rows[e.RowIndex].FindControl("ddlBASE_TBL_COL_NAME") as DropDownList;
           // FillBase_Src_Colms(ddlBASE_TBL_COL_NAME, ddlBaseTableName.SelectedValue.ToString(), "BS");
            DropDownList ddlMaster_TBL_NAME = grvaddedresult.Rows[e.RowIndex].FindControl("ddlMaster_TBL_NAME") as DropDownList;
           // FillTable(ddlMaster_TBL_NAME, "M");
            DropDownList ddlMaster_TBL_COL_NAME = grvaddedresult.Rows[e.RowIndex].FindControl("ddlMaster_TBL_COL_NAME") as DropDownList;
           // FillBase_Src_Colms(ddlMaster_TBL_COL_NAME, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
            DropDownList ddlMaster_Col_Desc = grvaddedresult.Rows[e.RowIndex].FindControl("ddlMaster_Col_Desc") as DropDownList;
           // FillBase_Src_Colms(ddlMaster_Col_Desc, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
            TextBox txtVAL_DESC = grvaddedresult.Rows[e.RowIndex].FindControl("txtVAL_DESC") as TextBox;
            TextBox txtceasedt = grvaddedresult.Rows[e.RowIndex].FindControl("txtceasedt") as TextBox;

            Label LBLSEQNO = grvaddedresult.Rows[e.RowIndex].FindControl("LBLSEQNO") as Label;
            TextBox txtValCode = grvaddedresult.Rows[e.RowIndex].FindControl("txtValCode") as TextBox;
                //((TextBox)row.FindControl("txtValCode")).Text.ToString();
            //string IS_FX_RG_FLAG = (grvaddedresult.Rows[e.RowIndex].FindControl("ddlIS_FX_RG_FLAG") as DropDownList).SelectedValue.ToString().Trim();

            TextBox DateTimeValue = grvaddedresult.Rows[e.RowIndex].FindControl("DateTimeValue") as TextBox;
            Label lblMappedCd = grvaddedresult.Rows[e.RowIndex].FindControl("lblMappedCd") as Label;

            Hashtable ht = new Hashtable();
            ht.Add("@VAL_CODE", txtValCode.Text);
            ht.Add("@VAL_DESC", txtVAL_DESC.Text);
            ht.Add("@IS_FX_RG_FLAG", ddlIS_FX_RG_FLAG.SelectedValue);
            ht.Add("@BASE_DATA_TBL_NAME", ddlBaseTableName.SelectedValue.ToString());
            ht.Add("@BASE_DATA_TBL_COL_NAME", ddlBASE_TBL_COL_NAME.SelectedValue.ToString());
            if (txtceasedt.Text == "" && ddlSTATUS.SelectedValue == "1")
            {
                ht.Add("@CSE_DTIM", System.DBNull.Value);
            }
            else if (txtceasedt.Text != "" && DateTime.Parse(txtceasedt.Text) <= DateTime.Parse(DateTimeValue.Text) && ddlSTATUS.SelectedValue == "0")
            {
               // && Convert.ToDateTime(tbxFromDate.Value) > DateTime.Today
               // ht.Add("@CSE_DTIM", System.DBNull.Value);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Cease date Greater than Effective Date');", true);
                return;
                txtceasedt.Text = "";
            }
            else
            {
                ht.Add("@CSE_DTIM", DateTime.Parse(txtceasedt.Text));
            }
            ht.Add("@STATUS", ddlSTATUS.SelectedValue.ToString());

            if (ddlIS_FX_RG_FLAG.SelectedValue == "2" && ddlMaster_TBL_NAME.SelectedIndex == 0)
            {
                ht.Add("@MASTER_NAME", System.DBNull.Value);
            }
            else
            {
                ht.Add("@MASTER_NAME", ddlMaster_TBL_NAME.SelectedValue.ToString());
            }
            if (ddlIS_FX_RG_FLAG.SelectedValue == "2" && ddlMaster_TBL_COL_NAME.SelectedIndex == 0)
            {
                ht.Add("@MASTER_COL_NAME", System.DBNull.Value);
            }
            else
            {
                ht.Add("@MASTER_COL_NAME", ddlMaster_TBL_COL_NAME.SelectedValue.ToString());
            }
            if (ddlIS_FX_RG_FLAG.SelectedValue == "2" && ddlMaster_Col_Desc.SelectedIndex == 0)
            {
                ht.Add("@MASTER_COL_DESC", System.DBNull.Value);
            }
            else
            {
                ht.Add("@MASTER_COL_DESC", ddlMaster_Col_Desc.SelectedValue.ToString());
            }
            if (ddlMaster_TBL_NAME.SelectedValue == "LookUpSU" && ddllookup.SelectedIndex == 0)
            {
                ht.Add("@LookupCode", System.DBNull.Value);
            }
            else
            {
                ht.Add("@LookupCode", ddllookup.SelectedValue.ToString());
            }
            ht.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@Flag", "UPD");
            ht.Add("@SEQ_NO", LBLSEQNO.Text);
            ht.Add("@KPI_CODE", Request.QueryString["KPICode"].ToString().Trim());
            htParam.Add("@MAPPED_CODE", lblMappedCd.Text);
            htParam.Add("@IS_SCOPE", Request.QueryString["ACT_TYP"].ToString().Trim());
            DataSet ds = new DataSet();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_DEL_MST_ACT_VAL_SU", ht);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msgs = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msgs == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already exists..!');", true);
                    // return;
                }
                else if (msgs == "FAILED_1" && ddlSTATUS.SelectedValue == "0" && txtceasedt.Text != "") //&& txtceasedt.Text != ""
                {
                    //ddlSTATUS.SelectedValue = "1";
                    //ddlSTATUS.Enabled = false;
                    //txtceasedt.Enabled = false;
                    //if (txtceasedt.Text != "" && ddlSTATUS.SelectedValue == "0")
                    //{
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot update the Status as Inactive and Cease Date');", true);
                    //return;
                    txtceasedt.Text = "";
                    //txtceasedt.Enabled = false;
                    //}
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Updated Successfully...!')", true);
                }

            }
            grvaddedresult.EditIndex = -1;
            BindSearchGrid();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkbtngnrt_Click(object sender, EventArgs e)
    {
        HTMLGenerator hTML = new HTMLGenerator(Convert.ToString(Request.QueryString["KPICode"]), Convert.ToString(Request.QueryString["ACT_TYP"]));
        string status = hTML.Generate();
        if (status == "Success")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('UI Generated Successfully');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Oops somthing went wrong.');", true);
        }
    }
    protected void ddlIS_FX_RG_FLAG_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIS_FX_RG_FLAG.SelectedValue == "2")
        {
            ddlMaster_Col_Desc.Enabled = false;
            ddlMaster_TBL_COL_NAME.Enabled = false;
            ddlMaster_TBL_NAME.Enabled = false;
            ddlMaster_Col_Desc.SelectedIndex = 0;
            ddlMaster_TBL_COL_NAME.SelectedIndex = 0;
            ddlMaster_TBL_NAME.SelectedIndex = 0;
        }
        else
        {
            //FillBase_Src_Colms(ddlMaster_TBL_COL_NAME, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
            //FillBase_Src_Colms(ddlMaster_Col_Desc, ddlMaster_TBL_NAME.SelectedValue.ToString(), "MS");
            ddlMaster_Col_Desc.Enabled = true;
            ddlMaster_TBL_COL_NAME.Enabled = true;
            ddlMaster_TBL_NAME.Enabled = true;
        }
    }
    protected void ddlMaster_Col_Desc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlMaster_Col_Desc.SelectedValue == "LookupCode")
        //{

        //    //spnlook.Visible = true;
        //    ddllookup.Enabled = true;
        //    FillBase_LookUpCode(ddllookup, "L");
        //}
        //else
        //{
        //    //lbllookpcd.Visible = false;
        //    //spnlook.Visible = false;
        //    ddllookup.Enabled = false;
        //    ddllookup.Attributes.Add("readonly", "readonly");
        //}
    }
    protected void BtnToolTip_Click(object sender, EventArgs e)
    {
        //btnadd.ToolTip = hdnMapDataType1.Value;
    }
    protected void BtnToolTip2_Click(object sender, EventArgs e)
    {

    }
}

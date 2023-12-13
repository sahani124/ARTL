
#region Namespace Declaration
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DataAccessClassDAL;
#endregion

public partial class Application_Isys_Saim_MaxRateSetup : BaseClass
{

    #region Global Variable Declaration
    SqlDataReader dtRead;
    Hashtable htparam;
    DataSet ds;
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            try
            {
                txtMaxRateCode.Focus();
                ddlChn.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlProductcodeCategory.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlMaxRatetype.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlMaxRateUSbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlMeasureAs.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlMaxRateOrg.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlCategory.Items.Insert(0, new ListItem("-- SELECT --", ""));

                FillDropDowns(ddlProductcodeCategory, "36"); //Product Category 
                FillDropDowns(ddlMaxRatetype, "1"); //Unit Rank
                funchnlpopup(ddlChn); //Hierarchy Name
                FillDropDowns(ddlMeasureAs, "3");//Measured As
                FillDropDowns(ddlMaxRateOrg, "4");//KPI Origin
                FillDropDowns(ddlCategory, "17");//Categeory

                FillDropDowns(ddlPortfolio, "38");//Categeory
                ddlCategory.SelectedValue = "1002";// fix text

                txtMaxRateCode.Enabled = false;
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "N")
                    {
                        txtStdMin.Text = "0";
                        txtStdMax.Text = "0";
                        ////for formula lnkAdd.Enabled = false;
                        GetMaxrateCode();
                    }
                    else if (Request.QueryString["flag"].ToString().Trim() == "E")
                    {
                        FillMaxRateDetails();
                        /////LnkVisible();
                    }
                }
                //lnkAdd.Attributes.Add("onclick", "funPopUp();return false;");
                btnSave.Attributes.Add("onclick", "javascript:return validate();");
            }
            catch (Exception ex)
            {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            finally
            {

            }
        }
    }
    #endregion

    #region funchnlpopup
    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            htparam = new Hashtable();
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_getchannels", htparam);
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
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
        }
    }
    #endregion

    #region FillDropDowns
    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            htparam = new Hashtable();
            ddl.Items.Clear();
            htparam.Add("@Flag", val.ToString().Trim());
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            dtRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            dtRead = null;
        }
    }
    #endregion

    #region ddlChn_SelectedIndexChanged
    protected void ddlChn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlChn.SelectedValue != "")
            {
                GetChnCls(); //Sub Class
            }
            else
            {
                ddlChnCls.Items.Clear();
                ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
            ddlChnCls.Focus();
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "ddlChn_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
        }
    }
    #endregion

    #region GetChnCls
    protected void GetChnCls()
    {
        try
        {
            htparam = new Hashtable();
            htparam.Add("@BizSrc", ddlChn.SelectedValue.ToString().Trim());

            dtRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", htparam);
            if (dtRead.HasRows)
            {
                ddlChnCls.DataSource = dtRead;
                ddlChnCls.DataTextField = "ChnClsDesc01";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            dtRead.Close();
            ddlChnCls.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "GetChnCls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            dtRead = null;
        }
    }
    #endregion

    #region ddlProductcodeCategory_SelectedIndexChanged
    protected void ddlProductcodeCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProductcodeCategory.SelectedValue != "")
            {
                GetProductName(); //Product Dropdown fill
            }
            else
            {
                ddlProduct.Items.Clear();
                ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
            ddlProduct.Focus();
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "ddlProductcodeCategory_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
        }
    }
    #endregion

    #region GetProductName
    protected void GetProductName()
    {
        try
        {
            htparam = new Hashtable();
            htparam.Add("@Productvalue", ddlProductcodeCategory.SelectedValue.ToString().Trim());
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetProductSubName", htparam);
            if (dtRead.HasRows)
            {
                ddlProduct.DataSource = dtRead;
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductValue";
                ddlProduct.DataBind();
            }
            dtRead.Close();
            ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "GetProductName", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            dtRead = null;
        }
    }
    #endregion

    #region ddlMaxRatetype_SelectedIndexChanged
    protected void ddlMaxRatetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMaxRatetype.SelectedValue != "")
            {
                FillSubType();

            }
            else
            {
                ddlMaxRateUSbtype.Items.Clear();
                ddlMaxRateUSbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
                txtStdMin.Text = "0";
                txtStdMax.Text = "0";
            }
            ddlMaxRateUSbtype.Focus();
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "ddlMaxRatetype_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
        }
    }
    #endregion

    #region FillSubType
    protected void FillSubType()
    {
        try
        {
            htparam = new Hashtable();
            htparam.Add("@TypeCode", ddlMaxRatetype.SelectedValue.ToString().Trim());
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetKPISubType", htparam);
            if (dtRead.HasRows)
            {
                ddlMaxRateUSbtype.DataSource = dtRead;
                ddlMaxRateUSbtype.DataTextField = "DESC01";
                ddlMaxRateUSbtype.DataValueField = "CODE";
                ddlMaxRateUSbtype.DataBind();
            }
            dtRead.Close();
            ddlMaxRateUSbtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "FillSubType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            dtRead = null;
        }
    }
    #endregion

    #region GetMaxrateCode
    protected void GetMaxrateCode()
    {
        try
        {
            htparam = new Hashtable();
            ds = new DataSet();
            ds.Clear();
            htparam.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxRateCode", htparam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtMaxRateCode.Text = ds.Tables[0].Rows[0]["MaxRate_Code"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "GetMaxrateCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            ds = null;
        }
    }
    #endregion

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ////if (ddlMaxRateUSbtype.SelectedIndex == 0)
            ////{
            ////    if (Convert.ToDecimal(txtStdMin.Text) > Convert.ToDecimal(txtStdMax.Text))
            ////    {
            ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Std Min. should not be less than Std Max.');", true);
            ////        return;
            ////    }
            ////}
            ////else if (ddlMaxRateUSbtype.SelectedIndex == 1)
            ////{
            ////    //if (Convert.ToDouble(txtStdMin.Text) > Convert.ToDouble(txtStdMax.Text))
            ////    //{
            ////    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Std Min. should not be less than Std Max.');", true);
            ////    //    return;
            ////    //}
            ////}

            MaxeRateCreate();
            mdlpopup.Show();
            lbl3.Text = "Max Rate Code Saved Successfully";
            lbl4.Text = "Max Rate Code:" + txtMaxRateCode.Text.ToString().Trim();
            lbl5.Text = "Max Rate Description:" + txtMaxRateDesc1.Text.ToString().Trim();
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
        }
    }
    #endregion

    #region MaxeRateCreate
    protected void MaxeRateCreate()
    {
        try
        {
            ds = new DataSet();
            htparam = new Hashtable();
            htparam.Add("@MRCODE", txtMaxRateCode.Text.ToString().Trim());
            htparam.Add("@MRDESC01", txtMaxRateDesc1.Text.ToString().Trim());
            htparam.Add("@MRDESC02", txtMaxRateDesc2.Text.ToString().Trim());
            htparam.Add("@MRDESC03", txtMaxRateDesc3.Text.ToString().Trim());
            htparam.Add("@CHN", ddlChn.SelectedValue.ToString().Trim());
            htparam.Add("@CHNCLS", ddlChnCls.SelectedValue.ToString().Trim());
            htparam.Add("@ProductCategory", ddlProductcodeCategory.SelectedValue.ToString().Trim());
            htparam.Add("@Product", ddlProduct.SelectedValue.ToString().Trim());
            htparam.Add("@UnitTYPE", ddlMaxRatetype.SelectedValue.ToString().Trim());
            htparam.Add("@UnitSUBTYPE", ddlMaxRateUSbtype.SelectedValue.ToString().Trim());
            htparam.Add("@Category", ddlCategory.SelectedValue.ToString().Trim());
            htparam.Add("@Maxrate", txtMaxRate.Text.ToString().Trim());
            htparam.Add("@VEREFFFROM", Convert.ToDateTime(txtEffdate.Text.ToString().Trim()));

            if (txtFrmDate.Text == "")
            {
                htparam.Add("@EFFFROM", System.DBNull.Value);
            }
            else
            {
                htparam.Add("@EFFFROM", Convert.ToDateTime(txtFrmDate.Text.ToString().Trim()));
            }
            if (txtToDate.Text == "")
            {
                htparam.Add("@EFFTO", System.DBNull.Value);
            }
            else
            {
                htparam.Add("@EFFTO", Convert.ToDateTime(txtToDate.Text.ToString().Trim()));
            }
            if (txtCseDt.Text == "")
            {
                htparam.Add("@VEREFFTO", System.DBNull.Value);
            }
            else
            {
                htparam.Add("@VEREFFTO", Convert.ToDateTime(txtCseDt.Text.ToString().Trim()));
            }
            htparam.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            if (Request.QueryString["flag"] != null)
            {
                htparam.Add("@Flag", Request.QueryString["flag"].ToString().Trim());
            }
            else
            {
                htparam.Add("@Flag", "N");
            }
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMaxRateDtls", htparam);
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "MaxeRateCreate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            ds = null;
        }
    }
    #endregion

    #region FillMaxRateDetails
    protected void FillMaxRateDetails()
    {
        try
        {
            ds = new DataSet();
            htparam = new Hashtable();
            if (Request.QueryString["MaxRateCode"] != null)
            {
                htparam.Add("@MrCode", Request.QueryString["MaxRateCode"].ToString().Trim());
            }
            htparam.Add("@Flag", "1");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_MaxRateSearch", htparam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtMaxRateCode.Text = ds.Tables[0].Rows[0]["MR_CODE"].ToString().Trim();
                txtMaxRateDesc1.Text = ds.Tables[0].Rows[0]["MR_DESC_01"].ToString().Trim();
                txtMaxRateDesc2.Text = ds.Tables[0].Rows[0]["MR_DESC_01"].ToString().Trim();
                txtMaxRateDesc3.Text = ds.Tables[0].Rows[0]["MR_DESC_01"].ToString().Trim();

                ddlChn.SelectedValue = ds.Tables[0].Rows[0]["CHN"].ToString().Trim();
                GetChnCls();
                ddlChnCls.SelectedValue = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();

                FillDropDowns(ddlProductcodeCategory, "36");
                ddlProductcodeCategory.SelectedValue = ds.Tables[0].Rows[0]["CODE"].ToString().Trim();
                GetProductName();
                ddlProduct.SelectedValue = ds.Tables[0].Rows[0]["productCode"].ToString().Trim();

                ddlMaxRatetype.SelectedValue = ds.Tables[0].Rows[0]["Unit_TYPECODE"].ToString().Trim();
                FillSubType();
                ddlMaxRateUSbtype.SelectedValue = ds.Tables[0].Rows[0]["Unit_SUBTYPECode"].ToString().Trim();

                //Product Dropdown fill

                txtMaxRate.Text = ds.Tables[0].Rows[0]["Max_rate"].ToString().Trim();
                txtFrmDate.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
                txtToDate.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();

                txtEffdate.Text = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
                txtCseDt.Text = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();


                ////ddlDtLstKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_LIST_KEY"].ToString().Trim();
                ////FillDataField(ddlDtFldKey, ddlDtLstKey);
                ////ddlDtFldKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_FIELD_KEY"].ToString().Trim();
                ////ddlDtFuncKey.SelectedValue = ds.Tables[0].Rows[0]["DATA_FUNCTION_KEY"].ToString().Trim();

            }
        }
        catch (Exception ex)
        {
              //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
              //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
              //  string sRet = oInfo.Name;
              //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
              //  String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "MaxRateSetup", "FillMaxRateDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            htparam.Clear();
            ds = null;
        }
    }
    #endregion

    #region ClearControls
    protected void ClearControls()
    {
        txtMaxRate.Text = "";
        txtMaxRateDesc1.Text = "";
        txtMaxRateDesc2.Text = "";
        txtMaxRateDesc3.Text = "";
        txtStdMax.Text = "";
        txtFrmDate.Text = "";
        txtToDate.Text = "";
        txtEffdate.Text = "";
        txtCseDt.Text = "";
        ddlProductcodeCategory.SelectedValue = "";
        ddlProduct.SelectedValue = "";
        ddlChn.SelectedValue = "";
        ddlChnCls.SelectedValue = "";
        ddlMaxRatetype.SelectedValue = "";
        ddlMaxRateUSbtype.SelectedValue = "";
    }
    #endregion

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    #endregion

    #region btnClose_Click
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaxRateSearch.aspx", true);
    }
    #endregion

    #region ddlMaxRateUSbtype_SelectedIndexChanged
    protected void ddlMaxRateUSbtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMaxRate.Focus();

    }
    #endregion
}
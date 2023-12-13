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
using System.Globalization;
using System.Web.Services;
using Newtonsoft.Json;

public partial class Application_Isys_Saim_Customisation_MSTACTSU : BaseClass
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
    string strmapcode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }

                if (Request.QueryString["mapcode"] != null)
                {
                    strmapcode = Request.QueryString["mapcode"].ToString();
                    txtMappedCd.Text = strmapcode;
                    txtEffDtFrm.Attributes.Add("readonly", "readonly");
                    txtceasedt.Attributes.Add("readonly", "readonly");
                }

                Fillddl(ddlActionType);
                Fillddl(ddlAuthFlg, "AuthFlg");

                if (Request.QueryString["ACT_TYPE"] != null)
                {
                    ddlActionType.SelectedValue = Request.QueryString["ACT_TYPE"].ToString().Trim();
                }

                //Added Functionality By Pratik
                string role = Convert.ToString(Request.QueryString["role"]);
                disable_Control(role);

                if (role == "admin")
                {
                    ChkPrntAct();
                }
                else
                {
                    ActionNotAvail(false);
                }

                checkUserRole(HttpContext.Current.Session["UserID"].ToString());

                // divcmpSrch.Attributes.Add(style.display = "none");

                btnSearch_Click(null, null);
                txtPage.Text = "1";
                txtEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEffDtFrm.Enabled = false;
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

        ddlAuthFlg.SelectedIndex = 1;
        ddlAuthFlg.Enabled = false;
    }

    public void checkUserRole(string UserID)
    {
        DataSet ds = new DataSet();
        Hashtable htable = new Hashtable();
        ds.Clear();
        htable.Clear();
        htable.Add("@UserID", UserID);
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GETUserRole", htable);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnResetExecOrder.Visible = (Convert.ToString(ds.Tables[0].Rows[0][0]).Trim().ToLower() == "sysadmin");
        }
    }

    protected void ChkPrntAct()
    {
        try
        {
            DataSet dsPrnt = new DataSet();
            dsPrnt.Clear();
            htParam.Clear();
            htParam.Add("@MAP_CODE", Request.QueryString["mapcode"].ToString());

            htParam.Add("@kpi_code", Request.QueryString["kpicode"].ToString());
            dsPrnt = objDal.GetDataSetForPrc_SAIM("PRC_CHK_ACT_NO", htParam);

            // Added BY Pratik 23_03_2020
            if (dsPrnt.Tables.Count > 0 && dsPrnt.Tables[0].Rows.Count > 0)
            {
                ActionNotAvail((dsPrnt.Tables[0].Rows[0]["Result"]).ToString() == "N");
            }
            else
            {
            }

            //Commmented BY Pratik -- 23_03_2020
            //if (dsPrnt.Tables.Count > 0 && dsPrnt.Tables[0].Rows.Count > 0)
            //{
            //    if ((dsPrnt.Tables[0].Rows[0]["Result"]).ToString() == "N")
            //    {
            //        divParentAct.Visible = true;
            //        divcmphdrcollapse.Visible = false;
            //        divsrchdrcollapse.Visible = false;
            //        divResult.Visible = false;
            //        FillddlActNo(ddlActCode);
            //    }
            //    else
            //    {
            //        divParentAct.Visible = false;
            //        divcmphdrcollapse.Visible = true;
            //        divsrchdrcollapse.Visible = true;
            //        divResult.Visible = true;
            //        Fillddl(ddlAuthFlg, "AuthFlg");
            //        Fillddl(ddlActionType);
            //        getActionNo();
            //        getExecutionOrder();
            //        BindActionGrid();
            //        txtPage.Text = "1";
            //    }
            //}
            //else
            //{
            //}
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

    protected void btnCnclCmp_Click(object sender, EventArgs e)
    {
        string flag = "1";
        string url = "~/Application/Isys/Saim/RuleSetPages/FFContestPageStdDef.aspx?";
        //Added By Pratik
        string role = Convert.ToString(Request.QueryString["role"]);
        url += "role=" + role + "&flag=" + flag + "&KpiCode=" + Request.QueryString["kpicode"].ToString().Trim() + "&mapcode=" + Request.QueryString["mapcode"].ToString().Trim();
        //Added By Pratik
        //url += "flag=" + flag + "&KpiCode=" + Request.QueryString["kpicode"].ToString().Trim() + "&mapcode=" + Request.QueryString["mapcode"].ToString().Trim();
        Response.Redirect(url, false);
    }

    protected void getActionNo()
    {
        Hashtable htable = new Hashtable();
        htable.Clear();
        htable.Add("@ActionNo", "ActNo");
        DataSet ds = new DataSet();
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACTIONNO", htable);
        txtActionNo.Text = ds.Tables[0].Rows[0]["ActionNo"].ToString();
        txtActionNo.Enabled = false;
    }

    protected void getExecutionOrder()
    {
        Hashtable htable = new Hashtable();
        htable.Clear();
        htable.Add("@map_code", txtMappedCd.Text);
        htable.Add("@action_type", Request.QueryString["ACT_TYPE"].ToString());
        DataSet ds = new DataSet();
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_ExecutionOrder", htable);
        txtExecOrder.Text = ds.Tables[0].Rows[0]["EXCTN_ORDR"].ToString();
    }

    protected bool btnUpdateValdtn(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DropDownList ddlAuthEdit = row.FindControl("ddlAuthEdit") as DropDownList;
            //DropDownList ddlActionEdit = row.FindControl("ddlActionEdit") as DropDownList;
            TextBox txtActionName = row.FindControl("txtActionNameEdit") as TextBox;
            TextBox txtActionDesc = row.FindControl("txtAct_DescEdit") as TextBox;
            TextBox txtEffDtFrm = row.FindControl("DateTimeValue") as TextBox;
            TextBox txtceasedtedit = row.FindControl("txtceasedtedit") as TextBox;

            if (txtActionName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter action name.');", true);
                return false;
            }

            if (txtActionDesc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter action description.');", true);
                return false;
            }

            if (ddlAuthEdit.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select status.');", true);
                return false;
            }

            //if (ddlActionEdit.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select action type.');", true);
            //    return false;
            //}

            if (txtEffDtFrm.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select effective date.');", true);
                return false;
            }

            if (txtceasedtedit.Text != "")
            {
                int result1 = compareDates(txtEffDtFrm.Text, txtceasedtedit.Text);
                if (result1 > 0)
                {
                    txtceasedtedit.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select correct cease date.')", true);
                    return false;
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
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return false;
        }
        return true;
    }

    protected bool btnSaveValdtn()
    {
        try
        {
            if (txtActionNo.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter Action No.');", true);
                return false;
            }

            if (txtActionVer.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter Version no.');", true);
                return false;
            }
            if (ddlAuthFlg.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select status.');", true);
                return false;
            }
            if (ddlActionType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select action type.');", true);
                return false;
            }
            if (txtEffDtFrm.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please select effective date.');", true);
                return false;
                ///*return*/ ;

            }
            //if (txtceasedt.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter cease date.');", true);
            //    return;
            //}
            if (txtActionName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter action name.');", true);
                return false;
            }

            if (txtActionDesc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter action description.');", true);
                return false;
            }

            if (txtExecOrder.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Please enter execution order.');", true);
                return false;
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


            return false;

        }
        return true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {


            bool flag = btnSaveValdtn();
            if (flag)
            {
                SaveData();
                BindActionGrid();
                ClrFiedls();

                getActionNo();

                getExecutionOrder();

            }
            txtEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEffDtFrm.Enabled = false;
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

    protected void SaveData()
    {
        try
        {
            Hashtable htable = new Hashtable();
            htable.Clear();
            htable.Add("@MAP_CODE", txtMappedCd.Text);
            htable.Add("@ACT_NO", txtActionNo.Text);
            htable.Add("@ACT_VER", txtActionVer.Text);
            htable.Add("@Status", ddlAuthFlg.SelectedItem.Value);
            htable.Add("@EFF_DTIM", txtEffDtFrm.Text);
            htable.Add("@CSE_DTIM", txtceasedt.Text);
            htable.Add("@ACT_TYP", ddlActionType.SelectedItem.Value);
            htable.Add("@ACT_NAME", txtActionName.Text);
            htable.Add("@ACT_DESC", txtActionDesc.Text);
            htable.Add("@EXCTN_ORDR", txtExecOrder.Text);
            htable.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
            DataSet ds = new DataSet();
            ds = objDal.GetDataSetForPrc_SAIM("prc_ins_MST_ACT_SU", htable);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Action details saved successfully')", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Action details saved successfully.');", true);
            //return;

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
    protected void ClrFiedls()
    {
        txtActionNo.Text = "";
        //ddlAuthFlg.SelectedIndex = 0;
        //ddlActionType.SelectedIndex = 0;
        txtEffDtFrm.Text = "";
        txtceasedt.Text = "";
        txtActionName.Text = "";
        txtActionDesc.Text = "";
        txtExecOrder.Text = "";
    }

    protected void Fillddl(DropDownList ddl, string LookupCode)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetBindddlVal", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc01";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0"));

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
    protected void Fillddl(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();

            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_get_actionType", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0"));
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

    protected void FillddlActNo(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            htParam.Clear();
            htParam.Add("@KPI_CODE", Request.QueryString["kpicode"].ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_PRNT_ACT_NO", htParam);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", "0"));
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


    protected void FillActNo()
    {
        Hashtable htable1 = new Hashtable();
        htable1.Clear();
        htable1.Add("@ActionNo", "ActNo");
        DataSet dsDDL = new DataSet();
        dsDDL = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACTIONNO", htable1);
        txtActionNo.Text = dsDDL.Tables[0].Rows[0]["ActionNo"].ToString();
    }

    protected void BindActionGrid()
    {
        try
        {
            ds.Clear();
            htParam.Clear();

            htParam.Add("@ACT_DESC", TextSrAcDesc.Text);
            htParam.Add("@ACT_NO", TextSrAcNo.Text);

            htParam.Add("@MAP_CODE", txtMappedCd.Text);
            htParam.Add("@ACT_TYP", ddlActionType.SelectedValue); // added by daksh for act_type filter

            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACTIONDATA", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();
                ViewState["grid"] = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 1)
                {
                    btnResetExecOrder.Enabled = true;
                }
                else
                {
                    btnResetExecOrder.Enabled = false;
                }

                if (grvaddedresult.PageCount == 1)
                {
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
                //ds = null;

                if (ds.Tables[0].Rows.Count > 1)
                {
                    btnResetExecOrder.Enabled = true;
                }
                else
                {
                    btnResetExecOrder.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void grvaddedresult_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
        grvaddedresult.EditIndex = e.NewEditIndex;
        this.BindActionGrid();
        grvaddedresult.EditIndex = e.NewEditIndex;
        grvaddedresult.AllowSorting = false;

        TextBox txtceasedtedit = grvaddedresult.Rows[index].FindControl("txtceasedtedit") as TextBox;
        TextBox DateTimeValue = grvaddedresult.Rows[index].FindControl("DateTimeValue") as TextBox;
        //txtceasedtedit.Attributes.Add("readonly", "readonly");
        //DateTimeValue.Attributes.Add("readonly", "readonly");

        TextBox txtexcuteOrder = grvaddedresult.Rows[index].FindControl("txtexcuteOrder") as TextBox;
        DropDownList ddlAuthEdit = grvaddedresult.Rows[index].FindControl("ddlAuthEdit") as DropDownList;
        //DropDownList ddlActionEdit = grvaddedresult.Rows[index].FindControl("ddlActionEdit") as DropDownList;
        DropDownList ddlSTATUS = grvaddedresult.Rows[index].FindControl("ddlSTATUS") as DropDownList;

        HiddenField hdnSTATUS = grvaddedresult.Rows[index].FindControl("hdnSTATUS") as HiddenField;
        //HiddenField hdnAction = grvaddedresult.Rows[index].FindControl("hdnAction") as HiddenField;
        //  Fillddl(ddlEcecuteEdit, "ExcOrder");
        Fillddl(ddlAuthEdit, "AuthFlg");
        //Fillddl(ddlActionEdit);
        ddlAuthEdit.SelectedValue = hdnSTATUS.Value;
        //ddlActionEdit.SelectedValue = hdnAction.Value;
    }
    protected void grvaddedresult_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //grvaddedresult.AllowSorting = true;
    }
    protected void grvaddedresult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvaddedresult.EditIndex = -1;
        BindActionGrid();
        grvaddedresult.AllowSorting = true;
    }
    protected void grvaddedresult_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            DropDownList ddlAuthEdit = row.FindControl("ddlAuthEdit") as DropDownList;
            //DropDownList ddlActionEdit = row.FindControl("ddlActionEdit") as DropDownList;

            string strtxtActNo = ((TextBox)row.FindControl("txtActionNo")).Text.ToString();
            string strMappedCode = ((TextBox)row.FindControl("txtMappedCd")).Text.ToString();
            string strActVer = ((TextBox)row.FindControl("txtActionVer")).Text.ToString();
            string strauthUpdate = (row.FindControl("ddlAuthEdit") as DropDownList).SelectedValue;
            //string strActionType = (row.FindControl("ddlActionEdit") as DropDownList).SelectedValue;
            string strEffDt = ((TextBox)row.FindControl("DateTimeValue")).Text.ToString();
            string strCeaseDt = ((TextBox)row.FindControl("txtceasedtedit")).Text.ToString();
            string strActonname = ((TextBox)row.FindControl("txtActionNameEdit")).Text.ToString();
            string strActonDesc = ((TextBox)row.FindControl("txtAct_DescEdit")).Text.ToString();
            string strExicutionOrd = ((TextBox)row.FindControl("txtexcuteOrder")).Text.ToString();

            bool flag = btnUpdateValdtn(sender, e);
            if (flag)
            {
                Hashtable ht = new Hashtable();
                ht.Add("@ACT_NO", strtxtActNo);
                ht.Add("@MAP_CODE", strMappedCode);
                ht.Add("@ACT_VER", strActVer);
                ht.Add("@STATUS", strauthUpdate);
                //ht.Add("@ACT_TYP", strActionType);
                ht.Add("@EFF_DTIM", strEffDt);
                ht.Add("@CSE_DTIM", strCeaseDt);
                ht.Add("@ACT_NAME", strActonname);
                ht.Add("@ACT_DESC", strActonDesc);
                ht.Add("@EXCTN_ORDR", strExicutionOrd);
                ht.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                DataSet ds = new DataSet();
                ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_MST_ACT_SU", ht);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Action details updated successfully.');", true);
                grvaddedresult.EditIndex = -1;
                grvaddedresult.AllowSorting = true;
                BindActionGrid();
            }
            else
            {
                grvaddedresult.AllowSorting = false;
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            grvaddedresult.EditIndex = -1;
            grvaddedresult.AllowSorting = true;
            BindActionGrid();
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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = grvaddedresult.PageIndex;
            grvaddedresult.PageIndex = pageIndex - 1;
            BindActionGrid();
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
            BindActionGrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lblCompCode_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lblCompCode = (LinkButton)grd.FindControl("lblCompCode");
        string Kpicode = Request.QueryString["kpicode"].ToString().Trim();
        string mapcode = Request.QueryString["mapcode"].ToString().Trim();

        string role = Convert.ToString(Request.QueryString["role"]);
        string ACT_TYPE = Convert.ToString(grvaddedresult.DataKeys[grd.RowIndex]["ACT_TYP_code"]);
        Response.Redirect("MstActCatgSU.aspx?role=" + role + "&ActNO=" + lblCompCode.Text.ToString().Trim() + "&KPIcode=" + Kpicode + "&mapcode=" + mapcode + "&ACT_TYPE=" + ACT_TYPE, true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@ACT_DESC", TextSrAcDesc.Text);
            htParam.Add("@ACT_NO", TextSrAcNo.Text);
            htParam.Add("@MAP_CODE", txtMappedCd.Text);
            htParam.Add("@ACT_TYP", ddlActionType.SelectedValue); // added by daksh for act_type filter
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACTIONDATA", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();
                ViewState["grid"] = ds.Tables[0];
                int pageIndex = grvaddedresult.PageIndex;

                txtPage.Text = Convert.ToString(pageIndex);

                if (ds.Tables[0].Rows.Count > 1)
                {
                    btnResetExecOrder.Enabled = true;
                }
                else
                {
                    btnResetExecOrder.Enabled = false;
                }

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
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                grvaddedresult.DataSource = ds;
                grvaddedresult.DataBind();

                if (ds.Tables[0].Rows.Count > 1)
                {
                    btnResetExecOrder.Enabled = true;
                }
                else
                {
                    btnResetExecOrder.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkDelAct_Click(object sender, EventArgs e)
    {

        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            GridViewRow gvrow = (GridViewRow)((LinkButton)sender).NamingContainer;

            LinkButton lnkCmpCode = (LinkButton)gvrow.FindControl("lblCompCode");
            htParam.Add("@ACT_NO", lnkCmpCode.Text.ToString().Trim());

            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_ACTIONDATA", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Action detail deleted.');", true);
            grvaddedresult.EditIndex = -1;
            BindActionGrid();
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

    protected void grvaddedresult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {


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


    protected void btnY_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlActCode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select parent map code');", true);
                return;
            }
            else
            {
                htParam.Clear();
                htParam.Add("@PRNT_MAP_CODE", ddlActCode.SelectedItem.Value);
                htParam.Add("@MAP_CODE", Request.QueryString["mapcode"].ToString());
                //  htParam.Add("@MAP_CODE", "1001");
                htParam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_PRNT_ACT_NO", htParam);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", string.Format("alert('Mapping added against mapped code : {0}.');", ds.Tables[0].Rows[0]["ParamDesc"].ToString()), true);


                divParentAct.Visible = false;
                divcmphdrcollapse.Visible = true;
                divsrchdrcollapse.Visible = true;
                divResult.Visible = true;


                //  Fillddl(ddlExecOrder, "ExcOrder");
                Fillddl(ddlAuthFlg, "AuthFlg");
                Fillddl(ddlActionType);

                FillActNo();
                getExecutionOrder();

                BindActionGrid();

                txtPage.Text = "1";
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

    protected void btnN_Click(object sender, EventArgs e)
    {
        divParentAct.Visible = false;
        divcmphdrcollapse.Visible = true;
        divsrchdrcollapse.Visible = true;
        divResult.Visible = true;

        //  Fillddl(ddlExecOrder, "ExcOrder");
        //Fillddl(ddlAuthFlg, "AuthFlg");
        //Fillddl(ddlActionType);

        FillActNo();

        getExecutionOrder();
        BindActionGrid();

        txtPage.Text = "1";
    }

    public int compareDates(string date1, string date2)
    {
        int d = 0;
        try
        {
            DateTime d1 = DateTime.ParseExact(date1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            d = DateTime.Compare(d1, d2);
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
        return d;
    }

    //Added Functionality By Pratik
    public void disable_Control(string role)
    {
        if (role != "admin")
        {
            //txtMappedCd.Enabled = false;
            //txtActionNo.Enabled = false;
            //txtActionVer.Enabled = false;
            //txtActionName.Enabled = false;
            //txtActionDesc.Enabled = false;
            //ddlAuthFlg.Enabled = false;
            //ddlActionType.Enabled = false;
            //txtEffDtFrm.Enabled = false;
            //txtceasedt.Enabled = false;
            //txtExecOrder.Enabled = false;
            //btnSave.Enabled = false;
            grvaddedresult.Columns[grvaddedresult.Columns.Count - 1].Visible = false;
            divcmphdrcollapse.Attributes.CssStyle.Add("display", "none");
        }
        else
        {
            grvaddedresult.Columns[grvaddedresult.Columns.Count - 1].Visible = true;
        }
    }
    //Added Functionality By Pratik
    public void ActionNotAvail(bool avail)
    {
        if (avail == true)
        {
            divParentAct.Visible = true;
            divcmphdrcollapse.Visible = false;
            divsrchdrcollapse.Visible = false;
            divResult.Visible = false;
            FillddlActNo(ddlActCode);
            //ddlActionType.SelectedValue = Convert.ToString(Request.QueryString["ACT_TYPE"]);
        }
        else
        {
            divParentAct.Visible = false;
            divcmphdrcollapse.Visible = true;
            divsrchdrcollapse.Visible = true;
            divResult.Visible = true;
            Fillddl(ddlAuthFlg, "AuthFlg");
            Fillddl(ddlActionType);
            // ddlActionType.SelectedValue = Convert.ToString(Request.QueryString["ACT_TYPE"]);
            getActionNo();
            getExecutionOrder();
            BindActionGrid();
            txtPage.Text = "1";
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }



    [WebMethod(EnableSession = true)]
    public static MethodResponse GetActionData(string map_code, string action_type)
    {
        string output = "";
        var MethodResponse = new MethodResponse();
        try
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sql = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("PRC_GET_ACTIONDATA", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACT_DESC", "");
                cmd.Parameters.AddWithValue("@ACT_NO", "");
                cmd.Parameters.AddWithValue("@MAP_CODE", map_code);
                cmd.Parameters.AddWithValue("@ACT_TYP", action_type);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dataTable);
                sql.Close();
                sda.Dispose();
            }
            var actionList = dataTable.AsEnumerable().Select(x => new
            {
                ACT_NO = Convert.ToString(x["ACT_NO"]),
                EXCTN_ORDR = Convert.ToString(x["EXCTN_ORDR"]),
                ACT_DESC = Convert.ToString(x["ACT_NAME"])
            });
            MethodResponse.status = 0;
            MethodResponse.message = "";
            MethodResponse.data = actionList;
            output = JsonConvert.SerializeObject(MethodResponse);
        }
        catch (Exception ex)
        {
            MethodResponse.status = 1;
            MethodResponse.message = ex.Message;
            MethodResponse.data = null;
            output = JsonConvert.SerializeObject(MethodResponse);
        }
        return MethodResponse;
    }

    [WebMethod(EnableSession = true)]
    public static MethodResponse SaveExecutionOrder(List<Dictionary<string, string>> data)
    {
        string output = "";
        var MethodResponse = new MethodResponse();
        try
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sql = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString()))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("PRC_UPD_ACT_EXCTN_ORDR", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Dictionary<string, string> item in data)
                {
                    foreach (var kvp in item)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                    cmd.Parameters.AddWithValue("UserId", Convert.ToString(HttpContext.Current.Session["UserID"]));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                sql.Close();
            }
            MethodResponse.status = 0;
            MethodResponse.message = "";
            MethodResponse.data = null;
            output = JsonConvert.SerializeObject(MethodResponse);
        }
        catch (Exception ex)
        {
            MethodResponse.status = 1;
            MethodResponse.message = ex.Message;
            MethodResponse.data = null;
            output = JsonConvert.SerializeObject(MethodResponse);
        }
        return MethodResponse;
    }
}


public class MethodResponse
{
    public int status { get; set; }
    public object data { get; set; }
    public string message { get; set; }
}
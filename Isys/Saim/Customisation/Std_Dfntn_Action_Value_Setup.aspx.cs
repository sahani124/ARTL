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

public partial class Application_Isys_Saim_Customisation_Std_Dfntn_Action_Value_Setup : BaseClass
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
        if (!IsPostBack)
        {
            FillDropDownCHNL();
         
            ddlmemtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlkpi.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlsubchnl.Items.Insert(0, new ListItem("-- SELECT --", ""));

            BindGridVw();
            btnnext.Visible = true;
            btnprevious.Visible = true;
            Txtpage.Visible = true;
        }
        
    }
    
    public void FillDropDownCHNL()
    {
        try
        {
            Hashtable ht = new Hashtable();
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_getchannels", ht);
            if (drRead.HasRows)
            {
                ddlChannl.DataSource = drRead;
                ddlChannl.DataTextField = "ChannelDesc01";
                ddlChannl.DataValueField = "BizSrc";
                ddlChannl.DataBind();
            }
            //drRead.Close();
            drRead = null;
            ddlChannl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "FillDropDownCHNL", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetChnlClsdetils(DropDownList ddlchl, DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@BizSrc", ddlchl.SelectedValue.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddlsubchnl.DataSource = drRead;
                ddlsubchnl.DataTextField = "ChnClsDesc01";
                ddlsubchnl.DataValueField = "ChnCls";
                ddlsubchnl.DataBind();
            }
           // drRead.Close();
            // ddl.Items.Clear();
            drRead = null;
            ddlsubchnl.Items.Insert(0, new ListItem("-- SELECT --", ""));

            ddlmemtype.Items.Clear();
            ddlmemtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
          catch (Exception ex)
       {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "GetChnlClsdetils", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlChannl_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillDropDownSubChnl();
        if (ddlChannl.SelectedValue!="")
        {
            GetChnlClsdetils(ddlChannl, ddlsubchnl);
        }
        else
        {
            ddlsubchnl.Items.Clear();
            ddlsubchnl.Items.Insert(0, new ListItem("-- SELECT --", ""));

            ddlmemtype.Items.Clear();
            ddlmemtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        //ddlChannl.Focus();// 
    }

    public void FillDropDownMemType(DropDownList ddlChnl, DropDownList ddlsubchnl, DropDownList ddlMemTyp)
    {
        try
        {
            ddlMemTyp.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@BizSrc", ddlChnl.SelectedValue.ToString());
            ht.Add("@ChnCls", ddlsubchnl.SelectedValue.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_fillddlMemType", ht);
            if (drRead.HasRows)
            {
                ddlMemTyp.DataSource = drRead;
                ddlMemTyp.DataTextField = "ParamDesc";
                ddlMemTyp.DataValueField = "ParamValue";
                ddlMemTyp.DataBind();
            }
            //drRead.Close();
            drRead = null;
            ddlMemTyp.Items.Insert(0, new ListItem("-- SELECT --", ""));
           
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "FillDropDownMemType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlsubchnl_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        if (ddlChannl.SelectedValue!="" && ddlsubchnl.SelectedValue!="")
        {
           FillDropDownMemType(ddlChannl, ddlsubchnl, ddlmemtype);
        }
        else
        {
            ddlmemtype.Items.Clear();
            ddlmemtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
       // ddlsubchnl.Focus();
        
    }

    public void FillDropDownKPI(DropDownList ddlChnl, DropDownList ddlsubchnl, DropDownList ddlMemTyp,DropDownList ddlkpi)
    {
        try
        {
            ddlkpi.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@BizSrc", ddlChnl.SelectedValue.ToString());
            ht.Add("@ChnCls", ddlsubchnl.SelectedValue.ToString());
            ht.Add("@MEMTYPE", ddlMemTyp.SelectedValue.ToString());

            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_FILL_KPIDESC_CHNMAP", ht);
            if (drRead.HasRows)
            {
                ddlkpi.DataSource = drRead;
                ddlkpi.DataTextField = "ParamDesc";
                ddlkpi.DataValueField = "ParamValue";
                ddlkpi.DataBind();
            }
            //drRead.Close();
            drRead = null;
            ddlkpi.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "FillDropDownKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlmemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChannl.SelectedValue != "" && ddlsubchnl.SelectedValue != "" && ddlmemtype.SelectedValue != "")
        {
            FillDropDownKPI(ddlChannl, ddlsubchnl, ddlmemtype, ddlkpi);
        }
        else{
            ddlkpi.Items.Clear();
            ddlkpi.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
    }

    protected void btncncl_Click(object sender, EventArgs e)
    {
     
        FillDropDownKPI(ddlChannl, ddlsubchnl, ddlmemtype, ddlkpi);
        ddlChannl.SelectedIndex = 0;

        ddlmemtype.Items.Clear();
        ddlsubchnl.Items.Clear();
        ddlkpi.Items.Clear();

        ddlmemtype.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlsubchnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlkpi.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }

    private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        try
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            int rowsCount = gv.Rows.Count;
            gv.Rows[0].Cells[columnsCount - 1].Text = "";
            gv.Rows[0].Cells[0].Text = "";
            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[1].Text = "Data have not been created";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void BindGridVw()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@BIZSRC", ddlChannl.SelectedValue.ToString());
            htParam.Add("@CHNCLS", ddlsubchnl.SelectedValue.ToString());
            htParam.Add("@MEMTYPE",ddlmemtype.SelectedValue.ToString());
            htParam.Add("@KPI_CODE",ddlkpi.SelectedValue.ToString());

            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_CHN_CHNCLS_MEMTYP_MAP", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgmap.DataSource = ds;
                dgmap.DataBind();
                ViewState["grid"] = ds.Tables[0];


                if (dgmap.PageCount > Convert.ToInt32(Txtpage.Text))
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
                dgmap.DataSource = ds;
                dgmap.DataBind();
                //ShowNoResultFound1(ds.Tables[0], dgmap);
                //dgmap.DataSource = null;
                //dgmap.DataBind();
                //Txtpage.Text = "1";
                //btnprevious.Enabled = false;
                //btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "BindGridVw", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        BindGridVw();
        Loading_gif.Style.Add("display", "none");
        divunitcd.Style.Add("display", "block");

        btnnext.Visible = true;
        btnprevious.Visible = true;
        Txtpage.Visible = true;
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = dgmap.PageIndex;
            dgmap.PageIndex = pageIndex - 1;
            Txtpage.Text = Convert.ToString(Convert.ToInt32(Txtpage.Text) - 1);
            if (Txtpage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
            BindGridVw();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgmap.PageIndex;
            dgmap.PageIndex = pageIndex + 1;
            Txtpage.Text = Convert.ToString(Convert.ToInt32(Txtpage.Text) + 1);
            btnprevious.Enabled = true;
            if (Txtpage.Text == Convert.ToString(dgmap.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgmap.PageCount;
            BindGridVw();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgmap_Sorting(object sender, GridViewSortEventArgs e)
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
            if (dgSource.PageCount >= Convert.ToInt32(Txtpage.Text))
            {
                btnprevious.Enabled = false;
                Txtpage.Text = "1";
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "dgmap_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkbtcn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ErrorSession.aspx");
    }
    // Code added by Pratik
    protected void lnkSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((sender as LinkButton).NamingContainer as GridViewRow);
            string KPI_CODE = Convert.ToString(dgmap.DataKeys[row.RowIndex]["KPI_CODE"]);
            string mapcode = Convert.ToString(dgmap.DataKeys[row.RowIndex]["MAP_CODE"]);
            string url = "~/Application/Isys/Saim/RuleSetPages/FFContestPageStdDef.aspx?";
            url += "role=maker&flag=1&KpiCode=" + KPI_CODE + "&mapcode=" + mapcode;
            Response.Redirect(url, false);
        }
        catch(Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Std_Dfntn_Action_Value_Setup", "lnkSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessClassDAL;
using System.Collections;
using System.Globalization;
using System.Configuration;


public partial class Application_Isys_Saim_Masters_MAJOR_MVMNT : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    SqlDataReader dtRead;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            funchnlpopup(ddlchnl);
            ddlsubchnl.Items.Insert(0, new ListItem("SELECT", ""));
            ddlMemtyp.Items.Insert(0, new ListItem("SELECT", ""));

            FillDropdown(ddltyp, "T");
            FillDropdown(ddlapprul, "A");

           // BindGridview();
        }
        
    }

    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();

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
            ddl.Items.Insert(0, new ListItem("SELECT", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void getsubchl(DropDownList ddl, string channel)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", channel.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ChnClsDesc01";
                ddl.DataValueField = "ChnCls";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("SELECT", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlchnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        getsubchl(ddlsubchnl, ddlchnl.SelectedValue.ToString());
    }
    protected void ddlsubchnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlchnl.SelectedValue != "" && ddlsubchnl.SelectedValue != "")
        {
            getMemType(ddlMemtyp, ddlchnl.SelectedValue.ToString(), ddlsubchnl.SelectedValue.ToString());
        }
        else
        {
            ddlMemtyp.Items.Clear();
            ddlMemtyp.Items.Insert(0, new ListItem("SELECT", ""));
        }
    }

    protected void getMemType(DropDownList ddl, string channel, string Subchannel)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", channel.ToString());
            ht.Add("@CHNCLS", Subchannel.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_fillddlMemType", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("SELECT", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropdown(DropDownList ddl, string Flag)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", Flag.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_FILL_APPRSL_DROPDOWN", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("SELECT", ""));
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

    protected void BindGridview()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            //htParam.Add("@BIZSRC", ddlchnl.SelectedValue.ToString());
            //htParam.Add("@CHNCLS", ddlsbcn.SelectedValue.ToString());
            htParam.Add("@MEMTYPE", ddlMemtyp.SelectedValue.ToString());
            htParam.Add("@CMPNSTN_CODE", ddlapprul.SelectedValue.ToString());

            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_TBL_DUM_MVMNT_NEW_DESG", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgmvmt.DataSource = ds;
                dgmvmt.DataBind();
                ViewState["grid"] = ds.Tables[0];

                lnk_rjct.Visible = true;
                lnkbtn_apprv.Visible = true;

                if (dgmvmt.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    btnnext.Visible = true;
                    btnprevious.Visible = true;
                    txtPage.Visible = true;
                   
                }
                else
                {
                    btnnext.Visible = false;
                }
                
            }
            
            //else
            //{
            //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //    dgmvmt.DataSource = ds;
            //    dgmvmt.DataBind();
            //    int columncount = dgmvmt.Rows[0].Cells.Count;
            //    dgmvmt.Rows[0].Cells.Clear();
            //    dgmvmt.Rows[0].Cells.Add(new TableCell());
            //    dgmvmt.Rows[0].Cells[0].ColumnSpan = columncount;
            //    dgmvmt.Rows[0].Cells[0].Text = "No Records Found";
            //    dgmvmt.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;

            //}
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnsrch_Click(object sender, EventArgs e)
    {
        BindGridview();
    }
    protected void lnkbtn_apprv_Click(object sender, EventArgs e)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            foreach(GridViewRow gvrow in dgmvmt.Rows)
            {
                var checkbox = gvrow.FindControl("chckmem") as CheckBox;

                if (checkbox.Checked)
                {
                    Label lblmemcd = gvrow.FindControl("lblmemcd") as Label;
                    Label lblseq = gvrow.FindControl("lblseq") as Label;

                    htParam.Add("@MEM_CODE",lblmemcd.Text);
                    htParam.Add("@SEQ_NO", lblseq.Text);
                    htParam.Add("@Flag", "A");

                    ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_FLAG_MST_TBL_DUM_MVMNT_NEW_DESG", htParam);
                    //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Member has been Approved')", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong..')", true);
                    //}
                    BindGridview();
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Record')", true);
                //}
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
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgmvmt.PageIndex;
            dgmvmt.PageIndex = pageIndex - 1;
            BindGridview();
            //grdsyn.DataSource = (DataTable)Session["grid"];
            //grdsyn.DataBind();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgmvmt.PageIndex;
            dgmvmt.PageIndex = pageIndex + 1;
            BindGridview();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgmvmt.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgmvmt.PageCount;
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
    protected void lnk_rjct_Click(object sender, EventArgs e)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            foreach (GridViewRow gvrow in dgmvmt.Rows)
            {
                var checkbox = gvrow.FindControl("chckmem") as CheckBox;

                if (checkbox.Checked)
                {
                    Label lblmemcd = gvrow.FindControl("lblmemcd") as Label;
                    Label lblseq = gvrow.FindControl("lblseq") as Label;

                    htParam.Add("@MEM_CODE", lblmemcd.Text);
                    htParam.Add("@SEQ_NO", lblseq.Text);
                    htParam.Add("@Flag", "");

                    ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_FLAG_MST_TBL_DUM_MVMNT_NEW_DESG", htParam);
                    //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Member has been Rejected')", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong..')", true);
                    //}
                    BindGridview();
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Record')", true);
                //}
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
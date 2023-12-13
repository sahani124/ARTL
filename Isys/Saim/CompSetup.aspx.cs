#region Namespace
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
#endregion

public partial class Application_ISys_Saim_CompSetup : BaseClass
{
    #region Declaration
    string RuleNo = "", ProdCode = "";
    DataSet ds = new DataSet();
    DataTable DtAppTo = new DataTable();
    DataTable DtProd = new DataTable();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            if (!IsPostBack)
            {
                oCommon.getDropDown(ddlFrequency, "frequency", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlFrequency.Items.Insert(0, new ListItem("-- Select --", ""));
                
                if (Request.QueryString["RuleNo"] != null)
                {
                    RuleNo = Request.QueryString["RuleNo"].ToString().Trim();
                }
                if (Request.QueryString["ProdCode"] != null)
                {
                    ProdCode = Request.QueryString["ProdCode"].ToString().Trim();
                }
                if (RuleNo != null && RuleNo != "")
                {
                    txtCmpTyp.Enabled = false;
                    txtCmpDesc.Enabled = false;
                    ddlFrequency.Enabled = false;
                    txtEffDt.Enabled = false;
                    btnSet.Enabled = false;

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@RuleNo", RuleNo);
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpSTPDtlsOnRuleEdit", htParam);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtCmpTyp.Text = ds.Tables[0].Rows[0]["CompType"].ToString().Trim();
                        txtCmpDesc.Text = ds.Tables[0].Rows[0]["CompDesc01"].ToString().Trim();
                        ddlFrequency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString().Trim();
                        txtEffDt.Text = ds.Tables[0].Rows[0]["EffDate"].ToString().Trim();
                        lblcmpTypeRuleval.Text = ds.Tables[0].Rows[0]["CompType"].ToString().Trim();
                        txtCmpName.Text = ds.Tables[0].Rows[0]["CompName"].ToString().Trim();
                        lblCmpRuleNoval.Text = ds.Tables[1].Rows[0]["CompRuleNo"].ToString().Trim();
                        lblTmpRuleNoval.Text = RuleNo;
                        lblTmpCompCode.Text = ds.Tables[0].Rows[0]["CompCode"].ToString().Trim();
                    }

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@CompType", txtCmpTyp.Text.Trim());
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpRuleDtlsOnEdit", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvCrsAppTo.DataSource = ds.Tables[0];
                        gvCrsAppTo.DataBind();
                        ViewState["DtAppTo"] = ds.Tables[0];
                        //gvCrsAppTo.Columns[8].Visible = false;
                        gvCrsAppTo.Columns[9].Visible = true;
                        tblCmpRuleSetup.Visible = true;
                        btnSetRule.Visible = true;
                        funchnlpopup(ddlBizSrc);

                        ddlChnCls.Items.Insert(0, new ListItem("--Select--", ""));
                        ddlMemType.Items.Insert(0, new ListItem("--Select--", ""));
                    }
                }
                if (ProdCode != null && ProdCode != "")
                {
                    txtCmpName.Enabled = false;
                    ddlBizSrc.Enabled = false;
                    ddlChnCls.Enabled = false;
                    ddlMemType.Enabled = false;
                    txtEffDate.Enabled = false;
                    Image1.Visible = false;
                    btnAdd.Enabled = false;
                    gvCrsAppTo.Enabled = false;
                    btnSetRule.Enabled = false;

                    trtmprulset.Visible = false;
                    trtmprulgrid.Visible = false;
                    trbtnSetRule.Visible = false;
                    tblTmpProd.Visible = true;

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@CompType", txtCmpTyp.Text.Trim());
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpRuleDtlsOnEdit", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvCheckRule.DataSource = ds.Tables[0];
                        gvCheckRule.DataBind();
                        ViewState["DtAppTo"] = ds.Tables[0];
                        ViewState["gv1"] = ds.Tables[0];
                        tblCmpRuleSetup.Visible = true;
                        btnSetRule.Visible = true;

                    }

                    htParam.Clear();
                    drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetProduct", htParam);
                    if (drRead.HasRows)
                    {
                        ddlProduct.DataSource = drRead;
                        ddlProduct.DataTextField = "ProdDesc1";
                        ddlProduct.DataValueField = "ProdCode";
                        ddlProduct.DataBind();
                    }
                    drRead.Close();

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@RuleNo", RuleNo);
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpProdDtlsOnEdit", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvCmpRuleSetup.DataSource = ds.Tables[0];
                        gvCmpRuleSetup.DataBind();
                        ViewState["DtProd"] = ds.Tables[0];
                        ViewState["gv2"] = ds.Tables[0];
                        //gvCmpRuleSetup.Columns[10].Visible = false;
                        gvCmpRuleSetup.Columns[11].Visible = true;
                        ddlProduct.SelectedValue = ds.Tables[0].Rows[0]["ProductID"].ToString().Trim();
                        gvCmpRuleSetup.Visible = true;
                        lblProdSrNo.Text = Convert.ToString(Convert.ToInt32(lblProdSrNo.Text) + 1);
                        btnSetProduct.Visible = true;
                    }
                }
            }
            btnSet.Attributes.Add("onClick", "Javascript:return funvalidateOnSet();");
            btnAdd.Attributes.Add("onClick", "Javascript:return funvalidateOnAdd();");
            btnSetRule.Attributes.Add("onClick", "Javascript:return funvalidateOnSetRule();");
            btnProAdd.Attributes.Add("onClick", "Javascript:return funvalidateOnProdAdd();");
        }
        catch (Exception ex)
        {
            // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            // string sRet = oInfo.Name;
            // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region funchnlpopup
    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDal.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "funchnlpopup", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ddlBizSrc_SelectedIndexChanged
    protected void ddlBizSrc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlBizSrc.SelectedValue.ToString().Trim());

            drRead = objDal.Common_exec_reader_prc("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddlChnCls.DataSource = drRead;
                ddlChnCls.DataTextField = "ChnClsDesc01";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            drRead.Close();
            ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));

            lblCmpCodeval.Text = lblcmpTypeRuleval.Text.Trim() + "_" + ddlBizSrc.SelectedValue.Trim() + "_" + ddlMemType.SelectedValue.Trim();

        }
        catch (Exception ex)
        {
            // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlBizSrc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ddlChnCls_SelectedIndexChanged
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlBizSrc.SelectedValue);
            ht.Add("@ChnCls", ddlChnCls.SelectedValue);

            drRead = objDal.Common_exec_reader_prc("prc_GetMemType", ht);
            if (drRead.HasRows)
            {
                ddlMemType.DataSource = drRead;
                ddlMemType.DataTextField = "MemTypeDesc01";
                ddlMemType.DataValueField = "MemType";
                ddlMemType.DataBind();
            }
            drRead.Close();
            ddlMemType.Items.Insert(0, new ListItem("-- Select --", ""));

        }
        catch (Exception ex)
        {
            // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlChnCls_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ddlMemType_SelectedIndexChanged
    protected void ddlMemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCmpCodeval.Text = lblcmpTypeRuleval.Text.Trim() + "_" + ddlBizSrc.SelectedValue.Trim() + "_" + ddlMemType.SelectedValue.Trim();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlMemType_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCrsAppTo_RowDataBound
    protected void gvCrsAppTo_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToString() == "E")
                    {
                        Label lblRuleNo = (Label)e.Row.FindControl("lblCmpRuleNo");
                        if (RuleNo == lblRuleNo.Text)
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }
                        htParam.Clear();
                        htParam.Add("@ruleno", lblRuleNo.Text);
                        DataSet dsresult = objDal.GetDataSetForPrc_SAIM("Prc_ChkRuleNo", htParam);
                        if (dsresult.Tables.Count > 0)
                        {
                            if (dsresult.Tables[0].Rows.Count > 0)
                            {
                                e.Row.Cells[8].Enabled = false;
                            }
                        }
                    }
                }
                //if (gvCrsAppTo.EditIndex >= 0)
                //{
                //    Label lblChnCls = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblChnCls");
                //    Label lblAgenttype = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblAgenttype");

                //    DropDownList ddlEditChnCls = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditChnCls");
                //    DropDownList ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
                //}
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCrsAppTo_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion
    
    #region gvCrsAppTo_RowEditing
    protected void gvCrsAppTo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtAppTo"];
        gvCrsAppTo.EditIndex = e.NewEditIndex;
        Label lblCmpRuleNo = null;
        Label lblCmpCode = null;
        Label lblChnCls = null;
        Label lblAgenttype = null;
        Label lblBizSrc = null;
        Label lblEffDt = null;
        //TextBox txtCmpRuleNo = null;
        //TextBox txtCmpCode = null;
        DropDownList ddlEditChnCls = null;
        DropDownList ddlEditAgentType = null;
        DropDownList ddlEditBizSrc = null;
        TextBox txtEffDt = null;

        if (gvCrsAppTo.EditIndex >= 0)
        {
            lblCmpRuleNo = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblCmpRuleNo");
            lblCmpCode = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblCmpCode");
            lblBizSrc = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblBizSrc");
            lblChnCls = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblChnCls");
            lblAgenttype = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblAgenttype");
            lblEffDt = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblEffDt");
        }

        gvCrsAppTo.DataSource = dt;
        gvCrsAppTo.DataBind();

        if (gvCrsAppTo.EditIndex >= 0)
        {
            //txtCmpRuleNo = (TextBox)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("txtCmpRuleNo");
            //txtCmpCode = (TextBox)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("txtCmpCode");
            ddlEditBizSrc = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditBizSrc");
            ddlEditChnCls = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditChnCls");
            ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
            txtEffDt = (TextBox)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("txtEffDt");
        }

        drRead = objDal.exec_reader_prc("Prc_ddlmgrchnnl");
        if (drRead.HasRows)
        {
            ddlEditBizSrc.DataSource = drRead;
            ddlEditBizSrc.DataTextField = "ChannelDesc01";
            ddlEditBizSrc.DataValueField = "BizSrc";
            ddlEditBizSrc.DataBind();
        }
        drRead.Close();
        ddlEditBizSrc.Items.FindByText(lblBizSrc.Text.Trim()).Selected = true;


        drRead = objDal.exec_reader_prc("prc_GetChannelClass");
        if (drRead.HasRows)
        {
            ddlEditChnCls.DataSource = drRead;
            ddlEditChnCls.DataTextField = "ChnClsDesc01";
            ddlEditChnCls.DataValueField = "ChnCls";
            ddlEditChnCls.DataBind();
        }
        drRead.Close();
        ddlEditChnCls.Items.FindByText(lblChnCls.Text.Trim()).Selected = true;

        string strSalesChn = ddlEditBizSrc.SelectedValue.ToString().Trim();

        Hashtable ht = new Hashtable();
        ht.Add("@BizSrc", strSalesChn);
        ht.Add("@ChnCls", ddlEditChnCls.SelectedValue);
        drRead = objDal.Common_exec_reader_prc("prc_GetMemType", ht);
        if (drRead.HasRows)
        {
            ddlEditAgentType.DataSource = drRead;
            ddlEditAgentType.DataTextField = "MemTypeDesc01";
            ddlEditAgentType.DataValueField = "MemType";
            ddlEditAgentType.DataBind();
        }
        else
        {
            ddlEditAgentType.Items.Clear();
        }
        drRead.Close();

        ddlEditAgentType.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEditAgentType.Items.FindByText(lblAgenttype.Text.Trim()).Selected = true;

        //txtCmpRuleNo.Text = lblCmpRuleNo.Text;
        //txtCmpCode.Text = lblCmpCode.Text;
        txtEffDt.Text = lblEffDt.Text;
    }
    #endregion

    #region gvCrsAppTo_RowCancelingEdit
    protected void gvCrsAppTo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtAppTo"];
        gvCrsAppTo.EditIndex = -1;
        gvCrsAppTo.DataSource = dt;
        gvCrsAppTo.DataBind();
    }
    #endregion

    #region gvCrsAppTo_RowUpdating
    protected void gvCrsAppTo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlEditChnCls = null;
        DropDownList ddlEditAgentType = null;
        DropDownList ddlEditBizSrc = null;
        TextBox txtEffDt = null;
        LinkButton lnkActInAct = null;
        HiddenField hdnActInAct = null;

        if (gvCrsAppTo.EditIndex >= 0)
        {
            ddlEditBizSrc = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditBizSrc");
            ddlEditChnCls = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditChnCls");
            ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
            txtEffDt = (TextBox)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("txtEffDt");
            lnkActInAct = (LinkButton)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lnkActInAct");
            hdnActInAct = (HiddenField)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("hdnActInAct");
        }

        if (ddlEditChnCls.SelectedItem.Text == "-- Select --")
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<Script Language=\"JavaScript\">alert('Please Select SalesChannel.');</Script>"); return;
            return;
        }

        if (ddlEditAgentType.SelectedItem.Text == "-- Select --")
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<Script Language=\"JavaScript\">alert('Please Select AgentType.');</Script>"); return;
            return;
        }

        DataTable dt = (DataTable)ViewState["DtAppTo"];
        dt.Rows[e.RowIndex]["BizSrcID"] = ddlEditBizSrc.SelectedItem.Value;
        dt.Rows[e.RowIndex]["BizSrc"] = ddlEditBizSrc.SelectedItem.Text;
        dt.Rows[e.RowIndex]["ChnClsID"] = ddlEditChnCls.SelectedItem.Value;
        dt.Rows[e.RowIndex]["ChnCls"] = ddlEditChnCls.SelectedItem.Text;
        dt.Rows[e.RowIndex]["AgentTypeID"] = ddlEditAgentType.SelectedItem.Value;
        dt.Rows[e.RowIndex]["AgentType"] = ddlEditAgentType.SelectedItem.Text;
        dt.Rows[e.RowIndex]["EffDtID"] = txtEffDt.Text;
        dt.Rows[e.RowIndex]["EffDt"] = txtEffDt.Text;
        if (Request.QueryString["Type"].ToString().Trim() == "E")
        {
            dt.Rows[e.RowIndex]["FlagID"] = hdnActInAct.Value;
            dt.Rows[e.RowIndex]["Flag"] = lnkActInAct.Text;
        }
        dt.AcceptChanges();

        gvCrsAppTo.EditIndex = -1;
        gvCrsAppTo.DataSource = dt;
        gvCrsAppTo.DataBind();
        ViewState["DtAppTo"] = dt;
    }
    #endregion

    #region gvCrsAppTo_RowDeleting
    protected void gvCrsAppTo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtAppTo"];
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        gvCrsAppTo.DataSource = dt;
        gvCrsAppTo.DataBind();

        ViewState["DtAppTo"] = dt;

        if (gvCrsAppTo.Rows.Count > 0)
        {
            if (gvCrsAppTo.Rows[0].Cells[0].Text == "No Records Found!")
            {
                ShowNoResultFound((DataTable)ViewState["DtAppTo"], gvCrsAppTo);
            }
        }
        else
        {
            ShowNoResultFound((DataTable)ViewState["DtAppTo"], gvCrsAppTo);
        }
        lblSrNo.Text = Convert.ToString(Convert.ToInt32(lblSrNo.Text) - 1);
    }
    #endregion

    #region ShowNoResultFound
    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        gv.Rows[0].Cells.Clear();
        gv.Rows[0].Cells.Add(new TableCell());
        gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
        gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[0].Font.Bold = true;
        gv.Rows[0].Cells[0].Text = "No Records Found!";
        source.Rows.Clear();
        gvCrsAppTo.Visible = false;
    }
    #endregion

    #region ShowNoResultFoundProd
    private void ShowNoResultFoundProd(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        gv.Rows[0].Cells.Clear();
        gv.Rows[0].Cells.Add(new TableCell());
        gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
        gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[0].Font.Bold = true;
        gv.Rows[0].Cells[0].Text = "No Records Found!";
        source.Rows.Clear();
        gvCmpRuleSetup.Visible = false;
    }
    #endregion

    #region ddlEditBizSrc_SelectedIndexChanged
    protected void ddlEditBizSrc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label lblCmpCode = null;
            HiddenField hdnCmpCode = null;
            DropDownList ddlEditAgentType = null;
            DropDownList ddlEditChnCls = null;
            DropDownList ddlEditBizSrc = null;

            if (gvCrsAppTo.EditIndex >= 0)
            {
                ddlEditBizSrc = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditBizSrc");
                ddlEditChnCls = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditChnCls");
                lblCmpCode = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblCmpCode");
                hdnCmpCode = (HiddenField)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("hdnCmpCode");
                ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
            }

            string strSalesChn = ddlEditBizSrc.SelectedValue.ToString().Trim();

            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlEditBizSrc.SelectedValue.ToString().Trim());

            drRead = objDal.Common_exec_reader_prc("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddlEditChnCls.DataSource = drRead;
                ddlEditChnCls.DataTextField = "ChnClsDesc01";
                ddlEditChnCls.DataValueField = "ChnCls";
                ddlEditChnCls.DataBind();
            }
            else
            {
                ddlEditChnCls.Items.Clear();
            }
            drRead.Close();

            ddlEditChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
            lblCmpCode.Text = lblcmpTypeRuleval.Text + ddlEditBizSrc.SelectedValue.Trim() + ddlEditAgentType.SelectedValue.Trim();
            hdnCmpCode.Value = lblCmpCode.Text;

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlEditBizSrc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ddlEditChnCls_SelectedIndexChanged
    protected void ddlEditChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlEditChnCls = null;
            DropDownList ddlEditAgentType = null;
            DropDownList ddlEditBizSrc = null;

            if (gvCrsAppTo.EditIndex >= 0)
            {
                ddlEditBizSrc = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditBizSrc");
                ddlEditChnCls = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditChnCls");
                ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
            }

            string strSalesChn = ddlEditChnCls.SelectedValue.ToString().Trim();

            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlEditBizSrc.SelectedValue);
            ht.Add("@ChnCls", ddlEditChnCls.SelectedValue);

            drRead = objDal.Common_exec_reader_prc("prc_GetMemType", ht);
            if (drRead.HasRows)
            {
                ddlEditAgentType.DataSource = drRead;
                ddlEditAgentType.DataTextField = "MemTypeDesc01";
                ddlEditAgentType.DataValueField = "MemType";
                ddlEditAgentType.DataBind();
            }
            else
            {
                ddlEditAgentType.Items.Clear();
            }
            drRead.Close();

            ddlEditAgentType.Items.Insert(0, new ListItem("-- Select --", ""));

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlEditChnCls_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ddlEditAgentType_SelectedIndexChanged
    protected void ddlEditAgentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label lblCmpCode = null;
            HiddenField hdnCmpCode = null;
            DropDownList ddlEditAgentType = null;
            DropDownList ddlEditBizSrc = null;

            if (gvCrsAppTo.EditIndex >= 0)
            {
                lblCmpCode = (Label)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("lblCmpCode");
                hdnCmpCode = (HiddenField)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("hdnCmpCode");
                ddlEditBizSrc = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditBizSrc");
                ddlEditAgentType = (DropDownList)gvCrsAppTo.Rows[gvCrsAppTo.EditIndex].FindControl("ddlEditAgentType");
            }
            lblCmpCode.Text = lblcmpTypeRuleval.Text + ddlEditBizSrc.SelectedValue.Trim() + ddlEditAgentType.SelectedValue.Trim();
            hdnCmpCode.Value = lblCmpCode.Text;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "ddlEditAgentType_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCmpRuleSetup_RowDataBound
    protected void gvCmpRuleSetup_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToString() == "E")
                    {
                        HiddenField lblProduct = (HiddenField)e.Row.FindControl("hdnProduct");
                        Label lblCmpRuleNo = (Label)e.Row.FindControl("lblCmpRuleNo");
                        if (ProdCode == lblProduct.Value)
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }

                        htParam.Clear();
                        htParam.Add("@product", lblProduct.Value);
                        htParam.Add("@ruleno", lblCmpRuleNo.Text.Trim());
                        DataSet dsresult = objDal.GetDataSetForPrc_SAIM("Prc_ChkProd", htParam);
                        if (dsresult.Tables.Count > 0)
                        {
                            if (dsresult.Tables[0].Rows.Count > 0)
                            {
                                e.Row.Cells[10].Enabled = false;
                            }
                        }
                    }
                }

                //DropDownList ddlChnCls = null;
                //DropDownList ddlMemType = null;
                //DropDownList ddlBizSrc = null;

                //ddlBizSrc = (DropDownList)e.Row.FindControl("ddlBizSrc");
                //ddlChnCls = (DropDownList)e.Row.FindControl("ddlChnCls");
                //ddlMemType = (DropDownList)e.Row.FindControl("ddlMemType");

                //funchnlpopup(ddlBizSrc);

                //ddlChnCls.Items.Insert(0, new ListItem("--Select--", ""));
                //ddlMemType.Items.Insert(0, new ListItem("--Select--", ""));
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCmpRuleSetup_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCmpRuleSetup_RowEditing
    protected void gvCmpRuleSetup_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtProd"];
        gvCmpRuleSetup.EditIndex = e.NewEditIndex;
        Label lblProduct = null;
        Label lblProductFrm = null;
        Label lblProductTo = null;
        Label lblCmpValTyp = null;
        Label lblCmpVal = null;
        Label lblPerfDesc = null;

        if (gvCmpRuleSetup.EditIndex >= 0)
        {
            lblProduct = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblProduct");
            lblProductFrm = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblProductFrm");
            lblProductTo = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblProductTo");
            lblCmpValTyp = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblCmpValTyp");
            lblCmpVal = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblCmpVal");

            lblPerfDesc = (Label)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("lblPerfDesc");
        }

        gvCmpRuleSetup.DataSource = dt;
        gvCmpRuleSetup.DataBind();
        ViewState["gv2"] = dt;
        DropDownList ddlProduct = null;
        TextBox txtProductFrm = null;
        TextBox txtProductTo = null;
        RadioButtonList rdbCmpVal = null;
        TextBox txtCmpVal = null;
        DropDownList ddlPerfCode = null;
        if (gvCmpRuleSetup.EditIndex >= 0)
        {
            ddlProduct = (DropDownList)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("ddlProduct");
            txtProductFrm = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtProductFrm");
            txtProductTo = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtProductTo");
            rdbCmpVal = (RadioButtonList)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("rdbCmpVal");
            txtCmpVal = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtCmpVal");

            ddlPerfCode = (DropDownList)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("ddlPerfCode");
        }

        htParam.Clear();
        drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetProduct", htParam);
        if (drRead.HasRows)
        {
            ddlProduct.DataSource = drRead;
            ddlProduct.DataTextField = "ProdDesc1";
            ddlProduct.DataValueField = "ProdCode";
            ddlProduct.DataBind();
        }
        drRead.Close();
        ddlProduct.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlProduct.Items.FindByText(lblProduct.Text.Trim()).Selected = true;
        txtProductFrm.Text = lblProductFrm.Text;
        txtProductTo.Text = lblProductTo.Text;
        rdbCmpVal.Items.FindByText(lblCmpValTyp.Text.Trim()).Selected = true;
        txtCmpVal.Text = lblCmpVal.Text;
    }
    #endregion

    #region gvCmpRuleSetup_RowCancelingEdit
    protected void gvCmpRuleSetup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtProd"];
        gvCmpRuleSetup.EditIndex = -1;
        gvCmpRuleSetup.DataSource = dt;
        gvCmpRuleSetup.DataBind();
        ViewState["gv2"] = dt;
    }
    #endregion

    #region gvCmpRuleSetup_RowUpdating
    protected void gvCmpRuleSetup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlProduct = null;
        TextBox txtProductFrm = null;
        TextBox txtProductTo = null;
        RadioButtonList rdbCmpVal = null;
        TextBox txtCmpVal = null;
        TextBox txtPerfCode = null;
        TextBox txtPerfDesc = null;
        if (gvCmpRuleSetup.EditIndex >= 0)
        {
            ddlProduct = (DropDownList)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("ddlProduct");
            txtProductFrm = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtProductFrm");
            txtProductTo = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtProductTo");
            rdbCmpVal = (RadioButtonList)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("rdbCmpVal");
            txtCmpVal = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtCmpVal");

            txtPerfCode = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtPerfCode");
            txtPerfDesc = (TextBox)gvCmpRuleSetup.Rows[gvCmpRuleSetup.EditIndex].FindControl("txtPerfDesc");
        }

        DataTable dt = (DataTable)ViewState["DtProd"];
        dt.Rows[e.RowIndex]["ProductID"] = ddlProduct.SelectedItem.Value;
        dt.Rows[e.RowIndex]["Product"] = ddlProduct.SelectedItem.Text;
        dt.Rows[e.RowIndex]["ProductFrmID"] = txtProductFrm.Text;
        dt.Rows[e.RowIndex]["ProductFrm"] = txtProductFrm.Text;
        dt.Rows[e.RowIndex]["ProductToID"] = txtProductTo.Text;
        dt.Rows[e.RowIndex]["ProductTo"] = txtProductTo.Text;
        dt.Rows[e.RowIndex]["CompValTypID"] = rdbCmpVal.SelectedItem.Value;
        dt.Rows[e.RowIndex]["CompValTyp"] = rdbCmpVal.SelectedItem.Text;
        dt.Rows[e.RowIndex]["CmpValID"] = txtCmpVal.Text;
        dt.Rows[e.RowIndex]["CmpVal"] = txtCmpVal.Text;

        dt.Rows[e.RowIndex]["PerfCode"] = txtPerfCode.Text;
        dt.Rows[e.RowIndex]["PerfDesc"] = txtPerfDesc.Text;
        dt.AcceptChanges();

        gvCmpRuleSetup.EditIndex = -1;
        gvCmpRuleSetup.DataSource = dt;
        gvCmpRuleSetup.DataBind();
        ViewState["DtProd"] = dt;
        ViewState["gv2"] = dt;

    }
    #endregion

    #region gvCmpRuleSetup_RowDeleting
    protected void gvCmpRuleSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["DtProd"];
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        gvCmpRuleSetup.DataSource = dt;
        gvCmpRuleSetup.DataBind();
        ViewState["gv2"] = dt;

        ViewState["DtProd"] = dt;

        if (gvCmpRuleSetup.Rows.Count > 0)
        {
            if (gvCmpRuleSetup.Rows[0].Cells[0].Text == "No Records Found!")
            {
                ShowNoResultFoundProd((DataTable)ViewState["DtProd"], gvCmpRuleSetup);
            }
        }
        else
        {
            ShowNoResultFoundProd((DataTable)ViewState["DtProd"], gvCmpRuleSetup);
        }
        lblProdSrNo.Text = Convert.ToString(Convert.ToInt32(lblProdSrNo.Text) - 1);
    }
    #endregion

    #region gvCheckRule_RowDataBound
    protected void gvCheckRule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToString() == "E")
                    {
                        LinkButton lnkSetProduct = (LinkButton)e.Row.FindControl("lnkSetProduct");
                        Label lblRuleNo = (Label)e.Row.FindControl("lblRuleNo");
                        //if (RuleNo != lblRuleNo.Text)
                        //{
                        //    lnkSetProduct.Enabled = false;
                        //}
                        if (RuleNo == lblRuleNo.Text)
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCheckRule_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCheckRule_PageIndexChanging
    protected void gvCheckRule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv1"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvCheckRule.PageIndex = e.NewPageIndex;
            dv.Sort = gvCheckRule.Attributes["SortExpression"];

            if (gvCheckRule.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvCheckRule.DataSource = dv;
            gvCheckRule.DataBind();
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCheckRule_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCheckRule_Sorting
    protected void gvCheckRule_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["gv1"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCheckRule_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCmpRuleSetup_PageIndexChanging
    protected void gvCmpRuleSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv2"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvCmpRuleSetup.PageIndex = e.NewPageIndex;
            dv.Sort = gvCmpRuleSetup.Attributes["SortExpression"];

            if (gvCmpRuleSetup.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvCmpRuleSetup.DataSource = dv;
            gvCmpRuleSetup.DataBind();
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCmpRuleSetup_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCmpRuleSetup_Sorting
    protected void gvCmpRuleSetup_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["gv2"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "gvCmpRuleSetup_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnSet_Click
    protected void btnSet_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
            htParam.Add("@CmpDesc", txtCmpDesc.Text.Trim());
            htParam.Add("@Freq", ddlFrequency.SelectedValue.Trim());
            htParam.Add("@EffDt", Convert.ToDateTime(txtEffDt.Text.Trim()));
            htParam.Add("@CreatedBy", Session["UserID"].ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpDtls", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblCmpRuleNoval.Text = ds.Tables[0].Rows[0]["CompRuleNo"].ToString().Trim();
            }

            txtCmpTyp.Enabled = false;
            txtCmpDesc.Enabled = false;
            ddlFrequency.Enabled = false;
            txtEffDt.Enabled = false;
            btnSet.Enabled = false;
            tblCmpRuleSetup.Visible = true;
            btnCalendar.Visible = false;

            //htParam.Clear();
            //drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetCompType", htParam);
            //if (drRead.HasRows)
            //{
            //    ddlCmpType.DataSource = drRead;
            //    ddlCmpType.DataTextField = "CompDesc01";
            //    ddlCmpType.DataValueField = "CompType";
            //    ddlCmpType.DataBind();
            //}
            //drRead.Close();
            //ddlCmpType.Items.Insert(0, new ListItem("-- Select --", "0"));

            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("prc_GetCompType", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblcmpTypeRuleval.Text = ds.Tables[0].Rows[0]["CompType"].ToString().Trim();
                //ddlCmpType.SelectedValue = ds.Tables[0].Rows[0]["CompType"].ToString().Trim();
                //ddlCmpType.Enabled = false;
                lblCmpCodeval.Text = lblcmpTypeRuleval.Text.Trim();
            }

            //DataTable dt = new DataTable();
            //dt.Columns.Add("SrNo");
            //DataRow dr = dt.NewRow();
            //dr["SrNo"] = "1";
            //dt.Rows.Add(dr);
            //gvCmpRuleSetup.DataSource = dt;
            //gvCmpRuleSetup.DataBind();

            funchnlpopup(ddlBizSrc);

            ddlChnCls.Items.Insert(0, new ListItem("--Select--", ""));
            ddlMemType.Items.Insert(0, new ListItem("--Select--", ""));

            DtAppTo.Columns.Add("SrNo");
            DtAppTo.Columns.Add("RuleNoID");
            DtAppTo.Columns.Add("RuleNo");
            DtAppTo.Columns.Add("CompCodeID");
            DtAppTo.Columns.Add("CompCode");
            DtAppTo.Columns.Add("BizSrcID");
            DtAppTo.Columns.Add("BizSrc");
            DtAppTo.Columns.Add("ChnClsID");
            DtAppTo.Columns.Add("ChnCls");
            DtAppTo.Columns.Add("AgentTypeID");
            DtAppTo.Columns.Add("AgentType");
            DtAppTo.Columns.Add("EffDtID");
            DtAppTo.Columns.Add("EffDt");
            //if (Request.QueryString["Type"].ToString().Trim() == "E")
            //{
                DtAppTo.Columns.Add("FlagID");
                DtAppTo.Columns.Add("Flag");
            //}
            ViewState["DtAppTo"] = DtAppTo;

            if (gvCrsAppTo.Rows.Count > 0)
            {
                if (gvCrsAppTo.Rows[0].Cells[0].Text == "No Records Found!")
                {
                    ShowNoResultFound((DataTable)ViewState["DtAppTo"], gvCrsAppTo);
                }
            }
            else
            {
                ShowNoResultFound((DataTable)ViewState["DtAppTo"], gvCrsAppTo);
            }
            btnSetRule.Visible = true;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "btnSet_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DtAppTo = (DataTable)ViewState["DtAppTo"];
            DataRow dataRow = DtAppTo.NewRow();
            dataRow["SrNo"] = lblSrNo.Text;
            dataRow["RuleNoID"] = lblCmpRuleNoval.Text;
            dataRow["RuleNo"] = lblCmpRuleNoval.Text;
            dataRow["CompCodeID"] = lblCmpCodeval.Text;
            dataRow["CompCode"] = lblCmpCodeval.Text;
            dataRow["BizSrcID"] = ddlBizSrc.SelectedItem.Value;
            dataRow["BizSrc"] = ddlBizSrc.SelectedItem.Text;
            dataRow["ChnClsID"] = ddlChnCls.SelectedItem.Value;
            dataRow["ChnCls"] = ddlChnCls.SelectedItem.Text;
            dataRow["AgentTypeID"] = ddlMemType.SelectedItem.Value;
            dataRow["AgentType"] = ddlMemType.SelectedItem.Text;
            dataRow["EffDtID"] = txtEffDate.Text;
            dataRow["EffDt"] = txtEffDate.Text;
            //if (Request.QueryString["Type"].ToString().Trim() == "E")
            //{
                dataRow["FlagID"] = "0";
                dataRow["Flag"] = "Active";
            //}
            DtAppTo.Rows.Add(dataRow);
            ViewState["DtAppTo"] = DtAppTo;

            gvCrsAppTo.DataSource = DtAppTo.DefaultView;
            gvCrsAppTo.DataBind();
            gvCrsAppTo.Visible = true;
            lblSrNo.Text = Convert.ToString(Convert.ToInt32(lblSrNo.Text) + 1);
            lblCmpRuleNoval.Text = Convert.ToString(Convert.ToInt32(lblCmpRuleNoval.Text) + 1);
            //ddlCmpType.Enabled = false;
            txtCmpName.Enabled = false;
            //gvCmpRuleSetup.Enabled = false;

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "btnAdd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnSetRule_Click
    protected void btnSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            #region refresh data
            gvCheckRule.DataSource = null;
            gvCheckRule.DataBind();
            ViewState["gv1"] = null;
            //ViewState["DtAppTo"] = null;
            tblTmpProd.Visible = false;
            gvCmpRuleSetup.DataSource = null;
            gvCmpRuleSetup.DataBind();
            ViewState["gv2"] = null;
            btnSetProduct.Visible = false;
            ViewState["DtProd"] = null;
            #endregion

            gvCheckRule.DataSource = ViewState["DtAppTo"];
            gvCheckRule.DataBind();
            ViewState["gv1"] = ViewState["DtAppTo"];
            if (Request.QueryString["Type"].ToString() == "E")
            {
                gvCheckRule.Columns[6].Visible = true;
            }
            tblcmpprod.Visible = true;
            
            DtProd.Columns.Add("SrNo");
            DtProd.Columns.Add("RuleNo");
            DtProd.Columns.Add("CompCode");
            DtProd.Columns.Add("CompType");
            DtProd.Columns.Add("KPICode");
            DtProd.Columns.Add("ProductID");
            DtProd.Columns.Add("Product");
            DtProd.Columns.Add("ProductFrmID");
            DtProd.Columns.Add("ProductFrm");
            DtProd.Columns.Add("ProductToID");
            DtProd.Columns.Add("ProductTo");
            DtProd.Columns.Add("CompValTypID");
            DtProd.Columns.Add("CompValTyp");
            DtProd.Columns.Add("CmpVal");
            DtProd.Columns.Add("CmpValID");
            DtProd.Columns.Add("PerfCode");
            DtProd.Columns.Add("PerfDesc");
            DtProd.Columns.Add("Flag");
            DtProd.Columns.Add("FlagID");

            ViewState["DtProd"] = DtProd;

            if (gvCmpRuleSetup.Rows.Count > 0)
            {
                if (gvCmpRuleSetup.Rows[0].Cells[0].Text == "No Records Found!")
                {
                    ShowNoResultFoundProd((DataTable)ViewState["DtProd"], gvCmpRuleSetup);
                }
            }
            else
            {
                ShowNoResultFoundProd((DataTable)ViewState["DtProd"], gvCmpRuleSetup);
            }
            gvCrsAppTo.Visible = false;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "btnSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region lnkSetProduct_Click
    protected void lnkSetProduct_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            tblTmpProd.Visible = true;
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblRuleNo = (Label)grd.FindControl("lblRuleNo");
            Label lblCompCode = (Label)grd.FindControl("lblCompCode");
            lblTmpRuleNoval.Text = lblRuleNo.Text;
            lblTmpCompCode.Text = lblCompCode.Text;
            htParam.Clear();
            drRead = objDal.Common_exec_reader_prc_SAIM("prc_GetProduct", htParam);
            if (drRead.HasRows)
            {
                ddlProduct.DataSource = drRead;
                ddlProduct.DataTextField = "ProdDesc1";
                ddlProduct.DataValueField = "ProdCode";
                ddlProduct.DataBind();
            }
            drRead.Close();

            

            FillPerfIndCode();
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].ToString().Trim() == "E")
                {
                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@RuleNo", lblRuleNo.Text);
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpProdDtlsOnEdit", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvCmpRuleSetup.DataSource = ds.Tables[0];
                        gvCmpRuleSetup.DataBind();
                        ViewState["DtProd"] = ds.Tables[0];
                        ViewState["gv2"] = ds.Tables[0];
                        //gvCmpRuleSetup.Columns[10].Visible = false;
                        gvCmpRuleSetup.Columns[11].Visible = true;
                        gvCmpRuleSetup.Visible = true;
                        lblProdSrNo.Text = Convert.ToString(Convert.ToInt32(lblProdSrNo.Text) + 1);
                        btnSetProduct.Visible = true;
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        gvCmpRuleSetup.DataSource = ds.Tables[0];
                        gvCmpRuleSetup.DataBind();
                        int columnsCount = gvCmpRuleSetup.Columns.Count;
                        gvCmpRuleSetup.Rows[0].Cells.Clear();
                        gvCmpRuleSetup.Rows[0].Cells.Add(new TableCell());
                        gvCmpRuleSetup.Rows[0].Cells[0].ColumnSpan = columnsCount;
                        gvCmpRuleSetup.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                        gvCmpRuleSetup.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gvCmpRuleSetup.Rows[0].Cells[0].Font.Bold = true;
                        gvCmpRuleSetup.Rows[0].Cells[0].Text = "No Records Found!";
                        ds.Tables[0].Rows.Clear();
                        gvCmpRuleSetup.Visible = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "lnkSetProduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnProAdd_Click
    protected void btnProAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DtProd = (DataTable)ViewState["DtProd"];
           
                DataRow dataRow = DtProd.NewRow();
                dataRow["SrNo"] = lblProdSrNo.Text;
                dataRow["RuleNo"] = lblTmpRuleNoval.Text;
                dataRow["CompCode"] = lblTmpCompCode.Text;
                dataRow["CompType"] = txtCmpTyp.Text;
                dataRow["ProductID"] = ddlProduct.SelectedItem.Value;
                dataRow["Product"] = ddlProduct.SelectedItem.Text;
                dataRow["ProductFrmID"] = txtProdFrm.Text;
                dataRow["ProductFrm"] = txtProdFrm.Text;
                dataRow["ProductToID"] = txtProdTo.Text;
                dataRow["ProductTo"] = txtProdTo.Text;
                dataRow["CompValTypID"] = "";
                dataRow["CompValTyp"] = "";
                dataRow["CmpValID"] = "";
                dataRow["CmpVal"] = txtCmpVal.Text;
                dataRow["KPICode"] = ddlPerIndCode.SelectedValue.ToString().Trim();
                dataRow["KPICode"] = ddlPerIndCode.SelectedItem.Text.ToString().Trim();

                dataRow["FlagID"] = "0";
                dataRow["Flag"] = "Active";
                DtProd.Rows.Add(dataRow);

            ViewState["DtProd"] = DtProd;

            gvCmpRuleSetup.DataSource = DtProd.DefaultView;
            gvCmpRuleSetup.DataBind();
            ViewState["gv2"] = ViewState["DtProd"];
            gvCmpRuleSetup.Visible = true;
            if (Request.QueryString["Type"].ToString() == "E")
            {
                //gvCmpRuleSetup.Columns[10].Visible = false;
                gvCmpRuleSetup.Columns[12].Visible = true;
            }
            lblProdSrNo.Text = Convert.ToString(Convert.ToInt32(lblProdSrNo.Text) + 1);
            btnSetProduct.Visible = true;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "btnProAdd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnSetProduct_Click
    protected void btnSetProduct_Click(object sender, EventArgs e)
    {
        try
        {
            #region set rule
            htParam.Clear();
            htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpRuleDtls", htParam);
            htParam.Clear();
            List<string> lstRuleNo = new List<string>();
            List<string> lstCompCode = new List<string>();
            List<string> lstBizSrc = new List<string>();
            List<string> lstChnCls = new List<string>();
            List<string> lstMemTyp = new List<string>();
            List<string> lstEffDt = new List<string>();
            List<string> lstAct = new List<string>();
            for (int intRowCount = 0; intRowCount <= gvCheckRule.Rows.Count - 1; intRowCount++)
            {
                HiddenField lblCmpRuleNo = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[1].FindControl("hdnCmpRuleNo");
                lstRuleNo.Add(lblCmpRuleNo.Value.ToString().Trim());
                HiddenField lblCmpCode = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[2].FindControl("hdnCmpCode");
                lstCompCode.Add(lblCmpCode.Value.ToString().Trim());
                HiddenField lblBizSrc = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[3].FindControl("hdnBizSrc");
                lstBizSrc.Add(lblBizSrc.Value.ToString().Trim());
                HiddenField lblChnCls = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[4].FindControl("hdnChnCls");
                lstChnCls.Add(lblChnCls.Value.ToString().Trim());
                HiddenField lblMemTyp = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[5].FindControl("hdnAgentType");
                lstMemTyp.Add(lblMemTyp.Value.ToString().Trim());
                HiddenField lblEffDt = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[6].FindControl("hdnEffDt");
                lstEffDt.Add(lblEffDt.Value.ToString().Trim());
                HiddenField hdnActInAct = (HiddenField)gvCheckRule.Rows[intRowCount].Cells[7].FindControl("hdnActInAct");
                lstAct.Add(hdnActInAct.Value.ToString().Trim());

            }

            for (int intDataCount = 0; intDataCount <= lstBizSrc.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@CmpRuleNo", lstRuleNo[intDataCount]);
                htParam.Add("@CmpCode", lstCompCode[intDataCount]);
                htParam.Add("@CmpName", txtCmpName.Text.Trim());
                htParam.Add("@BizSrc", lstBizSrc[intDataCount]);
                htParam.Add("@ChnCls", lstChnCls[intDataCount]);
                htParam.Add("@MemType", lstMemTyp[intDataCount]);
                htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
                htParam.Add("@Freq", ddlFrequency.SelectedValue.Trim());
                htParam.Add("@EffDt", lstEffDt[intDataCount]);
                htParam.Add("@status", lstAct[intDataCount]);
                htParam.Add("@CreatedBy", Session["UserID"].ToString());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpRuleDtls", htParam);

            }
            #endregion

            #region set product
            htParam.Clear();
            List<string> lstProdRuleNo = new List<string>();
            List<string> lstProdCompCode = new List<string>();
            List<string> lstKPI = new List<string>();
            List<string> lstProduct = new List<string>();
            List<string> lstProductFrmID = new List<string>();
            List<string> lstProductToID = new List<string>();
            List<string> lstCmpValTypID = new List<string>();
            List<string> lstCmpVal = new List<string>();

            List<string> lstPerfCode = new List<string>();
            List<string> lstPrefDesc = new List<string>();

            List<string> lstProdAct = new List<string>();
            for (int intRowCount = 0; intRowCount <= gvCmpRuleSetup.Rows.Count - 1; intRowCount++)
            {
                Label lblCmpRuleNo = (Label)gvCmpRuleSetup.Rows[intRowCount].Cells[1].FindControl("lblCmpRuleNo");
                lstProdRuleNo.Add(lblCmpRuleNo.Text.ToString().Trim());
                Label lblCmpCode = (Label)gvCmpRuleSetup.Rows[intRowCount].Cells[2].FindControl("lblCmpCode");
                lstProdCompCode.Add(lblCmpCode.Text.ToString().Trim());
                HiddenField hdnKPICode = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[3].FindControl("hdnKPICode");
                lstKPI.Add(hdnKPICode.Value.ToString().Trim());
                HiddenField hdnProduct = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[4].FindControl("hdnProduct");
                lstProduct.Add(hdnProduct.Value.ToString().Trim());
                HiddenField hdnProductFrm = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[5].FindControl("hdnProductFrm");
                lstProductFrmID.Add(hdnProductFrm.Value.ToString().Trim());
                HiddenField hdnProductTo = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[6].FindControl("hdnProductTo");
                lstProductToID.Add(hdnProductTo.Value.ToString().Trim());
                HiddenField hdnCmpValTyp = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[7].FindControl("hdnCmpValTyp");
                lstCmpValTypID.Add(hdnCmpValTyp.Value.ToString().Trim());
                HiddenField hdnCmpVal = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[8].FindControl("hdnCmpVal");
                lstCmpVal.Add(hdnCmpVal.Value.ToString().Trim());

                HiddenField hdnPerfCode = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[11].FindControl("hdnPerfCode");
                lstPerfCode.Add(hdnPerfCode.Value.ToString().Trim());
                HiddenField hdnPerfDesc = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[11].FindControl("hdnPerfDesc");
                lstPrefDesc.Add(hdnPerfDesc.Value.ToString().Trim());

                HiddenField hdnProdActInAct = (HiddenField)gvCmpRuleSetup.Rows[intRowCount].Cells[11].FindControl("hdnProdActInAct");
                lstProdAct.Add(hdnProdActInAct.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstProdRuleNo.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@CmpRuleNo", lstProdRuleNo[intDataCount]);
                ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpRuleProdDtls", htParam);

            }

            for (int intDataCount = 0; intDataCount <= lstProdRuleNo.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@CmpRuleNo", lstProdRuleNo[intDataCount]);
                htParam.Add("@CmpCode", lstProdCompCode[intDataCount]);
                htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
                htParam.Add("@Freq", ddlFrequency.SelectedValue.Trim());
                htParam.Add("@ProdCode", lstProduct[intDataCount]);
                htParam.Add("@ProdFrom", lstProductFrmID[intDataCount]);
                htParam.Add("@ProdTo", lstProductToID[intDataCount]);
                if (lstCmpValTypID[intDataCount].ToString() == "AMT")
                {
                    htParam.Add("@CompAmt", lstCmpVal[intDataCount]);
                    htParam.Add("@CompRate", "0.00");
                }
                else
                {
                    htParam.Add("@CompAmt", "0.00");
                    htParam.Add("@CompRate", lstCmpVal[intDataCount]);
                }
                htParam.Add("@PerfCode", lstPerfCode[intDataCount]);
                htParam.Add("@PerfDesc", lstPrefDesc[intDataCount]);
                htParam.Add("@EffDt", "");
                htParam.Add("@status", lstProdAct[intDataCount]);
                htParam.Add("@CreatedBy", Session["UserID"].ToString());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpRuleProdDtls", htParam);

            }
            #endregion

            //txtCmpRuleNo.Enabled = false;
            //txtCmpCode.Enabled = false;
            txtCmpName.Enabled = false;
            ddlBizSrc.Enabled = false;
            ddlChnCls.Enabled = false;
            ddlMemType.Enabled = false;
            txtEffDate.Enabled = false;
            Image1.Visible = false;
            btnAdd.Enabled = false;
            gvCrsAppTo.Enabled = false;
            btnSetRule.Enabled = false;
            gvCheckRule.Enabled = false;
            gvCmpRuleSetup.Enabled = false;
            ddlProduct.Enabled = false;
            txtProdFrm.Enabled = false;
            txtProdTo.Enabled = false;
            rdbCmpVal.Enabled = false;
            txtCmpVal.Enabled = false;
            btnProAdd.Enabled = false;
            btnSetProduct.Enabled = false;
            lbl3.Text = "Computation Setup Done Sucessfully" + "</br></br> Computation Type : " + txtCmpTyp.Text + "</br></br> Computation Description : " + txtCmpDesc.Text;
            mdlpopup.Show();
            lblMessage.Text = "Computation Setup Done Sucessfully";
            lblMessage.Visible = true;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "btnSetProduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region lnkActInAct_Click
    protected void lnkActInAct_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkActInAct = (LinkButton)grd.FindControl("lnkActInAct");
            HiddenField hdnActInAct = (HiddenField)grd.FindControl("hdnActInAct");
            if (lnkActInAct.Text.Trim() == "Active")
            {
                lnkActInAct.Text = "InActive";
                hdnActInAct.Value = "1";
            }
            else
            {
                lnkActInAct.Text = "Active";
                hdnActInAct.Value = "0";
            }
            DataTable dt = (DataTable)ViewState["DtAppTo"];

            dt.Rows[grd.RowIndex]["FlagID"] = hdnActInAct.Value;
            dt.Rows[grd.RowIndex]["Flag"] = lnkActInAct.Text;
            dt.AcceptChanges();

            ViewState["DtAppTo"] = dt;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "lnkActInAct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region lnkProdActInAct_Click
    protected void lnkProdActInAct_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkActInAct = (LinkButton)grd.FindControl("lnkProdActInAct");
            HiddenField hdnActInAct = (HiddenField)grd.FindControl("hdnProdActInAct");
            if (lnkActInAct.Text.Trim() == "Active")
            {
                lnkActInAct.Text = "InActive";
                hdnActInAct.Value = "1";
            }
            else
            {
                lnkActInAct.Text = "Active";
                hdnActInAct.Value = "0";
            }
            DataTable dt = (DataTable)ViewState["DtProd"];

            dt.Rows[grd.RowIndex]["FlagID"] = hdnActInAct.Value;
            dt.Rows[grd.RowIndex]["Flag"] = lnkActInAct.Text;
            dt.AcceptChanges();

            ViewState["DtProd"] = dt;
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "lnkProdActInAct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void FillPerfIndCode()
    {
        try
        {
            ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@RuleNo", lblTmpRuleNoval.Text.ToString().Trim());
            htParam.Add("@CompCode", lblTmpCompCode.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetKPIs", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlPerIndCode.DataSource = ds;
                ddlPerIndCode.DataTextField = "KPICode";
                ddlPerIndCode.DataValueField = "KPIDesc1";
                ddlPerIndCode.DataBind();
            }
            ds.Clear();
            htParam.Clear();
            ddlPerIndCode.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetup", "FillPerfIndCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkAddKPI_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lblRuleNo = (Label)grd.FindControl("lblRuleNo");
        Label lblCompCode = (Label)grd.FindControl("lblCompCode");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUp('" + lblRuleNo.Text.ToString().Trim() + "','" + lblCompCode.Text.ToString().Trim() + "');", true);

    }

    protected void btnkpi_Click(object sender, EventArgs e)
    {
        if (Session["KPI"] != null)
        {
            dgKPI.DataSource = Session["KPI"];
            dgKPI.DataBind();

            #region set KPI
            List<string> lstRuleNoKPI = new List<string>();
            List<string> lstCmpCode = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstKPIDesc = new List<string>();
            List<string> lstKPIOrigin = new List<string>();
            List<string> lstRngFrm = new List<string>();
            List<string> lstRngTo = new List<string>();
            List<string> lstVer = new List<string>();

            for (int intRowCount = 0; intRowCount <= dgKPI.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRuleNo = (HiddenField)dgKPI.Rows[intRowCount].Cells[1].FindControl("hdnRuleNo");
                lstRuleNoKPI.Add(hdnRuleNo.Value.ToString().Trim());
                HiddenField hdnCompCode = (HiddenField)dgKPI.Rows[intRowCount].Cells[1].FindControl("hdnCompCode");
                lstCmpCode.Add(hdnCompCode.Value.ToString().Trim());
                HiddenField hdnKPICode = (HiddenField)dgKPI.Rows[intRowCount].Cells[1].FindControl("hdnKPICode");
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstKPICode.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@CmpRuleNo", lstRuleNoKPI[intDataCount]);
                htParam.Add("@CmpCode", lstCmpCode[intDataCount]);
                htParam.Add("@KPICode", lstKPICode[intDataCount]);
                htParam.Add("@CreatedBy", Session["UserID"].ToString());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpRulKPI", htParam);
            }
            #endregion
            dgKPI.DataSource = Session["KPI"];
            dgKPI.DataBind();
        }
    }
   
}
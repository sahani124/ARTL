using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_INSC_Recruit_MstTblDwnDesign : BaseClass
{
    #region "Declare Variable"
    private multilingualManager olng;
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    protected CommonFunc oCommon = new CommonFunc();
    private const string c_strBlank = "-- Select --";
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    ArrayList arrResult = new ArrayList();
    private clsCndReg clsCndReg = new clsCndReg();
    DataSet dsDB = new DataSet();
    string strFDocType = string.Empty;
    DataSet dsResult = new DataSet();
    string strDelete = string.Empty;
    string strValue = string.Empty;
    DataTable dtCurrentTable;
    string x = string.Empty;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            olng = new multilingualManager("DefaultConn", "MstTblDesign.aspx", Session["UserLangNum"].ToString());
            if (!IsPostBack)
            {
                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"].ToUpper().Trim() == "DWNLDVR")
                    {
                        tblHeader.Visible = false;
                        tblDocType.Visible = true;
                        tblMstDesign.Visible = false;
                        tbldgMstDocDesign.Visible = false;
                        tblDownload.Visible = false;
                        tblButton.Visible = false;
                        PopulateDocName();
                    }
                }
                else
                {
                    tblButton.Visible = false;
                    InitializeControl();
                    BindDowndata();
                    EnabledisableGrid1();
                    SetInitialRow();
                    PopulateDwnldFrmt();
                }
            }

            btnInsert.Attributes.Add("Onclick", "javascript: return funMandatory();");
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region PopulateDownloadFormat
    private void PopulateDwnldFrmt()
    {
        oCommon.getDropDown(ddlDwnldFrmt, "DwnldFrmt", 1, "", 1);
        ddlDwnldFrmt.Items.Insert(0, "--Select--");
    }
    #endregion

    #region InitializeControl -MASTER DESIGN
    private void InitializeControl()
    {
        try
        {
            lblDoctype.Text = olng.GetItemDesc("lblDoctype");
            lblDecDesc.Text = olng.GetItemDesc("lblDecDesc");
            lblshrtDocName.Text = olng.GetItemDesc("lblshrtDocName");
            lblColcnt.Text = olng.GetItemDesc("lblColcnt");
            lblMstDocDesign.Text = olng.GetItemDesc("lblMstDocDesign");
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region EnabledisableGrid1
    private void EnabledisableGrid1()
    {
        try
        {
            foreach (GridViewRow row in dgMstDesign.Rows)
            {
                TextBox txt1 = (TextBox)row.FindControl("txtColName");
                TextBox txt2 = (TextBox)row.FindControl("txtLength");

                DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
                DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");


                if (!IsPostBack)
                {
                    txt1.Enabled = false; txt2.Enabled = false;
                    ddl1.Enabled = false; ddl2.Enabled = false; btnIns.Enabled = false;
                    btnIns.Enabled = false; tbldgMstDocDesign.Visible = false;
                }
                else
                {
                    txt1.Enabled = true; txt2.Enabled = true;
                    ddl1.Enabled = true; ddl2.Enabled = true; btnIns.Enabled = true;

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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region SetInitialRow - To Fill Gridview data
    private void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("DocType", typeof(string)));
            dt.Columns.Add(new DataColumn("ColumnName", typeof(string)));
            dt.Columns.Add(new DataColumn("Datatype", typeof(string)));
            dt.Columns.Add(new DataColumn("Length", typeof(string)));
            dt.Columns.Add(new DataColumn("Isprimary", typeof(string)));
            dt.Columns.Add(new DataColumn("Createby", typeof(string)));
            dt.Columns.Add(new DataColumn("CreatedDTime", typeof(string)));
            dt.Columns.Add(new DataColumn("UpdateBy", typeof(string)));
            dt.Columns.Add(new DataColumn("UpdatedDTime", typeof(string)));
            dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }

    }
    #endregion

    #region BindDowndata
    private void BindDowndata()
    {
        try
        {
            dgMstDesign.DataBind();
            DataTable dsdgMstDesign = GetDataTAble();

            //To show only one row at page load
            ArrayList TempArray = new ArrayList();
            TempArray.Add(dsdgMstDesign);

            if (dsdgMstDesign != null)
            {
                if (dsdgMstDesign.Rows.Count > 0)
                {
                    dgMstDesign.DataSource = TempArray;
                    dgMstDesign.DataBind();
                }
                else
                {
                    dgMstDesign.DataSource = null;
                    dgMstDesign.DataBind();
                }
            }

            else
            {
                dgMstDesign.DataSource = null;
                dgMstDesign.DataBind();
            }
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region GetDataTAble
    protected DataTable GetDataTAble()
    {
        try
        {
            DataSet dsdesign = new DataSet();
            DataTable dtdesign = new DataTable();

            dsdesign = dataAccessRecruit.GetDataSetForPrcUpdDwnldwithoutParam("Prc_GetdataMstdesign");
            //Session["dsdesign"] = dsdesign;
            ViewState["dsdesign"] = dsdesign;

            if (dsdesign != null)
            {
                if (dsdesign.Tables.Count > 0)
                {
                    if (dsdesign.Tables[0].Rows.Count > 0)
                    {
                        dtdesign = dsdesign.Tables[0];

                    }
                    else
                    {
                        dtdesign = null;

                    }
                }
                else
                {
                    dtdesign = null;

                }
            }

            else
            {
                dtdesign = null;

            }

            return dtdesign;
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }

    }
    #endregion

    #region dgMstDocDesign_RowDataBound
    protected void dgMstDocDesign_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    #endregion

    #region dgMstDesign_RowDataBound
    protected void dgMstDesign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //if (!IsPostBack)
                //{
                    //Bind Isprimary dropdown
                    DropDownList ddlisprim = (DropDownList)e.Row.FindControl("ddlIsPrim");

                    //ddlisprim.DataSource = Session["dsdesign"];
                    ddlisprim.DataSource = ViewState["dsdesign"];
                    ddlisprim.DataTextField = "ParamDesc01";
                    ddlisprim.DataValueField = "ParamDesc02";
                    ddlisprim.DataBind();
                    ddlisprim.Items.Insert(0, "--Select--");
                    //Bind datatype dropdown
                    //DropDownList ddlDataType = (DropDownList)e.Row.FindControl("ddlDataType");
                    //oCommon.getDropDown(ddlDataType, "DataType", 1, "", 1);
                    //ddlDataType.Items.Insert(0, "--Select--");

                    DropDownList ddlDataType = (DropDownList)e.Row.FindControl("ddlDataType");
                    htParam.Clear();
                    dsResult.Clear();
                    htParam.Add("@Flag", "1");
                    dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDataType", htParam);
                    ddlDataType.DataSource = dsResult.Tables[0];
                    ddlDataType.DataTextField = "ParamDesc01";
                    ddlDataType.DataValueField = "ParamDesc01";
                    ddlDataType.DataBind();
                    ddlDataType.Items.Insert(0, "--Select--");
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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region Button Insert
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            EnabledisableGrid1();
            //tbl_grid.Attributes.Add("Style", "visibility:visible");
            if (txtColcnt.Text != "" && txtDocDesc.Text != "" && txtShrtDocName.Text != "" && ddlDwnldFrmt.SelectedItem.Value != "--Select--")
            {
                htParam.Clear();
                htParam.Add("@DocDesc", txtDocDesc.Text);
                htParam.Add("@DocType", txtShrtDocName.Text);
                htParam.Add("@ColumnCnt", txtColcnt.Text);
                htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                //htParam.Add("@UpdatedBy", Session["UserID"].ToString().Trim());
                htParam.Add("@DocName", txtDoctype.Text);
                htParam.Add("@DwnFrmt", ddlDwnldFrmt.SelectedItem.Text.Trim());
                hdnColcnt.Value = txtColcnt.Text.Trim();
                htParam.Add("@Output", "");
                //hdntxtDoctype.Value = txtShrtDocName.Text.Trim();
                dsDB = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Pri_MstDocTypeDwnld", htParam);
                if (dsDB.Tables.Count > 0)
                {
                    //txtDoctype.Text = dsDB.Tables[0].Rows[0]["docname"].ToString();
                    // hdntxtDoctype.Value = txtDoctype.Text;
                    lbl_popup.Text = "Please enter master download document details";
                    mdlpopup.Show();
                }
                else
                {
                }
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('All fields are mandatory.')", true);
                return;
            }
            //shreela
            btnInsert.Enabled = false;
            btnFinish.Enabled = false;
            //shreela
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region Button Add
    protected void btnIns_Click(object sender, EventArgs e)
    {
        try
        {
            tbldgMstDocDesign.Visible = true;
            //DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            foreach (GridViewRow row in dgMstDesign.Rows)
            {
                TextBox txt1 = (TextBox)row.FindControl("txtColName");

                DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
                DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
                TextBox txt2 = (TextBox)row.FindControl("txtLength");


                if (txt1.Text != "" && ddl1.SelectedItem.Text != "--Select--" && ddl2.SelectedItem.Text != "--Select--")
                {
                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"].ToUpper().Trim() == "DWNLDVR")
                        {
                            dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            dgMstDocDesign.DataSource = ViewState["CurrentTable"];

                            InsertNewData();
                            tblMstDesign.Visible = false;
                            btnFinish.Enabled = true;
                        }
                    }
                    else
                    {

                        dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        if (dtCurrentTable.Rows.Count < Convert.ToInt32(hdnColcnt.Value))
                        {
                            dgMstDocDesign.DataSource = ViewState["CurrentTable"];
                            AddNewRowToGrid();

                            //txt1.Text = ""; txt2.Text = "";
                            if (dtCurrentTable.Rows.Count == Convert.ToInt32(hdnColcnt.Value))
                            {
                                tblButton.Visible = true;
                                btnFinish.Enabled = true;
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No more columns can be added')", true);
                            txt1.Text = ""; txt2.Text = "";
                            btnIns.Enabled = false;
                            btnFinish.Enabled = true;
                            return;

                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select mandatory fields.')", true);
                    return;
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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region AddNewRowToGrid - To Add new row to Gridview
    private void AddNewRowToGrid()
    {
        try
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                DropDownList ddl1 = (DropDownList)dgMstDesign.Rows[0].Cells[1].FindControl("ddlIsPrim");
                DropDownList ddl2 = (DropDownList)dgMstDesign.Rows[0].Cells[2].FindControl("ddlDataType");
                TextBox txt1 = (TextBox)dgMstDesign.Rows[0].Cells[0].FindControl("txtColName");
                TextBox txt2 = (TextBox)dgMstDesign.Rows[0].Cells[0].FindControl("txtLength");

                string str = string.Empty;
                rowIndex = dtCurrentTable.Rows.Count;
                drCurrentRow = dtCurrentTable.NewRow();
                //drCurrentRow["DocType"] = hdntxtDoctype.Value;
                drCurrentRow["DocType"] = txtShrtDocName.Text;
                drCurrentRow["ColumnName"] = txt1.Text;
                drCurrentRow["Datatype"] = ddl2.SelectedItem.Text;
                drCurrentRow["Length"] = txt2.Text;
                //Checking ismandatory start
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    string strprimary = dtCurrentTable.Rows[i]["Isprimary"].ToString();
                    int count = 0;

                    count = count + Convert.ToInt32(strprimary);
                    if (count >= 1 && Convert.ToInt32(ddl1.SelectedItem.Value) == 1)
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only one primary field allowed')", true);
                        return;

                    }
                    else
                    {
                        drCurrentRow["Isprimary"] = ddl1.Text;
                    }
                }
                if (dtCurrentTable.Rows.Count == 0)
                {
                    drCurrentRow["Isprimary"] = ddl1.Text;
                }
                //Checking ismandatory end

                drCurrentRow["Createby"] = Session["UserId"].ToString();
                drCurrentRow["CreatedDTime"] = System.DateTime.Now;
                drCurrentRow["UpdateBy"] = "";
                drCurrentRow["UpdatedDTime"] = System.DBNull.Value;

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                dgMstDocDesign.DataSource = dtCurrentTable;
                dgMstDocDesign.DataBind();
                txt1.Text = ""; txt2.Text = "";
                ddl1.ClearSelection();
                ddl2.ClearSelection();
            }

            else
            {
                Response.Write("ViewState is null");
            }
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }

    }
    #endregion

    #region Button Finish
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            //MASTER VERSIONING
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"].ToUpper().Trim() == "DWNLDVR")
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["UpdDwnld"];
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        string strprimary = dtCurrentTable.Rows[i]["Isprimary"].ToString();
                        if (strprimary == "1")
                        {
                            count++;
                        }
                    }

                    if (count < 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Atleast one primary field mandatory')", true);
                        btnFinish.Enabled = true;
                        return;
                    }
                    else if (count > 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only one primary field should be set to Yes')", true);
                        btnFinish.Enabled = true;
                        return;
                    }
                    else
                    {
                        htParam.Clear();
                        dsResult.Clear();
                        htParam.Add("@UserId", Session["UserID"].ToString().Trim());
                        htParam.Add("@Doctype", ddlName.SelectedValue.ToString().Trim());
                        htParam.Add("@Flag", "2");
                        int y = dataAccessRecruit.execute_sprcUpdDwnld("Prc_MoveMstData", htParam);

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                        {
                            bulkCopy.DestinationTableName = "MstDocTypeDtlsDwnld";
                            try
                            {
                                bulkCopy.WriteToServer(dtCurrentTable);
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        int icwnt = dtCurrentTable.Rows.Count;

                        htParam.Clear();
                        htParam.Add("@DocType", ddlName.SelectedItem.Value.ToString().Trim());
                        htParam.Add("@NewAdd", "Add");
                        htParam.Add("@Colname", dtCurrentTable.Rows[0]["ColumnName"].ToString());
                        htParam.Add("@Datatype", dtCurrentTable.Rows[0]["Datatype"].ToString().Trim());
                        htParam.Add("@Length", dtCurrentTable.Rows[0]["Length"].ToString().Trim());
                        htParam.Add("@Flag", "1");
                        //int x = dataAccessRecruit.execute_sprcUpdDwnld("Prc_CreateTempTable", htParam);
                        x = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_CreateTempTable", htParam, "@validateFlag");

                        if (x == "1")
                        {
                            txtColcnt.Text = "";
                            txtDocDesc.Text = "";
                            txtDoctype.Text = "";
                            txtShrtDocName.Text = "";

                            lbl_popup.Text = "History and temporary tables are created.";
                            btnFinish.Enabled = false;
                            btnAdd.Enabled = false;
                            mdlpopup.Show();
                        }
                        else
                        {
                            lbl_popup.Text = "History and temporary tables are not created, Please try again.";
                            mdlpopup.Show();
                        }
                    }
                }
            }
            else
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                {
                    string strprimary = dtCurrentTable.Rows[i]["Isprimary"].ToString();
                    if (strprimary == "1")
                    {
                        break;
                    }
                    else
                    {
                        count++;

                    }
                }

                if (count == dtCurrentTable.Rows.Count)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Atleast one primary field mandatory')", true);
                    return;
                }
                else
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                    {
                        bulkCopy.DestinationTableName = "MstDocTypeDtlsDwnld";
                        try
                        {
                            bulkCopy.WriteToServer(dtCurrentTable);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    int icwnt = dtCurrentTable.Rows.Count;

                    //strFDocType = hdntxtDoctype.Value;
                    htParam.Clear();
                    //htParam.Add("@DocType", strFDocType);
                    htParam.Add("@DocType", txtShrtDocName.Text);
                    htParam.Add("@NewAdd", "Old");
                    htParam.Add("@Colname", dtCurrentTable.Rows[0]["ColumnName"].ToString());
                    htParam.Add("@Datatype", dtCurrentTable.Rows[0]["Datatype"].ToString().Trim());
                    htParam.Add("@Length", dtCurrentTable.Rows[0]["Length"].ToString().Trim());
                    htParam.Add("@Flag", "1");
                    //int x = dataAccessRecruit.execute_sprcUpdDwnld("Prc_CreateTempTable", htParam);
                    x = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_CreateTempTable", htParam, "@validateFlag");

                    if (x == "1")
                    {
                        txtColcnt.Text = "";
                        txtDocDesc.Text = "";
                        txtDoctype.Text = "";
                        txtShrtDocName.Text = "";

                        lbl_popup.Text = "History and temporary tables are created.";
                        mdlpopup.Show();
                    }
                    else
                    {
                        lbl_popup.Text = "History and temporary tables are not created, Please try again.";
                        mdlpopup.Show();
                    }
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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region button Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ACT"] != null)
        {
            if (Request.QueryString["ACT"].ToUpper().Trim() == "DWNLDVR")
            {
                Response.Redirect("MstTblDwnDesign.aspx?ACT=DWNLDVR");
            }
        }
        else
        {
            Response.Redirect("MstTblDwnDesign.aspx");
        }
    }
    #endregion

    #region dgMstDocDesign_RowCommand
    protected void dgMstDocDesign_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string EmpID;
                EmpID = row.RowIndex.ToString();
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    dt1 = ViewState["CurrentTable"] as DataTable;
                    for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                    {
                        DataRow dr;
                        if (i.ToString() == EmpID)
                        {
                            dr = dt1.Rows[i];
                            dt1.Rows[i].Delete();
                            //dt1.Rows.Remove(dr);
                        }
                    }
                    ViewState.Remove("CurrentTable");
                    ViewState["CurrentTable"] = dt1;

                    dgMstDocDesign.DataSource = ViewState["CurrentTable"];
                    dgMstDocDesign.DataBind();
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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region dgMstDocDesign_RowDeleting
    protected void dgMstDocDesign_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region dgMstDocDesign_PageIndexChanging
    protected void dgMstDocDesign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"]; ;
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;

            dgSource.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.DataSource = dv;
            dgSource.DataBind();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    //kk

    #region Fill Document name dropdown
    private void PopulateDocName()
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Action", "Dwnld");
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDocumentName", htParam);
            ddlName.DataSource = dsResult;
            ddlName.DataValueField = "Doctype";
            ddlName.DataTextField = "DocDesc";
            ddlName.DataBind();
            ddlName.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region button View Format
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlName.SelectedValue.ToString().Trim() == "--Select--")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select Document Name.')</script>");
                strValue = "1";
            }
            else
            {
                strValue = "0";
            }
            if (strValue != "1")
            {
                FillGrid();
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region ddlName_SelectIndexChanged
    protected void ddlName_SelectIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tblMstDesign.Visible = false;
            tblDownload.Visible = false;
            tblButton.Visible = false;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region DOWNLOAD_PAGEINFORMATION
    private void ShowDwnldPageInformation()
    {
        int intPageIndex = dgDownload.PageIndex + 1;
        lblDPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDownload.PageCount;
    }
    #endregion

    #region dgDownload_RowCommand
    protected void dgDownload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            int deleteRowId = row.RowIndex;
            Label lblDColumnName = (Label)row.FindControl("lblDColumnName");
            string strValue = ddlName.SelectedItem.Value.ToString();

            DataTable dtDeleteRecord = (DataTable)ViewState["UpdDwnld"];
            ViewState["UpdDwnld"] = null;
            dtDeleteRecord.Rows.RemoveAt(deleteRowId);

            //htParam.Clear();
            //htParam.Add("@Flag", "2");
            //htParam.Add("@DocType", ddlName.SelectedItem.Value.ToString());
            //htParam.Add("@ColName", lblDColumnName.Text);
            //strDelete = dataAccessRecruit.execute_sprc_UpdDwnld_with_output_connKey("Prc_DelUpldDwnld", htParam, "@Value", "UpdDwnldConnectionString");

            lbl_popup.Text = "Selected record has been deleted successfully";
            mdlpopup.Show();

            ViewState["UpdDwnld"] = dtDeleteRecord;
            dgDownload.DataSource = dtDeleteRecord;
            dgDownload.DataBind();
        }
        if (e.CommandName == "Edit")
        {
            hdnGridRowId.Value = "";
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

            int row1id = row1.RowIndex;
            hdnGridRowId.Value = row1id.ToString();

            Label lblDColumnName = (Label)row1.FindControl("lblDColumnName");
            //Session["DColumnName"] = lblDColumnName.Text;
            hdnColumnName.Value = lblDColumnName.Text;
            Label lblDIsPrimary = (Label)row1.FindControl("lblDIsPrimary");
            //Session["DIsPrimary"] = lblDIsPrimary.Text;
            hdnIsPrimary.Value = lblDIsPrimary.Text;
            Label lblDDataType = (Label)row1.FindControl("lblDDataType");
            //Session["DDataType"] = lblDDataType.Text;
            hdnDataType.Value = lblDDataType.Text;
            Label lblDLength = (Label)row1.FindControl("lblDLength");
            //Session["DLength"] = lblDLength.Text;
            hdnLength.Value = lblDLength.Text;

        }
    }
    #endregion

    #region dgDownload_RowDataBound
    protected void dgDownload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("DEdeleteBtn");
            l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record?')");
        }
    }
    #endregion

    #region dgDownload_RowDeleting
    protected void dgDownload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region dgDownload_RowEditing
    protected void dgDownload_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgDownload.EditIndex = e.NewEditIndex;
        //illGrid();
        tblMstDesign.Visible = true;
        BindDowndata();
        foreach (GridViewRow row in dgMstDesign.Rows)
        {
            TextBox txt1 = (TextBox)row.FindControl("txtColName");
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
            TextBox txt2 = (TextBox)row.FindControl("txtLength");

            //txt1.Text = Session["DColumnName"].ToString();
            txt1.Text = hdnColumnName.Value;
            //ddl1.SelectedValue = Session["DIsPrimary"].ToString();
            ddl1.SelectedValue = hdnIsPrimary.Value;
            //ddl2.SelectedValue = Session["DDataType"].ToString();
            ddl2.SelectedValue = hdnDataType.Value;
            //txt2.Text = Session["DLength"].ToString();
            txt2.Text = hdnLength.Value;
        }
    }
    #endregion

    #region FillGrid
    private void FillGrid()
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@Action", "Dwnld");
        htParam.Add("@Doctype", ddlName.SelectedValue.ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetFormat", htParam);

        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ViewState["UpdDwnld"] = "";
                ViewState["UpdDwnld"] = dsResult.Tables[0];

                tblMstDesign.Visible = false;
                tblDocType.Visible = true;
                tbldgMstDocDesign.Visible = false;
                tblDownload.Visible = true;
                dgDownload.Visible = true;

                dgDownload.DataSource = ViewState["UpdDwnld"];
                dgDownload.DataBind();
            }
            else
            {
                tblHeader.Visible = false;
                tblDocType.Visible = true;
                tbldgMstDocDesign.Visible = false;
                tblDownload.Visible = false;
            }
        }
        else
        {
            tblHeader.Visible = false;
            tblDocType.Visible = true;
            tbldgMstDocDesign.Visible = false;
            tblDownload.Visible = false;
        }
    }
    #endregion

    #region btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblMstDesign.Visible = true;
        dgMstDesign.Visible = true;
        BindDowndata();
        EnabledisableGrid1();
        SetInitialRow();
    }
    #endregion

    #region clear button
    protected void btnClr_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in dgMstDesign.Rows)
        {
            TextBox txt1 = (TextBox)row.FindControl("txtColName");
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
            TextBox txt2 = (TextBox)row.FindControl("txtLength");

            txt1.Text = "";
            ddl1.ClearSelection();
            ddl2.ClearSelection();
            txt2.Text = "";
        }
    }
    #endregion

    #region InsertNewData
    private void InsertNewData()
    {
        try
        {
            tbldgMstDocDesign.Visible = false;
            tblButton.Visible = true;
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DropDownList ddl1 = (DropDownList)dgMstDesign.Rows[0].Cells[1].FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)dgMstDesign.Rows[0].Cells[2].FindControl("ddlDataType");

            TextBox txt1 = (TextBox)dgMstDesign.Rows[0].Cells[0].FindControl("txtColName");
            TextBox txt2 = (TextBox)dgMstDesign.Rows[0].Cells[3].FindControl("txtLength");

            DataTable dtUpldDwnld = (DataTable)ViewState["UpdDwnld"];
            ViewState["UpdDwnld"] = null;

            DataRow dr = dtUpldDwnld.NewRow();
            dr["Doctype"] = ddlName.SelectedItem.Value.ToString().Trim();
            dr["ColumnName"] = txt1.Text;
            dr["IsPrimary"] = ddl1.Text;
            dr["DataType"] = ddl2.SelectedItem.Text;
            dr["Length"] = txt2.Text;

            if (hdnGridRowId.Value != "")
            {
                dtUpldDwnld.Rows.RemoveAt(Convert.ToInt16(hdnGridRowId.Value));
                dtUpldDwnld.Rows.InsertAt(dr, Convert.ToInt16(hdnGridRowId.Value));
                hdnGridRowId.Value = "";
            }
            else
            {
                dtUpldDwnld.Rows.Add(dr);
            }

            ViewState["UpdDwnld"] = dtUpldDwnld;
            dgDownload.DataSource = dtUpldDwnld;
            dgDownload.DataBind();

            txt1.Text = ""; txt2.Text = "";
            ddl1.ClearSelection();
            ddl2.ClearSelection();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    //kk
}
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


public partial class Application_INSC_Recruit_MstTblDesign : BaseClass
{
    #region "Declare Variable"
    private multilingualManager olng;
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    protected CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    ArrayList arrResult = new ArrayList();
    private clsCndReg clsCndReg = new clsCndReg();
    DataSet dsDB = new DataSet();
    DataSet dsResult = new DataSet();
    private const string c_strBlank = "-- Select --";
    const int alphabetsCount = 26;
    string strFDocType = string.Empty;
    string strDelete = string.Empty;
    DataTable dtCurrentTable;
    string str = string.Empty;
    string strValue = string.Empty;
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
                //MASTER VERSIONING
                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"].ToUpper().Trim() == "UPDVR")
                    {
                        //KK1
                        tblDocType.Visible = true;
                        PopulateDocName();
                        tblMstDesign.Visible = false;
                        tbl_grid.Visible = false;
                        divSearchDetails.Visible = false;
                        tbldgMstDocDesign.Visible = false;
                        tblUpload.Visible = false;
                        tblButton.Visible = false;
                        //KK2
                    }
                }
                //MASTER UPLOAD DESIGN
                else
                {
                    InitializeControl();
                    BindGrid();
                    //BindGridDtls();
                    //divdgMstDesign.Disabled = true;
                    tblEditDesign.Visible = true;
                    tblButton.Visible = false;
                    EnabledisableGrid1();
                    SetInitialRow();
                    PopulateFileSize();
                    // ShowNotes();
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

    #region InitializeControl
    private void InitializeControl()
    {
        try
        {
            lblUDoctype.Text = olng.GetItemDesc("lblUDoctype");
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
        foreach (GridViewRow row in dgMstDesign.Rows)
        {
            TextBox txt1 = (TextBox)row.FindControl("txtColName");
            TextBox txt2 = (TextBox)row.FindControl("txtLength");
            TextBox txt3 = (TextBox)row.FindControl("txtPermisibleValues");
            //TextBox txt4 = (TextBox)row.FindControl("txtwhere");
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
            DropDownList ddl3 = (DropDownList)row.FindControl("ddlIsMandatory");
            DropDownList ddl4 = (DropDownList)row.FindControl("ddlVerifReq");
            DropDownList ddl5 = (DropDownList)row.FindControl("ddlDB");
            DropDownList ddl6 = (DropDownList)row.FindControl("ddltbl");
            DropDownList ddl7 = (DropDownList)row.FindControl("ddlCol");

            if (!IsPostBack)
            {
                txt1.Enabled = false; txt2.Enabled = false; txt3.Enabled = false; //txt4.Enabled = false;
                ddl1.Enabled = false; ddl2.Enabled = false; ddl3.Enabled = false; ddl4.Enabled = false;
                ddl5.Enabled = false; ddl6.Enabled = false; ddl7.Enabled = false; btnIns.Enabled = false; tbldgMstDocDesign.Visible = false;
            }
            else
            {
                txt1.Enabled = true; txt2.Enabled = true; txt3.Enabled = false; //txt4.Enabled = false;
                ddl1.Enabled = true; ddl2.Enabled = true; ddl3.Enabled = true; btnIns.Enabled = true; ddl4.Enabled = true;
                ddl5.Enabled = false; ddl6.Enabled = false; ddl7.Enabled = false;
            }

        }
    }
    protected void BindGrid()
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
                dgMstDesign.DataSource = TempArray;//To show only one row at page load dsdgMstDesign;
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

    #region dgMstDesign_RowDataBound
    protected void dgMstDesign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (!IsPostBack)
                //{
                DropDownList ddlisprim = (DropDownList)e.Row.FindControl("ddlIsPrim");

                //ddlisprim.DataSource = Session["dsdesign"];
                ddlisprim.DataSource = ViewState["dsdesign"];
                ddlisprim.DataTextField = "ParamDesc01";
                ddlisprim.DataValueField = "ParamDesc02";
                ddlisprim.DataBind();
                ddlisprim.Items.Insert(0, "---");

                DropDownList ddlIsMandatory = (DropDownList)e.Row.FindControl("ddlIsMandatory");
                //ddlIsMandatory.DataSource = Session["dsdesign"];
                ddlIsMandatory.DataSource = ViewState["dsdesign"];
                ddlIsMandatory.DataTextField = "ParamDesc01";
                ddlIsMandatory.DataValueField = "ParamDesc02";
                ddlIsMandatory.DataBind();
                ddlIsMandatory.Items.Insert(0, "---");

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
                //DropDownList ddlDataType = (DropDownList)e.Row.FindControl("ddlDataType");
                //oCommon.getDropDown(ddlDataType, "DataType", 1, "", 1);
                //ddlDataType.Items.Insert(0, "--Select--");

                DropDownList ddlVerifReq = (DropDownList)e.Row.FindControl("ddlVerifReq");
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@Flag", "2");
                dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDataType", htParam);
                ddlVerifReq.DataSource = dsResult.Tables[0];
                ddlVerifReq.DataTextField = "ParamDesc01";
                ddlVerifReq.DataValueField = "ParamDesc01";
                ddlVerifReq.DataBind();
                ddlVerifReq.Items.Insert(0, "---");
                //DropDownList ddlVerifReq = (DropDownList)e.Row.FindControl("ddlVerifReq");
                //oCommon.getDropDown(ddlVerifReq, "VerifReq", 1, "", 1);
                //ddlVerifReq.Items.Insert(0, "---");

                DropDownList ddlDB = (DropDownList)e.Row.FindControl("ddlDB");
                ddlDB.Items.Insert(0, "--Select--");

                DropDownList ddltbl = (DropDownList)e.Row.FindControl("ddltbl");
                ddltbl.Items.Insert(0, "--Select--");


                DropDownList ddlCol = (DropDownList)e.Row.FindControl("ddlCol");
                ddlCol.Items.Insert(0, "--Select--");
                TextBox txt3 = (TextBox)e.Row.FindControl("txtPermisibleValues");
                //TextBox txt4 = (TextBox)e.Row.FindControl("txtwhere");

                //disable DB, Table, Col, where and permissible values on page load
                //ddlddlDB.Enabled = false;
                ddlCol.Enabled = false;
                ddltbl.Enabled = false;
                txt3.Enabled = false;
                //txt4.Enabled = false;
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

    #region ddlVerifReq_SelectedIndexChanged
    protected void ddlVerifReq_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((DropDownList)sender).NamingContainer as GridViewRow;

            DropDownList ddlVerifReq = (DropDownList)row.FindControl("ddlVerifReq");
            string valueDB = ddlVerifReq.SelectedItem.Text.Trim();

            DropDownList ddlDB = (DropDownList)row.FindControl("ddlDB");
            DropDownList ddlTbl = (DropDownList)row.FindControl("ddlTbl");
            DropDownList ddlCol = (DropDownList)row.FindControl("ddlCol");

            TextBox txtPermisibleValues = (TextBox)row.FindControl("txtPermisibleValues");
            //TextBox txtwhere = (TextBox)row.FindControl("txtwhere");
            txtPermisibleValues.Enabled = false;
            if (valueDB == "1")
            {

                txtPermisibleValues.Enabled = true;

                ddlDB.ClearSelection();
                ddlTbl.ClearSelection();
                ddlCol.ClearSelection();
                ddlDB.Enabled = false;
                ddlDB.ClearSelection();
                ddlTbl.Enabled = false;
                ddlTbl.ClearSelection();
                ddlCol.Enabled = false;
                ddlCol.ClearSelection();
                //txtwhere.Enabled = false;

                //ddlDB.SelectedItem.Text = "--Select--"; ddlTbl.SelectedItem.Text = "--Select--"; ddlCol.SelectedItem.Text = "--Select--";

            }
            else if (valueDB == "2")
            {
                txtPermisibleValues.Enabled = false;
                txtPermisibleValues.Text = "";
                ddlDB.Enabled = true;
                ddlTbl.Enabled = false;
                ddlCol.Enabled = false;
                //txtwhere.Enabled = true;

                //ddlTbl.SelectedItem.Text = "--Select--"; ddlCol.SelectedItem.Text = "--Select--";

                Hashtable htDB = new Hashtable();
                htDB.Add("@Flag", "1");
                htDB.Add("@DB", System.DBNull.Value);
                htDB.Add("@Table", System.DBNull.Value);
                dsDB = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htDB);

                ddlDB.Items.Clear();
                ddlDB.DataSource = dsDB;
                ddlDB.DataTextField = "DatabaseName";
                ddlDB.DataValueField = "DatabaseName";
                ddlDB.DataBind();
                ddlDB.Items.Insert(0, "--Select--");
            }
            else
            {
                txtPermisibleValues.Text = "";
                txtPermisibleValues.Enabled = false;
                ddlDB.ClearSelection();
                ddlDB.Enabled = false;
                ddlTbl.ClearSelection();
                ddlTbl.Enabled = false;
                ddlCol.ClearSelection();
                ddlCol.Enabled = false;
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

    #region ddlDB_SelectedIndexChanged
    protected void ddlDB_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlDB = (DropDownList)row.FindControl("ddlDB");
            DropDownList ddltbl = (DropDownList)row.FindControl("ddltbl");
            DropDownList ddlCol = (DropDownList)row.FindControl("ddlCol");

            if (ddlDB.SelectedItem.Text != "--Select--")
            {
                string value = ddlDB.SelectedItem.Text.Trim();

                DataSet dsTable = new DataSet();
                Hashtable htDB = new Hashtable();
                htDB.Add("@Flag", "2");
                htDB.Add("@DB", value);
                htDB.Add("@Table", System.DBNull.Value);
                //GetDataSetForPrcRecruitUpdDwnld
                dsTable = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htDB);
                DropDownList ddltbl1 = (DropDownList)row.FindControl("ddltbl");
                ddltbl1.DataSource = dsTable;

                ddltbl1.DataTextField = "tablename";
                ddltbl1.DataValueField = "tablename";

                ddltbl1.DataBind();
                ddltbl.Enabled = true;
                ddlCol.Enabled = false;
                ddltbl.Items.Insert(0, "--Select--");
                ddlCol.Items.Insert(0, "--Select--");
            }
            else
            {
                ddltbl.SelectedItem.Text = "--Select--";
                ddlCol.SelectedItem.Text = "--Select--";
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

    #region ddltbl_SelectedIndexChanged
    protected void ddltbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlDB = (DropDownList)row.FindControl("ddlDB");
            string valueDB = ddlDB.SelectedItem.Text.Trim();
            DropDownList ddltbl = (DropDownList)row.FindControl("ddltbl");
            string value = ddltbl.SelectedItem.Text.Trim();
            DropDownList ddlCol = (DropDownList)row.FindControl("ddlCol");


            DataSet dsTable = new DataSet();
            Hashtable htDB = new Hashtable();
            htDB.Add("@Flag", "3");
            htDB.Add("@DB", valueDB);
            htDB.Add("@Table", value);
            dsTable = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htDB);

            ddlCol.DataSource = dsTable;

            ddlCol.DataTextField = "COLUMN_NAME";
            ddlCol.DataValueField = "COLUMN_NAME";

            ddlCol.DataBind();
            ddlCol.Items.Insert(0, "--Select--");
            ddlCol.Enabled = true;
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

    #region btnIns_Click
    protected void btnIns_Click(object sender, EventArgs e)
    {
        try
        {
            
            btnConfirm.Enabled = false;
            btnFinish.Enabled = false;

            foreach (GridViewRow row in dgMstDesign.Rows)
            {
                TextBox txt1 = (TextBox)row.FindControl("txtColName");
                TextBox txt2 = (TextBox)row.FindControl("txtLength");
                DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
                DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
                DropDownList ddl3 = (DropDownList)row.FindControl("ddlIsMandatory");
                TextBox txt3 = (TextBox)row.FindControl("txtPermisibleValues");
                DropDownList ddl4 = (DropDownList)row.FindControl("ddlVerifReq");
                DropDownList ddl5 = (DropDownList)row.FindControl("ddlDB");
                DropDownList ddl6 = (DropDownList)row.FindControl("ddltbl");
                DropDownList ddl7 = (DropDownList)row.FindControl("ddlCol");

                //MASTER VERSIONING
                if (txt1.Text != "" && txt2.Text != "" && ddl1.SelectedItem.Text != "---" && ddl2.SelectedItem.Text != "--Select--" && ddl3.SelectedItem.Text != "---" && ddl4.SelectedItem.Text != "---")
                {
                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"].ToUpper().Trim() == "UPDVR")
                        {
                            dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            dgMstDocDesign.DataSource = ViewState["CurrentTable"];

                            InsertNewData();
                            btnConfirm.Enabled = true;
                            //tblEditDesign.Visible = false;
                        }
                    }
                    //MASTER UPLOAD DESIGN
                    else
                    {
                        tbldgMstDocDesign.Visible = true;
                        dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        if (dtCurrentTable.Rows.Count < Convert.ToInt32(hdnColcnt.Value))
                        {
                            dgMstDocDesign.DataSource = ViewState["CurrentTable"];

                            AddNewRowToGrid();
                            tblButton.Visible = true;
                            btnConfirm.Enabled = true;
                            btnFinish.Enabled = false;
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no more columns added')", true);
                            txt1.Text = ""; txt2.Text = ""; txt3.Text = ""; //txt4.Text = "";
                            btnIns.Enabled = false;
                            btnConfirm.Enabled = true;
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

    #region SetInitialRow - To Fill Gridview data
    private void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("DocType", typeof(string)));
            dt.Columns.Add(new DataColumn("ColumnName", typeof(string)));
            dt.Columns.Add(new DataColumn("Isprimary", typeof(string)));
            dt.Columns.Add(new DataColumn("Datatype", typeof(string)));
            dt.Columns.Add(new DataColumn("Length", typeof(string)));
            dt.Columns.Add(new DataColumn("XLHDR", typeof(string)));
            dt.Columns.Add(new DataColumn("Mandatory", typeof(string)));
            dt.Columns.Add(new DataColumn("VrifReq", typeof(string)));
            dt.Columns.Add(new DataColumn("PermissibleValues", typeof(string)));
            dt.Columns.Add(new DataColumn("VrifDb", typeof(string)));
            dt.Columns.Add(new DataColumn("VerifTbl", typeof(string)));
            dt.Columns.Add(new DataColumn("VerifTblColumn", typeof(string)));
            dt.Columns.Add(new DataColumn("VerifWhereCond", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
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

    #region AddNewRowToGrid - To Add new row to Gridview
    private void AddNewRowToGrid()
    {
        try
        {
            int rowIndex = 0;

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            
            DropDownList ddl1 = (DropDownList)dgMstDesign.Rows[0].Cells[1].FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)dgMstDesign.Rows[0].Cells[2].FindControl("ddlDataType");
            DropDownList ddl3 = (DropDownList)dgMstDesign.Rows[0].Cells[4].FindControl("ddlIsMandatory");
            DropDownList ddl4 = (DropDownList)dgMstDesign.Rows[0].Cells[6].FindControl("ddlVerifReq");
            DropDownList ddl5 = (DropDownList)dgMstDesign.Rows[0].Cells[7].FindControl("ddlDB");
            DropDownList ddl6 = (DropDownList)dgMstDesign.Rows[0].Cells[8].FindControl("ddlTbl");
            DropDownList ddl7 = (DropDownList)dgMstDesign.Rows[0].Cells[9].FindControl("ddlCol");

            TextBox txt1 = (TextBox)dgMstDesign.Rows[0].Cells[0].FindControl("txtColName");
            TextBox txt2 = (TextBox)dgMstDesign.Rows[0].Cells[3].FindControl("txtLength");
            TextBox txt3 = (TextBox)dgMstDesign.Rows[0].Cells[5].FindControl("txtPermisibleValues");
            //TextBox txt4 = (TextBox)dgMstDesign.Rows[0].Cells[10].FindControl("txtwhere");


            rowIndex = dtCurrentTable.Rows.Count;
            drCurrentRow = dtCurrentTable.NewRow();
            //drCurrentRow["DocType"] = hdntxtDoctype.Value;
            //drCurrentRow["DocType"] = txtDoctype.Text;
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

            //Verifreq check
            if (ddl4.SelectedItem.Value.ToString().Trim() == "1")
            {
                if (txt3.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter permissible value.')", true);
                    return;
                }
            }
            else if (ddl4.SelectedItem.Value.ToString().Trim() == "2")
            {
                if ((ddl5.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select database value.')", true);
                    return;
                }
                else if ((ddl6.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select table value.')", true);
                    return;
                }
                else if ((ddl7.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select column value.')", true);
                    return;
                }
            }
           
            if (dtCurrentTable.Rows.Count == 0)
            {
                drCurrentRow["Isprimary"] = ddl1.Text;
            }
            //Checking ismandatory end

            drCurrentRow["Mandatory"] = ddl3.Text;
            if (txt3.Text != "")
            {
                drCurrentRow["PermissibleValues"] = txt3.Text;
            }
            else
            {
                drCurrentRow["PermissibleValues"] = System.DBNull.Value;
            }
            if (ddl4.Text != "--Select--")
            {
                drCurrentRow["VrifReq"] = ddl4.SelectedItem.Text;
            }
            else
            {
                drCurrentRow["VrifReq"] = System.DBNull.Value;
            }
            if (ddl5.Text != "--Select--")
            {
                drCurrentRow["VrifDb"] = ddl5.SelectedItem.Text;
            }
            else
            {
                drCurrentRow["VrifDb"] = "";
            }
            if (ddl6.Text != "--Select--")
            {
                drCurrentRow["VerifTbl"] = ddl6.SelectedItem.Text;
            }
            else
            {
                drCurrentRow["VerifTbl"] = System.DBNull.Value;
            }
            if (ddl7.Text != "--Select--")
            {
                drCurrentRow["VerifTblColumn"] = ddl7.SelectedItem.Text;
            }
            else
            {
                drCurrentRow["VerifTblColumn"] = System.DBNull.Value;
            }
            //if (txt4.Text != "")
            //{
            //    drCurrentRow["VerifWhereCond"] = txt4.Text;
            //}
            //else
            //{
            //    drCurrentRow["VerifWhereCond"] = System.DBNull.Value;
            //}
            drCurrentRow["Status"] = "1";
            drCurrentRow["Createby"] = Session["UserId"].ToString();
            drCurrentRow["CreatedDTime"] = System.DateTime.Now;
            drCurrentRow["UpdateBy"] = "";
            drCurrentRow["UpdatedDTime"] = System.DBNull.Value;

            dtCurrentTable.Rows.Add(drCurrentRow);
            ViewState["CurrentTable"] = dtCurrentTable;

            dgMstDocDesign.DataSource = dtCurrentTable;
            dgMstDocDesign.DataBind();
            txt1.Text = ""; txt2.Text = ""; txt3.Text = ""; //txt4.Text = "";
            ddl1.ClearSelection();
            ddl2.ClearSelection();
            ddl3.ClearSelection();
            ddl4.ClearSelection();
            ddl5.ClearSelection();
            ddl6.ClearSelection();
            ddl7.ClearSelection();

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

    #region  dgMstDocDesign_RowDataBound
    protected void dgMstDocDesign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                l.Attributes.Add("onclick", "javascript:return confirm('Are You Sure You Want To Delete This Record?')");
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

    #region  dgMstDocDesign_RowCommand
    protected void dgMstDocDesign_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string EmpID;
                EmpID = row.DataItemIndex.ToString();
                //row.RowIndex.ToString();
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
            DataTable dt = (DataTable)ViewState["CurrentTable"];
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

    #region Add excel header
    static string GetColumnName(int index)
    {
        string columnString = "";
        decimal columnNumber = index;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        return columnString;
    }
    #endregion

    #region btnInsert_Click
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            //System.Threading.Thread.Sleep(2000);
            EnabledisableGrid1();
            tblnotes.Visible = true;
            tbl_grid.Visible = true;
            //tbl_grid.Attributes.Add("Style", "visibility:visible");tr_grid
            tr_grid.Attributes.Add("Style", "visibility:visible");
            if (txtColcnt.Text != "" && txtDocDesc.Text != "" && txtShrtDocName.Text != "" && ddlFileSize.SelectedItem.Value != "--Select--")
            {
                htParam.Clear();
                htParam.Add("@DocDesc", txtDocDesc.Text);
                htParam.Add("@DocType", txtShrtDocName.Text);
                htParam.Add("@ColumnCnt", txtColcnt.Text);
                htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                //htParam.Add("@UpdatedBy", Session["UserID"].ToString().Trim());
                //htParam.Add("@DocName", "");
                htParam.Add("@DocName", txtDoctype.Text);
                htParam.Add("@Output", "");
                htParam.Add("@FileSize", ddlFileSize.SelectedItem.Value.ToString().Trim());
                hdnColcnt.Value = txtColcnt.Text.Trim();
                //dsDB = dataAccessRecruit.GetDataSetForPrcRecruit("Pri_InsertMstDocTypeUpld", htParam);
                dsDB = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Pri_InsertMstDocTypeUpld", htParam);

                if (dsDB.Tables.Count > 0)
                {
                    //txtDoctype.Text = dsDB.Tables[0].Rows[0]["Output"].ToString();
                    //hdntxtDoctype.Value = txtShrtDocName.Text;


                    lbl_popup.Text = "Please enter master document details";
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

    #region btnConfirm_Click
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            btnFinish.Enabled = true;
            btnAdd.Visible = false;

            //MASTER VERSIONING
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"].ToUpper().Trim() == "UPDVR")
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
                        btnFinish.Enabled = false;
                        btnAdd.Visible = true;
                        return;
                    }
                    else if (count > 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only one primary field should be set to Yes')", true);
                        btnFinish.Enabled = false;
                        btnAdd.Visible = true;
                        return;
                    }
                    else
                    {
                        htParam.Clear();
                        htParam.Add("@UserId", Session["UserID"].ToString().Trim());
                        htParam.Add("@Doctype", ddlName.SelectedValue.ToString().Trim());
                        htParam.Add("@Flag", "1");
                        int y = dataAccessRecruit.execute_sprcUpdDwnld("Prc_MoveMstData", htParam);

                        for (int j = 0; j < dtCurrentTable.Rows.Count; j++)
                        {
                           string strHeader = GetColumnName(j + 1);
                           dtCurrentTable.Rows[j]["XLHdr"] = strHeader;
                        }

                        ViewState["CurrentTable"] = dtCurrentTable;

                        lbl_popup.Text = "Master document details are ready, please proceed with FINISH";
                        mdlpopup.Show();
                        btnConfirm.Enabled = false;
                        btnAdd.Visible = false;
                    }
                }
            }
            //MASTER UPLOAD DESIGN
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
                    btnFinish.Enabled = false;
                    return;
                }
                else
                {
                    if (dtCurrentTable.Rows.Count == Convert.ToInt32(hdnColcnt.Value))
                    {
                        for (int j = 0; j < Convert.ToInt32(hdnColcnt.Value); j++)
                        {
                            string strHeader = GetColumnName(j + 1);
                            dtCurrentTable.Rows[j]["XLHdr"] = strHeader;
                        }

                        ViewState["CurrentTable"] = dtCurrentTable;

                        lbl_popup.Text = "Master document details are ready, please proceed with FINISH";
                        mdlpopup.Show();
                        btnConfirm.Enabled = false;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Add more columns')", true);
                        btnConfirm.Enabled = false;
                        return;
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

    #region button Finish
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        try
        {
            //MASTER VERSIONING
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"].ToUpper().Trim() == "UPDVR")
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["UpdDwnld"];

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                    {
                        bulkCopy.DestinationTableName = "MstDocTypeDtlsUpld";
                        try
                        {
                            bulkCopy.WriteToServer(dtCurrentTable);

                            int icwnt = dtCurrentTable.Rows.Count;

                            htParam.Clear();
                            htParam.Add("@DocType", ddlName.SelectedItem.Value.ToString().Trim());
                            htParam.Add("@NewAdd", "Add");
                            htParam.Add("@Colname", dtCurrentTable.Rows[0]["ColumnName"].ToString());
                            htParam.Add("@Datatype", dtCurrentTable.Rows[0]["Datatype"].ToString().Trim());
                            htParam.Add("@Length", dtCurrentTable.Rows[0]["Length"].ToString().Trim());
                            htParam.Add("@Flag", "2");
                            //string x = dataAccessRecruit.execute_sprc_UpdDwnld_with_output_connKey("Prc_CreateTempTable", htParam, "@ReturnError", "UpdDwnldConnectionString");
                            x = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_CreateTempTable", htParam, "@validateFlag");
                            if (x == "1")
                            {
                                txtColcnt.Text = "";
                                txtDocDesc.Text = "";
                                txtDoctype.Text = "";
                                txtShrtDocName.Text = "";

                                lbl_popup.Text = "History and temporary tables are created.";
                                btnFinish.Enabled = false;
                                mdlpopup.Show();
                            }
                            else
                            {
                                lbl_popup.Text = "History and temporary tables are not created, Please try again.";
                                mdlpopup.Show();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    btnFinish.Enabled = false;

                }
            }
            //MASTER UPLOAD DESIGN
            else
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                {
                    bulkCopy.DestinationTableName = "MstDocTypeDtlsUpld";
                    try
                    {
                        bulkCopy.WriteToServer(dtCurrentTable);

                        int icwnt = dtCurrentTable.Rows.Count;

                        htParam.Clear();
                        //strFDocType = hdntxtDoctype.Value;
                        //htParam.Add("@DocType", strFDocType);
                        htParam.Add("@DocType", txtShrtDocName.Text);
                        htParam.Add("@NewAdd", "Old");
                        htParam.Add("@Colname", dtCurrentTable.Rows[0]["ColumnName"].ToString());
                        htParam.Add("@Datatype", dtCurrentTable.Rows[0]["Datatype"].ToString().Trim());
                        htParam.Add("@Length", dtCurrentTable.Rows[0]["Length"].ToString().Trim());
                        htParam.Add("@Flag", "2");
                        //int x = dataAccessRecruit.execute_SPRCPrcUpdDwnld("Prc_CreateTempTable", htParam);
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
                    catch (Exception ex)
                    {

                    }
                }
                btnFinish.Enabled = false;

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
            if (Request.QueryString["ACT"].ToUpper().Trim() == "UPDVR")
            {
                Response.Redirect("MstTblDesign.aspx?ACT=UPDVR");
            }
        }
        else
        {
            Response.Redirect("MstTblDesign.aspx");
        }
    }
    #endregion

    #region PopulateFileSize
    private void PopulateFileSize()
    {
        oCommon.getDropDown(ddlFileSize, "FileSizs", 1, "", 1);
        ddlFileSize.Items.Insert(0, "--Select--");
    }
    #endregion

    #region Fill Document name dropdown
    private void PopulateDocName()
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Action", "Upd");
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
            tblEditDesign.Visible = false;
            tblUpload.Visible = false;
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

    #region UPLOAD_PAGEINFORMATION
    private void ShowUpdPageInformation()
    {
        int intPageIndex = dgUpload.PageIndex + 1;
        lblUPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgUpload.PageCount;
    }
    #endregion

    #region dgUpload_RowCommand
    protected void dgUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

            int deleteRowId = row.RowIndex;

            Label lblDColumnName = (Label)row.FindControl("lblUColumnName");
            string strValue = ddlName.SelectedItem.Value.ToString();

            DataTable dtDeleteRecord = (DataTable)ViewState["UpdDwnld"];
            ViewState["UpdDwnld"] = null;
            dtDeleteRecord.Rows.RemoveAt(deleteRowId);

            //htParam.Clear();
            //htParam.Add("@Flag", "1");
            //htParam.Add("@DocType", ddlName.SelectedItem.Value.ToString());
            //htParam.Add("@ColName", lblDColumnName.Text);
            //strDelete = dataAccessRecruit.execute_sprc_UpdDwnld_with_output_connKey("Prc_DelUpldDwnld", htParam, "@Value", "UpdDwnldConnectionString");

            lbl_popup.Text = "Selected record has been deleted successfully";
            tblButton.Visible = true;
            btnConfirm.Enabled = true;
            btnFinish.Enabled = false;
            btnCancel.Enabled = true;

            mdlpopup.Show();

            ViewState["UpdDwnld"] = dtDeleteRecord;
            dgUpload.DataSource = dtDeleteRecord;
            dgUpload.DataBind();
        }
        if (e.CommandName == "Edit")
        {
            hdnGridRowId.Value = "";
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

            int row1id = row1.RowIndex;
            hdnGridRowId.Value = row1id.ToString();

            Label lblUColumnName = (Label)row1.FindControl("lblUColumnName");
            //Session["UColumnName"] = lblUColumnName.Text;
            hdnColumnName.Value = lblUColumnName.Text;
            Label lblUIsprimary = (Label)row1.FindControl("lblUIsprimary");
            //Session["UIsprimary"] = lblUIsprimary.Text;
            hdnIsprimary.Value = lblUIsprimary.Text;
            Label lblUDataType = (Label)row1.FindControl("lblUDataType");
            //Session["UDataType"] = lblUDataType.Text;
            hdnDataType.Value = lblUDataType.Text;
            Label lblULength = (Label)row1.FindControl("lblULength");
            //Session["ULength"] = lblULength.Text;
            hdnLength.Value = lblULength.Text;
            Label lblUMandatory = (Label)row1.FindControl("lblUMandatory");
            //Session["UMandatory"] = lblUMandatory.Text;
            hdnMandatory.Value = lblUMandatory.Text;
            Label lblUVrifReq = (Label)row1.FindControl("lblUVrifReq");
            //Session["UVrifReq"] = lblUVrifReq.Text;
            hdnVrifReq.Value = lblUVrifReq.Text;
            Label lblUPermissibleValues = (Label)row1.FindControl("lblUPermissibleValues");
            //Session["UPermissibleValues"] = lblUPermissibleValues.Text;
            hdnPermissibleValues.Value = lblUPermissibleValues.Text;
            Label lblUVrifDb = (Label)row1.FindControl("lblUVrifDb");
            //Session["UVrifDb"] = lblUVrifDb.Text;
            hdnVrifDb.Value = lblUVrifDb.Text;
            Label lblUVerifTbl = (Label)row1.FindControl("lblUVerifTbl");
            //Session["UVerifTbl"] = lblUVerifTbl.Text;
            hdnVerifTbl.Value = lblUVerifTbl.Text;
            Label lblUVerifTblColumn = (Label)row1.FindControl("lblUVerifTblColumn");
            //Session["UVerifTblColumn"] = lblUVerifTblColumn.Text;
            hdnVerifTblColumn.Value = lblUVerifTblColumn.Text;
        }
    }
    #endregion

    #region dgUpload_RowDataBound
    protected void dgUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
            l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record?')");
        }

    }
    #endregion

    #region dgUpload_RowDeleting
    protected void dgUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region dgUpload_RowEditing
    protected void dgUpload_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgUpload.EditIndex = e.NewEditIndex;
        //illGrid();
        tblEditDesign.Visible = true;
        BindGrid();
        foreach (GridViewRow row in dgMstDesign.Rows)
        {
            TextBox txt1 = (TextBox)row.FindControl("txtColName");
            TextBox txt2 = (TextBox)row.FindControl("txtLength");
            TextBox txt3 = (TextBox)row.FindControl("txtPermisibleValues");
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
            DropDownList ddl3 = (DropDownList)row.FindControl("ddlIsMandatory");
            DropDownList ddl4 = (DropDownList)row.FindControl("ddlVerifReq");
            DropDownList ddl5 = (DropDownList)row.FindControl("ddlDB");
            DropDownList ddl6 = (DropDownList)row.FindControl("ddltbl");
            DropDownList ddl7 = (DropDownList)row.FindControl("ddlCol");

            txt1.Text = hdnColumnName.Value;
            txt2.Text = hdnLength.Value;
            txt3.Text = hdnPermissibleValues.Value;
            ddl1.SelectedValue = hdnIsprimary.Value;
            ddl2.SelectedValue = hdnDataType.Value;
            ddl3.SelectedValue = hdnMandatory.Value;
            ddl4.SelectedValue = hdnVrifReq.Value;

            if (hdnVrifDb.Value.ToString() != "")
            {
                Hashtable htFillDB = new Hashtable();
                DataSet dsFillDB = new DataSet();
                htFillDB.Add("@Flag", "1");
                htFillDB.Add("@DB", System.DBNull.Value);
                htFillDB.Add("@Table", System.DBNull.Value);
                dsFillDB = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htFillDB);

                ddl5.Items.Clear();
                ddl5.DataSource = dsFillDB;
                ddl5.DataTextField = "DatabaseName";
                ddl5.DataValueField = "DatabaseName";
                ddl5.DataBind();
                ddl5.Items.Insert(0, "--Select--");

                ddl5.SelectedValue = hdnVrifDb.Value;

                ddl5.Enabled = true;
            }
            else
            {
                ddl5.SelectedValue = hdnVrifDb.Value;
                ddl5.Enabled = false;
            }

            if (hdnVerifTbl.Value.ToString() != "")
            {
                DataSet dsFillTable = new DataSet();
                Hashtable htFillDB = new Hashtable();
                htFillDB.Add("@Flag", "2");
                htFillDB.Add("@DB", hdnVrifDb.Value.ToString().Trim());
                htFillDB.Add("@Table", System.DBNull.Value);
                dsFillTable = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htFillDB);

                ddl6.DataSource = dsFillTable;
                ddl6.DataTextField = "tablename";
                ddl6.DataValueField = "tablename";
                ddl6.DataBind();
                ddl6.Items.Insert(0, "--Select--");

                ddl6.SelectedValue = hdnVerifTbl.Value;

                ddl6.Enabled = true;
            }
            else
            {
                ddl6.SelectedValue = hdnVerifTbl.Value;
                ddl6.Enabled = false;
            }

            if (hdnVerifTblColumn.Value.ToString() != "")
            {
                DataSet dsFillColumn = new DataSet();
                Hashtable htDB = new Hashtable();
                htDB.Add("@Flag", "3");
                htDB.Add("@DB", hdnVrifDb.Value.ToString().Trim());
                htDB.Add("@Table", hdnVerifTbl.Value.ToString().Trim());
                dsFillColumn = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_Get_DBandTable", htDB);

                ddl7.DataSource = dsFillColumn;
                ddl7.DataTextField = "COLUMN_NAME";
                ddl7.DataValueField = "COLUMN_NAME";
                ddl7.DataBind();
                ddl7.Items.Insert(0, "--Select--");

                ddl7.SelectedValue = hdnVerifTblColumn.Value;

                ddl7.Enabled = true;
            }
            else
            {
                ddl7.SelectedValue = hdnVerifTblColumn.Value;
                ddl7.Enabled = false;
            }
        }

    }
    #endregion

    #region FillGrid
    private void FillGrid()
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@Action", "Upd");
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
                tblEditDesign.Visible = false;
                tbl_grid.Visible = false;
                divSearchDetails.Visible = false;
                tbldgMstDocDesign.Visible = false;
                tblUpload.Visible = true;
                btnAdd.Visible = true;
                dgUpload.DataSource = ViewState["UpdDwnld"];
                dgUpload.DataBind();
                ShowUpdPageInformation();
            }
            else
            {
                tblMstDesign.Visible = false;
                tblDocType.Visible = true;
                tblEditDesign.Visible = false;
                tbl_grid.Visible = false;
                divSearchDetails.Visible = false;
                tbldgMstDocDesign.Visible = false;
                tblUpload.Visible = false;
            }
        }
        else
        {
            tblMstDesign.Visible = false;
            tblDocType.Visible = true;
            tblEditDesign.Visible = false;
            tbl_grid.Visible = false;
            divSearchDetails.Visible = false;
            tbldgMstDocDesign.Visible = false;
            tblUpload.Visible = false;
        }
    }
    #endregion

    #region btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblEditDesign.Visible = true;
        dgMstDesign.Visible = true;
        BindGrid();
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
            TextBox txt2 = (TextBox)row.FindControl("txtLength");
            TextBox txt3 = (TextBox)row.FindControl("txtPermisibleValues");
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)row.FindControl("ddlDataType");
            DropDownList ddl3 = (DropDownList)row.FindControl("ddlIsMandatory");
            DropDownList ddl4 = (DropDownList)row.FindControl("ddlVerifReq");
            DropDownList ddl5 = (DropDownList)row.FindControl("ddlDB");
            DropDownList ddl6 = (DropDownList)row.FindControl("ddltbl");
            DropDownList ddl7 = (DropDownList)row.FindControl("ddlCol");

            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            ddl1.ClearSelection();
            ddl2.ClearSelection();
            ddl3.ClearSelection();
            ddl4.ClearSelection();
            ddl5.ClearSelection();
            ddl6.ClearSelection();
            ddl7.ClearSelection();

            ddl5.Items.Clear();
            ddl5.Items.Insert(0, "--Select--");
            ddl6.Items.Clear();
            ddl6.Items.Insert(0, "--Select--");
            ddl7.Items.Clear();
            ddl7.Items.Insert(0, "--Select--");
            ddl5.Enabled = false;
            ddl6.Enabled = false;
            ddl7.Enabled = false;
            btnIns.Enabled = true;
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
            DataRow drCurrentRow = null;

            DropDownList ddl1 = (DropDownList)dgMstDesign.Rows[0].Cells[1].FindControl("ddlIsPrim");
            DropDownList ddl2 = (DropDownList)dgMstDesign.Rows[0].Cells[2].FindControl("ddlDataType");
            DropDownList ddl3 = (DropDownList)dgMstDesign.Rows[0].Cells[4].FindControl("ddlIsMandatory");
            DropDownList ddl4 = (DropDownList)dgMstDesign.Rows[0].Cells[6].FindControl("ddlVerifReq");
            DropDownList ddl5 = (DropDownList)dgMstDesign.Rows[0].Cells[7].FindControl("ddlDB");
            DropDownList ddl6 = (DropDownList)dgMstDesign.Rows[0].Cells[8].FindControl("ddlTbl");
            DropDownList ddl7 = (DropDownList)dgMstDesign.Rows[0].Cells[9].FindControl("ddlCol");

            TextBox txt1 = (TextBox)dgMstDesign.Rows[0].Cells[0].FindControl("txtColName");
            TextBox txt2 = (TextBox)dgMstDesign.Rows[0].Cells[3].FindControl("txtLength");
            TextBox txt3 = (TextBox)dgMstDesign.Rows[0].Cells[5].FindControl("txtPermisibleValues");

            DataTable dtUpldDwnld = (DataTable)ViewState["UpdDwnld"];
            ViewState["UpdDwnld"] = null;

            DataRow dr = dtUpldDwnld.NewRow();
            dr["DocType"] = ddlName.SelectedItem.Value.ToString().Trim();
            dr["ColumnName"] = txt1.Text;
            dr["DataType"] = ddl2.SelectedItem.Text;
            dr["Length"] = txt2.Text;
            dr["MandatoryFlag"] = ddl3.Text;    

            //Checking ismandatory start
            //for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
            //{
            //    string strprimary = dtCurrentTable.Rows[i]["Isprimary"].ToString();
            //    int count = 0;

            //    count = count + Convert.ToInt32(strprimary);
            //    if (count >= 1 && Convert.ToInt32(ddl1.SelectedItem.Value) == 1)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only one primary field allowed')", true);
            //        return;
            //    }
            //    else
            //    {
            //        drCurrentRow["Isprimary"] = ddl1.Text;
            //    }
            //}


            //Verifreq check
            if (ddl4.SelectedItem.Value.ToString().Trim() == "1")
            {
                if (txt3.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter permissible value.')", true);
                    ViewState["UpdDwnld"] = dtUpldDwnld;
                    return;
                }
            }
            else if (ddl4.SelectedItem.Value.ToString().Trim() == "2")
            {
                if ((ddl5.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select database value.')", true);
                    ViewState["UpdDwnld"] = dtUpldDwnld;
                    return;
                }
                else if ((ddl6.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select table value.')", true);
                    ViewState["UpdDwnld"] = dtUpldDwnld;
                    return;
                }
                else if ((ddl7.Text == "--Select--"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select column value.')", true);
                    ViewState["UpdDwnld"] = dtUpldDwnld;
                    return;
                }
            }
            
            dr["IsPrimary"] = ddl1.Text;
            
            if (ddl4.Text != "--Select--")
            {
                dr["VerifReq"] = ddl4.SelectedItem.Text;
            }
            else
            {
                dr["VerifReq"] = System.DBNull.Value;
            }
            if (txt3.Text != "")
            {
                dr["PremissibleValues"] = txt3.Text;
            }
            else
            {
                dr["PremissibleValues"] = System.DBNull.Value;
            }

            if (ddl5.Text != "--Select--")
            {
                dr["VerifDb"] = ddl5.SelectedItem.Text;
            }
            else
            {
                dr["VerifDb"] = System.DBNull.Value;
            }
            if (ddl6.Text != "--Select--")
            {
                dr["VerifTbl"] = ddl6.SelectedItem.Text;
            }
            else
            {
                dr["VerifTbl"] = System.DBNull.Value;
            }
            if (ddl7.Text != "--Select--")
            {
                dr["VerifTblColumn"] = ddl7.SelectedItem.Text;
            }
            else
            {
                dr["VerifTblColumn"] = System.DBNull.Value;
            }

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
            dgUpload.DataSource = dtUpldDwnld;
            dgUpload.DataBind();

            txt1.Text = ""; txt2.Text = ""; txt3.Text = ""; //txt4.Text = "";
            ddl1.ClearSelection();
            ddl2.ClearSelection();
            ddl3.ClearSelection();
            ddl4.ClearSelection();
            ddl5.ClearSelection();
            ddl6.ClearSelection();
            ddl7.ClearSelection();
            tblEditDesign.Visible = false;

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
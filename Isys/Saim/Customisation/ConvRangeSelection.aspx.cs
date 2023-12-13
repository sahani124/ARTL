using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Data;
using System.Collections;
using DataAccessClassDAL;
public partial class Application_Isys_Saim_Customisation_ConvRangeSelection : BaseClass
{
    class InputRequest
    {
        public string ACT_SCH_KEY { get; set; }
        public string KPI_CODE { get; set; }
        public string FIX_FACTOR { get; set; }
        public string SELECTED_RANGE { get; set; }
        public string VAL_CODE { get; set; }
        public string ACTION_TYPE { get; set; }
        public string TYPE { get; set; }
        public string MyPropverty { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                container.Style.Add("display", "none");
                loadersvg.Style.Add("display", "block");
            }
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    public void BindAllData()
    {
        txtLeftSearch.Text = "";
        txtRightSearch.Text = "";

        container.Style.Add("display", "none");
        loadersvg.Style.Add("display", "block");

        GvRightSide.PageIndex = 0;
        GvLeftSide.PageIndex = 0;
        DataSet dsFIX = JsonConvert.DeserializeObject<DataSet>(hdnSelectedFixFactor.Value);
        DataSet dsSelected = JsonConvert.DeserializeObject<DataSet>(hdnPreviousSelected.Value);
        DataAccessClass objDal = new DataAccessClass();
        Hashtable ht = new Hashtable();
        ht.Add("@VAL_DATA", dsFIX.Tables[0]);
        ht.Add("@ACT_SCH_KEY", Convert.ToString(Request.QueryString["ACT_SCH_KEY"]));
        ht.Add("@KPI_CODE", Convert.ToString(Request.QueryString["KPI_CODE"]));
        ht.Add("@ACTION_TYPE", Convert.ToString(Request.QueryString["ACTION_TYPE"]));
        ht.Add("@TYPE", Convert.ToString(Request.QueryString["TYPE"]));

        if (dsSelected.Tables[0].Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VAL_CODE");
            dt.Columns.Add("RangeData");
            ht.Add("@Selected_Range", dt);
        }
        else
        {
            ht.Add("@Selected_Range", dsSelected.Tables[0]);
        }

        ht.Add("@VAL_CODE", Convert.ToString(Request.QueryString["VAL_CODE"]));
        DataSet ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_COVT_RANGE_FACTOR_VAL_CODE", ht);
        DataTable SelectedRows = ds.Tables[0].Copy();
        ViewState["AllRows"] = ds.Tables[0];
        ViewState["SelectedRows"] = SelectedRows;

        if (hdnCurrentSelected.Value.Trim() == "")
        {
            GvLeftSide.DataSource = ds.Tables[0];
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            SelectedRows.Rows.Clear();
            SelectedRows.AcceptChanges();
            GvRightSide.DataSource = SelectedRows;
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
        }
        else
        {
            BindAlreadySelectedValues();
        }
        container.Style.Add("display", "block");
        loadersvg.Style.Add("display", "none");
    }

    public void BindAlreadySelectedValues()
    {
        try
        {
            DataTable dtLeftSide = (DataTable)ViewState["AllRows"];

            DataSet dsRightSide = JsonConvert.DeserializeObject<DataSet>(hdnCurrentSelected.Value);
            ViewState["SelectedRows"] = dsRightSide.Tables[0];
            GvRightSide.DataSource = dsRightSide.Tables[0];
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;

            ArrayList index = new ArrayList();
            for (int i = 0; i < dsRightSide.Tables[0].Rows.Count; i++)
            {
                for (int j = dtLeftSide.Rows.Count - 1; j >= 0; j--)
                {
                    if (Convert.ToString(dsRightSide.Tables[0].Rows[i]["Range"]) == Convert.ToString(dtLeftSide.Rows[j]["Range"]))
                    {
                        index.Add(j);
                    }
                }
            }

            for (int i = 0; i < index.Count; i++)
            {
                int j = (int)index[i];
                dtLeftSide.Rows[j].Delete();
            }

            dtLeftSide.AcceptChanges();
            GvLeftSide.DataSource = dtLeftSide;
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    public void BindAllData_Old()
    {
        string data = Convert.ToString(Request.QueryString["data"]);
        var json = System.Convert.FromBase64String(data);
        string str = Encoding.UTF8.GetString(json);
        InputRequest obj = JsonConvert.DeserializeObject<InputRequest>(str);
        DataSet dsFIX = JsonConvert.DeserializeObject<DataSet>(obj.FIX_FACTOR);
        DataSet dsSelected = JsonConvert.DeserializeObject<DataSet>(obj.SELECTED_RANGE);
        DataAccessClass objDal = new DataAccessClass();
        Hashtable ht = new Hashtable();
        ht.Add("@VAL_DATA", dsFIX.Tables[0]);
        ht.Add("@ACT_SCH_KEY", obj.ACT_SCH_KEY);
        ht.Add("@KPI_CODE", obj.KPI_CODE);
        ht.Add("@ACTION_TYPE", obj.ACTION_TYPE);
        ht.Add("@TYPE", obj.TYPE);

        if (dsSelected.Tables[0].Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VAL_CODE");
            dt.Columns.Add("RangeData");
            ht.Add("@Selected_Range", dt);
        }
        else
        {
            ht.Add("@Selected_Range", dsSelected.Tables[0]);
        }

        ht.Add("@VAL_CODE", obj.VAL_CODE);
        DataSet ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_COVT_RANGE_FACTOR_VAL_CODE", ht);
        GvLeftSide.DataSource = ds.Tables[0];
        GvLeftSide.DataBind();
        GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
        GvLeftSide.UseAccessibleHeader = true;

        DataTable SelectedRows = ds.Tables[0].Copy();
        SelectedRows.Rows.Clear();
        SelectedRows.AcceptChanges();
        GvRightSide.DataSource = SelectedRows;
        GvRightSide.DataBind();
        GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
        GvRightSide.UseAccessibleHeader = true;

        ViewState["AllRows"] = ds.Tables[0];
        ViewState["SelectedRows"] = SelectedRows;
    }

    protected void GvLeftSide_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            GvLeftSide.PageIndex = e.NewPageIndex;
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;

            DataTable dtLeft = (DataTable)ViewState["AllRows"];
            if (txtLeftSearch.Text.Trim() == "")
            {
                GvLeftSide.DataSource = dtLeft;
                GvLeftSide.DataBind();
                GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvLeftSide.UseAccessibleHeader = true;
                return;
            }

            DataRow[] FilteredRows = dtLeft.Select("ParamDesc Like '%" + txtLeftSearch.Text.Trim() + "%'");
            DataTable FilteredData = dtLeft.Clone();
            FilteredData.Rows.Clear();
            if (FilteredRows.Length > 0)
            {
                FilteredData = FilteredRows.CopyToDataTable();
            }
            GvLeftSide.DataSource = FilteredData;
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void GvLeftSide_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void GvRightSide_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            //DataTable dtLeft = (DataTable)ViewState["AllRows"];
            DataTable dtRight = (DataTable)ViewState["SelectedRows"];
            GvRightSide.PageIndex = e.NewPageIndex;
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            if (txtRightSearch.Text.Trim() == "")
            {
                GvRightSide.DataSource = dtRight;
                GvRightSide.DataBind();
                GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvRightSide.UseAccessibleHeader = true;
                return;
            }

            DataRow[] FilteredRows = dtRight.Select("ParamDesc Like '%" + txtRightSearch.Text.Trim() + "%'");
            DataTable FilteredData = dtRight.Clone();
            FilteredData.Rows.Clear();
            if (FilteredRows.Length > 0)
            {
                FilteredData = FilteredRows.CopyToDataTable();
            }
            GvRightSide.DataSource = FilteredData;
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
            
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void GvRightSide_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void chkLeftAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < GvLeftSide.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(GvLeftSide.Rows[i].FindControl("chkLeft"));
                CheckBox allchk = (CheckBox)sender;
                chk.Checked = allchk.Checked;
            }
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void chkRightAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GvRightSide.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(GvRightSide.Rows[i].FindControl("chkRight"));
                CheckBox allchk = (CheckBox)sender;
                chk.Checked = allchk.Checked;
            }
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;

            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void btnSelectorLeft_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dsAllData = (DataTable)ViewState["AllRows"];
            DataTable dsSelectedData = (DataTable)ViewState["SelectedRows"];

            ArrayList index = new ArrayList();
            for (int i = 0; i < GvLeftSide.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(GvLeftSide.Rows[i].FindControl("chkLeft"));
                if (chk.Checked)
                {
                    string Range = Convert.ToString(GvLeftSide.DataKeys[i]["Range"]);
                    DataRow[] dr = dsAllData.Select("Range = '" + Range + "'");
                    for (int k = 0; k < dr.Length; k++)
                    {
                        index.Add(dsAllData.Rows.IndexOf(dr[k]));
                        dsSelectedData.Rows.Add(dr[k].ItemArray);
                        dsSelectedData.AcceptChanges();
                    }
                }
            }

            index.Sort();
            index.Reverse();

            for (int i = 0; i < index.Count; i++)
            {
                dsAllData.Rows[(int)index[i]].Delete();
            }

            dsAllData.AcceptChanges();
            ViewState["AllRows"] = dsAllData;
            ViewState["SelectedRows"] = dsSelectedData;

            GvLeftSide.DataSource = dsAllData;
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            GvRightSide.DataSource = dsSelectedData;
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void btnSelectorRight_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dsAllData = (DataTable)ViewState["AllRows"];
            DataTable dsSelectedData = (DataTable)ViewState["SelectedRows"];
            ArrayList index = new ArrayList();

            for (int i = 0; i < GvRightSide.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(GvRightSide.Rows[i].FindControl("chkRight"));
                if (chk.Checked)
                {
                    string Range = Convert.ToString(GvRightSide.DataKeys[i]["Range"]);
                    DataRow[] dr = dsSelectedData.Select("Range = '" + Range + "'");
                    for (int k = 0; k < dr.Length; k++)
                    {
                        index.Add(dsSelectedData.Rows.IndexOf(dr[k]));
                        dsAllData.Rows.Add(dr[k].ItemArray);
                        dsAllData.AcceptChanges();
                    }
                }
            }

            index.Sort();
            index.Reverse();

            for (int i = 0; i < index.Count; i++)
            {
                dsSelectedData.Rows[(int)index[i]].Delete();
            }

            dsSelectedData.AcceptChanges();
            ViewState["AllRows"] = dsAllData;
            ViewState["SelectedRows"] = dsSelectedData;

            GvLeftSide.DataSource = dsAllData;
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            GvRightSide.DataSource = dsSelectedData;
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }
    protected void btnLoadData_Click(object sender, EventArgs e)
    {
        BindAllData();
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dsSelectedData = (DataTable)ViewState["SelectedRows"];
            if (dsSelectedData.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NoRowSelected", "alert('Please select atleast one combination')", true);
                return;
            }
            string str = JsonConvert.SerializeObject(dsSelectedData);
            var VAL_CODE = Convert.ToString(Request.QueryString["VAL_CODE"]);
            string function = String.Format("passDataToParent('{0}', '{1}'); ClosePopup();", str.Replace("'", ""), VAL_CODE);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "NoRowSelected", function, true);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void btnLeftSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtLeft = (DataTable)ViewState["AllRows"];
            DataTable dtRight = (DataTable)ViewState["SelectedRows"];
            GvLeftSide.PageIndex = 0;
            if (txtLeftSearch.Text.Trim() == "")
            {
                GvLeftSide.DataSource = dtLeft;
                GvLeftSide.DataBind();
                GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvLeftSide.UseAccessibleHeader = true;

                if (txtRightSearch.Text.Trim() == "")
                {
                    GvRightSide.DataSource = dtRight;
                    GvRightSide.DataBind();
                    GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GvRightSide.UseAccessibleHeader = true;
                }
                else
                {
                    DataRow[] RightFilteredRows = dtRight.Select("ParamDesc Like '%" + txtRightSearch.Text.Trim() + "%'");
                    DataTable RightFilteredData = dtRight.Clone();

                    RightFilteredData.Rows.Clear();
                    if (RightFilteredRows.Length > 0)
                    {
                        RightFilteredData = RightFilteredRows.CopyToDataTable();
                    }

                    GvRightSide.DataSource = RightFilteredData;
                    GvRightSide.DataBind();
                    GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GvRightSide.UseAccessibleHeader = true;
                }
                return;
            }
            
            DataRow[] FilteredRows = dtLeft.Select("ParamDesc Like '%" + txtLeftSearch.Text.Trim() + "%'");
            DataTable FilteredData = dtLeft.Clone();
            FilteredData.Rows.Clear();
            if (FilteredRows.Length > 0)
            {
                FilteredData = FilteredRows.CopyToDataTable();
            }
            GvLeftSide.DataSource = FilteredData;
            GvLeftSide.DataBind();
            GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvLeftSide.UseAccessibleHeader = true;

            //GvRightSide.DataSource = dtRight;
            //GvRightSide.DataBind();
            //GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            //GvRightSide.UseAccessibleHeader = true;

            if (txtRightSearch.Text.Trim() == "")
            {
                GvRightSide.DataSource = dtRight;
                GvRightSide.DataBind();
                GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvRightSide.UseAccessibleHeader = true;
            }
            else
            {
                DataRow[] RightFilteredRows = dtRight.Select("ParamDesc Like '%" + txtRightSearch.Text.Trim() + "%'");
                DataTable RightFilteredData = dtRight.Clone();

                RightFilteredData.Rows.Clear();
                if (RightFilteredRows.Length > 0)
                {
                    RightFilteredData = RightFilteredRows.CopyToDataTable();
                }

                GvRightSide.DataSource = RightFilteredData;
                GvRightSide.DataBind();
                GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvRightSide.UseAccessibleHeader = true;
            }

        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }

    protected void btnRightSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtLeft = (DataTable)ViewState["AllRows"];
            DataTable dtRight = (DataTable)ViewState["SelectedRows"];
            GvRightSide.PageIndex = 0;
            if (txtRightSearch.Text.Trim() == "")
            {
                if(txtLeftSearch.Text.Trim() == "")
                {
                    GvLeftSide.DataSource = dtLeft;
                    GvLeftSide.DataBind();
                    GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GvLeftSide.UseAccessibleHeader = true;
                }
                else
                {
                    DataRow[] LeftFilteredRows = dtLeft.Select("ParamDesc Like '%" + txtLeftSearch.Text.Trim() + "%'");
                    DataTable LeftsFilteredData = dtLeft.Clone();
                    LeftsFilteredData.Rows.Clear();

                    if (LeftFilteredRows.Length > 0)
                    {
                        LeftsFilteredData = LeftFilteredRows.CopyToDataTable();
                    }


                    GvLeftSide.DataSource = LeftsFilteredData;
                    GvLeftSide.DataBind();
                    GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                    GvLeftSide.UseAccessibleHeader = true;
                }

                GvRightSide.DataSource = dtRight;
                GvRightSide.DataBind();
                GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvRightSide.UseAccessibleHeader = true;
                return;
            }

            DataRow[] FilteredRows = dtRight.Select("ParamDesc Like '%" + txtRightSearch.Text.Trim() + "%'");
            DataTable FilteredData = dtLeft.Clone();
            FilteredData.Rows.Clear();
            if (FilteredRows.Length > 0)
            {
                FilteredData = FilteredRows.CopyToDataTable();
            }
            //GvLeftSide.DataSource

            //GvLeftSide.DataSource = dtLeft;
            //GvLeftSide.DataBind();
            //GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            //GvLeftSide.UseAccessibleHeader = true;

            if (txtLeftSearch.Text.Trim() == "")
            {
                GvLeftSide.DataSource = dtLeft;
                GvLeftSide.DataBind();
                GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvLeftSide.UseAccessibleHeader = true;
            }
            else
            {
                DataRow[] LeftFilteredRows = dtLeft.Select("ParamDesc Like '%" + txtLeftSearch.Text.Trim() + "%'");
                DataTable LeftsFilteredData = dtLeft.Clone();
                LeftsFilteredData.Rows.Clear();
                if (LeftFilteredRows.Length > 0)
                {
                    LeftsFilteredData = LeftFilteredRows.CopyToDataTable();
                }

                GvLeftSide.DataSource = LeftsFilteredData;
                GvLeftSide.DataBind();
                GvLeftSide.HeaderRow.TableSection = TableRowSection.TableHeader;
                GvLeftSide.UseAccessibleHeader = true;
            }

            GvRightSide.DataSource = FilteredData;
            GvRightSide.DataBind();
            GvRightSide.HeaderRow.TableSection = TableRowSection.TableHeader;
            GvRightSide.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("SAIM", sRet, method.Name.ToString(), error, "");
        }
    }
}
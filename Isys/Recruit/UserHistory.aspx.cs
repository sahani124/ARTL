using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class UserHistory : BaseClass
{
    /// <summary>
    /// This Class Displays the History of test takers either by Name, by Employee Code or by BOTH.    
    /// </summary>

    #region Global Declaration
    DataSet dsResult = new DataSet();
    DataAccessClass objDAL = new DataAccessClass();
    Hashtable ht = new Hashtable();
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            BindDataGrid();

           
        }
        else
        {
            String tmp = "<div style='width:100%; height:100%; font-wieght:bold;'>Please provide data in correct Format!";
            StringBuilder sb = new StringBuilder();
            sb.Append("bootbox.alert(\"");
            sb.Append(tmp);
            sb.Append("\");");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "JS1", sb.ToString(), true);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Label lblError = (Label)FindControl("lblError");
        lblError.Visible = false;
        gvDetails.DataSource = null;
        gvDetails.DataBind();
        tbl_Details.Visible = false;

        txtEmployeeCode.Text = String.Empty;
        txtEmployeeName.Text = String.Empty;
    }

    protected void lnkViewReport_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkViewReport = (LinkButton)row.FindControl("lnkViewReport");
        Label lblName = (Label)row.FindControl("lblName");
        try
        {
            ht.Clear();
            dsResult = null;
            ht.Add("@MemberName", lblName.Text.ToString().Trim());
            dsResult = objDAL.GetDataSetForPrc("prc_GetReportofMember", ht);
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                int totalO = Convert.ToInt32(dsResult.Tables[0].Rows[0]["COUNT-O"]);
                int totalG = Convert.ToInt32(dsResult.Tables[0].Rows[0]["COUNT-G"]);
                int totalI = Convert.ToInt32(dsResult.Tables[0].Rows[0]["COUNT-I"]);
                int totalD = Convert.ToInt32(dsResult.Tables[0].Rows[0]["COUNT-D"]);

                if (totalO > totalG && totalI > totalD)
                {
                    //OI-Stable
                    ht.Clear();
                    ht.Add("@Type", "OI");
                }
                if (totalO > totalG && totalD > totalI)
                {
                    //OD- Expressive
                    ht.Clear();
                    ht.Add("@Type", "OD");
                }
                if (totalG > totalO && totalI > totalD)
                {
                    //GI- Analyst
                    ht.Clear();
                    ht.Add("@Type", "GI");
                }
                if (totalG > totalO && totalD > totalI)
                {
                    //GD- Dominant
                    ht.Clear();
                    ht.Add("@Type", "GD");
                }
                dsResult = null;
                dsResult = objDAL.GetDataSetForPrc("prc_GetCharacteristicsforUser", ht);

                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    String str1 = Convert.ToString(dsResult.Tables[0].Rows[0]["CharDesc"]);
                    String str2 = Convert.ToString(dsResult.Tables[0].Rows[0]["CharAnalysis"]);
                    String str3 = "<div style='font-size:11.0pt;font-family:Calibri,sans-serif;color:black;'><h1>You are '" + str1 + "'!</h1><hr /><br />" + str2 + "</div>";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("bootbox.alert(\"");
                    sb.Append(str3);
                    sb.Append("\");");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Js1", sb.ToString(), true);
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    #region GRIDVIEW EVENTS and FUNCTIONS
    protected void gvDetails_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformation();
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

    protected DataTable GetDataTable()
    {
        DataSet ds = new DataSet();
        Hashtable htParam = new Hashtable();
        htParam.Add("@EmpCode", txtEmployeeCode.Text);
        htParam.Add("@EmpName", txtEmployeeName.Text);
        dsResult = objDAL.GetDataSetForPrc("prc_GetPreviousTestTakers", ht);
        return ds.Tables[0];
    }

    private void ShowPageInformation()
    {
        int intPageIndex = gvDetails.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gvDetails.PageCount;
    }

    protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
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
            ShowPageInformation();
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
    #endregion
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvDetails.PageIndex;
            gvDetails.PageIndex = pageIndex - 1;
            BindDataGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            // btnprevious.Enabled = true;
            int page = gvDetails.PageCount;
            //if (txtPage.Text == Convert.ToString(gvDetails.PageCount))
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                int intPageIndex = gvDetails.PageIndex - 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gvDetails.PageCount;
            }
        }
        //{
        //    int pageIndex = gvDetails.PageIndex;
        //    gvDetails.PageIndex = pageIndex - 1;
        //    BindDataGrid();
        //    //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
        //    if (txtPage.Text == "1")
        //    {
        //        btnprevious.Enabled = false;
        //    }
        //    else
        //    {
        //        btnprevious.Enabled = true;
        //    }
        //    btnnext.Enabled = true;
        //}
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvDetails.PageIndex;
            gvDetails.PageIndex = pageIndex + 1;
            BindDataGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = gvDetails.PageCount;
            if (txtPage.Text == Convert.ToString(gvDetails.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = gvDetails.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gvDetails.PageCount;
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
    #region BindDataGrid
    protected void BindDataGrid()
    {
        try
        {
            dsResult = null;
            ht.Clear();
            ht.Add("@EmpCode", txtEmployeeCode.Text);
            ht.Add("@EmpName", txtEmployeeName.Text);
            dsResult = objDAL.GetDataSetForPrc("prc_GetPreviousTestTakers", ht);
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                tbl_Details.Visible = true;
                gvDetails.DataSource = dsResult;
                gvDetails.DataBind();
                ShowPageInformation();
            }
            else
            {
                Label lblError = (Label)FindControl("lblError");
                lblError.Visible = true;
                lblError.Text = "0 record(s) found.";
                dsResult.Clear();
                dsResult = null;
                gvDetails.DataSource = null;
                gvDetails.DataBind();
                // lblPageInfo.Text = String.Empty;
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
    #endregion
}
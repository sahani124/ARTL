using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Collections;
using System.Web.UI.HtmlControls;
using DataAccessClassDAL;
using Telerik.Web.UI;

public partial class Application_ISys_Saim_ViewCmpStatement : BaseClass
{
    DataTable dt = new DataTable();
    Hashtable ht = new Hashtable();
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    static string cmptype = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "Pay")
            {
                if (Request.QueryString["MemCode"] != null)
                {
                    if (Request.QueryString["MemCode"].ToString().Trim() != "")
                    {
                        FillStatSumMem(Request.QueryString["MemCode"].ToString().Trim());
                    }
                }
                if (Request.QueryString["CommPts"].ToString().Trim() != null)
                {
                    if (Request.QueryString["CommPts"].ToString().Trim() != "")
                    {
                        hdnCommPts.Value = Request.QueryString["CommPts"].ToString().Trim();
                    }
                }

            }
        }
        if (!IsPostBack)
        {
            dt.Clear();
        }
        ////FillLOBPolCht();
    }

    public DataTable BindGrid()
    {
        ht = new Hashtable();
        ds = new DataSet();
        dt.Clear();
        if (Request.QueryString["MemCode"] != null)
        {
            if (Request.QueryString["MemCode"].ToString().Trim() != "")
            {
                ht.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            }
        }
        ht.Add("@CycDt1", Convert.ToDateTime(lblFromDtVal.Text.ToString()));
        ht.Add("@CycDt2", Convert.ToDateTime(lblToDtVal.Text.ToString()));
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMQYComm", ht);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    return dt;
                }
            }
            else
            {
                ds = null;
            }
        }
        return dt;
    }

    public void FillLOBCht()
    {
        DataTable dtLOB = new DataTable();
        ht = new Hashtable();
        //ds = new DataSet();
        DataSet ds11 = new DataSet();
        ds.Clear();
        ht.Add("@MemCode", lblMemCodeVal.Text.ToString().Trim());
        ht.Add("@CycDt1", lblFromDtVal.Text.ToString().Trim());
        ht.Add("@CycDt2", lblToDtVal.Text.ToString().Trim());
        ds11 = objDal.GetDataSetForPrc_SAIM("Prc_GetLOBPremAmt", ht);
        if (ds11.Tables != null)
        {
            if (ds11.Tables[0].Rows.Count > 0)
            {
                dtLOB = ds11.Tables[0];
            }
            else
            {
                ds11 = null;
            }
        }
        else
        {
            ds11 = null;
        }
        brChart.DataSource = dtLOB;
        brChart.DataBind();

        PolChrt.DataSource = dtLOB;
        PolChrt.DataBind();
    }

    protected void FillStatSumMem(string memcode)
    {
        DataSet dsMem = new DataSet();
        Hashtable htMem = new Hashtable();

        htMem.Clear();
        htMem.Add("@MemCode", memcode.ToString().Trim());
        dsMem = objDal.GetDataSetForPrc_SAIM("Prc_GetMemDtlsStatSum", htMem);
        if (dsMem.Tables != null)
        {
            if (dsMem.Tables[0].Rows.Count > 0)
            {
                lblMemNmVal.Text = dsMem.Tables[0].Rows[0]["MemberName"].ToString().Trim();
                lblMemCodeVal.Text = dsMem.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                lblEmailVal.Text = dsMem.Tables[0].Rows[0]["EmailID"].ToString().Trim();
                lblMobDtlVal.Text = dsMem.Tables[0].Rows[0]["MobileNo"].ToString().Trim();
                lblBizSrVal.Text = dsMem.Tables[0].Rows[0]["Channel"].ToString().Trim();
                lblChnClsVal.Text = dsMem.Tables[0].Rows[0]["SubClass"].ToString().Trim();
                lblMemTypVal.Text = dsMem.Tables[0].Rows[0]["MemType"].ToString().Trim();
                lblSapCdVal.Text = dsMem.Tables[0].Rows[0]["SapCode"].ToString().Trim();
                ////lblFromDtVal.Text = Convert.ToDateTime(dsMem.Tables[0].Rows[0]["CycDtFrm"].ToString().Trim()).ToShortDateString().ToString().Trim();
                /////lblToDtVal.Text = Convert.ToDateTime(dsMem.Tables[0].Rows[0]["CycDtTo"].ToString().Trim()).ToShortDateString().ToString().Trim();
            }
        }
    }

    protected void ShowCompType()
    {
        int row = 2;

        int col = 3;

        for (int i = 0; i < row; i++)
        {
            HtmlTableRow rows = new HtmlTableRow();
            for (int j = 0; j < col; j++)
            {
                HtmlTableCell cell = new HtmlTableCell();
                Telerik.Web.UI.RadButton rad = new Telerik.Web.UI.RadButton();
                cell.Controls.Add(rad);
                cell.Align = "Center";
                cell.BorderColor = "Gray";
                rows.Cells.Add(cell);
                tblCompType.Rows.Add(rows);
            }
        }
    }

    protected void lnkStatSumm_Click(object sender, EventArgs e)
    {
        MVwStat.ActiveViewIndex = 0;
        LoadGrid();
        BindPie();
        dt.Clear();
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "Pay")
            {
                if (Request.QueryString["MemCode"] != null)
                {
                    if (Request.QueryString["MemCode"].ToString().Trim() != "")
                    {
                        FillStatSumMem(Request.QueryString["MemCode"].ToString().Trim());
                    }
                }
            }
        }
    }

    protected void lnkStmtDtls_Click(object sender, EventArgs e)
    {
        MVwStat.ActiveViewIndex = 1;
        tblMnCht.Visible = false;
        ////ShowCompType();
    }

    protected void lnkVwPolicy_Click(object sender, EventArgs e)
    {
        MVwStat.ActiveViewIndex = 2;
        tblChart.Visible = false;
    }

    protected void lnkPrintVer_Click(object sender, EventArgs e)
    {
        MVwStat.ActiveViewIndex = 3;
    }

    protected void radCompFCP_Click(object sender, EventArgs e)
    {
        tblAch.Visible = true;
        lblcurrptsVal.Text = hdnCommPts.Value.ToString().Trim();
        GetAch();
        cmptype = "FCP";
        RadGrid1.DataSource = GetMonthDetails(DBNull.Value.ToString());
        RadGrid1.DataBind();
    }

    protected void radCompACP_Click(object sender, EventArgs e)
    {
        tblAch.Visible = true;
        lblcurrptsVal.Text = hdnCommPts.Value.ToString().Trim();
        GetAch();
        cmptype = "ACP";
    }

    protected void GetAch()
    {
        ht = new Hashtable();
        ds = new DataSet();
        ht.Add("@CommPts", hdnCommPts.Value.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAchievements", ht);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCurrClubVal.Text = ds.Tables[0].Rows[0]["ClubDesc"].ToString().Trim();
                    lblClubRng.Text = ds.Tables[0].Rows[0]["MinVal"].ToString().Trim() + "-" + ds.Tables[0].Rows[0]["MaxVal"].ToString().Trim();
                }
                else
                {
                    ds = null;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblNxtClubVal.Text = ds.Tables[1].Rows[0]["NxtClubDesc"].ToString().Trim();
                    lblNxtClubRng.Text = ds.Tables[1].Rows[0]["NxtMinVal"].ToString().Trim() + "-" + ds.Tables[1].Rows[0]["NxtMaxVal"].ToString().Trim();
                }
                else
                {
                    ds = null;
                }
            }

        }
    }

    protected void RadGrid1_DetailTableDataBind(object sender, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
        switch (e.DetailTableView.Name)
        {
            case "MonthDetails":
                {
                    string MonthID = dataItem.GetDataKeyValue("Mth").ToString();
                    e.DetailTableView.DataSource = GetMonthDetails(MonthID.ToString().Trim());
                    break;
                }
        }
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            RadGrid1.DataSource = GetMonthDetails(DBNull.Value.ToString());
            RadGrid1.DataBind();
        }
    }

    protected DataSet GetMonthDetails(string month)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@MemCode", lblMemCodeVal.Text.ToString().Trim());
        ht.Add("@CompType", cmptype.ToString().Trim());
        if (month != null)
        {
            if (month != String.Empty)
            {
                ht.Add("@Mth", month.ToString().Trim());
            }
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_MthWisePoints", ht);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            else
            {
                ds = null;
            }
        }
        return ds;
    }

    protected void BindPie()
    {
        dt = new DataTable();
        dt = BindGrid();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            DataPoint oDataPoint = new DataPoint(0, double.Parse(dr["CurrentMonth"].ToString()));
            oDataPoint.LegendText = dr["Type"].ToString();
            Chart1.Series["Default"].Points.Add(oDataPoint);

            /////Chart1.Series["Default"].Points[i]["Exploded"] = "true";
            i++;
        }

        Chart1.Series["Default"]["PointWidth"] = "1.5";
        Chart1.Series["Default"]["DrawingStyle"] = "Cylinder";
        Chart1.Series["Default"].Font = new System.Drawing.Font("Calibri", 7, System.Drawing.FontStyle.Regular);
        Chart1.Series["Default"].LegendText = "#VALX";

        Chart1.ChartAreas["MainArea"].InnerPlotPosition.Width = 40;
        Chart1.ChartAreas["MainArea"].InnerPlotPosition.Height = 98;
        Chart1.ChartAreas["MainArea"].InnerPlotPosition.X = 25;
        Chart1.ChartAreas["MainArea"].InnerPlotPosition.Y = 1;

    }

    protected DataTable VwPolGrid()
    {
        ds = new DataSet();
        ht = new Hashtable();
        dt = new DataTable();
        ds.Clear();
        ht.Clear();
        ht.Add("@MemCode", lblMemCodeVal.Text.ToString().Trim());
        if (txtFrmDt.Text != "")
        {
            ht.Add("@CycDt1", txtFrmDt.Text.ToString().Trim());
        }
        else
        {
            ht.Add("@CycDt1", System.DBNull.Value);
        }
        if (txtToDt.Text != "")
        {
            ht.Add("@CycDt2", txtToDt.Text.ToString().Trim());
        }
        else 
        {
            ht.Add("@CycDt2", System.DBNull.Value);    
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetPolDtls", ht);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    return dt;
                }
                else
                {
                    dt = null;
                }
            }
            else
            {
                dt = null;
            }
        }
        else
        {
            dt = null;
        }
        return dt;
    }
    
    protected void btnSrchPol_Click(object sender, EventArgs e)
    {
        dgPol.DataSource = VwPolGrid();
        dgPol.DataBind();
    }
    protected void dgPol_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = VwPolGrid();
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
    protected void dgPol_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = VwPolGrid();
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

    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = dgPol.PageIndex + 1;
        /////lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgPol.PageCount;
    }
    #endregion
    protected void rdgrdCyc_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        ////LoadGrid();
    }
    protected void rdgrdCyc_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        LoadGrid();
    }
    protected void rdgrdCyc_SortCommand(object sender, GridSortCommandEventArgs e)
    {
        LoadGrid();
    }
    protected void rdgrdCyc_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    {
        LoadGrid();
    }

    protected void LoadGrid()
    {
        DataTable dt = BindGrid();
        rdgrdCyc.DataSource = dt;
        rdgrdCyc.DataBind();
    }
    protected void rdgrdCyc_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)// gets the row collection  
        {
            GridDataItem item = e.Item as GridDataItem;
            Label Type = item.FindControl("lblType") as Label;
            Image imgType = item.FindControl("imgType") as Image;
            if (Type.Text == "Commission")
            {
                imgType.ImageUrl = "../../../images/comm1.png";
            }
            if (Type.Text == "Bonus Amount")
            {
                imgType.ImageUrl = "../../../images/bonus1.png";
            }
            if (Type.Text == "Points/Rewards")
            {
                imgType.ImageUrl = "../../../images/points1.png";
            }
            if (Type.Text == "Miscellaneous")
            {
                imgType.ImageUrl = "../../../images/misc1.png";
            }
            Type.Text = Type.Text.ToUpper().ToString().Trim();
        }  
    }
    protected void btnSrcDt_Click(object sender, EventArgs e)
    {
        pnlStat.Visible = true;
        tblMnCht.Visible = true;
        tblcht.Visible = true;
        LoadGrid();
        BindPie();
        FillLOBCht();
    }
}
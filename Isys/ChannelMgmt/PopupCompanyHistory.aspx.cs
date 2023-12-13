//Creator:		    <Ajay Yadav> 
//Create date:      <10th Sep 2021>
//Description:	    <This page is created for a comon serach history.>

#region Namespaces
using System;
using System.Collections;
#endregion

public partial class Application_Isys_ChannelMgmt_PopupCompanyHistory : Base
{
    #region Global declaration
    string bizsrc = "";
    string Flag = "";
    #endregion

    #region Page Load ()
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bizsrc = Request.QueryString["Code"].ToString();
            lblhdr1.Text = Request.QueryString["Header"].ToString();
            Flag= Request.QueryString["Flag"].ToString();
            DivGrid.Visible = false;
            DivSubChnl.Visible = false;
            DivMemType.Visible = false;
            DivUnitType.Visible = false;
            divUnitRank.Visible = false;
            if (!IsPostBack)
            {
                fillFinyr();
            }
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopupCompanyHistory.aspx", "Page_Load", ex);
        }
    }
    #endregion

    #region GridBind of history table
    public void grid_Bind()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            FillddlcheckNull(ddlFinYr, htParam, "@Period", ddlFinYr.SelectedValue.ToString());
            FillrbcheckNull(rdMode, htParam, "@ModMode", rdMode.SelectedValue);
            htParam.Add("@Bizsrc", bizsrc);
            if (Flag == "CHANNEL")
            {
                FillGridView(htParam, gvhistory, "PRC_GET_CHNSUHST", "INSCCommonConnectionString");
                DivGrid.Visible = true;
            }
            if (Flag == "COMPANY")
            {
                FillGridView(htParam, gvhistory, "PRC_GET_CMPSUHST", "INSCCommonConnectionString");
                DivGrid.Visible = true;
            }
            if (Flag == "SUBCHANNEL")
            {
                FillGridView(htParam, gvSubChnl, "PRC_GET_CHNCLSSUHST", "INSCCommonConnectionString");
                DivSubChnl.Visible = true;
            }
            if (Flag == "MEMTYPE")
            {
                FillGridView(htParam, gvMemType, "PRC_GET_CHNMEMSUHST", "INSCCommonConnectionString");
                DivMemType.Visible = true;
            }
            if (Flag == "UnitRank")
            {
                FillGridView(htParam, gvHistoryUntRnk, "PRC_GET_CHNUNTRNKSUHST", "INSCCommonConnectionString");
                divUnitRank.Visible = true;
            }
            if (Flag == "UNITYPE")
            {
                FillGridView(htParam, gvUnitType, "PRC_GET_CHNUNTSUHST", "INSCCommonConnectionString");
                DivUnitType.Visible = true;
            }
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopupCompanyHistory.aspx", "grid_Bind", ex);
        }
    }
    #endregion

    #region Search Button  Event ()
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            grid_Bind();
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "CompanySetup.aspx", "btnSearch_Click", ex);
        }
    }
    #endregion

    # region Filling  the Period (financial year) dropdown based on master business year setup
    protected void fillFinyr()
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Clear();
            ht.Add("@flag", "N");
            FillDropDowns(ddlFinYr, "Prc_get_Current_FinYear", ht, "INSCCommonConnectionString", "", true, "flagN");
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "CompanySetup.aspx", "fillFinyr", ex);
        }
    }
    #endregion

}
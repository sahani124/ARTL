//-- =============================================
//-- Author:        Goh Yuen Fei
//-- Create date:   01/05/2007
//-- Description:   create,edit and delete Multilingual Setup
//-- =============================================

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
using Insc.Common.Data;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;

public partial class Application_Admin_SysModule : BaseClass
{
    private multilingualManager olng;
    CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        string strUserLang;
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "SysModule.aspx", strUserLang);

        GridView1.PageSize = int.Parse(cboShowRecord.Text);
        if (!IsPostBack)
        {
            InitializeControl();
            SearchParameter(0);
        }
    }

    private void InitializeControl()
    {
        lblModVer.Text = olng.GetItemDesc("lblModVer.Text");
        lblTitle.Text = olng.GetItemDesc("lblTitle.Text");
        lblSearch.Text = olng.GetItemDesc("lblSearch.Text");
        lblContains.Text = olng.GetItemDesc("lblContains.Text");
        lblShowRecords.Text = olng.GetItemDesc("lblShowRecords.Text");
        lblSearchResult.Text = olng.GetItemDesc("lblSearchResult.Text");
        btnSearchAdv.Text = olng.GetItemDesc("lblSearch.Text");
        btnHClear.Text = olng.GetItemDesc("btnHClear.Value");
        oCommon.getDropDown(ddlSearchCol, "MODULE", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
        
    }

    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            mv1.ActiveViewIndex = 0;
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        mv1.ActiveViewIndex = 0;
    }
    protected void linkAddNew_Click(object sender, EventArgs e)
    {
        mv1.ActiveViewIndex = 1;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchParameter(e.NewPageIndex);
    }

    protected void btnSearchAdv_Click(object sender, EventArgs e)
    {
        SearchParameter(0);
    }

    protected void ddlSearchCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        SearchParameter(0);
    }

    public void SearchParameter(int intPageIndex)
    {
        GridView1.PageSize = int.Parse(cboShowRecord.Text);
        GridView1.PageIndex = intPageIndex;
        GridView1.DataBind();

        GridView1.Columns[0].HeaderText = olng.GetItemDesc("Gcol1");
        GridView1.Columns[1].HeaderText = olng.GetItemDesc("Gcol2");
        GridView1.Columns[2].HeaderText = olng.GetItemDesc("Gcol3");
        GridView1.Columns[3].HeaderText = olng.GetItemDesc("Gcol4");
        GridView1.Columns[4].HeaderText = olng.GetItemDesc("Gcol5");
        GridView1.Columns[5].HeaderText = olng.GetItemDesc("Gcol6");
        GridView1.Columns[6].HeaderText = olng.GetItemDesc("Gcol7");
        GridView1.Columns[7].HeaderText = olng.GetItemDesc("Gcol8");
        GridView1.Columns[8].HeaderText = olng.GetItemDesc("Gcol9");
        GridView1.Columns[9].HeaderText = olng.GetItemDesc("Gcol10");
        GridView1.Columns[10].HeaderText = olng.GetItemDesc("Gcol11");
        GridView1.Columns[11].HeaderText = olng.GetItemDesc("Gcol12");
        GridView1.Columns[12].HeaderText = olng.GetItemDesc("Gcol13");
        GridView1.Columns[13].HeaderText = olng.GetItemDesc("Gcol14");
        GridView1.Columns[14].HeaderText = olng.GetItemDesc("Gcol15");
        GridView1.Columns[15].HeaderText = olng.GetItemDesc("Gcol16");
        

        //display no. of page
        lblPageIndex.Text = "";
        int page = GridView1.PageIndex + 1;

        if (GridView1.Rows.Count < 1)
        {
            lblPageIndex.Text = "";
        }
        else
            lblPageIndex.Text = olng.GetItemDesc("Page.Text") + " " + page + " " + olng.GetItemDesc("of.Text") + " " + GridView1.PageCount.ToString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            if (LinkButton1!=null)
                LinkButton1.Text = olng.GetItemDesc("lblEdit.Text");
        }
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv != null)
        {
            if (gv.EditIndex > -1)
            {
                // validation for Grid View

                RequiredFieldValidator RFVModuleName2_1 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RFVModuleName2_1") as RequiredFieldValidator;
                RFVModuleName2_1.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
                RequiredFieldValidator RFVModuleDesc2_1 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RFVModuleDesc2_1") as RequiredFieldValidator;
                RFVModuleDesc2_1.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
                RequiredFieldValidator RFVModuleSequence2 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RFVModuleSequence2") as RequiredFieldValidator;
                RFVModuleSequence2.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
                RangeValidator RVtxtModuleSequence2 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RVtxtModuleSequence2") as RangeValidator;
                RVtxtModuleSequence2.ErrorMessage = olng.GetItemDesc("lblRV_int.Text");
                RequiredFieldValidator RFVModuleStatus2 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RFVModuleStatus2") as RequiredFieldValidator;
                RFVModuleStatus2.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
                RangeValidator RVModuleStatus2 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RVModuleStatus2") as RangeValidator;
                RVModuleStatus2.ErrorMessage = olng.GetItemDesc("lblRV_smallint.Text");
                LinkButton LinkButton1 = (LinkButton)gv.Rows[gv.EditIndex].Controls[0].FindControl("LnkUpdate");
                LinkButton1.Text = olng.GetItemDesc("lblUpdate.Text");
                LinkButton LinkButton2 = (LinkButton)gv.Rows[gv.EditIndex].Controls[0].FindControl("LnkCancel");
                LinkButton2.Text = olng.GetItemDesc("lblCancel.Text");

            }
        }
    }

    protected void DetailsView1_PreRender(object sender, EventArgs e)
    {
        RequiredFieldValidator RFVModuleID = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleID");
        RFVModuleID.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RangeValidator RVModuleID = (RangeValidator)DetailsView1.FindControl("RVModuleID");
        RVModuleID.ErrorMessage = olng.GetItemDesc("lblRV_int.Text");
        RequiredFieldValidator RFVModuleCode = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleCode");
        RFVModuleCode.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RequiredFieldValidator RFVRootModuleID = (RequiredFieldValidator)DetailsView1.FindControl("RFVRootModuleID");
        RFVRootModuleID.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RangeValidator RVRootModuleID = (RangeValidator)DetailsView1.FindControl("RVRootModuleID");
        RVRootModuleID.ErrorMessage = olng.GetItemDesc("lblRV_int.Text");
        RequiredFieldValidator RFVModuleName = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleName");
        RFVModuleName.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RequiredFieldValidator RFVModuleName1 = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleName1");
        RFVModuleName1.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RequiredFieldValidator RFVModuleDesc1 = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleDesc1");
        RFVModuleDesc1.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RequiredFieldValidator RFVModuleSequence = (RequiredFieldValidator)DetailsView1.FindControl("RFVModuleSequence");
        RFVModuleSequence.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RangeValidator RVModuleSequence = (RangeValidator)DetailsView1.FindControl("RVModuleSequence");
        RVModuleSequence.ErrorMessage = olng.GetItemDesc("lblRV_int.Text");
        RequiredFieldValidator RFVCarrierCode = (RequiredFieldValidator)DetailsView1.FindControl("RFVCarrierCode");
        RFVCarrierCode.ErrorMessage = olng.GetItemDesc("lblRFV.Text");

    }
    protected void cboShowRecord_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        SearchParameter(0);
    }


    protected void btnnextfin_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridView1.PageIndex;
            GridView1.PageIndex = pageIndex + 1;
           // Search("S", "FY", GridView1);
            txtPageFin.Text = Convert.ToString(Convert.ToInt32(txtPageFin.Text) + 1);
            btnprevfin.Enabled = true;
            if (txtPageFin.Text == Convert.ToString(GridView1.PageCount))
            {
                btnnextfin.Enabled = false;
            }

            int page = GridView1.PageCount;
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

    protected void btnprevfin_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridView1.PageIndex;
            GridView1.PageIndex = pageIndex - 1;
            //Search("S", "FY", GridView1);
            txtPageFin.Text = Convert.ToString(Convert.ToInt32(txtPageFin.Text) - 1);
            if (txtPageFin.Text == "1")
            {
                btnprevfin.Enabled = false;
            }
            else
            {
                btnprevfin.Enabled = true;
            }
            btnnextfin.Enabled = true;
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

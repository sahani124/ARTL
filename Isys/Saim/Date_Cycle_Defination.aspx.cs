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
using AjaxControlToolkit;

public partial class Application_ISys_Saim_Date_Cycle_Defination : BaseClass
{
    #region Declaration
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        try { 
      //  ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
       // SetInitialRow();
        if (!Page.IsPostBack)
        {
            
            //Page.AutoPostBackControl = this.Page;
            txtnofpart.Focus();
            divpagination.Visible = false;
            tblsave.Visible = false;
            btnadd.Visible = false;


            if (Request.QueryString["effdatefrom"] != null)
            {
                hdnEffFrm.Value = Request.QueryString["effdatefrom"].ToString().Trim();
            }


            if (Request.QueryString["effdateto"] != null)
            {
                hdnEffTo.Value = Request.QueryString["effdateto"].ToString().Trim();
            }
            //ShowNoResultFound(dt, dgcycle);
            //DataTable dt = new DataTable();
            //dgcycle.DataSource = dt;
            //dgcycle.DataBind();
            ///ShowNoResultFound(dt, dgcycle);
            SetInitialRow();
            //FillCycle();
            if (Request.QueryString["cmpcode"] != null)
            {
                lblCmpCode.Text = Request.QueryString["cmpcode"].ToString().Trim();
            }
            if (txtnofpart.Text.Trim() == "")
            {
                EmptydgCycle(dgcycle);
                //dgcycle.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                //dgcycle.Rows[0].Cells[1].Text = "";
                //dgcycle.Rows[0].Cells[2].Text = "";
                //dgcycle.Rows[0].Cells[3].Text = "";
                //dgcycle.Rows[0].Cells[4].Text = "";
                //dgcycle.Rows[0].Cells[5].Text = "";
                //dgcycle.Rows[0].Cells[0].Text = "No Cycles have been defined";
                
            }
            Deletedata();
            binddata();
        }
        //Temp

        //----end
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //For Edit Mode Bind Data

    public void Deletedata()
    {
        try { 
        ds.Clear();
        htParam.Clear();

        htParam.Add("@CMP_CODE", lblCmpCode.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_Delete_cycle", htParam);
       
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "Deletedata", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void binddata()
    {
        try { 
        ds.Clear();
        htParam.Clear();

        htParam.Add("@CMP_CODE", lblCmpCode.Text.ToString().Trim());
        htParam.Add("@RuleSetCode", Request.QueryString["rulesetcode"].ToString().Trim());
        
       
        ds = objDal.GetDataSetForPrc_SAIM("Prc_Getdata", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            grdshowcycle.DataSource = ds.Tables[0];
            grdshowcycle.DataBind();
            btnSaveHyr.Visible = true;
            btnCncel.Visible = true;
            tblpagination.Visible = true;
            divpagination.Visible = true;
            tblsave.Visible = true;
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], grdshowcycle);
            btnSaveHyr.Visible = true;
            btnSaveHyr.Enabled = false;
            btnCncel.Visible = true;
            tblpagination.Visible = true;
            divpagination.Visible = true;
            tblsave.Visible = true;
        }
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "binddata", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void GetData()
    {
        try { 
        DataTable dt = new DataTable();
        if (ViewState["CurrentTable"] != null)

            //dt = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add("SEQNO");
        dt.Columns.Add("MTH_CODE");
        dt.Columns.Add("MTH_NAME");
        dt.Columns.Add("START_DATE");
        dt.Columns.Add("END_DATE");
        dt.Columns.Add("PARENT_BUSI_CODE");

        for (int intRowCount = 0; intRowCount <= dgcycle.Rows.Count - 1; intRowCount++)
        {
            DataRow dr = dt.NewRow();

            Label lblseqno = (Label)dgcycle.Rows[intRowCount].Cells[0].FindControl("lblseqno");
            dr["SEQNO"] = lblseqno.Text.ToString().Trim();

            Label lblMthCode = (Label)dgcycle.Rows[intRowCount].Cells[0].FindControl("lblMthCode");
            dr["MTH_CODE"] = lblMthCode.Text.ToString().Trim();
            TextBox txtcydsc = (TextBox)dgcycle.Rows[intRowCount].Cells[1].FindControl("txtcydsc");
            dr["MTH_NAME"] = txtcydsc.Text.ToString().Trim();
            TextBox txtStrtDt = (TextBox)dgcycle.Rows[intRowCount].Cells[2].FindControl("txtStrtDt");
            dr["START_DATE"] = txtStrtDt.Text.ToString().Trim();
            TextBox txtEndDt = (TextBox)dgcycle.Rows[intRowCount].Cells[3].FindControl("txtEndDt");
            dr["END_DATE"] = txtEndDt.Text.ToString().Trim();
            Label lblparcode = (Label)dgcycle.Rows[intRowCount].Cells[4].FindControl("lblparcode");
            dr["PARENT_BUSI_CODE"] = lblparcode.Text.ToString().Trim();
            dt.Rows.Add(dr);
        }
        ViewState["CurrentTable1"] = dt;
        grdshowcycle.DataSource = dt;
        grdshowcycle.DataBind();       
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "GetData", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try{
        int cnt = 0;
        for (int i = 0; i < dgcycle.Rows.Count; i++)
        {
            TextBox txtcydsc = (TextBox)dgcycle.Rows[i].Cells[1].FindControl("txtcydsc");
            TextBox txtStrtDt = (TextBox)dgcycle.Rows[i].Cells[2].FindControl("txtStrtDt");
            TextBox txtEndDt = (TextBox)dgcycle.Rows[i].Cells[3].FindControl("txtEndDt");

            if (txtcydsc.Text.Trim() == "")
            {
                EmptydgCycle(grdshowcycle);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter cycle description');", true);
                return;
            }
            if (txtStrtDt.Text.Trim() == "")
            {
                EmptydgCycle(grdshowcycle);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter start date');", true);
                return;
            }
            if (txtEndDt.Text.Trim() == "")
            {
                EmptydgCycle(grdshowcycle);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter end date');", true);
                return;
            }
            cnt = cnt + 1;
        }
        if (cnt == dgcycle.Rows.Count)
        {
            for (int i = 0; i < dgcycle.Rows.Count; i++)
            {
                TextBox txtcydsc = (TextBox)dgcycle.Rows[i].Cells[1].FindControl("txtcydsc");
                TextBox txtStrtDt = (TextBox)dgcycle.Rows[i].Cells[2].FindControl("txtStrtDt");
                TextBox txtEndDt = (TextBox)dgcycle.Rows[i].Cells[3].FindControl("txtEndDt");

                var startdt = Convert.ToDateTime(txtStrtDt.Text);
                var enddt = Convert.ToDateTime(txtEndDt.Text);

                if (startdt > enddt)
                {
                    EmptydgCycle(grdshowcycle);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('End date should be greater then Start date');", true);
                    return;
                }

                int rc = dgcycle.Rows.Count;

                for (int a = 0; a < rc; a++)
                {
                    if (a != 0)
                    {
                        --a;
                        TextBox tmpEndDt = (TextBox)dgcycle.Rows[a].Cells[3].FindControl("txtEndDt");
                        ++a;
                        TextBox tmpstartdt = (TextBox)dgcycle.Rows[a].Cells[2].FindControl("txtStrtDt");
                        var tmstartdt = Convert.ToDateTime(tmpstartdt.Text);
                        var tmenddt = Convert.ToDateTime(tmpEndDt.Text);
                        if ((tmenddt > tmstartdt) || (tmenddt >= tmstartdt))
                        {
                            EmptydgCycle(grdshowcycle);
                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Incorrect dates of Parts');", true); changes done by mrunal on 03/04/18
                           // return;

                        }
                    }
                }
            }   
        }

        tblpagination.Visible = true;
        divpagination.Visible = true;
        tblsave.Visible = true;
        GetData();

        SetInitialRow();
        pnl.Visible = false;
        txtnofpart.Text = "";
        btnSaveHyr.Enabled = true;
        EmptydgCycle(dgcycle);
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "btnadd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void EmptydgCycle(GridView gv)
    {
        try { 
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[1].Text = "";
        gv.Rows[0].Cells[2].Text = "";
        gv.Rows[0].Cells[3].Text = "";
        gv.Rows[0].Cells[4].Text = "";
        gv.Rows[0].Cells[5].Text = "";
        gv.Rows[0].Cells[0].Text = "No Cycles have been defined";
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "EmptydgCycle", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void SetInitialRow()
    {
        try { 
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SEQNO", typeof(string)));
        dt.Columns.Add(new DataColumn("MTH_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("MTH_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("START_DATE", typeof(string)));
        dt.Columns.Add(new DataColumn("END_DATE", typeof(string)));
        dt.Columns.Add(new DataColumn("PARENT_BUSI_CODE", typeof(string)));
        dr = dt.NewRow();
        dr["SEQNO"] = string.Empty;
        dr["MTH_CODE"] = string.Empty;
        dr["MTH_NAME"] = string.Empty;
        dr["START_DATE"] = string.Empty;
        dr["END_DATE"] = string.Empty;
        dr["PARENT_BUSI_CODE"] = string.Empty;

        ViewState["CurrentTable"] = dt;
        dt.Rows.Clear();
        ShowNoResultFound(dt, dgcycle);
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "SetInitialRow", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void txtnofpart_TextChanged(object sender, EventArgs e)
    {
        try { 
        if (txtnofpart.Text.Trim() == "")
        {
            EmptydgCycle(dgcycle);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter parts of month');", true);
            return;
        }
        if (txtnofpart.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter valid parts of month');", true);
            return;
        }

        if (Convert.ToInt32(txtnofpart.Text) <= 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Parts of month should grether than zero');", true);
            return;
        }

        btnadd.Enabled = true;
        dgcycle.DataSource = null;
        dgcycle.DataBind();
        int norow = Convert.ToInt32(txtnofpart.Text);
        AddNewRowToGrid(norow);
        btnadd.Visible = true;
        lblshow.Text = " Please enter the cycle sequentially from top to bottom";
    
        //Extra added
        grdshowcycle.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        grdshowcycle.Rows[0].Cells[1].Text = "";
        grdshowcycle.Rows[0].Cells[2].Text = "";
        grdshowcycle.Rows[0].Cells[3].Text = "";
        grdshowcycle.Rows[0].Cells[4].Text = "";
        grdshowcycle.Rows[0].Cells[5].Text = "";
        grdshowcycle.Rows[0].Cells[0].Text = "No Cycles have been defined";
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "txtnofpart_TextChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void AddNewRowToGrid(int norow)
    {
        try { 
        int rowIndex = 0;
        //for (int a = 1; a <= norow - 1; a--)
        //{
        dgcycle.DataSource = null;
        dgcycle.DataBind();
        
        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            
            DataRow drCurrentRow = null;
         
            for (int i = 1; i <= norow; i++)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                dtCurrentTable.Rows.Add(drCurrentRow);
             
                drCurrentRow["PARENT_BUSI_CODE"] = "NULL";
             
            }
            dgcycle.DataSource = dtCurrentTable;
            dgcycle.DataBind();
            FillCycle();
            Session["grdbind"] = dtCurrentTable;
            }
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "AddNewRowToGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSaveHyr_Click(object sender, EventArgs e)
    {
        try { 
        string msg = string.Empty;
        Hashtable htParam = new Hashtable();
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();

        List<string> lstlblMthCode = new List<string>();
        List<string> lsttxtcydsc = new List<string>();
        List<string> lsttxtStrtDt = new List<string>();
        List<string> lsttxtEndDt = new List<string>();
        List<string> lstlblparcode = new List<string>();

        for (int intRowCount = 0; intRowCount < grdshowcycle.Rows.Count; intRowCount++)
        {
            
            Label lblMthCode = (Label)grdshowcycle.Rows[intRowCount].Cells[0].FindControl("lblMthCode");
            lstlblMthCode.Add(lblMthCode.Text.ToString().Trim());

            Label txtcydsc = (Label)grdshowcycle.Rows[intRowCount].Cells[1].FindControl("txtcydsc");
            lsttxtcydsc.Add(txtcydsc.Text.ToString().Trim());

            Label txtStrtDt = (Label)grdshowcycle.Rows[intRowCount].Cells[2].FindControl("txtStrtDt");
            lsttxtStrtDt.Add(txtStrtDt.Text.ToString().Trim());

            Label txtEndDt = (Label)grdshowcycle.Rows[intRowCount].Cells[3].FindControl("txtEndDt");
            lsttxtEndDt.Add(txtEndDt.Text.ToString().Trim());

            Label lblparcode = (Label)grdshowcycle.Rows[intRowCount].Cells[4].FindControl("lblparcode");
            lstlblparcode.Add(lblparcode.Text.ToString().Trim());
        }
        for (int intDataCount = 0; intDataCount < lstlblMthCode.Count; intDataCount++)
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@BUSI_CODE", lstlblMthCode[intDataCount].ToString());
            htParam.Add("@BUSI_DESC", lsttxtcydsc[intDataCount].ToString().Trim());
            htParam.Add("@START_DATE", lsttxtStrtDt[intDataCount].ToString().Trim());
            htParam.Add("@END_DATE", lsttxtEndDt[intDataCount].ToString().Trim());
            if (Request.QueryString["cyctype"] != "")
            {
                htParam.Add("@CYCLE_TYPE", Request.QueryString["cyctype"].ToString().Trim());
            }
            if (Request.QueryString["yrtyp"] != "")
            {
                htParam.Add("@YEAR_TYPE", Request.QueryString["yrtyp"].ToString().Trim());
            }
            htParam.Add("@PARENT_BUSI_CODE", lstlblparcode[intDataCount].ToString().Trim());
            htParam.Add("@ROOT_BUSI_CODE", Request.QueryString["BUSI_YEAR"].ToString());
            htParam.Add("@CMP_CODE", lblCmpCode.Text.ToString().Trim());
            htParam.Add("@CntstCode", Request.QueryString["cntstcode"].ToString().Trim());

            htParam.Add("@RuleSetCode", Request.QueryString["rulesetcode"].ToString().Trim());

            

            htParam.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMST_BUSI_YR", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["RESULT"].ToString().Trim();

                if (msg == "UNSUCCESS")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Already Exist Data');", true);


                }
                //else
                //{
                //    lblsuccess.Text = "";
                //    SetInitialRow();
                //    pnl.Visible = true;
                //    lbl3.Text = "Cycles Saved Successfully";
                //    lblsuccess.Text = "Compensation Code :" + lblCmpCode.Text;
                //    mdlpopup.Show();

                //}
            }
        }

        SetInitialRow();
        pnl.Visible = true;
        lbl3.Text = "Cycles Saved Successfully";
        lblsuccess.Text = "Compensation Code :" + lblCmpCode.Text;
 ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        mdlpopup.Show();
        EmptydgCycle(dgcycle);
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "btnSaveHyr_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillCycle()
    {
        try {
            DataSet dsNextCycle = new DataSet();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BUSI_CODE");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string strmsg = string.Empty;
            int strseq = 1;
            strmsg = ds.Tables[0].Rows[0]["BUSI_CODE"].ToString().Trim();
         
            for (int i = 0; dgcycle.Rows.Count > i; i++)
            {
                Label lblMthCode = (Label)dgcycle.Rows[i].FindControl("lblMthCode");
                Label lblseqno = (Label)dgcycle.Rows[i].FindControl("lblseqno");
               
                dsNextCycle.Clear();

                dsNextCycle = objDal.GetDataSetForPrc_SAIM("Prc_BUSI_CODE");

                lblMthCode.Text = dsNextCycle.Tables[0].Rows[0]["BUSI_CODE"].ToString().Trim();

               // strmsg = (Convert.ToInt32(strmsg) + 1).ToString().Trim();
                lblseqno.Text = strseq.ToString();
                strseq = strseq + 1;
            }
            for (int i = 0; dgcycle.Rows.Count > i; i++)
            {
                TextBox txtdatefrom = (TextBox)dgcycle.Rows[0].Cells[1].FindControl("txtStrtDt");
                TextBox txtdateto = (TextBox)dgcycle.Rows[dgcycle.Rows.Count - 1].Cells[2].FindControl("txtEndDt");

                //CalendarExtender cal1 = (CalendarExtender)dgcycle.Rows[0].Cells[1].FindControl("CETXStrDt");
                //CalendarExtender cal2 = (CalendarExtender)dgcycle.Rows[dgcycle.Rows.Count - 1].Cells[2].FindControl("CETXEndDt");
                txtdatefrom.Text = hdnEffFrm.Value;
                txtdatefrom.Enabled = false;
                txtdateto.Text = hdnEffTo.Value;
                txtdateto.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "FillCycle", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        try { 
        source.Rows.Add(source.NewRow());

        gv.DataSource = source;
        gv.DataBind();

        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[columnsCount - 3].Text = "";
        gv.Rows[0].Cells[columnsCount - 4].Text = "";
        gv.Rows[0].Cells[columnsCount - 5].Text = "";
        gv.Rows[0].Cells[0].Text = "No Cycles have been defined";
        source.Rows.Clear();
    }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try { 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    //////button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
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
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "OnRowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void grdshowcycle_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try { 
        string msg = string.Empty;

        Label lblMthCode = (Label)grdshowcycle.Rows[e.RowIndex].FindControl("lblMthCode");
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["CurrentTable1"] as DataTable;
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                dt.Rows[index].Delete();
                grdshowcycle.DataSource = dt;
                grdshowcycle.DataBind();
                if (dt.Rows.Count == 0)
                {
                    binddata();
                }
            }

            else
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@cmp_code", lblCmpCode.Text.ToString().Trim());
                htParam.Add("@BUSI_CODE", lblMthCode.Text.ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCycleDtls", htParam);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    msg = ds.Tables[0].Rows[0]["RESULT"].ToString().Trim();

                    if (msg == "FAILED")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the cycle. Target is assigned to this cycle.');", true);
                    }
                    else
                    {


                    }
                }
                binddata();
            }
        }
        else
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@BUSI_CODE", lblMthCode.Text.ToString().Trim());
            htParam.Add("@cmp_code", lblCmpCode.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCycleDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["RESULT"].ToString().Trim();

                if (msg == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the cycle. Target is assigned to this cycle.');", true);
                }
                else
                {


                }
            }
            binddata();
        }
        EmptydgCycle(dgcycle);
        }
        catch (Exception ex)
        {
          //  string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
          //  System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
          //  string sRet = oInfo.Name;
          //  System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
          //  String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Date_Cycle_Defination", "grdshowcycle_OnRowDeleting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void grdshowcycle_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
       
    //    Label lblMthCode = (Label)grdshowcycle.Rows[e.RowIndex].FindControl("lblMthCode");
    //    int index = Convert.ToInt32(e.RowIndex);
    //    DataTable dt = ViewState["CurrentTable1"] as DataTable;
    //    if (dt != null)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            dt.Rows[index].Delete();
    //            grdshowcycle.DataSource = dt;
    //            grdshowcycle.DataBind();
    //            if (dt.Rows.Count == 0)
    //            {
    //                binddata();
    //            }
    //        }
    //        else
    //        {
    //            htParam.Clear();
    //            ds.Clear();
    //            htParam.Add("@cmp_code", lblCmpCode.Text.ToString().Trim());
    //            htParam.Add("@BUSI_CODE", lblMthCode.Text.ToString().Trim());
    //            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCycleDtls", htParam);
    //            binddata();
    //        }
    //    }
    //    else
    //    {
    //        htParam.Clear();
    //        ds.Clear();
    //        htParam.Add("@BUSI_CODE", lblMthCode.Text.ToString().Trim());
    //        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCycleDtls", htParam);
    //        binddata();
    //    }
    //    EmptydgCycle(dgcycle);
    //}

    //protected void lnkCnstCode_Click(object sender, EventArgs e)
    //{
    //    LinkButton lnkbtn = sender as LinkButton;
    //    //getting particular row linkbutton
    //    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
    //    //getting userid of particular row
    //    int index = Convert.ToInt32(gvrow.RowIndex);
    //    DataTable dt = ViewState["CurrentTable1"] as DataTable;
    //    dt.Rows[index].Delete();
    //    ViewState["dt"] = dt;
    //    if (dt.Rows.Count > 0)
    //    {
    //        grdshowcycle.DataSource = dt;
    //        grdshowcycle.DataBind();
    //    }
    //    else
    //    {
    //        ShowNoResultFound(dt, grdshowcycle);
    //    }
    //}

}
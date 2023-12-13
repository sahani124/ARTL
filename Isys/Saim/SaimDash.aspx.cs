using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Web.UI;
//using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;

public partial class Application_ISys_ChannelMgmt_SaimDash : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    public static int intr = 0;
    public static int time = 0;
    public static int grid = 0;
    public static int rerun = 0;
    public static string prcID = string.Empty;
    int i = 0;
    DataSet dsBtch = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        tmr.Enabled = false;
        if (!IsPostBack)
        {

            lblPulDt.Text = "This section shows the details of transfering data from POLDATA table to temp tables of Production";
            lblValDt.Text = "This section verifies data and validates it";
            lblCmpPrd.Text = "This section shows the details of computing production data i.e products sold by the Members";
            lblHier.Text = "This section shows the Member Hierarchy Tree";
            lblCmpCom.Text = "This section shows the details of computing compensation currently active";
            ddlCmpCode.Items.Insert(0, new ListItem("--SELECT--", ""));
            #region comment
            ////btnPulData.Attributes.Add("onclick", "ChangeColor('btnPulData')");
            ////btnCmpProd.Attributes.Add("onclick", "ChangeColor('btnCmpProd')");
            ////btnValData.Attributes.Add("onclick", "ChangeColor('btnValData')");
            ////btnHierTree.Attributes.Add("onclick", "ChangeColor('btnHierTree')");
            ////btnCmpComm.Attributes.Add("onclick", "ChangeColor('btnCmpComm')");
            #endregion
            lnkViewComp.Attributes.Add("onclick", "funcShow();");
            lnkViewComp.Visible = true;
            /////GetPrevDtls();
            tmr.Enabled = false;
            grid = 0;
            FillDropDowns(ddlCmpType, "10", "");

            //if (Request.QueryString["flag"] != null)
            //{
            //    if (Request.QueryString["flag"] == "BTCH")
            //    {
            //        if (Request.QueryString["CycDt1"] != null)
            //        {
            //            txtStrTm.Text = Request.QueryString["CycDt1"].ToString().Trim();
            //        }
            //        if (Request.QueryString["CycDt2"] != null)
            //        {
            //            txtEndTm.Text = Request.QueryString["CycDt2"].ToString().Trim();
            //        }
            //    }
            //}
            //GetBtchStat("Prc_InsPullData", btnPulData, 1, grdPulDt);
            //GetBtchStat("Prc_InsValData", btnValData, 2, grdValData);
            //GetBtchStat("Prc_InsPrdMemRelation", btnHierTree, 3, grdMemRel);
            //GetBtchStat("Prc_InsProd", btnCmpProd, 4, grdPrdData);
            //txtPrvCycDt1.Text = "31/10/2014";
            //txtPrvCycDt2.Text = "31/10/2014";
        }
    }

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        ds = null;
        ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdDashTbls");
        //grdPrd.DataSource = ds;
        //grdPrd.DataBind();

    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        ds = null;
        //if (Convert.ToDateTime(txtPrvCycDt1.Text) > Convert.ToDateTime(txtStrTm.Text))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Current CycleDateFrom is less than Previous CycleDateFrom');</script>", false);
        //    return;
        //}
        //if (Convert.ToDateTime(txtStrTm.Text) > Convert.ToDateTime(txtEndTm.Text))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('CycleDateFrom is greater than CycleDateTo');</script>", false);
        //    return;
        //}
        //if (Convert.ToDateTime(txtStrTm.Text) > DateTime.Now)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('You cannot enter future date');</script>", false);
        //    return;
        //}
        btnPulData.BackColor = System.Drawing.Color.FromArgb(135, 206, 250);
        if (txtStrTm.Text.ToString() != null)
        {
            if (txtStrTm.Text.ToString() != "")
            {
                htParam.Add("@CycDt1", Convert.ToDateTime(txtStrTm.Text.ToString()));
            }
            else
            {
                htParam.Add("@CycDt1", "");
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Start Date');</script>", false);
                return;
            }
        }
        if (txtEndTm.Text.ToString() != null)
        {
            if (txtEndTm.Text.ToString() != "")
            {
                htParam.Add("@CycDt2", Convert.ToDateTime(txtEndTm.Text.ToString()));
            }
            else
            {
                htParam.Add("@CycDt2", "");
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter End Date');</script>", false);
                return;
            }
        }
        htParam.Add("@CreatedBy", HttpContext.Current.Session["UserId"].ToString().Trim());
        #region cycdate
        ds = objDal.GetDataSetForPrc_SAIM("Prc_VrfyCycledates", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VrfyStat"] != null)
                {
                    if (ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "S")
                    {
                        //////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('These are Valid Cycle Dates.You may proceed with your Daily Job');</script>", false);
                        mdlpopup.Show();
                        lbl3.Text = "These are Valid Cycle Dates.You may proceed with your Daily Job";
                        btnPulData.Text = "PULL DATA";
                        btnValData.Text = "VALIDATE DATA";
                        btnHierTree.Text = "HIERARCHY TREE";
                        btnCmpProd.Text = "COMPUTE PRODUCTION";
                        btnPulData.Enabled = true;
                        intr = 1;
                        rerun = 0;
                    }
                    else if (ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "F" || ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "P")
                    {
                        mdlpopup.Show();
                        lbl3.Text = "The jobs are already run for these Cycle Dates.Please proceed to Rerun";
                        btnPulData.Enabled = true;
                        intr = 1;
                        rerun = 1;
                    }
                }
                if (ds.Tables[0].Rows[0]["RunNo"] != null)
                {
                    lbCurRnNoVal.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                    lbCurRnCntVal.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                }

                if (ds.Tables[0].Rows[0]["RunStatus"] != null)
                {
                    if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "S")
                    {
                        lbCurRnStVal.Text = "Success";
                    }
                    else if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "F")
                    {
                        lbCurRnStVal.Text = "Failed";

                    }
                    else if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "P")
                    {
                        lbCurRnStVal.Text = "Pending";
                    }
                }
                else 
                {
                    lbCurRnStVal.Text = "Pending";
                }

                if (ds.Tables[0].Rows[0]["RunBy"] != null)
                {
                    if (ds.Tables[0].Rows[0]["RunBy"].ToString().Trim() != "")
                    {
                        lbCurRnByVal.Text = ds.Tables[0].Rows[0]["RunBy"].ToString().Trim();
                    }
                    else
                    {
                        lbCurRnByVal.Text = HttpContext.Current.Session["UserId"].ToString().Trim();
                    }
                }
                else
                {
                    lbCurRnByVal.Text = HttpContext.Current.Session["UserId"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["PrcID"] != null)
                {
                    if (ds.Tables[0].Rows[0]["PrcID"].ToString().Trim() != "")
                    {
                        prcID = ds.Tables[0].Rows[0]["PrcID"].ToString().Trim();
                    }
                }
            }
        }
        #endregion
        ////tmr.Enabled = true;
    }

    protected void btnPulData_Click(object sender, EventArgs e)
    {
        int retval;
        if (intr == 1)
        {
            grid = 1;
            tmr.Enabled = true;
            btnPulData.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
            retval = RunBtchJob("Prc_InsPullData", rerun);
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsPullData");
            grdPulDt.DataSource = dsBtch;
            grdPulDt.DataBind();
            //////tmr.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
        }
    }

    protected void btnValData_Click(object sender, EventArgs e)
    {
        int retval;
        if (intr == 1)
        {
            grid = 2;
            ////intr = 1;
            tmr.Enabled = true;
            btnValData.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
            retval = RunBtchJob("Prc_InsValData", rerun);
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsValData");
            grdValData.DataSource = dsBtch;
            grdValData.DataBind();
            ////tmr.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
        }
    }

    protected void btnCmpProd_Click(object sender, EventArgs e)
    {
        int retval;
        if (intr == 1)
        {
            grid = 4;
            tmr.Enabled = true;
            //////btnCmpProd.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            retval = RunBtchJob("Prc_InsProd", rerun);
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsProd");
            grdPrdData.DataSource = dsBtch;
            grdPrdData.DataBind();
            //////tmr.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
        }
    }

    private void UpdateProgressContext(RadProgressContext progress)
    {
        const int total = 100;

        progress.Speed = "N/A";

        for (int i = 0; i <= total; i++)
        {
            progress.PrimaryTotal = 1;
            progress.PrimaryValue = 1;
            progress.PrimaryPercent = 100;

            progress.SecondaryTotal = total;
            progress.SecondaryValue = i;
            progress.SecondaryPercent = i;


            progress.CurrentOperationText = i.ToString() + "%";

            if (!Response.IsClientConnected)
            {
                break;
            }

            progress.TimeEstimated = (total - i) * 100;
            //Stall the current thread for 0.1 seconds
            System.Threading.Thread.Sleep(100);
        }
    }

    protected DataSet FillCount(string proc)
    {
        ds = null;
        htParam.Clear();
        htParam.Add("@ProcName", proc.ToString().Trim());
        if (txtStrTm.Text.ToString() != null)
        {
            if (txtStrTm.Text.ToString() != "")
            {
                htParam.Add("@CycDt1", Convert.ToDateTime(txtStrTm.Text.ToString()));
            }
            else
            {
                htParam.Add("@CycDt1", "");
            }
        }
        else
        {
            htParam.Add("@CycDt1", "");
        }

        if (txtEndTm.Text.ToString() != null)
        {
            if (txtEndTm.Text.ToString() != "")
            {
                htParam.Add("@CycDt2", Convert.ToDateTime(txtEndTm.Text.ToString()));
            }
            else
            {
                htParam.Add("@CycDt2", "");
            }
        }
        else
        {
            htParam.Add("@CycDt2", "");
        }
        htParam.Add("@PrcID", prcID);
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCount", htParam);
        return ds;
    }

    protected void lnkVwmrRun_Click(object sender, EventArgs e)
    {
        dsBtch.Clear();
        dsBtch = FillCount("Prc_InsPullData");
        grdPulDt.DataSource = dsBtch;
        grdPulDt.DataBind();
    }

    protected int RunBtchJob(string proc, int run)
    {
        htParam.Clear();
        ds = null;
        int ret = 0;
        //txtStrTm.Text = "01/11/2014";
        //txtEndTm.Text = "01/11/2014";
        try
        {
            htParam.Add("@CreatedBy", HttpContext.Current.Session["UserId"].ToString().Trim());
            if (run == 1)
            {
                htParam.Add("@Flag", "R");
            }
            else
            {
                htParam.Add("@Flag", "N");
            }
            htParam.Add("@PrcID", prcID.ToString().Trim());
            htParam.Add("@CycDt1", Convert.ToDateTime(txtStrTm.Text.ToString()));
            htParam.Add("@CycDt2", Convert.ToDateTime(txtEndTm.Text.ToString()));
            htParam.Add("@ProcName", proc.ToString().Trim());
            ds = null;
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsBtchStat", htParam);
            ds = null;
            ret = 1;

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "SaimDash", "RunBtchJob", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            ret = 2;
        }
        return ret;
    }

    protected void grdPulDt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProcess = (Label)e.Row.FindControl("lblProcess");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            if (lblProcess.Text == "S")
            {
                lblProcess.Text = "Success";
                lblProcess.ForeColor = System.Drawing.Color.Green;
                //btnPulData.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                btnPulData.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                btnPulData.Attributes.Add("background","yellow");
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
                tmr.Enabled = false;
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                btnPulData.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
                tmr.Enabled = false;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                btnPulData.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                ////btnPulData.Attributes.Add("background", "yellow");
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnPulData.Text = "PULL DATA";
            btnPulData.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        //else
        //{
        //    btnPulData.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        //}
    }
    protected void lnkVwMrCPrd_Click(object sender, EventArgs e)
    {
        dsBtch.Clear();
        dsBtch = FillCount("Prc_InsProd");
        grdPrdData.DataSource = dsBtch;
        grdPrdData.DataBind();
    }

    protected void lnkVwMrVDt_Click(object sender, EventArgs e)
    {
        dsBtch.Clear();
        dsBtch = FillCount("Prc_InsValData");
        grdValData.DataSource = dsBtch;
        grdValData.DataBind();
    }



    protected void grdValData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProcess = (Label)e.Row.FindControl("lblProcess");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            if (lblProcess.Text == "S")
            {
                lblProcess.Text = "Success";
                lblProcess.ForeColor = System.Drawing.Color.Green;
                btnValData.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
                tmr.Enabled = false;
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                btnValData.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
                tmr.Enabled = false;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                btnValData.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnValData.Text = "RERUN";
            btnValData.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        //else
        //{
        //    btnValData.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        //}
    }

    protected void grdPrdData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProcess = (Label)e.Row.FindControl("lblProcess");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            if (lblProcess.Text == "S")
            {
                lblProcess.Text = "Success";
                lblProcess.ForeColor = System.Drawing.Color.Green;
                btnCmpProd.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
                tmr.Enabled = false;
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                btnCmpProd.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
                tmr.Enabled = false;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                btnCmpProd.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnCmpProd.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        //else
        //{
        //    btnCmpProd.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        //}
    }

    protected void lnkViewComp_Click(object sender, EventArgs e)
    {

    }

    protected void GetPrevDtls()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@PrcID", "DE");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetPrevRunDtls", htParam);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["CycDt1"].ToString() != null)
                    {
                        txtPrvCycDt1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CycDt1"].ToString().Trim()).ToShortDateString();
                    }
                    if (ds.Tables[0].Rows[0]["CycDt2"].ToString() != null)
                    {
                        txtPrvCycDt2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CycDt2"].ToString().Trim()).ToShortDateString();
                    }
                    if (ds.Tables[0].Rows[0]["RunNo"].ToString() != null)
                    {
                        txtRunNo.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[0]["RunStatus"].ToString() != null)
                    {
                        if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "S")
                        {
                            txtRunStat.Text = "Success";
                        }
                        else if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "F")
                        {
                            txtRunStat.Text = "Failed";
                        }
                        else
                        {
                            txtRunStat.Text = "Pending";
                        }
                    }
                    if (ds.Tables[0].Rows[0]["RunNo"].ToString() != null)
                    {
                        txtRunCnt.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[0]["RunBy"].ToString() != null)
                    {
                        txtRunBy.Text = ds.Tables[0].Rows[0]["RunBy"].ToString().Trim();
                    }
                }
            }
        }
    }

    protected void tmr_Tick(object sender, EventArgs e)
    {
        if (grid == 1)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsPullData");
            grdPulDt.DataSource = dsBtch;
            grdPulDt.DataBind();
        }
        else if (grid == 2)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsValData");
            grdValData.DataSource = dsBtch;
            grdValData.DataBind();
        }
        else if (grid == 3)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsPrdMemRelation");
            grdMemRel.DataSource = dsBtch;
            grdMemRel.DataBind();
        }
        else if (grid == 4)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsProd");
            grdPrdData.DataSource = dsBtch;
            grdPrdData.DataBind();
        }
        else if (grid == 5)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsProd");
            grdCommData.DataSource = dsBtch;
            grdCommData.DataBind();
        }
    }
    protected void btnHierTree_Click(object sender, EventArgs e)
    {
        int retval;
        htParam.Clear();
        ds = null;
        try
        {
            if (intr == 1)
            {
                grid = 3;
                tmr.Enabled = true;
                btnHierTree.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                retval = RunBtchJob("Prc_InsPrdMemRelation", rerun);
                dsBtch.Clear();
                dsBtch = FillCount("Prc_InsPrdMemRelation");
                grdMemRel.DataSource = dsBtch;
                grdMemRel.DataBind();
                btnHierTree.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                /////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Member Hierarchy Set Successfully');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
                /////btnHierTree.BackColor = System.Drawing.Color.FromArgb(250, 0, 0);
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "SaimDash", "btnHierTree_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            btnHierTree.BackColor = System.Drawing.Color.FromArgb(250, 0, 0);
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Member Hierarchy Not Set Successfully');</script>", false);
        }

    }

    protected void lnkViewComm_Click(object sender, EventArgs e)
    {
        /////Response.Redirect("CalcCommission.aspx?flag=COMM&CycDt1=" + txtStrTm.Text.Trim() + "&CycDt2=" + txtEndTm.Text.Trim() + "", false);
        MVJob.ActiveViewIndex = 1;
        lnkVwBtch.ImageUrl = "~/theme/iflow/vwbtch_active.png";
        lnkViewComm.ImageUrl = "~/theme/iflow/vwcomp.png";
        txtPrvCycDt1.Text = "01/10/2014";
        txtPrvCycDt2.Text = "31/10/2014";
        txtStrTm.Text = "";
        txtEndTm.Text = "";
        lbCurRnByVal.Text = "";
        lbCurRnStVal.Text = "";
        lbCurRnNoVal.Text = "";
        lbCurRnCntVal.Text = "";
        GetBtchStat("Prc_InsProd", btnCmpComm, 5, grdCommData);
        txtStrTm.Text = "01/11/2014";
        txtEndTm.Text = "31/11/2014";
    }
    protected void lnkVwBtch_Click(object sender, EventArgs e)
    {
        //////Response.Redirect("SaimDash.aspx?flag=BTCH&CycDt1=" + txtStrTm.Text.Trim() + "&CycDt2=" + txtEndTm.Text.Trim() + "", false);
        MVJob.ActiveViewIndex = 0;
        lnkVwBtch.ImageUrl = "~/theme/iflow/vwbtch.png";
        lnkViewComm.ImageUrl = "~/theme/iflow/vwcomp_active.png";
        txtPrvCycDt1.Text = "31/10/2014";
        txtPrvCycDt2.Text = "31/10/2014";
    }

    protected void lnkVwHier_Click(object sender, EventArgs e)
    {

    }

    protected void btnCmpComm_Click(object sender, EventArgs e)
    {
        int retval;
        grid = 5;
        if (intr == 1)
        {
            tmr.Enabled = true;
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
            retval = RunBtchJob("Prc_InsProd", rerun);
            dsBtch.Clear();
            dsBtch = FillCount("Prc_InsProd");
            grdCommData.DataSource = dsBtch;
            grdCommData.DataBind();
            tmr.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
        }
    }

    protected void grdCommData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProcess = (Label)e.Row.FindControl("lblProcess");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            if (lblProcess.Text == "S")
            {
                lblProcess.Text = "Success";
                lblProcess.ForeColor = System.Drawing.Color.Green;
                btnCmpComm.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
                tmr.Enabled = false;
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                btnCmpComm.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
                tmr.Enabled = false;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                btnCmpComm.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnCmpComm.Text = "COMPUTE COMMISSION";
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        //else
        //{
        //    btnCmpComm.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        //}
    }

    protected void lnkVwMrCCom_Click(object sender, EventArgs e)
    {
        dsBtch.Clear();
        dsBtch = FillCount("Prc_ComputeComp");
        grdCommData.DataSource = dsBtch;
        grdCommData.DataBind();
    }

    protected void grdMemRel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblProcess = (Label)e.Row.FindControl("lblProcess");
            Label lbltblsrc = (Label)e.Row.FindControl("lbltblsrc");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            if (lbltblsrc.Text == "CHMS..MemRelation")
            {
                lbltblsrc.Text = "MemRelation";
            }
            if (lblProcess.Text == "S")
            {
                lblProcess.Text = "Success";
                lblProcess.ForeColor = System.Drawing.Color.Green;
                btnHierTree.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
                tmr.Enabled = false;
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                btnHierTree.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
                tmr.Enabled = false;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                btnHierTree.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnHierTree.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        //else
        //{
        //    btnHierTree.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        //}
    }

    public void GetBtchStat(string procName, RadButton btn, int gridNo, GridView gv)
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        DataSet dsBtch = new DataSet();
        ds = null;
        ht.Clear();
        intr = 1;
        rerun = 0;
        ht.Add("@prcName", procName.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetBtchStatus", ht);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtStrTm.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CycleDateFrom"].ToString().Trim()).ToShortDateString();
                txtEndTm.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CycleDateTo"].ToString().Trim()).ToShortDateString();
                lbCurRnNoVal.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                lbCurRnCntVal.Text = ds.Tables[0].Rows[0]["RunNo"].ToString().Trim();
                lbCurRnByVal.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString().Trim();
                string prc = ds.Tables[0].Rows[0]["ProcName"].ToString().Trim();
                if (txtStrTm.Text.Trim() == txtEndTm.Text.Trim())
                {
                    prcID = "DE";
                }
                if (ds.Tables[0].Rows[0]["RunStatus"].ToString().Trim() == "Processed" && ds.Tables[0].Rows[0]["ExecStatus"].ToString().Trim() == "Completed")
                {
                    ////lbCurRnStVal.Text = "Success";
                    btn.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
                    grid = gridNo;

                    dsBtch.Clear();
                    dsBtch = FillCount(prc.ToString().Trim());
                    gv.DataSource = dsBtch;
                    gv.DataBind();
                }
                else
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(255, 255, 51);
                    ////lbCurRnStVal.Text = "Pending";
                    grid = gridNo;
                    tmr.Enabled = true;
                }
            }
        }
        else
        {
            ds = null;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnPulData.BackColor = System.Drawing.Color.FromArgb(255, 135, 206, 250);
        btnValData.BackColor = System.Drawing.Color.FromArgb(255, 135, 206, 250);
        btnHierTree.BackColor = System.Drawing.Color.FromArgb(255, 135, 206, 250);
        btnCmpProd.BackColor = System.Drawing.Color.FromArgb(255, 135, 206, 250);
        grdPulDt.DataSource = null;
        grdPulDt.DataBind();
        grdValData.DataSource = null;
        grdValData.DataBind();
        grdMemRel.DataSource = null;
        grdMemRel.DataBind();
        grdPrdData.DataSource = null;
        grdPrdData.DataBind();
        txtStrTm.Text = "";
        txtEndTm.Text = "";
        lbCurRnNoVal.Text = "";
        lbCurRnStVal.Text = "";
        lbCurRnCntVal.Text = "";
        lbCurRnByVal.Text = "";
        tmr.Enabled = false;
    }

    protected void FillDropDowns(DropDownList ddl, string val,string cmptype)
    {
        SqlDataReader drRead;
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        ht.Add("@CMPNSTYPE", cmptype.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected void ddlCmpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlCmpCode, "16", ddlCmpType.SelectedValue.ToString().Trim());
    }
    protected void btnCnl_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CompCode", ddlCmpCode.SelectedValue.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtPrvCycDt1.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
            txtPrvCycDt2.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
            txtRunCnt.Text = "1";
            txtRunNo.Text = "1";
            txtRunStat.Text = "Completed";
            txtRunBy.Text = "systemadmin";
            txtStrTm.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim(); ;
            txtEndTm.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim(); ;
            lbCurRnNoVal.Text = "1";
            lbCurRnCntVal.Text = "2";
            lbCurRnStVal.Text = "Pending";
            lbCurRnByVal.Text = "systemadmin";
        }
    }
}

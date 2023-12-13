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

public partial class Application_ISys_Saim_CalcCommission : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    public static int intr = 0;
    public static int time = 0;
    public static int grid = 0;
    public static int rerun = 0;
    int i = 0;
    DataSet dsBtch = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lnkViewComp.Visible = true;
            lnkViewComp.Attributes.Add("onclick", "funcShow();");
            lblCmpCom.Text = "This section shows the details of computing Commission of the products sold by the Members";
            GetPrevDtls();
            tmr.Enabled = false;
            grid = 0;


            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"] == "COMM")
                {
                    if (Request.QueryString["CycDt1"] != null)
                    {
                        txtStrTm.Text = Request.QueryString["CycDt1"].ToString().Trim();
                    }
                    if (Request.QueryString["CycDt2"] != null)
                    {
                        txtEndTm.Text = Request.QueryString["CycDt2"].ToString().Trim();
                    }
                }
            }
        }
    }
    protected void btnCmpComm_Click(object sender, EventArgs e)
    {
        int retval;
        grid = 4;
        /////tmr.Enabled = true;
        btnCmpComm.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
        retval = RunBtchJob("Prc_CmpComm", rerun);
        if (retval == 1)
        {
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
            btnCmpComm.Text = "COMPUTE COMMISSION";
            //////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Commission Computation Successful');</script>", false);
        }
        else if (retval == 1)
        {
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(250, 0, 0);
            ///btnCmpComm.Text = "RERUN";

        }
        dsBtch.Clear();
        dsBtch = FillCount("Prc_CmpComm");
        grdCommData.DataSource = dsBtch;
        grdCommData.DataBind();
        ////tmr.Enabled = false;
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

        if (txtStrTm.Text.ToString() != null)
        {
            if (txtStrTm.Text.ToString() != "")
            {
                htParam.Add("@CycDt2", Convert.ToDateTime(txtStrTm.Text.ToString()));
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
        htParam.Add("@PrcID", "DE");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCount", htParam);
        return ds;
    }

    protected int RunBtchJob(string proc, int run)
    {
        htParam.Clear();
        ds = null;
        int ret = 0;
        try
        {
            if (intr == 1)
            {
                htParam.Add("@CreatedBy", HttpContext.Current.Session["UserId"].ToString());
                if (run == 1)
                {
                    htParam.Add("@Flag", "R");
                }
                else
                {
                    htParam.Add("@Flag", "N");
                }
                htParam.Add("@PrcID", "DE");
                htParam.Add("@CycDt1", Convert.ToDateTime(txtStrTm.Text.ToString()));
                htParam.Add("@CycDt2", Convert.ToDateTime(txtEndTm.Text.ToString()));
                htParam.Add("@ProcName", proc.ToString().Trim());
                ds = null;
                ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpComm", htParam);
                ds = null;
                ret = 1;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CalcCommission", "RunBtchJob", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            ret = 2;
        }
        return ret;
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
                imgStatus.ImageUrl = "../../../images/tick_ok.ico";
            }
            else if (lblProcess.Text == "F")
            {
                lblProcess.Text = "Error";
                lblProcess.ForeColor = System.Drawing.Color.Red;
                imgStatus.ImageUrl = "../../../images/cross1.ico";
                i = i + 1;
            }
            else
            {
                lblProcess.Text = "Awaiting Execution";
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
        }
        if (i > 0)
        {
            btnCmpComm.Text = "COMPUTE COMMISSION";
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        else
        {
            btnCmpComm.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        }
    }

    protected void lnkVwMrCCom_Click(object sender, EventArgs e)
    {
        dsBtch.Clear();
        dsBtch = FillCount("Prc_CmpComm");
        grdCommData.DataSource = dsBtch;
        grdCommData.DataBind();
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        ds = null;
        if (Convert.ToDateTime(txtStrTm.Text) > Convert.ToDateTime(txtEndTm.Text))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('CycleDateFrom is greater than CycleDateTo');</script>", false);
            return;
        }
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
            }
        }
        /////htParam.Add("@PrcID", "DE");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_VrfyCycledates", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VrfyStat"] != null)
                {
                    if (ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "S")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Verified');</script>", false);
                        btnCmpComm.Text = "COMPUTE COMMISSION";
                        intr = 1;
                        rerun = 0;
                    }
                    else if (ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "F")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Click On ReRun');</script>", false);
                        btnCmpComm.Text = "COMPUTE COMMISSION";
                        intr = 1;
                        rerun = 1;
                    }
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
        }
    }

    protected void tmr_Tick(object sender, EventArgs e)
    {
        if (grid == 4)
        {
            dsBtch.Clear();
            dsBtch = FillCount("Prc_CmpComm");
            grdCommData.DataSource = dsBtch;
            grdCommData.DataBind();
        }
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

    protected void lnkViewComm_Click(object sender, EventArgs e)
    {
        Response.Redirect("CalcCommission.aspx?&flag=COMM&CycDt1=" + txtStrTm.Text.Trim() + "&CycDt2=" + txtEndTm.Text.Trim() + "", false);
    }
    protected void lnkVwBtch_Click(object sender, EventArgs e)
    {
        Response.Redirect("SaimDash.aspx?&flag=BTCH&CycDt1=" + txtStrTm.Text.Trim() + "&CycDt2=" + txtEndTm.Text.Trim() + "", false);
    }

    protected void lnkViewComp_Click(object sender, EventArgs e)
    {

    }
}
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

public partial class Application_ISys_ChannelMgmt_SaimDash : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    public static int intr = 0;
    int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //ds = null;
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_GetDashDtls");
        //grdPrd.DataSource = ds;
        //grdPrd.DataBind();
        btnRun.Attributes.Add("onclick", "ChangeColor()");
    }
    protected void btnRun_Click(object sender, EventArgs e)
    {
        try
        {
            
            htParam.Clear();
            ds = null;
            if (intr == 1)
            {
                imgload.Visible = true;
                Thread.Sleep(10000);
                imgload.Visible = false;
                htParam.Add("@CreatedBy", HttpContext.Current.Session["UserId"].ToString());
                if (btnRun.Text == "RERUN")
                {
                    htParam.Add("@Flag", "R");
                }
                else
                {
                    htParam.Add("@Flag", "N");
                }
                htParam.Add("@PrcID", "DE");
                htParam.Add("@StartTime", Convert.ToDateTime(txtStrTm.Text.ToString()));
                htParam.Add("@EndTime", Convert.ToDateTime(txtEndTm.Text.ToString()));
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsProd", htParam);

                ds = null;
                ds = objDal.GetDataSetForPrc_DIRECT("Prc_GetDashDtls");
                grdPrd.DataSource = ds;
                grdPrd.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Verify Start Date and End Date');</script>", false);
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

    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
       
    //}

    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        ds = null;
        ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdDashTbls");
        grdPrd.DataSource = ds;
        grdPrd.DataBind();

    }
    protected void grdPrd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStat = (Label)e.Row.FindControl("lblStat");
            if (lblStat.Text == "Completed")
            {
                lblStat.ForeColor = System.Drawing.Color.Green;
            }
            else if (lblStat.Text == "Error")
            {
                lblStat.ForeColor = System.Drawing.Color.Red;
                i = i + 1;
            }
        }
        if (i > 0)
        {
            btnRun.Text = "RERUN";
            btnRun.BackColor = System.Drawing.Color.FromArgb(240, 0, 0);
        }
        else
        {
            btnRun.BackColor = System.Drawing.Color.FromArgb(50, 255, 50);
        }
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        ds = null;
        btnRun.BackColor = System.Drawing.Color.FromArgb(0, 0, 205);
        grdPrd.DataSource = ds;
        grdPrd.DataBind();
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
        htParam.Add("@PrcID", "DE");
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
                        btnRun.Text = "RUN";
                        btnRun.Enabled = true;
                        intr = 1;

                    }
                    else if (ds.Tables[0].Rows[0]["VrfyStat"].ToString().Trim() == "F")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Click On ReRun');</script>", false);
                        btnRun.Text = "RERUN";
                        btnRun.Enabled = true;
                        intr = 1;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;


public partial class Application_ISys_Recruit_PopSMDetails : BaseClass
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TrEmpSearch.Visible = true;
            //FillSMDetails();
        
        }
    }

    protected DataSet FillSMDetails()
    {
        Hashtable htParam = new Hashtable();
        DataSet dsmgr = new DataSet();
        dsmgr.Clear();
        htParam.Clear();
        try
        {
            //htParam.Add("@BizSrc", Request.QueryString["bizsrc"].ToString().Trim());
            //htParam.Add("@ChnCls", Request.QueryString["subchnl"].ToString().Trim());
            //htParam.Add("@UnitCode", Request.QueryString["untcd"].ToString().Trim());
            if (txtEmpCode.Text != "")
            {
                htParam.Add("@EmpCode", txtEmpCode.Text);
            }
            else
            {
                htParam.Add("@EmpCode", System.DBNull.Value);
            }
            if (txtEmpName.Text != "")
            {
                htParam.Add("@EmpName", txtEmpName.Text);
            }
            else
            {
                htParam.Add("@EmpName", System.DBNull.Value);
            }
            dsmgr = objDAL.GetDataSetForPrcRecruit("Prc_GetNewSMDtls", htParam);
            
            ////dsmgr = null;
            
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
        return dsmgr;
    }
    
    protected void gvSMDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkMgrCode = new LinkButton();
            Label lblBizSrc = new Label();
            Label lblChncls = new Label();
            Label lblUntCode = new Label();
            Label lblBrnchNm = new Label();
            LinkButton lblEmpCode = new LinkButton();
            Label lblLegalName = new Label();
            Label lblAgentTypeDesc01 = new Label();
            Label lblBranch = new Label();
            Label lblAgentTypeDesc = new Label();
            Label lblBizSrcvalue = new Label();
            Label lblChnClsvalue = new Label();
            Label lblAgentType = new Label();
            Label lblAgnType = new Label();
            Label lblUnitCode = new Label();
            lblEmpCode = (LinkButton)e.Row.FindControl("lblEmpCode");
            lnkMgrCode = (LinkButton)e.Row.FindControl("lnkmemCode");
            lblLegalName = (Label)e.Row.FindControl("lblLegalName");
            lblBizSrc = (Label)e.Row.FindControl("lblBizSrc");
            lblChncls = (Label)e.Row.FindControl("lblChncls");
            lblAgentTypeDesc01 = (Label)e.Row.FindControl("lblAgentTypeDesc01");
            lblBrnchNm = (Label)e.Row.FindControl("lblBrnchNm");
            lblBranch = (Label)e.Row.FindControl("lblBranch");
            lblAgentTypeDesc = (Label)e.Row.FindControl("lblAgentTypeDesc");
            //pranjali
            lblBizSrcvalue = (Label)e.Row.FindControl("lblBizSrcvalue");
            lblChnClsvalue = (Label)e.Row.FindControl("lblChnClsvalue");
            lblAgentType = (Label)e.Row.FindControl("lblAgentType");
            lblAgnType = (Label)e.Row.FindControl("lblAgnType");
            lblUnitCode = (Label)e.Row.FindControl("lblUnitCode");

            ////lnkMgrCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + e.Row.Cells[2].Text.Trim() + "','" + lnkUnitCode.Text.Trim() + "');return false;");

            //lnkMgrCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + lblBizSrc.Text.Trim() + "','" + lblChncls.Text.Trim() + "','" + lblUntCode.Text.Trim() + "','" + lblBrnchNm.Text.Trim() + "','" + lblEmpCode.Text.Trim() + "','" + lblLegalName.Text.Trim() + "','" + lblAgentTypeDesc01.Text.Trim() + "','" + lblBranch.Text.Trim() + "','" + lblAgentTypeDesc.Text.Trim() + "');return false;");
            lblEmpCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + lblBizSrc.Text.Trim() + "','" + lblChncls.Text.Trim() + "','" + lblUntCode.Text.Trim() + "','" + lblBrnchNm.Text.Trim() + "','" + lblEmpCode.Text.Trim() + "','" + lblLegalName.Text.Trim() + "','" + lblAgentTypeDesc01.Text.Trim() + "','" + lblBranch.Text.Trim() + "','" + lblAgentTypeDesc.Text.Trim() + "','" + lblBizSrcvalue.Text.Trim() + "','" + lblChnClsvalue.Text.Trim() + "','" + lblAgentType.Text.Trim() + "','" + lblAgnType.Text.Trim() + "','" + lblUnitCode.Text.Trim() + "');return false;");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dsSM = new DataSet();
        dsSM = FillSMDetails();
        if (dsSM.Tables.Count > 0 && dsSM.Tables[0].Rows.Count > 0)
        {
            gvSMDtls.Visible = true;
            gvSMDtls.DataSource = dsSM.Tables[0];
            gvSMDtls.DataBind();
            ViewState["gv"] = dsSM;
            gvSMDtls.Visible = true;
        }
        else
        {
            trErrorMsg.Visible = true;
            lblErrorMsg.Visible = true;
            gvSMDtls.Visible = false;
            lblErrorMsg.Text = " No Records Found ! ";
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' No Records Found ! ');</script>", false);
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEmpCode.Text = "";
        txtEmpName.Text = "";
        gvSMDtls.Visible = false;
    }
    #region  PAGEINDEXCHANGING EVENT
    protected void gvSMDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = FillSMDetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;

            dgSource.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.DataSource = dt;
            dgSource.DataBind();
            ////ShowPageInformation();
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
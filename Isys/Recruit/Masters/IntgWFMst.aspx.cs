using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Recruit_Masters_IntgWFMst : BaseClass
{
    DataSet ds = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
	private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            BindGrid();
			//txtSrtOrd.Text = GetSrtOrdr();
			txtIntrgId.Text = Request.QueryString["IntrgtId"].Trim();
			GetddlActnVal();

		}
    }

	protected void GetddlActnVal()
	{
		htParam.Clear();
		ds.Clear();
		ddlActn.Items.Clear();
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetddlMstIntrgActnTbl", htParam);
		if (ds.Tables[0].Rows.Count > 0)
		{
			ddlActn.DataSource = ds.Tables[0];
			ddlActn.DataTextField = "Steps";
			ddlActn.DataValueField = "ActnId";
			ddlActn.DataBind();

			ddlNxtActn.DataSource = ds.Tables[0];
			ddlNxtActn.DataTextField = "Steps";
			ddlNxtActn.DataValueField = "ActnId";
			ddlNxtActn.DataBind();
		}
		ddlActn.Items.Insert(0, new ListItem("-- SELECT --", ""));
		ddlNxtActn.Items.Insert(0, new ListItem("-- SELECT --", ""));

	}


	protected void BindGrid()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		htParam.Add("@IntrgtId", Request.QueryString["IntrgtId"].Trim());
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetIntgWFMst", htParam);
		if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
            //gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
            gv_DBFunction.DataSource = ds;
            gv_DBFunction.DataBind();
            if (gv_DBFunction.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        else
        {
            ShowNoRecQualTrg(ds.Tables[0], gv_DBFunction);
        }
        Session["grid"] = ds.Tables[0];
        //Session["gridCnt"] = ds.Tables[1];
        Session["TblRowCount"] = 0;
        ViewState["TblRowCount1"] = 0;
    }

    private void ShowNoRecQualTrg(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        //gv.Rows[0].Cells[0].Text = "No targets have been defined";
		gv.Rows[0].Cells[0].Text = "No integration have been defined";
		source.Rows.Clear();
    }

    #region gv_DBFunction_RowDataBound
    protected void gv_DBFunction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblCode = (Label)e.Row.FindControl("lblCode");
            //LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
            //lnkEditRwdTrg.Attributes.Add("onclick", "funEditPopUp('" + lblCode.Text + "','grid');return false;");
        }
    }
    #endregion

    #region btnprev_Click
    protected void btnprev_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gv_DBFunction.PageIndex;
            gv_DBFunction.PageIndex = pageIndex - 1;
            //BindGrid();
            //dtTemp = Session["tmpgrid"] as DataTable;
            gv_DBFunction.DataSource = Session["grid"];
            gv_DBFunction.DataBind();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprev.Enabled = false;
            }
            else
            {
                btnprev.Enabled = true;
            }
            btnnext.Enabled = true;


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstAccCycle", "btnprev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnnext_Click
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv_DBFunction.PageIndex;
            gv_DBFunction.PageIndex = pageIndex + 1;
            //BindGrid();
            gv_DBFunction.DataSource = Session["grid"];
            gv_DBFunction.DataBind();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            btnprev.Enabled = true;
            if (txtpgrwdtrg.Text == Convert.ToString(gv_DBFunction.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv_DBFunction.PageCount;

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstAccCycle", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
	#endregion

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			htParam.Clear();
			ds.Clear();
			htParam.Add("@IntrgtId", txtIntrgId.Text);
			//htParam.Add("@IsMndtry", ddlActn.SelectedValue.ToString());
			//htParam.Add("@IsActv", ddlNxtActn.SelectedValue.ToString());
			if (ddlActn.SelectedIndex == 0)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Action');", true);
				return;

			}
			else
			{
				htParam.Add("@ActnId", ddlActn.SelectedValue.ToString().Trim());
			}
			if (ddlNxtActn.SelectedIndex == 0)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select  Next Action');", true);
				return;

			}
			else
			{
				htParam.Add("@NxtActnId", ddlNxtActn.SelectedValue.ToString().Trim());
			}
			htParam.Add("@ExcptnFlg", ddlIsExcpChckgFlg.SelectedValue.ToString());
			htParam.Add("@IsActv", ddlIsActv.SelectedValue.ToString());
			htParam.Add("@IsMndtry", ddlIsMndatry.SelectedValue.ToString());
			//htParam.Add("@IsMndtry", ddlIsMndatry.SelectedValue.ToString());
			//htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
			//htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
			//htParam.Add("@Xpath", txtXpath.Text);
			//htParam.Add("@IsLicens", ddlActn.SelectedValue.ToString());
			//if (ddlActn.SelectedIndex == 0)
			//{
			//	ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Action');", true);
			//	return;

			//}
			//else
			//{
			//	htParam.Add("@Action", ddlActn.SelectedValue.ToString().Trim());
			//}
			//htParam.Add("@DfltVal", txtDfltVal.Text);
			//htParam.Add("@PassWrd", txtPsswrd.Text);
			//htParam.Add("@SortOrder", txtSrtOrd.Text);
			//htParam.Add("@IsLicens", ddlIsLcns.SelectedValue.ToString());
			if (btnSave.Text== "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				htParam.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@UpdatedDate", Convert.ToDateTime(txtcreatedte.Text));
				htParam.Add("@Flag", "U");
				htParam.Add("@SrNo", Session["SrNo"]);
			}
			else
			{
				htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
				htParam.Add("@Flag", "S");
			}
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_InsIntgWFMst", htParam);
			BindGrid();
			if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Save";
				lblcreatedte.Text = "Created Date";
			}
			//txtActName.Text = "";
			ddlActn.SelectedIndex = 0;
			ddlNxtActn.SelectedIndex = 0;
			ddlIsActv.SelectedIndex = 0;
			ddlIsMndatry.SelectedIndex = 0;
			ddlIsExcpChckgFlg.SelectedIndex = 0;
			//txtXpath.Text = "";
			//txtDfltVal.Text = "";
			//txtPsswrd.Text = "";
			//txtSrtOrd.Text = GetSrtOrdr();
			//ddlIsLcns.SelectedIndex = 0;
			txtcreatedte.Text = "";
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

	protected void lnkEditRwdTrg_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update";
			Label lblSrNo = (Label)Row.FindControl("lblSrNo");
			Label lblActnId = (Label)Row.FindControl("lblActnId");
			Label lblNxtActnId = (Label)Row.FindControl("lblNxtActnId");
			Label lblIsActive = (Label)Row.FindControl("lblIsActive");
			Label lblExcptnFlg = (Label)Row.FindControl("lblExcptnFlg");
			Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
			//Label lblSrtOrdr = (Label)Row.FindControl("lblSrtOrdr");
			//Label lblIsLicense = (Label)Row.FindControl("lblIsLicense");
			//Label lblIsActive = (Label)Row.FindControl("lblIsActive");
			//Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
			lblcreatedte.Text = "Updated Date";
			//txtActName.Text = lblDesc1.Text;
			//txtXpath.Text= lblXpath.Text;
			//txtDfltVal.Text= lblDefaultvalue.Text;
			//txtPsswrd.Text= lblIntgPsswrd.Text;
			//txtSrtOrd.Text= lblSrtOrdr.Text;
			//GetddlActnVal();
			ddlActn.SelectedValue = lblActnId.Text;
			ddlNxtActn.SelectedValue = lblNxtActnId.Text;
			ddlIsActv.SelectedItem.Value = lblIsActive.Text;
			ddlIsExcpChckgFlg.SelectedValue = lblExcptnFlg.Text;
			ddlIsMndatry.SelectedItem.Value = lblIsMndtry.Text;
			Session["SrNo"] = lblSrNo.Text;
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

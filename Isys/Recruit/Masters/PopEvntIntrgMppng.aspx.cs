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

public partial class Application_ISys_Recruit_Masters_PopEvntIntrgMppng : BaseClass
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
			//BindGrid();
			//txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			BindGrid(Request.QueryString["IntrgtId"].Trim());
			GetddlEvntVal();
		}
    }

	private void GetddlEvntVal()
	{
		ddlEvntNme.Items.Clear();
		htParam.Clear();
		ds.Clear();
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetddlMstEvntTbl", htParam);
		if (ds.Tables[0].Rows.Count > 0)
		{
			ddlEvntNme.DataSource = ds.Tables[0];
			ddlEvntNme.DataTextField = "EvntNme";
			ddlEvntNme.DataValueField = "EvntId";
			ddlEvntNme.DataBind();
		}
		//ddlEvntNme.Items.Insert(0, new ListItem("-- SELECT --", ""));
	}

	protected void BindGrid(string IntrgtId)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
		htParam.Add("@IntrgtId", IntrgtId);
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetEvntIntrgMppng", htParam);
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
		gv.Rows[0].Cells[0].Text = "No events have been defined";
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
			//Added by Abuzar
			foreach (ListItem lst in ddlEvntNme.Items)
			{
				if (lst.Selected == true)
				{
					htParam.Clear();
					ds.Clear();
					htParam.Add("@EvntId", ddlEvntNme.SelectedValue.ToString());
					htParam.Add("@IntrgtId", Request.QueryString["IntrgtId"].Trim());
					htParam.Add("@Flag", "S");
					htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
					//htParam.Add("@IsActv", ddlIsActv.SelectedValue.ToString());
					//htParam.Add("@IsMndtry", ddlIsMndatry.SelectedValue.ToString());
					//if (chbkIsActv.Checked == true)
					//{
					//	htParam.Add("@IsActv", "Y");
					//}
					//else
					//{
					//	htParam.Add("@IsActv", "N");
					//}
					//if (chbkIsMndatry.Checked == true)
					//{
					//	htParam.Add("@IsMndtry", "Y");
					//}
					//else
					//{
					//	htParam.Add("@IsMndtry", "N");
					//}

					//htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
					//htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
					//if (btnSave.Text== "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
					//{
					//	htParam.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
					//	htParam.Add("@UpdatedDate", Convert.ToDateTime(txtcreatedte.Text));
					//	if (txtCseDte.Text != "")
					//	{
					//		if (chbkIsActv.Checked == true)
					//		{
					//			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Mapping Cannot be Active');", true);
					//			return;
					//		}
					//		htParam.Add("@CeaseDate", Convert.ToDateTime(txtCseDte.Text));
					//	}
					//	else
					//	{
					//		htParam.Add("@CeaseDate", DBNull.Value);
					//	}
					//	htParam.Add("@Flag", "U");
					//	htParam.Add("@Srno", Session["Srno"]);
					//}
					//else
					//{
					//	htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
					//	htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
					//	htParam.Add("@Flag", "S");
					//}
					ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_InsEvntIntrgMppng", htParam);
				}
			}
			BindGrid(Request.QueryString["IntrgtId"].Trim());
			//if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			//{
			//btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Save";
			//lblcreatedte.Text = "Created Date";
			//txtCseDte.Text = "";
			//txtCseDte.Enabled = false;
			//}
			//ddlEvntNme.SelectedIndex = 0;
			ddlEvntNme.ClearSelection();
			//ddlIsActv.SelectedIndex = 0;
			//ddlIsMndatry.SelectedIndex = 0;
			//chbkIsActv.Checked = true;
			//chbkIsMndatry.Checked = true;
			//txtcreatedte.Text = "";
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
			Label lblSrNo = (Label)Row.FindControl("lblSrNo");
			htParam.Clear();
			ds.Clear();
			htParam.Add("@Srno", lblSrNo.Text.ToString().Trim());
			htParam.Add("@Flag", "U");
			htParam.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_InsEvntIntrgMppng", htParam);
			BindGrid(Request.QueryString["IntrgtId"].Trim());
			//Label lblEvntId = (Label)Row.FindControl("lblEvntId");
			//Label lblIsActive = (Label)Row.FindControl("lblIsActive");
			//Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
			//Label lblCeaseDate = (Label)Row.FindControl("lblCeaseDate");
			//lblcreatedte.Text = "Updated Date";
			//ddlEvntNme.SelectedValue = lblEvntId.Text;
			//ddlIsActv.SelectedItem.Value = lblIsActive.Text;
			//ddlIsMndatry.SelectedItem.Value = lblIsMndtry.Text;
			//if (lblIsMndtry.Text.ToString().Trim() == "Y")
			//{
			//	chbkIsMndatry.Checked = true;
			//}
			//else
			//{
			//	chbkIsMndatry.Checked = false;
			//}
			//if (lblIsActive.Text.ToString().Trim() == "Y")
			//{
			//	chbkIsActv.Checked = true;
			//}
			//else
			//{
			//	chbkIsActv.Checked = false;
			//}
			//Session["Srno"] = lblSrNo.Text;
			//txtCseDte.Enabled = true;
			//txtCseDte.Text = Convert.ToDateTime(lblCeaseDate.Text).ToString("dd/MM/yyyy");
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

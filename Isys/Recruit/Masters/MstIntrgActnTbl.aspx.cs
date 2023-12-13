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

public partial class Application_ISys_Recruit_Masters_MstIntrgActnTbl : BaseClass
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
			txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			BindGrid(Request.QueryString["IntrgtId"].Trim());
			BindGridInactv(Request.QueryString["IntrgtId"].Trim());
			//txtSrtOrd.Text = GetSrtOrdr();
			GetddlActnVal();
			Getddlloctyp();

		}
	}

	protected void GetddlActnVal()
	{
		htParam.Clear();
		ds.Clear();
		htParam.Add("@ParamVal", "Action");

		ddlActn.Items.Clear();
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetddlActMstIntrgActnTbl", htParam);
		if (ds.Tables[0].Rows.Count > 0)
		{
			ddlActn.DataSource = ds.Tables[0];
			ddlActn.DataTextField = "ParamDesc01";
			ddlActn.DataValueField = "ParamValue";
			ddlActn.DataBind();
		}
		ddlActn.Items.Insert(0, new ListItem("-- SELECT --", ""));

	}

	protected void Getddlloctyp()
	{
		htParam.Clear();
		ds.Clear();
		htParam.Add("@ParamVal", "LocatorType");

		ddlloctyp.Items.Clear();
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetddlActMstIntrgActnTbl", htParam);
		if (ds.Tables[0].Rows.Count > 0)
		{
			ddlloctyp.DataSource = ds.Tables[0];
			ddlloctyp.DataTextField = "ParamDesc01";
			ddlloctyp.DataValueField = "ParamValue";
			ddlloctyp.DataBind();
		}
		ddlloctyp.Items.Insert(0, new ListItem("-- SELECT --", ""));

	}

	//protected void BindGrid()
	protected void BindGrid(string IntrgtId)
	{
		ds = new DataSet();
		htParam.Clear();
		ds.Clear();
		htParam.Add("@IntrgtId", IntrgtId);
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstIntrgActnTbl", htParam);
		if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
		{
			//hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
			//gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
			gv_DBFunction.DataSource = ds;
			gv_DBFunction.DataBind();
			//gv_DBFunction.Columns[2].ItemStyle.Width = 40;
			//gv_DBFunction.Columns[2].ItemStyle.Wrap = true;
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

	protected void BindGridInactv(string IntrgtId)
	{
		ds = new DataSet();
		htParam.Clear();
		ds.Clear();
		htParam.Add("@IntrgtId", IntrgtId);
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstIntrgActnTblInactv", htParam);
		if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
		{
			//hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
			//gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
			gventinact.DataSource = ds;
			gventinact.DataBind();
			//gventinact.Columns[3].ItemStyle.Width = 40;
			//gventinact.Columns[3].ItemStyle.Wrap = true;
			if (gventinact.PageCount > 1)
			{
				btnnextinac.Enabled = true;
			}
			else
			{
				btnnextinac.Enabled = false;
			}
		}
		else
		{
			ShowNoRecQualTrg(ds.Tables[0], gventinact);
		}
		Session["grid1"] = ds.Tables[0];
		//Session["gridCnt"] = ds.Tables[1];
		Session["TblRowCount1"] = 0;
		ViewState["TblRowCount2"] = 0;
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
		//gv.Rows[0].Cells[0].Text = "No integration have been defined";
		source.Rows.Clear();
	}

	#region gv_DBFunction_RowDataBound
	protected void gv_DBFunction_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			Label lblDefaultvalue = (Label)e.Row.FindControl("lblDefaultvalue");
			Label lblXpath = (Label)e.Row.FindControl("lblXpath");
			if (lblDefaultvalue.Text!="") {
				e.Row.Cells[5].Attributes.Add("style", "white-space:pre-wrap;");
			}
			if (lblXpath.Text != "")
			{
				e.Row.Cells[3].Attributes.Add("style", "white-space:pre-wrap;");
			}
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
			BindGrid(Request.QueryString["IntrgtId"].Trim());
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
			BindGrid(Request.QueryString["IntrgtId"].Trim());
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

	#region btnprev_Click
	protected void btnprevinac_Click(object sender, EventArgs e)
	{
		try
		{

			int pageIndex = gventinact.PageIndex;
			gventinact.PageIndex = pageIndex - 1;
			//BindGrid();
			BindGridInactv(Request.QueryString["IntrgtId"].Trim());
			//dtTemp = Session["tmpgrid"] as DataTable;
			gventinact.DataSource = Session["grid"];
			gventinact.DataBind();
			txtpgrwdtrginac.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrginac.Text) - 1);
			if (txtpgrwdtrginac.Text == "1")
			{
				btnprevinac.Enabled = false;
			}
			else
			{
				btnprevinac.Enabled = true;
			}
			btnnextinac.Enabled = true;


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
	protected void btnnextinac_Click(object sender, EventArgs e)
	{
		try
		{
			int pageIndex = gventinact.PageIndex;
			gventinact.PageIndex = pageIndex + 1;
			//BindGrid();
			BindGridInactv(Request.QueryString["IntrgtId"].Trim());
			gventinact.DataSource = Session["grid1"];
			gventinact.DataBind();
			txtpgrwdtrginac.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrginac.Text) + 1);
			btnprevinac.Enabled = true;
			if (txtpgrwdtrginac.Text == Convert.ToString(gventinact.PageCount))
			{
				btnnextinac.Enabled = false;
			}
			int page = gventinact.PageCount;

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
			htParam.Add("@Steps", txtActName.Text);
			htParam.Add("@IntrgtId", Request.QueryString["IntrgtId"].Trim());
			//htParam.Add("@IsActv", ddlIsActv.SelectedValue.ToString());
			if (chbkIsActv.Checked == true)
			{
				htParam.Add("@IsActv", "Y");
			}
			else
			{
				htParam.Add("@IsActv", "N");
			}
			htParam.Add("@LocatorType", ddlloctyp.SelectedValue.ToString().Trim());
			//htParam.Add("@IsMndtry", ddlIsMndatry.SelectedValue.ToString());
			//htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
			//htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
			htParam.Add("@Xpath", txtXpath.Text);
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
			htParam.Add("@Action", ddlActn.SelectedValue.ToString().Trim());
			htParam.Add("@DfltVal", txtDfltVal.Text);
			//htParam.Add("@PassWrd", txtPsswrd.Text);
			//htParam.Add("@SortOrder", txtSrtOrd.Text);
			//htParam.Add("@IsLicens", ddlIsLcns.SelectedValue.ToString());
			if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				htParam.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@UpdatedDate", Convert.ToDateTime(txtcreatedte.Text));
				if (txtCseDte.Text != "")
				{
					if (chbkIsActv.Checked == true)
					{
						ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Action Cannot be Active');", true);
						return;
					}
					htParam.Add("@CeaseDate", Convert.ToDateTime(txtCseDte.Text));
				}
				else
				{
					htParam.Add("@CeaseDate", DBNull.Value);
				}
				htParam.Add("@Flag", "U");
				htParam.Add("@ActnId", Session["ActnId"]);
			}
			else
			{
				htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
				htParam.Add("@Flag", "S");
			}
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_InsMstIntrgActnTbl", htParam);
			BindGrid(Request.QueryString["IntrgtId"].Trim());
			BindGridInactv(Request.QueryString["IntrgtId"].Trim());
			if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Save";
				lblcreatedte.Text = "Created Date";
				txtCseDte.Enabled = false;
				txtCseDte.Text = "";
			}
			txtActName.Text = "";
			//ddlIsActv.SelectedIndex = 0;
			//ddlIsMndatry.SelectedIndex = 0;
			txtXpath.Text = "";
			ddlActn.SelectedIndex = 0;
			ddlloctyp.SelectedIndex = 0;
			txtDfltVal.Text = "";
			//txtPsswrd.Text = "";
			//txtSrtOrd.Text = GetSrtOrdr();
			//ddlIsLcns.SelectedIndex = 0;
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
			btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update";
			txtCseDte.Enabled = true;
			Label lblCode = (Label)Row.FindControl("lblCode");
			Label lblDesc1 = (Label)Row.FindControl("lblDesc1");
			Label lblXpath = (Label)Row.FindControl("lblXpath");
			Label lblLoctrtyp = (Label)Row.FindControl("lblLoctrtyp");
			Label lblAction = (Label)Row.FindControl("lblAction");
			Label lblDefaultvalue = (Label)Row.FindControl("lblDefaultvalue");
			//Label lblSrtOrdr = (Label)Row.FindControl("lblSrtOrdr");
			//Label lblIsLicense = (Label)Row.FindControl("lblIsLicense");
			Label lblIsActive = (Label)Row.FindControl("lblIsActive");
			//Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
			lblcreatedte.Text = "Updated Date";
			txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			txtActName.Text = lblDesc1.Text;
			txtXpath.Text = lblXpath.Text;
			txtDfltVal.Text = lblDefaultvalue.Text;
			//txtPsswrd.Text= lblIntgPsswrd.Text;
			//txtSrtOrd.Text= lblSrtOrdr.Text;
			//GetddlActnVal();
			ddlActn.SelectedValue = lblAction.Text;
			ddlloctyp.SelectedValue = lblLoctrtyp.Text;
			//ddlIsActv.SelectedItem.Value = lblIsActive.Text;
			if (lblIsActive.Text == "Y")
			{
				chbkIsActv.Checked = true;
			}
			else
			{
				chbkIsActv.Checked = false;
			}
			//ddlIsMndatry.SelectedItem.Value = lblIsMndtry.Text;
			Session["ActnId"] = lblCode.Text;
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

	protected void chbkIsActv_OnCheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (chbkIsActv.Checked != true && btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				txtCseDte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			}
			else
			{
				txtCseDte.Text = "";
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

	protected void lnkEditRwdTrgInac_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update";
			txtCseDte.Enabled = true;
			Label lblCode = (Label)Row.FindControl("lblCodeInac");
			Label lblDesc1 = (Label)Row.FindControl("lblDesc1Inac");
			Label lblLoctrtyp = (Label)Row.FindControl("lblLoctrtypInac");
			Label lblXpath = (Label)Row.FindControl("lblXpathInac");
			Label lblAction = (Label)Row.FindControl("lblActionInac");
			Label lblDefaultvalue = (Label)Row.FindControl("lblDefaultvalueInac");
			//Label lblSrtOrdr = (Label)Row.FindControl("lblSrtOrdr");
			//Label lblIsLicense = (Label)Row.FindControl("lblIsLicense");
			Label lblIsActive = (Label)Row.FindControl("lblIsActiveInac");
			//Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
			lblcreatedte.Text = "Updated Date";
			txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			txtActName.Text = lblDesc1.Text;
			txtXpath.Text = lblXpath.Text;
			txtDfltVal.Text = lblDefaultvalue.Text;
			//txtPsswrd.Text= lblIntgPsswrd.Text;
			//txtSrtOrd.Text= lblSrtOrdr.Text;
			//GetddlActnVal();
			ddlActn.SelectedValue = lblAction.Text;
			ddlloctyp.SelectedValue = lblLoctrtyp.Text;
			//ddlIsActv.SelectedItem.Value = lblIsActive.Text;
			if (lblIsActive.Text == "Y")
			{
				chbkIsActv.Checked = true;
			}
			else
			{
				chbkIsActv.Checked = false;
			}
			//ddlIsMndatry.SelectedItem.Value = lblIsMndtry.Text;
			Session["ActnId"] = lblCode.Text;
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

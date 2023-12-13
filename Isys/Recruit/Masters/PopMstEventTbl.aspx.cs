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

public partial class Application_ISys_Recruit_Masters_PopMstEventTbl : BaseClass
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
			if (Request.QueryString["EvntId"].Trim() == "")
			{
				txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
			}
			else
			{
				FillControl(Request.QueryString["EvntId"].Trim());				
			}
			//BindGrid();

        }
    }

	protected void FillControl(string EvntId)
	{
		btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update";
		lblcreatedte.Text = "Updated Date";
		txtcreatedte.Text = DateTime.Now.ToString("dd/MM/yyyy");
		txtCseDte.Enabled = true;
		ds = new DataSet();
		htParam.Clear();
		ds.Clear();
		htParam.Add("@EvntId", EvntId);
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstEvntTblFillCntl", htParam);
		txtEvntNme.Text = ds.Tables[0].Rows[0]["EvntNme"].ToString().Trim();
		if(ds.Tables[0].Rows[0]["IsMndtry"].ToString().Trim() == "Y")
		{
			chbkIsMndatry.Checked = true;
		}
		else
		{
			chbkIsMndatry.Checked = false;
		}
		if (ds.Tables[0].Rows[0]["IsActv"].ToString().Trim() == "Y")
		{
			chbkIsActv.Checked = true;
		}
		else
		{
			chbkIsActv.Checked = false;
		}
		txtCseDte.Text = ds.Tables[0].Rows[0]["CeaseDate"].ToString().Trim();
	}


	//protected void BindGrid()
 //   {
 //       ds = new DataSet();
 //       htParam.Clear();
 //       ds.Clear();
 //       //ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
	//	ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstEvntTbl", htParam);
	//	if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
 //       {
 //           //hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
 //           //gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
 //           gv_DBFunction.DataSource = ds;
 //           gv_DBFunction.DataBind();
 //           if (gv_DBFunction.PageCount > 1)
 //           {
 //               btnnext.Enabled = true;
 //           }
 //           else
 //           {
 //               btnnext.Enabled = false;
 //           }
 //       }
 //       else
 //       {
 //           ShowNoRecQualTrg(ds.Tables[0], gv_DBFunction);
 //       }
 //       Session["grid"] = ds.Tables[0];
 //       //Session["gridCnt"] = ds.Tables[1];
 //       Session["TblRowCount"] = 0;
 //       ViewState["TblRowCount1"] = 0;
 //   }

 //   private void ShowNoRecQualTrg(DataTable source, GridView gv)
 //   {
 //       source.Rows.Add(source.NewRow());
 //       gv.DataSource = source;
 //       gv.DataBind();
 //       int columnsCount = gv.Columns.Count;
 //       int rowsCount = gv.Rows.Count;
 //       gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
 //       gv.Rows[0].Cells[columnsCount - 1].Text = "";
 //       gv.Rows[0].Cells[columnsCount - 2].Text = "";
 //       //gv.Rows[0].Cells[0].Text = "No targets have been defined";
	//	gv.Rows[0].Cells[0].Text = "No events have been defined";
	//	source.Rows.Clear();
 //   }

 //   #region gv_DBFunction_RowDataBound
 //   protected void gv_DBFunction_RowDataBound(object sender, GridViewRowEventArgs e)
 //   {
 //       if (e.Row.RowType == DataControlRowType.DataRow)
 //       {
 //           //Label lblCode = (Label)e.Row.FindControl("lblCode");
 //           //LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
 //           //lnkEditRwdTrg.Attributes.Add("onclick", "funEditPopUp('" + lblCode.Text + "','grid');return false;");
 //       }
 //   }
 //   #endregion

 //   #region btnprev_Click
 //   protected void btnprev_Click(object sender, EventArgs e)
 //   {
 //       try
 //       {

 //           int pageIndex = gv_DBFunction.PageIndex;
 //           gv_DBFunction.PageIndex = pageIndex - 1;
 //           //BindGrid();
 //           //dtTemp = Session["tmpgrid"] as DataTable;
 //           gv_DBFunction.DataSource = Session["grid"];
 //           gv_DBFunction.DataBind();
 //           txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
 //           if (txtpgrwdtrg.Text == "1")
 //           {
 //               btnprev.Enabled = false;
 //           }
 //           else
 //           {
 //               btnprev.Enabled = true;
 //           }
 //           btnnext.Enabled = true;


 //       }
 //       catch (Exception ex)
 //       {
 //           //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
 //           //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
 //           //string sRet = oInfo.Name;
 //           //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
 //           //String LogClassName = method.ReflectedType.Name;
 //           objErr.LogErr("ISYS-SAIM", "MstAccCycle", "btnprev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
 //       }
 //   }
 //   #endregion

 //   #region btnnext_Click
 //   protected void btnnext_Click(object sender, EventArgs e)
 //   {
 //       try
 //       {
 //           int pageIndex = gv_DBFunction.PageIndex;
 //           gv_DBFunction.PageIndex = pageIndex + 1;
 //           //BindGrid();
 //           gv_DBFunction.DataSource = Session["grid"];
 //           gv_DBFunction.DataBind();
 //           txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
 //           btnprev.Enabled = true;
 //           if (txtpgrwdtrg.Text == Convert.ToString(gv_DBFunction.PageCount))
 //           {
 //               btnnext.Enabled = false;
 //           }
 //           int page = gv_DBFunction.PageCount;

 //       }
 //       catch (Exception ex)
 //       {
 //           //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
 //           //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
 //           //string sRet = oInfo.Name;
 //           //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
 //           //String LogClassName = method.ReflectedType.Name;
 //           objErr.LogErr("ISYS-SAIM", "MstAccCycle", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
 //       }
 //   }
	//#endregion

	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			htParam.Clear();
			ds.Clear();
			htParam.Add("@EvntNme", txtEvntNme.Text);
			if (chbkIsActv.Checked == true)
			{
				htParam.Add("@IsActv", "Y");
			}
			else
			{
				htParam.Add("@IsActv", "N");
			}
			if (chbkIsMndatry.Checked == true)
			{
				htParam.Add("@IsMndtry", "Y");
			}
			else
			{
				htParam.Add("@IsMndtry", "N");
			}
			//htParam.Add("@IsActv", ddlIsActv.SelectedValue.ToString());
			//htParam.Add("@IsMndtry", ddlIsMndatry.SelectedValue.ToString());
			//htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
			//htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
			if(btnSave.Text== "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				htParam.Add("@UpdatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@UpdatedDate", Convert.ToDateTime(txtcreatedte.Text));
				if(txtCseDte.Text != "")
				{
					if(chbkIsActv.Checked == true)
					{
						ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Event Cannot be Active');", true);
						return;
					}
					htParam.Add("@CeaseDate", Convert.ToDateTime(txtCseDte.Text));
				}
				else
				{
					htParam.Add("@CeaseDate", DBNull.Value);
				}
				htParam.Add("@Flag", "U");
				htParam.Add("@EvntId", Request.QueryString["EvntId"].Trim());
			}
			else
			{
				htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
				htParam.Add("@CreatedDate", Convert.ToDateTime(txtcreatedte.Text));
				htParam.Add("@Flag", "S");
			}
			ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_InsMstEvntTbl", htParam);
			if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data has been updated');", true);
			}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data has been saved');", true);
			}
				//BindGrid();
			if (btnSave.Text == "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update")
			{
				//btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Save";
				//lblcreatedte.Text = "Created Date";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel();", true);
			}
			else
			{
				txtEvntNme.Text = "";
				//ddlIsActv.SelectedIndex = 0;
				//ddlIsMndatry.SelectedIndex = 0;
				//txtcreatedte.Text = "";
				//chbkIsActv.Checked = true;
				//chbkIsMndatry.Checked = true;
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

	//protected void lnkEditRwdTrg_Click(object sender, EventArgs e)
	//{
	//	try
	//	{
	//		GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
	//		btnSave.Text = "<span class='glyphicon glyphicon-floppy-disk' style='color: White'> </span> Update";
	//		Label lblCode = (Label)Row.FindControl("lblCode");
	//		Label lblDesc1 = (Label)Row.FindControl("lblDesc1");
	//		Label lblIsActive = (Label)Row.FindControl("lblIsActive");
	//		Label lblIsMndtry = (Label)Row.FindControl("lblIsMndtry");
	//		lblcreatedte.Text = "Updated Date";
	//		txtEvntNme.Text = lblDesc1.Text;
	//		ddlIsActv.SelectedItem.Value = lblIsActive.Text;
	//		ddlIsMndatry.SelectedItem.Value = lblIsMndtry.Text;
	//		Session["EvntId"] = lblCode.Text;
	//	}
	//	catch (Exception ex)
	//	{
	//		string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
	//		System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
	//		string sRet = oInfo.Name;
	//		System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
	//		String LogClassName = method.ReflectedType.Name;
	//		objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
	//	}
	//}
	protected void chbkIsActv_OnCheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (chbkIsActv.Checked != true && Request.QueryString["EvntId"].Trim() != "")
			{
				txtCseDte.Text= DateTime.Now.ToString("dd/MM/yyyy");
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


}

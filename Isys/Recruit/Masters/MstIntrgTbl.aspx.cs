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

public partial class Application_ISys_Recruit_Masters_MstIntrgTbl : BaseClass
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
            BindGrid("");
			BindGridInactv("");
			//txtSrtOrd.Text = GetSrtOrdr();
		}
    }

	//protected string GetSrtOrdr()
	//{
	//	ds = new DataSet();
	//	htParam.Clear();
	//	ds.Clear();
	//	ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetSrtOrdMstIntrgTbl", htParam);
	//	return ds.Tables[0].Rows[0]["SortOrder"].ToString();
	//}


	protected void BindGrid(string IntrgtNme)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		htParam.Add("@IntrgtNme", IntrgtNme);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstIntrgTblSearch", htParam);
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

	protected void BindGridInactv(string IntrgtNme)
	{
		ds = new DataSet();
		htParam.Clear();
		ds.Clear();
		htParam.Add("@IntrgtNme", IntrgtNme);
		//ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstAccCycleDtls", htParam);
		ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstIntrgTblSearchInactv", htParam);
		if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
		{
			//hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
			//gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
			gventinact.DataSource = ds;
			gventinact.DataBind();
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
		gv.Rows[0].Cells[6].Text = "";
		gv.Rows[0].Cells[7].Text = "";
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
			BindGrid("");
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
			BindGrid("");
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
			BindGridInactv("");
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
			BindGridInactv("");
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
			string Param = txtIntgNme.Text;
			BindGrid(Param);
			BindGridInactv(Param);
			txtIntgNme.Text = "";
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			string IntrgtId = "";
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp('" + IntrgtId.ToString().Trim() + "');", true);
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
			Label lblCode = (Label)Row.FindControl("lblCode");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp('" + lblCode.Text.ToString().Trim() + "');", true);
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
	protected void lnkMapTrg_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lblCode1 = (Label)Row.FindControl("lblCode");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp1('" + lblCode1.Text.ToString().Trim() + "');", true);
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

	protected void lnkstpsVew_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lblCode1 = (Label)Row.FindControl("lblCode");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
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

	protected void lnkAgrmnt_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			//Label lblCode1 = (Label)Row.FindControl("lblCode");
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Not Applicable');", true);
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
	protected void lnkIntgURL_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lnkIntgURL = (Label)Row.FindControl("lblIntgURL");
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Not Applicable');", true);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Openwindow('" + lnkIntgURL.Text + "')", true);
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
			Label lblCode = (Label)Row.FindControl("lblCodeInac");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp('" + lblCode.Text.ToString().Trim() + "');", true);
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
	protected void lnkMapTrgInac_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lblCode1 = (Label)Row.FindControl("lblCodeInac");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp1('" + lblCode1.Text.ToString().Trim() + "');", true);
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

	protected void lnkstpsVewInac_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lblCode1 = (Label)Row.FindControl("lblCodeInac");
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
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

	protected void lnkAgrmntInac_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lblCode1 = (Label)Row.FindControl("lblEntyId");
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Not Applicable');", true);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp3('" + lblCode1.Text.ToString().Trim() + "');", true);
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
	protected void lnkIntgURLInac_Click(object sender, EventArgs e)
	{
		try
		{
			GridViewRow Row = ((LinkButton)sender).NamingContainer as GridViewRow;
			Label lnkIntgURL = (Label)Row.FindControl("lblIntgURLInac");
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funEditPopUp2('" + lblCode1.Text.ToString().Trim() + "');", true);
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Not Applicable');", true);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "Openwindow('" + lnkIntgURL.Text + "')", true);
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

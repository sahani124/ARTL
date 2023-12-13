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

public partial class Application_ISys_Saim_Masters_MstType : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
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
        }   
    }
    protected void BindGrid()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstTypeDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
            //gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
            gv_DBFunction.DataSource = ds;
            gv_DBFunction.DataBind();
            if (gv_DBFunction.PageCount > 1)
            {
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
            }
        }
        else
        {
            ShowNoRecQualTrg(ds.Tables[0], gv_DBFunction);
        }
        Session["grid"] = ds.Tables[0];
        Session["gridCnt"] = ds.Tables[1];
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
        gv.Rows[0].Cells[0].Text = "No targets have been defined";
        source.Rows.Clear();
    }
}
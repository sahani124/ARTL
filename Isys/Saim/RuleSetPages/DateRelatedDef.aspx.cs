using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class DateRelatedDef : BaseClass
{
    #region Declarations
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["USERMGMT"].ToString();
    private SqlConnection sqlconn = new SqlConnection();
    private DataSet Ds = new DataSet();
    private SqlCommand cmd = new SqlCommand();
    private SqlDataAdapter sqladpt = new SqlDataAdapter();
 	 SqlDataReader drRead;
    Hashtable htparam = new Hashtable();
    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    DataAccessClass obDAL = new DataAccessClass();
    DataTable dt = new DataTable();
    ErrLog objErr = new ErrLog();
    string Branchcode = "";
    string strkpi_code= String.Empty;	

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            //FillDropDowns(ddlBusiType, "27","","",""); Commented by Abuzar
            GetKPICode();
	   FillDropDowns(ddlDateType, "47", "", " ",strkpi_code);

            ds.Clear();
            ht.Clear();
            if (Request.QueryString["RuleId"] != null)
            {
                if (Request.QueryString["RuleId"].ToString() != "")
                {
                    try
                    {
                        //int strRule = Convert.ToInt16(Request.QueryString["RuleId"].ToString().Trim()); Commented by Abuzar
                        ht.Add("@RecId", Request.QueryString["RuleId"].ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        ht.Add("@RecId", "0");
                    }
                }
                else
                {
                    ht.Add("@RecId", "0");
                }
            }
            ds = obDAL.GetDataSetForPrc_SAIM("PrcGetMST_DateRelatedDef", ht);//Changed by Abuzar on 14/10/2020
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlDateType.SelectedValue = ds.Tables[0].Rows[0]["DateType"].ToString();
                    //ddlBusiType.SelectedValue = ds.Tables[0].Rows[0]["BUSI_TYPE"].ToString(); Commented by Abuzar
                    //TxtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString(); Commented by Abuzar
                    TxtEffFrom.Text = ds.Tables[0].Rows[0]["DateEffectiveFrom"].ToString();
                    TxtEffTo.Text = ds.Tables[0].Rows[0]["DateEffectiveTo"].ToString();
                }
            }
        }
    }
    protected void SAVE_Click(object sender, EventArgs e)
    {
        DateTime datefrom = Convert.ToDateTime(TxtEffFrom.Text.Trim());
        DateTime dateto = Convert.ToDateTime(TxtEffTo.Text.Trim());
        string map = Request.QueryString["mapcode"].ToString();
        if (Request.QueryString["lblfrm"] != null)
        {
            if (Request.QueryString["lblfrm"].ToString().Trim() != "")
            {
                DateTime lblfrm = Convert.ToDateTime(Request.QueryString["lblfrm"].ToString().Trim());
                //if (ddlBusiType.SelectedValue == "NWB") Commented by Abuzar
                //{
                //    //if (ddlDateType.SelectedValue == "D1")
                //    //{
                //    //    if (datefrom != lblfrm)
                //    //    {
                //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Login Date must start from Contest Effective From');", true);
                //    //        return;
                //    //    }
                //    //}

                //    ////if (ddlDateType.SelectedValue == "D2")
                //    ////{
                //    ////    if (datefrom != lblfrm)
                //    ////    {
                //    ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Issue Date must start from Contest Effective From');", true);
                //    ////        return;
                //    ////    }
                //    ////}
                //} Commented by Abuzar
            }
        }

        if (datefrom >= dateto)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter Correct effective Date');", true);
            return;

        }
        
        htparam.Clear();

        if (Request.QueryString["RuleId"].ToString() != "")
        {

            try
            {

                //int strRule = Convert.ToInt16(Request.QueryString["RuleId"]); Commented by Abuzar

                htparam.Add("@RuleId", Request.QueryString["RuleId"].ToString());
            }
            catch (Exception ex)
            {
                htparam.Add("@RuleId", "");

            }


        }

        htparam.Add("@Mapped_Code", Request.QueryString["mapcode"].ToString().Trim());
        // htparam.Add("@BusiType", ddlBusiType.SelectedValue.ToString().Trim()); Commented by Abuzar
        htparam.Add("@Date_Type", ddlDateType.SelectedValue.ToString().Trim());
        htparam.Add("@DateEffectiveFrom", TxtEffFrom.Text.Trim());
        htparam.Add("@DateEffectiveTo", TxtEffTo.Text.Trim());
        // htparam.Add("@Remark", TxtRemark.Text.Trim()); Commented by Abuzar
        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        Ds=obDAL.GetDataSetForPrc_SAIM("Prc_GetData_DateRelatedDef2", htparam);//Changed by Abuzar on 14/10/2020
        if (Ds.Tables.Count > 0)
        {
            string msg1 = string.Empty;
            msg1 = Ds.Tables[0].Rows[0]["MESSAGE"].ToString().Trim();
            if (msg1 == "FAILED")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date related definition already exits');", true);
                return;
            }
        }
        else
        {
            //Button btn = ((Button)PreviousPage.FindControl("Button11"));
            //string str= btn.Text;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);
        }
    }
    //protected void btnCncl_Click(object sender, EventArgs e)
    //{

    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);

    //}
    protected void ddlBusiType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlDateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlBusiType.SelectedValue == "NWB") Commented by Abuzar
        //{ Commented by Abuzar
            if (Request.QueryString["lblfrm"] != null)
            {
                if (Request.QueryString["lblfrm"].ToString().Trim() != "")
                {
                    TxtEffFrom.Text = Request.QueryString["lblfrm"].ToString().Trim();
                }
            }
            if (Request.QueryString["lblto"] != null)
            {
                if (Request.QueryString["lblto"].ToString().Trim() != "")
                {
                    TxtEffTo.Text = Request.QueryString["lblto"].ToString().Trim();
                }
            }
        //} Commented by Abuzar
    }



    private string  GetKPICode()
    {
        DataSet dsCmpCode = new DataSet();
        dsCmpCode.Clear();


      
        Hashtable HTCmpCode = new Hashtable();
        HTCmpCode.Clear();


        HTCmpCode.Add("@MAPPED_CODE",  Request.QueryString["mapcode"].ToString().Trim());

        dsCmpCode = obDAL.GetDataSetForPrc_SAIM("Prc_GETKPI_CODE", HTCmpCode);


        if (dsCmpCode.Tables.Count > 0)
        {
            if (dsCmpCode.Tables[0].Rows.Count > 0)
            {

                strkpi_code = dsCmpCode.Tables[0].Rows[0]["KPI_CODE"].ToString();

            }


        }

        return strkpi_code;
    }



    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg, string strkpi_code)
    {
        try
        {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        ht.Add("@TYPFLG", typflg.ToString().Trim());
	ht.Add("@KPI_CODE", strkpi_code.ToString().Trim());
        drRead = obDAL.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
	   
        }
	
        drRead.Close();
 	ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
	
    }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    }

}
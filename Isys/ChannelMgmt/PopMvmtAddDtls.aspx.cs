using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using DataAccessClassDAL;

public partial class Application_Isys_ChannelMgmt_PopMvmtAddDtls : BaseClass
{
    #region Declaration
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    ErrLog objErr = new ErrLog();
    Hashtable htable = new Hashtable();
    DataAccessClass objDAL = new DataAccessClass();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oCommon.getRadio(rblTypeMkr, "UserTypes", Session["UserLangNum"].ToString(), "", 0);
            foreach (ListItem item in rblTypeMkr.Items)
            {
                if (item.Text == "External")
                {
                    item.Enabled = true; //changed by mrunal on 12.02.18
                }
                else
                {
                    item.Selected = true;
                }
            }
            objCommonU.GetSalesChannel(ddlmvmtchnmkr, "", 1);
            ddlmvmtchnmkr.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtsubclsmkr.Items.Insert(0, new ListItem("Select", ""));
            oCommon.getDropDown(ddlmvmtbsdonmkr, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlmvmtbsdonmkr.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtlvlagttypmkr.Items.Insert(0, new ListItem("Select", ""));

            if (Request.QueryString["ADE"] == "E")
            {
                LoadOnEdit(Convert.ToInt32(Request.QueryString["RowIndex"]));
            }

            if (Request.QueryString["MvmtLvl"] == "0")
            {
                DataSet maker = (DataSet)Session["MvmtDetails"];

                if (maker == null || maker.Tables.Count == 0 || maker.Tables[0].Rows.Count == 0)
                {
                     ddlmvmtchnmkr.SelectedValue = Request.QueryString["chn"].ToString().Trim();
                     GetSubChannel();
                     ddlmvmtsubclsmkr.SelectedValue = Request.QueryString["subchn"].ToString().Trim();
                     ddlmvmtbsdonmkr.SelectedValue = Request.QueryString["bsdon"].ToString().Trim();
                     GetMemType();
                     ddlmvmtlvlagttypmkr.SelectedValue = Request.QueryString["rmt"].ToString().Trim();
                }
            }
            else
            {
                DataSet checker = (DataSet)Session["MvmtCheckerDetails"];
                Label2.Text = "Checker Details";
            }
        }
    }


    protected void ddlmvmtchnmkr_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSubChannel();
    }

    private void GetSubChannel()
    {
        objCommonU.GetUserChnclsChannel(ddlmvmtsubclsmkr, ddlmvmtchnmkr.SelectedValue, 0, HttpContext.Current.Session["UserID"].ToString().Trim());
        ddlmvmtsubclsmkr.Items.Insert(0, new ListItem("Select", ""));
        ddlmvmtbsdonmkr.SelectedValue = "";
        ddlmvmtlvlagttypmkr.Items.Clear();
        ddlmvmtlvlagttypmkr.Items.Insert(0, new ListItem("Select", ""));
        ddlmvmtchnmkr.Focus();
    }

    protected void ddlmvmtbsdonmkr_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetMemType();
    }

    private void GetMemType()
    {
        ddlmvmtlvlagttypmkr.Items.Clear();
        if (ddlmvmtbsdonmkr.SelectedValue == "1")
        {
            if (Request.QueryString["unitrank"] != null)
            {
                if (Request.QueryString["unitrank"].ToString().Trim() != "")
                {
                    GetAgentTypeForSlsChnnlCT(ddlmvmtlvlagttypmkr, ddlmvmtchnmkr.SelectedValue, ddlmvmtbsdonmkr.SelectedValue, ddlmvmtsubclsmkr.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                }
            }
        }
        else if (ddlmvmtbsdonmkr.SelectedValue == "0")
        {
            if (Request.QueryString["unitrank"] != null)
            {
                if (Request.QueryString["unitrank"].ToString().Trim() != "")
                {
                    GetLevelType(ddlmvmtlvlagttypmkr, ddlmvmtchnmkr.SelectedValue, ddlmvmtsubclsmkr.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                }
            }
        }
        ddlmvmtlvlagttypmkr.Items.Insert(0, new ListItem("Select", ""));
        ddlmvmtbsdonmkr.Focus();
    }

    #region GetAgentTypeForSlsChnnlCT Method
    public void GetAgentTypeForSlsChnnlCT(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string urank)
    {
        try
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            string carriercode = "2";

            htable.Clear();

            htable.Add("@BizSrc", strBizSrc);
            htable.Add("@selectedchannel", strChnCls);
            htable.Add("@UnitRnk", urank);

            dsResult = objDAL.GetDataSetForPrc("Prc_getAgentLvl", htable);

            if (dsResult.Tables.Count > 0)
            {
                FillDropDown(ddl, dsResult.Tables[0], "MemType", "MemTypeDesc01");
            }
            dsResult = null;
            strSql = null;
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

    #region GetLevelType Method
    //added by akshay for getting channel based on reporting type
    public void GetLevelType(DropDownList ddl, string strBizSrc, string strChnCls, string UntRnk)
    {
        try
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            htable.Clear();
            htable.Add("@BizSrc", strBizSrc);
            htable.Add("@ChnnlClass", strChnCls);
            htable.Add("@UntRnk", UntRnk);
            dsResult = objDAL.GetDataSetForPrc("Prc_AgnLvl", htable);
            if (dsResult.Tables.Count > 0)
            {
                FillDropDown(ddl, dsResult.Tables[0], "UnitRank", "UnitRank");
            }
            dsResult = null;
            strSql = null;
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

    public void FillDropDown(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
    {
        try
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();
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

    protected void ddlmvmtsubclsmkr_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlmvmtbsdonmkr.SelectedValue = "";
        ddlmvmtlvlagttypmkr.Items.Clear();
        ddlmvmtlvlagttypmkr.Items.Insert(0, new ListItem("Select", ""));
    }

    protected void ddlmvmtlvlagttypmkr_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlmvmtbsdon_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlmvmtchn = (DropDownList)row.FindControl("ddlmvmtchn");
            DropDownList ddlmvmtsubcls = (DropDownList)row.FindControl("ddlmvmtsubcls");
            DropDownList ddlmvmtbsdon = (DropDownList)row.FindControl("ddlmvmtbsdon");
            DropDownList ddlmvmtlvlagttyp = (DropDownList)row.FindControl("ddlmvmtlvlagttyp");
            ddlmvmtlvlagttyp.Items.Clear();
            if (ddlmvmtbsdon.SelectedValue == "1")
            {
                if (Request.QueryString["unitrank"] != null)
                {
                    if (Request.QueryString["unitrank"].ToString().Trim() != "")
                    {
                        GetAgentTypeForSlsChnnlCT(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtbsdon.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                    }
                }
            }
            else if (ddlmvmtbsdon.SelectedValue == "0")
            {
                if (Request.QueryString["unitrank"] != null)
                {
                    if (Request.QueryString["unitrank"].ToString().Trim() != "")
                    {
                        GetLevelType(ddlmvmtlvlagttyp, ddlmvmtchn.SelectedValue, ddlmvmtsubcls.SelectedValue, Request.QueryString["unitrank"].ToString().Trim());
                    }
                }
            }
            ddlmvmtlvlagttyp.Items.Insert(0, new ListItem("Select", ""));
            ddlmvmtbsdon.Focus();
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet maker = (DataSet)Session["MvmtDetails"];
        DataSet checker = (DataSet)Session["MvmtCheckerDetails"];
        Hashtable htmaker = new Hashtable();
        Hashtable htchecker = new Hashtable();

        if (maker == null)
        {
            htmaker.Add("@Flag", "4");
            maker = objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", htmaker);
        }

        if (checker == null)
        {
            htchecker.Add("@Flag", "4");
            checker = objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", htchecker);
        }

        DataTable makerdt = maker.Tables[0];
        DataTable checkerDt = checker.Tables[0];
        DataRow makerRow = maker.Tables[0].NewRow();
        DataRow checkerRow = checker.Tables[0].NewRow();

        if (Request.QueryString["MvmtLvl"] == "0")
        {            
            //DataTable maker = makerChecker.Tables[0];

            if (rblTypeMkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Maker Type')", true);
                rblTypeMkr.Focus();
                return;
            }
            if (ddlmvmtchnmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Hierarchy Name');", true);
                ddlmvmtchnmkr.Focus();
                return;
            }
            if (ddlmvmtsubclsmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Sub Class')", true);
                ddlmvmtsubclsmkr.Focus();
                return;
            }
            if (ddlmvmtbsdonmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Based On')", true);
                ddlmvmtbsdonmkr.Focus();
                return;
            }
            if (ddlmvmtlvlagttypmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Makers Relation Member Type')", true);
                ddlmvmtlvlagttypmkr.Focus();
                return;
            }

            if (txtEffDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date')", true);
                txtEffDate.Focus();
                return;
            }

            string strDate = txtEffDate.Text;
            DateTime dateEntered;
            if (DateTime.TryParseExact(strDate, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateEntered))
            {
                int result = DateTime.Compare(dateEntered, (DateTime.Now).Date);
                if (result < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Effective Date should come after Current Date')", true);
                    txtEffDate.Focus();
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter a valid Effective Date')", true);
                txtEffDate.Focus();
                return;
            }


            if (txtCseDt.Text != "")
            {
                string csdt = txtCseDt.Text;
                DateTime dt;
                if (DateTime.TryParseExact(csdt, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                {
                    int date = DateTime.Compare(dt, dateEntered);
                    if (date < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cease Date cannot be before Effective Date')", true);
                        txtEffDate.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter a valid CeaseDate')", true);
                    txtCseDt.Focus();
                    return;
                }
            }

            DataRow dr = (DataRow)Session["MakerRow"]; // maker row loaded intially

            for (int i = 0; i < makerdt.Rows.Count; i++)
            {
                if (rblTypeMkr.SelectedValue == makerdt.Rows[i]["UserType"].ToString().Trim() && ddlmvmtchnmkr.SelectedValue == makerdt.Rows[i]["Channel"].ToString().Trim() && ddlmvmtsubclsmkr.SelectedValue == makerdt.Rows[i]["SubChannel"].ToString().Trim()
                    && ddlmvmtbsdonmkr.SelectedValue == makerdt.Rows[i]["BasedOn"].ToString().Trim() && ddlmvmtlvlagttypmkr.SelectedValue == makerdt.Rows[i]["MemOrLevelType"].ToString().Trim())
                {
                    if (dr != null)
                    {
                        if (rblTypeMkr.SelectedValue == dr["UserType"].ToString().Trim() && ddlmvmtchnmkr.SelectedValue == dr["Channel"].ToString().Trim() && ddlmvmtsubclsmkr.SelectedValue == dr["SubChannel"].ToString().Trim()
                        && ddlmvmtbsdonmkr.SelectedValue == dr["BasedOn"].ToString().Trim() && ddlmvmtlvlagttypmkr.SelectedValue == dr["MemOrLevelType"].ToString().Trim()) // in case on edit user makes no changes and saves it as it is
                            continue;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Similar Maker already exists')", true);
                    Session["MakerRow"] = null;
                    return;
                }
            }

            if (Request.QueryString["ADE"] == "E")
            {
                int rowIndex = Convert.ToInt32(Request.QueryString["RowIndex"]);
                maker.Tables[0].Rows[rowIndex]["UserType"] = rblTypeMkr.SelectedValue;
                maker.Tables[0].Rows[rowIndex]["Channel"] = ddlmvmtchnmkr.SelectedValue;
                maker.Tables[0].Rows[rowIndex]["SubChannel"] = ddlmvmtsubclsmkr.SelectedValue;
                maker.Tables[0].Rows[rowIndex]["BasedOn"] = ddlmvmtbsdonmkr.SelectedValue;
                maker.Tables[0].Rows[rowIndex]["MemOrLevelType"] = ddlmvmtlvlagttypmkr.SelectedValue;
                maker.Tables[0].Rows[rowIndex]["BizSrcDesc"] = ddlmvmtchnmkr.SelectedItem.Text;
                maker.Tables[0].Rows[rowIndex]["BasedOnDesc"] = ddlmvmtbsdonmkr.SelectedItem.Text;
                maker.Tables[0].Rows[rowIndex]["ParamDesc"] = rblTypeMkr.SelectedItem.Text;
                maker.Tables[0].Rows[rowIndex]["MemTypeDesc"] = ddlmvmtlvlagttypmkr.SelectedItem.Text;
                if (txtCseDt.Text != "")
                {
                    maker.Tables[0].Rows[rowIndex]["CeaseDate"] = txtCseDt.Text;
                    maker.Tables[0].Rows[rowIndex]["CeaseDateDesc"] = "InActive";
                }
                else
                {
                    maker.Tables[0].Rows[rowIndex]["CeaseDateDesc"] = "Delete";
                }
                if (txtEffDate.Text != "")
                {
                    maker.Tables[0].Rows[rowIndex]["EffectiveDate"] = txtEffDate.Text;
                }
            }
            else
            {
                makerRow["UserType"] = rblTypeMkr.SelectedValue;
                makerRow["Channel"] = ddlmvmtchnmkr.SelectedValue;
                makerRow["SubChannel"] = ddlmvmtsubclsmkr.SelectedValue;
                makerRow["BasedOn"] = ddlmvmtbsdonmkr.SelectedValue;
                makerRow["MemOrLevelType"] = ddlmvmtlvlagttypmkr.SelectedValue;
                makerRow["BizSrcDesc"] = ddlmvmtchnmkr.SelectedItem.Text;
                makerRow["ChnClsDesc"] = ddlmvmtsubclsmkr.SelectedItem.Text;
                makerRow["BasedOnDesc"] = ddlmvmtbsdonmkr.SelectedItem.Text;
                makerRow["ParamDesc"] = rblTypeMkr.SelectedItem.Text;
                makerRow["MemTypeDesc"] = ddlmvmtlvlagttypmkr.SelectedItem.Text;
                if (txtCseDt.Text != "")
                {
                    makerRow["CeaseDate"] = txtCseDt.Text;
                    makerRow["CeaseDateDesc"] = "InActive";
                }
                else
                {
                    makerRow["CeaseDateDesc"] = "Delete";
                }
                if (txtEffDate.Text != "")
                {
                    makerRow["EffectiveDate"] = txtEffDate.Text;
                }
                makerRow["MvmtLvl"] = 0;

                maker.Tables[0].Rows.Add(makerRow);
                Session["MvmtDetails"] = maker;
            }
            Response.Redirect("PopMvmtDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim()
            + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&bsdon=" + Request.QueryString["bsdon"] + "&rmt=" + Request.QueryString["rmt"] + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&mdlpopup=mdlpopupmvmtBID", false);
        }
        else
        {
            //DataTable maker = makerChecker.Tables[0];

            if (rblTypeMkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Type')", true);
                rblTypeMkr.Focus();
                return;

            }
            if (ddlmvmtchnmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Hierarchy Name')", true);
                ddlmvmtchnmkr.Focus();
                return;
            }
            if (ddlmvmtsubclsmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Sub Class')", true);
                ddlmvmtsubclsmkr.Focus();
                return;
            }
            if (ddlmvmtbsdonmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Based On')", true);
                ddlmvmtbsdonmkr.Focus();
                return;
            }
            if (ddlmvmtlvlagttypmkr.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Checker Relation Member Type')", true);
                ddlmvmtlvlagttypmkr.Focus();
                return;
            }
            if (txtEffDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective Date')", true);
                txtEffDate.Focus();
                return;
            }

            string strDate = txtEffDate.Text;
            DateTime dateEntered;
            if (DateTime.TryParseExact(strDate, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateEntered))
            {
                int result = DateTime.Compare(dateEntered, (DateTime.Now).Date);
                if (result < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Effective Date should come after Current Date')", true);
                    txtEffDate.Focus();
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter a valid Effective Date')", true);
                txtEffDate.Focus();
                return;
            }


            if (txtCseDt.Text != "")
            {
                string csdt = txtCseDt.Text;
                DateTime dt;
                if (DateTime.TryParseExact(csdt, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                {
                    int date = DateTime.Compare(dt, dateEntered);
                    if (date < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cease Date cannot be before Effective Date')", true);
                        txtEffDate.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter a valid Cease Date')", true);
                    txtCseDt.Focus();
                    return;
                }
            }
            DataRow dr = (DataRow)Session["CheckerRow"];

            for (int i = 0; i < checkerDt.Rows.Count; i++)
            {
                if (rblTypeMkr.SelectedValue == checkerDt.Rows[i]["UserType"].ToString().Trim() && ddlmvmtchnmkr.SelectedValue == checkerDt.Rows[i]["Channel"].ToString().Trim() && ddlmvmtsubclsmkr.SelectedValue == checkerDt.Rows[i]["SubChannel"].ToString().Trim()
                    && ddlmvmtbsdonmkr.SelectedValue == checkerDt.Rows[i]["BasedOn"].ToString().Trim() && ddlmvmtlvlagttypmkr.SelectedValue == checkerDt.Rows[i]["MemOrLevelType"].ToString().Trim())
                {
                    if (dr != null)
                    {
                        if (rblTypeMkr.SelectedValue == dr["UserType"].ToString().Trim() && ddlmvmtchnmkr.SelectedValue == dr["Channel"].ToString().Trim() && ddlmvmtsubclsmkr.SelectedValue == dr["SubChannel"].ToString().Trim()
                        && ddlmvmtbsdonmkr.SelectedValue == dr["BasedOn"].ToString().Trim() && ddlmvmtlvlagttypmkr.SelectedValue == dr["MemOrLevelType"].ToString().Trim()) // in case on edit user makes no changes and saves it as it is
                            continue;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Similar Checker already exists')", true);
                    Session["CheckerRow"] = null;
                    return;
                }
            }

            if (Request.QueryString["ADE"] == "E")
            {
                int relativeRowIndex = Convert.ToInt32(Request.QueryString["RowIndex"]);
                int rowsBeforeindex = 0;
                DataView checkerdt = new DataView(checker.Tables[0]);
                checkerdt.RowFilter = "MvmtLvl < " + Request.QueryString["MvmtLvl"]; 
                DataTable temp = checkerdt.ToTable();
                if (temp.Rows.Count > 0)
                {
                    relativeRowIndex++;
                    rowsBeforeindex = temp.Rows.Count - 1;
                }
                int rowIndex = rowsBeforeindex + relativeRowIndex;
                checker.Tables[0].Rows[rowIndex]["UserType"] = rblTypeMkr.SelectedValue;
                checker.Tables[0].Rows[rowIndex]["Channel"] = ddlmvmtchnmkr.SelectedValue;
                checker.Tables[0].Rows[rowIndex]["SubChannel"] = ddlmvmtsubclsmkr.SelectedValue;
                checker.Tables[0].Rows[rowIndex]["BasedOn"] = ddlmvmtbsdonmkr.SelectedValue;
                checker.Tables[0].Rows[rowIndex]["MemOrLevelType"] = ddlmvmtlvlagttypmkr.SelectedValue;
                checker.Tables[0].Rows[rowIndex]["BizSrcDesc"] = ddlmvmtchnmkr.SelectedItem.Text;
                checker.Tables[0].Rows[rowIndex]["BasedOnDesc"] = ddlmvmtbsdonmkr.SelectedItem.Text;
                checker.Tables[0].Rows[rowIndex]["ParamDesc"] = rblTypeMkr.SelectedItem.Text;
                checker.Tables[0].Rows[rowIndex]["MemTypeDesc"] = ddlmvmtlvlagttypmkr.SelectedItem.Text;
                if (txtCseDt.Text != "")
                {
                    checker.Tables[0].Rows[rowIndex]["CeaseDate"] = txtCseDt.Text;
                    checker.Tables[0].Rows[rowIndex]["CeaseDateDesc"] = "InActive";
                }
                else
                {
                    checker.Tables[0].Rows[rowIndex]["CeaseDateDesc"] = "Delete";
                }
                if (txtEffDate.Text != "")
                {
                    checker.Tables[0].Rows[rowIndex]["EffectiveDate"] = txtEffDate.Text;
                }

            }
            else
            {
                checkerRow["UserType"] = rblTypeMkr.SelectedValue;
                checkerRow["Channel"] = ddlmvmtchnmkr.SelectedValue;
                checkerRow["SubChannel"] = ddlmvmtsubclsmkr.SelectedValue;
                checkerRow["BasedOn"] = ddlmvmtbsdonmkr.SelectedValue;
                checkerRow["MemOrLevelType"] = ddlmvmtlvlagttypmkr.SelectedValue;
                checkerRow["BizSrcDesc"] = ddlmvmtchnmkr.SelectedItem.Text;
                checkerRow["ChnClsDesc"] = ddlmvmtsubclsmkr.SelectedItem.Text;
                checkerRow["BasedOnDesc"] = ddlmvmtbsdonmkr.SelectedItem.Text;
                checkerRow["ParamDesc"] = rblTypeMkr.SelectedItem.Text;
                checkerRow["MemTypeDesc"] = ddlmvmtlvlagttypmkr.SelectedItem.Text;
                checkerRow["MvmtLvl"] = Request.QueryString["MvmtLvl"];
                if (txtCseDt.Text != "")
                {
                    checkerRow["CeaseDate"] = txtCseDt.Text;
                    checkerRow["CeaseDateDesc"] = "InActive";
                }
                else
                {
                    checkerRow["CeaseDateDesc"] = "Delete";
                }
                if (txtEffDate.Text != "")
                {
                    checkerRow["EffectiveDate"] = txtEffDate.Text;
                }
                checker.Tables[0].Rows.Add(checkerRow);
                Session["MvmtCheckerDetails"] = checker;
            }
            if (Session["MakerRow"] != null)
            {
                Session["MakerRow"] = null;
            }
            if(Session["CheckerRow"] != null)
            {
            Session["CheckerRow"] = null;
            }
            Response.Redirect("PopMvmtDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim()
            + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&bsdon=" + Request.QueryString["bsdon"] + "&rmt=" + Request.QueryString["rmt"] + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&mdlpopup=mdlpopupmvmtBID", false);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PopMvmtDtls.aspx?mvmtrule=" + Request.QueryString["mvmtrule"].ToString().Trim()
        + "&chn=" + Request.QueryString["chn"].ToString().Trim() + "&subchn=" + Request.QueryString["subchn"].ToString().Trim() + "&memtype=" + Request.QueryString["memtype"].ToString().Trim() + "&unitrank=" + Request.QueryString["unitrank"].ToString().Trim() + "&bsdon=" + Request.QueryString["bsdon"] + "&rmt=" + Request.QueryString["rmt"] + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&btn=" + Request.QueryString["btn"].ToString().Trim() + "&mdlpopup=mdlpopupmvmtBID", false);
    }

    protected void LoadOnEdit(int RowIndex)
    {
        DataTable maker = new DataTable();
        DataSet makerChecker = new DataSet();

        if (Request.QueryString["MvmtLvl"] == "0")
        {
            makerChecker = (DataSet)Session["MvmtDetails"];
            maker = makerChecker.Tables[0];
            Session["MakerRow"] = maker.Rows[RowIndex];
        }
        else
        {
            makerChecker = (DataSet)Session["MvmtCheckerDetails"];
            DataView checkerView = new DataView(makerChecker.Tables[0]);
            checkerView.RowFilter = "MvmtLvl =" + Request.QueryString["MvmtLvl"];
            maker = checkerView.ToTable();
            Session["CheckerRow"] = maker.Rows[RowIndex];
        }
        string Channel = string.Empty;
        string SubChannel = string.Empty;
        string BasedOn = string.Empty;
        string MemType = string.Empty;
        string UserType = string.Empty;
        string EffDate = string.Empty;
        string CeaseDate = string.Empty;


        Channel = maker.Rows[RowIndex]["Channel"].ToString();
        SubChannel = maker.Rows[RowIndex]["SubChannel"].ToString();
        BasedOn = maker.Rows[RowIndex]["BasedOn"].ToString();
        MemType = maker.Rows[RowIndex]["MemOrLevelType"].ToString();
        UserType = maker.Rows[RowIndex]["UserType"].ToString();
        EffDate = maker.Rows[RowIndex]["EffectiveDate"].ToString().Trim();
        if (EffDate.Length > 10)
            EffDate = EffDate.Substring(0, 10);
            CeaseDate = maker.Rows[RowIndex]["CeaseDate"].ToString().Trim();
        if (CeaseDate.Length > 10)
            CeaseDate = CeaseDate.Substring(0, 10);
        
        rblTypeMkr.SelectedValue = UserType.Trim();
        ddlmvmtchnmkr.SelectedValue = Channel.Trim();
        GetSubChannel();
        ddlmvmtsubclsmkr.SelectedValue = SubChannel.Trim();

        ddlmvmtbsdonmkr.SelectedValue = BasedOn.Trim();
        GetMemType();
        ddlmvmtlvlagttypmkr.SelectedValue = MemType.Trim();
        txtEffDate.Text = EffDate;
        txtCseDt.Text = CeaseDate;
    }
}

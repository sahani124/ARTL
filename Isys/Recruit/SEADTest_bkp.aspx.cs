using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.Xml;
using DataAccessClassDAL;
using System.Text;

public partial class SEADTest : BaseClass
{
    /// <summary>
    ///  This module runs tasks for Questions, Answers and Results for Psychometric SEAD analysis of the Employees.
    /// </summary>

    #region Global Decalration
    int[] UserResponse = new int[36];
    DataAccessClass objDAL = new DataAccessClass();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsQuestions = new DataSet();
    ErrLog objErr = new ErrLog();
    string UserType = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
		 lblName.Text = HttpContext.Current.Session["UserName"].ToString();
            setCodeAndIDforUser();
            fetchQuestions();
            BindDashBoard();
          
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int _result = 0;
        try
        {
            if (validateResponse())
            {
                #region Storage of Values for Analysis
                UserResponse[0] = Convert.ToInt32(hdnbtn1a.Value.ToString());
                UserResponse[1] = Convert.ToInt32(hdnbtn1b.Value.ToString());

                UserResponse[2] = Convert.ToInt32(hdnbtn2a.Value.ToString());
                UserResponse[3] = Convert.ToInt32(hdnbtn2b.Value.ToString());

                UserResponse[4] = Convert.ToInt32(hdnbtn3a.Value.ToString());
                UserResponse[5] = Convert.ToInt32(hdnbtn3b.Value.ToString());

                UserResponse[6] = Convert.ToInt32(hdnbtn4a.Value.ToString());
                UserResponse[7] = Convert.ToInt32(hdnbtn4b.Value.ToString());

                UserResponse[8] = Convert.ToInt32(hdnbtn5a.Value.ToString());
                UserResponse[9] = Convert.ToInt32(hdnbtn5b.Value.ToString());

                UserResponse[10] = Convert.ToInt32(hdnbtn6a.Value.ToString());
                UserResponse[11] = Convert.ToInt32(hdnbtn6b.Value.ToString());

                UserResponse[12] = Convert.ToInt32(hdnbtn7a.Value.ToString());
                UserResponse[13] = Convert.ToInt32(hdnbtn7b.Value.ToString());

                UserResponse[14] = Convert.ToInt32(hdnbtn8a.Value.ToString());
                UserResponse[15] = Convert.ToInt32(hdnbtn8b.Value.ToString());

                UserResponse[16] = Convert.ToInt32(hdnbtn9a.Value.ToString());
                UserResponse[17] = Convert.ToInt32(hdnbtn9b.Value.ToString());

                UserResponse[18] = Convert.ToInt32(hdnbtn10a.Value.ToString());
                UserResponse[19] = Convert.ToInt32(hdnbtn10b.Value.ToString());

                UserResponse[20] = Convert.ToInt32(hdnbtn11a.Value.ToString());
                UserResponse[21] = Convert.ToInt32(hdnbtn11b.Value.ToString());

                UserResponse[22] = Convert.ToInt32(hdnbtn12a.Value.ToString());
                UserResponse[23] = Convert.ToInt32(hdnbtn12b.Value.ToString());

                UserResponse[24] = Convert.ToInt32(hdnbtn13a.Value.ToString());
                UserResponse[25] = Convert.ToInt32(hdnbtn13b.Value.ToString());

                UserResponse[26] = Convert.ToInt32(hdnbtn14a.Value.ToString());
                UserResponse[27] = Convert.ToInt32(hdnbtn14b.Value.ToString());

                UserResponse[28] = Convert.ToInt32(hdnbtn15a.Value.ToString());
                UserResponse[29] = Convert.ToInt32(hdnbtn15b.Value.ToString());

                UserResponse[30] = Convert.ToInt32(hdnbtn16a.Value.ToString());
                UserResponse[31] = Convert.ToInt32(hdnbtn16b.Value.ToString());

                UserResponse[32] = Convert.ToInt32(hdnbtn17a.Value.ToString());
                UserResponse[33] = Convert.ToInt32(hdnbtn17b.Value.ToString());

                UserResponse[34] = Convert.ToInt32(hdnbtn18a.Value.ToString());
                UserResponse[35] = Convert.ToInt32(hdnbtn18b.Value.ToString());

                Hashtable ht = new Hashtable();
                int length = 36;
                int j = 1;
                ht.Clear();
                //Space to fetch the User Id and the Employee Id

                //Sapce Ends
                ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
                ht.Add("@EmpID", Session["strEmpCode"].ToString());
                for (int i = 0; i < length; i++)
                {
                    ht.Add("@Ans" + j, UserResponse[i]);
                    j++;
                }
                #endregion

                _result = objDAL.execute_sprc("prc_InsAnswersForTest", ht);
                
                if (_result > 0)
                {
                #region Perform Analysis of DISC

                #region Save Report
                int totalO = 0;
                int totalG = 0;
                int totalD = 0;
                int totalI = 0;

                totalO = UserResponse[0] + UserResponse[5] + UserResponse[8] + UserResponse[13] + UserResponse[16] + UserResponse[21] + UserResponse[24] + UserResponse[29] + UserResponse[32];
                totalG = UserResponse[1] + UserResponse[4] + UserResponse[9] + UserResponse[12] + UserResponse[17] + UserResponse[20] + UserResponse[25] + UserResponse[28] + UserResponse[33];
                totalD = UserResponse[3] + UserResponse[6] + UserResponse[11] + UserResponse[14] + UserResponse[19] + UserResponse[22] + UserResponse[27] + UserResponse[30] + UserResponse[35];
                totalI = UserResponse[2] + UserResponse[7] + UserResponse[10] + UserResponse[15] + UserResponse[18] + UserResponse[23] + UserResponse[26] + UserResponse[31] + UserResponse[34];

                ht.Clear();
                ht.Add("@TotalforO", totalO);
                ht.Add("@TotalforG", totalG);
                ht.Add("@TotalforI", totalI);
                ht.Add("@TotalforD", totalD);
                ht.Add("@UserId", HttpContext.Current.Session["UserID"].ToString());
                ht.Add("@EmpId", Session["strEmpCode"].ToString());
                objDAL.Common_exec_reader_prc("prc_InsTotalValuesforTest", ht);

                #endregion

                #region Perform Analysis
                if (totalO > totalG && totalI > totalD)
                {
                    //OI-Stable
                    ht.Clear();
                    ht.Add("@Type", "OI");
                }
                if (totalO > totalG && totalD > totalI)
                {
                    //OD- Expressive
                    ht.Clear();
                    ht.Add("@Type", "OD");
                }
                if (totalG > totalO && totalI > totalD)
                {
                    //GI- Analyst
                    ht.Clear();
                    ht.Add("@Type", "GI");
                }
                if (totalG > totalO && totalD > totalI)
                {
                    //GD- Dominant
                    ht.Clear();
                    ht.Add("@Type", "GD");
                }
                DataSet DS = new DataSet();
                DS = objDAL.GetDataSetForPrc("prc_GetCharacteristicsforUser", ht);

                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    String str1 = Convert.ToString(DS.Tables[0].Rows[0]["CharDesc"]);
                    String str2 = Convert.ToString(DS.Tables[0].Rows[0]["CharAnalysis"]);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("bootbox.alert(\"");
                    sb.Append("Thank you for taking this test!");
                    sb.Append("\");");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Js1", sb.ToString(), true);
                }
                #endregion

                #endregion

                #region Display result
                btnSubmit.Enabled = false;

                btnCancel.Text = "Close";
                #endregion
                }
                else
                {
                    btnSubmit.Enabled = false;
                    btnCancel.Text = "Close";
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("bootbox.alert(\"");
                    sb1.Append("This test has been already taken by you! These results will not be stored for analysis.");
                    sb1.Append("\");");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Js2", sb1.ToString(), true);
                }
            }
            else
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("bootbox.alert(\"");
                sb1.Append("You cannot submit an incomplete form. Please answer all questions.");
                sb1.Append("\");");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Js1", sb1.ToString(), true);
            }
            Session.Remove("strEmpCode");
        }
        catch (Exception ex)
        {
            Session.Remove("strEmpCode");
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void fetchQuestions()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htTable = new Hashtable();
            dsResult = null;
            htTable.Clear();
            htTable.Add("@TestType", "PSY");
            dsResult = objDAL.GetDataSetForPrc("prc_GetQuestionsForTest", htTable);
            htTable.Clear();

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                fillQuestions(dsResult);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "Alert3", "alert('No Questions Found to display.');", true);
            }
        }
        catch (Exception ex)
        {
            Session.Remove("strEmpCode");
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void fillQuestions(DataSet ds)
    {
        lbl1a.Text = Convert.ToString(ds.Tables[0].Rows[0]["QSTNDESC"]);
        lbl1b.Text = Convert.ToString(ds.Tables[0].Rows[1]["QSTNDESC"]);

        lbl2a.Text = Convert.ToString(ds.Tables[0].Rows[2]["QSTNDESC"]);
        lbl2b.Text = Convert.ToString(ds.Tables[0].Rows[3]["QSTNDESC"]);

        lbl3a.Text = Convert.ToString(ds.Tables[0].Rows[4]["QSTNDESC"]);
        lbl3b.Text = Convert.ToString(ds.Tables[0].Rows[5]["QSTNDESC"]);

        lbl4a.Text = Convert.ToString(ds.Tables[0].Rows[6]["QSTNDESC"]);
        lbl4b.Text = Convert.ToString(ds.Tables[0].Rows[7]["QSTNDESC"]);

        lbl5a.Text = Convert.ToString(ds.Tables[0].Rows[8]["QSTNDESC"]);
        lbl5b.Text = Convert.ToString(ds.Tables[0].Rows[9]["QSTNDESC"]);

        lbl6a.Text = Convert.ToString(ds.Tables[0].Rows[10]["QSTNDESC"]);
        lbl6b.Text = Convert.ToString(ds.Tables[0].Rows[11]["QSTNDESC"]);

        lbl7a.Text = Convert.ToString(ds.Tables[0].Rows[12]["QSTNDESC"]);
        lbl7b.Text = Convert.ToString(ds.Tables[0].Rows[13]["QSTNDESC"]);

        lbl8a.Text = Convert.ToString(ds.Tables[0].Rows[14]["QSTNDESC"]);
        lbl8b.Text = Convert.ToString(ds.Tables[0].Rows[15]["QSTNDESC"]);

        lbl9a.Text = Convert.ToString(ds.Tables[0].Rows[16]["QSTNDESC"]);
        lbl9b.Text = Convert.ToString(ds.Tables[0].Rows[17]["QSTNDESC"]);

        lbl10a.Text = Convert.ToString(ds.Tables[0].Rows[18]["QSTNDESC"]);
        lbl10b.Text = Convert.ToString(ds.Tables[0].Rows[19]["QSTNDESC"]);

        lbl11a.Text = Convert.ToString(ds.Tables[0].Rows[20]["QSTNDESC"]);
        lbl11b.Text = Convert.ToString(ds.Tables[0].Rows[21]["QSTNDESC"]);

        lbl12a.Text = Convert.ToString(ds.Tables[0].Rows[22]["QSTNDESC"]);
        lbl12b.Text = Convert.ToString(ds.Tables[0].Rows[23]["QSTNDESC"]);

        lbl13a.Text = Convert.ToString(ds.Tables[0].Rows[24]["QSTNDESC"]);
        lbl13b.Text = Convert.ToString(ds.Tables[0].Rows[25]["QSTNDESC"]);

        lbl14a.Text = Convert.ToString(ds.Tables[0].Rows[26]["QSTNDESC"]);
        lbl14b.Text = Convert.ToString(ds.Tables[0].Rows[27]["QSTNDESC"]);

        lbl15a.Text = Convert.ToString(ds.Tables[0].Rows[28]["QSTNDESC"]);
        lbl15b.Text = Convert.ToString(ds.Tables[0].Rows[29]["QSTNDESC"]);

        lbl16a.Text = Convert.ToString(ds.Tables[0].Rows[30]["QSTNDESC"]);
        lbl16b.Text = Convert.ToString(ds.Tables[0].Rows[31]["QSTNDESC"]);

        lbl17a.Text = Convert.ToString(ds.Tables[0].Rows[32]["QSTNDESC"]);
        lbl17b.Text = Convert.ToString(ds.Tables[0].Rows[33]["QSTNDESC"]);

        lbl18a.Text = Convert.ToString(ds.Tables[0].Rows[34]["QSTNDESC"]);
        lbl18b.Text = Convert.ToString(ds.Tables[0].Rows[35]["QSTNDESC"]);
    }

    protected Boolean validateResponse()
    {
        if (hdnbtn1a.Value.ToString() == String.Empty || hdnbtn1b.Value.ToString() == String.Empty || hdnbtn2a.Value.ToString() == String.Empty || hdnbtn2b.Value.ToString() == String.Empty || hdnbtn3a.Value.ToString() == String.Empty || hdnbtn3b.Value.ToString() == String.Empty || hdnbtn4a.Value.ToString() == String.Empty || hdnbtn4b.Value.ToString() == String.Empty || hdnbtn5a.Value.ToString() == String.Empty || hdnbtn5b.Value.ToString() == String.Empty || hdnbtn6a.Value.ToString() == String.Empty || hdnbtn6b.Value.ToString() == String.Empty || hdnbtn7a.Value.ToString() == String.Empty || hdnbtn7b.Value.ToString() == String.Empty || hdnbtn8a.Value.ToString() == String.Empty || hdnbtn8b.Value.ToString() == String.Empty || hdnbtn9a.Value.ToString() == String.Empty || hdnbtn9b.Value.ToString() == String.Empty || hdnbtn10a.Value.ToString() == String.Empty || hdnbtn10b.Value.ToString() == String.Empty || hdnbtn11a.Value.ToString() == String.Empty || hdnbtn11b.Value.ToString() == String.Empty || hdnbtn12a.Value.ToString() == String.Empty || hdnbtn13a.Value.ToString() == String.Empty || hdnbtn13b.Value.ToString() == String.Empty || hdnbtn14a.Value.ToString() == String.Empty || hdnbtn14b.Value.ToString() == String.Empty || hdnbtn15a.Value.ToString() == String.Empty || hdnbtn15b.Value.ToString() == String.Empty || hdnbtn16a.Value.ToString() == String.Empty || hdnbtn16b.Value.ToString() == String.Empty || hdnbtn17a.Value.ToString() == String.Empty || hdnbtn17b.Value.ToString() == String.Empty || hdnbtn18a.Value.ToString() == String.Empty || hdnbtn18b.Value.ToString() == String.Empty)
            return false;
        else
            return true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["strEmpCode"] != null)
        {
            Session.Remove("strEmpCode");
        }
        Response.Redirect("~/Application/ISys/Recruit/assets/Blank.aspx");
    }

    protected void setCodeAndIDforUser()
    {
        DataSet dsTmp = new DataSet();
        Hashtable HT = new Hashtable();
        try
        {
            dsTmp.Clear();
            dsTmp = null;
            HT.Clear();
            HT.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
            dsTmp = objDAL.GetDataSetForPrc_inscdirect("prc_GetEmpCode", HT);
            if (dsTmp.Tables.Count > 0 && dsTmp.Tables[0].Rows.Count > 0)
            { Session["strEmpCode"] = Convert.ToString(dsTmp.Tables[0].Rows[0]["EMPCODE"]); }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "JS3", "alert('This user does not have a employee code or may be he is not an employee.');", true);
                Session["strEmpCode"] = "99999999";
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

    protected void BindDashBoard()
    {
        
        DataSet ds = new DataSet();
        Hashtable htparam = new Hashtable();
        try
        { 
           
            ds.Clear();
            htparam.Clear();
            htparam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDashboardCnt", htparam);
           // ds = objDAL.execute_sprcrecruit("prc_GetDashboardCnt", htparam);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 &&  ds.Tables[0].Rows.Count > 0)
                {
                    lblRegCnt.Text = ds.Tables[0].Rows[0]["RegCount"].ToString();
                    lblBranchCount.Text = ds.Tables[0].Rows[0]["BranchCount"].ToString();
                    lblMobCount.Text = ds.Tables[0].Rows[0]["FlowApp"].ToString();
                    UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                    lblUserCount.Text = ds.Tables[0].Rows[0]["UserCount"].ToString();

                }
            }
            //if (UserType == "E")
            //{
                divSead.Attributes.Add("style","display:none");
                divSead.Visible = false;
                divCount.Visible = true;
                BindDashBoardCnd();
                BindDashBoardBranch();
                BindDashBoardUser();
                //sstblSead.Visible = false;
            //}
            //else {
            //    divSead.Visible = true;
            //    divCount.Visible = false;
            //}
           
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
    protected void BindDashBoardCnd()
    {

        DataSet ds = new DataSet();
        Hashtable htparam = new Hashtable();
        try
        {

            ds.Clear();
            htparam.Clear();
            htparam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
            htparam.Add("@Flag", 2);
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDashboardCnt", htparam);
            // ds = objDAL.execute_sprcrecruit("prc_GetDashboardCnt", htparam);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                   
                    GridCnt.DataSource = ds;
                    GridCnt.DataBind();


                }
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
    protected void BindDashBoardBranch()
    {
       
        DataSet ds = new DataSet();
        Hashtable htparam = new Hashtable();
        try
        {

            ds.Clear();
            htparam.Clear();
            htparam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
            htparam.Add("@Flag", 1);
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDashboardCnt", htparam);
            // ds = objDAL.execute_sprcrecruit("prc_GetDashboardCnt", htparam);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                  
                   GridBranch.DataSource = ds;
                   GridBranch.DataBind();


                }
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
    protected void BindDashBoardUser()
    {

        DataSet ds = new DataSet();
        Hashtable htparam = new Hashtable();
        try
        {

            ds.Clear();
            htparam.Clear();
            htparam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString());
            htparam.Add("@Flag", 3);
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDashboardCnt", htparam);
            // ds = objDAL.execute_sprcrecruit("prc_GetDashboardCnt", htparam);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    GridUser.DataSource = ds;
                    GridUser.DataBind();


                }
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
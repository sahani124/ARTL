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


public partial class Application_Isys_Saim_Rwd_Desc : BaseClass
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
        if(!IsPostBack)
        {
        if (Request.QueryString["cmpcode"].ToString() != null && Request.QueryString["ruleset"].ToString() != null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('page loaded')", true);
        }
        bindReward();
        }
    }

    protected void bindReward()
    {
        DataSet dserrg = new DataSet();
        dserrg.Clear();
        Hashtable hterrg = new Hashtable();
        hterrg.Clear();
        hterrg.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString());
        dserrg = objDal.GetDataSetForPrc_SAIM("PRC_GET_RWD_DESC_BSD_RULESET", hterrg);
        dgRWDDESC.DataSource = dserrg;
        dgRWDDESC.DataBind();
    }
}
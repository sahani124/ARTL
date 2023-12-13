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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;


public partial class Application_ISys_Recruit_DemoPage : BaseClass
{
    #region declaration
    private multilingualManager olng;
    ErrLog objErr = new ErrLog();//Added by rachana on 10-12-2013 for error log
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    private string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ToString();
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsResult = new DataSet();
    DataTable dtResult = new DataTable();
    EncodeDecode ObjDec = new EncodeDecode();
    Hashtable htable = new Hashtable();//Added by rachana on 26-11-2013 
    Hashtable htRprt = new Hashtable();
    DataSet dsRprt = new DataSet();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        lblInfo.Visible = true;
    }  
}
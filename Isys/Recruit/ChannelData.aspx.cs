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
using INSCL.DAL;
using System.Data.SqlClient;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_ISys_ChannelMgmt_ChannelData : BaseClass
{
    DataSet ds = new DataSet();
    Hashtable ht = new Hashtable();
    DataAccessClass objDAL = new DataAccessClass(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid(dgAgency,"Agency");
            FillGrid(dgBanca,"Banca");
            FillGrid(dgDST,"DST");
            FillGrid(dgBrkRel,"BrkRel");
            FillGrid(dgCorp, "CGSGrp");
            FillGrid(dgCorporate, "Corp");
            FillGrid(dgDD, "DirDist");
            FillGrid(dgDirect, "Dir");
            FillGrid(dgDirGrp, "DirGrp");
            FillGrid(dgDirGroup, "DirGroup");
            FillGrid(dgMotor, "Motor");
            FillGrid(dgOther, "Other");
            FillGrid(dgRetail, "Retdirtel");
            FillGrid(dgRGIC, "RGIC");
            FillGrid(dgRural, "Rural");
            FillGrid(dgSME, "SME");
            FillGrid(dgLarge, "LCE");
            FillGrid(dgTravel, "Travel");
            FillGrid(dgWebTele, "WebTel");
        }
    }

    protected void FillGrid(GridView dg,string col)
    {
        ds.Clear();
        ht.Clear();
        ht.Add("@col", col.ToString().Trim());
        ds = objDAL.GetDataSetForPrcCLP("Prc_GetChnlRptCnt", ht);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dg.DataSource = ds;
                    dg.DataBind();
                }
                else
                {
                    dg.DataSource = null;
                    dg.DataBind();
                }
            }
            else
            {
                dg.DataSource = null;
                dg.DataBind();
            }
        }
        else
        {
            dg.DataSource = null;
            dg.DataBind();
        }
    }
}
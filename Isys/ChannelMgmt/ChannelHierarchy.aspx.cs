using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_INSC_ChannelMgmt_ChannelHierarchy : BaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strType = Request.QueryString["T"];
        
        if (strType == "agn")
        {
            string AgntCode = Request.QueryString["A"];
            string Flag = Request.QueryString["Flag"];
            //string PrmyMgrCode = Request.QueryString["p"];
            iframe1.Attributes["src"] = "http://192.168.0.100/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&A= " + AgntCode + "&T=" + strType + "&Flag=" + Flag + "";
        }
        else
        {
            string BizSrc = Request.QueryString["B"];

            if (strType == "sbchhum" || strType == "sbchloc")
            {
                string strChnCls = Request.QueryString["C"];
                iframe1.Attributes["src"] = "http://192.168.0.100/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&B=" + BizSrc + "&T=" + strType + "&C=" + strChnCls + "";
            }
            else 
            {
                if (strType == "Branch")
                {
                    BizSrc = Request.QueryString["ChannelCode"];
                    string UnitCode = Request.QueryString["RptUntCode"];
                    iframe1.Attributes["src"] = "http://192.168.0.100/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&B=" + BizSrc + "&T=" + strType + "&U=" + UnitCode + "";
                }

                else
                {
                    iframe1.Attributes["src"] = "http://192.168.0.100/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&B=" + BizSrc + "&T=" + strType + "";
                }
            }
        }
    }
}
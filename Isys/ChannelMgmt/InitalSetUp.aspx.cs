using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using DataAccessClassDAL;

public partial class Application_ISys_ChannelMgmt_InitalSetUp : BaseClass
{

    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam1 = new Hashtable();
    DataSet dsdataset = new DataSet();
    string bizsrc;
    string chnldesc;
    string sortorder;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            htParam1.Add("@ChannelType", "O");
            dsdataset = objDAL.GetDataSetForPrcCLP("prc_ChannelSetup", htParam1);

            if (dsdataset != null)
            {
                if (dsdataset.Tables[0].Rows.Count > 0)
                {
                    LnkAdd.Enabled = false;
                    LnkView.Enabled = true;            
                  //  LnkChange.Enabled = true;
                    bizsrc = dsdataset.Tables[0].Rows[0]["BizSrc"].ToString();
                    chnldesc = dsdataset.Tables[0].Rows[0]["ChannelDesc01"].ToString();
                    sortorder = dsdataset.Tables[0].Rows[0]["SortOrder"].ToString();
                }
            }

            LnkView.Attributes.Add("onclick", "funcShowPopup('" + bizsrc + "');return false;");
            LnkAddChannel.Attributes.Add("onclick", "funcAddPopup('" + bizsrc + "');return false;");
            //LnkViewSub.Attributes.Add("onclick", "funcAddPopup('" + bizsrc + "','Flag=2');return false;");
            //LnkViewChannel.Attributes.Add("onclick", "funcShowPopup('" + bizsrc + "');return false;");
            LnkAddSub.Attributes.Add("onclick", "funcAddSubPopup('" + bizsrc + "');return false;");
            LnkAddUR.Attributes.Add("onclick", "funcAddUR('" + bizsrc + "');return false;");
            LnkAddUT.Attributes.Add("onclick", "funcAddUT('" + bizsrc + "');return false;");
            LnkAddMT.Attributes.Add("onclick", "funcAddMT('" + bizsrc + "');return false;");
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
    protected void LnkAdd_Click(object sender, EventArgs e)
    {
       
        //Response.Redirect("ChannelSetup.aspx?ChnTyp=O&flag=IN", false);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcAddPopup();", true);
    }
    protected void LnkAddChannel_Click(object sender, EventArgs e)
    {

        
       
    }
    protected void LnkView_Click(object sender, EventArgs e)
    {
       // Response.Redirect("ChannelSetup.aspx?ChnTyp=C&flag=V&ChnCls=" + bizsrc, false);
       // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcShowPopup('" + bizsrc + "');", true);
    }
    protected void LnkChange_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ChannelSetup.aspx?flag=C&ChnCls=" + bizsrc + "&ComChannelDesc01=" + chnldesc + "&ComSortOrder=" + sortorder);
    }
    protected void LnkViewChannel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataView.aspx?flag=1", false); 
    }
    protected void LnkAddSub_Click(object sender, EventArgs e)
    {

    }
    protected void LnkAddUR_Click(object sender, EventArgs e)
    {

    }
    protected void LnkAddUT_Click(object sender, EventArgs e)
    {

    }
    protected void LnkAddMT_Click(object sender, EventArgs e)
    {

    }
    protected void LnkViewSub_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataView.aspx?flag=2", false); 
    }
    protected void LnkViewUR_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dataview_Unitrank.aspx", false); 
    }
    protected void LnkViewUT_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataView_TypeSetup.aspx", false); 
    }
    protected void LnkViewMT_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataView_MemTypeSetup.aspx", false); 
    }
}
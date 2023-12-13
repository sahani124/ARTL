using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Collections;
using System.Data;

public partial class Application_Isys_Recruit_Dashboard : BaseClass
{
    DataAccessClass DALL = new DataAccessClass();
    Hashtable ht = new Hashtable();
    DataSet ds = new DataSet();
    string Psop;
    string Sprtl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Psop = Request.QueryString["Flag"];
            ddlDashBoard.SelectedValue = Psop;
            GetDashBoardData();
            Disabled();
        }
    }

    protected void ddlDashBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Disabled();
        GetDashBoardData();
    }

    public void GetDashBoardData()
    {
        ht.Clear();
        ds.Clear();
        ht.Add("@Flag", ddlDashBoard.SelectedValue);
        ds = DALL.GetDataSetForPrcRecruit("Prc_Get_IndPopData", ht);
        if (ds.Tables.Count > 0)
        {
            if (ddlDashBoard.SelectedValue=="IS")
            {
                //individual data bind
                lblIndPndngCndReg.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngCndReg"].ToString().Trim());
                lblinPndngDocUpld.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngDocUpld"].ToString().Trim());
                lblinPndngAgntPro.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngAgntPro"].ToString().Trim());
                lblinAgntProCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgntProCom"].ToString().Trim());
                lblinPndngFees.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFees"].ToString().Trim());
                lblinPndngFeesWaiApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFeesWaiApp"].ToString().Trim());
                lblinPndngQltychk.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngQltychk"].ToString().Trim());
                lblinCFRRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFRRaised"].ToString().Trim());
                lblindQltyChckCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["QltyChckCom"].ToString().Trim());
                lblinAgntProCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgntProCom"].ToString().Trim());
                lblindPndngCmpstApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngCmpstApp"].ToString().Trim());
                lblinPndngURNGnrtn.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngURNGnrtn"].ToString().Trim());
                lblinURNGenReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["URNGenReq"].ToString().Trim());
                lblSpoPenQltyChk.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpoPenQltyChk"].ToString().Trim());
                lblinPndngMoCkTstComp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngMoCkTstComp"].ToString().Trim());
                lblindTrainSltAllc.Text = Convert.ToString(ds.Tables[0].Rows[0]["TrainSltAllc"].ToString().Trim());
                lblindPndngPrfrdDtSlctn.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngPrfrdDtSlctn"].ToString().Trim());
                lblindPndngPrfrdDtApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngPrfrdDtApp"].ToString().Trim());
                lblindExmSchRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExmSchRqustd"].ToString().Trim());
                lblindSpnsrdExmSltAll.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpnsrdExmSltAll"].ToString().Trim());
                lblindLicensed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Licensed"].ToString().Trim());
                lblindLcnsdExprd.Text = Convert.ToString(ds.Tables[0].Rows[0]["LcnsdExprd"].ToString().Trim());
                lblindCndRjctd.Text = Convert.ToString(ds.Tables[0].Rows[0]["CndRjctd"].ToString().Trim());
                lblindNOCRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCRqustd"].ToString().Trim());
                lblindNOCAppByBM.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCAppByBM"].ToString().Trim());
                lblindPndngslsApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngslsApp"].ToString().Trim());
                lblindNOCApproved.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCApproved"].ToString().Trim());
                lblindPndngngRexm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngngRexm"].ToString().Trim());
            }
            if(ddlDashBoard.SelectedValue == "PS")
            {
                //Posp Data Bind
                lblpospPndngPANVrfctn.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngPANVrfctn"].ToString().Trim());
                lblpospPndngCndReg.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngCndReg"].ToString().Trim());
                lblpospPndngDocUpld.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngDocUpld"].ToString().Trim());
                lblpospPndngAgntPro.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngAgntPro"].ToString().Trim());
                lblpospAgntProCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgntProCom"].ToString().Trim());
                lblpospPndngFees.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFees"].ToString().Trim());
                lblpospPndngFeesWaiApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFeesWaiApp"].ToString().Trim());
                lblpospPndngQltychk.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngQltychk"].ToString().Trim());
                lblpospCFRRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFRRaised"].ToString().Trim());
                lblpospQltyChckCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["QltyChckCom"].ToString().Trim());
                lblpospPndngMoCkTstComp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngMoCkTstComp"].ToString().Trim());
                lblpospTrainSltAllc.Text = Convert.ToString(ds.Tables[0].Rows[0]["TrainSltAllc"].ToString().Trim());
                lblpopExmSchRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExmSchRqustd"].ToString().Trim());
                lblpospExmSltAll.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExmSltAll"].ToString().Trim());
                lblpospUIDGnrtnpndng.Text = Convert.ToString(ds.Tables[0].Rows[0]["UIDGnrtnpndng"].ToString().Trim());
                lblpospLicensed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Licensed"].ToString().Trim());
                lblpospPndngngRexm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngngRexm"].ToString().Trim());
                lblpospCndRej.Text = Convert.ToString(ds.Tables[0].Rows[0]["CndRej"].ToString().Trim());
                lblpospNOCRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCRqustd"].ToString().Trim());
                lblpospNOCAppByBM.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCAppByBM"].ToString().Trim());
                lblpospPndngslsApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngslsApp"].ToString().Trim());
                lblpospNOCApproved.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCApproved"].ToString().Trim());
            }
            if (ddlDashBoard.SelectedValue == "SP")
            {
                //individual data bind
                sprtlPndngCndReg.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngCndReg"].ToString().Trim());
                sprtlPndngDocUpld.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngDocUpld"].ToString().Trim());
                sprtlPndngAgntPro.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngAgntPro"].ToString().Trim());
                sprtlAgntProCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgntProCom"].ToString().Trim());
                sprtlPndngFees.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFees"].ToString().Trim());
                sprtlPndngFeesWaiApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngFeesWaiApp"].ToString().Trim());
                sprtlPndngQltychk.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngQltychk"].ToString().Trim());
                sprtlCFRRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFRRaised"].ToString().Trim());
                sprtldQltyChckCom.Text = Convert.ToString(ds.Tables[0].Rows[0]["QltyChckCom"].ToString().Trim());
                sprtldPndngCmpstApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgntProCom"].ToString().Trim());
                sprtldPndngCmpstApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngCmpstApp"].ToString().Trim());
                sprtlPndngURNGnrtn.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngURNGnrtn"].ToString().Trim());
                sprtlURNGenReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["URNGenReq"].ToString().Trim());
                sprtlSpoPenQltyChk.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpoPenQltyChk"].ToString().Trim());
                sprtlPndngMoCkTstComp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngMoCkTstComp"].ToString().Trim());
                sprtldTrainSltAllc.Text = Convert.ToString(ds.Tables[0].Rows[0]["TrainSltAllc"].ToString().Trim());
                sprtldPndngPrfrdDtSlctn.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngPrfrdDtSlctn"].ToString().Trim());
                sprtldPndngPrfrdDtApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngPrfrdDtApp"].ToString().Trim());
                sprtldExmSchRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExmSchRqustd"].ToString().Trim());
                sprtldSpnsrdExmSltAll.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpnsrdExmSltAll"].ToString().Trim());
                sprtldLicensed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Licensed"].ToString().Trim());
                //sprtldPndngslsApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["LcnsdExprd"].ToString().Trim());
                //sprtldNOCApproved.Text = Convert.ToString(ds.Tables[0].Rows[0]["CndRjctd"].ToString().Trim());
                sprtldNOCRqustd.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCRqustd"].ToString().Trim());
                sprtldNOCAppByBM.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCAppByBM"].ToString().Trim());
                sprtldPndngslsApp.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngslsApp"].ToString().Trim());
                sprtldNOCApproved.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOCApproved"].ToString().Trim());
                sprtldPndngngRexm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PndngngRexm"].ToString().Trim());
                sprtldLcnsdExprd.Text= Convert.ToString(ds.Tables[0].Rows[0]["LcnsdExprd"].ToString().Trim());
                sprtldCndRjctd.Text = Convert.ToString(ds.Tables[0].Rows[0]["CndRjctd"].ToString().Trim());
            }
        }
    }

    public void Disabled()
    {
        if (ddlDashBoard.SelectedValue == "IS")
        {
            divimg.Attributes.Add("style", "display:block");
            divPosp.Attributes.Add("style", "display:none");
            divsprtl.Attributes.Add("style", "display:none");
        }
        if (ddlDashBoard.SelectedValue == "PS")
        {
            divPosp.Attributes.Add("style", "display:block");
            divimg.Attributes.Add("style", "display:none");
            divsprtl.Attributes.Add("style", "display:none");
        }
        if (ddlDashBoard.SelectedValue == "SP")
        {
            divsprtl.Attributes.Add("style", "display:block");
            divPosp.Attributes.Add("style", "display:none");
            divimg.Attributes.Add("style", "display:none");
        }
    }
}
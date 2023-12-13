using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_FireQuotation : BaseClass
{

    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillState();
            BindNOcc();
            BindAddOnCvrs();
        }
        BindSumInsu();
    }

    protected void BindNOcc()
    {
        dt = new DataTable();
        dt.Columns.Add("North");
        dt.Columns.Add("South");
        dt.Columns.Add("East");
        dt.Columns.Add("West");

        DataRow dr = dt.NewRow();
        dr["North"] = "";
        dr["South"] = "";
        dr["East"] = "";
        dr["West"] = "";
        dt.Rows.Add(dr);

        dgNghOccup.DataSource = dt;
        dgNghOccup.DataBind();
        ////dgNghOccup.Rows[0].Cells[0].Text = "No records to display";
    }

    protected void BindSumInChld(string value)
    {
        dt = new DataTable();
        dt.Columns.Add("Desc");
        dt.Columns.Add("SumInsu");

        if (value == "Building")
        {
            DataRow dr = dt.NewRow();
            dr["Desc"] = "Super Structure";
            dr["SumInsu"] = "5000";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Desc"] = "Plinth and Foundation";
            dr["SumInsu"] = "5000";
            dt.Rows.Add(dr);
        }
        else if (value == "Stocks")
        {
            DataRow dr = dt.NewRow();
            dr["Desc"] = "Raw material";
            dr["SumInsu"] = "2500";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Desc"] = "Stocks in Process";
            dr["SumInsu"] = "2500";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Desc"] = "Finished Goods";
            dr["SumInsu"] = "5000";
            dt.Rows.Add(dr);
        }

        dgSumInChld.DataSource = dt;
        dgSumInChld.DataBind();
    }

    protected void BindSumInsu()
    {
        dt = new DataTable();
        dt.Columns.Add("Desc");
        dt.Columns.Add("SumInsu");

        DataRow dr = dt.NewRow();
        dr["Desc"] = "Building";
        dr["SumInsu"] = "10000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Desc"] = "Furniture’s and Fixtures";
        dr["SumInsu"] = "10000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Desc"] = "Plant and Machinery";
        dr["SumInsu"] = "10000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Desc"] = "Stocks";
        dr["SumInsu"] = "10000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Desc"] = "Others";
        dr["SumInsu"] = "10000";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Desc"] = "Total";
        dr["SumInsu"] = "50000";
        dt.Rows.Add(dr);

        dgSumInsu.DataSource = dt;
        dgSumInsu.DataBind();
    }
    protected void dgSumInsu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView dgSumInChld = (GridView)e.Row.FindControl("dgSumInChld");
            string desc = dgSumInsu.DataKeys[e.Row.RowIndex].Value.ToString();
            BindSumInChld(desc.ToString().Trim());
        }
    }

    protected void BindClmHst()
    {
        dt = new DataTable();
        dt.Columns.Add("SrNo");
        dt.Columns.Add("Year");
        dt.Columns.Add("ClmTyp");
        dt.Columns.Add("ClmAmt");
        dt.Columns.Add("PdRpt");

        DataRow dr = dt.NewRow();
        dr["SrNo"] = "1";
        dr["Year"] = "2014-2015";
        dr["ClmTyp"] = "Claim 1";
        dr["ClmAmt"] = "1000";
        dr["PdRpt"] = "Paid";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["SrNo"] = "2";
        dr["Year"] = "2013-2014";
        dr["ClmTyp"] = "Claim 2";
        dr["ClmAmt"] = "1000";
        dr["PdRpt"] = "Reputed";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["SrNo"] = "3";
        dr["Year"] = "2012-2013";
        dr["ClmTyp"] = "Claim 3";
        dr["ClmAmt"] = "1000";
        dr["PdRpt"] = "Reputed";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["SrNo"] = "4";
        dr["Year"] = "2011-2012";
        dr["ClmTyp"] = "Claim 4";
        dr["ClmAmt"] = "1000";
        dr["PdRpt"] = "Paid";
        dt.Rows.Add(dr);

        dgClmHst.DataSource = dt;
        dgClmHst.DataBind();
    }

    protected void BindAddOnCvrs()
    {
        dt = new DataTable();
        dt.Columns.Add("CvrsVal");
        dt.Columns.Add("CvrsDesc");

        DataRow dr = dt.NewRow();
        dr["CvrsVal"] = "1";
        dr["CvrsDesc"] = "Architects, Surveyors and Consulting Engineers Fees <br />( in excess of 3% claim amount) not exceeding the specified amount ( Policy rate should be applied on selected amount)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "2";
        dr["CvrsDesc"] = "Removal of Debris (in excess of 1% claim amount)not exceeding the specified amount .<br />Policy rate should be applied on selected amount)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "3";
        dr["CvrsDesc"] = "A.  Deterioration of Stocks in Cold Storage premises due to accidental power failure consequent to damage at the premises<br /> of Power Station due to an insured peril. <br /> B. Deterioration of stocks in cold storage premises due to change in temperature arising out of loss or<br /> damage to the cold storage machinery (ies) in the Insured’s  premises due to operation of insured peri";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "4";
        dr["CvrsDesc"] = "Forest Fire( SI to be Specified and the rate is 5% to be applied on specified amount)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "5";
        dr["CvrsDesc"] = "Impact Damage due to Insured’s own Rail/Road Vehicles, Forklifts, Cranes, Stackers and the like and articles dropped there from <br />(SI should be policy SI and Rate should be 5% of Policy Rate)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "6";
        dr["CvrsDesc"] = "Spontaneous Combustion. Category of Commodity<br />(SI should be selected by Insured same should be entered manually)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "7";
        dr["CvrsDesc"] = "Omission to Insure additions, alterations or extensions <br />( SI to be selected by Insured but not exceeding the 5% of the SI, Rate should be the Policy Rate)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "8";
        dr["CvrsDesc"] = "Earthquake (Fire and Shock)<br />if Floater is opted The Highest rate should be captured from the tariff amongst the Floater Locations.<br />If  Floater is not opted EQ rate is captured based on the zone selected";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "9";
        dr["CvrsDesc"] = "Spoilage Material Damage Cover SI for Stocks in specified blocks to be selected by the Insured<br /> (Rate should be 5 times of the Policy Rate). <br />SI for Machinery, Containers &Equipments<br /> in specified blocks to be selected by Insured (Rate should be 2.5 Time of the Policy Rate).";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "10";
        dr["CvrsDesc"] = "Leakage And Contamination Cover -<br /> Only Leakage required/ Or Leakage and contamination both required Location – <br />Within the insured premises or elsewhere (Accordingly rate should be captured from Tariff)";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "11";
        dr["CvrsDesc"] = "Temporary Removal of Stokes Clause";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "12";
        dr["CvrsDesc"] = "Loss of Rent clause.";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "13";
        dr["CvrsDesc"] = "Insurance Of Additional Expenses of Rent For An alternative Accommodation";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "14";
        dr["CvrsDesc"] = "Start-upExpenses ";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "15";
        dr["CvrsDesc"] = "Terrorism";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["CvrsVal"] = "16";
        dr["CvrsDesc"] = "Escalation";
        dt.Rows.Add(dr);

        //chkAddOnCvrs.DataSource = dt;
        //chkAddOnCvrs.DataTextField = "CvrsDesc";
        //chkAddOnCvrs.DataValueField = "CvrsVal";
        //chkAddOnCvrs.DataBind();

        dgAddOnCvrs.DataSource = dt;
        dgAddOnCvrs.DataBind();

    }
    protected void ddlBusiType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBusiType.SelectedValue == "I")
        {
            trBrkAgn.Visible = true;
            trBnk.Visible = true;
        }
        else
        {
            trBnk.Visible = false;
            trBrkAgn.Visible = false;
        }
    }
    protected void ddlRenType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRenType.SelectedValue == "Oth")
        {
            trPolNo.Visible = true;
        }
        else
        {
            trPolNo.Visible = true;
        }
    }
    protected void ddlTrnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrnType.SelectedValue == "R")
        {
            trRenTyp.Visible = true;
        }
        else
        {
            trRenTyp.Visible = false;
        }
    }
    protected void rblHypo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblHypo.SelectedValue == "Y")
        {
            trBnkNm.Visible = true;
        }
        else
        {
            trBnkNm.Visible = false;
        }
    }
    protected void rblClaim_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblClaim.SelectedValue == "Y")
        {
            trClmHst.Visible = true;
            BindClmHst();
        }
        else
        {
            trClmHst.Visible = false;
            dgClmHst.DataSource = null;
            dgClmHst.DataBind();
        }
    }

    protected void FillState()
    {
        dt = new DataTable();
        dt.Columns.Add("StValue");
        dt.Columns.Add("StDesc");

        DataRow dr = dt.NewRow();
        dr["StValue"] = "";
        dr["StDesc"] = "-- Select --";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "1";
        dr["StDesc"] = "Andaman & Nicobar";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "2";
        dr["StDesc"] = "Andhra Pradesh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "3";
        dr["StDesc"] = " Arunachal Pradesh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "4";
        dr["StDesc"] = "Assam";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "5";
        dr["StDesc"] = "Bihar";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "6";
        dr["StDesc"] = "Chandigarh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "7";
        dr["StDesc"] = "Chhattisgarh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "8";
        dr["StDesc"] = "Daman & Diu";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "9";
        dr["StDesc"] = "Delhi";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "10";
        dr["StDesc"] = "Dadra & Nagar Haveli";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "11";
        dr["StDesc"] = "Uttar Pradesh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "12";
        dr["StDesc"] = "Goa";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "13";
        dr["StDesc"] = "Gujarat";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "14";
        dr["StDesc"] = "Haryana";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "15";
        dr["StDesc"] = "Himachal Pradesh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "16";
        dr["StDesc"] = "Jharkhand";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "17";
        dr["StDesc"] = "Jammu & Kashmir";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "18";
        dr["StDesc"] = "Karnataka";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "19";
        dr["StDesc"] = "Kerala";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "20";
        dr["StDesc"] = "Lakshadweep";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "21";
        dr["StDesc"] = "Maharashtra";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "22";
        dr["StDesc"] = "Meghalaya";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "23";
        dr["StDesc"] = "Mizoram";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "24";
        dr["StDesc"] = "Manipur";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "25";
        dr["StDesc"] = "Madhya Pradesh";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "26";
        dr["StDesc"] = "Nagaland";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "27";
        dr["StDesc"] = "Orissa";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "28";
        dr["StDesc"] = "Pondicherry";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "29";
        dr["StDesc"] = "Punjab";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "30";
        dr["StDesc"] = "Rajasthan";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["StValue"] = "31";
        dr["StDesc"] = "Other";
        dt.Rows.Add(dr);

        ddlState.DataSource = dt;
        ddlState.DataTextField = "StDesc";
        ddlState.DataValueField = "StValue";
        ddlState.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void rblFltReq_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblFltReq.SelectedValue == "Y")
        {
            trLoc.Visible = true;
            trLocDtls.Visible = true;
        }
        else
        {
            trLoc.Visible = false;
            trLocDtls.Visible = false;
        }
    }
}
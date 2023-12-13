using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DataAccessClassDAL;
using System.Collections;
using System.Text;

using System.IO;

public partial class Application_ISys_Saim_SaimPopup : BaseClass
{
    DataAccessClassDAL.DataAccessClass obj = new DataAccessClassDAL.DataAccessClass();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            Hashtable ht2 = new Hashtable();
            string str2 = "";

            string strvalue = "8000001";// Request.QueryString["MemberID"].ToString();

            string strcyclevalue ="C1"; //Request.QueryString["cycle"].ToString();


            //string strvalue = "F0156";
            //string  strcyclevalue = "F0156";



            Hashtable ht = new Hashtable();

            ht.Add("@CycleCode", strcyclevalue);
            ht.Add("@AGENTCODE", strvalue);
            ht.Add("@CONTESTCODE", "C1");


            ds = obj.GetDataSetForPrcDBConn("GetPolDtls", ht, "SAIMConnectionString");

           

            str2 = str2 + "<table  width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'><tr><td style='width:30%;'>Agent Code</td><td>" + strvalue + "</td><td style='width:30%;'>Contest Name</td><td>" + " FANTASTIC FEBRUARY CONTEST" + "</td></tr>";

            str2 = str2 + "<tr><td style='width:30%;'>Agent Name</td><td>" + "Ashish Kumar" + "</td><td style='width:30%;'>Statement Date</td><td>" + DateTime.Today.ToShortDateString() + "</td></tr></table>";



            if (ds.Tables[1].Rows.Count > 0)
            {
                int dscount = ds.Tables[1].Rows.Count;
                str2 = str2 + "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'> <tr bgcolor='#0099FF'   ><td colspan='6'><b>" + "Agent Performance" + "</b></td></tr><tr><th>KPI Code</th><th>KPI Description </th><th> Achievement </th><th></th><th> </th><th> </th></tr>";
                for (int ij = 0; ij < dscount; ij++)
                {
                    str2 = str2 + "<tr><td>";

                    str2 = str2 + "" + ds.Tables[1].Rows[ij][0].ToString() + "</td>";
                    str2 = str2 + "<td>";

                    str2 = str2 + "" + ds.Tables[1].Rows[ij][1].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                   // str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][2]), 2).ToString() + "</td>";
                    if (ds.Tables[1].Rows[ij][2].ToString().Contains("Rew"))
                    {
                        str2 = str2 + "<b>";
                    }

                    str2 = str2 + "" + ds.Tables[1].Rows[ij][2].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                    if (ds.Tables[1].Rows[ij][2].ToString().Contains("Rew"))
                    {
                        str2 = str2 + "</b>";
                    }
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][3]), 2).ToString() + "</td>";
                    str2 = str2 + "" + ds.Tables[1].Rows[ij][3].ToString() + "</td>";
                    str2 = str2 + "<td  align='center'>";

                    if (ds.Tables[1].Rows[ij][2].ToString().Contains("Rew"))
                    {
                        str2 = str2 + "<b>";
                    }
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][4]), 0).ToString() + "</td>";
                    str2 = str2 + "" + ds.Tables[1].Rows[ij][4].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                    if (ds.Tables[1].Rows[ij][2].ToString().Contains("Rew"))
                    {
                        str2 = str2 + "</b>";
                    }
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                    str2 = str2 + "" + ds.Tables[1].Rows[ij][5].ToString() + "</td> </tr>";
                }
                str2 = str2 + "</table>";
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                int dscount = ds.Tables[2].Rows.Count;
                str2 = str2 + "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'> <tr bgcolor='#0099FF'   ><td colspan='8'><b>" + "Achievement" + "</b></td></tr><tr><th>Accumulation Cycle</th><th> KPI Description </th><th>KPI Achieved</th><th>KPI Utilized </th><th> KPI Carried Forward</th><th>Category Description </th><th>Slab Wise Reward </th><th>Reward Description </th></tr>";
                decimal iSum = 0;
                for (int ij = 0; ij < dscount; ij++)
                {
                    string str5 = "getCycleData('" + ds.Tables[2].Rows[ij][8].ToString() + "')";
                    str2 = str2 + "<tr><td><a onclick=" + str5 + " >";


                    str2 = str2 + ds.Tables[2].Rows[ij][0].ToString() + "</a></td>";
                    str2 = str2 + "<td>";

                    str2 = str2 + "" + ds.Tables[2].Rows[ij][1].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                    // str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][2]), 2).ToString() + "</td>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][2].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][3]), 2).ToString() + "</td>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][3].ToString() + "</td>";
                    str2 = str2 + "<td  align='right'>";

                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][4]), 0).ToString() + "</td>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][4].ToString() + "</td>";

                    
                    
                    str2 = str2 + "<td  align='right'>";
                    //SLA
                    if (ds.Tables[2].Rows[ij][5].ToString().Contains("SLA"))
                    {
                        str2 = str2 + "<b>";
                    }
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][5].ToString() + "</td>";

                   
                    str2 = str2 + "<td align='right'>";
                   
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][6].ToString() + "</td>";

                    if (ds.Tables[2].Rows[ij][5].ToString().Contains("SLA"))
                    {
                        str2 = str2 + "</b>";
                    }

                    try
                    {
                        iSum = iSum + Convert.ToDecimal(ds.Tables[2].Rows[ij][6]);
                    }
                    catch
                    {

                    }

                   
                    
                    //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                    str2 = str2 + "<td>";
                    str2 = str2 + "" + ds.Tables[2].Rows[ij][7].ToString() + "</td> </tr>";
                }
                str2 = str2 + "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td align='right'> " + iSum.ToString() + "</td><td></td>";
                str2 = str2 + "</table>";
            }




          //  str2 = str2 + GetQuarterData("8000001", "C1");
            

            divtest.InnerHtml = str2;
        }

    }

    private string GetQuarterData(string agentcode, string strcycle )
    {
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        Hashtable ht2 = new Hashtable();
        string str2 = "";

        string strvalue = agentcode;

        string strcyclevalue = strcycle;


        //string strvalue = "F0156";
        //string  strcyclevalue = "F0156";



        Hashtable ht = new Hashtable();

        ht.Add("@CycleCode", strcyclevalue);
        ht.Add("@AGENTCODE", strvalue);
        ht.Add("@CONTESTCODE", "C1");

        decimal dwrp = 0;
        decimal dclp = 0;

        ds = obj.GetDataSetForPrcDBConn("GetPolDtlsAgentWise", ht, "SAIMConnectionString");
        if (ds.Tables[0].Rows.Count > 0)
        {
            int dscount = ds.Tables[0].Rows.Count;
            str2 = str2 + "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'> <tr bgcolor='#0099FF'   ><td colspan='10'><b>" + "Policy Considered for Cycle" + "</b></td></tr><tr><th>Policy NO</th><th> Issue date </th><th>Login Date</th><th>Policy Term </th><th> Premium Pay Term</th><th>Product </th><th>Payment Mode </th><th>Payment Type </th><th>Premium </th><th> WRP </th></tr>";
            for (int ij = 0; ij < dscount; ij++)
            {
                str2 = str2 + "<tr><td>";

                str2 = str2 + "" + ds.Tables[0].Rows[ij][0].ToString() + "</td>";
                str2 = str2 + "<td>";

                str2 = str2 + "" + ds.Tables[0].Rows[ij][1].ToString() + "</td>";
                str2 = str2 + "<td  align='right'>";

                // str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][2]), 2).ToString() + "</td>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][2].ToString() + "</td>";
                str2 = str2 + "<td  align='right'>";

                //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][3]), 2).ToString() + "</td>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][3].ToString() + "</td>";
                str2 = str2 + "<td  align='right'>";

                //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][4]), 0).ToString() + "</td>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][4].ToString() + "</td>";
                str2 = str2 + "<td  align='center'>";

                //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][5].ToString() + "</td>";
                str2 = str2 + "<td align='center'>";
                //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][6].ToString() + "</td>";
                //str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[ij][5]), 2).ToString() + "</td></tr>";
                str2 = str2 + "<td align='center'>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][7].ToString() + "</td>";
                str2 = str2 + "<td align='right'>";
                 str2 = str2 + "" + ds.Tables[0].Rows[ij][8].ToString() + "</td>";

                 dclp = dclp + Convert.ToDecimal(ds.Tables[0].Rows[ij][8].ToString());
                 str2 = str2 + "<td align='right'>";
                str2 = str2 + "" + ds.Tables[0].Rows[ij][9].ToString() + "</td></tr>";
                dwrp =dwrp+ Convert.ToDecimal(ds.Tables[0].Rows[ij][9].ToString());
            }
            str2 = str2 + "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>Total</td><td align='right'> " + dclp.ToString() + "</td><td align='right'> " + dwrp.ToString() + "</td>";

            str2 = str2 + "</table>";
        }
        return str2;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //        alter PROCEDURE Prc_GETCDAPayoutDetailDownload  'F0156'   
        //@CSCCode varchar(50)   

        Hashtable ht2 = new Hashtable();

        DataSet ds2 = new DataSet();


        GridView grd1 = new GridView();

        string strvalue = Request.QueryString["MemberID"].ToString();

        ht2.Clear();
        ds2.Clear();


        //                    @CSCCode varchar(50),  
        //@PayoutLevel varchar(2) 

        ht2.Add("@CSCCODE", strvalue);



        ds2 = obj.GetDataSetForPrcDBConn("Prc_GETCDAPayoutDetailDownload", ht2, "SAIMConnectionString");

        DataTable firstTable = ds2.Tables[0];


        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=report.csv");

            //rite column header names
            for (int i = 0; i < firstTable.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(firstTable.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in firstTable.Rows)
            {
                for (int i = 0; i < firstTable.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "SaimPopup", "Button1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }
    protected void btn3_Click(object sender, EventArgs e)
    {
    }
    protected void btn3_Click1(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);

    }
    protected void btnCycle_Click(object sender, EventArgs e)
    {
        string strget2 = HdnFlag.Value;
        divCycle.InnerHtml = GetQuarterData("8000001", strget2); 
    }

}

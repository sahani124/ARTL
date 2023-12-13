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


public partial class Application_ISys_Saim_SaimBreakUpPageAmountWise : BaseClass
{

    DataAccessClassDAL.DataAccessClass obj = new DataAccessClassDAL.DataAccessClass();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
         DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        Hashtable ht2= new Hashtable();
        string str2="";

        string strvalue = Request.QueryString["MemberID"].ToString();

        string strval2 = Request.QueryString["flag"].ToString();


        string strvalcycle2 = Request.QueryString["Cycle"].ToString();


        //string strvalue = "F0156";

        //string strval2 = "D";


        //string strvalcycle2 = "F0156";


       
        Hashtable ht= new Hashtable ();

        ht.Add("@CSCCODE", strvalue);

        ht.Add("@OVTYPE", strval2);

        ds = obj.GetDataSetForPrcDBConn("Prc_GETCDAPAYMENTBreakUpAmountWise", ht, "SAIMConnectionString");



//        Cycle


//CDACode

        string str = ds.Tables[0].Rows[0]["CSCCODE"].ToString();

        string str223 = ds.Tables[0].Rows[0]["MemberType"].ToString();

        str = str + " - " + str223;


        str2 = str2 + "<table  width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'><tr><td style='width:30%;'>CDA Code</td><td>" + strvalue + "</td><td style='width:30%;'>Cycle Month</td><td>" + strvalcycle2 + "</td></tr>";

        str2 = str2 + "<tr><td style='width:30%;'>CDA Name</td><td>" + str + "</td><td style='width:30%;'>Statement Date</td><td>" + DateTime.Today.ToShortDateString() + "</td></tr></table>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            int dscount = ds.Tables[0].Rows.Count;

            for (int ij = 0; ij < dscount; ij++)
            {

                string stramt = ds.Tables[0].Rows[ij]["Reward_Amount"].ToString();
                string strDirectIndirectFlag = ds.Tables[0].Rows[ij]["Reward_Desc"].ToString().Substring(0,1);

                string strLevel = ds.Tables[0].Rows[ij]["OVTYPE"].ToString(); 
                if (strDirectIndirectFlag == "I")


                {

                    if(strLevel=="I1")
                    {
                        strLevel = "1";
                    }
                    if(strLevel=="I2")
                    {
                        strLevel = "2";
                    }

                    if (strLevel == "I3")
                    {
                        strLevel = "3";
                    }
                    strDirectIndirectFlag = ds.Tables[0].Rows[ij]["Category_Classification"].ToString(); 
                }
                else
                {

                    strDirectIndirectFlag = ds.Tables[0].Rows[ij]["Category_Classification"].ToString(); 
                }


                if (stramt != "0")
                {
                    str2 = str2 + "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'> <tr bgcolor='#0099FF'   ><td colspan='6'><b>" + strDirectIndirectFlag + "</b></td></tr><tr><th>Policy No</th><th> Agent Code</th><th> Premium </th><th>Basic Commission</th><th> Slab(%)</th><th> Override Commission</th></tr>";
             
                        ht2.Clear();
                        ds2.Clear();


//                    @CSCCode varchar(50),  
//@PayoutLevel varchar(2) 
                 
                        ht2.Add("@CSCCODE",strvalue);

                        ht2.Add("@PayoutLevel", ds.Tables[0].Rows[ij]["OVTYPE"].ToString());

                        decimal strPremAmtSum = 0;

                        decimal strCommAmt = 0;

                        decimal strBASEOV = 0;

                        int strBASEPercent = 0;

                        ds2 = obj.GetDataSetForPrcDBConn("Prc_GETCDAPayoutDetail", ht2, "SAIMConnectionString");



                                    if (ds2.Tables[0].Rows.Count > 0)
                                    {
                                        int ds2count = ds2.Tables[0].Rows.Count;

                                        for (int i = 0; i < ds2count; i++)
                                        {


                                            strBASEPercent = Convert.ToInt16(Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[0]["BASEPercent"]), 0));
                                            strPremAmtSum = strPremAmtSum + Convert.ToDecimal(ds2.Tables[0].Rows[i]["PremAmt"]);

                                            strCommAmt = strCommAmt + Convert.ToDecimal(ds2.Tables[0].Rows[i]["CommAmt"]);

                                            strBASEOV = strBASEOV + Convert.ToDecimal(ds2.Tables[0].Rows[i]["BASEOV"]);
                                            str2 = str2 + "<tr><td>";

                                            str2 = str2 + "" + ds2.Tables[0].Rows[i]["Policyno"].ToString() + "</td>";
                                            str2 = str2 + "<td>";

                                            str2 = str2 + "" + ds2.Tables[0].Rows[i]["Agentcode"].ToString() + "</td>";
                                            str2 = str2 + "<td  align='right'>";

                                            str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[i]["PremAmt"]), 2).ToString() + "</td>";
                                            str2 = str2 + "<td  align='right'>";

                                            str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[i]["CommAmt"]), 2).ToString() + "</td>";
                                            str2 = str2 + "<td  align='center'>";

                                            str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[i]["BASEPercent"]), 0).ToString() + "</td>";
                                            str2 = str2 + "<td  align='right'>";

                                            str2 = str2 + "" + Math.Round(Convert.ToDecimal(ds2.Tables[0].Rows[i]["BASEOV"]), 2).ToString() + "</td></tr>";
                                            //str2 = str2 + "<td>";

                                            //str2 = str2 + "" + ds2.Tables[0].Rows[i]["column7"].ToString() + "</td>";
                                           

                                        }
                                    }
                                    str2 = str2 + "" + "<tr><td>Sub Total :-</td><td></td><td align='right'>" + Math.Round(strPremAmtSum, 2).ToString() + "</td><td align='right'>" + Math.Round(strCommAmt, 2).ToString() + "</td><td align='center'>" + strBASEPercent + "</td><td align='right'>" + Math.Round(strBASEOV, 2).ToString() + "</td></tr>";


                                    str2 = str2 + "</table>";

             }


      


            }
        }
        
        divtest.InnerHtml = str2;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht2 = new Hashtable();

        DataSet ds2 = new DataSet();


        GridView grd1 = new GridView();

        string strvalue = Request.QueryString["MemberID"].ToString();


        string strval2 = Request.QueryString["flag"].ToString();

        ht2.Clear();
        ds2.Clear();


        //                    @CSCCode varchar(50),  
        //@PayoutLevel varchar(2) 




        ht2.Add("@CSCCODE", strvalue);

        ht2.Add("@OVTYPE", strval2);

        ds2 = obj.GetDataSetForPrcDBConn("Prc_GETCDAPAYMENTBreakUpAmountWise", ht2, "SAIMConnectionString");

 

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
            objErr.LogErr("ISYS-SAIM", "SaimBreakUpPageAmountWise", "Button1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
   

    }
   
}
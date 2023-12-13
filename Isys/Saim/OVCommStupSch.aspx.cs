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



public partial class form_layouts : BaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)

        {
      
        
  }


    }


    public void GettableData()

    {
        DataSet ds = new DataSet();

        DataAccessClassDAL.DataAccessClass obj = new DataAccessClassDAL.DataAccessClass();
        Hashtable ht= new Hashtable ();

        ht.Add ("@arjun","asdas");

        ds = obj.GetDataSetForPrcDBConn("Prc_GetSaimData", ht, "SAIMConnectionString");

        string str;

       // width="100%" cellpadding="0" cellspacing="0" 

        str = "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'><tr><th></th><th>Member Code</th><th>Short Code</th> <th>Member Name</th> <th>Member Type</th> <th>Cycle</th><th>Effective From</th><th>Effective To</th> <th>Break-up</th></tr>";


        if (ds.Tables[0].Rows.Count > 0)
        {
            int dscount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < dscount; i++)
            {

                str = str + "<tr  id='trid" + i + "'>";
                str = str + "<td id='td0" + i + "' align='center' style='margin-top :2px;'>";
                str = str + "<center>";
                str = str + " <img  id='img9" + i + "'  src ='../Saim/assets/img/PlusImages.png' onclick='viewtable(this.id)'  style='height: 15px; width: 15px;' />";

                str = str + "</center>";
                
                //str = str + "<input onclick='viewtable(this.id)' id='btn" + i + "' Type='Button'  style='height:15px;border: 1px solid #B6BCCB;background-image :url(&#039;assets/img/MinusImages.png&#039;);font-size: 1px; width: 15px;'     value='+' >";

                str = str + "</td>";



                str = str + "<td  id='td1" + i + "' >";
                str = str + "" + ds.Tables[0].Rows[i]["Member_Code"].ToString();
                str = str + "</td>";


                str = str + "<td id='td2" + i + "'>";
                str = str + "" + ds.Tables[0].Rows[i]["Short_Code"].ToString();
                str = str + "</td>";


                str = str + "<td id='td3" + i + "'>";
                str = str + "" + ds.Tables[0].Rows[i]["Short_Code"].ToString() + " - " + ds.Tables[0].Rows[i]["Member_Type"].ToString();
                str = str + "</td>";

                str = str + "<td align='center' id='td4" + i + "' >";
                str = str + "" + ds.Tables[0].Rows[i]["Member_Type"].ToString();
                str = str + "</td>";

                str = str + "<td align='center' id='td5" + i + "'>";
                str = str + "" + ds.Tables[0].Rows[i]["Cycle"].ToString();
                str = str + "</td>";

                str = str + "<td align='center' id='td6" + i + "'>";
                str = str + "" + ds.Tables[0].Rows[i]["Effective_From"].ToString();
                str = str + "</td>";

                str = str + "<td  align='center' align='center' id='td7" + i + "'>";
                str = str + "" + ds.Tables[0].Rows[i]["Effective_To"].ToString();
                str = str + "</td>";

                str = str + "<td align='center' id='td8" + i + "'>";

                str = str + "<input type ='hidden' id='hdn8" + i + "' value='" + ds.Tables[0].Rows[i]["Cycle"].ToString() + "'/>";
                str = str + "<a id='alink8" + i + "' onclick='openNewPage(this.id)'>View Details</a>";
                str = str + "</td>";
                str = str + "</tr>";





                str = str + "<tr  id='tridhide" + i + "'>";


             //<table cellpadding="0" width="100%" cellspacing="5" style="border: 1px solid #c1c1c1">


                str = str + "<td class='details' style=''  runat='server' Colspan='9'   >";


                str = str + "<div style='display:none;'  id='td9" + i + "'>";

                str = str + "<table  cellpadding='2'   cellspacing='2'    style='width:100%;border: 1px solid #c1c1c1;'><tbody><tr style='background-color:#D0D0D0' ;><th align='center'>Reward Code</th><th align='left'>Category Classification </th> <th align='center'>Rule Setup Key</th> <th align='center'>Reward Type</th><th align='center'>Type </th><th align='center'>Based On KPI </th><th align='center'>Value</th><th align='center'> Reward Desc</th><th align='right'>Reward Amount</th></tr>";


                DataSet ds2 = new DataSet();

                Hashtable ht2 = new Hashtable();
               

                ht2.Add("@CSCCODE", ds.Tables[0].Rows[i]["Short_Code"].ToString());
                ds2 = obj.GetDataSetForPrcDBConn("Prc_GETCDAPAYMENTBreakUp", ht2, "SAIMConnectionString");
                string str2="";

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int ds2count = ds2.Tables[0].Rows.Count;

                    for (int ij = 0; ij < ds2count; ij++)
                    {


                        str2 = str2 + "<tr id='tridchild" + ij + "'>";
                        str2 = str2 + "<td align='center' id='tdchild1" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Reward_Code"].ToString();
                        str2 = str2 + "</td>";


                        str2 = str2 + "<td align='left' id='tdchild2"+ i +"" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Category_Classification"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td  align='center' id='tdchild3" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Rule_Set_Key"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td align='center' id='tdchild4" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Reward_Type"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td align='center' id='tdchild5" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Type"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td align='center' id='tdchild6" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Based_On_KPI"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td align='center'  id='tdchild7" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Value"].ToString();
                        str2 = str2 + "</td>";

                        str2 = str2 + "<td align='center'  id='tdchild8" + i + "" + ij + "'>";
                        str2 = str2 + "" + ds2.Tables[0].Rows[ij]["Reward_Desc"].ToString();
                        str2 = str2 + "</td>";


                        str2 = str2 + "<td style='padding-right:10px;' align='right' id='tdchild9" + i + "" + ij + "'>";

                             //<input type ="hidden" id="hdn" />

                        
                        str2 = str2 + "<input type ='hidden' id='hdnchild9" + i + "" + ij + "' value='" + ds2.Tables[0].Rows[ij]["OVTYPE"].ToString() + "'/>";

                        str2 = str2 + "<input type ='hidden' id='hdnchild92" + i + "" + ij + "' value='" + ds2.Tables[0].Rows[ij]["CSCCODE"].ToString() + "'/>";
                        str2 = str2 + "<input type ='hidden' id='hdnchild93" + i + "" + ij + "' value='" + ds2.Tables[0].Rows[ij]["Cycle"].ToString() + "'/>";
                        str2 = str2 + "<a onclick='openNewPageonAmount(this.id)' id='alinkchild9" + i + "" + ij + "'>" + ds2.Tables[0].Rows[ij]["Reward_Amount"].ToString() + "</a>";

                        str2 = str2 + "</td>";
                        str2 = str2 + "</tr>";

                       



                    }
                }

                str2 = str2 + "</tbody></table>";
                str = str + "" + str2;

                str = str + "</div>";
               

                str = str + "</td>";
                str = str + "</tr>";




            }
            str = str + "</table>";

            test.InnerHtml = str;

            //str.Replace("'",""")
        }


    }



    protected void Button1_Click(object sender, EventArgs e)
    {

        string str2 = ddlctype.Value.ToString();
      string str= ddlMonth.Value.ToString();

      if (str == "8")
      {

          DivComp.Visible = true;
          GettableData();
      }

      else
      {
          DivComp.Visible = false;

          test.InnerHtml = "";

      }

     
  
     // DivComp.Style.Add("display", "block");
        //Hidden1.Value = "<table><tr><th> Reward Code</th> <th> Category Classification</th> <th> Rule</th> <th> asa</th> <th>asd</th> <th> sadas</th> <th> asdas</th> <th> asdas</th> <th> asdas</th></tr></table>";

      
        
        
        //    hdnTDTExt





    }


    
}
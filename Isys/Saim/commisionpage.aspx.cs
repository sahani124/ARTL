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

public partial class Application_ISys_Saim_commisionpage : BaseClass
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
        Hashtable ht = new Hashtable();

        ht.Add("@arjun", ddlMonth.SelectedIndex);

        ds = obj.GetDataSetForPrcDBConn("Prc_GetSaimData_Feb", ht, "SAIMConnectionString");

        string str;

        // width="100%" cellpadding="0" cellspacing="0" 

        str = "<table width='100%'  cellpadding='0' cellspacing='0'  class='table table-striped table-bordered table-hover'><tr><th>Member Code</th> <th>Member Name</th> <th>Member Type</th> <th>Cycle</th><th>Effective From</th><th>Effective To</th> <th>Break-up</th></tr>";


        if (ds.Tables[0].Rows.Count > 0)
        {
            int dscount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < dscount; i++)
            {



                str = str + "<td  id='td1" + i + "' >";
                str = str + "" + ds.Tables[0].Rows[i]["Member_Code"].ToString();
                str = str + "</td>";

                str = str + "<td  id='td1" + i + "' >";
                str = str + "" + ds.Tables[0].Rows[i]["MemberName"].ToString();
                
                str = str + "</td>";

                str = str + "<td  id='td1" + i + "' >";
                str = str + "Agent";
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
                str = str + "<a  onclick='openNewPage()'>View Details</a>";
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
        string str = ddlMonth.Value.ToString();

        if (str == "11")
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


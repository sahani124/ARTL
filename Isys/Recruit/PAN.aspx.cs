using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using DataAccessClassDAL;
using System.Threading;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

public partial class Application_Isys_Recruit_PAN : BaseClass
{
    DataAccessClass dataAccessRecruit = new DataAccessClass();
    Hashtable htPan = new Hashtable();
    DataSet ds = new DataSet();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    Hashtable htTbl = new Hashtable();
    DataSet dsResult = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Note added 19 july 2023 start
            if (Request.QueryString["AgtType"] != null)
            {
                if (Request.QueryString["AgtType"].ToString().Trim() == "PS")
                {
                    lblmsgrec.Text = "Alert: This module should be used only for registration of POSPs";
                }
                else {
                    lblmsgrec.Text = "Alert: This module should be used only for registration of individual agents";
                }
            }
            //Note added 19 july 2023 end


            if (Request.QueryString["PAN"] != null)
            {
                string QSPano= Request.QueryString["PAN"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "filltextbox('" + QSPano + "');", true);
            }
        }
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            var textpan = "";
            bool isFound = false;
            DataSet dsRes = new DataSet();
            for (int i = 1; i <= 10; i++)
            {
				var textboxname = Request.Form["ctl00$ContentPlaceHolder1$TextBox" + i];
				if (textboxname != "")
				{
					textpan += textboxname;
					textboxname = "";
				}
				else
				{
					if(lblPANMsg.Text!="")
					{
						lblPANMsg.Text = "";
						btnprecdnext.Attributes.Add("style", "display:none");
						btnPrcd.Attributes.Add("style", "display:block");
						btnPrcd.Attributes.Add("style", "margin-left:177px");
					}
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter value in all the TextBox')", true);
					return;
				}
			}
			lblPANMsg.Text = "";
            hdnPan.Value = "0";
            htParam.Clear();
            htParam.Add("@PAN", textpan.Trim());
            htParam.Add("@AgentType", Request.QueryString["AgtType"].ToString().Trim());
            dsRes = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetChkPANExist", htParam);

            for (int i = 0; i < dsRes.Tables.Count; i++)
            {
                if (dsRes.Tables[i].Rows.Count > 0)
                {

                    if (dsRes.Tables[0].Rows.Count > 0)
                    {

                        if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "180" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "C")// added by usha for 
                        {
                            isFound = true;
                        }
                    }
                    //ended  by usha 
                    if (dsRes.Tables.Count > 1)
                    {
                        if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")//Added by rachana to show empcode in duplicate PAN
                        {
                            hdnCndCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][3]).Trim();
                        }
                    }
                    else
                    {
                        hdnCndCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][0]).Trim();
                    }
                }
            }
            if (isFound == true)
            {
                if (dsRes.Tables[0].Rows.Count > 0 || dsRes.Tables[1].Rows.Count > 0)
                {
                    if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "")// added by usha for composite 
                    {
                        //addded by sanoj 31082023
                        if (Convert.ToString(dsRes.Tables[0].Rows[0][4]).Trim() == "P" && Request.QueryString["AgtType"].ToString().Trim() == "IS")
                        {
                            Label7.Text = "You can convert this POSP to an Individual Agent! Do you want to proceed?";
                            btnProceed.Visible = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "CallJS", "popup();", true);
                        }
                        //endded by sanoj 31082023
                        else
                        {
                            if (Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim() != "")
                            {
                                hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim();
                                lblPANMsg.Text = "Duplicate match found for <br/>Agent Broker Code :- " + hdnAgentBrokerCode.Value;
                            }
                            else if (Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim() != "")
                            {
                                hdnUrn.Value = Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim();
                                lblPANMsg.Text = "Duplicate match found for <br/>URN NO :- " + hdnUrn.Value;
                            }
                            else
                            {
                                lblPANMsg.Text = "Duplicate match found for <br/>ApplicationNo :- " + hdnCndCode.Value;
                            }

                          
                        }

                        lblPANMsg.ForeColor = Color.Green;
                        hdnPan.Value = "0";
                        htPan.Add("@DupAppNo", Convert.ToString(dsRes.Tables[0].Rows[0][0]).Trim());
                        if (dsRes.Tables[0].Rows[0][5].ToString().Trim() != "")
                        {
                            htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim());
                        }
                        else
                        {
                            htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                        }
                        if (dsRes.Tables[0].Rows[0][2].ToString().Trim() != "")
                        {
                            htPan.Add("@DupURNNo", Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim());
                        }
                        else
                        {
                            htPan.Add("@DupURNNo", System.DBNull.Value);
                        }
                        if (dsRes.Tables[0].Rows[0][7].ToString().Trim() != "")
                        {
                            htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[0].Rows[0][7]).Trim());
                        }
                        else
                        {
                            htPan.Add("@DupSAPCode", System.DBNull.Value);
                        }
                        if (dsRes.Tables[0].Rows[0][6].ToString().Trim() != "")
                        {
                            htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[0].Rows[0][6]).Trim());
                        }
                        else
                        {
                            htPan.Add("@DupAgentCode", System.DBNull.Value);
                        }
                    }
                }
            }
            else if (dsRes.Tables.Count > 1 && dsRes.Tables[1].Rows.Count > 0)
            {
                if (Convert.ToString(dsRes.Tables[1].Rows[0][0]).Trim() != "")
                {
                    hdnEmpCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim();
                    lblPANMsg.Text = "We found this PAN linked with an existing employee (Emp Code: "+hdnEmpCode.Value + ")." ;
                }
                else if (Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim() != "")
                {
                    hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim();
                    lblPANMsg.Text = "We found this PAN linked with an existing Agent/Intermediary (Code: "+ hdnAgentBrokerCode.Value + ").";
                }
                else
                {
                    lblPANMsg.Text = "We found this PAN linked with an existing member (Code: " + hdnCndCode.Value + ").";
                }

                
                hdnPan.Value = "0";
                htPan.Clear();
                btnprecdnext.Attributes.Add("style", "display:block");
                if (dsRes.Tables[1].Rows[0][2].ToString().Trim() != "")
                {
                    htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim());
                }
                else
                {
                    htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                }
                if (dsRes.Tables[1].Rows[0][0].ToString().Trim() != "")
                {
                    htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[1].Rows[0][0]).Trim());
                }
                else
                {
                    htPan.Add("@DupAgentCode", System.DBNull.Value);
                }
                if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")
                {
                    htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim());
                }
                else
                {
                    htPan.Add("@DupSAPCode", System.DBNull.Value);
                }

                //htPan.Add("@DupPAN", txtpan.Text.Trim());
                htPan.Add("@DupPAN", textpan.Trim());
                htPan.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                int x = dataAccessRecruit.execute_sprcrecruit("Prc_InsDupPANDtls", htPan);
                //added by ajay 23-03-2023 start
                btnPrcd.Attributes.Add("style", "display:none");
                btnprecdnext.Attributes.Add("style", "display:none");
                //added by ajay 23-03-2023 end
            }

            else
            {
                lblPANMsg.Text = "We did not find any member linked with this PAN so lets proceed with the registration.";
                lblPANMsg.ForeColor = Color.Green;
                hdnPan.Value = "1";
                hdnPanValue.Value = textpan.Trim();
                btnprecdnext.Attributes.Add("style", "display:block");
                btnprecdnext.Attributes.Add("style", "margin-left:177px");
                btnPrcd.Attributes.Add("style", "display:none");
                lblPANMsg.Visible = true;
            }
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            lblPANMsg.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            btnprecdnext.Attributes.Add("style", "display:none");
            btnPrcd.Attributes.Add("style", "display:block");
            btnPrcd.Attributes.Add("style", "margin-left:177px");
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

    protected void btnPrcd_Click(object sender, EventArgs e)
    {
        try
        {
         
            btnVerify_Click(null,null);
            
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

    protected void btnprecdnext_Click(object sender, EventArgs e)
    {
        string ModuleID = Request.QueryString["ModuleID"].Trim();
        string AgtType = Request.QueryString["AgtType"].Trim();
        string PAN = hdnPanValue.Value;
        string Type = Request.QueryString["Type"];//added by ajay yadav 02-11-2022
        string Code = Request.QueryString["Code"];//added by ajay yadav 02-11-2022
        string ACT = Request.QueryString["ACT"];//added by ajay yadav 02-11-2022
        Response.Redirect("Integration.aspx?ModuleID=" + ModuleID + "&AgtType=" + AgtType + "&PAN=" + PAN + "&Type=" + Type + "&Code=" + Code + "&ACT=" + ACT, false);
    }


    //added  bysanoj 31082023
    protected void lnkPrcdWthCon_Click(object sender, EventArgs e)
    {
        try
        {
            string SapCode = HttpContext.Current.Session["UserID"].ToString().Trim();
            htTbl.Clear();
            dsResult.Clear();
            htTbl.Add("@EmpCode", SapCode);
            dsResult = dataAccessRecruit.GetDataSetForPrc("Prc_GetMemRecruiterDtls", htTbl);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@AppNo", hdnCndCode.Value);
                htParam.Add("@SapCode", SapCode);
                htParam.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrc"].ToString());
                htParam.Add("@ChnCls", dsResult.Tables[0].Rows[0]["ChnCls"].ToString());
                htParam.Add("@UNitcode", dsResult.Tables[0].Rows[0]["UnitCode"].ToString());
                htParam.Add("@SFlag", "W");
                ds = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_ConvertPStoIS", htParam);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnNewAppNo.Value = ds.Tables[0].Rows[0]["AppNo"].ToString();
                    Label7.Text = ds.Tables[0].Rows[0]["status"].ToString() + "<br/>Name :- " + ds.Tables[0].Rows[0]["Name"].ToString() + "<br/>ApplicationNo :- " + ds.Tables[0].Rows[0]["AppNo"].ToString();
                    btnYes.Attributes["style"] = "color: red;display:none";
                    //btnProceed.Attributes["style"] = "color: red;display:block";

                    btnProceed.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallJS", "popup();", true);

                }

            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "lnkPrcdWthCon_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void lmkbtnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("CndReg.aspx?ProspectId=" + hdnNewAppNo.Value + "&Type=E&ACT=PR&ModuleID=8017" +  "&Code=Spon" + "&AgtType=IS", false);

    }

    //Endded  bysanoj 31082023

   
}
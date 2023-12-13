//using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using INSCL.DAL;
//using System.Data.SqlClient;
//using System.Threading;
//using System.Globalization;
//using Insc.Common.Multilingual;
//using System.Xml;
//using CLTMGR;
//using DataAccessClassDAL;

//public partial class Application_Isys_ChannelMgmt_LOBDtls : BaseClass
//{
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
namespace INSCL
{
    public partial class LOBDtls : BaseClass
    {
        
        #region Global Declaration
        DataTableReader dtReadr;
        DataSet dsResult;
        Hashtable ht;
        private string strUserLang;
        DataAccessClass objDAL = new DataAccessClass();
        ErrLog objErr = new ErrLog();
        int count;
        string StrChnCls, StrMemType, StrBizSrc, StrMemCode;
        //ChannelSetup c = new ChannelSetup();


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                Session["CarrierCode"] = '2';
                if (!IsPostBack)
                {
                    BindLobDtls();
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
            finally
            {

            }
        }
        

        private void BindLobDtls()
        {
            try
            {
                dsResult = new DataSet();
                dsResult = null;
                dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBDtls");
                dtReadr = dsResult.Tables[0].CreateDataReader();
                while (dtReadr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dtReadr["LobName"].ToString();
                    item.Value = dtReadr["LOBCode"].ToString();
                    LOBchklst.Items.Add(item);
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
            finally
            {
                dsResult = null;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetDataTable();
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
            finally
            {
                dsResult = null;
                ht.Clear();
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex - 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }
                else
                {
                    btnprevious.Enabled = true;
                }
                btnnext.Enabled = true;
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
            finally
            {

            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex + 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                int page = GridProdDtls.PageCount;
                if (txtPage.Text == Convert.ToString(GridProdDtls.PageCount))
                {
                    btnnext.Enabled = false;
                }
                else
                {
                    int intPageIndex = GridProdDtls.PageIndex + 1;
                    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
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
            finally
            {

            }
        }

        protected void GrdStateDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = GetDataTable();
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;
                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
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
            finally
            {

            }
        }

        protected DataTable GetDataTable()
        {
            try
            {
                ht = new Hashtable();
                dsResult = new DataSet();
                dsResult.Clear();
                ht.Clear();
                string LobList = "";
                foreach (ListItem item in LOBchklst.Items)
                {
                    if (item.Selected)
                    {
                        LobList += item.Value;
                        LobList += "'" + "," + "'";
                        count = count + 1;
                    }
                }
                LobList = LobList.Substring(0, LobList.Length - 3);
                hdnnLOB.Value = LobList;

                //ht.Add("@Bizsrc", Request.QueryString["Bizsrc"].ToString());
                //"N" Add New
                if (Request.QueryString["Flag"].ToString() == "N" || Request.QueryString["Flag"].ToString() == "E")
                {
                    ht.Add("@LOBCode", LobList);
                    string strs = Request.QueryString["hdnprodcode"].Replace(",", "','");
                    ht.Add("@Prodcode", strs);
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetProductDtls", ht);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            divsearchDtls.Visible = true;
                            GridProdDtls.DataSource = dsResult.Tables[0];
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            tblDtl.Visible = true;
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                            ShowPageInformation();
                        }
                        else
                        {

                            divsearchDtls.Visible = false;
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            //divsearchDtls.Attributes.Add("style", "display:none");
                            trtitle.Visible = false;
                        }
                    }
                    else
                    {

                        divsearchDtls.Visible = false;
                        GridProdDtls.DataSource = null;
                        GridProdDtls.DataBind();
                        lblPageInfo.Text = "";
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";
                        //divsearchDtls.Attributes.Add("style", "display:none");
                        trtitle.Visible = false;
                    }
                }
                else
                {
                    ht.Add("@LOBCode", LobList);
                    //ht.Add("@Prodcode", Request.QueryString["hdnprodcode"]);
                    ht.Add("@Bizsrc", Request.QueryString["Bizsrc"].ToString());
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetProductDtls_bizsrc", ht);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            divsearchDtls.Visible = true;
                            GridProdDtls.DataSource = dsResult.Tables[0];
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            tblDtl.Visible = true;
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                            ShowPageInformation();
                        }
                        else
                        {

                            divsearchDtls.Visible = false;
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            //divsearchDtls.Attributes.Add("style", "display:none");
                            trtitle.Visible = false;
                        }
                    }
                    else
                    {

                        divsearchDtls.Visible = false;
                        GridProdDtls.DataSource = null;
                        GridProdDtls.DataBind();
                        lblPageInfo.Text = "";
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record Found";
                        //divsearchDtls.Attributes.Add("style", "display:none");
                        trtitle.Visible = false;
                    }


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
            finally
            {

            }
            return dsResult.Tables[0];
        }

        private void ShowPageInformation()
        {
            try
            {
                int intPageIndex = GridProdDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
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
            finally
            {

            }
        }

        protected void btninsertprod_Click(object sender, EventArgs e)
        {
            try
            {
                int chkprocount = 0;
                foreach (GridViewRow gridrow in GridProdDtls.Rows)
                {
                    CheckBox chk = (CheckBox)gridrow.FindControl("chkselect");
                    if (chk.Checked)
                    {
                        chkprocount = 1;
                    }
                }
                if (chkprocount == 1)
                {
                    Session["ProductDetails"] = null;
                    string strProdCode = "";
                    string strProdName = "";
                    string strname = string.Empty;
                    DataTable dtprod = new DataTable();
                    dtprod.Columns.Add("ProdCode");
                    dtprod.Columns.Add("ProdName");
                    dtprod.Columns.Add("LOBList");
                    foreach (GridViewRow gvrow in GridProdDtls.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("chkselect");
                        if (chk != null & chk.Checked)
                        {
                            //strProdCode += GridProdDtls.DataKeys[gvrow.RowIndex].Values[0] + "'" + "," + "'";
                            strProdCode += GridProdDtls.DataKeys[gvrow.RowIndex].Values[0] + ",";
                            strProdName += GridProdDtls.DataKeys[gvrow.RowIndex].Values[1] + "'" + "," + "'";
                        }
                    }

                    if (strProdCode.Length > 2 && strProdName.Length > 2)
                    {
                        //strProdCode = strProdCode.Substring(0, strProdCode.Length - 3);
                        strProdCode = strProdCode.Substring(0, strProdCode.Length - 1);
                        strProdName = strProdName.Substring(0, strProdName.Length - 3);
                        DataRow drprod = dtprod.NewRow();
                        drprod["ProdCode"] = strProdCode;
                        drprod["ProdName"] = strProdName;
                        drprod["LOBList"] = hdnnLOB.Value;
                        dtprod.Rows.Add(drprod);
                    }
                    hdnprdcode.Value = strProdCode;
                    Session["ProductDetails"] = dtprod;
                    //1):-Flag='' for New Added to channel setup
                    //if (Request.QueryString["Flag"].ToString() == "''" || Request.QueryString["Flag"].ToString() == "E")
                        if (Request.QueryString["Flag"].ToString() == "N" || Request.QueryString["Flag"].ToString() == "E")

                        {
                        Hashtable htable;
                        htable = new Hashtable();
                        DataSet ds = new DataSet();
                        htable.Clear();
                        ds.Clear();
                        htable.Clear();
                        if (Request.QueryString["ChnType"].ToString() != "C")
                        {
                            if (Request.QueryString["ChnName"].ToString() != "" || Request.QueryString["MemTypeDesc"].ToString() != "")
                            {
                                htable.Add("@ChnName", Request.QueryString["ChnName"].ToString());//
                                htable.Add("@MemTypeDesc", Request.QueryString["MemTypeDesc"].ToString());//
                                ds = objDAL.GetDataSetForPrcIsysTemp("Prc_GetMemtypedata", htable);
                                StrChnCls = ds.Tables[0].Rows[0]["ChnCls"].ToString();
                                StrMemType = ds.Tables[0].Rows[0]["MemType"].ToString();
                                StrBizSrc = ds.Tables[0].Rows[0]["BizSrc"].ToString();
                            }

                            if (Request.QueryString["ChnType"].ToString() == "A")
                            {
                                StrMemCode = Request.QueryString["memCode"].ToString();
                            }
                        }
                        else
                        {
                            StrChnCls = "";
                            StrMemType = "";
                            StrBizSrc = Request.QueryString["Bizsrc"].ToString();
                        }
                        // Hashtable htable;
                        foreach (GridViewRow grdtls in GridProdDtls.Rows)
                        {
                            CheckBox chk = (CheckBox)grdtls.FindControl("chkselect");
                            if (chk != null & chk.Checked)
                            {
                                string StrProdCode = ((Label)grdtls.FindControl("lblProdCode")).Text;
                                string StrEffdtim = "";
                                string StrLobCode = ((HiddenField)grdtls.FindControl("hdnLOBCode")).Value;
                                string StrStatus = "Active";//"A"
                                string StrCeasedate = "";
                                htable = new Hashtable();
                                htable.Clear();
                                if (Request.QueryString["ChnType"].ToString() != "C")
                                {
                                    if (Request.QueryString["ChnName"].ToString() == "" || Request.QueryString["MemTypeDesc"].ToString() == "")
                                    {
                                        htable.Add("@Bizsrc", Request.QueryString["Bizsrc"].ToString());//
                                        htable.Add("@Chncls", Request.QueryString["Chnchncls"].ToString());//
                                    }
                                    else
                                    {
                                        htable.Add("@Bizsrc", StrBizSrc);
                                        htable.Add("@Chncls", StrChnCls);
                                        htable.Add("@Memtype", StrMemType);
                                    }
                                }
                                else
                                {
                                    htable.Add("@Bizsrc", StrBizSrc);
                                    htable.Add("@Chncls", StrChnCls);
                                    htable.Add("@Memtype", StrMemType);
                                }

                                if (Request.QueryString["ChnType"].ToString() == "A")
                                {
                                    if (Request.QueryString["AgentCode"] != null)
                                    {
                                        htable.Add("@memcode", Request.QueryString["AgentCode"].ToString().Trim());
                                        htable.Add("@Memtype", Request.QueryString["Memtype"].ToString().Trim());
                                    }
                                    else
                                    {
                                        htable.Add("@memcode", System.DBNull.Value);
                                        htable.Add("@Memtype", System.DBNull.Value);
                                    }

                                }

                                htable.Add("@Flag", Request.QueryString["ChnType"].ToString());//Request.QueryString["ChnTyp"].ToString()
                                htable.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                                htable.Add("@ProdCode", StrProdCode);
                                //htable.Add("@MemCode", StrMemCode);
                                htable.Add("@EffDate", StrEffdtim);
                                htable.Add("@LOBCode", StrLobCode);
                                htable.Add("@Status", StrStatus);
                                htable.Add("@Ceasedate", StrCeasedate);
                                objDAL.execute_sprcIsysTemp("Prc_InsertProductDtls", htable);
                           
                                
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel();", true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Product inserted successfully.');", true);

                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePopup();", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select atleast one product for product insert.');", true);
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel();", true);
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
            finally
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel()", true);
                //if user click cancel button if alredy selsct product
                Session["ProductDetails"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ClosePanel()", true);
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
            finally
            {

            }
        }
    }
}
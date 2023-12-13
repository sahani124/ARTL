using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using DataAccessClassDAL;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Web.Script.Serialization;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class CustomizationDynamic : System.Web.Services.WebService
{
    //Added BY Pratik
    [WebMethod]
    public string GetHtmlTemplates(string KPI_CODE, string ACT_NO, string ACT_TYP_ID, string ACT_SCHM_KEY)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACT_NO", ACT_NO);
            ht.Add("@ACT_TYP_ID", ACT_TYP_ID);
            ht.Add("@ACT_SCHM_KEY", ACT_SCHM_KEY);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_GET_MST_DYN_STD_DEF_SETUP]", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetFactorsBySchemeKey(string ACT_SCH_KEY, string KPI_CODE, string ACTION_TYPE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetFixFactorControls", ht);
            resp.status = "0";
            resp.Data = ds;
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetLookupData(string LookupCode)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@LookupCode", LookupCode);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_FIX_FACTORS", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetFixFactorsData(string KPI_CODE, string ACTION_TYPE, string FLAG, string TYPE, string ACT_SCHM_KEY)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@FLAG", FLAG);
            ht.Add("@ACT_SCHM_KEY", ACT_SCHM_KEY);
            ht.Add("@TYPE", TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_FIX_FACTOR_MASTER_DATA", ht);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    ds.Tables[i].TableName = Convert.ToString(ds.Tables[i].Rows[0][0]);
                }
            }

            resp.status = "0";
            resp.Data = ds;
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetFixFactorFromRangeFactor(string ACT_SCH_KEY, string VAL_CODE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_FIX_FACTOR_FROM_RANGE_FACTOR", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetBasedRFDDL(string LookupCode, string Type, string ACT_SCH_KEY)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@LookupCode", LookupCode);
            //ht.Add("@Type", Type);
            ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
            //ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_DDL_NEW_UPD_DATA", ht);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GETUpdatedMPLData", ht);
            resp.status = "0";
            resp.Data = ds.Tables[1];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetConvetedRangeFactor(string ACT_SCH_KEY, string FIX_FACTOR, string KPI_CODE, string ACTION_TYPE, string TYPE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@TYPE", TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_COVT_RANGE_FACTOR", ht);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    ds.Tables[i].TableName = Convert.ToString(ds.Tables[i].Rows[0][0]);
                }
            }
            resp.status = "0";
            resp.Data = ds;
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetConvetedRangeFactorByValCode(string ACT_SCH_KEY, string FIX_FACTOR, string KPI_CODE, string ACTION_TYPE, string TYPE, string SELECTED_RANGE, string VAL_CODE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            DataSet selected_data = JsonConvert.DeserializeObject<DataSet>(SELECTED_RANGE);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@TYPE", TYPE);
            if (selected_data.Tables.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("VAL_CODE");
                dt.Columns.Add("RangeData");
                ht.Add("@Selected_Range", dt);
            }
            else
            {
                ht.Add("@Selected_Range", selected_data.Tables[0]);
            }
            
            ht.Add("@VAL_CODE", VAL_CODE);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_COVT_RANGE_FACTOR_VAL_CODE", ht);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    ds.Tables[i].TableName = Convert.ToString(ds.Tables[i].Rows[0][0]);
                }
            }
            resp.status = "0";
            resp.Data = ds;
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    // Main Table
    [WebMethod]
    public string SaveRangeFactor(string ACT_SCH_KEY, string FIX_FACTOR, string VAL_CODE, string FROM_DATA, string TO_DATA, string CREATED_BY, string KPI_CODE, string ACTION_TYPE, string SelValue, string selPosition)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ht.Add("@FROM_DATA", FROM_DATA);
            ht.Add("@TO_DATA", TO_DATA);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@SELCTED_RANGE", SelValue);
            ht.Add("@POSITION", selPosition);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_VALIDATE_RANGE_FACTOR", ht);
            int status = Convert.ToInt16(ds.Tables[0].Rows[0]["Response"]);
            if(status == 1)
            {
                resp.status = status.ToString();
                resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
                return JsonConvert.SerializeObject(resp);
            }

            ht.Clear();
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ht.Add("@FROM_DATA", FROM_DATA);
            ht.Add("@TO_DATA", TO_DATA);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@CREATED_BY", CREATED_BY);
            ht.Add("@SelValue", SelValue);
            ht.Add("@SelPosition", selPosition);
            // ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_MPL_RANGE_FACTORS", ht);
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_MPL_RANGE_FACTORS", ht);
            resp.status = Convert.ToString(ds.Tables[ds.Tables.Count - 1].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[ds.Tables.Count - 1].Rows[0]["ResponseText"]);

            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, CREATED_BY);
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string DeleteRangeFactor(string RNG_FACT_ID, string ACT_SCH_KEY, string FIX_FACTOR, string VAL_CODE, string FROM_DATA, string TO_DATA, string UPDATED_BY, string KPI_CODE, string ACTION_TYPE, int SRT_ORDR)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@RNG_FACT_ID", RNG_FACT_ID);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ht.Add("@FROM_DATA", FROM_DATA);
            ht.Add("@TO_DATA", TO_DATA);
            ht.Add("@UPDATED_BY", UPDATED_BY);
            ht.Add("@SRT_ORDR", SRT_ORDR);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_DEL_MST_MPL_RANGE_FACTOR_PRATIK]", ht);
            resp.status = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string UpdateRangeFactor(string RNG_FACT_ID, string ACT_SCH_KEY, string FIX_FACTOR, string VAL_CODE, string FROM_DATA, string TO_DATA, string UPDATED_BY, string KPI_CODE,
        string ACTION_TYPE, int SRT_ORDR, string POS)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@RNG_FACT_ID", RNG_FACT_ID);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ht.Add("@FROM_DATA", FROM_DATA);
            ht.Add("@TO_DATA", TO_DATA);
            ht.Add("@UPDATED_BY", UPDATED_BY);
            ht.Add("@SRT_ORDR", SRT_ORDR);

            ht.Add("@POS", POS);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_MST_MPL_RANGE_FACTOR_PRATIK", ht);
            resp.status = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetRangeFactor(string ACT_SCH_KEY, string VAL_CODE, string FIX_FACTOR)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_GET_MST_MPL_RANGE_FACTOR_FROM_FIX_FACTOR]", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    //Updated By Pratik
    [WebMethod]
    public string GetRangeFactorBasedOnFF(string ACT_SCH_KEY, string FIX_FACTOR, string VAL_CODE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            //ht.Add("@FIX_FACTOR", FIX_FACTOR);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_GET_MST_MPL_RANGE_FACTOR_FROM_FIX_FACTOR]", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            resp.DataCount = ds.Tables[1].Rows.Count;

            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetConvRangeFactorBasedOnFF(string MODE, string ACT_SCH_KEY, string FIX_FACTOR, string VAL_CODE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
            ht.Add("@VALCODE_REQ", VAL_CODE);
            ht.Add("@MODE", MODE);
            //ht.Add("@ACT_SCHM_KEY", FIX_FACTOR);
            //ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_MPL_ConvRANGE_FACTORBYFF", ht);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GETCONVRFDDL", ht);
            resp.status = "0";
            resp.Data = ds.Tables[1];
            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string SaveMPL(string ACT_SCH_KEY, string FIX_FACTOR, dynamic RANGE_FACTOR, string MPL_FLAG, string RATE, string CREATED_BY)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@FIX_FACTOR", FIX_FACTOR);
            ht.Add("@RANGE_FACTOR", RANGE_FACTOR);
            ht.Add("@MPL_FLAG", MPL_FLAG);
            ht.Add("@RATE", RATE);
            ht.Add("@CREATED_BY", CREATED_BY);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_MPL_RANGE_FACTOR", ht);
            resp.status = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, CREATED_BY);
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string SaveMPLDetails(string ACT_SCH_KEY, string VAL_CODE, string RNG_FACT_ID, string FROM_DATA, string TO_DATA, string UPDATED_BY)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@RNG_FACT_ID", RNG_FACT_ID);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_CODE", VAL_CODE);
            ht.Add("@FROM_DATA", FROM_DATA);
            ht.Add("@TO_DATA", TO_DATA);
            ht.Add("@UPDATED_BY", UPDATED_BY);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_MST_MPL_RANGE_FACTOR", ht);
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetPendingData(string FIX_FACTOR, string ACT_SCH_KEY, string RANGE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
            ht.Add("@VAL_DATA", data.Tables[0]);
            if (RANGE == "N")
            {
                ds = objDal.GetDataSetForPrc_SAIM("PRC_GETPenMPLData_BKP", ht);
            }
            else
            {
                ds = objDal.GetDataSetForPrc_SAIM("PRC_GETWORNGPenMPLData", ht);
            }
            resp.status = "0";
            resp.Data = ds.Tables[0];
            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetUpdatedData(string ACT_SCHM_KEY, string RANGE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCHM_KEY", ACT_SCHM_KEY);
            if (RANGE == "N")
            {
                ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_DATA_BKP2", ht);
            }
            else
            {
                ds = objDal.GetDataSetForPrc_SAIM("PRC_GETWORNGUpdMPLData", ht);
            }
            resp.status = "0";
            resp.Data = ds.Tables[1];
            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string SaveConvRangeFactor(string ACT_SCH_KEY, string COVT_RANGE_FACTOR, string KPI_CODE, string ACTION_TYPE, string CREATED_BY, string TYPE, string IS_CONSIDER)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(COVT_RANGE_FACTOR);
            ht.Add("@MPL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@CREATED_BY", CREATED_BY);
            ht.Add("@IS_CONSIDER", IS_CONSIDER);
            ht.Add("@TYPE", TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_COVT_RANGE_FACTOR", ht);
            resp.status = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
            Response = JsonConvert.SerializeObject(resp);
        }

        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, CREATED_BY);
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string SaveWORangeFactor(string ACT_SCH_KEY, string FIX_FACTOR, string CREATED_BY, string IS_CONSIDER, string KPI_CODE, string ACTION_TYPE, string TYPE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable(); 
            DataSet ds = new DataSet();
            DataSet data = JsonConvert.DeserializeObject<DataSet>(FIX_FACTOR);
            ht.Add("@VAL_DATA", data.Tables[0]);
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ht.Add("@CREATED_BY", CREATED_BY);
            ht.Add("@IS_CONSIDER", IS_CONSIDER);
            ht.Add("@TYPE", TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_INS_FIXED_RANGE_FACTOR]", ht);
            resp.status = Convert.ToString(ds.Tables[0].Rows[0]["Response"]);
            resp.Data = Convert.ToString(ds.Tables[0].Rows[0]["ResponseText"]);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, CREATED_BY);
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetPendingAndUpdatedDataWithRange(string ACT_SCH_KEY, string KPI_CODE, string ACTION_TYPE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_GET_UPDATED_PENDING_DATA_WITH_RANGE]", ht);
            ds.Tables[0].TableName = "Updated";
            ds.Tables[1].TableName = "Pending";
            resp.status = "0";
            resp.Data = (ds);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    [WebMethod]
    public string GetPendingAndUpdatedDataWithoutRange(string ACT_SCH_KEY, string KPI_CODE, string ACTION_TYPE)
    {
        string Response = "";
        ResponseClass resp = new ResponseClass();
        try
        {
            DataAccessClass objDal = new DataAccessClass();
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Add("@ACT_SCH_KEY", ACT_SCH_KEY);
            ht.Add("@KPI_CODE", KPI_CODE);
            ht.Add("@ACTION_TYPE", ACTION_TYPE);
            ds = objDal.GetDataSetForPrc_SAIM("[PRC_GET_UPDATED_PENDING_DATA_WITHOUT_RANGE]", ht);
            ds.Tables[0].TableName = "Updated";
            ds.Tables[1].TableName = "Pending";
            resp.status = "0";
            resp.Data = (ds);
            Response = JsonConvert.SerializeObject(resp);
        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            string sRet = new System.IO.FileInfo(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName()).Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            string error = Convert.ToString(ex.Message + " " + ex.InnerException);
            objErr.LogErr("ISYS-SAIM-WS", sRet, method.Name.ToString(), error, "");
            resp.status = "1";
            resp.Data = error;
            Response = JsonConvert.SerializeObject(resp);
        }
        return Response;
    }

    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
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
            throw ex;
        }

        return Rest;
    }

    public class ResponseClass
    {
        public string status { get; set; }
        public object Data { get; set; }
        public object DataCount { get; set; }

    }
}

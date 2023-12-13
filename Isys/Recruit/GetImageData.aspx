<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetImageData.aspx.cs" Inherits="Application_ISys_Recruit_GetImageData" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <rsweb:ReportViewer ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer> 
        <asp:SqlDatasource ID="SqlDatasource1" runat="server" ConnectionString="INSCRecruitConnectionString"
        SelectCommand="prc_GetAgtId" SelectCommandType="StoredProcedure">
  <SelectParameters>
     <asp:ControlParameter Name="@cndNO" ControlID="controlThatHoldsParameterValue" PropertyName="Text" />
  </SelectParameters>
    </asp:SqlDataSource>
        
    </div>
    </form>
</body>
</html>

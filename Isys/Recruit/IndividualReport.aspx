<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="IndividualReport.aspx.cs" Inherits="Application_ISys_Recruit_IndividualReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" language="javascript">
        function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<table class="container" width="95%">--%>
        <div class="panel panel-success">
            <%--<tr>
                <td align="center">--%>
            <div class="card">
                 <div id="divSearch" runat="server" class="panel-body">
                  <div class="row">
                    <asp:Panel ID="pnlRpt" runat="server" Visible="false">
                      <%--  <table>
                            <tr>
                                <td style="width: 100%;">--%>
                                <div>
                                    <rsweb:ReportViewer ID="RptVwReport" runat="server" Width="100%" Height="405px"
                                        PageCountMode="Actual">
                                    </rsweb:ReportViewer>
                                    </div>
                               <%-- </td>
                            </tr>
                            <tr>--%>
                               <%-- <td>--%>
                               <div class="row" style="margin-top: 12px;display:none;">
                            <div class="col-sm-12" align="center">
                                   <%-- <asp:Button ID="btnCancel" runat="server" OnClientClick="doCancel(); return false" Text="Cancel" />--%>
                                   <asp:LinkButton ID="btnCancel" OnClientClick="doCancel(); return false" CssClass="btn btn-danger" 
                                    TabIndex="5" runat="server">
                                 <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel</asp:LinkButton>
                                    </div>
                                    </div>
                               <%-- </td>
                            </tr>--%>
                  <%--      </table>--%>
                    </asp:Panel>
                </div>
                </div>
            </div>
            </div>
        <%--</table>--%>
    </center>
</asp:Content>

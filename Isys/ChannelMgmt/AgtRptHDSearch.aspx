<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AgtRptHDSearch.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_AgtRptHDSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Search Reporting Head Code</title>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/style.css" type="text/css" rel="Stylesheet" />
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2) {
            
            window.parent.document.getElementById('<%=Request.QueryString["strrpthdcode"].ToString()%>').innerText = doEncodeToParent(args2);
            window.parent.document.getElementById('<%=Request.QueryString["code"].ToString()%>').value = doEncodeToParent(args1);
            window.parent.document.getElementById('<%=Request.QueryString["lblcode"].ToString()%>').innerText = doEncodeToParent(args1);
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtRptHDCode.ClientID%>").value = "";
            document.getElementById("<%=txtRptHDName.ClientID%>").value = "";
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <div>
        <center>
            <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            <div style="text-align: center">
                <table class="formtable table-condensed" width="100%">
                    <tr>
                        <td class="test formHeader" colspan="4">
                            Search Criteria
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblRptHDCode1" runat="server" Width="141px"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtRptHDCode" runat="server" CssClass="standardmenu" Width="70%"></asp:TextBox>
                        </td>
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblRptHDName" runat="server" Width="151px"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtRptHDName" runat="server" CssClass="standardmenu" Width="70%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4" style="height: 20px; text-align: center;" align="center">
                            <asp:Button ID="btnSearchRp" runat="server" CssClass="standardbutton" Text="SEARCH"
                                Width="80px" OnClick="btnSearchRp_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnClearField" runat="server" CssClass="standardbutton" Text="CLEAR"
                                Width="80px" OnClientClick="doClear();return false;" />&nbsp;&nbsp;
                            <asp:Button ID="btncancel" runat="server" CssClass="standardbutton" Text="CANCEL"
                                Width="80px" OnClientClick="doCancel();return false;" />
                        </td>
                    </tr>
                    <tr>
                        <td class="test formHeader" colspan="2">
                            Search Result
                        </td>
                        <td class="test formHeader" colspan="2" style="text-align:right;">
                            <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4">
                            <asp:GridView ID="gvDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                HorizontalAlign="Left" Width="100%" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center" AllowSorting="True"
                                OnPageIndexChanging="gvDetails_PageIndexChanging" OnSorting="gvDetails_Sorting"
                                OnRowDataBound="gvDetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="RptHeadCode" SortExpression="AgentCode">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:LinkButton ID="lnkRptHDCode" runat="server" Text='<%# Bind("AgentCode") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="RptHeadName" DataField="LegalName" SortExpression="LegalName" ItemStyle-HorizontalAlign="Left" />
                                </Columns>
                                <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White"/>
                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                <RowStyle CssClass="sublinkodd" />
                                <AlternatingRowStyle CssClass="sublinkeven" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </div>
</asp:Content>

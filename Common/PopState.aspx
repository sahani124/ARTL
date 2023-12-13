<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopState.aspx.cs"
    Inherits="Application_Receipt_PopLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2) {
            window.parent.document.getElementById('<%=Request.QueryString["field1"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["field2"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["field1"].ToString()%>').focus();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtStateCode.ClientID%>").value = "";
            document.getElementById("<%=txtStateDesc.ClientID%>").value = "";
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

    </script>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <div>
        <table class="formtable" width="100%">
            <tr>
                <td class="test" width="100%" align="center" colspan="4">
                    <asp:Label ID="lblhdr" runat="server" Text="State Search" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                    <asp:Label ID="lblStateCode" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:TextBox CssClass="standardtextbox" ID="txtStateCode" runat="server"></asp:TextBox>
                </td>
                <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                    <asp:Label ID="lblStateDesc" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:TextBox CssClass="standardtextbox" ID="txtStateDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formcontent" colspan="4" style="text-align: center">
                    <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search" Width="60px" OnClick="btnSearch_Click" />&nbsp
                    <asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" Width="60px" OnClientClick="doClear();return false;" />&nbsp
                    <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel" Width="60px"
                        OnClientClick="doCancel();return false;" />
                </td>
            </tr>
            <tr>
                <td class="formcontent" colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="msgerror2" Visible="False"></asp:Label>
                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" OnSorting="gv_Sorting"
                                PageSize="10" Width="100%">
                                <HeaderStyle CssClass="test" ForeColor="DarkBlue" HorizontalAlign="Center" />
                                <AlternatingRowStyle CssClass="sublinkeven" />
                                <RowStyle CssClass="sublinkodd" />
                                <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="State Code" SortExpression="ParamValue">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ParamDesc" HeaderText="State Name" SortExpression="ParamDesc"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80%" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

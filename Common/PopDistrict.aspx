<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopDistrict.aspx.cs"
    Inherits="Application_Common_PopDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">

        function doSelect(args1, args2, args3, args4) {
            window.parent.document.getElementById('<%=Request.QueryString["DistDesc"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["strHDist"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["shdnPinFrom"].ToString()%>').value = args3;
            window.parent.document.getElementById('<%=Request.QueryString["shdnPinTo"].ToString()%>').value = args4;
            window.parent.document.getElementById('<%=Request.QueryString["DistDesc"].ToString()%>').disabled = false;
            //window.parent.document.getElementById('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //$find("mdlViewBID").show();
            //window.parent.window.hidePopWin(false);
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtDistDesc.ClientID%>").value = "";
        }

        function doCancel() {
            //window.parent.window.hidePopWin(false);
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

    </script>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="100%" DefaultButton="btnSearch">
            <table class="formtable" width="100%">
                <%--<tr>
                    <td class="formcontent" nowrap="nowrap">
                        <asp:Label ID="lblDistCode" runat="server" Text="State Code"></asp:Label>
                    </td>
                    <td class="formcontent" width="100%">
                        <asp:TextBox CssClass="standardtextbox" ID="txtStateCode" runat="server"></asp:TextBox></td>
                </tr>--%>
                <tr>
                    <td align="center" class="test" colspan="2">
                        <asp:Label ID="lblhdr" runat="server" Text="District Search" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" nowrap="nowrap">
                        <asp:Label ID="lblDistDesc" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" width="100%">
                        <asp:TextBox CssClass="standardtextbox" ID="txtDistDesc" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" colspan="2" style="text-align: center">
                        <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search"
                            OnClick="btnSearch_Click" />
                        <asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" OnClientClick="doClear();return false;" />
                        <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel"
                            OnClientClick="doCancel();return false;" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblErrMsg" runat="server" CssClass="msgerror2" Visible="False"></asp:Label>
                                <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                    PageSize="12" Width="100%" OnRowDataBound="gv_RowDataBound" OnSorting="gv_Sorting"
                                    OnPageIndexChanging="gv_PageIndexChanging">
                                    <HeaderStyle CssClass="test" ForeColor="DarkBlue" />
                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                    <RowStyle CssClass="sublinkodd" />
                                    <PagerStyle CssClass="pagelink" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="District" SortExpression="District">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("District") %>'></asp:LinkButton>
                                                <asp:HiddenField ID="hdnDist" runat="server" Value='<%# Bind("District") %>' />
                                                <asp:HiddenField ID="hdnPinFrom" runat="server" Value='<%# Bind("PinCode_From") %>' />
                                                <asp:HiddenField ID="hdnPinTo" runat="server" Value='<%# Bind("PinCode_To") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ParamDesc" HeaderText="State Name" SortExpression="ParamDesc" />
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
            <table>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

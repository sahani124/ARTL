<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopCountry.aspx.cs"
    Inherits="Application_Receipt_PopLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2) {
            window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = doEncodeToParent(args1);
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = doEncodeToParent(args2);
            window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').focus();
            //Added by rachana on 08-07-2013 start
            //window.parent.window.hidePopWin(false);
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //Added by rachana on 08-07-2013 end 
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtCountryCode.ClientID%>").value = "";
            document.getElementById("<%=txtCountryDesc.ClientID%>").value = "";
        }

        function doCancel() {
            //Added by rachana on 08-07-2013 start
            //window.parent.window.hidePopWin(false);
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //Added by rachana on 08-07-2013 end
        }
    </script>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="0%" Width="99%" DefaultButton="btnSearch">
            <table class="formtable" width="100%">
                <tr>
                    <td align="center" class="test" colspan="4">
                        <asp:Label ID="lblhdr" runat="server" Text="Country Search" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" nowrap="nowrap" style="width:20%;">
                        <asp:Label ID="lblCountryCode" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width:30%;">
                        <asp:TextBox CssClass="standardtextbox" ID="txtCountryCode" runat="server"></asp:TextBox>
                    </td>
                    <td class="formcontent" nowrap="nowrap" style="width:20%;">
                        <asp:Label ID="lblCountryDesc" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width:30%;">
                        <asp:TextBox CssClass="standardtextbox" ID="txtCountryDesc" runat="server"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" colspan="4" align="center" style="text-align: center">
                        <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search" Width="60px"
                            OnClick="btnSearch_Click" />&nbsp
                            <asp:Button class="standardbutton" ID="btnClear" runat="server" Width="60px"
                                Text="Clear" OnClientClick="doClear();return false;" />&nbsp
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
                                    <%--ForeColor added by kalyani on 3-1-2014--%>
                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                    <RowStyle CssClass="sublinkodd" />
                                    <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Country Code" SortExpression="ParamValue">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ParamDesc" HeaderText="Country Name" SortExpression="ParamDesc" ItemStyle-HorizontalAlign="Left" />
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
        </asp:Panel>
    </div>
</asp:Content>

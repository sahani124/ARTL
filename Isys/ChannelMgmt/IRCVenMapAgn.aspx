<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="IRCVenMapAgn.aspx.cs" Inherits="Application_INSC_ChannelMgmt_IRCVenMapAgn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <center>
        <asp:UpdatePanel ID="updVendor" runat="server">
            <ContentTemplate>
                <table class="formtable" border="1" style="width: 100%;">
                    <tr>
                        <td colspan="2" class="test formHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="Agent Vendor Mapping Details"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMsg" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gv_AgentVendorMap" runat="server" Width="100%" AutoGenerateColumns="False"
                                HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_AgentVendorMap_PageIndexChanging"
                                OnSorting="gv_AgentVendorMap_Sorting" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Agent Code" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="AgentCode" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgentCode" runat="server" Text='<%# Eval("MemCode") %>'> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Code" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="VendorCode" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorCode" runat="server" Text='<%# Eval("VendorCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="VendorName" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="Status" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Relationship Code" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="VendorBasID" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorBasID" runat="server" Text='<%# Eval("VendorBasID") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Primary" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="PrmyFlag" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrimary" runat="server" Text='<%# Eval("PrmyFlag") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rel Start Date" HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px"
                                        SortExpression="RelStartDate" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRelStartDate" runat="server" Text='<%# Eval("RelStartDate") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbViewIRC" Text="ViewIRC" OnClick="lbViewIRC_Active_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White" />
                                <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                                <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue"></RowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gv_AgentVendorMapIRC" runat="server" Width="100%" AutoGenerateColumns="False"
                                HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_AgentVendorMapIRC_PageIndexChanging"
                                OnSorting="gv_AgentVendorMapIRC_Sorting" Visible="false">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" SortExpression="Vendor Code"
                                        HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgentCode" runat="server" Text='<%# Eval("AgentCode") %>'> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" SortExpression="Vendor Code"
                                        HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorCode" runat="server" Text='<%# Eval("VendorCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" SortExpression="Vendor Name"
                                        HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" SortExpression="Vendor Code"
                                        HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Business Model" HeaderStyle-Font-Size ="11px" HeaderStyle-Height = "10px" SortExpression="Vendor Code" HeaderStyle-CssClass ="standardlink">
               <ItemTemplate>
                <asp:Label ID="lblBusinessModel" runat="server" Text='<%# Eval("BusinessModel") %>'>
               
               </asp:Label>
               </ItemTemplate>


               </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" SortExpression="Vendor Code"
                                        HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorBasID" runat="server" Text='<%# Eval("VendorBasID") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Size="11px" HeaderStyle-Height="10px" HeaderStyle-CssClass="standardlink">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrimary" runat="server" Text='<%# Eval("PrmyFlag") %>'>
               
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbViewIRC" Text="ViewIRC" OnClick="lbViewIRC_Active_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbAddNew" Text="Add IRC" OnClick="lbAddNew_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White" />
                                <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                                <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue"></RowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" id="trGridIRC" class="test formHeader" style="text-align: left;"
                            colspan="2" runat="server" visible="false">
                            <asp:Label ID="Label1" runat="server" Text="IRC Code Listing"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gv_IRCCODE" runat="server" Width="100%" AutoGenerateColumns="False"
                                HorizontalAlign="center" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                PagerStyle-ForeColor="blue" AllowPaging="True" PageSize="5" OnPageIndexChanging="gv_IRCCODE_PageIndexChanging"
                                OnSorting="gv_IRCCODE_Sorting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIRCCOde" runat="server" Text='<%# Eval("IRCCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgentCOde" runat="server" Text='<%# Eval("MemCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLegalName" runat="server" Text='<%# Eval("LegalName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgentType" runat="server" Text='<%# Eval("MemType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBizSrc" runat="server" Text='<%# Eval("BizSrc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblChnCls" runat="server" Text='<%# Eval("ChnCls") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Vendor CODE">
                   <ItemTemplate>
                  <asp:Label ID="lblVendorCode" runat="server" Text='<%# Eval("VendorCode") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>--%>
                                </Columns>
                                <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White" />
                                <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Blue"></PagerStyle>
                                <RowStyle CssClass="formsublinkeven" HorizontalAlign="Left" ForeColor="Blue"></RowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="center" style="text-align: center" colspan="2">
                            <%--<asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search"
                        Width="60px" onclick="btnSearch_Click" />&nbsp--%>
                            <%--<asp:Button class="standardbutton" ID="btnClear" runat="server" Width="60px" Text="Clear"
                        OnClientClick="doClear();return false;" />&nbsp--%>
                            <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="CANCEL"
                                Width="80px" OnClientClick="doCancel();return false;" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

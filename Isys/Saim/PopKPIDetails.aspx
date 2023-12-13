<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopKPIDetails.aspx.cs" Inherits="Application_ISys_Saim_PopKPIDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function doOk() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnkpi").click();
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <center>
        <table class="tableIsys" style="width: 100%;">
            <tr>
                <td class="test formHeader" style="padding-left: 5px;">
                    <asp:Label ID="lblKPISrch" Text="KPI Search" runat="server" />
                </td>
            </tr>
        </table>
        <table class="formtable3" style="width: 100%;">
            <tr>
                <td class="formtable3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgKPI" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                                Width="100%" AllowPaging="True" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                BorderStyle="Solid" BorderColor="Gray" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                AllowSorting="True" OnRowDataBound="dgKPI_RowDataBound">
                                <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                <AlternatingRowStyle CssClass="sublinkeven" />
                                <Columns>
                                    <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkKPICode" Text='<%# Bind("KPICode")%>' runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI Description" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPIDesc1" Text='<%# Bind("KPIDesc1")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPIType" Text='<%# Bind("KPIType")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPIOrigin" Text='<%# Bind("KPIOrigin")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eff. Frm" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRangeFrm" Text='<%# Bind("RangeFrm")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRangeTo" Text='<%# Bind("RangeTo")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Version" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVersion" Text='<%# Bind("Version")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table class="tableIsys" style="width: 100%;">
            <tr>
                <td class="formcontent" style="text-align: center;">
                    <asp:Button ID="btnOK" Text="OK" runat="server" CssClass="standardbutton" OnClick="btnOK_Click" Width="80px"/>
                    <asp:Button ID="btnCancel" Text="CANCEL" runat="server" 
                        CssClass="standardbutton"  Width="80px" 
                        OnClientClick="doCancel();return false;"/>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopSearchUnitRank.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopSearchUnitRank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <%--Added by rachana on 16/05/2013 for AJAX controls start--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--Added by rachana on 16/05/2013 for AJAX controls end--%>
        <br />
        <asp:UpdatePanel ID="up_UnitR" runat="server">
            <ContentTemplate>
                <table align="center" width="80%">
                    <tr style="height:30px;">
                        <td colspan="4" rowspan="4" align="center">
                            <table style="border-collapse: separate; left: 0in; position: relative; top: 1px;
                                height: 24px;" width="80%" class="tableIsys">
                                <tr style="height:30px;">
                                    <td align="left" class="test formHeader" colspan="4">
                                        <%--Added by rachana on 14/05/2013 for changing CSS class name--%>
                                        <asp:Label ID="lblChannelUnitRankSetup" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td align="right" class="formcontent" style="width: 20%; height: 21px">
                                        <asp:Label ID="lblChnlType" runat="server" Height="22px" Width="150px"></asp:Label>
                                    </td>
                                    <td align="center" class="formcontent" style="height: 23px; width: 30%;">
                                        <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    TabIndex="8" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="1" Text="Channel"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td align="right" class="formcontent" style="width: 20%; height: 21px">
                                        <asp:Label ID="lblSaleschannel" runat="server" Height="22px" Width="150px"></asp:Label>
                                    </td>
                                    <td align="center" class="formcontent" style="height: 21px; width: 30%;">
                                        <asp:UpdatePanel ID="upChnnl" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="standardmenu" Width="200px"
                                                    Height="21px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                               <tr>
                            <td class="formcontent">
                                <asp:Label Text="Financial Year" ID="lblFincYear" runat="server" />
                            </td>
                                <td class="formcontent">
                                    <asp:UpdatePanel ID="updfinyr" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList runat="server" CssClass="standardmenu" AutoPostBack="true" Width="200px" 
                                        ID="ddlFincYear" onselectedindexchanged="ddlFincYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent">
                                    <asp:Label Text="Version" ID="lblBaseVersion" runat="server" />
                                </td>    
                                <td class="formcontent">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                 <asp:DropDownList runat="server" CssClass="standardmenu" AutoPostBack="true " Width="200px" ID="ddlBaseVersion">
                                    </asp:DropDownList>
                                     </ContentTemplate>
                                     <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlFincYear" EventName="selectedindexchanged" />
                                     </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                                <tr style="height:30px;">
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                            Text="SEARCH" Width="80px" OnClick="btnSearch_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                                            Text="CLEAR" Width="80px" OnClick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table align="center" cellspacing="0" class="formtable" style="width: 80%" id="tbldgDtls" runat="server">
                    <tr id="trDetails" runat="server" style="width: 80%;height:30px;">
                        <td colspan="3" align="left" class="test formHeader" style="border-collapse: separate;
                            border-right-width: 0">
                            <asp:Label ID="lblUnitRankSearchResult" runat="server" Font-Bold="true"></asp:Label>
                            <span style="padding-left: 570px;"></span>
                            <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                        <%--Added by Rachana on 14/05/2013 for changing CSS class name start--%>
                        <%--<td align="right" style="border-collapse: separate;" class="test">
                </td>--%>
                        <%--Added by Rachana on 14/05/2013 for changing CSS class name end--%>
                    </tr>
                    <tr id="trDgDetails" runat="server" style="width: 100%;height:30px;">
                        <td align="center" class="formcontent" colspan="4" style="height: 21px">
                            <asp:UpdatePanel ID="upUnitRank" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                         Width="100%" AllowPaging="True" AllowSorting="True"
                                        OnPageIndexChanging="dgDetails_PageIndexChanging" OnSorting="dgDetails_Sorting">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sales Channel" DataField="ChannelDesc01" SortExpression="ChannelDesc01">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitRank" HeaderText="Unit Rank" SortExpression="UnitRank" />
                                            <asp:TemplateField ShowHeader="false" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluntRnk" runat="server" Text='<%# Bind("UnitRank") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Unit Rank Description" HeaderStyle-Width="180px" DataField="UnitRankDesc01"
                                                SortExpression="UnitRankDesc01">
                                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Period" SortExpression="Period" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFincYear" Text='<%# Eval("Period")%>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Version"  SortExpression="BaseVersion" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVersion" Text='<%# Eval("BaseVersion")%>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date" SortExpression="EffDate" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEffDate" Text='<%# Eval("EffDate")%>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cease Date" SortExpression="CeaseDate" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCeaseDate" Text='<%# Eval("CeaseDate")%>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerSettings Mode="Numeric" />
                                        <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                        <RowStyle CssClass="sublinkodd"></RowStyle>
                                        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

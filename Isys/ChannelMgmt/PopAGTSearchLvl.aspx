<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopAGTSearchLvl.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopAGTSearchLvl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .pagelink span
        {
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
    </script>
    <%--Added by Pranjali on 28-05-2013 for modal popup display start--%>
    <asp:ScriptManager ID="SM1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <%--Added by Pranjali on 28-05-2013 for modal popup display end--%>
    <asp:UpdatePanel ID="updagt" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <table style="border-collapse: separate; position: relative; top: 3px;" width="80%"
                    class="tableIsys">
                    <tr style="height:25px;">
                        <td colspan="4" align="left" class="test" style="height: 32px">
                            <%--Changed by Pranjali on 28-05-2013 for class name --%>
                            <asp:Label ID="lblAgtTypeSearch" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="formcontent" align="left" style="width: 25%">
                            <asp:Label ID="lblChnlType" runat="server"></asp:Label>
                        </td>
                        <td class="formcontent" align="left" style="width:  25%">
                            <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        TabIndex="8" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1" Text="Channel"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" align="left" colspan="2">
                           
                        </td>
                    </tr>
                    <tr style="height:25px;">
                        <td class="formcontent">
                            <asp:Label ID="lblSalesChannel" runat="server" Width="143px"></asp:Label>
                        </td>
                        <td class="formcontent">
                            <asp:UpdatePanel ID="upddlSales" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="standardmenu" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged" Height="21px" Width="220px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" align="left" style="width: 86px">
                            <asp:Label ID="lblChnnlClass" runat="server" Width="143px"></asp:Label>
                        </td>
                        <td class="formcontent">
                            <asp:UpdatePanel ID="upddlChnlCls" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnnlClass" runat="server" CssClass="standardmenu" Height="21px"
                                        Width="220px" OnSelectedIndexChanged="ddlChnnlClass_SelectedIndexChanged">
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
                    <tr style="height:25px;">
                        <td colspan="4" align="center">
                            <input id="flgHidden" type="hidden" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                    Text="SEARCH" Width="80px" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                                    Text="CLEAR" Width="80px" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                <table width="80%">
                    <tr>
                        <td align="center" style="height: 21px">
                            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="620px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellspacing="0" class="tableIsys" style="width: 100%" id="tbdgDtls" runat="server">
                            <tr id="trDetails" runat="server" style="width: 100%;height:25px;">
                                <td colspan="3" align="left" class="test" style="border-collapse: separate; border-right-width: 0;">
                                    <asp:Label ID="lblAgtTypSearchRes" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td align="right" style="border-collapse: separate; height: 20px;" class="test">
                                    <asp:Label ID="lblPageInfo" runat="server" Font-Bold="false"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trDgDetails" runat="server" style="width: 100%;height:25px;">
                                <td class="formcontent" colspan="4">
                                    <asp:UpdatePanel ID="updgDetails" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                 Width="100%" OnPageIndexChanging="dgDetails_PageIndexChanging"
                                                PagerStyle-HorizontalAlign="Center" AllowSorting="True" OnSorting="dgDetails_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Hierarchy Name" DataField="ChannelDesc" SortExpression="ChannelDesc">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ChnlDesc" HeaderText="Sub Class" SortExpression="ChnlDesc">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Unit Rank" DataField="UnitRank" SortExpression="UnitRank" />
                                                    <asp:BoundField HeaderText="Member Level" DataField="MemLevel" SortExpression="MemLevel" />
                                                    <asp:BoundField HeaderText="Member Type" DataField="MemTypeDesc01" SortExpression="MemTypeDesc01">
                                                        <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmemtyp" runat="server" Text='<%#Bind("MemType")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblbizsrc" runat="server" Text='<%#Bind("BizSrc")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblchncls" runat="server" Text='<%#Bind("ChnCls")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                                <HeaderStyle CssClass="portlet box blue" HorizontalAlign="Center" ForeColor="White" />
                                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


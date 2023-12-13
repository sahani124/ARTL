<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopSearchUnitNew.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopSearchUnitNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .pagelink span
        {
            font-weight: bold;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <asp:UpdatePanel ID="upUnitType" runat="server">
            <ContentTemplate>
                <table align="center"  style="width: 80%;">
                    <tr style="height:30px;">
                        <td colspan="3" rowspan="3" align="center" style="height: 88px;">
                            <table style="border-collapse: separate; left: -0.01in; position: relative; top: 1px;
                                height: 24px;" width="50%" class="tableIsys">
                                <tr style="height:30px;">
                                    <td class="test" colspan="4" align="left">
                                        <%--Added By Ibrahim on 18-05-2013 modified class="formtitle" to class="test" to change banner background --%>
                                        <asp:Label ID="lblChannelUnitTypesetup" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="formcontent" align="left" style="width: 62px;">
                                        <asp:Label ID="lblChnlType" runat="server" Height="22px" Width="168px" Text="Channel Type"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    TabIndex="1" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="1" Text="Channel"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" align="left" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td class="formcontent" align="left" style="width: 62px;">
                                        <asp:Label ID="lblSaleschannel" runat="server" Height="22px" Width="168px"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:UpdatePanel runat="server" ID="upnlSalesChannel">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="standardmenu" Height="21px"
                                                    Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged"
                                                    TabIndex="2">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:Label ID="lblChnnlClass" runat="server" Width="122px"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:UpdatePanel runat="server" ID="upnlChnnlClass">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnnlClass" runat="server" CssClass="standardmenu" Width="200px"
                                                    Height="21px" TabIndex="3">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                </asp:AsyncPostBackTrigger>
                                            </Triggers>
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
                                        <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="4"
                                            Text="SEARCH" Width="90px" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="5" Text="CLEAR"
                                            Width="90px" OnClick="btnClear_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <table align="center"  style="width: 80%;">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="659px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="tableIsys" align="center"  style="width: 100%;" id="tbldgDtls"
                    runat="server">
                    <tr id="trDetails" runat="server" style="width: 70%;height:30px;">
                        <td class="test" colspan="4" align="left" style="border-collapse: separate; border-right-width: 0;
                            height: 32px;">
                            <asp:Label ID="lblChannelUnitTypeSearch" runat="server" Font-Bold="true"></asp:Label>
                            <span style="padding-left: 73%;"></span>
                            <asp:Label ID="lblPageInfo" runat="server" Font-Bold="false"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr id="trDgDetails" runat="server" style="width: 100%;height:30px;">
                        <td align="center" class="formcontent" colspan="4" >
                            <asp:UpdatePanel ID="updgDetails" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                         Width="100%" AllowPaging="True" AllowSorting="True"
                                         OnPageIndexChanging="dgDetails_PageIndexChanging"
                                         OnSorting="dgDetails_Sorting" >
                                        <Columns>
                                            <asp:BoundField HeaderText="Channel Code" DataField="BizSrcLinkDecs" HeaderStyle-Width="150px"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" SortExpression="BizSrc">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Sub Class" DataField="ChnclsLinkDesc" HeaderStyle-Width="200px"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" SortExpression="ChnCls">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitType" HeaderText="Unit Type" HeaderStyle-Width="120px"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="UnitType">
                                            </asp:BoundField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluntyp" Text='<%# Bind("UnitType") %>' runat="server" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Unit Rank" DataField="UnitRank" HeaderStyle-Width="120px"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="UnitRank">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Level" DataField="UnitLevel" HeaderStyle-Width="120px"
                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="UnitLevel">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unit Type Desc" DataField="UnitDesc01" HeaderStyle-Width="120px"
                                                SortExpression="UnitDesc01">
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
                                        <%--Added By Ibrahim on 18-05-2013 modified class="formlink" to class="test" to change banner background --%>
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
</asp:Content>


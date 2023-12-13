<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CompSetupSearch.aspx.cs"
    Inherits="Application_ISys_Saim_CompSetupSearch" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table style="width: 85%;" class="tableIsys">
                        <tr style="height: 25px;">
                            <td align="left" colspan="4" class="test">
                                <asp:Label ID="lblcmpsetup" runat="server" Text="Computation Setup Search" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%; height: 26px;">
                                <asp:Label ID="lblcmpTyp" runat="server" Text="Comp. Type"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCmpTyp" runat="server" Width="140px" CssClass="standardtextbox"></asp:TextBox>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblcmpDesc" runat="server" Text="Comp. Type Desc."></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCmpDesc" runat="server" Width="140px" CssClass="standardtextbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%; height: 26px;">
                                <asp:Label ID="lblFreq" runat="server" Text="Frequency"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:DropDownList ID="ddlFrequency" runat="server" CssClass="standardmenu" Width="140px">
                                </asp:DropDownList>
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblEffDt" runat="server" Text="Effective Date"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtEffDt" runat="server" Width="140px" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="cldext" Format="dd/MM/yyyy" PopupButtonID="btnCalendar"
                                    TargetControlID="txtEffDt" runat="server">
                                </ajaxToolkit:CalendarExtender>
                                <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 26px; text-align: center;">
                                <asp:UpdatePanel ID="updsetbtn" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" CssClass="standardbutton"
                                            Width="80px" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnClear" runat="server" Text="CLEAR" CssClass="standardbutton" Width="80px"
                                            OnClick="btnClear_Click" />
                                        <asp:Button ID="btnAddNew" runat="server" Text="ADD NEW" CssClass="standardbutton"
                                            Width="80px" OnClick="btnAddNew_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 85%;padding: 10px;" class="tableIsys">
                        <tr id="trDetails" runat="server" visible="false">
                            <td align="left" class="test formHeader" style="border-collapse: separate;">
                                <asp:Label ID="lblAgtSrchRes" runat="server" Text="Computation Setup Search Results"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trDgDetails" runat="server" visible="false">
                            <td>
                                <asp:GridView ID="gvCompSetup" runat="server" Width="100%" AutoGenerateColumns="False"
                                    EnableTheming="True" onpageindexchanging="gvCompSetup_PageIndexChanging" AllowPaging="true" AllowSorting="true"
                                    onsorting="gvCompSetup_Sorting">
                                    <HeaderStyle CssClass="portlet box blue" HorizontalAlign="Center" ForeColor="White" />
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Comp. Type" SortExpression="CompType" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompType" runat="server" Text='<%# Bind("CompType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Comp. Type Desc." DataField="CompDesc01" SortExpression="CompDesc01" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderText="Frequency" DataField="Frequency" SortExpression="Frequency" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderText="Effective Date" SortExpression="EffDate" DataField="EffDate" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkViewRule" runat="server" Text="View Rule" OnClick="lnklnkViewRule_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="width: 85%;" class="tableIsys">
                        <tr id="trrulehdr" runat="server" visible="false">
                            <td align="left" class="test formHeader" style="border-collapse: separate;">
                                <asp:Label ID="lblrulestpsrch" runat="server" Text="Computation Rule Setup Search Results"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trrulegrid" runat="server" visible="false">
                            <td>
                                <asp:GridView ID="gvCompRuleSetup" runat="server" Width="100%" AutoGenerateColumns="False"
                                    EnableTheming="True" OnRowDataBound="gvCompRuleSetup_RowDataBound" AllowPaging="true" AllowSorting="true"
                                    onpageindexchanging="gvCompRuleSetup_PageIndexChanging" 
                                    onsorting="gvCompRuleSetup_Sorting">
                                    <HeaderStyle CssClass="portlet box blue" HorizontalAlign="Center" ForeColor="White" />
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Rule No." SortExpression="CompRuleNo" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompRuleNo" runat="server" Text='<%# Bind("CompRuleNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comp. Code" SortExpression="CompCode" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompCode" runat="server" Text='<%# Bind("CompCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Comp. Name" DataField="CompName" 
                                            SortExpression="CompName" ItemStyle-HorizontalAlign="Left" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" />
                                        <asp:BoundField HeaderText="Channel Sub Class" DataField="ChnCls" SortExpression="ChnCls" />
                                        <asp:BoundField HeaderText="Member Type" DataField="MemType" SortExpression="MemType" />
                                        <asp:BoundField HeaderText="Effective Date" DataField="EffDate" SortExpression="EffDate" />
                                        <asp:TemplateField HeaderText="View Product">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkViewProduct" runat="server" Text="View Product" OnClick="lnkViewProduct_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View KPI">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkViewKPI" runat="server" Text="View KPI" 
                                                    onclick="lnkViewKPI_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Action" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table style="width: 85%;" class="tableIsys">
                        <tr id="tr1" runat="server" visible="false">
                            <td align="left" class="test formHeader" style="border-collapse: separate;">
                                <asp:Label ID="lblKPIHdr" runat="server" Text="Computation Rule KPI Details Search Results"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trkpi" runat="server" visible="false">
                            <td>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgKPI" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                                            Width="100%" AllowPaging="True" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                            BorderStyle="Solid" BorderColor="Gray" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                            AllowSorting="True" >
                                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                            <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="sublinkeven" />
                                            <Columns>
                                            <asp:TemplateField HeaderText="Rule No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkRuleNo" Text='<%# Bind("RuleNo")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkCompCode" Text='<%# Bind("CompCode")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
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
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table style="width: 85%;" class="tableIsys">
                        <tr id="trruledtlhdr" runat="server" visible="false">
                            <td align="left" class="test formHeader" style="border-collapse: separate;">
                                <asp:Label ID="lblCompRuleDtlStp" runat="server" Text="Computation Rule Details Setup Search Results"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trruledtlsgrid" runat="server" visible="false">
                            <td>
                                <asp:GridView ID="gvCompRuleDtlSetup" runat="server" Width="100%" AutoGenerateColumns="False"
                                    EnableTheming="True" onrowdatabound="gvCompRuleDtlSetup_RowDataBound" AllowPaging="true" AllowSorting="true"
                                    onpageindexchanging="gvCompRuleDtlSetup_PageIndexChanging" 
                                    onsorting="gvCompRuleDtlSetup_Sorting">
                                    <HeaderStyle CssClass="portlet box blue" HorizontalAlign="Center" ForeColor="White" />
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Rule No." DataField="CompRuleNo" SortExpression="CompRuleNo" />
                                        <asp:BoundField HeaderText="Comp. Code" DataField="CompCode" SortExpression="CompCode" />
                                        <asp:TemplateField HeaderText="Product Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdCode" runat="server" Text='<%# Bind("ProdCode") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Product" DataField="Product" SortExpression="Product" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField HeaderText="PRD From" DataField="ProdFrom" SortExpression="ProdFrom" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="PRD To" DataField="ProdTo" SortExpression="ProdTo" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="Comp. Amt" DataField="CompAmt" SortExpression="CompAmt" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="Comp. Rate" DataField="CompRate" SortExpression="CompRate" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="Perf. Indicator" DataField="PerfDesc" SortExpression="PerfDesc" ItemStyle-HorizontalAlign="Left"/>
                                        <asp:BoundField HeaderText="Effective Date" DataField="EffDate" SortExpression="EffDate" />
                                        <asp:BoundField HeaderText="Action" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ViewCompensation.aspx.cs" Inherits="Application_ISys_ChannelMgmt_ViewCompensation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function doCancel() {
            $find("mdlComp").hide();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" class="tableIsys">
        <tr>
            <td colspan="4" class="test">
                <asp:Label Text="Compensation Search Results" runat="server" Font-Bold="true" />
            </td>
        </tr>
        <tr>
            <td class="test" colspan="4">
                <asp:Label ID="Label1" Text="Basic Search" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblCycDtFrm" Text="Date From" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtCycDtFrm" runat="server" CssClass="standardtextbox" />
                <asp:Image ID="img1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                <ajaxToolkit:CalendarExtender ID="calextstr" CssClass="ajax__calendar" runat="server"
                    TargetControlID="txtCycDtFrm" PopupButtonID="img1" Format="dd/MM/yyyy" />
            </td>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblCycDtTo" Text="Date To" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtCycDtTo" runat="server" CssClass="standardtextbox" />
                <asp:Image ID="img2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="ajax__calendar" runat="server"
                    TargetControlID="txtCycDtFrm" PopupButtonID="img2" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblMemCode" Text="Member Code" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtMemCode" runat="server" CssClass="standardtextbox" />
            </td>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblPanNo" Text="PAN Number" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtPanNo" runat="server" CssClass="standardtextbox" />
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblSap" Text="SAP Code" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtSap" runat="server" CssClass="standardtextbox" />
            </td>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblAgtBrkCd" Text="Agent Broker Code" runat="server" />
            </td>
            <td class="formcontent" style="width: 30%">
                <asp:TextBox ID="txtAgtBrkCd" runat="server" CssClass="standardtextbox" />
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="width: 20%">
                <asp:Label ID="lblCompType" Text="Computation Type" runat="server" />
            </td>
            <td class="formcontent" colspan="3">
                <asp:UpdatePanel ID="updComp" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCompType" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="203px"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="test" colspan="4">
                <asp:Label ID="lblHDtls" Text="Advanced Search" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="formcontent" colspan="4">
                <div id="divAgtAdvSearch" runat="server" style="display: block;">
                    <table width="100%" class="tableIsys">
                        <tr>
                            <td class="formcontent" style="width: 20%; height: 21px" align="left">
                                <asp:Label ID="lblchnltype" runat="server" Text="Hierarchy Type"></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 21px;" align="left" colspan="3">
                                <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="height: 13px" align="left">
                                <asp:Label ID="lblSlsChnnl" runat="server" Font-Bold="False" Text="Channel"></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 13px;" align="left">
                                <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSlsChnnl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlsChnnl_SelectedIndexChanged"
                                            CssClass="standardmenu" Width="203px" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent">
                                <asp:Label ID="lblChnCls" runat="server" Text="Sub Channel"></asp:Label>
                            </td>
                            <td align="left" class="formcontent">
                                <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" Width="203px" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlSlsChnnl" EventName="SelectedIndexChanged">
                                        </asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="height: 21px" align="left">
                                <asp:Label ID="lblAgntType" runat="server" Font-Bold="False" Text="Member Type"></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 21px" align="left" colspan="3">
                                <asp:UpdatePanel ID="upnlAgnType" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                            OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" Width="203px" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="formcontent" colspan="4" style="text-align: center;">
                <asp:Button ID="btnSearch" Text="SEARCH" runat="server" CssClass="standardbutton"
                    OnClick="btnSearch_Click" />&nbsp;
                <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CssClass="standardbutton"
                    OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td class="formcontent" colspan="4">
                <asp:UpdatePanel ID="updCmp" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdComp" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                            Width="100%" AllowPaging="True" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                            BorderStyle="Solid" BorderColor="Gray" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                            AllowSorting="True" OnPageIndexChanging="grdComp_PageIndexChanging" OnSorting="grdComp_Sorting" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="Member Code" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpCode" Text='<%# Bind("MemCode") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSapCode" Text='<%# Bind("SapCode") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InsMemCode" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgtBrkCd" Text='<%# Bind("AgtBrkCode") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Channel" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBizSrc" Text='<%# Bind("BizSrc") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Class" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChnCls" Text='<%# Bind("ChnCls") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Member Type" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMemTyp" Text='<%# Bind("MemType") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Computation Type" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompType" Text='<%# Bind("CompType") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Premium Production" HeaderStyle-Font-Underline="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdPrm" Text='<%# Bind("PremAmt") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVwDtls" Text="View Details" runat="server" OnClick="lnkVwDtls_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVwPayOut" Text="View Payout" runat="server" OnClick="lnkVwPayOut_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCommPts" Text='<%# Bind("CurrCommPts") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComm" Text='<%# Bind("CurrComm") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle CssClass="pagelink" />
                            <PagerSettings FirstPageImageUrl="~/Images/iFirst.gif" LastPageImageUrl="~/Images/iLast.gif"
                                NextPageImageUrl="~/Images/iNext.gif" PreviousPageImageUrl="~/Images/iPrev.gif" />
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
    <center>
        <asp:Panel runat="server" ID="pnlVwCmp" Width="600px" Height="355px" display="none">
            <table class="tableIsys" width="100%">
            <tr>
                <td class="test">
                    <asp:Label Text="Member Club" runat="server" Font-Bold="true" />
                </td>
            </tr>
                <tr>
                    <td class="formcontent" style="text-align:center;">
                        <asp:UpdatePanel ID="updClub" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdClub" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                                    Width="100%" AllowPaging="True" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                    BorderStyle="Solid" BorderColor="Gray" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                    AllowSorting="True" OnRowDataBound="grdClub_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Points Accumulated" HeaderStyle-Font-Underline="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommPts" Text='<%# Bind("CommPts") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commission Earned" HeaderStyle-Font-Underline="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblComm" Text='<%# Bind("PrdComm") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Club" HeaderStyle-Font-Underline="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemClub" Text='<%# Bind("ClubDesc") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompType" Text='<%# Bind("CompType") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pagelink" />
                                    <PagerSettings FirstPageImageUrl="~/Images/iFirst.gif" LastPageImageUrl="~/Images/iLast.gif"
                                        NextPageImageUrl="~/Images/iNext.gif" PreviousPageImageUrl="~/Images/iPrev.gif" />
                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="text-align:center;">
                        <asp:Button ID="btnOk" Text="OK" runat="server" OnClientClick="doCancel();return false;"  CssClass="standardbutton"/>
                        <asp:Label runat="server" ID="lbl1" Style="display: none" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </center>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwComp" BehaviorID="mdlComp"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlVwCmp" BackgroundCssClass="modalPopupBg" Y="100" X="250">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

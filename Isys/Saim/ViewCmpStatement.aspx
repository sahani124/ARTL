<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ViewCmpStatement.aspx.cs" Inherits="Application_ISys_Saim_ViewCmpStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .lnk
        {
            background-color: #0A23BE;
            border: 1px,solid;
            border-left: #FFFFFF;
            border-right: #FFFFFF;
            border-top: #FFFFFF;
            color: #FFFFFF;
        }
    </style>
    <script language="javascript">
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
    <asp:ScriptManager ID="scr" runat="server">
    </asp:ScriptManager>
    <table class="tableIsys" width="100%">
        <tr>
            <td class="formcontent" style="width: 100%;">
                <div class="ImgTab">
                    <ul>
                        <li id="lnkstat" style="border-bottom:solid 1px #FFFFFF;">
                            <asp:Image ID="imgstat" ImageUrl="~/images/statsum.png" runat="server" Height="20px" Width="20px" />
                            <asp:LinkButton ID="lnkStatSumm" Text="Statement Summary" runat="server" OnClick="lnkStatSumm_Click"/>
                        </li>
                        <li id="lnkstdtls" runat="server">
                            <asp:Image ID="imgstdtls" ImageUrl="~/images/statdtls.png" runat="server" Height="20px" Width="20px" />
                            <asp:LinkButton ID="lnkStmtDtls" Text="Statement Details" runat="server" OnClick="lnkStmtDtls_Click"/>
                        </li>
                        <li id="lnkpol" runat="server">
                            <asp:Image ID="imgpol" ImageUrl="~/images/Policy.png" runat="server" Height="20px" Width="20px" />
                            <asp:LinkButton ID="lnkVwPolicy" Text="View Policies" runat="server" OnClick="lnkVwPolicy_Click"/>
                        </li>
                        <li id="lnkprint" runat="server">
                            <asp:Image ID="imgprint" ImageUrl="~/images/print.png" runat="server" Height="20px" Width="20px" />
                            <asp:LinkButton ID="lnkPrintVer" Text="Printable Version" runat="server" OnClick="lnkPrintVer_Click" />
                        </li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tableIsys" width="100%">
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="standardbutton" value="+" id="btnmemdtlscollapse"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmemdtls','ctl00_ContentPlaceHolder1_btnmemdtlscollapse');" />
                            <asp:Label ID="lblMemhdr" Text="Member Details" runat="server" Font-Bold="true" />
                        </td>
                    </tr>
                </table>
                <div id="divmemdtls" runat="server" style="display: none;" width="100%">
                    <table class="tableIsys" width="100%">
                        <tr>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblMemNm" Text="Member Name" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblMemNmVal" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblMemCode" Text="Member Code" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblMemCodeVal" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblBizSrc" runat="server" Text="Channel" />
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblBizSrVal" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="Label3" runat="server" Text="Sub Class" />
                            </td>
                            <td class="formcontent" style="width: 30%; white-space: nowrap;">
                                <asp:Label ID="lblChnClsVal" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblMemTypHdr" runat="server" Text="Member Type" />
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblMemTypVal" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblSapCd" runat="server" Text="SAP Code" />
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblSapCdVal" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 25%;">
                                <asp:Label ID="lblEmail" Text="Email ID" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 25%;">
                                <asp:Label ID="lblEmailVal" runat="server" />
                            </td>
                            <td class="formcontent" style="width: 25%;">
                                <asp:Label ID="lblMobDtl" Text="Mobile No." runat="server" />
                            </td>
                            <td class="formcontent" style="width: 25%;">
                                <asp:Label ID="lblMobDtlVal" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="updStat" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MVwStat" ActiveViewIndex="0" runat="server">
                            <asp:View ID="VwStatSum" runat="server">
                                <asp:UpdatePanel ID="upStatSum" runat="server">
                                    <ContentTemplate>
                                        <table class="tableIsys" width="100%">
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <input runat="server" type="button" class="standardbutton" value="-" id="btncycdtls"
                                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcycdtls','ctl00_ContentPlaceHolder1_btncycdtls');" />
                                                    <asp:Label ID="lblcycdthdr" Text="Cycle Date Details" runat="server" Font-Bold="true" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divcycdtls" runat="server" style="display: block;">
                                            <table class="tableIsys" width="100%">
                                                <tr>
                                                    <td class="formcontent" colspan="4">
                                                        <asp:Label ID="lblCurr" Text="Current Cycle Date" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblFromDt" Text="From Date" runat="server" />
                                                    </td>
                                                    <td class="formcontent" style="width: 30%;">
                                                            <%--<asp:Label ID="lblFromDtVal" runat="server" />--%>
                                                            <asp:TextBox ID="lblFromDtVal" runat="server" />
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" CssClass="ajax__calendar" runat="server"
                                                            TargetControlID="lblFromDtVal" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                                    </td>
                                                    <td class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblToDt" Text="To Date" runat="server" />
                                                    </td>
                                                    <td class="formcontent" style="width: 30%;">
                                                        <%--<asp:Label ID="lblToDtVal" runat="server" />--%>
                                                        <asp:TextBox ID="lblToDtVal" runat="server" />
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" CssClass="ajax__calendar" runat="server"
                                                            TargetControlID="lblToDtVal" PopupButtonID="Image2" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="formcontent" style="text-align:center;" colspan="4">
                                                        <asp:Button ID="btnSrcDt" Text="Search" runat="server" OnClick="btnSrcDt_Click" CssClass="standardbutton" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="formcontent" colspan="4">
                                                        <asp:Panel ID="pnlStat" runat="server" visible="false">
                                                            <table class="tableIsys" style="width: 100%;" id="tblcht" runat="server" visible="false">
                                                                <tr>
                                                                    <td class="formcontent" style="width: 50%;">
                                                                        <asp:UpdatePanel ID="updCycle" runat="server">
                                                                            <ContentTemplate>
                                                                                <telerik:RadGrid ID="rdgrdCyc" runat="server" Width="700px" ShowStatusBar="true" AutoGenerateColumns="False"
                                                                                    PageSize="7" AllowSorting="True" AllowMultiRowSelection="False" Skin="Outlook"
                                                                                    AllowPaging="True" OnNeedDataSource="rdgrdCyc_NeedDataSource" GridLines="None"
                                                                                    OnPageIndexChanged="rdgrdCyc_PageIndexChanged" OnSortCommand="rdgrdCyc_SortCommand"
                                                                                    OnItemDataBound="rdgrdCyc_ItemDataBound">
                                                                                    <MasterTableView>
                                                                                        <Columns>
                                                                                            <telerik:GridTemplateColumn SortExpression="Type" HeaderText="Type">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Image ID="imgType" runat="server" Height="25px" Width="25px"/>
                                                                                                    <asp:Label ID="lblType" Text='<%# Bind("Type") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </telerik:GridTemplateColumn>
                                                                                            <telerik:GridTemplateColumn SortExpression="CurrentMonth" HeaderText="Current Month"
                                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblCurrMth" Text='<%# Bind("CurrentMonth") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </telerik:GridTemplateColumn>
                                                                                            <telerik:GridTemplateColumn SortExpression="CurrentQuarter" HeaderText="Current Quarter"
                                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblCurrQtr" Text='<%# Bind("CurrentQuarter") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </telerik:GridTemplateColumn>
                                                                                            <telerik:GridTemplateColumn SortExpression="CurrentYear" HeaderText="Current Year"
                                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblCurrYr" Text='<%# Bind("CurrentYear") %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </telerik:GridTemplateColumn>
                                                                                        </Columns>
                                                                                        <HeaderStyle Font-Bold="true" HorizontalAlign="Center"/>
                                                                                    </MasterTableView>
                                                                                </telerik:RadGrid>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td class="formcontent" style="width: 50%; text-align: center;">
                                                                        <asp:Chart ID="Chart1" runat="server" Height="250px" Width="250px">
                                                                            <Titles>
                                                                                <asp:Title Text="Current Month Details">
                                                                                </asp:Title>
                                                                            </Titles>
                                                                            <Series>
                                                                                <asp:Series Name="Default" ChartType="Pie" ChartArea="MainArea" IsValueShownAsLabel="true">
                                                                                </asp:Series>
                                                                            </Series>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="MainArea" Area3DStyle-Inclination="10" Area3DStyle-IsClustered="false"
                                                                                    AlignmentOrientation="All" AlignmentStyle="Position" >
                                                                                    <Area3DStyle Enable3D="True" />
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                        </asp:Chart>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="lnkStatSumm" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="VwStatDtls" runat="server">
                                <asp:UpdatePanel ID="updStatDt" runat="server">
                                    <ContentTemplate>
                                        <table class="tableIsys" width="100%" id="tblCompType" runat="server">
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <input runat="server" type="button" class="standardbutton" value="-" id="btnstatcmp"
                                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divstatcmp','ctl00_ContentPlaceHolder1_btnstatcmp');" />
                                                    <asp:Label ID="lblStatDtlHdr" Text="Incentives and Payments" runat="server" Font-Bold="true" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divstatcmp" runat="server" style="display: block;">
                                            <table class="tableIsys" width="100%" runat="server">
                                                <tr>
                                                    <td class="formcontent" style="width: 25%;">
                                                        <telerik:RadButton ID="radBscComm" runat="server" Text="BASIC COMMISSION" BackColor="#4c4cff"
                                                            Height="80px" Width="250px" Skin="Metro" ForeColor="White" Font-Bold="true">
                                                            <Icon PrimaryIconUrl="../../../images/Account4.png" PrimaryIconHeight="100px" PrimaryIconWidth="100px"
                                                                PrimaryIconTop="10px" PrimaryIconLeft="2px" />
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td class="formcontent" style="width: 25%;">
                                                        <telerik:RadButton ID="radInctv" runat="server" Text="INCENTIVE" BackColor="#dc322f"
                                                            Height="80px" Width="250px" Skin="Metro" ForeColor="White" Font-Bold="true">
                                                            <Icon PrimaryIconUrl="../../../images/inc8.png" PrimaryIconHeight="100px" PrimaryIconWidth="100px"
                                                                PrimaryIconTop="10px" PrimaryIconLeft="2px" />
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td class="formcontent" style="width: 25%;">
                                                        <telerik:RadButton ID="radCompFCP" runat="server" Text="FAME CLUB POINTS" BackColor="#54C571"
                                                            OnClick="radCompFCP_Click" Height="80px" Width="250px" Skin="Metro" ForeColor="White"
                                                            Font-Bold="true">
                                                            <Icon PrimaryIconUrl="../../../images/FCP2.png" PrimaryIconHeight="100px" PrimaryIconWidth="100px"
                                                                PrimaryIconTop="10px" PrimaryIconLeft="2px" />
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td class="formcontent" style="width: 25%;">
                                                        <telerik:RadButton ID="radOthrs" runat="server" Text="OTHERS" BackColor="#ffd932"
                                                            Height="80px" Width="250px" Skin="Metro" ForeColor="White" Font-Bold="true">
                                                            <Icon PrimaryIconUrl="../../../images/inc1.png" PrimaryIconHeight="100px" PrimaryIconWidth="100px"
                                                                PrimaryIconTop="10px" PrimaryIconLeft="2px" />
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table id="tblAch" runat="server" class="tableIsys" width="100%" visible="false">
                                                            <tr>
                                                                <td class="test" colspan="4">
                                                                    <asp:Label ID="lblAchHdr" Text="Achievements" runat="server" Font-Bold="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formcontent" style="width: 20%">
                                                                    <asp:Label ID="lblcurrpts" Text="Current Points:" runat="server" />
                                                                </td>
                                                                <td class="formcontent" colspan="3" style="width: 30%">
                                                                    <asp:Label ID="lblcurrptsVal" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formcontent" style="width: 20%">
                                                                    <asp:Label ID="lblCurrClub" Text="Current Club" runat="server" />
                                                                </td>
                                                                <td class="formcontent" style="width: 30%">
                                                                    <asp:UpdatePanel ID="updcrcl" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblCurrClubVal" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td class="formcontent" style="width: 20%">
                                                                    <asp:Label ID="lblcurrnghdr" Text="Current Club Range" runat="server" />
                                                                </td>
                                                                <td class="formcontent" style="width: 30%">
                                                                    <asp:UpdatePanel ID="upd2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblClubRng" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formcontent" style="width: 20%">
                                                                    <asp:Label ID="lblNxtClubHdr" Text="Next Club" runat="server" />
                                                                </td>
                                                                <td class="formcontent" style="width: 30%">
                                                                    <asp:UpdatePanel ID="upd1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblNxtClubVal" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td class="formcontent" style="width: 20%">
                                                                    <asp:Label ID="lblnxtrngHdr" Text="Next Club Range" runat="server" />
                                                                </td>
                                                                <td class="formcontent" style="width: 30%">
                                                                    <asp:UpdatePanel ID="updnxcl" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblNxtClubRng" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formcontent" colspan="4">
                                                                    <asp:UpdatePanel ID="updRad" runat="server">
                                                                        <ContentTemplate>
                                                                            <telerik:RadGrid ID="RadGrid1" runat="server" Width="95%" ShowStatusBar="true" AutoGenerateColumns="False"
                                                                                PageSize="7" AllowSorting="True" AllowMultiRowSelection="False" AllowPaging="True"
                                                                                OnDetailTableDataBind="RadGrid1_DetailTableDataBind" OnNeedDataSource="RadGrid1_NeedDataSource">
                                                                                <MasterTableView Width="100%" DataKeyNames="Mth" AllowMultiColumnSorting="True">
                                                                                    <DetailTables>
                                                                                        <telerik:GridTableView DataKeyNames="Mth" Name="MonthDetails" Width="100%">
                                                                                            <Columns>
                                                                                                <telerik:GridTemplateColumn SortExpression="" DataField="" HeaderText="">
                                                                                                    <ItemTemplate>
                                                                                                    </ItemTemplate>
                                                                                                </telerik:GridTemplateColumn>
                                                                                                <telerik:GridBoundColumn SortExpression="Mth" HeaderText="Month" DataField="Mth">
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn SortExpression="PolicyNo" HeaderText="Policy" DataField="PolicyNo"
                                                                                                    ItemStyle-HorizontalAlign="Right">
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn SortExpression="PremAmt" HeaderText="Premium Amount" DataField="PremAmt"
                                                                                                    ItemStyle-HorizontalAlign="Right">
                                                                                                </telerik:GridBoundColumn>
                                                                                                <telerik:GridBoundColumn SortExpression="Points" HeaderText="Points" DataField="Points"
                                                                                                    ItemStyle-HorizontalAlign="Right">
                                                                                                </telerik:GridBoundColumn>
                                                                                            </Columns>
                                                                                        </telerik:GridTableView>
                                                                                    </DetailTables>
                                                                                    <Columns>
                                                                                        <telerik:GridBoundColumn SortExpression="Mth" HeaderText="Month" DataField="Mth">
                                                                                        </telerik:GridBoundColumn>
                                                                                        <telerik:GridBoundColumn SortExpression="PolicyNo" HeaderText="Policy" DataField="PolicyNo"
                                                                                            ItemStyle-HorizontalAlign="Right">
                                                                                        </telerik:GridBoundColumn>
                                                                                        <telerik:GridBoundColumn SortExpression="PremAmt" HeaderText="Premium Amount" DataField="PremAmt"
                                                                                            ItemStyle-HorizontalAlign="Right">
                                                                                        </telerik:GridBoundColumn>
                                                                                        <telerik:GridBoundColumn SortExpression="Points" HeaderText="Points" DataField="Points"
                                                                                            ItemStyle-HorizontalAlign="Right">
                                                                                        </telerik:GridBoundColumn>
                                                                                    </Columns>
                                                                                </MasterTableView>
                                                                            </telerik:RadGrid></ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="lnkStmtDtls" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="VwPol" runat="server">
                                <asp:UpdatePanel ID="updVwPol" runat="server">
                                    <ContentTemplate>
                                        <table class="tableIsys" width="100%">
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <input runat="server" type="button" class="standardbutton" value="-" id="btnpoldtls"
                                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpoldtls','ctl00_ContentPlaceHolder1_btnpoldtls');" />
                                                    <asp:Label ID="lblPolHdr" Text="Policy Details" runat="server" Font-Bold="true" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divpoldtls" runat="server" style="display: block;">
                                            <table class="tableIsys" width="100%">
                                                <tr>
                                                    <td class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblFrmDtPol" Text="From Date" runat="server" />
                                                    </td>
                                                    <td class="formcontent" style="width: 30%;">
                                                        <asp:TextBox ID="txtFrmDt" runat="server" />
                                                        <asp:Image ID="img1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="ajax__calendar" runat="server"
                                                            TargetControlID="txtFrmDt" PopupButtonID="img1" Format="dd/MM/yyyy" />
                                                    </td>
                                                    <td class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblToDtPol" Text="To Date" runat="server" />
                                                    </td>
                                                    <td class="formcontent" style="width: 30%;">
                                                        <asp:TextBox ID="txtToDt" runat="server" />
                                                        <asp:Image ID="img2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" CssClass="ajax__calendar" runat="server"
                                                            TargetControlID="txtToDt" PopupButtonID="img2" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="formcontent" style="text-align: center;" colspan="4">
                                                        <asp:Button ID="btnSrchPol" Text="Search" runat="server" OnClick="btnSrchPol_Click"
                                                            CssClass="standardbutton" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:UpdatePanel ID="updPol" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgPol" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        OnPageIndexChanging="dgPol_PageIndexChanging" OnSorting="dgPol_Sorting" PageSize="10"
                                                        AllowSorting="true" AllowPaging="true">
                                                        <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="sublinkodd" HorizontalAlign="Left"></RowStyle>
                                                        <AlternatingRowStyle CssClass="sublinkeven" HorizontalAlign="Left"></AlternatingRowStyle>
                                                        <EmptyDataTemplate>
                                                            <center>
                                                                <asp:Label ID="lblRec" Text="No Records Found" runat="server" ForeColor="Red" />
                                                            </center>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Policy Number" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPolNo" Text='<%# Bind("PolicyNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Policy Holder" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPolHd" Text='<%# Bind("PolHold") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Policy Start Date" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPolDt" Text='<%# Bind("PolicyDt") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Policy End Date" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPolEndDt" Text='<%# Bind("PolicyEndDt") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Product" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProd" Text='<%# Bind("Product") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="LOB" HeaderStyle-Font-Underline="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLOB" Text='<%# Bind("LOB") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Premium Amount" HeaderStyle-Font-Underline="true"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrmAmt" Text='<%# Bind("PolPrm") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Points" HeaderStyle-Font-Underline="true" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPts" Text='<%# Bind("Points") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Comm Amount" HeaderStyle-Font-Underline="true" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPts" Text='<%# Bind("Comm") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSrchPol" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="lnkVwPolicy" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updtable" runat="server">
        <ContentTemplate>
            <table class="tableIsys" id="tblMnCht" runat="server" visible="false">
                <tr>
                    <td class="formcontent">
                        <table class="tableIsys" width="100%;" id="tblChart" runat="server">
                            <tr>
                                <td class="test" colspan="4">
                                    <input runat="server" type="button" class="standardbutton" value="-" id="btnchrtdtls"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divchrt','ctl00_ContentPlaceHolder1_btnchrtdtls');" />
                                    <asp:Label ID="lblLOBHdr" Text="LOB Wise" runat="server" Font-Bold="true" />
                                </td>
                            </tr>
                        </table>
                        <div id="divchrt" runat="server" style="display: block;">
                            <table class="tableIsys" width="100%;">
                                <tr>
                                    <td class="formcontent" style="width: 50%;">
                                        <asp:Chart ID="brChart" runat="server">
                                            <Titles>
                                                <asp:Title Text="LOB Wise Premium">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="LOBPremium" ChartType="Column" ChartArea="MainChartArea" BorderWidth="5"
                                                    Color="#4c4cff" XValueMember="LOB" YValueMembers="ProdPrem" IsValueShownAsLabel="true">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="MainChartArea" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true"
                                                    BorderWidth="1" Area3DStyle-WallWidth="1" Area3DStyle-PointGapDepth="50" Area3DStyle-PointDepth="100"
                                                    Area3DStyle-Rotation="30">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="LegendLOB"
                                                    LegendStyle="Row" />
                                            </Legends>
                                        </asp:Chart>
                                    </td>
                                    <td class="formcontent" style="width: 50%; text-align: center;">
                                        <asp:Chart ID="PolChrt" runat="server">
                                            <Titles>
                                                <asp:Title Text="LOB Wise Policy Count">
                                                </asp:Title>
                                            </Titles>
                                            <Series>
                                                <asp:Series Name="LOBPolicy" ChartType="Column" ChartArea="MainChartArea" BorderWidth="5"
                                                    XValueMember="LOB" YValueMembers="PolicyCnt" Color="#ff3232" IsValueShownAsLabel="true">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="MainChartArea" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true"
                                                    BorderWidth="1" Area3DStyle-WallWidth="1" Area3DStyle-PointGapDepth="50" Area3DStyle-PointDepth="100"
                                                    Area3DStyle-Rotation="30" >
                                                </asp:ChartArea>
                                            </ChartAreas>
                                            <Legends>
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Legend"
                                                    LegendStyle="Row" />
                                            </Legends>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updHdn" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnCommPts" runat="server" />
            <asp:HiddenField ID="hdnCompType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="CalcCommission.aspx.cs" Inherits="Application_ISys_Saim_CalcCommission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .pagelink span
        {
            font-weight: bold;
        }
        .pnlCon
        {
            display: none;
        }
        
        .RadButton_disablebtn
        {
            line-height: 20px;
            color: rgb(255, 255, 255);
            margin-right: 0px;
            margin-left: -8px;
            background-color: rgb(135, 206, 250);
            background-position: 100% -88px;
            background-repeat: no-repeat;
        }
        
        .btnrd
        {
            border-right: #B6BCCB 1px solid;
            border-left: #B6BCCB 1px solid;
            border-top: #B6BCCB 1px solid;
            border-bottom: #B6BCCB 1px solid;
        }
        .classHoveredImage
        {
            background-position: 0 -100px;
        }
        .classPressedImage
        {
            background-position: 0 -200px;
        }
        .imgbtn
        {
            display: block;
            float: left;
            background-image: url(../../../images/checked-checkbox-64.jpg);
            height: 20px;
            width: 20px;
        }
    </style>
    <script src="../../../Scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function funcShow() {
            /////debugger;
            var myExtender = $find('prgGrdBID');
            myExtender.show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "ViewCompensation.aspx";
        }
        function doCancel() {
            $find("prgGrdBID").hide();
        }
        function ChangeColor(btn, grd) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + btn).style.backgroundColor = "rgb(255, 255, 51)";
        }
        function fillcycdtTo() {
            ////debugger;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtStrTm").value != null) {
                document.getElementById("ctl00_ContentPlaceHolder1_txtEndTm").value = document.getElementById("ctl00_ContentPlaceHolder1_txtStrTm").value;
                /////return false;
            }
    </script>
    <asp:ScriptManager ID="scrcomm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="lnkVwBtch" runat="server" OnClick="lnkVwBtch_Click" ImageUrl="~/theme/iflow/vwbtch_active.png"
                Height="30px" Width="180px" />
            <asp:ImageButton ID="lnkViewComm" Text="View Compensation" runat="server" OnClick="lnkViewComm_Click"
                ImageUrl="~/theme/iflow/vwcomp.png" Height="30px" Width="200px" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="10">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tableIsys" width="90%" align="center">
                <tr>
                    <td class="test" colspan="4">
                        <asp:Label Text="SAIM BATCH JOB" ID="lblSaimDash" runat="server" Font-Bold="true" />
                    </td>
                </tr>
                <tr>
                    <td class="test" colspan="4">
                        <asp:Label ID="lblPrev" Text="Previous Batch Job Details" runat="server" Font-Bold="true" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label ID="lblPrvCycDt1" Text="Cycle Date From" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtPrvCycDt1" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lblPrvCycDt2" Text="Cycle Date To" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtPrvCycDt2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label ID="lblRunNo" Text="RunNo" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtRunNo" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lblStat" Text="Status" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtRunStat" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label ID="lblruncnt" Text="Run Count" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtRunCnt" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lblRunBy" Text="Run By" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="txtRunBy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="test" colspan="4">
                        <asp:Label ID="lblCurRnhdr" Text="Current Batch Job Details" runat="server" Font-Bold="true" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label Text="Cycle Date From" ID="lblStrTm" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:UpdatePanel runat="server" ID="updStrTm" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtStrTm" runat="server" CssClass="standardtextbox" onblur="javascript:fillcycdtTo();"/>
                                <asp:Image ID="imgstr" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <ajaxToolkit:CalendarExtender ID="calextstr" CssClass="ajax__calendar" runat="server"
                                    TargetControlID="txtStrTm" PopupButtonID="imgstr" Format="dd/MM/yyyy" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lblEndTm" Text="Cycle Date To" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:TextBox ID="txtEndTm" runat="server" CssClass="standardtextbox" />
                        <asp:Image ID="imgend" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="calextend" CssClass="ajax__calendar" runat="server"
                            TargetControlID="txtEndTm" PopupButtonID="imgend" Format="dd/MM/yyyy" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnNo" Text="RunNo" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnNoVal" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnCnt" Text="Run Count" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnCntVal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnStat" Text="Run Status" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnStVal" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRunBy" Text="Run By" runat="server" />
                    </td>
                    <td class="formcontent">
                        <asp:Label ID="lbCurRnByVal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button Text="VERIFY" CssClass="standardbutton" ID="btnVerify" runat="server"
                            OnClick="btnVerify_Click" />
                    </td>
                </tr>
            </table>
            <table class="tableIsys" width="90%" align="center">
                <tr>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Panel ID="Panel2" runat="server">
                            <telerik:RadButton ID="btnCmpComm" runat="server" BackColor="#87CEFA" CssClass="btnrd"
                                Font-Size="Small" Skin="Metro" ForeColor="White" Text="COMPUTE COMMISSION" Height="50px"
                                Width="100%" OnClick="btnCmpComm_Click">
                                <Icon PrimaryIconUrl="../../../images/data_comm.png" PrimaryIconTop="10px" PrimaryIconLeft="2px"
                                    PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                            </telerik:RadButton>
                        </asp:Panel>
                        <asp:LinkButton ID="lnkVwMrCCom" runat="server" BackColor="#0000cd" Font-Size="Small"
                            Font-Underline="false" ForeColor="White" Text="View More" Width="100%" OnClick="lnkVwMrCCom_Click"></asp:LinkButton>
                    </td>
                    <td class="formcontent" colspan="3" style="width: 80%;">
                        <asp:Label ID="lblCmpCom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trComp" runat="server" visible="false">
                    <td class="formcontent" colspan="4">
                        <asp:LinkButton ID="lnkViewComp" Text="View Compensation Details" runat="server"
                            Visible="false" OnClick="lnkViewComp_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" colspan="4">
                        <telerik:RadProgressManager ID="RadProgressManager3" runat="server" Visible="false" />
                        <telerik:RadProgressArea ID="RadProgressArea3" runat="server" DisplayCancelButton="true"
                            Visible="false" ProgressIndicators="TotalProgressBar,
                            TotalProgress,
                            TimeElapsed,
                            TimeEstimated,
                            CurrentFileName,
                            TransferSpeed">
                        </telerik:RadProgressArea>
                        <asp:UpdatePanel ID="updcommDt" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdCommData" runat="server" Width="100%" AutoGenerateColumns="false"
                                    OnRowDataBound="grdCommData_RowDataBound">
                                    <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Left"></RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven" HorizontalAlign="Left"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Source Table">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Destination Table">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Source Count">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Destination Count">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Result">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                <asp:LinkButton ID="lnkVw" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkViewComm" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Panel runat="server" ID="pnlVwCmp" Width="600px" Height="355px" display="none">
        <table class="tableIsys">
            <tr>
                <td class="formcontent">
                    <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
                        display="none" style="height: 100%;"></iframe>
                </td>
            </tr>
            <tr>
                <td class="formcontent">
                    <asp:Button ID="Button1" Text="OK" runat="server" OnClientClick="doCancel();return false;" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="prgGrd" BehaviorID="prgGrdBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlVwCmp" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

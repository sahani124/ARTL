<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="SaimDash.aspx.cs" Inherits="Application_ISys_ChannelMgmt_SaimDash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar
        {
            z-index:100px;
        }
    .pagelink span {font-weight:bold;}
    .btnrd
    {
        border-right : #B6BCCB 1px solid; border-left : #B6BCCB 1px solid; border-top : #B6BCCB 1px solid; border-bottom : #B6BCCB 1px solid;
     }
     .imgbtn
     {
         display:block;
         float:left;
        background-image:url(../../../images/checked-checkbox-64.jpg);
        height:20px;
        height:20px;
     }
     .divWaiting{
   
        position: absolute;
        background-color: #FAFAFA;
        z-index: 2147483647 !important;
        opacity: 0.8;
        overflow: hidden;
        text-align: center; top: 0; left: 0;
        height: 100%;
        width: 100%;
        padding-top:20%;
    } 
    </style>
    <script type="text/javascript">
        function ChangeColor() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1";
            document.getElementById(strContent + "_btnRun").style.backgroundColor = "rgb(255, 255, 51)";
        }
    </script>
  <%--<asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
    </asp:Timer>--%>

<asp:UpdatePanel runat="server">
<ContentTemplate>
    <table class="tableIsys"  width="90%" align="center">
        <tr>
            <td class="test" colspan="4">
                <asp:Label Text="SAIM BATCH JOB" ID="lblSaimDash"  runat="server" Font-Bold="true"/>
            </td>
        </tr>
        <tr>
            <td class="formcontent">
                <asp:Label Text="Cycle Date From" ID="lblStrTm"  runat="server"/>
            </td>
            <td class="formcontent">
                <asp:UpdatePanel runat="server" ID="updStrTm" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStrTm" runat="server" CssClass="standardtextbox" />
                        <asp:Image ID="imgstr" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="calextstr" CssClass="ajax__calendar" runat="server"
                            TargetControlID="txtStrTm" PopupButtonID="imgstr" Format="dd/MM/yyyy" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="formcontent">
                <asp:Label ID="lblEndTm" Text="Cycle Date To" runat="server"/>
            </td>
            <td class="formcontent">
                <asp:TextBox ID="txtEndTm"  runat="server" CssClass="standardtextbox"/>
                <asp:Image ID="imgend" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                <ajaxToolkit:CalendarExtender ID="calextend" CssClass="ajax__calendar" runat="server" TargetControlID="txtEndTm"
                    PopupButtonID="imgend" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button Text="VERIFY" CssClass="standardbutton" ID="btnVerify" 
                    runat="server" onclick="btnVerify_Click" />
                <%--&nbsp;<asp:Button Text="RUN" CssClass="standardbutton" ID="btnRun" runat="server" 
                    onclick="btnRun_Click" />--%>
                &nbsp;<asp:Button Text="Truncate" runat="server" ID="btnTruncate"  CssClass="standardbutton" 
                    onclick="btnTruncate_Click"  Visible="false"/>
            </td>
        </tr>
        <tr>
            <td class="formcontent" style="text-align:center" colspan="4">

                <%--<telerik:RadButton ID="btnRun" runat="server" Text="PULL DATA" Height="100" Width="150" 
                    Skin="Metro"  CssClass="btnrd" ForeColor="White" Font-Size="Medium" BackColor="#0000cd" OnClick="btnRun_Click">
                <Icon PrimaryIconCssClass="fa fa-download" PrimaryIconTop="10" PrimaryIconLeft="60"/>
                </telerik:RadButton>--%>

                <asp:Button ID="btnRun" runat="server" Text="PULL DATA" Height="100" Width="150"  
                BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium" OnClick="btnRun_Click"/>
                
                <%--<telerik:RadButton ID="btnValData" runat="server" Text="VALIDATE DATA" Height="100" Width="150" 
                    Skin="Metro" BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium">
                <Icon PrimaryIconCssClass="fa fa-wrench"  PrimaryIconTop="10" PrimaryIconLeft="60" />
                </telerik:RadButton>--%>

                <asp:Button ID="btnValData" runat="server" Text="VALIDATE DATA" Height="100" Width="150"  
                BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium" />
<%--
                 <telerik:RadButton ID="btnCmpProd" runat="server" Text="COMPUTE PROD" Height="100" Width="150" 
                    Skin="Metro" BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium">
                <Icon PrimaryIconCssClass="fa fa-download" PrimaryIconTop="10" PrimaryIconLeft="60" />
                </telerik:RadButton>--%>

                <asp:Button ID="btnCmpProd" runat="server" Text="COMPUTE PROD" Height="100" Width="150"  
                BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium" />

                 <%--<telerik:RadButton ID="btnCmpComm" runat="server" Text="COMPUTE COMM" Height="100" Width="150" 
                    Skin="Metro" BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium">
                <Icon PrimaryIconCssClass="fa fa-download" PrimaryIconTop="10" PrimaryIconLeft="60" />
                </telerik:RadButton>--%>

                <asp:Button ID="btnCmpComm" runat="server" Text="COMPUTE COMM" Height="100" Width="150"  
                BackColor="#0000cd" CssClass="btnrd" ForeColor="White" Font-Size="Medium" />

            </td>
        </tr>
        <tr>
            <td class="formcontent" colspan="4">
                <asp:Panel id="divload" runat="server">
                    <asp:Image ID="imgload" ImageUrl="../../../images/spinner.gif" runat="server" Visible="false"/>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView runat="server" Width="100%" AutoGenerateColumns="false" 
                            ID="grdPrd" onrowdatabound="grdPrd_RowDataBound">
                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left"></RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven" HorizontalAlign="Left"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNo" Text='<%# Bind("SeqNo") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Task Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTName" Text='<%# Bind("TaskName") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStat" Text='<%# Bind("Status") %>' runat="server" />
                                            <asp:Image ImageUrl='<%# (Eval("Status").Equals("Completed") ? "../../../images/tick_ok.ico" : "../../../images/cross1.ico") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />--%>
                    </Triggers>
                </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="CmpSetupReport.aspx.cs" Inherits="Application_ISys_Saim_CmpSetupReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function funPopUp(cmpcode, cmpdesc) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntst.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc + "&mdlpopup=mdlViewBID";
        }

        function doCancel() {
            $find("mdlViewBID").hide();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcmphdr" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:TextBox ID="txtCompCode" runat="server" CssClass="form-control col-md-5" TabIndex="1"
                                        Enabled="false" />--%>
                                        <asp:Label ID="txtCompCode"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:TextBox ID="txtCompDesc1" runat="server" CssClass="form-control col-md-5" TabIndex="2" />--%>
                                    <asp:Label ID="txtCompDesc1"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:TextBox ID="txtCompDesc2" runat="server" CssClass="form-control col-md-5" TabIndex="3" />--%>
                                    <asp:Label ID="txtCompDesc2"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:DropDownList ID="ddlAccCyc" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                                TabIndex="4">

                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlAccCyc"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblAccYear" Text="Accumulation Year" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                           <%-- <asp:DropDownList ID="ddlAccYear" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                                TabIndex="5" OnSelectedIndexChanged="ddlAccYear_SelectedIndexChanged">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlAccYear"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:DropDownList ID="ddlCompType" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                                TabIndex="6">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlCompType"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="Label1" Text="Accrual Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:DropDownList ID="ddlAccrCyc" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlAccrCyc"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblRwdRlsCyc" Text="Rewards Release Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:DropDownList ID="ddlRwdRlsCyc" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlRwdRlsCyc"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblFinYr" Text="Business Year" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:DropDownList ID="ddlBusiYear" runat="server" CssClass="select2-container form-control col-md-5"
                                                AutoPostBack="true" TabIndex="7" OnSelectedIndexChanged="ddlBusiYear_SelectedIndexChanged">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="ddlBusiYear"  runat="server" CssClass="control-label col-md-5" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control col-md-5" TabIndex="7" />--%>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap; top: 120px; left: 714px;" class="col-md-7">
                                    <%--<asp:TextBox ID="txtVer" runat="server" CssClass="form-control col-md-5" TabIndex="8" />--%>
                                    <asp:Label ID="txtVer"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtEffDtFrm" runat="server" CssClass="form-control col-md-5" TabIndex="9" />
                                            <div style="padding: 6px 12px;">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                    Height="20px" Width="20px" /></div>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" PopupButtonID="Image1"
                                                TargetControlID="txtEffDtFrm" runat="server">
                                            </ajaxToolkit:CalendarExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="txtEffDtFrm"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtEffDtTo" runat="server" CssClass="form-control col-md-5" TabIndex="10" />
                                            <div style="padding: 6px 12px;">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                    Height="20px" Width="20px" /></div>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" PopupButtonID="Image2"
                                                TargetControlID="txtEffDtTo" runat="server">
                                            </ajaxToolkit:CalendarExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="txtEffDtTo"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblVerEffFrm" Text="Ver. Eff. From" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtVerEffFrm" runat="server" CssClass="form-control col-md-5" TabIndex="9" />
                                            <div style="padding: 6px 12px;">
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                    Height="20px" Width="20px" /></div>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" PopupButtonID="Image3"
                                                TargetControlID="txtVerEffFrm" runat="server">
                                            </ajaxToolkit:CalendarExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="txtVerEffFrm"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblVerEffTo" Text="Ver. Eff. To" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtVerEffTo" runat="server" CssClass="form-control col-md-5" TabIndex="10" />
                                            <div style="padding: 6px 12px;">
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                    Height="20px" Width="20px" /></div>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" PopupButtonID="Image4"
                                                TargetControlID="txtVerEffTo" runat="server">
                                            </ajaxToolkit:CalendarExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="txtVerEffTo"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblStatus" Text="Status" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5"
                                                TabIndex="11">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="ddlStatus"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblStTrgRul" Text="Set Target Rule" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <%--<asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblSetTrgRul" runat="server" AutoPostBack="true" CssClass="radio">
                                                <asp:ListItem Text="Set full period target and split by cycle" Value="1001" />
                                                <asp:ListItem Text="Set target by cycle" Value="1002" />
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Label ID="rblSetTrgRul"  runat="server" CssClass="control-label col-md-5" />
                                </td>
                            </tr>
                        </table>
                        <table runat="server" visible="false" class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btnSave" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnCnclCmp" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                                        OnClick="btnCnclCmp_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <br />
                <div id="divcntstcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label2" Text="Contestant Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcntst','Img1','#Img1');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcntst" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                        padding: 10px;" class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                    OnRowDataBound="dgCntst_RowDataBound" OnSorting="dgCntst_Sorting">
                                    <HeaderStyle ForeColor="Black" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                            runat="server" />
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                            </ItemTemplate>
                                            <ItemStyle  HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>' />
                                                <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                                <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="Unit Rank" SortExpression="UnitRank">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Count">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemCnt" Text="1" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle  HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Premium">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalPremium" Text="258800.00" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle  HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reward Cost">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRwrdCost" Text="26100.00" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle  HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddCntst" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnSaveCntst" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <br />
                    <div id="divPage" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                    <table id="tbladdcntst" visible="false" runat="server" class="form-actions fluid" style="width: 100%;">
                        <tr>
                            <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                <asp:Button ID="btnAddCntst" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                    Enabled="true" />
                                <asp:Button ID="btnSaveCntst" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                    Enabled="true" OnClick="btnSaveCntst_Click" />
                                <asp:Button ID="btncmp" runat="server" ClientIDMode="Static" Style="display: none;"
                                    OnClick="btncmp_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <%--ADDED BY KALYANI START--%>
                <%--<div id="divC" runat="server" style="width: 95%;" class="divBorder1" visible="false">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divok','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divok" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable" align="left">
                        <asp:CheckBox ID="chkQual" Text=" Completed contest creation, click OK to submit for review"
                            runat="server" OnCheckedChanged="chkQual_CheckedChanged" 
                            AutoPostBack="True" />
                        <table id="Table1" runat="server" class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btOK" Text="OK" runat="server" Width="100px" CssClass="btn blue"
                                        Enabled="false" OnClick="btOK_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>--%>
                <%--<div id="divR" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div1','Img3','#Img3');" />
                            </td>
                        </tr>
                    </table>
                    <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblContestStatus" Text="Status" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 20%; white-space: nowrap;" class="col-md-7" colspan="">
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlStatusR" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5" 
                                                TabIndex="4">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    &nbsp;</td>
                               
                            </tr>
                            <tr>
                                <td class="form-body align col-md-6" style="white-space: nowrap; width: 20%;">
                                    <asp:Label ID="lblStatusRemark" runat="server" 
                                        CssClass="control-label col-md-5" Text="Approver Remark" />
                                </td>
                                 <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="50px" runat="server" CssClass="form-control col-md-5"
                                        TabIndex="2" />
                                </td>
                                
                            </tr>
                            <table id="Table2" runat="server" class="form-actions fluid" style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                        <asp:Button ID="btSubmit" Text="Submit" runat="server" Width="100px" 
                                            CssClass="btn blue" onclick="btSubmit_Click1" />
                                    </td>
                                </tr>
                            </table>
                        </table>
                    </div>
                </div>--%>
                <br />
                <%--<div id="divAudit" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label3" Text="Contest Audit Trail" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img4" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divAuditTrail','Img4','#Img4');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divAuditTrail" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                        padding: 10px;" class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdAudit" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                     >
                                    <HeaderStyle ForeColor="Black" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                            runat="server" />
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CMPNSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnACompCode" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Id" SortExpression="CMPNSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                                <asp:HiddenField ID="hdnAUserId" runat="server" Value='<%# Bind("USERid")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark" SortExpression="CHN">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                                <asp:HiddenField ID="hdnRemark" runat="server" Value='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="CHNCLS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Created Date" SortExpression="CreateDtim">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnCreatedDtim" runat="server" Value='<%# Bind("CreateDtim")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            
                        </asp:UpdatePanel>
                    </div>
                    <br />
                    <div id="div4" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Button1" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                    Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="TextBox1" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="Button2" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </div>--%>
                <%--ADDED BY KALYANI END--%>
                <div>
                <div id="DivChart1Header" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label3" Text="Report" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('DivChart1','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>
                    <div id="DivChart1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                        padding: 10px;" class="table-scrollable">
                
        <asp:Chart ID="Chart1" runat="server" Width="800px">
            <Series>
                <asp:Series Name="Series1"  ChartType="Line" Legend="Legend1" >
                
                </asp:Series>
                <asp:Series Name="Series2" ChartType="Line" Legend="Legend1">
                </asp:Series>
                <asp:Series Name="Series3" ChartType="Line" Legend="Legend1">
                </asp:Series>
            </Series>
           
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        </div>
    </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="400px" Width="1000px" ID="pnlMdl" display="none"
        Style="text-align: center;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                            <br />
                            <center>
                                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="standardbutton" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
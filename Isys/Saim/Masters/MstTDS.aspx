<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MstTDS.aspx.cs" Inherits="Application_ISys_Saim_Masters_MstTDS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
   <%-- <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function funPopup(code) {
            $find("mdlPopBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmPop").src = "PopMstTDS.aspx?code=" + code + "&mdlpopup=mdlPopBID";
        }
    </script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
            text-align: center;
        }
        .new_text_new
        {
            color: #066de7;
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
        .disablepage
        {
            display: none;
        }
        
        .box
        {
            background-color: #efefef;
            padding-left: 5px;
        }
        
    </style>

     <style type="text/css">
    .space
    {
        padding :10px;
    }
    </style>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <center>
                <div id="divRwdcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                
                                <asp:Label ID="Label3" Text="Master Setup" runat="server" Font-Size="19px"/>
                            </div>
                            <div class="col-sm-2">
                                <span class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>&nbsp;
                            </div>
                        </div>
                    </div>
                    <div id="divRwd" runat="server" style="width: 96%; white-space: nowrap; text-align: left;
                        display: block;" class="panel-body">
                        <h3 class="form-section" style="text-align: left; border-bottom:none;">
                            TDS Master Setup</h3>
                        <div id="div5" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_SrvcTax" runat="server" AllowSorting="True"
                                        AllowPaging="true" AutoGenerateColumns="false" style="width: 100%;">
                                        <RowStyle CssClass="standardlabel" ></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="Code" SortExpression="TaxType">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("TaxType")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("TaxRulNo")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Tax Description" SortExpression="TaxTypeDesc">
                                                <ItemStyle HorizontalAlign="Center" CssClass="space"/>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc1" runat="server" Text='<%# Bind("TaxTypeDesc")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("TaxRulNo")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Amount From" SortExpression="TAXAMTFRM" >
                                                  <ItemStyle HorizontalAlign="right" CssClass="space"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaxFrm" runat="server" Text='<%# Bind("TAXAMTFRM")%>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Amount To" SortExpression="TAXAMTTO">
                                                <ItemStyle HorizontalAlign="Right" CssClass="space"/>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaxTo" runat="server" Text='<%# Bind("TAXAMTTO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS Rate" SortExpression="TDSRate">
                                                <ItemStyle HorizontalAlign="Center" CssClass="space" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaxRate" runat="server" Text='<%# Bind("TDSRate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IsActive" SortExpression="ISACTIVE">
                                                <ItemStyle HorizontalAlign="Center" CssClass="space"/>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("ISACTIVE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnIsActive" runat="server" Value='<%# Bind("IsActiveCd")%>'>
                                                    </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" CssClass="space"/>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEditSrvcTax" runat="server" Text="Edit" OnClick="lnkEditSrvcTax_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" CssClass="space"/>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelSrvcTax" runat="server" Text="Delete" OnClick="lnkDelSrvcTax_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddRwdTrg" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSaveRwdTrg" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <center>
                            <div id="divRwdPgTrg" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                        <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </center>
                        <div id="tblrwdtrg" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddRwdTrg" runat="server" Width="100px" CssClass="btn btn-sample"
                                    Enabled="true">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Add
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnSaveRwdTrg" runat="server" Width="100px" CssClass="btn btn-sample"
                                    Enabled="true">
                                    <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnCnt" runat="server" />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="275px" Width="1020px" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

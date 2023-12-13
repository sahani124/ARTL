<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MstSrvcTax.aspx.cs" Inherits="Application_ISys_Saim_Masters_MstSrvcTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />
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
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
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
    <script type="text/javascript" language="javascript">
        function funPopUp() {
            alert('akshay');
            //            var strContent = "ctl00_ContentPlaceHolder1_";
            //            $find("mdlViewBID").show();
            //            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMstSrvcTax.aspx?mdlpopup=mdlViewBID";
        }
    </script>
    <script type="text/javascript" language="javascript">
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

        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }

        function ShowReqDiv(divId, btnId, img, chkId, divChk) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + chkId) != null) {
                if (document.getElementById(strContent + chkId).checked == true) {
                    $(document.getElementById(strContent + divId)).slideToggle();
                    if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                        $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
                    }
                    else {
                        $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png');
                    }
                }
                else {
                    $(document.getElementById(strContent + divId)).hide();
                    $(document.getElementById(strContent + divChk)).show();
                }
            }
        }


        function ShowDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({
                height: 'toggle'
            });
        }

        function HideDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({ right: '25px' });
        }




    </script>
     <style type="text/css">
    .space
    {
        padding :10px;
    }
    </style>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
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
    <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>--%>
    <center>
        <div id="divRwdcollapse" runat="server" style="width: 90%;" class="panel panel-success">
            <div id="div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                        <asp:Label ID="Label3" Text="Master Setup" runat="server" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="Img3" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divRwd" runat="server" style="width: 100%; white-space: nowrap; text-align: left;
                display: block;" class="panel-body">
                <h3 class="form-section" style="text-align: left;">
                    GST Setup</h3>
                <div id="div1" runat="server" style="width: 100%; display:none;">
                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblChn" Text="Channel" runat="server" CssClass="control-label" /><span
                                style="color: Red;">*</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChn" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        OnSelectedIndexChanged="ddlChn_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="Label1" Text="Sub Class" runat="server" CssClass="control-label" /><span
                                style="color: Red;">*</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubChn" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                        OnSelectedIndexChanged="ddlSubChn_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div id="tblsvtrg" runat="server" class="row" style="margin-top: 12px; padding: 10px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" Enabled="true"
                                OnClick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnClear" Text="CLEAR" runat="server" CssClass="btn btn-primary"
                                Enabled="true" OnClick="btnClear_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnAdd" Text="ADD NEW" runat="server" CssClass="btn btn-primary"
                                Enabled="true" OnClick="btnAdd_Click" Visible="false">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                            </asp:LinkButton>
                            <asp:Button ID="btntax" runat="server" Style="display: none;" OnClick="btntax_Click" />
                        </div>
                    </div>
                </div>
                <div id="div5" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                    class="table-scrollable">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gv_SrvcTax" runat="server"  AllowSorting="True"
                                AllowPaging="true" AutoGenerateColumns="false" style="width: 100%;">
                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                              <Columns>
                                    <asp:TemplateField HeaderText="Transaction Type" SortExpression="Transaction_Type">
                                        <ItemStyle HorizontalAlign="center"  CssClass="space" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesc1" runat="server" Text='<%# Bind("Transaction_Type")%>' ></asp:Label>
                                            <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("Transaction_Type")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State Of J&K" SortExpression="state">
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxFrm" runat="server" Text='<%# Bind("state")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnBizSrc" runat="server" Value='<%# Bind("state")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resident Status" SortExpression="Resident_sattus">
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxTo" runat="server" Text='<%# Bind("Resident_sattus")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnChnCls" runat="server" Value='<%# Bind("Resident_sattus")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Type" SortExpression="TaxType">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxType" runat="server" Text='<%# Bind("TaxType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Rate" SortExpression="Tax_Rate">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxRate" runat="server" Text='<%# Bind("Tax_Rate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Is Active" SortExpression="IsActive">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("IsActive")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnIsActive" runat="server" Value='<%# Bind("IsActive")%>'>
                                            </asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditSrvcTax" runat="server" Text="Edit" OnClick="lnkEditSrvcTax_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemStyle HorizontalAlign="Center" />
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
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" Enabled="false" />
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
                        <asp:LinkButton ID="btnAddRwdTrg" runat="server" CssClass="btn btn-primary" Enabled="true"
                            OnClick="btnAddRwdTrg_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Add
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnSaveRwdTrg" runat="server" CssClass="btn btn-primary" Enabled="true">
                                    <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnCnt" runat="server" />
    </center>
    <asp:Panel runat="server" Height="275px" Width="1020px" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

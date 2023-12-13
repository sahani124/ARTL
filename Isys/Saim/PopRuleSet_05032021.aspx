<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopRuleSet.aspx.cs" Inherits="Application_ISys_Saim_PopRuleSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <style type="text/css">
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
    <center>
        <div id="divqualhdrcollapse" runat="server" style="width: 95%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblhdr" Text="Rule Set Key Definition" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                        <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divqual','myImg','#myImg');" />
                    </td>
                </tr>
            </table>
            <div id="divqual" runat="server" style="width: 100%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                            <asp:Label ID="lblrlSetKy" Text="Rule Set Key" runat="server" CssClass="control-label col-md-5" />
                        </td>
                        <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlRulSetKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <div id="div1" runat="server" style="width: 100%; padding: 10px; display: block;">
                    <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCR" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                    AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false">
                                    <HeaderStyle ForeColor="Black" Width="100%" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carry Forward Rule" SortExpression="CRYFWD">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCRYFWD" runat="server" Text='<%# Bind("CARRY_FWD")%>' />
                                                <asp:HiddenField ID="hdnCRYFWD" runat="server" Value='<%# Bind("CARRY_FWD")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reward Computation Rule" SortExpression="RWDCMPRUL">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRwdCmpRul" runat="server" Text='<%# Bind("RWD_CMP_RULE")%>' />
                                                <asp:HiddenField ID="hdnRwdCmpRul" runat="server" Value='<%# Bind("RWD_CMP_RULE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Type" SortExpression="UNIT_TYPE">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UNIT_TYPE")%>' />
                                                <asp:HiddenField ID="hdnUnitType" runat="server" Value='<%# Bind("UNIT_TYPE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Max Limit" SortExpression="MAX_LIMIT">
                                            <ItemStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaxLmt" runat="server" Text='<%# Bind("MAX_LIMIT")%>' />
                                                <asp:HiddenField ID="hdnMaxLmt" runat="server" Value='<%# Bind("MAX_LIMIT")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="text-align:left;padding:10px;">
                    <asp:Label ID="lblNote" runat="server" ForeColor="Red" /></div>
                <table id="tblrwd" runat="server" class="form-actions fluid" style="width: 100%;">
                    <tr>
                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                            <asp:Button ID="btnSave" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                Enabled="true" />
                            <asp:Button ID="btnCancel" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                                OnClientClick="doCancel();return false;" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </center>
</asp:Content>

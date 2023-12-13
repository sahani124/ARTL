<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopSubCntst.aspx.cs" Inherits="Application_ISys_Saim_PopSubCntst" %>

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
            box-shadow: none !important;
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

        function doOk() {
            
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btncmp") != null) {
                window.parent.document.getElementById("btncmp").click();
            }
            else {
            }
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btnSbCnt") != null) {
                window.parent.document.getElementById("btnSbCnt").click();
            }
            else {
                ///alert("no btncmp");
            }
        }
    </script>
    <center>
    <div id="divBsKPIhdr" runat="server" style="width: 95%;" class="divBorder1">
        <table class="formtablehdr" style="width: 100%;">
            <tr style="height: 30px;">
                <td style="padding-left: 5px;">
                    <i class="fa fa-list"></i>
                    <asp:Label ID="Label16" Text="Add Sub Contestants" runat="server" Style="padding-left: 5px;" />
                </td>
                <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                    <img id="Img1" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divBsKPI','Img1','#Img1');" />
                </td>
            </tr>
        </table>
        <div id="divBsKPI" runat="server" style="width: 100%;">
            <table id="tblBskpi" runat="server" style="width: 100%;">
                <tr>
                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                        <asp:Label ID="Label17" Text="Sales Channel" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label19" Text="*" runat="server" Style="color: Red" />
                    </td>
                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSlsChnl" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlSlsChnl_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                        <asp:Label ID="Label21" Text="Sub Class" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label22" Text="*" runat="server" Style="color: Red" />
                    </td>
                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                        <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubCls" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlSubCls_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                        <asp:Label ID="lblCntst" Text="Contestant Code" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label18" Text="*" runat="server" Style="color: Red" />
                    </td>
                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                        <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlContestant" runat="server" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlContestant_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                        <asp:Label ID="lblSubCont" Text="Rule Set Key" runat="server" CssClass="control-label" />
                        <asp:Label ID="Label20" Text="*" runat="server" Style="color: Red" />
                    </td>
                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubCnt" runat="server" CssClass="select2-container form-control"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table class="form-actions fluid" style="width: 100%;">
                <tr>
                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                        <asp:Button ID="btnAdd" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                             onclick="btnAdd_Click" />
                        <asp:Button ID="btnCncl" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                            OnClientClick="doCancel();return false;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </center>
</asp:Content>

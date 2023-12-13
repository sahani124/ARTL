<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopFrmlEditCatg.aspx.cs" Inherits="Application_ISys_Saim_PopFrmlEditCatg" %>

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

        function funcall() {

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="divrwdrulcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblhdr" Text="Formula Editor" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <%--<img id="Img4" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />--%>
                                <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divfrmltrg','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divfrmltrg" runat="server" style="width: 100%; padding: 10px;">
                        <table id="tblfrml" runat="server" style="width: 100%">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                    <asp:Label ID="Label2" Text="Data Function Key" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlFunckeyTrg" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlFunckeyTrg_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                    <asp:Label ID="Label3" Text="Based on KPI" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlKPICode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table id="tblfrmltxt" runat="server" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFrmlTrg" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                        Width="100%" />
                                </td>
                            </tr>
                        </table>
                        <div id="tblbtnfrml" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveFrml" runat="server" CssClass="btn btn-primary" 
                                    TabIndex="24">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclFrml" runat="server" CssClass="btn btn-primary"
                                    TabIndex="25" OnClientClick="doCancel();return false;">
                                    <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                    </asp:LinkButton>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopFrmlEdit.aspx.cs" Inherits="Application_ISys_Saim_PopFrmlEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
            vertical-align: top;
        }
    </style>
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

            /////alert('dkjahjkd');
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="divfrmedtcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label1" Text="Formula Editor" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                    alt="" onclick="ShowReqDtl('divfrmltrg','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divfrmltrg" runat="server" style="width: 100%; padding: 10px;">
                        <table id="tblfrmltxt" runat="server" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFrmlTrg" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                        Width="100%" />
                                </td>
                            </tr>
                        </table>
                        <table id="tblbtnfrml" runat="server" class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:LinkButton ID="btnCnclFrml" Text="CANCEL" runat="server" CssClass="btn btn-primary"
                                        Width="80px" TabIndex="25" OnClientClick="doCancel();return false;">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                        </asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

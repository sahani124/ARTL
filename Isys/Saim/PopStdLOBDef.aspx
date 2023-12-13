<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopStdLOBDef.aspx.cs" Inherits="Application_ISys_Saim_PopStdLOBDef" %>

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
        function doOk(LOBcode, LOBName,Freq, FreqVal, Consider, ConsiderVal, Type, TypeVal, Wght) {
            window.parent.document.getElementById('<%=Request.QueryString["LOB"].ToString()%>').value = LOBcode;
            window.parent.document.getElementById('<%=Request.QueryString["LOBval"].ToString()%>').value = LOBName;
            window.parent.document.getElementById('<%=Request.QueryString["PrdctFreq"].ToString()%>').value = Freq;
            window.parent.document.getElementById('<%=Request.QueryString["PrdctFreqval"].ToString()%>').value = FreqVal;
            window.parent.document.getElementById('<%=Request.QueryString["Consider"].ToString()%>').value = Consider;
            window.parent.document.getElementById('<%=Request.QueryString["Considerval"].ToString()%>').value = ConsiderVal;
            window.parent.document.getElementById('<%=Request.QueryString["Type"].ToString()%>').value = Type;
            window.parent.document.getElementById('<%=Request.QueryString["Typeval"].ToString()%>').value = TypeVal;
            window.parent.document.getElementById('<%=Request.QueryString["Wght"].ToString()%>').value = Wght;
            window.parent.document.getElementById("btnLOB").click();
            alert('akshayZ');
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            alert('akshayT');
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        //        
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
    </style>
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="divPrdcthdrcollapse" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblhdr" Text="Select LOB level weightage definitions" runat="server"
                                    Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divPrdct','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divPrdct" class="divBorder1" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblLOBName" Text="LOB Name" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlLOBName" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5" OnSelectedIndexChanged="ddlLOBName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblPrdctName" Text="Product Name" runat="server" Visible="false" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlPrdctName" runat="server" Visible="false" AutoPostBack="true" CssClass="select2-container form-control col-md-5" OnSelectedIndexChanged="ddlPrdctName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblFreq" Text="Frequency" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlFreq" runat="server" AutoPostBack="true" CssClass="select2-container form-control col-md-5">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblConsider" Text="Consider" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rbtConsider" runat="server" AutoPostBack="true" CssClass="radio-list"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Text="INCLUDE" Value="I"></asp:ListItem>
                                                <asp:ListItem Text="EXCLUDE" Value="E"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblType" Text="Unit Type" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="true" CssClass="radio-list"
                                                RepeatDirection="Horizontal" CellSpacing="10" OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                                                <asp:ListItem Text="AMOUNT" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="PERCENT" Value="P"></asp:ListItem>
                                                <asp:ListItem Text="NUMBER" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblwght" Text="Weightage" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%;" class="col-md-7">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtWgth" runat="server" CssClass="form-control" TabIndex="2" placeholder="Weightage" /></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btnSave" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnCncl" Text="CANCEL" runat="server" Width="100px" CssClass="btn default"
                                        OnClick="btnCncl_Click" OnClientClick="doCancel();return false;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>


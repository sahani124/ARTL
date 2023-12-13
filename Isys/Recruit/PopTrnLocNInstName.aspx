<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopTrnLocNInstName.aspx.cs"
    Inherits="Application_INSC_PopTrnLocNInstName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function doSelect(args1, args2) {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["strhdnTrnInstitute"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["strtxtTrnInstitute"].ToString()%>').value = args2;
            window.parent.document.getElementById('<%=Request.QueryString["strtxtTrnInstitute"].ToString()%>').disabled = false;
            window.parent.document.getElementById('<%=Request.QueryString["strtxtTrnInstitute"].ToString()%>').focus();
            //window.parent.window.hidePopWin(false);
            window.parent.$find('mdlViewBID').hide();
            // window.parent.document.getElementById('<%=Request.QueryString["strtxtTrnInstitute"].ToString()%>').disabled = true;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }
        function doClear() {
            document.getElementById("txtTrnLocCode").value = "";
            document.getElementById("txtTrnLocName").value = "";
            document.getElementById("txtTrnInstCode").value = "";
            document.getElementById("txtTrnInstName").value = "";
            document.getElementById("lblMessage").value = "";
        }
        function doCancel() {
            window.parent.$find('mdlViewBID').hide();
            //window.parent.window.hidePopWin(false);
            //window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/plugins/revolution_slider/css/rs-style.css" media="screen" />
    <link rel="stylesheet" href="assets/plugins/revolution_slider/rs-plugin/css/settings.css"
        media="screen" />
    <link href="assets/plugins/bxslider/jquery.bxslider.css" rel="stylesheet" />
    <!-- END PAGE LEVEL PLUGIN STYLES-->
    <!-- BEGIN THEME STYLES -->
    <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style1.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
     <!-- END THEME STYLES -->
</head>
<body>
    <form id="form1" runat="server">
    <div id="divTrnLoc" runat="server" visible="false">
        <table class="formtable" width="100%">
            <tr id="trLocation" runat="server">
                <td class="test" align="center" colspan="4">
                    Training Institute Search
                </td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblTrnLocCode" runat="server" Text="Training Location Code" ></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtTrnLocCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblTrnLocName" runat="server" Text="Training Location Name"></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtTrnLocName" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divTrnInstitute" runat="server" visible="false">
        <table class="formtable" width="100%">
            <tr id="trlocationn" runat="server">
                <td class="test" align="center" colspan="4">
                    Training Institute Search
                </td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblTrnInstCode" runat="server" Text="Training Institute Code"></asp:Label>
                </td>
                <td class="formcontent" style="width: 100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtTrnInstCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formcontent" nowrap="nowrap">
                    <asp:Label ID="lblTrnInstName" runat="server" Text="Training Institute Name"></asp:Label>
                </td>
                <td class="formcontent" width="100%">
                    <asp:TextBox CssClass="standardtextbox" ID="txtTrnInstName" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divButtons" runat="server">
        <table class="formtable" width="100%">
            <tr>
                <td colspan="2" align="center">
                <%-- <div class="btn btn-xs btn-primary">
                        <i class="fa fa-search"></i>--%>
                    <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search"
                        OnClick="btnSearch_Click" /><%--</div>--%>
                          <span style="padding-left:3px;"></span>
                    <%--<div class="btn btn-xs btn-primary">
                        <i class="fa fa-times"></i>--%>
                    <asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" OnClientClick="doClear();return false;" /><%--</div>--%>
                    <span style="padding-left:3px;"></span>
                    <%--<div class="btn btn-xs btn-primary">
                        <i class="fa fa-times-circle-o"></i>--%>
                    <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel"
                        OnClientClick="doCancel();return false;" /><%--</div>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"> </asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="divDGList" runat="server" visible="false">
        <table class="formtable" width="100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" OnSorting="gv_Sorting"
                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" AllowPaging="True"
                        AllowSorting="True">
                        <HeaderStyle CssClass="portlet blue"  ForeColor="White" Font-Bold="true" />
                        <AlternatingRowStyle CssClass="sublinkeven" />
                        <RowStyle CssClass="sublinkodd" />
                        <PagerStyle CssClass="pagelink" />
                        <Columns>
                            <asp:BoundField DataField="ECCode" NullDisplayText=" " HeaderText="Centre Code" SortExpression="ECCode" />
                            <asp:TemplateField HeaderText="Centre Name" SortExpression="HwsUnitDesc01">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("HwsUnitDesc01") %>'></asp:LinkButton>
                                    <asp:HiddenField ID="hdnECCode" runat="server" Value='<%# Bind("ECCode") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHistory.aspx.cs" Inherits="UserHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<head runat="server">
    <title></title>
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
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
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
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI%20Styles/assets/css/KMI%20-%20Copy.css" rel="stylesheet" />--%>
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>

    <!-- END THEME STYLES -->
    <style type="text/css">
        /*.test
        {
            background-image: url(assets/img/tab-bg3.jpg);
            color: Navy;
        }
        .formtable
        {
            background-color: #f0f0f0;
            height: 18px;
            text-align: left;
            width: 80%;
        }
        .style1
        {
            width: 246px;
        }
        .style2
        {
            width: 352px;
        }
        .sublinkeven
        {
            font-family: arial;
            font-weight: normal;
            font-size: 11px;
            padding: 3px 3px 3px 3px;
            color: #0076B7;
            background-color: #ffffff;
            text-valign: middle;
            text-align: center;
        }
        .sublinkodd
        {
            font-family: arial;
            font-weight: normal;
            font-size: 11px;
            padding: 4px 4px 4px 4px;
            color: #0076B7;
            background-color: #F6F6F6;
            text-valign: middle;
            text-align: center;
        }*/
        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: #FFFFFF;
            border-color: #f04e5e;
            text-align: center;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
        </script>
</head>
<body>
    <form id="form1" runat="server" action="">
        <asp:ScriptManager runat="server" ID="SM2" />
        <div class="container">
        <asp:UpdatePanel runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <center>
                    <div>
                        <div class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                            <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('divSearch1','btnWfParam');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblReportingUnit" runat="server" CssClass="control-label" Text="Search Previous Test Takers" Font-Size="19px"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divSearch1" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblEmployeeName" runat="server" CssClass="control-label" Text="Employee Name"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control"
                                                    MaxLength="40" TabIndex="1" ForeColor="Black"></asp:TextBox><br />
                                                <asp:RegularExpressionValidator ValidationGroup="valgrp1" ErrorMessage="Name cannot be in Numbers!"
                                                    ControlToValidate="txtEmployeeName" ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"
                                                    runat="server" ForeColor="Red" SetFocusOnError="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblEmployeeCode" CssClass="control-label" runat="server" Text="Employee Code"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="form-control"
                                                    MaxLength="8" TabIndex="2" ForeColor="Black"></asp:TextBox><br />
                                                <asp:RegularExpressionValidator ValidationGroup="valgrp1" ErrorMessage="Code cannot be in Alphabets!"
                                                    ControlToValidate="txtEmployeeCode" Display="Dynamic" ValidationExpression="^[0-9\-\(\)\, ]+$"
                                                    runat="server" ForeColor="Red" SetFocusOnError="true" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 37px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-sample" ValidationGroup="valgrp1"
                                            runat="server">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-sample"
                                            TabIndex="5" runat="server">
                                 <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Cancel
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <asp:UpdatePanel runat="server" ID="UpdPnl_Error" UpdateMode="Conditional">
                            <ContentTemplate>
                                <center>
                                    <asp:Label ID="lblError" ForeColor="Red" Font-Names="Arial" Font-Size="Small" runat="server" /></center>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server" ID="UpdPnl_Details" UpdateMode="Always">
                            <ContentTemplate>
                                <div>
                                    <div class="panel" id="tbl_Details" style="margin-left: 3%; margin-right: 3%; margin-top: 0.5%" visible="false" runat="server">
                                        <div class="panel-heading" onclick="ShowReqDtl('divCndMvmt','btnCndMvmt');return false;">
                                            <div class="row" id="cndmvmt" runat="server">
                                                <div class="col-sm-10" style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text="Previous Test Takers" CssClass="control-label" Font-Size="19px"></asp:Label>
                                                    <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                                </div>
                                                <div class="col-sm-2">
                                                    <span id="btnCndMvmt" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divCndMvmt" runat="server" style="margin-top: 11px;">

                                            <div id="trDgDetails" runat="server" style="overflow-x: scroll; display: block">

                                                <asp:UpdatePanel runat="server" UpdateMode="Always" ID="UpdPnl_GridView">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CssClass="footable" Style="border-bottom-color: black;"
                                                            PageSize="10" AllowSorting="True" AllowPaging="True" OnPageIndexChanging="gvDetails_PageIndexChanging"
                                                            OnSorting="gvDetails_Sorting">
                                                            <PagerStyle CssClass="disablepage" />
                                                            <HeaderStyle CssClass="gridview th" />
                                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="true" HeaderText="Employee Name" SortExpression="LEGALNAME"
                                                                    HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName" Text='<%# Bind("LEGALNAME") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="btn btn-xs" style="width: 100%;">
                                                                            <i class="fa fa-bar-chart-o"></i>
                                                                            <asp:LinkButton ID="lnkViewReport" Text="View Report" runat="server" OnClick="lnkViewReport_Click" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <%-- <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                                            <PagerSettings Mode="Numeric" />
                                                            <PagerStyle CssClass="pagination pagination-sm" />
                                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                            <div id="trGridCndStatusPage" runat="server" visible="false">

                                                <br />


                                            </div>
                                        </div>
                                        </br>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                            CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px"
                                                            OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>

                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
            </div>
    </form>
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS-->
    <script src="assets/plugins/flot/jquery.flot.js" type="text/javascript"></script>
    <script src="assets/plugins/flot/jquery.flot.resize.js" type="text/javascript"></script>
    <script src="assets/plugins/gritter/js/jquery.gritter.js" type="text/javascript"></script>
    <!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
    <script src="assets/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/scripts/app.js" type="text/javascript"></script>
    <script src="assets/scripts/index.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- END JAVASCRIPTS -->
    <!-- Load javascripts at bottom, this will reduce page load time -->
    <!-- BEGIN CORE PLUGINS(REQUIRED FOR ALL PAGES) -->
    <!--[if lt IE 9]>
    <script src="assets/plugins/respond.min.js"></script>  
    <script src="assets/plugins/excanvas.min.js"></script> 
    <![endif]-->
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/back-to-top.js"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL JAVASCRIPTS(REQUIRED ONLY FOR CURRENT PAGE) -->
    <script type="text/javascript" src="assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
    <script type="text/javascript" src="assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
    <script type="text/javascript" src="assets/plugins/bxslider/jquery.bxslider.min.js"></script>
    <script src="assets/scripts/app.js" type="text/javascript"></script>
    <script src="assets/scripts/index.js" type="text/javascript"></script>
    <script src="assets/scripts/core/app.js" type="text/javascript"></script>
    <script src="assets/scripts/custom/ui-alert-dialog-api.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootbox/bootbox.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery.noConflict();
            App.init();
            UIAlertDialogApi.init();
        });
    </script>
    <!-- END PAGE LEVEL JAVASCRIPTS -->
</body>
</html>

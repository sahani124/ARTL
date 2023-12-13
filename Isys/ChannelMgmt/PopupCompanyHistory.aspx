<%--Creator:		    <Ajay Yadav> 
    Create date:      <10th Sep 2021>
    Description:	    <This page is created for serach history of  company.>
--%>
<%
    @ Page Language="C#" AutoEventWireup="true" CodeFile="PopupCompanyHistory.aspx.cs" Inherits="Application_Isys_ChannelMgmt_PopupCompanyHistory" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
     <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

    <style type="text/css">
        .ccsalignCenter {
            text-align: center !important;
        }

        .cssalingleft {
            text-align: left !important;
        }

        .cssalingright {
            text-align: right !important;
        }
    </style>

    <script lang="javascript" type="text/javascript">

        //  Model Popup Cancel Button Close.
        function ClosePopup() {
            debugger;
            window.parent.$find('mdlViewBIDUT').hide();
        }

        // function for Collapse of panel Humburger
        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
            }
            else {
                objnewdiv.style.display = "block";
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                <div id="DivSearch" runat="server" class="panel" style="margin-left: 2%; margin-top: 0.5%">
                    <div id="DivHeader" runat="server" class="panel-heading" onclick="ShowReqDtl2('DivBody','myImg');return false;">
                        <div class="row">

                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblhdr1" Text=" " runat="server" Font-Size="19px" Style="padding-left: 5px;" />
                            </div>
                            <div class="col-sm-2">
                               <%-- <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                            </div>

                        </div>

                    </div>

                    <div id="DivBody" runat="server" class="panel-body" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                        <div class="row">
                            <div class="col-sm-12" style="text-align: left; margin-left: 19px;">
                                <asp:Label ID="Label25" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>

                        </div>
                        <div id="DivSubBody" runat="server" class="panel-body" style="display: block">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="Label24" runat="server" Text="Modification Mode" CssClass="control-label" />
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:RadioButtonList ID="rdMode" runat="server" CellPadding="2" CellSpacing="2"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR">  </asp:ListItem>
                                        <asp:ListItem Text="&nbspChanges&nbsp" Value="CH"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblFinyer" Text="Financial year" CssClass="control-label" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlFinYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-12" style="text-align: center">

                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success"
                                        CausesValidation="false" TabIndex="14" OnClick="btnSearch_Click"> 
                                   <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> Search 
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-clear" OnClientClick="ClosePopup();">
                                <span class="glyphicon glyphicon-remove" style="color:red;"></span> Cancel
                                    </asp:LinkButton>

                                </div>

                            </div>
                        </div>
                        <div id="divloader" runat="server" style="display: none; text-align: center;">
                            <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                            Loading...
                        </div>

                        <div id="DivGrid" runat="server" class="panel-body" style="display: block; overflow: auto">
                            <asp:GridView AllowSorting="True" ID="gvhistory" runat="server" CssClass="footable"
                                AutoGenerateColumns="False" PageSize="50" AllowPaging="true" CellPadding="1">
                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Company">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("BizSrc") %>'
                                                CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Company Desc 01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyDesc01" runat="server" Text='<%# Eval("ChannelDesc01") %>'
                                                CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Company Desc 02">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyDesc02" runat="server" Text='<%# Eval("ChannelDesc02") %>'
                                                CommandArgument='<%# Eval("ChannelDesc02") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Company Desc 03">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyDesc03" runat="server" Text='<%# Eval("ChannelDesc03") %>'
                                                CommandArgument='<%# Eval("ChannelDesc03") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sort Order">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSortOrder" runat="server" Text='<%# Eval("SortOrder") %>'
                                                CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                                CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVersion" runat="server" Text='<%# Eval("Version") %>'
                                                CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Insurance Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInsuranceType" runat="server" Text='<%# Eval("Insurance_Type") %>'
                                                CommandArgument='<%# Eval("Insurance_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Company name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompName" runat="server" Text='<%# Eval("CompName") %>'
                                                CommandArgument='<%# Eval("CompName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Year of Incorporation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblYrIncorporation" runat="server" Text='<%# Eval("YrIncorporation") %>'
                                                CommandArgument='<%# Eval("YrIncorporation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ccsalignCenter" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="License Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>'
                                                CommandArgument='<%# Eval("LcnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingright" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Office Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOffcAddr" runat="server" Text='<%# Eval("OffcAddr") %>'
                                                CommandArgument='<%# Eval("OffcAddr") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModMode" runat="server" Text='<%# Eval("ModMode") %>'
                                                CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Parent Channel Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblParntChnlID" runat="server" Text='<%# Eval("Parnt_ChnlID") %>'
                                                CommandArgument='<%# Eval("Parnt_ChnlID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Business Year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBusYr" runat="server" Text='<%# Eval("BusYrFlg") %>'
                                                CommandArgument='<%# Eval("BusYrFlg") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Freeze Business Year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFrzBsnss" runat="server" Text='<%# Eval("FrzBsnssFlg") %>'
                                                CommandArgument='<%# Eval("FrzBsnssFlg") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ccsalignCenter" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEffDate" runat="server" Text='<%# Eval("EffDate") %>'
                                                CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ccsalignCenter" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCeaseDate" runat="server" Text='<%# Eval("CeaseDate") %>'
                                                CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ccsalignCenter" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created By">
                                        <ItemTemplate>
                                            <asp:Label ID="CreateBy" runat="server" Text='<%# Eval("CreateBy") %>'
                                                CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="cssalingleft" />
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDtim" runat="server" Text='<%# Eval("CreateDtim") %>'
                                                CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ccsalignCenter" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>

                        <div id="DivSubChnl" runat="server" class="panel-body" style="display: block; overflow: auto">
                            <asp:GridView AllowSorting="True" ID="gvSubChnl" runat="server" CssClass="footable"
                                AutoGenerateColumns="False" PageSize="50" AllowPaging="true" CellPadding="1">
                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                      <Columns>
                              
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sub Channel Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnCls") %>'
                                            CommandArgument='<%# Eval("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                             
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Desc 01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnClsDesc01") %>'
                                            CommandArgument='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Desc 02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnClsDesc02") %>'
                                            CommandArgument='<%# Eval("ChnClsDesc02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Desc 03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnClsDesc03") %>'
                                            CommandArgument='<%# Eval("ChnClsDesc03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sort Order">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("SortOrder") %>'
                                            CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="End Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Creator">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>



                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modifier">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                            CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modified Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sub Chnl Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("SubChnlId") %>'
                                            CommandArgument='<%# Eval("SubChnlId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>

                            </asp:GridView>
                        </div>

                        <div id="DivMemType" runat="server" class="panel-body" style="display: block; overflow: auto">
                        <asp:GridView AllowSorting="True" ID="gvMemType" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BizSrc") %>'
                                            CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemType") %>'
                                            CommandArgument='<%# Eval("MemType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sub class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnCls") %>'
                                            CommandArgument='<%# Eval("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRank") %>'
                                            CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Level">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemLevel") %>'
                                            CommandArgument='<%# Eval("MemLevel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc01") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc02") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc03") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Member Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemberRole") %>'
                                            CommandArgument='<%# Eval("MemberRole") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Member Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemberRole") %>'
                                            CommandArgument='<%# Eval("MemberRole") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Alw. RecruitMem">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwRecruitMem") %>'
                                            CommandArgument='<%# Eval("AlwRecruitMem") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>


                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. CreateRul">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemCreateRul") %>'
                                            CommandArgument='<%# Eval("MemCreateRul") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Unitchannel") %>'
                                            CommandArgument='<%# Eval("Unitchannel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Sub Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitSubClass") %>'
                                            CommandArgument='<%# Eval("UnitSubClass") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>


                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitType") %>'
                                            CommandArgument='<%# Eval("UnitType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Is Unit Manager">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("IsUnitManager") %>'
                                            CommandArgument='<%# Eval("IsUnitManager") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                            CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                               </div>

                                <div id="DivUnitType" runat="server" class="panel-body" style="display: block; overflow: auto">
                        <asp:GridView  AllowSorting="True" ID="gvUnitType" runat="server"  ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellSpacing="1">
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                             <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitBizSrc" runat="server" Text='<%# Eval("BizSrc") %>'
                                            CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderText="Sub Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitChnCls" runat="server" Text='<%# Eval("ChnCls") %>'
                                            CommandArgument='<%# Eval("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center"   HeaderText="Unit Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitType" runat="server" Text='<%# Eval("UnitType") %>'
                                            CommandArgument='<%# Eval("UnitType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                              

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center"   HeaderText="Unit Rank">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitRank" runat="server" Text='<%# Eval("UnitRank") %>'
                                            CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center"   HeaderText="Unit Level">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitLevel" runat="server" Text='<%# Eval("UnitLevel") %>'
                                            CommandArgument='<%# Eval("UnitLevel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center"   HeaderText="Unit Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitUnitDesc01" runat="server" Text='<%# Eval("UnitDesc01") %>'
                                            CommandArgument='<%# Eval("UnitDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Allow Multiple Unit Manager">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwMultiUntMgr") %>'
                                            CommandArgument='<%# Eval("AlwMultiUntMgr") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                               
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Allow Services">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwSvc") %>'
                                            CommandArgument='<%# Eval("AlwSvc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Rule Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("RptRule") %>'
                                            CommandArgument='<%# Eval("RptRule") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center"   HeaderText="Financial Year">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="End Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>--%>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modifier">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                            CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modified Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Creator">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                                 </asp:GridView>
                              </div>


          
                        <div id="divUnitRank" runat="server" class="panel-body" style="display: block; overflow: auto">
                        <asp:GridView AllowSorting="True" ID="gvHistoryUntRnk" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <Columns>
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BizSrc") %>'
                                            CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRank") %>'
                                            CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc01") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc02") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank Desc 03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankDesc03") %>'
                                            CommandArgument='<%# Eval("UnitRankDesc03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr01") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr02") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank Hdr03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRankHdr03") %>'
                                            CommandArgument='<%# Eval("UnitRankHdr03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created by">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>

</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopKpiMemCycleNS.aspx.cs" Inherits="Application_Report_PopKpiMemCycleNS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Member Search</title>
    <%--Added by vijendra on 05-06-2014 start--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />

    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />

    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <%--Added by vijendra on 05-06-2014 start--%>
    <style type="text/css">
        .buttonSelect {
        }
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/

        .dataTable {
            width: 100% !important;
            clear: both;
            margin-top: 5px;
        }

        .dataTables_filter label {
            line-height: 32px;
        }

        .dataTable .row-details {
            margin-top: 3px;
            display: inline-block;
            cursor: pointer;
            width: 14px;
            height: 14px;
        }

            .dataTable .row-details.row-details-close {
                background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
            }

            .dataTable .row-details.row-details-open {
                background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px;
            }

        .dataTable .details {
            background-color: #eee;
        }

            .dataTable .details td, .dataTable .details th {
                padding: 4px;
                background: none;
                border: 0;
                border: 1px solid #ddd;
            }

            .dataTable .details tr:hover td, .dataTable .details tr:hover th {
                background: none;
            }

            .dataTable .details tr:nth-child(odd) td, .dataTable .details tr:nth-child(odd) th {
                background-color: #eee;
            }

            .dataTable .details tr:nth-child(even) td, .dataTable .details tr:nth-child(even) th {
                background-color: #eee;
            }

        .dataTable > thead > tr > th.sorting, .dataTable > thead > tr > th.sorting_asc, .dataTable > thead > tr > th.sorting_desc {
            padding-right: 18px;
        }

        .dataTable .table-checkbox {
            width: 8px !important;
        }

        @media (max-width: 768px) {
            .dataTables_wrapper .dataTables_length .form-control, .dataTables_wrapper .dataTables_filter .form-control {
                display: inline-block;
            }

            .dataTables_wrapper .dataTables_info {
                top: 17px;
            }

            .dataTables_wrapper .dataTables_paginate {
                margin-top: -15px;
            }
        }

        @media (max-width: 480px) {
            .dataTables_wrapper .dataTables_filter .form-control {
                width: 175px !important;
            }

            .dataTables_wrapper .dataTables_paginate {
                float: left;
                margin-top: 20px;
            }
        }

        .dataTables_processing {
            position: fixed;
            top: 50%;
            left: 50%;
            min-width: 125px;
            margin-left: 0;
            padding: 7px;
            text-align: center;
            color: #333;
            font-size: 13px;
            border: 1px solid #ddd;
            background-color: #eee;
            vertical-align: middle;
            -webkit-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            -moz-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
        }

            .dataTables_processing span {
                line-height: 15px;
                vertical-align: middle;
            }

        .dataTables_empty {
            text-align: center;
        }

        .ajax__calendar {
            position: relative;
            z-index: 9999;
        }

        .new_text_new {
            color: #066de7;
        }

        .form-submit-button {
        }

        .disablepage {
            display: none;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .align {
            text-align: left;
        }

        .rowalign {
            margin-bottom: 15px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function ValidationSelection() {
            alert("You haven't select any data");


        }
        function funCheckUnCheck(objId) {
            //debugger;
            var grd = document.getElementById("GrdSearch");
            var rdoArray = grd.getElementsByTagName("input");
            for (i = 0; i <= rdoArray.length - 1; i++) {
                if (rdoArray[i].type == 'checkbox') {////
                    if (objId == "GrdSearch_ctl01_checkAll") {
                        if (document.getElementById("GrdSearch_ctl01_checkAll").checked == true) {
                            rdoArray[i].checked = true;
                        }
                        else {
                            rdoArray[i].checked = false;
                        }
                    }
                    else if (rdoArray[i].id == objId) {
                        if (rdoArray[i].checked == true) {
                            rdoArray[i].checked = true;
                        }
                        else {
                            rdoArray[i].checked = false;
                            document.getElementById("GrdSearch_ctl01_checkAll").checked = false;
                        }
                    }
                }
            }

        }

        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }

        window.onbeforeunload = RefreshParent;

        function Validation() {
            if (document.getElementById('txtsearch').value == "") {
                alert("Please Insert Search.")
                document.getElementById('txtsearch').focus();
                return false;
            }
            return true;
        }

        function doSelect(Flag, args, Code) {
            debugger;
            if (Flag == "LEADSOURCE") {
                window.opener.document.getElementById('DvLeadSource').innerHTML = args;
                window.opener.document.getElementById('hndleadsourceDesc').value = args;
                window.opener.document.getElementById('hdnleadsource').value = Code;
            }
            if (Flag == "LEADSUBSOURCE") {
                window.opener.document.getElementById('DvLeadSubSource').innerHTML = args;
                window.opener.document.getElementById('hndleadsubsourceDesc').value = args;
                window.opener.document.getElementById('hdnleadsubsource').value = Code;
            }
            if (Flag == "BRANCH") {
                window.opener.document.getElementById('DvBranch').innerHTML = args;
                window.opener.document.getElementById('hndBranchDesc').value = args;
                window.opener.document.getElementById('hdnBranch').value = Code;
            }
            if (Flag == "PRODUCT") {
                window.opener.document.getElementById('DvProduct').innerHTML = args;
                window.opener.document.getElementById('hndProductDesc').value = args;
                window.opener.document.getElementById('hndProduct').value = Code;
            }

            if (Flag == "Region") {
                window.opener.document.getElementById('DivGeoLoc').innerHTML = args;
                //                    window.opener.document.getElementById('hdnRegionCode').innerHTML = Code;
                window.opener.document.getElementById('hdnRegionCode').value = Code;
            }

            if (Flag == "BranchCode") {
                window.opener.document.getElementById('Divbranch').innerHTML = args;
                //                    window.opener.document.getElementById('hdnBranchCodeDesc').innerHTML = args;
                window.opener.document.getElementById('hdnBranchCode').value = Code;
            }

            if (Flag == "Zone") {
                //                    window.opener.document.getElementById('DvBranchCode').innerHTML = args;
                //                    window.opener.document.getElementById('hdnBranchCodeDesc').innerHTML = args;
                window.opener.document.getElementById('hdnZoneCode').value = Code;
            }

            if (Flag == "SmCode") {
                window.opener.document.getElementById('DivSmCode').innerHTML = args;
                //                    window.opener.document.getElementById('hdnBranchCodeDesc').innerHTML = args;
                window.opener.document.getElementById('HiddenSmcode').value = Code;

                // window.opener.document.getElementById('HdnSMcode').value = Code;
            }

            if (Flag == "MarketType") {
                var strCount = "(" + document.getElementById('HdnMarkCnt').value + ")"
                window.opener.document.getElementById('hdnMarcketypeDesc').value = args;
                window.opener.document.getElementById('hdnMarcketCode').value = Code;
                window.opener.document.getElementById('hMarket').value = strCount;
                window.opener.document.getElementById("BtnToolTip").click();


            }

            if (Flag == "HNIN") {
                var strHNIN = "(" + document.getElementById('HdnHninCnt').value + ")"
                //  window.opener.document.getElementById('DvHNINCodeVal').innerHTML = args;
                window.opener.document.getElementById('HdnHninDesc').value = args;
                window.opener.document.getElementById('HdnHninCode').value = Code;

                window.opener.document.getElementById('Hhnin').value = strHNIN;
                window.opener.document.getElementById("BtnHNINToolTip").click();

            }
            if (Flag == "Agent") {
               
               // var strAgent = "(" + document.getElementById('HdnAgentCnt').value + ")"
                // window.opener.document.getElementById('DvAgtNameVal').innerHTML = args;

                var HiddenDesc = document.getElementById('HiddenDesc').value;
                var HiddenCode = document.getElementById('HiddenCode').value;

               // alert(HiddenDesc);
                window.opener.document.getElementById(HiddenDesc).value = args;
                
                window.opener.document.getElementById(HiddenCode).value = Code;

                window.opener.document.getElementById(HiddenDesc).innerText = args;

                window.opener.document.getElementById(HiddenCode).innerText = Code;

                //alert("hi");
                //alert(HiddenDesc);
                //alert(window.opener.document.getElementById(HiddenDesc).value);
               // window.opener.document.getElementById('ctl00_ContentPlaceHolder1_HAgent').value = strAgent;
              //  window.opener.document.getElementById("BtnAgentToolTip").click();


            }


            //window.opener.location.reload(true)
            window.close();
        }
    </script>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

             <asp:HiddenField ID="HiddenDesc" runat="server" />
                                                    <asp:HiddenField ID="HiddenCode" runat="server" />
            <asp:UpdatePanel ID="Upd" runat="server">
                <ContentTemplate>


                    <%--  <div class="page-container" style="margin-top: 0px;">--%>
                    <%-- <div id="div1" runat="server" class="panel"  >--%>
                    <%-- <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                    <%-- <asp:Label ID="lblhdr" Text="" runat="server" Font-Size="19px" />

                                        </div>
                                        <div class="col-sm-2">
                                            <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>--%>
                    <%--  </div>--%>

                    <%-- class="panel-body" --%>
                    <div id="divcmphdr" runat="server" class="panel-body">



                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Label ID="lblName" Text="Name" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"
                                    Width="150px" OnTextChanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>

                            <div class="col-sm-3">
                                <asp:Label ID="lblCode" Text="Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="TxtSearchfield" CssClass="form-control" runat="server" Width="150px"></asp:TextBox>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-12">
                                <center>
                                    <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-sample"
                                        OnClick="btnsearch_Click" Text="Search" Width="87px" />

                                    <center />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">

                                <asp:Label ID="lblResult" runat="server" CssClass="control-label"
                                    ForeColor="Red" Text="Record Not Found." Visible="false"></asp:Label>
                                <asp:Label ID="lblLcu" runat="server" CssClass="control-label" Font-Bold="True" Text=""></asp:Label>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-5" style="overflow: scroll;">

                                <asp:GridView ID="GrdSearchfilter" runat="server" AllowPaging="True" CssClass="footable"
                                    AutoGenerateColumns="False"  HorizontalAlign="Center"
                                    Visible="false">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="3%" HeaderText="">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll0" runat="server" AutoPostBack="false" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect0" runat="server" AutoPostBack="true" />
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblcallHeader0" runat="server" CssClass="standardlabel" Text=""></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCounter0" runat="server" Text='<%# Eval("Number") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblcallType0" runat="server"
                                                    Text='<%# Eval("TypeDesc").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" CssClass="standardlabel" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Lead No" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcallReqCode0" runat="server"
                                                    Text='<%# Eval("TypeCode").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" CssClass="standardlabel"
                                                HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridViewRow" />
                                    <FooterStyle CssClass="GridViewFooter" />
                                    <PagerStyle CssClass="GridViewPager" />
                                    <HeaderStyle CssClass="GridViewHeader" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                    <PagerTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblpageindx0" runat="server" CssClass="standardlabelCRM"
                                                        Text="Page : "></asp:Label>
                                                </td>
                                                <td align="center" class="tablePagerData">
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnFirst2" runat="server" CommandArgument="First"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrFirst.gif"
                                                                    ToolTip="First Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnPrevious2" runat="server" CommandArgument="Prev"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrPrevious.gif"
                                                                    ToolTip="Previous Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:DropDownList ID="ddlPageSelectorR0" runat="server" AutoPostBack="true"
                                                                    CssClass="standardPagerDropdown"
                                                                    OnSelectedIndexChanged="ddlPageSelectorR_SelectedIndexChanged"
                                                                    ToolTip="Goto Page">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnNext2" runat="server" CommandArgument="Next"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrNext.gif"
                                                                    ToolTip="Next Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnLast2" runat="server" CommandArgument="Last"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrLast.gif"
                                                                    ToolTip="Last Page" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                </asp:GridView>
                                <asp:GridView ID="GrdSearch" runat="server" Width="100%" HorizontalAlign="Center" AutoGenerateColumns="False"
                                    OnPageIndexChanging="GrdSearch_PageIndexChanging" OnRowDataBound="GrdSearch_RowDataBound"
                                    OnRowCreated="GrdSearch_RowCreated">
                                    <Columns>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="3%">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="false" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_OnCheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblcallHeader" runat="server" CssClass="standardlabel" Text=""></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCounter" runat="server" Text='<%# Eval("Number") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblcallType" runat="server" Text='<%# Eval("TypeDesc").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="standardlabel" BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lead No" HeaderStyle-Width="10%" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcallReqCode" runat="server" Text='<%# Eval("TypeCode").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" CssClass="standardlabel" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <FooterStyle CssClass="GridViewFooter" />
                                    <PagerStyle CssClass="GridViewPager"></PagerStyle>
                                    <HeaderStyle CssClass="GridViewHeader"></HeaderStyle>
                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    <PagerTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="tablePagerDataSmall" align="left">
                                                    <asp:Label ID="lblpageindx" CssClass="standardlabelCRM" Text="Page : " runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="tablePagerData">
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ToolTip="First Page" Width="2px" Height="2px" CommandName="Page" CommandArgument="First"
                                                                    runat="server" ID="ImgbtnFirst1" ImageUrl="~/images/DeletegrideRecordImage.jpg" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ToolTip="Previous Page" CommandName="Page" CommandArgument="Prev"
                                                                    runat="server" ID="ImgbtnPrevious1" ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrPrevious.gif" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:DropDownList ToolTip="Goto Page" ID="ddlPageSelectorR" runat="server" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlPageSelectorR_SelectedIndexChanged" CssClass="standardPagerDropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ToolTip="Next Page" CommandName="Page" CommandArgument="Next" runat="server"
                                                                    ID="ImgbtnNext1" ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrNext.gif" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ToolTip="Last Page" CommandName="Page" CommandArgument="Last" runat="server"
                                                                    ID="ImgbtnLast1" ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrLast.gif" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                        </table>
                                    </PagerTemplate>

                                </asp:GridView>
                            </div>


                            <div class="col-sm-2">
                                <asp:ImageButton ID="btnsearch0" runat="server"
                                    OnClick="btnsearch0_Click" ImageUrl="~/images/arrow_right_double.png" Width="20px" />
                            </div>

                            <div class="col-sm-5" style="overflow: scroll;">
                                <asp:GridView ID="GrdSearchSelect" Width="100%"
                                    OnRowCommand="GridView1_RowCommand" CssClass="footable"
                                    runat="server"
                                    AutoGenerateColumns="False" HorizontalAlign="Center">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <EmptyDataTemplate>
                                        No data selected...
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:TemplateField HeaderStyle-Width="3%" HeaderText="">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblcallHeader1" runat="server" CssClass="standardlabel" Text=""></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>

                                                    <asp:ImageButton runat="server"
                                                        CommandName="MyButtonClick" CommandArgument='<%# Container.DataItemIndex %>' ID="btncheck" ImageUrl="~/images/dialog_cancel.png" OnClick="btncheck_Click" />
                                                    <%-- <asp:CheckBox ID="chkSelect1" OnCheckedChanged="chkSelect1_OnCheckedChanged" runat="server" AutoPostBack="true" 
                                                    />--%>
                                                </center>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblcallHeader12" runat="server" CssClass="standardlabel" Text="Selected Data"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCounter1" runat="server" Text='<%# Eval("Number") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblcallType1" runat="server"
                                                    Text='<%# Eval("TypeDesc").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" CssClass="standardlabel" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Lead No" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcallReqCode1" runat="server"
                                                    Text='<%# Eval("TypeCode").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BackColor="White" CssClass="standardlabel"
                                                HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridViewRow" />
                                    <FooterStyle CssClass="GridViewFooter" />
                                    <PagerStyle CssClass="GridViewPager" />
                                    <HeaderStyle CssClass="GridViewHeader" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                    <PagerTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" class="tablePager">
                                            <tr>
                                                <td align="left" class="tablePagerDataSmall" style="width: 35%">
                                                    <asp:Label ID="lblpageindx1" runat="server" CssClass="standardlabelCRM"
                                                        Text="Page : "></asp:Label>
                                                </td>
                                                <td align="center" class="tablePagerData" style="width: 98%">
                                                    <table cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnFirst3" runat="server" CommandArgument="First"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrFirst.gif"
                                                                    ToolTip="First Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnPrevious3" runat="server" CommandArgument="Prev"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrPrevious.gif"
                                                                    ToolTip="Previous Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:DropDownList ID="ddlPageSelectorR1" runat="server" AutoPostBack="true"
                                                                    CssClass="standardPagerDropdown"
                                                                    OnSelectedIndexChanged="ddlPageSelectorR_SelectedIndexChanged"
                                                                    ToolTip="Goto Page">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnNext3" runat="server" CommandArgument="Next"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrNext.gif"
                                                                    ToolTip="Next Page" />
                                                            </td>
                                                            <td>
                                                                <span style="padding-left: 5px;"></span>
                                                                <asp:ImageButton ID="ImgbtnLast3" runat="server" CommandArgument="Last"
                                                                    CommandName="Page"
                                                                    ImageUrl="~/Application/PSSNEW/assets/css/Images/ImgArrLast.gif"
                                                                    ToolTip="Last Page" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>

                        </div>


                        <div class="row">
                                                <div class="col-sm-12">
                                                    <center> 
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sample" Text="Select" OnClick="btnSubmit_Click" />
                                                  </center> 
                                                          <asp:HiddenField ID="hndDesc" runat="server" />
                                                    <asp:HiddenField ID="hndCode" runat="server" />
                                                    <asp:HiddenField ID="HdnMarkCnt" runat="server" />
                                                    <asp:HiddenField ID="HdnAgentCnt" runat="server" />
                                                    <asp:HiddenField ID="HdnHninCnt" runat="server" />

                                                </div>
                    </div>

                    </div>
                          <%--  </div>--%>

                     <%--   </div>--%>
                  

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <!-- KEEN THEME REGION START -->
    <script src="../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../KMI Styles/assets/plugins/bootbox/bootbox.min.js"></script>
    <script type="text/javascript" src="../../Scripts/JQuery/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../Scripts/JQuery/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../Scripts/JQuery/jquery.ui.button.js"></script>
    <!-- KEEN THEME REGION END -->


</body>
</html>

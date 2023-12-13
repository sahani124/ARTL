<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopBatch.aspx.cs" Inherits="Application_ISys_Saim_PopBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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

        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }

        function doCancel(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("btnbtch").click();
        }

        function expcolcall() {
            $("[src*=btnexp]").live("click", function () {
                $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("src", "../../../images/btncol.png");
            });
            $("[src*=btncol]").live("click", function () {
                $(this).attr("src", "../../../images/btnexp.png");
                $(this).closest("tr").next().remove();
            });
        }
    </script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">

        $("[src*=btnexp]").live("click", function () {

            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");
        });
        $("[src*=btncol]").live("click", function () {

            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .td, th
        {
            white-space: nowrap;
        }
        .dataTables_filter label
        {
            line-height: 32px;
        }
        
        .dataTable .row-details
        {
            margin-top: 3px;
            display: inline-block;
            cursor: pointer;
            width: 14px;
            height: 14px;
        }
        
        .dataTable .row-details.row-details-close
        {
            background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
        }
        
        .dataTable .row-details.row-details-open
        {
            background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px;
        }
        
        .dataTable .details
        {
            background-color: #eee;
        }
        
        .dataTable .details td, .dataTable .details th
        {
            padding: 4px;
            background: none;
            border: 0;
            border: 1px solid #ddd;
        }
        
        .dataTable .details tr:hover td, .dataTable .details tr:hover th
        {
            background: none;
        }
        
        .dataTable .details tr:nth-child(odd) td, .dataTable .details tr:nth-child(odd) th
        {
            background-color: #eee;
        }
        
        .dataTable .details tr:nth-child(even) td, .dataTable .details tr:nth-child(even) th
        {
            background-color: #eee;
        }
        
        .dataTable > thead > tr > th.sorting, .dataTable > thead > tr > th.sorting_asc, .dataTable > thead > tr > th.sorting_desc
        {
            padding-right: 18px;
        }
        
        .dataTable .table-checkbox
        {
            width: 8px !important;
        }
        
        @media (max-width: 768px)
        {
            .dataTables_wrapper .dataTables_length .form-control, .dataTables_wrapper .dataTables_filter .form-control
            {
                display: inline-block;
            }
        
            .dataTables_wrapper .dataTables_info
            {
                top: 17px;
            }
        
            .dataTables_wrapper .dataTables_paginate
            {
                margin-top: -15px;
            }
        }
        
        @media (max-width: 480px)
        {
            .dataTables_wrapper .dataTables_filter .form-control
            {
                width: 175px !important;
            }
        
            .dataTables_wrapper .dataTables_paginate
            {
                float: left;
                margin-top: 20px;
            }
        }
        
        .dataTables_processing
        {
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
        
        .dataTables_processing span
        {
            line-height: 15px;
            vertical-align: middle;
        }
        
        .dataTables_empty
        {
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="2000">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="divcmphdrcollapse" runat="server" style="width: 90%;" class="panel panel-success">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                <asp:Label ID="lblhdr" Text="Batch Job Details" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 100%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRSKCode" Text="Rule Set Key" runat="server" CssClass="control-label" />
                                <asp:Button ID="Button1" runat="server" Width="100px" CssClass="btn btn-primary" Visible="false"
                                    Text="Download" OnClick="Button1_Click" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblRSKCodeVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRSKDesc" Text="Rule Set Key Description" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblRSKDescVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div id="divBtchGrd" runat="server" style="width: 100%; border: none; padding: 10px;"
                            class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgBtchRSK" runat="server" AutoGenerateColumns="false" Width="100%"
                                        OnRowDataBound="dgBtchRSK_RowDataBound" PageSize="10" AllowSorting="false" AllowPaging="true"
                                        CssClass="footable">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                                                <asp:Label ID="lblKPICODE" Text="KPI Code" runat="server" CssClass="control-label" />
                                                            </td>
                                                            <td style="width: 30%;" class="col-md-7">
                                                                <asp:Label ID="lblKPICodeDsc" Text='<%# Bind("KPI_DESC") %>' runat="server" CssClass="form-control-static new_text_new" />
                                                                <asp:Label ID="lblRwrdCd" Text='<%# Bind("RWRD_CODE") %>' runat="server" CssClass="form-control-static new_text_new" />
                                                                <asp:HiddenField ID="hdnRwrdCd" Value='<%# Bind("RWRD_CODE") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnRwrdRlCd" Value='<%# Bind("RWD_RUL_CODE") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnKPICode" Value='<%# Bind("KPI_CODE") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnRulCode" Value='<%# Bind("RULE_CODE") %>' runat="server" />
                                                            </td>
                                                            <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                                                <asp:Label ID="lblKPIType" Text="KPI Type" runat="server" CssClass="control-label" />
                                                            </td>
                                                            <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                                                <asp:Label ID="lblRwrdCdDsc" Text='<%# Bind("RWRD_DESC") %>' runat="server" CssClass="form-control-static new_text_new" />
                                                                <asp:Label ID="lblKPITypeDsc" Text='<%# Bind("KPI_ORG_DESC") %>' runat="server" CssClass="form-control-static new_text_new" />
                                                                <asp:HiddenField ID="hdnKPIType" Value='<%# Bind("KPI_ORIGIN") %>' runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="white-space: nowrap;" class="form-body align col-md-6" colspan="4">
                                                                <%--<div id="divChild" runat="server" style="display: block; margin: 0px 0 !important;
                                                                    width: 100%;" class="table-scrollable">--%>
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="dgSbBtch" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                            PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                                            OnRowDataBound="dgSbBtch_RowDataBound">
                                                                            <HeaderStyle ForeColor="Black" />
                                                                            <RowStyle />
                                                                            <PagerStyle CssClass="disablepage" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Step">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStep" runat="server" Text='<%# Bind("STEP")%>'></asp:Label>
                                                                                        <asp:HiddenField ID="hdnStpCd" runat="server" Value='<%# Bind("STEP_CODE")%>'></asp:HiddenField>
                                                                                        <asp:HiddenField ID="hdnRlCodeSb" Value='<%# Bind("RULE_CODE") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hdnKPICodeSb" Value='<%# Bind("KPI_CODE") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hdnKPIOrgn" Value='<%# Bind("KPI_ORIGIN") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Step Description">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStepDsc" runat="server" Text='<%# Bind("STEP_DESC")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:UpdatePanel runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:FileUpload ID="fUpld" runat="server" Visible="false" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <ajax:PostBackTrigger ControlID="lnkStart" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                        <asp:LinkButton ID="lnkStart" Text='<%# Bind("STATUS") %>' runat="server" OnClick="lnkStart_Click" />
                                                                                        <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hdnStatus" Value='<%# Bind("RUN_STATUS") %>' runat="server" />
                                                                                        <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" Visible="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <%--</div>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="div1" runat="server" style="width: 100%; border: none; padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgBaseCatg" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable" OnRowDataBound="dgBaseCatg_RowDataBound">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Step">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStep" runat="server" Text='<%# Bind("STEP")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnStpCd" runat="server" Value='<%# Bind("STEP_CODE")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnRlCodeSb" Value='<%# Bind("RULE_CODE") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnKPICodeSb" Value='<%# Bind("KPI_CODE") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnKPIOrgn" Value='<%# Bind("KPI_ORIGIN") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Step Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStepDsc" runat="server" Text='<%# Bind("STEP_DESC")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBsStart" Text='<%# Bind("STATUS") %>' runat="server" OnClick="lnkBsStart_Click" />
                                                    <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnStatus" Value='<%# Bind("RUN_STATUS") %>' runat="server" />
                                                    <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" Visible="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnCncl" Text="BACK" runat="server" CssClass="btn btn-primary"
                                            OnClick="btnCncl_Click">
                                             <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color:White"></span> Back
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnDocType" runat="server" />
            <asp:HiddenField ID="hdnBatchID" runat="server" />
            <asp:HiddenField ID="hdnCntstCode" runat="server" />
            <asp:HiddenField ID="hdnRulStKy" runat="server" />
            <asp:HiddenField ID="hdnRulStKyDsc" runat="server" />
            <asp:HiddenField ID="hdncmptflg" runat="server" />
            <asp:HiddenField ID="hdnRulTyp" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

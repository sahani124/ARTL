<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="BtchJob.aspx.cs" Inherits="Application_ISys_Saim_BtchJob" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- commented by ajay sawant
     <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../SaimStyle/KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../SaimStyle/KMI Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../SaimStyle/KMI Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../../../SaimStyle/KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <%-- commented by ajay sawant
    <link href="../../../SaimStyle/KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../SaimStyle/KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../SaimStyle/KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <%-- commented by ajay sawant
     <link href="../../../SaimStyle/KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />--%>
    <%-- <link href="../../../SaimStyle/KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <%-- commented by ajay sawant
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../SaimStyle/KMI Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../SaimStyle/KMI Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../SaimStyle/KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

    <link href="../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />

    <%--  added by ajay sawant --%>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        debugger;
        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");
        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <script type="text/javascript">

        function funRunStep(id) {
            debugger;


            document.getElementById(id).style.display = "none";

            if (id == "ctl00_ContentPlaceHolder1_gvKPI_ctl02_lnkRunKPI") {


                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl02_imgStatus").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl02_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl02_lblStatus").value = "Awaiting Execution"


            }
            if (id == "ctl00_ContentPlaceHolder1_gvKPI_ctl03_lnkRunKPI") {

                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl03_imgStatus").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl03_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl03_lblStatus").value = "Awaiting Execution"
            }
            if (id == "ctl00_ContentPlaceHolder1_gvKPI_ctl04_lnkRunKPI") {
                ocument.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl04_imgStatus").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl04_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl04_lblStatus").value = "Awaiting Execution"
            }

            if (id == "ctl00_ContentPlaceHolder1_gvKPI_ctl05_lnkRunKPI") {
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl05_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_gvKPI_ctl05_lblStatus").value = "Awaiting Execution"
            }


        }

        function funStartStep(id) {
            debugger;

            //            alert(id);
            //  alert("NewChanges apply")

            document.getElementById(id).style.display = "none";

            if (id == "ctl00_ContentPlaceHolder1_dgSbBtch_ctl02_lnkStart") {

                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl02_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl02_lblStatus").value = "Awaiting Execution"


            }
            if (id == "ctl00_ContentPlaceHolder1_dgSbBtch_ctl03_lnkStart") {
                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl03_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl03_lblStatus").value = "Awaiting Execution"
            }
            if (id == "ctl00_ContentPlaceHolder1_dgSbBtch_ctl04_lnkStart") {
                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl04_imgStatus").src = "../../../images/spinner.gif"
                document.getElementById("ctl00_ContentPlaceHolder1_dgSbBtch_ctl04_lblStatus").value = "Awaiting Execution"
            }


        }
        $(function () {
            debugger;

            $("#<%= txtStrTm.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtEndTm.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });

        function ChkFinalClose() {
            debugger;
            var chkfinal = document.getElementById("ctl00_ContentPlaceHolder1_ChkFinalClose");
            var btnfinal = document.getElementById("ctl00_ContentPlaceHolder1_lbtFinalClose");
            if (chkfinal.checked) {
                btnfinal.disabled = false;
            } else {
                btnfinal.disabled = true;
            }

        }

        //function enableOrdisable() {
        //    debugger;
        //    if (document.getElementById('ctl00_ContentPlaceHolder1_ChkFinalClose').checked == true) {
        //        alert(document.getElementById('ctl00_ContentPlaceHolder1_ChkFinalClose').checked);
        //        document.getElementById('ctl00_ContentPlaceHolder1_lbtFinalClose').disabled = false;
        //        alert(document.getElementById('ctl00_ContentPlaceHolder1_lbtFinalClose').disabled);
        //    }
        //    else {
        //        document.getElementById('ctl00_ContentPlaceHolder1_lbtFinalClose').disabled = true;
        //    }
        //}


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
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }


        function ShowDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({
                height: 'toggle'
            });
        }

        function HideDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({ right: '25px' });
        }

        function funPopup(cmpcode, cntstcd, rskey, cyccd, cycdesc, rskeydesc, cmptflag, rultyp) {
            /////alert("ejkcbqc");
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmPop").src = "PopBatch.aspx?CmpCode=" + cmpcode
                + "&cntstcd=" + cntstcd + "&rskey=" + rskey + "&cyccd=" + cyccd + "&cycdesc=" + cycdesc + "&rskeydesc=" + rskeydesc + "&cmptflag="
                + cmptflag + "&rultyp=" + rultyp + "&flag=V&mdlpopup=mdlPopBID";
        }


        function funPopupInterim(cmpcode, cntstcd, rskey, cyccd) {
            debugger;

            /////alert("ejkcbqc");
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmPop").src = "InterimAccumStp.aspx?CmpCode=" + cmpcode
                + "&CNTSTNT_CODE=" + cntstcd + "&RuleSetKy=" + rskey + "&CycCode=" + cyccd + "&mdlpopup=mdlPopBID";
        }

        function funPopupInterimtemp() {
            debugger;

            /////alert("ejkcbqc");
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmPop").src = "InterimAccumStp.aspx?mdlpopup=mdlPopBID";
        }

        function funPopupDataSynchHybrid(cmpcode, cnstCode, RuleSet, AccCycle) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBIDHybrid").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBatchHybrid.aspx?CmpCode=" + cmpcode + "&cnstCode=" + cnstCode + "&RuleSet=" + RuleSet + "&AccCycle=" + AccCycle
                + "&mdlpopup=mdlPopBIDHybrid";
        }

        function funPopRpt(cmpcode, cyccd) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlPopBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmPop").src = "PopBatch.aspx?CmpCode=" + cmpcode + "&cyccd=" + cyccd
                + "&flag=Rpt&mdlpopup=mdlPopBID";
        }
        function openInWindow(CycCode, mode, CMPNSTN_CODE) {
            debugger;
            window.open("../../../CycleDetails1.aspx?CYCLE_CODE=" + CycCode + "&CMPNSTN_CODE=" + CMPNSTN_CODE + "&Mode=" + mode + "", "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=40,left=70,bottom=80,width=1200,height=500");
        }
    </script>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/

        .new_text_new {
            color: #066de7;
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

        .disablepage {
            display: none;
        }

        /*.box
        {
            background-color: #efefef;
            padding-left: 5px;
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

        /*.dataTable .details
        {
            background-color: #eee;
        }
        
        .dataTable .details td, .dataTable .details th
        {
            padding: 4px;
            background: none;
            border: 0;
            border: 1px solid #ddd;
        }*/

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
    </style>
    <center>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="2000">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                       <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                        <asp:Label ID="lblhdr" Text="Compensation Details" Style="font-size:19px;" runat="server" />
                    </div>
                    <div class="col-sm-2">
                       <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%; white-space: nowrap; text-align: left;"
                class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                        <%--col-md-5--%>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="1"></asp:Label>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="2"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompDesc2Val" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccCycVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccYr" Text="Accumulation Year" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccYrVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompTypVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccCycle" Text="Accrual Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblReleaseCycle" Text="Release Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblReleaseCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label7" Text="Business Year" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblBusYr" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label8" Text="Version" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblVersion" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblEffDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblEffDtToVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divPrevHdr" runat="server" style="width: 97%;" class="panel">
                    <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divPrev','Img7');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblPrev" Text="Previous Batch Job Summary" runat="server"  />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divPrev" runat="server" style="width: 96%; white-space: nowrap; text-align: left;"
                        class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPrvCycDt1" Text="Cycle Date From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="txtPrvCycDt1" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPrvCycDt2" Text="Cycle Date To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="txtPrvCycDt2" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;display:none" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRunNo" Text="RunNo" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="txtRunNo" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStat" Text="Status" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="txtRunStat" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divprevdtlshdr" runat="server" style="width: 97%;" class="panel" visible="false">
                    <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprevdtls','myImg1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label2" Text="Previous Batch Job Details" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divprevdtls" runat="server" style="width: 100%;">
                        <div id="div2" runat="server" style="width: 100%; border: none; padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgBatchPrev" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Compensation Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpCodeDsc" Text='<%# Bind("CMP_CODE_DESC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCmpCodeDsc" Value='<%# Bind("CMPNSTN_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contestant Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCntstCodeDsc" Text='<%# Bind("CNT_CODE_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCntstCode" Value='<%# Bind("CNTSTNT_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Set Key Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRlStKyDsc" Text='<%# Bind("RULE_ST_KY_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnRlStKy" Value='<%# Bind("RULE_SET_KEY") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Computation Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpFlag" Text='<%# Bind("COMPUTE_FLAG_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCmpFlag" Value='<%# Bind("COMPUTE_FLAG") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewPrev" Text="View" runat="server" OnClick="lnkViewPrev_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divCurHdr" runat="server" style="width: 97%;" class="panel">
                    <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCur','Img3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblCurRnhdr" Text="Current Batch Job Summary" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="Img3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divCur" runat="server" style="width: 96%; white-space: nowrap; text-align: left;"
                        class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label Text="Cycle Date From" ID="lblStrTm" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updStrTm" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtStrTm" runat="server" CssClass="form-control" AutoPostBack="true"
                                            placeholder="Cycle Date From" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEndTm" Text="Cycle Date To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtEndTm" runat="server" CssClass="form-control" placeholder="Cycle Date To" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;display:none">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbCurRnNo" Text="RunNo" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lbCurRnNoVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbCurRnStat" Text="Run Status" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lbCurRnStVal" runat="server" CssClass="form-control-static new_text_new" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div class="row" style="margin-top: 12px;">
            <div class="col-sm-12" >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnStart" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClick="btnStart_Click">
                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Start
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCncl" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClick="btnCncl_Click">
                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <%--<asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
                <div id="divBtchHdr" runat="server" style="width: 97%;" class="panel"
                    visible="false">
                    <div id="Div11" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divBtch','myImg3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label1" Text="Current Batch Job Details" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <br />

                     <div id="divBtch2" runat="server" style="width: 96%;" visible="true" class="panel-body">
                        <div id="divBtchKPI" runat="server" style="width: 100%; border: none;">
                           
                                 <asp:GridView ID="gvKPI" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable" OnRowDataBound="gvKPI_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="KPI Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKPIcode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnKPIcode" runat="server" Value='<%# Bind("KPI_CODE")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="KPI  Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKPIDsc" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                <ItemTemplate>
                                                       <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                         <ContentTemplate>
                                                             <asp:HiddenField ID="hdnHybrid" Value='<%# Bind("KPI_ORIGIN") %>' runat="server" />

                                                             <asp:LinkButton ID="lnkUpload" Text='Upload Data' visible="false" runat="server" CssClass="btn btn-primary" OnClick="lnkUpload_Click" /> 
                                                         <%-- OnClientClick="funRunStep(this.id)" --%>
                                                            <asp:LinkButton ID="lnkRunKPI" Text='RUN' runat="server" CssClass="btn btn-primary" OnClick="lnkRunKPI_Click" OnClientClick="funRunStep(this.id)"
                                                         
                                                                /> 
                                                            <asp:HiddenField ID="hdnStaus" Value='<%# Bind("RUN_STATUS") %>' runat="server" />
                                                       
                                                             <asp:Label ID="lblStatus" Text="" runat="server"  Style="text-decoration-color:green" />
                                                             <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px"  />
                                               

                                                     
                                                     </ContentTemplate>
                                               </asp:UpdatePanel>
                                                        </ItemTemplate>
                                            </asp:TemplateField>
                                  


                                            
                               
                                  
                                             <asp:TemplateField HeaderText="Action">
                                                 <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                  

                                             <asp:LinkButton ID="lnkDownload" Text='Download Achievement Data'  runat="server" CssClass="btn btn-primary" OnClick="lnkDownload_Click"   />
                                                    
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                               
                     
                            </div>
                      </div>




                    <div id="divBtch" runat="server" style="width: 96%;" visible="false" class="panel-body">
                        <div id="div1" runat="server" style="width: 100%; border: none;">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgSbBtch" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable" OnRowDataBound="dgSbBtch_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Step">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStep" runat="server" Text='<%# Bind("STEP")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnStpCd" runat="server" Value='<%# Bind("STEP_CODE")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Step Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStepDsc" runat="server" Text='<%# Bind("STEP_DESC")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkStart" Text='<%# Bind("STATUS") %>' runat="server" CssClass="btn btn-primary" OnClick="lnkStart_Click" OnClientClick="funStartStep(this.id)"  />
                                                    <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnStatus" Value='<%# Bind("RUN_STATUS") %>' runat="server" />
                                                    <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px"  />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="divBtchGrd" runat="server" style="width: 100%; border: none; " class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgBatch" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="30" AllowSorting="false" AllowPaging="true" CssClass="footable" OnRowDataBound="dgBatch_RowDataBound">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                    <div id="divChild" runat="server" style="display: none; margin: 0px 0 !important;"
                                                        class="table-scrollable">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="dgSubRSK" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="30" AAllowPaging="true" CssClass="dataTable details" DataKeyNames="RULE_SET_KEY">
                                                                    <%--llowSorting="True" --%>
                                                                    <HeaderStyle ForeColor="Black" />
                                                                    <RowStyle />
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="Label2" Text="No rule types have been defined" ForeColor="Red" CssClass="control-label"
                                                                            runat="server" />
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Rule Set Key Description" SortExpression="RULE_SET_KEY"
                                                                            HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRSK" runat="server" Text='<%# Bind("RULE_ST_KY_DSC")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnRSK" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                                                <asp:HiddenField ID="hdnCmpCodeDsc" Value='<%# Bind("CMPNSTN_CODE") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnCntstCode" Value='<%# Bind("CNTSTNT_CODE") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnCmpFlag" Value='<%# Bind("COMPUTE_FLAG") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rule Type" SortExpression="RULE_TYPE" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRulType" runat="server" Text='<%# Bind("RULE_TYPE_DESC")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnRulType" runat="server" Value='<%# Bind("RULE_TYPE")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" SortExpression="RUN_STATUS" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("RUN_STATUS")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#c1c1c1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkViewRSK" Text="View" runat="server" OnClick="lnkViewRSK_Click" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Compensation Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpCodeDsc" Text='<%# Bind("CMP_CODE_DESC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCmpCodeDsc" Value='<%# Bind("CMPNSTN_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contestant Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCntstCodeDsc" Text='<%# Bind("CNT_CODE_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCntstCode" Value='<%# Bind("CNTSTNT_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Set Key Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRlStKyDsc" Text='<%# Bind("RULE_ST_KY_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnRlStKy" Value='<%# Bind("RULE_SET_KEY") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Process Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpFlag" Text='<%# Bind("COMPUTE_FLAG_DSC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCmpFlag" Value='<%# Bind("COMPUTE_FLAG") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkView" Text="View" runat="server" OnClick="lnkView_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="divTax" runat="server" style="width: 100%; display:none" visible="false">
                            <div style="width: 100%; margin-left: 0px; margin-right: 0px;" class="panel panel-success">
                                <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','Img5');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                            <asp:Label ID="Label3" Text="Tax and TDS Details" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="Img5" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                                padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="div3" runat="server" style="width: 100%; border: none; padding: 10px;" class="table-scrollable">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgTax" runat="server" AutoGenerateColumns="false" Width="100%"
                                                PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable">
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpnstn" runat="server" Text='<%# Bind("CMPNSTN_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCmpnstn" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>'>
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contestant Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCntst" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCntst" runat="server" Value='<%# Bind("CNTSTN_CODE")%>'>
                                                            </asp:HiddenField>
                                                            <asp:HiddenField ID="hdnMemtype" runat="server" Value='<%# Bind("MEMTYPE_CD")%>'>
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Process Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpFlg" runat="server" Text='<%# Bind("COMP_FLAG_DSC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCmpFlg" runat="server" Value='<%# Bind("COMPUTE_FLAG")%>'>
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" Text='<%# Bind("STATUS") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnStatus" Value='<%# Bind("RUN_STATUS") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkViewTax" Text="View" runat="server" OnClick="lnkViewTax_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
    <div>

    <br /><br />
                   
                </div>



                <div style="display:none">
                        <div id="divSum" runat="server" style="width: 100%;display:none" visible="false" >
                            <div style="width: 100%; margin-left: 0px; margin-right: 0px;" class="panel panel-success">
                                <div id="Div13" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div8','myImg6');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                            <asp:Label ID="Label5" Text="Summary Reports" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="myImg6" class="glyphicon glyphicon-collapse-down" style="float: right;
                                                color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="div8" runat="server" style="width: 100%; border: none; padding: 10px;" class="table-scrollable">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:GridView ID="dgSummRpt" runat="server" AutoGenerateColumns="false" Width="100%"
                                                PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable">
                                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpnstn" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCmpnstn" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>'>
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contestant Description" SortExpression="CNTSTNT_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCntstn" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCntstn" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>'>
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkViewRpt" Text="View" runat="server" OnClick="lnkViewRpt_Click" />
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
                            </div>
                        </div>

                        </div>
                    </div>
                </div>


         <div  id="divView" style="width: 97%; margin-left: 0px; margin-right: 0px;" class="panel" visible="false">
                        <div id="divLinks" runat="server" visible="false" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div4','myImg7');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left;font-size:19px;">
                                    <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                    <asp:Label ID="Label6" Text="View" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="myImg7" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                                </div>
                            </div>
                        </div>
                        <div id="div4" runat="server" visible="false" style="width: 96%; white-space: nowrap; text-align: left;"
                            class="panel-body">
                             <div class="row" style="padding-left:2%;padding-right:2%">
                            <center>
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>
                                                Description
                                            </th>
                                            <th>
                                                Action
                                            </th>
                                            <%-- <th style="text-align: center">
                                                Email
                                            </th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                PR register data as per cycle
                                            </td>
                                            <td>
                                                <a id="lnkPR" runat="server" href="#">View</a>
                                            </td>
                                            <%-- <td style="text-align: center">
                                                john@example.com
                                            </td>--%>
                                        </tr>
                                     <%--    <tr>
                                            <td>
                                                Consider policy for commision calculation for current cycle
                                            </td>
                                            <td>
                                                <a id="lnkCommission" runat="server" href="#">View</a>
                                            </td>--%>
                                            <%-- <td style="text-align: center">
                                                mary@example.com
                                            </td>--%>
                                      <%--    </tr>--%>
                                        <tr>
                                            <td>
                                                Weightage calculation data
                                            </td>
                                            <td>
                                                <a id="lnkWeight" runat="server" href="#">View</a>
                                            </td>
                                            <%-- <td style="text-align: center">
                                                july@example.com
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td>
                                                Total achievement member wise
                                            </td>
                                            <td>
                                                <a id="lnkAchieve" runat="server" href="#">View</a>
                                            </td>
                                            <%-- <td style="text-align: center">
                                                july@example.com
                                            </td>--%>
                                        </tr>

                                         <tr>
                                            <td>
                                                Final commission member wise
                                            </td>
                                            <td>
                                                <a id="lnkCommission" runat="server" href="#">View</a>
                                            </td>
                                            <%-- <td style="text-align: center">
                                                july@example.com
                                            </td>--%>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                        </div>
                    </div>
        </div>

      
            <div class="row" style="margin-top: 12px;">
            <div class="col-sm-12" >
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkComputeReward" runat="server" Width="150px" CssClass="btn btn-sample"
                            OnClick="lnkComputeReward_Click">
                                <span class="glyphicon glyphicon-credit-card" style="color: White;"></span> Compute Reward
                        </asp:LinkButton>
                        <%--<asp:LinkButton ID="LinkButton2" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClick="btnCncl_Click">
                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
       

            </div>
        <%--    </ContentTemplate>
        </asp:UpdatePanel>--%>



         <div id="div18" runat="server" style="width: 97%;" class="panel"
                    visible="true">
                    <div id="Div19" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div15','myImg13');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label9" Text="Close Accrual Cycle" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg13" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <br />
           
                    <div id="div15" runat="server" style="width: 96%;" visible="true" class="panel-body">
                        <div id="div16" runat="server" style="width: 100%; border: none;">
                            <div class="row">
                                <div class="col-sm-6" style="text-align: left;padding-left: 3%;" >
                                    
                                   <asp:Label ID="lblVerifyData" Text="Please verify data before accrual cycle closed" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
 
                           
                                 </div>
                            <div class="col-sm-6" style="text-align: center">
                                     <asp:LinkButton ID="LbtVerifyData"  runat="server"    Style="float: left;" Width="109px" CssClass="btn btn-sample" 
                            OnClick="LbtVerifyData_Click">
                                <span class="glyphicon glyphicon-export" style="color: White;"></span> Verify Data
                                </asp:LinkButton>
                           
                                          
                            </div>
                           </div>
                            <div class="row">
                                <asp:UpdatePanel runat="server">
                                    <triggers>
                                        <asp:AsyncPostBackTrigger ControlId="ChkFinalClose" EventName="CheckedChanged"/>
                                        </triggers>
                                    <ContentTemplate>
                                <div class="col-sm-6" style="text-align: left;display:flex;padding-left: 4%;" >
                                <asp:CheckBox ID="ChkFinalClose" runat="server" CssClass="checkbox"  Checked="false" OnCheckedChanged="ChkFinalClose_CheckedChanged"  AutoPostBack="true" />
                          <asp:Label ID="LblFinalClose" Text="Close Accrual Cycle" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
                               </div>
                                 <div class="col-sm-6" style="text-align: center">
                                       <asp:LinkButton ID="lbtFinalClose"  runat="server" Enabled="false"  Style="float: left;" Width="109px" CssClass="btn btn-sample" 
                            OnClick="lbtFinalClose_Click">
                                <span class="glyphicon glyphicon-save" style="color: White;"></span> Save
                        </asp:LinkButton>
                                     </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                 </div>

                        </div>
                   </div>
              
                        
             </div>

         <%--added by ajay sawant 6/6/2018--%>
         <div id="divInterim" runat="server" style="width: 97%;display:none;" class="panel" 
                    visible="true">
                    <div id="Div21" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div15','myImg14');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label11" Text="Interim Accumulation" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg15" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="div22" runat="server" style="width: 96%;" visible="true" class="panel-body">
                        <div id="div23" runat="server" style="width: 100%; border: none;">
                            <%--<div class="row">
                                <div class="col-sm-8" style="text-align: left;display:flex;padding-left: 3%;" >
                                
                                     <asp:Label ID="Label13" Text="Please verify data before  accumulation cycle closed" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
                                 </div>
                        
                            <div class="col-sm-4" style="text-align: left;">
                                 <asp:LinkButton ID="LinkButton1"  runat="server"  Style="float: left" Width="109px"  CssClass="btn btn-sample" 
                            OnClick="LbtAccVerifyData_Click">
                                <span class="glyphicon glyphicon-save" style="color: White;"></span> Verify Data
                                </asp:LinkButton>

                          
                                
                            </div>
                            </div>--%>


                            <div class="row">
                                <asp:UpdatePanel runat="server">
                                     <triggers>
                                        <asp:AsyncPostBackTrigger ControlId="chkAccumulationClose" EventName="CheckedChanged"/>
                                        </triggers>
                                    <ContentTemplate>

                                
                                 <div class="col-sm-8" style="text-align: left;display:flex;padding-left: 4%;" >
                    <asp:CheckBox ID="chkInterim" runat="server" CssClass="checkbox"  Checked="false" OnCheckedChanged="chkInterim_CheckedChanged" AutoPostBack="True" />
 
                                  <asp:Label ID="Label14" Text="For interim accumulation close" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
                           
                                     </div>
                                 <div class="col-sm-4" style="text-align: left;">
                                       <asp:LinkButton ID="lnkInterimSet"  runat="server"  enabled="false"  Style="float: left;" Width="109px" CssClass="btn btn-sample" 
                            OnClick="lnkInterimSet_Click">
                                <span class="glyphicon glyphicon-open" style="color: White;"></span> Set
                        </asp:LinkButton>
                                     </div>
                                        </ContentTemplate>
                                      </asp:UpdatePanel>
                                        
                                </div>


                        </div>
                   </div>

             </div>


        <%--added by ajay sawant 6/6/2018--%>
         <div id="divAccumulation" runat="server" style="width: 97%;" class="panel"
                    visible="true">
                    <div id="Div14" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div15','myImg14');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px;">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblFinalPay" Text="Close Accumulation Cycle For Final Payment" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg14" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="div17" runat="server" style="width: 96%;" visible="true" class="panel-body">
                        <div id="div20" runat="server" style="width: 100%; border: none;">
                            <div class="row">
                                <div class="col-sm-8" style="text-align: left;display:flex;padding-left: 3%;" >
                                
                                     <asp:Label ID="lblAccVerify" Text="Please verify data before  accumulation cycle closed" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
                                 </div>
                        
                            <div class="col-sm-4" style="text-align: left;">
                                 <asp:LinkButton ID="LbtAccVerifyData"  runat="server"  Style="float: left" Width="109px"  CssClass="btn btn-sample" 
                            OnClick="LbtAccVerifyData_Click">
                                <span class="glyphicon glyphicon-save" style="color: White;"></span> Verify Data
                                </asp:LinkButton>

                          
                                
                            </div>
                            </div>


                            <div class="row">
                                <asp:UpdatePanel runat="server">
                                     <triggers>
                                        <asp:AsyncPostBackTrigger ControlId="chkAccumulationClose" EventName="CheckedChanged"/>
                                        </triggers>
                                    <ContentTemplate>

                                
                                 <div class="col-sm-8" style="text-align: left;display:flex;padding-left: 4%;" >
    <asp:CheckBox ID="chkAccumulationClose" runat="server" CssClass="checkbox"  Checked="false" OnCheckedChanged="chkAccumulationClose_CheckedChanged" AutoPostBack="True" />
 
                                  <asp:Label ID="Label12" Text="All accrual cycle run have been completed successfully and hence close the accumulation cycle" runat="server" CssClass="control-label" Style="margin-top: 12px;" />
                           
                                     </div>
                                 <div class="col-sm-4" style="text-align: left;">
                                       <asp:LinkButton ID="lnkAccumulationClose"  runat="server"  enabled="false"  Style="float: left;" Width="109px" CssClass="btn btn-sample" 
                            OnClick="lnkAccumulationClose_Click">
                                <span class="glyphicon glyphicon-save" style="color: White;"></span> Save
                        </asp:LinkButton>
                                     </div>
                                        </ContentTemplate>
                                      </asp:UpdatePanel>
                                        
                                </div>


                        </div>
                   </div>



             </div>
        <asp:GridView ID="dgAccrualExport" runat="server" AutoGenerateColumns="true" Width="100%"
                                          visible="true">
                  </asp:GridView>
        <asp:GridView ID="dgAccumulationExport" runat="server" AutoGenerateColumns="true" Width="100%"
                                          visible="true">
                  </asp:GridView>
    </center>
    <asp:Panel runat="server" Height="494px" Width="1020px" ID="pnl" display="none" Style="text-align: center; padding: 10px;"
        CssClass="panel panel-success">
        <iframe runat="server" id="ifrmPop" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label4" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlPop" BehaviorID="mdlPopBID"
        DropShadow="false" TargetControlID="Label4" PopupControlID="pnl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnChn" runat="server" />
            <asp:HiddenField ID="hdnSbChn" runat="server" />
            <asp:HiddenField ID="hdnMemType" runat="server" />
            <asp:HiddenField ID="hdnVersnFrm1" runat="server" />
            <asp:HiddenField ID="hdnVrsnTo1" runat="server" />
            <asp:HiddenField ID="hdnCycCode" runat="server" />
            <asp:HiddenField ID="hdnCycDesc" runat="server" />
            <asp:HiddenField ID="hdnCycCodePrv" runat="server" />
            <asp:HiddenField ID="hdnCycDescPrv" runat="server" />
            <asp:Button ID="btnbtch" runat="server" Width="100px" ClientIDMode="Static" Style="display: none;"
                OnClick="btnbtch_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>



    <asp:Panel runat="server" Height="494px" Width="1020px" ID="Panel1" display="none" Style="text-align: center; padding: 10px;"
        CssClass="panel panel-success">
        <iframe runat="server" id="Iframe1" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>


    </asp:Panel>
    <asp:Label runat="server" ID="Label10" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>



</asp:Content>

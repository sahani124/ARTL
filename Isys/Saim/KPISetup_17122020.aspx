<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" EnableViewState="true"
    CodeFile="KPISetup.aspx.cs" Inherits="Application_ISys_Saim_KPISetup" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

    <%--<link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CBFRMCommon.js"></script>


    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../assets/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script type="text/javascript">

        function checkDateIsGreaterThanToday(fromDay, toDay) {

            var fromArr = fromDay.split('/');
            var toArr = toDay.split('/');

            if (fromArr[2] == toArr[2]) {
                if (fromArr[1] < toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if (fromArr[1] == toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            else if (fromArr[2] < toArr[2]) {

                return true;

            }
            else {
                return false;
            }
        }

        function checkDate() {
            var EffDate = $('#<%= txtEfDate.ClientID  %>').val();
            var CeDate = $('#<%= txtCeDate.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (EffDate != "" && CeDate != "") {
                if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                    alert("Please enter the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtCeDate").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function PopulateCalender() {
            //minDate:new Date()
            $("#<%= txtEfDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        $(document).ready(function () {
            debugger;
            $("#<%= txtEfDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= txtCeDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        })

        function populateGridCalender(obj) {
            $(obj).datepicker({
                dateFormat: 'dd/mm/yy'
                , changeMonth: true,
                changeYear: true
            });
        }

        function PopulateCalender1() {
            $("#<%= txtCeDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function ValidateDefScpInp() {
            var strcontent = "ctl00_ContentPlaceHolder1_";
            debugger;
            if (!$("#<%= lstChannel.ClientID %>").val()) {
                alert("Please select channel");
                return false;
            }

            if ($("#<%= lstSubChnl.ClientID %>").val().length == 0) {
                alert("Please select sub channel");
                return false;
            }

            if ($("#<%= lstMemType.ClientID %>").val().length == 0) {
                alert("Please select member type");
                return false;
            }

            //if (document.getElementById(strcontent + "ddlChannel") != null) {
            //    if (document.getElementById(strcontent + "ddlChannel").value == "") {
            //        alert("Please select channel");
            //        document.getElementById(strcontent + "ddlChannel").focus();
            //        return false;
            //    }
            //}
            //if (document.getElementById(strcontent + "ddlSubChannel") != null) {
            //    if (document.getElementById(strcontent + "ddlSubChannel").value == "") {
            //        alert("Please select sub channel");
            //        document.getElementById(strcontent + "ddlSubChannel").focus();
            //        return false;
            //    }
            //}
            //if (document.getElementById(strcontent + "ddlMemType") != null) {
            //    if (document.getElementById(strcontent + "ddlMemType").value == "") {
            //        alert("Please select member type");
            //        document.getElementById(strcontent + "ddlMemType").focus();
            //        return false;
            //    }
            //}
            if (document.getElementById(strcontent + "ddlStatus") != null) {
                if (document.getElementById(strcontent + "ddlStatus").value == "") {
                    alert("Please select status");
                    document.getElementById(strcontent + "ddlStatus").focus();
                    return false;
                }
            }
            if (document.getElementById(strcontent + "txtEfDate") != null) {
                if (document.getElementById(strcontent + "txtEfDate").value == "") {
                    alert("Please select effective date");
                    //document.getElementById(strcontent + "txtEfDate").focus();
                    return false;
                }
            }
            //if (document.getElementById(strcontent + "txtCeDate") != null) {
            //    if (document.getElementById(strcontent + "txtCeDate").value == "") {
            //        alert("Please Select Cease Date");
            //        document.getElementById(strcontent + "txtCeDate").focus();
            //        return false;
            //    }
            //}
            return true;
        }

        function validate() {

            var strcontent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strcontent + "txtKPIDesc1") != null) {
                if (document.getElementById(strcontent + "txtKPIDesc1").value == "") {
                    alert("Please enter KPI description");
                    document.getElementById(strcontent + "txtKPIDesc1").focus();
                    return false;
                }
            }

            //Commented BY Pratik
            //if (document.getElementById(strcontent + "ddlChn") != null) {
            //    if (document.getElementById(strcontent + "ddlChn").value == "") {
            //        alert("Please Select Hierarchy Name");
            //        document.getElementById(strcontent + "ddlChn").focus();
            //        return false;
            //    }
            //}

            //if (document.getElementById(strcontent + "ddlChnCls") != null) {
            //    if (document.getElementById(strcontent + "ddlChnCls").value == "") {
            //        alert("Please Select Sub Class");
            //        document.getElementById(strcontent + "ddlChnCls").focus();
            //        return false;
            //    }
            //}
            //Commented BY Pratik

            if (document.getElementById(strcontent + "ddlKPItype") != null) {
                if (document.getElementById(strcontent + "ddlKPItype").value == "") {
                    alert("Please select unit type");
                    document.getElementById(strcontent + "ddlKPItype").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlKPISbtype") != null) {
                if (document.getElementById(strcontent + "ddlKPISbtype").value == "") {
                    alert('Please select unit sub type');
                    document.getElementById(strcontent + "ddlKPISbtype").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlMeasureAs") != null) {
                if (document.getElementById(strcontent + "ddlMeasureAs").value == "") {
                    alert('Please select measured as');
                    document.getElementById(strcontent + "ddlMeasureAs").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlKPIOrg") != null) {
                if (document.getElementById(strcontent + "ddlKPIOrg").value == "") {
                    alert("Please select KPI origin");
                    document.getElementById(strcontent + "ddlKPIOrg").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtStdMin") != null) {
                if (document.getElementById(strcontent + "txtStdMin").value == "") {
                    alert("Please select Std. Min");
                    document.getElementById(strcontent + "txtStdMin").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtStdMax") != null) {
                if (document.getElementById(strcontent + "txtStdMax").value == "") {
                    alert("Please Select  Std. Max");
                    document.getElementById(strcontent + "txtStdMax").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlCategory") != null) {
                if (document.getElementById(strcontent + "ddlCategory").value == "") {
                    alert('Please select category');
                    document.getElementById(strcontent + "ddlCategory").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtCategory") != null) {
                if (document.getElementById(strcontent + "txtCategory").value == "") {
                    alert("Please enter category");
                    document.getElementById(strcontent + "txtCategory").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtFrmDate") != null) {
                if (document.getElementById(strcontent + "txtFrmDate").value == "") {
                    alert("Please enter from date");
                    document.getElementById(strcontent + "txtFrmDate").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtFinYr") != null) {
                if (document.getElementById(strcontent + "txtFinYr").value == "") {
                    alert("Please enter financial year");
                    document.getElementById(strcontent + "txtFinYr").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVer") != null) {
                if (document.getElementById(strcontent + "txtVer").value == "") {
                    alert("Please enter version");
                    document.getElementById(strcontent + "txtVer").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtEffdate") != null) {
                if (document.getElementById(strcontent + "txtEffdate").value == "") {
                    alert("Please enter effective date");
                    document.getElementById(strcontent + "txtEffdate").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlKPIOrg") != null) {
                if (document.getElementById(strcontent + "ddlDtLstKey") != null) {
                    if (document.getElementById(strcontent + "ddlKPIOrg").value == "1001") {
                        if (document.getElementById(strcontent + "ddlDtLstKey").value == "") {
                            alert("Please select data list key");
                            document.getElementById(strcontent + "ddlDtLstKey").focus();
                            return false;
                        }
                    }
                }
            }

            if (document.getElementById(strcontent + "ddlKPIOrg") != null) {
                if (document.getElementById(strcontent + "ddlDtFldKey") != null) {
                    if (document.getElementById(strcontent + "ddlKPIOrg").value == "1001") {
                        if (document.getElementById(strcontent + "ddlDtFldKey").value == "") {
                            alert("Please select data field key");
                            document.getElementById(strcontent + "ddlDtFldKey").focus();
                            return false;
                        }
                    }
                }
            }

            if (document.getElementById(strcontent + "ddlKPIOrg") != null) {
                if (document.getElementById(strcontent + "ddlDtFuncKey") != null) {
                    if (document.getElementById(strcontent + "ddlKPIOrg").value == "1001") {
                        if (document.getElementById(strcontent + "ddlDtFuncKey").value == "") {
                            alert("Please select data function key");
                            document.getElementById(strcontent + "ddlDtFuncKey").focus();
                            return false;
                        }
                    }
                }
            }

        }

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

        function CloseDiv(divId) {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }

        function funPopUp() {
            ////alert('akshay');
            var strContent = "ctl00_ContentPlaceHolder1_";
            hdnlstkey = null;
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopFrmEditor.aspx?mdlpopup=mdlViewBID&funckey="
                + document.getElementById(strContent + "hdnfunckey").id + "&lstkey=" + document.getElementById(strContent + "hdnlstkey").id
                + "&fldkey=" + document.getElementById(strContent + "hdnfldkey").id
                + "&frml=" + document.getElementById(strContent + "txtFormula").id
                + "&frmlcd=" + document.getElementById(strContent + "hdnFormulaCode").id
               + "&kpicode=" + document.getElementById(strContent + "txtKPICode").value;

        }

        function funPopUpHyb(kpicode, kpidesc) {
            // alert('adscjkbac');
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwHbBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmhb").src = "MstTblDesign.aspx?kpidesc=" + kpidesc + "&kpicode=" + kpicode + "&mdlpopup=mdlVwHbBID";
        }

        function x1() {
            var t1 = document.getElementById('<%=txtStdMin.ClientID%>').value;
            document.getElementById('<%=txtStdMax.ClientID%>').value = t1;
        }

        function confirmDeletetable() {
            return confirm('Are you sure to delete this table?');
        }

        function customeAlert(msg) {
            alert(msg);
        }

        $(document).ready(function () {
            window.history.replaceState('', '', window.location.href)
        })

    </script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .disablepage td {
            display: none;
        }

        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
            vertical-align: top;
        }

        .custom {
            width: 100px !important;
        }

        .color-white {
            color: #fff !important;
        }

        .grid-container {
            margin-top: 10px;
            max-height: 300px;
            overflow-y: scroll;
        }

            .grid-container::-webkit-scrollbar {
                width: 5px;
            }

            .grid-container::-webkit-scrollbar-track {
                background: #f1f1f1;
            }

            /* Handle */
            .grid-container::-webkit-scrollbar-thumb {
                background: #888;
            }

                /* Handle on hover */
                .grid-container::-webkit-scrollbar-thumb:hover {
                    background: #555;
                }

        .bg-primary {
            color: #fff !important;
            background-color: #337ab7 !important;
        }

        .p-0 {
            padding: 0px;
        }

        .font-14 {
            font-size: 14px;
        }

        .text-black {
            color: #000;
        }

        .glyphicon {
            color: black;
            margin-left: 5px;
            margin-right: 5px;
            cursor: pointer;
        }

        .CenterAlign {
            text-align: center !important;
        }

        .LeftAlign {
            text-align: left !important;
        }

        .RightAlign {
            text-align: right !important;
        }

        .multiselect {
            overflow: hidden;
            width: 245px;
        }

        .glyphicon:hover {
            color: #fff;
        }

        .btn.focus, .btn:focus, .btn:hover {
            color: #fff !important;
        }

        .multiselect {
            overflow: hidden;
            width: 245px;
        }

        .multiselect-container {
            max-height: 200px;
            overflow: scroll;
        }

            .multiselect-container::-webkit-scrollbar {
                width: 7px;
                height: 0px;
            }

            /* Track */
            .multiselect-container::-webkit-scrollbar-track {
                background: #f1f1f1;
            }

            /* Handle */
            .multiselect-container::-webkit-scrollbar-thumb {
                background: #888;
            }

                /* Handle on hover */
                .multiselect-container::-webkit-scrollbar-thumb:hover {
                    background: #555;
                }
    </style>



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="divkpihdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%" class="panel">
        <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpihdr','myImg1');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="KPI Setup" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="divkpihdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
            <%--KPI_DETAILS--%>
            <div style="padding: 10px;">
                <div id="div8" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div13','ImgDetails');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label28" Text="KPI Details" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="ImgDetails" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div13" runat="server" style="width: 96%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPICode" Text="KPI Code" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtKPICode" runat="server" CssClass="form-control" TabIndex="1"
                                    placeholder="KPI Code" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPIDesc1" Text="KPI Description 1" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtKPIDesc1" runat="server" CssClass="form-control" TabIndex="2"
                                    placeholder="KPI Description 1" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPIDesc2" Text="KPI Description 2" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblKPIDesc2Hindi" Text="[हिन्दी]" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtKPIDesc2" runat="server" CssClass="form-control" TabIndex="3"
                                    placeholder="KPI Description 2" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPIDesc3" Text="KPI Description 3" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblKPIDesc3Reg" Text="[Regional]" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtKPIDesc3" runat="server" CssClass="form-control" TabIndex="4"
                                    placeholder="KPI Description 3" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px; display: none">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCls" Text="Hierarchy Name" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label4" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChn" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlChn_SelectedIndexChanged" TabIndex="5">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSubCls" Text="Sub Class" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label5" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="select2-container form-control" TabIndex="6"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPItype" Text="Unit Type" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label6" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlKPItype" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="7" OnSelectedIndexChanged="ddlKPItype_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPISbtype" Text="Unit Sub Type" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label7" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlKPISbtype" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="8" OnSelectedIndexChanged="ddlKPISbtype_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMsrdOn" Text="Measured As" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                    ID="Label8" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMeasureAs" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="9" OnSelectedIndexChanged="ddlMeasureAs_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPIOrg" Text="KPI Origin" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                    ID="Label9" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlKPIOrg" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="10" OnSelectedIndexChanged="ddlKPIOrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStdMin" Text="Std. Min" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label10" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtStdMin" runat="server" CssClass="form-control" TabIndex="11" onChange="x1()"
                                            placeholder="Std. Min" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStdMax" Text="Std. Max" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label11" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtStdMax" runat="server" CssClass="form-control" TabIndex="12"
                                            placeholder="Std. Max" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Category" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                    ID="Label12" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"
                                            Visible="false" placeholder="Category" />
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="select2-container form-control" TabIndex="13">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSrcUpld" Text="Source of Upload" runat="server" CssClass="control-label"
                                            Visible="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSrcUpld" runat="server" AutoPostBack="true" CssClass="select2-container form-control" TabIndex="14"
                                            Visible="false">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="padding: 10px;">
                            <div id="divdefhdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                                <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdef','myImg');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <asp:Label ID="lblDefRngHdr" Text="Date Range" runat="server" Font-Size="19px" />
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divdef" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblFinYr" Text="Business Yr Type" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                                ID="Label14" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control" TabIndex="15" placeholder="Business Yr Type"
                                                Visible="false" />
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlBusiYrType" runat="server" Enabled="false" AutoPostBack="true" CssClass="select2-container form-control" TabIndex="16"
                                                        OnSelectedIndexChanged="ddlBusiYrType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label18" Text="Business Yr" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                                ID="Label19" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlBusiYear" Enabled="false" runat="server" AutoPostBack="true" CssClass="select2-container form-control" TabIndex="17"
                                                        OnSelectedIndexChanged="ddlBusiYear_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblFrm" Text="From Date" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                                ID="Label13" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtFrmDate" Enabled="false" runat="server" CssClass="form-control" TabIndex="18"
                                                        placeholder="From Date" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblTo" Text="To Date" Style="font-size: 14px;"
                                                runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtToDate" Enabled="false" runat="server" CssClass="form-control" TabIndex="19" placeholder="To Date" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblEffdate" Text="Ver. Eff. From" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                            <%--onmousedown="populateGridCalender(this)" onmouseup="populateGridCalender(this)" --%>
                                            <asp:Label ID="Label16" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtEffdate" Enabled="false" runat="server" CssClass="form-control" TabIndex="20" onmousedown="populateGridCalender(this)" onmouseup="populateGridCalender(this)"
                                                        placeholder="Ver. Eff. From" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblCseDt" Text="Ver. Eff. To" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtCseDt" Enabled="false" runat="server" CssClass="form-control" TabIndex="21"
                                                        placeholder="Ver. Eff. To" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVer" Text="Version" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label15" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" Enabled="false" TabIndex="22" placeholder="Version" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblBusiRuleCd" Text="Business Rule Code" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtBusiRuleCd" runat="server" CssClass="form-control" Enabled="false" TabIndex="23"
                                    placeholder="Business Rule Code" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblFormula" Text="Formula Editor" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-9">
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFormula" runat="server" Enabled="false" CssClass="form-control" TabIndex="24"
                                            TextMode="MultiLine" Columns="20" ClientIDMode="Static" Rows="5" placeholder="Formula Editor" MaxLength="2" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <div style="text-align: left;">
                                            <asp:LinkButton ID="lnkAdd" Text="Add Formula" Enabled="false" runat="server" />&nbsp;
                                    <asp:LinkButton ID="lnkHyb" Text="Set Hybrid Details" Enabled="false" runat="server" Visible="false"
                                        OnClick="lnkHyb_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click" Enabled="false"
                                    TabIndex="25">
                                <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-sample" OnClick="btnEdit_Click"
                                    TabIndex="26">
                                <span class="glyphicon glyphicon-edit" style="color: White;"></span> Edit
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"
                                    OnClick="btnCancel_Click" TabIndex="27">
                                <span class="glyphicon glyphicon-erase" style="color:White"></span> Clear
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClose" runat="server" CssClass="btn btn-sample"
                                    OnClick="btnClose_Click" TabIndex="28">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnHist" runat="server" CssClass="btn btn-sample"
                                    OnClick="btnHist_Click" TabIndex="29" Visible="false">
                                <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> History
                                </asp:LinkButton>
                                <asp:Button ID="btnfrml" runat="server" ClientIDMode="Static" Style="display: none;"
                                    OnClick="btnfrml_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--KPI_DETAILS--%>
            <%--Added by Shubham--%>
            <div style="padding: 10px;">
                <div id="div4" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div7','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label20" Text="Define Scope of Standard Definition" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div7" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <center>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblChannel" Text="Channel" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label22" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChannel" runat="server"  CssClass="select2-container form-control" Visible="false"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged" TabIndex="5"  >
                                        </asp:DropDownList>

                                        <asp:ListBox ID="lstChannel"  SelectionMode="Single" runat="server" CssClass="select2-container form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="lstChannel_SelectedIndexChanged">

                                        </asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSubChannel" Text="Sub Channel" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label24" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSubChannel" runat="server" CssClass="select2-container form-control" TabIndex="6" Visible="false"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlSubChannel_SelectedIndexChanged">
                                        </asp:DropDownList>

                                        <asp:ListBox ID="lstSubChnl" runat="server" CssClass="select2-container form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="lstSubChnl_SelectedIndexChanged" SelectionMode="Multiple">
                                        </asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemType" Text="Member Type" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label27" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMemType" runat="server" CssClass="select2-container form-control" TabIndex="6" Visible="false"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlMemType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                           <asp:ListBox ID="lstMemType" runat="server" CssClass="select2-container form-control" SelectionMode="Multiple">
                                        </asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStatus" Text="Status" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label25" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select2-container form-control" TabIndex="6"
                                            >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEfDate" Text="Effective Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label23" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                 <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtEfDate" runat="server" CssClass="form-control" 
                                    onmousedown="PopulateCalender()"
                                        onmouseup="PopulateCalender()"
                                     placeholder="DD/MM/YYYY"  />
                                        <%--onmousedown="PopulateCalender()"
                                        onmouseup="PopulateCalender()"--%>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCeDate" Text="Cease Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label26" Text="*" runat="server" Style="color: Red" Visible="false" />
                            </div>
                            <div class="col-sm-3">
                                 <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtCeDate" runat="server" CssClass="form-control" 
                                    onmousedown="PopulateCalender1()"
                                    onmouseup="PopulateCalender1()"
                                    placeholder="DD/MM/YYYY" />
                                        <%--onmousedown="PopulateCalender1()"
                                    onmouseup="PopulateCalender1()" --%>
                                          </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;margin-bottom:12px;">
                            <div class="col-sm-12" align="center">
                                 <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sample" OnClick="btnAddnew_Click" OnClientClick="return ValidateDefScpInp()"
                                    TabIndex="25">
                                                <span class="glyphicon glyphicon-plus" style="color: White;"></span> Add
                                </asp:LinkButton>
                                        </ContentTemplate>
                                     </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--GridView-Start--%>
                        
                            <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                <ContentTemplate>
                                    <div id="divGrid" runat="server" > 
                                    <div class="container-fluid">
                                        <asp:GridView ID="grvaddedresult" runat="server" AutoGenerateColumns="false"
                                        OnRowEditing="grvaddedresult_RowEditing"
                                        OnSorting="grvaddedresult_Sorting"
                                        Style="margin-right: 1%; margin-bottom: 0.3%;"
                                        CssClass="footable"
                                        OnRowUpdating="grvaddedresult_RowUpdating"
                                        CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="true" ShowFooter="false"
                                        AllowPaging="true" ForeColor="#333333" GridLines="None" EmptyDataText="No Record found..!"
                                        PageSize="10" DataKeyNames="BIZSRC,CHNCLS,MEMTYPE">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Channel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="BIZSRC">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChnl" runat="server" Text='<%# Bind("BIZSRC")%>' Style="display: none"> </asp:Label>
                                                    <asp:Label ID="lblChnDesc" runat="server" Text='<%# Bind("ChannelDesc01")%>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlGrdChnl" runat="server" Visible="false" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="ddlGrdChnl_SelectedIndexChanged" CssClass="select2-container form-control" ClientIDMode="Static" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblChnDesc" runat="server" Text='<%# Bind("ChannelDesc01")%>'> </asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sub Channel" SortExpression="CHNCLS">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubChnl" runat="server" Text='<%# Bind("CHNCLS")%>' Style="display: none" />
                                                    <asp:Label ID="lblSubChnlDesc" runat="server" Text='<%# Bind("ChnClsDesc01")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlGrdSubChnl" Visible="false" runat="server" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="ddlGrdSubChnl_SelectedIndexChanged" CssClass="select2-container form-control" ClientIDMode="Static" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblSubChnlDesc" runat="server" Text='<%# Bind("ChnClsDesc01")%>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>' Style="display: none" />
                                                    <asp:Label ID="lblMemTypeDesc" runat="server" Text='<%# Bind("MemTypeDesc01")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlGrdMemType" Width="100px" Visible="false" runat="server" AutoPostBack="true" CssClass="select2-container form-control" ClientIDMode="Static" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblMemTypeDesc" runat="server" Text='<%# Bind("MemTypeDesc01")%>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="STATUS" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("STATUS")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlGrdStatus" Width="100px" CssClass="select2-container form-control" ClientIDMode="Static" runat="server">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date" SortExpression="EFF_DTIM">
                                                <ItemStyle HorizontalAlign="Center" CssClass="CenterAlign" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEffDate" runat="server" Text='<%# Bind("Eff_date_format")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEffDtFrm"  Visible="false" Text='<%# Bind("Eff_date_format")%>' runat="server"  onmousedown="populateGridCalender(this)"  onmouseup="populateGridCalender(this)" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <asp:Label ID="lblEffDate" runat="server" Text='<%# Bind("Eff_date_format")%>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cease Date" SortExpression="CSE_DTIM">
                                                <ItemStyle HorizontalAlign="Center" CssClass="CenterAlign"   />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblceasedt" runat="server" Text='<%# Bind("CSE_date_format")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtceasedt" Text='<%# Bind("CSE_date_format")%>' runat="server" onmousedown="populateGridCalender(this)" onmouseup="populateGridCalender(this)" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created By" SortExpression="CREATEDBY" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCratedBy" runat="server" Text='<%# Bind("CREATEDBY")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtCratedBy" Enabled="false" Text='<%# Bind("CREATEDBY")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created DateTime" SortExpression="CREATE_DTIM" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCratedDtim" runat="server" Text='<%# Bind("CREATE_DTIM")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtCratedDtim" Enabled="false" Text='<%# Bind("CREATE_DTIM")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            	
                                            <asp:TemplateField HeaderText="Updated By" SortExpression="UPDATEDBY" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUpdatedBy" runat="server" Text='<%# Bind("UPDATEDBY")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtUpdatedBy" Text='<%# Bind("UPDATEDBY")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Updated DateTime" SortExpression="UPDATE_DTIM" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUpdatedDtim" runat="server" Text='<%# Bind("UPDATE_DTIM")%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtUpdatedDtim" Text='<%# Bind("UPDATE_DTIM")%>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                               <asp:TemplateField HeaderText="Action" >
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                    <asp:LinkButton Text="Edit" ShowEditButton="true" CommandName="Edit" runat="server" />
                                                    <asp:LinkButton Text="Delete" ID="btnDeleteGrdRcrd" Visible="false" OnClick="btnDeleteGrdRcrd_Click" ShowEditButton="true" CommandName="delete" runat="server" />
                                                    
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" ShowEditButton="true" CommandName="Update" runat="server" />
                                                    <asp:LinkButton ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click1" ShowEditButton="true" CommandName="Cancel" runat="server" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action" >
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <ItemTemplate>
                                                   <asp:LinkButton Text="Set Rule" ID="btnSetRule" OnClick="btnSetRule_Click"  runat="server" />
                                                </ItemTemplate>
                                                   <EditItemTemplate>
                                                </EditItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="ChnlMapId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChnlMapId" runat="server" Text='<%# Bind("KPI_CODE")%>'> </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblChnlMapId" runat="server" Text='<%# Bind("KPI_CODE")%>'> </asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                          <div class="pagination" style="padding: 10px;">
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnpreviousChnlMap" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                        OnClick="btnpreviousChnlMap_Click" />
                                                    <asp:TextBox runat="server" ID="txtPageChnlMap" Style="width: 50px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                        CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextChnlMap" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                        Width="40px" OnClick="btnnextChnlMap_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                          
                        <%--GridView-End--%>
                            </center>
                    </div>
                </div>
            </div>
            <%--Ended by Shubham--%>
            <%--Added By Pratik--%>

            <%--Base Table Allocation--%>
            <div style="padding: 10px;" runat="server" id="div17" visible="false">
                <div id="div18" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div19" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div20','ImgBase');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label30" Text="Define Base Tables" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="ImgBase" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div20" runat="server" style="padding: 10px;" class="panel-body">
                        <asp:UpdatePanel runat="server" ID="UpdatePanelBase">
                            <ContentTemplate>
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="selected Table"></div>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList runat="server" ID="ddlTableList" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:LinkButton runat="server" ID="btnViewTableDetails">
                                                <i class="glyphicon glyphicon-menu-hamburger" ></i> View Details
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--Base Table Allocation--%>

            <%--Base Table--%>
            <div style="padding: 10px;" runat="server" id="divBase" visible="false">
                <div id="div9" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div11','ImgDef');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label21" Text="Define Base Tables" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="ImgDef" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div11" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <asp:UpdatePanel runat="server" ID="updBaseTable">
                            <ContentTemplate>
                                <div class="container-fluid">
                                    <div class="col-sm-5">
                                        <span class="font-14">Search Table</span>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtBaseAll" CssClass="form-control" />
                                            <span class="input-group-addon bg-primary" style="padding: 0px; padding-left: 10px; padding-right: 10px;">
                                                <asp:LinkButton Text="text" runat="server" ID="btnBaseAllSearch" OnClick="btnBaseAllSearch_Click">
                                                    <i class="glyphicon glyphicon-search" style="color:#fff"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="grid-container">
                                            <asp:GridView ID="gvBaseTableALL" runat="server" AutoGenerateColumns="false"
                                                CssClass="footable"
                                                CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                                AllowPaging="false" ForeColor="#333333" GridLines="None" EmptyDataText="No Tables Defined"
                                                PageSize="10" DataKeyNames="OBJ_ID,TBL_NAME" ShowHeader="false">
                                                <RowStyle CssClass="GridViewRowNew" />
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox Text="" runat="server" ID="chkSelector" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TBL_NAME" HeaderText="Table Name" />
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagination" style="padding: 10px; display: none">
                                                <table>
                                                    <tr>
                                                        <td style="white-space: nowrap;">
                                                            <asp:Button ID="btnBaseALLPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                OnClick="btnBaseALLPrev_Click" />
                                                            <asp:TextBox runat="server" ID="txtBaseALLNum" Style="width: 50px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                                CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnBaseALLNext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                Width="40px" OnClick="btnBaseALLNext_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <center>
                                        <asp:LinkButton runat="server" ID="btnAddBase" OnClick="btnAddBase_Click" CssClass="color- btn btn-danger">
                                                Add <i class="glyphicon glyphicon-triangle-right color-white"></i>
                                        </asp:LinkButton>
                                        </center>
                                    </div>
                                    <div class="col-sm-5">
                                        <span class="font-14">Search Table</span>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtBaseKPI" CssClass="form-control" />
                                            <span class="input-group-addon bg-primary" style="padding: 0px; padding-left: 10px; padding-right: 10px;">
                                                <asp:LinkButton Text="text" runat="server" ID="btnBaseKPISearch" OnClick="btnBaseKPISearch_Click">
                                                    <i class="glyphicon glyphicon-search" style="color:#fff"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="grid-container">
                                            <asp:GridView ID="gvBaseTableKPI" runat="server" AutoGenerateColumns="false"
                                                CssClass="footable"
                                                CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                                AllowPaging="false" ForeColor="#333333" GridLines="None" EmptyDataText="No Tables Defined"
                                                PageSize="10" ShowHeader="false" DataKeyNames="OBJ_ID,TBL_NAME">
                                                <RowStyle CssClass="GridViewRowNew" />
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:BoundField DataField="TBL_NAME" HeaderText="Table Name" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBaseBtnDelete" runat="server" CssClass="btn btn-link p-0 text-black"
                                                                OnClientClick="return confirmDeletetable()" OnClick="lnkBaseBtnDelete_Click">
                                                            <i class="glyphicon glyphicon-trash"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagination" style="padding: 10px; display: none">
                                                <table>
                                                    <tr>
                                                        <td style="white-space: nowrap;">
                                                            <asp:Button ID="btnBaseKPIPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                OnClick="btnBaseKPIPrev_Click" />
                                                            <asp:TextBox runat="server" ID="txtBaseKPINum" Style="width: 50px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                                CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnBaseKPINext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                Width="40px" OnClick="btnBaseKPINext_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--Base Table--%>
            <%--Src Table--%>
            <div style="padding: 10px;" runat="server" id="divSrc" visible="false">
                <div id="div14" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div15" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div16','v');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label29" Text="Define Source Tables" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="ImgSorce" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div16" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel22">
                            <ContentTemplate>
                                <div class="container-fluid">
                                    <div class="col-sm-5">
                                        <span class="font-14">Search Table</span>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtSrcAll" CssClass="form-control" />
                                            <span class="input-group-addon bg-primary" style="padding: 0px; padding-left: 10px; padding-right: 10px;">
                                                <asp:LinkButton Text="text" runat="server" ID="btnSrcAllSearch" OnClick="btnSrcAllSearch_Click">
                                                    <i class="glyphicon glyphicon-search" style="color:#fff"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="grid-container">
                                            <asp:GridView ID="gvSrcTableALL" runat="server" AutoGenerateColumns="false"
                                                CssClass="footable"
                                                CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                                AllowPaging="false" ForeColor="#333333" GridLines="None" EmptyDataText="No Tables Defined"
                                                PageSize="10" DataKeyNames="OBJ_ID,TBL_NAME" ShowHeader="false">
                                                <RowStyle CssClass="GridViewRowNew" />
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox Text="" runat="server" ID="chkSelector" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TBL_NAME" HeaderText="Table Name" />
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagination" style="padding: 10px; display: none">
                                                <table>
                                                    <tr>
                                                        <td style="white-space: nowrap;">
                                                            <asp:Button ID="gvSrcTableALLPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                OnClick="gvSrcTableALLPrev_Click" />
                                                            <asp:TextBox runat="server" ID="txtSrcTableALL" Style="width: 50px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                                CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="gvSrcTableALLNext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                Width="40px" OnClick="gvSrcTableALLNext_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <center>
                                        <asp:LinkButton runat="server" ID="btnAddSrc" CssClass="color- btn btn-danger" OnClick="btnAddSrc_Click">
                                            Add <i class="glyphicon glyphicon-triangle-right color-white"></i>
                                        </asp:LinkButton>
                                            </center>
                                    </div>
                                    <div class="col-sm-5">
                                        <span class="font-14">Search Table</span>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtSrcKPI" CssClass="form-control" />
                                            <span class="input-group-addon bg-primary" style="padding: 0px; padding-left: 10px; padding-right: 10px;">
                                                <asp:LinkButton Text="text" runat="server" ID="btnSrcKPISearch" OnClick="btnSrcKPISearch_Click">
                                                    <i class="glyphicon glyphicon-search" style="color:#fff"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                        <div class="grid-container">
                                            <asp:GridView ID="gvSrcTableKPI" runat="server" AutoGenerateColumns="false"
                                                CssClass="footable"
                                                CellPadding="4" AllowSorting="True" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                                AllowPaging="false" ForeColor="#333333" GridLines="None" EmptyDataText="No Tables Defined"
                                                PageSize="10" DataKeyNames="OBJ_ID,TBL_NAME" ShowHeader="false">
                                                <RowStyle CssClass="GridViewRowNew" />
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:BoundField DataField="TBL_NAME" HeaderText="Table Name" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkSrcBtnDelete" runat="server" CssClass="btn btn-link"
                                                                OnClientClick="return confirmDeletetable()" OnClick="lnkSrcBtnDelete_Click">      
                                                            <i class="glyphicon glyphicon-trash"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagination" style="padding: 10px; display: none">
                                                <table>
                                                    <tr>
                                                        <td style="white-space: nowrap;">
                                                            <asp:Button ID="gvSrcTableKPIPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                OnClick="gvSrcTableKPIPrev_Click" />
                                                            <asp:TextBox runat="server" ID="txtSrcTableKPI" Style="width: 50px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                                CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="gvSrcTableKPINext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                Width="40px" OnClick="gvSrcTableKPINext_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <%--Src Table--%>

            <%--Added By Pratik--%>
        </div>
    </div>


    <%--Added by Prathamesh on 21_02_2018 start--%>

    <asp:Panel ID="pnlVersion" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #034ea2; color: white;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">

            <br />
            <center>
                <asp:Label ID="lblVersion" runat="server"></asp:Label></center>
            <br />

        </div>
        <div class="modal-footer" style="text-align: center">
            <center>

                 <div class="row"  >
                      <div class="col-sm-3" >
                          </div>
                       <div class="col-sm-3" >
                  <asp:LinkButton ID="btnYes" OnClick="btnYes_Click"    Width="80px" CssClass="btn btn-sample" runat="server">  
                       <span class="glyphicon glyphicon-ok" style="color:White"></span> YES
                       </asp:LinkButton> 
                       </div>
           
                       <div class="col-sm-3"   >
                 <asp:LinkButton ID="lnkCanSave" runat="server" CssClass="btn btn-sample" 
                            OnClick="btnCanSave_Click" >
                      
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> NO
                        </asp:LinkButton>
                    </div>
                      <div class="col-sm-3" >
                          &nbsp; <asp:Button ID="btnNo" OnClick="btnNo_Click" Text="No" Width="80px" Visible="false"  CssClass="btn btn-sample" 
                       runat="server"></asp:Button>
                          </div>
               
                  </div>
               </center>
            <%--  <asp:Button ID="Button1" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-sample" />--%>
        </div>
    </asp:Panel>


    <asp:Panel ID="pnl" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #034ea2; color: white;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">

            <br />
            <center>
                <asp:Label ID="lbl3" runat="server"></asp:Label></center>
            <br />
            <%--  <center>
                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
            </center>
            <br />--%>
            <center>
                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" OnClick="btnok_Click" CssClass="btn btn-sample" />
        </div>
    </asp:Panel>


    <asp:Panel ID="pnVersion2" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #034ea2; color: white;">
            <%--Width="400px" Height="250px" CssClass="modal-content"--%>
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">

            <br />
            <center>
                <asp:Label ID="lblVersion1" runat="server"></asp:Label></center>
            <br />
        </div>
        <div class="modal-footer" style="text-align: center">
            <center>
                <div class="row">
                          <div class="col-sm-3">
                          </div>
                              <div class="col-sm-3">
                  <asp:LinkButton ID="btnYes1" OnClick="btnYes1_Click" Text="Yes" Width="80px" CssClass="btn btn-sample" runat="server">
                       <span class="glyphicon glyphicon-ok" style="color:White"></span>YES
                  </asp:LinkButton> 
                               </div>
                              <div class="col-sm-3">
                   <asp:LinkButton ID="btnNo1" OnClick="btnNo1_Click" Text="No" Width="80px" CssClass="btn btn-sample" runat="server">
                         <span class="glyphicon glyphicon-remove" style="color:White"></span>NO
                   </asp:LinkButton>
                                </div>
                              <div class="col-sm-3">
                                  </div>
                                   
          
        </div>
                          </center>
    </asp:Panel>


    <%--Added by Prathamesh on 21_02_2018 end--%>


    <asp:Panel ID="pnlVersion3" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #034ea2; color: white;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">

            <br />
            <center>
                <asp:Label ID="lblPnl4" runat="server"></asp:Label></center>
            <br />
            <%-- <center>
                <asp:Label ID="lblPnl5" runat="server"></asp:Label></center>
            <br />--%>
            <center>
                <asp:Label ID="lblPnl6" runat="server"></asp:Label></center>
            <br />

        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:Button ID="btnPnl4" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-sample" />
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" Width="400px" Height="250px" CssClass="modal-content">
        <div class="modal-header" style="text-align: center; background-color: #034ea2; color: white;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">
            <asp:Label ID="lblChnMapNew" runat="server"></asp:Label>
            <asp:Label ID="Label32" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-sample" />
        </div>
    </asp:Panel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnfunckey" runat="server" />
            <asp:HiddenField ID="hdnlstkey" runat="server" />
            <asp:HiddenField ID="hdnfldkey" runat="server" />
            <asp:HiddenField ID="hdnFormulaCode" runat="server" />
            <asp:HiddenField ID="hdnFormula" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>


    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" X="500" Y="100">
    </ajaxToolkit:ModalPopupExtender>

    <ajaxToolkit:ModalPopupExtender ID="mdlBulkWarning" runat="server" TargetControlID="lblChnMapNew"
        BehaviorID="mdlBulkWarning" BackgroundCssClass="modalPopupBg" PopupControlID="Panel2"
        DropShadow="false" OkControlID="Button1" X="500" Y="100">
    </ajaxToolkit:ModalPopupExtender>

    <%--Added by Prathamesh on 21_02_2018 start--%>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup1" runat="server" TargetControlID="lblVersion"
        BehaviorID="mdlpopup1" BackgroundCssClass="modalPopupBg" PopupControlID="pnlVersion"
        DropShadow="false" X="500" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Prathamesh on 21_02_2018 end--%>

    <%--Added by Prathamesh on 21_02_2018 start--%>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup2" runat="server" TargetControlID="lblVersion1"
        BehaviorID="mdlpopup2" BackgroundCssClass="modalPopupBg" PopupControlID="pnVersion2"
        DropShadow="false" OkControlID="btnNo1" X="500" Y="100">
    </ajaxToolkit:ModalPopupExtender>


    <ajaxToolkit:ModalPopupExtender ID="mdlpopup3" runat="server" TargetControlID="lblPnl4"
        BehaviorID="mdlpopup3" BackgroundCssClass="modalPopupBg" PopupControlID="pnlVersion3"
        DropShadow="false" OkControlID="btnPnl4" X="500" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Prathamesh on 21_02_2018 end--%>



    <asp:Panel runat="server" Height="100%" Width="100%" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel runat="server" Height="100%" Width="90%" ID="Panel1" display="none" CssClass="panel panel-primary"
        Style="text-align: center; padding: 10px;">
        <table style="width: 100%; height: 100%;">
            <tr>
                <td>
                    <iframe runat="server" id="ifrmhb" scrolling="yes" width="100%" frameborder="0" display="none"
                        style="height: 100%;"></iframe>
                </td>
            </tr>
            <tr runat="server" style="height: 5px">
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                    <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnC" runat="server" CssClass="btn btn-success" OnClick="btnC_Click"
                                TabIndex="25">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label runat="server" ID="Label17" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwHb" BehaviorID="mdlVwHbBID"
        DropShadow="false" TargetControlID="Label17" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
        <ContentTemplate>
            <center>
                <div id="divkpisrchhdrcollapse" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div2" runat="server" class="panel-heading" style="width: 100%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                <asp:Label ID="lblKPISrch" Text="KPI Search" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 100%; padding: 10px;" class="panel-body">
                        <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgKPI" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" OnRowDataBound="dgKPI_RowDataBound" AllowPaging="true"
                                        OnSorting="dgKPI_Sorting" CssClass="footable">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <pagerstyle cssclass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="KPI_CODE">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkKPICode" Text='<%# Bind("KPI_CODE")%>' runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="KPI Description" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" SortExpression="KPI_DESC_01">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKpiDesc" Text='<%# Bind("KPI_DESC_01")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="KPI_DESC_02" HeaderText="KPI Description 2" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" SortExpression="KPI_DESC_02">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="KPIType" HeaderText="KPI Type" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="KPIType" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="KPIOrigin" HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="KPIOrigin" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="KPIOrigin">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKpiOrg" Text='<%# Bind("KPIOrigin")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="hdnCatg" Value='<%# Bind("CATG")%>' runat="server"></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RangeFrm" HeaderText="Eff. From" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="RangeFrm" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RangeTo" HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" SortExpression="RangeTo" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Version" HeaderText="Version" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" SortExpression="Version" ItemStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="lnkDelete_Click"
                                                        OnClientClick="confirm('Do you want to delete this KPI')" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Std. Definition" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSetRule" Text="Set Rule" runat="server" OnClick="lnkSetRule_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;" 
                                                        OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src='<%= ResolveUrl("~/assets/scripts/jquery.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap-multiselect.js") %>'></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script>
        function BindMultiSelect() {
            $('#<%= lstChannel.ClientID %>').multiselect();
            $('#<%= lstSubChnl.ClientID %>').multiselect({
                includeSelectAllOption: true,
            });
            $('#<%= lstMemType.ClientID %>').multiselect({
                includeSelectAllOption: true,
            });
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            BindMultiSelect();
        });

        $(document).ready(function () {
            debugger;
            BindMultiSelect();
            $("#<%= txtFrmDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });
            $("#<%= txtToDate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });

            $("#<%= txtEffdate.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });
            $("#<%= txtCseDt.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });

            $(document).on("click", "#<%= btnok.ClientID%>", function () {
                window.location.href = "KPISetup.aspx?flag=E&KPICode=" + "<%= txtKPICode.Text %>";
            })
        });
    </script>
</asp:Content>

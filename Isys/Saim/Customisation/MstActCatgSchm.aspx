<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MstActCatgSchm.aspx.cs" Inherits="Application_Isys_Saim_Customisation_MstActCatgSchm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

        <link href="../../../../KMI Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/Bootstrap/css/footable.min.css" rel="stylesheet"
        type="text/css" />
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
    <%--Added References by Daksh for Reports Start--%>
   <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../../../assets/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../../../../assets/scripts/commonValidate.js"></script>

    <%--Added References by DAksh for Reports End--%>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        #divLoading {
            display: none;
        }

            #divLoading.show {
                display: block;
                position: fixed;
                z-index: 100;
                background-image: url('../../../../theme/iflow/aniprogress.gif');
                background-color: #666;
                opacity: 0.4;
                background-repeat: no-repeat;
                background-position: center;
                left: 0;
                bottom: 0;
                right: 0;
                top: 0;
            }

        #loadinggif.show {
            left: 50%;
            top: 50%;
            position: absolute;
            z-index: 101;
            width: 32px;
            height: 32px;
            margin-left: -16px;
            margin-top: -16px;
        }

        /*div.content {
            width: 1000px;
            height: 1000px;
        }*/

        .onhover {
            color: white !important;
        }

        .gridview th {
            padding: 10px;
            height: 40px;
            background-color: #f04e5e;
            color: #FFFFFF;
            border-color: #f04e5e;
            text-align: center;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
        }

        .bottomspace {
            margin-bottom: 10px;
        }


        ul#menu li a:active {
            background: white;
        }


        .required:after {
            content: "*";
            font-weight: bold;
            color: red;
        }



        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }

        .footable > tbody > tr > td {
            text-align: center !important;
        }
    </style>
    <script type="text/javascript">

        function doPostback() {
            debugger;
            console.log("debugg");
            $('#<%=btnDnldGridData.ClientID %>').removeAttr("disabled");
            //$('#<%=btnDnldGridData.ClientID %>').attr("disabled", false);;
            //$("#ctl00_ContentPlaceHolder1_btnDnldGridData").attr("disabled", false);
        }
        function StartProgressBar() {
            debugger;
            var myExtender = $find('ProgressBarModalPopupExtender1');
            myExtender.show();
            return true;
        }

        $(document).ready(function () {
            $("th").click(function () {
                var columnIndex = $(this).index();
                var tdArray = $(this).closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")");
                tdArray.sort(function (p, n) {
                    var pData = $(p).text();
                    var nData = $(n).text();
                    return pData < nData ? -1 : 1;
                });
                tdArray.each(function () {
                    var row = $(this).parent();
                    $("#dgCntst").append(row);
                });
            });
        })

        function popAlert() {
            alert("Rate Updated Successfully");
            //$("div#divLoading").removeClass('show');
        }

        function popup() {
            $("#myModal").modal();

        }

        function PopulateLDFrom() {
            $("#<%= txtLDFrom.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy', onSelect: function (d, i) {
                }
            });
        }

        function PopulateLDTo() {
            $("#<%= txtLDto.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy', onSelect: function (d, i) {
                }
            });
        }

        function PopulateTDFrom() {
            $("#<%= txtTDFrom.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy', onSelect: function (d, i) {
                }
            });
        }

        function PopulateTDTo() {
            $("#<%= txtTDto.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy', onSelect: function (d, i) {
                }
            });
        }



        function validatefields() {

            if ((document.getElementById("<%=txtweightage.ClientID%>").value).trim() == "") {
                alert("Please select Weightage.")
                return false;
            }

            if (document.getElementById("<%=divLob.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddllob.ClientID%>");
                var LOB = e.options[e.selectedIndex].value;
                if (LOB == 0) {
                    alert("Please select LOB.");
                    return false;
                }
            }

            if (document.getElementById("<%=divPC.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddlProductCode.ClientID%>");
                var PROD = e.options[e.selectedIndex].value;
                if (PROD == 0) {
                    alert("Please select Product Code.");
                    return false;
                }
            }

            if (document.getElementById("<%=divSPC.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddlsubProductCode.ClientID%>");
                var SUBPROD = e.options[e.selectedIndex].value;
                if (SUBPROD == 0) {
                    alert("Please select Sub-Product Code.");
                    return false;
                }
            }

            if (document.getElementById("<%=divPT.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddlpolicyType.ClientID%>");
                var POLTYP = e.options[e.selectedIndex].value;
                if (POLTYP == 0) {
                    alert("Please select Policy Type.");
                    return false;
                }
            }

            if (document.getElementById("<%=divFixFactorSELFIandULIPbody.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddlSELFIflag.ClientID%>");
                var SELFI = e.options[e.selectedIndex].value;
                if (SELFI == 0) {
                    alert("Please select Selfi Flag.");
                    return false;
                }
            }


            if (document.getElementById("<%=divULIP.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=ddlULIP.ClientID%>");
                var ULIP = e.options[e.selectedIndex].value;
                if (ULIP == 0) {
                    alert("Please select ULIP + Protection Flag.");
                    return false;
                }
            }


            if (document.getElementById("<%=divCPC.ClientID%>").style.display == "block") {
            debugger;
                var e = document.getElementById("<%=ddlCPC.ClientID%>");
                var CPC = e.options[e.selectedIndex].value;
                if (CPC == 0) {
                    alert("Please select Combo Product Code");
                    return false;
                }
            }


            if (document.getElementById("<%=divPDT.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=DdlPDT.ClientID%>");
                var POLICYCATG = e.options[e.selectedIndex].value;
                if (POLICYCATG == 0) {
                    alert("Please select Policy Category");
                    return false;
                }
            }

           

            if (document.getElementById("<%=divVPSC.ClientID%>").style.display == "block") {
                debugger;
                var e = document.getElementById("<%=DdlVpscFlag.ClientID%>");
                var VPSC = e.options[e.selectedIndex].value;
                if (VPSC == 0) {
                    alert("Please select VPSC Flag");
                    return false;
                }
            }


            debugger;
            if ((document.getElementById("<%=txtLDto.ClientID%>").value).length != 0 && (document.getElementById("<%=txtLDFrom.ClientID%>").value).length != 0) {
                var toDate = document.getElementById("<%=txtLDto.ClientID%>").value;
                var fromDate = document.getElementById("<%=txtLDFrom.ClientID%>").value;
                var strcontent = "ctl00_ContentPlaceHolder1_";
                debugger;
                if (!checkDateIsGreaterThanToday(fromDate, toDate)) {
                    alert("Login From Date should not be greater than Login To Date.");
                    return false;
                }
            }

            if ((document.getElementById("<%=txtTDto.ClientID%>").value).length != 0 && (document.getElementById("<%=txtTDFrom.ClientID%>").value).length != 0) {
                var toDate = document.getElementById("<%=txtTDto.ClientID%>").value;
                var fromDate = document.getElementById("<%=txtTDFrom.ClientID%>").value;
                var strcontent = "ctl00_ContentPlaceHolder1_";
                debugger;
                if (!checkDateIsGreaterThanToday(fromDate, toDate)) {
                    alert("Transaction From Date should not be greater than Transaction To Date.");
                    return false;
                }
            }

            if (document.getElementById("<%=divRangeFactorPTFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtPayTermFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Pay Term From ");
                    return false;
                }
                if ((document.getElementById("<%=txtPayTermTo.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Pay Term To ");
                    return false;
                }
            }

            if (document.getElementById("<%=divRangeFactorPWOTFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtPremiumWOTaxFrom.ClientID%>").value).trim() == "") {

                    alert("Please enter Premium Without Tax From");
                    return false;
                }
                if ((document.getElementById("<%=txtPremiumWOTaxTo.ClientID%>").value).trim() == "") {

                    alert("Please enter Premium Without Tax To ");
                    return false;
                }

            }



            

            if (document.getElementById("<%=divRangeFactorPWTFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtPremiumWTaxFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Premium With Tax From");
                    return false;
                }
                if ((document.getElementById("<%=txtPremiumWTaxTo.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Premium With Tax To ");
                    return false;
                }

            }

            if (document.getElementById("<%=divRangeFactorLDFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtLDFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter LogIn Date From");
                    return false;
                }
                if ((document.getElementById("<%=txtLDto.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter LogIn Date To");
                    return false;
                }

            }


            if (document.getElementById("<%=divRangeFactorANPFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtANPFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter ANP From ");
                    return false;
                }
                if ((document.getElementById("<%=txtANPTo.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter ANP To ");
                    return false;
                }
            }

            if (document.getElementById("<%=divRangeFactorWNBPFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtWNBPFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter WNBP From ");
                    return false;
                }
                if ((document.getElementById("<%=txtWNBPTo.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter WNBP To ");
                    return false;
                }
            }
            if (document.getElementById("<%=divRangeFactorDFPFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtDEPFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Deferment Period From ");
                    return false;
                }
                if ((document.getElementById("<%=txtDEPFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Deferment Period To ");
                    return false;
                }
            }
            


          

            if (document.getElementById("<%=divRangeFactorTDFromTo.ClientID%>").style.display == "block") {
                debugger;
                if ((document.getElementById("<%=txtTDFrom.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Transaction Date From");
                    return false;
                }
                if ((document.getElementById("<%=txtTDto.ClientID%>").value).trim() == "") {
                    debugger;
                    alert("Please enter Transaction Date To");
                    return false;
                }

            }


            





        }



    </script>
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
    </script>
    <%---------------------------------------------------------------------------------%>
    <style type="text/css">
        .multiselect {
            overflow: hidden;
            /*width: 250px;*/
            width: 228px;
        }

        .btn-group {
            margin-right: 148px;
        }

        .dropdown-toggle {
            padding-left: 78px;
            padding-right: 78px;
        }

        .icon-button {
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            outline: none;
            border: 0;
            background: transparent;
        }

        .viewadd {
            background: url(../../../../images/plus-with-circle.png) no-repeat;
            width: 29px;
            height: 37px;
            display: block;
            position: relative;
            background-size: 100%;
            float: right;
        }

        .closeimg {
            background: url(../../../../images/close-circle.png) no-repeat;
            width: 35px;
            height: 37px;
            display: block;
            position: relative;
            background-size: 100%;
            float: right;
            margin-left: -3px;
        }
        /* Added by Abuzar on 02/02/2021 starts*/
        .select[multiple], select[size] {
            display:none;
        }
        .dropdown-menu > li > a {
            padding: 2px 30px;
        }
        /* Added by Abuzar on 02/02/2021 ends*/
        /*.ajax__calendar
        {
            z-index: 100px;
        }
        .form-submit-button
        {
            box-shadow: none !important;
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .transbox
        {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier 
            z-index: inherit;
        }
        
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        
        .btn-tab
        {
            color: #3c763d;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }
        
        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus
        {
            color: #555555;
            background-color: #dff0d8;
        }
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
        }*/

        ul#menu li a:active {
            background: white;
        }



        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {


            $("th").click(function () {
                var columnIndex = $(this).index();
                var tdArray = $(this).closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")");
                tdArray.sort(function (p, n) {
                    var pData = $(p).text();
                    var nData = $(n).text();
                    return pData < nData ? -1 : 1;
                });
                tdArray.each(function () {
                    var row = $(this).parent();
                    $("#dgCntst").append(row);
                });
            });
        })
        function PopulateLDFrom() {
            //minDate:new Date()
            $("#<%= txtLDFrom.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function PopulateLDTo() {
            //minDate:new Date()
            $("#<%= txtLDto.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function PopulateTDFrom() {
            //minDate:new Date()
            $("#<%= txtTDFrom.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function PopulateTDTo() {
            //minDate:new Date()
            $("#<%= txtTDto.ClientID  %>").datepicker({
                changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function checkDate() {
            debugger;
            var fromDate = $('#<%= txtLDFrom.ClientID  %>').val();
            var toDate = $('#<%= txtLDto.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";
            debugger;
            if (fromDate != "" && toDate != "") {
                if (!checkDateIsGreaterThanToday(fromDate, toDate)) {
                    alert("Login From Date should not be greater than Login To Date.");
                    document.getElementById("<%= txtLDFrom.ClientID %>").value = "";
                    return false;
                }
                else {
                    // CheckDateWithinDate();
                }
            }
            else {
                // alert("Please Select Date");
            }
        }

        function checkDateIsGreaterThanToday(fromDay, toDay) {
            debugger;
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
    </script>
    <script type="text/javascript">
        function fnCallPOP() {
            debugger;
            var ActSchKey = document.getElementById("<%=txtrtgschKey.ClientID%>").value;
            $find("mdlPopBIDHybrid").show();
            var Mode = "B";
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = ("FRMCtgStpDtlsPopUp.aspx?&ActSchKey=" + ActSchKey + "&Mode=" + Mode + "&mdlpopup=mdlPopBIDHybrid");
            // document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopBulkCatgUpd.aspx";
            return false;
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
        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }
        function callsearch() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }
    </script>
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
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

    <style type="text/css">
        .radio-group label {
            overflow: hidden;
        }

        .radio-group input {
            /* This is on purpose for accessibility. Using display: hidden is evil. This makes things keyboard friendly right out tha box! */
            height: 1px;
            width: 1px;
            position: absolute;
            top: -20px;
        }

        .radio-group .not-active {
            color: #3276b1;
            background-color: #fff;
        }
    </style>

    <center>
    
            <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel" >
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblhdr" Text="Add Scheme Details" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;display:none;" class="panel-body">
                <div id="defaultdiv" class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblrtgschKey" Text="Category Scheme Key" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtrtgschKey" runat="server" Enabled="false" CssClass="form-control" TabIndex="1"
                                    MaxLength="20" placeholder="Category Scheme Key" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="ftxRulNo" runat="server" FilterType="Numbers"
                                    TargetControlID="txtrtgschKey">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblweightage" Text="Weightage" runat="server" CssClass="control-label; required" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtweightage" runat="server" CssClass="form-control" TabIndex="2"
                                    MaxLength="20" placeholder="Weightage" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                    TargetControlID="txtweightage">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div id="divFixfactor" runat="server" style="width: 97%;" class="panel">
                    <div id="divfixHeading" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfixBody','fixfactorImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblfixfactors" Text="Fix factors" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                     <span id="fixfactorImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divfixBody" runat="server" style="width: 96%;" class="panel-body">
                        <%--<div id="divFixFactorLOBandPCbody" class="row" style="margin-bottom: 5px;" runat="server">--%>
                        <div class="col-sm-6">
                            <div id="divLob" runat="server" class="row" style=" display:none; margin-bottom:auto" >
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lbllob" Text="LOB"   runat="server" CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server"  class="bottomspace" >
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddllob" runat="server"  CssClass="select2-container form-control" placeholder="SELECT LOB"
                                                TabIndex="4">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                            </div>

                             <div id="divPT" runat="server" class="row" style="display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblpolicyType" Text="Policy Type"    runat="server"  CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlpolicyType" runat="server" CssClass="select2-container form-control"
                                                placeholder="SELECT POLICYTYPE" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                 <br />
                            </div>


                             <div id="divPDT" runat="server" class="row" style="display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblPDT" Text="Policy Category"    runat="server"  CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel28" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DdlPDT" runat="server" CssClass="select2-container form-control"
                                                placeholder="SELECT PRODUCT CATEGORY" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                 <br />
                            </div>


                             
                             </div>
                           <div class="col-sm-6">

                               <div id="divPC" runat="server" class="row" style="display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblPC" Text="Product Code"    runat="server" CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlProductCode" runat="server"   CssClass="select2-container form-control"
                                                placeholder="SELECT PRODUCT CODE" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div><br />
                            </div>

                                <div id="divCPC" runat="server" class="row" style="display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblCPC" Text="Combo Product Code"    runat="server" CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlCPC" runat="server"   CssClass="select2-container form-control"
                                                placeholder="SELECT COMBO PRODUCT CODE" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div><br />
                            </div>


                               <div id="divVPSC" runat="server" class="row" style="display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="LblVPSC" Text="VPSC Flag"    runat="server" CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel27" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DdlVpscFlag" runat="server"   CssClass="select2-container form-control"
                                                placeholder="VPSC FLAG" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div><br />
                            </div>
                               
                        </div>


                         <div class="col-sm-6">
                              <div id="divFixFactorSELFIandULIPbody" runat="server" class="row" style="margin-bottom: 5px ; display:none">
                            <div id="divSELFI" runat="server">
                                <div class="col-sm-6" style="text-align: left" >
                                    <asp:Label ID="lblSELFIflag" Text="SELFI Flag" runat="server"  CssClass="control-label; required"  />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlSELFIflag" runat="server"    CssClass="select2-container form-control"
                                               placeholder="SELECT SELFIFLAG" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
<br />
                        </div>
                           
                              <div id="divSPC" runat="server" class="row" style="display:none" >
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblsubProductCode" Text="Sub Product Code" runat="server"  CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlsubProductCode" runat="server"   CssClass="select2-container form-control"
                                               placeholder="SELECT SUBPRODUCT" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div> <br />
                            </div>
                            <div id="divULIP" runat="server" class="row" style="margin-bottom: 5px; display:none">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblULIP" Text="ULIP + Protection" runat="server"  CssClass="control-label; required" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" class="bottomspace">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlULIP" runat="server"    CssClass="select2-container form-control"
                                               placeholder="SELECT ULIP + Protection" TabIndex="4"  class="bottomspace" >
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div><br />
                            </div>
                        </div>
                    </div>


                    

                </div>

                 <div id="divRangeFactor" runat="server" style="width: 97%;" class="panel">
                    <div id="divrangeHeading" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRangeBody','rangefactorImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblrangefactors" Text="Range factors" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                     <span id="rangefactorImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divRangeBody" runat="server" style="width: 96%;" class="panel-body">
                        
                        <div id="divRangeFactorPTFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPayTermFrom" Text="Pay Term From" runat="server"   CssClass="control-label; required"   />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPayTermFrom" onchange="isNumber(this)" runat="server" CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Pay Term From" onkeypress='return isNumber(event)'  />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" 
                                            TargetControlID="txtPayTermFrom" FilterType="Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPayTermTo" Text="Pay Term To" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPayTermTo" runat="server"   CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Pay Term To" onkeypress='return isNumber(event)' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" 
                                            TargetControlID="txtPayTermTo" FilterType="Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div id="divRangeFactorPWTFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPremiumWTaxFrom" Text="Premium With Tax From" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPremiumWTaxFrom" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Premium With Tax From" onkeypress='return validateFloatKeyPress(this,event);' />
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                            TargetControlID="txtPremiumWTaxFrom" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPremiumWTaxTo" Text="Premium With Tax To" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPremiumWTaxTo" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Premium With Tax To" onkeypress='return validateFloatKeyPress(this,event);' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            TargetControlID="txtPremiumWTaxTo" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div id="divRangeFactorPWOTFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPremiumWOTaxFrom" Text="Premium Without Tax From" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPremiumWOTaxFrom" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Premium Without Tax From" onkeypress='return validateFloatKeyPress(this,event);' />
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" 
                                            TargetControlID="txtPremiumWOTaxFrom" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPremiumWOTaxTo" Text="Premium Without Tax To" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPremiumWOTaxTo" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Premium Without Tax To" onkeypress='return validateFloatKeyPress(this,event);' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            TargetControlID="txtPremiumWOTaxTo" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div id="divRangeFactorLDFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblLDFrom" Text="LogIn Date From" runat="server"  CssClass="control-label; required"  />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtLDFrom" runat="server" CssClass="form-control" onmousedown="PopulateLDFrom()"
                                            onmouseup="PopulateLDFrom()" placeholder="DD/MM/YYYY"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblLDto" Text="LogIn Date To" runat="server"    CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtLDto"  runat="server"  CssClass="form-control" onmousedown="PopulateLDTo()"
                                            onmouseup="PopulateLDTo()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div id="divRangeFactorTDFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTDFrom" Text="Transaction Date From" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtTDFrom"   runat="server"  CssClass="form-control" onmousedown="PopulateTDFrom()"
                                            onmouseup="PopulateTDFrom()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTDto" Text="Transaction Date To" runat="server"   CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtTDto" runat="server"  CssClass="form-control" onmousedown="PopulateTDTo()"
                                            onmouseup="PopulateTDTo()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                         <div id="divRangeFactorANPFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblANPFrom" Text="ANP From" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtANPFrom" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="ANP From" onkeypress='return validateFloatKeyPress(this,event);' />
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" 
                                            TargetControlID="txtANPFrom" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblANPTO" Text="ANP To" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtANPTo" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="ANP To" onkeypress='return validateFloatKeyPress(this,event);' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                            TargetControlID="txtANPTo" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                         <div id="divRangeFactorWNBPFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblWNBPFrom" Text="WNBP From" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtWNBPFrom" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="WNBP From" onkeypress='return validateFloatKeyPress(this,event);' />
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" 
                                            TargetControlID="txtWNBPFrom" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblWNBPTo" Text="WNBP To" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtWNBPTo" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="WNBP To" onkeypress='return validateFloatKeyPress(this,event);' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                            TargetControlID="txtWNBPTo" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                     <%--   DFP--%>

                         <div id="divRangeFactorDFPFromTo" class="row" style="margin-bottom: 5px; display:none" runat="server">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDEPFrom" Text="Deferment Period From" runat="server"  CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDEPFrom" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Deferment Period From" onkeypress='return validateFloatKeyPress(this,event);' />
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" 
                                            TargetControlID="txtDEPFrom" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label5" Text="Deferment Period To" runat="server" CssClass="control-label; required" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDEPTo" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="20" placeholder="Deferment Period To" onkeypress='return validateFloatKeyPress(this,event);' />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                            TargetControlID="txtDEPTo" FilterType="Custom, Numbers" ValidChars="+-=/*()." >
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>




                    </div>

                </div>

                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-sample onhover" OnClick="btnAddNew_Click" OnClientClick="return validatefields(); ">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample onhover" OnClick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample onhover" Visible="false" OnClick="btnClear_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                                </asp:LinkButton>
                                
                                
    </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        
        
    </center>


    <%--///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>

    <center>
        <div id="divpnlBlkUpd" runat="server" style="width: 97%;" class="panel">
            <div id="DivpnlhdBlkUpd" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpnlbdyBlkUpd','myImgBlkUpd');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label1" Text="Bulk Upload Details" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImgBlkUpd" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divpnlbdyBlkUpd" runat="server" style="width: 96%;" class="panel-body">
                <div id="defaultdivBlkUpd" class="row" style="margin-bottom: 5px;display:none;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCtgSchKeyBlkUpd" Text="Category Scheme Key" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCtgSchKeyBlkUpd" runat="server" CssClass="form-control" TabIndex="1"
                                    MaxLength="10" placeholder="Category Scheme Key" />
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblweightageBlkUpd" Text="Weightage" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtweightageBlkUpd" runat="server" CssClass="form-control" TabIndex="2"
                                    MaxLength="10" placeholder="Weightage" />
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div id="divpnlFixfactorBlkUpd" runat="server" style="width: 97%;" class="panel">
                    <div id="divpnlhdFixfactorBlkUpd" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpnlbdyFixfactorBlkUpd','hdfixfactorImgBlkUpd');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblhdfixfactorBlkUpd" Text="Fix factors" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                     <span id="hdfixfactorImgBlkUpd" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>

                    <div id="divpnlbdyFixfactorBlkUpd" runat="server" style="width: 96%;" class="panel-body">
                        <div id="divFixFactorLOBandPCbodyBlkUpd" class="row" style="margin-bottom: 5px;">
                            <div id="divLobBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblLOBBlkUpd" Text="LOB" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlLOBBlkUpd"  Enabled="false" runat="server" AutoPostBack="true"  CssClass="select2-container form-control" style="width:228px;margin-right:22px;"
                                                TabIndex="4" OnSelectedIndexChanged="ddlLOBBlkUpd_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div id="divProductCodeBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblProdCodeBlkUpd" Text="Product Code"  runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                        <ContentTemplate>
                                    <asp:ListBox ID="lstProdCodeBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                            </ContentTemplate>
                                        <Triggers  >

                                            <asp:AsyncPostBackTrigger ControlID="ddlLOBBlkUpd" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                     
                        <%--TALIC NEW FIX PARAMETER START --%>

                           <div id="divFixFactorPolTypeandPolicyCategory" class="row" style="margin-bottom: 5px;">
                            <div id="div9" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblPDTBlkUpd" Text="Policy Category" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstPDTBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                           <div id="divPolicyTypBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblPolicyTypBlkUpd" Text="Policy Type" runat="server"  CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstPolicyTypBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>


                         <div id="divFixFactorVPSCandComboproduct" class="row" style="margin-bottom: 5px;">
                            <div id="divVPSCBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblVPSCBlkUpd" Text="VPSC Flag" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstVPSCFlagBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                           <div id="divCPCBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblCPCBlkUpd" Text="Combo Product" runat="server"  CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                         <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                        <ContentTemplate>

                                    </updatepanel>
                                    <asp:ListBox ID="lstCPCBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                     </ContentTemplate>
                                        <Triggers  >

                                            <asp:AsyncPostBackTrigger ControlID="ddlLOBBlkUpd" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                           <%--TALIC NEW FIX PARAMETER END --%>




                           <div id="divFixFactorPTandSPCbodyBlkUpd" class="row" style="margin-bottom: 5px;display:none;">
                            <div id="divSubProductCodeBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSubProductCodeBlkUpd" Text="Sub Product Code" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstSubProductCodeBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                            
                        </div>

                        <div id="divFixFactorSELFIandULIPbodyBlkUpd" class="row" style="margin-bottom: 5px; display:none;">
                            <div id="divSELFIFlgBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSELFIFlgBlkUpd" Text="SELFI Flag" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstSELFIFlgBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                            <div id="divULIPBlkUpd" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblULIPBlkUpd" Text="ULIP + Protection" runat="server"  CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstULIPBlkUpd" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div id="divFixFactorEPAYandMSCbodyBlkUpd" class="row" style="margin-bottom: 5px;display:none;">
                            <div id="divEPAY" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblEPAY" Text="E PAY Flag" runat="server" CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstepay" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>

                            <div id="divMSC" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblmsc" Text="Miscellaneous" runat="server"  CssClass="control-label required" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:ListBox ID="lstmscbox" Enabled="false" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>






                        <div id="divGeographicalLoc" runat="server" style="width: 97%;display:none;" class="panel" >
                            <div id="divGeoLocHeading" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divGeoLocBody','geoLocImg');return false;">
                                 <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblpnlgeoloc" Text="Geographical Location" Font-Size="19px" runat="server" />
                                    </div>
                                    <div class="col-sm-2">
                                                <span id="geoLocImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                 </div>
                            </div>
                            
                           <asp:updatepanel runat="server">
                             <contenttemplate>
                                 <div id="divGeoLocBody" runat="server" style="width: 96%;" class="panel-body">
                                <div id="divHOandHUBZonal" class="row" style="margin-bottom: 5px;">
                                   <div id="divHO" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblHO" Text="Head Office" runat="server" CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxHO" Enabled="true" runat="server" SelectionMode="Single" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxHO_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                   </div>

                                   <div id="divHUBZonal" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblHUBZonal" Text="Hub Zonal" runat="server"  CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxHubZonal" Enabled="true" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxHubZonal_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                  </div>
                                </div>
                                <div id="divZonalandStateOffice" class="row" style="margin-bottom: 5px;">
                                   <div id="div1" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblZonal" Text="Zonal Office" runat="server" CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxZonal" Enabled="true" runat="server" SelectionMode="Multiple"  AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxZonal_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                   </div>

                                   <div id="div2" runat="server">
                                      
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblStateOffc" Text="State Office" runat="server"  CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxStateOffc" Enabled="true" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxStateOffc_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                                 
                                  </div>
                                </div>
                                <div id="divRegionalandAreaOffice" class="row" style="margin-bottom: 5px;">
                                   <div id="div3" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblRegionOffc" Text="Regional Office" runat="server" CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxRegionOffc" Enabled="true" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxRegionOffc_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                   </div>

                                   <div id="div4" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblAreaOffc" Text="Area Office" runat="server"  CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxAreaOffc" Enabled="true" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxAreaOffc_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                  </div>
                                </div>
                                <div id="divBranchandSalesUnit" class="row" style="margin-bottom: 5px;">
                                   <div id="div5" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblBranchOffc" Text="Branch Office" runat="server" CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxBranchOffc" Enabled="true" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxBranchOffc_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                   </div>

                                   <div id="div7" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblSalesUnit" Text="Sales Unit" runat="server"  CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxSalesUnit"  Enabled="false" runat="server" SelectionMode="Multiple" AutoPostBack="true"
                                            OnSelectedIndexChanged="ListBoxSalesUnit_SelectedIndexChanged"></asp:ListBox>
                                        </div>
                                  </div>
                                </div>
                                 <div id="divSubSalesUnit" class="row" style="margin-bottom: 5px;">
                                   <div id="div8" runat="server">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblSubSalesUnit" Text="Sub Sales Unit" runat="server" CssClass="control-label required" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ListBox ID="ListBoxSubSalesUnit" Enabled="true" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                   </div>

                                   
                                </div>

                            </div>

                             </contenttemplate>
                          </asp:updatepanel>
                    </div>




                    </div>

                </div>

                <div id="divpnlRangefactorBlkUpd" runat="server" style="width: 97%;" class="panel">
                    <div id="divpnlhdRangefactorBlkUpd" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpnlbdyRangefactorBlkUpd','pnlhdrangefactorImgBlkUpd');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblpnlhdRangefactorBlkUpd" Text="Range factors" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                     <span id="pnlhdrangefactorImgBlkUpd" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divpnlbdyRangefactorBlkUpd" runat="server" style="width: 96%;" class="panel-body">
                        <div id="divRangeFactorPTFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                        <div id="divRangeFactorPWTFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                        <div id="divRangeFactorPWOTFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                        <div id="divRangeFactorWNBPFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                         <div id="divRangeFactorDFPFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                         <div id="divRangeFactorANPFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>

                        



                        <div id="divRangeFactorLDFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                        </div>
                        <div id="divRangeFactorTDFromToBlkUpd" runat="server" class="row" style="margin-bottom: 5px;">
                             </div>
                    </div>   
                       <%-- <div id="InnerAnsBody" class="row" style="margin-bottom: 5px;">
                           <div class="col-sm-3" style="text-align:left">
                             <label ID ="lblInAnsw" Class="control-label">Pay Term From</Label>
                           </div>
                           <div class="col-sm-3">
                                <input type="text" Class="form-control">
                           </div>
                           <div class="col-sm-3" style="text-align:left">
                             <label ID ="lblInAnsw1" Class="control-label">Pay Term To</Label>
                           </div>
                           <div class="col-sm-3">
                                <input type="date" Class="form-control">
                           </div>
                         </div>--%>
                       <%-- <div id="divRangeFactorPTFromToBlkUpd" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPTFromBlkUpd" Text="Pay Term From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPTFromBlkUpd" runat="server" CssClass="form-control" TabIndex="1"
                                            MaxLength="8" placeholder="Rule Number" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPTToBlkUpd" Text="Pay Term To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPTToBlkUpd" runat="server"  CssClass="form-control" TabIndex="1"
                                            MaxLength="8" placeholder="Rule Number" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                       <%-- <div id="divRangeFactorPWOTFromToBlkUpd" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPWOTFromBlkUpd" Text="Premium With Tax From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPWOTFromBlkUpd" runat="server" CssClass="form-control" TabIndex="1"
                                            MaxLength="8" placeholder="Rule Number" />
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPWOTToBlkUpd" Text="Premium With Tax To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" >
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPWOTToBlkUpd" runat="server" CssClass="form-control" TabIndex="1"
                                            MaxLength="8" placeholder="Rule Number" />
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                       <%--<div id="divRangeFactorLDFromToBlkUpd" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblLDFromBlkUpd" Text="LogIn Date From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtLDFromBlkUpd" runat="server" CssClass="form-control" onmousedown="PopulateLDFrom()"
                                            onmouseup="PopulateLDFrom()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblLDToBlkUpd" Text="LogIn Date To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtLDToBlkUpd" runat="server" CssClass="form-control" onmousedown="PopulateLDTo()"
                                            onmouseup="PopulateLDTo()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                       <%--<div id="divRangeFactorTDFromToBlkUpd" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTDFromBlkUpd" Text="Transaction Date From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtTDFromBlkUpd" runat="server"  CssClass="form-control" onmousedown="PopulateTDFrom()"
                                            onmouseup="PopulateTDFrom()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblTDToBlkUpd" Text="Transaction Date To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtTDToBlkUpd" runat="server"  CssClass="form-control" onmousedown="PopulateTDTo()"
                                            onmouseup="PopulateTDTo()" placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                </div>

                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                         <%--<asp:LinkButton ID="btnGenerate" runat="server"  OnClientClick="fnCallSave();" CssClass="btn btn-sample" TabIndex="32">
                            <span   class="glyphicon glyphicon-plus BtnGlyphicon" style="color:white"></span>  Generate File
                        </asp:LinkButton>--%>
                        <button id="btnGenerate"  type="button" Class="btn btn-sample" style="color:white;"> <span class="glyphicon glyphicon-edit" style="color:white;"></span>  Generate File</button>
                        <button id="btnblkUpd"  type="button" onclick="fnCallPOP();" style="color:white;" Class="btn btn-sample"> <span class="glyphicon glyphicon-upload" style="color:white;"></span>  Bulk Upload</button>
                        <asp:LinkButton ID="btnDnldGridData"  runat="server"   style="color:white;" CssClass="btn btn-sample" TabIndex="32" OnClick="btnDnldGridData_Click">
                            <span   class="glyphicon glyphicon-plus BtnGlyphicon" style="color:white"></span> Download
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample onhover" OnClick="btnCancel_Click">
                                    <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                        <asp:Button ID="lnlGenExcelFile" runat="server" CssClass="btn btn-sample" style="display:none;color:white;"  OnClick="lnlGenExcelFile_Click1">
                        </asp:Button>
                        <%--<asp:UpdatePanel ID="UpdatePanel26" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lnlGenExcelFile" runat="server" CssClass="btn btn-sample" OnClick="lnlGenExcelFile_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Generate File
                                </asp:LinkButton>

                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>

                      <%--Added by rutuja grid --%>
            <asp:UpdatePanel ID="UpdatePanel00" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 100%;" class="panel">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divGridRslts','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               
                                <asp:Label ID="lblCmpSrch" Text="Scheme Results" style="font-size:19px;" runat="server" />
                                <%-- <span style="color: red;">*</span>  --%>
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                       
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divGridRslts" runat="server" style="width: 100%;" class="">
                <div id="divGrid" runat="server" style="width: 99%;overflow:auto" >
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvcatgStp" runat="server" AutoGenerateColumns="false" Width="97% "
                                    PageSize="10" AllowSorting="True" OnSorting="gvcatgStp_Sorting" AllowPaging="true"
                                    CssClass="footable" OnRowDataBound="gvcatgStp_RowDataBound" AutoGenerateEditButton="true" OnRowEditing="gvcatgStp_RowEditing"  
                                     OnRowCancelingEdit="btnCancel_Click1"  OnRowUpdating="gvcatgStp_RowUpdating" ShowHeaderWhenEmpty="True"
                                     emptydatatext="No Record Found.">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    
                                    
                                </asp:GridView>

                                <div class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                          
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       </div>
                        </div>
                     </div>


            </ContentTemplate>
        </asp:UpdatePanel>
            <%--ended by rutuja grid --%>
        </div>
        <asp:HiddenField id="respJSON" runat="server"/>
        <asp:Panel runat="server" Height="365px" Width="863px" ID="Panel1" display="none" Style="text-align: center;top:59px !important; padding: 5px;left:-22px;" CssClass="panel panel-success">
            <iframe runat="server" id="Iframe1" scrolling="yes" width="80%" frameborder="0" display="none" style="height: 100%; "></iframe>
        </asp:Panel>
        <asp:Label runat="server" ID="Label10" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDHybrid"
        DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg"  X="-4" Y="0">
        </ajaxToolkit:ModalPopupExtender>

        <asp:HiddenField ID="hiddenField1" runat="server" />
        
         <div id="divLoading">
        </div>

                    
    </center>

  <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>--%>

 <%--    <script src='<%= ResolveUrl("~/assets/scripts/jquery.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap-multiselect.js") %>'></script>--%>


     <script type="text/javascript" src="../../../../assets/scripts/jquery.min.js"></script>
       <script type="text/javascript" src="../../../../assets/scripts/bootstrap.min.js"></script>
       <script type="text/javascript" src="../../../../assets/scripts/bootstrap-multiselect.js"></script>
    <script type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../../assets/scripts/moment.js"></script>

    <script>

        function ShowProgress() {
            debugger;
            $("div#divLoading").addClass('show');
        }
        function HideShowProgress() {
            debugger;
            $("div#divLoading").removeClass('show');
        }

        $(document).ready(function () {
            debugger;


            var lstBox = ['#<%= lstProdCodeBlkUpd.ClientID%>', '#<%= lstPolicyTypBlkUpd.ClientID%>', '#<%= lstSubProductCodeBlkUpd.ClientID%>', '#<%= lstSELFIFlgBlkUpd.ClientID%>', '#<%= lstSELFIFlgBlkUpd.ClientID%>', '#<%= lstULIPBlkUpd.ClientID%>', '#<%= lstepay.ClientID%>', '#<%= lstmscbox.ClientID%>', '#<%= ListBoxHO.ClientID%>'
                , '#<%= ListBoxHubZonal.ClientID%>', '#<%= ListBoxZonal.ClientID%>'
                , '#<%= ListBoxStateOffc.ClientID%>', '#<%= ListBoxRegionOffc.ClientID%>'
                , '#<%= ListBoxAreaOffc.ClientID%>', '#<%= ListBoxBranchOffc.ClientID%>'
                , '#<%= ListBoxSalesUnit.ClientID%>', '#<%= ListBoxSubSalesUnit.ClientID%>'
                , '#<%= lstCPCBlkUpd.ClientID%>', '#<%= lstPDTBlkUpd.ClientID%>'
                  , '#<%= lstVPSCFlagBlkUpd.ClientID%>'

            ]
            for (var i = 0; i < lstBox.length; i++) {
                $(lstBox[i]).multiselect({
                    includeSelectAllOption: true,
                });
            }
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            var lstBox = ['#<%= lstProdCodeBlkUpd.ClientID%>', '#<%= lstPolicyTypBlkUpd.ClientID%>'
                , '#<%= lstSubProductCodeBlkUpd.ClientID%>', '#<%= lstSELFIFlgBlkUpd.ClientID%>'
                , '#<%= lstSELFIFlgBlkUpd.ClientID%>', '#<%= lstULIPBlkUpd.ClientID%>'
                , '#<%= lstepay.ClientID%>', '#<%= lstmscbox.ClientID%>', '#<%= ListBoxHO.ClientID%>'
                , '#<%= ListBoxHubZonal.ClientID%>', '#<%= ListBoxZonal.ClientID%>'
                , '#<%= ListBoxStateOffc.ClientID%>', '#<%= ListBoxRegionOffc.ClientID%>'
                , '#<%= ListBoxAreaOffc.ClientID%>', '#<%= ListBoxBranchOffc.ClientID%>'
                , '#<%= ListBoxSalesUnit.ClientID%>', '#<%= ListBoxSubSalesUnit.ClientID%>'
                , '#<%= lstCPCBlkUpd.ClientID%>', '#<%= lstPDTBlkUpd.ClientID%>'
                , '#<%= lstVPSCFlagBlkUpd.ClientID%>'

            ]
            for (var i = 0; i < lstBox.length; i++) {
                $(lstBox[i]).multiselect({
                    includeSelectAllOption: true,
                });
            }
        });



        function callDate(obj) {
            debugger
            //$(this).closest("[name ^= '" + obj + "']").datepicker({ minDate: new Date(), changeMonth: true, changeYear: true, dateFormat: 'dd-mm-yy' });
            var dateArr = $(obj).val().split('-');
            $(obj).datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd/mm/yy' });
            $.datepicker.initialized = true;
            $(obj).focus();
        }
        var PTFromTonumber = 1
        var PWTFromTonumber = 1
        var PWOTFromTonumber = 1
        
        var ANPFromTonumber = 1

        var WNBPFromTonumber=1
        var LDnumber = 1
        var TDnumber = 1

        var DFPFromTonumber = 1
        function customAddClick(mainDiv, runtimeDiv, toBindDiv, divDesc, lblName) {
            debugger;
            var counter = 1;
            if (divDesc == "PT") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), PTFromTonumber, divDesc, lblName));
                PTFromTonumber += 1;
            }
            if (divDesc == "PWT") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), PWTFromTonumber, divDesc, lblName));
                PWTFromTonumber += 1;
            }
            if (divDesc == "PWOT") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), PWOTFromTonumber, divDesc, lblName));
                PWOTFromTonumber += 1;
            }


            if (divDesc == "ANP") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), ANPFromTonumber, divDesc, lblName));
                ANPFromTonumber += 1;
            }

            if (divDesc == "WNBP") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), WNBPFromTonumber, divDesc, lblName));
                WNBPFromTonumber += 1;
            }

            if (divDesc == "DFP") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), DFPFromTonumber, divDesc, lblName));
                DFPFromTonumber += 1;
            }


            if (divDesc == "LD") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), LDnumber, divDesc, lblName));
                LDnumber += 1;
            }


            if (divDesc == "TD") {
                $(toBindDiv).append(customGetDynamicTxtBox(mainDiv, runtimeDiv, parseInt(counter), TDnumber, divDesc, lblName));
                TDnumber += 1;
            }
        }

        function customGetDynamicTxtBox(mainDiv, runtimeDiv, counter, number, divDesc, lblName) {
            debugger;
            var desc = divDesc;
            if (divDesc == "LD" || divDesc == "TD") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" onclick="callDate(this)" readonly name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="' + lblName + ' From" maxlength="20" onkeypress="return isNumber(event)" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" onclick="callDate(this)" readonly name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="' + lblName + ' To" maxlength="20" onkeypress="return isNumber(event)"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }
            else if (divDesc == "PWT") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="Premium with Tax From" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="Premium with Tax To" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }

                //resolve error 09072020_ARJ
            else if (divDesc == "PWOT") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="Premium without Tax From" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="Premium without Tax To" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }
            else if (divDesc == "ANP") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="Premium without Tax From" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="Premium without Tax To" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }
            else if (divDesc == "WNBP") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="Premium without Tax From" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="Premium without Tax To" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }

            else if (divDesc == "DFP") {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="Premium without Tax From" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="Premium without Tax To" maxlength="20" onkeypress="return validateFloatKeyPress(this,event);"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }




            else {
                return '<div id = "' + mainDiv + number + '"><div id="' + runtimeDiv + number + '"><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'FromBlkUpd' + (counter + 1) + '" Class="control-label required">' + lblName + ' From <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name = "txt' + divDesc + 'FromBlkUpd' + number + '" placeholder="' + lblName + ' From" maxlength="20" onkeypress="return isNumber(event)" Class="form-control"></div><div class="col-sm-2" style="text-align:left"><label ID ="lbl' + divDesc + 'ToBlkUpd' + number + '" Class="control-label required">' + lblName + ' To <span class="counter"> ' + (number + 1) + '</span></Label></div><div class="col-sm-3"><input type="text" name="txt' + divDesc + 'ToBlkUpd' + number + '" placeholder="' + lblName + ' To" maxlength="20" onkeypress="return isNumber(event)"  Class="form-control"></div><div class="col-sm-2"><button id="btnRemove' + divDesc + 'To"  class="icon-button" type = "button"><span style = "font-size:x-large" class="closeimg"></span></button></div></div></div>'
            }
            //onclick="closeDiv(' + mainDiv + ',\'' + desc + '\')"
        }

        function update_Index(index, div) {
            debugger;
            var a = $("[id ^= '" + div + "']");
            for (var i = 0; i < a.length; i++) {
                var counter = $(a[i]).find('.counter');
                for (var j = 0; j < counter.length; j++) {
                    $(counter[j]).html(i + 1)
                }
            }
        }

        //function closeDiv(divMain, divDesc) {
        //    debugger;
        //    var a = $(this).closest("[id ^= '" + divMain.id + "']")
        //    $(a).siblings().find()
        //    var labels = $(a).siblings().find('[id ^= "lbl' + divDesc + 'FromBlkUpd"]');
        //    if (confirm('Are you sure you want to delete?')) {
        //        $(a).remove();
        //        PTFromTonumber = PTFromTonumber - 1;
        //        update_Index(PTFromTonumber, divMain);
        //    }
        //}

        $(document).on("click", "#btnRemovePTTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divPTFromandToBody']")
            var counter = $(a)[0].id.substring("divPTFromandToBody".length);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblPTFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                PTFromTonumber = PTFromTonumber - 1;
                update_Index(PTFromTonumber, "divPTFromandToBody");
            }
        });
        $(document).on("click", "#btnRemovePWTTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divPWTFromandToBody']")
            var counter = $(a)[0].id.substring("divPWTFromandToBody".length);
            var hdnValue = $("#addPWTTo" + counter).val();
            $("#addPWTTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblPWTFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                PWTFromTonumber = PWTFromTonumber - 1;
                update_Index(PWTFromTonumber, "divPWTFromandToBody");
            }

        });
        $(document).on("click", "#btnRemovePWOTTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divPWOTFromandToBody']")
            var counter = $(a)[0].id.substring("divPWOTFromandToBody".length);
            var hdnValue = $("#addPWOTTo" + counter).val();
            $("#addPWOTTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblPWOTFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                PWOTFromTonumber = PWOTFromTonumber - 1;
                update_Index(PWOTFromTonumber, "divPWOTFromandToBody");
            }

        });
        $(document).on("click", "#btnRemoveLDTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divLDFromandToBody']")
            var counter = $(a)[0].id.substring("divLDFromandToBody".length);
            var hdnValue = $("#addLDFromTo" + counter).val();
            $("#addLDFromTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblLDFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                LDnumber = LDnumber - 1;
                update_Index(LDnumber, "divLDFromandToBody");
            }

        });
        $(document).on("click", "#btnRemoveTDTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divTDFromandToBody']")
            var counter = $(a)[0].id.substring("divTDFromandToBody".length);
            var hdnValue = $("#addTDFromTo" + counter).val();
            $("#addTDFromTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblTDFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                TDnumber = TDnumber - 1;
                update_Index(TDnumber, "divTDFromandToBody");
            }

        });


        //09072020_arj btnRemoveWNBPTo  btnRemoveWNBPTo

        $(document).on("click", "#btnRemoveWNBPTo", function () {
            debugger;

            var a = $(this).closest("[id ^= 'divWNBPFromandToBody']")
            var counter = $(a)[0].id.substring("divWNBPFromandToBody".length);
            var hdnValue = $("#addWNBPFromTo" + counter).val();
            $("#addWNBPFromTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblWNBPFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                WNBPFromTonumber = WNBPFromTonumber - 1;
                update_Index(WNBPFromTonumber, "divWNBPFromandToBody");
            }

        });

        $(document).on("click", "#btnRemoveANPTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divANPFromandToBody']")
            var counter = $(a)[0].id.substring("divANPFromandToBody".length);
            var hdnValue = $("#addLDFromTo" + counter).val();
            $("#addLDFromTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblANPFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                ANPFromTonumber = ANPFromTonumber - 1;
                update_Index(ANPFromTonumber, "divANPFromandToBody");
            }

        });


      



        $(document).on("click", "#btnRemoveDFPTo", function () {
            debugger;
            var a = $(this).closest("[id ^= 'divDFPFromandToBody']")
            var counter = $(a)[0].id.substring("divDFPFromandToBody".length);
            var hdnValue = $("#addLDFromTo" + counter).val();
            $("#addLDFromTo" + counter).val(parseInt(hdnValue) - 1);
            $(a).siblings().find()
            var labels = $(a).siblings().find('[id ^= "lblDFPFromBlkUpd"]');
            if (confirm('Are you sure you want to delete?')) {
                $(a).remove();
                DFPFromTonumber = DFPFromTonumber - 1;
                update_Index(DFPFromTonumber, "divDFPFromandToBody");
            }

        });
    </script>
    <script>


        var divExists = []
        var divExistsName = []
        $("#btnGenerate").on("click", function () {
            //function fnCallSave(){
            debugger;
            //var myExtender = $find('ProgressBarModalPopupExtender1');
            //myExtender.show();
            //return true;
            if ($("[id = 'divPTFromandToInnerBody']").length) {
                divExists.push("divPTFromandToInnerBody");
                divExistsName.push("PPT");
            }
            if ($("[id = 'divPWTFromandToInnerBody']").length) {
                divExists.push("divPWTFromandToInnerBody");
                divExistsName.push("PWT");
            }
            if ($("[id = 'divPWOTFromandToInnerBody']").length) {
                divExists.push("divPWOTFromandToInnerBody");
                divExistsName.push("PWOT");
            }
            if ($("[id = 'divLDTFromandToInnerBody']").length) {
                divExists.push("divLDTFromandToInnerBody");
                divExistsName.push("LD");
            }
            if ($("[id = 'divTDTFromandToInnerBody']").length) {
                divExists.push("divTDTFromandToInnerBody");
                divExistsName.push("TD");
            }

            if ($("[id = 'divANPFromandToInnerBody']").length) {
                divExists.push("divANPFromandToInnerBody");
                divExistsName.push("ANP");
            }
            if ($("[id = 'divWNBPFromandToInnerBody']").length) {
                divExists.push("divWNBPFromandToInnerBody");
                divExistsName.push("WNBP");
            }
            if ($("[id = 'divDFPFromandToInnerBody']").length) {
                divExists.push("divDFPFromandToInnerBody");
                divExistsName.push("DFP");
            }


            if (divExists.length >= 0 && divExistsName.length >= 0) {
                var fix = valFixFactors();
                if (fix) {
                    debugger;
                    var range = valRangeFactors();
                    if (range) {
                        debugger;
                        saveData();
                    }
                }
            }
        });
        var objMain = {};
        function getSelectedNames(id, name) {
            var columnNames = "";
            var sel = id;
            var listLength = sel.options.length;
            var valLength = 0;
            objMain[name] = []
            for (var i = 0; i < listLength; i++) {
                var objFF = {};
                if (sel.options[i].selected) {
                    objFF[name] = sel.options[i].value;
                    objMain[name].push(objFF);
                    valLength = 1;
                }
            }
            return valLength;
        }

        function valFixFactors() {

            if (!document.getElementById('<%= ddlLOBBlkUpd.ClientID %>').disabled == true) {
                
            var e = document.getElementById("<%=ddlLOBBlkUpd.ClientID%>");
            var optionSelIndex = e.options[e.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please select LOB in Bulk Upload Section.");
                return false;
            }
            }
            if (!document.getElementById('<%= lstProdCodeBlkUpd.ClientID %>').disabled == true) {
                var prodCodeNames = getSelectedNames(document.getElementById('<%= lstProdCodeBlkUpd.ClientID %>'), 'PC');
                if (prodCodeNames == 0) {
                    alert("Please select Product Code.");
                    return false;
                }

            }
            if (!document.getElementById('<%= lstSubProductCodeBlkUpd.ClientID %>').disabled == true) {
                var subProdCodeNames = getSelectedNames(document.getElementById('<%= lstSubProductCodeBlkUpd.ClientID %>'), 'SPC');
                if (subProdCodeNames == 0) {
                    alert("Please select Sub Product Code.");
                    return false;
                }

            }
           
            if (!document.getElementById('<%= lstSELFIFlgBlkUpd.ClientID %>').disabled == true) {
                var SELFINames = getSelectedNames(document.getElementById('<%= lstSELFIFlgBlkUpd.ClientID %>'), 'SELFI');
                if (SELFINames == 0) {
                    alert("Please select SELFI Flag.");
                    return false;
                }

            }
            if (!document.getElementById('<%= lstULIPBlkUpd.ClientID %>').disabled == true) {
                var ULIPNames = getSelectedNames(document.getElementById('<%= lstULIPBlkUpd.ClientID %>'), 'ULIP');
                if (ULIPNames == 0) {
                    alert("Please select ULIP Flag.");
                    return false;
                }

            }
            if (!document.getElementById('<%= lstepay.ClientID %>').disabled == true) {
                var EPYNames = getSelectedNames(document.getElementById('<%= lstepay.ClientID %>'), 'EPY');
                if (EPYNames == 0) {
                    alert("Please select E PAY Flag.");
                    return false;
                }

            }
            if (!document.getElementById('<%= lstmscbox.ClientID %>').disabled == true) {
                var MSCNames = getSelectedNames(document.getElementById('<%= lstmscbox.ClientID %>'), 'MSC');
                if (MSCNames == 0) {
                    alert("Please select Miscellaneous Flag.");
                    return false;
                }

            }
           <%-- if (!document.getElementById('<%= ListBoxSalesUnit.ClientID %>').disabled == true) {
                var MSCNames = getSelectedNames(document.getElementById('<%= ListBoxSalesUnit.ClientID %>'), 'REGLOC');
                if (MSCNames == 0) {
                    alert("Please select Sales Unit.");
                    return false;
                }

            }--%>


            if (!document.getElementById('<%= lstPDTBlkUpd.ClientID %>').disabled == true) {
                var PDTNames = getSelectedNames(document.getElementById('<%= lstPDTBlkUpd.ClientID %>'), 'PDT');
                if (PDTNames == 0) {
                      alert("Please select Policy Category.");
                      return false;
                  }

            }


            if (!document.getElementById('<%= lstPolicyTypBlkUpd.ClientID %>').disabled == true) {
                var policyTypeNames = getSelectedNames(document.getElementById('<%= lstPolicyTypBlkUpd.ClientID %>'), 'PT');
                 if (policyTypeNames == 0) {
                     alert("Please select Policy Type.");
                     return false;
                 }

             }

            if (!document.getElementById('<%= lstVPSCFlagBlkUpd.ClientID %>').disabled == true) {
                var VPSCNames = getSelectedNames(document.getElementById('<%= lstVPSCFlagBlkUpd.ClientID %>'), 'VPSC');
                if (VPSCNames == 0) {
                      alert("Please select VPSC Flag.");
                      return false;
                  }

              }

            if (!document.getElementById('<%= lstCPCBlkUpd.ClientID %>').disabled == true) {
                var CPCNames = getSelectedNames(document.getElementById('<%= lstCPCBlkUpd.ClientID %>'), 'CPC');
                if (CPCNames == 0) {
                    alert("Please select Combo product code.");
                    return false;
                }

            }
            return true;

        }
        var objRange = {}
        function valRangeFactors() {
            var blnkTxtArr = []
            for (var i = 0; i < divExists.length; i++) {
                var From = $("[id ^= '" + divExists[i] + "']");
                objMain[divExistsName[i]] = [];
                objRange[divExistsName[i]] = [];
                $(From).each(function (index, element) {
                    debugger;
                    var objFromTo = {};
                    var inputs = $(element).find("[type='text']");
                    $(inputs).each(function (index, ele) {
                        if (!$(ele).val() || $(ele).val() == "") {
                            blnkTxtArr.push(i + 1)
                        }
                    })
                    objFromTo[divExistsName[i] + "_From"] = $(inputs[0]).val();
                    objFromTo[divExistsName[i] + "_To"] = $(inputs[1]).val();

                    objRange[divExistsName[i]].push(objFromTo)
                })
            }
            if (blnkTxtArr.length > 0) {
                alert('Please enter value for all fields of range factors');
                return false;
            }
            else {
                return true;
            }
        }

        function validateRange() {
            debugger;
            var previousTo = "";
            var isbreak = true;
            for (var i = 0; i < divExists.length; i++) {
                var From = $("[id ^= '" + divExists[i] + "']");
                objMain[divExistsName[i]] = [];
                var previousTo = "";
                $(From).each(function (index, element) {
                    debugger;
                    var objFromTo = {};
                    var fromVal = "";
                    var toVal = "";
                    var ifCondition;

                    var inputs = $(element).find("[type='text']");
                    if (divExists[i] == "divLDTFromandToInnerBody" || divExists[i] == "divTDTFromandToInnerBody") {
                        fromVal = $.datepicker.parseDate("dd/mm/yy", $(inputs[0]).val())
                        toVal = $.datepicker.parseDate("dd/mm/yy", $(inputs[1]).val())

                    }
                    else {
                        fromVal = parseFloat($(inputs[0]).val())
                        toVal = parseFloat($(inputs[1]).val())
                    }
                    if (index == 0) {
                        if (divExists[i] == "divLDTFromandToInnerBody" || divExists[i] == "divTDTFromandToInnerBody") {
                            if (fromVal > toVal) {
                                alert(divExistsName[i] + "_To " + (index + 1) + " should be greater than " + divExistsName[i] + "_From " + (index + 1))
                                isbreak = false;
                                return false;
                            }

                            else {
                                previousTo = toVal
                            }
                        }
                        else {
                            if (fromVal >= toVal) {
                                alert(divExistsName[i] + "_To " + (index + 1) + " should be greater than " + divExistsName[i] + "_From " + (index + 1))
                                isbreak = false;
                                return false;
                            }

                            else {
                                previousTo = toVal
                            }
                        }
                    }
                    else {
                        if (previousTo != "") {
                            if (previousTo >= fromVal) {
                                alert(divExistsName[i] + "_From " + (index + 1) + " should be greater than " + divExistsName[i] + "_To " + ((index + 1) - 1))
                                isbreak = false;
                                return false;
                            }
                            else {
                                if (divExists[i] == "divLDTFromandToInnerBody" || divExists[i] == "divTDTFromandToInnerBody") {
                                    if (fromVal > toVal) {
                                        alert(divExistsName[i] + "_To " + (index + 1) + " should be greater than " + divExistsName[i] + "_From " + (index + 1))
                                        isbreak = false;
                                        return false;
                                    }

                                    else {
                                        previousTo = toVal
                                    }
                                }
                                else {
                                    if (fromVal >= toVal) {
                                        alert(divExistsName[i] + "_To " + (index + 1) + " should be greater than " + divExistsName[i] + "_From " + (index + 1))
                                        isbreak = false;
                                        return false;
                                    }

                                    else {
                                        previousTo = toVal
                                    }
                                }
                            }
                        }
                    }


                })
                if (isbreak == false) {
                    break;
                }
            }
            return isbreak;
        }

        function saveData() {
            debugger;
            var isRangeValid = validateRange()
            if (isRangeValid) {
                for (var i = 0; i < divExists.length; i++) {
                    var From = $("[id ^= '" + divExists[i] + "']");
                    objMain[divExistsName[i]] = [];
                    $(From).each(function (index, element) {
                        debugger;
                        var objFromTo = {};
                        //if (divExists[i] == "divLDTFromandToInnerBody" || divExists[i] == "divTDTFromandToInnerBody") {
                        //    var inputs = $(element).find("[type='date']");
                        //} else {
                        var inputs = $(element).find("[type='text']");
                        //}
                        objFromTo[divExistsName[i] + "_From"] = $(inputs[0]).val();
                        objFromTo[divExistsName[i] + "_To"] = $(inputs[1]).val();
                        objMain[divExistsName[i]].push(objFromTo)
                    })

                }
                var objFixFactors = {};
                objMain["LOB"] = [];
                objFixFactors["LOB"] = $('#<%=ddlLOBBlkUpd.ClientID %>').val();
                objMain["LOB"].push(objFixFactors);

                //console.log(objMain);

                $.ajax({
                    type: "POST",
                    url: "MstActCatgSchm.aspx/GenerateList",
                    data: "{ 'Data' : '" + JSON.stringify(objMain) + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        <%--if (response.d == 1) {
                            $('#<%=lnlGenExcelFile.ClientID %>').click();
                        }--%>
                        var json = JSON.parse(response.d)
                        var data = {};
                        data["Table"] = json;
                        $('#<%=respJSON.ClientID %>').val(JSON.stringify(data));
                        //console.log(response.d);
                        $('#<%=lnlGenExcelFile.ClientID %>').click();
                    },
                    failure: function (response) {

                    }
                });
            }
        }
    </script>
</asp:Content>


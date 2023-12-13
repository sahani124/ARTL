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
    <%--    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../../../../assets/scripts/commonValidate.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>--%>
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
        //Added by Abuzar start
        function addDigit(button) {
            var txtformuladiv = document.getElementById('<%= txtformuladiv.ClientID %>');
            txtformuladiv.value += button.value;
            return txtformuladiv.value;
        }
        function PopulateCalender2() {
            //minDate:new Date()
            $("#<%= txteffdefdttyp.ClientID  %>").datepicker({
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
            $("#<%= txteffdefdttyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= txtcsedttyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
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

        function PopulateCalender3() {
            $("#<%= txtcsedttyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }
        function checkDate() {
            var EffDate2 = $('#<%= txteffdtdefstdtyp.ClientID  %>').val();
            var CeDate2 = $('#<%= txtcsedtdefstdtyp.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (EffDate2 != "" && CeDate2 != "") {
                if (!checkDateIsGreaterThanToday(EffDate2, CeDate2)) {
                    alert("Please enter the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtcsedtdefstdtyp").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function PopulateCalender4() {
            //minDate:new Date()
            $("#<%= txteffdtdefstdtyp.ClientID  %>").datepicker({
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
            $("#<%= txteffdtdefstdtyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= txtcsedtdefstdtyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
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

        function PopulateCalender5() {
            $("#<%= txtcsedtdefstdtyp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }
        function checkDate() {
            var EffDate3 = $('#<%= txteffdtdefaccruallog.ClientID  %>').val();
            var CeDate3 = $('#<%= txtcsedtdefaccruallog.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (EffDate3 != "" && CeDate3 != "") {
                if (!checkDateIsGreaterThanToday(EffDate3, CeDate3)) {
                    alert("Please enter the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtcsedtdefaccruallog").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function PopulateCalender6() {
            //minDate:new Date()
            $("#<%= txteffdtdefaccruallog.ClientID  %>").datepicker({
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
            $("#<%= txteffdtdefaccruallog.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= txtcsedtdefaccruallog.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
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

        function PopulateCalender7() {
            $("#<%= txtcsedtdefaccruallog.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }
        function checkDate() {
            var EffDate4 = $('#<%=txteffdtaccrualwhr.ClientID  %>').val();
            var CeDate4 = $('#<%= txtcsedtaccrualwhr.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (EffDate4 != "" && CeDate4 != "") {
                if (!checkDateIsGreaterThanToday(EffDate4, CeDate4)) {
                    alert("Please enter the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtcsedtaccrualwhr").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function PopulateCalender8() {
            //minDate:new Date()
            $("#<%= txteffdtaccrualwhr.ClientID  %>").datepicker({
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
            $("#<%= txteffdtaccrualwhr.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });

            $("#<%= txtcsedtaccrualwhr.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
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

        function PopulateCalender9() {
            $("#<%= txtcsedtaccrualwhr.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', minDate: 0, changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }
        function confPromptBox() {
            var resp = confirm("Successfully saved the record")
            if (resp == true) {

                location.replace(location.href);

            }
            else {

            }

        }
        function confPromptBox1() {
            var resp = confirm("Data has been deleted")
            if (resp == true) {

                location.replace(location.href);

            }
            else {

            }

        }
        //Added by Abuzar ends
    </script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .dvHeader {
            font-size: 14px;
            FONT-FAMILY: 'VAG Rounded std Light';
            FONT-WEIGHT: BOLD;
            /*margin-bottom: 20px;*/
            color: #F04e5e;
        }

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
                    <img src="../../../images/KPI_icon.png" style="width: 30px; height: 30px !important" />
                    <asp:Label ID="Label1" Text="KPI SETUP" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="divkpihdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
            <%--KPI_DETAILS--%>
            <%--            <div style="padding: 10px;">--%>
            <div id="div8" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div13','ImgDetails');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="Label28" Text="KPI DETAILS" runat="server" Font-Size="19px" />
                        </div>
                        <div class="col-sm-2">
                            <span id="ImgDetails" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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
                            <asp:Label ID="Label43" Text="Define Processing Logic" Style="font-size: 14px;" runat="server" CssClass="control-label" /><asp:Label
                                ID="Label44" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButton ID="rdDefproclog" AutoPostBack="true" runat="server" GroupName="Is Define processing logic" Text="Yes" OnCheckedChanged="rdDefproclog_CheckedChanged" />
                                    <asp:RadioButton ID="rdDefproclog1" AutoPostBack="true" runat="server" GroupName="Is Define processing logic" Text="No" OnCheckedChanged="rdDefproclog1_CheckedChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="Label41" Text="Attach Processor" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtattchproc" runat="server" CssClass="form-control" placeholder="Procedure Name" />
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
                    <div class="row" style="padding: 10px; display: none">
                        <%--Added by Abuzar--%>
                        <div id="divdefhdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                            <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdef','myImg');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblDefRngHdr" Text="Date Range" runat="server" Font-Size="19px" />
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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
                    <div class="row" style="margin-bottom: 5px; display: none">
                        <%--Added by Abuzar--%>
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
                    <div class="row" style="margin-bottom: 5px; display: none">
                        <%--Added by Abuzar--%>
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
                                <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> SAVE
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-sample" OnClick="btnEdit_Click"
                                TabIndex="26">
                                <span class="glyphicon glyphicon-edit" style="color: White;"></span> EDIT
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"
                                OnClick="btnCancel_Click" TabIndex="27">
                                <span class="glyphicon glyphicon-erase" style="color:White"></span> CLEAR
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnClose" runat="server" CssClass="btn btn-sample"
                                OnClick="btnClose_Click" TabIndex="28">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> CANCEL
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnHist" runat="server" CssClass="btn btn-sample"
                                OnClick="btnHist_Click" TabIndex="29" Visible="false">
                                <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> HISTORY
                            </asp:LinkButton>
                            <asp:Button ID="btnfrml" runat="server" ClientIDMode="Static" Style="display: none;"
                                OnClick="btnfrml_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%--            </div>--%>
            <%--KPI_DETAILS--%>
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
                                <span id="ImgBase" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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
                                                <i class="glyphicon glyphicon-chevron-down" ></i> View Details
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
                                <span id="ImgDef" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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
                                <span id="ImgSorce" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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

            <%--Added By Abuzar Starts--%>

            <div class="row" style="padding: 10px;">

                <div id="divsrcbsetbldefhdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div25" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrcbsetbldefhdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label37" Text="SOURCE AND BASE TABLE DEFINITION" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img7" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divsrcbsetbldefhdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">

                        <%--added..wizard images start--%>
                        <div id="showWizardImg0" runat="server" style="width: 929px; margin: 0 auto;">
                            <img id="Img12" runat="server" src="../../../image/Btn_imgs/step_00.png" />
                        </div>

                        <div id="showWizardImg1" runat="server" style="width: 929px; margin: 0 auto; display: none">
                            <img id="step1" runat="server" src="../../../image/Btn_imgs/step_01.png" />
                        </div>

                        <div id="showWizardImg2" runat="server" style="width: 929px; margin: 0 auto; display: none">
                            <img id="Img2" runat="server" src="../../../image/Btn_imgs/step_02.png" />
                        </div>

                        <div id="showWizardImg3" runat="server" style="width: 929px; margin: 0 auto; display: none">
                            <img id="Img3" runat="server" src="../../../image/Btn_imgs/step_03.png" />
                        </div>

                        <div id="showWizardImg4" runat="server" style="width: 929px; margin: 0 auto; display: none">
                            <img id="Img6" runat="server" src="../../../image/Btn_imgs/step_04.png" />
                        </div>

                        <div id="showWizardImg5" runat="server" style="width: 929px; margin: 0 auto; display: none">
                            <img id="Img11" runat="server" src="../../../image/Btn_imgs/step_05.png" />
                        </div>

                        <%--added..wizard images Ends--%>

                        <%--DO YOU NEED TO CREATE A SYNONYMS STARTS--%>
                        <div class="row" id="divSynonyms" style="width: 18%; height: 260px; float: left; background-color: #fcfcfc; margin: 10px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                <asp:UpdatePanel ID="UpdatePanel33" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSynonnyms" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        <%--<asp:Label Text="*" runat="server" Style="color: Red" />--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="margin-top: 15px; text-align: center">
                                If Yes please click below <span style="color: #f04e5e; font-weight: bold;">ADD</span> Button Or else you can <b>click No for skip</b>.
                            </div>
                            <div style="margin-top: 15px; text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButton ID="rdSynonnyms" runat="server" onclick="ShowStep1();" GroupName="Synonyms" AutoPostBack="true" Text="&nbsp&nbspYes&nbsp&nbsp" OnCheckedChanged="rdSynonnyms_CheckedChanged" />
                                        <asp:RadioButton ID="rdSynonnyms1" runat="server" onclick="ShowStep1();" GroupName="Synonyms" AutoPostBack="true" Text="&nbsp&nbspNo&nbsp&nbsp" OnCheckedChanged="rdSynonnyms_CheckedChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <center>
                            <div style="margin-top: 15px; text-align:center">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkcrtsyn" Width="160px" runat="server" Enabled="false"  CssClass="btn btn-sample" OnClick="lnkcrtsyn_Click"><%--Text="ADD"--%>
                                        <span class="glyphicon glyphicon-plus" style="color: White;"></span>ADD
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                                </center>
                        </div>
                        <%--DO YOU NEED TO CREATE A SYNONYMS ENDS--%>

                        <%--DO YOU NEED TO CREATE A SOURCE TABLE start--%>
                        <div class="row" id="dvcrtsrctbl" style="width: 18%; height: 260px; float: left; background-color: #fcfcfc; margin: 10px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                <asp:UpdatePanel ID="UpdatePanel89" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <asp:Label ID="lblSrctbl" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        <%--<asp:Label Text="*" runat="server" Style="color: Red" />--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="margin-top: 15px; text-align: center;">
                                If Yes please click below <span style="color: #f04e5e; font-weight: bold;">ADD</span> Button Or else you can <b>click No for skip</b>.
                            </div>

                            <div style="margin-top: 15px; text-align: center;">
                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButton ID="rdSrctbl" runat="server" onclick="ShowStep2();" GroupName="Source table" AutoPostBack="true" Text="&nbsp&nbspYes&nbsp&nbsp" OnCheckedChanged="rdSrctbl_CheckedChanged" />
                                        <asp:RadioButton ID="rdSrctbl1" runat="server" onclick="ShowStep2();" GroupName="Source table" AutoPostBack="true" Text="&nbsp&nbspNo&nbsp&nbsp" OnCheckedChanged="rdSrctbl_CheckedChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <center>
                            <div style="margin-top: 15px;text-align: center;">
                                <asp:UpdatePanel ID="UpdatePanel49" runat="server" >
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkcrtsrctbl" runat="server" Width="160px" CssClass="btn btn-sample" Enabled="false"   OnClick="lnkcrtsrctbl_Click"> <%--Text="Create Source"--%>
                                        <span class="glyphicon glyphicon-plus" style="color: White;"></span>ADD
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                </center>
                        </div>
                        <%--DO YOU NEED TO CREATE A SOURCE TABLE ends here--%>

                        <%--DO YOU NEED TO MAP A SYNONYMS TO A SOURCE TABLE start--%>
                        <div class="row" style="width: 18%; height: 260px; float: left; background-color: #fcfcfc; margin: 10px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                <asp:UpdatePanel ID="UpdatePanel90" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <asp:Label ID="lblmapsyntosrc" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        <%--<asp:Label Text="*" runat="server" Style="color: Red" />--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div style="margin-top: 35px; text-align: center;">
                                If Yes please click below <span style="color: #f04e5e; font-weight: bold;">MAP</span> Button Or else you can <b>click No for skip</b>.
                            </div>
                            <div style="margin-top: 15px; text-align: center;">
                                <asp:UpdatePanel ID="UpdatePanel82" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButton ID="rdmapsyntosrc" onclick="ShowStep3();" runat="server" AutoPostBack="true" GroupName="Synonyms to Source" Text="&nbsp&nbspYes&nbsp&nbsp" OnCheckedChanged="rdmapsyntosrc_CheckedChanged" />
                                        <asp:RadioButton ID="rdmapsyntosrc1" onclick="ShowStep3();" runat="server" AutoPostBack="true" GroupName="Synonyms to Source" Text="&nbsp&nbspNo&nbsp&nbsp" OnCheckedChanged="rdmapsyntosrc_CheckedChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <center>
                            <div style="margin-top: 14px;text-align: center;">     <%-- style="margin-top: 15px;text-align: center;"--%>
                                <asp:UpdatePanel ID="UpdatePanel81" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkmapsyntosrc" Width="160px" runat="server" Enabled="false" CssClass="btn btn-sample"  >   <%--Text="Map Synonyms to Source Table"--%>
                                        <span class="glyphicon glyphicon-retweet" style="color: White;"></span>MAP
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                </center>
                        </div>
                        <%--DO YOU NEED TO MAP A SYNONYMS TO A SOURCE TABLE ends here--%>

                        <%--CREATE A BASE TABLE STARTS HERE--%>
                        <div class="row" style="width: 18%; height: 260px; float: left; background-color: #fcfcfc; margin: 10px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                <asp:UpdatePanel ID="UpdatePanel92" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <asp:Label ID="Label35" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="margin-top: 35px; text-align: center;">
                                If Yes please click below <span style="color: #f04e5e; font-weight: bold;">ADD</span> Button Or else you can <b>click No for skip</b>.
                            </div>
                            <div style="margin-top: 15px">
                            </div>
                            <center>
                            <div  style="margin-top: 57px; text-align: center;">
                                <asp:UpdatePanel ID="UpdatePanel84" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkcrtbsetbl" runat="server" CssClass="btn btn-sample" width="160px" OnClientClick="ShowStep4();" OnClick="lnkcrtbsetbl_Click">  <%-- Text="Create Base Table"--%>
                                        <span class="glyphicon glyphicon-plus" style="color: White;"></span>ADD
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                </center>
                        </div>
                        <%--CREATE A BASE TABLE ends HERE--%>

                        <%--MAP A BASE TABLE TO A SOURCE TABLE STARTS HERE--%>
                        <div class="row" style="width: 18%; height: 260px; float: left; background-color: #fcfcfc; margin: 10px; border: solid 1px #ccdcee; padding: 10px">
                            <div class="dvHeader">
                                <asp:UpdatePanel ID="UpdatePanel91" runat="server" style="text-align: center;">
                                    <ContentTemplate>
                                        <asp:Label ID="Label34" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div style="margin-top: 15px; text-align: center">
                                If Yes please click below <span style="color: #f04e5e; font-weight: bold;">MAP</span> Button Or else you can <b>click No for skip</b>.
                            </div>
                            <div style="margin-top: 15px">
                            </div>
                            <center>
                            <div style="margin-top: 57px">
                                <asp:UpdatePanel ID="UpdatePanel88" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkmapbsesrctbl" runat="server" CssClass="btn btn-sample" Width="160px" OnClientClick="ShowStep5();"  OnClick="lnkmapbsesrctbl_Click">  <%--Text="Map Base table to Source table"--%>
                                        <span class="glyphicon glyphicon-retweet" style="color: White;"></span>MAP     

                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                </center>
                        </div>
                        <%--MAP A BASE TABLE TO A SOURCE TABLE ENDS HERE--%>
                    </div>
                </div>
            </div>


            <div class="row" style="padding: 10px;">
                <div id="divdefdattyphdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div29" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdefdattyphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label39" Text="DEFINE DATE TYPE" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img7" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divdefdattyphdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <div class="dattyp" style="padding: 10px">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbldattypdesc" Text="Date Type Description" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtdattypdesc" runat="server" CssClass="form-control" TabIndex="1"
                                                placeholder="Date Type Description" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbltblnam" Text="Table Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddltblnam" runat="server" CssClass="select2-container form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltblnam_SelectedIndexChanged"
                                                TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblcolnam" Text="Column Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlcolnam" runat="server" CssClass="select2-container form-control"
                                            TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbldattypsta" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                <asp:Label Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel70" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddldattypsta" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label42" Text="Effective Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label45" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel69" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txteffdefdttyp" runat="server" CssClass="form-control"
                                            onmousedown="PopulateCalender2()"
                                            onmouseup="PopulateCalender2()"
                                            placeholder="DD/MM/YYYY" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label47" Text="Cease Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtcsedttyp" runat="server" CssClass="form-control"
                                            onmousedown="PopulateCalender3()"
                                            onmouseup="PopulateCalender3()"
                                            placeholder="DD/MM/YYYY" Enabled="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnAdddattyp" runat="server" CssClass="btn btn-sample" OnClick="btnSavedattyp_Click">
                                                 <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncncldattyp" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                        </div>

                        <div id="div30" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgdattyp" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                        AllowPaging="true" AutoGenerateColumns="false" ForeColor="#333333" EmptyDataText="No date type Defined">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date Type Description" HeaderStyle-HorizontalAlign="Left"
                                                SortExpression="DESC01">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldattypdesc" runat="server" Text='<%# Bind("DESC01")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdndattypdesc" runat="server" Value='<%# Bind("CODE")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Column Name" HeaderStyle-HorizontalAlign="Left" SortExpression="COL_NAME">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColnam" runat="server" Text='<%# Bind("COL_NAME")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnColnam" runat="server" Value='<%# Bind("SRC_TBL_ID")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" SortExpression="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldattypsta" runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdndattypsta" runat="server" Value='<%# Bind("STATUS")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Left" SortExpression="EFF_DTIM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldattypeffdt" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdndattypeffdt" runat="server" Value='<%# Bind("EFF_DTIM")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Left" SortExpression="CSE_DTIM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldattypcsedt" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdndattypcsedt" runat="server" Value='<%# Bind("CSE_DTIM")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkeditdattyp" runat="server" Text="Edit" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="EDIT" Enabled='<%# Eval("DESC01").ToString() == "MEMBER HISTORY DATE"||Eval("DESC01").ToString() == "INCOME STATUS AS ON DATE" ? false : true %>' OnClick="lnkeditdattyp_Click">
                                                          <img src="../../../KMI%20Styles/assets/css/Images/imgEdit.png" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>

                                                    <%--   <asp:LinkButton ID="lnkDelCmp"  runat="server" Text="Delete" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="DELETE" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="lnkDelCmp_Click">
                                                 <img src="../../../KMI%20Styles/assets/css/Images/delete.png" />
                                                </asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkdeletedattyp" runat="server" Text="Delete" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="DELETE" Enabled='<%# Eval("DESC01").ToString() == "MEMBER HISTORY DATE"||Eval("DESC01").ToString() == "INCOME STATUS AS ON DATE" ? false : true %>' OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkdeletedattyp_Click">
                                             <img src="../../../KMI%20Styles/assets/css/Images/delete.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="pagination" style="width: 100%">
                                <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap">
                                            <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnpreviousdattyp" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnpreviousdattyp_Click"/>
                                                    <asp:TextBox runat="server" ID="txtpgdattyp" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextdattyp" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnextdattyp_Click"/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                           </center>
                            </div>

                        </div>


                    </div>
                </div>
            </div>

            <div class="row" style="padding: 10px;">
                <div id="divdefstddeftyphdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div23" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdefstddeftyphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label33" Text="DEFINE STANDARD DEFINITION TYPE" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img5" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divdefstddeftyphdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <div class="Stddef" style="padding: 10px">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblStddeftyp" Text="Standard Definition Type" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddllblStddeftyp" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblbsdontbltyp" Text="Based on Table Type" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlbsdontbltyp" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                                <asp:ListItem Value="">SELECT</asp:ListItem>
                                                <asp:ListItem Value="B">BASE</asp:ListItem>
                                                <asp:ListItem Value="S">SOURCE</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbldefstddeftypsta" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel72" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddldefstddeftypsta" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbleffdtdefstdtyp" Text="Effective Date" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel73" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txteffdtdefstdtyp" runat="server" CssClass="form-control"
                                                onmousedown="PopulateCalender4()"
                                                onmouseup="PopulateCalender4()"
                                                placeholder="DD/MM/YYYY" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblcsedtdefstdtyp" Text="Cease Date" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel74" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtcsedtdefstdtyp" runat="server" CssClass="form-control"
                                                onmousedown="PopulateCalender5()"
                                                onmouseup="PopulateCalender5()"
                                                placeholder="DD/MM/YYYY" Enabled="false" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnsavestddeftyp" runat="server" CssClass="btn btn-sample" OnClick="btnSavestddeftyp_Click">
                                                 <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncnclstddeftyp" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                        </div>
                        <div id="div26" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgstddeftyp" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                        AllowPaging="true" AutoGenerateColumns="false" ForeColor="#333333" EmptyDataText="No Standard definition type Defined">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Standard definition type" HeaderStyle-HorizontalAlign="Left"
                                                SortExpression="ACT_TYP_DSC">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstddeftyp" runat="server" Text='<%# Bind("ACT_TYP_DSC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnstddeftyp" runat="server" Value='<%# Bind("ACT_TYPE")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnkpicodestddef" runat="server" Value='<%# Bind("KPI_CODE")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Based on Table Type" HeaderStyle-HorizontalAlign="Left" SortExpression="BSD_ON_TBL_TYP">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbsdtbltyp" runat="server" Text='<%# Bind("BSD_ON_TBL_TYP")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnbsdtbltyp" runat="server" Value='<%# Bind("BSD_ON_TBL_TYP")%>' />
                                                    <%--<asp:Label ID="lblhdnbsdontbltype" runat="server" Text='<%# Bind("BSD_ON_TBL_TYPE")%>' Visible="false"></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" SortExpression="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstddeftypstatus" runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnstddeftypstatus" runat="server" Value='<%# Bind("STATUS")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Left" SortExpression="EFF_DTIM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstddeftypffdt" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnstddeftypffdt" runat="server" Value='<%# Bind("EFF_DTIM")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Left" SortExpression="CSE_DTIM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstddeftypcsedt" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnstddeftypcsedt" runat="server" Value='<%# Bind("CSE_DTIM")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkeditstddeftyp" runat="server" Text="Edit" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="EDIT" OnClick="lnkeditstddeftyp_Click">
                                                          <img src="../../../KMI%20Styles/assets/css/Images/imgEdit.png" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdeletestddeftyp" runat="server" Text="Delete" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="DELETE" OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkdeletestddeftyp_Click">
                                                          <img src="../../../KMI%20Styles/assets/css/Images/delete.png" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdefvalfctr" runat="server" Text="Define Val Factor" OnClick="lnkdefvalfctr_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>

            <%--Added by Shubham--%>

            <div id="div4" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div7','myImg');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="Label20" Text="DEFINE SCOPE OF STANDARD DEFINITION" runat="server" Font-Size="19px" />
                        </div>
                        <div class="col-sm-2">
                            <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
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
                                                   <asp:LinkButton Text="Set Rule" ID="btnSetRule" OnClick="btnSetRule_Click"  runat="server" Enabled='<%# Checkforstddef() ? true:false %>'/>
<%--                                                   <asp:LinkButton Text="Set Rule" ID="btnSetRule" OnClick="btnSetRule_Click"  runat="server" Enabled="true"/>--%>
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


            <%--Ended by Shubham--%>

            <div class="row" style="padding: 10px;">
                <div id="divdefaccdatsynloghdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div27" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdefaccdatsynloghdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label36" Text="DEFINE ACCRUAL DATA SYNCHRONIZATION LOGIC" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img8" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divdefaccdatsynloghdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <div class="divdefaccdatsynlog" style="padding: 10px">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbltemplate" Text="Template" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddltemplate" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblNoParam" Text="Define No.Parameter" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtNoParam" runat="server" CssClass="form-control" TabIndex="2"
                                                placeholder="Place Enter No of Parameter" MaxLength="40" />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterType="Numbers" FilterMode="ValidChars" TargetControlID="txtNoParam">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbldefgrpbsdcol" Text="Define Grouping based column" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                        <ContentTemplate>
                                            <asp:ListBox ID="lstdefgrpbsdcol" SelectionMode="Multiple" runat="server" CssClass="select2-container form-control"></asp:ListBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblgrpcond" Text="Group Condition" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlgrpcond" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblgrpcolnam" Text="Group Column Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                        <ContentTemplate>
                                            <asp:ListBox ID="lstgrpcolnam" SelectionMode="Multiple" runat="server" CssClass="select2-container form-control"></asp:ListBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbldefaccruallogsta" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel75" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddldefaccruallogsta" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbleffdtdefaccruallog" Text="Effective Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                    <asp:Label ID="Label48" Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel76" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txteffdtdefaccruallog" runat="server" CssClass="form-control"
                                                onmousedown="PopulateCalender6()"
                                                onmouseup="PopulateCalender6()"
                                                placeholder="DD/MM/YYYY" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblcsedtdefaccruallog" Text="Cease Date" Style="font-size: 14px;" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel77" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtcsedtdefaccruallog" runat="server" CssClass="form-control"
                                                onmousedown="PopulateCalender7()"
                                                onmouseup="PopulateCalender7()"
                                                placeholder="DD/MM/YYYY" Enabled="false" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>

                            <div class="row" style="margin-bottom: 5px;">
                                <center>
                                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkaccdatsynlog" runat="server" CssClass="btn btn-sample" OnClick="lnkaccdatsynlog_Click">
                                                 <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnClearaccdatsynlog" runat="server" CssClass="btn btn-sample" OnClick="btnClearaccdatsynlog_Click">
                                                 <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncnclaccdatsynlog" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                            </div>

                            <div id="div21" runat="server" style="overflow-x: auto; width: 100%; border: none; margin: 0px 0 !important;"
                                class="table-scrollable">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgdefaccdatsynlog" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                            AllowPaging="true" AutoGenerateColumns="false" ForeColor="#333333" EmptyDataText="No Standard definition type Defined">
                                            <RowStyle CssClass="GridViewRow"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Parameter" HeaderStyle-HorizontalAlign="Left"
                                                    SortExpression="PRMTR">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblParam" runat="server" Text='<%# Bind("PRMTR")%>' OnClick="lblParam_Click"></asp:LinkButton>
                                                        <asp:HiddenField ID="hdnParam" runat="server" Value='<%# Bind("PRMTR")%>'></asp:HiddenField>
                                                        <asp:HiddenField ID="hdnkpicodeaccr" runat="server" Value='<%# Bind("KPI_CODE")%>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Define grouping" HeaderStyle-HorizontalAlign="Left" SortExpression="GRP_BSE_COL">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldefgrp" runat="server" Text='<%# Bind("GRP_BSE_COL")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdndefgrp" runat="server" Value='<%# Bind("GRP_BSE_COL")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group column name" HeaderStyle-HorizontalAlign="Left" SortExpression="COL">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgrpcolnam" runat="server" Text='<%# Bind("COL")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdngrpcolnam" runat="server" Value='<%# Bind("COL")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Template" HeaderStyle-HorizontalAlign="Left" SortExpression="TMPLT_ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltmplt" runat="server" Text='<%# Bind("TMPLT_ID")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdntmplt" runat="server" Value='<%# Bind("TMPLT_ID1")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" SortExpression="STATUS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaccruallogicstatus" runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnaccruallogicstatus" runat="server" Value='<%# Bind("STATUS")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Left" SortExpression="EFF_DTIM">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaccruallogiceffdt" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnaccruallogiceffdt" runat="server" Value='<%# Bind("EFF_DTIM")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Left" SortExpression="CSE_DTIM">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaccruallogiccsedt" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnaccruallogiccsedt" runat="server" Value='<%# Bind("CSE_DTIM")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                    <HeaderStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkeditaccrlog" runat="server" Text="Edit" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="EDIT" OnClick="lnkeditaccrlog_Click">
                                                             <img src="../../../KMI%20Styles/assets/css/Images/imgEdit.png" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="paginationaccsyn" style="width: 100%; padding-left: 45%; padding-top: 5px">
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap">
                                                <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnpreviousaccsyn" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                            Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            OnClick="btnpreviousaccsyn_Click" />
                                                        <asp:TextBox runat="server" ID="txtbtnnextaccsyn" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                            Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextaccsyn" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClick="btnnextaccsyn_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>


                            <div class="row" style="margin-left: 5px;">
                                <div id="divfrtcolparamhdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                                    <div id="Div28" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfrtcolparamhdr','myImg');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <asp:Label ID="Label38" Text="FIRST COLUMN PARAMETER" runat="server" Font-Size="19px" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span id="Img9" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divfrtcolparamhdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                                        <div class="divfrtcolparam" style="padding: 10px">
                                            <div class="row" style="margin-bottom: 5px;">
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblwhrconcolnam" Text="Where Condition column name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlwhrconcolnam" runat="server" CssClass="select2-container form-control"
                                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblOprtr" Text="Operator" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlOprtr" runat="server" CssClass="select2-container form-control"
                                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>

                                            </div>
                                            <div class="row" style="margin-bottom: 5px;">
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblwhrconcolval" Text="Where condition column value" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtwhrconcolval" runat="server" CssClass="form-control" TabIndex="2"
                                                                placeholder="Place Enter where value" MaxLength="40" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblParamnam" Text="Parameter Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblParamnamVal" runat="server" CssClass="control-label" Style="font-size: 12px; text-align: left">
                                                            </asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>

                                            </div>
                                            <div class="row" style="margin-bottom: 5px;">
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblaccrualwhrsta" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel78" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlaccrualwhrsta" runat="server" CssClass="select2-container form-control"
                                                                AutoPostBack="true" TabIndex="1" Height="35px">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lbleffdtaccrualwhr" Text="Effective Date" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel79" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txteffdtaccrualwhr" runat="server" CssClass="form-control"
                                                                onmousedown="PopulateCalender8()"
                                                                onmouseup="PopulateCalender8()"
                                                                placeholder="DD/MM/YYYY" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-bottom: 5px;">
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblcsedtaccrualwhr" Text="Cease Date" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:UpdatePanel ID="UpdatePanel80" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtcsedtaccrualwhr" runat="server" CssClass="form-control"
                                                                onmousedown="PopulateCalender9()"
                                                                onmouseup="PopulateCalender9()"
                                                                placeholder="DD/MM/YYYY" Enabled="false" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px;">
                                                <center>
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkbtnfrtcolparamadd" runat="server" CssClass="btn btn-sample" OnClick="lnkbtnfrtcolparamadd_Click">
                                                 <span class="glyphicon glyphicon-plus" style="color: White;"></span> Add
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnfrtcolparamclr" runat="server" CssClass="btn btn-sample" OnClick="lnkbtnfrtcolparamclr_Click">
                                                 <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnfrtcolparamgen" runat="server" CssClass="btn btn-sample">
                                                 <span class="glyphicon glyphicon-plus" style="color: White;"></span> Generate
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncnclfrtcolparam" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                                            </div>
                                            <div id="div31" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                                class="table-scrollable">
                                                <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="dgwhrcnd" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                                            AllowPaging="true" AutoGenerateColumns="false" ForeColor="#333333" EmptyDataText="No Standard definition type Defined">
                                                            <RowStyle CssClass="GridViewRow"></RowStyle>
                                                            <PagerStyle CssClass="disablepage" />
                                                            <HeaderStyle CssClass="gridview th" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Parameter" HeaderStyle-HorizontalAlign="Left"
                                                                    SortExpression="PRMTR">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhrParam" runat="server" Text='<%# Bind("PRMTR")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhrParam" runat="server" Value='<%# Bind("PRMTR")%>'></asp:HiddenField>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Where Condition Column Name" HeaderStyle-HorizontalAlign="Left" SortExpression="WHR_CNDTN_COL_NAME">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhrconcolnam" runat="server" Text='<%# Bind("WHR_CNDTN_COL_NAME")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhrconcolnam" runat="server" Value='<%# Bind("WHR_CNDTN_COL_NAME")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Where Condition Operator" HeaderStyle-HorizontalAlign="Left" SortExpression="ParamDesc1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhrconopr" runat="server" Text='<%# Bind("ParamDesc1")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhrconopr" runat="server" Value='<%# Bind("ParamValue")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Where Condition Column Value" HeaderStyle-HorizontalAlign="Left" SortExpression="WHR_CNDTN_COL_VAL">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhrconcolval" runat="server" Text='<%# Bind("WHR_CNDTN_COL_VAL")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhrconcolval" runat="server" Value='<%# Bind("WHR_CNDTN_COL_VAL")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" SortExpression="STATUS">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhraccruallogicstatus" runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhraccruallogicstatus" runat="server" Value='<%# Bind("STATUS")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Left" SortExpression="EFF_DTIM">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhraccruallogiceffdt" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhraccruallogiceffdt" runat="server" Value='<%# Bind("EFF_DTIM")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Left" SortExpression="CSE_DTIM">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwhraccruallogiccsedt" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnwhraccruallogiccsedt" runat="server" Value='<%# Bind("CSE_DTIM")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkeditwhrcond" runat="server" Text="Edit" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="EDIT" OnClick="lnkeditwhrcond_Click">
                                                                              <img src="../../../KMI%20Styles/assets/css/Images/imgEdit.png" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkdeletewhrcond" class="red-tooltip" data-toggle="tooltip" data-placement="left" title="DELETE" runat="server" Text="Delete"
                                                                            OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkdeletewhrcond_Click">
                                                                             <img src="../../../KMI%20Styles/assets/css/Images/delete.png" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="paginationaccsyn" style="width: 100%; padding-left: 45%; padding-top: 5px">
                                                    <table>
                                                        <tr>
                                                            <td style="white-space: nowrap">
                                                                <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button ID="btnpreviouswhrcnd" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                                            Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                            OnClick="btnpreviouswhrcnd_Click" />
                                                                        <asp:TextBox runat="server" ID="txtpagewhrcnd" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                                            Text="1" CssClass="form-control" ReadOnly="true" />
                                                                        <asp:Button ID="btnnextwhrcnd" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                                            Width="40px" OnClick="btnnextwhrcnd_Click" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <%--                    <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: center">
                                <asp:Label ID="lblQuery" Text="Query" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                            </div>
                            <div class="col-sm-9">
                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtQuery" runat="server" CssClass="form-control" TabIndex="24"
                                            TextMode="MultiLine" Columns="20" ClientIDMode="Static" Rows="6" MaxLength="100"/>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                    </div>--%>
                        <div class="row" style="margin-bottom: 5px;">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="lnkbtndefaccdatsynlog" runat="server" CssClass="btn btn-sample">
                                                 <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row" style="padding: 10px;">
                <div id="divforcalhdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div22" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divforcalhdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label31" Text="FORMULA FOR THE CALCULATION" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img4" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divforcalhdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="Formula" style="padding: 10px">
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td style="white-space: nowrap;">
                                                        <asp:Button ID="btn0" Text="0" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="true" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn1" Text="1" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn2" Text="2" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn3" Text="3" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btnMinus" Text="-" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;">
                                                        <asp:Button ID="btn4" Text="4" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="true" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn5" Text="5" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn6" Text="6" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn7" Text="7" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btnperc" Text="%" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;">
                                                        <asp:Button ID="btn8" Text="8" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="true" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btn9" Text="9" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btnPlus" Text="+" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" Enabled="true" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="btnequla" Text="=" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                        <asp:Button ID="Buttonmul" Text="*" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                            Width="40px" OnClientClick="return addDigit(this);" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="white-space: nowrap;" id="tdadddyn" runat="server">
                                                        <asp:Panel ID="pnladdbtn" runat="server"></asp:Panel>

                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-9">
                                    <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtformuladiv" runat="server" CssClass="form-control" TabIndex="24"
                                                TextMode="MultiLine" Columns="20" ClientIDMode="Static" Rows="6" placeholder="Formula" MaxLength="100" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnaddparam" runat="server" CssClass="btn btn-sample" OnClick="btnaddparam_Click">
                                                 <span class="glyphicon glyphicon-plus" style="color: White;"></span> Define Formula
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveformuladiv" runat="server" CssClass="btn btn-sample" OnClick="btnSaveformuladiv_Click">
                                                 <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncnclformuladiv" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" style="padding: 10px;">
                <div id="divdefacccycloghdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div33" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divdefacccycloghdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label40" Text="DEFINE ACCUMULATION CYCLE LOGIN" runat="server" Font-Size="19px" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img10" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divdefacccycloghdr" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <div class="divdefacccyclog" style="padding: 10px">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lbldefaccumucyclogtmplt" Text="Template" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                    <asp:Label Text="*" runat="server" Style="color: Red" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddltemplatebind" runat="server" CssClass="select2-container form-control"
                                                AutoPostBack="true" TabIndex="1" Height="35px" OnSelectedIndexChanged="ddltemplatebind_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbldefacccyclog" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <center>
                                <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnsavedefacccyclog" runat="server" CssClass="btn btn-sample" OnClick="btnsavedefacccyclog_Click">
                                                 <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btncnclsavdefacccyclog" runat="server" CssClass="btn btn-sample" OnClick="btncncl_Click" TabIndex="28">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                       </asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       </center>
                        </div>
                    </div>
                </div>
            </div>

            <%--Added By Abuzar Ends--%>
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
                                <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>
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
    <%--<input type="hidden" id="endreq" value="0" />
        <input type="hidden" id="bodyy" value="0"/>
        <script type="text/javascript">
            var prm;
            prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(beginRequestHandler);
            prm.add_endRequest(endRequestHandler);

            $(window).scroll(function () {
                var cend = $("#endreq").val();
                if (cend == "1") {
                    $("#endreq").val("0");
                    var nbodyY = $("#bodyy").val();
                    $(window).scrollTop(nbodyY);
                }
            });

function beginRequestHandler(sender, event) {
    $("#endreq").val("0");
    $("#bodyy").val($(window).scrollTop());
}

function endRequestHandler(sender, evemt) {
    $("#endreq").val("1");
}
        </script>--%>

     <%--Added by Rajkapoor on 21-02-2022 for Showing Wizard images on radio button click Starts here--%>
    <script type="text/javascript">

        var radioButton = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl");
        var radioButton = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl1");

        function ShowStep1() {
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg0').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg1').style.display = 'block';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg2').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg3').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg4').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg5').style.display = 'none';

            //step2 radio
            var SecondSetpRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl");
            var SecondSetpRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl1");
            SecondSetpRdo1.checked = false;
            SecondSetpRdo2.checked = false;

            //step3 radio
            var ThirdStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc");
            var ThirdStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc1");
            ThirdStepRdo1.checked = false;
            ThirdStepRdo2.checked = false;
        }
        function ShowStep2() {
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg0').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg1').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg2').style.display = 'block';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg3').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg4').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg5').style.display = 'none';


            //step 1 radio   
            var FirstStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms");
            var SecondStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms1");
            FirstStepRdo1.checked = false;
            SecondStepRdo2.checked = false;

            //step3 radio
            var ThirdStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc");
            var ThirdStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc1");
            ThirdStepRdo1.checked = false;
            ThirdStepRdo2.checked = false;
        }
        function ShowStep3() {
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg0').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg1').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg2').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg3').style.display = 'block';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg4').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg5').style.display = 'none';


            //step 1 radio   
            var FirstStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms");
            var SecondStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms1");
            FirstStepRdo1.checked = false;
            SecondStepRdo2.checked = false;

            //step2 radio
            var SecondSetpRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl");
            var SecondSetpRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl1");
            SecondSetpRdo1.checked = false;
            SecondSetpRdo2.checked = false;
        }
        function ShowStep4() {

            //step 1 radio   
            var FirstStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms");
            var SecondStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms1");
            FirstStepRdo1.checked = false;
            SecondStepRdo2.checked = false;

            //step2 radio
            var SecondSetpRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl");
            var SecondSetpRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl1");
            SecondSetpRdo1.checked = false;
            SecondSetpRdo2.checked = false;

            //step3 radio
            var ThirdStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc");
            var ThirdStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc1");
            ThirdStepRdo1.checked = false;
            ThirdStepRdo2.checked = false;

            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg0').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg1').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg2').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg3').style.display = 'none';

            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg4').style.display = 'block';
            test1();
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg5').style.display = 'none';
        }
        function ShowStep5() {
            //step 1 radio   
            var FirstStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms");
            var SecondStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSynonnyms1");
            FirstStepRdo1.checked = false;
            SecondStepRdo2.checked = false;

            //step2 radio
            var SecondSetpRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl");
            var SecondSetpRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdSrctbl1");
            SecondSetpRdo1.checked = false;
            SecondSetpRdo2.checked = false;

            //step3 radio
            var ThirdStepRdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc");
            var ThirdStepRdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdmapsyntosrc1");
            ThirdStepRdo1.checked = false;
            ThirdStepRdo2.checked = false;

            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg0').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg1').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg2').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg3').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg4').style.display = 'none';
            document.getElementById('ctl00_ContentPlaceHolder1_showWizardImg5').style.display = 'block';
            test1();
        }


        function test1() {
            // let's say JavaScript did have a sleep function..
            // sleep for 3 seconds
            sleep(5000);

            alert('hi');
        }
    </script>

    <%--Added by Rajkapoor on 21-02-2022 for showing Wizard images on radio button click Ends here--%>


    <script type="text/javascript">  
        var xPos, yPos, needScroll;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_pageLoaded(EndRequestHandler)

        function BeginRequestHandler(sender, args) {
            xPos = 0;
            yPos = window.pageYOffset || document.documentElement.scrollTop;
        }

        function EndRequestHandler(sender, args) {
            if (needScroll) {
                window.setTimeout("window.scrollTo(" + xPos + "," + yPos + ")", 100);
            }
        }
    </script>
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
            $('#<%= lstdefgrpbsdcol.ClientID%>').multiselect({
                includeSelectAllOption: true,
            });
            $('#<%= lstgrpcolnam.ClientID%>').multiselect({
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

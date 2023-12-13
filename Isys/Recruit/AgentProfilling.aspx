<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AgentProfilling.aspx.cs"
    Inherits="Application_ISys_Recruit_AgentProfilling" Title="Agent Profile" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/Application/Common/CltDetailAddr.ascx" TagName="AddAddr" TagPrefix="uc1" %>
<%@ Register Src="../../../App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="../../../App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup" TagPrefix="uc3" %>
<%@ Register Src="../../../App_UserControl/Common/ddlLookup2.ascx" TagName="ddlLookup" TagPrefix="uc4" %>
<%@ Register Src="../../../App_UserControl/Common/popupOccupation.ascx" TagName="popupOccupation" TagPrefix="uc5" %>
<%@ Register Src="~/Application/Common/popupAML.ascx" TagName="popupAML" TagPrefix="uc6" %>
<%@ Register Src="~/Application/Common/ClientAML.ascx" TagName="ClientAML" TagPrefix="uc8" %>
<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<%@ Register Src="~/Application/Common/ClientAddress.ascx" TagName="ClientAddress" TagPrefix="uc9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../DDLChkStyle/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <link href="../../../DDLChkStyle/css/bootstrap-3.1.1.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../assets/css/KMI.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script src="../../../DDLChkStyle/js/bootstrap-2.3.2.min.js" type="text/javascript"></script>
    <script src="../../../DDLChkStyle/js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../../DDLChkStyle/js/bootstrap-multiselect.js" type="text/javascript"></script>
    --%>

    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
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

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <%--
<script language="javascript" type="text/javascript">
    function Confirm() {
        debugger;
        $('#ctl00_ContentPlaceHolder1_ListSocialGrp').multiselect({
                     });
    $('#ctl00_ContentPlaceHolder1_ListSocialGrp').multiselect();

    $('#ctl00_ContentPlaceHolder1_ListFinanceServiceName').multiselect({
});
$('#ctl00_ContentPlaceHolder1_ListFinanceServiceName').multiselect();
         }

         </script>--%>

    <script language="javascript" type="text/javascript">

        $(function () {
            debugger;

            $("#<%= TxtDOB.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= TxtAniversaryDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= TxtSpouseDOB.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= Txtchild1Dob.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= Txtchild2Dob.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
        function popup() {
            $("#myModal").modal();
        }

        //function ShowReqDtl(divId, btnId) {
        //    //debugger
        //    if (document.getElementById(divId).style.display == "block") {
        //        document.getElementById(divId).style.display = "none";

        function ShowReqDtlResize(divName, btnName) {
            debugger;
            try {
                var objnewdiv = divName;
                var objnewbtn = btnName;
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }
            catch (err) {
                showerrormsg(err.description);
            }
        }

         function showerrormsg(vmsg) {
            var vmsg = document.getElementById("<%=lblError2.ClientID%>").value.split(",")
            alert(vmsg);
         }

        function ShowReqDtl(divName, btnName) {
            //debugger;
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
               
            }
        }

        //        document.getElementById(btnId).value = '+';
        //    }
        //    else {
        //        document.getElementById(divId).style.display = "block";

        //        document.getElementById(btnId).value = '-';
        //    }
        //}

        function dtYear() {
            //debugger
            var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").value;

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            var a = strDOB.split('/');
            var todayDate = new Date();

            var cY, cM, cD;
            cY = todayDate.getFullYear();
            cM = todayDate.getMonth() + 1;
            cD = todayDate.getDate();

            var dY = a[2];
            var dM = a[1];
            var dD = a[0];

            var dob = dY + '-' + dM + '-' + dD;
            var cDate = cY + '-' + cM + '-' + cD;

            var x = dob.split('-'),
            y = cDate.split('-'),

       yrCount = 0,
       mthCount = 0,
       dayCount = 0;

            // Convert to dates
            var date0 = new Date(x[0], x[1] - 1, x[2]);
            var date1 = new Date(y[0], y[1] - 1, y[2]);

            // Make the lower one date0
            if (date0 > date1) {
                date0 = date1;
                date1 = new Date(x[0], x[1] - 1, x[2]);
            }

            // Add years to date0 until after date1
            while (addYr(date0) <= date1) {
                date0 = addYr(date0);
                yrCount++;
            }

            // Add months to date0 until after date1
            while (addMth(date0) <= date1) {
                date0 = addMth(date0);
                mthCount++;
            }

            // Add days to date0 until after date1
            while (addDay(date0) <= date1) {
                date0 = addDay(date0);
                dayCount++
            }



            if (yrCount < 18) {
                alert("Minimum DOB should be 18 years");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").focus();
                return "0";
            }
            else {
                return "1";
            }
        }
        function check2k(a) {
            return (a < 1900) ? a -= -1900 : a;
        }

        function addYr(a) {
            return new Date(check2k(1 * a.getYear() + 1), a.getMonth(), a.getDate());
        }

        function addMth(a) {
            return new Date(check2k(a.getYear()), 1 * a.getMonth() + 1, a.getDate());
        }

        function addDay(a) {
            return new Date(check2k(a.getYear()), a.getMonth(), 1 * a.getDate() + 1);
        }


        function funValidate() {
            debugger
            var Mobile1 = SpaceTrim(document.getElementById('<%= TxtMobile.ClientID %>').value);
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "DdlActulPrsnBsns") != null) {
                if (document.getElementById(strContent + "DdlActulPrsnBsns").selectedIndex == 0) {
                    alert("Please select actual person business");
                    document.getElementById(strContent + "DdlActulPrsnBsns").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "cboTitle") != null) {
                if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
                    alert("Please select title");
                    document.getElementById(strContent + "cboTitle").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById(strContent + "TxtMtrName").value) == "") {
                alert("Please enter mentor name");
                document.getElementById(strContent + "TxtMtrName").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //            if (SpaceTrim(document.getElementById(strContent + "TxtMtrAadharNo").value) == "") {
            //                alert("Please enter aadhaar no ");
            //                document.getElementById(strContent + "TxtMtrAadharNo").focus();
            //                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                return false;
            //            }



            //            if (document.getElementById(strContent + "TxtMtrAadharNo").value != "") {
            //                var AadharId = SpaceTrim(document.getElementById('<%= TxtMtrAadharNo.ClientID %>').value);
            //                if (AadharId.length != 12) {
            //                    alert("Incorrect aadhaar no");
            //                    document.getElementById(strContent + "TxtMtrAadharNo").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                    return false;
            //                }


            //            }
            if (document.getElementById(strContent + "DdlResCity").selectedIndex == 0) {
                alert("Please select residing in current city since year");
                document.getElementById(strContent + "DdlResCity").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }
            if (document.getElementById(strContent + "DdlGender") != null) {
                if (document.getElementById(strContent + "DdlGender").selectedIndex == 0) {
                    //alert(document.getElementById(strContent + "hdnID290").value);
                    alert('Please select gender');
                    //alert("1");
                    document.getElementById(strContent + "DdlGender").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById(strContent + "TxtDOB").value) == "") {

                alert("Please enter date of birth");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (dtYear() == "0") {
                document.getElementById("ctl00_ContentPlaceHolder1_TxtDOB").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (document.getElementById(strContent + "cboMaritalStatus") != null) {

                if (document.getElementById(strContent + "cboMaritalStatus").selectedIndex == 0) {
                    alert("Please select marital status");
                    document.getElementById(strContent + "cboMaritalStatus").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById(strContent + "TxtAniversaryDt").value) == "" && (document.getElementById('<%=cboMaritalStatus.ClientID %>').value == "M")) {

                alert("Please enter marriage anniversary date");
                document.getElementById("ctl00_ContentPlaceHolder1_LblAniversaryDt").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (document.getElementById(strContent + "DdlNosOfDependent") != null) {
                debugger;
                if (document.getElementById(strContent + "DdlNosOfDependent").selectedIndex == 0) {
                    debugger;
                    alert("Please enter number of dependants");
                    document.getElementById("ctl00_ContentPlaceHolder1_DdlNosOfDependent").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById(strContent + "TxtSpouseName").value) == "" && (document.getElementById('<%=cboMaritalStatus.ClientID %>').value == "M")) {

                alert("Please enter spouse name");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtSpouseName").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "TxtSpouseDOB").value) == "" && (document.getElementById('<%=cboMaritalStatus.ClientID %>').value == "M")) {

                alert("Please enter spouse DOB date");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtSpouseDOB").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            var selected = $('#<%=ConfirmSpouseWrking.ClientID %> input:radio:checked').length;

            if (document.getElementById('<%=cboMaritalStatus.ClientID %>').value == "M") {
                if (selected > 0) {
                }

                else {

                    alert("Please select spouse working (Yes/No) ");
                    document.getElementById("ctl00_ContentPlaceHolder1_ConfirmSpouseWrking").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById(strContent + "DdlOccuption") != null) {
                if (document.getElementById(strContent + "DdlOccuption").selectedIndex == 0) {
                    debugger;
                    alert('Please select occupation');

                    document.getElementById(strContent + "DdlOccuption").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            ///New
            if (document.getElementById(strContent + "DdlSocialGrp") != null) {
                if (document.getElementById(strContent + "DdlSocialGrp").selectedIndex == 0) {

                    alert('Please select name of social group');

                    document.getElementById(strContent + "DdlSocialGrp").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlFBUsagesFreq") != null) {
                if (document.getElementById(strContent + "DdlFBUsagesFreq").selectedIndex == 0) {

                    alert('Please select FB usages frequency');

                    document.getElementById(strContent + "DdlFBUsagesFreq").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById(strContent + "DdlothrSocialGrp") != null) {
                if (document.getElementById(strContent + "DdlothrSocialGrp").selectedIndex == 0) {

                    alert('Please select other social group');

                    document.getElementById(strContent + "DdlothrSocialGrp").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            var OtherinsAsso = $('#<%=ConfirmOtherinsAsso.ClientID %> input:radio:checked').length;


            if (OtherinsAsso > 0) {

            }

            else {

                alert("Please select is he associated with any industry other than insurance");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmOtherinsAsso").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var Confirmfourwhler = $('#<%=Confirmfourwhler.ClientID %> input:radio:checked').length;


            if (Confirmfourwhler > 0) {

            }

            else {

                alert("Please select has 4 wheeler");
                document.getElementById("ctl00_ContentPlaceHolder1_Confirmfourwhler").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            var ConfirmTwowhler = $('#<%=ConfirmTwowhler.ClientID %> input:radio:checked').length;


            if (ConfirmTwowhler > 0) {

            }

            else {

                alert("Please select has 2 wheeler");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmTwowhler").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            var ConfirmOwnhouse = $('#<%=ConfirmOwnhouse.ClientID %> input:radio:checked').length;


            if (ConfirmOwnhouse > 0) {

            }

            else {

                alert("Please select has own house");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmOwnhouse").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var ConfirmCridtCard = $('#<%=ConfirmCridtCard.ClientID %> input:radio:checked').length;


            if (ConfirmCridtCard > 0) {

            }

            else {

                alert("Please select is he having credit card of any bank ");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmCridtCard").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "TxtConfirmFood").value) == "") {

                alert("Please enter Veg/Non veg");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtConfirmFood").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "Txthobby").value) == "") {

                alert("Please enter hobby");
                document.getElementById("ctl00_ContentPlaceHolder1_Txthobby").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (document.getElementById(strContent + "DdlMthertong") != null) {
                if (document.getElementById(strContent + "DdlMthertong").selectedIndex == 0) {

                    alert('Please select mother tongue');

                    document.getElementById(strContent + "DdlMthertong").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlTypeofAgnt") != null) {
                if (document.getElementById(strContent + "DdlTypeofAgnt").selectedIndex == 0) {

                    alert('Please select type of agent');

                    document.getElementById(strContent + "DdlTypeofAgnt").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlWrkExp") != null) {
                if (document.getElementById(strContent + "DdlWrkExp").selectedIndex == 0) {

                    alert('Please select total work experience (In Years)');

                    document.getElementById(strContent + "DdlWrkExp").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlWrkExpGI") != null) {
                if (document.getElementById(strContent + "DdlWrkExpGI").selectedIndex == 0) {

                    alert('Please select total work experience GI (In Years)');

                    document.getElementById(strContent + "DdlWrkExpGI").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlNameOfGIProduct") != null) {
                if (document.getElementById(strContent + "DdlNameOfGIProduct").selectedIndex == 0) {

                    alert('Please select name of GI product he deal in');

                    document.getElementById(strContent + "DdlNameOfGIProduct").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlWrkExpLI") != null) {
                if (document.getElementById(strContent + "DdlWrkExpLI").selectedIndex == 0) {

                    alert('Please select total work experience LI (In Years)');

                    document.getElementById(strContent + "DdlWrkExpLI").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            var ConfirmFinanceService = $('#<%=ConfirmFinanceService.ClientID %> input:radio:checked').length;


            if (ConfirmFinanceService > 0) {

            }

            else {

                alert("Please select is he deal in other financial service");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmFinanceService").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var ConfirmOthrRcl = $('#<%=ConfirmOthrRcl.ClientID %> input:radio:checked').length;


            if (ConfirmOthrRcl > 0) {

            }

            else {

                alert("Please select deal with any other reliance capital company");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmOthrRcl").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            var Confirmproimaryincom = $('#<%=Confirmproimaryincom.ClientID %> input:radio:checked').length;


            if (Confirmproimaryincom > 0) {

            }

            else {

                alert("Please select is insurance primary source of income");
                document.getElementById("ctl00_ContentPlaceHolder1_Confirmproimaryincom").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (document.getElementById(strContent + "DdlAnulFmlyIncom") != null) {
                if (document.getElementById(strContent + "DdlAnulFmlyIncom").selectedIndex == 0) {

                    alert('Please select annual family income');

                    document.getElementById(strContent + "DdlAnulFmlyIncom").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlAnualBusns") != null) {
                if (document.getElementById(strContent + "DdlAnualBusns").selectedIndex == 0) {

                    alert('Please select annual business (In lacs)');

                    document.getElementById(strContent + "DdlAnualBusns").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            //			    if (document.getElementById(strContent + "DdlmtrBusns") != null) {
            //			        if (document.getElementById(strContent + "DdlmtrBusns").selectedIndex == 0) {
            if (SpaceTrim(document.getElementById(strContent + "DdlmtrBusns").value) == "") {

                alert('Please enter motor contribution (In %)');

                document.getElementById(strContent + "DdlmtrBusns").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //			    }
            //			    if (document.getElementById(strContent + "DdltrvlBusns") != null) {
            //			        if (document.getElementById(strContent + "DdltrvlBusns").selectedIndex == 0) {
            if (SpaceTrim(document.getElementById(strContent + "DdltrvlBusns").value) == "") {

                alert('Please enter travel contribution (In %)');

                document.getElementById(strContent + "DdltrvlBusns").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
                //}
            }
            //			    if (document.getElementById(strContent + "DdlhealthBusns") != null) {
            //			        if (document.getElementById(strContent + "DdlhealthBusns").selectedIndex == 0) {

            if (SpaceTrim(document.getElementById(strContent + "DdlhealthBusns").value) == "") {
                alert('Please enter health contribution (In %)');

                document.getElementById(strContent + "DdlhealthBusns").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
                // }
            }
            //			    if (document.getElementById(strContent + "DdlCLBusns") != null) {
            // if (document.getElementById(strContent + "DdlCLBusns").selectedIndex == 0) {
            if (SpaceTrim(document.getElementById(strContent + "DdlCLBusns").value) == "") {
                alert('Please enter CL contribution (In %)');

                document.getElementById(strContent + "DdlCLBusns").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
                //}
            }



            var ConfirmOthrGI = $('#<%=ConfirmOthrGI.ClientID %> input:radio:checked').length;


            if (ConfirmOthrGI > 0) {

            }

            else {

                alert("Please select working with other GI companies");
                document.getElementById("ctl00_ContentPlaceHolder1_ConfirmOthrGI").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Mobile
            if (SpaceTrim(document.getElementById(strContent + "TxtMobile").value) == "") {
                alert("Mobile No. is mandatory");
                document.getElementById(strContent + "TxtMobile").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {
                var Mobile = SpaceTrim(document.getElementById('<%= TxtMobile.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No. Should be 10 digit");
                    document.getElementById(strContent + "TxtMobile").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (Mobile.substr(0, 1) == "0") {
                    alert("Mobile No. Should Not Start With 0");
                    document.getElementById(strContent + "TxtMobile").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (Mobile1.substr(0, 1) == "1" || Mobile1.substr(0, 1) == "2" || Mobile1.substr(0, 1) == "3"
            || Mobile1.substr(0, 1) == "4" || Mobile1.substr(0, 1) == "5" || Mobile1.substr(0, 1) == "6") {
                alert("Mobile No. Should Start With (7,8,9)");
                document.getElementById(strContent + "TxtMobile").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }

            if (SpaceTrim(document.getElementById(strContent + "TxtEmail").value) == "") {
                alert("Email is mandatory.");
                document.getElementById(strContent + "TxtEmail").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {

                var emailid = (document.getElementById(strContent + "TxtEmail").value);
                if (validateEmail1(emailid) == 0) {
                    return false;
                }
            }
            if (document.getElementById(strContent + "DdlNosofContact") != null) {
                if (document.getElementById(strContent + "DdlNosofContact").selectedIndex == 0) {

                    alert('Please select number of contacts in phone');

                    document.getElementById(strContent + "DdlNosofContact").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlBasicQual") != null) {
                if (document.getElementById(strContent + "ddlBasicQual").selectedIndex == 0) {

                    alert('Please select education qualification ');

                    document.getElementById(strContent + "ddlBasicQual").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlProfQual") != null) {
                if (document.getElementById(strContent + "ddlProfQual").selectedIndex == 0) {

                    alert('Please select professional qualification ');

                    document.getElementById(strContent + "ddlProfQual").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }



        }
        //Function end 

        function SpaceTrim(InString) {
            var LoopCtrl = true;
            while (LoopCtrl) {
                if (InString.indexOf("  ") != -1) {
                    Temp = InString.substring(0, InString.indexOf("  "));
                    InString = Temp + InString.substring(InString.indexOf("  ") + 1, InString.length);
                }
                else
                    LoopCtrl = false;
            }
            if (InString.substring(0, 1) == " ")
                InString = InString.substring(1, InString.length);
            if (InString.substring(InString.length - 1) == " ")
                InString = InString.substring(0, InString.length - 1);
            return (InString);
        }
        function validateEmail1(sEmail1) {
            debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail1.match(reEmail)) {
                alert("Please enter valid email");
                document.getElementById("ctl00_ContentPlaceHolder1_TxtEmail").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return 0;
            }

            return 1;

        }

    </script>



    <asp:ScriptManager ID="SM1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>

    <div  id="dvnew">
         <asp:Label ID="lblError2" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="lblMessage" Visible="false" runat="server" ForeColor="#C04000"></asp:Label>

        <div class="panel" style="display:none">
            <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPersonal','ctl00_ContentPlaceHolder1_btnpersnl');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label4" runat="server" Text="Agent Details" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div class="panel-body" id="divPersonal" style="display:block;">
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="lblAppNo" runat="server" Font-Bold="False"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <%--  <asp:TextBox ID="lblAppNoValue" runat="server" Enabled="false" CssClass="form-control" > </asp:TextBox>--%>
                        <asp:Label ID="lblAppNoValue" Style="text-align: center" runat="server" Font-Bold="False"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCndNo" runat="server" Font-Bold="False"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCndNoValue" runat="server" Font-Bold="False"></asp:Label>
                        <%-- <asp:TextBox ID="lblCndNoValue" runat="server" Enabled="false" CssClass="form-control" > </asp:TextBox>--%>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <%--  <span style="color: red">  *</span>--%>
                        <asp:Label ID="LblMtrAadharNo" runat="server" Font-Bold="False" Style="color: black"></asp:Label>

                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TxtMtrAadharNo" runat="server" Enabled="false" CssClass="form-control" MaxLength="12" TabIndex="18"> </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender88" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                            FilterMode="InvalidChars" TargetControlID="TxtMtrAadharNo" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-3">

                        <%-- <asp:Label ID="AadharVerify" Visible="false" runat="server" Font-Bold="False" Text="Do you want to verify Aadhar No ?"></asp:Label>--%>
                        <asp:Label ID="LblCndName" runat="server" Font-Bold="False" Text="Candidate Name"></asp:Label>

                    </div>
                    <div id="Td3" align="left" class="col-sm-3" runat="server">
                        <asp:TextBox ID="TxtCndName" runat="server" Enabled="false" CssClass="form-control" TabIndex="18"> </asp:TextBox>
                        <%--<asp:RadioButtonList ID="ConfirmAadhar" Visible="false" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="ConfirmAadharVerification_SelectedIndexChanged">
                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="N" Selected="True" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>--%>
                    </div>
                </div>
                <tr>


                    <td id="Td1" runat="server" class="formcontent" style="width: 20%;">

                        <asp:Label ID="LblAadharVerfy" Visible="false" runat="server" Font-Bold="False" Style="color: black"></asp:Label>

                    </td>
                    <td id="Td2" align="left" runat="server" class="formcontent" style="width: 20%;">
                        <asp:DropDownList ID="DdlAadharVerfy" Visible="false" AutoPostBack="true" runat="server" CssClass="standardmenu">
                            <%--removed by ashitosh for adhar-- %><%--OnSelectedIndexChanged="DDlAadharVerfy_SelectedIndexChanged"--%>
                        </asp:DropDownList>
                    </td>

                    <td class="formcontent" style="width: 20%;">
                        <%--<span style="color: red">--%>
                        <asp:Label ID="LblAadharOTP" runat="server" Visible="false" Font-Bold="False" Style="color: black"></asp:Label>
                        <%-- *</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdateOTP" Visible="false" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TxtAadharOTP" runat="server" CssClass="standardtextbox" MaxLength="10"
                                    TabIndex="16"></asp:TextBox>


                                <asp:Button ID="BtnOTP" runat="server" Text="Verify" CssClass="standardbutton"
                                    Width="50px" TabIndex="17"></asp:Button>
                                <%--Commented by ashitosh--%> <%-- OnClick="btnVerifyOTP_Click"--%>
                                <div id="div2" class="Content" style="display: none">
                                    <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                    <asp:Label ID="LblAaharotp" Text="Aadhaar no verified" Visible="false" runat="server"></asp:Label>
                                </div>
                                <br />


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </div>

        </div>

        <div class="panel"  >
            <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divIsSpecified', 'ctl00_ContentPlaceHolder1_btnPersonal');">
                        <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label5" runat="server" Text="Personal Details" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnPersonal" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>


            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div id="divIsSpecified" runat="server" style="display: block;">
                        <asp:UpdatePanel ID="Updatepanel13" runat="server">
                            <ContentTemplate>

                                <div class="panel-body" runat="server" id="tbltest">
                                    <div class="row">

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblActulPrsnBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DdlActulPrsnBsns" OnSelectedIndexChanged="DdlActulPrsnBsns_SelectedIndexChanged"
                                                        AutoPostBack="true" runat="server" CssClass="form-control" TabIndex="5" Enabled="false">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                        </div>

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblResCity" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="DdlResCity" runat="server" CssClass="form-control" TabIndex="9">
                                            </asp:DropDownList>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblMtrName" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <div class="input-group">
                                                <span class="input-group-addon input-addon_extended">
                                                    <asp:DropDownList ID="cboTitle" runat="server" CssClass="form-control"
                                                        DataTextField="ParamDesc" DataValueField="ParamValue"
                                                        AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                                        TabIndex="5">
                                                    </asp:DropDownList>
                                                </span>
                                                <asp:TextBox ID="TxtMtrName" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                                <asp:SqlDataSource ID="dscbotitle" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                                <asp:HiddenField ID="hdnGenderTitle1" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnGenderTitle2" runat="server"></asp:HiddenField>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblGender" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="DdlGender" runat="server" CssClass="form-control" TabIndex="9">
                                            </asp:DropDownList>
                                        </div>

                                    </div>


                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblDOB" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtDOB" runat="server" CssClass="form-control" MaxLength="12" TabIndex="18"
                                                onmousedown="$('#TxtDOB').datepicker({ changeMonth: true, changeYear: true });" onchange="setDateFormat('txtDob')"> 
                                            </asp:TextBox>

                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="Lblmaritalstatus" runat="server" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="cboMaritalStatus" runat="server" CssClass="form-control" AutoPostBack="true"
                                                        OnSelectedIndexChanged="cboMaritalStatus_OnSelectedIndexChanged" TabIndex="13">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblAniversaryDt" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtAniversaryDt" runat="server" CssClass="form-control"
                                                TabIndex="11" onmousedown="$('#TxtDOB').datepicker({ changeMonth: true, changeYear: true });" onchange="setDateFormat('txtDob')" />



                                            </asp:TextBox>
                                                       
                                        </div>


                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblNosOfDependent" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="DdlNosOfDependent" runat="server" CssClass="form-control" AutoPostBack="true"
                                                TabIndex="13">
                                                <asp:ListItem Text="Select" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>

                                            </asp:DropDownList>

                                        </div>


                                    </div>
                                    <div class="row">

                                        <div class="col-sm-3">

                                            <asp:Label ID="LblSpouseName" runat="server" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtSpouseName" runat="server" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblSpouseDOB" runat="server" Style="color: black"></asp:Label>


                                        </div>

                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtSpouseDOB" runat="server" CssClass="form-control"
                                                TabIndex="11" onmousedown="$('#TxtDOB').datepicker({ changeMonth: true, changeYear: true });"
                                                onchange="setDateFormat('txtDob')" />

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblSpouseWrking" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">

                                            <asp:RadioButtonList ID="ConfirmSpouseWrking" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="ConfirmSpouseWrking_SelectedIndexChanged">
                                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblOrgname" runat="server" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtSpouseOrgname" runat="server" Enabled="false" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblchildName1" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtchildName1" runat="server" CssClass="form-control" MaxLength="60" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblchildDob" runat="server" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="Txtchild1Dob" runat="server" CssClass="form-control"
                                                TabIndex="11" onmousedown="$('#TxtDOB').datepicker({ changeMonth: true, changeYear: true });" onchange="setDateFormat('txtDob')" />

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblchildName2" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtchildName2" runat="server" CssClass="form-control" MaxLength="60" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="Lblchild2Dob" runat="server" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="Txtchild2Dob" runat="server" CssClass="form-control"
                                                TabIndex="11" onmousedown="$('#TxtDOB').datepicker({ changeMonth: true, changeYear: true });" onchange="setDateFormat('txtDob')" />

                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblOccuption" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: #ff0000">
                                                <asp:DropDownList ID="DdlOccuption" runat="server" CssClass="form-control" CausesValidation="true"
                                                    TabIndex="108">
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblSocialGrp" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="DdlSocialGrp" runat="server" CssClass="form-control" CausesValidation="true">
                                            </asp:DropDownList>


                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblFBUsagesFreq" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: #ff0000">
                                                <asp:DropDownList ID="DdlFBUsagesFreq" runat="server" CssClass="form-control" CausesValidation="true"
                                                    TabIndex="108">
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblothrSocialGrp" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="DdlothrSocialGrp" runat="server" CssClass="form-control" CausesValidation="true"
                                                TabIndex="108">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblOtherinsAsso" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>

                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:RadioButtonList ID="ConfirmOtherinsAsso" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                        EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="ConfirmOtherinsAsso_SelectedIndexChanged">
                                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--<asp:TextBox ID="TxtOtherinsAsso" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  MaxLength="12" TabIndex="18" ></asp:TextBox>--%>
                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblNameOtherinsAsso" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtNameOtherinsAsso" runat="server" CssClass="form-control" Enabled="false" MaxLength="100" TabIndex="18"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="Lblfourwhler" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:RadioButtonList ID="Confirmfourwhler" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                        EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="Confirmfourwhler_SelectedIndexChanged">
                                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="LblfourwhlerMake" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtfourwhlerMake" runat="server" Enabled="false" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-sm-3">

                                            <asp:Label ID="Lblfourwhlermodel" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="Txtfourwhlermodel" runat="server" Enabled="false" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblTwowhler" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButtonList ID="ConfirmTwowhler" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="Confirmfourwhler_SelectedIndexChanged">
                                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblOwnhouse" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButtonList ID="ConfirmOwnhouse" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="Confirmfourwhler_SelectedIndexChanged">
                                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblcridtCard" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButtonList ID="ConfirmCridtCard" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px">
                                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<asp:TextBox ID="TxtcridtCard" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  MaxLength="12" TabIndex="18" ></asp:TextBox>--%>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblVeg" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtConfirmFood" runat="server" CssClass="form-control" MaxLength="12" TabIndex="18"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3">

                                            <asp:Label ID="Lblpassport" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="Txtpassport" runat="server" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="Lblhobby" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">

                                            <asp:TextBox ID="Txthobby" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="100" TabIndex="18"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="LblMthertong" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                                *</span>

                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: #ff0000">
                                                <asp:DropDownList ID="DdlMthertong" runat="server" CssClass="form-control" CausesValidation="true"
                                                    TabIndex="108">
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="panel"  >
            <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPlan', 'ctl00_ContentPlaceHolder1_btnPlan');">
                 <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label2" runat="server" Text="Business Experiences" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnPlan" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>


            <div id="divPlan" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel4" runat="server">
                    <ContentTemplate>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblTypeofAgnt" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlTypeofAgnt" runat="server" CssClass="form-control" CausesValidation="true"
                                            TabIndex="108">
                                        </asp:DropDownList>
                                    </span>
                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblWrkExp" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlWrkExp" runat="server" CssClass="form-control" CausesValidation="true"
                                            TabIndex="108">
                                        </asp:DropDownList>
                                    </span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblWrkExpGI" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlWrkExpGI" runat="server" CssClass="form-control" CausesValidation="true"
                                            TabIndex="108">
                                        </asp:DropDownList>
                                    </span>
                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblNameOfWrkExpGI" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlNameOfGIProduct" runat="server" CssClass="form-control" CausesValidation="true"
                                            TabIndex="108">
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="TxtNameOfWrkExpGI" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  MaxLength="12" TabIndex="18" ></asp:TextBox>--%>
                                    </span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblWrkExpLI" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlWrkExpLI" runat="server" CssClass="form-control" CausesValidation="true" TabIndex="108">
                                        </asp:DropDownList>
                                    </span>
                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblFinanceService" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">

                                    <asp:RadioButtonList ID="ConfirmFinanceService" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="Confirmfourwhler_SelectedIndexChanged">
                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblFinanceServiceName" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">

                                    <%--<asp:ListBox ID="ListFinanceServiceName" runat="server" AppendDataBoundItems="True"
                                                               Style="width: 100%;" SelectionMode="Multiple"></asp:ListBox>--%>
                                    <asp:DropDownList ID="ListFinanceServiceName" runat="server" CssClass="form-control" CausesValidation="true">
                                    </asp:DropDownList>


                                </div>
                                <div class="col-sm-3"></div>
                                <div class="col-sm-3"></div>

                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblOthrRcl" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">


                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="ConfirmOthrRcl" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="ConfirmOthrRcl_SelectedIndexChanged">
                                                <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="LblOthrRclName" runat="server" Font-Bold="False" Style="color: black"></asp:Label>


                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel runat="server" ID="updcompName">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlcompName" runat="server" CssClass="form-control" TabIndex="6" Enabled="false">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%-- <span style="color: #ff0000">
                                                <asp:TextBox ID="TxtOthrRclName" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"  MaxLength="12" TabIndex="18" ></asp:TextBox>
                                                </span>--%>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="Lblproimaryincom" runat="server" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">

                                    <asp:RadioButtonList ID="Confirmproimaryincom" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                        EnableViewState="true" CellPadding="2" CellSpacing="2" Width="90px" OnSelectedIndexChanged="Confirmfourwhler_SelectedIndexChanged">
                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>


                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblAnulFmlyIncom" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="DdlAnulFmlyIncom" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="panel" >
            <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusiness', 'ctl00_ContentPlaceHolder1_BtnBusiness');">
                  <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label1" runat="server" Text="Total Business" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="BtnBusiness" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>


            <div id="divBusiness" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel5" runat="server">
                    <ContentTemplate>

                        <div runat="server" id="Table2" class="panel-body" >

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblAnualBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="DdlAnualBusns" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:DropDownList>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblmtrBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="DdlmtrBusns" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:TextBox>


                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LbltrvlBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>

                                <div class="col-sm-3">
                                    <asp:TextBox ID="DdltrvlBusns" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:TextBox>


                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblhealthBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="DdlhealthBusns" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:TextBox>


                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblCLBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="DdlCLBusns" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:TextBox>


                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblTotalBusns" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="DdlTotalBusns" Enabled="false" runat="server" CssClass="form-control" CausesValidation="true"
                                        TabIndex="108">
                                    </asp:TextBox>


                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblOthrGI" runat="server" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">

                                    <asp:RadioButtonList ID="ConfirmOthrGI" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                        EnableViewState="true" Width="90px" CellPadding="2" CellSpacing="2">
                                        <asp:ListItem Value="Y" Text="Yes">&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblStaldaloneGI" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:TextBox ID="TxtStaldaloneGI" runat="server" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                    </span>
                                </div>
                            </div>

                        </div>


                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <%-- Contact Information--%>
        <div class="panel" >
            <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3', 'ctl00_ContentPlaceHolder1_btnContact');">
                 <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label6" runat="server" Text="Contact Information" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnContact" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>

            <div id="div3" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel6" runat="server">
                    <ContentTemplate>

                        <div runat="server" id="Table3" class="panel-body">

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblMobile" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control"
                                        MaxLength="10" TabIndex="18"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                        FilterMode="InvalidChars" TargetControlID="TxtMobile" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>

                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="LblWhatsaap" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:TextBox ID="TxtWhatsaap" runat="server" CssClass="form-control" MaxLength="10" TabIndex="18"></asp:TextBox>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Lblpfhometel" runat="server" Font-Bold="False" Style="color: black"></asp:Label>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="TxtSTD" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>

                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="LblLandline" runat="server" Font-Bold="False" Style="color: black"></asp:Label>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="TextLandline" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblEmail" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblNosofConcate" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                        *</span>
                                </div>
                                <div class="col-sm-3">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="DdlNosofContact" runat="server" CssClass="form-control" CausesValidation="true"
                                            TabIndex="108">
                                        </asp:DropDownList>
                                    </span>
                                    </td>
                                </div>


                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>



        <%--  education details--%>

        <%--  education details--%>

        <div class="panel " style="width: 90%">

            <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div1', 'ctl00_ContentPlaceHolder1_btnProofofDocument');">
                    <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label7" runat="server" Text="Education Details" CssClass="control-label" Font-Size="19px"></asp:Label>

                    </div>
                    <div class="col-sm-2">
                        <span id="btnProofofDocument" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>




            <div id="div1" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel7" runat="server">
                    <ContentTemplate>

                        <div runat="server" id="Table4" class="panel-body">

                            <div class="row">
                                <div class="col-sm-3">
                                    <span style="color: red">
                                        <asp:Label ID="LblBasicQual" runat="server" Style="color: black"></asp:Label>
                                        *</span>

                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlBasicQual" runat="server" CssClass="form-control"
                                        AutoPostBack="true" CausesValidation="true" TabIndex="109">
                                    </asp:DropDownList>

                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="LblProfQual" runat="server" Style="color: black"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlProfQual" runat="server" CssClass="form-control"
                                        TabIndex="107">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="LblInsQual" runat="server" Style="color: black">
                                    </asp:Label>

                                </div>

                                <div class="col-sm-3">
                                    <asp:DropDownList ID="DdlInsQual" runat="server" CssClass="form-control"
                                        AutoPostBack="true" CausesValidation="true" TabIndex="109">
                                    </asp:DropDownList>

                                </div>
                                <div class="col-sm-3"></div>
                                <div class="col-sm-3"></div>

                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>



        <div class="row" align="Center" runat="server">
            <div class="col-sm-12">
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" CausesValidation="false"
                    OnClick="btnUpdate_Click" OnClientClick="return funValidate();" TabIndex="244">
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> SAVE
                </asp:LinkButton>


                <%-- <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" CausesValidation="false"
                            OnClick="btnUpdate_Click" OnClientClick="return funValidate();" Style='margin-top: 5px' TabIndex="244" />--%>

                        &nbsp;&nbsp;
                <asp:LinkButton ID="btnCancel"  style="background-color:#FFF;color:#f04e5e; width:85px !important"  runat="server" CssClass="btn btn-danger"
                    CausesValidation="False" Text="Cancel" OnClick="btnCancel_Click" TabIndex="245">

                    <span style="color:#f04e5e" class="glyphicon glyphicon-remove BtnGlyphicon"> </span> CANCEL
                </asp:LinkButton>

                <div id="divloader" runat="server" style="display: none;">
                    &nbsp;&nbsp;
                            <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                    Loading...
                </div>
            </div>
        </div>


    </div>
    <input type="hidden" runat="server" id="hdnUserId" />
    <%--Commented by ashitosh for change in save modal popup--%>
    <%--<asp:Panel ID="pnl" runat="server" class="modalpopupmesg" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" Width="350px" Height="200px">
        <table width="100%">
            <tr align="center">
                <td class="test" width="100%" colspan="1" style="height: 32px">INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                             <asp:Label ID="lbl" runat="server"></asp:Label><br />
                        </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
        <asp:Button ID="btnok" runat="server" Text="OK"  
               Width="81px" />
       </center>
    </asp:Panel>--%>
    <%--Commented by ashitosh for change in save modal popup end--%>
    <%--<ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" X="260" Y="100">
    </ajaxToolkit:ModalPopupExtender>--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />

    <%--Commented by ashitosh for change in save modal popup--%>

    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <%--background-color: #C0C0C0;--%>
        <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
    </asp:Panel>
    <%--Commented by ashitosh for change in save modal popup end--%>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">



            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label16" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <span class="glyphicon glyphicon-ok  BtnGlyphicon"></span>OK</button>

                </div>
            </div>



        </div>
    </div>
    <%--</div>--%>
</asp:Content>

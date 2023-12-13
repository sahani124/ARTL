<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="frmCND_Personal.aspx.cs"
    Inherits="Application_INSC_Recruit_frmCND_Personal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/Application/Common/CltDetailAddr.ascx" TagName="AddAddr" TagPrefix="uc1" %>
<%@ Register Src="../../../App_UserControl/Common/txtDate.ascx" TagName="txtDate"
    TagPrefix="uc2" %>
<%@ Register Src="../../../App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup"
    TagPrefix="uc3" %>
<%@ Register Src="../../../App_UserControl/Common/ddlLookup2.ascx" TagName="ddlLookup"
    TagPrefix="uc4" %>
<%@ Register Src="../../../App_UserControl/Common/popupOccupation.ascx" TagName="popupOccupation"
    TagPrefix="uc5" %>
<%@ Register Src="~/Application/Common/popupAML.ascx" TagName="popupAML" TagPrefix="uc6" %>
<%@ Register Src="~/Application/Common/ClientAML.ascx" TagName="ClientAML" TagPrefix="uc8" %>
<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
<%@ Register Src="~/Application/Common/ClientAddress.ascx" TagName="ClientAddress"
    TagPrefix="uc9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
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
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=11"/>
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
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
  <%--  <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />--%>
  <%--  <meta http-equiv="X-UA-Compatible" content="IE=edge" />--%>
<%--    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />--%>
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
    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            // $("#<%= txtDOB.ClientID  %>").datepicker({ maxDate: new Date(), dateFormat: 'dd/mm/yy' });
        });
    </script>
    <script language="javascript" type="text/javascript">

        function openBranchList(BizSrc, ChnCls, AgentType, MgrCode, Type, IsAgt, agttype) {
            debugger;
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../ChannelMgmt/UntLst.aspx?UnitCode=&CmpUntObj=&UntObj=&BizSrc=" + BizSrc
            + "&ChnCls=" + ChnCls + "&AgentType=" + AgentType + "&MgrCode=" + MgrCode + "&UntAdr=&Type=" + Type + "&OutUntCode=&hdn2=&OutUntDesc=&hdn1=&OutCmpUnt=&RecruitDate=&Source=1&IsAgt=" + IsAgt
            + "&mdlpopup=mdlViewBID&agttype=" + agttype + "&page=REG";
        }

        function ShowReqDtl(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }


        function popup() {
            $("#myModal").modal();
        }
        function LdWait(delay) {
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }







        function RemoveLoading12() {

            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';

        }
        function HideProgressBar() {

            //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();

        }

        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            //document.getElementById("btnSubmit").click();
            return true;
        }

        //Added by Rahul on 28-04-2015 for Work Tel Validation start
        function CheckWorkTelFormat(sValue) {
            var result = true;
            var LocalTel = sValue;

            strLocalTel = new String(LocalTel)

            if (strLocalTel.length > 0) {
                if (!IsNumeric(strLocalTel)) {
                    return 0;
                }
                strLocalTel = strLocalTel.substr(0, 1)
                if (strLocalTel == "0") {
                    return 0;
                }
            }

            return 1;
        }
        //Added by Rahul on 28-04-2015 for Work Tel Validation end

        function FrmToDateValidation(args1, argsID1, args2, argsID2) {
            var Splitargs1 = args1.split("/");
            var Splitargs2 = args2.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var EndMonth = eval(Splitargs2[1]);
            var EndYear = eval(Splitargs2[2]);
            var BeginDate = new Date(BeginYear, BeginMonth - 1, 1);
            var EndDate = new Date(EndYear, EndMonth - 1, 1);
            var BeginDate1 = args1;
            var EndDate1 = args2;
            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID1).focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return 1;
                }
            }
            if (EndMonth != '' && EndYear != '') {
                if (!validDate(EndDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID2).focus();
                    return 1;
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                }
            }

            return 0;
        }
        //        
        function funrecruitercode() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "btnUpdate").focus();
        }
        function funpan() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "ddlPrimProf").focus();
        }
        //Added By pranjali on 17-12-2013 for button verify SM Code validation start


        function funValidateEmpCode() {

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (SpaceTrim(document.getElementById(strContent + "txtEmpCode").value) == "") {
                alert("Please enter Employee Code");
                document.getElementById(strContent + "txtEmpCode").focus();
                return false;
            }
        }
        //Added By pranjali on 17-12-2013 for button verify SM Code validation end
        //Added By pranjali on 20-12-2013 for pan validation start
        function ValidationPAN() {
            var varPAN = document.getElementById('<%= txtpan.ClientID %>').value;
            //document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';
            if (varPAN.length == 0) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }

            //Validation for PAN No format.
            if (SpaceTrim(document.getElementById('<%= txtpan.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtpan.ClientID %>').value)) == 0) {
                    document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert('Invalid Pan Format');
                    document.getElementById('<%= txtpan.ClientID %>').focus();
                    return false;
                }
            }
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
            document.getElementById('<%=hdnPan.ClientID%>').value = '0';
            document.getElementById('divPAN').style.display = 'block'
        }

        function CheckPANFormat(strPANNo) {

            var result = true;
            var pan = strPANNo.split(",");
            var Char;

            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                return 0;
                            }
                            if (j == 3) {

                                if (pan2.substring(j, j + 1) != 'P') {
                                    return 0;
                                }
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return 0;
                            }
                        }
                    }
                }
                else {
                    return 0;
                }
            }
            return 1;
        }

        function isAlphabet(strText) {
            var inputStr = strText
            for (var intCounter = 0; intCounter < inputStr.length; intCounter++) {
                var oneChar = inputStr.substring(intCounter, intCounter + 1)

                if (oneChar.toUpperCase() < "A" || oneChar.toUpperCase() > "Z") {
                    return false

                }
            }
            return true
        }

        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;

            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }

            return IsNumber;
        }

        //Added by Rahul Kamble on 28-04-2015 for Given Name Space validation start
        function CheckSpaces() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            var strText = document.getElementById(strContent + "txtpfGivenName").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtpfGivenName").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 2) {
                    alert("More than 2 spaces are not allowed in Name.");
                }
            }
            return false;
        }
        //Ended by Rahul Kamble on 28-04-2015 for Given Name Space validation end

        //Added by Nikhil Pathari on 11-05-2015 for father Name Space validation start

        function AllowSpace() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            var strText = document.getElementById(strContent + "txtFatherName").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtFatherName").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Name.");
                }
            }
            return false;
        }

        //Ended by Nikhil Pathari on 11-05-2015 for Father Name Space validation end



        //Added By pranjali on 20-12-2013 for pan validation end
        function funValidate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            var Mobile1 = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
            var Mobile2 = SpaceTrim(document.getElementById('<%= txtMobile2.ClientID %>').value);
  <%--if (SpaceTrim(document.getElementById(strContent + "txtaadhr").value) == "") {
                alert("Please Enter Aadhar no ");
                document.getElementById(strContent + "txtaadhr").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }



            if (document.getElementById(strContent + "txtaadhr").value != "") {
                var AadharId = SpaceTrim(document.getElementById('<%= txtaadhr.ClientID %>').value);
                if (AadharId.length != 12) {
                    alert("Incorrect Aadhar no");
                    document.getElementById(strContent + "txtaadhr").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


            }--%>

            var varPAN = document.getElementById('<%= txtpan.ClientID %>').value;
            //document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';

            if (varPAN.length == 0) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtpan.ClientID %>').focus();
                return false;
            }

            if (SpaceTrim(document.getElementById('<%= txtpan.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtpan.ClientID %>').value)) == 0) {
                    document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert('Invalid Pan Format');
                    document.getElementById('<%= txtpan.ClientID %>').focus();
                    return false;
                }
            }
            debugger;
             <%--if ((document.getElementById('<%=hdnPan.ClientID%>').value == null || document.getElementById('<%=hdnPan.ClientID%>').value == '0')) 
             {
                    document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert('Please Validate Pan Number');
                    document.getElementById('<%= txtpan.ClientID %>').focus();
                    return false;
            }

            if (!(document.getElementById('<%=hdnPanValue.ClientID%>').value == null || document.getElementById('<%=hdnPanValue.ClientID%>').value == ''))
            {
                if (document.getElementById('<%=hdnPanValue.ClientID%>').value != document.getElementById('<%= txtpan.ClientID%>').value) {
                    document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert('Please Validate Pan Number');
                    document.getElementById('<%= txtpan.ClientID %>').focus();
                    return false;
                }
                
            }--%>

            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "Select") {
                alert("Current Occupation is Mandatory");
                document.getElementById('<%= ddlPrimProf.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }


            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "HW") {
                if ((document.getElementById('<%=cboTitle.ClientID %>').value == "MISS") || (document.getElementById('<%=cboTitle.ClientID %>').value == "MRS") || (document.getElementById('<%=cboTitle.ClientID %>').value == "SHRI") || (document.getElementById('<%=cboTitle.ClientID %>').value == "SMT")) {

                }
                else {
                    alert("Please select proper Occupation and Title");
                    document.getElementById(strContent + "cboTitle").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
            }


            if ((document.getElementById('<%=ddlPrimProf.ClientID %>').value == "HW") && (document.getElementById('<%=cboGender.ClientID %>').value == "M")) {
                alert("Please select proper Profession and Gender Type");
                document.getElementById(strContent + "cboGender").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //Validation for Given Name
            if (document.getElementById(strContent + "cboTitle") != null) {
                if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID280").value);
                    document.getElementById(strContent + "cboTitle").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
            }
            //Added Validation for Given Name by pranjali start
            if (SpaceTrim(document.getElementById(strContent + "txtpfGivenName").value) == "") {
                alert("Please enter Given Name");
                document.getElementById(strContent + "txtpfGivenName").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            var lenGivenName = document.getElementById('<%= txtpfGivenName.ClientID %>').value;
            if (lenGivenName.length < 3) {
                alert("Given Name should be atleast of three Characters");
                document.getElementById('<%= txtpfGivenName.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            CheckSpaces();
            //Added Validation for Given Name by pranjali end
            //Validation for SurName
            //if (SpaceTrim(document.getElementById(strContent + "txtpfSurname").value) == "") {
            //    alert(document.getElementById(strContent + "hdnID470").value);
            //    document.getElementById(strContent + "txtpfSurname").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            //var Surname = document.getElementById('<%= txtpfSurname.ClientID %>').value;
            //if (Surname.length < 3) {
            //    alert("Surname should be atleast of three Characters");
            //    document.getElementById('<%= txtpfSurname.ClientID %>').focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}
            ////            //Validation for Father/ Spouse Name
            ////            if (SpaceTrim(document.getElementById('<%= txtFatherName.ClientID %>').value) == "") {
            ////                alert("Father / Spouse Name is mandatory.");
            ////                document.getElementById('<%= txtFatherName.ClientID %>').focus();
            ////                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            ////                
            ////                return false;
            ////            }

            //VAlidation on FatherName , only allowing Alphabets and Space
            //           if (isAlphabetSpace(document.getElementById('<%= txtFatherName.ClientID %>').value) == false) {
            //                alert("Special character are not allowed for Father/Spouse Name");
            //                document.getElementById('<%= txtFatherName.ClientID %>').focus();
            //                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                
            //                return false;
            //            }
            //            var lenFather = document.getElementById('<%= txtFatherName.ClientID %>').value;
            //            if (lenFather.length < 3) {
            //                alert("Father/Spouse Name should be atleast of three Characters");
            //                document.getElementById('<%= txtFatherName.ClientID %>').focus();
            //                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                
            //                return false;
            //            }
            if (SpaceTrim(document.getElementById(strContent + "txtFatherName").value) == "") {
                alert("Please enter Father/Spouse Name");
                document.getElementById(strContent + "txtFatherName").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();

                return false;
            }

            var lenFather = document.getElementById('<%= txtFatherName.ClientID %>').value;
            if (lenFather.length < 3) {
                alert("Father Name should be atleast of three Characters");
                document.getElementById('<%= txtFatherName.ClientID %>').focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();

                return false;
            }
            AllowSpace();

            if (document.getElementById('<%=ddlCategory.ClientID %>').value == "Select") {
                alert("Classification is Mandatory.");
                document.getElementById('<%= ddlCategory.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //added by pranjali on 11-03-2014 for gender validation start
            if ((document.getElementById('<%=cboGender.ClientID %>').value == "Select") || (document.getElementById('<%=cboGender.ClientID %>').value == "")) {
                alert("Please Select Gender");
                document.getElementById('<%= cboGender.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //added by pranjali on 11-03-2014 for gender validation end
            //Validation for Nationality
            if ((SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) == "") || (document.getElementById(strContent + "txtNationalCode").value) != "IND") {
                alert(document.getElementById(strContent + "hdnID320").value);
                document.getElementById(strContent + "txtNationalCode").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) != null) {
                if (SpaceTrim(document.getElementById(strContent + "txtNationalDesc").value) == "") {
                    alert(document.getElementById(strContent + "hdnID320").value);
                    document.getElementById(strContent + "txtNationalCode").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
            }
            //Validation for Marital Status
            if (document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "Select" || document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "") {
                alert("Please Select Marital Status");
                document.getElementById(strContent + "cboMaritalStatus").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            //added by pranjali on 20-03-2014 start
            if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
                alert("Invalid Title");
                document.getElementById(strContent + "cboTitle").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            //added by meena on 27/11/17 start
            if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MISS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value != "S")) {

                alert("Invalid Title");
                document.getElementById(strContent + "cboTitle").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
                alert("Invalid Title");
                document.getElementById(strContent + "cboTitle").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //added by meena on 27/11/17 end
            //commented by meena 17_5_18
            //Validate Home Tel
            //if (SpaceTrim(document.getElementById(strContent + "txthometel").value) == "") {
            //    alert("Landline No.(with STD) is mandatory");
            //    document.getElementById(strContent + "txthometel").focus();
            //    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            //else
            if (SpaceTrim(document.getElementById(strContent + "txthometel").value) != "") {
                var HomeTel = SpaceTrim(document.getElementById('<%= txthometel.ClientID %>').value);
                if (HomeTel.length != 10) {
                    alert("Landline No.(with STD) should be 10 digit.");
                    document.getElementById(strContent + "txthometel").focus();
                    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 start
                if ((HomeTel.substr(0, 1)) == "0") {
                    alert("Landline No.(with STD) should not start with 0");
                    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 end
            }



            if (SpaceTrim(document.getElementById(strContent + "txtMobileTel").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileTel").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {
                var Mobile = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }
            if (Mobile1.substr(0, 1) == "1" || Mobile1.substr(0, 1) == "0" || Mobile1.substr(0, 1) == "2" || Mobile1.substr(0, 1) == "3"
                         || Mobile1.substr(0, 1) == "4" || Mobile1.substr(0, 1) == "5") {
                alert("Mobile No.1 Should Start With (6,7,8,9)");
                document.getElementById(strContent + "txtMobileTel").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }

            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 start

            if (document.getElementById(strContent + "txtMobile2").value != "") {
                if (!((document.getElementById("<%=txtMobile2.ClientID%>").value).length == "10")) {
                    alert("Mobile No.2 should be 10 digit");
                    document.getElementById(strContent + "txtMobile2").focus();
                    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }
            if (Mobile2.substr(0, 1) == "1" || Mobile2.substr(0, 1) == "0" || Mobile2.substr(0, 1) == "2" || Mobile2.substr(0, 1) == "3"
                         || Mobile2.substr(0, 1) == "4" || Mobile2.substr(0, 1) == "5") {
                alert("Mobile No.2 Should Start With (6,7,8,9)");
                document.getElementById(strContent + "txtMobile2").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;

            }

            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 end



            ///For Email   txtemail
            //added by pranjali on 06-03-2014 for email validation start
            if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
                alert("Email is mandatory.");
                document.getElementById(strContent + "txtemail").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {

                var emailid = (document.getElementById(strContent + "txtemail").value);
                if (validateEmail1(emailid) == 0) {

                    return false;
                }
            }

            if (SpaceTrim(document.getElementById(strContent + "txtEmail2").value) != "") {
                var emailid = (document.getElementById(strContent + "txtEmail2").value);
                if (validateEmail2(emailid) == 0) {
                    return false;
                }
            }
            //added by pranjali on 06-03-2014 for email validation end

            //added by pranjali on 20-03-2014 end
            //Commented by Pranjali on 06-12-2013 for making MaritalStatus field non-mandatory start

            //            if (document.getElementById(strContent + "cboMaritalStatus_ddliSysLookupParam") != null) {
            //                if (document.getElementById(strContent + "cboMaritalStatus_ddliSysLookupParam").selectedIndex == 0) {
            //                    //alert(document.getElementById(strContent + "hdnID300").value);
            //                    alert("Please Select Marital Status");
            //                    document.getElementById(strContent + "cboMaritalStatus_ddliSysLookupParam").focus();
            //                    return false;
            //                }
            //            }
            //Commented by Pranjali on 06-12-2013 for making MaritalStatus field non-mandatory end

            //Added by pranjali on 09-12-2013 for SM Code validation end

            //Added by pranjali on 11-03-2014 for Recruiter Code validation start
            //if (SpaceTrim(document.getElementById(strContent + "txtpfSMCode").value) == "") {
            //    alert("Please enter Recruiter Code");
            //    document.getElementById(strContent + "txtpfSMCode").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}
            //Added by pranjali on 11-03-2014 for Recruiter Code validation end

            //Added by pranjali on 09-12-2013 for Channel validation start
            if (document.getElementById("<%=ddlSlsChannel.ClientID%>").value == "Select" || document.getElementById("<%=ddlSlsChannel.ClientID%>").value == "") {
                alert("Please select candidate channel");
                document.getElementById(strContent + "ddlSlsChannel").focus();
                //  //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //Added by pranjali on 09-12-2013 for Channel validation end

            //Added by pranjali on 09-12-2013 for Sub Class validation start
            <%--if (document.getElementById("<%=ddlChnCls.ClientID%>").value == "Select" || document.getElementById("<%=ddlChnCls.ClientID%>").value == "") {
                alert("Sub Class is Mandatory.");
                document.getElementById(strContent + "ddlChnCls").focus();

                return false;
            }--%>
            //Added by pranjali on 09-12-2013 for Sub Class validation end

            //Added by pranjali on 09-12-2013 for Agent Type validation start
            if (document.getElementById("<%=ddlAgnTypes.ClientID%>").value == "Select") {
                alert("Recruiter Type is Mandatory.");
                document.getElementById("<%=ddlAgnTypes.ClientID%>").focus();
                // //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //Added by pranjali on 09-12-2013 for Agent Type validation end

            //Added by pranjali on 09-12-2013 for Branch Code validation start
            if (document.getElementById(strContent + "txtBranchCode").value == "") {
                alert("Branch Name is Mandatory.");
                document.getElementById(strContent + "txtBranchCode").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //Added by pranjali on 09-12-2013 for Branch Code validation end

            //Added by pranjali on 09-12-2013 for SM Name validation start
            if (document.getElementById(strContent + "txtSMName").value == "") {
                alert("Recruiter Name is Mandatory.");
                document.getElementById(strContent + "txtSMName").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            //Added by pranjali on 09-12-2013 for SM Name validation end




            //Added by amruta on 04-01-2015 for Unit code validation of candidate end



            //Added by pranjali on 25-11-2013 for Applying validation on title and gender selection start
            //            
            //            var ddlcboGender = document.getElementById("<%=cboGender.ClientID%>");
            //            var sGenderValue = ddlcboGender.options[ddlcboGender.selectedIndex].value;
            //            var title = document.getElementById("<%=cboTitle.ClientID%>").value;
            //            var sTitle = document.getElementById("<%=hdnGenderTitle1.ClientID%>").value.split(",");
            //            var sGender = document.getElementById("<%=hdnGenderTitle2.ClientID%>").value.split(",");

            //            for (var i = 0; i < sTitle.length; i++) {
            //                if ((sTitle[i] == title) && (sGender[i] == sGenderValue)) {
            //                    return 0;
            //                }
            //            }
            //            alert("Invalid Title");
            //            document.getElementById(strContent + "cboTitle").focus();
            //            return false;

            debugger;
            //added by usha on 17.02.2018
            if ($("#<%= txtDOB.ClientID  %>").val() != "") {
                var val = SpaceTrim($("#<%= txtDOB.ClientID  %>").val());
                var matches = /^(\d{2})[/](\d{2})[/](\d{4})$/.exec(val);

                if (matches == null) {
                    alert('Enter date in dd/mm/yyyy format');
                    return false;
                }

                var date = val.split('/');
                if (date.length == 3) {
                    if (date[2] < "1900") {
                        alert('Date year cannnot be less than Year 1900');
                        return false;
                        // $("#<%= txtDOB.ClientID  %>").focus();
                    }
                } else {
                    alert('select a valid date');
                    return false;
                    // $("#<%= txtDOB.ClientID  %>").focus();
                }
            }
            //added by usha on 17.02.2018
            //Added by pranjali on 25-11-2013 for Applying validation on title and gender selection start
            //Validation for Gender

            <%--if (document.getElementById(strContent + "cboGender") != null) {
                if (document.getElementById(strContent + "cboGender").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID290").value);
                    document.getElementById(strContent + "cboGender").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
                var ddlcboGender = document.getElementById("<%=cboGender.ClientID%>");
                var sGenderValue = ddlcboGender.options[ddlcboGender.selectedIndex].value;
                var title = document.getElementById("<%=cboTitle.ClientID%>").value;
                var sTitle = document.getElementById("<%=hdnGenderTitle1.ClientID%>").value.split(",");
                var sGender = document.getElementById("<%=hdnGenderTitle2.ClientID%>").value.split(",");

                for (var i = 0; i < sTitle.length; i++) {
                    if ((sTitle[i] == title) && (sGender[i] == sGenderValue)) {
                        return 0;
                    }
                }
                alert("Invalid Title");
                document.getElementById(strContent + "cboTitle").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }--%>

            //Added by pranjali on 25-11-2013 for Applying validation on title and gender selection end




            //Added by Pranjali on 10-12-2013 for DOB validation start

            var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

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

                alert("Minimum Entry Age should be 18 years.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            else {
                return true;
            }
            //Added by Pranjali on 10-12-2013 for DOB validation end

          

            //Validation for DOB 

            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) == "") {
                alert(document.getElementById(strContent + "hdnID450").value);
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

          
            //Validation for DOB 

            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) != "") {
                if (DateValidation(document.getElementById("<%= txtDOB.ClientID %>").value, "ctl00_ContentPlaceHolder1_txtDOB") == 1)
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
            }
            document.getElementById(strContent + "hdnFlag").value = "1";
        }

        //added by pranjali on 06-03-2014 start
        function validateEmail1(sEmail1) {

            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail1.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtemail").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return 0;
            }

            return 1;

        }

        function validateEmail2(sEmail2) {

            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail2.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail2").focus();
                //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return 0;


            }

            return 1;

        }
        //added by pranjali on 06-03-2014 end
        //commented by pranjali on 05-12-2013 for Application start
        //Validation for Application No. 
        //            if (SpaceTrim(document.getElementById(strContent + "txtpfAppNo").value) == "") {
        //                alert(document.getElementById(strContent + "hdnID260").value);
        //                document.getElementById(strContent + "txtpfAppNo").focus();
        //                return false;
        //            }
        //commented by pranjali on 05-12-2013 for Application end

        function IsCheckAppNo(sText) {

            var IsNumber = true;

            if (sText.substring(0, 1) == "1" || sText.substring(0, 1) == "9") {
                IsNumber = true;
            }

            else {
                IsNumber = false;
            }

            return IsNumber;
        }

        //commented by pranjali on 05-12-2013 for Application start
        //            for Application no. start validation
        //            if (!IsCheckAppNo(document.getElementById("<%=txtpfAppNo.ClientID%>").value)) {
        //                
        //                            alert("Application No. should start with 1 or 9");
        //                            document.getElementById(strContent + "txtpfAppNo").focus();
        //                            return false;
        //                        }
        //commented by pranjali on 05-12-2013 for Application end   


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
        function isAlphabetSpace(val) {
            if (val.match(/^[ a-zA-Z]+$/)) {
                return true;
            }
            else {
                return false;
            }
        }
        function DateValidation(args1, argsID) {
            var Splitargs1 = args1.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var RegDate = new Date(args1); //BeginYear,BeginMonth-1,1);
            var BeginDate1 = args1;
            var TodayDate = new Date();

            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID).focus();
                    return 1;
                }
            }
            return 0;
        }

        function dtYear() {

            var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
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

                alert("Minimum Entry Age should be 18 years.");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
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


    </script>
    <style type="text/css">
        .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus {
            color: #555555;
            background-color: #dff0d8;
        }

        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
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
    <asp:ScriptManager ID="SM1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <center>
 
 <div class="container img-rounded mainpage-header">
            <div class="row" >
                <div class="col-sm-12">
                    <div style="width: 100%; border-collapse: collapse;" >
                        <div  class="row"  id="tr_message" runat="server" align="center" style="visibility: hidden">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMessage" runat="server" CssClass="control-label" ></asp:Label> <%--ForeColor="#C04000"--%>
                            </div>
                        </div>
                  </div> 
   
                  </div>
              </div>
         </div>
            <div class="panel"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                <div id="Div2" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblpfPersonal" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                <div id="divSearch" runat="server" style="display:block;" class="panel-body">
                <asp:UpdatePanel ID="updPersonal" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblpfAppNo" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtpfAppNo" runat="server"  TabIndex="1" CssClass="form-control" MaxLength="8"
                                 ReadOnly="True"></asp:TextBox>
                        </div>
                        <%--<td class="formcontent"></td> --%>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblpfRegDate" runat="server" CssClass="control-label"></asp:Label>
                            <span style="color: red">*</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtpfRegDate" runat="server" CssClass="form-control" TabIndex="2"
                                Enabled="False" MaxLength="20" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                      <div class="row">
                           <div class="col-sm-3" style="text-align:left">

                                    <asp:Label ID="lblpan" runat="server"  CssClass="control-label"></asp:Label>
                                                                    <span style="color: red">*</span>
                        </div>
                             <div class="col-sm-3">
                           
                                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                     <ContentTemplate>
                                         <div class="input-group">
                                             <asp:TextBox ID="txtpan"  runat="server" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                                 TabIndex="3"></asp:TextBox>&nbsp;
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" 
                                                 InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtpan"
                                                 FilterType="Custom">
                                             </ajaxToolkit:FilteredTextBoxExtender>
                                           <span class="input-group-btn input-addon_extended">
                                                 <asp:LinkButton ID="btnVerifyPAN" runat="server" Text="Verify" style="margin-bottom: 14px;" CssClass="btn btn-verify"
                                                     OnClick="btnVerifyPAN_Click" OnClientClick="funpan();" TabIndex="4">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                               </span>
                                           </div> 
                                       
                                         <div id="divPAN" class="Content" style="display: none">
                                             <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                             <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                         </div>
                                         <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" CssClass="control-label"
                                             Font-Size="X-Small"></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                               
                                 <i class="fa fa-hand-o-right"></i>
            <a href="https://incometaxindiaefiling.gov.in/e-Filing/Services/KnowYourJurisdiction.html;jsessionid=Fl7hSy1QFps1MQr5XqXhX51h7rJp7Jyd1HLJnMxthzG1HLRhgPFl!905747125" target="_blank" style="font-size:13px"; tabindex="5">Income Tax PAN Verification Link</a> <%--14-01-2014--%>
        
                             </div>
                                <div class="col-sm-3" style="text-align:left">

                                    <asp:Label ID="lblaadhr" runat="server" Text ="Aadhaar No"  Visible="false" CssClass="control-label"></asp:Label>
                                    <%-- <span style="color: red">*</span>--%>

                                                                   
                        </div>
                             <div class="col-sm-3">
                           
                                 <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                     <ContentTemplate>
                                         <div  class="input-group">
                                             <asp:TextBox ID="txtaadhr"  Enabled ="False" Visible="false" runat="server" CssClass="form-control" MaxLength="12" 
                                                 TabIndex="6"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender82" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                  FilterMode="InvalidChars" TargetControlID="txtaadhr" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>&nbsp;
                                            
                                           <span class="input-group-btn input-addon_extended">
                                                 <asp:LinkButton ID="lnkaadhar" runat="server" Visible="false" Text="Verify" style="margin-bottom: 14px;" Enabled ="False" CssClass="btn btn-verify"
                                                     OnClick="btnVerifyaadhar_Click"  TabIndex="7">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                               </span>
                                           </div> 
                                       
                                         <div id="div6" class="Content" style="display: none">
                                             <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                             <asp:Label ID="Label4" runat="server"></asp:Label>
                                         </div>
                                         <asp:Label ID="lblAadharMsg" runat="server" Font-Bold="False" CssClass="control-label"
                                             Font-Size="X-Small"></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                               
                                
                             </div>          
                           <div class="col-sm-3" style="text-align:left">
                               
                                    <asp:Label ID="lblProfession" runat="server"   CssClass="control-label"></asp:Label>
                                     <span style="color: #ff0000">*</span>
                        </div>
                           <div class="col-sm-3" >
                                <asp:DropDownList ID="ddlPrimProf" runat="server" CssClass="form-control" TabIndex="8">
                                    <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                </asp:DropDownList>
                      </div>

         
                         

                   </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblpfGivenName" runat="server" CssClass="control-label"></asp:Label>
                            <span style="color: #ff0000;">*</span>
                        </div>
                        <div class="col-sm-3">

                            <div  class="input-group">
                             <span class="input-group-addon input-addon_extended">
                                    <asp:DropDownList ID="cboTitle" runat="server" CssClass="form-control" DataTextField="ParamDesc"
                                        DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                       Width="75px"  TabIndex="9">
                                    </asp:DropDownList>
                             </span>
                                <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                              
                                <asp:TextBox ID="txtpfGivenName" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                  MaxLength="30" TabIndex="10" onblur="CheckSpaces();"></asp:TextBox>
                               
                            </div>
                            <asp:HiddenField ID="hdnGenderTitle1" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdnGenderTitle2" runat="server"></asp:HiddenField>
                        </div>
                    <div class="col-sm-3" style="text-align: left">
                        <span>
                            <asp:Label ID="lblpfSurname" runat="server" CssClass="control-label"></asp:Label></span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtpfSurname" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                            CssClass="form-control" MaxLength="30" TabIndex="11"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars="" TargetControlID="txtpfSurname">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                 <%--   amruta end--%>
                        
                <div class="row">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfFatherName" runat="server" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                             MaxLength="60" TabIndex="12" onblur="AllowSpace();return false;"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                            InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " TargetControlID="txtFatherName"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCategory" runat="server" CssClass="control-label"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" TabIndex="13"
                            >
                        </asp:DropDownList>
                    </div>
                </div>
                </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfDOB" runat="server" CssClass="control-label"></asp:Label>
                        <span><font color="red">*</font> </span>
                    </div>
                    <div class="col-sm-3">
                        <%--
                    <input type="text"  id="datepicker1" class="hasDatepicker"/>--%>
                    
                        <asp:TextBox CssClass="form-control" onmousedown="$('#txtDob').datepicker({ changeMonth: true, changeYear: true, minDate : new Date(1900, 0 , 1) });"
                           runat="server" ID="txtDOB" MaxLength="15"
                            TabIndex="14" />   <%--onchange="setDateFormat('txtDob')" --%>
                         
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfGender" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="cboGender" CssClass="form-control" runat="server" 
                            TabIndex="15">
                        </asp:DropDownList>
                    </div>
                </div>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="row">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfNationality" CssClass="control-label" runat="server"></asp:Label><span
                            style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                         <div  class="input-group">
                             <span class="input-group-addon input-addon_extended">
                             <asp:TextBox ID="txtNationalCode" runat="server" Style="margin-bottom:20px;text-align:center" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                            Enabled="False"   MaxLength="3" TabIndex="16"></asp:TextBox>
                                 </span>
                            <asp:TextBox ID="txtNationalDesc" runat="server" CssClass="form-control" Enabled="False"
                                onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="17"></asp:TextBox>
                           <span class="input-group-btn input-addon_extended">
                                <asp:LinkButton ID="btnNational" runat="server" CausesValidation="False" CssClass="btn btn-verify"
                                    Enabled="false" TabIndex="18" Text="..." style="width:100%;margin-bottom: 20px;">
                                
                                   
                      <%--  <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> ...--%>
                                </asp:LinkButton>
                     </span>
                    </div>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblpfmaritalstatus" CssClass="control-label" 
                            runat="server"></asp:Label><span style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="cboMaritalStatus" runat="server" CssClass="form-control" 
                            TabIndex="19">
                        </asp:DropDownList>
                    </div>
                </div>
                 </ContentTemplate>
                </asp:UpdatePanel>
                   </div>
       </div>
            
             <%--contact details--%>
          <div class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
          <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">           
                   <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                        
                     <asp:Label ID="Label6" runat="server" text="Contact Information" CssClass="control-label" Font-Size="19px"></asp:Label>
                         
                    </div>
                     <div class="col-sm-2">
                        <span id="btnContactInformation" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
               </div>
          <div id="divContactInformation" style="display:block;" runat="server" class="panel-body">
         
           <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblpfconpreferred" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <contenttemplate>
                                                            
                                                      
                           <asp:DropDownList id="ddlDstbnMethod" runat="server"  CssClass="form-control" AutoPostBack="true" 
                                                               TabIndex="20" ></asp:DropDownList>
                                                                 </contenttemplate> 
                                                 </asp:UpdatePanel> 
                        </div>
                        </div>       
                                          
                                        <div class="row">
                                          <div class="col-sm-3" style="text-align:left">
                                             <%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblpfhometel" runat="server" CssClass="control-label" ></asp:Label>
                                                <%--<span style="color: red">*</span>--%>
                                               <%-- <span style="color: #ff0000">*</span>--%>
                                       </div>
                                          <div class="col-sm-3" >
                                              <div class="input-group">
                                              <span class="input-group-addon input-addon_extended">
                           <asp:TextBox ID="txtLandlinecode" Enabled="false"  runat="server" Text="91" CssClass="form-control" style="text-align:center" TabIndex ="43"></asp:TextBox>
                              </span>
                                                <asp:TextBox  ID="txthometel" runat="server"
                                                  placeholder="Should not start with 0 and should be 10 digit."    CssClass="form-control" MaxLength="10" 
                                                    TabIndex = "21" ></asp:TextBox>
                                                  </div>


                                               <%-- <asp:TextBox  ID="txthometel" runat="server"
                                                  placeholder="Should not start with 0 and should be 10 digit."    CssClass="form-control" MaxLength="10" 
                                                    TabIndex = "21" ></asp:TextBox>--%>
                                                    <asp:Label ID="LblhomeNote" runat="server" visible="false" Text="(Tel No:Should not start with 0 and should be 10 digit.)" CssClass="control-label" ForeColor="Red"></asp:Label>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                      FilterMode="InvalidChars" TargetControlID="txthometel" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                       </div>
                                          <div class="col-sm-3" style="text-align:left">
                                                <span><asp:Label ID="lblpfofftel" runat="server" CssClass="control-label"></asp:Label></span>
                                     </div>
                                          <div class="col-sm-3">
                                                <asp:TextBox ID="txtWorkTel" runat="server" CssClass="form-control"
                                                    MaxLength="11" TabIndex="22" ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                      FilterMode="InvalidChars" TargetControlID="txtWorkTel" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                      </div>
                                         </div>
              <div class="row">
                  <div class="col-sm-3" style="text-align: left">
                      <%--Added by shreela on 6/03/14 to remove space--%>
                      <asp:Label ID="lblpfmobtel" runat="server" CssClass="control-label"></asp:Label>
                      <span style="color: red">*</span>
                      <%-- <span style="color: #ff0000">*</span>--%>
                  </div>
                  <div class="col-sm-3">
                      <div class="input-group">
                          <span class="input-group-addon input-addon_extended">
                           <asp:TextBox ID="txtmobcode" Enabled="false"  runat="server" Text="91" CssClass="form-control" style="text-align:center" TabIndex ="23"></asp:TextBox>
                              </span>
                          <asp:TextBox ID="txtMobileTel" runat="server" CssClass="form-control" 
                           placeholder="Mobile No should be 10 digit."   MaxLength="10" TabIndex="24"></asp:TextBox>
                         
                          <%--<asp:Label ID="lblMobNote" runat="server" Text="(Mob No:Starts with 0 and should be 11 digit.)" Font-Size="Smaller" ForeColor="Red"></asp:Label>--%>
                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                              InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                              FilterMode="InvalidChars" TargetControlID="txtMobileTel" FilterType="Custom">
                          </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                       <asp:Label ID="lblMobNote" runat="server" Text="(Mobile No should be 10 digit.)"
                            visible="false"  Font-Size="Smaller" CssClass="control-label" ForeColor="Red"></asp:Label>
                     
                  </div>
                  <div class="col-sm-3" style="text-align: left">
                      <asp:Label ID="lblMobile2" runat="server" CssClass="control-label"></asp:Label>
                  </div>
                  <div class="col-sm-3">
                      <div class="input-group">
                          <span class="input-group-addon input-addon_extended">
                           <asp:TextBox ID="txtmobcode2"  runat="server" Text="91" style="text-align:center" CssClass="form-control" TabIndex="25" Enabled="false"></asp:TextBox>
                              </span> 
                          <asp:TextBox ID="txtMobile2" runat="server" CssClass="form-control" 
                              MaxLength="10" TabIndex="26"></asp:TextBox>
                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                              InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                              FilterMode="InvalidChars" TargetControlID="txtMobile2" FilterType="Custom">
                          </ajaxToolkit:FilteredTextBoxExtender>
                      </div>
                     
                  </div>
              </div>
                                       <div class="row">
                                           <div class="col-sm-3" style="text-align:left">
                                           <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblpfemail" runat="server" CssClass="control-label"></asp:Label>
                                                      <span style="color: red">*</span>
                                         </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" MaxLength="50" TabIndex="27" ></asp:TextBox>&nbsp;
                                          </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <span>
                                                    <asp:Label ID="lblEmail2" runat="server" CssClass="control-label"></asp:Label>
                                                </span>
                                      </div>
                                           <div class="col-sm-3">
                                                <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control"
                                                    MaxLength="50" TabIndex="28" ></asp:TextBox>&nbsp;
                                            </div>
                                  </div>
                                   
                                    </div>
             </div>
             <%--Contact details end--%>
        <%--Added by Pranjali on 06-12-2013 start--%>
  <div class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 1.5%">
         <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divrecruit','btncallmap');return false;">
             <div class="row">
                 <div class="col-sm-10" style="text-align: left">
                     
                     <asp:Label ID="lblpfrecinfotitle" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>
                 </div>
                 <div class="col-sm-2">
                     <span id="btncallmap" class="glyphicon glyphicon-chevron-down" style="float: right;
                         color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                 </div>
             </div>
         </div>
         <div id="divrecruit" style="display:block;" runat="server" class="panel-body">
             <div class="row">
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="Label5" Text="Employee Code" runat="server" CssClass="control-label"></asp:Label><span
                         style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                         <ContentTemplate>
                             <div class="input-group">
                                 <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" TabIndex="29" 
                                     onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>&nbsp;
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                     InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtEmpCode"
                                     FilterType="Custom">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                                <span class="input-group-addon input-addon_extended">
                                     <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-verify" style="margin-bottom:15px;margin-left:2px;" OnClientClick="funrecruitercode();"
                                         OnClick="btnVerifyEmpCode_Click" ValidationGroup="RecruitInfo" TabIndex="30">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify   
                                     </asp:LinkButton>
                                 </span>
                             </div>
                             <div id="Div1" class="Content" style="display: none">
                                 <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                            
                             <asp:Label ID="lblEmpMsg" runat="server" CssClass="control-label" Font-Bold="False"
                                 Font-Size="X-Small"></asp:Label>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
             </div>
             <div id="trempcode" runat="server" class="row">
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="lblpfSlsChannel" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label><span
                         style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="form-control" Enabled="false"
                                 OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" AutoPostBack="true"
                                 TabIndex="31">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="lblpfChnCls" CssClass="control-label" runat="server"></asp:Label><span
                         style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control" Enabled="true" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged"
                                 AutoPostBack="true" TabIndex="32">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
             </div>
             <div class="row">
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="lblpfSMName" CssClass="control-label" runat="server"></asp:Label><span
                         style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                         <ContentTemplate>
                             <asp:TextBox ID="txtSMName" runat="server" CssClass="form-control" ReadOnly="true"
                                 TabIndex="33"></asp:TextBox>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
                 <div class="col-sm-3" style="text-align: left">
                     <span style="color: #ff0000">
                         <asp:Label ID="lblpfagetype" runat="server" CssClass="control-label" Font-Bold="False"
                             Style="color: black;"></asp:Label>&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlAgntType" runat="server" Visible="false" CssClass="form-control"
                                 AutoPostBack="false" TabIndex="34">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlAgnTypes" runat="server" DataTextField="MemTypeDesc01" DataValueField="MemType"
                                 Enabled="false" CssClass="form-control" DataSourceID="DSAgnTypes" TabIndex="35">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     <asp:SqlDataSource ID="DSAgnTypes" runat="server" ConnectionString="<%$ ConnectionStrings:INSCCommonConnectionString %>">
                     </asp:SqlDataSource>
                 </div>
             </div>
             <div class="row">
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="lblpfimmleader" CssClass="control-label" runat="server"></asp:Label><span
                         style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                   
                    <%--  <asp:UpdatePanel runat="server" ID="updPnl_txtRptCode" UpdateMode="Conditional">
                                <ContentTemplate>
                                 <div  class="input-group" style="margin-left: 0%;">
                                              <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" TabIndex="36" disabled="true" style="width:242px;"                                            ></asp:TextBox>
                                            <span class="input-group-btn input-addon_extended">
                                                  <asp:Button ID="btnRptMgr" runat="server" CssClass="btn btn-verify" OnClick="btnmemgrid_Click" Text="...." style="margin-left: 0px;margin-right: 5px;"
                                            TabIndex="37" />
                                               </span>
                                           </div> 
                                       <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                        <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                        <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static" 
                                            TabIndex="38"
                                        Style="display: none;" />
                                  
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                         <ContentTemplate>
                             <div class="input-group">
                                 <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" style="width: 228px;" TabIndex="36"  disabled="true"
                                     onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>&nbsp;

                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                     InvalidChars="&`''#%!@$^*-_+={}[]|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtBranchCode"
                                     FilterType="Custom">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                                <span class="input-group-addon input-addon_extended">
                                     <asp:LinkButton ID="btnRptMgr" runat="server" CssClass="btn btn-verify" style="margin-bottom:15px;margin-left:2px;" OnClientClick="funrecruitercode();"
                                         OnClick="btnmemgrid_Click"  TabIndex="37">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> ...   
                                     </asp:LinkButton>
                                 </span>
                             </div>
                            
                         </ContentTemplate>
                     </asp:UpdatePanel>
                      <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                        <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                        <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static" 
                                            
                                        Style="display: none;" />
 
                 </div>
                 <div class="col-sm-3" style="text-align: left">
                     <asp:Label ID="lblCndAgtType" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                     <span style="color: #ff0000">&nbsp*</span>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="updpnlCndAgtType" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlCndAgtType" runat="server" CssClass="form-control" Enabled="false"
                                 TabIndex="39" >
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     &nbsp;
                     <asp:HiddenField ID="hdnBizsrc1" runat="server" />
                     <asp:HiddenField ID="hdnChnCls" runat="server" />
                 </div>
             </div>
             <div class="row">

                   <div class="col-sm-3" style="text-align: left">
                    <%-- <span style="color: #ff0000">--%>
                         <asp:Label ID="LblRptMgrCode" runat="server" Text="Additional Reporting Manager" CssClass="control-label" Font-Bold="False"></asp:Label>
                           <%--  Style="color: black;"></asp:Label> &nbsp*</span>--%>
                 </div>
                 <div class="col-sm-3">
                     <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlAddRptMgrCode" runat="server"  CssClass="form-control"
                                 AutoPostBack="false" TabIndex="34">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     
                 </div>
                 </div>
         </div>
     </div>
        <div>
              <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
                            <%--<asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                OnClick="btnUpdate_Click" TabIndex="32"  OnClientClick="StartProgressBar();" >
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> 
                        </asp:LinkButton>  --%>  
                  
                                <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-sample"  OnClientClick="funpan();" 
                                    CausesValidation="false"  OnClick="btnUpdate_Click" TabIndex="40">
                               <%--       <span   class="glyphicon glyphicon-floppy-disk BtnGlyphicon" ></span> --%>
                                </asp:LinkButton>
                     <asp:HiddenField ID="hdnFlag" runat="server" />
                            <asp:LinkButton ID="btnCancel" style="background-color:#FFF;color:#f04e5e;" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                OnClick="btnCancel_Click" TabIndex="41">
                             <span  style="color:#f04e5e" class="glyphicon glyphicon-remove BtnGlyphicon"> </span> 
                             </asp:LinkButton> 
                             <%--  <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div> --%>
                     </div>
                     </div>
         </div>
         <br />
              <div class="panel"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                 <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divnotes','btnnotes');return false;">
                   <div class="row">  
                     <div class="col-sm-10" style="text-align:left">    
                            <asp:Label ID="lblSpeclNotes" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                     </div>
                      <div class="col-sm-2">
                        <span id="btnnotes" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>

                          
                    </div>
                    </div>
                    </div>
                 <div id="divnotes" style="display:block;" runat="server" class="panel-body">
                     <div class="row">
                      <div class="col-md-6"  style="text-align:left" >
                            <asp:Label ID="Label1" Text=" Name as per PAN Card." Font-Size="Small" runat="server" CssClass="control-label"
                                ForeColor="Red"></asp:Label><br /><%--shreela 29/05/2014--%>
                                </div>
                                 <div class="col-md-6">
                            <asp:Label ID="Label2" Text=" Letter from Panchayat if population is less than 5000 for rural case."
                             CssClass="control-label"   Font-Size="Small" runat="server" ForeColor="Red" Visible="False"></asp:Label><%--shreela 29/05/2014--%>
                       </div>
                       </div>
                </div>
              
               
        </div>
        <input id="hdnID280" type="hidden" runat="server" />
        <input id="hdnID290" type="hidden" runat="server" />
        <input id="hdnID300" type="hidden" runat="server" />
        <input id="hdnID320" type="hidden" runat="server" />
        <input id="hdnID440" type="hidden" runat="server" />
        <input id="hdnID450" type="hidden" runat="server" />
        <input id="hdnID470" type="hidden" runat="server" />
        <input id="hdnIsDateValid" type="hidden" runat="server" />
        <input id="hdnDOB" type="hidden" runat="server" />
        <input id="hdnSave" type="hidden" runat="server" />
        <input id="hdnBizSrc" type="hidden" runat="server" />
        <%--Added by Pranjali on 20-12-2013--%>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updPnlHidden" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnCndCode" runat="server" />
                            <asp:HiddenField ID="hdnPan" runat="server" />
                            <asp:HiddenField ID="hdnPanValue" runat="server" />
                            <asp:HiddenField ID="hdnBranchCode" runat="server" />
                            <asp:HiddenField ID="hdnUrn" runat="server" />
                            <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
                            <asp:HiddenField ID="hdnRecrtCode" runat="server" />
                            <asp:HiddenField ID="hdnEmpCode" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <%--Added by Pranjali on 20-12-2013--%>
    </center>

    <%-- <button type="button" class="btn btn-info btn-lg" id="myBtn" runat="server" visible="false" onclick="myBtn_Click" ></button>--%>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px;border-radius: 15px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span> OK

                    </button>

                </div>
            </div>

        </div>
    </div>

    <asp:Panel runat="server" ID="pnlMdl"  Width ="500" Height="428" display = "none" top="52">
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="530px" frameborder="0" style="margin-top: -60px;"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--For Displaying Information Pop-up End--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />

</asp:Content>


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
    
    <script src="../../../assets/scripts/jquery-1.10.2.min.js"></script>
    <script src="../../../assets/scripts/jquery.min.js"></script>
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
    
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=11" />
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
<%--     <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
      <%--<script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
  <%--  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
<%--        $(function () {
            debugger;
            $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            // $("#<%= txtDOB.ClientID  %>").datepicker({ maxDate: new Date(), dateFormat: 'dd/mm/yy' });
        });
        $(function () {
            debugger;
            $("#<%= TxtAnnivrsryDt.ClientID  %>").datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                 changeYear: true
             }); //txtReqDate

         });--%>
        function textDOB () {
           var start = new Date();
            start.setFullYear(start.getFullYear() - 70);
            var end = new Date();
            end.setFullYear(end.getFullYear() - 18);
            $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                minDate: start,
                maxDate: end,
                yearRange: start.getFullYear() + ':' + end.getFullYear()
            });
            DobVali();
        }
        function AnnvDte () {
            debugger;
            $("#<%= TxtAnnivrsryDt.ClientID  %>").datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                changeYear: true,
                 maxDate:'0'
             }); //txtReqDate

         }
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
                    document.getElementById('ctl00_ContentPlaceHolder1_btnrow').style.display = "none";
                    document.getElementById('ctl00_ContentPlaceHolder1_btnnote').style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_btnrow').style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_btnnote').style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

		function Hidepopup() {
			debugger;
			//$("#myModal").modal();
			$("#myModal").hide();
		}

		function popup(HTML) {
			debugger;
			//$("#myModal").modal();
			$("#myModal").show();
			//document.getElementById("ctl00_ContentPlaceHolder1_divmdlbdy").innerHTML = HTML;
			document.getElementById("divmdlbdy").innerHTML = HTML;
		}

        function LdWait(delay) {
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }

        function RemoveLoading12() {

            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';

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
            //document.getElementById(strContent + "ddlPrimProf").focus();
            //if (SpaceTrim(document.getElementById(strContent + "txtEmpCode").value) == "") {
            //    alert("Please enter Employee Code");
            //    document.getElementById(strContent + "txtEmpCode").focus();
            //    return false;
            //}
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
        //    document.getElementById('divPAN').style.display = 'block'
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
                    return count;
                }
            }
            return false;
        }

        function funValidate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            var Mobile1 = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
            var Mobile2 = SpaceTrim(document.getElementById('<%= txtMobile2.ClientID %>').value);
 

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
             

            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "Select") {
                alert("Occupation is Mandatory");
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
                    alert("Please Select Prefix");
                    document.getElementById(strContent + "cboTitle").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            //Added Validation for Given Name by pranjali start
            if (SpaceTrim(document.getElementById(strContent + "txtpfGivenName").value) == "") {
                alert("Please Enter Given Name");
                document.getElementById(strContent + "txtpfGivenName").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            var lenGivenName = document.getElementById('<%= txtpfGivenName.ClientID %>').value;
            if (lenGivenName.length < 3) {
                alert("Given Name should be atleast of three Characters");
                document.getElementById('<%= txtpfGivenName.ClientID %>').focus();
                return false;
            }

            CheckSpaces();
            var strContent = "ctl00_ContentPlaceHolder1_";
 
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

            <%--if (document.getElementById('<%=ddlCategory.ClientID %>').value == "Select") {
                alert("Classification is Mandatory.");
                document.getElementById('<%= ddlCategory.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }--%>

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

                return false;
            }
            //added by pranjali on 11-03-2014 for gender validation end
            //Validation for Nationality
            if ((SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) == "") || (document.getElementById(strContent + "txtNationalCode").value) != "IND") {
                alert(document.getElementById(strContent + "hdnID320").value);
                document.getElementById(strContent + "txtNationalCode").focus();

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
           <%-- if (document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "Select" || document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "") {
                alert("Please Select Marital Status");
                document.getElementById(strContent + "cboMaritalStatus").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }--%>

            ////added by pranjali on 20-03-2014 start
            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            ////added by meena on 27/11/17 start
            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MISS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value != "S")) {

            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}
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
                alert("Mobile No.1 should be 10 digit.");
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

            if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
                alert("Email Id 1 is mandatory.");
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

            if (document.getElementById("<%=ddlSlsChannel.ClientID%>").value == "Select" || document.getElementById("<%=ddlSlsChannel.ClientID%>").value == "") {
                alert("Please select candidate channel");
                document.getElementById(strContent + "ddlSlsChannel").focus();
                //  //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            if (document.getElementById("<%=ddlAgnTypes.ClientID%>").value == "Select") {
                alert("Recruiter Type is Mandatory.");
                document.getElementById("<%=ddlAgnTypes.ClientID%>").focus();
                // //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }

            if (document.getElementById(strContent + "txtBranchCode").value == "") {
                alert("Branch Name is Mandatory.");
                document.getElementById(strContent + "txtBranchCode").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }
            if (document.getElementById(strContent + "txtSMName").value == "") {
                alert("Recruiter Name is Mandatory.");
                document.getElementById(strContent + "txtSMName").focus();
                return false;
            }
            debugger;
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
           /* document.getElementById(strContent + "hdnFlag").value = "1";*/
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

        function funAddmaster2(url) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd1").src = url + "&mdlpopup=mdlViewBID";
        }

        function CallParent(Status) {
            document.getElementById("ctl00_ContentPlaceHolder1_ShowResult").innerText = Status;
            $find("mdlVwBID").hide();
        }

        function disablebtn(){
            var a = document.getElementById("")
        }
//======================= Fun added by Sarthak start=============================
        function validatepanel1() {
            debugger;
            //====================validation for given name (First row)
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "Select") {
                alert("Occupation is Mandatory");
                document.getElementById('<%= ddlPrimProf.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
			}

            if (document.getElementById(strContent + "cboTitle") != null) {
                if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
                    alert("Please Select Prefix");
                    document.getElementById(strContent + "cboTitle").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
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
            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            //added by meena on 27/11/17 start
            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MISS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value != "S")) {

            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}
            CheckSpaces();
            if (SpaceTrim(document.getElementById(strContent + "txtpfGivenName").value) == "") {
                alert("Please Enter Given Name");
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

   //         if (SpaceTrim(document.getElementById(strContent + "txtMiddleName").value) == "") {
   //             alert("Please enter Middle Name");
   //             document.getElementById(strContent + "txtMiddleName").focus();
   //             //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

   //             return false;
			//}

           

<%--            var lenGivenName = document.getElementById('<%= txtpfGivenName.ClientID %>').value;
            if (lenGivenName.length < 3) {
                alert("Given Name should be atleast of three Characters");
                document.getElementById('<%= txtpfGivenName.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
            }--%>

<%--            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "HW") {
                if ((document.getElementById('<%=cboTitle.ClientID %>').value == "MISS") || (document.getElementById('<%=cboTitle.ClientID %>').value == "MRS") || (document.getElementById('<%=cboTitle.ClientID %>').value == "SHRI") || (document.getElementById('<%=cboTitle.ClientID %>').value == "SMT")) {

                }
                else {
                    alert("Please select proper Occupation and Title");
                    document.getElementById(strContent + "cboTitle").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                    return false;
                }
            }--%>

            //if (document.getElementById(strContent + "cboTitle") != null) {
            //    if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
            //        alert(document.getElementById(strContent + "hdnID280").value);
            //        document.getElementById(strContent + "cboTitle").focus();
            //        //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //        return false;
            //    }
            //}

            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            ////added by meena on 27/11/17 start
            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MISS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value != "S")) {

            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}

            //if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MRS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value == "S")) {
            //    alert("Invalid Title");
            //    document.getElementById(strContent + "cboTitle").focus();
            //    //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

            //    return false;
            //}
      //==============for pan validation==================
            //ValidationPAN();

            var varPAN = document.getElementById('<%= txtpan.ClientID %>').value;

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
            <%--debugger;

            if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "Select") {
                alert("Current Occupation is Mandatory");
                document.getElementById('<%= ddlPrimProf.ClientID %>').focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }--%>

            CheckSpaces();
        //=======================For DOB validation
            if ((document.getElementById('<%=cboGender.ClientID %>').value == "Select") || (document.getElementById('<%=cboGender.ClientID %>').value == "")) {
                alert("Please Select Gender");
                document.getElementById('<%= cboGender.ClientID %>').focus();
               
                return false;
            }
            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                //document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();

                return false;
            }

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

             var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                alert("Please Enter Date of Birth");
                //document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
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
            //else {
            //    return true;
            //}
            //Validation for DOB 

<%--            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) == "") {
                alert(document.getElementById(strContent + "hdnID450").value);
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) != "") {
                if (DateValidation(document.getElementById("<%= txtDOB.ClientID %>").value, "ctl00_ContentPlaceHolder1_txtDOB") == 1)
                    return false;
            }--%>

            //==================validation for Gender
            if ((document.getElementById('<%=cboGender.ClientID %>').value == "Select") || (document.getElementById('<%=cboGender.ClientID %>').value == "")) {
                alert("Please Select Gender");
                document.getElementById('<%= cboGender.ClientID %>').focus();
               
                return false;
            }
            debugger
            // Validation for father/spouse
            if (SpaceTrim(document.getElementById(strContent + "txtFatherName").value) == "") {
                alert("Please enter Father/Spouse Name");
                document.getElementById(strContent + "txtFatherName").focus();
                return false;
            }

            var lenFather = document.getElementById('<%= txtFatherName.ClientID %>').value;
            if (lenFather.length < 3) {
                alert("Father Name should be atleast of three Characters");
                document.getElementById('<%= txtFatherName.ClientID %>').focus();
                return false;
            }
            else if (AllowSpace()==2) {
               
                return false;
             }
            
            //=====================Validation for classification

            <%--if (document.getElementById('<%=ddlCategory.ClientID %>').value == "Select") {
                alert("Classification is Mandatory.");
                document.getElementById('<%= ddlCategory.ClientID %>').focus();
                
                return false;
            }--%>

            //======================Validation For Marital Status
            <%-- if (document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "Select" || document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "") {
                alert("Please Select Marital Status");
                document.getElementById(strContent + "cboMaritalStatus").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
             }--%>

            if ((SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) == "") || (document.getElementById(strContent + "txtNationalCode").value) != "IND") {
                alert(document.getElementById(strContent + "hdnID320").value);
                document.getElementById(strContent + "txtNationalCode").focus();

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

            if (document.getElementById("<%=cboMaritalStatus.ClientID%>").value == "M") {
                var idate = document.getElementById("ctl00_ContentPlaceHolder1_TxtAnnivrsryDt").value;
                debugger;
                           dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;

                if (IsFutureDate(idate)==0) {
                    return false;
                    }
               }
        }

		function validatepanel2() {
			debugger;
			var strContent = "ctl00_ContentPlaceHolder1_";
             if (document.getElementById("<%=ddlDstbnMethod.ClientID%>").value == "Select" || document.getElementById("<%=ddlDstbnMethod.ClientID%>").value == "") {
                alert("Please Select Contact Preferred");
                document.getElementById(strContent + "ddlDstbnMethod").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();

                return false;
			}
			
            if (SpaceTrim(document.getElementById(strContent + "txthometel").value) != "") {
                var HomeTel = SpaceTrim(document.getElementById('<%= txthometel.ClientID %>').value);
                if (HomeTel.length != 10) {
                    alert("Landline No.(with STD) should be 10 digit.");
                    document.getElementById(strContent + "txthometel").focus();
                     
                    return false;
                }
                
                if ((HomeTel.substr(0, 1)) == "0") {
                    alert("Landline No.(with STD) should not start with 0");
                    //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                
            }

            var Mobile1 = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
            var Mobile2 = SpaceTrim(document.getElementById('<%= txtMobile2.ClientID %>').value);

            if (SpaceTrim(document.getElementById(strContent + "txtMobileTel").value) == "") {
                alert("Mobile No. 1 is mandatory.");
                document.getElementById(strContent + "txtMobileTel").focus();
                return false;
            }
            else {
                var Mobile = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    return false;
                }

            }
            if (Mobile1.substr(0, 1) == "1" || Mobile1.substr(0, 1) == "0" || Mobile1.substr(0, 1) == "2" || Mobile1.substr(0, 1) == "3"
                         || Mobile1.substr(0, 1) == "4" || Mobile1.substr(0, 1) == "5") {
                alert("Mobile No.1 Should Start With (6,7,8,9)");
                document.getElementById(strContent + "txtMobileTel").focus();
                return false;

			}

            //if (SpaceTrim(document.getElementById(strContent + "txtMobile2").value) == "") {
            //    alert("Mobile No 2 is mandatory.");
            //    document.getElementById(strContent + "txtMobile2").focus();
            //    return false;
            //}
            
            if (document.getElementById(strContent + "txtMobile2").value != "") {
                if (!((document.getElementById("<%=txtMobile2.ClientID%>").value).length == "10")) {
                    alert("Mobile No.2 should be 10 digit");
                    document.getElementById(strContent + "txtMobile2").focus();
                    
                    return false;
                }
            }
            if (Mobile2.substr(0, 1) == "1" || Mobile2.substr(0, 1) == "0" || Mobile2.substr(0, 1) == "2" || Mobile2.substr(0, 1) == "3"
                         || Mobile2.substr(0, 1) == "4" || Mobile2.substr(0, 1) == "5") {
                alert("Mobile No.2 Should Start With (6,7,8,9)");
                document.getElementById(strContent + "txtMobile2").focus();
                           return false;

            }

            //if (SpaceTrim(document.getElementById(strContent + "txtWorkTel").value) == "") {
            //    alert("Work telephone is mandatory.");
            //    document.getElementById(strContent + "txtWorkTel").focus();
            //    return false;
            //}

            if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
                alert("Email Id 1 is mandatory.");
                document.getElementById(strContent + "txtemail").focus();
                return false;
            }
            else {

                var emailid = (document.getElementById(strContent + "txtemail").value);
                if (validateEmail1(emailid) == 0) {

                    return false;
                }
            }

            //if (SpaceTrim(document.getElementById(strContent + "txtEmail2").value) == "") {
            //    alert("Email 2 is mandatory.");
            //    document.getElementById(strContent + "txtEmail2").focus();
            //    return false;
            //}
            //else {

            //    var emailid = (document.getElementById(strContent + "txtEmail2").value);
            //    if (validateEmail1(emailid) == 0) {

            //        return false;
            //    }
            //}

            //if (SpaceTrim(document.getElementById(strContent + "txtEmail2").value) != "") {
            //    var emailid = (document.getElementById(strContent + "txtEmail2").value);
            //    if (validateEmail2(emailid) == 0) {
            //        return false;
            //    }
            //}
        }

        function validatepanel3() {
            funValidateEmpCode();
		}
        function IsFutureDate(dateVal) {
            var today = new Date().getTime(),
                dateVal = dateVal.split("/");

            dateVal = new Date(dateVal[2], dateVal[1] - 1, dateVal[0]).getTime();
            if ((today - dateVal) < 0) {
                alert("Anniversary date should not be a future date");
                return 0;
            }
            else {

                return 1;
            }

        }

        function DobVali() {
            var getdob = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;
            var enteredAge = getAge(getdob);
            if (enteredAge < 18) {
                 alert("Age must be between 18 to 70 years!");
                 txtDOB.focus();
                 return false;
             }
        }
        function getAge(DOB) {
            var today = new Date();
            var birthDate = new Date(DOB);
            var age = today.getFullYear() - birthDate.getFullYear();
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }    
            return age;
        }
        //======================= Fun added by Sarthak end=============================

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
    <div class="stripPanelClass">
        <ul class="nav nav-tabs" id="myTab" role="tablist">
              <li class="nav-item" role="presentation">
                        <button class="nav-link active Strip" id="divPDH1" runat="server" data-bs-toggle="tab" data-bs-target="#divPD1" type="button" role="tab" aria-controls="divPD1" aria-selected="true"><span id="span1" runat="server" class="badge bg-secondary numbercircle">1</span>&nbsp Prospect Details</button>
                    </li>
            <li class="nav-item" role="presentation">
                        <button class="nav-link Strip" id="divCDH1" runat="server" data-bs-toggle="tab" data-bs-target="#divCD1" type="button" role="tab" aria-controls="divCD1" aria-selected="false"><span id="span2" runat="server" class="badge bg-secondary numbercircle" style="background-color: #8c8c8c !important;">2</span>&nbsp Contact Details</button>
                    </li>
            <li class="nav-item" role="presentation">
                        <button class="nav-link Strip" id="divRDH1" runat="server" data-bs-toggle="tab" data-bs-target="#divRD1" type="button" role="tab" aria-controls="divRD1" aria-selected="false"><span id="span4" runat="server" class="badge bg-secondary numbercircle " style="background-color: #8c8c8c !important;">3</span>&nbsp Recruiter Details</button>
                    </li>
        </ul>
    </div>

<div class="PanelInsideTab" id="myTabContent">
    <asp:UpdatePanel ID="Updatepanel1" runat="server" CssClass="PanelInsideTab">
         <ContentTemplate>
        
      <div id="divPannel1" runat="server" visible="true">
                <div id="Div2" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnpersnl');return false;">           
                        <div class="row spacebetnrow">
                            <div class="col-sm-10" style="text-align:left">
                                <asp:Label ID="lblpfPersonal" runat="server" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                 
                            </div>
                            <div class="col-sm-2">
                                <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                </div>
                <div id="divSearch" runat="server" style="display:block;" class="panel-body">
                <asp:UpdatePanel ID="updPersonal" runat="server">
                <ContentTemplate>
          <%---------------------------First row App No Start-----------------------------%>         
                    <div class="row" style="text-align:left;font-weight:500;">
                        <div class="col-sm-4">
                            <asp:Label ID="lblpfAppNo" runat="server" CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblpfRegDate" runat="server" CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblProfession" runat="server"   CssClass="control-label labelSize"></asp:Label>
                        </div>
                    </div>
                    <div class="row spacebetnrow" style="text-align:left">
                        <div class="col-sm-4">
                             <asp:TextBox ID="txtpfAppNo" runat="server"  TabIndex="1" CssClass="form-control" MaxLength="8"
                                 ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtpfRegDate" runat="server" CssClass="form-control" TabIndex="2"
                                Enabled="False" MaxLength="20" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlPrimProf" runat="server" CssClass="form-control form-select mandatory" TabIndex="8">
                                    <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
          <%---------------------------First row App No End-----------------------------%>

                <%----------------------------Second Row------------------------%>
                    <div class="row labelSize" style="text-align:left;font-weight:500;">
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="lblpfPrefix" runat="server" CssClass="control-label labelSize">Prefix</asp:Label>
                                </div>
                                <div class="col-lg-9">
                                    <asp:Label ID="lblpfGivenName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4" style="display:none;">
                                    <asp:Label ID="lblpfMiddleName" runat="server" CssClass="control-label labelSize">Middle Name</asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <span>
                            <asp:Label ID="lblpfSurname" runat="server" CssClass="control-label labelSize"></asp:Label></span>
                        </div>
                         <div class="col-sm-4">
                            <asp:Label ID="lblpfGender" CssClass="control-label" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row spacebetnrow" style="text-align:left">
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="cboTitle" runat="server" CssClass="form-control form-select mandatory PrefixDll" DataTextField="ParamDesc" AutoPostBack="true" OnSelectedIndexChanged="cboTitle_SelectedIndexChanged"
                                        DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                         TabIndex="9" style="text-align:left;padding-left: 1px;padding-right: 1px;">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtpfGivenName" runat="server" CssClass="form-control mandatory" onChange="javascript:this.value=this.value.toUpperCase();"
                                  MaxLength="30" TabIndex="10" onblur="CheckSpaces();"></asp:TextBox>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnGenderTitle1" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdnGenderTitle2" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-sm-4" style="display:none;">
                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control mandatory" MaxLength="30" TabIndex="11"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <span>
                            <asp:TextBox ID="txtpfSurname" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                            CssClass="form-control" MaxLength="30" TabIndex="11"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars="" TargetControlID="txtpfSurname">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                         <div class="col-sm-4">
                             <asp:DropDownList ID="cboGender" Enabled="false" CssClass="form-control form-select mandatory" runat="server" 
                                TabIndex="12">
                            </asp:DropDownList>
                        </div>
                    </div>
                <%--------------------------Second Row End----------------------%>    
          <%---------------------------Third row pan Start-----------------------------%>  
                    <div class="row labelSize" style="text-align:left;font-weight:500;">
                        <div class="col-sm-4"> 
                            <asp:Label ID="lblpan" runat="server"  CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblpfDOB" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                       <div class="col-sm-4">
                            <asp:Label ID="lblpfFatherName" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                    </div>
                    <div class="row spacebetnrow" style="text-align:left">
                        <div class="col-sm-4">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                     <ContentTemplate>
                                         <div class="row">
                                             <div class="col-lg-12">
                                                <asp:TextBox ID="txtpan"  runat="server" CssClass="form-control mandatory" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="3"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" 
                                                    InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtpan"
                                                    FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                             </div>
                                             <div class="col-sm-3">
                                                 <asp:LinkButton ID="btnVerifyPAN" runat="server" Text="Verify" style="margin-bottom: 14px;" CssClass="btn btn-success"
                                                     OnClick="btnVerifyPAN_Click" OnClientClick="funpan();" TabIndex="4" Visible="false">
                                                <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                 </asp:LinkButton>
                                               </span>
                                            </div>
                                         </div> 
                                         <%--<div id="divPAN" class="Content" style="display: none">
                                             <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                             <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                         </div>--%>
                                         <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" CssClass="control-label labelSize"
                                             Font-Size="X-Small" Visible="false"></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                            <div runat="server" visible="false">
                                 <i class="fa fa-hand-o-right"></i>
                                 <asp:Label ID="ShowResult" runat="server" Text=""></asp:Label><br />
                            </div>
                        </div>
                        <div class="col-sm-4">
<%--                            <asp:TextBox CssClass="form-control mandatory" onmousedown="$('#txtDob').datepicker({ changeMonth: true, changeYear: true, minDate : new Date(1900, 0 , 1) });"
                                runat="server" ID="txtDOB" MaxLength="15"
                                TabIndex="14" />--%>   <%--onchange="setDateFormat('txtDob')" --%>
                            <asp:TextBox CssClass="form-control mandatory" onmousedown="textDOB ();" placeholder="dd/mm/yyyy" 
                                runat="server" ID="txtDOB" MaxLength="15"
                                TabIndex="13" />
                        </div>
                       <div class="col-sm-4">
                           <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control mandatory" onChange="javascript:this.value=this.value.toUpperCase();"
                             MaxLength="60" TabIndex="14" onblur="AllowSpace();return false;"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                                InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " TargetControlID="txtFatherName"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom">
                            </ajaxToolkit:FilteredTextBoxExtender> 
                        </div>
                    </div>
          <%---------------------------Third row pan End-----------------------------%>         

          <%---------------------------Fourth row DOB Start-----------------------------%>         
                    <div class="row" style="text-align:left;font-weight:500;">
                        
                        <div class="col-sm-4">
                            <asp:Label ID="lblpfNationality" CssClass="control-label" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblCategory" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblpfmaritalstatus" CssClass="control-label" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="text-align:left">
                        
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtNationalCode" runat="server" Style="margin-bottom:20px;text-align:center;" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                        Enabled="False"   MaxLength="3" TabIndex="16"></asp:TextBox>
                                </div>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtNationalDesc" runat="server" CssClass="form-control" Enabled="False"
                                        onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="17"></asp:TextBox> 
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control form-select" TabIndex="15">
                             </asp:DropDownList>
                        </div>
                         <div class="col-sm-4">
                            <asp:DropDownList ID="cboMaritalStatus" runat="server" CssClass="form-control form-select" AutoPostBack="true"
                                TabIndex="16" OnSelectedIndexChanged="cboMaritalStatus_SelectedIndexChanged">
                             </asp:DropDownList>
                        </div>
                    </div>
          <%---------------------------Fourth row DOB End-----------------------------%>  

          <%---------------------------Fifth row Nationality Start-----------------------------%>         
                    <div class="row labelSize" style="text-align:left;font-weight:500;">
                        
                        <div class="col-sm-4">
                            <asp:Label ID="LblAnnivrsryDt" Text="Anniversary Date" runat="server"
                                Style="color: black;" Visible="false"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                             <asp:Label ID="lblaadhr" runat="server" Text ="Aadhaar No"  Visible="false" CssClass="control-label labelSize"></asp:Label>                           
                        </div>
                    </div>
                    <div class="row spacebetnrow" style="text-align:left">
                            <div class="col-sm-4" id="divanniversarydate" runat="server" visible="false">
                                <asp:TextBox ID="TxtAnnivrsryDt" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"
                                        MaxLength="15" TabIndex="17" onmousedown="AnnvDte ();"></asp:TextBox>
                            </div>
                        <div class="col-sm-4">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                     <ContentTemplate>
                                         <div  class="input-group">
                                             <asp:TextBox ID="txtaadhr"  Enabled ="False" Visible="false" runat="server" CssClass="form-control mandatory" MaxLength="12" 
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
                                         <asp:Label ID="lblAadharMsg" runat="server" Font-Bold="False" CssClass="control-label labelSize"
                                             Font-Size="X-Small"></asp:Label>
                                     </ContentTemplate>
                                 </asp:UpdatePanel> 
                        </div>
                    </div>
          <%---------------------------Fifth row relationship with agent End-----------------------------%>  
                                       
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
      </div> 
        
        <div id="divPannel2" runat="server" visible="false">
          <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">           
              <div class="row spacebetnrow">
                   <div class="col-sm-10" style="text-align:left">             
                       <asp:Label ID="Label6" runat="server" text="Contact Information" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                   </div>
                   <div class="col-sm-2">
                       <span id="btnContactInformation" class="glyphicon glyphicon-chevron-down" style="float: right;color:#00cccc; 
                           padding: 1px 10px ! important; font-size:18px;"></span>
                   </div>
              </div>
          </div>
          <div id="divContactInformation" style="display:block;" runat="server" class="panel-body">
       <%--=========================First Row Preferred contact Mode Start========================--%>
            <div class="row" style="text-align:left; font-weight:500">
                <div class="col-sm-4">
                    <asp:Label ID="lblpfconpreferred" runat="server" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="row spacebetnrow">
                <div class="col-sm-4">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <contenttemplate>
                           <asp:DropDownList id="ddlDstbnMethod" runat="server"  CssClass="form-control form-select mandatory" AutoPostBack="true" 
                               TabIndex="20" ></asp:DropDownList>
                        </contenttemplate> 
                    </asp:UpdatePanel>
                </div>
            </div>
       <%--=========================First Row Preferred contact Mode End========================--%>
    
       <%--=========================Second Row Phone no Start========================--%>
            <div class="row" style="text-align:left; font-weight:500">
                <div class="col-sm-4">
                    <asp:Label ID="lblpfhometel" runat="server" CssClass="control-label" ></asp:Label>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblpfmobtel" runat="server" CssClass="control-label"></asp:Label>                    
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblMobile2" runat="server" CssClass="control-label"></asp:Label>                   
                </div>
            </div>
            <div class="row spacebetnrow">
                <div class="col-sm-4">
                     <div class="row">
                        <div class="col-sm-3">
                           <asp:TextBox ID="txtLandlinecode" Enabled="false"  runat="server" Text="91" CssClass="form-control PrefixDll" style="text-align:center" TabIndex ="43"></asp:TextBox>                            
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox  ID="txthometel" runat="server" placeholder="Should not start with 0 and should be 10 digit." 
                                CssClass="form-control" MaxLength="10" TabIndex = "21" ></asp:TextBox>
                            <asp:Label ID="LblhomeNote" runat="server" visible="false" Text="(Tel No:Should not start with 0 and should be 10 digit.)" CssClass="control-label" ForeColor="Red"></asp:Label>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                 FilterMode="InvalidChars" TargetControlID="txthometel" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <asp:Label ID="lblMobNote" runat="server" Text="(Mobile No should be 10 digit.)"
                            visible="false"  Font-Size="Smaller" CssClass="control-label" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-sm-4">
                     <div class="row">
                        <div class="col-sm-3">
                           <asp:TextBox ID="txtmobcode" Enabled="false"  runat="server" Text="91" CssClass="form-control PrefixDll" style="text-align:center" TabIndex ="23"></asp:TextBox>                            
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtMobileTel" runat="server" CssClass="form-control mandatory" 
                                placeholder="Mobile No should be 10 digit."   MaxLength="10" TabIndex="22"></asp:TextBox>
                         
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                FilterMode="InvalidChars" TargetControlID="txtMobileTel" FilterType="Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                     <div class="row">
                        <div class="col-sm-3">
                           <asp:TextBox ID="txtmobcode2"  runat="server" Text="91" style="text-align:center" CssClass="form-control PrefixDll" TabIndex="25" Enabled="false"></asp:TextBox>                            
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtMobile2" runat="server" CssClass="form-control" 
                              MaxLength="10" TabIndex="23"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                FilterMode="InvalidChars" TargetControlID="txtMobile2" FilterType="Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>
                </div>
            </div>
       <%--=========================Second Row Phone no End========================--%>

       <%--=========================Third Row Office Tel no Start========================--%>
            <div class="row" style="text-align:left; font-weight:500">
                <div class="col-sm-4">
                    <asp:Label ID="lblpfofftel" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblpfemail" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblEmail2" runat="server" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="row spacebetnrow">
                <div class="col-sm-4">
                    <asp:TextBox ID="txtWorkTel" runat="server" CssClass="form-control" MaxLength="10" TabIndex="23" ></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                        FilterMode="InvalidChars" TargetControlID="txtWorkTel" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control mandatory" MaxLength="50" TabIndex="24" ></asp:TextBox>&nbsp;
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control" MaxLength="50" TabIndex="25" ></asp:TextBox>
                </div>
            </div>
        <%--=========================Third Row Office Tel End========================--%>
        </div>
        </div>
       
        <div  id="divpanel3" runat="server" visible="false">
         <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divrecruit','btncallmap');return false;">
             <div class="row spacebetnrow">
                 <div class="col-sm-10" style="text-align: left">                     
                     <asp:Label ID="lblpfrecinfotitle" runat="server" CssClass="control-label HeaderColor" Font-Size="19px"></asp:Label>
                 </div>
                 <div class="col-sm-2">
                     <span id="btncallmap" class="glyphicon glyphicon-chevron-down" style="float: right;
                         color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                 </div>
             </div>
         </div>
         <div id="divrecruit" style="display:block;" runat="server" class="panel-body">
             <div class="row"  style="text-align: left">
                                    <div class="col-sm-4">
                                          <asp:Label ID="Label5" Text="Employee Code" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                 </div>
             <div class="row spacebetnrow" style="text-align:left;">
                  <div class="col-sm-4">
                  
                    
                                    <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control mandatory" TabIndex="29" Enabled="false" ReadOnly="true" 
                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtEmpCode"
                                        FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                 <div >
                                    
                                 </div>
                             <div id="Div1" class="Content" style="display: none">
                                 <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                            
                             <asp:Label ID="lblEmpMsg" runat="server" CssClass="control-label" Font-Bold="False"
                                 Font-Size="X-Small"></asp:Label>
                        
                 </div>
                     <div class="col-sm-1" style="display:none;">
                          <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-success buttonsize" style="margin-bottom:15px;margin-left:2px;" OnClientClick="funrecruitercode();"
                                         OnClick="btnVerifyEmpCode_Click" ValidationGroup="RecruitInfo" TabIndex="30" Visible="false">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify   
                                     </asp:LinkButton>
                         </div>
             </div>
            
             <div class="row" style="text-align:left; font-weight:500">
                 <div class="col-sm-4">
                     <asp:Label ID="lblpfSlsChannel" runat="server" CssClass="control-label"></asp:Label>
                 </div>
                 <div class="col-sm-4">
                     <asp:Label ID="lblpfChnCls" CssClass="control-label" runat="server"></asp:Label>
                 </div>
                 <div class="col-sm-4">
                     <asp:Label ID="lblpfSMName" CssClass="control-label" runat="server"></asp:Label>
                 </div>
             </div>
             <div class="row spacebetnrow">
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="form-control mandatory" Enabled="false"
                                 OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" AutoPostBack="true"
                                 TabIndex="31">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control mandatory" Enabled="true" OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged"
                                 AutoPostBack="true" TabIndex="32">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                         <ContentTemplate>
                             <asp:TextBox ID="txtSMName" runat="server" CssClass="form-control mandatory" ReadOnly="true"
                                 TabIndex="33"></asp:TextBox>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
             </div>
           
             <div class="row" style="text-align:left; font-weight:500">
                 <div class="col-sm-4">
                      <asp:Label ID="lblpfagetype" runat="server" CssClass="control-label"></asp:Label>
                 </div>
                 <div class="col-sm-4">
                     <asp:Label ID="lblpfimmleader" CssClass="control-label" runat="server"></asp:Label>
                 </div>     
                 <div class="col-sm-4">
                     <asp:Label ID="lblCndAgtType" runat="server" CssClass="control-label"></asp:Label>
                 </div>
             </div>
             <div class="row" style="height:52px">
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlAgntType" runat="server" style="display:none" CssClass="form-control mandatory"
                                 AutoPostBack="false" TabIndex="34">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlAgnTypes" runat="server" DataTextField="MemTypeDesc01" DataValueField="MemType"
                                 Enabled="false" CssClass="form-control mandatory" DataSourceID="DSAgnTypes" TabIndex="35">
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     <asp:SqlDataSource ID="DSAgnTypes" runat="server" ConnectionString="<%$ ConnectionStrings:INSCCommonConnectionString %>">
                     </asp:SqlDataSource>
                 </div>
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                         <ContentTemplate>
                                 <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control mandatory" TabIndex="36"  disabled="true"
                                     onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>&nbsp;

                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                     InvalidChars="&`''#%!@$^*-_+={}[]|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtBranchCode"
                                     FilterType="Custom">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                                <span class="input-group-addon input-addon_extended">
                                     <asp:LinkButton ID="btnRptMgr" runat="server" CssClass="btn btn-verify" style="margin-bottom:15px;margin-left:2px; display:none" OnClientClick="funrecruitercode();"
                                         OnClick="btnmemgrid_Click" TabIndex="37">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> ...   
                                     </asp:LinkButton>
                                 </span>
                            
                         </ContentTemplate>
                     </asp:UpdatePanel>
                      <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                        <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                        <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static" 
                                            
                                        Style="display: none;" />
                 </div>
                 <div class="col-sm-4">
                     <asp:UpdatePanel ID="updpnlCndAgtType" runat="server">
                         <ContentTemplate>
                             <asp:DropDownList ID="ddlCndAgtType" runat="server" CssClass="form-control mandatory" Enabled="false"
                                 TabIndex="39" >
                             </asp:DropDownList>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     <asp:HiddenField ID="hdnBizsrc1" runat="server" />
                     <asp:HiddenField ID="hdnChnCls" runat="server" />
                 </div>
             </div>
          
             <div class="row" style="text-align:left;">
                 <div class="col-sm-4">
                     <asp:Label ID="LblRptMgrCode" runat="server" Text="Additional Reporting Manager" CssClass="control-label"></asp:Label>
                       
                             <asp:DropDownList ID="ddlAddRptMgrCode" runat="server"  CssClass="form-control form-select"
                                 AutoPostBack="false" TabIndex="34">
                             </asp:DropDownList>
                 </div>
             </div>
             
         </div>
     </div>
       
        <div class="row" style="margin-top:12px;" id="btnrow" runat="server">
            <div class="col-sm-12" style="text-align:center;">
                   <asp:LinkButton ID="btnPrev2" runat="server" Text="PREVIOUS" CssClass="btn btn-success" Visible="false" OnClick="btnPrev2_Click">
               <span class="glyphicon glyphicon-arrow-left BtnGlyphicon"> </span>  PREVIOUS 
           </asp:LinkButton>
                 <asp:LinkButton ID="btnPrev1" runat="server" Text="" CssClass="btn btn-success" OnClick="btnPrev1_Click" Visible="false">
                 <span class="glyphicon glyphicon-arrow-left BtnGlyphicon"> </span>  PREVIOUS 
            </asp:LinkButton>
                 <%--1 tab--%>
                   <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" CausesValidation="False"
                OnClick="btnCancel_Click" TabIndex="359">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon">CLEAR </span> 
            </asp:LinkButton>
            <asp:LinkButton ID="btnexit" runat="server" CssClass="btn btn-danger" CausesValidation="False" OnClick="btnexit_Click">EXIT
                             <span  class="glyphicon glyphicon-remove BtnGlyphicon"> </span> 
            </asp:LinkButton>
                <asp:Button ID="btnPreview" runat="server" Text="PREVIEW" CssClass="btn btn-success buttonsize" Visible="false"  OnClick="btnPreview_Click" OnClientClick="return validatepanel3()"/>
                <asp:Button ID="btnNextPannel3" runat="server" Text="NEXT" CssClass="btn btn-success buttonsize" OnClick="btnNextPannel2_Click" Visible="false"  />              
                <%--<asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="SAVE"  OnClientClick="funpan();" Visible="false" 
                 OnClick="btnUpdate_Click" TabIndex="40">SAVE
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> 
            </asp:LinkButton>--%>
                <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="SAVE" Visible="false" OnClick="btnUpdate_Click"
                 TabIndex="358">SAVE
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> 
            </asp:LinkButton>
                 <asp:LinkButton ID="btnNextPannel1" runat="server" Text="" CssClass="btn btn-success" OnClick="btnNextPannel1_Click"  Visible="true" OnClientClick="return validatepanel1()">
                NEXT  <span class="glyphicon glyphicon-arrow-right BtnGlyphicon"> </span>
            </asp:LinkButton><%----%>
                <%--1 tab--%>
                 <asp:LinkButton ID="btnNextPannel2" runat="server" Text="" CssClass="btn btn-success" OnClick="btnNextPannel2_Click"  Visible="false"  OnClientClick="return validatepanel2()">
                NEXT <span class="glyphicon glyphicon-arrow-right BtnGlyphicon"> </span>
            </asp:LinkButton>
            </div>
          </div>
<div class="row rowspacing" id="btnnote" runat="server">
    <div class="col-sm-12" style="text-align:center">
           <asp:Label ID="Label1" Text="Note : Name as per PAN card." Font-Size="Small" runat="server" CssClass="control-label"
                                ForeColor="Red"></asp:Label><br /><%--shreela 29/05/2014--%>
</div>
</div>
       
        <div ><%--class="container img-rounded mainpage-header">--%>
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
       
       </ContentTemplate>
    </asp:UpdatePanel>
         <br /> 
        <div class="PanelInsideTab" style="display:none">
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
                         
                                </div>
                                 <div class="col-md-6">
                            <asp:Label ID="Label2" Text=" Letter from Panchayat if population is less than 5000 for rural case."
                             CssClass="control-label"   Font-Size="Small" runat="server" ForeColor="Red" Visible="False"></asp:Label><%--shreela 29/05/2014--%>
                       </div>
                       </div>
                </div>
        </div>
        </div>

     <input id="hdnflag" type="hidden" runat="server" />
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
      
    <div class="modal fade" id="myModal" role="dialog" style="opacity:1.0">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style='width: 400px; height: 300px;'>
                <div class="modal-header" style="margin-left:126px;background-color: white !important;color: #00cccc;border-bottom:none;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true" Style="font-weight: bold; margin-left: 7px; color: blue; font-size: 20px; margin-top: 20px;"></asp:Label>

                </div>

                <div id="divmdlbdy" class="modal-body" style="text-align: center">
                    
                </div>
                <div class="modal-footer" style="margin-right:160px;border-top:none;">
                    <button type="button" class="btn btn-success" data-dismiss="modal" style='margin-bottom: 36px; width: 69px; margin-left: 171px;' onclick="Hidepopup();">
                        <span  style="color: white" ></span>OK

                    </button>
                </div>
            </div>

        </div>
    </div>

    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="428" display="none" top="52">
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="530px" frameborder="0" style="margin-top: -60px;"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="400px" Width="750px" ID="pnlRwdRulDemo" display="none" top="52" Style="margin-left: 350px;">
        <iframe runat="server" id="ifrmRwd1" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label11" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw" BehaviorID="mdlVwBID" DropShadow="false"
        TargetControlID="Label11" PopupControlID="pnlRwdRulDemo" BackgroundCssClass="modalPopupBg" X="20" Y="30">
    </ajaxToolkit:ModalPopupExtender>

    <%--For Displaying Information Pop-up End--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />



    <asp:UpdatePanel ID="pop1" runat="server">
        <ContentTemplate>
   <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder"   Width="38%" Height="51%" style="background-color: white" Visible="false">
         <div class="panel rcorners2" id="divAlert" runat="server" style="width:30%;
                display: block; border: 2px;border: 0px !important;
              " cellpadding="0" cellspacing="0">
                <div id="Div25" runat="server"   style="width:100% !important" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div id="Div26" runat="server">
                             <center style="color: #034ea2;font-size: 22px;padding:10px;margin-left: -38px;width: 100%;"  CssClass="control-label HeaderColor">INFORMATION</center>
                            </div>
                        </div>
        <table>
            <tr>
                <td style="width: 391px;">
                    <center>
                        <asp:Label ID="lbl3" runat="server" ></asp:Label><br />
                    </center>
                </td>
            </tr>
           
        </table>
             <br />
        <center>
                 <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" style="margin-left: -38px;width:80px;" CssClass="btn btn-success"/>
                     </center>
       
           
            <br />
            </div>
    </asp:Panel>
    
                <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl3"
                    BehaviorID="mdlpopup" PopupControlID="pnl" BackgroundCssClass="modalPopupBg"
                    OkControlID="btnok" Y="100">
                   
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>


    <script type="text/javascript">
        function ConCol() {
            document.getElementById('ctl00_ContentPlaceHolder1_span1').setAttribute("style", "background-color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divPDH1').setAttribute("style", "color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_span2').setAttribute("style", "background-color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divCDH1').setAttribute("style", "color: #00cccc !important");
        }
        function ConColRem() {
            document.getElementById('ctl00_ContentPlaceHolder1_span1').setAttribute("style", "background-color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divPDH1').setAttribute("style", "color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_span2').setAttribute("style", "background-color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divCDH1').setAttribute("style", "color: #8c8c8c !important");
        }
         function RDCol() {
            document.getElementById('ctl00_ContentPlaceHolder1_span2').setAttribute("style", "background-color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divCDH1').setAttribute("style", "color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_span4').setAttribute("style", "background-color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divRDH1').setAttribute("style", "color: #00cccc !important");
        }
         function RDColRem() {
            document.getElementById('ctl00_ContentPlaceHolder1_span2').setAttribute("style", "background-color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divCDH1').setAttribute("style", "color: #00cccc !important");
            document.getElementById('ctl00_ContentPlaceHolder1_span4').setAttribute("style", "background-color: #8c8c8c !important");
            document.getElementById('ctl00_ContentPlaceHolder1_divRDH1').setAttribute("style", "color: #8c8c8c !important");
        }
        </script>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AGTInfo.aspx.cs" Inherits="INSCL.AGTInfo"
    MasterPageFile="~/iFrame.master" Title="Agent Info Maintenance" %>


<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Microsoft.Web.Atlas" Namespace="Microsoft.Web.UI" TagPrefix="cc1" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup2.ascx" TagName="ddlLookup" TagPrefix="uc4" %>
<%@ Register Src="~/App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup"
    TagPrefix="uc5" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup" TagPrefix="uc8" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<%-- 
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="HirerachyJS/Pan.js"></script>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
 
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
 
    <script src="../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.js"></script>
    <script src="../Recruit/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
  
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Bootstrap/css/jquery-1.10.2.min.js"></script>
    <script src="../../../assets/scripts/core/app.js" type="text/javascript"></script>
    <script src="../../../assets/scripts/custom/ui-alert-dialog-api.js"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
     <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
        <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
   
      <%--added by sanoj 12-12-2022 --%>

     <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"  type="text/css" />
  <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />


     
    <%-- <style>
       .form-select {
           display: block;
           width: 100%;
           padding: 0.375rem 2.25rem 0.375rem 0.75rem;
           background-position: right 0.75rem center; 
           transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }
     </style>


    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />--%>

 <%--   endded by sanoj 12-12-2022--%>
 
   <%-- <style>
        .Prefix1{
            margin-left: -18px;
            margin-right: 10px;
            Width: 80px;
            height: 34px;
            text-align: center;
            padding: 2px;
        }

        .btncolor1 {
            color: white;
        }
    </style>--%>
    <script type="text/javascript">
       
        function showProfiling(){
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
          function hideProfiling(){
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "block";
        }
        function showSalHie(){
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
        function hideSalHie(){
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
       function showBnkNme(){
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
         function hideBnkNme(){
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }

     
         function  hideDocupld(){
           document.getElementById("ctl00_ContentPlaceHolder1_ImgDocumentUpload").style.display = "none";
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }

        function showSummary() {
           document.getElementById("ctl00_ContentPlaceHolder1_ImgSummary").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgDocumentUpload").style.display = "none";
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }

         function hideSummary(){
           document.getElementById("ctl00_ContentPlaceHolder1_ImgSummary").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgDocumentUpload").style.display = "block";
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
          function  showDocupld(){
           document.getElementById("ctl00_ContentPlaceHolder1_ImgDocumentUpload").style.display = "block";
           document.getElementById("ctl00_ContentPlaceHolder1_ImgBank").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgHierarchy").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBusiness").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "none";
        }
       //added by sanoj 16052023
        function setGender(val) {
            debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_ddlGender").value = val;
                }
      //added by sanoj 16052023
        function myFunction() {
            document.getElementById('divPAN').style.display = 'block';
            showBasicInfo();
            ValidationPAN();
            var strContent = "ctl00_ContentPlaceHolder1_";
            debugger;
            document.getElementById(strContent + "btnVerifyPAN").click();
            //document.getElementById(strContent + "btnVerfyP").click();
            

        }
         function showBasicInfo() {
            debugger;
        document.getElementById("ctl00_ContentPlaceHolder1_ImgBasicInfo").style.display = "block";
        }

        function AnnvDte() {
            $("#<%= TxtAnnivrsryDt
        .ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate:'0'
            });
        }
       
        function DatetxtTenurFrom() {
            $("#<%= txtTenurFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        }
        function Datetxttenur2() {
            $("#<%= txttenur2.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        }
        function DateNomDob() {
           //maxDate: 0,
            var today = new Date();
            var eighteenYearsAgo = new Date(today.getFullYear() - 18, today.getMonth(), today.getDate());
            var dateOfBirthInput = document.getElementById("ctl00_ContentPlaceHolder1_txtNomDob");
             $("#<%= txtNomDob.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
            
                minDate: new Date(1905, 0, 1),
                maxDate: new Date(today.getFullYear() - 18, today.getMonth(), today.getDate())
            });
        }
        function showPopup() {
            var some_html = '<div style="font-size:10.0pt;font-family:Calibri,sans-serif;color:black;"><p>The maximum score for each pair of questions is 3,total for question A and question B is 3, for example</p><ul><li>If A is very characteristic of you and B is very uncharacteristic, write ‘3’ next to A and ‘0’ next to B. </li><li>If B is very characteristic of you and A is very uncharacteristic, write ‘3’ next to B and ‘0’ next to A. </li><li>If A is somewhat characteristic of you and B is less characteristic, write ‘2’ next to A and ‘1’ next to B. </li><li>If B is somewhat characteristic of you and A is less characteristic, write ‘2’ next to B and ‘1’ next to A </li></ul></div>';
            bootbox.alert(some_html);
            return false;
        }

        jQuery(document).ready(function () {
            App.init();
            UIAlertDialogApi.init();
        });

        function doCancel() {

            window.close();

        }
        function showPopup1() {
        }
        function AllowIFSC() {
            var ifsc = document.getElementById('<%=txtNeftCode.ClientID%>').value;
            var reg = /[A-Za-z]{4}[A-Za-z0-9]{7}$/;
            if (!ifsc.match(reg)) {
                document.getElementById("ctl00_ContentPlaceHolder1_spanifsccode").style.display = "block";
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_spanifsccode").style.display = "none";

            }
        }
    </script>

   <%-- <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/jQuery_1.X.js"></script>--%>
    <script language="javascript" type="text/javascript">
         function Datedob() {
             var today = new Date();
            var eighteenYearsAgo = new Date(today.getFullYear() - 18, today.getMonth(), today.getDate());
            var dateOfBirthInput = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB");
             $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                
                minDate: new Date(1905, 0, 1),
                maxDate: new Date(today.getFullYear() - 18, today.getMonth(), today.getDate())

            });
            //dateOfBirthInput.value = eighteenYearsAgo.toISOString().slice(0, 10);
            
        }

        var path = "<%=Request.ApplicationPath.ToString()%>";

        $(document).ready(function () {//Added:Parag
Datedob();
DateNomDob();
            $("#ctl00_ContentPlaceHolder1_txtBizLicEndDt").css("background-color", "#FFFFB2");
        });


        function LdWait(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }

        function RemoveLoading12() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';

        }



        function worktelval() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            var work = document.getElementById(strContent + "txtWorkTel").value;
            if (work != "") {
                if (work.length != 10) {
                    alert("Office Tel (with STD) should be 10 digit.");
                    return false;
                }
                else {
                    return "1";
                }
            }
        }

        function verifyPan() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "ddlGender").focus();
        }

        function CheckCapitalLimit(src, args) {
            var result = true;
            var capital = document.getElementById("<%=txtCapital.ClientID%>").value.split(",");

            if ((capital != null) && capital != 0) {
                if (IsNumeric(capital[0])) {
                    var capital = capital[0]

                    if (IsInteger(capital)) {
                        if ((capital <= 2000000000) && (capital >= -2000000000))
                            result = true;
                        else
                            result = false;
                    }
                }
                else {
                    result = false;
                }
            }
            args.IsValid = result;
        }

        function IsInteger(sText) {
            var ValidChars1 = "-0123456789";
            var ValidChars2 = "0123456789";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (i == 0) {
                    if (ValidChars1.indexOf(Char) == -1)
                        IsNumber = false;
                }
                else {
                    if (ValidChars2.indexOf(Char) == -1)
                        IsNumber = false;
                }
            }

            return IsNumber;
        }

        function CheckStaffSzLimit(src, args) {
            var result = true;
            var StaffSz = document.getElementById("<%=txtStaffSz.ClientID%>").value.split(",");

            if ((StaffSz != null) && StaffSz != 0) {
                var StaffSz = StaffSz[0]

                if (IsInteger(StaffSz)) {
                    if ((StaffSz <= 2000000000) && (StaffSz >= -2000000000))
                        result = true;
                    else
                        result = false;
                }
            }
            args.IsValid = result;
        }

        function CheckAnnTurnoverLimit(src, args) {
            var result = true;
            var AnnTurnover = document.getElementById("<%=txtAnnTurnover.ClientID%>").value.split(",");

            if ((AnnTurnover != null) && AnnTurnover != 0) {
                var AnnTurnover = AnnTurnover[0]

                if (IsInteger(AnnTurnover)) {
                    if ((AnnTurnover <= 9000000000000000) && (AnnTurnover >= -9000000000000000))
                        result = true;
                    else
                        result = false;
                }
            }

            args.IsValid = result;
        }

        function client_function() {
            document.getElementById("ctl00_ContentPlaceHolder1_txtUntCode").value = "";
            document.getElementById("ctl00_ContentPlaceHolder1_txtCmpUntCode").value = "";
        }

        //Added by swapnesh on 17-12-2013 for collapsable functionality start
        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }
        //Added by swapnesh on 17-12-2013 for collapsable functionality end

        //Added by swapnesh on 21/12/2013 to set visibility of Client Details panel start
        function ShowCltDtls(lictype) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_divCClient") != null || document.getElementById("ctl00_ContentPlaceHolder1_divPClient") != null) {
                if (lictype == 'P') {
                    //document.getElementById("ctl00_ContentPlaceHolder1_divCClient").style.display = "none";
                    //document.getElementById("ctl00_ContentPlaceHolder1_divPClient").style.display = "block";

                }
                else if (lictype == 'C') {
                    //document.getElementById("ctl00_ContentPlaceHolder1_divCClient").style.display = "block";
                    //document.getElementById("ctl00_ContentPlaceHolder1_divPClient").style.display = "none";

                }
                else if (lictype == '') {
                    //document.getElementById("ctl00_ContentPlaceHolder1_divCClient").style.display = "none";
                    //document.getElementById("ctl00_ContentPlaceHolder1_divPClient").style.display = "none";
                }
            }
        }
        //Added by swapnesh on 21/12/2013 to set visibility of Client Details panel end

        function filldob(strDate) {
            document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").text = strDate;
        }
//added by ajay for pan format 02052023 start
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
//added by ajay for pan format 02052023 end
        //Added by swapnesh on 31/12/2013 for Pan Verification start
        function ValidationPAN() {
            var varPAN = document.getElementById('<%= txtPanNo.ClientID %>').value;
            document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';
            if (varPAN.length < 10 && varPAN.length > 1) {
                alert('PAN No. must have minimum 10 characters.');
          <%--  document.getElementById('<%= txtPanNo.ClientID %>').focus();--%>
                return false;
            }

            //Validation for PAN No format.
            if (SpaceTrim(document.getElementById('<%= txtPanNo.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtPanNo.ClientID %>').value)) == 0) {
                alert('Invalid Pan Format');
               <%-- document.getElementById('<%= txtPanNo.ClientID %>').focus();--%>
                    return false;
                }
            }

            document.getElementById('divPAN').style.display = 'none';

        }
        function CheckPANFormat(strPANNo) {
            debugger;
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
                                //adeed by sanoj H,C,F for pan validation
                                if (pan2.substring(j, j + 1) != 'P' && pan2.substring(j, j + 1) != 'C'&& pan2.substring(j, j + 1) != 'F' && pan2.substring(j, j + 1) != 'H')
                                {
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
        //Added by swapnesh on 31/12/2013 for Pan Verification end

        //For TPD New Field to Add End  
        function getRadioSelectedValue(radioList) {
            var options = radioList.getElementsByTagName('input');
            for (i = 0; i < options.length; i++) {
                var opt = options[i];
                if (opt.checked) {
                    return opt.value;
                }
            }
        }

        function chkPerc(str, alwEmpty) {
            str = str.toString();
            if (isEmpty(str))
                return (alwEmpty == 1) ? (true) : (false)   //Allow Empty return true	
            if (!chkAmount(str))
                return false;
            if ((parseFloat(str) < 0) || (parseFloat(str) > 100))
                return false;
            return true;
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

        function doValidateName(src, args) {
            var result = true;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtBankHolderName").value;
            //Check for invalid characters
            var iChars = "#%!@&$^*_+={}[]|\:;?><,.'~0123456789";
            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = false;
                }
            }

            args.IsValid = result;
        }

        function isInteger(src, args) {
            var result = true;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtBankAccNo").value;
            //Check for invalid characters
            var iChars = "#%!@&$^*_+={}[]|\:;?><,.~-";
            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = false;
                }
            }
            args.IsValid = result;
        }

        function CompareWith2Day() {
            var varHidnVal = document.getElementById("ctl00_ContentPlaceHolder1_hdncurdate").value;
            // made changes to get txtrecruit date -Ibrahim    
            var varToDate = document.getElementById("ctl00_ContentPlaceHolder1_txtRecruitDate").value;
            // made changes to get txtrecruit date -Ibrhaim
            var arrCurDt = varHidnVal.split('/');
            var arrToDt = varToDate.split('/');

            // FromYear greater than ToYear
            if (parseInt(arrCurDt[2], 10) < parseInt(arrToDt[2], 10)) {
                alert("Future date is not allowed for Recruit Date");
                return false;
            }
            else if ((parseInt(arrCurDt[2], 10) == parseInt(arrToDt[2], 10))) {
                // Check if from month > to Month
                if (parseInt(arrCurDt[1], 10) < parseInt(arrToDt[1], 10)) {
                    alert("Future date is not allowed for Recruit Date");
                    return false;
                }
                else if (parseInt(arrCurDt[1], 10) > parseInt(arrToDt[1], 10)) {
                    alert("Recruit date should be of current month");
                    return false;

                }
                else if (parseInt(arrCurDt[1], 10) == parseInt(arrToDt[1], 10)) {
                    if (parseInt(arrCurDt[0], 10) < parseInt(arrToDt[0], 10)) {
                        alert("Future date is not allowed for Recruit Date");
                        return false;
                    }
                }

            }
            else if (parseInt(arrCurDt[2], 10) > parseInt(arrToDt[2], 10)) {
                alert("Recruit date should be of current month");
                return false;
            }

            return true;

        }

        function CompareWith2DayLicExp() {
            /////debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            var varHidnVal = document.getElementById("ctl00_ContentPlaceHolder1_hdncurdate").value;
            var varToDate = "";
            if (document.getElementById(strContent + "txtBizLicEndDt") != null) {
                varToDate = document.getElementById(strContent + "txtBizLicEndDt").value;
            }
            var arrCurDt = varHidnVal.split('/');
            var arrToDt = varToDate.split('/');
            // FromYear greater than ToYear
            if (parseInt(arrCurDt[2], 10) > parseInt(arrToDt[2], 10)) {
                alert("Past date is not allowed for License Expiry Date");
                return false;

            }
            // Check if from month > to Month
            else if ((parseInt(arrCurDt[2], 10) == parseInt(arrToDt[2], 10))) {
                if (parseInt(arrCurDt[1], 10) > parseInt(arrToDt[1], 10)) {
                    alert("Past date is not allowed for License Expiry Date");
                    return false;
                }
                else if (parseInt(arrCurDt[1], 10) == parseInt(arrToDt[1], 10)) {
                    if (parseInt(arrCurDt[0], 10) > parseInt(arrToDt[0], 10)) {
                        alert("Past date is not allowed for License Expiry Date");
                        return false;
                    }
                }
            }
            return true;
        }

        function chkRecruitAgt() {
            var RecruitAgtCode = document.getElementById("ctl00_ContentPlaceHolder1_txtRecruitAgntCode");
            var AgentRank = document.getElementById("ctl00_ContentPlaceHolder1_hdnAgntRank").value;

            var errMsg1 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID210").value; //Please enter Recruit Agent Code.
            var errMsg2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID220").value; //Recruit Agent Code is 8 characters length.
            var errMsg3 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID280").value; //Recruit Agent Code cannot same as Agent Code
            var errMsg4 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID290").value; //Please enter valid Recruit Agent Code.
            var errMsg5 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID270").value; //Please enter Unit Code.
            var errMsg6 = document.getElementById("ctl00_ContentPlaceHolder1_hdnID300").value; //Please enter Branch Office Code.

            if (RecruitAgtCode.value == '') {
                alert(errMsg1);
                return false;
            }
            //        Ibrhaim

            //Purpose: For Zone Manager, the Agent Code are allow same as Recruit Agent Code
            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_hdnAgntRank").value) != '2') {
                if (RecruitAgtCode && document.getElementById("ctl00_ContentPlaceHolder1_ddlAgntType")) {
                    if (RecruitAgtCode.value == document.getElementById("ctl00_ContentPlaceHolder1_txtAgtCode").value) {
                        alert(errMsg3);
                        RecruitAgtCode.focus();
                        return false;
                    }
                }
            }
            return true;
        }

        function chkMgrCode() {
            ///modified by akshay on 13-02-14 start
            if (document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr") == null) {
                var DirectAgtCode = "";
            }
            else {
                var DirectAgtCode = document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr").value;
            }

            if (document.getElementById('<%= txtRptMgr.ClientID %>' != null)) {
                if (isBlank(document.getElementById('<%= txtRptMgr.ClientID %>').value)) {
                    return funShowAlert("ctl00_ContentPlaceHolder1_hdnID650", '<%= txtRptMgr.ClientID %>');
                }
            }

            if (!isBlank(DirectAgtCode) && !chkCodes(DirectAgtCode)) {
                return funShowAlert("ctl00_ContentPlaceHolder1_hdnID530", "ctl00_ContentPlaceHolder1_hdnRptMgr");
            }

            return true;
        }

        function chkDirectAgt() {
            var DirectAgtCode = document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr").value;
            var AgentRank = document.getElementById("ctl00_ContentPlaceHolder1_hdnAgntRank").value;


            if (isBlank(document.getElementById('<%= txtRptMgr.ClientID %>').value)) {
                return funShowAlert("ctl00_ContentPlaceHolder1_hdnID650", '<%= txtRptMgr.ClientID %>');
            }

            if (!isBlank(DirectAgtCode) && !chkCodes(DirectAgtCode)) {
                return funShowAlert("ctl00_ContentPlaceHolder1_hdnID530", "ctl00_ContentPlaceHolder1_txtRptMgr");
            }
            if (AgentRank != 2) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr").disabled == false) {
                    if (DirectAgtCode == document.getElementById("ctl00_ContentPlaceHolder1_txtAgtCode").value) {
                        return funShowAlert("ctl00_ContentPlaceHolder1_hdnID320", "ctl00_ContentPlaceHolder1_txtRptMgr");
                    }
                }
            }
            return true;
        }

        function Termination_Validate() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "chkShwCauseLtr").checked == true) {
                if (document.getElementById(strContent + "txtMisc4").disabled == false) {
                    if (document.getElementById(strContent + "txtMisc4") != null) {
                        if (isEmpty(document.getElementById(strContent + "txtMisc4").value)) {
                            alert("Please Enter Show Cause Remark");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "chkcautionltr").checked == true) {
                if (document.getElementById(strContent + "txtMisc1").disabled == false) {
                    if (document.getElementById(strContent + "txtMisc1") != null) {
                        if (isEmpty(document.getElementById(strContent + "txtMisc1").value)) {
                            alert("Please Enter Caution Remark");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "chkwarningltr").checked == true) {
                if (document.getElementById(strContent + "txtMisc2").disabled == false) {
                    if (document.getElementById(strContent + "txtMisc2") != null) {
                        if (isEmpty(document.getElementById(strContent + "txtMisc2").value)) {
                            alert("Please Enter Warning Remark");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "chkterminationltr").checked == true) {
                if (document.getElementById(strContent + "txtMisc3").disabled == false) {
                    if (document.getElementById(strContent + "txtMisc3") != null) {
                        if (isEmpty(document.getElementById(strContent + "txtMisc3").value)) {
                            alert("Please Enter Termination Remark");
                            return false;
                        }
                    }
                }
            }
        }
        //Added start By sanoj 05-01-2022
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
        function IsFutureDateExprience(dateVal) {
            var today = new Date().getTime(),
                dateVal = dateVal.split("/");

            dateVal = new Date(dateVal[2], dateVal[1] - 1, dateVal[0]).getTime();
            if ((today - dateVal) < 0) {
                alert("Tenure To Date should notbe a future date");
                return 0;
            }
            else {

                return 1;
            }

        }
        function IsFutureDateExprience(dateVal) {
            var today = new Date().getTime(),
                dateVal = dateVal.split("/");

            dateVal = new Date(dateVal[2], dateVal[1] - 1, dateVal[0]).getTime();
            if ((today - dateVal) < 0) {
                alert("Tenure From Date should notbe a future date");
                return 0;
            }
            else {

                return 1;
            }

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
                alert("Minimum Entry Age should be 18 years");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                return "0";
            }
            else {
                return "1";
            }
        }
        function DateValidation(args1, argsID) {
            debugger;
            var Splitargs1 = args1.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var RegDate = new Date(args1);//BeginYear,BeginMonth-1,1);
            var BeginDate1 = args1;
            var TodayDate = new Date();

            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID).focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }
            return 0;
        }
        function isEmpty(str) {
            if ((str == null) || (str == "") || (str == " "))
                return true;
            return false;
        }
        function funValidatePannel1() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "cboagnTitle") != null) {
                if (document.getElementById(strContent + "cboagnTitle").disabled == false) {
                    debugger;
                    if (document.getElementById(strContent + "cboagnTitle").selectedIndex == 0) {
                        alert("Please select Prefix.");
                        document.getElementById(strContent + "cboagnTitle").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "txtAgntName") != null) {
                if (isEmpty(document.getElementById(strContent + "txtAgntName").value)) {
                    alert("Please Enter Member Name");
                    document.getElementById(strContent + "txtAgntName").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtPanNo") != null) {
                if (isEmpty(document.getElementById(strContent + "txtPanNo").value)) {
                    alert("Please Enter Pan Number");
                    //document.getElementById(strContent + "txtPanNo").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtPanNo") != null) {
                //if (document.getElementById(strContent + "txtPanNo").disabled == false) {
                if (document.getElementById(strContent + "txtPanNo").value != "") {
                    if (document.getElementById(strContent + "hdnPan") != null) {
                        if (document.getElementById(strContent + "hdnPan").value != "1") {
                            alert("Please Verify PAN Number");
                            //document.getElementById(strContent + "txtPanNo").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
                }
                // }
            }



            //if (document.getElementById(strContent + "ddlGender") != null) {
            //    if (document.getElementById(strContent + "ddlGender").disabled == false) {
            //        if (document.getElementById(strContent + "ddlGender").selectedIndex == 0) {
            //            alert("Please select Gender.");
            //            document.getElementById(strContent + "ddlGender").focus();
            //            RemoveLoading12();
            //            return false;
            //        }
            //    }
            //}

            //Validation added for DOB by sanoj 24-01-2022

            //added by sanoj 08062022
            if (document.getElementById(strContent + "cboagnTitle").value == "M/S") {
                debugger;
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) != "") {
                    var idate = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;
                    debugger;
                    dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;

                    if (IsFutureDateMS(idate) == 0) {

                        return false;
                    }
                }
            }
            function IsFutureDateMS(dateVal) {
                var today = new Date().getTime(),
                    dateVal = dateVal.split("/");

                dateVal = new Date(dateVal[2], dateVal[1] - 1, dateVal[0]).getTime();
                if ((today - dateVal) < 0) {
                    alert("Date should not be a future date");
                    return 0;
                }
                else {

                    return 1;
                }

            }
            //ended by sanoj 08062022


            //added by sanoj 02062022
            if (document.getElementById(strContent + "cboagnTitle").value != "M/S") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value) == "") {
                    alert("Please Enter Date of Birth");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                    return false;
                }
                else {
                    var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").value;
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

                    if (yrCount < 18 || yrCount >= 72) {//if (yrCount < 18) {

                        alert("Age must be between 18 to 70 years!");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                        return false;
                    }


                }


                //Validation end for DOB by sanoj 24-01-2022
                //added by ajay start 20-05-2022
                if (document.getElementById(strContent + "ddlGender") != null) {
                    if (document.getElementById(strContent + "ddlGender").disabled == false) {
                        if (document.getElementById(strContent + "ddlGender").selectedIndex == 0) {
                            alert("Please select Gender.");
                            document.getElementById(strContent + "ddlGender").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
                }

                if (document.getElementById(strContent + "cboMaritalStatus") != null) {
                    if (document.getElementById(strContent + "cboMaritalStatus").disabled == false) {
                        if (document.getElementById(strContent + "cboMaritalStatus").selectedIndex == 0) {
                            alert(document.getElementById(strContent + "hdnmarsts").value);
                            document.getElementById(strContent + "cboMaritalStatus").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
                }

                if (document.getElementById(strContent + "ddlEducutn") != null) {
                    if (document.getElementById(strContent + "ddlEducutn").disabled == false) {
                        if (document.getElementById(strContent + "ddlEducutn").selectedIndex == 0) {
                            alert("Please select Education.");
                            document.getElementById(strContent + "ddlEducutn").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
                }

            }
            //ended by sanoj 02062022


            //added by ajay end 20-05-2022



            //Added by sanoj for annivarsry date  on 05-01-2022
            //commented by ajay 19-05-2022
            //if (document.getElementById("ctl00_ContentPlaceHolder1_cboMaritalStatus").value == "M") {

            //     if (SpaceTrim(document.getElementById(strContent + "TxtAnnivrsryDt").value) == "") {

            //         alert("Please Enter Anniversary Date");
            //         document.getElementById("ctl00_ContentPlaceHolder1_TxtAnnivrsryDt").focus();

            //         return false;
            //     }
			//aded by sanoj 07-06-2022
			if(document.getElementById("ctl00_ContentPlaceHolder1_TxtAnnivrsryDt") != null)
			{
				if (SpaceTrim(document.getElementById(strContent + "TxtAnnivrsryDt").value) != "") {
					var idate = document.getElementById("ctl00_ContentPlaceHolder1_TxtAnnivrsryDt").value;
					debugger;
					dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;
					if (IsFutureDate(idate) == 0) {
						return false;
					}
				}
			} 
            //ended by sanoj 07-06-2022
            // }

            //ended by sanoj 
            //commented by ajay 19-05-2022



            //     if(document.getElementById(strContent + "txtHomeTel") != null)// comented by sanoj 20-02-2022
            //{
            //       var alphaExp =",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            //       var strContent = "ctl00_ContentPlaceHolder1_";
            //       var HomeTel = document.getElementById(strContent + "txtHomeTel").value;

            //    if(isEmpty(document.getElementById(strContent + "txtHomeTel").value))
            //    {
            //        alert(document.getElementById(strContent + "hdnHomeTel").value);
            //        document.getElementById(strContent + "txtHomeTel").focus();
            //        RemoveLoading12();
            //           return false;
            //    }
            //       else if(HomeTel.length != 11)
            //       {
            //           alert("Home Tel (with STD) should be 11 digit.");
            //           RemoveLoading12();
            //           return false;
            //       }
            //       }

            // //Validation for Email.1 and Email.2
            //if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
            //    alert("Email No.1 is Mandatory");
            //    document.getElementById(strContent + "txtemail").focus();
            //   // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            //else {


            //    var emailid = (document.getElementById(strContent + "txtemail").value);
            //    if (validateEmail1(emailid) == 0) {
            //        return false;
            //    }
            //}




            //  if(document.getElementById(strContent + "txtHomeTel") != null)// comented by sanoj 20-02-2022
            //{

            //       var strContent = "ctl00_ContentPlaceHolder1_";
            //       var HomeTel = document.getElementById(strContent + "txtHomeTel").value;

            //    if(isEmpty(document.getElementById(strContent + "txtHomeTel").value))
            //    {
            //        alert(document.getElementById(strContent + "hdnHomeTel").value);
            //        document.getElementById(strContent + "txtHomeTel").focus();
            //        RemoveLoading12();
            //           return false;
            //    }
            //       else if(HomeTel.length != 10)
            //       {
            //           alert("Home Tel  should be 10 digit.");
            //           RemoveLoading12();
            //           return false;
            //       }
            //       }

            if (document.getElementById(strContent + "txtMobileTel") != null) {
                if (isEmpty(document.getElementById(strContent + "txtMobileTel").value)) {
                    alert("Please Enter Mobile No.1");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    return false;
                }
                else {
                    var Mobile1 = (document.getElementById(strContent + "txtMobileTel").value);
                    if (Mobile1.length != 10) {
                        alert("Mobile No.1 Should be 10 digit");
                        document.getElementById(strContent + "txtMobileTel").focus();
                        return false;
                    }
                }
                if (Mobile1.substr(0, 1) == "1" || Mobile1.substr(0, 1) == "2" || Mobile1.substr(0, 1) == "3"
                    || Mobile1.substr(0, 1) == "4" || Mobile1.substr(0, 1) == "5") {
                    alert("Mobile No.1 Should Start With (6,7,8,9)");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    return false;

                }
            }

            //mobile2
            if ((document.getElementById(strContent + "txtMobileTel2").value) != "") {
                if ((document.getElementById(strContent + "txtMobileTel2").value) != "") {
                    var Mobile2 = (document.getElementById(strContent + "txtMobileTel2").value);
                    if (Mobile2.length != 10) {
                        alert("Mobile No.2 Should be 10 digit");
                        document.getElementById(strContent + "txtMobileTel2").focus();
                        return false;
                    }
                }
                if (Mobile2.substr(0, 1) == "1" || Mobile2.substr(0, 1) == "2" || Mobile2.substr(0, 1) == "3"
                    || Mobile2.substr(0, 1) == "4" || Mobile2.substr(0, 1) == "5") {
                    alert("Mobile No.2 Should Start With (6,7,8,9)");
                    document.getElementById(strContent + "txtMobileTel2").focus();
                    return false;
                }
            }





            if (SpaceTrim(document.getElementById(strContent + "txtEmail").value) == "") {
                alert("Email1 is mandatory.");
                document.getElementById(strContent + "txtEmail").focus();
                return false;
            }
            else {
                debugger;
                var emailid = (document.getElementById(strContent + "txtEmail").value);
                if (validateEmail(emailid) == 0) {
                    return false;
                }
            }
            //Validation for Email2
            if (SpaceTrim(document.getElementById(strContent + "txtEmail2").value) != "") {
                var emailid = (document.getElementById(strContent + "txtEmail2").value);
                if (validateEmail3(emailid) == 0) {
                    return false;
                }
            }

            //Validate Home Tel1

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtHomeTel").value) != "") {

                var HomeTel = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtHomeTel").value);
                if (HomeTel.length != 10) {

                    alert("Home Tel (with STD) should be 10 digit");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtHomeTel").focus();

                    return false;
                }

                if ((HomeTel.substr(0, 1)) == "0") {
                    alert("Home Tel (with STD) should not start with 0");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtHomeTel").focus();

                    return false;
                }
            }
            //Validate office Tel
            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtWorkTel").value) != "") {

                var HomeTel = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtWorkTel").value);
                if (HomeTel.length != 10) {

                    alert("Office Tel (with STD) should be 10 digit");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtWorkTel").focus();

                    return false;
                }

                if ((HomeTel.substr(0, 1)) == "0") {
                    alert("Office Tel (with STD) should not start with 0");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtWorkTel").focus();

                    return false;
                }
            }


            if (document.getElementById(strContent + "txtAddrP1") != null) {
                if (isEmpty(document.getElementById(strContent + "txtAddrP1").value)) {
                    alert(document.getElementById(strContent + "hdnResAddr").value);
                    document.getElementById(strContent + "txtAddrP1").focus();
                    RemoveLoading12();
                    return false;
                }
            }



            if (document.getElementById(strContent + "ddlState").selectedIndex == 0) {
                alert("Please select State.");
                document.getElementById(strContent + "ddlState").focus();
                RemoveLoading12();
                return false;
            }



            if (document.getElementById(strContent + "txtStateCodeP") == null) {
                alert('ajay')
                if (isEmpty(document.getElementById(strContent + "txtStateCodeP").value)) {
                    alert(document.getElementById(strContent + "hdnStateP").value);
                    document.getElementById(strContent + "txtStateCodeP").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            //commented by ajay 19-05-2022 start
            //if (document.getElementById(strContent + "txtAddrP2") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtAddrP2").value)) {
            //        alert("Please Enter Address 2");
            //        document.getElementById(strContent + "txtAddrP2").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}
            //commented by ajay 19-05-2022 end
            if (document.getElementById(strContent + "txtDistP") != null) {
                if (isEmpty(document.getElementById(strContent + "txtDistP").value)) {
                    alert(document.getElementById(strContent + "hdnDistrP").value);
                    document.getElementById(strContent + "txtDistP").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            //commented by ajay 19-05-2022 start
            //if (document.getElementById(strContent + "txtAddrP3") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtAddrP3").value)) {
            //        alert("Please Enter Address 3");
            //        document.getElementById(strContent + "txtAddrP3").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}
            //commented by ajay 19-05-2022 end
            if (document.getElementById(strContent + "txtPinP") != null) {
                if (isEmpty(document.getElementById(strContent + "txtPinP").value)) {
                    alert(document.getElementById(strContent + "hdnPinP").value);
                    document.getElementById(strContent + "txtPinP").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtCountryCodeP") != null) {
                if (isEmpty(document.getElementById(strContent + "txtCountryCodeP").value)) {
                    alert(document.getElementById(strContent + "hdnCntryCP").value);
                    document.getElementById(strContent + "txtCountryCodeP").focus();
                    RemoveLoading12();
                    return false;
                }
            }



        }
        //adde by sanoj date validation
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
        //end
        //Added by sanoj Email validation
        function validateEmail(Email1) {
            debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email1.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return 0;
            }

            return 1;

        }
        function validateEmail1(sEmail1) {
            debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail1.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtNomEmail").focus();
                return 0;
            }

            return 1;

        }
        function validateEmail3(Email3) {
            //debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email3.match(reEmail)) {
                alert("Please Enter Valid Email-2 Address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail2").focus();
                return 0;
            }

            return 1;

        }

        //ended by sanoj Email validation
        function funValidatePannel2() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            //VAlidation for pannel2 Bussiness
           if (document.getElementById(strContent + "txtExpt1").selectedIndex == 0)
            {
                    alert("Please select expected monthly business");
                    document.getElementById(strContent + "txtExpt1").focus();
                    RemoveLoading12();
                    return false;
            }
            if (document.getElementById(strContent + "txtExpectTm") != null) {
                if (isEmpty(document.getElementById(strContent + "txtExpectTm").value)) {
                    alert("Please Enter Expected Team Strength");
                    document.getElementById(strContent + "txtExpectTm").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtAgntMonth") != null) {
                if (isEmpty(document.getElementById(strContent + "txtAgntMonth").value)) {
                    alert("Please Enter Agents(In 6 Month)");
                    document.getElementById(strContent + "txtAgntMonth").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtAgntMonth12") != null) {
                if (isEmpty(document.getElementById(strContent + "txtAgntMonth12").value)) {
                    alert("Please Enter Agents(In 12 Month)");
                    document.getElementById(strContent + "txtAgntMonth12").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtPosp6") != null) {
                if (isEmpty(document.getElementById(strContent + "txtPosp6").value)) {
                    alert("Please Enter POSP(In 6 Month)");
                    document.getElementById(strContent + "txtPosp6").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtPosp12") != null) {
                if (isEmpty(document.getElementById(strContent + "txtPosp12").value)) {
                    alert("Please Enter POSP(In 12 Month)");
                    document.getElementById(strContent + "txtPosp12").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            //if (document.getElementById(strContent + "txtDtlsExtBus") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtDtlsExtBus").value)) {
            //        alert("Please Enter Details of existing and any other business ");
            //        document.getElementById(strContent + "txtDtlsExtBus").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}
            //if (document.getElementById(strContent + "txtmrktBus") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtmrktBus").value)) {
            //        alert("Please Enter 	Whether involved in Multi level Marketing in financial service business ");
            //        document.getElementById(strContent + "txtmrktBus").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}
            //if (document.getElementById(strContent + "txtSrcProvd") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtSrcProvd").value)) {
            //        alert("Please Enter Details of law suits against or initiated by Service Provider");
            //        document.getElementById(strContent + "txtSrcProvd").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}
            //if (document.getElementById(strContent + "txtAsnmnet") != null) {
            //    if (isEmpty(document.getElementById(strContent + "txtAsnmnet").value)) {
            //        alert("Please Enter	Details of other assignment(employment)");
            //        document.getElementById(strContent + "txtAsnmnet").focus();
            //        RemoveLoading12();
            //        return false;
            //    }
            //}


            if (document.getElementById(strContent + "txtTenurFrom") != null) {
                var idate = document.getElementById("ctl00_ContentPlaceHolder1_txtTenurFrom").value;
                debugger;
                dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;

                if (IsFutureDateExprience(idate) == 0) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtTenurFrom").focus();
                    return false;
                }

            }


            if (document.getElementById(strContent + "txttenur2") != null) {
                var idate = document.getElementById("ctl00_ContentPlaceHolder1_txttenur2").value;
                debugger;
                dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;

                if (IsFutureDateExprience(idate) == 0) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txttenur2").focus();
                    return false;
                }

            }
        }
        //Added start By sanoj 05-01-2021
        //Added by sanoj
        function funValidatePannel4() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "txtBankHolderName") != null) {
                if (isEmpty(document.getElementById(strContent + "txtBankHolderName").value)) {
                    alert("Please Enter Account Holder Name");
                    document.getElementById(strContent + "txtBankHolderName").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            //Bank Account No
            if (SpaceTrim(document.getElementById(strContent + "txtBankAccNo").value) == "") {
                alert("Please Enter Bank Account No");
                document.getElementById(strContent + "txtBankAccNo").focus();
                RemoveLoading12();
                return false;
            }

            //Bank IFSC Code
            if (SpaceTrim(document.getElementById(strContent + "txtNeftCode").value) == "") {
                alert("Please Enter Bank IFSC code");
                document.getElementById(strContent + "txtNeftCode").focus();
                RemoveLoading12();
                return false;
            }
            else {
                debugger;
                var ifsc = document.getElementById(strContent + "txtNeftCode").value;
                // var reg = /[A-Z|a-z]{4}[0-9]{7}$/;

                var reg = /[A-Za-z]{4}[A-Za-z0-9]{7}$/;

                if (!ifsc.match(reg)) {

                    //document.getElementById("ctl00_ContentPlaceHolder1_spanifsccode").style.display = "block";
                    alert("Please Enter Correct Bank IFSC code");
                    return false;

                }
            }


            // ended by usha

            //Bank Name
            if (SpaceTrim(document.getElementById(strContent + "txtBankName").value) == "") {
                alert("Please Enter Bank Name");
                document.getElementById(strContent + "txtBankName").focus();
                RemoveLoading12();
                return false;
            }
            if (document.getElementById(strContent + "txtBnkAddress") != null) {
                if (isEmpty(document.getElementById(strContent + "txtBnkAddress").value)) {
                    alert("Please Enter Bank Address");
                    document.getElementById(strContent + "txtBnkAddress").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            //Bank Account Type
            if (document.getElementById(strContent + "ddlactype").selectedIndex == 0) {
                alert("Please select Account type");
                document.getElementById(strContent + "ddlactype").focus();
                RemoveLoading12();
                return false;
            }
//added by ajay 28042023

 if (document.getElementById("ctl00_ContentPlaceHolder1_txtmcrcode").value != "") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtmcrcode").value.length != 9) {
                    alert("MICR Code Should be 9 Digit.");
                    return false;
                }
            }
            //Bank MICR Code
            //if (SpaceTrim(document.getElementById(strContent + "txtmcrcode").value) == "") {
            //    alert("Please Enter bank MICR code");
            //    document.getElementById(strContent + "txtmcrcode").focus();
            //    return false;
            //}

            //validation Nominee Detail
            if (document.getElementById("<%=Chknominee.ClientID %>").checked == true) {
                if (SpaceTrim(document.getElementById(strContent + "txtNomNme").value) == "") {
                    alert("Please Enter Nominee Name");
                    document.getElementById(strContent + "txtNomNme").focus();
                    return false;
                }
                //if (SpaceTrim(document.getElementById(strContent + "txtNomDob").value) == "") {
                //    alert("Please Enter Date of Birth");
                //    document.getElementById(strContent + "txtNomDob").focus();
                //    return false;
                //}
                //Validation added for DOB by sanoj 24-01-2022

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtNomDob").value) == "") {
                    alert("Please Enter Date of Birth");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtNomDob").focus();
                    return false;
                }
                else {
                    var strDOB = document.getElementById("ctl00_ContentPlaceHolder1_txtNomDob").value;
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
                        document.getElementById("ctl00_ContentPlaceHolder1_txtNomDob").focus();
                        return false;
                    }


                }
                //Validation ended for DOB by sanoj 24-01-2022
                if (SpaceTrim(document.getElementById(strContent + "txtNomMob").value) == "") {
                    alert("Please Enter Mobile No");
                    document.getElementById(strContent + "txtNomMob").focus();
                    return false;
                }
                else {
                    var mob = (document.getElementById(strContent + "txtNomMob").value);
                    if (mob.length != 10) {
                        alert("Mobile No Should Be 10 Digit");
                        return false;
                    }
                    if (mob.substr(0, 1) == "1" || mob.substr(0, 1) == "2" || mob.substr(0, 1) == "3"
                        || mob.substr(0, 1) == "4" || mob.substr(0, 1) == "5") {
                        alert("Mobile No. Should Start With (6,7,8,9)");
                        document.getElementById(strContent + "txtNomMob").focus();
                        return false;

                    }

                }

                //if (SpaceTrim(document.getElementById(strContent + "txtNomEmail").value) == "") {
                //    alert("Please Enter Email");
                //    document.getElementById(strContent + "txtNomEmail").focus();
                //    return false;
                //}
                if (SpaceTrim(document.getElementById(strContent + "txtNomEmail").value) == "") {
                    alert("Email is mandatory.");
                    document.getElementById(strContent + "txtNomEmail").focus();
                    return false;
                }
                else {
                    debugger;
                    var emailid = (document.getElementById(strContent + "txtNomEmail").value);
                    if (validateEmail1(emailid) == 0) {
                        return false;
                    }
				}
            if (document.getElementById(strContent + "ddlNomnRel").selectedIndex == 0) {
                alert("Please select Nominee Relationship");
                document.getElementById(strContent + "ddlNomnRel").focus();
                return false;
            }
            }
        }
        function funValidate() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";







        //Added by swapnesh on 15/01/2014 to add mandatory fields start
   //     if(document.getElementById(strContent + "txtEmail") != null)
   //     {
   //         if(isEmpty(document.getElementById(strContent + "txtEmail").value))
			//{
			//	alert(document.getElementById(strContent + "hdnemail1").value);
			//	document.getElementById(strContent + "txtEmail").focus();
			//	RemoveLoading12();
			//    return false;
			//}
   //     }

        //Added by swapnesh on 15/01/2014 to add mandatory fields end
      <%--  if(document.getElementById(strContent + "txtMobileTel") != null)
	        {
                var reg = new RegExp('^[0-9]+$');
	            if(isEmpty(document.getElementById(strContent + "txtMobileTel").value))
	            {
	                alert(document.getElementById(strContent + "hdnMobTel").value);
	                document.getElementById(strContent + "txtMobileTel").focus();
	                RemoveLoading12();
	                return false;
	            }
                
                else
                {
                   if (reg.test(document.getElementById(strContent + "txtMobileTel").value))
                    {
                    var MobNo = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
                   var mobile = document.getElementById(strContent + "txtMobileTel").value;
                   if(MobNo.length != 11)
                   {
                        alert("Mobile Tel (with STD) should be 11 digit.");
                        document.getElementById(strContent + "txtMobileTel").focus();
                        RemoveLoading12();
                        return false;
                   }
                   else if(mobile.length == 11)
                   {
                        
                        if((mobile.substr(0,1)) != "0")
                        {
                            alert("Mobile Number should start with 0");
                            document.getElementById(strContent + "txtMobileTel").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
               }
              }
	        }--%>
            ////debugger;
            //   if(document.getElementById(strContent + "txtPager") != null)
            //{
            //       var alphaExp =",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            //       var strContent = "ctl00_ContentPlaceHolder1_";
            //       var pagerno = document.getElementById(strContent + "txtPager").value;
            //       if(document.getElementById(strContent + "txtPager").value != ""){
            //       if(pagerno.length != 11)
            //       {
            //           alert("Pager No should be 11 digit.");
            //           RemoveLoading12();
            //           return false;
            //       }
            //       }
            //}
            //   if(document.getElementById(strContent + "txtFax") != null)
            //{
            //       var alphaExp =",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            //       var strContent = "ctl00_ContentPlaceHolder1_";
            //       var fax = document.getElementById(strContent + "txtFax").value;
            //       if(document.getElementById(strContent + "txtFax").value != ""){
            //       if(fax.length != 11)
            //       {
            //           alert("Fax No should be 11 digit.");
            //           RemoveLoading12();
            //           return false;
            //       }
            //       }
            //}
            if (document.getElementById(strContent + "ddlSlsChannel") != null) {
                if (document.getElementById(strContent + "ddlSlsChannel").disabled == false) {
                    if (document.getElementById(strContent + "ddlSlsChannel").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID250").value);
                        document.getElementById(strContent + "ddlSlsChannel").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlChnCls") != null) {
                if (document.getElementById(strContent + "ddlChnCls").disabled == false) {
                    if (document.getElementById(strContent + "ddlChnCls").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value);
                        document.getElementById(strContent + "ddlChnCls").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
            }
            ////debugger;
            var list = document.getElementById('<%= rdbChnlTyp.ClientID %>'); //Client ID of the radiolist
            var inputs = list.getElementsByTagName("input");
            var selected;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    selected = inputs[i];
                    break;
                }
            }
            if (!selected) {
                //Added: Parag @ 04042014
                var radioId = document.getElementById('<%= rdbChnlTyp.ClientID %>');
                alert('Please Choose Hierarchy, as either Company or Channel.')
                document.getElementById(strContent + "rdbChnlTyp").focus();
                RemoveLoading12();
                return false;
            }

            if (document.getElementById(strContent + "ddlAgntType") != null) {
                if (document.getElementById(strContent + "ddlAgntType").selectedIndex == 0) {
                    alert("Please select member type");
                    //document.getElementById(strContent + "ddlAgntType").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlLicTyp") != null) {
                if (document.getElementById(strContent + "ddlLicTyp").selectedIndex == 0) {
                    alert("Please select Member Entity");
                    //document.getElementById(strContent + "ddlLicTyp").focus();
                    RemoveLoading12();
                    return false;
                }
            }

<%--            if (document.getElementById(strContent + "hdnPriMandatory") != null) {
                if (document.getElementById(strContent + "hdnPriMandatory").value != "") {
                    if (document.getElementById(strContent + "hdnPriMandatory").value == "True") {
                        if (document.getElementById("<% =ddlamrptdesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlambasedondesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlamchnldesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlamsubchnldesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddllvlagttype.ClientID %>").selectedIndex == 0
                            // || document.getElementById(strContent + "txtRptMgr").value == ""
                        ) {
                            alert("Please Fill Primary Reporting Details");
                            RemoveLoading12();
                            return false;
                        }
                    }
                }
            }--%>
            if (document.getElementById(strContent + "hdnPriMandatory") != null) {
				if (document.getElementById(strContent + "hdnPriMandatory").value != "") {
<%--					var e = document.getElementById("<% =ddllvlagttype.ClientID %>");
					var value = e.value;
					var text = e.options[e.selectedIndex].text;--%>
                    if (document.getElementById(strContent + "hdnPriMandatory").value == "True") {
                        if (document.getElementById("<% =ddlamrptdesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlambasedondesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlamchnldesc.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlamsubchnldesc.ClientID %>").selectedIndex == 0 
                        <%--document.getElementById("<% =ddllvlagttype.ClientID %>").selectedIndex == 0--%>
                            // || document.getElementById(strContent + "txtRptMgr").value == ""
                        ) {
							//alert("Please Fill Primary Reporting Details");
							alert("Please fill Parental Reporting Details");
                            RemoveLoading12();
                            return false;
                        }
                    }
                }
            }
            //
            //Modified: Parag
            if (document.getElementById("<%=lblVw1AgntType.ClientID %>").innerHTML != "Vendor Type") {
                if (document.getElementById(strContent + "txtUntCode") != null) {
                    //                if(isEmpty(document.getElementById(strContent + "txtUntCode").value))
                    //			    {
                    //				    alert("Please Enter Unit Code");
                    //				    document.getElementById(strContent + "txtUntCode").focus();
                    //				    RemoveLoading12();
                    //			        return false;
                    //			    }
                }
            }
            //Modified: END

            //Comented by sanoj10-01-2022
            //  if(document.getElementById(strContent + "txtAddrP1") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtAddrP1").value))
            //{
            // alert(document.getElementById(strContent + "hdnResAddr").value);
            // document.getElementById(strContent + "txtAddrP1").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtStateCodeP") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtStateCodeP").value))
            //{
            // alert(document.getElementById(strContent + "hdnStateP").value);
            // document.getElementById(strContent + "txtStateCodeP").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtDistP") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtDistP").value))
            //{
            // alert(document.getElementById(strContent + "hdnDistrP").value);
            // document.getElementById(strContent + "txtDistP").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtPinP") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtPinP").value))
            //{
            // alert(document.getElementById(strContent + "hdnPinP").value);
            // document.getElementById(strContent + "txtPinP").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtCountryCodeP") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtCountryCodeP").value))
            //{
            // alert(document.getElementById(strContent + "hdnCntryCP").value);
            // document.getElementById(strContent + "txtCountryCodeP").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtPermAdd1") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtPermAdd1").value))
            //{
            // alert(document.getElementById(strContent + "hdnPermAddr").value);
            // document.getElementById(strContent + "txtPermAdd1").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtStateCode") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtStateCode").value))
            //{
            // alert(document.getElementById(strContent + "hdnStatePrm").value);
            // document.getElementById(strContent + "txtStateCode").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtPermPostcode") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtPermPostcode").value))
            //{
            // alert(document.getElementById(strContent + "hdnPinPrm").value);
            // document.getElementById(strContent + "txtPermPostcode").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }

            //  if(document.getElementById(strContent + "txtPermCountryCode") != null)
            //  {
            //      if(isEmpty(document.getElementById(strContent + "txtPermCountryCode").value))
            //{
            // alert(document.getElementById(strContent + "hdnCntryCPrm").value);
            // document.getElementById(strContent + "txtPermCountryCode").focus();
            // RemoveLoading12();
            // return false;
            //}
            //  }
            //Comented End by sanoj10-01-2022
            //Added by sanoj 10-01-2022
            // End by sanoj10-01-2022
            //Added by swapnesh on 15/01/2014 to add mandatory fields start
            if (document.getElementById("ctl00_ContentPlaceHolder1_divPClient") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_divPClient").style.display == "block") {
                    if (document.getElementById(strContent + "txtDOB") != null) {
                        if (isEmpty(document.getElementById(strContent + "txtDOB").value)) {
                            alert(document.getElementById(strContent + "hdnCltDOB").value);
                            document.getElementById(strContent + "txtDOB").focus();
                            RemoveLoading12();
                            return false;
                        }
                    }
                    ////
                    //   if(document.getElementById(strContent + "cboMaritalStatus") != null)
                    //{
                    //       if(document.getElementById(strContent + "cboMaritalStatus").disabled == false)
                    //       {
                    //           if(document.getElementById(strContent + "cboMaritalStatus").selectedIndex == 0)
                    //           {
                    //               alert(document.getElementById(strContent + "hdnmarsts").value);
                    //               document.getElementById(strContent + "cboMaritalStatus").focus();
                    //               RemoveLoading12();
                    //               return false;
                    //           }
                    //       }
                    //   }

                    if (document.getElementById(strContent + "cboOtherIDType") != null) {
                        if (document.getElementById(strContent + "cboOtherIDType").value != "") {
                            if (document.getElementById(strContent + "txtOthersID").value == "") {
                                alert("Please Enter Alternate ID No.")
                                RemoveLoading12();
                                return false;
                            }
                        }
                    }
                }
            }

            //Added by swapnesh on 15/01/2014 to add mandatory fields end
            if (document.getElementById(strContent + "txtCusmId") != null) {
                if (isEmpty(document.getElementById(strContent + "txtCusmId").value)) {
                    alert("Please Enter Customer ID");
                    document.getElementById(strContent + "txtCusmId").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            ////debugger;
            if (document.getElementById(strContent + "txtBizOldLicNo") != null) {
                if (document.getElementById(strContent + "txtBizOldLicStrtDt").value != "" ||
                    document.getElementById(strContent + "txtBizOldLicExpDt").value != "" ||
                    document.getElementById(strContent + "txtBizOldLicNo").value != "") {
                    if (document.getElementById(strContent + "txtBizOldLicStrtDt").value == "" ||
                        document.getElementById(strContent + "txtBizOldLicExpDt").value == "" ||
                        document.getElementById(strContent + "txtBizOldLicNo").value == "") {
                        alert("Please Enter Old License Details.");
                        RemoveLoading12();
                        return false;
                    }
                }
            }


            if (document.getElementById(strContent + "txtBizLicNo") != null) {
                if (isEmpty(document.getElementById(strContent + "txtBizLicNo").value)) {
                    alert("Please Enter Biz License No.");
                    document.getElementById(strContent + "txtBizLicNo").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtBizLicEndDt") != null) {
                if (isEmpty(document.getElementById(strContent + "txtBizLicEndDt").value)) {
                    alert("Please Enter Biz License Expiry Date");
                    RemoveLoading12();
                    return false;
                }
            }

            if (!CompareWith2DayLicExp()) {
                return false;
            }

            if (document.getElementById("ctl00_ContentPlaceHolder1_divCClient").style.display == "block") {
                if (document.getElementById(strContent + "cboTitle") != null) {
                    if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnTitle").value);
                        document.getElementById(strContent + "cboTitle").focus();
                        RemoveLoading12();
                        return false;
                    }
                }

                if (document.getElementById(strContent + "txtSurname") != null) {
                    if (isEmpty(document.getElementById(strContent + "txtSurname").value)) {
                        alert(document.getElementById(strContent + "hdnName").value);
                        document.getElementById(strContent + "txtSurname").focus();
                        RemoveLoading12();
                        return false;
                    }
                }

                if (document.getElementById(strContent + "txtCapital") != null) {
                    if (isEmpty(document.getElementById(strContent + "txtCapital").value)) {
                        alert(document.getElementById(strContent + "hdnCapital").value);
                        document.getElementById(strContent + "txtCapital").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
            }
            ///debugger;
            //IsCmpStaff in ChnMemSu table 1 for Mandatory and 0 for Non Mandatory      
            //    if(document.getElementById(strContent + "hdnEMPCode").value == "Y")
            //     {       
            //     if(isEmpty(document.getElementById(strContent + "txtSAPcode").value))
            //{
            //             alert("Please enter SAP Code");
            //             document.getElementById(strContent + "txtSAPcode").focus();
            //             RemoveLoading12();
            //    return false;  
            //}      
            //     }
            if (document.getElementById(strContent + "txtEmpCode") != null) {
                var sString = document.getElementById("ctl00_ContentPlaceHolder1_txtEmpCode").getAttribute("value");
                //Check for invalid characters
                var iChars = "#%!@&$^*_+={}[]|\:;?><,.'~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                for (var i = 0; i < sString.length; i++) {
                    if (iChars.indexOf(sString.charAt(i)) != -1) {
                        alert("Invalid Characters");
                        document.getElementById(strContent + "txtEmpCode").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "txtdoj_txtDate") != null) {
                if (isEmpty(document.getElementById(strContent + "txtdoj_txtDate").value)) {
                    alert("Please Enter Date Of Joining");
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlAcadQual") != null) {
                if (isEmpty(document.getElementById(strContent + "ddlAcadQual").value)) {
                    alert("Please choose education level");
                    document.getElementById(strContent + "ddlAcadQual").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtNoOfChild") != null) {
                if (!isEmpty(document.getElementById(strContent + "txtNoOfChild").value) && !chkIntegerRange(document.getElementById(strContent + "txtNoOfChild").value, 0, 10, 1)) {
                    alert(document.getElementById(strContent + "hdnID380").value);
                    document.getElementById(strContent + "txtNoOfChild").focus();
                    RemoveLoading12();
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtFamilyCnt") != null) {
                if (!isEmpty(document.getElementById(strContent + "txtFamilyCnt").value) && !chkIntegerRange(document.getElementById(strContent + "txtFamilyCnt").value, 0, 99, 1)) {
                    alert(document.getElementById(strContent + "hdnID370").value);
                    document.getElementById(strContent + "txtFamilyCnt").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtGradDate") != null) {
                var todayDate = new Date();
                var graduateDate = new Date(document.getElementById(strContent + "txtGradDate").value);
                if (graduateDate > todayDate) {
                    alert(document.getElementById(strContent + "hdnID360").value);
                    document.getElementById(strContent + "txtGradDate").focus();
                    RemoveLoading12();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtPrevEmpName1") != null) {
                if (document.getElementById(strContent + "ddlAgntLvlAchieve1").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpStatus1").selectedIndex != 0 || document.getElementById(strContent + "ddlWorkIndustry1").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpLvl1").selectedIndex != 0 || SpaceTrim(document.getElementById(strContent + "txtPrevAgntCode1").value) != "" || SpaceTrim(document.getElementById(strContent + "txtQualID1").value) != "" || SpaceTrim(document.getElementById(strContent + "txtLastIncome1").value) != "") {
                    if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName1").value) == "") {
                        alert(document.getElementById(strContent + "hdnID310").value + "- 1");
                        document.getElementById(strContent + "txtPrevEmpName1").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
                if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName1").value) != "") {
                    if (document.getElementById(strContent + "ddlVw3FromMnth1").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 1");
                        document.getElementById(strContent + "ddlVw3FromMnth1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3FromYear1").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 1");
                        document.getElementById(strContent + "txtVw3FromYear1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlVw3ToMnth1").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 1");
                        document.getElementById(strContent + "ddlVw3ToMnth1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3ToYear1").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 1");
                        document.getElementById(strContent + "txtVw3ToYear1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlWorkIndustry1").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID270").value + "- 1");
                        document.getElementById(strContent + "ddlWorkIndustry1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlEmpLvl1").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID280").value + "- 1");
                        document.getElementById(strContent + "ddlEmpLvl1").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (!chkAmountPositive(document.getElementById(strContent + "txtLastIncome1").value, 1)) {
                        return funShowAlert(strContent + "hdnID340", strContent + "txtLastIncome1");
                    }
                }
            }

            if (document.getElementById(strContent + "txtPrevEmpName2") != null) {
                if (document.getElementById(strContent + "ddlAgntLvlAchieve2").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpStatus2").selectedIndex != 0 || document.getElementById(strContent + "ddlWorkIndustry2").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpLvl2").selectedIndex != 0 || SpaceTrim(document.getElementById(strContent + "txtPrevAgntCode2").value) != "" || SpaceTrim(document.getElementById(strContent + "txtQualID2").value) != "" || SpaceTrim(document.getElementById(strContent + "txtLastIncome2").value) != "") {
                    if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName2").value) == "") {
                        alert(document.getElementById(strContent + "hdnID310").value + "- 2");
                        document.getElementById(strContent + "txtPrevEmpName2").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
                if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName2").value) != "") {
                    if (document.getElementById(strContent + "ddlVw3FromMnth2").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 2");
                        document.getElementById(strContent + "ddlVw3FromMnth2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3FromYear2").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 2");
                        document.getElementById(strContent + "txtVw3FromYear2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlVw3ToMnth2").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 2");
                        document.getElementById(strContent + "ddlVw3ToMnth2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3ToYear2").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 2");
                        document.getElementById(strContent + "txtVw3ToYear2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlWorkIndustry2").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID270").value + "- 2");
                        document.getElementById(strContent + "ddlWorkIndustry2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlEmpLvl2").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID280").value + "- 2");
                        document.getElementById(strContent + "ddlEmpLvl2").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (!chkAmountPositive(document.getElementById(strContent + "txtLastIncome2").value, 1)) {
                        return funShowAlert(strContent + "hdnID340", strContent + "txtLastIncome2");
                    }
                }
            }
            if (document.getElementById(strContent + "txtPrevEmpName3") != null) {
                if (document.getElementById(strContent + "ddlAgntLvlAchieve3").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpStatus3").selectedIndex != 0 || document.getElementById(strContent + "ddlWorkIndustry3").selectedIndex != 0 || document.getElementById(strContent + "ddlEmpLvl3").selectedIndex != 0 || SpaceTrim(document.getElementById(strContent + "txtPrevAgntCode3").value) != "" || SpaceTrim(document.getElementById(strContent + "txtQualID3").value) != "" || SpaceTrim(document.getElementById(strContent + "txtLastIncome3").value) != "") {
                    if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName3").value) == "") {
                        alert(document.getElementById(strContent + "hdnID310").value + "- 3");
                        document.getElementById(strContent + "txtPrevEmpName3").focus();
                        RemoveLoading12();
                        return false;
                    }
                }
                if (SpaceTrim(document.getElementById(strContent + "txtPrevEmpName3").value) != "") {
                    if (document.getElementById(strContent + "ddlVw3FromMnth3").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 3");
                        document.getElementById(strContent + "ddlVw3FromMnth3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3FromYear3").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 3");
                        document.getElementById(strContent + "txtVw3FromYear3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlVw3ToMnth3").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 3");
                        document.getElementById(strContent + "ddlVw3ToMnth3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (SpaceTrim(document.getElementById(strContent + "txtVw3ToYear3").value) == "") {
                        alert(document.getElementById(strContent + "hdnID260").value + "- 3");
                        document.getElementById(strContent + "txtVw3ToYear3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlWorkIndustry3").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID270").value + "- 3");
                        document.getElementById(strContent + "ddlWorkIndustry3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (document.getElementById(strContent + "ddlEmpLvl3").selectedIndex == 0) {
                        alert(document.getElementById(strContent + "hdnID280").value + "- 3");
                        document.getElementById(strContent + "ddlEmpLvl3").focus();
                        RemoveLoading12();
                        return false;
                    }
                    else if (!chkAmountPositive(document.getElementById(strContent + "txtLastIncome3").value, 1)) {
                        return funShowAlert(strContent + "hdnID340", strContent + "txtLastIncome3");
                    }
                }
            }
            if (document.getElementById(strContent + "txtPrevEmpName1") != null && document.getElementById(strContent + "txtPrevEmpName2") != null && document.getElementById(strContent + "txtPrevEmpName3") != null) {
                for (var i = 1; i < 4; i++) {
                    var BeginMonth = eval('document.getElementById(strContent + "ddlVw3FromMnth" + i).value');
                    var BeginYear = eval('document.getElementById(strContent + "txtVw3FromYear" + i).value');
                    var EndMonth = eval('document.getElementById(strContent + "ddlVw3ToMnth" + i).value');
                    var EndYear = eval('document.getElementById(strContent + "txtVw3ToYear" + i).value');
                    var BeginDate = new Date(BeginYear, BeginMonth - 1, 1);
                    var EndDate = new Date(EndYear, EndMonth - 1, 1);
                    var BeginDate1 = "1/" + BeginMonth + "/" + BeginYear;
                    var EndDate1 = "1/" + EndMonth + "/" + EndYear;
                    var PrevAgentCode = eval('document.getElementById(strContent + "txtPrevEmpName" + i).value');
                    var QualifiedID = eval('document.getElementById(strContent + "txtQualID" + i).value');

                    if (BeginMonth != '' && BeginYear != '') {

                        if (!validDate(BeginDate1, 'mm/dd/yyyy', 1, 2)) {
                            alert(document.getElementById(strContent + "hdnID380").value);
                            RemoveLoading12();
                            return false;
                        }
                    }

                    if (EndMonth != '' && EndYear != '') {
                        if (!validDate(EndDate1, 'mm/dd/yyyy', 1, 2)) {
                            alert(document.getElementById(strContent + "hdnID390").value);
                            RemoveLoading12();
                            return false;
                        }
                    }

                    if (BeginMonth != '' && BeginYear != '' && EndMonth != '' && EndYear != '') {
                        if (BeginDate > EndDate) {
                            alert(document.getElementById(strContent + "hdnID320").value);
                            RemoveLoading12();
                            return false;
                        }

                        if (BeginDate > TodayDate || EndDate > TodayDate) {
                            alert(document.getElementById(strContent + "hdnID330").value);
                            RemoveLoading12();
                            return false;
                        }
                    }

                    if (PrevAgentCode != '' && !chkCodes(PrevAgentCode, 0)) {
                        alert(document.getElementById(strContent + "hdnID400").value + i);
                        RemoveLoading12();
                        return false;
                    }

                    if (QualifiedID != '' && !chkCodes(QualifiedID, 0)) {
                        alert(document.getElementById(strContent + "hdnID410").value + i);
                        RemoveLoading12();
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "txtRecruitAgntCode") != null && document.getElementById(strContent + "txtImmLeaderCode") != null) {
                if (!chkRecruitAgt()) {
                    RemoveLoading12();
                    return false;
                }
                if (!chkDirectAgt()) {
                    RemoveLoading12();
                    return false;
                }
                if ('<%= Request.QueryString["Type"].ToString()%>' != "E") {
                    if (!CompareWith2Day()) {
                        RemoveLoading12();
                        return false;
                    }
                }

            }

            //rachana to be uncommented 1Apr 13 to check functionality of SAVE button       
            if (document.getElementById(strContent + "ddlPaymentMode") != null && document.getElementById(strContent + "ddlPayeeCatg") != null) {
                if (document.getElementById(strContent + "ddlPayeeCatg").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID620").value);
                    document.getElementById(strContent + "ddlPayeeCatg").focus();
                    RemoveLoading12();
                    return false;
                }

                if (document.getElementById(strContent + "ddlPaymentMode").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID560").value);
                    document.getElementById(strContent + "ddlPaymentMode").focus();
                    RemoveLoading12();
                    return false;
                }
                if (document.getElementById(strContent + "ddlPaymentMode").value == "HR" && SpaceTrim(document.getElementById(strContent + "txtEmpCode").value) == "") {
                    alert(document.getElementById(strContent + "hdnID630").value);
                    document.getElementById(strContent + "txtEmpCode").focus();
                    RemoveLoading12();
                    return false;
                }
                if (document.getElementById(strContent + "hdnAgntClass").value == "CS" && document.getElementById(strContent + "ddlPaymentMode").value != "HR") {
                    alert(document.getElementById(strContent + "hdnID640").value);
                    document.getElementById(strContent + "ddlPaymentMode").focus();
                    RemoveLoading12();
                    return false;
                }

                if (getRadioSelectedValue(document.getElementById("ctl00_ContentPlaceHolder1_rdTaxExmp")) == "Y") {
                    if (SpaceTrim(document.getElementById(strContent + "txtTaxExmpCertId").value) == "") {
                        return funShowAlert(strContent + "hdnID570", strContent + "txtTaxExmpCertId");
                    }
                    else {
                        if (SpaceTrim(document.getElementById(strContent + "txtTaxExmpRate").value) == "") {
                            return funShowAlert(strContent + "hdnID580", strContent + "txtTaxExmpRate");
                        }
                        else if (SpaceTrim(document.getElementById(strContent + "txtTaxExmpRate").value) == "0") {
                            return funShowAlert(strContent + "hdnID600", strContent + "txtTaxExmpRate");
                        }
                        else if (!chkPerc(SpaceTrim(document.getElementById(strContent + "txtTaxExmpRate").value))) {
                            return funShowAlert(strContent + "hdnID590", strContent + "txtTaxExmpRate");
                        }
                    }
                }


            }

        }
        //--------------------------------funValidate ENDS-------------------------------------
        function funShowAlert(objError, objFocus) {
            alert(document.getElementById(objError).value);
            document.getElementById(objFocus).focus();
            return false;
        }

        function funShowReadonly() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtSmCode") != null)
                document.getElementById("ctl00_ContentPlaceHolder1_txtSmCode").readOnly = true;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtCmpUntCode") != null)
                document.getElementById("ctl00_ContentPlaceHolder1_txtCmpUntCode").readOnly = true;
        }

        function funValidate_WelcomeLetter() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "ddlSlsChannel").value != "AG") {
                //For F2f Channel
                if ((document.getElementById(strContent + "ddlSlsChannel").value != "AD") && (document.getElementById(strContent + "ddlSlsChannel").value != "LP")
                    && (document.getElementById(strContent + "ddlSlsChannel").value != "CN") && (document.getElementById(strContent + "ddlSlsChannel").value != "PR"))//For CN / PR
                {
                    if (document.getElementById(strContent + "hdnAppRule").value == "1") {
                        if (isEmpty(document.getElementById(strContent + "txt_AppNo").value) == true) {
                            alert("Application Number Cannot be Blank");
                            document.getElementById(strContent + "txt_AppNo").focus();
                            return false;
                        }
                        if (isEmpty(document.getElementById(strContent + "txtDTJoinFrom_txtDate").value) == true) {
                            alert("Application Date Cannot be Blank");
                            document.getElementById(strContent + "txtDTJoinFrom_txtDate").focus();
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        function addlvalidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "hdnUntCode") != null) {
                if (document.getElementById(strContent + "hdnUntCode").value == "") {
                    alert("Please Select UnitCode");
                    return false;
                }
            }
        }

        function funblankRptMgr() {
            if (document.getElementById('<%=txtRptMgr.ClientID %>').value == "") {
                document.getElementById('<%=lblrptmgr.ClientID %>').innerText = "";
                document.getElementById('<%=hdnRptMgr.ClientID %>').value = "";
            }
        }

        function funblankUntCode() {
            if (document.getElementById('<%=txtUntCode.ClientID %>').value == "") {
                document.getElementById('<%=lblUnitDesc.ClientID %>').innerText = "";
                document.getElementById('<%=hdnUntCode.ClientID %>').value = "";
                document.getElementById('<%=lblUntAddr.ClientID %>').innerText = "";
            }
        }

    </script>
   <%-- <script  type="text/javascript" src="~/Scripts/common.js"></script>
    <script  type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script  type="text/javascript" src="~/Scripts/subModal.js"></script>--%>

    <style>
.clsCenter {
            text-align: center !important;
        }
 .clsLeft {
            text-align: left !important;
        }
        A {
    color: black;
    text-decoration: none;
}
        .btnsize{
            width: 43px;
            height: 34px;
        }
        .gv1{
            border:none;
        }
        .gridviewth {
       padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: left;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
    color:black;
}
		.pad{
			text-align:center !important;
		}
		.pad1{
			text-align:left !important;
		}
    </style>
     <script type="text/javascript" >
         function ShowReqDtl(divName, btnName) {

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

     </script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    
    <center>
        <div class="row">
            <div class="col-sm-12">
<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
       
        <asp:UpdatePanel ID="Updatepanel9" runat="server" >
            <ContentTemplate>
                <div id="imageContent" runat="server" class="card PanelInsideTab">
                    <asp:Image ID="ImgBasicInfo" ImageUrl="~/theme/iflow/tabs/01_Basic_Information.png" Visible="true" runat="server" Style="border-width: 0px; width: 1020px;" />
                    <asp:Image ID="ImgBusiness" ImageUrl="~/theme/iflow/tabs/02_Business_background.png" Visible="false" runat="server" Style="border-width: 0px; width: 1020px;" />
                    <asp:Image ID="ImgHierarchy" ImageUrl="~/theme/iflow/tabs/03_Sales_Hierarchy.png" Visible="false" runat="server" Style="border-width: 0px; width: 1020px;" />
                    <asp:Image ID="ImgBank" ImageUrl="~/theme/iflow/tabs/04_Bank_and_Nominee.png" Visible="false" runat="server" Style="border-width: 0px; width: 1020px;" />
                    <asp:Image ID="ImgDocumentUpload" ImageUrl="~/theme/iflow/tabs/05_Document_Upload.png" Visible="false" runat="server" Style="border-width: 0px; width: 1020px;" />
                    <asp:Image ID="ImgSummary" ImageUrl="~/theme/iflow/tabs/06_Summary.png" Visible="false" runat="server" Style="border-width: 0px; width: 1020px;" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
		   
        <div>
                    <asp:UpdatePanel ID="Updatepanel4" runat="server">
                        <ContentTemplate>
                            <div id="divPannel1"   runat="server" visible="true">
                             
                                      <div id="divpn1" class="card PanelInsideTab" runat="server" visible="true">
									<%-- <div id="Div2" runat="server" class="panelheadingAliginment">
                        <div class="row spacebetnrow">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblPersonalPart" runat="server"  CssClass="control-label HeaderColor"></asp:Label>
                            </div>
                           
                        </div>
                    </div>--%>
                  <div id="Div2" runat="server" class="panelheadingAliginment">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                      
                        <asp:Label ID="lblPersonalPart" runat="server" CssClass="control-label HeaderColor"></asp:Label>
  
                    </div>
                    <div class="col-sm-2">
                        <%--<span id="btnprsnldtlscollapse" runat="server" class="glyphicon glyphicon-collapse-down" style="float: right;
                            color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                 <span id="btnprsnldtlscollapse" class="glyphicon glyphicon-chevron-down"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','btnprsnldtlscollapse');return false;" style="float: right; padding: 1px 10px ! important; font-size: 18px; color:#00cccc"></span>

                    </div>
                </div>
            </div>
                                     <div id="divpersnldtls" runat="server" class="panel-body panelContent spacebetnrow" style="display: block">

                                         <%--1st row control start here--%>
                                        <%-- <div class="row rowspacing">
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblPrefix" runat="server" Text="Pre.Fix" CssClass="control-label labelSize"></asp:Label> 

                                               
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                <asp:Label ID="lblPanNo" runat="server"  CssClass="control-label labelSize"></asp:Label> 
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="LblMdob" runat="server" Text="DOB"   CssClass="control-label labelSize"></asp:Label> 
                                                 </div>
                                         </div>--%>
                                         <div class="row" style="text-align:left">
                                             <div class="col-sm-1">
                                                 <asp:Label ID="lblPrefix" runat="server" Text="Prefix" CssClass="control-label labelSize"></asp:Label>
                                               <asp:UpdatePanel ID="divcboagnTitle" runat="server">
                                                              <ContentTemplate>
                                                                                                                    <asp:DropDownList ID="cboagnTitle" runat="server" CssClass="form-control form-select mandatory" style="padding-left:4px"
                                                                            DataTextField="ParamDesc" DataValueField="ParamValue" AutoPostBack="true" Width="81px"
                                                                            OnSelectedIndexChanged="cboagnTitle_SelectedIndexChanged"
                                                                            AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                                                            TabIndex="5">
                                                                        </asp:DropDownList>
                                                                      <%--  <asp:RequiredFieldValidator runat="server" ID="req_title" InitialValue="none" ValidationGroup="agtValGrp" SetFocusOnError="true"
                                                                            ControlToValidate="cboagnTitle" ErrorMessage="Title Required." Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                  </ContentTemplate>
                                                             </asp:UpdatePanel>

                                                   </div>
                                             <div class="col-sm-3">
                                                  <asp:Label ID="lblAgntName" runat="server"  CssClass="control-label labelSize"></asp:Label>
                                                 <asp:TextBox ID="txtAgntName" runat="server"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                                            CssClass="form-control mandatory" MaxLength="125" TabIndex="6" ></asp:TextBox>
                                                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtAgntName" ValidChars=" " FilterMode="ValidChars">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
															

                                                                        <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                             </div>
                                             <div class="col-sm-4">
                                                   <asp:Label ID="lblPanNo" runat="server"  CssClass="control-label labelSize"></asp:Label>
                                                 <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control mandatory" MaxLength="10" onblur="myFunction();"
                                                                            onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="7"
                                                                            ></asp:TextBox>

                                             
                                                    <div id="divPAN" class="col-sm-1" style="display: none">
                                                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Spinner" />
                                                                            <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                                                        </div>
                                                  <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Panvalidate" runat="server" ControlToValidate="txtPanNo" ErrorMessage="Invalid PAN!" SetFocusOnError="true"
                                                                            ValidationExpression="^[^<>#%@!~`+$]*$" Font-Size="X-Small" Display="Dynamic"></asp:RegularExpressionValidator>
                                                 </div>
                                             <div class="col-sm-1" style="display:none">
                                                 <asp:Button ID="btnVerifyPAN" runat="server" CssClass="btn btn-success Prefix1" 
                                                                            OnClick="btnVerifyPAN_Click" OnClientClick="verifyPan();" TabIndex="8" Text="Verify"  />
                                             </div>
                                             <div class="col-sm-4">
                                                  <asp:Label ID="LblMdob" runat="server" Text="DOB"   CssClass="control-label labelSize"></asp:Label>
                                                 <asp:TextBox ID="txtDOB" runat="server" placeholder="DD/MM/YYYY" 
                                                                    CssClass="form-control mandatory"></asp:TextBox>
                                               <%--    <asp:Image ID="Image7" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" visible="false"/>
																  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                    ValidChars="1234567890/" FilterMode="ValidChars"
                                                                    TargetControlID="txtDOB" FilterType="Custom">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                               
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="txtDOB"
                                                                    Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                        Type="Date" ControlToValidate="txtDOB" Display="Dynamic"></asp:CompareValidator>&nbsp;
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtDOB" Display="Dynamic"
                        ErrorMessage="Age must be between 18 to 70 years!" OnInit="rngval_DOB_init" MaximumValue="2099-01-01" MinimumValue="1944-01-01"
                        Type="Date"></asp:RangeValidator> --%> 
                                                 </div>
                                             
                                         </div>
                                       
                                         <div class="row rowspacing">
                                            <div class="col-sm-4"  style="text-align: left">
                                               <asp:Label ID="lblGender" runat="server" Text="Gender" CssClass="control-label labelSize"></asp:Label>
                                            </div>
                                                <div class="col-sm-4"  style="text-align: left">
                                                   <asp:Label ID="lblMstatus" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                </div>
                                                    <div class="col-sm-4"  style="text-align: left;">
                                                       <asp:Label ID="lblEducutn" runat="server"  CssClass="control-label labelSize" Text="Education"></asp:Label>
                                                    </div>
                                          </div>
                                         <div class="row">
                                            <div class="col-sm-4"  style="text-align: left">
                                                   <asp:UpdatePanel runat="server" ID="udpPnl_ddlGender" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlGender" runat="server" class="form-control form-select mandatory"
                                                                            TabIndex="10"  AutoPostBack="true" Enabled="false"
                                                                            OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator runat="server" ID="req_Gender" InitialValue="" ErrorMessage="Gender Required."
                                                                            SetFocusOnError="true" ControlToValidate="ddlGender" ValidationGroup="agtValGrp" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                             </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="cboagnTitle" EventName="SelectedIndexChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-4">
                                                    <asp:UpdatePanel ID="UpdPanelMarital" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="cboMaritalStatus" runat="server" RequiredField="true" AutoPostBack="true"
                                                                            CssClass="form-control form-select mandatory" LookupCode="MarrySts"
                                                                            TabIndex="102" OnSelectedIndexChanged="cboMaritalStatus_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                </div>
                                              <div class="col-sm-4">
                                                      <asp:DropDownList ID="ddlEducutn" runat="server" CssClass="form-control form-select mandatory" AutoPostBack="True"                                                                  
                                                                    TabIndex="22">
                                                                </asp:DropDownList>
                                         </div>
                                          
                                          </div>
                                         <%--2nd row control end here--%>

                                          <%--3rd row control start here--%>
                                         <div class="row rowspacing" >
                                             <div class="col-sm-4" id="divAnnivrsryDt" runat="server"  style="text-align: left" visible="false">
                                                 <asp:Label ID="lblMAnivers" runat="server" Text="Marriage Anniversary" CssClass="control-label labelSize"></asp:Label> 
                                        
                                                         <asp:TextBox ID="TxtAnnivrsryDt" runat="server" CssClass="form-control" MaxLength="12" TabIndex="18" onmousedown="AnnvDte()" placeholder="DD/MM/YYYY"> </asp:TextBox>  
                                                         <asp:Image ID="Image9" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" Visible="false"/>

                                                                <asp:TextBox ID="txtImg1" runat="server" CssClass="form-control" onkeypress="checkDate()" Style="display: none"
                                                                   ></asp:TextBox>
                                                               <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="TxtAnnivrsryDt"
                                                                    PopupButtonID="Image9" Format="dd/MM/yyyy" />--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ControlToValidate="TxtAnnivrsryDt"
                                                                    Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                        Type="Date" ControlToValidate="TxtAnnivrsryDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="TxtAnnivrsryDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                    </div>

                                             <div class="col-sm-4"  style="text-align: left">

                                                 </div>
                                             <div class="col-sm-4"  style="text-align: left">

                                                 </div>
                                         </div>
                                          <%--3rd row control end here--%>


										  <div class="row"  id="divimgupld" runat="server" ><%--style="display:none;"--%>
                                          
                                               
											   <div class="col-sm-12" style="display:none;">
                                                 
												    <div class="row"  runat="server" style="margin-bottom: 5px;" >
                                             
                                                       <tr id="tr2" runat="server" style="height: 25px;" visible="true">
                                                            <td class="formcontent"><span style="font-size: 10pt; color: #ff0000">
                                                                <asp:Label ID="Label33" Text="Emp Code" runat="server" Style="color: fuchsia"></asp:Label>*</span>

                                                            </td>
                                                            <td class="formcontent">
                                                                <asp:TextBox ID="txtempcode1" runat="server" CssClass="standardtextbox"
                                                                    MaxLength="12" TabIndex="1" Width="201px"></asp:TextBox>
                                                               
                                                            </td>
                                                            <td class="formcontent">
                                                                 <asp:Label ID="Label34" Text="SAP Code" runat="server" CssClass="control-label labelSize"></asp:Label>*</span> 
                                                            </td>
                                                            <td class="formcontent">
                                                                <asp:TextBox ID="txtSapCode1" runat="server" CssClass="standardtextbox"
                                                                    MaxLength="12" TabIndex="1" Width="201px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <div class="row" id="trcltcode" runat="server" style="margin-bottom: 5px;" visible="false">
                                                          
															 <div class="col-sm-3" style="text-align: left">
															<span style="font-size: 10pt; color: #ff0000">
                                                                <asp:Label ID="lblClCode" runat="server" CssClass="control-label labelSize"></asp:Label>*</span>
															</div>
                                                          
                                                            <div class="col-sm-3">
                                                                <asp:TextBox ID="txtCusmId" runat="server" CssClass="standardtextbox"
                                                                    MaxLength="12" TabIndex="1" Width="201px"></asp:TextBox>
                                                                <asp:Button ID="btnCusmId" runat="server" CssClass="standardbutton"
                                                                    TabIndex="2" Text="...." Visible="false" Width="20px" />
                                                           </div>
                                                             <div class="col-sm-3" style="text-align: left">	
                                                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                                                            </div>
                                                             <div class="col-sm-3">	
                                                                <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline"
                                                                    UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtCltCode" runat="server" CssClass="standardtextbox"
                                                                            MaxLength="12" TabIndex="3" Width="104px"></asp:TextBox>
                                                                        <span style="padding-left: 3px;"></span>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                      
														 <div class="row"  runat="server" id="tr1" style="margin-bottom: 5px;">
                                                             <div class="col-sm-1" style="text-align: left">
                                                                <asp:Label ID="lvlVw1AgntCode" runat="server" Font-Bold="False"></asp:Label>
                                                           </div>
                                                            
															  <div class="col-sm-3" style="text-align: left">
                                                                <asp:TextBox ID="txtAgtCode" runat="server" CssClass="standardtextbox" Enabled="false"
                                                                    TabIndex="4" Width="210px" BackColor="#EDEFEE" ForeColor="Black"></asp:TextBox>
                                                                <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" Text=""
                                                                    Visible="false"></asp:Label>
                                                           </div>
																 
															  <div class="col-sm-3" style="text-align: left">
															 <span>
                                                                <asp:Label ID="lblVw1AgntStatus" runat="server" Font-Bold="False"></asp:Label>
                                                            </span>
															</div>
																 
															  <div class="col-sm-3" style="text-align: left">
                                                                <asp:DropDownList ID="ddlAgntStatus" runat="server" CssClass="form-control"
                                                                    Width="150px">
                                                                </asp:DropDownList>
                                                          </div>
																  
                                                       </div>
															

                                                     
														 <div class="row" runat="server" style="margin-bottom: 5px; ">
                                                       <div class="col-sm-4" runat="server" style="text-align:left">
															 <div class="row" style="text-align:left" >
                                                                <%--<span style="font-size: 10pt; color: #ff0000">--%>
                                                                    
																 </div>
                                                                
															  <div class="row"style="text-align:left;">
                                                                <asp:UpdatePanel runat="server" ID="updPnl_ddlTitle">
                                                                    <ContentTemplate>
																		<div class="row">
																			<div class="col-sm-3">
                                                                       
																				</div>
																			<div class="col-sm-8">
                                                                        
                                                                    </div>
                                                                            <div class="col-sm-1">

                                                                            </div>
																			</div>
																			</ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlGender" EventName="SelectedIndexChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                          </div>

                                                           </div>
                                                              <div class="col-sm-4" runat="server" style="text-align:left">
															 <div class="row"style="text-align:left">
                                                                <%--<span style="font-size: 10pt; color: #ff0000">
                                                                    *</span>--%>
                                                           </div>
														 <div class="row"style="text-align:left">
                                                                <asp:UpdatePanel ID="UpdPnlPAN" runat="server">
                                                                    <ContentTemplate>
																		<div class="row">
																			<div class="col-sm-8" style="text-align:left">
                                                                        
																				</div>
																			<div class="col-sm-2" style="text-align:left">
                                                                        
																				</div>
                                                                       <%-- <div id="divPAN" class="col-sm-2" style="display: none">
                                                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Spinner" />
                                                                            <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                                                        </div>--%>
                                                                        <br />
                                                                       
                                                                    </div>
																			</ContentTemplate>
                                                                </asp:UpdatePanel>
                                                          </div>
														</div>	

                                                              <div class="col-sm-4" runat="server" style="text-align:left">
                                                                 
                                                                   <div class="row" style="text-align: left">
                                                                <%--<span style="font-size: 10pt; color: #ff0000">
                                                                    *</span>--%>
                                                           </div>
                                                                   <div class="row" style="text-align:left">
                                                                      <div class="col-sm-8" style="text-align: left">
                                                                                                                                                                                       
																  </div>
															 <div class="col-sm-4" style="text-align: left">
																  

															 </div>
                                                                      
                                                                      </div>
                                                              </div>
                                                             
                                                       </div>																											
                                                       
														<div class="row" style="margin-bottom: 5px;" id="trserv" runat="server" visible="false">
                                                            
															 <div class="col-sm-3" style="text-align: left">
                                                                <span style="font-size: 10pt; color: #ff0000">
                                                                    <asp:Label ID="lblServName" runat="server" Font-Bold="False"
                                                                        Text="Service Name" CssClass="control-label labelSize"></asp:Label>*</span>
																</div>
																
															<div class="col-sm-3">
                                                                <asp:TextBox ID="txtServProvInfo" runat="server" CssClass="form-control mandatory"
                                                                    MaxLength="30" TabIndex="9" ></asp:TextBox>
                                                           </div>
																
															 <div class="col-sm-3">
															 </div>
															 <div class="col-sm-3">
															 </div>
                                                    </div>															
                                                       
														 <div class="row" style="margin-bottom: 5px;">                                                          																												                                                        															  														                                                          
                                                           <div class="col-sm-4" runat="server" style="text-align:left">
															  <div id="divGender" runat="server" class="row" >
                                                                
                                                            
																  </div>
                                                           
															  <div id="divddlGender" runat="server" class="row">
                                                                 
                                                            
                                                                      
                                                         </div>
																
                                                               </div>
                                                              <div class="col-sm-4" runat="server" style="text-align:left">
                                                                  <div class="row" style="text-align: left">
                                                                

																  </div>
                                                                    <div class="row" style="text-align: left">
                                                               
                                                       </div>
                                                              </div>

                                                         <div class="col-sm-4" runat="server" style="text-align:left">
                                                             <div class="row"  runat="server" style="text-align: left" id="Td6">
                                                                                                                              
                                                           </div>
                                                             <div class="row"  runat="server" >
                                                                  <div class="col-sm-8" runat="server" id="Td7" visible="true" style="text-align:left">
                                                              
                                                          </div>
															 <div class="col-sm-4" style="text-align:left">
																
															 </div>

                                                             </div>
                                                         </div>

															</div>                                                                                                        															

                                                       <div class="row" style="margin-bottom: 5px;" >
                                                            <div class="col-sm-4" runat="server" style="text-align:left">
														   <div class="row" style="text-align:left">
                                                                
                                                            </div>
                                                           <div class="row" style="text-align:left">
                                                           <div class="col-sm-8" style="text-align:left">
                                                           
                                                               </div>
                                                           </div>
                                                                </div>
                                                         
                               
                       </div>

                                    <div id="trexclusive" class="row" runat="server" visible="false" style="height: 25px;">
                                        <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblExclusive" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-3" style="text-align:left">
                                            <asp:RadioButtonList ID="rdlExclusive" runat="server">
                                            </asp:RadioButtonList>
                                        </div>
										 <div class="col-sm-3">

										 </div>
										 <div class="col-sm-3">

										 </div>
                                      
                                    </div>
									</div>
                              												
								</div>
                             
											<%--  <end>--%>
                              
									 <div class="col-sm-12" ><%--style="visibility:hidden"--%>
                                    <table border="0" cellpadding="0" cellspacing="0" class="tableIsys">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="updgrdImage" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" Visible="false"/>
                                                        <asp:GridView ID="GridImage" runat="server" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="formtable"
                                                            Height="100%" HorizontalAlign="Left" OnRowDataBound="GridImage_RowDataBound"
                                                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" Visible="false"
                                                            PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="MemCode" SortExpression="MemCode"
                                                                    Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("MemCode") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:ImageField ControlStyle-Height="100px" ControlStyle-Width="120px"
                                                                    DataImageUrlField="MemCode"
                                                                    DataImageUrlFormatString="ImageRet.aspx?ImageID={0}" HeaderText="Preview Image"
                                                                    NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                                                </asp:ImageField>
                                                            </Columns>
                                                            <RowStyle BackColor="#78A8FA" CssClass="sublinkeven" />
                                                            <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue"
                                                                HorizontalAlign="Center" />
                                                            <HeaderStyle CssClass="test" />
                                                            <AlternatingRowStyle BackColor="#78A8FA" CssClass="sublinkodd" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridCndImage" runat="server" AllowSorting="True" CssClass="formtable"
                                                            PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                            RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                            AllowPaging="True" Width="100%" Visible="false"
                                                            OnRowDataBound="GridCndImage_RowDataBound">
                                                            <Columns>

                                                                <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                                        <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImgCndMem.aspx?ImageID={0}"
                                                                    HeaderText="Preview Image" ControlStyle-Height="100px" ControlStyle-Width="120px">
                                                                </asp:ImageField>
                                                            </Columns>
                                                            <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True"></PagerStyle>
                                                            <HeaderStyle CssClass="test"></HeaderStyle>
                                                            <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo"
                                                    Font-Size="12px"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                               
                               </div>
                           
										 </div>
                             
                            </div>
    </div>
                                     <%--Personal details End  by ajay yadav 02-11-2022--%>

                                     <%--Contact details Start  by ajay yadav 02-11-2022--%>
                                    <div id="divpn2" runat="server" class="card PanelInsideTab" visible="true">
							   		<%--<div id="Div6" runat="server" class="panelheadingAliginment">
										<div class="row spacebetnrow">
											<div class="col-sm-10" style="text-align: left">
                                                                                              <asp:Label ID="lblCnctDtlsHdr" runat="server"
                                                   Text="Contact Details" CssClass="control-label HeaderColor"></asp:Label>
                                          </div>
											</div>
										</div>--%>
                                         <div id="Div6" runat="server" class="panelheadingAliginment" >
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                      
                        <asp:Label ID="lblCnctDtlsHdr" runat="server" Text="Contact Details" CssClass="control-label HeaderColor"></asp:Label>
  
                    </div>
                    <div class="col-sm-2">
                         
                 <span id="btncnctdtlscollapse" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcnctdetails','btncnctdtlscollapse');return false;" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc"></span>

                    </div>
                </div>
            </div>

                                     <div id="divcnctdetails" runat="server"  style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                         <div class="row rowpacing">
                                             <div class="col-sm-4"  style="text-align: left">
                                                   <asp:Label ID="lblMobileNo" runat="server"  CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtMobileTel" runat="server" 
                                                    CssClass="form-control mandatory" MaxLength="10" TabIndex="15" ></asp:TextBox>
                                              
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtMobileTel" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                          
                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblMobile2" runat="server"  CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtMobileTel2" runat="server" CssClass="form-control"
                                                    MaxLength="10" TabIndex="17" ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtMobileTel2" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>

                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblHomeTel" runat="server"  CssClass="control-label labelSize"></asp:Label>
												
                                                <asp:TextBox ID="txtHomeTel" runat="server"
                                                    CssClass="form-control" MaxLength="10" TabIndex="12"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtHomeTel" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                         </div>
                                        
                                         <div class="row">
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblOfficeTel" runat="server" CssClass="control-label labelSize"></asp:Label>
                                               
                                                <asp:TextBox ID="txtWorkTel" runat="server" CssClass="form-control" onblur="javascript:worktelval();return false;"
                                                    MaxLength="10" TabIndex="13" ></asp:TextBox>
                                               <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtWorkTel" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblEmail" runat="server" CssClass="control-label labelSize"></asp:Label>
										
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mandatory" 
                                                    TabIndex="14" ></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="revEmail" runat="server"
                                                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email ID!" SetFocusOnError="true"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    Width="208px"></asp:RegularExpressionValidator>
                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblEmail2" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control"
                                                    TabIndex="16" ></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtEmail2" Display="Dynamic" ErrorMessage="Invalid Email ID!"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                   ></asp:RegularExpressionValidator>
                                         </div>
                                         </div>
                                       
                                             <div class="row">
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblFbId" runat="server" Text="Facebook ID" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtFbId" runat="server"
                                                    CssClass="form-control" ></asp:TextBox>
                                         </div>
                                          <div class="col-sm-4"  style="text-align: left">
                                                <asp:Label ID="lblInstId" runat="server" Text="Instagram ID" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtInstId" runat="server"
                                                    CssClass="form-control" ></asp:TextBox>
                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblTwt" runat="server" Text="Twitter handle" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtTwt" runat="server"
                                                    CssClass="form-control" ></asp:TextBox>
                                         </div>
                                         </div>
                                        
                                            <div class="row rowspacing">
                                                   <div class="col-sm-4"  style="text-align: left">
 <asp:Label ID="lblFax" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"
                                                    TabIndex="19"  MaxLength="11"></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtFax" FilterType="Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                         </div>
                                         </div>
                                        
										
									<div class="row" style="display:none" >
                                            <div class="col-sm-1" style="text-align: left">
                                                <asp:Label ID="lblPager" runat="server" CssClass="control-label labelSize"></asp:Label>
                                            </div>
                                             <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtPager" runat="server" CssClass="form-control"
                                                    TabIndex="18"  MaxLength="11"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ValidationExpression="^[0-9\-\(\)\, ]+$" ControlToValidate="txtPager"
                                                    ErrorMessage="Invalid number!" ID="regexp_Pager" runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                                           </div>
										</div>
                                </div>
                                        </div>
                                     <%--Contact details End  by ajay yadav 02-11-2022--%>

                                     <%--Address details Start  by ajay yadav 02-11-2022--%>
                                    <div id="divpn3" runat="server" class="card PanelInsideTab" visible="true">
                                         <div id="Div10" runat="server" class="panelheadingAliginment" >
                        <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                                    <%-- <div id="Div10" runat="server" class="panelheadingAliginment">
										  <div class="row spacebetnrow" id="div7" runat="server">
                                        <div class="col-sm-10" style="text-align: left">
                                           --%>
                                            <asp:Label ID="lblresadd" runat="server" Text="Present Address" CssClass="control-label HeaderColor" ></asp:Label>
                                       </div>
                             <div class="col-sm-2">
                     
                              <span id="btnresaddrcollapse" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divresaddress','btnresaddrcollapse');return false;" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc"></span>
                    </div>
                                    </div>
											  </div>
                                     <div id="divresaddress" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%"> 
                                           <div class="row rowspacing" style="display:none">
                                                <div class="col-sm-3">
                                                <asp:TextBox ID="txtStateCodeP" runat="server" CssClass="form-control" MaxLength="3"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" 
                                                     TabIndex="37"></asp:TextBox>
                                                <asp:TextBox ID="txtStateDescP" runat="server" CssClass="form-control" Enabled="true"
                                                    ></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:Button ID="btnStateP" runat="server" CausesValidation="False" CssClass="btn btn-success" Text="..." TabIndex="38" />
                                            </div>
                                           </div>
                                         <div class="row rowspacing">
                                          <div class="col-sm-4"  style="text-align: left">
                                                    <asp:Label ID="lblpfAddrP1" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtAddrP1" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    runat="server" Font-Bold="False" CssClass="form-control mandatory" MaxLength="30"
                                                    TabIndex="60"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Addr1" runat="server" ControlToValidate="txtAddrP1" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>

                                         </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblpfAddrP2" Text="Address2" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtAddrP2" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="67" 
                                                     TabIndex="61"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Addr2" runat="server" ControlToValidate="txtAddrP2" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                         </div>
                                                <div class="col-sm-4"  style="text-align: left">
                                                    <asp:Label ID="lblpfAddrP3" Text="Address3" runat="server" CssClass="control-label labelSize">
                                                </asp:Label>
                                                <asp:TextBox ID="txtAddrP3" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="68"
                                                     TabIndex="62"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Addr3" runat="server" ControlToValidate="txtAddrP3" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                         </div>
</div>

                                         <div class="row rowspacing">
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblpfStateP" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                   <asp:Label ID="lblDistP" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblcity" runat="server" Text="City" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                         </div>

                                         <div class="row ">
                                             <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control form-select mandatory"  Width="276px"
                                                     TabIndex="65">
                                                </asp:DropDownList>
                                                 </div>
										<div class="col-sm-1" style="text-align: left">
											 <asp:Button ID="btnStateSrch" runat="server" CausesValidation="False" CssClass="btn btn-success Prefix1" style=" width: 65px; padding-left: 4px; height: 33px; "
                                                    Text="SEARCH" TabIndex="66" />
										</div>
                                             <div class="col-sm-4">
                                                 <asp:TextBox ID="txtDistP" ReadOnly="false" runat="server" Font-Bold="False" Enabled="false"
                                                    CssClass="form-control mandatory" MaxLength="50" 
                                                   TabIndex="67"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:Button ID="btnDist" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                                    Text="..." TabIndex="83" Visible="False" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_DistP" runat="server" ControlToValidate="txtDistP" ErrorMessage="Invalid District!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                <asp:HiddenField ID="hdnDist" runat="server" />
                                                <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnPinTo" runat="server" />
                                             </div>
                                             <div class="col-sm-4">
                                                  <asp:TextBox ID="txtcity" runat="server" 
                                                    CssClass="form-control mandatory" Font-Bold="False" MaxLength="70" ReadOnly="false" Enabled="false"
                                                    TabIndex="64" ></asp:TextBox>
                                                <asp:Button ID="btncity" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Enabled="false" Text="..." Visible="false"
                                                    TabIndex="71" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_txtCity1" runat="server" ControlToValidate="txtcity"
                                                    ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>

                                         <div class="row">
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:UpdatePanel ID="UpdPanelVillage" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblVillage" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                        <asp:TextBox ID="txtVillage" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" Font-Bold="False" MaxLength="69"
                                                            TabIndex="63"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Village" runat="server" ControlToValidate="txtVillage" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                            ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblarea" runat="server" Text="Area" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtarea" runat="server" CssClass="form-control mandatory" Enabled="false"
                                                     ReadOnly="false"
                                                    Font-Bold="False" MaxLength="50" TabIndex="68" ></asp:TextBox>
                                                <asp:Button ID="btnarea" runat="server" CssClass="btn btn-success" CausesValidation="False"
                                                    Text="..." Enabled="false" Visible="false" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_area" runat="server" ControlToValidate="txtarea" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblpfPinP" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtPinP" runat="server" CssClass="form-control mandatory" ReadOnly="false" Enabled="false"
                                                    Font-Bold="False" MaxLength="6" 
                                                    TabIndex="69"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ValidationExpression="^[0-9\-\(\)\, ]+$" ControlToValidate="txtPinP"
                                                    ErrorMessage="Invalid PinCode!" ID="regexp_PinCode" runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>

                                         <div class="row rowspacing">
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblpfCountryP" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-4" style="text-align: left">
                                                 <div class="row">
                                                    <div class="col-sm-3">
                                                          <asp:TextBox TabIndex="70" ID="txtCountryCodeP" runat="server" CssClass="form-control mandatory PrefixDll" style="width:105%"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    MaxLength="3"  Text="IND" ReadOnly="true"></asp:TextBox>    
                                                     </div>
                                                     <div class="col-sm-9">
                                                          <asp:TextBox ID="txtCountryDescP" runat="server" CssClass="form-control"
                                                     Enabled="False"  Text="INDIA"
                                                    TabIndex="71"></asp:TextBox>
                                                         <%--<asp:Button TabIndex="72" ID="btnCountryP" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Text="..." />--%>
                                                        
                                                     </div>
                                                     <div class="col-sm-1" style="display:none">
                                                          <asp:Button ID="btnCountryP" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success PrefixDll" TabIndex="85" Text="..." />
                                                     </div>
                                                 </div>
                                             </div>
                                         </div>

                                        <div class="row" id="tradd1" runat="server" style="display:none">
                                          
											<div class="col-sm-2">
											</div>
											<div class="col-sm-3">
											</div>
											<div class="col-sm-2">
											</div>									
											
                                        </div>
                                       
									<div class="row"  style="display:none">
                                            <div class="col-sm-1" style="text-align: left">
                                               
                                            </div>
										<div class="col-sm-2">

										</div>
                                             <div class="col-sm-1" style="text-align: left">
                                                <span style="color: #ff0000">
                                                   
												 </div>
                                             
                                        </div>
                                      <div class="row" style="display:none">
                                            <div class="col-sm-1" style="text-align: left">
                                               
                                                
                                                <span style="color: #ff0000">*</span>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                 
                                            </div>
										  <div class="col-sm-2">

										</div>
                                            <div class="col-sm-1" style="text-align: left">
                                                <span style="color: #ff0000">
                                                  *</span>
												</div>
                                            <div class="col-sm-3" style="text-align: left">
                                                
                                            </div>
                                        </div>
                                         <div class="row" style="display:none">
                                           <div class="col-sm-1" style="text-align: left">
                                                <span style="color: #ff0000">*</span>
                                          </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                
                                            </div>
											  <div class="col-sm-2" >

											  </div>
                                            <div class="col-sm-1" style="text-align: left">
                                                <span style="color: #ff0000">*</span>
                                            </div>
                                           <div class="col-sm-3" style="text-align: left">
                                              
                                            </div>
                                        </div>
                                        <div class="row"  style="display:none">
                                           <div class="col-sm-1" style="text-align: left">
                                                <span style="color: Red">
                                                    *</span>
                                            </div>
                                           <div class="col-sm-3" style="text-align: left">
                                               
                                            </div>
											<div class="col-sm-2">

											 
											</div>
                                            <div class="col-sm-1" style="text-align: left">
                                                <span style="color: #ff0000">*</span>
                                           </div>
                                            <div class="col-sm-3" style="text-align: left">
                                               
                                           </div>
                                       </div>
                                        <div class="row" style="display:none">

                                            <div class="col-sm-1" style="text-align: left">
                                                
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                
                                           </div>
											<div class="col-sm-2">

											</div>
                                           <div class="col-sm-1" style="text-align: left">
                                                
                                           </div>										
                                           <div class="col-sm-4" style="text-align: left">
                                                                                                                                         
                                            </div>
											<div class="col-sm-3" style="text-align:left">
												
												
											</div>
											<div class="col-sm-1" style="text-align:left">
												
											</div>
                                       </div>
                                </div>
                                        </div>
                                    <%--Address details End  by ajay yadav 02-11-2022--%>

                                     <%--Permanent details Start  by ajay yadav 02-11-2022--%>
                                    <div id="divpn4" runat="server" class="card PanelInsideTab" visible="true">
                                    <%--<div id="Div9" runat="server" class="panelheadingAliginment" >
										  <div class="row spacebetnrow" id="Div14" runat="server">
                                    <div class="col-sm-10" style="text-align: left">
                                    <asp:Label ID="lblPermAdd" Text="Permanent Address" runat="server" CssClass="control-label HeaderColor" ></asp:Label>
                                   </div>
                               </div>
								  </div>--%>
                   <div id="Div9" runat="server" class="panelheadingAliginment" >
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        
                        <asp:Label ID="lblPermAdd" runat="server" Text="Permanent Address" CssClass="control-label HeaderColor"></asp:Label>
                        
                    </div>
                    <div class="col-sm-2">
                     
                         <span id="btnPermAddrCollapse" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpermaddr','btnPermAddrCollapse');return false;" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px; color:#00cccc"></span>

                    </div>
                </div>
            </div>
                                    <div id="divpermaddr" runat="server" style="display: block;" width="100%"  class="panel-body panelContent spacebetnrow">
                                        <div class="row">
                                    <div class="col-sm-12" style="text-align: left">
                                          <div class="col-sm-8" style="text-align:left">
                                                <asp:Label ID="lblpfPrmAddTitle" runat="server" style="padding-left: 3px; color:Red"  Text="Permanent Address same as Present Address"   CssClass="control-label labelSize"></asp:Label>
                                             <%-- <span style="padding-left: 3px; color:Red"></span>--%>
                                                <asp:CheckBox ID="ChkPARes" runat="server"
                                                    CssClass="standardcheckbox" TabIndex="107" />
                                                <asp:CheckBox ID="ChkPABusns" runat="server" Text="Business" Visible="false"
                                                    CssClass="standardcheckbox" TabIndex="108" />
                                                <span style="font-size: smaller; color: Red; font-family: Arial;display:none;">Please reselect checkbox in case for changes in above address.</span>
                                           </div>
                                             <div class="col-sm-2" style="text-align:left">
                                                <asp:Label ID="lblCorrAdd" CssClass="control-label labelSize" runat="server" Visible="false" Text="Correspondence Address"></asp:Label>
                                           </div>
                                            <div class="col-sm-2" style="text-align:left ; display:none">
                                                <asp:DropDownList ID="ddlCnctType" runat="server" AppendDataBoundItems="true"
                                                    CssClass="form-control" DataSourceID="dsCnctType" DataTextField="ParamDesc"
                                                    DataValueField="ParamValue" TabIndex="11" Width="150px">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="dsCnctType" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                            </div>
                                    </div>
                                </div>
                                        <div class="row rowspacing">
                                      <div class="col-sm-4"  style="text-align: left">
                                                 
                                                    <asp:Label ID="lblpfprmAdd1" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtPermAdd1" runat="server"
                                                    MaxLength="30" TabIndex="86" ></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtPermAdd1" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-4"  style="text-align: left">
                                                <asp:Label ID="lblpfprmAdd2" Text="Address2" runat="server" CssClass="control-label labelSize"></asp:Label>
                                         
                                                <asp:TextBox CssClass="form-control" ID="txtPermAdd2" runat="server"
                                                    MaxLength="30" TabIndex="87"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtPermAdd2" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                            <div class="col-sm-4"  style="text-align: left">
                                                <asp:Label ID="lblpfprmAdd3" Text="Address3" runat="server" CssClass="control-label labelSize"></asp:Label>
                                          
                                                <asp:TextBox CssClass="form-control" ID="txtPermAdd3" runat="server"
                                                    MaxLength="30" TabIndex="88" ></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtPermAdd3" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                             </div>
                                        <div class="row rowspacing">
                                             <div class="col-sm-4"  style="text-align: left">
                                                    <asp:Label ID="lblpfprmstatecode" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                    <asp:Label ID="lblPDist" runat="server" Text="District" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                 <asp:Label ID="lblcity1" runat="server" Text="City" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                         </div>
                                        <div class="row">
                                             <div class="col-sm-4">
                                                 <div class="row">
                                            <div class="col-sm-9">
                                                  <asp:DropDownList ID="ddlState1" runat="server" Width="280px"
                                                    CssClass="form-control form-select" TabIndex="91" >
                                                </asp:DropDownList>
                                             </div>
                                                     <div class="col-sm-3">
                                                           <asp:Button ID="btnStateSrch1" runat="server" CausesValidation="False" style=" width: 65px; padding-left: 4px; height: 33px; "
                                                    CssClass="btn btn-success" TabIndex="92" Text="SEARCH" />
                                             </div>
                                                     </div>
                                                 </div>
                                             <div class="col-sm-4">
  <asp:TextBox ID="txtDistric" ReadOnly="false" Enabled="false" runat="server" Font-Bold="False" CssClass="form-control"
                                                    MaxLength="50"  TabIndex="93"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:Button ID="btnDistric" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Text="..." TabIndex="118" Visible="False" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_Distc" runat="server" ControlToValidate="txtDistric" ErrorMessage="Invalid District!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                <asp:HiddenField ID="hdnDistP" runat="server" />
                                                <asp:HiddenField ID="hdnPinFromP" runat="server" />
                                                <asp:HiddenField ID="hdnPinToP" runat="server" />
                                             </div>
                                             <div class="col-sm-4">
                                                   <asp:TextBox ID="txtcity1" runat="server"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="50" Enabled="false"
                                                    TabIndex="90" ></asp:TextBox>
                                                <asp:Button ID="btncity1" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Enabled="false" Text="..." Visible="false"
                                                    TabIndex="114" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_city1" runat="server" ControlToValidate="txtcity1" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>
                                        <div class="row">
                                             <div class="col-sm-4"  style="text-align: left">
                                                   <asp:Label ID="lblPermVillage" runat="server" Text="Village" CssClass="control-label labelSize"></asp:Label>
                                            
                                                <asp:UpdatePanel ID="UpdPermVilg" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtPermVillage" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                            TabIndex="89"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_txtPermVillage" runat="server"
                                                            ControlToValidate="txtPermVillage" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                            ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                  <asp:Label ID="lblarea1" runat="server" Text="Area" CssClass="control-label labelSize"></asp:Label>
												
                                                <asp:TextBox ID="txtarea1" runat="server"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="50" ReadOnly="false" Enabled="false"
                                                    TabIndex="94"></asp:TextBox>
                                                <asp:Button ID="btnarea1" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Enabled="false" TabIndex="120" Text="..."
                                                    Visible="false" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_area1" runat="server" ControlToValidate="txtarea1" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                             <div class="col-sm-4"  style="text-align: left">
                                                   <asp:Label ID="lblpfprmpostcode" runat="server" CssClass="control-label labelSize"></asp:Label>
												
                                                <asp:TextBox ID="txtPermPostcode" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                                    MaxLength="6" TabIndex="95" ></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ValidationExpression="^[0-9\-\(\)\, ]+$" ControlToValidate="txtPermPostcode"
                                                    ErrorMessage="Invalid PinCode!" ID="regexp_txtPermPin" runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>
                                        <div class="row rowspacing">
                                             <div class="col-sm-4"  style="text-align: left">
<asp:Label ID="lblpfprmcountry" runat="server" CssClass="control-label labelSize"></asp:Label>
											  
                                             
                                             </div>
                                         </div>
                                        <div class="row">
                                             <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-3">
                                                  <asp:TextBox ID="txtPermCountryCode" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false" style="width:105%"
                                                    MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="96"  Text="IND"></asp:TextBox>
                                             </div>
                                             <div class="col-sm-9">
                                                  <asp:TextBox ID="txtPermCountryDesc" runat="server" CssClass="form-control"
                                                    Enabled="false" TabIndex="97" 
                                                    Text="INDIA"></asp:TextBox>
												 
                                                 </div>
                                            <div class="col-sm-3" style="display:none">
                                                <asp:Button ID="btnPermCountry" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success PrefixDll" TabIndex="98" Text="..." />
                                             </div>
                                             </div>

                                             </div>
                                         </div>
                                       <div class="row" style="margin-bottom: 5px;" id="trPermAdd1" runat="server" visible="false">
                                           <div class="col-sm-3">

											</div>
                                            <div class="col-sm-3">

											</div>
                                            <div class="col-sm-3">

											</div>
                                            <div class="col-sm-3" style="display: flex">
                                                <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control"
                                                    MaxLength="3" 
                                                    onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="62"
                                                   ></asp:TextBox>
                                                <asp:TextBox ID="txtStateDesc" runat="server" CssClass="btn btn-success"
                                                    Width="170px" Enabled="false" TabIndex="63" ></asp:TextBox><span style="padding-left: 3px;"></span>
												<asp:Button CssClass="btn btn-success" ID="btnPermState" runat="server" Text="..."
                                                        CausesValidation="False" TabIndex="64" />
                                           </div>
                                       </div>
                                       <div class="row" style="margin-bottom: 5px;" visible="false">
                                            <div class="col-sm-1" style="text-align: left">
                                               
                                           </div>
										    <div class="col-sm-2" style="text-align: left">

										   </div>                                         									  
                                           <div class="col-sm-6" style="text-align: left">
											   <div class="row">
												   <div class="col-sm-2" style="text-align: left">
                                                
											   </div>
												   <div class="col-sm-6">
                                              
													   </div>
												     <div class="col-sm-2" style="text-align:left">
                                              
												   </div>
												   </div>
                                            </div>
                                       </div>
                                       <div class="row" style="margin-bottom: 5px;" id="trPermAdd2" runat="server" visible="false">
                                          
                                           </div>
										    <div class="col-sm-2" style="text-align: left" visible="false">

										   </div>
                                           <div class="col-sm-1" style="text-align: left" visible="false">
                                                
											   </div>
                                            <div class="col-sm-3" style="text-align: left" visible="false">
                                              
                                            </div>
                                       <%--</div>--%>
                                       <div class="row" style="margin-bottom: 5px;" id="trPermAdd3" runat="server" visible="false">
                                            <div class="col-sm-1" style="text-align: left">
                                                
                                            </div>
										    <div class="col-sm-2" style="text-align: left">

										   </div>
                                            <div class="col-sm-1" style="text-align: left">

                                               
                                            </div>
                                       </div>
                                        <div class="row" style="margin-bottom: 5px;" visible="false">
                                            <div class="col-sm-1" style="text-align: left">

                                                
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                              
                                            </div>
											<div class="col-sm-2">

											</div>

                                            <div class="col-sm-1" style="text-align: left">

                                              
                                           </div>
                                       </div>
                                        <div class="row" style="margin-bottom: 5px;" visible="false">
                                            <div class="col-sm-1" style="text-align: left">
                                              
                                           </div>
											<div class="col-sm-2">

											</div>
                                           <div class="col-sm-6" style="text-align: left">
											   <div class="row">
											   <div class="col-sm-2" style="text-align: left">
                                                
											   </div>
											  <div class="col-sm-5" style="text-align: left"> 
                                               
                                            </div>
												   </div>
											</div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;" visible="false">

                                            <div class="col-sm-5" style="text-align: center">                                              
                                                <asp:Button ID="btnAddrAdd" runat="server" Text="ADD" Visible="false" CssClass="standardbutton"
                                                    TabIndex="188" Width="100px" OnClick="btnAddrAdd_Click" />
                                            </div>                        
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">

                                            <div class="col-sm-5" style="text-align: center">
                                                <asp:GridView ID="GridViewAddress" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" OnRowDeleting="GridViewAddress_RowDeleting" runat="server"
                                                    BackColor="White" Style="width: 100%;"
                                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">

                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                    <SortedDescendingHeaderStyle BackColor="#002876" />

                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Address Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddressType" runat="server" Text='<%# Bind("AddressType") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="District">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("District") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Area">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Area") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Village">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVillage" runat="server" Text='<%# Bind("Village") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="city">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcity" runat="server" Text='<%# Bind("city") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PinCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPinCode" runat="server" Text='<%# Bind("PinCode") %>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="delete" />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                   </div>
                                        </div>
                                    <%--Permanent details End  by ajay yadav 02-11-2022--%>

                                    <%--Bussiness details Start  by ajay yadav 02-11-2022--%>
                                    <div id="divpn5" runat="server" class="card PanelInsideTab" visible="true">
                                	 <%-- <div id="Div12" runat="server" class="panelheadingAliginment" >
                                     <div class="row spacebetnrow" id="div8" runat="server" style="text-align: left;">
                                       <div class="col-sm-10" style="text-align: left">
                                         <asp:Label ID="lblbusadd" runat="server" Text="Business Address (Optional)" CssClass="control-label HeaderColor"></asp:Label>
                                            </div>
                                   </div>
											  </div>--%>
                    <div id="Div12" runat="server" class="panelheadingAliginment">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-10" style="text-align: left">
                       
                        <asp:Label ID="lblbusadd" runat="server" Text="Business Address (Optional)" CssClass="control-label HeaderColor"></asp:Label>
                       
                    </div>
                    <div class="col-sm-2">
                      <span id="btnBusiAddrCollapse"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusiaddr','btnBusiAddrCollapse');return false;" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc"></span>

                    </div>
                </div>
            </div>
                                      <div id="divBusiaddr" runat="server" style="display: block;" width="100%" class="panel-body panelContent spacebetnrow">               
                                        <div class="row" id="tradd2" style="margin-bottom: 5px;" runat="server" visible="false">
                                            <div class="col-sm-3">

											</div>
                                            <div class="col-sm-3">

											</div>
											 <div class="col-sm-3">

											</div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="txtStateCodeB" runat="server" CssClass="form-control" MaxLength="3"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" 
                                                    TabIndex="47"></asp:TextBox>
                                                <asp:TextBox ID="txtStateDescB" runat="server" CssClass="form-control" Enabled="true"
                                                    TabIndex="48"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:Button ID="btnStateB" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                                    Text="..." TabIndex="49" />
                                            </div>
                                      </div>
                                        <div class="row rowspacing" style="margin-bottom: 5px;">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblpfAddrB1" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtAddrB1" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    runat="server" Font-Bold="False" CssClass="form-control" MaxLength="30"
                                                     TabIndex="73"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_AddrB1" runat="server" ControlToValidate="txtAddrB1" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                          </div>
                                              <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblpfAddrB2" Text="Address2" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtAddrB2" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                    TabIndex="74"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_AddrB2" runat="server" ControlToValidate="txtAddrB2" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                           </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblpfAddrB3" Text="Address3" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:TextBox ID="txtAddrB3" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                    TabIndex="75"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAddrB3" ErrorMessage="Invalid Address!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                           </div>
                                       </div>
                                        <div class="row rowspacing">
                                             <div class="col-sm-4" style="text-align: left">
                                                 <asp:Label ID="lblpfStateB" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                   <asp:Label ID="lblDistB" Text="District" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                  <asp:Label ID="lblcity0" runat="server" Text="City" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                         </div>
                                        <div class="row">
                                             <div class="col-sm-4"  >
                                                 <div class="row">
                                                      <div class="col-sm-9" style="text-align: left">
                                                <asp:DropDownList ID="ddlState0" runat="server" Width="278px"
                                                    CssClass="form-control form-select" TabIndex="78" >
                                                </asp:DropDownList>
												</div>
												 <div class="col-sm-3" style="text-align: left">
                                                <asp:Button ID="btnStateSrch0" runat="server" CausesValidation="False" Style="padding-left: 4px; width: 65px; height: 33px;"
                                                    CssClass="btn btn-success Prefix1" TabIndex="79" Text="SEARCH" />
                                            </div>
                                                     </div>
                                             </div>
                                             <div class="col-sm-4">
                                                  <asp:TextBox ID="txtDistB" ReadOnly="false" Enabled="false" runat="server" Font-Bold="False"
                                                    CssClass="form-control" MaxLength="50" 
                                                    TabIndex="80"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span>
                                                <asp:Button ID="btnDistB" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                                    Text="..." TabIndex="99" Visible="False" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_DistB" runat="server" ControlToValidate="txtDistB" ErrorMessage="Invalid District!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                <asp:HiddenField ID="hdnDistB" runat="server" />
                                                <asp:HiddenField ID="hdnPinFromB" runat="server" />
                                                <asp:HiddenField ID="hdnPinToB" runat="server" />
                                             </div>
                                             <div class="col-sm-4">
                                                  <asp:TextBox ID="txtcity0" runat="server"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="50" ReadOnly="false" Enabled="false"
                                                    TabIndex="77" ></asp:TextBox>
                                                <asp:Button ID="btncity0" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Enabled="false" Text="..." Visible="false"
                                                    TabIndex="95" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_txtcity0" runat="server" ControlToValidate="txtcity0" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>
                                        <div class="row">
                                             <div class="col-sm-4" style="text-align: left">
                                                  <asp:Label ID="lblBvillage" runat="server" CssClass="control-label labelSize"></asp:Label>
                                            
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtBvillage" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                            TabIndex="76"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator3" runat="server"
                                                            ControlToValidate="txtBVillage" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                            ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                 <asp:Label ID="lblarea0" runat="server" Text="Area" CssClass="control-label labelSize"></asp:Label>

                                            
                                                <asp:TextBox ID="txtarea0" runat="server"
                                                    CssClass="form-control" Font-Bold="False" MaxLength="50" ReadOnly="false" Enabled="false"
                                                    TabIndex="81"></asp:TextBox>
                                                <asp:Button ID="btnarea0" runat="server" CausesValidation="False"
                                                    CssClass="btn btn-success" Enabled="false" TabIndex="101" Text="..."
                                                    Visible="false" />
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_area0" runat="server" ControlToValidate="txtarea0" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                                                    ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                  <asp:Label ID="lblpfPinB" runat="server" CssClass="control-label labelSize"></asp:Label>
                                         
                                                <asp:TextBox ID="txtPinB" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                                    Font-Bold="False" MaxLength="6" 
                                                    TabIndex="82"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ValidationExpression="^[0-9\-\(\)\, ]+$" ControlToValidate="txtPinB"
                                                    ErrorMessage="Invalid PinCode!" ID="RegularExpressionValidator4" runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                                             </div>
                                         </div>
                                          <div class="row rowspacing" style="text-align: left">
                                             <div class="col-sm-4"  style="text-align: left">
<asp:Label ID="lblpfCountryB" runat="server" CssClass="control-label labelSize"></asp:Label>
                                             </div>
                                             <div class="col-sm-4">

                                             </div>
                                             <div class="col-sm-4">

                                             </div>
                                         </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                           <div class="col-sm-4" style="text-align: left">
                                               <div class="row">
                                           <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtCountryCodeB" runat="server" CssClass="form-control PrefixDll" Enabled="false"  style="width:105%"
                                                    MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="83" Text="IND" ></asp:TextBox>
											   </div>
											    <div class="col-sm-9" style="text-align: left">
                                                <asp:TextBox ID="txtCountryDescB" runat="server" CssClass="form-control"
                                                    Enabled="False" TabIndex="84" Text="INDIA" ></asp:TextBox>
											   </div>
											    <div class="col-sm-3" style="text-align: left;display:none" >
                                                <asp:Button ID="btnCountryB" runat="server" CausesValidation="False" 
                                                    CssClass="btn btn-success PrefixDll" TabIndex="85" Text="..." />
                                            </div>
										   </div>
                                        </div>
                                          </div>
                                </div>

                                        <div class="row">
                                            <div class="col-sm-12">
     <asp:LinkButton  ID="btnNextPannel1" runat="server" Text="" CssClass="btn btn-success " OnClick="btnNextPannel1_Click" OnClientClick="return funValidatePannel1();">  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 

                                            </div>
                                        </div>
                                        </div>
                                    <%--Bussiness details End  by ajay yadav 02-11-2022--%>
                                <%--OnClientClick="return funValidatePannel1();"       OnClientClick="return funValidatePannel1();"--%>
                                                              
                                    <%-- <asp:Button ID="btnNextPannel1" runat="server" Text="NEXT" CssClass="btn btn-success "
                                    OnClick="btnNextPannel1_Click"  TabIndex="188"/>--%><%--OnClientClick="return funValidatePannel1();"--%>        
                            <%--</div>--%>
                            </div>
                            </span>
          </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="Updatepanel5" runat="server">
                        <ContentTemplate>
                            <div id="divPannel2" runat="server" visible="false">
                                <div id="div3"  class="card PanelInsideTab" runat="server" style="display: block;">
                                    <%--<div id="Div13" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusiness','divBusinesscollapse');return false;">
                                         <div class="row spacebetnrow" id="div11" runat="server" style="text-align: left;">
                                            <div class="col-sm-12">
                                                <asp:Label ID="Label17" runat="server" CssClass="control-label HeaderColor" 
                                                    Text="Business Evaluation "></asp:Label>
                                             </div>
                                        </div>
									</div>--%>
                                     <div id="Div13" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusiness','btnBusinesscollapse');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                      
                        <asp:Label ID="Label17" runat="server" CssClass="control-label HeaderColor"  Text="Business Evaluation "></asp:Label>
  
                    </div>
                    <div class="col-sm-2">
                        
                 <span id="btnBusinesscollapse" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc"></span>

                    </div>
                </div>
            </div>

                                    <div id="divBusiness" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                       
                                            <div class="row rowspacing" style="margin-bottom: 5px;">
                                                <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label18" runat="server" CssClass="control-label" Text="Expected monthly Business (Health)"></asp:Label>
                                                        <asp:TextBox ID="txtExpt" runat="server"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control mandatory" style="display:none;"></asp:TextBox>
                                                     <asp:DropDownList ID="txtExpt1" runat="server" CssClass="form-control form-select mandatory"  TabIndex="79">
                                                        </asp:DropDownList>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtExpt" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>

                                                   </div>
                                                <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label20" runat="server" CssClass="control-label" Text="Expected Team Strength "></asp:Label>													
                                                        <asp:TextBox ID="txtExpectTm" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control mandatory" ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtExpectTm" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                   </div>
                                                 <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="control-label" Text="Agents(In 6 Month)"></asp:Label>
                                                        <asp:TextBox ID="txtAgntMonth" runat="server" 
                                                            CssClass="form-control mandatory"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtAgntMonth" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>


                                                   </div>
                                            </div>

                                            <div class="row rowspacing" style="margin-bottom: 5px;">
                                                    <div class="col-sm-4" style="text-align: left">
                                                        <asp:Label ID="Label19" runat="server" CssClass="control-label" Text="Agents(In 12 Month)"></asp:Label>
                                                        <asp:TextBox ID="txtAgntMonth12" runat="server" 
                                                            CssClass="form-control mandatory" ></asp:TextBox>

                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtAgntMonth12" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </div>
                                                 <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label21" runat="server" Text="POSP(In 6 Month)" CssClass="control-label"></asp:Label>
                                                        <asp:TextBox ID="txtPosp6" runat="server" 
                                                            CssClass="form-control mandatory" ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtPosp6" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-sm-4" style="text-align: left">
                                                        <asp:Label ID="Label23" runat="server" Text="POSP(In 12 Month)" CssClass="control-label"></asp:Label>
                                                        
                                                        <asp:TextBox ID="txtPosp12" runat="server" 
                                                            CssClass="form-control mandatory"></asp:TextBox>

                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                            FilterType="Numbers" TargetControlID="txtPosp12" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </div>
                                           </div>
                                        <div class="row rowspacing">
                                            <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label24" runat="server" CssClass="control-label" Text="Details of existing and any other business"></asp:Label>

                                            </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                        <asp:Label ID="Label25" runat="server" style="line-height:1px" CssClass="control-label" Text="Whether involved in Multi level Marketing in financial service business"></asp:Label>

                                            </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label26" runat="server" CssClass="control-label" Text="Details of law suits against or initiated by Service Provider- Criminal or Police records / Legal or checks"></asp:Label>

                                            </div>
                                        </div>

                                            <div class="row " style="margin-bottom: 5px;">
                                               <div class="col-sm-4" style="text-align: left">
                                                    
                                                        <asp:TextBox ID="txtDtlsExtBus" runat="server" TextMode="MultiLine"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtDtlsExtBus" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>

                                                    </div>
                                                    <div class="col-sm-4" style="text-align: left">
                                                        
                                                        <asp:TextBox ID="txtmrktBus" runat="server" TextMode="MultiLine" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" ></asp:TextBox>

                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtmrktBus" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </div>
                                                  <div class="col-sm-4" style="text-align: left">
                                                    
                                                        <asp:TextBox ID="txtSrcProvd" runat="server" TextMode="MultiLine" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtSrcProvd" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>

                                                   </div>
                                            </div>

                                            <div class="row" >
                                                    <div class="col-sm-4" style="text-align: left">
                                                        <asp:Label ID="Label27" runat="server" Text="Details of other assignment(employment or other connection)" CssClass="control-label"></asp:Label>
                                                        
                                                       
                                                    </div>
                                                       <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="Label28" runat="server" Text="Remark" CssClass="control-label"></asp:Label>
                                                       
                                                    </div>
                                            </div> 
                                         <div class="row">
                                             <div class="col-sm-4" >
                                                  <asp:TextBox ID="txtAsnmnet" runat="server" TextMode="MultiLine"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control " ></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtAsnmnet" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                             </div>
                                             <div class="col-sm-4">
                                                  <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            CssClass="form-control" Width="666px"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtRemark" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>

                                             </div>
                                    </div>
                                      </div>
									 

                                    <%--<asp:Button ID="btnPervPnnel2" runat="server" Text="PREVIOUS" CssClass="btn btn-success"
                                        OnClick="btnPervPnnel2_Click" TabIndex="188"  />--%>

                                               
                                    <%--<asp:Button ID="btnNextPnnel2" runat="server" Text="  NEXT  " CssClass="btn btn-success" 
                                        OnClick="btnNextPnnel2_Click"  TabIndex="188" />--%>												<%--OnClientClick="return funValidatePannel2();"--%>
                                  </div>

                                <div id="div4"  class="card PanelInsideTab" runat="server" style="display: block;">
                                          <div id="Div16" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBackground','btnBackgroundcollapse');return false;">
                                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                      
                        <asp:Label ID="Label29" runat="server" CssClass="control-label HeaderColor"   Text="Background / Experience"></asp:Label>
  
                    </div>
                    <div class="col-sm-2">
                        
                          <span id="btnBackgroundcollapse" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc"></span>

                    </div>
                </div>
            </div>
									<%--<div id="Div16" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBackground','divBackgroundcollapse');return false;">
                                       <div class="row spacebetnrow" id="div15" runat="server" style="text-align: left;">
                                            <div class="col-sm-12">
                                                 <asp:Label ID="Label29" runat="server" CssClass="control-label HeaderColor" 
                                                    Text="Background / Experience"></asp:Label>
                                            </div>
                                        </div>
										</div>--%>
                                    
                                    <div id="divBackground" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                        <div class="row rowspacing" >
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label30" CssClass="control-label" runat="server" Text="Total Experience"></asp:Label>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label35" CssClass="control-label" runat="server" Text="Sector"></asp:Label>
                                            </div>
                                             <div class="col-sm-4" id="divtxtotherSeclbl" runat="server" style="text-align: left"  visible="false"> 
                                                 <asp:Label ID="lblotherSec" CssClass="control-label" runat="server" Text="Other Sector"></asp:Label>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left; display:none;">
                                                
                                                <asp:Label ID="Label31" CssClass="control-label" runat="server" Text="Organization / Insurance Firm associated with" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left;display:none">
                                                 <asp:Label ID="LblTenur" runat="server" Text="Tenure From "></asp:Label>
                                            </div>
                                            </div>

                                            <div class="row" style="margin-bottom: 5px;">
                                                 <div class="col-sm-4" style="text-align: left">
													 <div class="row">
												 <div class="col-sm-8" style="text-align: left">
                                                    <asp:TextBox ID="txtExpernc" runat="server" Width="246px"  
                                                        CssClass="form-control mandatory" MaxLength="2"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                                        FilterType="Numbers" TargetControlID="txtExpernc" ValidChars=" " FilterMode="ValidChars">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
													</div>
													<div class="col-sm-2" style="text-align: left">
                                                    <asp:DropDownList ID="ddlBackgrndYear" runat="server" CssClass="form-control form-select  mandatory " AutoPostBack="true"  TabIndex="22" Width="98px" >
                                                        <asp:ListItem Value="Years">Years</asp:ListItem>
                                                        <asp:ListItem Value="Months"> Months</asp:ListItem>
                                                    </asp:DropDownList>

                                               </div>
												</div>
													 </div>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="txtOrdInc1" runat="server" CssClass="form-control form-select mandatory" TabIndex="22"  OnSelectedIndexChanged="txtOrdInc1_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server"
                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtOrdInc" ValidChars=" " FilterMode="ValidChars">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </div>
                                                   <div id="userinput" runat="server"  class="col-sm-4" visible="false">
                                                    
                                                    <asp:TextBox ID="txtotherSec" runat="server"
                                                        CssClass="form-control mandatory" MaxLength="10"></asp:TextBox>
                                            </div>
                                                 <div class="col-sm-4" style="text-align: left; display:none">
                                                    <asp:TextBox ID="txtOrdInc" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                        CssClass="form-control mandatory"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtOrdInc" ValidChars=" " FilterMode="ValidChars">
                                                    </ajaxToolkit:FilteredTextBoxExtender>

                                                </div>
                                                   <div class="col-sm-4" style="text-align: left;display:none">
                                                        <asp:TextBox ID="txtTenurFrom" runat="server" onmousedown="DatetxtTenurFrom()"
                                                            CssClass="form-control mandatory" ></asp:TextBox>
                                                        <asp:Image ID="Image10" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" Visible="false" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtTenurFrom"
                                                            PopupButtonID="Image10" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true"
                                                            ControlToValidate="txtTenurFrom" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                               <asp:CompareValidator ID="COMPAREVALIDATOR7" runat="server" ErrorMessage="Invalid date!"
                                                   Operator="DataTypeCheck" Type="Date" ControlToValidate="txtTenurFrom" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                               <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtTenurFrom"
                                                   Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                   MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>

                                                  </div>

                                                 

                                            </div>

                                             <div class="row rowspacing" style="margin-bottom: 5px; display:none">
                                                   <div class="col-sm-4" style="text-align: left">
                                                        <asp:Label ID="lbltenur2" CssClass="control-label" runat="server" Text="Tenure To"></asp:Label>
                                                        
                                                        <asp:TextBox ID="txttenur2" runat="server" onmousedown="Datetxttenur2()"
                                                            CssClass="form-control mandatory"></asp:TextBox>

                                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" Visible="false"/>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txttenur2"
                                                            PopupButtonID="Image11" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                                                            ControlToValidate="txttenur2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                               <asp:CompareValidator ID="COMPAREVALIDATOR8" runat="server" ErrorMessage="Invalid date!"
                                                   Operator="DataTypeCheck" Type="Date" ControlToValidate="txttenur2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                               <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txttenur2"
                                                   Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                   MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    </div>
                                            </div>

                                        <div class="row rowspacing">
                                        
                                        </div>
                                            <div class="row rowspacing" style="margin-bottom: 5px;">

                                                <div class="col-sm-12" style="text-align: center">
                                                    <asp:Button ID="btnBackExp" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnBackExp_Click"  
                                                        />						<%--OnClientClick="return funValidatePannel2();"--%>
                                               </div>

                                            </div>

                                            <div class="row rowspacing" style="margin-bottom: 5px;">
                                                    <asp:GridView ID="gvComposite" AutoGenerateColumns="false" OnRowDeleting="gvComposite_RowDeleting" AutoGenerateDeleteButton="false" runat="server"
                                                         Style="width: 100%;" CssClass="footable"
                                                         CellPadding="4">

                                                        <%--<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                        <SortedDescendingHeaderStyle BackColor="#002876" />--%>
                                                          <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Experience">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExperience" runat="server" Text='<%# Bind("Experience") %>'></asp:Label>

                                                                </ItemTemplate>
 <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Experience Year">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExpTime" runat="server" Text='<%# Bind("ExpTime") %>'></asp:Label>

                                                                </ItemTemplate>
 <ItemStyle CssClass="clsLeft" />
                                                        <HeaderStyle CssClass="clsLeft" />
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Sector">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOrganization" runat="server" Visible="false" Text='<%# Bind("Organization") %>'></asp:Label>
                                                                    <asp:Label ID="lblOthSectDesc" runat="server" Text='<%# Bind("OthSectDesc") %>'></asp:Label> 
                                                                </ItemTemplate>
 <ItemStyle CssClass="clsLeft" />
                                                        <HeaderStyle CssClass="clsLeft" />
                                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Other Sector">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblotherssectors" runat="server" Text='<%# Bind("OtherSector") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                 <ItemStyle CssClass="clsLeft" />
                                                        <HeaderStyle CssClass="clsLeft" />
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="Tenure From">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTenureFrom" runat="server" Text='<%# Bind("TenureFrom") %>'></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tenure To">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTenureTo" runat="server" Text='<%# Bind("TenureTo") %>'></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                                                             
                                                            

                                                            
                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="delete" />

                                                                </ItemTemplate>
<ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                            </asp:TemplateField>



                                                        </Columns>

                                                    </asp:GridView>
                                                
                                            </div>
                                    </div>
                                    <br />
                                     <div class="row">
                                    <div class="col-sm-12" style="text-align:center;">
 <asp:LinkButton ID="btnPervPnnel2" runat="server"   CssClass="btn btn-success  "  OnClick="btnPervPnnel2_Click"> <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS </asp:LinkButton> 
                                                 <asp:LinkButton  ID="btnNextPnnel2" runat="server"  CssClass="btn btn-success "  OnClick="btnNextPnnel2_Click" OnClientClick="return funValidatePannel2();">  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> <%--OnClientClick="return funValidatePannel2();"--%>
                                    </div>
                                     
                                </div>
                                         </div>
                               
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="Updatepanel6" runat="server">
                        <ContentTemplate>
                            <div id="divPannel3"  runat="server" visible="false" >
                                <div class="card PanelInsideTab">
                                <div id="Div18" runat="server" class="panelheadingAliginment" >
                                     <div class="row spacebetnrow" id="div17" runat="server" style="text-align: left;">
                                        <div class="col-sm-10">
                                            <asp:Label ID="lblHirarchyDtlshdr" runat="server" CssClass="control-label HeaderColor" 
                                                Text="Hierarchy Details"></asp:Label>
                                        </div>
                                          <div class="col-sm-2">
                        
                          <span id="btnHD" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divHirarchyDtls','btnHD');return false;"></span>

                    </div>
                                    </div>
                                </div>
                                    
                                <div id="divHirarchyDtls" runat="server" style="display: block;" class="panelContent spacebetnrow" width="100%">
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-4" style="text-align: left">
<asp:Label ID="lblchnltype" runat="server" CssClass="control-label labelSize"></asp:Label>
                                        </div>
                                          <div class="col-sm-4" style="text-align: left;padding-left:5px;">
                                                    <asp:Label ID="lblBusinessSrc" runat="server" Font-Bold="False" CssClass="control-label labelSize"></asp:Label>
                                        </div>
                                          <div class="col-sm-4" style="text-align: left;padding-left:0px;">
                                               
                                                    <asp:Label ID="lblChnCls" runat="server" CssClass="control-label labelSize"></asp:Label>
                                        </div>
                                       <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-sm-4" style="text-align: left">
                                                
                                                <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                                    <ContentTemplate>
                                                        <asp:RadioButtonList ID="rdbChnlTyp" runat="server" CssClass="form-control mandatory" style="background-color: #e9ecef;" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                                            RepeatDirection="Horizontal" TabIndex="20">
                                                            <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                           </div>
                                           <div class="col-sm-4" style="text-align: left">
                                                
                                                <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="form-control mandatory" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" 
                                                            TabIndex="22" >
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                             <div class="col-sm-4" style="text-align: left">
                                               
                                                <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control mandatory" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" TabIndex="23"
                                                            >
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlSlsChannel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>

                                           </div>
                                           <div class="col-sm-4" style="text-align: left;display:none">
                                                <asp:Label ID="lblCntDetails" runat="server" Visible="false"></asp:Label>
                                                <asp:LinkButton ID="lnbViewCntDetails" runat="server" TabIndex="21" Visible="false">View Details</asp:LinkButton>
                                           </div>
                                        </div>
                                        <div class="row rowspacing" style="margin-bottom: 5px;">
                                            <div class="col-sm-4" style="text-align: left">
                                                    <asp:Label ID="lblVw1AgntType" runat="server" Font-Bold="False" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="upnlAgnType">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlAgntType" runat="server" CssClass="form-control form-select mandatory" AutoPostBack="True"
                                                             OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged"
                                                            TabIndex="24" >
                                                            <asp:ListItem Text="Select" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblAgntClass" runat="server" Visible="false" Font-Bold="False"></asp:Label>
                                                <asp:Label ID="lblConstTyp" runat="server" Text="Member Entity" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel ID="updLicTyp" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlLicTyp" runat="server" CssClass="form-control form-select mandatory"
                                                           AutoPostBack="True" 
                                                            OnSelectedIndexChanged="ddlLicTyp_SelectedIndexChanged" TabIndex="26">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:DropDownList ID="ddlAgntClass" runat="server" CssClass="form-control"
                                                    Enabled="false"
                                                    TabIndex="25" Visible="false">
                                                    <asp:ListItem Value="NM" Text="Staff"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                       </div>
                                </div>

                               

                             
									<%--changes has not been done due to Non-Existence--%>
                               								





                             




                            </div>
                                    </div>
                                 <div id="tblUnitCodeDetails" visible="true" runat="server" class="card PanelInsideTab">
                                   <div id="Div20" runat="server" class="panelheadingAliginment">
                                        <div class="row spacebetnrow" id="div19" runat="server" style="text-align: left;">
                                           <div class="col-sm-10">
                                                <asp:Label ID="Label11" runat="server" Text="Unit Code Details" CssClass="control-label HeaderColor" ></asp:Label>
                                           </div>
                                             <div class="col-sm-2">
                        
                          <span id="btnUC" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divuntcode','btnUC');return false;"></span>

                    </div>
                                        </div>
                                   </div>
                                    <div id="divuntcode" runat="server" style="display: block;" width="100%" class="panelContent spacebetnrow">
                                       
                                            <div class="row" style="margin-bottom: 5px;"> 
                                                <div class="col-sm-12" style="text-align: left">
                                                    <asp:UpdatePanel ID="upUnitCode" runat="server">
                                                        <ContentTemplate>
                                                           <div class="row" style="margin-bottom: 5px;"> 
                                                                   <div class="col-sm-4" style="text-align: left">
                                                                       <asp:Label ID="lblUntCde" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                                       </div>
                                                               </div>
                                                               <div class="row" style="margin-bottom: 5px;"> 
                                                                   <div class="col-sm-3" style="text-align: left">
                                                                        <asp:UpdatePanel ID="upnlBtnUnitCode" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtUntCode" runat="server" Enabled="false" 
                                                                                    CssClass="form-control mandatory" MaxLength="10" TabIndex="58" 
                                                                                    onblur="funblankUntCode();return false;"></asp:TextBox>
                                                                               
                                                                                <asp:Button ID="btnSalesUnitCode" runat="server" CssClass="form-control mandatory"
                                                                                    TabIndex="29" Text="...." Visible="false"  />

                                                                                <asp:Label ID="lblUnitDesc" runat="server" Style="display: none;"></asp:Label>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlAgntType"
                                                                                    EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                        <asp:Label ID="lblUntCode" runat="server"></asp:Label>
                                                                    </div>
                                                                   <div class="col-sm-1">
                                                                        <asp:Button ID="btnUnitCode" runat="server" CssClass="btn btn-success Prefix1"
                                                                                    TabIndex="59" Text="...."  />
                                                                   </div>
                                                                   <div class="col-sm-3" style="text-align: left">
                                                                        <asp:UpdatePanel ID="upunadr" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <asp:Label ID="lblUntAddr" runat="server" Text=""></asp:Label>
                                                                                <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static" Style="display: none;" />
                                                                                <asp:HiddenField ID="hdnutadr" runat="server" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                               </div>

                                                                <div class="row" style="margin-bottom: 5px;"> 
                                                                    
                                                                        <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                                            AllowSorting="true" Width="100%" CssClass="footable"
                                                                            PageSize="8" >
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Unit Code" HeaderStyle-CssClass="pad" SortExpression="UnitCode">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Width="10%" />
                                                                                    <ItemStyle CssClass="pad" HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Unit Description" HeaderStyle-CssClass="pad1" SortExpression="UnitDesc01">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Width="20%" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Unit Type" HeaderStyle-CssClass="pad1" SortExpression="UnitTypDesc">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Width="20%" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Unit Address" HeaderStyle-CssClass="pad1" SortExpression="Adr1">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                             <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                                        </asp:GridView>
                                                                    
                                                               </div>
                                                           
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                           </div>
                                       
                                    </div>
                                     
                                </div>
                                 <asp:UpdatePanel runat="server" ID="updReportingMngrDtls">
                                    <ContentTemplate>
                                        <div id="tblReportingMngrDtls" visible="true" runat="server" class="card PanelInsideTab">


                                            <div id="trprirep" runat="server" style="margin-top: 5px">
                                                <div runat="server" class="panelheadingAliginment">
                                     <div class="row spacebetnrow"  runat="server" style="text-align: left;">
                                        <div class="col-sm-10" style="text-align:left;">
                                                            <asp:Label ID="lblPrimaryReportinghdr" runat="server" CssClass="control-label HeaderColor" Text="Parental Reporting"></asp:Label>
                                        </div>
                                         <div class="col-sm-2">
                        
                          <span id="btnRP" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divprirep','btnRP');return false;"></span>

                    </div>
                                    </div>
                                </div>

<div id="divprirep" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                        <div class="row rowspacing" style="display:none;">
                                            <div class="col-sm-4">
                                                  <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type"></asp:Label>
                                            </div>

                                        </div>
                                        <div class="row" style="display:none;">
                                            <div class="col-sm-3">
                                                                                                                <asp:DropDownList ID="ddlventype" runat="server" 
                                                                                                        AutoPostBack="True" CssClass="form-control"
                                                                                                        OnSelectedIndexChanged="ddlventype_SelectedIndexChanged" TabIndex="27">
                                                                                                    </asp:DropDownList>
                                                               
                                            </div>
                                            <div class="col-sm-1">
                                                 <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" TabIndex="28" AutoPostBack="true" />
                                        </div>

                                        </div>
                                       <div class="row rowspacing" style="margin-bottom: 5px;display:none;">
                                           <div class="col-sm-4" style="text-align: left">
<asp:Label ID="lblreportingtypeh" runat="server" Text="Reporting Type"></asp:Label>
                                                           
                                                                <asp:DropDownList ID="ddlamrptdesc" runat="server" Height="19px" 
                                                                    Enabled="False" CssClass="form-control" TabIndex="29">
                                                                </asp:DropDownList>
                                           </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblbasedon" runat="server" Text="Based On"></asp:Label>
                                                            
                                                                <asp:DropDownList ID="ddlambasedondesc" runat="server" Enabled="False"
                                                                     CssClass="form-control" TabIndex="30">
                                                                </asp:DropDownList>
                                           </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblchannel" runat="server"></asp:Label>
                                                            
                                                                <asp:DropDownList ID="ddlamchnldesc" runat="server" Height="19px"
                                                                    Enabled="False" CssClass="form-control" TabIndex="31">
                                                                </asp:DropDownList>
                                           </div>
                                           </div>
                                       <div class="row rowspacing" style="margin-bottom: 5px;">
                                         <div class="col-sm-4" style="text-align: left;display:none">
                                 <asp:Label ID="lblsubchannel" runat="server" Width="120px"></asp:Label>
                            </div>
                                         <div class="col-sm-4" style="text-align: left;">
                                             <asp:Label ID="lbllevelagttype" runat="server" CssClass="control-label labelSize"></asp:Label>
                                         </div>
                                         <div class="col-sm-4" style="text-align: left">
                                              <asp:Label ID="lblReportingMgr" runat="server" Text="Parental Reporting Code"></asp:Label><%--<asp:Label ID="lbpri" Text="*" runat="server" ForeColor="Red" />--%>
                                         </div>
                                                               </div>
                                       <div class="row " style="margin-bottom: 5px;">
        <div class="col-sm-4" style="display:none;">
            <asp:DropDownList ID="ddlamsubchnldesc" runat="server"  Enabled="False" CssClass="form-control"
                                                                    TabIndex="32">
                                                                </asp:DropDownList>

        </div>
        <div class="col-sm-4">
             <asp:DropDownList ID="ddllvlagttype" runat="server" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddllvlagttype_SelectedIndexChanged"
                                                                     Enabled="False" CssClass="form-control form-select" TabIndex="35">
                   <%--<asp:ListItem Text="Independent" Value=""></asp:ListItem>--%>
                                                                </asp:DropDownList>

        </div>
        <div class="col-sm-3" style="display:flex">
            <asp:UpdatePanel runat="server" ID="updPnl_txtRptCode" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtRptMgr" runat="server" CssClass="form-control" style="width:280px;" Enabled="false"
                                                                            TabIndex="33" onblur="funblankRptMgr();return false;"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                                                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                                                        <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                                                        <asp:Button ID="btnmemgrid" runat="server" OnClick="btnmemgrid_Click" ClientIDMode="Static" Style="display: none;" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
			&nbsp;&nbsp;
           <asp:Button ID="btnRptMgr" runat="server" style="height:35px;" CssClass="btn btn-success Prefix1" Text="...." 
                                                                            TabIndex="34" />

        </div>
<%--       <div class="col-sm-1">
           <asp:Button ID="btnRptMgr" runat="server" CssClass="btn btn-success Prefix1" Text="...." 
                                                                            TabIndex="34" />
       </div>--%>
    </div>
    </div>
                                                
                                                <div id="d1" runat="server" class="rowspacing" style="display:block" width="100%">
                                                    <div class="container">
                                                        <div class="row" id="trventype" runat="server" style="height: 25px;">
                                                        </div>
                                                       
                                                            <div class="row">
                                                                <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Border="none"
                                                                    PageSize="10" Width="100%" CssClass="gv1">
                                                                        <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridviewth" />
                            <PagerStyle CssClass="disablepage" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-CssClass="pad" HeaderText="Member Code" SortExpression="MemCode">
                                                                            <ItemTemplate>
                                                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        <ItemStyle CssClass="pad" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="pad1" HeaderText="Employee Name" SortExpression="Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                           <ItemStyle CssClass="pad1" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="pad1" HeaderText="Member Type" SortExpression="MemType">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="pad1" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="pad" HeaderText="Unit Code">
                                                                            <ItemTemplate>
                                                                                <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                             <ItemStyle CssClass="pad" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                       
                                                    </div>
                                                </div>
                                            </div>

                                          

                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                                  <div id="traddlrep" runat="server" class="card PanelInsideTab">
                                                <div runat="server" class="panelheadingAliginment">
                                     <div class="row spacebetnrow"  runat="server" style="text-align: left;">
                                        <div class="col-sm-10">
                                                            <asp:Label ID="lblMngrdtlshdr" runat="server" Text="Managers Details" CssClass="control-label HeaderColor"></asp:Label>
                                        </div>
                                         <div class="col-sm-2">
                        
                          <span id="btnAR" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMngrDtls','btnAR');return false;"></span>

                    </div>
                                    </div>
                                </div>
                                                <div id="divMngrDtls" runat="server" class="panel-body panelContent spacebetnrow" width="100%">
    <div class="row">
        <div class="col-sm-12" style="text-align:left;">
             <asp:Label ID="lbladditionalreporting" runat="server" Text="Additional Reporting Rule"></asp:Label>
             <asp:Label ID="lbladditionalreportingrule" runat="server"></asp:Label>
                                                                <asp:Label ID="lblRptMngrErr" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="row rowspacing">
         <asp:GridView ID="gv_RptMngr" runat="server" AllowPaging="True" AllowSorting="True" CssClass="gv1"
                                                                    AutoGenerateColumns="False" PageSize="5" Width="100%"
                                                                    OnRowDataBound="gv_RptMngr_RowDataBound">
                                                                    <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                                            <ItemTemplate>
                                                                                <div class="container">
                                                                                    <div runat="server" class="panelheadingAliginment">
                                                                                    <div class="row spacebetnrow" style="text-align: left;">
                                                                                          <div class="col-sm-12">
                                                                                              <asp:Label ID="lblMgrHdr" runat="server" Height="19px" Font-Bold="true" Text="Additional Manager"></asp:Label>
                                                                                            <asp:Label ID="lblNo" runat="server" Height="19px" Font-Bold="true" Text='<%# Bind("Mngr") %>'></asp:Label>
                                                                                            <asp:Label ID="lblord" runat="server" Height="19px" Visible="false" Text='<%# Bind("RelOrder") %>'></asp:Label>
                                                                                    </div>
                                                                                    </div>
                                                                                  </div>
                                                                                    <div class="row rowspacing">
                                                                                          <div class="col-sm-4" style="text-align: left;">
                                                                                               <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" CssClass="control-label"/>
                                                                                              <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control" Height="19px" >
                                                                                            </asp:DropDownList>
                                                                                    </div>
                                                                                         <div class="col-sm-4" style="text-align: left;">
                                                                                             <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" CssClass="control-label"/>
                                                                                               <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control" Height="19px">
                                                                                                </asp:DropDownList>
                                                                                    </div>
                                                                                         <div class="col-sm-4" style="text-align: left;">
                                                                                             <asp:Label ID="lblAdlChn" runat="server" Text="Channel" CssClass="control-label"/>
                                                                                              <asp:DropDownList ID="ddlAdlChn" runat="server" CssClass="form-control"
                                                                                                Height="19px"  AutoPostBack="true"
                                                                                                OnSelectedIndexChanged="ddlAdlChn_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                    </div>

                                                                                    </div>
                                                                                    <div class="row rowspacing">
                                                                                        <div class="col-sm-4" style="text-align: left">
                                                                                            <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" CssClass="control-label"/>
                                                                                        </div>
                                                                                        <div class="col-sm-4" style="text-align: left">
                                                                                            <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" CssClass="control-label"/>
                                                                                        </div>
                                                                                        <div class="col-sm-4" style="text-align: left">
                                                                                            <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" CssClass="control-label"/>
                                                                                            <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row ">
                                                                                        <div class="col-sm-4">
                                                                                             <asp:DropDownList ID="ddlAdlSChn" runat="server" CssClass="form-control"
                                                                                                Height="19px" 
                                                                                                OnSelectedIndexChanged="ddlAdlSChn_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" CssClass="form-control form-select" AutoPostBack="true"
                                                                                                 OnSelectedIndexChanged="ddlAdlAgtTyp_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </div>
                                                                                        <div class="col-sm-3" style="display:flex;">
                                                                                            <asp:UpdatePanel runat="server">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox ID="txtRptMngr" runat="server" Enabled="false" style="width:280px;" CssClass="form-control"></asp:TextBox>
                                                                                                    <asp:Label ID="lblRptMngr" runat="server" />
                                                                                                 
                                                                                                    <asp:Button ID="btnRptmemgrid" runat="server" OnClick="btnRptmemgrid_Click" ClientIDMode="Static" Style="display: none;" />
                                                                                                    <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                                                                    <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                                                                    <asp:HiddenField ID="hdnAddlStp" runat="server" />
                                                                                                    <asp:HiddenField ID="hdnAdMemType" runat="server" />
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
																							&nbsp;&nbsp;
																							<asp:Button ID="lnkRptMngr" style="height:35px;" runat="server" Text="...." OnClick="lnkRptMngr_Click"
                                                                                                        CssClass="btn btn-success Prefix1" ></asp:Button>
                                                                                        </div>
<%--                                                                                         <div class="col-sm-1">
                                                                                                <asp:Button ID="lnkRptMngr" runat="server" Text="...." OnClick="lnkRptMngr_Click"
                                                                                                        CssClass="btn btn-success Prefix1" ></asp:Button>
                                                                                    </div>--%>
                                                                                        </div>
                                                                                </div>
                                                                                <div id="trVenType" runat="server" class="container rowspacing">
                                                                                    <div class="row" style="text-align:left;display:none;">
                                                                                        <div class="col-sm-4">
                                                                                             <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" CssClass="control-label"/>
                                                                                        </div>
                                                                                         <div class="col-sm-4">
                                                                                            <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model" CssClass="control-label"></asp:Label>

                                                                                        </div>
                                                                                         <div class="col-sm-4">

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row"  style="text-align:left;display:none">
                                                                                        <div class="col-sm-3">
                                                                                            <asp:DropDownList ID="ddlAddlventype" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                                                OnSelectedIndexChanged="ddlAddlventype_SelectedIndexChanged">
                                                                                            </asp:DropDownList>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" TabIndex="54" AutoPostBack="true" />

                                                                                            </div>
                                                                                         <div class="col-sm-4">
                                                                                              <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                                                            </asp:DropDownList>
                                                                                            <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details" TabIndex="50" />
                                                                                        </div>
                                                                                         <div class="col-sm-4">

                                                                                        </div>
                                                                                    </div>
                                                                                
                                                                                            <asp:GridView ID="gvAddlMgr" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="gv1"
                                                                                                PageSize="10" Width="100%">
                                                                                                <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridviewth" />
                            <PagerStyle CssClass="disablepage" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderStyle-CssClass="pad" HeaderText="Member Code" SortExpression="MemCode">
                                                                                                        <ItemTemplate>
                                                                                                            <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                                            <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle CssClass="pad" HorizontalAlign="Center" Width="20%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderStyle-CssClass="pad1" HeaderText="Employee Name" SortExpression="Name">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle CssClass="pad1" HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderStyle-CssClass="pad1" HeaderText="Member Type" SortExpression="MemType">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle CssClass="pad1" HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderStyle-CssClass="pad" HeaderText="Unit Code">
                                                                                                        <ItemTemplate>
                                                                                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                                                            <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                         <ItemStyle CssClass="pad" HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>

                                                                                    </div>
                                                                            </ItemTemplate>
                                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
    </div>
</div>
                                        <div class="row">
                                      <div class="col-sm-12" style="text-align:center">
                                          <asp:LinkButton ID="bntBack" runat="server"   CssClass="btn btn-success  "  OnClick="bntBack_Click"> <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS </asp:LinkButton> 
                                                 <asp:LinkButton  ID="btnNextPannel3" runat="server"  CssClass="btn btn-success "  OnClick="btnNextPannel3_Click" OnClientClick="funValidate()">  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 

                                      </div>
                                  </div>
                                            </div>
                                
                                
                                <%--<asp:Button ID="btnNextPannel3" runat="server" Text="NEXT" CssClass="btn btn-success"  TabIndex="188" OnClick="btnNextPannel3_Click" OnClientClick="funValidate()"/>--%><%----%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="Updatepanel8" runat="server">
                        <ContentTemplate>
                            <div  id="divPannel5" runat="server" visible="false">
                                <div  class="card PanelInsideTab">
                                    <div id="Div22" runat="server" class="panelheadingAliginment">
                                   <div class="row spacebetnrow" id="div21" runat="server" style="text-align: left;">
                                       <div class="col-sm-10">
                                            <asp:Label ID="Label14" runat="server" CssClass="control-label HeaderColor" 
                                                Text="Franchisee Bank Details"></asp:Label>
										</div>
                                       <div class="col-sm-2">
                          <span id="btnFBD" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBankDtls','btnFBD');return false;"></span>
                    </div>
                                    </div>
                                </div>
                                <div id="divBankDtls" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                       <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblBankAccHolderName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                               
													
												
                                                <asp:TextBox ID="txtBankHolderName" CssClass="form-control mandatory" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="172" ></asp:TextBox>
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="cvHolderName" runat="server" ErrorMessage="Invalid Characters!"
                                                    Display="Dynamic" ClientValidationFunction="doValidateName" ControlToValidate="txtBankHolderName"></asp:CustomValidator>

                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender75" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                                    TargetControlID="txtBankHolderName">
                                                </ajaxToolkit:FilteredTextBoxExtender>

                                           </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblBankAccNo" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:TextBox ID="txtBankAccNo" runat="server" CssClass="form-control mandatory" 
                                                    TabIndex="171" MaxLength="20"  AutoPostBack="true"></asp:TextBox>

                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender85" runat="server"
                                                    FilterType="Numbers,Custom"
                                                    TargetControlID="txtBankAccNo">
                                                </ajaxToolkit:FilteredTextBoxExtender>

                                            </div>
                                              <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label7" runat="server" Text="IFSC Code" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:UpdatePanel runat="server" ID="updatepnlPayMode">
                                                    <ContentTemplate>                                
                                                        <asp:Button ID="btnVerifyNeft" runat="server" Style="display: none;" CssClass="btn btn-success"
                                                            CausesValidation="False" Text="Verify"  TabIndex="174" UseSubmitBehavior="false"
                                                            OnClick="btnVerifyNeft_Click" />
                                                        <span style="color: #ff0000">
                                                            <asp:TextBox ID="txtNeftCode" runat="server" CssClass="form-control mandatory" OnTextChanged="txtNeftCode_TextChanged" AutoPostBack="true"
                                                                Style="text-transform: uppercase;"  TabIndex="107" MaxLength="11" ></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender87" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers"
                                                                TargetControlID="txtNeftCode">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </span>
                                                        <span id="spanifsccode" runat="server" style="color: red; display: none;">Incorrect Bank IFSC Code
                                                        </span>


                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnVerifyNeft" EventName="Click"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>        
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-sm-3" style="text-align: left;display:none">
                                                <asp:UpdatePanel runat="server" ID="updtnpnlPayMode">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblBranchName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPaymentMode" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                      </div>
                                       <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label4" runat="server" Text="Bank Name" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:UpdatePanel runat="server" ID="updtpnlPayMode">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control mandatory"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                            TabIndex="175" ></asp:TextBox>
                                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtBankName" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>

                                                        </asp:UpdatePanel>
                                           </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblBnkAddress" runat="server" Text="Bank Branch Address" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:TextBox ID="txtBnkAddress" CssClass="form-control mandatory" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="172"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" InitialValue="none" ValidationGroup="agtValGrp" SetFocusOnError="true"
                                                    ControlToValidate="txtBnkAddress" ErrorMessage="Enter Bank Address" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                                    TargetControlID="txtBnkAddress">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label15" runat="server" Text="Account Type" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:DropDownList ID="ddlactype" runat="server" CssClass="form-control form-select mandatory"  TabIndex="107" >
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                                    <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                       </div>
                                       <div class="row rowspacing" style="margin-bottom: 5px;">
                                           <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label16" runat="server" Text="MICR Code" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtmcrcode" runat="server" CssClass="form-control"
                                                            TabIndex="175"  MaxLength="9"></asp:TextBox>

                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
									                          FilterType="Numbers" TargetControlID="txtmcrcode" ValidChars=" " FilterMode="ValidChars">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left;display:none">
                                                <asp:Label ID="Label6" runat="server" Text="Bank Branch Name" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="updtnlPayMode">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtBnkBrnchName" runat="server" CssClass="form-control"
                                                            TabIndex="176" ></asp:TextBox>
                                                     </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnVerifyNeft" EventName="Click"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left;display:none">
                                                <asp:Label ID="lblDeductTax" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="upnlDedctTax">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlDeductTax" runat="server" CssClass="form-control" 
                                                            TabIndex="177">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;display:none">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblTaxCode" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="upnlTaxCode">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlTaxCode" runat="server" CssClass="form-control"
                                                            TabIndex="178" >
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                           </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblCommCls" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:UpdatePanel runat="server" ID="upnlComm">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlCommCls" runat="server" CssClass="form-control"
                                                            TabIndex="179">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblPayFreq" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                <asp:DropDownList ID="ddlPayFrequency" runat="server" CssClass="form-control"
                                                    TabIndex="180" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row" style="text-align: left;display:none">
                                            
                                       </div>
                                        <div class="row" style="margin-bottom: 5px;display:none">
                                           <div class="col-sm-2" style="text-align: left">
                                                <asp:Label ID="lblAccPayee" runat="server" CssClass="control-label labelSize"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtAccPayee" runat="server"  CssClass="form-control"
                                                            MaxLength="10" TabIndex="181"></asp:TextBox>
                                                        <asp:Button ID="btnAccPayee" runat="server" CssClass="btn btn-success" Text="...."
                                                             ToolTip="Search Customer ID" UseSubmitBehavior="False" TabIndex="182" />
                                                        <asp:Label ID="lblAccPayeeDesc" runat="server"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="txtBankAccNo" EventName="TextChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                           </div>
                                            <div class="col-sm-2" style="text-align: left">
                                                <asp:Label ID="lblMinAmt" runat="server" CssClass="control-label labelSize"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtMinAmt" runat="server" CssClass="form-control" 
                                                    Enabled="False" MaxLength="20" TabIndex="184"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" ControlToValidate="txtMinAmt"
                                                    ErrorMessage="Invalid Amount!" ID="regexp_minAmt" runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </div>
                                       </div>
										<div class="row" id="trparentchild" runat="server" style="margin-bottom: 5px;display:none;visibility:hidden">
                                            <div class="col-sm-2" style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label labelSize"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" Enabled="False"
                                                    TabIndex="185"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:LinkButton ID="lnkbtn_parentchild" runat="server">Parent Child link</asp:LinkButton>
                                            </div>
                                           <div class="col-sm-3" style="text-align: left">
                                                <asp:LinkButton ID="lnkbtn_childparent" runat="server">Child Parent link</asp:LinkButton>
                                            </div>
                                        </div>
											<div class="row" id="trPartnerField" runat="server" style="margin-bottom: 5px;display:none;visibility:hidden">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblPartnerName" runat="server" Text="Partner Name"></asp:Label>
                                           </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtPartnerName" runat="server" CssClass="form-control"
                                                  TabIndex="186"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblPartnerCode" runat="server" Text="Partner Code"></asp:Label>
                                           </div>
                                           <div class="col-sm-3" style="text-align: left">
                                                <asp:TextBox ID="txtPartnerCode" runat="server" CssClass="form-control"
                                                    TabIndex="187"></asp:TextBox>
                                           </div>
                                        </div>
                                        <tr id="trrecruitinfo" runat="server" visible="false">
                                            <td colspan="4">
                                                <table>
                                                    <tr>
                                                        <td align="left" class="test" colspan="7">
                                                            <asp:Label ID="lblReportingInfohdr" runat="server" Text="Recruiting Info / Reporting Info"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblRecruitDate" runat="server"></asp:Label>
                                                            
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtRecruitDate" Width="80px" />
                                                            <asp:Image ID="btnCalendar" onclick="client_function()" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                                                                runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtRecruitDate"
                                                                PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ValidationGroup="agtValGrp" ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtRecruitDate"
                                                                Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator><span style="padding-left: 3px;"></span><%--Added:Parag--%>
                                                            <asp:CompareValidator ValidationGroup="agtValGrp" ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                                Type="Date" ControlToValidate="txtDtValidate" Display="Dynamic"></asp:CompareValidator><span style="padding-left: 3px;"></span><%--Added:Parag--%>
                                                            <asp:RangeValidator ValidationGroup="agtValGrp" ID="RGV" runat="server" ControlToValidate="txtDtValidate" Display="Dynamic"
                                                                ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                                Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblBranchCode" runat="server" Height="19px" Width="128px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtBranchCode" runat="server" CssClass="standardtextbox" Width="81px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="False"></asp:Label>
                                                            
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtRecruitAgntCode" runat="server" CssClass="standardtextbox" Width="80px"
                                                                MaxLength="10"></asp:TextBox>
                                                            <asp:Button ID="btnRecAgnCode" runat="server" CssClass="standardbutton" Text="...." />
                                                            <asp:Label ID="lblRecruitAgtName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblAraCde" runat="server" Width="108px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtAreCode" runat="server" CssClass="standardtextbox" Width="82px"></asp:TextBox>
                                                            <asp:Label ID="lblAreaDesc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblMngrCode" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent" style="width: 184px">
                                                            <asp:TextBox ID="txtMngrCode" runat="server" CssClass="standardtextbox" Width="68px"
                                                                MaxLength="10" Visible="false"></asp:TextBox>
                                                            <asp:Button ID="btnMngrCodeSearch" runat="server" CssClass="standardbutton" Text="...."
                                                                Width="20px" Visible="false" />
                                                            <asp:Label ID="lblMngrName" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblAgntPrefix" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:UpdatePanel runat="server" ID="upnlAgntPrefix">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblCSCPrefix" runat="server" __designer:wfdid="w1" TabIndex="47"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent" style="width: 289px">
                                                            <asp:Label ID="lblImmLeader" runat="server" Width="184px"></asp:Label>
                                                            <span style="font-size: 10pt; color: #ff0000"></span>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:UpdatePanel runat="server" ID="upnlImmLeaderCode">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtImmLeaderCode" runat="server" CssClass="standardtextbox" Width="80px"
                                                                        MaxLength="10" Enabled="false"></asp:TextBox>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <asp:UpdatePanel runat="server" ID="upnlImmLeaderCodeBtn">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnImmLeaderCode" runat="server" CssClass="standardbutton" Text="...."
                                                                        Width="20px" Enabled="false" __designer:wfdid="w3"></asp:Button>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <asp:UpdatePanel runat="server" ID="upnlImmCDAlbl">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblImmCDA" runat="server" Visible="False" Text="Please enter the Immediate Franchisee Code"
                                                                        __designer:wfdid="w2" ForeColor="Red"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <span style="padding-left: 3px;"></span><span style="padding-left: 3px;"></span>
                                                            <asp:Label ID="lblDirectAgtName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblCscCode" runat="server"></asp:Label>
                                                            
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtSmCode" runat="server" CssClass="standardtextbox" Width="82px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="Label5" runat="server" Width="74px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:LinkButton ID="lbtnAgnOrDetails" runat="server" Width="124px">Agent OR Details</asp:LinkButton>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lblEmpCode" runat="server" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="font-size: 7pt;" align="left">
                                                            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="TextBox" Width="82px" MaxLength="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:UpdatePanel runat="server" ID="UpdPnllblDOJ">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lbldoj" Text="Date Of Joining" runat="server" Visible="false" Width="134px"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <asp:UpdatePanel runat="server" ID="UpdPnlspndoj">
                                                                <ContentTemplate>
                                                                    <span runat="server" id="spndoj" style="font-size: 10pt; color: #ff0000" visible="false">*</span>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:UpdatePanel runat="server" ID="UpdPnltxtDoj">
                                                                <ContentTemplate>
                                                                    <uc3:ctlDate ID="txtdoj" runat="server" CssClass="standardtextbox" Width="90" Visible="false" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <asp:TextBox ID="txtdt" runat="server" Visible="false"></asp:TextBox>
                                                            <asp:Label ID="lblUnitCodeComp" runat="server" Text="" Visible="False" Width="99px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent"></td>
                                                        <td align="left" class="formcontent"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblDtTerminated" runat="server" Width="134px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <uc3:ctlDate ID="txtCeaseDate" runat="server" CssClass="standardtextbox" Width="90" />
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblCompUntCde" runat="server" Width="135px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtCmpUntCode" runat="server" CssClass="standardtextbox" Width="82px"
                                                                MaxLength="10"></asp:TextBox>
                                                            <asp:Label ID="lblCmpUntDesc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lblBlkLstStatus" runat="server" Width="134px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:DropDownList ID="ddlBlkLstStatus" runat="server" CssClass="form-control" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:LinkButton ID="LnkMaptoVendor" runat="server" Style="display: none;"> Map to vendor</asp:LinkButton>
                                                        </td>
                                                        <td class="formcontent" align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <asp:Label ID="lbl_AppDate" Text="Application Date" runat="server"></asp:Label><span
                                                                style="font-size: 10pt; color: #ff0000">*</span>
                                                        </td>
                                                        <td class="formcontent" style="width: 210px; height: 21px" align="left">
                                                            <asp:UpdatePanel runat="server" ID="upnltxtDTJoin">
                                                                <ContentTemplate>
                                                                    <uc3:ctlDate ID="txtDTJoinFrom" Visible="false" runat="server" CssClass="standardtextbox"
                                                                        Width="90" RequiredField="false" />
                                                                    <asp:TextBox ID="txtTemp" runat="server" Visible="true" CssClass="standardtextbox"
                                                                        Width="82px" MaxLength="10"></asp:TextBox>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:Label ID="lbl_AppNo" Text="Application No" runat="server" Width="135px"></asp:Label>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:UpdatePanel runat="server" ID="upnlAppNo">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txt_AppNo" Enabled="true" runat="server" CssClass="standardtextbox"
                                                                        Width="82px" MaxLength="10"></asp:TextBox>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                </div>
                                </div>
                                
                                        <div class="card PanelInsideTab">
  <div id="Div24" runat="server" class="panelheadingAliginment">
                                    <div class="row spacebetnrow" id="div23" runat="server" style="text-align: left;">
                                         <div class="col-sm-10">
                                           <%-- <input runat="server" type="button" class="standardlink" value="-" id="divNomineecollapse"
                                                 onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNominee', 'ctl00_ContentPlaceHolder1_divNomineecollapse');" />--%>
                                            <asp:Label ID="lblNominee" runat="server" CssClass="control-label HeaderColor" 
                                                Text="Nominee Details"></asp:Label>
                                        </div>
                                           <div class="col-sm-2">
                          <span id="btnND" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;color:#00cccc" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNominee','btnND');return false;"></span>
                    </div>
                                    </div>
                               </div>
                                <div id="divNominee" runat="server" style="display: block;" class="panel-body panelContent spacebetnrow" width="100%">
                                    <div class="row " style="text-align:left;">
                                       
                                              <div class="col-sm-1" style="width:1px">
                                                   <asp:Label ID="Label36" runat="server" style="display: none;"></asp:Label><span style="padding-left: 3px;"></span>
                                                  <asp:CheckBox ID="Chknominee" runat="server" OnCheckedChanged="Chknominee_CheckedChanged" AutoPostBack="true"
                                                    CssClass="standardcheckbox" TabIndex="180" />
                                                  </div>
                                             <div class="col-sm-10">
                                                  
                                                <span style="font-size: smaller; color: Red; font-family: Arial;">Please select checkbox,if Nominee Details need to be enter.</span>
                                                  </div>

                                      
                                        
                                               
                                    
                                          </div>
                                        <div class="row rowspacing">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblNomNme" runat="server" Text="Nominee Name" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:TextBox ID="txtNomNme" runat="server" CssClass="form-control"   onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>


                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtNomNme" ValidChars=" " FilterMode="ValidChars">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                           </div>
												 <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblNomDob" runat="server" Text="DOB " CssClass="control-label labelSize"></asp:Label>
                                                

                                                <asp:TextBox ID="txtNomDob" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
														  <asp:Image ID="Image8" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" Visible="false"/>
                                              
                                               <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtNomDob"
                                                    PopupButtonID="Image8" Format="dd/MM/yyyy" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ControlToValidate="txtNomDob"
                                                    Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                     <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                         Type="Date" ControlToValidate="txtNomDob" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                   	<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtNomDob" Display="Dynamic"
                                           ErrorMessage="Age must be between 18 to 70 years!" OnInit="rngval_DOB_init" MaximumValue="2099-01-01" MinimumValue="1944-01-01"
                                           Type="Date"></asp:RangeValidator>--%>
													 </div>
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label13" runat="server" Text=" Mobile Number" CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:TextBox ID="txtNomMob" runat="server" CssClass="form-control" MaxLength="10"  ></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtNomMob" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                       <div class="row rowspacing">
                                            <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="Label12" runat="server" Text="Email " CssClass="control-label labelSize"></asp:Label>
                                                
                                                <asp:TextBox ID="txtNomEmail" runat="server"
                                                    CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>

                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator6" runat="server"
                                                    ControlToValidate="txtNomEmail" Display="Dynamic" ErrorMessage="Invalid Email ID!"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                   ></asp:RegularExpressionValidator>

                                            </div>
                                             <div class="col-sm-4" style="text-align: left">
                                                <asp:Label ID="lblNomnRel" runat="server" Text="Nominee Relationship" CssClass="control-label labelSize"></asp:Label>

                                                <asp:DropDownList ID="ddlNomnRel" runat="server" CssClass="form-control form-select"                                                 
                                                    TabIndex="22">
                                                </asp:DropDownList>
                                                </div>
                                        </div>

                                      <div class="row rowspacing">
                                    <div class="col-sm-12" style="text-align:center">

                                    
                                <asp:LinkButton ID="btnPrevPannel5" runat="server"   CssClass="btn btn-success  "  OnClick="btnPrevPannel5_Click"> <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS </asp:LinkButton> 
                                                 <asp:LinkButton  ID="btnNextPannel5" runat="server"  CssClass="btn btn-success "  OnClick="btnNextPannel5_Click"  OnClientClick="return funValidatePannel4();">  NEXT <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 
                                        </div>
                                </div>
                                </div>
                               <%-- <asp:Button ID="btnPrevPannel5" runat="server" Text="PREVIOUS" CssClass="btn btn-success" OnClick="btnPrevPannel5_Click"  />--%>
                              
                                </div>
                          
                              
                                  </div>
                               <%-- <asp:Button ID="btnNextPannel5" runat="server" Text="NEXT" CssClass="btn btn-success"  OnClick="btnNextPannel5_Click" />--%>
                              <%-- OnClientClick="return funValidatePannel4();"--%>
                           
							</ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="Updatepanel7" runat="server">
                        <ContentTemplate>
                            <div id="divPannel4" runat="server" visible="false" class="card PanelInsideTab">
                                 <div id="Div26" runat="server" class="panelheadingAliginment">
                                    <div class="row spacebetnrow" id="div25" runat="server" style="text-align: left;">
                                            <div class="col-sm-12">
                                            <asp:Label ID="Label32" runat="server" CssClass="control-label HeaderColor"  
                                                Text="Document Upload"></asp:Label>
                                        </div>
                                   </div>
                              
                                    <div class="row" id="tblupload" style="margin-bottom: 5px;">
                                       <div class="col-sm-12" style="text-align:center;">
                                            <asp:Label ID="lblNote" runat="server" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/PNG/PDF format"
                                                ForeColor="red"></asp:Label>
                                       </div>
                                    </div>
                                 </div>
                               
                                <div id="div1" runat="server" style="display: block;" class="panel-body" width="100%">
                                    <div class ="card" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px">
                                                <asp:UpdatePanel ID="upddgView" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="dgView" runat="server" AllowSorting="True" 
                                                             OnPageIndexChanging="dgView_PageIndexChanging" CssClass="footable"
                                                             OnRowCommand="dgView_RowCommand"
                                                            OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                            AllowPaging="True" Width="100%" PageSize="15">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                                                    <ItemTemplate>
                   
																		<asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="clsLeft" />
                                                        <HeaderStyle CssClass="clsLeft" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="clsLeft" />
                                                        <HeaderStyle CssClass="clsLeft" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                                </asp:TemplateField>


                                                                      <asp:TemplateField HeaderText="Upload Documents">
                                                                    <ItemTemplate>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                                            <ContentTemplate>
                                                                                <asp:FileUpload ID="FileUpload" runat="server" Width="154px"></asp:FileUpload>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </ItemTemplate>
<ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btn_Upload" runat="server" CssClass="btn btn-success" style="width:95px;height:37px;" Text="Upload" Enabled="false" Visible="false" 
                                                                                    OnClick="btn_Upload_Click" />
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btn_ReUpload" runat="server" CssClass="btn btn-success" Text="ReUpload" 
                                                                                    OnClick="btn_ReUpload_Click" />
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                   <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                                </asp:TemplateField>

                                                               <%-- <asp:TemplateField HeaderText="Upload Documents">
                                                                    <ItemTemplate>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">--%>
                                                                           <%--  <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                            </Triggers>--%>
                                                                          <%--  <ContentTemplate>
                                                                                <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload>
                                                                            </ContentTemplate>
                                                                           
                                                                        </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                             <%--   <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                                             <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                            </Triggers>
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btn_Upload" runat="server" Text="Upload" Enabled="false" Visible="false" 
                                                                                    OnClick="btn_Upload_Click" />
                                                                            </ContentTemplate>
                                                                           
                                                                        </asp:UpdatePanel>
                                                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btn_ReUpload" runat="server" CssClass="btn btn-success" Text="ReUpload" 
                                                                                    OnClick="btn_ReUpload_Click" />
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>--%>

                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                            Text='<%#Bind("DocCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>' CommandName="Preview"
                                                                            Font-Size="11px" Style="text-transform: capitalize;">
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                           <%-- <RowStyle CssClass="sublinkodd"></RowStyle>
                                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True"></PagerStyle>
                                                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                                             <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                               
                                                </asp:UpdatePanel>
                                        <div class="row rowspacing">
                                            <div class="col-sm-6" style="text-align: left;">
                                                    <asp:CheckBox ID="chkgst" runat="server" Enabled="false" style="margin-left: 204px;"/>
												<asp:Label ID="lblgst" runat="server" Text="GST Not Applicable" Font-Bold="true" CssClass="control-label labelSize"></asp:Label>
                                                </div>
                                               <div class="col-sm-4" style="text-align:left">
                                                    
                                                    <asp:LinkButton ID="btngst" runat="server" Enabled="false" style="color:#0d6efd;text-decoration:underline" Text="View non-GST Declaration" OnClick="btngst_Click"></asp:LinkButton>
                                                   </div>
                                                       
                                        </div>
                                        <div class="row rowspacing" >
                                             <div class="col-sm-6" style="text-align: left;">
                                                    <asp:CheckBox ID="chkagree" runat="server" Enabled="false" style="margin-left: 204px;"/>
                                                            <asp:Label ID="lblagree" runat="server" Font-Bold="true" Text="Agree to Application Terms and Conditions" CssClass="control-label labelSize"></asp:Label>

                                             </div>
                                                       <div class="col-sm-4" style="text-align:left;padding-left: 120px">
                                                     <asp:LinkButton ID="btnView" runat="server" Enabled="false" style="color:#0d6efd;text-decoration:underline" Text="View T&C" OnClick="btnView_Click"></asp:LinkButton>
                                                   <%-- <span style="color: #ff0000; margin-left: -3px;">*</span>--%>
                                             </div>
                                                
                                                  
                                                        
                                        </div>
                                           </div> 
                                </div>

                                <div>
                                <div class="row rowspacing">
                                    <div class="col-sm-12" style="text-align:center">
               <%--                         <asp:Button ID="btnBackPannel4" runat="server" Text="PREVIOUS" CssClass="btn btn-success" OnClick="btnBackPannel4_Click"  />--%>
                                        <asp:LinkButton ID="btnBackPannel4" runat="server"   CssClass="btn btn-success  "  OnClick="btnBackPannel4_Click"> <span   class="glyphicon glyphicon-arrow-left BtnGlyphicon" ></span> PREVIOUS </asp:LinkButton> 
                                        <asp:Button ID="btnPreviewBack" runat="server" Text="PREVIOUS" CssClass="btn btn-success" OnClick="btnPreviewBack_Click"  />
                                        <asp:Button ID="BtnPreView" runat="server" Text="PREVIEW" CssClass="btn btn-success" OnClick="BtnPreView_Click"  />
                                          <asp:Button ID="btnCncl" runat="server" Text="CANCEL" CssClass="btn btn-clear" OnClick="btnCncl_Click"  />

                                              <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="btn btn-success"
                                                OnClick="btnUpdate_Click" TabIndex="188" OnClientClick="LdWait(1)"  />

                                    </div>
                                </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div id="divPClient" runat="server" style="width: 100%; display: none; margin-top: 5px">
                        <table width="100%" class="formtable2" style="margin-top: 5px">
                            <tr style="height: 20px;">
                                <td align="left" colspan="4" class="test formHeader">
                                    <input runat="server" type="button" class="standardlink" value="-" id="btnPcltdtlscollapse"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPCltDtls', 'ctl00_ContentPlaceHolder1_btnPcltdtlscollapse');" />
                                    <asp:Label ID="lblPCltDtlsHdr" runat="server" Font-Bold="True" Text="Other Personal Details"></asp:Label>
                                </td>
                            </tr>
                        </table>

                        <div id="divPCltDtls" runat="server" style="display: none;" width="100%">
                            <table width="100%" class="tableIsys">

                                <tr id="trchnl" runat="server" visible="false">
                                    <td class="formcontent" width="20%">
                                        <asp:Label ID="lblCltChnl" runat="server"></asp:Label>
                                        <span style="color: Red">*</span>
                                    </td>
                                    <td class="formcontent" width="30%">
                                        <asp:DropDownList ID="ddlChannels" runat="server" CssClass="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlChannels_SelectedIndexChanged" TabIndex="125">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="CD">CDA Franchise</asp:ListItem>
                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ValidationGroup="agtValGrp" ID="rfvddlchannels" runat="server" SetFocusOnError="true"
                                            ErrorMessage="Mandatory!" Enabled="true" Display="Dynamic" ControlToValidate="ddlChannels"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="formcontent" width="20%"></td>
                                    <td class="formcontent" width="30%"></td>
                                </tr>
                                <tr>
                                    <td class="formcontent" width="20%">
                                        <asp:Label ID="lbldob" runat="server"></asp:Label>
                                        
                                    </td>
                                   
                                    <td class="formcontent" width="20%">
                                        <span><font color="Red">
                                            <asp:Label ID="lblspIndicator" runat="server" CssClass="control-label labelSize"></asp:Label></font></span></td>
                                    <td class="formcontent" width="30%">
                                        <asp:DropDownList CssClass="form-control" ID="ddlSpecInd" runat="server" Enabled="false"
                                            Width="220px" TabIndex="100">
                                            <asp:ListItem Text="--Select--"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent">
                                        <span><font color="Red">
                                            <asp:Label ID="lblAltIDType" runat="server" CssClass="control-label labelSize"></asp:Label></font></span>
                                    </td>
                                    <td class="formcontent">
                                        <asp:UpdatePanel ID="UpdPanelOtherIDType" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cboOtherIDType" runat="server" RequiredField="true"
                                                    CssClass="form-control" LookupCode="NBSIDKey"
                                                    Width="220px" TabIndex="101">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent">
                                        </td>
                                    <td class="formcontent">
                                       </td>
                                </tr>
                                <tr>
                                    <td class="formcontent">
                                        <span>
                                            <asp:Label ID="lblAltIDNo" runat="server"></asp:Label></span>
                                    </td>
                                    <td class="formcontent">
                                        <asp:TextBox ID="txtOthersID" runat="server" CssClass="standardtextbox"
                                            MaxLength="10" Width="220px" TabIndex="103"></asp:TextBox>
                                        <asp:Button ID="btnSearchClt" runat="server" CausesValidation="False" Visible="false"
                                            CssClass="standardbutton" Text="FIND" TabIndex="130" />
                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="lblSOE" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent">
                                        <asp:DropDownList ID="ddlSOE" runat="server" CssClass="form-control"
                                            Width="220px" TabIndex="104">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent">
                                        <span>
                                            <asp:Label ID="lblNationality" runat="server"></asp:Label><span style="color: #ff0000"></span>
                                        </span>
                                    </td>
                                    <td class="formcontent">
                                        <asp:TextBox ID="txtNationalCode" runat="server" CssClass="standardtextbox"
                                            onChange="javascript:this.value=this.value.toUpperCase();" Width="50px"
                                            TabIndex="105" Text="IND"></asp:TextBox>
                                        <asp:TextBox CssClass="standardtextbox" Enabled="true" ID="txtNationalDesc"
                                            onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                            Width="166px" TabIndex="106" Text="INDIA"></asp:TextBox>
                                        <asp:Button CausesValidation="False" CssClass="standardbutton" ID="btnNational"
                                            runat="server" Text="..." TabIndex="107" />
                                        <br />
                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent">
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"
                                            Width="220px" TabIndex="108">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" nowrap="nowrap">
                                        <span>
                                            <asp:Label ID="lblHigestQul" runat="server">
                                                <asp:Label ID="lblmandatory" runat="server" Style="color: #ff0000" Text="*"></asp:Label></asp:Label>
                                        </span>
                                    </td>
                                    <td class="formcontent">
                                        <asp:UpdatePanel ID="UpdPanelQualCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cboQualCode" runat="server" RequiredField="false"
                                                    CssClass="form-control" Width="220px"
                                                    ValidationError="Mandatory!" TabIndex="109">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="lblSAPcode" runat="server"></asp:Label><asp:Label ID="lbsap" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>

                                    </td>
                                    <td class="formcontent">
                                        <asp:UpdatePanel runat="server" ID="upsapcode" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtSAPcode" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                                    MaxLength="10" Width="220px" TabIndex="110"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlLicTyp" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <table width="100%" class="formtable2" style="margin-top: 5px">
                            <tr style="height: 20px;">
                                <td align="left" colspan="4" class="test formHeader">
                                    <input runat="server" type="button" class="standardlink" value="-" id="btnperdtlscollapse"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divperdtls', 'ctl00_ContentPlaceHolder1_btnperdtlscollapse');" />
                                    <span><b>Personal Details</b></span>
                                </td>
                            </tr>
                        </table>
                        <div id="divperdtls" runat="server" style="display: none;" width="100%">
                            <table width="100%" class="tableIsys">
                                <tr>
                                    <td class="formcontent" width="20%">
                                        <asp:Label ID="lblHeight" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%;" colspan="2">
                                        <asp:TextBox ID="txtHeight1" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                            MaxLength="3" Width="220px" TabIndex="111"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                            FilterMode="InvalidChars" TargetControlID="txtHeight1"
                                            FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td class="formcontent" width="20%">
                                        <asp:Label ID="lblWeight" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" width="30%" colspan="2">
                                        <asp:TextBox ID="txtWeight" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                            MaxLength="3" Width="220px" TabIndex="112"></asp:TextBox>
                                        <asp:CompareValidator ValidationGroup="agtValGrp" ID="cvWeight" runat="server"
                                            ControlToValidate="txtWeight" Display="Dynamic" ErrorMessage="Invalid weight!"
                                            Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                            FilterMode="InvalidChars" TargetControlID="txtHeight1" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent">
                                        <span>
                                            <asp:Label ID="lblOccup" runat="server" Width="78px"></asp:Label>
                                        </span>
                                    </td>
                                    <td class="formcontent" colspan="2">
                                        <asp:TextBox ID="txtOccupationCode" runat="server" CssClass="standardtextbox" Width="50px"
                                            onChange="javascript:this.value=this.value.toUpperCase();"
                                            TabIndex="113"></asp:TextBox>
                                        <asp:TextBox ID="txtOccupationDesc" runat="server" CssClass="standardtextbox" Width="166px"
                                            Enabled="true" onChange="javascript:this.value=this.value.toUpperCase();"
                                            TabIndex="114"></asp:TextBox>
                                        <asp:Button ID="btnOccupation" runat="server" CausesValidation="False" CssClass="standardbutton"
                                            Text="..." TabIndex="115" />
                                    </td>
                                    <td class="formcontent">
                                        <span>
                                            <asp:Label ID="lblAnnualIncome" runat="server" Width="104px"></asp:Label>
                                        </span>
                                    </td>
                                    <td class="formcontent" colspan="2">
                                        <asp:TextBox ID="txtALIncome" runat="server" Width="220px" MaxLength="20"
                                            CssClass="standardtextbox" TabIndex="116"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trchks" runat="server" visible="false">
                                    <td class="formcontent" style="text-align: center" colspan="2">
                                        <asp:Label ID="lblPreferedClient" runat="server"></asp:Label>
                                        <asp:CheckBox ID="chkprefclt" runat="server" CssClass="standardcheckbox"
                                            TabIndex="117" />
                                    </td>
                                    <td class="formcontent" style="text-align: center" colspan="2">
                                        <asp:Label ID="lblStaff" runat="server"></asp:Label>
                                        <asp:CheckBox ID="chkStaff" runat="server" CssClass="standardcheckbox"
                                            TabIndex="118" />
                                    </td>
                                    <td class="formcontent" colspan="2">
                                        <span style="padding-right: 30px;"></span>
                                        <asp:Label ID="lblServiceTax" runat="server" TabIndex="148"></asp:Label>
                                        <asp:CheckBox ID="CheckBox2" runat="server" CssClass="standardcheckbox"
                                            TabIndex="119" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" width="20%">
                                        <span>
                                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td width="80%" class="formcontent" colspan="5">
                                        <asp:TextBox ID="Menu1" runat="server" Width="100%" Font-Overline="false" MaxLength="100"
                                            CssClass="standardtextbox" Height="60px" TextMode="MultiLine"
                                            TabIndex="120"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="divCClient" runat="server" style="width: 100%; display: none; margin-top: 5px">
                        <table width="100%" class="formtable2" style="margin-top: 5px">
                            <tr style="height: 20px;">
                                <td align="left" colspan="4" class="test formHeader">
                                    <input runat="server" type="button" class="standardlink" value="-" id="btnCcltdtlscollapse"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCCltDtls', 'ctl00_ContentPlaceHolder1_btnCcltdtlscollapse');" />
                                    <asp:Label ID="lblCCltDtlsHdr" runat="server" Font-Bold="True" Text="Other Personal Details"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div id="divCCltDtls" runat="server" style="display: block;" width="100%">
                            <table width="100%" class="tableIsys">
                                <tr>
                                    <td class="formcontent" width="20%">
                                        <asp:Label ID="lblcmpynm" runat="server" Text="Company Name"></asp:Label>
                                        <span style="color: Red; margin-left: -3px;">*</span>
                                    </td>
                                    <td class="formcontent" colspan="3" nowrap="nowrap">
                                        <asp:UpdatePanel ID="UpdPanelSurname" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cboTitle" runat="server" CssClass="form-control"
                                                    Width="90px" BackColor="#FFFFB2" TabIndex="130">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtSurname" runat="server" Width="510px" CssClass="standardtextbox"
                                                    MaxLength="60" BackColor="#FFFFB2" TabIndex="131"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_cmpName" SetFocusOnError="true" ErrorMessage="Invalid Name!" runat="server"
                                                    ValidationExpression="[a-zA-Z ]+$" ControlToValidate="txtSurName" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" width="20%">
                                        <span>Company Reg. No.</span>
                                    </td>
                                    <td class="formcontent" style="width: 30%">
                                        <asp:UpdatePanel ID="UpdPanelCurrentID" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtCurrentID" runat="server" Width="220px" CssClass="standardtextbox"
                                                    MaxLength="24" TabIndex="132"></asp:TextBox><span style="padding-left: 3px;"></span><asp:Button ID="Button1" runat="server"
                                                        CausesValidation="False" Visible="true"
                                                        CssClass="standardbutton" Text="FIND" TabIndex="153" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" style="width: 20%">Economic Activity
                                    </td>
                                    <td class="formcontent" style="width: 30%">
                                        <asp:DropDownList ID="ddlEcon" runat="server" CssClass="form-control"
                                            Width="220px" TabIndex="133">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" style="width: 20%">
                                        <asp:Label ID="Label9" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent">

                                        <asp:TextBox ID="txtDOB1" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                            RequiredField="true" TabIndex="134" Width="220px"></asp:TextBox>
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDOB1"
                                            PopupButtonID="Image5" Format="dd/MM/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ValidationGroup="agtValGrp" ID="CompareValidator4" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                            Type="Date" ControlToValidate="txtDOB1" Display="Dynamic"></asp:CompareValidator>
                                        <span style="padding-left: 3px;"></span><br />
                                        <asp:RangeValidator ValidationGroup="agtValGrp" ID="RangeValidator1" runat="server" ControlToValidate="txtDOB1" Display="Dynamic"
                                            ErrorMessage="Age must be between 18 to 70 years!" OnInit="rngval_DOB_init" MinimumValue="1944-01-01"
                                            Type="Date"></asp:RangeValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            InvalidChars=",#$@%^!*()&''%^~`<>=?.|{}[]:+;-" FilterMode="InvalidChars" TargetControlID="txtDOB1"
                                            FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:Label ID="lbldob1msg" runat="server" Text="Date Format(dd/MM/yyyy)"
                                            ForeColor="Red" Font-Size="XX-Small"></asp:Label>

                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" width="30%">
                                        <asp:UpdatePanel ID="UpdPanelBirthPlace" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtBirthPlace" runat="server" CssClass="standardtextbox"
                                                    MaxLength="135" Width="220px" TabIndex="156"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" style="width: 20%">Original Country
                                    </td>
                                    <td class="formcontent">
                                        <asp:UpdatePanel ID="UpdPanelCountry" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtCountryCode" runat="server" class="standardtextbox" Width="50px"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="136"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span><asp:TextBox ID="txtCountryDesc" runat="server" class="standardtextbox" Width="170px"
                                                    Enabled="false" TabIndex="137"></asp:TextBox>
                                                <span style="padding-left: 3px;"></span><asp:Button ID="btnCountry" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                    Text="..." Width="20px" TabIndex="138" />
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="ctvCountry" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Country Code!"
                                                    Display="Dynamic" ControlToValidate="txtCountryCode" ClientValidationFunction="CheckList"></asp:CustomValidator>
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="ctvCountryDesc" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Country Code!"
                                                    Display="Dynamic" ControlToValidate="txtCountryDesc" ClientValidationFunction="CheckList"></asp:CustomValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="lblCapital" runat="server"></asp:Label>
                                        <span style="color: Red; margin-left: -3px;">*</span>
                                    </td>
                                    <td class="formcontent" width="30%">
                                        <asp:UpdatePanel ID="UpdPanelCapital" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox Style="text-align: right" ID="txtCapital" runat="server" Width="220px"
                                                    CssClass="standardtextbox" MaxLength="18" BackColor="#FFFFB2"
                                                    TabIndex="139"></asp:TextBox>
                                                <asp:CompareValidator ValidationGroup="agtValGrp" ID="CVCapital" runat="server" Display="Dynamic" ControlToValidate="txtCapital"
                                                    Type="Currency" Operator="DataTypeCheck" ErrorMessage="Invalid Amount!"></asp:CompareValidator>
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="ctvCapital" runat="server" ErrorMessage="Invalid Amount!"
                                                    Display="Dynamic" ControlToValidate="txtCapital" ClientValidationFunction="CheckCapitalLimit"
                                                    SetFocusOnError="True"></asp:CustomValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" style="width: 20%">
                                        <asp:Label ID="lblStaffSz" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" width="30%">
                                        <asp:UpdatePanel ID="UpdPanelStaffSz" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox Style="text-align: right" ID="txtStaffSz" runat="server" CssClass="standardtextbox"
                                                    MaxLength="15" Width="220px" TabIndex="140"></asp:TextBox>
                                                <asp:CompareValidator ValidationGroup="agtValGrp" ID="CVSz" runat="server" Display="Dynamic" ErrorMessage="Invalid Staff size!"
                                                    Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtStaffSz"></asp:CompareValidator>
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="ctvStaffSz" runat="server" SetFocusOnError="True" ErrorMessage="Out of range!"
                                                    Display="Dynamic" ControlToValidate="txtStaffSz" ClientValidationFunction="CheckStaffSzLimit"></asp:CustomValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent">
                                        <asp:Label ID="lblservtaxapplble" runat="server" Text="Service Tax Applicable "></asp:Label>
                                    </td>
                                    <td class="formcontent">
                                        <asp:UpdatePanel ID="UpdPanelSalesTax" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkSalesTax" runat="server"
                                                    CssClass="standardcheckbox" TextAlign="Left" Checked="True" TabIndex="141"></asp:CheckBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent" style="width: 20%">Annual Turnover
                                    </td>
                                    <td class="formcontent" width="30%">
                                        <asp:UpdatePanel ID="UpdPanelAnnTurnover" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox Style="text-align: right" ID="txtAnnTurnover" runat="server" CssClass="standardtextbox"
                                                    MaxLength="21" Width="220px" TabIndex="142"></asp:TextBox>
                                                <asp:CompareValidator ValidationGroup="agtValGrp" ID="CVATurnOver" runat="server" Display="Dynamic" ErrorMessage="Invalid Annual Turnover!"
                                                    Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtAnnTurnover"></asp:CompareValidator>
                                                <asp:CustomValidator ValidationGroup="agtValGrp" ID="ctvTurnOver" runat="server" SetFocusOnError="True" ErrorMessage="Out of range!"
                                                    Display="Dynamic" ControlToValidate="txtAnnTurnover" ClientValidationFunction="CheckAnnTurnoverLimit"></asp:CustomValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent">Prefered Client
                                    </td>
                                    <td class="formcontent">
                                        <asp:CheckBox ID="chkVip" runat="server" CssClass="standardcheckbox"
                                            TabIndex="164" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="divlicdtls" runat="server" style="width: 100%; margin-top: 5px;display:none;">
                        <table width="100%" class="formtable2" style="margin-top: 5px">
                            <tr style="height: 20px;">
                                <td align="left" colspan="8" class="test formHeader">
                                    <input runat="server" type="button" class="standardlink" value="-" id="btnLicnseDtlscollapse"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLicnsDtls', 'ctl00_ContentPlaceHolder1_btnLicnseDtlscollapse');" />
                                    <asp:Label ID="lblLicnsDtlshdr" runat="server" Font-Bold="True" Text="License Details"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div id="divLicnsDtls" runat="server" style="display: block;" width="100%">
                            <table width="100%" class="tableIsys">
                                <tr>
                                    <td align="left" class="formcontent" style="width: 20%;">
                                        <span style="font-size: 10pt; color: #ff0000">
                                            <asp:Label ID="lblLicNo" runat="server" CssClass="control-label labelSize"></asp:Label>*</span></td>
                                    <td align="left" class="formcontent" style="width: 30%;">
                                        <asp:TextBox ID="txtBizLicNo" runat="server" CssClass="standardtextbox" Width="220px"
                                            MaxLength="20" TabIndex="143" BackColor="#FFFFB2"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_NewLicNo" runat="server" ControlToValidate="txtBizLicNo" ErrorMessage="Invalid Lic. No!" SetFocusOnError="true"
                                            ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ValidationGroup="agtValGrp" ControlToValidate="txtBizLicNo" ErrorMessage="Required." runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 20%;" nowrap="nowrap">
                                        <span style="font-size: 10pt; color: #ff0000">
                                            <asp:Label ID="lblLicEexpDate" runat="server" CssClass="control-label labelSize"></asp:Label>*</span></td>
                                    <td align="left" class="formcontent" style="width: 30%;" nowrap="nowrap">
                                        <asp:TextBox ID="txtBizLicEndDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                            RequiredField="true" TabIndex="144" Width="220px"></asp:TextBox>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBizLicEndDt"
                                            PopupButtonID="Image2" Format="dd/MM/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                       
                                    </td>
                                </tr>
                                <tr id="trOldLic" runat="server">
                                    <td class="formcontent" align="left" nowrap="nowrap">
                                        <asp:Label ID="lblOldLicNo" runat="server" Text="Old Lic No" Width="148px"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:TextBox ID="txtBizOldLicNo" runat="server" CssClass="standardtextbox"
                                            Width="220px" TabIndex="145" MaxLength="20"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="regexp_oldLicNo" runat="server" ControlToValidate="txtBizOldLicNo" ErrorMessage="Invalid Lic. No!" SetFocusOnError="true"
                                            ValidationExpression="^[^<>#%@!~`+$]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:Label ID="lblOldLicStrtDt" runat="server" Text="Old License Start Date"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left">
                                        <asp:TextBox ID="txtBizOldLicStrtDt" runat="server" CssClass="standardtextbox"
                                            Width="220px" TabIndex="146"></asp:TextBox>
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBizOldLicStrtDt"
                                            PopupButtonID="Image3" Format="dd/MM/yyyy" />
                                        <asp:CompareValidator ValidationGroup="agtValGrp" ID="CompareValidator3" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                            Type="Date" ControlToValidate="txtBizOldLicStrtDt" Display="Dynamic"></asp:CompareValidator>
                                        <span style="padding-left: 3px;"></span><br />
                                       
                                    </td>
                                </tr>
                                <tr id="trOldStrtDt" runat="server">
                                    <td class="formcontent" align="left">
                                        <asp:Label ID="lblOldLicExpDt" runat="server" Text="Old License Expiry Date"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left" style="white-space: nowrap">
                                        <asp:TextBox ID="txtBizOldLicExpDt" runat="server" CssClass="standardtextbox"
                                            Width="220px" TabIndex="147"></asp:TextBox>
                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtBizOldLicExpDt"
                                            PopupButtonID="Image4" Format="dd/MM/yyyy" />
                                        <asp:RegularExpressionValidator ValidationGroup="agtValGrp" ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtBizOldLicExpDt" ErrorMessage="Invalid Date!" SetFocusOnError="true"
                                            ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="formcontent" align="left"></td>
                                    <td class="formcontent" align="left"></td>
                                </tr>
                                <tr id="trPaymethod" runat="server" visible="false">
                                    <td class="formcontent" align="left" style="width: 259px; height: 22px;">
                                        <asp:Label ID="lblPayMethod" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 214px; height: 22px;" align="left">
                                        <asp:UpdatePanel runat="server" ID="upnlAgtMode">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged"
                                                    TabIndex="169" Width="220px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="formcontent" align="left" style="width: 180px; height: 22px;">
                                        <span>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td class="formcontent" style="width: 198px; height: 22px;" align="left">
                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control" Width="220px"
                                            TabIndex="170">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table width="100%" class="formtable2" style="margin-top: 5px">
                            <tr style="height: 20px;">
                                <td align="left" colspan="8" class="test formHeader">
                                    <input runat="server" type="button" class="standardlink" value="-" id="btnPymtDtlsCollapse"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPymtDtls', 'ctl00_ContentPlaceHolder1_btnPymtDtlsCollapse');" />
                                    <asp:Label ID="lblBnkDtlshdr" runat="server" Font-Bold="True" Text="Payment Details"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div id="divPymtDtls" runat="server" style="display: block;" width="100%">
                        </div>
                    </div>

                    <div>
                        <table style="margin-top: 5px;display:none">
                            <tr>
                                <td class="formcontent" align="center">

                                    <asp:Button ID="btnCreatIRC" runat="server" Text="CREATE IRC" Visible="false"
                                        CssClass="standardbutton" OnClick="btnCreatIRC_Click" Width="100px" />
                                    <asp:UpdatePanel runat="server">
                   <ContentTemplate>

                       <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="standardbutton"
                           OnClientClick="doCancel();return false;" Width="7%" Visible="false"></asp:Button></ContentTemplate>
               </asp:UpdatePanel>
                                    
                                    <asp:Button ID="btnAMLetter" runat="server" CssClass="standardbutton" Text="Gen AM Welcome Letter"
                                        Visible="False" OnClick="btnAMLetter_Click" Width="155px" />
                                 
                                    <asp:Button ID="btnPDLetter" runat="server" CssClass="standardbutton" Text="Gen PD Welcome Letter"
                                        Visible="false" OnClick="btnPDLetter_Click" />
                                    <span style="padding-left: 3px;"></span>
                                    <asp:Button ID="btnAMGoalLetter" runat="server" CssClass="standardbutton" Text="Goal Letter"
                                        OnClick="btnAMGoalLetter_Click" Visible="False" /><span style="padding-left: 3px;"></span>
                                    <asp:Button ID="btnCDAPromotionLetter"
                                        runat="server" CssClass="standardbutton" Text="CDA Promotion Letter" Visible="False"
                                        Width="137px" OnClick="btnCDAPromotionLetter_Click" /><asp:Button ID="btnTerminationLetter"
                                            runat="server" CssClass="standardbutton" Text="Generate Letter" Visible="False"
                                            Enabled="false" Width="137px" OnClick="btnTerminationLetter_Click" /><span style="padding-left: 3px;"></span>
                                    <asp:Button ID="btnReGenerateLetter" runat="server" CssClass="standardbutton" Text="ReGenerate Letter"
                                        Width="137px" OnClientClick="return confirm('Are you sure you want to DELETE this record?');"
                                        OnClick="btndelete_Click" Enabled="False" Visible="False" />
                                    <div id="divloader" runat="server" style="display: none;">
                                        &nbsp;&nbsp;<img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                        Loading...
                                    </div>
                                </td>
                                <td class="formcontent" align="left">
                                    <asp:Button ID="btn_GoalSheetRpt" runat="server" CssClass="standardbutton" OnClick="btn_GoalSheetRpt_Click"
                                        Text="GoalSheet Report" Width="124px" Visible="False" /><span style="padding-left: 3px;"></span>
                                </td>
                                <td class="formcontent" align="left">
                                    <asp:Button ID="btn_CDAWelcomeLetter" Enabled="false" runat="server" CssClass="standardbutton"
                                        OnClick="btn_CDAWelcomeLetter_Click" Text="Gen Welcome Letter" Width="124px" Visible="false" /><span style="padding-left: 3px;"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="hdnID210" type="hidden" runat="server" />
                                    <input id="hdnID220" type="hidden" runat="server" />
                                    <input id="hdnID240" type="hidden" runat="server" />
                                    <input id="hdnID250" type="hidden" runat="server" />
                                    <input id="hdnID260" type="hidden" runat="server" />
                                    <input id="hdnID270" type="hidden" runat="server" />
                                    <input id="hdnID280" type="hidden" runat="server" />
                                    <input id="hdnID290" type="hidden" runat="server" />
                                    <input id="hdnID300" type="hidden" runat="server" />
                                    <input id="hdnID310" type="hidden" runat="server" />
                                    <input id="hdnID320" type="hidden" runat="server" />
                                    <input id="hdnID330" type="hidden" runat="server" />
                                    <input id="hdnID340" type="hidden" runat="server" />
                                    <input id="hdnID360" type="hidden" runat="server" />
                                    <input id="hdnID370" type="hidden" runat="server" />
                                    <input id="hdnID380" type="hidden" runat="server" />
                                    <input id="hdnID390" type="hidden" runat="server" />
                                    <input id="hdnID400" type="hidden" runat="server" />
                                    <input id="hdnID410" type="hidden" runat="server" />
                                    <input id="hdnID420" type="hidden" runat="server" />
                                    <input id="hdnID430" type="hidden" runat="server" />
                                    <input id="hdnID440" type="hidden" runat="server" />
                                    <input id="hdnID450" type="hidden" runat="server" />
                                    <input id="hdnID460" type="hidden" runat="server" />
                                    <input id="hdnID470" type="hidden" runat="server" />
                                    <input id="hdnID480" type="hidden" runat="server" />
                                    <input id="hdnID490" type="hidden" runat="server" />
                                    <input id="hdnID500" type="hidden" runat="server" />
                                    <input id="hdnID510" type="hidden" runat="server" />
                                    <input id="hdnID520" type="hidden" runat="server" />
                                    <input id="hdnID530" type="hidden" runat="server" />
                                    <input id="hdnID550" type="hidden" runat="server" />
                                    <input id="hdnID560" type="hidden" runat="server" />
                                    <input id="hdnID570" type="hidden" runat="server" />
                                    <input id="hdnID580" type="hidden" runat="server" />
                                    <input id="hdnID590" type="hidden" runat="server" />
                                    <input id="hdnID600" type="hidden" runat="server" />
                                    <input id="hdnID620" type="hidden" runat="server" />
                                    <input id="hdnID630" type="hidden" runat="server" />
                                    <input id="hdnID640" type="hidden" runat="server" />
                                    <input id="hdnID650" type="hidden" runat="server" />
                                    <input id="hdnID660" type="hidden" runat="server" />
                                    <input id="hdncurdate" type="hidden" runat="server" />
                                    <input id="hdnAgntRank" type="hidden" runat="server" />
                                    <input id="hdnAgntType" type="hidden" runat="server" />
                                    <input id="hdnAgntLevel" type="hidden" runat="server" />
                                    <input id="hdnAgntClass" type="hidden" runat="server" />
                                    <input id="hdnCSCCode" type="hidden" runat="server" />
                                    <input id="hdnAgnCreateRul" type="hidden" runat="server" />
                                    <input id="hdnUnitRank" type="hidden" runat="server" />
                                    <input id="hdnMicr" type="hidden" runat="server" />
                                    <input id="hdnChkCnt" type="hidden" runat="server" />
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <input id="hdnEndDate" type="hidden" runat="server" />
                                    <input id="hdnPaymentmode" type="hidden" runat="server" />
                                    <input id="hdnAgentType" type="hidden" runat="server" />
                                    <input id="HdnSlschnl" type="hidden" runat="server" />
                                    <input id="hdnagtcode" type="hidden" runat="server" />
                                    <input id="hdnagtname" type="hidden" runat="server" />
                                    <input id="hdnrptrule" type="hidden" runat="server" />
                                    <input id="hdnHomeTel" type="hidden" runat="server" />
                                    <input id="hdnemail1" type="hidden" runat="server" />
                                    <input id="hdnmarsts" type="hidden" runat="server" />
                                    <input id="hdnCltDOB" type="hidden" runat="server" />
                                    <input id="hdnMobTel" type="hidden" runat="server" />
                                    <input id="hdnNtlty" type="hidden" runat="server" />
                                    <input id="hdnOccup" type="hidden" runat="server" />
                                    <input id="hdnTitle" type="hidden" runat="server" />
                                    <input id="hdnName" type="hidden" runat="server" />
                                    <input id="hdnCapital" type="hidden" runat="server" />
                                    <input id="hdnResAddr" type="hidden" runat="server" />
                                    <input id="hdnBusiAddr" type="hidden" runat="server" />
                                    <input id="hdnPermAddr" type="hidden" runat="server" />
                                    <input id="hdnStateP" type="hidden" runat="server" />
                                    <input id="hdnStateB" type="hidden" runat="server" />
                                    <input id="hdnStatePrm" type="hidden" runat="server" />
                                    <input id="hdnDistrP" type="hidden" runat="server" />
                                    <input id="hdnDistrB" type="hidden" runat="server" />
                                    <input id="hdnPinP" type="hidden" runat="server" />
                                    <input id="hdnPinB" type="hidden" runat="server" />
                                    <input id="hdnPinPrm" type="hidden" runat="server" />
                                    <input id="hdnCntryCP" type="hidden" runat="server" />
                                    <input id="hdnCntryCB" type="hidden" runat="server" />
                                    <input id="hdnCntryCPrm" type="hidden" runat="server" />
                                    <input id="hdnchn" type="hidden" runat="server" />
                                    <input id="hdnsubchn" type="hidden" runat="server" />
                                    <input id="hdnConstiRole" type="hidden" runat="server" />
                                    <asp:UpdatePanel ID="upmand" runat="server">
                                        <ContentTemplate>
                                            <asp:HiddenField ID="hdnPan" runat="server" />
                                            <input id="hdnUntCode" type="hidden" runat="server" />
                                            <input type="hidden" id="hdnRptSetup" runat="server" />
                                            <input id="hdnPriMandatory" type="hidden" runat="server" />
                                            <input id="hdnMgr1Mandatory" type="hidden" runat="server" />
                                            <input id="hdnMgr2Mandatory" type="hidden" runat="server" />
                                            <input id="hdnMgr3Mandatory" type="hidden" runat="server" />
                                            <asp:HiddenField ID="hdnrowid" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel runat="server" ID="upnlRule">
                                        <ContentTemplate>
                                            <input id="hdnCreateRule" type="hidden" runat="server" />
                                            <input id="hdnAppRule" type="hidden" runat="server" />
                                            <input id="hdnEMPCode" type="hidden" runat="server" />
                                            <input id="hdnBrkCode" type="hidden" runat="server" />
                                            <input id="hdnVenCode" type="hidden" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel runat="server" ID="upnlUntRule">
                                        <ContentTemplate>
                                            <input id="hdnUntRule" type="hidden" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
			   </div>

         <div id="demo1" class="row" runat="server" style="text-align: left; margin-left: 20px;margin-bottom: 10px;" visible="false">
                    <asp:ImageButton ID="lnkPage1" Visible="false" runat="server" OnClick="lnkPage1_Click" CssClass="TextBox"
                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Agent1.png" />
                    <asp:ImageButton ID="lnkPage2" runat="server" OnClick="lnkPage2_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Education2.png" />
                    <asp:ImageButton ID="lnkPage3" runat="server" OnClick="lnkPage3_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/EmpHst2.png" />
                    <asp:ImageButton ID="lnkPage4" runat="server" OnClick="lnkPage4_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/Disp2.png" />
                    <asp:ImageButton ID="lnkPage5" runat="server" OnClick="lnkPage5_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/tabs/PaymentInfo2.png" />
	   </div>
    </center>

    <script type="text/javascript">
        function funchkpaclick(objChkPA, strchk) {
            strchk = "Residential";
            if (strchk == "Residential") {
                if (document.getElementById("<%=ChkPARes.ClientID %>").checked == true) {
                    document.getElementById("<% =txtPermAdd1.ClientID %>").value = document.getElementById("<% =txtAddrP1.ClientID %>").value;
                    document.getElementById("<% =txtPermAdd2.ClientID %>").value = document.getElementById("<% =txtAddrP2.ClientID %>").value;
                    document.getElementById("<% =txtPermAdd3.ClientID %>").value = document.getElementById("<% =txtAddrP3.ClientID %>").value;
                    document.getElementById("<% =txtDistric.ClientID %>").value = document.getElementById("<% =txtDistP.ClientID %>").value;
                    document.getElementById("<% =txtarea1.ClientID %>").value = document.getElementById("<% =txtarea.ClientID %>").value;
                    document.getElementById("<% =txtPermPostcode.ClientID %>").value = document.getElementById("<% =txtPinP.ClientID %>").value;
                    document.getElementById("<% =txtPermCountryCode.ClientID %>").value = document.getElementById("<% =txtCountryCodeP.ClientID %>").value;
                    document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = document.getElementById("<% =txtCountryDescP.ClientID %>").value;
                    document.getElementById("<% =txtPermVillage.ClientID %>").value = document.getElementById("<% =txtVillage.ClientID %>").value;
                    document.getElementById("<% =txtcity1.ClientID %>").value = document.getElementById("<% =txtcity.ClientID %>").value;
                    document.getElementById("<% =ddlState1.ClientID %>").value = document.getElementById("<% =ddlState.ClientID %>").value;

                    document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = true;
                    document.getElementById('<% =txtDistric.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermCountryDesc.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermVillage.ClientID %>').disabled = true;
                    document.getElementById('<% =txtarea1.ClientID %>').disabled = true;
                    document.getElementById('<% =txtcity1.ClientID %>').disabled = true;
                    document.getElementById("<% =ddlState1.ClientID %>").disabled = true;
                    document.getElementById("<% =btnStateSrch1.ClientID %>").disabled = true;
                }
                else {
                    document.getElementById("<% =txtPermAdd1.ClientID %>").value = "";
                    document.getElementById("<% =txtPermAdd2.ClientID %>").value = "";
                    document.getElementById("<% =txtPermAdd3.ClientID %>").value = "";
                    document.getElementById("<% =txtDistric.ClientID %>").value = "";
                    document.getElementById("<% =txtPermPostcode.ClientID %>").value = "";
                    document.getElementById("<% =txtPermCountryCode.ClientID %>").value = "";
                    document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = "";
                    document.getElementById("<% =txtPermVillage.ClientID %>").value = "";
                    document.getElementById("<% =txtarea1.ClientID %>").value = "";
                    document.getElementById("<% =txtcity1.ClientID %>").value = "";
                    document.getElementById("<% =ddlState1.ClientID %>").selectedIndex = 0;

                    document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermCountryDesc.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermVillage.ClientID %>').disabled = false;
                    document.getElementById('<% =txtarea1.ClientID %>').disabled = false;
                    document.getElementById('<% =txtcity1.ClientID %>').disabled = false;
                    document.getElementById("<% =ddlState1.ClientID %>").disabled = false;
                    document.getElementById("<% =btnStateSrch1.ClientID %>").disabled = false;
                }
            }
            if (strchk == "Business") {
                if (document.getElementById("<%=ChkPABusns.ClientID %>").checked == true) {
                    document.getElementById("<% =txtPermAdd1.ClientID %>").value = document.getElementById("<% =txtAddrB1.ClientID %>").value;
                    document.getElementById("<% =txtPermAdd2.ClientID %>").value = document.getElementById("<% =txtAddrB2.ClientID %>").value;
                    document.getElementById("<% =txtPermAdd3.ClientID %>").value = document.getElementById("<% =txtAddrB3.ClientID %>").value;
                    document.getElementById("<% =txtDistric.ClientID %>").value = document.getElementById("<% =txtDistB.ClientID %>").value;
                    document.getElementById("<% =txtarea1.ClientID %>").value = document.getElementById("<% =txtarea0.ClientID %>").value;
                    document.getElementById("<% =txtPermPostcode.ClientID %>").value = document.getElementById("<% =txtPinB.ClientID %>").value;
                    document.getElementById("<% =txtPermCountryCode.ClientID %>").value = document.getElementById("<% =txtCountryCodeB.ClientID %>").value;
                    document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = document.getElementById("<% =txtCountryDescB.ClientID %>").value;
                    document.getElementById("<% =txtPermVillage.ClientID %>").value = document.getElementById("<% =txtBvillage.ClientID %>").value;
                    document.getElementById("<% =txtcity1.ClientID %>").value = document.getElementById("<% =txtcity0.ClientID %>").value;
                    document.getElementById("<% =ddlState1.ClientID %>").value = document.getElementById("<% =ddlState0.ClientID %>").value;

                    document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = true;
                    document.getElementById('<% =txtDistric.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermCountryDesc.ClientID %>').disabled = true;
                    document.getElementById('<% =txtPermVillage.ClientID %>').disabled = true;
                    document.getElementById('<% =txtarea1.ClientID %>').disabled = true;
                    document.getElementById('<% =txtcity1.ClientID %>').disabled = true;
                    document.getElementById("<% =ddlState1.ClientID %>").disabled = true;
                    document.getElementById("<% =btnStateSrch1.ClientID %>").disabled = true;
                }
                else {
                    document.getElementById("<% =txtPermAdd1.ClientID %>").value = "";
                    document.getElementById("<% =txtPermAdd2.ClientID %>").value = "";
                    document.getElementById("<% =txtPermAdd3.ClientID %>").value = "";
                    document.getElementById("<% =txtDistric.ClientID %>").value = "";
                    document.getElementById("<% =txtPermPostcode.ClientID %>").value = "";
                    document.getElementById("<% =txtPermCountryCode.ClientID %>").value = "";
                    document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = "";
                    document.getElementById("<% =txtPermVillage.ClientID %>").value = "";
                    document.getElementById("<% =txtarea1.ClientID %>").value = "";
                    document.getElementById("<% =txtcity1.ClientID %>").value = "";

                    document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermCountryDesc.ClientID %>').disabled = false;
                    document.getElementById('<% =txtPermVillage.ClientID %>').disabled = false;
                    document.getElementById('<% =txtarea1.ClientID %>').disabled = false;
                    document.getElementById('<% =txtcity1.ClientID %>').disabled = false;
                    document.getElementById("<% =ddlState1.ClientID %>").disabled = false;
                    document.getElementById("<% =btnStateSrch1.ClientID %>").disabled = false;
                }
            }
        }
        //added by Ibrahim  to Display Search pages in popup format on 15/5/2013 Start 
        // PopUp to Search Customer ID -Ibrahim
        function funcShowImgPopup(strPopUpType, stragtrole) {
            debugger;
            if (strPopUpType == "upimage") {
                ////
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopImage.aspx?mdlpopup=mdlViewBID"
                    + "&Field1=" + document.getElementById('<%=txtAgtCode.ClientID%>').value + "&AgtRole=" + stragtrole;
            }
        }
        function funcPopup() {////debugger;

            var textbox = document.getElementById("ctl00_ContentPlaceHolder1_gv_RptMngr_ctl02_txtRptMngr").id;
            alert(textbox);
        }

        //Modified: Parag

        function funcShowPopup(strPopUpType) {

            if (strPopUpType == "VendorIRC") {
                debugger;
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/IRCVenMapAgn.aspx?AgentCode=" + document.getElementById('<%=txtAgtCode.ClientID %>').value
                    + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "statedemo") {
                if (document.getElementById('<%=ddlState.ClientID %>').value == "") {
                    alert("Please select State.");

                    document.getElementById('<%= ddlState.ClientID %>').focus();
                    return false;
                }
                else {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlState.ClientID %>').value
                        + "&field1=" + document.getElementById('<%=txtPinP.ClientID %>').id + "&field2=" + document.getElementById('<%=txtDistP.ClientID %>').id
                        + "&field3=" + document.getElementById('<%=txtcity.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea.ClientID %>').id
                        + "&field11=" + document.getElementById('<%=hdnPinP.ClientID %>').id + "&field21=" + document.getElementById('<%=hdnDistrP.ClientID %>').id
                        + "&field31=" + document.getElementById('<%=hdnPinP.ClientID %>').id + "&field41=" + document.getElementById('<%=hdnDistrP.ClientID %>').id
                        + "&mdlpopup=mdlViewBID";
                }
            }

            if (strPopUpType == "statedemo1") {
                if (document.getElementById('<%=ddlState0.ClientID %>').value == "") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlState0.ClientID %>').focus();
                    return false;
                }
                else {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlState0.ClientID %>').value
                        + "&field1=" + document.getElementById('<%=txtPinB.ClientID %>').id + "&field2=" + document.getElementById('<%=txtDistB.ClientID %>').id
                            + "&field3=" + document.getElementById('<%=txtcity0.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea0.ClientID %>').id
                            + "&field11=" + document.getElementById('<%=hdnPinB.ClientID %>').id + "&field21=" + document.getElementById('<%=hdnDistrB.ClientID %>').id
                            + "&field31=" + document.getElementById('<%=hdnPinB.ClientID %>').id + "&field41=" + document.getElementById('<%=hdnDistrB.ClientID %>').id
                        + "&mdlpopup=mdlViewBID";
                }
            }

            if (strPopUpType == "statedemo2") {
                if (document.getElementById('<%=ddlState1.ClientID %>').value == "") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlState1.ClientID %>').focus();
                    return false;
                }
                else {
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlState1.ClientID %>').value
                        + "&field1=" + document.getElementById('<%=txtPermPostcode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtDistric.ClientID %>').id
                            + "&field3=" + document.getElementById('<%=txtcity1.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea1.ClientID %>').id
                            + "&field11=" + document.getElementById('<%=txtPermPostcode.ClientID %>').id + "&field21=" + document.getElementById('<%=txtDistric.ClientID %>').id
                            + "&field31=" + document.getElementById('<%=txtcity1.ClientID %>').id + "&field41=" + document.getElementById('<%=txtarea1.ClientID %>').id
                        + "&mdlpopup=mdlViewBID";
                }
            }
            //Added by sanoj  &field11 &field31 &field41 &field4 in Abow src
            //Added by swapnesh on 23/12/2013 to Add popup start

            if (strPopUpType == "country") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtCountryDescP.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtCountryDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "countryO") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtPermCountryCode.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtPermCountryDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtPermCountryCode.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtPermCountryDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "countryOC") {
                ////debugger;
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCode.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtCountryDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCode.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtCountryDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "countryB") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCodeB.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtCountryDescB.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCodeB.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtCountryDescB.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "national") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtNationalCode.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtNationalDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtNationalCode.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtNationalDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "occup") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopOccupation.aspx?Code=" + document.getElementById('<%=txtOccupationCode.ClientID %>').value
                    + "&Desc=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtOccupationCode.ClientID %>').id
                    + "&field2=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            //Added by swapnesh on 23/12/2013 to Add popup end
            if (strPopUpType == "custid") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AgtCustmerId.aspx?Code="
                    + document.getElementById('<%=txtCusmId.ClientID %>').value + "&Field1=" + document.getElementById('<%=txtAgntName.ClientID %>').id
                    + "&Field2=" + document.getElementById('<%=txtCusmId.ClientID %>').id + "&Field3=" + document.getElementById('<%=txtPanNo.ClientID %>').id + "&Source=0"
                    + "&mdlpopup=mdlViewBID";
            }
            //PopUp to Search Contact Details - Ibrahim 
            if (strPopUpType == "contact") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "ViewContactDetails.aspx?Code=" + document.getElementById('<%=txtCusmId.ClientID %>').value
                    + "&field1=1" + "&mdlpopup=mdlViewBID";
            }

            //PopUp to Search Account Payee Code-Ibrahim 
            if (strPopUpType == "accntpay") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AccountPayeeCode.aspx?Code=" + document.getElementById('<%=txtAccPayee.ClientID %>').value
                    + "&field1=" + document.getElementById("ctl00_ContentPlaceHolder1_lblAccPayeeDesc").id + "&Field2=" + document.getElementById('<%=txtAccPayee.ClientID %>').id
                    + "&Field3=" + document.getElementById('<%=ddlSlsChannel.ClientID%>').value + "&Field4=" + document.getElementById('<%=ddlChnCls.ClientID%>').value
                    + "&Field5=" + document.getElementById('<%=ddlAgntType.ClientID%>').value + "&Source=1" + "&mdlpopup=mdlViewBID";
            }

            //Popup to Search Recruit Agent Code-Ibrahim 
            if (strPopUpType == "ragtcode") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_txtImmLeaderCode").value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AccntPayPopup.aspx?Code=" + document.getElementById('<%=txtRecruitAgntCode.ClientID %>').value
                    + "&field1=" + document.getElementById('<%=lblRecruitAgtName.ClientID %>').id + "&Field2=" + document.getElementById('<%=txtRecruitAgntCode.ClientID %>').id
                    + "&Field3=" + document.getElementById('<%=txtSmCode.ClientID %>').id + "&Field4=0"
                    + "&Field5=" + document.getElementById('<%=ddlSlsChannel.ClientID%>').value + "&Field6=" + document.getElementById('<%=ddlChnCls.ClientID%>').value
                    + "&Field7=" + document.getElementById('<%=ddlAgntType.ClientID %>').value + "&objUnt=" + document.getElementById('<%=txtUntCode.ClientID %>').id
                    + "&objCSC=" + document.getElementById('<%=txtCmpUntCode.ClientID%>').id + "&objHdnCSC=" + "" + "&Source=1" + "&mdlpopup=mdlViewBID";
            }

            //PopUp to search Immediate Leader Code - Ibrahim 
            if (strPopUpType == "ImmLeaderCode") {
                ////
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_txtImmLeaderCode").value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AccntPopUp.aspx?Code="
                    + document.getElementById('<%=txtImmLeaderCode.ClientID %>').value
                    + "&field1=" + document.getElementById('<%=lblDirectAgtName.ClientID %>').id
                    + "&Field2=" + document.getElementById('<%=txtImmLeaderCode.ClientID %>').id
                    + "&Field3=" + document.getElementById('<%=txtSmCode.ClientID %>').id + "&Field4=1"
                    + "&Field5=" + document.getElementById('<%=ddlSlsChannel.ClientID%>').value
                    + "&Field6=" + document.getElementById('<%=ddlChnCls.ClientID%>').value
                    + "&Field7=" + document.getElementById('<%=ddlAgntType.ClientID %>').value
                    + "&objUnt=" + document.getElementById('<%=txtUntCode.ClientID %>').id
                    + "&objCSC=" + document.getElementById('<%=txtCmpUntCode.ClientID%>').id
                    + "&MgrCode=" + +document.getElementById('<%=hdnRptMgr.ClientID%>').value
                    + "&objHdnCSC=" + "" + "&Source=1" + "&mdlpopup=mdlViewBID";
            }

            //PopUp to search Manager Code - Ibrahim 
            if (strPopUpType == "mgrcode") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_txtImmLeaderCode").value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AccntPayPopup.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
                    + "&field1=" + document.getElementById('<%=lblMngrName.ClientID %>').id + "&Field2=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
                    + "&Field3=" + document.getElementById('<%=txtSmCode.ClientID %>').id + "&Field4=1"
                    + "&Field5=" + document.getElementById('<%=ddlSlsChannel.ClientID%>').value + "&Field6=" + document.getElementById('<%=ddlChnCls.ClientID%>').value
                    + "&Field7=" + document.getElementById('<%=ddlAgntType.ClientID %>').value + "&objUnt=" + document.getElementById('<%=txtUntCode.ClientID %>').id
                    + "&objCSC=" + document.getElementById('<%=txtCmpUntCode.ClientID%>').id + "&objHdnCSC=" + "" + "&Source=1" + "&mdlpopup=mdlViewBID";
            }

            //PopUp to Search Unit Code _Ibrahim ( not in Use )
            if (strPopUpType == "untcode") {
                ////
                $find("mdlViewBID").show();
                if (!chkMgrCode()) {
                    return false;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUntCode.ClientID %>').value
                    + "&CmpUntObj=" + document.getElementById('<%=lblUnitDesc.ClientID %>').id + "&UntObj=" + document.getElementById('<%=txtCmpUntCode.ClientID %>').id
                    + "&BizSrc=" + document.getElementById('<%=ddlSlsChannel.ClientID %>').value + "&ChnCls=" + document.getElementById('<%=ddlChnCls.ClientID %>').value
                    + "&AgentType=" + document.getElementById('<%=ddlAgntType.ClientID%>').value + "&MgrCode=" + document.getElementById('<%=hdnRptMgr.ClientID%>').value
                    + "&Type=" + queryString("Type") + "&OutUntCode=" + document.getElementById('<%=txtUntCode.ClientID %>').id
                    + "&OutUntDesc=" + document.getElementById('<%=lblUnitDesc.ClientID%>').id + "&OutCmpUnt=" + document.getElementById('<%=txtCmpUntCode.ClientID%>').id
                    + "&RecruitDate=" + document.getElementById('<%=txtRecruitDate.ClientID%>').value + "&Source=1" + "&mdlpopup=mdlViewBID";
            }
        }

        function funcShowPopupBAS(strPopUp) {

            if (strPopUp == "Agtcode") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/PopVendorlist.aspx?AgentCode=" + document.getElementById('<%=txtAgtCode.ClientID %>').value
                    + "&AgentName=" + document.getElementById('<%=txtAgntName.ClientID %>').value + "&mdlpopup=mdlViewBID";
            }
            if (strPopUp == "Agtcode1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/PopChildParentList.aspx?AgentCode=" + document.getElementById('<%=txtAgtCode.ClientID %>').value +
                    "&AgentName=" + document.getElementById('<%=txtAgntName.ClientID%>').value + "&mdlpopup=mdlViewBID";

            }
        }

        //Added by Miti for showing Map to vendor popup on 25/10.2013 start
        function funcShowPopupMaptoVendor() {
            $find("mdlViewpop").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframepop").src = "../../../Application/ISys/ChannelMgmt/FrmMaptoVendor.aspx?mdlpopup=mdlViewpop";
        }
        //Added by Miti for showing Map to vendor popup on 25/10.2013 end


        //Modified: Parag

    </script>
    <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="false" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" Width="600" Height="355" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:UpdatePanel ID="updPnl_Msg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server"   BackColor="white" ForeColor="Black"
                 class="modalpopupmesg" Width="400px" Height="300px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" colspan="1" style="height: 32px;color:#00cccc">INFORMATION 
                        </td>
                    </tr>
                </table>
                <table style="height: 29%">
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                            <br />
                            <center>
                                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                            <br />
                            <center>
                                <asp:Label ID="lbl6" runat="server"></asp:Label>
                                <br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl7" runat="server"></asp:Label>
                            </center>
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" style="margin-top:-67px" Width="80px" class="btn btn-success" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="false" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

		function fununtpopup(strvalue, strqstring, strIsAgent, strMgr) {
			debugger
            var strAgentType;


            if (strvalue == "untcode") {

                $find("mdlViewBID").show();
                //if (!chkMgrCode()) {
                //    return false;
                //} /////debugger;
                //if ($('#ddllvlagttype').is(':visible'))
                var element = document.getElementById('<%=ddllvlagttype.ClientID%>');
                if (typeof (element) != 'undefined' && element != null) { strAgentType = document.getElementById('<%=ddllvlagttype.ClientID%>').value; } //To handle the case when the User Selects the CH as the Agent Type -- Modified: Parag @ 02042014
                else { strAgentType = document.getElementById('<%=ddlAgntType.ClientID%>').value; }

             //if (document.getElementById('<%=hdnRptMgr.ClientID%>') != null) {
                if (strMgr != '') {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUntCode.ClientID %>').value
                     + "&CmpUntObj=" + document.getElementById('<%=lblUnitDesc.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + document.getElementById('<%=ddlSlsChannel.ClientID %>').value + "&ChnCls=" + document.getElementById('<%=ddlChnCls.ClientID %>').value
                     + "&AgentType=" + strAgentType + "&MgrCode=" + strMgr + "&hdn2=" + document.getElementById('<%=hdnutadr.ClientID %>').id
                     + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtUntCode.ClientID %>').id + "&UntAdr=" + document.getElementById('<%=lblUntAddr.ClientID %>').id
                     + "&OutUntDesc=" + document.getElementById('<%=lblUnitDesc.ClientID%>').id + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                     + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent + "&mdlpopup=mdlViewBID&agttype=" + document.getElementById('<%=ddlAgntType.ClientID %>').value;
             }
             else {
                 document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUntCode.ClientID %>').value
                     + "&CmpUntObj=" + document.getElementById('<%=lblUnitDesc.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + document.getElementById('<%=ddlSlsChannel.ClientID %>').value + "&ChnCls=" + document.getElementById('<%=ddlChnCls.ClientID %>').value
                     + "&AgentType=" + strAgentType + "&MgrCode=" + "&UntAdr=" + document.getElementById('<%=lblUntAddr.ClientID %>').id
                     + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtUntCode.ClientID %>').id + "&hdn2=" + document.getElementById('<%=hdnutadr.ClientID %>').id
                     + "&OutUntDesc=" + document.getElementById('<%=lblUnitDesc.ClientID%>').id + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                     + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent + "&mdlpopup=mdlViewBID&agttype=" + document.getElementById('<%=ddlAgntType.ClientID %>').value;
                }
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr1") != null) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr1").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_lblrptmgr1").innerText = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr1").value = null;
                }
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr2") != null) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr2").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_lblrptmgr2").innerText = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr2").value = null;
                }
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr3") != null) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtRptMgr3").value = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_lblrptmgr3").innerText = "";
                    document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr3").value = null;
                }
            }
        }

        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon, struntcode) {
            debugger;
            var strAgentType = document.getElementById('<%=ddlAgntType.ClientID%>').value;
            var primStp = document.getElementById('<%=hdnPrimStp.ClientID%>').value;
            var chnl = document.getElementById('<%=ddlSlsChannel.ClientID %>').value;
            var schnl = document.getElementById('<%=ddlChnCls.ClientID %>').value;
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                if (struntcode == '') {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
                     + "&Desc=" + document.getElementById('<%=txtRptMgr.ClientID %>').value + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
                     + "&field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent
                     + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnUntCode.ClientID %>').value
                     + "&field3=" + document.getElementById('<%=lblrptmgr.ClientID %>').id + "&chnl=" + chnl + "&schnl=" + schnl
                     + "&rptsetup=" + document.getElementById('<%=hdnRptSetup.ClientID %>').value
                     + "&MemCode=''"
                     + "&ddl=" + document.getElementById('<%=ddllvlagttype.ClientID %>').id
                     + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBID&isPrimary=Y";
             }
             else {
                 document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
                     + "&Desc=" + document.getElementById('<%=txtRptMgr.ClientID %>').value + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
                     + "&field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent
                     + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + struntcode
                     + "&field3=" + document.getElementById('<%=lblrptmgr.ClientID %>').id + "&chnl=" + chnl + "&schnl=" + schnl
                     + "&rptsetup=" + document.getElementById('<%=hdnRptSetup.ClientID %>').value
                     + "&MemCode=''"
                     + "&ddl=" + document.getElementById('<%=ddllvlagttype.ClientID %>').id
                     + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBID&isPrimary=Y";
                }
            }
        }

        function funcgridMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon, rowid, struntcode, rwid) {
            ////debugger;
            var PrimMgr = document.getElementById('<%=hdnRptMgr.ClientID%>');
            var untcode = document.getElementById('<%=hdnUntCode.ClientID%>');
            var chnl = document.getElementById('<%=ddlSlsChannel.ClientID %>').value;
            var schnl = document.getElementById('<%=ddlChnCls.ClientID %>').value;
            var strAgentType = document.getElementById('<%=ddlAgntType.ClientID%>').value;
            if (strPopUpType == "rptmgr") {
                if (PrimMgr != null && untcode != null) {
                    if (PrimMgr.value == "" || untcode.value == "") {
                        //                        alert("Please select Primary Manager and Unitcode first.");
                        //                        return false;
                    }
                }
                else if (untcode != null) {
                    if (untcode.value == "") {
                        //                        alert("Please select Unitcode first.");
                        //                        return false;
                    }
                }
                $find("mdlViewBID").show();
                if (struntcode == '') {
                    /////alert('aaaaaaa');
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
                        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
                        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
                        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnUntCode.ClientID %>').value
                        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon
                        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
                        + "&MemCode=''"
                        + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id
                        + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value + "&memtyp=" + strAgentType
                        + "&rowid=" + rwid
                        + "&hdn=" + document.getElementById(rowid + "_hdnrowid").id
                        + "&mdlpopup=mdlViewBID&isPrimary=N";
                }
                else {
                    ////alert('bbbbbbbb');
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
                        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
                        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
                        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + struntcode
                        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon
                        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
                        + "&MemCode=''"
                        + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id
                        + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value + "&memtyp=" + strAgentType
                        + "&rwid=" + rwid
                        + "&hdn=" + document.getElementById("ctl00_ContentPlaceHolder1_hdnrowid").id
                        + "&mdlpopup=mdlViewBID&isPrimary=N";
                }
            }
        }

    </script>
</asp:Content>

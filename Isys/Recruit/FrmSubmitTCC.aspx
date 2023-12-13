<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmSubmitTCC.aspx.cs" Inherits="Application_ISys_Recruit_FrmSubmitTCC" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     
     <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
     <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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
<%--    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
     <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
        <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
<%--     <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>
<%--    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>--%>
<%--    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
<%--    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>--%>
<%--    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
<%--    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
<%--    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>--%>
<%--    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>--%>
<%--    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
<%--      <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>

    <script language="javascript" type="text/javascript">
        function popup() {
            $("#myModal").modal();
        }


         function popup1() {
            $("#myModal1").modal();
        }

<%--        $(function () {
           debugger;

            $("#<%= txtExmdt1.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true,mindate:1 });


        });--%>
   //  added by pallavi on 20/12/2022

          $(function () {
            debugger;
            var date = new Date();
            var followingDay = new Date(date.getTime() + 86400000)
            var currentMonth = followingDay.getMonth();
            var currentDate = followingDay.getDate();
            var currentYear = followingDay.getFullYear();
            $("#<%= txtExmdt1.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                minDate: new Date(currentYear, currentMonth, currentDate)
            
            });
          });

   //  added by pallavi on 20/12/2022


        $(document).ready(function () {

            //call the blink function on the element you want to blink
            // alert('usha');
            // alert(document.getElementById("ctl00_ContentPlaceHolder1_ChkFeesWavier").id);
            if (document.getElementById("ctl00_ContentPlaceHolder1_ChkFeesWavier").disabled == true) {

                // alert('usha1');
                $("#myDiv").removeClass("blink");
            }
            else {
                //alert('usa2');
                $("#myDiv").addClass("blink");
                blink("#myDiv", -1, 100);

            }
        });


        function blink(elem, times, speed) {
            if (times > 0 || times < 0) {
                if ($(elem).hasClass("blink"))
                    $(elem).removeClass("blink");
                else
                    $(elem).addClass("blink");
            }

            clearTimeout(function () {
                blink(elem, times, speed);
            });

            if (times > 0 || times < 0) {
                setTimeout(function () {
                    blink(elem, times, speed);
                }, speed);
                times -= .5;
            }
        }

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

        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            //document.getElementById("btnSubmit").click();
            return true;
        }

        function Closewin() {

            window.close();
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "ExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                     document.getElementById('<%=txtExmCntr.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCntr.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }
        }
        function ShowReqDtlExam(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

        function ShowReqDtl(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    // objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function ShowReqDtlDwnld(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

        function ShowReqDtlNew(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

        function ShowReqDtlRenew(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }


        function Validation() {
            var strContent = "ctl00_ContentPlaceHolder1_";

            //Transfer Case start
            //debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                }
            }
            //Transfer case end

            //composite start
            //debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                    alert("License Number for Composite is Mandatory");
                    document.getElementById(strContent + "txtCompLicNo").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                }

                if (document.getElementById("<%=hdnWebTknCon.ClientID %>").value != "1") {
                if (document.getElementById("<%=hdnWebTkn.ClientID %>").value != "1") {
                        if (!(document.getElementById("<%=chkWebTknRecd.ClientID %>").checked)) {
                            document.getElementById("<%=txtFeesRcvd.ClientID %>").value == ""

                        }
                    }
                }


            //fees validation

                if (document.getElementById("<%=hdnWebTknCon.ClientID %>").value != "1") {
                if (document.getElementById("<%=hdnWebTkn.ClientID %>").value != "1") {
                        if ((document.getElementById("<%=chkWebTknRecd.ClientID %>").checked)) {
                            if (document.getElementById("<%=txtFeesRcvd.ClientID %>").value == "") {
                                alert("Please Enter Transaction Id");
                                document.getElementById("<%=txtFeesRcvd.ClientID %>").focus();
                                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                                return false;
                            }

                        }
                    }
                }

            }
        }
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        function AlertMsgs(msgs) {
            alert(msgs);
        }

        function form2() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            //debugger;
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
                return false;
            }
            else {
                //                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                //                if ((Mobile.substr(0, 1)) != "0") {
                //                    alert("Mobile Number should start with 0");
                //                    document.getElementById(strContent + "txtMobileNo").focus();
                //                    return false;
                //                }
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileNo").focus();
                    return false;
                }

            }
            return true;
        }

        function validateEmail1() {

            //debugger;
            var Email = (document.getElementById('<%= txtEMail.ClientID %>').value);
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEMail").focus();
                return false;
            }

            return true;

        }

        //        added by shreela on 14/07/2014
        function OpenPOP() {
            debugger;
            window.parent.document.getElementById("btnReFresh").click();
        }

        function CloseSub() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnReFresh").click();
        }

        function funcClear() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
        //added by shreela on 14/07/2014

        function ShowReqDtl1(divName, btnName) {
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

        //function checkDate() {
        //     debugger;
        //    try {
        //        var idate = document.getElementById("ctl00_ContentPlaceHolder1_txtExmdt1"),
        //            resultDiv = document.getElementById("ctl00_ContentPlaceHolder1_divdate"),
        //            dateReg = /(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/]201[4-9]|20[2-9][0-9]/;

        //        if (!dateReg.test(idate.value)) {
        //            resultDiv.innerHTML = "Invalid date!";
        //            resultDiv.style.color = "red";
        //            return;
        //        }

        //        if (isFutureDate(idate.value)) {
        //            resultDiv.innerHTML = "Entered date is a future date";
        //            resultDiv.style.color = "red";
        //        } else {
        //            resultDiv.innerHTML = "It's a valid date";
        //            resultDiv.style.color = "green";
        //        }
        //    }
        //    catch (err) {
        //        ShowError(err.description);
        //    }
        //}

        //function isFutureDate(idate){
        //  var today = new Date().getTime(),
        //  idate = idate.split("/");

        // idate = new Date(idate[2], idate[1] - 1, idate[0]).getTime();
        // return (today - idate) < 0;
        // }

      

    </script>
    <style>
        .blink {
            color: Black !important;
            background: #EDF1cc !important;
        }

        modal-header1 {
            min-height: 16.42857143px;
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background-color: #FFFFFF !important;
            /*color: #034ea2*/
        }

    </style>



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                            <div class="stripPanelClass">
        <ul class="nav nav-tabs" id="myTab" role="tablist" style="height: 53px;">
            <li class="nav-item" role="presentation" style="font-size: 12px!important;">
                <button class="nav-link active Strip" id="divPDH" runat="server" data-bs-toggle="tab" data-bs-target="#divPD" type="button" role="tab" aria-controls="divPD" aria-selected="true"><span id="span2" runat="server" class="badge bg-secondary numbercircle">1</span>&nbsp Candidate Details</button>
            </li>


            <li class="nav-item" role="presentation">
                <button class="nav-link Strip" id="divCDH" runat="server" data-bs-toggle="tab" data-bs-target="#divCD" type="button" role="tab" aria-controls="divCD" aria-selected="false"><span id="span9" runat="server" class="badge bg-secondary numbercircle">2</span>&nbsp Training Details</button>
            </li>
               <li class="nav-item" role="presentation">
                <button class="nav-link Strip" id="divEDH" runat="server" data-bs-toggle="tab" data-bs-target="#divED" type="button" role="tab" aria-controls="divED" aria-selected="false"><span id="span3" runat="server" class="badge bg-secondary numbercircle">3</span>&nbsp Exam Details</button>
            </li>


        </ul>
    </div>

                            <div class="row rowspacing">
                                <div  runat="server"  class="col-sm-12" style="margin-bottom: 5px;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                                    <asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                                </div>
                            </div>
                            <div id="Div3" runat="server" class="panelheadingAliginment" > 
                          <div class="rowr rowspacing">
                                        <div class="col-sm-10" style="text-align: left">
                                            <asp:Label ID="lblTitle" runat="server" style="font-size:19px" CssClass="control-label HeaderColor"
                                              ></asp:Label>
                                        </div>
<%--                                        <div class="col-sm-2">
                                            <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>--%>
                                    </div>
                                </div>
    <%--Pallavi UI 06 Oct 2022 Start--%> 

                             <div class="tab-content" id="myTabContent">

    <%--Personal Details Start--%>
            <div class="tab-pane fade show active PanelInsideTab" id="divPD" role="tabpanel" aria-labelledby="divPDH">
                            
            </div>
    <%--Personal Details End--%>

 
    <%--Training & Exam Details Start--%>
            <div class="tab-pane fade PanelInsideTab" id="divTED" role="tabpanel" aria-labelledby="divEEDH">3
        
  </div>
       <%--Training & Exam Details End--%>
            <div class="tab-pane fade PanelInsideTab" id="divEXD" role="tabpanel" aria-labelledby="divEXDH">4

 
</div>
    <%--Pallavi UI 26 Sep 2022 End--%> 
                    <div  id= "div5"  class="card PanelInsideTab" runat="server" visible="true"  style="margin-top: -3%;margin-right: 68px;margin-left: 70px;"> 
                            <div  id= "divPannel1"   runat="server" visible="true" > <%--width: 88% !important;height: 500px;--%> <%--class="card PanelInsideTab"--%>
                      <%--candidate Details start--%> 
                              <div  id="divCndtls"  runat="server">
                              <div class="panelheadingAliginment" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;" > 
                                 <div class="row spacebetnrow">
                                      <div class="col-sm-10" style="text-align: left">
                                           <asp:Label ID="lblCnddtls" runat="server" class=" control-label HeaderColor" Style="font-size: 19px;"></asp:Label>
                                       </div>
                                       <div class="col-sm-2">
                                            <span id="Span1" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important;
                                             font-size: 18px; color:#00cccc;margin-right: 15px;"></span>
                                       </div>
                                 </div>
                                  </div>

                              <div runat="server" id="divagndetails" style="display: block;width: 96%" class="panel-body panelContent">
                                       <div class="row rowspacing" >
                                       <div class="col-sm-4" style="text-align: left">
                                         </div>
                                      <div class="col-sm-4" style="text-align: left">
                                         </div>
                                      <div class="col-sm-4" style="text-align: left">
                                                            <%--<asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>--%>
                                        <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click" class="control-label labelSize" visible="true"></asp:LinkButton>
                                           </div>
                                             </div>

                               <div class="row rowspacing" style="padding-left:20px; height: 59px;">
                                     <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblAppNo" runat="server" Text="Application No" CssClass="control-label labelSize" ></asp:Label>
                                            <asp:TextBox ID="lblAppNoValue" runat="server" Enabled="false"  CssClass="form-control"></asp:TextBox> <%-- style="margin-bottom:5px;ss"--%>
                                       </div>
                                     <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblCndName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                           <asp:TextBox ID="lblAdvNameValue" Enabled="false"   CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>   <%--style="margin-bottom:5px;"--%>
                                        </div>
                                     <div class="col-sm-4" style="text-align: left">
                                            <asp:Label ID="lblCndNo" runat="server" CssClass="control-label labelSize"></asp:Label>
                                          <asp:TextBox ID="lblCndNoValue" CssClass="form-control" Enabled="false"  runat="server" Font-sBold="False"></asp:TextBox> <%--style="margin-bottom:5px;" --%>
                                                <asp:HiddenField ID="hdnCndNo" runat="server"/>
                                                <asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" class="control-label labelSize" runat="server"></asp:Label>
<%--                                               <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details"  class="control-label labelSize" visible="true" onclick="lblCndView_Click"></asp:LinkButton>--%>
                                              <asp:CheckBox ID="chkAdvWaiver" runat="server" Visible="false" AutoPostBack="true"
                                                OnCheckedChanged="chkAdvWaiver_CheckedChanged" />
                                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:LinkButton ID="btnAdvisorWaiver" runat="server" Visible="false" Text="Waiver Advisor"
                                               Width="100" CssClass="standardbutton" />
                                          <asp:HiddenField ID="hdnAdvWaiver" runat="server" />
                                             <asp:HiddenField ID="hdnCsccode" runat="server" />
                                            </div>
                                    </div>
                               <div class="row rowspacing" style="padding-left:20px; height: 59px;">
                               <div class="col-sm-4" style="text-align: left">
                               <asp:Label ID="lblBranch" runat="server"  CssClass="control-label labelSize"></asp:Label>
                              <asp:TextBox ID="lblBranchValue" style="margin-bottom:5px;" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                               </div>
                               <div class="col-sm-4" style="text-align: left">
                            <asp:Label ID="lblSMName" CssClass="control-label labelSize" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblSMNameValue" style="margin-bottom:5px;" Enabled="false" CssClass="form-control" runat="server" ></asp:TextBox>
                               </div>
                               <div class="col-sm-4" style="text-align: left">
                            <asp:Label ID="lblMobileNo" runat="server" CssClass="control-label labelSize" style="color:Black"></asp:Label>
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="form-control mandatory"></asp:TextBox>
                                       <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                           InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                           FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                                       </ajaxToolkit:FilteredTextBoxExtender>                              
                                   <asp:LinkButton ID="btnverifymobile" runat="server" Visible="false" Text="Verify" ValidationGroup="RecruitInfo"
                                       OnClientClick="return form2();"></asp:LinkButton>
                                             <div id="divmob" class="Content" style="display: none">
                                       <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                       Loading...</div>
                                 
                                   <asp:Label ID="lblmobileverify" runat="server" Font-Bold="False" Font-Size="X-Small" ></asp:Label>
                               </div>
                  </div>
                               <div class="row rowspacing" style="padding-left:20px; height: 59px;" >
                               <div class="col-sm-4" style="text-align: left">
                                    <asp:Label ID="lblPAN" runat="server"  CssClass="control-label labelSize"></asp:Label>     
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="form-control mandatory" onChange="javascript:this.value=this.value.toUpperCase();" Enabled="false"></asp:TextBox>
                                    <asp:LinkButton ID="btnVerifyPAN" runat="server" Visible="false" Text="Verify" ValidationGroup="RecruitInfo" Enabled="false"></asp:LinkButton>
                                   <%-- <div id="divPAN" class="Content" style="display: none">
                                        <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                        Loading...</div>--%>
                                    <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" CssClass="control-label labelSize" Font-Size="X-Small"></asp:Label>
                                    <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField> 
                            </div>
                               <div class="col-sm-4" style="text-align: left">
                                  <asp:Label ID="lblEmail" runat="server" CssClass="control-label labelSize " style="color:Black"></asp:Label> 
                                  <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control mandatory"  onblur="validateEmail1(this.value)"></asp:TextBox>
                                  <asp:LinkButton ID="btnverifyemail" runat="server" Visible="false" Text="Verify" ValidationGroup="RecruitInfo" OnClientClick="return validateEmail1();"></asp:LinkButton>
                                  <div id="divEmail" class="Content" style="display: none">
                                  <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                Loading...</div>
                           <%-- <br />--%>
                                 <asp:Label ID="lblEmailMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                           </div>
                               <div class="col-sm-4"  style="text-align: left" >
                                  <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" CssClass="control-label labelSize"></asp:Label>
                                  <asp:TextBox ID="lblSponsorDtValue" CssClass="form-control"  Enabled="false" runat="server"></asp:TextBox>
                             </div>
                                </div>
                               <div class="row rowspacing" style="padding-left:20px; height: 59px;">
                               <div class="col-sm-4" style="text-align: left" >
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                   <ContentTemplate>
                                        <asp:Label ID="lblcndURNNo" Text="Candidate URN No"  CssClass="control-label labelSize"  runat="server"></asp:Label>
                                        <asp:TextBox ID="lblCndURNVal" CssClass="form-control" runat="server"  Text="(dd/mm/yyyy)" placeholder="Candidate URN No" Enabled="false"></asp:TextBox>
                                  </ContentTemplate>
                                  </asp:UpdatePanel>
                             </div>
                            <%--   <div class="col-sm-4" style="text-align: left" >  
                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:Label id="TblFeesWaiver" runat="server"  CssClass="control-label labelSize" Text="Fees Waiver"  ></asp:Label>
                                        <asp:CheckBox ID="ChkFeesWavier" runat="server"    AutoPostBack ="true" Enabled="true"
                                         OnCheckedChanged="ChkFeesWavier_CheckedChanged"  TabIndex="21" style='margin-left:1px'/>&nbsp&nbsp
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                            </div>--%>
                               </div>

                            </div>
                             </div>
                      <%--candidate Details End--%>
                                         
                                           </div>


                      <%-- Training Details Start --%>      
                              <div  id="tbltrn" runat="server" visible="false"   style="border:none;">  <%-- class="card PanelInsideTab"--%>  <%--margin-top: -45px;margin-right: 88px;margin-left: 70px;--%>
                              <%--<div  id="divTrndtls" runat="server" style=" margin-left: -80px;margin-right: -90px;"--%>
                               <div class="panelheadingAliginment"  runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divNOCdetails','Span110');return false;">
                             <div class="row spacebetnrow">
                               <div class="col-sm-10" style="text-align:left">
                                   <asp:Label ID="lblTrnDtl"  runat="server" Text="Training Details"  class="control-label HeaderColor" Style="font-size: 19px;" ></asp:Label>
                                </div>
                                  <div class="col-sm-2">
                                 <span id="Span110" class="glyphicon glyphicon-chevron-up" style="float: right;color:#00cccc;
                                 padding: 1px 10px ! important; font-size: 18px;"></span>
                               </div>      
                           </div>
                          </div>
                               <asp:GridView ID="dgPaymentdtls" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" HorizontalAlign="Left" 
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" 
                            PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable" 
                            Style="color: blue" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Tran. Id" ItemStyle-Width="10%" 
                                    SortExpression="TransID_fk">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrxid" runat="server"  Text='<%# Eval("TransID_fk") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pymt. Mode" ItemStyle-Width="10%" 
                                    SortExpression="PaymentMode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPymtMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Receipt Id" ItemStyle-Width="10%" 
                                    SortExpression="Receiptid">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRcptId" runat="server" Text='<%# Eval("Receiptid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pymt. Amt" ItemStyle-Width="10%" 
                                    SortExpression="ChequeAmount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPymtAmt" runat="server" Text='<%# Eval("ChequeAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EFT/NEFT No." ItemStyle-Width="10%" 
                                    SortExpression="EFT/NEFT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEFTNEFTTrxNo" runat="server" Text='<%# Eval("EFT/NEFT") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cheque No." ItemStyle-Width="10%" 
                                    SortExpression="ChequeNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChqNo" runat="server" Text='<%# Eval("ChequeNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cheque Dt." ItemStyle-Width="15%" 
                                    SortExpression="ChequeDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChqDt" runat="server" 
                                            Text='<%# Eval("ChequeDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Name" ItemStyle-Width="15%" 
                                    SortExpression="BankName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" 
                                            Text="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Font-Underline="False" HorizontalAlign="Center" />
                                    <ControlStyle Font-Underline="True" />
                                    <FooterStyle Font-Underline="False" />
                                    <HeaderStyle CssClass="test" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="standardlink" HorizontalAlign="Center" />
                            <PagerStyle Font-Underline="True" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle CssClass="sublinkodd" Font-Size="Small" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="sublinkeven" />
                        </asp:GridView>
                               <div id="divNOCdetails" runat="server" style="display: block;"  class="panel-body panelContent"> <%--width: 94%--%>
                               <div class="row rowspacing" style="padding-left:20px;">
                    <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblTrnMode" runat="server" CssClass="control-label labelSize" ></asp:Label>
                        <asp:TextBox ID="lblTrnModeValue" runat="server" CssClass="form-control" disabled="disabled"></asp:TextBox>
                     </div>
                      <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblTrnLoc" runat="server" class="control-label labelSize" Style="color: black" ></asp:Label>
                        <asp:TextBox ID="lblTrnLocValue" CssClass="form-control" runat="server" disabled="disabled"></asp:TextBox>
                    </div>
                       <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblTrnInstitute" runat="server" class="control-label labelSize" Style="color: black" ></asp:Label>
                       <asp:TextBox ID="lblTrnInstituteValue" CssClass="form-control" runat="server" disabled="disabled"></asp:TextBox>
                     </div>
                    </div>
                               <div class="row rowspacing"  style="padding-left:20px;" >
                               <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblAcc1" runat="server" class="control-label labelSize" Style="color: black" text="Accrediation No"></asp:Label>
                       <asp:TextBox ID="lblAccvalue1" CssClass="form-control" runat="server" disabled="disabled" ></asp:TextBox>
                     </div>
                               <div class="col-sm-4"  style="text-align: left">
                        <asp:Label ID="lblTrnHrs1" runat="server" class="control-label labelSize" Style="color: black" text="Training Hours"></asp:Label>
                       <asp:TextBox ID="lblTrnHrsValue1" runat="server" CssClass="form-control" disabled="disabled"></asp:TextBox>
                   </div>
                             </div>
                            </div>
                              <%--</div>--%>
                         </div>


                               <div id="divExm" runat="server"  visible="false">  <%--style=" margin-left:-89px;margin-right:-13px;"--%>  <%--visible="true"--%>
                                   <div id="divEXmSCH" runat="server" > 
                               <div id="tblExmSchedule" class="panelheadingAliginment"  runat="server"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div1','Span6');return false;"> 
                              <div class="row" style="margin-top: 20px;">
                                      <div class="col-sm-10" style="text-align: left">
                                           <asp:Label ID="LblExam" runat="server" Text="Exam Schedule" class=" control-label HeaderColor" Style="font-size: 19px; margin-top: 42px;"></asp:Label>
                                       </div>
                                       <div class="col-sm-2">
                                            <span id="Span6" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important;
                                             font-size: 18px; color:#00cccc;"></span><%-- margin-right: -72px;--%>
                                       </div>
                                 </div>  
                                 </div>
                               <div runat="server" id="div1" style="display: block" class="panel-body panelContent">
                            <div class="row rowspacing" style="padding-left:20px;" >
                            <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblNWExmdt" runat="server"  class="control-label labelSize" Style="color: black"></asp:Label>
                         <asp:TextBox ID="lblNWExmdtValue" CssClass="form-control"  Enabled="false" runat="server" placeholder="System Exam Date(dd/mm/yyyy)"></asp:TextBox>
                     </div>
                            <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblpref1dt" Text="Preferred Exam Date" class="control-label labelSize " runat="server" ></asp:Label> <%--Visible="false"--%>
                          <asp:TextBox ID="lblpref1value" CssClass="form-control" runat="server" Enabled="false" placeholder="Preferred Exam Date(dd/mm/yyyy)"></asp:TextBox>
                         <asp:TextBox ID="lblNwExmfrmt" CssClass="form-control" runat="server" visible="false" Text="(dd/mm/yyyy)" ></asp:TextBox>

                    </div>
                            <div class="col-sm-4" style="text-align: left" runat="server" id="divdate">
                          <asp:Label ID="lblExmdt1" Text="Preferred Exam Date 1" class="control-label labelSize" runat="server"></asp:Label> 
                        <asp:TextBox ID="lblprefformat1" CssClass="form-control" runat="server"  visible="false"  Text="(dd/mm/yyyy)" ></asp:TextBox>
                       <asp:TextBox  ID="txtExmdt1" runat="server" CssClass="form-control mandatory"  MaxLength="15" style="margin-bottom:5px;" TabIndex="6" 
                           placeholder="Preferred Exam Date1(dd/mm/yyyy)"/>  
                            

                      </div>
                             </div>
                                    </div>
                         
                                 </div>
                      <%-- added by pallavi on 10102022 for old n new exam start --%>
                               <div id="tblexam" runat="server" visible="false">
                              <div   class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div2','Span4');return false;">
                            <div class="row" style="margin-top: 20px;" >   <%--style="padding-left:20px;"--%>
                             <div class="col-sm-10" style="text-align: left">
                                 <asp:Label ID="lblExamTitle"  class="control-label HeaderColor" runat="server"  Text="Old Exam Details"  Style="font-size: 19px; margin-top: 42px;"  ></asp:Label>
                               </div>
                             <div class="col-sm-2">
                                  <span id="Span4" class="glyphicon glyphicon-chevron-up"  style="float: right;
                                      padding: 1px 10px ! important; font-size: 18px; color:#00cccc;"></span>
                              </div>
                        </div>
                          </div>
                              <div id="div2" runat="server" style="display: block"  class="panel-body">
                            <div class="row rowspacing" style="padding-left:20px;" >
                            <div class="col-sm-4" style="text-align: left" >
                           <asp:Label ID="lblOExam" class="control-label labelSize" runat="server" Font-Bold="False" Style="color: black"> </asp:Label> 
                     <%--<asp:TextBox ID="txtExm" runat="server" Enabled="false"  CssClass="form-control mandatory"></asp:TextBox>--%>
                      </div>
                            <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblExmBody" runat="server" Cssclass="control-label labelSize"></asp:Label>
                     </div>
                            <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" cssclass="control-label labelSize"></asp:Label>
                      </div>
                          </div>
                            <div class="row" style="padding-left:20px;">
                            <div class="col-sm-4" style="text-align: left" >
                                <asp:TextBox ID="txtExm" runat="server" CssClass="form-control mandatory" enabled="false" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                   TabIndex="22"></asp:TextBox>
                               </div>
                                <div class="col-sm-4" style="text-align: left" >
                                <asp:TextBox ID="txtBody" runat="server" Enabled="false" CssClass="form-control mandatory"></asp:TextBox>
                               </div>
                                  <div class="col-sm-4" style="text-align: left" >
                                    <asp:TextBox ID="txtLang" runat="server" Enabled="false" CssClass="form-control mandatory"></asp:TextBox>
                               </div>
                          </div>
                            <div class="row rowspacing" style="padding-left:20px;">
                          <div class="col-sm-4" style="text-align: left"  >
                        <asp:Label ID="lblCentre" runat="server" CssClass="control-label labelSize"></asp:Label>
<%--                         <span style="color:Red"> *</span>--%>
                   
<%--                     </div>
                         <div class="col-sm-4" style="text-align: left"  >--%>
                     </div>
                        <div class="col-sm-4" style="text-align: left" >
                        <asp:Label ID="lblExmDt" runat="server"  CssClass="control-label labelSize" ></asp:Label>
                        </div>
                        </div>
                            <div class="row" style="padding-left:20px;">
                             <div class="col-sm-4" style="text-align: left" >
                              <asp:UpdatePanel ID="updExmCentre" runat="server">
                            <ContentTemplate>
                               <asp:TextBox ID="txtExmCentre" runat="server" Enabled="false" CssClass="form-control mandatory"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                             <div class="col-sm-4" style="text-align: left" >
                       <asp:TextBox ID="lblExmDtValue" CssClass="form-control" runat="server" Text="System Exam Date" placeholder="dd/mm/yyyy" Enabled="false"></asp:TextBox>
                        <%--<asp:TextBox ID="lbldt" CssClass="form-control" runat="server"  Text="(dd/mm/yyyy)" ></asp:TextBox>--%>
                        </div>
                        </div>
                           </div>
                 </div>
                               <div id="tblNexam" runat="server" visible="false">
                           <div class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div4','Span5');return false;">
                                <div class="row"  style="margin-top: 20px;">
                                <div class="col-sm-10" style="text-align: left">
                               <asp:Label ID="lblNExamTitle" runat="server"  Text="New Exam Details" class="control-label HeaderColor"  Style="font-size: 19px; margin-top: 42px;" ></asp:Label>
                      </div>
                                 <div class="col-sm-2">
                                   <span id="Span5" class="glyphicon glyphicon-chevron-up"  style="float: right;
                             padding: 1px 10px ! important; font-size: 18px; color:#00cccc;"></span>
                       </div>
                                                           
                       </div>
               </div>
                          <div id="div4" runat="server" style="display: block"  class="panel-body">
                          <div class="row rowspacing" style="padding-left:20px;">
                            <div class="col-sm-4" style="text-align: left" >
                       <asp:Label ID="lblNExam" runat="server" CssClass="control-label labelSize"> </asp:Label>
<%--                        <span style="color: #ff0000"> *</span>                    --%>
                        </div>
                            <div class="col-sm-4" style="text-align: left" >
                       <%-- <span style="color: #ff0000">*</span> --%>  
                            <asp:Label ID="lblNExmBody" runat="server" class="control-label labelSize" Style="color: black"></asp:Label>                
                     </div>
                            <div class="col-sm-4" style="text-align: left" >
<%--                    <span style="color:Red">*</span> --%>
                        <asp:Label ID="lblNpreexamlng" runat="server" class="control-label labelSize" Font-Bold="False" style="color:Black"></asp:Label>                         
                        </div>
                      </div>
                          <div class="row" style="padding-left:20px;">
                               <div class="col-sm-4" style="text-align: left" >
                             <asp:UpdatePanel ID="updNExam" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlNExam" runat="server"  AutoPostBack="true" CssClass="form-control form-select mandatory" OnSelectedIndexChanged="ddlNExam_SelectedIndexChanged"> 
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                         <div class="col-sm-4" style="text-align: left" >
                        <asp:UpdatePanel ID="UpdNExmBody" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmBody" runat="server" cssclass="form-control form-select mandatory " OnSelectedIndexChanged="ddlNExmBody_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                          <div class="col-sm-4" style="text-align: left" >
                              <asp:UpdatePanel ID="updNPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNpreeamlng" runat="server" CssClass="form-control form-select mandatory" OnSelectedIndexChanged="ddlNpreeamlng_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList> 
                            </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                      </div>
                          <div class="row rowspacing" style="padding-left:20px;" >
                    <div class="col-sm-4" style="text-align: left" >
                     <%-- <span style="color:Red">*</span>--%>
                        <asp:Label ID="lblNCentre" runat="server" class="control-label labelSize" Style="color: black"></asp:Label>
                       
                   </div>
                   </div>
                         <div class="row" style="padding-left:20px;">
                            <div class="col-sm-4" style="text-align: left" >
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <%--<div class="input-group">--%>
                            <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="form-control" Visible="false"> 
                                </asp:DropDownList>
                                <asp:TextBox ID="txtExmCntr" runat="server" Enabled="false" CssClass="form-control"    TabIndex="171"
                                            Visible="true"></asp:TextBox>
                                <input type="hidden" runat="server" id="hdnExmCentreCode"/>
                                     <%-- <span class="input-group-btn input-addon_extended">--%>
                                        
                                       <%-- </span>--%>
                                        
                                    <%--</div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>

                             <div class="col-sm-4"  >
                                  <asp:LinkButton ID="btnExmCentre" runat="server" CausesValidation="False"   CssClass="btn btn-success" 
                                           Text="SEARCH" class="glyphicon glyphicon-search" TabIndex="99"  style="width:70px;height:34px;padding-left:2px;margin-left: -20px"  />
                                  </div>
                   </div>

                   </div>
            </div>
                                   </div>
                      <%-- added by pallavi on 10102022 for old n new exam end --%>
                       <%-- Training Details End--%>

                       <%--Button panel start--%>  
                               <div class="row  rowspacing" style="text-align:center" >  <%--footerbtnrow--%>   <%--style="margin-right:12px;"--%>
                                  <div class="col-sm-12">
                                        <asp:LinkButton ID="btnPrev1" runat="server" Text="PREVIOUS"  CssClass="btn btn-success" visible="false" OnClick="btnPrev1_Click">
                                     <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color:White"></span> PREVIOUS
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btnPrev" runat="server" Text="PREVIOUS" CssClass="btn btn-success" OnClick="btnPrev_Click" Visible="false">
                                      <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color:White"></span> PREVIOUS                                         
                                        </asp:LinkButton> 
                                           <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-clear" Text="CANCEL" OnClick="btnClear_Click" class="glyphicon glyphicon-remove"
                                      style="border: 2px solid;border-radius: 5px;color:#f04e5e;text-align:center !important;"
                                  TabIndex="43">
<%--                                  <span class="glyphicon glyphicon-remove" style="color:White"></span> CANCEL--%>
                                </asp:LinkButton>
                                  <asp:LinkButton ID="btnCancel" runat="server" Visible="false" OnClientClick="funcClear()"  CssClass="btn btn-clear" Text="CANCEL" OnClick="btnClear_Click" style="border: 2px solid;border-radius: 5px;"  TabIndex="43">
                                  <span class="glyphicon glyphicon-remove" style="color:#f04e5e;"> </span> CANCEL
                                </asp:LinkButton>
                                        <asp:LinkButton ID="btnNextPannel1" runat="server" Text="NEXT" CssClass="btn btn-success" OnClick="btnNextPannel1_Click" Visible="true">
                                     NEXT <span class="glyphicon glyphicon-arrow-right BtnGlyphicon" style="color:White"></span>                                         
                                        </asp:LinkButton>
                                       <asp:LinkButton ID="btnNext" runat="server" Text="NEXT" CssClass="btn btn-success" OnClick="btnNext_Click" Visible="false">
                                     NEXT <span class="glyphicon glyphicon-arrow-right BtnGlyphicon" style="color:White"></span>                                         
                                        </asp:LinkButton> 
                                            <asp:LinkButton ID="btnSubmit" OnClientClick="StartProgressBar();"  Visible="false" OnClick="btnSubmit_Click"
                                                CssClass="btn btn-success" runat="server">
                                                <asp:HiddenField ID="TabName" runat="server" />
                                                <span class="glyphicon glyphicon-saved" style="color:White"></span> SUBMIT
                                            </asp:LinkButton>
                                         <asp:LinkButton ID="btnFinish" OnClientClick="StartProgressBar();"  OnClick="btnfinish_Click" Visible="false"
                                                 CssClass="btn btn-sample" runat="server">
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                <span class="glyphicon glyphicon-envelope" style="color:White"></span> SUBMIT
                                            </asp:LinkButton>
                               
                                </div>
                                </div>
                       <%--Button panel end--%>

                       </div>

                   <%-- not required --%>
                     <table id="Table1" runat="server" style="width: 90%" class="tableIsys" visible="false">
                      <tr id="trReq" runat="server">
                        <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblReqStatus" runat="server"  class="control-label" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblReqStatusValue" runat="server" class="control-label" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblpandetail" runat="server" class="control-label" Text="Is Pan name different from registered name"
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:CheckBox ID="Chkpan" runat="server"/>
                        </td>
                    </tr>
                    <tr id="trfeesdtls" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <span id="spwebtoken" runat="server" style="color:Red">
                            <asp:Label ID="lblWebTknReceived" runat="server" style="color:Black" class="control-label"></asp:Label>*</span>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left" nowrap="nowrap">
                            <asp:UpdatePanel ID="updChkFees" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkWebTknRecd" runat="server" AutoPostBack ="true"/>
                                <asp:TextBox ID="txtFeesRcvd" runat="server" CssClass="standardtextbox" Width="159px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtFeesRcvd" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                <asp:HiddenField ID="hdnRecruitAgntCode" runat="server" ></asp:HiddenField>
                        
                                <asp:Button ID="btnGetFeeDetails" runat="server" Text="Get Details" width="80px"
                                CssClass="standardbutton" OnClick="btnGetFeeDetails_Click"></asp:Button>
                           </ContentTemplate>
                           </asp:UpdatePanel>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left" colspan="2">
                            <span id="spwaiver" runat="server" visible="false" style="color: #ff0000"></span>
                            <asp:Label ID="lbladvWaiverbtn" runat="server" Visible="false" class="control-label" Text="Upload Adv's Waiver Form"></asp:Label>
                            &nbsp;
                            
                        </td>
                       
                    </tr>
                    <tr id="trlicn" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicnno" runat="server" CssClass="standardlabel control-label" ></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblLicExpDt" runat="server" CssClass="standardlabel control-label"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox control-label" BackColor="#FFFFB2"></asp:TextBox>
                        </td>
                    </tr>
                </table>
              
           
     

      <%--New ICM Details Added by rachana on 30-04-2014 Start --%>
             <table id="tblICMManual"  runat="server"  width="90%" visible="false" >
                <tr>
                    <td  align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnICM"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divICM', 'ctl00_ContentPlaceHolder1_btnICM');" />
                        <asp:Label ID="lblNICMTitle" runat="server" Font-Bold="True"  Text="Fees Details Edit"></asp:Label>
                    </td>
                </tr>
                </table>
                <div runat="server" id="divICM" style="display:none">  
          	<table runat="server" id="tblICMDetails" class="tableIsys" style="width: 90%;" >
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                      <asp:Label ID="lblPymtMode" runat="server" class="control-label" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                       <asp:UpdatePanel ID="upldPayment" runat="server">
                            <ContentTemplate>
                       <asp:DropDownList ID="DDlPymtMode" runat="server" AutoPostBack="true" 
                            CssClass="standardmenu" Width="185px" 
                            onselectedindexchanged="DDlPymtMode_SelectedIndexChanged"> 
                       </asp:DropDownList> 
                       </ContentTemplate>
                       </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPymtAmt" class="control-label" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                       <asp:TextBox ID="txtPymtAmt" runat="server" CssClass="standardtextbox"></asp:TextBox>
                       <ajaxToolkit:FilteredTextBoxExtender ID="FTEAmt" runat="server" InvalidChars="/\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtPymtAmt" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                    
                        <asp:Label ID="lblChequeNo" class="control-label" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                       <asp:TextBox ID="txtChequeNo" runat="server" CssClass="standardtextbox"></asp:TextBox>
                       <ajaxToolkit:FilteredTextBoxExtender ID="FTEChqNo" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtChequeNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                     <asp:Label ID="lblChequeDate" class="control-label" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                       <asp:TextBox  ID="txtChequedate" runat="server" CssClass="standardtextbox"   TabIndex="22"/>
                        <asp:Image ID="btncal" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                        <asp:TextBox ID="txtcal" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtChequedate" PopupButtonID="btncal" Format="dd/MM/yyyy"  />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"  ControlToValidate="txtChequedate"  Enabled="false"
                         ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <ASP:COMPAREVALIDATOR id="COMPAREVALIDATOR3" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                         controltovalidate="txtChequedate" Display="Dynamic" ></ASP:COMPAREVALIDATOR>&nbsp;
                          <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtChequedate" Display="Dynamic"
                          ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                          Type="Date"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                 <td class="formcontent"  style="width: 20%; height: 24px;">
                    
                        <asp:Label ID="lblBankName" class="control-label" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent"  style="width: 30%; height: 24px;">
                       <asp:TextBox ID="txtBankName" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEBnkName" runat="server"
                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                        TargetControlID="txtBankName">
                      </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td class="formcontent"  style="width: 20%; height: 24px;">
                    
                        <asp:Label ID="lblEFT" class="control-label" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent"  style="width: 30%; height: 24px;">
                      <asp:UpdatePanel ID="upldeft" runat="server">
                            <ContentTemplate>
                       <asp:TextBox ID="TextEFT" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEEFT" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                        FilterMode="InvalidChars" TargetControlID="TextEFT" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                       </ContentTemplate>
                       </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            </div>
            <%--New ICM Details Added by rachana on 30-04-2014 end --%>
      <%--Fees Details Start--%>
        <asp:UpdatePanel ID="updgridfees1" runat="server">
            <ContentTemplate>  
                <table id="tblFees" style="width: 90%" class="formtable" runat="server" visible="false">
                    <tr>
                        <td colspan="4" align="left" class="test">
                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnfees"
                                   style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divFees', 'ctl00_ContentPlaceHolder1_btnfees');" />
                            <asp:Label ID="lblFeesDtls" class="control-label" Text="Fees Details" runat="server" font-bold="true"></asp:Label> <%--shreela 24032014--%>
                        </td>
                    </tr>
                </table>
                <div id="divFees" runat="server" style="display: none;">
                    <table id="tblfeesdtl" style="width: 90%" class="formtable" runat="server">  
                        <tr id="trfeesDetails1" runat="server" >
                            <td  style="height: 20px" class="formcontent" > 
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <ajax:AsyncPostBackTrigger ControlID="btnGetFeeDetails" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGetFeeDetails" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
      <%--Fees Details End--%>

      <%-- Tranfer Details Start--%>
        <table id="trnsfrtitle" class="formtable" runat="server" style="width: 90%;" visible="false">
            <tr>
                <td  colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePaneltr" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblTransferDtl" class="control-label" Text="Transfer Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblTrfrFlag" class="control-label" runat="server" Style="color: black" Text="Transfer Case" ></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox"  
                                          AutoPostBack ="true"
                                          TabIndex="19"  />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanelfr" runat="server">
            <ContentTemplate>
                 <div id="divTrnsferDetails" runat="server" visible="false" style="display:block;">
                    <table class="tableIsys" style="width: 90%;">
                        <tr id="trTCCase"  runat="server"  >
			                <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label ID="lbloldLcnNo" class="control-label" runat="server" Style="color: black" Text="License No"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox id="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="21" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                             FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label class="control-label" ID="lblOldLcnexpDate" runat="server" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox  ID="txtDate" runat="server" CssClass="standardtextbox"  BackColor="#FFFFB2"  TabIndex="22"/>
                                <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate" PopupButtonID="btnoldlicense" Format="dd/MM/yyyy"  />
                                <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"  ControlToValidate="txtDate"  Enabled="false"
                                     ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <ASP:COMPAREVALIDATOR id="COMPAREVALIDATOROldLicense" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                     controltovalidate="txtDate" Display="Dynamic" ></ASP:COMPAREVALIDATOR>&nbsp;
                                <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                     ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                     Type="Date"></asp:RangeValidator>
                                                
                            </td>
			           </tr>
			           <tr id="trTCCase1" runat="server" >
			                <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label ID="lblPrevInsurerName" runat="server" class="control-label" Style="color: black" Text="Insurer Name" ></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:DropDownList id="ddlTrnsfrInsurName" runat="server" CssClass="standardmenu control-label"  BackColor="#FFFFB2" 
                                     Width="270px" TabIndex="65" ></asp:DropDownList>
                            </td>  
                            <td align="left" class="formcontent" style="width:20%;">
                                <span style="color:Red">
                                <asp:Label ID="lblNOCFlag" runat="server" class="" Style="color: black" Text="NOC Received" ></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2" AutoPostBack="false" Visible = "false"/> 
                                <asp:updatepanel ID="upnlRbtNoc" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" 
                                            CssClass="radiobtn" TabIndex="24" 
                                            AutoPostBack="true">
                                        <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                   </asp:RadioButtonList>
                                </ContentTemplate>                                        
                                </asp:updatepanel>
                             </td>
                          </tr>
                          <tr id="trAckRcv" runat="server" style="height:10%">
                                <td style="width:20%;" class="formcontent"></td>
                                <td style="width:30%;" class="formcontent"></td>
                                <td style="width:20%;" class="formcontent">
                                    <asp:updatepanel ID="upnllblAckrcv" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblAckrcv" runat="server"  Visible="false"/>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:updatepanel>
                                 </td>
                                 <td style="width:30%;" class="formcontent">
                                    <asp:updatepanel ID="upnlRbAckRev" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn"  RepeatDirection="Horizontal" 
                                                 Visible="false" TabIndex="25">
                                                <asp:ListItem Value="Y" >Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                     </asp:updatepanel>
                                 </td>
                            </tr>
                       </table>
                 </div>
             </ContentTemplate>
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
             </Triggers>
         </asp:UpdatePanel>
      <%--Transfer Details End     --%>                             
       
      <%-- Composite Details Start --%>                           
        <table id="CompositeTitle" runat="server" class="formtable" style="width: 90%;" visible="false">
            <tr>
                <td  colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanelcomp" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server" class="control-label" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblCompLcn" runat="server" class="control-label" Style="color: black" Text="Composite Case" ></asp:Label>&nbsp
                            <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="true" AutoPostBack ="true"
                                 TabIndex="20"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </td>
            </tr>
         </table>
        <asp:UpdatePanel ID="UpdatePanelcmps" runat="server">
            <ContentTemplate>
                <div id="divCompositeDetails" runat="server" visible="false" style="display:block;">
                    <table class="tableIsys" style="width: 90%;">
                        <tr id="tr2"  runat="server"  >
			                <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label ID="lblCompLicNo" class="control-label" runat="server" Style="color: black" Text="Life License No"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox id="txtCompLicNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="21" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                      FilterMode="InvalidChars" TargetControlID="txtCompLicNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label ID="lblComplicnseExpDt" class="control-label" runat="server" Style="color: black"></asp:Label>*</span> 
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox  ID="txtCompLicExpDt" runat="server" CssClass="standardtextbox"  BackColor="#FFFFB2"  TabIndex="22"/>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt" PopupButtonID="Image1" Format="dd/MM/yyyy"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"  ControlToValidate="txtCompLicExpDt"  Enabled="false"
                                     ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator id="COMPAREVALIDATOR2" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                     controltovalidate="txtCompLicExpDt" Display="Dynamic" ></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt" Display="Dynamic"
                                     ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                     Type="Date"></asp:RangeValidator>
                            </td>
			           </tr>
			           <tr id="tr3" runat="server" >
			                <td align="left" class="formcontent" style="width:20%;">
                                <span style="color: red">
                                <asp:Label ID="lblCompInsurerName" class="control-label" runat="server" Style="color: black" Text="Insurer Name" ></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:DropDownList id="ddlCompInsurerName" runat="server" CssClass="control-label standardmenu"  BackColor="#FFFFB2" 
                                     Width="270px" TabIndex="65"></asp:DropDownList>
                            </td>  
                            <td align="left" class="formcontent" style="width:20%;">
                            </td>
                            <td class="formcontent" style="width: 30%;">
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
                            <td align="left" class="formcontent" colspan="4">
                                <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox"  Enabled="true" TabIndex="21"  />
                            </td>
                        </tr>
                   </table>
               </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTccCompLcn" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
         </asp:UpdatePanel>
           <%--not required--%>
       
        <%-- Added by kalyani on 21/04/2014 for Preferred exam details start--%>         
    <%--  start Not required --%>
      
        <table id="tblExmsdtls" runat="server" style="width: 90%" class="formtable" visible="false">
                <tr>
                    <td class="test" colspan="4">
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnExmDtls"
                            style="width: 20px;" onclick="ShowReqDtlExam('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl', 'ctl00_ContentPlaceHolder1_btnExmDtls');" />
                            
                             <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>
            </table>   
        <div runat="server" id="divAgnPhotoTrnExmDtl" visible="false">  
          <table runat="server" id="Table3" class="tableIsys" style="width: 90%;">
               <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color:Red">
                        <asp:Label ID="lblExamrenew" runat="server" class="control-label" Style="color: black" Font-Bold="False"> </asp:Label>*</span>
                     
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updExam" runat="server">
                            <ContentTemplate>
                                   <asp:TextBox ID="txtexmdrenew" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color:Red"><asp:Label ID="lblExmBodyrenew" runat="server" class="control-label" Style="color: black"></asp:Label>*</span>
                  
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdExmBody" runat="server">
                            <ContentTemplate>
                                   <asp:TextBox ID="txtexmbodyrenew" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                    <span style="color:Red">
                        <asp:Label ID="lblpreexamlngrenew" runat="server" Font-Bold="False" class="control-label" style="color:Black"></asp:Label>*</span>
                  
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                              <asp:TextBox ID="txtpreexamlngrenew" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblCentrerenew" runat="server" class="control-label" Style="color: black"></asp:Label>*</span>
                 
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                              <asp:TextBox ID="txtcenterrenew" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>  
          <%-- end  Not required --%>

                         <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
               <%-- <table  class="tableIsys" id="tblCndURN" runat="server" style="width: 90%;" visible="false">--%>
               <div id="tblCndURN" runat="server" style="margin-bottom:20px" visible="false">
                <div class="panel-heading subheader" >
<%--                     onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div1','Span3');return false;" --%>
<%--                    commit by pallavi on 10102022--%>
                                                        <div class="row rowspacing" >
                                                             <div class="col-sm-10" style="text-align: left">
                                                                   <asp:Label ID="lbltitleURN" runat="server"  class="subheader" Text="Candidate URN No" ></asp:Label>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <span id="Span3" class="glyphicon glyphicon-menu-hamburger"  style="float: right;
                                                                    padding: 1px 10px ! important; font-size: 18px; color:#034ea2;"></span>
                                                            </div>
                                                           
                                                        </div>
                                                    </div>
                   <%-- <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbltitleURN" runat="server" Font-Bold="True" Text="Candidate URN No."></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td align="left" class="formcontent">--%>
                       
                    </div>
               <%-- </table>--%>  <%--commit by pallavi on 10102022 as hearder for URN not required--%>

            </ContentTemplate>
        </asp:UpdatePanel>

          <%--  start Not required --%>
      <%-- added by shreela on 25-04-2014 for Renewal Details start--%>
                         <table id="tblRenewalCollapse" style="width: 90%" class="formtable" runat="server" visible="false">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnRenew"
                        style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRenewal', 'ctl00_ContentPlaceHolder1_btnRenew');" />
                    <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" class="control-label" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
                         <div id="divRenewal" runat="server" style="display: block" visible="false">
        <table id="tblRenewal" style="width: 90%" class="tableIsys" runat="server">
           <tr>
             <td align="left" colspan="4" class="formcontent" style="width:20%;">
             <asp:Label ID="lblCndType" runat="server" class="control-label" style="color:Black"></asp:Label>
             </td>
             <td id="Td1" runat="server" class="formcontent">
             <asp:Label ID="lblCndVal" class="control-label" runat="server"></asp:Label>
             </td>
             <td id="Td2" runat="server" class="formcontent" style="width:20%;">
             <asp:Label ID="lblCount" runat="server" style="color:Black"></asp:Label>
             </td>
             <td id="Td3" runat="server" class="formcontent" >
             <asp:Label ID="lblCountVal" class="control-label" runat="server"></asp:Label>
             </td>
           </tr>
        
            <%--Added by kalyani to fetch Renewal record on QC module start--%>
           <tr id="trCompQC" runat="server" visible="false">
             <td id="Td8" align="left" colspan="4" runat="server" class="formcontent" style="width:20%;">
             <span style="color:Red">
             <asp:Label ID="lblQCRenewType" runat="server" class="control-label" style="color:Black"></asp:Label></span>
             </td>
             <td id="Td9" runat="server" class="formcontent" style="width:30%;">
             <asp:Label ID="lbltxtQCRenewType" runat="server" class="control-label" style="color:Black"></asp:Label>
             </td>
             <td id="Td10" runat="server" class="formcontent" style="width:20%;">
             <span style="color:Red">
             <asp:Label ID="lblQClyfTraining" runat="server" class="control-label" style="color:Black"></asp:Label></span>
             </td>
             <td id="Td11" runat="server" class="formcontent" style="width:30%;">
             <asp:Label ID="lbltxtQClyfTraining" runat="server" class="control-label" style="color:Black"></asp:Label>
             </td>
           </tr>
           <%--Added by kalyani to fetch Renewal record on QC module end--%>
        </table>
        </div>
          <%-- end  Not required --%>

       <%-- added by shreela on 25-04-2014 for Renewal Details end--%>   
  
          <div id="tblPrefExm" runat="server"  visible="false" class="panel  " style="display: none" >
    <%--  <table runat="server" id="tblPrefExm" class="tableIsys" style="width: 90%;" visible="false">--%>
                          <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','Span7');return false;">
                                                        <div class="row" >
                                                             <div class="col-sm-10" style="text-align: left">
                                                                   <asp:Label ID="Label3" runat="server"  Text="Preferred Exam Schedule"  class="subheader"></asp:Label>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <span id="Span7" class="glyphicon glyphicon-menu-hamburger"  style="float: right;
                                                                    padding: 1px 10px ! important; font-size: 18px; color:#034ea2;"></span>
                                                            </div>
                                                           
                                                        </div>
                                                    </div>
                          <div id="div6" runat="server" style="display: block"  class="panel-body">
                            <div class="row" >
                        
                            
                       <div class="col-sm-4" style="text-align: left" >
                            <asp:Label ID="lblExmdt2" runat="server" class="control-label" Text="Preferred Exam Date 2" Font-Bold="False" Visible="false"></asp:Label>
                          </div>
                        <div class="col-sm-4">
                        <asp:TextBox ID="txtExmdt2" runat="server" CssClass="standardtextbox" Width="150"
                         RequiredValidationMessage="Mandatory!" RequiredField="false" Visible="false"/>
                      </div>
                          </div>
                      </div>
                            </div>
                             <%-- Exam details end--%>
       
           <%--Not required  usha--%>
        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
            <ContentTemplate>
                <div id="divRmrk" runat="server" style="display: none;">
                    <table class="tableIsys" style="width: 90%;">
                        <tr id="trRmrk" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <asp:Label ID="lblSMRmrks" runat="server" Style="color: black" class="control-label" Text="Remarks"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" colspan="3">
                                <asp:TextBox ID="txtRemrk" runat="server" Rows="3"  TextMode="multiline"  CssClass="standardtextbox" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
             
            </Triggers>
        </asp:UpdatePanel>
        <%--Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 End--%>
      <%-- Candidate Documents Upload Start--%>
        <table class="formtable" id="tblupload" runat="server" style="width: 90%;" visible="false">
            <tr id="trupload" runat="server" visible="false">
                <td align="center" >
                    <asp:Label ID="lblNoteUpld" runat="server" class="control-label" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in PDF format" ForeColor="red"></asp:Label>
                </td>
            </tr>
            <tr id="trdownld" runat="server">
                <td align="center" >
                    <asp:Label ID="lblNote" runat="server" class="control-label" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format" ForeColor="red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="test"  style="text-align: left;">
                    <asp:Label ID="lblCanddoc" runat="server" class="control-label" Text="Candidate Document Upload" Font-Bold="true"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Mandatory Documents" OnClick="lnkmandtry_click"> </asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
       </table>
        <div id="divUpload" runat="server" style="display: table;" visible="false">
            <table class="formtable" align="center" style="width: 90%;">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelUpld" runat="server">
                            <ContentTemplate>
                            <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="formtable"
                                PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging" OnRowCommand="dgView_RowCommand"
                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable" OnRowDataBound="dgView_RowDataBound"
                                HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15">
                                <Columns>
                                    <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                        <ItemTemplate>
                                        <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                        <ItemTemplate>
                                        <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Upload Documents">
                                        <ItemTemplate>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_Upload" runat="server" CssClass="standardbutton" Text="Upload" Enabled="false" Visible="false" Width="80px"
                                                 onclick="btn_Upload_Click"/>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd">
                                        <ContentTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload" Width="80px"
                                           onclick="btn_ReUpload_Click"/>
                                           </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
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
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                            </PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                        </ContentTemplate>
                       <%-- <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />  
                        </Triggers>--%>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
      <%-- Candidate Documents Upload End--%> 
      <%-- Candidate Documents ReUpload Start--%>
        <table class="formtable" id="Table2" runat="server" style="width: 90%;">
            <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
               <td class="test" colspan="3" style="text-align: left;">
                    <input runat="server" type="button" class="standardbutton" value="-" visible="false"
                        id="BtnReUpload" style="width: 20px;" onclick="FunShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles', 'ctl00_ContentPlaceHolder1_BtnReUpload');" />
                    <asp:Label ID="lblcndupload" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divReUpload" runat="server" style="display: table;">
            <table class="formtable" align="center" style="width: 90%;">
                <tr id="tr_reupload" runat="server" visible="false">
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CssClass="formtable"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable" OnRowDataBound="GridView1_RowDataBound"
                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="210px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Date" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="130px">
                                <ItemTemplate>
                                        <asp:Label ID="lblReupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                             
                                <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileReUpload" runat="server" Width="360px" Filebytes='<%# Bind("UserFileName") %>'>
                                        </asp:FileUpload>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoccode1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                            </PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
      <%-- Candidate Documents ReUpload End--%>

      <%-- Candidate Documents Download Start--%>
        <table class="formtable" id="tblDwnld" runat="server" style="width: 90%;">
            <tr id="tr_DocumentDownload" runat="server" visible="false">
                <td class="test" colspan="3" style="text-align: left;">
                    <input runat="server" type="button" class="standardbutton" value="-" visible="false"
                        id="btnDwnld" style="width: 20px;" onclick="ShowReqDtlDwnld('ctl00_ContentPlaceHolder1_divDwnldFiles', 'ctl00_ContentPlaceHolder1_BtnDwnld');" />
                    <asp:Label ID="lblcndDnwld" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divDwnld" runat="server" style="display: table;width: 90%;" visible="false">
            <table class="formtable" align="center" style="width: 100%;">
                <tr id="tr_Dwnld" runat="server">
                    <td>
                      <asp:GridView ID="dgDwnld" runat="server" AllowSorting="True" CssClass="formtable"
                            OnPageIndexChanging="dgDwnld_PageIndexChanging" PagerStyle-HorizontalAlign="Center" OnRowDataBound="dgDwnld_RowDataBound"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="formtable" 
                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="185px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Date" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="350px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                <%--    <div class="btn btn-xs btn-primary"><i class="fa fa-download"></i>--%>
                                        <asp:Button ID="btn_Dwnld" runat="server" CssClass="standardbutton" Text="Download"
                                            onclick="btn_Dwnld_Click"/><%--</div>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                            </PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
      <%-- Candidate Documents Download End--%>

         <%--added by shreela for old license details start--%>
        <table id="tbloldlic" runat="server" style="width:90%"  class="tableIsys" visible="false">
         <tr>
            <td align="center" colspan="4">
                    <asp:Label ID="Label4" class="control-label" runat="server" Text="NOTE: License will be updated once license details are uploaded from Lic User" ForeColor="red"></asp:Label>
            </td>
        </tr>
            <tr>
                <td id="tdoldlic" class="test" runat="server" colspan="4">
                    <asp:Label ID="lbloldlic" class="control-label" runat="server" Text="Old License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divoldlic" runat="server" style="display:block" visible="false">
        <table id="tbloldlicdtls" runat="server" class="tableIsys" style="width:90%">
            <tr>
                <td align="left" class="formcontent" style="width:20%">
                    <asp:Label ID="lbloldlicno" class="control-label" Text="License No" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%">
                    <asp:Label ID="lbloldlicnoval" class="control-label" runat="server"></asp:Label>
                </td>
                <td align="left" class="formcontent" style="width:20%">
                    <asp:Label ID="lbloldexpdate" class="control-label" Text="Old LicenseExpDate" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width:30%">
                    <asp:Label ID="lbloldexpdateval" class="control-label" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formcontent" style="width:20%">
                    <asp:Label ID="lbloldlicissu" class="control-label" Text="Old License Issue Date" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width:30%">
                    <asp:Label ID="lbloldlicissuval" class="control-label" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width:20%">
                </td>
                <td class="formcontent" style="width:30%">
                </td>
            </tr>
        </table>
        </div>
        <table id="tblnewlic" runat="server" style="width:90%"  class="tableIsys" visible="false">
            <tr>
                <td id="tdnewlic"  class="test" runat="server" colspan="4">
                    <asp:Label ID="lblnewlic" runat="server" class="control-label" Text="New License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divnewlic" runat="server" style="display:block" visible="false">
        <table id="tblnewlicdtls" runat="server" class="tableIsys" style="width:90%">
            <tr>
                <td align="left" class="formcontent" style="width:20%">
                    <asp:Label ID="lblnewlicno"  class="control-label" Text="License No" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%">
                    <asp:Label ID="lblnewlicnoval" class="control-label" runat="server"></asp:Label>
                </td>
                <td align="left" class="formcontent" style="width:20%">
                    <asp:Label ID="lblnewexpdate" class="control-label" Text="LicenseExpDate" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width:30%">
                   <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="standardtextbox"></asp:TextBox>
                   <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                   <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtnewexpdate"
                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" Enabled="false" />
                   <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtnewexpdate"
                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                            Type="Date" ControlToValidate="txtnewexpdate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtnewexpdate" Display="Dynamic"
                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                            Type="Date"></asp:RangeValidator>
                   
                  <%--  <asp:Label ID="Label8" runat="server"></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td class="formcontent" style="width:20%">
                    <asp:Label ID="lblnewlicissu" class="control-label" Text="License Issue Date" runat="server"></asp:Label>
                </td>
                <td class="formcontent" style="width:30%">
                    <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="standardtextbox"></asp:TextBox>
                       <asp:Image ID="btnCalenderissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                   <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtnewlicissu"
                            PopupButtonID="btnCalenderissu" Format="dd/MM/yyyy" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ControlToValidate="txtnewlicissu"
                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                            Type="Date" ControlToValidate="txtnewlicissu" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtnewlicissu" Display="Dynamic"
                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                            Type="Date"></asp:RangeValidator>
                </td>
                <td class="formcontent" style="width:20%">
                </td>
                <td class="formcontent" style="width:30%">
                </td>
            </tr>
        </table>
        </div>
          <%--added by shreela for new license details end--%>
         <%--CheckBox Start--%>
      <table class="tableIsys" id="tblCheck" runat="server" visible="false">
        <tr>
            <td>
                <asp:CheckBox ID="chckDwnld" runat="server" Text="Confirm Successful File Download" OnCheckedChanged="chckDwnld_CheckedChanged" AutoPostBack="true"/>
            </td>
        </tr>
      </table>
      <%--CheckBox End--%>        <%-- end not required --%>

      

                        <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div> 

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style="width: 316px;">
                <div class="modal-header1" style="text-align:center;margin-top: 10px;">  <%-- background-color: #00cccc;--%>
                    <asp:Label ID="Label8" class="control-label" Text="INFORMATION" runat="server" Font-Bold="true" style="text-align:center; margin-left: -2px;font-size: 19px;color: #034ea2;"></asp:Label>

                </div>
                <div class="modal-body" style="text-align:center">
                    <asp:Label ID="lbl_popup" class="control-label" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">  <%--style="text-align:center"--%>
                    <asp:LinkButton  runat="server" id="btnok1"  cssclass="btn btn-success" Text="OK"
                        style="margin-top: -6px; margin-right: 105px;text-align:center;" onclick="btnok1_Click">
                        <span class="glyphicon glyphicon-ok" style="color:white;"></span> OK
                     </asp:LinkButton> <%-- data-dismiss="modal"--%>

                    <%--</button>--%>

                </div>
            </div>

        </div>
    </div>

    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style="width: 316px;">
                <div class="modal-header1" style="text-align:center;margin-top: 10px;">  <%-- background-color: #00cccc;--%>
                    <asp:Label ID="Label7" class="control-label" Text="INFORMATION" runat="server" Font-Bold="true" style="text-align:center; margin-left: -2px;font-size: 19px;color: #034ea2;"></asp:Label>

                </div>
                <div class="modal-body" style="text-align:center">
                    <asp:Label ID="lblSub1" class="control-label" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">  <%--style="text-align:center"--%>
                    <asp:LinkButton  runat="server" id="btnokRxm"  cssclass="btn btn-success" Text="OK"
                        style="margin-top: -6px; margin-right: 105px;text-align:center;" onclick="btnokRxm_Click">
                        <span class="glyphicon glyphicon-ok" style="color:white;"></span> OK
                     </asp:LinkButton> <%-- data-dismiss="modal"--%>

                    <%--</button>--%>

                </div>
            </div>

        </div>
    </div>

    <div id="divButtons" runat="server"  >
        <%--PopUp for Mandatory Documents Start--%>
        <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
            DropShadow="true" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="buttonNull" runat="server" Style="display: none" />
        <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table class="formtable" align="center" style="width: 40%;">
                        <tr id="trdgDetails" runat="server">
                            <td class="formcontent" colspan="3" style="height: 40px">
                                <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                    Width="450px" RowStyle-CssClass="formtable" AllowSorting="True">

                                    <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandatory Documents">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle Font-Names="verdana" />
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" Font-Size="9px" />
                                    <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%--align="center">--%>
                                <%-- <div class="btn btn-xs btn-primary"><i class="fa fa-times"></i>--%>
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" /><%--</div>--%>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnpopcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <%--PopUp for Mandatory Documents End--%>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnWebTknCon" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hdnBizSrc" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hdnWebTkn" runat="server" />
                </td>
                <td>
                    <input type="hidden" runat="server" id="hdnUserId" />
                </td>
                <td>
                    <asp:HiddenField ID="hdnMobileVerify" runat="server" />
                    <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hdnMobile" runat="server" />
                    <asp:HiddenField ID="hdnEmail" runat="server" />
                </td>
                <td>
                    <asp:HiddenField ID="hdnCanid" runat="server" />
                    <asp:HiddenField ID="hdnCndName" runat="server" />
                    <asp:HiddenField ID="hdnoldlicexpdate" runat="server" />
                </td>
                <%--   <td>
                 <asp:HiddenField ID="hdnCndNo" runat="server" />
              </td>--%>
            </tr>
        </table>

        <%--//added by pranjali on 26-04-2014--%>
        <asp:Panel ID="Panel2" runat="server" Style="display: none; background-color: #C0C0C0;">
            <center>
<img src="../../../theme/iflow/animated_progress_bar.gif" />
<br />
<asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red"></asp:Label>
</center>
        </asp:Panel>

        <asp:Label runat="server" ID="Label2" Style="display: none" />

        <asp:HiddenField ID="hdnfield" runat="server" />
        <asp:HiddenField ID="HdnTccDate" runat="server" />
        <asp:HiddenField ID="HdnLicTccDate" runat="server" />
        <asp:Button Text="btnok" ID="btnopen" OnClick="btnopen_Click" runat="server" Visible="false" />
        <%--//added by pranjali on 26-04-2014--%>
        <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
            <iframe runat="server" id="ifrmMdlPopup" frameborder="0" display="none" style="height: 220px; width: 696px"></iframe>
        </asp:Panel>
        <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" class="modalpopupmesg" Width="320px" Height="266px"
            Visible="false">
            <table width="100%">
                <tr align="center">
                    <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 391px;">
                        <br />
                        <center>
                        <asp:Label ID="lbl" runat="server"></asp:Label><br />
                        <br />
                    </center>
                        <br />
                    </td>
                </tr>
            </table>
            <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-success" OnClientClick="Closewin()" /></center>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl"
            BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
            DropShadow="true" OkControlID="btnok" Y="100">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlMdl1" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="170px" Visible="false">
            <table width="100%">
                <tr align="center">
                    <td width="100%" class="test" colspan="1" style="height: 32px;text-align:center;">INFORMATION
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 391px;">
                        <br />
                        <center>
                        <asp:Label ID="lbl1" runat="server"></asp:Label><br />
                        <br />
                    </center>
                        <br />
                    </td>
                </tr>
            </table>
            <center>
            <asp:Button ID="Button1" runat="server" Text="OK" TabIndex="105" Width="80px" /></center>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
            DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl1" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" ID="PnlExm" Width="600" Height="355" display="none">
            <iframe runat="server" id="IframeExm" scrolling="no" width="100%" frameborder="0"
                display="none" style="height: 100%; background-color: White;"></iframe>
        </asp:Panel>
        <asp:Label runat="server" ID="Label6" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDExm"
            DropShadow="false" TargetControlID="Label6" PopupControlID="PnlExm" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>

        <%--added by shreela on 14/07/2014--%>
        <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
            <table width="100%">
                <tr align="center">
                    <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                    </td>
                </tr>
            </table>
            <table>
            </table>
            <center>
            <br />
            <asp:Label ID="lblSub" runat="server"></asp:Label></center>
            <br />
            <center>
            <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px" OnClientClick="CloseSub()"  />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblSub"
            BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
            DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
        </ajaxToolkit:ModalPopupExtender>
        <%--added by shreela on 14/07/2014--%>
        <%--loader image start--%>
        <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
            BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
            TargetControlID="hiddenField1" PopupControlID="Panel1">
        </ajaxToolkit:ModalPopupExtender>
        <asp:HiddenField ID="hiddenField1" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
            <%--background-color: #C0C0C0;--%>
            <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
        </asp:Panel>
        <%--loader image end--%>
    </div>

    <div class="row" style="align-cenetr">
        <div class="col-sm-2">
            <div id="div7" runat="server" style="display: none;">
                <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                Loading...
            </div>
        </div>
    </div>
</asp:Content>



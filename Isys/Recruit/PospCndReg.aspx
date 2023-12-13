<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PospCndReg.aspx.cs" Inherits="Application_ISys_Recruit_PospCndReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
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
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.mintxtAddrP1.js"></script>
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script type="text/javascript">

        function fnSetTabs(strTabIndex) {
            debugger;
            if (strTabIndex == '1') {
                //document.getElementById("ancRel").style.backgroundColor = "#fffefe";
                //document.getElementById("ancLegal").style.backgroundColor = "#f5f5f5";
                //document.getElementById("ancLegal").style.color = "red";
                //document.getElementById("ancRel").style.color = "black";
                document.getElementById("menu1").style.display = "block";
                document.getElementById("menu2").style.display = "none";
                //document.getElementById("EmptyPagePlaceholder_hdnTabIndex").value = "1";

                //document.getElementById("ancRel").style.backgroundColor = "#FFFFFF";


            }

            if (strTabIndex == '2') {
                //document.getElementById("ancLegal").style.backgroundColor = "#fffefe";
                //document.getElementById("ancRel").style.backgroundColor = "#f5f5f5";
                //document.getElementById("ancLegal").style.color = "black";
                //document.getElementById("ancRel").style.color = "red";
                document.getElementById("menu1").style.display = "none";
                document.getElementById("menu2").style.display = "block";
                //document.getElementById("EmptyPagePlaceholder_hdnTabIndex").value = "2";
                //document.getElementById("ancRel").style.backgroundColor = "#f5f5f5";
                return true;

            }

        }




        //     added by usha
        function AllowIFSC(id) {
            debugger;
            var val = document.getElementById(id).value.trim();
            if (val) {
                if (val.length == "") {
                    alert("Please enter IFSC code");
                    return false;
                }
                else if (val.length > 11 || val.length < 11) {
                    alert("IFSC Code Should be 11 digit long");
                    return false;
                }
                else {
                    var regex = /^[a-zA-Z]*$/;
                    var regex_for_alphanum = /^[a-zA-Z0-9]*$/
                    if (!(regex.test(val.substring(0, 4)) && val.charAt(4) == '0' && regex_for_alphanum.test(val.substring(5)))) {
                        alert("Invalid IFSC code format");
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
            else {
                alert("Please enter IFSC code");
                return false;
            }
        }


        function funcShowPopup(strPopUpType, strbtnid) {
            //debugger;
            if (strPopUpType == "District") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopDistrict.aspx?strHDist=" + document.getElementById('<%=txtDistric.ClientID %>').id + "&DistDesc=" + document.getElementById('<%=txtDistric.ClientID%>').id + "&StateCode="
                    + document.getElementById('<%=txtStateCodeP.ClientID %>').value + "&txtDisc=" + document.getElementById('<%=txtDistric.ClientID %>').value
                    + "&shdnPinFrom=" + document.getElementById('<%=hdnPinFrom.ClientID %>').id + "&shdnPinTo=" + document.getElementById('<%=hdnPinTo.ClientID %>').id
                    + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "statedemo") {
                ////debugger;
                if (document.getElementById('<%=ddlState.ClientID %>').value == "Select") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlState.ClientID %>').focus();
                 return false;
             }
             else {
                    //        alert("HI");
                 $find("mdlViewBID").show();
                 document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlState.ClientID %>').value
                     + "&field1=" + document.getElementById('<%=txtPinP.ClientID %>').id + "&field2=" + document.getElementById('<%=txtDistric.ClientID %>').id
                     + "&field3=" + document.getElementById('<%=txtcity.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea.ClientID %>').id +
                     "&field11=" + document.getElementById('<%=hdnPin.ClientID %>').id + "&field21=" + document.getElementById('<%=hdnDist.ClientID %>').id +
                     "&field31=" + document.getElementById('<%=hdnCity.ClientID %>').id + "&field41=" + document.getElementById('<%=hdnArea.ClientID %>').id
                        + "&btnid=" + strbtnid + "&mdlpopup=mdlViewBID";
             }
         }
         if (strPopUpType == "statedemo1") {
             if (document.getElementById('<%=ddlstate1.ClientID %>').value == "Select") {
                    alert("Please select State.");
                    document.getElementById('<%= ddlstate1.ClientID %>').focus();
                 return false;
             }
             else {
                 $find("mdlViewBID").show();
                 document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopAgtCnct.aspx?Code=" + document.getElementById('<%=ddlstate1.ClientID %>').value
                     + "&field1=" + document.getElementById('<%=txtPermPostcode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtpermDistrict.ClientID %>').id
                     + "&field3=" + document.getElementById('<%=txtcity1.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea1.ClientID %>').id +
                     "&field11=" + document.getElementById('<%=hdnPin1.ClientID %>').id + "&field21=" + document.getElementById('<%=hdnpermDist.ClientID %>').id +
                     "&field31=" + document.getElementById('<%=hdnCity1.ClientID %>').id + "&field41=" + document.getElementById('<%=hdnArea1.ClientID %>').id
                        + "&btnid=" + strbtnid + "&mdlpopup=mdlViewBID";
             }
         }

            //Added by kalyani on 31-12-2013 for permanant address district field
         if (strPopUpType == "permDistrict") {
             $find("mdlViewBID").show();
             document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopDistrict.aspx?strHDist=" + document.getElementById('<%=txtpermDistrict.ClientID %>').id + "&DistDesc=" + document.getElementById('<%=txtpermDistrict.ClientID%>').id + "&StateCode="
                 + document.getElementById('<%=txtStateCodeP.ClientID %>').value + "&txtDisc=" + document.getElementById('<%=txtDistric.ClientID %>').value
                 + "&shdnPinFrom=" + document.getElementById('<%=hdnpermPinFrom.ClientID %>').id + "&shdnPinTo=" + document.getElementById('<%=hdnpermPinTo.ClientID %>').id
                    + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "state") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeP.ClientID %>').value + "&Desc=" + document.getElementById('<%=txtStateDescP.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtStateCodeP.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "state") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeP.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtStateDescP.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtStateCodeP.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "state1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeR1.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtStateDescR1.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtStateCodeR1.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescR1.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "occup") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopOccupation.aspx?Code=" + document.getElementById('<%=txtOccupationCode.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtOccupationCode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtOccupationDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "state2") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeR2.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtStateDescR2.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtStateCodeR2.ClientID %>').id + "&field2=" + document.getElementById('<%=txtStateDescR2.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "permstate") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopState.aspx?Code=" + document.getElementById('<%=txtPermStateCode.ClientID %>').value + "&Desc=" + document.getElementById('<%=txtPermStateDesc.ClientID %>').value + "&field1="
                 + document.getElementById('<%=txtPermStateCode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtPermStateDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";

            }
            if (strPopUpType == "country") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtCountryDescP.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').id
                 + "&field2=" + document.getElementById('<%=txtCountryDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            if (strPopUpType == "nationality") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/Common/PopCountry.aspx?Code=" + document.getElementById('<%=txtNationalCode.ClientID %>').value
                 + "&Desc=" + document.getElementById('<%=txtNationalDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtNationalCode.ClientID %>').id
                 + "&field2=" + document.getElementById('<%=txtNationalDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
        }

        function openBranchList(BizSrc, ChnCls, AgentType, MgrCode, Type, IsAgt, agttype) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../ChannelMgmt/UntLst.aspx?UnitCode=&CmpUntObj=&UntObj=&BizSrc=" + BizSrc
                + "&ChnCls=" + ChnCls + "&AgentType=" + AgentType + "&MgrCode=" + MgrCode + "&UntAdr=&Type=" + Type + "&OutUntCode=&hdn2=&OutUntDesc=&hdn1=&OutCmpUnt=&RecruitDate=&Source=1&IsAgt=" + IsAgt
                + "&mdlpopup=mdlViewBID&agttype=" + agttype + "&page=REG";
        }

        $(function () {
            //debugger;

            $("#<%= txtDOB.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtIC.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtDateOfAppointmentTrnsfr.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtDateOfCessationTrnsfr.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtYrPass.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtDateOfAppointment.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtDateOfCessation.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtTagApp.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });

        });

        function funAddTr() {
            //debugger;

            $("#ctl00_ContentPlaceHolder1_txtIC").datepicker('setDate', null);
            $("#ctl00_ContentPlaceHolder1_txtDateOfAppointmentTrnsfr").datepicker('setDate', null);
            $("#ctl00_ContentPlaceHolder1_txtDateOfCessationTrnsfr").datepicker('setDate', null);
            $("#ctl00_ContentPlaceHolder1_txtDateOfAppointment").datepicker('setDate', null);
            $("#ctl00_ContentPlaceHolder1_txtDateOfCessation").datepicker('setDate', null);
        }

        function funAddTag() {
            //debugger;

            $("#ctl00_ContentPlaceHolder1_txtTagApp").datepicker('setDate', null);
        }

        function ShowReqDtlResize(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
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
                ShowError(err.description);
            }
        }

    </script>
    <script language="javascript" type="text/javascript">

        var path = "<%=Request.ApplicationPath.ToString()%>";
        var ChangeFlag = "0";
        var dtYDOB = "0";
        //function ShowReqDtl(divName, btnName) {
        //    ////debugger;
        //    var objnewdiv = document.getElementById(divName);
        //    var objnewbtn = document.getElementById(btnName);

        //    if (objnewdiv.style.display == "block") {
        //        objnewdiv.style.display = "none";
        //        objnewbtn.className = 'glyphicon glyphicon-collapse-up'   
        //    }
        //    else {
        //        objnewdiv.style.display = "block";
        //        objnewbtn.className = 'glyphicon glyphicon-menu-hamburger' 
        //    }
        //}










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
                ShowError(err.description);
            }
        }

        function popup() {
            $("#myModal").modal();
        }
        //added by amruta on 2.6.2015 for grid in composite start
        function funalert() {
            alert("Only four entries are allowed.");
            ////return false;
        }
        //added by amruta on 2.6.2015 for grid in composite endss
        function CheckSpaces() {
            ////debugger;


            var strContent = "ctl00_ContentPlaceHolder1_";
            var strText = document.getElementById(strContent + "txtGivenName").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtGivenName").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 2) {
                    alert("More than 2 spaces are not allowed in Given Name");
                    document.getElementById(strContent + "txtGivenName").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }



            }

        }
        //Ended by Rahul Kamble on 28-04-2015 for Given Name Space validation end

        //Added by Nikhil Pathari on 11-05-2015 for father Name Space validation start

        function AllowSpace() {
            ////debugger;


            var strContent = "ctl00_ContentPlaceHolder1_";
            var strText = document.getElementById(strContent + "txtFathername").value;
            strText = SpaceTrim(strText);
            document.getElementById(strContent + "txtFathername").value = strText;
            var count = 0;

            if (strText.length > 0) {
                for (var i = 0; i < strText.length; i++) {
                    if (strText.charAt(i) == " ") {
                        count++;
                    }
                }
                if (count > 1) {
                    alert("More than 1 spaces are not allowed in Father Name");
                    document.getElementById(strContent + "txtFathername").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }

                //ProgressBarModalPopupExtender.Hide();

            }

        }

        //Ended by Nikhil Pathari on 11-05-2015 for Father Name Space validation end
        function funpan() {
            ////debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "ddlCasteCat").focus();
        }
        function funrecruitercode() {
            ////debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "ddlCnctType").focus();
        }

        //Commented by shreela on 13/03/14 

        //function Special() {
        //   ////debugger;
        //    if (!(event.keyCode == 97 || event.keyCode == 98 || event.keyCode == 99 || event.keyCode == 100 || event.keyCode == 101 || event.keyCode == 102 || event.keyCode == 103 || event.keyCode == 104 || event.keyCode == 105 || event.keyCode == 106
        //               || event.keyCode == 107 || event.keyCode == 108 || event.keyCode == 109 || event.keyCode == 109 || event.keyCode == 109 || event.keyCode == 110 || event.keyCode == 111 || event.keyCode == 112 || event.keyCode == 113 || event.keyCode == 114 || event.keyCode == 115
        //               || event.keyCode == 116 || event.keyCode == 117 || event.keyCode == 118 || event.keyCode == 119 || event.keyCode == 120 || event.keyCode == 121 || event.keyCode == 122)) {
        //        alert("Only alphabets are allowed");
        //        event.returnValue = false;
        //    }
        //}

        //function AlertMsgs(msgs) {
        //    alert(msgs);
        //}
        //End shreela on 10/03/14
        //Popup finction


        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            //document.getElementById("btnSubmit").click();
            return true;
        }

        //Added by Prathamesh 16-7-15 start for Profiling

        function funProfiling() {
            //debugger;

            // funValidate();
            var strContent = "ctl00_ContentPlaceHolder1_";

            //Added by Prthamesh 15-7-15 start FOR Profiling

            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 0) {

                alert("Please Select Agent Type");
                document.getElementById(strContent + "ddlagntype").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            //Validation IsWorking
            //if (document.getElementById(strContent + "ddlIsWrkng") != null) {
            if (document.getElementById(strContent + "ddlIsWrkng").selectedIndex == 0) {
                alert("Please select Is he Working With Some other Group Company");
                document.getElementById(strContent + "ddlIsWrkng").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation IsWorking then specify CompName
            if (document.getElementById(strContent + "ddlIsWrkng").selectedIndex == 1) {

                if (document.getElementById(strContent + "ddlcompName").selectedIndex == 0) {
                    alert("Please specify Company Name");
                    document.getElementById(strContent + "ddlcompName").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation No. of YEARS In Insurance
            //if (document.getElementById(strContent + "ddlNoOfYrsIns") != null) {
            if (document.getElementById(strContent + "ddlNoOfYrsIns").selectedIndex == 0) {
                alert("Please select No. of Years In Insurance");
                document.getElementById(strContent + "ddlNoOfYrsIns").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation No. of YEARS In Reliance
            if (document.getElementById(strContent + "ddlNoOfYrs").selectedIndex == 0) {
                alert("Please select No. of Years with company");
                document.getElementById(strContent + "ddlNoOfYrs").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            //Validation for agenType
            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 5) {

                if (SpaceTrim(document.getElementById(strContent + "txtOthers").value) == "") {
                    alert("Please fill From Others please Specify");
                    document.getElementById(strContent + "txtOthers").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation VEHICLE MANUFACTURER DEALING WITH
            if (document.getElementById(strContent + "ddlagntype").selectedIndex == 2) {

                if (document.getElementById(strContent + "ddlTypeOfVehicle").selectedIndex == 0) {
                    alert("Please select Type of Vehicle Dealing in");
                    document.getElementById(strContent + "ddlTypeOfVehicle").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (document.getElementById(strContent + "ddlVechManuf").selectedIndex == 0) {
                    alert("Please select VEHICLE MANUFACTURER DEALING WITH");
                    document.getElementById(strContent + "ddlVechManuf").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (document.getElementById(strContent + "txtDlrCompName").value == "") {
                    alert("Please Enter Company Name");
                    document.getElementById(strContent + "txtDlrCompName").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }


            //Validation Potential of Agent
            //if (document.getElementById(strContent + "ddlAvgMonthlyIncm") != null) {
            if (document.getElementById(strContent + "ddlAvgMonthlyIncm").selectedIndex == 0) {
                alert("Please select Potential of agent");
                document.getElementById(strContent + "ddlAvgMonthlyIncm").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation COMPETITOR COMPANY Name 1
            //if (document.getElementById(strContent + "ddlComp1Name") != null) {
            if (document.getElementById(strContent + "ddlComp1Name").selectedIndex == 0) {
                alert("Please select COMPETITOR COMPANY Name 1");
                document.getElementById(strContent + "ddlComp1Name").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}


            //Validation COMPETITOR COMPANY Monthly Volume
            //if (document.getElementById(strContent + "ddlMnthVol1") != null) {
            if (document.getElementById(strContent + "ddlMnthVol1").selectedIndex == 0) {
                alert("Please select COMPETITOR COMPANY Monthly Volume 1");
                document.getElementById(strContent + "ddlMnthVol1").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            //Validation  Business Volume with RGI
            //if (document.getElementById(strContent + "ddlRGIMnthVol") != null) {
            if (document.getElementById(strContent + "ddlRGIMnthVol").selectedIndex == 0) {
                alert("Please select Business Volume With Group Company");
                document.getElementById(strContent + "ddlRGIMnthVol").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            // }

            //Validation Total Business for Motor
            //if (document.getElementById(strContent + "ddlTotBsnMtr") != null) {
            //debugger;
            //if (document.getElementById(strContent + "ddlTotBsnMtr").selectedIndex == 0) {
            //    alert("Please select Total Business for Motor");
            //    document.getElementById(strContent + "ddlTotBsnMtr").focus();
            //    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            //}

            

        }
        //Added by Prathamesh 16-7-15 end for Profiling  




        //function to show alert
        function funShowAlertForDate(strmsg) {
            alert(strmsg)
            return false;
        }

        //function PAN format
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
                                //var pan4char = pan2.substring(j,j+1);
                                if (pan2.substring(j, j + 1) != 'P')
                                    //if( pan4char != 'P' && pan4char != 'C')
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
            }
            else {
                return 0;
            }

            return 1;

        }

        // Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field
        //function ddlPaymentMode_onchange()
        //{
        //}

        function NEFTCodeChange() {
        }

        //PAN verification
        function ValidationPAN() {
            debugger;
            var varPAN = document.getElementById('<%= txtCurrentID.ClientID %>').value;

            if (varPAN.length == 0) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }
        if (varPAN.length < 10) {
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }

        if (varPAN.length != 10) {
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }


            //Validation for PAN No format.
        if (SpaceTrim(document.getElementById('<%= txtCurrentID.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtCurrentID.ClientID %>').value)) == 0) {
                    document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert('Invalid Pan Format');
                    document.getElementById('<%= txtCurrentID.ClientID %>').focus();
                return false;
            }
        }

        document.getElementById('divPAN').style.display = 'block'
    }



    function ValidationRefBy() {
        document.getElementById('iDivVerRefBy').style.display = 'block'
    }

    function isEmpty(str) {
        if ((str == null) || (str == "") || (str == " "))
            return true;
        return false;
    }

    function funHidePermAddOnPageLoad() {
        document.getElementById("<%=trPermAdd1.ClientID %>").style.display = "none";
            document.getElementById("<%=trPermAdd2.ClientID %>").style.display = "none";
            document.getElementById("<%=trPermAdd3.ClientID %>").style.display = "none";
        }

        function funTogglePermAdd() {
            if (document.getElementById("<%=ChkPA.ClientID %>").checked) {
                document.getElementById("<%=trPermAdd1.ClientID %>").style.display = "none";
                document.getElementById("<%=trPermAdd2.ClientID %>").style.display = "none";
                document.getElementById("<%=trPermAdd3.ClientID %>").style.display = "none";
                document.getElementById("<%=trPermAdd4.ClientID %>").style.display = "none";
            }
            else {
                document.getElementById("<%=trPermAdd1.ClientID %>").style.display = "block";
                document.getElementById("<%=trPermAdd2.ClientID %>").style.display = "block";
                document.getElementById("<%=trPermAdd3.ClientID %>").style.display = "block";
                document.getElementById("<%=trPermAdd4.ClientID %>").style.display = "none";
            }
            return false;
        }

        function doFormat(args) {
            var sString = document.getElementById(args).value;
            //Trim spaces
            sString = doTrim(sString);
            //Collapse spaces
            sString = doCollapse(sString);
            //Ensure comma immediately follows a non-space and is followed by a space
            sString = doFormatComma(sString);
            //Convert to proper case
            sString = toProperCase(sString);

            if (args == "ctl00_ContentPlaceHolder1_txtAddrP1" || args == "ctl00_ContentPlaceHolder1_txtAddrP2" || args == "ctl00_ContentPlaceHolder1_txtAddrP3") {
                document.getElementById(args).value = sString.toUpperCase();
            }
            else {
                document.getElementById(args).value = sString;
            }
            if (args == "ctl00_ContentPlaceHolder1_txtPermAdd1" || args == "ctl00_ContentPlaceHolder1_txtPermAdd2" || args == "ctl00_ContentPlaceHolder1_txtPermAdd3") {
                document.getElementById(args).value = sString.toUpperCase();
            }
            else {
                document.getElementById(args).value = sString;
            }
        }

        function doValidateName() {
            var sString = document.getElementById("<%=txtname.ClientID%>").value;

            //Check for invalid characters
            var iChars = "!@$^*_+={}[]|\:;?><";

            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    return 0;
                }
            }

            if (sString.length == 1) {
                return 0;
            }

            return 1;
        }
        //added by ank on 1 June2011 for Referred By advisor
        function doClearRefAdvInfo() {
            document.getElementById("<%=txtRefByadvName.ClientID%>").value = "";
        }



        function doValidateAddress(sValue) {
            var result = true;
            var sString = sValue;
            var intComCount = 1;
            //Check for invalid characters
            var iChars = "!@$^*_+={}[]|\:;?><,";

            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    if (sString.charAt(i) == ',') {
                        if (intComCount > 1) {
                            return 0
                        }
                        intComCount = intComCount + 1
                    }
                    else
                        return 0
                }

            }

            //Check if there's at least one block of 2 characters (valid)
            var sArray = sString.split(" ");
            var blnValid = false;
            for (var i = 0; i < sArray.length; i++) {
                if (sArray[i].length > 1) {
                    blnValid = true;
                }
            }
            if (!blnValid) {
                return 0;
            }

            //Check if there's a hyphen or apostrophe adjacent to space (invalid)
            if ((sString.match("' ") != null) ||
                (sString.match(" '") != null) ||
                (sString.match("- ") != null) ||
                (sString.match(" -") != null)) {
                return 0;
            }

            //Check if there's three same characters in a row (invalid)
            sArray = sString.toUpperCase().split("");
            for (var i = 2; i < sArray.length; i++) {
                if ((sArray[i] == sArray[i - 1]) &&
                    (sArray[i] == sArray[i - 2])) {

                    if (IsNumeric(sArray[i]) != true && isAlphabet(sArray[i]) != true)
                        return 0;
                }
            }

            return 1;
        }


        function doTrim(sString) {

            while (sString.substring(0, 1) == " ") {
                sString = sString.substring(1, sString.length);
            }

            while (sString.substring(sString.length - 1, sString.length) == " ") {
                sString = sString.substring(0, sString.length - 1);
            }
            return sString;

        }

        function doCollapse(sString) {
            while (sString.match("  ") != null) {
                sString = sString.replace("  ", " ");
            }
            return sString;
        }

        function doFormatComma(sString) {
            sString = sString.replace(",", ", ");
            sString = sString.replace(" ,", ",");
            sString = sString.replace(",  ", ", ");

            return sString;
        }

        function doValidateTitle() {

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
            return 1;
        }


        function showerrormsg(vmsg) {
            var vmsg = document.getElementById("<%=lblError2.ClientID%>").value.split(",")
            alert(vmsg);
        }

        function SetFocus(controlID) {
            document.getElementById("ctl00_ContentPlaceHolder1_cmdCancelM").enabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_cmdCancelM").visible = true;
            document.getElementById("ctl00_ContentPlaceHolder1_cmdCancel").enabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_cmdCancel").visible = true;
            displaySelectBoxes();


        }

        function displaySelectBoxes() {
            for (var i = 0; i < document.forms.length; i++) {
                for (var e = 0; e < document.forms[i].length; e++) {
                    if (document.forms[i].elements[e].tagName == "SELECT") {
                        document.forms[i].elements[e].style.visibility = "visible";
                    }
                }
            }
        }

        function CheckValidEmailAdd() {
            var result;
            var Email2 = document.getElementById("ctl00_ContentPlaceHolder1_txtemail").value.split(",");

            var Email = Email2[0];
            if (!((Email.indexOf(".") > 2) && (Email.indexOf("@") > 0))) {
                alert(document.getElementById("<%=hdnID530.ClientID%>").value);
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return 0;
            }
            return 1;
        }

        //added by pranjali on 06-03-2014 start
        function validateEmail1(sEmail1) {
            ////debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail1.match(reEmail)) {
                alert("Please Enter Valid Email-1 Address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtemail").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return 0;
            }

            return 1;

        }

        function validateEmail2(sEmail2) {
            ////debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail2.match(reEmail)) {
                alert("Please Enter Valid Email-2 Address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail2").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide(); 
                return 0;
            }

            return 1;

        }
        //added by pranjali on 06-03-2014 end

        function CheckWorkTelFormat(sValue) {
            var result = true;
            var LocalTel = sValue;

            strLocalTel = new String(LocalTel)

            if (strLocalTel.length > 0) {
                if (!IsNumeric(strLocalTel)) {
                    return 0;
                }
                strLocalTel = strLocalTel.substr(0, 1)
                if (strLocalTel != "0") {
                    return 0;
                }
            }

            return 1;
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

        //Added on : 12th June 09,Mahen
        //VAlidation on Father Name, only allowing Alphabets and Space
        function isAlphabetSpace(val) {
            if (val.match(/^[ a-zA-Z]+$/)) {
                return true;
            }
            else {
                return false;
            }
        }


        //Added by Praveena
        function funOpenPopWin(strPageName, strPayeeCode, strValue, strCode, strSource) {
            showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Source=" + strSource, 500, 350, null);
            return false;
        }

        //End of Addition


        function toProperCase(s) {
            return s.toLowerCase().replace(/^(.)|\s(.)/g, function ($1) { return $1.toUpperCase(); })
        }




        function popCountryP(oCode, oDesc, sCode, sDesc) {
            ////debugger;
            showPopWin("../../../Application/Common/PopCountry.aspx?Code=" + sCode +
                "&Desc=" + sDesc +
                "&Field1=" + oCode +
                "&Field2=" + oDesc
                , 500, 350, null);
        }

        function CheckPIN(args, argsID, argCntryID) {
            var CountryCode = document.getElementById(argCntryID).value;
            var Pin = args;
            if (CountryCode.toUpperCase() == "IND") {
                if (!IsNumeric(Pin) || (Pin.length != 6)) {
                    alert(document.getElementById("<%=hdnID490.ClientID%>").value);
                    document.getElementById(argsID).focus();
                    return 0;
                }
            }
            else {
                if (Pin.length > 8) {
                    alert(document.getElementById("<%=hdnID490.ClientID%>").value);
                    document.getElementById(argsID).focus();
                    return 0;
                }
            }
            return 1;
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

        function funShowAlert(objError, objFocus) {
            alert(document.getElementById(objError).value);
            document.getElementById(objFocus).focus();
            return false;
        }

        function funOpenPopWinForAccntPayee(strPageName, strPayeeCode, strValue, strCode, strCode1, strDispCSC, strSlsChnnl, strChnCls, strSource) {
            showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Field3=" + strCode1 + "&Field4=" + strDispCSC + "&Field5=" + strSlsChnnl + "&Field6=" + strChnCls + "&Source=" + strSource, 500, 350, null);
            return false;
        }

        //added by amruta for composite on 27/05/2015 start

        function funValidateComp() {

            var strContent = "ctl00_ContentPlaceHolder1_";


            if (document.getElementById(strContent + "ddlCatComp").selectedIndex == 0) {

                alert("Category for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlCatComp").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (document.getElementById(strContent + "ddlNameIns").selectedIndex == 0)//amruta 8.6
            {
                alert("Name of Insurer for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlNameIns").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtAgencyCode").value) == "") {
                alert("Agency Code Number for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtAgencyCode").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtDateOfAppointment").value) == "") {
                alert("Date of Appointment as Agent for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfAppointment").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (document.getElementById(strContent + "ddlSts").selectedIndex == 0) {

                alert("Status for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlSts").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (document.getElementById(strContent + "ddlSts").selectedIndex == 2) {

                if (SpaceTrim(document.getElementById(strContent + "txtDateOfCessation").value) == "") {
                    alert("Date of Cessation of Agency for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfCessation").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "txtReasonForCessation").value) == "") {
                    alert("Reason for Cessation of Agency for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtReasonForCessation").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        }
        //added by amruta for composite on 27/05/2015 end
        //added by amruta for transfer on 27/05/2015 start


        function funValidateTrn() {
            //debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";


            if (SpaceTrim(document.getElementById(strContent + "txtIC").value) == "") {


                alert("Date of I-C Date for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtIC").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //debugger;

            //Added By Pratik For date format validation -- start ) 05-03-2018

            var iCdate = document.getElementById(strContent + "txtIC").value;
            var matches = ValidateDateFormat(iCdate);
            if (!matches) {
                document.getElementById(strContent + "txtIC").focus();
                return false;
            }
            //Added By Pratik For date format validation -- end 05-03-2018


            if (SpaceTrim(document.getElementById(strContent + "txtIC").value) != "") {

                var dateFields = (document.getElementById('ctl00_ContentPlaceHolder1_txtIC')).value.split('/')

                var date = new Date(dateFields[2], dateFields[1] - 1, dateFields[0])
                //(SpaceTrim(document.getElementById(strContent + "txtIC").value));
                var curdate = new Date();
                //alert(curdate.format("dd/MM/yyyy"));

                if (date > curdate) {
                    alert('I-C Date can not be Greater than Today Date');   //date.valueOf() < curdate.valueOf()
                    document.getElementById("ctl00_ContentPlaceHolder1_txtIC").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }

            if (document.getElementById(strContent + "ddlCaTrnsfr").selectedIndex == 0) {


                alert("Category for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlCaTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (document.getElementById(strContent + "ddlNameInTrnsfr").selectedIndex == 0) {

                alert("Name of Insurer for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlNameInTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtAgencyCodeTrnsfr").value) == "") {
                alert("Agency Code Number for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtAgencyCodeTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtDateOfAppointmentTrnsfr").value) == "") {
                alert("Date of Appointment as Agent for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfAppointmentTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Added By Pratik For date format validation -- start ) 05-03-2018
            var Appointmentdate = document.getElementById(strContent + "txtDateOfAppointmentTrnsfr").value;
            var matches = ValidateDateFormat(Appointmentdate);
            if (!matches) {
                document.getElementById(strContent + "txtDateOfAppointmentTrnsfr").focus();
                return false;
            }
            //Added By Pratik For date format validation -- end 05-03-2018


            //Added by Prathamesh 20-7-15 start
            if (document.getElementById(strContent + "ddlStsTrnsfr").selectedIndex == 0) {

                alert("Status is Mandatory for Transfer");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlStsTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //Added by Prathamesh 20-7-15 end

            // if (document.getElementById(strContent + "ddlStsTrnsfr").selectedIndex == 0) {
            if (SpaceTrim(document.getElementById(strContent + "txtDateOfCessationTrnsfr").value) == "") {
                alert("Date of Cessation of Agency for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfCessationTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //Added By Pratik For date format validation -- start ) 05-03-2018
            var Cessationdate = document.getElementById(strContent + "txtDateOfCessationTrnsfr").value;
            var matches = ValidateDateFormat(Cessationdate);
            if (!matches) {
                document.getElementById(strContent + "txtDateOfCessationTrnsfr").focus();
                return false;
            }
            //Added By Pratik For date format validation -- end 05-03-2018

            if (SpaceTrim(document.getElementById(strContent + "txtReasonForCessationTrnsfr").value) == "") {
                alert("Reason for Cessation of Agency for Transfer is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtReasonForCessationTrnsfr").focus();
                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


        }
        //added by amruta for transfer on 11/05/2015 end

        //added BY Pratik for date format validation 05-03-2018 -- start
        function ValidateDateFormat(date) {
            var matches = /^(\d{2})[/](\d{2})[/](\d{4})$/.test(date);
            if (!matches) {
                alert("Enter Date in dd/mm/yyyy format.")
                //document.getElementById(strContent + "txtDateOfCessationTrnsfr").focus();
                return false;
            }
            if (parseInt(date.split('/')[2]) < 1900) {
                alert("Year cannot be less than 1900.");
                //document.getElementById(strContent + "txtDateOfCessationTrnsfr").focus();
                return false;
            }
            return true
        }

        //added BY Pratik for date format validation 05-03-2018 -- end



        // Added By pratik for Client Side Validation of Tagged Details 05-03-2018 start

        function validateTagDetails() {
            //debugger;
            var ddlTagcat = document.getElementById('<%= ddlTagCat.ClientID %>').value;
            if (ddlTagcat.toLowerCase() == 'select') {
                alert("Please select Category. ");
                document.getElementById('<%= ddlTagCat.ClientID %>').focus();
                return false;
            }

            var ddlTagIns = document.getElementById('<%= ddlTagIns.ClientID %>').value;
            if (ddlTagIns.toLowerCase() == 'select') {
                alert("Please select Name of Insurer. ");
                document.getElementById('<%= ddlTagIns.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%= txtTagAgn.ClientID %>').value.trim() == '') {
                alert("Please Enter Agency code number. ");
                document.getElementById('<%= txtTagAgn.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%= txtTagURN.ClientID %>').value.trim() == '') {
                alert("Please Enter URN number. ");
                document.getElementById('<%= txtTagURN.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%= txtTagApp.ClientID %>').value.trim() == '') {
                alert("Please Date of appointment as agent. ");
                document.getElementById('<%= txtTagApp.ClientID %>').focus();
                return false;
            }

            var Appointmentdate = document.getElementById('<%= txtTagApp.ClientID %>').value;
            var matches = ValidateDateFormat(Appointmentdate);
            if (!matches) {
                document.getElementById('<%= txtTagApp.ClientID %>').focus();
                return false;
            }
        };
        // Added By pratik for Client Side Validation of Tagged Details 05-03-2018 End
        function funValidate() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";
            var Mobile1 = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
            var Mobile2 = SpaceTrim(document.getElementById('<%= txtMobile2.ClientID %>').value);




            //Validation of Classification
            //alert("funValidate");
            if (document.getElementById(strContent + "ddlcategory").selectedIndex == 0) {
                //alert("Personal");
                alert('Please Select Candidate Classification');
                document.getElementById(strContent + "ddlcategory").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
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

            //Validation for Given Name
            if (document.getElementById(strContent + "cboTitle") != null) {
                if (document.getElementById(strContent + "cboTitle").selectedIndex == 0) {
                    alert("Please Select Title"); //alert(document.getElementById(strContent + "hdnID280").value);
                    document.getElementById(strContent + "cboTitle").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //added by pranjali on 06-03-2014 start
            if ((document.getElementById('<%=cboTitle.ClientID %>').value == "MRS") && (document.getElementById('<%=cboMaritalStatus.ClientID %>').value == "S")) {
                alert("Invalid Title");
                document.getElementById(strContent + "cboTitle").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            //added by pranjali on 06-03-2014 end

            //added by meena on 27/11/17 start
            if ((document.getElementById('ctl00_ContentPlaceHolder1_cboTitle').value == "MISS") && (document.getElementById('ctl00_ContentPlaceHolder1_cboMaritalStatus').value != "S")) {
                //debugger;
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
            //added by pranjali on 10-03-2014 start
            if (SpaceTrim(document.getElementById(strContent + "txtGivenName").value) == "") {
                alert("Please Enter Given Name");
                document.getElementById(strContent + "txtGivenName").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }


            var GivenName = document.getElementById('<%= txtGivenName.ClientID %>').value;
            if (GivenName.length < 3) {
                alert("GivenName should be atleast of three Characters");
                document.getElementById('<%= txtGivenName.ClientID %>').focus();
                //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            CheckSpaces();

            //added by pranjali on 10-03-2014 end
            //Validation for Sur Name
            //Commented By rachana on 20-10-2014 as every candidate does not have Surname start
            //	             if(SpaceTrim(document.getElementById(strContent + "txtname").value) =="")
            //                {
            //                     alert(document.getElementById(strContent + "hdnID470").value);
            //                     document.getElementById(strContent + "txtname").focus();
            //                     var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                     return false;
            //                 }
            //                 var SurName = document.getElementById('<%= txtname.ClientID %>').value;
            //                 if (SurName.length < 3) {
            //                     alert("SurName should be atleast of three Characters");
            //                     document.getElementById('<%= txtname.ClientID %>').focus();
            //                     var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                     return false;
            //                 }
            //Commented By rachana on 20-10-2014 as every candidate does not have Surname end
            //Added on : 6frb09,mahen
            //Validation for Father/ Spouse Name
            if (SpaceTrim(document.getElementById('<%= txtFathername.ClientID %>').value) == "") {
                alert("Please Enter Father/Spouse Name");
                document.getElementById('<%= txtFathername.ClientID %>').focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            //Added on : 12th June 09,Mahen

            //VAlidation on FatherName , only allowing Alphabets and Space
            if (isAlphabetSpace(document.getElementById('<%= txtFathername.ClientID %>').value) == false) {
                alert("Special character are not allowed for Father/Spouse Name");
                document.getElementById('<%= txtFathername.ClientID %>').focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            var lenFather = document.getElementById('<%= txtFathername.ClientID %>').value;
            if (lenFather.length < 3) {
                alert("Father/Spouse Name should be atleast of three Characters");
                document.getElementById('<%= txtFathername.ClientID %>').focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            AllowSpace();

            //Validation For ddlRelwithFather
            //Added by Rachana on 21-04-2015 for Retrival Process start
            //if (document.getElementById(strContent + "ddlRelwithFather") != null) {
            //    if (document.getElementById(strContent + "ddlRelwithFather").selectedIndex == 0) {
            //        alert('Please Select Relation With Agent'); //'Middle Name' replace with 'Agent' by Ajay on 19 Apr 2018 for testing bug
            //        document.getElementById(strContent + "ddlRelwithFather").focus();
            //        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;
            //    }
            //}
            //Added by Rachana on 21-04-2015 for Retrival Process end

            //Validation for Gender
            ////debugger;
            if (document.getElementById(strContent + "cboGender") != null) {
                if (document.getElementById(strContent + "cboGender").selectedIndex == 0) {
                    //alert(document.getElementById(strContent + "hdnID290").value);
                    alert('Please Select Gender');
                    //alert("1");
                    document.getElementById(strContent + "cboGender").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

                if ((document.getElementById(strContent + "cboGender").selectedIndex == 1 && document.getElementById(strContent + "cboTitle").selectedIndex == 1) ||
                    (document.getElementById(strContent + "cboGender").selectedIndex == 2 && document.getElementById(strContent + "cboTitle").selectedIndex == 2) ||
                    (document.getElementById(strContent + "cboGender").selectedIndex == 2 && document.getElementById(strContent + "cboTitle").selectedIndex == 3)) {

                    alert("Please Select Valid Gender");
                    document.getElementById(strContent + "cboGender").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for DOB 
            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) == "") {
                // alert(document.getElementById(strContent + "hdnID450").value);
                alert("Please Enter Date Of Birth");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            if (dtYear() == "0") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for DOB 
            if (SpaceTrim(document.getElementById(strContent + "txtDOB").value) != "") {
                if (DateValidation(document.getElementById("<%= txtDOB.ClientID %>").value, "ctl00_ContentPlaceHolder1_txtDOB") == 1)
                    return false;
            }

            //Validation for Marital Status
            if (document.getElementById(strContent + "cboMaritalStatus") != null) {

                if (document.getElementById(strContent + "cboMaritalStatus").selectedIndex == 0) {
                    alert("Please Select Marital Status");
                    document.getElementById(strContent + "cboMaritalStatus").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //Validation for Nationality
            //                 if(SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) =="")
            //                {
            //                    alert(document.getElementById(strContent + "hdnID310").value + " Code");
            //                    document.getElementById(strContent + "txtNationalCode").focus();
            //                   // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }

            //                 if(SpaceTrim(document.getElementById(strContent + "txtNationalCode").value) != null)
            //                {
            //	                 if(SpaceTrim(document.getElementById(strContent + "txtNationalDesc").value) =="")
            //                    {
            //                        alert(document.getElementById(strContent + "hdnID320").value);
            //                        document.getElementById(strContent + "txtNationalCode").focus();
            //                       // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			            return false;
            //                    }
            //			    }

            //Added by Prthamesh 15-7-15 start for Personal
            //ValidationPAN();

            //debugger;
            var varPAN = document.getElementById('<%= txtCurrentID.ClientID %>').value;

            if (varPAN.length == 0) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }
        if (varPAN.length < 10) {
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }

        if (varPAN.length != 10) {
            document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtCurrentID.ClientID %>').focus();
            return false;
        }

        if (SpaceTrim(document.getElementById(strContent + "txtCurrentID").value) != null) {

            if (CheckPANFormat(SpaceTrim(document.getElementById(strContent + "txtCurrentID").value)) == 0) {
                document.getElementById('<%=lblPANMsg.ClientID%>').innerHTML = '';
                    document.getElementById('<%=hdnPan.ClientID%>').value = '0';
                    alert(document.getElementById(strContent + "hdnID580").value);
                    // alert("Please Enter Pan No.");
                    document.getElementById(strContent + "txtCurrentID").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    document.getElementById(strContent + "lblPANMsg").value = "";
                    return false;
                }
            }

            //Validation for category
            //if (document.getElementById(strContent + "ddlCasteCat") != null) {

            //    if (document.getElementById(strContent + "ddlCasteCat").selectedIndex == 0) {
            //        alert('Please Select Category'); //Repalce 'Cast Category' with 'Category' by Ajay on 19 Apr 2018 for testing bug 
            //        document.getElementById(strContent + "ddlCasteCat").focus();
            //        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;
            //    }
            //}

            //Aadhaar validation
            if (SpaceTrim(document.getElementById(strContent + "txtaadhr").value) == "") {
                alert("Please Enter Aadhaar no ");
                document.getElementById(strContent + "txtaadhr").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }



            if (document.getElementById(strContent + "txtaadhr").value != "") {
                var AadharId = SpaceTrim(document.getElementById('<%= txtaadhr.ClientID %>').value);
                if (AadharId.length != 12) {
                    alert("Please Enter 12 Digit Aadhaar Number");
                    document.getElementById(strContent + "txtaadhr").focus();
                    //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }
            //Aadhaar validation
            ////debugger;
            //Validation for Primary Profession
            //if (document.getElementById(strContent + "ddlPrimProf") != null) {

            //    if (document.getElementById(strContent + "ddlPrimProf").selectedIndex == 0) {
            //        alert('Please Select Current Occupation');
            //        document.getElementById(strContent + "ddlPrimProf").focus();
            //        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;
            //    }
            //}

            if (document.getElementById(strContent + "ddlCatFlag")) { // added by pratik
                if (document.getElementById(strContent + "ddlCatFlag").Checked == true) {
                    if (document.getElementById(strContent + "ddlCatFlag").selectedIndex == 0) {
                        //alert(document.getElementById(strContent + "hdnID290").value);
                        alert('Please select the category for consider URN No.');
                        document.getElementById(strContent + "ddlCatFlag").focus();
                        return false;
                    }
                }
            }

            if (SpaceTrim(document.getElementById(strContent + "txtNomineeAge").value) != "") {

                var age = (document.getElementById("<%=txtNomineeAge.ClientID%>").value);
                if (age == "0" || age < "18") {

                    alert("Please Enter Valid Nominee Age");
                    document.getElementById(strContent + "txtNomineeAge").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //			    if (document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag").Checked == true) {
            //			        alert("parth");
            //			        alert('Please Enter Transfer Javascript Details');
            //			        // document.getElementById(strContent + "cbTrfrFlag").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }
            //Validation of Composite Case
            //			    if (document.getElementById(strContent + "cbTccCompLcn").Checked == true) {
            //			        alert("parth");
            //			        alert('Please Enter Composite Javascript Details');
            //			       // document.getElementById(strContent + "cbTccCompLcn").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }

            //Validation of Transfer Case



            //funValidateTrn();//Added by Prathamesh 20-7-15 for Transfer case
            //funValidateComp(); //Added by Prathamesh 20-7-15 composite case 


            //Validation for Present Address Type
            //if (document.getElementById(strContent + "ddlCnctType") != null) {

            if (document.getElementById(strContent + "ddlCnctType").selectedIndex == 0) {
                //alert(document.getElementById(strContent + "hdnID360").value);
                alert("Please Select Present Address Type");
                document.getElementById(strContent + "ddlCnctType").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            // }

            //Validation for Present Address -1
            //alert("1");
            if (SpaceTrim(document.getElementById(strContent + "txtAddrP1").value) == "") {
                //alert("2");
                //alert(document.getElementById(strContent + "hdnID370").value + " - 1.");
                alert("Please Enter Present Address Type-1");
                document.getElementById(strContent + "txtAddrP1").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for Present Address -2
            if (SpaceTrim(document.getElementById(strContent + "txtAddrP2").value) == "") {
                //alert(document.getElementById(strContent + "hdnID370").value + " - 2.");
                alert("Please Enter Present Address Type-2");
                document.getElementById(strContent + "txtAddrP2").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for Present Address -3
            if (SpaceTrim(document.getElementById(strContent + "txtAddrP3").value) == "") {
                //alert(document.getElementById(strContent + "hdnID370").value + " - 3.");
                alert("Please Enter Present Address Type-3");
                document.getElementById(strContent + "txtAddrP3").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for Present state
            // if (document.getElementById(strContent + "ddlState") != null) {

            if (document.getElementById(strContent + "ddlState").selectedIndex == 0) {
                alert("Please Select Present Address State");
                document.getElementById(strContent + "ddlState").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            // }

            //Validation for Present state
            if (SpaceTrim(document.getElementById(strContent + "txtDistric").value) == "") {
                alert("Please Select Present Address District");
                document.getElementById(strContent + "txtDistric").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //			    if (SpaceTrim(document.getElementById(strContent + "txtcity").value) == "") {
            //			        alert("Please Enter Present Address City");
            //			        document.getElementById(strContent + "txtcity").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }

            //			    if (SpaceTrim(document.getElementById(strContent + "txtarea").value) == "") {
            //			        alert("Please Enter Present Address Area");
            //			        document.getElementById(strContent + "txtarea").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }


            //			    if (SpaceTrim(document.getElementById(strContent + "txtCountryCodeP").value) == "") {
            //			        alert("Please Enter Present Address Country Code");
            //			        document.getElementById(strContent + "txtCountryCodeP").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }

            if (document.getElementById(strContent + "ddlcategory").selectedIndex == 2) {

                if (SpaceTrim(document.getElementById(strContent + "txtVillage").value) == "") {

                    alert("Please Enter Present Address Village");
                    document.getElementById(strContent + "txtVillage").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }



            //Validation for  Permanent Address -1
            if (SpaceTrim(document.getElementById(strContent + "txtPermAdd1").value) == "") {
                //alert(document.getElementById(strContent + "hdnID370").value + " - 1.");
                alert("Please Enter Permanent Address Type-1");
                document.getElementById(strContent + "txtPermAdd1").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for Permanent Address -2
            if (SpaceTrim(document.getElementById(strContent + "txtPermAdd2").value) == "") {
                //alert(document.getElementById(strContent + "hdnID370").value + " - 2.");
                alert("Please Enter Permanent Address Type-2");
                document.getElementById(strContent + "txtPermAdd2").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Validation for Permanent Address -3
            if (SpaceTrim(document.getElementById(strContent + "txtPermAdd3").value) == "") {
                //alert(document.getElementById(strContent + "hdnID370").value + " - 3.");
                alert("Please Enter Permanent Address Type-3");
                document.getElementById(strContent + "txtPermAdd3").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            //if (document.getElementById(strContent + "ddlstate1") != null) {

            if (document.getElementById(strContent + "ddlstate1").selectedIndex == 0) {
                alert("Please Select Permanent Address State");
                document.getElementById(strContent + "ddlstate1").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //}

            if (SpaceTrim(document.getElementById(strContent + "txtpermDistrict").value) == "") {
                alert("Please Enter Permanent Address District");
                document.getElementById(strContent + "txtpermDistrict").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //			    if (SpaceTrim(document.getElementById(strContent + "txtcity1").value) == "") {
            //			        alert("Please Enter Permanent Address City");
            //			        document.getElementById(strContent + "txtcity1").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }
            //			   
            //			    if (SpaceTrim(document.getElementById(strContent + "txtarea1").value) == "") {
            //			        alert("Please Enter Permanent Address Area");
            //			        document.getElementById(strContent + "txtarea1").focus();
            //			    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //			    }


            //comment by Prathamsh 21-7-15 start
            //if (SpaceTrim(document.getElementById(strContent + "txtPermCountryCode").value) == "") {
            //  alert("Please Enter Permanent Address Country Code");
            //  document.getElementById(strContent + "txtPermCountryCode").focus();
            //  var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //  return false;
            //}
            //comment by Prathamsh 21-7-15 end


            //Validation for Permanent Village
            if (document.getElementById(strContent + "ddlcategory").selectedIndex == 2) {

                if (SpaceTrim(document.getElementById(strContent + "txtpermvillage").value) == "") {
                    alert("Please Enter Permanent Address Village");
                    document.getElementById(strContent + "txtpermvillage").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }


            //Validation for Contact Preferred
            if (document.getElementById(strContent + "ddlDstbnMethod").selectedIndex == 0) {
                alert("Please Select Prefered Mode Of Contact.");
                document.getElementById(strContent + "ddlDstbnMethod").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //Validation for alternet whastapp no Mobile.1 
            <%-- if (SpaceTrim(document.getElementById(strContent + "TxtWhatsaap").value) == "") {
            alert("Mobile No.1 is Mandatory");
            document.getElementById(strContent + "TxtWhatsaap").focus();
            // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }
        else {--%>
            <%--if (document.getElementById(strContent + "TxtWhatsaap").value != "") {
            var MobileA = SpaceTrim(document.getElementById('<%= TxtWhatsaap.ClientID %>').value);
            if (MobileA.length != 10) {
                alert("Alternate Mobile (Whatsapp No.) should be 10 digit");
                document.getElementById(strContent + "TxtWhatsaap").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }--%>

            //                if ((Mobile.Text.substr(0, 1) != "9") && (Mobile.Text.substr(0, 1) != "8") && (Mobile.Text.substr(0, 1) != "7")) 
            //                {
            //                    alert("Mobile No should be  digit.");
            //                    document.getElementById(strContent + "txtMobileTel").focus();
            //                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //                    return false;
            //                    
            //                }
            // commented by mrunal on today
            //if (MobileA.substr(0, 1) == "1" || MobileA.substr(0, 1) == "2" || MobileA.substr(0, 1) == "3"
            //                || MobileA.substr(0, 1) == "4" || MobileA.substr(0, 1) == "5") {
            //    alert("Alternate Mobile (Whatsapp No.)  should start with (6,7,8,9)");
            //    document.getElementById(strContent + "TxtWhatsaap").focus();
            // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //return false;

            //}

            //    if (MobileA.substr(0, 1) == "0") {
            //        alert("Alternate Mobile (Whatsapp No.) should not start with 0");
            //        document.getElementById(strContent + "TxtWhatsaap").focus();
            //        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;

            //    }

            //}



            //Added by Prathamesh 14-7-15 start
            //commentyed by meena 17_5_18 start
            //Validate Home Tel 
        <%--if (SpaceTrim(document.getElementById(strContent + "txthometel").value) == "") {
            alert("Please Enter  Phone No");
            document.getElementById(strContent + "txthometel").focus();
            // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            return false;
        }
        else {

            var HomeTel = SpaceTrim(document.getElementById('<%= txthometel.ClientID %>').value);
            if (HomeTel.length != 10) {

                alert("Phone No should be 10 digit");
                document.getElementById(strContent + "txthometel").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 start
            if ((HomeTel.substr(0, 1)) == "0") {
                alert("Phone No should not start with 0");
                document.getElementById(strContent + "txthometel").focus();
                //  var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
        }--%>
            //commentyed by meena 17_5_18 start
            //Validation for Work-Tel
            if (SpaceTrim(document.getElementById(strContent + "txtWorkTel").value) != "") {

                var WorkTel = SpaceTrim(document.getElementById('<%= txtWorkTel.ClientID %>').value);
                if (WorkTel.length != 10) {

                    alert("Office Tel (with STD) should be 10 digit");
                    document.getElementById(strContent + "txtWorkTel").focus();
                    //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 start
                if ((WorkTel.substr(0, 1)) == "0") {

                    alert("Office Tel (with STD) should not start with 0");
                    document.getElementById(strContent + "txtWorkTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 end
            }

            //Validation for Mobile.1 
            if (SpaceTrim(document.getElementById(strContent + "txtMobileTel").value) == "") {
                alert("Mobile No.1 is Mandatory");
                document.getElementById(strContent + "txtMobileTel").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {
                var Mobile = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No.1 Should be 10 digit");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //                if ((Mobile.Text.substr(0, 1) != "9") && (Mobile.Text.substr(0, 1) != "8") && (Mobile.Text.substr(0, 1) != "7")) 
                //                {
                //                    alert("Mobile No should be  digit.");
                //                    document.getElementById(strContent + "txtMobileTel").focus();
                //                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                //                    return false;
                //                    
                //                }

                if (Mobile.substr(0, 1) == "0") {
                    alert("Mobile No.1 Should Not Start With 0");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }

                if (Mobile.substr(0, 1) == "1" || Mobile.substr(0, 1) == "2" || Mobile.substr(0, 1) == "3"
                    || Mobile.substr(0, 1) == "4" || Mobile.substr(0, 1) == "5") {
                    alert("Mobile No.1 Should Start With (6,7,8,9)");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }
                //Added by Prathamesh 14-7-15 start


            }





            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 start
            //Validation for Mobile.2 
            if (document.getElementById(strContent + "txtMobile2").value != "") {
                var Mobile2 = SpaceTrim(document.getElementById('<%= txtMobile2.ClientID %>').value);
                if (Mobile2.length != 10) {
                    alert("Alternate Mobile Number should be 10 digit");
                    document.getElementById(strContent + "txtMobile2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (Mobile2.substr(0, 1) == "0") {
                    alert("Alternate Mobile Number should not start with 0");
                    document.getElementById(strContent + "txtMobile2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }

                if (Mobile2.substr(0, 1) == "1" || Mobile2.substr(0, 1) == "2" || Mobile2.substr(0, 1) == "3"
                    || Mobile2.substr(0, 1) == "4" || Mobile2.substr(0, 1) == "5") {
                    alert("Alternate Mobile Number should start with (6,7,8,9)");
                    document.getElementById(strContent + "txtMobile2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }
            }


            //Validation for Email.1 and Email.2
            //debugger;
            if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
                alert("Email No.1 is Mandatory");
                document.getElementById(strContent + "txtemail").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            else {


                var emailid = (document.getElementById(strContent + "txtemail").value);
                if (validateEmail1(emailid) == 0) {
                    return false;
                }
            }


            //Validation for Email2
            if (SpaceTrim(document.getElementById(strContent + "txtEmail2").value) != "") {
                var emailid = (document.getElementById(strContent + "txtEmail2").value);
                if (validateEmail2(emailid) == 0) {
                    return false;
                }
            }

            //Validation Basic-Qualification
            //debugger;
            ///Education Details validation commented by daksh
            //if (document.getElementById(strContent + "ddlBasicQual") != null) {

            //    if (document.getElementById(strContent + "ddlBasicQual").selectedIndex == 0) {
            //        alert("Please select basic qualification");
            //        document.getElementById(strContent + "ddlBasicQual").focus();
            //        /// var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;
            //    }
            //}

            ////Validation for Board Name
            //if (SpaceTrim(document.getElementById(strContent + "txtBoardName").value) == "") {
            //    alert("Please Enter Board Name");
            //    document.getElementById(strContent + "txtBoardName").focus();
            //    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}

            ///Education Details validation commented by daksh
            //Validation for Roll No
            ///Education Details validation commented by daksh
            //if (SpaceTrim(document.getElementById(strContent + "txtBasicRNo").value) == "") {
            //    alert("Please enter basic qual. Roll No");
            //    document.getElementById(strContent + "txtBasicRNo").focus();
            //    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            ///Education Details validation commented by daksh
            //else {
            //                  if (!IsNumeric(document.getElementById("<%=txtBasicRNo.ClientID%>").value))
            //                    {                
            //                           alert("Basic Roll No should be numberic");
            //                           document.getElementById(strContent + "txtBasicRNo").focus();
            //                           var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                           return false;
            //                       }

            // }


            //Validation for Year of Passing
            //debugger;

            ///Education Details validation commented by daksh
            //if (SpaceTrim(document.getElementById(strContent + "txtYrPass").value) == "")//txtYrPass_txtDate
            //{
            //    alert("Please Enter Date Of Passing");
            //    document.getElementById("ctl00_ContentPlaceHolder1_txtYrPass").focus();
            //    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}

            //var passingYear = document.getElementById(strContent + "txtYrPass").value;
            //if (!ValidateDateFormat(passingYear)) {
            //    return false;
            //}
            ///Education Details validation commented by daksh


            //			        alert("1");
            //			        if (SpaceTrim(document.getElementById(strContent + "txtYrPass").value) != "")//txtYrPass_txtDate   
            //			        {
            //			            alert("2");
            //			            if ((Convert.ToDateTime(txtYrPass.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT)))) {
            //			                alert("Date of passing could not be greater than current date");
            //			                document.getElementById("ctl00_ContentPlaceHolder1_txtYrPass").focus();
            //			            //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			                return false;
            //			            }
            //			        }


            //Validation for Highest Basic Qualification
            ///Education Details validation commented by daksh
            //if (document.getElementById(strContent + "ddleducationproof") != null) {

            //    if (document.getElementById(strContent + "ddleducationproof").selectedIndex == 0) {

            //        alert("Please Select Highest Qualification");
            //        document.getElementById(strContent + "ddleducationproof").focus();
            //        // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //        return false;
            //    }
            //}
            ///Education Details validation commented by daksh
            //commented by meena 16_4_18 start

            //if (!(document.getElementById(strContent + "chkPhotoSign").checked)) {

            //    alert("Photos/Signature is Mandatory");
            //    document.getElementById(strContent + "chkPhotoSign").focus();
            //    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            //commented by meena 16_4_18 end
            //ADD NEW CODE 19/03/2018  usha
            //Account Holder Name
            if (SpaceTrim(document.getElementById(strContent + "txtbnkhldname").value) == "") {
                alert("Please enter account holder name");
                document.getElementById(strContent + "txtbnkhldname").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Account No
            if (SpaceTrim(document.getElementById(strContent + "txtbnkacno").value) == "") {
                alert("Please enter account no");
                document.getElementById(strContent + "txtbnkacno").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Bank Name
            if (SpaceTrim(document.getElementById(strContent + "txtbnkname").value) == "") {
                alert("Please enter bank name");
                document.getElementById(strContent + "txtbnkname").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Branch Name
            if (SpaceTrim(document.getElementById(strContent + "txtbrnchname").value) == "") {
                alert("Please enter branch name");
                document.getElementById(strContent + "txtbrnchname").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Account Type
            if (document.getElementById(strContent + "ddlactype").selectedIndex == 0) {
                alert("Please select account type");
                document.getElementById(strContent + "ddlactype").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //Bank IFSC Code
            //if (SpaceTrim(document.getElementById(strContent + "txtifsccode").value) == "") {
            //    alert("Please enter bank IFSC code");
            //    document.getElementById(strContent + "txtifsccode").focus();
            //    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}

            // added By pratik for ifsc Validation 20-03-2018
            if (!AllowIFSC(strContent + "txtifsccode")) {
                document.getElementById(strContent + "txtifsccode").focus()
                return false;
            }

            //Bank MICR Code
            if (SpaceTrim(document.getElementById(strContent + "txtmicrcode").value) == "") {
                alert("Please enter bank MICR code");
                document.getElementById(strContent + "txtmicrcode").focus();
                //var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            //END ADD NEW CODE 19/03/2018


            //			        if (document.getElementById(strContent + "cbTrfrFlag").checked == true) {
            //			            //alert("Transfer");

            //			            var gridViewRowCount = document.getElementById(strContent + "hdnTransfer");
            //			            //alert(gridViewRowCount.value);
            //			            if (gridViewRowCount.value == 0) {
            //			                //alert("rowscount");
            //			                alert("Please Enter Transfer Javascript Details");
            //			                document.getElementById(strContent + "cbTrfrFlag").focus();
            //			            //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			                return false;
            //			            }
            //			        }


            //			        if (document.getElementById(strContent + "cbTccCompLcn").checked == true) {
            //			            ////debugger;
            //			            //alert("Compo");

            //			            var gridViewRowCount = document.getElementById(strContent + "hdnCount");
            //			            //alert(gridViewRowCount.value);
            //			            if (gridViewRowCount.value == 0) {
            //			               // alert("rowscount");
            //			                alert("Please Enter Composite Details");
            //			                document.getElementById(strContent + "cbTccCompLcn").focus();
            //			            //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			                return false;
            //			            }

            //			        }


            //Validation for GivenName
            //			        var strText = document.getElementById(strContent + "txtGivenName").value;
            //			        strText = SpaceTrim(strText);
            //			        document.getElementById(strContent + "txtGivenName").value = strText;
            //			        var count = 0;

            //			        if (strText.length > 0) {
            //			            for (var i = 0; i < strText.length; i++) {
            //			                if (strText.charAt(i) == " ") {
            //			                    count++;
            //			                }
            //			            }
            //			            if (count > 2) {
            //			                alert("More than 2 spaces are not allowed in Name.");

            //			            }
            //			            
            //			        //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			            return false;
            //			        }

            //                    
            //                    //Validation for FatherName
            //			        var strText = document.getElementById(strContent + "txtFatherName").value;
            //			        strText = SpaceTrim(strText);
            //			        document.getElementById(strContent + "txtFatherName").value = strText;
            //			        var count = 0;

            //			        if (strText.length > 0) {
            //			            for (var i = 0; i < strText.length; i++) {
            //			                if (strText.charAt(i) == " ") {
            //			                    count++;
            //			                }
            //			            }
            //			            if (count > 1) {
            //			                alert("More than 1 spaces are not allowed in Name.");

            //			            }
            //			            
            //			        //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			            return false;
            //			        }







            //comment by Prathamesh 22-7-15 start     

            //Validate Transfer Case
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {
                if (SpaceTrim(document.getElementById(strContent + "txtOldTccLcnNo").value) != null) {
                    if (SpaceTrim(document.getElementById(strContent + "txtOldTccLcnNo").value) == "") {
                        alert("License Number for Transfer is Mandatory");
                        document.getElementById(strContent + "txtOldTccLcnNo").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }

                //                    if (SpaceTrim(document.getElementById(strContent + "txtDate").value) == "")//txtOldTccLcnExpDate_txtDate
                //                    {
                //                        alert("License Expiry Date for Transfer is Mandatory");
                //                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                //                        return false;
                //                    }
                //                    if (SpaceTrim(document.getElementById(strContent + "txtLicIssueDt").value) == "")//txtOldTccLcnExpDate_txtDate
                //                    {
                //                        alert("License Issue Date for Transfer is Mandatory");
                //                        document.getElementById("ctl00_ContentPlaceHolder1_txtLicIssueDt").focus();
                //                        return false;
                //                    }
                //			        
                //added by pranjali on 13-03-2014 start
                if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                    alert("Insurer Name for Transfer is Mandatory.");
                    document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
                //added by pranjali on 13-03-2014 end
        }

            //added by pranjali on 13-03-2014 for composite start
        if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                {
                    if (SpaceTrim(document.getElementById(strContent + "txtCompLicNo").value) == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }

                if (SpaceTrim(document.getElementById(strContent + "txtCompLicExpDt").value) == "")//txtOldTccLcnExpDate_txtDate
                {
                    alert("License Expiry Date for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtCompLicExpDt").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

                //			        
                //added by pranjali on 13-03-2014 start
           <%-- if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                alert("Insurer Name for Composite is Mandatory.");
                document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }--%>
                //added by pranjali on 13-03-2014 end
                //added by amruta 27/05/2015 start
                if (SpaceTrim(document.getElementById(strContent + "ddlCatComp").value) == "") {
                    alert("Category for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_ddlCatComp").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "ddlNameIns").value) == "")//amruta 8.6
                {
                    alert("Name of insurer for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_ddlNameIns").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "txtAgencyCode").value) == "") {
                    alert("Agency code number for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtAgencyCode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "txtDateOfAppointment").value) == "") {
                    alert("Date of appointment as agent for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfAppointment").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "txtDateOfCessation").value) == "") {
                    alert("Date of Cessation of Agency for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfCessation").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById(strContent + "txtReasonForCessation").value) == "") {
                    alert("Reason for Cessation of Agency for Composite is Mandatory");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtReasonForCessation").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            //added by amruta for transfer on 15/05/2015 start
            if (SpaceTrim(document.getElementById(strContent + "ddlCaTrnsfr").value) == "") {
                alert("Category for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlCaTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "ddlNameInTrnsfr").value) == "") {
                alert("Name of insurer for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_ddlNameInTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtAgencyCodeTrnsfr").value) == "") {
                alert("Agency code number for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtAgencyCodeTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtDateOfAppointmentTrnsfr").value) == "") {
                alert("Date of appointment as agent for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfAppointmentTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtDateOfCessationTrnsfr").value) == "") {
                alert("Date of cessation of agency for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtDateOfCessationTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById(strContent + "txtReasonForCessationTrnsfr").value) == "") {
                alert("Reason for cessation of agency for Composite is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtReasonForCessationTrnsfr").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            //                //added by amruta for transfer on 15/05/2015 end

            //added by pranjali on 13-03-2014 for composite end

            //validation for Category dropdown
            //                    alert("1");
            //                if (document.getElementById('<%=ddlCasteCat.ClientID %>').value == "Select") {
            //                    alert("2");
            //                    alert("Caste Category is Mandatory.");
            //                    document.getElementById('<%= ddlCasteCat.ClientID %>').focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                    return false;
            //                }



            //Validation for Primary Profession dropdown 
            //txtPrimProf is changed to ddlPrimProf by kalyani on 20-12-2013 start
            //                if (document.getElementById('<%=ddlPrimProf.ClientID %>').value == "Select") {
            //                    
            //                     alert("Primary Profession is Mandatory");
            //                     document.getElementById('<%= ddlPrimProf.ClientID %>').focus();
            //                     var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			         return false;
            //			     }
            //txtPrimProf is changed to ddlprimProf by kalyani on 20-12-2013 end

            //added by ank on 03.08.2011 for Nominee Age Validation
            if (SpaceTrim(document.getElementById(strContent + "txtNomineeAge").value) != null) {
                if (!IsNumeric(document.getElementById("<%=txtNomineeAge.ClientID%>").value)) {
                    alert("Nominee Age should be Numeric");
                    document.getElementById(strContent + "txtNomineeAge").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }
            //end by ank on 03.08.2011

            //Validation for agent type
            //                if(document.getElementById('<%=ddlAgnTypes.ClientID %>').value=="Select")
            //                {
            //                    alert("Agent Type is Mandatory.");
            //                    document.getElementById('<%= ddlAgnTypes.ClientID %>').focus();
            //                    return false;
            //                }

            //Validation for Sales Channel
            if (document.getElementById(strContent + "ddlSlsChannel") != null) {
                if (document.getElementById(strContent + "ddlSlsChannel").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID330").value);

                    document.getElementById(strContent + "txtEmpCode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide(); 
                    return false;
                }
            }

            //Validation for Channel Sub Class
            if (document.getElementById(strContent + "ddlChnCls") != null) {
                if (document.getElementById(strContent + "ddlChnCls").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID340").value);

                    document.getElementById(strContent + "txtEmpCode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //Validation for Channel Agent Type
            if (document.getElementById(strContent + "ddlAgntType") != null) {
                if (document.getElementById(strContent + "ddlAgntType").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID350").value);
                    document.getElementById(strContent + "ddlAgntType").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById(strContent + "txtImmLeader").value) == "") {
                alert(document.getElementById(strContent + "hdnID630").value);

                document.getElementById(strContent + "txtEmpCode").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtDirectAgtName").value) == "") {
                alert(document.getElementById(strContent + "hdnID640").value);

                document.getElementById(strContent + "txtEmpCode").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtEmpCode").value) == "") {
                alert(document.getElementById(strContent + "hdnID650").value);
                document.getElementById(strContent + "txtEmpCode").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            //Validation for Present Address Type		  
            //			    if (document.getElementById(strContent + "ddlCnctType") != null) {
            //			        if (document.getElementById(strContent + "ddlCnctType").selectedIndex == 0) {
            //			            alert(document.getElementById(strContent + "hdnID360").value);
            //			            document.getElementById(strContent + "ddlCnctType").focus();
            //			            var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			            return false;
            //			        }
            //			    }

            //                //Validation for Present Address -1
            //	             if(SpaceTrim(document.getElementById(strContent + "txtAddrP1").value) =="")
            //                {
            //                    alert(document.getElementById(strContent + "hdnID370").value + " - 1.");
            //                    document.getElementById(strContent + "txtAddrP1").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //                
            //                //Validation for Present Address -2
            //	             if(SpaceTrim(document.getElementById(strContent + "txtAddrP2").value) =="")
            //                {
            //                    alert(document.getElementById(strContent + "hdnID370").value + " - 2.");
            //                    document.getElementById(strContent + "txtAddrP2").focus();
            //                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //                }
            //                
            //                //Validation for Present Address -3
            //	             if(SpaceTrim(document.getElementById(strContent + "txtAddrP3").value) =="")
            //                {
            //                    alert(document.getElementById(strContent + "hdnID370").value + " - 3.");
            //                    document.getElementById(strContent + "txtAddrP3").focus();
            //                //     var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //			        return false;
            //                }



            //                if(SpaceTrim(document.getElementById(strContent + "txtDistric").value) =="")
            //                {
            //                    alert("Plese enter district");
            //                    document.getElementById(strContent + "txtDistric").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }

            //			    if (SpaceTrim(document.getElementById(strContent + "txtDistric").value) == "")
            //                {
            //                    alert("Plese select district");
            //                    document.getElementById(strContent + "txtDistric").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //			    //pranjali city start 
            //			    if (SpaceTrim(document.getElementById(strContent + "txtcity").value) == "") {
            //			        alert("Please enter City");
            //			        document.getElementById(strContent + "txtcity").focus();
            //			        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //			    }
            //			    //pranjali end

            //			    //pranjali area start 
            //			    if (SpaceTrim(document.getElementById(strContent + "txtarea").value) == "") {
            //			        alert("Please enter Area");
            //			        document.getElementById(strContent + "txtarea").focus();
            //			        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //			    }
            //pranjali end
            //Validation for Present Address State Code
            //                if(SpaceTrim(document.getElementById(strContent + "txtStateCodeP").value) =="")
            //                {
            //                    alert(document.getElementById(strContent + "hdnID380").value + " Code" );
            //			        document.getElementById(strContent + "txtStateCodeP").focus();
            //			        return false;
            //                }
            //                
            //                if(SpaceTrim(document.getElementById(strContent + "txtStateCodeP").value) !=null)
            //                {
            //	                 if(SpaceTrim(document.getElementById(strContent + "txtStateDescP").value) =="")
            //                    {
            //                        alert(document.getElementById(strContent + "hdnID590").value );
            //			            document.getElementById(strContent + "txtStateCodeP").focus();
            //			            return false;
            //                    }
            //                }  
            //pranjali start

            //if (document.getElementById(strContent + "ddlstate").value == "" || document.getElementById(strContent + "ddlstate").value == "Select")
            //			    if (document.getElementById('<%=ddlState.ClientID %>').value == "" || document.getElementById('<%=ddlState.ClientID %>').value == "Select")
            //			    {
            //			                        alert("Please select the state");
            //			                        document.getElementById(strContent + "ddlstate").focus();
            //			                        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			    			        return false;//			    }
            //pranjali end
            //		        if(SpaceTrim(document.getElementById(strContent + "txtStateCodeP").value) =="ME"
            //                   || SpaceTrim(document.getElementById(strContent + "txtStateCodeP").value) == "SI")
            //                {
            //                }
            //                else
            //                {
            //                    if(SpaceTrim(document.getElementById(strContent + "txtCurrentID").value) =="")
            //                    {
            //                        alert("Please Enter PAN");
            //		                document.getElementById(strContent + "txtCurrentID").focus();
            //		                return false;
            //                    }
            //                }

            //Validation for PAN No format.
            if (SpaceTrim(document.getElementById(strContent + "txtCurrentID").value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById(strContent + "txtCurrentID").value)) == 0) {
                    alert(document.getElementById(strContent + "hdnID580").value);
                    document.getElementById(strContent + "txtCurrentID").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }


            //Validation for Present Address PinCode
            if (SpaceTrim(document.getElementById(strContent + "txtPinP").value) == "") {
                alert(document.getElementById(strContent + "hdnID390").value);
                document.getElementById(strContent + "txtPinP").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            else {
                var Pin = document.getElementById(strContent + "txtPinP").value;
                var PinFrom = SpaceTrim(document.getElementById(strContent + "hdnPinFrom").value);
                var PinTo = SpaceTrim(document.getElementById(strContent + "hdnPinTo").value);

                if (PinFrom <= Pin && PinTo >= Pin) {
                }
                else {
                    if (PinFrom.length != 0) {
                        alert("Pincode range should be between " + PinFrom + " to " + PinTo);
                        document.getElementById(strContent + "txtPinP").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
            }

            //Validation for Present Address Country Code
            if (SpaceTrim(document.getElementById(strContent + "txtCountryCodeP").value) == "") {
                alert(document.getElementById(strContent + "hdnID400").value + " Code");
                document.getElementById(strContent + "txtCountryCodeP").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtCountryCodeP").value) != null) {
                if (SpaceTrim(document.getElementById(strContent + "txtCountryDescP").value) == "") {
                    alert(document.getElementById(strContent + "hdnID600").value);
                    document.getElementById(strContent + "txtCountryCodeP").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //Validate Home Tel
            if (SpaceTrim(document.getElementById(strContent + "txthometel").value) == "") {
                alert("Home Tel (with STD) is mandatory");
                document.getElementById(strContent + "txthometel").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            else {
                var HomeTel = SpaceTrim(document.getElementById('<%= txthometel.ClientID %>').value);
                if (HomeTel.length != 10) {
                    alert("Home Tel (with STD) should be 10 digit.");
                    document.getElementById(strContent + "txthometel").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 start
                if ((HomeTel.substr(0, 1)) == "0") {
                    alert("Home Tel (with STD) should not start with 0");
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
                //Added by pranjali on 05-03-2014 for validation of telphn should start with 0 end
            }



            if (SpaceTrim(document.getElementById(strContent + "txtMobileTel").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileTel").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            else {
                var Mobile = SpaceTrim(document.getElementById('<%= txtMobileTel.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;

                }
                //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 start
                //                    var mobile = document.getElementById(strContent + "txtMobileTel").value;
                //                    if ((mobile.substr(0, 1)) != "0") {
                //                        alert("Mobile Number should start with 0");
                //                        return false;
                //                    }
                //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 end
            }



            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 start

            //                if (document.getElementById(strContent + "txtMobile2").value != "") {
            //                    if (!((document.getElementById("<%=txtMobile2.ClientID%>").value).length == "10")) {
            //                        alert("Mobile No.2 should be 10 digit");
            //                        document.getElementById(strContent + "txtMobile2").focus();
            //                        var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                        return false;
            //                    }
            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 start
            //                    var mobile = document.getElementById(strContent + "txtMobile2").value;
            //                    if ((mobile.substr(0, 1)) != "0") {
            //                        alert("Mobile Number 2 should start with 0");
            //                        return false;
            //                    }
            //}
            //Added by pranjali on 05-03-2014 for validation of Mobile No should start with 0 end



            ///For Email   txtemail
            //added by pranjali on 06-03-2014 for email validation start
            if (SpaceTrim(document.getElementById(strContent + "txtemail").value) == "") {
                alert("Email is mandatory.");
                document.getElementById(strContent + "txtemail").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            else {
                ////debugger;
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

            if (document.getElementById('<%=ddlBasicQual.ClientID %>').value == "Select") {
                alert("Basic Qualification is Mandatory.");
                document.getElementById('<%= ddlBasicQual.ClientID %>').focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtBoardName").value) != null) {
                if (SpaceTrim(document.getElementById(strContent + "txtBoardName").value) == "") {
                    alert("Board Name is Mandatory");
                    document.getElementById(strContent + "txtBoardName").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

            }

            if (SpaceTrim(document.getElementById(strContent + "txtBasicRNo").value) == "") {
                alert("Roll No. is Mandatory");
                document.getElementById(strContent + "txtBasicRNo").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }
            else {
                //                  if (!IsNumeric(document.getElementById("<%=txtBasicRNo.ClientID%>").value))
                //                    {                
                //                           alert("Basic Roll No should be numberic");
                //                           document.getElementById(strContent + "txtBasicRNo").focus();
                //                           var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                //                           return false;
                //                       }

            }



            if (SpaceTrim(document.getElementById(strContent + "txtYrPass").value) == "")//txtYrPass_txtDate
            {
                alert("Year of Passing is Mandatory");
                document.getElementById("ctl00_ContentPlaceHolder1_txtYrPass").focus();
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            //Validate Email ID


            if (document.getElementById(strContent + "ddleducationproof") != null) {
                if (document.getElementById(strContent + "ddleducationproof").selectedIndex == 0) {
                    alert("Select the Highest Qualification");
                    document.getElementById(strContent + "ddleducationproof").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (!(document.getElementById("<%=chkPhotoSign.ClientID %>").checked)) {
                alert("4 Photos/Signature  is Mandatory");
                // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                return false;
            }

            //Added by rachana on 23-11-2013 for validation of marksheet,certificate start
            //Commented by kalyani on 2-1-2014  as not a required field start
            //if (!(document.getElementById("<%=cbmarksheet.ClientID %>").checked)) {
            //    alert("Marksheet  is Mandatory");
            //    return false;
            //}

            //if (!(document.getElementById("<%=cbcertificate.ClientID %>").checked)) {
            //    alert("Certificate is Mandatory");
            //    return false;
            //}
            //Commented by kalyani on 2-1-2014  as not a required field end
            //Added by rachana on 23-11-2013 for validation of marksheet,certificate end

            //Validate for Permanent Address
            if (document.getElementById("ctl00_ContentPlaceHolder1_ChkPA").checked == false) {
                //Validation for Permanent Address -1
                if (SpaceTrim(document.getElementById(strContent + "txtPermAdd1").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + " - 1.");
                    document.getElementById(strContent + "txtPermAdd1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

                //Validation for Permanent Address -2
                if (SpaceTrim(document.getElementById(strContent + "txtPermAdd2").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + " - 2.");
                    document.getElementById(strContent + "txtPermAdd2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //Validation for Permanent Address -3
                if (SpaceTrim(document.getElementById(strContent + "txtPermAdd3").value) == "") {
                    alert(document.getElementById(strContent + "hdnID370").value + " - 3.");
                    document.getElementById(strContent + "txtPermAdd3").focus();
                    return false;
                }

                //Validation for Permanent Address State Code
                //	             if(SpaceTrim(document.getElementById(strContent + "txtPermStateCode").value) =="")
                //                {
                //                    alert(document.getElementById(strContent + "hdnID380").value +" Code");
                //			        document.getElementById(strContent + "txtPermStateCode").focus();
                //			        return false;
                //                }
                //                
                //                if(SpaceTrim(document.getElementById(strContent + "txtPermStateCode").value) != null)
                //                 {
                //                    if(SpaceTrim(document.getElementById(strContent + "txtPermStateDesc").value) =="")
                //                    {
                //                        alert(document.getElementById(strContent + "hdnID590").value );
                //			            document.getElementById(strContent + "txtPermStateCode").focus();
                //			            return false;
                //                    }
                //			    }

                //pranjali start
                if (document.getElementById(strContent + "ddlstate1").value == "" || document.getElementById(strContent + "ddlstate").value == "Select") {
                    alert("Please select the state");
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    document.getElementById(strContent + "ddlstate1").focus();
                    return false;
                }
                //pranjali end
                //Validation for Permanent Address district Code
                if (SpaceTrim(document.getElementById(strContent + "txtpermDistrict").value) == "") {
                    alert(document.getElementById(strContent + "hdnID380").value + " Code");
                    document.getElementById(strContent + "txtpermDistrict").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
                //pranjali city start 
                if (SpaceTrim(document.getElementById(strContent + "txtcity1").value) == "") {
                    alert("Please enter City");
                    document.getElementById(strContent + "txtcity1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
                //pranjali end

                //pranjali area start 
                if (SpaceTrim(document.getElementById(strContent + "txtarea1").value) == "") {
                    alert("Please enter Area");
                    document.getElementById(strContent + "txtarea1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
                //pranjali end
                //Validation for Permanent Address PinCode
                if (SpaceTrim(document.getElementById(strContent + "txtPermPostcode").value) == "") {
                    alert(document.getElementById(strContent + "hdnID390").value);
                    document.getElementById(strContent + "txtPermPostcode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

                //Validation for Permanent Address Country Code
                if (SpaceTrim(document.getElementById(strContent + "txtPermCountryCode").value) == "") {
                    alert(document.getElementById(strContent + "hdnID400").value + " Code");
                    document.getElementById(strContent + "txtPermCountryCode").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById(strContent + "txtPermCountryCode").value) != null) {
                    if (SpaceTrim(document.getElementById(strContent + "txtPermCountryDesc").value) == "") {
                        alert(document.getElementById(strContent + "hdnID600").value);
                        document.getElementById(strContent + "txtPermCountryCode").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
            }

            //validation for cheque amount 
            if (SpaceTrim(document.getElementById(strContent + "txtchqamt").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtchqamt.ClientID%>").value)) {
                    alert("Cheque amount should be numberic and round off");
                    document.getElementById(strContent + "txtchqamt").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtPinP.ClientID%>").value) != null) {
                if (CheckPIN(document.getElementById("<%=txtPinP.ClientID%>").value, "ctl00_ContentPlaceHolder1_txtPinP", "ctl00_ContentPlaceHolder1_txtCountryCodeP") == 0) {
                    return false;
                }
            }

            //Validate Surname
            if (SpaceTrim(document.getElementById(strContent + "txtname").value) != "") {
                if (doValidateName() == 0) {
                    alert(document.getElementById("<%=hdnID550.ClientID%>").value);
                    document.getElementById(strContent + "txtname").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            //Validate Title
            if (document.getElementById(strContent + "cboGender") != null) {
                if (document.getElementById(strContent + "cboGender").selectedIndex != 0) {
                    if (doValidateTitle() == 1) {
                        alert(document.getElementById("<%=hdnID540.ClientID%>").value);
                        document.getElementById(strContent + "cboGender").focus();
                        // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                        return false;
                    }
                }
            }





            //Validate Present AddressP1
            //                 if(SpaceTrim(document.getElementById("<%=txtAddrP1.ClientID%>").value) != "")
            //                {
            //                    if(doValidateAddress(document.getElementById(strContent + "txtAddrP1").value)== 0)
            //                    {
            //                         alert(document.getElementById("<%=hdnID560.ClientID%>").value);
            //                         document.getElementById(strContent + "txtAddrP1").focus();
            //                         var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                         return false;
            //                    }
            //                }

            //Validate Present AddressP2
            if (SpaceTrim(document.getElementById("<%=txtAddrP2.ClientID%>").value) != "") {
                if (doValidateAddress(document.getElementById(strContent + "txtAddrP2").value) == 0) {
                    alert(document.getElementById("<%=hdnID560.ClientID%>").value);
                    document.getElementById(strContent + "txtAddrP2").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validate Present AddressP3
            if (SpaceTrim(document.getElementById("<%=txtAddrP3.ClientID%>").value) != "") {
                if (doValidateAddress(document.getElementById(strContent + "txtAddrP3").value) == 0) {
                    alert(document.getElementById("<%=hdnID560.ClientID%>").value);
                    document.getElementById(strContent + "txtAddrP3").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //added by : M.Valvi , on 12th Feb 09.
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlcategory").selectedIndex == 2) {
                if (SpaceTrim(document.getElementById(strContent + "txtVillage").value) == "") {
                    alert("Village is Mandatory ,if Candidate Category is Rural");
                    document.getElementById(strContent + "txtVillage").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (!(document.getElementById("<%=ChkPA.ClientID %>").checked)) {

                //Validate Premenant AddressP1
                if (SpaceTrim(document.getElementById("<%=txtPermAdd1.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById(strContent + "txtPermAdd1").value) == 0) {
                        alert(document.getElementById("<%=hdnID560.ClientID%>").value);
                    document.getElementById(strContent + "txtPermAdd1").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

                //Validate Premenant AddressP2
            if (SpaceTrim(document.getElementById("<%=txtPermAdd2.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById(strContent + "txtPermAdd2").value) == 0) {
                        alert(document.getElementById("<%=hdnID560.ClientID%>").value);
                    document.getElementById(strContent + "txtPermAdd2").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

                //Validate Premenant AddressP3
            if (SpaceTrim(document.getElementById("<%=txtPermAdd3.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById(strContent + "txtPermAdd3").value) == 0) {
                        alert(document.getElementById("<%=hdnID560.ClientID%>").value);
                    document.getElementById(strContent + "txtPermAdd3").focus();
                    //  var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtPermPostcode.ClientID%>").value) != null) {
                    if (CheckPIN(document.getElementById("<%=txtPermPostcode.ClientID%>").value, "ctl00_ContentPlaceHolder1_txtPermPostcode", "ctl00_ContentPlaceHolder1_txtPermCountryCode") == 0) {
                    return false;
                }
            }
        }





            //Validate Work Tel no
        if (SpaceTrim(document.getElementById(strContent + "txtWorkTel").value) != "") {
            if (CheckWorkTelFormat(document.getElementById(strContent + "txtWorkTel").value) == 0) {
                alert(document.getElementById("<%=hdnID570.ClientID%>").value);
                    document.getElementById(strContent + "txtWorkTel").focus();
                    // var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
                    return false;
                }
            }


            //               if(dtYear()=="0")
            //               {
            //                document.getElementById("ctl00_ContentPlaceHolder1_txtDOB").focus();
            //                return false; 
            //               }
            //               else
            //                { 
            //                    if(document.getElementById('<%=btnUpdate.ClientID%>').value == "Save")
            //                    {
            //                        if(confirm('Application number and recruiter code cannot be edited.Do you want to continue?'))
            //                        {
            //                            HideBtn();
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            return false;
            //                        }
            //                    }
            //                }

            //                //comment by Prthamesh 22-7-15 end 
            //funProfiling();
        } //End Function CndPersonal





        function HideBtn() {
            if (document.getElementById('<%=hdnBtnDis.ClientID%>').value == "1") {
                document.getElementById('<%=btnUpdate.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=hdnBtnDis.ClientID%>').value = "1";
            }
        }

        //Open Newly addedon 21-01-08
        //Validation for Language Known
        function funValidateForm2() {

            //             if(document.getElementById("<%=ddllanknow1.ClientID%>") != null)
            //	             {
            //	                    if(document.getElementById("<%=ddllanknow1.ClientID%>").selectedIndex != "")
            //	       	            {
            //				            if(document.getElementById("<%=cbpread.ClientID%>").checked == false && document.getElementById("<%=cbpspeak.ClientID%>").checked == false && document.getElementById("<%=cbpwrite.ClientID%>").checked == false)
            //    			            {
            //			                    alert(document.getElementById("<%=hdnID300.ClientID%>").value);
            //			                    document.getElementById("<%=ddllanknow1.ClientID%>").focus();
            //			                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //      	                        return false;
            //   				            }                	     
            //                	    }
            //                }

            //                if(document.getElementById("<%=ddllanknow2.ClientID%>") != null)
            //	             {
            //	                    if(document.getElementById("<%=ddllanknow2.ClientID%>").selectedIndex != "")
            //	       	            {
            //				            if(document.getElementById("<%=cbpread2.ClientID%>").checked == false && document.getElementById("<%=cbpspeak2.ClientID%>").checked == false && document.getElementById("<%=cbpwrite2.ClientID%>").checked == false)
            //    			            {
            //			                    alert(document.getElementById("<%=hdnID300.ClientID%>").value);
            //			                    document.getElementById("<%=ddllanknow2.ClientID%>").focus();
            //			                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //      	                        return false;
            //   				            }                	     
            //                	    }
            //                }
            //                
            //              
            //                if(document.getElementById("<%=ddllanknow3.ClientID%>") != null)
            //	             {
            //	                    if(document.getElementById("<%=ddllanknow3.ClientID%>").selectedIndex != "")
            //	       	            {
            //				            if(document.getElementById("<%=cbpread3.ClientID%>").checked == false && document.getElementById("<%=cbpspeak3.ClientID%>").checked == false && document.getElementById("<%=cbpwrite3.ClientID%>").checked == false)
            //    			            {
            //			                    alert(document.getElementById("<%=hdnID300.ClientID%>").value);
            //			                    document.getElementById("<%=ddllanknow3.ClientID%>").focus();
            //			                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //      	                        return false;
            //   				            }                	     
            //                	    }
            //      	                            }

            //                
            //                if(document.getElementById("<%=ddllanknow4.ClientID%>") != null)
            //	             {
            //	                    if(document.getElementById("<%=ddllanknow4.ClientID%>").selectedIndex != "")
            //	       	            {
            //				            if(document.getElementById("<%=cbpread4.ClientID%>").checked == false && document.getElementById("<%=cbpspeak4.ClientID%>").checked == false && document.getElementById("<%=cbpwrite4.ClientID%>").checked == false)
            //    			            {
            //			                    alert(document.getElementById("<%=hdnID300.ClientID%>").value);
            //			                    document.getElementById("<%=ddllanknow4.ClientID%>").focus();
            //			                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //      	                        return false;
            //   				            }                	     
            //                	    }
            //      	            }


            //Validation for Qualification Page
            if (document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode").selectedIndex == 0) {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value);
                    document.getElementById("ctl00_ContentPlaceHolder1_cboQualCode").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            //Validation for Permanent Address State Code
            if (SpaceTrim(document.getElementById("<%=txtOccupationCode.ClientID%>").value) == "") {
                alert(document.getElementById("<%=hdnID280.ClientID%>").value);
                document.getElementById("<%=txtOccupationCode.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtOccupationCode.ClientID%>").value) != null) {
                if (SpaceTrim(document.getElementById("<%=txtOccupationDesc.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID290.ClientID%>").value);
                    document.getElementById("<%=txtOccupationCode.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //End Newly added on 21-01-08





        } //End funValidateForm2()


        //Validation for Employee History Page
        function funValidateForm3() {
            //Validation for Employment History -1 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName1.ClientID%>").value) != "") {
                //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom1.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 1");
                    document.getElementById('<%=txtfrom1.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //                  else {
                //                      var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").value);
                //                      var curdate= new Date();

                //                      if (date > curdate.format("ddmmyyyy")) {
                //                          alert('Cannot enter future date');
                //                          document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").focus();
                //                          return false;
                //                      }
                //                  }                      
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtto1.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 1");
                    document.getElementById('<%=txtto1.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //			    else
                //                 {
                //                     var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").focus();
                //			            return false;
                //			        }
                //			    }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").value) == "") {
                    alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }


                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").value) == "") {
                    alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").value) == "") {
                    alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").value) == "") {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //document.getElementById('<%=txtto1.ClientID %>').value

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").value != null )
                if (document.getElementById('<%=txtfrom1.ClientID %>').value != null && document.getElementById('<%=txtfrom1.ClientID %>').value != null) {
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom1.ClientID %>').value, "document.getElementById('<%=txtfrom1.ClientID %>')", document.getElementById('<%=txtfrom1.ClientID %>').value, "document.getElementById('<%=txtfrom1.ClientID %>')") == 1)
                        return false;
                }

                if (SpaceTrim(document.getElementById("<%=txtLastIncome1.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome1.ClientID%>").value)) {
                        alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 1");
                        document.getElementById("<%=txtLastIncome1.ClientID%>").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }


            } // End if EH-1


            //Validation for Employment History -2 
            if (SpaceTrim(document.getElementById("<%=txtPrevEmpName2.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom2.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 2");
                    document.getElementById('<%=txtfrom2.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").focus();
                //			            return false;
                //			        }
                //			    }
                if (SpaceTrim(document.getElementById('<%=txtfrom2.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 2");
                document.getElementById('<%=txtfrom2.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto2_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto2_txtDate").focus();
                //			            return false;
                //			        }
                //			    }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").value) == "") {
                alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 2");
                document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").value) == "") {
                alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 2");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").value) == "") {
                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 2");
                document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").value) == "") {
                alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 2");
                document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto2_txtDate").value != null )
            if (document.getElementById('<%=txtfrom2.ClientID %>').value != null && document.getElementById('<%=txtto2.ClientID %>').value != null) {
                    if (FrmToDateValidation(document.getElementById('<%=txtfrom2.ClientID %>').value, "document.getElementById('<%=txtfrom2.ClientID %>').value", document.getElementById('<%=txtto2.ClientID %>').value, "document.getElementById('<%=txtto2.ClientID %>')") == 1)
                    return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtLastIncome2.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome2.ClientID%>").value)) {
                    alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 2");
                    document.getElementById("<%=txtLastIncome2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        } // End if EH-2


            //Validation for Employment History - 3 
        if (SpaceTrim(document.getElementById("<%=txtPrevEmpName3.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom3.ClientID%>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 3");
                    document.getElementById('<%=txtfrom3.ClientID%>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").focus();
                //			            return false;
                //			        }
                //			    }


                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtto3.ClientID%>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 3");
                document.getElementById('<%=txtto3.ClientID%>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").focus();
                //			            return false;
                //			        }
                //			    }
            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").value) == "") {
                alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 3");
                document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").value) == "") {
                alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 3");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").value) == "") {
                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 3");
                document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").value) == "") {
                alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 3");
                document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").value != null )
            if (document.getElementById('<%=txtfrom3.ClientID%>').value != null && document.getElementById('<%=txtto3.ClientID%>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom3.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom3_txtDate",document.getElementById("<%= txtto3.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto3_txtDate") == 1)
                if (FrmToDateValidation(document.getElementById('<%=txtfrom3.ClientID%>').value, "document.getElementById('<%=txtfrom3.ClientID%>')", document.getElementById('<%=txtto3.ClientID%>').value, "document.getElementById('<%=txtto3.ClientID%>')") == 1)
                    return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtLastIncome3.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome3.ClientID%>").value)) {
                    alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 3");
                    document.getElementById("<%=txtLastIncome3.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        } // End if EH-3

            //Validation for Employment History - 4 
        if (SpaceTrim(document.getElementById("<%=txtPrevEmpName4.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom4.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 4");
                    document.getElementById('<%=txtfrom4.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").focus();
                //			            return false;
                //			        }
                //			    }


                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtto4.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 4");
                document.getElementById('<%=txtto4.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").focus();
                //			            return false;
                //			        }
                //			    }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").value) == "") {
                alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 4");
                document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").value) == "") {
                alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 4");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").value) == "") {
                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 4");
                document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").value) == "") {
                alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 4");
                document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").value != null )
            if (document.getElementById('<%=txtfrom4.ClientID %>').value != null && document.getElementById('<%=txtto4.ClientID %>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom4.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom4_txtDate",document.getElementById("<%= txtto4.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto4_txtDate") == 1)
                if (FrmToDateValidation(document.getElementById('<%=txtfrom4.ClientID %>').value, "document.getElementById('<%=txtfrom4.ClientID %>')", document.getElementById('<%=txtto4.ClientID %>').value, "document.getElementById('<%=txtto4.ClientID %>')") == 1)
                    return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtLastIncome4.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome4.ClientID%>").value)) {
                    alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 4");
                    document.getElementById("<%=txtLastIncome4.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        } // End if EH-4

            //Validation for Employment History - 5 
        if (SpaceTrim(document.getElementById("<%=txtPrevEmpName5.ClientID%>").value) != "") {
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtfrom5.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 5");
                    document.getElementById('<%=txtfrom5.ClientID %>').value.focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").focus();
                //			            return false;
                //			        }
                //			    }


                //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtto5.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 5");
                document.getElementById('<%=txtto5.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
                //rk
                //			    else {
                //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").value);
                //			        var curdate = new Date();

                //			        if (date > curdate.format("ddmmyyyy")) {
                //			            alert('Cannot enter future date');
                //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").focus();
                //			            return false;
                //			        }
                //			    }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").value) == "") {
                alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 5");
                document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").value) == "") {
                alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 5");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").value) == "") {
                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 5");
                document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").value) == "") {
                alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 5");
                document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

                // if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").value != null )
            if (document.getElementById('<%=txtfrom5.ClientID %>').value != null && document.getElementById('<%=txtto5.ClientID %>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom5.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom5_txtDate",document.getElementById("<%= txtto5.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto5_txtDate") == 1)
                if (FrmToDateValidation(document.getElementById('<%=txtfrom5.ClientID %>').value, "document.getElementById('<%=txtfrom5.ClientID %>')", document.getElementById('<%=txtto5.ClientID %>').value, "document.getElementById('<%=txtto5.ClientID %>')") == 1)
                    return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtLastIncome5.ClientID%>").value) != "") {
                    if (!IsNumeric(document.getElementById("<%=txtLastIncome5.ClientID%>").value)) {
                    alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 5");
                    document.getElementById("<%=txtLastIncome5.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        } // End if EH-5

            //Commented by rachana on 22-08-2014 as not required start
            //Validation for Employment History - 6 
            //	         if(SpaceTrim(document.getElementById("<%=txtPrevEmpName6.ClientID%>").value) != "")
            //              {
            //                  //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom6_txtDate").value) == "")
            //                  if (SpaceTrim(document.getElementById('<%=txtfrom6.ClientID %>').value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 6");
            //                    document.getElementById('<%=txtfrom6.ClientID %>').focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //rk
            //			    else {
            //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom6_txtDate").value);
            //			        var curdate = new Date();

            //			        if (date > curdate.format("ddmmyyyy")) {
            //			            alert('Cannot enter future date');
            //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").focus();
            //			            return false;
            //			        }
            //			    }

            //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto6_txtDate").value) == "")
            //			    if (SpaceTrim(document.getElementById('<%=txtto6.ClientID %>').value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 6");
            //                    document.getElementById('<%=txtto6.ClientID %>').focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //			    }
            //rk
            //			    else {
            //			        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtto6_txtDate").value);
            //			        var curdate = new Date();

            //			        if (date > curdate.format("ddmmyyyy")) {
            //			            alert('Cannot enter future date');
            //			            document.getElementById("ctl00_ContentPlaceHolder1_txtto6_txtDate").focus();
            //			            return false;
            //			        }
            //			    }


            //                if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp6").value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID280.ClientID%>").value + " - 6");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp6").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //                
            //                
            //                 if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl6").value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID290.ClientID%>").value + " - 6");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl6").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }

            //                if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome6").value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 6");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome6").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //                
            //                if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave6").value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID310.ClientID%>").value + " - 6");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave6").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }

            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom6_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtto6_txtDate").value != null )
            //			    if (document.getElementById('<%=txtfrom6.ClientID %>').value != null && document.getElementById('<%=txtto6.ClientID %>').value != null)
            //                {
            //                    //if (FrmToDateValidation(document.getElementById("<%= txtfrom6.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtfrom6_txtDate",document.getElementById("<%= txtto6.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtto6_txtDate") == 1)
            //                    if (FrmToDateValidation(document.getElementById('<%=txtfrom6.ClientID %>').value, "document.getElementById('<%=txtfrom6.ClientID %>')", document.getElementById('<%=txtto6.ClientID %>').value, "document.getElementById('<%=txtto6.ClientID %>')") == 1)
            //                    return false;
            //                }
            //                
            //                 if(SpaceTrim(document.getElementById("<%=txtLastIncome6.ClientID%>").value) != "")
            //                {
            //                    if (!IsNumeric(document.getElementById("<%=txtLastIncome6.ClientID%>").value)) 
            //                    {                
            //                           alert(document.getElementById("<%=hdnID480.ClientID%>").value + " - 6");
            //                           document.getElementById("<%=txtLastIncome6.ClientID%>").focus();
            //                           var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //                           return false;
            //                    }
            //                }

            //}// End if EH-6
            //Commented by rachana on 22-08-2014 as not required end
            //Validation End for Employment History Name 1 - 5

            //Validation for Employment History Name 1
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom1_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto1_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").value != "")
            if (document.getElementById("<%=txtfrom1.ClientID%>").value != "" || document.getElementById("<%=txtto1.ClientID%>").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome1").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave1").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName1").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 1");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName1").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 2 if(document.getElementById('<%=txtfrom2.ClientID %>').value != null && document.getElementById('<%=txtto2.ClientID %>').value != null )
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom2_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto2_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").value != "")
            if (document.getElementById('<%=txtfrom2.ClientID %>').value != "" || document.getElementById('<%=txtto2.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome2").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave2").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName2").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 2");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName2").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 3
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom3_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto3_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").value != "")
            if (document.getElementById('<%=txtfrom3.ClientID %>').value != "" || document.getElementById('<%=txtto3.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome3").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave3").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName3").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 3");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName3").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 4
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom4_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto4_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").value != "")
            if (document.getElementById('<%=txtfrom4.ClientID %>').value != "" || document.getElementById('<%=txtto4.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome4").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave4").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName4").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 4");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName4").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Employment History Name 5
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom5_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto5_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").value != "")
            if (document.getElementById('<%=txtfrom5.ClientID %>').value != "" || document.getElementById('<%=txtto5.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome5").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave5").value != "") {
                if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName5").value) == "") {
                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 5");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName5").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Commented by rachana on 22-08-2014 as not required start
            //Validation for Employment History Name 6
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtfrom6_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtto6_txtDate").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp6").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl6").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome6").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave6").value != "")
            //              if(document.getElementById('<%=txtfrom6.ClientID %>').value != "" || document.getElementById('<%=txtto6.ClientID %>').value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtaddofemp6").value != "" ||document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLvl6").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtLastIncome6").value != "" || document.getElementById("ctl00_ContentPlaceHolder1_txtreasforleave6").value != "")
            //	          {
            //                 if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName6").value) == "")
            //                {
            //                    alert(document.getElementById("<%=hdnID410.ClientID%>").value + " - 6");
            //                    document.getElementById("ctl00_ContentPlaceHolder1_txtPrevEmpName6").focus();
            //                    var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //			        return false;
            //                }
            //              }
            //Commented by rachana on 22-08-2014 as not required end

            if ((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_1").checked) == false)) {
                alert(document.getElementById("<%=hdnID380.ClientID%>").value);
                document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtemprecordname1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID420.ClientID%>").value);
                    document.getElementById("<%=txtemprecordname1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //Validation for Other Exp - 1
            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbotherexp_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtemprecordname1.ClientID%>").value) != "") {

                    //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate").value) == "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom1.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 1");
                    document.getElementById('<%=txtotherexpfrom1.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                    //rk
                    //	                    else {
                    //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate").value);
                    //	                        var curdate = new Date();

                    //	                        if (date > curdate.format("ddmmyyyy")) {
                    //	                            alert('Cannot enter future date');
                    //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate").focus();
                    //	                            return false;
                    //	                        }
                    //	                    }
                if (SpaceTrim(document.getElementById('<%=txtotherexpTo1.ClientID %>').value) == "") {
                        alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 1");
                    document.getElementById('<%=txtotherexpTo1.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                    //rk
                    //	                    else {
                    //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate").value);
                    //	                        var curdate = new Date();

                    //	                        if (date > curdate.format("ddmmyyyy")) {
                    //	                            alert('Cannot enter future date');
                    //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate").focus();
                    //	                            return false;
                    //	                        }
                    //	                    }
                    //rk
                    //validation for job nature and record field

                if (SpaceTrim(document.getElementById("<%= txtemprecordjobnature1.ClientID %>").value) == "") {
                        alert('Please enter job nature.');
                        document.getElementById("<%= txtemprecordjobnature1.ClientID %>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById("<%=txtemprecordfield1.ClientID%>").value) == "") {
                        alert('Please enter field details.');
                        document.getElementById("<%=txtemprecordfield1.ClientID %>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                    //if (document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate").value != null) 
                if (document.getElementById('<%=txtotherexpfrom1.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo1.ClientID %>').value != null) {
                        //  if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom1.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom1_txtDate", document.getElementById("<%= txtotherexpTo1.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo1_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom1.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom1.ClientID %>')", document.getElementById('<%=txtotherexpTo1.ClientID %>').value, "document.getElementById('<%=txtotherexpTo1.ClientID %>')") == 1)
                        return false;
                }


            } // End if Other Exp-1

                //Validation for Other Exp - 2
            if (SpaceTrim(document.getElementById("<%=txtemprecordname2.ClientID%>").value) != "") {

                    //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").value) == "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom2.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 2");
                    document.getElementById('<%=txtotherexpfrom2.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //	                    else {
                //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").value);
                //	                        var curdate = new Date();

                //	                        if (date > curdate.format("ddmmyyyy")) {
                //	                            alert('Cannot enter future date');
                //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").focus();
                //	                            return false;
                //	                        }
                //	                    }
                //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate").value) == "") {
                if (SpaceTrim(document.getElementById('<%=txtotherexpTo2.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 2");
                    document.getElementById('<%=txtotherexpTo2.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //	                    else {
                //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate").value);
                //	                        var curdate = new Date();

                //	                        if (date > curdate.format("ddmmyyyy")) {
                //	                            alert('Cannot enter future date');
                //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate").focus();
                //	                            return false;
                //	                        }
                //	                    }
                //rk
                //validation for job nature and record field
                if (SpaceTrim(document.getElementById("<%=txtemprecordjobnature2.ClientID%>").value) == "") {
                    alert('Please enter job nature.');
                    document.getElementById("<%=txtemprecordjobnature2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById("<%=txtemprecordfield2.ClientID%>").value) == "") {
                    alert('Please enter field details.');
                    document.getElementById("<%=txtemprecordfield2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //if (document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate").value != null) 
                if (document.getElementById('<%=txtotherexpfrom2.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo2.ClientID %>').value != null) {
                    //if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom2.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom2_txtDate", document.getElementById("<%= txtotherexpTo2.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo2_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom2.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom2.ClientID %>')", document.getElementById('<%=txtotherexpTo2.ClientID %>').value, "document.getElementById('<%=txtotherexpTo2.ClientID %>')") == 1)
                        return false;
                }
            } // End if Other Exp-2


                //Validation for Other Exp - 3
            if (SpaceTrim(document.getElementById("<%=txtemprecordname3.ClientID%>").value) != "") {

                    //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate").value) == "") {
                    if (SpaceTrim(document.getElementById('<%=txtotherexpfrom3.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " - 3");
                    document.getElementById('<%=txtotherexpfrom3.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //	                    else {
                //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate").value);
                //	                        var curdate = new Date();

                //	                        if (date > curdate.format("ddmmyyyy")) {
                //	                            alert('Cannot enter future date');
                //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate").focus();
                //	                            return false;
                //	                        }
                //	                    }
                //if (SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate").value) == "") {
                if (SpaceTrim(document.getElementById('<%=txtotherexpTo3.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID270.ClientID%>").value + " - 3");
                    document.getElementById('<%=txtotherexpTo3.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //rk
                //	                    else {
                //	                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate").value);
                //	                        var curdate = new Date();

                //	                        if (date > curdate.format("ddmmyyyy")) {
                //	                            alert('Cannot enter future date');
                //	                            document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate").focus();
                //	                            return false;
                //	                        }
                //	                    }
                //rk
                //validation for job nature and record field
                //SpaceTrim(document.getElementById("<%=txtemprecordjobnature2.ClientID%>").value

                if (SpaceTrim(document.getElementById("<%=txtemprecordjobnature3.ClientID%>").value) == "") {
                    alert('Please enter job nature.');
                    document.getElementById("<%=txtemprecordjobnature3.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById("<%=txtemprecordfield3.ClientID%>").value) == "") {
                    alert('Please enter job field details.');
                    document.getElementById("<%=txtemprecordfield3.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

                //if (document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate").value != null && document.getElementById("ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate").value != null) 
                if (document.getElementById('<%=txtotherexpfrom3.ClientID %>').value != null && document.getElementById('<%=txtotherexpTo3.ClientID %>').value != null) {
                    //    if (FrmToDateValidation(document.getElementById("<%= txtotherexpfrom3.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpfrom3_txtDate", document.getElementById("<%= txtotherexpTo3.ClientID %>" + "_txtDate").value, "ctl00_ContentPlaceHolder1_txtotherexpTo3_txtDate") == 1)
                    if (FrmToDateValidation(document.getElementById('<%=txtotherexpfrom3.ClientID %>').value, "document.getElementById('<%=txtotherexpfrom3.ClientID %>')", document.getElementById('<%=txtotherexpTo3.ClientID %>').value, "document.getElementById('<%=txtotherexpTo3.ClientID %>')") == 1)
                        return false;
                }

            } // End if Other Exp-3
        }

            //Validation for Details of Insurance Agency
        if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbinsagency_0").checked) == true) {
            if (SpaceTrim(document.getElementById("<%=txtInsCompName.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID420.ClientID%>").value);
                    document.getElementById("<%=txtInsCompName.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").value) == "")
                if (SpaceTrim(document.getElementById('<%=txtdateofissue.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID320.ClientID%>").value);
                document.getElementById('<%=txtdateofissue.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
                //rk
                //                    else {
                //                        var date = SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").value);
                //			            var curdate = new Date();

                //			            if (date > curdate.format("ddmmyyyy")) {
                //			                alert('Cannot enter future date');
                //			                document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").focus();
                //			                return false;
                //			            }
                //			        }

                //if(SpaceTrim(document.getElementById("ctl00_ContentPlaceHolder1_txtvaliddate_txtDate").value) == "")
            if (SpaceTrim(document.getElementById('<%=txtvaliddate.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID330.ClientID%>").value);
                document.getElementById('<%=txtvaliddate.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById('<%=txtterminatedate.ClientID %>').value) == "") {
                    alert(document.getElementById("<%=hdnID340.ClientID%>").value);
                document.getElementById('<%=txtterminatedate.ClientID %>').focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
        } // End if Insurance Agency

        if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbinsagency_0").checked) == true) {
            //if(document.getElementById("ctl00_ContentPlaceHolder1_txtdateofissue_txtDate").value != null)
            if (document.getElementById('<%=txtdateofissue.ClientID %>').value != null) {

                    //if (DateValidation(document.getElementById("<%= txtdateofissue.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtdateofissue_txtDate") == 1)
                    if (DateValidation(document.getElementById('<%=txtdateofissue.ClientID %>').value, "document.getElementById('<%=txtdateofissue.ClientID %>')") == 1)
                        return false;
                }
                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtvaliddate_txtDate").value != null)
                if (document.getElementById('<%=txtvaliddate.ClientID %>').value != null) {
                    //if (DateValidation(document.getElementById("<%= txtvaliddate.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtvaliddate_txtDate") == 1)
                if (DateValidation(document.getElementById('<%=txtvaliddate.ClientID %>').value, "document.getElementById('<%=txtvaliddate.ClientID %>')") == 1)
                    return false;
            }
                //if(document.getElementById("ctl00_ContentPlaceHolder1_txtterminatedate_txtDate").value != null)
            if (document.getElementById('<%=txtterminatedate.ClientID %>').value != null) {
                    //if (DateValidation(document.getElementById("<%=txtterminatedate.ClientID %>" + "_txtDate").value,"ctl00_ContentPlaceHolder1_txtterminatedate_txtDate") == 1)
                if (DateValidation(document.getElementById('<%=txtterminatedate.ClientID %>').value, "document.getElementById('<%=txtterminatedate.ClientID %>')") == 1)
                    return false;
            }
        }



    } // Function End funValidateForm3


    //Validation for Disciplinary Info
    function funValidateForm4() {
        //commented by rachana on 22-08-2014 start	            
        //	            if((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn01_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn01_1").checked) == false))
        //	            {
        //	                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 1");
            //	                document.getElementById("ctl00_ContentPlaceHolder1_rbQstn01_0").focus();
            //	                var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //	                return false;
            //	            }
            //	            if((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn02_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn02_1").checked) == false))
            //	            {
            //	                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 2");
            //	                document.getElementById("ctl00_ContentPlaceHolder1_rbQstn02_0").focus();
            //	                var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //	                return false;
            //	            }
            //               
            //               if((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn03_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn03_1").checked) == false))
            //	            {
            //	                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 3");
            //	                document.getElementById("ctl00_ContentPlaceHolder1_rbQstn03_0").focus();
            //	                var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //	                return false;
            //	            }
            //	            
            //	            if((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn04_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbQstn04_1").checked) == false))
            //	            {
            //	                alert(document.getElementById("<%=hdnID300.ClientID%>").value + " - 4");
            //	                document.getElementById("ctl00_ContentPlaceHolder1_rbQstn04_0").focus();
            //	                var myExtender = $find('ProgressBarModalPopupExtender');myExtender.hide();
            //	                return false;
            //	            }
            //commented by rachana on 22-08-2014 end

            //Validation For Reference 1 
            if (SpaceTrim(document.getElementById("<%=txtRef1Name.ClientID%>").value) != "") {
                if (SpaceTrim(document.getElementById("<%=txtRef1Add1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 Address - 1");
                    document.getElementById("<%=txtRef1Add1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById("<%=txtRef1Add2.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 Address - 2");
                document.getElementById("<%=txtRef1Add2.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById("<%=txtRef1Add3.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 Address - 3");
                document.getElementById("<%=txtRef1Add3.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtRef1Add3.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 Address - 3");
                document.getElementById("<%=txtRef1Add3.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtStateCodeR1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 - State Code");
                document.getElementById("<%=txtStateCodeR1.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtStateCodeR1.ClientID%>").value) != null) {
                    if (SpaceTrim(document.getElementById("<%=txtStateDescR1.ClientID%>").value) == "") {
                    alert("Reference 1 - " + document.getElementById("<%=hdnID320.ClientID%>").value);
                    document.getElementById("<%=txtStateCodeR1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtRef1Pin.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 - Pin Code");
                document.getElementById("<%=txtRef1Pin.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtCountryCodeR1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 1 - Country Code");
                document.getElementById("<%=txtCountryCodeR1.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtCountryCodeR1.ClientID%>").value) != null) {
                    if (SpaceTrim(document.getElementById("<%=txtCountryDescR1.ClientID%>").value) == "") {
                    alert("Reference 1 - " + document.getElementById("<%=hdnID330.ClientID%>").value);
                    document.getElementById("<%=txtCountryCodeR1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }


                //Validate Reference 1 - Address1
            if (SpaceTrim(document.getElementById("<%=txtRef1Add1.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef1Add1.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef1Add1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

                //Validate Reference 1 - Address2
            if (SpaceTrim(document.getElementById("<%=txtRef1Add2.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef1Add2.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef1Add2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

                //Validate Reference 1 - Address3
            if (SpaceTrim(document.getElementById("<%=txtRef1Add3.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef1Add3.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef1Add3.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtRef1Pin.ClientID%>").value) != null) {
                    if (CheckPIN(document.getElementById("<%=txtRef1Pin.ClientID%>").value, "ctl00_ContentPlaceHolder1_txtRef1Pin", "ctl00_ContentPlaceHolder1_txtCountryCodeR1") == 0) {
                    return false;
                }
            }

        } //end if txtRef1Name 

            //Validation For Reference 2 
        if (SpaceTrim(document.getElementById("<%=txtRef2Name.ClientID%>").value) != "") {
                if (SpaceTrim(document.getElementById("<%=txtRef2Add1.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 Address - 1");
                    document.getElementById("<%=txtRef2Add1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
                if (SpaceTrim(document.getElementById("<%=txtRef2Add2.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 Address - 2");
                document.getElementById("<%=txtRef2Add2.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if (SpaceTrim(document.getElementById("<%=txtRef2Add3.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 Address - 3");
                document.getElementById("<%=txtRef2Add3.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtRef2Add3.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 Address - 3");
                document.getElementById("<%=txtRef2Add3.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtStateCodeR2.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 - State Code");
                document.getElementById("<%=txtStateCodeR2.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtStateCodeR2.ClientID%>").value) != null) {
                    if (SpaceTrim(document.getElementById("<%=txtStateDescR2.ClientID%>").value) == "") {
                    alert("Reference 2 - " + document.getElementById("<%=hdnID320.ClientID%>").value);
                    document.getElementById("<%=txtStateCodeR2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }


            if (SpaceTrim(document.getElementById("<%=txtRef2Pin.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 - Pin Code");
                document.getElementById("<%=txtRef2Pin.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("<%=txtCountryCodeR2.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID260.ClientID%>").value + " 2 - Country Code");
                document.getElementById("<%=txtCountryCodeR2.ClientID%>").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }

            if (SpaceTrim(document.getElementById("<%=txtCountryCodeR2.ClientID%>").value) != null) {
                    if (SpaceTrim(document.getElementById("<%=txtCountryDescR2.ClientID%>").value) == "") {
                    alert("Reference 2 - " + document.getElementById("<%=hdnID330.ClientID%>").value);
                    document.getElementById("<%=txtCountryCodeR2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }


                //Validate Reference 2 - Address1
            if (SpaceTrim(document.getElementById("<%=txtRef2Add1.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef2Add1.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef2Add1.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

                //Validate Reference 2 - Address2
            if (SpaceTrim(document.getElementById("<%=txtRef2Add2.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef2Add2.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef2Add2.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

                //Validate Reference 2 - Address3
            if (SpaceTrim(document.getElementById("<%=txtRef2Add3.ClientID%>").value) != "") {
                    if (doValidateAddress(document.getElementById("<%=txtRef2Add3.ClientID%>").value) == 0) {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtRef2Add3.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtRef2Pin.ClientID%>").value) != null) {
                    if (CheckPIN(document.getElementById("<%=txtRef2Pin.ClientID%>").value, "ctl00_ContentPlaceHolder1_txtRef2Pin", "ctl00_ContentPlaceHolder1_txtCountryCodeR2") == 0) {
                    return false;
                }
            }

        } //end if txtRef2Name 

    } //End function funValidateForm4



    function funValidateForm5() {

        if ((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbtimework_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbtimework_1").checked) == false)) {
            alert(document.getElementById("<%=hdnID260.ClientID%>").value);
                document.getElementById("ctl00_ContentPlaceHolder1_rbtimework_0").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }
            if ((eval(document.getElementById("ctl00_ContentPlaceHolder1_rbrelatedemp_0").checked) == false) && (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbrelatedemp_1").checked) == false)) {
                alert(document.getElementById("<%=hdnID270.ClientID%>").value);
                document.getElementById("ctl00_ContentPlaceHolder1_rbrelatedemp_0").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return false;
            }


            if (SpaceTrim(document.getElementById("<%=txtbusinessplannooflives11.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannooflives11.ClientID%>").value)) {
                    alert("Year 1 - " + document.getElementById("<%=hdnID280.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannooflives11.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplansumassured11.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplansumassured11.ClientID%>").value)) {
                    alert("Year 1 - " + document.getElementById("<%=hdnID290.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplansumassured11.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplannfirstyearpremium11.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannfirstyearpremium11.ClientID%>").value)) {
                    alert("Year 1 - " + document.getElementById("<%=hdnID300.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannfirstyearpremium11.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }


            if (SpaceTrim(document.getElementById("<%=txtbusinessplannooflives21.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannooflives21.ClientID%>").value)) {
                    alert("Year 2 - " + document.getElementById("<%=hdnID280.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannooflives21.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplannsumassured21.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannsumassured21.ClientID%>").value)) {
                    alert("Year 2 - " + document.getElementById("<%=hdnID290.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannsumassured21.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplannfirstyearpremium21.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannfirstyearpremium21.ClientID%>").value)) {
                    alert("Year 2 - " + document.getElementById("<%=hdnID300.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannfirstyearpremium21.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (SpaceTrim(document.getElementById("<%=txtbusinessplannooflives31.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannooflives31.ClientID%>").value)) {
                    alert("Year 3 - " + document.getElementById("<%=hdnID280.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannooflives31.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplannsumassured31.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannsumassured31.ClientID%>").value)) {
                    alert("Year 3 - " + document.getElementById("<%=hdnID290.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannsumassured31.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (SpaceTrim(document.getElementById("<%=txtbusinessplannfirstyearpremium31.ClientID%>").value) != "") {
                if (!IsNumeric(document.getElementById("<%=txtbusinessplannfirstyearpremium31.ClientID%>").value)) {
                    alert("Year 3 - " + document.getElementById("<%=hdnID300.ClientID%>").value);
                    document.getElementById("<%=txtbusinessplannfirstyearpremium31.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (eval(document.getElementById("ctl00_ContentPlaceHolder1_rbrelatedemp_0").checked) == true) {
                if (SpaceTrim(document.getElementById("<%=txtrelativeworkdesc.ClientID%>").value) == "") {
                    alert(document.getElementById("<%=hdnID310.ClientID%>").value);
                    document.getElementById("<%=txtrelativeworkdesc.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

        } //End function funValidateForm5


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
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
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
                alert("Minimum Entry Age should be 18 years");
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
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }

            if (EndMonth != '' && EndYear != '') {
                if (!validDate(EndDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert(document.getElementById("<%=hdnID440.ClientID%>").value);
                    document.getElementById(argsID2).focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return 1;
                }
            }

            return 0;
        }


        function funchkpaclick(objChkPA) {
            ////debugger;
            if (document.getElementById("<%=ChkPA.ClientID %>").checked == true) {
                document.getElementById("<% =txtPermAdd1.ClientID %>").value = document.getElementById("<% =txtAddrP1.ClientID %>").value;
                document.getElementById("<% =txtPermAdd2.ClientID %>").value = document.getElementById("<% =txtAddrP2.ClientID %>").value;
                document.getElementById("<% =txtPermAdd3.ClientID %>").value = document.getElementById("<% =txtAddrP3.ClientID %>").value;
                document.getElementById("<% =txtpermvillage.ClientID %>").value = document.getElementById("<% =txtVillage.ClientID %>").value;
                document.getElementById("<% =txtPermCountryCode.ClientID %>").value = document.getElementById("<% =txtCountryCodeP.ClientID %>").value; //Added by pranjali on 14-01-2014 for permanant adderss nationality field
                document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = document.getElementById("<% =txtCountryDescP.ClientID %>").value; //Added by pranjali on 14-01-2014 for permanant adderss nationality field
                document.getElementById("<% =ddlstate1.ClientID %>").value = document.getElementById("<% =ddlState.ClientID %>").value;
                document.getElementById("<% =txtpermDistrict.ClientID %>").value = document.getElementById("<% =txtDistric.ClientID %>").value; //Added by kalyani on 31-12-2013 for permanant adderss district field
                document.getElementById("<% =txtcity1.ClientID %>").value = document.getElementById("<% =txtcity.ClientID %>").value;
                document.getElementById("<% =txtarea1.ClientID %>").value = document.getElementById("<% =txtarea.ClientID %>").value;
                document.getElementById("<% =txtPermPostcode.ClientID %>").value = document.getElementById("<% =txtPinP.ClientID %>").value;
                //document.getElementById("<% =txtPermStateDesc.ClientID %>").value = document.getElementById("<% =txtStateDescP.ClientID %>").value;

                //document.getElementById("<% =txtPermCountryCode.ClientID %>").value = document.getElementById("<% =txtCountryCodeP.ClientID %>").value;



                document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = true;
                document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = true;
                document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = true;
                document.getElementById('<% =txtpermvillage.ClientID %>').disabled = true;
                document.getElementById('<% =ddlstate1.ClientID %>').disabled = true;
                document.getElementById('<% =txtpermDistrict.ClientID %>').disabled = true;
                //         document.getElementById('<% =txtPermStateDesc.ClientID %>').disabled = true;
                document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = true;
                document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = true;
                document.getElementById('<% =txtcity1.ClientID %>').disabled = true;
                document.getElementById('<% =txtarea1.ClientID %>').disabled = true;
                document.getElementById('<% =btnstate1search.ClientID %>').disabled = true;
                //         document.getElementById('<% =btnPermState.ClientID %>').disabled = true;
                //         document.getElementById('<% =btnpermDistrict.ClientID %>').disabled = true; //Added by kalyani on 31-12-2013 for permanant adderss district field
            }
            else {
                document.getElementById("<% =txtPermAdd1.ClientID %>").value = "";
                document.getElementById("<% =txtPermAdd2.ClientID %>").value = "";
                document.getElementById("<% =txtPermAdd3.ClientID %>").value = "";
                document.getElementById("<% =txtpermvillage.ClientID %>").value = "";
                //document.getElementById("<% =txtPermCountryCode.ClientID %>").value = "";
                //document.getElementById("<% =txtPermCountryDesc.ClientID %>").value = "";
                document.getElementById("<% =ddlstate1.ClientID %>").value = "";
                document.getElementById("<% =txtarea1.ClientID %>").value = "";
                //document.getElementById("<% =txtPermStateCode.ClientID %>").value = "";
                document.getElementById("<% =txtcity1.ClientID %>").value = "";
                document.getElementById("<% =txtpermDistrict.ClientID %>").value = "";
                //             document.getElementById("<% =txtPermStateDesc.ClientID %>").value = "";
                document.getElementById("<% =txtPermPostcode.ClientID %>").value = "";


                document.getElementById('<% =txtPermAdd1.ClientID %>').disabled = false;
                document.getElementById('<% =txtPermAdd2.ClientID %>').disabled = false;
                document.getElementById('<% =txtPermAdd3.ClientID %>').disabled = false;
                document.getElementById('<% =txtpermvillage.ClientID %>').disabled = false;
                document.getElementById('<% =ddlstate1.ClientID %>').disabled = false;
                //             document.getElementById('<% =txtPermStateCode.ClientID %>').disabled = false;
                document.getElementById('<% =txtpermDistrict.ClientID %>').disabled = false;
                //             document.getElementById('<% =txtPermStateDesc.ClientID %>').disabled = false;
                document.getElementById('<% =txtPermPostcode.ClientID %>').disabled = false;
                // document.getElementById('<% =txtPermCountryCode.ClientID %>').disabled = false;
                document.getElementById('<% =txtcity1.ClientID %>').disabled = false;
                document.getElementById('<% =txtarea1.ClientID %>').disabled = false;
                document.getElementById('<% =btnstate1search.ClientID %>').disabled = false;
                document.getElementById('<% =btnstate1search.ClientID %>').disabled = false;
                // document.getElementById('<% =btnPermState.ClientID %>').disabled = false;
            }
        }

        function funTrfrFlagclick(objcbTrfrFlag) {
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {

                //document.getElementById('<%=divTrnsferDetails.ClientID %>').Visible = false;

                //Added by kalyani on 30-12-2013 to disable composite license on transfer case click start
                document.getElementById('<% =cbTccCompLcn.ClientID %>').disabled = true;
                document.getElementById('<% =lblCompLcn.ClientID %>').disabled = true;
                //Added by kalyani on 30-12-2013 to disable composite license on transfer case click end
                document.getElementById('<% =lblOldLcnexpDate.ClientID %>').disabled = false;
                document.getElementById('<% =lbloldLcnNo.ClientID %>').disabled = false;
                document.getElementById('<% =lblPrevInsurerName.ClientID %>').disabled = false;
                document.getElementById('<% =txtOldTccLcnNo.ClientID %>').disabled = false;
                document.getElementById('<% =lblNOCFlag.ClientID %>').disabled = false;
                //document.getElementById("ctl00_ContentPlaceHolder1_txtOldTccLcnExpDate_txtDate").disabled = false;
                //document.getElementById("ctl00_ContentPlaceHolder1_txtOldTccLcnExpDate_btnCalendar").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtDate").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_btnoldlicense").disabled = false;

                document.getElementById('<% =ddlTrnsfrInsurName.ClientID %>').disabled = false; //added by pranjali on 13-03-2014 

                var controlObject = document.getElementById('<% =RbtNoc.ClientID%>');

                RecursiveEnabled(controlObject);
            }
            else {
                //Added by kalyani on 30-12-2013 to enable composite license on transfer case click start
                document.getElementById('ctl00_ContentPlaceHolder1_cbTccCompLcn').disabled = false;
                document.getElementById('<% =lblCompLcn.ClientID %>').disabled = false;
                //Added by kalyani on 30-12-2013 to enable composite license on transfer case click end
                document.getElementById('<% =txtOldTccLcnNo.ClientID %>').value = "";

                document.getElementById('<% =ddlTrnsfrInsurName.ClientID %>').value = ""; //added by pranjali on 13-03-2014 
                //document.getElementById("ctl00_ContentPlaceHolder1_txtOldTccLcnExpDate_txtDate").value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_txtDate").value = "";
                document.getElementById('<% =lblOldLcnexpDate.ClientID %>').disabled = true;
                document.getElementById('<% =lbloldLcnNo.ClientID %>').disabled = true;
                document.getElementById('<% =lblPrevInsurerName.ClientID %>').disabled = true;
                document.getElementById('<% =txtOldTccLcnNo.ClientID %>').disabled = true;
                document.getElementById('<% =lblNOCFlag.ClientID %>').disabled = true;
                //document.getElementById("ctl00_ContentPlaceHolder1_txtOldTccLcnExpDate_txtDate").disabled = true;
                //document.getElementById("ctl00_ContentPlaceHolder1_txtOldTccLcnExpDate_btnCalendar").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_txtDate").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_btnoldlicense").disabled = false;
                document.getElementById('<% =ddlTrnsfrInsurName.ClientID %>').disabled = true; //added by pranjali on 13-03-2014 


                for (i = 0; i < '<%= RbtNoc.Items.Count %>'; i++) {
                    var objCurRdo = document.getElementById("ctl00_ContentPlaceHolder1_RbtNoc_" + i);
                    objCurRdo.checked = false;
                    objCurRdo.disabled = true;
                }


            }

            function RecursiveEnabled(control) {
                var children = control.childNodes;
                try { control.removeAttribute('disabled') }
                catch (ex) { }
                for (var j = 0; j < children.length; j++) {
                    RecursiveEnabled(children[j]);
                }
            }

            function RecursiveDisable(control) {
                var children = control.childNodes;
                try { control.addAttribute('disabled') }
                catch (ex) { }
                for (var j = 0; j < children.length; j++) {
                    RecursiveDisable(children[j]);


                }
            }


        }

        //...gaurav

        //Nitesh Bank Control



        //Added by Kalyani on 30-12-2013 for Expandable-collapsable functionality start
        //     function ShowReqDtl(divId, btnId) {
        //     //debugger
        //         if (document.getElementById(divId).style.display == "block") {
        //             document.getElementById(divId).style.display = "none";
        //             //document.getElementById(divId).value = '+'
        //             document.getElementById(btnId).value = '+';
        //         }
        //         else {
        //             document.getElementById(divId).style.display = "block";
        //             //document.getElementById(btnId).value = '-'
        //             document.getElementById(btnId).value = '-';
        //         }
        //     }
        //Added by Kalyani on 30-12-2013 for Expendable-collapsable functionality end

        //Added by Prathamesh 7-8-15 start

        //     function IsMobileNumber(txtMobileTel) {
        //         var mob = /^[1-9]{1}[0-9]{9}$/;
        //         var txtMobile = document.getElementById(txtMobId);
        //         if (mob.test(txtMobile.value) == false) {
        //             alert("Please enter valid mobile number.");
        //             txtMobile.focus();
        //             return false;
        //         }
        //         return true;
        //     }

        //Added by Prathamesh 7-8-15 end



    </script>

    <script type="text/javascript">

        function ShowReqDtl12(divName, btnName) {
            ////debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
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
                ShowError(err.description);
            }
        }
        //for main div
        function ShowReqDtl1(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
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
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }*/

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


    <table style="width: 80%;  border-collapse: collapse;">
        <tr align="center">
            <td>
                <asp:Label ID="lblError2" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="lblMessage" Visible="false" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>

        <tr align="center" style="display: block;margin-left:-54%">
            <td align="left" style="width: 95%">
                <asp:ImageButton ID="lnkPage1" runat="server"
                    CssClass="TextBox" BackColor="transparent" OnClick="lnkPage1_Click"
                    ImageUrl="~/theme/iflow/tabs/Personal 2.png" CausesValidation="False"
                    TabIndex="1" />
                <asp:ImageButton ID="lnkPage2" runat="server"
                    CssClass="TextBox" BackColor="Transparent" OnClick="lnkPage2_Click"
                    ImageUrl="~/theme/iflow/tabs/profiling2.png" CausesValidation="False"
                    TabIndex="2" />
            </td>
        </tr>
    </table>




    <%--<ul id="myTab" class="nav nav-tabs" style="">
            <li class="listTabs"><a id="ancLegal" onclick="return fnSetTabs('1');" style="background-color: white; font-size: 150%; color: red;">Personal</a></li>
            <li class="listTabs"><a id="ancRel" onclick="return fnSetTabs('2');" style="font-size: 150%; color: black;">Profiling</a></li>
        </ul>--%>

    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <%--1-Personal section start--%>
        <asp:View ID="View1" runat="server">

           

                <%--Personal Information Start--%>
                <%--   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>--%>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPersonal','btnpersnl');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblpfPersonal" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>


                    <div id="divIsSpecified" runat="server" class="panel-body">
                        <asp:UpdatePanel ID="Updatepanel13" runat="server">
                            <ContentTemplate>
                                <table class="tableIsys" style="width: 100%;">
                                    <tr>
                                        <td class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblIsSPFlag" runat="server" CssClass="control-label"></asp:Label>
                                        </td>
                                        <td style="width: 30%;" class="formcontent">
                                            <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                                <ContentTemplate>
                                                    <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                        Visible="true" TabIndex="3"
                                                        AutoPostBack="true" OnSelectedIndexChanged="rbtIsSP_SelectedIndexChanged">
                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 20%;" class="formcontent"></td>
                                        <td style="width: 30%;" class="formcontent"></td>
                                    </tr>

                                    <tr id="tr_IsSPDtls" visible="false" runat="server">
                                        <td class="formcontent" style="width: 20%;">
                                            <asp:UpdatePanel ID="Updatepanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblCACode" runat="server" CssClass="control-label"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="Updatepanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtCACode" TabIndex="4" runat="server" CssClass="standardtextbox" MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    </asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server" InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                        FilterMode="InvalidChars" TargetControlID="txtCACode" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 20%;">
                                            <asp:UpdatePanel ID="Updatepanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblCAName" runat="server" CssClass="control-label"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" style="width: 30%;">
                                            <asp:UpdatePanel ID="Updatepanel12" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtCAName" TabIndex="5" runat="server" CssClass="standardtextbox" MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender76" runat="server"
                                                        InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" FilterMode="InvalidChars"
                                                        TargetControlID="txtCAName" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="divPersonal" style="display: block;" runat="server" class="panel-body">
                        <div class="row">

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblpfcndid" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtcndid" runat="server" CssClass="form-control" MaxLength="20" ReadOnly="true"
                                    Enabled="false" TabIndex="6"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblcategory" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%--  <span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdPanelCategory" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged"
                                            TabIndex="7">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblpfappno" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtapplicationno" runat="server" CssClass="form-control" Enabled="false" ReadOnly="true"
                                    TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                    FilterMode="InvalidChars" TargetControlID="txtapplicationno" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblpfregdate" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtregdate" runat="server" CssClass="form-control" Enabled="False"
                                    MaxLength="20" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblpfgivenName" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <div class="input-group">

                                    <%-- <asp:UpdatePanel ID="UpdPanelAgtType" runat="server">
                                                        <contenttemplate>--%>
                                    <span class="input-group-addon input-addon_extended">
                                        <asp:DropDownList ID="cboTitle" runat="server" CssClass="form-control" DataTextField="ParamDesc"
                                            DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                            Width="80px" TabIndex="10">
                                        </asp:DropDownList>
                                    </span>
                                    <%--  </contenttemplate>
                                                    </asp:UpdatePanel>
                                                  
                                                                </div>
                                                                 <div class="col-sm-2">--%>

                                    <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                        MaxLength="30" TabIndex="11" onblur="CheckSpaces();return false;"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" TargetControlID="txtGivenName"
                                        ValidChars=" " FilterMode="ValidChars">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                    <asp:HiddenField ID="hdnGenderTitle1" runat="server"></asp:HiddenField>
                                    <asp:HiddenField ID="hdnGenderTitle2" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <span>
                                    <asp:Label ID="lblpfSurName" runat="server" CssClass="control-label"></asp:Label></span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control"
                                    onChange="javascript:this.value=this.value.toUpperCase();"
                                    MaxLength="30" TabIndex="12"></asp:TextBox>

                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    TargetControlID="txtname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpffathername" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%--<span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtFathername" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                    MaxLength="60" TabIndex="13" onblur="AllowSpace();return false;"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FatherName" runat="server"
                                    InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" ValidChars=" " FilterMode="ValidChars"
                                    TargetControlID="txtFathername" FilterType="LowercaseLetters, UppercaseLetters,Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>

                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpfGender" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="cboGender" runat="server" CssClass="form-control"
                                    TabIndex="14">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--Added by Rachana on 20-04-2015 for addition of Relation DDL for FAther name entered start--%>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblRelation" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%--<span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlRelwithFather" runat="server" CssClass="form-control"
                                    DataSourceID="DsRelation" DataTextField="ParamDesc"
                                    DataValueField="ParamValue" TabIndex="15">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DsRelation" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:USERMGMT%>"
                                    SelectCommand="Prc_GetRelation" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            </div>

                        </div>
                        <%--Added by Rachana on 20-04-2015 for addition of Relation DDL for FAther name entered end--%>


                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblpfdob" runat="server" CssClass="control-label"></asp:Label>
                                <span><font color="red">*</font></span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox CssClass="form-control"
                                    runat="server" ID="txtDOB" MaxLength="15" ReadOnly="false"
                                    TabIndex="16" />
                                <%--onchange="setDateFormat('txtDob')"--%>
                            </div>
                            <%--ReadOnly="true"--%>
                            <%--onmousedown="$('#txtDob').datepicker({ changeMonth: true, changeYear: true });"--%>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblpfpob" Visible="false" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox CssClass="form-control" ID="txtplaceofbirthpersonal" runat="server" Visible="false" MaxLength="30"
                                    TabIndex="17"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpfmaritalstatus" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboMaritalStatus" runat="server" CssClass="form-control" AutoPostBack="true"
                                            TabIndex="18">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpfNationality" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <div class="input-group">
                                    <span class="input-group-addon input-addon_extended">
                                        <asp:TextBox ID="txtNationalCode" runat="server" Style="margin-bottom: 20px;" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                            Enabled="False" MaxLength="3" TabIndex="19"></asp:TextBox>
                                    </span>
                                    <asp:TextBox ID="txtNationalDesc" runat="server" CssClass="form-control" Enabled="False"
                                        onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="20"></asp:TextBox>
                                    <span class="input-group-btn input-addon_extended">
                                        <asp:LinkButton ID="btnNational" runat="server" CausesValidation="False" CssClass="btn btn-verify"
                                            Enabled="false" TabIndex="21" Text="..." Style="width: 100%; margin-left: 2px!important; margin-bottom: 20px!important;">
                                
                                   
                      <%--  <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> ...--%>
                                        </asp:LinkButton>
                                    </span>
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpfpan" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtCurrentID" runat="server" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"
                                                TabIndex="22"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender75" runat="server"
                                                InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtCurrentID"
                                                FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <%-- <span class="input-group-btn">--%>
                                            <span class="input-group-btn input-addon_extended">
                                                <asp:LinkButton ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="btn btn-verify"
                                                    OnClick="btnVerifyPAN_Click" OnClientClick="funpan();" TabIndex="23">
                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                </asp:LinkButton>
                                            </span>
                                            <%--        </span>--%>
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
                                <%--<a href="https://incometaxindiaefiling.gov.in/e-Filing/Services/KnowYourJurisdiction.html;jsessionid=Fl7hSy1QFps1MQr5XqXhX51h7rJp7Jyd1HLJnMxthzG1HLRhgPFl!905747125" target="_blank" style="font-size:13px"; tabindex="24">Income Tax PAN Verification Link</a>--%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="LblpanName" runat="server" CssClass="control-label"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblaadhr" runat="server" Text="Aadhaar No" Enabled="True" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel29" RenderMode="Inline" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <%-- <div  class="input-group">--%>
                                        <asp:TextBox ID="txtaadhr" Enabled="True" EnableViewState="true" runat="server" CssClass="form-control" MaxLength="12"
                                            TabIndex="25"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender82" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWYZabcdefghijklmnopqrstuvwxyz "
                                            FilterMode="InvalidChars" TargetControlID="txtaadhr" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <%--  &nbsp;--%>
                                        <%-- <span class="input-group-btn input-addon_extended"> 
                                                                    <asp:LinkButton ID="lnkaadhar" runat="server" Text="Verify"  CssClass="btn btn-verify"
                                                                    Enabled="false" OnClick="btnVerifyaadhar_Click" style="margin-bottom: 14px !important;"
                                                                        TabIndex="26">
                                                             <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify
                                                                 </asp:LinkButton>
                                                                    </span>--%>
                                        <%--  </div> --%>

                                        <%--<div id="div22" class="Content" style="display: none">
                                                             <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                                             <asp:Label ID="Label18" runat="server"></asp:Label>
                                                         </div>
                                                         <asp:Label ID="lblAadharMsg" runat="server" Font-Bold="False" CssClass="control-label"
                                                             Font-Size="X-Small"></asp:Label>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="tr1" class="row" >
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblCasteCat" runat="server" CssClass="control-label" Text="Category"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="form-control"
                                    TabIndex="27">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblPrimProf" runat="server" CssClass="control-label" Text="Primary Profession"></asp:Label>
                                <span style="color: red">*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlPrimProf" runat="server" CssClass="form-control"
                                    TabIndex="28">
                                    <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                    </div>
                </div>
                <%--  </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                <%--Personal Information End--%>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrComp','btnTrComp');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;">
                                <asp:Label ID="Label24" runat="server" Text="Candidate Type" CssClass="control-label" Font-Size="19px"></asp:Label>


                            </div>
                            <div class="col-sm-2">
                                <span id="btnTrComp" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>

                        </div>
                    </div>

                    <div id="divTrComp" style="display: block;" runat="server" class="panel-body">
                        <div class="row">
                            <div id="trFreshTitle" runat="server" class="col-sm-4" style="text-align: center; display: none;">
                                <asp:Label ID="lblfreshDtl" Visible="false" Text="Fresh Details" runat="server" Font-Bold="true"></asp:Label>
                                <asp:RadioButton ID="cbFrshFlag" GroupName="cndtype" runat="server" CssClass="standardcheckbox"
                                    AutoPostBack="true" OnCheckedChanged="cbFrshFlag_CheckedChanged"
                                    TabIndex="29" />
                                <asp:Label ID="lblfrshFlag" runat="server" Font-Bold="true" Style="color: black" Text="Fresh" CssClass="control-label"></asp:Label>


                            </div>
                            <div id="trTrnTitle" runat="server" class="col-sm-4" style="text-align: center">
                                <asp:Label ID="lblTransferDtl" Visible="false" Text="Roll Over Details" runat="server" Font-Bold="true"></asp:Label>
                                <asp:RadioButton ID="cbTrfrFlag" GroupName="cndtype" runat="server" CssClass="standardcheckbox"
                                    AutoPostBack="true" Enabled="true"
                                    OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="30" />
                                <asp:Label ID="lblTrfrFlag" runat="server" Font-Bold="true" Style="color: black" Text="RollOver Case" CssClass="control-label"></asp:Label>


                            </div>
                            <div id="trCompTitle" visible="false" runat="server" class="col-sm-3" style="text-align: center; display: none">
                                <%--Added display:none by Meena--%>

                                <asp:Label ID="lblCompositeDtl" Visible="false" Text="Composite Details" runat="server" Font-Bold="true"></asp:Label>
                                <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="True" AutoPostBack="true"
                                    TabIndex="31" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                                <asp:Label ID="lblCompLcn" runat="server" Font-Bold="true" Style="color: black" Text="Composite" CssClass="control-label"></asp:Label>



                            </div>
                            <div id="trTagTitle" runat="server" class="col-sm-4" style="text-align: center; display: none;">
                                <asp:Label ID="lblTagDtl" Visible="false" Text="Tagged Details" runat="server" Font-Bold="true"></asp:Label>
                                <asp:RadioButton ID="cbTagLcn" GroupName="cndtype" runat="server" CssClass="standardcheckbox"
                                    AutoPostBack="true" Enabled="true"
                                    OnCheckedChanged="cbTagFlag_CheckedChanged" TabIndex="32" />
                                <asp:Label ID="lblTagLcn" runat="server" Font-Bold="true" Style="color: black" Text="Tagged" CssClass="control-label"></asp:Label>


                            </div>
                        </div>

                        <div class="row">
                            <div id="divTrnsferDetails" runat="server" visible="false" class="panel">
                                <div id="Div5" runat="server" class="panel-heading subHeader" style="background-color: #ffffff !important"
                                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTransfer','btnTransfer');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="subheader">Roll Over Details</span>


                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnTransfer" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>

                                    </div>
                                </div>
                                <div id="divTransfer" style="display: block;" runat="server" class="panel-body">
                                    <div id="trNoteTr" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblIC" Style="color: black" CssClass="control-label" Text="I-C Date" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtIC" runat="server" CssClass="form-control"
                                                placeholder="Please provide last insurer I-C Date" TabIndex="33"></asp:TextBox>
                                            <asp:Image ID="btnCalendarIC" runat="server"
                                                Visible="false" ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />
                                            <%--commented by pratik 05-03-2018 It Was Showing an extra datepicker on UI--%>
                                            <%--                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txtIC"
                                                            PopupButtonID="btnCalendarIC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>--%>
                                        </div>
                                        <div id="tdNoteIc" style="display: none;" runat="server" class="col-sm-6">
                                            <asp:Label ID="lblNoteIc" runat="server" Text="Please provide last insurer I-C Date" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                    <div id="trTrnsfr1" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblCatTrnsfr" Style="color: black" CssClass="control-label" Text="Category" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCaTrnsfr" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlCaTrnsfr_OnSelectedIndexChanged" AutoPostBack="true"
                                                        TabIndex="34">
                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="trTrnsfr2" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblInsurerTrnsfr" Style="color: black" CssClass="control-label" Text="Name of Insurer" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel17">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNameInTrnsfr" runat="server" CssClass="form-control"
                                                        TabIndex="35">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblAgencyCodeTrnsfr" Style="color: black" CssClass="control-label" Text="Agency code number" runat="server"></asp:Label>
                                                *</span>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtAgencyCodeTrnsfr" runat="server" CssClass="form-control" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="20" TabIndex="36"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender80" runat="server"
                                                        TargetControlID="txtAgencyCodeTrnsfr" FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="trTrnsfr3" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblDateOfAppointmentTrnsfr" Style="color: black" CssClass="control-label" Text="Date of appointment as agent" runat="server"></asp:Label>
                                                *</span>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtDateOfAppointmentTrnsfr" runat="server" CssClass="form-control"
                                                TabIndex="37"></asp:TextBox>
                                            <asp:Image ID="btnCalendarTr" runat="server"
                                                Visible="false" ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />


                                        </div>
                                    </div>
                                    <div id="trTrnsfr4" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblStsTrnsfr" Style="color: black" CssClass="control-label" Text="Status" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlStsTrnsfr" runat="server" CssClass="form-control"
                                                        TabIndex="38">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        <%-- <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>--%>
                                                        <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                                    </asp:DropDownList>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="trTrnsfr5" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblDateOfCessationTrnsfr" Style="color: black" CssClass="control-label" Text="Date of cessation of agency" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtDateOfCessationTrnsfr" runat="server" CssClass="form-control"
                                                TabIndex="39"></asp:TextBox>
                                            <asp:Image ID="btnCalendartr2" Visible="false" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />


                                        </div>
                                        <div class="col-sm-3">

                                            <span style="color: red">
                                                <asp:Label ID="lblReasonForCessationTrnsfr" Style="color: black" CssClass="control-label" Text="Reason for cessation of agency" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel26">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtReasonForCessationTrnsfr" runat="server" CssClass="form-control"
                                                        TabIndex="40" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="row" style="text-align: center">
                                                <asp:LinkButton ID="btnAddTrnsfr" runat="server" CssClass="btn btn-sample" Style='margin-top: 22px; border-radius: 15px;'
                                                    OnClick="btnAddTrnsfr_Click"
                                                    TabIndex="41">
                               <span class="glyphicon glyphicon-plus BtnGlyphicon"> </span> Add
                                                </asp:LinkButton>
                                            </div>
                                            <div class="row">
                                                <br />
                                                <div class="col-sm-12" style="overflow-x: scroll;">


                                                    <asp:GridView ID="gvTrnsfr" OnRowDeleting="gvTrnsfr_RowDeleting" CssClass="footable" Style="border-bottom-color: black;"
                                                        TabIndex="42" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server">
                                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                        <PagerStyle CssClass="disablepage" />
                                                        <HeaderStyle CssClass="gridview th" />

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="I-C Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of insurer">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Agency code number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of appointment as agent">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of cessation of agency">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateCessation" runat="server" Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Reason for cessation of agency">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblReasonCessation" runat="server" Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'
                                                                        CommandName="delete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <input id="hdnTransfer" type="hidden" runat="server" />
                                    <table class="tableIsys" style="width: 100%; display: none;">

                                        <tr id="trTCCase" style="display: none;" runat="server">
                                            <td align="left" class="formcontent" style="width: 20%;">
                                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="License No"></asp:Label>
                                                    *</span>
                                                <%--  <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:UpdatePanel ID="updlcnVer1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="43" OnTextChanged="txtOldTccLcnNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="lbllcnerr2" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server" />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                            FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo" FilterType="Custom">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td align="left" class="formcontent" style="width: 20%;">
                                                <%--<span style="color: red">--%>
                                                <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black"></asp:Label><%--*</span>--%>
                                                   
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="44" />
                                                <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="45"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate" PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                                                <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true" ControlToValidate="txtDate" Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtDate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                            </td>
                                        </tr>
                                        <tr id="trTCCase1" style="display: none;" runat="server">
                                            <td align="left" class="formcontent" style="width: 20%;">
                                                <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>
                                                    *</span>
                                                <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <%--<asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" Visible="false" ></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlTrnsfrInsurName" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                    Width="270px" TabIndex="46">
                                                </asp:DropDownList>
                                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td align="left" class="formcontent" style="width: 20%;">

                                                <asp:Label ID="lblLicIssueDt" runat="server" Style="color: black" Text="License Issue Date"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:UpdatePanel ID="Updatepanel14" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtLicIssueDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="47"></asp:TextBox>
                                                        <asp:Image ID="btnLicIssue" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="48"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txtLicIssueDt" PopupButtonID="btnLicIssue" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" SetFocusOnError="true" ControlToValidate="txtLicIssueDt" Enabled="false"
                                                            ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR24" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtLicIssueDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator23" runat="server" ControlToValidate="txtLicIssueDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <%--// 01...06/09/2012...Miti--%>
                                        </tr>

                                        <tr id="tr4" style="display: none;" runat="server">
                                            <td align="left" class="formcontent" style="width: 20%;">
                                                <span style="color: Red">
                                                    <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received"></asp:Label>
                                                    *</span>
                                                <%--  <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <%--// 01...06/09/2012...Miti--%>
                                                <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2" AutoPostBack="false" Visible="false"
                                                    TabIndex="49" />
                                                <%----%>
                                                <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                                                    <ContentTemplate>
                                                        <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal"
                                                            CssClass="radiobtn" TabIndex="50"
                                                            AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td align="left" class="formcontent" style="width: 20%;"></td>
                                            <td class="formcontent" style="width: 30%;"></td>
                                        </tr>
                                        <tr id="trAckRcv" style="display: none;" runat="server">
                                            <td style="width: 20%;" class="formcontent">
                                                <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 30%;" class="formcontent">
                                                <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                                                    <ContentTemplate>
                                                        <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                            Visible="false" TabIndex="51">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 20%;" class="formcontent"></td>
                                            <td style="width: 30%;" class="formcontent"></td>

                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="divTagged" runat="server" visible="false" class="panel">
                                <div id="divTagDtls" runat="server" class="panel-heading subHeader" style="background-color: #ffffff !important"
                                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTag','btnTag');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="subheader">Tagged Details</span>


                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnTag" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>

                                    </div>
                                </div>
                                <div id="divTag" style="display: block;" runat="server" class="panel-body">

                                    <div id="divCatIns" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagCat" Style="color: black" CssClass="control-label" Text="Category" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTagCat" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlTagcat_SelectedIndexChanged" AutoPostBack="True" TabIndex="52">
                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>

                                                    </asp:DropDownList>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagIns" Style="color: black" CssClass="control-label" Text="Name of Insurer" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel31">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTagIns" runat="server" CssClass="form-control"
                                                        TabIndex="53">
                                                        <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="divAgnURN" runat="server" class="row">

                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagAgn" Style="color: black" CssClass="control-label" Text="Agency code number" runat="server"></asp:Label>
                                                *</span>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel32">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtTagAgn" runat="server" CssClass="form-control" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="20" TabIndex="55"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender83" runat="server"
                                                        TargetControlID="txtTagAgn" FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagURN" Style="color: black" CssClass="control-label" Text="URN No." runat="server"></asp:Label>
                                                *</span>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel36">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtTagURN" runat="server" CssClass="form-control" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                        onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="20" TabIndex="56"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender84" runat="server"
                                                        TargetControlID="txtTagURN" FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="divAppStatus" runat="server" class="row">
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagApp" Style="color: black" CssClass="control-label" Text="Date of appointment as agent" runat="server"></asp:Label>
                                                *</span>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtTagApp" runat="server" CssClass="form-control"
                                                TabIndex="57"></asp:TextBox>
                                            <asp:Image ID="Image3" runat="server"
                                                Visible="false" ImageUrl="~/App_UserControl/Common/calendar.bmp" Height="16px" />


                                        </div>
                                        <div class="col-sm-3">
                                            <span style="color: red">
                                                <asp:Label ID="lblTagStatus" Style="color: black" CssClass="control-label" Text="Status" runat="server"></asp:Label>
                                                *</span>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTagStatus" runat="server" CssClass="form-control"
                                                        TabIndex="58">
                                                        <%--  <asp:ListItem Value="0" Text="Select"></asp:ListItem>--%>
                                                        <asp:ListItem Value="A" Text="Active" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="I" Text="In Active"></asp:ListItem>
                                                    </asp:DropDownList>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                    <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                        <ContentTemplate>
                                            <div class="row" style="text-align: center">
                                                <asp:LinkButton ID="lnkAddTag" runat="server" CssClass="btn btn-sample" OnClientClick="javascript : return validateTagDetails()" Style='margin-top: 22px; border-radius: 15px;'
                                                    OnClick="btnAddTag_Click"
                                                    TabIndex="59">
                               <span class="glyphicon glyphicon-plus BtnGlyphicon"> </span> Add
                                                </asp:LinkButton>
                                            </div>
                                            <div class="row">
                                                <br />
                                                <div class="col-sm-12" style="overflow-x: scroll;">


                                                    <asp:GridView ID="grdTag" OnRowDeleting="grdTag_RowDeleting" CssClass="footable" Style="border-bottom-color: black;"
                                                        TabIndex="60" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" runat="server">
                                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                        <PagerStyle CssClass="disablepage" />
                                                        <HeaderStyle CssClass="gridview th" />

                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Category">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of insurer">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Agency code number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="URN No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblURNNo" runat="server" Text='<%# Bind("URNNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Date of appointment as agent">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'
                                                                        CommandName="delete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <div id="divCatFlag" runat="server" visible="false" class="row">
                                                        <div class="col-sm-3">
                                                            <span style="color: red">
                                                                <asp:Label ID="lblCatFlag" Style="color: black" CssClass="control-label" Text="Which type of Category do you want to consider for URN No.?"
                                                                    runat="server"></asp:Label>
                                                                *</span>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlCatFlag" runat="server" CssClass="form-control" TabIndex="61">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <input id="hdnTag" type="hidden" runat="server" />

                                </div>
                            </div>
                        </div>
                        <%-- composite segment hide  by usha on 06-12-2017 start --%>

                        <div class="row" runat="server" visible="false">
                            <div id="divCompDtls" runat="server" visible="false" class="panel">
                                <div id="Div24" runat="server" class="panel-heading subHeader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divComposite','btnComposite');return false;"
                                    style="background-color: #ffffff !important">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            Composite Details
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnComposite" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>

                                <div id="divComposite" style="display: block;" runat="server" class="panel-body">
                                    <div id="trNote" runat="server" class="row">
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblHasAgent" CssClass="control-label"
                                                Text="Has the agent taken an acknowledgement on form I-B from the other Insurance Company  (Y/N)" runat="server"></asp:Label>


                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButtonList ID="radioComposite" AutoPostBack="true" runat="server"
                                                RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10" TabIndex="61"
                                                OnSelectedIndexChanged="radioComposite_SelectedIndexChanged" Enabled="false">
                                                <asp:ListItem Value="0">YES &nbsp;</asp:ListItem>

                                                <asp:ListItem Value="1">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div id="divCompositeDetails" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <span style="color: red">
                                                    <asp:Label ID="lblCatComp" CssClass="control-label" Style="color: black" Text="Category" runat="server"></asp:Label>
                                                    *</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlCatComp" runat="server" CssClass="form-control"
                                                            TabIndex="62">
                                                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                            <%-- <asp:ListItem Value="Life" Text="Life"></asp:ListItem>
                                                                  <asp:ListItem Value="Health" Text="Health"></asp:ListItem>--%>
                                                        </asp:DropDownList>


                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div id="trInsurer" runat="server" class="row">
                                            <div class="col-sm-3">
                                                <span style="color: red">
                                                    <asp:Label ID="lblInsurer" CssClass="control-label" Style="color: black" Text="Name of Insurer" runat="server"></asp:Label>
                                                    *</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel runat="server" ID="updNameIns">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlNameIns" runat="server" CssClass="form-control"
                                                            TabIndex="63">
                                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel27">
                                                    <ContentTemplate>
                                                        <span style="color: red">

                                                            <asp:Label ID="lblAgencyCode" CssClass="control-label" Style="color: black" Text="Agency code number" runat="server"></asp:Label>
                                                            *</span>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtAgencyCode" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    MaxLength="20" TabIndex="64" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender81" runat="server"
                                                    TargetControlID="txtAgencyCode" FilterType="Numbers,UppercaseLetters,LowercaseLetters">
                                                </ajaxToolkit:FilteredTextBoxExtender>

                                            </div>
                                        </div>
                                        <div id="trAppointment" runat="server" class="row">
                                            <div class="col-sm-3">
                                                <span style="color: red">
                                                    <asp:Label ID="lblDateOfAppointment" CssClass="control-label" Style="color: black" Text="Date of appointment as agent" runat="server"></asp:Label>
                                                    *</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtDateOfAppointment" runat="server" CssClass="form-control"
                                                    TabIndex="65"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div id="trSts" runat="server" class="row">
                                            <div class="col-sm-3">
                                                <span style="color: red">
                                                    <asp:Label ID="lblSts" CssClass="control-label" Style="color: black" Text="Status" runat="server"></asp:Label>
                                                    *</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlSts" runat="server" CssClass="form-control"
                                                            TabIndex="66">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Inforce"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Cessation"></asp:ListItem>
                                                        </asp:DropDownList>


                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>
                                        <div id="trCessation" runat="server" class="row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblDateOfCessation" CssClass="control-label" Style="color: black" Text="Date of cessation of agency" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtDateOfCessation" runat="server" CssClass="form-control"
                                                    TabIndex="67"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblReasonForCessation" CssClass="control-label" Style="color: black" Text="Reason for cessation of agency" runat="server"></asp:Label>

                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel28">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtReasonForCessation" runat="server" CssClass="form-control"
                                                            TabIndex="68" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="updtransfer" runat="server">
                                            <ContentTemplate>
                                                <div class="row" style="text-align: center">
                                                    <div class="col-sm-12">
                                                        <asp:LinkButton ID="btnAddComposite" runat="server" CssClass="btn btn-verify" OnClick="btnAddComposite_Click"
                                                            TabIndex="69">
                               <span class="glyphicon glyphicon-plus BtnGlyphicon"> </span> Add
                                                        </asp:LinkButton>

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12" style="overflow-x: scroll;">
                                                        <asp:GridView ID="gvComposite" OnRowDeleting="gvComposite_RowDeleting" AutoGenerateColumns="false" Style="border-bottom-color: black;"
                                                            TabIndex="70" AutoGenerateDeleteButton="false" runat="server" CssClass="footable">
                                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                            <PagerStyle CssClass="disablepage" />
                                                            <HeaderStyle CssClass="gridview th" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name_of_Insurer">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNameInsurer" runat="server" Text='<%# Bind("Name_of_Insurer") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Agency_code_Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAgencyCode" runat="server" Text='<%# Bind("Agency_code_Number") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date_of_appointment_as_agent">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date_of_appointment_as_agent") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date_of_cessation_of_agency">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDateCessation" runat="server" Text='<%# Bind("Date_of_cessation_of_agency") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reason_for_cessation_of_agency">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReasonCessation" runat="server" Text='<%# Bind("Reason_for_cessation_of_agency") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--/added by amruta on 11.7.15 start--%>
                                                                <asp:TemplateField HeaderText="AutoWavier" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAutoWavier" runat="server" Text='<%# Bind("Autowavier") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--/added by amruta on 11.7.15 end--%>
                                                                <%-- <asp:CommandField ShowDeleteButton="true"  DeleteText="Delete" />--%>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<% #Eval("Agency_code_Number")%>'
                                                                            CommandName="delete" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <table class="tableIsys" style="width: 100%;">

                                            <tr id="tr2" style="display: none" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lblCompLicNo" runat="server" Style="color: black" Text="Life License No"></asp:Label>
                                                        *</span>
                                                </td>
                                                <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="updlcnver2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtCompLicNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="71" OnTextChanged="txtCompLicNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            <br />
                                                            <asp:Label ID="lbllcnerr" Font-Size="X-Small" Visible="false" ForeColor="Green" runat="server" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~"
                                                                FilterMode="InvalidChars" TargetControlID="txtCompLicNo" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                        <asp:Label ID="lblComplicnseExpDt" runat="server" Style="color: black"></asp:Label>
                                                        *</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtCompLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="72" />
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="73"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="txtCompLicExpDt" Enabled="false"
                                                        ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="COMPAREVALIDATOR2" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                                        ControlToValidate="txtCompLicExpDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                    <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
                                            </tr>
                                            <tr id="tr3" style="display: none" runat="server">
                                                <td align="left" class="formcontent" style="width: 20%;">
                                                    <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                                        <asp:Label ID="lblCompInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>
                                                        *</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <%--<asp:TextBox id="txtCompInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" ></asp:TextBox>--%>
                                                    <asp:DropDownList ID="ddlCompInsurerName" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                        Width="270px" TabIndex="74">
                                                    </asp:DropDownList>
                                                    <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>
                                                <td align="left" class="formcontent" style="width: 20%;"></td>
                                                <td class="formcontent" style="width: 30%;"></td>

                                            </tr>

                                        </table>

                                    </div>
                                    <input id="hdnCount" runat="server" type="hidden" />
                                </div>
                            </div>
                        </div>
                        <%-- composite segment hide  by usha on 06-12-2017 start --%>
                    </div>

                </div>

                <%--Fees Wavier Added by amrurta on 22-09-2016 start --%>
                <div id="tblFeesWavier" runat="server" visible="false" class="panel" style="margin-left: 0px; margin-right: 0px; display: none;">

                    <div class="panel-heading">

                        <asp:UpdatePanel ID="UpdFeesWavier" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-12" style="text-align: left; display: flex;">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>

                                        <asp:Label ID="lblFeesTitle" runat="server" Text="Fees Wavier Details" CssClass="control-label" Font-Size="19px"></asp:Label>
                                        <asp:CheckBox ID="ChkFeesWavier" Style="margin-left: 15px" runat="server" CssClass="standardCheckBox" AutoPostBack="true" Enabled="true" TabIndex="75" />
                                    </div>
                                    <%--<div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-collapse-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>--%>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--Fees Wavier Added by amrurta on 22-09-2016  end --%>
                <%--Composite Case end--%>
                <%--Nominee Details start--%>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <div class="panel" style="margin-left: 0px; margin-right: 0px;display:none;">
                            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNomineeDetails','btnNominee');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="Label3" runat="server" Text="Nominee Details" CssClass="control-label" Font-Size="19px"></asp:Label>

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnNominee" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>

                                </div>
                            </div>

                            <div id="divNomineeDetails" style="display: block;" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label5" Text="Nominee Name" CssClass="control-label" runat="server"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtNominee" runat="server" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                            MaxLength="100" TabIndex="76"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                            TargetControlID="txtNominee">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label7" Text="Relationship to Advisor" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="Ddlrelation" runat="server" CssClass="form-control"
                                            TabIndex="77">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label6" Text="Age" CssClass="control-label" runat="server"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtNomineeAge" runat="server" CssClass="form-control"
                                            MaxLength="2" TabIndex="78"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                            FilterMode="InvalidChars" TargetControlID="txtNomineeAge" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3">
                                    </div>
                                    <div class="col-sm-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Nominee Details end--%>

                <%--Recruit Information Start--%>
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <div class="panel" style="margin-left: 0px; margin-right: 0px">

                            <div id="Div7" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRecruitInformation','btnRecruitInformation');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblpfrecinfotitle" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnRecruitInformation" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <%-- <asp:UpdatePanel ID="UpdPanelRecruitInfo" runat="server">
                                        <contenttemplate>--%>
                            <div id="divRecruitInformation" style="display: block;" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label12" Text="Employee Code" CssClass="control-label" runat="server"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                            <ContentTemplate>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" TabIndex="78"
                                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                        InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtEmpCode"
                                                        FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <%--   <span class="input-group-btn">--%>
                                                    <span class="input-group-btn input-addon_extended">
                                                        <asp:LinkButton ID="btnEmpCode" runat="server" CssClass="btn btn-verify" OnClientClick="funrecruitercode();"
                                                            OnClick="btnVerifyEmpCode_Click" ValidationGroup="RecruitInfo" TabIndex="79">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Verify   
                                                        </asp:LinkButton>
                                                    </span>
                                                    <%--  </span>--%>
                                                </div>
                                                <div id="div1" class="Content" style="display: none">
                                                    <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...
                                                </div>

                                                <asp:Label ID="lblEmpMsg" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Font-Size="X-Small"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfsalchannel" runat="server" Font-Bold="False" CssClass="control-label" Style="color: Black"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="form-control"
                                            AutoPostBack="true" Enabled="false" TabIndex="80" OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfchasubclass" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control"
                                            AutoPostBack="false" Enabled="False" TabIndex="81">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfsmname" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtDirectAgtName" runat="server" CssClass="form-control" ReadOnly="true"
                                            Enabled="false" TabIndex="82"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfagetype" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: Red">*</span>
                                        <%--  <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntType" runat="server" CssClass="form-control" Visible="false"
                                            AutoPostBack="false" TabIndex="83">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlAgnTypes" runat="server" CssClass="form-control" Enabled="false"
                                            TabIndex="84">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfimmleader" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%--  <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <%--<asp:TextBox id="txtImmLeader" runat="server" CssClass="form-control"  iframe
                                                                MaxLength="10" ReadOnly="true" TabIndex="37"></asp:TextBox> 
                                                         <asp:Button id="btnImmLeaderCode" runat="server" CssClass="standardbutton"  Text="..." 
                                                                Enabled="false" visible="false" TabIndex="38"></asp:Button> 
                                                                <asp:HiddenField ID="hdnBranchCode" runat="server" />--%>

                                        <asp:UpdatePanel runat="server" ID="updPnl_txtRptCode" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="input-group" style="margin-left: 0%;">
                                                    <asp:TextBox ID="txtImmLeader" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control" Style="width: 242px;" TabIndex="85"></asp:TextBox>

                                                    <span class="input-group-btn input-addon_extended">
                                                        <asp:Button ID="btnImmLeaderCode" runat="server" CssClass="btn btn-verify" OnClick="btnmemgrid_Click" Text="...." Style="margin-right: 0%; margin-left: 5px !important;"
                                                            TabIndex="86" />
                                                        <%--'margin-left:5px !important;' added by Ajay on 19 Apr 2018 for testing bug--%>
                                                    </span>
                                                </div>

                                                <asp:HiddenField ID="hdnBranchCode" runat="server" />
                                                <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                                <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                                <asp:HiddenField ID="hdnMemType" runat="server" />
                                                <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                                <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static"
                                                    Style="display: none;" TabIndex="87" />
                                                <%-- <div style="display: flex;">
                                        <asp:TextBox ID="txtImmLeader" runat="server" Enabled="false" ReadOnly="true" CssClass="form-control" MaxLength="10" TabIndex="85"></asp:TextBox>
                                        <asp:Button ID="btnImmLeaderCode" runat="server" CssClass="btn btn-verify" OnClick="btnmemgrid_Click" Text="...." Style="margin-left: 2px;"
                                            TabIndex="86" />
                                          <asp:HiddenField ID="hdnBranchCode" runat="server" />
                                        <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                        <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                        <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static"
                                        Style="display: none;" TabIndex="87" />
                                    </div>--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblCandAgntType" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlCandType" runat="server" CssClass="form-control"
                                            AutoPostBack="false" TabIndex="88">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfrecagent" Visible="false" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtrecagent" runat="server" CssClass="form-control" Visible="false" MaxLength="10" ReadOnly="true" TabIndex="40"></asp:TextBox>
                                        <asp:Button ID="btnagent" runat="server" CssClass="standardbutton"
                                            Text="..." Enabled="False" Visible="false" TabIndex="89"></asp:Button>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfrecagtname" Visible="false" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtrecagtname" runat="server" CssClass="form-control" Visible="false"
                                            ReadOnly="true" TabIndex="90"></asp:TextBox>
                                    </div>
                                </div>
                                <%--Added By Ankita Shah for Referral EmpCode Information on 31/01/2013***********************--%>
                                <tr id="trRefEmpBy" runat="server" visible="false">
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:Label ID="lblReferredEmpBy" Text="Referral Code" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 30%;">
                                        <asp:TextBox ID="txtReferredEmpBy" runat="server" CssClass="standardtextbox"
                                            MaxLength="91"></asp:TextBox>
                                        <%--<div class="btn btn-xs btn-primary"><i class="fa fa-check-circle-o"></i>--%>
                                        <asp:Button ID="btnVerifyRefEmpBy" runat="server" CssClass="standardbutton" Text="Verify"
                                            TabIndex="92" OnClick="btnVerifyRefEmpBy_Click" ValidationGroup="RecruitInfo" Width="50px"></asp:Button>
                                        <%--</div> --%>
                                        <div id="iDivVerRefEmpBy" class="Content" style="display: none">
                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." /></img>Loading...
                                        </div>

                                        <asp:Label ID="lblErrRefEmpBy" runat="server" Style="color: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                        <asp:HiddenField ID="hdnRefEmpBy" runat="server"></asp:HiddenField>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                            TargetControlID="txtReferredEmpBy" FilterType="Numbers" Enabled="True">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:Label ID="lblrefEmp" Text="Referral Name" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:TextBox ID="txtRefByadvEmpName" runat="server" CssClass="standardtextbox"
                                            Enabled="true" TabIndex="93"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtRefByadvEmpName"
                                            FilterType="Custom, LowercaseLetters, UppercaseLetters" InvalidChars="./()',-!@$^*_+={}[]|\:;?><123456789"
                                            Enabled="True" FilterMode="InvalidChars">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <%--End Added By Ankita Shah for Referral EmpCode Information on 31/01/2013***********************--%>
                                <tr id="trRefBy" runat="server" visible="false">
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:Label ID="lblReferredBy" Text="Referred By Advisor" runat="server"></asp:Label></td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 30%;">
                                        <asp:TextBox ID="txtReferredBy" runat="server" CssClass="standardtextbox"
                                            MaxLength="10" TabIndex="94"></asp:TextBox>
                                        <%--<div class="btn btn-xs btn-primary"><i class="fa fa-check-circle-o"></i>--%>
                                        <asp:Button ID="btnVerifyRefBy" runat="server" CssClass="standardbutton" Text="Verify"
                                            OnClick="btnVerifyRefBy_Click"
                                            ValidationGroup="RecruitInfo" Width="50px" TabIndex="95"></asp:Button>
                                        <%--</div>--%>
                                        <div id="iDivVerRefBy" class="Content" style="display: none">
                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." /></img>Loading...
                                        </div>

                                        <asp:Label ID="lblErrRefBy" runat="server" Style="color: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                        <asp:HiddenField ID="hdnRefBy" runat="server"></asp:HiddenField>
                                    </td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:Label ID="Label10" Text="Referred By Advisor(Name)" runat="server"></asp:Label>
                                    </td>
                                    <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                        <asp:TextBox ID="txtRefByadvName" Enabled="false" runat="server" TabIndex="48"></asp:TextBox>
                                    </td>
                                </tr>
                            </div>
                            <%--    </contenttemplate>
                                    </asp:UpdatePanel>--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Recruit Information End--%>

                <%-- Exam Details Start--%>
                <table id="Table1" class="tableIsys" runat="server" style="width: 100%;" visible="false">
                    <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <asp:Label ID="lblExamTitle" runat="server" Font-Bold="False"
                                Text="Exam Details"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" style="width: 20%; height: 24px;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblExam" runat="server" Font-Bold="False" Style="color: Black"> </asp:Label>
                                *</span>
                            <%--  <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 24px;">
                            <asp:UpdatePanel ID="updExam" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu"
                                        OnSelectedIndexChanged="ddlExam_SelectedIndexChanged" AutoPostBack="true"
                                        DataTextField="ParamDesc1" DataValueField="ParamValue"
                                        AppendDataBoundItems="True" DataSourceID="DSddlExam" Width="152px" TabIndex="96">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DSddlExam" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" style="width: 20%; height: 24px;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>
                                *</span>
                            <%--<span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 24px;">
                            <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu"
                                        DataTextField="ParamDesc1" DataValueField="ParamValue"
                                        AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng" Width="152px" TabIndex="97">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="left" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblCentre" runat="server" CssClass="control-label" Text="Exam Centre"></asp:Label>
                                *</span>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="updExmCentre" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtExmCentre" runat="server" CssClass="standardtextbox" Enabled="false" Width="125px"
                                        TabIndex="98"></asp:TextBox>
                                    <input type="hidden" runat="server" id="hdnExmCentreCode" name="hdnExmCentreCode" />
                                    <asp:Button ID="btnExmCentre" runat="server" CssClass="standardbutton" CausesValidation="False"
                                        Text="..." TabIndex="99" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" align="left" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblYFrmNo" runat="server" Text="Yellow Form No" Style="color: Black"></asp:Label>
                                *</span>
                            <%--<span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtYFrmNo" runat="server" CssClass="standardtextbox"
                                Width="150px" TabIndex="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="left" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblExmBody" runat="server" CssClass="control-label" Text="Examination Body"></asp:Label>
                                *</span>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="UpdExmBody" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlExmBody" runat="server" CssClass="standardmenu"
                                        Width="152px" TabIndex="101">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="NSE-IT" Value="NSEIT"></asp:ListItem>
                                        <asp:ListItem Text="I.I.I." Value="III"></asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" align="left" style="width: 20%;"></td>
                        <td class="formcontent" style="width: 30%;"></td>
                    </tr>
                </table>
                <%-- Exam Details end--%>

                <%-- Training Details End --%>
                <table id="Table5" class="tableIsys" style="width: 100%;" runat="server" visible="false">
                    <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <asp:Label ID="lblTrnDtl" Text="Training Details" runat="server"
                                Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="left" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Training Mode"></asp:Label>
                                *</span>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:DropDownList ID="ddlTrnMode" runat="server" CssClass="standardmenu" Width="152px" TabIndex="102">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Online" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Offline" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="formcontent" align="left" style="width: 20%;">
                            <span style="color: red"><%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblTrnLoc" runat="server" CssClass="control-label" Text="Training Location"></asp:Label>
                                *</span>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:DropDownList ID="ddlTrnLoc" runat="server" CssClass="standardmenu"
                                Width="152px" TabIndex="103">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Online" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <%-- Training Details End --%>

                <%--Present Address Start--%>
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <div class="panel" style="margin-left: 0px; margin-right: 0px">
                            <div id="Div8" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPresentAddress','btnPresentAddress');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblpfpresentadd" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnPresentAddress" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>

                            <div id="divPresentAddress" style="display: block;" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfaddresstype" runat="server" CssClass="control-label"></asp:Label>
                                        <span
                                            style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlCnctType" runat="server" CssClass="form-control"
                                            DataTextField="ParamDesc" DataValueField="ParamValue"
                                            AppendDataBoundItems="True" DataSourceID="dsCnctType" TabIndex="104">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdnCnctType" runat="server" />
                                        <asp:SqlDataSource ID="dsCnctType" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="rfvCnctType" runat="server" SetFocusOnError="True" Display="None" ControlToValidate="ddlCnctType" ErrorMessage="Mandatory!" Enabled="False"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="vceCnctType" runat="server" Enabled="True" BehaviorID="vceCnctType" TargetControlID="rfvCnctType"></ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfStateP" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">
                                                 *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Style="width: 99% !important"
                                                        TabIndex="112">
                                                    </asp:DropDownList>

                                                    <%--   <span class="input-group-btn">--%>
                                                    <span class="input-group-btn input-addon_extended">
                                                        <asp:LinkButton ID="btnstatesearch" runat="server" CssClass="btn btn-verify" TabIndex="113" OnClick="btnstatesearch_Click">
                                      <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search   
                                                        </asp:LinkButton>
                                                    </span>
                                                    <asp:Button ID="Btnpincode" runat="server" OnClick="Btnpincode_Click" ClientIDMode="Static"
                                                        Style="display: none;" TabIndex="87" />
                                                    <%--  </span>--%>
                                                </div>
                                                <div id="Div13" class="Content" style="display: none">
                                                    <img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...
                                                </div>

                                                <asp:Label ID="Label17" runat="server" CssClass="control-label" Font-Bold="False"
                                                    Font-Size="X-Small"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="lblpfAddrP1" runat="server" Style="color: Black" CssClass="control-label"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                            <div class="col-sm-3">

                                                <asp:TextBox ID="txtAddrP1" runat="server" CssClass="form-control" TabIndex="105" Style='width: 100%;'
                                                    onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                    InvalidChars="& `''#%!@$^*-_+={}[]()|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtAddrP1"
                                                    FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <%--Added by shreela on 6/03/14 to remove space--%>
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="District" Style="color: Black"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                            <%--    Meena <asp:UpdatePanel runat="server">
                                    <ContentTemplate>--%>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtDistric" runat="server" CssClass="form-control" Enabled="false"
                                                    Font-Bold="False" MaxLength="50" TabIndex="114"></asp:TextBox>
                                                <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                                <asp:Button ID="btnDist" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                    Text="..." Enabled="false" Visible="false" TabIndex="115" />
                                                <asp:HiddenField ID="hdnDist" runat="server" />
                                                <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnPinTo" runat="server" />
                                            </div>
                                            <%--  Meena   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">

                                        <asp:Label ID="lblpfAddrP2" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtAddrP2" runat="server" CssClass="form-control"
                                            Placeholder="Enter street name" onChange="javascript:this.value=this.value.toUpperCase();"
                                            Font-Bold="False" MaxLength="100" TabIndex="106"></asp:TextBox>
                                        <asp:Label ID="lblStreet" Visible="false" runat="server" Text="(Enter street name)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                            FilterMode="InvalidChars" TargetControlID="txtAddrP2" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblcity" runat="server" Text="City" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtcity" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                            Font-Bold="False" MaxLength="50" TabIndex="116"></asp:TextBox>

                                        <asp:Button ID="btncity" runat="server" CssClass="standardbutton" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="117" />
                                        <asp:HiddenField ID="hdnCity" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">

                                        <asp:Label ID="lblpfAddrP3" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtAddrP3" runat="server" CssClass="form-control"
                                            onChange="javascript:this.value=this.value.toUpperCase();"
                                            Placeholder="Enter town name" Font-Bold="False"
                                            MaxLength="100" TabIndex="107"></asp:TextBox>
                                        <asp:Label ID="lblTown" runat="server" Visible="false" Text="(Enter town name)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                            FilterMode="InvalidChars" TargetControlID="txtAddrP3" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblarea" runat="server" CssClass="control-label" Text="Area"></asp:Label><span style="color: #ff0000">
                                            *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtarea" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                            Font-Bold="False" MaxLength="50" TabIndex="118"></asp:TextBox>
                                        <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                        <asp:Button ID="btnarea" runat="server" CssClass="standardbutton" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="119" />
                                        <asp:HiddenField ID="hdnArea" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblVillage" runat="server" CssClass="control-label" Text="Village"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdPanelVillage" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtVillage" runat="server" CssClass="form-control"
                                                    placeholder="Enter Village(If candidate is rural)" onChange="javascript:this.value=this.value.toUpperCase();" Font-Bold="False"
                                                    MaxLength="30" TabIndex="108"></asp:TextBox>
                                                <asp:Label ID="Lblvillagenote" Visible="false" runat="server" Text="(Village is mandatory if candidate is rural)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation start--%>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                                    TargetControlID="txtVillage">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation end--%>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                    FilterMode="InvalidChars" TargetControlID="txtVillage" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfPinP" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPinP" runat="server" CssClass="form-control" Enabled="false"
                                            Font-Bold="False" MaxLength="6" TabIndex="120"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                            FilterMode="InvalidChars" TargetControlID="txtPinP" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:HiddenField ID="hdnPin" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label11" runat="server" Text="State" CssClass="control-label" Visible="false"></asp:Label><%--<span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtStateCodeP" runat="server" CssClass="form-control" Visible="false"
                                            MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();"
                                            TabIndex="109"></asp:TextBox>
                                        <asp:TextBox ID="txtStateDescP" runat="server" Visible="false" CssClass="form-control"
                                            Enabled="true" TabIndex="110"></asp:TextBox>
                                        <asp:Button ID="btnStateP" runat="server" CssClass="form-control" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="111" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfCountryP" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <%--
                                                        <div class="input-group-addon">
                                IND</div>--%>

                                            <span class="input-group-addon input-addon_extended">
                                                <asp:TextBox ID="txtCountryCodeP" runat="server" CssClass="form-control"
                                                    Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    MaxLength="3" TabIndex="121"></asp:TextBox>
                                            </span><%--Width="25%"--%>
                                            <asp:TextBox ID="txtCountryDescP" runat="server"
                                                CssClass="form-control" Enabled="False" TabIndex="122"></asp:TextBox>
                                        </div>
                                        <span class="input-group-btn input-addon_extended">

                                            <asp:Button ID="btnCountryP" runat="server" CssClass="standardbutton"
                                                CausesValidation="False" Text="..."
                                                Enabled="true" TabIndex="123" />
                                        </span>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Present Address End--%>

                <%--Permanent Address start--%>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <div class="panel" style="margin-left: 0px; margin-right: 0px">
                            <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPermanentAddress','btnPermanentAddress');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="Label8" runat="server" Text="Permanent Address" CssClass="control-label" Font-Size="19px"></asp:Label>

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnPermanentAddress" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divPermanentAddress" style="display: block;" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-6" style="text-align: left">
                                        <%--style="width: 20%; text-align:left;"--%>
                                        <asp:Label ID="lblpfPrmAddTitle" runat="server" CssClass="control-label"></asp:Label>
                                        <asp:CheckBox ID="ChkPA" runat="server" CssClass="standardcheckbox" AutoPostBack="true" OnCheckedChanged="ChkPA_CheckedChanged" TabIndex="124" />
                                    </div>

                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfprmstatecode" CssClass="control-label" runat="server"></asp:Label><span style="color: #ff0000">
                                                *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlstate1" runat="server" CssClass="form-control" Style="width: 99% !important"
                                                TabIndex="133">
                                            </asp:DropDownList>
                                            <%--     <span class="input-group-btn"> --%>
                                            <span class="input-group-btn input-addon_extended">
                                                <asp:LinkButton ID="btnstate1search" runat="server" CssClass="btn btn-verify" CausesValidation="False" OnClick="btnstate1search_Click"
                                                    TabIndex="134"> 
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search   
                                                </asp:LinkButton>
                                            </span>
                                            <asp:Button ID="BtnPermanentPincode" runat="server" OnClick="BtnPermanentPincode_Click" ClientIDMode="Static"
                                                Style="display: none;" TabIndex="87" />
                                            <%--  </span> --%>
                                        </div>
                                    </div>

                                </div>
                                <div id="trPermAdd1" runat="server" class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfprmAdd" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPermAdd1" CssClass="form-control"
                                            onChange="javascript:this.value=this.value.toUpperCase();" runat="server"
                                            Font-Bold="False" MaxLength="100" TabIndex="125"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender223" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                            FilterMode="InvalidChars" TargetControlID="txtPermAdd1" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpermDistrict" runat="server" CssClass="control-label" Text="District" Style="color: Black"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtpermDistrict" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                            Font-Bold="False" MaxLength="50" TabIndex="135"></asp:TextBox>
                                        <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                        <asp:Button ID="btnpermDistrict" runat="server" CssClass="standardbutton" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="136" />
                                        <asp:HiddenField ID="hdnpermDist" runat="server" />
                                        <asp:HiddenField ID="hdnpermPinFrom" runat="server" />
                                        <asp:HiddenField ID="hdnpermPinTo" runat="server" />
                                    </div>
                                </div>
                                <div id="trPermAdd4" runat="server" class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfprmAdd2" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPermAdd2" CssClass="form-control" runat="server"
                                            PlaceHolder="Enter street name" MaxLength="100" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="126"></asp:TextBox>
                                        <asp:Label ID="lblstreet1" runat="server" Visible="false" Text="(Enter street name)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                            FilterMode="InvalidChars" TargetControlID="txtPermAdd2" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblcity1" runat="server" Text="City" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtcity1" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                            Font-Bold="False" MaxLength="50" TabIndex="137"></asp:TextBox>
                                        <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                        <asp:Button ID="btncity1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="138" />
                                        <asp:HiddenField ID="hdnCity1" runat="server" />
                                    </div>
                                </div>
                                <div id="trPermAdd2" runat="server" class="row">
                                    <div class="col-sm-3" style="text-align: left">

                                        <asp:Label ID="lblpfprmAdd3" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPermAdd3" runat="server" CssClass="form-control"
                                            Placeholder="Enter Town Name" MaxLength="100" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="127"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender79" runat="server" InvalidChars="&quot;',#$@%^!*()&''%^~`"
                                            FilterMode="InvalidChars" TargetControlID="txtPermAdd3" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:Label ID="lblTown1" Visible="false" runat="server" Text="(Enter town name)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblarea1" runat="server" CssClass="control-label" Text="Area"></asp:Label><span style="color: #ff0000">
                                            *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtarea1" runat="server" CssClass="form-control" ReadOnly="false" Enabled="false"
                                            Font-Bold="False" MaxLength="50" TabIndex="139"></asp:TextBox>
                                        <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                        <asp:Button ID="btnarea1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                            Text="..." Enabled="false" Visible="false" TabIndex="140" />
                                        <asp:HiddenField ID="hdnArea1" runat="server" />
                                    </div>
                                </div>
                                <div id="trPermAdd3" runat="server" class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpermVillage" runat="server" CssClass="control-label" Text="Village"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="upnlprmVillage" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtpermvillage" runat="server" CssClass="form-control"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" Font-Bold="False"
                                                    MaxLength="30" TabIndex="128"></asp:TextBox>
                                                <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation start--%>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_Village" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                                    TargetControlID="txtpermvillage">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <%--ADDED BY PRANJALI ON 05-03-2014 for allowing only characters for village validation end--%>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" InvalidChars=",#$@%^!*()&''%^~`"
                                                    FilterMode="InvalidChars" TargetControlID="txtpermvillage" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfprmpostcode" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%--<span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPermPostcode" runat="server" CssClass="form-control" Enabled="false"
                                            MaxLength="6" TabIndex="141"></asp:TextBox>
                                        <asp:HiddenField ID="hdnPin1" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtPermStateCode" runat="server" Visible="false" CssClass="form-control"
                                            MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="129"></asp:TextBox>
                                        <asp:TextBox ID="txtPermStateDesc" Visible="false" runat="server" CssClass="form-control"
                                            Enabled="false" TabIndex="131"></asp:TextBox>
                                        <asp:Button ID="btnPermState" runat="server" CssClass="standardbutton" Text="..."
                                            CausesValidation="False" Visible="false" TabIndex="132" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfprmcountry" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">

                                            <%--      <div class="input-group-addon">
                                IND</div>--%>
                                            <span class="input-group-addon input-addon_extended">
                                                <asp:TextBox ID="txtPermCountryCode" runat="server" CssClass="form-control"
                                                    Text="IND" Enabled="false" MaxLength="3" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    TabIndex="142"></asp:TextBox>
                                            </span><%--Width="25%"--%>
                                            <asp:TextBox ID="txtPermCountryDesc" runat="server" CssClass="form-control"
                                                Enabled="false" TabIndex="143"></asp:TextBox>
                                        </div>
                                        <span class="input-group-btn input-addon_extended">
                                            <asp:Button ID="btnPermCountry" runat="server" CssClass="standardbutton" Text="..."
                                                CausesValidation="False" Enabled="false" TabIndex="144" />
                                        </span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Permanent Address end--%>

                <%--Contact Information Start--%>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <div class="panel" style="margin-left: 0px; margin-right: 0px">
                            <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divContactInformation','btnContactInformation');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="Label9" runat="server" Text="Contact Information" CssClass="control-label" Font-Size="19px"></asp:Label>

                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnContactInformation" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>

                                </div>
                            </div>
                            <div id="divContactInformation" style="display: block;" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblpfconpreferred" runat="server" CssClass="control-label" Text="Prefered Mode of Contact"></asp:Label><span style="color: red">
                                               *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlDstbnMethod" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    TabIndex="144">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="LblWhatsaap" CssClass="control-label" Visible="false" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">

                                        <asp:TextBox ID="TxtWhatsaap" Visible="false" runat="server" CssClass="form-control" MaxLength="10" TabIndex="18"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender92" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                            FilterMode="InvalidChars" TargetControlID="TxtWhatsaap" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfhometel" runat="server" CssClass="control-label" Style="color: Black"></asp:Label>
                                        <span style="color: red"></span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <%--Added by usha on 16/05/15 to remove space--%>
                                        <div class="input-group">
                                            <%--  <div class="input-group-addon">91
                                            </div>
                                            --%>
                                            <span class="input-group-addon input-addon_extended">
                                                <asp:TextBox ID="TextBox2" runat="server" Text="91" CssClass="form-control"
                                                    Enabled="false" TabIndex="145"></asp:TextBox>
                                            </span><%--Width="25%"--%>
                                            <asp:TextBox ID="txthometel" runat="server"
                                                CssClass="form-control" MaxLength="10"
                                                Placeholder="Not start with 0 and accept 10 digit" TabIndex="146"></asp:TextBox>
                                        </div>
                                        <asp:Label ID="LblhomeNote" runat="server" Visible="false" Text="(Tel No:Should not start with 0 and should be 10 digit.)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                            FilterMode="InvalidChars" TargetControlID="txthometel" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>


                                    </div>

                                    <div class="col-sm-3" style="text-align: left">
                                        <span>
                                            <asp:Label ID="lblpfofftel" CssClass="control-label" runat="server" Width="76px"></asp:Label></span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtWorkTel" runat="server" CssClass="form-control"
                                            MaxLength="10" TabIndex="147"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                            FilterMode="InvalidChars" TargetControlID="txtWorkTel" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfmobtel" runat="server" Text="Mobile No.1" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <%-- <div class="input-group-addon">91
                                            </div>--%>

                                            <span class="input-group-addon input-addon_extended">
                                                <asp:TextBox ID="txtmobcode" runat="server" Enabled="false" Text="91" CssClass="form-control"></asp:TextBox>
                                            </span><%--Width="25%"--%>
                                            <asp:TextBox ID="txtMobileTel" runat="server" CssClass="form-control"
                                                Placeholder="Mobile No should be 10 digit." MaxLength="10" TabIndex="148"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                FilterMode="InvalidChars" TargetControlID="txtMobileTel" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>

                                        </div>
                                        <asp:Label ID="lblMobNote" Visible="false" runat="server" Text="(Mobile No should be 10 digit.)" Font-Size="Smaller" ForeColor="Red"></asp:Label>


                                    </div>


                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblMobile2" runat="server" CssClass="control-label" Text="Alternate Mobile Number"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <%--  <div class="input-group-addon">91

                                            </div>--%>

                                            <span class="input-group-addon input-addon_extended">
                                                <asp:TextBox ID="txtmobcode2" runat="server" Text="91" CssClass="form-control"
                                                    Enabled="false"></asp:TextBox>
                                                <%--Width="25%"--%></span>
                                            <asp:TextBox ID="txtMobile2" runat="server" CssClass="form-control"
                                                MaxLength="10" TabIndex="150"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                FilterMode="InvalidChars" TargetControlID="txtMobile2" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>

                                        </div>




                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <%--<span>--%>
                                        <asp:Label ID="lblpfemail" runat="server" Text="Email 1" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>

                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"
                                            MaxLength="50" TabIndex="151"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <span>
                                            <asp:Label ID="lblEmail2" runat="server" CssClass="control-label" Text="Email 2"></asp:Label>
                                        </span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control"
                                            MaxLength="50" TabIndex="152"></asp:TextBox><%----%>
                                    </div>

                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

                <table style="display: none;">
                    <tr id="trfax" runat="server" visible="false">
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblpffax" runat="server" Width="74px" Visible="false"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtfax" runat="server" CssClass="standardtextbox"
                                Visible="false" MaxLength="20" TabIndex="153"></asp:TextBox>
                        </td>
                        <td class="formcontent" style="width: 20%; height: 24px;">
                            <span>
                                <asp:Label ID="lblpfdirmail" Visible="false" runat="server" Width="84px"></asp:Label></span>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 24px;">
                            <asp:CheckBox ID="cbdirectmail" runat="server"
                                CssClass="standardcheckbox" Visible="false" TabIndex="154" />

                        </td>
                    </tr>
                    <tr id="trpager" runat="server" visible="false">
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblpfpager" runat="server" Visible="false" Width="72px"></asp:Label></td>
                        <td class="formcontent" style="width: 30%">
                            <asp:TextBox ID="txtpager" runat="server"
                                CssClass="standardtextbox" Visible="false" MaxLength="16" TabIndex="155"></asp:TextBox></td>
                        <td class="formcontent" style="width: 20%;">
                            <asp:Label ID="lblpfdidtel" runat="server" Visible="false" Width="78px"></asp:Label></td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:TextBox ID="txtdidtel" Visible="false" runat="server"
                                CssClass="standardtextbox" MaxLength="16" TabIndex="156"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <%--Contact Information End--%>

                <%--Account Information Start--%>
                <%--    Commented by kalyani on 21-12-2013 as Individual account info is not a required start--%>
                <%--  <div id="divAccInfo" runat ="server">--%>

                <%-- <table class="formtable" style="width: 100%;">
                                        <tr>
                                            <td class="test" align="left" colspan="4">
                                                <asp:Label ID="lblpfindaccinftitle" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%; height: 12px;">
                                                <asp:Label ID="lblpfBankAccntNo" runat="server" Font-Bold="False" ></asp:Label></td>
                                            <td class="formcontent" style="width: 30%; height: 12px;">
                                               <asp:UpdatePanel ID="UpBkaccno" runat="server">
                                                    <contenttemplate>
                                                         <asp:TextBox id="txtBankAccntNo" runat="server" CssClass="standardtextbox" 
                                                                MaxLength="24" TabIndex="375"></asp:TextBox> 
                                                    </contenttemplate>
                                               </asp:UpdatePanel>
                                          </div>   
                                            <td class="formcontent" style="width: 20%; height: 12px;">
                                                <asp:Label ID="lblpfBankAccHoldName" runat="server" Font-Bold="False" ></asp:Label></td>
                                            <td class="formcontent" style="width: 30%; height: 12px;">
                                               <asp:UpdatePanel ID="UpBkholdname" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox ID="txtBankAccHoldName" runat="server" CssClass="standardtextbox" 
                                                            MaxLength="60" TabIndex="380" Width="168px"  ></asp:TextBox>--%><%--Added by rachana 25-10-12 to changed width--%>
                <%--  </contenttemplate>
                                              </asp:UpdatePanel>
                                          </div>   
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%; height: 12px;">
                                                <asp:Label ID="lblpfBankNtfeCode" runat="server" Font-Bold="False" ></asp:Label></td>
                                            <td class="formcontent" style="width: 30%; height: 12px;">
                                               <asp:UpdatePanel ID="UpBkNtfeCode" runat="server">
                                                    <contenttemplate>
                                                            <asp:TextBox id="txtBankNtfeCode" runat="server" CssClass="standardtextbox" 
                                                                MaxLength="24" TabIndex="385"></asp:TextBox> 
                                                           <asp:Button ID="btnVerifyNEFT" runat="server"  
                                                                Cssclass="standardbutton" Text="Verify"  OnClick="btnVerifyNEFT_Click" 
                                                                ValidationGroup="BankInfo" TabIndex="386"/>
                                                           <div id="ivarLoad" class="Content" style="display:none"><img src="../../../App_Themes/Isys/images/spinner.gif" /></img>Loading...</div>
                                                           
                                                           <asp:Label ID="lblErrNtfe" runat="server" style="COLOR: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                          </div>   
                                            <td class="formcontent" style="width: 20%; height: 12px;" colspan="2">
                                                <asp:Label ID="lblpfBankNtfeCodeDesc" runat="server" Font-Bold="False" Font-Size="X-Small" style="COLOR: #ff0000" ></asp:Label>
                                          </div>   
                                        </tr> 
                                        <tr>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblpfBankCode" runat="server" Font-Bold="False"></asp:Label></td>
                                            <td class="formcontent" style="width: 30%;">
                                              <asp:UpdatePanel ID="UpBkCode" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="standardtextbox" 
                                                            Enabled="false" TabIndex="390"></asp:TextBox>
                                                        <asp:TextBox ID="txtBankCode" runat="server"  CssClass="standardtextbox" Visible = "false"  
                                                            Enabled="false" TabIndex="395"></asp:TextBox>--%>
                <!--<asp:DropDownList ID="ddlBankCode" runat="server" CssClass="standardmenu"></asp:DropDownList>-->
                <%--   </contenttemplate>
                                              </asp:UpdatePanel>
                                          </div>   
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblpfBankBranch" runat="server" Font-Bold="False" ></asp:Label></td>
                                            <td class="formcontent" style="width: 30%;">
                                               <asp:UpdatePanel ID="UPBkbranch" runat="server">
                                                    <contenttemplate>
                                                        <asp:TextBox ID="txtBankBranchName" runat="server" CssClass="standardtextbox" 
                                                            Enabled="false" TabIndex="400" Width="168px" 
                                                            ></asp:TextBox>--%><%--Added by rachana on 25-10-12 to change width--%>
                <%--  <asp:TextBox ID="txtBankBranchCode" runat="server" 
                                                            CssClass="standardtextbox"  Visible = "false" Enabled="false" TabIndex="405"></asp:TextBox>--%>
                <!--<asp:DropDownList ID="ddlBankBranch" runat="server" CssClass="standardmenu"></asp:DropDownList>-->
                <%-- </contenttemplate>
                                               </asp:UpdatePanel>
                                          </div>   
                                        </tr>
                                   </table> --%>
                <%--</div>   --%>
                <%--    Commented by kalyani on 21-12-2013 as Individual account info is not a required start--%>

                <%--Cash details start --%>
                <table class="tableIsys" style="width: 100%; display: none">
                    <tr id="trcashhdr" runat="server" visible="false">
                        <td class="test" colspan="4">
                            <asp:Label ID="lblchqdetails" runat="server" Font-Bold="False" Text="Cash Details"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trChequeDetail" runat="server" visible="false">
                        <%----%>
                        <td class="formcontent" style="width: 20%; height: 12px;">
                            <asp:Label ID="lblcheqdd" runat="server" Visible="false" Text="Cheque/DD No"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 12px;">
                            <asp:TextBox ID="txtchqdd" runat="server"
                                TabIndex="157" CssClass="standardtextbox" Visible="false" Text="" MaxLength="50"></asp:TextBox>
                        </td>
                        <td class="formcontent" style="width: 20%; height: 12px;">
                            <asp:Label ID="lblchqdate" runat="server" Visible="false" Font-Bold="False" Text="Cheque Date"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 12px;">
                            <asp:TextBox TabIndex="158" ID="txtchqdate" runat="server" CssClass="standardtextbox" />
                            <asp:Image ID="btnChqDate" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                            <asp:TextBox ID="btnChequeDetails" TabIndex="159" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderchqdate" runat="server" TargetControlID="txtDate" PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                            <asp:RequiredFieldValidator ID="RFVchqdate" runat="server" SetFocusOnError="true" ControlToValidate="txtDate" Enabled="false"
                                ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="COMPAREVALIDATORchqdate" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"
                                ControlToValidate="txtDate" Display="Dynamic"></asp:CompareValidator>
                            <asp:RangeValidator ID="RVchqdate" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                Type="Date"></asp:RangeValidator>
                            <%-- <uc7:ctlDate ID="txtchqdate" runat="server"  
                                                   CssClass="standardtextbox" Visible="false"  RequiredField="true" TabIndex="415"  />--%>
                        </td>
                    </tr>
                    <tr id="trCash" runat="server" style="display: none">
                        <td class="formcontent" style="width: 20%; height: 12px;">
                            <asp:Label ID="lblchqamt" runat="server" Text="Cash Amount" MaxLength="8"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 12px;">
                            <asp:TextBox ID="txtchqamt" runat="server" CssClass="standardtextbox"
                                TabIndex="160"></asp:TextBox>
                        </td>
                        <td class="formcontent" style="width: 20%; height: 12px;">
                            <asp:Label ID="lblCashReceipt" runat="server" Text="Cash/DD Received"></asp:Label>
                            <span style="color: red">*</span>
                        </td>
                        <td class="formcontent" style="width: 30%; height: 12px;">
                            <asp:CheckBox ID="chkCashReceipt" runat="server" TabIndex="161" />
                        </td>
                    </tr>
                </table>
                <%--Cash details end --%>

                <%--Proof of Document start--%>

                <div class="panel" style="margin-left: 0px; margin-right: 0px;display:none;">

                    <div id="Div11" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProofofDocument','btnProofofDocument');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblpfprodoctitle" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnProofofDocument" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <%--  </contenttemplate>
                           </asp:UpdatePanel>--%>
                    <div id="divProofofDocument" style="display: block;" runat="server" class="panel-body">
                        <table style="display: none;">
                            <tr id="trAgeAddrProof" runat="server" visible="false">
                                <td align="left" class="formcontent" style="width: 20%; height: 26px;">
                                    <asp:Label ID="lblpfageproof" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000"></span>
                                </td>
                                <td class="formcontent" style="width: 30%; height: 26px;">
                                    <asp:UpdatePanel ID="Upageproof" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlProofAge" runat="server" CssClass="standardmenu"
                                                Width="187px" TabIndex="162">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="height: 20px;">
                                    <asp:Label ID="lblpfaddproof" runat="server" CssClass="control-label"></asp:Label><span style="color: #ff0000">
                                                   
                                    </span>
                                </td>
                                <td class="formcontent" style="width: 30%; height: 26px;">
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="ddlProofAddr" runat="server" CssClass="standardmenu" CausesValidation="true"
                                            Width="187px" TabIndex="163">
                                        </asp:DropDownList>
                                    </span>
                                </td>

                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpnlQualification" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblBasicQual" runat="server" CssClass="control-label" Text="Basic Qualification"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%--  <span style="color: red">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdBasicQual" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlBasicQual" runat="server"
                                                    CssClass="form-control"
                                                    AutoPostBack="true"
                                                    CausesValidation="true"
                                                    OnSelectedIndexChanged="ddlBasicQual_SelectedIndexChanged" TabIndex="164">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblBoardName" runat="server" CssClass="control-label" Text="Board Name"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%--<span style="color: red">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtBoardName" runat="server" CssClass="form-control" MaxLength='50'
                                            onchange="javascript:this.value=this.value.toUpperCase();" TabIndex="165"></asp:TextBox><%--Added by rachana on 25-10-12 to change width--%>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_BoardName" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " FilterMode="ValidChars"
                                            TargetControlID="txtBoardName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblBasicRNo" runat="server" CssClass="control-label" Text="Basic Qual. Roll No"></asp:Label>
                                <span style="color: red">*</span>
                                <%-- <span style="color: red">*</span>--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtBasicRNo" runat="server" MaxLength="20" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"
                                    TabIndex="166"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender78" runat="server"
                                    TargetControlID="txtBasicRNo" FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>



                            <div class="col-sm-3" style="text-align: left">
                                <%--Added by shreela on 6/03/14 to remove space--%>
                                <asp:Label ID="lblYrPass" runat="server" CssClass="control-label"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <%--  <asp:TextBox ID="txtYrPass"  runat="server" CssClass="form-control" 
                                                        TabIndex="112" />--%>



                                <asp:TextBox ID="txtYrPass" runat="server" CssClass="form-control"
                                    TabIndex="167"></asp:TextBox>
                                <asp:Image ID="btnYrPass" runat="server"
                                    Visible="false" ImageUrl="~/App_UserControl/Common/calendar.bmp" />


                            </div>
                        </div>




                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblpfeduproof" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>
                                        <%-- <span style="color: #ff0000"></span>--%>
                                        <%--<span style="color: red">*</span>--%>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="Upeducationproof" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddleducationproof" runat="server"
                                                    CssClass="form-control" DataTextField="ParamDesc" DataValueField="ParamValue"
                                                    AppendDataBoundItems="True" DataSourceID="dseducationproof"
                                                    TabIndex="168">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="dseducationproof" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                                <%--<uc4:ddlLookup runat="server" ID="ddleducationproof" CssClass="standardmenu" RequiredField="false" LookupCode="NBEduQua" ValidationError="Mandatory!"></uc4:ddlLookup>--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="display:none;">
                                        <span style="color: red">
                                            <asp:Label ID="LblProfQual" CssClass="control-label" runat="server" Style="color: black"></asp:Label>
                                        </span>
                                    </div>
                                    <div class="col-sm-3" style="display:none;">

                                        <asp:DropDownList ID="ddlProfQual" runat="server" CssClass="form-control"
                                            TabIndex="107">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="row" style="display:none;">
                                    <div class="col-sm-3">
                                        <span style="color: red">
                                            <asp:Label ID="LblInsQual" CssClass="control-label" runat="server" Style="color: black">
                                            *</span>
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
                                <div class="row">
                                    <div class="col-sm-4" style="text-align: left; display: none">
                                        <%--;display:none added by meena 16_4_18--%>
                                        <asp:Label ID="lblPhotoSign" runat="server" Text="Photos/Signature Recd" CssClass="control-label" Visible="true" Style="color: Black"></asp:Label>
                                        <span style="color: Red">*</span> <%--changed by kalayani on 20-12-2013 '4 Photos/Signature Recd' to 'Photos/Signature Recd'--%>
                                        <%-- <span style="color: red">*</span>--%>

                                        <asp:CheckBox ID="chkPhotoSign" runat="server" CssClass="standardCheckBox" Visible="true" TabIndex="169" />
                                    </div>
                                    <div class="col-sm-4" style="text-align: center; display: none">
                                        <%--;display:none added by meena 16_4_18--%>
                                        <asp:Label ID="lblpfmarksheet" runat="server" CssClass="control-label"></asp:Label>

                                        <asp:CheckBox ID="cbmarksheet" runat="server" CssClass="standardcheckbox"
                                            TabIndex="170" />
                                        <%--<span style="color: red">*</span>--%>
                                    </div>
                                    <div class="col-sm-4" style="text-align: right; display: none">
                                        <%--;display:none added by meena 16_4_18--%>
                                        <asp:Label ID="lblpfcertificate" runat="server" CssClass="control-label"></asp:Label>

                                        <asp:CheckBox ID="cbcertificate" runat="server" CssClass="standardcheckbox"
                                            TabIndex="171" />
                                    </div>
                                </div>
                                <div class="row" id="trNOCAck" runat="server" visible="false" style="display: none;">
                                    <div class="col-sm-4" style="text-align: left">
                                        <asp:Label ID="lblNOCAck" runat="server" Text="NOC/Acknowledgement" CssClass="control-label"></asp:Label>
                                        <span style="color: red">*</span>


                                        <asp:CheckBox ID="chkNOCAck" runat="server" TabIndex="172" />
                                    </div>
                                </div>
                                <%--  Added by kalyani on 21-12-2013 for panchayat proof received start--%>
                                <tr id="trPanchayat" runat="server" visible="false">
                                    <td class="formcontent" align="left" style="width: 20%;">
                                        <%--<span style="color: red">--%><%--Modify by Nikhil on 23.04.15-- %><%--Added by shreela on 6/03/14 to remove space--%>
                                        <asp:Label ID="lblPanachayat" runat="server" Text="Panchayat Proof Received" Style="color: Black"></asp:Label><%--*</span>--%>
                                        <%--<span style="color: red">*</span>--%>
                                    </td>
                                    <td class="formcontent" style="width: 30%;">
                                        <asp:CheckBox ID="cbPanachayat" runat="server" TabIndex="173" />
                                    </td>
                                    <td class="formcontent" colspan="2">
                                        <asp:Label ID="lblNote2" runat="server" ForeColor="red" Text="Note : Population in village should be less than 5000"></asp:Label>
                                        <%--added by pranjali on 03-03-2014--%>
                                    </td>
                                </tr>

                                <%--  Added by kalyani on 21-12-2013 for panchayat proof received end--%>
                                <tr id="trcfr" runat="server" visible="false">
                                    <td class="formcontent" align="left" style="width: 20%;">
                                        <asp:Label ID="lblcfr" runat="server" CssClass="control-label" Text="CFR"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%;">
                                        <asp:CheckBox ID="cbcfr" runat="server" CssClass="standardcheckbox"
                                            TabIndex="174" />
                                    </td>
                                    <td class="formcontent" style="width: 20%;">
                                        <asp:Label ID="lblremarks" runat="server" CssClass="control-label" Text="Remarks"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%;">
                                        <asp:TextBox ID="txtremarks" runat="server"
                                            CssClass="standardtextbox" Rows="2" TextMode="multiLine" TabIndex="175"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <!-- Visible="false" added by ank on 08.08.2011 -->
                                    <td class="formcontent" style="width: 20%; display: none;">
                                        <asp:Label ID="lblpfphoto" runat="server" Visible="false" Style="color: black;"></asp:Label>
                                        <!--<span style="color: red" >*</span>-->
                                    </td>
                                    <td class="formcontent" style="width: 30%; display: none;">
                                        <asp:CheckBox ID="cbphoto" runat="server"
                                            CssClass="standardcheckbox" Visible="false" TabIndex="176" />
                                    </td>
                                    <td class="formcontent" align="left" style="width: 20%; display: none;">
                                        <asp:Label ID="lblLUnitCode" runat="server" Visible="false" CssClass="control-label" Text="Log in Location"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%; display: none;">
                                        <asp:TextBox ID="txtUnitName" runat="server" CssClass="standardtextbox" ReadOnly="true" Visible="false"
                                            Rows="2" Width="120px" TabIndex="177"></asp:TextBox>
                                        <input type="hidden" runat="server" id="txtUnitCode" name="txtUnitCode" visible="false" />
                                        <asp:Button ID="btnLUnitCode" runat="server" CssClass="standardbutton" Visible="false"
                                            CausesValidation="False" Text="..." TabIndex="178" />
                                    </td>
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--Proof of Document end--%>
                <%--Bank Details start 08/06/2017--%>

                <%--<table class="formtable" style="width: 100%;">--%>
                <%--<div class="panel" style="margin-left:0px;margin-right:0px">
                                        <tr>
                                             <td  class = "test" colspan="4" style="text-align: left;">
                                                <input runat="server" type="button" class="standardlink" value="-" id="btnbnkdtls" style="width: 20px;"
                                                  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divbnkdtls','ctl00_ContentPlaceHolder1_divbnkdtls');" />
                                                 <asp:Label ID="lblbnkdtls" runat="server" Font-Bold="true"></asp:Label>
                                             </td>
                                        </tr>
                                     </table>--%>




                <div id="Div23" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divbnkdtls','btnProofofDocument');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="lblbnkdtls" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                        </div>
                        <div class="col-sm-2">
                            <span id="btnbnkdtls" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>

                <div id="divbnkdtls" style="display: block;" runat="server" class="panel-body">

                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblbnkhldname" runat="server" Style="color: black" CssClass="control-label"></asp:Label><span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3">
                            <span style="color: #ff0000">
                                <asp:TextBox ID="txtbnkhldname" runat="server" CssClass="form-control" TabIndex="180" MaxLength="50"
                                    onblur="AllowSpacebnkname(this);return false;" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender85" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" "
                                    TargetControlID="txtbnkhldname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </span>
                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblbnkacno" runat="server" Style="color: black" CssClass="control-label"></asp:Label>
                            <span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3">
                            <asp:TextBox ID="txtbnkacno" runat="server" CssClass="form-control" TabIndex="181" MaxLength="20" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>

                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender86" runat="server"
                                FilterType="Numbers,LowercaseLetters, UppercaseLetters,Custom"
                                TargetControlID="txtbnkacno">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblbnkname" runat="server" Style="color: black" CssClass="control-label"></asp:Label><span style="color: #ff0000">&nbsp; *</span>
                        </div>

                        <div class="col-sm-3">
                            <span style="color: #ff0000">
                                <asp:TextBox ID="txtbnkname" runat="server" CssClass="form-control" TabIndex="182" MaxLength="100" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>

                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender87" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=". , "
                                    TargetControlID="txtbnkname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </span>
                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblbrnchname" runat="server" Style="color: black" CssClass="control-label"></asp:Label>
                            <span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <span style="color: #ff0000">
                                <asp:TextBox ID="txtbrnchname" runat="server" CssClass="form-control" TabIndex="183" MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender88" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" "
                                    TargetControlID="txtbrnchname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblactype" runat="server" Style="color: black" CssClass="control-label"></asp:Label><span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3">

                            <asp:DropDownList ID="ddlactype" runat="server" CssClass="form-control" Style="width: 100%" TabIndex="184">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Saving" Value="Saving"></asp:ListItem>
                                <asp:ListItem Text="Current" Value="Current"></asp:ListItem>
                            </asp:DropDownList>

                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblifsccode" runat="server" Style="color: black" CssClass="control-label"></asp:Label>
                            <span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3">
                            <span style="color: #ff0000">
                                <asp:TextBox ID="txtifsccode" runat="server"
                                    Style="text-transform: uppercase;" CssClass="form-control" TabIndex="185" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender89" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers"
                                    TargetControlID="txtifsccode">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </span>
                            <span id="spanifsccode" runat="server" style="color: red; display: none;">Incorrect Bank IFSC Code
                            </span>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblmicrcode" runat="server" Style="color: black" CssClass="control-label"></asp:Label><span style="color: #ff0000">&nbsp;*</span>
                        </div>

                        <div class="col-sm-3">

                            <asp:TextBox ID="txtmicrcode" runat="server" CssClass="form-control" TabIndex="186" MaxLength="9"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender90" runat="server"
                                FilterType="Custom,Numbers"
                                TargetControlID="txtmicrcode">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <%--LowercaseLetters, UppercaseLetters,--%>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblGstcode" runat="server" Style="color: black" CssClass="control-label"></asp:Label>
                        </div>

                        <div class="col-sm-3">

                            <asp:TextBox ID="txtGSTNO" runat="server" CssClass="form-control" TabIndex="187" MaxLength="15" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender91" runat="server"
                                InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtGSTNO"
                                FilterType="Custom,LowercaseLetters, UppercaseLetters">
                            </ajaxToolkit:FilteredTextBoxExtender>

                        </div>
                    </div>
                </div>
                <%--End Bank Details start 08/06/2017--%>
           
        </asp:View>
        <asp:View ID="View2" runat="server">
            
                <%-- <div class="panel" style="margin-left:0px;margin-right:0px">
                          <div class="row">
                                    <div class="col-sm-3">
                                        <input runat="server" type="button" class="standardlink" value="-" id="btnView2"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView2','ctl00_ContentPlaceHolder1_btnView2');" />
                                        <asp:Label ID="lblView2" Text="Profiling" runat="server"  CssClass="control-label" Font-Bold="true"></asp:Label>
                               </div>
                             
                            </div>
                          </div>--%>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">

                    <%--Personal Information start--%>
                    <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divQPersonal','btnQPersonal');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblqfpersonalinformation" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnQPersonal" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>

                        </div>
                    </div>

                    <div id="divQPersonal" runat="server" style="display: block" class="panel-body" width="100%;">

                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblqfcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox Enabled="False" CssClass="form-control" ID="lblqcndno" runat="server" TabIndex="179"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left" visible="false">
                                <asp:Label ID="lblqfcategorytitle" Visible="false" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left" visible="false">
                                <asp:TextBox Enabled="False" Visible="false" CssClass="form-control" ID="lblqfcategory" runat="server" TabIndex="180"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblqfappnotitle" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox TabIndex="181" Enabled="False" CssClass="form-control" ID="lblqappno" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblqfregdatetitle" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox Enabled="False" CssClass="form-control" ID="lblqregdate" runat="server" TabIndex="182"></asp:TextBox>
                            </div>
                        </div>

                        <%--comment by Prathamesh Name and surname--%>

                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblqfgivennametitle" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox Enabled="False" CssClass="form-control" ID="lblqgivenname" runat="server" TabIndex="183"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblqfsurname" CssClass="control-label" runat="server" TabIndex="184"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox Enabled="False" CssClass="form-control" ID="lblqsurname" runat="server" TabIndex="184"></asp:TextBox>
                            </div>
                        </div>
                        <%--comment by Prathamesh Name and surname end--%>

                        <%--Personal Information end--%>
                    </div>
                </div>
                <table class="formtable" style="width: 100%; display: none;">
                    <%--Languages known start--%>
                    <tr>
                        <td class="test" colspan="4">
                            <asp:UpdatePanel ID="upnldivLanguage" runat="server">
                                <ContentTemplate>
                                    <input runat="server" type="button" class="standardlink" value="+" id="btnLanguage"
                                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLanguage', 'btnLanguage');" />
                                    <asp:Label ID="lblqfknolanguagestitle" runat="server" Font-Bold="true"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <div id="divLanguage" runat="server" style="display: none" width="100%;">
                    <table class="tableIsys" style="width: 100%;">
                        <tr>
                            <td class="formcontent" align="left"></td>
                            <td class="formcontent" align="left">
                                <asp:Label ID="lblqflanguage1" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnlLanguage1" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblqfread1" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblqfwrite1" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblqfspeak1" runat="server" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left"></td>
                            <td class="formcontent" align="left">
                                <asp:Label ID="lblqflanguage2" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnlLanguage2" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblqfread2" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblqfwrite2" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblqfspeak2" runat="server" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" align="left">
                                <asp:Label ID="lblqflanguagesKnown1" runat="server"></asp:Label>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddllanknow1" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="100px" OnSelectedIndexChanged="ddllanknow1_SelectedIndexChanged" TabIndex="185">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td id="tdlanknow1" runat="server" class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow1Chk" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbpread" runat="server" CssClass="standardcheckbox"
                                            Visible="false" TabIndex="186" />
                                        <asp:CheckBox ID="cbpwrite" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="187" />
                                        <asp:CheckBox ID="cbpspeak" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="188" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow1" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:Label ID="lblqflanguagesKnown2" runat="server" Font-Bold="False" Width="117px"></asp:Label>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddllanknow3" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="100px" OnSelectedIndexChanged="ddllanknow3_SelectedIndexChanged" TabIndex="189">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow3Chk" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbpread3" runat="server" CssClass="standardcheckbox"
                                            Visible="false" TabIndex="190" />
                                        <asp:CheckBox ID="cbpwrite3" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="191" />
                                        <asp:CheckBox ID="cbpspeak3" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="192" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow3" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" align="left"></td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddllanknow2" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="100px" OnSelectedIndexChanged="ddllanknow2_SelectedIndexChanged" TabIndex="193">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow2Chk" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbpread2" runat="server" CssClass="standardcheckbox"
                                            Visible="false" TabIndex="194" />
                                        <asp:CheckBox ID="cbpwrite2" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="195" />
                                        <asp:CheckBox ID="cbpspeak2" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="196" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow2" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left"></td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddllanknow4" runat="server" CssClass="standardmenu" Width="100px"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddllanknow4_SelectedIndexChanged"
                                            TabIndex="197">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="formcontent" align="left">
                                <asp:UpdatePanel ID="upnllanknow4Chk" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbpread4" runat="server" CssClass="standardcheckbox"
                                            Visible="false" TabIndex="198" />
                                        <asp:CheckBox ID="cbpwrite4" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="199" />
                                        <asp:CheckBox ID="cbpspeak4" runat="server" CssClass="standardcheckbox" Visible="false"
                                            TabIndex="200" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllanknow4" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <%--Languages known End--%>
                    </table>
                </div>
                <table class="formtable" style="width: 100%; display: none;">
                    <%--Address of Employer start--%>
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="standardlink" value="+" id="btnQOccupation"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divOccupation', 'ctl00_ContentPlaceHolder1_btnQOccupation');" />
                            <asp:Label ID="lbqfloccqualification" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="divOccupation" runat="server" style="display: none" width="100%;">
                    <table class="tableIsys" style="width: 100%;">
                        <tr>
                            <td class="formcontent" style="width: 20%">
                                <asp:Label ID="lblqfHigestQul" runat="server"></asp:Label><span style="color: red">*</span>
                            </td>
                            <td class="formcontent" style="width: 26%" colspan="4">
                                <asp:UpdatePanel ID="upnlQualCode" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboQualCode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="310px" TabIndex="201">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--<uc4:ddlLookup runat="server" ID="cboQualCode" CssClass="standardmenu" 
                                                 RequiredField="false" LookupCode="NBEduQua" ValidationError="Mandatory!" 
                                                 TabIndex="580"></uc4:ddlLookup>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%">
                                <asp:Label ID="lblqfinsqualification" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 501px" colspan="4">
                                <asp:TextBox CssClass="standardtextbox" ID="txtinsurancequalification" runat="server"
                                    MaxLength="50" Width="300px" TabIndex="202"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" align="left" style="width: 20%">
                                <span style="color: red">
                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblqfoccupation" runat="server" CssClass="control-label"></asp:Label>*</span>
                                <%-- <span style="color: red">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%" align="left">
                                <asp:TextBox ID="txtOccupationCode" runat="server" CssClass="standardtextbox"
                                    Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="4"
                                    TabIndex="203"></asp:TextBox>
                                <asp:TextBox ID="txtOccupationDesc" runat="server" CssClass="standardtextbox" Enabled="false"
                                    Width="120px" onChange="javascript:this.value=this.value.toUpperCase();"
                                    TabIndex="204"></asp:TextBox>

                                <asp:Button ID="btnOccupation" runat="server" CssClass="standardbutton" Text="..."
                                    CausesValidation="False" Width="20px" TabIndex="205"></asp:Button>
                            </td>
                            <td class="formcontent" style="width: 20%">
                                <asp:Label ID="lblqfempaddress" runat="server" Font-Bold="False"></asp:Label>
                            </td>
                            <td class="formcontent" style="width: 30%">
                                <asp:TextBox ID="txtempaddress" runat="server" CssClass="standardtextbox" MaxLength="100"
                                    Width="178px" TextMode="MultiLine" TabIndex="206"></asp:TextBox>
                            </td>
                        </tr>
                        <%--Address of Employer End--%>
                    </table>
                </div>
                <table class="formtable" style="width: 100%; display: none;">
                    <tr>
                        <td class="test" colspan="5">
                            <input runat="server" type="button" class="standardlink" value="+" id="btnFunProduct"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divFunProduct', 'ctl00_ContentPlaceHolder1_btnFunProduct');" />
                            <asp:Label ID="lblqfdoyouhave" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="divFunProduct" runat="server" style="display: none" width="100%;">
                    <table class="tableIsys" style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <table class="tableIsys" style="width: 100%;">
                                    <tr>
                                        <td class="formcontent" align="left" style="width: 20%">
                                            <asp:Label ID="lblqffromreliance" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left" style="width: 15%">
                                            <asp:CheckBox ID="cbMutFund" runat="server" CssClass="standardcheckbox" TabIndex="207" />
                                        </td>
                                        <td class="formcontent" align="left" style="width: 15%">
                                            <asp:CheckBox ID="cbLifeIns" runat="server" CssClass="standardcheckbox" TabIndex="208" />
                                        </td>
                                        <td class="formcontent" align="left" style="width: 18%">
                                            <asp:CheckBox ID="cbGenIns" runat="server" CssClass="standardcheckbox" TabIndex="209" />
                                        </td>
                                        <td class="formcontent" align="left" style="width: 15%">
                                            <asp:CheckBox ID="cbCreCard" runat="server" CssClass="standardcheckbox" TabIndex="210" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 18%">
                                <asp:Label ID="lblqffromothers" runat="server" Width="176px"></asp:Label>
                            </td>
                            <td class="formcontent" colspan="3">
                                <asp:TextBox ID="txtOtherProduct" runat="server" CssClass="standardtextbox" Width="200px"
                                    MaxLength="20" TabIndex="211"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>



                <div id="divView3" runat="server" style="display: none; width: 90%;">
                    <table id="Table4" runat="server" class="container" style="width: 100%">
                        <tr>
                            <td style="width: 791px" align="center">
                                <%--Personal Information--%>
                                <table class="formtable" width="90%" style="display: none;">
                                    <tr>
                                        <td style="background-color: #3399FF; color: Navy;" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btnEPersonal"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEPersonal', 'ctl00_ContentPlaceHolder1_btnEPersonal');" />
                                            <asp:Label ID="lblehtpersonalinformation" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divEPersonal" runat="server" style="display: none;">
                                    <table class="tableIsys" width="90%">
                                        <%--Newly--%>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%;">
                                                <asp:Label ID="lblehcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblecndno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblehcategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblehcategory" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%;">
                                                <asp:Label ID="lblehappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lbleappno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblehregdatetitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lbleregdate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblehgivennametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblegivenname" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblehsurnametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblesurname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--Personal Information End--%>
                                </div>
                                <table class="formtable" style="width: 100%">
                                    <tr style="background-color: #0055A0">
                                        <td colspan="4" align="left">
                                            <input runat="server" type="button" visible="false" class="standardlink" value="+"
                                                id="btnEmploymentHist" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divEmploymentHist', 'ctl00_ContentPlaceHolder1_btnEmploymentHist');" />
                                            <asp:Label ID="lblehEmpHistory" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divEmploymentHist" runat="server" style="display: block" width="100%;">
                                    <table class="tableIsys" width="100%">
                                        <tr>
                                            <td class="formcontent" colspan="4" align="left">
                                                <asp:Label ID="lblehbeginning" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--Working--%>
                                        <tr>
                                            <td align="left" class="formcontent" colspan="4">
                                                <table class="tableIsys" width="100%">
                                                    <tr class="test">
                                                        <td align="center" style="width: 100px;">
                                                            <asp:Label ID="lblehfrom" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 100px;">
                                                            <asp:Label ID="lblehto" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 94px;">
                                                            <asp:Label ID="lblehname" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 94px;">
                                                            <asp:Label ID="lblehaddofemp" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 94px;">
                                                            <asp:Label ID="lbllehastposition" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 94px;">
                                                            <asp:Label ID="lblehannincome" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 94px;">
                                                            <asp:Label ID="lblehresforleave" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom1" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="139" />--%>
                                                            <asp:TextBox ID="txtfrom1" runat="server" CssClass="standardtextbox" Width="80" TabIndex="212" />
                                                            <asp:Image ID="btnfrom1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimg1cal" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="213"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtfrom1"
                                                                PopupButtonID="btnfrom1" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR6" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom1" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtfrom1"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto1" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="140"/>--%>
                                                            <asp:TextBox ID="txtto1" runat="server" CssClass="standardtextbox" Width="80" TabIndex="214" />
                                                            <asp:Image ID="btntxtto1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto1" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="215"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtto1"
                                                                PopupButtonID="btntxtto1" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR7" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto1" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtto1"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="216"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender111" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName1">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtaddofemp1" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="217"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtEmpLvl1" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="218"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender411" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl1">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtLastIncome1" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="219"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender911" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome1" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtreasforleave1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="220"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave1">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom2" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="146"/>--%>
                                                            <asp:TextBox ID="txtfrom2" runat="server" CssClass="standardtextbox" Width="80" TabIndex="221" />
                                                            <asp:Image ID="imgtxtfrom2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtfrom2" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="222"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtfrom2"
                                                                PopupButtonID="txtimgtxtfrom2" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto1" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR8" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom2" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtfrom2"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto2" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="147"/>--%>
                                                            <asp:TextBox ID="txtto2" runat="server" CssClass="standardtextbox" Width="80" TabIndex="223" />
                                                            <asp:Image ID="imgtxtto2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto2" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="224"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtto2"
                                                                PopupButtonID="txtimgtxtfrom2" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR9" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto2" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtto2"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName2" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="225"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName2">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtaddofemp2" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="226"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtEmpLvl2" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="227"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl2">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtLastIncome2" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="228"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome2" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtreasforleave2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="229"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave2">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom3" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="153"/>--%>
                                                            <asp:TextBox ID="txtfrom3" runat="server" CssClass="standardtextbox" Width="80" TabIndex="230" />
                                                            <asp:Image ID="imgtxtfrom3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtfrom3" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="231"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtfrom3"
                                                                PopupButtonID="imgtxtfrom3" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR10" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom3" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtfrom3"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto3" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="154"/>--%>
                                                            <asp:TextBox ID="txtto3" runat="server" CssClass="standardtextbox" Width="80" TabIndex="232" />
                                                            <asp:Image ID="imgtxtto3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto3" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="233"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtimgtxtto3"
                                                                PopupButtonID="imgtxtto3" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto3" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR11" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto3" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtto3"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName3" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="234"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName3">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtaddofemp3" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="235"></asp:TextBox>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtEmpLvl3" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="236"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl3">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtLastIncome3" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="237"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome3" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td align="left" class="formcontent">
                                                            <asp:TextBox ID="txtreasforleave3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="238"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave3">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom4" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="160"/>--%>
                                                            <asp:TextBox ID="txtfrom4" runat="server" CssClass="standardtextbox" Width="80" TabIndex="239" />
                                                            <asp:Image ID="imgtxtfrom4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtfrom4" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="240"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtimgtxtfrom4"
                                                                PopupButtonID="imgtxtfrom4" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR12" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom4" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txtfrom4"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto4" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="161"/>--%>
                                                            <asp:TextBox ID="txtto4" runat="server" CssClass="standardtextbox" Width="80" TabIndex="241" />
                                                            <asp:Image ID="imgtxtto4" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto4" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="242"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtimgtxtto4"
                                                                PopupButtonID="imgtxtto4" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto4" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR13" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto4" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txtto4"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName4" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="243"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName4">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtaddofemp4" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="244"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtEmpLvl4" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="245"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl4">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtLastIncome4" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="246"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome4" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtreasforleave4" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="247"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave4">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom5" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="167"/>--%>
                                                            <asp:TextBox ID="txtfrom5" runat="server" CssClass="standardtextbox" Width="80" TabIndex="248" />
                                                            <asp:Image ID="imgtxtfrom5" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtfrom5" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="249"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtimgtxtfrom5"
                                                                PopupButtonID="imgtxtfrom5" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR14" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom5" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txtfrom5"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto5" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="168"/>--%>
                                                            <asp:TextBox ID="txtto5" runat="server" CssClass="standardtextbox" Width="80" TabIndex="250" />
                                                            <asp:Image ID="imgtxtto5" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto5" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="251"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender151" runat="server" TargetControlID="txtimgtxtto5"
                                                                PopupButtonID="imgtxtto5" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator151" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom5" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR15" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto5" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator15" runat="server" ControlToValidate="txtfrom5"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName5" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="252"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName5">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtaddofemp5" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="253"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtEmpLvl5" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="254"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl5">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtLastIncome5" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="255"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome5" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtreasforleave5" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="256"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave5">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr5" runat="server" visible="false">
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtfrom6" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="174"/>--%>
                                                            <asp:TextBox ID="txtfrom6" runat="server" CssClass="standardtextbox" Width="80" TabIndex="257" />
                                                            <asp:Image ID="imgtxtfrom6" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtfrom6" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="258"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender161" runat="server" TargetControlID="txtimgtxtfrom6"
                                                                PopupButtonID="imgtxtfrom6" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator161" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtfrom6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR161" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtfrom6" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator1611" runat="server" ControlToValidate="txtfrom6"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <%--<uc7:ctlDate ID="txtto6" runat="server" CssClass="standardtextbox" width="80" 
                                                                    TabIndex="175"/>--%>
                                                            <asp:TextBox ID="txtto6" runat="server" CssClass="standardtextbox" Width="80" TabIndex="259" />
                                                            <asp:Image ID="imgtxtto6" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                            <asp:TextBox ID="txtimgtxtto6" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="260"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender171" runat="server" TargetControlID="txtimgtxtto6"
                                                                PopupButtonID="imgtxtto6" Format="dd/MM/yyyy" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" SetFocusOnError="true"
                                                                ControlToValidate="txtto6" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="COMPAREVALIDATOR17" runat="server" ErrorMessage="Invalid date!"
                                                                Operator="DataTypeCheck" Type="Date" ControlToValidate="txtto6" Display="Dynamic"></asp:CompareValidator>
                                                            <asp:RangeValidator ID="RangeValidator17" runat="server" ControlToValidate="txtto6"
                                                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtPrevEmpName6" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                Style="width: 94%;" TabIndex="261"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtPrevEmpName6">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtaddofemp6" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                                Rows="1" MaxLength="200" Style="width: 95%;" TabIndex="262"></asp:TextBox>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtEmpLvl6" runat="server" CssClass="standardtextbox" Style="width: 95%;"
                                                                MaxLength="50" TabIndex="263"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtEmpLvl6">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtLastIncome6" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                Style="width: 95%;" TabIndex="264"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server"
                                                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                FilterMode="InvalidChars" TargetControlID="txtLastIncome6" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                        <td class="formcontent" align="left">
                                                            <asp:TextBox ID="txtreasforleave6" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                Style="width: 95%;" TabIndex="265"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server"
                                                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtreasforleave6">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table class="formtable" width="100%">
                                    <%--Sales/Marketing/Financial Services Experience -Start--%>
                                    <tr style="background-color: #0055A0">
                                        <td align="left" colspan="4">
                                            <input runat="server" type="button" visible="false" class="standardlink" value="-"
                                                id="btnSalesExp" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSalesExp', 'ctl00_ContentPlaceHolder1_btnSalesExp');" />
                                            <asp:Label ID="lblehexperience" runat="server" Style="padding-left: 20px" ForeColor="White"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divSalesExp" runat="server" style="display: block" width="100%;">
                                    <table class="tableIsys" width="100%">
                                        <tr>
                                            <td class="formcontent" align="left" colspan="6" style="width: 100%;">
                                                <table>
                                                    <tr>
                                                        <td class="formcontent" align="right" style="width: 90%;">
                                                            <span style="color: Red;">
                                                                <asp:Label ID="lblehhaveyou" runat="server" Font-Bold="False" Style="color: Black;"></asp:Label>*</span>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 10%;">
                                                            <asp:UpdatePanel ID="updrbotherexp" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RadioButtonList ID="rbotherexp" runat="server" CssClass="radiobtn"
                                                                        RepeatDirection="Horizontal" TabIndex="266" AutoPostBack="true" OnSelectedIndexChanged="rbotherexp_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="4">
                                                <table class="tableIsys" width="100%">
                                                    <tr class="test">
                                                        <td align="center" style="width: 160px;">
                                                            <asp:Label ID="lblehcompanyname" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 160px;">
                                                            <asp:Label ID="lblehcnfrom" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 90px;">
                                                            <asp:Label ID="lblehcnto" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 90px;">
                                                            <asp:Label ID="lblehcnjobnature" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="center" style="width: 90px;">
                                                            <asp:Label ID="lblehcnfield" runat="server" ForeColor="Navy" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtemprecordname1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordname1" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                        TabIndex="267"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender46" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname1">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpfrom1" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtotherexpfrom1" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="183"/>--%>
                                                                    <asp:TextBox ID="txtotherexpfrom1" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="268" />
                                                                    <asp:Image ID="imgtxtotherexpfrom1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpfrom1" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender181" runat="server" TargetControlID="txtotherexpfrom1"
                                                                        PopupButtonID="imgtxtotherexpfrom1" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator181" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpfrom1" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR181" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom1" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator141" runat="server" ControlToValidate="txtotherexpfrom1"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpTo1" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtotherexpTo1" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="184"/>--%>
                                                                    <asp:TextBox ID="txtotherexpTo1" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="269" />
                                                                    <asp:Image ID="imgtxtotherexpTo1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpTo1" runat="server" CssClass="standardtextbox"
                                                                        TabIndex="270" Style="display: none"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtotherexpTo1"
                                                                        PopupButtonID="imgtxtotherexpTo1" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpTo1" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR16" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo1" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator151" runat="server" ControlToValidate="txtotherexpTo1"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordjobnature1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordjobnature1" runat="server" CssClass="standardtextbox"
                                                                        MaxLength="30" TabIndex="271"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender47" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature1">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordfield1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordfield1" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                        TabIndex="272"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender48" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield1">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updemprecordname2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordname2" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                        TabIndex="273"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender49" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname2">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpfrom2" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtotherexpfrom2" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="188"/>--%>
                                                                    <asp:TextBox ID="txtotherexpfrom2" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="274" />
                                                                    <asp:Image ID="imgtxtotherexpfrom2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpfrom2" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none" TabIndex="275"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="txtotherexpfrom2"
                                                                        PopupButtonID="imgtxttxtotherexpfrom2" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpfrom2" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR171" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom2" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator161" runat="server" ControlToValidate="txtotherexpfrom2"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpTo2" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtotherexpTo2" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="189"/>--%>
                                                                    <asp:TextBox ID="txtotherexpTo2" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="276" />
                                                                    <asp:Image ID="imgtxtotherexpTo2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpTo2" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none" TabIndex="277"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="txtotherexpTo2"
                                                                        PopupButtonID="imgtxtotherexpTo2" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator171" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpTo2" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR18" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo2" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator171" runat="server" ControlToValidate="txtotherexpTo2"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordjobnature2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordjobnature2" runat="server" CssClass="standardtextbox"
                                                                        MaxLength="30" TabIndex="278"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender50" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature2">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordfield2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordfield2" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                        TabIndex="279"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender51" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield2">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtemprecordname3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordname3" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                                        TabIndex="280"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender52" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordname3">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpfrom3" runat="server">
                                                                <ContentTemplate>
                                                                    <%--<uc7:ctlDate ID="txtotherexpfrom3" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="193"/>--%>
                                                                    <asp:TextBox ID="txtotherexpfrom3" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="281" />
                                                                    <asp:Image ID="imgtxtotherexpfrom3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpfrom3" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none" TabIndex="282"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="txtotherexpfrom3"
                                                                        PopupButtonID="imgtxtotherexpfrom3" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpfrom3" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR19" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpfrom3" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="txtotherexpfrom3"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 20%">
                                                            <asp:UpdatePanel ID="updtxtotherexpTo3" runat="server">
                                                                <ContentTemplate>
                                                                    <%-- <uc7:ctlDate ID="txtotherexpTo3" runat="server" CssClass="standardtextbox" 
                                                                width="80" TabIndex="194"/>--%>
                                                                    <asp:TextBox ID="txtotherexpTo3" runat="server" CssClass="standardtextbox" Width="80"
                                                                        TabIndex="283" />
                                                                    <asp:Image ID="imgtxtotherexpTo3" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                                    <asp:TextBox ID="txtimgtxtotherexpTo3" runat="server" CssClass="standardtextbox"
                                                                        Style="display: none" TabIndex="284"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txtotherexpTo3"
                                                                        PopupButtonID="imgtxtotherexpTo3" Format="dd/MM/yyyy" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" SetFocusOnError="true"
                                                                        ControlToValidate="txtotherexpTo3" Enabled="false" ErrorMessage="Mandatory!"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="COMPAREVALIDATOR20" runat="server" ErrorMessage="Invalid date!"
                                                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="txtotherexpTo3" Display="Dynamic"></asp:CompareValidator>
                                                                    <asp:RangeValidator ID="RangeValidator19" runat="server" ControlToValidate="txtotherexpTo3"
                                                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordjobnature3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordjobnature3" runat="server" CssClass="standardtextbox"
                                                                        MaxLength="30" TabIndex="285"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender53" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordjobnature3">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 15%">
                                                            <asp:UpdatePanel ID="updtxtemprecordfield3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtemprecordfield3" runat="server" CssClass="standardtextbox" MaxLength="30"
                                                                        TabIndex="286"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender54" runat="server"
                                                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtemprecordfield3">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table class="formtable" width="100%">
                                    <tr style="background-color: #0055A0">
                                        <td align="left" colspan="4">
                                            <input runat="server" type="button" visible="false" class="standardlink" value="-"
                                                id="btnInsuranceAgency" style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divInsuranceAgency', 'ctl00_ContentPlaceHolder1_btnInsuranceAgency');" />
                                            <asp:Label ID="lblehdetofinsagcy" Style="padding-left: 20px" ForeColor="White" runat="server"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divInsuranceAgency" runat="server" style="display: none" width="100%;">
                                    <table class="tableIsys" width="100%">
                                        <tr>
                                            <td class="formcontent" colspan="4">
                                                <table width="90%">
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 90%;">
                                                            <span style="color: Red;">
                                                                <asp:Label ID="lblehgerlifeinscompy" runat="server" Font-Bold="False" Style="color: Black;"></asp:Label>*</span>
                                                        </td>
                                                        <td class="formcontent" align="left" style="width: 10%;">
                                                            <asp:UpdatePanel ID="UpdPanelrbagnex" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RadioButtonList ID="rbinsagency" runat="server" CssClass="radiobtn" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="rdagnexp_SelectedIndexChanged" RepeatDirection="Horizontal"
                                                                        TabIndex="287">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblehnameofcomp" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:UpdatePanel ID="upinscompname" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtInsCompName" runat="server" CssClass="standardtextbox" MaxLength="50"
                                                            Width="152px" TabIndex="288"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender55" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtInsCompName">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblehlicno" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:UpdatePanel ID="upLcnNo" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtLcnNo" runat="server" CssClass="standardtextbox" MaxLength="22"
                                                            Width="152px" TabIndex="289"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender56" runat="server"
                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                            FilterMode="InvalidChars" TargetControlID="txtLcnNo" FilterType="Custom">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblehdateofissue" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:UpdatePanel ID="updateofissue" runat="server">
                                                    <ContentTemplate>
                                                        <%--<uc7:ctlDate ID="txtdateofissue" runat="server" CssClass="standardtextbox" 
                                                            TabIndex="200" />--%>
                                                        <asp:TextBox ID="txtdateofissue" runat="server" CssClass="standardtextbox" Width="152"
                                                            TabIndex="290" />
                                                        <asp:Image ID="imgtxtdateofissue" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <asp:TextBox ID="txtimgtxtdateofissue" runat="server" CssClass="standardtextbox"
                                                            Style="display: none" TabIndex="291"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txtdateofissue"
                                                            PopupButtonID="imgtxtdateofissue" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" SetFocusOnError="true"
                                                            ControlToValidate="txtdateofissue" Enabled="false" ErrorMessage="Mandatory!"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="COMPAREVALIDATOR21" runat="server" ErrorMessage="Invalid date!"
                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtdateofissue" Display="Dynamic"></asp:CompareValidator>
                                                        <asp:RangeValidator ID="RangeValidator20" runat="server" ControlToValidate="txtdateofissue"
                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblehvaliddate" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:UpdatePanel ID="upvaliddate" runat="server">
                                                    <ContentTemplate>
                                                        <%--<uc7:ctlDate ID="txtvaliddate" runat="server" CssClass="standardtextbox" 
                                                             TabIndex="201" />--%>
                                                        <asp:TextBox ID="txtvaliddate" runat="server" CssClass="standardtextbox" Width="152"
                                                            TabIndex="292" />
                                                        <asp:Image ID="imgtxtvaliddate" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <asp:TextBox ID="txtimgtxtvaliddate" runat="server" CssClass="standardtextbox" Style="display: none" TabIndex="293"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender21" runat="server" TargetControlID="txtvaliddate"
                                                            PopupButtonID="imgtxtvaliddate" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" SetFocusOnError="true"
                                                            ControlToValidate="txtvaliddate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="COMPAREVALIDATOR22" runat="server" ErrorMessage="Invalid date!"
                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtvaliddate" Display="Dynamic"></asp:CompareValidator>
                                                        <asp:RangeValidator ID="RangeValidator21" runat="server" ControlToValidate="txtvaliddate"
                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblehagencycode" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%;">
                                                <asp:UpdatePanel ID="upagtcode" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtInsAgencyCode" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                            Width="152px" TabIndex="294"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender57" runat="server"
                                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                            FilterMode="InvalidChars" TargetControlID="txtInsAgencyCode" FilterType="Custom">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%;">
                                                <asp:Label ID="lblehterminationdate" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%;">
                                                <asp:UpdatePanel ID="upterminatedate" runat="server">
                                                    <ContentTemplate>
                                                        <%--<uc7:ctlDate ID="txtterminatedate" runat="server" CssClass="standardtextbox" 
                                                             TabIndex="203" />--%>
                                                        <asp:TextBox ID="txtterminatedate" runat="server" CssClass="standardtextbox" Width="152"
                                                            TabIndex="294" />
                                                        <asp:Image ID="imgtxtterminatedate" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        <asp:TextBox ID="txtimgtxtterminatedate" runat="server" CssClass="standardtextbox"
                                                            Style="display: none" TabIndex="295"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txtterminatedate"
                                                            PopupButtonID="imgtxtterminatedate" Format="dd/MM/yyyy" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" SetFocusOnError="true"
                                                            ControlToValidate="txtterminatedate" Enabled="false" ErrorMessage="Mandatory!"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="COMPAREVALIDATOR23" runat="server" ErrorMessage="Invalid date!"
                                                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtterminatedate" Display="Dynamic"></asp:CompareValidator>
                                                        <asp:RangeValidator ID="RangeValidator22" runat="server" ControlToValidate="txtterminatedate"
                                                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblehterreason" runat="server" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" colspan="3">
                                                <asp:UpdatePanel ID="upTermination" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtTerminationReason" runat="server" CssClass="standardtextbox"
                                                            MaxLength="30" Width="152px" TabIndex="296"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender58" runat="server"
                                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtTerminationReason">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <%--Sales/Marketing/Financial Services Experience -End--%>
                                        <%--Employee history End--%>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

                <table class="formtable" style="width: 90%; display: none;">
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="standardlink" value="+" id="btnView4"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView4', 'ctl00_ContentPlaceHolder1_btnView4');" />
                            <asp:Label ID="Label141" Text="Disciplinary Information" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="divView4" runat="server" style="display: none; width: 90%;">
                    <table id="Table3" runat="server" class="container" style="width: 100%">
                        <tr>
                            <td style="width: 791px" align="center">
                                <%--Personal Information--%>
                                <table class="formtable" style="display: none">
                                    <tr>
                                        <td class="test" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btnDPersonal"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivDPersonal', 'ctl00_ContentPlaceHolder1_btnDPersonal');" />
                                            <asp:Label ID="lblpersonalinformation" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="DivDPersonal" runat="server" style="display: none;">
                                    <table class="tableIsys">
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%;">
                                                <asp:Label ID="lbldicndidtitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblpcndno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lbldicategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 501px;">
                                                <asp:Label ID="lbldicategory" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lbldiappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblpappno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lbldiregdatetitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblpregdate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lbldigivennametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblpgivenname" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lbldisurnametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblpSurname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Personal Information End--%>
                                <%--Disciplinary Information Start--%>
                                <table class="formtable" style="display: none;">
                                    <tr>
                                        <td class="test" align="left" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btnDisciplinaryInfo"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divDisciplinaryInfo', 'ctl00_ContentPlaceHolder1_btnDisciplinaryInfo');" />
                                            <asp:Label ID="lbldidisinformation" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divDisciplinaryInfo" runat="server" style="display: none;">
                                    <table class="tableIsys">
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <asp:Label ID="lbldihybconvicted" runat="server" Font-Bold="False"></asp:Label><span
                                                    style="color: #ff0000">*</span>
                                            </td>
                                            <td class="formcontent" align="left">
                                                <asp:RadioButtonList ID="rbQstn01" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                    TabIndex="297">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <span style="color: red">
                                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lbldihybsubject" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" align="left">
                                                <asp:RadioButtonList ID="rbQstn02" runat="server" CssClass="radiobtn"
                                                    RepeatDirection="Horizontal" TabIndex="298">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <span style="color: red">
                                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lbldihybjudgement" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" align="left">
                                                <asp:RadioButtonList ID="rbQstn03" runat="server" CssClass="radiobtn"
                                                    RepeatDirection="Horizontal" TabIndex="299">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <span style="color: red">
                                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lbldihybinsolv" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <td class="formcontent" align="left">
                                                <asp:RadioButtonList ID="rbQstn04" runat="server" CssClass="radiobtn"
                                                    RepeatDirection="Horizontal" TabIndex="300">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table class="formtable" style="display: none;">
                                    <tr>
                                        <td class="test" align="left" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="+" id="btnReferences"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divReferences', 'ctl00_ContentPlaceHolder1_btnReferences');" />
                                            <asp:Label ID="lbldireference" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divReferences" runat="server" style="display: block;">
                                    <table class="tableIsys">
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lblditrefname1" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef1Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                    TabIndex="301"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender59" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Name">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiref1address" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef1Add1" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="302"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef1state" runat="server"></asp:Label><span style="color: #ff0000"></span>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtStateCodeR1" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    Width="50px" MaxLength="3" TabIndex="303"></asp:TextBox>
                                                <asp:TextBox ID="txtStateDescR1" runat="server" CssClass="standardtextbox" Enabled="False"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="304"></asp:TextBox>
                                                <asp:Button ID="btnStateR1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                    Text="..." TabIndex="305" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="Label41" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef1Add2" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="306"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef1Add2">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef1Pincode" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef1Pin" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="6" Width="163px" TabIndex="307"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender74" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtRef1Pin" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="Label43" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef1Add3" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="308"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef1country" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtCountryCodeR1" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    Width="50px" MaxLength="3" TabIndex="309"></asp:TextBox>
                                                <asp:TextBox ID="txtCountryDescR1" runat="server" CssClass="standardtextbox" Enabled="False"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="310"></asp:TextBox>
                                                <asp:Button ID="btnCountryR1" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                    Text="..." TabIndex="311" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRefname2" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef2Name" runat="server" CssClass="standardtextbox" MaxLength="60"
                                                    TabIndex="312"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender61" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtRef2Name">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef2Add" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef2Add1" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="313"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef2State" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtStateCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    Width="50px" MaxLength="3" TabIndex="314"></asp:TextBox>
                                                <asp:TextBox ID="txtStateDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="315"></asp:TextBox>
                                                <asp:Button ID="btnStateR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                    Text="..." TabIndex="316" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="Label62" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef2Add2" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="317"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef2Pincode" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef2Pin" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="10" Width="163px" TabIndex="318"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender62" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtRef2Pin" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="Label63" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtRef2Add3" runat="server" CssClass="standardtextbox" Font-Bold="False"
                                                    MaxLength="30" TabIndex="319"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                <asp:Label ID="lbldiRef2Country" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" nowrap="nowrap" style="width: 30%;">
                                                <asp:TextBox ID="txtCountryCodeR2" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    Width="50px" MaxLength="3" TabIndex="320"></asp:TextBox>
                                                <asp:TextBox ID="txtCountryDescR2" runat="server" CssClass="standardtextbox" Enabled="False"
                                                    onChange="javascript:this.value=this.value.toUpperCase();" Width="86px" TabIndex="321"></asp:TextBox>
                                                <asp:Button ID="btnCountryR2" runat="server" CssClass="standardbutton" CausesValidation="False"
                                                    Text="..." TabIndex="322" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Disciplinary Information End--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <table style="width: 90%; display: none;">
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="standardlink" value="+" id="btnView5"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divView5', 'ctl00_ContentPlaceHolder1_btnView5');" />
                            <asp:Label ID="Label15" Text="Business Plan" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="divView5" runat="server" style="display: none; width: 90%;">
                    <table id="Table2" runat="server" class="container" style="width: 100%">
                        <tr>
                            <td style="width: 791px" align="center">
                                <table class="formtable" style="display: none">
                                    <tr>
                                        <td class="test" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btnBPersonal"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBPersonal', 'ctl00_ContentPlaceHolder1_btnBPersonal');" />
                                            <asp:Label ID="lblbppersinftitle" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divBPersonal" runat="server" style="display: none;">
                                    <table class="tableIsys">
                                        <%--Newly--%>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%;">
                                                <asp:Label ID="lblbpcndnotitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblbcndno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblbpcategorytitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 501px;">
                                                <asp:Label ID="lblbpcategory" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblbpappnotitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblbappno" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblbpregdatetitle" runat="server" CssClass="control-label"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblbregdate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblbpgivennametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblbgivenname" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblbpsurnametitle" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblbSurname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Three years biz plan Start--%>
                                <table class="formtable" style="display: none;">
                                    <tr>
                                        <td class="test" colspan="4">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btnBusinessPlan"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBusinessPlan', 'ctl00_ContentPlaceHolder1_btnBusinessPlan');" />
                                            <asp:Label ID="lblbpEmpHistory1" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divBusinessPlan" runat="server" style="display: block;">
                                    <table class="tableIsys">
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblbptyear" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lbltnooflives" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lbltsumassured" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:Label ID="lbltfirstyearpremium" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblbpyear1" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannooflives11" runat="server" CssClass="standardtextbox"
                                                    MaxLength="4" Style="text-align: right" TabIndex="323" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender63" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives11" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:TextBox ID="txtbusinessplansumassured11" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="324" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplansumassured11" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannfirstyearpremium11" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="325" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender65" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium11"
                                                    FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblbpyear2" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannooflives21" runat="server" CssClass="standardtextbox"
                                                    MaxLength="4" Style="text-align: right" TabIndex="326" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender66" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives21" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:TextBox ID="txtbusinessplannsumassured21" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="327" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender67" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured21" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannfirstyearpremium21" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="328" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender68" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium21"
                                                    FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:Label ID="lblbpyear3" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannooflives31" runat="server" CssClass="standardtextbox"
                                                    MaxLength="4" Style="text-align: right" TabIndex="329" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender69" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannooflives31" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 20%">
                                                <asp:TextBox ID="txtbusinessplannsumassured31" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="330" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender70" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannsumassured31" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td class="formcontent" align="left" style="width: 30%">
                                                <asp:TextBox ID="txtbusinessplannfirstyearpremium31" runat="server" CssClass="standardtextbox"
                                                    MaxLength="9" Style="text-align: right" TabIndex="331" Width="50%"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender71" runat="server"
                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                    FilterMode="InvalidChars" TargetControlID="txtbusinessplannfirstyearpremium31"
                                                    FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <span style="color: red">
                                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                                    <asp:Label ID="lblbpwillingtowork" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>*</span>
                                                <%-- <span style="color: #ff0000">*</span>--%>
                                            </td>
                                            <%--<td align="left" class="formcontent">
                                           </div>   --%>
                                            <td align="left" class="formcontent">
                                                <asp:RadioButtonList ID="rbtimework" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                    TabIndex="332">
                                                    <asp:ListItem Value="0">Full Time</asp:ListItem>
                                                    <asp:ListItem Value="1">Part Time</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" colspan="4" style="height: 18px">
                                                <asp:Label ID="lblbpanyotherinformation" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" colspan="4">
                                                <asp:TextBox ID="txtpastachievement" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                                    Width="773px" MaxLength="100" Rows="3" TabIndex="333"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender72" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtpastachievement">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left" colspan="3">
                                                <span style="color: red">
                                                    <asp:Label ID="lblbpareyourelated" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>*</span>
                                            </td>
                                            <td class="formcontent" align="left">
                                                <asp:RadioButtonList ID="rbrelatedemp" runat="server" CssClass="radiobtn"
                                                    RepeatDirection="Horizontal" TabIndex="334">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" align="left">
                                                <asp:Label ID="lblbpifyes" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" align="left" colspan="3">
                                                <asp:TextBox ID="txtrelativeworkdesc" runat="server" CssClass="standardtextbox" Width="575px"
                                                    MaxLength="50" Height="31px" TabIndex="335"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender73" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtrelativeworkdesc">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Three years biz plan End--%>
                                <%--added by Rachana on 17/05/2013 for Interview Details --%>
                                <%--<table  id="tblint" runat="server" class="formtable2"> 
                                           <tr>
                                             <td class="test" colspan="4" >
                                                 <asp:Label ID="lblInt" runat="server" Text="Interview Details" CssClass="standardtextbox1"></asp:Label>
                                           </div>   
                                         </tr>
                                         <tr>
                                               <td class="formcontent" nowrap="nowrap">
                                                   <asp:Label ID="lblCndNo" Text="Candidate No."  runat="server" ></asp:Label>
                                             </div>   
                                               <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateid" runat="server" ></asp:Label>
                                              </div>   
                                           </tr>
                                           <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblCndName" Text="Candidate Name" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" width="100%" colspan="3">
                        
                                                    <asp:Label ID="lblCandidateName" runat="server" ></asp:Label>     
                                               </div>   
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInterviewerName" Text="Interviewer Name" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" >
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerName" runat="server" 
                                                        Width="209px"></asp:TextBox>
                         
                                              </div>   
                                                <td class="formcontent" ><asp:Label ID="lblDate" Text="Date of Interview" runat="server" ></asp:Label>
                                              </div>   
                                                 <td class="formcontent" >
                                                    <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="standardtextbox" 
                                                                RequiredField="false" RequiredValidationMessage="Mandatory!" Width="100" />
                     
                                                </div>   
                                             </tr>
                                             <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInterviewerComment" runat="server" ></asp:Label>
                                              </div>   
                                                <td class="formcontent" width="100%"  colspan="3">
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtInterviewerComment" 
                                                        runat="server" Height="115px" TextMode="MultiLine" Width="427px"></asp:TextBox>
                                              </div>   
                                            </tr>
                                      </table>--%>
                                <%--End Interview Details--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- </div>--%>

                <%--    profiling -------start--------------%>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div14" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','btndiv3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblBusiPln" runat="server" Text="Business Plan" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btndiv3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div3" runat="server" style="display: block;" class="panel-body">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblagntype" runat="server" CssClass="control-label"
                                    Font-Bold="False" Text="Type of agent"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updangtype" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlagntype" runat="server" AutoPostBack="true"
                                            CssClass="form-control" OnSelectedIndexChanged="ddlagntype_SelectedIndexChanged" TabIndex="336">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Others" runat="server" CssClass="control-label"
                                    Font-Bold="False" Text="From others please specify"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updOthers" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtOthers" runat="server" CssClass="form-control"
                                            Enabled="false" MaxLength="30"
                                            onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="337"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                            runat="server" FilterMode="InvalidChars" FilterType="Custom"
                                            InvalidChars="/.\?&lt;&gt;{}[];:|=+_-,#$@%^!*()&amp;''%^~ `0123456789"
                                            TargetControlID="txtOthers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="Label4" runat="server" CssClass="control-label" Font-Bold="False" Text="Is he working with some other Group company"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updIsWrkng">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlIsWrkng" runat="server" AutoPostBack="true" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlIsWrkng_SelectedIndexChanged" TabIndex="338">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Y"> </asp:ListItem>
                                            <asp:ListItem Text="No" Value="N"> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblcompName" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="If yes, company name"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updcompName">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlcompName" runat="server" CssClass="form-control"
                                            TabIndex="339" Enabled="false">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblNoOfYrsInsurance" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="No. of years in insurance"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updNoOfYrsIns">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNoOfYrsIns" runat="server" CssClass="form-control"
                                            TabIndex="340">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblNoOfYrs" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="No. of years with company"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updNoOfYrs">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNoOfYrs" runat="server" CssClass="form-control"
                                            TabIndex="341">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblTypeOfVehicle" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="If Dealer, type of vehicle dealing in"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updTypeOfvehicle">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTypeOfVehicle" runat="server" CssClass="form-control"
                                            TabIndex="342">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblVchlManf" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="If Dealer, vehicle manufacturer dealing with"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updVechManuf">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlVechManuf" runat="server" CssClass="form-control"
                                            TabIndex="343">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblDlrCompName" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="Company  Name"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updDlrCompName">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDlrCompName" runat="server" Enabled="false" CssClass="form-control"
                                            onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30"
                                            TabIndex="344"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                            TargetControlID="txtDlrCompName" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDlrOth" runat="server" CssClass="control-label" Font-Bold="False" Text="From others please specify"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updDlrOth">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDlrOth" runat="server" Enabled="false" CssClass="form-control"
                                            onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="30"
                                            TabIndex="345"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                            InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `0123456789" FilterMode="InvalidChars"
                                            TargetControlID="txtDlrOth" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div15" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpotentail','btnpotential');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label13" runat="server" Text="Potential of agent" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnpotential" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divpotentail" runat="server" style="display: block;" class="panel-body">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="Label14" runat="server" CssClass="control-label" Font-Bold="False" Text="Avg. monthly volume in Lacs"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updAvgMonthlyIncm">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAvgMonthlyIncm" runat="server" CssClass="form-control"
                                            TabIndex="346">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                            </div>
                            <div class="col-sm-3">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div16" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompetitor','btnCompetitor');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label20" runat="server" Text="Competitor company working with" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnCompetitor" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divCompetitor" style="display: block;" runat="server" class="panel-body">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblComp1Name" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="Company 1 name"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updComp1Name">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlComp1Name" runat="server" CssClass="form-control"
                                            TabIndex="347">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblMnthVol1" runat="server" CssClass="control-label"
                                    Text="Monthly volume in Lacs"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updMnthVol1">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMnthVol1" runat="server" CssClass="form-control"
                                            TabIndex="348">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblComp2Name" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="Company 2 name"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updComp2Name">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlComp2Name" runat="server" CssClass="form-control"
                                            TabIndex="349">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMnthVol2" runat="server" CssClass="control-label"
                                    Text="Monthly volume in Lacs"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updMnthVol2">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMnthVol2" runat="server" CssClass="form-control"
                                            TabIndex="350">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel" style="margin-left: 0px; margin-right: 0px">
                    <div id="Div17" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRGI','btnRGI');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label21" runat="server" Text="Business volume with Group Company" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnRGI" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divRGI" runat="server" style="display: block;" class="panel-body">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">

                                <asp:Label ID="lblRGIMnthVol" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="Monthly volume in Lacs"></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="updRGIMnthVol">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRGIMnthVol" runat="server" CssClass="form-control"
                                            TabIndex="351">
                                            <asp:ListItem Text="Select" Value=""> </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                            </div>
                            <div class="col-sm-3">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel" style="margin-left: 0px; margin-right: 0px; display: none;">
                    <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProduct','btnProduct');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblPrdMxAgn" runat="server" Text="Product mix of agent" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">
                                <span id="btnProduct" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                        <%-- panel-body panel-collapse collapse in  --%>               <%--panel-heading subheader--%>
                    </div>
                    <div id="divProduct" style="display: block;" runat="server" class="panel-body">

                        <div id="div20">
                            <div class="panel" style="margin-left: 0px; margin-right: 0px">
                                <div id="Div19" runat="server" class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTotalbuisness','btnTotalbuisness');return false;"
                                    style="background-color: #ffffff !important">
                                    <div class="row">
                                        <div class="col-sm-9" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                            <asp:Label ID="Label22" runat="server" Text="Total Business" CssClass="control-label" class="subheader"></asp:Label>

                                        </div>
                                        <div class="col-sm-3">
                                            <span id="btnTotalbuisness" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divTotalbuisness" style="display: block;" runat="server" class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-2" style="text-align: left">

                                            <asp:Label ID="lblTotBsnMtr" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Motor (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updTotBsnMtr" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTotBsnMtr" runat="server" CssClass="form-control"
                                                        TabIndex="352">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-2" style="text-align: left">

                                            <asp:Label ID="lblTotBsnHlth" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Health (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updddlTotBsnHlth" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTotBsnHlth" runat="server" CssClass="form-control"
                                                        TabIndex="353">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-2" style="text-align: left">

                                            <asp:Label ID="lblTotBsnComm" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Commercial line (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updddlTotBsnComm" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTotBsnComm" runat="server" CssClass="form-control"
                                                        TabIndex="354">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel" style="margin-left: 0px; margin-right: 0px">
                                <div id="Div21" runat="server" class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divBuisnessRGI','btnBuisnessRGI');return false;"
                                    style="background-color: #ffffff !important">
                                    <div class="row">
                                        <div class="col-sm-9" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                            <asp:Label ID="Label23" runat="server" Text="Business with Group Company" class="subheader" CssClass="control-label"></asp:Label>

                                        </div>
                                        <div class="col-sm-3">
                                            <span id="btnBuisnessRGI" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divBuisnessRGI" style="display: block;" runat="server" class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-2" style="text-align: left">

                                            <asp:Label ID="lblRGIBsnMtr" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Motor (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updRGIBsnMtr" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlRGIBsnMtr" runat="server" CssClass="form-control"
                                                        TabIndex="355">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-2" style="text-align: left">
                                            <asp:Label ID="lblRGIBsnHlth" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Health (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updddlRGIBsnHlth" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlRGIBsnHlth" runat="server" CssClass="form-control"
                                                        TabIndex="356">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-2" style="text-align: left">

                                            <asp:Label ID="lblRGIBsnComm" runat="server" CssClass="control-label"
                                                Font-Bold="False" Text="Commercial line (in percentage)"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:UpdatePanel ID="updddlRGIBsnComm" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlRGIBsnComm" runat="server" CssClass="form-control"
                                                        TabIndex="357">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--pranjali removed--%>
           
        </asp:View>
    </asp:MultiView>




    <div id="divIRCC" runat="server" style="padding: 1%" role="tabpanel">


        <div class="tab-content">
        </div>

    </div>
    <center>
    
                  

             <div>
              <div class="row" style="margin-top:12px;">
                    <div class="col-sm-12" align="center">
       
                         <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                                OnClick="btnUpdate_Click" TabIndex="358" >
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> 
                        </asp:LinkButton>  
               
                 <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                OnClick="btnCancel_Click" TabIndex="359">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> 
                             </asp:LinkButton> 
                   <div id="divloader" runat="server" style="display:none;">
                                 <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                    </div>
                    </div>
                    </div> 
                    </div>   
    
    
       <input id="hdnID210" type="hidden" runat="server" />
       <input id="hdnID260" type="hidden" runat="server" />
       <input id="hdnID270" type="hidden" runat="server" />
       <input id="hdnID280" type="hidden" runat="server" />
       <input id="hdnID290" type="hidden" runat="server" />
       <input id="hdnID300" type="hidden" runat="server" />
       <input id="hdnID310" type="hidden" runat="server" />
       <input id="hdnID320" type="hidden" runat="server" />
       <input id="hdnID330" type="hidden" runat="server" />
       <input id="hdnID340" type="hidden" runat="server" />
       <input id="hdnID350" type="hidden" runat="server" />
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
       <input id="hdnID540" type="hidden" runat="server" />
       <input id="hdnID550" type="hidden" runat="server" />
       <input id="hdnID560" type="hidden" runat="server" />
       <input id="hdnID570" type="hidden" runat="server" />
       <input id="hdnID580" type="hidden" runat="server" />
       <input id="hdnID590" type="hidden" runat="server" />
       <input id="hdnID600" type="hidden" runat="server" />
       <input id="hdnID610" type="hidden" runat="server" />
       <input id="hdnID620" type="hidden" runat="server" />
                                
       <input id="hdnID630" type="hidden" runat="server" />
       <input id="hdnID640" type="hidden" runat="server" />
       <input id="hdnID650" type="hidden" runat="server" />
       <input id="hdnID660" type="hidden" runat="server" />
       <input id="hdnID670" type="hidden" runat="server" />
                                
       <input id="hdnIsDateValid" type="hidden" runat="server" />
       <input id="hdnDOB" type="hidden" runat="server" />
       <input id="hdnSave" type="hidden" runat="server" />
       <input id="hdnUpdate" type="hidden" runat="server" />
       <input id="hdnAppno" type="hidden" runat="server" />
       <input id="hdSmCode" type="hidden" runat="server" />
       <input id="hdnECCode" type="hidden" runat="server" />
       <input id="hdnBizSrc" type="hidden" runat="server" />
        <asp:HiddenField ID="hdnCndNo" runat="server" />                        
        <asp:HiddenField ID="hdnBtnDis" runat="server" />
             <table>
                  <tr>
                      <td>
                           <asp:UpdatePanel ID="updPnlHidden" runat="server">
                               <contenttemplate>
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <asp:HiddenField ID="hdnPan" runat="server" />
                                    <asp:HiddenField ID="hdnAgentBrokerCode" runat="server" />
                                    <asp:HiddenField ID="hdnUrn" runat="server" />     
                                    <%-- //04...07/09/2012...Miti --%>           
                                    <asp:HiddenField ID="hdnpanedit" runat="server" />
                                     <%--//04...07/09/2012...Miti--%>
                                     <asp:HiddenField ID="hdnEmpCode" runat="server" />
                                </contenttemplate>
                            </asp:UpdatePanel>
                     </td>
                   </tr> 
             </table>
    </center>
    <%-- //05...12/09/2012...Miti--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="428" display="none" top="52" left="529px">
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="539px" frameborder="0" style="margin-top: -100px; margin-left: 107px;"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        X="260" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">



            <div class="modal-content">
                <div class="modal-header" style="text-align: center;">
                    <asp:Label ID="Label16" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px; border-radius: 15px;'>
                        <span class="glyphicon glyphicon-ok  BtnGlyphicon" style='color: White;'></span>OK

                    </button>

                </div>
            </div>



        </div>
    </div>
    <center>
    
    
    
    
   <%-- 
    <asp:Panel ID="pnl" runat="server"  BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" Width="90%" Height="280%">
        <div class="panel #rcorners2" id="divAlert" runat="server" style="width:35%;
                display: none; border: 2px; border-radius: 15px; background-color: white; border: solid; 
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0">

                    
             
       </div>                      
    </asp:Panel>
--%>


<%-- <asp:Panel ID="pnl" runat="server"  
        Width="90%" Height="90%" display=none>
           <div class="panel #rcorners2" id="divAlert" runat="server" style="width:35%;
                display: block; border: 2px; border-radius: 15px; background-color: white; border: solid; display:none;
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0">
                    <div id="Div22" runat="server"   style="width:98%;!important" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div class="row" id="Div23" runat="server">
                                 
                             
                            </div>
                        </div>
     
       
        
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" />
            <br /></center>
            </div>
    </asp:Panel>



   
   <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup"  PopupControlID="pnl"
        OkControlID="btnok" X="40" Y="210">
    </ajaxToolkit:ModalPopupExtender>--%>
    </center>


    <asp:Panel runat="server" ID="Panel2" ScrollBars="Both" Width="600" Height="355" display="none" Style="display: none">
        <iframe runat="server" id="Iframe1" width="100%" frameborder="0"
            display="none" style="height: 100%; background-color: white;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label19" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--//05...12/09/2012...Miti--%>
    <%--For Displaying Information Pop-up End--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <%--background-color: #C0C0C0;--%>
        <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
    </asp:Panel>
</asp:Content>



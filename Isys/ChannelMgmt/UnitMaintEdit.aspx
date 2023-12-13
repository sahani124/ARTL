<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitMaintEdit.aspx.cs" Inherits="INSCL.UnitMaintEdit" MasterPageFile="~/iFrame.master" Title="Unit Maintenance Edit" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
    </script>
    <script type="text/javascript" src="~/Scripts/common.js"></script>
    <script type="text/javascript" src="~/Scripts/subModal.js"></script>
    <script type="text/javascript" src="~/Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>

    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>


    <%--<script type="text/javascript" src="../../../Scripts/UnitMaintScript.js"></script>--%>
    <script language="javascript" src="~/Scripts/jsAgtCheck.js" type="text/javascript"></script>
            <style type="text/css">
  .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
            text-align:left;
        }
    </style>

    <script type="text/javascript">

        function popup() {
            $("#myModal").modal();
        }

        $(function () {
            debugger;

            $("#<%= txtReqDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //                   objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //                 objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }


        var strContent = "ctl00_ContentPlaceHolder1_";
        function funResetUnitMgrInfo() {
            //debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";

            if ("<%=Request.QueryString["ULevel"] %>" == "60.0") //Changed by Kalyani on 17-12-2013 to new unitlevel -old 7
            {
                if (document.getElementById(strContent + "rdlYesNo")) {
                    if (getRadioSelectedValue(document.getElementById(strContent + "rdlYesNo")) == "N") {
                        setRadioSelectedValue(document.getElementById(strContent + "rdlYesNo"), "Y");
                        return funShowAlertWithoutFocus(strContent + "hdnID360");
                    }
                }
                if (document.getElementById(strContent + "txtUnitMGRCode")) {
                    document.getElementById(strContent + "txtUnitMGRCode").disabled = false;
                }
                if ("<%=Request.QueryString["ChannelCode"] %>" == "XX") {
                    if (document.getElementById(strContent + "txtSALocCode") && document.getElementById(strContent + "btnGetDefault")) {
                        document.getElementById(strContent + "txtSALocCode").disabled = false;
                        document.getElementById(strContent + "btnGetDefault").disabled = false;
                    }
                }
                else {
                    if (document.getElementById(strContent + "txtCompanyUnitCode")) {
                        document.getElementById(strContent + "txtCompanyUnitCode").disabled = false;
                    }
                }
            }
            else {
                if (document.getElementById(strContent + "rdlYesNo")) {
                    if (getRadioSelectedValue(document.getElementById(strContent + "rdlYesNo")) == "Y") {
                        if (document.getElementById(strContent + "txtUnitMGRCode")) {
                            document.getElementById(strContent + "txtUnitMGRCode").disabled = false;
                        }
                        if ("<%=Request.QueryString["ChannelCode"] %>" == "XX") {
                         if (document.getElementById(strContent + "txtSALocCode") && document.getElementById(strContent + "btnGetDefault")) {
                             document.getElementById(strContent + "txtSALocCode").disabled = false;
                             document.getElementById(strContent + "btnGetDefault").disabled = false;
                         }
                     }
                     else {
                         if (document.getElementById(strContent + "txtCompanyUnitCode")) {
                             document.getElementById(strContent + "txtCompanyUnitCode").disabled = false;

                         }
                     }
                 }
                 else {
                     if (document.getElementById(strContent + "txtUnitMGRCode")) {
                         document.getElementById(strContent + "txtUnitMGRCode").value = "";
                         document.getElementById(strContent + "txtUnitMGRCode").disabled = true;
                     }

                     if ("<%=Request.QueryString["ChannelCode"] %>" == "XX") {
                         if (document.getElementById(strContent + "txtSALocCode") && document.getElementById(strContent + "btnGetDefault")) {
                             document.getElementById(strContent + "txtSALocCode").value = "";
                             document.getElementById(strContent + "txtSALocCode").disabled = true;
                             document.getElementById(strContent + "btnGetDefault").disabled = true;
                         }
                     }
                     else {
                         if (document.getElementById(strContent + "txtCompanyUnitCode")) {
                             document.getElementById(strContent + "txtCompanyUnitCode").disabled = true;

                         }
                     }
                 }
             }
         }
     }

     function getRadioSelectedValue(radioList) {
         var options = radioList.getElementsByTagName('input');
         for (i = 0; i < options.length; i++) {
             var opt = options[i];
             if (opt.checked) {
                 return opt.value;
             }
         }
     }


     function setRadioSelectedValue(radioList, strVal) {
         var options = radioList.getElementsByTagName('input');
         for (i = 0; i < options.length; i++) {
             var opt = options[i];
             if (opt.value == strVal) {
                 opt.checked = true;
             }
         }
     }

     function funShowAlert(objError, objFocus) {
         alert(document.getElementById(objError).value);
         document.getElementById(objFocus).focus();
         return false;
     }

     function funShowAlertWithoutFocus(objError) {
         alert(document.getElementById(objError).value);
         return false;
     }

     function RetrieveSALocCode() {

         var UnitCode, RptUnitCode, RptUnitLevel;
         if (document.getElementById(strContent + "txtUnitCode")) {
             UnitCode = document.getElementById(strContent + "txtUnitCode").value;
         }
         else if (document.getElementById(strContent + "lblUnitCode")) {
             UnitCode = document.getElementById(strContent + "lblUnitCode").innerText;
         }
         if (document.getElementById(strContent + "ddlReportingUnit")) {
             RptUnitCode = document.getElementById(strContent + "ddlReportingUnit").value;
         }
         RptUnitLevel = parseInt("<%=Request.QueryString["ULevel"] %>") - 10.0; //Changed by kalyani on 17-12-2013 to new unitlevel-old 1

            //if (isEmpty(UnitCode))
            if (UnitCode == null || UnitCode == "") {
                if (document.getElementById(strContent + "txtUnitCode")) {
                    return funShowAlert(strContent + "hdnID220", strContent + "txtUnitCode");
                }
                else if (document.getElementById(strContent + "lblUnitCode")) {
                    return funShowAlertWithoutFocus(strContent + "hdnID220");
                }
            }

            //if (isEmpty(RptUnitCode))
            if (RptUnitCode == null || RptUnitCode == "") {
                return funShowAlert(strContent + "hdnID320", strContent + "ddlReportingUnit");
            }
            else {
                if (document.getElementById(strContent + "txtSALocCode")) {
                    if (RptUnitLevel == 0) {
                        document.getElementById(strContent + "txtSALocCode").value = document.getElementById(strContent + "hdnSALocCode").value;
                    }
                    else if (RptUnitLevel == 1) {
                        document.getElementById(strContent + "txtSALocCode").value = document.getElementById(strContent + "hdnSALocCode").value + UnitCode;
                    }
                    else {
                        document.getElementById(strContent + "txtSALocCode").value = RptUnitCode + UnitCode;
                    }
                }
            }
            return false;
        }

        function doValidateNumbers(src, args) {
            var result = false;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtOTel").getAttribute("value");
            if (str >= 0 || str <= 9) {
                result = true;
                //alert('ok');
            }
            args.IsValid = result;

        }


        function doValidateNumber(src, args) {
            var result = false;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtFax").getAttribute("value");
            if (str >= 0 || str <= 9) {
                result = true;
            }
            args.IsValid = result;
        }

        function doValidateInteger(src, args) {
            var result = false;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtPOstCode").getAttribute("value");
            if (str >= 0 || str <= 9) {
                result = true;
            }
            args.IsValid = result;
        }

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }

        function IsEmail() {
            debugger;
            //var result = $("#result");
            var email = $("#ctl00_ContentPlaceHolder1_txtEMail").val();
            //result.text("");

            if (validateEmail(email)) {
                //result.text(email + " is valid :)");
                //result.css("color", "green");
            } else {
                //$result.text(email + " is not valid :(");
                //$result.css("color", "red");
                alert('Please enter valid EmailId');
                $("#ctl00_ContentPlaceHolder1_txtEMail").focus();

            }
            return false;
        }


        //function IsEmail() {
        //    debugger;
        //    //var sString = args.value;
        //    var result = true;
        //    var sString = document.getElementById("ctl00_ContentPlaceHolder1_txtEMail").value;
        //    if (!chkEmailFormat(sString, 1)) {
        //        result = false;
        //    }
        //    //  args.IsValid = result;

        //}


        function Validations() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "txtPCCode") != null) {
                if (document.getElementById(strContent + "txtPCCode").disabled == false) {
                    var iChars = "!@$^*-_+={}[]()|\:;?><,.'~ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    var sString = document.getElementById(strContent + "txtPCCode").value;

                    for (var i = 0; i < sString.length; i++) {
                        if (iChars.indexOf(sString.charAt(i)) != -1) {
                            alert('Invalid PC Code!');
                            document.getElementById(strContent + "txtPCCode").focus();
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "txtUntDesc1") != null) {
                var iChar = "!@$^*-_+={}[]()|\:;?><,.'~";
                var sString = document.getElementById(strContent + "txtUntDesc1").value;

                for (var i = 0; i < sString.length; i++) {
                    if (iChar.indexOf(sString.charAt(i)) != -1) {
                        alert('Invalid Unit Description!');
                        document.getElementById(strContent + "txtUntDesc1").focus();
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "txtUnitCode") != null) {
                //if(isEmpty(document.getElementById(strContent + "txtUnitCode").value))  Added by swapnesh on 15/5/2013 to remove isBlank function to solve javascript error
                if (document.getElementById(strContent + "txtUnitCode").value == "") {
                    alert("Please Enter UnitCode.");
                    document.getElementById(strContent + "txtUnitCode").focus();
                    return false;
                }
            }

            if (document.getElementById(strContent + "rdlYesNo") != null) {
                if (document.getElementById('<%= rdlYesNo.ClientID %>_0').checked == false && document.getElementById('<%= rdlYesNo.ClientID %>_1').checked == false) {
                    alert("Please Select Sales Unit Option");
                    document.getElementById(strContent + "rdlYesNo").focus();
                    return false;

                    //alert("Please Select Sales Unit Option");
                    //document.getElementById(strContent + "rdlYesNo").focus();
                    return false;
                }
            }



            if (document.getElementById(strContent + "txtUntDesc1") != null) {
                //if(isEmpty(document.getElementById(strContent + "txtUntDesc1").value))  Added by swapnesh on 15/5/2013 to remove isBlank function to solve javascript error
                if (document.getElementById(strContent + "txtUntDesc1").value == "") {
                    alert("Please Enter Unit Description.");
                    document.getElementById(strContent + "txtUntDesc1").focus();
                    return false;
                }
            }

            //added by meena 6_10_18

            //if (document.getElementById(strContent + "txtBranchCode") != null) {
            //    //if(isEmpty(document.getElementById(strContent + "txtUntDesc1").value))  Added by swapnesh on 15/5/2013 to remove isBlank function to solve javascript error
            //    if (document.getElementById(strContent + "txtBranchCode").value == "") {
            //        alert("Please select Sap location.");
            //        document.getElementById(strContent + "txtBranchCode").focus();
            //        return false;
            //    }
            //}
            //added by meena 6_10_18 
            //if (document.getElementById(strContent + "ddlState").selectedIndex == 0) {
            //    alert("Please Select State Code");
            //    document.getElementById(strContent + "ddlState").focus();
            //    // var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
            //    return false;
            //}
            //            if(document.getElementById(strContent + "txtRptUntCode") != null)
            //            {
            //                if(document.getElementById(strContent + "txtRptUntCode").value=="")
            //			    {
            //				    alert("Please Enter Reporting Unit Code.");
            //				    document.getElementById(strContent + "txtRptUntCode").focus();
            //			        return false;
            //			    }
            //            }

            if (document.getElementById(strContent + "txtSMCount") != null) {
                if (document.getElementById(strContent + "txtSMCount").disabled == false) {
                    //if(isEmpty(document.getElementById(strContent + "txtSMCount").value))  Added by swapnesh on 15/5/2013 to remove isBlank function to solve javascript error
                    if (document.getElementById(strContent + "txtSMCount").value == "") {
                        alert("Please Enter SM Count.");
                        document.getElementById(strContent + "txtSMCount").focus();
                        return false;
                    }
                    var iChars = "!@$^*-_+={}[]()|\:;?><,.'~ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    var sString = document.getElementById(strContent + "txtSMCount").value;

                    for (var i = 0; i < sString.length; i++) {
                        if (iChars.indexOf(sString.charAt(i)) != -1) {
                            alert('Invalid SM Count!');
                            document.getElementById(strContent + "txtSMCount").focus();
                            return false;
                        }
                    }
                }
            }
            //             if(document.getElementById(strContent + "hdnPrimMand") != null)
            //            {
            //                if(document.getElementById(strContent + "hdnPrimMand").value != "")
            //                {
            //                    if(document.getElementById(strContent + "hdnPrimMand").value == "True")
            //                    {
            //                        if(document.getElementById("<% =ddlreportingtype.ClientID %>").selectedIndex == 0 ||
            //                            document.getElementById("<% =ddlbasedon.ClientID %>").selectedIndex == 0 ||
            //                            document.getElementById("<% =ddlchannel.ClientID %>").selectedIndex == 0 ||
            //                            document.getElementById("<% =ddlsubchannel.ClientID %>").selectedIndex == 0 ||
            //                            document.getElementById("<% =ddllevelagttype.ClientID %>").selectedIndex == 0 ||
            //                            document.getElementById(strContent + "txtRptUntCode").value == ""
            //                        )                    
            //                        {
            //                            alert("Please Fill Primary Reporting Details");
            //	                        return false;
            //                        }
            //                    }
            //                }
            //            }
            if (document.getElementById(strContent + "hdnAddl1Mand") != null) {
                if (document.getElementById(strContent + "hdnAddl1Mand").value != "") {
                    if (document.getElementById(strContent + "hdnAddl1Mand").value == "True") {
                        if (document.getElementById("<% =ddlam1reportingtype.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlam1basedon.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlam1channel.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlam1subchannel.ClientID %>").selectedIndex == 0 ||
                        document.getElementById("<% =ddlam1levelagttype.ClientID %>").selectedIndex == 0 ||
                            document.getElementById(strContent + "txtRptUnitCodeMgr1").value == ""
                        ) {
                            alert("Please Fill Additional Reporting Manager1 Details");
                            return false;
                        }
                    }
                }
            }

            if (document.getElementById(strContent + "txtEmail") == null) {

                var email = document.getElementById(strContent + "txtEmail").value;
                var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
                if (!filter.test(email.value)) {
                    alert('Please provide a valid email address');
                    email.focus;
                    return false;
                }
                return true;

            }
            //document.getElementById('ivarLoad').style.display='block'
        }



        function funcShowPopup(strPopUpType, strbtnid) {
            debugger;
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
                    + "&field3=" + document.getElementById('<%=txtcityp.ClientID %>').id + "&field4=" + document.getElementById('<%=txtarea.ClientID %>').id +
                    "&field11=" + "" + "&field21=" + "" +
                    "&field31=" + "" + "&field41=" + ""
                    + "&btnid=" + strbtnid + "&mdlpopup=mdlViewBID&";
                // + "&mdlpopup=mdlViewBID";
            }
        }

        if (strPopUpType == "rptunt") {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopRptUnitCode.aspx?Unitdesc=" + document.getElementById('<%=txtRptUntCode.ClientID %>').id
                    + "&UnitCode=" + document.getElementById('<%=lblRptUntCode.ClientID %>').id + "&BizSrc=" + document.getElementById('<%=ddlchannel.ClientID %>').value
                    + "&ChnCls=" + document.getElementById('<%=ddlsubchannel.ClientID %>').value + "&rule=" + document.getElementById('<%=ddlRuleTypePrmry.ClientID %>').value
                    + "&UnitType=" + document.getElementById('<%=ddllevelagttype.ClientID%>').value + "&RptUntCode=" + document.getElementById('<%=hdnRptUntCode.ClientID%>').id
                    + "&flag=P" + "&unttyp=" + document.getElementById('<%=ddlUnitType.ClientID%>').value
                    + "&ddl=" + document.getElementById('<%=ddllevelagttype.ClientID %>').id
                    + "&ddlsch=" + document.getElementById('<%=ddlsubchannel.ClientID %>').id
                    + "&scls=" + document.getElementById('<%=ddlChnnlSubClass.ClientID %>').value + "&cls=" + document.getElementById('<%=hdnChnl.ClientID %>').value
                + "&mdlpopup=mdlViewBID";
        }

        if (strPopUpType == "rptunt1") {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopRptUnitCode.aspx?Unitdesc=" + document.getElementById('<%=txtRptUnitCodeMgr1.ClientID %>').id
                + "&UnitCode=" + document.getElementById('<%=lblRptUntCodeMgr1.ClientID %>').id + "&BizSrc=" + document.getElementById('<%=ddlam1channel.ClientID %>').value
                + "&ChnCls=" + document.getElementById('<%=ddlam1subchannel.ClientID %>').value + "&rule=" + document.getElementById('<%=ddlRuleTypeAddl1.ClientID %>').value
                + "&UnitType=" + document.getElementById('<%=ddlam1levelagttype.ClientID%>').value + "&RptUntCode=" + document.getElementById('<%=hdnRptUntCodeMgr1.ClientID%>').id
                + "&flag=A" + "&unttyp=" + document.getElementById('<%=ddlUnitType.ClientID%>').value
                + "&ddl=" + document.getElementById('<%=ddllevelagttype.ClientID %>').id
                + "&ddlsch=" + document.getElementById('<%=ddlsubchannel.ClientID %>').id
                + "&scls=" + document.getElementById('<%=ddlChnnlSubClass.ClientID %>').value + "&cls=" + document.getElementById('<%=hdnChnl.ClientID %>').value
                    + "&mdlpopup=mdlViewBID";
        }
    }


    function funOpenPopWinForUntCode(strPageName, strUnitCode, strOutUntCode, strOutUntDesc, strSource) {
        showPopWin(strPageName + "?UnitCode=" + strUnitCode + "&OutUntCode=" + strOutUntCode + "&OutUntDesc=" + strOutUntDesc + "&Source=" + strSource, 450, 400, null);
        return false;
    }
    function done() {

        window.location.href = "UnitMaint.aspx";
        return false;
    }


    //Added by usha  for SAP location 
    function openSAPBranchList() {
        debugger;
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../ChannelMgmt/PopSapLocations.aspx?&mdlpopup=mdlViewBID";
    }

    //Ended by usha  for sap location  on 19.09.2018

    </script>

    <style type="text/css">
        .rbl input[type="radio"] {
            margin-left: 10px;
            margin-right: 1px;
        }

        .ajax__calendar {
            position: static;
        }

        .pagelink span {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/


        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<div class="container">--%>
    <center>
                <asp:Label ID="lblmsg" runat="server" Width="430px" Font-Bold="false" ForeColor="Red">
                </asp:Label>

                <div class="panel " id="divcmphdrcollapse" runat="server">
                <div id="Div10" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div2','btndiv2');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>--%>
                     <asp:Label ID="lblUntPart" runat="server" Text="Unit Particular" CssClass="control-label"  Font-Size="19px"  ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
             
          </div>
            <div id="div2" runat="server" class="panel-body" style="display:block"> 
                                   <%-- <tbody>--%>
                                      <%--  <tr>
                                            <td class="test formHeader" align="left" colspan="4">
                                            <asp:Label ID="lblUntPart" runat="server" Text="Unit Particular" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>--%>
                       <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblSalesChnl" CssClass="control-label" runat="server"></asp:Label>
                     </div>
                            <div class="col-md-3">
                                                <asp:TextBox ID="lblSalesChannel"  CssClass="form-control"  runat="server" TabIndex="1"></asp:TextBox>
                                                <input id="txtSalesCCode" runat="server" class="standardtextbox" style="width: 78px;" type="hidden"   />
                           </div>
                   <div class="col-md-3" style="text-align:left">
                                               
                                                <asp:Label ID="lblChnnlSubClass" CssClass="control-label" runat="server" style="color:Black"></asp:Label>
                                                  <span style="font-size: 10pt; color:Red">*</span><%--shreela--%></div>
                      <div class="col-md-3">
                                                <asp:DropDownList ID="ddlChnnlSubClass" runat="server" 
                                                    OnSelectedIndexChanged="ddlChnnlSubClass_SelectedIndexChanged" CssClass="form-control"
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvChnnlSubClass" runat="server" ControlToValidate="ddlChnnlSubClass"
                                                    ErrorMessage="Mandatory!" Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                  </div>
                        </div>
                          <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-3" style="text-align:left">
                                                <%--<asp:Label ID="lblRptUnit" runat="server"></asp:Label>
                                                <span style="font-size: 10pt; color: #ff0000">*</span>--%>
                                              <%--shreela--%>
                                                <asp:Label ID="lblUntCode" runat="server" CssClass="control-label" style="color:Black"></asp:Label>
                                                 <span style="font-size: 10pt; color:Red" id="span2" runat="server">*</span>
                                              
                             </div>
                           <div class="col-md-3">
                                                <asp:TextBox ID="txtUnitCode" runat="server"  CssClass="form-control" 
                                                    Visible="False" Enabled="false" MaxLength="8" TabIndex="3"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtUnitCodeFTX" runat="server"
                                                TargetControlID="txtUnitCode" FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
                                                <%--<asp:RequiredFieldValidator ID="rfvUCode" runat="server" ControlToValidate="txtUnitCode"
                                                    ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%>
                                                <asp:TextBox ID="lblUnitCode" runat="server"  TabIndex="4"  CssClass="form-control" ></asp:TextBox>
                              </div>
                                     <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblrefcode" runat="server" CssClass="control-label" Text="Ins. Ref. Code"></asp:Label>
                                    </div>
                            <div class="col-md-3">
                                                <asp:TextBox ID="txtInsRefCode" runat="server"  CssClass="form-control"  TabIndex="5"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtInsRefCodeFTX" runat="server"
                                                TargetControlID="txtInsRefCode" FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
                           </div>
                           </div>
                          <div class="row" style="margin-bottom:5px;">
                            <div class="col-md-3" style="text-align:left">
                                            
                                                <asp:Label ID="lblUntType"  CssClass="control-label" runat="server" style="color:Black"></asp:Label>
                                                  <span style="color: #ff0000" id="span1" runat="server" visible="false">*</span><%--shreela--%><span style="font-size: 10pt"><span style="color: #ff0000"></span></span></div>
                          <div class="col-md-3">
                                                <asp:DropDownList ID="ddlUnitType" runat="server" CssClass="form-control"
                                                    onselectedindexchanged="ddlUnitType_SelectedIndexChanged" 
                                                    AutoPostBack = "true" TabIndex="6">
                                                </asp:DropDownList>
                           </div>
                                              <div class="col-md-3" style="text-align:left">
                                             
                                               <asp:Label ID="lblUnitStatus" CssClass="control-label" runat="server" style="color:Black"></asp:Label>
                                                 <span style="font-size: 10pt"><span style="color: #ff0000">*</span><%--shreela--%><span style="color: #ff0000"></span></span></div>
                                          <div class="col-md-3">
                                                <asp:DropDownList ID="ddlUnitStat" runat="server" CssClass="form-control" 
                                                 TabIndex="7">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUnitStat"
                                                    ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>--%>
                                      </div>
                          </div>
                                <div class="row" style="margin-bottom:5px;">
                                          <div class="col-md-3" style="text-align:left">
                                                
                                                <asp:Label ID="lblSalesUnt" runat="server" CssClass="control-label" style="color:Black"></asp:Label>
                                                <span style="font-size: 10pt; color: #ff0000">*</span><%--shreela--%></div>
                                          <div class="col-md-3">
                                                <asp:RadioButtonList ID="rdlYesNo" runat="server"  OnSelectedIndexChanged="rdlYesNo_SelectedIndexChanged"
                                                CssClass="rbl"    AutoPostBack="True" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" TabIndex="8">
                                                </asp:RadioButtonList>
                                           </div>
                                                <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblUntMgrCode" CssClass="control-label" runat="server"></asp:Label>
                                         </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtUnitMGRCode" runat="server" CssClass="form-control"  
                                                    TabIndex="9"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtUnitMGRCodeFTX" runat="server"
                                                TargetControlID="txtUnitMGRCode" FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
                                           </div>
                               </div>
                             <div class="row" style="margin-bottom:5px;">
                                <div class="col-md-3" style="text-align:left">
                                           
                                                <asp:Label ID="lblUntDesc1" runat="server" CssClass="control-label" style="color:Black"></asp:Label>
                                                 <span style="font-size: 10pt;color: #ff0000">*</span><%--shreela--%></div>
                                  <div class="col-md-3">
                                                <asp:TextBox ID="txtUntDesc1" runat="server" onChange="javascript:this.value=this.value.toUpperCase();" CssClass="form-control"
                                                    MaxLength="100" TabIndex="11"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtUntDesc1FTX" runat="server" ValidChars=" "
                                                TargetControlID="txtUntDesc1" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="rfvUntDesc" runat="server" ControlToValidate="txtUntDesc1"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                      </div>
                                  <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblRemark" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                   <div class="col-md-3">
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"  
                                                    MaxLength="100" TabIndex="12"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtRemarkFTX" runat="server"
                                            TargetControlID="txtRemark" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                              </div>
                                 <div class="row" style="margin-bottom:5px;">
                                       <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblUntDesc2" CssClass="control-label" runat="server"></asp:Label>
                                      </div>
                                       <div class="col-md-3">
                                                <asp:TextBox ID="txtUntDesc2" runat="server" CssClass="form-control"  
                                                    MaxLength="100" TabIndex="13"  onChange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtUntDesc2FTX" runat="server"
                                                TargetControlID="txtUntDesc2" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                          </div>
                                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblCmpUntCode" CssClass="control-label" runat="server" Text="Company Unit Code">
                                                </asp:Label>
                                                <asp:Label ID="lblLocCode" CssClass="control-label" runat="server"></asp:Label>
                                      </div>
                                         <div class="col-md-3" style='display:flex;'>
                                                <asp:TextBox ID="txtSALocCode" runat="server" CssClass="form-control" 
                                                    MaxLength="20" TabIndex="14"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtSALocCodeFTX" runat="server"
                                                        TargetControlID="txtSALocCode" FilterType="Custom, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:Button ID="btnGetDefault" runat="server" CssClass="btn blue" TabIndex="15" 
                                                   Text="Get Default" CausesValidation="False" 
                                                    OnClick="btnCancel_Click" >
                                                </asp:Button>
                                                <asp:TextBox ID="txtCompanyUnitCode" runat="server" CssClass="form-control" 
                                                    MaxLength="10" TabIndex="16" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtCompanyUnitCodeFTX" runat="server"
                                                        TargetControlID="txtCompanyUnitCode" FilterType="Custom, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:Button ID="btnCmsUntCode" runat="server" CssClass="btn default"  Visible="false"
                                                    Text="...." TabIndex="17"></asp:Button>
                                           </div>
                               </div>
                             <div class="row" style="margin-bottom:5px;">
                                 <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblUntDesc3" CssClass="control-label" runat="server"></asp:Label>
                                  </div>
                                <div class="col-md-3">
                                                <asp:TextBox ID="txtUntDesc3" runat="server" CssClass="form-control" onchange="javascript:this.value=this.value.toUpperCase();"  
                                                    MaxLength="100" TabIndex="18"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtUntDesc3FTX" runat="server"
                                                TargetControlID="txtUntDesc3" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                 </div>
                                  <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblCSCCodeLA"  CssClass="control-label" runat="server"  Text=" CSC Code L/A (dd/mm/yyyy)"></asp:Label>
                                   </div>
                                  <div class="col-md-3">
                                                <asp:Label ID="lblCSCCode" CssClass="control-label"  runat="server" Visible="False"></asp:Label>
                                        <%--        <uc7:ctlDate ID="txtReqDate" runat="server"  RequiredField="false" CssClass="form-control" 
                                                  RequiredValidationMessage="Mandatory!" Width="301" TabIndex="16" style="margin-left:14px;"/>--%>
                                                    <asp:TextBox ID="txtReqDate" runat="server"  RequiredField="false" CssClass="form-control" 
                                                  RequiredValidationMessage="Mandatory!" TabIndex="19"></asp:TextBox>
                                                  
                                 </div>
                              </div>

               <%-- Added by mrunal for saplocation--%>
                       <div class="row" style="display:none;margin-bottom:5px;">
                                                 <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblsaplocation" Text="Sap Location" CssClass="control-label" runat="server"></asp:Label>
                                                     <span style="font-size: 10pt; color:Red">*</span>
                                  </div>

                           <div class="col-sm-3" >
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                         <ContentTemplate>
                             <div class="input-group">
                                 <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" TabIndex="36"  disabled="true"
                                     onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>&nbsp;
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                     InvalidChars="&`''#%!@$^*-_+={}[]|\:;?><,'~" FilterMode="InvalidChars" TargetControlID="txtBranchCode"
                                     FilterType="Custom">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                                <span class="input-group-addon input-addon_extended">
                                     <asp:LinkButton ID="btnRptMgr" runat="server" CssClass="btn btn-verify" style="margin-bottom:15px;margin-left:2px;" 
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
                              
                                  <div class="col-md-3" style="text-align:left">
                                             
                                   </div>
                                  <div class="col-md-3">
                                     
                                                  
                                 </div>
                              </div>
                </div>

                              <div class="row" style="margin-bottom:5px;" visible="false" runat="server">
                                 <div class="col-md-3" style="text-align:left">
                                    
                                                <asp:Label ID="lblSMCount" CssClass="control-label" runat="server" Text="SM Count" Visible="false" ></asp:Label><span
                                                    id="spSMCount" runat="server" style="font-size: 10pt; color: #ff0000" visible="false">*</span>
                                   </div>
                                 <div class="col-md-3">
                                                <asp:TextBox ID="txtSMCount" runat="server" CssClass="form-control"   Visible="false" 
                                                    MaxLength="2" TabIndex="20"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtSMCountFTX" runat="server"
                                                TargetControlID="txtSMCount" FilterType="Custom, Numbers" ></ajaxToolkit:FilteredTextBoxExtender>
                                  </div>
                             <div class="col-md-3" style="text-align:left">

                                                <asp:Label ID="lblPCCode" CssClass="control-label" runat="server" Text="PC Code" Visible="false"></asp:Label>
                                            
                               </div>
                               <div class="col-md-3">
                                                <asp:TextBox ID="txtPCCode" runat="server" CssClass="form-control"  Visible="false"
                                                    MaxLength="12" TabIndex="21"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtPCCodeFTX" runat="server"
                                                TargetControlID="txtPCCode" FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                                        </div>
            
            
            
            <br />                                        
                    <div class="panel " id="div1"  runat="server">    
                          <div id="Div11" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_tblUnitRptType','btndiv3');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>--%>
                     <asp:Label ID="lblPrReptDtls" runat="server"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
             
          </div>
            <div id="tblUnitRptType" runat="server" class="panel-body" style="display:block"> 
           <%-- <div id="tblUnitRptType" runat="server">--%>
                    <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblruletyp" runat="server" Text="Rule Type"  CssClass="control-label"></asp:Label>
                       </div>
                      <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRuleTypePrmry" runat="server" CssClass="form-control" 
                                                     Enabled="false" >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                   </div>
                  
                     </div>
                    <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblddlreportingtype"  CssClass="control-label"  runat="server"></asp:Label>
                      </div>
                     <div class="col-md-3">
                                                <asp:UpdatePanel ID="upReptType" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlreportingtype" runat="server" CssClass="form-control"  TabIndex="19"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlreportingtype_SelectedIndexChanged"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                     </div>
                   <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblPribasedon" CssClass="control-label"  runat="server"></asp:Label>
                   </div>
                    <div class="col-md-3">
                                                <asp:UpdatePanel ID="upBasedOn" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlbasedon" runat="server" CssClass="form-control"  TabIndex="20"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlbasedon_SelectedIndexChanged"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                   </div>
                   </div>
                      <div class="row" style="margin-bottom:5px;">
                        <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblPrichannel" CssClass="control-label" runat="server"></asp:Label>
                         </div>
                          <div class="col-md-3">
                                                <asp:UpdatePanel ID="upChannel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlchannel" runat="server" CssClass="form-control" TabIndex="21"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlchannel_SelectedIndexChanged"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlreportingtype" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                            </div>
                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblPrisubchannel" CssClass="control-label" runat="server"></asp:Label>
                         </div>
                         <div class="col-md-3">
                                                <asp:UpdatePanel ID="upSubChannel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlsubchannel" runat="server" CssClass="form-control"  TabIndex="22"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlsubchannel_SelectedIndexChanged"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlchannel" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                         </div>
                       </div>
                    <div class="row" style="margin-bottom:5px;">
                   <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblPrilevelagttype" CssClass="control-label" runat="server"></asp:Label>
                     </div>
                   <div class="col-md-3">
                                                <asp:UpdatePanel ID="upLevelAgtType" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddllevelagttype" runat="server" CssClass="form-control" TabIndex="23"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlbasedon" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                     </div>
                    <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblrptunitcode"  CssClass="control-label" runat="server" Text="Reporting Unit Code"></asp:Label>
                     </div>
                  <div class="col-md-3">
                  <div  style="display: flex">
                                                <asp:TextBox ID="txtRptUntCode" runat="server" TabIndex="24" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtRptUntCodeFTX" runat="server"
                                                TargetControlID="txtRptUntCode" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:Button ID="btnRptUntCode" style="margin-left: 2px" runat="server"  CssClass="btn btn-verify" TabIndex="25" Text="..." />
                                                               
                                                <asp:Label ID="lblRptUntCode" CssClass="control-label" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnRptUntCode" runat="server" />
                                                </div>
                    </div>
                    </div>
                     <div class="row" style="margin-bottom:5px;" id="trrptrule" runat="server" visible="false">
                             <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblRptRule"  CssClass="control-label"  runat="server" Visible="false"></asp:Label>
                               </div>
                              <div class="col-md-3">
                                                <asp:UpdatePanel ID="upReptRule" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlReportingRule" runat="server" CssClass="select2-container form-control"
                                                            TabIndex="26" Enabled="false" Visible="false">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                  </div>
                            
                           </div>
                   
           <%--  </div>--%>
           </div>
                                        </div>
                              
                                         
            <br />  
              <div class="panel " id="div4" runat="server">
                      <div id="Div12" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div5','btndiv5');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>--%>
                     <asp:Label ID="lblAddlRDtls" runat="server"  CssClass="control-label"  Font-Size="19px"  ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv5" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
             
          </div>
           <div id="div5" runat="server" class="panel-body" style="display:block"> 
                <div class="row" style="margin-bottom:5px;">
                  <div class="col-md-3" style="text-align:left">
                                                        <asp:Label ID="lbladditionalreporting" runat="server" CssClass="control-label"></asp:Label>
                   </div>
                   <div class="col-md-3">
                                                        <asp:Label ID="lbladditionalrptdesc" runat="server" CssClass="control-label"></asp:Label>
                 </div>
                 <div class="col-md-3">
                 </div>
                 <div class="col-md-3">
                 </div>
                                         
                 </div>
                 <div  id="tblMgr1" runat="server" style="margin-bottom:5px;">
                 <div class="row" id="tr1" style="margin-bottom:5px;" runat="server">
                             <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lbladditionalmangr1" runat="server" CssClass="control-label"></asp:Label>
                             </div>
                             <div class="col-md-3">
                             </div>
                              <div class="col-md-3">
                              </div>
                               <div class="col-md-3">
                               </div>
                   </div>
                    <div class="row" runat="server" style="margin-bottom:5px;">
                                <div class="col-md-3" style="text-align:left">
                                        <asp:Label ID="lblruletypaddl1" runat="server" Text="Rule Type" CssClass="control-label"></asp:Label>
                             </div>
                                <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRuleTypeAddl1" runat="server" TabIndex="27" CssClass="form-control" Enabled="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                                 <div class="col-md-3">
                                 </div>
                                  <div class="col-md-3">
                                  </div>
                     </div>
                      <div id="tradnmgr1" class="row" style="margin-bottom:5px;" runat="server">
                                  <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMRptTyp" runat="server" CssClass="control-label"></asp:Label>
                                     </div>
                                     <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upAm1ReptType" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam1reportingtype" runat="server" CssClass="form-control" TabIndex="28"
                                                                                    Enabled="false">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam1channel" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                     </div>
                                  <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMBsdOn" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                       <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upAm1BasedOn" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam1basedon" runat="server" CssClass="form-control"  TabIndex="29"
                                                                                    Enabled="false">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam1levelagttype" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                    </div>
                     </div>
                        <div class="row" runat="server" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblAddlMChnl" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                     <div class="col-md-3">
                            <asp:UpdatePanel ID="upAm1Channel" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlam1channel" runat="server" AutoPostBack="True" 
                                       CssClass="form-control"   Enabled="false" 
                                        OnSelectedIndexChanged="ddlam1channel_SelectedIndexChanged" TabIndex="30">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlam1subchannel" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                      </div>
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblAddlMSubCls" CssClass="control-label" runat="server"></asp:Label>
                      </div>
                      <div class="col-md-3">
                            <asp:UpdatePanel ID="upAm1SubChannel" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlam1subchannel" runat="server" 
                                        CssClass="form-control" Enabled="false" 
                                        OnSelectedIndexChanged="ddlam1subchannel_SelectedIndexChanged" TabIndex="31">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlam1basedon" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                       </div>
                   </div>
                       <div id="Div9" class="row" style="margin-bottom:5px;" runat="server">
                    <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblAMLvlAgtTyp" runat="server" CssClass="control-label"></asp:Label>
                     </div>
                      <div class="col-md-3">
                            <asp:UpdatePanel ID="upAm1LvlAgtType" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlam1levelagttype" runat="server" 
                                        CssClass="form-control" Enabled="false" TabIndex="32">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                       </div>
                       <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblRptUnitCodeMgr1" runat="server" CssClass="control-label" 
                                Text="Reporting Unit Code"></asp:Label>
                     </div>
                    <div class="col-md-3">
                    <div style="display: flex">
                            <asp:TextBox ID="txtRptUnitCodeMgr1" runat="server" 
                                CssClass="form-control" TabIndex="33"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="txtRptUnitCodeMgr1FTX" runat="server" 
                                FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers" 
                                TargetControlID="txtRptUnitCodeMgr1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:Button ID="btnRptUnitCodeMgr1" runat="server" style="margin-left: 2px" CssClass="btn btn-verify" 
                                TabIndex="34" Text="..." />
                            <asp:Label ID="lblRptUntCodeMgr1" runat="server" CssClass="control-label"></asp:Label>
                            <asp:HiddenField ID="hdnRptUntCodeMgr1" runat="server" />
                        </div>
                        </div>
                  </div>
                    
   </div>
               <%--additional --%>
                <div  id="tblMgr2" runat="server"  style="margin-bottom:5px;" visible="false">
                 <div class="row" id="tradnmgr2" style="margin-bottom:5px;" runat="server" visible="false">
                       <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lbladditionalmangr2" CssClass="control-label" runat="server"></asp:Label>
                         </div>
                       <div class="col-md-3">
                       </div>
                       <div class="col-md-3">
                       </div>
                       <div class="col-md-3">
                       </div>
                   </div>
                    
                    <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMRptTyp2" runat="server" Text="Relationship Type" CssClass="control-label"></asp:Label>
                       </div>
                        <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upAm2ReptType" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam2reportingtype" runat="server" CssClass="form-control" TabIndex="37"
                                                                                     Enabled="False">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam2channel" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                     </div>
                       <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMBsdOn2" runat="server" Text="Based On" CssClass="control-label"></asp:Label>
                       </div>
                       <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upam2BasedOn" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam2basedon" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlam2basedon_SelectedIndexChanged" TabIndex="38">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam2levelagttype" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                       </div>
                   </div>
                   <div class="row" style="margin-bottom:5px;">
                      <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMChnl2" runat="server" Text="Hierarchy Name" CssClass="control-label"></asp:Label>
                       </div>
                    <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upAm2Channel" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam2channel" runat="server" CssClass="form-control"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlam2channel_SelectedIndexChanged" TabIndex="39">
                                                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam2subchannel" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                </div>
                   <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAddlMSubCls2" runat="server" Text="Sub Class" CssClass="control-label"></asp:Label>
                     </div>
                    <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upAm2SubChannel" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam2subchannel" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlam2subchannel_SelectedIndexChanged" TabIndex="40">
                                                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlam2basedon" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                        </div>
                    </div>
                             <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                                                        <asp:Label ID="lblAMLvlAgtTyp2" runat="server" Text="Relation Member Type" CssClass="control-label"></asp:Label>
                               </div>
                              <div class="col-md-3">
                                                                        <asp:UpdatePanel ID="upLvlAgttype" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlam2levelagttype" runat="server" CssClass="form-control" TabIndex="41"
                                                                                    Enabled="false">
                                                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                  </div>
                                                                    <div class="col-md-3">
                                                                    </div>
                                                                     <div class="col-md-3">
                                                                     </div>
                               </div>
                                                 </div>
           <div class="row" style="margin-bottom:5px; display:none" id="trMasterLink" runat="server" >
                  <div class="col-md-2">
                                                            <asp:Label ID="LblBizsrc"  CssClass="control-label" runat="server" Text="Channel" ></asp:Label><span
                                                                id="Span3" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                   </div>
                <div class="col-md-1">
                                                            <asp:Label ID="LblSlschannel"  CssClass="control-label" runat="server"></asp:Label><span
                                                                id="Span4" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                </div>
          <div class="col-md-2">
                                                            <asp:Label ID="LblSubclass"  CssClass="control-label" runat="server" Text="Sub class"  ></asp:Label><span
                                                                id="Span5" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
           </div>
                <div class="col-md-1">
                                                            <asp:Label ID="LblChannelSubclass"  CssClass="control-label"  runat="server"></asp:Label><span
                                                                id="Span6" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
              </div>
                <div class="col-md-2">
                                                            <asp:Label ID="LblUntcodeLink"  CssClass="control-label"  runat="server" Text = "Unit Type"></asp:Label><span
                                                                id="Span7" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                 </div>
                <div class="col-md-1">
                                                            <asp:Label ID="LblUnitType"  CssClass="control-label"  runat="server"></asp:Label>
                 </div>
              <div class="col-md-2">
                                                            <asp:Label ID="LblUnitName"  CssClass="control-label"  runat="server" Text="Unit Name"></asp:Label>
            </div>
                <div class="col-md-1">
                                                           <asp:DropDownList ID="DdlUnitName" runat="server"  CssClass="form-control" TabIndex="48">
                                                            </asp:DropDownList>
               </div>
                                                   
           </div>
                                        <%--Link to staff Contents--%>
                                          <div class="row" style="margin-bottom:5px;" id="trStaffLink" runat="server">
                                            <div class="col-md-2">
                                                            <asp:Label ID="lbluntSalesChnl"  CssClass="control-label" runat="server" Text="Channel" ></asp:Label><span
                                                                id="Span8" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                                          </div>
                                                    <div class="col-md-1">
                                                            <asp:Label ID="lbluntSalesChnlDesc"  CssClass="control-label" runat="server"></asp:Label><span
                                                                id="Span9" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                                                     </div>
                                                    <div class="col-md-2">
                                                            <asp:Label ID="lbluntSubChnl"  CssClass="control-label" runat="server" Text="Sub class"  ></asp:Label><span
                                                                id="Span10" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                              </div>
                                                      <div class="col-md-1">
                                                            <asp:Label ID="lbluntSubChnlDesc"  CssClass="control-label"  runat="server"></asp:Label><span
                                                                id="Span11" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                                            </div>
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblAgntType"  CssClass="control-label"  runat="server" Text = "Agent Type"></asp:Label><span
                                                                id="Span12" runat="server" style="font-size: 10pt; color: #ff0000;" ></span>
                                                     </div>
                                                     <div class="col-md-1">
                                                            <asp:Label ID="LblAgentType"  CssClass="control-label"  runat="server" ></asp:Label>
                                             </div>
                                                       <div class="col-md-2">
                                                            <asp:Label ID="LblAgentName"  CssClass="control-label"  runat="server" Text = "Agent Name"></asp:Label>
                                                  </div>
                                                  <div class="col-md-1">
                                                           <asp:DropDownList ID="DdlAgntName" runat="server"  CssClass="form-control" TabIndex="49">
                                                            </asp:DropDownList>
                                                  </div>
                                           </div>
                                        <%-- Added by Kalyani for Link to master unit checkbox and Link to staff checkbox content--%>
                                         </div>
                                         </div>

                                         <br/>
                                        
                 <div class="panel " id="div6" runat="server">  
                    <div id="Div13" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','btndivcmphdr');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblUntCnctI" runat="server" Text="Unit Contact Information" Font-Size="19px"  CssClass="control-label" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btndivcmphdr" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
             
                 </div>
                  <div id="divcmphdr" runat="server" class="panel-body" style="display:block"> 
                     <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblEmail" CssClass="control-label" runat="server"></asp:Label>
                       </div>
                       <div class="col-md-3">
                                                <asp:TextBox ID="txtEMail" runat="server"   CssClass="form-control"
                                                    MaxLength="50" TabIndex="50" onblur="IsEmail()" ></asp:TextBox>
                                            <%--  <asp:RegularExpressionValidator ID="txtEMailregex" ControlToValidate="txtEMail"
                                                       ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" display="Static"
                                                   runat="server"  ErrorMessage="Please provide a valid email address" ></asp:RegularExpressionValidator>--%>
                       </div>
                      <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblOffTel" CssClass="control-label" runat="server"></asp:Label>
                     </div>
                       <div class="col-md-3">
                                                <asp:TextBox ID="txtOTel" runat="server"  CssClass="form-control"
                                                    MaxLength="11" TabIndex="51"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtOTelFTX" runat="server"
                                                    TargetControlID="txtOTel" FilterType="Custom, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                      </div>
                    <div class="row" style="margin-bottom:5px;">
                             <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblFax" runat="server" CssClass="control-label" ></asp:Label>
                               </div>
                                 <div class="col-md-3">
                                                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control" 
                                                    MaxLength="20" TabIndex="52"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtFaxFTX" runat="server"
                                                    TargetControlID="txtFax" FilterType="Custom, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                 </div>
                                  <div class="col-md-3">
                                  </div>
                                   <div class="col-md-3">
                                   </div>
                      </div>
                    <div class="row" style="margin-bottom:5px;">
                              <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblpfAddrP1" CssClass="control-label" runat="server" Text="Address"></asp:Label>
                               </div>
                               <div class="col-md-3">
                                            <asp:TextBox ID="txtAddrP1" onChange="javascript:this.value=this.value.toUpperCase();"
                                                runat="server" Font-Bold="False"  CssClass="form-control"  MaxLength="30" 
                                                  TabIndex="53"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtAddrP1DTX" runat="server"
                                                TargetControlID="txtAddrP1" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                              </div>
                              <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblpfStateP"  CssClass="control-label" runat="server" Text="State"></asp:Label>
                                   <span style="/*font-size: 10pt; color:Red*/">*</span></div>
                               <div class="col-md-3">
                               <div style= "display: flex">
                                            <asp:DropDownList id="ddlState" runat="server" CssClass="form-control"  
                                                        TabIndex="54"></asp:DropDownList>
                                
                                                <asp:Button ID="btnStateSrch" runat="server" style="margin-left: 2px" CausesValidation="False" CssClass="btn btn-verify" 
                                                Text="Search" TabIndex="55" />
                                                </div>
                            </div>
                          </div>
                    <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">

                                            <asp:Label ID="lblpfAddrP2" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                          <div class="col-md-3">
                                            <asp:TextBox  ID="txtAddrP2" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                               CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                 TabIndex="56"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtAddrP2FTX" runat="server"
                                                TargetControlID="txtAddrP2" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                           <%-- <asp:RequiredFieldValidator ID="revAddrP2" runat="server" ErrorMessage="Mandatory" ControlToValidate="txtAddrP2">
                                            </asp:RequiredFieldValidator>--%>
                          </div>
                         <div class="col-md-3" style="text-align:left">

                                            <asp:Label ID="lblDistP" runat="server" CssClass="control-label" Text="District"></asp:Label>
                          </div>
                        <div class="col-md-3">
                                            <asp:TextBox ID="txtDistP"  ReadOnly="false" runat="server" Font-Bold="False"
                                                CssClass="form-control"   TabIndex="57"></asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="txtDistPFTX" runat="server"
                                                TargetControlID="txtDistP" FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                 &nbsp;<asp:Button ID="btnDist" runat="server" CausesValidation="False"  CssClass="btn blue"
                                                Text="..." TabIndex="58" Visible="False" />
                                            <%--<asp:RequiredFieldValidator ID="revDistP" runat="server" ErrorMessage="Mandatory" ControlToValidate="txtDistP">
                                            </asp:RequiredFieldValidator>--%>
                                            <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                            <asp:HiddenField ID="hdnDist" runat="server" />
                                            <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                            <asp:HiddenField ID="hdnPinTo" runat="server" />
                          </div>
                     </div>
                      <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblpfAddrP3" CssClass="control-label"  runat="server"></asp:Label>
                         </div>
                          <div class="col-md-3">
                                            <asp:TextBox ID="txtAddrP3" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                 TabIndex="59"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtAddrP3FTX" runat="server"
                                                TargetControlID="txtAddrP3" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <%--<asp:RequiredFieldValidator ID="revaddrp3" runat="server" ErrorMessage="Mandatory" ControlToValidate="txtAddrP3">
                                            </asp:RequiredFieldValidator>--%>
                           </div>
                          <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblarea" CssClass="control-label" runat="server" Text="Area"></asp:Label>
                          </div>
                          <div class="col-md-3">
                                            <asp:TextBox ID="txtarea" runat="server" CssClass="form-control" 
                                                  ReadOnly="false" Font-Bold="False" MaxLength="50" TabIndex="60"></asp:TextBox> <%-- onkeypress="alert('Please Select District,Do not Type');return false;"  onChange="javascript:this.value=this.value.toUpperCase();"--%>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtareaFTX" runat="server"
                                                TargetControlID="txtarea" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                <asp:Button  ID="btnarea" runat="server"  CssClass="btn default"  CausesValidation="False" 
                                                      Text="..." Enabled="false" Visible="false" TabIndex = "61"/>
                          </div>
                     </div>
                       <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblVillage" runat="server" CssClass="control-label" Text="Village"></asp:Label>
                           </div>
                        <div class="col-md-3">
                                            <asp:UpdatePanel ID="UpdPanelVillage" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtVillage" runat="server" onChange="javascript:this.value=this.value.toUpperCase();"
                                                      CssClass="form-control" Font-Bold="False" MaxLength="30" 
                                                        TabIndex="62"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtVillageFTX" runat="server"
                                                    TargetControlID="txtVillage" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                        </div>
                         <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblpfPinP" runat="server" CssClass="control-label" Text="Postcode"></asp:Label>
                         </div>
                        <div class="col-md-3">
                                            <asp:TextBox ID="txtPinP" runat="server" CssClass="form-control"
                                                Font-Bold="False" MaxLength="6" 
                                                TabIndex="63"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="revPinP" runat="server" 
                                                ControlToValidate="txtPinP" ErrorMessage="Mandatory">
                                            </asp:RequiredFieldValidator>--%>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtPinPFTX" runat="server"
                                                    TargetControlID="txtPinP" FilterType="Custom, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                     </div>
                        <div class="row" style="margin-bottom:5px;">
                           <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblcityp" runat="server" CssClass="control-label" Text="City"></asp:Label>
                         </div>
                            <div class="col-md-3">
                                            <asp:TextBox ID="txtcityp" runat="server"  
                                                CssClass="form-control" Font-Bold="False" MaxLength="50" ReadOnly="false" 
                                                TabIndex="64"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtcitypFTX" runat="server"
                                                    TargetControlID="txtcityp" FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                             </div>
                           <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblpfCountryP" runat="server" CssClass="control-label" Text="Country"></asp:Label>
                           </div>
                            <div class="col-md-3">
                            <div style="display: flex">
                                            <asp:TextBox ID="txtCountryCodeP" runat="server"  CssClass="form-control" 
                                                onChange="javascript:this.value=this.value.toUpperCase();" 
                                                MaxLength="3" Text="IND" Enabled="false"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtCountryCodePFTX" runat="server"
                                                    TargetControlID="txtCountryCodeP" FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                            <asp:TextBox  ID="txtCountryDescP" runat="server" CssClass="form-control" 
                                             Enabled="False" Text="INDIA"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtCountryDescPFTX" runat="server"
                                                    TargetControlID="txtCountryDescP" FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                                    </ajaxToolkit:FilteredTextBoxExtender>&nbsp;
                                <asp:Button CssClass="btn btn-default"
                                                TabIndex="65" ID="btnCountryP" runat="server" CausesValidation="False" />
                                                </div>
                          </div>
                     </div> 
                            <div class="row" style="margin-bottom:5px;" runat="server" visible="false">   
                             <div class="col-md-3" style="text-align:left">
                                                 <asp:Label ID="lblAddress"  CssClass="control-label"  runat="server"></asp:Label>
                               </div>
                              <div class="col-md-3">
                                                <asp:TextBox ID="txtAddress1" runat="server"  CssClass="form-control" TabIndex="66"
                                                    MaxLength="100" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtAddress1FTX" runat="server"
                                                    TargetControlID="txtAddress1" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                          <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblPostCode"  CssClass="control-label"  runat="server"></asp:Label>
                           </div>
                           <div class="col-md-3">
                                                <asp:TextBox ID="txtPOstCode" runat="server"  CssClass="form-control"  TabIndex="67"
                                                    MaxLength="10" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtPOstCodeFTX" runat="server"
                                                    TargetControlID="txtPOstCode" FilterType="Custom, Numbers">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                          </div>
                           <div id="Div14" class="row" style="margin-bottom:5px;" runat="server" visible="false">   
                               <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblAddress2" CssClass="control-label"  runat="server"></asp:Label>
                                 </div>
                              <div class="col-md-3">
                                                 <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" TabIndex="68"
                                                        MaxLength="100" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtAddress2FTX" runat="server"
                                                TargetControlID="txtAddress2" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                              </div>
                             <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblCity" CssClass="control-label"  runat="server"></asp:Label>
                             </div>
                              <div class="col-md-3">
                                                
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" TabIndex="69"
                                                    MaxLength="100" ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtCityFTX" runat="server"
                                                TargetControlID="txtCity" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                              </div>
                           </div>
                           <div id="Div3" class="row" style="margin-bottom:5px;" runat="server">  
                                 <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="LlbGST" Text ="GST IN" CssClass="control-label" runat="server"></asp:Label>
                               </div>
                                  <div class="col-md-3">
                                                 <asp:TextBox ID="TxtGST" runat="server" CssClass="form-control"  TabIndex="70"
                                                        MaxLength="100" ></asp:TextBox>
                                   </div>
                                     <div class="col-md-3">
                             
                             </div>
                             <div class="col-md-3">
                               
                             </div>
                                   </div>
                               <div id="Div15" class="row" style="margin-bottom:5px;" runat="server" visible="false">  
                                 <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblAddress3" CssClass="control-label" runat="server"></asp:Label>
                               </div>
                                  <div class="col-md-3">
                                                <asp:TextBox ID="txtAddress3" runat="server" CssClass="form-control" TabIndex="71"
                                                        MaxLength="100" ></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtAddress3FTX" runat="server"
                                            TargetControlID="txtAddress3" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                   </div>
                             <div class="col-md-3">
                             
                             </div>
                             <div class="col-md-3">
                               
                             </div>
                           </div>
                   </div>                    
                   </div> 
                   <br /> 
              <div class="panel " id="div7" runat="server">     
                       <div id="Div16" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div8','btndiv8');return false;"> 
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblLocn" runat="server" Text="Google Map Location"  Font-Size="19px"  CssClass="control-label" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                    <span id="btndiv8" class="glyphicon glyphicon-menu-hamburger"  style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
                 </div>
                 <div id="div8" runat="server" class="panel-body" style="display:block"> 
                     <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblLatitude" CssClass="control-label" runat="server" Text="Latitude"></asp:Label>
                           </div>
                      <div class="col-md-3">
                                                <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control"  TabIndex="72"
                                                    MaxLength="100"></asp:TextBox>
                                               <ajaxToolkit:FilteredTextBoxExtender ID="txtLatitudeFTX" runat="server"
                                                TargetControlID="txtLatitude" FilterType="Custom, Numbers"
                                                ValidChars="." >
                                                </ajaxToolkit:FilteredTextBoxExtender>
                       </div>
                        <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblLongitude" CssClass="control-label" runat="server" Text="Longitude"></asp:Label>
                        </div>
                          <div class="col-md-3">
                                                <asp:TextBox ID="txtLongitude" runat="server"  CssClass="form-control"  TabIndex="73"
                                                    MaxLength="20"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="txtLongitudeFTX" runat="server"
                                                TargetControlID="txtLongitude" FilterType="Custom, Numbers"
                                                ValidChars="." ></ajaxToolkit:FilteredTextBoxExtender>
                         </div>
                       </div>

                                  </div>
             </div>

            <%--Added by Rajkapoor Yadav on 25-02-2022 Starts here--%> 
                      <div class="panel " id="div17" runat="server">     
                       <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divChnEnblmnt','btndivnew');return false;"> 
                           <%--onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div8','btndivnew');return false;"--%>
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label2" runat="server" Text="Channel Enablement"  Font-Size="19px"  CssClass="control-label" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                    <span id="btndivnew" class="glyphicon glyphicon-menu-hamburger"  style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>  
                 </div>
                 <div id="divChnEnblmnt" runat="server" class="panel-body" style="display:block"> 
                     <%--For Channel Enablment Grid End--%>

                                      <div ID="trChnEnblmnt" runat="server" style="width:97%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                        <asp:GridView   ID="grdChnEnblmnt" runat="server" CssClass="footable" AllowSorting="true"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   
                                         style="margin-top:10px" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />

                                        <Columns>
                                            <asp:BoundField DataField="ChannelDesc01"   HeaderText="Channel" 
                                                SortExpression="LegalName"><%--1--%>
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ChnClsDesc01" HeaderText="Sub Channel" 
                                                SortExpression="UnitType"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="UnitDesc01" HeaderText="Unit Type" 
                                                SortExpression="UnitType"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="unitcode" HeaderText="Unit Code" 
                                                SortExpression="unitcode"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="UnitLegalName" HeaderText="Unit Name" 
                                                SortExpression="UnitType"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="cmsunitcode" HeaderText="CMS Unit Code" 
                                                SortExpression="UnitType"><%--4--%>
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                       
                                    </asp:GridView>
                                </ContentTemplate>
                          
                            </asp:UpdatePanel>
                 </div>

                     <%--For Channel Enablment Grid End--%>


                     <div class="row" style="margin-bottom:5px;">
                         <div class="col-md-3" style="text-align:left">
                                                 
                           </div>
                      <div class="col-md-3">
                                                
                       </div>
                        <div class="col-md-3" style="text-align:left">
                                                 
                        </div>
                          <div class="col-md-3">
                                                
                         </div>
                       </div>

                                  </div>
             </div>
                      
                  <%--Added by Rajkapoor Yadav on 25-02-2022 Ends here--%> 



                                   <%--<tr>
                                            <td style="height: 25px" align="center" colspan="4">
                                                <div style="display: none" id="ivarLoad" class="Content">
                                                    <img class="UpdateProgress1_img" alt="" src="~/App_Themes/Isys/images/spinner.gif" />
                                                    Loading ...
                                                </div>
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="standardbutton" TabIndex="51" OnClick="btnUpdate_Click" 
                                                    Width="80px"  Text="UPDATE"></asp:Button> &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" TabIndex="52" OnClick="btnCancel_Click" 
                                                    Width="80px"  Text="CANCEL" CausesValidation="False">
                                                </asp:Button>
                                            </td>
                                        </tr>
--%>
                    <%--</table>
                                  </div>--%>


          <div id="tbladdcntst" runat="server" style="width: 98%;">
             <div class="row">
                   <div class="col-md-12" style="text-align:center">
                        <input id="hidFlag" runat="server" type="hidden" />&nbsp;
                  <%--      <asp:Button ID="btnUpdate" runat="server" TabIndex="43" CssClass="btn blue" CausesValidation="True"
                            Text="UPDATE" Width="100px" OnClick="btnUpdate_Click" OnClientClick="javascript:validate();" />--%>
                                 <asp:LinkButton ID="btnUpdate" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnUpdate_Click" TabIndex="73" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Update
                                  </asp:LinkButton>
                        &nbsp;&nbsp;
                     <%--   <asp:Button ID="Cancel" runat="server" TabIndex="43" Text="CANCEL" CssClass="btn default"
                            Width="100px" OnClick="btnCancel_Click" CausesValidation="False" />--%>
                              <asp:LinkButton ID="Cancel" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnCancel_Click" TabIndex="74" >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                  </asp:LinkButton>
                    </td>
           </div>
        </div>
                                  
             </div>                           
                                        
     <asp:Button ID="Btnpincode" runat="server" OnClientClick="function() {}" OnClick="Btnpincode_Click" ClientIDMode="Static" style="display:none"/>
                                        
                                        
                <table>
                <tbody>
                    <tr>
                        <td>
                            <input id="hdnCreateRule" type="hidden" runat="server" />
                            <input id="hdnID220" type="hidden" runat="server" />
                            <input id="hdnCmsDesc" type="hidden" runat="server" />
                            <input id="hdnPrimMand" type="hidden" runat="server" />
                            <input id="hdnAddl1Mand" type="hidden" runat="server" />
                            <input id="hdnAddl2Mand" type="hidden" runat="server" />
                            <input id="hdnID230" type="hidden" runat="server" />
                            <input id="hdnID240" type="hidden" runat="server" />
                            <input id="hdnID250" type="hidden" runat="server" />
                            <input id="hdnID260" type="hidden" runat="server" />
                            <input id="hdnID270" type="hidden" runat="server" />
                            <input id="hdnID280" type="hidden" runat="server" />
                            <input id="hdnID290" type="hidden" runat="server" />
                            <input id="hdnID320" type="hidden" runat="server" />
                            <input id="hdnID330" type="hidden" runat="server" />
                            <input id="hdnID350" type="hidden" runat="server" />
                            <input id="hdnID360" type="hidden" runat="server" />
                            <input id="hdnID370" type="hidden" runat="server" />
                            <input id="hdnID380" type="hidden" runat="server" />
                            <input id="hdnSALocCode" type="hidden" runat="server" />
                            <input id="hdnChnl" type="hidden" runat="server" />
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <input id="hdnPrmStp" type="hidden" runat="server" />
                                                <input id="hdnAdlStp" type="hidden" runat="server" />
                                                <input id="hdnPrmType" type="hidden" runat="server" />
                                                <input id="hdnAdlType" type="hidden" runat="server" />
                                                
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                            <%--Added by rachana on 02-07-2013 for client code start--%>
                            <input id="hdnAgentcode" type="hidden" runat="server" />
                            <%--Added by rachana on 02-07-2013 for client code start--%>
                        </td>
                    </tr>
                    </tbody>
            </table>
            </center>
    </div>
    <%--Added by swapnesh on 28/5/2013 for showing popup and messagebox start--%>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>

        </div>
    </div>
    <asp:Panel runat="server" ID="pnlMdl" Width="600" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="600" height="550px" scrolling="auto" frameborder="0" display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID" TargetControlID="lbl1" PopupControlID="pnlMdl"
        BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--Added by swapnesh on 28/5/2013 for showing popup and messagebox end--%>

    <%--/Added by usha on 19.09.2018--%>

    <asp:Panel runat="server" ID="Panel1" Width="500" Height="428" display="none" top="52">
        <iframe runat="server" id="Iframe1" width="610px" height="530px" frameborder="0" style="margin-top: -60px;"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--For Displaying Information Pop-up End--%>
</asp:Content>

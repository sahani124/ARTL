<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="BrnAdvTrn50HrsSearch.aspx.cs"
    Inherits="Application_INSC_Recruit_BrnAdvTrn50HrsSearch" Title="Untitled Page" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

       <%-- start Added by sanoj 29092022--%>

    
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
   
    <%--<link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />--%> <%--given by ush mam--%>



       <%-- end Added by sanoj 29092022--%>
  
    <%--<link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/menu4jquery-ui.css" rel="stylesheet"  type="text/css" />
      <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"type="text/css" />
        <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"type="text/css" />--%>


    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
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
    <script language="javascript" type="text/javascript">
        $(function () {
            debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
        });
        $(function () {
            debugger;

            $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true ,maxDate:0}); //txtReqDate

        });
        $(function () {
            debugger;

            $("#<%= txtReqDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true }); //txtReqDate

        });

        $(function () {
            // debugger;
            $('#<%=dgView.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000
                }
            });
        });
        $(document).ready(function () {
            debugger;
            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                var currentTab = $(e.target).text(); // get current tab
                var LastTab = $(e.relatedTarget).text(); // get last tab
                $(".current-tab span").html(currentTab);
                $(".last-tab span").html(LastTab);
            });
        });
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
            $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
            $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });

        function validtab() {

            debugger;
            if ($("[id*=TabName]").val() != "" && $("[id*=TabName]").val() == "menu1")//added  by sanoj for qc one pazor
                //($('#ctl00_ContentPlaceHolder1_LinkButton1').attr('aria-expanded') === 'true')
            {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('1');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1"; //added  by sanoj for qc one pazor
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else if
                ($("[id*=TabName]").val() != "" && $("[id*=TabName]").val() == "menu2")
                /* ($('#ctl00_ContentPlaceHolder1_LinkButton2').attr('aria-expanded') === 'true')*/ {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('2');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu2";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }


            else if
                ($("[id*=TabName]").val() != "" && $("[id*=TabName]").val() == "menu3")
                /* ($('#ctl00_ContentPlaceHolder1_LinkButton2').attr('aria-expanded') === 'true')*/ {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('3');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu3";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

            else if ($("[id*=TabName]").val() != "" && $("[id*=TabName]").val() == "menu4")
                //($('#ctl00_ContentPlaceHolder1_LinkButton3').attr('aria-expanded') === 'true')
            {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('4');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu4";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else if ($("[id*=TabName]").val() != "" && $("[id*=TabName]").val() == "menu4")
                //($('#ctl00_ContentPlaceHolder1_LinkButton4').attr('aria-expanded') === 'true') 
            {

                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('4');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu4";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('0');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

        }

        //added by pallavi on 19042023

        //function validtab() {

        //    debugger;
        //    if ($('#ctl00_ContentPlaceHolder1_LinkButton1').attr('aria-expanded') === 'true') {
        //        $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('1');
        //        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
        //        $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
        //        $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
        //            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        //        });

        //    }
        //    else if ($('#ctl00_ContentPlaceHolder1_LinkButton2').attr('aria-expanded') === 'true') {
        //        $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('2');
        //        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu2";
        //        $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
        //        $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
        //            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        //        });

        //    }

        //    else if ($('#ctl00_ContentPlaceHolder1_LinkButton3').attr('aria-expanded') === 'true') {
        //        $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('3');
        //        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu3";
        //        $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
        //        $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
        //            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        //        });

        //    }
        //    else if ($('#ctl00_ContentPlaceHolder1_LinkButton4').attr('aria-expanded') === 'true') {

        //        $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('4');
        //        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu4";
        //        $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
        //        $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
        //            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        //        });

        //    }
        //    else {
        //        $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('0');
        //        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
        //        $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
        //        $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
        //            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        //        });

        //    }

        //}

        //function ShowReqDtl(divName, btnName) {
        //    debugger;
        //    try {
        //        var objnewdiv = document.getElementById(divName)
        //        var objnewbtn = document.getElementById(btnName);
        //        if (objnewdiv.style.display == "block") {
        //            objnewdiv.style.display = "none";
        //            objnewbtn.className = 'glyphicon glyphicon-chevron-down'
        //        }
        //        else {
        //            objnewdiv.style.display = "block";
        //            objnewbtn.className = 'glyphicon glyphicon-chevron-down'
        //        }
        //    }
        //    catch (err) {
        //        ShowError(err.description);
        //    }
        //}

        function ShowReqDtl(divName, btnName) {
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

        //        function ShowReqDtl(divName, btnName) {
        //            debugger;
        //            try {
        //                var objnewdiv = document.getElementById(divName)
        //                var objnewbtn = document.getElementById(btnName);
        //                if (objnewdiv.style.display == "block") {
        //                    objnewdiv.style.display = "none";
        //                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
        //                }
        //                else {
        //                    objnewdiv.style.display = "block";
        //                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
        //                }
        //            }
        //            catch (err) {
        //                ShowError(err.description);
        //            }
        //        }


        var path = "<%=Request.ApplicationPath.ToString()%>";

        function poponload(window) {

            window.moveTo(0, 0);

        }

        //popup added by rachana to show CFR for admin and other user with status raised,responded,closed start
        function funcShowPopup(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFR") {
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopCFRAssigned.aspx?CndNo=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
                //agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
            }
        }
        function funcShowPopupCFR(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFRDetail") {
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopCFRAssigned.aspx?CndNo=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
                // agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user +"&mdlpopup=MdlPopRaiseCFR";
            }
        }

        //popup added by rachana to show CFR for admin and other user with status raised,responded,closed end
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

        function LdWaitGrid(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divloadergrid").style.display = 'block';
            setTimeout("RemoveLoadingGrid()", delay);
        }

        function RemoveLoadingGrid() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloadergrid").style.display = 'none';

        }

        function funcopen(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&CndNo=" + arg1 + "&Code=" + Code + "&Type=Qc&mdlpopup=MdlPopRaiseSub";
        }

        //Added by Rahul on 25-04-2015 for retrieval process start
        function funcopenRET(arg1, status, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&CndNo=" + arg1 + "&Status=" + status + "&Code=" + Code + "&Type=Qc&mdlpopup=MdlPopRaiseSub";
        }
        //Added by Rahul on 25-04-2015 for retrieval process end

        //Added by Nikhil on 29-07-2015 for NOC process start
        function funcopenNOC(arg1, status, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=NOCQc&CndNo=" + arg1 + "&Status=" + status + "&Code=" + Code + "&Type=QcNO&mdlpopup=MdlPopRaiseSub";
        }
        //Added by Nikhil on 29-07-2015 for NOC process end


        function funcopenCFR(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + arg1 + "&Code=" + Code + "&Type=Qc&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
        //added bu usha  on 21-07-2015
        function funcopenNOCAppCFR(arg1, Code, arg2) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRRespond&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=QcRes&user=Brn&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenNOCTeamCFR1(arg1, Code,ModuleID, arg2) {
            debugger;
            $find("MdlPopRaiseSub").show();
            //document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRCVR&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=NTRes&mdlpopup=MdlPopRaiseSub";commendted by ajay 02 062023
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRCVR&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&ModuleID=" + ModuleID + "&Type=NTRes&mdlpopup=MdlPopRaiseSub&userrollcode=SMUSER";
        }
        function funcopenNOCCFR(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRRespond&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&status=NOCCFR&mdlpopup=MdlPopRaiseSub";
        }
        //ended by usha 
        function funcopenNOCTeamCFR(arg1, Code, arg2) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond1&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=QcRes&user=Lic&status=NOCCFR&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRBrn(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + arg1 + "&Code=" + Code + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenCFRres(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
        //Added by usha for NOC 19.07.015
        function funcopenCFRNOCres(arg1, Code,ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            //document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&Mode=NOCCLOSED&mdlpopup=MdlPopRaiseSub";commented by ajay 02 062023
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&CndNo=" + arg1 + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=QcRes&user=Lic&Mode=NOCCLOSED&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRNOCres1(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&Mode=NOC&mdlpopup=MdlPopRaiseSub";
        }
        //        //        added by usha for licteam inbox om 14.8.015
        function funcopenCFRNOCresSM(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondSM&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=SM&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRNOCresFSM(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            //url changes by ajay 19042023
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=SMR&mdlpopup=MdlPopRaiseSub&Mode=NOCCLOSED&user=Lic&flag=nocview";
            //document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondFSM&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=SMR&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRNOCIN(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=funcopenCFRNOCIN&CndNo=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
        //ended by usha 

        //added by sanoj 14102022 
        function changstyle(parm) {
            debugger;
            alert("OK");
            //nFilter.setAttribute("style", "width:330px;float:left;");
        }
       
         //endded by sanoj 14102022
    </script>

    <style type="text/css">
    .clscenter{
        text-align:center!important;
    }
        .clsleft {
            text-align:left!important;
            padding: 9px;
        }

 .gridview th {
    padding: 5px;
    height: 40px;
    /* background-color: #53accd !important; */
    /* color: #f2f2f2; */
    border-color: #53accd !important;
    text-align: left;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
    /* border-top: 1px solid #ccc; */
}
 .pad{
	 text-align:left !important;
 }
 .pad1{
	 text-align:center !important;
 }
   </style>

    <asp:ScriptManager ID="sm50HrsSearch" runat="server">
    </asp:ScriptManager>

    <%-- <asp:UpdatePanel ID="up_prospect" runat="server">
            <ContentTemplate>--%>
    <%--      <div class="page-container" style="margin-top: 0px;">--%>

    <div class="card PanelInsideTab" > <%--style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;background-color: white;"--%>
        <%-- <table class="container" width="80%">--%>
        <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trSearchDetails','btnWfParam');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="lblTitle" runat="server" Font-Size="19px"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="trSearchDetails" runat="server" class="panel-body panelContent">
         
          <%--  start added by sanoj for Qc Search- 29092022--%>
             <div class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                    <asp:Label ID="lblCandidateCode" CssClass="control-label" runat="server"></asp:Label>
          
                    <asp:TextBox ID="txtCndNo" runat="server" CssClass="form-control" placeholder="Candidate Number" MaxLength="10"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                        ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtCndNo" FilterType="Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                    <div class="col-sm-4" style="text-align: left">
                    <asp:Label ID="lblAppNo" runat="server" CssClass="control-label"></asp:Label>

                      <asp:TextBox ID="txtAppNo" runat="server" placeholder="Application Number" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                        ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtAppNo" FilterType="Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblGivenName" runat="server" CssClass="control-label"></asp:Label>
                       <asp:TextBox ID="txtName" runat="server" placeholder="Given Name" CssClass="form-control" MaxLength="60"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_txtName" runat="server"
                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtName">
                    </ajaxToolkit:FilteredTextBoxExtender>
                   </div>
                 
                 </div>

              <div class="row rowspacing" >
                    <div class="col-sm-4" style="text-align: left">
                   <asp:Label ID="lblSurName" runat="server" CssClass="control-label"></asp:Label>
                    <asp:TextBox ID="txtSurname" runat="server" placeholder="Surname"  CssClass="form-control" MaxLength="60"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtSurname">
                    </ajaxToolkit:FilteredTextBoxExtender>
                   </div>
                    <div class="col-sm-4" style="text-align: left">
                      <asp:Label ID="lblProcessType" runat="server" CssClass="control-label"  Text="Process Type"></asp:Label>
                      <asp:DropDownList ID="ddlProcessType" runat="server" AutoPostBack="false" CssClass="form-control form-select">
                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        <asp:ListItem Text="Fresh" Value="F"></asp:ListItem>
                        <asp:ListItem Text="Composite" Value="C"></asp:ListItem>
                        <asp:ListItem Text="Transfer" Value="T"></asp:ListItem>
                        <asp:ListItem Text="ReExam" Value="RE"></asp:ListItem>
                        <asp:ListItem Text="Retrieval" Value="RW"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                    <div class="col-sm-4" style="text-align: left">
                    <asp:Label ID="lblAgntBroker" runat="server" Text="Agent Broker Code" CssClass="control-label"></asp:Label>
              
                    <asp:TextBox ID="txtAgntBroker" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            
               </div>
             <div class="row rowspacing" id="SapRow" runat="server">
                   <div class="col-sm-4" style="text-align: left">
                    <asp:Label ID="lblSapcode" runat="server" Text="SAP Code" CssClass="control-label"></asp:Label>
                
                    <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                   <div class="col-sm-4" style="text-align: left">
                      <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label"> </asp:Label>
                    <asp:TextBox ID="txtDTRegFrom" TextMode="DateTime" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                   <div class="col-sm-4" style="text-align: left">
                      <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label"></asp:Label>
                    <asp:TextBox ID="txtDTRegTo" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                 </div>
            
        

              <div class="row rowspacing" id="PanRow" runat="server">
                  <div class="col-sm-4" style="text-align: left">
                       <asp:Label ID="lblPan" runat="server" CssClass="control-label"></asp:Label>
               
                    <asp:TextBox ID="txtPan" runat="server" placeholder="Pan No" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="col-sm-4" style="text-align: left; display:none;" >
                       <asp:Label ID="lblReqStatus" runat="server" CssClass="control-label"></asp:Label>
               
                    <asp:DropDownList ID="ddlreqstatus" runat="server" placeholder="Request Status" CssClass="form-control">
                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                        <asp:ListItem Text="Requested" Value="Req"></asp:ListItem>
                        <asp:ListItem Text="New Request" Value="New"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                  <div class="col-sm-4" style="text-align: left;">  <%--display none by sanoj --%> 
                      <asp:Label ID="lblShwRecords" runat="server"  CssClass="control-label"></asp:Label>
               
                    <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                    </asp:DropDownList>
                  </div>

                 <div class="col-sm-4" style="text-align: left;">
                      <asp:Label ID="lblURN" runat="server" Text="URN No" CssClass="control-label"></asp:Label>
              
                    <asp:TextBox ID="txtURN" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
            


                  
            </div>
                  <div class="row rowspacing" style="display:none">
                    <div class="col-sm-4" style="text-align: left">
                       <asp:Label ID="lblRecruiterName" runat="server" CssClass="control-label"></asp:Label>
               
                    <asp:TextBox ID="txtRecruiterName" runat="server" placeholder="Recruiter Name" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtRecruiterName">
                    </ajaxToolkit:FilteredTextBoxExtender>
                  </div>
                
                    
                    <div class="col-sm-4" style="text-align: left">
                      <asp:Label ID="lblBranchName" runat="server" CssClass="control-label" ></asp:Label>
                      <asp:TextBox ID="txtBranchName" runat="server" placeholder="Branch Name" CssClass="form-control" MaxLength="60"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '&" TargetControlID="txtBranchName">
                    </ajaxToolkit:FilteredTextBoxExtender>
                  </div>
              

            </div>

            

            <%--  End added by sanoj for Qc Search- 29092022--%>
            <div class="row" style="display:none;">
               
               
                <div class="col-sm-3">
                    
                </div>
                <%--<tr>
                                    <td class="formcontent" align="left" style="width: 20%">
                                        <asp:Label ID="lblGivenName" runat="server" Font-Bold="False"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="standardtextbox" MaxLength="60"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_txtName" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td class="formcontent" align="left" style="height: 24px">
                                        <asp:Label ID="lblSurName" runat="server" Font-Bold="False"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="height: 24px; width: 243px;" align="left">
                                        <asp:TextBox ID="txtSurname" runat="server" CssClass="standardtextbox" MaxLength="60"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtSurname">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>--%>

                <div class="col-sm-3" style="text-align: left">
                   
                </div>
                <div class="col-sm-3">
                    
                </div>
              
                    
               
            </div>

            <div id="trregstrtndt" runat="server" class="row" visible="false">
                <div class="col-sm-3" style="text-align: left">
                    
                </div>
                <div id="Div3" class="col-sm-3" style="text-align: left" runat="server">
                    
                </div>
            </div>
            <div id="trtraning" runat="server" class="row">
                <div class="col-sm-3" style="text-align: left">
                   
                </div>
                <div id="tdreq" class="col-sm-3" style="text-align: left" runat="server">
                    
                </div>
                <div id="tdreqsta" runat="server" class="col-sm-3">
                    
                </div>
            </div>
            <div id="trCodedlicdetails" runat="server" class="row" visible="false">
             
               
            </div>
            <div id="TrForSpon" runat="server" class="row">
                <div class="col-sm-3" style="text-align: left">
                    
                </div>
                <div class="col-sm-3">
                   
                </div>
                <div id="tdPan" class="col-sm-3" style="text-align: left">
                   
                </div>
            </div>
            <div id="trURN" runat="server" class="row" visible="false">
                <div id="Div4" class="col-sm-3" style="text-align: left">
                   
                </div>
            </div>
            <div id="trReq" visible="False" class="row" runat="server">
                <div class="col-sm-3" style="text-align: left">
                   
                </div>
            </div>
            <div id="trShw" runat="server" class="row">
                <div class="col-sm-3" style="text-align: left">
                    
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblRequestDate" runat="server" CssClass="control-label"> </asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtReqDate" runat="server" CssClass="form-control" MaxLength="10"
                        TabIndex="12" />
                </div>
            </div>
            <div class="row">
                <center>
                                        <div class="col-sm-12" style='margin-top:15px;'>
                                            <asp:LinkButton ID="btnSearch" OnClientClick="return validtab();" OnClick="btnSearch_Click"
                                                CssClass="btn btn-success  " runat="server">
                                                <asp:HiddenField ID="TabName" runat="server" />
                                                <span class="glyphicon glyphicon-search BtnGlyphicon"></span> SEARCH
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-clear"
                                                runat="server">
                             <span style="color:#f04e5e"> </span> CLEAR </asp:LinkButton>
                                            <asp:LinkButton ID="btnReFresh" runat="server" CssClass="btn btn-clear " Style="display: none;"
                                                ClientIDMode="Static" OnClick="btnReFresh_Click" />
                                            <div id="divloader" runat="server" style="display: none;">
                                                <caption>
                                                    <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                                    Loading...
                                                </caption>
                                            </div>
                                        </div>
                                      
                                          

                                    </center>

            </div>
            <br />
            <div id="trnote" runat="server" class="col-sm-12" style="margin-bottom: 5px; text-align: center;">
                <asp:Label ID="Label2" runat="server" Text=""
                    ForeColor="black"> 	</asp:Label>
            </div>

            <div id="trRecord" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                <asp:Label ID="lblMessage" runat="server" CssClass="standardlabelErr"></asp:Label>
            </div>

        </div>
        <%--</div>--%>
    </div>
    <%-- added by sanoj qc search pannel--%>

     <%-- added by sanoj qc search pannel--%>
    
    <%--     </div>--%>
    <div id="trDgViewDtl" runat="server" visible="false">
        <div class="card PanelInsideTab" > <%--style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%"--%>

            <div id="trtitle" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trgridsponsorship','ctl00_ContentPlaceHolder1_Span4');return false;">

               




                <div class="row" id="trDetails" runat="server">
                    <div class="col-sm-7" style="text-align: left">
                        <asp:Label ID="lblprospectsearch" runat="server" Font-Size="19px" Text="Sponsorship Search Results"></asp:Label>
                    </div>
                    <%--<div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                                    BackColor="#034ea2"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" Text="CFR Raised" Visible="false">
                                          </asp:Label>
                                                  <asp:Label ID="Label7" runat="server" Visible="false"></asp:Label>    
                                            </div>--%>
                    <div class="col-sm-3" style="text-align: left ;margin-left: 89px;">
                        <div id="lired" runat="server" visible="false">
                            <%--<li id="lired" runat="server" visible="false">--%>
                            <asp:Label ID="lired1" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                BackColor="Orange"></asp:Label>
                            <asp:Label ID="lblCFR" runat="server" style=" font-size: 14px; " Text="CFR RAISED">

                            </asp:Label>
                             <asp:Label ID="Label6" Visible="true" runat="server" BackColor="LightGreen" CssClass="control-label" Width="20px" Height="12px"></asp:Label>
                            <asp:Label ID="Label7" Visible="true" runat="server" CssClass="control-label" Text="CFR RESPONDED">       </asp:Label>
                        </div>
                        <%--</li>--%>
                        <div id="ligreen" runat="server" visible="false">
                            <%-- <li id="ligreen" runat="server" visible="false">--%>
                            <asp:Label ID="txtQCColr" Visible="false" runat="server" BackColor="LightGreen" CssClass="control-label" Width="20px" Height="12px"></asp:Label>
                            <asp:Label ID="lblQC" Visible="false" runat="server" CssClass="control-label" Text="Second QC">
                            </asp:Label>
                        </div>
                        <%--  </li>--%>
                    </div>
                    <div class="col-sm-1">
                        <span id="Span4" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>

            </div>
            <%--<div id="" runat="server" style="margin-left: 20px; margin-right: 20px; margin-top: 10px">--%>
                  <div id="trgridsponsorship" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px"> <%--class ="card" --%>
                <%--<asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                                                <ContentTemplate>--%>
                <div style="width: 100%; overflow-x: scroll">
                    <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="footable"
                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" 
                        OnSorting="dgView_Sorting" OnRowCommand="dgView_RowCommand" OnRowDataBound="dgView_RowDataBound" RowStyle-CssClass="dgViewGrid" >
                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                        <PagerStyle CssClass="disablepage" />
                        <HeaderStyle CssClass="gridview th" />
                        <Columns>
                            <asp:BoundField DataField="AppNo" HeaderStyle-CssClass="pad1"   HeaderText="Application No"
                                SortExpression="AppNo">
                                <ItemStyle CssClass="clscenter"/>
                                 <HeaderStyle CssClass="clscenter" />
                            </asp:BoundField>
                            <asp:TemplateField   HeaderText="Candidate ID"
                                SortExpression="CndNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblCndNo"   runat="server" CommandArgument='<%# Eval("CndNo") %>' Text='<%# Eval("CndNo") %>'></asp:Label>
                                </ItemTemplate>
								 <ItemStyle CssClass="clscenter"/>
                                 <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="GivenName"   HeaderText="Candidate Name"
                                SortExpression="GivenName">
                                 <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Branch"   HeaderText="Branch Name" SortExpression="Branch">
                               <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Channel"   HeaderText="Sales Channel"
                                SortExpression="Channel" Visible="false">
                              <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="smcode"   HeaderText="Reporting SM Code"
                                SortExpression="smcode" Visible="false">
                               <ItemStyle CssClass="clscenter"/>
                                 <HeaderStyle CssClass="clscenter" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Recruiter"   HeaderText="Recruiter Name"
                                SortExpression="Recruiter">
                                <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status"   HeaderText="Request Status"
                                SortExpression="Status">
                               <ItemStyle CssClass="clsLeft"/>
                                 <HeaderStyle CssClass="clsLeft" />
                            </asp:BoundField>
                            <asp:TemplateField   HeaderText="Request Date" SortExpression="RequestDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblSponDate" runat="server" Text='<%# Eval("RequestDate","{0:dd/MM/yyyy}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="clscenter"/>
                               <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PAN"   SortExpression="PAN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPan" runat="server" Text='<%# Eval("PAN No") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle CssClass="clscenter"/>
                               <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblRenwlQCFlag" runat="server" Text='<%#Bind("RnwlQCFlag") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" CssClass="pad1" />
                            </asp:TemplateField>
                            <asp:TemplateField   HeaderText="SAP Code" 
                                SortExpression="Agent_SAPCODE" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="clscenter"/>
                               <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:TemplateField   HeaderText="Broker Code"
                                  SortExpression="Agent_Broker_Code" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                        ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle CssClass="clscenter"/>
                               <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action"      SortExpression="Request">
                                <ItemTemplate>
                                    <div style="white-space: nowrap; width: 100%;">
                                        
                                        <asp:LinkButton ID="lblRequest" CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("CndNo") %>'
                                            CommandName="ReqClick" Text='<%# Eval("Request") %>'> <span class="glyphicon glyphicon-pencil" style="color: black!important;"></span></asp:LinkButton>
                                    </div>
                                    <asp:HiddenField ID="hdnAgentCode" runat="server" Value='<%# Eval("CndNo") %>' />
                                    <asp:HiddenField ID="hdnDRF" runat="server" Value='<%# Eval("DRF") %>' />
                                    <asp:HiddenField ID="hdnMock" runat="server" Value='<%# Eval("Mock") %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="clscenter"/>
                               <HeaderStyle CssClass="clscenter" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="pad" HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div>
                    <center>
                                                  

                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                        background-color: transparent; float: left; margin: 0; height: 34px;" OnClick="btnprevious_Click" />
                                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 40px; border-style: solid;
                                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                                        text-align: center;"  ReadOnly="true" />
                                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                        float: left; margin: 0; height: 34px;" Width="40px" OnClick="btnnext_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                </div>
                <%--</ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>
                <%--
                                                <div class="row">
                                                    <ul style="list-style-type:disc">--%>

                <%--   <li id="lired" runat="server" visible="false">
                                                            <asp:Label ID="txtCFRcolr" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                                                BackColor="Orange"></asp:Label>
                                                            <asp:Label ID="lblCFR" runat="server" Text="CFR Raised">
                                                            </asp:Label></li>
                                                        <li id="ligreen" runat="server" visible="false">
                                                            <asp:Label ID="txtQCColr"  runat="server" BackColor="LightGreen" CssClass="control-label"  Width="20px" Height="12px"></asp:Label>
                                                            <asp:Label ID="lblQC" runat="server" CssClass="control-label" Text="Second QC">
                                                            </asp:Label></li>--%>
                <%-- </ul>
                                                
                                            </div>--%>
                <br />

                <div class="col-sm-3" style="text-align: left" style="display: none">


                    <asp:Label ID="lblPageInfo" runat="server" Visible="false"></asp:Label>
                </div>
                <div id="divloadergrid" class="col-sm-12" runat="server" style="display: none;">
                    <caption>
                        <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                        Loading...
                    </caption>
                </div>


            </div>





            <%-- <tr ID="tr1" runat="server" class="formcontent">
                                        <td align="center">
                                            <div ID="divloadergrid" runat="server" style="display:none;">
                                                &nbsp;&nbsp;
                                                <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                                                Loading...
                                            </div>
                                        </td>
                                    </tr>--%>
            <div id="trbtnexport" visible="false" runat="server" class="col-sm-12">
                <div class="btn default btn-xs" style="white-space: nowrap; width: 124px;">
                    <i class="fa fa-table"></i>
                    <asp:LinkButton ID="btnExport" runat="server" CssClass="btn default btn-xs" OnClick="btnExport_Click"
                        Text="Export to Excel" Width="114px" />
                </div>
                <asp:LinkButton ID="btnjs" runat="server" Text="js" Visible="false" />
                <caption>
                    &nbsp;</caption>
            </div>

        </div>
    </div>
    <%-- </table>
                            </td>
                        </tr>
                    </caption>
                </table>
    --%>


    <div id="divBrnuser" runat="server">
        <%--class="page-container" style="margin-top: 0px;"--%>
        <div class="card" style="margin-left: 5%; margin-right: 5%; margin-top: 0.5%">
            <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divIRCC','btnDeptMstGrd');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label3" runat="server" Text="View CFR Search Result" CssClass="control-label" Font-Size="19px">
                        </asp:Label>
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnDeptMstGrd" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divIRCC" runat="server" style="padding: 1%" role="tabpanel">

                <ul class="nav nav-tabs">
                    <li runat="server" id="inbox" class="active "> 
                        <a id="LinkButton1" runat="server" aria-controls="menu1"
                        data-toggle="tab" href="#menu1">Raised CFR </a>
                    </li>
                    <li runat="server" id="responded" ><a id="LinkButton2" runat="server" aria-controls="menu2"
                        data-toggle="tab" href="#menu2">Responded CFR</a></li>
                    <li runat="server" id="closed" style="display:none;" ><a id="LinkButton3" runat="server" data-toggle="tab"
                        aria-controls="menu3" href="#menu3">Close</a></li>
                    <li runat="server" id="cfr" style="display:none;" ><a id="LnkCFR_Inbox" runat="server" data-toggle="tab"
                        aria-controls="menu4" href="#menu4">CFR</a></li>
                </ul>

                <div class="tab-content">

                    <div id="menu1" class="tab-pane fade in active">
                        <asp:UpdatePanel ID="updInbox" runat="server">
                            <ContentTemplate>
                                <div style="overflow-x: scroll">
                                    <asp:GridView ID="GridInbox" runat="server" AllowSorting="True" CssClass="footable" Style="border-bottom-color: black;"
                                        AllowPaging="true" PagerStyle-HorizontalAlign="Center" HorizontalAlign="center"
                                        AutoGenerateColumns="False" OnPageIndexChanging="GridInbox_PageIndexChanging"
                                        OnRowCommand="GridInbox_RowCommand" OnRowDataBound="GridInbox_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField SortExpression="AppNo" HeaderText="App No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("AppNo") %>' CommandArgument='<%# Eval("AppNo") %>'
                                                        CommandName="Click_AppNo"></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle CssClass="clscenter"/>
                                                <HeaderStyle CssClass="clscenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("CndNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clscenter"/>
                                                <HeaderStyle CssClass="clscenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndName" HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("CndName") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="UnitLegalName" HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("UnitLegalName") %>'></asp:Label>
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:BoundField SortExpression="CFRRaised" HeaderText="Total CFR Raised" DataField="CFRRaised"
                                                Visible="false">
                                               <ItemStyle CssClass="clscenter"/>
                                            </asp:BoundField>
                                            <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                <ItemTemplate>
                                                    <div style="width: 100%; white-space: nowrap;">
                                                        <span class="glyphicon glyphicon-flag"></span>
                                                        <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                            CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                 <ItemStyle CssClass="clscenter"/>
                                                <HeaderStyle CssClass="clscenter" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <center>
                                        <table id="InboxPage" runat="server" visible="false">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious1" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;"
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtprevious1" Text="1" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                        text-align: center;" ReadOnly="true" />
                                                    <asp:Button ID="btnnext1" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 33px;" Width="40px"
                                                        OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<div id="divCFR" runat="server" visible="false" colspan="6" style="height: 18px;
                                    text-align: center;">
                                    <asp:Label ID="lblCFRMsg" runat="server" Text="0 Record Found"  CssClass="standardlabelErr"></asp:Label>
                                </div>--%>
                        <div id="trInboxMsg" runat="server" visible="false" style="text-align: center">
                            <asp:Label ID="Label5" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                        </div>
                    </div>
                    <div id="menu2" class="tab-pane fade">
                        <asp:UpdatePanel ID="updRespond" runat="server">
                            <ContentTemplate>
                                <div style="overflow-x: scroll">
                                    <asp:GridView ID="GridResponded" runat="server" AllowSorting="True" CssClass="footable"
                                        AllowPaging="true" PagerStyle-HorizontalAlign="Center" 
                                        HorizontalAlign="center" AutoGenerateColumns="False" OnPageIndexChanging="GridResponded_PageIndexChanging"
                                        OnRowDataBound="GridResponded_RowDataBound" OnRowCommand="GridResponded_RowCommand">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField SortExpression="AppNo" HeaderText="App No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("AppNo") %>' CommandArgument='<%# Eval("AppNo") %>'
                                                        CommandName="Click_AppNo"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clscenter" />
                                                        <HeaderStyle CssClass="clscenter" />
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("CndNo") %>' CommandArgument='<%# Eval("CndNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle CssClass="clscenter" />
                                                        <HeaderStyle CssClass="clscenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndName" HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("CndName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="UnitLegalName" HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("UnitLegalName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                            </asp:TemplateField>
                                            <asp:BoundField SortExpression="cfrresponded" HeaderText="Total CFR Raised" DataField="CFRResponded"
                                                Visible="false">
                                            </asp:BoundField>
                                            <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                <ItemTemplate>
                                                    <div style="width: 100%; white-space: nowrap;">
                                                        <span class="glyphicon glyphicon-flag"></span>
                                                        <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                            CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                                <ItemStyle CssClass="clscenter" />
                                                <HeaderStyle CssClass="clscenter" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <center>
                                        <table id="ResPage" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious2" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;"
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtResponded" Text="1" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                        text-align: center;"  ReadOnly="true" />
                                                    <asp:Button ID="btnnext2" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 33px;" Width="40px"
                                                        OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="divRes" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                            <asp:Label ID="lblResMsg" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                        </div>
                    </div>
                    <div id="menu3" class="tab-pane fade">
                        <asp:UpdatePanel ID="updClose" runat="server">
                            <ContentTemplate>
                                <div style="overflow-x: scroll">
                                    <asp:GridView ID="GridClosed" runat="server" AllowSorting="True" CssClass="footable"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        OnPageIndexChanging="GridClosed_PageIndexChanging" AllowPaging="True" OnRowDataBound="GridClosed_RowDataBound"
                                        PageSize="10">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField SortExpression="AppNo" HeaderText="App No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("AppNo") %>' CommandArgument='<%# Eval("AppNo") %>'
                                                        CommandName="Click_AppNo"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("CndNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndName" HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("CndName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="UnitLegalName" HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("UnitLegalName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField SortExpression="CFRClosed" HeaderText="Total CFR Raised" DataField="CFRClosed"
                                                Visible="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField SortExpression="Request" HeaderText="">
                                                <ItemTemplate>
                                                    <span class="glyphicon glyphicon-blackboard"></span>
                                                    <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                        CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <%--<RowStyle CssClass="sublinkodd"></RowStyle>
                                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                    </PagerStyle>
                                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <center>
                                  
                                        <table id="ClosedPage" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnPreClosed" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;"
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtClosed" Text="1" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                        text-align: center;" ReadOnly="true" />
                                                    <asp:Button ID="btnNextClosed" Text=">" CssClass="form-submit-button" runat="server"
                                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;" Width="40px"
                                                        OnClientClick="return validtab();"
                                                        OnClick="btnnextMenu_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                        <div id="divclose" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                            <asp:Label ID="lblclose" runat="server" Text="0 record found" CssClass="standardlabelerr"></asp:Label>
                        </div>
                    </div>
                    <div id="menu4" class="tab-pane fade">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div style="overflow-x: scroll">
                                    <asp:GridView ID="GridCFR" runat="server" AllowSorting="True" CssClass="footable"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="true" OnPageIndexChanging="GridCFR_PageIndexChanging"
                                        OnRowDataBound="GridCFR_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField SortExpression="AppNo" HeaderText="App No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("AppNo") %>' CommandArgument='<%# Eval("AppNo") %>'
                                                        CommandName="Click_AppNo"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("CndNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CndName" HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("CndName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="UnitLegalName" HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("UnitLegalName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="Request" HeaderText="">
                                                <ItemTemplate>
                                                    <div style="width: 100%; white-space: nowrap;">
                                                        <span class="glyphicon glyphicon-blackboard"></span>
                                                        <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                            CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                                <div>
                                    <center>
                                         
                                        <table id="CFRPage" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnPreCFR" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;" 
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtCFR" Text="1" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnNextCFR" Text=">" CssClass="form-submit-button" runat="server"
                                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 33px;" Width="40px"
                                                     OnClientClick="return validtab();"   OnClick="btnnextMenu_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                </div>
                                </center>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="divCFRS" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                            <asp:Label ID="lblCFRS" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdnCndNo" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnCndName" runat="server" />
            </td>
            <td></td>
            <td>
                <asp:HiddenField ID="hdnTrnReqDt" runat="server" />
            </td>
            <%--Added by rachana on 22-08-2013 for branched user start--%>
            <td></td>
            <td>
                <asp:HiddenField ID="hdnName" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnCandCode" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnRecruiterCode" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnMenuName" runat="server" />

                <input type="hidden" id="hdnEmpName" runat="server" />
            </td>
            <%--Added by rachana on 22-08-2013 for branched user end--%>
        </tr>
    </table>

    <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>

    <%--rachana..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="518px" display="none">
        <iframe runat="server" id="IframeRaiseCFR" frameborder="0" display="none" style="width: 537px; height: 463px"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        DropShadow="false" TargetControlID="Label1" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="PnlRaiseSub" Width="75%" Height="50%" display="none">
        <iframe runat="server" id="IframeRaiseSub" width="100%" frameborder="0" display="none"
            style="height: 384%; margin-top: -116px;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
        TargetControlID="lblSub" PopupControlID="PnlRaiseSub" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%-- DropShadow="true"--%>
    <%--Shreela  for QC...End--%>
</asp:Content>

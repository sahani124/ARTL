
<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="NOCApprovalTeam.aspx.cs"
    Inherits="Application_ISys_Recruit_NOCApprovalTeam" Title="Untitled Page" %>

<%--<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />

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

 <%--   <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
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
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>



     <script language="javascript" type="text/javascript">

          $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            debugger; 
            $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: new Date(currentYear, currentMonth, currentDate)
            
            });
        });
         function AnnvDte() {
             debugger;
             var date = new Date();
             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();
             $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                 changeYear: true,
                 maxDate: new Date(currentYear, currentMonth, currentDate)
             });
         }
         function AnnvDte1() {
             debugger;
             var date = new Date();
             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();
             $("#<%= txtDTRegTo.ClientID  %>").datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                 changeYear: true,
                 maxDate: new Date(currentYear, currentMonth, currentDate)
             });
         }

        $(function () {
             var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            debugger;

            $("#<%= txtDTRegTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: new Date(currentYear, currentMonth, currentDate)
            }); //txtReqDate

        });
        $(function () {
            debugger;

            $("#<%= txtReqDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true }); //txtReqDate

        });

         function popup() {
             $("#myModal1").modal();
         }
        $(function () {
            // debugger;
            $('#<%=dgDetails.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000
                }
            });
        });
        $(document).ready(function () {
            debugger;
           // alert ('pallavi')
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
            //alert('ajay');
            debugger;
            if ($('#ctl00_ContentPlaceHolder1_LinkButton1').attr('aria-expanded') === 'true') {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('1');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else if ($('#ctl00_ContentPlaceHolder1_LinkButton2').attr('aria-expanded') === 'true') {
                debugger;
               // alter ('Hi')
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('2');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu2";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

            else if ($('#ctl00_ContentPlaceHolder1_LinkButton3').attr('aria-expanded') === 'true') {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('3');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu3";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else if ($('#ctl00_ContentPlaceHolder1_LnkCFR_Inbox').attr('aria-expanded') === 'true') {

                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('4');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu4";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else {
               // alert('hii');
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('0');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
                $('#ctl00_ContentPlaceHolder1_divIRCC a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divIRCC a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

        }

        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }


        var path = "<%=Request.ApplicationPath.ToString()%>";

        function poponload(window) {
        
            window.moveTo(0, 0);

        }
    <%--    $(function () {
            debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' }); });
        $(function () {
            debugger;

            $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' }); //txtReqDate

        });
        $(function () {
            debugger;

            $("#<%= txtReqDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' }); //txtReqDate

        });--%>

       
        //popup added by rachana to show CFR for admin and other user with status raised,responded,closed start
        
        function funcShowPopupCFR(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFRDetail") {
           // $find("MdlPopRaiseCFR1").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/PopCFRAssigned.aspx?CndNo=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseSub";
                // agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user +"&mdlpopup=MdlPopRaiseCFR";
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
     


        function funcopenNOC(arg1, status, Code) {
            debugger;
            //// $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOC.aspx?TrnRequest=QCNoc&CndNo=" + arg1 + "&Status=" + status + "&Code=" + Code + "&Type=QCNoc&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenCFR(arg1, Code, arg2) {
            debugger;
            /////$find("MdlPopRaiseSubB").show();

            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRCVR&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=CFR&Status=CVR&mdlpopup=MdlPopRaiseSub";
        }


        function funcShowPopup(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFR") {
                // $find("MdlPopRaiseCFR1").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/PopCFRAssigned.aspx?CndNo=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseSub";
                //agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
            }
        }

        function funcopenCFRres(arg1, Code, arg2, arg3) {
            debugger;
            // $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRRespond1&CndNo=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&UserId=" + arg3 + "&Type=Res&status=NOCCFR&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenCFRBrn(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + arg1 + "&Code=" + Code + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub";
        }


        function ShowReqDtl12(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
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
        function popup1(Msg) {
            debugger;
            //alert('ok')
            //document.getElementById("myModal12").style.display = 'block';
            document.getElementById("myModal12").setAttribute('style', 'opacity:1.0;display:block');
            document.getElementById("ctl00_ContentPlaceHolder1_Label8");
                //setAttribute('style', 'font-weight:bold;text-align:center; margin-left: 73px;font-size: 19px;');
            document.getElementById("ctl00_ContentPlaceHolder1_lblus").innerHTML = Msg;
          // $("#myModal12").modal();
        }
        function popup2(Msg1) {
            debugger;
           // alter('Hi')
            document.getElementById("myModal1").setAttribute('style', 'opacity:1.0;display:block');
            document.getElementById("ctl00_ContentPlaceHolder1_Label1").setAttribute('style', 'font-weight:bold;text-align:center; margin-left:80px;font-size: 19px;color: #fff');
            document.getElementById("ctl00_ContentPlaceHolder1_lbl2").innerHTML = Msg1;
        }

        //function ClosePopup() {
        //    debugger;
        //    $("#mdlpopup1").hide();

        //}

        function CloseSub() {
          
            $("#myModal12").hide();

        }
        function CloseSub1() {

            $("#myModal1").hide();

        }
    </script>
    

     <style type="text/css">  
         
             /*.gridview th {
     padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
}*/
  .modal-dialog{
    position: relative;
    display: table;
    overflow-y: auto;    
    overflow-x: auto;
    width: auto;
    min-width: 50px;   
}
          .disablepage
        {
            display: none;
        }
         ul#menu {
    padding: 0;
       margin-right: 69%;
        }

ul#menu li {
    display: inline;
     
    
}

.clsCenter{
    text-align:center !important;
}

ul#menu li a {
    background-color:Silver;
    color: black;
    cursor:pointer;
    padding: 10px 20px;

    text-decoration: none;
    border-radius: 4px 4px 0 0;
}
ul#menu li a:active{background:white;}

ul#menu li a:hover {
    background-color: red;
}

.gridview th {
    padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: center;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
}

.position {
    position: absolute;
    top: 590px!important
}

        </style>
    <asp:ScriptManager ID="smNOCAPPSearch" runat="server">
    </asp:ScriptManager>
<%--=====================================Sarthak Changes Start===========================--%> 
    <asp:UpdatePanel ID="Updatepanel2" runat="server">  <%--CssClass="PanelInsideTab"--%>
       <ContentTemplate>
            <div class="card PanelInsideTab" id="divPannel1" runat="server" visible="true" style="margin-right:68px;margin-left:70px; margin-top: -3px;">
                    <div  class="row" style="display:none;">
                        <div class="col-sm-12" >
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                    <div id="Div1" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_trSearchDetails','btnWfParam');return false;">
                        <div class="row"> <%--rowspacing--%>
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblTitle" runat="server" Font-Bold="False" Font-Size="19px" style=" color:#00cccc; " ></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; color:#00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="trSearchDetails" style="display: block" runat="server" class="panel-body">
        <%--===========================================First Row Start====================================--%>
                        <div class="row rowspacing" style="text-align:left">
                            <div class="col-sm-4">
                                <asp:Label ID="lblCandidateCode" CssClass="control-label labelSize"  runat="server" ></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblAppNo" runat="server" CssClass="control-label labelSize"></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblGivenName" runat="server" CssClass="control-label labelSize"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtCndNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtCndNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtAppNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_txtName" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
        <%--===========================================First Row End====================================--%>

        <%--===========================================Second Row Start====================================--%>
                        <div class="row rowspacing" style="text-align:left">
                            <div class="col-sm-4">
                                <asp:Label ID="lblSurName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                            </div>
                            <div class="col-sm-4" id="lblrecnamehide" runat="server">
                                <%--<div id="trtraning" runat="server" class="row">--%>
                                <asp:Label ID="lblRecruiterName" runat="server" CssClass="control-label labelSize"></asp:Label>                                
                            </div>
                            <div class="col-sm-4" id="lblbrnamehide" runat="server">
                                <asp:Label ID="lblBranchName" runat="server" CssClass="control-label labelSize" ></asp:Label>                            
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtSurname">
                                </ajaxToolkit:FilteredTextBoxExtender>                            
                            </div>                        
                            <div class="col-sm-4" id="hiderecname" runat="server">
                                <asp:TextBox ID="txtRecruiterName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtRecruiterName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-4" id="hidebrname" runat="server">
                                <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control"  MaxLength="60"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '&" TargetControlID="txtBranchName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
        <%--===========================================Second Row End====================================--%>
                    <div id="trHideRows" runat="server">
        <%--===========================================Third Row Start====================================--%>
                        <div class="row rowspacing" style="text-align:left">
                            <div class="col-sm-4">
                                <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize" > </asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblDTRegTO" runat="server"  CssClass="control-label labelSize"></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblAgntBroker" runat="server" Text="Agent Broker Code" CssClass="control-label labelSize"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDTRegFrom" runat="server" placeholder="dd/mm/yyyy"  CssClass="form-control" onmousedown="AnnvDte();"></asp:TextBox>  <%--onmousedown="AnnvDte ();"--%>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDTRegTo" runat="server"  placeholder="dd/mm/yyyy"  CssClass="form-control" onmousedown="AnnvDte1();" ></asp:TextBox>  <%--onmousedown="AnnvDte1 ();"--%>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtAgntBroker" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
        <%--===========================================Third Row End====================================--%>

        <%--===========================================Fourth Row Start====================================--%>
                        <div class="row rowspacing" style="text-align:left">
                        <div class="col-sm-4">
                            <asp:Label ID="lblSapcode" runat="server" Text="SAP Code" CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblProcessType" runat="server"  CssClass="control-label labelSize" Text="Process Type"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblPan" runat="server" CssClass="control-label labelSize"></asp:Label>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlProcessType" runat="server" AutoPostBack="false" CssClass="form-control form-select">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="Fresh" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Composite" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Transfer" Value="T"></asp:ListItem>
                                <asp:ListItem Text="ReExam" Value="RE"></asp:ListItem>
                                <asp:ListItem Text="Retrieval" Value="RW"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtPan" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
        <%--===========================================Fourth Row End====================================--%>

        <%--===========================================Fifth Row Start====================================--%>
                        <div class="row rowspacing" style=" text-align:left">
                        <div class="col-sm-4">
                            <asp:Label ID="lblURN" runat="server" Text="URN No" CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblShwRecords" runat="server" CssClass="control-label labelSize"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="lblRequestDate" runat="server" CssClass="control-label labelSize"> </asp:Label>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtURN" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                                         
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtReqDate" runat="server" CssClass="form-control" MaxLength="10" TabIndex="12" />
                        </div>
                    </div>
        <%--===========================================Fifth Row End====================================--%>
                    </div>
        <%--========================changes Start=========================--%>                             
                    <div class="row" style="text-align:center; margin-top:35px;">
                        <div class="col-sm-12">
                            <asp:LinkButton ID="btnSearch" OnClientClick="return validtab();" OnClick="btnSearch_Click"
                                CssClass="btn btn-success" runat="server">
                                <span class="glyphicon glyphicon-search BtnGlyphicon"></span> 
                            <asp:HiddenField ID="TabName" runat="server" /> SEARCH </asp:LinkButton>
                            <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" 
                                CssClass="btn btn-clear" runat="server">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> CLEAR
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnReFresh" runat="server"  CssClass="btn btn-success"  style="display:none;"
                                ClientIDMode="Static" onclick="btnReFresh_Click"  />
                            <div id="divloader" runat="server" style="display:none;">
                                <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                            </div>
                        </div>           
                    </div>
                          <%--========================changes end=========================--%>                                   
                                <br />
                        <%-- <div id="trnote" runat="server" class="col-sm-12" style="margin-bottom: 5px;">
                          <asp:Label ID="Label2" runat="server" Text="Note: All dates are in (dd/mm/yyyy)"
                            ForeColor="Red"></asp:Label>
                    </div>--%>

                                 <div>
                            <div id="trmessage" runat="server"  colspan="6" style="height: 18px;
                                text-align: center;">
                               <%-- <img src="../Images/info-icon.gif" class="iconInfo" />--%>
                               
                                <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="standardlabelErr"></asp:Label>
                            </div>
                        </div>
                        </div>
                          <%--</div>--%>
            </div>
       </ContentTemplate>
    </asp:UpdatePanel>
<%--=====================================Sarthak Changes End===========================--%>
<asp:UpdatePanel ID="Updatepanel3" runat="server" >
    <ContentTemplate>
           <div  id="div5" runat="server"  class="card PanelInsideTab"  style="margin-left: 70px; overflow:auto;display:none;"  >  <%--class="card PanelInsideTab" width: 90% ;--%>
               <%--<asp:Panel ID="Panel2" Width="100%" runat="server" Style="overflow: hidden;">--%>
                   <div id="trDgViewDtl"  runat="server" visible="false">
                       <div id="trtitle" runat="server" class="panel-heading" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_trDgDetails','Span1');return false;">
                           <%-- <div id="trtitle" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','Span1');return false;">--%>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <ContentTemplate>
                                   <div class="row" id="trDetails" runat="server">
                                       <div class="col-sm-5" style="text-align: left">
                                           <span class=""></span>
                                           <asp:Label ID="lblprospectsearch" runat="server" Text="NOC Approval Search Results" Font-Size="19px"></asp:Label>
                                       </div>
                                       <div class="col-sm-3" style="text-align: left">
                                           <asp:Label ID="txtCFRcolr" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                               BackColor="Orange"></asp:Label>
                                           <asp:Label ID="lblCFR" runat="server" Text="CFR Raised" Visible="false">
                                           </asp:Label>
                                           <asp:Label ID="lblPageInfo" runat="server" Visible="false"></asp:Label>
                                       </div>
                                       <div class="col-sm-4">
                                           <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;  padding: 1px 10px ! important; font-size: 18px;margin-right: -182px;"></span>
                                       </div>
                                   </div>
                               </ContentTemplate>
                           </asp:UpdatePanel>
                       </div>
                       <div id="trDgDetails" runat="server"  style="width: 115%; margin-top: 10px;"><%-- ;overflow-x: scroll--%>
                           <asp:GridView ID="dgDetails" runat="server" AllowSorting="True" CssClass="footable"
                               AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" OnSorting="dgDetails_Sorting"
                               OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound">
                               <FooterStyle CssClass="GridViewFooter" />
                               <RowStyle CssClass="GridViewRowNew" />
                               <HeaderStyle CssClass="gridview th" />
                               <PagerStyle CssClass="disablepage" />
                               <SelectedRowStyle CssClass="GridViewSelectedRow" />
                               <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>

                               <Columns>
                                   <asp:TemplateField ItemStyle-Width="5%" >
                                       <ItemTemplate>
                                           <asp:UpdatePanel ID="updchk" runat="server">
                                               <ContentTemplate>
                                                   <asp:CheckBox ID="chkRejApp" runat="server" AutoPostBack="True"
                                                       OnCheckedChanged="chkRejApp_CheckedChanged" />
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                       </ItemTemplate>
                                       <ItemStyle Width="5%" CssClass="pad" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Candidate ID" SortExpression="CandidateNo" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="lbCndNo" runat="server" CommandArgument='<%# Eval("CndNo") %>' CommandName="click" Text='<%# Eval("CndNo") %>'>
                                           </asp:LinkButton>
                                       </ItemTemplate>
                                       <ItemStyle CssClass="clscenter"/> <%-- CssClass="pad"  Width="10%" --%>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Application No" SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="12%">
                                       <ItemTemplate>
                                           <asp:Label ID="lblappno" runat="server" Text='<%# Eval("AppNo") %>' ToolTip='<%# Eval("AppNo") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter"  />   <%-- ItemStyle-Width="12%" --%>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Name" ItemStyle-Width="9%" SortExpression="Givenname" HeaderStyle-HorizontalAlign="Center">
                                       <ItemTemplate>
                                           <asp:Label ID="lblNamePronoun" runat="server" Text='<%# Eval("GivenName") %>' ToolTip='<%# Eval("GivenName") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False"  CssClass="clscenter"/>  <%--HorizontalAlign="Left"--%>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Surname" ItemStyle-Width="9%" SortExpression="Surname" HeaderStyle-HorizontalAlign="Center">
                                       <ItemTemplate>
                                           <asp:Label ID="lbSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Reporting SM Name" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Center"
                                       SortExpression="RecruitAgtName">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("Recruiter") %>'
                                               ToolTip='<%# Eval("Recruiter") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter" />
                                   </asp:TemplateField>
                                   <%--added by usha --%>
                                   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SAP Code" HeaderStyle-Width="110px" ItemStyle-Width="12%"
                                      SortExpression="Agent_SAPCODE">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>'
                                               ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter" /> <%--Width="5%" --%>
                                   </asp:TemplateField>
                                   <%--column 13--%>
                                   <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                       HeaderText="Broker Code"   ItemStyle-Width="12%" SortExpression="Agent_Broker_Code">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAgtBrokerCode" runat="server"
                                               Text='<%# Eval("Agent_Broker_Code") %>'
                                               ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                       </ItemTemplate> <%-- HeaderStyle-Width="110px" Width="5%"  --%>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Actionable Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="12%" SortExpression="ActionableDate" > 
                                       <ItemTemplate>
                                           <asp:Label ID="lblSponDate" runat="server"
                                               Text='<%# Eval("RequestDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle Font-Bold="False" CssClass="clscenter" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Yes-Approve/No-Raise CFR"  HeaderStyle-HorizontalAlign="Center" >  <%--ItemStyle-Width="25%"--%>
                                       <ItemTemplate>
                                           <asp:RadioButtonList ID="rdbCFR" runat="server" AutoPostBack="true"
                                               OnSelectedIndexChanged="rdbCFR_SelectedIndexChanged"
                                               RepeatDirection="Horizontal">
                                               <asp:ListItem Text="Yes" Value="1" />
                                               <asp:ListItem Text="No" Value="0" />
                                           </asp:RadioButtonList>
                                       </ItemTemplate>
                                       <ItemStyle Width="5%" CssClass="clscenter" /> <%-- HeaderStyle-Width="110px"--%>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks"
                                       ItemStyle-Width="13%">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control"
                                               MaxLength="50" Width="200px" />
                                       </ItemTemplate>
                                       <HeaderStyle HorizontalAlign="Center" />
                                       <ItemStyle Width="23%" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderStyle-ForeColor="teal" HeaderText="Bank"
                                       ItemStyle-Width="6%" Visible="false">
                                       <ItemTemplate>
                                           <input type="button" id="btnVarify" value="Verify" class="form-control" width="50px"
                                               runat="server" />
                                       </ItemTemplate>
                                       <HeaderStyle ForeColor="Teal" />
                                       <ItemStyle Width="6%" />
                                   </asp:TemplateField>
                                   <asp:TemplateField Visible="false">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label>
                                       </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Left" />
                                   </asp:TemplateField>
                               </Columns>
                         </asp:GridView>
                           <br />
                            <center>
                           <table>
                               <tr>
                                   <td>
                                                                     <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                        background-color: transparent; float: left; margin: 0; height: 34px;" OnClick="btnprevious_Click" />
                                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                        float: left; margin: 0; height: 34px;" Width="40px" OnClick="btnnext_Click" />
                                   </td>
                               </tr>
                           </table>
 </center>
                           <div id="divloadergrid" class="col-sm-12" runat="server" style="display: none;">

                               <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                               Loading...
                           </div>


                           <div id="trbtnexport" visible="false" runat="server" class="col-sm-12">
                             <div class="btn default btn-xs" style="white-space: nowrap; width: 124px;">
                                   <i class="fa fa-table"></i>
                                   <asp:LinkButton ID="btnExport" runat="server" CssClass="btn default btn-xs"
                                       OnClick="btnExport_Click" Text="Export to Excel" Width="114px" />
                               </div>
                               <asp:LinkButton ID="btnjs" runat="server" Text="js" Visible="false" />
                               <%--</td>
                                                </tr--%>&nbsp;
                           </div>


                           <br />
                           <div id="trButton" style="padding-bottom: 6px" runat="server" class="col-sm-12" align="center">
                               <asp:LinkButton ID="btnReject" OnClick="btnReject_Click" Visible="False" CssClass="btn btn-primary"
                                   runat="server" >  <%--OnClientClick="StartProgressBar();"--%>
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Reject
                               </asp:LinkButton>
                               <asp:LinkButton ID="btnSubmit" OnClick="btnSubmit_Click" Visible="True" CssClass="btn btn-success"
                                   runat="server">   <%--OnClientClick="StartProgressBar();"--%>
                                 <span class="glyphicon glyphicon-saved" style='color:White;'> </span> SUBMIT
                               </asp:LinkButton>
                               <asp:LinkButton ID="btnCancel" OnClick="btnCancel_Click" Visible="True" CssClass="btn btn-clear"
                                   TabIndex="5" runat="server" >  <%-- style="color:#f04e5e;"--%>
                                 <span class="glyphicon glyphicon-remove" style="color:#d32020"> </span> CANCEL
                               </asp:LinkButton>
                               <%--</div>--%>
                           </div>
                           <br />
                       </div>
                   </div>
                   <div id="divBrnuser" runat="server"  class="PanelInsideTab" style="margin-top: 0px;" visible="false">  <%--class="page-container"--%>
                       <%--<div >--%>
                           <div id="Div4" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divIRCC','btnDeptMstGrd');return false;">
                               <div class="row">
                                   <div class="col-sm-10" style="text-align: left">
                                       <%--<span class=""></span>--%>
                                       <asp:Label ID="Label3" class=" control-label HeaderColor"  runat="server" Text="View CFR Search Results" Font-Size="19px" Style="margin-left:-68px;">
                                       </asp:Label>
                                       <asp:Label ID="Label4" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>
                                   </div>
                                   <div class="col-sm-2">
                                       <span id="btnDeptMstGrd" class="glyphicon glyphicon-chevron-up" style="float: right; color:  #00cccc; padding: 1px 10px ! important; font-size: 18px;margin-right: -74px;"></span>
                                   </div>
                               </div>
                           </div>
                           <div id="divIRCC" runat="server"  style="padding: 1%; display: block; margin-top: 35px;" role="tabpanel"> <%-- class="card"--%>

                               <ul class="nav nav-tabs">
                                   <li runat="server" id="inbox" class="active"><a id="LinkButton1" runat="server" aria-controls="menu1"
                                       data-toggle="tab" href="#menu1">Inbox</a></li>
                                   <li runat="server" id="responded"><a id="LinkButton2" runat="server" aria-controls="menu2" 
                                       data-toggle="tab" href="#menu2">Responded</a></li>  <%--onclick="validtab();" --%>
                                   <li runat="server" id="closed"><a id="LinkButton3" runat="server" data-toggle="tab"
                                       aria-controls="menu3" href="#menu3">Closed</a></li>
                                   <li runat="server" id="cfr"><a id="LnkCFR_Inbox" runat="server" data-toggle="tab"
                                       aria-controls="menu4" href="#menu4">CFR</a></li>
                               </ul>

                               <div class="tab-content">

                                   <div id="menu1" class="tab-pane fade in active" >  <%--style="overflow-x: scroll;"--%>
                                       <asp:UpdatePanel ID="updInbox" runat="server">
                                           <ContentTemplate>
                                               <asp:GridView ID="GridInbox" runat="server" AllowSorting="True" CssClass="footable"
                                                   AllowPaging="true" PagerStyle-HorizontalAlign="Center" HorizontalAlign="Left"
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
                                                       </asp:TemplateField>
                                                       <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No.">
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
                                                       <asp:BoundField SortExpression="CFRRaised" HeaderText="Total CFR Raised" DataField="CFRRaised"
                                                           Visible="false">
                                                           <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                       </asp:BoundField>
                                                       <asp:TemplateField SortExpression="Request" HeaderText="">
                                                           <ItemTemplate>
                                                               <div style="width: 100%; white-space: nowrap;">
                                                                   <span class="glyphicon glyphicon-flag"></span>
                                                                   <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                       CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                               </div>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                   </Columns>
                                               </asp:GridView>

                                                <center>
                                               <table id="InboxPage" runat="server" visible="false">
                                                   <tr>
                                                       <td>
                                                           <asp:Button ID="btnprevious1" Text="<" CssClass="form-submit-button" runat="server"
                                                               Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                           <asp:TextBox runat="server" ID="txtprevious1" Text="1" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                               CssClass="form-control" ReadOnly="true" />
                                                           <asp:Button ID="btnnext1" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               Width="40px"
                                                               OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                       </td>
                                                   </tr>
                                               </table>
                                                     </center>


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
                                   <div id="menu2" class="tab-pane fade in">
                                       <asp:UpdatePanel ID="updRespond" runat="server">
                                           <ContentTemplate>
                                               <asp:GridView ID="GridResponded" runat="server" AllowSorting="True" CssClass="footable"
                                                   AllowPaging="true" PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable"
                                                   HorizontalAlign="Left" AutoGenerateColumns="False" OnPageIndexChanging="GridResponded_PageIndexChanging"
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
                                                       </asp:TemplateField>
                                                       <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No.">
                                                           <ItemTemplate>
                                                               <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("CndNo") %>' CommandArgument='<%# Eval("CndNo") %>'></asp:Label>
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
                                                       <asp:BoundField SortExpression="cfrresponded" HeaderText="Total CFR Raised" DataField="CFRResponded"
                                                           Visible="false">
                                                           <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                       </asp:BoundField>
                                                       <asp:TemplateField SortExpression="Request" HeaderText="">
                                                           <ItemTemplate>
                                                               <div style="width: 100%; white-space: nowrap;">
                                                                   <span class="glyphicon glyphicon-flag"></span>
                                                                   <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                       CommandArgument='<%# Eval("CndNo") %>'></asp:LinkButton>
                                                               </div>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                   </Columns>
                                               </asp:GridView>
                                                 <center>
                                               <table id="ResPage" runat="server">
                                                   <tr>
                                                       <td>
                                                           <asp:Button ID="btnprevious2" Text="<" CssClass="form-submit-button" runat="server"
                                                               Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                           <asp:TextBox runat="server" ID="txtResponded" Text="1" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                               CssClass="form-control" ReadOnly="true" />
                                                           <asp:Button ID="btnnext2" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               Width="40px"
                                                               OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                       </td>
                                                   </tr>
                                               </table>
                                                       </center>

                                           </ContentTemplate>
                                       </asp:UpdatePanel>
                                       <div id="divRes" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                                           <asp:Label ID="lblResMsg" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                                       </div>
                                   </div>
                                   <div id="menu3" class="tab-pane fade in">
                                       <asp:UpdatePanel ID="updClose" runat="server">
                                           <ContentTemplate>
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
                                                       <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No.">
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



                                               <table id="ClosedPage" runat="server">
                                                   <tr>
                                                       <td>
                                                           <asp:Button ID="btnPreClosed" Text="<" CssClass="form-submit-button" runat="server"
                                                               Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                           <asp:TextBox runat="server" ID="txtClosed" Text="1" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                               CssClass="form-control" ReadOnly="true" />
                                                           <asp:Button ID="btnNextClosed" Text=">" CssClass="form-submit-button" runat="server"
                                                               Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               Width="40px"
                                                               OnClientClick="return validtab();"
                                                               OnClick="btnnextMenu_Click" />
                                                       </td>
                                                   </tr>
                                               </table>


                                           </ContentTemplate>

                                       </asp:UpdatePanel>
                                       <div id="divclose" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                                           <asp:Label ID="lblclose" runat="server" Text="0 record found" CssClass="standardlabelerr"></asp:Label>
                                       </div>
                                   </div>
                                   <div id="menu4" class="tab-pane fade in">
                                       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                           <ContentTemplate>
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
                                                       <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No.">
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
                                               <center>
                                               <table id="CFRPage" runat="server">
                                                   <tr>
                                                       <td>
                                                           <asp:Button ID="btnPreCFR" Text="<" CssClass="form-submit-button" runat="server"
                                                               Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                           <asp:TextBox runat="server" ID="txtCFR" Text="1" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                               CssClass="form-control" ReadOnly="true" />
                                                           <asp:Button ID="btnNextCFR" Text=">" CssClass="form-submit-button" runat="server"
                                                               Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                               Width="40px"
                                                               OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                       </td>
                                                   </tr>
                                               </table>
                                                   </center>

                                           </ContentTemplate>
                                       </asp:UpdatePanel>
                                       <div id="divCFRS" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                                           <asp:Label ID="lblCFRS" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                                       </div>
                                   </div>

                               </div>
                           </div>
                       <%--</div>--%>
                   </div>
               <%--</asp:Panel>--%>
           </div>
                
    </ContentTemplate>
</asp:UpdatePanel>                           
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnCndNo" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCndName" runat="server" />
                            </td>
                            <td>
                         
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTrnReqDt" runat="server" />
                            </td>

                            <td>
                          
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnName" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCandCode" runat="server" />
                            </td>
                            <td>
                              <asp:HiddenField ID="hdnMenuName" runat="server" />
                                <asp:HiddenField ID="hdnRecruiterCode" runat="server" />
                            </td>
                            <%--Added by rachana on 22-08-2013 for branched user end--%>
                        </tr>
                    </table>


          <%--  Added by usha for pop --%>
              <div class="modal fade position" id="myModal1" role="dialog" style="opacity:1.0;">  <%--position: absolute; top: 583px!important;--%>
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style="width: 316px;">
        <div class="modal-header" style="text-align: center;background-color:white;">  <%--background-color:#dff0d8;--%>
            <asp:Label ID="Label1" Text="INFORMATION" runat="server" class="control-label" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server" class="control-label"></asp:Label><br />
          <asp:Label ID="lbl2" runat="server" class="control-label"></asp:Label><br />
          <asp:Label ID="lbl4" runat="server" class="control-label"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
<%--          <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top:-6px;margin-right: 100px;'>--%>
                 <asp:LinkButton  runat="server" id="LinkButton4"  cssclass="btn btn-success" Text="OK" OnClientClick="CloseSub1()"
                        style="margin-top: -6px; margin-right: 105px;text-align:center;" >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
                      </asp:LinkButton> 

           <%--  </button>--%>
         
        </div>
      </div>
      
    </div>
  </div>

        <%--  ended  by usha for pop --%>

                
    
    <div class="panel panel-success" runat="server" ID="PnlRaiseSub" Width="1000px" display="none" >
         <asp:Panel runat="server">
        <iframe runat="server" id="IframeRaiseSub" frameborder="0" display="none" style="width:1000px;
            height: 500px"></iframe>
    </asp:Panel>
    </div>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
        TargetControlID="lblSub" PopupControlID="PnlRaiseSub">
    </ajaxToolkit:ModalPopupExtender>
          
       
        
     
    <%--rachana..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="518px" display="none">
        <iframe runat="server" id="IframeRaiseCFRTeam" frameborder="0" display="none" style="width: 518px;
            height: 350px"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lblsub123" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFRB"
        DropShadow="true" TargetControlID="lblsub123" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
   
    <%--loader image start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="hiddenField1" runat="server" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
                
                     
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                     
                </asp:Panel>
        <asp:UpdatePanel ID="pop1" runat="server">
        <ContentTemplate>
   <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder"   Width="25%" Height="40%" style="background-color: white">
         <div class="panel rcorners2" id="divAlert" runat="server" style="width:30%;
                display: block; border: 2px;border: 0px !important;
              " cellpadding="0" cellspacing="0">
                <div id="Div25" runat="server"   style="width:100% !important" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div id="Div26" runat="server">
                             <center style="color: #034ea2;font-size: 15px;padding:10px;margin-left: -38px;width: 100%;"  CssClass="control-label HeaderColor">INFORMATION</center>
                            </div>
                        </div>
        <table>
            <tr>
                <td style="width: 391px;">
                    <center >
                        <asp:Label ID="Label2" runat="server"  style="margin-left: -64px;"></asp:Label><br />
                    </center>
                    <br />
                     <center >
                        <asp:Label ID="Label6" runat="server" style="margin-left: -64px;"></asp:Label><br />
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
    
                <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Label2"
                    BehaviorID="mdlpopup" PopupControlID="pnl" BackgroundCssClass="modalPopupBg"
                    OkControlID="btnok" Y="100">
                   
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>



                <div class="modal fade" id="myModal12" role="dialog" style="opacity:1.0;padding-top: 853px!important;"> // <%--added by pallavi on 01012023--%>
    <div class="modal-dialog modal-sm">
      <div class="modal-content" style="width: 316px;height: 250px" >
        <div  runat="server" style="text-align: center;background-color:white;margin-top: 25px;" > <%-- aaded by palalvi on 22022023--%> <%-- class="modal-header" --%>
            <asp:Label ID="Label8" Text="INFORMATION" runat="server" Font-Bold="true" class="control-label HeaderColor " style="text-align:center; margin-left:15px;font-size: 19px;color:#00cccc !important;"></asp:Label>
                  <%-- changes by palalvi on 22022023--%>                    
        </div>
        <div class="modal-body" style="text-align: center;padding-top:50px">
          <asp:Label ID="lblus" class="control-label" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">            
            <asp:LinkButton  runat="server" id="btnok1"  cssclass="btn btn-success" Text="OK" OnClientClick="CloseSub()"
                        style="margin-top: -6px; margin-right: 105px;text-align:center;" >  <%--onclick="btnok_Click" --%>
                        <span class="glyphicon glyphicon-ok" style="color:white;"></span> OK
                     </asp:LinkButton> <%-- data-dismiss="modal"--%>
        </div>
      </div>
      
    </div>
  </div>

</asp:Content>
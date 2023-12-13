<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FranchiesSerach.aspx.cs" Inherits="Application_ISys_ChannelMgmt_FranchiesEnrollment_FranchiesSerach" %>--%>

<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FranchiesSerach.aspx.cs"
    Inherits="Application_ISys_ChannelMgmt_FranchiesSerach" Title="Untitled Page" %>

 
 <%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <%-- <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
   
      <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" /> 
   
    <script src="../../../KMI%20Styles/jquery.min.js"></script>
    <script src="../../../KMI%20Styles/bootstrap.min.js"></script>
     <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>

     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
   
   


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
    <script type="text/javascript">
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

        //added by sanoj 13062023 for shifting respond to inbox tab
        function showSelectedTab() {
            $("#menu1").removeClass("tab-pane fade in active show");
            $("#menu2").addClass("tab-pane fade in active show");
            $("#menu1").addClass("tab-pane fade");
        }
        //Endded by sanoj 13062023
        $(function () {
            debugger; $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate:0 });
        });

         $(function () {
             debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
         });

        $(document).ready(function () {
             
            debugger;
            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
               
                var currentTab = $(e.target).text(); // get current tab
                var LastTab = $(e.relatedTarget).text(); // get last tab
                 console.log(currentTab);
                console.log(LastTab);
                $(".current-tab span").html(currentTab);
                $(".last-tab span").html(LastTab);
            });
        });
        $(function () {
           
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
            $('#ctl00_ContentPlaceHolder1_divBrnuser a[href="#' + tabName + '"]').tab('show');
            $("#ctl00_ContentPlaceHolder1_divBrnuser a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });


        function validtab() {
           //alert('validtab() call');
            debugger;
            if ($('#ctl00_ContentPlaceHolder1_A1').attr('class') == 'active') {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('1');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
                $('#ctl00_ContentPlaceHolder1_divBrnuser a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divBrnuser a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }
            else if ($('#ctl00_ContentPlaceHolder1_A2').attr('class') == 'active') {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('2');
                
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu2";
                $('#ctl00_ContentPlaceHolder1_divBrnuser a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divBrnuser a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

            else {
                $('#ctl00_ContentPlaceHolder1_hdnMenuName').val('0');
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "menu1";
                $('#ctl00_ContentPlaceHolder1_divBrnuser a[href="#' + tabName + '"]').tab('show');
                $("#ctl00_ContentPlaceHolder1_divBrnuser a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });

            }

        }

        
        function funcopenDocs(arg1) {
            debugger;

            $find("mdlViewBID").show();

            //MdlPopRaiseSub
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/FPView_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=mdlViewBID";

        }

        var path = "<%=Request.ApplicationPath.ToString()%>";

        function poponload(window) {

            window.moveTo(0, 0);

        }

        //popup added by rachana to show CFR for admin and other user with status raised,responded,closed start
        function funcShowPopup(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFR") {
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/ChannelMgmt/FPPopCFRAssigned.aspx?MemCode=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
                //agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
            }
        }
        function funcShowPopupCFR(strPopUpType, agtcode, flag, user) {
            debugger;
            if (strPopUpType == "CFRDetail") {
                $find("MdlPopRaiseCFR").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/ChannelMgmt/FPPopCFRAssigned.aspx?MemCode=" +
                agtcode + "&Popup=" + flag + "&user=" + user + "&mdlpopup=MdlPopRaiseCFR";
                // agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&user=" + user +"&mdlpopup=MdlPopRaiseCFR";
            }
        }
        //            if (strPopUpType == "CFRDetail") {
        //                debugger;
        //                $find("MdlPopRaiseCFR").show();
        //                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopCFRAssigned.aspx?CndNo=" +
        //                 agtcode + "&Popup=" + flag + "&UserType=" + UserType + "&UserGrpCode=" + UserGrpCode + "&mdlpopup=MdlPopRaiseCFR";
        //            }
        //        }
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

        function funcopen(arg1, Code, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&MemCode=" + arg1 + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=Qc&mdlpopup=MdlPopRaiseSub";
        }

        //Added by Rahul on 25-04-2015 for retrieval process start
        function funcopenRET(arg1, status, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&MemCode=" + arg1 + "&Status=" + status + "&Code=" + Code + "&Type=Qc&mdlpopup=MdlPopRaiseSub";
        }
        //Added by Rahul on 25-04-2015 for retrieval process end

        //Added by Nikhil on 29-07-2015 for NOC process start
        function funcopenNOC(arg1, status, Code, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=NOCQc&MemCode=" + arg1 + "&Status=" + status + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=QcNO&mdlpopup=MdlPopRaiseSub";
        }
        //Added by Nikhil on 29-07-2015 for NOC process end


        function funcopenCFR(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&MemCode=" + arg1 + "&Code=" + Code + "&Type=Qc&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
        //added bu usha  on 21-07-2015
        function funcopenNOCAppCFR(arg1, Code,ModuleID, arg2 ) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRRespond&MemCode=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&ModuleID=" + ModuleID + "&Type=QcRes&user=Brn&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenNOCTeamCFR1(arg1, Code, arg2) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRCVR&MemCode=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=NTRes&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenNOCCFR(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=CFRRespond&MemCode=" + arg1 + "&Code=" + Code + "&Type=QcRes&status=NOCCFR&mdlpopup=MdlPopRaiseSub";
        }
        //ended by usha 
        function funcopenNOCTeamCFR(arg1, Code,arg2) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond1&MemCode=" + arg1 + "&Code=" + Code + "&Cfr=" + arg2 + "&Type=QcRes&user=Lic&status=NOCCFR&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRBrn(arg1, Code, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&MemCode=" + arg1 + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenCFRres(arg1, Code, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond&MemCode=" + arg1 + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=QcRes&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
        //Added by usha for NOC 19.07.015
        function funcopenCFRNOCres(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&MemCode=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&Mode=NOCCLOSED&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRNOCres1(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondNOC&MemCode=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&Mode=NOC&mdlpopup=MdlPopRaiseSub";
        }
        //        //        added by usha for licteam inbox om 14.8.015
        function funcopenCFRNOCresSM(arg1, Code, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondSM&MemCode=" + arg1 + "&Code=" + Code + "&ModuleID=" + ModuleID + "&Type=QcRes&user=SM&mdlpopup=MdlPopRaiseSub";
        
        }
        function funcopenCFRNOCresFSM(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespondFSM&MemCode=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=SMR&mdlpopup=MdlPopRaiseSub";
        }
        function funcopenCFRNOCIN(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPAdvTrnHrsReqSubmit.aspx?TrnRequest=funcopenCFRNOCIN&MemCode=" + arg1 + "&Code=" + Code + "&Type=QcRes&user=Lic&mdlpopup=MdlPopRaiseSub";
        }
//ended by usha 
    </script>
    <style>
         .clscenter{
           text-align:center!important;
           }
           .clsLeft{
           text-align:left !important;
           }
            .gridview th {
    padding: 10px;
    } 
    </style>
    <asp:ScriptManager ID="sm50HrsSearch" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
        <asp:UpdatePanel ID="up_prospect" runat="server">
            <ContentTemplate>
                <div id="divSearchDetails" runat="server" class="card PanelInsideTab">
                     <div id="Div1" runat="server" class="HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Tremcode','btnWfParam');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="lblTitle" runat="server" style="font-size:19px;margin-left: 17px;"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
                   <%-- <div  id="divPannel1" runat="server">
                     <div id="Div2" runat="server" class="panelheadingAliginment">
                    <div class="row spacebetnrow">
                           <div class="col-sm-10" style="text-align: left">
                         <asp:Label ID="lblTitle" runat="server" CssClass="HeaderColor"></asp:Label>
                 </div>
                         </div>
                    </div>--%>

                        <div id="Tremcode" style="display: block;" runat="server" class="panel-body panelContent">
                              <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="LblMemcoe" runat="server" Text ="Member Code" CssClass="control-label labelSize"></asp:Label>
                              <asp:TextBox ID="TxtMemCode" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>

                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                            FilterMode="InvalidChars" TargetControlID="TxtMemCode" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFranCode" runat="server" CssClass="control-label labelSize"></asp:Label>
                              <asp:TextBox ID="txtFranCode" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
                        </div>
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFranSapCode" runat="server" CssClass="control-label labelSize"></asp:Label>
                              <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
                          </div>
                         </div>
                              <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                               <asp:Label ID="lblGivenName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_txtName" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                          <div class="col-sm-4" style="text-align: left">
                               <asp:Label ID="lblSurName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                   
                                        <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="60" ></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtSurname">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                        </div>
                          <div class="col-sm-4" style="text-align: left">
                               <asp:Label ID="Label1" Text="Pan No" runat="server" CssClass="control-label labelSize"></asp:Label>
                             
                                  <asp:TextBox ID="TxtPanNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                              
                        </div>
                         </div>
                              <div class="row rowspacing">
                                 <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblShwRecords1" Text="Show Records" runat="server" CssClass="control-label labelSize"></asp:Label>
                                     <asp:DropDownList ID="ddlShwRecrds1" runat="server" CssClass="form-control form-select"  AutoPostBack="true">
                                </asp:DropDownList>
                                     </div>
                               <div class="col-sm-4" style="text-align: left">
                                    <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize"> </asp:Label><%--width changed by shreela on 6/03/14--%>
                                         <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegFrom" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate:0 });" MaxLength="10" placeholder="(dd/mm/yyyy)" 
                                           />

                                </div>
                                  <div class="col-sm-4" style="text-align: left">
                                      <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegTo" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate:0 });" MaxLength="10" placeholder="(dd/mm/yyyy)"
                                      />
                                     


                                </div>
                                </div>
                              
                              <div class="row rowspacing">
<div class="col-sm-12" style="text-align:center;">
    <%--<div class="glyphicon glyphicon-search" style="white-space: nowrap;">
                                            <i class="fa fa-search"></i>--%>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click"
                                            TabIndex="43" Text="SEARCH" OnClientClick="return validtab();"/>
                                          <%--</div>--%>
                                        
                                        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-clear" OnClick="btnClear_Click"
                                            TabIndex="43" Text="CLEAR" />
                                   <asp:Button ID="btnReFresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnReFresh_Click"  />
                                             <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div>
</div>
                            </div>

                           <div class="row rowspacing" id="trnote" runat="server" visible="false">
                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                   </div>
                        </div>
                        <%-- </div>--%>
                       <div id="trRecord" runat="server" visible="false" colspan="6" style="height: 18px; text-align: center;">
                <asp:Label ID="lblMessage" runat="server" CssClass="standardlabelErr"></asp:Label>
            </div>
                    </div>

                    <div  id="trDgViewDtl" runat="server" class="card PanelInsideTab" visible="false">
               <%-- <div id="Div3" runat="server" class="panelheadingAliginment">--%>
                    
                    <%--<div class="row rowspacing" id="trtitle" runat="server" visible="false">
                         <div class="col-sm-5" style="text-align: left">
                              <asp:Label ID="lblprospectsearch" runat="server" Text="Search Results"
                                                    CssClass="HeaderColor"></asp:Label>
                             </div>
                        <div id="divcolor" runat="server" class="col-sm-5" style="text-align: left ;margin-top: 5px;">
                        <asp:UpdatePanel ID="updPageInfo" runat="server">
                                            <ContentTemplate>
                                               
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                               <asp:Label ID="txtCFRcolr" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                BackColor="Orange"></asp:Label>
                            <asp:Label ID="lblCFR" runat="server" style=" font-size: 14px; " Text="CFR RAISED"> </asp:Label>
                             <asp:Label ID="txtQCColr" Visible="true" runat="server" BackColor="LightGreen" CssClass="control-label" Width="20px" Height="12px"></asp:Label>
                            <asp:Label ID="lblQC" Visible="true" runat="server" CssClass="control-label" Text="CFR RESPONDED">       </asp:Label>
                                                <span style="padding-right"></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-6" style="text-align:left;display:none">
                        <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Width="160px"></asp:Label>
                            </div>
                        </div>--%>

                   <%-- <div class ="card" id="trgridsponsorship" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px">--%>
                        <div id="Div2" runat="server" class="HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trgridsponsorship','btnDeptMstGrd');return false;">
                <div class="row">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="trtitle" runat="server" Text="QC Search Results" CssClass="control-label" style="font-size:19px;margin-left: 12px;">
                        </asp:Label>
                        <asp:Label ID="lblprospectsearch" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>
                    </div>

                    <div class="col-sm-7" style="text-align: right">
                    <div id="divcolor" runat="server" visible="true">
                         <asp:UpdatePanel ID="updPageInfo" runat="server">
                                            <ContentTemplate>
                                               
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                               <asp:Label ID="txtCFRcolr" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                BackColor="Orange"></asp:Label>
                            <asp:Label ID="lblCFR" runat="server" style=" font-size: 14px; " Text="CFR RAISED"> </asp:Label>
                             <asp:Label ID="txtQCColr" Visible="true" runat="server" BackColor="LightGreen" CssClass="control-label" Width="20px" Height="12px"></asp:Label>
                            <asp:Label ID="lblQC" Visible="true" runat="server" CssClass="control-label" Text="CFR RESPONDED">       </asp:Label>
                                                <span style="padding-right"></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>    
                            <%--<asp:Label ID="Label8" runat="server" CssClass="control-label" Width="20px" Height="12px" BackColor="blue"></asp:Label>
                            <asp:Label ID="Label9" runat="server" style=" font-size: 14px; " Text="FRESH QC"> </asp:Label>
                             &nbsp &nbsp
                            <asp:Label ID="lired1" runat="server" CssClass="control-label" Width="20px" Height="12px"  BackColor="Orange"></asp:Label>
                            <asp:Label ID="lblCFR" runat="server" style=" font-size: 14px; " Text="CFR RAISED"> </asp:Label>
                             &nbsp &nbsp
                             <asp:Label ID="Label6" Visible="true" runat="server" BackColor="LightGreen" CssClass="control-label" Width="20px" Height="12px"></asp:Label>
                           <asp:Label ID="txtQCColr" Visible="true" runat="server" CssClass="control-label" Text="CFR RESPONDED">       </asp:Label>--%>
                        </div>
                   </div>

                    <div class="col-sm-1">
                        <span id="btnDeptMstGrd" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
                         <div id="trgridsponsorship" class ="card" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px">
                         <asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                                            <ContentTemplate>
                                                 <div style="overflow-x: scroll">
                                                <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="footable"
                                                    AutoGenerateColumns="False"
                                                    AllowPaging="True" OnPageIndexChanging="dgView_PageIndexChanging" OnRowCommand="dgView_RowCommand"
                                                    OnSorting="dgView_Sorting" OnRowDataBound="dgView_RowDataBound" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField SortExpression="MemCode" HeaderText="Member Code" DataField="MemCode">
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:BoundField>
                                                        <asp:BoundField SortExpression="EmpCode" HeaderText="Franchisee Code" DataField="EmpCode" >
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField SortExpression="LegalName" HeaderText="Franchisee Name">
                                                            <ItemTemplate>
                                                               
                                                                <asp:Label ID="lblLegalName" runat="server" Text='<%# Eval("LegalName") %>' CommandArgument='<%# Eval("LegalName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                             <ItemStyle CssClass="clsLeft" />
                                                             <HeaderStyle CssClass="clsLeft" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField SortExpression="SAPCODE" HeaderText="Sap Code" DataField="SAPCODE"  >
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:BoundField>
                                                     
                                                        <asp:TemplateField SortExpression="RequestDate" HeaderText="Request Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSponDate" runat="server" Text='<%# Eval("RequestDate","{0:dd/MM/yyyy}") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="PAN No" HeaderText="PAN" 
                                                            ItemStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPanNo" runat="server" Text='<%# Eval("PAN No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField> 

                                                        <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div style="white-space: nowrap; width: 100%;">
                                                                    <asp:LinkButton ID="lblRequest" CssClass="btn btn-success" runat="server" CommandArgument='<%# Eval("MemCode") %>' Text='<%# Eval("Request") %>' 
                                                                        CommandName="ReqClick"><span class="glyphicon glyphicon-pencil" style="color: black!important;"></span></asp:LinkButton>
                                                                </div>
                                                           
                                                            </ItemTemplate>
                                                             <ItemStyle CssClass="clscenter" />
                                                             <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                     
                                                             <asp:TemplateField Visible="false">
                                                             <ItemTemplate>
                                                                    <asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label> 
                                                             </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                </asp:GridView>
                                            </div>
                                                <div>
                                    <center>

                                          <table  id="QCPage" runat="server" visible="false">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                        background-color: transparent; float: left; margin: 0; height: 34px;" OnClick="btnprevious_Click" />
                                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 40px; border-style: solid;
                                                                        border-width: 1px; border-color: Gray; height: 33px; float: left; margin: 0;
                                                                        text-align: center;" ReadOnly="true" />
                                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                        float: left; margin: 0; height: 34px;" Width="40px" OnClick="btnnext_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                         </center>
                                        
                                </div>
                                                     </ContentTemplate>
                                           <%-- <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                            </Triggers>--%>
                                        </asp:UpdatePanel>
                  </div>  

               <%-- </div>--%>
                      
                        </div>
                    <%-- </div>--%>
                <table class="container" width="80%">
                    <tr id="trSearchDetails" runat="server" style="display:none;">
                        <td align="center">
                            <table id="tbl1" style="border-collapse: separate; left: 0in; position: relative;
                                top: 0px; width: 100%; z-index: 4;" class="tableIsys" runat="server" >
                                <tr>
                                    <td class="test portlet-title" colspan="4" align="left" style="height: 20px;">
                                       
                                    </td>
                                </tr>
                               <%-- added by usha  on 31.05.2022  --%>
                                <tr  runat="server">
                                    <td class="formcontent" align="left" style="width: 20%">
                                        
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        
                                        
                                    </td>
                                    <td class="formcontent" align="left" style="width: 20%">
                                       
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        
                                       
                                    </td>
                                </tr>
                                   <%-- ended by ush aon 31.05.2022   --%>
                                <tr>
                                    <td class="formcontent" align="left" style="width: 20%">
                                        
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        
                                       <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtFranCode" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="formcontent" align="left" style="width: 20%">
                                        
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        
                                       <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            ValidChars="1234567890" FilterMode="ValidChars" TargetControlID="txtAppNo" FilterType="Custom">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                               <%-- <tr style="display:none">--%>
                                 <tr >
                                    <td class="formcontent" align="left" style="width: 20%">
                                       
                                    </td>
                                    <td class="formcontent" align="left" style="height: 24px">
                                       
                                    </td>
                                </tr>
                                 <tr id="trregstrtndt" runat="server" visible="false" style="height: 37.5px;">
                                   <td class="formcontent" align="left" style="height:24px">
                                
                            </td>
                            <td class="formcontent" align="left" style="height:24px">
                                
                            </td>
                            <td class="formcontent" align="left" style="height:24px">
                                
                                   
                            </td>
                                   <%-- <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize" Width="160px"> </asp:Label> 
                                    </td>
                                    <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </td>
                                    <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize" Width="136px"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left" style="width: 243px; height: 21px">
                                        <uc7:ctlDate ID="txtDTRegTo" runat="server" CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </td>--%>
                                </tr>
                                <%-- <tr id="trregstrtndt" runat="server" visible="false" style="height: 37.5px;">
                                        <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize" Width="136px"></asp:Label>
                                    </td>
                                    <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </td>
                                  
                                    <td class="formcontent" align="left" style="width: 210px; height: 21px">
                                        <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize" Width="160px"> </asp:Label> 
                                    </td>
                                      <td class="formcontent" align="left" style="width: 243px; height: 21px">
                                        <uc7:ctlDate ID="txtDTRegTo" runat="server" CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </td>
                                    
                                </tr>--%>


                                   <%-- added by sanoj on 26-01-2022 start--%>
                       
                       <tr id="trshowrecords" runat="server" visible="true" style="height:35px">
                            <td class="formcontent" align="left" style="height: 24px">
                                
                            </td>
                            <td runat="Server" id="td2" class="formcontent" align="left" style="height: 24px">
                                  
                             </td>
                        </tr>
                        <%--ended by sanoj on 26-01-2022 start--%>

                                <%--Added by rachana on 31122013 for filtered search start--%>
                                <tr id="trtraning" runat="server" visible="false">
                                    <td class="formcontent" align="left" style="width: 20%">
                                        <asp:Label ID="lblFranName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="width: 30%" align="left">
                                        <asp:TextBox ID="txtRecruiterName" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtRecruiterName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td id="tdreq" runat="server" class="formcontent" style="width: 227px; height: 21px"
                                        align="left">
                                        <asp:Label ID="lblBranchName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                    </td>
                                    <td id="tdreqsta" runat="server" class="formcontent" style="height: 21px" align="left">
                                        <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '&" TargetControlID="txtBranchName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <%--Added by rachana on 31122013 for filtered search end--%>
                               
                                 <tr id="trCodedlicdetails" runat="Server" style="height:35px" visible="false">
                            
                            <td class="formcontent" style="width: 227px; height: 21px" align="left">
                                    <asp:Label ID="lblAgntBroker" runat="server" Text="Agent Broker Code" Width="140px"></asp:Label>
                                </td>
                                <td class="formcontent" style="width: 227px; height: 21px" align="left" nowrap="nowrap">
                                    <asp:TextBox ID="txtAgntBroker" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>    
                            
                            <td class="formcontent" style="width: 227px; height: 21px" align="left">
                                <asp:Label ID="lblSapcode" runat="server" Text="SAP Code" CssClass="control-label labelSize"></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 21px" align="left">
                                <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                            
                        </tr>

                                <tr id="TrForSpon" runat="server" style="height: 30px; display:none;">
                                  
                                    <td class="formcontent" style="width: 20%;">
                                        <asp:Label ID="lblProcessType" runat="server" CssClass="control-label labelSize" Text="Process Type"></asp:Label>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 30%;">
                                        <asp:DropDownList ID="ddlProcessType" runat="server" AutoPostBack="false" CssClass="standardmenu"
                                            Width="187px">
                                            <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Fresh" Value="F"></asp:ListItem>
                                            <asp:ListItem Text="Composite" Value="C"></asp:ListItem>
                                            <asp:ListItem Text="Transfer" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="POSP" Value="P"></asp:ListItem>
                                            <asp:ListItem Text="ReExam" Value="RE"></asp:ListItem>
                                            <asp:ListItem Text="Retrieval" Value="RW"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                  
                                   
                                
                                    <td id="tdPan" class="formcontent" style="width: 227px; height: 21px" align="left">
                                        <asp:Label ID="lblPan" runat="server" CssClass="control-label labelSize"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="height: 21px" align="left">
                                        <asp:TextBox ID="txtPan" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </td>
                                    </tr>
                                <%--pranjali--%>
                                 <%-- usa--%>
                                 <tr id="trURN" runat="server" style="height:35px" visible="false">
                       
                        <td class="formcontent" align="left" style="height: 24px">
                            <asp:Label ID="lblURN" runat="server" Text="URN No" CssClass="control-label labelSize"></asp:Label>
                        </td>
                        <td class="formcontent" align="left" style="height: 24px">
                            <asp:TextBox ID="txtURN" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td align="left" class="formcontent" style="width: 20%; height: 50px;">
                                        <%--<asp:Label ID="lblCandType" runat="server" Text="Candidate Type"></asp:Label>--%>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 30%; height: 50px;">
                                     
                                    </td>
                    
                       </tr>
                                <tr  id="trReq" visible="False" runat="server" style="height: 30px;">
                                 <td class="formcontent" style="width: 227px; height: 50px" align="left">
                                        <asp:Label ID="lblReqStatus" Text ="Request Date From (dd/mm/yyyy)" runat="server" CssClass="control-label labelSize"></asp:Label>
                                    </td>
                                    <td class="formcontent" style="height: 50px" align="left">
                                        <asp:DropDownList ID="ddlreqstatus" runat="server" CssClass="standardmenu" Width="187px">
                                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                            <asp:ListItem Text="Requested" Value="Req"></asp:ListItem>
                                            <asp:ListItem Text="New Request" Value="New"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    
                                    <td align="left" class="formcontent" style="width: 20%; height: 50px;">
                                        <%--<asp:Label ID="lblCandType" runat="server" Text="Candidate Type"></asp:Label>--%>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 30%;">
                                        <%--<asp:DropDownList ID="ddlCandType" runat="server" AutoPostBack="false" 
                                        CssClass="standardmenu" Width="187px">
                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Fresh" Value="F"></asp:ListItem>
                                        <asp:ListItem Text="Composite" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Transfer" Value="T"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr id="trShw" runat="server" style="display:none;">
                                    <td align="left" class="formcontent" style="width: 227px; height: 21px;">
                                        <asp:Label ID="lblShwRecords" runat="server" CssClass="control-label labelSize"></asp:Label>
                                    </td>
                                    <td align="left" class="formcontent" style="height: 21px">
                                        <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="standardmenu" OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged"
                                            Width="50px">
                                            <%--AutoPostBack="true"--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 20%">
                                        <asp:Label ID="lblRequestDate" runat="server" CssClass="control-label labelSize" Width="136px"> </asp:Label>
                                    </td>
                                    <td align="left" class="formcontent" style="width: 30%">
                                        <asp:TextBox ID="txtReqDate" runat="server" CssClass="form-control" MaxLength="10"
                                            TabIndex="12" />
                                        <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                        <asp:TextBox ID="txtDtValidate" runat="server" CssClass="form-control" Style="display: none"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtReqDate" ValidChars="1234567890/">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" Format="dd/MM/yyyy"
                                            PopupButtonID="btnCalendar" TargetControlID="txtReqDate" />
                                        <asp:CompareValidator ID="CV" runat="server" ControlToValidate="txtReqDate" Display="Dynamic"
                                            ErrorMessage="Invalid date!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                        &nbsp;
                                        <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtReqDate" Display="Dynamic"
                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                            Type="Date"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <%--pranjali--%><%-- added by shreela on 10042014 start--%>
                                <%-- <tr id="trPan">
                        <td id="tdPan" class="formcontent" style="width: 227px; height:21px" align="left" >
                            <asp:Label ID="lblPan" runat="server" CssClass="control-label labelSize"></asp:Label>
                        </td>
                        <td class="formcontent" style="height: 21px" align="left">
                            <asp:TextBox ID="txtPan" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="formcontent"></td>
                        <td class="formcontent"></td>
                       </tr>--%><%--added by shreela on 10042014 end--%>
                                
                                
                            </table>
                        </td>
                    </tr>
                    <%--</div>--%>
                    <%-- <div id="divDgViewDtl" runat="server" visible="false">--%>
                    <tr  runat="server" style="display:none">
                        <td align="center">
                            <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                                z-index: 3; width: 100%;" class="test portlet-title">
                            <tr  >
                            <td class="formcontent2" colspan="2" style="border-collapse: separate; height:20px;">
                               
                               </td>
                            </tr>
                                <tr >
                                    <td style="border-collapse: separate" class="test" align="left">
                                        
                                    </td>
                                    <%-- added by shreela on 24032014--%>
                                    <td class="test" align="right">
                                        
                                    </td>
                                </tr>
                                <tr  runat="server">
                                    <td colspan="2">
                                       
                                    </td>
                                </tr>

                               <%-- added by sanoj 24052022--%>

                              <%--  <tr id="tr2" runat="server">
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvDocs" runat="server" AllowSorting="True" CssClass="formtable"
                                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False" OnPageIndexChanging="gvDocs_PageIndexChanging"
                                                    AllowPaging="True" OnRowCommand="gvDocs_RowCommand" 
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField SortExpression="EmpCode" HeaderText="Franchisee Code" DataField="EmpCode"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField SortExpression="LegalName" HeaderText="Franchisee Name" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                
                                                                <asp:Label ID="lblLegalName" runat="server" Text='<%# Eval("LegalName") %>' CommandArgument='<%# Eval("LegalName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField SortExpression="SAPCODE" HeaderText="Sap Code" DataField="SAPCODE"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:BoundField>
                                                      
                                                        <asp:TemplateField SortExpression="ConstCode" HeaderText="Entity Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblentityType" runat="server" Text='<%# Eval("ConstCode") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="RequestDate" HeaderText="Request Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSponDate" runat="server" Text='<%# Eval("RequestDate","{0:dd/MM/yyyy}") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="PAN No" HeaderText="PAN" 
                                                            ItemStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPanNo" runat="server" Text='<%# Eval("PAN No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize" Width="8%"></ItemStyle>
                                                            
                                                        </asp:TemplateField> 

                                                      
                                                        <asp:TemplateField SortExpression="Request" HeaderText="">
                                                            <ItemTemplate>
                                                                <div style="white-space: nowrap; width: 100%;">
                                                                    <i class="fa fa-flash"></i>
                                                                    <asp:LinkButton ID="lblRequest" runat="server" CommandArgument='<%# Eval("MemCode") %>' Text="View Document" 
                                                                        CommandName="viewClick"></asp:LinkButton>
                                                                </div>
                                                           
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     
                                                             <asp:TemplateField Visible="false">
                                                             <ItemTemplate>
                                                                    <asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label> 
                                                             </ItemTemplate>
                                                              <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                    </PagerStyle>
                                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" HorizontalAlign="Center"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>--%>
                                <%-- ended by sanoj 24052022--%>
                                 <tr id="tr1" class="formcontent" runat="server">
                                    <td align="center" colspan="4">
                                 <div id="divloadergrid" runat="server" style="display:none;">
                                                                &nbsp;&nbsp; <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                                                </div>
                                  </td>
                                  </tr>
                                    <tr id="trbtnexport" runat="server">
                                    <td align="center" colspan="2">
                                        <table visible="false" style="border-collapse: separate; left: 0in; position: relative;
                                            top: 0px; width: 100%;" class="formtable">
                                            <tr visible="false">
                                                <td align="center">
                                                    <div class="btn default btn-xs" style="white-space: nowrap; width: 124px;">
                                                        <i class="fa fa-table"></i>
                                                        <asp:Button ID="btnExport" runat="server" CssClass="btn default btn-xs" Text="Export to Excel"
                                                            Width="114px" OnClick="btnExport_Click" />
                                                    </div>
                                                    <asp:Button ID="btnjs" runat="server" Text="js" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
            
                <div id="divBrnuser" runat="server" visible="false" class="card PanelInsideTab" role="tabpanel">
                     <ul class="nav nav-tabs" >
                    <li runat="server" id="inbox" class="active"><a id="A1" runat="server" aria-controls="menu1"
                        data-toggle="tab" href="#menu1">Inbox</a></li>
                    <li runat="server" id="responded"><a id="A2" runat="server" aria-controls="menu2"
                        data-toggle="tab" href="#menu2">Responded</a></li>
                         </ul>

                     <div class="tab-content">
                          <div id="menu1" class="tab-pane fade in active show">
                                <asp:UpdatePanel ID="updInbox" runat="server">
                            <ContentTemplate>
                                   <div > <%--style="overflow-x: scroll"--%>
                                <asp:GridView ID="GridInbox"  runat="server" AllowSorting="True" CssClass="footable" Style="border-bottom-color: black;"
                                        AllowPaging="true" PagerStyle-HorizontalAlign="Center" HorizontalAlign="Left"
                                        AutoGenerateColumns="False" OnPageIndexChanging="GridInbox_PageIndexChanging"  OnRowCommand="GridInbox_RowCommand"
                                                    OnRowDataBound="GridInbox_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="EmpCode" HeaderText="Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("EmpCode") %>' CommandArgument='<%# Eval("EmpCode") %>'
                                                                    CommandName="Click_AppNo"></asp:Label></ItemTemplate>
                                                            <ItemStyle CssClass="clscenter" />
                                                            <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndNo" HeaderText="Member Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("MemCode") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle CssClass="clscenter" />
                                                            <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndName" HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("MemName") %>'></asp:Label>
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
                                                        <asp:BoundField SortExpression="CFRRaised" HeaderText="Total CFR Raised" DataField="CFRRaised"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:BoundField>
                                                          <%--//added by ajay 05 june 2023--%>
                                                        <asp:TemplateField HeaderText="Member Type">
                                                            <ItemTemplate>
                                                                <%--<asp:HiddenField id="hdnmemtype" runat="server"  Text='<%# Eval("memtype") %>'/>--%>
                                                                   <asp:Label ID="hdnmemtype" runat="server" Text='<%# Eval("memtype") %>'></asp:Label>
                                                            </ItemTemplate>
                                                             <HeaderStyle CssClass="clsLeft"/>
                                                            <ItemStyle  CssClass="clsLeft"/>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div style="width: 100%; white-space: nowrap;">
                                                                    <i class="fa fa-external-link"></i>
                                                                    <asp:LinkButton ID="LinkButton4" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                        CommandArgument='<%# Eval("MemCode") %>'></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="clsLeft" />
                                                            <HeaderStyle CssClass="clsLeft" />
                                                        </asp:TemplateField>
                                                    </Columns>
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                </asp:GridView>
</div>
                                 <div>
                                    <center>
                                        <table id="InboxPage" runat="server" visible="false">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious1" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtprevious1" Text="1" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 34px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-submit-button" ReadOnly="true" />
                                                    <asp:Button ID="btnnext1" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 34px;" Width="40px"
                                                        OnClientClick="return validtab();" OnClick="btnnextMenu_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                               <div id="trInboxMsg" runat="server" visible="false" style="text-align: center">
                            <asp:Label ID="Label5" runat="server" Text="0 Record Found" CssClass="standardlabelErr"></asp:Label>
                        </div>
                              </div>
                          <div>
                                </div>
                          <div id="menu2" class="tab-pane fade">
                               <asp:UpdatePanel ID="updRespond" runat="server">
                            <ContentTemplate>
                                    <div > <%--style="overflow-x: scroll"--%>
                               <asp:GridView ID="GridResponded"  runat="server" AllowSorting="True" CssClass="footable" Style="border-bottom-color: black;"
                                        AllowPaging="true" PagerStyle-HorizontalAlign="Center" HorizontalAlign="Left"
                                        AutoGenerateColumns="False"  OnPageIndexChanging="GridResponded_PageIndexChanging"   OnRowDataBound="GridResponded_RowDataBound"
                                                    OnRowCommand="GridResponded_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="AppNo" HeaderText="Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("EmpCode") %>' CommandArgument='<%# Eval("EmpCode") %>'
                                                                    CommandName="Click_AppNo"></asp:Label></ItemTemplate>
                                                            <ItemStyle CssClass="clscenter" />
                                                            <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndNo" HeaderText="Member Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("MemCode") %>' CommandArgument='<%# Eval("MemCode") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle CssClass="clscenter" />
                                                            <HeaderStyle CssClass="clscenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndName" HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("MemName") %>'></asp:Label>
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
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div style="width: 100%; white-space: nowrap;">
                                                                    <i class="fa fa-external-link"></i>
                                                                    <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                        CommandArgument='<%# Eval("MemCode") %>'></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                             <ItemStyle CssClass="clsLeft" />
                                                            <HeaderStyle CssClass="clsLeft" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                  
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                </asp:GridView>
                                        </div>
                                <div>
                                    <center>
                                        <table id="ResPage" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious2" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        OnClientClick="return validtab();" OnClick="btnpreviousMenu_Click" />
                                                    <asp:TextBox runat="server" ID="txtResponded" Text="1" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 34px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-submit-button" ReadOnly="true" />
                                                    <asp:Button ID="btnnext2" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 34px;" Width="40px"
                                                        OnClientClick="return validtab();" OnClick="btnnextMenu_Click" Enabled="false" />
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
                         
                         </div>

                    
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="false">
                        <asp:View ID="View1" runat="server">
                            <div class="panel-body panelContent" style="text-align: left; width: 80%; position: relative; z-index: 3;">
                                <div class="ImgTab">
                                         
                                            <div class="TabContent">
                                               
                                            </div>
                                        </div>
                            </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <div class="panel-body panelContent" style="text-align: left; width: 80%; position: relative; z-index: 3;">
                                  <div class="ImgTab">
                                            <ul>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="lnkInbox_Click">Inbox</asp:LinkButton></li>
                                                <li class="current">
                                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="lnkResponded_Click">Responded</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkClosed_Click">Closed</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LnkCFR_Respond" runat="server" OnClick="LinkCFRs_Click">CFR's</asp:LinkButton></li>
                                            </ul>
                                            <div class="TabContent">
                                              
                                            </div>
                                        </div>
                                </div>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <div class="panel-body panelContent" style="text-align: left; width: 80%; position: relative; z-index: 3;">
                                  <div class="ImgTab">
                                            <ul>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="lnkInbox_Click">Inbox</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton10" runat="server" OnClick="lnkResponded_Click">Responded</asp:LinkButton></li>
                                                <li class="current">
                                                    <asp:LinkButton ID="LinkClosed" runat="server" OnClick="LinkClosed_Click">Closed</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LnkCFR_Close" runat="server" OnClick="LinkCFRs_Click">CFR's</asp:LinkButton></li>
                                            </ul>
                                            <div class="TabContent">
                                                <asp:GridView ID="GridClosed" runat="server" AllowSorting="True" CssClass="formtable"
                                                    PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="GridClosed_PageIndexChanging" AllowPaging="True" OnRowDataBound="GridClosed_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="EmpCode" HeaderText="Emp Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("EmpCode") %>' CommandArgument='<%# Eval("EmpCode") %>'
                                                                    CommandName="Click_AppNo"></asp:Label></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="MEmCode" HeaderText="Member Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("MEmCode") %>'></asp:Label></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="MemName" HeaderText="Emp Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("MemName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField SortExpression="CFRClosed" HeaderText="Total CFR Raised" DataField="CFRClosed"
                                                            Visible="false">
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField SortExpression="Request" HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                    CommandArgument='<%# Eval("MemCode") %>'></asp:LinkButton></ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                    </PagerStyle>
                                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                </div>
                           <%-- <table style="text-align: left; width: 80%; z-index: 3; position: relative;">
                                <tr>
                                    <td>
                                      
                                    </td>
                                </tr>
                            </table>--%>
                        </asp:View>
                        <%--Added by pranjali on 25022014 for showing cfrs tab start--%>
                        <asp:View ID="View4" runat="server">
                            <div class="panel-body panelContent" style="text-align: left; width: 80%; position: relative; z-index: 3;">
                                        <div class="ImgTab">
                                            <ul>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton12" runat="server" OnClick="lnkInbox_Click">Inbox</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton13" runat="server" OnClick="lnkResponded_Click">Responded</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkClosed_Click">Closed</asp:LinkButton></li>
                                                <li class="current">
                                                    <asp:LinkButton ID="LnkCFR_CFR" runat="server" visble="false" OnClick="LinkCFRs_Click">CFR's</asp:LinkButton></li>
                                            </ul>
                                            <div class="TabContent">
                                                <asp:GridView ID="GridCFR" runat="server" AllowSorting="True" CssClass="footable"
                                                   HorizontalAlign="Left" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="GridCFR_PageIndexChanging" AllowPaging="True" OnRowDataBound="GridCFR_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="AppNo" HeaderText="App No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Eval("EmpCode") %>' CommandArgument='<%# Eval("EmpCode") %>'
                                                                    CommandName="Click_AppNo"></asp:Label></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndNo" HeaderText="Candidate No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("MemCode") %>'></asp:Label></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="CndName" HeaderText="Candidate Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCndName" runat="server" Text='<%# Eval("MemName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRecruitrName" runat="server" Text='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="UnitLegalName" HeaderText="Branch">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("UnitLegalName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="ProcessType" HeaderText="Process Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProcessType" runat="server" Text='<%# Eval("ProcessType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="control-label labelSize"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Request" HeaderText="">
                                                            <ItemTemplate>
                                                                <div style="width: 100%; white-space: nowrap;">
                                                                    <i class="fa fa-external-link"></i>
                                                                    <asp:LinkButton ID="lblcfr" runat="server" Text='View CFR' CommandName="ViewCFR"
                                                                        CommandArgument='<%# Eval("MemCode") %>'></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                     <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                     </div>
                        </asp:View>
                        <%--Added by pranjali on 25022014 for showing cfrs tab end--%>
                    </asp:MultiView>

                    <div class="row rowspacing" style="display:none">
                        <div class="col-sm-12" style="text-align:center;">
                             <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkResponded_Click" CssClass="btn btn-success " Visible="true">NEXT</asp:LinkButton></li>
                    <asp:LinkButton  ID="LinkButton1" runat="server" Text="" CssClass="btn btn-success " OnClick="lnkInbox_Click" Visible="false">  PREVIOUS <span   class="glyphicon glyphicon-arrow-right BtnGlyphicon" ></span> </asp:LinkButton> 
                        </div>

                     <%--  <ul>
                                                <li class="current">--%>
                                                   <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkInbox_Click" Visible="false">Inbox</asp:LinkButton></li><li>--%>
                                                       
                                               <%-- <li>--%>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkClosed_Click" Visible="false">Closed</asp:LinkButton></li>
                                               <%-- <li>--%>
                                                    <asp:LinkButton ID="LnkCFR_Inbox" runat="server" Visible="false" OnClick="LinkCFRs_Click">CFR's</asp:LinkButton></li>
                                            <%--</ul>--%>
                         </div>
                    </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnCndNo" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCndName" runat="server" />
                            </td>
                            <td>
                                <%--<asp:HiddenField ID="hdnApplicationNo" runat="server" />--%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTrnReqDt" runat="server" />
                            </td>
                            <%--Added by rachana on 22-08-2013 for branched user start--%>
                            <td>
                                <%--<asp:HiddenField ID="hdnAppNo" runat="server" />--%>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnName" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCandCode" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnRecruiterCode" runat="server" />
                                  <asp:HiddenField ID="hdnMenuName" runat="server" />
                                <asp:HiddenField ID="TabName" runat="server" />
                            </td>
                            <%--Added by rachana on 22-08-2013 for branched user end--%>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <%--rachana..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="518px" display="none">
        <iframe runat="server" id="IframeRaiseCFR" frameborder="0" display="none" style="width: 518px;
            height: 350px"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpop" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        DropShadow="false" TargetControlID="lblpop" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--rachana..for Raise CFR...end--%>

     <%--Shreela  for QC...Start--%>
     <asp:Panel runat="server" ID="PnlRaiseSub" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseSub" frameborder="0" display="none" style="width:1000px;
            height: 500px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
         TargetControlID="lblSub" PopupControlID="PnlRaiseSub" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
     <%--Shreela  for QC...End--%>
    <%--Ajay  Popup start--%>
     <asp:Panel runat="server" ID="pnlMdl" Width="1000px" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" frameborder="0" style="width:1000px;
            height: 470px"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Ajay  Popup end--%>
</asp:Content>

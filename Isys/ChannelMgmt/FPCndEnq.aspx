<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="FPCndEnq.aspx.cs"
    Inherits="Application_ISys_ChannelMgmt_FranchiesEnrollment_FPCndEnq" Title="Prospect Search" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

   <%-- <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Common/Styles/bootstrap.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE6" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="expires" content="-1" />
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
 

    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
--%>




       <%-- ended  by sanoj 14032023--%>
    <style type="text/css">
        .tr31{
                margin-left: 96px;
    margin-right: 97px;
    margin-top: 2%;
    padding: 1%;
        }
        .gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    text-align: left;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
             .clsleft{
        text-align:left!important;
    }
         .clscenter{
        text-align:center!important;
    }
        .colHeader-CenterAlign {
        text-align:center !important;
    }
      
	.LnkBtn
	 {	
      text-decoration:underline;	
     }
	
        .style2
        {
            height: 28px;
        }
        .style4
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            height: 42px;
            background-color: #FAFAFA;
        }
        .style5
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 227px;
            height: 53px;
            background-color: #FAFAFA;
        }
        .style6
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            height: 53px;
            background-color: #FAFAFA;
        }
        .style7
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 227px;
            height: 42px;
            background-color: #FAFAFA;
        }
        .style8
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 227px;
            height: 48px;
            background-color: #FAFAFA;
        }
        .style9
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            height: 48px;
            background-color: #FAFAFA;
        }
        .style11
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 243px;
            height: 59px;
            background-color: #FAFAFA;
        }
        .style17
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 210px;
            height: 73px;
            background-color: #FAFAFA;
        }
        .style18
        {
            font-family: Verdana, Tahoma, Arial;
            font-size: 12px;
            text-align: left;
            width: 210px;
            height: 59px;
            background-color: #FAFAFA;
        }
	
    </style>
      
    <script type="text/javascript" language="javascript">
       //addd by ajay for RF (HNIN)
        function getvalid() {
            debugger;
            flag =  GetQueryStringValue(window.location, 'MemType')
            if (flag == 'RF') {
                getid = document.getElementById("ctl00_ContentPlaceHolder1_ddlmemtype");
                getidval = getid.value;
                if (getidval == 'Select') {
                    alert('Please select member type');
                    getid.focus();
                    return false;
                }
            }
        }

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
         //added by ajay start
        $(function () {
            debugger; $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
        });

         $(function () {
             debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
         });
        function funcopenDocs(arg1) {
            debugger;
            
            $find("mdlViewBID").show();

            //MdlPopRaiseSub
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/FPView_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=mdlViewBID";

        }
        //added by ajay end
        function doClear() {
            debugger;
            document.getElementById("<%=lblMessage.ClientID%>").textContent = "";
            document.getElementById("<%=txtCandCode.ClientID%>").value = "";
            document.getElementById("<%=txtApplicatoNo.ClientID%>").value = "";
           document.getElementById("<%=txtGivenName.ClientID%>").value = "";
            document.getElementById("<%=txtSurname.ClientID%>").value = "";
            document.getElementById("<%=txtDTRegFrom.ClientID%>").value = "";
            document.getElementById("<%=txtDTRegTo.ClientID%>").value = "";
         
          
        }
               //addd by ajay for RF (HNIN)
        function GetQueryStringValue(url, param) {
            debugger;
            param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),
            results = regVal.exec(url);
            return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));
        }

    </script>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        function funOpenPopWinForAccntPayee(strPageName, strPayeeCode, strValue, strCode, strCode1, strDispCSC, strSlsChnnl, strChnCls, strSource) {
            showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Field3=" + strCode1 + "&Field4=" + strDispCSC + "&Field5=" + strSlsChnnl + "&Field6=" + strChnCls + "&Source=" + strSource, 800, 430, null);
            return false;
        }
        function PopUpWindow() {
            showPopWin
            return false;
        }
        
        function funOpenPopWinForAgn(strPageName, strPayeeCode, strValue, strCode, strCode1, strSlsChnnl, strChnCls, strUntObj, strCSCObj, strDispCSC, strSource) {
            showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Field3=" + strCode1 + "&Field4=" + strDispCSC + "&Field5=" + strSlsChnnl + "&Field6=" + strChnCls + "&objUnt=" + strUntObj + "&objCSC=" + strCSCObj + "&objHdnCSC=" + "" + "&Source=" + strSource, 500, 350, null);
            return false;
        }
        //function funReport(CndNo, ReportType) {
        //    debugger;
        //    $find("MdlPopupReport").show();
        //    document.getElementById("ctl00_ContentPlaceHolder1_IframeReport").src = "../../../Application/ISys/Recruit/IndividualReport.aspx?Type=" + ReportType + "&MemCode="
        //    + CndNo + "&mdlpopup=MdlPopupReport";
        //}

        function funReport(CndNo, ReportType) {
            debugger;
            var modal = document.getElementById('MyModalRpt');
            var modaliframe = document.getElementById("iframeRpt");
            modaliframe.src = "../../../Application/ISys/Recruit/IndividualReport.aspx?Type=" + ReportType + "&MemCode=" + CndNo + "&mdlpopup=MdlPopupReport";
            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                debugger;
                modal.style.display = "none";

            }
            $('#MyModalRpt').modal();
        }
        function funcopenDoc(arg1) {
            debugger;

            $find("MdlPopRaiseSub").show();

            //MdlPopRaiseSub
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/View_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=MdlPopRaiseSub";

        }

        //added by sanoj 24052022
        // function funcopenDocs(arg1) {
        //    debugger;

        //    $find("MdlPopRaiseSub").show();

        //    //MdlPopRaiseSub
        //    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/ChannelMgmt/FPView_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=MdlPopRaiseSub";

        //}
        // //Ended by sanoj 24052022
        //Added by Nikhil
        function funReport(CndNo, ReportType) {
            debugger;
            $find("MdlPopupReport").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReport").src = "../../../Application/ISys/Recruit/IndividualReport.aspx?Type=" + ReportType + "&MemCode="
            + CndNo + "&mdlpopup=MdlPopupReport";
        }

        //rachana 06/05/13
        function funcShowPopup(strPopUpType, cnd, name) {
            //debugger;
            if (strPopUpType == "inter") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/Recruit/PopIntDetails.aspx?CndNo=" + cnd + "&Name=" + name + "&mdlpopup=mdlViewBID";
            }
        }
        //End rachana 06/05/13

        //shreela 11/07/2014
        function funcopen(arg1) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=Renewal&CndNo=" + arg1 + "&Type=Renwl&Code=Spon&mdlpopup=MdlPopRaiseSub";
        }
        //shreela 11/07/2014

        //shreela 14/07/2014
        function funcopenReExam(arg1, ReExm) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=ReExam&CndNo=" + arg1 + "&ReExm=" + ReExm + "&Type=ReTrn&Code=Spon&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenReExamV(arg1, ReExm, ModuleID) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/FrmSubmitTCC.aspx?Type=ReExam&CndNo=" + arg1 + "&ReExm=" + ReExm + "&ModuleID=" + ModuleID + "&Code=Spon&mdlpopup=MdlPopRaiseSub";
        }
        //shreela 14/07/2014

        //Commented by shreela on 13/03/14 

        //function Special() {
        //   //debugger;
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

        //Loader for grid
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

        function funcPopupAct(strPopUpType, appcode) {
            debugger;
            if (strPopUpType == "act") {
                $find("MdlPopRaiseAct").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseAct").src = "../../../Application/ISys/Recruit/PopActionable.aspx?AppNo=" +
                appcode + "&mdlpopup=MdlPopRaiseAct";

            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
    <asp:UpdatePanel ID="up_prospect" runat="server">
    <ContentTemplate>
    
    <div class="card PanelInsideTab"  >
<%--        <table class="container" width="95%">--%>
        <%--<tr>
                <td align="center" style="width: 100%;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" 
                        Width="310px"></asp:Label>
                </td>
            </tr>
            <tr>--%>
           <%-- <div>
                <div>--%>
               <%-- <td align="center">--%>
                <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>--%>
                     <%--added by sanoj 14032023--%>
                       <div id="SearchDiv" class="panelheadingAliginment" runat="server">
                           <div id="titlediv" runat="server" class="control-label HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_contentDiv','btnWfParam');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="lbltitle" runat="server" style="font-size:19px;margin-left: 17px;"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
                       <%-- <div id="titlediv">
                        <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left;margin-left: 31px">
                              <asp:Label ID="lbltitle" runat="server" CssClass="control-label HeaderColor"></asp:Label>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             
                          </div>
                         </div>
                            </div>--%>
                        <div id="contentDiv" runat="server" class="panel-body panelContent">
                         <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="Label4" runat="server" Text="Member Code" CssClass="control-label labelSize"></asp:Label>
                              <asp:TextBox ID="txtMemberCode" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
                                                    FilterMode="InvalidChars" TargetControlID="txtMemberCode" FilterType="Custom">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFrenchCode" runat="server" Text="Code" CssClass="control-label labelSize"></asp:Label>

                                <asp:TextBox ID="txtFrenchCode" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFrenchSapCode" runat="server" Text="SAP Code" CssClass="control-label labelSize"></asp:Label>
                           
                               
                                <asp:TextBox ID="txtFrenchSap" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                          </div>
                         </div>

                       <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize"  > </asp:Label><%--width changed by shreela on 6/03/14--%>
                              <%-- <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegFrom" MaxLength="10" 
                        TabIndex="12" />--%>
                               <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegFrom" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)" 
                        TabIndex="12" />
                  
                  <%--  <asp:TextBox CssClass="form-control" ID="TextBox2" Style="display: none"
                        runat="server" Width="80px" ></asp:TextBox>--%>
                  <%--  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                        ValidChars ="1234567890/" FilterMode="ValidChars"
                        TargetControlID="txtDTRegFrom" FilterType="Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDTRegFrom"
                        PopupButtonID="Image1" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="txtDTRegFrom"
                        Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                        Type="Date" ControlToValidate="txtDTRegFrom" Display="Dynamic"></asp:CompareValidator>&nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDTRegFrom" Display="Dynamic"
                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                        Type="Date"></asp:RangeValidator>--%>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize"></asp:Label>
                             <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegTo" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)"
                        TabIndex="12" />
                                  <%--  <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegTo" MaxLength="10" 
                        TabIndex="12" />--%>
                    
                    <%--<asp:TextBox CssClass="form-control" ID="txtDtValidate" Style="display: none"
                        runat="server" Width="80px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                        ValidChars ="1234567890/" FilterMode="ValidChars"
                        TargetControlID="txtDTRegTo" FilterType="Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDTRegTo"
                        PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtDTRegTo"
                        Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                        Type="Date" ControlToValidate="txtDTRegTo" Display="Dynamic"></asp:CompareValidator>&nbsp;
                    <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtDTRegTo" Display="Dynamic"
                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                        Type="Date"></asp:RangeValidator>--%>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFranName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                    
                                        <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtGivenName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                          </div>
                         </div>

                        <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="lblBranchName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                   
                                        <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '&" TargetControlID="txtBranchName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblSurName" runat="server" CssClass="control-label labelSize"></asp:Label>
                           
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox> 
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                TargetControlID="txtSurname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="lblPan" runat="server" CssClass="control-label labelSize"></asp:Label>
                        
                            <asp:TextBox ID="txtPan" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                          </div>
                         </div>


                           <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblShwRecords1" runat="server" CssClass="control-label labelSize" ></asp:Label>
                           
                                <asp:DropDownList ID="ddlShwRecrds1" runat="server" CssClass="form-control form-select"  AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlShwRecrds1_SelectedIndexChanged">
                                </asp:DropDownList>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                              <%--//ADDED BY AJAY 01 JUNE 2023--%>
                             <asp:Label ID="Label8" runat="server" CssClass="control-label labelSize" Text="Member Type"></asp:Label>
                           
                                <asp:DropDownList ID="ddlmemtype" runat="server" CssClass="form-control form-select mandatory">
                                </asp:DropDownList>
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             
                          </div>
                         </div>


                              <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align: center">
                               <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-success" OnClick="btnSearch_Click" OnClientClick="return getvalid();" > <span class="glyphicon glyphicon-search BtnGlyphicon"></span>SEARCH </asp:LinkButton>
                              &nbsp;

                               <asp:Button ID="btnClear" runat="server" CssClass="btn btn-clear" TabIndex="43" OnClientClick="doClear();return false;"
                                    Text="CLEAR" Width="80px" OnClick="btnClear_Click" />&nbsp;
                          </div>
                         </div>

                             <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align: center;margin-bottom:5px;">
                          <asp:Label ID="Label2" runat="server"></asp:Label>

                          </div>
						  
                         </div>

                            </div>
                       </div>
        </div>
                      <%-- <br />--%>
                       <div id="trGridCndStatus" runat="server" visible="false" class="card PanelInsideTab">
                           <div id="Div2" runat="server" class="panelheadingAliginment" >
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
 
                                <asp:Label ID="Label6" runat="server"   CssClass="control-label HeaderColor"> </asp:Label>
                                
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Div1','Span1');return false;"></span>
                            </div>
                        </div>
                    </div>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                  <div id="Div1" runat="server"  style="padding: 10px;overflow-x: scroll;">
                                   <%-- <div style="width:1000px;overflow-x:auto; text-align:center;margin-bottom: 10px;margin-top: 38px;">--%>
                                    
                                        <asp:GridView ID="GridCndStatus" runat="server" Visible="false"  CssClass="footable"  
                                            AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridCndStatus_PageIndexChanging" 
                                              
                                            OnSorting="GridCndStatus_Sorting" Width="100%"  
                                            OnRowCommand="GridCndStatus_RowCommand" onrowdatabound="GridCndStatus_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                       <HeaderStyle CssClass="gridview th" />
                                       <PagerStyle CssClass="disablepage" />
                                             <Columns>
                                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                            <ItemTemplate>
                                                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                             
						                                 <ItemStyle CssClass="clscenter"/>
                                                            <HeaderStyle CssClass="clsCenter" />
                                                                        </asp:TemplateField>

                                                        <asp:BoundField SortExpression="EmpCode" HeaderText="Franchisee Code" DataField="EmpCode" >
                                                            <ItemStyle CssClass="clscenter"/>
                                                            <HeaderStyle CssClass="clsCenter" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField SortExpression="LegalName" HeaderText="Franchisee Name" > 
                                                            <ItemTemplate>
                                                             
                                                                <asp:Label ID="lblCndNo" runat="server" Text='<%# Eval("LegalName") %>' CommandArgument='<%# Eval("LegalName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                              <ItemStyle CssClass="clsLeft" />
                                                              <HeaderStyle CssClass="clsLeft" />
                                                        </asp:TemplateField>

                                                        <asp:BoundField SortExpression="SAPCODE" HeaderText="Sap Code" DataField="SAPCODE" >
                                                             <ItemStyle CssClass="clscenter"/>
                                                             <HeaderStyle CssClass="clsCenter" />
                                                        </asp:BoundField>

                                                        <asp:BoundField SortExpression="Channel" HeaderText="Channel" DataField="Channel" >
                                                          <ItemStyle CssClass="clsLeft" />
                                                              <HeaderStyle CssClass="clsLeft" />
                                                        </asp:BoundField>

                                                        <asp:BoundField SortExpression="SubChannel" HeaderText="SubChannel" DataField="SubChannel" >
                                                         <ItemStyle CssClass="clsLeft" />
                                                              <HeaderStyle CssClass="clsLeft" />
                                                        </asp:BoundField>

                                                        <asp:BoundField SortExpression="UnitLegalName" HeaderText="Branch " DataField="UnitLegalName" >
                                                          <ItemStyle CssClass="clsLeft" />
                                                              <HeaderStyle CssClass="clsLeft" />
                                                        </asp:BoundField>

                                                        <asp:BoundField SortExpression="Status" HeaderText="Status" DataField="Status" >
                                                            <ItemStyle CssClass="clsLeft" />
                                                              <HeaderStyle CssClass="clsLeft" />
                                                        </asp:BoundField>
                                                        <asp:BoundField SortExpression="REQUEST DATE" HeaderText="Create Date" DataField="CreateDtim" >
                                                            <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField SortExpression="Unitcode" HeaderText="Unitcode"  ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunitcode" runat="server" Text='<%# Eval("unitcode") %>' ToolTip='<%# Eval("unitcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>

                                                        <asp:TemplateField SortExpression="Actionable" HeaderText="Actionable"   ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaction1" runat="server" Text='<%# Eval("Actionable") %>' ToolTip='<%# Eval("Actionable") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                         
                                                        <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div style="white-space: nowrap; width: 100%;">
                                                                  <%--  <i class="fa fa-flash"></i>--%>
                                                                    <asp:LinkButton ID="lblRequest" runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("MemCode") %>' Text="View Details" 

                                                                        CommandName="ReqClick"></asp:LinkButton>

                                                                 
                                                                </div>
                                                           
                                                            </ItemTemplate>
                                                              <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                        </asp:TemplateField>
                                                     
                                                             <asp:TemplateField Visible="false">
                                                             <ItemTemplate>
                                                                   <%--<asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label>--%>
                                                             </ItemTemplate>
                                                            <ItemStyle CssClass="clscenter"/>
                                                        </asp:TemplateField>
                                                    
                                                    </Columns>
                                             
                                        </asp:GridView>
                                         </div>
                                         <div id="trGridCndStatusPage" runat="server" visible="false">
                                <div>
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnPreStatus" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtStatus" Text="1" Style="width: 35px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;"   ReadOnly="true" />
                                                <asp:Button ID="btnNextStatus" Text=">" CssClass="form-submit-button" runat="server"
                                                    Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                    OnClick="btnnext_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                         </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                           
                        </div>

                       <br />
                     <%--Ended by sanoj 14032023--%>

                    <table class="tableIsys" style="border-collapse: separate; display:none; left: 0in; position: relative; top: 0px; width: 1000px; z-index:4" >
                        <tr>
                            <td class="test" colspan="4" align="left"  style="border-collapse: separate;height:20px;" >
                               
                            </td>
                        </tr>
                        <tr id="trApplication" runat="server" style="height:35px">
                            <td class="formcontent" align="left" style="height:24px;">
                                <asp:Label ID="lblAppNo" runat="server"></asp:Label> 
                            </td>
                            <td class="formcontent" align="left" style="height:24px;">
                                <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox><%--Added by shreela on 6/03/14 for validation--%>
                              <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtAppNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td id="Td1" class="formcontent" runat="server" style="height:24px;" colspan="2"></td>
                        </tr>
                        <tr id="trCandidateNo" runat="server" style="height:35px; display:none">
                             <td class="formcontent" align="left" style="height: 24px;">
                                    <asp:Label ID="lblCandidateCode" runat="server" ></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 24px; width: 243px;" align="left">
                                    <asp:TextBox ID="txtCandCode" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtCandCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                   <%-- Added by shreela on 7/03/14--%>
                           <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                            <asp:Label ID="LblhomeNote" runat="server" Visible="false" Text="(Value should be of 12 digit.)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                           <%-- End--%>
                            </td>
                            <td class="formcontent" align="left" style="height: 24px">
                                <asp:Label ID="lblApplicationNo" runat="server" ></asp:Label><%--lblCandidateCode changed to lblApplicationNo by kalyani on 23-12-2013 for new requirement--%>
                            </td>
                            <td class="formcontent" style="width: 210px; height: 24px" align="left">
                                <asp:TextBox ID="txtApplicatoNo" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox><%--txtCandCode changed to txtApplicatoNo by kalyani on 23-12-2013 for new requirement--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtApplicatoNo" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            
                        </tr>
                        <%--added by ajay start 1-21-2021--%>
                         <tr style="height:35px">
                            <td class="formcontent" align="left" style="height: 24px">
                                
                            </td>
                             <td class="formcontent" style="width: 210px; height: 24px" align="left">
                                

                                 </td>
                            <td class="formcontent" align="left" style="height: 24px">
                               
                            </td>
                             <td class="formcontent" style="width: 210px; height: 24px" align="left">
                                 </td>
                            </tr>
                      <%--  added by sanoj 14032023--%>
                       

                          <%--  ended by sanoj 14032023--%>
                        <%--added by ajay End 1-21-2021--%>
                        <tr style="height:35px">
                            <td class="formcontent" align="left" style="height: 24px">
                               
                            </td>
                            <td class="formcontent" style="width: 210px; height: 24px" align="left">
                               <%-- <asp:TextBox ID="txtGivenName" style="display:none" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox--%>
                              
                                <%--Added by shreela on 6/03/14 for validation--%>
                                <%--added by pranjali on 05-03-2014 for allowing only characters validation start--%>
                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_FrenchCode" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                TargetControlID="txtFrenchCode">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <%--added by pranjali on 05-03-2014 for allowing only characters validation end--%>
                            </td>
                            <td class="formcontent" align="left" style="height: 24px">
                               
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                TargetControlID="txtFrenchSap">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <%--added by pranjali on 05-03-2014 for allowing only characters validation end--%>
                            </td>
                        </tr>
                       
                        <tr style="height:35px">
                            <td class="formcontent" align="left" style="height:24px">
                               
                            </td>
                            <td class="formcontent" align="left" style="height:24px">
                                
                            </td>
                        </tr>
                        <%--Added  by sanoj 29-12-2021--%>
                        <tr id="trtraning" runat="server">
                                    <td class="formcontent" align="left" style="width: 20%">
                                       
                                    </td>
                                    <td id="tdreq" runat="server" class="formcontent" style="width: 227px; height: 21px"
                                        align="left">
                                        
                                    </td>
                                </tr>
                        <%--Endded  by sanoj 29-12-2021--%>

                        <tr style="height:35px">
                           
                            <td class="formcontent" align="left" style="height: 24px">
                               
                                
                            </td>
                            <td id="tdPan" class="formcontent" align="left" style="height: 24px" >
                            
                        </td>
                        </tr>

                        <tr id="trCodedlicdetails" style="display:none" runat="Server" >
                            
                            <td class="formcontent" style="width: 227px; height: 21px" align="left">
                                    <asp:Label ID="lblAgntBroker" runat="server" Width="140px"></asp:Label>
                                </td>
                                <td class="formcontent" style="width: 227px; height: 21px" align="left" nowrap="nowrap">
                                    <asp:TextBox ID="txtAgntBroker" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>    
                            
                            <td class="formcontent" style="width: 227px; height: 21px" align="left">
                                <asp:Label ID="lblSapcode" runat="server" ></asp:Label>
                            </td>
                            <td class="formcontent" style="height: 21px" align="left">
                                <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                            
                        </tr>

                          <%-- added by shreela on 10042014 start--%>
                       
                       <tr id="trshowrecords" runat="server" visible="false" style="height:35px">
                            <td class="formcontent" align="left" style="height: 24px">
                               
                            </td>
                            <td runat="Server" id="td2" class="formcontent" align="left" style="height: 24px">
                              </td>
                             <td runat="Server" id="td3" class="formcontent" align="left" nowrap="nowrap" style="height: 24px">
                             </td>
                        </tr>
                        <%--added by shreela on 10042014 end--%>
                       
                        <tr  runat="server" >    
                            <td colspan="4" align="center" style="height: 20px">
                            
                            <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                                            <i class="fa fa-search"></i>--%>
                               
                                   <%--</div>--%>
                                        <span style="padding-left: 3px;"></span>
                            
                             <%--<div class="btn btn-xs btn-primary" 
                                            style="white-space: nowrap; width: 110px">
                                            <i class="fa fa-times"></i>--%>
                                        
                              
                                   <%-- </div>--%>
                            
                           <%-- </div>--%>
                                        <span style="padding-left: 3px;"></span>
                                        <%--<div id="divbtnAddnew" runat="Server" visible="false" class="btn btn-xs btn-primary" 
                                            style="white-space: nowrap; width: 110px">
                                            <i class="fa fa-times"></i>--%>
                                        
                                <asp:Button ID="btnAddnew" OnClick="btnSubmit_Click" runat="server" Visible="false" 
                                    Text="Add New" Width="80px" CssClass="standardbutton" Height="19px"></asp:Button>
                                    <%--</div>--%>

                                     <asp:Button ID="btnReFresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnReFresh_Click"  />
                           
                            <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div>
                                       

                                   <%-- added by pranjali add new button --%>
                                
                            </td>
                        </tr>
                        <tr id="trLbl" runat="server">
                            <td colspan="4" align="center">
                                <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
               <%-- </td>--%>
                   <%-- </div>
                </div>--%>
                <%--</div>--%>
            <%--</tr>
             </table>--%>
          <%--  <tr id="tr31" runat="server">--%>
            <div id="tr31" runat="server" class="card  PanelInsideTab" visible="false" style="margin-top: -6px;">
                <%--ajay--%>
                <div id="Div3" runat="server" class="panelheadingAliginment" >
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
 
                                <asp:Label ID="Label7" runat="server" Text="Member Search Result"  CssClass="control-label HeaderColor">
                                </asp:Label>
                                <%-- <asp:Label ID="lblPageInfo1" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>--%>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','Span2');return false;"></span>
                            </div>
                        </div>
                    </div>
               
                       <div id="trDgDetails"  runat="server" >
                                <%--<asp:UpdatePanel ID="UpdatePanel002" runat="server">
                                   <ContentTemplate>--%>
                                       <div    style="overflow-x: scroll;">
                                        <asp:GridView ID="dgDetails" runat="server"  CssClass="footable"  
                                            AllowSorting="True" 
                                            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="dgDetails_PageIndexChanging" 
                                            OnSorting="dgDetails_Sorting" Width="100%" 
                                            OnRowCommand="dgDetails_RowCommand" onrowdatabound="dgDetails_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                       <HeaderStyle CssClass="gridview th" />
                                       <PagerStyle CssClass="disablepage" />
                                            <Columns>
                                                <%--column 0--%>
                                                <asp:TemplateField HeaderText="MemberCode">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("MemCode") %>' CommandArgument='<%# Eval("MemCode") %>'
                                                            CommandName="click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter" />
                                                    <HeaderStyle CssClass="clscenter" />
                                                </asp:TemplateField>
                                                <%--column 1--%>
                                                <asp:TemplateField SortExpression="EmpCode" HeaderText="Code" >
                                                    <ItemTemplate>
                                                        <%--<asp:LinkButton CssClass="LnkBtn" ID="lbProsID" runat="server" Text='<%# Eval("EmpCode") %>' CommandArgument='<%# Eval("EmpCode") %>'
                                                            CommandName="click"></asp:LinkButton>--%><%--commented by ajay--%>
                                                         <asp:Label ID="lbProsID" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter" />
                                                    <HeaderStyle CssClass="clscenter" />
                                                </asp:TemplateField>
                                                <%--column 2--%>
                                                <asp:TemplateField  HeaderText="Name" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("LegalName") %>' ToolTip='<%# Eval("LegalName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clsleft" />
                                                    <HeaderStyle CssClass="clsleft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="unitcode" HeaderText="Unitcode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunitcode" runat="server" Text='<%# Eval("unitcode") %>' ToolTip='<%# Eval("unitcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter" />
                                                    <HeaderStyle CssClass="clscenter" />
                                                </asp:TemplateField>  <%--added by sanoj--%>
                                                <%--column 3--%>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clsleft" />
                                                    <HeaderStyle CssClass="clsleft" />
                                                </asp:TemplateField>
                                                <%--column 4--%>
                                                <asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("Status") %>' ToolTip='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clsleft" />
                                                    <HeaderStyle CssClass="clsleft" />
                                                </asp:TemplateField>
                                                <%--column 5--%>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter" />
                                                    <HeaderStyle CssClass="clscenter" />
                                                </asp:TemplateField>
                                                <%--column 6--%>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbizsrc" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clsleft" />
                                                    <HeaderStyle CssClass="clsleft" />
                                                </asp:TemplateField>
                                                <%--column 7--%>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtName" runat="server" Text='<%# Eval("RecruiterName") %>' ToolTip='<%# Eval("RecruiterName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clsleft" />
                                                    <HeaderStyle CssClass="clsleft" />
                                                </asp:TemplateField>
                                                <%--column 8--%>
                                                <asp:TemplateField SortExpression="MemCode" HeaderText="Recruiter Code" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtCode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter" />
                                                    <HeaderStyle CssClass="clscenter" />
                                                </asp:TemplateField>
                                                <%--column 9--%>
                                               <%-- <asp:TemplateField SortExpression="RptName" HeaderText="Reporting Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 10--%>
                                                <%--<asp:TemplateField SortExpression="RptCode" HeaderText="Reporting Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 11--%>
                                               <%-- <asp:TemplateField SortExpression="CndURN" HeaderText="URN No." HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblurn" runat="server" Text='<%# Eval("CndURN") %>' ToolTip='<%# Eval("CndURN") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 12--%>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("SAPCODE") %>' ToolTip='<%# Eval("SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
                                                </asp:TemplateField>
                                                <%--column 13--%>
                                                <%--<asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 14--%>
                                               <%-- <asp:TemplateField SortExpression="LcnExpDate" HeaderText="LcnExpDate" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbllcnexpdate" runat="server" Text='<%# Eval("LcnExpDate") %>' ToolTip='<%# Eval("LcnExpDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 15--%>
                                               <%-- <asp:TemplateField SortExpression="Actionable" HeaderText="Actionable" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaction" runat="server" Text='<%# Eval("Actionable") %>' ToolTip='<%# Eval("Actionable") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 16--%>
                                               <%-- <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                     <div style="width: 100%;">
                                                     <i class="fa fa-male"></i>
                                                        <asp:LinkButton ID="lnkagent" runat="server" Text="Create Agent" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="CreateAgent"></asp:LinkButton>
                                                            </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 17--%>
                                               <%-- <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkcnd" runat="server" Text="Revive" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="Revive"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 18--%>
                                              <%--  <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderText="License Issue Date" ItemStyle-Width="5%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:label ID="lblLcnIssDate" runat="server" Text='<%# Eval("LcnIssDate") %>'></asp:label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 19--%>
                                               <%-- <asp:TemplateField SortExpression="CandidateNo" 
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkCndNo_view" runat="server" Text="View Details" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="ViewStatus"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 20--%>
                                               <%-- <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                 <i class="fa fa-credit-card"></i>
                                                    <asp:LinkButton ID="lnklicn" runat="server" Text="Select" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="License Renewal"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%--column 21--%>
                                                <%--<asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSMAlloct" runat="server" Text="Allocate SM" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="SMAllocation"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%--column 22--%>
                                               <%-- <asp:TemplateField SortExpression="SystemDate" HeaderText="Preffered Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPreffDates" runat="server" Text='<%# Eval("SystemDate","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("SystemDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <%--column 23--%>
                                                <%--<asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPrefDt" runat="server" Text="Preffered Date" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="Preffered Date"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <%--column 24--%>
                                                <%--<asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false"> 
                                                
                                                <ItemTemplate>
                                                    <asp:label ID="lblLicenseStatus" runat="server" Text='<%# Eval("LicenseStatus") %>'></asp:label>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                 <%--column 25 for Agent Profile cr 17 --%>
                                                <%--<asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                 
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LblAgentProfile" runat="server" Text="Agent Profile" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="Agent Profile"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            
                                        </asp:GridView>
                                           </div>
                                            <div>
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />                                              
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                                         
                                 <%-- </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                          </asp:UpdatePanel>--%>
                                 </div>
                <%--ajay--%>
           
              <%--  <td align="center">--%> <%--style="width: 100%;"--%>
                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>--%>
                    <table class="formtable" style="border-collapse: separate; left: 0in; position: relative; top: 8px; z-index:4">
                        <%--<tr id="trnote" runat="server" visible="false" >
                            <td class="formcontent2" colspan="2" style="border-collapse: separate; height:20px;">
                              
                         
                           </td>
                                       
                        </tr>--%>
                        <tr id="trDetails" runat="server">
                            <td class="test" style="border-collapse: separate; height:20px;">
                                <asp:UpdatePanel ID="UpdatePanel001" runat="server">
                                    <ContentTemplate>
                                    <asp:Label ID="lblprospectsearch" runat="server" Text="Prospect Search Results" Font-Bold="true" Font-Size="Small"></asp:Label>
                                        <span style="padding-left:650px;"></span>
                                      <%--  <asp:Label ID="lblPageInfo" runat="server"></asp:Label>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                               <%-- added by shreela on 24032014--%>
                            <td class="test" align="right">
                          <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Width="160px"></asp:Label>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server" style="display:none;">
                            <td class="test"  align="left"  style="border-collapse: separate;height:20px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Search Result"  Font-Bold="true" style="text-align:left;" Font-Size="Small"></asp:Label>
                                        <span style="padding-left:500px;"></span>
                                       <%-- <asp:Label ID="lblPageInfo1" runat="server"></asp:Label>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                                <%-- added by shreela on 24032014--%>
                            <td class="test"  align="right"  style="border-collapse: separate;height:20px;">
                            <asp:Label ID="lblPageInfo1" runat="server" Font-Bold="true"  Width="160px"></asp:Label>
                            
                            </td>
                        </tr>
                        <%--<tr id="trDgDetails" runat="server">--%>
                      
                       <%-- start  by sanoj 23052022--%>
                         <tr id="trdocs" runat="server">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                   <ContentTemplate>
                                        <asp:GridView ID="gvDocs" runat="server" CssClass="footable" RowStyle-CssClass="dgViewGrid"   
                                            AllowSorting="True" CellPadding="1" 
                                            AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="gvDocs_RowCommand" OnPageIndexChanging="gvDocs_PageIndexChanging" 
                                             Width="100%" >

                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                          <PagerStyle CssClass="disablepage" />
                                             <HeaderStyle CssClass="gridview th" />

                                            <Columns>
                                                        <asp:BoundField SortExpression="EmpCode" HeaderText="Franchisee Code" DataField="EmpCode"  
                                                            HeaderStyle-HorizontalAlign="Center">
                                                              <ItemStyle CssClass="clscenter"/>
                                                              <HeaderStyle CssClass="colHeader-CenterAlign" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField SortExpression="LegalName" HeaderText="Franchisee Name" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLegalName" runat="server" Text='<%# Eval("LegalName") %>' CommandArgument='<%# Eval("LegalName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="clsLeft"/>
                                                             <HeaderStyle CssClass="clsLeft" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField SortExpression="SAPCODE" HeaderText="Sap Code" DataField="SAPCODE"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <ItemStyle CssClass="clsCenter"/>
                                                              <HeaderStyle CssClass="clsCenter" />
                                                        </asp:BoundField>
                                                      
                                                     
                                                        <asp:TemplateField SortExpression="RequestDate" HeaderText="Request Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSponDate" runat="server" Text='<%# Eval("RequestDate","{0:dd/MM/yyyy}") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                           <ItemStyle CssClass="clsCenter"/>
                                                              <HeaderStyle CssClass="clsCenter" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="PAN No" HeaderText="PAN" 
                                                            ItemStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPanNo" runat="server" Text='<%# Eval("PAN No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                            <HeaderStyle CssClass="colHeader-CenterAlign"/>
                                                        </asp:TemplateField> 
                                                 
                                                        <asp:TemplateField SortExpression="Request" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <div style="white-space: nowrap; width: 100%;">
                                                                    <i class="fa fa-flash"></i>
                                                                    <asp:LinkButton ID="lblRequest" runat="server" CommandArgument='<%# Eval("MemCode") %>' Text="View Document" 
                                                                        CommandName="click"></asp:LinkButton>
                                                                </div>
                                                           
                                                            </ItemTemplate>
                                                              <ItemStyle CssClass="clsLeft"/>
                                                              <HeaderStyle CssClass="clsLeft" />                                                        </asp:TemplateField>
                                                     
                                                             <asp:TemplateField Visible="false">
                                                             <ItemTemplate>
                                                                    <asp:Label ID="lblCFRFlag" runat="server" Text='<%#Bind("CFR") %>'></asp:Label> 
                                                             </ItemTemplate>
                                                              <ItemStyle HorizontalAlign="Left" />
                                                                 <HeaderStyle CssClass="colHeader-CenterAlign"/>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField SortExpression="EditReq" HeaderText="">
                                                            <ItemTemplate>
                                                                
                                                                <asp:LinkButton ID="lnkEditReq" runat="server" Text='<%# Eval("EditReq") %>' CommandArgument='<%# Eval("CndNo") %>'
                                                                    CommandName="EditReqClick"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="EditPANReq" HeaderText="">
                                                            <ItemTemplate>
                                                                
                                                                <asp:LinkButton ID="lnkEditPanReq" runat="server" Text='<%# Eval("EditPANReq") %>'
                                                                    CommandArgument='<%# Eval("CndNo") %>' CommandName="EditPanReqClick">
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                          
                                         
                                        </asp:GridView>
                                         <%--</div>--%>



                                       <br/>
                                         <div>
                                        <center>

                                          <table style="display:none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btndocsPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                        background-color: transparent; float: left; margin: 0; height: 34px;" OnClick="btndocsPrev_Click"  />
                                                                    <asp:TextBox runat="server" ID="txtPage2" Text="1" Style="width: 40px; border-style: solid;
                                                                        border-width: 1px; border-color: Gray; height: 34px; float: left; margin: 0;
                                                                        text-align: center;" ReadOnly="true" />
                                                                    <asp:Button ID="btndocNext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                        float: left; margin: 0; height: 34px;" Width="40px" OnClick="btndocNext_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                         </center>
                                        
                                </div>
                                  </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                          </asp:UpdatePanel>
                            </td>
                        </tr>

                       


                        <%--added by sanoj 29-12-2021--%>
                           <%-- added by shreela on 14042014 start--%>
                       <tr id="trdgRenTnr" runat="server" visible="false">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgRenTrn" runat="server" 
                                             AllowSorting="True" PagerStyle-HorizontalAlign="Center" 
                                             RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" 
                                             AutoGenerateColumns="False" AllowPaging="True" HeaderStyle-ForeColor="White"
                                             PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" OnPageIndexChanging="dgRenTrn_PageIndexChanging"
                                             OnSorting="dgRenTrn_Sorting" OnRowCommand="dgRenTrn_RowCommand" OnRowDataBound="dgRenTrn_RowDataBound"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CndNo") %>' ToolTip='<%# Eval("CndNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ProspectId") %>' ToolTip='<%# Eval("ProspectId") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("GivenName") %>' ToolTip='<%# Eval("GivenName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("cndStatus") %>' ToolTip='<%# Eval("cndStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                    <div style="width: 100%;">
                                                                    <i class="fa fa-calendar"></i>
                                                        <asp:Label ID="lblDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSapCode" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="DwnldCnt" HeaderText="Download Count" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDwnldCnt" runat="server" Text='<%# Eval("DwnldCnt") %>' ToolTip='<%# Eval("DwnldCnt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRenTrnU" runat="server" Text="TCC Upload" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="RenewalU"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRenTrnD" runat="server" Text="TCC Download" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="RenewalD"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDwnld" runat="server" Text="Download" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="Dwnld"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAction" runat="server" Text="Actionable" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="Action"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--added by pranjali on 18-10-2014 for license upload download start--%>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Agent Lic & ID Upload" ItemStyle-Width="8%" Visible="false"> <%--18--%>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkLicUpld" runat="server" Text="Upload" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="LicUpld"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%" Visible="false"> <%--19--%>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkLicDwnld" runat="server" Text="License Download" CommandArgument='<%# Eval("CndNo") %>'
                                                            CommandName="LicDwnld"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--added by pranjali on 18-10-2014 for license upload download end--%>
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> 
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" ></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                       <%-- added by shreela on 14042014 end--%>
                        <%--added by shreela on 21042014----start--%>
                        <tr id="trdgreExam" runat="server" visible="false">
                            <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                            <%-- added by shreela--%>
                            <asp:GridView ID="dgReExam" runat="server" AllowSorting="True" PagerStyle-HorizontalAlign="Center"
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue"
                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="dgReExam_PageIndexChanging"
                                    PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" OnSorting="dgReExam_Sorting"
                                    Width="100%" Visible="false" OnRowDataBound="dgReExam_RowDataBound" OnRowCommand="dgReExam_RowCommand">
                                    <Columns>
                                        <asp:TemplateField SortExpression="Candidate No" HeaderText="Candidate No" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <i class="fa fa-male" ></i>
                                             <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CndNo") %>' ToolTip='<%# Eval("CndNo") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Application No" HeaderText="Application No" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblApp" runat="server" Text='<%# Eval("AppNo") %>' ToolTip='<%# Eval("AppNo") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="GivenName" HeaderText="Given Name" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblGname" runat="server" Text='<%# Eval("GivenName") %>' ToolTip='<%# Eval("GivenName") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ExmResult" HeaderText="Exam Result" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblExm" runat="server" Text='<%# Eval("ExmResult") %>' ToolTip='<%# Eval("ExmResult") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TCCDate" HeaderText="TCC Date" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblTccD" runat="server" Text='<%# Eval("TCCDate") %>' ToolTip='<%# Eval("TCCDate") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TCC" HeaderText="TCC" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblTcc" runat="server" Text='<%# Eval("TCC") %>' ToolTip='<%# Eval("TCC") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                   <%-- <asp:TemplateField SortExpression="TCCFlag" HeaderText="TCC Flag" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblTccF" runat="server" Text='<%# Eval("TCCFlag") %>' ToolTip='<%# Eval("TCCFlag") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField SortExpression="AppNO" HeaderStyle-HorizontalAlign="Center"
                                             HeaderText="" ItemStyle-Width="8%">
                                             <ItemTemplate>
                                               <div id="divReExam" runat="server">
                                                                    <i class="fa fa-share-square-o"></i>  
                                             <asp:LinkButton ID="lnkRe" runat="server" Text="ReExam" CommandArgument='<%# Eval("CndNo") %>'
                                                  CommandName="ReExam" Visible="false"></asp:LinkButton>
                                             <asp:LinkButton ID="lnkSpon" runat="server" Text="Sponsorship" CommandArgument='<%# Eval("CndNo") %>'
                                                  CommandName="Sponsorship" Visible="false"></asp:LinkButton></div>
                                             </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center">
                                    <%--Font-Underline="True"--%>
                                    <%--Commented by pranjali on 14-12-2013 for removing the link for page indexing of the current page--%>
                                    </PagerStyle>
                                    <HeaderStyle CssClass="portlet blue"  ForeColor="White"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                             </asp:GridView>
                             </ContentTemplate>
                             <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                             </Triggers>
                          </asp:UpdatePanel>
                          </td>
                       </tr>
                       <tr id="trRprt" runat="server" visible="false">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GvRprt" runat="server" 
                                             AllowSorting="True" PagerStyle-HorizontalAlign="Center" 
                                             RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" 
                                             AutoGenerateColumns="False" AllowPaging="True" HeaderStyle-ForeColor="White"
                                             PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" OnPageIndexChanging="GvRprt_PageIndexChanging"
                                              OnRowCommand="GvRprt_RowCommand" OnRowDataBound="GvRprt_RowDataBound"
                                            Width="100%"> <%--OnSorting="GvRprt_Sorting"--%>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvRprt" runat="server" Text="Appointment Letter" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="Report"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> 
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" ></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>


                       <%--added by rachana on 10/04/2015 for retrival Process start--%>
                      <tr id="tr3" runat="server" visible="false" >
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                      <asp:GridView ID="GrdDocumentRet" runat="server" AllowPaging="true" PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable"
                                      HorizontalAlign="Left" PagerStyle-ForeColor="Blue" AutoGenerateColumns="false" AllowSorting="false" HeaderStyle-ForeColor="White" PagerStyle-Font-Underline="true"
                                      PagerStyle-CssClass="pagelink" OnRowDataBound="GrdDocumentRet_RowDataBound" OnPageIndexChanging="GrdDocumentRet_PageIndexChanging" OnSorting="GrdDocumentRet_Sorting">
                                      <Columns>
                                                <asp:TemplateField  HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <asp:CheckBox ID="chkrcvd" runat="server" /> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCndRet" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppRet" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="NamePronoun" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnnameRet" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnmeRet" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTimRet" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannelRet" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntnameRet" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RecruitEmpCode" HeaderText="Recruiter Code"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRecruiterCodeRet" runat="server" Text='<%# Eval("RecruitEmpCode") %>' ToolTip='<%# Eval("RecruitEmpCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptNameRet" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCodeRet" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="PAN" HeaderText="PAN"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPANRet" runat="server" Text='<%# Eval("PAN") %>' ToolTip='<%# Eval("PAN") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="LcnNo" HeaderText="LcnNo"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>' ToolTip='<%# Eval("LcnNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="" HeaderText="Document Received Date"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                  <ItemTemplate>
                                                   
                                                            <asp:TextBox ID="txtdocrecdate" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" Style="display: none" runat="server"
                                    Width="80px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    ValidChars="1234567890/" FilterMode="ValidChars" TargetControlID="txtdocrecdate"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocrecdate"
                                    PopupButtonID="Image1" Format="dd/MM/yyyy" />  </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
             
                                                <asp:TemplateField SortExpression="" HeaderText="Remark"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarkRet" runat="server" Width="140px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> 
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" ></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                      </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                      <%--added by rachana on 10/04/2015 for retrival Process end--%>

                      <%--Added by Nikhil on 17-04-2015 for License & ID Download start--%>
                        <%--<tr id="trLICId" runat="server" visible="false">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdGrdLicId" runat="server">
                                    <ContentTemplate>--%> 
                         
                           <%-- </td>
                        </tr>--%>
                        <%--Added by nikhil on 17-04-2015 end--%>

                        <%-- Added by pallavi on 25-08-2020 for License Download for posp start--%>

                            <tr id="trLICPosp" runat="server" visible="true">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdLicPosp" runat="server" 
                                             AllowSorting="True" PagerStyle-HorizontalAlign="Center" 
                                             RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" 
                                             AutoGenerateColumns="False" AllowPaging="True" HeaderStyle-ForeColor="White"
                                             PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" 
                                            Width="100%" onrowcommand="GrdLicPosp_RowCommand"
                                            onpageindexchanging="GrdLicPosp_PageIndexChanging" onsorting="GrdLicPosp_Sorting"> <%--OnSorting="GvRprt_Sorting"--%>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvLic" runat="server" Text="License Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="PospAppointment"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
<%--                                                <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvID" runat="server" Text="ID Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="ID"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> 
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" ></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <%--Added by pallavi on 25-08-2020 for License Download for posp end--%>


                          <%--Added by Nikhil on 31-08-2015 for NOC IC start--%>
                        <tr id="trNOCIC" runat="server" visible="false">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePane20" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridNOCIC" runat="server" 
                                             AllowSorting="True" PagerStyle-HorizontalAlign="Center" 
                                             RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" 
                                             AutoGenerateColumns="False" AllowPaging="True" HeaderStyle-ForeColor="White"
                                             PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" 
                                            Width="100%" onrowcommand="GridNOCIC_RowCommand" 
                                            onpageindexchanging="GridNOCIC_PageIndexChanging" onsorting="GridNOCIC_Sorting"> <%--OnSorting="GvRprt_Sorting"--%>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkNOCIC" runat="server" Text="NOC IC Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="NOC"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> 
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" ></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <%--Added by nikhil on 31-08-2015 end--%>

                        <%--Added by Rahul on 21-04-2015 for Retrieval Process start--%>
                        <tr id="trRetrieval" runat="server" visible="false">
                            <td colspan="2">
                                <asp:GridView ID="dgRetrieval" runat="server"   
        AllowSorting="True" PagerStyle-HorizontalAlign="Center" 
        RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" 
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="dgRetrieval_PageIndexChanging" 
        PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" 
        OnSorting="dgRetrieval_Sorting" Width="100%"  HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Small"
        OnRowCommand="dgRetrieval_RowCommand" onrowdatabound="dgRetrieval_RowDataBound">
        <Columns>
            <%--column 0--%>
             <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                <ItemTemplate>
                    <i class="fa fa-credit-card"></i>
                        <asp:LinkButton ID="lnklicn" runat="server" Text="Retrieval" CommandArgument='<%# Eval("CandidateNo") %>'
                            CommandName="License Renewal"></asp:LinkButton>
                 </ItemTemplate>
               </asp:TemplateField>
            <%--column 1--%>
            <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Application No" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton CssClass="LnkBtn" ID="lbProsID" runat="server" Text='<%# Eval("ApplicationNo") %>' CommandArgument='<%# Eval("ApplicationNo") %>'
                        CommandName="click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <%--column 2--%>
            <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="Candidate No" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblCandidateNo" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' style="padding-left:5px;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--column 3--%>
            <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" >
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
            </asp:TemplateField>
            <%--column 4--%>
            <asp:TemplateField SortExpression="AgnCode" HeaderText="Agent Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblAgnCode" runat="server" Text='<%# Eval("AgnCode") %>' ToolTip='<%# Eval("AgnCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" ></ItemStyle>
            </asp:TemplateField>
            <%--column 5--%>
            <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 3--%>
            <%--<asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("CndStatus") %>' ToolTip='<%# Eval("CndStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" ></ItemStyle>
            </asp:TemplateField>--%>
            <%--column 6--%>
            <asp:TemplateField SortExpression="PAN No" HeaderText="PAN No" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                <ItemTemplate>
                    <asp:Label ID="lblPANNo" runat="server" Text='<%# Eval("PAN No") %>' ToolTip='<%# Eval("PAN No") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="7%"></ItemStyle>
            </asp:TemplateField>
            <%--column 7--%>
            <asp:TemplateField SortExpression="LcnNo" HeaderText="License No." HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                <ItemTemplate>
                    <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>' ToolTip='<%# Eval("LcnNo") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 8--%>
            <asp:TemplateField SortExpression="EmpCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                <ItemTemplate>
                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 9--%>
            <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Label ID="lblAgtName" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
            </asp:TemplateField>
            <%--column 10--%>
            <asp:TemplateField SortExpression="RptCode" HeaderText="Reporting Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                <ItemTemplate>
                    <asp:Label ID="lblRptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 11--%>
            <asp:TemplateField SortExpression="RptName" HeaderText="Reporting Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Label ID="lblRptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>' style="padding-left:5px;"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  Width="8%"></ItemStyle>
            </asp:TemplateField>
            <%--column 12--%>
            <asp:TemplateField SortExpression="BranchName" HeaderText="Branch Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                <ItemTemplate>
                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>' ToolTip='<%# Eval("BranchName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 13--%>
            <asp:TemplateField SortExpression="BranchCode" HeaderText="Branch Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                <ItemTemplate>
                    <asp:Label ID="lblBranchCode" runat="server" Text='<%# Eval("BranchCode") %>' ToolTip='<%# Eval("BranchCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>
            <%--column 14--%>
            <asp:TemplateField SortExpression="LcnExpDate" HeaderText="LcnExpDate" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="lbllcnexpdate" runat="server" Text='<%# Eval("LcnExpDate") %>' ToolTip='<%# Eval("LcnExpDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="8%"></ItemStyle>
            </asp:TemplateField>
            <%--column 5--%>
            <%--<asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                <ItemTemplate>
                    <asp:Label ID="lblbizsrc" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>--%>
            <%--column 7--%>
            <%--<asp:TemplateField SortExpression="MemCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                <ItemTemplate>
                    <asp:Label ID="lblAgtCode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>--%>
            <%--column 12--%>
            <%--<asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>--%>
            <%--column 13--%>
            <%--<asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                <ItemTemplate>
                    <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="5%"></ItemStyle>
            </asp:TemplateField>--%>
            <%--column 16--%>
             <%--<asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                <ItemTemplate>
                    <i class="fa fa-credit-card"></i>
                        <asp:LinkButton ID="lnklicn" runat="server" Text="Select" CommandArgument='<%# Eval("CandidateNo") %>'
                            CommandName="License Renewal"></asp:LinkButton>
                 </ItemTemplate>
               </asp:TemplateField>--%>
        </Columns>
        <RowStyle CssClass="sublinkodd"></RowStyle>
        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center">
        </PagerStyle>
        <HeaderStyle CssClass="portlet blue" ForeColor="white" HorizontalAlign="Center"></HeaderStyle>
        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
    </asp:GridView>
                            </td>
                        </tr>
                        <%--Added by Rahul on 21-04-2015 for Retrieval Process end--%>

                          <%--Added by amruta on 21-07-2015 for fees Wavier Process start--%>

                         <tr style="width: 100%" id="trDgFees"  visible="false" runat="server">
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView Style="color: blue; margin-top: 0px;" ID="dgFees" 
                                            runat="server" AllowSorting="True"
                                            PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                            RowStyle-CssClass="formtable" HorizontalAlign="Left" AutoGenerateColumns="False"
                                            AllowPaging="True" OnPageIndexChanging="dgFees_PageIndexChanging" OnSorting="dgFees_Sorting"
                                            OnRowCommand="dgFees_RowCommand" 
                                            OnRowDataBound="dgFees_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate ID" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblappno" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNamePronoun" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" ItemStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("RecruitAgtName") %>' ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDtim" HeaderText="Registration Date" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDtim" runat="server" Text='<%# Eval("CreateDtim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDtim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    
                                                    <ItemStyle ></ItemStyle>
                                                </asp:TemplateField>
                                             
                                             <asp:TemplateField SortExpression="DateSubmission" HeaderText="Date of Submission" ItemStyle-Width="10%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateSubmission" runat="server" Text='<%# Eval("submiteddate") %>' ToolTip='<%# Eval("submiteddate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>

                                                  <asp:TemplateField SortExpression="BranchName" HeaderText="Branch Name" ItemStyle-Width="10%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("Branch") %>' ToolTip='<%# Eval("Branch") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField SortExpression="ExmResult" HeaderText="Last exam result" ItemStyle-Width="10%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExmResult" runat="server" Text='<%# Eval("result") %>' ToolTip='<%# Eval("result") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Approve"  ItemStyle-Width="5%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblapprove" runat="server" Text='<%# Eval("cndStatus") %>' Visible="false" />
                                                         
                                                        <asp:RadioButton ID="rbrapprove" GroupName="Approval" runat="server" 
                                                            AutoPostBack="True" oncheckedchanged="rbrapprove_CheckedChanged" />
                                                    </ItemTemplate>
                                                  
                                                    
                                                    <ItemStyle Width="5%" />
                                                  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reject"  Visible="True" ItemStyle-Width="4%" >
                                                    <ItemTemplate>
                                                   
                                                        <asp:RadioButton ID="rbrreject" GroupName="Approval" runat="server" 
                                                            AutoPostBack="True" oncheckedchanged="rbrreject_CheckedChanged"/>
                                                    </ItemTemplate>
                                                    
                                                    
                                                    <ItemStyle Width="4%" />
                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%" >
                                                    <ItemTemplate>
                                                   
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" MaxLength="35"
                                                            Width="200px" />
                                                         <%--Added by Kalyani on 25-11-13 Hidden fields as Bank Templatefield is invisible start--%>
                                                        <input type="hidden" runat="server" id="hdntxtVarify" value="NotDone"  />
                                                        <input type="hidden" runat="server" id="hdnPmtMode" value='<%# Eval("PmtMode") %>' />
                                                         <%--Added by Kalyani on 25-11-13  Hidden fields as Bank Templatefield is invisible end--%>
                                                 
                                                    </ItemTemplate>
                                                    <HeaderStyle  HorizontalAlign="Center" />
                                                    <ItemStyle Width="23%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bank" HeaderStyle-ForeColor="teal" ItemStyle-Width="6%" Visible="false">
                                                    <ItemTemplate>
                                                        <input type="button" id="btnVarify" value="Verify" class="standardbutton" width="50px"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="Teal" />
                                                    <ItemStyle Width="6%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                            </PagerStyle>
                                            <HeaderStyle  Height="10px" CssClass="portlet blue" ForeColor="White" Font-Bold="true" HorizontalAlign="Center"></HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                        </asp:GridView>
                                       
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                                 
                        
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                         <%-- <tr id="tr5" runat="server" style="display:none">  
                         <td>
                         <asp:CheckBox ID="chkrcvd" runat="server" />
                             <asp:Label ID="lblconfirm" runat="server" Style="color: black" Text="Confirm"></asp:Label>
                         </td>
                         <td colspan="1">
                             &nbsp;</td>
                          
                           
                        </tr>--%>

                        
                       

                         <tr id="tr6" runat="server" >
                            <td align="center" colspan="2">
                              <%--<div class="btn btn-xs btn-primary" style="white-space:nowrap; width:124px;">
                                    <i class="fa fa-search"></i>--%>
                                <asp:Button ID="btnSubmit" OnClick="btnFeesSubmit_Click" runat="server"
                                    Text="Submit" Width="80px"  style='margin-top:10px' CssClass="standardbutton"  OnClientClick="StartProgressBar();"></asp:Button>
                                    <%--</div>--%>
                                    
                                    <span style="padding-left: 7px;"></span>
                                     <%--<div class="btn btn-xs btn-primary" style="white-space:nowrap; width:124px;">
                                    <i class="fa fa-times"></i>--%>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" CssClass="standardbutton"
                                    Height="19px" style='margin-top:10px' OnClick="btnCancel_Click" ></asp:Button>  
                                   <%-- </div> --%>
                                     <span style="padding-left: 7px;"></span>
                            </td>
                        </tr>
                         <%--Added by amruta on 21-07-2015 for fees Wavier Process end--%>
                      <%--added by shreela on 21042014----end--%>
                        <tr id="tr4" class="formcontent" runat="server" >
                                    <td align="center" colspan="2"  >
                                 <div id="divloadergrid" runat="server" style="display:none;">
                                 &nbsp;&nbsp; <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                 </div>
                          </td>
                      </tr>
                        <tr id="trButton" runat="server">
                            <td align="center">
                                
                            </td>
                        </tr>
                    </table>
                    <table id="tblSave" runat="server" class="formtable" style="Width: 1000px;background:white">
                    <tr id="trSave" runat="server">
                            <td colspan="4" align="center" style="height: 25px">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" CssClass="standardbutton"
                                    Height="19px" OnClick="btnSave_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
              <%--  </td>--%>
           <%-- </tr>--%>
                <%--  </div>--%>

                <div id="trLICId" runat="server"  visible="false" class="panel-body">
                                <%--<asp:UpdatePanel ID="UpdatePanel002" runat="server">
                                   <ContentTemplate>--%>
                                 <div style="padding: 10px;overflow-x: scroll;">
                                         
                                           <asp:GridView ID="GrdLicId" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdLicId_PageIndexChanging"
                                OnSorting="GrdLicId_Sorting" OnRowCommand="GrdLicId_RowCommand" style="overflow-x: scroll;">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                             <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id"   Visible="false"  >
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                      <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo"  HeaderText="EmpCode"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApp" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                     <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                  <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname"   Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"   >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                
                                                 <asp:TemplateField SortExpression="CandidateNo"   HeaderText="Action"  >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvLic" runat="server" Text="Welcome Letter" CommandArgument='<%# Eval("MemCode") %>'
                                                            CommandName="FPWelcmLttr"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                             
                                        </asp:GridView>
                                             </div>
                                           <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreLICId" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtLICId" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="btnNextLICId" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                               </div>
                                    
                                          
                             </div>
        </div>
         </ContentTemplate>
    </asp:UpdatePanel>
    </center>
    <%--Rachana 06/05/13--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="1000px" display="none">
        <iframe runat="server" id="ifrmMdlPopup" frameborder="0" display="none" style="height: 470px;
            width: 1000px;">
        </iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        >
    </ajaxToolkit:ModalPopupExtender>
    <%--End Rachana 06/05/13--%>

     <%--Shreela  for Actionable...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseAct" Width="518px" display="none">
        <iframe runat="server" id="IframeRaiseAct" frameborder="0" display="none" style="width: 518px;
            height: 250px"></iframe>
       
    </asp:Panel>
    <asp:Label runat="server" ID="lblAct" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseAct" BehaviorID="MdlPopRaiseAct"
        DropShadow="true" TargetControlID="lblAct" PopupControlID="PnlRaiseAct" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Shreela  for Actionable...end--%>


    <%--Shreela  for Submit...Start--%>
     <asp:Panel runat="server" ID="PnlRaiseSub" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseSub" frameborder="0" display="none" style="width:1000px;
            height: 470px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
        DropShadow="true" TargetControlID="lblSub" PopupControlID="PnlRaiseSub" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
     <%--Shreela  for Submit...Start--%>
     <%--Report Popup--%>
      <asp:Panel runat="server" ID="PnlReport" Width="700px" display="none">
        <iframe runat="server" id="IframeReport" frameborder="0" display="none" style="width:700px;
            height: 470px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblRprt" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopupReport" BehaviorID="MdlPopupReport"
        DropShadow="true" TargetControlID="lblRprt" PopupControlID="PnlReport" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="320px" Height="230px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px;">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server"></asp:Label><br />
                                <br />
                            </center>
                            <center>
                        <asp:Label ID="lbl2" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <center>
                        <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" /></center>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopupFees" runat="server" TargetControlID="Label3"
                BackgroundCssClass="modalPopupBg" PopupControlID="pnl" DropShadow="true" OkControlID="btnok"
                Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
<%--    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewRen" BehaviorID="mdlViewBIDRen"
        DropShadow="true" TargetControlID="lblDocRcvd" PopupControlID="pnlMdlDocRcvd" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>--%>


            <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>

 <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                    <%--background-color: #C0C0C0;--%>
                    <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
                </asp:Panel>

     <%--Ajay  Popup start--%>
     <asp:Panel runat="server" ID="Panel2" Width="1000px" display="none">
        <iframe runat="server" id="Iframe1" scrolling="yes" frameborder="0" style="width:1000px;
            height: 470px"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label5" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBID1"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Ajay  Popup end--%>

     <div class="modal" id="MyModalRpt" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="
    padding-top: 0px;
    width: 55%;">
    <div class="modal-content" style="width:712px!important">
      <div class="modal-header" style="padding-right:326px">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">Report</h4>
      </div>
      <div class="modal-body" >
          <iframe id="iframeRpt" src="" width="675" height="300" frameborder="0" allowtransparency="true"></iframe>  
      </div>
      <div class="modal-footer" style="text-align: center;padding-right: 298px">
          <button type="button" class="btn btn-clear" data-dismiss="modal" >
             <span class="glyphicon glyphicon-remove" style='color:Red;'> </span> Cancel

             </button>
         
        </div>
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
      </asp:Content>

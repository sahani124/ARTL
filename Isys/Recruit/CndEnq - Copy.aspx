<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CndEnq.aspx.cs"
    Inherits="Application_Recruit_PrsptSearch" Title="Prospect Search" %>
 
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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

    <script language="javascript" type="text/javascript">


        $(function () {
            // debugger;

            $('#<%=dgDetails.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000


                }
            });

        });
        


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


        <%--var path = "<%=Request.ApplicationPath.ToString()%>";--%>
        
        function poponload(window) {

            window.moveTo(0, 0);

        }
        <%--$(function () {
            debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate:'0'
            });
        });--%>
            $(function () {
                debugger;

                $("#<%= txtDTRegTo.ClientID  %>").datepicker({
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    maxDate:'0'
                }); //txtReqDate

        });


        function ShowReqDtl1(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
            //        objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
              //      objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }



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
        function funReport(CndNo, ReportType) {
            debugger;
            var modal = document.getElementById('MyModalRpt');
            var modaliframe = document.getElementById("iframeRpt");
            modaliframe.src = "../../../Application/ISys/Recruit/IndividualReport.aspx?Type=" + ReportType + "&CndNo=" + CndNo + "&mdlpopup=MdlPopupReport";
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
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "View_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=MdlPopRaiseSub";

        }

        //Added by Nikhil


        //rachana 06/05/13
        function funcShowPopup(strPopUpType, cnd, name) {
            //debugger;
            if (strPopUpType == "inter") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopIntDetails.aspx?CndNo=" + cnd + "&Name=" + name + "&mdlpopup=mdlViewBID";
            }
        }
        //End rachana 06/05/13

        //shreela 11/07/2014
        function funcopen(arg1) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "AdvTrnHrsReqSubmit.aspx?TrnRequest=Renewal&CndNo=" + arg1 + "&Type=Renwl&Code=Spon&mdlpopup=MdlPopRaiseSub";
        }
        //shreela 11/07/2014

        //shreela 14/07/2014
        function funcopenReExam(arg1, ReExm) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "AdvTrnHrsReqSubmit.aspx?TrnRequest=ReExam&CndNo=" + arg1 + "&ReExm=" + ReExm + "&Type=ReTrn&Code=Spon&mdlpopup=MdlPopRaiseSub";
        }

        function funcopenReExamV(arg1, ReExm) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "FrmSubmitTCC.aspx?Type=ReExam&CndNo=" + arg1 + "&ReExm=" + ReExm + "&Code=Spon&mdlpopup=MdlPopRaiseSub";
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
                document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseAct").src = "PopActionable.aspx?AppNo=" +
                appcode + "&mdlpopup=MdlPopRaiseAct";

            }
        }


         function ValidationPAN() {

            var varPAN = document.getElementById("ctl00_ContentPlaceHolder1_txtPan").value;

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                return false;
            }
            if (varPAN.length < 10) {
                alert('PAN No. must have minimum 10 characters.');
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                return false;
            }

            if (SpaceTrim(document.getElementById('<%= txtPan.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtPan.ClientID %>').value)) == 0) {
                    alert('Invalid Pan Format');
                    return false;
                }
            }

            document.getElementById('divPAN').style.display = 'block'
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
            }
            else {
                return 0;
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
    </script>
  <style>
   modalpopupmesg{
       background-color: white !important;
    padding: 15px 15px 15px 15px;
   } 
   
.gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    /*text-align: center;*/
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
.clsCenter{
    text-align:center !important;
}
.clsLeft{
    text-align:left !important;
}
      .panel_over
      {
            margin-left: 0%!important;
            margin-right: 0%!important;
      }
	  .pad{
		  text-align:center !important;
	  }
	  .pad1{
		  text-align:left !important;
	  }
  </style> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <center>
     
       <%-- <div class="panel panel-success PanelInsideTab" style="margin-top: 0px;">--%>
            <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
            <div class="card PanelInsideTab" id="Div1" >
                <div class="panelheadingAliginment" >
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                           
                            <asp:Label ID="lbltitle" runat="server" CssClass="control-label HeaderColor"></asp:Label>
                        </div>
                        <div class="col-sm-2">
 
                            <%--<span id="Spntitle" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;
                                padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>--%>
                            
                             <span id="Spntitle" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>
                        </div>
                    </div>
                </div>
                <div id="divSearch" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
 
                <div id="trApplication" visible="false" runat="server" class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblAppNo" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="15" TabIndex="1"  ></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                          InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                          FilterMode="InvalidChars" TargetControlID="txtAppNo" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                <div id="trCandidateNo" runat="server" class="row rowspacing">
                    
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblApplicationNo" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtApplicatoNo" runat="server" CssClass="form-control" MaxLength="10" TabIndex="3"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                           InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                           FilterMode="InvalidChars" TargetControlID="txtApplicatoNo" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblGivenName" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" MaxLength="60" TabIndex="4"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtGivenName">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblCandidateCode" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtCandCode" runat="server" CssClass="form-control" MaxLength="15" TabIndex="2"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                           InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                           FilterMode="InvalidChars" TargetControlID="txtCandCode" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <asp:Label ID="LblhomeNote" runat="server" Visible="false" Text="(Value should be of 12 digit.)"
                            Font-Size="Smaller" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div id="trregstrtndt" runat="server" class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblSurName" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="30" TabIndex="5"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtSurname">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label"> </asp:Label>
                        <asp:TextBox ID="txtDTRegFrom" runat="server" onmouseenter="funtxtDTRegFrom();" CssClass="form-control" TabIndex="6" placeholder="(dd/mm/yyyy)"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label"></asp:Label>
                        <asp:TextBox TabIndex="7" ID="txtDTRegTo" runat="server" CssClass="form-control" placeholder="(dd/mm/yyyy)"></asp:TextBox>
                    </div>
                </div>
                <div id="trCodedlicdetails" runat="Server" class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                        <%--<asp:Label ID="lblAgntBroker" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtAgntBroker" TabIndex="8" runat="server" CssClass="form-control"></asp:TextBox>--%>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblSapcode" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtSapCode" runat="server" TabIndex="10" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblURN" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtURN" runat="server" TabIndex="12" CssClass="form-control"></asp:TextBox>
                    </div>
                   
                </div>
               <%-- <div id="trPan" runat="Server" class="row rowspacing">
                    
                    
 
                </div>--%>
                <div id="trshowrecords" runat="server" class="row rowspacing">
                     <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblPan" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtPan" runat="server" TabIndex="11" CssClass="form-control" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblShwRecords1" runat="server" CssClass="control-label" />
                        <asp:DropDownList TabIndex="12" ID="ddlShwRecrds1" runat="server" CssClass="form-control form-select"
                                        OnSelectedIndexChanged="ddlShwRecrds1_SelectedIndexChanged">
                                    </asp:DropDownList>
                    </div>
                 
                     <div class="col-sm-4"  id ="DivStatus" visible="false"  runat="server" style="text-align: left">
                         <asp:Label ID="lblStatus" runat="server" CssClass="control-label" />
                          <asp:DropDownList TabIndex="13" ID="ddlStatus" runat="server" CssClass="form-control form-select" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                    </div>
               
                <%--added by ajay 28 july 2023 start--%>
                       <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblAgntBroker" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="txtAgntBroker" TabIndex="8" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    
                <%--added by ajay 28 july 2023 end--%>
                </div>

                <div runat="server" id="trstausshowrecords" visible="false" class="row rowspacing">
                   <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblShwRecords" runat="server" CssClass="control-label" />
                        <asp:DropDownList ID="ddlShwRecrds" TabIndex="14" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                                    </asp:DropDownList>
                    </div>
                     <%--<div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblStatus" runat="server" CssClass="control-label" />
                        <asp:DropDownList TabIndex="13" ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                    </div>--%>

<%--                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="Label6" runat="server" CssClass="control-label" />
                        <asp:TextBox ID="TextBox4" runat="server" TabIndex="11" CssClass="form-control"></asp:TextBox>
                    </div>--%>
                </div>

 
                    <br />
                    <div class="row">
                        <div class="col-sm-12" align="center">
                            <div class="col-sm-12" align="center">
 
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" AutoPostback="false"
                                    OnClick="btnSearch_Click" TabIndex="15">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> SEARCH
                                </asp:LinkButton> 
 
                                <asp:LinkButton ID="btnClear"   OnClick="btnClear_Click" CssClass="btn btn-clear"
                                   TabIndex="16" runat="server">
                             CLEAR </asp:LinkButton>
                                <asp:LinkButton ID="btnAddnew" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click"
                                    Visible="false" TabIndex="17">
                               <span class="glyphicon glyphicon-plus" style='color:White;'> </span> ADD NEW
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnReFresh" runat="server" CssClass="standardbutton" Style="display: none;"
                                    ClientIDMode="Static" OnClick="btnReFresh_Click" TabIndex="18"></asp:LinkButton>
                                <div id="divloader" runat="server" style="display: none;">
                                    <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                    Loading...
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    
                </div>
            </div>
        <div id="trnote" runat="server" class="row">
                      <%--  <asp:Label ID="Label2" runat="server" Text="Note: All dates are in (dd/mm/yyyy)"
                            ForeColor="black"></asp:Label>--%>
                    </div>
                    <div id="trLbl" runat="server" class="row" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
        <%--</div>--%>
       <div id="tr31"  class="card PanelInsideTab" visible="false" runat="server">
          
               <%-- <div id="trDetails" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdgdtls','btnDeptMstGrd');return false;">
                    <div class="row" style="margin-left:10px;margin-right:10px">
                        <div class="col-sm-10" style="text-align: left">
                             <asp:Label ID="lblprospectsearch" runat="server" Text="" CssClass="control-label HeaderColor">  </asp:Label>
                             <asp:Label ID="lblPageInfo" runat="server" ForeColor="#00cccc" Font-Bold="true" Width="160px" Visible="false"></asp:Label> 
                        </div>
                        <div class="col-sm-2">
                            <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;  padding: 1px 10px ! important; font-size: 18px;"></span>
                            
                        </div>
                    </div>
                </div>--%>
            <%-- </div> --%>
                <%--<div class="card" id="Div2" style="margin-left: 2%; margin-right: 2%; margin-top: 1.5%"> --%>
                    <div id="tr2" runat="server" class="panelheadingAliginment" >
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
 
                                <asp:Label ID="Label1" runat="server" Text="Candidate Modification Search Result"  CssClass="control-label HeaderColor">
                                </asp:Label>
                                <%-- <asp:Label ID="lblPageInfo1" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>--%>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdgdtls','Span1');return false;"></span>
                            </div>
                        </div>
                    </div>
                
             <%--  </div> --%>
                    <div id="trdgdtls"  runat="server" >
                        <div id="trDgDetails" runat="server" style="padding: 10px;overflow-x: scroll;">
                           <%-- <div style="overflow-x: scroll;width:97%">--%>
                            <asp:GridView ID="dgDetails" runat="server" Style="border-bottom-color: black;width:97%" AutoGenerateColumns="False"
                                CssClass="footable" PageSize="10" AllowSorting="True" AllowPaging="True" OnRowDataBound="dgDetails_RowDataBound"
                                OnRowCommand="dgDetails_RowCommand" OnPageIndexChanging="dgDetails_PageIndexChanging"
                                OnSorting="dgDetails_Sorting">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <%--column 0--%>
                                    <asp:TemplateField HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px"
                                       SortExpression="CandidateNo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="click" Font-Underline="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                     
                                    </asp:TemplateField>
                                    <%--column 1--%>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                        HeaderText="Application No">
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lbProsID" runat="server" Text='<%# Eval("ApplicationNo") %>'
                                                CommandArgument='<%# Eval("ApplicationNo") %>' CommandName="click" Font-Underline="false"></asp:LinkButton>
                                            <%-- <asp:Label ID="lbProsID" runat="server" Text='<%# Eval("ApplicationNo") %>'
                                                CommandArgument='<%# Eval("ApplicationNo") %>' CommandName="click"></asp:Label>--%>
                                        </ItemTemplate>
                                          <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 2--%>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 3--%>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' ></asp:Label>
                                        </ItemTemplate>
                                     <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 4--%>
                                    <asp:TemplateField SortExpression="CndStatus" HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("CndStatus") %>' ToolTip='<%# Eval("CndStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 5--%>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                  <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 6--%>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbizsrc" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 7--%>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtName" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                ></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 8--%>
                                    <asp:TemplateField SortExpression="MemCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtCode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 9--%>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporting Name" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="100px"
                                        ItemStyle-Width="15%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pad" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--column 10--%>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporting Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px"
                                        ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 11--%>
                                    <asp:TemplateField SortExpression="CndURN" HeaderText="URN No." HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblurn" runat="server" Text='<%# Eval("CndURN") %>' ToolTip='<%# Eval("CndURN") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 12--%>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-CssClass="pad" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pad" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 13--%>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderStyle-CssClass="pad" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pad" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 14--%>
                                    <asp:TemplateField SortExpression="LcnExpDate" HeaderText="LcnExpDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllcnexpdate" runat="server" Text='<%# Eval("LcnExpDate") %>' ToolTip='<%# Eval("LcnExpDate") %>'></asp:Label>
                                        </ItemTemplate>
                                       <%-- <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <%--column 15--%>
                                    <asp:TemplateField HeaderStyle-CssClass="pad1" SortExpression="Actionable" HeaderText="Actionable" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblaction" runat="server" Text='<%# Eval("Actionable") %>' ToolTip='<%# Eval("Actionable") %>'></asp:Label>
                                        </ItemTemplate>
                                       <%-- <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <%--column 16--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <div style="width: 100%;">
                                                <i class="fa fa-male"></i>
                                                <asp:LinkButton ID="lnkagent" runat="server" Text="Create Agent" CommandArgument='<%# Eval("CandidateNo") %>'
                                                    CommandName="CreateAgent"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                       <%-- <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <%--column 17--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkcnd" runat="server" Text="Revive" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="Revive"></asp:LinkButton>
                                        </ItemTemplate>
                                        <%--<ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <%--column 18--%>
                                    <asp:TemplateField HeaderStyle-CssClass="pad" HeaderStyle-HorizontalAlign="Center" HeaderText="License Issue Date"
                                        SortExpression="LcnIssDate" ItemStyle-Width="5%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnIssDate" runat="server" Text='<%# Eval("LcnIssDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pad" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 19--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <%--<span class="glyphicon glyphicon-duplicate"></span>--%>
                                            <asp:LinkButton ID="lnkCndNo_view" runat="server" Text="View Details" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="ViewStatus"></asp:LinkButton>
                                        </ItemTemplate>
                                      <%--  <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <%--column 20--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <i class="fa fa-credit-card"></i>
                                            <asp:LinkButton ID="lnklicn" runat="server" Text="Select" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="License Renewal"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 21--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSMAlloct" runat="server" Text="Allocate SM" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="SMAllocation"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 22--%>
                                    <asp:TemplateField SortExpression="SystemDate" HeaderText="Preferred Date" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="100px"
                                        ItemStyle-Width="4%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreffDates" runat="server" Text='<%# Eval("SystemDate","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("SystemDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 23--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPrefDt" runat="server" Text="Preferred Date" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="Preffered Date"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 24--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <%--23--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLicenseStatus" runat="server" Text='<%# Eval("LicenseStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <%--23--%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LblAgentProfile" runat="server" Text="Candidate Profile" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="Agent Profile"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                              <%--  </div>--%>
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
                        </div>
                        <div id="trGridCndStatus" runat="server" visible="false" style="padding: 10px;overflow-x: scroll;">
                            <asp:GridView ID="GridCndStatus" Width="140%" runat="server" AutoGenerateColumns="False" CssClass="footable" Style="border-bottom-color: black;"
                                Visible="false" PageSize="10" AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GridCndStatus_PageIndexChanging"
                                OnSorting="GridCndStatus_Sorting" OnRowCommand="GridCndStatus_RowCommand" OnRowDataBound="GridCndStatus_RowDataBound">
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <Columns>
                                    <%--column 0--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:LinkButton ID="lbCndNo1" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 1--%>
                                    <asp:TemplateField SortExpression="ApplicationNo"
                                        HeaderText="Application No" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="LnkBtn" ID="lbProsID1" runat="server" Text='<%# Eval("ApplicationNo") %>'
                                                CommandArgument='<%# Eval("ApplicationNo") %>' CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 2--%>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname1" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 3--%>
                                    <asp:TemplateField SortExpression="CndStatus" HeaderText="Status"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCndStatus1" runat="server" Text='<%# Eval("CndStatus") %>' ToolTip='<%# Eval("CndStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 4--%>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim1" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 5--%>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbizsrc1" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 6--%>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtName1" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <%--column 7--%>
                                    <asp:TemplateField SortExpression="MemCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemCode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>'></asp:Label>
                                        </ItemTemplate>
                                          <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 8--%>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporting Name" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptName1" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 9--%>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporting Code" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptCode1" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 10--%>
                                    <asp:TemplateField SortExpression="CndURN" HeaderText="URN No." HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblurn1" runat="server" Text='<%# Eval("CndURN") %>' ToolTip='<%# Eval("CndURN") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 11--%>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" Visible="false"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtCodeSapCode" runat="server" Text='<%# Eval("Agent_SAPCODE") %>'
                                                ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 12--%>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode1" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 13--%>
                                    <asp:TemplateField HeaderStyle-CssClass="pad1" SortExpression="Actionable" HeaderText="Actionable" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblaction1" runat="server" Text='<%# Eval("Actionable") %>' ToolTip='<%# Eval("Actionable") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pad1" />
                                        <%--<HeaderStyle CssClass="clsLeft" />--%>
                                    </asp:TemplateField>
                                    <%--column 14--%>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="License No."
                                        SortExpression="LcnNo" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>' ToolTip='<%# Eval("LcnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 15--%>
                                    <asp:TemplateField HeaderStyle-CssClass="pad" HeaderStyle-HorizontalAlign="Center" HeaderText="License Issue Date"
                                        SortExpression="LcnIssDate" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnIssDate1" runat="server" Text='<%# Eval("LcnIssDate") %>' ToolTip='<%# Eval("LcnIssDate") %>'></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="pad" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 16--%>
                                    <asp:TemplateField SortExpression="LcnExpDate" HeaderText="LcnExpDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllcnexpdate1" runat="server" Text='<%# Eval("LcnExpDate") %>' ToolTip='<%# Eval("LcnExpDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <%--column 17--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                           <%-- <span class="glyphicon glyphicon-blackboard"></span>--%>
                                            <asp:LinkButton ID="lnkCndNo_view1" runat="server" Text="View Details" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="ViewStatus"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--added by ajay 16.03.2023--%>
                                         <asp:TemplateField SortExpression="Statusvalue" HeaderText="Status" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatusvalue" runat="server" Text='<%# Eval("statusvalue") %>' ToolTip='<%# Eval("statusvalue") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
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
                        <div id="trdgRenTnr" runat="server" visible="false" class="panel-body" >
                            <div style="overflow-x: scroll;width:97%">
                                 <asp:GridView ID="dgRenTrn" runat="server" Visible="false" Style="border-bottom-color: black;" AutoGenerateColumns="False"
                                CssClass="footable" PageSize="10" AllowSorting="True" AllowPaging="True" OnRowDataBound="dgRenTrn_RowDataBound"
                                OnRowCommand="dgRenTrn_RowCommand" OnPageIndexChanging="dgRenTrn_PageIndexChanging"
                                OnSorting="dgRenTrn_Sorting">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />


                                <Columns>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CndNo") %>' ToolTip='<%# Eval("CndNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ProspectId") %>' ToolTip='<%# Eval("ProspectId") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("GivenName") %>' ToolTip='<%# Eval("GivenName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("cndStatus") %>' ToolTip='<%# Eval("cndStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                    <div style="width: 100%;">
                                                                    <i class="fa fa-calendar"></i>
                                                        <asp:Label ID="lblDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                                </asp:TemplateField>--%>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSapCode" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="DwnldCnt" HeaderText="Download Count" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDwnldCnt" runat="server" Text='<%# Eval("DwnldCnt") %>' ToolTip='<%# Eval("DwnldCnt") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRenTrnU" runat="server" Text="TCC Upload" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="RenewalU"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRenTrnD" runat="server" Text="TCC Download" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="RenewalD"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDwnld" runat="server" Text="Download" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="Dwnld"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAction" runat="server" Text="Actionable" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="Action"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--added by pranjali on 18-10-2014 for license upload download start--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Agent Lic & ID Upload" ItemStyle-Width="8%" Visible="false">
                                        <%--18--%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLicUpld" runat="server" Text="Upload" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="LicUpld"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%" Visible="false">
                                        <%--19--%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLicDwnld" runat="server" Text="License Download" CommandArgument='<%# Eval("CndNo") %>'
                                                CommandName="LicDwnld"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--added by pranjali on 18-10-2014 for license upload download end--%>
                                </Columns>
                            </asp:GridView>
                            </div>
                            <div>
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnPreRenTnr" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtRenTnr" Text="1" Style="width: 35px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnNextRenTnr" Text=">" CssClass="form-submit-button" runat="server"
                                                    Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                    OnClick="btnnext_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </div>
                        <div id="trdgreExam" runat="server" style="padding: 10px;overflow-x: scroll;" visible="false">
                            <%--<div style="overflow-x: scroll;width:97%">--%>
                            <asp:GridView ID="dgReExam" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="dgReExam_PageIndexChanging"
                                OnSorting="dgReExam_Sorting" OnRowCommand="dgReExam_RowCommand" OnRowDataBound="dgReExam_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <HeaderStyle CssClass="gridview th" />
                                <PagerStyle CssClass="disablepage" />
                                <Columns>
                                    <asp:TemplateField SortExpression="Candidate No" HeaderText="Candidate No" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CndNo") %>' ToolTip='<%# Eval("CndNo") %>'
                                                Style="padding-left: 35px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Application No" HeaderText="Application No" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApp" runat="server" Text='<%# Eval("AppNo") %>' ToolTip='<%# Eval("AppNo") %>'
                                                Style="padding-left: 35px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="GivenName" HeaderText="Given Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGname" runat="server" Text='<%# Eval("GivenName") %>' ToolTip='<%# Eval("GivenName") %>'
                                                Style="padding-left: 35px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ExmResult" HeaderText="Exam Result" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExm" runat="server" Text='<%# Eval("ExmResult") %>' ToolTip='<%# Eval("ExmResult") %>'
                                                Style="padding-left: 35px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="TCCDate" HeaderText="TCC Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTccD" runat="server" Text='<%# Eval("TCCDate") %>' ToolTip='<%# Eval("TCCDate") %>'
                                                Style="padding-left: 45px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="TCC" HeaderText="TCC" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTcc" runat="server" Text='<%# Eval("TCC") %>' ToolTip='<%# Eval("TCC") %>'
                                                Style="padding-left: 45px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField SortExpression="TCCFlag" HeaderText="TCC Flag" HeaderStyle-HorizontalAlign="Center"
                                             ItemStyle-Width="35%">
                                             <ItemTemplate>
                                             <asp:Label ID="lblTccF" runat="server" Text='<%# Eval("TCCFlag") %>' ToolTip='<%# Eval("TCCFlag") %>'
                                                  Style="padding-left: 5px;"></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                        </asp:TemplateField>--%>
                                    <asp:TemplateField SortExpression="AppNO" HeaderStyle-HorizontalAlign="Center" HeaderText=""
                                        ItemStyle-Width="8%">
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
                            </asp:GridView>
                                <%--</div>--%>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPrereExam" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtreExam" Text="1" Style="width: 40px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"  ReadOnly="true" />
                                            <asp:Button ID="btnNextreExam" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                        </div>
                        <div id="trRprt" runat="server"  visible="false" class="card PanelInsideTab" style="padding: 10px;overflow-x: scroll;">
                           <%-- <div style="overflow-x: scroll;width:97%">--%>
                            <asp:GridView ID="GvRprt" runat="server" Visible="false" AutoGenerateColumns="False"
                                CssClass="footable" PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GvRprt_PageIndexChanging"
                                OnRowCommand="GvRprt_RowCommand" OnRowDataBound="GvRprt_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>'
                                                ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkIndvRprt" runat="server" Text="Appointment Letter" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="Report"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                <%--</div>--%>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreRprt" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtRprt" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="btnNextRprt" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                        </div>
                     
                        <div id="tr3" runat="server" visible="false" class="card PanelInsideTab" style="padding: 10px;overflow-x: scroll;">
                             <div style="overflow-x: scroll;width:97%">
                            <asp:GridView ID="GrdDocumentRet" runat="server" Visible="false" AutoGenerateColumns="False"
                                CssClass="footable" PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdDocumentRet_PageIndexChanging"
                                OnSorting="GrdDocumentRet_Sorting" OnRowDataBound="GrdDocumentRet_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkrcvd" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCndRet" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAppRet" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="NamePronoun" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvnnameRet" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurnmeRet" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTimRet" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchannelRet" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntnameRet" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RecruitEmpCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecruiterCodeRet" runat="server" Text='<%# Eval("RecruitEmpCode") %>'
                                                ToolTip='<%# Eval("RecruitEmpCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptNameRet" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptCodeRet" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="PAN" HeaderText="PAN" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPANRet" runat="server" Text='<%# Eval("PAN") %>' ToolTip='<%# Eval("PAN") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="LcnNo" HeaderText="LcnNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>' ToolTip='<%# Eval("LcnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="" HeaderText="Document Received Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdocrecdate" runat="server" Width="100px" CssClass="standardtextbox"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                            <asp:TextBox CssClass="form-control" ID="TextBox2" Style="display: none" runat="server"
                                                Width="80px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                ValidChars="1234567890/" FilterMode="ValidChars" TargetControlID="txtdocrecdate"
                                                FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdocrecdate"
                                                PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="" HeaderText="Remark" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarkRet" runat="server" Width="140px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                 </div>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreDocumentRet" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtDocumentRet" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="btnNextDocumentRet" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </div>
                        </div>
                        <div id="trLICId" runat="server" visible="false" class="panel-body">
                             <div style="overflow-x: scroll;width:97%">
                            <asp:GridView ID="GrdLicId" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdLicId_PageIndexChanging"
                                OnSorting="GrdLicId_Sorting" OnRowCommand="GrdLicId_RowCommand" OnRowDataBound="GrdLicId_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <%--added by ajay 28 july 2023 start--%>
                                    <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%" HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkAssigned" runat="server" />
                                    </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" CssClass="pad"  ></ItemStyle>
                                </asp:TemplateField>
                                <%--added by ajay 28 july 2023 end--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                         ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>'
                                                ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <span class="glyphicon glyphicon-print"></span>
                                            <asp:LinkButton ID="lnkIndvLic" runat="server" Text="License Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="License"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <span class="glyphicon glyphicon-print"></span>
                                            <asp:LinkButton ID="lnkIndvID" runat="server" Text="ID Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="ID"></asp:LinkButton>
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
                            <%--added by ajay 28 july 2023--%>
                            <br />
                            <div id="divdwnld" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-sm-12" style="text-align:center;">
                                          <asp:LinkButton ID="BtnDwnldAll" OnClick="BtnDwnldAll_Click" TabIndex="43" CssClass="btn btn-success"
                                    runat="server">
                                 <span class="glyphicon glyphicon-download" style="color:White"> </span> Download All
                                </asp:LinkButton>
                                    </div>
                                     
                                </div>
                            </div>
                            <%--added by ajay 28 july 2023--%>
                        </div>
                       <%-- Added by usha on 11.10.2022--%>
                           <div id="trLICPosp" visible="false" runat="server" class="panel-body">
                             <div style="overflow-x: scroll;width:97%">
                                 <asp:GridView ID="GrdLicPosp" runat="server"  CssClass="footable"
                                             AllowSorting="True" HorizontalAlign="Left"  
                                             AutoGenerateColumns="False" AllowPaging="True"  onrowcommand="GrdLicPosp_RowCommand"
                                            onpageindexchanging="GrdLicPosp_PageIndexChanging" onsorting="GrdLicPosp_Sorting"> 
                                     <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
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
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>' ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvLic" runat="server" Text="License Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="PospAppointment"></asp:LinkButton>
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
                                            <asp:Button ID="BtnLicPospprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="TxtLicPosp" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="BtnLicPospNext" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                               </div>
                               </div>
                      <%--  ended by usha 11.10.2022--%>
                        <div id="trNOCIC" visible="false" runat="server" class="panel-body">
                             <%--<div style="overflow-x: scroll;width:97%">--%>
                            <asp:GridView ID="GridNOCIC" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridNOCIC_PageIndexChanging"
                                OnSorting="GridNOCIC_Sorting" OnRowCommand="GridNOCIC_RowCommand">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" >
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>
                                            <asp:Label ID="lblCnd" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>' >

                                            </asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo"  
                                        HeaderText="Application No"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblApp" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'
                                                ></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsLeft" />
                                          <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname"   Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsLeft" />
                                          <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                          <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsLeft" />
                                          <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporter Name" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsLeft" />
                                          <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporter Code" Visible="false"
                                        >
                                        <ItemTemplate>
                                            <asp:Label ID="lblReptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>'
                                                ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Agent_Broker_Code" HeaderText="Broker Code"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtBrokerCode" runat="server" Text='<%# Eval("Agent_Broker_Code") %>'
                                                ToolTip='<%# Eval("Agent_Broker_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CandidateNo"  
                                        HeaderText="Action"  >
                                        <ItemTemplate>
                                            <span class="glyphicon glyphicon-print"></span>
                                            <asp:LinkButton ID="lnkNOCIC" runat="server" Text="NOC IC Copy" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="NOC"></asp:LinkButton>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                          <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                <%-- </div>--%>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreNOCIC" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtNOCIC" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="btnNextNOCIC" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                        </div>
                        <div id="trRetrieval" runat="server" visible="false" class="panel-body">
                             <div style="overflow-x: scroll;width:97%">
                            <asp:GridView ID="dgRetrieval" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="dgRetrieval_PageIndexChanging"
                                OnSorting="dgRetrieval_Sorting" OnRowCommand="dgRetrieval_RowCommand" OnRowDataBound="dgRetrieval_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <%--column 0--%>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <span class="glyphicon glyphicon-pencil"></span>
                                            <asp:LinkButton ID="lnklicn" runat="server" Text="Retrieval" CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="License Renewal"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 1--%>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="LnkBtn" ID="lbProsID" runat="server" Text='<%# Eval("ApplicationNo") %>'
                                                CommandArgument='<%# Eval("ApplicationNo") %>' CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 2--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Candidate No" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCandidateNo" runat="server" Text='<%# Eval("CandidateNo") %>' ToolTip='<%# Eval("CandidateNo") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--column 3--%>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 4--%>
                                    <asp:TemplateField SortExpression="AgnCode" HeaderText="Agent Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgnCode" runat="server" Text='<%# Eval("AgnCode") %>' ToolTip='<%# Eval("AgnCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 5--%>
                                    <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtCode1" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 3--%>
                                    <%--<asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("CndStatus") %>' ToolTip='<%# Eval("CndStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
            </asp:TemplateField>--%>
                                    <%--column 6--%>
                                    <asp:TemplateField SortExpression="PAN No" HeaderText="PAN No" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPANNo" runat="server" Text='<%# Eval("PAN No") %>' ToolTip='<%# Eval("PAN No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 7--%>
                                    <asp:TemplateField SortExpression="LcnNo" HeaderText="License No." HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLcnNo" runat="server" Text='<%# Eval("LcnNo") %>' ToolTip='<%# Eval("LcnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 8--%>
                                    <asp:TemplateField SortExpression="EmpCode" HeaderText="Recruiter Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 9--%>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtName" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 10--%>
                                    <asp:TemplateField SortExpression="RptCode" HeaderText="Reporting Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptCode" runat="server" Text='<%# Eval("RptCode") %>' ToolTip='<%# Eval("RptCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 11--%>
                                    <asp:TemplateField SortExpression="RptName" HeaderText="Reporting Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRptName" runat="server" Text='<%# Eval("RptName") %>' ToolTip='<%# Eval("RptName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 12--%>
                                    <asp:TemplateField SortExpression="BranchName" HeaderText="Branch Name" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>' ToolTip='<%# Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 13--%>
                                    <asp:TemplateField SortExpression="BranchCode" HeaderText="Branch Code" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchCode" runat="server" Text='<%# Eval("BranchCode") %>' ToolTip='<%# Eval("BranchCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 14--%>
                                    <asp:TemplateField SortExpression="LcnExpDate" HeaderText="LcnExpDate" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllcnexpdate" runat="server" Text='<%# Eval("LcnExpDate") %>' ToolTip='<%# Eval("LcnExpDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </div>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreRetrieval" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtRetrieval" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnNextRetrieval" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                        </div>
                        <div id="trDgFees"    class="card" runat="server" visible="false" style="padding: 10px;overflow-x: scroll;">
                          <%--  <div style="overflow-x: scroll;width:97%">--%>
                            <asp:GridView ID="dgFees" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="dgFees_PageIndexChanging"
                                OnSorting="dgFees_Sorting" OnRowCommand="dgFees_RowCommand" OnRowDataBound="dgFees_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate ID" HeaderStyle-Wrap="false"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderText="Application No" ItemStyle-Width="12%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappno" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Givenname" HeaderText="Name" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamePronoun" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" ItemStyle-Width="10%"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("RecruitAgtName") %>'
                                                ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="CreateDtim" HeaderText="Registration Date" ItemStyle-Width="13%"
                                        HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDtim" runat="server" Text='<%# Eval("CreateDtim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="DateSubmission" HeaderText="Date of Submission"
                                        ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateSubmission" runat="server" Text='<%# Eval("submiteddate") %>'
                                                ToolTip='<%# Eval("submiteddate") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="BranchName" HeaderText="Branch Name" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("Branch") %>' ToolTip='<%# Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ExmResult" HeaderText="Last exam result" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExmResult" runat="server" Text='<%# Eval("result") %>' ToolTip='<%# Eval("result") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approve" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblapprove" runat="server" Text='<%# Eval("cndStatus") %>' Visible="false" />
                                            <asp:RadioButton ID="rbrapprove" GroupName="Approval" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="rbrapprove_CheckedChanged" />
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reject" Visible="True" ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbrreject" GroupName="Approval" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="rbrreject_CheckedChanged" />
                                        </ItemTemplate>
                                       <HeaderStyle CssClass="clsCenter" />
                                        <ItemStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="standardtextbox" MaxLength="35"
                                                Width="200px" />
                                            <%--Added by Kalyani on 25-11-13 Hidden fields as Bank Templatefield is invisible start--%>
                                            <input type="hidden" runat="server" id="hdntxtVarify" value="NotDone" />
                                            <input type="hidden" runat="server" id="hdnPmtMode" value='<%# Eval("PmtMode") %>' />
                                            <%--Added by Kalyani on 25-11-13  Hidden fields as Bank Templatefield is invisible end--%>
                                        </ItemTemplate>
                                         
                                         <HeaderStyle CssClass="clsLeft" />
                                        <ItemStyle CssClass="clsLeft" />
                                        <ItemStyle Width="23%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank" HeaderStyle-ForeColor="teal" ItemStyle-Width="6%"
                                        Visible="false">
                                        <ItemTemplate>
                                            <input type="button" id="btnVarify" value="Verify" class="standardbutton" width="50px"
                                                runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="Teal" />
                                        <ItemStyle Width="6%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         <%--   </div>--%>
                            <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreFees" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtFees" Text="1" Style="width: 37px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"  ReadOnly="true" />
                                            <asp:Button ID="btnNextFees" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnnext_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                </div>
                        </div>
                        <div id="tr5" runat="server" style="display: none">
                            <asp:CheckBox ID="chkrcvd" runat="server" />
                            <asp:Label ID="lblconfirm" runat="server" Style="color: black" Text="Confirm"></asp:Label>
                        </div>
                        <div id="tr6" runat="server" class="row" style ="padding-top:1px">
                            <div class="col-sm-12" align="center">
                                <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btnSubmit" OnClick="btnFeesSubmit_Click" runat="server" CssClass="btn btn-success"
                                        TabIndex="11">
                                 <span class="glyphicon glyphicon-saved BtnGlyphicon"> </span> SUBMIT
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnCancel"   runat="server" Text="CANCEL" CssClass="btn btn-clear"
                                        OnClick="btnCancel_Click">
                             <span style="color:#f04e5e" class="glyphicon glyphicon-remove"> </span> CANCEL </asp:LinkButton>
                                    <div id="tr4" runat="server" style="display: none">
                                        <div id="divloadergrid" runat="server" style="display: none;">
                                            <img id="Img3" alt="" src="~/images/spinner.gif" runat="server" />
                                            Loading...
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tblSave" runat="server" class="row">
                            <div id="trSave" runat="server" class="col-sm-12" align="center">
                                <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" Visible="false" runat="server" CssClass="btn btn-sample"
                                        TabIndex="11">
                                 <span class="glyphicon glyphicon-film"> </span> Save
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                   <%-- </div>
                </div>--%>
            </div> 
        </div> 
       
        <%--       
            </ContentTemplate>
        </asp:UpdatePanel>--%>
    </center>
    <table class="formtable" style="border-collapse: separate; left: 0in; position: relative;
        top: 8px; width: 1000px; z-index: 4">
        <tr id="trButton" runat="server">
            <td align="center">
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlMdl" Width="770px" display="none">
        <iframe runat="server" id="ifrmMdlPopup" frameborder="0" display="none" style="height: 250px;
            width: 770px;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
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
    <%-- <div  class="panel panel-default">
  <div class="panel-body">

     <div id="myModal" class="modal fade" style="padding-top:1%" >  
                        <div class="modal-dialog" style="width:80%;height:120%;padding-bottom:2%">  
                            <div class="modal-content">  
                                <div >  
                                    <asp:LinkButton ID="inkEx" runat="server" class="close" data-dismiss="modal" >�</asp:LinkButton>  
                                   
                                </div>  
                                <div id="mdlpoup1" runat="server" class="modal-body" style="overflow-y: scroll; max-height: 85%; margin-top: 50px; margin-bottom: 50px;">  
                                                    </div>
                          </div>  
                        </div>  
                </div>
              
</div>
</div>--%>
    <%--Report Popup--%>
    <div class="panel" runat="server" id="PnlRaiseSub" display="none">
        <asp:Panel runat="server">
            <iframe runat="server" id="IframeRaiseSub" frameborder="0" display="none" style="width: 1000px;
                height: 470px"></iframe>
        </asp:Panel>
    </div>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
        TargetControlID="lblSub" PopupControlID="PnlRaiseSub">
    </ajaxToolkit:ModalPopupExtender>
    <%--Report Popup--%>
    <%--Physical retrival--%>
    <%--<asp:Panel ID="pnlMdlDocRcvd" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="180px">
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
                        <asp:Label ID="lblDocRcvd" runat="server"></asp:Label><br />
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
    </asp:Panel>--%>

     <%--   added by sanoj --%>

<div class="modal" id="msgModalPopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="padding-top: 0px; width: 70%;">
    <div class="modal-content" style=" width: 333px;margin-left: 93px;">
      
      <h3 style="margin-top: 23px;color:#00cccc;font-size:18px;text-align: center;margin-bottom: 15px;">INFORMATION</h3>
          
     
      <%--<div class="modal-body" >--%>
    
          
          <table>
                    <tr>
                        <td style="width: 391px;">
                           
                            <center>
                                <asp:Label ID="lbl3" runat="server" font-size="14px"></asp:Label><br />
                               
                            </center>
                            <center>
                                <asp:Label ID="lbl2" runat="server" font-size="14px"></asp:Label><br />
                                
                            </center>
                            <center>
                                <asp:Label ID="lbl4" runat="server" font-size="14px"></asp:Label><br />
                                
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>
     
        <div class="modal-footer" style="text-align:center">
          <button type="button" class="btn btn-success" data-dismiss="modal" onclick="return Cancel(msgModalPopup);" style="margin-right: 110px;border-radius: 6px;">
             <span class="glyphicon glyphicon-ok" style='color: White;'> </span> OK</button>
         
       
      </div>
        
         <%-- <iframe id="iframeCFR123" src="" width="675" height="300" frameborder="0" allowtransparency="true"></iframe>  --%>
      <%--</div>--%>
     
    </div>

  </div>

</div>
              <%--    endded by sanoj 02052023--%>



    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" style="background-color: white;height: 230px;width: 320px;position: absolute;z-index: 2;margin-left: -100px;">
                <table width="100%">
                    <tr align="center">
                        <td width="100%"  colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <%--<table>
                    <tr>
                        <td style="width: 391px;">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server" font-size="14px"></asp:Label><br />
                               
                            </center>
                            <center>
                                <asp:Label ID="lbl2" runat="server" font-size="14px"></asp:Label><br />
                                
                            </center>
                            <center>
                                <asp:Label ID="lbl4" runat="server" font-size="14px"></asp:Label><br />
                                
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>--%>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" class="btn btn-success"/></center>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopupFees" runat="server" TargetControlID="Label3"
                BackgroundCssClass="modalPopupBg" PopupControlID="pnl" DropShadow="false" OkControlID="btnok"
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
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <%--background-color: #C0C0C0;--%>
        <center>
            <img src="../../../../App_Themes/Isys/images/spinner.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>
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
             <span class="glyphicon glyphicon-remove" style='color:Red;'> </span> CANCEL

             </button>
         
        </div>
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
    <script>
        function funtxtDTRegFrom(){
             $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                 maxDate:'0'
            });
        }


        function popup() {
            debugger;
            var modal = document.getElementById('msgModalPopup');
            modal.style.display = "block";

        }
        function Cancel(modalimg) {
            debugger;
            var modal = modalimg;
            modal.style.display = "none";


        }
    </script>
</asp:content>

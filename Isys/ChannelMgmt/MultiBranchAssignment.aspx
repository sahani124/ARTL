<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MultiBranchAssignment.aspx.cs" Inherits="MultiBranchAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js"
        type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
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
    <script language="javascript" type="text/javascript">

        function popup() {
            $("#myModal").modal();
        }

        //        function showmodal() {
        //           
        //            $('#myModal').modal({
        //                backdrop: 'static',
        //                keyboard: false
        //            });
        //            var arg1 = "30026856";
        //            $("#myModal").load("View_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=MdlPopRaiseSub");
        //   
        //           
        //            
        //        }


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




        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function ShowReqDtl(divName, btnName) {
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
                    objnewbtn.className = '  glyphicon glyphicon-resize-full'
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
            $find("MdlPopupReport").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReport").src = "IndividualReport.aspx?Type=" + ReportType + "&CndNo="
            + CndNo + "&mdlpopup=MdlPopupReport";
        }

        function funcopenDoc(arg1) {
            debugger;

            $find("MdlPopRaiseSub").show();

            //MdlPopRaiseSub
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "View_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=MdlPopRaiseSub";

        }

        //Added by Nikhil
        function funReport(CndNo, ReportType) {
            debugger;
            $find("MdlPopupReport").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReport").src = "IndividualReport.aspx?Type=" + ReportType + "&CndNo="
            + CndNo + "&mdlpopup=MdlPopupReport";
        }

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
    </script>
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }
        .disablepage
        {
            display: none;
        }
        ul#menu
        {
            padding: 0;
            margin-right: 69%;
        }
        
        ul#menu li
        {
            display: inline;
        }
        
        
        
        ul#menu li a
        {
            background-color: Silver;
            color: black;
            cursor: pointer;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 4px 4px 0 0;
        }
        ul#menu li a:active
        {
            background: white;
        }
        
        ul#menu li a:hover
        {
            background-color: red;
        }
    </style>
    <script type="text/javascript" language="javascript">
        ////debugger;
        function funpopup(a) {
            ////debugger;
            if (a == 'Agent') {
                var myExtender = $find('mdlViewBID');
                myExtender.show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/AgentVendorSearch.aspx?strAgnCd="
            + document.getElementById('<%=txtAgtCode.ClientID %>').value
            + "&StrAgnName=" + document.getElementById('<%=lblNameData.ClientID%>').id
            + "&strAgnChn=" + document.getElementById('<%=lblAgnChnData.ClientID %>').id
            + "&strAgnChnCls=" + document.getElementById('<%=lblAgnSubClsData.ClientID %>').id
            + "&strHidden=" + document.getElementById('<%=hdnAgtCode.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnAgentName.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnAgnBizSrc.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnAgnChnCls.ClientID %>').value
            + "&mdlpopup=mdlViewBID"
            + "&agntype=" + a + "";
                //return false;
            }
            if (a == 'Vendor') {
                var myExtender = $find('mdlViewBID');
                myExtender.show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/AgentVendorSearch.aspx?strVendCd=" + document.getElementById('<%=txtVendoreCode.ClientID %>').value
            + "&strVendName=" + document.getElementById('<%=lblVenNameData.ClientID %>').id
            + "&strVendChn=" + document.getElementById('<%=lblVenChnData.ClientID %>').id
            + "&strVendChnCls=" + document.getElementById('<%=lblSubclassData.ClientID %>').id
            + "&strHidden=" + document.getElementById('<%=hdnVendCode.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendName.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendBizSrc.ClientID %>').value
            + "&strHidden=" + document.getElementById('<%=hdnVendChnCls.ClientID %>').value
            + "&mdlpopup=mdlViewBID"
            + "&agntype=" + a + "";
                //return false;
            }
        }
        function funValidate() {
            if ((document.getElementById("ctl00_ContentPlaceHolder1_txtLocation").value).length == 0) {
                alert("Location Is mandatory");
                document.getElementById('ctl00_ContentPlaceHolder1_txtLocation').focus();
                return false;
            }

            if ((document.getElementById("ctl00_ContentPlaceHolder1_ddlLocation").selectedIndex == 0)) {
                alert("Please Select location");
                document.getElementById('ctl00_ContentPlaceHolder1_ddlLocation').focus();
                return false;
            }

        }

        //        function ShowReqDtl(divId, btnId, img) {
        //            var strContent = "ctl00_ContentPlaceHolder1_";
        //            $(document.getElementById(strContent + divId)).slideToggle();
        //            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
        //                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
        //            }
        //            else {
        //                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
        //            }
        //        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div>
        <div class="col-sm-12" style="text-align: center">
            <asp:Label ID="lblMsg" ForeColor="Red" Visible="false" runat="server"></asp:Label>
        </div>
    </div>
    <div class="panel panel-success" id="divIrcCodeCreationHdr" runat="server">
        <div id="Div7" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrch1','demo');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                    <asp:Label ID="lblTitle" runat="server" CssClass="control-label" Font-Bold="false"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                </div>
                <div class="col-sm-2">
                    <span id="demo" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                        padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="divsrch1" runat="server" class="panel-body">
            <div class="panel panel-success" id="divhead" runat="server">
                <div id="divIrcCodeCreation" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important"
                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','Span1');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblAgentTitle" runat="server" Font-Bold="false"></asp:Label>
                        </div>
                        <%--shreela--%>
                        <div class="col-sm-2">
                            <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="divpersnldtls" runat="server" class="panel-body">
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label runat="server" ID="lblAgnCode" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="display: flex;">
                            <asp:TextBox ID="txtAgtCode" TabIndex="1" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:LinkButton ID="btnPopup" runat="server" CssClass="btn btn-primary" Text="...."
                                Style="margin-left: 2px"></asp:LinkButton>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label runat="server" ID="lblAgnName" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label runat="server" ID="lblNameData" CssClass="control-label"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label runat="server" ID="lblAgnChn" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label runat="server" ID="lblAgnChnData" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label runat="server" ID="lblSubCls" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label runat="server" ID="lblAgnSubClsData" CssClass="control-label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-success" id="div1" runat="server">
                <div id="formtablehdr" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important"
                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div8','Span2');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblVendorDtls" runat="server" Font-Bold="false"></asp:Label>
                            <%--shreela--%>&nbsp;
                        </div>
                        <div class="col-sm-2">
                            <span id="Span2" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="div8" runat="server" class="panel-body">
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblVendorcode" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <div style='display: flex;'>
                                <asp:TextBox ID="txtVendoreCode" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                <asp:LinkButton ID="btnVendorSrch" runat="server" CssClass="btn btn-primary" Style="margin-left: 2px"
                                    Text="...."></asp:LinkButton>
                                <%--<asp:LinkButton ID="btnVendorSrch" runat="server" CssClass="btn btn-primary">
                                      <span> </span>....  
                                     </asp:LinkButton>--%>
                            </div>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblVendorName" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lblVenNameData" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblVenChn" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lblVenChnData" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblSubclass" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lblSubclassData" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-success" id="div2" runat="server"><%--class="panel panel-success"--%>
                <div id="divhdr" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important"
                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div4','Span3');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblMapping" runat="server" Font-Bold="false"></asp:Label>
                            <%--shreela--%>&nbsp;
                        </div>
                        <div class="col-sm-2">
                            <span id="Span3" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="div4" runat="server" class="panel-body">
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <span style="color: Red;">
                                <asp:Label ID="lblLocation" runat="server" CssClass="control-label" Style="color: Black"></asp:Label>
                                *</span><%--shreela--%></div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" TabIndex="3"
                                MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <span style="color: Red;">
                                <asp:Label ID="lblPrimary" runat="server" CssClass="control-label" Style="color: Black"></asp:Label>
                                *</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" TabIndex="4">
                                        <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Agent" Value="Agent"></asp:ListItem>
                                        <asp:ListItem Text="Vendor" Value="Vendor"></asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-success" id="div5" runat="server">
                <div id="divhd" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important"
                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','Span4');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblMapDtls" runat="server" CssClass="control-label" Font-Bold="false"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="Span4" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="div6" runat="server" class="panel-body">
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblChannel" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lblSubChannel" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblBranch" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lblSalesManager" runat="server" CssClass="control-label"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:UpdatePanel ID="upnlChn1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChannel1" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlChannel1_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubChannel1" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlSubChannel1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%-- <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="ddlChannel1" 
                                                                     EventName="SelectedIndexChanged" />
                                                             </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlBranch1" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlBranch1_SelectedIndexChanged" TabIndex="5">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%-- <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="ddlSubChannel1" 
                                                                     EventName="SelectedIndexChanged" />
                                                             </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSalesManager1" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlSalesManager1_SelectedIndexChanged" TabIndex="6">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%-- <Triggers>
                                                                 <asp:AsyncPostBackTrigger ControlID="ddlBranch1" 
                                                                     EventName="SelectedIndexChanged" />
                                                             </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 12px;" id="divbtn" runat="server">
                <div class="col-sm-12" align="center">
                    <asp:UpdatePanel ID="updSaveBtn" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" AutoPostback="false"
                                OnClick="btnAdd_Click" visble="true" OnClientClick="mandtxtbox();">
                                 <span class="glyphicon glyphicon-Save" style='color:White;'></span> 
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger"
                                runat="server">
                                 <span class="glyphicon glyphicon-remove"></span> </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div align="center" style='margin: 1%;' class="col-sm-12">
            <asp:HiddenField ID="hdnAgtCode" runat="server" />
            <asp:HiddenField ID="hdnAgentName" runat="server" />
            <asp:HiddenField ID="hdnAgnBizSrc" runat="server" />
            <asp:HiddenField ID="hdnAgnChnCls" runat="server" />
            <asp:HiddenField ID="hdnVendCode" runat="server" />
            <asp:HiddenField ID="hdnVendBizSrc" runat="server" />
            <asp:HiddenField ID="hdnVendName" runat="server" />
            <asp:HiddenField ID="hdnVendChnCls" runat="server" />
        </div>
    </div>
    <asp:Label runat="server" ID="Label3" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        TargetControlID="Label3" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="700px" height="380px" frameborder="1" display="none"></iframe>
    </asp:Panel>
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content" style='width: 500px; height: 500px;'>
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label1" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

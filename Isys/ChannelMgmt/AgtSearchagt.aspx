<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AgtSearchagt.aspx.cs" Inherits="Application_Isys_ChannelMgmt_AgtSearchagt" %>


<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <%--    <script type="text/javascript" src="../../../Scripts/CalendarControl.js"></script>--%>
    <script type="text/javascript">
        function funClearTxt() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + "ddlSlsChnnl").selectedIndex == 0;
            document.getElementById(strContent + "txtAgntCode") = "";
            document.getElementById(strContent + "txtAgntName") = "";
            document.getElementById(strContent + "ddlRptTyp").selectedIndex == 0;
            document.getElementById(strContent + "txtSapCode") = "";
            document.getElementById(strContent + "ddlPosition").selectedIndex == 0;
            document.getElementById(strContent + "ddlSlsChnnl").selectedIndex == 0;
            document.getElementById(strContent + "txtPAN") = "";
            document.getElementById(strContent + "txtDTJoinFrom") = "";
            document.getElementById(strContent + "txtDTJoinTo") = "";
            document.getElementById(strContent + "txtLicNo") = "";
        }
           
        
    </script>
    <script type="text/javascript">
        $(function () {
            debugger;

            $("#<%= txtDTJoinFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtDTJoinTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });
    </script>
    <style type="text/css">
        .btn-tab
        {
            color: #3c763d;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }
        
        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus
        {
            color: #555555;
            background-color: #dff0d8;
        }
        
        ul#menu li a:active
        {
            background: white;
        }
        
        
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
    <script language="javascript" type="text/javascript">

        function addCssClassByClick(flag) {
            debugger;

            if (flag == 1) {

                //alert("Hello");
                $("#ctl00_ContentPlaceHolder1_Employee").addClass("btn-tab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Agent").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Other").removeClass("btn-tab")

            }

            else if (flag == 2) {
                //  alert("Hello11");
                $("#ctl00_ContentPlaceHolder1_Employee").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Agent").addClass("btn-tab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Other").removeClass("btn-tab")

            }

            else if (flag == 3) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_Employee").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Agent").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Other").addClass("btn-tab btn btn-default")

            }

        }


        var path = "<%=Request.ApplicationPath.ToString()%>";
        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            var sAgtType = document.getElementById('<%= ddlAgntType.ClientID %>').value;
            var sChekCDA = document.getElementById('<%= CDACheck.ClientID %>');

            if (document.getElementById(strContent + "ddlSlsChnnl") != null) {
                if (document.getElementById(strContent + "ddlSlsChnnl").disabled == false) {
                    if (document.getElementById(strContent + "ddlSlsChnnl").selectedIndex == 0) {
                        alert('Please Select Sales Channel');
                        document.getElementById(strContent + "ddlSlsChnnl").focus();
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlChnCls") != null) {
                if (document.getElementById(strContent + "ddlChnCls").disabled == false) {
                    if (document.getElementById(strContent + "ddlChnCls").selectedIndex == 0) {
                        alert('Please Select Channel Sub Class');
                        document.getElementById(strContent + "ddlChnCls").focus();
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlAgntType") != null) {
                if (document.getElementById(strContent + "ddlAgntType").selectedIndex == 0) {
                    alert('Please Select Agent Type');
                    document.getElementById(strContent + "ddlAgntType").focus();
                    return false;
                }
            }

            if ((sAgtType.value == 'All' || sAgtType.value == 'HO' || sAgtType.value == 'ZM' || sAgtType.value == 'RM' || sAgtType.value == 'CM' || sAgtType.value == 'BM') && (sChekCDA.checked == true)) {
                alert("CDA linkage is allowed for franchise manager only.");
                return false;
            }

        }

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

        function CheckAgtTypeForCDA() {
            var sAgtType = document.getElementById('<%= ddlAgntType.ClientID %>').value;
            var sChekCDA = document.getElementById('<%= CDACheck.ClientID %>');

            if (sChekCDA.checked == true) {
                if (sAgtType.value == 'All' || sAgtType.value == 'HO' || sAgtType.value == 'ZM' || sAgtType.value == 'RM' || sAgtType.value == 'CM' || sAgtType.value == 'BM') {
                    alert('CDA linkage is allowed for franchise manager only.');
                    sChekCDA.checked = false;
                    return false;
                }
            }
        }
        //Added by Vijendra on 13-03-2014 to validate textboxes start
        function fncInputNumericValuesOnly() {
            if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
                event.returnValue = false;
            }
        }
        //Added by Vijendra on 13-03-2014 to validate textboxes End

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
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }



            catch (err) {
                ShowError(err.description);
            }
        }


        //    function ShowReqDtl(divId, btnId, img) {
        //        var strContent = "ctl00_ContentPlaceHolder1_";
        //        $(document.getElementById(strContent + divId)).slideToggle();
        //        if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
        //            $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
        //        }
        //        else {
        //            $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
        //        }
        //    }


        //Added by Kalyani on 11-12-2013 for collapsable functionality start
        function ShowReqDtls(divId, btnId) {
            //debugger;
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
        //Added by Kalyani on 11-12-2013 for collapsable functionality end
        //Added by swapnesh on 16/12/2013 for collapsable functionality start
        function ShowReqDtlonSearch(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(divId).value = '+'
                //document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(btnId).value = '-'
                //document.getElementById(btnId).value = '-';
            }
        }
        //Added by swapnesh on 16/12/2013 for collapsable functionality end

        //added by akshay on 25/03/14 start for pan validation

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
                else {
                    return 0;
                }
            }
            return 1;
        }

        function ValidationPAN() {

            var varPAN = document.getElementById('<%= txtPAN.ClientID %>').value;

            //            if (varPAN.length == 0) {
            //                alert('Please Enter PAN No.');
            //                document.getElementById('<%= txtPAN.ClientID %>').focus();
            //                return false;
            //            }
            if (varPAN != "") {
                if (varPAN.length < 10) {
                    alert('PAN No. must have minimum 10 characters.');
                    document.getElementById('<%= txtPAN.ClientID %>').focus();
                    return false;
                }

                if (varPAN.length != 10) {
                    alert('PAN No. should be 10 characters.');
                    document.getElementById('<%= txtPAN.ClientID %>').focus();
                    return false;
                }

                //Validation for PAN No format.
                if (SpaceTrim(document.getElementById('<%= txtPAN.ClientID %>').value) != "") {
                    if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtPAN.ClientID %>').value)) == 0) {
                        alert('Invalid Pan Format');
                        document.getElementById('<%= txtPAN.ClientID %>').focus();
                        return false;
                    }
                }
            }
        }
        //added by akshay on 25/03/14 end
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd6576" runat="server">
    <ContentTemplate>
    <center>
        <asp:ImageButton ID="lnkTab1" runat="server" Visible="false" CssClass="TextBox" BackColor="transparent"
            Style="margin-left: 13px;" ImageUrl="~/theme/iflow/tabs/Employee1.png" OnClick="lnkTab1_Click" />
        <asp:ImageButton ID="lnkTab2" runat="server" CssClass="TextBox" BackColor="Transparent"
            Style="margin-left: 13px;" ImageUrl="~/theme/iflow/tabs/Agent2.png" OnClick="lnkTab2_Click"
            Visible="false" />
        <asp:ImageButton ID="lnkTab3" runat="server" CssClass="TextBox" BackColor="Transparent"
            Style="margin-left: 13px;" ImageUrl="~/theme/iflow/tabs/Other2.png" OnClick="lnkTab3_Click"
            Visible="false" />
        <div id="demo1" style="margin-right: 980px;" runat="server">
            <asp:LinkButton ID="Employee" Text="Employee" CssClass="btn-tab btn btn-default"
                OnClientClick="return addCssClassByClick('1')" OnClick="Employee_Click" runat="server" Visible="false"></asp:LinkButton>
            <asp:LinkButton ID="Agent" Text="Agent" CssClass=" btn btn-default" OnClientClick="return addCssClassByClick('2')"
                OnClick="Agent_Click" runat="server" Visible="false"></asp:LinkButton>
            <asp:LinkButton ID="Other" Text="Other" CssClass="btn btn-default" OnClientClick="return addCssClassByClick('3')"
                OnClick="Other_Click" runat="server" Visible="false"></asp:LinkButton>
        </div>
        <div class="container">
            <div class="panel panel-success" style="margin-left: 0px; margin-right: 0px">
                <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('hide1','btnNominee');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                            <asp:Label ID="lblSourceName" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="btnNominee" class="glyphicon glyphicon-collapse-down" style="float: right;
                                color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="hide1" class="panel-body">
                    <div class="panel panel-success" style="margin-top: 15px;">
                        <div id="Div1" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important"
                            onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtBasicSearch','Span3');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                    <asp:Label ID="lblbas" Text="Basic Search" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span3" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                        padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="divAgtBasicSearch" runat="server" class="panel-body">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgntCode" CssClass="control-label" runat="server" Font-Bold="False"
                                        Text="Member Code"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAgntCode" runat="server" CssClass="form-control" onkeypress="fncInputNumericValuesOnly('txtQty')"
                                        MaxLength="8"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtagtcdFTX" runat="server" InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-"
                                        FilterMode="InvalidChars" TargetControlID="txtAgntCode" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblAgntName" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtAgntName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                        InvalidChars=",#$@%^!*()&''%^~`0123456789<>=?./|\{}[]:+;-" FilterMode="InvalidChars"
                                        TargetControlID="txtAgntName" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblRptType" CssClass="control-label" runat="server" Text="Reporting Type"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updRptType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlRptTyp" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="ddlRptTyp_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblImmLeaderCode" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updMgrCode" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtImmLeaderCode" runat="server" CssClass="form-control" Enabled="false"
                                                onkeypress="fncInputNumericValuesOnly('txtQty')" MaxLength="8"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="LblMgrSapCode" Text="Rpt Manager SAP Code" CssClass="control-label"
                                        runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:UpdatePanel ID="updMgrSapCode" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtMgrSapCode" runat="server" CssClass="form-control" Enabled="false"
                                                onkeypress="fncInputNumericValuesOnly('txtMgrSapCode')" MaxLength="8"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblSapCode" CssClass="control-label" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control" onkeypress="fncInputNumericValuesOnly('txtQty')"
                                        MaxLength="8"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtSapCdFTX" runat="server" InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-"
                                        FilterMode="InvalidChars" TargetControlID="txtSapCode" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblShwRecords" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-success" style="margin-top: 15px;">
                        <div id="Div3" runat="server" class="panel-heading" style="background-color: #EDF1cc !important"
                            onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtAdv','Span1');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                    <asp:Label ID="Label3" Text="Advance Search" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                        padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="divAgtAdv" runat="server" class="panel-body">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblchnltype" CssClass="control-label" runat="server" Text="Hierarchy Type"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                            CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Text="Company &nbsp;&nbsp;"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblPosition" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSlsChnnl" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSlsChnnl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlsChnnl_SelectedIndexChanged"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblIDNo" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtPAN" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars=",#$@%^!*()&amp; ''%^~`<>=?./|\{}[]:+;-"
                                    TargetControlID="txtPAN">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblChnCls" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlSlsChnnl" EventName="SelectedIndexChanged">
                                        </asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAgntStatus" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlAgntStatus" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAgntType" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="upnlAgnType" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblUnitCode" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="display: flex;">
                                <asp:TextBox ID="txtUnitCode" runat="server" CssClass="form-control" onkeypress="fncInputNumericValuesOnly('txtQty')"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    InvalidChars=",#$@%^!*()&''%^~`<>=?./|\{}[]:+;-" FilterMode="InvalidChars" TargetControlID="txtUnitCode"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:Button ID="btnUnitCode" runat="server" Style="margin-left: 2px;" CssClass="btn btn-primary"
                                    Text="..." UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblUnTyp" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updUnitType" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlUnitType" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRptUntTyp" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updUnits" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlUnits" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlUnitType" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDTJoinFrom" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtDTJoinFrom" onclientclick="$('#txtDTJoinFrom').datepicker({ changeMonth: true, changeYear: true });"
                                    onchange="setDateFormat('txtDTJoinFrom')"></asp:TextBox>
                            </div>
                            <%--onmousedown="$('#txtDTJoinFrom').datepicker({dateFormat: 'dd/mm/yy' , changeMonth: true, changeYear: true });"--%>
                            <%--<asp:Image ID="Image1" runat="server" Height="20px"  Width="20px" CssClass=".ajax__calendar"
                                                ImageUrl="~/App_UserControl/Common/calendar.bmp" style='margin-left:3px;'/>--%>
                            <%-- <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                                        runat="server" Width="80px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" CssClass="ajax__calendar" runat="server" TargetControlID="txtDTJoinFrom"
                                        PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />--%>
                            <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtDTJoinFrom"
                                Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator><%--&nbsp;--%>
                            <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                Type="Date" ControlToValidate="txtDTJoinFrom" Display="Dynamic"></asp:CompareValidator><%--&nbsp;--%>
                            <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtDTJoinFrom" Display="Dynamic"
                                ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                Type="Date"></asp:RangeValidator>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDTJoinTo" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtDTJoinTo" onmousedown="$('#txtDTJoinTo').datepicker({dateFormat: 'dd/mm/yy' , changeMonth: true, changeYear: true });"></asp:TextBox>
                            </div>
                            <%-- <asp:Image ID="btnCalendar" runat="server" Height="20px"  Width="20px" CssClass=".ajax__calendar"
                                                ImageUrl="~/App_UserControl/Common/calendar.bmp" style='margin-left:3px;' />--%>
                            <asp:TextBox CssClass="standardtextbox" ID="TextBox2" Style="display: none" runat="server"></asp:TextBox>
                            <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="ajax__calendar" runat="server" TargetControlID="txtDTJoinTo"
                                        PopupButtonID="btnCalendar1" Format="dd/MM/yyyy" />
                            --%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                ControlToValidate="TextBox2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!"
                                Operator="DataTypeCheck" Type="Date" ControlToValidate="TextBox2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
                                Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                            <%-- <div class="col-sm-3" style="text-align:left">--%>
                            <asp:Label ID="lblCSCCode" runat="server" Visible="false" CssClass="control-label"
                                Font-Bold="False"></asp:Label>
                            <%--  </div>
                              <div class="col-sm-3">--%>
                            <asp:TextBox ID="txtCSCCode" Visible="false" runat="server" CssClass="form-control"
                                MaxLength="6"></asp:TextBox>
                            <%--  </div>
                                
                             <div class="col-sm-3" style="text-align:left">--%>
                            <asp:Label ID="lblRefAdv" Visible="false" runat="server" CssClass="control-label"></asp:Label>
                            <%--  </div>
                                
                              <div class="col-sm-3">--%>
                            <asp:TextBox ID="txtLinkRef" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--  </div>
                                
                             <div class="col-sm-3" style="text-align:left">--%>
                            <asp:Label ID="lblClientCode" Visible="false" runat="server" CssClass="control-label"></asp:Label>
                            <%--  </div>
                                
                              <div class="col-sm-3">--%>
                            <asp:TextBox ID="txtGCN" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                            <%--</div>--%>
                            <asp:Label ID="lblchbox" runat="server" Visible="false" CssClass="control-label"></asp:Label>
                            <asp:Label ID="lblFranchisee" runat="server" Visible="False" CssClass="control-label"></asp:Label>
                            <asp:CheckBox ID="chbxdefaultunit" runat="server" Text="" Visible="false" />
                            <asp:CheckBox ID="ChkFranchisee" runat="server" Visible="False" />
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblLicenseNo" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtLicNo" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars=",#$@%^!*()&amp; ''%^~`<>=?./|\{}[]:+;-"
                                    TargetControlID="txtLicNo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <asp:Label ID="lblCDALinkg" Visible="false" CssClass="control-label" runat="server"></asp:Label>
                            <asp:CheckBox ID="CDACheck" Visible="false" runat="server" Text="" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" CausesValidation="true"
                                Text="SEARCH" OnClick="btnSearch_Click" OnClientClick="javascript:validate();"
                                TabIndex="43">
                         <span class="glyphicon glyphicon-search" style='color: White;'></span> Search
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-primary" CausesValidation="False"
                                 OnClick="btnClear_Click" TabIndex="43"><%--OnClientClick="funClearTxt();"--%>
                              <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <table width="95%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <%--<div id="divsrchHdr" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr ID="trDetails" runat="server" style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-search"></i>
                                  <asp:Label ID="lblAgtSrchRes" runat="server" Text="Member Search Results"></asp:Label>
                                  </td>
    
                
                          <td style="text-align: right;">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>

                                        <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divsrch','Img2','#Img2);" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
            </tr>
            </table>--%>
        <div id="divsearch1" runat="server" class="panel panel-success" style="margin-top: 15px;
            display: none;">
            <div id="divsrchHdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrch','Span2');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                        <asp:Label ID="lblAgtSrchRes" runat="server" Text="Member Search Results"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divsrch" runat="server" style="width: 100%; padding: 5px;">
                <%--padding: 10px;--%>
                <div id="Div2" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                    class="table-scrollable">
                    <asp:UpdatePanel ID="upUnitRank" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="10" HorizontalAlign="Left" OnRowDataBound="dgDetails_RowDataBound"
                                OnPageIndexChanging="dgDetails_PageIndexChanging" CssClass="footable" AllowSorting="True"
                                OnSorting="dgDetails_Sorting">
                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:ImageField DataImageUrlField="MemCode" DataImageUrlFormatString="ImageGrid.aspx?ImageID={0}"
                                        HeaderText="Photo" ControlStyle-Height="40px" ControlStyle-Width="40px">
                                    </asp:ImageField>
                                    <asp:BoundField DataField="MemCode" SortExpression="MemCode" HeaderText="Member Code">
                                        <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Emp Code" SortExpression="EMPCode">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Visible="true" Text='<%# Bind("EMPCode") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnMemRole" runat="server" Value='<%# Bind("MemberRole") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ins Ref Code" SortExpression="InsMemCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInsMemCode" runat="server" Text='<%# Bind("InsMemCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName">
                                        <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PAN" DataField="CurrentID" SortExpression="CurrentID"
                                        Visible="false">
                                        <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField HeaderText="Manager Code" DataField="MgrCode" SortExpression="MgrCode">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="Unit Code" DataField="unitCode" SortExpression="unitCode" />
                                    <%--<asp:BoundField HeaderText="Unit Desc" DataField="UnitDesc" SortExpression="UnitDesc" ItemStyle-HorizontalAlign="Left" />--%>
                                    <asp:BoundField HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" />
                                    <asp:BoundField HeaderText="Sub Class" DataField="ChnCls" SortExpression="ChnCls" />
                                    <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" />
                                    <asp:BoundField DataField="MemStatus" HeaderText="Status" SortExpression="MemStatus" />
                                    <%-- <asp:BoundField DataField="RecruitDate" HeaderText="Join Date" SortExpression="RecruitDate" />--%>
                                    <asp:TemplateField HeaderText="Member Status" SortExpression="MemStatus" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AgentStatus" runat="server" Visible="true" Text='<%# Bind("MemStatus") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnCrMvmtRule" runat="server" Value='<%# Bind("CrMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnModMvmtRule" runat="server" Value='<%# Bind("ModMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnTrfMvmtRule" runat="server" Value='<%# Bind("TrfMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnTrmMvmtRule" runat="server" Value='<%# Bind("TrmMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnReinMvmtRule" runat="server" Value='<%# Bind("ReinMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnPrmMvmtRule" runat="server" Value='<%# Bind("PrmMvmtRule") %>'/>
                                            <asp:HiddenField ID="hdnDemMvmtRule" runat="server" Value='<%# Bind("DemMvmtRule") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MgrEMPCode" SortExpression="MgrEmpcode" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="MgrEMPCode" runat="server" Visible="true" Text='<%# Bind("MgrEmpcode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Link" HeaderText="Link" HeaderStyle-Wrap="false"
                                        Visible="false" ItemStyle-Width="6%">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnk" runat="server" Text="Link" CommandArgument='<%# Bind("MemCode") %>'
                                                CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <br />
            </div>
            <div id="divPage" visible="true" runat="server" class="pagination">
                <center>
                    <table>
                        <tr>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </tr>
                    </table>
                </center>
                <br />
            </div>
        </div>
        <asp:HiddenField ID="hdnAgentRole" runat="server" />
    </center>
    <script type="text/javascript">
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup start


        function funcShowPopup(strPopUpType) {
            debugger;
            if (strPopUpType == "unitcode") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/GetunitCodePopUp.aspx?Code=" + document.getElementById('<%=txtUnitCode.ClientID %>').value + "&Desc=" + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field1="
        + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field2=" + document.getElementById('<%=txtUnitCode.ClientID %>').id + "&field3= 1" + "&mdlpopup=mdlViewBID";
            }

        }

        function funcShowPopupBAS(Agtcode) {

            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/PopVendorlist.aspx?AgentCode=" + Agtcode + "&mdlpopup=mdlViewBID";


        }
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup 
    </script>

    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" BackColor="White"  display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="420px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="Panel1" Width="700" display="none">
        <iframe runat="server" id="Iframe1" width="700" height="700px" frameborder="0" display="none">
        </iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label2" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlView"
        DropShadow="true" TargetControlID="Label2" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



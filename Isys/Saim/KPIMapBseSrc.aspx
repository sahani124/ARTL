<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" EnableViewState="true"
    CodeFile="KPIMapBseSrc.aspx.cs" Inherits="Application_ISys_Saim_KPIMapBseSrc" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=11,IE=10" />

    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />


    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>

    <%--<link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../../KMI Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />

    <%-- <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />


    <%-- <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />--%>
    <link href="../../../KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>

    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <%--Added References by Daksh for Reports Start--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <%--Added References by DAksh for Reports End--%>


    <script type="text/javascript">



        $(document).ready(function () {
            fnSetTabs('1');
        });

        function fnSetTabs(strTabIndex) {
            debugger;
            if (strTabIndex == '1') {
                document.getElementById("ctl00_ContentPlaceHolder1_divDJoin").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_DivWhr").style.display = "none";
                document.getElementById("liDJ").className = "active";
                document.getElementById("liDWC").classList.remove("active");
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "1";
            }
            if (strTabIndex == '2') {
                document.getElementById("ctl00_ContentPlaceHolder1_divDJoin").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_DivWhr").style.display = "block";
                document.getElementById("liDJ").classList.remove("active");
                document.getElementById("liDWC").className = "active";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnTabIndex").value = "2";
            }
        }



         function fnselSrcTblCol() {
            debugger;
        
            var ddlSTcol = document.getElementById("ctl00_ContentPlaceHolder1_ddlBsetblCol");
            var optionSelIndex = ddlSTcol.options[ctl00_ContentPlaceHolder1_ddlBsetblCol.selectedIndex].value;
            if (optionSelIndex == 0) {
                alert("Please Select Base Table Column.");
                return false;
            }

                     
            fnCallPOP(optionSelIndex)
            document.getElementById("%=ctl00_ContentPlaceHolder1_BtnGrp").click();
           
        }

        function fnCallPOP(SRC_TBL_COL) {
            debugger;
            $find("mdlVwBID2").show();
            var Mode = "B";
            document.getElementById("<%=ddlSrctblCol.ClientID%>").disabled = true;
            var KPI_CD = document.getElementById("<%=txtIntGid.ClientID%>").value;
            var SrcTbl = document.getElementById("ctl00_ContentPlaceHolder1_txtSrctblNam").value;
            var MapCode = document.getElementById("ctl00_ContentPlaceHolder1_hdnKPIMapCode").value;
               
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd3").src = ("KPIMapBseSrcFormulaPopUp.aspx?&SRC_TBL_COL=" + SRC_TBL_COL + "&SrcTbl=" + SrcTbl + "&MapCode=" + MapCode + "&KPI_CD=" + KPI_CD + "&mdlpopup=mdlVwBID2");
           
         
            return false;
        }


         
        function test()
        {
            alert("hi");
        }

        function callEffectiveDate() {
            //minDate:new Date()  
            debugger;
            $("[id*=TxtWhrCseDt],[id*=TxtWhrEffFrm],[id*=txtEffDtFrm],[id*=txtceasedt],[id*=txtDJEffFrom],[id*=txtDJEffTo],[id*=txtDCJoinEffFrm],[id*=txtDCJoinEffTo],[id*=txtmapEffDtFrm],[id*=txtmapceasedt]").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true, onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        $(this).change()
                        //checkDate();
                        button: ".next()"
                    }
                }
            });
        }

        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function CloseDiv(divId) {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }
        function gotoHome() {
            parent.location.href = parent.location.href;
        }
        function confPromptBox() {
            var resp = confirm("Please Select base table name")
            if (resp == true) {

                location.replace(location.href);

            }
            else {

            }

        }
        function confPromptBox1() {
            var resp = confirm("Please Select Source table name")
            if (resp == true) {

                location.replace(location.href);

            }
            else {

            }

        }
        function confPromptBox2() {
            var resp = confirm("Data Added Successfully")
            if (resp == true) {

                location.replace(location.href);

            }
            else {

            }

        }
        function ToggleDiv(Flag) {
            debugger;
            if (Flag == "col") {
                document.getElementById('<%=divDefColJoin.ClientID %>').style.display = 'block';

            }
            else {
                document.getElementById('<%=divDefColJoin.ClientID %>').style.display = 'none';
            }
        }

        function ToggleDivMap(Flag) {
            if (Flag == "col") {
                document.getElementById('<%=divmapbsetbltosrctblhdrcollapse.ClientID %>').style.display = 'block';
            }
            else {
                document.getElementById('<%=divmapbsetbltosrctblhdrcollapse.ClientID %>').style.display = 'none';
            }
        }



        function PopulateMapLDFrom() {
            debugger;
            //minDate:new Date()
            $("#<%=txtEffDtFrm.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function PopulateLDFrom() {
            debugger;
            //minDate:new Date()  ctl00_ContentPlaceHolder1_txtEffDtFrm
            $("#<%=txtEffDtFrm.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }




        function PopulateMapCeaseDate() {
            debugger;

            $("#<%= txtmapceasedt.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                     debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }



        function PopulateCeaseDate() {
            debugger;

            $("#<%= txtceasedt.ClientID  %>").datepicker({
                minDate: new Date(),
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });
        }

        function checkDate() {
            debugger;

            var EffDate = $('#<%= txtEffDtFrm.ClientID  %>').val();
            var CeDate = $('#<%= txtceasedt.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";
            debugger;
            if (EffDate != "" && CeDate != "") {
                if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                    alert("Please select the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtceasedt").value = "";
                    return false;
                }
                else {
                    //alert("step2");
                }
            }
        }

        function checkDateIsGreaterThanToday(fromDay, toDay) {
            debugger;
            var fromArr = fromDay.split('/');
            var toArr = toDay.split('/');

            if (fromArr[2] == toArr[2]) {
                if (fromArr[1] < toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if (fromArr[1] == toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            else if (fromArr[2] < toArr[2]) {

                return true;

            }
            else {
                return false;
            }
        }


        function openDJoin() {
            debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divDJoin").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divDwhereCondition").style.display = "none";
        }

        function openDwhereCondition() {
            debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divDJoin").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divDwhereCondition").style.display = "block";
        }


        function openDefJoin(divName, divNameNone) {
            debugger;
            var div = document.getElementById(divName);
            var divNone = document.getElementById(divNameNone);
            if (div.style.display !== "none") {
                div.style.display = "none";
            }
            else {
                div.style.display = "block";
                divNone.style.display = "none";
            }
        }

        function openWhrCond(divName, divNameNone) {
            debugger;
            var div = document.getElementById(divName);
            var divNone = document.getElementById(divNameNone);
            if (div.style.display !== "none") {
                div.style.display = "none";
            }
            else {
                div.style.display = "block";
                divNone.style.display = "none";
            }
        }

        function OpenPopupColData(FlagType, CallVal) {
            debugger;

            //window.open("DefColDtType.aspx?CallVal=" + CallVal + "", '', 'width=800,height=350,toolbar=no,scrollbars=Yes,resizable=No,left=300,top=150,location=0;');


            window.open("DefColDtType.aspx?FlagType=" + FlagType + "&CallVal=" + CallVal + "", '', 'width=800,height=350,toolbar=no,scrollbars=Yes,resizable=No,left=300,top=150,location=0;');
        }

    </script>
    <%--<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main1.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .disablepage td {
            display: none;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
            vertical-align: top;
        }

        .custom {
            width: 100px !important;
        }

        .color-white {
            color: #fff !important;
        }

        .bg-primary {
            color: #fff !important;
            background-color: #337ab7 !important;
        }

        .p-0 {
            padding: 0px;
        }

        .font-14 {
            font-size: 14px;
        }

        .text-black {
            color: #000;
        }

        .glyphicon {
            color: black;
            margin-left: 5px;
            margin-right: 5px;
            cursor: pointer;
        }

        .CenterAlign {
            text-align: center !important;
        }

        .LeftAlign {
            text-align: left !important;
        }

        .RightAlign {
            text-align: right !important;
        }

        .multiselect {
            overflow: hidden;
            width: 245px;
        }

        .glyphicon:hover {
            color: #fff;
        }

        .btn.focus, .btn:focus, .btn:hover {
            color: #fff !important;
        }

        .multiselect {
            overflow: hidden;
            width: 245px;
        }

        .multiselect-container {
            max-height: 200px;
            overflow: scroll;
        }

            .multiselect-container::-webkit-scrollbar {
                width: 7px;
                height: 0px;
            }

            /* Track */
            .multiselect-container::-webkit-scrollbar-track {
                background: #f1f1f1;
            }

            /* Handle */
            .multiselect-container::-webkit-scrollbar-thumb {
                background: #888;
            }

                /* Handle on hover */
                .multiselect-container::-webkit-scrollbar-thumb:hover {
                    background: #555;
                }
        /*.footable > tbody > tr > td{
            text-align:center;*/
        }
    </style>

    <style>
        /* Style the tab */
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #e6f7ff;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 2px 90px;
                transition: 0.3s;
                font-size: 13px;
                font-family: Tahoma;
                font-weight: bold;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>


    <style type="text/css">
        .new_text_new {
            color: #066de7;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }

        .gridview th {
            text-align: left;
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap;
        }
    </style>

    <style>
        /* Style the tab */
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #e6f7ff;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 2px 90px;
                transition: 0.3s;
                font-size: 13px;
                font-family: Tahoma;
                font-weight: bold;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>


    <style type="text/css">
        .nav-tabs {
            border-bottom: 2px solid #DDD;
        }

            .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
                border-width: 0;
            }

            .nav-tabs > li > a {
                border: none;
                color: #666;
            }

                .nav-tabs > li.active > a, .nav-tabs > li > a:hover {
                    border: none;
                    color: #4285F4 !important;
                    background: transparent;
                }

                .nav-tabs > li > a::after {
                    content: "";
                    background: #4285F4;
                    height: 2px;
                    position: absolute;
                    width: 100%;
                    left: 0px;
                    bottom: -1px;
                    transition: all 250ms ease 0s;
                    transform: scale(0);
                }

            .nav-tabs > li.active > a::after, .nav-tabs > li:hover > a::after {
                transform: scale(1);
            }

        .tab-nav > li > a::after {
            background: #21527d none repeat scroll 0% 0%;
            color: #fff;
        }

        .tab-pane {
            padding: 15px 0;
        }

        .tab-content {
            padding: 20px;
        }

        .card {
            background: #FFF none repeat scroll 0% 0%;
            box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
            margin-bottom: 30px;
        }

        body {
            /*background: #EDECEC;*/
            /*padding: 50px;*/
        }
    </style>

    <style type="text/css">
        .pad {
            text-align: center !important;
        }

        .pad1 {
            padding-left: 0.5% !important;
        }
    </style>

    <style type="text/css">
        a:hover, a:focus {
                outline: none;
                text-decoration: none;
        }

        .tab .nav-tabs {
                border: none;
                margin-bottom: 10px;
        }

            .tab .nav-tabs li a {
                    padding: 10px 20px;
                    margin-right: 15px;
                    background: #f8333c;
                    font-size: 17px;
                    font-weight: 600;
                    color: #fff;
                    text-transform: uppercase;
                    border: none;
                    border-top: 3px solid #f8333c;
                    border-bottom: 3px solid #f8333c;
                    border-radius: 0;
                    overflow: hidden;
                    position: relative;
                    transition: all 0.3s ease 0s;
            }

                .tab .nav-tabs li.active a,
                .tab .nav-tabs li a:hover {
                        border: none;
                        border-top: 3px solid #f8333c;
                        border-bottom: 3px solid #f8333c;
                        background: #fff;
                        color: #f8333c;
                }

                .tab .nav-tabs li a:before {
                        content: "";
                        border-top: 15px solid #f8333c;
                        border-right: 15px solid transparent;
                        border-bottom: 15px solid transparent;
                        position: absolute;
                        top: 0;
                        left: -50%;
                        transition: all 0.3s ease 0s;
                }

                .tab .nav-tabs li a:hover:before,
                .tab .nav-tabs li.active a:before {
                    left: 0;
                }

                .tab .nav-tabs li a:after {
                        content: "";
                        border-bottom: 15px solid #f8333c;
                        border-left: 15px solid transparent;
                        border-top: 15px solid transparent;
                        position: absolute;
                        bottom: 0;
                        right: -50%;
                        transition: all 0.3s ease 0s;
                }

                .tab .nav-tabs li a:hover:after,
                .tab .nav-tabs li.active a:after {
                    right: 0;
                }

        .tab .tab-content {
                padding: 20px 30px;
                border-top: 3px solid #384d48;
                border-bottom: 3px solid #384d48;
                font-size: 17px;
                color: #384d48;
                letter-spacing: 1px;
                line-height: 30px;
                position: relative;
        }

            .tab .tab-content:before {
                    content: "";
                    border-top: 25px solid #384d48;
                    border-right: 25px solid transparent;
                    border-bottom: 25px solid transparent;
                    position: absolute;
                    top: 0;
                    left: 0;
            }

            .tab .tab-content:after {
                    content: "";
                    border-bottom: 25px solid #384d48;
                    border-left: 25px solid transparent;
                    border-top: 25px solid transparent;
                    position: absolute;
                    bottom: 0;
                    right: 0;
            }

            .tab .tab-content h3 {
                    font-size: 24px;
                    margin-top: 0;
            }

        @media only screen and (max-width: 479px) {
                 .tab .nav-tabs li {
                        width: 100%;
                        text-align: center;
                        margin-bottom: 15px;
            }
        }

        .disablepage {
            display: none;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            /*color: #337ab7;*/
        }

        .imgheight {
            display: block;
            max-width: 100%;
            height: 50px;
        }

        .textalign th {
            padding-left: 42%;
        }

        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }
    </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <%-- <asp:UpdatePanel ID="updRl" runat="server">
        <ContentTemplate>--%>

    <div id="divmapkpibsetblhdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%" class="panel">
        <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmapkpibsetblhdr','myImg1');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="Label1" Text="Map KPI Base Table" runat="server" Font-Size="19px" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
        <div id="divmapkpibsetblhdr" runat="server" style="width: 96%;" class="panel-body">
            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrcBaseMapCd" Text="KPI Base Source Map Code" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtkpiBseSrcMapCode" runat="server" CssClass="form-control" TabIndex="2"
                                MaxLength="40" />
                            <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars="_,@,#"
                                    FilterMode="ValidChars" TargetControlID="txtkpiBseSrcMapCode">
                                             </ajaxToolkit:FilteredTextBoxExtender>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblkpicoddesc" Text="KPI Code & Description" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <%--  <asp:Label ID="txtkpicoddesc" runat="server" CssClass="form-control" TabIndex="2"
                                    MaxLength="100" />--%>

                            <asp:TextBox ID="txtkpicoddesc" runat="server" Enabled="false" CssClass="form-control"
                                TextMode="MultiLine" Columns="10" ClientIDMode="Static" Rows="2" MaxLength="2" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblbsetbl" Text="Base Table" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label ID="Label3" Text="*" runat="server" Style="color: Red" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlbsetbl" runat="server" CssClass="select2-container form-control"
                                TabIndex="1" Height="35px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblSrctbl" Text="Source Table" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSrctbl" runat="server" CssClass="select2-container form-control"
                                TabIndex="1" Height="35px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>



            <div class="row" style="margin-bottom: 5px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblEffDate" Text="Effective Date" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEffDtFrm" runat="server" CssClass="form-control" onclick="callEffectiveDate()" Enabled="false"
                                placeholder="DD/MM/YYYY" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblceasedt" Text="Cease Date" runat="server" CssClass="control-label" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtceasedt" runat="server" CssClass="form-control" onclick="callEffectiveDate()" Enabled="false" placeholder="DD/MM/YYYY" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

            <div class="row" style="margin-bottom: 5px;">

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblStatus" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                    <asp:Label Text="*" runat="server" Style="color: Red" />
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlStatus" Enabled="false" runat="server" CssClass="select2-container form-control"
                                TabIndex="1" Height="35px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

            <div class="row" style="margin-top: 12px; margin-bottom: 4px">
                <div class="col-sm-12" align="center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnUpd" runat="server" CssClass="btn btn-sample" Style="display: none;" TabIndex="17" OnClick="btnUpd_Click">
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Update
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnSave" Style="display: inline-block;" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClick="btnCncl_Click">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div id="div19" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                class="table-scrollable">
                <div id="divGridMap" runat="server" style="width: 100%; overflow-x: scroll">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgmapkpibsetbl" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                OnRowDataBound="dgmapkpibsetbl_RowDataBound" AllowPaging="true" AutoGenerateColumns="false">
                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="KPI_CODE_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKpiCode" runat="server" Text='<%# Bind("KPI_CODE_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnKpiCode" runat="server" Value='<%# Bind("KPI_CODE")%>'></asp:HiddenField>
                                            <asp:HiddenField ID="HdnMapSeqNo" runat="server" Value='<%# Bind("SEQ_NO")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Base Table" HeaderStyle-HorizontalAlign="Left" SortExpression="BASE_TBL_ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbsetbl" runat="server" Text='<%# Bind("BASE_TBL_ID")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnbsetbl" runat="server" Value='<%# Bind("BASE_TBL_ID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Source Table" HeaderStyle-HorizontalAlign="Left" SortExpression="SRC_TBL_ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrctbl" runat="server" Text='<%# Bind("SRC_TBL_ID")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnSrctbl" runat="server" Value='<%# Bind("SRC_TBL_ID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Table Description" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="TBL_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltbldesc" runat="server" Text='<%# Bind("TBL_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="TBL_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusDesc")%>'></asp:Label>
                                            <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="left" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="EFF_DTIM">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltxtEffDTM" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                            <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center"
                                        SortExpression="CSE_DTIM">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltxtCse_DTM" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                            <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmapbsetblsrctbl" runat="server" Text="Map Base Table Column to Source Table Column" OnClientClick="return ToggleDivMap('col')" OnClick="lnkmapbsetblsrctbl_Click"></asp:LinkButton>


                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkMapEdit" runat="server" Text="Edit" OnClick="lnkMapEdit_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkMapDel" runat="server" Text="Delete"
                                                OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkMapDel_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="pagination" style="width: 100%; padding-left: 45%">
                    <table>
                        <tr>
                            <td style="white-space: nowrap">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                            Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                            OnClick="btnprevious_Click" />
                                        <asp:TextBox runat="server" ID="txtPage" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                            Text="1" CssClass="form-control" ReadOnly="true" />
                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                            Width="40px" OnClick="btnnext_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>



            <div id="divmapbsetbltosrctblhdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%; display: none" class="panel">
                <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmapbsetbltosrctblhdr','myImg1');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="Label2" Text="Map Source Table Column to Base Table Column" runat="server" Font-Size="19px" />
                        </div>
                        <div class="col-sm-2">
                            <span id="myImg2" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="divmapbsetbltosrctblhdr" runat="server" style="width: 96%;" class="panel-body">
                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblBsetblCol" Text="Base Table Column" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                            <asp:Label Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlBsetblCol" runat="server" CssClass="select2-container form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBsetblCol_SelectedIndexChanged"
                                        TabIndex="1" Height="35px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblSrctblNam" Text="Source Table Name" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                            <asp:Label Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtSrctblNam" runat="server" CssClass="form-control" TabIndex="2" MaxLength="40" Enabled="false" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars="_,@,#"
                                        FilterMode="ValidChars" TargetControlID="txtSrctblNam">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 5px;">

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblSrctblCol" Text="Source Table Column" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                            <asp:Label ID="Label7" Text="*" runat="server" Style="color: Red" />
                        </div>
                        <div class="col-sm-2">


                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSrctblCol" runat="server" CssClass="select2-container form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSrctblCol_SelectedIndexChanged"
                                            TabIndex="1" Height="35px" width="181px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                             <div class="col-sm-1">
                              <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                    <ContentTemplate>
                             <button id="divbtnGrp1" runat="server" type="button" onclick="return fnselSrcTblCol();" class="btn btn-danger" style="height:35px; width:62px">
                                            <span class="glyphicon glyphicon-plus" style="color: white;"></span>
                                        </button>
                                         </ContentTemplate>
                                </asp:UpdatePanel>


                            <%--<div class="input-group">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSrctblCol" runat="server" CssClass="select2-container form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSrctblCol_SelectedIndexChanged"
                                            TabIndex="1" Height="35px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="input-group-btn" id="divbtnGrp" runat="server" >
                                    <div class="">
                                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                    <ContentTemplate>
                                        <button id="divbtnGrp1" runat="server" type="button" onclick="return fnselSrcTblCol();" class="btn btn-danger" style="height:35px">
                                            <span class="glyphicon glyphicon-plus" style="color: white;"></span>
                                        </button>

                                        </ContentTemplate>
                                            </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>--%>


                        </div>

                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblmapStatus" Text="Status" runat="server" Style="font-size: 14px;" CssClass="control-label" />
                            <asp:Label Text="*" runat="server" Style="color: Red" />
                        </div>

                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="MapddlStatus" runat="server" CssClass="select2-container form-control" Enabled="false"
                                        TabIndex="1" Height="35px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>


                    </div>

                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblmapEffDate" Text="Effective Date" runat="server" CssClass="control-label" />
                            <span style="color: red;">*</span>
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtmapEffDtFrm" runat="server" CssClass="form-control" onclick="callEffectiveDate()" Enabled="false"
                                        placeholder="DD/MM/YYYY" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>


                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblmapceasedt" Text="Cease Date" runat="server" CssClass="control-label" />
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtmapceasedt" runat="server" Enabled="false" CssClass="form-control" onclick="callEffectiveDate()" placeholder="DD/MM/YYYY" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                   

                    <div class="row" style="margin-top: 12px; margin-bottom: 4px">
                        <div class="col-sm-12" align="center">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btnMapUpd" runat="server" CssClass="btn btn-sample" Style="display: none;" TabIndex="17" OnClick="btnMapUpd_Click">
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Update
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnSave1" Style="display: inline-block;" runat="server" CssClass="btn btn-sample" AutoPostback="false" OnClick="btnSave1_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnClear1" runat="server" CssClass="btn btn-sample" OnClick="btnClear1_Click">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White;"></span> Clear
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCnCl1" runat="server" CssClass="btn btn-sample" OnClick="btnCnCl1_Click">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                    </asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>

                <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                    class="table-scrollable">

                    <div id="divGriCol" runat="server" style="width: 100%; overflow-x: scroll">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgmapbsetbltosrctbl" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                    OnRowDataBound="dgmapbsetbltosrctbl_RowDataBound" AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />

                                     <EmptyDataTemplate>
                                                <asp:Label ID="lblerror" Text="No records found" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                            </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Base Table" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="BASE_TBL_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBsetbl" runat="server" Text='<%# Bind("BASE_TBL_ID")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnColMapSeq" runat="server" Value='<%# Bind("SEQ_NO")%>'></asp:HiddenField>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Source Table" HeaderStyle-HorizontalAlign="Left" SortExpression="SRC_TBL_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrctbl" runat="server" Text='<%# Bind("SRC_TBL_ID")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnSrctbl" runat="server" Value='<%# Bind("SRC_TBL_ID")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Base Column" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="BSE_TBL_COL_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBseCol" runat="server" Text='<%# Bind("BSE_TBL_COL_DESC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnBseCol" runat="server" Value='<%# Bind("BSE_TBL_COL_ID")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Source Column" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="SCR_TBL_COL_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrcCol" runat="server" Text='<%# Bind("SCR_TBL_COL_DESC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnSrcCol" runat="server" Value='<%# Bind("SCR_TBL_COL_ID")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="TBL_DESC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusCOL" runat="server" Text='<%# Bind("StatusDescCOL")%>'></asp:Label>
                                                <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="EFF_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtEffDTM_COL" runat="server" Text='<%# Bind("EFF_DTIM_COL")%>'></asp:Label>
                                                <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="CSE_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltxtCse_DTM_COL" runat="server" Text='<%# Bind("CSE_DTIM_COL")%>'></asp:Label>
                                                <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" Text="Edit" OnClick="lnkedit_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkMapColDel" runat="server" Text="Delete"
                                                    OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkMapColDel_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="pagination" style="width: 100%; padding-left: 45%">
                        <table>
                            <tr>
                                <td style="white-space: nowrap">
                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnpreviouscol" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                OnClick="btnpreviouscol_Click" />
                                            <asp:TextBox runat="server" ID="txtpagecol" Style="width: 35px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                                Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnextcol" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                                Width="40px" OnClick="btnnextcol_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>



            </div>


            <%--<div class="tab" style="width:97%">

                                       <button class="tablinks" onclick="openDefJoin('ctl00_ContentPlaceHolder1_divDJoin','ctl00_ContentPlaceHolder1_DivWhr')" ><a id="0" class="tab_Lnk"
                href="#">Define Join</a></button>
  <button class="tablinks" onclick="openWhrCond('ctl00_ContentPlaceHolder1_DivWhr','ctl00_ContentPlaceHolder1_divDJoin' )" ><a id="1" class="tab_Lnk"
                href="#" >Define Where Condition</a></button>

                               
             
                                      </div>--%>


            <div class="row" style="width: 100%;">
                <div class="col-md-12">
                    <div class="card">
                        <ul id="myTab" class="nav nav-tabs">
                            <li id="liDJ"><a id="tabDJ" onclick="return fnSetTabs('1');" style="font-weight: bold;">Define Join </a></li>
                            <li id="liDWC"><a id="tabDWC" onclick="return fnSetTabs('2');" style="font-weight: bold;">Define Where Condition</a></li>
                        </ul>




                        <%--                         <asp:UpdatePanel runat="server" RenderMode="Inline">
                            <ContentTemplate> --%>

                        <div id="divDJoin" class="tab-pane active" runat="server" style="display: none">
                            <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divDEFJOIN','myImgDJoin');return false;">

                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblRulSrch" Text="Define Join" Font-Size="19px" runat="server" />
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="myImgDJoin" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>

                            </div>

                            <div id="divDEFJOIN" runat="server" style="padding: 30px;" class="panel-body" width="96%">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblIntGid" Text="KPI Code" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtIntGid" runat="server" CssClass="form-control" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblST" Text="Join ID" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">

                                        <asp:TextBox ID="txtJId" runat="server" CssClass="form-control" TabIndex="1" Enabled="false"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblSyn1" Text="Source Table 1" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSynm1" runat="server" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblSyn2" Text="Source Table 2" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSynm2" runat="server" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label4" Text="Is-Primary Join" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlPrmJnt" runat="server" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblJointType" Text="Join Type" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlJoinType" runat="server" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblDJEffFrom" Text="Effective From" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDJEffFrom" onclick="callEffectiveDate()" Enabled="false"
                                                    placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblDJEffTo" Text="Cease Date" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDJEffTo" onclick="callEffectiveDate()" Enabled="false"
                                                    placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblDJStatus" Text="Status" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlDJStatus" runat="server" CssClass="form-control" Enabled="false"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>



                                <center>
                      <div id="divsyncrete" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" >
                                <asp:UpdatePanel runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnDEFJOINSave" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnDEFJOINSave_Click" style="display:inline-block;"  >
                                   <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Save
                                 </asp:LinkButton>

                                   <asp:LinkButton ID="btnClr" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnClr_Click">
                                     <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                   </asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDEFJOINUpd" runat="server" CssClass="btn btn-sample" style="display:none;"  TabIndex="17"  OnClick="lnkbtnDEFJOINUpd_Click"
                                >
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Update
                            </asp:LinkButton>

                                <asp:LinkButton ID="btnCancl" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnCancl_Click" >
                                     <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                                   </asp:LinkButton>

                                </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                           
                        </div>
                      </center>
                            </div>
                            <br />
                            <center>
                       <div id="divGRIDDefJoin" runat="server" style="width: 97%;" >

                       <asp:updatepanel runat="server">
                        <contenttemplate>
                            <asp:GridView ID="gridDefJoin" runat="server" AutoGenerateColumns="false" Width="100%"
                            PageSize="10" AllowSorting="True" AllowPaging="true" OnSorting="gridDefJoin_Sorting" 
                                    CssClass="footable" OnRowDataBound="gridDefJoin_RowDataBound" ShowHeader="true">


                            <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Join ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="JN_ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJN_ID" Text='<%# Bind("JN_ID") %>' runat="server" />
                                         <asp:HiddenField ID="hdnDefSEQNO" runat="server" Value='<%# Eval("SEQ_NO") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SRC Table 1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="SRC_TABLE_1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTABLE_1" Text='<%# Bind("SRC_TABLE_1") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="clsCenter"/>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SRC Table 2" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="TABLE_2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTABLE_2" Text='<%# Bind("SRC_TABLE_2") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Is Primary" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="IS_PRIMARY_JOIN_DESC">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIS_PRIMARY_JOIN" Text='<%# Bind("IS_PRIMARY_JOIN_DESC") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Join Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="JN_TYP_DESC">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJN_TYP" Text='<%# Bind("JN_TYP_DESC") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="StatusDesc">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_GridJSts" Text='<%# Bind("StatusDesc") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="EFF_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldef_eff" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                              
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="clsCenter" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="CSE_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldef_cse" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                             
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="clsCenter" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>



                                <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGRIDDefJOINEdit"  runat="server" Text="Define Join Column" OnClick="lnkGRIDDefJOINEdit_Click"></asp:LinkButton>
                                                 <%-- <asp:LinkButton ID="lnkGridDefJoinEdit" runat="server" Text="EDIT" OnClick="lnkGridDefJoinEdit_Click"></asp:LinkButton>
                                                 <asp:LinkButton ID="lnkGridDefJoinDel" runat="server" Text="DELETE" OnClick="lnkGridDefJoinDel_Click"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                 </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkGRIDJOINEdit" runat="server" Text="Edit" OnClick="lnkGridJoinEdit_Click" ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkGRIDDefJOINDel" runat="server" Text="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkGridDefJoinDel_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        </contenttemplate>
                       </asp:updatepanel>


                         <div class="pagination" style="padding: 10px;">
                           
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnGrdDEFJOINPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnGrdDEFJOINPrev_Click" />
                                                    <asp:TextBox runat="server" ID="TextBox3" Text="1" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnGrdDEFJOINNext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnGrdDEFJOINNext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            
                        </div>
                      </div>
               </center>

                            <br />
                            <div id="divDefColJoin" runat="server" style="display: none;">
                                <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRulsrch','myImgcol');return false;">

                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <asp:Label ID="Label5" Text="Define Column for Join" Font-Size="19px" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="myImgcol" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>

                                </div>

                                <div id="div5" runat="server" style="padding: 30px;" class="panel-body">
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblSVACol" Text="Set value as column" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButtonList ID="rdbSVACol" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbSVACol_SelectedIndexChanged">
                                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="NO" Value="0" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblSValCol" Text="Set value column" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSValCol" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCFJSynmCol" Text="Table Column" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDCFJSynmCol" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCFJSOpertr" Text="Operator" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDCFJSOpertr" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCFJColVal" Text="Column Value" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDCFJColVal" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label10" Text="Table 1 Column" runat="server" CssClass="control-label" />
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSyn1Col" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label11" Text="Table 2 Column" runat="server" CssClass="control-label" />
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSyn2Col" runat="server" CssClass="form-control"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>


                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="Col1MapDT" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="Col1MapDT_Click">
                                   <span class="glyphicon glyphicon-hand-up" style="color: White;"></span> Convert Column 1 Datatype
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="Col2MapDT" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="Col2MapDT_Click">
                                   <span class="glyphicon glyphicon-hand-up" style="color: White;"></span> Convert Column 2 Datatype
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>

                                    <div class="row" style="margin-bottom: 5px;">

                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label9" Text="Join ID" runat="server" CssClass="control-label" />
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="TextBoxColJoinId" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label8" Text="KPI Code" runat="server" CssClass="control-label" />
                                            <asp:Label Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="TextBoxColKpi" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCJoinEffFrm" Text="Effective From" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDCJoinEffFrm" onclick="callEffectiveDate()" Enabled="false"
                                                        placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCJoinEffTo" Text="Cease Date" runat="server" CssClass="control-label" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtDCJoinEffTo" onclick="callEffectiveDate()" Enabled="false"
                                                        placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblDCJoinStatus" Text="Status" runat="server" CssClass="control-label" Enabled="false" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDCJoinStatus" runat="server" CssClass="form-control" Enabled="false"
                                                        TabIndex="4">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <center>
                     <div id="div7" runat="server" class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" >
                             <asp:LinkButton ID="lnkdefcolupd" runat="server" CssClass="btn btn-sample" style="display:none;"  TabIndex="17" OnClick="lnkdefcolupd_Click">
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Update
                            </asp:LinkButton>

                            <asp:LinkButton ID="lnkDefColJoinbtn" runat="server" style="display:inline-block;" CssClass="btn btn-sample" TabIndex="17" OnClick="lnkDefColJoinbtn_Click1">
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Add
                            </asp:LinkButton>

                            <asp:LinkButton ID="LinkBtnColclr" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkBtnColclr_Click">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                            </asp:LinkButton>

                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton3_Click">
                                <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                            </asp:LinkButton>
                        </div>
                     </div>

                          <asp:HiddenField ID="hdnColSEQ" runat="server"/>
                        <asp:Label ID="lblHdSql"  runat="server" CssClass="control-label" Visible="false" />
                        <br />

                     <div id="divGRIDDEFCOLJOIN" runat="server" style="width: 97%;" >
                       
                               
                             <asp:GridView ID="GridDefCol" runat="server" AutoGenerateColumns="false" Width="100%"
                            PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnSorting="GridDefCol_Sorting" 
                            OnRowDataBound="GridDefCol_RowDataBound" ShowHeader="true">
                            <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Join ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="JN_ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDEFCOLJOINJN_ID" Text='<%# Bind("JN_ID") %>' runat="server" />

                                        
                                         <asp:HiddenField ID="hdnColSEQNO" runat="server" Value='<%# Eval("SEQ_NO") %>' />

                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table Col 1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="TBL_1_COL">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJDEFCOLJOINTBL_1_COL" Text='<%# Bind("TBL_1_COL_desc") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Table Col 2" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="TBL_2_COL">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJDEFCOLJOINTBL_2_COL" Text='<%# Bind("TBL_2_COL_desc") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="StatusDesc">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJDEFCOLJOININTGRTN_ID" Text='<%# Bind("StatusDesc") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" CssClass="clsCenter"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="EFF_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcoleff" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                               <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="CSE_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcse" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                               <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDEFCOLJOINEdit"  runat="server" Text="Edit" OnClick="lnkDEFCOLJOINEdit_Click" ></asp:LinkButton>
                                             
                                            </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDEFCOLJOIN" runat="server" Text="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkDEFCOLJOINDel_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                           <%-- </contenttemplate>
                        </asp:updatepanel>--%>
                        <div class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnGrdDEFWHERECondPrev" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnGrdDEFWHERECondPrev_Click" />
                                                    <asp:TextBox runat="server" ID="txtPageDEFWCond" Text="1" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnGrdDEFWHERECondNext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnGrdDEFWHERECondNext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                     </div>
                        
                        </center>
                            </div>

                        </div>

                        <div id="DivWhr" runat="server" style="display: none">

                            <div id="div8" runat="server" style="padding: 30px;" class="panel-body" width="96%">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label6" Text="Source Table" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlST" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    TabIndex="4" OnSelectedIndexChanged="ddlST_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="ColName" Text="Col Name" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCol" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label12" Text="Operator" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlOp" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label13" Text="Col Value" runat="server" CssClass="control-label" />
                                        <asp:Label Text="*" runat="server" Style="color: Red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TextBoxColVal" runat="server" CssClass="form-control" TabIndex="1" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblGrEffFrm" Text="Effective From" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtWhrEffFrm" onclick="callEffectiveDate()" Enabled="false"
                                                    placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblGrCs" Text="Cease Date" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtWhrCseDt" onclick="callEffectiveDate()" Enabled="false"
                                                    placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblGrsts" Text="Status" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="true" CssClass="form-control" Enabled="false"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>


                                </div>
                                <%--  <center>--%>

                                <div id="divWhrBtn" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>

                                                <asp:LinkButton ID="lnkWhrUPD" runat="server" CssClass="btn btn-sample" Style="display: none;" TabIndex="17" OnClick="lnkWhrUPD_Click">
                                <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Update
                                                </asp:LinkButton>


                                                <asp:LinkButton ID="LinkButton1" Style="display: inline-block;" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton1_Click">
                                   <span class="glyphicon glyphicon-floppy-save" style="color: White;"></span> Save
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton4_Click">
                                     <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="LinkButton5_Click">
                                     <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                    </div>

                                </div>
                                <%--  </center>--%>
                                <br />
                            </div>
                            <center>
                                             <div id="divWhrGrid" runat="server" style="width: 97%;" >

                       <asp:updatepanel runat="server">
                        <contenttemplate>
                            <asp:GridView ID="GridViewWhr" runat="server" AutoGenerateColumns="false" Width="100%"
                            PageSize="10" AllowSorting="True" AllowPaging="true" OnSorting="gridDefJoin_Sorting" 
                                    CssClass="footable" OnRowDataBound="gridDefJoin_RowDataBound" ShowHeader="true">


                            <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Table Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="SRC_TBL_NAME_desc">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_GrST" Text='<%# Bind("SRC_TBL_NAME_desc") %>' runat="server" />
                                        
                                         <asp:HiddenField ID="hdnSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Col-Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="COL_NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrColName" Text='<%# Bind("COL_DESC") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="clsCenter"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Operator" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="OPRTR">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrOp" Text='<%# Bind("OPRTR") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="COL-VAL" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="COL_VAL">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrColVal" Text='<%# Bind("COL_VAL") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center"  Width="20%"/>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="EFF_DTIM" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblwheeff" runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                               <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center"  />
                                            <HeaderStyle HorizontalAlign="Center"  />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center"
                                            SortExpression="CSE_DTIM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblwhrcse" runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                               <%-- <asp:HiddenField ID="hdntbldesc" runat="server" Value='<%# Bind("TBL_DESC")%>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGRIDWhrEdit"  runat="server" Text="Edit" onclick="lnkGRIDWhrEdit_Click"></asp:LinkButton>
                                               <%--  <asp:LinkButton ID="lnkGRIDWhrDel" runat="server" Text="DELETE" OnClick="lnkGRIDWhrDel_Click"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkGRIDWhrDel" runat="server" Text="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to Delete?');" OnClick="lnkGRIDWhrDel_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </contenttemplate>
                       </asp:updatepanel>

                          <div class="pagination" style="padding: 10px;" align="center">
                           
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnPrvWhr" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnPrvWhr_Click" />
                                                    <asp:TextBox runat="server" ID="TextBox4" Text="1" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnNctWhr" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnNctWhr_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                           
                        </div>
</div>
                                                  </center>


                        </div>

                        <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>



        </div>

    </div>

    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:Button ID="BtnToolTip" runat="server" Text="BtnToolTip" Style="display: none"
        OnClick="BtnToolTip_Click" />
    <asp:Button ID="BtnToolTip2" runat="server" Text="BtnToolTip" Style="display: none"
        OnClick="BtnToolTip2_Click" />
    <asp:Button ID="BtnGrp" runat="server" Text="BtnToolTip" Style="display: none"
        OnClick="BtnGrp_Click" />


    <asp:Panel runat="server" Height="400px" Width="900px" ID="Panel2" display="none"
        Style="text-align: center; padding: 8px; margin-left: 200px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd3" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>

   <%--   <asp:Panel runat="server" Height="430px" Width="1090px" ID="Panel2" display="none" Style="text-align: center; top: 59px !important; padding: 5px; left: -2px !important; margin-left: -8px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd3" scrolling="yes" width="100%" frameborder="0" display="none" style="height: 100%;"></iframe>
    </asp:Panel>--%>

    <asp:Label runat="server" ID="Label14" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw2" BehaviorID="mdlVwBID2" DropShadow="false" X="15" Y="30"
        TargetControlID="Label14" PopupControlID="Panel2" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

     
    <asp:HiddenField ID="HdnColVal" runat="server" />


    <asp:HiddenField ID="hdnMapDataType" runat="server" />
    <asp:HiddenField ID="hdnMapDataType1" runat="server" />
    <asp:HiddenField ID="hdnMapDataType2" runat="server" />
    <asp:HiddenField ID="hdnCol1DT" runat="server" />
    <asp:HiddenField ID="hdnCol2DT" runat="server" />
    <asp:HiddenField ID="hdnTabIndex" runat="server" />
    <asp:HiddenField ID="hdnKPIMapCode" runat="server" />
   

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CmpSetupSimu.aspx.cs" Inherits="Application_Isys_Saim_CmpSetupSimu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--  <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
 
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
   
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
--%>

     <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />

    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />




    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%-- <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>--%>
    <script type="text/javascript">
        debugger;
        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");
        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <%-- Added By bhaurao--%>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/
        
        .dataTable
        {
            width: 100% !important;
            clear: both;
            margin-top: 5px;
        }
        
        .dataTables_filter label
        {
            line-height: 32px;
        }
        
        .dataTable .row-details
        {
            margin-top: 3px;
            display: inline-block;
            cursor: pointer;
            width: 14px;
            height: 14px;
        }
        
        .dataTable .row-details.row-details-close
        {
            background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
        }
        
        .dataTable .row-details.row-details-open
        {
            background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px;
        }
        
        .dataTable .details
        {
            background-color: #eee;
        }
        
        .dataTable .details td, .dataTable .details th
        {
            padding: 4px;
            background: none;
            border: 0;
            border: 1px solid #ddd;
        }
        
        .dataTable .details tr:hover td, .dataTable .details tr:hover th
        {
            background: none;
        }
        
        .dataTable .details tr:nth-child(odd) td, .dataTable .details tr:nth-child(odd) th
        {
            background-color: #eee;
        }
        
        .dataTable .details tr:nth-child(even) td, .dataTable .details tr:nth-child(even) th
        {
            background-color: #eee;
        }
        
        .dataTable > thead > tr > th.sorting, .dataTable > thead > tr > th.sorting_asc, .dataTable > thead > tr > th.sorting_desc
        {
            padding-right: 18px;
        }
        
        .dataTable .table-checkbox
        {
            width: 8px !important;
        }
        
        @media (max-width: 768px)
        {
            .dataTables_wrapper .dataTables_length .form-control, .dataTables_wrapper .dataTables_filter .form-control
            {
                display: inline-block;
            }
        
            .dataTables_wrapper .dataTables_info
            {
                top: 17px;
            }
        
            .dataTables_wrapper .dataTables_paginate
            {
                margin-top: -15px;
            }
        }
        
        @media (max-width: 480px)
        {
            .dataTables_wrapper .dataTables_filter .form-control
            {
                width: 175px !important;
            }
        
            .dataTables_wrapper .dataTables_paginate
            {
                float: left;
                margin-top: 20px;
            }
        }
        
        .dataTables_processing
        {
            position: fixed;
            top: 50%;
            left: 50%;
            min-width: 125px;
            margin-left: 0;
            padding: 7px;
            text-align: center;
            color: #333;
            font-size: 13px;
            border: 1px solid #ddd;
            background-color: #eee;
            vertical-align: middle;
            -webkit-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            -moz-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
            box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
        }
        
        .dataTables_processing span
        {
            line-height: 15px;
            vertical-align: middle;
        }
        
        .dataTables_empty
        {
            text-align: center;
        }
        .ajax__calendar
        {
            position: relative;
            z-index: 9999;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
    </style>
    <script type="text/javascript">



        function FuncheckDateWithiBusinessYear(flag) {
            debugger;
            if (flag != "Y") {
                alert("Invalid date selection")
                document.getElementById("<%= txtEffDtFrm.ClientID %>").value = "";
            }
        }

        function CheckDateWithinDate() {
            debugger;
            document.getElementById('<%=Button1.ClientID%>').click();
    }


    function PopulateCalender() {
        //minDate:new Date()
        $("#<%= txtEffDtFrm.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });

        }
        function onKeySignin() {
            if (window.event.keyCode == 13) {
                document.getElementById('<%=btnok.ClientID%>').focus();
                document.getElementById('<%=btnok.ClientID%>').click();
            }
        }

        document.attachEvent("onkeydown", onKeySignin);



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
        
    </script>
    <script language="javascript" type="text/javascript">
        function onOk() {
            form1.submit();
        }
        function checkDate() {
            debugger;

            var fromDate = $('#<%= txtEffDtFrm.ClientID  %>').val();
            var toDate = $('#<%= txtEffDtTo.ClientID  %>').val();
             var strcontent = "ctl00_ContentPlaceHolder1_";
             // alert(fromDate);
             //alert(toDate);
             debugger;
             if (fromDate != "" && toDate != "") {
                 if (!checkDateIsGreaterThanToday(fromDate, toDate)) {

                     alert("Effective  From Date should not be greater than Effective To Date.");
                     document.getElementById("<%= txtEffDtFrm.ClientID %>").value = "";

                    return false;

                }
                else {

                    CheckDateWithinDate();
                }
            }
            else {
                alert("Please Select  Date");
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




        function funPopUpCycle(cmpcode, accycle, cyctype, yrtyp, effdatefrom, effdateto) {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "Date_Cycle_Defination.aspx?cmpcode=" + cmpcode + "&accyc=" + accycle
            + "&cyctype=" + cyctype + "&yrtyp=" + yrtyp + "&effdatefrom=" + effdatefrom + "&effdateto=" + effdateto + "&mdlpopup=mdlViewBID";
        }
        //        function funPopUpCycle() {
        //            //////alert('akshay');
        //            var strContent = "ctl00_ContentPlaceHolder1_";
        //            $find("mdlViewBID").show();
        //            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "Date_Cycle_Defination.aspx?mdlpopup=mdlViewBID";
        //        }


        function funPopUp(cmpcode, cmpdesc, pcntstcd, flag) {
            debugger;
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntst.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc
            + "&pcntstcd=" + pcntstcd + "&flag=" + flag + "&mdlpopup=mdlViewBID";
        }

        function funPopUpSub(cmpcode, cmpdesc, pcntstcd, flag, bizsrc, chncls, memtype, memcode, depcode) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntst.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc
            + "&pcntstcd=" + pcntstcd + "&flag=" + flag + "&bizsrc=" + bizsrc + "&chncls=" + chncls + "&memtype=" + memtype + "&mdlpopup=mdlViewBID";
        }

        function funPopUpMemtype(cmpcode, cmpdesc, pcntstcd, flag, bizsrc, chncls, memtype) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntstMem.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc
            + "&pcntstcd=" + pcntstcd + "&flag=" + flag + "&bizsrc=" + bizsrc + "&chncls=" + chncls + "&memtype=" + memtype + "&mdlpopup=mdlViewBID";
        }
        //Added by Prity
        function funPopUpSetRule(cmpcode, cmpdesc, pcntstcd, flag, bizsrc, chncls, memtype) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntstSetRule.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc
            + "&pcntstcd=" + pcntstcd + "&flag=" + flag + "&bizsrc=" + bizsrc + "&chncls=" + chncls + "&memtype=" + memtype + "&mdlpopup=mdlViewBID";
        }
        //Ended by prity

        function funPopUpMemtypeNew(cmpcode, cmpdesc, pcntstcd, flag, bizsrc, chncls, memtype, Depcode, memcode) {

            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntstNew.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc
            + "&pcntstcd=" + pcntstcd + "&flag=" + flag + "&bizsrc=" + bizsrc + "&chncls=" + chncls + "&memtype=" + memtype + "&depcode=" + Depcode + "&memcode=" + memcode + "&mdlpopup=mdlViewBID";

        }

        function doCancel() {
            $find("mdlViewBID").hide();
        }

        function ValidTwoDateWB(fromDT, toDT) {
            // 
            try {
                fromDT = reSetDateInFormat1(fromDT);
                toDT = reSetDateInFormat1(toDT);
                //calculate Total time for one day
                var errFlag = "";
                var one_day = 1000 * 60 * 60 * 24;
                //get entered date in array
                var myDatePartFrom = fromDT.split("/");
                var myDatePartTo = toDT.split("/");
                var cmpDate1 = new Date(myDatePartFrom[2], (myDatePartFrom[1] - 1), myDatePartFrom[0]);
                var cmpDate2 = new Date(myDatePartTo[2], (myDatePartTo[1] - 1), myDatePartTo[0]);
                var month1 = myDatePartFrom[1] - 1;
                var month2 = myDatePartTo[1] - 1;

                //Calculate difference between the two dates, and convert to days               
                var dateDiff = Math.ceil((cmpDate2.getTime() - cmpDate1.getTime()) / (one_day));
                if (dateDiff < 0) {
                    errFlag = "0";
                }
                else if (dateDiff > 31) {
                    errFlag = "1";
                }

                return errFlag;


            }
            catch (err) {
                MainErrorFlag = 1;
                ShowError(err.description);
            }
        }


        function validate() {
            debugger;
            var strcontent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strcontent + "txtCompDesc1") != null) {
                if (document.getElementById(strcontent + "txtCompDesc1").value == "") {
                    alert("Please Enter Compensation Description");
                    document.getElementById(strcontent + "txtCompDesc1").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlAccCyc") != null) {
                if (document.getElementById(strcontent + "ddlAccCyc").value == "") {
                    alert("Please Select Accumulation Cycle");
                    document.getElementById(strcontent + "ddlAccCyc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlAccYear") != null) {
                if (document.getElementById(strcontent + "ddlAccYear").value == "") {
                    alert("Please Select Accumulation Year");
                    document.getElementById(strcontent + "ddlAccYear").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlCompType") != null) {
                if (document.getElementById(strcontent + "ddlCompType").value == "") {
                    alert("Please Select Compensation Type");
                    document.getElementById(strcontent + "ddlCompType").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlAccrCyc") != null) {
                if (document.getElementById(strcontent + "ddlAccrCyc").value == "") {
                    alert("Please Select Accrual Cycle");
                    document.getElementById(strcontent + "ddlAccrCyc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRwdRlsCyc") != null) {
                if (document.getElementById(strcontent + "ddlRwdRlsCyc").value == "") {
                    alert("Please Select Reward Release Cycle");
                    document.getElementById(strcontent + "ddlRwdRlsCyc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlBusiYear") != null) {
                if (document.getElementById(strcontent + "ddlBusiYear").value == "") {
                    alert("Please Select Business Year");
                    document.getElementById(strcontent + "ddlBusiYear").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVer") != null) {
                if (document.getElementById(strcontent + "txtVer").value == "") {
                    alert("Please Enter Version No.");
                    document.getElementById(strcontent + "txtVer").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtEffDtFrm") != null) {
                if (document.getElementById(strcontent + "txtEffDtFrm").value == "") {
                    alert("Please Enter Effective From");
                    document.getElementById(strcontent + "txtEffDtFrm").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtEffDtTo") != null) {
                if (document.getElementById(strcontent + "txtEffDtTo").value == "") {
                    alert("Please Enter Effective To");
                    document.getElementById(strcontent + "txtEffDtTo").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVerEffFrm") != null) {
                if (document.getElementById(strcontent + "txtVerEffFrm").value == "") {
                    alert("Please Enter Version Effective From");
                    document.getElementById(strcontent + "txtVerEffFrm").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVerEffTo") != null) {
                if (document.getElementById(strcontent + "txtVerEffTo").value == "") {
                    alert("Please Enter Version Effective To");
                    document.getElementById(strcontent + "txtVerEffTo").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlCmptnRule") != null) {
                if (document.getElementById(strcontent + "ddlCmptnRule").value == "") {
                    alert("Please Enter Set Computation Rule");
                    document.getElementById(strcontent + "ddlCmptnRule").focus();
                    return false;
                }
            }


           <%-- var isChecked = false;
            var rblSetTrgRul = document.getElementById("<%=rblSetTrgRul.ClientID%>");
            var radioButtons = rblSetTrgRul.getElementsByTagName("input");
            for (var i = 0; i < radioButtons.length; i++) {
                if (radioButtons[i].checked) {
                    isChecked = true;
                    break;
                }
            }

            if (!isChecked) {
                alert("Please Select Set Target Rule");
            }

            return isChecked;--%>
        }

     function ShowReqDtl1(divName, btnName) {
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
    </script>
    <asp:UpdatePanel ID="UPD1" runat="server">
        <ContentTemplate>
            <center>
                <div class="page-container" style="margin-top: 0px;">
                <div id="divcmphdrcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" Font-Size="19px" />
                                  
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtCompCode" runat="server" CssClass="form-control" TabIndex="1"
                                    Enabled="false" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblCompDesc_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtCompDesc1" runat="server" CssClass="form-control" TabIndex="2"
                                    MaxLength="40" onChange="javascript:this.value=this.value.toUpperCase();" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" !@#$%*()_:-+"
                                    FilterMode="ValidChars" TargetControlID="txtCompDesc1">
                                </ajaxToolkit:FilteredTextBoxExtender>


                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars=",#$@%^!*()&''%^~`_:-+"
                                                            FilterMode="InvalidChars" TargetControlID="txtCompDesc1" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                            
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label" />
                                <%-- <asp:Label ID="lblComDesc2_s" Text="*" runat="server" ForeColor="red" />--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtCompDesc2" runat="server" CssClass="form-control" TabIndex="3"
                                    MaxLength="40" onChange="javascript:this.value=this.value.toUpperCase();" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" InvalidChars=",#$@%^!*()&''%^~`_:-+"
                                                            FilterMode="InvalidChars" TargetControlID="txtCompDesc2" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                            
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblAccCyc_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4" OnSelectedIndexChanged="ddlAccCyc_SelectedIndexChanged" Enabled="true" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccYear" Text="Accumulation Year" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblAccYear_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccYear" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="5" OnSelectedIndexChanged="ddlAccYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label " />
                                <asp:Label ID="lblCompTyp_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCompType" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="6" OnSelectedIndexChanged="ddlCompType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label Text="Accrual Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="Accrual_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccrCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="7" OnSelectedIndexChanged="ddlAccrCyc_SelectedIndexChanged"  Enabled="true">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdRlsCyc" Text="Rewards Release Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblRwdRlsCyc_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRwdRlsCyc" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="8" OnSelectedIndexChanged="ddlRwdRlsCyc_SelectedIndexChanged" Enabled="false">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                       <%-- added  by ajay sawant--%>
                           <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRewardComputation" Text="Reward Computation Cycle" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label18" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRewardComputation" runat="server" CssClass="form-control" AutoPostBack="true"
                                            TabIndex="9" Enabled="false" >
                                          
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--<asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control col-md-5" TabIndex="7" />--%>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStatus" Text="Status" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblstatus_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="19" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblFinYr" Text="Business Year" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblFinYr_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBusiYear" runat="server" CssClass="form-control" AutoPostBack="true"
                                            TabIndex="9" OnSelectedIndexChanged="ddlBusiYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--<asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control col-md-5" TabIndex="7" />--%>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label" />
                                <asp:Label ID="bllver_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" TabIndex="10" MaxLength="10" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="txtVer">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" style="white-space: nowrap;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtEffDtFrm" runat="server" CssClass="form-control" onmousedown="PopulateCalender()"
                                            onmouseup="PopulateCalender()"
                                                  
                                     placeholder="DD/MM/YYYY" />	<%--  Enabled="false" --%>

                                          <asp:LinkButton  ID="Button1" runat="server" style="display:none;" Text="Button" OnClick="Button1_Click"></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtEffDtTo" runat="server" CssClass="form-control" 
                                            AutoPostBack="true" />	<%--  Enabled="false" --%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVerEffFrm" Text="Ver. Eff. From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtVerEffFrm" runat="server" CssClass="form-control" Enabled="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVerEffTo" Text="Ver. Eff. To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtVerEffTo" runat="server" CssClass="form-control" Enabled="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStTrgRul" Text="Set Target Rule" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblStTrgRul_s" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3" style="margin-right:0px;" >
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rblSetTrgRul" runat="server" AutoPostBack="true" 

                                            RepeatDirection="Vertical" TabIndex="16"  style="text-align: left;padding:2px;">
                                            <asp:ListItem Text="Set full period target and split by cycle" Value="1001" Enabled="false"  />
                                            <asp:ListItem Text="Set target by cycle" Value="1002" Selected="True" />
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label15" Text="Set Computation Rule" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label16" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3"  style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCmptnRule" runat="server" AutoPostBack="true" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                          
                        </div>
                        <div id="tbladdcmpst" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <%--commented by ajay sawant--%>
                                <%--<asp:LinkButton ID="btncycle" runat="server" CssClass="btn btn-sample" OnClick="btncycle_Click">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Cycle
                                </asp:LinkButton>--%>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" TabIndex="17"
                                    OnClientClick="return validate();" OnClick="btnSave_Click">
                                                    <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclCmp" runat="server" CssClass="btn btn-sample" TabIndex="18"
                                    OnClick="btnCnclCmp_Click">
                                                    <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divcmphdrview" runat="server" class="panel" visible="false" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','Img5');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label5" Text="Compensation Details" Font-Size="19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img5" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div3" runat="server" class="panel-body" style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label6" Text="Compensation Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                                    TabIndex="1"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label7" Text="Compensation Description" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new"
                                    TabIndex="2"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label8" Text="Compensation Description" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompDesc2Val" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label9" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblAccCycVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccYr" Text="Accumulation Year" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblAccYrVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label10" Text="Compensation Type" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompTypVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccrCycle" Text="Accural Cycle" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblAccrCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblReleaseCycle" Text="Release Cycle" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblReleaseCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label11" Text="Business Year" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblBusYr" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label12" Text="Version" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblVersion" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label13" Text="Effective From" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblEffDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label14" Text="Effective To" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblEffDtToVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVerDtFrm" Text="Ver. Eff. From" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblVerDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVerDtTo" Text="Ver. Eff. To" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblVerDtToVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStat" Text="Status" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblStatVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSetTrgRul" Text="Set Target Rule" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblSetTrgRulVal" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div id="divcntstcollapse" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div7" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcntst','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label1" Text="Contestant Details" runat="server" Font-Size="19px" Style="padding-left: 5px;" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcntst" runat="server"  style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div style="margin-top: 0.9%;margin-bottom: 0.9%" class="table-scrollable">
                                    <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnRowDataBound="dgCntst_RowDataBound"
                                        OnSorting="dgCntst_Sorting">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                    <div id="divChild" runat="server" style="display: none; margin: 0px 0 !important;"
                                                        class="table-scrollable">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="dgSubemp" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="10" AllowPaging="true" CssClass="footable" DataKeyNames="MemCode">
                                                                    <%--llowSorting="True" --%>
                                                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <HeaderStyle CssClass="gridview th" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                            runat="server" />
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                                                            <ItemTemplate>
                                                                                <%--<asp:LinkButton ID="lnkSubCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                                                    OnClick="lnkSubCnstCode_Click"> </asp:LinkButton>--%>
                                                                                <asp:Label ID="lnkSubCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("MemCode")%>' />
                                                                                <%--<asp:Label ID="lblPCntst" runat="server" Text='<%# Bind("PARENT_CNTST_CODE")%>' />--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Name" SortExpression="LegalName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("LegalName")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Agent Code" SortExpression="ClientCode">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("ClientCode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date Of Joining" SortExpression="DateOfJoining">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDateOfJoining" runat="server" Text='<%# Bind("DateOfJoining")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Status" SortExpression="MemStatus">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblmemstatus" runat="server" Text='<%# Bind("MemStatus")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkSubCntstDel" runat="server" Text="Delete" OnClick="lnkSubCntstDel_Click"
                                                                                    OnClientClick="return confirm('Are you sure you want to Delete?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <br />
                                                                <asp:GridView ID="dgSubCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="10" AllowPaging="true" CssClass="footable" DataKeyNames="CNTSTNT_CODE"
                                                                    OnRowDataBound="dgSubCntst_RowDataBound">
                                                                    <%--llowSorting="True" --%>
                                                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <HeaderStyle CssClass="gridview th" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                            runat="server" />
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <%--Bhaurao 02122017--%>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                                                <div id="divChild" runat="server" style="display: none; margin: 0px 0 !important;"
                                                                                    class="table-scrollable">
                                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:GridView ID="dgSubCntstMembers" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                                                PageSize="10" AllowPaging="true" CssClass="footable" DataKeyNames="CNTSTNT_CODE">
                                                                                                <%--llowSorting="True" --%>
                                                                                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                                                                                <PagerStyle CssClass="disablepage" />
                                                                                                <HeaderStyle CssClass="gridview th" />
                                                                                                <EmptyDataTemplate>
                                                                                                    <asp:Label ID="Label2" Text="No contestants members have been defined" ForeColor="Red"
                                                                                                        CssClass="control-label" runat="server" />
                                                                                                </EmptyDataTemplate>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                                                                                        <ItemTemplate>
                                                                                                            <%--<asp:LinkButton ID="lnkSubCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                                                                                OnClick="lnkSubCnstCode_Click"> </asp:LinkButton>--%>
                                                                                                            <asp:Label ID="lnkSubCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("MemCode")%>' />
                                                                                                            <%--<asp:Label ID="lblPCntst" runat="server" Text='<%# Bind("PARENT_CNTST_CODE")%>' />--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Member Name" SortExpression="LegalName">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("LegalName")%>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Agent Code" SortExpression="ClientCode">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("ClientCode")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Date Of Joining" SortExpression="DateOfJoining">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblDateOfJoining" runat="server" Text='<%# Bind("DateOfJoining")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Member Status" SortExpression="MemStatus">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblmemstatus" runat="server" Text='<%# Bind("MemStatus")%>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Action">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkSubCntstDel" runat="server" Text="Delete" OnClick="lnkSubCntstDel_Click"
                                                                                                                OnClientClick="return confirm('Are you sure you want to Delete?');"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkSubCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                                                    OnClick="lnkSubCnstCode_Click"> </asp:LinkButton>
                                                                                <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Compensation Description" SortExpression="PARENT_CNTST_CODE">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>' />
                                                                                <%--<asp:Label ID="lblPCntst" runat="server" Text='<%# Bind("PARENT_CNTST_CODE")%>' />--%>
                                                                                <asp:HiddenField ID="hdnPCntst" runat="server" Value='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                                                <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                                                                <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                                                                <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- ---Added by mrunal on 19/08/17-----------%>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkAddMemberSubCntst" runat="server" Text="Add Members" OnClick="lnkAddMemberSubCntst_Click"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- ---Added by mrunal on 19/08/17-----------%>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkSubCntstDel" runat="server" Text="Delete" OnClick="lnkSubCntstDel_Click"
                                                                                    OnClientClick="return confirm('Are you sure you want to Delete?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                        OnClick="lnkCnstCode_Click"></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                                    <asp:HiddenField ID="hdnPCnstCode" runat="server" Value='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>' />
                                                    <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                                    <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want to Delete?');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAddSbCntst" runat="server" Text="Add Dependent Contestants"
                                                        OnClick="lnkAddSbCntst_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- ---Added by mrunal on 19/08/17-----------%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAddMembers" runat="server" Text="Add Members" OnClick="lnkAddMembers_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- ---Added by mrunal on 19/08/17-----------%>
                                            <%-- ---Added by Prity on 4/07/18-----------%>
                                           <%-- <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSetRule" runat="server" Text="Set Rule" OnClick="lnkSetRule_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%-- ---Ended by prity on 4/07/18-----------%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                      </ContentTemplate>
                                            </asp:UpdatePanel>                 
                                </div>
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                        <div id="divPage" visible="true" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                       
                        <div id="tbladdcntst" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddCntst" runat="server" CssClass="btn btn-sample" Enabled="true"
                                    OnClick="btnAddCntst_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclCntst" runat="server" CssClass="btn btn-sample" Enabled="true"
                                    Visible="false" OnClick="btnCnclCntst_Click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnSaveCntst" runat="server" CssClass="btn btn-sample" Visible="false"
                                    Enabled="true" OnClick="btnSaveCntst_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btncmp" runat="server" ClientIDMode="Static" Style="display: none;"
                                    OnClick="btncmp_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <%--ADDED BY KALYANI START--%>
                <div id="divC" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divok','Img2');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label4" Text="Compensation Status" runat="server" Font-Size="19px" Style="padding-left: 5px;" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divok" runat="server"  class="panel-body" align="left" style="display: block; margin-top: 0.9%;margin-bottom: 0.9%">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-12" style="text-align: left">
                                <asp:CheckBox ID="chkQual" runat="server" OnCheckedChanged="chkQual_CheckedChanged"
                                    AutoPostBack="True" />&nbsp;
                                <asp:Label ID="lblcheck" runat="server" Text=" Completed Compensation creation/modification click OK to submit for review"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div id="div1" runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblContestStatus" Text="Status" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStatusR" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4" OnSelectedIndexChanged="ddlStatusR_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblStatusRemark" runat="server" CssClass="control-label" Text="Approver Remark" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="50px" runat="server" CssClass="form-control"
                                            TabIndex="2" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="row" style="margin-top: 12px;">
                                <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btOK" runat="server" CssClass="btn btn-sample" Enabled="false"
                                        OnClick="btOK_Click">
                                                <span class="glyphicon glyphicon-save BtnGlyphicon"></span> OK
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--  <div id="divC" runat="server" style="width: 95%;" class="divBorder1" visible="false">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divok','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divok" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable" align="left">
                        <asp:CheckBox ID="chkQual" Text=" Completed contest creation, click OK to submit for review"
                            runat="server" OnCheckedChanged="chkQual_CheckedChanged" 
                            AutoPostBack="True" />
                        <table id="Table1" runat="server" class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btOK" Text="OK" runat="server" Width="100px" CssClass="btn blue"
                                        Enabled="false" OnClick="btOK_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divR" runat="server" style="width: 95%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div1','Img3','#Img3');" />
                            </td>
                        </tr>
                    </table>
                    <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblContestStatus" Text="Status" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 20%; white-space: nowrap;" class="col-md-7" colspan="">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlStatusR" runat="server" AutoPostBack="true" CssClass="form-control col-md-5" 
                                                TabIndex="4">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    &nbsp;</td>
                               
                            </tr>
                            <tr>
                                <td class="form-body align col-md-6" style="white-space: nowrap; width: 20%;">
                                    <asp:Label ID="lblStatusRemark" runat="server" 
                                        CssClass="control-label col-md-5" Text="Approver Remark" />
                                </td>
                                 <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="50px" runat="server" CssClass="form-control col-md-5"
                                        TabIndex="2" />
                                </td>
                                
                            </tr>
                            <table id="Table2" runat="server" class="form-actions fluid" style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                        <asp:Button ID="btSubmit" Text="Submit" runat="server" Width="100px" 
                                            CssClass="btn blue" onclick="btSubmit_Click1" />
                                    </td>
                                </tr>
                            </table>
                        </table>
                    </div>
                </div>--%>
                <br />
                <div id="divAudit" runat="server" class="panel" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                    <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAuditTrail','Img4');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                             <%--   <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label3" Text="Compensation  Audit Trail" runat="server" Font-Size="19px" Style="padding-left: 5px;" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img4" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divAuditTrail" runat="server"  style="display: block; margin-top: 0.9%; margin-bottom: 0.9%">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdAudit" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" OnSorting="gdAudit_Sorting">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                            runat="server" />
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Compensation Code" SortExpression="CMPNSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnACompCode" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Id" SortExpression="USERid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                                <asp:HiddenField ID="hdnAUserId" runat="server" Value='<%# Bind("USERid")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments Type" SortExpression="CmntType">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmntType" runat="server" Text='<%# Bind("CmntType")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" SortExpression="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                                <asp:HiddenField ID="hdnRemark" runat="server" Value='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Trail Date" SortExpression="CreateDtim">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnCreatedDtim" runat="server" Value='<%# Bind("CreateDtim")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Version No." SortExpression="Version">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblVersion" runat="server" Text='<%# Bind("Version")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <center>
                            <div id="div4" visible="true" runat="server" class="pagination">
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevaudit" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevaudit_Click" />
                                                    <asp:TextBox runat="server" ID="txtPageAudit" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextaudit" Text=">" CssClass="form-submit-button" runat="server"
                                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        OnClick="btnnextaudit_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </center>
                    </div>
                </div>
                <%--ADDED BY Bhaurao END--%>
            </center>
            <asp:Panel ID="pnl" runat="server" Width="500px" Height="250px" DefaultButton="btnok"
                CssClass="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    INFORMATION
                </div>
                <div class="modal-body" style="text-align: center">
                    <br />
                    <center>
                        <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                    <br />
                    <center>
                        <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                    <br />
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:LinkButton ID="btnok" runat="server" TabIndex="1" CssClass="btn btn-primary"
                        OnClick="btnAddRegistro_Click" OnClientClick="fnFocus();" BorderStyle="Solid"
                        Font-Bold="true">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class="glyphicon glyphicon-ok" style='color:White;'> &nbsp;</span> OK
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </asp:LinkButton>
                </div>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100" OnOkScript="onOk();">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="550px" Width="1000px" ID="pnlMdl" display="none"
        Style="text-align: center;">
        <iframe runat="server" id="ifrmMdlPopup" width="100%" frameborder="0" display="none"
            style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

</asp:Content>

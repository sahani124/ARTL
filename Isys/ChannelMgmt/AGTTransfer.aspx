<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="AGTTransfer.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AGTTransfer" %>

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
    
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
   <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
 <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <%--    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>--%>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script src="../../../Scripts/jQuery_1.X.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";

        function done() {

            window.location.href = "AGTSearch.aspx?ID=IN&Type=E";
            return false;
        }

        function funCheckUnCheck(objId) {
            ////debugger;
            var grd = document.getElementById("ctl00_ContentPlaceHolder1_gv_Dwnls");
            var rdoArray = grd.getElementsByTagName("input");
            for (i = 0; i <= rdoArray.length - 1; i++) {
                if (rdoArray[i].type == 'checkbox') {////
                    if (objId == "gv_Dwnls_ctl01_chkSelectAll") {
                        if (document.getElementById("gv_Dwnls_ctl01_chkSelectAll").checked == true) {
                            rdoArray[i].checked = true;
                        }
                        else {
                            rdoArray[i].checked = false;
                        }
                    }
                    else if (rdoArray[i].id == objId) {
                        if (rdoArray[i].checked == true) {
                            rdoArray[i].checked = true;
                        }
                        else {
                            rdoArray[i].checked = false;
                            document.getElementById("gv_Dwnls_ctl01_chkSelectAll").checked = false;
                        }
                    }
                }
            }

        }

        function ShowReqDtl1(divName, btnName) {
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

        function ShowReqDtl(divName, btnName) {
            //debugger;
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

//        function ShowReqDtl(divId, btnId) {
//            if (document.getElementById(divId).style.display == "block") {
//                document.getElementById(divId).style.display = "none";
//                document.getElementById(btnId).value = '+';
//            }
//            else {
//                document.getElementById(divId).style.display = "block";
//                document.getElementById(btnId).value = '-';
//            }
//        }

        function chkMgrCode() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr") == null)/// || document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr").value != "")
            {
                var DirectAgtCode = "";
            }
            else {
                var DirectAgtCode = document.getElementById("ctl00_ContentPlaceHolder1_hdnRptMgr").value;
            }
            ///modified by akshay on 13-02-14 end
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "ddlAgntType") != null) {
                if (document.getElementById(strContent + "ddlAgntType").selectedIndex == 0) {
                    alert(document.getElementById(strContent + "hdnID240").value);
                    document.getElementById(strContent + "ddlAgntType").focus();
                    return false;
                }
            }
            if (document.getElementById('<%= txtRptMgr.ClientID %>' != null)) {
                if (isBlank(document.getElementById('<%= txtRptMgr.ClientID %>').value)) {
                    return funShowAlert("ctl00_ContentPlaceHolder1_hdnID650", '<%= txtRptMgr.ClientID %>');
                }
            }
            if (!isBlank(DirectAgtCode) && !chkCodes(DirectAgtCode)) {
                //return funShowAlert("ctl00_ContentPlaceHolder1_hdnID530", "ctl00_ContentPlaceHolder1_txtRptMgr");
                return funShowAlert("ctl00_ContentPlaceHolder1_hdnID530", "ctl00_ContentPlaceHolder1_hdnRptMgr");
            }
            return true;
        }

        function fununtpopup(strvalue ,strbzsrc, strsbclass, strqstring, vcode, strIsAgent, strMgr) {

            ///var vcode = document.getElementById("vCode");
            if (vcode == "" || vcode == null) {
                vcode = document.getElementById('<%=hdnAgntType.ClientID %>').value
            }

            if (strvalue == "untcode") {
                $find("mdlViewBID").show();
                //            if (!chkMgrCode()) {
                //                return false;
                //            }
                var strAgentType;
                var element = document.getElementById('<%=ddllvlagttype.ClientID%>');
                if (typeof (element) != 'undefined' && element != null)
                { strAgentType = document.getElementById('<%=ddllvlagttype.ClientID%>').value; } //To handle the case when the User Selects the CH as the Agent Type -- Modified: Parag @ 02042014
                else
                { strAgentType = document.getElementById('<%=hdnPriMemTyp.ClientID%>').value; }

                if (strMgr != "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblNwUntcd.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + strbzsrc
                + "&ChnCls=" + strsbclass + "&agttype=" + vcode + "&hdn2=" + document.getElementById('<%=hdnNewUntAdr.ClientID %>').id
                + "&AgentType=" + document.getElementById('<%=ddllvlagttype.ClientID%>').value + "&MgrCode=" + strMgr
                + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').id + "&UntAdr=" + document.getElementById('<%=lblNewUntAddr.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=lblNwUntcd.ClientID%>').id + "&hdn1=" + document.getElementById('<%=hdnNwUntcd.ClientID %>').id
                + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent + "&mdlpopup=mdlViewBID";

                }
                if (strMgr == "") {
//                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').value
//                + "&CmpUntObj=" + document.getElementById('<%=lblNwUntcd.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + document.getElementById('<%=ddlamchnldesc.ClientID %>').value
//                + "&ChnCls=" + document.getElementById('<%=ddlamsubchnldesc.ClientID %>').value + "&trf=TRF" + "&agttype=" + vcode + "&hdn2=" + document.getElementById('<%=hdnNewUntAdr.ClientID %>').id
//                + "&AgentType=" + document.getElementById('<%=ddllvlagttype.ClientID%>').value + "&MgrCode=" + strMgr +"&UntAdr=" + document.getElementById('<%=lblNewUntAddr.ClientID %>').id
//                + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').id
//                + "&OutUntDesc=" + document.getElementById('<%=lblNwUntcd.ClientID%>').id + "&hdn1=" + document.getElementById('<%=hdnNwUntcd.ClientID %>').id
                    //                + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent + "&mdlpopup=mdlViewBID";
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblNwUntcd.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + strbzsrc +
                 "&ChnCls=" + strsbclass + "&trf=TRF" + "&agttype=" + vcode + "&hdn2=" + document.getElementById('<%=hdnNewUntAdr.ClientID %>').id
                + "&AgentType=" + document.getElementById('<%=ddllvlagttype.ClientID%>').value + "&MgrCode=" + strMgr + "&UntAdr=" + document.getElementById('<%=lblNewUntAddr.ClientID %>').id
                + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=lblNwUntcd.ClientID%>').id + "&hdn1=" + document.getElementById('<%=hdnNwUntcd.ClientID %>').id
                + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent + "&mdlpopup=mdlViewBID";
                }
            }
        }

        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon) {
            debugger;
            var memcode;
            if (document.getElementById('ctl00_ContentPlaceHolder1_ddlTransferType').value == "D") {
                memcode = document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText;
            }
            else {
                memcode = document.getElementById('<%=hdnRptMgr.ClientID %>').value;
            }
            
            var strAgentType = document.getElementById('ctl00_ContentPlaceHolder1_hdnAgntType').value;
            var chnl = document.getElementById('<%=hdnBizsrc.ClientID %>').value;
            var schnl = document.getElementById('<%=hdnChncls.ClientID %>').value;
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnNRptMgr.ClientID %>').value
+ "&Desc=" + document.getElementById('<%=txtRptMgr.ClientID %>').value + "&Field1=" + document.getElementById('<%=hdnNRptMgr.ClientID %>').id
+ "&Field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent
+ "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnNwUntcd.ClientID %>').value + "&trf=TRF"
+ "&Field3=" + document.getElementById('<%=lblNwRptMgr.ClientID %>').id + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById('<%=hdnRptSetup.ClientID %>').value
+ "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBID&isPrimary=Y"
+ "&MemCode=" + memcode
+ "&ddl=" + document.getElementById('<%=ddllvlagttype.ClientID %>').id;
            }
            if (strPopUpType != "rptmgr") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_hdnNwUntcd").value != "") {
                   
                }
                else {
                    alert("Please Select Unit Code");
                }
            }
        }
        
        function AssigText(strtext) {
            if (strtext == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            if (strtext == "Multiple-1") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            else if (strtext == "Multiple-2") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            else if (strtext == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            if (strtext == 'empty') {
                document.getElementById("ctl00_ContentPlaceHolder1_tblReportingMngrDtls").style.display = "none";
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam1rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam1rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                }
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam2rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam2rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                }
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam3rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam3rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
                }
            }
        }

        function funValidate() {
            ////debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "ddlTransferReason") != null) {
                if (document.getElementById(strContent + "ddlTransferReason").value == "") {
                    alert("Please Enter Transfer Reason");
                    document.getElementById(strContent + "ddlTransferReason").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtRemark") != null) {
                if (document.getElementById(strContent + "txtRemark").value == "") {
                    alert("Please Enter Remarks");
                    document.getElementById(strContent + "txtRemark").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlTransferType") != null) {
                if (document.getElementById(strContent + "ddlTransferType").value == "") {
                    alert("Please Enter Transfer Type");
                    document.getElementById(strContent + "ddlTransferType").focus();
                    return false;
                }
            }
//            if (document.getElementById(strContent + "txtRptMgr") != null) {
//                if (document.getElementById(strContent + "txtRptMgr").value == "") {
//                    alert("Please Select Primary Reporting Manager");
//                    document.getElementById(strContent + "txtRptMgr").focus();
//                    return false;
//                }
//            }
//            if (document.getElementById(strContent + "hdnNwUntcd") != null) {
//                if (document.getElementById(strContent + "hdnNwUntcd").value == "" || document.getElementById(strContent + "hdnNwUntcd").value == null) {
//                    alert("Please Select Unit Code");
//                    return false;
//                }
//            }
//            if (document.getElementById(strContent + "txtNewUntCode") != null) {
//                if (document.getElementById(strContent + "lblNwUntcd") != null) {
//                    if (document.getElementById(strContent + "lblNwUntcd").value == "") {
//                        alert("Please Select Unit Code");
//                        document.getElementById(strContent + "txtNewUntCode").focus();
//                        return false;
//                    }
//                }
//            }
            ///debugger;
//            if (document.getElementById(strContent + "hdnPriMandatory") != null) {
//                if (document.getElementById(strContent + "hdnPriMandatory").value != "") {
//                    if (document.getElementById(strContent + "hdnPriMandatory").value == "True") {
//                        if (document.getElementById(strContent + "hdnNRptMgr").value == "") {
//                            alert("Please Fill Primary Reporting Details");
//                            return false;
//                        }
//                    }
//                }
//            }

//            if (document.getElementById(strContent + "hdnMgr1Mandatory") != null) {
//                if (document.getElementById(strContent + "hdnMgr1Mandatory").value != "") {
//                    if (document.getElementById(strContent + "hdnMgr1Mandatory").value == "True") {
//                        if (document.getElementById(strContent + "hdnRptMgr1").value == "") {
//                            alert("Please Fill Additional Reporting Manager1 Details");
//                            return false;
//                        }
//                    }
//                }
//            }
//            if (document.getElementById(strContent + "hdnMgr2Mandatory") != null) {
//                if (document.getElementById(strContent + "hdnMgr2Mandatory").value != "") {
//                    if (document.getElementById(strContent + "hdnMgr2Mandatory").value == "True") {
//                        if (document.getElementById(strContent + "hdnRptMgr2").value == "") {
//                            alert("Please Fill Additional Reporting Manager2 Details");
//                            return false;
//                        }
//                    }
//                }
//            }

//            if (document.getElementById(strContent + "hdnMgr3Mandatory") != null) {
//                if (document.getElementById(strContent + "hdnMgr3Mandatory").value != "") {
//                    if (document.getElementById(strContent + "hdnMgr3Mandatory").value == "True") {
//                        if (document.getElementById(strContent + "hdnRptMgr3").value == "") {
//                            alert("Please Fill Additional Reporting Manager3 Details");
//                            return false;
//                        }
//                    }
//                }
//            }
        }
        function addlvalidate() {
            ////debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
//            if (document.getElementById(strContent + "hdnNwUntcd") != null) {
//                if (document.getElementById(strContent + "hdnNwUntcd").value == "") {
//                    alert("Please Select UnitCode");
//                    return false;
//                }
//            }
        }
        function funblankUntCode() {
            ////debugger;
            if (document.getElementById('<%=txtNewUntCode.ClientID %>').value == "") {
                document.getElementById('<%=lblNwUntcd.ClientID %>').innerText = "";
                document.getElementById('<%=hdnNwUntcd.ClientID %>').value = "";
                document.getElementById('<%=lblNewUntDr.ClientID %>').innerText = "";
//               
            }
        }
        function funblankRptMgr()
        {//debugger;
            if (document.getElementById('<%=txtRptMgr.ClientID %>') != null) {
                if (document.getElementById('<%=txtRptMgr.ClientID %>').value == "") {
                    document.getElementById('<%=lblNwRptMgr.ClientID %>').innerText = "";
                    document.getElementById('<%=hdnNRptMgr.ClientID %>').value = "";
                }
            }
        }

        function funcgridMgrShowPopup(strPopUpType, strbzsrc, strsbclass, strAgentType, stragttyp, stragent, strbsdon, rowid) {
           ////debugger;
           var strAgentType = document.getElementById('ctl00_ContentPlaceHolder1_hdnAgntType').value;
           var PrimMgr = document.getElementById('<%=hdnNRptMgr.ClientID%>');
           var chnl = document.getElementById('<%=hdnBizsrc.ClientID %>').value;
           var schnl = document.getElementById('<%=hdnChncls.ClientID %>').value;
            var untcode = document.getElementById('ctl00_ContentPlaceHolder1_hdnNwUntcd');
            var memcode;
            if (document.getElementById('ctl00_ContentPlaceHolder1_ddlTransferType').value == "D") {
                memcode = document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText;
            }
            else {
                memcode = document.getElementById('<%=hdnRptMgr.ClientID %>').value;
            }
            if (strPopUpType == "rptmgr") {
            //    if (PrimMgr.value == "" || untcode.value == "") {
            //        alert("Please select Primary Manager and Unitcode first.");
            //        return false;
            //    }
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('ctl00_ContentPlaceHolder1_hdnNwUntcd').value
        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value
        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
        + "&MemCode=" + memcode
        + "&memtyp=" + strAgentType + "&mdlpopup=mdlViewBID&isPrimary=N" + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id;
            }
        }

    </script>
    <style type="text/css">
              .btn-subtab
        {
            color:#034ea2;
            background-color:#FFFFFF;
            border-color:#034ea2;
        }
     
   
        .pagelink span
        {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/
    </style>
    <script language="javascript" type="text/javascript" src="~/Scripts/common.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/subModal.js"></script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <center>
        <table width="80%" border="0" style="border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="panel " id="div3" runat="server">
            <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','btnprsnldtlscollapse');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblPersonalPart" runat="server" Text="Personal Particular" Font-Size="19px"></asp:Label>
                        <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnprsnldtlscollapse" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divpersnldtls" runat="server" class="panel-body" style="display: block">
                <div class="row">
                    <div class="col-md-10">
                        <div>
                            <div class="row" style="margin-bottom: 5px;" id="trcltcode" runat="server" visible="false">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblClCode" CssClass="control-label" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lblCusmIdVal" runat="server" CssClass="form-control" MaxLength="12"
                                      ></asp:Label>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblCode" CssClass="control-label" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCltCodeVal" runat="server" CssClass="form-control" MaxLength="12"
                                               ></asp:Label>
                                            &nbsp;
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lvlVw1AgntCode" CssClass="control-label" runat="server" Font-Bold="False">Agent Code</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblAgtCodeVal" runat="server" CssClass="form-control" Enabled="false"
                                        ></asp:TextBox>
                                    <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" Text="" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <span>
                                        <asp:Label ID="lblVw1AgntStatus" CssClass="control-label" runat="server" Font-Bold="False">Agent Status</asp:Label>
                                    </span>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblAgntStatusVal" runat="server" Enabled="false" CssClass="form-control"
                                       > </asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblAgntName" CssClass="control-label" runat="server">Agent Name</asp:Label>
                                </div>
                                <div class="col-md-3" style="display: flex">
                                    <asp:TextBox ID="lblagnTitleVal" runat="server" Enabled="false" CssClass="form-control"
                                        Style="display: inline;"></asp:TextBox>
                                    <asp:TextBox ID="lblAgntNameVal" runat="server" Enabled="false" CssClass="form-control"
                                        MaxLength="125" Style="margin-left: 2px" ></asp:TextBox>
                                    <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblGender" runat="server" CssClass="control-label" Text="Gender"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblGenderVal" runat="server" Enabled="false" CssClass="form-control"
                                       ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;" id="trserv" runat="server" visible="false">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblServName" runat="server" Font-Bold="False" CssClass="control-label"
                                    Text="Service Name"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblServProvInfoVal" runat="server" CssClass="form-control" MaxLength="30"
                                   ></asp:Label>
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;" id="trexclusive" runat="server" visible="false">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblExclusive" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:RadioButtonList ID="rdlExclusive" runat="server" >
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="row">
                            <div class="panel " id="div5" runat="server" style="margin-top:10px">
                                <div id="div6" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divTrfDtls','btntrfdtlscollapse');return false;"
                                    >
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                            <asp:Label ID="lbltermDtls" runat="server" Text="Transfer Details" CssClass="subheader"
                                                ></asp:Label>
                                            <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btntrfdtlscollapse" class="glyphicon glyphicon-resize-full" style="float: right;
                                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divTrfDtls" runat="server" class="panel-body" style="display: block">
                                    <div id="tblTrfDtls">
                                        <div class="row" id='trEffDt' style="margin-bottom: 5px;" runat="server">
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblEffctDt" runat="server" CssClass="control-label" Text="Effective Date"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox CssClass="form-control" runat="server" ID="lblEffectiveDate" Enabled="false"
                                                   Font-Bold="false" Font-Size="Small"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblTrfType" runat="server" CssClass="control-label" Text="Transfer Type"></asp:Label>
                                                <span style="color: #ff0000; margin-left: -5px;">*</span><%--Modified: Parag @ 25032014 --%>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:UpdatePanel ID="updTrfTyp" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlTransferType" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                            OnSelectedIndexChanged="ddlTransferType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblTrnsReason" runat="server" CssClass="control-label" Text="Transfer Reason"></asp:Label>
                                                <span style="color: #ff0000; margin-left: -5px;">*</span>
                                            </div>
                                            <%--Modified:Parag @ 25032014 --%>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="ddlTransferReason" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblRemark" runat="server" CssClass="control-label" Text="Remarks"></asp:Label>
                                                <span style="color: #ff0000;">*</span>
                                            </div>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-12" style="text-align: center">
                                <asp:Label ID="lblPhoto" runat="server" Text="Photo" CssClass="control-label" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                            <%--    <asp:GridView ID="GridImage" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CssClass="formtable" Height="100%" HorizontalAlign="Left"
                                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" PagerStyle-HorizontalAlign="Center"
                                                    RowStyle-CssClass="formtable" Width="100%">--%>
                            <asp:GridView AllowSorting="True" ID="GridImage" runat="server" CssClass="footable"
                                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="MemCode" SortExpression="MemCode" Visible="false">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("MemCode") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ImageField ControlStyle-Height="100px" DataImageUrlField="MemCode" DataImageUrlFormatString="ImageRet.aspx?ImageID={0}"
                                        HeaderText="Preview Image" NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                    </asp:ImageField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="row">
                            <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo" Font-Size="12px" 
                                Visible="false"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="panel " id="div7" runat="server">
            <div id="Div8" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCurntDtls','btnCurrntDtlscollapse');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label15" runat="server" Text="Current Details" Font-Size="19px"></asp:Label>
                        <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnCurrntDtlscollapse" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divCurntDtls" runat="server" class="panel-body" style="display: block">
                <div id="tblReportingMngrDtls" runat="server">
                    <asp:UpdatePanel ID="updCrnttabs" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="lnkCrntHier" runat="server" CssClass="TextBox" BackColor="transparent"
                                Visible="false" ImageUrl="~/theme/iflow/tabs/HierarchyDtls1.png" Text="Primary Manager" 
                                OnClick="lnkCrntHier_Click" />
                            <asp:ImageButton ID="lnkCrntPrimMgr" runat="server" CssClass="TextBox" BackColor="transparent"
                                Visible="false" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager" 
                                OnClick="lnkCrntPrimMgr_Click" />
                            <asp:ImageButton ID="lnkCrntAddlMgr" runat="server" CssClass="TextBox" BackColor="transparent"
                                Visible="false" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                                OnClick="lnkCrntAddlMgr_Click" />
                            <asp:ImageButton ID="lnkCrntDlines" runat="server" CssClass="TextBox" BackColor="transparent"
                                Visible="false" ImageUrl="~/theme/iflow/tabs/Downlines2.png" Text="Downlines" 
                                OnClick="lnkCrntDlines_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="demo1" class="row" runat="server" style="text-align: left;margin-left:20px;margin-bottom:10px">
                        <asp:LinkButton ID="lnkHierarchy" Text="Hierarchy Details" CssClass="btn btn-default" 
                            OnClick="lnkHierarchy_Click" runat="server"></asp:LinkButton>
                        <asp:LinkButton ID="lnkprimary" Text="Primary Manager" CssClass="btn btn-default" 
                            OnClick="lnkprimaryl_Click" runat="server"></asp:LinkButton>
                        <asp:LinkButton ID="lnkadditional" Text="Additional Manager" CssClass="btn btn-default"
                            OnClick="lnkadditional_Click" runat="server"></asp:LinkButton>
                        <asp:LinkButton ID="lnkDownlines" Text="Downlines" CssClass="btn btn-default" OnClick="lnkDownlines_Click"
                            runat="server"></asp:LinkButton>
                    </div>
                    <asp:HiddenField ID="hdnTab" runat="server" />
                    <div class="panel " id="divHirarchy" runat="server">
                        <div class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHirarchyDtls','btnHirarchyDtlscollapse');return false;"
                           >
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                    <asp:Label ID="lblHirarchyDtlshdr" CssClass="subheader" runat="server" Text="Hierarchy Details"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="btnHirarchyDtlscollapse" class="glyphicon glyphicon-resize-full" style="float: right;
                                        color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="divHirarchyDtls" runat="server" class="panel-body" style="display: block">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblchnltype" CssClass="control-label" runat="server">Channel Type</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                              >
                                                <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblCntDetails" CssClass="control-label" runat="server" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <%--<asp:LinkButton ID="lnbViewCntDetails" runat="server" Visible="false">View Details</asp:LinkButton>--%>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblBusinessSrc" CssClass="control-label" runat="server" Font-Bold="False">Hierarchy Name</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="lblSlsChannelVal" runat="server" AutoPostBack="True" Enabled="false"
                                                CssClass="form-control" ></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblChnCls" CssClass="control-label" runat="server">Sub Class</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblChnClsVal" runat="server" Enabled="false" CssClass="form-control"
                                       ></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblVw1AgntType" CssClass="control-label" runat="server" Font-Bold="False">Agent Type</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblAgntTypeVal" runat="server" Enabled="false" CssClass="form-control"
                                      ></asp:TextBox>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblAgntClass" CssClass="control-label" runat="server" Font-Bold="False">Agent Class</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="lblAgntClassVal" runat="server" CssClass="form-control" Enabled="false"
                                        ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divPrimry" runat="server">
                        <div class="panel ">
                            <div runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprirep','btnprirepcollapse');return false;"
                                >
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="lblPrimaryReportinghdr" CssClass="subheader" runat="server" Text="Primary Reporting"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnprirepcollapse" class="glyphicon glyphicon-resize-full" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divprirep" runat="server" class="panel-body" style="display: block">
                                <div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lblddlreportingtype" CssClass="control-label" runat="server" Text="Reporting Type"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lblprimrepoVal" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lblbasedon" runat="server" CssClass="control-label" Text="Based On"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lblbasedondescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lblchannel" CssClass="control-label" runat="server">Hierarchy Name</asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lblchanneldescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lblsubchannel" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lblsubchnldescVal" runat="server" Enabled="false" CssClass="form-control" >
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lblReportingMgr" runat="server" CssClass="control-label" Text="Reporting Manager"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lblRptMgrVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>&nbsp
                                            <asp:TextBox ID="lblrptmgr" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lbllevelagttype" CssClass="control-label" runat="server">Level/Rel Type</asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="lbllvlagtVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                <%--    <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                                    PageSize="10" Width="100%" >
                                                                    <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White" />
                                                                    <AlternatingRowStyle CssClass="sublinkeven" />
                                                                    <RowStyle CssClass="sublinkodd" />
                                                                    <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />--%>
                               <div class="container" style="width:100%">
                                    <asp:GridView AllowSorting="True" ID="gvoldprimary" runat="server" CssClass="footable" AutoGenerateColumns="False"
                                    PageSize="10" AllowPaging="true" CellPadding="1">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                            <ItemTemplate>
                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Code">
                                            <ItemTemplate>
                                                <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                              </div>
                            </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="upUCode">
                            <ContentTemplate>
                                <div class="panel " id="tblUnitCodeDetails" runat="server">
                                    <div id="div10" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divuntcode','btnuntcode');return false;"
                                        >
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                                <asp:Label ID="Label22" CssClass="subheader" runat="server" Text="Unit Code Details"></asp:Label>
                                            </div>
                                            <div class="col-sm-2">
                                                <span id="btnuntcode" class="glyphicon glyphicon-resize-full" style="float: right;
                                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divuntcode" runat="server" class="panel-body" style="display: block">
                                        <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblUntCde" CssClass="control-label" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:UpdatePanel ID="upnlBtnUnitCode" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtUntCode" runat="server" CssClass="form-control" MaxLength="10"
                                                            Enabled="false" Visible="false"></asp:TextBox>
                                                        <%--<asp:Button ID="btnUnitCode" runat="server" CssClass="standardbutton" Text="...." Width="20px" />--%>
                                                        <asp:TextBox ID="lblUCode" runat="server" CssClass="form-control" Visible="false"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:TextBox ID="lblUnitDesc" runat="server" Style="display: none;" Visible="false" 
                                                            CssClass="form-control"></asp:TextBox>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:TextBox ID="lblUntCode" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:UpdatePanel ID="upunadr" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="lblUntAddr" runat="server" CssClass="form-control" Enabled="false" Visible="false"
                                                            Text=""></asp:TextBox>
                                                        <asp:HiddenField ID="hdnutadr" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                <%-- <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true" 
                                                AllowSorting="true" Width="100%" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                                PageSize="8" PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center">--%>
                                         <div class="container" style="width:100%">              
                                              <asp:GridView AllowSorting="false" ID="gvolduntlst" runat="server" CssClass="footable"
                                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="panel " id="divAdditional" runat="server">
                        <div runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMngrDtls','btnaddlmgrcollapse');return false;"
                            >
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                    <asp:Label ID="lblAddlMgrDet" runat="server" Text="Additional Manager Details" CssClass="subheader"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="btnaddlmgrcollapse" class="glyphicon glyphicon-resize-full" style="float: right;
                                        color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="divMngrDtls" runat="server" class="panel-body" style="display: block">
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lbladditionalreporting" runat="server" CssClass="control-label" Text="Additional Reporting Rule"></asp:Label>
                                </div>
                                <div class="col-md-9" style="text-align:left;">
                                    <asp:TextBox ID="lbladditionalreportingrule" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblRptMngrErr"  runat="server" CssClass="control-label" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <%--<tr>
                                                                        <td class="formcontent" style="width: 100%;" colspan="2">
                                                                            <table id="tblmgr1" class="formtable2" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td align="left" class="test" style="height: 30px; width: 20%;" colspan="8">
                                                                                        <asp:Label ID="lbladdnlmgr1" runat="server" Text="Additional Manager 1"
                                                                                            Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamreportingtype1" runat="server" Text="Reporting Type"
                                                                                            Width="100px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam1rptdescVal" runat="server" CssClass="standardlabel"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblambasedon1" runat="server" Text="Based On" Width="65px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam1basedondescVal" runat="server" CssClass="standardlabel"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblchnl1" runat="server" Text="Channel" Width="55px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam1chnldescVal" runat="server" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblsubchnl1" runat="server" Text="Sub Channel" Width="80px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam1subchnldescVal" runat="server" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamlevelagttype1" runat="server" Height="16px" Text="Level/Agent Type"
                                                                                            Width="110px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lbllvlagttype1Val" runat="server" Height="21px" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblMgr1" runat="server" Text="Manager" Width="94px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam1lMgrVal" runat="server" CssClass="standardlabel" Height="16px"
                                                                                           ></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table id="tblmgr2" class="formtable2" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td align="left" class="test" style="height: 30px; width: 20%;" colspan="8">
                                                                                        <asp:Label ID="lbladdnlmgr2" runat="server" Text="Additional Manager 2"
                                                                                            Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamreportingtype2" runat="server" Text="Reporting Type"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam2rptdescVal" runat="server" Height="16px" CssClass="standardlabel"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblambasedon2" runat="server" Text="Based On" Width="65px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam2basedondescVal" runat="server"  CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblchnl2" runat="server" Text="Channel"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam2chnldescVal" runat="server"  CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblsubchnl2" runat="server" Text="Sub Channel"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam2subchnldescVal" runat="server"  CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamlevelagttype2" runat="server" Height="16px" Text="Level/Agent Type"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lbllvlagttype2Val" runat="server" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblMgr2" runat="server" Text="Manager"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam2lMgrVal" runat="server" CssClass="standardlabel" Height="18px"
                                                                                           >
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table id="tblmgr3" class="formtable2" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td align="left" class="test" style="height: 30px; width: 20%;" colspan="8">
                                                                                        <asp:Label ID="lbladdnlmgr3" runat="server" Text="Additional Manager 3"
                                                                                            Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamreportingtype3" runat="server" Text="Reporting Type"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam3rptdescVal" runat="server" CssClass="standardlabel"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblambasedon3" runat="server" Text="Based On"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam3basedondescVal" runat="server"  CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblchnl3" runat="server" Text="Channel" Width="55px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam3chnldescVal" runat="server"  CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblsubchnl3" runat="server" Text="Sub Channel" Width="80px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam3subchnldescVal" runat="server" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="lblamlevelagttype3" runat="server" Height="16px" Text="Level/Agent Type"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lbllvlagttype3Val" runat="server" CssClass="standardlabel">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 20%;">
                                                                                        <asp:Label ID="Label28" runat="server" Text="Manager"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="formcontent" style="height: 30px; width: 30%;">
                                                                                        <asp:Label ID="lblam3lMgrVal" runat="server" CssClass="standardlabel" Height="18px"
                                                                                            ></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>--%>
                            <div class="row" style="margin-bottom: 5px;">
                                <div class="col-md-12" style="text-align: left">
                                    <asp:GridView ID="gv_RptMngr_Crnt" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" PageSize="5" Width="100%" OnRowDataBound="gv_RptMngr_Crnt_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <%--<div class="row" style="margin-bottom: 5px;">
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblMgrHdr" runat="server" CssClass="subheader" Font-Bold="true" Text="Additional Manager"></asp:Label>
                                                            <asp:Label ID="lblNo" runat="server" Font-Bold="true" Text='<%# Bind("Mngr") %>'></asp:Label>
                                                        </div>
                                                    </div>--%>
                                                 <%--   <div id="trVenType" runat="server" class="row" visible="false" style="margin-bottom: 5px;">
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" />
                                                          </div>
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="ddlventype" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" AutoPostBack="true" />
                                                        </div>
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:DropDownList ID="ddlRelModel" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                                />
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-bottom: 5px;">
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrntAdlRptTyp" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrtAdlBsdOn" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-bottom: 5px;">
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrntAdlChn" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrntAdlSChn" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-bottom: 5px;">
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrntAdlAgtTyp" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3" style="text-align: left">
                                                            <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" />
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="lblCrntRptMngr" runat="server" CssClass="standardlabel"></asp:Label>
                                                        </div>
                                                    </div>--%>
                                                 <div class="panel " style="margin-top: 15px;">
                                            <div id="Div1" runat="server" class="panel-heading subheader"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtBasicSearch','Span3');return false;">
                                                <div class="row">
                                                    <div class="col-sm-10" style="text-align: left">
                                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                                        <asp:Label ID="lblMgrHdr" runat="server" CssClass="subheader" Text="Additional Manager"></asp:Label>
                                                        <asp:Label ID="lblNo" runat="server" CssClass="subheader" Text='<%# Bind("Mngr") %>'></asp:Label>
                                                        <asp:Label ID="lblord" runat="server" CssClass="control-label" Visible="false" Text='<%# Bind("RelOrder") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <span id="Span3" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divMgr" runat="server" class="panel-body" style="display: block;">
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblVendorType" runat="server" CssClass="control-label" Text="Vendor Type" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAddlventype" runat="server" CssClass="form-control" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlAddlventype_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" TabIndex="54" AutoPostBack="true" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblRelModel" runat="server" CssClass="control-label" Text="Relationship Model"></asp:Label>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                        TabIndex="50" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlRptTyp" CssClass="control-label" runat="server" Text="Relationship Type" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlBasedOn" runat="server" CssClass="control-label" Text="Based On" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlChn" runat="server" CssClass="control-label" Text="Hierarchy Name" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlChn" runat="server" CssClass="form-control" AutoPostBack="true"
                                                       >
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlSChn" CssClass="control-label" runat="server" Text="Sub Class" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlSChn" runat="server" CssClass="form-control" >
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlMemTyp" CssClass="control-label" runat="server" Text="Member Type" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" CssClass="form-control" AutoPostBack="true"
                                                        >
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" />
                                                    <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false" />
                                                </div>
                                                <div class="col-sm-3">
                                                    
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div style="display:flex;">
                                                            <asp:TextBox ID="txtRptMngr" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblRptMngr" runat="server" /> 
                                                          <%--  <input   value="...."  type="button"   runat="server" id="lnkRptMngr" disabled="disabled"
                                                             onclick="funcgridMgrShowPopup('rptmgr', 'AG', 'AGAG', 'BP', 'A', '1', 'ctl00_ContentPlaceHolder1_gv_RptMngr_ctl02', '51', '0')"
                                                               />
                                                              --%>
                                                           
                                                            <asp:Button ID="lnkRptMngr" runat="server" CssClass="btn btn-primary" Text="...." Style="margin-left: 2px;"
                                                             
                                            TabIndex="34"/>
                                                            
                                                            <asp:Button ID="btnoldRptmemgrid" runat="server"  ClientIDMode="Static"
                                                                Style="display: none;" />
                                                            <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                            <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                            <asp:HiddenField ID="hdnAddlStp" runat="server" />
                                                            <asp:HiddenField ID="hdnAdMemType" runat="server" /> </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                       
                                                </div>
                                                <asp:GridView ID="gvoldAddlMgr" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" PageSize="10" Width="100%">
                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                            <ItemTemplate>
                                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Code">
                                                            <ItemTemplate>
                                                                <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                                </ItemTemplate>
                                               <%-- <ItemStyle ForeColor="Black" HorizontalAlign="Center" />--%>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel " id="divDownlines" runat="server">
                        <div runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_trDownlines','btnDownlines');return false;"
                            >
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left">
                                    <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                    <asp:Label ID="lblDwnDtlsHdr" runat="server" Text="Downline Details" CssClass="subheader"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="btnDownlines" class="glyphicon glyphicon-resize-full" style="float: right;
                                        color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="trDownlines" runat="server" class="panel-body" visible="false">
                            <div class="row" style="margin-bottom: 5px; width:100%">
                                <div class="col-sm-12" style="text-align: left">
                                    <asp:LinkButton ID="lnkbtnCF" runat="server" CssClass="btn btn-sample"
                                        OnClick="lnkbtnCF_Click">
                                            <span class="glyphicon glyphicon-user" style="color:White"></span> Primary Downline Details
                                        </asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnCU" runat="server" Text="Additional Downline Details" CssClass="btn btn-sample"
                                        OnClick="lnkbtnCU_Click">
                                            <span class="glyphicon glyphicon-user" style="color:White"></span> Additional Downline Details
                                        </asp:LinkButton>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="upDownlines" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="margin-bottom: 5px; width:97%">
                                        <asp:GridView AllowSorting="True" ID="gv_TrfDownlines" runat="server" CssClass="footable"
                                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                            OnSorting="gv_TrfDownlines_Sorting" OnPageIndexChanging="gv_TrfDownlines_PageIndexChanging">
                                            <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview" />
                                            <PagerStyle CssClass="disablepage" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Member Code" DataField="MemCode" SortExpression="MemCode"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField HeaderText="Member Name" DataField="LegalName" SortExpression="LegalName"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField HeaderText="Channel" DataField="Channel" SortExpression="Channel"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField DataField="SubChannel" HeaderText="Sub Class" SortExpression="SubChannel"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField DataField="AgentTypeDesc" HeaderText="Member Type" SortExpression="AgentTypeDesc"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField DataField="RelationType" HeaderText="Relation Type" SortExpression="RelationType"
                                                    HeaderStyle-HorizontalAlign="Center" />
                                            </Columns>
                                            <PagerSettings FirstPageImageUrl="~/Images/iFirst.gif" LastPageImageUrl="~/Images/iLast.gif"
                                                NextPageImageUrl="~/Images/iNext.gif" PreviousPageImageUrl="~/Images/iPrev.gif" />
                                        </asp:GridView>
                                        <asp:Label ID="lblDownlineErrorMsg" runat="server" CssClass="standardlabel" Text="No Downlines Found"
                                            Visible="false" ForeColor="Red"></asp:Label>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="upNewD" runat="server">
            <ContentTemplate>
                <div id="tblNewDts" runat="server" class="panel " style="display: none;">
                    <div id="Div9" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','btnNominee');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label17" runat="server" Width="141px" Text="New Details" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btnNominee" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divNewDtls" runat="server" style="display: block;" class="panel-body">
                        <asp:UpdatePanel ID="upNewDtlsTabs" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="lnkCrntHierNew" Visible="false" runat="server" CssClass="TextBox"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls1.png" Text="Primary Manager"
                                    OnClick="lnkCrntHierNew_Click" />
                                <asp:ImageButton ID="lnkCrntPrimMgrNew" Visible="false" runat="server" CssClass="TextBox"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager"
                                    OnClick="lnkCrntPrimMgrNew_Click" />
                                <asp:ImageButton ID="lnkCrntAddlMgrNew" Visible="false" runat="server" CssClass="TextBox"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                                    OnClick="lnkCrntAddlMgrNew_Click" />
                                <asp:ImageButton ID="lnkCrntDlinesNew" Visible="false" runat="server" CssClass="TextBox"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Downlines2.png" Text="Downlines"
                                    OnClick="lnkCrntDlinesNew_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="Div15" class="row" runat="server" style="margin-left: 20px;text-align: left; margin-bottom:10px">
                            <asp:LinkButton ID="Hierarchy" Text="Hierarchy Details" CssClass="btn-subtab btn btn-default"
                                OnClientClick="return addCssClassByClick('1')" OnClick="Hierarchy_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Primary" Text="Primary Manager" CssClass=" btn btn-default" OnClientClick="return addCssClassByClick('2')"
                                OnClick="Primary_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Additional" Text="Additional Manager" CssClass="btn btn-default"
                                OnClientClick="return addCssClassByClick('3')" OnClick="Additional_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Downlines" Text="Downlines" CssClass="btn btn-default" OnClientClick="return addCssClassByClick('4')"
                                OnClick="Downlines_Click" runat="server"></asp:LinkButton>
                        </div>
                        <div id="divHierNew" runat="server" class="panel " style="margin-top: 15px;">
                            <div id="div11" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHirarchyDtlsNew','Span7');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label1" runat="server" Text="Hierarchy Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span7" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divHirarchyDtlsNew" runat="server" style="display: block;" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label2" CssClass="control-label" runat="server">Channel Type</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblChnlType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                     OnSelectedIndexChanged="rblChnlType_SelectedIndexChanged" Enabled="False">
                                                    <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label3" CssClass="control-label" runat="server" Visible="false"></asp:Label>
                                    </div>
                                    <%-- <div class="col-sm-3" >--%>
                                    <%--<asp:LinkButton ID="lnbViewCntDetails" runat="server"  Visible="false">View Details</asp:LinkButton>--%>
                                    <%-- </div>--%>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label4" runat="server" CssClass="control-label" Font-Bold="False">Hierarchy Name</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                            <asp:UpdatePanel ID="updddlSlsChnl0" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSlsChannel" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" Enabled="False">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label6" CssClass="control-label" runat="server">Sub Class</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="upnlChnCls" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" Enabled="False">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSlsChannel" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label9" runat="server" CssClass="control-label" Font-Bold="False">Agent Type</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label11" runat="server" CssClass="control-label" Font-Bold="False">Agent Class</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntClass" runat="server" Enabled="false" CssClass="form-control"
                                            >
                                            <asp:ListItem Text="Staff" Value="NM"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divprimnew" runat="server" class="panel " style="margin-top: 15px;">
                            <div id="div12" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divprirepNew','Span1');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label5" runat="server" Text="Primary Reporting" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span1" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divprirepNew" runat="server"  class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label7" CssClass="control-label" runat="server" Text="Reporting Type"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlamrptdesc" runat="server" CssClass="form-control" 
                                            Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label12" CssClass="control-label" runat="server" Text="Based On"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlambasedondesc" runat="server" CssClass="form-control"
                                            Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label14" CssClass="control-label" runat="server">Hierarchy Name</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlamchnldesc" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlam1chnldesc_SelectedIndexChanged"
                                            Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label16" CssClass="control-label" runat="server">Sub Class</asp:Label>
                                    </div>
                                    <div class="col-sm-3" >
                                        <asp:DropDownList ID="ddlamsubchnldesc" runat="server" CssClass="form-control" 
                                            Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label18" CssClass="control-label" runat="server" Text="Reporting Manager"></asp:Label>
                                        <span id="spnrpt" runat="server" style="color:Red;">*</span>
                                    </div>
                                    <div class="col-sm-3" style="display: flex;">
                                        <asp:TextBox ID="txtRptMgr" runat="server" MaxLength="10" CssClass="form-control"
                                              Enabled="false"></asp:TextBox>&nbsp <%--onblur="Javascript:funblankRptMgr();"--%>
                                        <asp:Button ID="btnRptMgr" runat="server" CssClass="btn btn-verify"
                                            Text="...." OnClick="btnRptMgr_Click1" />
                                        <asp:Label ID="lblNwRptMgr" runat="server" CssClass="control-label"></asp:Label>
                                        <asp:Button ID="btnmemgrid" runat="server" OnClick="btnmemgrid_Click" ClientIDMode="Static"
                                            Style="display: none;" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label21" CssClass="control-label" runat="server" Text="Level/Rel Type"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:UpdatePanel runat="server" ID="updAgtTyp" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddllvlagttype" runat="server" CssClass="form-control"
                                                    Enabled="False" AutoPostBack="true" OnSelectedIndexChanged="ddllvlagttype_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-12" style="text-align: left">
                                        <asp:GridView AllowSorting="false" ID="gv" runat="server" CssClass="footable" AutoGenerateColumns="False"
                                            PageSize="10" AllowPaging="true" CellPadding="1">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                    <ItemTemplate>
                                                        <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                        <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Code">
                                                    <ItemTemplate>
                                                        <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                        <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>' Enabled="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div id="HierarchyDemo" runat="server" class="panel " style="margin-top: 15px;margin-left: 0px;margin-right:0px;">
                                    <div id="div13" runat="server" class="panel-heading subheader"
                                        onclick="ShowReqDtl('div1','Span4');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                                <asp:Label ID="Label24" runat="server" Text="Unit Code Details" CssClass="subheader"></asp:Label>
                                                &nbsp;
                                                <asp:CheckBox ID="chkUnt" runat="server" OnCheckedChanged="chkUnt_CheckedChanged"
                                                    Font-Bold="false" AutoPostBack="true" Text="Change Unit Code" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span id="Span4" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="div1" runat="server" style="display: block;" class="panel-body">
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="Label26" CssClass="control-label" runat="server"></asp:Label>
                                                <span style="color: #ff0000; margin-left: 2px;">*</span>
                                            </div>
                                            <div class="col-sm-3" style="display: flex;">
                                                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>--%>
                                                <asp:TextBox ID="txtNewUntCode" runat="server" CssClass="form-control" MaxLength="10"
                                                     Enabled="false" AutoPostBack="true" OnTextChanged="txtNewUntCode_TextChanged"></asp:TextBox>
                                                <span style="margin-left: 5px;"></span>
                                                <asp:Button ID="btnUnitCode" runat="server" CssClass="btn btn-verify"
                                                    Text="...." Enabled="false" OnClick="btnUnitCode_Click" />
                                                <asp:Label ID="lblNewUntDr" runat="server"></asp:Label>
                                                <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static"
                                                    Style="display: none;" />
                                                <%--    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>--%>
                                                <asp:Label ID="lblNwUntcd" runat="server" CssClass="control-label" Style="display: none;"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblNewUntAddr" CssClass="control-label" runat="server" Text=""></asp:Label>
                                                        <asp:HiddenField ID="hdnNewUntAdr" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 5px;">
                                            <div class="col-sm-12" style="text-align: left">
                                                <asp:GridView AllowSorting="false" ID="gvUntLst" runat="server" CssClass="footable"
                                                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="PrimaryDemo" runat="server" class="panel " style="margin-top: 15px;
                            display: none;">
                            <div id="div14" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('divprmotdmotDtls','Span3');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label10" runat="server" Text="Additional Manager Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span5" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divMngrDtlsNew" runat="server" style="display: block;" class="panel-body">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label13" runat="server" CssClass="subheader" Text="Additional Reporting Rule"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="lblNwaddtnlreptrule" CssClass="subheader" runat="server"></asp:Label>
                                            <asp:Label ID="lblRptRulErr" runat="server" CssClass="control-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div id="div2" runat="server" style="display: block;" class="panel-body">
                                    <asp:GridView ID="gv_RptMngr_new" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" PageSize="5" Width="100%" OnRowDataBound="gv_RptMngr_new_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-sm-12" style="text-align: left">
                                                            <asp:Label ID="lblMgrHdr" runat="server" Font-Bold="true" CssClass="control-label" Text="Additional Manager"></asp:Label>
                                                            <asp:Label ID="lblNo" runat="server" Font-Bold="true" CssClass="control-label" Text='<%# Bind("Mngr") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div id="trVenType" runat="server" visible="false" class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblVendorType" runat="server" CssClass="control-label" Text="Vendor Type" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlventype" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" AutoPostBack="true" />
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model" CssClass="control-label"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details" CssClass="control-label"
                                                                 />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlChn" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlSChn" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAdlAgtTyp_SelectedIndexChanged" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" CssClass="control-label" />
                                                            <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false" />
                                                        </div>
                                                        <div class="col-sm-3" style="display:flex;">
                                                            <asp:TextBox ID="txtRptMngr" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblRptMngr" runat="server" />
                                                            <asp:Button ID="lnkRptMngr" runat="server" Text="...." CssClass="btn btn-primary"
                                                                OnClick="lnkRptMngr_Click"></asp:Button>
                                                             <asp:Button ID="btnRptmemgrid" runat="server" OnClick="btnRptmemgrid_Click" ClientIDMode="Static"
                                                                Style="display: none;" />
                                                            <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                            <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                            <asp:HiddenField ID="hdnAddlStp" runat="server" />
                                                            <asp:HiddenField ID="hdnAdMemType" runat="server" />
                                                             
                                                        </div>
                                                        <asp:GridView ID="gvAddlMgr" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" PageSize="10" Width="98%">
                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                            <ItemTemplate>
                                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Code">
                                                            <ItemTemplate>
                                                                <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div id="divdwnldtls" runat="server" class="panel " style="margin-top: 15px;display: none;">
                            <div id="divMemberReinstatement" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divReinstate','Span12');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label29" runat="server" Text="Downline Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span12" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divReinstate" runat="server" class="panel-body">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-12" style="text-align: left">
                                        <asp:LinkButton ID="lnkbtnNewCF" runat="server" CssClass="btn btn-sample" OnClick="lnkbtnNewCF_Click">
                                        <span class="glyphicon glyphicon-user" style="color:White"></span> Primary Downline Details
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnNewCU" runat="server" CssClass="btn btn-sample" OnClick="lnkbtnNewCU_Click">
                                    <span class="glyphicon glyphicon-user" style="color:White"></span> Additional Downline Details
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" style="text-align: left">
                                        <asp:GridView ID="gv_NewDownlines" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CssClass="footable" HorizontalAlign="Left" Width="100%" AllowSorting="True" OnPageIndexChanging="gv_NewDownlines_PageIndexChanging"
                                            OnSorting="gv_NewDownlines_Sorting">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDwnls" runat="server" AutoPostBack="true" OnCheckedChanged="chkDwnls_CheckedChanged" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="MemCode" HeaderText="Member Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Member Name" DataField="LegalName" SortExpression="LegalName"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField HeaderText="Channel" DataField="Channel" SortExpression="Channel">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubChannel" HeaderText="Sub Class" SortExpression="SubChannel">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AgentTypeDesc" HeaderText="Member Type" SortExpression="AgentTypeDesc">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RelationType" HeaderText="Relation Type" SortExpression="RelationType" />
                                                <asp:TemplateField SortExpression="MemType" HeaderText="Member Code" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMemTyp" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblDwlnErrmsg" runat="server" CssClass="standardlabel" Text="No Downlines Found"
                                            Visible="false" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                  <div id="tr3"  runat="server"  class="panel" style="margin-top: 15px;display: none;">
                         <div id="divnewdwndtls" runat="server" class="panel-heading"
                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdwnl','Span13');return false;">
                             <div class="row">
                              <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label33" runat="server" Font-Bold="true" Text="Downline Details" Font-Size="19px"></asp:Label></div>
                             <div class="col-sm-2">
                                        <span id="Span13" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                 </div>
                    </div>              
                <div id="trdwnl" runat="server"  class="panel-body" >  <%--style="display: none;" class="row"--%>
                      <div class="row">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lbldwnlMem" Text="Downline Member Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:UpdatePanel runat="server" ID="upd">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddldwnlMem" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="ddldwnlMem_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>
                          <div class="col-sm-3"></div>
                           <div class="col-sm-3"></div>
                      </div>
                    <div id="tr2" runat="server" style="display: none;">                   
                    <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-12" style="text-align: left">
                                <asp:LinkButton ID="lnkbtnDwnCF" runat="server" OnClick="lnkbtnDwnCF_Click">
                                        <span class="glyphicon glyphicon-user" style="color:White"></span> Primary Downline Details
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDwnCU" runat="server" OnClick="lnkbtnDwnCU_Click">
                                        <span class="glyphicon glyphicon-user" style="color:White"></span> Additional Downline Details
                                </asp:LinkButton>
                            </div>
                        </div> 
                    <div class="row">
                                    <div class="col-sm-12" style="text-align: left;display:block">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
<%--                                    <div class="row">
                                <div class="col-sm-12" style="text-align: left">--%>
                                        <asp:GridView ID="gv_Dwnls" runat="server" AllowPaging="True"   AutoGenerateColumns="False" 
                                            CssClass="footable" HorizontalAlign="Left" Width="100%" AllowSorting="True" PageSize="10"
                                            OnPageIndexChanging="gv_Dwnls_PageIndexChanging1" OnSorting="gv_Dwnls_Sorting" 
                                            OnRowDataBound="gv_Dwnls_RowDataBound">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkDwnls" runat="server" AutoPostBack="true" OnCheckedChanged="chkDwnls_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="MemCode" HeaderText="Member Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Member Name" DataField="LegalName" SortExpression="LegalName"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                <asp:BoundField HeaderText="Channel" DataField="Channel" SortExpression="Channel">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubChannel" HeaderText="Sub Class" SortExpression="SubChannel">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AgentTypeDesc" HeaderText="Member Type" SortExpression="AgentTypeDesc">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RelationType" HeaderText="Relation Type" SortExpression="RelationType" />
                                                <asp:TemplateField SortExpression="AgentType" HeaderText="Member Code" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMemTyp" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lbldwnlsmsg" runat="server" CssClass="standardlabel" Text="No Downlines Found"
                                            Visible="false" ForeColor="Red"></asp:Label>
                                   <%-- </div>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                        </div>                       
                        </div>
                    </div>
              </div>
                
               
                </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlTransferType" EventName="SelectedIndexChanged" />  

            </Triggers>
        </asp:UpdatePanel>
        <div>
            <div class="row">
                <div class="col-md-12" style="text-align: center">
                    <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                        OnClick="btnUpdate_Click">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Transfer
                    </asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="btnApprove" runat="server" CssClass="btn btn-sample" Visible="false"
                        CausesValidation="false" OnClick="btnApprove_Click">
                                  <span class="glyphicon glyphicon-ok-circle" style="color:White"> </span> Approve
               
                    </asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-sample" Visible="false"
                        CausesValidation="false" OnClick="btnReject_Click" >
                                  <span class="glyphicon glyphicon-remove-circle" style="color:White"> </span> Reject
               
                    </asp:LinkButton>
                    &nbsp;
                    <%--   <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="standardbutton" Width="80px"
                                        CausesValidation="False" OnClick="btnCancel_Click" />--%>
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                        OnClick="btnCancel_Click" >
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
               
                    </asp:LinkButton>
                    &nbsp;
                </div>
            </div>
        </div>
        <%--<tr>
                <td>--%>
                    <asp:UpdatePanel ID="updMgr" runat="server">
                        <ContentTemplate>
                            <input id="hdnAgntType" type="hidden" runat="server" />
                            <asp:HiddenField ID="hdnNRptMgr" runat="server" />
                            <asp:HiddenField ID="hdnRptMgr1" runat="server" />
                            <asp:HiddenField ID="hdnRptMgr2" runat="server" />
                            <asp:HiddenField ID="hdnRptMgr3" runat="server" />
                            <input id="hdnPriMandatory" type="hidden" runat="server" />
                            <input id="hdnMgr1Mandatory" type="hidden" runat="server" />
                            <input id="hdnMgr2Mandatory" type="hidden" runat="server" />
                            <input id="hdnMgr3Mandatory" type="hidden" runat="server" />
                            <input id="hdnNwUntcd" type="hidden" runat="server" />
                            <input id="hdnchn" type="hidden" runat="server" />
                            <input id="hdnsubchn" type="hidden" runat="server" />
                              <input id="hdnunitchn" type="hidden" runat="server" />
                            <input id="hdnunitsubchn" type="hidden" runat="server" />
                            <input type="hidden" id="hdnPriMemTyp" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <input id="hdnID210" type="hidden" runat="server" />
                    <input id="hdnID220" type="hidden" runat="server" />
                    <input id="hdnID240" type="hidden" runat="server" />
                    <input id="hdnID250" type="hidden" runat="server" />
                    <input id="hdnID260" type="hidden" runat="server" />
                    <input id="hdnID270" type="hidden" runat="server" />
                    <input id="hdnID280" type="hidden" runat="server" />
                    <input id="hdnID290" type="hidden" runat="server" />
                    <input id="hdnID300" type="hidden" runat="server" />
                    <input id="hdnID310" type="hidden" runat="server" />
                    <input id="hdnID320" type="hidden" runat="server" />
                    <input id="hdnID330" type="hidden" runat="server" />
                    <input id="hdnID340" type="hidden" runat="server" />
                    <input id="hdnID360" type="hidden" runat="server" />
                    <input id="hdnID370" type="hidden" runat="server" />
                    <input id="hdnID380" type="hidden" runat="server" />
                    <input id="hdnID390" type="hidden" runat="server" />
                    <input id="hdnID400" type="hidden" runat="server" />
                    <input id="hdnID410" type="hidden" runat="server" />
                    <input id="hdnID420" type="hidden" runat="server" />
                    <input id="hdnID430" type="hidden" runat="server" />
                    <input id="hdnID440" type="hidden" runat="server" />
                    <input id="hdnID450" type="hidden" runat="server" />
                    <input id="hdnID460" type="hidden" runat="server" />
                    <input id="hdnID470" type="hidden" runat="server" />
                    <input id="hdnID480" type="hidden" runat="server" />
                    <input id="hdnID490" type="hidden" runat="server" />
                    <input id="hdnID500" type="hidden" runat="server" />
                    <input id="hdnID510" type="hidden" runat="server" />
                    <input id="hdnID520" type="hidden" runat="server" />
                    <input id="hdnID530" type="hidden" runat="server" />
                    <input id="hdnID550" type="hidden" runat="server" />
                    <input id="hdnID560" type="hidden" runat="server" />
                    <input id="hdnID570" type="hidden" runat="server" />
                    <input id="hdnID580" type="hidden" runat="server" />
                    <input id="hdnID590" type="hidden" runat="server" />
                    <input id="hdnID600" type="hidden" runat="server" />
                    <input id="hdnID620" type="hidden" runat="server" />
                    <input id="hdnID630" type="hidden" runat="server" />
                    <input id="hdnID640" type="hidden" runat="server" />
                    <input id="hdnID650" type="hidden" runat="server" />
                    <input id="hdnID660" type="hidden" runat="server" />
                    <input id="hdncurdate" type="hidden" runat="server" />
                    <input id="hdnAgntRank" type="hidden" runat="server" />
                    <input id="hdnAgntLevel" type="hidden" runat="server" />
                    <input id="hdnAgntClass" type="hidden" runat="server" />
                    <input id="hdnCSCCode" type="hidden" runat="server" />
                    <input id="hdnAgnCreateRul" type="hidden" runat="server" />
                    <input id="hdnUnitRank" type="hidden" runat="server" />
                    <input id="hdnMicr" type="hidden" runat="server" />
                    <input id="hdnChkCnt" type="hidden" runat="server" />
                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    <asp:HiddenField ID="hdnPan" runat="server" />
                    <input id="hdnEndDate" type="hidden" runat="server" />
                    <input id="hdnPaymentmode" type="hidden" runat="server" />
                    <input id="hdnAgentType" type="hidden" runat="server" />
                    <input id="HdnSlschnl" type="hidden" runat="server" />
                    <input id="hdnagtcode" type="hidden" runat="server" />
                    <input id="hdnagtname" type="hidden" runat="server" />
                    <input id="hdnrptrule" type="hidden" runat="server" />
                    <input id="hdnHomeTel" type="hidden" runat="server" />
                    <input id="hdnemail1" type="hidden" runat="server" />
                    <input id="hdnmarsts" type="hidden" runat="server" />
                    <input id="hdnUntCode" type="hidden" runat="server" />
                    <input id="hdnCltDOB" type="hidden" runat="server" />
                    <input id="hdnMobTel" type="hidden" runat="server" />
                    <input id="hdnNtlty" type="hidden" runat="server" />
                    <input id="hdnOccup" type="hidden" runat="server" />
                    <input id="hdnTitle" type="hidden" runat="server" />
                    <input id="hdnName" type="hidden" runat="server" />
                    <input id="hdnCapital" type="hidden" runat="server" />
                    <input id="hdnResAddr" type="hidden" runat="server" />
                    <input id="hdnBusiAddr" type="hidden" runat="server" />
                    <input id="hdnPermAddr" type="hidden" runat="server" />
                    <input id="hdnStateP" type="hidden" runat="server" />
                    <input id="hdnStateB" type="hidden" runat="server" />
                    <input id="hdnStatePrm" type="hidden" runat="server" />
                    <input id="hdnDistrP" type="hidden" runat="server" />
                    <input id="hdnDistrB" type="hidden" runat="server" />
                    <input id="hdnPinP" type="hidden" runat="server" />
                    <input id="hdnPinB" type="hidden" runat="server" />
                    <input id="hdnPinPrm" type="hidden" runat="server" />
                    <input id="hdnCntryCP" type="hidden" runat="server" />
                    <input id="hdnCntryCB" type="hidden" runat="server" />
                    <input id="hdnCntryCPrm" type="hidden" runat="server" />
                    <input id="hdnagttyp" type="hidden" runat="server" />
                    <input id="hdnsapcode" type="hidden" runat="server" />
                    <input id="hdnUnitCode" type="hidden" runat="server" />
                    <input id="hdnBizsrc" type="hidden" runat="server" />
                    <input id="hdnChncls" type="hidden" runat="server" />
                    
                    <asp:UpdatePanel runat="server" ID="upnlRule">
                        <ContentTemplate>
                            <input id="hdnCreateRule" type="hidden" runat="server" />
                            <input id="hdnAppRule" type="hidden" runat="server" />
                            <input id="hdnEMPCode" type="hidden" runat="server" />
                            <input id="hdnMemType" type="hidden" runat="server" />
                            <input id="hdnRelOrder" type="hidden" runat="server" />
                            <input id="hdnRptSetup" type="hidden" runat="server" />
                            <asp:HiddenField ID="hdnRptMgr" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="upnlUntRule">
                        <ContentTemplate>
                            <input id="hdnUntRule" type="hidden" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
            <%--    </td>
            </tr>--%>
        
    </center>
    <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="false" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" Width="600" Height="400" display="none" ScrollBars="Both" CssClass="panel ">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 110%"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" CssClass="modal-content" Width="450px" Height="310px">
        <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">
            <br />
            <br />
            <asp:Label ID="lbl3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl4" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl5" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <div class="modal-footer" style="text-align: center;padding: 10px;">
            <asp:LinkButton ID="btnok" runat="server" CssClass="btn btn-sample"> <%--OnClientClick="javascript:done();"--%>
                <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
                </asp:LinkButton>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

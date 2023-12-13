<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AGTPromotion.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_AGTPromotion" %>

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
  
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
 
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



        function addCssClassByClick(flag) {
            debugger;

            if (flag == 1) {

                //alert("Hello");
                $("#ctl00_ContentPlaceHolder1_Hierarchy").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Primary").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Additional").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Downlines").removeClass("btn-subtab")

            }

            else if (flag == 2) {
                //  alert("Hello11");
                $("#ctl00_ContentPlaceHolder1_Hierarchy").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Primary").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Additional").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Downlines").removeClass("btn-subtab")

            }

            else if (flag == 3) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_Hierarchy").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Primary").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Additional").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Downlines").removeClass("btn-subtab")

            }

            else if (flag == 4) {
                //  alert("Hello11");
                //alert("Hello");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Downlines").addClass("btn-subtab btn btn-default")

            }

            else if (flag == 5) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_PrimDwd").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_AddDwd").removeClass("btn-subtab")


            }
            else if (flag == 6) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_AddDwd").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_PrimDwd").removeClass("btn-subtab")


            }

            else if (flag == 7) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").removeClass("btn-subtab")


            }

            else if (flag == 8) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").removeClass("btn-subtab")


            }

            else if (flag == 9) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").addClass("btn-subtab btn btn-default")


            }

            else if (flag == 10) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_lnkbtnCF").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_lnkbtnCU").removeClass("btn-subtab")



            }

            else if (flag == 11) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_lnkbtnCF").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_lnkbtnCU").addClass("btn-subtab btn btn-default")



            }

        }

        var path = "<%=Request.ApplicationPath.ToString()%>";

        function validation() {
            //debugger;
            var sUnitRank = document.getElementById('<%=hdUnitRank.ClientID%>');
            var AgPro = document.getElementById('<%=ddlAgPro.ClientID%>');
            var NewAgnType = document.getElementById('<%=ddl_NewAgnType.ClientID%>');
            var txtRemark = document.getElementById('<%=txtRemark.ClientID%>');
            var NewUntCode = document.getElementById('<%=txtNewUntCode.ClientID%>');
            var EffDate = document.getElementById('<%=txtEffectdt.ClientID%>');
            var PrmType = document.getElementById('<%=ddlPromoType.ClientID%>');
            var KPI = document.getElementById('<%=ddlKPIParam.ClientID%>');
            var Bizsrc = document.getElementById("ctl00_ContentPlaceHolder1_hdnBizsrc").value;
            var PgParam = document.getElementById("ctl00_ContentPlaceHolder1_hdnPageParam").value;
            var PrimRptMgr = document.getElementById('<%=txtRptMgr.ClientID%>');

            if (PgParam == "PR") {

                if (AgPro.value == "" || AgPro.value == "--Select--") {
                    alert("Agent Promotion field can not be blank");
                    return false;
                }
                if (NewAgnType.value == "" || NewAgnType.value == "--Select--") {
                    alert("New Agent Type field can not be blank");
                    return false;
                }
                if (txtRemark.value == "") {
                    alert("Remark can not be blank");
                    return false;
                }
                //                if (NewUntCode.value == "" || NewUntCode.value == "--Select--") {
                //                    alert("New Unit Code can not be blank");
                //                    return false;
                //                }
            }
            if (EffDate.value == "") {
                alert("Effective Date can not be blank");
                return false;
            }
        }

        function ShowReqDtls(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
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

        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, strAgentType, stragttyp, stragent, strbsdon, struntcd) {
            debugger;
            //alert(struntcd);
            var PrimMgr = document.getElementById('<%=hdnPrimRptMgrcode.ClientID%>');
            var untcode = document.getElementById('<%=hdnUntCode.ClientID%>');
            ////var TxtNewUntCode = document.getElementById('<%=txtNewUntCode.ClientID%>').value;
            //            if (TxtNewUntCode == "") {
            //                alert('no new unitcode');
            //                document.getElementById('<%=hdnUntCode.ClientID %>').value = "";
            //            }
            //            alert(stragttyp);
            var primStp = document.getElementById('<%=hdnPrimStp.ClientID%>').value;
            var chnl = document.getElementById('<%=hdnBizsrc.ClientID %>').value;
            var schnl = document.getElementById('<%=hdnChncls.ClientID %>').value;
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnPrimRptMgrcode.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtRptMgr.ClientID %>').value + "&field1=" + document.getElementById('<%=hdnPrimRptMgrcode.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc + "&flag=" + stragent + "&chkflag=1"
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + struntcd
        + "&field3=" + document.getElementById('<%=lblPrimRptMgrcode.ClientID %>').id + "&bsdon=" + strbsdon + "&rptstp=" + primStp + "&memtyp=" + strAgentType
        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById('<%=hdnRptSetup.ClientID %>').value
        + "&ddl=" + document.getElementById('<%=ddlPrimagttype.ClientID %>').id + "&MemCode=" + document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText
        + "&mdlpopup=mdlViewBID&isPrimary=Y";
            }
        }

        debugger;
        function funcgridMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon, rowid, struntcode, rwid) {
            debugger;
            var PrimMgr = document.getElementById('<%=hdnPrimRptMgrcode.ClientID%>').value;
            var untcode = document.getElementById('<%=hdnUntCode.ClientID%>').value;
            var strAgentType = document.getElementById('<%=ddl_NewAgnType.ClientID%>').value;
            var chnl = document.getElementById('<%=hdnBizsrc.ClientID %>').value;
            var schnl = document.getElementById('<%=hdnChncls.ClientID %>').value;
            if (strPopUpType == "rptmgr") {
                //                if (PrimMgr.value == "" || untcode.value == "") {
                //                    alert("Please select Primary Manager and Unitcode first.");
                //                    return false;
                //                }
                $find("mdlViewBID").show();
                if (struntcode == '') {
                    alert(strAgentType);
                    /////alert('aaaaaaa');
                    //                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
                    //        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
                    //        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
                    //        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnUntCode.ClientID %>').value
                    //        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon
                    //        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
                    //        + "&MemCode=" + document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText
                    //        + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id
                    //        + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value + "&memtyp=" + strAgentType
                    //        + "&rowid=" + rwid
                    //        + "&hdn=" + document.getElementById(rowid + "_hdnrowid").id
                    //        + "&mdlpopup=mdlViewBID&isPrimary=N";
                }
                else {
                    //alert("modal12");
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + struntcode
        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon
        + "&chnl=" + chnl + "&schnl=" + schnl + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
        + "&MemCode=" + document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText
        + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id
        + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value + "&memtyp=" + strAgentType
        + "&rwid=" + rwid
        + "&hdn=" + document.getElementById("ctl00_ContentPlaceHolder1_hdnrowid").id
        + "&mdlpopup=mdlViewBID&isPrimary=N";
                }
            }
        }


        function fununtpopup(strvalue, strqstring, strAgentType, strprimagttyp, strMgr) {
            debugger;
            if (strvalue == "untcode") {
                alert(strMgr);
                var sNewAgtType = document.getElementById('<%=ddl_NewAgnType.ClientID%>');
                var sNewRptCode = document.getElementById('<%=hdnPrimRptMgrcode.ClientID%>');
                if (sNewAgtType.value == "" || sNewAgtType.value == "-- Select --" || sNewAgtType.value == "--Select--" || sNewAgtType.value == "0") {
                    alert("Please select new agnet type.");
                    return false;
                }
                //                if (sNewRptCode.value == "") {
                //                    alert("Please select New Reporting Manager.");
                //                    return false;
                //                }
                $find("mdlViewBID").show();   //document.getElementById('<%=hdnPrimRptMgrcode.ClientID%>') != null
                if (strMgr != '') {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblUnitDesc.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + document.getElementById("<%=hdnBizsrc.ClientID%>").value
                + "&ChnCls=" + document.getElementById("<%=hdnChncls.ClientID%>").value + "&UntAdr=" + document.getElementById("<%=lblUntAddr.ClientID%>").id
                + "&AgentType=" + document.getElementById("<%=ddl_NewAgnType.ClientID%>").value + "&MgrCode=" + strMgr
                + "&agttype=" + document.getElementById("<%=ddl_NewAgnType.ClientID%>").value + "&hdn2=" + document.getElementById("<%=hdnuntadr.ClientID%>").id
                + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').id + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=lblUnitDesc.ClientID%>').id + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=AE&mdlpopup=mdlViewBID";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblUnitDesc.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + document.getElementById("<%=hdnBizsrc.ClientID%>").value
                + "&ChnCls=" + document.getElementById("<%=hdnChncls.ClientID%>").value + "&UntAdr=" + document.getElementById("<%=lblUntAddr.ClientID%>").id
                + "&AgentType=" + document.getElementById("<%=ddl_NewAgnType.ClientID%>").value + "&MgrCode="
                + "&agttype=" + document.getElementById("<%=ddl_NewAgnType.ClientID%>").value + "&hdn2=" + document.getElementById("<%=hdnuntadr.ClientID%>").id
                + "&Type=" + strqstring + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                + "&OutUntCode=" + document.getElementById('<%=txtNewUntCode.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=lblUnitDesc.ClientID%>').id + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=AE&mdlpopup=mdlViewBID";
                }
            }
        }

        function funOpenPopWinForUntCode(struntsrch) {

            if (struntsrch == "RptUnitSearch") {
                var sNewAgtType = document.getElementById('<%=ddlPrimagttype.ClientID%>');
                var sNewRptCode = document.getElementById('<%=txtRptMgr.ClientID%>');

                if (sNewAgtType.value == "" || sNewAgtType.value == "-- Select --" || sNewAgtType.value == "--Select--" || sNewAgtType.value == "0") {
                    alert("Please select new agnet type.");
                    return false;
                }

                if (sNewRptCode.value == "") {
                    alert("Please select reporting head code.");
                    return false;
                }
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "AgtUnitCodeSearch.aspx?sValue=" +
            document.getElementById("<%=txtRptMgr.ClientID%>").value + "&rptuntcode=" + document.getElementById("<%=txtNewUntCode.ClientID%>").value +
            "&agentcode=" + document.getElementById("<%=lblAgtCodeVal.ClientID%>").innerText + "&newagenttype=" + document.getElementById("<%=ddl_NewAgnType.ClientID%>").value +
            "&strrptuntcode=" + document.getElementById("<%=txtNewUntCode.ClientID%>").id + "&mdlpopup=mdlViewBID";
            }
        }



        function funblankRptMgr() {//debugger;
            if (document.getElementById('<%=txtRptMgr.ClientID %>') != null) {
                if (document.getElementById('<%=txtRptMgr.ClientID %>').value == "") {
                    document.getElementById('<%=lblPrimRptMgrcode.ClientID %>').innerText = "";
                    document.getElementById('<%=hdnPrimRptMgrcode.ClientID %>').value = "";
                }
            }
        }

        function funblankuntcode() {//debugger;
            if (document.getElementById('<%=txtNewUntCode.ClientID %>').value == "") {
                document.getElementById('<%=lblUnitDesc.ClientID %>').innerText = "";
                document.getElementById('<%=hdnUntCode.ClientID %>').value = "";
                document.getElementById('<%=hdnuntadr.ClientID %>').value = "";



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
        .btn-tab
        {
            color: #3c763d;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }
        
         .nav-tabs > li.active > a,
        .nav-tabs > li.active > a:hover,
        .nav-tabs > li.active > a:focus {
            color: #ffffff;
            background-color: #034ea2;
        }
        
        ul#menu li a:active
        {
            background: white;
        }
        
        
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
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
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() != undefined) {
                args.set_errorHandled(true);
            }
        }
    </script>
    <style>
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
    </style>
    <style type="text/css">
        .dataTable
        {
            width: 100% !important;
            clear: both;
            margin-top: 5px;
            border: none;
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
            z-index: 100px;
        }
        .form-submit-button
        {
            box-shadow: none !important;
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
        
        .transbox
        {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            z-index: inherit;
        }
        
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <table width="80%" border="0" style="border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <%-- <table width="100%" style="border-collapse: collapse; background-image: url(Images\background.jpg);
            height: 18px;">
            <tr align="center">
                <td>--%>
        <asp:UpdatePanel ID="up_UnitR" runat="server">
            <ContentTemplate>
                <%--  <div id="divpersnldtlsHdr" runat="server" style="width: 90%;padding-right: 1px;" class="divBorder1">
                  <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-search"></i>
                                <asp:Label ID="lblPersonalPart" runat="server"  Text="Personal Particular"  style="padding-right: 10px;"></asp:Label>
                            </div>
                             <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                     <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divpersnldtls','myImg','#myImg');" />
                    </div>
                        </tr>
                    </table>
                --%>
                <div class="panel" style="margin-right:-29datepx;width: 1230px; border-style:none">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpersnldtls','btnNominee');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                
                                <asp:Label ID="lblPersonalPart" runat="server" Text="Personal Particular" Style="padding-right: 10px; font-size:19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2; padding: 1px 10px ! important; font-size: 18px;" ></span>--%>
                                <%--<span id="btnNominee" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                 <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divpersnldtls" class="panel-body" runat="server">
                        <div class="row">
                            <div class="col-sm-10">
                                <div class="row" id="trcltcode" runat="server" visible="false">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblClCode" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblCusmIdVal" runat="server" CssClass="control-label" MaxLength="12"
                                            TabIndex="1"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblCode" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="lblCltCodeVal" runat="server" CssClass="control-label" MaxLength="12"
                                                    TabIndex="3"></asp:Label>
                                                &nbsp;
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lvlVw1AgntCode" runat="server" Font-Bold="False" CssClass="control-label">Agent Code</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="lblAgtCodeVal" runat="server" CssClass="form-control" Enabled="False"
                                            TabIndex="4"></asp:TextBox>
                                        <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" Text="" Visible="false"
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <span>
                                            <asp:Label ID="lblVw1AgntStatus" runat="server" Font-Bold="False" CssClass="control-label">Agent Status</asp:Label>
                                        </span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="lblAgntStatusVal" runat="server" CssClass="form-control" TabIndex="5"
                                            Enabled="False">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblAgntName" runat="server" CssClass="control-label">Agent Name</asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="display: flex;">
                                        <asp:TextBox ID="lblagnTitleVal" runat="server" CssClass="form-control" Enabled="false"
                                            Width="20%"></asp:TextBox>
                                        <asp:TextBox ID="lblAgntNameVal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblGender" runat="server" Text="Gender" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="lblGenderVal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" id="trserv" runat="server" visible="false">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblServName" runat="server" Font-Bold="False" Text="Service Name"
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblServProvInfoVal" runat="server" CssClass="control-label" MaxLength="30"
                                            TabIndex="9"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblExclusive" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RadioButtonList ID="rdlExclusive" CssClass="radiobtn" runat="server" TabIndex="12">
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="panel" style="margin-top: 15px; border-style:none">
                                    <div id="divprmotdmotDtlsHdr" runat="server" class="panel-heading subheader"
                                        onclick="ShowReqDtl('divprmotdmotDtls','Span3');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                                <asp:Label ID="lblbas" Text="Basic Search" runat="server" Style="padding-left: 5px;" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divprmotdmotDtls" class="panel-body" runat="server">
                                        <div id="Div3" class="row" runat="server" visible="false">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" Text="Type of Promotion" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlPromoType" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlPromoType_SelectedIndexChanged">
                                                    <asp:ListItem>Normal Promotion</asp:ListItem>
                                                    <asp:ListItem>Exception Promotion</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="Label2" runat="server" Text="KPI Parameters" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlKPIParam" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>No of Lives</asp:ListItem>
                                                    <asp:ListItem>WRP/TP</asp:ListItem>
                                                    <asp:ListItem>Team Size</asp:ListItem>
                                                    <asp:ListItem>Qualified Advisor</asp:ListItem>
                                                    <asp:ListItem>Persistency</asp:ListItem>
                                                    <asp:ListItem>Health NOL</asp:ListItem>
                                                    <asp:ListItem>AAA</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAgPromotion" runat="server" CssClass="control-label"></asp:Label><span
                                                    style="color: #ff0000">*</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel runat="server" ID="updAgPro">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlAgPro" runat="server" CssClass="form-control" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlAgPro_SelectedIndexChanged">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Value="PRM">Promotion</asp:ListItem>
                                                            <asp:ListItem Value="DEM">Demotion</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblNewAgentType" runat="server" CssClass="control-label"></asp:Label><span
                                                    style="color: #ff0000">*</span>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:UpdatePanel runat="server" ID="updNewAgtType">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddl_NewAgnType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_NewAgnType_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgPro" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>  
                                            </div>
                                     <%--   <div class="row">
                                          
                                        </div>--%>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblEffDt" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtEffectdt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                <asp:TextBox CssClass="form-control" ID="txtDtValidate" Style="display: none" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtdt" runat="server" Visible="false"></asp:TextBox>
                                            </div>
                                        <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblRemark" runat="server" CssClass="control-label"></asp:Label><span
                                                    style="color: #ff0000">*</span>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" Rows="5" Columns="50"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>  </div>
                                        <%--<div class="row">
                                          
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="row">
                                    <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                                    <asp:GridView ID="GridImage" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="footable" HorizontalAlign="Left" PagerStyle-Font-Underline="true"
                                        PagerStyle-ForeColor="blue" PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable">
                                        <RowStyle CssClass="GridViewRow"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="AgentCode" SortExpression="MemCode" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("MemCode") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ImageField ControlStyle-Height="100px" ControlStyle-Width="120px" DataImageUrlField="MemCode"
                                                DataImageUrlFormatString="ImageRet.aspx?ImageID={0}" HeaderText="Preview Image"
                                                NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                            </asp:ImageField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo" Font-Size="12px"
                                    Visible="false"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- <br />--%>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div class="panel" style="margin-top: 15px;width:1230px;border-style:none">
                    <div id="divCurntDtlsHdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCurntDtls','Span6');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblcrntdtls" runat="server" Text="Current Details" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <%--<span id="Span6" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                 <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divCurntDtls" runat="server" class="panel-body">
                        <asp:UpdatePanel ID="updCrntMgrDtls" runat="server">
                            <ContentTemplate>
                                <tr>
                                    <td style="background-color: White;">
                                        <asp:ImageButton ID="lnkCrntHier" runat="server" Visible="false" CssClass="TextBox"
                                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls2.png" OnClick="lnkCrntHier_Click" />
                                        <asp:ImageButton ID="lnkCrntPrimMgr" runat="server" Visible="false" CssClass="TextBox"
                                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager"
                                            OnClick="lnkCrntPrimMgr_Click" />
                                        <asp:ImageButton ID="lnkCrntAddlMgr" runat="server" Visible="false" CssClass="TextBox"
                                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                                            OnClick="lnkCrntAddlMgr_Click" />
                                        <asp:ImageButton ID="lnkCrntDlines" runat="server" Visible="false" CssClass="TextBox"
                                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Downlines2.png" Text="Downlines"
                                            OnClick="lnkCrntDlines_Click" />
                                    </td>
                                </tr>
                                <div id="demo1" class="row" style="text-align: left; margin-left: 20px;margin-bottom: 10px"  runat="server">
                                    <asp:LinkButton ID="Hierarchy" Text="Hierarchy Details" CssClass="btn-subtab btn btn-default"
                                        OnClientClick="return addCssClassByClick('1')" OnClick="Hierarchy_Click" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="Primary" Text="Primary Manager" CssClass=" btn btn-default" OnClientClick="return addCssClassByClick('2')"
                                        OnClick="Primary_Click" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="Additional" Text="Additional Manager" CssClass="btn btn-default"
                                        OnClientClick="return addCssClassByClick('3')" OnClick="Additional_Click" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="Downlines" Text="Downlines" CssClass="btn btn-default" OnClientClick="return addCssClassByClick('4')"
                                        OnClick="Downlines_Click" runat="server"></asp:LinkButton>
                                </div>
                                <div id="HierarchyDiv" runat="server" class="panel" style="margin-top: 15px;display:none; border-style:none;">
                                    <div id="divHirarchyDtlsHdr" runat="server" class="panel-heading subheader"
                                        onclick="ShowReqDtl('divHirarchyDtls','Span1');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                                <asp:Label ID="lblHirarchyDtlshdr" Text="Hierarchy Details" runat="server" Style="padding-left: 5px;" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divHirarchyDtls" class="panel-body" runat="server" style="display: block;">
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblchnltype" runat="server" CssClass="control-label">Channel Type</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                                    <ContentTemplate>
                                                        <asp:RadioButtonList ID="rdbChnlTyp" runat="server" CssClass="radiobtn" AutoPostBack="true"
                                                            CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" TabIndex="21" Enabled="False">
                                                            <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblCntDetails" runat="server" Visible="false" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:LinkButton ID="lnbViewCntDetails" runat="server" TabIndex="11" Visible="false">View Details</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblBusinessSrc" runat="server" Font-Bold="False" CssClass="control-label">Hierarchy Name</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblSlsChannelVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblChnCls" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblChnClsVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblVw1AgntType" runat="server" Font-Bold="False">Agent Type</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblAgntTypeVal" runat="server" Enabled="false" CssClass="form-control"
                                                    TabIndex="24"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAgntClass" runat="server" Font-Bold="False">Agent Class</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblAgntClassVal" runat="server" Enabled="false" CssClass="form-control"
                                                    Text="STAFF" TabIndex="25"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="PrimaryDiv" runat="server" class="panel panel-success" style="margin-top: 15px;display:none; border-style:none;">
                                    <div id="divprirepHdr" runat="server" class="panel-heading subheader"
                                        onclick="ShowReqDtl('divprirep','Span2');return false;">
                                        <div class="row">
                                            <div class="col-sm-10" style="text-align: left">
                                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                                <asp:Label ID="lblPrimaryReportinghdr" Text="Primary Reporting" runat="server" Style="padding-left: 5px;" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divprirep" runat="server" class="panel-body" style="display: block;">
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblddlreportingtype" runat="server" Text="Reporting Type" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblprimrepoVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblbasedon" runat="server" Text="Based On" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblbasedondescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblchannel" runat="server" CssClass="control-label">Hierarchy Name</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblchanneldescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblsubchannel" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblsubchnldescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblReportingMgr" runat="server" Text="Reporting Manager" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblRptMgrVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                                <asp:Label ID="lblrptmgr" runat="server" CssClass="standardlabel"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lbllevelagttype" runat="server" CssClass="control-label">Level/Rel Type</asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lbllvlagtVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="footable">
                                                <RowStyle CssClass="GridViewRow"></RowStyle>
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
                                </div>
                                <div id="AdditionalDiv" runat="server" class="panel panel-success" style="margin-top: 15px;display:none; border-style:none;">
                                    <div id="divMngrDtlsHdr" runat="server" class="panel-heading subheader"
                                        onclick="ShowReqDtl('divMngrDtls','Span5');return false;">
                                        <div class="row" id="tr8" runat="server">
                                            <div class="col-sm-10" style="text-align: left">
                                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                                <asp:Label ID="lblAddlMgrDet" Text="Additional Manager Details" runat="server" Style="padding-left: 5px;" />
                                            </div>
                                            <div class="col-sm-2">
                                                <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divMngrDtls" class="panel-body" runat="server">
                                        <div class="row">
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lbladditionalreporting" runat="server" Text="Additional Reporting Rule"
                                                    CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lbladditionalreportingrule" runat="server" CssClass="control-label"></asp:Label>
                                                <asp:Label ID="lblRptMngrErr" runat="server" ForeColor="Red" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:GridView ID="gv_RptMngr_Crnt" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" OnRowDataBound="gv_RptMngr_Crnt_RowDataBound" CssClass="footable">
                                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                        <ItemTemplate>
                                                            <div class="col-sm-3" style="text-align: left">
                                                                <asp:Label ID="lblMgrHdr" runat="server" Text="Additional Manager" CssClass="control-label"></asp:Label>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Bind("Mngr") %>' CssClass="control-label"></asp:Label>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:DropDownList ID="ddlventype" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" TabIndex="54" AutoPostBack="true" />
                                                                </div>
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                                        TabIndex="50" />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrntAdlRptTyp" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrtAdlBsdOn" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrntAdlChn" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrntAdlSChn" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrntAdlAgtTyp" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                                <div class="col-sm-3" style="text-align: left">
                                                                    <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <asp:Label ID="lblCrntRptMngr" runat="server" CssClass="control-label"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <asp:GridView ID="gvAddlMgr" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="footable">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <RowStyle />
                                                                <PagerStyle CssClass="disablepage" />
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
                                                        </ItemTemplate>
                                                        <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div id="DownlineDiv" runat="server" style='display:none;'>
                                  
                                            <asp:LinkButton ID="lnkbtnCF" Visible="false" runat="server" 
                                                Text="Primary Downline Details" OnClientClick="return addCssClassByClick('10')"
                                                OnClick="lnkbtnCF_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkbtnCU" Visible="false" runat="server" 
                                                Text="Additional Downline Details" OnClientClick="return addCssClassByClick('11')"
                                                OnClick="lnkbtnCU_Click"></asp:LinkButton>
                                       
                                    <div id="Div1" class="row" runat="server" style='margin-top:10px;text-align:center;'>
                                        <asp:LinkButton ID="PrimDwd" Text="Primary Downline Details" CssClass="btn-subtab btn btn-default"
                                        OnClick="PrimDwd_Click" runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="AddDwd" Text="Additional Downline Details" CssClass=" btn btn-default"
                                           OnClick="AddDwd_Click" runat="server"></asp:LinkButton>
                                    </div>
                                    <div id="DownDemo" runat="server" class="panel-body">
                                        <asp:UpdatePanel ID="upDownlines" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gv_TrfDownlines" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    AllowSorting="True" CssClass="footable" OnPageIndexChanging="gv_TrfDownlines_PageIndexChanging"
                                                    OnSorting="gv_TrfDownlines_Sorting">
                                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Member Code" DataField="MemCode" SortExpression="MemCode"
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
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="panel" style="margin-top: 15px;width:1230px;border-style:none">
                    <div id="divuntcodeHdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divuntcode','Span4');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label24" Text="Unit Code Details" runat="server" Style="padding-left: 5px; font-size:19px" />
                            </div>
                            <div class="col-sm-2">
                                <%--<span id="Span4" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                 <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divuntcode" class="panel-body" runat="server">
                        <div class="row">
                            <div align="left" class="col-sm-3">
                                <asp:Label ID="lblCrntUntCode" runat="server" Text="Current Unit Code" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtCrntUntCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                <asp:Label ID="lblCrntUnitDesc" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                            </div>
                            <div class="col-sm-3">
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                AllowSorting="true" CssClass="footable">
                                <RowStyle CssClass="GridViewRow"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="tblRptMgrDtlsNew" runat="server" class="panel" style="margin-top: 15px; width:1230px">
                    <div id="divNewDtlsHdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divNewDtls','Span7');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label17" runat="server" Text="New Details" Style="padding-left: 5px; font-size:19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                               <%-- <span id="Span7" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                 <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divNewDtls" runat="server" class="panel-body">
                        <asp:ImageButton ID="lnkCrntHierNew" Visible="false" runat="server" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls2.png" OnClick="lnkCrntHierNew_Click" />
                        <asp:ImageButton ID="lnkNewPrimMgr" runat="server" Visible="false" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager"
                            OnClick="lnkNewPrimMgr_Click" />
                        <asp:ImageButton ID="lnkNewAddlMgr" runat="server" Visible="false" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                            OnClick="lnkNewAddlMgr_Click" />
                        <div id="Div4" class="row" runat="server">
                            <asp:LinkButton ID="HierarchyNew" Text="Hierarchy Details" CssClass="btn-subtab btn btn-default"
                                OnClientClick="return addCssClassByClick('7')" OnClick="HierarchyNew_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="PrimaryNew" Text="Primary Manager" CssClass=" btn btn-default"
                                OnClientClick="return addCssClassByClick('8')" OnClick="PrimaryNew_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="AdditionalNew" Text="Additional Manager" CssClass="btn btn-default"
                                OnClientClick="return addCssClassByClick('9')" OnClick="AdditionalNew_Click"
                                runat="server"></asp:LinkButton>
                        </div>
                        <div id="divHirarchyDtlsNewHdr" runat="server" class="panel panel-success" style="border-style:none;">
                            <div id="div5" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('divHirarchyDtlsNew','Span8');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                       
                                        <asp:Label ID="Label3" runat="server" Text="Hierarchy Details" Style="padding-right: 10px;"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                       <%-- <span id="Span8" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                         <span id="Span8" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divHirarchyDtlsNew" runat="server" class="panel-body" style="margin-top:0">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label4" runat="server" CssClass="control-label">Channel Type</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblChnlType" runat="server" AutoPostBack="true" CellPadding="2"
                                                    CellSpacing="2" RepeatDirection="Horizontal" TabIndex="21" OnSelectedIndexChanged="rblChnlType_SelectedIndexChanged"
                                                    Enabled="False">
                                                    <asp:ListItem Value="0" Text="&nbspCompany"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="&nbspChannel"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <asp:Label ID="Label5" runat="server" Visible="false" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label6" Text="Hierarchy Name" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="updddlSlsChnl0" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSlsChannel" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" TabIndex="22" Enabled="False">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label7" Text="Sub Class" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="upnlChnCls" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" TabIndex="23" Enabled="False">
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
                                        <asp:Label ID="Label9" Text="Agent Type" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" TabIndex="24" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label11" Text="Agent Class" runat="server" Font-Bold="False" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntClass" runat="server" CssClass="form-control" Enabled="false"
                                            TabIndex="25">
                                            <asp:ListItem Text="Staff" Value="NM"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divprirptHdr" runat="server" class="panel panel-success" style="border-style:none;">
                            <div id="div7" runat="server" class="panel-heading subheader" style="background-color: #EDF1cc !important;"
                                onclick="ShowReqDtl('divprirpt','Span9');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                        <asp:Label ID="lblPrimaryRpthdr" runat="server" Text="Primary Reporting" Style="padding-left: 5px;"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divprirpt" runat="server" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblPrimrpttype" runat="server" Text="Reporting Type" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlPrimRptTyp" runat="server" Enabled="False" CssClass="form-control"
                                            TabIndex="29">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblPrimbasedon" runat="server" Text="Based On" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlPrimbasedon" runat="server" Enabled="False" CssClass="form-control"
                                            TabIndex="32">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblPrimchannel" Text="Hierarchy Name" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlPrimchannel" runat="server" Enabled="False" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblPrimsubchannel" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlPrimsubchannel" runat="server" CssClass="form-control" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label Text="Level/Rel Type" ID="lblPrimagttype" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList ID="ddlPrimagttype" runat="server"   CssClass="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlPrimagttype_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblPrimReportingMgr" runat="server" Text="Reporting Manager" CssClass="control-label"></asp:Label>
                                        <caption>
                                            <span style="color: #ff0000">*</span>
                                        </caption>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left; display: flex;">
                                        <asp:TextBox ID="txtRptMgr" runat="server" CssClass="form-control" TabIndex="34"></asp:TextBox>
                                        <caption>
                                            &nbsp;
                                            <%--onblur="Javascript:funblankRptMgr();"--%>
                                            <asp:Button ID="btnRptMgr" runat="server" CssClass="btn btn-primary" TabIndex="35"
                                                Text="...." />
                                            <asp:Label ID="lblPrimRptMgrcode" runat="server" CssClass="control-label"></asp:Label>
                                            <asp:Button ID="btnmemgrid" runat="server" ClientIDMode="Static" OnClick="btnmemgrid_Click"
                                                Style="display: none;" />
                                        </caption>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvNew" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="footable" OnRowDeleting="gvNew_RowDeleting">
                                            <RowStyle CssClass="GridViewRow"></RowStyle>
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
                                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div style="width: 100%;">
                                                            <i class="fa fa-trash-o"></i>
                                                            <asp:LinkButton ID="DeleteBtn" Text="Delete" ForeColor="Red" CommandName="Delete"
                                                                runat="server" />
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <ajax:AsyncPostBackTrigger ControlID="btnmemgrid" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnmemgrid" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="divNewMngrDtlsHdr" runat="server" class="panel panel-success" style="border-style:none;">
                            <div id="div8" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('divNewMngrDtls','Span10');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                        <asp:Label ID="lblNewMngrDtls" runat="server" Text="Additional Manager Details" Style="padding-left: 5px;"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divNewMngrDtls" class="panel-body" runat="server">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblNewaddlrpt" runat="server" Text="Additional Reporting Rule" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="lblNewaddlrptrule" runat="server" CssClass="control-label"></asp:Label>
                                    <asp:Label ID="lblNewRptMngrErr" runat="server" ForeColor="Red" CssClass="control-label"></asp:Label>
                                </div>
                                <%--<div id="div2" runat="server" class="panel-body">--%>
                                <asp:GridView ID="gv_RptMngr_new" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                    Width="100%" OnRowDataBound="gv_RptMngr_new_RowDataBound">
                                    <HeaderStyle ForeColor="Black" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblMgrHdr" runat="server" Text="Additional Manager" CssClass="control-label"></asp:Label>
                                                    <asp:Label ID="lblNo" runat="server" Text='<%# Bind("Mngr") %>' CssClass="control-label"></asp:Label>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" CssClass="control-label" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlventype" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" TabIndex="54" AutoPostBack="true" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model" CssClass="control-label"></asp:Label>
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                        TabIndex="50" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" CssClass="control-label" />
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <div class="col-sm-3" style="text-align: left">
                                                        <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" CssClass="control-label" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
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
                                                    </tr>
                                                    <tr>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" CssClass="form-control" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" CssClass="control-label" />
                                                            <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false"
                                                                CssClass="control-label" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtRptMngr" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblRptMngr" runat="server" CssClass="control-label" />
                                                            <asp:LinkButton ID="lnkRptMngr" runat="server" Text="view" OnClick="lnkRptMngr_Click"
                                                                Height="29px" Width="29px"></asp:LinkButton>
                                                            <asp:Button ID="btnRptmemgrid" runat="server" OnClick="btnRptmemgrid_Click" ClientIDMode="Static"
                                                                Style="display: none;" />
                                                            <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                            <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                            <asp:HiddenField ID="hdnAddlStp" runat="server" />
                                                            <asp:HiddenField ID="hdnAdMemType" runat="server" />
                                                        </div>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="padding: 3px;">
                                                            <asp:GridView ID="gvNewAddlMgr" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                                Width="100%" OnRowDeleting="gvNewAddlMgr_RowDeleting">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <RowStyle />
                                                                <PagerStyle CssClass="disablepage" />
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
                                                                    <asp:TemplateField ShowHeader="False" ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <div style="width: 100%;">
                                                                                <i class="fa fa-trash-o"></i>
                                                                                <asp:LinkButton ID="DeleteBtn" Text="Delete" ForeColor="Red" CommandName="Delete"
                                                                                    runat="server" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                </div>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="divNEWuntcodeHdr" runat="server" class="panel panel-success" style="border-style:none;">
                            <div id="div2" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl('divNEWuntcode','Span11');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                        <asp:Label ID="Label10" runat="server" Text="Unit Code Details"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <%--<span id="Span11" class="glyphicon glyphicon-resize-full" style="float: right; color: Orange;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                                         <span id="Span11" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divNEWuntcode" runat="server" class="panel-body" style="margin-top:0">
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:Label ID="lblNewUntCode" runat="server" CssClass="control-label"></asp:Label><span
                                        style="color: #ff0000"> *</span>
                                </div>
                                <div class="col-sm-3" style="display: flex;">
                                    <asp:UpdatePanel ID="updunt" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtNewUntCode" runat="server" CssClass="form-control" onblur="Javascript:funblankuntcode();"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars=",#$@%^!*&amp; ''%^~`<>=?./|\{}[]:+;-"
                                                TargetControlID="txtNewUntCode">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <%-- AutoPostBack="true" ontextchanged="txtNewUntCode_TextChanged"--%>
                                            <asp:Button ID="btnRptUnitSearch" runat="server" CssClass="btn btn-primary" Text="...."
                                                UseSubmitBehavior="False" />
                                            <asp:Label ID="lblUnitDesc" Style="display: none" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                                            <asp:Label ID="lblUntAddr" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            <asp:Button ID="btnunitgrid" runat="server" OnClick="btnunitgrid_Click" ClientIDMode="Static"
                                                Style="display: none;" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:GridView ID="gvNewUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                    AllowSorting="true" CssClass="footable" OnRowDeleting="gvNewUntLst_RowDeleting">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <div style="width: 100%;">
                                                    <i class="fa fa-trash-o"></i>
                                                    <asp:LinkButton ID="DeleteBtn" Text="Delete" ForeColor="Red" CommandName="Delete"
                                                        runat="server" />
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div class="row" style="margin-top: 12px;">
            <div class="col-sm-12" align="center">
                <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" CausesValidation="true"
                    Text="Update" OnClick="btnUpdate_Click" OnClientClick="javascript:validate();"
                    TabIndex="43"> <span class="glyphicon glyphicon-floppy-disk" style='color: White;'></span> Update </asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"
                    OnClick="btnCancel_Click"> <span class="glyphicon glyphicon-remove  BtnGlyphicon"></span> Cancel </asp:LinkButton>
            </div>
        </div>
        <table class="form-actions fluid" style="width: 90%;">
            <tr>
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                    <asp:Button ID="btnApprove" runat="server" Text="APPROVE" Visible="false" CssClass="btn blue"
                        OnClick="btnApprove_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnReject" runat="server" Text="REJECT" Visible="false" CssClass="btn blue"
                        OnClick="btnReject_Click" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdUnitRank" runat="server" />
                    <%--Added by swapnesh on 30/12/2013 for pan verification start--%>
                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    <%--Added by swapnesh on 30/12/2013 for pan verification end--%>
                    <input id="hdnEndDate" type="hidden" runat="server" />
                    <input id="hdnPaymentmode" type="hidden" runat="server" />
                    <input id="hdnAgentType" type="hidden" runat="server" />
                    <input id="HdnSlschnl" type="hidden" runat="server" />
                    <input id="hdnagtcode" type="hidden" runat="server" />
                    <input id="hdnagtname" type="hidden" runat="server" />
                    <input id="hdnrptrule" type="hidden" runat="server" />
                    <input id="hdnCltDOB" type="hidden" runat="server" />
                    <input id="hdnName" type="hidden" runat="server" />
                    <input id="hdnCapital" type="hidden" runat="server" />
                    <input id="hdnchn" type="hidden" runat="server" />
                    <input id="hdnsubchn" type="hidden" runat="server" />
                    <input id="hdnagttyp" type="hidden" runat="server" />
                    <input id="hdnBizsrc" type="hidden" runat="server" />
                    <input id="hdnChncls" type="hidden" runat="server" />
                    <asp:HiddenField ID="hdnrowid" runat="server" />
                    <input id="hdnCreateRule" type="hidden" runat="server" />
                    <input id="hdnAppRule" type="hidden" runat="server" />
                    <input id="hdnEMPCode" type="hidden" runat="server" />
                    <input id="hdnUntRule" type="hidden" runat="server" />
                    <input id="hdnUntCode" type="hidden" runat="server" />
                    <input id="hdnuntadr" type="hidden" runat="server" />
                    <asp:HiddenField ID="hdnPrimRptMgrcode" runat="server" />
                    <asp:HiddenField ID="hdnPrimAgtType" runat="server" />
                    <asp:HiddenField ID="hdnPageParam" runat="server" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <input id="hdnRptSetup" type="hidden" runat="server" />
                            <input id="hdnRptStp" type="hidden" runat="server" />
                            <input id="hdnPrimStp" type="hidden" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:HiddenField ID="hdnTrfRefNo" runat="server" />
                </td>
            </tr>
        </table>
        <%--</td>
            </tr>
        </table>--%>
    </center>
    <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0" 
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="true" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlMdl" ScrollBars="Both" Width="600" Height="355" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="100%" frameborder="0" display="none" scrolling="auto"
            style="height: 100%"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
  <%--  <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" 
        BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
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
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" CssClass="standardbutton" />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>--%>

        <asp:Panel ID="pnl" runat="server" CssClass="modal-content" Width="450px" Height="310px">
        <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">
           
            <asp:Label ID="lbl3" runat="server"></asp:Label>
           
            <asp:Label ID="lbl4" runat="server"></asp:Label>
       
            <asp:Label ID="lbl5" runat="server"></asp:Label>
            <br />
            <br />

             <asp:LinkButton ID="btnok" runat="server"  CausesValidation="true"
                CssClass="btn btn-sample"> 
                <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
                </asp:LinkButton>
        </div>
     <%--   <div class="modal-footer" style="text-align: center">
             <asp:LinkButton ID="btnok" runat="server"  CausesValidation="true"
                CssClass="btn btn-sample"> 
                <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
                <%--</asp:LinkButton>--%>--%>
             <%--<asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" CssClass="standardbutton" />--%>
      <%--  </div>--%>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" Y="100">
    </ajaxToolkit:ModalPopupExtender>

</asp:Content>

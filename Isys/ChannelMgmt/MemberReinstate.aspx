<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MemberReinstate.aspx.cs" Inherits="Application_INSC_ChannelMgmt_MemberReinstate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script language="javascript" type="text/javascript">


        function popup() {
            $("#myModal").modal();
        }


        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                  //  objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
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

            }

            else if (flag == 2) {
                //  alert("Hello11");
                $("#ctl00_ContentPlaceHolder1_Hierarchy").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Primary").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Additional").removeClass("btn-subtab")

            }

            else if (flag == 3) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_Hierarchy").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Primary").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Additional").addClass("btn-subtab btn btn-default")

            }

            else if (flag == 4) {
                //  alert("Hello11");
                //alert("Hello");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").removeClass("btn-subtab")

            }

            else if (flag == 5) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").removeClass("btn-subtab")

            }
            else if (flag == 6) {
                //alert("Hello111");
                $("#ctl00_ContentPlaceHolder1_HierarchyNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_PrimaryNew").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_AdditionalNew").addClass("btn-subtab btn btn-default")


            }

        }


        var path = "<%=Request.ApplicationPath.ToString()%>";
        var strContent = "ctl00_ContentPlaceHolder1_";

        function funValidate() {
            //debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + "hdnPriMandatory") != null) {
                if (document.getElementById(strContent + "hdnPriMandatory").value != "") {
                    if (document.getElementById(strContent + "hdnPriMandatory").value == "True") {
                        if (document.getElementById(strContent + "hdnNRptMgr").value == "") {
                            alert("Please Fill Primary Reporting Details");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "hdnMgr1Mandatory") != null) {
                if (document.getElementById(strContent + "hdnMgr1Mandatory").value = "") {
                    if (document.getElementById(strContent + "hdnMgr1Mandatory").value == "True") {
                        if (document.getElementById(strContent + "hdnRptMgr1").value == "") {
                            alert("Please Fill Additional Reporting Manager1 Details");
                            return false;
                        }
                    }
                }
            }

            if (document.getElementById(strContent + "hdnMgr2Mandatory") != null) {
                if (document.getElementById(strContent + "hdnMgr2Mandatory").value != "") {
                    if (document.getElementById(strContent + "hdnMgr2Mandatory").value == "True") {
                        if (document.getElementById(strContent + "hdnRptMgr2").value == "") {
                            alert("Please Fill Additional Reporting Manager2 Details");
                            return false;
                        }
                    }
                }
            }

            if (document.getElementById(strContent + "hdnMgr3Mandatory") != null) {
                if (document.getElementById(strContent + "hdnMgr3Mandatory").value != "") {
                    if (document.getElementById(strContent + "hdnMgr3Mandatory").value == "True") {
                        if (document.getElementById(strContent + "hdnRptMgr3").value == "") {
                            alert("Please Fill Additional Reporting Manager3 Details");
                            return false;
                        }
                    }
                }
            }
        }






        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, strAgentType, stragttyp, stragent, strbsdon) {
            debugger;
            var PrimMgr = document.getElementById('<%=hdnPrmyRptMgr.ClientID%>');
            var untcode = document.getElementById('<%=hdnUntCode.ClientID%>');
            var primStp = document.getElementById('<%=hdnPrimStp.ClientID%>').value;
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnPrmyRptMgr.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtRptMgr.ClientID %>').value + "&field1=" + document.getElementById('<%=hdnPrmyRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc + "&flag=" + stragent + "&chkflag=1"
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnUntCode.ClientID %>').value
        + "&field3=" + document.getElementById('<%=lblrptmgr.ClientID %>').id + "&bsdon=" + strbsdon + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value
        + "&memtyp=" + strAgentType + "&chnl=" + document.getElementById('<%=hdnBizsrc.ClientID %>').value + "&rptsetup=" + document.getElementById('<%=hdnRptSetup.ClientID %>').value
        + "&ddl=" + document.getElementById('<%=ddllvlagttype.ClientID %>').id
        + "&MemCode=" + document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText
        + "&isPrimary=Y"
        + "&schnl=" + document.getElementById('<%=hdnChncls.ClientID %>').value + "&mdlpopup=mdlViewBID";
            }
        }

        function funcgridMgrShowPopup(strPopUpType, strbzsrc, strsbclass, strAgentType, stragttyp, stragent, strbsdon, rowid) {
            debugger;
            var PrimMgr = document.getElementById('<%=hdnPrmyRptMgr.ClientID%>');
            var untcode = document.getElementById('<%=hdnUntCode.ClientID%>');
            if (strPopUpType == "rptmgr") {
                if (PrimMgr != null && untcode != null) {
                    if (PrimMgr.value == "" || untcode.value == "") {
                        alert("Please select Primary Manager and Unitcode first.");
                        return false;
                    }
                }
                else if (untcode != null) {
                    if (untcode.value == "") {
                        alert("Please select Unitcode first.");
                        return false;
                    }
                }
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById(rowid + "_hdnAddlRptMgr").value
        + "&Desc=" + document.getElementById(rowid + "_txtRptMngr").value + "&field1=" + document.getElementById(rowid + "_hdnAddlRptMgr").id
        + "&field2=" + document.getElementById(rowid + "_txtRptMngr").id + "&bizsrc=" + strbzsrc + "&chkflag=2" + "&flag=" + stragent
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp + "&untcd=" + document.getElementById('<%=hdnUntCode.ClientID %>').value
        + "&field3=" + document.getElementById(rowid + "_lblRptMngr").id + "&bsdon=" + strbsdon + "&rptstp=" + document.getElementById(rowid + "_hdnAdMemType").value
        + "&chnl=" + document.getElementById('<%=hdnBizsrc.ClientID %>').value + "&schnl=" + document.getElementById('<%=hdnChncls.ClientID %>').value
        + "&MemCode=" + document.getElementById('<%=lblAgtCodeVal.ClientID %>').innerText
        + "&memtyp=" + strAgentType + "&mdlpopup=mdlViewBID" + "&rptsetup=" + document.getElementById(rowid + "_hdnAddlStp").value
        + "&ddl=" + document.getElementById(rowid + "_ddlAdlAgtTyp").id;
            }
        }

        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }

        //        function fununtpopup(strvalue, strqstring, strIsAgent, argBizSrc, argSubChncls, argAgntType) {
        //            if (strvalue == "untcode") {

        //                $find("mdlViewBID").show();

        //                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUnitCode.ClientID %>').value
        //                + "&CmpUntObj=" + document.getElementById('<%=lblNewUnitCode.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + argBizSrc + "&ChnCls=" + argSubChncls
        //                + "&AgentType=" + argAgntType + "&agttype=" + argAgntType + "&MgrCode=" + document.getElementById('<%=hdnPrmyRptMgr.ClientID%>').value + "&Type=" + strqstring
        //                + "&OutUntCode=" + document.getElementById('<%=txtNewUnitDesc.ClientID %>').id + "&OutUntDesc=" + document.getElementById('<%=txtUnitCode.ClientID%>').id
        //                + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id + "&UntAdr=" + document.getElementById('<%=lblNewUntAddr.ClientID %>').id
        //                + "&hdn2=" + document.getElementById('<%=hdnNewUntAddr.ClientID %>').id + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent
        //                + "&mdlpopup=mdlViewBID";
        //            }
        //        }

        function fununtpopup(strvalue, strqstring, strIsAgent, argBizSrc, argSubChncls, argAgntType) {
            ////debugger;
            var strAgentType;
            if (strvalue == "untcode") {
                var sNewRptCode = document.getElementById('<%=hdnPrmyRptMgr.ClientID%>');
                var element = document.getElementById('<%=ddllvlagttype.ClientID%>');
                if (typeof (element) != 'undefined' && element != null)
                { strAgentType = document.getElementById('<%=ddllvlagttype.ClientID%>').value; } //To handle the case when the User Selects the CH as the Agent Type -- Modified: Parag @ 02042014
                else
                { strAgentType = document.getElementById('<%=hdnPriMemTyp.ClientID%>').value; }

                $find("mdlViewBID").show();
                if (document.getElementById('<%=hdnPrmyRptMgr.ClientID%>') != null) {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUnitCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblNewUnitCode.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + argBizSrc
                + "&ChnCls=" + argSubChncls + "&UntAdr=" + document.getElementById("<%=lblNewUntAddr.ClientID%>").id
                + "&AgentType=" + strAgentType + "&MgrCode=" + document.getElementById('<%=hdnPrmyRptMgr.ClientID%>').value
                + "&agttype=" + argAgntType + "&hdn2=" + document.getElementById("<%=hdnNewUntAddr.ClientID%>").id
                + "&Type=" + strqstring + "&OutUntCode=" + document.getElementById('<%=txtNewUnitDesc.ClientID %>').id + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=txtUnitCode.ClientID%>').id + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent
                + "&mdlpopup=mdlViewBID";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "UntLst.aspx?UnitCode=" + document.getElementById('<%=txtUnitCode.ClientID %>').value
                + "&CmpUntObj=" + document.getElementById('<%=lblNewUnitCode.ClientID %>').id + "&UntObj=''" + "&BizSrc=" + argBizSrc
                + "&ChnCls=" + argSubChncls + "&UntAdr=" + document.getElementById("<%=lblNewUntAddr.ClientID%>").id
                + "&AgentType=" + strAgentType + "&MgrCode="
                + "&agttype=" + argAgntType + "&hdn2=" + document.getElementById("<%=hdnNewUntAddr.ClientID%>").id
                + "&Type=" + strqstring + "&hdn1=" + document.getElementById('<%=hdnUntCode.ClientID %>').id
                + "&OutUntCode=" + document.getElementById('<%=txtNewUnitDesc.ClientID %>').id
                + "&OutUntDesc=" + document.getElementById('<%=txtUnitCode.ClientID%>').id + "&OutCmpUnt=''" + "&RecruitDate=''" + "&Source=1" + "&IsAgt=" + strIsAgent
                + "&mdlpopup=mdlViewBID";
                }
            }
        }

        function funblankRptMgr() {
            if (document.getElementById('<%=txtRptMgr.ClientID %>').value == "") {
                document.getElementById('<%=lblrptmgr.ClientID %>').innerText = "";
                document.getElementById('<%=hdnRptMgr.ClientID %>').value = "";
            }
        }

        function funblankUntCode() {
            if (document.getElementById('<%=txtNewUnitDesc.ClientID %>').value == "") {
                document.getElementById('<%=lblNewUnitCode.ClientID %>').innerText = "";
                document.getElementById('<%=hdnUntCode.ClientID %>').value = "";
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="~/Scripts/common.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/subModal.js"></script>
    <style type="text/css">
        .btn-subtab {
            color: white;
            background-color: #034ea2 !important;
            border-color: white;
        }

        .btn-tab {
            color: #3c763d;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus {
            color: #555555;
            background-color: #dff0d8;
        }

        ul#menu li a:active {
            background: white;
        }

        .demo{
            border: 1px solid black;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }



                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>
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
        <%--  <div class="container">--%>
        <%-- <table width="100%" class="formtable2">
                        <tr>
                            <td align="left" colspan="8" class="test formHeader">
                                <input runat="server" type="button" class="inputBtn" value="-" id="btnprsnldtlscollapse"
                                    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','ctl00_ContentPlaceHolder1_btnprsnldtlscollapse');" />
                                <asp:Label ID="lblPersonalPart" runat="server"  Text="Personal Particular"></asp:Label>
                            </td>
                        </tr>
                    </table>--%>
        <div class="panel " style="margin-top: 15px;">
            <div id="divprmotdmotDtlsHdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divpersnldtls','Span3');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblPersonalPart" runat="server" Text="Personal Particular" Font-Size="19px"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divpersnldtls" runat="server" style="display: block;" class="panel-body">
                <div class="row">
                    <div class="col-sm-10">
                        <div style='display: none;' class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblClCode" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblCusmIdVal" Enabled="false" runat="server" CssClass="form-control"
                                    MaxLength="12"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="lblCltCodeVal" Enabled="false" runat="server" CssClass="form-control"
                                            MaxLength="12"></asp:TextBox>
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lvlVw1AgntCode" CssClass="control-label" runat="server" Font-Bold="False">Agent Code</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblAgtCodeVal" runat="server" CssClass="form-control" Enabled="False"
                                   ></asp:TextBox>
                            </div>
                            <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" Text="" Visible="false"></asp:Label>
                            <div class="col-sm-3" style="text-align: left">
                                <span>
                                    <asp:Label ID="lblVw1AgntStatus" runat="server" CssClass="control-label" Font-Bold="False">Agent Status</asp:Label>
                                </span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblAgntStatusVal" runat="server" CssClass="form-control" Enabled="false"
                                    ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAgntName" CssClass="control-label" Text="Agent Name" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblAgntNameVal" runat="server" CssClass="form-control" MaxLength="125"
                                   ></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblGender" CssClass="control-label" runat="server" Text="Gender"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblGenderVal" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblServName" runat="server" CssClass="control-label" Font-Bold="False"
                                    Text="Service Name"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblServProvInfoVal" Enabled="false" runat="server" CssClass="form-control"
                                    MaxLength="30" ></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblExclusive" CssClass="control-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButtonList ID="rdlExclusive" CssClass="radiobtn" runat="server" >
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="panel " style="margin-top: 15px;">
                            <div id="divMemberReinstatement" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divReinstate','Span12');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color:#034ea2"></span>
                                        <asp:Label ID="lblReinstatementSectionTitle" runat="server" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span12" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divReinstate" runat="server" style="display: block;" class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblMemberReinstateReason" CssClass="control-label" runat="server"></asp:Label><span
                                            style="margin-left: -3px; color: #ff0000"> *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlMemberReinstateReason" CssClass="form-control" runat="server"
                                            >
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblReinstatementDateTtl" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="lblReinstatementDate" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRemarks" CssClass="control-label" runat="server"></asp:Label><span
                                            style="color: Red; margin-left: -3px;"> *</span>
                                    </div>
                                    <div class="col-sm-6" style="text-align: left">
                                        <textarea id="txtRemarks" runat="server" style='width: 47%;' cssclass="form-control"></textarea>
                                    </div>
                                </div>
                            </div>
                            <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo" Font-Size="12px"
                                Visible="false"></asp:LinkButton>
                        </div>
                        <div class="panel " style="margin-top: 15px;">
                            <div id="div7" runat="server" class="panel-heading subheader" 
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divuntcode','Span88');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color:#034ea2"></span>
                                        <asp:Label ID="Label24" runat="server" Text="Unit Code Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span88" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divuntcode" runat="server" style="display: block;" class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblUnit" CssClass="control-label" Text="Unit" runat="server"></asp:Label>
                                            <span style="margin-left: -3px; color: #ff0000;">*</span>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left; display: flex;">
                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtUnitCode" runat="server" Enabled="false" CssClass="form-control"
                                                        MaxLength="10" ></asp:TextBox>
                                                    <asp:Button ID="btnEditUnitCode" runat="server" CssClass="btn btn-verify" 
                                                        Text="...." Visible="false" Width="20px" />
                                                    <asp:Label ID="lblUntDr" Style="display: none" runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label ID="lblUntcd" Style="display: none" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblUntAddr" runat="server" Text=""></asp:Label>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="col-sm-2">
                            <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                            <asp:GridView ID="GridImage" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="footable" HorizontalAlign="Left" PagerStyle-Font-Underline="true"
                                PagerStyle-ForeColor="blue" PagerStyle-HorizontalAlign="Center">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="AgentCode" SortExpression="MemCode" Visible="false">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("MemCode") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ImageField ControlStyle-Height="100px" DataImageUrlField="MemCode" DataImageUrlFormatString="ImageRet.aspx?ImageID={0}"
                                       ItemStyle-CssClass="demo" HeaderText="Preview Image" NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                    </asp:ImageField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </div>--%>
        <%--<table width="100%" class="formtable2">
                        <tr>
                            <td align="left" colspan="8" class="test formHeader">
                                <input runat="server" type="button" class="standardlink" value="-" id="btnCurrentDtls"
                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divReportingMngrDtls','ctl00_ContentPlaceHolder1_btnCurrentDtls');"
                                    visible="true" />
                             
                                <asp:Label ID="Label1" runat="server"   Text="Current Details"></asp:Label>
                            </td>
                        </tr>
                    </table>--%>
        <div class="panel " style="margin-top: 15px;">
            <div id="div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divReportingMngrDtls','Span1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label1" runat="server" Text="Current Details" Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divReportingMngrDtls" runat="server" class="panel-body" style="display: block;"
                width="100%">
                <asp:UpdatePanel ID="updCrnttabs" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="lnkCrntHier" runat="server" Visible="false" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls1.png" Text="Primary Manager"
                            OnClick="lnkCrntHier_Click" />
                        <asp:ImageButton ID="lnkCrntPrimMgr" runat="server" Visible="false" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager"
                            OnClick="lnkCrntPrimMgr_Click" />
                        <asp:ImageButton ID="lnkCrntAddlMgr" runat="server" Visible="false" CssClass="TextBox"
                            BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                            OnClick="lnkCrntAddlMgr_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="demo1" class="row" runat="server">
                    <asp:LinkButton ID="Hierarchy" Text="Hierarchy Details" CssClass="btn-subtab btn btn-default"
                        OnClientClick="return addCssClassByClick('1')" OnClick="Hierarchy_Click" runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="Primary" Text="Primary Manager" CssClass=" btn btn-default" OnClientClick="return addCssClassByClick('2')"
                        OnClick="Primary_Click" runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="Additional" Text="Additional Manager" CssClass="btn btn-default"
                        OnClientClick="return addCssClassByClick('3')" OnClick="Additional_Click" runat="server"></asp:LinkButton>
                </div>
                <div id="HierarchyDtl" runat="server" class="panel " style="margin-top: 15px;
                    display: none;">
                    <div id="div8" runat="server" class="panel-heading subheader"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHirarchyDtls','Span9');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                <asp:Label ID="lblHirarchyDtlshdr" runat="server" Text="Hierarchy Details" CssClass="subheader"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span9" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divHirarchyDtls" runat="server" class="panel-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblchnltype" runat="server" CssClass="control-label">Channel Type</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdbChnlTyp" Enabled="false" runat="server" AutoPostBack="true"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCntDetails" CssClass="control-label" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:LinkButton ID="lnbViewCntDetails" runat="server" Visible="false">View Details</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblBusinessSrc" runat="server" CssClass="control-label" Font-Bold="False">Hierarchy Name</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="lblSlsChannelVal" runat="server" CssClass="form-control" Enabled="false"
                                            AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblChnCls" runat="server" CssClass="control-label">Sub Class</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblChnClsVal" runat="server" CssClass="form-control" Enabled="false"
                                   ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVw1AgntType" runat="server" CssClass="control-label" Font-Bold="False">Agent Type</asp:Label>
                                &nbsp;
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblAgntTypeVal" runat="server" Enabled="false" CssClass="form-control"
                                   ></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAgntClass" CssClass="control-label" runat="server" Font-Bold="False">Agent Class</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblAgntClassVal" runat="server" Enabled="false" CssClass="form-control"
                                    ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="PrimaryDtl" runat="server" class="panel " style="margin-top: 15px;">
                    <div id="div9" runat="server" class="panel-heading subheader"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprirep','Span10');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                <asp:Label ID="lblPrimaryReportinghdr" runat="server" Text="Primary Reporting" CssClass="subheader"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span10" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divprirep" runat="server" style="display: block;" width="100%" class="panel-body   ">
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblddlreportingtype" CssClass="control-label" runat="server" Text="Reporting Type"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblprimrepoVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblbasedon" CssClass="control-label" runat="server" Text="Based On"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblbasedondescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblchannel" CssClass="control-label" runat="server">Hierarchy Name</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblchanneldescVal" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblsubchannel" CssClass="control-label" runat="server">Sub Class</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lblsubchnldescVal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblReportingMgr" runat="server" CssClass="control-label" Text="Reporting Manager"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRptMgrVal" runat="server" CssClass="form-control"></asp:Label>&nbsp
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbllevelagttype" CssClass="control-label" runat="server">Level/Rel Type</asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="lbllvlagtVal" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="AdditionalDtl" runat="server" class="panel " style="margin-top: 15px;">
                    <div id="div10" runat="server" class="panel-heading subheader"
                        onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMngrDtls','Span11');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                <asp:Label ID="lblAddlMgrDet" runat="server" Text="Additional Manager Details" CssClass="subheader"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span11" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divMngrDtls" runat="server" class="panel-body" style="display: block;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lbladditionalreporting" CssClass="control-label" runat="server" Text="Additional Reporting Rule"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="lbladditionalreportingrule" CssClass="form-control" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblRptMngrErr" runat="server" CssClass="form-control" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:GridView ID="gv_RptMngr_Crnt" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" PageSize="5" OnRowDataBound="gv_RptMngr_Crnt_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                        <ItemTemplate>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblMgrHdr" runat="server" Text="Additional Manager"></asp:Label>
                                                <asp:Label ID="lblNo" runat="server" Text='<%# Bind("Mngr") %>'></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" />
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:DropDownList ID="ddlventype" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary"  AutoPostBack="true" />
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                   />
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" />
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblCrntAdlRptTyp" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" />
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblCrtAdlBsdOn" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblCrntAdlChn" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblCrntAdlSChn" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblCrntAdlAgtTyp" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="lblCrntRptMngr" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
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
        <asp:UpdatePanel ID="upNewD" runat="server">
            <ContentTemplate>
                <%--  <table id="tblNewDts" runat="server" class="tableIsys" width="100%">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" class="formtable2"> 
                                                    <tr style="height: 20px;">
                                                        <td align="left" colspan="8" class="test formHeader">
                                                            <input runat="server" type="button" class="standardlink" value="-" id="btnNewDtlscollapse"
                                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNewDtls','ctl00_ContentPlaceHolder1_btnNewDtlscollapse');"
                                                                visible="true" />
                                                            <asp:Label ID="Label17" runat="server"   Text="New Details"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>--%>
                <div class="panel " style="margin-top: 15px;">
                    <div id="div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divNewDtls','Span2');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label17" runat="server" Text="New Details" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span2" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divNewDtls" runat="server" style="display: block;" class="panel-body">
                        <td style="background-color: White;">
                            <asp:UpdatePanel ID="upNewDtlsTabs" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="lnkCrntHierNew" runat="server" Visible="false" CssClass="TextBox"
                                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls1.png" Text="Primary Manager"
                                        OnClick="lnkCrntHierNew_Click" />
                                    <asp:ImageButton ID="lnkCrntPrimMgrNew" runat="server" Visible="false" CssClass="TextBox"
                                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" Text="Primary Manager"
                                        OnClick="lnkCrntPrimMgrNew_Click" />
                                    <asp:ImageButton ID="lnkCrntAddlMgrNew" runat="server" Visible="false" CssClass="TextBox"
                                        BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" Text="Addl. Managers"
                                        OnClick="lnkCrntAddlMgrNew_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <div id="Div11" class="row" runat="server">
                            <asp:LinkButton ID="HierarchyNew" Text="Hierarchy Details" CssClass="btn-subtab btn btn-default"
                                OnClientClick="return addCssClassByClick('4')" OnClick="HierarchyNew_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="PrimaryNew" Text="Primary Manager" CssClass=" btn btn-default"
                                OnClientClick="return addCssClassByClick('5')" OnClick="PrimaryNew_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="AdditionalNew" Text="Additional Manager" CssClass="btn btn-default"
                                OnClientClick="return addCssClassByClick('6')" OnClick="AdditionalNew_Click"
                                runat="server"></asp:LinkButton>
                        </div>
                        <div id="HierarchyDemo" runat="server" class="panel " style="margin-top: 15px;
                            display: none;">
                            <div id="div3" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHirarchyDtlsNew','Span4');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label2" runat="server" Text="Hierarchy Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span4" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divHirarchyDtlsNew" class="panel-body" runat="server" style="display: block;">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label3" Text="Channel Type" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblChnlType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    Enabled="false">
                                                    <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label4" runat="server" CssClass="control-label" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="txtHierarchy" CssClass="control-label" runat="server" Text="Hierarchy Name"
                                            Font-Bold="False"></asp:Label><span style="color: Red; margin-left: -3px;"> *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="updddlSlsChnl0" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSlsChannel" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblSubClass" Text="Sub Class" CssClass="control-label" runat="server"></asp:Label><span
                                            style="color: Red; margin-left: -3px;"> *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="upnlChnCls" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="form-control"
                                                    >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblAgtType" runat="server" Text="Agent Type" CssClass="control-label"
                                            Font-Bold="False"></asp:Label><span style="color: Red; margin-left: -3px;"> *</span>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                           >
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblAgtClass" runat="server" CssClass="control-label" Text="Agent Class"
                                            Font-Bold="False"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlAgntClass" runat="server" CssClass="form-control" Enabled="false"
                                           >
                                            <asp:ListItem Text="Staff" Value="NM"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="PrimaryDemo" runat="server" class="panel " style="margin-top: 15px;
                            display: none;">
                            <div id="div4" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprirepNew','Span5');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="lblPrmyRptg" runat="server" Text="Primary Reporting" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span5" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divprirepNew" runat="server" class="panel-body" style="display: block;">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRptTyp" runat="server" CssClass="control-label" Text="Reporting Type"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlamrptdesc" runat="server" CssClass="form-control" >
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblBasedOn2" runat="server" CssClass="control-label" Text="Based On"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlambasedondesc" runat="server" CssClass="form-control" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblHierarchy2" Text="Hierarchy Name" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList ID="ddlamchnldesc" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblSubClass2" runat="server" CssClass="control-label" Text="Sub Class"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddlamsubchnldesc" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRepMgr" runat="server" CssClass="control-label" Text="Reporting Manager"></asp:Label>
                                        <span style="color: Red; margin-left: -3px;">*</span>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left; display: flex;">
                                        <asp:TextBox ID="txtRptMgr" runat="server" CssClass="form-control" MaxLength="10"
                                             onblur="funblankRptMgr();return false;" OnTextChanged="txtRptMgr_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>&nbsp;&nbsp;
                                        <asp:Button ID="btnRptMgr" runat="server" CssClass="btn btn-verify" 
                                            Text="...." OnClick="btnRptMgr_Click" />
                                         <asp:Button ID="btnmemgrid" runat="server" OnClick="btnmemgrid_Click" ClientIDMode="Static"
                                            Style="display: none;" />
                                        <asp:Label ID="lblrptmgr" runat="server" CssClass="control-label"></asp:Label>
                                        <asp:HiddenField ID="hdnMemType" runat="server" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRelType" runat="server" CssClass="control-label" Text="Level/Rel Type"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddllvlagttype" runat="server" CssClass="form-control"
                                            OnSelectedIndexChanged="ddllvlagttype_SelectedIndexChanged">
                                        </asp:DropDownList>
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
                            </div>
                        </div>
                        <div id="AdditionalDemo" runat="server" class="panel " style="margin-top: 15px;
                            display: none;">
                            <div id="div5" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMngrDtlsNew','Span6');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="Label10" runat="server" Text="Additional Manager Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span6" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divMngrDtlsNew" runat="server" class="panel-body" style="display: block;">
                                <div class="row">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="Label13" runat="server" CssClass="control-label" Text="Additional Reporting Rule"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblNwaddtnlreptrule" runat="server"></asp:Label>
                                        <asp:Label ID="lblRptRulErr" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                                <asp:GridView ID="gv_RptMngr_new" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" PageSize="5" Width="100%" OnRowDataBound="gv_RptMngr_new_RowDataBound">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                            <ItemTemplate>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblMgrHdr" runat="server" Text="Additional Manager"></asp:Label>
                                                    <asp:Label ID="lblNo" runat="server" Text='<%# Bind("Mngr") %>'></asp:Label>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlventype" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chkisprimry" runat="server" Text="Is Primary" AutoPostBack="true" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblRelModel" runat="server" Text="Relationship Model"></asp:Label>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlRelModel" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="lnkViewMDtls" runat="server" Visible="false" Text="View Details"
                                                        />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlAdlChn" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlAdlSChn" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAdlAgtTyp_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" />
                                                    <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false" />
                                                </div>
                                                <div class="col-sm-3" style="text-align: left">
                                                    <asp:TextBox ID="txtRptMngr" runat="server" CssClass="standardtextbox" OnTextChanged="txtRptMngr_TextChanged"></asp:TextBox>
                                                    <asp:Label ID="lblRptMngr" runat="server" />
                                                    <asp:Button ID="lnkRptMngr" runat="server" Text="view" OnClick="lnkRptMngr_Click">
                                                    </asp:Button>
                                                    <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                    <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                    <asp:HiddenField ID="hdnAddlStp" runat="server" />
                                                    <asp:HiddenField ID="hdnAdMemType" runat="server" />
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="panel " style="margin-top: 15px;">
                            <div id="div6" runat="server" class="panel-heading subheader"
                                onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divNEWuntcode','Span7');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                        <asp:Label ID="lblNewUntDtls" runat="server" Text="Unit Details" CssClass="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span7" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divNEWuntcode" runat="server" style="display: block;" class="panel-body">
                                <div id="tblUnitCodeDtls" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:Label ID="lblNewUnit" CssClass="control-label" Text="Unit" runat="server"></asp:Label>
                                                <span style="margin-left: -3px; color: #ff0000;">*</span>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-sm-3" style="display: flex;">
                                                        <asp:TextBox ID="txtNewUnitDesc" runat="server" CssClass="form-control" MaxLength="10"
                                                            onblur="funblankUntCode();return false;" OnTextChanged="txtNewUnitDesc_TextChanged"
                                                            AutoPostBack="true"></asp:TextBox>&nbsp;&nbsp;
                                                        <asp:Button ID="btnUnitCode" runat="server" CssClass="btn btn-verify"
                                                            OnClick="btnunitgrid_Click" Text="...." Visible="true" />
                                                        <asp:Label ID="lblNewUnitCode" runat="server"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label ID="lblUnitd" Style="display: none" CssClass="control-label" runat="server"></asp:Label>
                                            <div class="col-sm-3" style="text-align: left">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblNewUntAddr" runat="server" Text=""></asp:Label>
                                                        <asp:HiddenField ID="hdnNewUntAddr" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="margin-bottom: 5px;">
                                        <%-- <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true" 
                                                AllowSorting="true" Width="100%" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                                PageSize="8" PagerStyle-Font-Underline="true" PagerStyle-HorizontalAlign="Center">--%>
                                    <div>   
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
                                        </asp:GridView></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- <table class="tableIsys" style="width: 100%;">
                                                                    <tr style="height: 20px;">
                                                                        <td class="test" colspan="4" style="text-align: left;">
                                                                            <asp:Label ID="lblNewUntDtls" runat="server" Text="Unit Details" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>--%>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row" style="margin-top: 12px;">
            <div class="col-sm-12" align="center">
                <asp:LinkButton ID="btnReinstate" runat="server" CssClass="btn btn-sample" CausesValidation="true"
                    Text="REINSTATE" OnClick="btnReinstate_Click" OnClientClick="javascript:validate();"
                    > <span class="	glyphicon glyphicon-repeat" style='color: White;'></span> Reinstate</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sample BtnGlyphicon"
                    OnClick="btnCancel_Click"> <span class="glyphicon glyphicon-remove  BtnGlyphicon"></span> Cancel </asp:LinkButton>
            </div>
        </div>
        <div>
            <table>
                <%--<tr>
                                <td class="formcontent" align="right">
                                    <asp:Button ID="btnReinstate" runat="server" Text="REINSTATE" CssClass="standardbutton"
                                        OnClick="btnReinstate_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnApprove" Visible="false" runat="server" Text="APPROVE" CssClass="standardbutton"
                                        OnClick="btnApprove_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnReject" Visible="false" runat="server" Text="REJECT" CssClass="standardbutton"
                                        OnClick="btnReject_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="standardbutton"
                                        CausesValidation="False" OnClick="btnCancel_Click"  />
                                </td>
                            </tr>--%>
                <tr>
                    <td>
                        <input type="hidden" id="hdnRptMgr" runat="server" />
                        <input type="hidden" id="hdnPrmyRptMgr" runat="server" />
                        <input type="hidden" id="hdnPriMemTyp" runat="server" />
                        <input type="hidden" id="hdnRptSetup" runat="server" />
                        <input id="hdncurdate" type="hidden" runat="server" />
                        <input id="hdnAgntRank" type="hidden" runat="server" />
                        <input id="hdnAgntType" type="hidden" runat="server" />
                        <input id="hdnAgntLevel" type="hidden" runat="server" />
                        <input id="hdnAgntClass" type="hidden" runat="server" />
                        <input id="hdnCSCCode" type="hidden" runat="server" />
                        <input id="hdnAgnCreateRul" type="hidden" runat="server" />
                        <input id="hdnUnitRank" type="hidden" runat="server" />
                        <input id="hdnMicr" type="hidden" runat="server" />
                        <input id="hdnChkCnt" type="hidden" runat="server" />
                        <%--Added by swapnesh on 30/12/2013 for pan verification start--%>
                        <asp:HiddenField ID="hdnAgnCode" runat="server" />
                        <asp:HiddenField ID="hdnPan" runat="server" />
                        <%--Added by swapnesh on 30/12/2013 for pan verification end--%>
                        <input id="hdnEndDate" type="hidden" runat="server" />
                        <input id="hdnPaymentmode" type="hidden" runat="server" />
                        <input id="hdnAgentType" type="hidden" runat="server" />
                        <input id="HdnSlschnl" type="hidden" runat="server" />
                        <input id="hdnagtcode" type="hidden" runat="server" />
                        <input id="hdnagtname" type="hidden" runat="server" />
                        <%-- Ibrahim..to retrive values--%>
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
                        <input id="hdnchn" type="hidden" runat="server" />
                        <input id="hdnsubchn" type="hidden" runat="server" />
                        <input id="hdnagttyp" type="hidden" runat="server" />
                        <input id="hdnUntAdr" type="hidden" runat="server" />
                        <input id="hdnPriMandatory" type="hidden" runat="server" />
                        <input id="hdnMgr1Mandatory" type="hidden" runat="server" />
                        <input id="hdnMgr2Mandatory" type="hidden" runat="server" />
                        <input id="hdnMgr3Mandatory" type="hidden" runat="server" />
                        <input id="hdnBizsrc" type="hidden" runat="server" />
                        <input id="hdnChncls" type="hidden" runat="server" />
                        <input id="hdnAgntTyp" type="hidden" runat="server" />
                        <asp:HiddenField ID="hdnPrimStp" runat="server" />
                        <%--Added by rachana for addditional mgr start--%>
                        <asp:UpdatePanel runat="server" ID="upnlRule">
                            <ContentTemplate>
                                <input id="hdnCreateRule" type="hidden" runat="server" />
                                <input id="hdnAppRule" type="hidden" runat="server" />
                                <input id="hdnEMPCode" type="hidden" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server" ID="upnlUntRule">
                            <ContentTemplate>
                                <input id="hdnUntRule" type="hidden" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </center>
    <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="true" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Ibrahim--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="350" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="500" frameborder="0"
            display="none" style="height: 380px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--<asp:Panel runat="server" ID="Panel1" Width="850" display="none">
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                        <asp:Label ID="Label5" Text="INFORMATION" runat="server"></asp:Label>
                    </div>
                    <div class="modal-body" style="text-align: center">
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbl4" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbl5" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbl6" runat="server"></asp:Label>
                        <asp:Label ID="lbl7" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbl8" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px;'>
                            <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>--%>
      <asp:Panel ID="pnl" runat="server" CssClass="modal-content" Width="450px" Height="220px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="modal-header" colspan="1" style="height: 32px">
                    <asp:Label ID="lblTitle" runat="server" Text="INFORMATION" Font-Bold="true" Font-Size="19px" />
                </td>
            </tr>
        </table>
        <table class="modal-body" style="text-align: center; width:100%; margin-top:20px">
            <tr>
                <td>
                    
                        <asp:Label ID="lbl3" CssClass="control-label" runat="server"></asp:Label><br />
                </td>
                <tr><td>
                        <asp:Label ID="lbl4" CssClass="control-label" runat="server"></asp:Label><br />
                    </td>
                    </tr>
                <tr><td>
                        <asp:Label ID="lbl5" CssClass="control-label" runat="server"></asp:Label><br />
                </td>
            </tr>
        </table>
        <div class="modal-footer" style="text-align: center">
            <asp:Button ID="btnok" runat="server" Text="OK" Width="80px" CssClass="btn btn-sample" />
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        OkControlID="btnok" X="406" Y="160">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

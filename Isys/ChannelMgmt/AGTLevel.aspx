<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AGTLevel.aspx.cs" Inherits="INSCL.AGTLevel"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<Comment>--%>
    

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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        function funcShowPopupLOB() {
            debugger;
            $find("mdlViewBIDLOB").show();
            var prdcode = document.getElementById('<%= hdnprdcode.ClientID%>').value;
            var ProdcodeEdit = document.getElementById('<%= hdnProdcodeEdit.ClientID%>').value;
            var Chntype = document.getElementById('<%= hdnChntype.ClientID%>').value;
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblChannel') != null) {
                var Bizsrc = document.getElementById('ctl00_ContentPlaceHolder1_lblChannel').innerText;
            }
            else { var Bizsrc = ""; }
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblSalesChannelVal') != null) {
                var ChnName = document.getElementById('ctl00_ContentPlaceHolder1_lblSalesChannelVal').innerText;
            }
            else {
                var ChnName = "";
            }
            if (document.getElementById('ctl00_ContentPlaceHolder1_lblAgtTypeVal') != null) {
                var MemTypeDesc = document.getElementById('ctl00_ContentPlaceHolder1_lblAgtTypeVal').innerText;
            }
            else {
                var MemTypeDesc = "";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "../../../Application/ISys/ChannelMgmt/LOBDtls.aspx?mdlpopup=MdlPopExtndrLOB" + "&hdnprodcode=" + prdcode + "&Flag=" + ProdcodeEdit + "&Bizsrc=" + Bizsrc + "&ChnType=" + Chntype + "&ChnName=" + ChnName + "&MemTypeDesc=" + MemTypeDesc;
        }
        function popup() {
            $("#myModalPop").modal();
        }

        funcShowPopupCease(lnk) {
            debugger;
            var row = lnk.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var Prodcode = row.cells[0].innerText;
            var prodName = row.cells[1].innerText;
            var Effdate = row.cells[2].innerText;
            var Mdlpnlcease = "Mdlpnlcease";
            $find("mdlViewBIDCease").show();
            //  document.getElementById("ctl00_ContentPlaceHolder1_Ifrmcease").src = "../../../Application/ISys/ChannelMgmt/CeaseDtls.aspx?&mdlpopup=Mdlpnlcease";
            document.getElementById("ctl00_ContentPlaceHolder1_Ifrmcease").src = "../../../Application/ISys/ChannelMgmt/CeaseDtls.aspx?mdlpopup=" + 'Mdlpnlcease' + "&Productcode=" + Prodcode + "&ProductName= " + prodName + "&Effectivedate=" + Effdate;
            return false;
        }

        function showPopup() {
            var some_html = '<div style="font-size:10.0pt;font-family:Calibri,sans-serif;color:black;"><p>The maximum score for each pair of questions is 3,total for question A and question B is 3, for example</p><ul><li>If A is very characteristic of you and B is very uncharacteristic, write ‘3’ next to A and ‘0’ next to B. </li><li>If B is very characteristic of you and A is very uncharacteristic, write ‘3’ next to B and ‘0’ next to A. </li><li>If A is somewhat characteristic of you and B is less characteristic, write ‘2’ next to A and ‘1’ next to B. </li><li>If B is somewhat characteristic of you and A is less characteristic, write ‘2’ next to B and ‘1’ next to A </li></ul></div>';
            bootbox.alert(some_html);
            return false;
        }



    </script>

    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtEffDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtCseDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon, struntcode, RptSetup, RelType) {
            debugger;
            var strAgentType = document.getElementById('<%=txtAgtTypeDesc01.ClientID%>').value;
            var chnl = document.getElementById('<%=ddlchannel.ClientID %>').value;//Hierarchy Name
            var schnl = document.getElementById('<%=ddlsubchannel.ClientID %>').value;//Sub Class
            var RptSetup2 = document.getElementById('<%=ddlRptSetup.ClientID %>').value
            var Reltype = document.getElementById('<%=ddlreportingtype.ClientID %>').value//Relationship Type


            stragttyp = document.getElementById('<%=ddllevelagttype.ClientID %>').value //Relation Member Type
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMemType.aspx?Code="
                    + "&Carriercode=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&untcd=" + document.getElementById('<%=ddlUnitRank.ClientID %>').value
                    + "&subchnl=" + strsbclass + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&chnl=" + chnl + "&schnl=" + schnl
                    + "&MemType01=" + document.getElementById('<%=hdnMemCode.ClientID %>').value.toString()
                    + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent + "&agttyp=" + stragttyp
                    + "&RptSetup=" + RptSetup2 + "&RelType=" + Reltype + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBID&isPrimary=Y";
            }
        }

        function funcMgrShowPopupView() {
            debugger;
            var strAgentType = document.getElementById('<%=hdnMemCode.ClientID %>').value.toString();
            var chnl = document.getElementById('<%=ddlchannel.ClientID %>').value;
            var schnl = document.getElementById('<%=ddlsubchannel.ClientID %>').value;
            var RptSetup2 = document.getElementById('<%=ddlRptSetup.ClientID %>').value
            var Reltype = document.getElementById('<%=ddlreportingtype.ClientID %>').value
            //  if (strPopUpType == "rptmgr") {
            $find("ModalPopupviewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "PopViewPage.aspx?&bizsrc=" + chnl + "&schnl=" + schnl +
                "&RptSetup=" + Reltype + "&memtyp=" + strAgentType + "&mdlpopup=ModalPopupviewBID";

            // }
        }

        function funcMgrShowPopupForARD(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon, struntcode, RptSetup, RelType) {
            debugger;
            var strAgentType = document.getElementById('<%=txtAgtTypeDesc01.ClientID%>').value;
            var chnl = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlChn').value;//Hierarchy Name
            var schnl = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlSChn').value;//Sub Class
            var RptSetup2 = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlRptStp').value
            var Reltype = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlRptTyp').value//Relationship Type

            strbzsrc = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlChn').value;//Hierarchy Name
            strsbclass = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlSChn').value;//Sub Class
            stragttyp = document.getElementById('ctl00_ContentPlaceHolder1_dgAddlRpt_ctl02_ddlAdlAgtTyp').value //Relation Member Type
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMemType.aspx?Code="
                    + "&Carriercode=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&untcd=" + document.getElementById('<%=ddlUnitRank.ClientID %>').value
                    + "&subchnl=" + strsbclass + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&chnl=" + chnl + "&schnl=" + schnl
                    + "&MemType01=" + document.getElementById('<%=hdnMemCode.ClientID %>').value.toString()
                    + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent + "&agttyp=" + stragttyp
                    + "&RptSetup=" + RptSetup2 + "&RelType   =" + Reltype + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBID&isPrimary=Y";
            }
        }


    </script>

    <style type="text/css">
        .ajax__calendar {
            position: static;
        }

        .disablepage {
            display: none;
        }

        .subheader {
            font-size: 16px !important;
        }
    </style>

    <script type="text/javascript">
        //added by ajay

        function OpenElement() {
            debugger;
            //var modaliframe = document.getElementById("iframeElement");    
            //modaliframe.src = "../../../PopMemType.aspx";
            $('#myModalRaise1').modal();
        }
        //added by ajay

        function popup() {
            $("#myModal").modal();


        }

        function popupHist() {
            $("#myModal1").modal();
        }

        function ShowReqDtl(divName, btnName) {
            var objnewdiv = document.getElementById(divName);
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
        function ShowReqDtl1(divName, btnName) {
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
        function done() {
            window.location.href = "AGTSearchLvl.aspx";
            return false;
        }
        function isInteger(src, args) {
            var result = false;
            var str = document.getElementById("ctl00_ContentPlaceHolder1_ddlUnitRank").getAttribute("value");
            if (str >= 7 && str <= 120) {
                result = true;
            }
            args.IsValid = result;
        }
        function doValidateName(src, args) {
            var result = true;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtAgtTypeVal").value;
            var iChars = "#%!@&$^*-_+={}[]()|\:;?><,.'~";
            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = false;
                }
            }
            args.IsValid = result;
        }
        function isInteger1(src, args) {
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtAgtTypeVal").getAttribute("value");
            var result = true;
            for (i = 0; i <= 99; i++) {
                if (i == str) {
                    result = false;
                }
                args.IsValid = result;
            }
        }
        function doValidateNumbers(src, args) {
            var result = false;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtAgentLvl").value;
            var iChars = "0123456789";
            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    result = true;
                }
            }

            args.IsValid = result;
        }
        function funcShowPopupMvmt(mvmtrule, chn, schn, memtype, unitrank, bsdon, rmt, flag, lnkbtn) {
            $find("mdlpopupmvmtBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmmvmt").src = "PopMvmtDtls.aspx?mvmtrule=" + mvmtrule
                + "&chn=" + chn + "&subchn=" + schn + "&memtype=" + memtype + "&unitrank=" + unitrank + "&bsdon=" + bsdon + "&rmt=" + rmt + "&flag=" + flag + "&btn=" + lnkbtn + "&mdlpopup=mdlpopupmvmtBID";
        }
        function funcShowPopup(strPopUpType, strcode) {
            if (strPopUpType == "mgr1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopUpAdnMgr.aspx?Code="
                    + "&Carriercode=" + strcode + "&Source=1" + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "mgr2") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopUpAdnMgr.aspx?Code="
                    + "&Carriercode=" + strcode + "&Source=2" + "&mdlpopup=mdlViewBID";
            }

            if (strPopUpType == "mgr3") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopUpAdnMgr.aspx?Code="
                    + "&Carriercode=" + strcode + "&Source=3" + "&mdlpopup=mdlViewBID";
            }
        }
        function funValidateNew() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            var chk = "";
            if (document.getElementById(strContent + "ddlSalesChannel") != null) {
                if (document.getElementById(strContent + "ddlSalesChannel").value == "") {
                    alert("Please Enter Hierarchy Name");
                    document.getElementById(strContent + "ddlSalesChannel").focus();
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlChnnlClass") != null) {
                if (document.getElementById(strContent + "ddlChnnlClass").value == "") {
                    alert("Please Enter Sub Class Name");
                    document.getElementById(strContent + "ddlChnnlClass").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtAgtTypeVal") != null) {
                if (document.getElementById(strContent + "txtAgtTypeVal").value == "") {
                    alert("Please Enter Member Type");
                    document.getElementById(strContent + "txtAgtTypeVal").focus();
                    return false;
                }
                //else if (document.getElementById(strContent + "txtAgtTypeVal").value.length() <2)
                //{
                //    alert("Please Enter Atleast Two Character of Member Type");
                //    document.getElementById(strContent + "txtAgtTypeVal").focus();
                //    return false;

                //}
            }
            if (document.getElementById(strContent + "ddlAgtCreateRul") != null) {
                if (document.getElementById(strContent + "ddlAgtCreateRul").value == "") {
                    alert("Please Enter Member Create Rule");
                    document.getElementById(strContent + "ddlAgtCreateRul").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "ddlUnitRank") != null) {
                if (document.getElementById(strContent + "ddlUnitRank").value == "") {
                    alert("Please Enter Unit Rank");
                    document.getElementById(strContent + "ddlUnitRank").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtAgentLvl") != null) {
                if (document.getElementById(strContent + "txtAgentLvl").value == "") {
                    alert("Please Enter Member Level");
                    document.getElementById(strContent + "txtAgentLvl").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtAgtTypeDesc01") != null) {
                if (document.getElementById(strContent + "txtAgtTypeDesc01").value == "") {
                    alert("Please Enter Member Description");
                    document.getElementById(strContent + "txtAgtTypeDesc01").focus();
                    return false;
                }
            }
            ////Primary Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkPriMand") != null) {
                if (document.getElementById(strContent + "chkPriMand").checked == true) {
                    if (document.getElementById(strContent + "ddlreportingtype").value == "") {
                        alert("Please Enter Primary Relationship Type");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlreportingtype") != null) {
                if (document.getElementById(strContent + "ddlreportingtype").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddllevelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlReportingRule").value == "") {
                        alert("Please Enter Primary Relationship Details");
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlUChnnl").value != null) {
                if (document.getElementById(strContent + "ddlUChnnl").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlUUnitType").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlUnitLoc").value == "") {
                        alert("Please Enter Unit Manager Details");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlUMBasedOn").value != null) {
                if (document.getElementById(strContent + "ddlUMBasedOn").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlUChnnl").value == "") {
                        alert("Please Enter Unit Manager Details");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "chkIsUM") != null) {
                if (document.getElementById(strContent + "chkIsUM").checked == true) {
                    if (document.getElementById(strContent + "ddlUChnnl") != null) {
                        if (document.getElementById(strContent + "ddlUChnnl").value == "") {
                            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlUUnitType").value == "") {
                                alert("Please Enter Unit Manager Details");
                                return false;
                            }
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                }
            }
        }
        function ShowReqDtls(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(document.getElementById(strContent + divId)).slideUp();
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(document.getElementById(strContent + divId)).slideDown();
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
         function funPopUp() {
             debugger;        
            
            var value = document.getElementById('<%= hdnMemCode.ClientID%>').value;
            var Header = "Version History Of Member Type";
            var Flag = "MEMTYPE";
            $find("mdlViewBIDLOB").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeLOB").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDLOB" + "&Header=" + Header + "&Flag=" + Flag;
        }

    </script>

 
    <asp:ScriptManager runat="server" ID="scrmgr"></asp:ScriptManager>

    <center class="container">
        <table width="100%">
            <tr>
                <td align="center" colspan="3" rowspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="False" ForeColor="Red" Height="16px"></asp:Label>
                </td>
            </tr>
        </table>

         <%--added by ajay--%>

         <div class="panel" id="divModification" runat="server" style="display:block;display:block;">
<div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">  
                 <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label21" runat="server" Text="Correction or changes in Member Type Setup"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
                    </div>
                    <div class="col-sm-2">
                         <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>         
           </div>
                <div id="divmodifybody" runat="server" class="panel-body" style="display:block"> 
                   <div class="row" style="margin-bottom:5px;">
                       <div class="col-md-3" style="text-align:left;margin-top: 10px;">
                        <asp:Label ID="lblModMode" Text="Mod mode" runat="server"  CssClass="control-label" /> 
                        <span style="color: #ff0000"> *</span>
                        </div>
                         <div class="col-md-3" style="text-align:left"  >
                        <div class="btn-group"  role="group" style="margin-left: -162px;">
                        
                        <asp:RadioButtonList  ID="rbCorrection" runat="server"  CellPadding="2" CellSpacing="2"  RepeatDirection="Horizontal"  AutoPostBack="true" OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged" >  <%--OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged"--%>
                        <asp:ListItem Text="&nbspCorrection&nbsp"  value="CR" Selected="True"  class="btn btn-default"  />
                        <asp:ListItem Text="&nbspChanges&nbsp"  value="CH"  class="btn btn-default" style="margin-left: 0px;"  />
                     </asp:RadioButtonList>
                               
                    </div>
                       </div>
                        <div class="col-md-3">
                     </div>
                      <div class="col-md-3">
                     </div>
                  </div>
            </div>
        </div>

        <%--added by ajay--%>


        <div class="panel" id="div1" runat="server">
            <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div222','btndiv');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblAgtTypSetup" runat="server" CssClass="control-label"  Font-Size="19px"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btndiv" class="glyphicon glyphicon-chevron-down" style="float: right;
                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="div222" runat="server" class="panel-body" style="display: block">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="divcmphdrcollapse" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMemDtls','btndivMemDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblAgtDtls" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivMemDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divMemDtls" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblSalesChannel" CssClass="control-label" runat="server"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:UpdatePanel ID="upSalesChannel" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="form-control" Visible="False" TabIndex="1"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblSalesChannelVal" runat="server" Visible="False" CssClass="control-label"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblChnCls" runat="server" Style="color: Black" CssClass="control-label"></asp:Label>
                                        <span style="color: Red">*</span><%--<asp:RadioButtonList ID="rdlIsCmpStaff" runat="server" CssClass="radiobtn" 
                                    AutoPostBack="True">
                                </asp:RadioButtonList>--%></div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upSlsSbChannel" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChnnlClass" runat="server" CssClass="form-control" TabIndex="2" OnSelectedIndexChanged="ddlChnnlClass_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvChnCls" runat="server" ControlToValidate="ddlChnnlClass"
                                                    ErrorMessage="Mandatory!" Font-Size="Smaller" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgentType" runat="server" Style="color: Black" CssClass="control-label"></asp:Label>
                                        <span style="color: Red">*</span><%--<span style="font-size: 10pt; color: #ff0000">*</span>--%><%--<asp:RadioButtonList ID="rdlIsCmpStaff" runat="server" CssClass="radiobtn" 
                                    AutoPostBack="True">
                                </asp:RadioButtonList>--%></div>
                                    <div class="col-md-3" style="text-align: left">
                                       <%-- <asp:UpdatePanel ID="Uptpnl" runat="server">
                                                     <ContentTemplate>--%>
                                        <asp:Label ID="lblAgtTypeVal" runat="server" Visible="False" CssClass="control-label"></asp:Label>
                                        <asp:TextBox ID="txtAgtTypeVal" runat="server" Visible="False" CssClass="form-control" OnTextChanged="txtAgtTypeVal_TextChanged"  TabIndex="3" AutoPostBack="true"
                                           onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                   <%-- </contenttemplate> 
                                        </asp:UpdatePanel> --%>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgtCreateRule" runat="server" Style="color: Black" CssClass="control-label"></asp:Label>
                                        <span style="color: Red">*</span><%--                            <asp:RadioButton ID="rdbyes" Text="Yes" runat="server"/>
                            <asp:RadioButton ID="rdbno" Text="No" runat="server"  Checked="true"  />--%><%--<asp:RadioButtonList ID="rdlIsCmpStaff" runat="server" CssClass="radiobtn" 
                                    AutoPostBack="True">
                                </asp:RadioButtonList>--%></div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlAgtCreateRul" runat="server" CssClass="form-control"  TabIndex="4">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvAgnCreateRule" runat="server" ControlToValidate="ddlAgtCreateRul"
                                                    ErrorMessage="Mandatory!" Display="Dynamic" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUnitRank" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUnitRank" runat="server"  TabIndex="5" CssClass="form-control" OnSelectedIndexChanged="ddlUnitRank_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="cvRank" runat="server" ErrorMessage="Invalid UnitRank!"
                                                    Font-Size="Smaller"></asp:CustomValidator>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="rdlAllowPrRept" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgentLevel" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAgentLvl" runat="server" CssClass="form-control"  TabIndex="6" Style="margin-top: 5px;" MaxLength="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="txtAgentLvl"
                                         Display="Dynamic" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvLevel" runat="server" ControlToValidate="txtAgentLvl"
                                            ErrorMessage="Invalid AgentLevel!" ClientValidationFunction="doValidateNumbers"
                                            Font-Size="Smaller"></asp:CustomValidator>
                                        <%-- Primary Reporting Details start--%>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAgentLvlFTX" FilterType="Custom, Numbers"
                                            runat="server" TargetControlID="txtAgentLvl">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgtTypeDesc01" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAgtTypeDesc01" runat="server" CssClass="form-control"  TabIndex="7" MaxLength="50" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDesc1" runat="server" ControlToValidate="txtAgtTypeDesc01"
                                            ErrorMessage="Mandatory!" Display="Dynamic" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAgtTypeDesc01FTX" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            runat="server" ValidChars=" " TargetControlID="txtAgtTypeDesc01">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgtTypeDesc02" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAgtTypeDesc02" runat="server" CssClass="form-control"  TabIndex="8" onChange="javascript:this.value=this.value.toUpperCase();"
                                            Style="margin-top: 5px;" MaxLength="50"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAgtTypeDesc02FTX" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            runat="server" ValidChars=" " TargetControlID="txtAgtTypeDesc02">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAgtTypeDesc03" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAgtTypeDesc03" runat="server" CssClass="form-control"  TabIndex="9" onChange="javascript:this.value=this.value.toUpperCase();"
                                            MaxLength="50"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAgtTypeDesc03FTX" FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers"
                                            runat="server" ValidChars=" " TargetControlID="txtAgtTypeDesc03">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAlwPRept" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upAllowPrRept" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rdlAllowPrRept" runat="server" CssClass="radiobtn2"  TabIndex="10" CellPadding="2"
                                                    CellSpacing="2" RepeatDirection="Horizontal" Width="90px" AutoPostBack="True"
                                                    Style="margin-top: 5px;" OnSelectedIndexChanged="rdlAllowPrRept_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="divCompDetails" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCmpyDtls','btndivCmpyDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblCmpyDtls" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivCmpyDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divCmpyDtls" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAlwSls" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upAllowSls" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2" ID="rdlAllowSls" CellPadding="2"  TabIndex="11" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAlwRecAgent" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upAlwRecAgt" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2" ID="rdlAlwRecAgt" runat="server" CellPadding="2"  TabIndex="12"
                                                    CellSpacing="2" RepeatDirection="Horizontal" Width="90px" AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblIsCmpStaff" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upCmpStaff" runat="server">
                                            <ContentTemplate>
                                                <%--<asp:RadioButtonList ID="rdlIsCmpStaff" runat="server" CssClass="radiobtn" 
                                    AutoPostBack="True">
                                </asp:RadioButtonList>--%>
                                                <asp:DropDownList ID="ddlCmpStaff" runat="server"  TabIndex="13" CssClass="form-control" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="Label1" runat="server" CssClass="control-label"></asp:Label>
                                        <%--commented by akshay dhanji 30/11/2013 start--%>
                                    </div>
                                    <div class="col-md-3">                                    
                                        <asp:UpdatePanel ID="upEmpCode" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rdlEmpCode"  TabIndex="14" runat="server" CssClass="radiobtn2" CellPadding="2"
                                                    CellSpacing="2" RepeatDirection="Horizontal" Width="90px" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblAlwServicing" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2"  TabIndex="15" ID="rdlAllowSer" CellPadding="2" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left; top: 0px; left: 0px;">
                                        <asp:Label ID="lblLicReq" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2"  TabIndex="16" ID="rdlLicReq" CellPadding="2" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <%--commented by akshay dhanji 30/11/2013 end--%>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br /> 
               <%-- Added  by usha  for tax --%>
               <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="div4" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div5','Span1');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="LblTax" Text="Tax & Accounting details" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="div5" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblTDS" runat="server" text="TDS Applicable" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3" runat ="server">
                                        <asp:UpdatePanel id="updatetds" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2"   TabIndex="17" ID="rdlTDS" CellPadding="2" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    

                                
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblCommsion" runat="server" Text="Commission GL Code" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                   <asp:TextBox ID="TxtCommision" runat="server"   TabIndex="18" CssClass="form-control"
                                            MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                      
                                    </div>

                                    </div>
                                     <div class="row" style="margin-bottom: 5px;">

                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblExecption" runat="server" Text="TDS Exemption allowed" CssClass="control-label"></asp:Label>
                                       
                                    </div>
                                    <div class="col-md-3">
                                        
                                        <asp:UpdatePanel ID="UpdateExecption" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="RadioLblExecption"  TabIndex="19" runat="server" CssClass="radiobtn2" CellPadding="2"
                                                    CellSpacing="2" RepeatDirection="Horizontal" Width="90px" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                               
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblothrPayout" runat="server" Text="Other Payout GL Code" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                   <asp:TextBox ID="TextBox1" runat="server"   TabIndex="20" CssClass="form-control"
                                            MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                      
                                    </div>
                               </div>
                                <div class="row" style="margin-bottom: 5px;">


                                 <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblExpUnit" runat="server" Text="TDS Std. Exemption Limit" CssClass="control-label"></asp:Label>
                                    </div>
                                  <div class="col-md-3" style="text-align:right">
                                   <asp:TextBox ID="TextLimit" runat="server"   TabIndex="21"   Text ="15000.00" style="text-align: right"   CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                     <div class="col-md-3"  style="text-align: left">
                                        
                                    </div>
                                    <div class="col-md-3">
                                 
                                    </div>
                                    </div>


                                     <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblGstRegion" runat="server" Text ="GST Regn Required" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2"  TabIndex="22" ID="RadioGstRegion" CellPadding="2" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="True">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblGstpayout"  Text ="GST payout under RCM" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList CssClass="radiobtn2"  TabIndex="23" ID="RadioGstpayout" CellPadding="2" CellSpacing="2"
                                                    RepeatDirection="Horizontal" Width="90px" runat="server" AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    </div>
                                     <div class="row" style="margin-bottom: 5px; display:none;">
                                      <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblRgonno" runat="server" Text="GST Regn Number" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                   <asp:TextBox ID="TextBox2"  TabIndex="24" runat="server" Enabled ="false"  CssClass="form-control"
                                            MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                      
                                    </div>
                                     <div class="col-md-3"  style="text-align: left">
                                        
                                    </div>
                                    <div class="col-md-3">
                                 
                                    </div>
                                    </div>
                                       <div class="row" style="margin-bottom: 5px; display:none;">
                                      <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="LblRegistraction" runat="server" Text="Registration State" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DdlRegistraction"  TabIndex="25" runat="server" CssClass="form-control" AutoPostBack="True"
                                               Enabled ="false"      >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                           
                                        </asp:UpdatePanel>
                                    </div>
                                     <div class="col-md-3"  style="text-align: left">
                                        
                                    </div>
                                    <div class="col-md-3">
                                 
                                    </div>
                                </div>
                                </div>
                              
                            </div>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Ended by usa--%>
                <br />
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="divPrRepDtlshdr" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divPrRepDtls','btndivPrRepDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                      <%--Added by AshishP on 28-03-2018 start--%>
                                    <div class="col-sm-10" style="text-align: left;">
                                        <asp:Label ID="lblPrReptDtls" runat="server" class="subheader"></asp:Label>
                                    </div>
                                  
                                      <%--Added by AshishP on 28-03-2018 start--%>
                                    <div class="col-sm-2">
                                        <span id="btndivPrRepDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divPrRepDtls" runat="server" class="panel-body" style="display: block">
                                <%--Added by AshishP on 28-03-2018 start--%>
                                <div class="row" style="margin-bottom: 5px;">
                                     <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblIsMdty" runat="server"   CssClass="control-label" />
                                    </div>
                                      <div class="col-sm-3" style="text-align: left;">
                                        <asp:UpdatePanel ID="upPriMand" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkPriMand" runat="server" Enabled="true" Style="margin-left: 10px; font-size:14px" CssClass="control-label" tabindex="26"
                                                    Checked="false" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3">
                                        </div>
                                     <div class="col-md-3">
                                        </div>
                                  </div>
                               <%-- Added by AshishP on 28-03-2018 END--%>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblddlreportingtype" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upReptType" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlreportingtype"  TabIndex="27" runat="server" CssClass="form-control" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlreportingtype_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlchannel" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblRptRule" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upReptRule" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlReportingRule" runat="server"  TabIndex="28" CssClass="form-control" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblchannel" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upChannel" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlchannel" runat="server"  TabIndex="29" CssClass="form-control" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlchannel_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsubchannel" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblsubchannel" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upSubChannel" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsubchannel"  TabIndex="30" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlsubchannel_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlbasedon" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblbasedon" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upBasedOn" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlbasedon"  TabIndex="31" runat="server" CssClass="form-control" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlbasedon_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddllevelagttype" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lbllevelagttype" runat="server" CssClass="control-label"></asp:Label>
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upLevelAgtType" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddllevelagttype"  TabIndex="32" runat="server" CssClass="form-control" AutoPostBack="True">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblRptSetup" runat="server" CssClass="control-label" />
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="updStp" runat="server">
                                            <ContentTemplate>
                                            
                                      <div style="display: flex;"><%--by meena--%>
                                                <asp:DropDownList ID="ddlRptSetup" runat="server"  TabIndex="33" AutoPostBack="true" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlRptSetup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                  <asp:Button ID="btnRptMgr" TabIndex="33" runat="server" CssClass="btn btn-verify" Text="...." Style="margin-left: 2px;"
                                             OnClick="btnRptMgr_Click" /><%--by meena--%>
                                            <input id="hdnMemRole" type="hidden" runat="server" /><%--by meena--%>
                                             <asp:HiddenField ID="hdnMemType" runat="server" /><%--by meena--%>
                                             <asp:HiddenField ID="hdnMemCode" runat="server" /><%--by meena--%>
                                              <input type="hidden" id="hdnRptSetup" runat="server" /><%--by meena--%>
                                              <asp:Button ID="btnmemgrid" runat="server" OnClick="btnmemgrid_Click" ClientIDMode="Static"
                                            Style="display: none;" /><%--by meena--%>
                                            </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-2" style="text-align: left">
                                        <asp:Label ID="lblRptLvl" runat="server" Visible="false" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:UpdatePanel runat="server" ID="rptLvl">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRptLevel" TabIndex="34"  runat="server" CssClass="form-control"
                                                    Visible="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                     <%-- added byajay--%>
                                      <div class="col-md-2" style="text-align: left">
                                        <asp:LinkButton ID="lnkBtnModel" runat="server" Text="View Relation" OnClick="lnkBtnModel_Click"></asp:LinkButton>
                                    </div>
                                     <%-- added byajay--%>
                                    
                                </div>
                                <%--<tr>
                        <td align="left" class="formcontent" style="width: 229px">
                            <asp:Label ID="Label4" runat="server"></asp:Label></td>
                        <td align="left" class="formcontent" colspan="3">
                            <asp:TextBox ID="txtAppRule" runat="server" CssClass="standardtextbox" Width="59px" MaxLength="1"></asp:TextBox></td>
                    </tr>--%><div class="row" style="margin-bottom: 5px;">





                        
                        <asp:GridView AllowSorting="True" ID="gv" runat="server" CssClass="footable" AutoGenerateColumns="False"
                            PageSize="10" AllowPaging="true" CellPadding="1">
                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                            <Columns>
                              
                                <asp:TemplateField HeaderText="Hierarchy Name" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Class" SortExpression="MemType">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChnCls" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Member Type" SortExpression="MemCode">
                                    <ItemTemplate>
                                        <i class="fa fa-male"></i>&nbsp;&nbsp;
                                        <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Unit Rank" SortExpression="untRnk">
                                    <ItemTemplate>
                                        <i class="fa fa-male"></i>&nbsp;&nbsp;
                                        <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("untRnk") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="ddivAddlRDtlsHdriv2" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAddlRDtls','btndivAddlRDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblAddlRDtls" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivAddlRDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divAddlRDtls" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lbladditionalreporting" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upAddlReptRule" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddladditionalreportingrule" TabIndex="35" runat="server" CssClass="select2-container form-control"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddladditionalreportingrule_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>

                              

                                <div class="row" style="margin-bottom: 5px;padding:10px;">
                                    <asp:UpdatePanel runat="server" ID="updAddl">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgAddlRpt" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                HorizontalAlign="Left" Width="100%" AllowSorting="True" ShowHeader="false" GridLines="None"
                                                OnRowDataBound="dgAddlRpt_RowDataBound">
                                                <%--<PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />--%>
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                        <ItemTemplate>
                                                            <div class="row" style="margin-bottom: 5px;">
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlRptTyp" runat="server" CssClass="control-label" />

                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlAdlRptTyp" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAdlRptTyp_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlRptRule" runat="server" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlAdlRptRul" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-bottom: 5px;">
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlChn" runat="server" CssClass="control-label" />
                                                                    <span style="font-size: 10pt; color: #ff0000">*</span>
                                                                </div>
                                                                <div class="col-md-3">
                                                                   
                                                                     <asp:UpdatePanel ID="UpdatePanelAdlChn" runat="server">
                                                                      <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlAdlChn" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAdlChn_SelectedIndexChanged">
                                                                    </asp:DropDownList>
				                                           	  </ContentTemplate>
                                                           </asp:UpdatePanel>
                                                                

                                                                </div>
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlSChn" runat="server" CssClass="control-label" />
                                                                    <span style="font-size: 10pt; color: #ff0000">*</span>
                                                                </div>
                                                                <div class="col-md-3">

                                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                       <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlAdlSChn" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAdlSChn_SelectedIndexChanged">
                                                                    </asp:DropDownList>
			                                             		  </ContentTemplate>
                                                              </asp:UpdatePanel>
				
                                                                    
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-bottom: 5px;">
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlBsdOn" runat="server" CssClass="control-label" />
                                                                    <span style="font-size: 10pt; color: #ff0000">*</span>
                                                                </div>
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                     <ContentTemplate>
                                                                       <asp:DropDownList ID="ddlAdlBsdOn" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAdlBsdOn_SelectedIndexChanged">
                                                                    </asp:DropDownList>
			                                               		  </ContentTemplate>
                                                               </asp:UpdatePanel>
				
                                                                  
                                                                </div>
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAddlAgt" runat="server" CssClass="control-label" />
                                                                    <span style="font-size: 10pt; color: #ff0000">*</span>
                                                                </div>
                                                                <div class="col-md-3" style="text-align: left">

                                                                      <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                             <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlAdlAgtTyp" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAdlAgtTyp_SelectedIndexChanged">
                                                                    </asp:DropDownList>
				                                        	  </ContentTemplate>
                                                             </asp:UpdatePanel>

                                                                 
                                                                </div>
                                                            </div>
                                                            <div class="row" style="margin-bottom: 5px;">
                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlRptStp" runat="server" CssClass="control-label" />
                                                                    <span style="font-size: 10pt; color: #ff0000">*</span>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    
                                                                    <asp:UpdatePanel ID="updStp1" runat="server" style="display: flex;">
                                                                       <ContentTemplate>

                                                                    <asp:DropDownList ID="ddlRptStp" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlRptStp_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                      <asp:Button ID="btnRptMgr1" TabIndex="33" runat="server" OnClick="btnRptMgr1_Click" CssClass="btn btn-verify" Text="...." Style="margin-left: 2px;"/>
                                                                        
                                                                    </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                </div>

                                                                <div class="col-md-3" style="text-align: left">
                                                                    <asp:Label ID="lblAdlRptLvl" runat="server" Visible="false" CssClass="control-label" />
                                                                    <asp:Label ID="lblMandate" runat="server" Text="Is Mandatory" CssClass="control-label" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlRptLvl" runat="server" CssClass="form-control" Visible="false">
                                                                    </asp:DropDownList>
                                                                    <asp:CheckBox ID="chkAdlMand" runat="server" AutoPostBack="true" ToolTip="Is Mandatory" />
                                                                    <asp:Label Text="(Mandatory reporting for the Member Type)" Font-Size="X-Small" ForeColor="Red"
                                                                        runat="server" CssClass="control-label" />
                                                                </div>
                                                            </div>

                                                            <div class="row" style="margin-bottom: 5px;">
                                                              <asp:LinkButton ID="lnkBtnADR" runat="server" Text="View Relation" OnClick="lnkBtnADR_Click" style="margin-left: 883px;"></asp:LinkButton>
                                                            </div>

                                                        </ItemTemplate>
                                                        <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <div id="divmvMnHdr" runat="server" class="panel">
                            <div id="divMvmtHdr" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMvmt','btndivMvmt');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblMvmt" runat="server" CssClass="control-label" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivMvmt" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divMvmt" runat="server" class="panel-body" style="display: block;">
                                <div class="row" style="margin-bottom: 5px;margin-right:-75%;">
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblCreate" runat="server" Text="Creation" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblModify" runat="server" Text="Modification" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblTrf" runat="server" Text="Transfer" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblTrm" runat="server" Text="Termination" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblRein" runat="server" Text="Reinstatement" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblPro" runat="server" Text="Promotion" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="lblDemo" runat="server" Text="Demotion" Font-Bold="false" CssClass="control-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;margin-right:-75%;">
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblcreate" runat="server" CellPadding="2" CellSpacing="2"
                                                    Width="90px" AutoPostBack="True" align="center" TabIndex="37"
                                                    RepeatDirection="Horizontal" 
                                                    onselectedindexchanged="rblcreate_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblmodify" runat="server" TabIndex="38" CellPadding="2" CellSpacing="2"
                                                    Width="90px" AutoPostBack="True" align="center" 
                                                    RepeatDirection="Horizontal" 
                                                    onselectedindexchanged="rblmodify_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="uptrf" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rbltrf" runat="server" CellPadding="2" CellSpacing="2" Width="90px" TabIndex="39"
                                                    AutoPostBack="True" align="center" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbltrf_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="upter" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblter" runat="server" AutoPostBack="True" CellPadding="2" TabIndex="40"
                                                    align="center" CellSpacing="2" Width="90px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblter_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="uprein" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblrein" runat="server" AutoPostBack="True" CellPadding="2" TabIndex="41"
                                                    align="center" CellSpacing="2" Width="90px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblrein_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblpromo" runat="server" AutoPostBack="True" CellPadding="2" TabIndex="42"
                                                    align="center" CellSpacing="2" Width="90px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblpromo_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rbldemo" runat="server" AutoPostBack="True" CellPadding="2" TabIndex="43"
                                                    align="center" CellSpacing="2" Width="90px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbldemo_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px; margin-right: -75%;">
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:LinkButton ID="lnkCrtAdd" Text="Add Rule" runat="server" TabIndex="44"
                                            Visible="false" CausesValidation="false" onclick="lnkCrtAdd_Click" />
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkCrtView" Text="View Rule" runat="server" TabIndex="45"
                                            Visible="false" onclick="lnkCrtView_Click" />
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:LinkButton ID="lnkModAdd" Text="Add Rule" runat="server" TabIndex="46"
                                            Visible="false" CausesValidation="false" onclick="lnkModAdd_Click" />
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkModView" Text="View Rule" runat="server" TabIndex="47"
                                            Visible="false" onclick="lnkModView_Click" />
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:LinkButton ID="lnkTrfAdd" Text="Add Rule" runat="server" OnClick="lnkTrfAdd_Click" TabIndex="48"
                                            Visible="false" CausesValidation="false"/>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkTrfView" Text="View Rule" runat="server" OnClick="lnkTrfView_Click" TabIndex="49"
                                            Visible="false" />
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkTrmAdd" Text="Add Rule" runat="server" TabIndex="50"
                                                    onclick="lnkTrmAdd_Click" Visible="false"/>
                                                    &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkTrmView" Text="View Rule" runat="server"  TabIndex="51"
                                                    onclick="lnkTrmView_Click" Visible="false"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkReinAdd" Text="Add Rule" runat="server" TabIndex="52"
                                                    onclick="lnkReinAdd_Click" Visible="false"/>
                                                    &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkReinView" Text="View Rule" runat="server" TabIndex="53"
                                                    onclick="lnkReinView_Click" Visible="false"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkPrmAdd" Text="Add Rule" runat="server" TabIndex="54"
                                                    onclick="lnkPrmAdd_Click" Visible="false"/>
                                                    &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkPrmView" Text="View Rule" runat="server" TabIndex="55"
                                                    onclick="lnkPrmView_Click" Visible="false"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkDemoAdd" Text="Add Rule" runat="server" TabIndex="56"
                                                    onclick="lnkDemoAdd_Click" Visible="false"/>
                                                    &nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkDemoView" Text="View Rule" runat="server" TabIndex="57"
                                                    onclick="lnkDemoView_Click" Visible="false"/>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="btn" runat="server" onclick="btn_Click" ClientIDMode="Static" style="display:none;" TabIndex="58"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="divUMDtlsHdr" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divUMDtls','btndivUMDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblUMDtls" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivUMDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divUMDtls" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblIsUM" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upChkUM" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkIsUM" runat="server" OnCheckedChanged="chkIsUM_CheckedChanged"
                                                    AutoPostBack="True" TabIndex="59" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUChnl" runat="server" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upUChnnl" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUChnnl" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUChnnl_SelectedIndexChanged" TabIndex="60"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlUSubCls" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUSubClass" runat="server" CssClass="control-label"></asp:Label>
                                        <%--Width="85px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upSubCls" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUSubCls" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="61"
                                                    OnSelectedIndexChanged="ddlUSubCls_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUMBasedOn" runat="server" CssClass="control-label"></asp:Label>
                                        <%--Width="85px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUMBasedOn" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="62"
                                                    OnSelectedIndexChanged="ddlUMBasedOn_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlUUnitType" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUUnitType" runat="server" CssClass="control-label"></asp:Label>
                                        <%--Width="100px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upUnitType" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUUnitType" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="63">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblUnitLoc" runat="server" CssClass="control-label"></asp:Label>
                                        <%--Width="100px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="upddlULoc" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUnitLoc" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="64">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <%--added by ajay start 18-02-2022--%>
                 <asp:UpdatePanel ID="UptPnlIsUnt" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="div8" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divUMDtls1','btndivUMDtls1');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblUMDtls1" runat="server" class="subheader" Text="ADDITIONAL UNIT MANAGER DETAILS"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivUMDtls1" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divUMDtls1" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="Label10" runat="server" CssClass="control-label" Text="Hierarchy Name"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUChnnl1" runat="server" CssClass="form-control" TabIndex="60" OnSelectedIndexChanged="ddlUChnnl1_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlUSubCls1" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="Label11" runat="server" CssClass="control-label" Text="Sub Class"></asp:Label>
                                        <%--Width="85px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUSubCls1" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="61">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblbasedon1" runat="server" CssClass="control-label" Text="Based On"></asp:Label>
                                        <%--Width="85px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUMBasedOn1"  runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="62" OnSelectedIndexChanged="ddlUMBasedOn1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlUUnitType1" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="Label13" runat="server" CssClass="control-label" Text="Unit Type"></asp:Label>
                                        <%--Width="100px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUUnitType1" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="63">
                                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="Label14" runat="server" CssClass="control-label" Text="Location"></asp:Label>
                                        <%--Width="100px"--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlUnitLoc1" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="64">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--added by ajay end 18-02-2022--%>
                <div class="panel">
                    <div id="div2" runat="server" class="panel-heading subheader" style="background-color: #ffffff !important">
                        <asp:UpdatePanel ID="upPosReq" runat="server">
                            <ContentTemplate>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-10" style="text-align: left">
                                        <%--<span class="glyphicon glyphicon-chevron-down" style="color: #034ea2;"></span>--%>
                                        <asp:Label ID="lblPosReq" runat="server" class="subheader"></asp:Label>
                                        <%-- Width="124px"--%>
                                        <asp:CheckBox ID="chkPosReq" runat="server" Enabled="true" TabIndex="65" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                   <%-- added  by Bhaurao on 30.03.2018 Start--%>
                     <div class="panel" id="div16" runat="server"  style="display:none"> <%--style="margin-left: 2%; margin-right: 2%;"--%>
                      <div  id="divprodtls" runat="server" ><%--style="margin-left: 2%; margin-right: 2%;" --%>
        <div id="Div17" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divProducrGridDtls','spnsrch');return false;">  
            <div class="row">
            <div class="col-sm-10" style="text-align:left">
                <asp:Label ID="lblprodname" runat="server" Text="Product Details"  CssClass="control-label"  Font-Size="19px" ></asp:Label>
            </div>
            <div class="col-sm-2">
                    <span id="spnsrch" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
            </div>
        </div> 
    </div>
     
        <div id="divChannel" runat="server" style="width:96.6%;" class="container panel-body" >
        <div class="row">
        <div class="col-sm-8" style="text-align: center">                       
            <asp:LinkButton ID="lnkbtnaddprod" runat="server"  CssClass="btn btn-sample" 
            CausesValidation="false" TabIndex="14" OnClick="lnkbtnaddprod_Click">
            <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> ADD PRODUCT
            </asp:LinkButton>
                </div>
            <div class="col-sm-2">
            <%--<span> Product Status</span>
            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                <asp:ListItem Value="All" Text="All"> </asp:ListItem>
                    <asp:ListItem Value="A" Text="Active"> </asp:ListItem>
            </asp:DropDownList>--%>
                <%-- <div class="col-sm-2">--%>
                    <asp:Label ID="lblstatus" CssClass="control-label" Text="Product Status" runat="server" />
        </div> 
            <div class="col-sm-2">
            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Value="All" Text="All"  Selected="True"> </asp:ListItem>
                    <asp:ListItem Value="A" Text="Active"> </asp:ListItem>
            </asp:DropDownList>
            <%-- </div>--%>
                       
        </div>
    </div>
        <br />
        <div id="divProducrGridDtls" runat="server"  visible="false" style="width:100%"> 
        <asp:GridView ID="GridProdDtls" runat="server" Width="100%" AutoGenerateColumns="False" RowStyle-BackColor="#F6F6F6" CssClass="footable"
            PageSize="10" AllowSorting="True" AllowPaging="True" DataKeyNames="ProductCode,ProductName" OnRowDataBound="GridProdDtls_RowDataBound"> <%--OnRowDataBound="GridProdDtls_RowDataBound"--%>
            <RowStyle CssClass="GridViewRowNew"></RowStyle>
            <PagerStyle CssClass="disablepage" />
            <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />
            <Columns>                       
                <asp:TemplateField HeaderText="Product Code" HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblProdCode" runat="server" CssClass="standardlabel" Text='<%# Eval("ProductCode").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hndProductCode" runat="server" Value='<%# Eval("ProductCode").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblProdName" CssClass="standardlabel" runat="server" Text='<%# Eval("ProductName").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hndProductName" runat="server" Value='<%# Eval("ProductName").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Effective Date" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblEffFromDate" CssClass="standardlabel" runat="server" Text='<%# Eval("EffFromDate").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnEffFromDate" runat="server" Value='<%# Eval("EffFromDate").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="LOB Code" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblLobCode" CssClass="standardlabel" runat="server" Text='<%# Eval("LobCode").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnLobCode" runat="server" Value='<%# Eval("LobCode").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" CssClass="standardlabel" runat="server" Text='<%# Eval("Status").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Status").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cease Date" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:Label ID="lblCeaseDtim" CssClass="standardlabel" runat="server" Text='<%# Eval("CeaseDtim").ToString() %>'></asp:Label>
                        <asp:HiddenField ID="hdnCeaseDtim" runat="server" Value='<%# Eval("CeaseDtim").ToString() %>'
                            Visible="false" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-Font-Bold="true">
                    <ItemTemplate>
                        <%-- <asp:LinkButton ID="lnkdelete" runat="server"  CssClass="btn btn-sample" 
                                TabIndex="14" CausesValidation="false" CommandName="Delete" OnClientClick ="return funcShowPopupCease(this)"  ><span class="glyphicon glyphicon-remove" style="color:White"> </span> Delete
                            </asp:LinkButton>--%>
                        <asp:Button runat="server" ID="lnkdelete" Text="Delete" CommandName="Delete" CssClass="btn btn-sample" OnClientClick ="return funcShowPopupCease(this);"   /><%--CausesValidation="false"OnClick="lnkdelete_Click"--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Font-Bold="False"></ItemStyle>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
        <br />
        <center>
            <table id="tblpagination" runat="server" visible="false"> 
                <tr>
                    <td>
                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" /> <%--OnClick="btnprevious_Click"--%>
                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                        <%--OnClick="btnnext_Click"--%>
                </td>
                </tr>
            </table>
        </center>
        <br />
                  
            <center>  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" Width="310px"></asp:Label><%--Style='margin-left: 192px;' --%>
            </center>
    </div>
    </div>
    </div>
                     </div>
                   <%-- added  by Bhaurao on 30.03.2018 end--%>
                <br />
          

                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <div class="panel">
                            <div id="divOthDtlsHdr" runat="server" class="panel-heading subheader" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divOthDtls','btndivOthDtls');return false;"
                                style="background-color: #ffffff !important">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblhdrOth" runat="server" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivOthDtls" class="glyphicon glyphicon-chevron-down" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divOthDtls" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblPer" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                        <asp:TextBox ID="txtFinYr" visible="false" runat="server" CssClass="form-control" TabIndex="66" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="-" TargetControlID="txtFinYr">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblVer" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtVer" runat="server" CssClass="form-control"  TabIndex="67"/>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="." TargetControlID="txtVer">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblEffDate" runat="server" CssClass="control-label" />
                                        <span style="font-size: 10pt; color: #ff0000">*</span>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" TabIndex="68" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtEffDate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblCseDt" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtCseDt" runat="server" CssClass="form-control" TabIndex="69" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtCseDt">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </div>
                                </div>

                                   <%--//added by ajay START--%>
				        
                                     
	                 	<div class="col-sm-3" style="text-align:left">
                          <asp:Label ID="lblSubChnStatus" Text="Status" runat="server" CssClass="control-label" style="margin-left:-14px;"/> 
                           <span style="color: #ff0000"> *</span>
                     </div>
                        <div class="col-sm-3">
                        <asp:DropDownList Enabled="false" id="ddlDraftStatus"  CssClass="form-control"  runat="server"
                            style="margin-left:-7px;width: 250px;">
                        <asp:ListItem   Value="Draft">Draft</asp:ListItem>
                          <asp:ListItem Selected="True" Value="Final">Final</asp:ListItem>
                        </asp:DropDownList>
                        </div>
               <%--//added by ajay END--%>   
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                        <%--Added by AJAY  for model popup Start--%>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; 
background-color: #dff0d8;">
                    <asp:Label ID="Label3" Text="INFORMATION" 
                        runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-verify" data-dismiss="modal" style='margin-top: -6px; border-radius: 15px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                    </button>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog modal-sm" style="width: auto; padding: 49px">
            <!-- Modal content-->
            <%--<div class="modal-content" style="height: 380px; width: 706px">--%>
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; text-align: initial; background-color: #dff0d8;">
                    <asp:Label ID="Label31" Text="Version history of Member type setup" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>
                </div>
                <div class="panel" id="div7" runat="server" style="margin-left: 2%; margin-right: 2%;">
                    <div id="Div19" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label23" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                    </div>
                    <div id="div20" runat="server" class="panel-body" style="display: block">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="Label24" runat="server" Text="Modification Mode" CssClass="control-label" />
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:RadioButtonList ID="rdMode" runat="server" CellPadding="2" CellSpacing="2"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR">  </asp:ListItem>
                                    <asp:ListItem Text="&nbspChanges&nbsp" Value="CH"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-3" style="text-align: left">
                                <asp:Label ID="lblFinyer" Text="Financial year" CssClass="control-label" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlFinYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                            </div>
                        </div>
                    </div>
                </div>

                  <div id="div21" runat="server" style="width: 98%;">
                    <div class="row">
                        <div class="col-md-12" style="text-align: center">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample"
                                CausesValidation="false"  TabIndex="14" OnClick="btnSearch_Click"> <%--">--%>
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> SEARCH </asp:LinkButton>
                            <button type="button" class="btn btn-sample" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCANCEL
                            </button>
                        </div>
                    </div>
                </div>

                         <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
                                                 <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                        <asp:GridView AllowSorting="True" ID="gvhistory" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("BizSrc") %>'
                                            CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemType") %>'
                                            CommandArgument='<%# Eval("MemType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Sub class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnCls") %>'
                                            CommandArgument='<%# Eval("ChnCls") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="UnitRank">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitRank") %>'
                                            CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Level">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemLevel") %>'
                                            CommandArgument='<%# Eval("MemLevel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc01">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc01") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc02">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc02") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc02") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. Type Desc03">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemTypeDesc03") %>'
                                            CommandArgument='<%# Eval("MemTypeDesc03") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Member Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemberRole") %>'
                                            CommandArgument='<%# Eval("MemberRole") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Member Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemberRole") %>'
                                            CommandArgument='<%# Eval("MemberRole") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Alw. RecruitMem">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwRecruitMem") %>'
                                            CommandArgument='<%# Eval("AlwRecruitMem") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>


                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mem. CreateRul">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("MemCreateRul") %>'
                                            CommandArgument='<%# Eval("MemCreateRul") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                            CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit channel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Unitchannel") %>'
                                            CommandArgument='<%# Eval("Unitchannel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Sub Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitSubClass") %>'
                                            CommandArgument='<%# Eval("UnitSubClass") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>


                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UnitType") %>'
                                            CommandArgument='<%# Eval("UnitType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Is Unit Manager">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("IsUnitManager") %>'
                                            CommandArgument='<%# Eval("IsUnitManager") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                            CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                            CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Eff. Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                            CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Cease Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                            CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                            CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                            CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                            CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Updated Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                            CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                
                                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                            CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
               
                </div>

                   <div class="modal-footer" id="DivButton" visible="false" runat="server" style="text-align: center">
                    <button type="button" visible="false" runat="server" class="btn btn-sample" data-dismiss="modal" style='margin-top: -93px; border-radius: 15px;'>
                        <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                    </button>
                </div>
            </div>
        </div>
    </div>


    <%--Added by AJAY for model popup END--%>
                <br />
                <div id="div9" runat="server" style="width: 100%;">
                    <div class="row" id="tbladdcntst" runat="server">
                        <div class="col-md-12" style="text-align: center">
                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" CausesValidation="false"
                                OnClick="btnUpdate_Click" TabIndex="70">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> UPDATE
               
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-sample" OnClick="btnSave_Click" 
                              CausesValidation="false"   TabIndex="14" OnClientClick="return funValidateNew();" >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> SAVE
                                </asp:LinkButton>&nbsp;
                            &nbsp;<%--<asp:Button ID="btnCancel" runat="server" CssClass="btn default" Text="CANCEL"
                                        Width="100px" CausesValidation="False" OnClick="btnCancel_Click" />--%>
                            <asp:LinkButton ID="btnCancel" runat="server" style="background-color:#FFF;color:#f04e5e; width:85px !important" CssClass="btn btn-sample" 
                                OnClick="btnCancel_Click" TabIndex="71" onClientclick="javascript:window.history.back();return false;">
                                  <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> CANCEL
               
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-sample" 
                              CausesValidation="false" TabIndex="15" OnClientClick="funPopUp();return false;" > <%--onclick="btnshowHist_Click1"--%>
                                  <span class="glyphicon glyphicon-dashboard" style="color:White"> </span> VIEW HISTORY
                                </asp:LinkButton>
                            
                        </div>
                    </div>
                </div>
                <br />
                <div id="div6" runat="server">
                    <div class="row" id="trAgentTypes" runat="server" style="margin-left: 19px; width: 97%;
                        overflow: auto;">                     
                        <asp:GridView AllowSorting="True" ID="gv_AgentTypes" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                           <%-- <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                            <Columns>
                                <asp:BoundField HeaderText="Channel" DataField="Channel" SortExpression="BizSrc"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="SubChannel" HeaderText="Sub Channel" SortExpression="ChnCls"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField HeaderText="Total active" DataField="Active" SortExpression="Active"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Total Inactive" DataField="InActive" SortExpression="InActive"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            
        </div>
    </center>

    <asp:Panel runat="server" ID="pnlMdl" Width="800px" Height="400px" display="none" Style="display: none">
        <iframe runat="server" id="ifrmMdlPopup" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>

    <asp:Label runat="server" ID="lbl1" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"  
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>



    <asp:Panel runat="server" ID="pnlview" Width="800px" Height="400px" display="none" Style="display: none">
        <iframe runat="server" id="Iframe1" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>

    <asp:Label runat="server" ID="Label7" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupview" BehaviorID="ModalPopupviewBID"
        DropShadow="false" TargetControlID="Label7" PopupControlID="pnlview" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--iframe--%>
    <asp:Panel runat="server" ID="pnlmvmt" Height="400px" Width="1000px" display="none" CssClass="panel">
        <iframe runat="server" id="ifrmmvmt" frameborder="0" display="none" style="height: 100%; width: 100%"></iframe>
    </asp:Panel>

    <asp:Label runat="server" ID="Label2" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlpopupmvmt" BehaviorID="mdlpopupmvmtBID"
        TargetControlID="Label2" PopupControlID="pnlmvmt" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--iframe--%>


    <asp:Panel ID="pnl" runat="server" CssClass="modal-content" Width="450px" Height="310px" style="height: 310px;width: 450px;position: fixed;z-index: 100001;left: 482px;top: 160px;" >
        <div class="modal-header" style="text-align: center;">
            <asp:Label ID="Label4" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body" style="text-align: center">
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:LinkButton ID="btnok" runat="server" TabIndex="1205"
                class="btn btn-verify" OnClientClick="javascript:done();">
                <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
            </asp:LinkButton>
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" OkControlID="btnok" X="539" Y="160">
    </ajaxToolkit:ModalPopupExtender>

    <%--Added by Bhau on 07/04/2018 for model popup Start--%>

     <asp:Panel runat="server" ID="PnlPopupLOB" Width="1000px" Height="550px" display="none" top="52" left="529px">
        <iframe runat="server" id="IframeLOB" width="100%" height="100%" frameborder="0" display="block"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDLOB"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Button ID="btnProductDtls" runat="server" OnClick="btnProductDtls_Click" ClientIDMode="Static"
        Style="display: none;" TabIndex="72" />
    <asp:HiddenField ID="hdnprodctcode" runat="server" />
    <asp:HiddenField ID="hdnprodctNmae" runat="server" />

    <asp:Panel runat="server" ID="pnlcease" Width="500" Height="428" display="none" top="52" left="529px">
        <iframe runat="server" id="Ifrmcease" width="610px" height="539px" frameborder="0" style="margin-top: -45px;"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblcease" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlpnlcease" BehaviorID="mdlViewBIDCease"
        DropShadow="false" TargetControlID="lblcease" PopupControlID="pnlcease" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Button ID="btncease" runat="server" ClientIDMode="Static"
        Style="display: none;" TabIndex="72" />
    <asp:HiddenField ID="hdn1" runat="server" />
    <asp:HiddenField ID="hdn2" runat="server" />
    <asp:HiddenField ID="hdn3" runat="server" />
    <asp:HiddenField ID="hdnprdcode" runat="server" />
    <asp:HiddenField ID="hdnProdcodeEdit" runat="server" />
    <asp:HiddenField ID="hdnChntype" runat="server" />
    <asp:HiddenField ID="hdnBizSrc" runat="server" />
    <%--Added by Bhau on 07/04/2018 for model popup End--%>



    <div class="modal" id="myModalPop" role="dialog" width="45%">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label5" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        hideRadioSymbol();

        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }

    </script>
</asp:Content>




 
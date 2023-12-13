<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="AgtHierarchySearch.aspx.cs" Inherits="INSCL.Application_INSC_ChannelMgmt_AgtHierarchySearch" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
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
    <style type="text/css">
        .btn-tab {
            color: white;
            background-color: #034ea2;
            border-color: white;
        }
        .subheader {
            font-size: 16px !important;
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
    <style type="text/css">
        .ajax__calendar {
            position: static;
        }

        .pagelink span {
            font-weight: bold;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .disablepage {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">


        function addCssClassByClick(flag) {
            debugger;

            if (flag == 1) {

                $("#ctl00_ContentPlaceHolder1_Employee").addClass("btn-tab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Agent").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Other").removeClass("btn-tab")

            }

            else if (flag == 2) {
                $("#ctl00_ContentPlaceHolder1_Employee").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Agent").addClass("btn-tab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Other").removeClass("btn-tab")

            }

            else if (flag == 3) {
                $("#ctl00_ContentPlaceHolder1_Employee").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Agent").removeClass("btn-tab")
                $("#ctl00_ContentPlaceHolder1_Other").addClass("btn-tab btn btn-default")

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
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
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
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
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

        function OpenPopup(agentcode, Flag) {
            //debugger;
            //window.open("AgtSearchHierarchydtls.aspx?Flag=P&AgnCd=" + agentcode + "", 'Popup', '');
            //window.open("http://192.168.0.100/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&A= " + agentcode + "&T=agn&Flag=" + Flag + "", 'Popup', 'toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            //  window.open("../../Hierarchy/RadWindowOrgChartContent.aspx?AgtCode=" + agentcode + "&Flag=" + Flag + "", 'Popup', 'toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            window.open("../../Hierarchy/RadWindowOrgChartContent.aspx?AgtCode=" + agentcode + "&Flag=" + Flag + "", 'Popup', 'toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
            return false;
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


        //Added by Prathamesh 1-9-15 start

        function ShowReqDtls(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
        //Added by Prathamesh 1-9-15 end



        //Added by Kalyani on 11-12-2013 for collapsable functionality start
        //        function ShowReqDtl(divId, btnId) {
        //            //debugger;
        //            if (document.getElementById(divId).style.display == "block") {
        //                document.getElementById(divId).style.display = "none";
        //                //document.getElementById(divId).value = '+'
        //                document.getElementById(btnId).value = '+';
        //            }
        //            else {
        //                document.getElementById(divId).style.display = "block";
        //                //document.getElementById(btnId).value = '-'
        //                document.getElementById(btnId).value = '-';
        //            }
        //        }
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
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container" style="margin-top: 0px;">
    <center>
       
                    
                        <tr align="left">
                            <td align="left">
                                <asp:ImageButton ID="lnkTab1" runat="server" Visible="false" CssClass="TextBox" BackColor="transparent"
                                    Style="margin-left: 64px;" ImageUrl="~/theme/iflow/tabs/Employee1.png" OnClick="lnkTab1_Click" />
                                <asp:ImageButton ID="lnkTab2" runat="server" Visible="false" CssClass="TextBox" BackColor="Transparent"
                                    ImageUrl="~/theme/iflow/tabs/Agent2.png" OnClick="lnkTab2_Click" />
                                <asp:ImageButton ID="lnkTab3" runat="server" Visible="false" CssClass="TextBox" BackColor="Transparent"
                                    ImageUrl="~/theme/iflow/tabs/Other2.png" OnClick="lnkTab3_Click" />
                            </td>
                        </tr>
                   
                   
                  <%--   <div id="divIRCC" runat="server" style="padding: 1%" role="tabpanel">--%>
                       <%-- <ul class="nav nav-tabs">
                            <li class="active"><a id="Employee1" runat="server" aria-controls="Employee" data-toggle="tab" onclick="Employee1_Click"
                                href="#menu1"><b>Employee</b></a>
                                    </li>
                            <li><a id="Agent1" runat="server" aria-controls="Agent"  href="#Agent" data-toggle="tab"  onclick="Agent1_Click">
                                <b>Agent</b></a></li>
                            <li><a id="Other1" runat="server" aria-controls="Other" data-toggle="tab" href="#Other" onclick="Other1_Click">
                                <b>Other</b></a></li>
                        </ul>--%>
                        <div id="demo1" class="row" style="width:100%;margin-bottom:10px" runat="server">
                         <div class="col-sm-6 col-xs-12 col-lg-3 col-md-6">
                             <div style="float:left">                            
                            <asp:LinkButton ID="Employee"  Text="Employee" CssClass="btn btn-default"  OnClientClick="return addCssClassByClick('1')"  OnClick="Employee_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Agent" Text="Agent" CssClass="btn btn-default"  OnClick="Agent_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Other" Text="Other" CssClass="btn btn-default" OnClick="Other_Click"  OnClientClick="return addCssClassByClick('3')" runat="server"></asp:LinkButton>
                                 </div>
                         </div>
                        </div>

                     
                            
                                <%-- <div class="tab-content">
                            
                                <div id="Employee" class="tab-pane fade in active" >
                                 <div id="Agent" class="tab-pane fade" >
                                  <div id="Other" class="tab-pane fade" >--%>
                       
                                        <div class="panel">
                                            <div id="trHead" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div5','Span1');return false;">
                                                <div class="row">
                                                    <div class="col-sm-10" style="text-align: left">
                                                        <asp:Label ID="lblSourceName" Visible="false" runat="server" Font-Bold="false" Font-Size="19px"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="div5" style="display: block;" runat="server" class="panel-body">
                                                <%--  <div id="divcmphdrcollapse" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lblbas" Text="Basic Search"  runat="server" Font-Bold="false" Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>--%>
                                                <div class="panel">
                                                    <div id="divcmphdrcollapse" runat="server" class="panel-heading subheader" style="background-color:white!important" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','btnpersnl');return false;">
                                                        <div class="row">
                                                            <div class="col-sm-10" style="text-align: left">
                                                              &nbsp;
                                                    <span id="Span12" class="glyphicon glyphicon-menu-hamburger" style="height:16px; color:#034ea2"></span>
                                                                <asp:Label ID="lblbas" Text="Basic Search" runat="server"  class="subheader"></asp:Label>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <span id="btnpersnl" class="glyphicon glyphicon-resize-full" style="float: right;
                                                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="divcmphdr" style="display: block;" runat="server" class="panel-body">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAgntCode" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                        <asp:TextBox ID="txtAgntCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" 
                                                         InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                                             FilterMode="InvalidChars" TargetControlID="txtAgntCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAgntName" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtAgntName" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" 
                                                                    TargetControlID="txtAgntName"></ajaxToolkit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblRptType" CssClass="control-label" runat="server" Text="Reporting Type"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updRptType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRptTyp" runat="server" AutoPostBack="true" CssClass="form-control"
                                                                        OnSelectedIndexChanged="ddlRptTyp_SelectedIndexChanged" >
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
                                                               
                                                                    <asp:TextBox ID="txtImmLeaderCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
                                                                InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                                             FilterMode="InvalidChars" TargetControlID="txtImmLeaderCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="LblMgrSapCode" CssClass="control-label" Text="Rpt Manager SAP Code"
                                                                runat="server" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updMgrSapCode" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtMgrSapCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                                      InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                                             FilterMode="InvalidChars" TargetControlID="txtMgrSapCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblSapCode" Text="Member Sap Code" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                              <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                                              InvalidChars=",#$@%^!*()& ''%^~`abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                                             FilterMode="InvalidChars" TargetControlID="txtSapCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblShwRecords" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control" Font-Size="11">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--  <div id="div1" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lbladvsrch" runat="server" Text="Advance Search" Font-Bold="false" Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div2','Img1','#Img1');" />
                            </td>
                        </tr>
                    </table>--%>
                                                <div class="panel">
                                                    <div id="div1" runat="server" class="panel-heading subheader"  style="background-color:white !important"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div2','Span2');return false;">
                                                        <div class="row">
                                                            <div class="col-sm-10" style="text-align: left">
                                                                &nbsp;
                                                    <span id="Span11" class="glyphicon glyphicon-menu-hamburger" style="height:16px; color:#034ea2"></span>

                                                                <asp:Label ID="lbladvsrch" runat="server" Text="Advance Search"  class="subheader"></asp:Label>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <span id="Span2" class="glyphicon glyphicon-resize-full" style="float: right; color: #034ea2;
                                                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="div2" style="display: block;" runat="server" class="panel-body">
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblchnltype" CssClass="control-label" runat="server" Text="Hierarchy Type"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                                                        CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" CssClass="radiobtn control-label"
                                                                        >
                                                                        <asp:ListItem Value="0" Text="&nbsp;Company&nbsp;&nbsp;"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="&nbsp;Channel"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblPosition" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:DropDownList ID="ddlPosition" runat="server"  CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblSlsChnnl" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlSlsChnnl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlsChnnl_SelectedIndexChanged"
                                                                        CssClass="form-control" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblIDNo" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtPAN" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblChnCls" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" >
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
                                                            <asp:DropDownList ID="ddlAgntStatus" runat="server" CssClass="form-control" >
                                                            </asp:DropDownList>
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblAgntType" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="upnlAgnType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="form-control"
                                                                        OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" >
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
                                                            <asp:TextBox ID="txtUnitCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <%--</div>
                                      <div class="col-sm-1">--%>
                                                            <asp:Button ID="btnUnitCode" runat="server" CssClass="btn btn-verify" style="margin-left: 2px"
                                                                Text="...." UseSubmitBehavior="False" />
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblUnTyp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updUnitType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlUnitType" runat="server" CssClass="form-control"
                                                                         OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblRptUntTyp" CssClass="control-label" runat="server" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:UpdatePanel ID="updUnits" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlUnits" runat="server" CssClass="form-control" >
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlUnitType" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblDTJoinFrom" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtDTJoinFrom" />
                                                          
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblDTJoinTo" runat="server" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtDTJoinTo" />
                                                          
                                                        </div>
                                                            </div>
                                                        <div class="row" style="display:none">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblCSCCode" runat="server" visible="false" CssClass="control-label" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtCSCCode" runat="server" visible="false"  CssClass="form-control" MaxLength="6"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblRefAdv" CssClass="control-label" visible="false"  runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtLinkRef" runat="server" visible="false"  CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                            </div>
                                                        <div class="row" style="display:none">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblClientCode" CssClass="control-label" Visible="false"  runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtGCN" runat="server" Visible="false"  CssClass="form-control"></asp:TextBox>
                                                        </div>                                      
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblchbox" CssClass="control-label" runat="server" Visible="false"></asp:Label>
                                                       </div>
                                                        <div  class="col-sm-3">
                                                            <asp:CheckBox ID="chbxdefaultunit" CssClass="standardcheckbox" Visible="false"  runat="server" Text=""/>
                                                     </div>
                                                            </div>
                                                        <div class="row">
                                                        <div  class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblFranchisee" CssClass="control-label"   runat="server" Visible="False"></asp:Label>
                                                        </div>
                                                        <div  class="col-sm-3">
                                                            <asp:CheckBox ID="ChkFranchisee" CssClass="standardcheckbox"  runat="server" Visible="False" />
                                                      </div>
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblLicenseNo" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox ID="txtLicNo" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                                        </div>
                                                            </div>
                                                        <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:Label ID="lblCDALinkg" runat="server" Visible="false"  CssClass="control-label"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:CheckBox ID="CDACheck" Visible="false"  CssClass="standardcheckbox" runat="server" Text="" />
                                                        </div>
                                                            </div>
                                                    </div>
                                                </div>

                                                      
                                        <div class="row">
                                            <div class="col-sm-12" align="center">
                                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" AutoPostback="false"
                                                    OnClick="btnSearch_Click" OnClientClick="javascript:validate();">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> Search
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-sample"
                                                    runat="server">
                             <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear </asp:LinkButton>
                                            </div>
                                        </div>
                                            </div>
                                        </div>
                                
                                        <br />
                                        <table width="80%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                       
                                        <div id="demo" runat="server" style='display: none;' class="panel">
                                            <div id="div3" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div4','Span3');return false;">
                                                <div class="row">
                                                    <div class="col-sm-10" style="text-align: left">                                    
                                                        <asp:Label ID="lblAgtSrchRes" runat="server" Text="Member Search Results" Font-Size="19px"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <span id="Span3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="div4" runat="server" >
                                                <div style='overflow-x: scroll; display: block;margin-top:10px; width:97%'>
                                                    <center>
                                                <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    HorizontalAlign="Left" Width="100%" OnRowDataBound="dgDetails_RowDataBound" OnPageIndexChanging="dgDetails_PageIndexChanging"
                                                    CssClass="footable"
                                                   OnSorting="dgDetails_Sorting">
                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:ImageField DataImageUrlField="MemCode" DataImageUrlFormatString="ImageGrid.aspx?ImageID={0}"
                                                            HeaderText="Photo" ControlStyle-Height="40px" ControlStyle-Width="40px">
                                                        </asp:ImageField>
                                                        <asp:BoundField DataField="MemCode" SortExpression="MemCode">
                                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Agent Code" Visible="false" SortExpression="MemCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAgtCode" runat="server" Visible="true" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Emp Code" SortExpression="EMPCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Visible="true" Text='<%# Bind("EMPCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName">
                                                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="PAN" DataField="CurrentID" SortExpression="CurrentID"
                                                            Visible="false">
                                                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Manager Code" DataField="MemCode" SortExpression="MemCode">
                                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Unit Code" Visible="false" DataField="unitCode" SortExpression="unitCode" />
                                                        <asp:BoundField HeaderText="Unit Desc" Visible="false" DataField="UnitDesc" SortExpression="UnitDesc"
                                                            ItemStyle-HorizontalAlign="Left" />
                                                        <asp:BoundField HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" />
                                                        <asp:BoundField HeaderText="Sub Class" DataField="ChnCls" SortExpression="ChnCls" />
                                                        <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" />
                                                        <asp:BoundField DataField="MemStatus" Visible="false" HeaderText="Status" SortExpression="MemStatus" />
                                                        <asp:BoundField DataField="RecruitDate" Visible="false" HeaderText="Join Date" SortExpression="RecruitDate" />
                                                        <asp:BoundField DataField="ProcessFlag" Visible="false" HeaderText="Process Flag"
                                                            SortExpression="ProcessFlag" />
                                                        <asp:TemplateField HeaderText="AgentStatus" SortExpression="MemStatus" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="AgentStatus" runat="server" Visible="true" Text='<%# Bind("MemStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="LinkRefAdv" HeaderText="Link Advisor Code" SortExpression="LinkRefAdv"
                                                            Visible="false" />
                                                        <asp:TemplateField HeaderText="MgrEMPCode" SortExpression="MgrEmpcode" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="MgrEMPCode" runat="server" Visible="true" Text='<%# Bind("MgrEmpcode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Primary Manager">
                                                            <ItemTemplate>
                                                                <i class="fa fa-external-link-square"></i>&nbsp;
                                                                <asp:LinkButton ID="lbPrmyMgrCode" runat="server" Text="View" OnClick="lbPrmyMgrCode_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Additional Manager">
                                                            <ItemTemplate>
                                                                <i class="fa fa-external-link-square"></i>&nbsp;
                                                                <asp:LinkButton ID="lbAddlMgrCode" runat="server" Text="View" OnClick="lbAddlMgrCode_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="Link" HeaderText="Link" HeaderStyle-Wrap="false"
                                                            Visible="false" ItemStyle-Width="6%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk" runat="server" Text="Link" CommandArgument='<%# Bind("MemCode") %>'
                                                                    CommandName="click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                        </center>
                                                    </div>
                                                <div id="divPage" style='display:block;' runat="server" class="pagination">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td style="white-space: nowrap;">
                                                                  <%--  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>--%>
                                                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                                float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                                        <%--</ContentTemplate>
                                                                    </asp:UpdatePanel>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </div>
                                        </div>
                               
                                
             
        <asp:HiddenField ID="hdnAgentRole" runat="server" />
    </center>
    <script type="text/javascript">
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup start
        $(function () {
            debugger;

            $("#<%= txtDTJoinFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth:true });
            $("#<%= txtDTJoinTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true });
        });

        function funcShowPopup(strPopUpType) {
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
    </div>
    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="600" Style='background-color: White;'
        display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="400px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        TargetControlID="lbl1" PopupControlID="pnlMdl" X="260" Y="100" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%-- <asp:Panel runat="server" ID="Panel2" Width ="500" display = "none" >
        <iframe runat="server" id="Iframe2" width="610px" height="300px" frameborder="0"
            display="none"></iframe>
       
    </asp:Panel>
    <asp:Label runat="server" ID="Label3" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender2" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        X="260" Y="100" >
                    </ajaxToolkit:ModalPopupExtender>--%>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="Panel1" Width="700" display="none">
        <iframe runat="server" id="Iframe1" width="700" height="700px" frameborder="0" display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label2" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlView"
        DropShadow="true" TargetControlID="Label2" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
</asp:Content>

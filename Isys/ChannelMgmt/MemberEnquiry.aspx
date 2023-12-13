<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="MemberEnquiry.aspx.cs" Inherits="INSCL.MemberEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <style type="text/css">
        .ajax__calendar
        {
            position: static;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function OpenPopup(agentcode, Flag) {
            //debugger;
            //window.open("AgtSearchHierarchydtls.aspx?Flag=P&AgnCd=" + agentcode + "", 'Popup', '');
            window.open("http://localhost:31875/cSharp/Frames/NExampleFrame.aspx?ExampleUrl=Examples/DemoDiagrams/NBusinessCompanyUC.ascx&A= " + agentcode + "&T=agn&Flag=" + Flag + "", 'Popup', 'toolbar=no,scrollbars=yes,resizable=yes,left=50,top=10,location=0');
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

        //Added by Kalyani on 11-12-2013 for collapsable functionality start
        function ShowReqDtl(divId, btnId) {
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
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <table width="80%">
            <tr>
                <td colspan="3" rowspan="3" align="center" style="width: 100%">
                    &nbsp;
                    <table style="border-collapse: collapse; left: -0.03in; text-align: left; position: relative;
                        background-image: url(Images\background.jpg); height: 18px;" width="100%">
                        <tr align="left">
                            <td align="left">
                                <asp:ImageButton ID="lnkTab1" runat="server" CssClass="TextBox" BackColor="transparent"
                                    ImageUrl="~/theme/iflow/employee.GIF" OnClick="lnkTab1_Click" />
                                <asp:ImageButton ID="lnkTab2" runat="server" Enabled="false" Visible="false" CssClass="TextBox"
                                    BackColor="Transparent" ImageUrl="~/theme/iflow/Agent.gif" OnClick="lnkTab2_Click" />
                                <asp:ImageButton ID="lnkTab3" runat="server" Enabled="false" Visible="false" CssClass="TextBox"
                                    BackColor="Transparent" ImageUrl="~/theme/iflow/other.gif" OnClick="lnkTab3_Click" />
                            </td>
                        </tr>
                        <tr id="trHead" runat="server" visible="false">
                            <td align="left" class="test formHeader">
                                <asp:Label ID="lblSourceName" Visible="false" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="border-collapse: separate; left: -0.03in; position: relative;" width="100%"
                        class="formtable">
                        <tr>
                            <td colspan="4" align="left" class="test formHeader">
                                <%-- Added by Kalyani on 11-12-2013 for collapsable functionality start--%>
                                <input runat="server" type="button" class="standardlink" value="-" id="btnBasicCollapse"
                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtBasicSearch','ctl00_ContentPlaceHolder1_btnBasicCollapse');" />
                                <%-- Added by Kalyani on 11-12-2013 for collapsable functionality end--%>
                                <asp:Label ID="lblbas" runat="server" Text="Basic Search" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div id="divAgtBasicSearch" runat="server" style="display: block;">
                        <%-- Added by Kalyani on 11-12-2013 for collapsable functionality --%>
                        <table style="border-collapse: separate; left: -0.03in; position: relative; top: 8px;"
                            width="100%" class="formtable table-condensed">
                            <tr>
                                <td class="formcontent" align="left" style="height: 21px; width: 20%;">
                                    <asp:Label ID="lblAgntCode" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px; width: 30%;" align="left">
                                    <asp:TextBox ID="txtAgntCode" runat="server" CssClass="standardtextbox" Width="200px"></asp:TextBox>
                                </td>
                                <td class="formcontent" align="left" style="height: 21px; width: 20%;">
                                    <asp:Label ID="lblAgntName" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px; width: 30%;" align="left">
                                    <asp:TextBox ID="txtAgntName" runat="server" CssClass="standardtextbox" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:Label ID="lblRptType" runat="server" Text="Reporting Type"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:UpdatePanel ID="updRptType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlRptTyp" runat="server" AutoPostBack="true" Width="203px"
                                                OnSelectedIndexChanged="ddlRptTyp_SelectedIndexChanged" Font-Size="11px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:RadioButtonList ID="rdbRptTyp" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem Value="1" Text="Administrative"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Functional"></asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                </td>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:Label ID="lblImmLeaderCode" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:UpdatePanel ID="updMgrCode" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtImmLeaderCode" runat="server" CssClass="standardtextbox" Enabled="false"
                                                Width="200px"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRptTyp" EventName="selectedindexchanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" style="height: 21px;" align="left">
                                    <asp:Label ID="lblSapCode" runat="server"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px;" align="left">
                                    <asp:TextBox ID="txtSapCode" runat="server" CssClass="standardtextbox" Width="200px"></asp:TextBox>
                                </td>
                                <td class="formcontent" style="height: 21px;" align="left">
                                    <asp:Label ID="lblShwRecords" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px;" align="left">
                                    <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="standardmenu" Width="203px"
                                        Font-Size="11px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="border-collapse: separate; left: -0.03in; position: relative; top: 8px;"
                        width="100%" class="formtable">
                        <tr>
                            <td colspan="4" align="left" class="test formHeader">
                                <%-- Added by Kalyani on 11-12-2013 for collapsable functionality start--%>
                                <input runat="server" type="button" class="standardlink" value="-" id="btnAdvCollapse"
                                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtAdvSearch','ctl00_ContentPlaceHolder1_btnAdvCollapse');" />
                                <%-- Added by Kalyani on 11-12-2013 for collapsable functionality end--%>
                                <asp:Label ID="lbladvsrch" runat="server" Text="Advance Search" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div id="divAgtAdvSearch" runat="server" style="display: block;">
                        <table style="border-collapse: separate; left: -0.03in; position: relative; top: 8px;"
                            width="100%" class="formtable table-condensed">
                            <tr>
                                <td class="formcontent" style="width: 20%; height: 21px" align="left">
                                    <asp:Label ID="lblchnltype" runat="server" Text="Hierarchy Type"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px; width: 30%;" align="left">
                                    <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" TabIndex="8">
                                                <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                <asp:ListItem Selected="True" Value="1" Text="Channel"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 20%; height: 21px" align="left">
                                    <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                </td>
                                <td class="formcontent" style="width: 30%; height: 21px" align="left">
                                    <%--<asp:RadioButtonList ID="rdbPosn" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:DropDownList ID="ddlPosition" runat="server" Width="203px" Font-Size="11px">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" style="height: 13px" align="left">
                                    <asp:Label ID="lblSlsChnnl" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 13px;" align="left">
                                    <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlSlsChnnl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSlsChnnl_SelectedIndexChanged"
                                                CssClass="standardmenu" Width="203px" Font-Size="11px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblIDNo" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:TextBox ID="txtPAN" runat="server" CssClass="standardtextbox" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="formcontent">
                                    <asp:Label ID="lblChnCls" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="formcontent">
                                    <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" Width="203px" Font-Size="11px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSlsChnnl" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" align="left">
                                    <asp:Label ID="lblAgntStatus" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" align="left">
                                    <asp:DropDownList ID="ddlAgntStatus" runat="server" CssClass="standardmenu" Width="203px"
                                        Font-Size="11px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:Label ID="lblAgntType" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:UpdatePanel ID="upnlAgnType" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlAgntType" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                                OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" Width="203px" Font-Size="11px">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="height: 21px" align="left">
                                    <asp:Label ID="lblUnitCode" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px;" align="left">
                                    <asp:TextBox ID="txtUnitCode" runat="server" CssClass="standardtextbox" Width="200px"></asp:TextBox>
                                    &nbsp;<asp:Button ID="btnUnitCode" runat="server" CssClass="standardbutton" Text="...."
                                        UseSubmitBehavior="False" Width="20px" />
                                </td>
                                <%--Added by Rachana on 14-05-2013 for removing onclick event of txtUnitCode control--%>
                            </tr>
                            <tr>
                                <td class="formcontent" align="left" style="height: 21px; width: 20%;">
                                    <asp:Label ID="lblDTJoinFrom" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px; width: 30%;" align="left">
                                    <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtDTJoinFrom" Width="200px" />
                                    <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                    <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                                        runat="server" Width="80px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" CssClass="ajax__calendar"
                                        runat="server" TargetControlID="txtDTJoinFrom" PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                                    <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtDTJoinFrom"
                                        Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                    <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                        Type="Date" ControlToValidate="txtDTJoinFrom" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                    <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtDTJoinFrom" Display="Dynamic"
                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                        Type="Date"></asp:RangeValidator>
                                </td>
                                <td class="formcontent" align="left" style="height: 21px; width: 20%;">
                                    <asp:Label ID="lblDTJoinTo" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 21px; width: 30%;" align="left">
                                    <%-- <uc3:ctlDate id="txtDTJoinTo" runat="server" cssclass="standardtextbox" width="90" requiredfield="false" requiredvalidationmessage="Mandatory!" />--%>
                                    <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtDTJoinTo" Width="200px" />
                                    <asp:Image ID="btnCalendar1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                    <asp:TextBox CssClass="standardtextbox" ID="TextBox2" Style="display: none" runat="server"
                                        Width="80px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="ajax__calendar" runat="server"
                                        TargetControlID="txtDTJoinTo" PopupButtonID="btnCalendar1" Format="dd/MM/yyyy" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                        ControlToValidate="TextBox2" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!"
                                        Operator="DataTypeCheck" Type="Date" ControlToValidate="TextBox2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
                                        Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                        MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr id="trcsc" runat="server" visible="false">
                                <td class="formcontent" align="left" style="height: 24px">
                                    <asp:Label ID="lblCSCCode" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" align="left" colspan="1" style="height: 24px">
                                    <asp:TextBox ID="txtCSCCode" runat="server" CssClass="standardtextbox" Width="103px"
                                        MaxLength="6"></asp:TextBox>
                                </td>
                                <td class="formcontent" style="height: 24px" align="left">
                                    &nbsp;
                                </td>
                                <td class="formcontent" style="height: 24px" align="left" colspan="1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trlnkref" runat="server" visible="false">
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblRefAdv" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:TextBox ID="txtLinkRef" runat="server" CssClass="standardtextbox" Width="103px"></asp:TextBox>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblClientCode" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:TextBox ID="txtGCN" runat="server" CssClass="standardtextbox" Width="103px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trfranch" runat="server" visible="false">
                                <td align="left" class="formcontent" style="height: 13px">
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblchbox" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblFranchisee" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:CheckBox ID="chbxdefaultunit" runat="server" Text="" Visible="false" />
                                    <asp:CheckBox ID="ChkFranchisee" runat="server" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblLicenseNo" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:TextBox ID="txtLicNo" runat="server" CssClass="standardtextbox" MaxLength="20"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                </td>
                            </tr>
                            <tr id="trCDAHierarchy" runat="server">
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:Label ID="lblCDALinkg" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    <asp:CheckBox ID="CDACheck" runat="server" Text="" />
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                    &nbsp;
                                </td>
                                <td align="left" class="formcontent" style="height: 13px">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="border-collapse: separate; left: -0.03in; position: relative; top: 8px;"
                        width="100%" class="formtable">
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" Text="SEARCH"
                                    Width="80px" OnClick="btnSearch_Click" OnClientClick="ShowReqDtlonSearch('ctl00_ContentPlaceHolder1_divAgtAdvSearch','ctl00_ContentPlaceHolder1_btnAdvCollapse');" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" Text="CLEAR" Width="80px"
                                    OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="80%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="80%" cellspacing="0">
            <tr id="trDetails" runat="server">
                <td colspan="3" align="left" class="test formHeader">
                    <asp:Label ID="lblAgtSrchRes" runat="server" Text="Agent Search Results" Width="150px"
                        Font-Bold="true"></asp:Label>
                    <span style="padding-left: 72%;"></span>
                    <asp:Label ID="lblPageInfo" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trDgDetails" runat="server">
                <td class="formcontent" colspan="4" style="height: 21px">
                    <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        HorizontalAlign="Left" Width="100%" OnRowDataBound="dgDetails_RowDataBound" OnPageIndexChanging="dgDetails_PageIndexChanging"
                        RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue" BorderStyle="Solid"
                        BorderColor="Gray" PagerStyle-HorizontalAlign="Center" AllowSorting="True" OnSorting="dgDetails_Sorting">
                        <Columns>
                            <%--<asp:BoundField HeaderText="Agent Code" DataField="AgentCode" SortExpression="AgentCode">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Agent Code" SortExpression="Agent Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblAgtCode" runat="server" Visible="true" Text='<%# Bind("AgentCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SAP Code" SortExpression="EMPCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpcode" runat="server" Visible="true" Text='<%# Bind("EMPCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%--<asp:BoundField HeaderText="Prmy Manager Code" DataField="MgrCode" SortExpression="MgrCode">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Addl Manager Code" DataField="AddlReporting" SortExpression="AddlReporting">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Primary Manager Code">
                                <ItemTemplate>
                                    <asp:LinkButton Enabled="false" ID="lbPrmyMgrCode" runat="server" Text="View" OnClick="lbPrmyMgrCode_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Additional Manager Code">
                                <ItemTemplate>
                                    <asp:LinkButton Enabled="false" ID="lbAddlMgrCode" runat="server" Text="View" OnClick="lbAddlMgrCode_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" />
                            <asp:BoundField HeaderText="Sub Class" DataField="ChnCls" SortExpression="ChnCls" />
                        </Columns>
                        <HeaderStyle CssClass="portlet blue" HorizontalAlign="Center" ForeColor="White" />
                        <PagerStyle CssClass="pagelink" ForeColor="Blue" HorizontalAlign="Center" />
                        <RowStyle CssClass="sublinkodd"></RowStyle>
                        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAgentRole" runat="server" />
    </center>
    <script type="text/javascript">
        //Added by Rachana on 14/05/2013 for replacing js funOpenPopWinForUntCode with funcShowPopup start     


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
    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
    <%--Added by Rachana on 14/05/2013 for panel pnlMdl start--%>
    <asp:Panel runat="server" ID="Panel1" Width="700" display="none">
        <iframe runat="server" id="Iframe1" width="700" height="700px" frameborder="0" display="none">
        </iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label2" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlView"
        DropShadow="false" TargetControlID="Label2" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Added by Rachana on 14/05/2013 for panel end--%>
</asp:Content>

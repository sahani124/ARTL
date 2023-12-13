<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FrmPreffExmDtls.aspx.cs" Inherits="Application_INSC_Recruit_FrmPreffExmDtls" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
   <%-- <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
    </script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script>
     //added by pranjali on 11-04-2014 start
        function ShowReqDtl(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //added by pranjali on 11-04-2014 end
        //added by pranjali on 11-04-2014 start
        function funValidate() {
            
//            if (document.getElementById(strContent + "txtExmdt1").value == "") {
//                alert("Preffered Exam Date1 is Mandatory.");
//                document.getElementById(strContent + "txtExmdt1").focus();
//                return false;
//            }
//            if (document.getElementById(strContent + "txtExmdt2").value == "") {
//                alert("Preffered Exam Date2 is Mandatory.");
//                document.getElementById(strContent + "txtExmdt2").focus();
//                return false;
//            }
            
            //added by pranjali on 11-04-2014 start
            //added by pranjali on 11-04-2014 end
            if ((document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                alert("Exam Mode is Mandatory.");
                document.getElementById('<%= ddlExam.ClientID %>').focus();
                return false;
            }

            if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                alert("Exam Body is Mandatory.");
                document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                return false;
            }

            if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                alert("Exam language is Mandatory.");
                document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                return false;
            }
            if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
                alert("Exam Centre is Mandatory.");
                document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
                return false;
            }

            //added by pranjali on 11-04-2014 end

        }

        </script>
    <center>
    <table cellpadding="0" cellspacing="2" style="width: 80%;">
    <tr><td>
        <table style="width: 90%; border-collapse: collapse;" cellspacing="5" cellpadding="4" border="0">
        <tr id="tr_message" runat="server" align="center" style="visibility:hidden">
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        </table>
        </td></tr>
        <tr><td>
        <table id="Table1" runat="server" style="border-collapse: separate; left: 0in; position: relative; top: 0px; width: 90%;" >
            <tr>
                <td class="test" align="left" colspan="4" style="height:20px;">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblCndNo" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblCndNoValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblAppNo" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblAppNoValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblCndName" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblCndNameValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblBranchValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblPAN" runat="server" Font-Bold="False"></asp:Label>
                    
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    
                         <asp:Label ID="lblPANValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                    
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblMobileValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="width: 20%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblEmail" runat="server" ></asp:Label>
                    
                </td>
                <td style="width: 30%; height: 20px" class="formcontent" align="left">
                    <asp:Label ID="lblEmailValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>

        </table>
         </td></tr>
        <tr><td>
        <table visible="true" runat="server" id="tbltrn" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblTrnDtl" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnInstitute" runat="server" Style="color: black" ></asp:Label>
                        
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnInstituteValue" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnLoc" runat="server" Style="color: black" ></asp:Label>
                        
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblTrnLocValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblTrnMode" runat="server" Style="color: black" ></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;" colspan="3">
                     <asp:Label ID="lblTrnModeValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
            </table>
             </td></tr>

             <%--added by pranjali on 11-04-2014 start--%>
        <tr>
        <td>
        
        <table style="width: 90%" class="formtable">
                <tr>
                    <td class="test" colspan="4">
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnExmDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl','ctl00_ContentPlaceHolder1_btnExmDtls');" />
                            
                              <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>
            </table>   
            <div runat="server" id="divAgnPhotoTrnExmDtl" visible="true">
            <table runat="server" id="tblexam" class="tableIsys" style="width: 90%;">
                <%--<tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: #ff0000"><asp:Label ID="lblExammode" runat="server" Font-Bold="False" style="color:Black"></asp:Label>
                        *</span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updExam" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="185px" >
                                    <%-- CssClass="standardmenu" DataTextField="ParamDesc1" DataValueField="ParamValue" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"
                                    AppendDataBoundItems="True" DataSourceID="DSddlExam"--%>
                                </asp:DropDownList>
                                <%--<asp:SqlDataSource ID="DSddlExam" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                       <span style="color: #ff0000"><asp:Label ID="lblExmBody" runat="server" Style="color: black"></asp:Label>
                        *</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdExmBody" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlExmBody" runat="server" CssClass="standardmenu" Width="185px">
                                    <%--<asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                    <asp:ListItem Text="NSE.IT" Value="NSEIT"></asp:ListItem>
                                    <asp:ListItem Text="III Online" Value="IIIOn"></asp:ListItem>
                                    <asp:ListItem Enabled="false" Text="III Offline" Value="IIIOf"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                    <span style="color:Red">
                        <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" Text="Prefer Exam Lang" style="color:Black"></asp:Label>*</span>
                        <%--<span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px"> 
                                   <%--DataTextField="ParamDesc1" DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">--%>
                                </asp:DropDownList>
                                <%--<asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblCentre" runat="server" Style="color: black"></asp:Label>*</span>
                     <%--   <span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="updExmCentre" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="standardmenu" Width="185px"> 
                                </asp:DropDownList>
                                <asp:TextBox ID="txtExmCentre" runat="server" Enabled="true" CssClass="standardtextbox" Visible="false"></asp:TextBox>
                                <input type="hidden" runat="server" id="hdnExmCentreCode" name="hdnExmCentreCode" />
                                <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton" Visible="false"
                                    Text="..." />&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        </td>
        </tr>
        <tr id="trnewexmdtls" runat="server" visible="false">
        <td>
        
        <table style="width: 90%" class="formtable" visible="false">
                <tr>
                    <td class="test" colspan="4">
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="Button1"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div1','ctl00_ContentPlaceHolder1_Button1');" />
                            
                              <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>
            </table>   
            <div runat="server" id="div1" visible="false">
            <table runat="server" id="Table4" class="tableIsys" style="width: 90%;">
                <%--<tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: #ff0000"><asp:Label ID="lblExammode1" runat="server" Font-Bold="False" Style="color: black"></asp:Label>
                        *</span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="standardmenu" AutoPostBack="true" Width="185px" >
                                    <%-- CssClass="standardmenu" DataTextField="ParamDesc1" DataValueField="ParamValue" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"
                                    AppendDataBoundItems="True" DataSourceID="DSddlExam"--%>
                                </asp:DropDownList>
                                <%--<asp:SqlDataSource ID="DSddlExam" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: #ff0000"><asp:Label ID="lblExmBody1" runat="server" Style="color: black"></asp:Label>
                        *</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="standardmenu" Width="185px">
                                    <%--<asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                    <asp:ListItem Text="NSE.IT" Value="NSEIT"></asp:ListItem>
                                    <asp:ListItem Text="III Online" Value="IIIOn"></asp:ListItem>
                                    <asp:ListItem Enabled="false" Text="III Offline" Value="IIIOf"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                    <span style="color:Red">
                        <asp:Label ID="lblpreexamlng1" runat="server" Font-Bold="False" style="color:Black"></asp:Label>*</span>
                        <%--<span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="standardmenu" Width="185px"> 
                                   <%--DataTextField="ParamDesc1" DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">--%>
                                </asp:DropDownList>
                                <%--<asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblCentre1" runat="server" Style="color: black"></asp:Label>*</span>
                     <%--   <span style="color: #ff0000">*</span>--%>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="standardmenu" Width="185px"> 
                                </asp:DropDownList>
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="true" CssClass="standardtextbox" Visible="false"></asp:TextBox>
                                <input type="hidden" runat="server" id="Hidden1" name="hdnExmCentreCode" />
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="standardbutton" Visible="false"
                                    Text="..." />&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        </td>
        </tr>
        <%--added by pranjali on 11-04-2014 end--%>
        

             <tr><td>
        <table id="Table2" runat="server" style="width: 90%" class="tableIsys">
            <tr>
                <td class="test" align="left" colspan="4">
                    <asp:Label ID="LblExam" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblExmDt" runat="server" Style="color: black" ></asp:Label>
                        
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblExmDtValue" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="Label1" runat="server"></asp:Label> 
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </td></tr>
            <tr><td>
        <table visible="true" runat="server" id="Table3" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblprefexmschdl" runat="server" Font-Bold="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>
                            <%--<span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <uc7:ctlDate ID="txtExmdt1" runat="server" CssClass="standardtextbox" Width="150"
                                        RequiredValidationMessage="Mandatory!" RequiredField="false"></uc7:ctlDate>
                            <%--<asp:TextBox CssClass="standardtextbox" Width="201px" runat="server" ID="txtExmdt1" 
                        TabIndex="12" BackColor="#FFFFB2" />
                    <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                    <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                        runat="server" Width="80px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtExmdt1"
                        PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtExmdt1"
                        Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                        Type="Date" ControlToValidate="txtExmdt1" Display="Dynamic"></asp:CompareValidator>&nbsp;
                    <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtExmdt1" Display="Dynamic"
                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                        Type="Date"></asp:RangeValidator>--%>
                        </td>
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <asp:Label ID="lblExmdt2" runat="server" Text="Preffered Exam Date 2" Font-Bold="False"></asp:Label>
                            <%--<span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <uc7:ctlDate ID="txtExmdt2" runat="server" CssClass="standardtextbox" Width="150"
                                        RequiredValidationMessage="Mandatory!" RequiredField="false"></uc7:ctlDate>
                            <%--<asp:TextBox CssClass="standardtextbox" Width="201px" runat="server" ID="txtExmdt2" 
                        TabIndex="12" BackColor="#FFFFB2" />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                    <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate1" Style="display: none"
                        runat="server" Width="80px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExmdt2"
                        PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="txtExmdt2"
                        Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                        Type="Date" ControlToValidate="txtExmdt2" Display="Dynamic"></asp:CompareValidator>&nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtExmdt2" Display="Dynamic"
                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                        Type="Date"></asp:RangeValidator>--%>
                        </td>
                    </tr>
                </table>
                </td></tr>
                <tr><td>
        <table>
                    <tr>
                        <td style="height: 20px" align="center" colspan="4">
                        <%-- <div class="btn btn-xs btn-primary"><i class="fa fa-check"></i>--%>
                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                CssClass="standardbutton" Width="114px"></asp:Button><%--</div>--%>
                             <%--   <div class="btn btn-xs btn-primary"><i class="fa fa-times"></i>--%>
                            <asp:Button ID="btnClear" TabIndex="43" OnClick="btnClear_Click" runat="server" Text="Cancel"
                                CssClass="standardbutton" Width="114px"></asp:Button><%--</div>--%>
                        </td>
                    </tr>
            </table>
            </td></tr>
            </table>
    </center>
    <%--For Displaying Dropshadow of mdlView Start--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <%--For Displaying Dropshadow of mdlView End--%>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <%--For Displaying Information Pop-up Start--%>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="309px" Height="182px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="lbl_popup" runat="server"></asp:Label><br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" CssClass="btn btn-xs btn-primary" TabIndex="1205" Width="81px" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl_popup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--For Displaying Information Pop-up End--%>
</asp:Content>

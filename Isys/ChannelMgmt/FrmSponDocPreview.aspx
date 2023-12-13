<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmSponDocPreview.aspx.cs" Inherits="Application_ISys_ChannelMgmt_FranchiesEnrollment_FrmSponDocPreview" %>

<%--<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />

    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    
    
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
   



 <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
   
  <style type="text/css">
    
    .clscenter{
        text-align:center!important;
    }
     .Pv {
    font-size: 16px;
    font-weight: normal;
    text-align:center;
         }
	   </style>
    <%--Added by rahana end--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    <table style="width: 100%">
        <tr>
                        <td align="right" colspan="4">
                            <asp:ImageButton ID="Img2" runat="server" Visible="true" ForeColor="Red" OnClientClick="CloseSub()" src="~/theme/iflow/Error.JPG"/>
                            
                        </td>
                    </tr>
                    </table>
        <div id="divSearchDetails" runat="server">
            <table style="width: 90%" class="tableIsys">
                <tbody>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="red"></asp:Label>
                            <asp:Label ID="lblSuccessMsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="test" align="left" colspan="4">
                            <asp:Label ID="lblTitle" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAppNo" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAppNoValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAdvNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
                </tbody>
            </table>
            <table style="width: 90%" class="formtable table-condensed">
                <tr>
                    <td class="test" colspan="4">
                        <%--//added by pranjali for id on 11-04-2014--%>
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnUploadDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails','ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                        <asp:Label ID="lblCnddtls" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="divIsSpecified" runat="server" style="display: block;">
                <asp:UpdatePanel ID="Updatepanel14" runat="server">
                    <ContentTemplate>
                        <table class="tableIsys" style="width: 90%;">
                            <tr>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:Label ID="lblIsSPFlag" runat="server" Style="color: black"></asp:Label>
                                </td>
                                <td style="width: 30%;" class="formcontent">
                                    <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                Visible="true" TabIndex="25" Enabled="false">
                                                <%--AutoPostBack="true" OnSelectedIndexChanged="rbtIsSP_SelectedIndexChanged"--%>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 20%;" class="formcontent">
                                </td>
                                <td style="width: 30%;" class="formcontent">
                                </td>
                            </tr>
                            <tr id="tr_IsSPDtls" visible="false" runat="server">
                                <td class="formcontent" style="width: 20%;">
                                    <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCACode" runat="server" Style="color: black"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCACode" runat="server" CssClass="standardtextbox" MaxLength="20"
                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> 
                                            </asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server"
                                                InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                FilterMode="InvalidChars" TargetControlID="txtCACode" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:UpdatePanel ID="Updatepanel17" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblCAName" runat="server" Style="color: black"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:UpdatePanel ID="Updatepanel18" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCAName" runat="server" CssClass="standardtextbox" MaxLength="20"
                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();">
                                            </asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender76" runat="server"
                                                InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" FilterMode="InvalidChars"
                                                TargetControlID="txtCAName" FilterType="Custom">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div runat="server" id="divagndetails" style="display: block">
                <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
                <table runat="server" id="tbltest" style="width: 90%" class="tableIsys">
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndNo" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndNoValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left" colspan="2">
                            <asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>
                            <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                            <asp:CheckBox ID="chkAdvWaiver" runat="server" Visible="false" AutoPostBack="true"
                                OnCheckedChanged="chkAdvWaiver_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdvisorWaiver" runat="server" Visible="false" Text="Waiver Advisor"
                                Width="100" CssClass="standardbutton" />
                            <asp:HiddenField ID="hdnAdvWaiver" runat="server" />
                            <asp:HiddenField ID="hdnCsccode" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <%-- commented by pranjali on 27-12-2013--%>
                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                        <%-- commented by pranjali on 27-12-2013--%>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<tr>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDate" runat="server" Text="Training Start Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 160px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDate" runat="server" Text="Training End Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 210px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <tr>
                        <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblReqStatus" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblReqStatusValue" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDtValue" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <span style="color: Red">
                                <asp:Label ID="lblMobileNo" Text="Mobile No" runat="server" Style="color: Black"></asp:Label>*</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%--  <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                            <asp:TextBox ID="txtmobilecode" runat="server" Text="91" CssClass="standardtextbox"
                                Width="25px" Enabled="false" BackColor="#FFFFB2"></asp:TextBox>
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="standardtextbox"
                                Width="155px" BackColor="#FFFFB2"></asp:TextBox><%-- onblur="form2();"--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <%-- added by shravana 14jun2013--%>
                            <asp:Button ID="btnverifymobile" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                CssClass="standardbutton" OnClick="btnverifymobile_Click" OnClientClick="return form2();">
                            </asp:Button>
                            <div id="divmob" class="Content" style="display: none">
                                <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                Loading...</div>
                            <br />
                            <asp:Label ID="lblmobileverify" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                            <%--Added by rachana on 14-08-2013 to verify email end--%>
                            <%-- added by shravana 14jun2013--%>
                        </td>
                        <td style="width: 20%; height: 38px" class="formcontent" align="left">
                            <span style="color: Red">
                                <asp:Label ID="lblPAN" runat="server" Text="PAN No" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%--  <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 38px" class="formcontent" align="left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="standardtextbox"
                                        onChange="javascript:this.value=this.value.toUpperCase();" BackColor="#FFFFB2"
                                        ></asp:TextBox>
                                    <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="standardbutton"
                                        OnClick="btnVerifyPAN_Click" ValidationGroup="RecruitInfo" ></asp:Button>
                                    <div id="divPAN" class="Content" style="display: none">
                                        <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                        Loading...</div>
                                    <br />
                                    <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                    <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                    <%--Added by pranjali on 14-03-2014--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <span style="color: Red">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" Style="color: Black"></asp:Label>*</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%-- <span style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtEMail" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                onblur="validateEmail1(this.value)"></asp:TextBox><%--onblur="validateEmail1(this.value)"--%>
                            <%-- added by shravana14jun2013--%>
                            <asp:Button ID="btnverifyemail" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                CssClass="standardbutton" OnClick="btnverifyemail_Click" OnClientClick="return validateEmail1();">
                            </asp:Button><%--OnClientClick="funshowdiv();"--%>
                            <%--Added by rachana on 14-08-2013 to verify email start--%>
                            <div id="divEmail" class="Content" style="display: none">
                                <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                Loading...</div>
                            <br />
                            <asp:Label ID="lblEmailMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                            <%--Added by rachana on 14-08-2013 to verify email end--%>
                            <%-- added by shravana14jun2013--%>
                        </td>
                        <%--ank strt 12.01.2011--%>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblpandetail" runat="server" Text="Is Pan name different from registered name"
                                Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:CheckBox ID="Chkpan" runat="server" />
                        </td>
                    </tr>
                    
                    <%--  added by shreela 21032014--%>
                    <tr id="trlicn" runat="server" visible="false">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                             <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                        </td>
                    </tr>
                    <%--  added by shreela 21032014--%>
                    <%--added by rachana on 14032013 for fees Details start--%>
                    <%--added by rachana on 14032013 for fees Details end--%>
                    <!--ank end 12.01.2011-->
                    <%--</tbody>--%>
                    <tr align="center">
                        <td>
                            <asp:Label ID="LabelFees" runat="server" Visible="false" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <table id="tblIcmColl" runat="server"  style="width:90%" class="tableIsys">
            <tr>
                    <td align="left" class="test" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnICMDtls"
                    style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivICMDtls','ctl00_ContentPlaceHolder1_btnICMDtls');" />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Payment Details"
                    ></asp:Label>
                    </td>
            </tr>
        </table>
        <div runat="server" id="DivICMDtls" style="display: none">
        <table runat="server" id="tblICMDtls" class="tableIsys" style="width: 90%;">
        <tr id="FeesRow" runat="server" visible="true">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <span id="spwebtoken" runat="server" style="color: Red">
                                <asp:Label ID="lblWebTknReceived" Text="Fees Collected" runat="server" Style="color: Black"></asp:Label>*</span>
                            <%--  added by shreela on 10/03/14--%>
                            <%-- <span id="spwebtoken" runat="server" style="color: #ff0000">*</span>--%>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left" nowrap="nowrap">
                            <asp:UpdatePanel ID="updChkFees" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox ID="chkWebTknRecd" runat="server" OnCheckedChanged="chkWebTknRecd_CheckedChanged"
                                        AutoPostBack="true" Enabled="false" Visible="false"/>
                                    <%--<asp:TextBox ID="txtFeesRcvd" runat="server" CssClass="standardtextbox" Width="130px" TabIndex="10" Visible="false"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FTEFees" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtFeesRcvd" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    <asp:HiddenField ID="hdnVerifyFees" runat="server"></asp:HiddenField>
                                    <%--<asp:Button ID="btnGetFeeDetails" runat="server" Text="Get Details" width="80px"
                                CssClass="standardbutton" onclick="btnGetFeeDetails_Click" ></asp:Button>--%>
                                    <asp:LinkButton ID="lnkGetFees" runat="server" Text="Get Fees" OnClick="lnkGetFees_Click" Enabled="false"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>--%>
                            <%--</ContentTemplate>
                              <Triggers><asp:AsyncPostBackTrigger ControlID="chkWebTknRecd" EventName="CheckedChanged" /></Triggers>
                              </asp:UpdatePanel>--%>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lbladvWaiverbtn" runat="server" Visible="false" Text="Upload Adv's Waiver Form"></asp:Label>
                            <span id="spwaiver" runat="server" visible="false" style="color: #ff0000">*</span>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAdvWaiverUpl" runat="server" Visible="false"></asp:Label>
                            <asp:FileUpload ID="AdvWaiverUpload" runat="server" Visible="false" Width="98%">
                            </asp:FileUpload>
                            <asp:CustomValidator ID="CVAdvWaiverValidator" runat="server" ControlToValidate="AdvWaiverUpload"
                                OnServerValidate="CVAdvWaiverValidator_ServerValidate" SetFocusOnError="True"> </asp:CustomValidator>
                        </td>
                    </tr>
        <tr id="trTokenwithFees"  runat="server">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTknNo" runat="server" Text="Token No"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTknNoValue" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTotfees" runat="server" Text="Total Fees"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTotfeesValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trTokenwithLatestFees" runat="server" style="display:none">
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTknNoLst" runat="server" Text="Token No"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTknNoLstDesc" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTotfeesLst" runat="server" Text="Fees as on todays date"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTotfeesLstDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
        </table>
        </div>
        <%--New ICM Details Added by rachana on 30-04-2014 Start --%>
        <table id="tblICMManual" runat="server" width="90%">
            <tr>
                <td align="left" class="test" colspan="4">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnICM"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divICM','ctl00_ContentPlaceHolder1_btnICM');" />
                    <asp:Label ID="lblNICMTitle" runat="server" Font-Bold="True" Text="Fees Details Edit"
                        Width="860px"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divICM" style="display: none">
            <table runat="server" id="tblICMDetails" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblPymtMode" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="upldPayment" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DDlPymtMode" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="185px" OnSelectedIndexChanged="DDlPymtMode_SelectedIndexChanged" TabIndex="15">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPymtAmt" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="updpayment" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPymtAmt" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEAmt" runat="server" InvalidChars="/\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtPymtAmt" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:UpdatePanel ID="updchqlbl" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblChequeNo" runat="server" Font-Bold="False"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updchq" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequeNo" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEChqNo" runat="server" InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtChequeNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:UpdatePanel ID="updchqdate" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblChequeDate" runat="server" Font-Bold="False"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="upddate" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtChequedate" runat="server" CssClass="standardtextbox" TabIndex="22" />
                                <asp:Image ID="btncal" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="txtcal" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChequedate"
                                    PopupButtonID="btncal" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtChequedate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR1" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtChequedate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtChequedate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblBankName" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updbnkname" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBankName" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEBnkName" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Custom"
                                    ValidChars=" " TargetControlID="txtBankName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <asp:Label ID="lblEFT" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="upldeft" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextEFT" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEEFT" runat="server" InvalidChars="/.\?<>{}[];:|=+_,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="TextEFT" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent2" colspan="4" style="width: 20%; height: 24px;">
                        <asp:UpdatePanel ID="updAdd" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="BtnAdd" runat="server" Text="Add" CssClass="standardbutton" Width="114px"
                                    OnClick="BtnAdd_Click"></asp:Button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--New ICM Details Added by rachana on 30-04-2014 end --%>
        <asp:UpdatePanel ID="updgridfees" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="TblFees" style="width: 90%" class="formtable table-condensed" runat="server"
                    visible="false">
                    <tr>
                        <td colspan="4" align="left" class="test">
                            <input runat="server" type="button" value="+" id="btnfees" style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divFees','ctl00_ContentPlaceHolder1_btnfees');"
                                class="btn btn-xs btn-primary" />
                            <asp:Label ID="lblFeesDtls" Text="Fees Collected Details" runat="server" Font-Bold="true"></asp:Label>
                            <%--shreela 24032014--%>
                        </td>
                    </tr>
                </table>
                <div id="divFees" runat="server" style="display: none;">
                    <table id="tblfeesdtl" style="width: 90%" class="tableIsys" runat="server">
                        <tr id="trfeesDetails1" runat="server">
                            <td style="height: 20px" class="formcontent">
                                <asp:GridView ID="dgPaymentdtls" runat="server" PagerStyle-HorizontalAlign="Center"
                                    CssClass="tableIsys" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                    RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" OnRowDataBound="dgPaymentdtls_RowDataBound" OnRowCommand="dgPaymentdtls_RowCommand"
                                    OnRowDeleting="dgPaymentdtls_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField SortExpression="TokenNo" HeaderText="Token No" ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTokenNo" runat="server" Text='<%# Eval("TokenNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentMode" HeaderText="Payment Mode" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtMode" runat="server" Text='<%# Eval("PaymentMode") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="PaymentDate" HeaderText="Payment Date" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtDt" runat="server" Text='<%# Eval("PaymentDate","{0:dd/MM/yyyy}") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="BankName" HeaderText="Bank Name" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField SortExpression="InstrumentNo" HeaderText="Instrument No" ItemStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentNo" runat="server" Text='<%# Eval("InstrumentNo") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="InstrumentDate" HeaderText="Instrument Date" ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstrumentDt" runat="server" Text='<%# Eval("InstrumentDate","{0:dd/MM/yyyy}") %>'
                                                    Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="Amount" HeaderText="Amount" ItemStyle-Width="6%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPymtAmt" runat="server" Text='<%# Eval("Amount") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="TrxNo" HeaderText="Transaction No" ItemStyle-Width="12%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrxNo" runat="server" Text='<%# Eval("TrxNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ReceiptNo" HeaderText="Receipt Id" ItemStyle-Width="7%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRcptId" runat="server" Text='<%# Eval("RcptNo") %>' Font-Size="Smaller"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="test" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" Enabled="false" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Font-Underline="False" />
                                            <ControlStyle Font-Underline="True" />
                                            <FooterStyle Font-Underline="False" />
                                            <HeaderStyle CssClass="test" Font-Size="Smaller"/>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="standardlink" HorizontalAlign="Center" />
                                    <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                                    </RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<ajax:AsyncPostBackTrigger ControlID="btnGetFeeDetails" EventName="Click" />--%>
                <ajax:AsyncPostBackTrigger ControlID="lnkGetFees" EventName="Click" />
                <ajax:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <%--added by pranjali on 11-04-2014 start--%>
        <asp:UpdatePanel ID="updtblEmsdtls" runat="server">
            <ContentTemplate>
                <table id="tblEmsdtls" runat="server" style="width: 90%" class="formtable table-condensed">
                    <tr>
                        <td class="test" colspan="4">
                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnExmDtls"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divAgnPhotoTrnExmDtl','ctl00_ContentPlaceHolder1_btnExmDtls');" />
                            <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True"></asp:Label>
                            <%--Text="Exam Details"--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <div runat="server" id="divAgnPhotoTrnExmDtl" visible="true" style="display:block">
            <asp:UpdatePanel ID="updexamdetailforqc" runat="server">
                <ContentTemplate>
                    <table runat="server" id="tblexam" class="tableIsys" style="width: 90%;">
                        <%--<tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblExamTitle" runat="server" Font-Bold="True" Text="Exam Details"></asp:Label>
                    </td>
                </tr>--%>
                        <tr>
                            <td class="formcontent" style="width: 20%; height: 24px;">
                                <span style="color: Red">
                                    <asp:Label ID="lblExam" runat="server" Style="color: black" Font-Bold="False"> </asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%; height: 24px;">
                                <asp:UpdatePanel ID="updExam" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExam" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="185px" BackColor="#FFFFB2">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblExmBody" runat="server" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="UpdExmBody" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                            BackColor="#FFFFB2">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="formcontent" style="width: 20%; height: 24px;">
                                <span style="color: Red">
                                    <asp:Label ID="lblpreexamlng" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%; height: 24px;">
                                <asp:UpdatePanel ID="updPreExmLng" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                            BackColor="#FFFFB2">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblCentre" runat="server" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updExmCentre" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlExmCentre" runat="server" CssClass="standardmenu" Width="185px"
                                            BackColor="#FFFFB2" Visible="false">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtExmCentre" runat="server" Enabled="true" CssClass="standardtextbox"
                                            Visible="true" BackColor="#FFFFB2"></asp:TextBox>
                                        <asp:Button ID="btnExmCentre" runat="server" CausesValidation="False" CssClass="standardbutton"
                                            Text="Search" />
                                        <input type="hidden" runat="server" id="hdnExmCentreCode" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <table id="tblExmSchedule" runat="server" style="width: 90%" class="tableIsys"
                visible="false">
                <tr>
                    <td class="test" align="left" colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Exam Schedule" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="test" align="left" colspan="2">
                        <asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblNWExmdt" runat="server" Style="color: black"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblNWExmdtValue" runat="server"></asp:Label>
                        <asp:Label ID="lblNwExmfrmt" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                        <asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 20px;">
                        <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
                    </td>
                </tr>
            </table>
            <table runat="server" id="tblPrefExm" class="tableIsys" style="width: 90%;"
                visible="false">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <%--<asp:Label ID="Label5" Text="Preffered Exam Schedule" runat="server" Font-Bold="true"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%; height: 38px" class="formcontent" align="left">
                        <%--<asp:Label ID="lblExmdt1" Text="Preffered Exam Date 1" runat="server"></asp:Label>--%>
                    </td>
                    <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <%-- <asp:Label ID="lblpref1value" runat="server"></asp:Label>
                        <asp:Label ID="lblprefformat1" runat="server" Text="(dd/mm/yyyy)"></asp:Label>--%>
                    </td>
                    <td style="width: 20%; height: 38px" class="formcontent" align="left">
                        <asp:Label ID="lblExmdt2" runat="server" Text="Preffered Exam Date 2" Font-Bold="False"
                            Visible="false"></asp:Label>
                        <%--<span style="color: #ff0000">*</span> --%>
                    </td>
                    <td style="width: 30%; height: 38px" class="formcontent" align="left">
                        <asp:Label ID="lblpref2value" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblprefformat2" runat="server" Text="(dd/mm/yyyy)" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <%-- Old Exam Details start--%>
        <table id="tbloldexm" runat="server" class="tableIsys" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                 <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldExmDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivOldExmdtls','ctl00_ContentPlaceHolder1_BtnOldExmDtls');" />
                    <asp:Label ID="lbloldexm" runat="server" Font-Bold="True" Text="Old Exam Details"></asp:Label>
                </td>
            </tr>
            </table>
            <div id="DivOldExmdtls" runat="server" style="display: block;">
            <table id="Table2" runat="server" class="tableIsys" style="width: 90%; display:none">
            <tr>
                <td class="formcontent" style="width: 20%; height: 24px;">
                    <asp:Label ID="lblOExam" runat="server" Font-Bold="False" Text="Exam Mode"> </asp:Label>
                    <span style="color: #ff0000">*</span>
                </td>
                <td class="formcontent" style="width: 30%; height: 24px;">
                    <asp:TextBox ID="txtExm" runat="server" Enabled="false" CssClass="standardtextbox"
                        BackColor="#FFFFB2"></asp:TextBox>
                </td>
                <td align="left" class="formcontent" style="width: 20%;">
                    <asp:Label ID="lbloldexmbody" runat="server" Style="color: black" Text="Examination Body"></asp:Label>
                    <span style="color: #ff0000">*</span>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:TextBox ID="txtBody" runat="server" Enabled="false" CssClass="standardtextbox"
                        BackColor="#FFFFB2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formcontent" style="width: 20%; height: 24px;">
                    <span style="color: Red">
                        <asp:Label ID="lbloldpref" runat="server" Font-Bold="False" Text="Preffered Exam Language"
                            Style="color: Black"></asp:Label>*</span>
                    <%--<span style="color: #ff0000">*</span>--%>
                </td>
                <td class="formcontent" style="width: 30%; height: 24px;">
                    <asp:TextBox ID="txtLang" runat="server" Enabled="false" CssClass="standardtextbox"
                        BackColor="#FFFFB2"></asp:TextBox>
                    <%--   <asp:UpdatePanel ID="updPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlpreeamlng" runat="server" CssClass="standardmenu" DataTextField="ParamDesc1"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="DSddlpreeamlng">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSddlpreeamlng" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </td>
                <td align="left" class="formcontent" style="width: 20%;">
                    <span style="color: Red">
                        <asp:Label ID="lbloldCentre" runat="server" Style="color: black" Text="Exam Centre"></asp:Label>*</span>
                    <%--   <span style="color: #ff0000">*</span>--%>
                </td>
                <td class="formcontent" style="width: 30%;">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="textoldexmcenter" runat="server" Enabled="false" CssClass="standardtextbox"
                                BackColor="#FFFFB2"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        </div>
        <%--Old Exam Details End --%>
        <%--added by pranjali on 11-04-2014 end--%>
        <%--added by pranjali on 28-04-2014--%>
        <%--New Exam Details Start --%>
        <table id="tblNExmTitle" runat="server" class="formtable table-condensed" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnNwExm"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divNewExmDtls','ctl00_ContentPlaceHolder1_btnNwExm');" />
                    <asp:Label ID="lblNExamTitle" runat="server" Font-Bold="True" Text="New Exam Details"></asp:Label>
                </td>
            </tr>
        </table>
        <div runat="server" id="divNewExmDtls" visible="true" style="display:none">
            <table runat="server" id="tblNexam" class="tableIsys" style="width: 90%;"
                visible="false">
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: #ff0000">
                            <asp:Label ID="lblNExam" runat="server" Font-Bold="False" Style="color: black"> </asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updNExam" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExam" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                    Width="185px" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNExam_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: #ff0000">
                            <asp:Label ID="lblNExmBody" runat="server" Style="color: black"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdNExmBody" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmBody" runat="server" CssClass="standardmenu" Width="185px"
                                    BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNExmBody_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%; height: 24px;">
                        <span style="color: Red">
                            <asp:Label ID="lblNpreexamlng" runat="server" Font-Bold="False" Style="color: Black"></asp:Label>*</span>
                        <%--//removed text by pranjali on 25-04-2014--%>
                    </td>
                    <td class="formcontent" style="width: 30%; height: 24px;">
                        <asp:UpdatePanel ID="updNPreExmLng" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNpreeamlng" runat="server" CssClass="standardmenu" Width="185px"
                                    BackColor="#FFFFB2" OnSelectedIndexChanged="ddlNpreeamlng_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <span style="color: Red">
                            <asp:Label ID="lblNCentre" runat="server" Style="color: black"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNExmCenter" runat="server" CssClass="standardmenu" Visible="false"
                                    BackColor="#FFFFB2" Width="185px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtNExmCenter" runat="server" Enabled="true" CssClass="standardtextbox"
                                    Visible="true" BackColor="#FFFFB2"></asp:TextBox>
                                <asp:Button ID="btnNExmCenter" runat="server" CausesValidation="False" CssClass="standardbutton"
                                    Text="Search" />
                                <input type="hidden" runat="server" id="hdnNExmCenter" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--New Exam Details end --%>
        <%--added by pranjali on 28-04-2014--%>
        <%--pranjali--%>
        <table id="tbltrndtls" runat="server" class="tableIsys" style="width: 90%;"
            visible="false">
            <tr>
                <td class="test" colspan="4" style="text-align: left;">
                <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnOldTrnDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divoldtrndtls','ctl00_ContentPlaceHolder1_BtnOldTrnDtls');" />
                    <asp:Label ID="Label3" Text="Old Training Details" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            </table>
            <div id="Divoldtrndtls" runat="server" style="display: none;">
            <table id="tbltrndtlsall" runat="server" class="tableIsys" style="width: 90%;">
            <tr>
                <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                    <asp:Label ID="lblTrnMode1" runat="server" Style="color: black" Text="Training Mode"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%; height: 20px;">
                    <asp:Label ID="lblTrnModeValue" runat="server"></asp:Label>
                </td>
                <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                    <asp:Label ID="lblTrnLoc1" runat="server" Style="color: black" Text="Training Location"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%; height: 20px;">
                    <asp:Label ID="lblTrnLocValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                    <asp:Label ID="lblTrnInst1" runat="server" Style="color: black" Text="Training Institute"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%; height: 20px;">
                    <asp:Label ID="lblTrnInstituteValue" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                    <asp:Label ID="lblAcc1" runat="server" Style="color: black" Text="Accrediation No."></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%; height: 20px;" colspan="3">
                    <asp:Label ID="lblAccvalue1" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="formcontent" style="width: 20%; height: 20px;">
                    <asp:Label ID="lblTrnHrs1" runat="server" Style="color: black" Text="Training Hours"></asp:Label>
                </td>
                <td class="formcontent" style="width: 30%; height: 20px;">
                    <asp:Label ID="lblTrnHrsValue1" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td id="Td16" class="formcontent" runat="server" style="width: 20%">
                </td>
                <td id="Td17" class="formcontent" runat="server" style="width: 30%">
                </td>
            </tr>
        </table>
        </div>
        <asp:UpdatePanel ID="updtrn" runat="server">
            <ContentTemplate>
               
                    <table visible="false" runat="server" id="tbltrn" class="tableIsys"
                        style="width: 90%;">
                        <tr>
                            <td class="test" colspan="4" style="text-align: left;">
                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnTrnDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_Divtrndtls','ctl00_ContentPlaceHolder1_BtnTrnDtls');" />
                                <asp:Label ID="lblTrnDtl" Text="Training Details" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        </table>
                         <div id="Divtrndtls" runat="server" style="display: block;">
                         <table visible="true" runat="server" id="tbltrndtlss" class="tableIsys"
                        style="width: 90%;">
                        <tr>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="Label2" runat="server" Style="color: black" Text="Training Mode"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updTrnMode" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnMode" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                            Width="250px" BackColor="#FFFFB2" Enabled="true" OnSelectedIndexChanged="ddlTrnMode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblTrnLoc" runat="server" Style="color: black" Text="Training Location"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;" colspan="3">
                                <asp:UpdatePanel ID="updTrnLoc" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnLoc" runat="server" CssClass="standardmenu" Visible="true"
                                            AutoPostBack="true" Width="250px" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlTrnLoc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnLocation" name="hdnTrnLocation" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <%--Added by M.Valvi--%>
                        </tr>
                        <tr>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblTrnInstitute" runat="server" Style="color: black" Text="Training Institute"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:UpdatePanel ID="updTrnInstitute" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTrnInstitute" runat="server" CssClass="standardmenu" Visible="true"
                                            Width="250px" BackColor="#FFFFB2" AutoPostBack="true" OnSelectedIndexChanged="ddlTrnInstitute_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <input type="hidden" runat="server" id="hdnTrnInstitute" name="hdnTrnInstitute" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblAccrdtn" runat="server" Style="color: black" Text="Accreditation Number"></asp:Label>
                            </td>
                            <td style="width: 30%;" class="formcontent" align="left">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblAccrdtnValue" runat="server" MaxLength="50"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="formcontent" align="left">
                                <asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                                <span style="color: #ff0000">*</span>
                            </td>
                            <td style="width: 30%" class="formcontent" align="left">
                                <asp:UpdatePanel ID="updTrnHrs" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlHrsTrn" runat="server" AutoPostBack="true" CssClass="standardmenu"
                                            BackColor="#FFFFB2" Width="250px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                <%--<asp:Label ID="lblHrnTrn" runat="server" Font-Bold="False"></asp:Label>
                        <span style="color: #ff0000">*</span>--%>
                                <asp:Label ID="lblExmType" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px" class="formcontent" align="left">
                                <%--<asp:DropDownList ID="ddlHrsTrn" runat="server" Width="120px">
                            <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>--%>
                                <%--<asp:UpdatePanel ID="updExpTpe" runat="server" >
                            <ContentTemplate>--%>
                                <asp:DropDownList ID="ddlExmTpe" runat="server" Visible="False" Width="120px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlExmTpe_SelectedIndexChanged">
                                    <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                    <asp:ListItem Text="New Advisor" Value="NADV"></asp:ListItem>
                                    <asp:ListItem Text="Repeater" Value="REXM"></asp:ListItem>
                                </asp:DropDownList>
                                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <div id="divPOI" runat="server" visible="false">
            <table runat="server" id="tblPOI" class="tableIsys" style="width: 90%;">
                <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblPOITitle" runat="server" Font-Bold="True" Text="Proof of Document"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicQual" runat="server" Style="color: black" Text="Basic Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:UpdatePanel ID="UpdBasicQual" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlBasicQual" runat="server" CausesValidation="true" BackColor="#FFFFB2"
                                    CssClass="standardmenu">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBoardName" runat="server" Style="color: black" Text="Board Name"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBoardName" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblBasicRNo" runat="server" Style="color: black" Text="Basic Qual. Roll No"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtBasicRNo" runat="server" BackColor="#FFFFB2" CssClass="standardtextbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVBasicRNo" runat="server" ControlToValidate="txtBasicRNo"
                            ErrorMessage="Basic Roll No. should be Numeric.!!" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblYrPass" runat="server" Style="color: black" Text="Year of Passing"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox CssClass="standardtextbox" runat="server" ID="txtYrPass" Width="90px"
                            BackColor="#FFFFB2" />
                        <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox CssClass="standardtextbox" ID="txtDtValidate" Style="display: none"
                            runat="server" Width="80px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtYrPass"
                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtYrPass"
                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                            Type="Date" ControlToValidate="txtYrPass" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtYrPass" Display="Dynamic"
                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                            Type="Date"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblpfeduproof" runat="server" Style="color: black" Text="Qualification"></asp:Label>
                        <span style="color: red">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;" colspan="3">
                        <asp:UpdatePanel ID="Upeducationproof" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddleducationproof" runat="server" CssClass="standardmenu" DataTextField="ParamDesc"
                                    DataValueField="ParamValue" AppendDataBoundItems="True" DataSourceID="dseducationproof"
                                    BackColor="#FFFFB2">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="dseducationproof" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>">
                                </asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" style="width: 20%;">
                    </td>
                    <td class="formcontent" style="width: 501px;">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCasteCat" runat="server" Style="color: black" Text="Category"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="standardmenu" BackColor="#FFFFB2">
                        </asp:DropDownList>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblPrimProf" runat="server" Style="color: black" Text="Primary Profession"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtPrimProf" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div id="divAdvDtl" runat="server">
            <table  class="formtable" style="width: 90%;">
                 <tr>
                    <td class="test" colspan="4" style="text-align: left;">
                        <asp:Label ID="lblAdvDtl" runat="server" Font-Bold="True" Text="Candidate Image Details"></asp:Label>
                    </td>
                 </tr>
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAnPhoto" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblPhotoPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnPhotoUpload" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="AgnPhotoUpload"
                                    OnServerValidate="CustomValidator1_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label6" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="updAgnSign" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblSignPath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="AgnSignUpload" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVSignature" runat="server" ControlToValidate="AgnSignUpload"
                                    OnServerValidate="CVSignature_ServerValidate" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                 </tr>
                 
                 <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label7"  runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                    <td style="height: 20px" class="formcontent" align="left" colspan="3">
                       <table style="width:100%;">
                          <tr>
                             <td class="formcontent" style="width:40%;" align="left"> 
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                   <asp:Label ID="lblPANPath" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="PANUpload" runat="server" Width="99%" EnableViewState="true">
                                   </asp:FileUpload>
                                   <asp:CustomValidator ID="CVPANValidator" runat="server" ControlToValidate="PANUpload"
                                    OnServerValidate="CVPANValidator_ServerValidate" SetFocusOnError="True">
                                   </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                    
                        <td style="width: 15%; height: 20px" class="formcontent" align="left">
                            <asp:UpdatePanel ID="upnllblNocDoc" runat="server" Visible="false">
                            <ContentTemplate>
                                <asp:Label ID="Label8" runat="server"></asp:Label><span
                                    style="color: #ff0000">*</span>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td id="tdNocDoc" runat="server" class="formcontent" style="width:30%;visibility:hidden" align="left"> 
                                <asp:UpdatePanel ID="upnlNocDoc" runat="server" >
                                <ContentTemplate>
                                 <asp:Label ID="lblNoc" runat="server" Visible="false"></asp:Label>
                                   <asp:FileUpload ID="NocDocUpload" runat="server" Width="139%" 
                                        EnableViewState="true">
                                   </asp:FileUpload>
                                    <asp:CustomValidator ID="CVDocUpload" runat="server" ControlToValidate="NocDocUpload"
                                   SetFocusOnError="True" onservervalidate="CVDocUpload_ServerValidate">
                                </asp:CustomValidator>
                               </ContentTemplate>
                               </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                         <td class="formcontent" style="width:25%;" align="left"> </td>
                         <td class="formcontent" style="width:25%;" align="left" >
                               <asp:LinkButton ID="lnkArf" runat="server" Visible = "true"  Text="ARF Form Pg1"
                                 onclick="Click_Arf"   ></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkArfForm" runat="server" Text="ARF Form Pg2" Visible = "true"></asp:LinkButton>
                            </td>
                            <td class="formcontent" style="width:25%;" align="left">
                               <asp:LinkButton ID="lnkeducation" runat="server" Visible = "true" Text="Education Proof" 
                                 onclick="Click_Educationproof"  ></asp:LinkButton>
                            </td>
                            </tr>
                       </table>
                    </td>  
                </tr>
                
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf1" runat="server" ControlToValidate="CndArf1"
                                     SetFocusOnError="True" onservervalidate="CVArf1_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndArf2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblArf2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndArf2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVArf2" runat="server" ControlToValidate="AgnSignUpload"
                                     SetFocusOnError="True" onservervalidate="CVArf2_ServerValidate">
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                   <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label11" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu1" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof1" runat="server" Width="98%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof1" runat="server" ControlToValidate="CndEduProof1"
                                     SetFocusOnError="True" onservervalidate="CVEduProof1_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label12" runat="server" ></asp:Label>
                        <span style="color: #ff0000">*</span>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:UpdatePanel ID="upnlCndEduProof2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEdu2" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="CndEduProof2" runat="server" Width="99%"></asp:FileUpload>
                                <asp:CustomValidator ID="CVEduProof2" runat="server" ControlToValidate="CndEduProof2"
                                     SetFocusOnError="True" onservervalidate="CVEduProof2_ServerValidate" >
                                </asp:CustomValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                 
            </table>
       </div>--%>
        <%--//pranjali--%>
        <%--Added by rachana on 14022014 for Transfer Case Details start--%>
        <%--<table id="tblcol" style="width: 90%" class="formtable" runat="server">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="standardlink" value="-" id="btntransCollapse"
                        style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divtransfer','ctl00_ContentPlaceHolder1_btntransCollapse');" />
                    <asp:Label ID="lblheadtrans" runat="server" Text="Transfer/Composite Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <%--<div runat="server" id="divtransfer" style="display: none;">
            <table id="TblTransfer" runat="server" style="width: 90%" class="formtable">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="false"
                            OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite License">
                        </asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                            AutoPostBack="false" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                    </td>
                </tr>
                <tr id="trTCCase" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="Life License No">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="21">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                            InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black" Text="Old License Exp.Date">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                            TabIndex="22" />
                        <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate"
                            PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtDate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic">
                        </asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate" Display="Dynamic">
                        </asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date">
                        </asp:RangeValidator>
                    </td>
                </tr>
                <tr id="trTCCase1" runat="server">
                    <td align="left" class="formcontent" style="width: 20%;">
                     <span style="color:Red">
                        <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Prev Insurer Name">
                        </asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="txtTccPrevInsurerName" runat="server" CssClass="standardtextbox"
                            BackColor="#FFFFB2" TabIndex="23">
                        </asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                            InvalidChars=",#$@%^!*()&''%^~`1234567890" FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName"
                            FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%;">
                      <span style="color:Red">
                        <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received"></asp:Label>*</span>

                    </td>
                    <td class="formcontent" style="width: 30%;">
                        <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2"
                            AutoPostBack="false" Visible="false" />
                        <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" CssClass="radiobtn"
                                    TabIndex="24" AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Y" Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="1" Text="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trAckRcv" runat="server" style="height: 10%">
                    <td style="width: 20%;" class="formcontent">
                    </td>
                    <td style="width: 30%;" class="formcontent">
                    </td>
                    <td style="width: 20%;" class="formcontent">
                        <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 30%;" class="formcontent">
                        <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                    Visible="false" TabIndex="25">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trNOCAck" runat="server" visible="false">
                    <td class="formcontent" align="left" style="width: 20%;">
                        <asp:Label ID="lblNOCAck" runat="server" Text="NOC/Acknowledgement"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%;">
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkNOCAck" runat="server" BackColor="#FFFFB2"
                            TabIndex="118" />
                    </td>
                    <td class="formcontent" colspan="2">
                    </td>
                </tr>
            </table>
        </div>--%>
        <%--added by pranjali on 13-03-2014 for transfr deatils start--%>
        <table id="trnsfrtitle" class="tableIsys table-condensed" runat="server" style="width: 90%;">
            <tr>
                <td colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <%--<input runat="server" type="button" class="standardlink" value="+" id="btnTransferDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divTrnsferDetails','ctl00_ContentPlaceHolder1_btnTransferDetails');" />--%>
                            <asp:Label ID="lblTransferDtl" Text="Transfer Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                OnCheckedChanged="cbTrfrFlag_CheckedChanged" TabIndex="19" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divTrnsferDetails" runat="server" visible="false" style="display: block;">
                    <table class="tableIsys" style="width: 90%;">
                        <%--<tr>
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="false"
                                                        oncheckedchanged="cbTrfrFlag_CheckedChanged"  TabIndex="19"  />   
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;"></td>
                                                <td class="formcontent" style="width: 30%;"></td>
			                               </tr>--%>
                        <tr id="trTCCase" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="License No"></asp:Label>*</span>
                                <%--  <span style="color: #ff0000">*</span>--%>
                            </td>
                            <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                    TabIndex="21"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                            <span style="color: red">
                                <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="standardtextbox" TabIndex="22" BackColor="#FFFFB2" />
                                <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate"
                                    PopupButtonID="btnoldlicense" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtDate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtDate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                            </td>
                        </tr>
                        <tr id="trTCCase1" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>*</span>
                                <%-- <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--<asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" Visible="false" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlTrnsfrInsurName" runat="server" CssClass="standardmenu"
                                    BackColor="#FFFFB2" Width="270px" TabIndex="65">
                                </asp:DropDownList>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received"></asp:Label>*</span>
                                <%--  <span style="color: #ff0000">*</span>--%>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--// 01...06/09/2012...Miti--%>
                                <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2"
                                    AutoPostBack="false" Visible="false" />
                                <%----%>
                                <asp:UpdatePanel ID="upnlRbtNoc" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" CssClass="radiobtn"
                                            TabIndex="24" AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="0" Text="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="N">No</asp:ListItem>--%>
                                            <%--//added by pranjali on 26-03-2014 start--%>
                                            <asp:ListItem Value="Y" Text="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Text="N">No</asp:ListItem>
                                            <%--//added by pranjali on 26-03-2014 end--%>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <%--// 01...06/09/2012...Miti--%>
                        </tr>
                        <tr id="trAckRcv" runat="server" style="height: 10%">
                            <%--<td style="width:20%;" class="formcontent">
                                                <span style="color: red">
                                                <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" Style="color: black"></asp:Label>*</span>
                                                </td>
                                                <td style="width:30%;" class="formcontent">
                                                <asp:TextBox id="txtCndURNNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                </td>--%>
 <td align="left" class="formcontent" style="width: 20%;">
                            <span style="color:Red">
                                <asp:Label ID="lblissudate" runat="server" Text="License Issue Date" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtissudate" runat="server" CssClass="standardtextbox" TabIndex="22" BackColor="#FFFFB2" />
                                <asp:Image ID="btnissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtissudate"
                                    PopupButtonID="btnissu" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtissudate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR5" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtissudate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtissudate"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                            </td>

                            <td style="width: 20%;" class="formcontent">
                                <asp:UpdatePanel ID="upnllblAckrcv" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblAckrcv" runat="server" Visible="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 30%;" class="formcontent">
                                <asp:UpdatePanel ID="upnlRbAckRev" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                            Visible="false" TabIndex="25">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <%--added by pranjali on 13-03-2014 for transfr deatils end--%>
        <%--added by pranjali on 13-03-2014 for composite deatils start--%>
        <table id="CompositeTitle" runat="server" class="tableIsys table-condensed" style="width: 90%;">
            <tr>
                <td colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <%--<input runat="server" type="button" class="standardlink" value="+" id="btnCompositeDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','ctl00_ContentPlaceHolder1_btnCompositeDetails');" />--%>
                            <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite Case"></asp:Label>&nbsp
                            <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                                AutoPostBack="true" TabIndex="20" OnCheckedChanged="cbTccCompLcn_CheckedChanged" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <%--<td class="test">
                                               <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox"  Enabled="true" TabIndex="21"  />
                                               </td>--%>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div id="divCompositeDetails" runat="server" visible="false" style="display: block;">
                    <table class="tableIsys" style="width: 90%;">
                        <%--<tr>                                            
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite License" ></asp:Label></td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="true" AutoPostBack ="false"
                                                         TabIndex="20" oncheckedchanged="cbTccCompLcn_CheckedChanged" />
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;"></td>
                                                <td class="formcontent" style="width: 30%;"></td>
			                               </tr>--%>
                        <tr id="tr2" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblCompLicNo" runat="server" Style="color: black" Text="License No"></asp:Label>*</span>
                            </td>
                            <%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCompLicNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                    TabIndex="21"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server"
                                    InvalidChars=",#$@%^!*()& ''%^~`" FilterMode="InvalidChars" TargetControlID="txtCompLicNo"
                                    FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                            <span style="color: red">
                                <asp:Label ID="lblComplicnseExpDt" runat="server" Style="color: black"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <asp:TextBox ID="txtCompLicExpDt" runat="server" CssClass="standardtextbox" TabIndex="22" />
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="standardtextbox" Style="display: none"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCompLicExpDt"
                                    PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                    ControlToValidate="txtCompLicExpDt" Enabled="false" ErrorMessage="Mandatory!"
                                    Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:CompareValidator ID="COMPAREVALIDATOR2" runat="server" ErrorMessage="Invalid date!"
                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtCompLicExpDt" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCompLicExpDt"
                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                            </td>
                        </tr>
                        <tr id="tr3" runat="server">
                            <td align="left" class="formcontent" style="width: 20%;">
                                <span style="color: red">
                                    <%--Added by shreela on 6/03/14 to remove space--%>
                                    <asp:Label ID="lblCompInsurerName" runat="server" Style="color: black" Text="Insurer Name"></asp:Label>*</span>
                            </td>
                            <td class="formcontent" style="width: 30%;">
                                <%--<asp:TextBox id="txtCompInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlCompInsurerName" runat="server" CssClass="standardmenu"
                                    BackColor="#FFFFB2" Width="270px" TabIndex="65">
                                </asp:DropDownList>
                                <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtCompInsurerName" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                            <td align="left" class="formcontent" style="width: 20%;">
                            </td>
                            <td class="formcontent" style="width: 30%;">
                            </td>
                        </tr>
                        <%--added by pranjali on 28-03-2014--%>
                        <%--shree--%>
                        <%--shree07--%>
                        <%--<tr id="trrenwl" runat="server" visible="false">
                                                     <td id="Td12" align="left" runat="server" class="formcontent" style="width:20%;">
                                                     <span style="color:Red">
                                                     <asp:Label ID="lblinsrentype" runat="server" style="color:Black"></asp:Label>*</span>
                                                     </td>
                                                     <td id="Td13" runat="server" class="formcontent" >
                                                     <asp:DropDownList ID="ddlinsrentype" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                     Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlinsrentype_SelectedIndexChanged"></asp:DropDownList>
                                                     </td>
                                                     <td id="Td14" runat="server" class="formcontent" style="width:20%;">
                                                     <span style="color:Red">
                                                     <asp:Label ID="lbllyftrngcmpltd" runat="server" style="color:Black"></asp:Label>*</span>
                                                     </td>
                                                     <td id="Td15" runat="server" class="formcontent">
                                                     <asp:DropDownList ID="ddllyftrngcmpltd" runat="server" CssClass="standardmenu"  BackColor="#FFFFB2" 
                                                     Width="210px" Enabled="false" ></asp:DropDownList>
                                                     </td>
                                          </tr>--%>
                        <%--shree--%>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cbTccCompLcn" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <table id="trIsPriorAgt" class="tableIsys" runat="server" style="height: 5%;
            width: 90%;">
            <tr>
                <td align="left" colspan="4" class="test">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox" Enabled="true"
                                TabIndex="21" OnCheckedChanged="chkCompAgnt_CheckedChanged" AutoPostBack="true" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <%--added by pranjali on 28-03-2014--%>
        <%--added by pranjali on 13-03-2014 for composite deatils end--%>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <table id="tblCndURN" runat="server" style="width: 90%;" visible="false">
                    <tr>
                        <td class="test" colspan="4" style="text-align: left;">
                            <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                <ContentTemplate>
                                <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnCndTrnsDtls"
                        style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndTrnsDtls','ctl00_ContentPlaceHolder1_BtnCndTrnsDtls');" />
                                    <asp:Label ID="lbltitleURN" runat="server" Font-Bold="True" Text="Candidate URN No."></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    </table>
                    <div id="divCndTrnsDtls" runat="server" style="display: none;">
                    <table id="tblCndURNDtl" runat="server" style="width: 90%; display:block">
                    <tr>
                        <td align="left" class="formcontent">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <span style="color: red">
                                        <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" Style="color: black"></asp:Label>*</span>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="formcontent" style="width: 30%;">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtCndURNNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                    <asp:Label ID="lblcndURNVal" runat="server" style="color:Black" visible="false"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left" class="formcontent" style="width: 20%;">
                        <asp:Label ID="lblTrnsfrReqNo" Text="IRDA Transfer Request No." runat="server" Style="color: black"></asp:Label>
                        </td>
                        <td  class="formcontent" style="width: 30%;">
                        <asp:TextBox ID="TxtTrnsfrReqNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- added by shreela on 18-04-2014 for Renewal Details start--%>
        <table id="tblRenewalCollapse" style="width: 90%" class="formtable table-condensed"
            runat="server" visible="false">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRenew"
                        style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRenewal','ctl00_ContentPlaceHolder1_btnRenew');" />
                    <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="updrenewal" runat="server">
            <ContentTemplate>
                <div id="divRenewal" runat="server" visible="false" style="display:none">
                    <table id="tblRenewal" style="width: 90%" class="tableIsys" runat="server">
                        <tr>
                            <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCndType" runat="server" Style="color: Black"></asp:Label>
                            </td>
                            <td id="Td1" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblCndVal" runat="server"></asp:Label>
                            </td>
                            <td id="Td2" runat="server" class="formcontent" style="width: 20%;">
                                <asp:Label ID="lblCount" runat="server" Style="color: Black"></asp:Label>
                            </td>
                            <td id="Td3" runat="server" class="formcontent" style="width: 30%;">
                                <asp:Label ID="lblCountVal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="Comp" runat="server" style="display: none;">
                            <td id="Td4" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblRenewType" runat="server" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td id="Td5" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddlRenewType" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                    Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlRenewType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td id="Td6" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lbllyfTraining" runat="server" Style="color: Black"></asp:Label>*</span>
                            </td>
                            <td id="Td7" runat="server" class="formcontent">
                                <asp:DropDownList ID="ddllyfTraining" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                    Width="210px" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--Added by kalyani to fetch Renewal record on QC module start--%>
                        <tr id="trCompQC" runat="server" visible="false">
                            <td id="Td8" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblQCRenewType" runat="server" Style="color: Black"></asp:Label></span>
                            </td>
                            <td id="Td9" runat="server" class="formcontent">
                                <asp:Label ID="lbltxtQCRenewType" runat="server" Style="color: Black"></asp:Label>
                            </td>
                            <td id="Td10" runat="server" class="formcontent" style="width: 20%;">
                                <span style="color: Red">
                                    <asp:Label ID="lblQClyfTraining" runat="server" Style="color: Black"></asp:Label></span>
                            </td>
                            <td id="Td11" runat="server" class="formcontent">
                                <asp:Label ID="lbltxtQClyfTraining" runat="server" Style="color: Black"></asp:Label>
                            </td>
                        </tr>
                        <%--Added by kalyani to fetch Renewal record on QC module end--%>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- added by shreela on 18-04-2014 for Renewal Details end--%>
        <%--added by shreela for old license details start--%>
        <table id="tbloldlic" runat="server" style="width: 90%" class="tableIsys"
            visible="false">
            <%-- <tr>
            <td align="center" colspan="4">
                    <asp:Label ID="Label6" runat="server" Text="NOTE: License will be updated once license details are uploaded from Lic User" ForeColor="red"></asp:Label>
            </td>
        </tr>--%>
            <tr>
                <td id="tdoldlic" class="test" runat="server" colspan="4">
                 <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldLicDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divoldlic','ctl00_ContentPlaceHolder1_BtnOldLicDtls');" />
                    <asp:Label ID="lbloldlic" runat="server" Text="Old License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divoldlic" runat="server" style="display: none" visible="false">
            <table id="tbloldlicdtls" runat="server" class="tableIsys" style="width: 90%">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldlicno" Text="License No" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldlicnoval" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldexpdate" Text="Old LicenseExpDate" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldexpdateval" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%">
                        <asp:Label ID="lbloldlicissu" Text="Old License Issue Date" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lbloldlicissuval" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 20%">
                    </td>
                    <td class="formcontent" style="width: 30%">
                    </td>
                </tr>
            </table>
        </div>
        <%--added by shreela for old license details end--%>
        <%--added by shreela for new license details start--%>
        <table id="tblnewlic" runat="server" style="width: 90%" class="tableIsys"
            visible="false">
            <tr>
                <td id="tdnewlic" class="test" runat="server" colspan="4">
                <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnNewLicDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divnewlic','ctl00_ContentPlaceHolder1_BtnNewLicDtls');" />
                    <asp:Label ID="lblnewlic" runat="server" Text="New License Details" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divnewlic" runat="server" style="display: none" visible="false">
            <table id="tblnewlicdtls" runat="server" class="tableIsys" style="width: 90%">
                <tr>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewlicno" Text="License No" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:Label ID="lblnewlicnoval" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewexpdate" Text="LicenseExpDate" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtnewexpdate"
                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" Enabled="false" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtnewexpdate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewexpdate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtnewexpdate"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                        <%--  <asp:Label ID="Label8" runat="server"></asp:Label>--%>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" style="width: 20%">
                        <asp:Label ID="lblnewlicissu" Text="License Issue Date" runat="server"></asp:Label>
                    </td>
                    <td class="formcontent" style="width: 30%">
                        <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="standardtextbox"></asp:TextBox>
                        <asp:Image ID="btnCalenderissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtnewlicissu"
                            PopupButtonID="btnCalenderissu" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtnewlicissu" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Invalid date!"
                            Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewlicissu" Display="Dynamic"></asp:CompareValidator>&nbsp;
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtnewlicissu"
                            Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                            MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                    </td>
                    <td class="formcontent" style="width: 20%">
                    </td>
                    <td class="formcontent" style="width: 30%">
                    </td>
                </tr>
            </table>
        </div>
        <%--added by shreela for new license details end--%>
        <%--Added by rachana on 14022014 for Transfer Case Details end--%>
        <%--Added by rachana on 13022014 to show inbox cfr details start--%>
        <table id="tblCFRInboxCollapse" style="width: 90%" class="formtable table-condensed"
            runat="server">
            <tr>
                <td colspan="4" align="left" class="test">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnBasicCollapse"
                        style="width: 20px;" onclick="ShowReqDtlNew('ctl00_ContentPlaceHolder1_divCFRInbox','ctl00_ContentPlaceHolder1_btnBasicCollapse');" />
                    <asp:Label ID="lblhead" runat="server" Text="Raised CFR's" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divCFRInbox" runat="server" style="display:block">
            <table id="tblCFRInbox" style="width: 90%" class="tableIsys" runat="server">
                <tr>
                    <td align="left" class="test" colspan="4" style="width: 30">
                        <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="standardlink "></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="standardlink "></asp:Label>&nbsp;
                        <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="standardlink "></asp:Label>
                        <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="standardlink "></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView Style="color: blue" ID="dgDetailsInbox" runat="server" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnRowCommand="dgDetailsInbox_RowCommand"
                            OnPageIndexChanging="dgDetailsInbox_PageIndexChanging" PageSize="5" OnRowDataBound="dgDetailsInbox_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkAssigned" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" CssClass="test"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                                    <ItemTemplate>
                                        <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Responded" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCFRFlagType" runat="server" Text='<%# Eval("CFRFlagType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkReopen" style="text-align:center;" runat="server" Text="ReOpen CFR" CommandArgument='<%# Eval("RemarkId") %>'
                                         CommandName="ReopenCFR" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                            </RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                <td id="Td14" runat="server" align="left" class="test" Visible="false" colspan="4">
                <asp:Label ID="lblTitleRemarks" Visible="false" runat="server" Text="Remarks" Font-Bold="true"></asp:Label>
                </td>
                </tr>
                <tr>
                    <td>
                    <asp:GridView Style="color: blue" ID="GridRemarks" runat="server" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                            HorizontalAlign="Left" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                            OnPageIndexChanging="GridRemarks_PageIndexChanging" PageSize="5">
                            <Columns>
                            <asp:TemplateField SortExpression="Date" HeaderText="Date" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CFRRemark" HeaderText="Remarks" ItemStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="test" />
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>
                                
                                </Columns>
                                <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                            </RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                    </tr>
                <tr id="trRespond" runat="server" visible="false">
                    <td align="center">
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                        <asp:Button ID="btnRespond" runat="server" Text="Respond" CssClass="standardbutton"
                            Width="84px" OnClick="btnRespond_Click" Visible="false"></asp:Button>
                        <%--</div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;">
                            <i class="fa fa-comment"></i>--%>
                        <asp:Button ID="btnCloseCfr" runat="server" Text="Close CFR" CssClass="standardbutton"
                            Width="114px" OnClick="btnCloseCfr_Click"></asp:Button>
                        <%--</div>--%>
                    </td>
                </tr>
            </table>
        </div>
        <%--Added by rachana on 13022014 to show inbox cfr details end--%>
        <table class="tableIsys" id="tblupload" runat="server" style="width: 90%;">
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblNote" runat="server" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                        ForeColor="red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="test" colspan="3" style="text-align: left;">
                    <asp:Label ID="lblCanddoc" runat="server" Text="Candidate Document Upload" Font-Bold="true" Visible="false"></asp:Label>
                    <%--  Candidate Document Upload &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtcolr" runat="server" CssClass="standardtextbox" Visible="false" Width="20px"
                        Height="13px" BackColor="LightPink"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" Text="Mandatory Documents" OnClick="lnkmandtry_click">
                    </asp:LinkButton>&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
            DropShadow="false" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button ID="buttonNull" runat="server" Style="display: none" />
        <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table class="tableIsys" align="center" style="width: 40%;">
                        <tr id="trdgDetails" runat="server">
                            <td class="formcontent" colspan="3" style="height: 40px">
                                <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                    Width="450px" RowStyle-CssClass="tableIsys" AllowSorting="True">
                                    <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandatory Documents">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle Font-Names="verdana" />
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                    <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                                    <HeaderStyle CssClass="portlet blue" Font-Bold="true" ForeColor="White" />
                                    <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%--align="center">--%>
                                <%--<div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="fa fa-times"></i>--%>
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" />
                                <%--</div>--%>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnpopcancel" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <div id="div1" runat="server" style="display: block;">
            <table class="tableIsys" align="center" style="width: 90%;">
                <tr>
                    <td>
                        <%--//pranjali start--%>
                        <asp:UpdatePanel ID="upddgView" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="tableIsys"
                                    PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging"
                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                    OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                <%--<span style="color: #ff0000">*</span>--%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <%--added by pranjali on 03-03-2014 start--%>
                                        <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <%--added by pranjali on 03-03-2014 end--%>
                                        <asp:TemplateField HeaderText="Upload Documents">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btn_Upload" runat="server" CssClass="standardbutton" Text="Upload" Enabled="false" Visible="false" Width="80px"
                                                            OnClick="btn_Upload_Click" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload" Width="80px" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                    <ContentTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload" 
                                            OnClick="btn_ReUpload_Click" />
                                        </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                    </PagerStyle>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <table class="formtable table-condensed" id="Table1" runat="server" style="width: 90%;">
            <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
                <%--pranjali--%>
                <td class="test" colspan="3" style="text-align: left;">
                    <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" visible="false"
                        id="Button11" style="width: 20px;" onclick="funShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles','ctl00_ContentPlaceHolder1_BtnReUpload');" />
                    <%--<asp:Label ID="lblcndupload" runat="server" Font-Bold="True" Text=""></asp:Label>--%>
                    <asp:Label ID="lblcndupload" runat="server" Font-Bold="True"></asp:Label>
                    <%--  Candidate Document Re-Upload--%>
                </td>
            </tr>
        </table>
        <div id="div2" runat="server" style="display: block;">
            <table class="tableIsys" align="center" style="width: 90%;">
                <tr id="tr_reupload" runat="server" visible="false">
                    <td>
                        <%--//pranjali start--%>
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CssClass="tableIsys"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Center"
                            PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                            OnRowDataBound="GridView1_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                            AllowPaging="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="210px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Dt" HeaderStyle-Width="90px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <%--added by pranjali on 03-03-2014 start--%>
                                <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <%--added by pranjali on 03-03-2014 end--%>
                                <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileReUpload" runat="server" Width="340px" Filebytes='<%# Bind("UserFileName") %>'>
                                        </asp:FileUpload>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_ReUpload" runat="server" CssClass="standardbutton" Text="ReUpload"
                                            OnClick="btn_ReUpload_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                            Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoccode1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="sublinkodd"></RowStyle>
                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                            </PagerStyle>
                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <%--pranjali end--%>
        <%--Added by rachana on 29-07-2013 for addition of panel showing documents start--%>
        <div id="divnavigate" runat="server">
            <table id="tblphoto" runat="server" style="width: 90%;">
                <tr>
                    <td class="formcontent" colspan="2">
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCrop" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                        <asp:Button ID="Btncrop" TabIndex="43" runat="server" Text="CROP" CssClass="standardbutton"
                            OnClick="Btncrop_Click" Width="80" Visible="false"></asp:Button>
                        <%--</div>--%>
                        <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCFR" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                        <asp:Button ID="BtnCFR" TabIndex="43" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                            CssClass="standardbutton" Width="80px" Visible="false"></asp:Button><%--</div>--%>
                        <%--OnClientClick="fungetcropimage();"--%>
                    </td>
                    <%--Added by pranjali on 25-022014 for displaying cfr raised start--%>
                    <td align="left" class="style2" colspan="2">
                        <asp:Label ID="lblcfrrais1" runat="server" Text="Raised CFR:" CssClass="standardlink "></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrais1count" runat="server" CssClass="standardlink" Style="color: Red;"></asp:Label><br />
                    </td>
                    <%--</tr>
                <tr>--%>
                    <td align="left" class="formcontent" colspan="2">
                        <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="standardlink" Style="color: Orange;"></asp:Label><br />
                    </td>
                    <%--</tr>
        <tr>--%>
                    <td align="left" class="formcontent" colspan="2">
                        <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                        <asp:Label ID="lblcfrclosed" runat="server" CssClass="standardlink" Style="color: Green;"></asp:Label><br />
                    </td>
                    <%--Added by pranjali on 25-022014 for displaying cfr raised end--%>
                    <td class="formcontent3">
                        <asp:UpdatePanel runat="server" ID="upnlPrev">
                            <ContentTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <%--<div class="btn btn-xs btn-primary" style="width: 110;">
                                    <i class="fa fa-chevron-circle-left"></i>--%>
                                <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" OnClick="btnprev_Click"
                                    Width="80"></asp:Button><%--</div>--%>
                                &nbsp;&nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent">
                        <asp:UpdatePanel runat="server" ID="upnlNext">
                            <ContentTemplate>
                                <%--<div class="btn btn-xs btn-primary" style="width: 110;">
                                    <i class="fa fa-crop"></i>--%>
                                <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" OnClick="btnnext_Click"
                                    Width="80"></asp:Button>
                                <%--<i class="fa fa-chevron-right"></i>
                                </div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <%--Added by rachana on 29-07-2013 for addition of panel showing documents end--%>
        <%--added by shravana 14jun2013--%>
        <%--Added by rachana on 07-08-2013 start--%>
        <%--<asp:Panel ID="Panelphoto1"   runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="2px"  Width="89%" Height="500px" 
           ScrollBars="Vertical" class="modalpopupmesg" HorizontalAlign="Left" style="display:none"> 
          <center>
              <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height:5%;">
                 <tr>
                     <td >
                         <asp:Label ID="Label3" runat="server"   CssClass = "standardlink "/>
                         
                     </td>
                 </tr>
             </table>
          </center>
          <table style="width: 99%; height: 18px">
             <tr class="modalpanelleft">
               <td>
                  <asp:Image ID="Imageall" runat="server"/>
               </td>
            </tr>
         </table>   
      </asp:Panel>--%>
        <asp:Panel ID="Panelphoto2" runat="server" 
            Width="89%" Visible="true" class="card">
            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                    <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                        <tr>
                            <td align="center">
                            <%--    <asp:Label ID="lblpanelheader" runat="server" CssClass="standardlink " />--%>
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table class="modalpanel" style="display: none">
                        <tr>
                            <td>
                                <asp:Image ID="imgCrop" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%----%>
                    <div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">
                        <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;"
                           >
                            <tr>
                                <td>
                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="True" Width="100%" OnPageIndexChanging="GridImage_PageIndexChanging"
                                        OnRowDataBound="GridImage_RowDataBound">
                                        <Columns>
                                            <%--<asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="FPImageCSharp.aspx?ImageID={0}"
                                                HeaderText="Preview Image">
                                                <%--ItemStyle-Height="100%" ItemStyle-Width="100%"--%>
                                                <ItemStyle CssClass="clscenter"/>
                                                 <HeaderStyle CssClass="clscenter" />
                                            </asp:ImageField>
                                        </Columns>
                            <FooterStyle CssClass="GridViewFooter" Width="100%"/>
                            <RowStyle CssClass="GridViewRow" />
                            <HeaderStyle CssClass="gridview" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <iframe id="FrmImg" runat="server" visible="false" width="100%" height="500px"></iframe>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
      </asp:Panel>
            <asp:Label ID="lblpanelheader" runat="server" CssClass="control-label" />
       
        <div id="divButtons" runat="server">
            <table>
                <tbody>
                    <tr></tr>
                    <tr>
                        <td style="height: 20px" align="center" colspan="4">
                           
                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                CssClass="standardbutton" Width="114px" OnClientClick="StartProgressBar();"></asp:Button>
                            
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="standardbutton"
                                Width="80px" Visible="false" OnClientClick="StartProgressBar();"></asp:Button>
                            
                            <asp:Button ID="BtnApprove" OnClick="btnApprove_Click" runat="server" Text="Approve"
                                CssClass="standardbutton" Width="80px" Visible="false" OnClientClick="StartProgressBar();"></asp:Button>
                            
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="standardbutton"
                                Visible="false"  style="width:114px;" OnClick="btnReject_Click" OnClientClick="StartProgressBar();" />
                            <%--<asp:Button ID="btnClear" TabIndex="43" OnClick="btnClear_Click" runat="server" Text="CANCEL"
                                CssClass="btn btn-clear" style="width:114px; margin-top: 10px;"></asp:Button>--%>

                            <asp:LinkButton ID="btnClear" TabIndex="43"  
                                runat="server" 
                                CssClass="btn btn-clear" onclick="btnClear_Click">
                                    <span class="glyphicon glyphicon-remove" style="color:red"> </span> CANCEL
                                      </asp:LinkButton>
                                  <%--  Added by shreela on 14/07/2014 for renewals--%>
                            <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" Width="114px" Text="Cancel" Visible="false" OnClientClick="CloseSub()" />
                              <asp:Button ID="btnCroprefresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnCroprefresh_Click"  /><%--added by shreela on 05/08/2014 fro cropping--%>
                                    <asp:Button ID="btnReOpenReFresh" runat="server" CssClass="standardbutton"   style="display:none;"
                                    ClientIDMode="Static" onclick="btnReOpenReFresh_Click"  />
                            <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnBranchCode" runat="server" />
                        <asp:HiddenField ID="hdnflag" runat="server" />
                        <asp:HiddenField ID="hdnDocCode" runat="server" />
                        <%--//Added by rachana on 02-01-2014 for confirmation of approval--%>
                        <asp:HiddenField ID="hdnDoctype" runat="server" />
                        <asp:HiddenField ID="hdnprevcount" runat="server" />
                        <asp:HiddenField ID="hdnCandTypeRen" runat="server" />
                        <asp:HiddenField ID="hdnInsRenType" runat="server" />
                        <asp:HiddenField ID="hdncompinsren" runat="server" />
                        <%--shree--%>
                        <asp:HiddenField ID="hdnrenwlflag" runat="server" />
                        <%--shree--%>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStartDate" runat="server" />
                        <asp:HiddenField ID="hdnRenwlCnt" runat="server" />
                        <asp:HiddenField ID="hdnRenwl" runat="server" />
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hdnUserId" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnBizSrc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnLoc" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTrnInst" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnPhoto" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnSign" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTccID" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAppNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnCndNo" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnSDate" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnStateCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnbtnVerify" runat="server" />
                        <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                        <asp:HiddenField ID="hdnMobileVerify" runat="server" />
                    </td>
                    <!-- Added by ank 12.01.2011-->
                    <td>
                        <asp:HiddenField ID="hdnWebTkn" runat="server" />
                    </td>
                    <!-- Added by Darshik 01.02.2013-->
                    <td>
                        <asp:HiddenField ID="hdnWebTknCon" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnEntryDate" runat="server" />
                    </td>
                    <asp:UpdatePanel ID="updPnlHidden" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnPan" runat="server" />
                            <asp:HiddenField ID="hdnEmail" runat="server" />
                            <asp:HiddenField ID="hdnMobile" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        <asp:HiddenField ID="hdnCanid" runat="server" />
                        <asp:HiddenField ID="hdnpath" runat="server" />

                       <asp:Button Text="btnok" ID="btnopen" OnClick="btnopen_Click" runat="server" Visible="false"/>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div>
         <table style="width: 90%">
             <tbody>
                    <tr>
                        <td style="height: 20px" align="left" colspan="4">
                            <asp:Label ID="lblNotes" runat="server" Visible="true" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>--%>
              
    </center>
    <%--miti..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="700" display="none">
        <iframe runat="server" id="IframeRaiseCFR" width="700" height="450px" frameborder="0"
            display="none" style="background-color: White;"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        DropShadow="true" TargetControlID="Label1" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...end--%>
    <%-- //Ibrahim--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblpopup" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" Width="81px" OnClientClick="Closewin()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>

<%--added by shreela on 14/07/2014--%>
      <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblSub" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px" OnClientClick="CloseSub()"  />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--added by shreela on 14/07/2014--%>


    <%--added by shreela on 14/07/2014--%>
     <asp:Panel ID="pnlsave" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblsave" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnoksave" runat="server" Text="OK" Width="81px" OnClientClick="funcClear()"  />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSave" runat="server" TargetControlID="lblsave"
        BehaviorID="mdlpopupSave" BackgroundCssClass="modalPopupBg" PopupControlID="pnlsave"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--added by shreela on 14/07/2014--%>
    <asp:Panel ID="PanelPhoto" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="520px" Height="380px">
        <%--340px,350px--%>
        <center>
            <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                <tr>
                    <td>
                        <asp:Label ID="lblAdvisor" runat="server" Text="" CssClass="standardlink " />
                    </td>
                </tr>
            </table>
        </center>
        <table>
            <asp:Image ID="Image_Photo" runat="server" Width="520px" Height="340px" />
            <%--330,287--%>
        </table>
        <%-- added by shravana--%>
        <table width="100%">
            <tr align="center">
                <td bgcolor="gray" colspan="1" style="height: 32px" width="100%">
                    <asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn-xs default" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup_photo" runat="server" TargetControlID="Image_Photo"
        BehaviorID="mdlpopup_photo" BackgroundCssClass="modalPopupBg" PopupControlID="PanelPhoto"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--//End Ibrahim--%>
    <asp:ListBox ID="LstImagepath" runat="server" Style="display: none"></asp:ListBox>
    <asp:ListBox ID="Listlabel" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 1-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListDoccode" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 29-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListID" runat="server" Style="display: none"></asp:ListBox>
    <%--panel for cnd view--%>
    <asp:Panel runat="server" ID="pnlMdlCnd" Width="760px" display="none">
        <iframe runat="server" id="Iframe1Cnd" width="790px" height="600px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1Cnd" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewCnd" BehaviorID="mdlViewBIDCnd"
        DropShadow="true" TargetControlID="lbl1Cnd" PopupControlID="pnlMdlCnd" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMdlRen" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="180px" Visible="false">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblRen" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="Button2" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn-xs default" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewRen" BehaviorID="mdlViewBIDRen"
        DropShadow="true" TargetControlID="lblRen" PopupControlID="pnlMdlRen" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMdl1" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="230px" Visible="false">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblcfrrespnd" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnCFROk" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn-xs default" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlCFRRespond" BehaviorID="mdlViewBIDRespnd"
        DropShadow="true" TargetControlID="lblcfrrespnd" PopupControlID="pnlMdl1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="PnlExm" Width="450" Height="320" display="none">
        <iframe runat="server" id="IframeExm" scrolling="no" width="100%" frameborder="0"
            display="none" style="height: 100%; background-color: White;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label6" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDExm"
        DropShadow="true" TargetControlID="Label6" PopupControlID="PnlExm" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    <%--Shreela  for Crop...Start--%>
     <asp:Panel runat="server" ID="PnlRaiseCrop" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseCrop" frameborder="0" display="none" style="width:1000px;
            height:500px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblCrop" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCrop" BehaviorID="MdlPopRaiseCrop" DropShadow="true"
       TargetControlID="lblCrop" PopupControlID="PnlRaiseCrop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
  <%--Shreela  for Crop...End--%>
  <%--ReOpen  CFR...START--%>
       <asp:Panel runat="server" ID="PnlReOpenCFR" Width="600px" display="none">
        <iframe runat="server" id="IframeReOpenCFR" frameborder="0" display="none" style="width:600px;
            height:300px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblReOpenCFR" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopReOpenCFR" BehaviorID="MdlPopReOpenCFR" DropShadow="true"
       TargetControlID="lblReOpenCFR" PopupControlID="PnlReOpenCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--ReOpen  CFR...END--%>
  <%--Loader popup start--%>
  <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="hiddenField1" runat="server" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">
                    
                    <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
                </asp:Panel>
  <%--Loader popup end--%>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        var imgno = 1;

        function Validation() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////
            var StateCode = (document.getElementById("<%=hdnStateCode.ClientID %>").value);

            if (StateCode == "ME" || StateCode == "SI") {
            }
            else {
                if (document.getElementById("<%=txtPAN.ClientID%>").value == "") {
                    alert("Please Enter PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById("<%=txtPAN.ClientID%>").value != "") {
                if (CheckPANFormat(document.getElementById("<%=txtPAN.ClientID%>").value) == 0) {
                    alert("Please Enter Valid PAN No");
                    document.getElementById("<%=txtPAN.ClientID%>").focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }

            }


            //Validate Transfer Case
            debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                        alert("Candidate URN No. is Mandatory.");
                        document.getElementById(strContent + "txtCndURNNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    if (document.getElementById(strContent + "txtCompLicExpDt").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Composite is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtCompLicExpDt").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    //			        
                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                }
            }

            //added by pranjali on 13-03-2014 for composite end
            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Exam Mode is Mandatory.");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                    alert("Exam Body is Mandatory.");
                    document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Exam language is Mandatory.");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "--Select--") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Exam Centre is Mandatory.");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end

            //added by pranjali on 28-04-2014 start
            if (document.getElementById('<%=ddlNExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExam.ClientID %>').value == "")) {
                    alert("Exam Mode is Mandatory.");
                    document.getElementById('<%= ddlNExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlNExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExmBody.ClientID %>').value == "")) {
                    alert("Exam Body is Mandatory.");
                    document.getElementById('<%= ddlNExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlNpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNpreeamlng.ClientID %>').value == "")) {
                    alert("Exam language is Mandatory.");
                    document.getElementById('<%= ddlNpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=txtNExmCenter.ClientID %>') != null) {
                if ((document.getElementById('<%=txtNExmCenter.ClientID %>').value == "--Select--") || (document.getElementById('<%=txtNExmCenter.ClientID %>').value == "")) {
                    alert("Exam Centre is Mandatory.");
                    document.getElementById('<%= txtNExmCenter.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlNExmCenter.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlNExmCenter.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlNExmCenter.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 28-04-2014 end







            //Added by rachana for fees validation




            //shree07
            //                //added by shreela on18042014 for renewals validation
            //                if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "C") {
            //                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
            //                        alert("Insurer Type is Mandatory.");
            //                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
            //                        return false;
            //                    }
            //                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
            //                        if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
            //                            alert("Life Training Completed is Mandatory.");
            //                            document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
            //                            return false;
            //                        }
            //                    } //shree
            //                }

        }


        //added by pranjali on 04-03-2014 start
        function funvalidateApprove() {

            var strContent = "ctl00_ContentPlaceHolder1_";
            debugger;


            //added by pranjali on 11-04-2014 start
            if (document.getElementById('<%=ddlExam.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExam.ClientID %>').value == "")) {
                    alert("Exam Mode is Mandatory.");
                    document.getElementById('<%= ddlExam.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlExmBody.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlExmBody.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmBody.ClientID %>').value == "")) {
                    alert("Exam Body is Mandatory.");
                    document.getElementById('<%= ddlExmBody.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }
            if (document.getElementById('<%=ddlpreeamlng.ClientID %>') != null) {
                if ((document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlpreeamlng.ClientID %>').value == "")) {
                    alert("Exam language is Mandatory.");
                    document.getElementById('<%= ddlpreeamlng.ClientID %>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            if (document.getElementById('<%=txtExmCentre.ClientID %>') != null) {
                if ((document.getElementById('<%=txtExmCentre.ClientID%>').value == "--Select--") || (document.getElementById('<%=txtExmCentre.ClientID%>').value == "")) {
                    alert("Exam Centre is Mandatory.");
                    document.getElementById('<%=txtExmCentre.ClientID%>').focus();
                    var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                    return false;
                }
            }

            //            if (document.getElementById('<%=ddlExmCentre.ClientID %>') != null) {
            //                if ((document.getElementById('<%=ddlExmCentre.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlExmCentre.ClientID %>').value == "")) {
            //                    alert("Exam Centre is Mandatory.");
            //                    document.getElementById('<%= ddlExmCentre.ClientID %>').focus();
            //                    return false;
            //                }
            //            }

            //added by pranjali on 11-04-2014 end
            if (document.getElementById("ctl00_ContentPlaceHolder1_cbTrfrFlag") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked != true) {
                    //debugger;
                    if (document.getElementById('<%=ddlTrnMode.ClientID %>') != null) {
                        if ((document.getElementById('<%= ddlTrnMode.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "")) {
                            alert("Please Select Training Mode");
                            document.getElementById('<%= ddlTrnMode.ClientID  %>').focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById('<%=ddlTrnLoc.ClientID %>') != null) {
                        if ((document.getElementById("<%=ddlTrnLoc.ClientID%>").value == "--Select--") || (document.getElementById('<%=ddlTrnLoc.ClientID %>').value == "")) {
                            alert("Please Enter the Training Location");
                            document.getElementById("<%=ddlTrnLoc.ClientID%>").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                    if (document.getElementById('<%=ddlTrnInstitute.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnInstitute.ClientID %>').value == "")) {
                            alert("Please Select Training Institute");
                            document.getElementById("<%=ddlTrnInstitute.ClientID%>").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById('<%=ddlHrsTrn.ClientID %>') != null) {
                        if ((document.getElementById('<%= ddlHrsTrn.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlHrsTrn.ClientID %>').value == "")) {
                            alert("Please Select Training Hrs");
                            document.getElementById('<%= ddlHrsTrn.ClientID  %>').focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }
                }
            }

            //shree
            if (document.getElementById("<%=hdnrenwlflag.ClientID %>").value == "Y") {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById('<%=txtCompLicNo.ClientID %>').Value == "") {
                        alert("Please Enter Life LicenseNo.");
                        document.getElementById("<%=txtCompLicNo.ClientID %>").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=txtCompLicExpDt.ClientID %>').Value == "") {
                        alert("Please Enter License Exp.Date");
                        document.getElementById("<%=txtCompLicExpDt.ClientID %>").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById('<%=ddlCompInsurerName.ClientID %>') != null) {
                        if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                            alert("Please Select Insurer Name");
                            document.getElementById("<%=ddlCompInsurerName.ClientID%>").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }


                }
                //shree07
                //added by shreela on18042014 for renewals validation
                if (document.getElementById('<%=hdnCandTypeRen.ClientID %>').value == "Composite") {
                    if ((document.getElementById('<%=ddlRenewType.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddlRenewType.ClientID %>').value == "")) {
                        alert("Insurer Type is Mandatory.");
                        document.getElementById('<%= ddlRenewType.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    if (document.getElementById('<%=hdnInsRenType.ClientID %>').value == "L") {
                        if (document.getElementById('<%=ddllyfTraining.ClientID %>') != null) {
                            if ((document.getElementById('<%=ddllyfTraining.ClientID %>').value == "---Select---") || (document.getElementById('<%=ddllyfTraining.ClientID %>').value == "")) {
                                alert("Life Training Completed is Mandatory.");
                                document.getElementById('<%= ddllyfTraining.ClientID %>').focus();
                                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                                return false;
                            }
                        } //shree
                    }
                }
            }
            //shree
            //Validate Transfer Case
            debugger;
            if (document.getElementById("<%=cbTrfrFlag.ClientID %>") != null) {
                if (document.getElementById("<%=cbTrfrFlag.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtOldTccLcnNo").value != null) {
                        if (document.getElementById(strContent + "txtOldTccLcnNo").value == "") {
                            alert("License Number for Transfer is Mandatory");
                            document.getElementById(strContent + "txtOldTccLcnNo").focus();
                            var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                            return false;
                        }
                    }

                    if (document.getElementById(strContent + "txtDate").value == "")//txtOldTccLcnExpDate_txtDate
                    {
                        alert("License Expiry Date for Transfer is Mandatory");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtDate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlTrnsfrInsurName.ClientID %>').value == "")) {
                        alert("Insurer Name for Transfer is Mandatory.");
                        document.getElementById('<%= ddlTrnsfrInsurName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                    if (document.getElementById(strContent + "txtCndURNNo").value == "") {
                        alert("Candidate URN No. is Mandatory.");
                        document.getElementById(strContent + "txtCndURNNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }

                    if (document.getElementById(strContent + "txtissudate").value == "") {
                        alert("License Issue Date for Transfer is Mandatory.");
                        document.getElementById(strContent + "txtissudate").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                }
            }

            //added by pranjali on 13-03-2014 for composite start
            debugger;
            if (document.getElementById("<%=cbTccCompLcn.ClientID %>") != null) {
                if (document.getElementById("<%=cbTccCompLcn.ClientID %>").checked == true) {
                    if (document.getElementById(strContent + "txtCompLicNo").value == "") {
                        alert("License Number for Composite is Mandatory");
                        document.getElementById(strContent + "txtCompLicNo").focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }


                    //added by pranjali on 13-03-2014 start
                    if ((document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "--Select--") || (document.getElementById('<%=ddlCompInsurerName.ClientID %>').value == "")) {
                        alert("Insurer Name for Composite is Mandatory.");
                        document.getElementById('<%= ddlCompInsurerName.ClientID %>').focus();
                        var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                        return false;
                    }
                    //added by pranjali on 13-03-2014 end
                }
            }

            //added by pranjali on 13-03-2014 for composite end

        }
        //added by pranjali on 04-03-2014 end
        function ValidationPAN() {

            var varPAN = document.getElementById('<%= txtPAN.ClientID %>').value;
            document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
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

            document.getElementById('divPAN').style.display = 'block'

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
                                if (pan2.substring(j, j + 1) != 'P')
                                    return 0;
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

        function funOpenPopWinExmCentre(strPageName, strExmCentreName, strtxtExmCentreName, strhdnExmCCode) {
            if (document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") {
                alert("Please Select Exam Mode");
                return false;
            }
            else {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                    alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                    alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                }
                showPopWin(strPageName + "?txtExmCentreName=" + document.getElementById(strExmCentreName).value +
            "&strtxtExmCentreName=" + strtxtExmCentreName +
            "&strhdnExmCCode=" + strhdnExmCCode + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value + "&SalesUnitCode=" + "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value + "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value, 750, 350, null);

            }
        }


        function funOpenPopWinTrnInstitute(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnInst&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value, 750, 350, null);
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }

        function funcopencrop1() {
            debugger;
            $find("MdlPopRaiseCrop").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCrop").src = "../../../Application/ISys/Recruit/CropImage.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerText + "&mdlpopup=MdlPopRaiseCrop";

        } //added by shreela on 08/05/2014 for croping

        function FuncReOpen(lblRemarkidValue) {
            debugger;
            //$find("MdlPopReOpenCFR").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReOpenCFR").src = "../../../Application/ISys/Recruit/PopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&mdlpopup=MdlPopReOpenCFR";
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "RaiseCFR") {
                debugger;
                if (document.getElementById('<%=TxtTrnsfrReqNo.ClientID %>') != null) {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&TransfrReqNo=" + document.getElementById('<%=TxtTrnsfrReqNo.ClientID%>').value + "&FlagCode=Trnsfr" + "&mdlpopup=MdlPopRaiseCFR";
                }
                else {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&FlagCode=Others" + "&mdlpopup=MdlPopRaiseCFR";
                }
            }
            if (strPopUpType == "ExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtExmCentre.ClientID%>').value + "&field1=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }

            if (strPopUpType == "NExmCentre") {
                debugger;
                $find("mdlViewBIDExm").show();
                document.getElementById("ctl00_ContentPlaceHolder1_IframeExm").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?ExmCentre=" +
                 document.getElementById('<%=txtNExmCenter.ClientID%>').value + "&field1=" + document.getElementById('<%=txtNExmCenter.ClientID %>').id +
                 "&field2=" + document.getElementById('<%=hdnNExmCenter.ClientID %>').id +
                 "&mdlpopup=mdlViewBIDExm";
            }
            if (strPopUpType == "ExamCentre") {
                if (document.getElementById('<%=ddlExam.ClientID %>').value == "--Select--") {
                    alert("Please Select Exam Mode");
                    return false;
                }
                else {
                    if (document.getElementById('<%=ddlExam.ClientID %>').value == "1") {
                        alert("To Select Exam Center within 85 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    else if (document.getElementById('<%=ddlExam.ClientID %>').value == "2") {
                        alert("To Select Exam Center within 100 KM,Check on IRDA Site: www.irdaonline.org by providing only Agent address Pin Code");
                    }
                    $find("mdlViewBID").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/Recruit/PopExmCentre.aspx?txtExmCentreName=" +
                    document.getElementById('<%=txtExmCentre.ClientID %>').value + "&strtxtExmCentreName=" + document.getElementById('<%=txtExmCentre.ClientID %>').id +
                    "&strhdnExmCCode=" + document.getElementById('<%=hdnExmCentreCode.ClientID %>').id + "&ExmMode=" + document.getElementById('<%=ddlExam.ClientID %>').value +
                     "&BizSrc=" + document.getElementById('<%=hdnBizSrc.ClientID %>').value +
                    "&ExmBody=" + document.getElementById('<%=ddlExmBody.ClientID %>').value + "&mdlpopup=mdlViewBID";

                }
            }
        }

        function funOpenPopWinTrnLocation(strPageName, strTrnInstitute, strtxtTrnInstitute, strhdnTrnInstitute) {
            if (document.getElementById('<%=ddlTrnMode.ClientID %>').value == "--Select--") {
                alert("Please Select Training Mode");
                return false;
            }
            else {
                showPopWin(strPageName + "?txtTrnInstName=" + document.getElementById(strTrnInstitute).value +
            "&strtxtTrnInstitute=" + strtxtTrnInstitute +
            "&strhdnTrnInstitute=" + strhdnTrnInstitute + "&Page=TrnLoc&TrnMode=" + document.getElementById('<%=ddlTrnMode.ClientID%>').value + "&TrnInst=" + document.getElementById('<%=hdnTrnInstitute.ClientID%>').value, 750, 350, null);
            }
        }
        function PopWaiver(CscCode) {

            showPopWin("../../../Application/Common/PopWaiverAdvisor.aspx?Code=" + CscCode
                    , 500, 100, null);
        }


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
        function ShowReqDtlNew(divId, btnId) {
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
        //        function funShowReqDtl(divId, btnId) {

        //            if (document.getElementById(divId).style.display == "block") {
        //                document.getElementById(divId).style.display = "none";
        //                //document.getElementById(divId).value = '+'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '+';
        //            }
        //            else {
        //                document.getElementById(divId).style.display = "block";
        //                //document.getElementById(btnId).value = '-'
        //                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpload").value = '-';
        //            }
        //        }

        //        function funChkOpnCfr(count) {


        //            if (count > 0) {
        //                var confirmed = confirm('CFR is still open. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else if (count == 0) {
        //                var confirmed = confirm('CFR not raised yet/CFR closed. Do you want to approve?');
        //                if (confirmed == true) {

        //                    document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 1;
        //                    return true;
        //                }
        //            }
        //            else {

        //                document.getElementById("ctl00_ContentPlaceHolder1_hdnflag").value = 0;
        //                return true;
        //            }
        //        }
        //}

        //Added by rachana on 02-01-2014 for confirmation of approval end
        function Closewin() {

            window.close();
        }

        function RecursiveEnabled(control) {
            var children = control.childNodes;
            try { control.removeAttribute('disabled') }
            catch (ex) { }
            for (var j = 0; j < children.length; j++) {
                RecursiveEnabled(children[j]);
            }
        }

        //Added for transfer case end
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        //added by shreela on 12/03/14 for validation on mobile no and email start
        function form2() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            // debugger;
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
                return false;
            }
            else {
                //                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                //                if ((Mobile.substr(0, 1)) != "0") {
                //                    alert("Mobile Number should start with 0");
                //                    document.getElementById(strContent + "txtMobileNo").focus();
                //                    return false;
                //                }
                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileNo").focus();
                    return false;
                }

            }
            return true;
        }

        function validateEmail1() {

            //debugger;
            var Email = (document.getElementById('<%= txtEMail.ClientID %>').value);
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEMail").focus();
                return false;
            }

            return true;

        }
        //added by shreela on 12/03/14 for validation on mobile no and email end


        //Added by shreela on 8/04/2014 for Renewal start
        function validateRenewal() {
            debugger;
            if (document.getElementById('<%=ddlRenewType.ClientID%>').value == "---Select---") {
                alert("Insurer Type is Mandatory");
                document.getElementById('<%=ddlRenewType.ClientID%>').focus();
                return true;
            }
            else if (document.getElementById('<%=ddllyfTraining.ClientID%>').value == "---Select---") {
                alert("Please select Life Training");
                document.getElementById('<%=ddllyfTraining.ClientID%>').focus();
                return true;
            }
        }
        function ShowReqDtlRenew(divId, btnId) {
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
        function AlertMsgs(msgs) {
            alert(msgs);
        }

        //Added by shreela on 8/04/2014 for Renewal end

        //changing color of fees at 2nd Qc
        function btnClick() {
            debugger;
            var x = document.getElementById("tbltest").getElementsByTagName("FeesRow");
            // var y = document.getElementById("tblICMDtls").getElementsByTagName("trTokenwithFees");
            x.style.backgroundColor = "yellow";
            //y.style.backgroundColor = "red";
        }

        //Added by rachana for showinfg loader image on approve,save,submit, reject button start
        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();

            return true;
        }

        //Added by rachana for showinfg loader image on approve,save,submit, reject button end
    </script>
</asp:Content>

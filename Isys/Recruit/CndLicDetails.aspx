<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CndLicDetails.aspx.cs" Inherits="Application_INSC_Recruit_CndLicDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
 <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
 <script language="javascript" type="text/javascript">
     var path = "<%=Request.ApplicationPath.ToString()%>";
     var ChangeFlag = "0";
     var dtYDOB = "0";

     function funpan() {
         debugger;
         var strContent = "ctl00_ContentPlaceHolder1_";
         document.getElementById(strContent + "ddlCasteCat").focus();
     }
     function funrecruitercode() {
         debugger;
         var strContent = "ctl00_ContentPlaceHolder1_";
         document.getElementById(strContent + "ddlCnctType").focus();
     }

     function ShowReqDtl(divId, btnId) {
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

     function funValidate() {
         var strContent = "ctl00_ContentPlaceHolder1_";

         if (document.getElementById(strContent + "txtOldTccLcnNo") != null) {
             if (isEmpty(document.getElementById(strContent + "txtOldTccLcnNo").value)) {
                 alert("Please Enter License Number");
                 document.getElementById(strContent + "txtOldTccLcnNo").focus();
                 return false;
             }
         }

         if (document.getElementById(strContent + "txtDate") != null) {
             if (isEmpty(document.getElementById(strContent + "txtDate").value)) {
                 alert("Please Enter License Expiry Date");
                 document.getElementById(strContent + "txtDate").focus();
                 return false;
             }
         }
     }
 </script>


<asp:ScriptManager id="SM1" runat="server">
        <scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" /> 
        </scripts>
        <services>
            <asp:ServiceReference  Path="../../../Application/Common/Lookup.asmx" />
        </services> 
    </asp:ScriptManager>

<center>
    <table style="width: 80%;  border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblError2" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="formtable" style="width: 100%;">
                    <tr>
                    <td colspan="4" class="test">
                        <input runat="server" type="button" class="standardlink" value="-" id="btnPersonal" style="width: 20px;"
                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divPersonal','ctl00_ContentPlaceHolder1_btnPersonal');" />
                        <asp:Label ID="lblpfPersonal" runat="server" Font-Bold="true" Width="700px"  ></asp:Label>
                                                
                    </td>
                </tr>
            </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divPersonal" runat="server" style="display: block;">
                                        <table class="formtable" style="width: 100%;">
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfcndid" runat="server" Style="color: black"  ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:TextBox id="txtcndid" runat="server" CssClass="standardtextbox" MaxLength="20" 
                                                        ReadOnly="True" TabIndex="1" Enabled="False"></asp:TextBox> 
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblcategory" runat="server" Style="color: black" ></asp:Label>
                                                </td> 
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="UpdPanelCategory" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="ddlcategory" runat="server" CssClass="standardmenu" AutoPostBack="true" 
                                                                OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged"
                                                                Width="187px" TabIndex="2" Enabled="False"></asp:DropDownList>
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                     <asp:Label ID="lblpfappno" runat="server" Style="color: black" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                      <asp:TextBox id="txtapplicationno" runat="server" CssClass="standardtextbox" 
                                                          TabIndex="3" Enabled="False"></asp:TextBox> 
                                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                                            FilterMode="InvalidChars" TargetControlID="txtapplicationno" FilterType="Custom">
                                                      </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                    <asp:Label ID="lblpfregdate" runat="server" Style="color: black"></asp:Label></span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtregdate" runat="server" CssClass="standardtextbox" 
                                                        Enabled="False" MaxLength="20" ReadOnly="True" TabIndex="4"></asp:TextBox>
                                                 </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <span style="color: red">
                                                    <asp:Label ID="lblpfgivenName" runat="server" Style="color: black"></asp:Label></span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:UpdatePanel ID="UpdPanelAgtType" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="cboTitle"  runat="server" CssClass="standardmenu" 
                                                                DataTextField="ParamDesc" DataValueField="ParamValue" 
                                                                AppendDataBoundItems="True" DataSourceID="dscbotitle"  
                                                                Width="50px" TabIndex="5" Enabled="False"></asp:DropDownList> 
                                                            <asp:TextBox id="txtGivenName" runat="server" CssClass="standardtextbox" 
                                                                onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="30" 
                                                                Width="130px" TabIndex="6" Enabled="False"></asp:TextBox> 
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                               FilterMode="InvalidChars" TargetControlID="txtGivenName" FilterType="Custom">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:SqlDataSource ID="dscbotitle" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                                            <asp:HiddenField id="hdnGenderTitle1" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField id="hdnGenderTitle2" runat="server"></asp:HiddenField> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <span><font color="red">
                                                    <asp:Label ID="lblpfSurName" runat="server" Style="color: black" ></asp:Label></font></span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox id="txtname"  runat="server" CssClass="standardtextbox" 
                                                        onChange="javascript:this.value=this.value.toUpperCase();" 
                                                        MaxLength="30" TabIndex="7" Enabled="False"></asp:TextBox>&nbsp;
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtname" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpffathername" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">                           
                                                    <asp:TextBox id="txtFathername"  runat="server" CssClass="standardtextbox" 
                                                        onChange="javascript:this.value=this.value.toUpperCase();"  MaxLength="60" 
                                                        TabIndex="8" Enabled="False" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtFathername" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfGender" runat="server" Text="Gender" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:DropDownList id="cboGender" runat="server" CssClass="standardmenu" 
                                                       Width="187px" TabIndex="9" Enabled="False"></asp:DropDownList> 
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <span><font color="red">
                                                    <asp:Label ID="lblpfdob" runat="server" Style="color: black" ></asp:Label></font>&nbsp;</span></td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtDOB"  runat="server" CssClass="standardtextbox"
                                                        TabIndex="10" Enabled="False" />
                                                    <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <asp:TextBox ID="txtDtValidate" runat="server" CssClass="standardtextbox" Style="display: none"
                                                            Width="80px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDOB"
                                                            PopupButtonID="btnCalendar" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RFV" runat="server" SetFocusOnError="true" ControlToValidate="txtDOB"
                                                            Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <asp:CompareValidator ID="CV" runat="server" ErrorMessage="Invalid date!" Operator="DataTypeCheck"
                                                            Type="Date" ControlToValidate="txtDOB" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                    <asp:RangeValidator ID="RGV" runat="server" ControlToValidate="txtDOB" Display="Dynamic"
                                                            ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                            Type="Date"></asp:RangeValidator>
                                               </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfpob" Visible="false" runat="server" Font-Bold="False"  ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox CssClass="standardtextbox" ID="txtplaceofbirthpersonal" 
                                                        runat="server" visible="false"  MaxLength="30" TabIndex="11" Enabled="False"></asp:TextBox>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfmaritalstatus" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="cboMaritalStatus" runat="server" CssClass="standardmenu" 
                                                                AutoPostBack="true" Width="187px" TabIndex="12" Enabled="False" ></asp:DropDownList>
                                                        </contenttemplate> 
                                                    </asp:UpdatePanel> 
                                                    <%--<uc4:ddlLookup runat="server" ID="cboMaritalStatus" CssClass="standardmenu" BackColor="#FFFFB2" 
                                                        RequiredField="false" LookupCode="MarrySts" ValidationError="Mandatory!" 
                                                        TabIndex="55"></uc4:ddlLookup>--%>
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfNationality" runat="server" ></asp:Label>

                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox ID="txtNationalCode" runat="server" CssClass="standardtextbox" 
                                                        onChange="javascript:this.value=this.value.toUpperCase();" Width="42px" 
                                                        MaxLength="3" TabIndex="13" Enabled="False"></asp:TextBox>
                                                    <asp:TextBox ID="txtNationalDesc" runat="server" CssClass="standardtextbox" 
                                                         onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="14"  
                                                        Enabled="False" Width="133px" ></asp:TextBox>
                                                    <asp:Button ID="btnNational"  runat="server" CssClass="btn btn-xs btn-primary" 
                                                        Enabled="False" CausesValidation="False" Text="..."  TabIndex="15"/>&nbsp;
                                                </td>
                                           </tr>
                                           <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Label ID="lblpfpan" runat="server" Font-Bold="False"  ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
						                             <asp:UpdatePanel ID="UpdPnlPAN" runat="server">
                                                          <ContentTemplate>
                                                               <asp:TextBox id="txtCurrentID" runat="server" CssClass="standardtextbox" MaxLength="24"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();"  TabIndex="16" 
                                                                   Enabled="False"></asp:TextBox>
                                                               <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                                                     FilterMode="InvalidChars" TargetControlID="txtCurrentID" FilterType="Custom">
                                                               </ajaxToolkit:FilteredTextBoxExtender>
						                                       <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="btn btn-xs btn-primary"
                                                                     OnClick="btnVerifyPAN_Click" OnClientClick="funpan();" 
                                                                   ValidationGroup="RecruitInfo" Width="40px" TabIndex="17" Enabled="False"></asp:Button>
                                                               <div id="divPAN" class="Content" style="display: none" >
                                                               <img src="../../../App_Themes/Isys/images/spinner.gif"  alt="Loading..."  />  
                                                               <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                                               </div>
                                                    
                                                               <%--<asp:Label ID="lblPANMsg" runat="server" Style="color: #ff0000" Font-Bold="False"
                                                                     Font-Size="X-Small"></asp:Label>&nbsp;--%>
                                                               <%--<a href="https://incometaxindiaefiling.gov.in/e-Filing/Services/KnowYourJurisdiction.html;jsessionid=Fl7hSy1QFps1MQr5XqXhX51h7rJp7Jyd1HLJnMxthzG1HLRhgPFl!905747125" target="_blank">Pan Verification</a>--%>
					                                       </ContentTemplate> 
                                                       </asp:UpdatePanel> 
                                                </td>
                                                <td class="formcontent" style="width: 20%;"> 
                                                  <%--  Miti--%>
                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                         <ContentTemplate>
                                                             <asp:Label ID="LblpanName" runat="server"  Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                         </ContentTemplate> 
                                                     </asp:UpdatePanel> <%--  Miti--%>
                                                    <%-- <asp:Label ID="Labeluid" runat="server" Font-Bold="False" Text="UserId"></asp:Label>--%>
                                                </td>
                                                <td class="formcontent">
                                                   <%-- <asp:TextBox ID="txtuid" runat="server" CssClass="standardtextbox" Width="150px" MaxLength="18" TabIndex="18" ></asp:TextBox>--%>
                                                </td>
                                           </tr>
                                           <%--  Commented by kalyani on 20-12-2013 as Commission payment mode is not a required field start--%>
                                               <%-- <tr>
                                                        <td class="formcontent">
                                                           <asp:Label ID="lblpfcompaymode" runat="server"  ></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;" colspan="3">
                                                            <asp:DropDownList  ID="ddlPaymentMode" runat="server" CssClass="standardmenu" TabIndex="75"/>
                                                        </td>
                                                     </tr>--%>
                                           <%--  Commented by kalyani on 20-12-2013 as Commission payment mode is not a required field end--%>
                                          <%-- <tr>
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case" ></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox"  
                                                        AutoPostBack ="false"
                                                        oncheckedchanged="cbTrfrFlag_CheckedChanged"  TabIndex="19"  />   
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite License" ></asp:Label></td>
                                                <td class="formcontent" style="width: 30%;">
                                                     <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox"  Enabled="true" AutoPostBack ="false"
                                                         TabIndex="20" oncheckedchanged="cbTccCompLcn_CheckedChanged" />
                                                </td>
			                               </tr>--%>
                                           </table>
                                    </div>
                                    <table class="formtable" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <table class="formtable" style="width: 100%;">
                                                <tr>
                                                    <td colspan="4" class="test">
                                                        <input runat="server" type="button" class="standardlink" value="-" id="btnLicense" style="width: 20px;"
                                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLicense','ctl00_ContentPlaceHolder1_btnLicense');" />
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Width="150px" Text="License Details" ></asp:Label>
                                                
                                                    </td>
                                                </tr>
                                            </table>
                                         </td>
                                    </tr>
                                    </table>
                                    <div id="divLicense" runat="server" style="display: block;">
                                    <table class="formtable" style="width: 100%;">
			                               <tr id="trTCCase"  runat="server"  >
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lbloldLcnNo" runat="server" Style="color: black" Text="License No." ></asp:Label><span style="color: #ff0000">*</span>
                                                </td><%--text Old License No.Changed to Life License No. by kalyani on 20-12-2013--%>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox id="txtOldTccLcnNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="21" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                                          FilterMode="InvalidChars" TargetControlID="txtOldTccLcnNo" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="rfvlcnno" runat="server" SetFocusOnError="true"  ControlToValidate="txtOldTccLcnNo"  Enabled="true"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblOldLcnexpDate" runat="server" Style="color: black" Text="License Exp.Date" ></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                   <asp:TextBox  ID="txtDate" runat="server" CssClass="standardtextbox"  BackColor="#FFFFB2"  TabIndex="22"/>
                                                    <asp:Image ID="btnoldlicense" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                                    <asp:TextBox ID="txtOldLicense" runat="server" CssClass="standardtextbox"  style="display: none" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CldrExtendrOldLicense" runat="server" TargetControlID="txtDate" PopupButtonID="btnoldlicense" Format="dd/MM/yyyy"  />
                                                    <asp:RequiredFieldValidator ID="RFVOldLicense" runat="server" SetFocusOnError="true"  ControlToValidate="txtDate"  Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                    <ASP:COMPAREVALIDATOR id="COMPAREVALIDATOROldLicense" runat="server" errormessage="Invalid date!" operator="DataTypeCheck" type="Date" 
                                                    controltovalidate="txtDate" Display="Dynamic" ></ASP:COMPAREVALIDATOR>&nbsp;
                                                    <asp:RangeValidator ID="RVOldLicense" runat="server" ControlToValidate="txtDate" Display="Dynamic"
                                                        ErrorMessage="Date out of range!" MaximumValue="2099-01-01" MinimumValue="1900-01-01"
                                                        Type="Date"></asp:RangeValidator>
                                                   <%-- <uc7:ctlDate ID="txtOldTccLcnExpDate" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                        RequiredField="false" TabIndex="95" />--%>
                                                </td>
			                               </tr>
			                               <tr id="trTCCase1" runat="server" visible="false">
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblPrevInsurerName" runat="server" Style="color: black" Text="Prev Insurer Name" ></asp:Label><span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:TextBox id="txtTccPrevInsurerName" runat="server" 
                                                        CssClass="standardtextbox" BackColor="#FFFFB2" TabIndex="23" ></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" InvalidChars=",#$@%^!*()&''%^~`1234567890"
                                                          FilterMode="InvalidChars" TargetControlID="txtTccPrevInsurerName" FilterType="Custom">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>  
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblNOCFlag" runat="server" Style="color: black" Text="NOC Received" ></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                               
                                                     <asp:CheckBox ID="cbNOCFlag" runat="server" CssClass="standardcheckbox" BackColor="#FFFFB2" AutoPostBack="false"
                                                         Visible = "false" />
                                                     <asp:updatepanel ID="upnlRbtNoc" runat="server">
                                                         <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbtNoc" runat="server" RepeatDirection="Horizontal" 
                                                               CssClass="radiobtn" TabIndex="24" 
                                                               AutoPostBack="true" OnSelectedIndexChanged="RbtNoc_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Text="Y" Selected="True" >Yes</asp:ListItem>
                                                            <asp:ListItem Value="1" Text="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>                                        
                                                     </asp:updatepanel>
                                                </td>
                                                
			                               </tr>

                                           <%-- <tr id="trAckRcv" runat="server" style="height:10%">
                                                <td style="width:20%;" class="formcontent"></td>
                                                <td style="width:30%;" class="formcontent"></td>
                                                <td style="width:20%;" class="formcontent">
                                                    <asp:updatepanel ID="upnllblAckrcv" runat="server">
                                                         <ContentTemplate>
                                                             <asp:Label ID="lblAckrcv" runat="server" Visible="false"/>
                                                         </ContentTemplate>
                                                         <Triggers>
                                                              <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                         </Triggers>
                                                     </asp:updatepanel>
                                                </td>
                                                <td style="width:30%;" class="formcontent">
                                                    <asp:updatepanel ID="upnlRbAckRev" runat="server">
                                                       <ContentTemplate>
                                                            <asp:RadioButtonList ID="RbAckRev" runat="server" CssClass="radiobtn"  RepeatDirection="Horizontal" 
                                                               Visible="false" TabIndex="25">
                                                                <asp:ListItem Value="Y" >Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="RBtNoc" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:updatepanel>
                                               </td>
                                           </tr>--%>
			                               <tr id="tr1" runat="server" visible="false">
			                                    <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblCasteCat" runat="server" Style="color: black" Text="Category" ></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                    <asp:DropDownList ID="ddlCasteCat" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                         Width="187px" TabIndex="26" >
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" class="formcontent" style="width:20%;">
                                                    <asp:Label ID="lblPrimProf" runat="server" Style="color: black" Text="Primary Profession" ></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 30%;">
                                                 
                                                      <asp:DropDownList ID="ddlPrimProf" runat="server" CssClass="standardmenu" BackColor="#FFFFB2" Width="187px" TabIndex="27">
                                                          <asp:ListItem Text="--Select--" Value=""> </asp:ListItem>
                                                      </asp:DropDownList>
                                                   
                                                </td>
			                                </tr>
                                    </table>
                                    </div>

                                      <asp:UpdatePanel ID="UpdPanelRecruitInfo" runat="server">
                                        <contenttemplate>
                                            <table class="formtable" style="width: 100%;">
                                                 <tr>
                                                      <td  colspan="4" class="test">
                                                           <input runat="server" type="button" class="standardlink" value="-" id="btnRecruitInformation" style="width: 20px;"
                                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divRecruitInformation','ctl00_ContentPlaceHolder1_btnRecruitInformation');" />
                                                           <asp:Label ID="lblpfrecinfotitle" runat="server" Font-Bold="true"></asp:Label>
                                                      </td>
                                                 </tr>
                                            </table>
                                            <div id="divRecruitInformation" runat="server" style="display: block;">
                                               <table class="formtable" style="width: 100%;">
                                                 <tr>
                                                      <td nowrap="nowrap" align="left" class="formcontent" style="width: 20%;">
                                                          <asp:Label ID="lblpfbesmcode" runat="server" ></asp:Label>
                                                      </td>
                                                      <td nowrap="nowrap" align="left" class="formcontent" style="width: 30%;">
                                                           <asp:TextBox id="txtSmCode" runat="server" CssClass="standardtextbox"
                                                                MaxLength="10" TabIndex="31" Enabled="False"></asp:TextBox>
                                                           <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" InvalidChars=",#$@%^!*()& ''%^~`"
                                                                FilterMode="InvalidChars" TargetControlID="txtSmCode" FilterType="Custom">
                                                           </ajaxToolkit:FilteredTextBoxExtender>
                                                            <%--<div class="btn btn-xs btn-primary">
                                                                <i class="fa fa-check-circle"></i>--%>
                                                           <asp:Button  id="btnVerifyCSC" runat="server" CssClass="standardbutton"  
                                                               Text="Verify" OnClientClick="funrecruitercode();" 
                                                                OnClick="btnVerifyCSC_Click"  Width="40px"
                                                                ValidationGroup="RecruitInfo" TabIndex="32" Enabled="False"></asp:Button>
                                                                <%--</div> --%>
                                                           <div id="iDivVerSCS" class="Content" style="display:none">
                                                           <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." /></img>Loading...</div>
                                                           <br />
                                                           <asp:Label ID="lblErrCSC" runat="server" style="COLOR: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                       </td>
                                                      <td  class="formcontent" nowrap="nowrap" style="width: 20%;">
                                                             <asp:Label ID="lblpfsalchannel" runat="server" Font-Bold="False"></asp:Label>
                                                      </td>
                                                      <td  class="formcontent" align="left" style="width: 30%;">
                                                            <asp:DropDownList id="ddlSlsChannel" runat="server" CssClass="standardmenu"
                                                                AutoPostBack="false" enabled="False" Width="187px" TabIndex="33"></asp:DropDownList>&nbsp;
                                                      </td>
                                                 </tr>
                                                 <tr>
                                                    <td  align="left" class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblpfchasubclass" runat="server" ></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="width: 30%;">
                                                         <asp:DropDownList id="ddlChnCls" runat="server" CssClass="standardmenu"
                                                                AutoPostBack="false" Enabled="False" Width="187px" TabIndex="34"></asp:DropDownList>&nbsp; 
                                                   </td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%">
                                                         <asp:Label ID="lblpfagetype" runat="server" Font-Bold="False"></asp:Label>
								                         &nbsp;</td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 30%">
                                                         <asp:DropDownList id="ddlAgntType" runat="server" CssClass="standardmenu"  visible="false" 
                                                              AutoPostBack="false" Width="187px" TabIndex="35" Enabled="False"></asp:DropDownList>
								                        <asp:DropDownList ID="ddlAgnTypes" runat="server" CssClass="standardmenu"  
                                                             DataTextField="AgentTypeDesc01" enabled="False"  
                                                              DataValueField ="AgentType" DataSourceID="DSAgnTypes" Width="187px"
                                                              TabIndex="36" ></asp:DropDownList>
                                                        <asp:SqlDataSource ID="DSAgnTypes" runat="server" ConnectionString="<%$ ConnectionStrings:INSCCommonConnectionString %>" ></asp:SqlDataSource>
                                                    </td>
                                                 </tr>
                                                 <%--<tr id="trbranch" visible="false">
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%">
                                                        <asp:Label ID="lblpfimmleader" runat="server"></asp:Label><span style="color: #ff0000">*</span></td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 30%">
                                                        <asp:TextBox id="txtImmLeader" runat="server" CssClass="standardtextbox" 
                                                                MaxLength="10" ReadOnly="true" TabIndex="37" Enabled="False"></asp:TextBox> 
                                                         <asp:Button id="btnImmLeaderCode" runat="server" CssClass="standardbutton"  Text="..." 
                                                                Enabled="false" visible="false" TabIndex="38"></asp:Button> 
                                                     </td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                            <asp:Label ID="lblpfsmname" runat="server"></asp:Label>
                                                            <span style="color: #ff0000">*</span>
                                                    </td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 30%;">
                                                        <asp:TextBox id="txtDirectAgtName" runat="server" CssClass="standardtextbox"
                                                                ReadOnly="true" TabIndex="39" Enabled="False"></asp:TextBox> 
                                                    </td>
                                                 </tr>--%>
                                                 <tr id="trrec" visible="false">
                                                     <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                          <asp:Label ID="lblpfrecagent" visible="false" runat="server"></asp:Label>
                                                     </td>
                                                     <td class="formcontent"  nowrap="nowrap" align="left" style="width: 30%;">
                                                          <asp:TextBox id="txtrecagent" runat="server" CssClass="standardtextbox" 
                                                              visible="false" MaxLength="10" ReadOnly="true" TabIndex="40" Enabled="False" ></asp:TextBox> 
                                                          <asp:Button id="btnagent" runat="server" CssClass="btn btn-xs btn-primary" 
                                                               Text="..." Enabled="False"  visible="false" TabIndex="41"></asp:Button> 
                                                    </td>
                                                     <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                         <asp:Label ID="lblpfrecagtname" visible="false" runat="server"></asp:Label>
                                                     </td>
                                                     <td class="formcontent"  nowrap="nowrap" style="width: 30%;">
                                                         <asp:TextBox id="txtrecagtname" runat="server" CssClass="standardtextbox"  visible="false"  
                                                              ReadOnly="true" TabIndex="42" Enabled="False" ></asp:TextBox> 
                                                     </td>
                                                 </tr>
                                                 <%--Added By Ankita Shah for Referral EmpCode Information on 31/01/2013***********************--%>                                                   
                                                 <tr id="trRefEmpBy" runat="server" visible="false">
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                       <asp:Label ID="lblReferredEmpBy" Text="Referral Code" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 30%;">
                                                        <asp:TextBox id="txtReferredEmpBy" runat="server" CssClass="standardtextbox" 
                                                            MaxLength="43"></asp:TextBox> 
                                                        <asp:Button id="btnVerifyRefEmpBy" runat="server" CssClass="standardbutton" Text="Verify"   
                                                                OnClick="btnVerifyRefEmpBy_Click" ValidationGroup="RecruitInfo" Width="44px"></asp:Button> 
                                                        <div id="iDivVerRefEmpBy" class="Content" style="display:none">
                                                        <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." /></img>Loading...</div>
                                                        <br />
                                                        <asp:Label ID="lblErrRefEmpBy" runat="server" style="COLOR: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                        <asp:HiddenField id="hdnRefEmpBy" runat="server"></asp:HiddenField> 
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" 
                                                               TargetControlID= "txtReferredEmpBy" FilterType="Numbers" Enabled="True">
                                                        </ajaxToolkit:FilteredTextBoxExtender> 
                                                   </td>
                                                    <td class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                       <asp:Label ID="lblrefEmp" Text="Referral Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td  class="formcontent"  nowrap="nowrap" align="left" style="width: 20%;">
                                                         <asp:TextBox id="txtRefByadvEmpName" runat="server" CssClass="standardtextbox"  
                                                             Enabled="true" TabIndex="45" ></asp:TextBox>
                                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtRefByadvEmpName" 
                                                              FilterType="Custom, LowercaseLetters, UppercaseLetters" InvalidChars="./()',-!@$^*_+={}[]|\:;?><123456789" 
                                                              Enabled="True" FilterMode="InvalidChars">
                                                         </ajaxToolkit:FilteredTextBoxExtender>       
                                                    </td>
                                                 </tr> 
                                                 <%--End Added By Ankita Shah for Referral EmpCode Information on 31/01/2013***********************--%>       
                                                 <tr id="trRefBy" runat="server" visible="false">
                                                      <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                                          <asp:Label ID="lblReferredBy" Text="Referred By Advisor"  runat="server"></asp:Label></td>
                                                      <td class="formcontent" nowrap="nowrap" align="left" style="width: 30%;">
                                                          <asp:TextBox id="txtReferredBy"  runat="server" CssClass="standardtextbox" 
                                                                MaxLength="10" TabIndex="46"  ></asp:TextBox> 
                                                                  <%--<div class="btn btn-xs btn-primary">
                                                                <i class="fa fa-check-circle"></i>--%>
                                                          <asp:Button id="btnVerifyRefBy" runat="server" CssClass="standardbutton" Text="Verify" 
                                                                OnClick="btnVerifyRefBy_Click" 
                                                                ValidationGroup="RecruitInfo" Width="40px" TabIndex="47"   ></asp:Button> <%--</div>--%>
                                                          <div id="iDivVerRefBy" class="Content" style="display:none">
                                                          <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." /></img>Loading...</div>
                                                          <br />
                                                          <asp:Label ID="lblErrRefBy" runat="server" style="COLOR: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                          <asp:HiddenField id="hdnRefBy" runat="server"></asp:HiddenField> 
                                                      </td>
                                                      <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                                         <asp:Label ID="Label10" Text="Referred By Advisor(Name)"        runat="server"></asp:Label></td>
                                                         <td class="formcontent" nowrap="nowrap" align="left" style="width: 20%;">
                                                         <asp:TextBox id="txtRefByadvName" Enabled="false" runat="server" TabIndex="48"></asp:TextBox>
                                                      </td>
                                                 </tr>
                                          </table>
                                            </div>
                                        </contenttemplate>
                                    </asp:UpdatePanel>              
                </td>
            </tr>
             <tr>
             <td>
              <%--<div class="btn btn-xs btn-primary">
                     <i class="fa fa-check"></i>--%>
                <asp:Button ID="btnUpdate" runat="server" CssClass="standardbutton"  CausesValidation="false"
                     OnClick="btnUpdate_Click" TabIndex="244" />
                     <%--</div>
                      <div class="btn btn-xs btn-primary">
                     <i class="fa fa-user"></i>--%>
                <asp:Button ID="btnCrtNewAgt" runat="server" CssClass="standardbutton"  CausesValidation="false"
                     TabIndex="245" onclick="btnCrtNewAgt_Click" Text="Create New Agent" Visible="false"/>
                     <%--</div>
                       <div class="btn btn-xs btn-primary">
                     <i class="fa fa-times"></i>--%>
                <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" 
                    CausesValidation="False" OnClick="btnCancel_Click" TabIndex="246" />
                   <%-- </div>--%>
              </td>
         </tr>
</table>
 <input id="hdnID210" type="hidden" runat="server" />
       <input id="hdnID260" type="hidden" runat="server" />
       <input id="hdnID270" type="hidden" runat="server" />
       <input id="hdnID280" type="hidden" runat="server" />
       <input id="hdnID290" type="hidden" runat="server" />
       <input id="hdnID300" type="hidden" runat="server" />
       <input id="hdnID310" type="hidden" runat="server" />
       <input id="hdnID320" type="hidden" runat="server" />
       <input id="hdnID330" type="hidden" runat="server" />
       <input id="hdnID340" type="hidden" runat="server" />
       <input id="hdnID350" type="hidden" runat="server" />
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
       <input id="hdnID540" type="hidden" runat="server" />
       <input id="hdnID550" type="hidden" runat="server" />
       <input id="hdnID560" type="hidden" runat="server" />
       <input id="hdnID570" type="hidden" runat="server" />
       <input id="hdnID580" type="hidden" runat="server" />
       <input id="hdnID590" type="hidden" runat="server" />
       <input id="hdnID600" type="hidden" runat="server" />
       <input id="hdnID610" type="hidden" runat="server" />
       <input id="hdnID620" type="hidden" runat="server" />
                                
       <input id="hdnID630" type="hidden" runat="server" />
       <input id="hdnID640" type="hidden" runat="server" />
       <input id="hdnID650" type="hidden" runat="server" />
       <input id="hdnID660" type="hidden" runat="server" />
       <input id="hdnID670" type="hidden" runat="server" />
                                
       <input id="hdnIsDateValid" type="hidden" runat="server" />
       <input id="hdnDOB" type="hidden" runat="server" />
       <input id="hdnSave" type="hidden" runat="server" />
       <input id="hdnUpdate" type="hidden" runat="server" />
       <input id="hdnAppno" type="hidden" runat="server" />
       <input id="hdSmCode" type="hidden" runat="server" />
       <input id="hdnECCode" type="hidden" runat="server" />
       <input id="hdnBizSrc" type="hidden" runat="server" />
                                
        <asp:HiddenField ID="hdnBtnDis" runat="server" />
             <table>
                  <tr>
                      <td>
                           <asp:UpdatePanel ID="updPnlHidden" runat="server">
                               <contenttemplate>
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <asp:HiddenField ID="hdnPan" runat="server" />    
                                    <%-- //04...07/09/2012...Miti --%>           
                                    <asp:HiddenField ID="hdnpanedit" runat="server" />
                                     <%--//04...07/09/2012...Miti--%>
                                </contenttemplate>
                            </asp:UpdatePanel>
                       </td>
                   </tr>
             </table>
</center>
    <asp:Panel runat="server" ID="pnlMdl" Width ="500" display = "none" >
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
            display="none"></iframe>
         <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        >
                    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" class="modalpopupmesg" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" Width="400px" Height="220px">
       <table width="100%">
           <tr align="center">
                <td class="test" width="100%" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
           </tr>
       </table>
       <table>
            <tr>
                <td style="width: 391px">
                     <br />
                        <center>
                             <asp:Label ID="lbl" runat="server"></asp:Label><br />
                        </center>
                    <br />
                 </td>
            </tr>
       </table>
       <center>
        <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205"  CssClass="btn-xs default"
               Width="81px" />
       </center>                       
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100" >
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>


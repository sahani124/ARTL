<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="CorpCltView.aspx.cs" Inherits="Application_Common_CorpCltView" %>
<%@ Register Src="ClientAddress.ascx" TagName="ClientAddress" TagPrefix="uc9" %>

<%@ Register Src="~/App_UserControl/Common/popupOccupation.ascx" TagName="popupOccupation" TagPrefix="uc5" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
<%--<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="~/Styles/main.css" />    --%>



<asp:ScriptManager runat="server" ID="SM">
        <Scripts>
            <asp:ScriptReference Path="Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference  Path="Lookup.asmx" />
        </Services>
    </asp:ScriptManager>   
    <div>
            <table id="Table1" runat="server" border="0" cellpadding="3" cellspacing="1" align="center">
                <tr>                
                    <td style="width: 700px;" > 
                        <table border="0" cellpadding="3" cellspacing="1" bgcolor="lavender" width="790" align="center">                            
                            <tr>                                
                                <td class="test" colspan="5"> 
                                    <table cellpadding="0" cellspacing="0" width="100%"> 
                                     <tr>                                    
                                        <td colspan="3">                             
                                            <asp:UpdatePanel ID="UpdPanelHeader" runat="server" RenderMode="Inline"  UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    &nbsp;<asp:Label ID="lblHeader" runat="server" Text="Personal Client" ></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <input id="hdnUpdate" runat="server" type="hidden" />
                                        </td>
                                        <td align="right" colspan="2">CLTCRP V1.3</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" width="150px">
                                    <span>Customer ID</span>
                                    
                                </td>
                                <td class="formcontent">
									<asp:Label ID="lblCustomerID" runat="server"></asp:Label></td>
                                <td class="formcontent" width="150px">
                                    <span>Client Code</span></td>
                                <td class="formcontent">
									<asp:Label ID="lblClientCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formcontent" width="150px">
                                    <span>Company Name </span></td>
                                <td class="formcontent" colspan="3">
									<asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
                            </tr>                        
                            <tr>
                                <td class="formcontent" width="150px">
                                    <span>Company Reg. No.</span></td>
                                <td class="formcontent">
									<asp:Label ID="lblCompRegNo" runat="server"></asp:Label></td>
                                <td class="formcontent" colspan="2">
									&nbsp;<asp:Button ID="cmdLookup1" runat="server" Text="..." Width="0" CausesValidation="False" CssClass="standardbutton"/>
                                </td>
                            </tr>                        
                            <tr>
                                <td class="formcontent" width="150">
                                    PAN No.</td>
                                <td class="formcontent">
									<asp:Label ID="lblPanNo" runat="server"></asp:Label></td>
                                <td class="formcontent" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" width="150">
                                    Special Indicator</td>
                                <td class="formcontent">
									<asp:Label ID="lblSpecialInd" runat="server"></asp:Label></td>
                                <td class="formcontent">
                                    Economic Activity</td>
                                <td class="formcontent">
									<asp:Label ID="lblEcoActivity" runat="server"></asp:Label></td>
                            </tr>
                            <tr>                            
                                <td class="formcontent" width="150px">
                                    <asp:Label ID="lblCnctType" runat="server" Text="Correspondence Address" Width="160px"></asp:Label></td>
                                <td class="formcontent" width="230px">
									<asp:Label ID="lblCorrAddress" runat="server"></asp:Label></td>                            
                                <td class="formcontent" width="230">
                                    Category</td>
                                <td class="formcontent" width="230">
									<asp:Label ID="lblCateg" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="3" cellspacing="1" width="800" align="center">
                            <tr>
                                <td style="width: 800px;">
                                   <%--<uc1:AddAddr ID="CltAddrB1" runat="server" ></uc1:AddAddr>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style=" text-align: left;" class="test">
                                    &nbsp;<asp:Label ID="lblABHeadear" runat="server" Text="" Font-Size="10pt">Correspondance Address</asp:Label></td>
                           </tr>
                            <tr>
                                <td colspan="2" valign="top" style="width: 84%"> 
                                    <table cellspacing="1" class="formtable" width="100%">
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" style="width: 163px">
                                                <asp:Label ID="lblAddr1" runat="server" Text="Address"></asp:Label>
                                                </td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblAddres1" runat="server"></asp:Label>&nbsp;
											</td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" style="width: 163px">
                                                <asp:Label ID="lblAddr2" runat="server" Text=""></asp:Label></td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblAddres2" runat="server"></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" style="width: 163px">
                                                <asp:Label ID="lblAddr3" runat="server"></asp:Label></td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblAddres3" runat="server"></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" style="width: 163px">
                                                <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label></td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblAddres4" runat="server"></asp:Label>
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">
                                    <table cellspacing="1" class="formtable" width="100%">
										<%-- 
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" Width="150px">
                                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                <asp:Label ID="lblEst2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                            </td>
                                            <td nowrap="nowrap" class="formcontent">
                                                <asp:TextBox width="230px" ID="txtCity" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVCity" runat="server" ControlToValidate="txtCity" Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="ctvCity" runat="server" ClientValidationFunction="doValidateName"
                                                    ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="Invalid characters!"
                                                    SetFocusOnError="True"></asp:CustomValidator></td>
                                        </tr>--%>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>&nbsp;
                                        </td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblStateCode" runat="server"></asp:Label>
												<asp:Label ID="lblStateDesc" runat="server"></asp:Label>
												&nbsp;&nbsp;
                                            </td>                              
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                <asp:Label ID="lblPin" runat="server" Text="Pin Code"></asp:Label>
                                                </td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblPinCod" runat="server"></asp:Label>
												&nbsp;
                                            </td>      
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                <asp:Label ID="lblCountryCodeAddr" runat="server" Text="Country"></asp:Label>
                                                </td>
                                            <td nowrap="nowrap" class="formcontent">
												<asp:Label ID="lblCountryCode" runat="server"></asp:Label>
												&nbsp;&nbsp;<asp:Label ID="lblCountryDesc" runat="server"></asp:Label>
											</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 800px"></td>
                            </tr>
                        </table>                      
                        <table border="0" cellpadding="3" cellspacing="1" width="800" align="center">                        
                            <tr>
                                <td style="width: 800px">
                                    <asp:PlaceHolder ID="plcAddress" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="3" cellspacing="0" width="790" align="center">  
                            <tr>                                                
                                <td class="test" >
                                    <asp:Label ID="lblDstbnMethod" runat="server" Text="Contact Preferred" Width="160" ></asp:Label></td>   
                                <td class="test" colspan="1" width="395">
									<asp:Label ID="lblContPref" runat="server"></asp:Label></td>
                                <td class="test" colspan="1">
                                    <asp:Label ID="lblPrivacy" runat="server" Text="Privacy" Width="145px" ></asp:Label></td>
                                <td class="test">
									<asp:Label ID="lblPriv" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formcontent">
                                    <span >Work Tel</span></td>
                                <td class="formcontent" bgcolor="#e6e6fa">
									<asp:Label ID="lblWorkTel" runat="server"></asp:Label></td>
                                <td class="formcontent">
                                    <span >Alternate Work &nbsp;Tel</span></td>
                                <td class="formcontent">
									<asp:Label ID="lblAltWorkTel" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                               <td class="formcontent">
                                    <span >Work Fax</span></td>
                                <td class="formcontent">
									<asp:Label ID="lblWorkFax" runat="server"></asp:Label></td>
                                <td class="formcontent">
                                    <span >Email</span></td>
                                <td class="formcontent">
									<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formcontent">
                                    <span >Website</span></td>
                                <td class="formcontent"colspan="3">
									<asp:Label ID="lblWebSite" runat="server"></asp:Label></td>                            
                            </tr>                       
                            <tr>
                                <td class="formcontent">
                                    Contact Person</td>
                                <td class="formcontent" colspan="3">
									<asp:Label ID="lblContPer" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="test" colspan="4">
                                    <span>Company Details</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent">
                                    <asp:Label ID="lblDOB" runat="server" Text="Date Incorporated " Width="120px"></asp:Label></td>
                                <td class="formcontent">
									<asp:Label ID="lblDateIncorpo" runat="server"></asp:Label></td>                                
                                <td class="formcontent">
                                    <asp:Label ID="Label1" runat="server" Text="Incorporated In"></asp:Label></td>
                                <td class="formcontent" width="200">
									<asp:Label ID="lblIncorpoin" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formcontent">Original Country</td>
                                <td class="formcontent">
									<asp:Label ID="lblOriginalCount" runat="server"></asp:Label></td>
                                <td class="formcontent">
                                    <asp:Label ID="lblCapital" runat="server" Text="Capital"></asp:Label>
                                    </td>
                                <td class="formcontent" width="160px">
									<asp:Label ID="lblCapt" runat="server"></asp:Label>&nbsp;</td>
                            </tr>
							<tr>
								<td class="formcontent">
                                    <asp:Label ID="lblStaffSz" runat="server" Text="Staff Size" Width="160"></asp:Label></td>
								<td class="formcontent">
									<asp:Label ID="lblStaffSize" runat="server"></asp:Label></td>
								<td class="formcontent">
									<asp:Label ID="lblService" runat="server" Text="Service Tax Applicable"></asp:Label></td>
								<td class="formcontent" width="160">
									<asp:Label ID="lblServiceTax" runat="server"></asp:Label></td>
							</tr>
                            <tr>
                                <td class="formcontent">Annual Turnover</td>
                                <td class="formcontent" width="160px">
									<asp:Label ID="lblAnualTurn" runat="server"></asp:Label></td>
                                <td class="formcontent">
                                    Prefered Client</td>
                                <td class="formcontent">
									<asp:Label ID="lblPrefClint" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
									&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="formcontent" colspan="4">
                                    <table id="Table2" runat="server" border="0" cellpadding="3" cellspacing="1">
                                        <tr>                                    
                                            <td align="left" width="400">
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Width="80px" Text="Cancel" CssClass="standardbutton" OnClientClick="doCancel();return false" OnClick="btnCancel_Click" />
                                            </td>                        
                                            <td align="right" width="400">
                                                     </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtFlagFind" runat="server" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" ></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator id="rfvFlg" runat="server" SetFocusOnError="True" ErrorMessage="Please press 'FIND' button to check the match client before proceed." Enabled="true" Display="Dynamic" ControlToValidate="txtFlagFind"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>                   &nbsp;&nbsp;
                        <asp:TextBox runat="server" ID="txtDupBtnFlag" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" Wrap="true" />
                   </td>    
                </tr>            
                <tr>
                    <td style="width: 727px; height: 20px" align="left">
                </td>   
                </tr>           
            </table>        
    </div>

     <!---------------------------------------Error/Confirmation MsgBox--------------------------------------------->
    
    <!---------------------------------------Error Msg--------------------------------------------->
    
    <!---------------------------------------Confirm Msg--------------------------------------------->
	&nbsp;<!---------------------------------------Confirm Msg--------------------------------------------->
	&nbsp;<%--<ajaxToolkit:ModalPopupExtender ID="MPEComfirm" TargetControlID="hdnComfirmbtn" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelComfirm" OkControlID="cmdYes" CancelControlID="cmdNo"></ajaxToolkit:ModalPopupExtender>--%>


 </asp:Content>

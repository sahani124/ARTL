<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CltViewInfo.aspx.cs" Inherits="Application_Common_CltViewInfo" %>
<%@ Register Src="ClientAddress.ascx" TagName="ClientAddress" TagPrefix="uc9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!--<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />-->

    <script type="text/javascript" src="~/Scripts/common.js"></script>

    <script type="text/javascript" src="~/Scripts/subModal.js"></script>

    <script type="text/javascript" src="~/Scripts/ValidationDefeater.js"></script>

    <script type="text/javascript" src="~/Scripts/formatting.js"></script>

   

    <div style="text-align: center">
        <table class="container" width="650px">
            <tr>
                <td>
                    <div id="div1">
                        <asp:Panel ID="PanelMain" runat="server">
                           
                            <table id="Table1" runat="server" class="container" width="100%" >
                          
                              
                                <tr>
                                <td style="width: 872px">
                                
                                        <!-- Personal Client -->
                                        <table class="formtable" align="center">
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <table class="container" width="100%">
                                                        <tr>
                                                       
                                                            <td style="width: 363px">
                                                               
                                                &nbsp;<asp:Label ID="lblHeader" runat="server" ></asp:Label>
                                           
                                                            </td>
                                                            <%--<td class="test" style=" text-align: right" colspan="2"><asp:Label ID="TextBox1" runat="server" Text="Version 1.3" Width="100%"></asp:Label></td>--%>
                                                            <td align="right" style="width: 182px">
                                                                CLTPRS V1.3</td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" colspan="1">
                                                   <asp:Label ID="lblCusID" runat="server"></asp:Label>
                                                </td>
                                                <td class="formcontent">
													<asp:Label ID="lblGCN" runat="server"></asp:Label>
													<asp:TextBox style="TEXT-ALIGN: center" id="txtCltStat" runat="server" Width="47px" BorderStyle="None" BorderColor="Transparent">Active</asp:TextBox> 
</td>
                                                <td class="formcontent"  colspan="1">
                                                    <span></span>
                                                        <asp:Label ID="lblCode" runat="server"  Width="95%"></asp:Label></td>
                                                <td class="formcontent" >
													<asp:Label ID="lblCltCode" runat="server"></asp:Label>&nbsp; 
														</td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="height: 7px" >
                                                    <span style="color: red"\>
                                                        <asp:Label ID="lblName" runat="server" style="color: black"></asp:Label>&nbsp; 
                                                           </td>
                                                <td class="formcontent" style="height: 7px">
													<asp:Label ID="lblTitle" runat="server"></asp:Label>
													&nbsp;<asp:Label ID="lblGivenName" runat="server"></asp:Label>
													&nbsp;&nbsp;<%-- <asp:RequiredFieldValidator id="RFVGivenName" runat="server" Enabled="true" ErrorMessage="Mandatory!" Display="Dynamic" ControlToValidate="txtGivenName"></asp:RequiredFieldValidator>--%></td>
                                                <td class="formcontent" style="height: 7px" >
                                                    <span><font color="Red"><asp:Label ID="lblSurName" runat="server" style="color: black"></asp:Label></font></span></td>
                                                <td class="formcontent" style="height: 7px">
													<asp:Label ID="lblSrName" runat="server"></asp:Label>
													&nbsp;&nbsp;
                                                      
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="height: 16px">
                                                    <asp:Label ID="lbldob" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent" style="height: 16px" >
													<asp:Label ID="lblDOB1" runat="server"></asp:Label></td>
                                                <td class="formcontent" style="height: 16px">
                                                    <asp:Label ID="lblFname" runat="server"></asp:Label>
                                                    <%--Commented by Anoop on 19-11-2007--%>
                                                    
                                                    <%--<span style="color: #ff0000">*</span>--%>
                                                </td>
                                                <td class="formcontent" style="height: 16px">
                                                    <%--<asp:UpdatePanel ID="UpdPanelSurname" runat="server" RenderMode="Inline">
                                                        <contenttemplate>--%>
													<asp:Label ID="lblFatherName" runat="server"></asp:Label><%--<asp:RequiredFieldValidator id="RFVnme" runat="server" Enabled="true" ErrorMessage="Mandatory!" Display="Dynamic" ControlToValidate="txtSurname" __designer:wfdid="w11"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator id="revname" runat="server" Enabled="False" SetFocusOnError="True" ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtSurname" ValidationExpression="[\w\s]*" __designer:wfdid="w12"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator id="ctvFatherName" runat="server" __designer:dtid="281474976710790" SetFocusOnError="True" ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtSurname" ClientValidationFunction="doValidateName" __designer:wfdid="w13"></asp:CustomValidator> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>--%><%--End of Comment--%></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="height: 24px" >
                                                    <asp:Label ID="lblPAN" runat="server"></asp:Label></td>
                                                <td class="formcontent" style="height: 24px">
													<asp:Label ID="lblPAN1" runat="server"></asp:Label></td>
                                                <td class="formcontent" style="height: 24px" >
                                                    Client Create Rule
                                                </td>
                                                <td class="formcontent" style="height: 24px">
													<asp:Label ID="lblcltcreaterule" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="height: 14px" >
                                                
                                                        <asp:Label ID="lblGender" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent" style="height: 14px">
													<asp:Label ID="lblGend" runat="server"></asp:Label>
													&nbsp;
                                                       
                                                </td>
                                                <td class="formcontent" style="height: 14px" >
                                                    <span><font color="Red">
                                                        <asp:Label ID="lblspIndicator" runat="server" style="color: black"></asp:Label></font></span></td>
                                                <td class="formcontent" style="height: 14px">
													<asp:Label ID="lblspecialindicator" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <span><font color="Red"><asp:Label ID="lblAltIDType" runat="server" style="color: black"></asp:Label></font></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblAlterIdType" runat="server"></asp:Label></td>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblMstatus" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span><%--<uc4:ddlLookup ID="cboOtherIDType" runat="server" CssClass="standardmenu" LookupCode="NBSIDKey" RequiredField="false" Width="150" />--%></td>
                                                <td class="formcontent">
													<asp:Label ID="lblMartStatus" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                  <span> <asp:Label ID="lblAltIDNo" runat="server"></asp:Label></span></td>
                                                <td class="formcontent">

                                                   
													<asp:Label ID="lblAlterIdNo" runat="server"></asp:Label></td>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblSOE" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblSOE1" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <span>
                                                        <asp:Label ID="lblNationality" runat="server"></asp:Label><span style="color: #ff0000">
                                                        </span></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblNationalID" runat="server"></asp:Label>
													<asp:Label ID="lblNationDesc" runat="server"></asp:Label></td>
                                                <td class="formcontent" >
                                                    
                                                        <asp:Label ID="lblCategory" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblCatg" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap" >
                                                    <span>
                                                        <asp:Label ID="lblHigestQul" runat="server"></asp:Label></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblQualification" runat="server"></asp:Label></td>
                                                <td class="formcontent" >
                                                    <span>
                                                      
                                                        <asp:Label ID="lblCorrAdd" runat="server"></asp:Label></span></td>
                                                <td class="formcontent">
													<asp:Label ID="lblCnctType" runat="server"></asp:Label>
													&nbsp; &nbsp; &nbsp;

                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInceptiondate" runat="server"></asp:Label></td>
                                                <td class="formcontent">
													<asp:Label ID="lblIncepDate" runat="server"></asp:Label></td>
                                                <td class="formcontent" nowrap="nowrap">
                                                </td>
                                                <td class="formcontent">
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Residential Address --------------------------------------------->
                                        <table class="container" width="100%" cellpadding="0" cellspacing="0">
                                            <%--<tr>
                            <td width="100%">
                                <uc1:AddAddr ID="CltAddrP1" runat="server" RFVAddr1Enabled="false" RFVCityEnabled="false"
                                    RFVCountryEnabled="false" RFVPinEnabled="false" RFVStateEnabled="false" />
                            </td>
                        </tr> --%>
                                            <tr>
                                                <td colspan="4" style="text-align: left;" class="test">
                                                    &nbsp;<asp:Label ID="lblAPHeadear" runat="server" Font-Size="10pt"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 440px" valign="top">
                                                    <table class="formtable" >
                                                        
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:145px" >
                                                                <asp:Label ID="lblAddrP1" runat="server"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblAddressP1" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrP2" runat="server" Text=""></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrP3" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrP4" runat="server" Visible="False"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2" valign="top" style="width: 425px">
                                                    <table cellspacing="1" class="formtable" width="100%">
                                                        <%--<tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblCityP" runat="server" Text="City"></asp:Label>
                                                                <asp:Label ID="lblEstP2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox Width="230px" ID="txtCityP" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="100"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVCityP" runat="server" ControlToValidate="txtCityP"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <br />
                                                                <asp:CustomValidator ID="ctvCityP" runat="server" ClientValidationFunction="doValidateName"
                                                                    ControlToValidate="txtCityP" Display="Dynamic" ErrorMessage="Invalid characters!"
                                                                    SetFocusOnError="True"></asp:CustomValidator></td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:175px">
                                                                <asp:Label ID="lblStateP" runat="server"></asp:Label>&nbsp;
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblStateCodeP1" runat="server"></asp:Label>
																<asp:Label ID="lblStateDescP1" runat="server"></asp:Label>&nbsp;
															</td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblPinP" runat="server"></asp:Label>
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblPinCodeP1" runat="server"></asp:Label>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px" >
                                                                <asp:Label ID="lblCountryP" runat="server"></asp:Label>
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent" >
																<asp:Label ID="lblCountryIdP1" runat="server"></asp:Label>
																<asp:Label ID="lblCountryDescP1" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Residential Multiple Address --------------------------------------------->
                                        <table class="container" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="100%" align="left">
                                                    <asp:PlaceHolder ID="plcAddressP" runat="server"></asp:PlaceHolder>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Business Address --------------------------------------------->
                                        <table class="container" cellpadding="0" cellspacing="0">
                                            <%--<tr>
                            <td width="100%">
                                <uc1:AddAddr ID="CltAddrB1" runat="server" RFVAddr1Enabled="false" RFVCityEnabled="false"
                                    RFVCountryEnabled="false" RFVPinEnabled="false" RFVStateEnabled="false" />
                            </td>
                        </tr> --%>
                                            <tr>
                                                <td colspan="4" style="text-align: left;" class="test">
                                                    &nbsp;<asp:Label ID="lblABHeadear" runat="server" Font-Size="10pt"></asp:Label>&nbsp;
                                                    </td>
                                            </tr>
                                            
                                            <tr valign="top">
                                                <td colspan="2" style="width: 440px" valign="top">
                                                    <table class="formtable" >
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:145px" >
                                                                <asp:Label ID="lblAddrB1" runat="server" ></asp:Label>
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblAddressB1" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrB2" runat="server" Text=""></asp:Label></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  >
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrB3" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:Label ID="lblAddrB4" runat="server" Visible="False"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2" style="width: 425px" valign="top">
                                                    <table cellspacing="1" class="formtable" width="100%">
                                                        <%--<tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblCityB" runat="server" Text="City"></asp:Label>
                                                                <asp:Label ID="lblEstB2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox Width="230px" ID="txtCityB" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="100"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVCityB" runat="server" ControlToValidate="txtCityB"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvCityB" runat="server" ClientValidationFunction="doValidateName"
                                                                    ControlToValidate="txtCityB" Display="Dynamic" ErrorMessage="Invalid characters!"
                                                                    SetFocusOnError="True"></asp:CustomValidator></td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:175px">
                                                                <asp:Label ID="lblStateB" runat="server"></asp:Label>&nbsp;
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblStateCodeB1" runat="server"></asp:Label>
																<asp:Label ID="lblStateDescB1" runat="server"></asp:Label>&nbsp;
															</td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px" >
                                                                <asp:Label ID="lblPinB" runat="server"></asp:Label>
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent" >
																<asp:Label ID="lblPinCodeB1" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblCountryB" runat="server"></asp:Label>
                                                                </td>
                                                            <td nowrap="nowrap" class="formcontent">
																<asp:Label ID="lblCountryIdB1" runat="server"></asp:Label>
																<asp:Label ID="lblCountryDescB1" runat="server"></asp:Label>&nbsp;
															</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Businees Multiple Address --------------------------------------------->
                                        <table style="font-size: 8pt;" border="0" cellpadding="3" cellspacing="1" width="790"
                                            align="center">
                                            <tr>
                                                <td width="100%" align="left" >
                                                    <asp:PlaceHolder ID="plcAddressB" runat="server"></asp:PlaceHolder>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Client Contact --------------------------------------------->
                                        <table class="formtable">
                                        <tr>
											<td class="test" colspan="4" >
												<asp:Label ID="lblPA" runat="server"></asp:Label>
												&nbsp;
												<asp:Label ID="lblChkPA" runat="server"></asp:Label><%-- <asp:Button ID="btnPAdd" runat="server" CssClass="standardbutton" Text="Show Permanent Address" CausesValidation="false"/>--%></td>
                                         </tr>
                                         <tr id="trPermAdd1" runat="server">
											<td colspan="2" valign="top" style="width:40%">
												<table class="formtable" width="100%">
													<tr style="width:100px">
														<td class="formcontent" id="lblTitle1" style="width: 140px; height: 9px;">Address</td>
														<td class="formcontent" nowrap="nowrap" style="height: 9px">
															<asp:Label ID="lblAddr1" runat="server"></asp:Label>
															&nbsp;&nbsp;</td>
													</tr>
													<tr id="trPermAdd2" runat="server">
														<td class="formcontent"></td>
														<td class="formcontent">
															<asp:Label ID="lbladdr2" runat="server"></asp:Label>&nbsp;</td>
													</tr>
													<tr id="trPermAdd3" runat="server">
														<td class="formcontent"></td>
														<td class="formcontent">
															<asp:Label ID="lblAddr3" runat="server"></asp:Label>&nbsp;
														</td>
													</tr>
													<%--
													<tr id="trPermAdd4" runat="server">
														<td class="formcontent"></td>
														<td class="formcontent">
															<asp:TextBox CssClass="standardtextbox" ID="txtAdd4" runat="server" Width="160px" MaxLength="30" TabIndex="4"></asp:TextBox>
														</td>
				                                        
													</tr>
													--%>		
												</table>
											</td>
											<td colspan="2" valign="top" style="width:40%">
												<table class="formtable" width="100%">
													<tr style="width:100%">
														<td nowrap="nowrap" class="formcontent">
															State</td>
														<td class="formcontent">
															<asp:Label ID="lblStateId1" runat="server"></asp:Label>
															<asp:Label ID="lblStateDesc1" runat="server"></asp:Label>
															&nbsp;
														</td>
														<%--
														<td class="formcontent">City</td>
														<td class="formcontent">
															<asp:TextBox CssClass="standardtextbox" ID="txtCity" runat="server" Width="185px" TabIndex="5"></asp:TextBox>
														</td>--%>
													</tr>
													<tr>
														<td class="formcontent" style="width:150px" nowrap="nowrap">
															PIN Code</td>
														<td class="formcontent" nowrap="nowrap">
															<asp:Label ID="lblPinCode" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td nowrap="nowrap" class="formcontent" width="150px">Country</td>
														<td class="formcontent" nowrap="nowrap">
															<asp:Label ID="lblCountryID" runat="server"></asp:Label>
															<asp:Label ID="lblCountryDesc" runat="server"></asp:Label>
															&nbsp;&nbsp;
														</td>	                                        
													</tr>
												</table>
											</td>
                                         </tr>
                                         <tr>
                                                <td class="test" width="100%" colspan="4" style="height: 18px">
                                                    <table class="container">
                                                        <tr>
                                                            <td style="width: 29%">
                                                                Contact Preferred</td>
                                                            <td width="30%">
																<asp:Label ID="lblCnctPrefer" runat="server"></asp:Label></td>
                                                            <td width="20%">
                                                                Privacy</td>
                                                            <td style="width: 30%">
																<asp:Label ID="lblPrivacy" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">
                                                    
                                                        <asp:Label ID="lblHomeTel" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent" style="width: 20%">
													<asp:Label ID="lblHomeTelNo" runat="server"></asp:Label></td>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblOfficeTel" runat="server" Width="76px"></asp:Label></span></td>
                                                <td class="formcontent" width="20%" >
													<asp:Label ID="lblOfficeTelNo" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" style="height: 3px">
                                                    <asp:Label ID="lblDIdNo" runat="server" Width="78px"></asp:Label></td>
                                                <td class="formcontent" style="width: 27%; height: 3px;">
													<asp:Label ID="lblDidTellNo" runat="server"></asp:Label></td>
                                                <td class="formcontent" width="20%" style="height: 3px">
                                                    <asp:Label ID="lblMobileNo" runat="server"></asp:Label><span
                                                        style="color: #ff0000"></span></td>
                                                <td class="formcontent" width="30%" style="height: 3px">
													<asp:Label ID="lblMobileNo1" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblEmail" runat="server" Width="44px"></asp:Label>
                                                    </span></td>
                                                <td class="formcontent" style="width: 20%;">
													<asp:Label ID="lblEmail1" runat="server"></asp:Label></td>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblDirectmail" runat="server" Width="84px"></asp:Label>
                                                    </span></td>
                                                <td class="formcontent" width="20%" >
													<asp:Label ID="lblDirectMail1" runat="server"></asp:Label>
													&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" style="height: 24px">
                                                    <asp:Label ID="lblPager" runat="server" Width="72px"></asp:Label></td>
                                                <td class="formcontent" style="width: 27%; height: 24px;">
													<asp:Label ID="lblPager1" runat="server"></asp:Label></td>
                                                <td class="formcontent" width="20%" style="height: 24px">
                                                    &nbsp;<asp:Label ID="lblFax" runat="server" Width="74px"></asp:Label></td>
                                                <td class="formcontent" width="20%" style="height: 24px">
													<asp:Label ID="lblFax1" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <span>Personal Details</span></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblHeight" runat="server" ></asp:Label></td>
                                                <td class="formcontent" style="width: 27%" >
													<asp:Label ID="lblHeightcm" runat="server"></asp:Label>
													<asp:Label ID="lblheightcm2" runat="server"></asp:Label>&nbsp;<br />
												</td>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblWeight" runat="server"></asp:Label></td>
                                                <td class="formcontent" width="20%" >
													<asp:Label ID="lblwt" runat="server"></asp:Label>
												</td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">
                                                    <span>
                                                        <asp:Label ID="lblOccup" runat="server" Width="78px"></asp:Label><font color="Red"></font></span></td>
                                                <td class="formcontent" style="width: 27%">
													<asp:Label ID="lblOccpationCode" runat="server"></asp:Label>&nbsp;
													<asp:Label ID="lblOccupDesc" runat="server"></asp:Label>
													&nbsp;&nbsp;
                                                </td>
                                                <td class="formcontent" width="20%">
                                                    <span>
                                                        <asp:Label ID="lblAnnualIncome" runat="server" Width="104px"></asp:Label></span></td>
                                                <td class="formcontent" width="30%">
													<asp:Label ID="lblAnnInc" runat="server"></asp:Label>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" style="height: 33px" >
                                                    <asp:Label ID="lblPreferedClient" runat="server" Width="108px"></asp:Label></td>
                                                <td class="formcontent" colspan="3" width="80%" style="height: 33px" >
													<asp:Label ID="lblPrefClient" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblStaff" runat="server" Width="42px"></asp:Label></td>
                                                <td class="formcontent" colspan="3" width="80%" >
													<asp:Label ID="lblSta" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblServiceTax" runat="server" Width="146px"></asp:Label></td>
                                                <td class="formcontent" colspan="3" width="80%" >
													<asp:Label ID="lblSerTaxApp" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblRemark" runat="server" Width="80px"></asp:Label>
                                                    </span></td>
                                                <td width="80%" colspan="3" class="formcontent" >
													<asp:Label ID="lblRemarks" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                        <table id="Table2" runat="server" class="container">
                                            <tr>
                                                <td align="left" style="width:100%;">
													&nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Width="80px"
                                                        Text="Cancel" CssClass="standardbutton" OnClientClick="doCancel2();return false" OnClick="btnCancel_Click"  />&nbsp;
                                                </td>
                                                 </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                       

                       
    </div>
					</td>
        </tr>
    </table>
    </div>
    
    
</asp:Content>


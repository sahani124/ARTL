<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupPermAddr.aspx.cs" StylesheetTheme="Comm" Inherits="Application_Common_popupPermAddr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<!--><link href="~/Styles/style.css" type="text/css" rel="Stylesheet" />
<link href="~/Styles/style.css" type="text/css" rel="Stylesheet" />
  <link href="~/Styles/main.css" type="text/css" rel="Stylesheet" /><!-->

<head runat="server">
    <title>Untitled Page</title>
  
    
</head>
     <body>
              <form id="form1" runat="server">                                                                                        
                        <table class="formcontent" width="100%">                             
                                   <tr>
                                   <td  class="formcontent" >
                                   <asp:Label ID="lblAPHeadear" runat="server" Font-Size="10pt"></asp:Label></td>
                                 </tr>
                                    <tr>
                                                <td colspan="2"  width="80px" style="height: 23px" valign="top">
                                                    <table cellspacing="1" class="formcontent" width="100%">                                                                                                             
                                                        
                                                        <tr>
                                                            <td  class="formcontent"  >
                                                                <asp:Label ID="lblAddrP1" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP1" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                                                            <td  class="formcontent" width="60%">
                                                                <asp:TextBox  CssClass="standardtextbox" ID="txtAddrP1" runat="server" Width="150px" ></asp:TextBox>
                                                                <asp:CustomValidator ID="ctvAdd1" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP1" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RFVAddrP1" runat="server" ControlToValidate="txtAddrP1"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  width="0%" style="height: 21px">
                                                                <asp:Label ID="lblAddrP2" runat="server"></asp:Label></td>
                                                            <td nowrap="nowrap" class="formcontent"  width="80px" style="height:16px">
                                                                <asp:TextBox ID="txtAddrP2" runat="server" Width="150px" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP2" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  width="60px" style="height: 23px">
                                                                <asp:Label ID="lblAddrP3" runat="server"></asp:Label></td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrP3" runat="server" Width="150px" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP3" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="60px" style="height: 23px">
                                                                <asp:Label ID="lblAddrP4" runat="server" ></asp:Label></td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox Width="150px" ID="txtAddrP4" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30" ></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP4" Display="Dynamic" ErrorMessage="Invalid Address!"
                                                                    Visible="False"></asp:CustomValidator></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2" valign="top" >
                                                    <table cellspacing="1" class="formtable" width="100%">
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:Label ID="lblCity" runat="server" ></asp:Label>
                                                                <asp:Label ID="lblEstP2" runat="server" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox Width="80px" ID="txtCityP" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="100"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVCityP" runat="server" ControlToValidate="txtCityP"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvCityP" runat="server" ClientValidationFunction="doValidateName"
                                                                    ControlToValidate="txtCityP" Display="Dynamic" ErrorMessage="Invalid characters!"
                                                                    SetFocusOnError="True"></asp:CustomValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                                <asp:Label ID="lblEstP3" runat="server"  ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox ID="txtStateCodeP" runat="server" Width="80px"  onChange="javascript:this.value=this.value.toUpperCase();" ReadOnly="True" CssClass="standardtextbox"></asp:TextBox>
                                                                <asp:TextBox ID="txtStateDescP" runat="server" CssClass="standardtextbox" Width="80px"
                                                                    Enabled="false"></asp:TextBox>
                                                                <asp:Button ID="btnStateP" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                                    Text="..." />
                                                                <asp:RequiredFieldValidator ID="rfvStateP" runat="server" ControlToValidate="txtCountryDescP"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvStateP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCodeP"
                                                                    ClientValidationFunction="CheckStateListP"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvStateDescP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDescP"
                                                                    ClientValidationFunction="CheckStateListP"></asp:CustomValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  width="80px" style="height: 23px">
                                                                <asp:Label ID="lblPin" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP4" runat="server" ForeColor="red"></asp:Label></td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox Width="145px" ID="txtPinP" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="8"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVPinP" runat="server" ControlToValidate="txtPinP"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="CVPinP" runat="server" Enabled="true" ErrorMessage="Invalid Pin!"
                                                                    Display="Dynamic" ControlToValidate="txtPinP" ClientValidationFunction="CheckPINP"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  width="80px" style="height: 23px">
                                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP5" runat="server" ForeColor="red"></asp:Label></td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox ID="txtCountryCodeP" runat="server" CssClass="standardtextbox" Width="80px"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                                <asp:TextBox ID="txtCountryDescP" runat="server" CssClass="standardtextbox" Width="80px"
                                                                    Enabled="false"></asp:TextBox>
                                                                <asp:Button ID="btnCountryP" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                                    Text="..." />
                                                                <asp:RequiredFieldValidator ID="rfvCountryP" runat="server" ControlToValidate="txtCountryDescP"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvCountryCodeP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCodeP"
                                                                    ClientValidationFunction="CheckCountryListP"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvCountryDescP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDescP"
                                                                    ClientValidationFunction="CheckCountryListP"></asp:CustomValidator></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                         
    </form>
</body>
</html>



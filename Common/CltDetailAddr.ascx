<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CltDetailAddr.ascx.cs" Inherits="Application_Common_CltDetailAddr" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup" TagPrefix="uc1" %>
<%@ Register Src="~/App_UserControl/Common/popupLookup.ascx" TagName="popLookup" TagPrefix="uc2" %>
<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script type="text/javascript" language="javascript">
var path = "<%=Request.ApplicationPath.ToString()%>";

function doFormat(args)
{
    var sString = document.getElementById(args).value;
    //Trim spaces
    sString = doTrim(sString);
    //Collapse spaces
    sString = doCollapse(sString);
    //Ensure comma immediately follows a non-space and is followed by a space
    sString = doFormatComma(sString);
    //Convert first character to upper case
    sString = sString.replace(sString.substring(0,1), sString.substring(0,1).toUpperCase())
    
    document.getElementById(args).value = sString;
}

function doValidate(src, args)
{
    var result = true;
    var sString = args.Value;

    //Check if there's at least one block of 2 characters (valid)
    var sArray = sString.split(" ");
    var blnValid = false;
    for (var i = 0; i < sArray.length; i++)
    {
        if (sArray[i].length > 1)
        {
            blnValid = true;
        }            
    }
    if (!blnValid)
    {
        result = false;
    }
    
    //Check if there's a hyphen or apostrophe adjacent to space (invalid)
    if ((sString.match("' ") != null) ||
        (sString.match(" '") != null) ||
        (sString.match("- ") != null) ||
        (sString.match(" -") != null))
    {
        result = false;
    }
    
    //Check if there's three same characters in a row (invalid)
    sArray = sString.toUpperCase().split("");
    for (var i = 2; i < sArray.length; i++)
    {
        if ((sArray[i] == sArray[i - 1]) &&
            (sArray[i] == sArray[i - 2]))
        {
            result = false;
        }
    }
    
    args.IsValid = result;
}

function doTrim(sString) 
{
    while (sString.substring(0,1) == " ")
    {
        sString = sString.substring(1, sString.length);
    }
    
    while (sString.substring(sString.length - 1, sString.length) == " ")
    {
        sString = sString.substring(0,sString.length-1);
    }
    
    return sString;
}

function doCollapse(sString) 
{
    while (sString.match("  ") != null)
    {
        sString = sString.replace("  ", " ");
    }
    
    return sString;
}

function doFormatComma(sString)
{
    sString = sString.replace(",", ", ");
    sString = sString.replace(" ,", ",");
    sString = sString.replace(",  ", ", ");
    
    return sString;
}

    function popState(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopState.aspx?Code=" + sCode +
                    "&Desc=" + sDesc +
                    "&Field1=" + oCode +
                    "&Field2=" + oDesc
                    , 500, 350, null);
    }

    function popCountry(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopCountry.aspx?Code=" + sCode +
                    "&Desc=" + sDesc +
                    "&Field1=" + oCode +
                    "&Field2=" + oDesc
                    , 500, 350, null);
    }

    function CheckStateList(src, args)
    {
        var result = true;
        var StateCode = document.getElementById("<%=txtStateCode.ClientID%>").value.split(",");
        var StateDesc = document.getElementById("<%=txtStateDesc.ClientID%>").value.split(",");
  
        if ((StateCode != "") && (StateDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function CheckCountryList(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCode.ClientID%>").value.split(",");
        var CountryDesc = document.getElementById("<%=txtCountryDesc.ClientID%>").value.split(",");
  
        if ((CountryCode != "") && (CountryDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function Addr1toProperCase(s)
    {
        document.getElementById("<%=txtAddr1.ClientID%>").value = toProperCase(s);    
    }
    
    function Addr2toProperCase(s)
    {
        document.getElementById("<%=txtAddr2.ClientID%>").value = toProperCase(s);    
    }
    
    function Addr3toProperCase(s)
    {
        document.getElementById("<%=txtAddr3.ClientID%>").value = toProperCase(s);    
    }
    
    function Addr4toProperCase(s)
    {
        document.getElementById("<%=txtAddr4.ClientID%>").value = toProperCase(s);    
    }
    
    function CitytoProperCase(s)
    {
        document.getElementById("<%=txtCity.ClientID%>").value = toProperCase(s);    
    }
    
    function PintoProperCase(s)
    {
        document.getElementById("<%=txtPin.ClientID%>").value = toProperCase(s);    
    }
    
    function toProperCase(s)
    {
        return s.toLowerCase().replace(/^(.)|\s(.)/g, function($1) { return $1.toUpperCase(); })
    }
       
    
</script>
    <table cellpadding="0" cellspacing="0" border="0" id="TableAddr" class="formtable" rules="all" width="100%" style="font-size: 8pt;" >
        <tr>
            <td colspan="4" style=" text-align: left;" class="test">
                &nbsp;<asp:Label ID="lblABHeadear" runat="server" Text="" Font-Size="10pt"></asp:Label></td>
       </tr>
        <tr>
            <td colspan="2" width="100%">
                <table cellspacing="1" class="formtable" width="100%">
                    <tr>
                        <td nowrap="nowrap" class="formcontent" width="100%">
                            <asp:Label ID="lblAddr1" runat="server"></asp:Label>
                            <asp:Label ID="lblEst1" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="250px" ID="txtAddr1" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                            <asp:CustomValidator ID="ctvAdd1" runat="server" ClientValidationFunction="doValidate"
                                ControlToValidate="txtAdd1" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="RFVAddr1" runat="server" ControlToValidate="txtAddr1" Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:Label ID="lblAddr2" runat="server" Text=""></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="250px" ID="txtAddr2" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="doValidate"
                                ControlToValidate="txtAddr2" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:Label ID="lblAddr3" runat="server"></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="250px" ID="txtAddr3" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="doValidate"
                                ControlToValidate="txtAddr3" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="250px" ID="txtAddr4" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="doValidate"
                                ControlToValidate="txtAddr4" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table cellspacing="1" class="formtable" width="100%">
                    <tr>
                        <td nowrap="nowrap" class="formcontent" Width="150px">
                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                            <asp:Label ID="lblEst2" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="230px" ID="txtCity" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVCity" runat="server" ControlToValidate="txtCity" Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent" Width="150px">
                            <asp:Label ID="lblState" runat="server"></asp:Label>
                            <asp:Label ID="lblEst3" runat="server" Text="*" ForeColor="red"></asp:Label>
                    </td>
                        <td nowrap="nowrap" class="formcontent">
                        <asp:TextBox ID="txtStateCode" runat="server" CssClass="standardtextbox" Width="50px" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                        <asp:TextBox ID="txtStateDesc" runat="server" CssClass="standardtextbox" Width="130px" Enabled="false"></asp:TextBox>
                        <asp:Button ID="btnState" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..." Width="20px"/>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtStateDesc" Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:CustomValidator id="ctvState" runat="server" SetFocusOnError="True" Enabled="false" ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCode" ClientValidationFunction="CheckStateList"></asp:CustomValidator>
                        <asp:CustomValidator id="ctvStateDesc" runat="server" SetFocusOnError="True" Enabled="false"  ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDesc" ClientValidationFunction="CheckStateList"></asp:CustomValidator></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent" Width="150px">
                            <asp:Label ID="lblPin" runat="server"></asp:Label>
                            <asp:Label ID="lblEst4" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox width="230" ID="txtPin" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVPin" runat="server" ControlToValidate="txtPin" Enabled="true" 
                        Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="formcontent" Width="150px">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                            <asp:Label ID="lblEst5" runat="server" Text="*" ForeColor="red"></asp:Label></td>
                        <td nowrap="nowrap" class="formcontent">
                            <asp:TextBox ID="txtCountryCode" runat="server" CssClass="standardtextbox" Width="50px" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            <asp:TextBox ID="txtCountryDesc" runat="server" CssClass="standardtextbox" Width="130px" Enabled="false"></asp:TextBox>
                            <asp:Button ID="btnCountry" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..." Width="20px"/>
                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountryDesc" Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:CustomValidator id="ctvCountryCode" runat="server" SetFocusOnError="True" Enabled="false" ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCode" ClientValidationFunction="CheckCountryList"></asp:CustomValidator>
                            <asp:CustomValidator id="ctvCountryDesc" runat="server" SetFocusOnError="True" Enabled="false" ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDesc" ClientValidationFunction="CheckCountryList"></asp:CustomValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>








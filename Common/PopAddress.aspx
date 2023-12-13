<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopAddress.aspx.cs" Inherits="Application_Common_PopAddress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script type="text/javascript" src="~/Scripts/formatting.js"></script>

<script language="javascript" type="text/javascript">
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
    //Convert to proper case
    sString = toProperCase(sString);
    
    document.getElementById(args).value = sString;
}

function doValidateName(src, args)
{
    var result = true;
    var sString = args.Value;

    //Check for invalid characters
    var iChars = "!@$^*_+={}[]|\:;?><";
    
    for (var i = 0; i < args.Value.length; i++) 
    {
  	    if (iChars.indexOf(args.Value.charAt(i)) != -1) 
  	    {
  	        result = false;
  	    }
    }
    
    if (args.Value.length == 1)
    {
        result = false;
    }
    
    args.IsValid = result;
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
    for (var i = 3; i < sArray.length; i++)
    {
        if ((sArray[i] == sArray[i - 1]) &&
            (sArray[i] == sArray[i - 2]) &&
            (sArray[i] == sArray[i - 3]))
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

function doSave(add1, add2, add3, add4, city, state, postcode, country)
{   
    if (Page_ClientValidate() || IsBlank())
    {
//        CheckValidateAddr();
        window.parent.document.getElementById(add1).value = doEncodeToParent(document.getElementById("txtAdd1").value);
        window.parent.document.getElementById(add2).value = doEncodeToParent(document.getElementById("txtAdd2").value);
        window.parent.document.getElementById(add3).value = doEncodeToParent(document.getElementById("txtAdd3").value);
        window.parent.document.getElementById(add4).value = doEncodeToParent(document.getElementById("txtAdd4").value);
        window.parent.document.getElementById(city).value = doEncodeToParent(document.getElementById("txtCity").value);
        window.parent.document.getElementById(state).value = doEncodeToParent(document.getElementById("txtStateCode").value);
        window.parent.document.getElementById(postcode).value = doEncodeToParent(document.getElementById("txtPostcode").value);
        window.parent.document.getElementById(country).value = doEncodeToParent(document.getElementById("txtCountryCode").value);
        window.parent.window.hidePopWin(false);
    }   
}

function IsBlank()
{
    if ((document.getElementById("<%=txtAdd1.ClientID%>").value == "") &&
        (document.getElementById("<%=txtAdd2.ClientID%>").value == "") &&
        (document.getElementById("<%=txtAdd3.ClientID%>").value == "") &&
        (document.getElementById("<%=txtAdd4.ClientID%>").value == "") &&
        (document.getElementById("<%=txtCity.ClientID%>").value == "") &&
        (document.getElementById("<%=txtStateCode.ClientID%>").value == "") &&
        (document.getElementById("<%=txtStateDesc.ClientID%>").value == "") &&
        (document.getElementById("<%=txtPostcode.ClientID%>").value == "") &&
        (document.getElementById("<%=txtCountryCode.ClientID%>").value == "") &&
        (document.getElementById("<%=txtCountryDesc.ClientID%>").value == ""))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function popState(code, name, statecode, statedesc)
{
    showPopWin("PopState.aspx?Code=" + doEncodeToPopup(statecode) +
        "&Desc=" + doEncodeToPopup(statedesc) +
        "&Field1=" + doEncodeToPopup(code) +
        "&Field2=" + doEncodeToPopup(name)
        , 450, 150, null);
}

function popCountry(code, name, countrycode, countrydesc)
{
    showPopWin("PopResCntry.aspx?Code=" + doEncodeToPopup(countrycode) +
        "&Desc=" + doEncodeToPopup(countrydesc) +
        "&Field1=" + doEncodeToPopup(code) +
        "&Field2=" + doEncodeToPopup(name)
        , 450, 150, null);             
}

function doClear()
{
    document.getElementById("<%=txtAdd1.ClientID%>").value = "";
    document.getElementById("<%=txtAdd2.ClientID%>").value = "";
    document.getElementById("<%=txtAdd3.ClientID%>").value = "";
    document.getElementById("<%=txtAdd4.ClientID%>").value = "";
    document.getElementById("<%=txtCity.ClientID%>").value = "";
    document.getElementById("<%=txtStateCode.ClientID%>").value = "";
    document.getElementById("<%=txtStateDesc.ClientID%>").value = "";
    document.getElementById("<%=txtPostcode.ClientID%>").value = "";
    document.getElementById("<%=txtCountryCode.ClientID%>").value = "";
    document.getElementById("<%=txtCountryDesc.ClientID%>").value = "";        
}

function toProperCase(s)
{
    return s.toLowerCase().replace(/^(.)|\s(.)/g, function($1) { return $1.toUpperCase(); })
}

function IsNumeric(sText)
{
    var ValidChars = "0123456789";
    var IsNumber=true;
    var Char;

    for (i = 0; i < sText.length && IsNumber == true; i++) 
    { 
        Char = sText.charAt(i); 
        if (ValidChars.indexOf(Char) == -1) 
        {
            IsNumber = false;
        }
    }

    return IsNumber;  
}

function ValidatePin(src, args)
{
    var result = true;
    var CountryCode = document.getElementById("<%=txtCountryCode.ClientID%>").value;
    
    if (CountryCode.toUpperCase() == "IND")
    {            
        if (!IsNumeric(args.Value) || (args.Value.length != 6)) 
        {                
            result = false;
        }
    }              
    else
    {
        if (args.Value.length > 8)
        {
            result = false;
        }
    }
    
    args.IsValid = result;
}

function doCheckCountry()
{
    if ((document.getElementById("<%=txtCountryCode.ClientID%>").value.toUpperCase() == "IND") ||
        (document.getElementById("<%=txtCountryCode.ClientID%>").value.toUpperCase() == ""))
    {
        document.getElementById("<%=txtStateCode.ClientID%>").disabled = "";
        document.getElementById("<%=txtStateDesc.ClientID%>").disabled = "disabled";
        document.getElementById("<%=txtStateCode.ClientID%>").value = "";
    }
    else
    {
        document.getElementById("<%=txtStateCode.ClientID%>").disabled = "disabled";
        document.getElementById("<%=txtStateDesc.ClientID%>").disabled = "";
        document.getElementById("<%=txtStateCode.ClientID%>").value = "OT";
    }
}

</script>
<head runat="server">
    <title>Address</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptmgr">
        <Scripts>
            <asp:ScriptReference Path="Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference  Path="Lookup.asmx" />
        </Services>            
    </asp:ScriptManager>
    <div>
        <table class="formtable">
            <tr>
                <td class="formcontent" width="60px">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtAdd1" runat="server" Width="160px" MaxLength="30" TabIndex="1"></asp:TextBox>
                    <asp:CustomValidator ID="ctvAdd1" runat="server" ClientValidationFunction="doValidate"
                        ControlToValidate="txtAdd1" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="rfvAdd1" runat="server" Display="Dynamic" ErrorMessage="Mandatory!" SetFocusOnError="True" ControlToValidate="txtAdd1"></asp:RequiredFieldValidator></td>
                <td class="formcontent" width="60px">
                <asp:Label ID="lblCity" runat="server"></asp:Label>
                </td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtCity" runat="server" Width="185px" TabIndex="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="Dynamic" ErrorMessage="Mandatory!"
                        SetFocusOnError="True" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="ctvCity" runat="server" ClientValidationFunction="doValidateName"
                        ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="Invalid characters!"
                        SetFocusOnError="True"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td class="formcontent"></td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtAdd2" runat="server" Width="160px" MaxLength="30" TabIndex="2"></asp:TextBox>
                    <asp:CustomValidator ID="ctvAdd2" runat="server" ClientValidationFunction="doValidate"
                        ControlToValidate="txtAdd2" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                <td class="formcontent" style="width: 3px">
                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                </td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox ID="txtCountryCode" runat="server" CssClass="standardtextbox" MaxLength="4" Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="6"></asp:TextBox><asp:TextBox ID="txtCountryDesc" runat="server" CssClass="standardtextbox" Width="100px" Enabled="false" TabIndex="7"></asp:TextBox><asp:Button CssClass="standardbutton" ID="btnCountry" runat="server" Text="..." CausesValidation="False" Width="20px" TabIndex="8" /><asp:RequiredFieldValidator ID="rfvCountry" runat="server" Display="Dynamic"  ErrorMessage="Mandatory!" SetFocusOnError="True" ControlToValidate="txtCountryDesc"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="formcontent"></td>
                <td class="formcontent"  nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtAdd3" runat="server" Width="160px" MaxLength="30" TabIndex="3"></asp:TextBox>
                    <asp:CustomValidator ID="ctvAdd3" runat="server" ClientValidationFunction="doValidate"
                        ControlToValidate="txtAdd3" ErrorMessage="Invalid Address!"></asp:CustomValidator></td>
                <td class="formcontent">
                <asp:Label ID="lblState" runat="server"></asp:Label>
                    </td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox ID="txtStateCode" runat="server" CssClass="standardtextbox" MaxLength="4" Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="9"></asp:TextBox><asp:TextBox ID="txtStateDesc" runat="server" CssClass="standardtextbox" Width="100px" Enabled="false" TabIndex="10"></asp:TextBox><asp:Button CssClass="standardbutton" ID="btnState" runat="server" Text="..." CausesValidation="False" Width="20px" TabIndex="11" /><asp:RequiredFieldValidator ID="rfvState" runat="server" Display="Dynamic"  ErrorMessage="Mandatory!" SetFocusOnError="True" ControlToValidate="txtStateDesc"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="formcontent"></td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtAdd4" runat="server" Width="160px" MaxLength="30" TabIndex="4"></asp:TextBox>
                    <asp:CustomValidator ID="ctvAdd4" runat="server" ClientValidationFunction="doValidate"
                        ControlToValidate="txtAdd4" ErrorMessage="Invalid Address!" Visible="False"></asp:CustomValidator></td>
                <td class="formcontent">
                    <asp:Label ID="lblPincode" runat="server"></asp:Label>
                    </td>
                <td class="formcontent" nowrap="nowrap">
                    <asp:TextBox CssClass="standardtextbox" ID="txtPostcode" runat="server" Width="185px" TabIndex="12"></asp:TextBox><asp:CustomValidator ID="ctvPostcode" runat="server" ClientValidationFunction="ValidatePin"
                        ControlToValidate="txtPostcode" Display="Dynamic" ErrorMessage="Invalid Pin!"></asp:CustomValidator><asp:RequiredFieldValidator ID="rfvPostcode" runat="server" Display="Dynamic"
                        ErrorMessage="Mandatory!" SetFocusOnError="True" ControlToValidate="txtPostcode"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="formcontent" align="center" colspan="4" style=" text-align: center">
                    <asp:Button CssClass="standardbutton"  ID="btnSave" runat="server" Text="Ok" Width="50px" CausesValidation="false" TabIndex="13"/><asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" OnClientClick="doClear();return false;" CausesValidation="false" TabIndex="14" /><asp:Button CssClass="standardbutton" OnClientClick="window.parent.window.hidePopWin(false);return false;" ID="btnCancel" runat="server"  Text="Cancel" CausesValidation="False" Width="50px" TabIndex="15" />                                          
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    eval("<%=strInit%>");
</script>
</html>

<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Clt.aspx.cs" Inherits="Application_Common_Clt" %>

<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="CltDetailAddr.ascx" TagName="AddAddr" TagPrefix="uc1" %>
<%@ Register Src="../../App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="../../App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup" TagPrefix="uc3" %>
<%@ Register Src="../../App_UserControl/Common/ddlLookup2.ascx" TagName="ddlLookup" TagPrefix="uc4" %>
<%@ Register Src="../../App_UserControl/Common/popupOccupation.ascx" TagName="popupOccupation" TagPrefix="uc5" %>
<%@ Register Src="popupAML.ascx" TagName="popupAML" TagPrefix="uc6" %>
<%@ Register Src="ClientAML.ascx" TagName="ClientAML" TagPrefix="uc8" %>
<%@ Register Src="../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<%@ Register Src="ClientAddress.ascx" TagName="ClientAddress" TagPrefix="uc9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">

    var path = "<%=Request.ApplicationPath.ToString()%>";

    //Added by swapnesh on 14/5/2013 For showing popup start
    function funcShowPopup(strPopUpType) {
    
    if (strPopUpType == "state") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopState.aspx?Code=" + document.getElementById('<%=txtStateCode.ClientID %>').value 
        + "&Desc=" + document.getElementById('<%=txtStateDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtStateCode.ClientID %>').id 
        + "&field2=" + document.getElementById('<%=txtStateDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }
    if (strPopUpType == "stateP") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeP.ClientID %>').value 
        + "&Desc=" + document.getElementById('<%=txtStateDescP.ClientID %>').value + "&field1=" + document.getElementById('<%=txtStateCodeP.ClientID %>').id 
        + "&field2=" + document.getElementById('<%=txtStateDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }
    if (strPopUpType == "stateB") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopState.aspx?Code=" + document.getElementById('<%=txtStateCodeB.ClientID %>').value 
        + "&Desc=" + document.getElementById('<%=txtStateDescB.ClientID %>').value + "&field1=" + document.getElementById('<%=txtStateCodeB.ClientID %>').id 
        + "&field2=" + document.getElementById('<%=txtStateDescB.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }
    if (strPopUpType == "District") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopDistrict.aspx?strHDist=" + document.getElementById('<%=txtDistricP.ClientID %>').id + "&DistDesc=" + document.getElementById('<%=txtDistricP.ClientID%>').id + "&StateCode="
            + document.getElementById('<%=txtStateCodeP.ClientID %>').value + "&txtDisc=" + document.getElementById('<%=txtDistricP.ClientID %>').value
            + "&shdnPinFrom=" + document.getElementById('<%=hdnPinFrom.ClientID %>').id + "&shdnPinTo=" + document.getElementById('<%=hdnPinTo.ClientID %>').id
            + "&mdlpopup=mdlViewBID";
    }
        if (strPopUpType == "District1") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopDistrict.aspx?strHDist=" + document.getElementById('<%=txtDistrictB.ClientID %>').id + "&DistDesc=" + document.getElementById('<%=txtDistrictB.ClientID%>').id + "&StateCode="
            + document.getElementById('<%=txtStateCodeB.ClientID %>').value + "&txtDisc=" + document.getElementById('<%=txtDistrictB.ClientID %>').value
            + "&shdnPinFrom=" + document.getElementById('<%=hdnPinFrom.ClientID %>').id + "&shdnPinTo=" + document.getElementById('<%=hdnPinTo.ClientID %>').id
            + "&mdlpopup=mdlViewBID";
    }
        if (strPopUpType == "District2") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopDistrict.aspx?strHDist=" + document.getElementById('<%=txtDistric.ClientID %>').id + "&DistDesc=" + document.getElementById('<%=txtDistric.ClientID%>').id + "&StateCode="
            + document.getElementById('<%=txtStateCode.ClientID %>').value + "&txtDisc=" + document.getElementById('<%=txtDistric.ClientID %>').value
            + "&shdnPinFrom=" + document.getElementById('<%=hdnPinFrom.ClientID %>').id + "&shdnPinTo=" + document.getElementById('<%=hdnPinTo.ClientID %>').id
            + "&mdlpopup=mdlViewBID";
    }

    if (strPopUpType == "country") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtCountryDescP.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCodeP.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtCountryDescP.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }

    if (strPopUpType == "countryB") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCountry.aspx?Code=" + document.getElementById('<%=txtCountryCodeB.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtCountryDescB.ClientID %>').value + "&field1=" + document.getElementById('<%=txtCountryCodeB.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtCountryDescB.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }

     if (strPopUpType == "National") {
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopNational.aspx?Code=" + document.getElementById('<%=txtNationalCode.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=txtNationalDesc.ClientID %>').value + "&field1=" + document.getElementById('<%=txtNationalCode.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtNationalDesc.ClientID %>').id + "&mdlpopup=mdlViewBID";
    }

    if (strPopUpType == "Find") {////debugger;
        $find("mdlViewBID").show();
        document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopSearchClt.aspx?GCN=" + document.getElementById('<%=txtGCN.ClientID %>').value
        + "&Surname=" + document.getElementById('<%=txtname.ClientID %>').value + "&GivenName=" + document.getElementById('<%=txtGivenName.ClientID %>').value
        + "&Gender=" + document.getElementById('<%=cboGender.ClientID %>').value
        + "&DOB=" + document.getElementById('<%=txtDOB.ClientID %>'+'_txtDate').value + "&OthersID=" + document.getElementById('<%=txtCurrentID.ClientID %>').value
        + "&OtherIDType=txtCurrentIDType" + "&Field1=" + document.getElementById('<%=txtGCN.ClientID %>').id
        + "&Field2=" + document.getElementById('<%=txtSurname.ClientID %>').id + "&Field3=" + document.getElementById('<%=txtGivenName.ClientID %>').id
        + "&Field4=" + document.getElementById('<%=cboGender.ClientID %>').id + "&Field5=" + document.getElementById('<%=txtDOB.ClientID %>'+'_txtDate').id
        + "&Field6=" + document.getElementById('<%=txtCurrentID.ClientID %>').id + "&Field7=txtCurrentIDType"
         + "&mdlpopup=mdlViewBID";
    }
}

function popSearchClt (strPopUpType)
{
if(strPopUpType=="Find"){
$find("mdlViewBID").show();
document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopSearchClt.aspx?GCN=" + document.getElementById('<%=txtGCN.ClientID %>').value
+ "&Surname=" + document.getElementById('<%=txtSurname.ClientID %>').id +  "&GivenName="  + document.getElementById('<%=txtGivenName.ClientID %>').id +
+ "&Gender="+ document.getElementById('<%=cboGender.ClientID %>').id + "&DOB=" + document.getElementById('<%=txtDOB.ClientID %>').id 

+ document.getElementById('<%=txtGCN.ClientID %>').value
+ "&Surname=" + document.getElementById('<%=txtSurname.ClientID %>').value +  "&GivenName="  + document.getElementById('<%=txtGivenName.ClientID %>').value +
+ "&Gender="+ document.getElementById('<%=cboGender.ClientID %>').value + "&DOB=" + document.getElementById('<%=txtDOB.ClientID %>').value + 
 "&mdlpopup=mdlViewBID";
}
}

    //Added by swapnesh on 14/5/2013 For showing popup End

    function funDisableDOB()
    {
    // if("<%= Request.QueryString["GCN"] %>" != null)
    //   {
    //    document.getElementById("<%= txtDOB.ClientID %>"+ "_txtDate").readOnly = true;
    //    document.getElementById("ctl00_ContentPlaceHolder1_txtDOB_btnCalendar").style.display = "none";        
    //  }
    }

    function funDisableRecruitInfoDate()
    {       
        if("<%= Request.QueryString["Type"] %>" == "N")
        {          
             document.getElementById("<%= txtDOB.ClientID %>"+ "_txtDate").readOnly = true;
             document.getElementById("ctl00_ContentPlaceHolder1_txtDOB_btnCalendar").style.display = "none";
        }
    }    
    
    function funTogglePermAdd()
    {////debugger;
        if(document.getElementById("<%=ChkPA.ClientID %>").checked)
        {
            disableValidators("<%=rfvAdd1.ClientID%>");
            disableValidators("<%=rfvAdd2.ClientID%>");
            disableValidators("<%=rfvAdd3.ClientID%>");
            disableValidators("<%=rfvState.ClientID%>");
            disableValidators("<%=rfvPostCode.ClientID%>");
            disableValidators("<%=rfvCountryCode.ClientID%>");
        
            document.getElementById("<%=trPermAdd1.ClientID %>").style.display = "none";
            document.getElementById("<%=trPermAdd2.ClientID %>").style.display = "none";
            document.getElementById("<%=trPermAdd3.ClientID %>").style.display = "none";
        
            document.getElementById("<%=txtAdd1.ClientID %>").value = "";
            document.getElementById("<%=txtAdd2.ClientID %>").value = "";
            document.getElementById("<%=txtAdd3.ClientID %>").value = "";
            document.getElementById("<%=txtPostcode.ClientID %>").value = "";
            document.getElementById("<%=txtCountryCode.ClientID %>").value = "";
            document.getElementById("<%=txtCountryDesc.ClientID %>").value = "";
            document.getElementById("<%=txtStateCode.ClientID %>").value = "";
            document.getElementById("<%=txtStateDesc.ClientID %>").value = "";
        }
        else
        {
            if(document.getElementById("<%=txtAdd1.ClientID%>").value == "")
            {
                enableValidators("<%=rfvAdd1.ClientID%>");
            }
            if(document.getElementById("<%=txtAdd2.ClientID%>").value == "")
            {
                enableValidators("<%=rfvAdd2.ClientID%>");
            }
            if(document.getElementById("<%=txtAdd3.ClientID%>").value == "")
            {
                enableValidators("<%=rfvAdd3.ClientID%>");
            }
            if(document.getElementById("<%=txtStateCode.ClientID%>").value == "")
            {
                enableValidators("<%=rfvState.ClientID%>");
            }
            if(document.getElementById("<%=txtPostcode.ClientID%>").value == "")
            {
                enableValidators("<%=rfvPostCode.ClientID%>");
            }
            if(document.getElementById("<%=txtCountryCode.ClientID%>").value == "")
            {
                enableValidators("<%=rfvCountryCode.ClientID%>");
            }
            document.getElementById("<%=trPermAdd1.ClientID %>").style.display = "block";
            document.getElementById("<%=trPermAdd2.ClientID %>").style.display = "block";
            document.getElementById("<%=trPermAdd3.ClientID %>").style.display = "block";
        }
        return false;
    }

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
        var iChars = "!@$^*_+={}[]|\:;?><1234567890";
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

    function doValidateAddress(src, args)
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
        if ((sString.match("' ") != null) || (sString.match(" '") != null) || (sString.match("- ") != null) || (sString.match(" -") != null))
        {
            result = false;
        }
        //Check if there's three same characters in a row (invalid)
        sArray = sString.toUpperCase().split("");
        for (var i = 2; i < sArray.length; i++)
        {
            if ((sArray[i] == sArray[i - 1]) && (sArray[i] == sArray[i - 2]))
            {
                if (IsNumeric(sArray[i]) != true && IsAlphabet(sArray[i]) != true)
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

    function doValidate(src, args)
    {
        var result = false;
        var title = document.getElementById("<%=cboTitle.ClientID%>").value;
        var sTitle = document.getElementById("<%=hdnGenderTitle1.ClientID%>").value.split(",");
        var sGender = document.getElementById("<%=hdnGenderTitle2.ClientID%>").value.split(",");
        for (var i = 0; i < sTitle.length; i++)
        {
            if ((sTitle[i] == title) && (sGender[i] == args.Value))
            {
                result = true;
            }
        }
        args.IsValid = result;
    }

    function doCancel2(src, args)
    {
        var answer = confirm("Are you sure want to cancel?");
        var vgcn = document.getElementById("<%=txtGCN.ClientID%>").value;
        var vflag = document.getElementById("<%=txtFlagFind.ClientID%>").value;
        if (answer!=0) 
        {
			location.replace("Clt.aspx?ENQ=1&GCN=" + "" + "&FLAGFIND=" + vflag);
        }    
    }
    
    function funToggleValidators()
    {
        var address = document.getElementById("<%=hdnCnctType.ClientID%>").value.split(",");
        var GCN = document.getElementById("<%=txtGCN.ClientID%>").value.split(",");
        var ddl = document.getElementById("<%=cboCnctType.ClientID%>");
        if (ddl.value == "P1")
        {
            var ddd = document.getElementById("<%=txtAddrP1.ClientID%>").value;
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "*";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = ""; 
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = ""; 
            
            disableValidators("<%=RFVAddrB1.ClientID%>");
            disableValidators("<%=RFVAddrB2.ClientID%>");
            disableValidators("<%=RFVAddrB3.ClientID%>");
            disableValidators("<%=rfvStateB.ClientID%>");
            disableValidators("<%=RFVPinB.ClientID%>");
            disableValidators("<%=rfvCountryB.ClientID%>");
            
            if(document.getElementById("<%=txtAddrP1.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrP1.ClientID%>");
            }
            if(document.getElementById("<%=txtAddrP2.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrP2.ClientID%>");
            }
            if(document.getElementById("<%=txtAddrP3.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrP3.ClientID%>");
            }
            if(document.getElementById("<%=txtStateDescP.ClientID%>").value == "")
            {
                enableValidators("<%=rfvStateP.ClientID%>");
            }
            if(document.getElementById("<%=txtPinP.ClientID%>").value == "")
            {
                enableValidators("<%=RFVPinP.ClientID%>");
            }
            if(document.getElementById("<%=txtCountryDescP.ClientID%>").value == "")
            {
                enableValidators("<%=rfvCountryP.ClientID%>");
            }
            
        }        
        else if (ddl.value == "B1")           
        {
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "*";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = "*";  
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = "*";  
            
            if(document.getElementById("<%=txtAddrB1.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrB1.ClientID%>");
            }
            if(document.getElementById("<%=txtAddrB2.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrB2.ClientID%>");
            }
            if(document.getElementById("<%=txtAddrB3.ClientID%>").value == "")
            {
                enableValidators("<%=RFVAddrB3.ClientID%>");
            }
            if(document.getElementById("<%=txtStateDescB.ClientID%>").value == "")
            {
                enableValidators("<%=rfvStateB.ClientID%>");
            }
            if(document.getElementById("<%=txtPinB.ClientID%>").value == "")
            {
                enableValidators("<%=RFVPinB.ClientID%>");
            }    
            if(document.getElementById("<%=txtCountryDescB.ClientID%>").value == "")
            {    
                enableValidators("<%=rfvCountryB.ClientID%>");
            }
            
            disableValidators("<%=RFVAddrP1.ClientID%>");
            disableValidators("<%=RFVAddrP2.ClientID%>");
            disableValidators("<%=RFVAddrP3.ClientID%>");
            disableValidators("<%=rfvStateP.ClientID%>");
            disableValidators("<%=RFVPinP.ClientID%>");
            disableValidators("<%=rfvCountryP.ClientID%>");              
        }
        else
        {
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = "";  
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = "";  
            
            disableValidators("<%=RFVAddrB1.ClientID%>");
            disableValidators("<%=RFVAddrB2.ClientID%>");
            disableValidators("<%=RFVAddrB3.ClientID%>");
            disableValidators("<%=rfvStateB.ClientID%>");
            disableValidators("<%=RFVPinB.ClientID%>");
            disableValidators("<%=rfvCountryB.ClientID%>");
            
            disableValidators("<%=RFVAddrP1.ClientID%>");
            disableValidators("<%=RFVAddrP2.ClientID%>");
            disableValidators("<%=RFVAddrP3.ClientID%>");
            disableValidators("<%=rfvStateP.ClientID%>");
            disableValidators("<%=RFVPinP.ClientID%>");
            disableValidators("<%=rfvCountryP.ClientID%>");  
        }
    }
        
    function CheckAddress(src, args)
    {
        var result = true;
        var address = document.getElementById("<%=hdnCnctType.ClientID%>").value.split(",");
        var GCN = document.getElementById("<%=txtGCN.ClientID%>").value.split(",");
        var ddl = document.getElementById("<%=cboCnctType.ClientID%>");
        
        if (ddl.value == "P1")
        {
            var ddd = document.getElementById("<%=txtAddrP1.ClientID%>").value;
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "*";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = ""; 
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = ""; 
            
            disableValidators("<%=RFVAddrB1.ClientID%>");
            disableValidators("<%=RFVAddrB2.ClientID%>");
            disableValidators("<%=RFVAddrB3.ClientID%>");
            disableValidators("<%=rfvStateB.ClientID%>");
            disableValidators("<%=RFVPinB.ClientID%>");
            disableValidators("<%=rfvCountryB.ClientID%>");
            
            enableValidators("<%=RFVAddrP1.ClientID%>");
            enableValidators("<%=RFVAddrP2.ClientID%>");
            enableValidators("<%=RFVAddrP3.ClientID%>");
            enableValidators("<%=rfvStateP.ClientID%>");
            enableValidators("<%=RFVPinP.ClientID%>");
            enableValidators("<%=rfvCountryP.ClientID%>");
        }        
        else if (ddl.value == "B1")           
        {
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "*";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "*";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = "*";  
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = "*";  
            
            enableValidators("<%=RFVAddrB1.ClientID%>");
            enableValidators("<%=RFVAddrB2.ClientID%>");
            enableValidators("<%=RFVAddrB3.ClientID%>");
            enableValidators("<%=rfvStateB.ClientID%>");
            enableValidators("<%=RFVPinB.ClientID%>");
            enableValidators("<%=rfvCountryB.ClientID%>");
            
            disableValidators("<%=RFVAddrP1.ClientID%>");
            disableValidators("<%=RFVAddrP2.ClientID%>");
            disableValidators("<%=RFVAddrP3.ClientID%>");
            disableValidators("<%=rfvStateP.ClientID%>");
            disableValidators("<%=RFVPinP.ClientID%>");
            disableValidators("<%=rfvCountryP.ClientID%>");              
        }
        else
        {
            document.getElementById("<%=lblEstP3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP5.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstP6.ClientID%>").innerText = "";
            
            document.getElementById("<%=lblEstB1.ClientID%>").innerText = "";   
            document.getElementById("<%=lblEstB3.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB4.ClientID%>").innerText = "";
            document.getElementById("<%=lblEstB5.ClientID%>").innerText = "";  
            document.getElementById("<%=lblEstB6.ClientID%>").innerText = "";  
            
            disableValidators("<%=RFVAddrB1.ClientID%>");
            disableValidators("<%=RFVAddrB2.ClientID%>");
            disableValidators("<%=RFVAddrB3.ClientID%>");
            disableValidators("<%=rfvStateB.ClientID%>");
            disableValidators("<%=RFVPinB.ClientID%>");
            disableValidators("<%=rfvCountryB.ClientID%>");
            
            disableValidators("<%=RFVAddrP1.ClientID%>");
            disableValidators("<%=RFVAddrP2.ClientID%>");
            disableValidators("<%=RFVAddrP3.ClientID%>");
            disableValidators("<%=rfvStateP.ClientID%>");
            disableValidators("<%=RFVPinP.ClientID%>");
            disableValidators("<%=rfvCountryP.ClientID%>");  
        }
            
        if (GCN != "")
        {  
            for (i = 0; i < address.length; i++)
            {        
                var val = ("B" + (i + 2));
                var val2 = ("P" + (i + 2));
                
                if (val.length > 2)
                {
                    switch(val)
                    {
                        case("B10"):
                        val = "B0";
                    }
                }
                
                if (val2.length > 2)
                {
                    switch(val2)
                    {
                        case("P10"):
                        val2 = "P0";
                    }
                }  
                if(document.getElementById(address[i] + "_hdnAdd1") != null)
                {
                    if ((document.getElementById(address[i] + "_hdnAdd1").value == "") && ((ddl.value == val) || (ddl.value == val2)))
                    {                    
                        result = false;
                    }
                }             
            }          
        }   
        args.IsValid = result;
    }
    
    function SetFocus(controlID)
    { 
        document.getElementById("ctl00_ContentPlaceHolder1_cmdCancelM").enabled = true;  
        document.getElementById("ctl00_ContentPlaceHolder1_cmdCancelM").visible = true;
        document.getElementById("ctl00_ContentPlaceHolder1_cmdCancel").enabled = true;  
        document.getElementById("ctl00_ContentPlaceHolder1_cmdCancel").visible = true;
        displaySelectBoxes();
    }

    function displaySelectBoxes() {
	    for(var i = 0; i < document.forms.length; i++) {
		    for(var e = 0; e < document.forms[i].length; e++){
			    if(document.forms[i].elements[e].tagName == "SELECT") {
			    document.forms[i].elements[e].style.visibility="visible";
			    }
		    }
	    }
    }
    
    function CheckValidEmail(src, args) 
    {
        var result;
        var Email2 = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value.split(",");
        var Email = Email2[0];              
        result = ((Email.indexOf(".") > 2) && (Email.indexOf("@") > 0)); 
        args.IsValid = result;
    }

    function CheckHomeTelFormat(src, args)
    {
         var result = true;
         if (args.Value.length > 0)   
         {
             if (!IsNumeric(args.Value))
             {
                result = false;
             }
             args.Value = args.Value.substr(0,1)
             if (args.Value != "0")
             {
                 result = false;
             }
         }
         args.IsValid = result;
    }
    
    function CheckWorkTelFormat(src, args)
    {
         var result = true;
         var LocalTel = document.getElementById("<%=txtWorkTel.ClientID%>").value.split(",");
         strLocalTel = new String(LocalTel)
         if (strLocalTel.length > 0)   
         {
             if (!IsNumeric(strLocalTel))
             {
                result = false;
             }
             strLocalTel = strLocalTel.substr(0,1)
             if (strLocalTel != "0")
             {
                 result = false;
             }
         }
         args.IsValid = result;
    }
    
    function CheckMobileTelFormat(src, args)
    {
         var result = true;
         var strTel = document.getElementById("<%=txtMobileTel.ClientID%>").value;
         if (IsNumeric(strTel))
         {
            
         }
         else
         {
            result = false;
         }
         if(strTel=="09999999999" || strTel=="9999999999" || strTel=="99999999999")
         {
            result=false;
         }
         args.IsValid = result;
    }

    function IsAlphabet(sText)
    {
        var ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var IsAlphabet=true;
        var Char;
        for (i = 0; i < sText.length && IsAlphabet == true; i++) 
        { 
            Char = sText.charAt(i); 
            if (ValidChars.indexOf(Char) == -1) 
            {
                IsAlphabet = false;
            }
        }
        return IsAlphabet;  
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
    
    function CheckPANFormat(src, args)
    {
        var result = true;
        var pan = document.getElementById("<%=txtCurrentID.ClientID%>").value.split(",");
        var Char;
        var pan2 = pan[0]
        if (pan2 != "")
        { 
            if (pan2.length == 10)
            {
                for (j = 0; j < pan2.length && result == true; j++) 
                {                         
                   Char = pan2.substring(j, j+1);  
                   if (j==0 || j==1 || j==2 || j==3 || j==4 || j==9)                       
                   {     
                        if (!isAlphabet(Char)) 
                        {
                            result = false;
                        }           
                   }
                   if (j==5 || j==6 || j==7 || j==8)          
                   {                            
                        if (!IsNumeric(Char)) 
                        {
                            result = false;
                        }                                           
                    }
                }     
            } 
            else
            {
                result = false;
            }
        }     
        args.IsValid = result;        
    }
    
    function isAlphabet(strText) 
    {
        var inputStr = strText
        for (var intCounter = 0; intCounter < inputStr.length; intCounter++) 
        {
            var oneChar = inputStr.substring(intCounter, intCounter + 1)
            
            if (oneChar.toUpperCase() < "A" || oneChar.toUpperCase() > "Z") 
            {
                return false
                /*If Input Parameter is not Alphabet return false to Parent function*/
            }
        }
        return true
     }
    
    function popNational(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopNational.aspx?Code=" + doEncodeToPopup(sCode) + "&Desc=" + doEncodeToPopup(sDesc) + "&Field1=" + doEncodeToPopup(oCode) +
                    "&Field2=" + doEncodeToPopup(oDesc), 500, 350, null);
    }      
    
    function popOccupation(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopOccupation.aspx?Code=" + doEncodeToPopup(sCode) +  "&Desc=" + doEncodeToPopup(sDesc) + "&Field1=" + doEncodeToPopup(oCode) +
                    "&Field2=" + doEncodeToPopup(oDesc), 500, 350, null);
    }
    
    function popSearchClt(oGCN, oSurname, oGivenName, oGender, oDOB, oOthersID, oOtherIDType, sGCN, sSurname, sGivenName, sGender, sDOB, sOthersID, sOtherIDType)
    {             
       showPopWin("PopSearchClt.aspx?GCN=" + doEncodeToPopup(sGCN) + "&Surname=" + doEncodeToPopup(sSurname) + "&GivenName=" + doEncodeToPopup(sGivenName) +
                    "&Gender=" + doEncodeToPopup(sGender) + "&DOB=" + doEncodeToPopup(sDOB) + "&OthersID=" + doEncodeToPopup(sOthersID) +
                    "&OtherIDType=" + doEncodeToPopup(sOtherIDType) + "&Field1=" + doEncodeToPopup(oGCN) + "&Field2=" + doEncodeToPopup(oSurname) +
                    "&Field3=" + doEncodeToPopup(oGivenName) + "&Field4=" + doEncodeToPopup(oGender) + "&Field5=" + doEncodeToPopup(oDOB) +"&Field6=" + doEncodeToPopup(oOthersID) +
                    "&Field7=" + doEncodeToPopup(oOtherIDType), 500, 350, null);  
    }   
   
    function SurnametoProperCase(s)
    {
        document.getElementById("<%=txtSurname.ClientID%>").value = toProperCase(s);    
    }
    
    function GivenNametoProperCase(s)
    {
        document.getElementById("<%=txtGivenName.ClientID%>").value = toProperCase(s);    
    }
    
    function toProperCase(s)
    {
        return s.toLowerCase().replace(/^(.)|\s(.)/g, function($1) { return $1.toUpperCase(); })
    }
    
    function popStateP(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopState.aspx?Code=" + sCode + "&Desc=" + sDesc + "&Field1=" + oCode + "&Field2=" + oDesc, 500, 350, null);
    }
    // For District Purpose 13/05/2013 start
    function PersPopDistrict(strhdnDist,dDesc,strStateCode,strDist,strhdnPinFrom,strhdnPinTo)
    {
        var vDist = document.getElementById('<%=txtDistric.ClientID %>').value;
        if(document.getElementById('<%=txtStateCode.ClientID %>').value=="")
        {
            alert("Please enter State Code");
            document.getElementById('<%= txtStateCode.ClientID %>').focus();
            return false;
        }
        showPopWin("../../Application/Common/PopDistrict.aspx?strHDist=" + strhdnDist + "&DistDesc=" + dDesc + "&StateCode=" 
            + strStateCode + "&txtDisc=" + strDist + "&shdnPinFrom=" + strhdnPinFrom + "&shdnPinTo=" + strhdnPinTo,500, 350, null);
    }

    function ResPopDistrict(strhdnDist,dDesc,strStateCode,strDist,strhdnPinFrom,strhdnPinTo)
    {
        var vDist = document.getElementById('<%=txtDistricP.ClientID %>').value;
        if(document.getElementById('<%=txtStateCodeP.ClientID %>').value=="")
        {
            alert("Please enter State Code");
            document.getElementById('<%= txtStateCodeP.ClientID %>').focus();
            return false;
        }
        showPopWin("../../Application/Common/PopDistrict.aspx?strHDist=" + strhdnDist + "&DistDesc=" + dDesc + "&StateCode=" 
            + strStateCode + "&txtDisc=" + strDist + "&shdnPinFrom=" + strhdnPinFrom + "&shdnPinTo=" + strhdnPinTo,500, 350, null);
    }

    function PopDistrict(strhdnDist,dDesc,strStateCode,strDist,strhdnPinFrom,strhdnPinTo)
    {
       var vDist = document.getElementById('<%=txtDistrictB.ClientID %>').value;
        if(document.getElementById('<%=txtStateCodeB.ClientID %>').value=="")
        {
            alert("Please enter State Code");
            document.getElementById('<%= txtStateCodeB.ClientID %>').focus();
            return false;
        }
        showPopWin("../../Application/Common/PopDistrict.aspx?strHDist=" + strhdnDist + "&DistDesc=" + dDesc + "&StateCode=" 
            + strStateCode + "&txtDisc=" + strDist + "&shdnPinFrom=" + strhdnPinFrom + "&shdnPinTo=" + strhdnPinTo,500, 350, null);
    }
    // For District Purpose 13/05/2013 end
    function popCountryP(oCode, oDesc, sCode, sDesc)
    {
        showPopWin("PopCountry.aspx?Code=" + sCode + "&Desc=" + sDesc + "&Field1=" + oCode + "&Field2=" + oDesc, 500, 350, null);
    }

    function CheckStateListP(src, args)
    {
        var result = true;
        var StateCode = document.getElementById("<%=txtStateCodeP.ClientID%>").value.split(",");
        var StateDesc = document.getElementById("<%=txtStateDescP.ClientID%>").value.split(",");
        if ((StateCode != "") && (StateDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function CheckCountryListP(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCodeP.ClientID%>").value.split(",");
        var CountryDesc = document.getElementById("<%=txtCountryDescP.ClientID%>").value.split(",");   
        if ((CountryCode != "") && (CountryDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function CheckPINP(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCodeP.ClientID%>").value;
        var Pin = document.getElementById("<%=txtPinP.ClientID%>").value;
        if (CountryCode.toUpperCase() == "IND")
        {            
            if (!IsNumeric(Pin) || (Pin.length != 6)) 
            {                
                result = false;
            }
        }              
        else
        {
            if (Pin.length > 8)
            {
                result = false;
            }
        }
        args.IsValid = result;
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
    
    function CheckPIN(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCode.ClientID%>").value;
        var Pin = document.getElementById("<%=txtPostcode.ClientID%>").value;
        if (CountryCode.toUpperCase() == "IND")
        {            
            if (!IsNumeric(Pin) || (Pin.length != 6)) 
            {                
                result = false;
            }
        }              
        else
        {
            if (Pin.length > 8)
            {
                result = false;
            }
        }
        args.IsValid = result;
    }   
    
    function CheckStateListB(src, args)
    {
        var result = true;
        var StateCode = document.getElementById("<%=txtStateCodeB.ClientID%>").value.split(",");
        var StateDesc = document.getElementById("<%=txtStateDescB.ClientID%>").value.split(",");
        if ((StateCode != "") && (StateDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function CheckCountryListB(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCodeB.ClientID%>").value.split(",");
        var CountryDesc = document.getElementById("<%=txtCountryDescB.ClientID%>").value.split(",");
        if ((CountryCode != "") && (CountryDesc == ""))
        {            
            result = false;           
        }    
        args.IsValid = result;
    }
    
    function CheckPINB(src, args)
    {
        var result = true;
        var CountryCode = document.getElementById("<%=txtCountryCodeB.ClientID%>").value;
        var Pin = document.getElementById("<%=txtPinB.ClientID%>").value;
        if (CountryCode.toUpperCase() == "IND")
        {            
            if (!IsNumeric(Pin) || (Pin.length != 6)) 
            {                
                result = false;
            }
        }              
        else
        {
            if (Pin.length > 8)
            {
                result = false;
            }
        }
        args.IsValid = result;
    }   
    
    </script>

    <div style="text-align: center">
        <table class="container" width="650px">
            <tr>
                <td>
                    <div id="div1">
                        <asp:Panel ID="PanelMain" runat="server">
                            <asp:ScriptManager runat="server" ID="SM"><scripts>
                                <asp:ScriptReference Path="Lookup.js" /></scripts>
                                <services>
                                    <asp:ServiceReference  Path="Lookup.asmx" />
                                </services>
                            </asp:ScriptManager>
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
                                                                <asp:UpdatePanel ID="UpdPanelHeader" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                                    <contenttemplate>
                                                                        &nbsp;<asp:Label ID="lblHeader" runat="server" ></asp:Label>
                                                                    </contenttemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td align="right" style="width: 182px">
                                                                CLTPRS V1.3
                                                            </td>
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
                                                    <span></span>
                                                    <asp:Button ID="btnPostback" runat="server" Visible="true" Width="0" OnClick="RetrievePopClt"
                                                        CausesValidation="false" /><asp:Label ID="lblCusID" runat="server"></asp:Label>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelGCN" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:TextBox id="txtGCN" runat="server" CssClass="standardtextbox" Enabled="false" MaxLength="12"></asp:TextBox> 
                                                            <asp:TextBox style="TEXT-ALIGN: center" id="txtCltStat" runat="server" Width="47px" BorderStyle="None" 
                                                            BorderColor="Transparent">Active</asp:TextBox> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel></td>
                                                <td class="formcontent"  colspan="1">
                                                    <span></span>
                                                    <asp:Label ID="lblCode" runat="server"  Width="95%"></asp:Label>
                                                </td>
                                                <td class="formcontent" >
                                                    <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
															<asp:TextBox id="txtCltCode" runat="server" CssClass="standardtextbox" MaxLength="12"></asp:TextBox>&nbsp; 
														</contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <span style="color: red"></span>
                                                    <asp:Label ID="lblName" runat="server" style="color: black"></asp:Label>&nbsp; 
                                                    <span style="color:Red;"></span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelGivenNm" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="cboTitle" runat="server" CssClass="standardmenu" __designer:wfdid="w5"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator id="rfvTitle" runat="server" SetFocusOnError="True" ErrorMessage="Mandatory!" 
                                                            Display="Dynamic" ControlToValidate="cboTitle" __designer:wfdid="w6"></asp:RequiredFieldValidator>
                                                            <asp:TextBox id="txtGivenName" runat="server" CssClass="standardtextbox" MaxLength="30" Width="125px"></asp:TextBox> 
                                                            <asp:RegularExpressionValidator id="revGivenName" runat="server" Enabled="False" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtGivenName" 
                                                            ValidationExpression="[\w\s]*[^_1234567890]" __designer:wfdid="w4"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator id="ctvGivenName" runat="server" __designer:dtid="281474976710790" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtGivenName" 
                                                            ClientValidationFunction="doValidateName" __designer:wfdid="w1"></asp:CustomValidator> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:HiddenField ID="hdnGenderTitle1" runat="server" />
                                                    <asp:HiddenField ID="hdnGenderTitle2" runat="server" />
                                                </td>
                                                <td class="formcontent" >
                                                    <span><font color="Red"><asp:Label ID="lblSurName" runat="server" style="color: black"></asp:Label>*</font></span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelname" runat="server" RenderMode="Inline">
                                                        <contenttemplate>
                                                            <asp:TextBox id="txtname" runat="server" CssClass="standardtextbox" MaxLength="30" __designer:wfdid="w2"></asp:TextBox>
                                                            <asp:RequiredFieldValidator id="RFVName" runat="server" Enabled="true" ErrorMessage="Mandatory!" Display="Dynamic" 
                                                            ControlToValidate="txtname" __designer:wfdid="w3"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator id="revSurname" runat="server" Enabled="False" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtname" ValidationExpression="[\w\s]*" 
                                                            __designer:wfdid="w4"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator id="ctvName" runat="server" __designer:dtid="281474976710790" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtname" 
                                                            ClientValidationFunction="doValidateName" __designer:wfdid="w5"></asp:CustomValidator> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="230">
                                                    <asp:Label ID="lblChannel" runat="server"></asp:Label>
                                                    <span style="color: Red">*</span>
                                                </td>
                                                <td class="formcontent" width="230">
                                                    <asp:DropDownList ID="ddlChannels" runat="server" CssClass="standardmenu" autopostback="true"
                                                    OnSelectedIndexChanged="ddlChannels_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="CD">CDA Franchise</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlchannels" runat="server" SetFocusOnError="true"
                                                        ErrorMessage="Mandatory!" Enabled="true" Display="Dynamic" ControlToValidate="ddlChannels"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent">
                                                    <asp:Label ID="lbldob" runat="server" ></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" >
                                                    <uc7:ctlDate ID="txtDOB" runat="server" CssClass="standardtextbox"
                                                        RequiredField="true" RequiredValidationMessage="Mandatory!"/>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:Label ID="lblFname" runat="server" ></asp:Label>    
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelSurname" runat="server" RenderMode="Inline">
                                                        <contenttemplate>
                                                            <asp:TextBox id="txtSurname" runat="server" CssClass="standardtextbox" MaxLength="60" __designer:wfdid="w10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator id="RFVnme" runat="server" Enabled="true" ErrorMessage="Mandatory!" Display="Dynamic" 
                                                            ControlToValidate="txtSurname" __designer:wfdid="w11"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator id="revname" runat="server" Enabled="False" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtSurname" ValidationExpression="[\w\s]*" 
                                                            __designer:wfdid="w12"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator id="ctvFatherName" runat="server" __designer:dtid="281474976710790" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid characters!" Display="Dynamic" ControlToValidate="txtSurname" 
                                                            ClientValidationFunction="doValidateName" __designer:wfdid="w13"></asp:CustomValidator> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                  </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblPAN" runat="server" ></asp:Label>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelCurrentID" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:TextBox id="txtCurrentID" runat="server" CssClass="standardtextbox" 
                                                            onChange="javascript:this.value=this.value.toUpperCase();" MaxLength="10" __designer:wfdid="w22"></asp:TextBox>
                                                            <input id="txtCurrentIDType" type="hidden" value="P" /> 
                                                            <asp:RequiredFieldValidator id="rfvCurrentID" runat="server" Enabled="false" SetFocusOnError="True" 
                                                            ErrorMessage="Mandatory!" Display="Dynamic" ControlToValidate="txtCurrentID" __designer:wfdid="w23"></asp:RequiredFieldValidator> 
                                                            <asp:CustomValidator id="ctvCurrentID" runat="server" SetFocusOnError="True" ErrorMessage="Invalid PAN format!" 
                                                            Display="Dynamic" ControlToValidate="txtCurrentID" ClientValidationFunction="CheckPANFormat" 
                                                            __designer:wfdid="w24"></asp:CustomValidator> 
                                                            <asp:Button ID="btnVerifyPAN" runat="server"  Text="Verify" Enabled="false" CssClass="standardbutton"
                                                                       OnClick="btnVerifyPAN_Click" ValidationGroup="RecruitInfo"></asp:Button>
                                                            <div id="divPAN" class="Content" style="display: none">
                                                                <img alt="" src="../../../App_Themes/Isys/images/spinner.gif" /> Loading...
                                                            </div>
                                                            <br />
                                                            <asp:Label ID="lblPANMsg" runat="server" Style="color: #ff0000" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" >
                                                    Client Create Rule
                                                </td>
                                                <td class="formcontent">
                                                    <asp:DropDownList ID="ddlCltCreateRule" runat="server" CssClass="standardmenu"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelGender" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="cboGender" class="standardmenu" runat="server" CssClass="standardmenu" __designer:wfdid="w06"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator id="rfvGender" runat="server" SetFocusOnError="True" ErrorMessage="Mandatory!" 
                                                            Display="Dynamic" ControlToValidate="cboGender" __designer:wfdid="w06"></asp:RequiredFieldValidator>
                                                            <asp:CustomValidator id="ctvGender" runat="server" __designer:dtid="2814762652008448" SetFocusOnError="True" 
                                                            ErrorMessage="Invalid &#13;&#10;/Title!" ControlToValidate="cboGender" ClientValidationFunction="doValidate" 
                                                            __designer:wfdid="w26"></asp:CustomValidator> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" >
                                                    <span><font color="Red">
                                                        <asp:Label ID="lblspIndicator" runat="server" style="color: black"></asp:Label></font></span></td>
                                                <td class="formcontent">
                                                    <asp:DropDownList CssClass="standardmenu" ID="ddlSpecInd" runat="server" /><br />
                                                    <asp:AsyncPostBackTrigger ControlID="gvLookup1" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <span><font color="Red"><asp:Label ID="lblAltIDType" runat="server" style="color: black"></asp:Label></font></span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelOtherIDType" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <uc3:ddlSelectedLookup id="cboOtherIDType" runat="server" RequiredField="false" CssClass="standardmenu" 
                                                            LookupCode="NBSIDKey" __designer:wfdid="w2" Exprs="paramValue not in (''P'')"></uc3:ddlSelectedLookup> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblMstatus" runat="server"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelMarital" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <uc4:ddlLookup id="cboMaritalStatus" runat="server" RequiredField="true" CssClass="standardmenu" LookupCode="MarrySts" 
                                                            __designer:wfdid="w55" ValidationError="Mandatory!"></uc4:ddlLookup> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                  <span> <asp:Label ID="lblAltIDNo" runat="server"></asp:Label></span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelOtherID" runat="server" RenderMode="Inline">
                                                        <contenttemplate>
                                                            <asp:TextBox id="txtOthersID" runat="server" CssClass="standardtextbox" MaxLength="10" __designer:wfdid="w6" ></asp:TextBox> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:Button ID="btnSearchClt" runat="server" CausesValidation="False" Visible="true"
                                                        CssClass="standardbutton" Text="FIND" OnClick="btnSearchClt_Click" />
                                                </td>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblSOE" runat="server"></asp:Label>
                                                    <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:DropDownList ID="ddlSOE" runat="server" CssClass="standardmenu"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator id="rfvSOE" runat="server" SetFocusOnError="True" ErrorMessage="Mandatory!" Display="Dynamic" 
                                                    ControlToValidate="ddlSOE"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" >
                                                    <span>
                                                        <asp:Label ID="lblNationality" runat="server"></asp:Label><span style="color: #ff0000">
                                                        </span><font color="Red">*</font>
                                                    </span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:TextBox ID="txtNationalCode" runat="server" CssClass="standardtextbox" onChange="javascript:this.value=this.value.toUpperCase();" Width="42px"></asp:TextBox>
                                                    <asp:TextBox CssClass="standardtextbox" Enabled="true" ID="txtNationalDesc" onChange="javascript:this.value=this.value.toUpperCase();" runat="server" Width="86px"></asp:TextBox><asp:Button CausesValidation="False" CssClass="standardbutton" ID="btnNational" runat="server" Text="..." OnClick="btnNational_Click" Width="32px" /><asp:RequiredFieldValidator ControlToValidate="txtNationalDesc" Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" ID="rfvNationalCode" runat="server" SetFocusOnError="True" />
                                                    <br />
                                                </td>
                                                <td class="formcontent" >
                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                    <span style="color: #ff0000">*</span></td>
                                                <td class="formcontent">
                                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="standardmenu">
                                                    </asp:DropDownList>
													<asp:RequiredFieldValidator id="rfvCategory" runat="server" SetFocusOnError="True" ErrorMessage="Mandatory!" Display="Dynamic" 
                                                    ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap" >
                                                    <span>
                                                        <asp:Label ID="lblHigestQul" runat="server">
														<asp:Label ID="lblmandatory" runat="server" style="color: #ff0000" text="*"></asp:Label></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelQualCode" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <uc4:ddlLookup id="cboQualCode" runat="server" RequiredField="false" CssClass="standardmenu" LookupCode="NBEduQua" 
                                                            ValidationError="Mandatory!"></uc4:ddlLookup> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td class="formcontent" nowrap="">
                                                    <span>
                                                        <asp:Label ID="lblCorrAdd" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent">
                                                    <asp:UpdatePanel ID="UpdPanelCtType" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:DropDownList id="cboCnctType" runat="server" CssClass="standardmenu" AppendDataBoundItems="true" 
                                                            DataValueField="ParamValue" DataTextField="ParamDesc" DataSourceID="dsCnctType"></asp:DropDownList> 
                                                            <INPUT id="hdnCnctType" type=hidden runat="server" __designer:dtid="281474976710808" /> 
                                                            <asp:SqlDataSource id="dsCnctType" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource> 
                                                            <asp:RequiredFieldValidator id="rfvCnctType" runat="server" Enabled="false" SetFocusOnError="true" 
                                                            ErrorMessage="Mandatory!" Display="None" ControlToValidate="cboCnctType"></asp:RequiredFieldValidator> 
                                                            <asp:CustomValidator id="ctvCnctType" runat="server" SetFocusOnError="True" ErrorMessage="Invalid address!" 
                                                            Display="Dynamic" ControlToValidate="cboCnctType" ClientValidationFunction="CheckAddress"></asp:CustomValidator> 
                                                            <ajaxToolkit:ValidatorCalloutExtender id="vceCnctType" runat="server" TargetControlID="rfvCnctType"></ajaxToolkit:ValidatorCalloutExtender> 
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" nowrap="nowrap">
                                                    <asp:Label ID="lblInceptiondate" runat="server"></asp:Label>
                                                </td>
                                                <td class="formcontent">
                                                    <uc7:ctlDate ID="txtIndate" runat="server" CssClass="standardtextbox" RequiredField="false"
                                                        RequiredValidationMessage="Date is required" Visible="true" />
                                                </td>
                                                <td class="formcontent" nowrap="nowrap">
                                                </td>
                                                <td class="formcontent">
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Residential Address --------------------------------------------->
                                        <table class="container" width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="4" style="text-align: left;" class="test">
                                                    &nbsp;<asp:Label ID="lblAPHeadear" runat="server" Font-Size="10pt"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 440px" valign="top">
                                                    <table class="formtable" >        
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:145px" >
                                                                <asp:Label ID="lblAddrP1" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP6" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrP1" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="ctvAddrP1" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP1" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator><br />
                                                                <asp:RequiredFieldValidator ID="RFVAddrP1" runat="server" ControlToValidate="txtAddrP1"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrP2" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrP2" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="ctvAddrP2" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP2" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RFVAddrP2" runat="server" ControlToValidate="txtAddrP2"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrP3" runat="server"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrP3" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="ctvAddrP3" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP3" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RFVAddrP3" runat="server" ControlToValidate="txtAddrP3"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:Label ID="lblAddrP4" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrP4" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30" Visible="False"></asp:TextBox>
                                                                <asp:CustomValidator ID="ctvAddrP4" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrP4" Display="Dynamic" ErrorMessage="Invalid Address!"
                                                                    Visible="False"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2" valign="top" style="width: 425px">
                                                    <table cellspacing="1" class="formtable" width="100%">
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:175px">
                                                                <asp:Label ID="lblStateP" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox ID="txtStateCodeP" runat="server" Width="50px"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();" CssClass="standardtextbox"></asp:TextBox>
                                                                <asp:TextBox ID="txtStateDescP" runat="server" CssClass="standardtextbox" Width="130px"></asp:TextBox>
                                                                <asp:Button ID="btnStateP" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..." />
                                                                <asp:RequiredFieldValidator ID="rfvStateP" runat="server" ControlToValidate="txtStateDescP"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvStateP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCodeP"
                                                                    ClientValidationFunction="CheckStateListP"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvStateDescP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDescP"
                                                                    ClientValidationFunction="CheckStateListP"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;"> 
                                                                <asp:Label ID="Label2" runat="server" ></asp:Label>
                                                            </td>
                                                            <td class="formcontent" style="width: 30%;">
                                                                <asp:TextBox ID="txtDistricP" ReadOnly="false"  runat="server" Font-Bold="False" CssClass="standardtextbox" 
                                                                MaxLength="50" ></asp:TextBox> 
                                                                <asp:Button ID="btnDistP" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..."  />
                                                                <asp:HiddenField ID="hdnDistP" runat="server" />
                                                                <asp:HiddenField ID="hdnPinFromP" runat="server" />
                                                                <asp:HiddenField ID="hdnPinToP" runat="server" />                                                    
                                                            </td> 
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblPinP" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox Width="60px" ID="txtPinP" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="8"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVPinP" runat="server" ControlToValidate="txtPinP"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="CVPinP" runat="server" Enabled="true" ErrorMessage="Invalid Pin!"
                                                                    Display="Dynamic" ControlToValidate="txtPinP" ClientValidationFunction="CheckPINP"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px" >
                                                                <asp:Label ID="lblCountryP" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstP5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox ID="txtCountryCodeP" runat="server" CssClass="standardtextbox" Width="50px"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                                <asp:TextBox ID="txtCountryDescP" runat="server" CssClass="standardtextbox" Width="130px" Enabled="false"></asp:TextBox>
                                                                <asp:Button ID="btnCountryP" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..." />
                                                                <asp:RequiredFieldValidator ID="rfvCountryP" runat="server" ControlToValidate="txtCountryDescP"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvCountryCodeP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCodeP"
                                                                    ClientValidationFunction="CheckCountryListP"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvCountryDescP" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDescP"
                                                                    ClientValidationFunction="CheckCountryListP"></asp:CustomValidator>
                                                            </td>
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
                                            <tr>
                                                <td colspan="4" style="text-align: left;" class="test">
                                                    &nbsp;<asp:Label ID="lblABHeadear" runat="server" Font-Size="10pt"></asp:Label>
                                                    <asp:Label ID="lblEstB6" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td colspan="2" style="width: 440px" valign="top">
                                                    <table class="formtable" >
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:145px" >
                                                                <asp:Label ID="lblAddrB1" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstB1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrB1" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrB1" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator><br />
                                                                <asp:RequiredFieldValidator ID="RFVAddrB1" runat="server" ControlToValidate="txtAddrB1"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:Label ID="lblAddrB2" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrB2" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrB2" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RFVAddrB2" runat="server" ControlToValidate="txtAddrB2"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent"  >
                                                                <asp:Label ID="lblAddrB3" runat="server"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox  ID="txtAddrB3" runat="server" Font-Bold="False" CssClass="standardtextbox" MaxLength="30"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrB3" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
                                                                <asp:RequiredFieldValidator ID="RFVAddrB3" runat="server" ControlToValidate="txtAddrB3"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:Label ID="lblAddrB4" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox  ID="txtAddrB4" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="30" Visible="False"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator7" runat="server" ClientValidationFunction="doValidateAddress"
                                                                    ControlToValidate="txtAddrB4" Display="Dynamic" ErrorMessage="Invalid Address!"
                                                                    Visible="False"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2" style="width: 425px" valign="top">
                                                    <table cellspacing="1" class="formtable" width="100%">
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" style="width:175px">
                                                                <asp:Label ID="lblStateB" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstB3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox ID="txtStateCodeB" runat="server" CssClass="standardtextbox" Width="50px"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                                <asp:TextBox ID="txtStateDescB" runat="server" CssClass="standardtextbox" Width="130px" Enabled="true"></asp:TextBox>
                                                                <asp:Button ID="btnStateB" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..." Width="20px" />
                                                                <asp:RequiredFieldValidator ID="rfvStateB" runat="server" ControlToValidate="txtStateDescB"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvStateB" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCodeB"
                                                                    ClientValidationFunction="CheckStateListB"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvStateDescB" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDescB"
                                                                    ClientValidationFunction="CheckStateListB"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                        <td class="formcontent" nowrap="nowrap" style="width: 20%;"> 
                                                            <asp:Label ID="Label3" runat="server" ></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="width: 30%;">
                                                            <asp:TextBox ID="txtDistrictB" ReadOnly="false"  runat="server" Font-Bold="False" CssClass="standardtextbox" 
                                                            MaxLength="50" ></asp:TextBox> 
                                                            <asp:Button ID="btnDistrictB" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..."  />
                                                            <asp:HiddenField ID="hdnDistB" runat="server" />
                                                            <asp:HiddenField ID="hdnPinFromB" runat="server" />
                                                            <asp:HiddenField ID="hdnPinToB" runat="server" />                                                    
                                                        </td> 
                                                        </tr> 
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px" >
                                                                <asp:Label ID="lblPinB" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstB4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent" >
                                                                <asp:TextBox Width="60px" ID="txtPinB" runat="server" Font-Bold="False" CssClass="standardtextbox"
                                                                    MaxLength="8"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RFVPinB" runat="server" ControlToValidate="txtPinB"
                                                                    Enabled="true" Display="Dynamic" ErrorMessage="Mandatory!"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="CVPinB" runat="server" Enabled="true" ErrorMessage="Invalid Pin!"
                                                                    Display="Dynamic" ControlToValidate="txtPinB" ClientValidationFunction="CheckPINB"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" class="formcontent" width="150px">
                                                                <asp:Label ID="lblCountryB" runat="server"></asp:Label>
                                                                <asp:Label ID="lblEstB5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" class="formcontent">
                                                                <asp:TextBox ID="txtCountryCodeB" runat="server" CssClass="standardtextbox" Width="50px"
                                                                    onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                                <asp:TextBox ID="txtCountryDescB" runat="server" CssClass="standardtextbox" Width="130px"
                                                                    Enabled="false"></asp:TextBox>
                                                                <asp:Button ID="btnCountryB" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                                    Text="..." Width="20px" />
                                                                <asp:RequiredFieldValidator ID="rfvCountryB" runat="server" ControlToValidate="txtCountryDescB"
                                                                    Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="ctvCountryCodeB" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCodeB"
                                                                    ClientValidationFunction="CheckCountryListB"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="ctvCountryDescB" runat="server" SetFocusOnError="True" Enabled="false"
                                                                    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDescB"
                                                                    ClientValidationFunction="CheckCountryListB"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--------------------------------------- Businees Multiple Address --------------------------------------------->
                                        <table style="font-size: 8pt;" border="0" cellpadding="3" cellspacing="1" width="790" align="center">
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
                                                    <span style="color: #ff0000">*</span>&nbsp;
												    <asp:CheckBox ID="ChkPA" runat="server" />                                                                                             
                                                </td>
                                            </tr>
                                            <tr id="trPermAdd1" runat="server">
											    <td colspan="2" valign="top" style="width:40%">
												    <table class="formtable" width="100%">
													    <tr style="width:100px">
														    <td class="formcontent" id="lblTitle" style="width: 140px">Address<span style="color: #ff0000">*</span></td>
														    <td class="formcontent" nowrap="nowrap">
															    <asp:TextBox CssClass="standardtextbox" ID="txtAdd1" runat="server" Width="160px" MaxLength="30"></asp:TextBox>
															    <asp:CustomValidator ID="ctvAdd1" runat="server" ClientValidationFunction="doValidateAddress"
																    ControlToValidate="txtAdd1" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator><br />
															    <asp:RequiredFieldValidator ID="rfvAdd1" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtAdd1" Display="Dynamic"></asp:RequiredFieldValidator>
														    </td>
													    </tr>
													    <tr id="trPermAdd2" runat="server">
														    <td class="formcontent"></td>
														    <td class="formcontent">
															    <asp:TextBox CssClass="standardtextbox" ID="txtAdd2" runat="server" Width="160px" MaxLength="30"></asp:TextBox>
															    <asp:RequiredFieldValidator ID="rfvAdd2" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtAdd2" Display="Dynamic"></asp:RequiredFieldValidator>
															     <asp:CustomValidator ID="ctvAdd2" runat="server" ClientValidationFunction="doValidateAddress"
																    ControlToValidate="txtAdd2" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
														    </td>
													    </tr>
													    <tr id="trPermAdd3" runat="server">
														    <td class="formcontent"></td>
														    <td class="formcontent">
															    <asp:TextBox CssClass="standardtextbox" ID="txtAdd3" runat="server" Width="160px" MaxLength="30" ></asp:TextBox>
															    <asp:RequiredFieldValidator ID="rfvAdd3" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtAdd3" Display="Dynamic"></asp:RequiredFieldValidator>
															    <asp:CustomValidator ID="ctvAdd3" runat="server" ClientValidationFunction="doValidateAddress"
																    ControlToValidate="txtAdd3" Display="Dynamic" ErrorMessage="Invalid Address!"></asp:CustomValidator>
														    </td>
													    </tr>
												    </table>
											    </td>
											    <td colspan="2" valign="top" style="width:40%">
												    <table class="formtable" width="100%">
													    <tr style="width:100%">
														    <td nowrap="nowrap" class="formcontent">
															    State<span style="color: #ff0000">*</span>
                                                            </td>
														    <td class="formcontent">
															    <asp:TextBox ID="txtStateCode" runat="server" Width="50px" 
                                                                onChange="javascript:this.value=this.value.toUpperCase();" CssClass="standardtextbox"></asp:TextBox>
															    <asp:TextBox ID="txtStateDesc" runat="server" CssClass="standardtextbox" Width="100px" Enabled="true"></asp:TextBox>
															    <asp:Button CssClass="standardbutton" ID="btnState" runat="server" Text="..." CausesValidation="False" Width="20px" />
															    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtStateCode" Display="Dynamic"></asp:RequiredFieldValidator>
															    <asp:CustomValidator ID="ctvStateCode" runat="server" SetFocusOnError="True" Enabled="false"
																	    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateCode"
																	    ClientValidationFunction="CheckStateList"></asp:CustomValidator>
															    <asp:CustomValidator ID="ctvStateDesc" runat="server" SetFocusOnError="True" Enabled="false"
																	    ErrorMessage="Invalid State Code!" Display="Dynamic" ControlToValidate="txtStateDesc"
																	    ClientValidationFunction="CheckStateList"></asp:CustomValidator>
														    </td>
													    </tr>
													    <tr>
                                                            <td class="formcontent" nowrap="nowrap" style="width: 20%;"> 
                                                                <asp:Label ID="Label4" runat="server" ></asp:Label>
                                                            </td>
                                                            <td class="formcontent" style="width: 30%;">
                                                                <asp:TextBox ID="txtDistric" ReadOnly="false"  runat="server" Font-Bold="False" CssClass="standardtextbox" 
                                                                MaxLength="50" ></asp:TextBox> 
                                                                <asp:Button ID="btnDistric" runat="server" CausesValidation="False" CssClass="standardbutton" Text="..."  />
                                                                <asp:HiddenField ID="hdnDist" runat="server" />
                                                                <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                                                <asp:HiddenField ID="hdnPinTo" runat="server" />                                                    
                                                            </td> 
                                                        </tr> 
													    <tr>
														    <td class="formcontent" style="width:150px" nowrap="nowrap">
															    PIN Code<span style="color: #ff0000">*</span>
                                                            </td>
														    <td class="formcontent" nowrap="nowrap">
															    <asp:TextBox CssClass="standardtextbox" ID="txtPostcode" runat="server" Width="60px" MaxLength="8"></asp:TextBox>
															    <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtPostcode" Display="Dynamic"></asp:RequiredFieldValidator>
															    <asp:CustomValidator ID="ctvPostcode" runat="server" Enabled="true" ErrorMessage="Invalid Pin!"
																    Display="Dynamic" ControlToValidate="txtPostcode" ClientValidationFunction="CheckPIN"></asp:CustomValidator>
														    </td>
													    </tr>
													    <tr>
														    <td nowrap="nowrap" class="formcontent" width="150px">Country<span style="color: #ff0000">*</span></td>
														    <td class="formcontent" nowrap="nowrap">
															    <asp:TextBox ID="txtCountryCode" runat="server" CssClass="standardtextbox" MaxLength="4" Width="50px" onChange="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox><asp:TextBox ID="txtCountryDesc" runat="server" CssClass="standardtextbox" Width="100px" Enabled="false" ></asp:TextBox><asp:Button CssClass="standardbutton" ID="btnCountry" runat="server" Text="..." CausesValidation="False" Width="20px"  />
															    <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="Mandatory!" SetFocusOnError="true" 
																    ControlToValidate="txtCountryCode" Display="Dynamic"></asp:RequiredFieldValidator>
															    <asp:CustomValidator ID="ctvCountryCode" runat="server" SetFocusOnError="True" Enabled="false"
																    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryCode"
																    ClientValidationFunction="CheckCountryList"></asp:CustomValidator>
															    <asp:CustomValidator ID="ctvCountryDesc" runat="server" SetFocusOnError="True" Enabled="false"
																    ErrorMessage="Invalid Country Code!" Display="Dynamic" ControlToValidate="txtCountryDesc"
																    ClientValidationFunction="CheckCountryList"></asp:CustomValidator>
														    </td>	                                        
													    </tr>
												    </table>
											    </td>
                                            </tr>
                                            <tr>
                                                <td class="test" width="100%" colspan="4">
                                                    <table class="container">
                                                        <tr>
                                                            <td width="20%">Contact Preferred</td>
                                                            <td width="30%">
                                                                <uc4:ddlLookup ID="ddlDstbnMethod" runat="server" CssClass="standardmenu" LookupCode="DstbnMtd" RequiredField="false" />
                                                            </td>
                                                            <td width="20%">Privacy</td>
                                                            <td width="30%">
                                                                <uc4:ddlLookup ID="ddlPrivacy" runat="server" CssClass="standardmenu" LookupCode="PrvcStat"
                                                                    RequiredField="false" ddliSysLParamEnabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">    
                                                        <asp:Label ID="lblHomeTel" runat="server"></asp:Label>
                                                        <span style="color: #ff0000">*</span>
                                                </td>
                                                <td class="formcontent" style="width: 20%">
                                                    <asp:TextBox ID="txtHomeTel" runat="server" Width="112px" MaxLength="12" CssClass="standardtextbox"></asp:TextBox>&nbsp;
                                                    <asp:CustomValidator ID="ctvHomeTel" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Tel No!"
                                                        Display="Dynamic" ControlToValidate="txtHomeTel" ClientValidationFunction="CheckHomeTelFormat"></asp:CustomValidator>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblOfficeTel" runat="server" Width="76px"></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <asp:TextBox ID="txtWorkTel" runat="server" Width="82px" MaxLength="12" CssClass="standardtextbox"></asp:TextBox>
                                                    <asp:CustomValidator ID="ctvWorkTel" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Tel No!"
                                                        Display="Dynamic" ControlToValidate="txtWorkTel" ClientValidationFunction="CheckWorkTelFormat"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">
                                                    <asp:Label ID="lblDIdNo" runat="server" Width="78px"></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 27%">
                                                    <asp:TextBox ID="txtDidtel" runat="server" Width="113px" CssClass="standardtextbox" ></asp:TextBox>&nbsp;
                                                    <asp:CustomValidator ID="CustomValidator8" runat="server" ClientValidationFunction="CheckHomeTelFormat"
                                                        ControlToValidate="txtDidtel" Display="Dynamic" ErrorMessage="Invalid Tel No!"
                                                        SetFocusOnError="True"></asp:CustomValidator>
                                                </td>
                                                <td class="formcontent" width="20%">
                                                    <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                    <span style="color: #ff0000">*</span></td>
                                                <td class="formcontent" width="30%">
                                                    <asp:TextBox ID="txtMobileTel" runat="server" Width="84px" MaxLength="15" CssClass="standardtextbox"></asp:TextBox>
                                                    <asp:CustomValidator ID="ctvMobileTel" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Tel No!"
                                                        Display="Dynamic" ControlToValidate="txtMobileTel" ClientValidationFunction="CheckMobileTelFormat"></asp:CustomValidator>
                                                        <asp:RequiredFieldValidator ID="rfvMobileTel" runat="server" ControlToValidate="txtMobileTel"
                                                        Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblEmail" runat="server" Width="44px"></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="standardtextbox" Width="114px"></asp:TextBox>&nbsp;
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                        Display="Dynamic" ErrorMessage="Invalid Email!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                        Width="208px"></asp:RegularExpressionValidator>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblDirectmail" runat="server" Width="84px"></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <asp:CheckBox ID="ChkDrml" runat="server"  />
                                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">
                                                    <asp:Label ID="lblPager" runat="server" Width="72px"></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 27%">
                                                    <asp:TextBox ID="txtPager" runat="server" CssClass="standardtextbox" Width="116px"></asp:TextBox>
                                                </td>
                                                <td class="formcontent" width="20%">
                                                    &nbsp;<asp:Label ID="lblFax" runat="server" Width="74px"></asp:Label>
                                                </td>
                                                <td class="formcontent" width="20%">
                                                    <asp:TextBox ID="txtFax" runat="server" CssClass="standardtextbox" Width="84px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="test" colspan="4">
                                                    <span>Personal Details</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblHeight" runat="server"></asp:Label>
                                                </td>
                                                <td class="formcontent" style="width: 27%;" >
                                                    <asp:TextBox ID="txtHeight1" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                                            MaxLength="10" Width="100"></asp:TextBox>
                                                        <asp:TextBox ID="txtHeight" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                                            MaxLength="10" Width="100" Visible="true"></asp:TextBox><asp:CompareValidator ID="cvHeight" runat="server"
                                                                ControlToValidate="txtHeight1" Display="Dynamic" ErrorMessage="Invalid height!"
                                                                Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblWeight" runat="server"></asp:Label>
                                                </td>
                                                <td class="formcontent" width="20%" >
                                                    <asp:TextBox ID="txtWeight" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                                        MaxLength="10" Width="88px"></asp:TextBox>
                                                    <asp:CompareValidator ID="cvWeight" runat="server"
                                                            ControlToValidate="txtWeight" Display="Dynamic" ErrorMessage="Invalid weight!"
                                                            Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%">
                                                    <span>
                                                        <asp:Label ID="lblOccup" runat="server" Width="78px"></asp:Label><font color="Red">*</font>
                                                    </span>
                                                </td>
                                                <td class="formcontent" style="width: 27%">
                                                    <asp:TextBox ID="txtOccupationCode" runat="server" CssClass="standardtextbox" Width="50px"
                                                        onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                    <asp:TextBox ID="txtOccupationDesc" runat="server" CssClass="standardtextbox" Width="88px"
                                                        Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                                                    <asp:Button ID="btnOccupation" runat="server" CausesValidation="False" CssClass="standardbutton"
                                                        Text="..." Width="20px" OnClick="btnOccupation_Click" />
                                                    <asp:RequiredFieldValidator ID="rfvOccupation" runat="server" ControlToValidate="txtOccupationDesc"
                                                        Display="Dynamic" Enabled="true" ErrorMessage="Mandatory!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="formcontent" width="20%">
                                                    <span>
                                                        <asp:Label ID="lblAnnualIncome" runat="server" Width="104px"></asp:Label>
                                                    </span>
                                                </td>
                                                <td class="formcontent" width="30%">
                                                    <asp:TextBox ID="txtALIncome" runat="server" Width="90px" MaxLength="20" CssClass="standardtextbox"></asp:TextBox>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtALIncome"
                                                        CultureInvariantValues="True" Display="Dynamic" ErrorMessage="Invalid Annual Income"
                                                        MaximumValue="99999999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblPreferedClient" runat="server" Width="108px"></asp:Label>
                                                </td>
                                                <td class="formcontent" colspan="3" width="80%" >
                                                    <asp:CheckBox ID="chkVip" runat="server" CssClass="standardcheckbox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblStaff" runat="server" Width="42px"></asp:Label>
                                                </td>
                                                <td class="formcontent" colspan="3" width="80%" >
                                                    <asp:CheckBox ID="chkStaff" runat="server" CssClass="standardcheckbox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <asp:Label ID="lblServiceTax" runat="server" Width="146px"></asp:Label>
                                                </td>
                                                <td class="formcontent" colspan="3" width="80%" >
                                                    <asp:CheckBox ID="chkSalesTax" runat="server" CssClass="standardcheckbox" Width="300" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" width="20%" >
                                                    <span>
                                                        <asp:Label ID="lblRemark" runat="server" Width="80px"></asp:Label>
                                                    </span>
                                                </td>
                                                <td width="80%" colspan="3" class="formcontent" >
                                                    <asp:TextBox ID="Menu1" runat="server" Width="658px" Font-Overline="false" MaxLength="100"
                                                        CssClass="standardtextbox" Height="60px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:RequiredFieldValidator id="rfvDupFlg" runat="server" SetFocusOnError="True" ErrorMessage="Please press 'Exact Match' button to check the match client before proceed." Enabled="true" Display="Dynamic" ControlToValidate="txtDupBtnFlag"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator id="rfvAMLFlag" runat="server" SetFocusOnError="True" ErrorMessage="Please press 'AML' button before proceed." Enabled="true" Display="Dynamic" ControlToValidate="txtAMLFlag"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%">
                                        <table id="Table2" runat="server" class="container">
                                            <tr>
                                                <td align="left" style="width:100%;">
                                                    <asp:Button ID="btnSave" runat="server" Text="Update" Width="80px" OnClick="btnSave_Click"
                                                        CausesValidation="true" CssClass="standardbutton" />
                                                    <asp:Button ID="btnDupCltRecords" runat="server" Text="Exact Match" Enabled="true"  CausesValidation="false" 
                                                    CssClass="standardbutton" />
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Width="80px"
                                                        Text="Cancel" CssClass="standardbutton" OnClientClick="doCancel2();return false" OnClick="btnCancel_Click" />&nbsp;
                                                </td>
                                                <td align="right" width= "100%" >
                                                    <uc8:ClientAML ID="btnAML" runat="server" CssClass="standardbutton" OnLoad="btnAML_Load" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left"><br /><br />
                                                    <asp:Label Text="Note :- Please proceed to agent creation after client creation is complete." Font-Size="Small" runat="server" 
                                                    ForeColor="red"></asp:Label>
                                                </td>
                    	                    </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdPanelBtn" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <contenttemplate>
                                                            <asp:TextBox ID="txtFlagFind" runat="server" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" ></asp:TextBox>
                                                            <asp:TextBox ID="lblErrMsg2" runat="server" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" Wrap="true" ></asp:TextBox>
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                        <script language="javascript" type="text/javascript">
                            //Commented by Ibrahim on 17-06-2013  for Blocking  Old popup Start
//                            var err = "<%=lblErrMsg.Text%>";
//                            if (err != "")
//                            {
//                                alert(err);
                            //                            }
                            //Commented by Ibrahim on 17-06-2013  for Removing  lifeasia pop up End
                        </script>

                        <!---------------------------------------Error/Confirmation MsgBox--------------------------------------------->
                        <asp:Button ID="hdnbtn" Style="visibility: hidden" runat="server" Text="Button" OnClick="hdnbtn_OnClick" />
                        <asp:Button ID="hdnbtn2" Style="visibility: hidden" runat="server" Text="Button" OnClick="hdnbtn_OnClick" />
                        <asp:Button ID="hdnComfirmbtn" Style="visibility: hidden" runat="server" Text="Button" OnClick="hdnComfirmbtn_OnClick" />
                        <asp:Button ID="hdnComfirmbtnM" Style="visibility: hidden" runat="server" Text="Button" OnClick="hdnComfirmbtn_OnClick" OnLoad="MPE_OnClick" />
                        <!---------------------------------------Error Msg--------------------------------------------->
                        <asp:Panel ID="PanelError" runat="server" BackColor="#E0E0E0" HorizontalAlign="Center" Style="display: none" Width="400px">
                            <br />
                            <asp:UpdatePanel runat="server" id="upderror" RenderMode="Inline" UpdateMode="Conditional">
                                <contenttemplate>
                                    <asp:Label id="lblError1" runat="server" Text="Message." Width="380px"  Font-Bold="true" Font-Size="8pt"></asp:Label>
                                    <br />
                                    <asp:TextBox id="lblError2" runat="server" Text="Label" Width="380px" Enabled="false" TextMode="MultiLine" Height="100px" BorderStyle="None" 
                                    Wrap="true"></asp:TextBox>
                                    <br />
                                    <asp:Label id="lblError3" runat="server" Width="380px"></asp:Label> 
                                </contenttemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmdYes" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cmdNo" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cmdYesM" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cmdErrorCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                </triggers>
                            </asp:UpdatePanel>
                            <asp:Button ID="cmdErrorCancel" runat="server" Width="59px" Text="OK" CssClass="standardbutton" CausesValidation="false" OnClick="cmdOk_ClsMsg" />
                            <br />
                            <br />
                        </asp:Panel>
                        <!---------------------------------------Error Msg 2--------------------------------------------->
                        <asp:Panel ID="PanelError2" runat="server" BackColor="#E0E0E0" HorizontalAlign="Center" Style="display: none" Width="400px">
                            <br />
                            <asp:UpdatePanel runat="server" id="upderror2" RenderMode="Inline" UpdateMode="Conditional">
                                <contenttemplate>
                                    <asp:Label id="lblError21" runat="server" Text="Message." Width="380px"  Font-Bold="true" Font-Size="8pt"></asp:Label>
                                    <br />
                                    <asp:TextBox id="lblError22" runat="server" Text="Label" Width="380px" Enabled="false" TextMode="MultiLine" Height="100px" 
                                    BorderStyle="None" Wrap="true"></asp:TextBox>
                                    <br />
                                    <asp:Label id="lblError23" runat="server" Width="380px" ></asp:Label> 
                                </contenttemplate>
                                <triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmdErrorCancel2" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="cmdErrorCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                </triggers>
                            </asp:UpdatePanel>
                            <asp:Button ID="cmdErrorCancel2" runat="server" Width="59px" Text="OK" CssClass="standardbutton" CausesValidation="false" OnClick="cmdOk_ClsMsg" />
                            <br />
                            <br />
                        </asp:Panel>
                        <!---------------------------------------Confirm Msg--------------------------------------------->
                        <asp:Panel ID="PanelComfirm" DefaultButton="cmdYes" runat="server" BackColor="#E0E0E0" OnLoad="MPE_Onload" HorizontalAlign="Center" Style="display: none" Width="400px">
                            <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;border-bottom: black 1px solid" width="400">
                                <tr>
                                    <td align="left" valign="top" class="test">
                                        <asp:Label ID="lblComfirmHeader" runat="server" Font-Size="8pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent2">
                                        <br />
                                        <asp:UpdatePanel runat="server" id="updcomfirm" RenderMode="Inline" UpdateMode="Conditional">
                                            <contenttemplate>
                                                <asp:Label id="lblComfirm1" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                                <asp:Label id="lblComfirm2" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                                <asp:Label id="lblComfirm3" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                            </contenttemplate>
                                            <triggers>
                                                <asp:AsyncPostBackTrigger ControlID="cmdYes" EventName="Click"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="cmdNo" EventName="Click"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="cmdCancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                            </triggers>
                                        </asp:UpdatePanel><br />
                                        <asp:Button ID="cmdYes" runat="server" Width="59px" Text="Yes" CssClass="standardbutton"
                                            CausesValidation="false" OnClick="cmdYes_Click" />
                                        <asp:Button ID="cmdNo" runat="server" Width="59px" Text="No" CssClass="standardbutton"
                                            CausesValidation="false" OnClick="cmdNo_Click" />
                                        <asp:Button ID="cmdCancel" runat="server" Width="59px" Text="Cancel" CausesValidation="false"
                                            CssClass="standardbutton" OnClick="cmdCancel_Click" />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div id="div2">
                        <!---------------------------------------Confirm Msg--------------------------------------------->
                        <asp:Panel ID="PanelComfirmM" DefaultButton="cmdYesM" runat="server" BackColor="#E0E0E0"
                            OnLoad="MPE_Onload" HorizontalAlign="Center" Style="display: none" Width="400px">
                            <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;border-bottom: black 1px solid" width="400">
                                <tr>
                                    <td align="left" valign="top" class="test">
                                        <asp:Label ID="Label1" runat="server" Font-Size="8pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formcontent2">
                                        <br />
                                        <asp:UpdatePanel runat="server" id="updcomfirmM" RenderMode="Inline" UpdateMode="Conditional">
                                            <contenttemplate>
                                                <asp:Label id="lblComfirmM1" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                                <asp:Label id="lblComfirmM2" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                                <asp:Label id="lblComfirmM3" runat="server" Width="380px" Font-Size="8pt"></asp:Label>
                                                <br />
                                            </contenttemplate>
                                            <triggers>
                                                <asp:AsyncPostBackTrigger ControlID="cmdYesM" EventName="Click"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="cmdCancelM" EventName="Click"></asp:AsyncPostBackTrigger>
                                            </triggers>
                                        </asp:UpdatePanel><br />
                                        <asp:Button ID="cmdYesM" runat="server" Width="59px" Text="Yes" CssClass="standardbutton" CausesValidation="false" OnClick="cmdYes_Click" />
                                        <asp:Button ID="cmdCancelM" runat="server" Width="59px" Text="Cancel" CausesValidation="false"
                                            CssClass="standardbutton" OnClick="cmdCancel_Click" />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="PanelModalPopup" runat="server" BackColor="#E0E0E0">
                            <ajaxToolkit:ModalPopupExtender ID="MPEError" TargetControlID="hdnbtn" runat="server"
                                BackgroundCssClass="modalBackground" PopupControlID="PanelError">
                            </ajaxToolkit:ModalPopupExtender>
                            <ajaxToolkit:ModalPopupExtender ID="MPEError2" TargetControlID="hdnbtn2" runat="server"
                                BackgroundCssClass="modalBackground" PopupControlID="PanelError2" CancelControlID="cmdErrorCancel2">
                            </ajaxToolkit:ModalPopupExtender>
                            <ajaxToolkit:ModalPopupExtender ID="MPEComfirm" TargetControlID="hdnComfirmbtn" runat="server"
                                BackgroundCssClass="modalBackground" PopupControlID="PanelComfirm" CancelControlID="cmdCancel"
                                OnCancelScript="SetFocus('ctl00_ContentPlaceHolder1_cmdCancel');">
                            </ajaxToolkit:ModalPopupExtender>
                            <ajaxToolkit:ModalPopupExtender ID="MPEComfirmM" TargetControlID="hdnComfirmbtnM"
                                runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelComfirmM"
                                CancelControlID="cmdCancelM" OnCancelScript="SetFocus('ctl00_ContentPlaceHolder1_cmdCancelM');">
                            </ajaxToolkit:ModalPopupExtender>
                        </asp:Panel>
                    </div>
                    <asp:HiddenField runat="server" ID="hdnDupFlag" />
                    <asp:HiddenField runat="server" ID="hdnTempClientCode" />
                    <asp:HiddenField runat="server" ID="hdnClientCode" />
                    <%--for cda pan updation start--%>
                    <asp:HiddenField ID="hdnPan" runat="server" /> 
                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                    <%--for cda pan updation end--%>
                    <asp:TextBox runat="server" ID="txtDupBtnFlag" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" Wrap="true" />
                    <asp:TextBox runat="server" ID="txtAMLFlag" Width="0px" Text="" BorderStyle="None" BorderColor="transparent" Wrap="true" />
                </td>
            </tr>
        </table>
    </div>
    
     <script type="text/javascript">
        function funOpenPopWin(strPageName, strPayeeCode, strValue, strCode, strSource)
		{
		    if(strPageName == 'DuplicateCltRecords.aspx')
		    {
		        document.getElementById('<%= txtDupBtnFlag.ClientID%>').value = "1";
		    }
		    showPopWin(strPageName + "?Code=" + strPayeeCode + "&Field1=" + strValue + "&Field2=" + strCode + "&Source=" + strSource, 500, 350, null);
		    return false;
		}		
    </script>
    <asp:Panel runat="server" ID="pnlMdl" Width ="400" display = "none" >
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0" display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
       >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="200px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center><asp:Label ID="lblmsg" runat="server"></asp:Label></center>                           
                    <br />
                    <center><asp:Label ID="lblmsg4" runat="server"></asp:Label></center> 
                    <br />
                    <center><asp:Label ID="lblmsg5" runat="server"></asp:Label></center> 
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <center><asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" /></center>                     
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblmsg"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>
